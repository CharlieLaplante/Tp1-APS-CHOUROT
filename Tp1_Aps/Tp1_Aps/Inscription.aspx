<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="Tp1_Aps.Inscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="FormStyles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <h1>Inscription</h1>
            <hr />
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <label for="TB_FullName" class='label'>Nom Complet:</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TB_FullName" name="TB_FullName" runat="server" CssClass="textbox"
                                        onkeyup="ConstrainToAlpha(event);"> </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="TB_UserName" class='label'>Nom d'Utilisateur:</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TB_UserName" name="TB_UserName" runat="server" CssClass="textbox"
                                        onkeyup="ConstrainToAlpha(event);"> </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="TB_Password" class='label'>Password:</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TB_Password" name="TB_Password" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="TB_Email" class='label'>Email:</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TB_Email" name="TB_Email" runat="server" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="BTN_Add" runat="server" Text="Add" class="submitBTN"
                                        OnClick="BTN_Add_Click"  ValidationGroup="Subscribe_Validation" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="BTN_Cancel" runat="server" Text="Cancel" class="submitBTN" OnClick="BTN_Cancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td id="AvatarSection">
                        <asp:Image ID="IMG_Avatar" runat="server" CssClass="thumbnail" ImageUrl="~/Images/Anonymous.png" />
                        <hr />
                        <asp:FileUpload ID="FU_Avatar" runat="server" ClientIDMode="Static" onchange="PreLoadImage();" />
                    </td>
                    <td>
                        <div>
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="RegenarateCaptcha" runat="server"
                                                                ImageUrl="~/Images/RegenerateCaptcha.png"
                                                                CausesValidation="False"
                                                                OnClick="RegenarateCaptcha_Click"
                                                                ValidationGroup="Subscribe_Validation"
                                                                Width="48"
                                                                ToolTip="Regénérer le captcha..." />
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="IMGCaptcha" ImageUrl="~/captcha.png" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5"></asp:TextBox>
                                        <asp:CustomValidator ID="CV_Captcha" runat="server"
                                            ErrorMessage="Code captcha incorrect!"
                                            ValidationGroup="Subscribe_Validation"
                                            Text="!"
                                            ControlToValidate="TB_Captcha"
                                            OnServerValidate="CV_Captcha_ServerValidate"
                                            ValidateEmptyText="True">
                                        </asp:CustomValidator>
                                    </td>
                                </tr>                         
                            </table>
                        </div>
                        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
