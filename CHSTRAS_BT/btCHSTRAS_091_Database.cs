using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SHF_DA;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Database
    {
        daSHFDB database;
        DataSet dataSet;
        IDataReader reader;
        int length;

        public btCHSTRAS_091_Database()
        {
            database = new daSHFDB();
        }

        public IDataReader query(String tableName, String[] selections, String condition, String orderBy)
        {
            length = selections.Length;
            String sql = "SELECT ";
            foreach (String selection in selections)
            {
                sql += selection + ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += " FROM " + tableName;
            if (condition != null)
            {
                sql += " WHERE " + condition;
            }
            if (orderBy != null)
            {
                sql += " ORDER BY " + orderBy;
            }
            dataSet = database.GetDataSet(sql);
            reader = dataSet.CreateDataReader();
            return reader;
        }

        public int getSize()
        {
            int size = dataSet.Tables[0].Rows.Count;
            return size;
        }

        /**
         * 文字与图片信息获取方法。
         * 有查询结果返回String，
         * 无内容返回相同大小的null数组
         * 
        **/
        public String[] moveToNextString()
        {
            String[] result = new String[length];
            if (reader.Read())
            {
                int arraySize = reader.FieldCount;
                for (int i = 0; i < arraySize; i++)
                {
                    result[i] = reader.GetString(i);
                }
            }
            return result;
        }

        public String[] moveToBeforeString(int arraySize)
        {
            String[] str = new String[arraySize];
            DataTableCollection dtc = dataSet.Tables;
            return str;
        }
    }
}
