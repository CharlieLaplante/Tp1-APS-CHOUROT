﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Tp1_Aps
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
      int TickTimout = 0;//1 minutes
		protected void Page_Load(object sender, EventArgs e)
		{				
			LoadAccountAvatar();
			LoadAccountName();
			LoadPageTitle();
         TickTimout = 0;
         //if (Session["FullName"] == null)
         //{
         //   Response.Redirect("Login.aspx");
         //}
      }
		protected void LoadPageTitle()
		{
			Label_PageTitle.Text = Path.GetFileName(Request.PhysicalPath).Substring(0,Path.GetFileName(Request.PhysicalPath).Length - 5);
		}
		protected void LoadAccountAvatar()
		{
			String avatar_ID = "";
			if (Session["Avatar"] != null)
			{
				avatar_ID = Session["Avatar"].ToString();
			}
			else
			{
				avatar_ID = "Anonymous";
			}
			IMG_Account.ImageUrl = @"~\Avatars\" + avatar_ID + ".png";
		}
		protected void LoadAccountName()
		{
			if (Session["FullName"] != null)
			{
				Label_FullName.Text = Session["FullName"].ToString();
			}
			else
			{
				Label_FullName.Text = "";
			}   			
		}

      protected void Timer2_Tick(object sender, EventArgs e)
      {
         //TickTimout+=10;
         //if (TickTimout >=10/*60sec/1min*/)
         //{
            TickTimout = 0;
            Session.Abandon();
            Response.Redirect("Login.aspx");
         //}
      }

	}
}