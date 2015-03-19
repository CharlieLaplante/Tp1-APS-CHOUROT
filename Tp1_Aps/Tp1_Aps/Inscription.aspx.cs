using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tp1_Aps
{
   public partial class Inscription : System.Web.UI.Page
   {
      Random random = new Random();

      protected void Page_Load(object sender, EventArgs e)
      {
         if (!Page.IsPostBack)
         {
            Session["captcha"] = BuildCaptcha();
         }
      }
      public void AddUsers()
      {

         String avatar_ID = "";
         if (FU_Avatar.FileName != "")
         {
            String Avatar_Path = "";

            avatar_ID = Guid.NewGuid().ToString();
            Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
            FU_Avatar.SaveAs(Avatar_Path);
         }

         PersonnesTable personne = new PersonnesTable((String)Application["MainDB"], this);
         personne.FullName = TB_FullName.Text;
         personne.UserName = TB_UserName.Text;
         personne.Password = TB_Password.Text;
         personne.Email = TB_Email.Text;
         personne.Avatar = avatar_ID;
         personne.Insert();
      }
      protected void BTN_Add_Click(object sender, EventArgs e)
      {
         if (Page.IsValid)
         {
            AddUsers();
            Response.Redirect("Login.aspx");
         }
      }

      protected void BTN_Cancel_Click(object sender, EventArgs e)
      {
         Response.Redirect("Login.aspx");
      }
      protected void RegenarateCaptcha_Click(object sender, ImageClickEventArgs e)
      {
         Session["captcha"] = BuildCaptcha();
         // + DateTime.Now.ToString() pour forcer le fureteur recharger le fichier
         IMGCaptcha.ImageUrl = "~/Captcha.png?ID=" + DateTime.Now.ToString();
         PN_Captcha.Update();
      }
      string BuildCaptcha()
      {
         int width = 200;
         int height = 70;
         Bitmap bitmap = new Bitmap(width, height);
         Graphics DC = Graphics.FromImage(bitmap);
         SolidBrush brush = new SolidBrush(RandomColor(0, 127));
         SolidBrush pen = new SolidBrush(RandomColor(172, 255));
         DC.FillRectangle(brush, 0, 0, 200, 100);
         Font font = new Font("Snap ITC", 32, FontStyle.Regular);
         PointF location = new PointF(5f, 5f);
         DC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
         string captcha = Captcha();
         DC.DrawString(captcha, font, pen, location);

         // noise generation
         for (int i = 0; i < 5000; i++)
         {
            bitmap.SetPixel(random.Next(0, width), random.Next(0, height), RandomColor(127, 255));
         }
         bitmap.Save(Server.MapPath("Captcha.png"), ImageFormat.Png);
         return captcha;
      }
      char RandomChar()
      {
         // les lettres comportant des ambiguïtées ne sont pas dans la liste
         // exmple: 0 et O ont été retirés
         string chars = "abcdefghkmnpqrstuvwvxyzABCDEFGHKMNPQRSTUVWXYZ23456789";
         return chars[random.Next(0, chars.Length)];
      }

      Color RandomColor(int min, int max)
      {
         return Color.FromArgb(255, random.Next(min, max), random.Next(min, max), random.Next(min, max));
      }
      string Captcha()
      {
         string captcha = "";

         for (int i = 0; i < 5; i++)
            captcha += RandomChar();
         return captcha;//.ToLower();
      }
      protected void CV_TB_Captcha_ServerValidate(object source, ServerValidateEventArgs args)
      {
		  args.IsValid = (TB_Captcha.Text == (string)Session["captcha"]);
		  if (!args.IsValid)
		  {
			  TB_Captcha.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
		  }
		  else
		  {
			  TB_Captcha.BackColor = System.Drawing.Color.White;
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
	  protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
	  {
		  if (TB_UserName.Text == "")
		  {
			  TB_UserName.BackColor = System.Drawing.Color.FromArgb(0, 255, 200, 200);
			  args.IsValid = false;
		  }
		  else
		  {
			  TB_UserName.BackColor = System.Drawing.Color.White;
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
    protected void CV_TB_Password_Confirm_ServerValidate(object source, ServerValidateEventArgs args)
     {
       if(TB_Password.Text != TB_Password_Confirm.Text)
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
    protected void CV_TB_Email_Confirm_ServerValidate(object source, ServerValidateEventArgs args)
    {
       if (TB_Email.Text != TB_Email_Confirm.Text)
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