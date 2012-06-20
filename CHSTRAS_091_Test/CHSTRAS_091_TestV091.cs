using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_BT;
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
            //CHSTRAS_091 f = new CHSTRAS_091();
            //f.Show();
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
            uiCHSTRAS_091_AppMain f = new uiCHSTRAS_091_AppMain();
            f.Show();
        }

        private void button前言_Click(object sender, EventArgs e)
        {
            //处理：
            myUnitPrac = myUnitPracs.GetOne(1); // 按键练习的训练ID是 6；
            uiCHSTRAS_091_Foreword f = new uiCHSTRAS_091_Foreword(this, myUserLogin, myUnitPrac, 0);
            f.Show();
        }

        private void button认识事物_Click(object sender, EventArgs e)
        {
            //处理：
            myUnitPrac = myUnitPracs.GetOne(2); // 按键练习的训练ID是 6；
            uiCHSTRAS_091_Teach f = new uiCHSTRAS_091_Teach(this, myUserLogin, myUnitPrac, 1);
            f.Show();
        }

        private void button连结游戏_Click(object sender, EventArgs e)
        {
            myUnitPrac = myUnitPracs.GetOne(3); // 按键练习的训练ID是 6；
            uiCHSTRAS_091_Link f = new uiCHSTRAS_091_Link(this, myUserLogin, myUnitPrac, 1);
            f.Show();
        }

        private void button组合拼图_Click(object sender, EventArgs e)
        {
            myUnitPrac = myUnitPracs.GetOne(4); // 按键练习的训练ID是 6；
            uiCHSTRAS_091_Puzzle f = new uiCHSTRAS_091_Puzzle(this, myUserLogin, myUnitPrac, 1);
            f.Show();
        }

        private void button记忆门窗_Click(object sender, EventArgs e)
        {
            myUnitPrac = myUnitPracs.GetOne(5); // 按键练习的训练ID是 6；
            uiCHSTRAS_091_Memory f = new uiCHSTRAS_091_Memory(this, myUserLogin, myUnitPrac, 1);
            f.Show();
        }

        private void button找寻错误_Click(object sender, EventArgs e)
        {
            myUnitPrac = myUnitPracs.GetOne(6); // 按键练习的训练ID是 6；
            uiCHSTRAS_091_Fault f = new uiCHSTRAS_091_Fault(this, myUserLogin, myUnitPrac, 1);
            f.Show();
        }

        private void FOREWORD00_Click(object sender, EventArgs e)
        {
            button前言_Click(sender, e);
        }

        private void TEACH00_Click(object sender, EventArgs e)
        {
            button认识事物_Click(sender, e);
        }

        private void LINK00_Click(object sender, EventArgs e)
        {
            button连结游戏_Click(sender, e);
        }

        private void PUZZLE00_Click(object sender, EventArgs e)
        {
            button组合拼图_Click(sender, e);
        }

        private void MEMORY00_Click(object sender, EventArgs e)
        {
            button记忆门窗_Click(sender, e);
        }

        private void FAULT00_Click(object sender, EventArgs e)
        {
            button找寻错误_Click(sender, e);
        }
    }
}
