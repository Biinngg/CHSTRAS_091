using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHF_DA;

namespace CHSTRAS_091_BT
{
    public class CHSTRAS_091_Database
    {
        daSHFDB database;
        DataSet dataSet;
        IDataReader reader;

        public CHSTRAS_091_Database(String sqlString)
        {
            database = new daSHFDB();
            dataSet = database.GetDataSet(sqlString);
            reader = dataSet.CreateDataReader();
        }

        public int getSize()
        {
            int size = dataSet.Tables[0].Rows.Count;
            return size;
        }

        public String[] moveToNextString(int arraySize)
        {
            String[] str = new String[arraySize];
            reader.Read();
            for (int i = 0; i < arraySize; i++)
            {
                str[i] = reader.GetString(i);
            }
            return str;
        }

        public String[] moveToBeforeString(int arraySize)
        {
            String[] str = new String[arraySize];
            DataTableCollection dtc = dataSet.Tables;
            return str;
        }
    }
}
