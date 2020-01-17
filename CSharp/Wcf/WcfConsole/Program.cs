using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WcfConsole.ServiceReference1;

namespace WcfConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1Client client = new Service1Client();

            Console.WriteLine(client.TestMethodInt(1));
            Console.WriteLine(client.TestMethodStr(1));
            Console.WriteLine(client.TestMethodDou(1, 2));


            Console.ReadLine();
            client.Close();
        }
    }
}
