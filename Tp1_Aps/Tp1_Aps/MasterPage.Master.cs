using System;
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
		protected void Page_Load(object sender, EventArgs e)
		{				
			LoadAccountAvatar();
			LoadAccountName();
			LoadPageTitle();
         
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

	}
}