using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_BT;

namespace CHSTRAS_091_UI
{
    public partial class uiCHSTRAS_091_CourseShow : SHF_UI.uiSHF_CourseBase
    {
        private int itemId;
        public uiCHSTRAS_091_CourseShow()
        {
            InitializeComponent();
            itemId = 2;
        }

        public uiCHSTRAS_091_CourseShow(Form callForm, btSHFUserLogin callLog, btSHFUnitPractice callUnit)
            : base(callForm, callLog, callUnit)
        {
            InitializeComponent();
        }

        // 组合框选择事件
        private void ucCourseManagerSimple1_comCourse_AfterSelect(object sender, EventArgs e)
        {
            label课程信息.Text = ucCourseManagerSimple1.FieldName + "|" + ucCourseManagerSimple1.CourseName + "|" + ucCourseManagerSimple1.UnitName;

            label程序信息.Text = "《认识事物 CHSTRAS_091》V09-1|CHSTRAS_091_UI|uiCHSTRAS_091_CourseEdit";
            if (ucCourseManagerSimple1.TerminalID > 0)
                labelPageTitle.Text = this.myPages.GetOne(ucCourseManagerSimple1.TerminalID).PageTitle;
            else
                labelPageTitle.Text = this.ucCourseManagerSimple1.FieldName;
        }

        // TreeView控件选择事件
        private void ucCourseManagerSimple1_trvCourse_AfterSelect(object sender, EventArgs e)
        {
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            myPages.GetOne(itemId);
        }
    }
}
