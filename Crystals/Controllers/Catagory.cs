using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace Crystals.Controllers
{
    public class Catagory
    {
        public int AddCatagory(int Id, string Name, string Unit, string MediumStock, string LowStock)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Name", "'" + Name + "'");
            d.Add("Unit", "'" + Unit + "'");
            d.Add("MediumStockAlert", MediumStock);
            d.Add("LowStockAlert", LowStock );

            if (Id == -1)
            {
                //Create a Catagory

                Program.db.insert("Catagory", d);
            }
            else
            {
                string whereClause = " where Id =" + Id;
                Program.db.update("Catagory", d, whereClause);
            }

            if (!Program.db.error)
            {
                return Program.db.GetLastInsertedID("Catagory");
            }
            else
            {
                return -1;
            }
        }

        public string GetCatagoryName(int CatagoryId)
        {
            SqlDataReader reader = Program.db.get_where("Catagory", CatagoryId.ToString());
            if (reader.HasRows)
            {
                reader.Read();
                string Name = reader["Name"].ToString();
                reader.Close();
                return Name;
            }
            else
            {
                return null;
            }
        }

        public int GetMediumStockAlert(int CatagoryId)
        {
            SqlDataReader reader = Program.db.get_where("Catagory", CatagoryId.ToString());
            if (reader.HasRows)
            {
                reader.Read();
                int MedStock = Convert.ToInt32(reader["MediumStockAlert"]);
                reader.Close();
                return MedStock;
            }
            else
            {
                return -1;
            }
        }

        public int GetLowStockAlert(int CatagoryId)
        {
            SqlDataReader reader = Program.db.get_where("Catagory", CatagoryId.ToString());
            if (reader.HasRows)
            {
                reader.Read();
                int LowStock = Convert.ToInt32(reader["LowStockAlert"]);
                reader.Close();
                return LowStock;
            }
            else
            {
                return -1;
            }
        }

        public SqlDataReader GetCatagory(string CatagoryId)
        {
            SqlDataReader reader = Program.db.get_where("Catagory", CatagoryId);
            return reader;
        }

        public string GetUnit(string CatagoryId)
        {
            SqlDataReader reader = Program.db.get_where("Catagory", CatagoryId);
            if (reader.HasRows)
            {
                reader.Read();
                string Unit = reader["Unit"].ToString();
                reader.Close();
                return Unit;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader GetAllCatagory()
        {
            SqlDataReader reader = Program.db.get("Catagory");
            return reader;
        }

        public Dictionary<int, string> GetCatagoryDropDown()
        {
            SqlDataReader reader = Program.db.get_desc("Catagory");
            Dictionary<int, string> cats = new Dictionary<int, string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int Id = Convert.ToInt32(reader["Id"]);
                    string Name = reader["Name"].ToString();
                    cats.Add(Id, Name);
                }
            }

            reader.Close();

            return cats;
        }



    }
}
