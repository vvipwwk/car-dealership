<%@ Page Title="" Language="C#" MasterPageFile="~/NavigationStaff.Master" AutoEventWireup="true" CodeBehind="SCustomerRemove.aspx.cs" Inherits="CarDealership.SCustomerRemove" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        Are you sure you want to remove this customer information from the database?</p>
    <p>
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Width="64px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Width="63px" />
    </p>
    <p>
        <asp:Label ID="status" runat="server"></asp:Label>
    </p>
</asp:Content>
