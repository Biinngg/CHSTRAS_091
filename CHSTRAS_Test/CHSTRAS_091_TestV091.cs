using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using _认识事物_CHSTRAS_091_;
using CHSTRAS_091_BT;
using CHSTRAS_091_UI;

namespace CHSTRAS_091_Test
{
    public partial class CHSTRAS_091_TestV091 : SHF_UI.uiSHF_TestBase
    {
        public CHSTRAS_091_TestV091()
        {
            InitializeComponent();
        }

        public CHSTRAS_091_TestV091(Form callForm)
            : base(callForm)
        {
            InitializeComponent();
        }

        public CHSTRAS_091_TestV091(Form callForm, string callConnect)
            : base(callForm, callConnect)
        {
            InitializeComponent();
        }

        private void button主界面_Click(object sender, EventArgs e)
        {
            CHSTRAS_091 f = new CHSTRAS_091();
            f.Show();
        }

        private void button登录_Click(object sender, EventArgs e)
        {
            // 说明：
            // this -- 升级版实验窗体对象
            // this myUser -- 用户对象，保存登录对象信息，默认为来宾。
            // this.myUserLogin --用户登录状态对象，保存登录用户的状态信息，包括时间等。
            // userType -- 用户类型，设定默认的用户列表。

            int userType = 0; // 0 =来宾，1 = 学生， 2 = 教师。
            SHF_UI.uiSHF_Login f = new SHF_UI.uiSHF_Login(this, this.myUser, this.myUserLogin, userType);
            f.Show();
        }

        private void button目录_Click(object sender, EventArgs e)
        {
            // 训练对象：设置训练内容和训练要求。
            // 选择对象：修改训练对象内容。
            this.myUnitPrac = myUnitPracs.GetOne(6); // 按键练习的训练ID是 6；
            uiTyping01_Option f = new uiTyping01_Option(this, myUserLogin, myUnitPrac);
            f.Show();
        }
    }
}
