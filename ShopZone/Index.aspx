<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ShopZone.Index" %>

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
            <div>
                
        <!-- use jssor.slider.debug.js instead for debug -->
        <script>
            jQuery(document).ready(function ($) {

                var jssor_1_SlideshowTransitions = [
                  { $Duration: 1200, $Opacity: 2 }
                ];

                var jssor_1_options = {
                    $AutoPlay: true,
                    $SlideshowOptions: {
                        $Class: $JssorSlideshowRunner$,
                        $Transitions: jssor_1_SlideshowTransitions,
                        $TransitionsOrder: 1
                    },
                    $ArrowNavigatorOptions: {
                        $Class: $JssorArrowNavigator$
                    },
                    $BulletNavigatorOptions: {
                        $Class: $JssorBulletNavigator$
                    }
                };

                var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

                //responsive code begin
                //you can remove responsive code if you don't want the slider scales while window resizing
                function ScaleSlider() {
                    var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
                    if (refSize) {
                        refSize = Math.min(refSize, 600);
                        jssor_1_slider.$ScaleWidth(refSize);
                    }
                    else {
                        window.setTimeout(ScaleSlider, 30);
                    }
                }
                ScaleSlider();
                $(window).bind("load", ScaleSlider);
                $(window).bind("resize", ScaleSlider);
                $(window).bind("orientationchange", ScaleSlider);
                //responsive code end
            });
        </script>

        <style>
            /* jssor slider bullet navigator skin 05 css */
            /*
        .jssorb05 div           (normal)
        .jssorb05 div:hover     (normal mouseover)
        .jssorb05 .av           (active)
        .jssorb05 .av:hover     (active mouseover)
        .jssorb05 .dn           (mousedown)
        */
            .jssorb05 {
                position: absolute;
            }

                .jssorb05 div, .jssorb05 div:hover, .jssorb05 .av {
                    position: absolute;
                    /* size of bullet elment */
                    width: 16px;
                    height: 16px;
                    background: url('/images/img/b05.png') no-repeat;
                    overflow: hidden;
                    cursor: pointer;
                }

                .jssorb05 div {
                    background-position: -7px -7px;
                }

                    .jssorb05 div:hover, .jssorb05 .av:hover {
                        background-position: -37px -7px;
                    }

                .jssorb05 .av {
                    background-position: -67px -7px;
                }

                .jssorb05 .dn, .jssorb05 .dn:hover {
                    background-position: -97px -7px;
                }

            /* jssor slider arrow navigator skin 12 css */
            /*
        .jssora12l                  (normal)
        .jssora12r                  (normal)
        .jssora12l:hover            (normal mouseover)
        .jssora12r:hover            (normal mouseover)
        .jssora12l.jssora12ldn      (mousedown)
        .jssora12r.jssora12rdn      (mousedown)
        */
            .jssora12l, .jssora12r {
                display: block;
                position: absolute;
                /* size of arrow element */
                width: 30px;
                height: 46px;
                cursor: pointer;
                background: url('/images/img/a12.png') no-repeat;
                overflow: hidden;
            }

            .jssora12l {
                background-position: -16px -37px;
            }

            .jssora12r {
                background-position: -75px -37px;
            }

            .jssora12l:hover {
                background-position: -136px -37px;
            }

            .jssora12r:hover {
                background-position: -195px -37px;
            }

            .jssora12l.jssora12ldn {
                background-position: -256px -37px;
            }

            .jssora12r.jssora12rdn {
                background-position: -315px -37px;
            }
        </style>
                

        <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 600px; height: 300px; overflow: hidden; visibility: hidden;">
            <!-- Loading Screen -->
            <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
                <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
                <div style="position: absolute; display: block; background: url('/images/img/loading.gif') no-repeat center center; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
            </div>
            <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 600px; height: 300px; overflow: hidden;">

                <asp:Repeater ID="rptProduct2" runat="server">
                    <ItemTemplate>
                        <div data-p="112.50" style="display: none;">
                           <a href="Details.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id") %>"> <img data-u="image" src="<%# DataBinder.Eval(Container.DataItem, "ImageUrl") %>" />
                        </a></div>
                    </ItemTemplate>

                </asp:Repeater>
                <div style="min-height: 50px;">
    <!-- Jssor Slider Begin -->
    <div id="slider1_container" style="visibility: hidden; position: relative; margin: 0 auto; width: 980px; height: 380px; overflow: hidden;">
        ...
    </div>
    <!-- Jssor Slider End -->
</div>


               
            </div>
            <!-- Bullet Navigator -->
            <div data-u="navigator" class="jssorb05" style="bottom: 16px; right: 16px;" data-autocenter="1">
                <!-- bullet navigator item prototype -->
                <div data-u="prototype" style="width: 16px; height: 16px;"></div>
            </div>
            <!-- Arrow Navigator -->
            <span data-u="arrowleft" class="jssora12l" style="top: 0px; left: 0px; width: 30px; height: 46px;" data-autocenter="2"></span>
            <span data-u="arrowright" class="jssora12r" style="top: 0px; right: 0px; width: 30px; height: 46px;" data-autocenter="2"></span>
            <a href="http://www.jssor.com" style="display: none">Slideshow Maker</a>
        </div>

        <!-- #endregion Jssor Slider End -->

    </div>
             <div class="clearfix"></div>
        </div>
        <!-- grids_of_4 -->
        <div class="grid-product">


            <asp:Repeater ID="rptProduct" runat="server" OnItemDataBound="rptProduct_ItemDataBound" OnItemCommand="rptProduct_ItemCommand" >
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
                               
                                <asp:Button ID="btnOutOfStock" runat="server" Text="Out Of Stock" class="btn-warning" Enabled="false"   />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>

        
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>
