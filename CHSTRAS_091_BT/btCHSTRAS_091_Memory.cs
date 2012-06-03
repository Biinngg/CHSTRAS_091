using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;
using System.Drawing;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Memory : btCHSTRAS_091_Question
    {
        public Image open, close;
        private btCHSTRAS_091_File file;
        private Common.btCHSTRAS_091_Item item;
        private Common.btCHSTRAS_091_Unit unit;
        private bool submitMark = true;

        public btCHSTRAS_091_Memory(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice, int courseType, int itemNumber)
            : base(shfUnitPratice, courseType)
        {
            item = new Common.btCHSTRAS_091_Item(shfUserLogin, shfUnitPratice);
            unit = new Common.btCHSTRAS_091_Unit(getSize(), shfUserLogin, shfUnitPratice);
            file = new btCHSTRAS_091_File();
            open = file.getImage("open.png");
            close = file.getImage("close.png");
        }

        public Image getQuestion()
        {
            return file.getImage(Question);
        }

        public int getAnswer()
        {
            return System.Convert.ToInt32(QuestionAnswer);
        }

        public void record(int testAnswer, bool testRight)
        {
            String answer = testAnswer + "";
            int testScore = QuestionScore;
            if (!testRight)
            {
                testScore = 0;
            }
            item.record(QuestionID, answer, testRight, testScore);
        }

        public String submit()
        {
            if (submitMark)
            {
                submitMark = false;
                unit.record();
                return unit.getStatistics();
            }
            return null;
        }
    }
}
