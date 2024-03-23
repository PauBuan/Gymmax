<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="MaxFitnessGym.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="userdetailsstyles.css" /> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
        <h2>User Details</h2>
        <div class="user-info">
            <div class="info-row">
                <label>ID:</label>
                <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
            </div>
            <div class="info-row">
                <label>Last Name:</label>
                <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
            </div>
            <div class="info-row">
                <label>First Name:</label>
                <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
            </div>
            <div class="info-row">
                <label>Phone Number:</label>
                <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
            </div>
            <div class="info-row">
                <label>Date of Purchase:</label>
                <asp:Label ID="lblDateOfPurchase" runat="server" Text=""></asp:Label>
            </div>
            <div class="info-row">
                <label>Subscription:</label>
                <asp:Label ID="lblSubscription" runat="server" Text=""></asp:Label>
            </div>
            <div class="info-row">
                <label>Duration (Days):</label>
                <asp:Label ID="lblDuration" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="btn-container">
            <asp:Button ID="btnBack" runat="server" Text="Log Out" CssClass="btn btn-primary" OnClick="btnBack_Click" />
        </div>
    </div>
</asp:Content>
