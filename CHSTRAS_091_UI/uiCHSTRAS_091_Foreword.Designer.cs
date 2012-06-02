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
            this.textBox = new System.Windows.Forms.TextBox();
            this.groupBox.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBackward
            // 
            this.buttonBackward.Visible = false;
            // 
            // buttonForward
            // 
            this.buttonForward.Visible = false;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Visible = false;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Visible = false;
            // 
            // labelStatistics
            // 
            this.labelStatistics.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatistics.Size = new System.Drawing.Size(174, 20);
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.Size = new System.Drawing.Size(87, 35);
            this.labelPageTitle.Text = "前言";
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
            this.Name = "uiCHSTRAS_091_Foreword";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox textBox;
    }
}
