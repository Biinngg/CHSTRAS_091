using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_Link : uiCHSTRAS_091
    {
        public uiCHSTRAS_091_Link()
        {
            InitializeComponent();
        }

        public uiCHSTRAS_091_Link(Form form, SHF_BT.btSHFUserLogin shfUserLogin, SHF_BT.btSHFUnitPractice shfUnitPratice)
            : base(form, shfUserLogin, shfUnitPratice)
        {
            InitializeComponent();
        }
    }
}
