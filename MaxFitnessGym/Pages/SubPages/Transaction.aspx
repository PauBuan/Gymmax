<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="MaxFitnessGym.Transaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="pagestyles.css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div id="container">
    <h2>Transaction</h2>
    <div class="button-container">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="search-box" placeholder="Search..." OnTextChanged="Page_Load" AutoPostBack="true" />
    </div>
    <table class="table">
        <thead>
            <tr>
                <th>ID</th>
                <th>Customer ID</th>
                <th>Subscription ID</th>
                <th>Date of Purchase</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (MaxFitnessGym.App_Code.TransactionData transaction in MaxFitnessGym.App_Code.TransactionData.List) { %>
                <tr>
                    <th><%= transaction.ID %></th>
                    <th><%= transaction.CustomerID %></th>
                    <th><%= transaction.SubscriptionID %></th>
                    <th><%= transaction.DateOfPurchase %></th>
                </tr>
            <% } %>
        </tbody>
    </table>
</div>
</asp:Content>
