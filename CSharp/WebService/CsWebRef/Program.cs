using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsWebRef
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRef.WebService1 webService = new WebRef.WebService1();

            int a = 2;
            int b = 3;
            Console.WriteLine(webService.HelloWorld());
            Console.WriteLine(a + "+" + b + "=" + webService.Add(a, b));
            Console.ReadKey();

        }
    }
}
