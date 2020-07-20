using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;    //添加相应的引用即可

namespace OpenCVSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat source = new Mat(@"C:\WK\demo.jpg", ImreadModes.Color);
            Cv2.ImShow("Demo", source);
            Cv2.WaitKey(0);
        }
    }
}