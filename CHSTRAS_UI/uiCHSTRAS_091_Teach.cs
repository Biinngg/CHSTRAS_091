using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CHSTRAS_091_BT;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_Teach : uiCHSTRAS_091_Base
    {
        private btCHSTRAS_091_Teach bt;
        private int totalNum;

        public uiCHSTRAS_091_Teach(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPratice, int courseType)
            : base(form, shfUserLogin, shfUnitPratice, courseType)
        {
            InitializeComponent();

            pictureBox = new PictureBox[] { pictureBox1, pictureBox2 };
            label = new Label[] { label1, label2 };
            number = label.Length;
            bt = new btCHSTRAS_091_Teach(shfUserLogin, shfUnitPratice);
            buttonBackward.Enabled = false;
            totalNum = bt.getTotal();
            this.labelTotal.Text += totalNum;
            next();
        }

        protected void buttonForward_Click(object sender, EventArgs e)
        {
            buttonBackward.Enabled = true;
            next();
            int progress = answeredNum * 100 / totalNum;
            this.progressBar1.Value = progress;
            Console.Write("value:" + progress + "\n answeredNum=" + answeredNum + " totalNum="+ totalNum);
        }

        protected void buttonBackward_Click(object sender, EventArgs e)
        {
            buttonForward.Enabled = true;
            for (int i = number - 1; i >= 0; i--)
            {
                Boolean result = bt.moveToLast();
                pictureBox[i].Image = bt.getImage();
                label[i].Text = bt.getText();
                if (!result)
                {
                    buttonBackward.Enabled = false;
                }
            }
            int progress = answeredNum * 100 / totalNum;
            this.progressBar1.Value = progress;
        }

        private void next()
        {
            for (int i = 0; i < number; i++)
            {
                Boolean result = bt.moveToNext();
                pictureBox[i].Image = bt.getImage();
                label[i].Text = bt.getText();
                if (!result)
                {
                    buttonForward.Enabled = false;
                }
            }
        }
    }
}
