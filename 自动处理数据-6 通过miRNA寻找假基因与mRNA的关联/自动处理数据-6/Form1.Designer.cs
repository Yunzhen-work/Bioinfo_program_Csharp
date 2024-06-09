namespace 自动处理数据_5
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
            this.textBox_OutputFile = new System.Windows.Forms.TextBox();
            this.button_SelectFile2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_SelectFile1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button_SelectOutputFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_out = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_author = new System.Windows.Forms.Label();
            this.label_Info = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_SelectFile3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox_ExportValue = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_ENSG = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBox_OutputFile
            // 
            this.textBox_OutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_OutputFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_OutputFile.Location = new System.Drawing.Point(188, 218);
            this.textBox_OutputFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_OutputFile.Name = "textBox_OutputFile";
            this.textBox_OutputFile.ReadOnly = true;
            this.textBox_OutputFile.Size = new System.Drawing.Size(1000, 28);
            this.textBox_OutputFile.TabIndex = 59;
            // 
            // button_SelectFile2
            // 
            this.button_SelectFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile2.Location = new System.Drawing.Point(1198, 128);
            this.button_SelectFile2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SelectFile2.Name = "button_SelectFile2";
            this.button_SelectFile2.Size = new System.Drawing.Size(236, 34);
            this.button_SelectFile2.TabIndex = 63;
            this.button_SelectFile2.Text = "选择文件2";
            this.button_SelectFile2.UseVisualStyleBackColor = true;
            this.button_SelectFile2.Click += new System.EventHandler(this.button_SelectFile2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(188, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1000, 28);
            this.textBox1.TabIndex = 56;
            // 
            // button_SelectFile1
            // 
            this.button_SelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile1.Location = new System.Drawing.Point(1198, 18);
            this.button_SelectFile1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SelectFile1.Name = "button_SelectFile1";
            this.button_SelectFile1.Size = new System.Drawing.Size(236, 34);
            this.button_SelectFile1.TabIndex = 57;
            this.button_SelectFile1.Text = "选择文件1";
            this.button_SelectFile1.UseVisualStyleBackColor = true;
            this.button_SelectFile1.Click += new System.EventHandler(this.button_SelectFile1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Location = new System.Drawing.Point(188, 130);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1000, 28);
            this.textBox2.TabIndex = 62;
            // 
            // button_SelectOutputFile
            // 
            this.button_SelectOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectOutputFile.Location = new System.Drawing.Point(1198, 214);
            this.button_SelectOutputFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SelectOutputFile.Name = "button_SelectOutputFile";
            this.button_SelectOutputFile.Size = new System.Drawing.Size(236, 34);
            this.button_SelectOutputFile.TabIndex = 60;
            this.button_SelectOutputFile.Text = "选择输出文件";
            this.button_SelectOutputFile.UseVisualStyleBackColor = true;
            this.button_SelectOutputFile.Click += new System.EventHandler(this.button_SelectOutputFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 55;
            this.label1.Text = "假基因信息文件";
            // 
            // label_out
            // 
            this.label_out.AutoSize = true;
            this.label_out.Location = new System.Drawing.Point(22, 224);
            this.label_out.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_out.Name = "label_out";
            this.label_out.Size = new System.Drawing.Size(80, 18);
            this.label_out.TabIndex = 58;
            this.label_out.Text = "输出文件";
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start.Location = new System.Drawing.Point(1198, 258);
            this.button_Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(236, 82);
            this.button_Start.TabIndex = 61;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label_author
            // 
            this.label_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_author.AutoSize = true;
            this.label_author.Location = new System.Drawing.Point(1264, 436);
            this.label_author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(170, 18);
            this.label_author.TabIndex = 67;
            this.label_author.Text = "by 大肥 2016.01.29";
            // 
            // label_Info
            // 
            this.label_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Info.AutoSize = true;
            this.label_Info.Location = new System.Drawing.Point(18, 436);
            this.label_Info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(80, 18);
            this.label_Info.TabIndex = 66;
            this.label_Info.Text = "等待开始";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 68;
            this.label2.Text = "miRNA-假基因文件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 71;
            this.label3.Text = "miRNA-mRNA文件";
            // 
            // button_SelectFile3
            // 
            this.button_SelectFile3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile3.Location = new System.Drawing.Point(1198, 171);
            this.button_SelectFile3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SelectFile3.Name = "button_SelectFile3";
            this.button_SelectFile3.Size = new System.Drawing.Size(236, 34);
            this.button_SelectFile3.TabIndex = 70;
            this.button_SelectFile3.Text = "选择文件3";
            this.button_SelectFile3.UseVisualStyleBackColor = true;
            this.button_SelectFile3.Click += new System.EventHandler(this.button_SelectFile3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox3.Location = new System.Drawing.Point(188, 174);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(1000, 28);
            this.textBox3.TabIndex = 69;
            // 
            // checkBox_ExportValue
            // 
            this.checkBox_ExportValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_ExportValue.AutoSize = true;
            this.checkBox_ExportValue.Location = new System.Drawing.Point(832, 260);
            this.checkBox_ExportValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_ExportValue.Name = "checkBox_ExportValue";
            this.checkBox_ExportValue.Size = new System.Drawing.Size(358, 22);
            this.checkBox_ExportValue.TabIndex = 72;
            this.checkBox_ExportValue.Text = "同时输出包含假基因信息文件中的表达值";
            this.checkBox_ExportValue.UseVisualStyleBackColor = true;
            this.checkBox_ExportValue.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 73;
            this.label4.Text = "包含";
            // 
            // checkBox_ENSG
            // 
            this.checkBox_ENSG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_ENSG.AutoSize = true;
            this.checkBox_ENSG.Location = new System.Drawing.Point(239, 62);
            this.checkBox_ENSG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_ENSG.Name = "checkBox_ENSG";
            this.checkBox_ENSG.Size = new System.Drawing.Size(70, 22);
            this.checkBox_ENSG.TabIndex = 74;
            this.checkBox_ENSG.Text = "ENSG";
            this.checkBox_ENSG.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(539, 18);
            this.label5.TabIndex = 75;
            this.label5.Text = "自动识别position信息位于Position单列还是chr、Start、End三列";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(188, 258);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(249, 22);
            this.radioButton1.TabIndex = 77;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "所有的假基因输出一个文件";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(188, 291);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(249, 22);
            this.radioButton2.TabIndex = 78;
            this.radioButton2.Text = "每一个假基因输出一个文件";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 468);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_ENSG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_ExportValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_SelectFile3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_author);
            this.Controls.Add(this.label_Info);
            this.Controls.Add(this.textBox_OutputFile);
            this.Controls.Add(this.button_SelectFile2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_SelectFile1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button_SelectOutputFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_out);
            this.Controls.Add(this.button_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动处理数据-通过miRNA寻找假基因与mRNA的关联 v2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_OutputFile;
        private System.Windows.Forms.Button button_SelectFile2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_SelectFile1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button_SelectOutputFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_out;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_SelectFile3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox_ExportValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_ENSG;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

