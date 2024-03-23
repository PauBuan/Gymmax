<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="MaxFitnessGym.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="pagestyles.css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
        <h2>List of Clients</h2>
        <div class="button-container">
            <asp:Button ID="btnNewClient" runat="server" Text="New Client" CssClass="btn btn-primary btn-sm" OnClick="btnNewClient_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary btn-sm" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary btn-sm" OnClick="btnDelete_Click" />
            <asp:TextBox ID="txtSearch" runat="server" CssClass="search-box" placeholder="Search..." OnTextChanged="Page_Load" AutoPostBack="true" />
        </div>
        <table class="table">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Phone Number</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (MaxFitnessGym.App_Code.CustomerData customer in MaxFitnessGym.App_Code.CustomerData.List) { %>
                    <tr>
                        <th><%= customer.ID %></th>
                        <th><%= customer.FirstName %></th>
                        <th><%= customer.LastName %></th>
                        <th><%= customer.PhoneNumber %></th>
                    </tr>
                <% } %>
            </tbody>
        </table>
    </div>
</asp:Content>
