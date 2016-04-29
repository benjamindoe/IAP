<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <div class="control-box--wrapper">
        <div class="aspect aspect1-1 btn control-box control-box--users">
            <a href="./Users.aspx">
                <span class="vertical-align">User Control</span>
                <span class="count count--menu" id="userNumber" runat="server"></span>
            </a>
        </div>
        <div class="aspect aspect1-1 btn control-box control-box--menu">
            <a href="./Menu.aspx">
                <span class="vertical-align">Menu Control</span>
                <span class="count count--menu" id="menuItemNumber" runat="server"></span>
            </a>
        </div>
        <div class="aspect aspect1-1 btn control-box control-box--order">
            <a href="./Menu.aspx">
                <span class="vertical-align">Order Control</span>
                <span class="count count--order" id="orderNumber" runat="server"></span>
            </a>
        </div>
    </div>
    </form>
</asp:Content>

