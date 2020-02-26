using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SQLite;
//非独占sqlite
//sqlite更改后,刷新页面即可更新

namespace WebAppDb
{
    public partial class WebFormDb : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        string sql = @"Select * from Used";
        SQLiteConnection connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Load");
            UsedInit();
            UsedUpdateData();
        }

        public void UsedInit()
        {
            string connString = "Data Source=C:\\WK\\Db\\Used.sqlite;Version=3";
            this.connection = new SQLiteConnection(connString);//THIS!
            System.Diagnostics.Debug.WriteLine("UsedInite");
        }

        public void UsedUpdateData()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, connection);  //创建SqlDataAdapter实例da，并指定SQL查询string和SqlConnection
            da.Fill(ds, "Used");  //从数据库中读取数据，并填充ds
            DataView dv = new DataView(ds.Tables["Used"]); //创建DataView实例dv，并指定其DataTable
            GridView1.DataSource = dv;  //设置DataGrid的ItemsSource属性
            GridView1.DataBind();
            System.Diagnostics.Debug.WriteLine("UsedUpdateData");
        }

    }
}