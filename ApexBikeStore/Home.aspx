<%@ Page Title="" Language="C#" MasterPageFile="~/Apex.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ApexBikeStore.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4><asp:Label runat="server" ID="lblWelcome"></asp:Label></h4>
    <p>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
    <div>
        <a href="Cart.aspx">View your cart!</a><br/>
        <a href="Account.aspx">Edit your account!</a>
    </div>
</asp:Content>
