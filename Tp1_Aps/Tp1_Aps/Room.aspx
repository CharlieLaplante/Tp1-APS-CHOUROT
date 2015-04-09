<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="Tp1_Aps.Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">

    <div>
        <asp:Timer ID="Timer1" runat="server" Interval="3000" ontick="Timer1_Tick"></asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel1" class="Tableau" runat="server" UpdateMode="Conditional"></asp:UpdatePanel>        
        <asp:Panel ID="PN_ListerUtilisateur" class="Tableau" runat="server"></asp:Panel>
        <asp:Button ID="BTN_Retour" runat="server" Text="Retour" class="submitBTN" OnClick="BTN_Retour_Click" />

    </div>
</asp:Content>
