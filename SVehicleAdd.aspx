<%@ Page Title="" Language="C#" MasterPageFile="~/NavigationStaff.Master" AutoEventWireup="true" CodeBehind="SVehicleAdd.aspx.cs" Inherits="CarDealership.SVehicleAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 149px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30pt" Text="Add new vehicle"></asp:Label>
    <br />
    <br />
    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Car ID</td>
            <td>
                <asp:TextBox ID="txtCID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Brand</td>
            <td>
                <asp:TextBox ID="txtCBrand" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Model</td>
            <td>
                <asp:TextBox ID="txtCModel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Type</td>
            <td>
                <asp:DropDownList ID="DDLCType" runat="server">
                    <asp:ListItem>Sedan</asp:ListItem>
                    <asp:ListItem>Saloon</asp:ListItem>
                    <asp:ListItem>Luxury</asp:ListItem>
                    <asp:ListItem>SUV</asp:ListItem>
                    <asp:ListItem>Compact</asp:ListItem>
                    <asp:ListItem>MPV</asp:ListItem>
                    <asp:ListItem>Coupe</asp:ListItem>
                    <asp:ListItem>Sport</asp:ListItem>
                    <asp:ListItem>Exotic</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Engine</td>
            <td>
                <asp:TextBox ID="txtCEngine" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Country Imported from</td>
            <td>
                <asp:TextBox ID="txtCCountry" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Price (before tax)</td>
            <td>
                <asp:TextBox ID="txtCPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    <br />
    <br />
    <asp:Label ID="status" runat="server"></asp:Label>
</asp:Content>
