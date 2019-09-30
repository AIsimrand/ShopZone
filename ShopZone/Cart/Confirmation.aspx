<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="ShopZone.Cart.Confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women-product">
        <div style="vertical-align: bottom;">
            <div style="float: left; width: 80%;">
                <h2>Confirm Order</h2>
            </div>
            <div style="float: right; width: 20%; margin-top: 20px; margin-bottom: 10px;">
            </div>
        </div>

        <table class="table table-hover table-striped">
            <thead>
                <tr>

                    <th>Name</th>
                    <th>Image</th>
                    <th>Price</th>
                    <th>Unit</th>
                    <th>Discount</th>
                    <th>Total</th>

                </tr>

            </thead>
            <tbody>

                <asp:Repeater ID="rptProduct" runat="server" OnItemDataBound="rptProduct_ItemDataBound" OnItemCommand="rptProduct_ItemCommand">

                    <ItemTemplate>
                        <tr>

                            <td><%# DataBinder.Eval(Container.DataItem, "ProductInfo.Name") %></td>
                            <td>
                                <img src="<%# DataBinder.Eval(Container.DataItem, "ProductInfo.ImageUrl") %>" style="height: 30px; width: 30px;" alt="ProductImage" /></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "ProductInfo.Price") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Unit") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem,  string.Format("{0}", "Discount") ) %>%</td>
                            <td>Rs. <%# DataBinder.Eval(Container.DataItem,  "TotalAmount") %></td>


                        </tr>
                    </ItemTemplate>

                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">
                        <asp:TextBox ID="txtCouponCode" runat="server" placeholder="Enter Coupon Code"></asp:TextBox>
                          <asp:Button ID="btnApplyCoupon" class="btn btn-primary btn-xs" runat="server" Text="Apply" OnClick="btnApplyCoupon_Click" />

                        <br />
                        <asp:Literal ID="litCouponMessage" runat="server"></asp:Literal>
                       
                      
                    </td>


                    <td colspan="1">
                        <h4>Total</h4>
                    </td>

                    <td>
                        <asp:Literal ID="litTotalAmount" runat="server" Text=""></asp:Literal>
                    </td>

                </tr>
            </tfoot>
        </table>
        <table>
            <tr>
                <td><b>Shipping Details</b></td>

                <td>
                    <asp:Literal ID="litAddress1" runat="server" Text=""></asp:Literal><br />
                    <asp:Literal ID="litAddress2" runat="server" Text=""></asp:Literal><br />
                    <asp:Literal ID="litAddress3" runat="server" Text=""></asp:Literal><br />
                    <asp:Literal ID="litCity" runat="server" Text=""></asp:Literal>
                    <asp:Literal ID="litPincode" runat="server" Text=""></asp:Literal>

                </td>
            </tr>
        </table>

        <p>
            <div style="float: right;">
                <asp:Button ID="btnMakePayment" class="btn btn-success" runat="server" OnClick="btnMakePayment_Click" Text="Make Payment" />
            </div>
        </p>
    </div>
</asp:Content>
