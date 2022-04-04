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
        //Int32 m_CustomertID = -1;
        private enum CutomerEntryView
        {
            DefaultView = -1,
            CustomerProfile,
            BuyPackage,
            BusinessPromotion,
            CustomerCommunication
        };

        private CutomerEntryView m_CutomerEntryView = CutomerEntryView.DefaultView;
        private List<MetroFramework.Controls.MetroLink> custEntryNavControls = new List<MetroFramework.Controls.MetroLink>();
        private CustomerControl m_custCustomerControl = null;

        private void PopulateNavControlList()
        {
            custEntryNavControls.Add(custLnkNavCustProf);
            custEntryNavControls.Add(custLnkNavBuyPack);
            custEntryNavControls.Add(custLnkNavBusinessPromo);
            custEntryNavControls.Add(custLnkNavCustComm);
        }

        private void ConfigPanel_Customer()
        {
            PopulateNavControlList();

            m_custCustomerControl = new CustomerControl();
            m_custCustomerControl.Dock = DockStyle.Fill;
            custTLPInnerRight1.Controls.Add(m_custCustomerControl, 0, 1);
            
            ToggleCustomerEntryView(CutomerEntryView.CustomerProfile);
        }

        private void ToggleCustomerEntryView(CutomerEntryView entryView)
        {
            if (m_CutomerEntryView == entryView)
            {
                return;
            }

            for (int iRowNo = 0; iRowNo < 4; iRowNo++)
            {
                if (iRowNo == (int)entryView)
                {
                    m_CutomerEntryView = entryView;
                    custTLPEntry.RowStyles[iRowNo].SizeType = SizeType.Percent;
                    custTLPEntry.RowStyles[iRowNo].Height = 100F;
                    custEntryNavControls[iRowNo].Image = Properties.Resources.collapse_active;
                    custEntryNavControls[iRowNo].NoFocusImage = Properties.Resources.collapse_active;
                }
                else
                {
                    custTLPEntry.RowStyles[iRowNo].SizeType = SizeType.Absolute;
                    custTLPEntry.RowStyles[iRowNo].Height = 36F;
                    custEntryNavControls[iRowNo].Image = Properties.Resources.drop_active;
                    custEntryNavControls[iRowNo].NoFocusImage = Properties.Resources.drop_active;
                }
            }
        }


        private void populateCustomers()
        {
            //billTodaySessGrid.PerformLayout();

            //SqlDataReader reader = Program.db.get_desc("Customers");

            //if (reader.HasRows)
            //{
            //    int row = 0;
            //    billRegCustGrid.Rows.Clear();
            //    billRegCustGrid.AllowUserToAddRows = true;
            //    while (reader.Read())
            //    {
            //        try
            //        {
            //            billRegCustGrid.Rows.Add();
            //            billRegCustGrid.Rows[row].Cells[0].Value = reader["Id"].ToString();
            //            billRegCustGrid.Rows[row].Cells[1].Value = reader["Name"].ToString();
            //            billRegCustGrid.Rows[row].Cells[2].Value = reader["Phone"].ToString();

            //            billRegCustGrid.Rows[row].Cells[3].Value = reader["Email"].ToString();
            //            billRegCustGrid.Rows[row].Cells[4].Value = reader["Address"].ToString();
            //            billRegCustGrid.Rows[row].Cells[5].Value = reader["Visits"].ToString();
            //        }
            //        catch (Exception ex)
            //        {
            //            Log.AppError(ex.Message);
            //        }

            //        row++;
            //    }


            //}
            //billRegCustGrid.AllowUserToAddRows = false;
            //reader.Close();
        }

        private void LoadCustomers()
        {
            // metroGrid11.PerformLayout();
            //string custid = null, packageid = null;
            //SqlDataReader reader = Program.db.get("CustomerPackages");

            //if (reader.HasRows)
            //{
            //    int row = 0;
            //    custPackGrid.Rows.Clear();
            //    custPackGrid.AllowUserToAddRows = true;
            //    while (reader.Read())
            //    {
            //        try
            //        {
            //            custPackGrid.Rows.Add();
            //            custPackGrid.Rows[row].Cells[0].Value = reader["Id"].ToString();
            //            packageid = reader["PackageId"].ToString();
            //            SqlDataReader reader2 = Program.db.get_where("Packages", packageid);
            //            reader2.Read();
            //            custPackGrid.Rows[row].Cells[1].Value = reader2["Name"];
            //            custid = reader["CustomerId"].ToString();
            //            SqlDataReader reader1 = Program.db.get_where("Customers", custid);
            //            reader1.Read();
            //            custPackGrid.Rows[row].Cells[2].Value = reader1["Name"].ToString();
            //            custPackGrid.Rows[row].Cells[3].Value = Convert.ToDateTime(reader["StartDate"]).ToString("yyyy-MM-dd");
            //            custPackGrid.Rows[row].Cells[4].Value = Convert.ToDateTime(reader["ExpireDate"]).ToString("yyyy-MM-dd");
            //            custPackGrid.Rows[row].Cells[5].Value = reader["Sessions"].ToString();
            //            List<int> val = new List<int>();
            //            Packages package = new Packages();
            //            val = package.ValidServices(custid, packageid);
            //            if (val.Count <= 0)
            //            {
            //                custPackGrid.Rows[row].Cells[6].Value = "Invalid";
            //            }
            //            else
            //            {
            //                custPackGrid.Rows[row].Cells[6].Value = "Valid";
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Log.AppError(ex.Message);
            //        }

            //        row++;
            //    }
            //}
            //custPackGrid.AllowUserToAddRows = false;

            //PopulateCustomerData(custid, packageid);

        }

        private void PopulateCustomerData(string CustomerId, string PackageId)
        {
            SqlDataReader reader3 = Program.db.get("Customers");

            if (reader3.HasRows)
            {
                int row = 0;
                custGridCustomerList.Rows.Clear();
                custGridCustomerList.AllowUserToAddRows = true;
                while (reader3.Read())
                {
                    try
                    {
                        custGridCustomerList.Rows.Add();
                        custGridCustomerList.Rows[row].Cells[0].Value = reader3["Id"].ToString();


                        custGridCustomerList.Rows[row].Cells[1].Value = reader3["Name"];

                        custGridCustomerList.Rows[row].Cells[2].Value = reader3["Phone"].ToString();
                        custGridCustomerList.Rows[row].Cells[3].Value = reader3["Email"].ToString();
                        custGridCustomerList.Rows[row].Cells[4].Value = reader3["Address"].ToString();
                        custGridCustomerList.Rows[row].Cells[5].Value = reader3["Visits"].ToString();

                    }
                    catch (Exception ex)
                    {
                        Log.AppError(ex.Message);
                    }

                    row++;
                }
                custGridCustomerList.AllowUserToAddRows = false;
            }
        }

        private bool Validate_Customer()
        {
            //if (String.IsNullOrWhiteSpace(custTxtCustProName.Text))
            //{
            //    custTxtCustProName.WithError = true;
            //    ToggleCustomerStatus(true, true, "Customer name cannot be blank");
            //    return false;
            //}
            //if (String.IsNullOrWhiteSpace(custTxtCustProPh.Text))
            //{
            //    custTxtCustProPh.WithError = true;
            //    ToggleCustomerStatus(true, true, "Customer phone no cannot be blank");
            //    return false;
            //}
            //if (String.IsNullOrWhiteSpace(custTxtCustProEmail.Text))
            //{
            //    custTxtCustProEmail.WithError = true;
            //    ToggleCustomerStatus(true, true, "Customer email cannot be blank");
            //    return false;
            //}
            //if (String.IsNullOrWhiteSpace(custTxtCustProAddr.Text))
            //{
            //    custTxtCustProAddr.WithError = true;
            //    ToggleCustomerStatus(true, true, "Customer address cannot be blank");
            //    return false;
            //}

            return true;
        }

        private void EventCustomer_Save(object sender, EventArgs e)
        {
            //if (!Validate_Customer())
            //{
            //    return;
            //}

            //int id = 0, Visits = 0;
            //string name = custTxtCustProName.Text;
            //double Phone = Convert.ToDouble(custTxtCustProPh.Text);
            //string Email = custTxtCustProEmail.Text;
            ////Visits = Convert.ToInt32(custTxtVisits.Text);
            //string Address = custTxtCustProAddr.Text;

            //Customers cust = new Customers();
            //bool success = cust.AddCustomer(id, name, Phone, Email, Visits, Address);
            //if (success)
            //{
            //    this.LoadCustomers();
            //    //this.LoadBilling();
            //    ToggleCustomerStatus(true, false, "Customer added successfully");
            //}
            //else
            //{
            //    MetroMessageBox.Show(this.FindForm(), "Customer Addition/Update Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void ReinitializeCustomerControls()
        {
            //custTxtCustProName.Text = "";
            //custTxtCustProPh.Text = "";
            //custTxtCustProEmail.Text = "";
            ////custTxtVisits.Text = "";
            //custTxtCustProAddr.Text = "";
            //custTxtCustProName.Focus();
        }

        private bool bCustSaveTimerFired = false;
        private Timer custTimer = new Timer();

        private void ToggleCustomerStatus(bool bShow, bool bWarning = false, string text = "")
        {
            if (!bShow)
            {
                if (bCustSaveTimerFired)
                {
                    custTimer.Stop();
                    bCustSaveTimerFired = false;
                }

                custLnkStatus.Text = String.Empty;
                custPanelStatus.Visible = false;
            }
            else
            {
                if (bWarning)
                {
                    custLnkStatus.Image = Properties.Resources.warning_icon;
                    custLnkStatus.NoFocusImage = Properties.Resources.warning_icon;
                }
                else
                {
                    custLnkStatus.Image = Properties.Resources.thumb_up_small;
                    custLnkStatus.NoFocusImage = Properties.Resources.thumb_up_small;

                    if (!bCustSaveTimerFired)
                    {
                        custTimer.Interval = 2000;
                        custTimer.Tick += CustTimer_Tick;
                        custTimer.Start();
                        bCustSaveTimerFired = true;
                    }
                }

                custLnkStatus.Text = text;
                custPanelStatus.Visible = true;
            }
        }

        private void CustTimer_Tick(object sender, EventArgs e)
        {
            ToggleCustomerStatus(false);
            ReinitializeCustomerControls();
        }
    }
}
