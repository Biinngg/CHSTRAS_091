using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CHSTRAS_091_BT;
using System.Collections;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_Link : uiCHSTRAS_091_Base
    {
        private btCHSTRAS_091_Link bt;
        private btCHSTRAS_091_Link_Status status;
        private btCHSTRAS_091_File file;
        private Point[] point1, point2;
        private bool clickMark = false;

        public uiCHSTRAS_091_Link(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPratice, int courseType)
            : base(form, shfUserLogin, shfUnitPratice, courseType)
        {
            InitializeComponent();

            pictureBox = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            label = new Label[] { label1, label2, label3, label4 };
            itemNumber = label.Length;
            bt = new btCHSTRAS_091_Link(shfUserLogin, shfUnitPratice, courseType, itemNumber);
            totalNumber = bt.getSize();
            status = new btCHSTRAS_091_Link_Status(itemNumber);
            file = new btCHSTRAS_091_File();
            answeredNumber--;//由于点击两次下一个按钮才会到下一题，会多记一次。
            getPoint();
            next();
        }

        private void getPoint()
        {
            point1 = new Point[itemNumber];
            point2 = new Point[itemNumber];
            for (int i = 0; i < itemNumber; i++)
            {
                Point location = pictureBox[i].Location;
                int width = pictureBox[i].Width;
                point1[i] = new Point(location.X + width / 2, location.Y + pictureBox[i].Height);
                location = label[i].Location;
                width = label[i].Width;
                point2[i] = new Point(location.X + width / 2, location.Y);
            }
        }

        private void record()
        {
            clickDisable();
            ArrayList answer = bt.record(status.links);
            for (int i = 0; i < itemNumber; i++)
            {
                int n = status.links.IndexOf(i);
                if (n > -1)
                {
                    label[i].Image = file.getImage(answer[n].ToString() + ".png");
                }
                else
                {
                    label[i].Image = file.getImage("false.png");
                }
            }
            if (answer.Contains(false))
            {
                buttonAnswer.Visible = true;
            }
        }

        private void clean()
        {
            status.clean();
            for (int i = 0; i < itemNumber; i++)
            {
                label[i].Image = null;
            }
        }

        private void clickEnable()
        {
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBox[i].Enabled = true;
                label[i].Enabled = true;
            }
        }
        private void clickDisable()
        {
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBox[i].Enabled = false;
                label[i].Enabled = false;
            }
        }

        private void next()
        {
            clean();
            updateLinks();
            buttonAnswer.Visible = false;
            clickEnable();
            bt.moveToNext();
            status.unset();
            Image[] pictures = bt.getImages();
            String[] texts = bt.getTexts();
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBox[i].Image = pictures[i];
                label[i].Text = texts[i];
            }
        }

        private void updateLinks()
        {
            Graphics g = groupBox1.CreateGraphics();
            g.Clear(Color.White);
            status.setLinks();
            for (int i = 0; i < itemNumber; i++)
            {
                int value = (int)status.links[i];
                if (value > -1)
                {
                    g.DrawLine(new Pen(Color.Orange, 2), point1[i], point2[value]);
                }
            }
        }

        private void clickPicture(int num)
        {
            status.setImages(num);
            for (int i = 0; i < itemNumber; i++)
            {
                this.pictureBox[i].BackColor = Color.Transparent;
            }
            int selected = status.getImages();
            if (selected > -1)
            {
                this.pictureBox[selected].BackColor = Color.Orange;
            }
            updateLinks();
        }

        private void clickLabel(int num)
        {
            status.setLabels(num);
            for (int i = 0; i < itemNumber; i++)
            {
                this.label[i].BackColor = Color.Transparent;
            }
            int selected = status.getLabels();
            if (selected > -1)
            {
                this.label[selected].BackColor = Color.Orange;
            }
            updateLinks();
        }

        public void buttonForward_Click(object sender, EventArgs e)
        {
            if (clickMark)
            {
                next();
                clickMark = false;
            }
            else
            {
                answeredNumber--;//由于点击两次下一个按钮才会到下一题，会多记一次。
                record();
                clickMark = true;
            }
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            clean();
            status.links = bt.getAnswers();
            updateLinks();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            this.buttonSubmit.Enabled = false;
            this.groupBox1.Visible = false;
            this.labelStatistics.Text = bt.submit();
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
