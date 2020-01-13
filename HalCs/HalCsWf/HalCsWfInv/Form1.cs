using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Halcon
using HalconDotNet;//使用命名空间
using System.Data.OleDb;

namespace HalCsWfInv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“accessDemoDataSet.Scan”中。您可以根据需要移动或删除它。
            this.scanTableAdapter.Fill(this.accessDemoDataSet.Scan);
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体 
        }

        private void saomiaoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
