<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasEstudiante.aspx.cs" Inherits="Web.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Seleccionar Asignatura:<br />
            <asp:DropDownList ID="asignatura" runat="server" AutoPostBack="True" OnSelectedIndexChanged="asignatura_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Tabla de tareas:<br />
            <br />
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seleccionar" />
                </Columns>
                <EmptyDataTemplate>
                    No hay tareas de esa asignatura
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
