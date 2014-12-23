<%@ Page Title="" Language="C#" MasterPageFile="~/Apex.Master" AutoEventWireup="true" CodeBehind="SignOut.aspx.cs" Inherits="ApexBikeStore.SignOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/site.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="signout">
            <h4>Sign Out</h4>
            <hr/>
            <asp:Label runat="server" ID="lblMsg">
            </asp:Label>
            <div id="btnSpan">
            <asp:Button runat="server" ID="btnSignOut" CssClass="btn btn-danger" Text="Sign Out" OnClick="btnSignOut_Click"/>&nbsp;&nbsp;
                <!--return to previous page-->
            <button class="btn btn-info" onclick="window.history.go(-1);return false;">Return</button>
            </div>
        </div>
    </div>
</asp:Content>
