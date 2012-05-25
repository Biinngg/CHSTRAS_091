using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;

namespace CHSTRAS_091_BT.Common
{
    class btCHSTRAS_091_Unit
    {
        private Hashtable userUnitIDs;
        private btCHSTRAS_091_Database database;
        private btCHSTRAS_091_Base bt;

        public btCHSTRAS_091_Unit(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice)
        {
            database = new btCHSTRAS_091_Database();
            bt = new btCHSTRAS_091_Base();
            userUnitIDs = bt.getUserUnitIDs(shfUserLogin, shfUnitPratice);
        }

        public void record(DateTime startTime, int totalNum, int completeNum,
            String testAnswer, bool testRight, int testScore)
        {
            //TODO: completenumber等可以通过item算出
            Hashtable keyValues = new Hashtable();
            foreach (DictionaryEntry userUnitID in userUnitIDs)
            {
                keyValues.Add(userUnitID.Key, userUnitID.Value);
            }
            keyValues.Add("StartDateTime", startTime);
            keyValues.Add("PracticeTime", bt.getAnswerTime(startTime));
            keyValues.Add("TotalNumber", totalNum);
            keyValues.Add("CompleteNumber", completeNum);
            keyValues.Add("TestAnswer", testAnswer);
            keyValues.Add("TestRight", testRight);
            keyValues.Add("TestScore", testScore);
            database.insert("R_SHFItemScores", keyValues);
        }
    }
}
