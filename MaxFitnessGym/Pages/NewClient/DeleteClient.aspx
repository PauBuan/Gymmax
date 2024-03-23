<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="DeleteClient.aspx.cs" Inherits="MaxFitnessGym.DeleteClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="deleteclientstyles.css" /> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
        <h2>Delete Client</h2>
        <div class="form-group">
            <label for="txtEnterID">Enter Client ID:</label>
            <asp:TextBox ID="txtEnterID" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="btn-container">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
        </div>
        <div id="label">
            <asp:Label ID="lblDeleteMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        
    </div>
</asp:Content>
