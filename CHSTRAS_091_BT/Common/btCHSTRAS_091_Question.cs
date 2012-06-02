using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;
using System.Data;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Question
    {
        public int QuestionID, QuestionDiff, QuestionScore, AverageTime;
        public string QuestionSubject, Question, QuestionSolution,
            QuestionAnswer;
        private IDataReader reader;
        private btCHSTRAS_091_Database database;

        public btCHSTRAS_091_Question(btSHFUnitPractice unitPractice,
            int courseType)
        {
            btCHSTRAS_091_Base bt = new btCHSTRAS_091_Base();
            int pageID = bt.getPagesID(unitPractice);
            database = new btCHSTRAS_091_Database();
            String where = "QuestionType=" + pageID + " AND " +
                "QuestionTag=\'" + courseType + "\'";
            String[] columns = new String[] {"QuestionID", "QuestionDiff",
                "QuestionScore", "AverageTime", "QuestionSubject",
                "Question","QuestionSolution", "QuestionAnswer"};
            reader = database.query("E_SHFQuestions", columns, where, null);
        }

        public int getSize()
        {
            return database.getSize();
        }

        public bool moveToNext()
        {
            if (reader.Read())
            {
                //TODO: Handle the db null.
                QuestionID = reader.GetInt32(0);
                QuestionDiff = reader.GetInt32(1);
                QuestionScore = reader.GetInt32(2);
                AverageTime = reader.GetInt32(3);
                QuestionSubject = reader.GetString(4) + "";
                Question = reader.GetString(5) + "";
                if (!reader.IsDBNull(6))
                    QuestionSolution = reader.GetString(6) + "";
                else
                    QuestionSolution = null;
                QuestionAnswer = reader.GetString(7) + "";
                return true;
            }
            else
            {
                QuestionID = -1;
                QuestionDiff = -1;
                QuestionScore = -1;
                AverageTime = -1;
                QuestionSubject = null;
                Question = null;
                QuestionSolution = null;
                QuestionAnswer = null;
                return false;
            }
        }
    }
}
