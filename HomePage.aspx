<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CarDealership.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CarImport.my</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 309px;
        }
    </style>
</head>
<body style="background-image:url(https://static.vecteezy.com/system/resources/previews/002/196/579/original/modern-abstract-geometric-background-free-vector.jpg); ">
    <form id="form1" runat="server">
        <div style="width:750px;background-color:white;margin:50px auto;padding:50px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30pt" Text="Welcome To CarImport.my"></asp:Label>
            <br />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="127px" ImageUrl="~/customer.png" OnClick="ImageButton1_Click" Width="155px" />
                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="153px" ImageUrl="~/dealer.png" OnClick="ImageButton2_Click" Width="153px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Customer Login "></asp:Label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="Staff Login"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
