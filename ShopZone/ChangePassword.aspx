<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ShopZone.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="page-header">
        <h1>Change Password </h1>
    </div>
    <div class="form-vertical">
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Username</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtUsername" placeholder="Username"></asp:TextBox>
                </div>
            </div>


        </div>
           <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Current Password</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtCurrentPassword" placeholder="Current Password"></asp:TextBox>
                </div>
            </div>


        </div>
     
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputPassword1">New Password</label>
                    <asp:TextBox runat="server" class="form-control" ID="txtNewPassword" TextMode="Password" placeholder="New Password"></asp:TextBox>
                </div>



            </div>
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputPassword1">Confirm Password</label>
                    <asp:TextBox runat="server" class="form-control" ID="txtConfirmPassword" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                </div>
            </div>

        </div>

     
      
     
        <div class="row">
            <div class="col-lg-6">
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <asp:Button runat="server" ID="btnChange" class="btn btn-primary" Text="Change" OnClick="btnChange_Click" />

            </div>
        </div>

    </div>



</asp:Content>
