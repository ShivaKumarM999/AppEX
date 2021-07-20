<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="AppEx.SignIn" MasterPageFile="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <th colspan="4" align="left">Sign In</th>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <asp:Label ID="message" runat="server" Text="checkValidUser" ForeColor="#FF3300"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="2" align="right">User Name: </td>
                <td>
                    <asp:TextBox ID="userName" runat="server"></asp:TextBox>&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="reqUserName" runat="server" ErrorMessage="Please Enter User Name" ForeColor="#FF3300" ControlToValidate="userName"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right">Password: </td>
                <td>
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                </td>

                <td>

                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ErrorMessage="Please Enter Password" ForeColor="#FF3300" ControlToValidate="password"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <td colspan="2" align="left">
                    <asp:Button ID="login" runat="server" Text="Sign In" OnClick="login_Click" />

                    &nbsp;<asp:Button ID="retrivePassword" runat="server" Text="Retrive Password" OnClick="retrivePassword_Click" /></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>



