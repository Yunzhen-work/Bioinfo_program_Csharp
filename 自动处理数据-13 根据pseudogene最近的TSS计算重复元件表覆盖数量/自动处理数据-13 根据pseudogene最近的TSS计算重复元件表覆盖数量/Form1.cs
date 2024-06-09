using System;
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

namespace 自动处理数据_13_根据pseudogene最近的TSS计算重复元件表覆盖数量
{
    public partial class Form1 : Form
    {
        private OpenFileDialog importFile1 = null, importFile2 = null;
        private SaveFileDialog exportFile = null;
        private char[] splitter1 = new char[] { '\t' }, splitter2 = new char[] { '\t', '-' };

        public Form1()
        {
            InitializeComponent();
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
            importFile1.Multiselect = false;
            importFile1.Filter = "自动处理数据-4输出的pseudogene最近TSS文件（*.txt）|*.txt";

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
            importFile2.Filter = "重复元件位置信息（*.txt）|*.txt";

            var result = importFile2.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (importFile2.FileNames.Length == 1)
                    textBox2.Text = importFile2.FileName;
                else if (importFile2.FileNames.Length > 1)
                    textBox2.Text = importFile2.FileName + " 等" + importFile2.FileNames.Length + "个文件";
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            //textBox1
            if (textBox1.Text == "")
            {
                MessageBox.Show("还没选择自动处理数据-4输出的pseudogene最近TSS文件！");
                return;
            }

            //textBox2
            if (textBox2.Text == "")
            {
                MessageBox.Show("还没选择重复元件位置信息文件！");
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

        private bool StartWorking()
        {
            //读取自动-4输出的TSS表
            UpdateInfo("\n正在读取" + importFile1.FileName + "...");
            DataTable pseudogene_TSS = new DataTable();
            pseudogene_TSS.Columns.Add("Name");
            pseudogene_TSS.Columns.Add("chr");
            pseudogene_TSS.Columns.Add("start");
            pseudogene_TSS.Columns.Add("end");
            pseudogene_TSS.Columns.Add("TSS");
            StreamReader reader = new StreamReader(importFile1.FileName);
            string row = reader.ReadLine();
            string[] row_split = null;
            if (row != "假基因\tchr\t区域\tTSS")
            {
                MessageBox.Show("选择的文件不是自动处理数据-4输出的pseudogene最近TSS文件！\n表头应为\n假基因 chr 区域 TSS");
                UpdateInfo("选择的文件不是自动处理数据-4输出的pseudogene最近TSS文件！表头应为【假基因 chr 区域 TSS】");
                return false;
            }
            while (!reader.EndOfStream)
            {
                row = reader.ReadLine();
                row_split = row.Split(splitter1);
                string[] range = row_split[2].Split(splitter2);
                pseudogene_TSS.Rows.Add(row_split[0], row_split[1], range[0], range[1], row_split[3]);
            }
            reader.Close();
            UpdateInfo("完毕");

            //读取重复元件表
            for (int fileNo = 0; fileNo < importFile2.FileNames.Length; fileNo++)
            {
                UpdateInfo("\n正在读取" + importFile2.FileNames[fileNo] + "...");
                DataTable repeatElements = new DataTable(Path.GetFileNameWithoutExtension(importFile2.FileNames[fileNo]));
                reader = new StreamReader(importFile2.FileNames[fileNo]);
                repeatElements.Columns.Add("chr", typeof(string));
                repeatElements.Columns.Add("start", typeof(long));
                repeatElements.Columns.Add("end", typeof(long));
                while (!reader.EndOfStream)
                {
                    row = reader.ReadLine();
                    row_split = row.Split(splitter1);
                    repeatElements.Rows.Add(row_split[0], Convert.ToInt64(row_split[1]), Convert.ToInt64(row_split[2]));
                }
                reader.Close();
                UpdateInfo("完毕");

                //处理数据
                UpdateInfo("\n正在计算" + repeatElements.TableName + "的分布");
                string exportFileName =
                    importFile2.FileNames[fileNo].Replace(
                        Path.GetFileNameWithoutExtension(importFile2.FileNames[fileNo]),
                        "分布-" + Path.GetFileNameWithoutExtension(importFile2.FileNames[fileNo]));
                StreamWriter writer = new StreamWriter(exportFileName);
                //输出表头
                string rowOutput = "Pseudogene";
                for (int i = -10; i <= 9; i++)
                {
                    rowOutput += "\t" + i + "kb~" + (i+1) + "kb";
                }
                writer.WriteLine(rowOutput);

                int count = 0;
                foreach (DataRow onePseudo_TSS in pseudogene_TSS.Rows)
                {
                    rowOutput = onePseudo_TSS["Name"].ToString();
                    count++;
                    long TSS = Convert.ToInt64(onePseudo_TSS["TSS"]), sectionStart = 0, sectionEnd = 0, sectionCount = 0;
                    DataRow[] repeatElementsToBeSearched = repeatElements.Select("chr = '" + onePseudo_TSS["chr"].ToString() + "'", "start asc");

                    for (int i = -10; i <= 9; i++)
                    {
                        sectionCount = 0;
                        sectionStart = TSS + i*1000;
                        sectionEnd = sectionStart + 1000;
                        for (int j = 0; j < repeatElementsToBeSearched.Length; j++)
                        {
                            if ((long) repeatElementsToBeSearched[j]["end"] < sectionStart)
                                continue;
                            if ((long) repeatElementsToBeSearched[j]["start"] > sectionEnd)
                                break;
                            sectionCount++;
                        }
                        rowOutput += "\t" + sectionCount;
                    }
                    writer.WriteLine(rowOutput);
                    UpdateInfo(".");
                }
                writer.Close();
                UpdateInfo("完毕");
            }
            return true;
        }
    }
}
