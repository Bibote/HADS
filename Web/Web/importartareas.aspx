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
        </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="getTareasProfe" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="mail" SessionField="nombre" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Importar" />
        </p>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/profesor.aspx">Atras</asp:LinkButton>
    </form>
</body>
</html>
