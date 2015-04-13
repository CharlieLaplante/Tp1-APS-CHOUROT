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
         
         
         MakeListeChat(ListeChat);
      }   
      private void MakeListeChat(Thread t)
      {

         Table GridChatRoom = new Table();                 
            while (t.Next())
            {
               TableRow tr = new TableRow();            
               TableCell td = new TableCell();
               Button bt = new Button();    
               bt.Text = SQLHelper.FromSql(t.FieldsValues[2]);               
               td.Controls.Add(bt);
               tr.Cells.Add(td);
               GridChatRoom.Rows.Add(tr);                  
            }
         
         PN_ListeChat.Controls.Clear();

         if (GridChatRoom != null)
            PN_ListeChat.Controls.Add(GridChatRoom);
         t.EndQuerySQL();
         }
   }
 

}
