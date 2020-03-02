using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class MiaUsedBrowser : System.Web.UI.Page
    {
        WebRef.Service1 clientWcf = new WebRef.Service1();
        WebRefDb.Service1 clientDb = new WebRefDb.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TextBox2.Text += "No Web Test OK" + "\n";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.TextBox2.Text += clientWcf.GetHello() + "\n";

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = clientWcf.GetJson();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string base64 = clientWcf.GetImageScanRaw();
            this.Image1.ImageUrl = "data:image/jpg;base64," + base64;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string base64 = clientWcf.GetImageScanResult();
            this.Image2.ImageUrl = "data:image/jpg;base64," + base64;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            clientDb.openSql();
            GridView1.DataSource = clientDb.dbNew();
            GridView1.DataBind();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}