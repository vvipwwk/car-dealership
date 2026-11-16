<%@ Page Title="" Language="C#" MasterPageFile="~/NavigationStaff.Master" AutoEventWireup="true" CodeBehind="SStaffRemove.aspx.cs" Inherits="CarDealership.SStaffRemove" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        Are you sure you want to remove this staff information from the database?</p>
    <p>
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Width="56px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" Width="58px" />
    </p>
    <p>
        <asp:Label ID="status" runat="server"></asp:Label>
    </p>
</asp:Content>
