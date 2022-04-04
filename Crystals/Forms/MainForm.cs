using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MetroFramework.Controls;

namespace Crystals
{
    public partial class MainForm : Form
    {
        #region Class Members

        private const int HTCAPTION = 0x2;
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int CS_DBLCLKS = 0x8;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        private string loggedinUserLevel = string.Empty;
        private string loggedinUserName = string.Empty;

        #endregion

        public MainForm(string userLevel, string userName)
        {
            InitializeComponent();
            this.Text = "Crystals";
            this.Icon = Properties.Resources.app_icon;
            loggedinUserLevel = userLevel;
            loggedinUserName = userName;

            this.FormBorderStyle = FormBorderStyle.Sizable;
            //this.WindowState = FormWindowState.Maximized;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            //this.TopMost = true;

            ConfigPanel_Booking();
            ConfigPanel_Customer();
            ConfigPanel_Bill();
            ConfigPanel_Purchase();
            ConfigPanel_Package();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadUserTabs();

            //formLabelLoggedInUser.Text = "Logged in as: " + loggedinUserName + " (" + loggedinUserLevel + ")";

            //UIUtility.DisableButton(svcBtnSave, true);
            //UIUtility.DisableButton(billBtnBuyPackage, true);
            //UIUtility.DisableButton(billBtnCancel, true);
            //UIUtility.DisableButton(billBtnCheckOut, true);

            PopulateCurrentDateTimeForAppointment();
            LoadAppoinments();
            //LoadBilling();
            LoadPackages();
            LoadSales();
            LoadStocks();
            LoadTherapists();
            LoadServices();
            //LoadUsers();
            LoadCustomers();
            PopulateCategory();
            PopulatePurchase();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        // add the drop shadow flag for automatically drawing
        //        // a drop shadow around the form
        //        CreateParams cp = base.CreateParams;
        //        cp.ClassStyle |= CS_DROPSHADOW;
        //        cp.Style |= WS_MINIMIZEBOX;
        //        cp.ClassStyle |= CS_DBLCLKS;
        //        return cp;
        //    }
        //}

        //private void MainForm_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        ReleaseCapture();
        //        SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        //    }
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F4))
            {
                this.Close();
                Application.Exit();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lnkBranding_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.camycent.com");
        }

        private void linkSupport_Click(object sender, EventArgs e)
        {
            SupportForm.Instance.Show();
        }

        private void LoadUserTabs()
        {
            this.metroTabControl.SelectedTab = metroTabAppointment;
            if (loggedinUserLevel == "Store Manager")
            {
                //metroTabControl.TabPages.Remove(metroTabSettings);
                metroTabControl.TabPages.Remove(metroTabTherapist);
            }
            else if (loggedinUserLevel == "Customer Manager")
            {
                metroTabControl.TabPages.Remove(metroTabPackages);
                //metroTabControl.TabPages.Remove(metroTabSettings);
                metroTabControl.TabPages.Remove(metroTabTherapist);
            }
        }

        public static void ShowCalendar(DateTimePicker picker, MouseEventArgs clickEvent)
        {
            if (picker != null)
            {
                // Remove any existing event to prevent an infinite loop.
                //var suppressor = new EventSuppressor(picker);
                //suppressor.Suppress();

                // Get the position on the button.
                int x = picker.Width - 10;
                int y = picker.Height / 2;
                int lParam = x + y * 0x00010000;

                // Ignore if the calendar button was clicked
                if (clickEvent.X < picker.Width - 20)
                {
                    SendMessage(picker.Handle, WM_LBUTTONDOWN, 1, lParam);
                    SendMessage(picker.Handle, WM_LBUTTONUP, 1, lParam);
                }

                //suppressor.Resume();
            }
        }

        private void dateTime_MouseDown(object sender, MouseEventArgs e)
        {
            var control = (MetroDateTime)sender;
            ShowCalendar(control, e);
        }

        private void textBoxNumericKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            var textBoxControl = (MetroTextBox)sender;
            string controlText = textBoxControl.Text;
            if (e.KeyChar == '.' && controlText.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void listBoxPackService_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventAppoint_ServiceSelection(sender, e);
        }

        private void aptListBoxPacks_SelectedValueChanged(object sender, EventArgs e)
        {
            EventAppoint_PacksSelectionChanged(sender, e);
        }

        private void btnAppointGo_Click(object sender, EventArgs e)
        {
            EventAppoint_Go(sender, e);
        }

        private void aptLnkSave_Click(object sender, EventArgs e)
        {
            EventAppoint_Save(sender, e);
        }

        private void aptLnkClear_Click(object sender, EventArgs e)
        {
            ReInitializeAppointControls();
        }

        private void aptLnkCancel_Click(object sender, EventArgs e)
        {

        }

        private void thepRadioShowAll_CheckedChanged(object sender, EventArgs e)
        {
            populateCommisions();
        }

        private void thepRadioFilterDate_CheckedChanged(object sender, EventArgs e)
        {
            populateCommisions();
        }

        private void thepRadioFilterMonth_CheckedChanged(object sender, EventArgs e)
        {
            populateCommisions();
        }

        private void aptRadioShowAll_CheckedChanged(object sender, EventArgs e)
        {
            EventPopulateAppointments();
        }

        private void aptRadioFilter_CheckedChanged(object sender, EventArgs e)
        {
            EventPopulateAppointments();
        }

        private void aptDTFilter_ValueChanged(object sender, EventArgs e)
        {
            EventAppointDTChanged(sender, e);
        }

        private void purLnkCreateCat_Click(object sender, EventArgs e)
        {
            EventPurchase_NewCategoryView(true);
        }

        private void purLnkEditCat_Click(object sender, EventArgs e)
        {
            EventPurchase_NewCategoryView(false);
        }

        private void purLnkCreateItem_Click(object sender, EventArgs e)
        {
            EventPurchase_NewItemView(true);
        }

        private void purLnkEditItem_Click(object sender, EventArgs e)
        {
            EventPurchase_NewItemView(false);
        }

        private void svcLnkNew_Click(object sender, EventArgs e)
        {
            EventService_New(sender, e);
        }

        private void svcLnkSave_Click(object sender, EventArgs e)
        {
            EventService_Save(sender, e);
        }

        private void svcLnkDelete_Click(object sender, EventArgs e)
        {
            EventService_Delete(sender, e);
        }

        private void pckLnkNew_Click(object sender, EventArgs e)
        {
            EventPackage_New(sender, e);
        }

        private void pckLnkSave_Click(object sender, EventArgs e)
        {
            EventPackage_Save(sender, e);
        }

        private void pckLnkDelete_Click(object sender, EventArgs e)
        {
            EventDeletePackage(sender, e);
        }

        private void thepLnkSave_Click(object sender, EventArgs e)
        {
            EventTherapist_Save(sender, e);
        }

        private void thepLnkDelete_Click(object sender, EventArgs e)
        {
            EventTherapist_Delete(sender, e);
        }

        private void purLnkNew_Click(object sender, EventArgs e)
        {
            ReinitializeNewCategoryControls();
        }

        private void purLnkSave_Click(object sender, EventArgs e)
        {
            EventPurchase_Save();
        }

        private void purLnkDelete_Click(object sender, EventArgs e)
        {

        }

        private void custLnkSave_Click(object sender, EventArgs e)
        {
            EventCustomer_Save(sender, e);
        }

        private void salLnkDelete_Click(object sender, EventArgs e)
        {
            EventDeleteSales(sender, e);
        }

        private void aptTextBoxHR_TextChanged(object sender, EventArgs e)
        {
            EventAppoint_HRChanged(sender, e);
        }

        private void aptTextBoxMIN_TextChanged(object sender, EventArgs e)
        {
            EventAppoint_MINChanged(sender, e);
        }

        private void aptDTAppointDate_ValueChanged(object sender, EventArgs e)
        {
            EventAptDTChanged(sender, e);
        }

        private void aptTxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            EventAptTxtSearchKeyDown(sender, e);
        }

        private void purComboNewItemCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventPurchase_ItemCategoryChanged();
        }
      
        private void purComboItemCat_SelectionChanged(object sender, EventArgs e)
        {
            EventPurchase_CatagoryChanged();
        }

        private void purLnkBack_Click(object sender, EventArgs e)
        {
            EventPurchase_NewPurchaseView();
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            EventPurchase_CalculateTotalPrice();
        }

        private void purTxtPurQuantity_TextChanged(object sender, EventArgs e)
        {
            EventPurchase_CalculateTotalPrice();
        }

        private void EventPurchase_ControlKeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                purLnkSave.PerformClick();
            }
        }

        private void purPanelNewItem_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                purLnkSave.PerformClick();
            }
        }

        private void aptBtnHRUp_Click(object sender, EventArgs e)
        {
            EventAppoint_HRUp();
        }

        private void aptBtnHRDown_Click(object sender, EventArgs e)
        {
            EventAppoint_HRdown();
        }

        private void aptBtnMinUp_Click(object sender, EventArgs e)
        {
            EventAppoint_MinUp();
        }

        private void aptBtnMinDown_Click(object sender, EventArgs e)
        {
            EventAppoint_MinDown();
        }

        private void aptComboTherapist_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventAppoint_ThepSelectionChanged();
        }

        private void thepLnkNew_Click(object sender, EventArgs e)
        {
            ReInitializeThreparistControls();
        }

        private void aptTxtPhone_Leave(object sender, EventArgs e)
        {
            Validate_PhoneField(sender);
        }

        private void txtAppointCustEmail_Leave(object sender, EventArgs e)
        {
            Validate_EmailField(sender);
        }

        private void purListGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EventPurchase_Update(e.RowIndex);
        }

        private void svcItemRqdGrid_EndEdit(object sender, DataGridViewCellEventArgs e)
        {
            EventService_ItemRqdGrid_EndEdit(sender, e);
        }

        private void pckLnkCreateService_Click(object sender, EventArgs e)
        {
            TogglePackageEntryView(PackageEntryView.CreateService);
        }

        private void pckLnkCreatePack_Click(object sender, EventArgs e)
        {
            TogglePackageEntryView(PackageEntryView.CreatePackage);
        }
        
        private void svcListGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EventService_ListGrid_CellClick(sender, e);
        }

        private void custLnkNavCustProf_Click(object sender, EventArgs e)
        {
            ToggleCustomerEntryView(CutomerEntryView.CustomerProfile);
        }

        private void custLnkNavBuyPack_Click(object sender, EventArgs e)
        {
            ToggleCustomerEntryView(CutomerEntryView.BuyPackage);
        }

        private void custLnkNavBusinessPromo_Click(object sender, EventArgs e)
        {
            ToggleCustomerEntryView(CutomerEntryView.BusinessPromotion);
        }

        private void custLnkNavCustComm_Click(object sender, EventArgs e)
        {
            ToggleCustomerEntryView(CutomerEntryView.CustomerCommunication);
        }

        private void aptRadioExistCust_Click(object sender, EventArgs e)
        {
            EventAppoint_ExistingCustomer();
        }

        private void aptRadioNewCust_Click(object sender, EventArgs e)
        {
            EventAppoint_NewCustomer();
        }

        private void aptBtnGo_Click(object sender, EventArgs e)
        {
            EventAppoint_Go(sender, e);
        }

        private void aptLnkTopNav_Click(object sender, EventArgs e)
        {
            ReInitializeAppointControls();
        }
    }
}
