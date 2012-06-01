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

        private void button前言_Click(object sender, EventArgs e)
        {
            try
            {
                uiCHSTRAS_091_Foreword f = new uiCHSTRAS_091_Foreword(this, shfUserLogin, shfUnitPractice, courseType);
                f.Show();
            }
            catch (Exception exception)// Exception ex
            {
                MessageBox.Show("Exception:" + exception.ToString());
            }
        }

        private void button认识植物_Click(object sender, EventArgs e)
        {
            try
            {
                uiCHSTRAS_091_Teach f = new uiCHSTRAS_091_Teach(this, shfUserLogin, shfUnitPractice, courseType);
                f.Show();
            }
            catch (Exception exception)// Exception ex
            {
                MessageBox.Show("Exception:" + exception.ToString());
            }
        }

        private void button连结游戏_Click(object sender, EventArgs e)
        {
            try
            {
                uiCHSTRAS_091_Link f = new uiCHSTRAS_091_Link(this, shfUserLogin, shfUnitPractice, courseType);
                f.Show();
            }
            catch (Exception exception)// Exception ex
            {
                MessageBox.Show("Exception:" + exception.ToString());
            }
        }
    }
}
