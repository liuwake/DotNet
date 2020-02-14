using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using ServiceReference1;
using WebApplication3.ServiceReference1;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Service1Client client = new Service1Client.Service1Client();
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text = "No Web Test OK";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            WeatherWebService.WeatherWebService w = new WeatherWebService.WeatherWebService();
            this.Label1.Text = w.getWeatherbyCityName("beijing")[5];


        }
    }
}