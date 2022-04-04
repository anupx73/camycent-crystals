using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Crystals.Controllers;
using Crystals.Models;
using System.Runtime.InteropServices;
using MetroFramework.Controls;

namespace Crystals
{
    public partial class LoginForm : Form
    {
        private const int HTCAPTION = 0x2;
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int CS_DBLCLKS = 0x8;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();

        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Crystals - Login";
            this.Icon = Properties.Resources.app_icon;
            if (txtUsername.Text.Length < UIUtility.UserPwdMinLength ||
                txtPassword.Text.Length < UIUtility.UserPwdMinLength)
            {
                UIUtility.DisableButton(btnLogin, true);
                btnLogin.Enabled = false;
            }
        }

        private void Textboxes_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length >= UIUtility.UserPwdMinLength &&
                txtPassword.Text.Length >= UIUtility.UserPwdMinLength && 
                !String.IsNullOrEmpty(metroComboBoxUserLevel.Text))
            {
                UIUtility.DisableButton(btnLogin, false);
            }
            else
            {
                UIUtility.DisableButton(btnLogin, true);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.lblLoginError.Visible = false;

            string UserLevel=metroComboBoxUserLevel.SelectedItem.ToString();
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            users login = new users();
            Boolean success =  login.AuthUser(Username, Password, UserLevel);
            if(success)
            {
                this.Hide();
                MainForm ob = new MainForm(UserLevel, Username);
                ob.Show();
            }
            else
            {
                this.lblLoginError.Visible = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Activate();
            txtUsername.Focus();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void lnkSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.camycent.com");
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

        private void Cmbuserlevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(metroComboBoxUserLevel.Text))
            {
                UIUtility.DisableButton(btnLogin, true);
            }
            else
            {
                if (txtUsername.Text.Length >= UIUtility.UserPwdMinLength && 
                    txtPassword.Text.Length >= UIUtility.UserPwdMinLength)
                {
                    UIUtility.DisableButton(btnLogin, false);
                }
            }
        }

        private void LoginForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            var control = (MetroTextBox)sender;
            if (control.Text.Length < UIUtility.UserPwdMinLength)
            {
                control.WithError = true;
            }
        }
    }
}
