using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CHSTRAS_091_BT;
using SHF_BT;

namespace _认识事物_CHSTRAS_091_
{
    public partial class CHSTRAS_091_Teach : CHSTRAS_091_UI.uiCHSTRAS_091_Teach
    {
        int itemNum, itemMax, size;
        btCHSTRAS_091_Database database;

        public CHSTRAS_091_Teach(Form form, btSHFUserLogin shfUserLogin,
            btSHFUnitPractice shfUnitPratice)
            : base(form, shfUserLogin, shfUnitPratice)
        {
            InitializeComponent();
            size = label.Length;
            initial(shfUnitPratice);
        }

        private void initial(btSHFUnitPractice shfUnitPratice)
        {
            itemNum = 1;
            btCHSTRAS_091_Base bt = new btCHSTRAS_091_Base();
            String sqlString = "ProgramID=" + bt.getPagesID(shfUnitPratice);
            database = new btCHSTRAS_091_Database();
            database.query("E_SHFPages", new String[] { "TextInfo", "ImageInfo" }, sqlString, null);
            itemMax = database.getSize();
            buttonBackward.Enabled = false;
            buttonForward_Click(null, null);
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
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
                buttonForward.Enabled = false;
            }
        }

        private void buttonBackward_Click(object sender, EventArgs e)
        {

        }
    }
}
