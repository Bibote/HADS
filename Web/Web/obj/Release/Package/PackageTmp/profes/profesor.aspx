<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profesor.aspx.cs" Inherits="Web.profesor" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

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
                <asp:MenuItem Text="Ver horas alumnos" Value="Estadisticas.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Importar tareas" Value="impoexpo/importartareas.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Exportar tareas" Value="impoexpo/exportartareas.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Eliminar Usuarios" Value="impoexpo/baneos.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Ver Tiempos" Value="impoexpo/tiempos.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="6000" OnTick="Timer1_Tick">
                </asp:Timer>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="email" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="email" HeaderText="Profesores conectados:" ReadOnly="True" SortExpression="email" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="email" DataSourceID="SqlDataSource2">
                    <Columns>
                        <asp:BoundField DataField="email" HeaderText="Alumnos conectados:" ReadOnly="True" SortExpression="email" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="SELECT [email] FROM [Conectados] WHERE ([tipo] = @tipo)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="alumno" Name="tipo" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="SELECT [email] FROM [Conectados] WHERE ([tipo] = @tipo)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="profesor" Name="tipo" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
        <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" BehaviorID="UpdatePanel1_UpdatePanelAnimationExtender" TargetControlID="UpdatePanel1">
        </ajaxToolkit:UpdatePanelAnimationExtender>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                Buscando Usuarios...
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
