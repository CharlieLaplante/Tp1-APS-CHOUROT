<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="Tp1_Aps.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <div>
        <table id="TMTable">
            <tr>
                
                <td>
                    <div>Liste de mes discussion</div>
                    <asp:ListBox ID="LB_ListDiscussion" runat="server" Height="100px" Width="150px"></asp:ListBox></td>
                <td>
                    <div>Titre de la discussion</div>
                    <asp:TextBox ID="TB_NewDiscussionTitre" runat="server" Width="150px"></asp:TextBox>
                    <div>Sélection des invités</div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
