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
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace Crystals
{
    public partial class InvoiceForm : MetroForm
    {

        private PrintDocument printDocument1 = new PrintDocument();
        Bitmap memoryImage;
        private string documentContents;
        private string stringToPrint;
        public double total = 0.0;

        public InvoiceForm()
        {

            InitializeComponent();

        }

        public InvoiceForm(int CustomerId, int AppointmentId, double Amount, List<int> ServiceIds, bool frompackage)
        {
            InitializeComponent();

            SqlDataReader reader = Program.db.get("Company");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //  pictureBox1.ImageLocation = reader["Logo"].ToString();
                    metroLabel1.Text = reader["Name"].ToString();
                    metroLabel2.Text = reader["Address"].ToString();
                    metroLabel3.Text = reader["Phone"].ToString();
                }
                reader.Close();
            }

            reader = Program.db.get_where("Customers", CustomerId.ToString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    metroLabel4.Text = reader["Name"].ToString();
                    metroLabel5.Text = reader["Phone"].ToString();
                    metroLabel6.Text = reader["Address"].ToString();
                }
                reader.Close();
            }
            reader = Program.db.get_where("ServiceAppointments", AppointmentId.ToString());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string serviceid = reader["ServiceId"].ToString();
                    SqlDataReader reader1 = Program.db.get_where("Services", serviceid);
                    
                    if (reader1.HasRows)
                    {
                        try
                        {
                            int rows = 0;
                            while (reader1.Read())
                            {
                                DataGridViewRow row = (DataGridViewRow)metroGrid1.Rows[0].Clone();

                                metroGrid1.Rows.Add(row);

                                metroGrid1.Rows[rows].Cells[0].Value = row;
                                metroGrid1.Rows[rows].Cells[1].Value = reader1["Name"];
                                metroGrid1.Rows[rows].Cells[2].Value = reader1["Description"];
                                metroGrid1.Rows[rows].Cells[3].Value = reader1["Price"];
                                double price = Convert.ToDouble(reader1["Price"]);

                                total = total + price;

                                rows++;
                            }


                        }
                        catch (System.NullReferenceException exp)
                        {
                            Log.AppError(exp.Message);
                        }
                    }
                    else
                    {

                    }


                }
            }

            reader.Close();

            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

        }






        private void print_Click(object sender, EventArgs e)
        {
            // printDocument1.Print();

            CaptureScreen();
            PrintDialog pdi = new PrintDialog();
            pdi.Document = printDocument1;
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DocumentName = "Invoice";
                printDocument1.Print();
            }
            else
            {
                MessageBox.Show("Print Cancelled");
            }

        }

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();

            Size s = printpanel.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y + 20, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
          System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        public void populate_invoice()
        {

        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            populate_invoice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double tax = Convert.ToDouble(metroTextBox1.Text);
            double discount = Convert.ToDouble(metroTextBox2.Text);
            total = total + total * (tax / 100);
            total = total - discount;
        }




    }
}
