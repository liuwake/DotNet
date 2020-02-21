
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWcf
{
    public class AppServer : IAppServer
    {
        public string GetStringFromWCF()
        {
            //实现接口返回Hello World
            return "Hello World";
        }
    }

}
