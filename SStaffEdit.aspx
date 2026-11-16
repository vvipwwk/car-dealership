<%@ Page Title="" Language="C#" MasterPageFile="~/NavigationStaff.Master" AutoEventWireup="true" CodeBehind="SStaffEdit.aspx.cs" Inherits="CarDealership.SStaffEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            height: 36px;
        }
        .auto-style4 {
            height: 33px;
        }
        .auto-style5 {
            height: 32px;
        }
        .auto-style6 {
            width: 100%;
            height: 320px;
        }
        .auto-style7 {
            height: 36px;
            width: 122px;
        }
        .auto-style8 {
            height: 33px;
            width: 122px;
        }
        .auto-style9 {
            height: 32px;
            width: 122px;
        }
        .auto-style10 {
            width: 122px;
        }
        .auto-style11 {
            height: 36px;
            width: 151px;
        }
        .auto-style12 {
            height: 33px;
            width: 151px;
        }
        .auto-style13 {
            height: 32px;
            width: 151px;
        }
        .auto-style14 {
            width: 151px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="30pt" Text="Edit Staff details"></asp:Label>
    <br />
    <br />
    <table class="auto-style6">
        <tr>
            <td class="auto-style7">Staff ID</td>
            <td class="auto-style11">
                <asp:Label ID="lblStaffID" runat="server"></asp:Label>
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style8">Staff Name</td>
            <td class="auto-style12">
                <asp:TextBox ID="txtStaffName" runat="server" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStaffName" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Password</td>
            <td class="auto-style13">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password word count should be at least 8 characters and above." ForeColor="Red" ValidationExpression=".{8,}" ValidationGroup="validate"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Full Name</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtFullName" runat="server" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFullName" ErrorMessage="* required field" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Date of Birth</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtDateofBirth" runat="server" TextMode="Date" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDateofBirth" ErrorMessage="You must above 21 years old in order to register staff" ForeColor="Red" MaximumValue="2001-01-01" MinimumValue="1940-01-01" Type="Date" ValidationGroup="validate"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Sex</td>
            <td class="auto-style14">
                <asp:RadioButton ID="RBMale" runat="server" Text="Male" />
&nbsp;&nbsp;
                <asp:RadioButton ID="RBFemale" runat="server" Text="Female" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">Position</td>
            <td class="auto-style14">
                <asp:DropDownList ID="DDLPosition" runat="server" ValidationGroup="validate">
                    <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem>Account</asp:ListItem>
                    <asp:ListItem>Manager</asp:ListItem>
                    <asp:ListItem>Supervisor</asp:ListItem>
                    <asp:ListItem>Salesperson</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="DDLPosition" Text="Please select a position!" ErrorMessage="Please select a position!" ForeColor="Red" ValidationGroup="validate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Contact Number</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtContactNo" runat="server" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtContactNo" ErrorMessage="Please enter a valid mobile number!" ForeColor="Red" ValidationExpression="^(\+?6?01)[02-46-9]-*[0-9]{7}$|^(\+?6?01)[1]-*[0-9]{8}$" ValidationGroup="validate"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Email</td>
            <td class="auto-style14">
                <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="validate"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter a valid e-mail address!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validate"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" ValidationGroup="validate" />
    <br />
</asp:Content>
