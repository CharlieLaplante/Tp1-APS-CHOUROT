using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp1_Aps
{
   public class Logins : SqlExpressUtilities.SqlExpressWrapper
   {
      public long ID { get; set; }
      public long IDLogins { get; set; }
      public long UserID { get; set; }
      public DateTime LoginDate { get; set; }
      public DateTime LogoutDate { get; set; }
      public String IpAddress { get; set; }
      public String FullName { get; set; }
      public String UserName { get; set; }
      public String Password { get; set; }
      public String Email { get; set; }
      public String Avatar { get; set; }


       public Logins(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {            
            SQLTableName = "LOGINS"; 
        }

       public override bool SelectAll(string orderBy = "")
       {
          string sql = "SELECT * FROM " + SQLTableName;
          if (orderBy != "")
             sql += " ORDER BY " + orderBy;
          QuerySQL(sql);
          return reader.HasRows;
       }

      public override void GetValues()
      {
         IDLogins = long.Parse(FieldsValues[0]);
         UserID = long.Parse(FieldsValues[1]);
         LoginDate = DateTime.Parse(FieldsValues[2]);
         LogoutDate = DateTime.Parse(FieldsValues[3]);
         IpAddress = FieldsValues[4];
      }

      public override void Insert()
      {
         InsertRecord(UserID, LoginDate, LogoutDate, IpAddress);
      }

   }
}