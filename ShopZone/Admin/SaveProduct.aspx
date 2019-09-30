<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SaveProduct.aspx.cs" Inherits="ShopZone.Admin.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h1>Product Registration </h1>
    </div>
    <div class="form-vertical">
        <div class="row">

            <div class="col-lg-6">
                <div class="form-group">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                </div>
            </div>


        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Name</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtName" placeholder="Name"></asp:TextBox>
                </div>
            </div>


        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Description</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtDescription" placeholder="Description" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Category</label>

                    <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" placeholder="Category">
                        <asp:ListItem Text="Select..."></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Sub Category</label>

                    <asp:DropDownList runat="server" ID="ddlSubCategory" AutoPostBack="false" placeholder="Sub Category"></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Price</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtPrice" placeholder="Price"></asp:TextBox>

                </div>
            </div>
        </div>
         <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">No. of Stock</label>
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtNoOfStock" placeholder="No. Of Stock"></asp:TextBox>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Product Image</label>
                    <asp:FileUpload ID="fuProductImage" runat="server" />
                </div>

            </div>
        </div>
         <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Featured Product</label>
                    <asp:CheckBox ID="chkIsFeaturedProduct" runat="server" Checked="false" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Has Offer</label>
                    <asp:CheckBox ID="chkHasOffer" runat="server" Checked="false" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Is Active</label>
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked="false" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-6">
                <asp:Button runat="server" ID="btnSave" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                <asp:Button runat="server" ID="btnCancel" class="btn btn-primary" Text="Cancel" PostBackUrl="~/Admin/Products.aspx" />
            </div>
        </div>

    </div>


</asp:Content>
