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
    public partial class CHSTRAS_091_Link : CHSTRAS_091_UI.uiCHSTRAS_091_Link
    {
        int itemNum, itemMax;
        btCHSTRAS_091_Database database;

        public CHSTRAS_091_Link()
        {
            InitializeComponent();
        }

        public CHSTRAS_091_Link(Form form, SHF_BT.btSHFUserLogin shfUserLogin,
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
            String sqlString = "ProgramID=" + programID;
            database = new btCHSTRAS_091_Database();
            database.query("E_SHFPages", new String[] { "TextInfo", "ImageInfo" }, sqlString, null);
            itemMax = database.getSize();
            buttonBefore.Enabled = false;
            buttonNext_Click(null,null);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            PictureBox[] pictureBox = new PictureBox[] { pictureBox1,
                pictureBox2, pictureBox3, pictureBox4 };
            Label[] label = new Label[]{label1, label2, label3, label4};
            int size = label.Length;
            for (int i = 0; i < size; i++)
            {
                String[] str = database.moveToNextString();
                btCHSTRAS_091_File file = new btCHSTRAS_091_File();
                pictureBox[i].Image = file.getBitMap(str[1]);
                label[i].Text = file.getText(str[0]);
            }
            itemNum += size;
            if (itemNum >= itemMax)
            {
                buttonNext.Enabled = false;
            }
        }

        private void buttonBefore_Click(object sender, EventArgs e)
        {
            itemNum -= 2;
        }
    }
}
