namespace 自动处理数据_13_根据pseudogene最近的TSS计算重复元件表覆盖数量
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_SelectFile1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label_out = new System.Windows.Forms.Label();
            this.button_SelectFile2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_author = new System.Windows.Forms.Label();
            this.richTextBox_Info = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 123;
            this.label1.Text = "自动-4输出的最近TSS";
            // 
            // button_SelectFile1
            // 
            this.button_SelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile1.Location = new System.Drawing.Point(992, 13);
            this.button_SelectFile1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_SelectFile1.Name = "button_SelectFile1";
            this.button_SelectFile1.Size = new System.Drawing.Size(235, 35);
            this.button_SelectFile1.TabIndex = 125;
            this.button_SelectFile1.Text = "选择文件1";
            this.button_SelectFile1.UseVisualStyleBackColor = true;
            this.button_SelectFile1.Click += new System.EventHandler(this.button_SelectFile1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(207, 16);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(776, 28);
            this.textBox1.TabIndex = 124;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Location = new System.Drawing.Point(207, 60);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(776, 28);
            this.textBox2.TabIndex = 133;
            // 
            // label_out
            // 
            this.label_out.AutoSize = true;
            this.label_out.Location = new System.Drawing.Point(14, 110);
            this.label_out.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_out.Name = "label_out";
            this.label_out.Size = new System.Drawing.Size(620, 18);
            this.label_out.TabIndex = 126;
            this.label_out.Text = "输出文件将存放在重复元件位置信息所在文件夹，以“分布-”+原文件名命名";
            // 
            // button_SelectFile2
            // 
            this.button_SelectFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile2.Location = new System.Drawing.Point(992, 58);
            this.button_SelectFile2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_SelectFile2.Name = "button_SelectFile2";
            this.button_SelectFile2.Size = new System.Drawing.Size(235, 35);
            this.button_SelectFile2.TabIndex = 134;
            this.button_SelectFile2.Text = "选择文件2";
            this.button_SelectFile2.UseVisualStyleBackColor = true;
            this.button_SelectFile2.Click += new System.EventHandler(this.button_SelectFile2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 132;
            this.label2.Text = "重复元件位置信息";
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start.Location = new System.Drawing.Point(992, 102);
            this.button_Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(235, 83);
            this.button_Start.TabIndex = 130;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // label_author
            // 
            this.label_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_author.AutoSize = true;
            this.label_author.Location = new System.Drawing.Point(1062, 234);
            this.label_author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(170, 18);
            this.label_author.TabIndex = 131;
            this.label_author.Text = "by 大肥 2017.02.14";
            // 
            // richTextBox_Info
            // 
            this.richTextBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Info.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox_Info.Location = new System.Drawing.Point(16, 256);
            this.richTextBox_Info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox_Info.Name = "richTextBox_Info";
            this.richTextBox_Info.ReadOnly = true;
            this.richTextBox_Info.Size = new System.Drawing.Size(1213, 257);
            this.richTextBox_Info.TabIndex = 129;
            this.richTextBox_Info.Text = "等待开始";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 528);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_SelectFile1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label_out);
            this.Controls.Add(this.button_SelectFile2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.label_author);
            this.Controls.Add(this.richTextBox_Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动处理数据-13 根据pseudogene最近的TSS计算重复元件表覆盖数量分布";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_SelectFile1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label_out;
        private System.Windows.Forms.Button button_SelectFile2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.RichTextBox richTextBox_Info;
    }
}

