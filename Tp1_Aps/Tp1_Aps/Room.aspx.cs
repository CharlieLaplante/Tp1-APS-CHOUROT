using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class Room : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          PersonnesTable user = new PersonnesTable((string)Application["MainDB"], this);
         user.SelectAll();
		 user.MakeGridView(PN_ListerUtilisateur, "");
      }
      protected void BTN_Retour_Click(object sender, EventArgs e)
      {
         Response.Redirect("Index.aspx");
      }
       protected void Timer1_Tick(object sender, EventArgs e)
      {
          PersonnesTable user = new PersonnesTable((string)Application["MainDB"], this);
          user.SelectAll();
          user.MakeGridView(PN_ListerUtilisateur, "");
      }
   }
}