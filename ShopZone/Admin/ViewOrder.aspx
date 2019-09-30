<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="ShopZone.Admin.ViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        View Order
    </p>


    <div>
        <div class="row">
            <div class="col-lg-6">

                <div class="form-group ">
                    <strong>Produc Details</strong>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">

                <div class="form-group ">
                    <label for="exampleInputEmail1">Product</label>
                    <asp:Literal ID="litProductName" runat="server"></asp:Literal>

                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1"></label>
                    <img id="imgProduct" runat="server" alt="" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">

                <div class="form-group ">
                    <label for="exampleInputEmail1">Price</label>
                    <asp:Literal ID="litPrice" runat="server"></asp:Literal>

                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Unit</label>
                    <asp:Literal ID="litUnit" runat="server"></asp:Literal>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">

                <div class="form-group ">
                    <label for="exampleInputEmail1">Discount</label>
                    <asp:Literal ID="litDiscount" runat="server"></asp:Literal>

                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-group ">
                    <label for="exampleInputEmail1">Paid</label>
                    <asp:Literal ID="litAmountPaid" runat="server"></asp:Literal>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">

                <div class="form-group ">
                    <label for="exampleInputEmail1">Payment Mode</label>
                    <asp:Literal ID="litPaymentMode" runat="server"></asp:Literal>

                </div>
            </div>
            <div class="col-lg-6">
                <div class="form-group">
                    <label for="exampleInputEmail1">Payment Status</label>
                    <asp:Literal ID="litPaymentStatus" runat="server"></asp:Literal>

                </div>
            </div>
        </div>
        <div class="form-inline">

            <div class="form-group ">
                <label for="exampleInputEmail2">Transit Status</label>
            </div>
            <div class="form-group">
                <asp:DropDownList ID="ddlTransitStatus" runat="server">
                    <asp:ListItem Text="Order Placed" Value="Order Placed"></asp:ListItem>
                    <asp:ListItem Text="Transit to Bangalore Facility" Value="Transit to Bangalore Facility"></asp:ListItem>
                    <asp:ListItem Text="Recieved at Bangalore Facility" Value="Recieved at Bangalore Facility"></asp:ListItem>
                    <asp:ListItem Text="Transit to Mumbai Facility" Value="Transit to Mumbai Facility"></asp:ListItem>
                    <asp:ListItem Text="Recieved at Mumbai Facility" Value="Recieved at Mumbai Facility"></asp:ListItem>
                    <asp:ListItem Text="Out for Delivery" Value="Out for Delivery"></asp:ListItem>
                    <asp:ListItem Text="Delivered" Value="Delivered"></asp:ListItem>
                    <asp:ListItem Text="Returned" Value="Returned"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpdateTransit" runat="server" class="btn btn-primary" Text="Update Transit Status" OnClick="btnUpdateTransit_Click" />
            </div>
        </div>

        <strong>Transit History</strong>
        <div>
            <table class="table table-hover table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>Transit Status</th>
                <th>Transit Date</th>
                <th></th>
            </tr>

        </thead>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "TransitStatus") %></td>
                        <td>
                             <%# DataBinder.Eval(Container.DataItem, "CreatedOn") %>

                        </td>
                        <td>
                             

                        </td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </tbody>

    </table>
        </div>
    </div>
</asp:Content>
