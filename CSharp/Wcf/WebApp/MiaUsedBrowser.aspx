<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiaUsedBrowser.aspx.cs" Inherits="WebApp.MiaUsedBrowser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1800px; height: 20px; background: Aqua; margin: 0 auto;">
            <div style="width: auto; margin: 0 auto; height: auto; text-align: center">
                <asp:Label ID="Label1" runat="server" Text="医疗信息自动化B平台(浏览器端)Demo"></asp:Label>
            </div>
        </div>
        <div style="width: 1800px; margin: 0 auto; height: 800px;">
            <div style="height: 800px; background: #555; width: 600px; float: left">
                <asp:Image ID="Image1" runat="server" Height="800px" Width="600px" />
            </div>
            <div style="height: 800px; background: #555; width: 600px; float: left">
                <asp:Image ID="Image2" runat="server" Height="800px" Width="600px" />
            </div>

            <div style="height: 800px; background: #ccc; width: 600px; float: right">
                <div style="height: 392px; background: #ccc; width: 600px; float: left">

                    <asp:TextBox ID="TextBox1" runat="server" Height="364px" Style="margin-top: 8px" TextMode="MultiLine" Width="582px" Wrap="False" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    
                </div>
                <div style="height: 154px; background: #ccc; width: 600px; float: right">

                    <asp:GridView ID="GridView1" runat="server" Height="102px" Width="586px">
                    </asp:GridView>

                </div>
                 <div style="height: 112px; background: #ccc; width: 600px; float: left">
                     <asp:TextBox ID="TextBox2" runat="server" Height="97px" Width="585px" TextMode="MultiLine" Wrap="False"></asp:TextBox>
                     </div>
                     <div style="height: 100px; background: #ccc; width: 600px; float: left">
                     <p>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="OfflineTest" />
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="GetHello" />
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="GetJson" />
                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="GetImageScanRaw" />
                        <asp:Button ID="Button5" runat="server" Text="GetImageScanResult" OnClick="Button5_Click" />
                         <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="dbNew" />
                    </p>
                    </div>
            </div>
            
        </div>
    </form>
</body>
</html>
