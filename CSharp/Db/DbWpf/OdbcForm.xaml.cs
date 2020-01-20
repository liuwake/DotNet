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
        DataSet ds = new DataSet();
        string sql = @"Select * from Used";
        OdbcConnection connection;

        public OdbcForm()
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
            //string connString = "Driver={Microsoft Access Driver (*.mdb)};" + "Dbq=C:\\WK\\Db\\Used.mdb;";
            string connString = "Dsn=Used"; 
            this.connection = new OdbcConnection(connString);//THIS!
        }
        public void UsedSaveChange()//save 功能bug
        {
            OdbcDataAdapter da = new OdbcDataAdapter();
            da.SelectCommand = new OdbcCommand(sql, connection);
            OdbcCommandBuilder cb = new OdbcCommandBuilder(da);
            DataTable dt = new DataTable();
            dt = ((DataView)dataGridResult.ItemsSource).Table;
            da.Update(ds.Tables["Used"]);  //DataGrid和ds的table绑定之后，DataGrid的更改会自动更新到Dataset
        }
        public void UsedUpdateData()
        {
            OdbcDataAdapter da = new OdbcDataAdapter(sql, connection);  //创建SqlDataAdapter实例da，并指定SQL查询string和SqlConnection
            da.Fill(ds, "Used");  //从数据库中读取数据，并填充ds
            DataView dv = new DataView(ds.Tables["Used"]); //创建DataView实例dv，并指定其DataTable
            dataGridResult.ItemsSource = dv;  //设置DataGrid的ItemsSource属性
        }
        public void UsedUpdateCode()
        {
            //
            //OdbcConnection connection = new OdbcConnection(connString);
            ////string sql = @"Select * from Used";
            ////DataSet ds = new DataSet();
            //OdbcDataAdapter da = new OdbcDataAdapter(sql, connection);  //创建SqlDataAdapter实例da，并指定SQL查询string和SqlConnection

            //da.Fill(ds, "Used");  //从数据库中读取数据，并填充ds
            //DataView dv = new DataView(ds.Tables["Used"]); //创建DataView实例dv，并指定其DataTable
            //dataGridResult.ItemsSource = dv;  //设置DataGrid的ItemsSource属性

        }

    }
}
