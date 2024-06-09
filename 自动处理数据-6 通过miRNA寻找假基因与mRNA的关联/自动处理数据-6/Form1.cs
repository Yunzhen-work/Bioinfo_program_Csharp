using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace 自动处理数据_5
{

    public partial class Form1 : Form
    {
        class Cancer
        {
            public string Name { get; set; }
            public List<Pseudogene> Pseudogenes { get; set; }
            //public int PositionColumnNo { get; set; }
            //public int NameColumnNo { get; set; }
            public string HeaderOfValueSheet { get; set; }

            public Cancer(string _name)
            {
                this.Name = _name;
                this.Pseudogenes = new List<Pseudogene>();
                //this.PositionColumnNo = -1;
                //this.NameColumnNo = -1;
                this.HeaderOfValueSheet = "";
            }
        }
        class Pseudogene
        {
            public Pseudogene(string _name, string _rowString)
            {
                this.Name = _name;
                this.Position = "";
                this.ENSG = "";
                this.RowString = _rowString;
                this.Chr = "";
                this.Start = -1;
                this.End = -1;
            }
            public Pseudogene(string _name, string _position, string _rowString)
            {
                this.Name = _name;
                this.Position = _position;
                this.ENSG = "";
                this.RowString = _rowString;
                //if (Regex.IsMatch(Position, @"chr\S{1,2}:\d{1,12}-\d{1,12}"))
                {
                    string[] split = Position.Split(new char[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    this.Chr = split[0];
                    this.Start = Convert.ToInt64(split[1]);
                    this.End = Convert.ToInt64(split[2]);
                }
            }
            public Pseudogene(string _name, string _position, string _ENSG, string _rowString)
            {
                this.Name = _name;
                this.Position = _position;
                this.ENSG = _ENSG;
                this.RowString = _rowString;
                //if (Regex.IsMatch(Position, @"chr\S{1,2}:\d{1,12}-\d{1,12}"))
                {
                    string[] split = Position.Split(new char[] {':', '-'}, StringSplitOptions.RemoveEmptyEntries);
                    this.Chr = split[0];
                    this.Start = Convert.ToInt64(split[1]);
                    this.End = Convert.ToInt64(split[2]);
                }
            }
            public Pseudogene(string _name, string _chr, long _start, long _end, string _rowString)
            {
                this.Name = _name;
                this.Position = _chr + ":" + _start + "-" + _end;
                this.ENSG = "";
                this.RowString = _rowString;
                this.Chr = _chr;
                this.Start = _start;
                this.End = _end;
            }
            public Pseudogene(string _name, string _chr, long _start, long _end, string _ENSG, string _rowString)
            {
                this.Name = _name;
                this.Position = _chr + ":" + _start + "-" + _end;
                this.ENSG = _ENSG;
                this.RowString = _rowString;
                this.Chr = _chr;
                this.Start = _start;
                this.End = _end;
            }

            public string Name { get; private set; }
            public string Position { get; private set; }
            public string Chr { get; private set; }
            public long Start { get; private set; }
            public long End { get; private set; }
            public string ENSG { get; private set; }
            public string RowString { get; private set; }
        }
        class miRNA_Pseudogene
        {
            public miRNA_Pseudogene(string _miRNA, string _PseudogeneName)
            {
                this.miRNA = _miRNA;
                this.PseudogeneName = _PseudogeneName;
            }
            public string miRNA { get; set; }
            public string PseudogeneName { get; set; }
        }
        class miRNA_mRNA
        {
            public miRNA_mRNA(string _miRNA, string _mRNA)
            {
                this.miRNA = _miRNA;
                this.mRNA = _mRNA;
            }
            public string miRNA { get; set; }
            public string mRNA { get; set; }
        }


        private OpenFileDialog importFile1 = null,
            importFile2 = null,
            importFile3 = null;

        private SaveFileDialog exportFile = null;
        private StreamReader reader = null;

        private StreamWriter writer = null, writer_value = null;

        private List<Cancer> list_Cancers = null;
        private List<miRNA_Pseudogene> list_miRNA_Pseudogenes = null;
        private List<miRNA_mRNA> list_miRNA_mRNAs = null;
        
        private Stopwatch t = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void button_SelectFile1_Click(object sender, EventArgs e)
        {
            label_Info.Text = "";
            label_Info.Refresh();
            importFile1 = new OpenFileDialog();
            importFile1.Multiselect = true;
            importFile1.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = "";
                foreach (string fileName in importFile1.FileNames)
                    textBox1.Text += fileName + ";";
            }
        }

        private void button_SelectFile2_Click(object sender, EventArgs e)
        {
            UpdateInfoLabel("");
            importFile2 = new OpenFileDialog();
            importFile2.Multiselect = false;
            importFile2.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile2.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = importFile2.FileName;
            }
        }

        private void button_SelectFile3_Click(object sender, EventArgs e)
        {
            UpdateInfoLabel("");
            importFile3 = new OpenFileDialog();
            importFile3.Multiselect = false;
            importFile3.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile3.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox3.Text = importFile3.FileName;
            }
        }

        private void button_SelectOutputFile_Click(object sender, EventArgs e)
        {
            exportFile = new SaveFileDialog();
            exportFile.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = exportFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_OutputFile.Text = exportFile.FileName;
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            //textBox1
            if (textBox1.Text == "")
            {
                MessageBox.Show("还没选择假基因信息文件！");
                return;
            }

            //textBox2
            if (textBox2.Text == "")
            {
                MessageBox.Show("还没选择miRNA-假基因文件！");
                return;
            }

            //textBox3
            if (textBox3.Text == "")
            {
                MessageBox.Show("还没选择miRNA-mRNA文件！");
                return;
            }

            button_SelectFile1.Enabled = false;
            button_SelectFile2.Enabled = false;
            button_SelectFile3.Enabled = false;
            button_SelectOutputFile.Enabled = false;
            button_Start.Enabled = false;
            checkBox_ENSG.Enabled = false;
            checkBox_ExportValue.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private delegate void StringDelegate(string text);
        private void UpdateInfoLabel(string text)
        {
            if (label_Info.InvokeRequired)
            {
                Invoke(new StringDelegate(UpdateInfoLabel), text);
            }
            else
            {
                label_Info.Text = text;
                label_Info.Refresh();
            }
        }

        private void ReadData()
        {
            //假基因信息
            int fileNo = 0, totalFile = importFile1.FileNames.Length;
            string[] row_read = null;
            string line_read = "";

            list_Cancers = new List<Cancer>();

            foreach (string filePath in importFile1.FileNames)
            {
                int positionColumnNo = -1,
                    nameColumnNo = -1,
                    chrColumnNo = -1,
                    startColumnNo = -1,
                    endColumnNo = -1,
                    ENSGColumnNo = -1;
                bool firstRow = true;
                fileNo++;
                UpdateInfoLabel("正在读入" + Path.GetFileName(filePath) + "，第" + fileNo + "个假基因信息文件，共" + totalFile + "个");

                Cancer cancer = new Cancer(Path.GetFileNameWithoutExtension(filePath));
                reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    line_read = reader.ReadLine();
                    row_read = line_read.Split(new char[] {'\t'}, StringSplitOptions.RemoveEmptyEntries);

                    if (row_read.Length < 2)
                    {
                        MessageBox.Show("假基因信息文件列数少于2列", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reader.Close();
                        return;
                    }

                    if (firstRow)
                    //表头行
                    {
                        firstRow = false;
                        if ((line_read.ToLower().Contains("position")) || (line_read.ToLower().Contains("name")) ||
                            (line_read.ToLower().Contains("start")))
                            //有表头
                        {
                            //寻找Name列
                            if (line_read.ToLower().Contains("name"))
                            {
                                for (int i = 0; i < row_read.Length; i++)
                                {
                                    if (row_read[i].ToLower().Contains("name"))
                                    {
                                        nameColumnNo = i;
                                        break;
                                    }
                                }
                                if ((nameColumnNo < 0))
                                {
                                    MessageBox.Show(Path.GetFileName(filePath) + "中找到了表头，但没有找到Name列", "错误",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    reader.Close();
                                    return;
                                }
                            }
                            //寻找ENSG、Position、chr、Start、End列
                            for (int i = 0; i < row_read.Length; i++)
                            {
                                if (row_read[i].ToLower().Contains("ensg"))
                                {
                                    ENSGColumnNo = i;
                                }
                                if (row_read[i].ToLower().Contains("position"))
                                {
                                    positionColumnNo = i;
                                    break;
                                }
                                if (row_read[i].ToLower().Contains("chr"))
                                {
                                    chrColumnNo = i;
                                }
                                if (row_read[i].ToLower().Contains("start"))
                                {
                                    startColumnNo = i;
                                }
                                if (row_read[i].ToLower().Contains("end"))
                                {
                                    endColumnNo = i;
                                }
                            }
                            if ((positionColumnNo < 0) &&
                                ((startColumnNo < 0) || (endColumnNo < 0) || (chrColumnNo < 0)))
                                //没有position信息
                            {
                                MessageBox.Show(
                                    Path.GetFileName(filePath) +
                                    "中找到了表头，但没找到包含Position信息的列（Position，或chr、Start、End），将忽略Position信息", "注意",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            if ((checkBox_ENSG.Checked) && (ENSGColumnNo < 0))
                                //勾选了ENSG但没有ENSG列
                            {
                                MessageBox.Show(Path.GetFileName(filePath) + "中找到了表头，但没找到ENSG列，将忽略ENSG信息", "注意",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        //没有表头，按默认算
                        {
                            var dr =
                                MessageBox.Show(
                                    Path.GetFileName(filePath) + "中没有找到表头，是否按默认（Position信息在第1列，Name信息在第2列）设定列？", "注意",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dr == DialogResult.No)
                            {
                                reader.Close();
                                return;
                            }
                            positionColumnNo = 0;
                            nameColumnNo = 1;
                            ENSGColumnNo = -1;
                        }

                        //处理完表头，重新读一行
                        cancer.HeaderOfValueSheet = line_read; //保存表头
                        continue;
                    }
                    else
                    //数据行
                    {
                        if (positionColumnNo >= 0)
                            //有单列position信息
                        {
                            if ((checkBox_ENSG.Checked) && (ENSGColumnNo >= 0))
                                cancer.Pseudogenes.Add(new Pseudogene(row_read[nameColumnNo], row_read[positionColumnNo],
                                    row_read[ENSGColumnNo], line_read));
                            else
                                cancer.Pseudogenes.Add(new Pseudogene(row_read[nameColumnNo], row_read[positionColumnNo],
                                    line_read));
                        }
                        else if ((startColumnNo >= 0) && (endColumnNo >= 0) && (chrColumnNo >= 0))
                            //有分开的position信息
                        {
                            if ((checkBox_ENSG.Checked) && (ENSGColumnNo >= 0))
                                cancer.Pseudogenes.Add(new Pseudogene(row_read[nameColumnNo],
                                    row_read[chrColumnNo], Convert.ToInt64(row_read[startColumnNo]),
                                    Convert.ToInt64(row_read[endColumnNo]),
                                    row_read[ENSGColumnNo],
                                    line_read));
                            else
                                cancer.Pseudogenes.Add(new Pseudogene(row_read[nameColumnNo],
                                    row_read[chrColumnNo], Convert.ToInt64(row_read[startColumnNo]),
                                    Convert.ToInt64(row_read[endColumnNo]),
                                    line_read));
                        }
                        else
                        //没有Position信息
                            cancer.Pseudogenes.Add(new Pseudogene(row_read[nameColumnNo], line_read));
                    }
                }

                list_Cancers.Add(cancer);
                reader.Close();
            }

            //miRNA-假基因
            UpdateInfoLabel("正在读入" + Path.GetFileName(importFile2.FileName) + "，miRNA-假基因文件");
            list_miRNA_Pseudogenes = new List<miRNA_Pseudogene>();

            reader = new StreamReader(importFile2.FileName);
            reader.ReadLine(); //不要表头
            while (!reader.EndOfStream)
            {
                row_read = reader.ReadLine().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (row_read.Length < 2)
                {
                    MessageBox.Show("miRNA-假基因列数少于2列", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                list_miRNA_Pseudogenes.Add(new miRNA_Pseudogene(row_read[0], row_read[1]));
            }
            reader.Close();

            //miRNA-mRNA
            UpdateInfoLabel("正在读入" + Path.GetFileName(importFile3.FileName) + "，miRNA-mRNA文件");
            list_miRNA_mRNAs = new List<miRNA_mRNA>();

            reader = new StreamReader(importFile3.FileName);
            reader.ReadLine(); //不要表头
            while (!reader.EndOfStream)
            {
                row_read = reader.ReadLine().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (row_read.Length < 2)
                {
                    MessageBox.Show("miRNA-mRNA列数少于2列", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                list_miRNA_mRNAs.Add(new miRNA_mRNA(row_read[0], row_read[1]));
            }
            reader.Close();
        }

        private void StartWorking()
        {
            UpdateInfoLabel("正在汇总所有mRNA-miRNA-Position-假基因信息");

            var results =
                from p1 in list_miRNA_mRNAs
                join p2 in list_miRNA_Pseudogenes on p1.miRNA equals p2.miRNA
                select new { p2.PseudogeneName, p1.miRNA, p1.mRNA };


            if (radioButton1.Checked)
            {
                foreach (Cancer cancer in list_Cancers)
                {
                    writer = new StreamWriter(exportFile.FileName.Replace(".txt", "-" + cancer.Name + ".txt"));
                    string header = "mRNA\tmiRNA\tPosition\tPseudogeneName";
                    if (checkBox_ENSG.Checked)
                        header += "\tENSG";
                    writer.WriteLine(header);

                    //首先查询miRNA-假和假基因信息，假基因名字对上的加入datatable
                    UpdateInfoLabel("正在查询" + cancer.Name + "的信息");
                    if (checkBox_ExportValue.Checked)
                    {
                        //输出value的话选的长的名字
                        writer_value = new StreamWriter(exportFile.FileName.Replace(".txt", "-" + cancer.Name + "-表达值.txt"));
                        writer_value.WriteLine(cancer.HeaderOfValueSheet);

                        var queryResults =
                            from p1 in results
                            from p2 in cancer.Pseudogenes
                            where p1.PseudogeneName.Contains(p2.Name)
                            select new { p2.Position, p2.ENSG, p2.RowString, p2.Name, p1.PseudogeneName, p1.miRNA, p1.mRNA };

                        foreach (var row in queryResults)
                        {
                            string line_write = row.mRNA + "\t" + row.miRNA + "\t" + row.Position + "\t" + row.PseudogeneName;
                            if (checkBox_ENSG.Checked)
                                line_write += "\t" + row.ENSG;
                            writer.WriteLine(line_write);
                            writer_value.WriteLine(row.RowString.Replace(row.Name, row.PseudogeneName));//长名换短名
                        }
                        writer_value.Close();
                    }
                    else
                    {
                        //不输出value的话选的短的名字
                        var queryResults =
                            (from p1 in results
                             from p2 in cancer.Pseudogenes
                             where p1.PseudogeneName.Contains(p2.Name)
                             select new { p2.Position, p2.ENSG, p2.Name, p1.miRNA, p1.mRNA }).Distinct();

                        foreach (var row in queryResults)
                        {
                            string line_write = row.mRNA + "\t" + row.miRNA + "\t" + row.Position + "\t" + row.Name;
                            if (checkBox_ENSG.Checked)
                                line_write += "\t" + row.ENSG;
                            writer.WriteLine(line_write);
                        }

                    }
                    writer.Close();
                }
            }
            else if (radioButton2.Checked)
            {
                foreach (Cancer cancer in list_Cancers)
                {
                    string currentPseudogeneName = "";
                    UpdateInfoLabel("正在查询" + cancer.Name + "的信息");
                    if (checkBox_ExportValue.Checked)
                    {
                        //输出value的话选的长的名字
                        var queryResults =
                            from p1 in results
                            from p2 in cancer.Pseudogenes
                            where p1.PseudogeneName.Contains(p2.Name)
                            orderby p1.PseudogeneName
                            select new { p2.Position, p2.ENSG, p2.RowString, p2.Name, p1.PseudogeneName, p1.miRNA, p1.mRNA };

                        foreach (var row in queryResults)
                        {
                            if ((currentPseudogeneName == "") || (currentPseudogeneName != row.PseudogeneName))
                            {
                                currentPseudogeneName = row.PseudogeneName;
                                if (writer != null)
                                    writer.Close();
                                if (writer_value != null)
                                    writer_value.Close();
                                writer = new StreamWriter(exportFile.FileName.Replace(".txt", "-" + cancer.Name + "-" + currentPseudogeneName + ".txt"));
                                string header = "mRNA\tmiRNA\tPosition\tPseudogeneName";
                                if (checkBox_ENSG.Checked)
                                    header += "\tENSG";
                                writer.WriteLine(header);

                                writer_value = new StreamWriter(exportFile.FileName.Replace(".txt", "-" + cancer.Name + "-" + currentPseudogeneName + "-表达值.txt"));
                                writer_value.WriteLine(cancer.HeaderOfValueSheet);
                            }

                            string line_write = row.mRNA + "\t" + row.miRNA + "\t" + row.Position + "\t" + row.PseudogeneName;
                            if (checkBox_ENSG.Checked)
                                line_write += "\t" + row.ENSG;
                            writer.WriteLine(line_write);
                            writer_value.WriteLine(row.RowString.Replace(row.Name, row.PseudogeneName));//长名换短名
                        }
                        //输出结束
                        if (writer_value != null)
                            writer_value.Close();
                    }
                    else
                    {
                        //不输出value的话选的短的名字
                        var queryResults =
                            (from p1 in results
                             from p2 in cancer.Pseudogenes
                             where p1.PseudogeneName.Contains(p2.Name)
                             orderby p1.PseudogeneName
                             select new { p2.Position, p2.ENSG, p2.Name, p1.miRNA, p1.mRNA }).Distinct();

                        foreach (var row in queryResults)
                        {
                            if ((currentPseudogeneName == "") || (currentPseudogeneName != row.Name))
                            {
                                currentPseudogeneName = row.Name;
                                if (writer != null)
                                    writer.Close();
                                writer = new StreamWriter(exportFile.FileName.Replace(".txt", "-" + cancer.Name + "-" + currentPseudogeneName + ".txt"));
                                string header = "mRNA\tmiRNA\tPosition\tPseudogeneName";
                                if (checkBox_ENSG.Checked)
                                    header += "\tENSG";
                                writer.WriteLine(header);
                            }

                            string line_write = row.mRNA + "\t" + row.miRNA + "\t" + row.Position + "\t" + row.Name;
                            if (checkBox_ENSG.Checked)
                                line_write += "\t" + row.ENSG;
                            writer.WriteLine(line_write);
                        }

                    }
                    if (writer != null)
                        writer.Close();
                }
            }
            

            UpdateInfoLabel("处理完毕");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            t.Restart();
            ReadData();
            StartWorking();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            t.Stop();
            MessageBox.Show("完成！用时" + t.ElapsedMilliseconds / 1000 + "s");
            button_SelectFile1.Enabled = true;
            button_SelectFile2.Enabled = true;
            button_SelectFile3.Enabled = true;
            button_SelectOutputFile.Enabled = true;
            button_Start.Enabled = true;
            checkBox_ENSG.Enabled = true;
            checkBox_ExportValue.Enabled = true;
        }

    }
}
