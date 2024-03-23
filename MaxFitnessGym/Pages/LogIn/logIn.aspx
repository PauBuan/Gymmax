<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="MaxFitnessGym.Pages.LogIn.logIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Max Fitness Gym Login</title>
    <link rel="stylesheet" href="logIn.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-header">
                Max Fitness Gym
            </div>
            <div class="login-form">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="input" placeholder="Username" Width="239px"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password" placeholder="Password" Width="239px"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Log In" CssClass="btn" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
