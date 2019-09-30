<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="ShopZone.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="account_grid">
        <div class=" login-right">
            <h3>FORGOT PASSWORD</h3>



            <div class="form-vertical" runat="server" id="divGetSecurityQuestion" visible="true">
                <p>If you have an account with us, please enter your username/email id.</p>

                <div class="row">
                    <div class="form-group">
                        <asp:Literal ID="litMessage1" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtUsername" placeholder="Email Id"></asp:TextBox>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnRetrievePassword" class="btn btn-primary" Text="Get Security Question" OnClick="btnRetrievePassword_Click" />

                        </div>
                    </div>


                </div>

            </div>




            <div class="form-vertical" runat="server" id="divSecurityQuestion" visible="false">
                <div class="row">
                    <div class="form-group">
                        <p>If you have an account with us, please answer below security question's answer in.</p>

                    </div>
                    <div class="form-group">
                        <asp:Literal ID="litMessage2" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                        <asp:HiddenField runat="server" ID="hdnUsername"></asp:HiddenField>
                    </div>


                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">Security Question</label>
                    <asp:TextBox runat="server" class="form-control" ID="txtSecurityQuestion" TextMode="SingleLine" placeholder="Security Question"></asp:TextBox>
                </div>





                <div class="form-group">
                    <label for="exampleInputPassword1">Securiy Answer</label>
                    <asp:TextBox runat="server" class="form-control" ID="txtSecurityAnswer" TextMode="SingleLine" placeholder="Security Answer"></asp:TextBox>
                </div>


                <div class="form-group">
                    <asp:Button runat="server" ID="btnSubmit" class="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" />

                </div>


            </div>
        </div>

        <div class="clearfix"></div>
    </div>




</asp:Content>
