﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_Teach : uiCHSTRAS_091_Base
    {
        public uiCHSTRAS_091_Teach()
        {
            InitializeComponent();
        }

        public uiCHSTRAS_091_Teach(Form form, SHF_BT.btSHFUserLogin shfUserLogin, SHF_BT.btSHFUnitPractice shfUnitPratice)
            : base(form, shfUserLogin, shfUnitPratice)
        {
            InitializeComponent();
            pictureBox = new PictureBox[] { pictureBox1, pictureBox2 };
            label = new Label[] { label1, label2 };
        }
    }
}
