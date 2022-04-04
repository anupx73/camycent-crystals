using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Crystals.Controllers
{
    public class Items
    {
        public int AddItem(int ItemId, int CatagoryId, string Name, string MediumStockAlert, string LowStockAlert, bool ReUseable)
        {
            int iReUseable = ReUseable ? 1 : 0;
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("CatagoryId", CatagoryId.ToString());
            d.Add("Name", "'" + Name + "'");
            d.Add("MediumStockAlert", MediumStockAlert);
            d.Add("LowStockAlert", LowStockAlert);
            d.Add("ReUseable", iReUseable.ToString());

            if(ItemId == -1)
            {
                Program.db.insert("Items", d);
            }
            else
            {
                string where = " where Id=" + ItemId;
                Program.db.update("Items", d, where);
            }

            if(Program.db.error == false)
            {
                return Program.db.GetLastInsertedID("Items");
            }
            else
            {
                return -1;
            }
        }

        public Dictionary<int, string> GetItemDropDown()
        {
            SqlDataReader reader = Program.db.get("Items");
            Dictionary<int, string> items = new Dictionary<int, string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Id = Convert.ToInt32(reader["Id"]);
                    string Name = reader["Name"].ToString();
                    items.Add(Id, Name);
                }
            }

            reader.Close();

            return items;
        }

        public Dictionary<int, string> GetItemDropDown(string CatagoryId)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("CatagoryId", CatagoryId);
            SqlDataReader reader = Program.db.get_where_custom_desc("Items", d);

            Dictionary<int, string> items = new Dictionary<int, string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Id = Convert.ToInt32(reader["Id"]);
                    string Name = reader["Name"].ToString();
                    items.Add(Id, Name);
                }
            }

            reader.Close();
            return items;
        }

        public SqlDataReader GetItem(string ItemId)
        {
            SqlDataReader reader = Program.db.get_where("Items", ItemId);
            return reader;
        }

        public string GetUnit(string ItemId)
        {
            string unit = null;
            SqlDataReader reader = Program.db.get_where("Items", ItemId);
            if(reader.HasRows)
            {
                reader.Read();
                string CatagoryId = reader["CatagoryId"].ToString();
                Catagory cat = new Catagory();
                unit = cat.GetUnit(CatagoryId);
            }
            return unit;
        }

        public string GetItemName(string ItemId)
        {
            string ItemName = null;
            SqlDataReader reader = Program.db.get_where("Items", ItemId);
            if (reader.HasRows)
            {
                reader.Read();
                ItemName = reader["Name"].ToString();
            }
            return ItemName;
        }
    }
}
