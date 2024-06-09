namespace 自动处理数据_10_处理gtf文件_分类pseudo_mRNA_lncRNA并分列处理数据
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_SelectFile1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_OutputFile = new System.Windows.Forms.TextBox();
            this.button_SelectOutputFile = new System.Windows.Forms.Button();
            this.label_out = new System.Windows.Forms.Label();
            this.richTextBox_Info = new System.Windows.Forms.RichTextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_author = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(182, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(770, 28);
            this.textBox1.TabIndex = 87;
            // 
            // button_SelectFile1
            // 
            this.button_SelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile1.Location = new System.Drawing.Point(962, 18);
            this.button_SelectFile1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_SelectFile1.Name = "button_SelectFile1";
            this.button_SelectFile1.Size = new System.Drawing.Size(235, 35);
            this.button_SelectFile1.TabIndex = 88;
            this.button_SelectFile1.Text = "选择文件";
            this.button_SelectFile1.UseVisualStyleBackColor = true;
            this.button_SelectFile1.Click += new System.EventHandler(this.button_SelectFile1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 86;
            this.label1.Text = "annotation all";
            // 
            // textBox_OutputFile
            // 
            this.textBox_OutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_OutputFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_OutputFile.Location = new System.Drawing.Point(182, 65);
            this.textBox_OutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_OutputFile.Name = "textBox_OutputFile";
            this.textBox_OutputFile.ReadOnly = true;
            this.textBox_OutputFile.Size = new System.Drawing.Size(770, 28);
            this.textBox_OutputFile.TabIndex = 90;
            // 
            // button_SelectOutputFile
            // 
            this.button_SelectOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectOutputFile.Location = new System.Drawing.Point(962, 62);
            this.button_SelectOutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_SelectOutputFile.Name = "button_SelectOutputFile";
            this.button_SelectOutputFile.Size = new System.Drawing.Size(235, 35);
            this.button_SelectOutputFile.TabIndex = 91;
            this.button_SelectOutputFile.Text = "选择输出文件";
            this.button_SelectOutputFile.UseVisualStyleBackColor = true;
            this.button_SelectOutputFile.Click += new System.EventHandler(this.button_SelectOutputFile_Click);
            // 
            // label_out
            // 
            this.label_out.AutoSize = true;
            this.label_out.Location = new System.Drawing.Point(15, 71);
            this.label_out.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_out.Name = "label_out";
            this.label_out.Size = new System.Drawing.Size(80, 18);
            this.label_out.TabIndex = 89;
            this.label_out.Text = "输出文件";
            // 
            // richTextBox_Info
            // 
            this.richTextBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Info.Location = new System.Drawing.Point(14, 234);
            this.richTextBox_Info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox_Info.Name = "richTextBox_Info";
            this.richTextBox_Info.ReadOnly = true;
            this.richTextBox_Info.Size = new System.Drawing.Size(1183, 231);
            this.richTextBox_Info.TabIndex = 93;
            this.richTextBox_Info.Text = "等待开始";
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start.Location = new System.Drawing.Point(962, 107);
            this.button_Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(235, 83);
            this.button_Start.TabIndex = 94;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label_author
            // 
            this.label_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_author.AutoSize = true;
            this.label_author.Location = new System.Drawing.Point(1029, 212);
            this.label_author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(170, 18);
            this.label_author.TabIndex = 95;
            this.label_author.Text = "by 大肥 2017.02.09";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(395, 18);
            this.label2.TabIndex = 96;
            this.label2.Text = "注：目前仅分类，不分列，lncRNA只包含lincRNA";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 480);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_author);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.richTextBox_Info);
            this.Controls.Add(this.textBox_OutputFile);
            this.Controls.Add(this.button_SelectOutputFile);
            this.Controls.Add(this.label_out);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_SelectFile1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动处理数据-10 处理gtf文件：分类pseudo、mRNA、lncRNA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_SelectFile1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_OutputFile;
        private System.Windows.Forms.Button button_SelectOutputFile;
        private System.Windows.Forms.Label label_out;
        private System.Windows.Forms.RichTextBox richTextBox_Info;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.Label label2;
    }
}

