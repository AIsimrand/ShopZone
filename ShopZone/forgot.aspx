<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="forgot.aspx.cs" Inherits="ShopZone.forgot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="reservation_top">
            <div class=" contact_right">
                <h3>ChangePassword Form</h3>
                <div class="contact-form">
    <div class="main-cont">
<table border="0" cellspacing="10%" cellpadding="10%" width="60%" align="center">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Email Id" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtemailid" runat="server" Width="200px" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                       &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" OnClick="btnSubmit_Click1" />
                         
                        <br />
                        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <br />
                        <br />
                   <br />
                         </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Security Question" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecurityquestion" runat="server" Width="200px" Height="20px" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                        <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Security Answer" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtsecurityanswer" runat="server" Width="200px" Height="20px" Visible="False"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="center">
                       &nbsp;<asp:Button ID="Button5" runat="server" Text="Submit" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large"  Visible="False" OnClick="Button5_Click" /> 
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                   <br />
                         </td>
                </tr>
                <br />
                        <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="New Password" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtpassword" runat="server" Width="200px" Height="20px" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Retype Password" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtretypepassword" runat="server" Width="200px" Height="20px" Visible="False"></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <br />
                <tr>
                    <td></td>
                    <td align="center">
                       &nbsp;<asp:Button ID="Button3" runat="server" Text="Submit" Font-Bold="True" Font-Names="Times New Roman" Font-Size="X-Large"  class="comments" Visible="False" OnClick="Button3_Click"/> 
                   <br />
                         </td>

                </tr>
               
			</table>
</div>
   
                    </div>
                </div>
            </div>
                </div>              
    
    <div class="clear"> </div>

</asp:Content>
