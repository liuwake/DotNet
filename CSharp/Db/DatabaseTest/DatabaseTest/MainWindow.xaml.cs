using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

using System.Data;
using System.Data.SQLite;


namespace DatabaseTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public class people
    {
        public string Name { get; set; }
        public string Age { get; set; }
       // public sexual_enum sexual { get; set; }
    }
    public partial class MainWindow : Window
    {

        ObservableCollection<people> peopleList = new ObservableCollection<people>();
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            peopleList.Add(new people()
            {
                Name = "小明",
                Age = "18",
                //sexual = sexual_enum.BOY,
            });

            peopleList.Add(new people()
            {
                Name = "小红",
                Age = "19",
                //sexual = sexual_enum.GIRL
            });

            peopleList.Add(new people()
            {
                Name = "汤姆",
                Age = "30",
                //sexual = sexual_enum.GIRL
            });

            ((this.FindName("DATA_GRID")) as DataGrid).ItemsSource = peopleList;
        }

        public string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString.ToString();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            SQLiteConnection sqlConnection = new SQLiteConnection(connectionString);
            SQLiteCommand sqlCommand = new SQLiteCommand
            {
                CommandText = "select * from Used",
                Connection = sqlConnection,
                CommandType = CommandType.Text
            };
            try
            {
                sqlConnection.Open();
                SQLiteDataAdapter SQLiteDataAdapter = new SQLiteDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                SQLiteDataAdapter.Fill(dataSet, "Used");
                DataTable dt = dataSet.Tables["Used"];
                this.DataGridView.ItemsSource = dt.DefaultView;
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ////MessageBox.Show("haha");
            //SQLiteConnection sqlConnection = new SQLiteConnection(connectionString);
            //SQLiteCommand SQLiteCommand = new SqlCommand
            //{
            //    CommandText = "select * from Student where Sname = '"+TextBoxName.Text.Trim()+"'",
            //    Connection = sqlConnection,
            //    CommandType = CommandType.Text
            //};
            //try
            //{
            //    SQLiteConnection.Open();
            //    SqlDataAdapter sqlDataAdapter = new SQLiteDataAdapter(SQLiteCommand);
            //    DataSet dataSet = new DataSet();
            //    sqlDataAdapter.Fill(dataSet, "Stu");
            //    DataTable dt = dataSet.Tables["Stu"];
            //    this.DataGridView.ItemsSource = dt.DefaultView;
            //}
            //catch
            //{
            //    MessageBox.Show("error");
            //}
        }

    }
}
