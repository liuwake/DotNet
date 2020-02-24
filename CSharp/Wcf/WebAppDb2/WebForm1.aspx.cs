using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SQLite;

namespace WebAppDb2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        WebRef.Service1 clientWcf = new WebRef.Service1();
        WebRefDb.Service1 clientDb = new WebRefDb.Service1();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = "No Web Test OK";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //this.TextBox1.Text = clientWcf.GetJson();
            clientDb.openSql();
            GridView1.DataSource = clientDb.querySql();
            GridView1.DataBind();
            //}
            //catch(SQLiteException ex)
            //{
            //    this.Label1.Text = ex.ToString();
            //}

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = clientDb.GetHello();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}