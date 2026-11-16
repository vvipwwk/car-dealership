<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustReg.aspx.cs" Inherits="CarDealership.CustReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            width: 133px;
            height: 37px;
        }
        .auto-style5 {
            width: 152px;
            height: 37px;
        }
        .auto-style6 {
            height: 37px;
        }
        .auto-style7 {
            width: 133px;
            height: 33px;
        }
        .auto-style8 {
            width: 152px;
            height: 33px;
        }
        .auto-style9 {
            height: 33px;
        }
        .auto-style10 {
            width: 133px;
            height: 36px;
        }
        .auto-style11 {
            width: 152px;
            height: 36px;
        }
        .auto-style12 {
            height: 36px;
        }
        .auto-style13 {
            width: 133px;
            height: 34px;
        }
        .auto-style14 {
            width: 152px;
            height: 34px;
        }
        .auto-style15 {
            height: 34px;
        }
        .auto-style16 {
            width: 133px;
            height: 38px;
        }
        .auto-style17 {
            width: 152px;
            height: 38px;
        }
        .auto-style18 {
            height: 38px;
        }
        .auto-style19 {
            width: 133px;
            height: 35px;
        }
        .auto-style20 {
            width: 152px;
            height: 35px;
        }
        .auto-style21 {
            height: 35px;
        }
    </style>
</head>
<body style="background-image:url(https://wallpaperaccess.com/full/187170.jpg); ">
    <form id="form1" runat="server">
        <div style="width:750px;background-color:white;margin:50px auto;padding:50px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30pt" Text="Account Registration - Customer"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">User Name:</td>
                    <td class="auto-style5">
            <asp:TextBox ID="txtUsername" runat="server" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">Password:&nbsp;&nbsp;&nbsp;</td>
                    <td class="auto-style8">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style9">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password must be at least 12 characters." ForeColor="Red" ValidationExpression=".{12,}" ValidationGroup="validate"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">Full Name:&nbsp;&nbsp;</td>
                    <td class="auto-style11"> <asp:TextBox ID="txtFName" runat="server" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFName" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Date of Birth:&nbsp;&nbsp;</td>
                    <td class="auto-style5">
            <asp:TextBox ID="txtDate" runat="server" TextMode="Date" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        &nbsp;
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="You must above 21 years old in order to register as our customer" ForeColor="Red" MaximumValue="2004-01-01" MinimumValue="1940-01-01" Type="Date" ValidationGroup="validate"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">Sex:</td>
                    <td class="auto-style14"> <asp:RadioButton ID="RBMale" runat="server" GroupName="sex" Text="Male" />
&nbsp;&nbsp;
            <asp:RadioButton ID="RBFemale" runat="server" GroupName="sex" Text="Female" />
                    </td>
                    <td class="auto-style15"></td>
                </tr>
                <tr>
                    <td class="auto-style16">Contact Number:&nbsp;&nbsp;</td>
                    <td class="auto-style17">
            <asp:TextBox ID="txtContact" runat="server" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style18">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtContact" ErrorMessage="Please enter a valid mobile phone number!" ForeColor="Red" ValidationExpression="^(\+?6?01)[02-46-9]-*[0-9]{7}$|^(\+?6?01)[1]-*[0-9]{8}$" ValidationGroup="validate"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style19">Email:&nbsp;&nbsp;</td>
                    <td class="auto-style20">
            <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style21">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid e-mail address!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validate"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="validate" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBackL" runat="server" OnClick="btnBackL_Click" Text="Back to Login" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
