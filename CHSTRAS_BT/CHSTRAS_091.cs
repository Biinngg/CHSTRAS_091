using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SHF_BT;

namespace CHSTRAS_091_BT
{
    public class CHSTRAS_091
    {
        private btSHFStructures structures = new btSHFStructures();

        public String getClassInfo(btSHFUnitPractice callUnit)
        {
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
    }
}
