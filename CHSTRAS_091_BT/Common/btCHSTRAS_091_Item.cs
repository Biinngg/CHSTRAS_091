using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;

namespace CHSTRAS_091_BT.Common
{
    class btCHSTRAS_091_Item
    {
        private btCHSTRAS_091_Database database;
        private Hashtable userUnitIDs;
        private btCHSTRAS_091_Base bt;
        private DateTime startTime;

        public btCHSTRAS_091_Item(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice)
        {
            database = new btCHSTRAS_091_Database();
            bt = new btCHSTRAS_091_Base();
            userUnitIDs = bt.getUserUnitIDs(shfUserLogin, shfUnitPratice);
            startTime = DateTime.Now;
        }

        public void record(int questionID, String testAnswer, bool testRight, int testScore)
        {
            btCHSTRAS_091_Time time = new btCHSTRAS_091_Time();
            Hashtable keyValues = new Hashtable();
            foreach (DictionaryEntry userUnitID in userUnitIDs)
            {
                keyValues.Add(userUnitID.Key, userUnitID.Value);
            }
            keyValues.Add("QuestionID", questionID);
            keyValues.Add("StartDateTime", startTime);
            keyValues.Add("AnswerTime", time.getAnswerTime(startTime));
            if(testAnswer != null)
            keyValues.Add("TestAnswer", testAnswer);
            keyValues.Add("TestRight", testRight);
            keyValues.Add("TestScore", testScore);
            database.insert("R_SHFItemScores", keyValues);
            startTime = DateTime.Now;
        }


    }
}
