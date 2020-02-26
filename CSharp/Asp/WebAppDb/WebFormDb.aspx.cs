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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DbAll();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            DbNow();
        }

        //Func Sql
        public void DbAll()
        {
            string connString = "Data Source=C:\\WK\\Db\\Used.sqlite;Version=3";
            SQLiteConnection sqlConnection = new SQLiteConnection(connString);
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
                this.GridView1.DataSource = dt.DefaultView;
                GridView1.DataBind();
            }
            catch (SQLiteException ex)
            {
                this.Label1.Text = ex.ToString();
            }
        }
        public void DbNow()
        {
            string connString = "Data Source=C:\\WK\\Db\\Used.sqlite;Version=3";
            SQLiteConnection sqlConnection = new SQLiteConnection(connString);
            SQLiteCommand sqlCommand = new SQLiteCommand
            {
                CommandText = "select * from Used WHERE DbId ORDER BY DbId DESC LIMIT 1",
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
                this.GridView2.DataSource = dt.DefaultView;
                GridView2.DataBind();
            }
            catch (SQLiteException ex)
            {
                this.Label1.Text = ex.ToString();
            }
        }


    }
}