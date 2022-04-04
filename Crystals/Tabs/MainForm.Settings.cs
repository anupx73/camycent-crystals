using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crystals.Controllers;
using MetroFramework;
using System.Data.SqlClient;

namespace Crystals
{
    partial class MainForm
    { }
    //{
    //    private void LoadUsers()
    //    {
    //        Settings s = new Settings();
    //        SqlDataReader reader = s.GetCompanyDetails();
    //        if (reader.HasRows)
    //        {
    //            reader.Read();
    //            if (!string.IsNullOrWhiteSpace(reader["Logo"].ToString()) && System.IO.File.Exists(reader["Logo"].ToString()))
    //            {
    //                pictureBoxPhoto.Image = new Bitmap(reader["Logo"].ToString());
    //                pictureBoxPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
    //            }
    //            settTxtName.Text = reader["Name"].ToString();
    //            settTxtPhone.Text = reader["Phone"].ToString();
    //            settTxtEmail.Text = reader["Email"].ToString();
    //            settTxtAddr.Text = reader["Address"].ToString();
    //            settTxtAdminEmail.Text = reader["AdminEmail"].ToString();
    //            settTxtSvcTax.Text = reader["STaxNumber"].ToString();
    //        }
    //        reader.Close();
    //        if (loggedinUserLevel == "Store Manager" || loggedinUserLevel == "Customer Manager")
    //        {
    //            return;
    //        }

    //        reader = Program.db.get("users");
    //        if (reader.HasRows)
    //        {
    //            try
    //            {
    //                while (reader.Read())
    //                {
    //                    settComboUser.Items.Add(reader["Username"]);
    //                }
    //            }
    //            catch (System.NullReferenceException exp)
    //            {
    //                Log.AppError(exp.Message);
    //            }
    //        }
    //    }

    //    private void metroLinkPhoto_Click(object sender, EventArgs e)
    //    {
    //        OpenFileDialog open = new OpenFileDialog();

    //        open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
    //        if (open.ShowDialog() == DialogResult.OK)
    //        {
    //            pictureBoxPhoto.Image = new Bitmap(open.FileName);
    //            pictureBoxPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
    //            string logoImageFile = open.FileName;
    //            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    //            folder = folder + "\\Crystals\\";

    //            if (!System.IO.Directory.Exists(folder))
    //            {
    //                System.IO.Directory.CreateDirectory(folder);
    //            }
    //            string ext = System.IO.Path.GetExtension(logoImageFile);
    //            folder = folder + "Logo" + ext;

    //            if (System.IO.File.Exists(folder))
    //            {
    //                System.IO.File.Delete(folder);
    //            }

    //            System.IO.File.Copy(logoImageFile, folder);

    //            Settings s = new Settings();
    //            s.UpdatePic(folder);
    //        }
    //    }

    //    private void buttonChangePass_Click(object sender, EventArgs e)   // user settings change password
    //    {
    //        string username = settComboUser.SelectedItem.ToString();
    //        string password = settTxtExtPass.Text;
    //        string n = settTxtNewPass.Text;

    //        users user = new users();
    //        if (user.ChangePass(username, password, n))
    //            MetroMessageBox.Show(this.FindForm(), "Success", "Change Password", MessageBoxButtons.OK);
    //        else
    //            MetroMessageBox.Show(this.FindForm(), "Failed", "Change Password", MessageBoxButtons.OK);

    //    }

    //    private void buttonAddUser_Click(object sender, EventArgs e)   // user settings Add new user 
    //    {
    //        string username = settTxtUser.Text;
    //        string password = settTxtPass.Text;
    //        string role = settComboUserLvl.SelectedItem.ToString();
    //        users user = new users();
    //        if (user.AddUser(username, password, role))
    //            MetroMessageBox.Show(this.FindForm(), "Added", "User", MessageBoxButtons.OK);
    //        else
    //            MetroMessageBox.Show(this.FindForm(), "Addition Failed", "User", MessageBoxButtons.OK);
    //    }

    //    private void buttonUpdateInfo_Click(object sender, EventArgs e)
    //    {
    //        if (String.IsNullOrWhiteSpace(settTxtName.Text) ||
    //            String.IsNullOrWhiteSpace(settTxtPhone.Text) ||
    //            String.IsNullOrWhiteSpace(settTxtSvcTax.Text) ||
    //            String.IsNullOrWhiteSpace(settTxtAddr.Text))
    //        {
    //            MetroMessageBox.Show(this.FindForm(), "Name, Phone, Address And Service Tax Number Cannot Be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //        else
    //        {
    //            string name = settTxtName.Text;
    //            string phone = settTxtPhone.Text;
    //            string email = settTxtEmail.Text;
    //            string address = settTxtAddr.Text;
    //            string adminEmail = settTxtAdminEmail.Text;
    //            string stno = settTxtSvcTax.Text;
    //            Settings s = new Settings();

    //            Boolean success = s.UpdateCompany(name, phone, email, address, adminEmail, stno);
    //            if (success)
    //            {
    //                MetroMessageBox.Show(this.FindForm(), "Details Saved", "Company Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //            }
    //            else
    //            {
    //                MetroMessageBox.Show(this.FindForm(), "Something Went Wrong, Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            }
    //        }
    //    }
    //}
}
