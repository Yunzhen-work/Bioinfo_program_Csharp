using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动处理数据_9_合并level2_level3小文件
{
    public partial class Form1 : Form
    {
        private OpenFileDialog importFile = null, importFile1 = null, importFile2 = null, importFile3 = null;
        private SaveFileDialog exportFile = null;
        private char[] splitter = new char[] {'\t'};

        public Form1()
        {
            InitializeComponent();
        }

        #region Expression_Genes
        private void button_1_SelectFile_Click(object sender, EventArgs e)
        {
            UpdateInfoLabel("");
            importFile = new OpenFileDialog();
            importFile.Multiselect = true;
            importFile.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_1_level.Text = importFile.FileNames[0] + " 等" + importFile.FileNames.Length + "个文件";
            }
        }

        private void button_1_SelectOutputFile_Click(object sender, EventArgs e)
        {
            exportFile = new SaveFileDialog();
            exportFile.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = exportFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_1_OutputFile.Text = exportFile.FileName;
            }
        }

        private void button_1_Start_Click(object sender, EventArgs e)
        {
            //textBox
            if (textBox_1_level.Text == "")
            {
                MessageBox.Show("还没选择level2或level3文件！");
                return;
            }

            //textBox_OutputFile
            if (textBox_1_OutputFile.Text == "")
            {
                MessageBox.Show("还没选择输出文件！");
                return;
            }

            Stopwatch t = new Stopwatch();
            t.Restart();
            StartWorking_1();
            t.Stop();

            UpdateInfoLabel("输出完成！共用时" + t.ElapsedMilliseconds/1000 + "s");
            MessageBox.Show("输出完成！共用时" + t.ElapsedMilliseconds/1000 + "s");

        }

        private void StartWorking_1()
        {
            //读取时正常读取，样本放列，探针（Name）放行
            DataTable dt = new DataTable();
            bool firstFile = true;
            StreamReader reader = null;
            string row_read = "";
            string[] row_split = null;
            int fileNo = 0;
            //读入所有文件进表格
            foreach (string filePath in importFile.FileNames)
            {
                if (firstFile) //第一个文件，新建row
                {
                    UpdateInfoLabel("正在读入探针名");
                    dt.Columns.Add("Name");
                    reader = new StreamReader(filePath);
                    reader.ReadLine();
                    reader.ReadLine(); //跳过前两行
                    while (!reader.EndOfStream)
                    {
                        row_read = reader.ReadLine();
                        row_split = row_read.Split(splitter, StringSplitOptions.None);
                        dt.Rows.Add(row_split[0]);
                    }
                    firstFile = false;
                    reader.Close();
                }

                fileNo++;
                UpdateInfoLabel("正在读入小文件，第" + fileNo + "个，共" + importFile.FileNames.Length + "个");
                reader = new StreamReader(filePath);

                row_read = reader.ReadLine();
                row_split = row_read.Split(splitter, StringSplitOptions.None);
                dt.Columns.Add(row_split[1]); //TCGA-XX-XXXX-XXX-XXX-XXXX-XX
                reader.ReadLine(); //Composite Element REF	log2 lowess normalized (cy5/cy3) collapsed by gene symbol
                int rowNo = 0;
                while (!reader.EndOfStream)
                {
                    row_read = reader.ReadLine(); //*Name*	*Value*
                    row_split = row_read.Split(splitter, StringSplitOptions.RemoveEmptyEntries); //[0]:Name [1]:Value
                    dt.Rows[rowNo][fileNo] = row_split.Length >= 2 ? row_split[1] : "0";
                    rowNo++;
                }
                reader.Close();
            }

            //输出表格
            string row_output = "";
            StreamWriter writer = new StreamWriter(exportFile.FileName);

            UpdateInfoLabel("正在输出表头");
            for (int colNo = 0; colNo < dt.Columns.Count; colNo++)
            {
                row_output += dt.Columns[colNo].ColumnName + "\t";
            }
            row_output = row_output.Remove(row_output.Length - 1);
            writer.WriteLine(row_output);

            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                UpdateInfoLabel("正在输出，第" + (rowNo + 1) + "行，共" + dt.Rows.Count + "行");
                row_output = "";
                for (int colNo = 0; colNo < dt.Columns.Count; colNo++)
                {
                    row_output += dt.Rows[rowNo][colNo].ToString() + "\t";
                }
                writer.WriteLine(row_output);
            }
            writer.Close();
        }
        #endregion

        #region miRNASeq
        private void button_2_SelectFile1_Click(object sender, EventArgs e)
        {
            UpdateInfoLabel("");
            importFile1 = new OpenFileDialog();
            importFile1.Multiselect = true;
            importFile1.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_2_level.Text = importFile1.FileNames[0] + " 等" + importFile1.FileNames.Length + "个文件";
            }
        }

        private void button_2_SelectFile2_Click(object sender, EventArgs e)
        {
            UpdateInfoLabel("");
            importFile2 = new OpenFileDialog();
            importFile2.Multiselect = false;
            importFile2.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile2.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_2_MatureList.Text = importFile2.FileName;
            }
        }

        private void button_2_SelectFile3_Click(object sender, EventArgs e)
        {
            UpdateInfoLabel("");
            importFile3 = new OpenFileDialog();
            importFile3.Multiselect = false;
            importFile3.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile3.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_2_InteractionList.Text = importFile3.FileName;
            }
        }
        private void button_2_SelectOutputFile_Click(object sender, EventArgs e)
        {
            exportFile = new SaveFileDialog();
            exportFile.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = exportFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_2_OutputFile.Text = exportFile.FileName;
            }
        }

        private void button_2_Start_Click(object sender, EventArgs e)
        {
            //textBox1
            if (textBox_2_level.Text == "")
            {
                MessageBox.Show("还没选择level2或level3文件！");
                return;
            }

            //textBox2
            if (textBox_2_MatureList.Text == "")
            {
                MessageBox.Show("还没选择成熟列表文件！");
                return;
            }

            //textBox_OutputFile
            if (textBox_2_OutputFile.Text == "")
            {
                MessageBox.Show("还没选择输出文件！");
                return;
            }

            Stopwatch t = new Stopwatch();
            t.Restart();
            StartWorking_2();
            t.Stop();

            UpdateInfoLabel("输出完成！共用时" + t.ElapsedMilliseconds / 1000 + "s");
            MessageBox.Show("输出完成！共用时" + t.ElapsedMilliseconds / 1000 + "s");

        }

        private void StartWorking_2()
        {
            StreamReader reader = null;
            string row_read = "";
            string[] row_split = null;

            //读取MatureList
            List<string> matureList = new List<string>();
            reader = new StreamReader(importFile2.FileName);
            UpdateInfoLabel("正在读入成熟列表文件");
            reader.ReadLine(); //跳过表头
            while (!reader.EndOfStream)
            {
                row_read = reader.ReadLine(); //*miRNA_ID*	*miRNA_region*
                row_split = row_read.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                matureList.Add(row_split[0].ToLower());
            }
            reader.Close();

            //读取InteractionList
            List<string> interactionList = new List<string>();
            reader = new StreamReader(importFile3.FileName);
            UpdateInfoLabel("正在读入包含于成熟列表内的互作对列表文件");
            reader.ReadLine(); //跳过表头
            while (!reader.EndOfStream)
            {
                row_read = reader.ReadLine(); //*miRNAname*
                if (matureList.Contains(row_read.ToLower())) //包含于成熟列表的才要
                    interactionList.Add(row_read.ToLower());
            }
            reader.Close();


            //读取level时正常读取，样本放列（样本名从文件名中取），探针（Name）放行
            DataTable dt = new DataTable();
            bool firstFile = true;
            int fileNo = 0;
            //读入所有level文件进表格
            foreach (string filePath in importFile1.FileNames)
            {
                if (firstFile) //第一个文件，新建row
                {
                    UpdateInfoLabel("正在读入miRNA_ID");
                    dt.Columns.Add("miRNA_ID");
                    reader = new StreamReader(filePath);
                    reader.ReadLine(); //跳过表头
                    while (!reader.EndOfStream)
                    {
                        row_read = reader.ReadLine();
                        row_split = row_read.Split(splitter, StringSplitOptions.None);
                        if (interactionList.Contains(row_split[0].ToLower())) //互作对列表中包含的才要
                            dt.Rows.Add(row_split[0]);
                    }
                    firstFile = false;
                    reader.Close();
                }

                fileNo++;
                UpdateInfoLabel("正在读入小文件，第" + fileNo + "个，共" + importFile1.FileNames.Length + "个");
                reader = new StreamReader(filePath);

                dt.Columns.Add(Path.GetFileName(filePath).Split(new char[] { '.' })[0]); //【TCGA-XX-XXXX-XXX-XXX-XXXX-XX】.mirna.quantification.txt
                reader.ReadLine();//跳过表头
                int rowNo = 0;
                while (!reader.EndOfStream)
                {
                    row_read = reader.ReadLine(); //*miRNA_ID*	*read_count*  【*reads_per_million_miRNA_mapped*】  *cross-mapped*
                    row_split = row_read.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                    if (interactionList.Contains(row_split[0])) //互作对列表中包含的才要
                    {
                        dt.Rows[rowNo][fileNo] = row_split.Length >= 4 ? row_split[2] : "0.000000";
                        rowNo++;
                    }
                }
                reader.Close();
            }

            //输出表格
            string row_output = "";
            StreamWriter writer = new StreamWriter(exportFile.FileName);

            UpdateInfoLabel("正在输出表头");
            for (int colNo = 0; colNo < dt.Columns.Count; colNo++)
            {
                row_output += dt.Columns[colNo].ColumnName + "\t";
            }
            row_output = row_output.Remove(row_output.Length - 1);
            writer.WriteLine(row_output);

            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                UpdateInfoLabel("正在输出，第" + (rowNo + 1) + "行，共" + dt.Rows.Count + "行");
                row_output = "";
                for (int colNo = 0; colNo < dt.Columns.Count; colNo++)
                {
                    row_output += dt.Rows[rowNo][colNo].ToString() + "\t";
                }
                writer.WriteLine(row_output);
            }
            writer.Close();
        }
        #endregion

        private void UpdateInfoLabel(string text)
        {
            label_Info.Text = text;
            label_Info.Refresh();
        }

    }
}
