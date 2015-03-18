using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class LoginsJournals : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         ListConnection();
      }
      private void ListConnection()
      {
         PersonnesTable users = new PersonnesTable((String)Application["MainDB"], this);
         users.SelectAllLogins();
         users.MakeGridViewLogins(PN_ListConnexion, "Profil.apsx");
      }
      protected void BTN_Retour_Click(object sender, EventArgs e)
      {
         Response.Redirect("Index.aspx");
      }
   }
}