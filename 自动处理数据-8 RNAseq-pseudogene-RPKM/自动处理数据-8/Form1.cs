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

namespace 自动处理数据_8
{
    public partial class Form1 : Form
    {
        private OpenFileDialog importFile1 = null, importFile2 = null, importFile3 = null;
        private SaveFileDialog exportFile = null;
        private DataTable dt_pseudogenes = null;
        private Hashtable ht_manifest = null;
        private char[] splitter1 = new char[] {'\t'}, splitter2 = new char[] {'\t', ':'}, splitter3 = new char[] {'-'};

        public Form1()
        {
            InitializeComponent();
        }

        private void button_SelectFile1_Click(object sender, EventArgs e)
        {
            UpdateInfoLabel("");
            importFile1 = new OpenFileDialog();
            importFile1.Multiselect = false;
            importFile1.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = importFile1.FileName;
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
            importFile3.Multiselect = true;
            importFile3.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile3.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox3.Text = importFile3.FileNames[0] + " 等" + importFile3.FileNames.Length + "个文件";
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
                MessageBox.Show("还没选择file_manifest.txt文件！");
                return;
            }

            //textBox3
            if (textBox3.Text == "")
            {
                MessageBox.Show("还没选择level3文件！");
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
            bool success = StartWorking();
            t.Stop();

            if (success)
            {
                UpdateInfoLabel("输出完成！共用时" + t.ElapsedMilliseconds / 1000 + "s");
                MessageBox.Show("输出完成！共用时" + t.ElapsedMilliseconds / 1000 + "s");
            }
            else
            {
                UpdateInfoLabel("遇到错误，程序停止");
            }
            
        }

        private /*async*/ bool StartWorking()
        {

            UpdateInfoLabel("正在读取假基因信息文件");
            StreamReader reader_pseudo = new StreamReader(importFile1.FileName);
            dt_pseudogenes = new DataTable("Pseudogenes");
            dt_pseudogenes.Columns.Add("chr", typeof (string));
            dt_pseudogenes.Columns.Add("Start", typeof (long));
            dt_pseudogenes.Columns.Add("End", typeof (long));
            dt_pseudogenes.Columns.Add("Strand", typeof (string));
            dt_pseudogenes.Columns.Add("ENSG", typeof (string));
            dt_pseudogenes.Columns.Add("Name", typeof (string));
            while (!reader_pseudo.EndOfStream)
            {
                string[] row = reader_pseudo.ReadLine().Split(splitter1, StringSplitOptions.None);
                dt_pseudogenes.Rows.Add(row[0], Convert.ToInt64(row[1]), Convert.ToInt64(row[2]), row[3], row[4], row[5]);
            }
            reader_pseudo.Close();

            UpdateInfoLabel("正在读取file_manifest.txt文件");
            StreamReader reader_manifest = new StreamReader(importFile2.FileName);
            ht_manifest = new Hashtable();
            while (!reader_manifest.EndOfStream)
            {
                string[] row = reader_manifest.ReadLine().Split(splitter1, StringSplitOptions.RemoveEmptyEntries);
                ht_manifest.Add(row[6], row[4]);//key: FileName, value: Sample
            }
            reader_manifest.Close();

            List<string> duplicatedSamples = new List<string>();
            foreach (string fileName in importFile3.FileNames)
            {
                string columnName = (string)ht_manifest[Path.GetFileName(fileName)];
                if (dt_pseudogenes.Columns.Contains(columnName))
                {
                    //MessageBox.Show("file_manifest.txt中有重复的项：\n" + columnName + "\n请检查后重试！\n\n程序停止", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return false;
                    MessageBox.Show("file_manifest.txt中有重复的项：\n" + columnName + "\n将去除这两项！", "Sample重复提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    duplicatedSamples.Add(columnName);
                }
                else
                    dt_pseudogenes.Columns.Add(columnName, typeof(decimal));
            }
            //delete duplicated items
            foreach (string s in duplicatedSamples)
            {
                dt_pseudogenes.Columns.Remove(s);
            }

            //int currentTaskAmount = 0, maxTaskAmount = Convert.ToInt32(numericUpDown1.Value);
            //List<Thread> threads = new List<Thread>();

            int fileNo = 0, totalFileAmount = importFile3.FileNames.Length;
            foreach (string fileName in importFile3.FileNames)
            {
                fileNo++;
                UpdateInfoLabel("正在处理level3文件，第" + fileNo + "个，共" + totalFileAmount + "个");
                if (dt_pseudogenes.Columns.Contains((string)ht_manifest[Path.GetFileName(fileName)]))
                    WorkForSingleLevel3File(fileName);
                /*
                UpdateInfoLabel("正在处理level3文件，第" + fileNo + "个，共" + totalFileAmount + "个；共" + threads.Count + "个线程");
                while (threads.Count >= maxTaskAmount)
                {
                    Thread tFinish = null;
                    //wait for any task finished
                    foreach (Thread t in threads)
                    {
                        if (t.ThreadState == System.Threading.ThreadState.Stopped)
                        {
                            tFinish = t;
                            break;
                        }
                    }
                    if (tFinish != null)
                    {
                        threads.Remove(tFinish);
                    }
                }

                if (threads.Count < maxTaskAmount)
                {
                    Thread t = new Thread(WorkForSingleLevel3File);
                    threads.Add(t);
                    t.Start(fileName);
                }
                */
            }
            /*
            while (threads.Count > 0)
            {
                Thread tFinish = null;
                foreach (Thread t in threads)
                {
                    if (t.ThreadState == System.Threading.ThreadState.Stopped)
                    {
                        tFinish = t;
                        break;
                    }
                }
                if (tFinish != null)
                {
                    threads.Remove(tFinish);
                }
                Thread.Sleep(500);
            }
            */
            StreamWriter writer = new StreamWriter(exportFile.FileName);
            int rowNo = 0, rowTotalAmount = dt_pseudogenes.Rows.Count;
            string row_write = "";
            //header
            foreach (DataColumn column in dt_pseudogenes.Columns)
            {
                row_write += column.ColumnName + "\t";
            }
            row_write.Remove(row_write.Length - 1);
            writer.WriteLine(row_write);

            foreach (DataRow row in dt_pseudogenes.Rows)
            {
                rowNo++;
                UpdateInfoLabel("正在输出，第" + rowNo + "行，共" + rowTotalAmount + "行");
                row_write = "";
                foreach (object cell in row.ItemArray)
                {
                    row_write += cell.ToString() + "\t";
                }
                row_write.Remove(row_write.Length - 1);
                writer.WriteLine(row_write);
            }
            writer.Close();

            return true;
        }

        private void WorkForSingleLevel3File(object fileName)
        {
            WorkForSingleLevel3File((string) fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c1">chr1</param>
        /// <param name="c2">chr2</param>
        /// <returns></returns>
        private int ChrComparer(string c1, string c2)
        {
            string n1 = c1.ToLower().Replace("chr", "");
            string n2 = c2.ToLower().Replace("chr", "");
            if (n1 == n2)
                return 0;
            if (n1 == "y")
                return 1;
            if (n2 == "y")
                return -1;
            if (n1 == "x")
                return 1;
            if (n2 == "x")
                return -1;
            try
            {
                int i1 = Convert.ToInt32(n1);
                int i2 = Convert.ToInt32(n2);
                if (i1 < i2)
                    return -1;
                else
                    return 1;
            }
            catch (Exception)
            {
                return -999;
            }

        }

        private void WorkForSingleLevel3File(string fileName)
        {
            string columnName = (string) ht_manifest[Path.GetFileName(fileName)];

            StreamReader reader_level3 = new StreamReader(fileName);

            long level3Start = -1, level3End = -1;
            string[] row_read = null, position = null;
            long row_counts = 0, reads = 0, all_reads = 0;
            bool continueReading = true;
            reader_level3.ReadLine();//skip header
            foreach (DataRow row_pseudo in dt_pseudogenes.Rows)
            {
                //bool moveNext = false;
                string pseudoChr = (string) row_pseudo["chr"], pseudoStrand = (string) row_pseudo["Strand"];
                long pseudoStart = (long) row_pseudo["Start"], pseudoEnd = (long) row_pseudo["End"];
                reads = 0;
                while (!reader_level3.EndOfStream)
                {
                    if (continueReading)
                    {
                        row_read = reader_level3.ReadLine()
                            .Split(splitter2, StringSplitOptions.RemoveEmptyEntries);
                        position = row_read[1].Split(splitter3, StringSplitOptions.RemoveEmptyEntries);
                        level3Start = Convert.ToInt64(position[0]);
                        level3End = Convert.ToInt64(position[1]);
                        row_counts = Convert.ToInt64(row_read[3]);
                        all_reads += row_counts;
                    }

                    //chr equal?
                    bool breakReadLoop = false, readNextLine = false;
                    switch (ChrComparer(pseudoChr, row_read[0]))
                    {
                        case 1:
                            //pseudo is larger, read next line
                            readNextLine = true;
                            break;
                        case -1:
                            //level3 is larger, move to next pseudo
                            breakReadLoop = true;
                            break;
                        case 0:
                            //OK
                            break;
                        case -999:
                            //error, read next line
                            readNextLine = true;
                            break;
                    }
                    if (breakReadLoop)
                    {
                        continueReading = false;
                        break;
                    }
                    if (readNextLine)
                    {
                        continueReading = true;
                        continue;
                    }

                    //compare start and end
                    if (level3End > pseudoEnd)
                    {
                        //move to next pseudogene and do not read new line
                        //moveNext = true;
                        continueReading = false;
                        break;
                    }
                    if (level3Start < pseudoStart)
                    {
                        //read next line
                        continueReading = true;
                        continue;
                    }

                    //strand equal?
                    if (row_read[2] != pseudoStrand)
                    {
                        continueReading = true;
                        continue;
                    }

                    //meet requirement
                    {
                        continueReading = true;
                        reads += row_counts;
                    }
                }
                lock (this)
                {
                    row_pseudo[columnName] = reads;
                }
                //row_pseudo[columnName] = 10E9M*reads/(all_reads*(pseudoEnd - pseudoStart));

                //剩余的全部按0来
                /*if (reader_level3.EndOfStream)
                    break;//读完了就处理完了,*/
            }

            //calculate
            
            foreach (DataRow row_pseudo in dt_pseudogenes.Rows)
            {
                long pseudoStart = (long)row_pseudo["Start"], pseudoEnd = (long)row_pseudo["End"];
                row_pseudo[columnName] = (decimal)row_pseudo[columnName] * 10E9M / (all_reads * (pseudoEnd - pseudoStart));
            }
            
            reader_level3.Close();

        }

        /*
        private string[] WorkForSingleLevel3File(string filename)
        {
            return new string[] {};
        }

        private Task<string[]> WorkForSingleLevel3FileAsync(string filename)
        {
            return Task.Run(() => WorkForSingleLevel3File(filename));
        }
        */

        private void UpdateInfoLabel(string text)
        {
            label_Info.Text = text;
            label_Info.Refresh();
        }
    }
}
