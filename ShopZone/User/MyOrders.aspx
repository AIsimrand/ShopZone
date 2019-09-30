<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="ShopZone.User.MyOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>My Orders</h2>
    <p>List of My Orders</p>

    <table class="table table-hover table-striped">
        <thead>
            <tr>
               
                
                <th>Product</th>
                <th>Unit</th>
                <th>Unit Amount</th>

                <th>Payment Mode</th>

                <th>Payment Status</th>
                <th>Transit Status</th>
                <th>Is Active</th>
                <th></th>
            </tr>

        </thead>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>
                    <tr>
                        
                        <td><img src='<%# DataBinder.Eval(Container.DataItem, "OrderProduct.ImageUrl") %>' style="height:50px;width:50px;" alt="Product Image" /></td>

                        <td><%# DataBinder.Eval(Container.DataItem, "Unit") %></td>
                        <td><%# string.Format("Rs. {0:0.00}", DataBinder.Eval(Container.DataItem, "UnitAmount") ) %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "PaymodeMode") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "PaymentStatus") %></td>
                        
                        <td><%# DataBinder.Eval(Container.DataItem, "TransitStatus") %></td>
                        <td><%# ((bool)DataBinder.Eval(Container.DataItem, "IsActive"))?"Yes" : "No" %></td>
                        <td>
                                 <asp:LinkButton ID="imgBtnView" Text="View" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CartGUID") %>' OnClick="imgBtnView_Click" ></asp:LinkButton>
                         


                        </td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </tbody>

    </table>
</asp:Content>
