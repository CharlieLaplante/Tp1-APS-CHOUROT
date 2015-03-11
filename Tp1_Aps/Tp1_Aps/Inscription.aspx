<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="Tp1_Aps.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <h2>Ajouter une personne</h2>  
         <hr />      

         <table>
             <tr>
                 <td> <label for="TB_Prenom" class='label'>Prénom:</label>  </td>
                 <td>
                     <asp:TextBox ID="TB_Prenom" name="TB_Prenom" runat="server" CssClass="textbox" 
                         onkeyup = "ConstrainToAlpha(event);"> </asp:TextBox>
                </td>
             </tr>
             <tr>
                 <td> <label for="TB_Nom" class='label'>Nom:</label> </td>
                 <td>
                     <asp:TextBox ID="TB_Nom" name="TB_Nom" runat="server" CssClass="textbox"
                          onkeyup = "ConstrainToAlpha(event);"> </asp:TextBox>
                  </td>
             </tr>
            <tr>
                 <td> <label for="TB_Telephone" class='label'>Téléphone:</label> </td>
                 <td>
                     <asp:TextBox ID="TB_Telephone" name="TB_Telephone" runat="server" CssClass="textbox"
                         onkeydown="Valide_Masque(event);" onkeyup = "Post_Check_Masque(event);" alt="(###) ###-####"></asp:TextBox>
                 </td>
             </tr>
            <tr>
                 <td> <label for="TB_CodePostal" class='label'>Code postal:</label> </td>
                 <td>
                     <asp:TextBox ID="TB_CodePostal" name="TB_CodePostal" runat="server" CssClass="textbox"
                         onkeydown="Valide_Masque(event);" onkeyup = "Post_Check_Masque(event);" alt="C#C #C#"></asp:TextBox>
                 </td>
             </tr>
          </table>
    
    </div>
    </form>
</body>
</html>
