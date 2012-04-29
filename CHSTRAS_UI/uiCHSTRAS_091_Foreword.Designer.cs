namespace CHSTRAS_091_UI
{
    partial class uiCHSTRAS_091_Foreword
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
            this.textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button返回
            // 
            this.button返回.Visible = false;
            // 
            // button确定
            // 
            this.button确定.Visible = false;
            // 
            // label程序信息
            // 
            this.label程序信息.Size = new System.Drawing.Size(359, 12);
            this.label程序信息.Text = "《认识事物 CHSTRAS_091》V09-1|SHF_UI|uiCHSTRAS_091_Foreword";
            // 
            // label课程信息
            // 
            this.label课程信息.Size = new System.Drawing.Size(137, 12);
            this.label课程信息.Tag = "中文学习|认识事物|前言";
            this.label课程信息.Text = "中文学习|认识事物|前言";
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.Size = new System.Drawing.Size(87, 35);
            this.labelPageTitle.Text = "前言";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.textBox);
            this.groupBox.Location = new System.Drawing.Point(30, 109);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(603, 379);
            this.groupBox.TabIndex = 148;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "给家长教师的话";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(20, 26);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(563, 338);
            this.textBox.TabIndex = 1;
            // 
            // uiCHSTRAS_091_Foreword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 516);
            this.Controls.Add(this.groupBox);
            this.Name = "uiCHSTRAS_091_Foreword";
            this.Controls.SetChildIndex(this.groupBox, 0);
            this.Controls.SetChildIndex(this.labelPageTitle, 0);
            this.Controls.SetChildIndex(this.label课程信息, 0);
            this.Controls.SetChildIndex(this.label程序信息, 0);
            this.Controls.SetChildIndex(this.label姓名, 0);
            this.Controls.SetChildIndex(this.label学号, 0);
            this.Controls.SetChildIndex(this.pictureBoxHead, 0);
            this.Controls.SetChildIndex(this.button退出, 0);
            this.Controls.SetChildIndex(this.button返回, 0);
            this.Controls.SetChildIndex(this.button确定, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox;
        protected System.Windows.Forms.TextBox textBox;
    }
}
