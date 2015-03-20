using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class Room : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         RoomDgv roomDgv = new RoomDgv((string)Application["MainDB"], this);
         roomDgv.SelectAll();
         roomDgv.MakeGridView(PN_GridView, "");
      }
      protected void BTN_Retour_Click(object sender, EventArgs e)
      {
         Response.Redirect("Index.aspx");
      }
   }
}