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
        btCHSTRAS_091_Base bt;

        public btCHSTRAS_091_Item(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice)
        {
            database = new btCHSTRAS_091_Database();
            bt = new btCHSTRAS_091_Base();
            userUnitIDs = bt.getUserUnitIDs(shfUserLogin, shfUnitPratice);
        }

        public void record(int questionID, DateTime startTime,
            String testAnswer, bool testRight, int testScore)
        {
            Hashtable keyValues = new Hashtable();
            foreach (DictionaryEntry userUnitID in userUnitIDs)
            {
                keyValues.Add(userUnitID.Key, userUnitID.Value);
            }
            keyValues.Add("QuestionID", questionID);
            keyValues.Add("StartDateTime", startTime);
            keyValues.Add("AnswerTime", bt.getAnswerTime(startTime));
            keyValues.Add("TestAnswer", testAnswer);
            keyValues.Add("TestRight", testRight);
            keyValues.Add("TestScore", testScore);
            database.insert("R_SHFItemScores", keyValues);
        }

    }
}
