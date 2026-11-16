<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffReg.aspx.cs" Inherits="CarDealership.StaffReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            margin-top: 0px;
        }
        .auto-style5 {
            width: 142px;
            height: 42px;
        }
        .auto-style6 {
            width: 144px;
            height: 42px;
        }
        .auto-style7 {
            height: 42px;
        }
        .auto-style8 {
            width: 142px;
            height: 35px;
        }
        .auto-style9 {
            width: 144px;
            height: 35px;
        }
        .auto-style10 {
            height: 35px;
        }
        .auto-style11 {
            width: 142px;
            height: 39px;
        }
        .auto-style12 {
            width: 144px;
            height: 39px;
        }
        .auto-style13 {
            height: 39px;
        }
        .auto-style14 {
            width: 142px;
            height: 38px;
        }
        .auto-style15 {
            width: 144px;
            height: 38px;
        }
        .auto-style16 {
            height: 38px;
        }
        .auto-style17 {
            width: 142px;
            height: 37px;
        }
        .auto-style18 {
            width: 144px;
            height: 37px;
        }
        .auto-style19 {
            height: 37px;
        }
        .auto-style20 {
            width: 142px;
            height: 36px;
        }
        .auto-style21 {
            width: 144px;
            height: 36px;
        }
        .auto-style22 {
            height: 36px;
        }
        .auto-style23 {
            width: 142px;
            height: 41px;
        }
        .auto-style24 {
            width: 144px;
            height: 41px;
        }
        .auto-style25 {
            height: 41px;
        }
    </style>
</head>
<body style="background-image:url(https://i.pinimg.com/originals/fe/7f/d0/fe7fd0869cd8ea07381304b97429178b.png); ">
    <form id="form1" runat="server">
        <div style="width:750px;background-color:white;margin:50px auto;padding:50px">
            <asp:Button ID="btnBackL" runat="server" OnClick="btnBackL_Click" Text="Back to Staff Page" />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30pt" Text="Account Registration - Staff"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">Staff ID:&nbsp;&nbsp;</td>
                    <td class="auto-style6">
            <asp:TextBox ID="txtID" runat="server" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtID" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">Staff Name:&nbsp;&nbsp;</td>
                    <td class="auto-style9">
            <asp:TextBox ID="txtSName" runat="server" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSName" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">Password:</td>
                    <td class="auto-style12">
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="auto-style13">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPass" ErrorMessage="Password word count should be at least 8 characters and above." ForeColor="Red" ValidationExpression=".{8,}" ValidationGroup="validate"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">Full Name:</td>
                    <td class="auto-style15"> <asp:TextBox ID="txtFName" runat="server" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style16">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFName" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">Date of Birth:&nbsp;&nbsp;</td>
                    <td class="auto-style18">
            <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" CssClass="auto-style3" ValidationGroup="validate"></asp:TextBox>
                    </td>
                    <td class="auto-style19">
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDOB" ErrorMessage="You must above 21 years old in order to register as staff" ForeColor="Red" MaximumValue="2001-01-01" MinimumValue="1940-01-01" Type="Date" ValidationGroup="validate"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style20">Sex:</td>
                    <td class="auto-style21"> <asp:RadioButton ID="RBMale" runat="server" Text="Male" />
&nbsp;&nbsp;
            <asp:RadioButton ID="RBFemale" runat="server" Text="Female" />
                    </td>
                    <td class="auto-style22"></td>
                </tr>
                <tr>
                    <td class="auto-style23">Position:&nbsp;&nbsp;</td>
                    <td class="auto-style24">
            <asp:DropDownList ID="DDLPosition" runat="server">
                <asp:ListItem Value="0">Select a position</asp:ListItem>
                <asp:ListItem>Account</asp:ListItem>
                <asp:ListItem>Manager</asp:ListItem>
                <asp:ListItem>Supervisor</asp:ListItem>
                <asp:ListItem>Salesperson</asp:ListItem>               
            </asp:DropDownList>
                    </td>
                    <td class="auto-style25">
                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="DDLPosition" Text="Please select a position!" ErrorMessage="Please select a position!" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">Contact Number:</td>
                    <td class="auto-style15">
            <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style16">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContact" ErrorMessage="Please enter a valid mobile phone number!" ForeColor="Red" ValidationExpression="^(\+?6?01)[02-46-9]-*[0-9]{7}$|^(\+?6?01)[1]-*[0-9]{8}$" ValidationGroup="validate"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style14">Email:</td>
                    <td class="auto-style15">
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style16">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid e-mail address!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validate"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="validate" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="status" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
