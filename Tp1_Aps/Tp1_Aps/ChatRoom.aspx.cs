using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class ChatRoom : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Thread ListeChat = new Thread((string)Application["MainDB"], this);
         ListeChat.SelectTitle();
         ListeChat.MakeGridView(PN_ListeChat, "");
      }    
   }
}