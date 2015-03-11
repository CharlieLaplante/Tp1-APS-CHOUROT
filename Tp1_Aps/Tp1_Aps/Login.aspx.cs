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
         PersonnesTable login = new PersonnesTable((string)Application["MainDB"], this);
         login.SelectByID(login.IndexOf(TB_UserName.Text).ToString());
         TB_Password.Text = login.IndexOf(TB_UserName.Text).ToString();
         login.EndQuerySQL();
      }
      protected void BTN_Inscription_Click(object sender, EventArgs e)
      {
         Response.Redirect("Inscription.aspx");
      }
   }
}