using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void FileSomething()
        {
            ///Init Dir
            //string[] imagePath = null;
            string[] imagePath = new string[100];
            //Image Failure
            string[] imageName = null;
            imageName = Directory.GetFiles(@"C:\Users\iwake\OneDrive - wake\Desktop\Mia\Images\0821");
            for (int i = 0; i < imageName.Length; i++)
            {
                imageName[i] = imageName[i].Remove(0, 55);
                imageName[i] = imageName[i].Substring(0, 36);
                Console.WriteLine(imageName[i]);

                imagePath[i] = @"D:\WK\Hospital\表单扫描\0820扫描表单\黑\img\" + imageName[i];
                //imagePath[i] = "abc" ;
                Console.WriteLine(imagePath[i]);
                //File.Copy(imagePath[i], @"C:\Users\iwake\OneDrive - wake\Desktop\Mia\Images\0821Ori\" + imageName[i], true);
            }
            // Image All
            //imagePath = Directory.GetFiles(@"D:\WK\Hospital\表单扫描\0806扫描表单\img");
            //imagePath = Directory.GetFiles(@"C:\Users\iwake\OneDrive - wake\Desktop\Mia\Images\SmallBar");
        }



        static void TimeSomething()
        {
            DateTime beforeDT = System.DateTime.Now;
            
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforeDT);
            Console.WriteLine("DateTime costed for Shuffle function is: {0}ms", ts.TotalMilliseconds);
        }
    }
}
