    <%@ Page Title="" Language="C#" MasterPageFile="~/Apex.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApexBikeStore.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/site.css" rel="stylesheet" />
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="login">
            <h4>Login</h4>
            <hr/>
            <!--E-mail input/Validation-->
            <asp:Label runat="server">E-mail:</asp:Label><br/>
            <asp:TextBox runat="server" ID="txtEmail" Placeholder="someone@example.com" TextMode="Email" CssClass="form-input"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ControlToValidate="txtEmail" 
                    runat="server" ID="RequiredFieldValidator1" 
                    Display="Dynamic" ErrorMessage="This is a required field!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>--%>
            <p/>
            <!--Password input/Validation-->
            <asp:Label runat="server">Password:</asp:Label><br/>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-input"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ControlToValidate="txtPassword" 
                    runat="server" ID="RequiredFieldValidator2" 
                    Display="Dynamic" ErrorMessage="This is a required field!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>--%>
            <p>
                <asp:Button runat="server" CssClass="btn btn-info" Text="Login" ID="btnLogin" OnClick="btnLogin_Click"/>
                <asp:CheckBox runat="server" ID="cbxRemember"/> Remember Me<br/>
            </p>
            <p>
                <asp:Label runat="server" ID="lblMsgLog" ForeColor="red"></asp:Label>
            </p>
        </div>

        <div id="register">
            <h4>Register</h4>
            <hr/>
            <!--First Name-->
            <asp:Label runat="server">First Name:</asp:Label><br/>
            <asp:TextBox runat="server" ID="txtFname" Placeholder="John" CssClass="form-input" type="text"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ControlToValidate="txtFname" 
                    runat="server" ID="RequiredFieldValidator3" 
                    Display="Dynamic" ErrorMessage="This is a required field!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>--%>
            <br/>
            <!--Last Name-->
            <asp:Label runat="server">Last Name:</asp:Label><br/>
            <asp:TextBox runat="server" ID="txtLname" Placeholder="Smith" CssClass="form-input" type="text"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ControlToValidate="txtLname" 
                    runat="server" ID="RequiredFieldValidator4" 
                    Display="Dynamic" ErrorMessage="This is a required field!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>--%>
            <br/>
            <!--Email-->
            <asp:Label runat="server">E-mail:</asp:Label><br/>
            <asp:TextBox runat="server" ID="txtEmailReg" Placeholder="johnsmith@gmail.com" CssClass="form-input" type="email"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ControlToValidate="txtEmailReg" 
                    runat="server" ID="RequiredFieldValidator5" 
                    Display="Dynamic" ErrorMessage="This is a required field!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>--%>
            <br/>
            <!--Password-->
            <asp:Label runat="server">Password:</asp:Label><br/>
            <asp:TextBox runat="server" ID="txtPasswordReg" CssClass="form-input" type="password"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ControlToValidate="txtPasswordReg" 
                    runat="server" ID="RequiredFieldValidator6" 
                    Display="Dynamic" ErrorMessage="This is a required field!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>--%>
            <br/>
            <!--Password Confirm-->
            <asp:Label runat="server">Confirm Password:</asp:Label><br/>
            <asp:TextBox runat="server" ID="txtPasswordConfirm" CssClass="form-input" type="password"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ControlToValidate="txtPasswordReg" 
                    runat="server" ID="RequiredFieldValidator7" 
                    Display="Dynamic" ErrorMessage="This is a required field!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>--%>
            <br/>
            <!--DOB-->
            <asp:Label runat="server">Date of Birth:</asp:Label><br/>
            <asp:TextBox runat="server" ID="txtDob" Placeholder="07/10/1993" CssClass="date form-input"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ControlToValidate="txtDob" 
                    runat="server" ID="RequiredFieldValidator8" 
                    Display="Dynamic" ErrorMessage="This is a required field!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>--%>
            <br/>
            <!--Gender-->
            <asp:Label runat="server">Gender:</asp:Label>
            <asp:RadioButtonList runat="server" ID="rbnGender">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
            </asp:RadioButtonList>
            <%--<asp:RequiredFieldValidator ControlToValidate="rbnGender" 
                    runat="server" ID="RequiredFieldValidator9" 
                    Display="Dynamic" ErrorMessage="This is a required field!" 
                    ForeColor="Red">
                </asp:RequiredFieldValidator>--%>
            <p>
                <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-success" Text="Register" OnClick="btnRegister_Click"/>
                <asp:CheckBox runat="server" ID="cbxRememberMe"/> Remember Me<br/>
            </p>
            <p>
                <asp:Label runat="server" ID="lblMsgReg" ForeColor="red"></asp:Label>
            </p>
        </div>
    </div>
    <!--scripts-->
    <script>
            $(function () {
                $(".date").datepicker({
                    dateFormat: "dd/MM/yy"
                }).val();
            });
    </script>
</asp:Content>
