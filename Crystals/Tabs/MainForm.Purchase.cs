using System.Windows.Forms;
using Crystals.Controllers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Linq;

namespace Crystals
{
    public partial class MainForm
    {
        private enum PurchaseEntryView
        {
            NewPurchase,
            NewCategory,
            NewItem
        };

        private PurchaseEntryView m_PurchaseEntryView = PurchaseEntryView.NewPurchase;
        Purchase m_PurchaseHandler = null;
        Catagory m_CategoryHandler = null;
        Items m_ItemHandler = null;
        Dictionary<int, string> m_CategoryList = null;
        Dictionary<int, string> m_ItemList = null;
        int m_PurchaseId = -1;
        int m_CatagoryId = -1;
        int m_ItemId = -1;

        private void BackToNewItem()
        {
            purPanelNewCat.Visible = false;
            purPanelNewPurchase.Visible = true;
        }

        private void ConfigPanel_Purchase()
        {
            purPanelNewPurchase.Dock = DockStyle.Fill;
            purPanelNewCat.Dock = DockStyle.Fill;
            purPanelNewItem.Dock = DockStyle.Fill;
            purDTPurchase.Value = DateTime.Today;
        }

        private void EventPurchase_NewCategoryView(bool bNew)
        {
            if (!bNew && purComboPurCat.Text.Length <= 0)
            {
                TogglePurchaseStatus(true, true, "Please select a Category to edit!");
                //MetroFramework.MetroMessageBox.Show(this, "Please select a Category to edit!", 100);
                return;
            }
            m_PurchaseEntryView = PurchaseEntryView.NewCategory;

            if (!bNew)
            {
                CreateCategoryHandler();
                m_CatagoryId = Convert.ToInt32((purComboPurCat.SelectedItem as ComboBoxItem).Value);

                SqlDataReader reader = m_CategoryHandler.GetCatagory(m_CatagoryId.ToString());
                if (reader.HasRows)
                {
                    reader.Read();
                    purTxtNewCatName.Text = reader["Name"].ToString();
                    purComboNewCatMeasur.Text = reader["Unit"].ToString();
                    purTxtCatStockMed.Text = reader["MediumStockAlert"].ToString();
                    purTxtCatStockLow.Text = reader["LowStockAlert"].ToString();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Database error: Failed to pull Category from database!");
                }
                reader.Close();
                purLnkNewCatNav.Text = "New Purchase > Edit Category";
            }
            else
            {
                purTxtNewCatName.Text = "";
                purComboNewCatMeasur.Text = "";
                purTxtCatStockMed.Text = "";
                purTxtCatStockLow.Text = "";
                purLnkNewCatNav.Text = "New Purchase > New Category";
                purComboNewCatMeasur.DropDownStyle = ComboBoxStyle.DropDownList;
                purComboNewCatMeasur.SelectedIndex = -1;
                purComboNewCatMeasur.PromptText = "Choose Here";
            }

            purTxtNewCatName.WithError = false;
            purTxtCatStockMed.WithError = false;
            purTxtCatStockLow.WithError = false;

            purPanelStatus.Visible = false;
            purPanelNewPurchase.Visible = false;
            purPanelNewItem.Visible = false;
            purPanelNewCat.Visible = true;
            purLnkBack.Visible = true;

            purTxtNewCatName.Focus();
        }

        private void EventPurchase_NewItemView(bool bNew)
        {
            if (bNew && purComboPurCat.Text.Length <= 0)
            {
                //MetroFramework.MetroMessageBox.Show(this, "Please select a Category first", 100);
                TogglePurchaseStatus(true, true, "Please select a Category to first!");
                return;
            }
            if (!bNew && purComboPurItem.Text.Length <= 0)
            {
                //MetroFramework.MetroMessageBox.Show(this, "Please select a Item to edit!", 100);
                TogglePurchaseStatus(true, true, "Please select a Item to edit!");
                return;
            }

            m_PurchaseEntryView = PurchaseEntryView.NewItem;
            PopulateCategory();

            if (!bNew)
            {
                CreateItemHandler();
                m_CatagoryId = Convert.ToInt32((purComboPurCat.SelectedItem as ComboBoxItem).Value);
                m_ItemId = Convert.ToInt32((purComboPurItem.SelectedItem as ComboBoxItem).Value);

                SqlDataReader reader = m_ItemHandler.GetItem(m_ItemId.ToString());
                if (reader.HasRows)
                {
                    reader.Read();
                    purTxtNewItemName.Text = reader["Name"].ToString();
                    purTxtItemStockMed.Text = reader["MediumStockAlert"].ToString();
                    purTxtItemStockLow.Text = reader["LowStockAlert"].ToString();
                    int iReusable = Convert.ToInt32(reader["ReUseable"]);
                    if (iReusable == 1)
                    {
                        purRadioItemReuseNo.Checked = false;
                        purRadioItemReuseYes.Checked = true;
                    }
                    else
                    {
                        purRadioItemReuseYes.Checked = false;
                        purRadioItemReuseNo.Checked = true;
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Database error: Failed to pull Item from database!");
                }
                reader.Close();
                purLnkNewItemNav.Text = "New Purchase > Edit Item";
            }
            else
            {
                CreateCategoryHandler();
                purTxtNewItemName.Text = "";
                int medStock = m_CategoryHandler.GetMediumStockAlert(m_CatagoryId);
                int lowStock = m_CategoryHandler.GetLowStockAlert(m_CatagoryId);
                purTxtItemStockLow.Text = lowStock.ToString();
                purTxtItemStockMed.Text = medStock.ToString();
                purComboNewItemCat.Text = m_CategoryList[m_CatagoryId];
                purLnkNewItemNav.Text = "New Purchase > New Item";
            }

            purTxtNewItemName.WithError = false;
            purTxtItemStockMed.WithError = false;
            purTxtItemStockLow.WithError = false;

            purPanelStatus.Visible = false;
            purPanelNewPurchase.Visible = false;
            purPanelNewCat.Visible = false;
            purPanelNewItem.Visible = true;
            purLnkBack.Visible = true;

            purTxtNewItemName.Focus();
        }

        private void EventPurchase_NewPurchaseView()
        {
            purLnkBack.Visible = false;
            purPanelNewCat.Visible = false;
            purPanelNewItem.Visible = false;
            purPanelStatus.Visible = false;
            purPanelNewPurchase.Visible = true;
            m_PurchaseEntryView = PurchaseEntryView.NewPurchase;

            //Select the last added item on combo box
            if (m_CategoryList != null && m_CategoryList.Count > 0 && m_CatagoryId != -1)
            {
                purComboPurCat.Text = m_CategoryList[m_CatagoryId];
            }
            if (m_ItemList != null && m_ItemList.Count > 0)
            {
                purComboPurItem.SelectedIndex = 0;
            }
        }

        private bool ValidateNewCatFields()
        {
            if (purTxtNewCatName.Text.Length <= 0)
            {
                purTxtNewCatName.WithError = true;
                TogglePurchaseStatus(true, true, "Category name cannot be blank");
                return false;
            }
            if (purComboNewCatMeasur.Text.Length <= 0)
            {
                purComboNewCatMeasur.PromptText = "Please Select";
                TogglePurchaseStatus(true, true, "Category measurement cannot be blank");
                return false;
            }
            if (purTxtCatStockMed.Text.Length <= 0)
            {
                purTxtCatStockMed.WithError = true;
                TogglePurchaseStatus(true, true, "Medium stock cannot be blank");
                return false;
            }
            if (purTxtCatStockLow.Text.Length <= 0)
            {
                purTxtCatStockLow.WithError = true;
                TogglePurchaseStatus(true, true, "Low stock cannot be blank");
                return false;
            }
            if (Convert.ToInt32(purTxtCatStockMed.Text) < Convert.ToInt32(purTxtCatStockLow.Text))
            {
                purTxtCatStockMed.WithError = true;
                purTxtCatStockLow.WithError = true;
                TogglePurchaseStatus(true, true, "Medium stock cannot be lower than Low stock");
                return false;
            }
            if (Convert.ToInt32(purTxtCatStockMed.Text) == Convert.ToInt32(purTxtCatStockLow.Text))
            {
                purTxtCatStockMed.WithError = true;
                purTxtCatStockLow.WithError = true;
                TogglePurchaseStatus(true, true, "Medium stock and Low stock cannot be same");
                return false;
            }

            return true;
        }

        private bool ValidateNewItemFields()
        {
            if (purComboNewItemCat.Text.Length <= 0)
            {
                purComboNewItemCat.Text = "Please Select";
                TogglePurchaseStatus(true, true, "Choose a category to continue");
                return false;
            }
            if (purTxtNewItemName.Text.Length <= 0)
            {
                purTxtNewItemName.WithError = true;
                TogglePurchaseStatus(true, true, "Item name cannot be blank");
                return false;
            }
            if (purTxtItemStockMed.Text.Length <= 0)
            {
                purTxtItemStockMed.WithError = true;
                TogglePurchaseStatus(true, true, "Medium stock cannot be blank");
                return false;
            }
            if (purTxtItemStockLow.Text.Length <= 0)
            {
                purTxtItemStockLow.WithError = true;
                TogglePurchaseStatus(true, true, "Low stock cannot be blank");
                return false;
            }
            if (Convert.ToInt32(purTxtItemStockMed.Text) < Convert.ToInt32(purTxtItemStockLow.Text))
            {
                purTxtItemStockMed.WithError = true;
                purTxtItemStockLow.WithError = true;
                TogglePurchaseStatus(true, true, "Medium stock cannot be lower than Low stock");
                return false;
            }
            if (Convert.ToInt32(purTxtItemStockMed.Text) == Convert.ToInt32(purTxtItemStockLow.Text))
            {
                purTxtItemStockMed.WithError = true;
                purTxtItemStockLow.WithError = true;
                TogglePurchaseStatus(true, true, "Medium stock and Low stock cannot be same");
                return false;
            }

            return true;
        }

        private bool ValidateNewPurchaseFields()
        {
            if (purComboPurCat.Text.Length <= 0)
            {
                TogglePurchaseStatus(true, true, "Choose a category to continue");
                return false;
            }
            if (purComboPurItem.Text.Length <= 0)
            {
                TogglePurchaseStatus(true, true, "Choose a item to continue");
                return false;
            }
            //if (String.IsNullOrWhiteSpace(txtVendor.Text))
            //{
            //    TogglePurchaseStatus(true, true, "Vendor name cannot be blank");
            //    return false; 
            //}
            if (String.IsNullOrWhiteSpace(purTxtPurUnit.Text))
            {
                TogglePurchaseStatus(true, true, "Unit cannot be blank");
                return false;
            }
            if (String.IsNullOrWhiteSpace(purTxtPurQuantity.Text))
            {
                TogglePurchaseStatus(true, true, "Quantity cannot be blank");
                return false;
            }
            if (String.IsNullOrWhiteSpace(purTxtPurUnitPrice.Text))
            {
                TogglePurchaseStatus(true, true, "Unit Price cannot be blank");
                return false;
            }

            return true;
        }

        private void EventPurchase_Save()
        {
            switch (m_PurchaseEntryView)
            {
                case PurchaseEntryView.NewPurchase:
                    {
                        if (!ValidateNewPurchaseFields())
                        {
                            break;
                        }

                        CreatePurchaseHandler();

                        //Collecting Data for save
                        string selectedCat = purComboPurCat.Text;
                        string selectedItem = purComboPurItem.Text;
                        int cat_id = m_CategoryList.FirstOrDefault(x => x.Value.Contains(selectedCat)).Key;
                        int item_id = m_ItemList.FirstOrDefault(x => x.Value.Contains(selectedItem)).Key;
                        string vendor = txtVendor.Text;
                        DateTime purDate = purDTPurchase.Value;
                        double unit = Convert.ToDouble(purTxtPurUnit.Text);
                        int quantity = Convert.ToInt32(purTxtPurQuantity.Text);
                        double UnitPrice = Convert.ToDouble(purTxtPurUnitPrice.Text);
                        double TotalPrice = Convert.ToDouble(purTxtPurTotalPrice.Text);

                        //Calling save Function
                        m_PurchaseId = m_PurchaseHandler.AddPurchase(m_PurchaseId, cat_id, item_id, vendor, purDate, unit, quantity, UnitPrice, TotalPrice);

                        if (m_PurchaseId == -1)
                        {
                            //Save Failed
                            MetroFramework.MetroMessageBox.Show(this, "Failed to create new Purchase");
                        }
                        else
                        {
                            //Success
                            PopulatePurchase();
                            TogglePurchaseStatus(true, false, "Purchase Added Successfully");
                        }
                    }
                    break;

                case PurchaseEntryView.NewCategory:
                    {
                        if (!ValidateNewCatFields())
                        {
                            break;
                        }

                        CreateCategoryHandler();

                        int iReturn = m_CategoryHandler.AddCatagory(m_CatagoryId,
                                           purTxtNewCatName.Text,
                                           purComboNewCatMeasur.Text,
                                           purTxtCatStockMed.Text,
                                           purTxtCatStockLow.Text);

                        m_CatagoryId = iReturn;
                        if (iReturn != -1)
                        {
                            m_PurchaseEntryView = PurchaseEntryView.NewCategory;
                            PopulateCategory();
                            //EventPurchase_NewPurchaseView();
                            TogglePurchaseStatus(true, false, "Category added successfully");
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Failed to create new Category");
                        }

                        // m_CatagoryId = -1;
                    }
                    break;

                case PurchaseEntryView.NewItem:
                    {
                        if (!ValidateNewItemFields())
                        {
                            break;
                        }

                        CreateItemHandler();

                        int iReturn = m_ItemHandler.AddItem(m_ItemId,
                                              m_CatagoryId,
                                              purTxtNewItemName.Text,
                                              purTxtItemStockMed.Text,
                                              purTxtItemStockLow.Text,
                                              purRadioItemReuseYes.Checked);

                        m_ItemId = iReturn;
                        if (iReturn != -1)
                        {
                            PopulateItems();
                            //EventPurchase_NewPurchaseView();
                            TogglePurchaseStatus(true, false, "Item added successfully");
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Failed to create new Item");
                        }

                        //m_ItemId = -1;
                        //m_CatagoryId = -1;
                    }
                    break;
            }
        }

        private void CreatePurchaseHandler()
        {
            if (m_PurchaseHandler == null)
            {
                m_PurchaseHandler = new Purchase();
            }
        }

        private void CreateCategoryHandler()
        {
            if (m_CategoryHandler == null)
            {
                m_CategoryHandler = new Catagory();
            }
        }

        private void CreateItemHandler()
        {
            if (m_ItemHandler == null)
            {
                m_ItemHandler = new Items();
            }
        }

        private void PopulateCategory()
        {
            CreateCategoryHandler();

            if (m_CategoryList == null)
            {
                m_CategoryList = new Dictionary<int, string>();
            }

            m_CategoryList = m_CategoryHandler.GetCatagoryDropDown();

            MetroFramework.Controls.MetroComboBox comboBoxCategory = null;
            if (m_PurchaseEntryView == PurchaseEntryView.NewItem)
            {
                comboBoxCategory = purComboNewItemCat;
            }
            else
            {
                comboBoxCategory = purComboPurCat;
            }

            if (comboBoxCategory != null)
            {
                comboBoxCategory.Items.Clear();
                foreach (KeyValuePair<int, string> entry in m_CategoryList)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = entry.Value;
                    item.Value = entry.Key;
                    comboBoxCategory.Items.Add(item);
                }
            }

            if (m_PurchaseEntryView == PurchaseEntryView.NewItem)
            {
                purComboNewItemCat.Text = purComboPurCat.Text;
            }

            PopulateUnitText();
        }

        private void PopulateUnitText()
        {
            if (m_CatagoryId != -1)
            {
                string catUnit = m_CategoryHandler.GetUnit(m_CatagoryId.ToString());
                if (!String.IsNullOrEmpty(catUnit))
                {
                    purLabelPurUnit.Text = "Unit (" + catUnit + ")";
                }
            }
        }

        private void PopulateItems()
        {
            CreateItemHandler();

            if (m_ItemList == null)
            {
                m_ItemList = new Dictionary<int, string>();
            }

            m_CatagoryId = Convert.ToInt32((purComboPurCat.SelectedItem as ComboBoxItem).Value);
            m_ItemList = m_ItemHandler.GetItemDropDown(m_CatagoryId.ToString());

            purComboPurItem.Items.Clear();
            if (m_ItemList.Count > 0)
            {
                foreach (KeyValuePair<int, string> entry in m_ItemList)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = entry.Value;
                    item.Value = entry.Key;
                    purComboPurItem.Items.Add(item);
                }
            }

            PopulateUnitText();
        }

        private void EventPurchase_ItemCategoryChanged()
        {
            m_CatagoryId = Convert.ToInt32((purComboNewItemCat.SelectedItem as ComboBoxItem).Value);
        }

        private void EventPurchase_CatagoryChanged()
        {
            PopulateItems();
        }

        private void EventPurchase_CalculateTotalPrice()
        {
            if (purTxtPurQuantity.Text.Length <= 0 || purTxtPurUnitPrice.Text.Length <= 0)
            {
                if (purTxtPurTotalPrice.Text.Length > 0)
                {
                    purTxtPurTotalPrice.Text = "";
                }
                return;
            }

            double totalPrice = (Convert.ToInt32(purTxtPurQuantity.Text) * Convert.ToDouble(purTxtPurUnitPrice.Text));
            purTxtPurTotalPrice.Text = String.Format("{0:0.##}", totalPrice);
        }

        private bool bPurSaveTimerFired = false;
        private Timer purTimer = new Timer();

        private void TogglePurchaseStatus(bool bShow, bool bWarning = false, string text = "")
        {
            if (!bShow)
            {
                if (bPurSaveTimerFired)
                {
                    purTimer.Stop();
                    bPurSaveTimerFired = false;
                }

                purLnkStatus.Text = String.Empty;
                purPanelStatus.Visible = false;
            }
            else
            {
                if (bWarning)
                {
                    purLnkStatus.Image = Properties.Resources.warning_icon;
                    purLnkStatus.NoFocusImage = Properties.Resources.warning_icon;
                }
                else
                {
                    purLnkStatus.Image = Properties.Resources.thumb_up_small;
                    purLnkStatus.NoFocusImage = Properties.Resources.thumb_up_small;

                    if (!bPurSaveTimerFired)
                    {
                        purTimer.Interval = 2000;
                        purTimer.Tick += PurTimer_Tick;
                        purTimer.Start();
                        bPurSaveTimerFired = true;
                    }
                }

                purLnkStatus.Text = text;
                purPanelStatus.Visible = true;
            }
        }

        private void PurTimer_Tick(object sender, EventArgs e)
        {
            TogglePurchaseStatus(false);
            switch (m_PurchaseEntryView)
            {
                case PurchaseEntryView.NewPurchase:
                    {
                        ReinitializeNewPurchaseControls();
                    }
                    break;

                case PurchaseEntryView.NewCategory:
                    {
                        ReinitializeNewCategoryControls();
                    }
                    break;

                case PurchaseEntryView.NewItem:
                    {
                        ReinitializeNewItemControls();
                    }
                    break;
            }
        }

        private void ReinitializeNewPurchaseControls()
        {
            purComboPurCat.PromptText = "Choose Here";
            purComboPurCat.DropDownStyle = ComboBoxStyle.DropDownList;
            purComboPurCat.SelectedIndex = -1;

            purComboPurItem.PromptText = "Choose Here";
            purComboPurItem.DropDownStyle = ComboBoxStyle.DropDownList;
            purComboPurItem.SelectedIndex = -1;

            purDTPurchase.Value = DateTime.Today;
            txtVendor.Text = "";
            purTxtPurUnit.Text = "";
            purTxtPurQuantity.Text = "";
            purTxtPurUnitPrice.Text = "";
            purTxtPurTotalPrice.Text = "";
        }

        private void ReinitializeNewCategoryControls()
        {
            purComboNewCatMeasur.PromptText = "Choose Here";
            purComboNewCatMeasur.DropDownStyle = ComboBoxStyle.DropDownList;
            purComboNewCatMeasur.SelectedIndex = -1;
            purTxtCatStockMed.Text = "";
            purTxtCatStockLow.Text = "";
            purTxtNewCatName.Text = "";
            purTxtNewCatName.Focus();
        }

        private void ReinitializeNewItemControls()
        {
            //purComboNewItemCat.Text = m_CategoryList[m_CatagoryId];
            purTxtItemStockLow.Text = m_CategoryHandler.GetMediumStockAlert(m_CatagoryId).ToString();
            purTxtItemStockMed.Text = m_CategoryHandler.GetLowStockAlert(m_CatagoryId).ToString();
            purTxtNewItemName.Text = "";
            purTxtNewItemName.Focus();
        }

        public void PopulatePurchase()
        {
            CreatePurchaseHandler();
            CreateCategoryHandler();
            CreateItemHandler();
            SqlDataReader reader = m_PurchaseHandler.GetPurchases();
            purListGrid.Rows.Clear();
            int row = 0;
            purListGrid.AllowUserToAddRows = true;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    purListGrid.Rows.Add();
                    purListGrid.Rows[row].Cells[0].Value = reader["Id"].ToString();
                    purListGrid.Rows[row].Cells[1].Value = Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd");
                    purListGrid.Rows[row].Cells[2].Value = m_CategoryHandler.GetCatagoryName(Convert.ToInt32(reader["CatagoryId"]));
                    purListGrid.Rows[row].Cells[3].Value = reader["Vendor"].ToString();
                    purListGrid.Rows[row].Cells[4].Value = m_ItemHandler.GetItemName(reader["ItemId"].ToString());
                    purListGrid.Rows[row].Cells[5].Value = reader["Unit"].ToString();
                    purListGrid.Rows[row].Cells[6].Value = reader["Quantity"].ToString();
                    purListGrid.Rows[row].Cells[7].Value = String.Format("{0:0.##}", Convert.ToDouble(reader["UnitPrice"]));
                    purListGrid.Rows[row].Cells[8].Value = String.Format("{0:0.##}", Convert.ToDouble(reader["TotalPrice"]));
                    row++;
                }   
                reader.Close();
                purListGrid.AllowUserToAddRows = false;
            }
        }

        public void EventPurchase_Update(int rowIndex)
        {
            //Fetching Row Data
            int Id = Convert.ToInt32(purListGrid.Rows[rowIndex].Cells[0].Value);

            //Get Purchase data
            CreatePurchaseHandler();
            SqlDataReader reader = m_PurchaseHandler.GetPurchase(Id.ToString());
            if (reader.HasRows)
            {
                reader.Read();
                CreateCategoryHandler();
                CreateItemHandler();
                m_PurchaseId = Convert.ToInt32(reader["Id"]);

                purComboPurCat.Text = m_CategoryList[Convert.ToInt32(reader["CatagoryId"])].ToString();
                PopulateItems();
                purComboPurItem.Text = m_ItemHandler.GetItemName(reader["ItemId"].ToString());
                txtVendor.Text = reader["Vendor"].ToString();
                purDTPurchase.Value = Convert.ToDateTime(reader["Date"]);
                purTxtPurUnit.Text = reader["Unit"].ToString();
                purTxtPurQuantity.Text = reader["Quantity"].ToString();
                purTxtPurUnitPrice.Text = string.Format("{0:0.##}", Convert.ToDouble(reader["UnitPrice"]));
                purTxtPurTotalPrice.Text = string.Format("{0:0.##}", Convert.ToDouble(reader["TotalPrice"]));


            }
        }


    }
}
