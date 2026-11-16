<%@ Page Title="" Language="C#" MasterPageFile="~/NavigationStaff.Master" AutoEventWireup="true" CodeBehind="SDetails.aspx.cs" Inherits="CarDealership.SDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 144px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30pt" Text="Vehicle Details"></asp:Label>
    <br />
    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Car ID</td>
            <td>
                <asp:Label ID="lblCID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Details ID</td>
            <td>
                <asp:TextBox ID="txtCDID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Brand</td>
            <td>
                <asp:Label ID="lblCBrand" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Model</td>
            <td>
                <asp:Label ID="lblCModel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Car Descriptions</td>
            <td>
                <asp:TextBox ID="txtCDesc" runat="server" Height="64px" TextMode="MultiLine" Width="231px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Image of the car</td>
            <td>
                <asp:FileUpload ID="imgUpload" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="status" runat="server"></asp:Label>
    <br />
</asp:Content>
