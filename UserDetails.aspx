<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="AppEx.UserDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Mobile App</h1>
    </div>
    <div>
       
        <table>
            <tr>
                <th colspan="3" align="left">Welcome
                        <asp:Label ID="user" runat="server" Text="User"></asp:Label></th>
            </tr>
            <tr>
                <th colspan="2"></th>
                        
            </tr>
            <tr>
                
                <td align="right">First Name: </td>
                <td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="firstName" runat="server" Text="firstName"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Last Name: </td><td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="lastName" runat="server" Text="lastName"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">User Name: </td><td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="userName" runat="server" Text="userName"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Email: </td><td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="email" runat="server" Text="email"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Gender: </td><td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="gender" runat="server" Text="gender"></asp:Label></td>
            </tr>
            <tr>
                <td>Date Of Birth: </td><td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="dateOfBirth" runat="server" Text="dateOfBirth"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Country: </td><td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="country" runat="server" Text="country"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">State: </td><td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="state" runat="server" Text="state"></asp:Label></td>
            </tr>
            <tr>
                <td align="right">Phone: </td><td>&nbsp;&nbsp;</td>
                <td>
                    <asp:Label ID="phone" runat="server" Text="phone"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
