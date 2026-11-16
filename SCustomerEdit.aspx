<%@ Page Title="" Language="C#" MasterPageFile="~/NavigationStaff.Master" AutoEventWireup="true" CodeBehind="SCustomerEdit.aspx.cs" Inherits="CarDealership.SCustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style22 {
            width: 100%;
            height: 286px;
        }
        .auto-style4 {
            width: 130px;
            height: 29px;
        }
        .auto-style16 {
            height: 29px;
            width: 142px;
        }
        .auto-style5 {
            height: 29px;
        }
        .auto-style6 {
            width: 130px;
            height: 33px;
        }
        .auto-style17 {
            height: 33px;
            width: 142px;
        }
        .auto-style7 {
            height: 33px;
        }
        .auto-style8 {
            width: 130px;
            height: 32px;
        }
        .auto-style18 {
            height: 32px;
            width: 142px;
        }
        .auto-style9 {
            height: 32px;
        }
        .auto-style10 {
            width: 130px;
            height: 30px;
        }
        .auto-style19 {
            height: 30px;
            width: 142px;
        }
        .auto-style11 {
            height: 30px;
        }
        .auto-style12 {
            width: 130px;
            height: 28px;
        }
        .auto-style20 {
            height: 28px;
            width: 142px;
        }
        .auto-style13 {
            height: 28px;
        }
        .auto-style14 {
            width: 130px;
            height: 31px;
        }
        .auto-style21 {
            height: 31px;
            width: 142px;
        }
        .auto-style15 {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30pt" Text="Edit customer details"></asp:Label>
    <br />
    <br />
    <table __designer:mapid="19" class="auto-style22">
        <tr __designer:mapid="1a">
            <td __designer:mapid="1b" class="auto-style4">User ID</td>
            <td __designer:mapid="1c" class="auto-style16">
                <asp:Label ID="lblUID" runat="server"></asp:Label>
            </td>
            <td __designer:mapid="1d" class="auto-style5"></td>
        </tr>
        <tr __designer:mapid="1e">
            <td __designer:mapid="1f" class="auto-style6">Username</td>
            <td __designer:mapid="20" class="auto-style17">
                <asp:TextBox ID="txtUserName" runat="server" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td __designer:mapid="21" class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr __designer:mapid="22">
            <td __designer:mapid="23" class="auto-style8">Password</td>
            <td __designer:mapid="24" class="auto-style18">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td __designer:mapid="25" class="auto-style9">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password must be blank or at least 12 characters." ForeColor="Red" ValidationExpression=".{12,}" ValidationGroup="validate"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr __designer:mapid="26">
            <td __designer:mapid="27" class="auto-style10">Full Name</td>
            <td __designer:mapid="28" class="auto-style19">
                <asp:TextBox ID="txtFullName" runat="server" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td __designer:mapid="29" class="auto-style11">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFullName" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr __designer:mapid="2a">
            <td __designer:mapid="2b" class="auto-style4">Date of Birth</td>
            <td __designer:mapid="2c" class="auto-style16">
                <asp:TextBox ID="txtDateofBirth" runat="server" TextMode="Date" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td __designer:mapid="2d" class="auto-style5">
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDateofBirth" ErrorMessage="You must above 21 years old in order to register as our customer" ForeColor="Red" MaximumValue="2001-01-01" MinimumValue="1940-01-01" Type="Date" ValidationGroup="validate"></asp:RangeValidator>
            </td>
        </tr>
        <tr __designer:mapid="2e">
            <td __designer:mapid="2f" class="auto-style12">Sex</td>
            <td __designer:mapid="30" class="auto-style20">
                <asp:RadioButton ID="RBMale" runat="server" Text="Male" />
&nbsp;&nbsp;
                <asp:RadioButton ID="RBFemale" runat="server" Text="Female" />
            </td>
            <td __designer:mapid="31" class="auto-style13"></td>
        </tr>
        <tr __designer:mapid="32">
            <td __designer:mapid="33" class="auto-style8">Contact Number</td>
            <td __designer:mapid="34" class="auto-style18">
                <asp:TextBox ID="txtContactNo" runat="server" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td __designer:mapid="35" class="auto-style9">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Please enter a valid mobile phone number!" ForeColor="Red" ValidationExpression="^(\+?6?01)[02-46-9]-*[0-9]{7}$|^(\+?6?01)[1]-*[0-9]{8}$" ValidationGroup="validate"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr __designer:mapid="36">
            <td __designer:mapid="37" class="auto-style14">Email</td>
            <td __designer:mapid="38" class="auto-style21">
                <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td __designer:mapid="39" class="auto-style15">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid e-mail address!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validate"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" ValidationGroup="validate" />
</asp:Content>
