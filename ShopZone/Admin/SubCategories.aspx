<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SubCategories.aspx.cs" Inherits="ShopZone.Admin.SubCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Sub Categories</h2>
    <p>List of Sub Categories for : <asp:Label ID="lblParentCategory" runat="server" Text=""></asp:Label></p>

    <table class="table table-hover table-striped">
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Is Active</th>
                  <th></th>
            </tr>

        </thead>
        <tbody>
              <p><asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-xs btn-success" OnClick="btnAdd_Click" /></p>
          
            <asp:Repeater ID="Repeater1" runat="server">

                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                        <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                        <td><%# ((bool)DataBinder.Eval(Container.DataItem, "IsActive"))?"Yes" : "No" %></td>
                        <td>
                            <asp:LinkButton ID="imgBtnEdit" Text="Edit" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>'  OnClick="imgBtnEdit_Click"   />
                            <asp:LinkButton ID="imgButtonDelete" Text="Delete" runat="server" CssClass="btn btn-default btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' OnClick="imgButtonDelete_Click" />

                          
                        </td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </tbody>

    </table>
</asp:Content>
