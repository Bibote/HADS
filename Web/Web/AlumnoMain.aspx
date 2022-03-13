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
            Main Alumno<br />
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/VerTareasEstudiante.aspx">Tareas</asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton2" runat="server">Ver horas alumnos</asp:LinkButton>
        </div>
    </form>
</body>
</html>
