using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;
using System.Drawing;
using System.Drawing.Imaging;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Puzzle : btCHSTRAS_091_Question
    {
        private int itemNumber;
        public Image finger;
        private btCHSTRAS_091_File file;
        private bool submitMark = true;
        private Common.btCHSTRAS_091_Item item;
        private Common.btCHSTRAS_091_Unit unit;

        public class PuzzlePic
        {
            public Bitmap image;
            public int order;
        }

        public btCHSTRAS_091_Puzzle(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice, int courseType, int itemNumber)
            : base(shfUnitPratice, courseType)
        {
            this.itemNumber = itemNumber;
            file = new btCHSTRAS_091_File();
            item = new Common.btCHSTRAS_091_Item(shfUserLogin, shfUnitPratice);
            unit = new Common.btCHSTRAS_091_Unit(getSize(), shfUserLogin, shfUnitPratice);
            finger = file.getImage("finger.png");
        }

        public void record(bool testRight)
        {
            int testScore;
            if (testRight)
                testScore = QuestionScore;
            else
                testScore = 0;
            item.record(QuestionID, null, testRight, testScore);
        }

        public String submit(bool lastTestRight)
        {
            if (submitMark)
            {
                submitMark = false;
                record(lastTestRight);
                unit.record();
                return unit.getStatistics();
            }
            return null;
        }

        public PuzzlePic[] getOriginPic()
        {
            Image origin = getAnswer();
            return placeRandom(origin);
        }

        public Image getAnswer()
        {
            btCHSTRAS_091_File file = new btCHSTRAS_091_File();
            return file.getImage(QuestionSubject);
        }

        private Boolean numNotExists(int num, int[,] pos)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (pos[i, j] == num)
                        return false;
                }
            return true;
        }

        private PuzzlePic[] placeRandom(Image img)
        {
            PuzzlePic[] puzzlePic = new PuzzlePic[9];
            Bitmap myBit = new Bitmap(img);
            Rectangle cloneRect;
            PixelFormat format;
            Random rnd = new Random();
            int i = 1;
            int ar = 0;
            int ac = 0;
            int val;
            int[,] pos = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            format = myBit.PixelFormat;
            while (i < 10)
            {
                val = rnd.Next(10);
                if (numNotExists(val, pos) == true && val > 0)
                {
                    pos[ar, ac] = val;
                    int p = ar * myBit.Width / 3;
                    int q = ac * myBit.Height / 3;
                    cloneRect = new Rectangle(p, q, myBit.Width / 3, myBit.Height / 3);
                    puzzlePic[val - 1] = new PuzzlePic();
                    puzzlePic[val - 1].order = i - 1;
                    puzzlePic[val - 1].image = myBit.Clone(cloneRect, format);
                    ac++;
                    if (ac > 2)
                    {
                        ac = 0;
                        ar++;
                    }
                    i++;
                }
                else
                    continue;
            }
            return puzzlePic;
        }
    }
}
