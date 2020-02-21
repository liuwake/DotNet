
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleWcf
{
    //接口对外公开的标记
    [ServiceContract]
    public interface IAppServer
    {
        //方法对外公开的标记
        [OperationContract]
        //写一个方法
        string GetStringFromWCF();
    }

}