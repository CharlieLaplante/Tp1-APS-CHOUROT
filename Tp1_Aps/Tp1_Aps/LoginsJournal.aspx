<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginsJournal.aspx.cs" Inherits="Tp1_Aps.LoginsJournals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">

<div>
        <asp:Panel ID="PN_ListConnexion" runat="server"></asp:Panel>
        <hr />
        <asp:Button ID="BTN_Retour" runat="server" Text="Retour..." OnClick="BTN_Retour_Click" />
</div>

</asp:Content>