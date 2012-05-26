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
        protected int number, answeredNum;
        protected DateTime startTime;
        private btCHSTRAS_091_Time times;

        public uiCHSTRAS_091_Base()
        {
            InitializeComponent();
        }

        public uiCHSTRAS_091_Base(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit)
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
            answeredNum = 2;
            this.labelAnswered.Text += answeredNum;
        }

        protected void buttonExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now - startTime;
            this.labelHave.Text = "已用时间：" + times.getTime(diff); ;
        }

        protected void buttonForward_Click(object sender, EventArgs e)
        {
            answeredNum += 2;
            this.labelAnswered.Text = "已答题数：" + answeredNum;
        }

        protected void buttonBackward_Click(object sender, EventArgs e)
        {
            answeredNum -= 2;
            this.labelAnswered.Text = "已答题数：" + answeredNum;
        }
    }
}
