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
        //Int32 m_TherapistID = -1;

        private void populateSalesComm()
        {
            SqlDataReader reader = Program.db.get_desc("Therapists");

            if (reader.HasRows)
            {
                DateTime date = DateTime.Today;
                string month = date.ToString("MMMM");
                saleMonthCommGrid.Rows.Clear();
                int row = 0;
                saleMonthCommGrid.AllowUserToAddRows = true;
                Therapists t = new Therapists();
                while (reader.Read())
                {
                    double comm = t.GetTotalCommissionByMonth(reader["Id"].ToString(), date);
                    double Sales = t.GetTotalSalesByMonth(reader["Id"].ToString(), date);
                    saleMonthCommGrid.Rows.Add();
                    saleMonthCommGrid.Rows[row].Cells[0].Value = reader["Name"].ToString();
                    saleMonthCommGrid.Rows[row].Cells[1].Value = month;
                    saleMonthCommGrid.Rows[row].Cells[2].Value = Sales.ToString();
                    saleMonthCommGrid.Rows[row].Cells[3].Value = comm.ToString();
                    row++;
                }

                saleMonthCommGrid.AllowUserToAddRows = false;
            }
        }

        private void LoadTherapists()// implement Therapist load here
        {
            if (loggedinUserLevel == "Store Manager" || loggedinUserLevel == "Customer Manager")
                return;


            SqlDataReader reader = Program.db.get_desc("Therapists");
            if (reader.HasRows)
            {
                try
                {
                    thepListGrid.Rows.Clear();
                    thepListGrid.AllowUserToAddRows = true;
                    int rows = 0;
                    while (reader.Read())
                    {
                        thepListGrid.Rows.Add();
                        thepListGrid.Rows[rows].Cells[0].Value = reader["Id"];
                        thepListGrid.Rows[rows].Cells[1].Value = reader["Name"];
                        thepListGrid.Rows[rows].Cells[2].Value = reader["Status"];
                        thepListGrid.Rows[rows].Cells[3].Value = reader["Phone"];
                        thepListGrid.Rows[rows].Cells[4].Value = reader["Email"];
                        thepListGrid.Rows[rows].Cells[5].Value = reader["Address"];
                        rows++;
                    }
                    thepListGrid.AllowUserToAddRows = false;
                }
                catch (System.NullReferenceException exp)
                {
                    Log.AppError(exp.Message);
                }
            }
            reader.Close();

            populateCommisions();
        }

        private int GetTherapistId()
        {
            string therapistName = aptComboTherapist.SelectedItem.ToString();
            Dictionary<string, string> data = new Dictionary<string, string>();
            SqlDataReader reader = null;
            data.Add("Name", "'" + therapistName + "'");
            reader = Program.db.get_where_custom("Therapists", data);
            reader.Read();
            int therapistId = Convert.ToInt32(reader["Id"]);
            reader.Close();
            data.Clear();
            return therapistId;
        }

        private bool Validate_Therapist()
        {
            if (String.IsNullOrWhiteSpace(thepTxtName.Text))
            {
                thepTxtName.WithError = true;
                ToggleTherapistStatus(true, true, "Therapist name cannot be blank");
                return false;
            }
            if (String.IsNullOrWhiteSpace(thepTxtPhone.Text))
            {
                thepTxtPhone.WithError = true;
                ToggleTherapistStatus(true, true, "Therapist phone no cannot be blank");
                return false;
            }
            //if (String.IsNullOrWhiteSpace(thepTxtEmail.Text))
            //{
            //    thepTxtEmail.WithError = true;
            //    ToggleTherapistStatus(true, true, "Therapist email cannot be blank");
            //    return false;
            //}
            if (String.IsNullOrWhiteSpace(thepTxtAddress.Text))
            {
                thepTxtAddress.WithError = true;
                ToggleTherapistStatus(true, true, "Therapist address cannot be blank");
                return false;
            }

            return true;
        }

        private void EventTherapist_Save(object sender, EventArgs e)
        {
            if (!Validate_Therapist())
            {
                return;
            }

            string name = thepTxtName.Text;
            string phone = thepTxtPhone.Text;
            string email = thepTxtEmail.Text;
            string address = thepTxtAddress.Text;
            Therapists ob = new Therapists();

            bool status = ob.Add(name, phone, email, address);
            if (status)
            {
                LoadTherapists();
                LoadAppoinments();
                //ReInitializeThreparistControls();
                ToggleTherapistStatus(true, false, "Therapist added succesfully");
            }
            else
            {
                MetroMessageBox.Show(this.FindForm(), "There seems to be some problem", "DB Update", MessageBoxButtons.OK);
            }
        }

        private void EventTherapist_Delete(object sender, EventArgs e)
        {
            DataGridViewRow row = this.thepListGrid.CurrentRow;
            string idStr = row.Cells["Column20"].Value.ToString();
            int id = -1;
            try
            {
                id = Convert.ToInt32(idStr);
            }
            catch (Exception ex)
            {
                Log.AppError(ex.Message);
                return;
            }
            Therapists obj = new Therapists();
            obj.delete(id);

            Therapists ob = new Therapists();

            int rows;
            SqlDataReader reader = Program.db.get("Therapists");
            if (reader.HasRows)
            {
                try
                {
                    rows = 0;
                    while (reader.Read())
                    {
                        row = (DataGridViewRow)thepListGrid.Rows[0].Clone();

                        //   metroGrid2.Rows.Add(row);

                        thepListGrid.Rows[rows].Cells[0].Value = reader["Id"];
                        thepListGrid.Rows[rows].Cells[1].Value = reader["Name"];
                        thepListGrid.Rows[rows].Cells[2].Value = reader["Status"];
                        thepListGrid.Rows[rows].Cells[3].Value = reader["Phone"];
                        thepListGrid.Rows[rows].Cells[4].Value = reader["Email"];
                        thepListGrid.Rows[rows].Cells[5].Value = reader["Address"];

                        rows++;
                    }
                    thepListGrid.Rows.RemoveAt(rows);
                }
                catch (System.NullReferenceException exp)
                {
                    Log.AppError(exp.Message);
                }
            }
            else
            {
                rows = 0;
                thepListGrid.Rows[rows].Cells[0].Value = "";
                thepListGrid.Rows[rows].Cells[1].Value = "";
                thepListGrid.Rows[rows].Cells[2].Value = "";
                thepListGrid.Rows[rows].Cells[3].Value = "";
                thepListGrid.Rows[rows].Cells[4].Value = "";
            }
            thepListGrid.Refresh();
            thepListGrid.ClearSelection();
        }

        private void ReInitializeThreparistControls()
        {
            thepTxtName.Text = "";
            thepTxtPhone.Text = "";
            thepTxtEmail.Text = "";
            thepTxtAddress.Text = "";
            thepTxtName.Focus();
        }

        public void populateCommisions()
        {
            SqlDataReader reader = Program.db.get_desc("Therapists");
            thepGridSales.Rows.Clear();
            if (reader.HasRows)
            {

                Therapists t = new Therapists();
                //DateTime now = thepDTFilter.Value;
                int row = 0;
                thepGridSales.AllowUserToAddRows = true;
                while (reader.Read())
                {
                    double sales = 0.0;
                    string date = null;
                    //if (thepRadioShowAll.Checked)
                    //{
                        sales = t.GetTotalSales(reader["Id"].ToString());
                        date = "AllTime";
                    //}
                    //else if (thepRadioFilterMonth.Checked)
                    //{
                    //    sales = t.GetTotalSalesByMonth(reader["Id"].ToString(), now);
                    //    date = now.ToString("MMMM");
                    //}
                    //else
                    //{
                    //    sales = t.GetTotalSales(reader["Id"].ToString(), now);
                    //    date = now.ToString("yyyy-MM-dd");
                    //}



                    if (sales != 0.0)
                    {

                        //  metroGrid6.Rows.Clear();


                        thepGridSales.Rows.Add();
                        thepGridSales.Rows[row].Cells[0].Value = date;
                        thepGridSales.Rows[row].Cells[1].Value = reader["Name"];

                        thepGridSales.Rows[row].Cells[2].Value = sales;
                        thepGridSales.Rows[row].Cells[3].Value = 0.05 * sales;
                        row++;

                    }
                }
                thepGridSales.AllowUserToAddRows = false;
            }
        }

        private bool bThepSaveTimerFired = false;
        private Timer thepTimer = new Timer();

        private void ToggleTherapistStatus(bool bShow, bool bWarning = false, string text = "")
        {
            if (!bShow)
            {
                if (bThepSaveTimerFired)
                {
                    thepTimer.Stop();
                    bThepSaveTimerFired = false;
                }

                thepLnkStatus.Text = String.Empty;
                thepPanelStatus.Visible = false;
            }
            else
            {
                if (bWarning)
                {
                    thepLnkStatus.Image = Properties.Resources.warning_icon;
                    thepLnkStatus.NoFocusImage = Properties.Resources.warning_icon;
                }
                else
                {
                    thepLnkStatus.Image = Properties.Resources.thumb_up_small;
                    thepLnkStatus.NoFocusImage = Properties.Resources.thumb_up_small;

                    if (!bThepSaveTimerFired)
                    {
                        thepTimer.Interval = 2000;
                        thepTimer.Tick += ThepTimer_Tick;
                        thepTimer.Start();
                        bThepSaveTimerFired = true;
                    }
                }

                thepLnkStatus.Text = text;
                thepPanelStatus.Visible = true;
            }
        }

        private void ThepTimer_Tick(object sender, EventArgs e)
        {
            ToggleTherapistStatus(false);
            ReInitializeThreparistControls();
        }
    }
}
