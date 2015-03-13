using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class Login : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {

      }
      protected void Session_Start(object sender, EventArgs e)
      {
         Session["StartTime"] = DateTime.Now;
         
      }
      protected void Session_End(object sender, EventArgs e)
      {
        
      }
      protected void BTN_Login_Click(object sender, EventArgs e)
      {

         PersonnesTable users = new PersonnesTable((string)Application["MainDB"], this);
         if (users.Exist(TB_UserName.Text))
         {
            if (users.GoodPassword(TB_UserName.Text, TB_Password.Text))
            {  
               users.SelectByID()
               Response.Redirect("Index.aspx");
            }
            else
            {
               TB_Password.Text = "";
            }
         }
      }

      protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
      {
         PersonnesTable users = new PersonnesTable((string)Application["MainDB"], this);
         args.IsValid = users.Exist(TB_UserName.Text);
      }
      protected void CV_TB_Password_ServerValidate(object source, ServerValidateEventArgs args)
      {
         PersonnesTable users = new PersonnesTable((string)Application["MainDB"], this);

         args.IsValid = users.GoodPassword(TB_UserName.Text, TB_Password.Text);
      }

      protected void BTN_Inscription_Click(object sender, EventArgs e)
      {
         Response.Redirect("Inscription.aspx");
      }
   }
}