using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;//AI System File IO
//using System.Web.Services;

namespace WcflessConsole
{
    class Comm
    {
        
        public string HelloWorld()
        {
            return "Hello World";
        }
        
        public int Add(int a, int b)
        {
            return a + b;
        }

        public static string GetImage()
        {
            string ImagePath = "C:\\WK\\Demo.jpg";
            return ImageToBase64String(ImagePath);
        }



        private static string ImageToBase64String(string ImagePath)
        {
            if (ImagePath == "")
                return "";

            byte[] buffer = new byte[0];
            System.IO.FileInfo fi = new System.IO.FileInfo(ImagePath);
            long len = fi.Length;
            System.IO.FileStream fs = new System.IO.FileStream(ImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            buffer = new byte[len];
            fs.Read(buffer, 0, (int)len);
            fs.Close();

            return Convert.ToBase64String(buffer);
        }

        //    //public void SaveString(string String, string CheckDateTime)
        //    public void SaveString(string String)
        //    {
        //        string PathString = "U" + System.DateTime.Now.ToFileTime() + ".txt";

        //        if (String != "")
        //            System.IO.File.WriteAllText(Server.MapPath("/") + "\\" + PathString, String);
        //        //Console.WriteLine("save Json at " + AppDirectory + "\\Result.txt");
        //        return;
        //    }

        //    public void SendImage(string CsImage, string CheckDateTime)
        //    {
        //        // 获取调用者 (Cs设备) 的IP地址
        //        //string CsIPAddress = Context.Request.UserHostAddress.ToString();

        //        // Base64编码图像文件转换为二进制buffer
        //        byte[] CsImageBuffer = Convert.FromBase64String(CsImage);

        //        string CsImageFileName = "U" + System.DateTime.Now.ToFileTime() + ".jpg";

        //        if (CsImage != "")
        //            BytesToFile(CsImageBuffer, Server.MapPath("/") + CsImageFileName);

        //    }

        //    // 把Base64编码的图像文件保存到本地文件
        //    private void BytesToFile(byte[] bytes, string filePath)
        //    {
        //        using (MemoryStream ms = new MemoryStream(bytes))
        //        {
        //            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        //            {
        //                ms.WriteTo(fs);
        //            }
        //        }
        //    }
    }
}
