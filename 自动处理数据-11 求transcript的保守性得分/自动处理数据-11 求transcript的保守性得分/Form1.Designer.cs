namespace 自动处理数据_11_求transcript的保守性得分
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
            this.components = new System.ComponentModel.Container();
            this.label_author = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.richTextBox_Info = new System.Windows.Forms.RichTextBox();
            this.textBox_OutputFile = new System.Windows.Forms.TextBox();
            this.button_SelectOutputFile = new System.Windows.Forms.Button();
            this.label_out = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_SelectFile1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button_SelectFile2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.checkBox_exon = new System.Windows.Forms.CheckBox();
            this.checkBox_CDS = new System.Windows.Forms.CheckBox();
            this.checkBox_UTR = new System.Windows.Forms.CheckBox();
            this.checkBox_start_codon = new System.Windows.Forms.CheckBox();
            this.checkBox_stop_codon = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button_SelectFile3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_T2_SelectFile1 = new System.Windows.Forms.Button();
            this.textBox_T2_1 = new System.Windows.Forms.TextBox();
            this.textBox_T2_2 = new System.Windows.Forms.TextBox();
            this.label_T2_out = new System.Windows.Forms.Label();
            this.button_T2_SelectFile2 = new System.Windows.Forms.Button();
            this.button_T2_SelectOutputFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_T2_OutputFile = new System.Windows.Forms.TextBox();
            this.button_T2_Start = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_author
            // 
            this.label_author.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_author.AutoSize = true;
            this.label_author.Location = new System.Drawing.Point(1060, 685);
            this.label_author.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(170, 18);
            this.label_author.TabIndex = 105;
            this.label_author.Text = "by 大肥 2018.12.13";
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Start.Location = new System.Drawing.Point(984, 190);
            this.button_Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(235, 83);
            this.button_Start.TabIndex = 104;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // richTextBox_Info
            // 
            this.richTextBox_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Info.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox_Info.Location = new System.Drawing.Point(14, 707);
            this.richTextBox_Info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox_Info.Name = "richTextBox_Info";
            this.richTextBox_Info.ReadOnly = true;
            this.richTextBox_Info.Size = new System.Drawing.Size(1213, 257);
            this.richTextBox_Info.TabIndex = 103;
            this.richTextBox_Info.Text = "等待开始\n\n之前文件夹名字太长，总是调试失败，改短后就好了_(:3」∠)_\n加入了文件的提示，鼠标移到上面的label上就能看到(｀･ω･´) \n";
            // 
            // textBox_OutputFile
            // 
            this.textBox_OutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_OutputFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_OutputFile.Location = new System.Drawing.Point(205, 148);
            this.textBox_OutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_OutputFile.Name = "textBox_OutputFile";
            this.textBox_OutputFile.ReadOnly = true;
            this.textBox_OutputFile.Size = new System.Drawing.Size(770, 28);
            this.textBox_OutputFile.TabIndex = 101;
            // 
            // button_SelectOutputFile
            // 
            this.button_SelectOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectOutputFile.Location = new System.Drawing.Point(984, 145);
            this.button_SelectOutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_SelectOutputFile.Name = "button_SelectOutputFile";
            this.button_SelectOutputFile.Size = new System.Drawing.Size(235, 35);
            this.button_SelectOutputFile.TabIndex = 102;
            this.button_SelectOutputFile.Text = "选择输出文件";
            this.button_SelectOutputFile.UseVisualStyleBackColor = true;
            this.button_SelectOutputFile.Click += new System.EventHandler(this.button_SelectOutputFile_Click);
            // 
            // label_out
            // 
            this.label_out.AutoSize = true;
            this.label_out.Location = new System.Drawing.Point(11, 154);
            this.label_out.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_out.Name = "label_out";
            this.label_out.Size = new System.Drawing.Size(80, 18);
            this.label_out.TabIndex = 100;
            this.label_out.Text = "输出文件";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(205, 14);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(770, 28);
            this.textBox1.TabIndex = 98;
            // 
            // button_SelectFile1
            // 
            this.button_SelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile1.Location = new System.Drawing.Point(984, 12);
            this.button_SelectFile1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_SelectFile1.Name = "button_SelectFile1";
            this.button_SelectFile1.Size = new System.Drawing.Size(235, 35);
            this.button_SelectFile1.TabIndex = 99;
            this.button_SelectFile1.Text = "选择文件1";
            this.button_SelectFile1.UseVisualStyleBackColor = true;
            this.button_SelectFile1.Click += new System.EventHandler(this.button_SelectFile1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 18);
            this.label1.TabIndex = 97;
            this.label1.Text = "已分类annotation文件";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Location = new System.Drawing.Point(205, 59);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(770, 28);
            this.textBox2.TabIndex = 107;
            // 
            // button_SelectFile2
            // 
            this.button_SelectFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile2.Location = new System.Drawing.Point(984, 56);
            this.button_SelectFile2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_SelectFile2.Name = "button_SelectFile2";
            this.button_SelectFile2.Size = new System.Drawing.Size(235, 35);
            this.button_SelectFile2.TabIndex = 108;
            this.button_SelectFile2.Text = "选择文件2";
            this.button_SelectFile2.UseVisualStyleBackColor = true;
            this.button_SelectFile2.Click += new System.EventHandler(this.button_SelectFile2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 106;
            this.label2.Text = "保守性分数文件";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(22, 29);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(267, 22);
            this.radioButton1.TabIndex = 109;
            this.radioButton1.Text = "输出所有信息，按transcript";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(22, 59);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(591, 22);
            this.radioButton2.TabIndex = 110;
            this.radioButton2.Text = "仅输出类型和得分（类型名由annotation文件名决定），按transcript";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(22, 89);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(537, 22);
            this.radioButton3.TabIndex = 111;
            this.radioButton3.Text = "仅输出类型和得分（类型名由annotation文件名决定），按exon";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // checkBox_exon
            // 
            this.checkBox_exon.AutoSize = true;
            this.checkBox_exon.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox_exon.Checked = true;
            this.checkBox_exon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_exon.Enabled = false;
            this.checkBox_exon.Location = new System.Drawing.Point(22, 29);
            this.checkBox_exon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_exon.Name = "checkBox_exon";
            this.checkBox_exon.Size = new System.Drawing.Size(70, 22);
            this.checkBox_exon.TabIndex = 112;
            this.checkBox_exon.Text = "exon";
            this.checkBox_exon.UseVisualStyleBackColor = false;
            // 
            // checkBox_CDS
            // 
            this.checkBox_CDS.AutoSize = true;
            this.checkBox_CDS.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox_CDS.Enabled = false;
            this.checkBox_CDS.Location = new System.Drawing.Point(98, 29);
            this.checkBox_CDS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_CDS.Name = "checkBox_CDS";
            this.checkBox_CDS.Size = new System.Drawing.Size(61, 22);
            this.checkBox_CDS.TabIndex = 113;
            this.checkBox_CDS.Text = "CDS";
            this.checkBox_CDS.UseVisualStyleBackColor = false;
            // 
            // checkBox_UTR
            // 
            this.checkBox_UTR.AutoSize = true;
            this.checkBox_UTR.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox_UTR.Enabled = false;
            this.checkBox_UTR.Location = new System.Drawing.Point(164, 29);
            this.checkBox_UTR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_UTR.Name = "checkBox_UTR";
            this.checkBox_UTR.Size = new System.Drawing.Size(61, 22);
            this.checkBox_UTR.TabIndex = 114;
            this.checkBox_UTR.Text = "UTR";
            this.checkBox_UTR.UseVisualStyleBackColor = false;
            // 
            // checkBox_start_codon
            // 
            this.checkBox_start_codon.AutoSize = true;
            this.checkBox_start_codon.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox_start_codon.Enabled = false;
            this.checkBox_start_codon.Location = new System.Drawing.Point(231, 29);
            this.checkBox_start_codon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_start_codon.Name = "checkBox_start_codon";
            this.checkBox_start_codon.Size = new System.Drawing.Size(133, 22);
            this.checkBox_start_codon.TabIndex = 115;
            this.checkBox_start_codon.Text = "start_codon";
            this.checkBox_start_codon.UseVisualStyleBackColor = false;
            // 
            // checkBox_stop_codon
            // 
            this.checkBox_stop_codon.AutoSize = true;
            this.checkBox_stop_codon.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox_stop_codon.Enabled = false;
            this.checkBox_stop_codon.Location = new System.Drawing.Point(369, 29);
            this.checkBox_stop_codon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_stop_codon.Name = "checkBox_stop_codon";
            this.checkBox_stop_codon.Size = new System.Drawing.Size(124, 22);
            this.checkBox_stop_codon.TabIndex = 116;
            this.checkBox_stop_codon.Text = "stop_codon";
            this.checkBox_stop_codon.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton9);
            this.groupBox1.Controls.Add(this.radioButton8);
            this.groupBox1.Controls.Add(this.radioButton7);
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Location = new System.Drawing.Point(205, 190);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(771, 358);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输出信息选择";
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(22, 301);
            this.radioButton9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(375, 22);
            this.radioButton9.TabIndex = 117;
            this.radioButton9.Text = "计算Tab2中所得结果中每个gene下exon数目";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(22, 271);
            this.radioButton8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(339, 22);
            this.radioButton8.TabIndex = 116;
            this.radioButton8.Text = "计算annotation中每个gene下exon数目";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(22, 229);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(456, 22);
            this.radioButton7.TabIndex = 115;
            this.radioButton7.Text = "计算Tab2中Pseudo附近找PCG所得结果的得分，按exon";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(22, 199);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(456, 22);
            this.radioButton6.TabIndex = 114;
            this.radioButton6.Text = "计算Tab2中Pseudo附近找PCG所得结果的得分，按gene";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(22, 149);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(537, 22);
            this.radioButton5.TabIndex = 113;
            this.radioButton5.Text = "仅输出类型和得分（类型名由annotation文件名决定），按gene";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(22, 119);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(609, 22);
            this.radioButton4.TabIndex = 112;
            this.radioButton4.Text = "仅输出类型和得分（类型名由annotation文件名决定），按所有SubTypes";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBox_exon);
            this.groupBox2.Controls.Add(this.checkBox_stop_codon);
            this.groupBox2.Controls.Add(this.checkBox_UTR);
            this.groupBox2.Controls.Add(this.checkBox_CDS);
            this.groupBox2.Controls.Add(this.checkBox_start_codon);
            this.groupBox2.Location = new System.Drawing.Point(205, 554);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(771, 62);
            this.groupBox2.TabIndex = 119;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分数包含";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1242, 659);
            this.tabControl1.TabIndex = 120;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.button_SelectFile3);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.button_SelectFile1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label_out);
            this.tabPage1.Controls.Add(this.button_SelectFile2);
            this.tabPage1.Controls.Add(this.button_SelectOutputFile);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox_OutputFile);
            this.tabPage1.Controls.Add(this.button_Start);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(1234, 627);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "计算保守性得分";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(205, 103);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(770, 28);
            this.textBox3.TabIndex = 121;
            // 
            // button_SelectFile3
            // 
            this.button_SelectFile3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFile3.Enabled = false;
            this.button_SelectFile3.Location = new System.Drawing.Point(984, 101);
            this.button_SelectFile3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_SelectFile3.Name = "button_SelectFile3";
            this.button_SelectFile3.Size = new System.Drawing.Size(235, 35);
            this.button_SelectFile3.TabIndex = 122;
            this.button_SelectFile3.Text = "选择文件3";
            this.button_SelectFile3.UseVisualStyleBackColor = true;
            this.button_SelectFile3.Click += new System.EventHandler(this.button_SelectFile3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 109);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 18);
            this.label9.TabIndex = 120;
            this.label9.Text = "Tab2的输出文件";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button_T2_SelectFile1);
            this.tabPage2.Controls.Add(this.textBox_T2_1);
            this.tabPage2.Controls.Add(this.textBox_T2_2);
            this.tabPage2.Controls.Add(this.label_T2_out);
            this.tabPage2.Controls.Add(this.button_T2_SelectFile2);
            this.tabPage2.Controls.Add(this.button_T2_SelectOutputFile);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox_T2_OutputFile);
            this.tabPage2.Controls.Add(this.button_T2_Start);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(1234, 627);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pseudo附近找PCG";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 269);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(872, 18);
            this.label8.TabIndex = 135;
            this.label8.Text = "*数据要求：5列，带表头（chr、start、end、strand、pseudogene或pcg（即名字），全小写），顺序无所谓";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(236, 145);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(739, 83);
            this.groupBox3.TabIndex = 134;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "搜索范围";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 129;
            this.label6.Text = "Pseudogene前";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(296, 29);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(90, 28);
            this.numericUpDown2.TabIndex = 133;
            this.numericUpDown2.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 130;
            this.label4.Text = "kb，后";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(130, 29);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 28);
            this.numericUpDown1.TabIndex = 132;
            this.numericUpDown1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 18);
            this.label7.TabIndex = 131;
            this.label7.Text = "kb";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 119;
            this.label3.Text = "Pseudogene*";
            // 
            // button_T2_SelectFile1
            // 
            this.button_T2_SelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_T2_SelectFile1.Location = new System.Drawing.Point(984, 12);
            this.button_T2_SelectFile1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_T2_SelectFile1.Name = "button_T2_SelectFile1";
            this.button_T2_SelectFile1.Size = new System.Drawing.Size(235, 35);
            this.button_T2_SelectFile1.TabIndex = 121;
            this.button_T2_SelectFile1.Text = "选择文件1";
            this.button_T2_SelectFile1.UseVisualStyleBackColor = true;
            this.button_T2_SelectFile1.Click += new System.EventHandler(this.button_T2_SelectFile1_Click);
            // 
            // textBox_T2_1
            // 
            this.textBox_T2_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_T2_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_T2_1.Location = new System.Drawing.Point(236, 14);
            this.textBox_T2_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_T2_1.Name = "textBox_T2_1";
            this.textBox_T2_1.ReadOnly = true;
            this.textBox_T2_1.Size = new System.Drawing.Size(739, 28);
            this.textBox_T2_1.TabIndex = 120;
            // 
            // textBox_T2_2
            // 
            this.textBox_T2_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_T2_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_T2_2.Location = new System.Drawing.Point(236, 59);
            this.textBox_T2_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_T2_2.Name = "textBox_T2_2";
            this.textBox_T2_2.ReadOnly = true;
            this.textBox_T2_2.Size = new System.Drawing.Size(739, 28);
            this.textBox_T2_2.TabIndex = 127;
            // 
            // label_T2_out
            // 
            this.label_T2_out.AutoSize = true;
            this.label_T2_out.Location = new System.Drawing.Point(11, 109);
            this.label_T2_out.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_T2_out.Name = "label_T2_out";
            this.label_T2_out.Size = new System.Drawing.Size(80, 18);
            this.label_T2_out.TabIndex = 122;
            this.label_T2_out.Text = "输出文件";
            // 
            // button_T2_SelectFile2
            // 
            this.button_T2_SelectFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_T2_SelectFile2.Location = new System.Drawing.Point(984, 56);
            this.button_T2_SelectFile2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_T2_SelectFile2.Name = "button_T2_SelectFile2";
            this.button_T2_SelectFile2.Size = new System.Drawing.Size(235, 35);
            this.button_T2_SelectFile2.TabIndex = 128;
            this.button_T2_SelectFile2.Text = "选择文件2";
            this.button_T2_SelectFile2.UseVisualStyleBackColor = true;
            this.button_T2_SelectFile2.Click += new System.EventHandler(this.button_T2_SelectFile2_Click);
            // 
            // button_T2_SelectOutputFile
            // 
            this.button_T2_SelectOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_T2_SelectOutputFile.Location = new System.Drawing.Point(984, 101);
            this.button_T2_SelectOutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_T2_SelectOutputFile.Name = "button_T2_SelectOutputFile";
            this.button_T2_SelectOutputFile.Size = new System.Drawing.Size(235, 35);
            this.button_T2_SelectOutputFile.TabIndex = 124;
            this.button_T2_SelectOutputFile.Text = "选择输出文件";
            this.button_T2_SelectOutputFile.UseVisualStyleBackColor = true;
            this.button_T2_SelectOutputFile.Click += new System.EventHandler(this.button_T2_SelectOutputFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 18);
            this.label5.TabIndex = 126;
            this.label5.Text = "PCG annotation*";
            // 
            // textBox_T2_OutputFile
            // 
            this.textBox_T2_OutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_T2_OutputFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_T2_OutputFile.Location = new System.Drawing.Point(236, 103);
            this.textBox_T2_OutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_T2_OutputFile.Name = "textBox_T2_OutputFile";
            this.textBox_T2_OutputFile.ReadOnly = true;
            this.textBox_T2_OutputFile.Size = new System.Drawing.Size(739, 28);
            this.textBox_T2_OutputFile.TabIndex = 123;
            // 
            // button_T2_Start
            // 
            this.button_T2_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_T2_Start.Location = new System.Drawing.Point(984, 145);
            this.button_T2_Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_T2_Start.Name = "button_T2_Start";
            this.button_T2_Start.Size = new System.Drawing.Size(235, 83);
            this.button_T2_Start.TabIndex = 125;
            this.button_T2_Start.Text = "开始";
            this.button_T2_Start.UseVisualStyleBackColor = true;
            this.button_T2_Start.Click += new System.EventHandler(this.button_T2_Start_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 980);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_author);
            this.Controls.Add(this.richTextBox_Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动处理数据-11 根据处理的gtf文件和保守性分数文件求保守性得分";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.RichTextBox richTextBox_Info;
        private System.Windows.Forms.TextBox textBox_OutputFile;
        private System.Windows.Forms.Button button_SelectOutputFile;
        private System.Windows.Forms.Label label_out;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_SelectFile1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button_SelectFile2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.CheckBox checkBox_exon;
        private System.Windows.Forms.CheckBox checkBox_CDS;
        private System.Windows.Forms.CheckBox checkBox_UTR;
        private System.Windows.Forms.CheckBox checkBox_start_codon;
        private System.Windows.Forms.CheckBox checkBox_stop_codon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_T2_SelectFile1;
        private System.Windows.Forms.TextBox textBox_T2_1;
        private System.Windows.Forms.TextBox textBox_T2_2;
        private System.Windows.Forms.Label label_T2_out;
        private System.Windows.Forms.Button button_T2_SelectFile2;
        private System.Windows.Forms.Button button_T2_SelectOutputFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_T2_OutputFile;
        private System.Windows.Forms.Button button_T2_Start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button_SelectFile3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

