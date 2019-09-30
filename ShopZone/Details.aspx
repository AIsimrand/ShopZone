<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="ShopZone.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/Content/js/jquery.etalage.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women-product" style="    width: 70%;
    float: right;">
        <div style="vertical-align: bottom;">
            <div style="float: left; width: 80%;">
                <h2>Product Details</h2>
            </div>
            <div style="float: right; width: 20%; margin-top: 20px; margin-bottom: 10px;">
                <%--<h4><a class="divContinueShopping" href="javascript:history.back();">Continue Shopping</a></h4> --%>
                <a href="javascript:history.back();" class="btn btn-default" role="button">Continue Shopping</a>
            </div>
               <div class="clearfix"></div>
        </div>
        <div class=" single_top1    ">
            <div class="single_grid" >
                <div class="grid images_3_of_2">
                    <ul id="etalage" class="etalage">



                        <li class="etalage_thumb thumb_4" style="background-image: none;">
                            <img id="imgProductImage" runat="server" class="etalage_thumb_image" style="display: inline; width: 250px; height: 300px;">
                        </li>

                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="desc1 span_3_of_2">


                    <h4>
                        <asp:Literal ID="litName" runat="server"></asp:Literal></a></h4>
                    <div class="cart-b">
                        <div class="left-n ">
                            <asp:Literal ID="litPrice" runat="server"></asp:Literal>
                        </div>

                        <asp:LinkButton ID="lBtnAddToCart" class="now-get get-cart" runat="server" Text="ADD TO CART" OnClick="lBtnAddToCart_Click"></asp:LinkButton>
                           <asp:Button ID="btnOutOfStock" runat="server" Text="Out Of Stock" class="btn-warning" Enabled="false"   />
                        <div class="clearfix"></div>
                    </div>

                    <p>
                        <asp:Literal ID="litDescription" runat="server"></asp:Literal>
                    </p>



                </div>
                <div class="clearfix"></div>
            </div>


            <%--  <div class="toogle">
            <h3 class="m_3">Product Details</h3>
            <p class="m_text">Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.</p>
        </div>--%>
        </div>
    </div>
</asp:Content>
