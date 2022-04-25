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
            Main Alumno<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Cerrar Sesión</asp:LinkButton>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/VerTareasEstudiante.aspx">Tareas</asp:LinkButton>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
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
                        <asp:BoundField DataField="email" HeaderText="Alumnos conectados" ReadOnly="True" SortExpression="email" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="SELECT [email] FROM [Conectados] WHERE ([tipo] = @tipo)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="alumno" Name="tipo" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="SELECT [email] FROM [Conectados] WHERE ([email] = @email)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="profesor" Name="email" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                Buscando usuarios...
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
