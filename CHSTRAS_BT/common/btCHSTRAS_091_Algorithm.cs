using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSTRAS_091_BT.Common
{
    class btCHSTRAS_091_Algorithm
    {
        public String[] random(String[] array)
        {
            int size = array.Length;
            String[] result = new String[size];
            Random rd = new Random();
            for(int i=0;i<size;i++)
            {
                result[i] = array[rd.Next(size)];
            }
            return result;
        }
    }
}
