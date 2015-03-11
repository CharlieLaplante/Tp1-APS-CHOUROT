using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labo__2_Apsx
{
   public class USERS : SqlExpressUtilities.SqlExpressWrapper
   {
      public long ID { get; set; }
      public String UserName { get; set; }
      public String Password { get; set; }
      public String FullName { get; set; }
      public USERS(String connexionString, System.Web.UI.Page Page)
         : base(connexionString, Page)
      {
         SQLTableName = "USERS";
      }
      public override void GetValues()
      {
         ID = long.Parse(FieldsValues[0]);
         UserName = FieldsValues[1];
         Password = FieldsValues[2];
         FullName = FieldsValues[3];
      }
      public override void Insert()
      {
         InsertRecord(UserName, Password, FullName);
      }
      public override void Update()
      {
         UpdateRecord(ID, UserName, Password, FullName);
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

   }

}