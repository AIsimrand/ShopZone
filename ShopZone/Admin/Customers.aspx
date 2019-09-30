<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="ShopZone.Admin.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Customers</h2>
    <p>List of customers</p>

    <table class="table table-hover table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Email Id</th>
                <th>Is Active</th>
                <%--<th></th>--%>
            </tr>

        </thead>
        <tbody>
            <p>
              </p>

            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "FirstName") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "LastName") %></td>
                       
                           <td><a href='UserDetails.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "Id") %>' target="_self"><%# DataBinder.Eval(Container.DataItem, "LoginInfo.EmailId") %></a></td>
                     

                        <td><%# ((bool)DataBinder.Eval(Container.DataItem, "IsActive"))?"Yes" : "No" %></td>
                       <%-- <td>
                            <asp:LinkButton ID="imgBtnEdit" Text="Edit" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' OnClick="imgBtnEdit_Click" />
                            <asp:LinkButton ID="imgButtonDelete" Text="Delete" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' OnClick="imgButtonDelete_Click" />


                        </td>--%>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </tbody>

    </table>
</asp:Content>
