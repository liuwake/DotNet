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
            HalLive halLive = new HalLive();
            halLive.Info();

            //Console.WriteLine("halEn = " + halCam.halEn);
            Console.WriteLine("Image mean= " + halLive.hv_Mean.D);
            Console.WriteLine(halLive.ho_Image.GetType());
        }
    }
}
