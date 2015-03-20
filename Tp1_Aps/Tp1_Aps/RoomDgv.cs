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
      public long UserID { get; set; }
      public DateTime LoginDate { get; set; }
      public DateTime LogoutDate { get; set; }
      public String IpAddress { get; set; }
      public String FullName { get; set; }
      public String UserName { get; set; }
      public String Password { get; set; }
      public String Email { get; set; }
      public String Avatar { get; set; }


       public RoomDgv(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {            
            SQLTableName = "USERS"; 
        }

       public override bool SelectAll(string orderBy = "")
       {
          string sql = "SELECT Users.ID,Logins.UserId,Logins.IPAddress,Users.FullName,Users.UserName,Users.Email,Users.Avatar FROM " + SQLTableName + " inner join Logins on Users.ID = Logins.UserID ";
                  
          if (orderBy != "")
             sql += " ORDER BY " + orderBy;
          QuerySQL(sql);
          return reader.HasRows;
       }

      public override void GetValues()
      {
         ID = long.Parse(this["ID"]);
         UserID = long.Parse(this["UserId"]);
         IpAddress = this["IPAddress"];
         FullName = this["FullName"];
         UserName = this["UserName"];
         Email = this["Email"];
         Avatar = this["Avatar"];
      }

      public override void Insert()
      {
         InsertRecord(UserID, LoginDate, LogoutDate, IpAddress); //Probleme Here en vue !
      }

      public override void InitCellsContentDelegate()
      {
         base.InitCellsContentDelegate();
         SetCellContentDelegate("ID", ContentDelegateID);
         SetCellContentDelegate("UserID", ContentDelegateUserID);
         SetCellContentDelegate("IpAddress", ContentDelegateIPAddress);
         SetCellContentDelegate("FullName", ContentDelegateFullName);
         SetCellContentDelegate("UserName", ContentDelegateUserName);
         SetCellContentDelegate("Email", ContentDelegateEmail);
         SetCellContentDelegate("Avatar", ContentDelegateAvatar);
      }

      public override void InitColumnsSortEnable()
      {
         base.InitColumnsSortEnable();                            //Probleme Here en vue !
         SetColumnSortEnable("ID", false);
      }

      public override void InitColumnsTitles()
      {
         base.InitColumnsTitles();
         SetColumnTitle("ID", "Id");
         SetColumnTitle("UserID", "User Id");
         SetColumnTitle("IpAddress", "Ip Adresse");
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
      System.Web.UI.WebControls.WebControl ContentDelegateUserID()
      {
         Label lbl = new Label();
         lbl.Text = UserID.ToString();
         return lbl;
      }
      System.Web.UI.WebControls.WebControl ContentDelegateLoginDate()
      {
         Label lbl = new Label();
         lbl.Text = LoginDate.ToString();
         return lbl;
      }
      System.Web.UI.WebControls.WebControl ContentDelegateLogoutDate()
      {
         Label lbl = new Label();
         lbl.Text = LogoutDate.ToString();
         return lbl;
      }
      System.Web.UI.WebControls.WebControl ContentDelegateIPAddress()
      {
         Label lbl = new Label();
         lbl.Text = IpAddress;
         return lbl;
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