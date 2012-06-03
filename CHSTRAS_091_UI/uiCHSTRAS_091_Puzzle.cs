using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CHSTRAS_091_BT;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_Puzzle : uiCHSTRAS_091_Base
    {
        private PictureBox[] pictureBoxL, pictureBoxR;
        private btCHSTRAS_091_Puzzle puzzle;
        private btCHSTRAS_091_Puzzle.PuzzlePic[] puzzlePic;
        private int blockNum, timeMark;
        private bool answer;

        public uiCHSTRAS_091_Puzzle(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPratice, int courseType)
            : base(form, shfUserLogin, shfUnitPratice, courseType)
        {
            InitializeComponent();

            pictureBoxL = new PictureBox[] { pictureBoxL1, pictureBoxL2, pictureBoxL3,
                pictureBoxL4, pictureBoxL5, pictureBoxL6, pictureBoxL7, pictureBoxL8, pictureBoxL9 };
            pictureBoxR = new PictureBox[] { pictureBoxR1, pictureBoxR2, pictureBoxR3,
                pictureBoxR4, pictureBoxR5, pictureBoxR6, pictureBoxR7, pictureBoxR8, pictureBoxR9 };
            itemNumber = pictureBoxL.Length;
            puzzle = new btCHSTRAS_091_Puzzle(shfUserLogin, shfUnitPratice, courseType, itemNumber);
            totalNumber = puzzle.getSize();
            next();
        }

        private void buttonForward_Click_1(object sender, EventArgs e)
        {
            if (blockNum < itemNumber)
                answer = false;
            puzzle.record(answer);
            next();
        }

        private void next()
        {
            clean();
            puzzle.moveToNext();
            puzzlePic = puzzle.getOriginPic();
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBoxL[i].BackgroundImage = puzzlePic[i].image;
            }
        }

        private void moveToNext()
        {
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBoxL[i].Image = null;
            }
            blockNum++;
            if (blockNum >= itemNumber)
            {
                disResult();
                return;
            }
            pictureBoxL[blockNum].Image = puzzle.finger;
        }

        private void clean()
        {
            answer = true;
            timeMark = -1;
            pictureBoxResult.Visible = false;
            buttonAnswer.Enabled = true;
            blockNum = -1;
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBoxR[i].Enabled = true;
                pictureBoxR[i].BackgroundImage = null;
            }
            moveToNext();
        }

        private void disResult()
        {
            pictureBoxResult.Visible = true;
            if (answer)
            {
                pictureBoxResult.Image = puzzle.happy;
            }
            else
            {
                pictureBoxResult.Image = puzzle.angry;
            }
        }

        private void judge(int pictureBoxNum)
        {
            int num = pictureBoxNum - 1;
            if (num != puzzlePic[blockNum].order)
            {
                answer = false;
            }
            Console.Write("num=" + num + " order=" + puzzlePic[blockNum].order + " blockNum=" + blockNum + " answer=" + answer + "\n");
        }

        private void pictureBoxR1_Click(object sender, EventArgs e)
        {
            pictureBoxR1.BackgroundImage = puzzlePic[blockNum].image;
            judge(1);
            pictureBoxR1.Enabled = false;
            moveToNext();
        }

        private void pictureBoxR2_Click(object sender, EventArgs e)
        {
            pictureBoxR2.BackgroundImage = puzzlePic[blockNum].image;
            judge(4);
            pictureBoxR2.Enabled = false;
            moveToNext();
        }

        private void pictureBoxR3_Click(object sender, EventArgs e)
        {
            pictureBoxR3.BackgroundImage = puzzlePic[blockNum].image;
            judge(7);
            pictureBoxR3.Enabled = false;
            moveToNext();
        }

        private void pictureBoxR4_Click(object sender, EventArgs e)
        {
            pictureBoxR4.BackgroundImage = puzzlePic[blockNum].image;
            judge(2);
            pictureBoxR4.Enabled = false;
            moveToNext();
        }

        private void pictureBoxR5_Click(object sender, EventArgs e)
        {
            pictureBoxR5.BackgroundImage = puzzlePic[blockNum].image;
            judge(5);
            pictureBoxR5.Enabled = false;
            moveToNext();
        }

        private void pictureBoxR6_Click(object sender, EventArgs e)
        {
            pictureBoxR6.BackgroundImage = puzzlePic[blockNum].image;
            judge(8);
            pictureBoxR6.Enabled = false;
            moveToNext();
        }

        private void pictureBoxR7_Click(object sender, EventArgs e)
        {
            pictureBoxR7.BackgroundImage = puzzlePic[blockNum].image;
            judge(3);
            pictureBoxR7.Enabled = false;
            moveToNext();
        }

        private void pictureBoxR8_Click(object sender, EventArgs e)
        {
            pictureBoxR8.BackgroundImage = puzzlePic[blockNum].image;
            judge(6);
            pictureBoxR8.Enabled = false;
            moveToNext();
        }

        private void pictureBoxR9_Click(object sender, EventArgs e)
        {
            pictureBoxR9.BackgroundImage = puzzlePic[blockNum].image;
            judge(9);
            pictureBoxR9.Enabled = false;
            moveToNext();
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            buttonAnswer.Enabled = false;
            pictureBoxResult.Visible = true;
            pictureBoxResult.Image = puzzle.getAnswer();
            timeMark = 0;
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBoxR[i].Enabled = false;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeMark >= 0)
            {
                if (timeMark < 2)
                {
                    timeMark++;
                }
                else
                {
                    clean();
                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            buttonSubmit.Enabled = false;
            if (blockNum < itemNumber)
                answer = false;
            labelStatistics.Text = puzzle.submit(answer);
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            if (blockNum < itemNumber)
                answer = false;
            puzzle.submit(answer);
        }
    }
}
