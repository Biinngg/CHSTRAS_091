namespace CHSTRAS_091_UI
{
    partial class uiCHSTRAS_091_CourseShow
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonBefore = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.ucCourseManagerSimple1 = new SHF_UI.ucCourseManagerSimple();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label程序信息
            // 
            this.label程序信息.Size = new System.Drawing.Size(419, 12);
            this.label程序信息.Text = "《认识事物 CHSTRAS_091》V09-1|CHSTRAS_091_UI|uiCHSTRAS_091_CourseShow";
            // 
            // label课程信息
            // 
            this.label课程信息.Size = new System.Drawing.Size(161, 12);
            this.label课程信息.Text = "中文学习|认识事物|认识植物";
            // 
            // labelPageTitle
            // 
            this.labelPageTitle.Size = new System.Drawing.Size(159, 35);
            this.labelPageTitle.Text = "认识植物";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.pictureBox2);
            this.groupBox.Controls.Add(this.pictureBox1);
            this.groupBox.Location = new System.Drawing.Point(205, 120);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(426, 280);
            this.groupBox.TabIndex = 148;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "教学内容";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "图片2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "图片1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(212, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 150);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 150);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonBefore
            // 
            this.buttonBefore.Location = new System.Drawing.Point(261, 435);
            this.buttonBefore.Name = "buttonBefore";
            this.buttonBefore.Size = new System.Drawing.Size(75, 23);
            this.buttonBefore.TabIndex = 149;
            this.buttonBefore.Text = "上一题";
            this.buttonBefore.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(476, 435);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 150;
            this.buttonNext.Text = "下一题";
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // ucCourseManagerSimple1
            // 
            this.ucCourseManagerSimple1.AcdemicPoint = 1;
            this.ucCourseManagerSimple1.ChapterName = "";
            this.ucCourseManagerSimple1.CourseName = "";
            this.ucCourseManagerSimple1.FieldName = "";
            this.ucCourseManagerSimple1.Location = new System.Drawing.Point(30, 92);
            this.ucCourseManagerSimple1.Name = "ucCourseManagerSimple1";
            this.ucCourseManagerSimple1.PageName = "";
            this.ucCourseManagerSimple1.PointName = "";
            this.ucCourseManagerSimple1.Size = new System.Drawing.Size(169, 421);
            this.ucCourseManagerSimple1.StructureID = 0;
            this.ucCourseManagerSimple1.TabIndex = 151;
            this.ucCourseManagerSimple1.TerminalID = 0;
            this.ucCourseManagerSimple1.TitleName = "";
            this.ucCourseManagerSimple1.UnitName = "";
            // 
            // uiCHSTRAS_091_CourseShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 516);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.ucCourseManagerSimple1);
            this.Controls.Add(this.buttonBefore);
            this.Controls.Add(this.buttonNext);
            this.Name = "uiCHSTRAS_091_CourseShow";
            this.Controls.SetChildIndex(this.buttonNext, 0);
            this.Controls.SetChildIndex(this.buttonBefore, 0);
            this.Controls.SetChildIndex(this.ucCourseManagerSimple1, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonBefore;
        private System.Windows.Forms.Button buttonNext;
        private SHF_UI.ucCourseManagerSimple ucCourseManagerSimple1;

    }
}
