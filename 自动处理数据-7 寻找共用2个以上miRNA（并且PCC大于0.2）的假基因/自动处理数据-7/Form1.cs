using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace 自动处理数据_7
{
    public partial class Form1 : Form
    {
        class Pseudogene
        {
            public Pseudogene(string _position)
            {
                this.Position = _position;
                this.miRNAs = new List<string>();
            }
            public string Position { get; set; }
            public List<string> miRNAs { get; set; }

            //参考http://bbs.csdn.net/topics/390617586?page=1，List的Contains调用Equals方法，因此重写Equals方法
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;

                if (this.GetType() != obj.GetType())
                    return false;

                return Equals(obj as Pseudogene);
            }

            private bool Equals(Pseudogene p)
            {
                return (this.Position == p.Position);
            }

            public override int GetHashCode()
            {
                return this.Position.GetHashCode();
            }
        }

        private OpenFileDialog importFile1 = null, importFile2 = null;
        private SaveFileDialog exportFile = null;

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
            importFile2.Multiselect = true;
            importFile2.Filter = "txt制表符分隔（*.txt）|*.txt";

            var result = importFile2.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = importFile2.FileName;
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
                MessageBox.Show("还没选择mRNA-miRNA-假基因文件！");
                return;
            }

            //textBox2
            if ((checkBox2.Checked) && (textBox2.Text == ""))
            {
                MessageBox.Show("还没选择假基因-假基因PCC文件！");
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
            StartWorking();
            UpdateInfoLabel("输出完成");
            MessageBox.Show("完成！用时" + t.ElapsedMilliseconds / 1000 + "s");
        }

        private void StartWorking()
        {
            int fileNo = 0, totalFile = importFile1.FileNames.Length;
            string[] row_read = null;
            foreach (string filePath in importFile1.FileNames)
            {
                fileNo++;
                UpdateInfoLabel("正在读入" + Path.GetFileName(filePath) + "，第" + fileNo + "个文件，共" + totalFile + "个");
                Hashtable pGenesHashTable = new Hashtable(), pGenesHubHashTable = new Hashtable();

                StreamReader reader = new StreamReader(filePath);
                row_read = reader.ReadLine().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);//读表头
                int positionNo = -1, miRNANo = -1;
                for (int i = 0; i < row_read.Length; i++)
                {
                    if (row_read[i] == "Position")
                        positionNo = i;
                    if (row_read[i] == "miRNA")
                        miRNANo = i;
                }
                if ((positionNo == -1) || (miRNANo == -1))
                {
                    MessageBox.Show(filePath + "文件不包含表头（“Position”和“miRNA”），无法判断哪一列是Position或miRNA，将忽略该文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                while (!reader.EndOfStream)
                {
                    row_read = reader.ReadLine().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string position = row_read[positionNo], miRNA = row_read[miRNANo];

                    if (!pGenesHashTable.Contains(position))
                        pGenesHashTable.Add(position, new Pseudogene(position));
                    if (!(pGenesHashTable[position] as Pseudogene).miRNAs.Contains(miRNA))
                        (pGenesHashTable[position] as Pseudogene).miRNAs.Add(miRNA);

                    if (!pGenesHubHashTable.Contains(position))
                        pGenesHubHashTable.Add(position, 1);
                    else
                        pGenesHubHashTable[position] = ((Int32)pGenesHubHashTable[position]) + 1;
                }
                reader.Close();

                UpdateInfoLabel("正在处理" + Path.GetFileName(filePath) + "的假基因表，第" + fileNo + "个文件，共" + totalFile + "个");

                List<Pseudogene> pseudogenes = new List<Pseudogene>();
                foreach (Pseudogene p in pGenesHashTable.Values)
                {
                    pseudogenes.Add(p);
                }

                DataTable dt_PCC = null;
                if (checkBox2.Checked)
                {
                    dt_PCC = new DataTable();
                    dt_PCC.Columns.Add("Position1");
                    dt_PCC.Columns.Add("Position2");
                    dt_PCC.Columns.Add("PCC");
                    string[] name = Path.GetFileNameWithoutExtension(filePath).Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    string PCCFile = "";
                    foreach (string n in name)
                    {
                        foreach (string nPCC in importFile2.FileNames)
                        {
                            if (Path.GetFileNameWithoutExtension(nPCC).Contains(n))
                            {
                                PCCFile = nPCC;
                                break;
                            }
                        }
                        if (PCCFile != "")
                            break;
                    }
                    UpdateInfoLabel("正在读入" + Path.GetFileName(filePath) + "对应的PCC值文件" + Path.GetFileName(PCCFile) + "，第" + fileNo + "个文件，共" + totalFile + "个");

                    StreamReader reader2 = new StreamReader(PCCFile);
                    row_read = reader2.ReadLine().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);//读表头
                    int position1No = -1, position2No = -1, PCCNo = -1;
                    for (int i = 0; i < row_read.Length; i++)
                    {
                        if (row_read[i] == "Position")
                        {
                            if (position1No == -1)
                                position1No = i;
                            else
                                position2No = i;
                        }
                            
                        if (row_read[i] == "PCC")
                            PCCNo = i;
                    }
                    if ((position1No == -1) || (position2No == -1) || (PCCNo == -1))
                    {
                        MessageBox.Show(filePath + "文件不包含表头（两列“Position”和“PCC”），无法判断哪一列是Position或PCC值，将忽略该文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    while (!reader2.EndOfStream)
                    {
                        row_read = reader2.ReadLine().Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        dt_PCC.Rows.Add(row_read[position1No], row_read[position2No], row_read[PCCNo]);
                    }
                    reader2.Close();
                }



                UpdateInfoLabel("正在寻找" + Path.GetFileName(filePath) + "中满足条件的假基因对，第" + fileNo + "个文件，共" + totalFile + "个");
                StreamWriter writer;
                if (checkBox2.Checked)
                {
                    writer = new StreamWriter(exportFile.FileName.Replace(".txt", "-PCC大于" + numericUpDown1.Value.ToString("F2") + "-" + Path.GetFileName(filePath)));
                    writer.WriteLine("Position1\tPosition2\tSame miRNA Count\tPCC");
                }
                else
                {
                    writer = new StreamWriter(exportFile.FileName.Replace(".txt", "-" + Path.GetFileName(filePath)));
                    writer.WriteLine("Position1\tPosition2\tSame miRNA Count");
                }


                int pNo = 0, pTotal = pseudogenes.Count * (pseudogenes.Count - 1) / 2;
                for (int i = 0; i < pseudogenes.Count; i++)
                {
                    for (int j = i + 1; j < pseudogenes.Count; j++)
                    {
                        pNo++;
                        UpdateInfoLabel("正在寻找" + Path.GetFileName(filePath) + "中满足条件的假基因对，第" + pNo + "对，共" + pTotal + "对；第" + fileNo + "个文件，共" + totalFile + "个");
                        int samemiRNACount = 0;
                        foreach (string miRNA in pseudogenes[i].miRNAs)
                        {
                            if (pseudogenes[j].miRNAs.Contains(miRNA))
                                samemiRNACount++;
                            //if (samemiRNACount > 1)
                            //    break;
                        }
                        if (samemiRNACount > 1)
                        {
                            if (checkBox2.Checked)
                            //判断PCC>=0.2
                            {
                                DataRow[] query = dt_PCC.Select("Position1='" + pseudogenes[i].Position + "' and Position2='" + pseudogenes[j].Position + "'");
                                if (query.Length == 0)
                                    query = dt_PCC.Select("Position2='" + pseudogenes[i].Position + "' and Position1='" + pseudogenes[j].Position + "'");
                                if (query.Length == 0)
                                    continue;
                                //有
                                if (Math.Abs(Convert.ToDecimal(query[0]["PCC"].ToString())) >= numericUpDown1.Value)
                                {
                                    writer.WriteLine(pseudogenes[i].Position + "\t" + pseudogenes[j].Position + "\t" + samemiRNACount + "\t" + query[0]["PCC"].ToString());

                                    pGenesHubHashTable[pseudogenes[i].Position] = ((Int32)pGenesHubHashTable[pseudogenes[i].Position]) + 1;
                                    pGenesHubHashTable[pseudogenes[j].Position] = ((Int32)pGenesHubHashTable[pseudogenes[j].Position]) + 1;
                                }
                            }
                            else
                                writer.WriteLine(pseudogenes[i].Position + "\t" + pseudogenes[j].Position + "\t" + samemiRNACount);
                        }
                    }
                }

                writer.Close();

                if (checkBox2.Checked)
                    writer = new StreamWriter(exportFile.FileName.Replace(".txt", "-Hub值-PCC大于" + numericUpDown1.Value.ToString("F2") + "-" + Path.GetFileName(filePath)));
                else
                    writer = new StreamWriter(exportFile.FileName.Replace(".txt", "-Hub值-" + Path.GetFileName(filePath)));
                writer.WriteLine("Position\tHub");
                foreach (string position in pGenesHubHashTable.Keys)
                {
                    writer.WriteLine(position + "\t" + pGenesHubHashTable[position].ToString());
                }
                writer.Close();
            }
        }
        private void UpdateInfoLabel(string text)
        {
            label_Info.Text = text;
            label_Info.Refresh();
        }

    }
}
