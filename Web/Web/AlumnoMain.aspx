<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlumnoMain.aspx.cs" Inherits="Web.AlumnoMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Main Alumno</div>
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem Text="Tareas" Value="VerTareasEstudiante.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Ver horas alumnos" Value="Estadisticas.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </form>
</body>
</html>
