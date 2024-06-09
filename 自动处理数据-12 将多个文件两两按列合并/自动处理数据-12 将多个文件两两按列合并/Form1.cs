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

namespace 自动处理数据_12_将多个文件两两按列合并
{
    public partial class Form1 : Form
    {
        private OpenFileDialog importFile1 = null;
        private char[] splitter = {'\t'};

        public Form1()
        {
            InitializeComponent();
        }

        private void button_SelectFile1_Click(object sender, EventArgs e)
        {
            importFile1 = new OpenFileDialog();
            importFile1.Multiselect = true;
            importFile1.Filter = "文本文件（*.txt）|*.txt";

            var result = importFile1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (importFile1.FileNames.Length == 1)
                    textBox1.Text = importFile1.FileName;
                else if (importFile1.FileNames.Length > 1)
                    textBox1.Text = importFile1.FileName + " 等" + importFile1.FileNames.Length + "个文件";
            }
            UpdateInfo("", false, true);
            int n = importFile1.FileNames.Length;
            UpdateInfo("\n共" + n + "个文件，将输出C(" + n + ",2) = " + (n * (n - 1) / 2) + "个文件");
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

        private void button_Start_Click(object sender, EventArgs e)
        {
            //textBox1
            if (textBox1.Text == "")
            {
                MessageBox.Show("还没选择任何文件！");
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

        private bool StartWorking0()
        {
            int n = importFile1.FileNames.Length;
            StreamReader reader = null;
            for (int i = 0; i < n; i++)
            {
                List<string> file1 = new List<string>();
                reader = new StreamReader(importFile1.FileNames[i]);
                while (!reader.EndOfStream)
                {
                    file1.Add(reader.ReadLine());
                }
                reader.Close();

                for (int j = i + 1; j < n; j++)
                {
                    UpdateInfo("\n正在合并" + Path.GetFileName(importFile1.FileNames[i]) + "和" + Path.GetFileName(importFile1.FileNames[j]) + "...");
                    List<string> file2 = new List<string>();
                    reader = new StreamReader(importFile1.FileNames[j]);
                    while (!reader.EndOfStream)
                    {
                        file2.Add(reader.ReadLine());
                    }
                    reader.Close();

                    List<string> f1, f2 = null;
                    if (file1.Count >= file2.Count) //f1行数更多
                    {
                        f1 = file1;
                        f2 = file2;
                    }
                    else
                    {
                        f1 = file2;
                        f2 = file1;
                    }

                    string filename = Path.GetDirectoryName(importFile1.FileNames[0]) + "\\" +
                                      Path.GetFileNameWithoutExtension(importFile1.FileNames[i] + "+" +
                                                                       importFile1.FileNames[j] + ".txt");
                    StreamWriter writer = new StreamWriter(filename);
                    for (int k = 0; k < f2.Count; k++)
                        writer.WriteLine(f1[k] + "\t" + f2[k]);
                    for (int k = f2.Count; k < f1.Count; k++)
                        writer.WriteLine(f1[k]);
                    writer.Close();
                    UpdateInfo("完毕");
                }
            }
            return true;
        }

        private bool StartWorking()
        {
            int n = importFile1.FileNames.Length;
            StreamReader reader1 = null, reader2 = null;
            StreamWriter writer = null;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    UpdateInfo("\n正在合并" + Path.GetFileName(importFile1.FileNames[i]) + "和" + Path.GetFileName(importFile1.FileNames[j]) + "...");

                    reader1 = new StreamReader(importFile1.FileNames[i]);
                    reader2 = new StreamReader(importFile1.FileNames[j]);
                    string filename = Path.GetDirectoryName(importFile1.FileNames[0]) + "\\合并：" +
                                      Path.GetFileNameWithoutExtension(importFile1.FileNames[i]) + "+" +
                                      Path.GetFileNameWithoutExtension(importFile1.FileNames[j]) + ".txt";
                    writer = new StreamWriter(filename);

                    if (checkBox1.Checked)
                    {
                        int c = Convert.ToInt32(numericUpDown1.Value) - 1;
                        //输出表头
                        writer.WriteLine(Path.GetFileNameWithoutExtension(importFile1.FileNames[i]) + "\t" +
                                         Path.GetFileNameWithoutExtension(importFile1.FileNames[j]));
                        while ((!reader1.EndOfStream) && (!reader2.EndOfStream))
                        {
                            writer.WriteLine(reader1.ReadLine().Split(splitter)[c] + "\t" + reader2.ReadLine().Split(splitter)[c]);
                        }
                        if (reader1.EndOfStream)
                        {
                            while (!reader2.EndOfStream)
                            {
                                writer.WriteLine("\t" + reader2.ReadLine().Split(splitter)[c]);
                            }
                        }
                        else if (reader2.EndOfStream)
                        {
                            while (!reader1.EndOfStream)
                            {
                                writer.WriteLine(reader1.ReadLine().Split(splitter)[c]);
                            }
                        }
                    }
                    else
                    {

                        while ((!reader1.EndOfStream) && (!reader2.EndOfStream))
                        {
                            writer.WriteLine(reader1.ReadLine() + "\t" + reader2.ReadLine());
                        }
                        if (reader1.EndOfStream)
                        {
                            while (!reader2.EndOfStream)
                            {
                                writer.WriteLine("\t" + reader2.ReadLine());
                            }
                        }
                        else if (reader2.EndOfStream)
                        {
                            while (!reader1.EndOfStream)
                            {
                                writer.WriteLine(reader1.ReadLine());
                            }
                        }
                    }

                    reader1.Close();
                    reader2.Close();
                    writer.Close();
                }
            }

            UpdateInfo("完毕");
            return true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = checkBox1.Checked;

        }
    }
}
