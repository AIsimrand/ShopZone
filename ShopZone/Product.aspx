<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ShopZone.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .product-grid {
            margin-top: 10px;
            width: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women-product">

        <div class=" w_content">
            <div class="women">
                <a href="#">
                    <h4>
                        <asp:Literal ID="litSearchType" runat="server"></asp:Literal>
                        - <span>
                            <asp:Literal ID="litSearchCount" runat="server"></asp:Literal>
                            items</span> </h4>
                </a>
                <ul class="w_nav">

                    <li><a class="active" href="/Product.aspx">Back to Home</a></li>
                    <%--<li>Sort : </li>|
			     	<li><a href="#">new </a></li> |
			     	<li><a href="#">discount</a></li> |
			     	<li><a href="#">price: Low High </a></li> --%>
                    <div class="clearfix"></div>
                </ul>
                <div class="clearfix"></div>
            </div>
        </div>
        <!-- grids_of_4 -->
        <div class="grid-product">


            <asp:Repeater ID="rptProduct" runat="server" OnItemDataBound="rptProduct_ItemDataBound" OnItemCommand="rptProduct_ItemCommand">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="  product-grid">
                        <div class="content_box">
                            <a href="Details.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Id") %>"></a>
                            <div class="left-grid-view grid-view-left">
                                <a href="Details.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Id") %>">
                                    <img id="imgProductImage" runat="server" style="height: 150px; width: 150px;" class="" alt="">
                                </a>
                            </div>
                            <h4><a href="Details.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Id") %>">
                                <asp:Literal ID="litName" runat="server"></asp:Literal></a></h4>
                            <p>
                                <asp:Literal ID="litDescription" runat="server"></asp:Literal>
                            </p>
                            <span class="actual">
                                <asp:Literal ID="litPrice" runat="server"></asp:Literal>

                            </span>
                            <span class="reducedfrom">
                                <asp:Literal ID="litReducedPrice" runat="server"></asp:Literal>


                            </span>
                            <div style="float: left;">
                                <asp:LinkButton ID="lBtnAddToCart" class="now-get get-cart" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' CommandName="ADD_TO_CART" Text="ADD TO CART"></asp:LinkButton>
                                <asp:Button ID="btnOutOfStock" runat="server" Text="Out Of Stock" class="btn-warning" Enabled="false" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>

            <%--       <div class="  product-grid">
                <div class="content_box">
                    <a href="single.html"></a>
                    <div class="left-grid-view grid-view-left">
                        <a href="single.html">
                            <img src="images/pic2.jpg" class="img-responsive watch-right" alt="">
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                        </a>
                    </div>
                    <h4><a href="#">Duis autem</a></h4>
                    <p>It is a long established fact that a reader</p>
                    Rs. 499
                </div>
            </div>
            <div class="  product-grid">
                <div class="content_box">
                    <a href="single.html"></a>
                    <div class="left-grid-view grid-view-left">
                        <a href="single.html">
                            <img src="images/pic3.jpg" class="img-responsive watch-right" alt="">
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                        </a>
                    </div>
                    <h4><a href="#">Duis autem</a></h4>
                    <p>It is a long established fact that a reader</p>
                    Rs. 499
                </div>
            </div>
            <div class="  product-grid">
                <div class="content_box">
                    <a href="single.html"></a>
                    <div class="left-grid-view grid-view-left">
                        <a href="single.html">
                            <img src="images/pic4.jpg" class="img-responsive watch-right" alt="">
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                        </a>
                    </div>
                    <h4><a href="#">Duis autem</a></h4>
                    <p>It is a long established fact that a reader</p>
                    Rs. 499
                </div>
            </div>
            <div class="  product-grid">
                <div class="content_box">
                    <a href="single.html"></a>
                    <div class="left-grid-view grid-view-left">
                        <a href="single.html">
                            <img src="images/pic6.jpg" class="img-responsive watch-right" alt="">
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                        </a>
                    </div>
                    <h4><a href="#">Duis autem</a></h4>
                    <p>It is a long established fact that a reader</p>
                    Rs. 499
                </div>
            </div>
            <div class="  product-grid">
                <div class="content_box">
                    <a href="single.html"></a>
                    <div class="left-grid-view grid-view-left">
                        <a href="single.html">
                            <img src="images/pic7.jpg" class="img-responsive watch-right" alt="">
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                        </a>
                    </div>
                    <h4><a href="#">Duis autem</a></h4>
                    <p>It is a long established fact that a reader</p>
                    Rs. 499
                </div>
            </div>
            <div class="  product-grid">
                <div class="content_box">
                    <a href="single.html"></a>
                    <div class="left-grid-view grid-view-left">
                        <a href="single.html">
                            <img src="images/pic8.jpg" class="img-responsive watch-right" alt="">
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                        </a>
                    </div>
                    <h4><a href="#">Duis autem</a></h4>
                    <p>It is a long established fact that a reader</p>
                    Rs. 499
                </div>
            </div>
            <div class="  product-grid">
                <div class="content_box">
                    <a href="single.html"></a>
                    <div class="left-grid-view grid-view-left">
                        <a href="single.html">
                            <img src="images/pic11.jpg" class="img-responsive watch-right" alt="">
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                        </a>
                    </div>
                    <h4><a href="#">Duis autem</a></h4>
                    <p>It is a long established fact that a reader</p>
                    Rs. 499
                </div>
            </div>
            <div class=" product-grid">
                <div class="content_box">
                    <a href="single.html"></a>
                    <div class="left-grid-view grid-view-left">
                        <a href="single.html">
                            <img src="images/pic12.jpg" class="img-responsive watch-right" alt="">
                            <div class="mask">
                                <div class="info">Quick View</div>
                            </div>
                        </a>
                    </div>
                    <h4><a href="#">Duis autem</a></h4>
                    <p>It is a long established fact that a reader</p>
                    Rs. 499
                </div>
            </div>--%>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>
