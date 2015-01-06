<%@ Page Title="" Language="C#" MasterPageFile="~/Apex.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ApexBikeStore.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4><asp:Label runat="server" ID="lblWelcome"></asp:Label></h4>
    <p>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
    <div class="container">
        <asp:TextBox runat="server" ID="txtPrice"></asp:TextBox>
        <asp:Button runat="server" ID="btnShowOrder" Text="Show Order" CssClass="btn btn-info" OnClick="btnShowOrder_Click"/>
        <asp:Label runat="server" ID="lblOrder"></asp:Label><p/>
        <a href="Account.aspx"><span class="btn btn-primary">Edit your account!</span></a>
    </div>
</asp:Content>
