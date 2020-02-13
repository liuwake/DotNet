using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcflessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
            //string testString = Comm.GetImage();
            Console.WriteLine(Comm.GetImage());
            Console.ReadKey();
        }
    }
}
