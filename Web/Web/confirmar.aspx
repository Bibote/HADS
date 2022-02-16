<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmar.aspx.cs" Inherits="Web.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email validado</div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Inicio" />
    </form>
</body>
</html>
