<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShippingDetails.aspx.cs" Inherits="ShopZone.Cart.ShippingDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="register">

        <div class="  register-top-grid">
            <h3>Shipping Details</h3>
            <div class="mation">
               

                             
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleTextarea">Address 1</label>
                            <asp:TextBox runat="server" type="text" class="form-control" Rows="3" ID="txtAddress1" placeholder="Address 1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleTextarea">Address 2</label>
                            <asp:TextBox runat="server" type="text" class="form-control" Rows="3" ID="txtAddress2" placeholder="Address 2"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group">
                            <label for="exampleInputEmail1">City</label>
                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtCity" placeholder="City"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">

                        <div class="form-group">
                            <label for="exampleInputEmail1">Pincode</label>
                            <asp:TextBox runat="server" type="text" class="form-control" ID="txtPincode" placeholder="Pincode"></asp:TextBox>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                  ControlToValidate="txtPincode"
                  ValidationExpression="[0-9]{6}"
                  ErrorMessage="That is not a valid Pincode" />
                        </div>

                    </div>
                </div>
            </div>
            <div class="clearfix"></div>

            <div class="register-top-grid">
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>
            </div>
            <div class="clearfix"></div>


          
        </div>

        <div class="clearfix"></div>
        <div class="register-but">

            <asp:Button runat="server" ID="btnSave" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" />

            <div class="clearfix"></div>

        </div>
    </div>
</asp:Content>
