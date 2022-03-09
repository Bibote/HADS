<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profesor.aspx.cs" Inherits="Web.profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Cerrar Sesión</asp:LinkButton>
        </div>
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem Text="Tareas" Value="tareasProfesor.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </form>
</body>
</html>
