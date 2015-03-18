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
        public long IDLogins { get; set; }
        public long UserID { get; set; }
        public String FullName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Avatar { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
        public String IpAddress { get; set; }
        
       
        public PersonnesTable(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableUsers = "USERS";
            SQLTableLogins = "LOGINS"; 
        }
      
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            FullName = FieldsValues[1];
            UserName = FieldsValues[2];
            Password = FieldsValues[3];
            Email = FieldsValues[4];          
            Avatar = FieldsValues[5]; 
        }
        public override void GetValuesLogins()
        {
           IDLogins = long.Parse(FieldsValues[0]);
           UserID = ID;
           LoginDate = DateTime.Parse(FieldsValues[2]);
           LogoutDate =DateTime.Parse(FieldsValues[3]);
           IpAddress = FieldsValues[4];
        }
        public override void InsertUser()
        {
            InsertRecordUser(FullName, UserName, Password, Email, Avatar);
        }
        public override void InsertLogin()
        {
           InsertRecordLogins(IDLogins,ID,LoginDate,LogoutDate,IpAddress);
        }
        public override void Update()
        {
           UpdateRecord(ID, FullName, UserName, Password, Email, Avatar);
        }
        public bool Exist(String Username)
        {
           QuerySQL("SELECT * FROM " + SQLTableUsers + " WHERE USERNAME = '" + Username + "'");
           // if (reader.HasRows) GetValues();
           return reader.HasRows;
        }

        public bool GoodPassword(String Username, String Password)
        {
           QuerySQL("SELECT * FROM " + SQLTableUsers + " WHERE USERNAME = '" + Username + "' AND PASSWORD = '" + Password + "'");
           // if (reader.HasRows) GetValues();
           return reader.HasRows;
        }

        public string GetEmailFromUsers(String Username)
        {
            QuerySQL("SELECT EMAIL FROM " + SQLTableUsers + " WHERE USERNAME = '" + Username + "'");
           reader.Read();
           return reader.GetString(0);             
        }

        public string GetPasswordFromUsers(String Username)
        {
            QuerySQL("SELECT PASSWORD FROM " + SQLTableUsers + " WHERE USERNAME = '" + Username + "'");
            reader.Read();
            return reader.GetString(0);
        } 

    }
}