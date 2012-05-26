using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SHF_BT;

namespace CHSTRAS_091_BT.Common
{
    class btCHSTRAS_091_Unit
    {
        private Hashtable userUnitIDs;
        private btCHSTRAS_091_Database database;
        private btCHSTRAS_091_Base bt;
        private DateTime startTime;
        private int totalNum, completeNum, totalScore, rightNum, answerTime;

        public btCHSTRAS_091_Unit(DateTime startTime, int totalNum, btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice)
        {
            bt = new btCHSTRAS_091_Base();
            userUnitIDs = bt.getUserUnitIDs(shfUserLogin, shfUnitPratice);
            answerTime = bt.getAnswerTime(startTime);
            this.startTime = startTime;
            this.totalNum = totalNum;
        }

        public void record()
        {
            getStatistics();
            Hashtable keyValues = new Hashtable();
            foreach (DictionaryEntry userUnitID in userUnitIDs)
            {
                keyValues.Add(userUnitID.Key, userUnitID.Value);
            }
            keyValues.Add("StartDateTime", startTime);
            keyValues.Add("PracticeTime", bt.getAnswerTime(startTime));
            keyValues.Add("TotalNumber", totalNum);
            keyValues.Add("CompleteNumber", completeNum);
            keyValues.Add("RightNumber", rightNum);
            keyValues.Add("ErrorNumber", completeNum - rightNum);
            keyValues.Add("CorrectRate", rightNum / completeNum);
            keyValues.Add("TotalScore", totalScore);
            database.insert("R_SHFItemScores", keyValues);
        }

        private void getStatistics()
        {
            String where = "StartDateTime>=#" + startTime + "#";
            String[] selections = new String[] { "TestScore" };
            database = new btCHSTRAS_091_Database();
            IDataReader reader = database.query("R_SHFItemScores", selections, where, null);
            completeNum = database.getSize();
            totalScore = 0;
            while (reader.Read())
            {
                totalScore += reader.GetInt32(0);
            }
            where = "StartDateTime>=#" + startTime + "# AND TestRight=true";
            database.query("R_SHFItemScores", selections, where, null);
            rightNum = database.getSize();
        }
    }
}
