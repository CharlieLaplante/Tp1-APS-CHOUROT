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
         LoadPanel();
		}
      private void LoadPanel()
      {
         MakeListeChat();
         if (Session["IDThread"] != null)
            MakeChat(Session["IDThread"].ToString());
         MakeListeUser();
      }
		private void MakeListeUser()
		{
			PersonnesTable ListeUser = new PersonnesTable((string)Application["MainDB"], this);
			ListeUser.SelectAll();

			Table GridListeUser = new Table();
			TableRow tr = new TableRow();
			while (ListeUser.Next())
			{
				tr = new TableRow();
				for(int i= 0 ; i<=2 ; i++)
				{ 
					TableCell td = new TableCell();	 			
					Label lb = new Label();	
					if(i==0)
					{
						
						Image imgc = new Image();
						if (ListeUser.Connected == "1")
						{
							imgc.ImageUrl = "Images/Connected_True.png";
						}
						else
						{
							imgc.ImageUrl = "Images/Connected_False.png";
						}
						imgc.Width = imgc.Height = 48;
						td.Controls.Add(imgc);
						
				    }
					else if(i==1)
					{
						Image img = new Image();
						if (ListeUser.Avatar != "")
						{
							img.ImageUrl = "Avatars/" + ListeUser.Avatar + ".png";
						}
						else
						{
							img.ImageUrl = "Images/Anonymous.png";
						}
						img.Width = img.Height = 40;
						
						td.Controls.Add(img);
					}
					else if(i==2)
					{
						lb.Text = SQLHelper.FromSql(ListeUser.UserName);
						td.Controls.Add(lb);
					}
					
					
					tr.Cells.Add(td);
				}

				GridListeUser.Rows.Add(tr);

			}

			PN_ListeUser.Controls.Clear();
		

			if (GridListeUser != null)
				PN_ListeUser.Controls.Add(GridListeUser);
			ListeUser.EndQuerySQL();
		}
		protected void Timer1_Tick(object sender, EventArgs e)
		{ 

		}
      protected void BTN_Return_Click(object sender, EventArgs e)
      {
         Response.Redirect("Index.aspx");        
      }

		private void MakeListeChat()
		{
			Thread ListeChat = new Thread((string)Application["MainDB"], this);
			ListeChat.SelectAll();
			Table GridListeChat = new Table();
			TableRow tr = new TableRow();
			while (ListeChat.Next())
			{
				tr = new TableRow();
				TableCell td = new TableCell();
				Button bt = new Button();
				bt.Click += new System.EventHandler(this.Btn_Room_Click);
            
				bt.Text = SQLHelper.FromSql(ListeChat.FieldsValues[2]);
				bt.ID = ListeChat.ID.ToString();
				td.Controls.Add(bt);
				tr.Cells.Add(td);
				GridListeChat.Rows.Add(tr);
         }
			PN_ListeChat.Controls.Clear();

			if (GridListeChat != null)
				PN_ListeChat.Controls.Add(GridListeChat);
			ListeChat.EndQuerySQL();
		}

		private void Btn_Room_Click(object sender, EventArgs e)
		{
         Session["IDThread"] = ((Button)sender).ID;
         LoadPanel();
        
		}
      protected void BTN_Envoyez_Click(object sender, EventArgs e)
      {
         if (Page.IsValid)
         {
            SendMessage();           
         }
      }

      public void SendMessage()
      {
         Thread_Message Message = new Thread_Message((String)Application["MainDB"], this);
         if(Session["IDThread"]!= null)
         {
            Message.Thread_Id = long.Parse(Session["IDThread"].ToString());
            Message.User_Id = (long)Session["UserId"];
            Message.Date_Of_Creation = DateTime.Now;
            Message.Message = TB_ChatBox.Text;
            Message.Insert();     
            MakeChat(Session["IDThread"].ToString());
         }        
      }

      private void DeleteMessage(string ID)
      {
         Thread_Message MessageToDelete = new Thread_Message((String)Application["MainDB"], this);
         if (Session["IDThread"] != null)
         {
            MessageToDelete.SelectAll(Session["IDThread"].ToString());
            MessageToDelete.DeleteRecordByID(ID);
         }
      }

      protected void BTN_Delete_Message_Click(Object sender, EventArgs e)
      {
         ImageButton ib = ((ImageButton)sender);
         string ID = ib.ID.Substring(ib.ID.IndexOf("_") + 1);
         DeleteMessage(ID);
         LoadPanel();
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
            TableCell td = new TableCell();
				for (int fieldIndex = 0; fieldIndex < ListeMessage.FieldsValues.Count; fieldIndex++)
				{
					if (ListeMessage.ColumnsVisibility[fieldIndex])
					{
						 td = new TableCell();
						Type type = ListeMessage.FieldsTypes[fieldIndex];						
							if (type == typeof(DateTime))
                     {
	                     td.Text = DateTime.Parse(ListeMessage.FieldsValues[fieldIndex]).ToShortDateString();                                        
                     }							
							else
                     {
	                        if(fieldIndex==5)
								   {
								      Image img = new Image();
								      if (ListeMessage.Avatar != "")
								      {
								   	   img.ImageUrl = "Avatars/" + ListeMessage.Avatar + ".png";
								      }
								      else
								      {
								   	   img.ImageUrl = "Images/Anonymous.png";
								      }
								      img.Width = img.Height = 40;
								      td.Controls.Add(img);
								   }
						           else  
								   {
								       td.Text = SQLHelper.FromSql(ListeMessage.FieldsValues[fieldIndex]);
								
								   }	
                     }  
                    tr.Cells.Add(td);               
					}			
				} 
            if (long.Parse(ListeMessage.FieldsValues[3]) == long.Parse(Session["UserId"].ToString()))
               {
                  td = new TableCell();
                  ImageButton BTN_Delete_Message = new ImageButton();
                  BTN_Delete_Message.Height = 16;
                  BTN_Delete_Message.Width = 16;
                  BTN_Delete_Message.Click += new ImageClickEventHandler(BTN_Delete_Message_Click);

                  BTN_Delete_Message.ImageUrl = @"~/Images/Delete.png";


                  BTN_Delete_Message.ID = "Delete_" + ListeMessage.ID;
                  td.Controls.Add(BTN_Delete_Message);
                  tr.Cells.Add(td);
               }    
               GridListeMessage.Rows.Add(tr);  
			}
			PN_ListeMessage.Controls.Clear();

			if (GridListeMessage != null)
				PN_ListeMessage.Controls.Add(GridListeMessage);
			ListeMessage.EndQuerySQL();

		}

	} 
}
