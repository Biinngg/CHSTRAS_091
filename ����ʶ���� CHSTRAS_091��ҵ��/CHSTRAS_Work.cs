﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using _认识事物_CHSTRAS_091_;
using CHSTRAS_UI;
using CHSTRAS_BT;
using CHSTRAS_Test;

namespace _认识事物_CHSTRAS_091作业_
{
    public partial class CHSTRAS_Work : uiCHSTRAS_WorkMain
    {
        public CHSTRAS_Work()
        {
            InitializeComponent();
        }

        private void button应用程序_Click(object sender, EventArgs e)
        {
            CHSTRAS_091 f = new CHSTRAS_091();
            f.Show();
        }

        private void button原版实验_Click(object sender, EventArgs e)
        {
            CHSTRAS_TestV091 f = new CHSTRAS_TestV091();
            f.Show();
        }

        private void button实验程序_Click(object sender, EventArgs e)
        {
            CHSTRAS_TestV091 f = new CHSTRAS_TestV091();
            f.Show();
        }
    }
}
