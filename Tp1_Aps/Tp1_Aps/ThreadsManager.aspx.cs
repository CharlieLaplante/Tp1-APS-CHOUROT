using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
   public partial class ThreadsManager : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         
      }

      protected void BTN_Nouveau_Click(object sender, EventArgs e)
      {
         //inserer dans La BD
         if (TB_NewDiscussionTitre.Text != "") // Ajouter si l'insertion de la BD est fait
         {
            ListItem nouvelleitem = new ListItem(TB_NewDiscussionTitre.Text,"0");
            LB_ListDiscussion.Items.Add(nouvelleitem);
            TB_NewDiscussionTitre.Text = null;

            CB_Liste.Items.Add(nouvelleitem);
         }
      }

      protected void BTN_Modifier_Click(object sender, EventArgs e)
      {

      }

      protected void BTN_Effacer_Click(object sender, EventArgs e)
      {
         LB_ListDiscussion.Items.Remove(LB_ListDiscussion.SelectedItem);         
      }

      protected void BTN_Retour_Click(object sender, EventArgs e)
      {
         Response.Redirect("Index.aspx");
      }

      protected void CB_Liste_SelectedIndexChanged(object sender, EventArgs e)
      {

      }
   }
}