<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="ShopZone.Admin.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Orders</h2>
    <p>List of Orders</p>

    <table class="table table-hover table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>Customer</th>
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
                        <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                        <td><a href='UserDetails.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "CustomerId") %>' target="_self"><%# DataBinder.Eval(Container.DataItem, "Customer.FirstName") %> <%# DataBinder.Eval(Container.DataItem, "Customer.LastName") %></a></td>
                        <td><a href='SaveProduct.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "ProductId") %>' target="_self"><%# DataBinder.Eval(Container.DataItem, "OrderProduct.Name") %></a></td>

                        <td><%# DataBinder.Eval(Container.DataItem, "Unit") %></td>
                        <td><%# string.Format("Rs. {0:0.00}", DataBinder.Eval(Container.DataItem, "UnitAmount") ) %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "PaymodeMode") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "PaymentStatus") %></td>
                        
                        <td><%# DataBinder.Eval(Container.DataItem, "TransitStatus") %></td>
                        <td><%# ((bool)DataBinder.Eval(Container.DataItem, "IsActive"))?"Yes" : "No" %></td>
                        <td>
                               <asp:LinkButton ID="imgBtnView" Text="View" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' OnClick="imgBtnView_Click" ></asp:LinkButton>
                         

                        </td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </tbody>

    </table>
</asp:Content>
