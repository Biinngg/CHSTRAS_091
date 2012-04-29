using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _认识事物_CHSTRAS_091_
{
    public partial class CHSTRAS_091_Foreword : CHSTRAS_091_UI.uiCHSTRAS_091_Foreword
    {
        public CHSTRAS_091_Foreword(Form form, SHF_BT.btSHFUserLogin shfUserLogin, SHF_BT.btSHFUnitPractice shfUnitPratice)
            : base(form, shfUserLogin, shfUnitPratice)
        {
            String textInfo = this.myPages.GetOne(TerminalID).TextInfo;
            InitializeComponent();
            this.textBox.Text = textInfo;
        }
    }
}
