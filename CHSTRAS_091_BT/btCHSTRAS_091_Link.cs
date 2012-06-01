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
        private String[] textNames, imageNames;
        private int arrayLength;

        public btCHSTRAS_091_Link(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice, int courseType, int arrayLength)
        {
            this.arrayLength = arrayLength;
            this.shfUserLogin = shfUserLogin;
            this.shfUnitPratice = shfUnitPratice;
            file = new btCHSTRAS_091_File();
            question = new btCHSTRAS_091_Question(shfUnitPratice, courseType);
            unit = new btCHSTRAS_091_Unit(DateTime.Now, question.getSize(), shfUserLogin, shfUnitPratice);
            item = new btCHSTRAS_091_Item(shfUserLogin, shfUnitPratice);
            textNames = new String[arrayLength];
            imageNames = new String[arrayLength];
        }

        public void moveToNext()
        {
            question.moveToNext();
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
                Console.Write("i=" + i + "arrayLength=" + arrayLength + "imageNames[i]=" + imageNames[i]);
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
    }
}
