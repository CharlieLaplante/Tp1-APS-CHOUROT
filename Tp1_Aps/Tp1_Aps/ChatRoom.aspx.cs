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
         Table GridListeChat = new Table();
         TableRow tr = new TableRow();
         while (t.Next())
         {
            tr = new TableRow();
            TableCell td = new TableCell();
            Button bt = new Button();
            bt.Click += new System.EventHandler(this.Btn_Room_Click);
            bt.Text = SQLHelper.FromSql(t.FieldsValues[2]);
            bt.ID = t.ID.ToString();
            td.Controls.Add(bt);
            tr.Cells.Add(td);
            GridListeChat.Rows.Add(tr);  
            
         }
         
         PN_ListeChat.Controls.Clear();

         if (GridListeChat != null)
            PN_ListeChat.Controls.Add(GridListeChat);
         t.EndQuerySQL();
      }

      private void Btn_Room_Click(object sender, EventArgs e)
      {
         MakeChat(((Button)sender).ID);     
      }

      private void MakeChat(string ID)
      {
         Thread_Message ListeMessage = new Thread_Message((string)Application["MainDB"], this);
         ListeMessage.SelectAll(ID);

         Table GridListeMessage = new Table();
         TableRow tr = new TableRow();
         while (ListeMessage.Next())
         {
            tr = new TableRow();
            for (int fieldIndex = 0; fieldIndex < ListeMessage.FieldsValues.Count; fieldIndex++)
            {
               if (ListeMessage.ColumnsVisibility[fieldIndex])
               {
                  TableCell td = new TableCell();               
                     Type type = ListeMessage.FieldsTypes[fieldIndex];
                     if (SQLHelper.IsNumericType(type))
                     {
                        td.Text = ListeMessage.FieldsValues[fieldIndex].ToString();                       
                        td.CssClass = "numeric";
                     }
                     else
                        if (type == typeof(DateTime))
                           td.Text = DateTime.Parse(ListeMessage.FieldsValues[fieldIndex]).ToShortDateString();
                        else
                           td.Text = SQLHelper.FromSql(ListeMessage.FieldsValues[fieldIndex]);               
                  tr.Cells.Add(td);
               }
               GridListeMessage.Rows.Add(tr);
            }
         }         
         PN_ListeMessage.Controls.Clear();

         if (GridListeMessage != null)
            PN_ListeMessage.Controls.Add(GridListeMessage);
         ListeMessage.EndQuerySQL();
               
      }

   }



}
