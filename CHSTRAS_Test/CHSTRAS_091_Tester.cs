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
using CHSTRAS_091_BT;
using CHSTRAS_091_UI;
using _认识事物_CHSTRAS_091_;

namespace CHSTRAS_091_Test
{
    public partial class CHSTRAS_091_Tester : uiSHF_TestBase
    {
        public CHSTRAS_091_Tester()
        {
            InitializeComponent();
        }

        public CHSTRAS_091_Tester(Form callForm)
            : base(callForm)
        {
            InitializeComponent();
        }

        public CHSTRAS_091_Tester(Form callForm, string callConnect)
            : base(callForm, callConnect)
        {
            InitializeComponent();
        }
    }
}
