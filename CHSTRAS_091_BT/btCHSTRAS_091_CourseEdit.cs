using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_CourseEdit
    {
        private btCHSTRAS_091_Database db;
        private int[] fatherID;
        private int typeIndex = -1;
        public class Content
        {
            public String title;
            public int score = 0;
            public String[] image, disName, corName, optName;
            public bool[] mark;
        }
        private Content[] ct;

        public btCHSTRAS_091_CourseEdit()
        {
            db = new btCHSTRAS_091_Database();
            fatherID = new int[5]{0,0,0,0,0};
        }

        public int getID(int level, int fatherIndex)
        {
            String[] selections = new String[] { "StructureID" };
            String condition = "FatherID=" + fatherID[level] +
                " AND SubOrder=" + fatherIndex;
            IDataReader reader = db.query("E_SHFStructures", selections,
                condition, null);
            reader.Read();
            return reader.GetInt32(0);
        }

        public String[] getComboItems(int level, int fatherIndex)
        {
            if (fatherIndex < 0)
                return null;
            fatherID[level] = getID(level-1, fatherIndex);
            String[] selections = new String[] { "StructureName" };
            String condition = "FatherID=" + fatherID[level];
            IDataReader reader = db.query("E_SHFStructures", selections,
                condition, null);
            String[] result = new String[db.getSize()];
            int i = 0;
            while(reader.Read())
            {
                result[i++] = reader.GetString(0);
            }
            return result;
        }

        public void setType(int typeIndex)
        {
            this.typeIndex = typeIndex + 1;
        }

        private Content[] getPages(int structureID)
        {
            if (typeIndex > -1)
            {
                String[] selections = new String[] { "PageCode", "TextInfo",
                    "ImageInfo" };
                String condition = "PageNumber=\'" + structureID +
                    "\' AND Tag=\'" + typeIndex + "\'";
                IDataReader reader = db.query("E_SHFPages", selections,
                    condition, null);
                ct = new Content[db.getSize()/2];
                int i = 0;
                while (reader.Read())
                {
                    ct[i] = new Content();
                    ct[i].disName = new String[2];
                    ct[i].image = new String[2];
                    if (!reader.IsDBNull(0))
                    {
                        ct[i].title = reader.GetString(0);
                        if (ct[i].title == "")
                            ct[i].title = "第" + (i + 1) + "题";
                    }
                    else
                        ct[i].title = "第" + (i + 1) + "题";
                    ct[i].disName[0] = reader.GetString(1);
                    ct[i].image[0] = reader.GetString(2);
                    reader.Read();
                    ct[i].disName[1] = reader.GetString(1);
                    ct[i].image[1] = reader.GetString(2);
                    i++;
                }
                return ct;
            }
            else
            {
                return null;
            }
        }

        private Content[] getQuestions(int structureID)
        {
            if (typeIndex > -1)
            {
                String[] selections = new String[] { "QuestionCode",
                    "QuestionScore", "QuestionSubject", "Question",
                    "QuestionAnswer" };
                String condition = "QuestionType=" + structureID + 
                    " AND QuestionTag=\'" + typeIndex + "\'";
                IDataReader reader = db.query("E_SHFQuestions", selections,
                    condition, null);
                ct = new Content[db.getSize()];
                int i = 0;
                while (reader.Read())
                {
                    ct[i] = new Content();
                    if (!reader.IsDBNull(0))
                    {
                        ct[i].title = reader.GetString(0);
                        if (ct[i].title == "")
                            ct[i].title = "第" + (i + 1) + "题";
                    }
                    else
                        ct[i].title = "第" + (i + 1) + "题";
                    if (!reader.IsDBNull(1))
                        ct[i].score = reader.GetInt32(1);
                    if (!reader.IsDBNull(2))
                        ct[i].image = reader.GetString(2).Split(
                            new char[] { ',' });
                    if (!reader.IsDBNull(3))
                    {
                        String str = reader.GetString(3);
                        if(str.Contains(','))
                            ct[i].disName = reader.GetString(3).Split(
                                new char[] { ',' });
                    }
                    if (!reader.IsDBNull(4))
                    {
                        String str = reader.GetString(4);
                        if(str.Contains(','))
                        {
                            ct[i].optName = reader.GetString(4).Split(
                                new char[] { ',' });
                        }
                        else
                        {
                            int length = ct[i].image.Length;
                            int num = Convert.ToInt32(str);
                            ct[i].mark = new bool[length];
                            for (int m = 0; m < length; m++)
                            {
                                if (m != num)
                                    ct[i].mark[m] = false;
                                else
                                    ct[i].mark[m] = true;
                            }
                        }
                    }
                    i++;
                }
                return ct;
            }
            else
            {
                return null;
            }
        }

        public Content[] getCheckedListItems(int level, int fatherIndex)
        {
            int structureID = getID(level-1, fatherIndex);
            switch (structureID)
            {
                case 7:
                    return getPages(structureID);
                default:
                    return getQuestions(structureID); 
            }
        }
    }
}
