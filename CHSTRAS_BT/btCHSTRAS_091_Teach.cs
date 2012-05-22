using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using SHF_BT;
using System.Data;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Teach
    {
        private int itemMax, itemNum;
        private String[] str;
        private DateTime startTime;
        private IDataReader readerPages;
        private btSHFUserLogin shfUserLogin;
        private btCHSTRAS_091_File file;
        private btCHSTRAS_091_Database database;
        private String[] shfStudys = new String[] {
            "ProgramID", "UserID", "CoursePageID",
            "StudyYN", "StudyTimes", "StartDateTime", "StdudyDateTime"};

        public btCHSTRAS_091_Teach(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice)
        {
            this.shfUserLogin = shfUserLogin;
            file = new btCHSTRAS_091_File();
            database = new btCHSTRAS_091_Database();
            btCHSTRAS_091_Base bt = new btCHSTRAS_091_Base();
            String[] columns = new String[] { "ProgramID",
                "PageID", "TextInfo", "ImageInfo" };
            String where = "ProgramID=" + bt.getPagesID(shfUnitPratice);
            readerPages = database.query("E_SHFPages", columns, where, null);
            itemMax = database.getSize();
            itemNum = 1;
            startTime = DateTime.Now;
        }

        public Boolean moveToNext()
        {
            if(readerPages.Read())
                record(readerPages);
            itemNum++;
            if (itemNum >= itemMax)
            {
                return false;
            }
            return true;
        }

        private int getTimes(int coursePageID)
        {
            int studyTimes;
            String where = shfStudys[2] + "=" + coursePageID;
            IDataReader reader = database.query("R_SHFStudys", new String[] {
                "StudyTimes" }, where, "StdudyDateTime DESC");
            if (reader.Read())
            {
                studyTimes = reader.GetInt32(0);
            }
            else
            {
                studyTimes = 0;
            }
            return studyTimes;
        }

        private void record(IDataReader reader)
        {
            Hashtable keyValues = new Hashtable();
            keyValues.Add(shfStudys[0], reader.GetInt32(0));
            keyValues.Add(shfStudys[1], shfUserLogin.UserID);
            keyValues.Add(shfStudys[2], reader.GetInt32(1));
            keyValues.Add(shfStudys[3], true);
            keyValues.Add(shfStudys[4], getTimes(reader.GetInt32(1)) + 1);
            keyValues.Add(shfStudys[5], startTime);
            keyValues.Add(shfStudys[6], DateTime.Now);
            database.insert("R_SHFStudys", keyValues);
        }

        public Image getImage()
        {
            return file.getBitMap(readerPages.GetString(3));
        }

        public String getText()
        {
            return file.getText(readerPages.GetString(2));
        }
    }
}
