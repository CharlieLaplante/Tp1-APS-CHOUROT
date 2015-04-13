using SqlExpressUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class ChatRoom : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Thread ListeChat = new Thread((string)Application["MainDB"], this);
         ListeChat.SelectAll();
         
         Table GridChatRoom =null;
         MakeListeChat(GridChatRoom, ListeChat);
      }   
      private void MakeListeChat(Table Grid,Thread t)
      {                  
            while (t.Next())
            {
               TableRow tr = new TableRow();            
               TableCell td = new TableCell();
                     if (t.CellsContentDelegate[2] != null)
                     {                      
                        td.Controls.Add(t.CellsContentDelegate[2]());
                     }
                     else
                     {
                        Type type = t.FieldsTypes[2];
                        if (SQLHelper.IsNumericType(type))
                        {
                           td.Text = t.FieldsValues[2].ToString();
                           // IMPORTANT! Il faut inclure dans la section style
                           // une classe numeric qui impose l'alignement à droite
                           td.CssClass = "numeric";
                        }
                        else
                        {
                           td.Text = SQLHelper.FromSql(t.FieldsValues[2]);
                        }                        
                     }
                     tr.Cells.Add(td);
                 Grid.Rows.Add(tr);                  
            }
         
         PN_ListeChat.Controls.Clear();

         if (Grid != null)
            PN_ListeChat.Controls.Add(Grid);
         t.EndQuerySQL();
         }
   }
 

}
