<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="panel panel--profile-page">
        <form runat="server">
            <div class="form-group">
                <asp:Label ID="Message" runat="server"></asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="FullName" runat="server" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="AddressLine1" runat="server" CssClass="form-control" placeholder="Addresss Line 1"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="AddressLine2" runat="server" CssClass="form-control" placeholder="Addresss Line 2"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="City" runat="server" CssClass="form-control" placeholder="City"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="Postcode" runat="server" CssClass="form-control" placeholder="Postcode" pattern="[A-Za-z]{1,2}[0-9Rr][0-9A-Za-z]? [0-9][ABD-HJLNP-UW-Zabd-hjlnp-uw-z]{2}"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="PhoneNumber" runat="server" CssClass="form-control" placeholder="Phone Number" pattern="^\s*\(?(020[7,8]{1}\)?[ ]?[1-9]{1}[0-9{2}[ ]?[0-9]{4})|(0[1-8]{1}[0-9]{3}\)?[ ]?[1-9]{1}[0-9]{2}[ ]?[0-9]{3})\s*$"></asp:TextBox>
                </div>
                <asp:Button ID="Submit" CssClass="btn btn-submit" Text="Submit" runat="server" OnClick="Submit_Click"/>
            </div>
           <asp:LinkButton ID="DeleteBtn" CssClass="btn btn-delete-account" runat="server" OnClientClick="return confirm('Are you sure you want to delete your Account? \nAll data including Order History will be lost.');" OnClick="DeleteBtn_Click">Delete Account</asp:LinkButton>
        </form>
    </div>
</asp:Content>

