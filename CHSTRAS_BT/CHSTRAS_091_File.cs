using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CHSTRAS_091_BT
{
    public class CHSTRAS_091_File
    {
        String filePath;

        public CHSTRAS_091_File(String filePath)
        {
            this.filePath = "..\\..\\..\\SHFDB\\Image\\";
            this.filePath += filePath;
        }

        public Image getBitMap()
        {
            Bitmap bitmap = new Bitmap(filePath);
            return bitmap;
        }
    }
}
