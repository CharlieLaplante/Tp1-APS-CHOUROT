using System;
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
        public void Insert(CheckBox CB_TousLeMonde, CheckBoxList CheckBoxList_Items, String CreatorID, String Titre)
        {
            string sqlNouvelleDiscussion = "insert into " + SQLTableName + " (Creator, Title, Date_Of_Creation) values (" + CreatorID + ",'" + Titre + "','" + DateTime.Now + "')";
            NonQuerySQL(sqlNouvelleDiscussion);
            String ThreadID = QueryLastIDInsert("Id", "Id", "Threads");
            
            //Donner l'acces au créateur
            NonQuerySQL("insert into " + SQLTableName + "_Access (Thread_ID, User_Id) Values (" + ThreadID + "," +CreatorID+ ")");

            if (CB_TousLeMonde.Checked) //si le checkbox[0] est check, Tou le monde a acces
            {
                for (int i = 0; i < CheckBoxList_Items.Items.Count; i++)
                {
                    string sqlAcess = "insert into " + SQLTableName + "_Access (Thread_ID, User_Id) Values (" + ThreadID + "," + CheckBoxList_Items.Items[i].Value + ")";
                    NonQuerySQL(sqlAcess);
                }
            }
            else // sinon, on check un par un
            {
                for (int i = 0; i < CheckBoxList_Items.Items.Count; i++)
                {
                    if (CheckBoxList_Items.Items[i].Selected)
                    {
                        string sqlAcess = "insert into " + SQLTableName + "_Access (Thread_Id, User_Id) Values (" + ThreadID + "," + CheckBoxList_Items.Items[i].Value + ")";
                        NonQuerySQL(sqlAcess);
                    }
                }
            }
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