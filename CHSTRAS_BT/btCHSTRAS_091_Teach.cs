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
        private int total, itemLearned, itemCurrent;
        private btSHFPage page;
        private DateTime startTime;
        private IDataReader readerPages, readerStudys, readerNext, readerBack;
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
            String[] columns = new String[] { "ProgramID", "PageID" };
            String where = "ProgramID=" + bt.getPagesID(shfUnitPratice);
            readerPages = database.query("E_SHFPages", columns, where, null);
            total = database.getSize();
            itemLearned = 1;
            itemCurrent = 1;
            startTime = DateTime.Now;
        }

        public bool moveToNext()
        {
            itemCurrent++;
            if (itemCurrent < itemLearned)
            {
                unrecord(itemCurrent, "ASC");
            }
            else
            {
                itemLearned++;
                if (readerPages.Read())
                    record(readerPages.GetInt32(0), readerPages.GetInt32(1), true);
            }
            if (itemLearned >= total)
                return false;
            return true;
        }

        public bool moveToLast()
        {
            if (itemCurrent == itemLearned)
            {
                itemCurrent -= 3;
            }
            else
            {
                itemCurrent--;
            }
            unrecord(itemLearned - itemCurrent, "DESC");
            if (itemCurrent <= 0)
            {
                return false;
            }
            return true;
        }

        private bool unrecord(int num, String order)
        {
            IDataReader reader = getReader(order);
            for (int i = 0; i < num; i++)
            {
                if (!reader.Read())
                    return false;
            }
            int id = reader.GetInt32(0);
            btSHFPages pages = new btSHFPages();
            btSHFPage page = pages.GetOne(id);
            record(page.ProgramID, page.PageID, false);
            return true;
        }

        private IDataReader getReader(String order)
        {
            String where = shfStudys[5] + "=#" + startTime +
                "# AND " + shfStudys[3] + "=true";
            IDataReader reader = database.query("R_SHFStudys",
                new String[] { shfStudys[2] }, where, "StudyID " + order);
            return reader;
        }

        private int getTimes(int coursePageID)
        {
            int studyTimes;
            String where = shfStudys[2] + "=" + coursePageID;
            IDataReader reader = database.query("R_SHFStudys", new String[] {
                shfStudys[4] }, where, "StudyID DESC");
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

        private void record(int ProgramID, int CoursePageID, bool StudyYN)
        {
            Hashtable keyValues = new Hashtable();
            keyValues.Add(shfStudys[0], ProgramID);
            keyValues.Add(shfStudys[1], shfUserLogin.UserID);
            keyValues.Add(shfStudys[2], CoursePageID);
            keyValues.Add(shfStudys[3], StudyYN);
            keyValues.Add(shfStudys[4], getTimes(CoursePageID) + 1);
            keyValues.Add(shfStudys[5], startTime);
            keyValues.Add(shfStudys[6], DateTime.Now);
            database.insert("R_SHFStudys", keyValues);
            readerStudys = getReader("DESC");
            getPages();
        }

        private void getPages()
        {
            String where = shfStudys[5] + "=#" + startTime + "#";
            IDataReader reader = database.query("R_SHFStudys",
                new String[] { shfStudys[2] }, where, "StudyID DESC");
            reader.Read();
            int pageID = reader.GetInt32(0);
            btSHFPages pages = new btSHFPages();
            page = pages.GetOne(pageID);
        }

        public Image getImage()
        {
            return file.getBitMap(page.ImageInfo);
        }

        public String getText()
        {
            return file.getText(page.TextInfo);
        }
    }
}
