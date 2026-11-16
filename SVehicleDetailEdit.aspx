<%@ Page Title="" Language="C#" MasterPageFile="~/NavigationStaff.Master" AutoEventWireup="true" CodeBehind="SVehicleDetailEdit.aspx.cs" Inherits="CarDealership.SVehicleDetailEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            width: 118px;
        }
        .auto-style5 {
            height: 23px;
            width: 118px;
        }
        .auto-style6 {
            width: 100%;
            height: 217px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30pt" Text="Vehicle Details - Edit"></asp:Label>
    <br />
    <br />
    <table class="auto-style6">
        <tr>
            <td class="auto-style4">Car ID</td>
            <td>
                <asp:Label ID="lblCarID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Car Details ID</td>
            <td>
                <asp:Label ID="lblCarDetailsID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Car Brand</td>
            <td>
                <asp:Label ID="lblCarBrand" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Car Model</td>
            <td class="auto-style3">
                <asp:Label ID="lblCarModel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Car Descriptions</td>
            <td>
                <asp:TextBox ID="txtCarDesc" runat="server" Height="70px" TextMode="MultiLine" Width="271px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Car Image</td>
            <td>
                <asp:FileUpload ID="imgUpload" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
&nbsp;&nbsp;
    <asp:Label ID="status" runat="server"></asp:Label>
</asp:Content>
