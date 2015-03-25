﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }
        protected void Session_End(object sender, EventArgs e)
        {
           PersonnesTable users = new PersonnesTable((string)Application["MainDB"], new System.Web.UI.Page());
           users.SelectByUserName(Session["UserName"].ToString());
           users.Connected = "0";
           users.Update(); 
        }

    }
}