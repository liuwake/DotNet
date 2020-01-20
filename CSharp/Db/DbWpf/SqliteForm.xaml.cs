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
using System.Windows.Shapes;

using System.Data;
using System.Data.SQLite;

namespace DbWpf
{
    /// <summary>
    /// SqliteForm.xaml 的交互逻辑
    /// </summary>
    public partial class SqliteForm : Window
    {       
        DataSet ds = new DataSet();
        string sql = @"Select * from Used";
        SQLiteConnection connection;

        public SqliteForm()
        {
            //Init
            InitializeComponent();
            UsedInit();          
        }
        // Wpf
        private void ButtonUsedUpdate_Click(object sender, RoutedEventArgs e)
        {
            UsedUpdateData();
        }

        //Func Sql
        public void UsedInit()
        {
            string connString = "Data Source=C:\\WK\\Db\\Used.sqlite;Version=3";
            this.connection = new SQLiteConnection(connString);//THIS!
        }
        public void UsedSaveChange()//save 功能bug
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            da.SelectCommand = new SQLiteCommand(sql, connection);
            SQLiteCommandBuilder cb = new SQLiteCommandBuilder(da);
            DataTable dt = new DataTable();
            dt = ((DataView)dataGridResult.ItemsSource).Table;
            da.Update(ds.Tables["Used"]);  //DataGrid和ds的table绑定之后，DataGrid的更改会自动更新到Dataset
        }
        public void UsedUpdateData()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, connection);  //创建SqlDataAdapter实例da，并指定SQL查询string和SqlConnection
            da.Fill(ds, "Used");  //从数据库中读取数据，并填充ds
            DataView dv = new DataView(ds.Tables["Used"]); //创建DataView实例dv，并指定其DataTable
            dataGridResult.ItemsSource = dv;  //设置DataGrid的ItemsSource属性
        }
        public void UsedUpdateCode()
        {
            //
            //SQLiteConnection connection = new SQLiteConnection(connString);
            ////string sql = @"Select * from Used";
            ////DataSet ds = new DataSet();
            //SQLiteDataAdapter da = new SQLiteDataAdapter(sql, connection);  //创建SqlDataAdapter实例da，并指定SQL查询string和SqlConnection

            //da.Fill(ds, "Used");  //从数据库中读取数据，并填充ds
            //DataView dv = new DataView(ds.Tables["Used"]); //创建DataView实例dv，并指定其DataTable
            //dataGridResult.ItemsSource = dv;  //设置DataGrid的ItemsSource属性

        }

    }
}
