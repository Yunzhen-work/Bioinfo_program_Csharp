namespace 自动处理数据_1
{
    partial class 自动处理数据
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
                if (fs_read != null)
                    fs_read.Close();
                if (fs_write != null)
                    fs_write.Close();
            }
            fs_read = null;
            fs_write = null;
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LockSheet = new System.Windows.Forms.Button();
            this.label_SelectSheetToImport = new System.Windows.Forms.Label();
            this.comboBox_SelectedSheetToImport = new System.Windows.Forms.ComboBox();
            this.textBox_SelectedFileToImport = new System.Windows.Forms.TextBox();
            this.button_SelectFileToImport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_SelectedPositionToQuery = new System.Windows.Forms.ComboBox();
            this.button_OpenQueryURL = new System.Windows.Forms.Button();
            this.textBox_QueryURL = new System.Windows.Forms.TextBox();
            this.label_QueryURL = new System.Windows.Forms.Label();
            this.button_CopyQueryCommand = new System.Windows.Forms.Button();
            this.textBox_QueryCommandOfSelectedGene = new System.Windows.Forms.TextBox();
            this.label_QueryCommandOfSelectedGene = new System.Windows.Forms.Label();
            this.comboBox_SelectedGeneToQuery = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_ImportQueryDataFromClipboard = new System.Windows.Forms.Button();
            this.button_DeleteAllData = new System.Windows.Forms.Button();
            this.button_DeleteSelectedData = new System.Windows.Forms.Button();
            this.label_ImportedAndProcessedData = new System.Windows.Forms.Label();
            this.listBox_ImportedAndProcessedData = new System.Windows.Forms.ListBox();
            this.button_ExportDataToExcel = new System.Windows.Forms.Button();
            this.button_ImportQueryDataFromExcel = new System.Windows.Forms.Button();
            this.panel_Waiting = new System.Windows.Forms.Panel();
            this.label_WaitingText2 = new System.Windows.Forms.Label();
            this.label_WaitingText1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_SkipCurrentPosition = new System.Windows.Forms.Button();
            this.button_ChangeHandlingMode = new System.Windows.Forms.Button();
            this.button_StopAutoHandling = new System.Windows.Forms.Button();
            this.button_AutoHandle = new System.Windows.Forms.Button();
            this.button_ChangeCheckBox = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button_AutoRead = new System.Windows.Forms.Button();
            this.button_Navigate = new System.Windows.Forms.Button();
            this.textBox_URL = new System.Windows.Forms.TextBox();
            this.button_AutoQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer_AutoReadLatterHalf = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel_Waiting.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_LockSheet);
            this.groupBox1.Controls.Add(this.label_SelectSheetToImport);
            this.groupBox1.Controls.Add(this.comboBox_SelectedSheetToImport);
            this.groupBox1.Controls.Add(this.textBox_SelectedFileToImport);
            this.groupBox1.Controls.Add(this.button_SelectFileToImport);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1365, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1、选择假基因位点文件和表格";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择文件：";
            // 
            // button_LockSheet
            // 
            this.button_LockSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LockSheet.Location = new System.Drawing.Point(1197, 70);
            this.button_LockSheet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_LockSheet.Name = "button_LockSheet";
            this.button_LockSheet.Size = new System.Drawing.Size(159, 34);
            this.button_LockSheet.TabIndex = 4;
            this.button_LockSheet.Text = "锁定/解锁表";
            this.button_LockSheet.UseVisualStyleBackColor = true;
            this.button_LockSheet.Click += new System.EventHandler(this.button_LockSheet_Click);
            // 
            // label_SelectSheetToImport
            // 
            this.label_SelectSheetToImport.AutoSize = true;
            this.label_SelectSheetToImport.Location = new System.Drawing.Point(26, 78);
            this.label_SelectSheetToImport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_SelectSheetToImport.Name = "label_SelectSheetToImport";
            this.label_SelectSheetToImport.Size = new System.Drawing.Size(98, 18);
            this.label_SelectSheetToImport.TabIndex = 3;
            this.label_SelectSheetToImport.Text = "选择表格：";
            // 
            // comboBox_SelectedSheetToImport
            // 
            this.comboBox_SelectedSheetToImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_SelectedSheetToImport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SelectedSheetToImport.FormattingEnabled = true;
            this.comboBox_SelectedSheetToImport.Location = new System.Drawing.Point(134, 74);
            this.comboBox_SelectedSheetToImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_SelectedSheetToImport.Name = "comboBox_SelectedSheetToImport";
            this.comboBox_SelectedSheetToImport.Size = new System.Drawing.Size(1052, 26);
            this.comboBox_SelectedSheetToImport.TabIndex = 2;
            this.comboBox_SelectedSheetToImport.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedSheetToImport_SelectedIndexChanged);
            // 
            // textBox_SelectedFileToImport
            // 
            this.textBox_SelectedFileToImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SelectedFileToImport.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_SelectedFileToImport.Location = new System.Drawing.Point(134, 30);
            this.textBox_SelectedFileToImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_SelectedFileToImport.Name = "textBox_SelectedFileToImport";
            this.textBox_SelectedFileToImport.ReadOnly = true;
            this.textBox_SelectedFileToImport.Size = new System.Drawing.Size(1052, 28);
            this.textBox_SelectedFileToImport.TabIndex = 1;
            // 
            // button_SelectFileToImport
            // 
            this.button_SelectFileToImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SelectFileToImport.Location = new System.Drawing.Point(1197, 27);
            this.button_SelectFileToImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SelectFileToImport.Name = "button_SelectFileToImport";
            this.button_SelectFileToImport.Size = new System.Drawing.Size(159, 34);
            this.button_SelectFileToImport.TabIndex = 0;
            this.button_SelectFileToImport.Text = "打开文件";
            this.button_SelectFileToImport.UseVisualStyleBackColor = true;
            this.button_SelectFileToImport.Click += new System.EventHandler(this.button_SelectFileToImport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBox_SelectedPositionToQuery);
            this.groupBox2.Controls.Add(this.button_OpenQueryURL);
            this.groupBox2.Controls.Add(this.textBox_QueryURL);
            this.groupBox2.Controls.Add(this.label_QueryURL);
            this.groupBox2.Controls.Add(this.button_CopyQueryCommand);
            this.groupBox2.Controls.Add(this.textBox_QueryCommandOfSelectedGene);
            this.groupBox2.Controls.Add(this.label_QueryCommandOfSelectedGene);
            this.groupBox2.Controls.Add(this.comboBox_SelectedGeneToQuery);
            this.groupBox2.Location = new System.Drawing.Point(18, 141);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1365, 114);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2、选择染色体位置";
            // 
            // comboBox_SelectedPositionToQuery
            // 
            this.comboBox_SelectedPositionToQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SelectedPositionToQuery.FormattingEnabled = true;
            this.comboBox_SelectedPositionToQuery.Location = new System.Drawing.Point(150, 30);
            this.comboBox_SelectedPositionToQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_SelectedPositionToQuery.Name = "comboBox_SelectedPositionToQuery";
            this.comboBox_SelectedPositionToQuery.Size = new System.Drawing.Size(268, 26);
            this.comboBox_SelectedPositionToQuery.TabIndex = 1;
            this.comboBox_SelectedPositionToQuery.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedPositionToQuery_SelectedIndexChanged);
            // 
            // button_OpenQueryURL
            // 
            this.button_OpenQueryURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OpenQueryURL.Location = new System.Drawing.Point(1197, 70);
            this.button_OpenQueryURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_OpenQueryURL.Name = "button_OpenQueryURL";
            this.button_OpenQueryURL.Size = new System.Drawing.Size(159, 34);
            this.button_OpenQueryURL.TabIndex = 5;
            this.button_OpenQueryURL.Text = "打开查询网址";
            this.button_OpenQueryURL.UseVisualStyleBackColor = true;
            this.button_OpenQueryURL.Click += new System.EventHandler(this.button_OpenQueryURL_Click);
            // 
            // textBox_QueryURL
            // 
            this.textBox_QueryURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_QueryURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_QueryURL.Location = new System.Drawing.Point(152, 78);
            this.textBox_QueryURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_QueryURL.MaxLength = 50000;
            this.textBox_QueryURL.Name = "textBox_QueryURL";
            this.textBox_QueryURL.ReadOnly = true;
            this.textBox_QueryURL.Size = new System.Drawing.Size(1036, 21);
            this.textBox_QueryURL.TabIndex = 4;
            this.textBox_QueryURL.Text = "http://ibl.mdanderson.org/tanric/_design/basic/query.html";
            this.textBox_QueryURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_QueryURL
            // 
            this.label_QueryURL.AutoSize = true;
            this.label_QueryURL.Location = new System.Drawing.Point(45, 76);
            this.label_QueryURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_QueryURL.Name = "label_QueryURL";
            this.label_QueryURL.Size = new System.Drawing.Size(98, 18);
            this.label_QueryURL.TabIndex = 6;
            this.label_QueryURL.Text = "查询网址：";
            // 
            // button_CopyQueryCommand
            // 
            this.button_CopyQueryCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CopyQueryCommand.Location = new System.Drawing.Point(1197, 27);
            this.button_CopyQueryCommand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_CopyQueryCommand.Name = "button_CopyQueryCommand";
            this.button_CopyQueryCommand.Size = new System.Drawing.Size(159, 34);
            this.button_CopyQueryCommand.TabIndex = 3;
            this.button_CopyQueryCommand.Text = "复制查询命令";
            this.button_CopyQueryCommand.UseVisualStyleBackColor = true;
            this.button_CopyQueryCommand.Click += new System.EventHandler(this.button_CopyQueryCommand_Click);
            // 
            // textBox_QueryCommandOfSelectedGene
            // 
            this.textBox_QueryCommandOfSelectedGene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_QueryCommandOfSelectedGene.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_QueryCommandOfSelectedGene.Location = new System.Drawing.Point(585, 30);
            this.textBox_QueryCommandOfSelectedGene.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_QueryCommandOfSelectedGene.MaxLength = 50000;
            this.textBox_QueryCommandOfSelectedGene.Name = "textBox_QueryCommandOfSelectedGene";
            this.textBox_QueryCommandOfSelectedGene.ReadOnly = true;
            this.textBox_QueryCommandOfSelectedGene.Size = new System.Drawing.Size(601, 28);
            this.textBox_QueryCommandOfSelectedGene.TabIndex = 2;
            // 
            // label_QueryCommandOfSelectedGene
            // 
            this.label_QueryCommandOfSelectedGene.AutoSize = true;
            this.label_QueryCommandOfSelectedGene.Location = new System.Drawing.Point(442, 36);
            this.label_QueryCommandOfSelectedGene.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_QueryCommandOfSelectedGene.Name = "label_QueryCommandOfSelectedGene";
            this.label_QueryCommandOfSelectedGene.Size = new System.Drawing.Size(134, 18);
            this.label_QueryCommandOfSelectedGene.TabIndex = 7;
            this.label_QueryCommandOfSelectedGene.Text = "对应查询命令：";
            // 
            // comboBox_SelectedGeneToQuery
            // 
            this.comboBox_SelectedGeneToQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SelectedGeneToQuery.FormattingEnabled = true;
            this.comboBox_SelectedGeneToQuery.Location = new System.Drawing.Point(9, 30);
            this.comboBox_SelectedGeneToQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_SelectedGeneToQuery.Name = "comboBox_SelectedGeneToQuery";
            this.comboBox_SelectedGeneToQuery.Size = new System.Drawing.Size(130, 26);
            this.comboBox_SelectedGeneToQuery.TabIndex = 0;
            this.comboBox_SelectedGeneToQuery.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedGeneToQuery_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button_ImportQueryDataFromClipboard);
            this.groupBox3.Controls.Add(this.button_DeleteAllData);
            this.groupBox3.Controls.Add(this.button_DeleteSelectedData);
            this.groupBox3.Controls.Add(this.label_ImportedAndProcessedData);
            this.groupBox3.Controls.Add(this.listBox_ImportedAndProcessedData);
            this.groupBox3.Controls.Add(this.button_ExportDataToExcel);
            this.groupBox3.Controls.Add(this.button_ImportQueryDataFromExcel);
            this.groupBox3.Location = new System.Drawing.Point(18, 264);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1365, 207);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3、导入查询网址中的数据";
            // 
            // button_ImportQueryDataFromClipboard
            // 
            this.button_ImportQueryDataFromClipboard.Location = new System.Drawing.Point(9, 74);
            this.button_ImportQueryDataFromClipboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ImportQueryDataFromClipboard.Name = "button_ImportQueryDataFromClipboard";
            this.button_ImportQueryDataFromClipboard.Size = new System.Drawing.Size(308, 34);
            this.button_ImportQueryDataFromClipboard.TabIndex = 1;
            this.button_ImportQueryDataFromClipboard.Text = "导入剪贴板数据";
            this.button_ImportQueryDataFromClipboard.UseVisualStyleBackColor = true;
            this.button_ImportQueryDataFromClipboard.Click += new System.EventHandler(this.button_ImportQueryDataFromClipboard_Click);
            // 
            // button_DeleteAllData
            // 
            this.button_DeleteAllData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_DeleteAllData.Location = new System.Drawing.Point(9, 160);
            this.button_DeleteAllData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_DeleteAllData.Name = "button_DeleteAllData";
            this.button_DeleteAllData.Size = new System.Drawing.Size(308, 34);
            this.button_DeleteAllData.TabIndex = 3;
            this.button_DeleteAllData.Text = "清除所有数据";
            this.button_DeleteAllData.UseVisualStyleBackColor = true;
            this.button_DeleteAllData.Click += new System.EventHandler(this.button_DeleteAllData_Click);
            // 
            // button_DeleteSelectedData
            // 
            this.button_DeleteSelectedData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_DeleteSelectedData.Location = new System.Drawing.Point(9, 117);
            this.button_DeleteSelectedData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_DeleteSelectedData.Name = "button_DeleteSelectedData";
            this.button_DeleteSelectedData.Size = new System.Drawing.Size(308, 34);
            this.button_DeleteSelectedData.TabIndex = 2;
            this.button_DeleteSelectedData.Text = "清除选定数据";
            this.button_DeleteSelectedData.UseVisualStyleBackColor = true;
            this.button_DeleteSelectedData.Click += new System.EventHandler(this.button_DeleteSelectedData_Click);
            // 
            // label_ImportedAndProcessedData
            // 
            this.label_ImportedAndProcessedData.AutoSize = true;
            this.label_ImportedAndProcessedData.Location = new System.Drawing.Point(388, 38);
            this.label_ImportedAndProcessedData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ImportedAndProcessedData.Name = "label_ImportedAndProcessedData";
            this.label_ImportedAndProcessedData.Size = new System.Drawing.Size(188, 18);
            this.label_ImportedAndProcessedData.TabIndex = 3;
            this.label_ImportedAndProcessedData.Text = "已导入并处理的数据：";
            // 
            // listBox_ImportedAndProcessedData
            // 
            this.listBox_ImportedAndProcessedData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_ImportedAndProcessedData.FormattingEnabled = true;
            this.listBox_ImportedAndProcessedData.ItemHeight = 18;
            this.listBox_ImportedAndProcessedData.Location = new System.Drawing.Point(585, 30);
            this.listBox_ImportedAndProcessedData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox_ImportedAndProcessedData.Name = "listBox_ImportedAndProcessedData";
            this.listBox_ImportedAndProcessedData.Size = new System.Drawing.Size(601, 148);
            this.listBox_ImportedAndProcessedData.TabIndex = 4;
            // 
            // button_ExportDataToExcel
            // 
            this.button_ExportDataToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ExportDataToExcel.Location = new System.Drawing.Point(1197, 30);
            this.button_ExportDataToExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ExportDataToExcel.Name = "button_ExportDataToExcel";
            this.button_ExportDataToExcel.Size = new System.Drawing.Size(159, 150);
            this.button_ExportDataToExcel.TabIndex = 5;
            this.button_ExportDataToExcel.Text = "导出到Excel";
            this.button_ExportDataToExcel.UseVisualStyleBackColor = true;
            this.button_ExportDataToExcel.Click += new System.EventHandler(this.button_ExportDataToExcel_Click);
            // 
            // button_ImportQueryDataFromExcel
            // 
            this.button_ImportQueryDataFromExcel.Location = new System.Drawing.Point(9, 27);
            this.button_ImportQueryDataFromExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ImportQueryDataFromExcel.Name = "button_ImportQueryDataFromExcel";
            this.button_ImportQueryDataFromExcel.Size = new System.Drawing.Size(308, 34);
            this.button_ImportQueryDataFromExcel.TabIndex = 0;
            this.button_ImportQueryDataFromExcel.Text = "导入之前保存的Excel数据";
            this.button_ImportQueryDataFromExcel.UseVisualStyleBackColor = true;
            this.button_ImportQueryDataFromExcel.Click += new System.EventHandler(this.button_ImportQueryDataFromExcel_Click);
            // 
            // panel_Waiting
            // 
            this.panel_Waiting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_Waiting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Waiting.Controls.Add(this.label_WaitingText2);
            this.panel_Waiting.Controls.Add(this.label_WaitingText1);
            this.panel_Waiting.Location = new System.Drawing.Point(152, 237);
            this.panel_Waiting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_Waiting.Name = "panel_Waiting";
            this.panel_Waiting.Size = new System.Drawing.Size(1100, 144);
            this.panel_Waiting.TabIndex = 8;
            this.panel_Waiting.Visible = false;
            // 
            // label_WaitingText2
            // 
            this.label_WaitingText2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_WaitingText2.AutoSize = true;
            this.label_WaitingText2.Location = new System.Drawing.Point(447, 69);
            this.label_WaitingText2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_WaitingText2.Name = "label_WaitingText2";
            this.label_WaitingText2.Size = new System.Drawing.Size(62, 18);
            this.label_WaitingText2.TabIndex = 1;
            this.label_WaitingText2.Text = "label2";
            // 
            // label_WaitingText1
            // 
            this.label_WaitingText1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_WaitingText1.AutoSize = true;
            this.label_WaitingText1.Location = new System.Drawing.Point(447, 51);
            this.label_WaitingText1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_WaitingText1.Name = "label_WaitingText1";
            this.label_WaitingText1.Size = new System.Drawing.Size(224, 18);
            this.label_WaitingText1.TabIndex = 0;
            this.label_WaitingText1.Text = "正在处理数据，请稍后……";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.button_SkipCurrentPosition);
            this.groupBox4.Controls.Add(this.button_ChangeHandlingMode);
            this.groupBox4.Controls.Add(this.button_StopAutoHandling);
            this.groupBox4.Controls.Add(this.button_AutoHandle);
            this.groupBox4.Controls.Add(this.button_ChangeCheckBox);
            this.groupBox4.Controls.Add(this.webBrowser1);
            this.groupBox4.Controls.Add(this.button_AutoRead);
            this.groupBox4.Controls.Add(this.button_Navigate);
            this.groupBox4.Controls.Add(this.textBox_URL);
            this.groupBox4.Controls.Add(this.button_AutoQuery);
            this.groupBox4.Location = new System.Drawing.Point(18, 480);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(1365, 552);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4、自动处理数据";
            // 
            // button_SkipCurrentPosition
            // 
            this.button_SkipCurrentPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SkipCurrentPosition.Location = new System.Drawing.Point(897, 74);
            this.button_SkipCurrentPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_SkipCurrentPosition.Name = "button_SkipCurrentPosition";
            this.button_SkipCurrentPosition.Size = new System.Drawing.Size(291, 34);
            this.button_SkipCurrentPosition.TabIndex = 9;
            this.button_SkipCurrentPosition.Text = "忽略这一项";
            this.button_SkipCurrentPosition.UseVisualStyleBackColor = true;
            this.button_SkipCurrentPosition.Click += new System.EventHandler(this.button_Skip_Click);
            // 
            // button_ChangeHandlingMode
            // 
            this.button_ChangeHandlingMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ChangeHandlingMode.Location = new System.Drawing.Point(1197, 74);
            this.button_ChangeHandlingMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ChangeHandlingMode.Name = "button_ChangeHandlingMode";
            this.button_ChangeHandlingMode.Size = new System.Drawing.Size(159, 34);
            this.button_ChangeHandlingMode.TabIndex = 4;
            this.button_ChangeHandlingMode.Text = "切换自动/手动";
            this.button_ChangeHandlingMode.UseVisualStyleBackColor = true;
            this.button_ChangeHandlingMode.Click += new System.EventHandler(this.button_ChangeHandlingMode_Click);
            // 
            // button_StopAutoHandling
            // 
            this.button_StopAutoHandling.Location = new System.Drawing.Point(9, 74);
            this.button_StopAutoHandling.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_StopAutoHandling.Name = "button_StopAutoHandling";
            this.button_StopAutoHandling.Size = new System.Drawing.Size(308, 34);
            this.button_StopAutoHandling.TabIndex = 1;
            this.button_StopAutoHandling.Text = "停止自动处理";
            this.button_StopAutoHandling.UseVisualStyleBackColor = true;
            this.button_StopAutoHandling.Click += new System.EventHandler(this.button_StopAutoHandling_Click);
            // 
            // button_AutoHandle
            // 
            this.button_AutoHandle.Location = new System.Drawing.Point(9, 30);
            this.button_AutoHandle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_AutoHandle.Name = "button_AutoHandle";
            this.button_AutoHandle.Size = new System.Drawing.Size(308, 34);
            this.button_AutoHandle.TabIndex = 0;
            this.button_AutoHandle.Text = "自动查询并导入（整个表）";
            this.button_AutoHandle.UseVisualStyleBackColor = true;
            this.button_AutoHandle.Click += new System.EventHandler(this.button_AutoHandle_Click);
            // 
            // button_ChangeCheckBox
            // 
            this.button_ChangeCheckBox.Location = new System.Drawing.Point(362, 74);
            this.button_ChangeCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ChangeCheckBox.Name = "button_ChangeCheckBox";
            this.button_ChangeCheckBox.Size = new System.Drawing.Size(291, 34);
            this.button_ChangeCheckBox.TabIndex = 5;
            this.button_ChangeCheckBox.Text = "选择/取消所有选框";
            this.button_ChangeCheckBox.UseVisualStyleBackColor = true;
            this.button_ChangeCheckBox.Click += new System.EventHandler(this.button_ChangeCheckBox_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(10, 117);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(30, 30);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(1346, 426);
            this.webBrowser1.TabIndex = 8;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // button_AutoRead
            // 
            this.button_AutoRead.Location = new System.Drawing.Point(9, 74);
            this.button_AutoRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_AutoRead.Name = "button_AutoRead";
            this.button_AutoRead.Size = new System.Drawing.Size(308, 34);
            this.button_AutoRead.TabIndex = 7;
            this.button_AutoRead.Text = "导入查询数据";
            this.button_AutoRead.UseVisualStyleBackColor = true;
            this.button_AutoRead.Click += new System.EventHandler(this.button_AutoRead_Click);
            // 
            // button_Navigate
            // 
            this.button_Navigate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Navigate.Location = new System.Drawing.Point(1197, 30);
            this.button_Navigate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Navigate.Name = "button_Navigate";
            this.button_Navigate.Size = new System.Drawing.Size(159, 34);
            this.button_Navigate.TabIndex = 3;
            this.button_Navigate.Text = "打开网页";
            this.button_Navigate.UseVisualStyleBackColor = true;
            this.button_Navigate.Click += new System.EventHandler(this.button_Navigate_Click);
            // 
            // textBox_URL
            // 
            this.textBox_URL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_URL.Location = new System.Drawing.Point(362, 33);
            this.textBox_URL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_URL.Name = "textBox_URL";
            this.textBox_URL.Size = new System.Drawing.Size(824, 28);
            this.textBox_URL.TabIndex = 2;
            this.textBox_URL.Text = "http://ibl.mdanderson.org/tanric/_design/basic/query.html";
            // 
            // button_AutoQuery
            // 
            this.button_AutoQuery.Location = new System.Drawing.Point(9, 30);
            this.button_AutoQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_AutoQuery.Name = "button_AutoQuery";
            this.button_AutoQuery.Size = new System.Drawing.Size(308, 34);
            this.button_AutoQuery.TabIndex = 6;
            this.button_AutoQuery.Text = "执行当前查询命令";
            this.button_AutoQuery.UseVisualStyleBackColor = true;
            this.button_AutoQuery.Click += new System.EventHandler(this.button_AutoQuery_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1214, 1036);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "by 大肥 2015.11.28";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer_AutoReadLatterHalf
            // 
            this.timer_AutoReadLatterHalf.Interval = 2000;
            this.timer_AutoReadLatterHalf.Tick += new System.EventHandler(this.timer_AutoReadLatterHalf_Tick);
            // 
            // 自动处理数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 1068);
            this.Controls.Add(this.panel_Waiting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "自动处理数据";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动处理数据 v0.42";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel_Waiting.ResumeLayout(false);
            this.panel_Waiting.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_SelectSheetToImport;
        private System.Windows.Forms.ComboBox comboBox_SelectedSheetToImport;
        private System.Windows.Forms.TextBox textBox_SelectedFileToImport;
        private System.Windows.Forms.Button button_SelectFileToImport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_SelectedGeneToQuery;
        private System.Windows.Forms.Button button_CopyQueryCommand;
        private System.Windows.Forms.TextBox textBox_QueryCommandOfSelectedGene;
        private System.Windows.Forms.Label label_QueryCommandOfSelectedGene;
        private System.Windows.Forms.Button button_OpenQueryURL;
        private System.Windows.Forms.TextBox textBox_QueryURL;
        private System.Windows.Forms.Label label_QueryURL;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_ImportQueryDataFromExcel;
        private System.Windows.Forms.Button button_ImportQueryDataFromClipboard;
        private System.Windows.Forms.Button button_DeleteAllData;
        private System.Windows.Forms.Button button_DeleteSelectedData;
        private System.Windows.Forms.Label label_ImportedAndProcessedData;
        private System.Windows.Forms.ListBox listBox_ImportedAndProcessedData;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_ExportDataToExcel;
        private System.Windows.Forms.Panel panel_Waiting;
        private System.Windows.Forms.Label label_WaitingText1;
        private System.Windows.Forms.Button button_LockSheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_SelectedPositionToQuery;
        private System.Windows.Forms.Button button_AutoQuery;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.Button button_Navigate;
        private System.Windows.Forms.Button button_AutoRead;
        private System.Windows.Forms.Button button_ChangeCheckBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_AutoHandle;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button_StopAutoHandling;
        private System.Windows.Forms.Button button_ChangeHandlingMode;
        private System.Windows.Forms.Label label_WaitingText2;
        private System.Windows.Forms.Timer timer_AutoReadLatterHalf;
        private System.Windows.Forms.Button button_SkipCurrentPosition;
    }
}

