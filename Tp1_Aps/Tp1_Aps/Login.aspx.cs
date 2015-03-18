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
        String SenderEmail = "pouletgrill@gmail.com";
        String SenderPassword = (((int)'@')*(2*(20*((int)'s')+((int)'c'))*((int)'A'))+((int)'x')+((int)'z')+((int)'j')+((int)'d')).ToString();
        String SenderName = "WebService";
        protected void Page_Load(object sender, EventArgs e)
        {
			Session["Avatar"] = null;
			Session["FullName"] = null;
			Session["UserName"] = null;
         Session["StartTime"] = null;
        }		 

        protected void BTN_Login_Click(object sender, EventArgs e)
      {

         PersonnesTable users = new PersonnesTable((string)Application["MainDB"], this);
         if (users.Exist(TB_UserName.Text))
         {
            if (users.GoodPassword(TB_UserName.Text, TB_Password.Text))
            {
				users.SelectByUserName(TB_UserName.Text);
				Session["Avatar"] = users.Avatar;
				Session["FullName"] = users.FullName;
				Session["UserName"] = users.UserName;
            Session["StartTime"] = DateTime.Now;
            Session["UserId"] = users.ID;

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

        protected void BTN_Mot_De_Passe_Email_Click(object sender, EventArgs e)
        {
            PersonnesTable users = new PersonnesTable((string)Application["MainDB"], this);
            if (users.Exist(TB_UserName.Text))
            {
                try
                {
                    EnvoyerPasswordEmail(users.GetEmailFromUsers(TB_UserName.Text), users);
                }
                catch (Exception ex)
                {
                    MessageBox(ex.Message);
                }
            }
            else
            {
                MessageBox("Nom d'utilisateur incorrect");
                TB_UserName.Text = "";
            }
        }
        private void MessageBox(string message)
        {
            string script = "alert(\"" + message + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);
        }

        private void EnvoyerPasswordEmail(String Adresse, PersonnesTable connexion)
        {
            EMail eMail = new EMail();

            // Vous devez avoir un compte gmail
            eMail.From = SenderEmail;
            eMail.Password = SenderPassword;
            eMail.SenderName = SenderName;

            eMail.Host = "smtp.gmail.com";
            eMail.HostPort = 587;
            eMail.SSLSecurity = true;

            eMail.To = connexion.GetEmailFromUsers(TB_UserName.Text);
            eMail.Subject = "Mot de passe oublié.. Oups";
            eMail.Body = "Voici le mot de passe pour " + TB_UserName.Text +
                " <hr/><h1> [ " + connexion.GetPasswordFromUsers(TB_UserName.Text) + " ]<h1/>";

            if (eMail.Send())
            {
                MessageBox("Message Envoyé avec succès");
                TB_UserName.Text = "";
            }
            else
            {
                MessageBox("Une érreur est survenue lors de l'envoie du Email..");
            }
        }
    }
}

