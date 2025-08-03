<%@ Page Title="Add Faculty Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FacultyProfile.aspx.cs" Inherits="FacultyProfileManagementSystem.FacultyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Faculty Profile Form</h2>

    <table style="width: 50%;">
        <tr>
            <td>Full Name:</td>
            <td><asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName" ErrorMessage="Full Name is required." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Department:</td>
            <td>
                <asp:DropDownList ID="ddlDepartment" runat="server">
                    <asp:ListItem Text="--Select Department--" Value=""></asp:ListItem>
                    <asp:ListItem Text="Computer Science" Value="CS"></asp:ListItem>
                    <asp:ListItem Text="Information Technology" Value="IT"></asp:ListItem>
                    <asp:ListItem Text="Electronics" Value="EC"></asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="rfvDepartment" runat="server" ControlToValidate="ddlDepartment" ErrorMessage="Department is required." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Highest Qualification:</td>
            <td><asp:TextBox ID="txtQualification" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvQualification" runat="server" ControlToValidate="txtQualification" ErrorMessage="Qualification is required." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Specialization:</td>
            <td><asp:TextBox ID="txtSpecialization" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Experience (in years):</td>
            <td><asp:TextBox ID="txtExperience" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="rvExperience" runat="server" ControlToValidate="txtExperience" Type="Integer" MinimumValue="0" MaximumValue="50" ErrorMessage="Experience must be between 0 and 50." ForeColor="Red">*</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>Email ID:</td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email format." ForeColor="Red">*</asp:RegularExpressionValidator>
                 <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Mobile Number:</td>
            <td><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtMobile" ValidationExpression="^[0-9]{10}$" ErrorMessage="Mobile number must be 10 digits." ForeColor="Red">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                 <asp:ValidationSummary ID="vsSummary" runat="server" ForeColor="Red" HeaderText="Please fix the following errors:" />
                 <br />
                 <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>