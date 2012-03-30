using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SHF_UI;
using SHF_BT;
using SHF_DA;



namespace CHSTRAS_UI
{
    public partial class uiCHSTRAS_091_WorkMain : Form
    {
        #region     程序常数说明 V07-2.01版
        protected static string shfConnect = string.Format("Provider={0};Data Source={1}{2}",
                "Microsoft.Jet.OLEDB.4.0;",
                System.AppDomain.CurrentDomain.BaseDirectory,
                "..\\..\\..\\SHFDB\\SHFDB_V07.01.mdb");
        private int myProgramID = 20001;
        private string myProgramName = "尚府教学作业";
        //private string myProgramCode = "SHF_062";
        //private string myProgramNumber = "2009-02-00-00-01";
        //private string myProgramVersion = "V06-2";

        private int myCourseID = 20001; // 学科课程
        private string myCourseName = "尚府教学";

        private int inst01UnitID = 1;
        //private string inst01UnitName = "应用程序";
        private int inst02UnitID = 2;
        //private string inst02UnitName = "教学实验";
        private int inst03UnitID = 3;
        //private string inst03UnitName = "编程实践";
        private int inst04UnitID = 4;
        //private string inst04UnitName = "课程编辑";

        private int Practice01UnitID = 6;
        //private string Practice01UnitName = "应用程序";
        private int Practice02UnitID = 7;
        //private string Practice02UnitName = "教学实验";
        private int Practice03UnitID = 8;
        //private string Practice03UnitName = "编程实践";
        private int Practice04UnitID = 8;
        //private string Practice04UnitName = "课程编辑";
        #endregion

        #region 全程变量 字段说明
        protected btSHFUser shfUser = new btSHFUser();
        private btSHFUsers shfUsers = new btSHFUsers(shfConnect);
        protected btSHFUserLogin shfUserLogin = new btSHFUserLogin();//用户运行配置数据，在各模块中需要引用。
        private btSHFUserLogins shfUserLogins = new btSHFUserLogins(shfConnect);
        protected btSHFUnitPractice shfUnitPractice = new btSHFUnitPractice();
        private btSHFUnitPractices shfUnitPractices = new btSHFUnitPractices(shfConnect);
        protected btSHFUnitScore shfUnitScore = new btSHFUnitScore();
        private btSHFUnitScores shfUnitScores = new btSHFUnitScores(shfConnect);
        protected btSHFPage shfSHFPage = new btSHFPage();
        private btSHFPages shfSHFPages = new btSHFPages(shfConnect);
        protected btSHFStructure shfSHFStructure = new btSHFStructure();
        private btSHFStructures shfSHFStructures = new btSHFStructures(shfConnect);

        //private int shfPracticeID;
        //private string shfPracticeName;
        #endregion

        #region 局部变量 字段说明
        private Form callMeForm;
        #endregion

  		#region uiSHFMain 重载说明

		public uiCHSTRAS_091_WorkMain()
		{
			InitializeComponent();

            shfInitializer(); //设置默认登录
		}

		/// <summary>调用重载（测试用）
		/// 
		/// </summary>
		/// <param name="callForm"></param>
        public uiCHSTRAS_091_WorkMain(Form callForm)
		{
			InitializeComponent();
			callMeForm = callForm;
			shfInitializer(); //设置默认登录

		}

		protected void shfInitializer()
		{
			// 初始化默认登录数据----需要初始化成为默认用户状态。
			shfUser = shfUsers.GetUserById(1);//设为默认用户。
			shfUserLogin = shfUserLogins.GetOneByUserID(1);//设为默认用户登录。

            //shfUserLogin.LoginProgramID = shfUser.ProgramID; // 设置程序标识
            shfUserLogin.LoginNumber++;
			shfUserLogin.LoginProgramID = this.myProgramID;//本程序标识
			shfUserLogin.LoginUnitID = 0; //主界面
			shfUserLogin.LastDateTime = shfUserLogin.ThisDateTime;
			shfUserLogin.ThisDateTime = DateTime.Now;

			shfUserLogins.UpdateOne(shfUserLogin);

		}


		#endregion

        #region  辅助功能--初始化、动态刷新 等

        /// <summary>登录返回
        /// 显示登录用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSHF_WorkMain_Activated(object sender, EventArgs e)
        {
            //
            try
            {
                //shfUserLogin = new btSHFUserLogin();
                //btSHFUserLogins shfUserLogins = new btSHFUserLogins();
                shfUserLogin = shfUserLogins.GetOneByUserID(shfUser.UserID);
                pictureBoxHead.ImageLocation = Application.StartupPath + shfUser.UserHeadPath;
                label学号.Text = "学号： " + shfUser.UserCode + " ";
                label姓名.Text = "姓名： " + shfUser.UserName + " ";
            }
            catch
            { }

        }

        #endregion

        #region  基本业务功能
        //用户管理
        /// <summary>单击登录
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button登录_Click(object sender, EventArgs e)
        {
            // 登录信息中需要设置：
            //  1 登录用户
            //  2 登录程序
            //  3 累计登录次数
            //  4 累计在线时间
            //  5 在线状态
            shfUserLogin.LoginProgramID = myProgramID;       //程序标识
            shfUserLogin.ProgramName = myProgramName;   //程序名称
            shfUserLogin.LoginCourseID = myCourseID;//键盘训练实验程序ID
            shfUserLogin.CourseName = myCourseName; //填写单元名称
            shfUserLogin.LoginUnitID = 2;//实验客户端登录单元ID
            shfUserLogin.UnitName = myProgramName + "登录"; //填写单元名称

            uiSHF_Login usrLog = new uiSHF_Login(this, shfUser, shfUserLogin, 1); // 默认学生登录
            usrLog.Show();

        }

        private void button注册_Click(object sender, EventArgs e)
        {
            uiSHF_Login usrLog = new uiSHF_Login(this, shfUser); // 默认学生登录
            usrLog.Show();
        }

        /// <summary>单击编辑用户
        ///  进入用户设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button设置_Click(object sender, EventArgs e)
        {
            uiSHF_Login uiR = new uiSHF_Login(this);
            uiR.Show();
            this.Hide();

        }


        // 作业题目
        private void button应用程序_Click(object sender, EventArgs e)
        {

        }

        private void button前言_Click(object sender, EventArgs e)
        {
            shfUserLogin.LoginUnitID = inst01UnitID;//设置学习内容
            //uiPageEditSimple fr = new uiPageEditSimple(this, shfUserLogin, shfSHFPage);
            ////this.Hide();
            //fr.Show();

        }

        private void button连结游戏_Click(object sender, EventArgs e)
        {

            //shfPracticeID = 6; //设置训练课程
            shfUserLogin.LoginUnitID = Practice01UnitID;//设置训练内容
            //uiTyping01 f = new uiTyping01(this, shfUserLogin.UserLoginID, shfPracticeID);
            //f.Show();


        }

        // 教学实验
        private void button原版实验_Click(object sender, EventArgs e)
        {

        }

        private void button认识植物_Click(object sender, EventArgs e)
        {

            //shfPracticeID = 6;  设置训练课程
            shfUserLogin.LoginUnitID = inst02UnitID; //设置学习内容
            //uiPageShowSimple fr = new uiPageShowSimple(this, shfUserLogin, shfSHFPage);
            //fr.Show();
            //this.Hide();

        }

        private void button组合拼图_Click(object sender, EventArgs e)
        {
            try
            {
                //shfPracticeID = 7; //设置训练课程

                shfUserLogin.LoginUnitID = Practice02UnitID;//设置训练内容
                shfUnitPractice = shfUnitPractices.GetOne(Practice02UnitID);
                //uiTyping02Option f = new uiTyping02Option(this, shfUserLogin, shfUnitPrac);
                //f.Show();
                //this.Hide();

            }
            catch
            {
                this.Text = "button组合拼图_Click 异常！  ";

            }


        }

        // 编程实践
        private void button教学03_Click(object sender, EventArgs e)
        {

            //shfPracticeID = 6;  设置训练课程
            shfUserLogin.LoginUnitID = inst03UnitID; //设置学习内容
            //uiPageShowSimple fr = new uiPageShowSimple(this, shfUserLogin, shfSHFPage);
            //fr.Show();
            //this.Hide();

        }

        private void button记忆门窗_Click(object sender, EventArgs e)
        {
            try
            {
                shfUserLogin.LoginUnitID = Practice03UnitID;//设置训练内容
                shfUnitPractice = shfUnitPractices.GetOne(Practice03UnitID);
                //btSHFUserLogin uL = new btSHFUserLogin();
                //btSHFStructure stt = new btSHFStructure();
                //uiSHFCourseBase f = new uiSHFCourseBase(this, shfUserLogin, shfSHFStructure);
                //uiTyping03Option f = new uiTyping03Option(this, shfUserLogin, shfUnitPrac);
                //f.Show();

            }
            catch
            {
                this.Text = "综合练习启动 异常！  ";

            }


        }

        // 课程编辑
        private void button创建课程_Click(object sender, EventArgs e)
        {
            uiPageEditSimple fr = new uiPageEditSimple(this, shfUserLogin);
            //this.Hide();
            fr.Show();

        }

        /// <summary>层次结构编辑
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button课程结构_Click(object sender, EventArgs e)
        {
            uiStructureManageer f = new uiStructureManageer(this, shfUserLogin);
            f.Show();
        }

        /// <summary>内容编辑
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button教学04_Click(object sender, EventArgs e)
        {

            //shfPracticeID = 6;  设置训练课程
            shfUserLogin.LoginUnitID = inst04UnitID; //设置学习内容
            uiPageShowSimple fr = new uiPageShowSimple(this, shfUserLogin, shfSHFPage);
            fr.Show();
            //this.Hide();

        }

        /// <summary>题目编辑
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button找寻错误_Click(object sender, EventArgs e)
        {
            try
            {
                shfUserLogin.LoginUnitID = Practice04UnitID;//设置训练内容
                shfUnitPractice = shfUnitPractices.GetOne(Practice04UnitID);
                //btSHFUserLogin uL = new btSHFUserLogin();
                //btSHFStructure stt = new btSHFStructure();
                //uiSHFCourseBase f = new uiSHFCourseBase(this, shfUserLogin, shfSHFStructure);
                //uiTyping03Option f = new uiTyping03Option(this, shfUserLogin, shfUnitPrac);
                //f.Show();

            }
            catch
            {
                this.Text = "综合练习启动 异常！  ";

            }


        }

        // 成绩管理

        /// <summary>单击查看成绩
        /// 查看登录用户的成绩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button单项成绩_Click(object sender, EventArgs e)
        {
            // 查看方式：
            //      1 显示给定的单元成绩记录。
            //      2 根据用户ID按顺序查看成绩。
            //      3 显示成绩表
            //uiVSKP vs = new uiVSKP();
            //uiViewScore vs = new uiViewScore(shfUser.UserID);
            //vs.Show();
        }

        private void button单元成绩_Click(object sender, EventArgs e)
        {
            shfUserLogin.LoginUnitID = Practice03UnitID;//设置训练内容
            shfUnitPractice = shfUnitPractices.GetOne(Practice03UnitID);
            //frTypeScore fr = new frTypeScore(this, shfUnitScore, shfUserLogin, shfUnitPrac);
            //fr.Show();
        }

        /// <summary>依据用户信息查看成绩
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button统计分析_Click(object sender, EventArgs e)
        {
            uiViewScore vs = new uiViewScore(shfUser.UserID);
            vs.Show();

        }



        private void button退出_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        #endregion

        private void uuiCHSTRAS_WorkMain_Load(object sender, EventArgs e)
        {

        }
 
    
    }
}
