<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ShopZone.Admin.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Products</h2>
    <p>List of Products</p>

    <table class="table table-hover table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Category</th>
                <th>Price</th>
                <th>Image</th>
                <th>Has Offer</th>
                 <th>Is Featured</th>
                <th>Is Active</th>
                <th></th>
            </tr>

        </thead>
        <tbody>
            <p><asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-xs btn-success" OnClick="btnAdd_Click" /></p>
            
            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>
                    <tr>
                        
                        <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Category.Name") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Price") %></td>
                        <td>
                            <img src="<%# DataBinder.Eval(Container.DataItem, "ImageUrl") %>" style="height: 70px; width: 60px;" alt="ProductImage" /></td>
                        <td><%# ((bool)DataBinder.Eval(Container.DataItem, "HasOffer"))?"Yes" : "No" %></td>
                            <td><%# ((bool)DataBinder.Eval(Container.DataItem, "IsFeaturedProduct"))?"Yes" : "No" %></td>
                        <td><%# ((bool)DataBinder.Eval(Container.DataItem, "IsActive"))?"Yes" : "No" %></td>
                        <td>
                            <asp:LinkButton ID="imgBtnEdit" Text="Edit" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>'  OnClick="imgBtnEdit_Click"   />
                            <asp:LinkButton ID="imgButtonDelete" Text="Delete" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' OnClick="imgButtonDelete_Click" />

                          
                        </td>

                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </tbody>

    </table>
</asp:Content>
