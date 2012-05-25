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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonBackward = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.groupBox.SuspendLayout();
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
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(256, 328);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(75, 23);
            this.buttonForward.TabIndex = 0;
            this.buttonForward.Text = "下一题";
            this.buttonForward.UseVisualStyleBackColor = true;
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
            // uiCHSTRAS_091_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(792, 516);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.buttonExit);
            this.KeyPreview = true;
            this.Name = "uiCHSTRAS_091_Base";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiCHSTRAS_091_Base_KeyDown);
            this.Controls.SetChildIndex(this.button退出, 0);
            this.Controls.SetChildIndex(this.buttonExit, 0);
            this.Controls.SetChildIndex(this.groupBox, 0);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox;
        protected System.Windows.Forms.Button buttonBackward;
        protected System.Windows.Forms.Button buttonForward;
        protected System.Windows.Forms.Button buttonSubmit;
        protected System.Windows.Forms.Button buttonExit;

    }
}
