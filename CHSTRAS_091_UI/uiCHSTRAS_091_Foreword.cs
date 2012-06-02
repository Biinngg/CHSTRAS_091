using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
using CHSTRAS_091_BT;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_Foreword : uiCHSTRAS_091_Base
    {
        private btSHFUnitPractice pratice;

        public uiCHSTRAS_091_Foreword(Form form, btSHFUserLogin shfUserLogin,
            btSHFUnitPractice shfUnitPratice, int courseType)
            : base(form, shfUserLogin, shfUnitPratice, courseType)
        {
            InitializeComponent();
            pratice = shfUnitPratice;
            this.labelStatistics.Text = disForeword();
        }

        public String disForeword()
        {
            String condition = "Tag=\'0\'";
            btCHSTRAS_091_Database database = new btCHSTRAS_091_Database();
            btCHSTRAS_091_File file = new btCHSTRAS_091_File();
            database.query("E_SHFPages", new String[] { "TextInfo" }, condition, null);
            String textInfo = database.moveToNextString()[0];
            return file.getText(textInfo);
        }
    }
}
