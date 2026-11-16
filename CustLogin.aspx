<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustLogin.aspx.cs" Inherits="CarDealership.CustLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Customer Login - CarImport.my</title>
    <link rel="stylesheet" href="Site.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            width: 108px;
            height: 54px;
        }
        .auto-style5 {
            width: 151px;
            height: 54px;
        }
        .auto-style6 {
            height: 54px;
        }
        .auto-style7 {
            width: 108px;
            height: 56px;
        }
        .auto-style8 {
            width: 151px;
            height: 56px;
        }
        .auto-style9 {
            height: 56px;
        }
    </style>
</head>
<body class="auth-page">
    <form id="form1" runat="server">
        <div class="auth-card">
            <span class="eyebrow">CarImport.my</span>
            <asp:Label ID="Label1" runat="server" CssClass="page-title" Font-Bold="True" Font-Size="30pt" Text="Customer sign in"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
            <strong>User Name: </strong></td>
                    <td class="auto-style5">
            <asp:TextBox ID="txtUName" runat="server" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUName" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
            <strong>Password:</strong>&nbsp;&nbsp;</td>
                    <td class="auto-style8">
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style9">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9" colspan="2">
                        <asp:CheckBox ID="CBRmbr" runat="server" Text="Remember username" />
                    </td>
                    <td class="auto-style9">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="validate" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Back to HomePage" />
            <br />
            <br />
            <asp:LinkButton ID="LBreg" runat="server" OnClick="LBreg_Click">First Time user? Register at here</asp:LinkButton>
        </div>
    </form>
</body>
</html>
