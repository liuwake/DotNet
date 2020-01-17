# CSharpPractice

## CSharp
### Wcf
----
# Wcf
## Intro
- [The Windows Communication Foundation (WCF), previously known as Indigo, is a runtime and a set of APIs in the .NET Framework for building connected, service-oriented applications.[1][2]](https://en.wikipedia.org/wiki/Windows_Communication_Foundation)
- [zhihu wcf](https://www.zhihu.com/search?type=content&q=wcf)
## Config
### local PC config

## Flow


#### Error
##### 发布错误
- [asp.net发布网站的时候出现， "发布遇到错误，未将对象引用设置到对象的实例。](https://bbs.csdn.net/topics/393598263?list=16718956)
  - ```tmpE44E.tmp```:
```2020/1/16 17:58:49
System.NullReferenceException: 未将对象引用设置到对象的实例。
   在 Microsoft.VisualStudio.ApplicationCapabilities.Publish.Provider.DefaultPublishTabProvider.InitializeProvider(IVsHierarchy hierarchy)
   在 Microsoft.VisualStudio.ApplicationCapabilities.Publish.Provider.DefaultPublishTabProvider.CreateViewAsync(IVsHierarchy project, IAsyncServiceProvider serviceProvider, CancellationToken cancellationToken)
   在 Microsoft.VisualStudio.ApplicationCapabilities.Publish.Provider.ManagedPublishProvider.<CreateViewAsync>d__3.MoveNext()
- 原因:VS发布组件错误
- 解决:VS installer - repair 
===================
```
##### 调试错误:
 
- ```HTTP 错误 404.3 - Not Found 由于扩展配置问题而无法提供您请求的页面。如果该页面是脚本，请添加处理程序。如果应下载文件，请添加 MIME 映射。```
  
  - 原因:可能是.NET4.x没有注册激活HTTP的服务
    - 解决:安装```.NET Framwork 4.8 Advances Services```
      - Windows 功能 - `.NET Framwork 4.8 Advances Services - WCF服务 - HTTP激活
        - 此时已选:```HTTP激活```,```TCP端口激活```
  - 其他原因:
    - [svc 报“由于扩展配置问题而无法提供您请求的页面。如果该页面是脚本，请添加处理程序。如果应下载文件，请添加 MIME 映射。“的HTTP 错误 404.3 – Not Found](https://blog.csdn.net/jumtre/article/details/38398355)
    - [由于扩展配置问题而无法提供您请求的页面。如果该页面是脚本,请添加处理程序。](https://blog.csdn.net/y13156556538/article/details/73920771)
    - [由于扩展配置问题而无法提供您请求的页面。如果该页面是脚本,请添加处理程序。如](https://wenku.baidu.com/view/22197728482fb4daa58d4b4a.html)
    - [由于扩展配置问题而无法提供您请求的页面。如果该页面是脚本，请添加处理程序。](https://bbs.csdn.net/topics/330269295)

## Ref
- [【WCF系列一】WCF入门教程(图文) VS2012](https://www.cnblogs.com/merlinhome/p/3542451.html)注意修改服务名```WcfServiceLibrary1.Service1```到```WcfServiceLibrary1.PersonService```("编辑```app.config```配置和手动修改```app.config```皆可)
- [【WCF系列二：如何调用WCF服务】WCF入门教程（图文）VS2012](https://www.cnblogs.com/merlinhome/p/3615745.html)
## GitProj
- https://github.com/dotnet/wcf s1.3k