/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿namespace paydisposition_default {
	partial class WizCreaPagamenti {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.tabPresentazione = new Crownwood.Magic.Controls.TabPage();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.gridDetail = new System.Windows.Forms.DataGrid();
			this.tabAzzeraMov = new Crownwood.Magic.Controls.TabPage();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.groupBox16 = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox20 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtDataCont = new System.Windows.Forms.TextBox();
			this.txtScadenza = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox18 = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtImportoMovimento = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox17 = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
			this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblImportoDisponibile = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtImportoDisponibile = new System.Windows.Forms.TextBox();
			this.txtImportoCorrente = new System.Windows.Forms.TextBox();
			this.gboxMovimento = new System.Windows.Forms.GroupBox();
			this.btnSelectMov = new System.Windows.Forms.Button();
			this.txtNumeroMovimento = new System.Windows.Forms.TextBox();
			this.labNum = new System.Windows.Forms.Label();
			this.txtEsercizioMovimento = new System.Windows.Forms.TextBox();
			this.labEserc = new System.Windows.Forms.Label();
			this.lblFaseMovimento = new System.Windows.Forms.Label();
			this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
			this.tabController.SuspendLayout();
			this.tabPresentazione.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
			this.tabAzzeraMov.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.groupBox16.SuspendLayout();
			this.groupBox20.SuspendLayout();
			this.groupBox18.SuspendLayout();
			this.groupBox17.SuspendLayout();
			this.gboxBilAnnuale.SuspendLayout();
			this.groupCredDeb.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gboxMovimento.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(797, 511);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 16;
			this.btnCancel.Tag = "maincancel";
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(677, 511);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(88, 23);
			this.btnNext.TabIndex = 15;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(589, 511);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(80, 23);
			this.btnBack.TabIndex = 14;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// tabController
			// 
			this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(12, 12);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 0;
			this.tabController.SelectedTab = this.tabPresentazione;
			this.tabController.Size = new System.Drawing.Size(867, 486);
			this.tabController.TabIndex = 0;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPresentazione,
            this.tabAzzeraMov});
			// 
			// tabPresentazione
			// 
			this.tabPresentazione.Controls.Add(this.txtImporto);
			this.tabPresentazione.Controls.Add(this.label4);
			this.tabPresentazione.Controls.Add(this.gridDetail);
			this.tabPresentazione.Location = new System.Drawing.Point(0, 0);
			this.tabPresentazione.Name = "tabPresentazione";
			this.tabPresentazione.Size = new System.Drawing.Size(867, 461);
			this.tabPresentazione.TabIndex = 0;
			this.tabPresentazione.Text = "Pagina 1 di 2";
			this.tabPresentazione.Title = "Page 1 di 2";
			// 
			// txtImporto
			// 
			this.txtImporto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImporto.Location = new System.Drawing.Point(62, 419);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.ReadOnly = true;
			this.txtImporto.Size = new System.Drawing.Size(147, 20);
			this.txtImporto.TabIndex = 6;
			this.txtImporto.TabStop = false;
			this.txtImporto.Tag = "";
			this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 417);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Totale:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gridDetail
			// 
			this.gridDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDetail.DataMember = "";
			this.gridDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDetail.Location = new System.Drawing.Point(13, 21);
			this.gridDetail.Name = "gridDetail";
			this.gridDetail.Size = new System.Drawing.Size(847, 343);
			this.gridDetail.TabIndex = 3;
			// 
			// tabAzzeraMov
			// 
			this.tabAzzeraMov.Controls.Add(this.gboxUPB);
			this.tabAzzeraMov.Controls.Add(this.groupBox16);
			this.tabAzzeraMov.Controls.Add(this.label6);
			this.tabAzzeraMov.Controls.Add(this.groupBox20);
			this.tabAzzeraMov.Controls.Add(this.groupBox18);
			this.tabAzzeraMov.Controls.Add(this.groupBox17);
			this.tabAzzeraMov.Controls.Add(this.gboxBilAnnuale);
			this.tabAzzeraMov.Controls.Add(this.groupCredDeb);
			this.tabAzzeraMov.Controls.Add(this.groupBox1);
			this.tabAzzeraMov.Controls.Add(this.gboxMovimento);
			this.tabAzzeraMov.Location = new System.Drawing.Point(0, 0);
			this.tabAzzeraMov.Name = "tabAzzeraMov";
			this.tabAzzeraMov.Selected = false;
			this.tabAzzeraMov.Size = new System.Drawing.Size(867, 461);
			this.tabAzzeraMov.TabIndex = 1;
			this.tabAzzeraMov.Text = "Pagina 2 di 2";
			this.tabAzzeraMov.Title = "Page 2 di 2";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(13, 184);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(466, 97);
			this.gboxUPB.TabIndex = 112;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(6, 65);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.ReadOnly = true;
			this.txtUPB.Size = new System.Drawing.Size(452, 23);
			this.txtUPB.TabIndex = 6;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(136, 8);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(324, 51);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Enabled = false;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(11, 39);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
			this.btnUPBCode.TabIndex = 2;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "";
			this.btnUPBCode.Text = "UPB:";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// groupBox16
			// 
			this.groupBox16.Controls.Add(this.txtResponsabile);
			this.groupBox16.Location = new System.Drawing.Point(13, 282);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new System.Drawing.Size(466, 40);
			this.groupBox16.TabIndex = 111;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Responsabile";
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(8, 13);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.ReadOnly = true;
			this.txtResponsabile.Size = new System.Drawing.Size(452, 23);
			this.txtResponsabile.TabIndex = 1;
			this.txtResponsabile.Tag = "manager.title?x";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 19);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(504, 23);
			this.label6.TabIndex = 105;
			this.label6.Text = "Selezionare il movimento di spesa a cui si desidera collegare i pagamenti generat" +
    "i";
			// 
			// groupBox20
			// 
			this.groupBox20.Controls.Add(this.label15);
			this.groupBox20.Controls.Add(this.txtDataCont);
			this.groupBox20.Controls.Add(this.txtScadenza);
			this.groupBox20.Controls.Add(this.label13);
			this.groupBox20.Location = new System.Drawing.Point(14, 407);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new System.Drawing.Size(344, 40);
			this.groupBox20.TabIndex = 103;
			this.groupBox20.TabStop = false;
			this.groupBox20.Text = "Data";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(2, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 20);
			this.label15.TabIndex = 0;
			this.label15.Text = "Contabile";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataCont
			// 
			this.txtDataCont.Location = new System.Drawing.Point(67, 15);
			this.txtDataCont.Name = "txtDataCont";
			this.txtDataCont.ReadOnly = true;
			this.txtDataCont.Size = new System.Drawing.Size(72, 23);
			this.txtDataCont.TabIndex = 1;
			this.txtDataCont.Tag = "";
			this.txtDataCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtScadenza
			// 
			this.txtScadenza.Location = new System.Drawing.Point(264, 16);
			this.txtScadenza.Name = "txtScadenza";
			this.txtScadenza.ReadOnly = true;
			this.txtScadenza.Size = new System.Drawing.Size(72, 23);
			this.txtScadenza.TabIndex = 2;
			this.txtScadenza.Tag = "";
			this.txtScadenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(192, 14);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 20);
			this.label13.TabIndex = 0;
			this.label13.Text = "Scadenza:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox18
			// 
			this.groupBox18.Controls.Add(this.SubEntity_txtImportoMovimento);
			this.groupBox18.Controls.Add(this.label11);
			this.groupBox18.Location = new System.Drawing.Point(13, 138);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new System.Drawing.Size(466, 40);
			this.groupBox18.TabIndex = 102;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Importo";
			// 
			// SubEntity_txtImportoMovimento
			// 
			this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(136, 11);
			this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
			this.SubEntity_txtImportoMovimento.ReadOnly = true;
			this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(121, 23);
			this.SubEntity_txtImportoMovimento.TabIndex = 1;
			this.SubEntity_txtImportoMovimento.Tag = "";
			this.SubEntity_txtImportoMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(67, 15);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 20);
			this.label11.TabIndex = 0;
			this.label11.Text = "Originale:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox17
			// 
			this.groupBox17.Controls.Add(this.txtDescrizione);
			this.groupBox17.Location = new System.Drawing.Point(488, 47);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new System.Drawing.Size(367, 78);
			this.groupBox17.TabIndex = 101;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Descrizione";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ReadOnly = true;
			this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrizione.Size = new System.Drawing.Size(353, 48);
			this.txtDescrizione.TabIndex = 1;
			this.txtDescrizione.Tag = "";
			// 
			// gboxBilAnnuale
			// 
			this.gboxBilAnnuale.Controls.Add(this.label9);
			this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
			this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
			this.gboxBilAnnuale.Location = new System.Drawing.Point(14, 321);
			this.gboxBilAnnuale.Name = "gboxBilAnnuale";
			this.gboxBilAnnuale.Size = new System.Drawing.Size(465, 80);
			this.gboxBilAnnuale.TabIndex = 99;
			this.gboxBilAnnuale.TabStop = false;
			this.gboxBilAnnuale.Tag = "";
			// 
			// label9
			// 
			this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label9.ImageIndex = 0;
			this.label9.Location = new System.Drawing.Point(7, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 18);
			this.label9.TabIndex = 3;
			this.label9.Text = "Bilancio";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtCodiceBilancio
			// 
			this.txtCodiceBilancio.Location = new System.Drawing.Point(6, 55);
			this.txtCodiceBilancio.Name = "txtCodiceBilancio";
			this.txtCodiceBilancio.ReadOnly = true;
			this.txtCodiceBilancio.Size = new System.Drawing.Size(453, 23);
			this.txtCodiceBilancio.TabIndex = 1;
			this.txtCodiceBilancio.Tag = "";
			// 
			// txtDenominazioneBilancio
			// 
			this.txtDenominazioneBilancio.Location = new System.Drawing.Point(152, 8);
			this.txtDenominazioneBilancio.Multiline = true;
			this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
			this.txtDenominazioneBilancio.ReadOnly = true;
			this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDenominazioneBilancio.Size = new System.Drawing.Size(307, 44);
			this.txtDenominazioneBilancio.TabIndex = 2;
			this.txtDenominazioneBilancio.TabStop = false;
			this.txtDenominazioneBilancio.Tag = "";
			// 
			// groupCredDeb
			// 
			this.groupCredDeb.Controls.Add(this.txtCredDeb);
			this.groupCredDeb.Location = new System.Drawing.Point(488, 138);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(367, 40);
			this.groupCredDeb.TabIndex = 100;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "";
			this.groupCredDeb.Text = "Percipiente";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.ReadOnly = true;
			this.txtCredDeb.Size = new System.Drawing.Size(351, 23);
			this.txtCredDeb.TabIndex = 1;
			this.txtCredDeb.Tag = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblImportoDisponibile);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.txtImportoDisponibile);
			this.groupBox1.Controls.Add(this.txtImportoCorrente);
			this.groupBox1.Location = new System.Drawing.Point(484, 376);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(359, 75);
			this.groupBox1.TabIndex = 104;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Situazione riassuntiva importo del movimento";
			// 
			// lblImportoDisponibile
			// 
			this.lblImportoDisponibile.Location = new System.Drawing.Point(37, 44);
			this.lblImportoDisponibile.Name = "lblImportoDisponibile";
			this.lblImportoDisponibile.Size = new System.Drawing.Size(192, 20);
			this.lblImportoDisponibile.TabIndex = 0;
			this.lblImportoDisponibile.Text = "Disponibile:";
			this.lblImportoDisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(37, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(200, 24);
			this.label12.TabIndex = 0;
			this.label12.Text = "Attuale (comprensivo delle variazioni):";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImportoDisponibile
			// 
			this.txtImportoDisponibile.Location = new System.Drawing.Point(256, 44);
			this.txtImportoDisponibile.Name = "txtImportoDisponibile";
			this.txtImportoDisponibile.ReadOnly = true;
			this.txtImportoDisponibile.Size = new System.Drawing.Size(96, 23);
			this.txtImportoDisponibile.TabIndex = 0;
			this.txtImportoDisponibile.TabStop = false;
			this.txtImportoDisponibile.Tag = "";
			this.txtImportoDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoCorrente
			// 
			this.txtImportoCorrente.Location = new System.Drawing.Point(256, 20);
			this.txtImportoCorrente.Name = "txtImportoCorrente";
			this.txtImportoCorrente.ReadOnly = true;
			this.txtImportoCorrente.Size = new System.Drawing.Size(96, 23);
			this.txtImportoCorrente.TabIndex = 0;
			this.txtImportoCorrente.TabStop = false;
			this.txtImportoCorrente.Tag = "";
			this.txtImportoCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// gboxMovimento
			// 
			this.gboxMovimento.Controls.Add(this.btnSelectMov);
			this.gboxMovimento.Controls.Add(this.txtNumeroMovimento);
			this.gboxMovimento.Controls.Add(this.labNum);
			this.gboxMovimento.Controls.Add(this.txtEsercizioMovimento);
			this.gboxMovimento.Controls.Add(this.labEserc);
			this.gboxMovimento.Controls.Add(this.lblFaseMovimento);
			this.gboxMovimento.Controls.Add(this.cmbFaseSpesa);
			this.gboxMovimento.Location = new System.Drawing.Point(13, 45);
			this.gboxMovimento.Name = "gboxMovimento";
			this.gboxMovimento.Size = new System.Drawing.Size(469, 80);
			this.gboxMovimento.TabIndex = 98;
			this.gboxMovimento.TabStop = false;
			this.gboxMovimento.Tag = "";
			this.gboxMovimento.Text = "Movimento";
			// 
			// btnSelectMov
			// 
			this.btnSelectMov.Location = new System.Drawing.Point(15, 17);
			this.btnSelectMov.Name = "btnSelectMov";
			this.btnSelectMov.Size = new System.Drawing.Size(75, 23);
			this.btnSelectMov.TabIndex = 4;
			this.btnSelectMov.Tag = "";
			this.btnSelectMov.Text = "Seleziona";
			this.btnSelectMov.Click += new System.EventHandler(this.btnSelectMov_Click);
			// 
			// txtNumeroMovimento
			// 
			this.txtNumeroMovimento.Location = new System.Drawing.Point(251, 43);
			this.txtNumeroMovimento.Name = "txtNumeroMovimento";
			this.txtNumeroMovimento.Size = new System.Drawing.Size(68, 23);
			this.txtNumeroMovimento.TabIndex = 3;
			this.txtNumeroMovimento.Tag = "";
			this.txtNumeroMovimento.Leave += new System.EventHandler(this.txtNumeroMovimento_Leave);
			// 
			// labNum
			// 
			this.labNum.Location = new System.Drawing.Point(219, 43);
			this.labNum.Name = "labNum";
			this.labNum.Size = new System.Drawing.Size(32, 20);
			this.labNum.TabIndex = 0;
			this.labNum.Text = "Num.";
			this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioMovimento
			// 
			this.txtEsercizioMovimento.Location = new System.Drawing.Point(134, 45);
			this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
			this.txtEsercizioMovimento.Size = new System.Drawing.Size(55, 23);
			this.txtEsercizioMovimento.TabIndex = 2;
			this.txtEsercizioMovimento.Tag = "";
			this.txtEsercizioMovimento.Leave += new System.EventHandler(this.txtEsercizioFasePrecedente_Leave);
			// 
			// labEserc
			// 
			this.labEserc.Location = new System.Drawing.Point(94, 45);
			this.labEserc.Name = "labEserc";
			this.labEserc.Size = new System.Drawing.Size(40, 20);
			this.labEserc.TabIndex = 0;
			this.labEserc.Text = "Eserc.";
			this.labEserc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblFaseMovimento
			// 
			this.lblFaseMovimento.Location = new System.Drawing.Point(102, 19);
			this.lblFaseMovimento.Name = "lblFaseMovimento";
			this.lblFaseMovimento.Size = new System.Drawing.Size(32, 20);
			this.lblFaseMovimento.TabIndex = 0;
			this.lblFaseMovimento.Text = "Fase";
			this.lblFaseMovimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbFaseSpesa
			// 
			this.cmbFaseSpesa.DisplayMember = "description";
			this.cmbFaseSpesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFaseSpesa.Location = new System.Drawing.Point(134, 19);
			this.cmbFaseSpesa.Name = "cmbFaseSpesa";
			this.cmbFaseSpesa.Size = new System.Drawing.Size(329, 23);
			this.cmbFaseSpesa.TabIndex = 1;
			this.cmbFaseSpesa.Tag = "expense.nphase";
			this.cmbFaseSpesa.ValueMember = "nphase";
			// 
			// WizCreaPagamenti
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(895, 546);
			this.Controls.Add(this.tabController);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Name = "WizCreaPagamenti";
			this.Text = "WizCreaPagamenti";
			this.tabController.ResumeLayout(false);
			this.tabPresentazione.ResumeLayout(false);
			this.tabPresentazione.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
			this.tabAzzeraMov.ResumeLayout(false);
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.groupBox16.ResumeLayout(false);
			this.groupBox16.PerformLayout();
			this.groupBox20.ResumeLayout(false);
			this.groupBox20.PerformLayout();
			this.groupBox18.ResumeLayout(false);
			this.groupBox18.PerformLayout();
			this.groupBox17.ResumeLayout(false);
			this.groupBox17.PerformLayout();
			this.gboxBilAnnuale.ResumeLayout(false);
			this.gboxBilAnnuale.PerformLayout();
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxMovimento.ResumeLayout(false);
			this.gboxMovimento.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabPresentazione;
		private Crownwood.Magic.Controls.TabPage tabAzzeraMov;
		private System.Windows.Forms.DataGrid gridDetail;
		private System.Windows.Forms.GroupBox gboxUPB;
		public System.Windows.Forms.TextBox txtUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.Button btnUPBCode;
		private System.Windows.Forms.GroupBox groupBox16;
		public System.Windows.Forms.TextBox txtResponsabile;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox20;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtDataCont;
		private System.Windows.Forms.TextBox txtScadenza;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox18;
		private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.GroupBox gboxBilAnnuale;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblImportoDisponibile;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtImportoDisponibile;
		private System.Windows.Forms.TextBox txtImportoCorrente;
		private System.Windows.Forms.GroupBox gboxMovimento;
		private System.Windows.Forms.Button btnSelectMov;
		private System.Windows.Forms.TextBox txtNumeroMovimento;
		private System.Windows.Forms.Label labNum;
		private System.Windows.Forms.TextBox txtEsercizioMovimento;
		private System.Windows.Forms.Label labEserc;
		private System.Windows.Forms.Label lblFaseMovimento;
		private System.Windows.Forms.ComboBox cmbFaseSpesa;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtImporto;
	}
}