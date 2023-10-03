<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HelloWebForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="PetCode" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="PetCode" HeaderText="PetCode" InsertVisible="False" ReadOnly="True" SortExpression="PetCode" />
                <asp:BoundField DataField="PetName" HeaderText="PetName" SortExpression="PetName" />
                <asp:BoundField DataField="PetGender" HeaderText="PetGender" SortExpression="PetGender" />
                <asp:BoundField DataField="PetColor" HeaderText="PetColor" SortExpression="PetColor" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:AnimalDBConnectionString %>" DeleteCommand="DELETE FROM [Pets] WHERE [PetCode] = @original_PetCode AND [PetName] = @original_PetName AND [PetGender] = @original_PetGender AND (([PetColor] = @original_PetColor) OR ([PetColor] IS NULL AND @original_PetColor IS NULL))" InsertCommand="INSERT INTO [Pets] ([PetName], [PetGender], [PetColor]) VALUES (@PetName, @PetGender, @PetColor)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:AnimalDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Pets]" UpdateCommand="UPDATE [Pets] SET [PetName] = @PetName, [PetGender] = @PetGender, [PetColor] = @PetColor WHERE [PetCode] = @original_PetCode AND [PetName] = @original_PetName AND [PetGender] = @original_PetGender AND (([PetColor] = @original_PetColor) OR ([PetColor] IS NULL AND @original_PetColor IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_PetCode" Type="Int32" />
                <asp:Parameter Name="original_PetName" Type="String" />
                <asp:Parameter Name="original_PetGender" Type="String" />
                <asp:Parameter Name="original_PetColor" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PetName" Type="String" />
                <asp:Parameter Name="PetGender" Type="String" />
                <asp:Parameter Name="PetColor" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PetName" Type="String" />
                <asp:Parameter Name="PetGender" Type="String" />
                <asp:Parameter Name="PetColor" Type="String" />
                <asp:Parameter Name="original_PetCode" Type="Int32" />
                <asp:Parameter Name="original_PetName" Type="String" />
                <asp:Parameter Name="original_PetGender" Type="String" />
                <asp:Parameter Name="original_PetColor" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
