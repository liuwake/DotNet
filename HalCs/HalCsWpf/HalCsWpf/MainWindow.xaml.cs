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

        //HTuple hd = null;
        HalScan HalInv = new HalScan();
        HalLive HalLive = new HalLive();
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
            showThread = new Thread(HalLiveShow);
            showThread.Start();
        }

        private void button2_click(object sender, EventArgs e)//停止
        {
            showThread.Abort();
            try
            {
                HalLive.StopHalcon();
                HalInv.StopHalcon();
            }
            catch
            {
                return;
            }
            
        }
         
        public void button3_click(object sender, RoutedEventArgs e)
        {
            showThread = new Thread(HalInvShow);
            showThread.Start();
        }

        ////Halcon Function
        void HalLiveShow()
        {
            HalLive.RunHalcon(hWindowControl1.HalconWindow);
        }
        void HalInvShow()
        {
            HalInv.RunHalcon(hWindowControl1.HalconWindow);
        }
}

}
