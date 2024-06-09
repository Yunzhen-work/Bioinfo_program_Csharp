using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace 自动处理数据_5
{
    public partial class Form1 : Form
    {
        private OpenFileDialog importFile1 = null, importFile2 = null, importFile3 = null, importFile4 = null;
        private SaveFileDialog exportFile = null;
        private DataTable dt_level2 = null, dt_level3 = null;
        private List<string> methyPositionList = null;
        private string errorMessage = "";

        private char[] splitter1 = new char[] { '\t' }, splitter2 = new char[] { ' ', '=' }, splitter3 = new char[] { '\t', ' ', '"', ';' };

        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(checkBox_MethyPosition, "单列（例：cg00000001），无表头");
            toolTip1.SetToolTip(textBox1, "单列（例：cg00000001），无表头");
            toolTip1.SetToolTip(checkBox_level2, "level2和level3可同时做");
            toolTip1.SetToolTip(checkBox_level3, "level2和level3可同时做");
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
            if (importFile1 == null)
            {
                importFile1 = new OpenFileDialog();
                importFile1.Multiselect = false;
                importFile1.Filter = "txt制表符分隔（*.txt）|*.txt";
            }

            var result = importFile1.ShowDialog();
            //if (result == DialogResult.OK)
            {
                textBox1.Text = importFile1.FileName;
            }
            //else
            //    textBox1.Text = "";
        }

        private void button_SelectFile2_Click(object sender, EventArgs e)
        {
            if (importFile2 == null)
            {
                importFile2 = new OpenFileDialog();
                importFile2.Multiselect = true;
                importFile2.Filter = "txt制表符分隔（*.txt）|*.txt";
            }

            var result = importFile2.ShowDialog();
            //if (result == DialogResult.OK)
            if (importFile2.FileNames.Length > 0)
            {
                textBox2.Text = importFile2.FileNames[0] + " 等" + importFile2.FileNames.Length + "个文件";
            }
            else
                textBox2.Text = "";
        }

        private void button_SelectFile3_Click(object sender, EventArgs e)
        {
            if (importFile3 == null)
            {
                importFile3 = new OpenFileDialog();
                importFile3.Multiselect = true;
                importFile3.Filter = "txt制表符分隔（*.txt）|*.txt";
            }

            var result = importFile3.ShowDialog();
            //if (result == DialogResult.OK)
            if (importFile3.FileNames.Length > 0)
            {
                textBox3.Text = importFile3.FileNames[0] + " 等" + importFile3.FileNames.Length + "个文件";

                exportFile = new SaveFileDialog();
                exportFile.FileName = importFile3.FileNames[0].Replace(".txt", "-level3.txt");
                textBox5.Text = exportFile.FileName;

            }
            //else
            //    textBox3.Text = "";
        }

        private void button_SelectFile4_Click(object sender, EventArgs e)
        {
            if (importFile4 == null)
            {
                importFile4 = new OpenFileDialog();
                importFile4.Multiselect = false;
                importFile4.Filter = "txt制表符分隔（*.txt）|*.txt";
            }

            var result = importFile4.ShowDialog();
            //if (result == DialogResult.OK)
            if (importFile4.FileNames.Length > 0)
            {
                textBox4.Text = importFile4.FileName;

                exportFile = new SaveFileDialog();
                exportFile.FileName = importFile4.FileName.Replace(".txt", "_merged_Selected.txt");
                textBox5.Text = exportFile.FileName;
            }
        }

        private void button_SelectOutputFile_Click(object sender, EventArgs e)
        {
            if (exportFile == null)
            {
                exportFile = new SaveFileDialog();
                exportFile.Filter = "txt制表符分隔（*.txt）|*.txt";
            }

            var result = exportFile.ShowDialog();
            //if (result == DialogResult.OK)
            {
                textBox5.Text = exportFile.FileName;
            }
            //else
            //    textBox5.Text = "";
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            //textBox1
            if ((checkBox_MethyPosition.Checked) && (textBox1.Text == ""))
            {
                MessageBox.Show("还没选择甲基化位点文件！");
                return;
            }

            //textBox2
            if ((checkBox_level2.Checked) && (textBox2.Text == ""))
            {
                MessageBox.Show("还没选择level2的cg表达值文件！");
                return;
            }

            //textBox3
            if ((checkBox_level3.Checked) && (textBox3.Text == ""))
            {
                MessageBox.Show("还没选择level3的cg表达值文件！");
                return;
            }

            //textBox4
            if ((checkBox_mergedLevel3.Checked) && (textBox4.Text == ""))
            {
                MessageBox.Show("还没选择合并后的level3的cg表达值文件！");
                return;
            }

            //level2和level3都不选
            if ((!checkBox_level2.Checked) && (!checkBox_level3.Checked) && (!checkBox_mergedLevel3.Checked))
            {
                MessageBox.Show("level2和level3都不选？");
                return;
            }

            //textBox5
            if (textBox5.Text == "")
            {
                MessageBox.Show("还没选择输出文件！");
                return;
            }

            UpdateInfo("", true);

            Stopwatch t = new Stopwatch();
            
            t.Reset();
            t.Start();

            methyPositionList = null;
            if (checkBox_MethyPosition.Checked)
                ReadMethyExpPosition();

            //if (checkBox_level2.Checked)
            //{
            //   Work_Level2();
            //}

            if (checkBox_level3.Checked)
            {
                Work_Level3();
            }

            if (checkBox_mergedLevel3.Checked)
            {
                Work_MergedLevel3();
            }

            t.Stop();

            
             UpdateInfo("\n处理完成，共用时" + (t.ElapsedMilliseconds / 1000M).ToString("F1") + "s");
             MessageBox.Show("处理完成，共用时" + (t.ElapsedMilliseconds / 1000M).ToString("F1") + "s");
            
        }

        private void ReadMethyExpPosition()
        {
            StreamReader reader = new StreamReader(importFile1.FileName);
            string row = null;
            methyPositionList = new List<string>();

            while (!reader.EndOfStream)
            {
                row = reader.ReadLine();
                //if (!methyPositionList.Contains(row))
                    methyPositionList.Add(row);
            }
            reader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox_MethyPosition.Checked = true;
            checkBox_level2.Checked = true;
            checkBox_level3.Checked = true;
            checkBox_MethyPosition.Checked = true;

            checkBox_MethyPosition.Checked = false;
            checkBox_level2.Checked = false;
            checkBox_level3.Checked = false;
            checkBox_MethyPosition.Checked = false;
        }

        private void checkBox_level2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox_level2.Checked;
            button_SelectFile2.Enabled = checkBox_level2.Checked;
        }

        private void checkBox_level3_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = checkBox_level3.Checked;
            button_SelectFile3.Enabled = checkBox_level3.Checked;
        }

        private void checkBox_mergedLevel3_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = checkBox_mergedLevel3.Checked;
            button_SelectFile4.Enabled = checkBox_mergedLevel3.Checked;
            
            if (checkBox_mergedLevel3.Checked)
                checkBox_MethyPosition.Checked = true;
        }

        private void checkBox_MethyPosition_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox_MethyPosition.Checked;
            button_SelectFile1.Enabled = checkBox_MethyPosition.Checked;

            if (!checkBox_MethyPosition.Checked)
                checkBox_mergedLevel3.Checked = false;
        }

        private bool Work_Level2()
        {

            return true;
        }

        private bool Work_Level3()
        {
            UpdateInfo("\n正在处理level3文件...");
            //第读取一个文件时，把共同部分提取出来，即除Beta_value以外的4列
            //Composite Element REF	Beta_value	Gene_Symbol	Chromosome	Genomic_Coordinate
            bool firstFile = true;
            List<string> outputList = new List<string>(), sampleCodeList = new List<string>();
            
            for (int i = 0; i < importFile3.FileNames.Length; i++)
            {
                UpdateInfo("\n正在读取level3文件...第" + (i+1) + "个，共" + importFile3.FileNames.Length + "个...");
                StreamReader reader = new StreamReader(importFile3.FileNames[i]);
                //第一行包含TCGA信息，提取之
                string row = reader.ReadLine();
                string[] row_split = row.Split(splitter1);
                if ((!row.Contains("Hybridization REF")) || (row_split.Length != 5))
                {
                    errorMessage = "文件" + importFile3.FileName[i] + "不是level3文件！\nlevel3文件第一行应为如下的表头：\nHybridization REF 及连续4个相同的TCGA长SampleCode";
                    UpdateInfo("\n" + errorMessage);
                    MessageBox.Show(errorMessage);
                    reader.Close();
                    return false;
                }
                //获取SampleCode
                string sampleCode_Long = row_split[1]; //长码例：TCGA-44-2655-11A-01D-1551-05，共28字符
                string sampleCode_Short = sampleCode_Long.Remove(15); //短码例：TCGA-44-2655-11，共15字符，保留0~14

                //如果短码有重复的就不要后面的了
                UpdateInfo("短码：" + sampleCode_Short);
                if (sampleCodeList.Contains(sampleCode_Short))
                {
                    UpdateInfo("有重复，跳过");
                    continue;
                }

                //第二行包含表头信息，若firstFile = true则新建List并提取表头信息
                row = reader.ReadLine();
                if (row != "Composite Element REF\tBeta_value\tGene_Symbol\tChromosome\tGenomic_Coordinate")
                {
                    errorMessage = "文件" + importFile3.FileName[i] + "不是level3文件！\nlevel3文件第二行应为如下的表头：\nComposite Element REF	Beta_value	Gene_Symbol	Chromosome	Genomic_Coordinate";
                    UpdateInfo("\n" + errorMessage);
                    MessageBox.Show(errorMessage);
                    reader.Close();
                    return false;
                }

                if (firstFile)
                {
                    string header = "Composite Element REF\tGene_Symbol\tChromosome\tGenomic_Coordinate\t" +
                                    sampleCode_Short;
                    outputList.Add(header); //第一行为表头
                    sampleCodeList.Add(sampleCode_Short); //添加到短码表中
                    //if (methyPositionList == null) //无甲基化位点表时，节省判断时间
                    {
                        while (!reader.EndOfStream)
                        {
                            row = reader.ReadLine();
                            row_split = row.Split(splitter1);
                            outputList.Add(row_split[0] + "\t" + row_split[2] + "\t" + row_split[3] + "\t" +
                                           row_split[4] + "\t" + row_split[1]);
                        }
                    }
                    /*
                    else //有甲基化位点表时
                    {
                        while (!reader.EndOfStream)
                        {
                            row = reader.ReadLine();
                            row_split = row.Split(splitter1);
                            if (methyPositionList.Contains(row_split[0]))
                                outputList.Add(row_split[0] + "\t" + row_split[2] + "\t" + row_split[3] + "\t" +
                                               row_split[4] + "\t" + row_split[1]);
                        }
                    }*/
                    firstFile = false;
                }
                else //非第一个文件
                {
                    int k = 1;
                    outputList[0] += "\t" + sampleCode_Short; //添加列表头
                    sampleCodeList.Add(sampleCode_Short); //添加到短码表中
                    //if (methyPositionList == null) //无甲基化位点表时，节省判断时间
                    {
                        while (!reader.EndOfStream)
                        {
                            row = reader.ReadLine();
                            row_split = row.Split(splitter1);
                            outputList[k] +="\t" + row_split[1];
                            k++;
                        }
                    }
                    /*
                    else //有甲基化位点表时
                    {
                        while (!reader.EndOfStream)
                        {
                            row = reader.ReadLine();
                            row_split = row.Split(splitter1);
                            if (methyPositionList.Contains(row_split[0]))
                                outputList[k] += "\t" + row_split[1];
                            k++;
                        }
                    }*/
                }
                reader.Close();
                UpdateInfo("完毕");
            }

            UpdateInfo("\n正在输出level3合并文件...");
            StreamWriter writer = new StreamWriter(exportFile.FileName);
            for (int i = 0; i < outputList.Count; i++)
            {
                writer.WriteLine(outputList[i]);
            }
            writer.Close();

            if (checkBox_mergedLevel3.Checked)
            {
                UpdateInfo("\n正在根据甲基化位点文件筛选已合并的level3文件...");
                exportFile.FileName = exportFile.FileName.Replace(".txt", "_merged_Selected.txt");
                writer = new StreamWriter(exportFile.FileName);
                writer.WriteLine(outputList[0]); //表头

                //筛选
                int n = 0, n_Selected = 0;
                string[] row_split;
                foreach (var row in outputList)
                {
                    row_split = row.Split(splitter1);
                    n++;

                    if (methyPositionList.Contains(row_split[0]))
                    {
                        writer.WriteLine(row);
                        n_Selected++;
                    }

                    if (n % 10000 == 0)
                    {
                        UpdateInfo("\n已检测" + n + "行，已筛选出" + n_Selected + "行");
                    }
                }
                
                writer.Close();
                UpdateInfo("\n已检测" + n + "行，已筛选出" + n_Selected + "行");

            }

            outputList = null;
            UpdateInfo("完毕");
            return true;
        }

        private bool Work_MergedLevel3()
        {
            UpdateInfo("\n正在根据甲基化位点文件筛选已合并的level3文件...");
            StreamReader reader = new StreamReader(importFile4.FileName);
            StreamWriter writer = new StreamWriter(exportFile.FileName);
            
            //表头
            string row = reader.ReadLine();
            string[] row_split;
            writer.WriteLine(row);

            //筛选
            int n = 0, n_Selected = 0;
            while (!reader.EndOfStream)
            {
                row = reader.ReadLine();
                row_split = row.Split(splitter1);
                n++;

                if (methyPositionList.Contains(row_split[0]))
                {
                     writer.WriteLine(row);
                    n_Selected++;
                }

                if (n % 10000 == 0)
                {
                    UpdateInfo("\n已读取" + n + "行，已筛选出" + n_Selected + "行");
                }
            }

            reader.Close();
            writer.Close();
            UpdateInfo("\n已读取" + n + "行，已筛选出" + n_Selected + "行");
            
            return true;
        }
        
    }
}
