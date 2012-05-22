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

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_Base : SHF_UI.uiSHF_CourseBase
    {
        protected PictureBox[] pictureBox;
        protected Label[] label;
        protected int number;

        public uiCHSTRAS_091_Base()
        {
            InitializeComponent();
        }

        public uiCHSTRAS_091_Base(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit)
            : base(callForm, callLog, callUnit)
        {
            InitializeComponent();
            btCHSTRAS_091_Base bt = new btCHSTRAS_091_Base();
            String title = callUnit.UnitPracticeName;
            this.Text = title;
            this.labelPageTitle.Text = title;
            this.label课程信息.Text = bt.getClassInfo(callUnit);
            this.label程序信息.Text = bt.getProgramInfo(callUnit);
        }
    }
}
