<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Subscriptions.aspx.cs" Inherits="ShopZone.Admin.Subscriptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Subscription</h2>
    <p>List of Subscriptions</p>
    <table class="table table-hover table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>Email Id</th>
                <th>Registered Date</th>
             
            </tr>

        </thead>
        <tbody>
            
            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "EmailId") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "CreatedOn") %></td>
                          
                        
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </tbody>

    </table>
</asp:Content>
