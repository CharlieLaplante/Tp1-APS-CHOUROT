using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{  
			String avatar_ID = "";
			if (Session["Avatar"] != null)
			{
				avatar_ID =Session["Avatar"].ToString();					
			}
			else
			{
				avatar_ID = "Anonymous";
			}
			IMG_Account.ImageUrl = @"~\Avatars\" + avatar_ID + ".png";
			
		}
	}
}