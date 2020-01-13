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

namespace HalCsWfDemo
{
    public partial class Form1 : Form
    {

        //Data
        
        //Halcon Data
        HObject ho_Demo, ho_GrayImage;
            
        public Form1()
        {
            InitializeComponent();
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HOperatorSet.GenEmptyObj(out ho_GrayImage);
                ho_GrayImage.Dispose();
                HOperatorSet.Rgb1ToGray(ho_Demo, out ho_GrayImage);
                HOperatorSet.DispObj(ho_GrayImage, hWindowControl1.HalconWindow);
                ho_Demo.Dispose(); //释放ho_Demo的内存
                ho_GrayImage.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void hWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HOperatorSet.GenEmptyObj(out ho_Demo);//创建对象
            ho_Demo.Dispose();//清理内存，使得ho_Demo中空无一物
            HOperatorSet.ReadImage(out ho_Demo, "C:/demo.jpg");//读入内存中
            HOperatorSet.DispObj(ho_Demo, hWindowControl1.HalconWindow);//显示在HWindowControl控件中
        }

       
    }
}
