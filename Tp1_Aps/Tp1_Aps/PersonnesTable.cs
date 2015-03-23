using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
    public class PersonnesTable : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID { get; set; }
        public String FullName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Avatar { get; set; }
        public String Connected { get; set; }	   
        
       
        public PersonnesTable(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "USERS";
        }
      
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            FullName = FieldsValues[1];
            UserName = FieldsValues[2];
            Password = FieldsValues[3];
            Email = FieldsValues[4];          
            Avatar = FieldsValues[5];
            Connected = FieldsValues[6];            
        } 
        public override void Insert()
        {
            InsertRecord(FullName, UserName, Password, Email, Avatar);
        }
      
        public override void Update()
        {
           UpdateRecord(ID, FullName, UserName, Password, Email, Avatar, Connected);
        }

		public override bool SelectAll(string orderBy = "")
		{
			string sql = "SELECT ID,FullName,Username,Password,Email,Avatar,Connected FROM " + SQLTableName;
			if (orderBy != "")
				sql += " ORDER BY " + orderBy;
			QuerySQL(sql);
			return reader.HasRows;
		}

        public bool SelectByUserName(String UserName)
        {
           string sql = "SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + UserName+"'";
           QuerySQL(sql);
           if (reader.HasRows)
              Next();
           return reader.HasRows;
        }

        public bool Exist(String Username)
        {
           QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + Username + "'");
           // if (reader.HasRows) GetValues();
           return reader.HasRows;
        }

        public bool GoodPassword(String Username, String Password)
        {
           QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + Username + "' AND PASSWORD = '" + Password + "'");
           // if (reader.HasRows) GetValues();
           return reader.HasRows;
        }

        public string GetEmailFromUsers(String Username)
        {
            QuerySQL("SELECT EMAIL FROM " + SQLTableName + " WHERE USERNAME = '" + Username + "'");
           reader.Read();
           return reader.GetString(0);             
        }

        public string GetPasswordFromUsers(String Username)
        {
            QuerySQL("SELECT PASSWORD FROM " + SQLTableName + " WHERE USERNAME = '" + Username + "'");
            reader.Read();
            return reader.GetString(0);
        }

		public override void InitColumnsVisibility()
		{
			base.InitColumnsVisibility();
			SetColumnVisibility("ID", false);
		}
        public override void InitCellsContentDelegate()
        {
            base.InitCellsContentDelegate();
            SetCellContentDelegate("ID", ContentDelegateID);
            SetCellContentDelegate("FullName", ContentDelegateFullName);
            SetCellContentDelegate("UserName", ContentDelegateUserName);
            SetCellContentDelegate("Email", ContentDelegateEmail);
            SetCellContentDelegate("Avatar", ContentDelegateAvatar);
			SetCellContentDelegate("Connected", ContentDelegateConnected);
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
            SetColumnTitle("UserName", "UserName");
            SetColumnTitle("FullName", "Nom complet");
            SetColumnTitle("Email", "Email");
            SetColumnTitle("Avatar", "Avatar");
			SetColumnTitle("Connected", "Connecté");
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