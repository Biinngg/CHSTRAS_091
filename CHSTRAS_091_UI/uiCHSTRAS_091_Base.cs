using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SHF_BT;
using CHSTRAS_091_BT;
using CHSTRAS_091_BT.Common;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_Base : SHF_UI.uiSHF_CourseBase
    {
        protected PictureBox[] pictureBox;
        protected Label[] label;
        protected int itemNumber, answeredNumber, totalNumber;
        protected DateTime startTime;
        private btCHSTRAS_091_Time times;

        public uiCHSTRAS_091_Base()
        {
            InitializeComponent();
        }

        public uiCHSTRAS_091_Base(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit, int courseType)
            : base(callForm, callLog, callUnit)
        {
            InitializeComponent();
            times = new btCHSTRAS_091_Time();
            btCHSTRAS_091_Base bt = new btCHSTRAS_091_Base();
            String title = callUnit.UnitPracticeName;
            this.Text = title;
            this.labelPageTitle.Text = title;
            this.label课程信息.Text = bt.getClassInfo(callUnit);
            this.label程序信息.Text = bt.getProgramInfo(callUnit);
            startTime = DateTime.Now;
            this.labelBegin.Text += times.getTime(startTime);
            answeredNumber = 1;
            this.labelAnswered.Text += answeredNumber;
            this.timer1.Enabled = true;
            this.buttonBackward.Enabled = false;
        }

        protected void buttonExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        protected void buttonForward_Click(object sender, EventArgs e)
        {
            answeredNumber ++;
            this.labelAnswered.Text = "已答题数：" + answeredNumber;
            int progress = answeredNumber * 100 / totalNumber;
            this.progressBar1.Value = progress;
            if (answeredNumber == totalNumber)
            {
                buttonForward.Enabled = false;
            }
            buttonBackward.Enabled = true;
        }

        protected void buttonBackward_Click(object sender, EventArgs e)
        {
            answeredNumber --;
            this.labelAnswered.Text = "已答题数：" + answeredNumber;
            int progress = answeredNumber * 100 / totalNumber;
            this.progressBar1.Value = progress;
            if (answeredNumber == 1)
            {
                buttonBackward.Enabled = false;
            }
            buttonForward.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now - startTime;
            this.labelHave.Text = "已用时间：" + times.getTime(diff);
            //totalNumber在子类中更新，父类初始化时并不知道其数值。
            this.labelTotal.Text ="总题数：" + totalNumber;
        }
    }
}
