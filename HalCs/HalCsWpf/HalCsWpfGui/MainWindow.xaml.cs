using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Dev
using HalconDotNet;
using HalCsMod;
using System.Threading;//引入线程

namespace HalCsWpfGui
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Thread showThread;
                showThread = new Thread(Start);
                showThread.Start();
            }
            catch(HalconException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 设置全屏
            //this.WindowState = System.Windows.WindowState.Normal;
            //this.WindowStyle = System.Windows.WindowStyle.None;
            //this.ResizeMode = System.Windows.ResizeMode.NoResize;
            //this.Topmost = true;

            //this.Left = 0.0;
            //this.Top = 0.0;
            //this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            //this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
        }

        private void Start()
        {
            HalCsMod.HalCam halCam = new HalCsMod.HalCam();
            //window = hWindowControl1.HalconWindow;
            halCam.showFrame(hWindowControl1.HalconWindow);
            //HOperatorSet.DispObj(halCam.ho_Image, hWindowControl1.HalconWindow);
            System.Diagnostics.Debug.WriteLine("Start()");


        }
    }
}
