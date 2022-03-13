<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Web.Estadisticas" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Seleccione un estudiante:<br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="email" DataValueField="email">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="SELECT [email] FROM [Usuario] WHERE ([tipo] = @tipo)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Alumno" Name="tipo" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <p>
            Horas Estimadas:<asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2">
                <series>
                    <asp:Series Name="Series1" XValueMember="codTarea" YValueMembers="hEstimadas" YValuesPerPoint="2">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            Horas Reales:<asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource3">
                <series>
                    <asp:Series Name="Series1" XValueMember="codTarea" YValueMembers="hReales">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="SELECT * FROM [EstudianteTarea] WHERE ([email] = @email)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="email" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="SELECT * FROM [EstudianteTarea] WHERE ([email] = @email)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="email" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/profesor.aspx">Atras</asp:LinkButton>
        </p>
    </form>
</body>
</html>
