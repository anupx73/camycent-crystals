using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crystals.Controllers
{
    class Sales
    {
        public Boolean SalesEntryAppointment(int CustomerId, int AppointmentId, List<int> ServiceIds, double Amount)
        {
            DateTime date = DateTime.Today;
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("CustomerId", CustomerId.ToString());
            d.Add("AppointmentId", AppointmentId.ToString());
            d.Add("Amount", Amount.ToString());
            d.Add("Date", "'" + date.ToString("yyyy-MM-dd") + "'");

            Program.db.insert("Sales", d);

            if (Program.db.error == false)
            {
                //generate invoice
                int SalesId = Program.db.GetLastInsertedID("Sales");
                Invoice frm = new Invoice(SalesId, CustomerId, AppointmentId, Amount, ServiceIds, false);
                frm.ShowDialog();
                //Admin Notify

                Customers cus = new Customers();
                string cusname = cus.GetCustomerName(CustomerId.ToString());

                string msg = "Date: " + date.ToString("yyyy-MM-dd") + "Customer Name: " + cusname + " Amount: " + Amount.ToString();
                AdminNotify.SendEmail("Service Sold", msg);

                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean SalesEntryPackages(int CustomerId, int PackageId, double Amount)
        {
            List<int> Sids = new List<int>();
            DateTime date = DateTime.Today;
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("CustomerId", CustomerId.ToString());
            d.Add("PackageId", PackageId.ToString());
            d.Add("Amount", Amount.ToString());
            d.Add("Date", "'" + date.ToString("yyyy-MM-dd") + "'");

            Program.db.insert("Sales", d);

            if (Program.db.error == false)
            {
                int SalesId = Program.db.GetLastInsertedID("Sales");
                //generate invoice

                List<int> ss = new List<int>();
                Invoice frm = new Invoice(SalesId, CustomerId, PackageId, Amount, ss, true);
                frm.ShowDialog();
                //Admin Notify
                Customers cus = new Customers();

                string cusname = cus.GetCustomerName(CustomerId.ToString());

                string msg = "Date: " + date.ToString("yyyy-MM-dd") + "Customer Name: " + cusname + " Amount: " + Amount.ToString();
                AdminNotify.SendEmail("Package Sold", msg);



                return true;
            }
            else
            {
                return false;
            }
        }

        public SqlDataReader GetSalesByDate(DateTime date)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Date", "'" + date.ToString("yyyy-MM-dd") + "'");
            SqlDataReader reader = Program.db.get_where_custom_desc("Sales", d);
            return reader;
        }

        public double GetSalesByMonth(DateTime date)
        {
            string month = date.ToString("MM");

            //Get All Sales For that Therapists

            SqlDataReader reader = Program.db.get("Sales");

            double TotalSales = 0;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Get the Sales Data
                    DateTime sdate = Convert.ToDateTime(reader["Date"]);
                    string sm = sdate.ToString("MM");

                    if (month == sm)
                    {
                        TotalSales = TotalSales + Convert.ToDouble(reader["Amount"]);
                    }

                }


            }
            reader.Close();
            return TotalSales;

        }

        public Boolean SetInvoicePath(string SalesId, string Path)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("InvoicePath", "'" + Path + "'");
            string where = " where Id= " + SalesId;
            Boolean success = Program.db.update("Sales", d, where);
            if (success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetSalesId(string CustomerId)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("CustomerId", CustomerId);
            SqlDataReader reader = Program.db.get_where_custom("Sales", d);
            if (reader.HasRows)
            {
                reader.Read();
                string SalesId = reader["Id"].ToString();
                return SalesId;
            }
            else
            {
                return null;
            }
        }

        public bool delete(int salesid)
        {
            bool success = false;
            success = Program.db.delete("Sales", salesid);
            if (success)
            {
                return true;
            }
            return false;
        }

        public Boolean SetDiscount(string SalesId, double DiscountVal)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Discount", DiscountVal.ToString());
            Boolean success = Program.db.update("Sales", d, " where Id=" + SalesId);
            if (success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetInvoicePath(string SalesId)
        {

            SqlDataReader reader = Program.db.get_where("Sales", SalesId);
            if (reader.HasRows)
            {
                reader.Read();
                string InvoicePath = reader["InvoicePath"].ToString();
                return InvoicePath;
            }
            else
            {
                return null;
            }

        }
    }
}
