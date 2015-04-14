using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Tp1_Aps;

namespace LABO_1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string DB_Path = Server.MapPath(@"~\App_Data\MainDB.mdf");
            // Toutes les Pages (WebForm) pourront accéder à la propriété Application["MaindDB"]
            Application["MainDB"] = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DB_Path + "';Integrated Security=False";      
        }
        protected void Session_Start(object sender, EventArgs e)
        {
           Session["Connecte"] = "1";
           Session.Timeout = 2;
           Session["IpAdresse"] = GetUserIP();
        }
        protected void Session_End(object sender, EventArgs e)
        {          
              if(Session["Page"]!=null)
              {
                 Logins Login = new Logins((String)Application["MainDB"], (System.Web.UI.Page)Session["Page"]);
                 Login.UserID = long.Parse(Session["UserId"].ToString());
                 Login.IpAddress = Session["IpAdresse"].ToString();
                 Login.LoginDate = DateTime.Parse(Session["StartTime"].ToString());
                 Login.LogoutDate = DateTime.Now;
                 Login.Insert();

                 PersonnesTable users = new PersonnesTable((string)Application["MainDB"], (System.Web.UI.Page)Session["Page"]);
                 users.SelectByUserName(Session["UserName"].ToString());
                 users.Connected = "0";
                 users.Update();                 
              }        
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

    }
}