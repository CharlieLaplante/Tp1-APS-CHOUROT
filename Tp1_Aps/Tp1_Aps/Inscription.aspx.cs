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
       
      }
      public void AddUsers()
      {

         String avatar_ID = "";
         if (FU_Avatar.FileName != "")
         {
            String Avatar_Path = "";

            avatar_ID = Guid.NewGuid().ToString();
            Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
            FU_Avatar.SaveAs(Avatar_Path);
         }

         PersonnesTable personne = new PersonnesTable((String)Application["MainDB"], this);
         personne.FullName = TB_FullName.Text;
         personne.UserName = TB_UserName.Text;
         personne.Password = TB_Password.Text;
         personne.Email = TB_Email.Text;
         personne.Avatar = avatar_ID;
         personne.Insert();
        
      }
      protected void BTN_Add_Click(object sender, EventArgs e)
      {
         if (Page.IsValid)
         {
            AddUsers();
            Response.Redirect("Login.aspx");
         }
      }
      protected void BTN_Cancel_Click(object sender, EventArgs e)
      {
         Response.Redirect("Login.aspx");
      }

   }
}