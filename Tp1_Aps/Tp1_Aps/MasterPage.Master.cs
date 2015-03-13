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
            avatar_ID = 
            IMG_Avatar.ImageUrl  = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";             
      }
   }
}