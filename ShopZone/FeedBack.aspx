<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FeedBack.aspx.cs" Inherits="ShopZone.FeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women-product" style="width: 70%; float: right;">
        <div style="vertical-align: bottom;">
            <div style="float: left; width: 80%;">
                <h2>Feedback</h2>
                <b>Post a Feedback, Comment, or Question about this article</b>
            </div>

            <div class="clearfix"></div>
        </div>

        <div class="form-vertical">
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                       <label for="exampleInputEmail1">Name</label>
                        <asp:TextBox ID="txtName" runat="server" placeholder="Name"/>
                    </div>
                </div>


            </div>


            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <label for="exampleInputEmail1">Subject</label>
                        <asp:TextBox ID="txtSubject" runat="server" placeholder="Subject" />
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                          <label for="exampleInputEmail1">Comment</label>
                        <asp:TextBox ID="txtComment" runat="server" placeholder="Comment" Rows="5" Columns="20"
                            TextMode="MultiLine" Width="391px" />
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
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-lg" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>



        </div>



        <div>
            <asp:Repeater ID="RepDetails" runat="server">
                <HeaderTemplate>
                    <table style="border: 1px solid #df5015; width: 500px" cellpadding="0">
                        <tr style="background-color: #df5015; color: White">
                            <td colspan="2">
                                <b>Post a Feedback, Comment, or Question about this article</b>
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: #EBEFF0">
                        <td>
                            <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; width: 500px">
                                <tr>
                                    <td>Subject:
                                        <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>' Font-Bold="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblComment" runat="server" Text='<%#Eval("Message") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; border-bottom: 1px solid #df5015; width: 500px">
                                <tr>
                                    <td>Post By:
                                        <asp:Label ID="lblUser" runat="server" Font-Bold="true" Text='<%#Eval("Name") %>' /></td>
                                    <td>Created Date:<asp:Label ID="lblDate" runat="server" Font-Bold="true" Text='<%#Eval("CreatedOn") %>' /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
