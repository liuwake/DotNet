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
using System.Data.Odbc;

namespace DbWpf
{
    /// <summary>
    /// OdbcForm.xaml 的交互逻辑
    /// </summary>
    public partial class OdbcForm : Window
    {
        //DataSet ds = new DataSet();
        //string sql = @"Select * from Used";
        //OdbcConnection connection;
        //DataView dataView;
        //OdbcDataAdapter da;

        public OdbcForm()
        {
            //Init
            InitializeComponent();
            //UsedInit();
        }
        // Wpf
        private void ButtonUsedUpdate_Click(object sender, RoutedEventArgs e)
        {
            UsedUpdateData();
        }

        //Func Sql
        //public void UsedInit()
        //{
        //    //string connString = "Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=C:\\WK\\Db\\Used.mdb;";
        //    string connString = "Dsn=Used"; 
        //    this.connection = new OdbcConnection(connString);//THIS!
        //}
        public void UsedSaveChange()//save 功能bug
        {
            string sql = @"Select * from Used";
            string connString = "Dsn=Used";
            OdbcConnection connection = new OdbcConnection(connString);
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(sql, connection);  //创建SqlDataAdapter实例da，并指定SQL查询string和SqlConnection
            DataSet dataSet = new DataSet();

            OdbcCommandBuilder commandBuilder = new OdbcCommandBuilder(dataAdapter);
            DataTable dataTable = new DataTable();
            dataTable = ((DataView)dataGridResult.ItemsSource).Table;
            dataAdapter.Update(dataSet.Tables["Used"]);  //DataGrid和ds的table绑定之后，DataGrid的更改会自动更新到Dataset
        }
        public void UsedUpdateData()
        {
            
            string sql = @"Select * from Used";
            string connString = "Dsn=Used";
            OdbcConnection connection = new OdbcConnection(connString);
            OdbcDataAdapter dataAdapter = new OdbcDataAdapter(sql, connection);  //创建SqlDataAdapter实例da，并指定SQL查询string和SqlConnection
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Used");  //从数据库中读取数据，并填充ds

            DataView  dataView = new DataView(dataSet.Tables["Used"]); //创建DataView实例dv，并指定其DataTable
            dataGridResult.ItemsSource = dataView;  //设置DataGrid的ItemsSource属性
        }
        //public void UsedUpdateOnece()
        //{
        //    OdbcDataAdapter da = new OdbcDataAdapter(sql, connection);  //创建SqlDataAdapter实例da，并指定SQL查询string和SqlConnection
        //    da.Fill(ds, "Used");  //从数据库中读取数据，并填充ds
        //    this.dataView = new DataView(ds.Tables["Used"]); //创建DataView实例dv，并指定其DataTable
        //    dataGridResult.ItemsSource = dataView;  //设置DataGrid的ItemsSource属性

        //}

    }
}
