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

        }

        protected void BTN_Nouveau_Click(object sender, EventArgs e)
        {
            BTN_Cree_Modifier.Text = "Crée...";
            TB_NewDiscussionTitre.Text = null;
            modifier = false;
        }

        protected void BTN_Effacer_Click(object sender, EventArgs e)
        {
            LB_ListDiscussion.Items.Remove(LB_ListDiscussion.SelectedItem);
            modifier = false;
            //Supprimer de la BD
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
            //if (LB_ListDiscussion.SelectedItem != null)
            //{
                BTN_Cree_Modifier.Text = "Modifier...";
                modifier = true;
            //}
        }

        protected void BTN_Cree_Modifier_Click(object sender, EventArgs e)
        {
            if (!modifier)//on crée pcq aucun truc na été selectionné
            {
                ListItem nouvelle_item = new ListItem(TB_NewDiscussionTitre.Text, "0");
                LB_ListDiscussion.Items.Add(nouvelle_item);
            }
            else //on modifie pcq un truc a été selectionné
            {
                TB_NewDiscussionTitre.Text = LB_ListDiscussion.SelectedItem.Text;
                
                //inserer dans La BD
                //if (TB_NewDiscussionTitre.Text != "") // Ajouter si l'insertion de la BD est fait
                //{

                //   TB_NewDiscussionTitre.Text = null;

                //   CB_Liste.Items.Add(nouvelleitem);
                //}
            }
        }
    }
}