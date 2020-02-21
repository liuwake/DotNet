
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
using System.Activities;

//必须用admin打开vs否则http报错

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //定义一个接口接收返回值，用Invoke方法调用workflow
            IDictionary<string, object> results = WorkflowInvoker.Invoke(new WorkflowProj.Activity1());
            //用键值接收返回值
            string result = results["returnValue"].ToString();
            MessageBox.Show(result);
        }

        }
    }

