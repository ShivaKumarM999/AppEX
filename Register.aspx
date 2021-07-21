
<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" EnableSessionState="False" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AppEx.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="/Scripts/jquery-3.4.1.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#MainContent_password').val("<%=password.Text%>");

            function pwdCheck() {
                var pwd = $("#MainContent_password").val();
                debugger
                var reg = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[#$%^&*()]).{8,20}$/
                if (pwd == "") {

                }
                else if (!(reg.test(pwd))) {
                    $("#MainContent_passwordError").show()
                    $("#MainContent_passwordError").text("Please enter valid Password, should contain atleast one Upper & Lower character, Digit and Special character")
                    debugger
                }
                else {
                    $("#MainContent_passwordError").show();
                    $("#MainContent_passwordError").text("")
                }
            }
            $("#MainContent_password").focusout(pwdCheck);
            $("#MainContent_register").click(pwdCheck);
        });
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>

        <table>
            <tr>
                <th colspan="4" align="left">Sign Up</th>
            </tr>

            <tr>
                <td colspan="2" align="right">First Name: </td>
                <td>
                    <asp:TextBox ID="firstName" runat="server"></asp:TextBox>&nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ErrorMessage="Please Enter First Name" ForeColor="#FF3300" ControlToValidate="firstName"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right">Last Name: </td>
                <td>
                    <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqLastName" runat="server" ErrorMessage="Please Enter Last Name" ForeColor="#FF3300" ControlToValidate="lastName"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right">User Name: </td>
                <td>
                    <asp:TextBox ID="userName" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Label ID="message" runat="server" Text="userCheck" ForeColor="#FF3300"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqUserName" runat="server" ErrorMessage="Please Enter User Name" ForeColor="#FF3300" ControlToValidate="userName"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right">Password: </td>
                <td>
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="passwordError" runat="server" Style="display: none" Text="passwordCheck" ForeColor="#FF3300"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ErrorMessage="Please Enter Password" ForeColor="#FF3300" ControlToValidate="password"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right">Email: </td>
                <td>
                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="right">Gender: </td>
                <td>
                    <asp:RadioButtonList ID="gender" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqGender" runat="server" ErrorMessage="Please select Gender" ForeColor="#FF3300" ControlToValidate="gender"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right">Date Of Birth: </td>
                <td>
                    <asp:TextBox ID="dateOfBirth" TextMode="Date" runat="server" AutoPostBack="True" OnTextChanged="dateOfBirth_TextChanged"></asp:TextBox>


                </td>

                <td>
                    <asp:Label ID="ageCheck" runat="server" Text="ageCheck" ForeColor="#FF3300"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqDOB" runat="server" ErrorMessage="Please select Date of Birth" ForeColor="#FF3300" ControlToValidate="dateOfBirth"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right">Country: </td>
                <td>
                    <asp:DropDownList ID="country" DataTextField="CountryName" DataValueField="CountryId" runat="server" OnSelectedIndexChanged="country_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;</td>
                <td style="font-weight: 700">
                    <asp:RequiredFieldValidator ID="reqCountry" runat="server" InitialValue="-1" ErrorMessage="Please select country" ForeColor="#FF3300" ControlToValidate="country" Font-Bold="False"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right">State: </td>
                <td>
                    <asp:DropDownList ID="state" DataTextField="StateName" DataValueField="SId" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="reqState" runat="server" InitialValue="-1" ErrorMessage="Please select state" ForeColor="#FF3300" ControlToValidate="state"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" align="right">Phone: </td>
                <td>
                    <asp:TextBox ID="phone" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center"></td>
                <td colspan="2" align="Left">
                    <asp:Button ID="register" runat="server" Text="Sign Up" OnClick="signUp_Click" /></td>

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
