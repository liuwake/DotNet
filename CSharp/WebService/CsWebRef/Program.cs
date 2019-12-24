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

            if (TestAdd(webService) == 1)
            {
                Console.WriteLine("WebRef Test Add Fuction SUCCESS!!");
            }
            else
            {
                Console.WriteLine("WebRef Test Add Fuction FAILURE!!");
            }

            string CheckDateTime = DateTime.Now.ToString();


            //string URL = "http://localhost:8000/";
            string URL = "http://localhost:53640/WebService1.asmx?WSDL";
            string CsImagePath = "C:\\Users\\iwake\\OneDrive - wake\\Desktop\\Dog.jpg";
            if (CallWebService(URL, CsImagePath, CheckDateTime) == 1)
            {
                Console.WriteLine("WebRef Test Image Fuction SUCCESS!!");
            }
            else
            {
                Console.WriteLine("WebRef Test Image Fuction FAILURE!!");
            }

            Console.ReadKey();

        }
        public static int TestAdd(WebRef.WebService1 webService)
        {
            try
            {
                //WebRef.WebService1 webService = new WebRef.WebService1();
                int a = 2;
                int b = 3;
                Console.WriteLine(webService.HelloWorld());
                Console.WriteLine(a + "+" + b + "=" + webService.Add(a, b));
                return 1;
            }
            catch
            {
                return -1; 
            }          

        }
        //public static int TestImage(WebRef.WebService1 webService)
        //{
        //    try
        //    {
        //        //WebRef.WebService1 webService = new WebRef.WebService1();
        //        int a = 2;
        //        int b = 3;
        //        Console.WriteLine(webService.HelloWorld());
        //        Console.WriteLine(a + "+" + b + "=" + webService.Add(a, b));
        //        return 1;
        //    }
        //    catch
        //    {
        //        return -1;
        //    }

        //}
        public static int CallWebService(string URL, string UVSSImagePath, string CheckDateTime)
        {
            try
            {
                string UVSSImage = String.Empty;
                

                if (UVSSImagePath != "" && System.IO.File.Exists(UVSSImagePath))
                {
                    UVSSImage = ImageToBase64String(UVSSImagePath);
                    Console.WriteLine("Read Image Fuction SUCCESS!!");
                    Console.WriteLine(UVSSImage);
                }
                

                return InvokeWebservice(URL, "CsWebService", "WebService1", "SendImage", new object[] { UVSSImage, CheckDateTime });
            }
            catch
            {
                return -1;
            }
        }

        private static int InvokeWebservice(string url, string @namespace, string classname, string methodname, object[] args)
        {
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                System.IO.Stream stream = wc.OpenRead(url);
                System.Web.Services.Description.ServiceDescription sd = System.Web.Services.Description.ServiceDescription.Read(stream);
                System.Web.Services.Description.ServiceDescriptionImporter sdi = new System.Web.Services.Description.ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                System.CodeDom.CodeNamespace cn = new System.CodeDom.CodeNamespace(@namespace);
                System.CodeDom.CodeCompileUnit ccu = new System.CodeDom.CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);

                Microsoft.CSharp.CSharpCodeProvider csc = new Microsoft.CSharp.CSharpCodeProvider();
                System.CodeDom.Compiler.ICodeCompiler icc = csc.CreateCompiler();

                System.CodeDom.Compiler.CompilerParameters cplist = new System.CodeDom.Compiler.CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                System.CodeDom.Compiler.CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }
                System.Reflection.Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                System.Reflection.MethodInfo mi = t.GetMethod(methodname);

                mi.Invoke(obj, args);
            }
            catch
            {
                return -1;
            }

            return 1;
        }

        private static string ImageToBase64String(string ImagePath)
        {
            if (ImagePath == "")
                return "";

            byte[] buffer = new byte[0];
            System.IO.FileInfo fi = new System.IO.FileInfo(ImagePath);
            long len = fi.Length;
            System.IO.FileStream fs = new System.IO.FileStream(ImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
            buffer = new byte[len];
            fs.Read(buffer, 0, (int)len);
            fs.Close();

            return Convert.ToBase64String(buffer);
        }
    }
}
