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
      bool modifier = false;
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!Page.IsPostBack)
         {
            MakeDiscussionListe();
            MakeListeUser();
         }
      }

      protected void BTN_Nouveau_Click(object sender, EventArgs e)
      {
         BTN_Cree_Modifier.Text = "Crée...";
         TB_NewDiscussionTitre.Text = "";
         modifier = false;
         UPan_TBtitreDiscussion.Update();
      }

      protected void BTN_Effacer_Click(object sender, EventArgs e)
      {
         //Supprimer de la BD
         MakeDiscussionListe();
      }

      protected void BTN_Retour_Click(object sender, EventArgs e)
      {
         Response.Redirect("Index.aspx");
      }

      protected void CB_Liste_SelectedIndexChanged(object sender, EventArgs e)
      {
         
      }

      protected void LB_ListDiscussion_SelectedIndexChanged(object sender, EventArgs e)
      {
         BTN_Cree_Modifier.Text = "Modifier...";
         modifier = true;
         TB_NewDiscussionTitre.Text = LB_ListDiscussion.SelectedItem.Text;
         UPan_BTN_Cree_Modifier.Update();
         UPan_TBtitreDiscussion.Update();
      }

      protected void BTN_Cree_Modifier_Click(object sender, EventArgs e)
      {
         if (!modifier)//on crée pcq aucun truc na été selectionné
         {
             Thread thd = new Thread((string)Application["MainDB"], this);
             thd.Insert(CB_Toutlemonde,CB_Liste, Session["UserID"].ToString(),TB_NewDiscussionTitre.Text);
         }
         else //on modifie pcq un truc a été selectionné
         {
             
         }
          //Comme sur le site de Chourot
         Response.Redirect("ChatRoom.aspx");
         //TB_NewDiscussionTitre.Text = "";
         //MakeDiscussionListe();
         //UPan_BTN_Cree_Modifier.Update();
         //UPan_TBtitreDiscussion.Update();
      }

      private void MakeDiscussionListe()
      {
         LB_ListDiscussion.Items.Clear();
         Thread ListeChat = new Thread((string)Application["MainDB"], this);
         ListeChat.SelectByCreator(Session["UserID"].ToString());
         while (ListeChat.Next())
         {
            ListItem nouvelleItem = new ListItem();
            nouvelleItem.Text = ListeChat.Title;
            nouvelleItem.Value = ListeChat.ID.ToString();// value est L'ID en string
            LB_ListDiscussion.Items.Add(nouvelleItem);
         }
         ListeChat.EndQuerySQL();
         UPan_ListDiscussion.Update();
      }

      private void MakeListeUser()
      {
         PersonnesTable ListeUser = new PersonnesTable((string)Application["MainDB"], this);
         ListeUser.SelectAll();

         Table GridListeUser = new Table();
         TableRow tr = new TableRow();
         while (ListeUser.Next())
         {
            if (ListeUser.UserName != Session["UserName"].ToString())
            {
               ListItem NouvelleElement = new ListItem();
               NouvelleElement.Value = ListeUser.ID.ToString();
               NouvelleElement.Text = ListeUser.UserName + " <img class='CB_Image' src='Avatars/" + ListeUser.Avatar + ".png' alt='' />";
               CB_Liste.Items.Add(NouvelleElement);
            }
         }
         ListeUser.EndQuerySQL();
      }
   }
}