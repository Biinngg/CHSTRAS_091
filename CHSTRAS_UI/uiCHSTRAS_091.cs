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
    public partial class uiCHSTRAS_091 : SHF_UI.uiSHF_CourseBase
    {
        public uiCHSTRAS_091()
        {
            InitializeComponent();
        }

        public uiCHSTRAS_091(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit)
            : base(callForm, callLog, callUnit)
        {
            InitializeComponent();
            CHSTRAS_091 bt = new CHSTRAS_091();
            this.labelPageTitle.Text = callUnit.UnitPracticeName;
            this.label课程信息.Text = bt.getClassInfo(callUnit);
            this.label程序信息.Text = bt.getProgramInfo(callUnit);
        }
    }
}
