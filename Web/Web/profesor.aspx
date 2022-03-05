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
        </div>
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem Text="Tareas" Value="Tareas.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Nuevo elemento" Value="Nuevo elemento"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </form>
</body>
</html>
