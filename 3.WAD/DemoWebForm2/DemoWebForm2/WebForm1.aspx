<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DemoWebForm2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="EmpID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="EmpID" HeaderText="EmpID" ReadOnly="True" SortExpression="EmpID" />
                    <asp:BoundField DataField="EmpName" HeaderText="EmpName" SortExpression="EmpName" />
                    <asp:BoundField DataField="EmpGender" HeaderText="EmpGender" SortExpression="EmpGender" />
                    <asp:BoundField DataField="DepID" HeaderText="DepID" SortExpression="DepID" />
                    <asp:BoundField DataField="EmpAge" HeaderText="EmpAge" SortExpression="EmpAge" />
                    <asp:BoundField DataField="EmpAddress" HeaderText="EmpAddress" SortExpression="EmpAddress" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:EmployeeDBConnectionString %>" DeleteCommand="DELETE FROM [Employee] WHERE [EmpID] = @original_EmpID AND [EmpName] = @original_EmpName AND (([EmpGender] = @original_EmpGender) OR ([EmpGender] IS NULL AND @original_EmpGender IS NULL)) AND (([DepID] = @original_DepID) OR ([DepID] IS NULL AND @original_DepID IS NULL)) AND (([EmpAge] = @original_EmpAge) OR ([EmpAge] IS NULL AND @original_EmpAge IS NULL)) AND (([EmpAddress] = @original_EmpAddress) OR ([EmpAddress] IS NULL AND @original_EmpAddress IS NULL))" InsertCommand="INSERT INTO [Employee] ([EmpID], [EmpName], [EmpGender], [DepID], [EmpAge], [EmpAddress]) VALUES (@EmpID, @EmpName, @EmpGender, @DepID, @EmpAge, @EmpAddress)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:EmployeeDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Employee]" UpdateCommand="UPDATE [Employee] SET [EmpName] = @EmpName, [EmpGender] = @EmpGender, [DepID] = @DepID, [EmpAge] = @EmpAge, [EmpAddress] = @EmpAddress WHERE [EmpID] = @original_EmpID AND [EmpName] = @original_EmpName AND (([EmpGender] = @original_EmpGender) OR ([EmpGender] IS NULL AND @original_EmpGender IS NULL)) AND (([DepID] = @original_DepID) OR ([DepID] IS NULL AND @original_DepID IS NULL)) AND (([EmpAge] = @original_EmpAge) OR ([EmpAge] IS NULL AND @original_EmpAge IS NULL)) AND (([EmpAddress] = @original_EmpAddress) OR ([EmpAddress] IS NULL AND @original_EmpAddress IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_EmpID" Type="String" />
                    <asp:Parameter Name="original_EmpName" Type="String" />
                    <asp:Parameter Name="original_EmpGender" Type="String" />
                    <asp:Parameter Name="original_DepID" Type="Int32" />
                    <asp:Parameter Name="original_EmpAge" Type="Int32" />
                    <asp:Parameter Name="original_EmpAddress" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="EmpID" Type="String" />
                    <asp:Parameter Name="EmpName" Type="String" />
                    <asp:Parameter Name="EmpGender" Type="String" />
                    <asp:Parameter Name="DepID" Type="Int32" />
                    <asp:Parameter Name="EmpAge" Type="Int32" />
                    <asp:Parameter Name="EmpAddress" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="EmpName" Type="String" />
                    <asp:Parameter Name="EmpGender" Type="String" />
                    <asp:Parameter Name="DepID" Type="Int32" />
                    <asp:Parameter Name="EmpAge" Type="Int32" />
                    <asp:Parameter Name="EmpAddress" Type="String" />
                    <asp:Parameter Name="original_EmpID" Type="String" />
                    <asp:Parameter Name="original_EmpName" Type="String" />
                    <asp:Parameter Name="original_EmpGender" Type="String" />
                    <asp:Parameter Name="original_DepID" Type="Int32" />
                    <asp:Parameter Name="original_EmpAge" Type="Int32" />
                    <asp:Parameter Name="original_EmpAddress" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
