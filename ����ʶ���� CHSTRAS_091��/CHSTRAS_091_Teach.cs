using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CHSTRAS_091_BT;

namespace _认识事物_CHSTRAS_091_
{
    public partial class CHSTRAS_091_Teach : CHSTRAS_091_UI.uiCHSTRAS_091_Teach
    {
        int itemNum, itemMax;
        String sqlString;
        CHSTRAS_091_Database database;

        public CHSTRAS_091_Teach()
        {
            InitializeComponent();
        }

        public CHSTRAS_091_Teach(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
            SHF_BT.btSHFUnitPractice shfUnitPratice)
            : base(form, shfUserLogin, shfUnitPratice)
        {
            InitializeComponent();
            initial(shfUnitPratice);
        }

        private void initial(SHF_BT.btSHFUnitPractice shfUnitPratice)
        {
            itemNum = 1;
            int programID = 7;
            sqlString = "SELECT TextInfo, ImageInfo FROM E_SHFPages WHERE ProgramID=" + programID;
            database = new CHSTRAS_091_Database(sqlString);
            itemMax = database.getSize();
            buttonBefore.Enabled = false;
            buttonNext_Click(null,null);
        }

        private void buttonBefore_Click(object sender, EventArgs e)
        {
            itemNum-=2;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            String[] str = database.moveToNextString(2);
            CHSTRAS_091_File file = new CHSTRAS_091_File(str[1]);
            pictureBox1.Image = file.getBitMap();
            label1.Text = str[0];
            str = database.moveToNextString(2);
            file = new CHSTRAS_091_File(str[1]);
            pictureBox2.Image = file.getBitMap();
            label2.Text = str[0];
            itemNum += 2;
            if (itemNum >= itemMax)
            {
                buttonNext.Enabled = false;
            }
        }
    }
}
