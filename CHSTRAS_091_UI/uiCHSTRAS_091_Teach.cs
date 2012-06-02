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

        public uiCHSTRAS_091_Teach(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPratice, int courseType)
            : base(form, shfUserLogin, shfUnitPratice, courseType)
        {
            InitializeComponent();

            pictureBox = new PictureBox[] { pictureBox1, pictureBox2 };
            label = new Label[] { label1, label2 };
            itemNumber = label.Length;
            bt = new btCHSTRAS_091_Teach(shfUserLogin, shfUnitPratice, courseType);
            totalNumber = bt.getTotal();
            next();
        }

        protected void buttonForward_Click(object sender, EventArgs e)
        {
            next();
        }

        protected void buttonBackward_Click(object sender, EventArgs e)
        {
            for (int i = itemNumber - 1; i >= 0; i--)
            {
                Boolean result = bt.moveToLast();
                pictureBox[i].Image = bt.getImage();
                label[i].Text = bt.getText();
            }
        }

        private void next()
        {
            for (int i = 0; i < itemNumber; i++)
            {
                Boolean result = bt.moveToNext();
                pictureBox[i].Image = bt.getImage();
                label[i].Text = bt.getText();
            }
        }
    }
}
