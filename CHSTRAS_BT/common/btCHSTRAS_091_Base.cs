using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;
using System.Data;
using System.Collections;

namespace CHSTRAS_091_BT
{
    public class btCHSTRAS_091_Base
    {

        public String getClassInfo(btSHFUnitPractice callUnit)
        {
            btSHFStructures structures = new btSHFStructures();
            btSHFStructure stru = structures.GetOne(1);
            String classInfo1 = stru.StructureName;
            stru = structures.GetOne(2);
            String classInfo2 = stru.StructureName;
            stru = structures.GetOne(callUnit.UnitID);
            String classInfo3 = stru.StructureName;
            String result = classInfo1 + "|" + classInfo2 + "|" + classInfo3;
            return result;
        }

        public String getProgramInfo(btSHFUnitPractice callUnit)
        {
            String programInfo = "《认识事物 CHSTRAS_091》V09-1|CHSTRAS_091_UI|";
            programInfo += callUnit.UnitPracticeCode;
            return programInfo;
        }

        public int getPagesID(btSHFUnitPractice shfUnitPratice)
        {
            int unitID = shfUnitPratice.UnitID;
            String where = "FatherID=" + unitID + " AND SubOrder=0";
            btCHSTRAS_091_Database database = new btCHSTRAS_091_Database();
            IDataReader reader = database.query("E_SHFStructures", new String[]{"ProgramID"}, where, null);
            reader.Read();
            return reader.GetInt32(0);
        }

        public Hashtable getUserUnitIDs(btSHFUserLogin shfUserLogin, btSHFUnitPractice shfUnitPratice)
        {
            Hashtable keyValues = new Hashtable();
            keyValues.Add("ProgramID", shfUnitPratice.ProgramID);
            keyValues.Add("UnitID", shfUnitPratice.UnitID);
            keyValues.Add("UnitPracticeID", shfUnitPratice.UnitPracticeID);
            if (shfUserLogin.LoginType == 2)
            {
                keyValues.Add("TeacherID", shfUserLogin.UserID);
                keyValues.Add("StudentID", 0);
            }
            else
            {
                keyValues.Add("TeacherID", 0);
                keyValues.Add("StudentID", shfUserLogin.UserID);
            }
            return keyValues;
        }

        public int getAnswerTime(DateTime startTime)
        {
            DateTime now = DateTime.Now;
            TimeSpan diff = now - startTime;
            return (int)diff.TotalSeconds;
        }
    }
}
