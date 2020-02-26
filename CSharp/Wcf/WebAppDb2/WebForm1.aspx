<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAppDb2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Height="229px" TextMode="MultiLine" Width="744px"></asp:TextBox>
            <asp:GridView ID="GridView1" runat="server" Height="155px" Width="749px">
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server" Height="71px" Width="747px">
            </asp:GridView>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="dbAll" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="height: 21px" Text="dbNew" />
    </form>
</body>
</html>
