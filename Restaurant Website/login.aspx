<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<%@ MasterType TypeName="SubMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="panel">
        <form id="form1" runat="server">
            <div class="form-group">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-user fa-fw" aria-hidden="true"></i></span>
                    <label class="sr-only">Username:</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtUsername" placeholder="Username"/>
                </div>
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-key fa-fw" aria-hidden="true"></i></span>
                    <label class="sr-only">Password:</label>
                    <asp:TextBox CssClass="form-control" runat="server" TextMode="password" ID="txtPassword" placeholder="Password"/>
                </div>
                <asp:Button CssClass="btn btn-submit" ID="submit" Text="Login" runat="server" OnClick="submit_Click" />
            </div>
        </form>
        <a class="btn btn-register" href="register.aspx">Register</a>

    </div>
</asp:Content>

