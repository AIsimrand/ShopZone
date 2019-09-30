<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="True" CodeBehind="SaveSubCategory.aspx.cs" Inherits="ShopZone.Admin.SaveSubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-header">
        <h1>Sub Category Registration: </h1>
        
    </div>
    <div class="form-vertical">
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
                    
                    <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="false" placeholder="Category"></asp:DropDownList>
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
                <asp:Button runat="server" ID="btnSave" class="btn btn-primary" Text="Save" OnClick="btnSave_Click"  />
                <asp:Button runat="server" ID="btnCancel" class="btn btn-primary" Text="Cancel" PostBackUrl="~/Admin/Categories.aspx" />
            </div>
        </div>

    </div>

</asp:Content>
