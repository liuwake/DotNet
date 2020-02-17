<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication3.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <div style="width:1800px; height:20px; background: Aqua ;margin:0 auto;">
               <div style="width:auto ; margin:0 auto; height: auto; text-align:center">
                   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
          </div>
          <div style="width:1800px; margin:0 auto; height: 800px;">
            <div style="height:800px; background:#555;width:600px; float:left">
                <asp:Image ID="Image1" runat="server" Height="800px" Width="600px" />
            </div>

            <div style="height:800px; background:#ccc;width:583px; float:right">
            <div style="height:326px; background:#ccc;width:573px; float:left">
           <div style="height:321px; background:#ccc;width:299px; float:left">
            <asp:Image ID="Image2" runat="server" Height="318px" Width="250px" />
              </div>
            <div style="height:321px; background:#ccc;width:250px; float:right">
                </div>

                        <asp:TextBox ID="TextBox1" runat="server" Height="395px" style="margin-top: 8px" TextMode="MultiLine" Width="570px"></asp:TextBox>
                <p>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="OfflineTest" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="GetHello" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="GetJson" />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="GetImageScanRaw" />
                    <asp:Button ID="Button5" runat="server" Text="GetImageScanResult" OnClick="Button5_Click" />
                </p>
              </div>

                </div>
          </div>
    </form>
</body>
</html>
