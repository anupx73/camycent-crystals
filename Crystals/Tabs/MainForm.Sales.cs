using Crystals.Controllers;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crystals
{
    partial class MainForm
    {
        public static int salesrow = 0;

        private void LoadSales()// implement sales load here
        {
            double amount, total = 0, totalwithtax = 0, tax = 0, monthtax = 0, totalmonthtax = 0;
            // string discount=null;
            Sales s = new Sales();
            SqlDataReader reader = s.GetSalesByDate(DateTime.Today);
            double cashsale = 0.0, cardsale = 0.0, amt = 0.0, discount = 0.0;
            string packageId = null;
            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    packageId = reader["PackageId"].ToString();
                    if (string.IsNullOrEmpty(packageId) == false)
                    {
                        discount = Convert.ToDouble(reader["Discount"]);
                        amount = Convert.ToDouble(reader["amount"]);

                        total = total + (amount - discount);

                        string paymentmode = reader["PaymentMode"].ToString();
                        if (paymentmode == "Cash")
                        {
                            amt = Convert.ToDouble(reader["Amount"]);
                            cashsale = cashsale + amt - discount;
                        }
                        else
                        {
                            amt = Convert.ToDouble(reader["Amount"]);
                            cardsale = cardsale + amt - discount;
                        }
                    }
                }
            }

            salLabelDayWTax.Text = "\u20B9 " + total.ToString();
            double MonthSales = s.GetSalesByMonth(DateTime.Today);
            salLabelMonthWTax.Text = "\u20B9 " + MonthSales.ToString();
            tax = total * .145;
            totalwithtax = total + tax;
            monthtax = MonthSales * .145;
            totalmonthtax = MonthSales + monthtax;
            salLabelMonthTax.Text = totalmonthtax.ToString();
            salLabelDayTax.Text = totalwithtax.ToString();
            salLabelTotalCash.Text = cashsale.ToString();
            salLabelTotalCard.Text = cardsale.ToString();
            reader.Close();

            populateSalesComm();


            populate_Sales();

        }

        public void populate_Sales()
        {
            saleInfoGrid.Rows.Clear();
            string cussId;
            SqlDataReader reader = Program.db.get_desc("Sales");;
            //if (saleRadioShowAll.Checked)
            //{
            //    reader = Program.db.get_desc("Sales");
            //}
            //else
            //{
            //    Sales s = new Sales();
            //    reader = s.GetSalesByDate(saleDTFilter.Value);
            //}

            if (reader.HasRows)
            {
                saleInfoGrid.AllowUserToAddRows = true;
                int rows = 0;
                while (reader.Read())
                {
                    saleInfoGrid.Rows.Add();
                    cussId = reader["CustomerId"].ToString();
                    SqlDataReader reader1 = Program.db.get_where("Customers", cussId);

                    DateTime date = Convert.ToDateTime(reader["Date"]);

                    saleInfoGrid.Rows[rows].Cells[0].Value = date.ToString("yyyy-MM-dd");


                    while (reader1.Read())
                    {
                        saleInfoGrid.Rows[rows].Cells[1].Value = reader1["Name"];
                    }

                    saleInfoGrid.Rows[rows].Cells[2].Value = reader["Amount"];
                    double sales = Convert.ToDouble(reader["Amount"]);
                    double saleswithtax = sales + (sales * .145);
                    saleInfoGrid.Rows[rows].Cells[3].Value = saleswithtax;
                    saleInfoGrid.Rows[rows].Cells[4].Value = reader["PaymentMode"];
                    saleInfoGrid.Rows[rows].Cells[5].Value = reader["discount"];
                    saleInfoGrid.Rows[rows].Cells[6].Value = reader["Id"];


                    rows++;

                }
                saleInfoGrid.AllowUserToAddRows = false;
            }
        }

        private void EventSalesDTChanged(object sender, EventArgs e)
        {
            double amount, total = 0;
            Sales s = new Sales();
            SqlDataReader reader = s.GetSalesByDate(salDTToday.Value);
            double cashsale = 0.0, cardsale = 0.0, amt = 0.0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    amount = Convert.ToDouble(reader["amount"]);
                    total = total + amount;
                    string paymentmode = reader["PaymentMode"].ToString();
                    if (paymentmode == "Cash")
                    {
                        amt = Convert.ToDouble(reader["Amount"]);
                        cashsale = cashsale + amt;

                    }
                    else
                    {
                        amt = Convert.ToDouble(reader["Amount"]);
                        cardsale = cardsale + amt;
                    }
                }
            }

            salLabelTotalCash.Text = cashsale.ToString();
            salLabelTotalCard.Text = cardsale.ToString();
            salLabelDayWTax.Text = (cashsale + cardsale).ToString();
            salLabelDayTax.Text = ((cashsale + cardsale) + ((cashsale + cardsale) * .145)).ToString();
        }

        private void EventDeleteSales(object sender, EventArgs e)
        {
            int salesid = Convert.ToInt32(saleInfoGrid.Rows[salesrow].Cells[6].Value);
            Sales sale = new Sales();
            bool success = false;
            success = sale.delete(salesid);
            if (success)
            {
                MetroMessageBox.Show(this.FindForm(), "Sales Deleted", "DB Update", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MetroMessageBox.Show(this.FindForm(), "Failed!!!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

            populate_Sales();

        }

        private void metroGrid12_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string SalesId = saleInfoGrid.Rows[row].Cells[6].Value.ToString();
            if (string.IsNullOrWhiteSpace(SalesId) == false)
            {
                Sales s = new Sales();
                string Path = s.GetInvoicePath(SalesId);
                if (string.IsNullOrWhiteSpace(Path) == false)
                {
                    System.Diagnostics.Process.Start(Path);
                }
            }
            if (users.umode == "Store Owner")
            {
                //saleBtnDelete.Enabled = true;
            }
            salesrow = e.RowIndex;

        }

        private void metroDateTime5_ValueChanged(object sender, EventArgs e)
        {
            double salesamount = 0, withtax = 0;
            string cussId;
            DateTime cdate = DateTime.Today; //saleDTFilter.Value;
            Sales s = new Sales();
            SqlDataReader reader = s.GetSalesByDate(cdate);
            if (reader.HasRows)
            {
                int rows = 0;
                saleInfoGrid.Rows.Clear();
                while (reader.Read())
                {
                    saleInfoGrid.Rows.Add();
                    cussId = reader["CustomerId"].ToString();
                    SqlDataReader reader1 = Program.db.get_where("Customers", cussId);

                    DateTime date = Convert.ToDateTime(reader["Date"]);

                    saleInfoGrid.Rows[rows].Cells[0].Value = date.ToString("yyyy-MM-dd");
                    //metroGrid12.Rows[rows].Cells[1].Value = reader["Id"];
                    saleInfoGrid.Rows[rows].Cells[2].Value = reader["Amount"];
                    salesamount = Convert.ToDouble(reader["Amount"]);
                    withtax = salesamount + (salesamount * .145);
                    while (reader1.Read())
                    {
                        saleInfoGrid.Rows[rows].Cells[1].Value = reader1["Name"];
                    }

                    saleInfoGrid.Rows[rows].Cells[3].Value = withtax;
                    saleInfoGrid.Rows[rows].Cells[4].Value = reader["PaymentMode"];
                    saleInfoGrid.Rows[rows].Cells[5].Value = reader["Discount"];
                    saleInfoGrid.Rows[rows].Cells[6].Value = reader["id"];
                    rows++;

                }
                saleInfoGrid.AllowUserToAddRows = false;
            }
            else
            {
                saleInfoGrid.Rows.Clear();
            }
        }

        private void saleRadioShowAll_CheckedChanged(object sender, EventArgs e)
        {
            this.populate_Sales();
        }

        private void saleRadioFilter_CheckedChanged(object sender, EventArgs e)
        {
            this.populate_Sales();
        }
    }
}
