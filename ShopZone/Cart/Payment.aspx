<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="ShopZone.Cart.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="women-product">
        <div style="vertical-align: bottom;">
            <div style="float: left; width: 80%;">
                <h2>Make Payment</h2>
            </div>
            <div style="float: right; width: 20%; margin-top: 20px; margin-bottom: 10px;">
            </div>
        </div>

        <table class="table table-hover table-striped">
            <thead>
                <tr>

                    <th>Name</th>
                    <th>Image</th>


                </tr>

            </thead>
            <tbody>
                <tr>
                    <td colspan="2">
                        <asp:RadioButtonList ID="rbtnPaymentMode" runat="server">
                            <asp:ListItem Text="Credit Card" Value="Credit Card" Selected="True"></asp:ListItem>
                             <asp:ListItem Text="Net Banking" Value="Net Banking" ></asp:ListItem>
                             <asp:ListItem Text="Cash on Delivery" Value="Cash on Delivery" ></asp:ListItem>

                        </asp:RadioButtonList>

                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Button ID="btnMakePayment" class="btn btn-success" runat="server" OnClick="btnMakePayment_Click" Text="Make Payment" />

                    </td>
                    <td>
                        <asp:Button ID="btnCancelPayment" class="btn btn-danger" runat="server" OnClick="btnCancelPayment_Click" Text="Cancel Payment" />

                    </td>
                </tr>
            </tbody>
        </table>



    </div>

</asp:Content>
