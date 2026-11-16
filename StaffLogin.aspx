<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="CarDealership.StaffLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Staff Login - CarImport.my</title>
    <link rel="stylesheet" href="Site.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            margin-top: 0px;
        }
        .auto-style3 {
            width: 99px;
            height: 55px;
        }
        .auto-style4 {
            width: 141px;
            height: 55px;
        }
        .auto-style5 {
            width: 99px;
            height: 56px;
        }
        .auto-style6 {
            width: 141px;
            height: 56px;
        }
        .auto-style7 {
            height: 56px;
        }
        .auto-style8 {
            height: 55px;
        }
    </style>
</head>
<body class="auth-page">
    <form id="form1" runat="server">
        <div class="auth-card">
            <span class="eyebrow">CarImport.my</span>
            <asp:Label ID="Label1" runat="server" CssClass="page-title" Font-Bold="True" Font-Size="30pt" Text="Staff sign in"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">
            <strong>Staff ID:</strong>&nbsp;&nbsp;</td>
                    <td class="auto-style6">
            <asp:TextBox ID="txtSID" runat="server" CssClass="auto-style2" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSID" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
            <strong>Password:</strong></td>
                    <td class="auto-style4">
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8" colspan="2">
                        <asp:CheckBox ID="CBRmbr" runat="server" Text="Remember staff ID" />
                    </td>
                    <td class="auto-style8">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="validate" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Back to HomePage" formnovalidate />
            <br />
        </div>
    </form>
</body>
</html>
