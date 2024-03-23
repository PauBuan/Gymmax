<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Site.Master" AutoEventWireup="true" CodeBehind="tryHomePage.aspx.cs" Inherits="MaxFitnessGym.Pages.SubPages.tryHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="pagestyles.css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="home-container" style="background-color: black;">
         <div class="right-section">
             <img src="feat.gif" alt="Feat" />
         </div>
         <div class="middle-section">
             <img src="gymlogo.png" alt="Gym Logo" />
         </div>
         <div class="right-section"> 
             <div class="image-container">
                 <img src="Promo 1.png" alt="Promo 1" />
             </div>
             <div class="image-container">
                 <img src="Promo2.png" alt="Promo 2" />
             </div>
             <div class="image-container">
                 <img src="Promo3.png" alt="Promo 3" />
             </div>
             <div class="image-container">
                 <img src="Promo4.png" alt="Promo 4" />
             </div>
         </div>
     </div>
</asp:Content>
