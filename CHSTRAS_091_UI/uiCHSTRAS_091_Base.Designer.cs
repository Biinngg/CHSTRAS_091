namespace CHSTRAS_091_UI
{
    partial class uiCHSTRAS_091_Base
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonBackward = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.labelBegin = new System.Windows.Forms.Label();
            this.labelHave = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelAnswered = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.groupBox.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // button返回
            // 
            this.button返回.Visible = false;
            // 
            // button退出
            // 
            this.button退出.Visible = false;
            // 
            // button确定
            // 
            this.button确定.Visible = false;
            // 
            // label程序信息
            // 
            this.label程序信息.Size = new System.Drawing.Size(305, 12);
            this.label程序信息.Text = "《认识事物 CHSTRAS_091》V09-1|SHF_UI|uiCHSTRAS_091";
            // 
            // label课程信息
            // 
            this.label课程信息.Size = new System.Drawing.Size(161, 12);
            this.label课程信息.Tag = "中文学习|认识事物|业务流程";
            this.label课程信息.Text = "中文学习|认识事物|业务流程";
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.Size = new System.Drawing.Size(159, 35);
            this.labelPageTitle.Text = "认识事物";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonBackward);
            this.groupBox.Controls.Add(this.buttonForward);
            this.groupBox.Controls.Add(this.buttonSubmit);
            this.groupBox.Location = new System.Drawing.Point(30, 107);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(605, 377);
            this.groupBox.TabIndex = 148;
            this.groupBox.TabStop = false;
            // 
            // buttonBackward
            // 
            this.buttonBackward.Location = new System.Drawing.Point(78, 328);
            this.buttonBackward.Name = "buttonBackward";
            this.buttonBackward.Size = new System.Drawing.Size(75, 23);
            this.buttonBackward.TabIndex = 20;
            this.buttonBackward.Text = "上一题";
            this.buttonBackward.UseVisualStyleBackColor = true;
            this.buttonBackward.Click += new System.EventHandler(this.buttonBackward_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(256, 328);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(75, 23);
            this.buttonForward.TabIndex = 0;
            this.buttonForward.Text = "下一题";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(432, 328);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 10;
            this.buttonSubmit.Text = "提交";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Font = new System.Drawing.Font("华文行楷", 15.75F);
            this.buttonExit.Location = new System.Drawing.Point(696, 417);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(64, 56);
            this.buttonExit.TabIndex = 149;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.progressBar1);
            this.groupBoxInfo.Controls.Add(this.labelProgress);
            this.groupBoxInfo.Controls.Add(this.labelBegin);
            this.groupBoxInfo.Controls.Add(this.labelHave);
            this.groupBoxInfo.Controls.Add(this.labelTotal);
            this.groupBoxInfo.Controls.Add(this.labelAnswered);
            this.groupBoxInfo.Location = new System.Drawing.Point(641, 155);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(148, 125);
            this.groupBoxInfo.TabIndex = 150;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "统计信息";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(55, 100);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(87, 16);
            this.progressBar1.TabIndex = 153;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelProgress.Location = new System.Drawing.Point(6, 100);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(41, 16);
            this.labelProgress.TabIndex = 152;
            this.labelProgress.Text = "进度：";
            // 
            // labelBegin
            // 
            this.labelBegin.AutoSize = true;
            this.labelBegin.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBegin.Location = new System.Drawing.Point(6, 20);
            this.labelBegin.Name = "labelBegin";
            this.labelBegin.Size = new System.Drawing.Size(63, 16);
            this.labelBegin.TabIndex = 151;
            this.labelBegin.Text = "开始时间：";
            // 
            // labelHave
            // 
            this.labelHave.AutoSize = true;
            this.labelHave.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelHave.Location = new System.Drawing.Point(6, 40);
            this.labelHave.Name = "labelHave";
            this.labelHave.Size = new System.Drawing.Size(63, 16);
            this.labelHave.TabIndex = 151;
            this.labelHave.Text = "已用时间：";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTotal.Location = new System.Drawing.Point(6, 80);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(64, 16);
            this.labelTotal.TabIndex = 151;
            this.labelTotal.Text = "总题数：    ";
            // 
            // labelAnswered
            // 
            this.labelAnswered.AutoSize = true;
            this.labelAnswered.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAnswered.Location = new System.Drawing.Point(6, 60);
            this.labelAnswered.Name = "labelAnswered";
            this.labelAnswered.Size = new System.Drawing.Size(63, 16);
            this.labelAnswered.TabIndex = 151;
            this.labelAnswered.Text = "已答题数：";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiCHSTRAS_091_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(792, 516);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.groupBoxInfo);
            this.Name = "uiCHSTRAS_091_Base";
            this.Controls.SetChildIndex(this.groupBoxInfo, 0);
            this.Controls.SetChildIndex(this.buttonExit, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
            this.Controls.SetChildIndex(this.button退出, 0);
            this.Controls.SetChildIndex(this.labelPageTitle, 0);
            this.Controls.SetChildIndex(this.label课程信息, 0);
            this.Controls.SetChildIndex(this.label程序信息, 0);
            this.Controls.SetChildIndex(this.label姓名, 0);
            this.Controls.SetChildIndex(this.label学号, 0);
            this.Controls.SetChildIndex(this.pictureBoxHead, 0);
            this.Controls.SetChildIndex(this.button返回, 0);
            this.Controls.SetChildIndex(this.button确定, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox;
        protected System.Windows.Forms.Button buttonBackward;
        protected System.Windows.Forms.Button buttonForward;
        protected System.Windows.Forms.Button buttonSubmit;
        protected System.Windows.Forms.Button buttonExit;
        protected System.Windows.Forms.GroupBox groupBoxInfo;
        protected System.Windows.Forms.ProgressBar progressBar1;
        protected System.Windows.Forms.Label labelProgress;
        protected System.Windows.Forms.Label labelBegin;
        protected System.Windows.Forms.Label labelHave;
        protected System.Windows.Forms.Label labelTotal;
        protected System.Windows.Forms.Label labelAnswered;
        protected System.Windows.Forms.Timer timer1;

    }
}
