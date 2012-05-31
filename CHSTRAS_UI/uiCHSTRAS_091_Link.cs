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
    public partial class uiCHSTRAS_091_Link : uiCHSTRAS_091_Base
    {
        private btCHSTRAS_091_Link bt;

        public uiCHSTRAS_091_Link(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPratice, int courseType)
            : base(form, shfUserLogin, shfUnitPratice, courseType)
        {
            InitializeComponent();

            pictureBox = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            label = new Label[] { label1, label2, label3, label4 };
            number = label.Length;
            bt = new btCHSTRAS_091_Link(shfUserLogin, shfUnitPratice);
            next();
        }

        public void buttonForward_Click(object sender, EventArgs e)
        {
            next();
        }

        private void next()
        {
            bt.moveToNext();
            Image[] pictures = bt.getImages();
            String[] texts = bt.getTexts();
            for (int i = 0; i < number; i++)
            {
                pictureBox[i].Image = pictures[i];
                label[i].Text = texts[i];
            }
        }
    }
}
