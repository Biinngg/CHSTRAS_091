using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
using System.Collections;
using System.Data;
using CHSTRAS_091_BT.Common;
using System.Drawing;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Link
    {
        private btSHFUserLogin shfUserLogin;
        private btSHFUnitPractice shfUnitPratice;
        private btCHSTRAS_091_Item item;
        private btCHSTRAS_091_Unit unit;
        private btCHSTRAS_091_File file;
        private btCHSTRAS_091_Question question;
        private String[] textNames, imageNames, questionAnswer;
        private int arrayLength, totalNumber;

        public btCHSTRAS_091_Link(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice, int courseType, int arrayLength)
        {
            this.arrayLength = arrayLength;
            this.shfUserLogin = shfUserLogin;
            this.shfUnitPratice = shfUnitPratice;
            file = new btCHSTRAS_091_File();
            question = new btCHSTRAS_091_Question(shfUnitPratice, courseType);
            totalNumber = question.getSize();
            unit = new btCHSTRAS_091_Unit(DateTime.Now, totalNumber, shfUserLogin, shfUnitPratice);
            item = new btCHSTRAS_091_Item(shfUserLogin, shfUnitPratice);
            textNames = new String[arrayLength];
            imageNames = new String[arrayLength];
        }

        public String submit()
        {
            unit.record();
            return unit.getStatistics();
        }

        public ArrayList record(ArrayList answer)
        {
            questionAnswer = question.QuestionAnswer.Split(new char[] { ',' });
            ArrayList result = new ArrayList(arrayLength);
            int questionID = question.QuestionID;
            String testAnswer = "";
            bool testRight = true;
            int testScore;
            int rightNum = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                testAnswer += answer[i] + ",";
                bool b = questionAnswer[i].Equals(answer[i]+"");
                if(b)
                {
                    rightNum++;
                }
                result.Add(b);
            }
            testAnswer = testAnswer.Substring(0, testAnswer.Length - 1);
            if (rightNum < arrayLength)
            {
                testRight = false;
            }
            testScore = rightNum * question.QuestionScore / arrayLength;
            item.record(questionID, testAnswer, testRight, testScore);
            return result;
        }

        public int getSize()
        {
            return totalNumber;
        }

        public bool moveToNext()
        {
            return question.moveToNext();
        }

        public Image[] getImages()
        {
            Image[] images = new Image[arrayLength];
            String[] imageNames = new String[arrayLength] ;
            if (question.QuestionSubject != null)
            {
                imageNames = question.QuestionSubject.Split(new char[]{','});
            }
            for (int i = 0; i < arrayLength; i++)
            {
                images[i] = file.getImage(imageNames[i]);
            }
            return images;
        }

        public String[] getTexts()
        {
            String[] texts = new String[arrayLength];
            String[] textNames = new String[arrayLength];
            if (question.Question != null)
            {
                textNames = question.Question.Split(new char[] { ',' });
            }
            for (int i = 0; i < arrayLength; i++)
            {
                texts[i] = file.getText(textNames[i]);
            }
            return texts;
        }

        public ArrayList getAnswers()
        {
            ArrayList list = new ArrayList(arrayLength);
            for(int i=0;i<arrayLength;i++)
            {
                list.Add(Convert.ToInt32(questionAnswer[i]));
            }
            return list;
        }
    }
}
