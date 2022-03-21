<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="exportartareas.aspx.cs" Inherits="Web.exportartareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Exportar" />
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/profesor.aspx">Atras</asp:LinkButton>
        </p>
    </form>
</body>
</html>
