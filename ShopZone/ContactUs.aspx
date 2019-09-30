<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ShopZone.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women-product" style="width: 70%; float: right;">
        <div style="vertical-align: bottom;">
            <div style="float: left; width: 80%;">
                <h2>Contact Us</h2>
            </div>

            <div class="clearfix"></div>
        </div>


        <div class="form-vertical">
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">

                        <asp:TextBox ID="txtname" runat="server" placeholder="First Name" class="form-control header"></asp:TextBox>
                    </div>
                </div>


            </div>


            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:TextBox ID="txtemail" runat="server" placeholder="Email Address" class="form-control header"></asp:TextBox>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:TextBox ID="txtsubject" runat="server" placeholder="Subject" class="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:TextBox ID="txtcomment" runat="server" placeholder="Enter your massage for us here. We will get back to you within 2 business days." TextMode="MultiLine" class="form-control"></asp:TextBox>

                    </div>
                </div>
            </div>




            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">

                        <asp:Label ID="lblmsg" runat="server" Text="Label" class="form-control" Enabled="false" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" class="btn btn-primary btn-lg" />

                    </div>
                </div>
            </div>


        </div>




        <address class="address">
            <p>
                9870 St Vincent Place,
                            <br>
                Glasgow, DC 45 Fr 45.
            </p>
            <dl>
                <dt></dt>
                <dd>Freephone:<span> +1 800 254 2478</span></dd>
                <dd>Telephone:<span> +1 800 547 5478</span></dd>
                <dd>FAX: <span>+1 800 658 5784</span></dd>
                <dd>E-mail:&nbsp; <a href="mailto@vintage.com">info(at)bigshop.com</a></dd>
            </dl>
        </address>
    </div>

</asp:Content>
