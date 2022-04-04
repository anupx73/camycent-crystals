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
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Data.SqlClient;
using Crystals.Controllers;



namespace Crystals
{
    public partial class Invoice : MetroForm
    {
        public int AppId;
        public int SalesId;
        public double total = 0.0;
        public Invoice()
        {
            InitializeComponent();
        }

        public Invoice(int SalesId, int CustomerId, int AppointmentId, double Amount, List<int> ServiceIds, bool frompackage)
        {
            this.SalesId = SalesId;
            InitializeComponent();

            InvoiceNoLabel.Text = SalesId.ToString();
            AppId = AppointmentId;
            string therapistid=null;
            populate();

            

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("AppointmentId", AppointmentId.ToString());
            SqlDataReader reader;
            // DataGridViewRow row = new DataGridViewRow();
            int rows = 0;
            // reader = Program.db.get_where("ServiceAppointments", AppointmentId.ToString());
            if (frompackage == false)
            {
               SqlDataReader therapistreader = Program.db.get_where("Appointments", AppointmentId.ToString());
                if (therapistreader.HasRows)
                {
                    therapistreader.Read();
                    therapistid = therapistreader["TherapistId"].ToString();
                }

                therapistreader = Program.db.get_where("Therapists", therapistid);
                if (therapistreader.HasRows)
                {
                    therapistreader.Read();
                    TherapistNameLabel.Text = therapistreader["Name"].ToString();
                }
                reader = Program.db.get_where_custom("ServiceAppointments", d);
               
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

                                while (reader1.Read())
                                {
                                    //DataGridViewRow row = (DataGridViewRow)metroGrid1.Rows[0].Clone();
                                    DataGridViewRow row = new DataGridViewRow();

                                    metroGrid1.Rows.Add(row);

                                    metroGrid1.Rows[rows].Cells[0].Value = rows;
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
            }
            else
            {
                // Package Invoice

                Packages p = new Packages();
                metroGrid1.Rows.Add();
                metroGrid1.Rows[rows].Cells[0].Value = rows;
                metroGrid1.Rows[rows].Cells[1].Value = p.GetPackageName(AppointmentId.ToString());
                metroGrid1.Rows[rows].Cells[2].Value = p.GetPackageDesc(AppointmentId.ToString());
                metroGrid1.Rows[rows].Cells[3].Value = p.GetPackagePrice(AppointmentId.ToString());
                double price = Convert.ToDouble(p.GetPackagePrice(AppointmentId.ToString()));

                total = total + price;
                metroLabel9.Text = "";


            }

            inTotal.Text = total.ToString();
            inSTax.Text = "14.5";
            double totalwithtax = total + (total * .145);
            inPayable.Text = totalwithtax.ToString();
            reader = Program.db.get_where("Customers", CustomerId.ToString());

            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    inCusName.Text = reader["Name"].ToString();
                    inCusPh.Text = reader["Phone"].ToString();
                    inDate.Text = System.DateTime.Today.ToString("yyyy-MM-dd");
                }
            }
            else
            {

            }
            reader.Close();



        }
        private System.IO.Stream streamToPrint;

        string streamType;


        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]

        private static extern bool BitBlt
        (

             IntPtr hdcDest, // handle to destination DC

             int nXDest, // x-coord of destination upper-left corner

             int nYDest, // y-coord of destination upper-left corner

             int nWidth, // width of destination rectangle

             int nHeight, // height of destination rectangle

             IntPtr hdcSrc, // handle to source DC

             int nXSrc, // x-coordinate of source upper-left corner

             int nYSrc, // y-coordinate of source upper-left corner

             System.Int32 dwRop // raster operation code

         );





        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            System.Drawing.Image image = System.Drawing.Image.FromStream(this.streamToPrint);

            int x = e.MarginBounds.X;

            int y = e.MarginBounds.Y;

            int width = image.Width;

            int height = image.Height;

            if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
            {

                width = e.MarginBounds.Width;

                height = image.Height * e.MarginBounds.Width / image.Width;

            }

            else
            {

                height = e.MarginBounds.Height;

                width = image.Width * e.MarginBounds.Height / image.Height;

            }

            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);

            e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
        }



        // Bitmap memoryImage;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics g1 = this.CreateGraphics();

            Image MyImage = new Bitmap(panel2.ClientRectangle.Width, panel2.ClientRectangle.Height, g1);

            //CaptureScreen();

            Graphics g2 = Graphics.FromImage(MyImage);

            IntPtr dc1 = g1.GetHdc();

            IntPtr dc2 = g2.GetHdc();

            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);

            g1.ReleaseHdc(dc1);

            g2.ReleaseHdc(dc2);

            string path = Directory.GetCurrentDirectory();

            MyImage.Save(path + "/PrintPage.jpg", ImageFormat.Jpeg);

            FileStream fileStream = new FileStream(path + "/PrintPage.jpg", FileMode.Open, FileAccess.Read);

            StartPrint(fileStream, "Image");

            // fileStream.Close();

            //Create a PDF 
            iTextSharp.text.Rectangle pageSize = null;
            string currFolder = System.IO.Directory.GetCurrentDirectory();
            string foldername = DateTime.Today.ToString("MMMM.yyyy");
            string desFolder = currFolder + "\\invoice\\" + foldername;
            long timestamp = DateTime.Today.Ticks;
            if (Directory.Exists(desFolder) == false)
            {
                Directory.CreateDirectory(desFolder);
            }
            //Get Customer Name

            Customers cus = new Customers();
            Appointments app = new Appointments();
            string cusId = app.GetCustomerId(this.AppId.ToString());
            string cusName = cus.GetCustomerName(cusId);

            string dstFilename = desFolder + "\\" + cusName + "_" + timestamp.ToString() + ".pdf";

            using (var srcImage = new Bitmap(fileStream))
            {
                pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
            }
            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(fileStream.Name);
                document.Add(image);
                document.Close();

                File.WriteAllBytes(dstFilename, ms.ToArray());
            }

            if (System.IO.File.Exists(path + "/PrintPage.jpg"))
            {

                System.IO.File.Delete(@"c:\PrintPage.jpg");

            }

            //Save the PDF path in Invoice Table

            Sales sale = new Sales();
            sale.SetInvoicePath(SalesId.ToString(), dstFilename);

            //Save The Discount Given against the Sale
            //inDisVal.Text

            if (!string.IsNullOrWhiteSpace(inDisVal.Text))
            {
                sale.SetDiscount(SalesId.ToString(), Convert.ToDouble(inDisVal.Text));
            }
            fileStream.Close();
            this.Hide();
        }


        public void StartPrint(Stream streamToPrint, string streamType)
        {

            this.printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

            this.streamToPrint = streamToPrint;

            this.streamType = streamType;

            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();

            PrintDialog1.AllowSomePages = true;

            PrintDialog1.ShowHelp = true;

            PrintDialog1.Document = printDoc;

            DialogResult result = PrintDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {

                printDoc.Print();

                //docToPrint.Print();

            }
        }







        public void populate()
        {
            SqlDataReader reader = Program.db.get("Company");
            string logo = "";
            string name = "";
            string ph = "";
            string address = "";
            if (reader.HasRows)
            {
                reader.Read();
                logo = reader["Logo"].ToString();
                name = reader["Name"].ToString();
                ph = reader["Phone"].ToString();
                address = reader["Address"].ToString();
                inSTno.Text = reader["STaxNumber"].ToString();
            }
            reader.Close();
            if (string.IsNullOrWhiteSpace(logo) == false && File.Exists(logo) == true)
            {
                inLogo.ImageLocation = logo;
            }
            inComAdd.MaximumSize = new Size(100, 100);
            inComAdd.AutoSize = true;
            inCName.Text = name;
            InCPh.Text = ph;
            inComAdd.Text = address;
            cbPaymentMode.SelectedItem = "Cash";
            metroGrid1.ClearSelection();


        }

        private void Invoice_Load(object sender, EventArgs e)
        {


        }

        private void inDPer_Click(object sender, EventArgs e)
        {

        }


        private void inSTax_Click(object sender, EventArgs e)
        {

        }

        private void inDPer_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inDPer.Text) == false)
            {

                string dis = inDPer.Text;
                double discount = Convert.ToDouble(dis);
                if (discount <= 20)
                {
                    double discountval = (discount / 100) * total;
                    discountval = Math.Round(discountval, 2);

                    inDisVal.Text = discountval.ToString();
                    double tax = Convert.ToDouble(inSTax.Text);
                    discountval = Convert.ToDouble(inDisVal.Text);
                    double disprice = Math.Round((total - discountval), 2);
                    double totalpay = disprice + (disprice * (tax / 100));
                    totalpay = Math.Round(totalpay, 2);
                    inPayable.Text = totalpay.ToString();
                }
                else
                {
                    inDisVal.Text = "0";
                    inDPer.Text = "0";

                    MessageBox.Show("Discount Cannot be more than 20%", "INVALID DISCOUNT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                inDisVal.Text = "0";
                inDPer.Text = "0";
            }
        }

        private void inSTax_TextChanged(object sender, EventArgs e)
        {


        }

        private void cbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customers cus = new Customers();
            Appointments app = new Appointments();
            string cusId = app.GetCustomerId(this.AppId.ToString());
            Dictionary<string, string> SalesData = new Dictionary<string, string>();
            SalesData.Add("PaymentMode", "'" + cbPaymentMode.SelectedItem.ToString() + "'");
            Program.db.update("Sales", SalesData, " where Id=" + this.SalesId.ToString());

        }

    }
}
