<%@ Page Title="" Language="C#" MasterPageFile="~/NavigationCust.Master" AutoEventWireup="true" CodeBehind="BookCar.aspx.cs" Inherits="CarDealership.BookCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 129px;
        }
        .auto-style4 {
            width: 100%;
            height: 157px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        Are you confirm to book the car?</p>
    <table class="auto-style4">
        <tr>
            <td class="auto-style3">Car Name:</td>
            <td>
                <asp:Label ID="lblCarBrand" runat="server"></asp:Label>
&nbsp;<asp:Label ID="lblCarModel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Price:</td>
            <td>
                <asp:Label ID="lblCarPrice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Buyer&#39;s name</td>
            <td>
                <asp:Label ID="lblBuyer" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Sales ID:</td>
            <td>
                <asp:Label ID="lblSalesID" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <p>
        <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" Width="69px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNo" runat="server" OnClick="Button2_Click" Text="No" Width="71px" />
    </p>
    <p>
        <asp:Label ID="status" runat="server"></asp:Label>
    </p>
</asp:Content>
