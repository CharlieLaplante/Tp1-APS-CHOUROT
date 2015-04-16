<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginsJournal.aspx.cs" Inherits="Tp1_Aps.LoginsJournal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">

<div>   
     <asp:Panel id="PN_ListeLogins" class="Tableau" runat="server"></asp:Panel>     
</div>
<asp:Button ID="BTN_Retour" runat="server" Text="Retour" class="submitBTN" Width="100px" OnClick="BTN_Retour_Click"/>
</asp:Content>
