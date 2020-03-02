using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using static WcfClass.WcfClass;


//namespace WcfService1
//{
//    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
//    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
//    public class Service1 : ISvcMiaUsed
//    {
//        public string GetData(int value)
//        {
//            return string.Format("You entered: {0}", value);
//        }

//        public CompositeType GetDataUsingDataContract(CompositeType composite)
//        {
//            if (composite == null)
//            {
//                throw new ArgumentNullException("composite");
//            }
//            if (composite.BoolValue)
//            {
//                composite.StringValue += "Suffix";
//            }
//            return composite;
//        }
//    }
//}
namespace WcfSvc
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“ServiceDemo”。
    public class SvcMiaUsed : ISvcMiaUsed
    {
        public string GetHello()
        {
            return "hello";
        }

        public string TestMethodStr(int i)
        {
            return "param is:" + i;
        }

        public int GetAdd(int a,int b)
        {
            return a + b;
        }

        public string GetJson()
        {
            string infoJson =  @"{
                              'inhospitalno': '6458290',
                              'bedno': '51床',
                              'name': '姜国臣',
                              'age': '64',
                              'tagcode': [
                                '0110111441287'
                                /*二维码-NG,OCR-OK;*/,
                                '0110111441288',
                                '0110111441289',
                                '0110111441290',
                                '0110111441291'
                                /*二维码-NG,OCR-NG,需人工*/,
                                '0110111441292',
                                '0110111441293',
                                '0110111441294'
                              ]
                                }";

            return infoJson;
        }

        public string GetImageScanResult()
        {
            string imagePath = @"C:\Users\iwake\OneDrive - wake\Desktop\Mia\Images\ScanResult.jpg";
            return WcfClass.WcfClass.ImageToBase64String(imagePath);
        }
        public string GetImageScanRaw()
        {
            string imagePath = @"C:\Users\iwake\OneDrive - wake\Desktop\Mia\Images\ScanRaw.jpg";
            return WcfClass.WcfClass.ImageToBase64String(imagePath);
        }

        public string GetScan()
        {
            string imagePath = "C:\\WK\\Demo.jpg";
            string scanJson = @"{
                              'inhospitalno': '6458290',
                              'bedno': '51床',
                              'name': '姜国臣',
                              'age': '64',
                              'tagcode': [
                                '0110111441287'
                                /*二维码-NG,OCR-OK;*/,
                                '0110111441288',
                                '0110111441289',
                                '0110111441290',
                                '0110111441291'
                                /*二维码-NG,OCR-NG,需人工*/,
                                '0110111441292',
                                '0110111441293',
                                '0110111441294'
                              ],
                              'image': '" +
                              WcfClass.WcfClass.ImageToBase64String(imagePath) +
                              "'}";
            return scanJson;

        }
        //public Int32 TestMethodInt(int i)
        //{
        //    return i;
        //}

        //public Double TestMethodDou(int i, int j)
        //{
        //    return i / j;
        //}
    }
}