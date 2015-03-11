using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class Inscription : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         String action = Request["action"];
         if (action == "add")
         {
            AddUsers();
            Response.Redirect("ListUsers.aspx");
         }
         if (action == "cancel")
         {
            Response.Redirect("ListUsers.aspx");
         }
      }
      public void AddUsers()
      {
         if ((Request["Prenom"] != null) && Request["Prenom"] != "")
         {
            PersonnesTable users = new PersonnesTable((String)Application["MainDB"], this);
            users.FullName = Request["Prenom"];
            users.UserName = Request["Nom"];
            users.Password = Request["Telephone"];
            users.Email = Request["CodePostal"];
         
            String Avatar_Path = "";
            String avatar_ID = "";

            if (FU_Avatar.FileName != "")
            {
               avatar_ID = Guid.NewGuid().ToString();
               Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
               FU_Avatar.SaveAs(Avatar_Path);
            }
            users.Avatar = avatar_ID;
            users.Insert();
         }
      }
   }
}