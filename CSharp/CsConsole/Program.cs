using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Json
using Newtonsoft.Json;
//IO
using System.IO;

namespace CsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 10330; i++)
            {
                Console.WriteLine("hello");
            }
            Test test = new Test();
            test.ProcessDelegate(TestJsonRead);
            test.ProcessDelegate(TestJsonWrite);
            //TestJson();

            Console.Write("按任意键退出...");
            Console.ReadKey(true);

        }
        public  static void TestJsonRead()
        {
            string json = @"{
                               'CPU': 'Intel',
                               'PSU': '500W',
                               'Drives': [
                                 'DVD read/writer'
                                 /*(broken)*/,
                                 '500 gigabyte hard drive',
                                 '200 gigabyte hard drive'
                               ]
                            }";

            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                }
                else
                {
                    Console.WriteLine("Token: {0}", reader.TokenType);
                }
            }
        }
        public static void TestJsonWrite()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();
                writer.WritePropertyName("CPU");
                writer.WriteValue("Intel");
                writer.WritePropertyName("PSU");
                writer.WriteValue("500W");
                writer.WritePropertyName("Drives");
                writer.WriteStartArray();
                writer.WriteValue("DVD read/writer");
                writer.WriteComment("(broken)");
                writer.WriteValue("500 gigabyte hard drive");
                writer.WriteValue("200 gigabyte hard drive");
                writer.WriteEnd();
                writer.WriteEndObject();
                //string output = JsonConvert.DeserializeObject(writer);
                Console.WriteLine(sb.ToString());
            }

            // {
            //   "CPU": "Intel",
            //   "PSU": "500W",
            //   "Drives": [
            //     "DVD read/writer"
            //     /*(broken)*/,
            //     "500 gigabyte hard drive",
            //     "200 gigabyte hard drive"
            //   ]
            // }
        }
        public static void TestFunc()
        {

            return;
        }
    }
    public class Test
    {

        public delegate void MyDelegate();

        public void ProcessDelegate(MyDelegate myDelegate)
        {
            try
            {
                myDelegate();
                Console.WriteLine("----Function Tester:Function OK----");
            }
            catch
            {
                Console.WriteLine("----Function Tester:Function NG----");
            }
            
        }
    }

    
    }
