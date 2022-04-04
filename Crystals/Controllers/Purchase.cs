using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Crystals.Controllers
{
    public class Purchase
    {
        public int AddPurchase(int PurchaseId, int CatagoryId, int ItemId, string vendor, DateTime Date, double Unit, int Quantity, double UnitPrice, double TotalPrice )
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("Date", "'"+Date.ToString("yyyy-MM-dd")+"'");
            data.Add("CatagoryId", CatagoryId.ToString());
            data.Add("ItemId", ItemId.ToString());
            data.Add("Vendor", "'"+vendor+"'");
            data.Add("Unit", Unit.ToString());
            data.Add("UnitPrice", UnitPrice.ToString());
            data.Add("Quantity", Quantity.ToString());
            data.Add("TotalPrice", TotalPrice.ToString());

            if(PurchaseId == -1)
            {
                Program.db.insert("Purchases", data);
            }
            else
            {
                string where = " where Id =" + PurchaseId;
                Program.db.update("Purchases", data, where);
            }
            
            if(!Program.db.error)
            {
                return Program.db.GetLastInsertedID("Purchases");
            }
            else
            {
                return -1;
            }
           
        }

        public SqlDataReader GetPurchase(string PurchaseId)
        {
            SqlDataReader reader = Program.db.get_where("Purchases", PurchaseId);
            return reader;
        }

        public SqlDataReader GetPurchases()
        {
            SqlDataReader reader = Program.db.get_desc("Purchases");
            return reader;
        }
    }
}
