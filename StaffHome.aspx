<%@ Page Title="Staff home" Language="C#" MasterPageFile="~/NavigationStaff.Master" AutoEventWireup="true" CodeBehind="StaffHome.aspx.cs" Inherits="CarDealership.StaffHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <span class="eyebrow">Dealership overview</span>
    <h1 class="page-title">Welcome to your workspace.</h1>
    <p class="page-intro">Manage your vehicle line-up, customer records, and booking enquiries from one place.</p>
    <div class="feature-row">
        <a class="feature-card" href="SVehicles.aspx"><strong>Vehicle inventory →</strong><span>Review listings, edit details, or add a vehicle.</span></a>
        <a class="feature-card" href="BookRecord.aspx"><strong>Booking records →</strong><span>See customer requests and follow up with buyers.</span></a>
        <a class="feature-card" href="HR.aspx"><strong>People →</strong><span>Access customer and staff management.</span></a>
    </div>
</asp:Content>
