﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tp1_Aps.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <script type="text/javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
 </script>
    <div>	      
        <table>
            <tr>
                <td>
                    <label for="TB_UserName" class='label'>Nom Utilisateur:</label>
                </td>
                <td>
                    <asp:TextBox ID="TB_UserName" name="TB_UserName" runat="server" CssClass="textbox"> </asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFV_TB_UserName" runat="server"
                        Text="!vide"
                        ErrorMessage="Le nom d'usager est vide!"
                        ControlToValidate="TB_UserName"
                        ValidationGroup="VG_Login">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="TB_Password" class='label'>Password:</label>
                </td>
                <td>
                    <asp:TextBox ID="TB_Password" name="TB_Password" runat="server" CssClass="textbox"
                        TextMode="Password"> </asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFV_TB_Password" runat="server"
                        Text="!vide"
                        ErrorMessage="Le mot de passe est vide!"
                        ControlToValidate="TB_Password"
                        ValidationGroup="VG_Login">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Login" runat="server" Text="Login" class="submitBTN" ValidationGroup="VG_Login"
                        OnClick="BTN_Login_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_Inscription"
                         runat="server" Text="Inscription"
                         class="submitBTN"
                         OnClick="BTN_Inscription_Click" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BTN_MotDePasseEmail"
                         runat="server"
                         Text="Mot de passe oublié"
                         Class="submitBTN"
                         OnClick="BTN_Mot_De_Passe_Email_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left;">
                    <asp:ValidationSummary ID="VGS_Logi" runat="server" ValidationGroup="VG_Login" HeaderText="Résumé des erreurs: &lt;hr/&gt;" />
                </td>
            </tr>
        </table>
    </div>
    <asp:CustomValidator ID="CV_TB_UserName" runat="server"
        ErrorMessage="Ce nom d'usager n'existe pas!"
        Display="None"
        ValidationGroup="VG_Login"
        OnServerValidate="CV_TB_UserName_ServerValidate">
    </asp:CustomValidator>

    <asp:CustomValidator ID="CV_TB_Password" runat="server"
        ErrorMessage="Mauvais Mot de passe!"
        Display="None"
        ValidationGroup="VG_Login"
        OnServerValidate="CV_TB_Password_ServerValidate">
    </asp:CustomValidator>
</asp:Content>
