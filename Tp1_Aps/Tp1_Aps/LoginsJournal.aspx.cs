using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
	public partial class LoginsJournal : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
         Logins Login = new Logins((string)Application["MainDB"], this);
         Login.SelectAll();
         Login.MakeGridView(PN_ListeLogins, "");
		}
      protected void BTN_Retour_Click(object sender, EventArgs e)
      {
         Response.Redirect("Index.aspx");
      }

	}
}