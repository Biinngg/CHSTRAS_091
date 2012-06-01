using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using SHF_BT;
using System.Data;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Teach
    {
        private int total, itemLearned, itemCurrent;
        private bool moveToLastPressed = false;
        private btSHFPage page;
        private ArrayList arrayList;
        private DateTime startTime;
        private IDataReader readerPages;
        private btSHFUserLogin shfUserLogin;
        private btCHSTRAS_091_File file;
        private btCHSTRAS_091_Database database;
        private String[] shfStudys = new String[] {
            "ProgramID", "UserID", "CoursePageID",
            "StudyYN", "StudyTimes", "StartDateTime", "StdudyDateTime"};

        public btCHSTRAS_091_Teach(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice, int courseType)
        {
            this.shfUserLogin = shfUserLogin;
            file = new btCHSTRAS_091_File();
            database = new btCHSTRAS_091_Database();
            btCHSTRAS_091_Base bt = new btCHSTRAS_091_Base();
            String[] columns = new String[] { "ProgramID", "PageID" };
            String where = "PageNumber=\'" + bt.getPagesID(shfUnitPratice) +
                "\' AND Tag=\'" + courseType + "\'";
            readerPages = database.query("E_SHFPages", columns, where, null);
            total = database.getSize();
            itemLearned = -1;
            itemCurrent = -1;
            arrayList = new ArrayList();
            startTime = DateTime.Now;
        }

        public bool moveToNext()
        {
            if (moveToLastPressed)
            {
                itemCurrent += 2;
                moveToLastPressed = false;
            }
            else
            {
                itemCurrent++;
            }
            if (itemCurrent <= itemLearned)
            {
                unrecord(itemCurrent);
            }
            else
            {
                itemLearned++;
                if (readerPages.Read())
                    record(readerPages.GetInt32(0), readerPages.GetInt32(1), true);
            }
            if (itemCurrent >= total - 1)
                return false;
            return true;
        }

        public bool moveToLast()
        {
            if (!moveToLastPressed)
            {
                itemCurrent -= 2;
                moveToLastPressed = true;
            }
            else
            {
                itemCurrent--;
            }
            unrecord(itemCurrent);
            if (itemCurrent <= 0)
            {
                return false;
            }
            return true;
        }

        private void unrecord(int num)
        {
            int id = (int)arrayList[num];
            btSHFPages pages = new btSHFPages();
            btSHFPage page = pages.GetOne(id);
            record(page.ProgramID, page.PageID, false);
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
            arrayList.Add(CoursePageID);
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
            String name = null;
            if (page != null)
                name = page.ImageInfo;
            return file.getImage(name);
        }

        public String getText()
        {
            String name = null;
            if (page != null)
                name = page.TextInfo;
            return file.getText(name);
        }

        public int getTotal()
        {
            return total/2;
        }
    }
}
