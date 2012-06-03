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
    public partial class uiCHSTRAS_091_Memory : uiCHSTRAS_091_Base
    {
        private int timeMark;
        private btCHSTRAS_091_Memory memory;

        public uiCHSTRAS_091_Memory(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPratice, int courseType)
            : base(form, shfUserLogin, shfUnitPratice, courseType)
        {
            InitializeComponent();

            pictureBox = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4};
            itemNumber = pictureBox.Length;
            memory = new btCHSTRAS_091_Memory(shfUserLogin, shfUnitPratice, courseType, itemNumber);
            totalNumber = memory.getSize();
            next();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeMark >= 0)
            {
                int number1 = timeMark % itemNumber;
                int number2 = (timeMark + itemNumber - 1) % itemNumber;
                if (timeMark < itemNumber * 2)
                {
                    pictureBox[number1].Image = memory.open;
                    pictureBox[number2].Image = memory.close;
                }
                else if (timeMark == itemNumber * 2)
                {
                    pictureBox[number2].Image = memory.close;
                    pictureBox5.Image = memory.open;
                    enabled(true);
                    timeMark = -2;//之后会++
                }
                timeMark++;
            }
        }

        private void next()
        {
            clean();
            timeMark = 0;
            memory.moveToNext();
            Image[] images = memory.getImages();
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBox[i].BackgroundImage = images[i];
            }
            pictureBox5.BackgroundImage = memory.getQuestion();
        }

        private void clean()
        {
            timeMark = -1;
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBox[i].Image = memory.close;
            }
            pictureBox5.Image = memory.close;
            pictureBox6.Image = null;
            pictureBox6.BackgroundImage = memory.close;
            enabled(false);
        }

        private void enabled(bool b)
        {
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBox[i].Enabled = b;
            }
        }

        private void click(int num)
        {
            enabled(false);
            pictureBox[num - 1].Image = memory.open;
            disAnswer(num - 1);
        }

        private void disAnswer(int num)
        {
            int answer = memory.getAnswer();
            bool result = (num == answer);
            pictureBox6.BackgroundImage = memory.open;
            if (result)
            {
                pictureBox6.Image = memory.happy;
            }
            else
            {
                pictureBox[answer].Image = memory.open;
                pictureBox6.Image = memory.angry;
            }
            memory.record(num, result);
        }

        private void buttonForward_Click_1(object sender, EventArgs e)
        {
            next();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            click(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            click(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            click(3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            click(4);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            buttonSubmit.Enabled = false;
            buttonForward.Enabled = false;
            labelStatistics.Visible = true;
            labelStatistics.Text = memory.submit();
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            memory.submit();
        }
    }
}
