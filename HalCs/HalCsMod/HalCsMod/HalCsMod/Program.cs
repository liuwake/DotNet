using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using HalconDotNet;

namespace HalCsMod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
           try
            {
                HalMain();

            }
            catch(HalconException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        static void HalMain()
        {
            HalCam halCam = new HalCam();
            halCam.Cam();
            halCam.Vision(out HTuple hv_Mean, out HTuple hv_Deviation);
            Console.WriteLine("halEn = " + halCam.halEn);
            Console.WriteLine("Image mean= " + hv_Mean.D);
            Console.WriteLine(halCam.ho_Image.GetType());
        }
    }
}
