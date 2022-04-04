<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="importartareas.aspx.cs" Inherits="Web.importartareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Importar" />
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
        </p>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/profesor.aspx">Atras</asp:LinkButton>
    </form>
</body>
</html>
