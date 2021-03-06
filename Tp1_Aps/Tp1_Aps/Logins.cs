﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public class Logins : SqlExpressUtilities.SqlExpressWrapper
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
      public bool Admin = false;


      public Logins(String connexionString, System.Web.UI.Page Page)
         : base(connexionString, Page)
      {
         SQLTableName = "LOGINS";
      }

      public override bool SelectAll(string orderBy = "")
      {
         string sql = "SELECT Logins.ID,UserId,LoginDate,LogoutDate,IPAddress,FullName,UserName,Email,Avatar FROM " + SQLTableName + " inner join Users on Users.ID = Logins.UserID ";
         if (!Admin)
         {
            sql += " where UserName = '" + UserName + "'";
         }

         if (orderBy != "")
            sql += " ORDER BY " + orderBy;
         QuerySQL(sql);
         return reader.HasRows;
      }

      public override void GetValues()
      {
         ID = long.Parse(this["ID"]);
         UserID = long.Parse(this["UserId"]);
         LoginDate = DateTime.Parse(this["LoginDate"]);
         LogoutDate = DateTime.Parse(this["LogoutDate"]);
         IpAddress = this["IPAddress"];
         FullName = this["FullName"];
         UserName = this["UserName"];
         Email = this["Email"];
         Avatar = this["Avatar"];
      }

      public override void Insert()
      {
         InsertRecord(UserID, LoginDate, LogoutDate, IpAddress);
      }

      public override void InitCellsContentDelegate()
      {
         base.InitCellsContentDelegate();
         SetCellContentDelegate("ID", ContentDelegateID);
         SetCellContentDelegate("UserID", ContentDelegateUserID);
         SetCellContentDelegate("LoginDate", ContentDelegateLoginDate);
         SetCellContentDelegate("LogoutDate", ContentDelegateLogoutDate);
         SetCellContentDelegate("IpAddress", ContentDelegateIPAddress);
         SetCellContentDelegate("FullName", ContentDelegateFullName);
         SetCellContentDelegate("UserName", ContentDelegateUserName);
         SetCellContentDelegate("Email", ContentDelegateEmail);
         SetCellContentDelegate("Avatar", ContentDelegateAvatar);
      }

      public override void InitColumnsSortEnable()
      {
         base.InitColumnsSortEnable();
         SetColumnSortEnable("ID", false);
      }

      public override void InitColumnsTitles()
      {
         base.InitColumnsTitles();
         SetColumnTitle("ID", "Id");
         SetColumnTitle("UserID", "User Id");
         SetColumnTitle("LoginDate", "Login date");
         SetColumnTitle("LogoutDate", "Logout date");
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