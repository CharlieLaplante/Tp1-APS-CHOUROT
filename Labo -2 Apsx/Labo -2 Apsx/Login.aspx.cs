using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Labo__2_Apsx
{
   public partial class Login : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
        
      }
      protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
      {
         USERS users = new USERS((string)Application["MainDB"], this);
         args.IsValid = users.Exist(TB_UserName.Text);
      }
      protected void CV_TB_Password_ServerValidate(object source, ServerValidateEventArgs args)
      {
         USERS users = new USERS((string)Application["MainDB"], this);

         args.IsValid = users.GoodPassword(TB_UserName.Text,TB_Password.Text);
      }  
   }
}