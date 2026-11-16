<%@ Page Title="" Language="C#" MasterPageFile="~/NavigationCust.Master" AutoEventWireup="true" CodeBehind="CVehicleDetails.aspx.cs" Inherits="CarDealership.CVehicleDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 294px;
        }
        .auto-style4 {
            width: 294px;
            height: 22px;
        }
        .auto-style5 {
            height: 22px;
        }
        .auto-style6 {
            width: 100%;
            height: 167px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblCarBrand" runat="server" Font-Bold="True" Font-Size="30pt"></asp:Label>
    &nbsp;<asp:Label ID="lblCarName" runat="server" Font-Bold="True" Font-Size="30pt"></asp:Label>
    <br />
    <br />
    <table class="auto-style6">
        <tr>
            <td class="auto-style3">Type</td>
            <td>
                <asp:Label ID="lblType" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Engine</td>
            <td>
                <asp:Label ID="lblEngine" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Imported from which country</td>
            <td>
                <asp:Label ID="lblCountry" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Price (Before tax) (MYR)</td>
            <td>
                <asp:Label ID="lblPrice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Click here to view more detail informations" Width="303px" />
            </td>
            <td class="auto-style5"></td>
        </tr>
    </table>
    <br />
                <asp:Image ID="Image1" runat="server" Height="320px" Width="500px" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Description about this car:"></asp:Label>
    <br />
    <br />
                <asp:Label ID="lblDesc" runat="server"></asp:Label>
    <br />
</asp:Content>
