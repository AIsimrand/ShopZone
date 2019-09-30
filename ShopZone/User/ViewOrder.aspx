<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="ShopZone.User.ViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Track Order
    </p>



    <asp:Repeater ID="rptProduct" runat="server">

        <ItemTemplate>


            <div>
                <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group ">
                            <strong>Produc Details - <span><%# DataBinder.Eval(Container.DataItem, "OrderProduct.Name") %></span></strong>

                        </div>
                    </div>
                </div>
                <div class="row">

                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleInputEmail1"></label>
                            <img id="imgProduct" alt="" src="<%# DataBinder.Eval(Container.DataItem, "OrderProduct.ImageUrl") %>" height="200px" width="200px" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group ">
                            <label for="exampleInputEmail1">Price</label>
                            <span><%# DataBinder.Eval(Container.DataItem, "UnitAmount") %></span>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Unit</label>
                            <span><%# DataBinder.Eval(Container.DataItem, "Unit") %></span>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group ">
                            <label for="exampleInputEmail1">Discount</label>
                            <span><%# DataBinder.Eval(Container.DataItem, "Discount") %></span>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group ">
                            <label for="exampleInputEmail1">Paid</label>
                            <span><%# DataBinder.Eval(Container.DataItem, "AmountPaid") %></span>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group ">
                            <label for="exampleInputEmail1">Payment Mode</label>
                            <span><%# DataBinder.Eval(Container.DataItem, "PaymodeMode") %></span>

                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Payment Status</label>
                            <span><%# DataBinder.Eval(Container.DataItem, "PaymentStatus") %></span>

                        </div>
                    </div>
                </div>
              <%--  <div class="row">
                    <div class="col-lg-6">

                        <div class="form-group ">
                            <label for="exampleInputEmail1">Transit Status</label>
                            <span><%# DataBinder.Eval(Container.DataItem, "TransitStatus") %></span>

                        </div>
                    </div>

                </div>--%>


            </div>


        </ItemTemplate>
        <SeparatorTemplate>
            <div>
                <hr />
            </div>
        </SeparatorTemplate>
    </asp:Repeater>




    
                <%-- <strong>Transit History</strong>
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

            <asp:Repeater ID="rptTransit" runat="server">

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
        </div>--%>
</asp:Content>
