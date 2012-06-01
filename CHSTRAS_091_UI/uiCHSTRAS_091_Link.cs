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
        private btCHSTRAS_091_Link_Status status;

        public uiCHSTRAS_091_Link(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPratice, int courseType)
            : base(form, shfUserLogin, shfUnitPratice, courseType)
        {
            InitializeComponent();

            pictureBox = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            label = new Label[] { label1, label2, label3, label4 };
            number = label.Length;
            bt = new btCHSTRAS_091_Link(shfUserLogin, shfUnitPratice, courseType, number);
            status = new btCHSTRAS_091_Link_Status(number);
            next();
        }

        public void buttonForward_Click(object sender, EventArgs e)
        {
            next();
        }

        private void next()
        {
            bt.moveToNext();
            status.unset();
            Image[] pictures = bt.getImages();
            String[] texts = bt.getTexts();
            for (int i = 0; i < number; i++)
            {
                pictureBox[i].Image = pictures[i];
                label[i].Text = texts[i];
            }
        }

        private void clickPicture(int num)
        {
            status.setImages(num);
            for (int i = 0; i < number; i++)
            {
                this.pictureBox[i].BackColor = Color.Transparent;
            }
            int selected = status.getImages();
            if (selected > -1)
            {
                this.pictureBox[selected].BackColor = Color.Orange;
            }
        }

        private void clickLabel(int num)
        {
            status.setLabels(num);
            for (int i = 0; i < number; i++)
            {
                this.label[i].BackColor = Color.Transparent;
            }
            int selected = status.getLabels();
            if (selected > -1)
            {
                this.label[selected].BackColor = Color.Orange;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clickPicture(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            clickPicture(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            clickPicture(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            clickPicture(3);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            clickLabel(0);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            clickLabel(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            clickLabel(2);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            clickLabel(3);
        }
    }
}
