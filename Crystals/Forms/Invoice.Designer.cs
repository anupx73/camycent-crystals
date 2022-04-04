namespace Crystals
{
    partial class Invoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.inLogo = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.inCusName = new MetroFramework.Controls.MetroLabel();
            this.inCusPh = new MetroFramework.Controls.MetroLabel();
            this.metroGrid1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.inTotal = new MetroFramework.Controls.MetroTextBox();
            this.inDPer = new MetroFramework.Controls.MetroTextBox();
            this.inDisVal = new MetroFramework.Controls.MetroTextBox();
            this.inSTax = new MetroFramework.Controls.MetroTextBox();
            this.inPayable = new MetroFramework.Controls.MetroTextBox();
            this.inCName = new MetroFramework.Controls.MetroLabel();
            this.InCPh = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.inSTno = new MetroFramework.Controls.MetroLabel();
            this.inDate = new MetroFramework.Controls.MetroLabel();
            this.inComAdd = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbPaymentMode = new MetroFramework.Controls.MetroComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.InvoiceNoLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.TherapistNameLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.inLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // inLogo
            // 
            this.inLogo.Location = new System.Drawing.Point(551, 3);
            this.inLogo.Name = "inLogo";
            this.inLogo.Size = new System.Drawing.Size(126, 98);
            this.inLogo.TabIndex = 0;
            this.inLogo.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(18, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(24, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "To";
            // 
            // inCusName
            // 
            this.inCusName.AutoSize = true;
            this.inCusName.Location = new System.Drawing.Point(18, 32);
            this.inCusName.Name = "inCusName";
            this.inCusName.Size = new System.Drawing.Size(106, 19);
            this.inCusName.TabIndex = 3;
            this.inCusName.Text = "Customer Name";
            // 
            // inCusPh
            // 
            this.inCusPh.AutoSize = true;
            this.inCusPh.Location = new System.Drawing.Point(18, 57);
            this.inCusPh.Name = "inCusPh";
            this.inCusPh.Size = new System.Drawing.Size(107, 19);
            this.inCusPh.TabIndex = 4;
            this.inCusPh.Text = "Customer Phone";
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToDeleteRows = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.White;
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeight = 25;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Item,
            this.Desc,
            this.Price});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.White;
            this.metroGrid1.Location = new System.Drawing.Point(3, 134);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersVisible = false;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.metroGrid1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(674, 191);
            this.metroGrid1.TabIndex = 5;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.FillWeight = 10F;
            this.id.HeaderText = "#";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item.FillWeight = 30F;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // Desc
            // 
            this.Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Desc.FillWeight = 40F;
            this.Desc.HeaderText = "Description";
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.FillWeight = 20F;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(416, 354);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(38, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Total";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(416, 373);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(73, 19);
            this.metroLabel5.TabIndex = 7;
            this.metroLabel5.Text = "Discount %";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(416, 392);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(87, 19);
            this.metroLabel6.TabIndex = 8;
            this.metroLabel6.Text = "Discount Amt";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(416, 411);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(74, 19);
            this.metroLabel7.TabIndex = 9;
            this.metroLabel7.Text = "Service Tax";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(415, 430);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(88, 19);
            this.metroLabel8.TabIndex = 10;
            this.metroLabel8.Text = "Total Payable";
            // 
            // inTotal
            // 
            this.inTotal.Lines = new string[0];
            this.inTotal.Location = new System.Drawing.Point(551, 350);
            this.inTotal.MaxLength = 32767;
            this.inTotal.Name = "inTotal";
            this.inTotal.PasswordChar = '\0';
            this.inTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inTotal.SelectedText = "";
            this.inTotal.Size = new System.Drawing.Size(108, 23);
            this.inTotal.TabIndex = 11;
            this.inTotal.UseCustomBackColor = true;
            this.inTotal.UseSelectable = true;
            // 
            // inDPer
            // 
            this.inDPer.Lines = new string[0];
            this.inDPer.Location = new System.Drawing.Point(551, 370);
            this.inDPer.MaxLength = 32767;
            this.inDPer.Name = "inDPer";
            this.inDPer.PasswordChar = '\0';
            this.inDPer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inDPer.SelectedText = "";
            this.inDPer.Size = new System.Drawing.Size(108, 23);
            this.inDPer.TabIndex = 12;
            this.inDPer.UseCustomBackColor = true;
            this.inDPer.UseSelectable = true;
            this.inDPer.TextChanged += new System.EventHandler(this.inDPer_TextChanged);
            this.inDPer.Click += new System.EventHandler(this.inDPer_Click);
            // 
            // inDisVal
            // 
            this.inDisVal.Lines = new string[0];
            this.inDisVal.Location = new System.Drawing.Point(551, 389);
            this.inDisVal.MaxLength = 32767;
            this.inDisVal.Name = "inDisVal";
            this.inDisVal.PasswordChar = '\0';
            this.inDisVal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inDisVal.SelectedText = "";
            this.inDisVal.Size = new System.Drawing.Size(108, 23);
            this.inDisVal.TabIndex = 13;
            this.inDisVal.UseCustomBackColor = true;
            this.inDisVal.UseSelectable = true;
            // 
            // inSTax
            // 
            this.inSTax.Lines = new string[0];
            this.inSTax.Location = new System.Drawing.Point(551, 410);
            this.inSTax.MaxLength = 32767;
            this.inSTax.Name = "inSTax";
            this.inSTax.PasswordChar = '\0';
            this.inSTax.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inSTax.SelectedText = "";
            this.inSTax.Size = new System.Drawing.Size(108, 23);
            this.inSTax.TabIndex = 14;
            this.inSTax.UseCustomBackColor = true;
            this.inSTax.UseSelectable = true;
            this.inSTax.TextChanged += new System.EventHandler(this.inSTax_TextChanged);
            this.inSTax.Click += new System.EventHandler(this.inSTax_Click);
            // 
            // inPayable
            // 
            this.inPayable.Lines = new string[0];
            this.inPayable.Location = new System.Drawing.Point(551, 432);
            this.inPayable.MaxLength = 32767;
            this.inPayable.Name = "inPayable";
            this.inPayable.PasswordChar = '\0';
            this.inPayable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inPayable.SelectedText = "";
            this.inPayable.Size = new System.Drawing.Size(108, 23);
            this.inPayable.TabIndex = 15;
            this.inPayable.UseCustomBackColor = true;
            this.inPayable.UseSelectable = true;
            // 
            // inCName
            // 
            this.inCName.AutoSize = true;
            this.inCName.Location = new System.Drawing.Point(18, 354);
            this.inCName.Name = "inCName";
            this.inCName.Size = new System.Drawing.Size(102, 19);
            this.inCName.TabIndex = 16;
            this.inCName.Text = "CompanyName";
            // 
            // InCPh
            // 
            this.InCPh.AutoSize = true;
            this.InCPh.Location = new System.Drawing.Point(18, 392);
            this.InCPh.Name = "InCPh";
            this.InCPh.Size = new System.Drawing.Size(107, 19);
            this.InCPh.TabIndex = 18;
            this.InCPh.Text = "Company Phone";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(18, 411);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(127, 19);
            this.metroLabel2.TabIndex = 19;
            this.metroLabel2.Text = "Service Tax Number";
            // 
            // inSTno
            // 
            this.inSTno.AutoSize = true;
            this.inSTno.Location = new System.Drawing.Point(161, 411);
            this.inSTno.Name = "inSTno";
            this.inSTno.Size = new System.Drawing.Size(79, 19);
            this.inSTno.TabIndex = 20;
            this.inSTno.Text = "0000000000";
            // 
            // inDate
            // 
            this.inDate.AutoSize = true;
            this.inDate.Location = new System.Drawing.Point(20, 80);
            this.inDate.Name = "inDate";
            this.inDate.Size = new System.Drawing.Size(36, 19);
            this.inDate.TabIndex = 21;
            this.inDate.Text = "Date";
            // 
            // inComAdd
            // 
            this.inComAdd.AutoSize = true;
            this.inComAdd.Location = new System.Drawing.Point(18, 373);
            this.inComAdd.Name = "inComAdd";
            this.inComAdd.Size = new System.Drawing.Size(113, 19);
            this.inComAdd.TabIndex = 22;
            this.inComAdd.Text = "CompanyAddress";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(20, 434);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(95, 19);
            this.metroLabel3.TabIndex = 23;
            this.metroLabel3.Text = "PaymentMode";
            // 
            // cbPaymentMode
            // 
            this.cbPaymentMode.FormattingEnabled = true;
            this.cbPaymentMode.ItemHeight = 23;
            this.cbPaymentMode.Items.AddRange(new object[] {
            "Cash",
            "Card"});
            this.cbPaymentMode.Location = new System.Drawing.Point(164, 431);
            this.cbPaymentMode.Name = "cbPaymentMode";
            this.cbPaymentMode.Size = new System.Drawing.Size(86, 29);
            this.cbPaymentMode.TabIndex = 24;
            this.cbPaymentMode.UseSelectable = true;
            this.cbPaymentMode.SelectedIndexChanged += new System.EventHandler(this.cbPaymentMode_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Crystals.Properties.Resources.th;
            this.pictureBox1.Location = new System.Drawing.Point(0, 487);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(680, 23);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TherapistNameLabel);
            this.panel2.Controls.Add(this.metroLabel9);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.cbPaymentMode);
            this.panel2.Controls.Add(this.metroLabel3);
            this.panel2.Controls.Add(this.inComAdd);
            this.panel2.Controls.Add(this.inDate);
            this.panel2.Controls.Add(this.inSTno);
            this.panel2.Controls.Add(this.metroLabel2);
            this.panel2.Controls.Add(this.InCPh);
            this.panel2.Controls.Add(this.inCName);
            this.panel2.Controls.Add(this.inPayable);
            this.panel2.Controls.Add(this.inSTax);
            this.panel2.Controls.Add(this.inDisVal);
            this.panel2.Controls.Add(this.inDPer);
            this.panel2.Controls.Add(this.inTotal);
            this.panel2.Controls.Add(this.metroLabel8);
            this.panel2.Controls.Add(this.metroLabel7);
            this.panel2.Controls.Add(this.metroLabel6);
            this.panel2.Controls.Add(this.metroLabel5);
            this.panel2.Controls.Add(this.metroLabel4);
            this.panel2.Controls.Add(this.metroGrid1);
            this.panel2.Controls.Add(this.inCusPh);
            this.panel2.Controls.Add(this.inCusName);
            this.panel2.Controls.Add(this.metroLabel1);
            this.panel2.Controls.Add(this.inLogo);
            this.panel2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(5, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(680, 561);
            this.panel2.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(260, 623);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(153, 26);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // InvoiceNoLabel
            // 
            this.InvoiceNoLabel.AutoSize = true;
            this.InvoiceNoLabel.Location = new System.Drawing.Point(133, 29);
            this.InvoiceNoLabel.Name = "InvoiceNoLabel";
            this.InvoiceNoLabel.Size = new System.Drawing.Size(27, 19);
            this.InvoiceNoLabel.TabIndex = 26;
            this.InvoiceNoLabel.Text = "No";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(18, 335);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(102, 19);
            this.metroLabel9.TabIndex = 26;
            this.metroLabel9.Text = "Therapist Name";
            // 
            // TherapistNameLabel
            // 
            this.TherapistNameLabel.AutoSize = true;
            this.TherapistNameLabel.Location = new System.Drawing.Point(164, 335);
            this.TherapistNameLabel.Name = "TherapistNameLabel";
            this.TherapistNameLabel.Size = new System.Drawing.Size(0, 0);
            this.TherapistNameLabel.TabIndex = 27;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(693, 664);
            this.ControlBox = false;
            this.Controls.Add(this.InvoiceNoLabel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Invoice";
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "INVOICE";
            this.Load += new System.EventHandler(this.Invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.PictureBox inLogo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel inCusName;
        private MetroFramework.Controls.MetroLabel inCusPh;
        private System.Windows.Forms.DataGridView metroGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox inTotal;
        private MetroFramework.Controls.MetroTextBox inDPer;
        private MetroFramework.Controls.MetroTextBox inDisVal;
        private MetroFramework.Controls.MetroTextBox inSTax;
        private MetroFramework.Controls.MetroTextBox inPayable;
        private MetroFramework.Controls.MetroLabel inCName;
        private MetroFramework.Controls.MetroLabel InCPh;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel inSTno;
        private MetroFramework.Controls.MetroLabel inDate;
        private MetroFramework.Controls.MetroLabel inComAdd;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cbPaymentMode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private MetroFramework.Controls.MetroLabel InvoiceNoLabel;
        private MetroFramework.Controls.MetroLabel TherapistNameLabel;
        private MetroFramework.Controls.MetroLabel metroLabel9;
    }
}