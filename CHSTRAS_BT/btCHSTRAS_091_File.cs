using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_File
    {
        public String getText(String text)
        {
            if (text == null)
            {
                text = "没有了";
                return text;
            }
            if (text.Contains(".txt"))
            {
                String filePath = "..\\..\\..\\SHFDB\\Text\\" + text;
                String result = "";
                StreamReader myStream = new StreamReader(filePath,
                    System.Text.Encoding.GetEncoding("gb2312"));
                string stringLine = myStream.ReadLine();
                while (stringLine != null)
                {
                    result += stringLine + "\r\t";
                    stringLine = myStream.ReadLine();
                }
                myStream.Close();
                text = result;
            }
            return text;
        }

        public Image getBitMap(String fileName)
        {
            Bitmap bitmap;
            String filePath = "..\\..\\..\\SHFDB\\Image\\";
            if (fileName != null)
            {
                filePath += fileName;
            }
            else
            {
                filePath += "none.BMP";
            }
            bitmap = new Bitmap(filePath);
            return bitmap;
        }
    }
}
