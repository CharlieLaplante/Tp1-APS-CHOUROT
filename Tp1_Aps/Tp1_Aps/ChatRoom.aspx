<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="Tp1_Aps.ChatRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">

    <table>
        <tr>
            <td>
                <asp:Panel id="PN_ListeChat" class="Tableau" runat="server"></asp:Panel>
            </td>
            <td>
                <asp:Panel id="PN_ListeMessage" class="Tableau" runat="server"></asp:Panel>
            </td>
        </tr>       
    </table>         

</asp:Content>
