using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
using SHF_DA;
using SHF_UI;

namespace CHSTRAS_091_UI
{
    public partial class uiTyping01_Option : SHF_UI.uiSHF_CourseBase
    {
        public uiTyping01_Option()
        {
            InitializeComponent();
        }

        public uiTyping01_Option(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit)
            : base(callForm, callLog, callUnit)
        {
            InitializeComponent();
        }
    }
}
