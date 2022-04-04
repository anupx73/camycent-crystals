namespace Crystals
{
    partial class CancelAppointment
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.pcbxLogo = new System.Windows.Forms.PictureBox();
            this.metroLabelNote = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelVer = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.txtRemarks = new MetroFramework.Controls.MetroTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 8);
            this.panel1.TabIndex = 59;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = global::Crystals.Properties.Resources.pad_top;
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Location = new System.Drawing.Point(488, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(137, 25);
            this.panel2.TabIndex = 60;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = global::Crystals.Properties.Resources.btn_close;
            this.buttonClose.Location = new System.Drawing.Point(104, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(26, 20);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // pcbxLogo
            // 
            this.pcbxLogo.Image = global::Crystals.Properties.Resources.logo;
            this.pcbxLogo.Location = new System.Drawing.Point(20, 26);
            this.pcbxLogo.Name = "pcbxLogo";
            this.pcbxLogo.Size = new System.Drawing.Size(199, 82);
            this.pcbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbxLogo.TabIndex = 62;
            this.pcbxLogo.TabStop = false;
            // 
            // metroLabelNote
            // 
            this.metroLabelNote.AutoSize = true;
            this.metroLabelNote.ForeColor = System.Drawing.Color.Gray;
            this.metroLabelNote.Location = new System.Drawing.Point(20, 156);
            this.metroLabelNote.Name = "metroLabelNote";
            this.metroLabelNote.Size = new System.Drawing.Size(211, 19);
            this.metroLabelNote.TabIndex = 63;
            this.metroLabelNote.Text = "Crystals Salon && Spa Management";
            this.metroLabelNote.UseCustomForeColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.ForeColor = System.Drawing.Color.Gray;
            this.metroLabel4.Location = new System.Drawing.Point(20, 187);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(52, 19);
            this.metroLabel4.TabIndex = 64;
            this.metroLabel4.Text = "Version";
            this.metroLabel4.UseCustomForeColor = true;
            // 
            // metroLabelVer
            // 
            this.metroLabelVer.AutoSize = true;
            this.metroLabelVer.ForeColor = System.Drawing.Color.Gray;
            this.metroLabelVer.Location = new System.Drawing.Point(78, 187);
            this.metroLabelVer.Name = "metroLabelVer";
            this.metroLabelVer.Size = new System.Drawing.Size(36, 19);
            this.metroLabelVer.TabIndex = 65;
            this.metroLabelVer.Text = "1.1.0";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.metroLabel2.Location = new System.Drawing.Point(252, 64);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(59, 19);
            this.metroLabel2.TabIndex = 66;
            this.metroLabel2.Text = "Remarks";
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(17)))), ((int)(((byte)(65)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(435, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 26);
            this.button2.TabIndex = 68;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Lines = new string[0];
            this.txtRemarks.Location = new System.Drawing.Point(348, 64);
            this.txtRemarks.MaxLength = 32767;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PasswordChar = '\0';
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.Size = new System.Drawing.Size(240, 84);
            this.txtRemarks.TabIndex = 69;
            this.txtRemarks.UseCustomBackColor = true;
            this.txtRemarks.UseSelectable = true;
            // 
            // CancelAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 226);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabelVer);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabelNote);
            this.Controls.Add(this.pcbxLogo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CancelAppointment";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pcbxLogo;
        private MetroFramework.Controls.MetroLabel metroLabelNote;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabelVer;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Button button2;
        private MetroFramework.Controls.MetroTextBox txtRemarks;
    }
}