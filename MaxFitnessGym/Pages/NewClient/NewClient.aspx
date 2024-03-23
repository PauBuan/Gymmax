<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="NewClient.aspx.cs" Inherits="MaxFitnessGym.NewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="newclientstyles.css" /> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
        <h2>New Client</h2>

        <div class="form-group">
             <label for="txtPassword">Password:</label>
             <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
       
        <div class="form-group">
            <label for="txtLastName">Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtFirstName">First Name:</label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtPhone">Phone:</label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ddlSubscription">Subscription:</label>
            <asp:DropDownList ID="ddlSubscription" runat="server" CssClass="form-control">
                <asp:ListItem Text="Session" Value="1"></asp:ListItem>
                <asp:ListItem Text="Weekly" Value="2"></asp:ListItem>
                <asp:ListItem Text="Bi-Weekly" Value="3"></asp:ListItem>
                <asp:ListItem Text="Monthly" Value="4"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="btn-container">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
        </div>
        <div id="label">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        
    </div>
</asp:Content>
