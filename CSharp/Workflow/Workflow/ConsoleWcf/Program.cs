using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleWcf
{
    class Program
    {
        //在数组程序中进行调用  
        static void Main(string[] args)
        {
            //在外部调用服务需要先启动服务，启动哪种类型的服务，用一个参数做服务的类型，也就是具体的实现，写具体的类
            using (ServiceHost host = new ServiceHost(typeof(AppServer)))
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