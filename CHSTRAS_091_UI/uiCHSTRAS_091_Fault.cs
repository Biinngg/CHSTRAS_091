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
    public partial class uiCHSTRAS_091_Fault : uiCHSTRAS_091_Base
    {
        private btCHSTRAS_091_Fault fault;
        private btCHSTRAS_091_Fault.Correct[] answer;
        private SHF_BT.btSHFUserLogin shfUserLogin;
        private SHF_BT.btSHFUnitPractice shfUnitPractice;
        private RadioButton[] radioButton;
        private int timeMark = 0;
        private int currentItem;

        public uiCHSTRAS_091_Fault(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPractice, int courseType)
            : base(form, shfUserLogin, shfUnitPractice, courseType)
        {
            InitializeComponent();

            this.shfUserLogin = shfUserLogin;
            this.shfUnitPractice = shfUnitPractice;
            pictureBox = new PictureBox[]{pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox5, pictureBox6};
            label = new Label[] { label1, label2, label3, label4, label5, label6 };
            radioButton = new RadioButton[] { radioButton1, radioButton2,
                radioButton3, radioButton4, radioButton5};
            itemNumber = label.Length;
            fault = new btCHSTRAS_091_Fault(shfUserLogin,
                shfUnitPractice, courseType, itemNumber);
            totalNumber = fault.getSize();
            next();
        }

        private void next()
        {
            fault.moveToNext();
            Image[] img = fault.getImages();
            String[] str = fault.getTexts();
            String[] answers = fault.QuestionAnswer.Split(new char[] { ',' });
            for (int i = 0; i < itemNumber; i++)
            {
                pictureBox[i].Image = img[i];
                pictureBox[i].Enabled = false;
                label[i].Text = str[i];
                label[i].Enabled = false;
            }
            foreach (String answer in answers)
            {
                int num = System.Convert.ToInt32(answer);
                pictureBox[num].Enabled = true;
                label[num].Enabled = true;
            }
        }

        private void disCorrect(int num, Image image)
        {
            currentItem = num;
            pictureBox[num].Enabled = false;
            label[num].Enabled = false;
            groupBox2.Visible = true;
            pictureBox7.BackgroundImage = image;
            answer = fault.getAnswers(num);
            for (int i = 0; i < radioButton.Length; i++)
            {
                radioButton[i].Text = answer[i].text;
                radioButton[i].Enabled = true;
                radioButton[i].Checked = false;
            }
        }

        private void animationPlay(Image animation)
        {
            pictureBox7.Image = animation;
            for (int i = 0; i < radioButton.Length; i++)
            {
                radioButton[i].Enabled = false;
            }
            timer1.Enabled = true;
        }

        private void animationStop()
        {
            timeMark = 0;
            if (pictureBox7.Image == fault.happy)
            {
                groupBox2.Visible = false;
            }
            pictureBox7.Image = null;
            for (int i = 0; i < radioButton.Length; i++)
            {
                radioButton[i].Enabled = true;
            }
            timer1.Enabled = false;
        }

        private void correct(int num)
        {
            Image img = null;
            if (answer[num].right)
            {
                img = fault.happy;
                label[currentItem].Text = answer[num].text;
                fault.saveAnswer(answer[num].text);
            }
            else
            {
                img = fault.angry;
            }
            animationPlay(img);
        }

        private void buttonForward_Click_1(object sender, EventArgs e)
        {
            fault.record();
            next();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            disCorrect(0, pictureBox1.Image);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            disCorrect(1, pictureBox2.Image);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            disCorrect(2, pictureBox3.Image);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            disCorrect(3, pictureBox4.Image);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            disCorrect(4, pictureBox5.Image);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            disCorrect(5, pictureBox6.Image);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            disCorrect(0, pictureBox1.Image);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            disCorrect(1, pictureBox2.Image);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            disCorrect(2, pictureBox3.Image);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            disCorrect(3, pictureBox4.Image);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            disCorrect(4, pictureBox5.Image);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            disCorrect(5, pictureBox6.Image);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            correct(0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            correct(1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            correct(2);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            correct(3);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            correct(4);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeMark++;
            if (timeMark > 2)
            {
                animationStop();
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            buttonSubmit.Enabled = false;
            buttonForward.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            labelStatistics.Text = fault.submit();
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            fault.submit();
        }
    }
}
