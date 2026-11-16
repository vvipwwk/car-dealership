<%@ Page Title="Vehicle line-up" Language="C#" MasterPageFile="~/NavigationCust.Master" AutoEventWireup="true" CodeBehind="CVehicles.aspx.cs" Inherits="CarDealership.CVehicles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <span class="eyebrow">The collection</span>
    <h1 class="page-title">Find your next drive</h1>
    <p class="page-intro">Explore our current line-up and open a vehicle to see more details.</p>
    <asp:Panel ID="vehicledb" runat="server" />
</asp:Content>
