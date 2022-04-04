<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baneos.aspx.cs" Inherits="Web.admin.baneos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Eliminar Usuarios</div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="email" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="email" HeaderText="email" ReadOnly="True" SortExpression="email" />
                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                <asp:BoundField DataField="apellidos" HeaderText="apellidos" SortExpression="apellidos" />
                <asp:CheckBoxField DataField="confirmado" HeaderText="confirmado" SortExpression="confirmado" />
                <asp:BoundField DataField="tipo" HeaderText="tipo" SortExpression="tipo" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:HADS2206ConnectionString %>" DeleteCommand="DELETE FROM [Usuario] WHERE [email] = @original_email AND [nombre] = @original_nombre AND [apellidos] = @original_apellidos AND [confirmado] = @original_confirmado AND [tipo] = @original_tipo" InsertCommand="INSERT INTO [Usuario] ([email], [nombre], [apellidos], [confirmado], [tipo]) VALUES (@email, @nombre, @apellidos, @confirmado, @tipo)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [email], [nombre], [apellidos], [confirmado], [tipo] FROM [Usuario] WHERE ([email] &lt;&gt; @email)" UpdateCommand="UPDATE [Usuario] SET [nombre] = @nombre, [apellidos] = @apellidos, [confirmado] = @confirmado, [tipo] = @tipo WHERE [email] = @original_email AND [nombre] = @original_nombre AND [apellidos] = @original_apellidos AND [confirmado] = @original_confirmado AND [tipo] = @original_tipo">
            <DeleteParameters>
                <asp:Parameter Name="original_email" Type="String" />
                <asp:Parameter Name="original_nombre" Type="String" />
                <asp:Parameter Name="original_apellidos" Type="String" />
                <asp:Parameter Name="original_confirmado" Type="Boolean" />
                <asp:Parameter Name="original_tipo" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="nombre" Type="String" />
                <asp:Parameter Name="apellidos" Type="String" />
                <asp:Parameter Name="confirmado" Type="Boolean" />
                <asp:Parameter Name="tipo" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="admin@ehu.es" Name="email" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="nombre" Type="String" />
                <asp:Parameter Name="apellidos" Type="String" />
                <asp:Parameter Name="confirmado" Type="Boolean" />
                <asp:Parameter Name="tipo" Type="String" />
                <asp:Parameter Name="original_email" Type="String" />
                <asp:Parameter Name="original_nombre" Type="String" />
                <asp:Parameter Name="original_apellidos" Type="String" />
                <asp:Parameter Name="original_confirmado" Type="Boolean" />
                <asp:Parameter Name="original_tipo" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl=" ">Atras</asp:LinkButton>
        </p>
    </form>
</body>
</html>
