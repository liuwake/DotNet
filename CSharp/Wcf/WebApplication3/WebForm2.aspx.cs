using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        WebRef.Service1 clientWcf = new WebRef.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = "No Web Test OK";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            

            // 使用 "client" 变量在服务上调用操作。

            // 始终关闭客户端。
            this.Label1.Text = clientWcf.GetHello();

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
    }
}