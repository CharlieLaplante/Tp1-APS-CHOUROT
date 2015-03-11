using Labo__2_Apsx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class Login : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {

      }
      protected void BTN_Login_Click(object sender, EventArgs e)
      {
         USERS users = new USERS((string)Application["MainDB"], this);
         if (users.Exist(TB_UserName.Text))
         {
            if (users.GoodPassword(TB_UserName.Text,TB_Password.Text))
            {
               Response.Redirect("Inscription.aspx");
            }
            else
            {
               TB_UserName.Text = "Mauvais mot de passe";
            }
         }
         else
         {
            TB_UserName.Text = "Username inexistent";
         }
      }
      protected void BTN_Inscription_Click(object sender, EventArgs e)
      {
         Response.Redirect("Inscription.aspx");
      }
   }
}