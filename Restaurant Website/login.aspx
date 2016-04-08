<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <label>Username:</label>
        <asp:TextBox runat="server" ID="txtUsername" placeholder="Username"/>

        <label>Password:</label>
        <asp:TextBox runat="server" ID="txtPassword" placeholder="Password"/>

        <asp:Button ID="submit" Text="Login" runat="server" OnClick="submit_Click" />
    </form>
    <a href="register.aspx">Register</a>
</asp:Content>

