using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;
using System.Drawing;
using System.Data;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Fault : btCHSTRAS_091_Question
    {
        private btCHSTRAS_091_File file;
        private Common.btCHSTRAS_091_Item item;
        private Common.btCHSTRAS_091_Unit unit;
        private bool submitMark = true;
        private String testAnswer = "";

        public class Correct
        {
            public String text;
            public bool right;
        }

        public btCHSTRAS_091_Fault(btSHFUserLogin shfUserLogin,
            btSHFUnitPractice shfUnitPratice, int courseType, int itemNumber)
            : base(shfUnitPratice, courseType)
        {
            item = new Common.btCHSTRAS_091_Item(shfUserLogin, shfUnitPratice);
            unit = new Common.btCHSTRAS_091_Unit(getSize(), shfUserLogin, shfUnitPratice);
            file = new btCHSTRAS_091_File();
        }

        public Correct[] getAnswers(int clickNum)
        {
            btCHSTRAS_091_Database db = new btCHSTRAS_091_Database();
            String[] selections = new String[] {"Question","QuestionAnswer" };
            String where = "QuestionSubject=\'" + QuestionID + "." + clickNum + "\'";
            IDataReader reader = db.query("E_SHFQuestions", selections, where, null);
            reader.Read();
            String question = reader.GetString(0);
            String answer = reader.GetString(1);
            String[] questions = question.Split(new char[] { ',' });
            int right = System.Convert.ToInt32(answer);
            Correct[] correct = new Correct[questions.Length];
            for (int i = 0; i < questions.Length; i++)
            {
                correct[i] = new Correct();
                correct[i].text = questions[i];
                if (i == right)
                    correct[i].right = true;
                else
                    correct[i].right = false;
            }
            return correct;
        }

        public void saveAnswer(String answer)
        {
            testAnswer += answer + ",";
        }

        public void record()
        {
            if(testAnswer.Length>0)
                testAnswer = testAnswer.Substring(0, testAnswer.Length - 1);
            int rightNum = testAnswer.Split(new char[] { ',' }).Length;
            int total = QuestionAnswer.Split(new char[] { ',' }).Length;
            int score = rightNum * QuestionScore / total;
            bool testRight = false;
            if (rightNum == total)
                testRight = true;
            item.record(QuestionID, testAnswer, testRight, score);
            testAnswer = "";
        }

        public String submit()
        {
            if (submitMark)
            {
                record();
                submitMark = false;
                unit.record();
                return unit.getStatistics();
            }
            return null;
        }
    }
}
