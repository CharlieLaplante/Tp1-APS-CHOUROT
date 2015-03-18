using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Tp1_Aps
{
	public partial class Profil : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
				LoadForm();
		}
		private void InsertValuesInForm(PersonnesTable User)
		{
			TB_FullName.Text = User.FullName;
			TB_Password.Text = User.Password;
         TB_Password_Confirm.Text = User.Password;
			TB_UserName.Text = User.UserName;
			TB_Email.Text = User.Email;
         TB_Email_Confirm.Text = User.Email;
		}
		private void LoadForm()
		{
			if (Session["FullName"] != null)
			{				
				PersonnesTable personne = new PersonnesTable((String)Application["MainDB"], this);			
				
				if (personne.SelectByUserName((String)Session["UserName"]))
				{ 				
					InsertValuesInForm(personne);
					if (personne.Avatar != "")
						IMG_Avatar.ImageUrl = "Avatars/" + personne.Avatar + ".png"; // +"?" + DateTime.Now.Millisecond.ToString();
					else
						IMG_Avatar.ImageUrl = "Images/Anonymous.png"; // +"?" + DateTime.Now.Millisecond.ToString();
				}
			}
		}
		protected void BTN_Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				UpdateCurrent();
				Response.Redirect("Index.aspx");
			}
		}
		protected void BTN_Cancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("Index.aspx");
		}

		private void GetFormValues(PersonnesTable User)
		{
			User.FullName = TB_FullName.Text;									
			User.Password = TB_Password.Text;						
			User.Email = TB_Email.Text;	 	
		}

		private void DeleteImage(String ID)
		{
			File.Delete(Server.MapPath(@"~\Avatars\") + ID + ".png");
		}  

		private void UpdateCurrent()
		{
			if (Session["FullName"] != null)
			{
				PersonnesTable user = new PersonnesTable((String)Application["MainDB"], this);
				user.SelectByUserName((String)Session["UserName"]);
				GetFormValues(user);

				if (FU_Avatar.FileName != "")
				{
					String Avatar_Path = "";
					String avatar_ID = "";
					DeleteImage(user.Avatar);
					avatar_ID = Guid.NewGuid().ToString();
					Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
					FU_Avatar.SaveAs(Avatar_Path);
					user.Avatar = avatar_ID;
				}
  				
				user.Update();
				Session["FullName"] = user.FullName;
				Session["Avatar"] = user.Avatar;
				}			
		}
		protected void CV_TB_FullName_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (TB_FullName.Text == "")
			{
				TB_FullName.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
				args.IsValid = false;
			}
			else
			{
				TB_FullName.BackColor = System.Drawing.Color.White;
				args.IsValid = true;
			}
		}
		protected void CV_TB_Password_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (TB_Password.Text == "")
			{
				TB_Password.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
				args.IsValid = false;
			}
			else
			{
				TB_Password.BackColor = System.Drawing.Color.White;
				args.IsValid = true;
			}
		}
		protected void CV_TB_Email_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (TB_Email.Text == "")
			{
				TB_Email.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
				args.IsValid = false;
			}
			else
			{
				TB_Email.BackColor = System.Drawing.Color.White;
				args.IsValid = true;
			}
		}
      protected void CV_Password_Confirm_ServerValidate(object source, ServerValidateEventArgs args)
      {
         if (TB_Password_Confirm.Text != TB_Password.Text)
         {
            TB_Password_Confirm.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
            args.IsValid = false;
         }
         else
         {
            TB_Password_Confirm.BackColor = System.Drawing.Color.White;
            args.IsValid = true;
         }
      }
      protected void CV_Email_Confirm_ServerValidate(object source, ServerValidateEventArgs args)
      {
         if (TB_Email_Confirm.Text != TB_Email.Text)
         {
            TB_Email_Confirm.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
            args.IsValid = false;
         }
         else
         {
            TB_Email_Confirm.BackColor = System.Drawing.Color.White;
            args.IsValid = true;
         }
      }
	}
}