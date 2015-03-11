<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tp1_Aps.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css"/>

    <script src="ClientFormUtilities.js"></script>
    <link rel="stylesheet" href="FormStyles.css"/>

</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table>
             <tr>
                 <td> <label for="TB_FullName" class='label'>Nom Complet:</label>  </td>
                 <td>
                     <asp:TextBox ID="TB_FullName" name="TB_FullName" runat="server" CssClass="textbox" 
                         onkeyup = "ConstrainToAlpha(event);"> </asp:TextBox>
                </td>
             </tr>
             
              <tr>
                 <td> <label for="TB_UserName" class='label'>Nom Utilisateur:</label> </td>
                 <td>
                     <asp:TextBox ID="TB_UserName" name="TB_UserName" runat="server" CssClass="textbox"
                          onkeyup = "ConstrainToAlpha(event);"> </asp:TextBox>
                  </td>
              </tr>
             
              <tr>
                  <td>&nbsp;</td>
                  <td> <asp:Button ID="BTN_Login" runat="server" Text="Login" class="submitBTN" 
                                   OnClick="BTN_Login_Click"/> </td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td><asp:Button ID="BTN_Inscription" runat="server" Text="Inscription" class="submitBTN" OnClick="BTN_Inscription_Click"/> </td>
              </tr>
       </table>
    </div>
    </form>
</body>
</html>
