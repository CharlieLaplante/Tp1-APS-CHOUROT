using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class Index : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {

      }
      protected void BTN_Profil_Click(object sender, EventArgs e)
      {
		  Response.Redirect("Profil.aspx");
      }
      protected void BTN_Room_Click(object sender, EventArgs e)
      {

      }
      protected void BTN_LoginsJournal_Click(object sender, EventArgs e)
      {

      }
      protected void BTN_Deconnection_Click(object sender, EventArgs e)
      {
		  Session["Avatar"] = null;
		  Session["FullName"] = null;
		  Session["UserName"] = null;
		  Response.Redirect("Login.aspx");
      }
	  
   }
}