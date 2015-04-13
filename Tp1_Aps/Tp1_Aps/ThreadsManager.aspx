<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="Tp1_Aps.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <div>
        <table class="TMTable">
            <tr>

                <td>
                    <div>Liste de mes discussion</div>
                    <asp:ListBox ID="LB_ListDiscussion" runat="server" Width="152px"></asp:ListBox>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Button" />
                    <br />
                    <asp:Button ID="Button3" runat="server" Text="Button" />
                    <br />
                    <asp:Button ID="Button4" runat="server" Text="Button" />
                    <br />
                </td>

                <td>
                    <div>Titre de la discussion</div>
                    <asp:TextBox ID="TB_NewDiscussionTitre" runat="server" Width="145px"></asp:TextBox>
                    <br />
                    <div>Sélection des invités</div>
                    <asp:CheckBox ID="CB_Tout_le_monde" runat="server" />
                    Tous les usagers
                    <asp:Panel ID="CB_Scroll_Truc" runat="server">
                        <asp:CheckBoxList ID="CB_Liste" runat="server"></asp:CheckBoxList>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
