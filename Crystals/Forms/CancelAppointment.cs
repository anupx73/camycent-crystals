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
using System.IO;
using System.Data.SqlClient;
using MetroFramework;
using Crystals.Controllers;

namespace Crystals
{
    public partial class CancelAppointment : MetroForm
    {
        public CancelAppointment()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string remarks = txtRemarks.Text;
            int id = Program.db.GetLastInsertedID("CancelAppointments");
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Remarks", "'" + remarks + "'");
            Program.db.update("CancelAppointments", d, " where id=" + id.ToString());

            //get app Id
            SqlDataReader reader = Program.db.get_where("CancelAppointments", id.ToString());
            if(reader.HasRows)
            {
                reader.Read();
                Customers cus = new Customers();
                Appointments app = new Appointments();
                string CustomerId = app.GetCustomerId(reader["AppId"].ToString());
                string cusname = cus.GetCustomerName(CustomerId.ToString());

                string msg = "Date: " + DateTime.Now.ToString("yyyy-MM-dd") + "Customer Name: " + cusname + " Reason: " + remarks;
                AdminNotify.SendEmail("Appointment Canceled", msg);
                reader.Close();

            }
            this.Hide();
            return;
            
            
                

        
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
