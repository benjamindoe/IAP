<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<%@ MasterType TypeName="SubMaster" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="formContent" ContentPlaceHolderID="body" Runat="Server">
    <div class="panel">

        <form ID="form1" runat="server">
            <div class="input-group input_username">
                <span class="input-group-addon"><i class="fa fa-user fa-fw" aria-hidden="true"></i></span>
                <label class="sr-only">Username:</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtUsername" placeholder="Username"/>
                <asp:RequiredFieldValidator ID="usernameReq" runat="server" 
                    ErrorMessage="&laquo; (Required)" 
                    ControlToValidate="txtUsername"
                    CssClass="ValidationError"
                    ToolTip="Compare Password is a REQUIRED field"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>

            <div class="input-group input_password">
                <span class="input-group-addon"><i class="fa fa-key fa-fw" aria-hidden="true"></i></span>
                <label class="sr-only">Password:</label>
                <asp:TextBox CssClass="form-control" runat="server" TextMode="password" ID="txtPassword" placeholder="Password"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="&laquo; (Required)" 
                    ControlToValidate="txtPassword"
                    CssClass="ValidationError"
                    ToolTip="Compare Password is a REQUIRED field"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>
            <div class="input-group input_confimPassword">
                <span class="input-group-addon"><i class="fa fa-key fa-fw" aria-hidden="true"></i></span>
                <label class="sr-only">Confirm Password:</label>
                <asp:TextBox CssClass="form-control" runat="server" TextMode="password" ID="txtConfirmPassword" placeholder="Confirm Password"/>
                <asp:RequiredFieldValidator ID="ConfimPassReq" runat="server" 
                    ErrorMessage="&laquo; (Required)" 
                    ControlToValidate="txtConfirmPassword"
                    CssClass="ValidationError"
                    ToolTip="Compare Password is a REQUIRED field"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>
            </div>

            <asp:CompareValidator ID="ComparePass" runat="server" 
                ControlToValidate="txtConfirmPassword"
                CssClass="ValidationError ComparePasswords"
                ControlToCompare="txtPassword"
                ErrorMessage="No Match" 
                ToolTip="Password must be the same" 
                Display="Dynamic"
            />

            <asp:Button CssClass="btn btn-sumbit" ID="registerBtn" Text="Register" runat="server" OnClick="registerBtn_Click" />
        </form>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
</asp:Content>

