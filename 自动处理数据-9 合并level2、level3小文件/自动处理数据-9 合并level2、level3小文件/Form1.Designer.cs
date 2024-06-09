namespace 自动处理数据_9_合并level2_level3小文件
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
            this.textBox_1_OutputFile = new System.Windows.Forms.TextBox();
            this.button_1_SelectOutputFile = new System.Windows.Forms.Button();
            this.label_1_out = new System.Windows.Forms.Label();
            this.button_1_Start = new System.Windows.Forms.Button();
            this.label_1_1 = new System.Windows.Forms.Label();
            this.button_1_SelectFile = new System.Windows.Forms.Button();
            this.textBox_1_level = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Expression_Genes = new System.Windows.Forms.TabPage();
            this.tabPage_miRNASeq = new System.Windows.Forms.TabPage();
            this.textBox_2_InteractionList = new System.Windows.Forms.TextBox();
            this.button_2_SelectFile3 = new System.Windows.Forms.Button();
            this.label_2_3 = new System.Windows.Forms.Label();
            this.textBox_2_level = new System.Windows.Forms.TextBox();
            this.button_2_SelectFile1 = new System.Windows.Forms.Button();
            this.label_2_1 = new System.Windows.Forms.Label();
            this.textBox_2_MatureList = new System.Windows.Forms.TextBox();
            this.button_2_SelectFile2 = new System.Windows.Forms.Button();
            this.label_2_2 = new System.Windows.Forms.Label();
            this.label_2_out = new System.Windows.Forms.Label();
            this.button_2_SelectOutputFile = new System.Windows.Forms.Button();
            this.textBox_2_OutputFile = new System.Windows.Forms.TextBox();
            this.button_2_Start = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_Expression_Genes.SuspendLayout();
            this.tabPage_miRNASeq.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_author
            // 
            this.label_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_author.AutoSize = true;
            this.label_author.Location = new System.Drawing.Point(1118, 380);
            this.label_author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(170, 18);
            this.label_author.TabIndex = 91;
            this.label_author.Text = "by 大肥 2016.04.16";
            // 
            // label_Info
            // 
            this.label_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Info.AutoSize = true;
            this.label_Info.Location = new System.Drawing.Point(18, 380);
            this.label_Info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(80, 18);
            this.label_Info.TabIndex = 90;
            this.label_Info.Text = "等待开始";
            // 
            // textBox_1_OutputFile
            // 
            this.textBox_1_OutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_1_OutputFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_1_OutputFile.Location = new System.Drawing.Point(187, 55);
            this.textBox_1_OutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_1_OutputFile.Name = "textBox_1_OutputFile";
            this.textBox_1_OutputFile.ReadOnly = true;
            this.textBox_1_OutputFile.Size = new System.Drawing.Size(830, 28);
            this.textBox_1_OutputFile.TabIndex = 87;
            // 
            // button_1_SelectOutputFile
            // 
            this.button_1_SelectOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_1_SelectOutputFile.Location = new System.Drawing.Point(1026, 53);
            this.button_1_SelectOutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_1_SelectOutputFile.Name = "button_1_SelectOutputFile";
            this.button_1_SelectOutputFile.Size = new System.Drawing.Size(235, 35);
            this.button_1_SelectOutputFile.TabIndex = 88;
            this.button_1_SelectOutputFile.Text = "选择输出文件";
            this.button_1_SelectOutputFile.UseVisualStyleBackColor = true;
            this.button_1_SelectOutputFile.Click += new System.EventHandler(this.button_1_SelectOutputFile_Click);
            // 
            // label_1_out
            // 
            this.label_1_out.AutoSize = true;
            this.label_1_out.Location = new System.Drawing.Point(11, 61);
            this.label_1_out.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_1_out.Name = "label_1_out";
            this.label_1_out.Size = new System.Drawing.Size(80, 18);
            this.label_1_out.TabIndex = 86;
            this.label_1_out.Text = "输出文件";
            // 
            // button_1_Start
            // 
            this.button_1_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_1_Start.Location = new System.Drawing.Point(1026, 97);
            this.button_1_Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_1_Start.Name = "button_1_Start";
            this.button_1_Start.Size = new System.Drawing.Size(235, 83);
            this.button_1_Start.TabIndex = 89;
            this.button_1_Start.Text = "开始";
            this.button_1_Start.UseVisualStyleBackColor = true;
            this.button_1_Start.Click += new System.EventHandler(this.button_1_Start_Click);
            // 
            // label_1_1
            // 
            this.label_1_1.AutoSize = true;
            this.label_1_1.Location = new System.Drawing.Point(11, 17);
            this.label_1_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_1_1.Name = "label_1_1";
            this.label_1_1.Size = new System.Drawing.Size(170, 18);
            this.label_1_1.TabIndex = 97;
            this.label_1_1.Text = "level2或level3文件";
            // 
            // button_1_SelectFile
            // 
            this.button_1_SelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_1_SelectFile.Location = new System.Drawing.Point(1026, 8);
            this.button_1_SelectFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_1_SelectFile.Name = "button_1_SelectFile";
            this.button_1_SelectFile.Size = new System.Drawing.Size(235, 35);
            this.button_1_SelectFile.TabIndex = 96;
            this.button_1_SelectFile.Text = "选择文件";
            this.button_1_SelectFile.UseVisualStyleBackColor = true;
            this.button_1_SelectFile.Click += new System.EventHandler(this.button_1_SelectFile_Click);
            // 
            // textBox_1_level
            // 
            this.textBox_1_level.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_1_level.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_1_level.Location = new System.Drawing.Point(187, 11);
            this.textBox_1_level.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_1_level.Name = "textBox_1_level";
            this.textBox_1_level.ReadOnly = true;
            this.textBox_1_level.Size = new System.Drawing.Size(830, 28);
            this.textBox_1_level.TabIndex = 95;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_Expression_Genes);
            this.tabControl1.Controls.Add(this.tabPage_miRNASeq);
            this.tabControl1.Location = new System.Drawing.Point(14, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1278, 362);
            this.tabControl1.TabIndex = 98;
            // 
            // tabPage_Expression_Genes
            // 
            this.tabPage_Expression_Genes.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Expression_Genes.Controls.Add(this.textBox_1_level);
            this.tabPage_Expression_Genes.Controls.Add(this.button_1_SelectFile);
            this.tabPage_Expression_Genes.Controls.Add(this.label_1_1);
            this.tabPage_Expression_Genes.Controls.Add(this.label_1_out);
            this.tabPage_Expression_Genes.Controls.Add(this.button_1_SelectOutputFile);
            this.tabPage_Expression_Genes.Controls.Add(this.textBox_1_OutputFile);
            this.tabPage_Expression_Genes.Controls.Add(this.button_1_Start);
            this.tabPage_Expression_Genes.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Expression_Genes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_Expression_Genes.Name = "tabPage_Expression_Genes";
            this.tabPage_Expression_Genes.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_Expression_Genes.Size = new System.Drawing.Size(1270, 330);
            this.tabPage_Expression_Genes.TabIndex = 0;
            this.tabPage_Expression_Genes.Text = "Expression_Genes";
            // 
            // tabPage_miRNASeq
            // 
            this.tabPage_miRNASeq.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_miRNASeq.Controls.Add(this.textBox_2_InteractionList);
            this.tabPage_miRNASeq.Controls.Add(this.button_2_SelectFile3);
            this.tabPage_miRNASeq.Controls.Add(this.label_2_3);
            this.tabPage_miRNASeq.Controls.Add(this.textBox_2_level);
            this.tabPage_miRNASeq.Controls.Add(this.button_2_SelectFile1);
            this.tabPage_miRNASeq.Controls.Add(this.label_2_1);
            this.tabPage_miRNASeq.Controls.Add(this.textBox_2_MatureList);
            this.tabPage_miRNASeq.Controls.Add(this.button_2_SelectFile2);
            this.tabPage_miRNASeq.Controls.Add(this.label_2_2);
            this.tabPage_miRNASeq.Controls.Add(this.label_2_out);
            this.tabPage_miRNASeq.Controls.Add(this.button_2_SelectOutputFile);
            this.tabPage_miRNASeq.Controls.Add(this.textBox_2_OutputFile);
            this.tabPage_miRNASeq.Controls.Add(this.button_2_Start);
            this.tabPage_miRNASeq.Location = new System.Drawing.Point(4, 28);
            this.tabPage_miRNASeq.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_miRNASeq.Name = "tabPage_miRNASeq";
            this.tabPage_miRNASeq.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage_miRNASeq.Size = new System.Drawing.Size(1270, 330);
            this.tabPage_miRNASeq.TabIndex = 1;
            this.tabPage_miRNASeq.Text = "miRNASeq";
            // 
            // textBox_2_InteractionList
            // 
            this.textBox_2_InteractionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_2_InteractionList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_2_InteractionList.Location = new System.Drawing.Point(187, 100);
            this.textBox_2_InteractionList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_2_InteractionList.Name = "textBox_2_InteractionList";
            this.textBox_2_InteractionList.ReadOnly = true;
            this.textBox_2_InteractionList.Size = new System.Drawing.Size(830, 28);
            this.textBox_2_InteractionList.TabIndex = 108;
            // 
            // button_2_SelectFile3
            // 
            this.button_2_SelectFile3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_2_SelectFile3.Location = new System.Drawing.Point(1026, 97);
            this.button_2_SelectFile3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_2_SelectFile3.Name = "button_2_SelectFile3";
            this.button_2_SelectFile3.Size = new System.Drawing.Size(235, 35);
            this.button_2_SelectFile3.TabIndex = 109;
            this.button_2_SelectFile3.Text = "选择文件3";
            this.button_2_SelectFile3.UseVisualStyleBackColor = true;
            this.button_2_SelectFile3.Click += new System.EventHandler(this.button_2_SelectFile3_Click);
            // 
            // label_2_3
            // 
            this.label_2_3.AutoSize = true;
            this.label_2_3.Location = new System.Drawing.Point(11, 106);
            this.label_2_3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_2_3.Name = "label_2_3";
            this.label_2_3.Size = new System.Drawing.Size(98, 18);
            this.label_2_3.TabIndex = 110;
            this.label_2_3.Text = "互作对列表";
            // 
            // textBox_2_level
            // 
            this.textBox_2_level.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_2_level.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_2_level.Location = new System.Drawing.Point(187, 11);
            this.textBox_2_level.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_2_level.Name = "textBox_2_level";
            this.textBox_2_level.ReadOnly = true;
            this.textBox_2_level.Size = new System.Drawing.Size(830, 28);
            this.textBox_2_level.TabIndex = 105;
            // 
            // button_2_SelectFile1
            // 
            this.button_2_SelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_2_SelectFile1.Location = new System.Drawing.Point(1026, 8);
            this.button_2_SelectFile1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_2_SelectFile1.Name = "button_2_SelectFile1";
            this.button_2_SelectFile1.Size = new System.Drawing.Size(235, 35);
            this.button_2_SelectFile1.TabIndex = 106;
            this.button_2_SelectFile1.Text = "选择文件1";
            this.button_2_SelectFile1.UseVisualStyleBackColor = true;
            this.button_2_SelectFile1.Click += new System.EventHandler(this.button_2_SelectFile1_Click);
            // 
            // label_2_1
            // 
            this.label_2_1.AutoSize = true;
            this.label_2_1.Location = new System.Drawing.Point(11, 17);
            this.label_2_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_2_1.Name = "label_2_1";
            this.label_2_1.Size = new System.Drawing.Size(170, 18);
            this.label_2_1.TabIndex = 107;
            this.label_2_1.Text = "level2或level3文件";
            // 
            // textBox_2_MatureList
            // 
            this.textBox_2_MatureList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_2_MatureList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_2_MatureList.Location = new System.Drawing.Point(187, 55);
            this.textBox_2_MatureList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_2_MatureList.Name = "textBox_2_MatureList";
            this.textBox_2_MatureList.ReadOnly = true;
            this.textBox_2_MatureList.Size = new System.Drawing.Size(830, 28);
            this.textBox_2_MatureList.TabIndex = 102;
            // 
            // button_2_SelectFile2
            // 
            this.button_2_SelectFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_2_SelectFile2.Location = new System.Drawing.Point(1026, 53);
            this.button_2_SelectFile2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_2_SelectFile2.Name = "button_2_SelectFile2";
            this.button_2_SelectFile2.Size = new System.Drawing.Size(235, 35);
            this.button_2_SelectFile2.TabIndex = 103;
            this.button_2_SelectFile2.Text = "选择文件2";
            this.button_2_SelectFile2.UseVisualStyleBackColor = true;
            this.button_2_SelectFile2.Click += new System.EventHandler(this.button_2_SelectFile2_Click);
            // 
            // label_2_2
            // 
            this.label_2_2.AutoSize = true;
            this.label_2_2.Location = new System.Drawing.Point(11, 61);
            this.label_2_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_2_2.Name = "label_2_2";
            this.label_2_2.Size = new System.Drawing.Size(152, 18);
            this.label_2_2.TabIndex = 104;
            this.label_2_2.Text = "成熟(mature)列表";
            // 
            // label_2_out
            // 
            this.label_2_out.AutoSize = true;
            this.label_2_out.Location = new System.Drawing.Point(11, 150);
            this.label_2_out.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_2_out.Name = "label_2_out";
            this.label_2_out.Size = new System.Drawing.Size(80, 18);
            this.label_2_out.TabIndex = 98;
            this.label_2_out.Text = "输出文件";
            // 
            // button_2_SelectOutputFile
            // 
            this.button_2_SelectOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_2_SelectOutputFile.Location = new System.Drawing.Point(1026, 142);
            this.button_2_SelectOutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_2_SelectOutputFile.Name = "button_2_SelectOutputFile";
            this.button_2_SelectOutputFile.Size = new System.Drawing.Size(235, 35);
            this.button_2_SelectOutputFile.TabIndex = 100;
            this.button_2_SelectOutputFile.Text = "选择输出文件";
            this.button_2_SelectOutputFile.UseVisualStyleBackColor = true;
            this.button_2_SelectOutputFile.Click += new System.EventHandler(this.button_2_SelectOutputFile_Click);
            // 
            // textBox_2_OutputFile
            // 
            this.textBox_2_OutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_2_OutputFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_2_OutputFile.Location = new System.Drawing.Point(187, 144);
            this.textBox_2_OutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_2_OutputFile.Name = "textBox_2_OutputFile";
            this.textBox_2_OutputFile.ReadOnly = true;
            this.textBox_2_OutputFile.Size = new System.Drawing.Size(830, 28);
            this.textBox_2_OutputFile.TabIndex = 99;
            // 
            // button_2_Start
            // 
            this.button_2_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_2_Start.Location = new System.Drawing.Point(1026, 185);
            this.button_2_Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_2_Start.Name = "button_2_Start";
            this.button_2_Start.Size = new System.Drawing.Size(235, 83);
            this.button_2_Start.TabIndex = 101;
            this.button_2_Start.Text = "开始";
            this.button_2_Start.UseVisualStyleBackColor = true;
            this.button_2_Start.Click += new System.EventHandler(this.button_2_Start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 413);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_author);
            this.Controls.Add(this.label_Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动处理数据-9 合并level2、level3小文件";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Expression_Genes.ResumeLayout(false);
            this.tabPage_Expression_Genes.PerformLayout();
            this.tabPage_miRNASeq.ResumeLayout(false);
            this.tabPage_miRNASeq.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.TextBox textBox_1_OutputFile;
        private System.Windows.Forms.Button button_1_SelectOutputFile;
        private System.Windows.Forms.Label label_1_out;
        private System.Windows.Forms.Button button_1_Start;
        private System.Windows.Forms.Label label_1_1;
        private System.Windows.Forms.Button button_1_SelectFile;
        private System.Windows.Forms.TextBox textBox_1_level;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Expression_Genes;
        private System.Windows.Forms.TabPage tabPage_miRNASeq;
        private System.Windows.Forms.TextBox textBox_2_level;
        private System.Windows.Forms.Button button_2_SelectFile1;
        private System.Windows.Forms.Label label_2_1;
        private System.Windows.Forms.TextBox textBox_2_MatureList;
        private System.Windows.Forms.Button button_2_SelectFile2;
        private System.Windows.Forms.Label label_2_2;
        private System.Windows.Forms.Label label_2_out;
        private System.Windows.Forms.Button button_2_SelectOutputFile;
        private System.Windows.Forms.TextBox textBox_2_OutputFile;
        private System.Windows.Forms.Button button_2_Start;
        private System.Windows.Forms.TextBox textBox_2_InteractionList;
        private System.Windows.Forms.Button button_2_SelectFile3;
        private System.Windows.Forms.Label label_2_3;
    }
}

