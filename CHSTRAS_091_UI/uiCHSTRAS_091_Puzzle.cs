using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_Puzzle : uiCHSTRAS_091_Base
    {
        private PictureBox[] pictureBoxL, pictureBoxR;

        public uiCHSTRAS_091_Puzzle(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPratice, int courseType)
            : base(form, shfUserLogin, shfUnitPratice, courseType)
        {
            InitializeComponent();
        }
    }
}
