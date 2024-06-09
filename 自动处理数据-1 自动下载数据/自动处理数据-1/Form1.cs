using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace 自动处理数据_1
{
    public partial class 自动处理数据 : Form
    {
        DataTable dtOnePosition = new DataTable();
        ArrayList dtAllPosition = new ArrayList();
        FileStream fs_read = null, fs_write = null;
        IWorkbook XLSImported = null, XLSExported = null;
        ISheet SelectedSheet = null;
        ArrayList columnHeaders = new ArrayList();
        ArrayList chr = new ArrayList();
        Hashtable chr_Positions = new Hashtable();
        ArrayList skipList = new ArrayList();

        int position_info_NumberOfColumn = 0;
        int currentPositionInChr, currentPositionInTotal, currentChr, totalPositionInOneChr, totalPosition, totalChr;
        int timeToWait = 3, waitingSeconds;
        int timer1Count = 0, timer1TimeOut = 10; //2秒一次Count
        int retryCount = 0;
        bool isOpeningFile = false;
        bool isOpeningSheet = false;
        bool isAddingPositions = false;
        bool isQueryFinished = false;
        bool isCopyed = true;
        bool isChecked = true;

        string status = "Normal"; //Normal、Busy、AutoHandle
        string handlingMode = "Auto"; //Auto、Manual
        public 自动处理数据()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            button_Navigate_Click(button_Navigate, new EventArgs());
            ChangeMode("Normal");
            ChangeHandlingMode("Auto");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("确认保存后再关闭哟！真的要关闭吗？", "关闭确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != DialogResult.Yes)
                e.Cancel = true;
        }

        private void ResetGroupBox2Controls()
        {
            comboBox_SelectedGeneToQuery.Items.Clear();
            comboBox_SelectedPositionToQuery.Items.Clear();
            textBox_QueryCommandOfSelectedGene.Text = "";
            chr = new ArrayList();
            chr_Positions = new Hashtable();
            columnHeaders = new ArrayList();
            skipList = new ArrayList();
        }

        private void ResetGroupBox3Controls()
        {
            listBox_ImportedAndProcessedData.Items.Clear();
            dtOnePosition = new DataTable();
            dtAllPosition = new ArrayList();
        }
        
        private void ShowWaitingPanel()
        {
            ShowWaitingPanel("请稍等...");
        }
        private void ShowWaitingPanel(string text1)
        {
            panel_Waiting.Show();
            if (text1 != "")
            {
                label_WaitingText1.Text = text1;
                label_WaitingText1.Location = new Point((panel_Waiting.Width - label_WaitingText1.Width) / 2, (panel_Waiting.Height - label_WaitingText1.Height) / 2);
                label_WaitingText1.Refresh();
            }
            label_WaitingText2.Hide();
            panel_Waiting.Refresh();

            if (status == "AutoHandle") return;
            ChangeMode("Busy");
        }

        private void ShowWaitingPanel(string text1, string text2)
        {
            panel_Waiting.Show();
            if (text1 != "")
            {
                label_WaitingText1.Text = text1;
                label_WaitingText1.Location = new Point((panel_Waiting.Width - label_WaitingText1.Width) / 2, (panel_Waiting.Height - label_WaitingText1.Height) / 2 - 10);
                label_WaitingText1.Refresh();
            }
            if (text2 != "")
            {
                label_WaitingText2.Text = text2;
                label_WaitingText2.Location = new Point((panel_Waiting.Width - label_WaitingText2.Width) / 2, (panel_Waiting.Height - label_WaitingText2.Height) / 2 + 10);
                label_WaitingText2.Show();
                label_WaitingText2.Refresh();
            }
            panel_Waiting.Refresh();

            if (status == "AutoHandle") return;
            ChangeMode("Busy");
        }

        private void HideWaitingPanel()
        {
            panel_Waiting.Hide();
            ChangeMode("Normal");
        }

        private IWorkbook ReadExcelFile(string filePath)
        {
            if (filePath == "") return null;
            try
            {
                fs_read = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                if (filePath.Contains(".xlsx"))
                    return new XSSFWorkbook(fs_read);
                else if (filePath.Contains(".xls"))
                    return new HSSFWorkbook(fs_read);
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序输出时遇到问题，重试一下吧？\n问题详情：" + ex.Message, "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (fs_read != null) fs_read.Close();
                HideWaitingPanel();
            }
            return null;
        }

        private void button_SelectFileToImport_Click(object sender, EventArgs e)
        {
            DialogResult result;
            //已经有处理的数据
            if (listBox_ImportedAndProcessedData.Items.Count > 0)
            {
                result = MessageBox.Show("已经打开了一个文件并且已经处理了一些信息，打开另一个文件的话将会清空下面已处理的所有信息，如果没有保存的话下面的信息将会丢失，确定吗？", "打开文件确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                    return;
            }
            //设置打开文件对话框
            OpenFileDialog importXLS = new OpenFileDialog();
            importXLS.Multiselect = false;
            importXLS.Filter = "Excel表格（*.xls, *.xlsx）|*.xls;*.xlsx";

            result = importXLS.ShowDialog();
            if (result == DialogResult.OK)
            //重新打开一个文件
            {
                //清空下面的所有信息
                ResetGroupBox2Controls();
                ResetGroupBox3Controls();

                //写入文件路径，读入文件
                ShowWaitingPanel("正在读入Excel文件...");
                textBox_SelectedFileToImport.Text = importXLS.FileName;
                XLSImported = ReadExcelFile(importXLS.FileName);
                if (XLSImported == null)
                {
                    MessageBox.Show("未选择文件或选择的文件不是Excel表格文件，请重新选择！", "文件打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                HideWaitingPanel();

                //重新读入文件中的表
                ShowWaitingPanel("正在读取Excel文件中的表...");
                comboBox_SelectedSheetToImport.Items.Clear();
                int numberOfSheets = XLSImported.NumberOfSheets;
                if (numberOfSheets <= 0)
                {
                    MessageBox.Show("选择的文件中没有任何表，请重新选择！", "文件打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //添加表名，选择第一项
                isOpeningFile = true;
                for (int i = 0; i < numberOfSheets; i++)
                {
                    comboBox_SelectedSheetToImport.Items.Add(XLSImported.GetSheetName(i));
                }
                HideWaitingPanel();
                isOpeningFile = false;

                comboBox_SelectedSheetToImport.SelectedIndex = 0;
            }
        }

        private void comboBox_SelectedSheetToImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("记得把网页中的癌症类型改成表对应的类型哦！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //判断是否是打开文件时
            if (isOpeningFile) return;

            if (textBox_SelectedFileToImport.Text == "")
            {
                MessageBox.Show("还没选文件呢 ", "亲先选文件", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //判断表名是否为空
            if (comboBox_SelectedSheetToImport.Text == "")
            {
                MessageBox.Show("未选择任何表，请重新选择！", "表打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listBox_ImportedAndProcessedData.Items.Count > 0)
            {
                var result = MessageBox.Show("已经对当前表处理了一些信息，更改为另一个表的话将会清空下面已处理的所有信息，如果没有保存的话下面的信息将会丢失，确定吗？", "更换表确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                    return;
            }

            //得到选择的表
            SelectedSheet = XLSImported.GetSheet(comboBox_SelectedSheetToImport.Text);

            //判断文件中是否包含该表
            if (SelectedSheet == null)
            {
                MessageBox.Show("Excel文件中不包含名为“" + comboBox_SelectedSheetToImport.Text + "”的表，请重新选择！", "表打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int errI = -1, errJ = -1;
            string errTime = "";
            try
            {
                //开始搜索含有chr的列，若没有找到则提示并返回
                errTime = "搜索含有chr的列时";
                int numberOfRows = SelectedSheet.LastRowNum + 1;
                int numberOfColumnContainingChr = -1;
                for (int i = 0; i < numberOfRows; i++)
                {
                    errI = i;
                    IRow row = SelectedSheet.GetRow(i);
                    int numberOfColumns = row.LastCellNum;
                    for (int j = 0; j < numberOfColumns; j++)
                    {
                        errJ = j;
                        string str = row.GetCell(j).StringCellValue.ToLower();
                        if ((str.Contains("chr")) && (str.Contains(":")))
                        {
                            numberOfColumnContainingChr = j;
                            break;
                        }
                    }
                    if (numberOfColumnContainingChr > -1)
                        break;
                }
                if (numberOfColumnContainingChr == -1)
                {
                    MessageBox.Show("表" + comboBox_SelectedSheetToImport.Text + "没有任何列包含基因位置信息，请重新选择！请确保基因位置列的格式为“chrX:Y-Z”，其中X、Y、Z为数字", "表打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ResetGroupBox3Controls();

                //搜索该列所有chr并添加到chr数组和combobox中，首先清空groupBox2
                errTime = "搜索整理所有chr时";
                isOpeningSheet = true;
                ResetGroupBox2Controls();
                ShowWaitingPanel("正在搜索所有chr并整理信息……");
                totalPosition = 0;
                for (int i = 0; i < numberOfRows; i++)
                {
                    errI = i;
                    IRow row = SelectedSheet.GetRow(i);
                    string chrString = row.GetCell(numberOfColumnContainingChr).StringCellValue;
                    //若该行不包含信息则跳过（表头、空行等）
                    if (i == 0)
                    {
                        if ((!chrString.Contains(":")) && (!chrString.Contains("chr")))
                        {
                            //认为是表头
                            for (int j = 0; j < row.LastCellNum; j++)
                            {
                                if (j != numberOfColumnContainingChr)
                                    columnHeaders.Add(row.GetCell(j).StringCellValue);
                                else
                                    columnHeaders.Add("Position");
                            }
                        }
                        else
                        {
                            //没有表头，自制一个
                            for (int j = 0; j < row.LastCellNum; j++)
                            {
                                if (j != numberOfColumnContainingChr)
                                    columnHeaders.Add("原表第" + j + "列信息");
                                else
                                    columnHeaders.Add("Position");
                            }
                        }

                    }
                    if (!chrString.Contains(":")) continue;
                    if (!chrString.Contains("chr")) continue;

                    totalPosition++;
                    position_info_NumberOfColumn = SelectedSheet.GetRow(i).LastCellNum;

                    string[] chr_position_info = chrString.Split(new char[] { ':' });

                    //将基因名称对应的position、name、Tissue Expression组合成单个position信息的数组
                    ArrayList position_info = new ArrayList();
                    position_info.Add(chr_position_info[1]); //单个position信息的数组，第一项为位置
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        errJ = j;
                        if (j != numberOfColumnContainingChr)
                            position_info.Add(row.GetCell(j).StringCellValue); //单个position信息的数组，第二项及以后为其他信息
                    }

                    if (!chr.Contains(chr_position_info[0]))
                    {
                        //将基因名称添加到chr列表
                        chr.Add(chr_position_info[0]);

                        //新建一个记录所有position信息数组的数组
                        ArrayList positions = new ArrayList();
                        positions.Add(position_info); //添加单个position信息数组

                        //将上面两项对应写入哈希表
                        chr_Positions.Add(chr_position_info[0], positions);

                        //将基因名称添加到ComboBox
                        //comboBox_SelectedGeneToQuery.Items.Add(chr_position_info[0]);
                    }
                    else
                    {
                        //对指定chr，添加单个position信息数组
                        ((ArrayList)(chr_Positions[chr_position_info[0]])).Add(position_info);
                        /* 另一种方法
                        ArrayList positions = (ArrayList)chr_Positions[chr_position_info[0]];
                        positions.Add(position_info);
                        chr_Positions[chr_position_info[0]] = positions;
                        */
                    }
                }
                chr.Sort();
                foreach (string s in chr)
                    comboBox_SelectedGeneToQuery.Items.Add(s);
                totalChr = chr.Count;
                isOpeningSheet = false;
                HideWaitingPanel();
                comboBox_SelectedGeneToQuery.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                errI++; errJ++;
                MessageBox.Show("程序处理数据时遇到了一点数据问题，请把数据更正后再试一次吧！要求所有单元格格式都是【文本】哦！\n"
                    + "出错的行：" + errI + "，列：" + errJ + "\n问题时机：" + errTime + "\n问题详情：" + ex.Message, "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetGroupBox2Controls();
                ResetGroupBox3Controls();
                HideWaitingPanel();
            }
        }
        
        private void RefreshItemsInComboBoxPosition()
        {
            isAddingPositions = true;

            comboBox_SelectedPositionToQuery.Items.Clear();
            foreach (ArrayList position_info in ((ArrayList)(chr_Positions[comboBox_SelectedGeneToQuery.Text])))
            {
                comboBox_SelectedPositionToQuery.Items.Add(position_info[0].ToString());
            }
            foreach (string addedItem in listBox_ImportedAndProcessedData.Items)
            {
                comboBox_SelectedPositionToQuery.Items.Remove(addedItem.Split(new char[] {':'})[1]); //移除listbox里已有的position
            }
            foreach (string skippedItem in skipList)
            {
                comboBox_SelectedPositionToQuery.Items.Remove(skippedItem.Split(new char[] { ':' })[1]); //移除忽略项
            }

            isAddingPositions = false;
            if (comboBox_SelectedPositionToQuery.Items.Count > 0)
                comboBox_SelectedPositionToQuery.SelectedIndex = 0;
            else
                textBox_QueryCommandOfSelectedGene.Text = "";
        }

        private void comboBox_SelectedGeneToQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            //判断是否是打开表添加基因时
            if (isOpeningSheet) return;

            RefreshItemsInComboBoxPosition();
        }

        private void comboBox_SelectedPositionToQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAddingPositions) return;

            //生成查询命令
            //ShowWaitingPanel("正在生成查询命令...");
            string queryCommand = comboBox_SelectedGeneToQuery.Text + ":";
            ArrayList positions = (ArrayList)(chr_Positions[comboBox_SelectedGeneToQuery.Text]);
            queryCommand = comboBox_SelectedGeneToQuery.Text + ":" + comboBox_SelectedPositionToQuery.Text;
            /*这是一个chr里所有的position合在一起的查询
            foreach (ArrayList position_info in positions)
            {
                queryCommand += position_info[0].ToString() + ";";
            }
            queryCommand = queryCommand.Remove(queryCommand.Length - 1);
            */
            textBox_QueryCommandOfSelectedGene.Text = queryCommand;
            //HideWaitingPanel();
        }

        private void button_CopyQueryCommand_Click(object sender, EventArgs e)
        {
            if (textBox_QueryCommandOfSelectedGene.Text == "")
            {
                MessageBox.Show("并没有选择任何基因", "复制命令到剪贴板", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Clipboard.SetText(textBox_QueryCommandOfSelectedGene.Text, TextDataFormat.Text);
            MessageBox.Show("命令已复制到剪贴板，去网页上粘贴吧", "复制命令到剪贴板", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_OpenQueryURL_Click(object sender, EventArgs e)
        {            
            Process.Start(textBox_QueryURL.Text);
        }

        private bool ImportQueryData(string dataString, string source)
        {
            if (textBox_SelectedFileToImport.Text == "")
            {
                MessageBox.Show("还没选文件", "先选文件", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string[] data_rows = dataString.Split(new char[] { '\n' });
            if (!dataString.Contains("TCGA"))
            {
                MessageBox.Show(source + "中并没有对应数据", "导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            dtOnePosition = new DataTable(comboBox_SelectedGeneToQuery.Text + ":" + comboBox_SelectedPositionToQuery.Text);
            dtOnePosition.TableName = comboBox_SelectedGeneToQuery.Text + ":" + comboBox_SelectedPositionToQuery.Text;
            //dtOnePosition.Columns.Add("Position");

            for (int i = 0; i < columnHeaders.Count; i++)
            {
                dtOnePosition.Columns.Add(columnHeaders[i].ToString());
            }

            DataRow row = dtOnePosition.Rows.Add();
            for (int i = 0; i < data_rows.Length; i++)
            {
                string[] row_info = data_rows[i].Split(new char[] { '\t' });
                if (row_info.Length != 4) continue;

                string value_chr = "chr" + row_info[1].Split(new char[] { ':' })[0];
                if (value_chr != comboBox_SelectedGeneToQuery.Text)
                {
                    if (status == "AutoHandle")
                        button_StopAutoHandling_Click(button_StopAutoHandling, new EventArgs());
                    MessageBox.Show(source + "中的数据对应的是" + value_chr + "，但上面选择的是" + comboBox_SelectedGeneToQuery.Text + "。请确保二者一致！", "染色体位置不一致", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string value_position = row_info[1].Split(new char[] { ':', ';' })[1];//得到信息中的位置
                if (value_position != comboBox_SelectedPositionToQuery.Text)
                {
                    if (status == "AutoHandle")
                        button_StopAutoHandling_Click(button_StopAutoHandling, new EventArgs());
                    MessageBox.Show(source + "中的数据对应的是" + value_position + "，但上面选择的是" + comboBox_SelectedPositionToQuery.Text + "。请确保二者一致！", "染色体位置不一致", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                row["Position"] = value_chr + ":" + value_position;

                ArrayList position_info = null;
                foreach (ArrayList position in (ArrayList)(chr_Positions[value_chr]))
                {
                    if (position[0].ToString() == value_position)
                    {
                        position_info = position;
                        break;
                    }
                }
                if (position_info != null)
                {
                    int n = 0;
                    for (int j = 1; j < position_info_NumberOfColumn; j++)
                    {
                        if (dtOnePosition.Columns[n].ColumnName == "Position")
                            n++;
                        row[n] = position_info[j];
                        n++;
                    }
                }

                if (!dtOnePosition.Columns.Contains(row_info[2]))
                    dtOnePosition.Columns.Add(row_info[2]); //如果没有SampleID列，则新建一个

                row[row_info[2]] = row_info[3]; //写入lncRNA Expression 表达值
            }

            dtAllPosition.Add(dtOnePosition);
            listBox_ImportedAndProcessedData.Items.Add(dtOnePosition.TableName);

            RefreshItemsInComboBoxPosition();
            return true;
        }

        private void button_ImportQueryDataFromClipboard_Click(object sender, EventArgs e)
        {
            ImportQueryData(Clipboard.GetText(), "剪贴板");
        }

        private void button_DeleteSelectedData_Click(object sender, EventArgs e)
        {
            if (listBox_ImportedAndProcessedData.Items.Count <= 0)
            {
                MessageBox.Show("列表中并没有数据", "清除数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if ((listBox_ImportedAndProcessedData.SelectedIndex < 0) || (listBox_ImportedAndProcessedData.SelectedIndex >= listBox_ImportedAndProcessedData.Items.Count))
            {
                MessageBox.Show("你并没有选择数据", "清除数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("确认清除选定的数据吗？ ", "清除数据", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                DataTable toBeDeleted = null;
                foreach (DataTable table in dtAllPosition)
                {
                    if (table.TableName == listBox_ImportedAndProcessedData.SelectedItem.ToString())
                    {
                        toBeDeleted = table;
                        break;
                    }
                }

                dtAllPosition.Remove(toBeDeleted);
                listBox_ImportedAndProcessedData.Items.Remove(listBox_ImportedAndProcessedData.SelectedItem);
            }

            RefreshItemsInComboBoxPosition();
        }

        private void button_DeleteAllData_Click(object sender, EventArgs e)
        {
            if (listBox_ImportedAndProcessedData.Items.Count <= 0)
            {
                MessageBox.Show("列表中并没有数据", "清除数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("确认清除【所有】的数据吗？ ", "清除数据", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                dtAllPosition.Clear();
                listBox_ImportedAndProcessedData.Items.Clear();
            }

            RefreshItemsInComboBoxPosition();
        }

        private void button_ExportDataToClipboard_Click(object sender, EventArgs e)
        {
            if (listBox_ImportedAndProcessedData.Items.Count <= 0)
            {
                MessageBox.Show("列表中并没有数据", "输出数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string data = ""; bool writeHeader = true;
            int n = 0, total = dtAllPosition.Count;
            foreach (DataTable table in dtAllPosition)
            {
                if (writeHeader)
                //写入表头
                {
                    ShowWaitingPanel("正在将数据写入剪贴板...", "写入表头");
                    foreach (DataColumn column in table.Columns)
                        data += column.Caption + "\t";
                    data = data.Remove(data.Length - 1) + "\n";
                    writeHeader = false;
                }
                //写入每行
                foreach (DataRow row in table.Rows)
                {
                    ShowWaitingPanel("正在将数据写入剪贴板...", "第" + ++n + "行，共" + total + "行");
                    foreach (string s in row.ItemArray)
                        data += s + "\t";
                    data += "\n";
                }
            }
            HideWaitingPanel();

            MessageBox.Show("输出完成，去粘贴吧~", "输出数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportDataToExcel()
        {
            ExportDataToExcel("");
        }

        private void ExportDataToExcel_AutoSave()
        {
            int i = 0;
            string autosavePath = Path.GetDirectoryName(textBox_SelectedFileToImport.Text) + "\\" +
                                  comboBox_SelectedSheetToImport.Text + "-自动处理完成-自动保存.xlsx";
            RETRY:
            try
            {
                if (File.Exists(autosavePath))
                    File.Delete(autosavePath);
            }
            catch (Exception)
            {
                i++;
                autosavePath = autosavePath.Replace("-自动处理完成-自动保存", "-自动处理完成-自动保存-" + i.ToString());
                goto RETRY;
            }
            ExportDataToExcel(autosavePath);
            var result = MessageBox.Show(comboBox_SelectedSheetToImport.Text + "的所有位置都查询完啦！\n已自动保存到原文件同一目录下，要打开看一下吗？", "自动操作完成", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
                Process.Start(autosavePath);
        }

        private void ExportDataToExcel(string path)
        {
            int n, total;
            string errPosition = "";
            DialogResult result;
            if (listBox_ImportedAndProcessedData.Items.Count <= 0)
            {
                MessageBox.Show("列表中并没有数据", "输出数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog exportXLS = new SaveFileDialog();
            exportXLS.Filter = "2007以上版本（*.xlsx）|*.xlsx";
            if (path == "")
                result = exportXLS.ShowDialog();
            else
            {
                result = DialogResult.OK;
                exportXLS.FileName = path;
            }


            if (result == DialogResult.OK)
            //新建一个文件
            {
                try
                {
                    if (File.Exists(exportXLS.FileName))
                        File.Delete(exportXLS.FileName);
                    
                    fs_write = new FileStream(exportXLS.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    XLSExported = new XSSFWorkbook();

                    ISheet sheet = XLSExported.CreateSheet(comboBox_SelectedSheetToImport.Text);

                    bool writeHeader = true;
                    int rowCount = 1;
                    n = 0;
                    total = dtAllPosition.Count;
                    foreach (DataTable table in dtAllPosition)
                    {
                        if (writeHeader)
                        //写入表头
                        {
                            ShowWaitingPanel("正在将数据写入Excel文件...", "写入表头");
                            IRow XLSrow = sheet.CreateRow(0);
                            int j = 0;
                            foreach (DataColumn column in table.Columns)
                            {
                                XLSrow.CreateCell(j).SetCellValue(column.Caption);
                                j++;
                            }
                            writeHeader = false;
                        }
                        //写入每行
                        errPosition = table.TableName;
                        foreach (DataRow row in table.Rows)
                        {
                            ShowWaitingPanel("正在将数据写入Excel文件...", "第" + ++n + "行，共" + total + "行");
                            IRow XLSrow = sheet.CreateRow(rowCount);
                            int j = 0;
                            foreach (string s in row.ItemArray)
                            {
                                if (s.Contains("."))
                                    XLSrow.CreateCell(j).SetCellValue(Convert.ToDouble(s));
                                else
                                    XLSrow.CreateCell(j).SetCellValue(s);
                                j++;
                            }
                            rowCount++;
                        }
                    }

                    XLSExported.Write(fs_write);
                    HideWaitingPanel();
                    if (path == "")
                        result = MessageBox.Show("输出完成，是否打开文件？", "输出数据", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        Process.Start(exportXLS.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("程序输出时遇到了一点问题\n问题详情：" + ex.Message + "\n异常类型：" + ex.InnerException + "\n出错的位置：" + errPosition + "\n请把这一行手动删除然后重新让程序自动导入一遍吧~", "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HideWaitingPanel();
                }
                finally
                {
                    if (fs_write != null) fs_write.Close();
                }
            }
        }

        private void button_ExportDataToExcel_Click(object sender, EventArgs e)
        {
            ExportDataToExcel();
        }

        private void button_ImportQueryDataFromExcel_Click(object sender, EventArgs e)
        {
            if (textBox_SelectedFileToImport.Text == "")
            {
                MessageBox.Show("还没选文件", "亲先选文件", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenFileDialog importTempXLS = new OpenFileDialog();
            importTempXLS.Multiselect = false;
            importTempXLS.Filter = "2007以上版本（*.xlsx）|*.xlsx";

            var result = importTempXLS.ShowDialog();
            if (result == DialogResult.OK)
            {
                //写入文件路径，读入文件
                IWorkbook tempXLSImported = ReadExcelFile(importTempXLS.FileName);
                if (tempXLSImported == null)
                {
                    MessageBox.Show("未选择文件或选择的文件不是Excel表格文件，请重新选择！", "文件打开错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tempXLSImported.NumberOfSheets <= 0)
                {
                    MessageBox.Show("这个并不是之前保存的文件", "导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ISheet sheet = tempXLSImported.GetSheetAt(0);
                if (sheet.LastRowNum < 1)
                {
                    MessageBox.Show("这个文件中并没有数据", "导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                IRow header = sheet.GetRow(0);
                string version = "none";
                if ((header.GetCell(0).StringCellValue == "chr") && (header.GetCell(1).StringCellValue == "Position") &&
                    (header.GetCell(2).StringCellValue == "Name") &&
                    (header.GetCell(3).StringCellValue == "Tissue Expression"))
                {
                    version = "old";
                }
                else if ((header.GetCell(0).StringCellValue == "Position") &&
                         (header.GetCell(1).StringCellValue == "Name") &&
                         (header.GetCell(2).StringCellValue == "Tissue Expression"))
                {
                    version = "new";
                }
                else
                {
                    MessageBox.Show(
                        "这个文件似乎不是程序生成的啊，是不是改动了？如果是程序输出的文件的话，老版本第一行从左到右依次是“chr”、“Position”、“Name”、“Tissue Expression”；新版本依次是“Position”、“Name”、“Tissue Expression”",
                        "导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dtOnePositionTemplet = new DataTable();
                for (int i = version == "new" ? 0 : 1; i < header.LastCellNum; i++)
                {
                    dtOnePositionTemplet.Columns.Add(header.Cells[i].StringCellValue);
                }
                int NumberOfRowImported = 0, NumberOfRowExisted = 0;

                if (version == "old")
                {
                    for (int i = 1; i < sheet.LastRowNum + 1; i++)
                    {
                        ShowWaitingPanel("正在读入之前保存的Excel文件...", "第" + i + "行，共" + (sheet.LastRowNum) + "行");
                        IRow row = sheet.GetRow(i);
                        if (listBox_ImportedAndProcessedData.Items.Contains(row.GetCell(0).StringCellValue + ":" + row.GetCell(1).StringCellValue))
                        {
                            NumberOfRowExisted++;
                        }
                        else
                        {
                            DataTable dtOnePositionImported = dtOnePositionTemplet.Clone();
                            dtOnePositionImported.TableName = row.GetCell(0).StringCellValue + ":" + row.GetCell(1).StringCellValue;
                            DataRow dtRow = dtOnePositionImported.Rows.Add();

                            dtRow[0] = row.GetCell(0).StringCellValue + ":" + row.GetCell(1).StringCellValue;
                            for (int j = 2; j < row.Cells.Count; j++)
                                dtRow[j - 1] = row.GetCell(j).StringCellValue;

                            dtAllPosition.Add(dtOnePositionImported);
                            listBox_ImportedAndProcessedData.Items.Add(dtOnePositionImported.TableName);

                            NumberOfRowImported++;   
                        }
                    }
                }
                else if (version == "new")
                {
                    for (int i = 1; i < sheet.LastRowNum + 1; i++)
                    {
                        ShowWaitingPanel("正在读入之前保存的Excel文件...", "第" + i + "行，共" + (sheet.LastRowNum) + "行");
                        IRow row = sheet.GetRow(i);
                        if (listBox_ImportedAndProcessedData.Items.Contains(row.GetCell(0).StringCellValue))
                        {
                            NumberOfRowExisted++;
                        }
                        else
                        {
                            DataTable dtOnePositionImported = dtOnePositionTemplet.Clone();
                            dtOnePositionImported.TableName = row.GetCell(0).StringCellValue;
                            DataRow dtRow = dtOnePositionImported.Rows.Add();
                            for (int j = 0; j < row.Cells.Count; j++)
                                dtRow[j] = row.GetCell(j).StringCellValue;

                            dtAllPosition.Add(dtOnePositionImported);
                            listBox_ImportedAndProcessedData.Items.Add(dtOnePositionImported.TableName);

                            NumberOfRowImported++;
                        }
                    }
                }
                HideWaitingPanel();

                RefreshItemsInComboBoxPosition();

                if (NumberOfRowExisted > 0)
                    MessageBox.Show("数据导入完成！共导入了" + NumberOfRowImported + "行，另外" + NumberOfRowExisted + "行列表中已存在", "导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("数据导入完成！共导入了" + NumberOfRowImported + "行", "导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /*
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, IntPtr wParam, int lParam);

        private void ClosePopWindow(string winTitle, string buttonTitle)
        {
            IntPtr hwnd = FindWindow(null, winTitle);
            if (hwnd != IntPtr.Zero)
            {
                IntPtr hwndText = FindWindowEx(hwnd, 0, null, "Invalid position input.");
                if (hwndText != IntPtr.Zero)
                {
                    IntPtr hwndSure = FindWindowEx(hwnd, 0, "Button", buttonTitle);
                    if (hwndSure != IntPtr.Zero)
                        SendMessage(hwndSure, 0xF5, (IntPtr)0, 0);
                }
            }
        }
        */
        private void AutoFill(string queryCommand)
        {
            if (webBrowser1.Document == null) return;
            //如果QueryBox隐藏了，则点开它
            HtmlElement queryBox_Button = webBrowser1.Document.GetElementById("query_box_toggle_button");
            HtmlElement queryBox_Form = webBrowser1.Document.GetElementById("query-form-div");
            if (queryBox_Form == null) return;

            if (queryBox_Form.Style != null)
                if (queryBox_Form.Style.Contains("none"))
                {
                    queryBox_Button.InvokeMember("Click");
                }

            //如果选择的不是Query by Position，则选择他；如果是，则输入数据，并按下右键激活事件，最后提交
            bool changed = false;
            JUDGE_QUERYBY:
            HtmlElement selectByPosition_Button = webBrowser1.Document.GetElementById("query_rna_by-button");
            if (selectByPosition_Button.InnerText == "Query by Annotation")
            {
                this.BringToFront();
                this.Activate();  

                selectByPosition_Button.InvokeMember("Click");
                selectByPosition_Button.Focus();
                SendKeys.Send("{DOWN}");
                SendKeys.Send("{DOWN}");
                SendKeys.Send("{ENTER}");
                Thread.Sleep(10);
                SendKeys.Flush();
                if (changed)
                {
                    MessageBox.Show("未能选择下拉菜单！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    changed = true;
                    goto JUDGE_QUERYBY;
                }
            }
            else if (selectByPosition_Button.InnerText == "Query by Position")
            {
                this.BringToFront();
                this.Activate();  

                HtmlElement positions_TextBox = webBrowser1.Document.GetElementById("positions");
                //positions_TextBox.InvokeMember("Focus");
                positions_TextBox.Focus();
                positions_TextBox.InnerText = queryCommand;
                SendKeys.Send("{RIGHT}");
                SendKeys.Flush();
                
                //如果有提示Invalid，则自动忽略当前position并选择下一个
                HtmlElementCollection labels = webBrowser1.Document.GetElementsByTagName("label");
                foreach (HtmlElement label in labels)
                {
                    if (label == null) continue;
                    if (label.InnerText == null) continue;
                    if (label.InnerText.Contains("Error:"))
                    {
                        SkipCurrentPosition();
                        waitingSeconds = 0;
                        timer2.Enabled = true;
                        return;
                    }
                }

                //没提示就提交
                HtmlElement submit_Button = webBrowser1.Document.GetElementById("submit-button");
                submit_Button.InvokeMember("Click");

                //如果有提示是否重新提交，点Submit
                HtmlElement jobRunningAlert = webBrowser1.Document.GetElementById("job-running-alert").Parent;
                if (jobRunningAlert.Style.Contains("block"))
                {
                    HtmlElementCollection buttons = webBrowser1.Document.GetElementsByTagName("button");
                    foreach (HtmlElement button in buttons)
                    {
                        if ((button.InnerText == "Submit") && (button.Id != "submit-button"))
                        {
                            button.InvokeMember("Click");
                            break;
                        }
                    }
                }
                

                isQueryFinished = true;
            }
            else
            {
                MessageBox.Show("找不到Query by选项！");
                return;
            }

            isCopyed = false;
            //an:outerhtml:"<span tabindex=\"0\" class=\"ui-selectmenu-button ui-widget ui-state-default ui-corner-all\" id=\"query_rna_by-button\" role=\"combobox\" aria-disabled=\"false\" aria-expanded=\"false\" aria-haspopup=\"true\" aria-labelledby=\"ui-id-50\" aria-activedescendant=\"ui-id-50\" aria-owns=\"query_rna_by-menu\" style=\"width: 168px;\" aria-autocomplete=\"list\"><span class=\"ui-icon ui-icon-triangle-1-s\"></span><span class=\"ui-selectmenu-text\">Query by Annotation</span></span>"
            //an:innerhtml:"<span class=\"ui-icon ui-icon-triangle-1-s\"></span><span class=\"ui-selectmenu-text\">Query by Annotation</span>"
            //an:outertext:"Query by Annotation"
            //an:innertext:"Query by Annotation"
            //po:outerhtml:"<span tabindex=\"0\" class=\"ui-selectmenu-button ui-widget ui-state-default ui-corner-all\" id=\"query_rna_by-button\" role=\"combobox\" aria-disabled=\"false\" aria-expanded=\"false\" aria-haspopup=\"true\" aria-labelledby=\"ui-id-51\" aria-activedescendant=\"ui-id-51\" aria-owns=\"query_rna_by-menu\" style=\"width: 168px;\" aria-autocomplete=\"list\"><span class=\"ui-icon ui-icon-triangle-1-s\"></span><span class=\"ui-selectmenu-text\">Query by Position</span></span>"
            //po:innerhtml:"<span class=\"ui-icon ui-icon-triangle-1-s\"></span><span class=\"ui-selectmenu-text\">Query by Position</span>"
            //po:outertext:"Query by Position"
            //po:innertext:"Query by Position"

        }

        private void button_AutoQuery_Click(object sender, EventArgs e)
        {
            if (textBox_SelectedFileToImport.Text == "")
            {
                MessageBox.Show("还没选文件", "亲先选文件", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox_QueryCommandOfSelectedGene.Text == "")
            {
                MessageBox.Show("并没有选择染色体位置", "先选染色体位置", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!isCopyed)
            {
                var result = MessageBox.Show("刚才的查询还没有复制呢！要重新开始一次查询么？", "自动查询", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (result == DialogResult.No)
                    return;
            }
            AutoFill(textBox_QueryCommandOfSelectedGene.Text);
        }


        private void button_Navigate_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(new Uri(textBox_URL.Text));
        }

        private void AutoRead()
        {
            if (webBrowser1.Document == null) return;
            if (!isQueryFinished) return;
            if (webBrowser1.Document.GetElementById("row_0") == null)
            {
                MessageBox.Show("还没查询完", "自动导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //如果listbox里已经有了则提示并返回
            if (listBox_ImportedAndProcessedData.Items.Contains("chr" + webBrowser1.Document.GetElementById("row_0").Children[1].InnerText))
            {
                MessageBox.Show("这一项已经添加过了哦！", "自动导入数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (status != "AutoHandle")
                ShowWaitingPanel("已载入数据，正在复制数据...");

            //搜寻100改为1000
            HtmlElementCollection selectControls = webBrowser1.Document.GetElementsByTagName("select");
            HtmlElement numberOfEntries = selectControls[0];
            foreach (HtmlElement he in selectControls)
            {
                if (he.Name == "rnaexpr_table_length")
                {
                    numberOfEntries = he;
                    break;
                }
            }
            numberOfEntries.Children[3].SetAttribute("value", "10000");
            numberOfEntries.Children[3].InnerText = "10000";
            //选择1000
            this.BringToFront();
            this.Activate();  

            numberOfEntries.Focus();
            SendKeys.Send("{DOWN}");
            SendKeys.Send("{DOWN}");
            SendKeys.Send("{DOWN}");
            SendKeys.Send("{DOWN}");
            SendKeys.Flush();

            timer_AutoReadLatterHalf.Enabled = true;//延迟后交给timer做完
        }

        private void timer_AutoReadLatterHalf_Tick(object sender, EventArgs e)
        {
            //接AutoRead
            timer_AutoReadLatterHalf.Enabled = false;
            //读取所有行
            HtmlElement rowParent = webBrowser1.Document.GetElementById("row_0").Parent;
            string data_to_process = "";
            foreach (HtmlElement row in rowParent.Children)
            {
                foreach (HtmlElement element in row.Children)
                {
                    data_to_process += element.InnerText + "\t";
                }
                data_to_process = data_to_process.Remove(data_to_process.Length - 1) + "\n";
            }
            ImportQueryData(data_to_process, "网页");
            
            if (status != "AutoHandle")
                HideWaitingPanel();

            isCopyed = true;
        }

        private void button_AutoRead_Click(object sender, EventArgs e)
        {
            AutoRead();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button_LockSheet_Click(object sender, EventArgs e)
        {
            comboBox_SelectedSheetToImport.Enabled = !comboBox_SelectedSheetToImport.Enabled;
        }

        private void ChangeCheckBox(bool toCheck)
        {
            if (webBrowser1.Document == null) return;
            HtmlElementCollection inputControls = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement input in inputControls)
            {
                if (input.GetAttribute("type").Contains("checkbox"))
                {
                    if (toCheck)
                        input.SetAttribute("checked","checked");
                    else
                        input.SetAttribute("checked", "");
                }
            }
            isChecked = toCheck;
        }

        private void button_ChangeCheckBox_Click(object sender, EventArgs e)
        {
            ChangeCheckBox(!isChecked);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (webBrowser1.Document == null) return;

            //HtmlElement timeoutAlert = webBrowser1.Document.GetElementById("timeout-alert")
            //if ()

            if (timer1Count > timer1TimeOut)
            {
                timer1.Enabled = false;
                currentPositionInChr--;
                currentPositionInTotal--;
                AutoHandle(true);
                return;
            }

            timer1Count++;

            if (webBrowser1.Document.GetElementById("row_0") != null)
            {
                if (("chr" + webBrowser1.Document.GetElementById("row_0").Children[1].InnerText) ==
                    (textBox_QueryCommandOfSelectedGene.Text))
                {
                    retryCount = 0;
                    timer1.Enabled = false;
                    ShowWaitingPanel("已载入数据，正在复制数据...",
                    "chr第" + currentChr + "个，共" + totalChr + "个；"
                    + "当前chr对应Position第" + currentPositionInChr + "个，共" + totalPositionInOneChr + "个；"
                    + "所有Position第" + currentPositionInTotal + "个，共" + totalPosition + "个，其中已忽略" + skipList.Count + "个");
                    AutoRead();
                    waitingSeconds = timeToWait;
                    timer2.Enabled = true;
                }
            }

        }
        

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (waitingSeconds > 0)
            {
                ShowWaitingPanel("数据复制完成，请稍等" + waitingSeconds + "秒等待系统反应。",
                        "chr第" + currentChr + "个，共" + totalChr + "个；"
                        + "当前chr对应Position第" + currentPositionInChr + "个，共" + totalPositionInOneChr + "个；"
                        + "所有Position第" + currentPositionInTotal + "个，共" + totalPosition + "个，其中已忽略" + skipList.Count + "个");
                waitingSeconds --;
            }
            else
            {
                timer2.Enabled = false;
                AutoHandle();
            }
        }
        private void AutoHandle()
        {
            AutoHandle(false);
        }
        private void AutoHandle(bool retry)
        {
            bool retrying = retry;
            ChangeMode("AutoHandle");
            while (true)
            {
                if (comboBox_SelectedPositionToQuery.Items.Count > 0)
                {
                    currentPositionInChr++;
                    currentPositionInTotal++;
                    if (retrying)
                    {
                        retryCount++;
                        if (retryCount >= 4)
                        {
                            SkipCurrentPosition();
                            waitingSeconds = 0;
                            timer2.Enabled = true;
                            return;
                        }
                        ShowWaitingPanel("等待超时，重试中...第" + retryCount + "次...正在等待网站返回数据...",
                        "chr第" + currentChr + "个，共" + totalChr + "个；"
                        + "当前chr对应Position第" + currentPositionInChr + "个，共" + totalPositionInOneChr + "个；"
                        + "所有Position第" + currentPositionInTotal + "个，共" + totalPosition + "个，其中已忽略" + skipList.Count + "个");
                    }
                    else
                        ShowWaitingPanel("正在等待网站返回数据...",
                        "chr第" + currentChr + "个，共" + totalChr + "个；"
                        + "当前chr对应Position第" + currentPositionInChr + "个，共" + totalPositionInOneChr + "个；"
                        + "所有Position第" + currentPositionInTotal + "个，共" + totalPosition + "个，其中已忽略" + skipList.Count + "个");
                    AutoFill(textBox_QueryCommandOfSelectedGene.Text);
                    timer1Count = 0;
                    timer1.Enabled = true;
                }
                else //该chr下所有position已经处理完
                {
                    if (comboBox_SelectedGeneToQuery.SelectedIndex + 1 == comboBox_SelectedGeneToQuery.Items.Count) //所有chr都处理完
                    {
                        StopAutoHandling();
                        ExportDataToExcel_AutoSave();
                    }
                    else //换下一个chr
                    {
                        retrying = false;
                        comboBox_SelectedGeneToQuery.SelectedIndex++;
                        currentChr++;
                        currentPositionInChr = 0;
                        totalPositionInOneChr = comboBox_SelectedPositionToQuery.Items.Count;
                        continue;
                    }
                }
                break;
            }
        }

        private void StopAutoHandling()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            //timer3.Enabled = false;
            HideWaitingPanel();
        }

        private void button_AutoHandle_Click(object sender, EventArgs e)
        {
            if (textBox_SelectedFileToImport.Text == "")
            {
                MessageBox.Show("还没选文件", "先选文件", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //timer3.Enabled = true;

            currentPositionInChr = 0;
            currentPositionInTotal = listBox_ImportedAndProcessedData.Items.Count + skipList.Count;
            currentChr = 1;
            comboBox_SelectedGeneToQuery.SelectedIndex = 0;
            totalPositionInOneChr = comboBox_SelectedPositionToQuery.Items.Count;

            ChangeCheckBox(false);
            AutoHandle();
        }

        private void button_StopAutoHandling_Click(object sender, EventArgs e)
        {
            StopAutoHandling();
        }
        /// <summary>
        /// 改变模式
        /// </summary>
        /// <param name="mode">Normal、Busy、AutoHandle</param>
        private void ChangeMode(string mode)
        {
            switch (mode)
            {
                case "Normal":
                    //groupBox1
                    button_SelectFileToImport.Enabled = true;
                    comboBox_SelectedSheetToImport.Enabled = true;
                    button_LockSheet.Enabled = true;

                    //groupBox2
                    comboBox_SelectedGeneToQuery.Enabled = true;
                    comboBox_SelectedPositionToQuery.Enabled = true;
                    button_CopyQueryCommand.Enabled = true;
                    button_OpenQueryURL.Enabled = true;

                    //groupBox3
                    button_ImportQueryDataFromClipboard.Enabled = true;
                    button_ImportQueryDataFromExcel.Enabled = true;
                    button_DeleteSelectedData.Enabled = true;
                    button_DeleteAllData.Enabled = true;
                    button_ExportDataToExcel.Enabled = true;

                    //groupBox4
                    button_AutoQuery.Enabled = true;
                    button_AutoRead.Enabled = true;
                    button_AutoHandle.Enabled = true;
                    button_StopAutoHandling.Enabled = false;
                    button_SkipCurrentPosition.Enabled = true;
                    button_ChangeCheckBox.Enabled = true;
                    button_Navigate.Enabled = true;
                    button_ChangeHandlingMode.Enabled = true;
                    break;
                case "Busy":
                    //groupBox1
                    button_SelectFileToImport.Enabled = false;
                    comboBox_SelectedSheetToImport.Enabled = false;
                    button_LockSheet.Enabled = false;

                    //groupBox2
                    comboBox_SelectedGeneToQuery.Enabled = false;
                    comboBox_SelectedPositionToQuery.Enabled = false;
                    button_CopyQueryCommand.Enabled = false;
                    button_OpenQueryURL.Enabled = false;

                    //groupBox3
                    button_ImportQueryDataFromClipboard.Enabled = false;
                    button_ImportQueryDataFromExcel.Enabled = false;
                    button_DeleteSelectedData.Enabled = false;
                    button_DeleteAllData.Enabled = false;
                    button_ExportDataToExcel.Enabled = false;

                    //groupBox4
                    button_AutoQuery.Enabled = false;
                    button_AutoRead.Enabled = false;
                    button_AutoHandle.Enabled = false;
                    button_StopAutoHandling.Enabled = false;
                    button_SkipCurrentPosition.Enabled = false;
                    button_ChangeCheckBox.Enabled = false;
                    button_Navigate.Enabled = false;
                    button_ChangeHandlingMode.Enabled = false;
                    break;
                case "AutoHandle":
                    //groupBox1
                    button_SelectFileToImport.Enabled = false;
                    comboBox_SelectedSheetToImport.Enabled = false;
                    button_LockSheet.Enabled = false;

                    //groupBox2
                    comboBox_SelectedGeneToQuery.Enabled = false;
                    comboBox_SelectedPositionToQuery.Enabled = false;
                    button_CopyQueryCommand.Enabled = false;
                    button_OpenQueryURL.Enabled = false;

                    //groupBox3
                    button_ImportQueryDataFromClipboard.Enabled = false;
                    button_ImportQueryDataFromExcel.Enabled = false;
                    button_DeleteSelectedData.Enabled = false;
                    button_DeleteAllData.Enabled = false;
                    button_ExportDataToExcel.Enabled = false;

                    //groupBox4
                    button_AutoQuery.Enabled = false;
                    button_AutoRead.Enabled = false;
                    button_AutoHandle.Enabled = false;
                    button_StopAutoHandling.Enabled = true;
                    button_SkipCurrentPosition.Enabled = false;
                    button_ChangeCheckBox.Enabled = false;
                    button_Navigate.Enabled = false;
                    button_ChangeHandlingMode.Enabled = false;
                    break;
            }
            status = mode;
        }
        /// <summary>
        /// 改变操作模式
        /// </summary>
        /// <param name="mode">Auto、Manual</param>
        private void ChangeHandlingMode(string mode)
        {
            switch (mode)
            {
                case "Auto":
                    button_ImportQueryDataFromClipboard.Visible = false;
                    button_AutoQuery.Visible = false;
                    button_AutoRead.Visible = false;
                    button_ChangeCheckBox.Visible = false;
                    button_AutoHandle.Visible = true;
                    button_StopAutoHandling.Visible = true;
                    groupBox4.Text = "4、自动处理数据";
                    break;
                case "Manual":
                    button_ImportQueryDataFromClipboard.Visible = true;
                    button_AutoQuery.Visible = true;
                    button_AutoRead.Visible = true;
                    button_ChangeCheckBox.Visible = true;
                    button_AutoHandle.Visible = false;
                    button_StopAutoHandling.Visible = false;
                    groupBox4.Text = "4、手动处理数据";
                    break;
            }
            handlingMode = mode;
        }
        private void button_ChangeHandlingMode_Click(object sender, EventArgs e)
        {
            if (handlingMode == "Auto")
                ChangeHandlingMode("Manual");
            else if (handlingMode == "Manual")
                ChangeHandlingMode("Auto");
        }
        
        private void SkipCurrentPosition()
        {
            skipList.Add(textBox_QueryCommandOfSelectedGene.Text);
            RefreshItemsInComboBoxPosition();
        }

        private void button_Skip_Click(object sender, EventArgs e)
        {
            if (textBox_QueryCommandOfSelectedGene.Text == "")
            {
                MessageBox.Show("现在并没有选择任何position项呀？", "添加忽略项", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string skipItem = textBox_QueryCommandOfSelectedGene.Text;
            var result = MessageBox.Show("确认忽略" + skipItem + "吗？下次重新打开程序的时候将会清除所有的忽略项哦~", "添加忽略项", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                SkipCurrentPosition();
                MessageBox.Show("已添加忽略项" + skipItem, "添加忽略项", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
