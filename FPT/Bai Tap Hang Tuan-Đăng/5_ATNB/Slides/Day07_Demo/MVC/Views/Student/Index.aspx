<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVC.Models.StudentModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List of Students
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List of Students</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Student  Name
            </th>
            <th>
                Email
            </th>
            <th>
                Phone
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.ID}) %> |
                <%: Html.ActionLink("Details", "Details", new { id = item.ID })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.ID })%>
            </td>
            <td>
                <%: item.StudentName %>
            </td>
            <td>
                <%: item.Email %>
            </td>
            <td>
                <%: item.Phone %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

