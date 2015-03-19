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
         Response.Redirect("LoginsJournal.aspx");
      }
      public string GetUserIP()
      {
         string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
         if (!string.IsNullOrEmpty(ipList))
            return ipList.Split(',')[0];
         string ipAddress = Request.ServerVariables["REMOTE_ADDR"];
         if (ipAddress == "::1") // local host
            ipAddress = "127.0.0.1";
         return ipAddress;
      }
      protected void BTN_Deconnection_Click(object sender, EventArgs e)
      {

        Logins Login = new Logins((String)Application["MainDB"], this);
        Login.UserID = long.Parse(Session["UserId"].ToString());
        Login.IpAddress = GetUserIP();
        Login.LoginDate = DateTime.Parse(Session["StartTime"].ToString());
        Login.LogoutDate = DateTime.Now;
        Login.Insert();

		  Response.Redirect("Login.aspx");
       
      }
	  

   }
}