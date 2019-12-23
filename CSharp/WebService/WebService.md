# CSharpPractice

## CSharp
### WebService
----

# WebService
## Folw
### VS + C# + WebService = CsWebService搭建教程
#### 新建项目
- Visual C# - Web - ASP.NET Web 应用程序(.NET Framework) - 确定
- 新建 ASP.NET Web应用程序 - 空 - (啥也不点)确定
#### 新建项(默认.NET 3.5)
- 解决方案资源管理器 - 项目 - 右击 - 添加 -新建项
- Visual C# - Web - Web服务(ASMX) - 名字默认```WebService1.asmx```
#### 添加功能
- ```WebService1.asmx```自带 ```hello word```功能
- 添加一个加法程序
- ```
   [WebMethod]
      public int Add(int a, int b)
      {
          return a + b;
      }
   ```
  - 可在此处添加断点,以便调试
#### 调试
- F5 或者点击绿色按钮
- **注意**:
  - 调试的chrome窗口实例关闭(或者合并)后,VS自动判定调试结束;
#### 发布
- 解决方案资源管理器 - 项目 - 右击 - 发布
- 选取发布目标 - IIS, FTP等 - 发布
- 发布
  -  连接 
     -  发布方法 - 文件系统
     -  目标位置 - *自己定*
  -  配置 - 默认
  -  发布
  -  注意:在发布页面F5和其他页面F5下效果不一样(在哪一页开的F5就会调试哪一页)
#### IIS管理器配置
 -  (左栏)连接 - 主机名(eg. WK-HS) - 网站 - 右击 - 添加网站
 -  ```在弹出的新建网站界面中输入网站的名称、VS发布的WebService文件路径、IP地址和端口（本机可以不填，或者填127.0.0.1，如果其他电脑访问需要输入本机实际地址），然后点击确定，网站就创建完成了。```
 -  (右栏)操作 - 浏览网站 - 浏览*:8000(http)
#### Error
##### 发布错误
- HTTP 错误 500.19 - Internal Server Error
   - ```配置错误:由于权限不足无法读取文件```
     - 编辑权限
   - ```配置错误	   定义了重复的“system.web.extensions/scripting/scriptResourceHandler”节```
     - 解决1:(左栏)连接 - 应用程序池 - ```CsWebService``` - 右击 - 基本设置
       - NET CLR 版本 - NET CLR 版本 v2.0xxxx
       - 团管管道模式 - 经典
     - 解决2:项目 - 应用程序池 - 选.NET2.0 Classic
     - [ref: 解决方法:定义了重复的“system.web.extensions/scripting/scriptResourceHandler”](https://www.mycodes.net/75/6127.htm)
- ```HTTP 错误 403.14``` 
  -  ```Forbidden Web 服务器被配置为不列出此目录的内容。```
     -  注意:每次发布都要改.*???如何配置发布config自动改完??? *
     - 解决:(中栏)IIS主页 
       - 目录浏览 - 双击 - 启用
       - 默认文档 - 添加- WebService1.asmx
  -  ```请求的内容似乎是脚本，因而将无法由静态文件处理程序来处理。```
     -  原因:VS调试成功,但是脱离环境出现此报错;因为VS有ASP.NET环境,而客户机没有安装
     -  解决:程序功能 - 启用和关闭Windows功能 - Internet Information Serivices - 万维网服务 - 应用程序开发功能- 增加ASP.NET 3.5和ASP
     -  [Ref: IIS部署 请求的内容似乎是脚本，因而将无法由静态文件处理程序来处理。](https://www.jianshu.com/p/d174fe955526)
##### 调试错误:
- HTTP Error 403.14 - Forbidden
## Ref
- [C#发布WebService](https://blog.csdn.net/han_better/article/details/81368433)



## TODO
- [ ] 