<%@ Page Title="" Language="C#" MasterPageFile="~/Apex.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="ApexBikeStore.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 50%">
        <!--change password-->
        <asp:Label CssClass="form-label" runat="server">Change your password: </asp:Label>
        <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" CssClass="form-input"></asp:TextBox>
        <br/>
        <asp:Label CssClass="form-label" runat="server">New password: </asp:Label>
        <asp:TextBox runat="server" TextMode="Password" ID="txtNewPassword" CssClass="form-input"></asp:TextBox>
        <p>
        <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click"/><br/>
        <asp:Label runat="server" ID="lblMsg"></asp:Label>
        </p>
    </div>
</asp:Content>
