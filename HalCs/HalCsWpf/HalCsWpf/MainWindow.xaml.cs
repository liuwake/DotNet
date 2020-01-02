using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using HalconDotNet;//引入halcon
using System.Threading;//引入线程


namespace HalCsWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        HObject ho_Image = null;
        HTuple hv_AcqHandle = null;
        //HTuple hd = null;
        HDevelopExport hd = new HDevelopExport();
        public MainWindow()
        {
            InitializeComponent();
            //Init ??? 
            //没有初始化new HDevelopExport();也能正常运行

            //HDevelopExport hd = new HDevelopExport();
            //HDevelopExportApp.


        }

        Thread showThread;

        private void button1_click(object sender, EventArgs e)//开始
        {
            showThread = new Thread(showFrame);
            showThread.Start();
        }

        private void button2_click(object sender, EventArgs e)//停止
        {
            showThread.Abort();
            HOperatorSet.CloseFramegrabber(hv_AcqHandle);
        }

        void showFrame()//采集
        {
            HOperatorSet.GenEmptyObj(out ho_Image);

            HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive",
        -1, "default", -1, "false", "default", "c42f90f2b7fa_Hikvision_MVCE12010GM",
        0, -1, out hv_AcqHandle);
            HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
            while ((int)(1) != 0)
            {
                ho_Image.Dispose();
                HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
                HOperatorSet.DispObj(ho_Image, hWindowControl1.HalconWindow);
            }
        }
        void showInv()
        {
            hd.RunHalcon(hWindowControl1.HalconWindow);
            //hd.action();
        }

        public void button3_click(object sender, RoutedEventArgs e)
        {
            //HDevelopExport hd = new HDevelopExport();
            //hd.RunHalcon(hWindowControl1.HalconWindow);
            //hd.hv_ExpDefaultWinHandle = hWindowControl1.HalconWindow;
            showThread = new Thread(showInv);
            showThread.Start();
        }
    }

}
