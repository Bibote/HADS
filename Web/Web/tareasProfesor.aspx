<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tareasProfesor.aspx.cs" Inherits="Web.tareasProfesor" %>

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
            <asp:DropDownList ID="asignatura" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" AutoPostBack="True" OnSelectedIndexChanged="asignatura_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignatura]"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="codigo" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="codigo" HeaderText="codigo" ReadOnly="True" SortExpression="codigo" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="codAsig" HeaderText="codAsig" SortExpression="codAsig" />
                    <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                    <asp:CheckBoxField DataField="explotacion" HeaderText="explotacion" SortExpression="explotacion" />
                    <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" DeleteCommand="DELETE FROM [TareaGenerica] WHERE [codigo] = @original_codigo AND (([descripcion] = @original_descripcion) OR ([descripcion] IS NULL AND @original_descripcion IS NULL)) AND (([codAsig] = @original_codAsig) OR ([codAsig] IS NULL AND @original_codAsig IS NULL)) AND (([hEstimadas] = @original_hEstimadas) OR ([hEstimadas] IS NULL AND @original_hEstimadas IS NULL)) AND (([explotacion] = @original_explotacion) OR ([explotacion] IS NULL AND @original_explotacion IS NULL)) AND (([tipoTarea] = @original_tipoTarea) OR ([tipoTarea] IS NULL AND @original_tipoTarea IS NULL))" InsertCommand="INSERT INTO [TareaGenerica] ([codigo], [descripcion], [codAsig], [hEstimadas], [explotacion], [tipoTarea]) VALUES (@codigo, @descripcion, @codAsig, @hEstimadas, @explotacion, @tipoTarea)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)" UpdateCommand="UPDATE [TareaGenerica] SET [descripcion] = @descripcion, [codAsig] = @codAsig, [hEstimadas] = @hEstimadas, [explotacion] = @explotacion, [tipoTarea] = @tipoTarea WHERE [codigo] = @original_codigo AND (([descripcion] = @original_descripcion) OR ([descripcion] IS NULL AND @original_descripcion IS NULL)) AND (([codAsig] = @original_codAsig) OR ([codAsig] IS NULL AND @original_codAsig IS NULL)) AND (([hEstimadas] = @original_hEstimadas) OR ([hEstimadas] IS NULL AND @original_hEstimadas IS NULL)) AND (([explotacion] = @original_explotacion) OR ([explotacion] IS NULL AND @original_explotacion IS NULL)) AND (([tipoTarea] = @original_tipoTarea) OR ([tipoTarea] IS NULL AND @original_tipoTarea IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_codigo" Type="String" />
                    <asp:Parameter Name="original_descripcion" Type="String" />
                    <asp:Parameter Name="original_codAsig" Type="String" />
                    <asp:Parameter Name="original_hEstimadas" Type="Int32" />
                    <asp:Parameter Name="original_explotacion" Type="Boolean" />
                    <asp:Parameter Name="original_tipoTarea" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="codigo" Type="String" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="codAsig" Type="String" />
                    <asp:Parameter Name="hEstimadas" Type="Int32" />
                    <asp:Parameter Name="explotacion" Type="Boolean" />
                    <asp:Parameter Name="tipoTarea" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="asignatura" Name="codAsig" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="codAsig" Type="String" />
                    <asp:Parameter Name="hEstimadas" Type="Int32" />
                    <asp:Parameter Name="explotacion" Type="Boolean" />
                    <asp:Parameter Name="tipoTarea" Type="String" />
                    <asp:Parameter Name="original_codigo" Type="String" />
                    <asp:Parameter Name="original_descripcion" Type="String" />
                    <asp:Parameter Name="original_codAsig" Type="String" />
                    <asp:Parameter Name="original_hEstimadas" Type="Int32" />
                    <asp:Parameter Name="original_explotacion" Type="Boolean" />
                    <asp:Parameter Name="original_tipoTarea" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" Text="Añadir Tarea" OnClick="Button1_Click1" />
            <br />
        </div>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/profesor.aspx">Atras</asp:LinkButton>
        </p>
    </form>
</body>
</html>
