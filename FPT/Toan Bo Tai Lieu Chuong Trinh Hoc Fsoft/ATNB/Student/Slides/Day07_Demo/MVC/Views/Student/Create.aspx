<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MVC.Models.StudentModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm("Create", "Student"))
       {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            <div class="editor-label">
                Student Name
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StudentName) %>
                <%: Html.ValidationMessageFor(model => model.StudentName) %>
            </div>
            
            <div class="editor-label">
                Email
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            
            <div class="editor-label">
                Phone Number
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Phone) %>
                <%: Html.ValidationMessageFor(model => model.Phone) %>
            </div>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

