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
        Int32 m_PackageID = -1;
        private enum PackageEntryView
        {
            DefaultView = -1,
            CreateService,
            CreatePackage
        };

        private PackageEntryView m_PackageEntryView = PackageEntryView.DefaultView;
        private List<MetroFramework.Controls.MetroLink> packEntryNavControls = new List<MetroFramework.Controls.MetroLink>();
        private void PopulatePackNavControlList()
        {
            packEntryNavControls.Add(pckLnkCreateService);
            packEntryNavControls.Add(pckLnkCreatePakcage);
        }
        
        private void ConfigPanel_Package()
        {
            PopulatePackNavControlList();
            TogglePackageEntryView(PackageEntryView.CreateService);
        }

        private void TogglePackageEntryView(PackageEntryView entryView)
        {
            if (m_PackageEntryView == entryView)
            {
                return;
            }

            for (int iRowNo = 0; iRowNo < 2; iRowNo++)
            {
                if (iRowNo == (int)entryView)
                {
                    m_PackageEntryView = entryView;
                    pckTLPEntry.RowStyles[iRowNo].SizeType = SizeType.Percent;
                    pckTLPEntry.RowStyles[iRowNo].Height = 100F;
                    packEntryNavControls[iRowNo].Image = Properties.Resources.collapse_active;
                    packEntryNavControls[iRowNo].NoFocusImage = Properties.Resources.collapse_active;
                }
                else
                {
                    pckTLPEntry.RowStyles[iRowNo].SizeType = SizeType.Absolute;
                    pckTLPEntry.RowStyles[iRowNo].Height = 36F;
                    packEntryNavControls[iRowNo].Image = Properties.Resources.drop_active;
                    packEntryNavControls[iRowNo].NoFocusImage = Properties.Resources.drop_active;
                }
            }

            //if (m_PackageEntryView == PackageEntryView.CreateService)
            //{
            //    svcGridItemRqd.Size = new System.Drawing.Size(210, pckPanelCreatePack.Height - svcGridItemRqd.Location.Y);
            //}
            //else if (m_PackageEntryView == PackageEntryView.CreatePackage)
            //{
            //    pckGridInclServices.Size = new System.Drawing.Size(210, pckPanelCreateSvc.Height - pckGridInclServices.Location.Y);
            //}
        }

        private void LoadPackages()          // implement package load here
        { }
        //{
        //    if (loggedinUserLevel == "Customer Manager")
        //    {
        //        return;
        //    }

        //    //DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
        //    //CheckBox chk = new CheckBox();
        //    //CheckboxColumn.Width = 20;
        //    //metroGrid9.Columns.Add(CheckboxColumn);

        //    Packages package = new Packages();
        //    SqlDataReader reader = Program.db.get_desc("Packages");

        //    if (reader.HasRows)
        //    {
        //        pckListGrid.AllowUserToAddRows = true;
        //        pckListGrid.Rows.Clear();
        //        try
        //        {
        //            int rows = 0;
        //            while (reader.Read())
        //            {
        //                DataGridViewRow row = (DataGridViewRow)pckListGrid.Rows[0].Clone();
        //                pckListGrid.Rows.Add(row);

        //                pckListGrid.Rows[rows].Cells[0].Value = reader["Id"];
        //                pckListGrid.Rows[rows].Cells[1].Value = reader["Name"];
        //                pckListGrid.Rows[rows].Cells[2].Value = reader["Price"];
        //                pckListGrid.Rows[rows].Cells[3].Value = reader["Duration"];
        //                pckListGrid.Rows[rows].Cells[4].Value = reader["Value"];
        //                pckListGrid.Rows[rows].Cells[5].Value = reader["Description"];

        //                rows++;
        //            }

        //            pckListGrid.AllowUserToAddRows = false;
        //        }
        //        catch (System.NullReferenceException exp)
        //        {
        //            Log.AppError(exp.Message);
        //        }
        //    }

        //    reader.Close();
        //    Services obj = new Services();
        //    reader = Program.db.get("Services");

        //    if (reader.HasRows)
        //    {
        //        try
        //        {
        //            pckGridInclServices.Rows.Clear();
        //            int rows = 0;
        //            pckGridInclServices.AllowUserToAddRows = true;
        //            while (reader.Read())
        //            {
        //                DataGridViewRow row = (DataGridViewRow)pckGridInclServices.Rows[0].Clone();

        //                pckGridInclServices.Rows.Add(row);

        //                pckGridInclServices.Rows[rows].Cells[0].Value = reader["Id"];
        //                pckGridInclServices.Rows[rows].Cells[1].Value = reader["Name"];
        //                pckGridInclServices.Rows[rows].Cells[2].Value = reader["Price"];
        //                pckGridInclServices.Rows[rows].Cells[3].Value = "";
        //                pckGridInclServices.Rows[rows].Cells[4].Value = false;
        //                rows++;
        //            }

        //            pckGridInclServices.AllowUserToAddRows = false;
        //        }
        //        catch (System.NullReferenceException exp)
        //        {
        //            Log.AppError(exp.Message);
        //        }
        //    }
        //}

        //private void pckListGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;

        //    //Fetching Row Data
        //    int Id = Convert.ToInt32(pckListGrid.Rows[row].Cells[0].Value);
        //    string Name = pckListGrid.Rows[row].Cells[1].Value.ToString();
        //    double Cost = Convert.ToDouble(pckListGrid.Rows[row].Cells[2].Value);
        //    int Duration = Convert.ToInt32(pckListGrid.Rows[row].Cells[3].Value);
        //    //double Worth = Convert.ToDouble(pckListGrid.Rows[row].Cells[4].Value);
        //    string Desc = pckListGrid.Rows[row].Cells[1].Value.ToString();

        //    //Setting data in the Add/Update Form

        //    pckTxtName.Text = Name;
        //    pckTxtValidity.Text = Duration.ToString();
        //    pckTxtCost.Text = Cost.ToString();
        //    //pckTxtService.Text = Worth.ToString();
        //    pckTxtDesc.Text = Desc;
        //    m_PackageID = Id;


        //    Packages package = new Packages();
        //    SqlDataReader reader = package.PackageServices(Id);

        //    int iRows = 0;
        //    foreach (DataGridViewRow iRow in pckGridInclServices.Rows)
        //    {
        //        pckGridInclServices.Rows[iRows].Cells[3].Value = null;
        //        pckGridInclServices.Rows[iRows].Cells[4].Value = false;
        //        iRows++;
        //    }

        //    int servid;
        //    if (reader != null)
        //    {
        //        if (reader.HasRows)
        //        {
        //            try
        //            {
        //                while (reader.Read())
        //                {
        //                    foreach (DataGridViewRow iRow in pckGridInclServices.Rows)
        //                    {
        //                        int rows = Convert.ToInt32(iRow.Index);
        //                        DataGridViewRow gridrow = (DataGridViewRow)pckGridInclServices.Rows[0].Clone();


        //                        servid = Convert.ToInt32(reader["ServiceId"]);
        //                        if (Convert.ToInt32(pckGridInclServices.Rows[rows].Cells[0].Value) == servid)
        //                        {
        //                            //taking a new reader which contains the item information of that specific selected item id
        //                            SqlDataReader ServReader = Program.db.get_where("Services", servid.ToString());
        //                            while (ServReader.Read())
        //                            {
        //                                pckGridInclServices.Rows[rows].Cells[0].Value = ServReader["Id"];
        //                                pckGridInclServices.Rows[rows].Cells[1].Value = ServReader["Name"];
        //                                pckGridInclServices.Rows[rows].Cells[2].Value = ServReader["Price"];
        //                                pckGridInclServices.Rows[rows].Cells[3].Value = reader["Sessions"];
        //                                if (reader["Sessions"] != null)
        //                                {
        //                                    pckGridInclServices.Rows[rows].Cells[4].Value = true;
        //                                }
        //                                else
        //                                    pckGridInclServices.Rows[rows].Cells[4].Value = false;
        //                            }

        //                        }
        //                    }

        //                }

        //            }
        //            catch (System.NullReferenceException exp)
        //            {
        //                Log.AppError(exp.Message);
        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //    else
        //    {
        //        MetroMessageBox.Show(this.FindForm(), "Table is empty", "Error", MessageBoxButtons.OK);
        //    }
        //}

        private void ReinitializePackControls()
        {
            m_PackageID = -1;
            pckTxtName.Text = "";
            pckTxtValidity.Text = "";
            pckTxtCost.Text = "";
            //pckTxtService.Text = "";
            pckTxtDesc.Text = "";
            pckTxtName.Focus();
        }

        private void EventPackage_New(object sender, EventArgs e)
        {
            ReinitializePackControls();
            foreach (DataGridViewRow row in pckGridInclServices.Rows)
            {
                pckGridInclServices.Rows[row.Index].Cells[3].Value = "";
                pckGridInclServices.Rows[row.Index].Cells[4].Value = false;
            }
        }

        private bool Validate_Package()
        {
            if (String.IsNullOrWhiteSpace(pckTxtName.Text))
            {
                pckTxtName.WithError = true;
                TogglePackStatus(true, true, "Package name cannot be blank");
                return false;
            }
            if (String.IsNullOrWhiteSpace(pckTxtValidity.Text))
            {
                pckTxtValidity.WithError = true;
                TogglePackStatus(true, true, "Package validity cannot be blank");
                return false;
            }
            if (String.IsNullOrWhiteSpace(pckTxtCost.Text))
            {
                pckTxtCost.WithError = true;
                TogglePackStatus(true, true, "Package cost cannot be blank");
                return false;
            }
            //if (String.IsNullOrWhiteSpace(pckTxtService.Text))
            //{
            //    pckTxtService.WithError = true;
            //    TogglePackStatus(true, true, "Service worth cost cannot be blank");
            //    return false;
            //}
            //if (String.IsNullOrWhiteSpace(pckTxtDesc.Text))
            //{
            //}

            return true;
        }

        private void EventPackage_Save(object sender, EventArgs e) // package addition here
        {
            if (!Validate_Package())
            {
                return;
            }

            string PackageName = pckTxtName.Text;
            int Duration = Convert.ToInt32(pckTxtValidity.Text);
            int Cost = Convert.ToInt32(pckTxtCost.Text);
            //int Worth = Convert.ToInt32(pckTxtService.Text);
            string Desc = pckTxtDesc.Text;
            int rows = 0;
            int SessionNo = 0;
            int Id = 0;
            Dictionary<int, int> PackageData = new Dictionary<int, int>();
            foreach (DataGridViewRow row in pckGridInclServices.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[4];
                if (Convert.ToBoolean(chk.Value))
                {
                    try
                    {
                        string sessions = pckGridInclServices.Rows[rows].Cells[3].Value.ToString();
                        string id = pckGridInclServices.Rows[rows].Cells[0].Value.ToString();// do database operation with quantity here 
                        string cost = pckGridInclServices.Rows[rows].Cells[2].Value.ToString();
                        bool result1 = Int32.TryParse(id, out Id);
                        bool result2 = Int32.TryParse(sessions, out SessionNo);

                        if (result1 && result2)
                        {
                            PackageData.Add(Id, SessionNo);

                            pckGridInclServices.EndEdit();
                        }

                        else
                        {
                            MetroMessageBox.Show(this.FindForm(), "Please Enter Number", "String Mismatch", MessageBoxButtons.OK);
                        }

                    }
                    catch (Exception ex)
                    {
                        Log.AppError(ex.Message);
                        MetroMessageBox.Show(this.FindForm(), "Null String Entered", "String Mismatch", MessageBoxButtons.OK);
                    }
                }

                rows++;
            }
            Packages ob = new Packages();
            Boolean success = ob.RegisterPackage(m_PackageID, PackageName, Duration, Cost, 0, Desc, PackageData);

            if (success)
            {
                LoadPackages();
                //LoadBilling();
                TogglePackStatus(true, false, "Package added successfully");
            }
            else
            {
                MetroMessageBox.Show(this.FindForm(), "Addition Failed. There seems to be some problem", "DB Update", MessageBoxButtons.OK);
            }
        }

        private void EventDeletePackage(object sender, EventArgs e)
        { }
        //{
        //    DataGridViewRow row = this.pckListGrid.CurrentRow;

        //    if (row == null)
        //    {
        //        return;
        //    }

        //    string idStr = row.Cells["Column32"].Value.ToString();
        //    int id = -1;
        //    try
        //    {
        //        id = Convert.ToInt32(idStr);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.AppError(ex.Message);
        //        return;
        //    }
        //    Packages obj = new Packages();
        //    obj.DeRegisterPackage(id);


        //    Packages ob = new Packages();

        //    int rows;
        //    SqlDataReader reader = Program.db.get("Packages");
        //    if (reader.HasRows)
        //    {
        //        try
        //        {
        //            rows = 0;
        //            while (reader.Read())
        //            {
        //                row = (DataGridViewRow)pckListGrid.Rows[0].Clone();

        //                //   metroGrid2.Rows.Add(row);

        //                pckListGrid.Rows[rows].Cells[0].Value = reader["Id"];
        //                pckListGrid.Rows[rows].Cells[1].Value = reader["Name"];
        //                pckListGrid.Rows[rows].Cells[2].Value = reader["Duration"];
        //                pckListGrid.Rows[rows].Cells[3].Value = reader["Price"];
        //                pckListGrid.Rows[rows].Cells[4].Value = reader["Value"];
        //                pckListGrid.Rows[rows].Cells[5].Value = reader["Description"];


        //                rows++;
        //            }
        //            pckListGrid.Rows.RemoveAt(rows);
        //        }
        //        catch (System.NullReferenceException exp)
        //        {
        //            Log.AppError(exp.Message);
        //        }
        //    }
        //    else
        //    {
        //        rows = 0;
        //        pckListGrid.Rows[rows].Cells[0].Value = "";
        //        pckListGrid.Rows[rows].Cells[1].Value = "";
        //        pckListGrid.Rows[rows].Cells[2].Value = "";
        //        pckListGrid.Rows[rows].Cells[3].Value = "";
        //        pckListGrid.Rows[rows].Cells[4].Value = "";
        //        pckListGrid.Rows[rows].Cells[5].Value = "";
        //    }
        //    pckListGrid.Refresh();
        //    pckListGrid.ClearSelection();
        //}

        //private void pckGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (pckGridInclServices.Rows[e.RowIndex].Cells[3].Value != null)
        //    {
        //        pckGridInclServices.Rows[e.RowIndex].Cells[4].Value = true;
        //        pckGridInclServices.Rows[e.RowIndex].Cells[4].ReadOnly = false;
        //    }
        //    else
        //    {
        //        pckGridInclServices.Rows[e.RowIndex].Cells[4].Value = false;
        //        pckGridInclServices.Rows[e.RowIndex].Cells[4].ReadOnly = true;
        //    }
        //}


        public static int PackListCount = 0;
        public static Boolean isPackageAppointment = false;

        private void btnBuyPackage_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrWhiteSpace(metroTextBox2.Text) ||
            //    String.IsNullOrWhiteSpace(metroTextBox4.Text))
            //{
            //    MetroMessageBox.Show(this.FindForm(), "Please Choose a Registered Customer or Create a Customer from the Customer's Tab", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    Packages pack = new Packages();
            //    string name = metroTextBox2.Text;
            //    double phone = Convert.ToDouble(metroTextBox4.Text);
            //    string email;
            //    int visit;
            //    string address;
            //    if (string.IsNullOrWhiteSpace(metroTextBox5.Text))
            //    {
            //        email = null;
            //    }
            //    else
            //    {
            //        email = metroTextBox5.Text;
            //    }

            //    if (string.IsNullOrWhiteSpace(metroTextBox8.Text))
            //    {
            //        visit = 0;
            //    }
            //    else
            //    {
            //        visit = Convert.ToInt32(metroTextBox8.Text);
            //    }

            //    if (string.IsNullOrWhiteSpace(metroTextBox29.Text))
            //    {
            //        address = null;
            //    }
            //    else
            //    {
            //        address = metroTextBox29.Text;
            //    }



            //    string packname = billComboChoosePck.SelectedItem.ToString();
            //    string packId = pack.GetPackageID(packname);

            //    Customers cus = new Customers();
            //    string cusId = cus.CustomerExsits(metroTextBox4.Text);

            //    if (cusId == null)
            //    {
            //        int cId = -1;
            //        Boolean success = cus.AddCustomer(cId, name, phone, email, visit, address);

            //        int CustomerId = Program.db.GetLastInsertedID("Customers");

            //        pack.BuyPackage(CustomerId, Convert.ToInt32(packId));



            //    }
            //    else
            //    {
            //        int cId = Convert.ToInt32(cusId);
            //        Boolean success = cus.AddCustomer(cId, name, phone, email, visit, address);
            //        pack.BuyPackage(cId, Convert.ToInt32(packId));


            //    }
            //    this.LoadSales();
            //    this.LoadCustomers();
            //}
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Package Combo in Customers

            //string selected = billComboChoosePck.SelectedItem.ToString();
            //Packages pack = new Packages();
            //string packId = pack.GetPackageID(selected);

            //SqlDataReader reader = pack.PackageServices(Convert.ToInt32(packId));

            //if (reader.HasRows)
            //{
            //    int row = 0;
            //    while (reader.Read())
            //    {
            //        SqlDataReader s = Program.db.get_where("Services", reader["ServiceId"].ToString());
            //        if (s.HasRows)
            //        {
            //            s.Read();
            //            billChoosePckGrid.Rows.Add();
            //            billChoosePckGrid.Rows[row].Cells[0].Value = s["Name"].ToString();
            //            billChoosePckGrid.Rows[row].Cells[1].Value = s["Price"].ToString();
            //            billChoosePckGrid.Rows[row].Cells[2].Value = reader["Sessions"].ToString();
            //            s.Close();
            //        }

            //        row++;
            //    }
            //}

            //reader.Close();

            //string price = pack.GetPackagePrice(packId);
            //lblPackagePrice.Text = price;
            ////btnBuyPackage.Enabled = true;
            //UIUtility.DisableButton(billBtnBuyPackage, false);
        }

        private bool bPackSaveTimerFired = false;
        private Timer pckTimer = new Timer();

        private void TogglePackStatus(bool bShow, bool bWarning = false, string text = "")
        {
            if (!bShow)
            {
                if (bPackSaveTimerFired)
                {
                    pckTimer.Stop();
                    bPackSaveTimerFired = false;
                }

                pckLnkStatus.Text = String.Empty;
                pckPanelStatus.Visible = false;
            }
            else
            {
                if (bWarning)
                {
                    pckLnkStatus.Image = Properties.Resources.warning_icon;
                    pckLnkStatus.NoFocusImage = Properties.Resources.warning_icon;
                }
                else
                {
                    pckLnkStatus.Image = Properties.Resources.thumb_up_small;
                    pckLnkStatus.NoFocusImage = Properties.Resources.thumb_up_small;

                    if (!bPackSaveTimerFired)
                    {
                        pckTimer.Interval = 2000;
                        pckTimer.Tick += PckTimer_Tick;
                        pckTimer.Start();
                        bPackSaveTimerFired = true;
                    }
                }

                pckLnkStatus.Text = text;
                pckPanelStatus.Visible = true;
            }
        }

        private void PckTimer_Tick(object sender, EventArgs e)
        {
            TogglePackStatus(false);
            ReinitializePackControls();
        }
    }
}
