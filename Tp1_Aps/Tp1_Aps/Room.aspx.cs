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
         PersonnesTable personnesTable = new PersonnesTable((string)Application["MainDB"], this);
         personnesTable.SelectAll();
         personnesTable.MakeGridView(PN_GridView, "");
         // Pas besoin d'appeler personnesTable.EndQuerySql car c'est déjà fait dans personnesTable.MakeGridView(...)
      }
   }
}