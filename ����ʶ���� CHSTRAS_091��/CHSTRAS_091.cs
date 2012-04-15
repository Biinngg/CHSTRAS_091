using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CHSTRAS_091_UI;
using SHF_UI;

namespace _认识事物_CHSTRAS_091_
{
    public partial class CHSTRAS_091 : uiCHSTRAS_091_AppMain
    {
        public CHSTRAS_091()
        {
            InitializeComponent();
        }

        private void button认识植物_Click(object sender, EventArgs e)
        {
            uiCHSTRAS_091_CourseShow f = new uiCHSTRAS_091_CourseShow();
            f.Show();
        }
    }
}
