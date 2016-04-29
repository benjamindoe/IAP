<%@ Page Title="" Language="C#" MasterPageFile="~/SubMaster.master" AutoEventWireup="true" CodeFile="Basket.aspx.cs" Inherits="Basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <asp:ListBox ID="lstCart" runat="server" Height="213px" Width="358px"></asp:ListBox>
        <div id="cartbuttons">
            <asp:Button ID="btnRemove" runat="server" Text="Remove Item" CssClass="button" OnClick="btnRemove_Click"/><br />
            <asp:Button ID="btnEmpty" runat="server" Text="Empty Cart" CssClass="button" OnClick="btnEmpty_Click"/>
        </div>
        <div id="shopbuttons">
            <asp:Button ID="btnContinue" runat="server" Text="Continue Shopping" CssClass="button" PostBackUrl="~/Order.aspx" />
            <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" CssClass="button" onclick="btnCheckOut_Click"/>
        </div>
        <asp:Label ID="lblMessage" runat="server" CssClass="button"  EnableViewState="false"></asp:Label>
    </form>
</asp:Content>

