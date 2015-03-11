<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="Tp1_Aps.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="ClientFormUtilities.js"></script>
    <link rel="stylesheet" href="FormStyles.css" />
</head>
<body>
    <form id="form1" runat="server">
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
                    </table>
                </td>
                <td id="AvatarSection">
                                <asp:Image ID="IMG_Avatar" runat="server" CssClass="thumbnail" ImageUrl="~/Images/Anonymous.png" />
                                <hr />
                                <asp:FileUpload ID="FU_Avatar" runat="server" ClientIDMode="Static" onchange="PreLoadImage();" />
                            </td>
            </tr>


            </table>
            
        </div>
       
            
                   
              
           
       
    </form>
</body>
</html>
