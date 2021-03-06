﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Tp1_Aps
{
    public class Thread : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID { get; set; }
        public long Creator { get; set; }
        public String Title { get; set; }
        public DateTime Date_Of_Creation { get; set; }

        public Thread(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "Threads";
        }
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            Creator = long.Parse(FieldsValues[1]);
            Title = FieldsValues[2];
            Date_Of_Creation = DateTime.Parse(FieldsValues[3]);
        }

        public override bool SelectAll(string ID = "")
        {

            string sql = "SELECT Threads.ID,Creator,Title,Date_Of_Creation FROM " + SQLTableName;
            if (ID != "")
                sql += " inner join Threads_Access on Threads_Access.Thread_Id = Threads.Id where USER_ID = " + ID;
            QuerySQL(sql);
            return reader.HasRows;
        }

        public bool SelectByCreator(string CreateurID, string orderBy = "")
        {
            string sql = "SELECT ID,Creator,Title,Date_Of_Creation FROM " + SQLTableName +
               " where Creator = " + CreateurID;
            if (orderBy != "")
                sql += " ORDER BY " + orderBy;
            QuerySQL(sql);
            return reader.HasRows;
        }

        public List<string> CheckBoxListSelectByThreadId(string ThreadId)
        {
            string sql = "SELECT User_Id FROM Threads_Access where Thread_Id = " +ThreadId;
            List<string> resultat = QueryCBLISTE(sql);
            return resultat;
        }

        public void Insert(CheckBoxList CheckBoxList_Items, String CreatorID, String Titre)
        {
            string sqlNouvelleDiscussion = "insert into " + SQLTableName + " (Creator, Title, Date_Of_Creation) values (" + CreatorID + ",'" + Titre + "','" + DateTime.Now + "')";
            NonQuerySQL(sqlNouvelleDiscussion);
            String ThreadID = QueryLastIDInsert("Id", "Id", "Threads");

            //Donner l'acces au créateur
            NonQuerySQL("insert into " + SQLTableName + "_Access (Thread_ID, User_Id) Values (" + ThreadID + "," + CreatorID + ")");
            
            for (int i = 0; i < CheckBoxList_Items.Items.Count; i++)
            {
                if (CheckBoxList_Items.Items[i].Selected)
                {
                    string sqlAcess = "insert into " + SQLTableName + "_Access (Thread_Id, User_Id) Values (" + ThreadID + "," + CheckBoxList_Items.Items[i].Value + ")";
                    NonQuerySQL(sqlAcess);
                }
            }
        }

        public void UpdateDiscussion(CheckBoxList CheckBoxList_Items, String CreatorID, String ThreadID, String NouveauTitre)
        {
            //Modification du titre
            NonQuerySQL("update " + SQLTableName + " set Title = '" + NouveauTitre + "' where Id = " + ThreadID);
            //Supression des anciennes personne qui y avait accès
            NonQuerySQL("delete from Threads_Access where Thread_Id = " + ThreadID);
            //Donner l'acces au créateur
            NonQuerySQL("insert into " + SQLTableName + "_Access (Thread_ID, User_Id) Values (" + ThreadID + "," + CreatorID + ")");
            //Donne l'accès a tout ceux qui son Checked dans l'objet CheckBoxList_Items
            for (int i = 0; i < CheckBoxList_Items.Items.Count; i++)
            {
                if (CheckBoxList_Items.Items[i].Selected)
                {
                    string sqlAcess = "insert into " + SQLTableName + "_Access (Thread_Id, User_Id) Values (" + ThreadID + "," + CheckBoxList_Items.Items[i].Value + ")";
                    NonQuerySQL(sqlAcess);
                }
            }
        }

        public void Delete(String ThreadID)
        {
            //Delete la discussion
            NonQuerySQL("delete from " + SQLTableName + " where Id = " + ThreadID);
            //Suppression les personne qui y ont accès
            NonQuerySQL("delete from Threads_Access where Thread_Id = " + ThreadID);
            //Suppression des messages
            NonQuerySQL("delete from Threads_Messages where Thread_Id = " + ThreadID);
        }

        public CheckBoxList LoadCheckBoxItems()
        {
            CheckBoxList NewShit = new CheckBoxList();
            string sqlCheckBoxQuery = "select ";
            return NewShit;
        }

        public void Update()
        {


        }
    }
}