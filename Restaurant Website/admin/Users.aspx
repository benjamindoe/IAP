<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Admin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form runat="server">

        <asp:SqlDataSource ID="UsersData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [Users]"
            DeleteCommand="DELETE FROM [Users] WHERE [username]=@username"
            UpdateCommand="UPDATE [Users] SET [isAdmin]=@isAdmin WHERE [username]=@username">
        <DeleteParameters>
            <asp:ControlParameter ControlID="GridView1" Name="username" PropertyName="SelectedDataKey" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="GridView1" Name="isAdmin" PropertyName="SelectedDataKey" />
        </UpdateParameters>
        </asp:SqlDataSource>
        <asp:GridView CssClass="admin-grid" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="UsersData" 
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="#F08080" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                <asp:CheckBoxField DataField="isAdmin" HeaderText="isAdmin" SortExpression="isAdmin" ReadOnly="false" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="EditButton" runat="server" CssClass="EditButton" CommandName="Edit" Text='<i class="fa fa-pencil"></i><span class="sr-only">Edit</span>' />&nbsp;
                        <asp:LinkButton ID="DeleteButton" CssClass="DeleteButton" OnClientClick="return confirm('Are you sure you want to delete this Item?');" Text='<i class="fa fa-trash-o"></i><span class="sr-only">Delete</span>' CommandName="Delete" runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="UpdateButton" runat="server" CssClass="UpdateButton" CommandName="Update" Text="Update" />&nbsp;
                        <asp:LinkButton ID="Cancel" runat="server" CssClass="CancelButton" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CD3700" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#CD3700" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>

    </form>
</asp:Content>


