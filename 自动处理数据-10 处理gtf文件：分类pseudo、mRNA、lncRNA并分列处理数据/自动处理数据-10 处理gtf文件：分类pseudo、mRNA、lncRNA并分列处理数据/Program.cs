using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动处理数据_10_处理gtf文件_分类pseudo_mRNA_lncRNA并分列处理数据
{
    static class Program
    {
        /// <summary>
        /// 应用数据的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
