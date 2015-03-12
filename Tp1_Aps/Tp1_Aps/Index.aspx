<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Tp1_Aps.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="BTN_Profil" runat="server" Text="Profil" class="submitBTN" OnClick="BTN_Profil_Click" />
                    </td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="BTN_Room" runat="server" Text="Usager en ligne" class="submitBTN" OnClick="BTN_Riin_Click" />
                    </td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="BTN_LoginsJournal" runat="server" Text="Profil" class="submitBTN" OnClick="BTN_Profil_Click" />
                    </td>
                </tr>
                 <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Profil" class="submitBTN" OnClick="BTN_Profil_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
