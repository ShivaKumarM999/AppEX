<%@ Page Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="AppEx.Details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:GridView ID="userGridView" runat="server"></asp:GridView>
    </div>
</asp:Content>
