using System;
using System.Net;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Web.Services.Description; //需导入System.Web.Services程序集（添加引用）
using Microsoft.CSharp;

namespace WebApplication1
{
    public static class WebServiceHelper
    {
        #region 通过反射动态调用WebService

        #region 调用示例
        /************************************************************************************
         * 
         * WebService方法：
         * [WebMethod(Description = "WebService测试方法")]
         * public string SayHello(string paramIn,ref string paramOut)
         * {
         *      paramOut = string.Format("Hello {0}!", paramIn);
         *      return "Success";
         * }
         * 
         * 调用示例如下：
         * object[] objs = new object[] { "张三", "" }; //入参
         * var webServiceUrl = "http://TianYa.DotNetShare.WebServiceDemo/WebServiceTest.asmx";
         * object result = WebServiceHelper.InvokeWebService(webServiceUrl, "SayHello", objs); //返回结果
         * object paramOut = objs[1]; //出参
         * 
         ************************************************************************************/
        #endregion

        /// <summary>
        /// 通过反射动态调用WebService
        /// </summary>
        /// <param name="webServiceUrl">WebServices地址</param>
        /// <param name="methodName">调用的方法名</param>
        /// <param name="args">把调用WebService时需要的参数按顺序放到这个object[]里，如果无参数传null</param>
        /// <returns>返回调用WebService的返回值，如果调用出错则返回null</returns>
        public static object InvokeWebService(string webServiceUrl, string methodName, params object[] args)
        {
            //这里的namespace是需要引用的WebService的命名空间，不用改也可以正常使用。也可以加一个参数从外面传进来。
            string @namespace = "CsWebService";

            try
            {
                //判断webServiceUrl中末尾是否包含“?WSDL”，如果不包含则添加
                if (webServiceUrl != null && !webServiceUrl.Equals(""))
                {
                    if (webServiceUrl.LastIndexOf("?") > -1)
                    {
                        if (webServiceUrl.ToUpper().LastIndexOf("WSDL") <= -1)
                        {
                            webServiceUrl = webServiceUrl + "WSDL";
                        }
                    }
                    else
                    {
                        webServiceUrl = webServiceUrl + "?WSDL";
                    }
                }

                //获取WSDL
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(webServiceUrl);
                ServiceDescription sd = ServiceDescription.Read(stream);
                string className = sd.Services[0].Name;
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);

                //生成客户端代理类代码
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider csc = new CSharpCodeProvider();
                //ICodeCompiler icc = csc.CreateCompiler();

                //设定编译参数
                CompilerParameters cpList = new CompilerParameters();
                cpList.GenerateExecutable = false;//动态编译后的程序集不生成可执行文件
                cpList.GenerateInMemory = true;//动态编译后的程序集只存在于内存中，不在硬盘的文件上
                cpList.ReferencedAssemblies.Add("System.dll");
                cpList.ReferencedAssemblies.Add("System.XML.dll");
                cpList.ReferencedAssemblies.Add("System.Web.Services.dll");
                cpList.ReferencedAssemblies.Add("System.Data.dll");

                //编译代理类
                CompilerResults cr = csc.CompileAssemblyFromDom(cpList, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }

                    //错误日志处理
                    throw new Exception(sb.ToString());
                }

                //生成代理实例，并调用方法
                System.Reflection.Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + className, true, true);
                object obj = Activator.CreateInstance(t);
                System.Reflection.MethodInfo mi = t.GetMethod(methodName);

                //注：method.Invoke(obj, null)返回的是一个Object,
                //如果你服务端返回的是DataSet,这里也是用(DataSet)method.Invoke(obj, null)转一下就行了,
                //method.Invoke(obj,null)这里的null可以传调用方法需要的参数,string[]形式的
                return mi.Invoke(obj, args);
            }
            catch (Exception ex)
            {
                //异常日志处理
                return null;
            }
        }
        #endregion
    }
}