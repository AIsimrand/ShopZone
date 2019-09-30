<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ShopZone.Admin.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Users</h2>
    <p>List of Users</p>

    <table class="table table-hover table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>Email</th>
                <th>Role</th>
                <th>Firstname</th>
                <th>Lastname</th>
               
            </tr>

        </thead>
        <tbody>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "LoginInfo.EmailId") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "LoginInfo.UserRole.Name") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "FirstName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "LastName") %></td>
                        
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </tbody>

    </table>
</asp:Content>
