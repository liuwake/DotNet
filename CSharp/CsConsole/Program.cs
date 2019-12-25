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
            //string json = @"{
            //                   'CPU': 'Intel',
            //                   'PSU': '500W',
            //                   'Drives': [
            //                     'DVD read/writer'
            //                     /*(broken)*/,
            //                     '500 gigabyte hard drive',
            //                     '200 gigabyte hard drive'
            //                   ]
            //                }";

            string json = @"{
                              'inhospitalno': '6458290',
                              'bedno': '51床',
                              'name': '姜国臣',
                              'age': '64',
                              'tagcode': [
                                '0110111441287'
                                /*二维码-NG,OCR-OK;*/,
                                '0110111441288',
                                '0110111441289',
                                '0110111441290',
                                '0110111441291'
                                /*二维码-NG,OCR-NG,需人工*/,
                                '0110111441292',
                                '0110111441293',
                                '0110111441294'
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
                writer.WritePropertyName("inhospitalno");
                writer.WriteValue("6458290");
                writer.WritePropertyName("bedno");
                writer.WriteValue("51床");
                writer.WritePropertyName("name");
                writer.WriteValue("姜国臣");
                writer.WritePropertyName("age");
                writer.WriteValue("64");
                writer.WritePropertyName("tagcode");
                writer.WriteStartArray();
                writer.WriteValue("0110111441287");
                writer.WriteComment("二维码-NG,OCR-OK;");
                writer.WriteValue("0110111441288");
                writer.WriteValue("0110111441289");
                writer.WriteValue("0110111441290");
                writer.WriteValue("0110111441291");
                writer.WriteComment("二维码-NG,OCR-NG,需人工");
                writer.WriteValue("0110111441292");
                writer.WriteValue("0110111441293");
                writer.WriteValue("0110111441294");
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
