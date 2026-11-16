<%@ Page Title="Vehicle details" Language="C#" MasterPageFile="~/NavigationCust.Master" AutoEventWireup="true" CodeBehind="CVehicleDetails.aspx.cs" Inherits="CarDealership.CVehicleDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <span class="eyebrow">Vehicle details</span>
    <div class="detail-layout">
        <div>
            <div class="detail-photo"><asp:Image ID="Image1" runat="server" AlternateText="Vehicle photo" /></div>
            <div class="detail-description"><asp:Label ID="Label1" runat="server" Text="About this vehicle" /><p><asp:Label ID="lblDesc" runat="server" /></p></div>
        </div>
        <section class="detail-info">
            <h1><asp:Label ID="lblCarBrand" runat="server" /> <asp:Label ID="lblCarName" runat="server" /></h1>
            <div class="detail-price">RM <asp:Label ID="lblPrice" runat="server" /></div>
            <div class="spec-list">
                <div class="spec-item"><small>Vehicle type</small><asp:Label ID="lblType" runat="server" /></div>
                <div class="spec-item"><small>Engine</small><asp:Label ID="lblEngine" runat="server" /></div>
                <div class="spec-item"><small>Country of origin</small><asp:Label ID="lblCountry" runat="server" /></div>
                <div class="spec-item"><small>Price basis</small>Before tax</div>
            </div>
            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show vehicle description" />
            <p class="page-intro" style="margin:16px 0 0">Interested? Choose “Book a vehicle” from the menu to send a request.</p>
        </section>
    </div>
</asp:Content>
