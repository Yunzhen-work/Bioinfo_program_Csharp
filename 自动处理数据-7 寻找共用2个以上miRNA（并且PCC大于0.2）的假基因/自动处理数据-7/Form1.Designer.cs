namespace 自动处理数据_7
{
    partial class Form1
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
            this.label_author = new System.Windows.Forms.Label();
            this.label_Info = new System.Windows.Forms.Label();
            this.textBox_OutputFile = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_SelectFile1 = new System.Windows.Forms.Button();
            this.button_SelectOutputFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_out = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_SelectFile2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label_PCC = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_author
            // 
            this.label_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_author.AutoSize = true;
            this.label_author.Location = new System.Drawing.Point(1320, 300);
            this.label_author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(170, 18);
            this.label_author.TabIndex = 76;
            this.label_author.Text = "by 大肥 2016.01.16";
            // 
            // label_Info
            // 
            this.label_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Info.AutoSize = true;
            this.label_Info.Location = new System.Drawing.Point(18, 300);
            this.label_Info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(80, 18);
            this.label_Info.TabIndex = 75;
            this.label_Info.Text = "等待开始";
            // 
            // textBox_OutputFile
            // 
            this.textBox_OutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_OutputFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_OutputFile.Location = new System.Drawing.Point(243, 108);
            this.textBox_OutputFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_OutputFile.Name = "textBox_OutputFile";
            this.textBox_OutputFile.ReadOnly = true;
            this.textBox_OutputFile.Size = new System.Drawing.Size(1000, 28);
            this.textBox_OutputFile.TabIndex = 72;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(243, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1000, 28);
            this.textBox1.TabIndex = 69;
            // 
            // button_SelectFile1
            // 
            this.button_SelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile1.Location = new System.Drawing.Point(1254, 18);
            this.button_SelectFile1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SelectFile1.Name = "button_SelectFile1";
            this.button_SelectFile1.Size = new System.Drawing.Size(236, 34);
            this.button_SelectFile1.TabIndex = 70;
            this.button_SelectFile1.Text = "选择文件1";
            this.button_SelectFile1.UseVisualStyleBackColor = true;
            this.button_SelectFile1.Click += new System.EventHandler(this.button_SelectFile1_Click);
            // 
            // button_SelectOutputFile
            // 
            this.button_SelectOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectOutputFile.Location = new System.Drawing.Point(1254, 105);
            this.button_SelectOutputFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SelectOutputFile.Name = "button_SelectOutputFile";
            this.button_SelectOutputFile.Size = new System.Drawing.Size(236, 34);
            this.button_SelectOutputFile.TabIndex = 73;
            this.button_SelectOutputFile.Text = "选择输出文件";
            this.button_SelectOutputFile.UseVisualStyleBackColor = true;
            this.button_SelectOutputFile.Click += new System.EventHandler(this.button_SelectOutputFile_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 18);
            this.label1.TabIndex = 68;
            this.label1.Text = "mRNA-miRNA-假基因文件";
            // 
            // label_out
            // 
            this.label_out.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_out.AutoSize = true;
            this.label_out.Location = new System.Drawing.Point(36, 114);
            this.label_out.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_out.Name = "label_out";
            this.label_out.Size = new System.Drawing.Size(80, 18);
            this.label_out.TabIndex = 71;
            this.label_out.Text = "输出文件";
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start.Location = new System.Drawing.Point(1254, 148);
            this.button_Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(236, 82);
            this.button_Start.TabIndex = 74;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_SelectFile2
            // 
            this.button_SelectFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile2.Location = new System.Drawing.Point(1254, 62);
            this.button_SelectFile2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SelectFile2.Name = "button_SelectFile2";
            this.button_SelectFile2.Size = new System.Drawing.Size(236, 34);
            this.button_SelectFile2.TabIndex = 78;
            this.button_SelectFile2.Text = "选择文件2";
            this.button_SelectFile2.UseVisualStyleBackColor = true;
            this.button_SelectFile2.Click += new System.EventHandler(this.button_SelectFile2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Location = new System.Drawing.Point(243, 64);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1000, 28);
            this.textBox2.TabIndex = 77;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(14, 68);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(214, 22);
            this.checkBox2.TabIndex = 80;
            this.checkBox2.Text = "假基因-假基因PCC文件";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label_PCC
            // 
            this.label_PCC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PCC.AutoSize = true;
            this.label_PCC.Location = new System.Drawing.Point(36, 183);
            this.label_PCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_PCC.Name = "label_PCC";
            this.label_PCC.Size = new System.Drawing.Size(179, 18);
            this.label_PCC.TabIndex = 81;
            this.label_PCC.Text = "仅输出PCC绝对值大于";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(243, 177);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(140, 28);
            this.numericUpDown1.TabIndex = 82;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 332);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label_PCC);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button_SelectFile2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label_author);
            this.Controls.Add(this.label_Info);
            this.Controls.Add(this.textBox_OutputFile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_SelectFile1);
            this.Controls.Add(this.button_SelectOutputFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_out);
            this.Controls.Add(this.button_Start);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动处理数据-7 寻找共用2个以上miRNA（并且PCC绝对值大于0.2）的假基因";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.TextBox textBox_OutputFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_SelectFile1;
        private System.Windows.Forms.Button button_SelectOutputFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_out;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_SelectFile2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label_PCC;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

