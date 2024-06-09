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

namespace 自动处理数据_2
{
    public partial class Form1 : Form
    {
        int k, total;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            label8.Refresh();
            OpenFileDialog importFile = new OpenFileDialog();
            importFile.Multiselect = false;
            importFile.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = importFile.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            label8.Refresh();
            OpenFileDialog importFile = new OpenFileDialog();
            importFile.Multiselect = false;
            importFile.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = importFile.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            label8.Refresh();
            SaveFileDialog exportFile = new SaveFileDialog();
            exportFile.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = exportFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox3.Text = exportFile.FileName;
            }
        }

        private void StartCalculation()
        {
            string[] rowArray1 = File.ReadAllLines(textBox1.Text);
            string[] rowArray2 = File.ReadAllLines(textBox2.Text);
            total = (rowArray1.Length - 1) * (rowArray2.Length - 1);
            string filePath = textBox3.Text;
            int fileNo = 1;

            int rowCountPerFile = Convert.ToInt32(numericUpDown1.Value);
            if (rowCountPerFile == 0)
                rowCountPerFile = total + 1;
            else
                filePath = filePath.Replace(".txt", "-" + fileNo.ToString("D3") + ".txt");

            FileStream file3 = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file3);


            //表头
            writer.WriteLine(rowArray1[0] + "\t" + rowArray2[0]);

            k = 0;
            for (int i = 1; i < rowArray1.Length; i++)
            {
                for (int j = 1; j < rowArray2.Length; j++)
                {
                    //数据
                    writer.WriteLine(rowArray1[i] + "\t" + rowArray2[j]);
                    k++;

                    if (k % rowCountPerFile == 0) //达到数量，关闭文件，计数+1，另开新文件，重写表头
                    {
                        if (writer != null)
                            writer.Close();
                        filePath = filePath.Replace("-" + fileNo.ToString("D3") + ".txt", "");
                        fileNo++;
                        filePath += "-" + fileNo.ToString("D3") + ".txt";
                        file3 = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                        writer = new StreamWriter(file3);
                        //表头
                        writer.WriteLine(rowArray1[0] + "\t" + rowArray2[0]);
                    }
                }
                backgroundWorker1.ReportProgress(k);
            }

            //File.WriteAllLines(textBox3.Text, rowArray3);
            writer.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            StartCalculation();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label8.Text = "已完成" + k + "行，共" + total + "行";
            label8.Refresh();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
                MessageBox.Show("输出完成！");

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
            button4.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
