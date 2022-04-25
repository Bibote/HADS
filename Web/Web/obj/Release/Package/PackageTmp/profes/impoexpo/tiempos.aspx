<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tiempos.aspx.cs" Inherits="Web.profes.impoexpo.tiempos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codAsig" DataValueField="codAsig" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="SELECT DISTINCT [codAsig] FROM [TareaGenerica]"></asp:SqlDataSource>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/profes/profesor.aspx">Atras</asp:LinkButton>
    </form>
</body>
</html>
