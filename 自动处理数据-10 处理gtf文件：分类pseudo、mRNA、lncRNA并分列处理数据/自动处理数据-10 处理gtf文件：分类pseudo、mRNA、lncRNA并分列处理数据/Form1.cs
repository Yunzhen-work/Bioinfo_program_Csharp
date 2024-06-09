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

namespace 自动处理数据_10_处理gtf文件_分类pseudo_mRNA_lncRNA并分列处理数据
{
    public partial class Form1 : Form
    {
        private OpenFileDialog importFile1 = null;
        private SaveFileDialog exportFile = null;
        private char[] splitter1 = new char[] {'\t'}, splitter2 = new char[] {'\t', ':'}, splitter3 = new char[] {'-'};

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
            importFile1.Filter = "gtf表格文件（*.gtf）|*.gtf";

            var result = importFile1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = importFile1.FileName;
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
                MessageBox.Show("还没选择annotation all的gtf表格文件！");
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
                UpdateInfo("\n共用时" + t.ElapsedMilliseconds/1000 + "s");
                MessageBox.Show("输出完成！共用时" + t.ElapsedMilliseconds/1000 + "s");
            }
            else
            {
                UpdateInfo("\n遇到错误，数据停止");
            }
        }


        private bool StartWorking()
        {
            UpdateInfo("\n正在读取gtf表格文件...");
            StreamReader reader = new StreamReader(importFile1.FileName);
            StreamWriter writer_pseudogene = new StreamWriter(exportFile.FileName.Replace(".txt", "-pseudogene.txt"));
            StreamWriter writer_lncRNA = new StreamWriter(exportFile.FileName.Replace(".txt", "-lncRNA.txt"));
            StreamWriter writer_proteinCoding = new StreamWriter(exportFile.FileName.Replace(".txt", "-protein_coding.txt"));

            string row;
            long n = 0, n_pseudo = 0, n_protein = 0, n_lncRNA = 0;
            while (!reader.EndOfStream)
            {
                row = reader.ReadLine();
                if (row.Contains("##"))
                    continue;

                if (row.Contains("pseudogene"))
                {
                    writer_pseudogene.WriteLine(row);
                    n_pseudo++;
                }
                else if (row.Contains("protein_coding"))
                {
                    writer_proteinCoding.WriteLine(row);
                    n_protein++;
                }
                else if (row.Contains("lincRNA"))
                {
                    writer_lncRNA.WriteLine(row);
                    n_lncRNA++;
                }

                n++;
                if (n%100000 == 0)
                    UpdateInfo("\n已处理 " + n + " 行");
            }

            writer_lncRNA.Close();
            writer_pseudogene.Close();
            writer_proteinCoding.Close();
            reader.Close();

            UpdateInfo("\n\n处理完成，共 " + n + " 行，其中pseudogene " + n_pseudo + " 行，protein_coding " + n_protein + " 行，lncRNA " + n_lncRNA + " 行");

            return true;
        }
    }
}
