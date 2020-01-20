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


//using Syste
namespace DbWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {     
        public MainWindow()
        {
            //Init
            InitializeComponent();            
            //Open window
            Window odbcForm = new OdbcForm();//这是新窗口的类                                            
            odbcForm.Show();//无模式，弹出！
            Window oleDbForm = new OleDbForm();//这是新窗口的类                                            
            oleDbForm.Show();//无模式，弹出！
            Window sqliteForm = new SqliteForm();//这是新窗口的类                                            
            sqliteForm.Show();//无模式，弹出！

        }

    }
}
