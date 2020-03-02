using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
//using WcfConsole.ProgHost;

//using WcfConsole.ServiceReference1;

namespace WcfConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo.TestOffline();
            ProgHostMiaUsed();

            //Service1Client client = new Service1Client();

            //Console.WriteLine(client.TestMethodInt(1));
            //Console.WriteLine(client.TestMethodStr(1));
            //Console.WriteLine(client.TestMethodDou(1, 2));


            //Console.ReadLine();
            //client.Close();
        }
        public static void ProgHostMiaUsed()
        {
            //在外部调用服务需要先启动服务，启动哪种类型的服务，用一个参数做服务的类型，也就是具体的实现，写具体的类
            //需手动添加app.config
            using (ServiceHost host = new ServiceHost(typeof(WcfSvc.SvcMiaUsed)))
            {
                //打开服务
                host.Open();
                //提示服务已经启动
                Console.WriteLine("服务已经启动！");
                Console.ReadLine();
            }
        }
    }
}
