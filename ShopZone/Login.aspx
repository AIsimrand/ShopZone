<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="Login.aspx.cs" Inherits="ShopZone.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
 </script>

    <div class="account_grid">
        <div class=" login-right">
            <h3>REGISTERED CUSTOMERS</h3>
            <p>If you have an account with us, please log in.</p>

            <%--<div>
                <span>Email Address<label>*</label></span>
                <asp:TextBox ID="txtUsername" runat="server" type="text" placeholder="Email Address" required="" autofocus=""></asp:TextBox>
            </div>
            <div>
                <span>Password<label>*</label></span>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" type="text" placeholder="Password" required="" autofocus=""></asp:TextBox>
            </div>--%>

            <div class="form-group">
                <label for="exampleInputEmail1">Email Address</label>
                <asp:TextBox ID="txtUsername" runat="server" type="text" placeholder="Email Address" required="" autofocus=""></asp:TextBox>
                
            </div>

            <div class="form-group">
                <label for="exampleInputEmail1">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" type="text" placeholder="Password" required="" autofocus=""></asp:TextBox>
                
            </div>

            <div>
                <label>
                    <asp:CheckBox ID="chkRemmemberMe" runat="server" />
                    Remember me
                </label>
            </div>
            <a class="forgot" href="ForgotPassword.aspx">Forgot Your Password?</a>
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-lg btn-primary btn-block" Text="Sign in" OnClick="btnLogin_Click" />
            <p>
                <asp:Label ID="lblMessage" ForeColor="red" runat="server" />
            </p>
        </div>
        <div class=" login-left">
            <h3>NEW CUSTOMERS</h3>
            <p>By creating an account with our store, you will be able to move through the checkout process faster, store multiple shipping addresses, view and track your orders in your account and more.</p>
            <a class="acount-btn" href="Register.aspx">Create an Account</a>
        </div>
        <div class="clearfix"></div>
    </div>
</asp:Content>
