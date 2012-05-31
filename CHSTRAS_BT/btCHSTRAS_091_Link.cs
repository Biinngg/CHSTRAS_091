using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
using System.Collections;
using System.Data;
using CHSTRAS_091_BT.Common;
using System.Drawing;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Link
    {
        private btSHFUserLogin shfUserLogin;
        private btSHFUnitPractice shfUnitPratice;
        private btCHSTRAS_091_Item item;
        private btCHSTRAS_091_Unit unit;
        private btCHSTRAS_091_File file;
        private IDataReader reader;
        private String[] textNames, imageNames;
        private static int size = 4;

        public btCHSTRAS_091_Link(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice)
        {
            this.shfUserLogin = shfUserLogin;
            this.shfUnitPratice = shfUnitPratice;
            btCHSTRAS_091_Base bt = new btCHSTRAS_091_Base();
            file = new btCHSTRAS_091_File();
            int programID = bt.getPagesID(shfUnitPratice);
            btCHSTRAS_091_Database database = new btCHSTRAS_091_Database();
            String where = "ProgramID=" + programID;
            String[] selection = new String[] { "TextInfo", "ImageInfo" };
            reader = database.query("E_SHFPages", selection, where, null);
            unit = new btCHSTRAS_091_Unit(DateTime.Now, database.getSize(), shfUserLogin, shfUnitPratice);
            item = new btCHSTRAS_091_Item(shfUserLogin, shfUnitPratice);
            textNames = new String[size];
            imageNames = new String[size];
            Console.Write("Initialized.");
            MessageBox.Show("Initialized.");
        }

        public void moveToNext()
        {
            MessageBox.Show("Arrived here.");
            Console.Write("Arrived here.");
            DateTime now = DateTime.Now;
            for (int i = 0; i < size; i++)
            {
                if (reader.Read())
                {
                    textNames[i] = reader.GetString(0);
                    imageNames[i] = reader.GetString(1);
                    Console.Write("textNames" + textNames[i] + "\n");
                    Console.Write(imageNames[i] + "\n");
                }
                else
                {
                    textNames[i] = null;
                    imageNames[i] = null;
                }
            }
        }

        public Image[] getImages()
        {
            Image[] images = new Image[imageNames.Length];
            for (int i = 0; i < size; i++)
            {
                images[i] = file.getImage(imageNames[i]);
            }
            return images;
        }

        public String[] getTexts()
        {
            String[] texts = new String[textNames.Length];
            for (int i = 0; i < size; i++)
            {
                texts[i] = file.getText(textNames[i]);
            }
            btCHSTRAS_091_Algorithm alg = new btCHSTRAS_091_Algorithm();
            texts = (String[])alg.random(texts);
            return texts;
        }
    }
}
