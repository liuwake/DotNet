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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = "No Web Test OK";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            WebRef.Service1 client = new WebRef.Service1();

            // 使用 "client" 变量在服务上调用操作。

            // 始终关闭客户端。
            this.Label1.Text = client.GetHello();

        }
    }
}