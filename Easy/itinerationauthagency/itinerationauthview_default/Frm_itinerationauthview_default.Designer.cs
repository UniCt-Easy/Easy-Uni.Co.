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

namespace itinerationauthview_default
{
    partial class Frm_itinerationauthview_default
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
            this.grpdatimissione = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnspese = new System.Windows.Forms.Button();
            this.btntappe = new System.Windows.Forms.Button();
            this.txtnumero = new System.Windows.Forms.TextBox();
            this.lblnum = new System.Windows.Forms.Label();
            this.txtesercizio = new System.Windows.Forms.TextBox();
            this.lbleser = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbladate = new System.Windows.Forms.Label();
            this.txtdataaut = new System.Windows.Forms.TextBox();
            this.lbldataaut = new System.Windows.Forms.Label();
            this.txtdtafine = new System.Windows.Forms.TextBox();
            this.lbldtafine = new System.Windows.Forms.Label();
            this.txtdatainizio = new System.Windows.Forms.TextBox();
            this.lbldtainizio = new System.Windows.Forms.Label();
            this.txtntappe = new System.Windows.Forms.TextBox();
            this.lbltappe = new System.Windows.Forms.Label();
            this.txtresponsabile = new System.Windows.Forms.TextBox();
            this.lblresponsabile = new System.Windows.Forms.Label();
            this.txtpercipiente = new System.Windows.Forms.TextBox();
            this.lblPercipiente = new System.Windows.Forms.Label();
            this.btnapprova = new System.Windows.Forms.Button();
            this.btnresp = new System.Windows.Forms.Button();
            this.txtdescr = new System.Windows.Forms.TextBox();
            this.lbldescr = new System.Windows.Forms.Label();
            this.lblauthagency = new System.Windows.Forms.Label();
            this.grpdatimissione.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpdatimissione
            // 
            this.grpdatimissione.Controls.Add(this.lblauthagency);
            this.grpdatimissione.Controls.Add(this.lbldescr);
            this.grpdatimissione.Controls.Add(this.txtdescr);
            this.grpdatimissione.Controls.Add(this.label1);
            this.grpdatimissione.Controls.Add(this.textBox2);
            this.grpdatimissione.Controls.Add(this.btnspese);
            this.grpdatimissione.Controls.Add(this.btntappe);
            this.grpdatimissione.Controls.Add(this.txtnumero);
            this.grpdatimissione.Controls.Add(this.lblnum);
            this.grpdatimissione.Controls.Add(this.txtesercizio);
            this.grpdatimissione.Controls.Add(this.lbleser);
            this.grpdatimissione.Controls.Add(this.textBox1);
            this.grpdatimissione.Controls.Add(this.lbladate);
            this.grpdatimissione.Controls.Add(this.txtdataaut);
            this.grpdatimissione.Controls.Add(this.lbldataaut);
            this.grpdatimissione.Controls.Add(this.txtdtafine);
            this.grpdatimissione.Controls.Add(this.lbldtafine);
            this.grpdatimissione.Controls.Add(this.txtdatainizio);
            this.grpdatimissione.Controls.Add(this.lbldtainizio);
            this.grpdatimissione.Controls.Add(this.txtntappe);
            this.grpdatimissione.Controls.Add(this.lbltappe);
            this.grpdatimissione.Controls.Add(this.txtresponsabile);
            this.grpdatimissione.Controls.Add(this.lblresponsabile);
            this.grpdatimissione.Controls.Add(this.txtpercipiente);
            this.grpdatimissione.Controls.Add(this.lblPercipiente);
            this.grpdatimissione.Location = new System.Drawing.Point(13, 13);
            this.grpdatimissione.Name = "grpdatimissione";
            this.grpdatimissione.Size = new System.Drawing.Size(668, 284);
            this.grpdatimissione.TabIndex = 0;
            this.grpdatimissione.TabStop = false;
            this.grpdatimissione.Text = "Dati Missione";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Totale Spese Previste";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 197);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(199, 20);
            this.textBox2.TabIndex = 9000;
            this.textBox2.Tag = "itinerationauthview.totadvance.c";
            // 
            // btnspese
            // 
            this.btnspese.Location = new System.Drawing.Point(503, 39);
            this.btnspese.Name = "btnspese";
            this.btnspese.Size = new System.Drawing.Size(142, 23);
            this.btnspese.TabIndex = 92;
            this.btnspese.Text = "Spese Previste";
            this.btnspese.UseVisualStyleBackColor = true;
            // 
            // btntappe
            // 
            this.btntappe.Location = new System.Drawing.Point(333, 39);
            this.btntappe.Name = "btntappe";
            this.btntappe.Size = new System.Drawing.Size(126, 23);
            this.btntappe.TabIndex = 91;
            this.btntappe.Text = "Tappe";
            this.btntappe.UseVisualStyleBackColor = true;
            // 
            // txtnumero
            // 
            this.txtnumero.Location = new System.Drawing.Point(158, 42);
            this.txtnumero.Name = "txtnumero";
            this.txtnumero.Size = new System.Drawing.Size(57, 20);
            this.txtnumero.TabIndex = 20;
            this.txtnumero.Tag = "itinerationauthview.";
            // 
            // lblnum
            // 
            this.lblnum.AutoSize = true;
            this.lblnum.Location = new System.Drawing.Point(155, 26);
            this.lblnum.Name = "lblnum";
            this.lblnum.Size = new System.Drawing.Size(44, 13);
            this.lblnum.TabIndex = 16;
            this.lblnum.Text = "Numero";
            // 
            // txtesercizio
            // 
            this.txtesercizio.Location = new System.Drawing.Point(16, 42);
            this.txtesercizio.Name = "txtesercizio";
            this.txtesercizio.Size = new System.Drawing.Size(57, 20);
            this.txtesercizio.TabIndex = 10;
            this.txtesercizio.Tag = "itinerationauthview.registry";
            // 
            // lbleser
            // 
            this.lbleser.AutoSize = true;
            this.lbleser.Location = new System.Drawing.Point(15, 26);
            this.lbleser.Name = "lbleser";
            this.lbleser.Size = new System.Drawing.Size(49, 13);
            this.lbleser.TabIndex = 14;
            this.lbleser.Tag = "itinerationauthview.yitineration";
            this.lbleser.Text = "Esercizio";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(503, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 100;
            this.textBox1.Tag = "itinerationauthview.adate";
            // 
            // lbladate
            // 
            this.lbladate.AutoSize = true;
            this.lbladate.Location = new System.Drawing.Point(500, 233);
            this.lbladate.Name = "lbladate";
            this.lbladate.Size = new System.Drawing.Size(77, 13);
            this.lbladate.TabIndex = 12;
            this.lbladate.Text = "Data Contabile";
            // 
            // txtdataaut
            // 
            this.txtdataaut.Location = new System.Drawing.Point(503, 197);
            this.txtdataaut.Name = "txtdataaut";
            this.txtdataaut.Size = new System.Drawing.Size(142, 20);
            this.txtdataaut.TabIndex = 80;
            this.txtdataaut.Tag = "itinerationauthview.authorizationdate";
            // 
            // lbldataaut
            // 
            this.lbldataaut.AutoSize = true;
            this.lbldataaut.Location = new System.Drawing.Point(500, 179);
            this.lbldataaut.Name = "lbldataaut";
            this.lbldataaut.Size = new System.Drawing.Size(101, 13);
            this.lbldataaut.TabIndex = 10;
            this.lbldataaut.Text = "Data Autorizzazione";
            // 
            // txtdtafine
            // 
            this.txtdtafine.Location = new System.Drawing.Point(333, 249);
            this.txtdtafine.Name = "txtdtafine";
            this.txtdtafine.Size = new System.Drawing.Size(142, 20);
            this.txtdtafine.TabIndex = 90;
            this.txtdtafine.Tag = "itinerationauthview.stop";
            // 
            // lbldtafine
            // 
            this.lbldtafine.AutoSize = true;
            this.lbldtafine.Location = new System.Drawing.Point(330, 234);
            this.lbldtafine.Name = "lbldtafine";
            this.lbldtafine.Size = new System.Drawing.Size(53, 13);
            this.lbldtafine.TabIndex = 8;
            this.lbldtafine.Text = "Data Fine";
            // 
            // txtdatainizio
            // 
            this.txtdatainizio.Location = new System.Drawing.Point(333, 197);
            this.txtdatainizio.Name = "txtdatainizio";
            this.txtdatainizio.Size = new System.Drawing.Size(142, 20);
            this.txtdatainizio.TabIndex = 70;
            this.txtdatainizio.Tag = "itinerationauthview.start";
            // 
            // lbldtainizio
            // 
            this.lbldtainizio.AutoSize = true;
            this.lbldtainizio.Location = new System.Drawing.Point(330, 179);
            this.lbldtainizio.Name = "lbldtainizio";
            this.lbldtainizio.Size = new System.Drawing.Size(57, 13);
            this.lbldtainizio.TabIndex = 6;
            this.lbldtainizio.Text = "Data Inizio";
            // 
            // txtntappe
            // 
            this.txtntappe.Location = new System.Drawing.Point(240, 89);
            this.txtntappe.Name = "txtntappe";
            this.txtntappe.Size = new System.Drawing.Size(34, 20);
            this.txtntappe.TabIndex = 40;
            this.txtntappe.Tag = "itinerationauthview.lapcount";
            // 
            // lbltappe
            // 
            this.lbltappe.AutoSize = true;
            this.lbltappe.Location = new System.Drawing.Point(237, 73);
            this.lbltappe.Name = "lbltappe";
            this.lbltappe.Size = new System.Drawing.Size(52, 13);
            this.lbltappe.TabIndex = 4;
            this.lbltappe.Text = "N. Tappe";
            // 
            // txtresponsabile
            // 
            this.txtresponsabile.Location = new System.Drawing.Point(16, 143);
            this.txtresponsabile.Name = "txtresponsabile";
            this.txtresponsabile.Size = new System.Drawing.Size(199, 20);
            this.txtresponsabile.TabIndex = 60;
            this.txtresponsabile.Tag = "itinerationauthview.managertitle";
            // 
            // lblresponsabile
            // 
            this.lblresponsabile.AutoSize = true;
            this.lblresponsabile.Location = new System.Drawing.Point(13, 127);
            this.lblresponsabile.Name = "lblresponsabile";
            this.lblresponsabile.Size = new System.Drawing.Size(71, 13);
            this.lblresponsabile.TabIndex = 2;
            this.lblresponsabile.Text = "Responsabile";
            // 
            // txtpercipiente
            // 
            this.txtpercipiente.Location = new System.Drawing.Point(16, 89);
            this.txtpercipiente.Name = "txtpercipiente";
            this.txtpercipiente.Size = new System.Drawing.Size(199, 20);
            this.txtpercipiente.TabIndex = 30;
            this.txtpercipiente.Tag = "itinerationauthview.registry";
            // 
            // lblPercipiente
            // 
            this.lblPercipiente.AutoSize = true;
            this.lblPercipiente.Location = new System.Drawing.Point(13, 73);
            this.lblPercipiente.Name = "lblPercipiente";
            this.lblPercipiente.Size = new System.Drawing.Size(60, 13);
            this.lblPercipiente.TabIndex = 0;
            this.lblPercipiente.Text = "Percipiente";
            // 
            // btnapprova
            // 
            this.btnapprova.Location = new System.Drawing.Point(191, 311);
            this.btnapprova.Name = "btnapprova";
            this.btnapprova.Size = new System.Drawing.Size(126, 23);
            this.btnapprova.TabIndex = 95;
            this.btnapprova.Text = "Approvata";
            this.btnapprova.UseVisualStyleBackColor = true;
            // 
            // btnresp
            // 
            this.btnresp.Location = new System.Drawing.Point(350, 311);
            this.btnresp.Name = "btnresp";
            this.btnresp.Size = new System.Drawing.Size(126, 23);
            this.btnresp.TabIndex = 96;
            this.btnresp.Text = "Non Approvata";
            this.btnresp.UseVisualStyleBackColor = true;
            // 
            // txtdescr
            // 
            this.txtdescr.Location = new System.Drawing.Point(333, 89);
            this.txtdescr.Multiline = true;
            this.txtdescr.Name = "txtdescr";
            this.txtdescr.Size = new System.Drawing.Size(312, 74);
            this.txtdescr.TabIndex = 50;
            this.txtdescr.Tag = "itinerationauthview.description";
            // 
            // lbldescr
            // 
            this.lbldescr.AutoSize = true;
            this.lbldescr.Location = new System.Drawing.Point(335, 73);
            this.lbldescr.Name = "lbldescr";
            this.lbldescr.Size = new System.Drawing.Size(62, 13);
            this.lbldescr.TabIndex = 96;
            this.lbldescr.Text = "Descrizione";
            // 
            // lblauthagency
            // 
            this.lblauthagency.AutoSize = true;
            this.lblauthagency.Location = new System.Drawing.Point(15, 234);
            this.lblauthagency.Name = "lblauthagency";
            this.lblauthagency.Size = new System.Drawing.Size(96, 13);
            this.lblauthagency.TabIndex = 97;
            this.lblauthagency.Tag = "itinerationauthview.yitineration";
            this.lblauthagency.Text = "Ente Autorizzatore:";
            // 
            // Frm_itinerationauthview_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 346);
            this.Controls.Add(this.btnresp);
            this.Controls.Add(this.btnapprova);
            this.Controls.Add(this.grpdatimissione);
            this.Name = "Frm_itinerationauthview_default";
            this.Text = "Frm_itinerationauthview_default";
            this.grpdatimissione.ResumeLayout(false);
            this.grpdatimissione.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpdatimissione;
        private System.Windows.Forms.Label lblPercipiente;
        private System.Windows.Forms.TextBox txtpercipiente;
        private System.Windows.Forms.TextBox txtresponsabile;
        private System.Windows.Forms.Label lblresponsabile;
        private System.Windows.Forms.TextBox txtntappe;
        private System.Windows.Forms.Label lbltappe;
        private System.Windows.Forms.TextBox txtdtafine;
        private System.Windows.Forms.Label lbldtafine;
        private System.Windows.Forms.Label lbldtainizio;
        private System.Windows.Forms.TextBox txtdatainizio;
        private System.Windows.Forms.TextBox txtdataaut;
        private System.Windows.Forms.Label lbldataaut;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbladate;
        private System.Windows.Forms.Label lblnum;
        private System.Windows.Forms.TextBox txtesercizio;
        private System.Windows.Forms.Label lbleser;
        private System.Windows.Forms.TextBox txtnumero;
        private System.Windows.Forms.Button btnspese;
        private System.Windows.Forms.Button btntappe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnapprova;
        private System.Windows.Forms.Button btnresp;
        private System.Windows.Forms.Label lbldescr;
        private System.Windows.Forms.TextBox txtdescr;
        private System.Windows.Forms.Label lblauthagency;
    }
}