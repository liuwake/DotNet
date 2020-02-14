using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = "offline test ok ";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            WeatherWebService.WeatherWebService w = new WeatherWebService.WeatherWebService();
            this.Label1.Text = w.getWeatherbyCityName("beijing")[5];

        }
    }
}