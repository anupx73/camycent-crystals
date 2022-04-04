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
        private CustomerControl m_billCustomerControl = null;
        private void ConfigPanel_Bill()
        {
            m_billCustomerControl = new CustomerControl();
            m_billCustomerControl.Dock = DockStyle.Fill;
            billTLPEntry.Controls.Add(m_billCustomerControl, 0, 4);
        }

        //CancelAppointment cancel = null;

    //    private void LoadBilling()
    //    {
    //        billTodaySessGrid.PerformLayout();
            
    //        SqlDataReader reader = Program.db.get_desc("Customers");
    //        if (reader.HasRows)
    //        {
    //            int row = 0;
    //            billRegCustGrid.Rows.Clear();
    //            billRegCustGrid.AllowUserToAddRows = true;
    //            while (reader.Read())
    //            {
    //                try
    //                {
    //                    billRegCustGrid.Rows.Add();
    //                    billRegCustGrid.Rows[row].Cells[0].Value = reader["Id"].ToString();
    //                    billRegCustGrid.Rows[row].Cells[1].Value = reader["Name"].ToString();
    //                    billRegCustGrid.Rows[row].Cells[2].Value = reader["Phone"].ToString();

    //                    billRegCustGrid.Rows[row].Cells[3].Value = reader["Email"].ToString();
    //                    billRegCustGrid.Rows[row].Cells[4].Value = reader["Address"].ToString();
    //                    billRegCustGrid.Rows[row].Cells[5].Value = reader["Visits"].ToString();
    //                }
    //                catch (Exception ex)
    //                {
    //                    Log.AppError(ex.Message);
    //                }

    //                row++;
    //            }
    //        }
    //        billRegCustGrid.AllowUserToAddRows = false;
    //        reader.Close();

    //        Appointments app = new Appointments();

    //        reader = app.GetLiveAppointments();

    //        Customers cus = new Customers();

    //        if (reader.HasRows)
    //        {
    //            billTodaySessGrid.Rows.Clear();
    //            billTodaySessGrid.AllowUserToAddRows = true;
    //            int row = 0;
    //            while (reader.Read())
    //            {
    //                billTodaySessGrid.Rows.Add();
    //                billTodaySessGrid.Rows[row].Cells[0].Value = reader["Id"].ToString();
    //                billTodaySessGrid.Rows[row].Cells[1].Value = cus.GetCustomerName(reader["CustomerId"].ToString());
    //                billTodaySessGrid.Rows[row].Cells[2].Value = reader["StartTime"].ToString();
    //                billTodaySessGrid.Rows[row].Cells[3].Value = reader["EndTime"].ToString();
    //                billTodaySessGrid.Rows[row].Cells[4].Value = reader["Price"].ToString();
    //                row++;
    //            }
    //            billTodaySessGrid.AllowUserToAddRows = false;
    //        }

    //        reader.Close();
    //        reader = Program.db.get("Packages");

    //        if (reader.HasRows)
    //        {
    //            billComboChoosePck.Items.Clear();
    //            while (reader.Read())
    //            {
    //                billComboChoosePck.Items.Add(reader["Name"].ToString());
    //            }
    //        }

    //        reader.Close();
    //        this.populateSessions();
    //        // implement customer load here
    //    }

    //    public static int customer_row;
    //    private void btnCheckOut_Click(object sender, EventArgs e)
    //    {
    //        int appId = Convert.ToInt32(billTodaySessGrid.Rows[customer_row].Cells[0].Value);
    //        Appointments app = new Appointments();
    //        Boolean success = app.CheckOut(appId);
    //        if (success)
    //        {
    //            LoadBilling();
    //            LoadSales();
    //        }
    //        else
    //        {
    //            Log.AppError("Checkout Failed");
    //            MetroMessageBox.Show(this.FindForm(), "Something Went Wrong, please restart the application.", "Checkout");
    //        }

    //        this.populateSessions();
    //        this.populateCommisions();
    //        this.EventPopulateAppointments();
    //    }

    //    private void button2_Click(object sender, EventArgs e)    // cancel appointment and insert remarks
    //    {
    //        string appId = billTodaySessGrid.Rows[customer_row].Cells[0].Value.ToString();
    //        string sessiondate;
    //        Dictionary<string, string> d = new Dictionary<string, string>();
    //        d.Add("Status", "'" + "Canceled" + "'");
    //        // changes appointment status from booked to canceled
    //        Program.db.update("Appointments", d, " where Id=" + appId + "");
    //        SqlDataReader reader = Program.db.get_where("Appointments", appId);
    //        while (reader.Read())
    //        {
    //            sessiondate = reader["SessionDate"].ToString();

    //            Dictionary<string, string> data = new Dictionary<string, string>();
    //            data.Add("AppId", "'" + appId + "'");
    //            data.Add("Date", "'" + sessiondate + "'");

    //            Program.db.insert("CancelAppointments", data);

    //        }
    //        if (cancel == null)
    //        {
    //            cancel = new CancelAppointment();
    //        }
    //        cancel.ShowDialog();


    //        this.populateSessions();
    //    }

    //    private void billRegCustGrid_CellClick(object sender, DataGridViewCellEventArgs e)
    //    {
    //        int row = e.RowIndex;

    //        metroTextBox2.Text = billRegCustGrid.Rows[row].Cells[1].Value.ToString();
    //        metroTextBox4.Text = billRegCustGrid.Rows[row].Cells[2].Value.ToString();
    //        metroTextBox5.Text = billRegCustGrid.Rows[row].Cells[3].Value.ToString();
    //        metroTextBox29.Text = billRegCustGrid.Rows[row].Cells[4].Value.ToString();
    //        metroTextBox8.Text = billRegCustGrid.Rows[row].Cells[5].Value.ToString();
    //    }

    //    private void billTodaySessionGrid_CellClick(object sender, DataGridViewCellEventArgs e)
    //    {
    //        UIUtility.DisableButton(billBtnCheckOut, false);
    //        UIUtility.DisableButton(billBtnCancel, false);
    //        customer_row = e.RowIndex;
    //    }
    }
}
