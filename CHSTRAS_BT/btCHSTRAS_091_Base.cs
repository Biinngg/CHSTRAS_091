using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;
using System.Data;

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
    }
}
