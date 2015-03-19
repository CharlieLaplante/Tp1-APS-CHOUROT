<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="Tp1_Aps.Room" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <form id="form1" runat="server">
    <div>
        <h2>
            Liste des personnes&nbsp;&nbsp;
            <asp:Button ID="BTN_Add" runat="server" Text="Ajouter..." PostBackUrl="~/AjouterPersonneV2.aspx" />  
         </h2>
        <hr />
        <asp:Panel id="PN_GridView" runat="server"></asp:Panel>
    </div>
    </form>
</asp:Content>
