<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="Tp1_Aps.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <div>
        <table class="TMTable">
            <tr>

                <td>
                    <div>Liste de mes discussion</div>
                    <asp:ListBox ID="LB_ListDiscussion" runat="server" Width="165px" OnSelectedIndexChanged="LB_ListDiscussion_SelectedIndexChanged"></asp:ListBox>
                    <br />
                    <br />
                    <asp:Button ID="BTN_Nouveau" CLASS="TM_Button" runat="server" Text="Nouveau..." OnClick="BTN_Nouveau_Click" />
                    <br />
                    <asp:Button ID="BTN_Cree_Modifier" CLASS="TM_Button" runat="server" Text="Crée..." OnClick="BTN_Cree_Modifier_Click" />
                    <br />
                    <asp:Button ID="BTN_Effacer" CLASS="TM_Button" runat="server" Text="Effacer..." OnClick="BTN_Effacer_Click" />
                    <br />
                    <asp:Button ID="BTN_Retour" CLASS="TM_Button" runat="server" Text="Retour..." OnClick="BTN_Retour_Click" />
                    <br />
                </td>
                <td>
                    <div>Titre de la discussion</div>
                    <asp:TextBox ID="TB_NewDiscussionTitre" runat="server" Width="145px"></asp:TextBox>
                    <br />
                    <div>Sélection des invités</div>                   
                    <asp:CheckBoxList CLASS="TM_list" ID="CB_Liste" runat="server" OnSelectedIndexChanged="CB_Liste_SelectedIndexChanged" TextAlign="Left">
                        <asp:ListItem Value="0">Tous les usagers</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
