/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace booking_default
{
    partial class Frm_booking_default
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
            this.lblEsercizio = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtybooking = new System.Windows.Forms.TextBox();
            this.txtnbooking = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCF = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCognome = new System.Windows.Forms.Label();
            this.txtcf = new System.Windows.Forms.TextBox();
            this.txtforename = new System.Windows.Forms.TextBox();
            this.txtsurname = new System.Windows.Forms.TextBox();
            this.btninsert = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.detailgrid = new System.Windows.Forms.DataGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbidman = new System.Windows.Forms.ComboBox();
            this.lblDetailsWaitForAuth = new System.Windows.Forms.Label();
            this.lblDetailsNotAuth = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEsercizio
            // 
            this.lblEsercizio.AutoSize = true;
            this.lblEsercizio.Location = new System.Drawing.Point(24, 26);
            this.lblEsercizio.Name = "lblEsercizio";
            this.lblEsercizio.Size = new System.Drawing.Size(49, 13);
            this.lblEsercizio.TabIndex = 0;
            this.lblEsercizio.Text = "Esercizio";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(149, 26);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.Text = "Numero";
            // 
            // txtybooking
            // 
            this.txtybooking.Location = new System.Drawing.Point(79, 23);
            this.txtybooking.Name = "txtybooking";
            this.txtybooking.Size = new System.Drawing.Size(60, 20);
            this.txtybooking.TabIndex = 2;
            this.txtybooking.Tag = "booking.ybooking.year";
            // 
            // txtnbooking
            // 
            this.txtnbooking.Location = new System.Drawing.Point(199, 23);
            this.txtnbooking.Name = "txtnbooking";
            this.txtnbooking.Size = new System.Drawing.Size(67, 20);
            this.txtnbooking.TabIndex = 3;
            this.txtnbooking.Tag = "booking.nbooking";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCF);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Controls.Add(this.lblCognome);
            this.groupBox1.Controls.Add(this.txtcf);
            this.groupBox1.Controls.Add(this.txtforename);
            this.groupBox1.Controls.Add(this.txtsurname);
            this.groupBox1.Location = new System.Drawing.Point(10, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 53);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati del Richiedente";
            // 
            // lblCF
            // 
            this.lblCF.AutoSize = true;
            this.lblCF.Location = new System.Drawing.Point(348, 22);
            this.lblCF.Name = "lblCF";
            this.lblCF.Size = new System.Drawing.Size(76, 13);
            this.lblCF.TabIndex = 5;
            this.lblCF.Text = "Codice Fiscale";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(186, 22);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 4;
            this.lblNome.Text = "Nome";
            // 
            // lblCognome
            // 
            this.lblCognome.AutoSize = true;
            this.lblCognome.Location = new System.Drawing.Point(11, 22);
            this.lblCognome.Name = "lblCognome";
            this.lblCognome.Size = new System.Drawing.Size(52, 13);
            this.lblCognome.TabIndex = 3;
            this.lblCognome.Text = "Cognome";
            // 
            // txtcf
            // 
            this.txtcf.Location = new System.Drawing.Point(430, 19);
            this.txtcf.Name = "txtcf";
            this.txtcf.ReadOnly = true;
            this.txtcf.Size = new System.Drawing.Size(100, 20);
            this.txtcf.TabIndex = 2;
            this.txtcf.Tag = "booking.cf";
            // 
            // txtforename
            // 
            this.txtforename.Location = new System.Drawing.Point(227, 19);
            this.txtforename.Name = "txtforename";
            this.txtforename.ReadOnly = true;
            this.txtforename.Size = new System.Drawing.Size(100, 20);
            this.txtforename.TabIndex = 1;
            this.txtforename.Tag = "booking.forename";
            // 
            // txtsurname
            // 
            this.txtsurname.Location = new System.Drawing.Point(69, 19);
            this.txtsurname.Name = "txtsurname";
            this.txtsurname.ReadOnly = true;
            this.txtsurname.Size = new System.Drawing.Size(100, 20);
            this.txtsurname.TabIndex = 0;
            this.txtsurname.Tag = "booking.surname";
            // 
            // btninsert
            // 
            this.btninsert.Location = new System.Drawing.Point(10, 159);
            this.btninsert.Name = "btninsert";
            this.btninsert.Size = new System.Drawing.Size(75, 23);
            this.btninsert.TabIndex = 5;
            this.btninsert.Tag = "insert.detail";
            this.btninsert.Text = "Inserisci";
            this.btninsert.UseVisualStyleBackColor = true;
            // 
            // btnedit
            // 
            this.btnedit.Location = new System.Drawing.Point(10, 188);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 23);
            this.btnedit.TabIndex = 6;
            this.btnedit.Tag = "edit.detail";
            this.btnedit.Text = "Modifica";
            this.btnedit.UseVisualStyleBackColor = true;
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(10, 217);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 7;
            this.btndelete.Tag = "delete.detail";
            this.btndelete.Text = "Elimina";
            this.btndelete.UseVisualStyleBackColor = true;
            // 
            // detailgrid
            // 
            this.detailgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.detailgrid.CaptionVisible = false;
            this.detailgrid.DataMember = "";
            this.detailgrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.detailgrid.Location = new System.Drawing.Point(93, 159);
            this.detailgrid.Name = "detailgrid";
            this.detailgrid.Size = new System.Drawing.Size(466, 185);
            this.detailgrid.TabIndex = 16;
            this.detailgrid.Tag = "bookingdetail.list.single";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbidman);
            this.groupBox2.Location = new System.Drawing.Point(294, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 47);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Responsabile";
            // 
            // cmbidman
            // 
            this.cmbidman.FormattingEnabled = true;
            this.cmbidman.Location = new System.Drawing.Point(6, 17);
            this.cmbidman.Name = "cmbidman";
            this.cmbidman.Size = new System.Drawing.Size(240, 21);
            this.cmbidman.TabIndex = 0;
            this.cmbidman.Tag = "booking.idman";
            // 
            // lblDetailsWaitForAuth
            // 
            this.lblDetailsWaitForAuth.AutoSize = true;
            this.lblDetailsWaitForAuth.Location = new System.Drawing.Point(25, 128);
            this.lblDetailsWaitForAuth.Name = "lblDetailsWaitForAuth";
            this.lblDetailsWaitForAuth.Size = new System.Drawing.Size(114, 13);
            this.lblDetailsWaitForAuth.TabIndex = 18;
            this.lblDetailsWaitForAuth.Text = "[lblDetailsWaitForAuth]";
            // 
            // lblDetailsNotAuth
            // 
            this.lblDetailsNotAuth.AutoSize = true;
            this.lblDetailsNotAuth.Location = new System.Drawing.Point(358, 128);
            this.lblDetailsNotAuth.Name = "lblDetailsNotAuth";
            this.lblDetailsNotAuth.Size = new System.Drawing.Size(94, 13);
            this.lblDetailsNotAuth.TabIndex = 19;
            this.lblDetailsNotAuth.Text = "[lblDetailsNotAuth]";
            // 
            // Frm_booking_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 357);
            this.Controls.Add(this.lblDetailsNotAuth);
            this.Controls.Add(this.lblDetailsWaitForAuth);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.detailgrid);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btninsert);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtnbooking);
            this.Controls.Add(this.txtybooking);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblEsercizio);
            this.Name = "Frm_booking_default";
            this.Text = "booking_default";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEsercizio;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtybooking;
        private System.Windows.Forms.TextBox txtnbooking;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btninsert;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.DataGrid detailgrid;
        private System.Windows.Forms.Label lblCF;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCognome;
        private System.Windows.Forms.TextBox txtcf;
        private System.Windows.Forms.TextBox txtforename;
        private System.Windows.Forms.TextBox txtsurname;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbidman;
        private System.Windows.Forms.Label lblDetailsWaitForAuth;
        private System.Windows.Forms.Label lblDetailsNotAuth;
    }
}