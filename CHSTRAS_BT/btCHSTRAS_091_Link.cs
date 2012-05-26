using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;
using System.Collections;
using System.Data;
using CHSTRAS_091_BT.Common;

namespace CHSTRAS_091_BT
{
    class btCHSTRAS_091_Link
    {
        btSHFUserLogin shfUserLogin;
        btSHFUnitPractice shfUnitPratice;
        btCHSTRAS_091_Item item;
        btCHSTRAS_091_Unit unit;
        IDataReader reader;
        String[] texts, images;

        public btCHSTRAS_091_Link(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice)
        {
            this.shfUserLogin = shfUserLogin;
            this.shfUnitPratice = shfUnitPratice;
            btCHSTRAS_091_Base bt = new btCHSTRAS_091_Base();
            int programID = bt.getPagesID(shfUnitPratice);
            btCHSTRAS_091_Database database = new btCHSTRAS_091_Database();
            String where = "ProgramID=" + programID;
            String[] selection = new String[] { "TextInfo", "ImageInfo" };
            reader = database.query("E_SHFPages", selection, where, null);
            unit = new btCHSTRAS_091_Unit(DateTime.Now, database.getSize(), shfUserLogin, shfUnitPratice);
            item = new btCHSTRAS_091_Item(shfUserLogin, shfUnitPratice);
            texts = new String[4];
            images = new String[4];
        }

        public void moveToNext()
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < 4; i++)
            {
                if (reader.Read())
                {
                    texts[i] = reader.GetString(0);
                    images[i] = reader.GetString(1);
                }
                else
                {
                    texts[i] = null;
                    images[i] = null;
                }
            }
        }
    }
}
