using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using _认识事物_CHSTRAS_091_;
using CHSTRAS_091_BT;
using CHSTRAS_091_UI;

namespace CHSTRAS_091_Test
{
    public partial class CHSTRAS_091_TestV091 : SHF_UI.uiSHF_TestBase
    {
        public CHSTRAS_091_TestV091()
        {
            InitializeComponent();
        }

        public CHSTRAS_091_TestV091(Form callForm)
            : base(callForm)
        {
            InitializeComponent();
        }

        public CHSTRAS_091_TestV091(Form callForm, string callConnect)
            : base(callForm, callConnect)
        {
            InitializeComponent();
        }
    }
}
