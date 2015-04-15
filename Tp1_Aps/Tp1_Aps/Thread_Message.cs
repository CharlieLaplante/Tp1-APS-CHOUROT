using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public class Thread_Message : SqlExpressUtilities.SqlExpressWrapper
   {
      public long ID { get; set; }
      public long Thread_Id { get; set; }
      public long  User_Id { get; set; }
      public DateTime Date_Of_Creation { get; set; }
      public string Message { get; set; }
      public string Avatar { get; set; }
      public string UserName { get; set; }


       public Thread_Message(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "Threads_Messages";           
        }
       public override void InitColumnsVisibility()
       {
          base.InitColumnsVisibility();
          SetColumnVisibility(0, false);
          SetColumnVisibility(1, false);
          SetColumnVisibility(2, false);  
       }

       public override void GetValues()
       {

          ID = long.Parse(FieldsValues[0]);
          Thread_Id = long.Parse(FieldsValues[1]);               
          User_Id = long.Parse(FieldsValues[2]);          
          Date_Of_Creation = DateTime.Parse(FieldsValues[3]);
          Message = FieldsValues[4];
          if(reader.FieldCount !=5)
          {
             Avatar = this["Avatar"];
             UserName = this["UserName"];

          }
      
       }
       public override bool SelectAll(string Thread_id)
       {
          string sql = "SELECT Threads_Messages.Id,Thread_Id,User_Id,Date_Of_Creation,Message,Avatar,UserName FROM " + SQLTableName + " inner join Users on Users.ID = Threads_Messages.User_ID WHERE Thread_ID = '" + Thread_id + "' order by Date_Of_Creation desc "; 
          QuerySQL(sql);
          return reader.HasRows;
       }
       public override void Insert()
       {
          InsertRecord(Thread_Id,User_Id,Date_Of_Creation, Message);
       }

       public override void Update()
       {
          UpdateRecord(ID,Thread_Id,User_Id,Date_Of_Creation,Message);

       }
	   public override void InitCellsContentDelegate()
	   {
		   base.InitCellsContentDelegate();
		   SetCellContentDelegate("UserName", ContentDelegateUserName);			  
		   SetCellContentDelegate("Avatar", ContentDelegateAvatar);
	   }
	   System.Web.UI.WebControls.WebControl ContentDelegateUserName()
	   {
		   Label lbl = new Label();
		   lbl.Text = UserName;
		   return lbl;
	   }
	   System.Web.UI.WebControls.WebControl ContentDelegateAvatar()
	   {
		   Image img = new Image();

		   if (Avatar != "")
		   {
			   img.ImageUrl = "Avatars/" + Avatar + ".png";
		   }
		   else
		   {
			   img.ImageUrl = "Images/Anonymous.png";
		   }
		   img.Width = img.Height = 40;
		   return img;
	   }


   }

}