﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="Tp1_Aps.Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <h2>Personnes en ligne&nbsp;&nbsp;</h2>
    <div>

        <asp:Panel ID="PN_GridView" class="Tableau" runat="server"></asp:Panel>
        <asp:Button ID="BTN_Retour" runat="server" Text="Retour" class="submitBTN" OnClick="BTN_Retour_Click" />

    </div>
</asp:Content>
