<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="Tp1_Aps.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <div>
        <table class="TMTable">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UPan_ListDiscussion" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div>Liste de mes discussion</div>
                            <asp:ListBox ID="LB_ListDiscussion" runat="server" Width="165px" Height="200" AutoPostBack="True" OnSelectedIndexChanged="LB_ListDiscussion_SelectedIndexChanged"></asp:ListBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UPan_BTN_Cree_Modifier" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="BTN_Nouveau" CLASS="TM_Button" runat="server" Text="Nouveau..." OnClick="BTN_Nouveau_Click" />
                            <br />
                            <asp:Button ID="BTN_Cree_Modifier" CLASS="TM_Button" runat="server" Text="Crée..." OnClick="BTN_Cree_Modifier_Click" />
                            <br />
                            <asp:Button ID="BTN_Effacer" CLASS="TM_Button" runat="server" Text="Effacer..." OnClick="BTN_Effacer_Click" />
                            <br />
                            <asp:Button ID="BTN_Retour" CLASS="TM_Button" runat="server" Text="Retour..." OnClick="BTN_Retour_Click" />
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>


                <td>
                    <div>Titre de la discussion</div>

                    <asp:UpdatePanel ID="UPan_TBtitreDiscussion" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:TextBox ID="TB_NewDiscussionTitre" runat="server" Width="145px"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <br />
                    <asp:UpdatePanel ID="UPan_CB" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div>Sélection des invités</div>
                            <asp:CheckBox Class="TM_list" ID="CB_Toutlemonde" runat="server" TextAlign="Left" Text="Tous les usager" OnCheckedChanged="CB_Toutlemonde_CheckedChanged" Checked="False" ViewStateMode="Enabled" AutoPostBack="True" />
                            <asp:CheckBoxList CLASS="TM_list" ID="CB_Liste" runat="server" OnSelectedIndexChanged="CB_Liste_SelectedIndexChanged" TextAlign="Left" ViewStateMode="Enabled"></asp:CheckBoxList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
