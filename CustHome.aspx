<%@ Page Title="Customer home" Language="C#" MasterPageFile="~/NavigationCust.Master" AutoEventWireup="true" CodeBehind="CustHome.aspx.cs" Inherits="CarDealership.CustHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section class="hero">
        <div class="hero-content">
            <span class="eyebrow">Welcome to CarImport.my</span>
            <h1>Make room for a new kind of drive.</h1>
            <p>Browse the latest arrivals, compare the details, and book a car that suits your next journey.</p>
            <div class="hero-actions"><a class="btn" href="CVehicles.aspx">Explore vehicles</a><a class="btn btn-secondary" href="BuyCar.aspx">Book a vehicle</a></div>
        </div>
    </section>
    <section class="feature-row">
        <div class="feature-card"><strong>Browse the line-up</strong><span>Explore available makes and models.</span></div>
        <div class="feature-card"><strong>Know the details</strong><span>See specifications, origin, and pricing.</span></div>
        <div class="feature-card"><strong>Take the next step</strong><span>Send a booking request to our team.</span></div>
    </section>
</asp:Content>
