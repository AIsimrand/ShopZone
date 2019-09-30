<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ShopZone.ShoppingCart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divContinueShopping").on("click", function () {
                history.back();
            });


        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> <div class="women-product">
        <div style="vertical-align:bottom;">
            <div style="float: left;width:80%;">
                <h2>My Shopping Cart</h2>
            </div>
            <div style="float: right;width:20%;margin-top: 20px;
    margin-bottom: 10px;">
             <%--<h4><a class="divContinueShopping" href="javascript:history.back();">Continue Shopping</a></h4> --%>
             <a href="javascript:history.back();" class="btn btn-default" role="button">Continue Shopping</a>
</div>
        </div>

        <table class="table table-hover table-striped">
            <thead>
                <tr>

                    <th>Name</th>
                    <th>Image</th>
                    <th>Price</th>
                    <th>Unit</th>
                    <th>Total</th>
                    <th></th>
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
                            <td>Rs. <%# DataBinder.Eval(Container.DataItem, string.Format("{0:0.00}", "TotalAmount")) %></td>
                            <td>
                                <asp:LinkButton ID="imgBtnEdit" Text="Remove" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductId") %>' OnClick="imgBtnEdit_Click" />


                            </td>

                        </tr>
                    </ItemTemplate>

                </asp:Repeater>
            </tbody>

        </table>
    <p>
        <asp:Literal ID="litMessage" runat="server"></asp:Literal>
    </p>
        <p>
            <div style="float:right;">
                <asp:Button ID="btnProceedToPayment" class="btn btn-success" runat="server" OnClick="btnProceedToPayment_Click" Text="Proceed to Payment" />
            </div>
        </p>
    </div>
   
</asp:Content>
