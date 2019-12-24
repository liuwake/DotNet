using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.IO;//AI System File IO

namespace CsWebService
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Add(int a, int b)
        {
            return a + b;
        }
        [WebMethod]
        public void SendImage(string CsImage, string CheckDateTime)
        {
            // 获取调用者 (Cs设备) 的IP地址
            string CsIPAddress = Context.Request.UserHostAddress.ToString();

            // Base64编码图像文件转换为二进制buffer
            byte[] CsImageBuffer = Convert.FromBase64String(CsImage);
            
            string CsImageFileName = "U" + System.DateTime.Now.ToFileTime() + ".jpg";
            
            if (CsImage != "")
                BytesToFile(CsImageBuffer, Server.MapPath("/") + CsImageFileName);

        }

        // 把Base64编码的图像文件保存到本地文件
        private void BytesToFile(byte[] bytes, string filePath)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    ms.WriteTo(fs);
                }
            }
        }
    }
}
