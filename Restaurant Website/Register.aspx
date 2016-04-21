<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="formContent" ContentPlaceHolderID="body" Runat="Server">
    <form ID="form1" runat="server">
        <span class="input_wrapper input_username">
            <label>Username:</label>
            <asp:TextBox runat="server" ID="txtUsername"/>
            <asp:RequiredFieldValidator ID="usernameReq" runat="server" 
                ErrorMessage="&laquo; (Required)" 
                ControlToValidate="txtUsername"
                CssClass="ValidationError"
                ToolTip="Compare Password is a REQUIRED field"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </span>

        <span class="input_wrapper input_password">
            <label>Password:</label>
            <asp:TextBox runat="server" TextMode="password" ID="txtPassword"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="&laquo; (Required)" 
                ControlToValidate="txtPassword"
                CssClass="ValidationError"
                ToolTip="Compare Password is a REQUIRED field"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </span>
        <span class="input_wrapper input_confimPassword">
            <label>Confirm Password:</label>
            <asp:TextBox runat="server" TextMode="password" ID="txtConfirmPassword"/>
            <asp:RequiredFieldValidator ID="ConfimPassReq" runat="server" 
                ErrorMessage="&laquo; (Required)" 
                ControlToValidate="txtConfirmPassword"
                CssClass="ValidationError"
                ToolTip="Compare Password is a REQUIRED field"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </span>

        <asp:CompareValidator ID="ComparePass" runat="server" 
            ControlToValidate="txtConfirmPassword"
            CssClass="ValidationError ComparePasswords"
            ControlToCompare="txtPassword"
            ErrorMessage="No Match" 
            ToolTip="Password must be the same" 
            Display="Dynamic"
        />

        <asp:Button ID="registerBtn" Text="Register" CssClass="button" runat="server" OnClick="registerBtn_Click" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
    </form>
</asp:Content>

