<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormDb.aspx.cs" Inherits="WebAppDb.WebFormDb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="GridView1" runat="server" Height="244px" Width="474px">
            </asp:GridView>

            <br />
            <asp:GridView ID="GridView2" runat="server" Height="73px" Width="472px">
            </asp:GridView>

        </div>
        <p>
        <asp:Label ID="Label1" runat="server" Text="Label" Width="200px"></asp:Label>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
