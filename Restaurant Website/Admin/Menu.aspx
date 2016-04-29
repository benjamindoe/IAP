<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Admin_Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataKeyNames="Id" 
            DataSourceID="MenuData" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="#F08080" />
            <Columns>
                <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="Id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="NewTitle" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="NewDescription" runat="server" Height="70px" TextMode="MultiLine" Width="217px"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vegitarian" SortExpression="isVeg">
                    <FooterTemplate>
                        <asp:CheckBox ID="NewVeg" runat="server" />
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("isVeg") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("isVeg") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Heat" SortExpression="heatLvl">
                    <FooterTemplate>
                        <asp:RadioButtonList ID="NewHeatLvl" runat="server">
                            <asp:ListItem Value="0">0 (Mild)</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4 (Hot as F****)</asp:ListItem>
                        </asp:RadioButtonList>
                    </FooterTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" SelectedValue='<%# Bind("heatLvl") %>'>
                            <asp:ListItem  Value="0">0 (Mild)</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4 (Hot as F****)</asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("heatLvl") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="EditButton" runat="server" CssClass="btn btn-edit" CommandName="Edit" >
                            <i class="fa fa-pencil"></i>
                            <span class="sr-only">Edit</span>
                        </asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="DeleteButton" CssClass="btn btn-delete" OnClientClick="return confirm('Are you sure you want to delete this Item?');"  CommandName="Delete" runat="server" >
                            <i class="fa fa-trash-o"></i>
                            <span class="sr-only">Delete</span>
                        </asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="UpdateButton" runat="server" CssClass="btn btn-update" CommandName="Update" Text="Update" />&nbsp;
                        <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-cancel" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="AddButton" CssClass="btn btn-add" runat="server" CommandName="Insert">
                            <i class="fa fa-plus"></i>
                            <span class="sr-only">Add</span>
                        </asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CD3700" Font-Bold="False" ForeColor="#333333" />
            <HeaderStyle BackColor="#CD3700" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
            <asp:SqlDataSource ID="MenuData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [Menu]"
            DeleteCommand="DELETE FROM [Menu] WHERE [Id] = @original_Id AND [Title] = @original_Title AND [Description] = @original_Description"
            UpdateCommand="UPDATE Menu SET Title = @Title, Description = @Description, isVeg = @isVeg, heatLvl = @heatLvl WHERE (Id = @original_Id) AND (Title = @original_Title) AND (Description = @original_Description) AND (isVeg = @original_isVeg) AND (heatLvl = @original_heatLvl)" ConflictDetection="CompareAllValues" 
            InsertCommand="INSERT INTO [Menu] ([Title], [Description], [isVeg], [heatLvl]) VALUES (@Title, @Description, @isVeg, @heatLvl)" OldValuesParameterFormatString="original_{0}">
            <DeleteParameters>
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_Title" Type="String" />
                <asp:Parameter Name="original_Description" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="isVeg" Type="Boolean" />
                <asp:Parameter Name="heatLvl" Type="Int16" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="isVeg" />
                <asp:Parameter Name="heatLvl" />
                <asp:Parameter Name="original_Id" Type="Int32" />
                <asp:Parameter Name="original_Title" Type="String" />
                <asp:Parameter Name="original_Description" Type="String" />
                <asp:Parameter Name="original_isVeg" />
                <asp:Parameter Name="original_heatLvl" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
            </asp:Content>

