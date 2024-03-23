<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="UpdateClient.aspx.cs" Inherits="MaxFitnessGym.UpdateClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="updateclientstyles.css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
        <h2>Update Client</h2>
        <asp:Panel ID="pnlEnterID" runat="server">
            <div class="form-group">
                <label for="txtEnterID">Enter Client ID:</label>
                <asp:TextBox ID="txtEnterID" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="btn-container">
                <asp:Button ID="btnEnterID" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnEnterID_Click" />
                <asp:Button ID="Button1" runat="server" Text="Back" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
            </div>
            <div id="label1">
                 <asp:Label ID="lblIDError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
           
        </asp:Panel>
        <asp:Panel ID="pnlUpdateClient" runat="server" Visible="false">
            <div class="form-group">
                <label for="txtPassword">New Password:</label>
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
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>
            <div ID="label2">
                <asp:Label ID="lblUpdateError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
            
        </asp:Panel>
    </div>
</asp:Content>
