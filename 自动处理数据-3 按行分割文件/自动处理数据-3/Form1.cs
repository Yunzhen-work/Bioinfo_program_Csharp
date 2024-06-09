using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 自动处理数据_3
{
    public partial class Form1 : Form
    {
        int fileNo = 0, rowCount = 0, rowNumberPerFile = Int32.MaxValue;
        bool cancelled = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_SelectInputFile_Click(object sender, EventArgs e)
        {
            label_Info.Text = "";
            label_Info.Refresh();
            OpenFileDialog importFile = new OpenFileDialog();
            importFile.Multiselect = false;
            importFile.Filter = "所有文件（*.*）|*.*";

            var result = importFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = importFile.FileName;
            }
        }

        private void button_SelectOutputFile_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("先选要分割的文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog exportFile = new SaveFileDialog();
            if (Path.GetExtension(textBox1.Text) == "")
                exportFile.Filter = "|*.*";
            else
                exportFile.Filter = "|*" + Path.GetExtension(textBox1.Text);

            var result = exportFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = exportFile.FileName;
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("还没选择输入文件！");
                return;
            }
            if (!File.Exists(textBox1.Text))
            {
                MessageBox.Show("输入文件不存在，请重新选择！");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("还没选择输出文件！");
                return;
            }

            button_SelectInputFile.Enabled = false;
            button_SelectOutputFile.Enabled = false;
            button_Start.Enabled = false;
            button_Cancel.Visible = true;

            //StartWorking();
            backgroundWorker1.RunWorkerAsync();
        }

        private void StartWorking()
        {
            FileStream file_Input = null, file_Output = null;
            StreamReader reader = null;
            StreamWriter writer = null;
            rowNumberPerFile = numericUpDown1.Value == 0.0M ? Int32.MaxValue : Convert.ToInt32(numericUpDown1.Value);
            fileNo = 0;
            rowCount = 0;
            string outputFilePath = null;

            try
            {
                file_Input = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(file_Input);

                while (!reader.EndOfStream)
                {
                    if ((file_Output == null) || (rowCount % rowNumberPerFile == 0))
                    {
                        if (writer != null)
                            writer.Close();
                        //新建一个文件
                        fileNo++;
                        outputFilePath = Path.GetFullPath(textBox2.Text).Replace(Path.GetExtension(textBox2.Text), "-" + fileNo.ToString("D3") + Path.GetExtension(textBox2.Text));
                        file_Output = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
                        writer = new StreamWriter(file_Output);
                    }
                    writer.WriteLine(reader.ReadLine());
                    rowCount++;
                    //backgroundWorker1.ReportProgress(0);
                    //if (backgroundWorker1.CancellationPending)
                    //    break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (writer != null)
                    writer.Close();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            cancelled = false;

            FileStream file_Input = null, file_Output = null;
            StreamReader reader = null;
            StreamWriter writer = null;
            rowNumberPerFile = numericUpDown1.Value == 0.0M ? Int32.MaxValue : Convert.ToInt32(numericUpDown1.Value);
            fileNo = 0;
            rowCount = 0;
            string outputFilePath = null;

            try
            {
                file_Input = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(file_Input);

                while (!reader.EndOfStream)
                {
                    if ((file_Output == null) || (rowCount % rowNumberPerFile == 0))
                    {
                        if (writer != null)
                            writer.Close();
                        //新建一个文件
                        fileNo++;
                        outputFilePath = Path.GetFullPath(textBox2.Text).Replace(Path.GetExtension(textBox2.Text), "-" + fileNo.ToString("D3") + Path.GetExtension(textBox2.Text));
                        file_Output = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);
                        writer = new StreamWriter(file_Output);
                    }
                    writer.WriteLine(reader.ReadLine());
                    rowCount++;
                    if (rowCount % 100 == 0)
                        backgroundWorker1.ReportProgress(0);
                    if (backgroundWorker1.CancellationPending)
                    {
                        cancelled = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (writer != null)
                    writer.Close();
            }

            backgroundWorker1.ReportProgress(0);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label_Info.Text = "已处理" + rowCount + "行";
            label_Info.Refresh();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label_Info.Text = "已处理" + rowCount + "行";
            label_Info.Refresh();

            if (cancelled)
                MessageBox.Show("已取消！", "分割未完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("完成！", "分割完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

            button_SelectInputFile.Enabled = true;
            button_SelectOutputFile.Enabled = true;
            button_Start.Enabled = true;
            button_Cancel.Visible = false;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
    }
}
