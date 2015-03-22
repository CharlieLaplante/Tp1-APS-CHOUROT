using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public class RoomDgv : SqlExpressUtilities.SqlExpressWrapper
   {
      public long ID { get; set; }
      public String FullName { get; set; }
      public String UserName { get; set; }
      public String Password { get; set; }
      public String Email { get; set; }
      public String Avatar { get; set; }
      public String Connected { get; set; }


       public RoomDgv(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {            
            SQLTableName = "USERS"; 
        }

       public override bool SelectAll(string orderBy = "")
       {
           string sql = "SELECT ID, Connected, FullName, UserName, Email, Avatar FROM " + SQLTableName;

          if (orderBy != "")
             sql += " order BY " + orderBy;
          QuerySQL(sql);
          return reader.HasRows;
       }

      public override void GetValues()
      {
         ID = long.Parse(this["ID"]);
         Connected = this["Connected"];
         FullName = this["FullName"];
         UserName = this["UserName"];
         Email = this["Email"];
         Avatar = this["Avatar"];
      }

      public override void Insert()
      {
          InsertRecord(Connected);
      }

      public override void InitCellsContentDelegate()
      {
         base.InitCellsContentDelegate();
         SetCellContentDelegate("ID", ContentDelegateID);
         SetCellContentDelegate("Connected", ContentDelegateConnected);//Connected
         SetCellContentDelegate("FullName", ContentDelegateFullName);
         SetCellContentDelegate("UserName", ContentDelegateUserName);
         SetCellContentDelegate("Email", ContentDelegateEmail);
         SetCellContentDelegate("Avatar", ContentDelegateAvatar);
      }

      public override void InitColumnsSortEnable()
      {
         base.InitColumnsSortEnable();
         SetColumnSortEnable("UserName", false);
      }

      public override void InitColumnsTitles()
      {
         base.InitColumnsTitles();
         SetColumnTitle("ID", "Id");
         SetColumnTitle("Connected", "Connecté");
         SetColumnTitle("UserName", "UserName");
         SetColumnTitle("FullName", "Nom complet");
         SetColumnTitle("Email", "Email");
         SetColumnTitle("Avatar", "Avatar");
      }

      System.Web.UI.WebControls.WebControl ContentDelegateID()
      {
         Label lbl = new Label();
         lbl.Text = ID.ToString();
         return lbl;
      }
      System.Web.UI.WebControls.WebControl ContentDelegateConnected() //Connected
      {
          Image imgc = new Image();
          if (Connected == "1")
          {
              imgc.ImageUrl = "Images/Connected_True.png";
          }
          else
          {
              imgc.ImageUrl = "Images/Connected_False.png";
          }
          imgc.Width = imgc.Height = 48;
          return imgc;
      }
      System.Web.UI.WebControls.WebControl ContentDelegateUserName()
      {
         Label lbl = new Label();
         lbl.Text = UserName;
         return lbl;
      }
      System.Web.UI.WebControls.WebControl ContentDelegateFullName()
      {
         Label lbl = new Label();
         lbl.Text = FullName;
         return lbl;
      }
      System.Web.UI.WebControls.WebControl ContentDelegateEmail()
      {
         Label lbl = new Label();
         lbl.Text = Email;
         return lbl;
      }
      System.Web.UI.WebControls.WebControl ContentDelegateAvatar()
      {
         Image img = new Image();
         if (Avatar !="")
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