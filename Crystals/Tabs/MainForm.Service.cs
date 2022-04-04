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
        Int32 m_ServiceID = -1;

        private void ConfigPanel_Service()
        {
            svcGridItemRqd.Size = new System.Drawing.Size(210, pckPanelCreateSvc.Size.Height - svcGridItemRqd.Location.Y);
        }

        public void populateServices()
        {
            aptListGrid.Rows.Clear();

            SqlDataReader reader = Program.db.get_desc("Services");

            if (reader.HasRows)
            {
                int rows = 0;
                while (reader.Read())
                {
                    aptListGrid.Rows.Add();
                    pckPackageListGrid.Rows[rows].Cells[0].Value = reader["Id"];
                    pckPackageListGrid.Rows[rows].Cells[1].Value = reader["Name"];
                    pckPackageListGrid.Rows[rows].Cells[1].Value = reader["Price"];
                    pckPackageListGrid.Rows[rows].Cells[1].Value = reader["Description"];
                    rows++;

                }
            }


        }

        private void LoadServices()      // implement service load here
        {
            if (loggedinUserLevel == "Customer Manager")
                return;

            //DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();

            //CheckBox chk = new CheckBox();
            //CheckboxColumn.Width = 20;
            //CheckboxColumn.ReadOnly = true;

            //metroGrid8.Columns.Add(CheckboxColumn);
            Services ob = new Services();

            SqlDataReader reader = Program.db.get_desc("Services");
            if (reader.HasRows)
            {
                try
                {
                    int rows = 0;
                    pckPackageListGrid.AllowUserToAddRows = true;
                    pckPackageListGrid.Rows.Clear();


                    while (reader.Read())
                    {
                        pckPackageListGrid.Rows.Add();
                        pckPackageListGrid.Rows[rows].Cells[0].Value = reader["Id"];
                        pckPackageListGrid.Rows[rows].Cells[1].Value = reader["Name"];
                        pckPackageListGrid.Rows[rows].Cells[2].Value = reader["AHTime"];
                        pckPackageListGrid.Rows[rows].Cells[3].Value = reader["Price"];
                        pckPackageListGrid.Rows[rows].Cells[4].Value = reader["Description"];
                        rows++;
                    }

                    pckPackageListGrid.AllowUserToAddRows = false;


                }
                catch (System.NullReferenceException exp)
                {
                    Log.AppError(exp.Message);
                }
            }
            else
            {

            }

            pckPackageListGrid.ClearSelection();
            reader = Program.db.get_desc("Items");
            if (reader.HasRows)
            {
                try
                {
                    int rows = 0;
                    svcGridItemRqd.Rows.Clear();
                    svcGridItemRqd.AllowUserToAddRows = true;
                    while (reader.Read())
                    {


                        svcGridItemRqd.Rows.Add();

                        svcGridItemRqd.Rows[rows].Cells[0].Value = reader["Id"].ToString();
                        svcGridItemRqd.Rows[rows].Cells[1].Value = reader["Name"].ToString();
                        Items item = new Items();
                        string unit = item.GetUnit(reader["Id"].ToString());
                        if (unit == "LTRS")
                        {
                            svcGridItemRqd.Rows[rows].Cells[2].Value = "ML";
                        }
                        else
                        {
                            svcGridItemRqd.Rows[rows].Cells[2].Value = unit;
                        }
                        rows++;
                    }
                    svcGridItemRqd.AllowUserToAddRows = false;
                }
                catch (System.NullReferenceException exp)
                {
                    Log.AppError(exp.Message);

                }
            }

            reader.Close();
        }

        private bool Validate_Service()
        {
            if (String.IsNullOrWhiteSpace(svcTxtName.Text))
            {
                svcTxtName.WithError = true;
                ToggleServiceStatus(true, true, "Service name cannot be blank");
                return false;
            }
            if (String.IsNullOrWhiteSpace(svcTxtDuration.Text))
            {
                svcTxtDuration.WithError = true;
                ToggleServiceStatus(true, true, "Duration field cannot be blank");
                return false;
            }
            if (String.IsNullOrWhiteSpace(svcTxtCost.Text))
            {
                svcTxtCost.WithError = true;
                ToggleServiceStatus(true, true, "Cost field cannot be blank");
                return false;
            }

            //if (String.IsNullOrWhiteSpace(svcTxtDesc.Text))
            //{
            //}

            return true;
        }
            
        private void EventService_Save(object sender, EventArgs e)
        {
            if (!Validate_Service())
            {
                return;
            }

            string ServiceName = svcTxtName.Text;
            int duration = Convert.ToInt32(svcTxtDuration.Text);
            double cost = Convert.ToDouble(svcTxtCost.Text);
            string description = svcTxtDesc.Text;
            Services ob = new Services();
            //THis Dictionay contains the ItemID and the Quantity.

            Dictionary<int, double> ServiceData = new Dictionary<int, double>();
            int c = svcGridItemRqd.RowCount;
            int rows = 0;
            double quant = 0;
            int Id = 0;
            foreach (DataGridViewRow row in svcGridItemRqd.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[4];
                if (Convert.ToBoolean(chk.Value) == true)
                {
                    try
                    {
                        string Quantity = svcGridItemRqd.Rows[rows].Cells[3].Value.ToString();
                        string id = svcGridItemRqd.Rows[rows].Cells[0].Value.ToString();
                        string unit = svcGridItemRqd.Rows[rows].Cells[2].Value.ToString();
                        bool result1 = Int32.TryParse(id, out Id);
                        bool result2 = Double.TryParse(Quantity, out quant);

                        //This is Not an Update
                        //In Case of an Update u get the Values in ML so u cant divide it with 1000 again !
                        //Handle it asi
                        if (result1 && result2)
                        {
                            if (unit == "ML")
                            {
                                quant = quant / 1000;
                                ServiceData.Add(Id, quant);
                                svcGridItemRqd.EndEdit();
                            }
                            else
                            {
                                ServiceData.Add(Id, quant);
                                svcGridItemRqd.EndEdit();
                            }
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
            Services service = new Services();
            Boolean success = service.RegisterService(m_ServiceID, ServiceName, duration, cost, description, ServiceData);
            LoadServices();
            this.LoadAppoinments();
            this.LoadPackages();

            //ReinitializeServiceControls();
            ToggleServiceStatus(true, false, "Service added successfully");
        }

        private void ReinitializeServiceControls()
        {
            m_ServiceID = -1;
            svcTxtDesc.Text = "";
            svcTxtName.Text = "";
            svcTxtDuration.Text = "";
            svcTxtCost.Text = "";
            svcTxtName.Focus();
        }

        private void EventService_New(object sender, EventArgs e)
        {
            ReinitializeServiceControls();

            int rows = 0;
            foreach (DataGridViewRow row in svcGridItemRqd.Rows)
            {
                svcGridItemRqd.Rows[rows].Cells[3].Value = "";
                svcGridItemRqd.Rows[rows].Cells[4].Value = false;
                rows++;
            }
        }

        private void EventService_Delete(object sender, EventArgs e)
        {
            DataGridViewRow row = this.pckPackageListGrid.CurrentRow;
            string idStr = row.Cells["Column37"].Value.ToString();
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
            Services obj = new Services();
            obj.DeRegisterService(id);

            this.populateServices();

            pckPackageListGrid.Refresh();
            pckPackageListGrid.ClearSelection();
        }

        private void EventService_ListGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.UseWaitCursor = true;
                //Getting Row Index
                //buttonAddService.Enabled = true;
                //UIUtility.DisableButton(svcBtnSave, false);
                int row = e.RowIndex;

                //Fetching Row Data
                int Id = Convert.ToInt32(pckPackageListGrid.Rows[row].Cells[0].Value);
                string Name = pckPackageListGrid.Rows[row].Cells[1].Value.ToString();
                double Duration = Convert.ToDouble(pckPackageListGrid.Rows[row].Cells[2].Value);
                double Cost = Convert.ToDouble(pckPackageListGrid.Rows[row].Cells[3].Value);
                string Desc = pckPackageListGrid.Rows[row].Cells[4].Value.ToString();

                //Setting data in the Add/Update Form

                svcTxtName.Text = Name;
                svcTxtDuration.Text = Duration.ToString();
                svcTxtCost.Text = Cost.ToString();
                svcTxtDesc.Text = Desc;
                //txtServiceId.Text = Id.ToString();
                m_ServiceID = Id;
                //svcBtnSave.Text = "Update Service";
                //Getting the Data for Required Service
                Services service = new Services();
                int iRows = 0;
                foreach (DataGridViewRow iRow in svcGridItemRqd.Rows)
                {
                    svcGridItemRqd.Rows[iRows].Cells[3].Value = "";
                    svcGridItemRqd.Rows[iRows].Cells[4].Value = false;
                    iRows++;
                }
                //Setting Data in the Items Required Grid.
                // SqlDataReader ItemReader = Program.db.get_where("items", Id.ToString());
                int Itemid;

                try
                {
                    int rows = 0;
                    foreach (DataGridViewRow iRowz in svcGridItemRqd.Rows)
                    {
                        SqlDataReader reader = service.ItemResourceReqd(Id);
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                DataGridViewRow gridrow = (DataGridViewRow)svcGridItemRqd.Rows[0].Clone();
                                Itemid = Convert.ToInt32(reader["ItemId"]);
                                if (Convert.ToInt32(svcGridItemRqd.Rows[rows].Cells[0].Value) == Itemid)
                                {
                                    //taking a new reader which contains the item information of that specific selected item id
                                    SqlDataReader ItemReader = Program.db.get_where("items", Itemid.ToString());
                                    while (ItemReader.Read())
                                    {
                                        svcGridItemRqd.Rows[rows].Cells[0].Value = ItemReader["Id"];
                                        svcGridItemRqd.Rows[rows].Cells[1].Value = ItemReader["ItemName"];
                                        if (ItemReader["Unit"].ToString() == "LTRS")
                                        {
                                            svcGridItemRqd.Rows[rows].Cells[2].Value = "ML";
                                            double a = Convert.ToDouble(reader["Amount"]);
                                            a = a * 1000;
                                            if (a != 0)
                                            {
                                                svcGridItemRqd.Rows[rows].Cells[4].Value = true;
                                            }
                                            svcGridItemRqd.Rows[rows].Cells[3].Value = a.ToString();
                                        }
                                        else
                                        {
                                            svcGridItemRqd.Rows[rows].Cells[2].Value = ItemReader["Unit"];

                                            svcGridItemRqd.Rows[rows].Cells[3].Value = reader["Amount"];
                                            if (reader["Amount"] != null)
                                            {
                                                svcGridItemRqd.Rows[rows].Cells[4].Value = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        reader.Close();
                        rows++;
                    }
                }
                catch (System.NullReferenceException exp)
                {
                    Log.AppError(exp.Message);
                }

                this.UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                Log.AppError(ex.Message);
                return;
            }
        }

        private void EventService_ItemRqdGrid_EndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (svcGridItemRqd.Rows[e.RowIndex].Cells[3].Value != null)
            {
                svcGridItemRqd.Rows[e.RowIndex].Cells[4].Value = true;
                svcGridItemRqd.Rows[e.RowIndex].Cells[4].ReadOnly = false;
            }
            else
            {
                svcGridItemRqd.Rows[e.RowIndex].Cells[4].Value = false;
                svcGridItemRqd.Rows[e.RowIndex].Cells[4].ReadOnly = true;
            }
        }

        private bool bSvcSaveTimerFired = false;
        private Timer svcTimer = new Timer();

        private void ToggleServiceStatus(bool bShow, bool bWarning = false, string text = "")
        {
            if (!bShow)
            {
                if (bSvcSaveTimerFired)
                {
                    svcTimer.Stop();
                    bSvcSaveTimerFired = false;
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

                    if (!bSvcSaveTimerFired)
                    {
                        svcTimer.Interval = 2000;
                        svcTimer.Tick += SvcTimer_Tick;
                        svcTimer.Start();
                        bSvcSaveTimerFired = true;
                    }
                }

                pckLnkStatus.Text = text;
                pckPanelStatus.Visible = true;
            }
        }

        private void SvcTimer_Tick(object sender, EventArgs e)
        {
            ReinitializeServiceControls();
            ToggleServiceStatus(false);
        }

    }
}
