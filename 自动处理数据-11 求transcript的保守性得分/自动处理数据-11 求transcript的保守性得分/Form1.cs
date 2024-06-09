using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace 自动处理数据_11_求transcript的保守性得分
{
    public partial class Form1 : Form
    {
        private OpenFileDialog importFile1 = null, importFile2 = null, importFile3 = null, importFile_T2_1 = null, importFile_T2_2 = null;
        private SaveFileDialog exportFile = null, exportFile_T2 = null;
        private char[] splitter1 = new char[] { '\t' }, splitter2 = new char[] { ' ', '=' }, splitter3 = new char[] { '\t', ' ', '"', ';' };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton4.Checked = true;
            toolTip1.SetToolTip(label1, "用自动处理数据-10得到的已分类annotation文件（处理之前是.gtf文件）");
            toolTip1.SetToolTip(label2, "一般是.wigFix文件，也可以是.txt文件");
            toolTip1.SetToolTip(label9, "第二个Tab（Pseudo附近找PCG）处理后得到的文件");
            toolTip1.SetToolTip(textBox1, "用自动处理数据-10得到的已分类annotation文件（处理之前是.gtf文件）");
            toolTip1.SetToolTip(textBox2, "一般是.wigFix文件，也可以是.txt文件");
            toolTip1.SetToolTip(textBox3, "第二个Tab（Pseudo附近找PCG）处理后得到的文件");
            toolTip1.InitialDelay = 5;
        }

        //定义类
        class Annotation
        {
            public string Name { get; set; }
            public List<Gene> Genes { get; set; }

            public Annotation(string _name)
            {
                this.Name = _name;
                this.Genes = new List<Gene>();
            }
        }

        class Transcript
        {
            public string RowString { get; set; }
            public string Chr { get; set; }
            public string Name { get; set; }
            public long Start { get; set; }
            public long End { get; set; }
            public List<TSSubType> SubTypes { get; set; }

            public Transcript(string _rowstring, string _chr, long _start, long _end, string _name)
            {
                this.RowString = _rowstring;
                this.Chr = _chr;
                this.Start = _start;
                this.End = _end;
                this.Name = _name;
                this.SubTypes = new List<TSSubType>();
            }

            public Transcript(string _rowstring, string _chr, string _start, string _end, string _name)
            {
                this.RowString = _rowstring;
                this.Chr = _chr;
                this.Start = Convert.ToInt64(_start);
                this.End = Convert.ToInt64(_end);
                this.Name = _name;
                this.SubTypes = new List<TSSubType>();
            }
        }

        class Gene
        {
            public string RowString { get; set; }
            public string Chr { get; set; }
            public string Name { get; set; }
            public long Start { get; set; }
            public long End { get; set; }
            public List<Transcript> Transcripts { get; set; }

            public Gene(string _rowstring, string _chr, long _start, long _end, string _name)
            {
                this.RowString = _rowstring;
                this.Chr = _chr;
                this.Start = _start;
                this.End = _end;
                this.Name = _name;
                this.Transcripts = new List<Transcript>();
            }

            public Gene(string _rowstring, string _chr, string _start, string _end, string _name)
            {
                this.RowString = _rowstring;
                this.Chr = _chr;
                this.Start = Convert.ToInt64(_start);
                this.End = Convert.ToInt64(_end);
                this.Name = _name;
                this.Transcripts = new List<Transcript>();
            }
        }

        class TSSubType
        {
            public string Chr { get; set; }
            public long Start { get; set; }
            public long End { get; set; }
            public string SubType { get; set; }

            public TSSubType(string _chr, long _start, long _end, string _subtype)
            {
                this.Chr = _chr;
                this.Start = _start;
                this.End = _end;
                this.SubType = _subtype;
            }

            public TSSubType(string _chr, string _start, string _end, string _subtype)
            {
                this.Chr = _chr;
                this.Start = Convert.ToInt64(_start);
                this.End = Convert.ToInt64(_end);
                this.SubType = _subtype;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                checkBox_exon.Checked = true;
                checkBox_CDS.Checked = true;
                checkBox_UTR.Checked = true;
                checkBox_start_codon.Checked = true;
                checkBox_stop_codon.Checked = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                checkBox_exon.Checked = true;
                checkBox_CDS.Checked = true;
                checkBox_UTR.Checked = true;
                checkBox_start_codon.Checked = true;
                checkBox_stop_codon.Checked = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                checkBox_exon.Checked = true;
                checkBox_CDS.Checked = false;
                checkBox_UTR.Checked = false;
                checkBox_start_codon.Checked = false;
                checkBox_stop_codon.Checked = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                checkBox_exon.Checked = true;
                checkBox_CDS.Checked = true;
                checkBox_UTR.Checked = true;
                checkBox_start_codon.Checked = true;
                checkBox_stop_codon.Checked = true;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                checkBox_exon.Checked = true;
                checkBox_CDS.Checked = false;
                checkBox_UTR.Checked = false;
                checkBox_start_codon.Checked = false;
                checkBox_stop_codon.Checked = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = radioButton6.Checked;
            button_SelectFile3.Enabled = radioButton6.Checked;

            if (radioButton6.Checked)
            {
                checkBox_exon.Checked = true;
                checkBox_CDS.Checked = false;
                checkBox_UTR.Checked = false;
                checkBox_start_codon.Checked = false;
                checkBox_stop_codon.Checked = false;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = radioButton7.Checked;
            button_SelectFile3.Enabled = radioButton7.Checked;

            if (radioButton7.Checked)
            {
                checkBox_exon.Checked = true;
                checkBox_CDS.Checked = false;
                checkBox_UTR.Checked = false;
                checkBox_start_codon.Checked = false;
                checkBox_stop_codon.Checked = false;
            }
        }


        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = !radioButton8.Checked;
            button_SelectFile2.Enabled = !radioButton8.Checked;

            if (radioButton8.Checked)
            {
                checkBox_exon.Checked = true;
                checkBox_CDS.Checked = false;
                checkBox_UTR.Checked = false;
                checkBox_start_codon.Checked = false;
                checkBox_stop_codon.Checked = false;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = !radioButton9.Checked;
            button_SelectFile2.Enabled = !radioButton9.Checked;

            textBox3.Enabled = radioButton9.Checked;
            button_SelectFile3.Enabled = radioButton9.Checked;

            if (radioButton9.Checked)
            {
                checkBox_exon.Checked = true;
                checkBox_CDS.Checked = false;
                checkBox_UTR.Checked = false;
                checkBox_start_codon.Checked = false;
                checkBox_stop_codon.Checked = false;
            }
        }

        private void UpdateInfo(string text = "", bool clear = false, bool reset = false)
        {
            if (reset)
            {
                richTextBox_Info.Text = "等待开始";
                return;
            }

            if (clear)
            {
                richTextBox_Info.Text = "";
                return;
            }

            richTextBox_Info.Text += text;
            richTextBox_Info.Refresh();
            richTextBox_Info.Select(richTextBox_Info.TextLength, 0);
            richTextBox_Info.ScrollToCaret();
        }

        private void button_SelectFile1_Click(object sender, EventArgs e)
        {
            importFile1 = new OpenFileDialog();
            importFile1.Multiselect = true;
            importFile1.Filter = "已分类的annotation（*.txt）|*.txt";

            var result = importFile1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (importFile1.FileNames.Length == 1)
                    textBox1.Text = importFile1.FileName;
                else if (importFile1.FileNames.Length > 1)
                    textBox1.Text = importFile1.FileName + " 等" + importFile1.FileNames.Length + "个文件";
            }
        }

        private void button_SelectFile2_Click(object sender, EventArgs e)
        {
            importFile2 = new OpenFileDialog();
            importFile2.Multiselect = true;
            importFile2.Filter = "保守性分数文件（*.wigFix）|*.wigFix|保守性分数文件（*.txt）|*.txt";

            var result = importFile2.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (importFile2.FileNames.Length == 1)
                    textBox2.Text = importFile2.FileName;
                else if (importFile2.FileNames.Length > 1)
                    textBox2.Text = importFile2.FileName + " 等" + importFile2.FileNames.Length + "个文件";
            }
        }

        private void button_SelectFile3_Click(object sender, EventArgs e)
        {
            importFile3 = new OpenFileDialog();
            importFile3.Multiselect = false;
            importFile3.Filter = "Tab2的输出文件：Pseudo附近PCG（*.txt）|*.txt";

            var result = importFile3.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (importFile3.FileNames.Length == 1)
                    textBox3.Text = importFile3.FileName;
                else if (importFile3.FileNames.Length > 1)
                    textBox3.Text = importFile3.FileName + " 等" + importFile3.FileNames.Length + "个文件";
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
            //先每次读一个保守性得分，再分别读取annotation文件
            //textBox1
            if (textBox1.Text == "")
            {
                MessageBox.Show("还没选择已分类annotation文件！");
                return;
            }

            //textBox2
            if ((!radioButton8.Checked) && (!radioButton9.Checked) && (textBox2.Text == ""))
            {
                MessageBox.Show("还没选择保守性分数文件！");
                return;
            }

            //textBox3
            if (((radioButton6.Checked) || (radioButton7.Checked) || (radioButton9.Checked)) && (textBox3.Text == ""))
            {
                MessageBox.Show("还没选择Tab2的输出文件（Pseudo及附近PCG）！");
                return;
            }

            //textBox_OutputFile
            if (textBox_OutputFile.Text == "")
            {
                MessageBox.Show("还没选择输出文件！");
                return;
            }

            Stopwatch t = new Stopwatch();
            t.Restart();
            UpdateInfo("", true, false);
            UpdateInfo("工作开始");
            bool success = StartWorking();
            t.Stop();

            if (success)
            {
                UpdateInfo("\n共用时" + t.ElapsedMilliseconds / 1000 + "s");
                MessageBox.Show("输出完成！共用时" + t.ElapsedMilliseconds / 1000 + "s");
            }
            else
            {
                UpdateInfo("\n遇到错误，程序停止");
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private string GetValue(string searchKey, string rowString)
        {
            string[] row_split = rowString.Split(splitter3, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < row_split.Length - 1; i++)
            {
                if (row_split[i] == searchKey)
                    return row_split[i + 1];
            }
            return "";
        }
        
        private bool StartWorking()
        {
            //读取Tab2的输出文件，选项6、7、9用
            #region 读取Tab2的输出文件
            DataTable pseudogeneData = new DataTable(), pcgData = new DataTable(); //Data存放原始数据
            Hashtable pseudogeneHash = new Hashtable(), pcgHash = new Hashtable(); //Hash存放单个Name和最终计算Conservative Value
            if ((radioButton6.Checked) || (radioButton7.Checked) || (radioButton9.Checked))
            {
                //读取Tab2的输出文件
                UpdateInfo("\n正在读取" + Path.GetFileName(importFile3.FileName) + "...");
                StreamReader reader = new StreamReader(importFile3.FileName);
                string row = reader.ReadLine();
                string[] row_split = row.Split(splitter1);
                if (row != "pseudogene\tchr\tstart\tend\tstrand\tpcg\tchr\tstart\tend\tstrand")
                {
                    MessageBox.Show("所选文件并非Tab2的输出文件！请确保文件包含表头并由依次以下列构成：\n" +
                                    "pseudogene chr start end strand pcg chr start end strand");
                    return false;
                }

                for (int i = 0; i < 5; i++)
                    pseudogeneData.Columns.Add(row_split[i]);
                for (int i = 5; i < 10; i++)
                    pcgData.Columns.Add(row_split[i]);

                while (!reader.EndOfStream)
                {
                    row = reader.ReadLine();
                    row_split = row.Split(splitter1);

                    pseudogeneData.Rows.Add(row_split[0], row_split[1], row_split[2], row_split[3], row_split[4]);
                    pcgData.Rows.Add(row_split[5], row_split[6], row_split[7], row_split[8], row_split[9]);

                    if (!pseudogeneHash.Contains(row_split[0]))
                    {
                        pseudogeneHash.Add(row_split[0], 0);
                    }
                    if (!pcgHash.Contains(row_split[5]))
                    {
                        pcgHash.Add(row_split[5], 0);
                    }
                }
                reader.Close();
                UpdateInfo("完毕");
            }
            #endregion

            //读取annotation文件
            #region 读取annotation文件
            List<Annotation> annotations = new List<Annotation>();
            if (true)
            {
                for (int i = 0; i < importFile1.FileNames.Length; i++)
                {
                    UpdateInfo("\n正在读取" + Path.GetFileName(importFile1.FileNames[i]) + "...");
                    StreamReader reader_annotation = new StreamReader(importFile1.FileNames[i]);
                    string row = "";
                    string[] row_split = null;

                    Annotation anno = new Annotation(Path.GetFileNameWithoutExtension(importFile1.FileNames[i]));
                        //单个annotation
                    Transcript ts = null;
                    Gene gene = null;
                    while (!reader_annotation.EndOfStream)
                    {
                        row = reader_annotation.ReadLine();
                        row_split = row.Split(splitter1, StringSplitOptions.RemoveEmptyEntries);
                        if (row_split[2] == "gene")
                        {
                            if (gene != null)
                            {
                                gene.Transcripts.Add(ts);
                                ts = null;
                                anno.Genes.Add(gene);
                            }
                            gene = new Gene(row, row_split[0], row_split[3], row_split[4], GetValue("gene_name", row));
                        }
                        else if (row_split[2] == "transcript")
                        {
                            if (ts != null)
                                gene.Transcripts.Add(ts); //加入之前加好SubTypes的Transcript
                            ts = new Transcript(row, row_split[0], row_split[3], row_split[4],
                                GetValue("transcript_name", row));
                        }
                        else if ((row_split[2] == "exon") || (row_split[2] == "CDS") || (row_split[2] == "UTR") ||
                                 (row_split[2] == "start_codon") || (row_split[2] == "stop_codon"))
                        {
                            ts.SubTypes.Add(new TSSubType(row_split[0], row_split[3], row_split[4], row_split[2]));
                                //加入当前Transcript的SubTypes列表中
                        }
                    }
                    //收尾工作：最后一行是exon，把最后一个Transcript加进去
                    if ((row_split[2] == "exon") || (row_split[2] == "CDS") || (row_split[2] == "UTR") ||
                        (row_split[2] == "start_codon") || (row_split[2] == "stop_codon"))
                    {
                        gene.Transcripts.Add(ts);
                        anno.Genes.Add(gene);
                    }
                    reader_annotation.Close(); //关闭文件
                    annotations.Add(anno); //读取完一个annotation，加入到annotations列表中
                    UpdateInfo("完毕");
                }
            }
            #endregion

            //计算保守性分数，选项1、2、3、4、5、6、7用
            #region 处理保守性分数文件，每读一个处理一个
            if ((!radioButton8.Checked) && (!radioButton9.Checked))
            {
                bool header = true;
                for (int i = 0; i < importFile2.FileNames.Length; i++)
                {
                    //读取
                    #region 读取保守性分数文件
                    UpdateInfo("\n正在读取" + Path.GetFileName(importFile2.FileNames[i]) + "中的分数...");
                    StreamReader reader_points = new StreamReader(importFile2.FileNames[i]);
                    double[] points = new double[250000000]; //当前chr保守性分数
                    for (long p = 0; p < 250000000; p++) points[p] = -1;
                    long n = 1, step = 1;
                    string row = "", currentChr = "";
                    while (!reader_points.EndOfStream)
                    {
                        row = reader_points.ReadLine();
                        if (row.Length > 5) //为分隔行，形如fixedStep chrom=chr2 start=11517 step=1
                        {
                            string[] partInfo = row.Split(splitter2, StringSplitOptions.RemoveEmptyEntries);
                            n = Convert.ToInt64(partInfo[4]);
                            step = Convert.ToInt64(partInfo[6]);
                            currentChr = partInfo[2];
                            continue;
                        }
                        else //为分数行
                        {
                            points[n] = Convert.ToDouble(row);
                            n += step;
                        }
                    }
                    //单个保守性分数文件读取完成
                    reader_points.Close(); //关闭文件
                    UpdateInfo("完毕");
                    #endregion

                    //处理数据
                    int count = 0;
                    UpdateInfo("\n正在根据" + Path.GetFileName(importFile2.FileNames[i]) + "计算分数...");

                    //处理Pseudo附近PCG
                    #region 选项7
                    if (radioButton7.Checked)
                    {
                        StreamWriter writer = new StreamWriter(exportFile.FileName, true); //追加而不是覆盖
                        if (header)
                        {
                            writer.WriteLine("Gene\tValue");
                        }
                        foreach (Annotation annotation in annotations)
                        {
                            //每个annotation依次处理
                            Hashtable ht = null;
                            //PCG
                            if ((annotation.Name.ToLower().Contains("protein")) ||
                                (annotation.Name.ToLower().Contains("pcg")) ||
                                (annotation.Name.ToLower().Contains("mrna")))
                                ht = pcgHash;
                            //Pseudo
                            else if (annotation.Name.ToLower().Contains("pseudogene"))
                                ht = pseudogeneHash;
                            //Other
                            else
                                continue;

                            foreach (Gene gene in annotation.Genes)
                            {
                                if (gene.Chr != currentChr)
                                    continue;
                                if (!ht.Contains(gene.Name))
                                    continue;

                                foreach (Transcript transcript in gene.Transcripts)
                                {
                                    //只要分数和类型，exon或所有subtypes，每个输出一行
                                    foreach (TSSubType subType in transcript.SubTypes)
                                    {
                                        if (subType.SubType != "exon")
                                            continue;
                                        double totalPoint = 0.0, averagePoint = 0.0;
                                        long totalLength = subType.End - subType.Start + 1;
                                        for (long k = subType.Start; k <= subType.End; k++)
                                            if (points[k] == -1)
                                                totalLength += -1;
                                            else
                                                totalPoint += points[k];
                                        if (totalLength <= 0)
                                            writer.WriteLine(annotation.Name + "\t0");
                                        else
                                        {
                                            averagePoint = totalPoint/totalLength;
                                            writer.WriteLine(annotation.Name + "\t" + averagePoint.ToString("F3"));
                                            //只要分数和类型
                                        }
                                    }
                                }
                            }
                        }
                        writer.Close();
                    }
                    #endregion
                    #region 选项6
                    else if (radioButton6.Checked)
                    {
                        //计算，结果全部放在Hashtable中
                        foreach (var annotation in annotations)
                        {
                            Hashtable ht = null;
                            //PCG
                            if ((annotation.Name.ToLower().Contains("protein")) ||
                                (annotation.Name.ToLower().Contains("pcg")) ||
                                (annotation.Name.ToLower().Contains("mrna")))
                                ht = pcgHash;
                            //Pseudo
                            else if (annotation.Name.ToLower().Contains("pseudogene"))
                                ht = pseudogeneHash;
                            //Other
                            else
                                continue;

                            foreach (Gene gene in annotation.Genes)
                            {
                                if (gene.Chr != currentChr)
                                    continue;
                                if (!ht.Contains(gene.Name))
                                    continue;

                                double totalPoint = 0.0, averagePoint = 0.0;
                                long totalLength = 0;
                                foreach (Transcript transcript in gene.Transcripts)
                                {
                                    foreach (TSSubType subType in transcript.SubTypes)
                                    {
                                        if (subType.SubType != "exon")
                                            continue;
                                        totalLength += subType.End - subType.Start + 1;
                                        for (long k = subType.Start; k <= subType.End; k++)
                                            if (points[k] == -1)
                                                totalLength += -1;
                                            else
                                                totalPoint += points[k];
                                    }
                                }

                                if (totalLength <= 0)
                                    averagePoint = 0;
                                else
                                    averagePoint = totalPoint/totalLength;

                                ht[gene.Name] = averagePoint; //将分数记录在HashTable里
                            }

                            //PCG
                            if ((annotation.Name.ToLower().Contains("protein")) ||
                                (annotation.Name.ToLower().Contains("pcg")) ||
                                (annotation.Name.ToLower().Contains("mrna")))
                                pcgHash = ht;
                            //Pseudo
                            else if (annotation.Name.ToLower().Contains("pseudogene"))
                                pseudogeneHash = ht;
                        }

                        //输出
                        StreamWriter writer = new StreamWriter(exportFile.FileName);
                        writer.WriteLine(
                            "pseudogene\tchr\tstart\tend\tstrand\tconservative_value\tpcg\tchr\tstart\tend\tstrand\tconservative_value");
                        string rowOutput = "";
                        for (int k = 0; k < pseudogeneData.Rows.Count; k++)
                        {
                            rowOutput = pseudogeneData.Rows[k]["pseudogene"] + "\t" + pseudogeneData.Rows[k]["chr"] +
                                        "\t" +
                                        pseudogeneData.Rows[k]["start"] + "\t" + pseudogeneData.Rows[k]["end"] + "\t" +
                                        pseudogeneData.Rows[k]["strand"] + "\t" +
                                        pseudogeneHash[pseudogeneData.Rows[k]["pseudogene"].ToString()] + "\t" +
                                        pcgData.Rows[k]["pcg"] + "\t" + pcgData.Rows[k]["chr"] + "\t" +
                                        pcgData.Rows[k]["start"] + "\t" + pcgData.Rows[k]["end"] + "\t" +
                                        pcgData.Rows[k]["strand"] + "\t" +
                                        pcgHash[pcgData.Rows[k]["pcg"].ToString()];
                            writer.WriteLine(rowOutput);
                        }
                        writer.Close();
                    }
                    #endregion
                    //处理annotation
                    #region 选项1、2、3、4、5
                    else
                    {
                        foreach (Annotation annotation in annotations)
                        {
                            //每个annotation依次处理
                            count++;
                            UpdateInfo(count.ToString() + "...");
                            StreamWriter writer =
                                new StreamWriter(exportFile.FileName.Replace(".txt", "-" + annotation.Name + ".txt"),
                                    true);
                            //追加而不是覆盖
                            if (header)
                            {
                                writer.WriteLine("Gene\tValue");
                            }
                            #region 选项5
                            if (radioButton5.Checked) //gene，只要exon
                            {
                                foreach (Gene gene in annotation.Genes)
                                {
                                    if (gene.Chr != currentChr)
                                        continue;
                                    double totalPoint = 0.0, averagePoint = 0.0;
                                    long totalLength = 0;
                                    foreach (Transcript transcript in gene.Transcripts)
                                    {
                                        foreach (TSSubType subType in transcript.SubTypes)
                                        {
                                            if (subType.SubType != "exon")
                                                continue;
                                            totalLength += subType.End - subType.Start + 1;
                                            for (long k = subType.Start; k <= subType.End; k++)
                                                if (points[k] == -1)
                                                    totalLength += -1;
                                                else
                                                    totalPoint += points[k];
                                        }
                                    }

                                    if (totalLength <= 0)
                                        writer.WriteLine(annotation.Name + "\t0");
                                    else
                                    {
                                        averagePoint = totalPoint/totalLength;
                                        writer.WriteLine(annotation.Name + "\t" + averagePoint.ToString("F3"));
                                            //只要分数和类型
                                    }
                                }
                            }
                            #endregion
                            #region 选项1、2、3、4
                            else
                            {
                                foreach (Gene gene in annotation.Genes)
                                {
                                    if (gene.Chr != currentChr)
                                        continue;
                                    foreach (Transcript transcript in gene.Transcripts)
                                    {
                                        #region 选项3、4
                                        if ((radioButton3.Checked) || (radioButton4.Checked))
                                            //只要分数和类型，exon或所有subtypes，每个输出一行
                                        {
                                            foreach (TSSubType subType in transcript.SubTypes)
                                            {
                                                if (radioButton3.Checked)
                                                {
                                                    if (subType.SubType != "exon")
                                                        continue;
                                                }
                                                double totalPoint = 0.0, averagePoint = 0.0;
                                                long totalLength = subType.End - subType.Start + 1;
                                                for (long k = subType.Start; k <= subType.End; k++)
                                                    if (points[k] == -1)
                                                        totalLength += -1;
                                                    else
                                                        totalPoint += points[k];
                                                if (totalLength <= 0)
                                                    writer.WriteLine(annotation.Name + "\t0");
                                                else
                                                {
                                                    averagePoint = totalPoint/totalLength;
                                                    writer.WriteLine(annotation.Name + "\t" +
                                                                     averagePoint.ToString("F3"));
                                                    //只要分数和类型
                                                }
                                            }
                                        }
                                        #endregion
                                        #region 选项1、2
                                        else if ((radioButton1.Checked) || (radioButton2.Checked))
                                            //transctipt下的subtypes（exon、CDS、UTR……）全都要
                                        {
                                            double totalPoint = 0.0, averagePoint = 0.0;
                                            long totalLength = 0;
                                            foreach (TSSubType subType in transcript.SubTypes)
                                            {
                                                totalLength += subType.End - subType.Start + 1;
                                                for (long k = subType.Start; k <= subType.End; k++)
                                                    if (points[k] == -1)
                                                        totalLength += -1;
                                                    else
                                                        totalPoint += points[k];
                                            }
                                            if (totalLength <= 0)
                                                writer.WriteLine(annotation.Name + "\t0");
                                            else
                                            {
                                                averagePoint = totalPoint/totalLength;

                                                if (radioButton2.Checked)
                                                    writer.WriteLine(annotation.Name + "\t" +
                                                                     averagePoint.ToString("F3"));
                                                //只要分数和类型
                                                else
                                                    writer.WriteLine(averagePoint.ToString("F3") + "\t" +
                                                                     transcript.RowString); //所有信息
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                            writer.Close();
                        }
                    }
                    #endregion
                    UpdateInfo("完毕");
                    header = false;
                }
            }

            #endregion

            //合并结果，选项1、2、3、4、5用
            #region 合并结果
            if ((!radioButton6.Checked) && (!radioButton7.Checked) && (!radioButton8.Checked) && (!radioButton9.Checked))
            {
                //将三个文件合并为一个文件
                UpdateInfo("\n正在合并结果...");
                int count2 = 0;
                StreamWriter writer2 = new StreamWriter(exportFile.FileName.Replace(".txt", "-all.txt"));
                writer2.WriteLine("Gene\tValue");
                foreach (var annotation in annotations)
                {
                    count2++;
                    UpdateInfo(count2.ToString() + "...");
                    StreamReader reader2 =
                        new StreamReader(exportFile.FileName.Replace(".txt", "-" + annotation.Name + ".txt"));
                    reader2.ReadLine(); //去掉表头
                    while (!reader2.EndOfStream)
                    {
                        writer2.WriteLine(reader2.ReadLine());
                    }
                    reader2.Close();
                }
                writer2.Close();
                UpdateInfo("完毕");
            }
            #endregion

            //计exon数，选项8：annotation
            #region 计exon数，annotation
            if (radioButton8.Checked)
            {
                UpdateInfo("\n正在计数...");
                int count = 0;
                foreach (Annotation annotation in annotations)
                {
                    //每个annotation依次处理
                    count++;
                    UpdateInfo(count.ToString() + "...");
                    StreamWriter writer = new StreamWriter(exportFile.FileName.Replace(Path.GetFileNameWithoutExtension(exportFile.FileName), "exon数量-" + Path.GetFileNameWithoutExtension(exportFile.FileName) + "-" + annotation.Name));
                    foreach (Gene gene in annotation.Genes)
                    {
                        long totalExonNo = 0;
                        foreach (Transcript transcript in gene.Transcripts)
                        {
                            foreach (TSSubType subType in transcript.SubTypes)
                            {
                                if (subType.SubType == "exon")
                                    totalExonNo++;
                            }
                        }
                        writer.WriteLine(totalExonNo);
                    }
                    writer.Close();
                }
                UpdateInfo("完毕");
            }

            #endregion

            //计exon数，选项9：Pseudo附近PCG
            #region 计exon数，Pseudo附近PCG
            if (radioButton9.Checked)
            {
                UpdateInfo("\n正在计数...");
                int count = 0;
                foreach (Annotation annotation in annotations)
                {
                    //每个annotation依次处理
                    count++;
                    UpdateInfo(count.ToString() + "...");
                    Hashtable ht = null;
                    string tableName = "";
                    //PCG
                    if ((annotation.Name.ToLower().Contains("protein")) ||
                        (annotation.Name.ToLower().Contains("pcg")) ||
                        (annotation.Name.ToLower().Contains("mrna")))
                    {
                        ht = pcgHash;
                        tableName = "PCG";
                    }
                    //Pseudo
                    else if (annotation.Name.ToLower().Contains("pseudogene"))
                    {
                        ht = pseudogeneHash;
                        tableName = "Pseudo";
                    }
                    //Other
                    else
                        continue;

                    StreamWriter writer = new StreamWriter(exportFile.FileName.Replace(Path.GetFileNameWithoutExtension(exportFile.FileName), "exon数量-" + Path.GetFileNameWithoutExtension(exportFile.FileName) + "-" + tableName));
                    foreach (Gene gene in annotation.Genes)
                    {
                        if (!ht.Contains(gene.Name))
                            continue;
                        long totalExonNo = 0;
                        foreach (Transcript transcript in gene.Transcripts)
                        {
                            foreach (TSSubType subType in transcript.SubTypes)
                            {
                                if (subType.SubType == "exon")
                                    totalExonNo++;
                            }
                        }
                        writer.WriteLine(totalExonNo);
                    }
                    writer.Close();
                }
                UpdateInfo("完毕");
            }
            #endregion

            return true;
        }

        private void button_T2_SelectFile1_Click(object sender, EventArgs e)
        {
            importFile_T2_1 = new OpenFileDialog();
            importFile_T2_1.Multiselect = true;
            importFile_T2_1.Filter = "Pseudogene（五列，带表头）|*.txt";

            var result = importFile_T2_1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_T2_1.Text = importFile_T2_1.FileName;;
            }
        }

        private void button_T2_SelectFile2_Click(object sender, EventArgs e)
        {
            importFile_T2_2 = new OpenFileDialog();
            importFile_T2_2.Multiselect = true;
            importFile_T2_2.Filter = "PCG annotation（五列，带表头）|*.txt";

            var result = importFile_T2_2.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_T2_2.Text = importFile_T2_2.FileName; ;
            }
        }

        private void button_T2_SelectOutputFile_Click(object sender, EventArgs e)
        {
            exportFile_T2 = new SaveFileDialog();
            exportFile_T2.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = exportFile_T2.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_T2_OutputFile.Text = exportFile_T2.FileName;
            }
        }

        private void button_T2_Start_Click(object sender, EventArgs e)
        {
            //textBox_T2_1
            if (textBox_T2_1.Text == "")
            {
                MessageBox.Show("还没选择Pseudogene文件！");
                return;
            }

            //textBox2
            if (textBox_T2_2.Text == "")
            {
                MessageBox.Show("还没选择PCG annotation文件！");
                return;
            }

            //textBox_T2_OutputFile
            if (textBox_T2_OutputFile.Text == "")
            {
                MessageBox.Show("还没选择输出文件！");
                return;
            }

            Stopwatch t = new Stopwatch();
            t.Restart();
            UpdateInfo("", true, false);
            UpdateInfo("工作开始");
            bool success = StartWorking_T2();
            t.Stop();

            if (success)
            {
                UpdateInfo("\n共用时" + t.ElapsedMilliseconds / 1000 + "s");
                MessageBox.Show("输出完成！共用时" + t.ElapsedMilliseconds / 1000 + "s");
            }
            else
            {
                UpdateInfo("\n遇到错误，程序停止");
            }
        }

        private bool StartWorking_T2()
        {
            DataTable pseudogene = new DataTable(), pcg = new DataTable();

            //pseudogene
            UpdateInfo("\n正在读取Pseudogene文件...");
            StreamReader reader = new StreamReader(importFile_T2_1.FileName);
            //读表头
            string row = reader.ReadLine();
            string[] row_split = row.Split(splitter1, StringSplitOptions.RemoveEmptyEntries);
            foreach (string columnTitle in row_split)
                pseudogene.Columns.Add(columnTitle);
            //读数据
            while (!reader.EndOfStream)
            {
                row = reader.ReadLine();
                row_split = row.Split(splitter1, StringSplitOptions.RemoveEmptyEntries);
                pseudogene.Rows.Add(row_split);
            }
            reader.Close();
            UpdateInfo("完毕");

            //pcg
            UpdateInfo("\n正在读取PCG annotation文件...");
            reader = new StreamReader(importFile_T2_2.FileName);
            //读表头
            row = reader.ReadLine();
            row_split = row.Split(splitter1, StringSplitOptions.RemoveEmptyEntries);
            foreach (string columnTitle in row_split)
                pcg.Columns.Add(columnTitle);
            //读数据
            while (!reader.EndOfStream)
            {
                row = reader.ReadLine();
                row_split = row.Split(splitter1, StringSplitOptions.RemoveEmptyEntries);
                pcg.Rows.Add(row_split);
            }
            reader.Close();
            UpdateInfo("完毕");


            //寻找pseudogene前后范围内的pcg
            UpdateInfo("\n正在输出Pseudogene前后范围内的PCG...");
            StreamWriter writer = new StreamWriter(exportFile_T2.FileName);
            long former = Convert.ToInt64(numericUpDown1.Value) * 1000, latter = Convert.ToInt64(numericUpDown2.Value) * 1000;
            //写表头
            writer.WriteLine("pseudogene\tchr\tstart\tend\tstrand\tpcg\tchr\tstart\tend\tstrand");
            foreach (DataRow row_pseudogene in pseudogene.Rows)
            {
                long pseudoStart = Convert.ToInt64(row_pseudogene["start"]), pseudoEnd = Convert.ToInt64(row_pseudogene["end"]);
                foreach (DataRow row_pcg in pcg.Select("chr='" + row_pseudogene["chr"] + "'"))
                {
                    long pcgStart = Convert.ToInt64(row_pcg["start"]), pcgEnd = Convert.ToInt64(row_pcg["end"]);
                    if (((pcgEnd >= pseudoStart - former) && (pcgEnd <= pseudoEnd + latter)) ||
                        ((pcgStart >= pseudoStart - former) && (pcgStart <= pseudoEnd + latter)))
                    {
                        //满足条件，输出
                        writer.WriteLine(row_pseudogene["pseudogene"] + "\t" + row_pseudogene["chr"] + "\t" +
                                         pseudoStart + "\t" + pseudoEnd + "\t" + row_pseudogene["strand"] + "\t" +
                                         row_pcg["pcg"] + "\t" + row_pcg["chr"] + "\t" + pcgStart + "\t" + pcgEnd + "\t" +
                                         row_pcg["strand"]);
                    }
                }
            }
            writer.Close();
            UpdateInfo("完毕");

            return true;
        }

    }
}
