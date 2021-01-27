
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace taxsortingsetup_default
{
	/// <summary>
	/// Summary description for Frm_taxsortingsetup.
	/// </summary>
	public class Frm_taxsortingsetup : System.Windows.Forms.Form
	{
		public taxsortingsetup_default.vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.ComboBox cmbTipoMov;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.GroupBox grpRitenute;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox grpPrestazione;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabDip;
		private System.Windows.Forms.GroupBox gboxClassRevDip;
		private System.Windows.Forms.TextBox txtDescrClassRevDip;
		private System.Windows.Forms.TextBox txtClassRevDip;
		private System.Windows.Forms.Button btnClassRevDip;
		private System.Windows.Forms.TabPage tabAmm;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chbEredita;
		private System.Windows.Forms.GroupBox gboxClassManAmm;
		private System.Windows.Forms.TextBox txtDescrClassManAmm;
		private System.Windows.Forms.TextBox txtClassManAmm;
		private System.Windows.Forms.Button btnClassManAmm;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox gboxClassRevAmm;
		private System.Windows.Forms.TextBox txtDescrClassRevAmm;
		private System.Windows.Forms.TextBox txtClassRevAmm;
		private System.Windows.Forms.Button btnClassRevAmm;
		private System.Windows.Forms.TabPage tabLiq;
		private System.Windows.Forms.GroupBox gboxClassLiq;
		private System.Windows.Forms.TextBox txtDescrClassLiq;
		private System.Windows.Forms.TextBox txtClassLiq;
		private System.Windows.Forms.Button btnClassLiq;
		MetaData Meta;
        private GroupBox gboxClassManDip;
        private TextBox txtDescrClassManDip;
        private TextBox txtClassManDip;
        private Button btnClassManDip;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Frm_taxsortingsetup()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DataAccess.SetTableForReading(DS.sortingemployproc, "sorting");
			DataAccess.SetTableForReading(DS.sortingadminproc, "sorting");
			DataAccess.SetTableForReading(DS.sortingadminpay, "sorting");
			DataAccess.SetTableForReading(DS.sortingtaxpay, "sorting");
            DataAccess.SetTableForReading(DS.sortingemploypay, "sorting");
            HelpForm.SetDenyNull(DS.taxsortingsetup.Columns["flaginherit"], true);
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        CQueryHelper QHC;
        QueryHelper QHS;
        int esercizio;

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.DS = new taxsortingsetup_default.vistaForm();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmbTipoMov = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.grpRitenute = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.grpPrestazione = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDip = new System.Windows.Forms.TabPage();
            this.gboxClassRevDip = new System.Windows.Forms.GroupBox();
            this.txtDescrClassRevDip = new System.Windows.Forms.TextBox();
            this.txtClassRevDip = new System.Windows.Forms.TextBox();
            this.btnClassRevDip = new System.Windows.Forms.Button();
            this.tabAmm = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chbEredita = new System.Windows.Forms.CheckBox();
            this.gboxClassManAmm = new System.Windows.Forms.GroupBox();
            this.txtDescrClassManAmm = new System.Windows.Forms.TextBox();
            this.txtClassManAmm = new System.Windows.Forms.TextBox();
            this.btnClassManAmm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gboxClassRevAmm = new System.Windows.Forms.GroupBox();
            this.txtDescrClassRevAmm = new System.Windows.Forms.TextBox();
            this.txtClassRevAmm = new System.Windows.Forms.TextBox();
            this.btnClassRevAmm = new System.Windows.Forms.Button();
            this.tabLiq = new System.Windows.Forms.TabPage();
            this.gboxClassLiq = new System.Windows.Forms.GroupBox();
            this.txtDescrClassLiq = new System.Windows.Forms.TextBox();
            this.txtClassLiq = new System.Windows.Forms.TextBox();
            this.btnClassLiq = new System.Windows.Forms.Button();
            this.gboxClassManDip = new System.Windows.Forms.GroupBox();
            this.txtDescrClassManDip = new System.Windows.Forms.TextBox();
            this.txtClassManDip = new System.Windows.Forms.TextBox();
            this.btnClassManDip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.grpRitenute.SuspendLayout();
            this.grpPrestazione.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDip.SuspendLayout();
            this.gboxClassRevDip.SuspendLayout();
            this.tabAmm.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gboxClassManAmm.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxClassRevAmm.SuspendLayout();
            this.tabLiq.SuspendLayout();
            this.gboxClassLiq.SuspendLayout();
            this.gboxClassManDip.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.cmbTipoMov);
            this.groupBox6.Controls.Add(this.button5);
            this.groupBox6.Location = new System.Drawing.Point(8, 120);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(591, 56);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Classificazione";
            // 
            // cmbTipoMov
            // 
            this.cmbTipoMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoMov.DataSource = this.DS.sortingkind;
            this.cmbTipoMov.DisplayMember = "description";
            this.cmbTipoMov.Location = new System.Drawing.Point(96, 24);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Size = new System.Drawing.Size(487, 21);
            this.cmbTipoMov.TabIndex = 1;
            this.cmbTipoMov.Tag = "taxsortingsetup.idsorkind";
            this.cmbTipoMov.ValueMember = "idsorkind";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.TabStop = false;
            this.button5.Tag = "manage.sortingkind.lista";
            this.button5.Text = "Tipo";
            // 
            // grpRitenute
            // 
            this.grpRitenute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRitenute.Controls.Add(this.comboBox2);
            this.grpRitenute.Controls.Add(this.button2);
            this.grpRitenute.Location = new System.Drawing.Point(8, 56);
            this.grpRitenute.Name = "grpRitenute";
            this.grpRitenute.Size = new System.Drawing.Size(591, 56);
            this.grpRitenute.TabIndex = 5;
            this.grpRitenute.TabStop = false;
            this.grpRitenute.Text = "Ritenuta";
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DataSource = this.DS.tax;
            this.comboBox2.DisplayMember = "description";
            this.comboBox2.Location = new System.Drawing.Point(96, 24);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(487, 21);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.Tag = "taxsortingsetup.taxcode";
            this.comboBox2.ValueMember = "taxcode";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "choose.tax.default";
            this.button2.Text = "Tipo";
            // 
            // grpPrestazione
            // 
            this.grpPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPrestazione.Controls.Add(this.comboBox1);
            this.grpPrestazione.Controls.Add(this.button1);
            this.grpPrestazione.Location = new System.Drawing.Point(8, 0);
            this.grpPrestazione.Name = "grpPrestazione";
            this.grpPrestazione.Size = new System.Drawing.Size(591, 48);
            this.grpPrestazione.TabIndex = 4;
            this.grpPrestazione.TabStop = false;
            this.grpPrestazione.Text = "Prestazione";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.service;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(96, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(487, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "taxsortingsetup.idser";
            this.comboBox1.ValueMember = "idser";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.service.default";
            this.button1.Text = "Tipo";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDip);
            this.tabControl1.Controls.Add(this.tabAmm);
            this.tabControl1.Controls.Add(this.tabLiq);
            this.tabControl1.Location = new System.Drawing.Point(8, 192);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(592, 176);
            this.tabControl1.TabIndex = 7;
            // 
            // tabDip
            // 
            this.tabDip.Controls.Add(this.gboxClassManDip);
            this.tabDip.Controls.Add(this.gboxClassRevDip);
            this.tabDip.Location = new System.Drawing.Point(4, 22);
            this.tabDip.Name = "tabDip";
            this.tabDip.Size = new System.Drawing.Size(584, 150);
            this.tabDip.TabIndex = 0;
            this.tabDip.Text = "c/dipendente";
            // 
            // gboxClassRevDip
            // 
            this.gboxClassRevDip.Controls.Add(this.txtDescrClassRevDip);
            this.gboxClassRevDip.Controls.Add(this.txtClassRevDip);
            this.gboxClassRevDip.Controls.Add(this.btnClassRevDip);
            this.gboxClassRevDip.Location = new System.Drawing.Point(8, 8);
            this.gboxClassRevDip.Name = "gboxClassRevDip";
            this.gboxClassRevDip.Size = new System.Drawing.Size(264, 88);
            this.gboxClassRevDip.TabIndex = 2;
            this.gboxClassRevDip.TabStop = false;
            this.gboxClassRevDip.Tag = "AutoManage.txtClassRevDip.tree";
            this.gboxClassRevDip.Text = "Entrata";
            // 
            // txtDescrClassRevDip
            // 
            this.txtDescrClassRevDip.Location = new System.Drawing.Point(120, 24);
            this.txtDescrClassRevDip.Multiline = true;
            this.txtDescrClassRevDip.Name = "txtDescrClassRevDip";
            this.txtDescrClassRevDip.ReadOnly = true;
            this.txtDescrClassRevDip.Size = new System.Drawing.Size(136, 56);
            this.txtDescrClassRevDip.TabIndex = 2;
            this.txtDescrClassRevDip.TabStop = false;
            this.txtDescrClassRevDip.Tag = "sortingemployproc.description";
            // 
            // txtClassRevDip
            // 
            this.txtClassRevDip.Location = new System.Drawing.Point(8, 56);
            this.txtClassRevDip.Name = "txtClassRevDip";
            this.txtClassRevDip.Size = new System.Drawing.Size(104, 20);
            this.txtClassRevDip.TabIndex = 1;
            this.txtClassRevDip.Tag = "sortingemployproc.sortcode?taxsortingsetupview.sortcode_employproc";
            // 
            // btnClassRevDip
            // 
            this.btnClassRevDip.Location = new System.Drawing.Point(8, 24);
            this.btnClassRevDip.Name = "btnClassRevDip";
            this.btnClassRevDip.Size = new System.Drawing.Size(104, 23);
            this.btnClassRevDip.TabIndex = 0;
            this.btnClassRevDip.TabStop = false;
            this.btnClassRevDip.Tag = "manage.sortingemployproc.tree";
            this.btnClassRevDip.Text = "Codice";
            // 
            // tabAmm
            // 
            this.tabAmm.Controls.Add(this.groupBox3);
            this.tabAmm.Controls.Add(this.groupBox2);
            this.tabAmm.Location = new System.Drawing.Point(4, 22);
            this.tabAmm.Name = "tabAmm";
            this.tabAmm.Size = new System.Drawing.Size(584, 150);
            this.tabAmm.TabIndex = 1;
            this.tabAmm.Text = "c/amministrazione";
            this.tabAmm.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chbEredita);
            this.groupBox3.Controls.Add(this.gboxClassManAmm);
            this.groupBox3.Location = new System.Drawing.Point(296, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 136);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Spesa";
            // 
            // chbEredita
            // 
            this.chbEredita.Location = new System.Drawing.Point(8, 16);
            this.chbEredita.Name = "chbEredita";
            this.chbEredita.Size = new System.Drawing.Size(232, 24);
            this.chbEredita.TabIndex = 0;
            this.chbEredita.Tag = "taxsortingsetup.flaginherit:S:N";
            this.chbEredita.Text = "Eredita da movimento padre";
            this.chbEredita.CheckedChanged += new System.EventHandler(this.chbEredita_CheckedChanged);
            // 
            // gboxClassManAmm
            // 
            this.gboxClassManAmm.Controls.Add(this.txtDescrClassManAmm);
            this.gboxClassManAmm.Controls.Add(this.txtClassManAmm);
            this.gboxClassManAmm.Controls.Add(this.btnClassManAmm);
            this.gboxClassManAmm.Location = new System.Drawing.Point(8, 40);
            this.gboxClassManAmm.Name = "gboxClassManAmm";
            this.gboxClassManAmm.Size = new System.Drawing.Size(264, 88);
            this.gboxClassManAmm.TabIndex = 1;
            this.gboxClassManAmm.TabStop = false;
            this.gboxClassManAmm.Tag = "AutoManage.txtClassManAmm.tree";
            this.gboxClassManAmm.Text = "Classificazione";
            // 
            // txtDescrClassManAmm
            // 
            this.txtDescrClassManAmm.Location = new System.Drawing.Point(120, 24);
            this.txtDescrClassManAmm.Multiline = true;
            this.txtDescrClassManAmm.Name = "txtDescrClassManAmm";
            this.txtDescrClassManAmm.ReadOnly = true;
            this.txtDescrClassManAmm.Size = new System.Drawing.Size(136, 56);
            this.txtDescrClassManAmm.TabIndex = 2;
            this.txtDescrClassManAmm.TabStop = false;
            this.txtDescrClassManAmm.Tag = "sortingadminpay.description";
            // 
            // txtClassManAmm
            // 
            this.txtClassManAmm.Location = new System.Drawing.Point(8, 56);
            this.txtClassManAmm.Name = "txtClassManAmm";
            this.txtClassManAmm.Size = new System.Drawing.Size(104, 20);
            this.txtClassManAmm.TabIndex = 1;
            this.txtClassManAmm.Tag = "sortingadminpay.sortcode?taxsortingsetupview.sortcode_adminpay";
            // 
            // btnClassManAmm
            // 
            this.btnClassManAmm.Location = new System.Drawing.Point(8, 24);
            this.btnClassManAmm.Name = "btnClassManAmm";
            this.btnClassManAmm.Size = new System.Drawing.Size(104, 23);
            this.btnClassManAmm.TabIndex = 0;
            this.btnClassManAmm.TabStop = false;
            this.btnClassManAmm.Tag = "manage.sortingadminpay.tree";
            this.btnClassManAmm.Text = "Codice";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gboxClassRevAmm);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 136);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entrata";
            // 
            // gboxClassRevAmm
            // 
            this.gboxClassRevAmm.Controls.Add(this.txtDescrClassRevAmm);
            this.gboxClassRevAmm.Controls.Add(this.txtClassRevAmm);
            this.gboxClassRevAmm.Controls.Add(this.btnClassRevAmm);
            this.gboxClassRevAmm.Location = new System.Drawing.Point(8, 40);
            this.gboxClassRevAmm.Name = "gboxClassRevAmm";
            this.gboxClassRevAmm.Size = new System.Drawing.Size(264, 88);
            this.gboxClassRevAmm.TabIndex = 2;
            this.gboxClassRevAmm.TabStop = false;
            this.gboxClassRevAmm.Tag = "AutoManage.txtClassRevAmm.tree";
            this.gboxClassRevAmm.Text = "Classificazione";
            // 
            // txtDescrClassRevAmm
            // 
            this.txtDescrClassRevAmm.Location = new System.Drawing.Point(120, 24);
            this.txtDescrClassRevAmm.Multiline = true;
            this.txtDescrClassRevAmm.Name = "txtDescrClassRevAmm";
            this.txtDescrClassRevAmm.ReadOnly = true;
            this.txtDescrClassRevAmm.Size = new System.Drawing.Size(136, 56);
            this.txtDescrClassRevAmm.TabIndex = 2;
            this.txtDescrClassRevAmm.TabStop = false;
            this.txtDescrClassRevAmm.Tag = "sortingadminproc.description";
            // 
            // txtClassRevAmm
            // 
            this.txtClassRevAmm.Location = new System.Drawing.Point(8, 56);
            this.txtClassRevAmm.Name = "txtClassRevAmm";
            this.txtClassRevAmm.Size = new System.Drawing.Size(104, 20);
            this.txtClassRevAmm.TabIndex = 1;
            this.txtClassRevAmm.Tag = "sortingadminproc.sortcode?taxsortingsetupview.sortcode_adminproc";
            // 
            // btnClassRevAmm
            // 
            this.btnClassRevAmm.Location = new System.Drawing.Point(8, 24);
            this.btnClassRevAmm.Name = "btnClassRevAmm";
            this.btnClassRevAmm.Size = new System.Drawing.Size(104, 23);
            this.btnClassRevAmm.TabIndex = 0;
            this.btnClassRevAmm.TabStop = false;
            this.btnClassRevAmm.Tag = "manage.sortingadminproc.tree";
            this.btnClassRevAmm.Text = "Codice";
            // 
            // tabLiq
            // 
            this.tabLiq.Controls.Add(this.gboxClassLiq);
            this.tabLiq.Location = new System.Drawing.Point(4, 22);
            this.tabLiq.Name = "tabLiq";
            this.tabLiq.Size = new System.Drawing.Size(584, 150);
            this.tabLiq.TabIndex = 2;
            this.tabLiq.Text = "liquidazione";
            this.tabLiq.Visible = false;
            // 
            // gboxClassLiq
            // 
            this.gboxClassLiq.Controls.Add(this.txtDescrClassLiq);
            this.gboxClassLiq.Controls.Add(this.txtClassLiq);
            this.gboxClassLiq.Controls.Add(this.btnClassLiq);
            this.gboxClassLiq.Location = new System.Drawing.Point(8, 8);
            this.gboxClassLiq.Name = "gboxClassLiq";
            this.gboxClassLiq.Size = new System.Drawing.Size(264, 88);
            this.gboxClassLiq.TabIndex = 3;
            this.gboxClassLiq.TabStop = false;
            this.gboxClassLiq.Tag = "AutoManage.txtClassLiq.tree";
            this.gboxClassLiq.Text = "Classificazione";
            // 
            // txtDescrClassLiq
            // 
            this.txtDescrClassLiq.Location = new System.Drawing.Point(120, 24);
            this.txtDescrClassLiq.Multiline = true;
            this.txtDescrClassLiq.Name = "txtDescrClassLiq";
            this.txtDescrClassLiq.ReadOnly = true;
            this.txtDescrClassLiq.Size = new System.Drawing.Size(136, 56);
            this.txtDescrClassLiq.TabIndex = 2;
            this.txtDescrClassLiq.TabStop = false;
            this.txtDescrClassLiq.Tag = "sortingtaxpay.description";
            // 
            // txtClassLiq
            // 
            this.txtClassLiq.Location = new System.Drawing.Point(8, 56);
            this.txtClassLiq.Name = "txtClassLiq";
            this.txtClassLiq.Size = new System.Drawing.Size(104, 20);
            this.txtClassLiq.TabIndex = 1;
            this.txtClassLiq.Tag = "sortingtaxpay.sortcode?taxsortingsetupview.sortcode_taxpay";
            // 
            // btnClassLiq
            // 
            this.btnClassLiq.Location = new System.Drawing.Point(8, 24);
            this.btnClassLiq.Name = "btnClassLiq";
            this.btnClassLiq.Size = new System.Drawing.Size(104, 23);
            this.btnClassLiq.TabIndex = 0;
            this.btnClassLiq.TabStop = false;
            this.btnClassLiq.Tag = "manage.sortingtaxpay.tree";
            this.btnClassLiq.Text = "Codice";
            // 
            // gboxClassManDip
            // 
            this.gboxClassManDip.Controls.Add(this.txtDescrClassManDip);
            this.gboxClassManDip.Controls.Add(this.txtClassManDip);
            this.gboxClassManDip.Controls.Add(this.btnClassManDip);
            this.gboxClassManDip.Location = new System.Drawing.Point(289, 8);
            this.gboxClassManDip.Name = "gboxClassManDip";
            this.gboxClassManDip.Size = new System.Drawing.Size(264, 88);
            this.gboxClassManDip.TabIndex = 3;
            this.gboxClassManDip.TabStop = false;
            this.gboxClassManDip.Tag = "AutoManage.txtClassManDip.tree";
            this.gboxClassManDip.Text = "Spesa";
            // 
            // txtDescrClassManDip
            // 
            this.txtDescrClassManDip.Location = new System.Drawing.Point(120, 24);
            this.txtDescrClassManDip.Multiline = true;
            this.txtDescrClassManDip.Name = "txtDescrClassManDip";
            this.txtDescrClassManDip.ReadOnly = true;
            this.txtDescrClassManDip.Size = new System.Drawing.Size(136, 56);
            this.txtDescrClassManDip.TabIndex = 2;
            this.txtDescrClassManDip.TabStop = false;
            this.txtDescrClassManDip.Tag = "sortingemploypay.description";
            // 
            // txtClassManDip
            // 
            this.txtClassManDip.Location = new System.Drawing.Point(8, 56);
            this.txtClassManDip.Name = "txtClassManDip";
            this.txtClassManDip.Size = new System.Drawing.Size(104, 20);
            this.txtClassManDip.TabIndex = 1;
            this.txtClassManDip.Tag = "sortingemploypay.sortcode?taxsortingsetupview.sortcode_employpay";
            // 
            // btnClassManDip
            // 
            this.btnClassManDip.Location = new System.Drawing.Point(8, 24);
            this.btnClassManDip.Name = "btnClassManDip";
            this.btnClassManDip.Size = new System.Drawing.Size(104, 23);
            this.btnClassManDip.TabIndex = 0;
            this.btnClassManDip.TabStop = false;
            this.btnClassManDip.Tag = "manage.sortingemploypay.tree";
            this.btnClassManDip.Text = "Codice";
            // 
            // Frm_taxsortingsetup
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(607, 374);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.grpRitenute);
            this.Controls.Add(this.grpPrestazione);
            this.Name = "Frm_taxsortingsetup";
            this.Text = "Frm_taxsortingsetup";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.grpRitenute.ResumeLayout(false);
            this.grpPrestazione.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabDip.ResumeLayout(false);
            this.gboxClassRevDip.ResumeLayout(false);
            this.gboxClassRevDip.PerformLayout();
            this.tabAmm.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.gboxClassManAmm.ResumeLayout(false);
            this.gboxClassManAmm.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gboxClassRevAmm.ResumeLayout(false);
            this.gboxClassRevAmm.PerformLayout();
            this.tabLiq.ResumeLayout(false);
            this.gboxClassLiq.ResumeLayout(false);
            this.gboxClassLiq.PerformLayout();
            this.gboxClassManDip.ResumeLayout(false);
            this.gboxClassManDip.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            esercizio = (int)Meta.GetSys("esercizio");
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
			GetData.SetStaticFilter(DS.taxsortingsetup, filterEsercizio);
            GetData.SetStaticFilter(DS.taxsortingsetupview, filterEsercizio);
            string filtroTipoClass = QHS.DoPar(QHS.AppOr(QHS.IsNotNull("nphaseincome"),
                                QHS.IsNotNull("nphaseexpense")));
			GetData.SetStaticFilter(DS.sortingkind, filtroTipoClass);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                    QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filtroTipoClass)),
                    QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingkind, filterI);
		}
	
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			switch(T.TableName) {
				case "sortingkind": {
					if (Meta.DrawStateIsDone) {
						if (!Meta.IsEmpty){
							DS.taxsortingsetup.Rows[0]["idsorkind"] = DBNull.Value;
							DS.taxsortingsetup.Rows[0]["idsor_employproc"] = DBNull.Value;
							DS.taxsortingsetup.Rows[0]["idsor_adminproc"] = DBNull.Value;
							DS.taxsortingsetup.Rows[0]["idsor_adminpay"] = DBNull.Value;
							DS.taxsortingsetup.Rows[0]["idsor_taxpay"] = DBNull.Value;
                            DS.taxsortingsetup.Rows[0]["idsor_employpay"] = DBNull.Value;
                            }
						txtClassRevDip.Text = "";
						txtDescrClassRevDip.Text = "";
						txtClassRevAmm.Text = "";
						txtDescrClassRevAmm.Text = "";
						txtClassManAmm.Text = "";
						txtDescrClassManAmm.Text = "";

                        txtClassManDip.Text = "";
                        txtDescrClassManDip.Text = "";

                        txtClassLiq.Text = "";
						txtDescrClassLiq.Text = "";
						DS.sortingemployproc.Clear();
						DS.sortingadminproc.Clear();
						DS.sortingadminpay.Clear();
                        DS.sortingemploypay.Clear();
                        DS.sortingtaxpay.Clear();
					}
					SetCodiciClass();
					return;
				}
			}
		}

		void SetCodiciClass(){
			btnClassRevDip.Enabled = (cmbTipoMov.SelectedIndex > 0);
			btnClassRevAmm.Enabled = (cmbTipoMov.SelectedIndex > 0);
			btnClassManAmm.Enabled = (cmbTipoMov.SelectedIndex > 0);
            btnClassManDip.Enabled = (cmbTipoMov.SelectedIndex > 0);
            btnClassLiq.Enabled = (cmbTipoMov.SelectedIndex > 0);
			txtClassRevDip.ReadOnly = (cmbTipoMov.SelectedIndex <= 0);
			txtClassRevAmm.ReadOnly = (cmbTipoMov.SelectedIndex <= 0);
			txtClassManAmm.ReadOnly = (cmbTipoMov.SelectedIndex <= 0);
            txtClassManDip.ReadOnly = (cmbTipoMov.SelectedIndex <= 0);
            txtClassLiq.ReadOnly = (cmbTipoMov.SelectedIndex <= 0);
			
			if (cmbTipoMov.SelectedIndex<=0){
				txtClassRevDip.Text = "";
				txtClassRevAmm.Text = "";
				txtClassManAmm.Text = "";
                txtClassManDip.Text = "";
                txtClassLiq.Text = "";
				txtDescrClassRevDip.Text = "";
				txtDescrClassRevAmm.Text = "";
				txtDescrClassManDip.Text = "";
				txtDescrClassLiq.Text = "";
			}
			else {
                string filter = QHS.CmpEq("idsorkind", cmbTipoMov.SelectedValue);
				DataTable Available = Meta.Conn.RUN_SELECT("sorting","*",null,filter,null,null,true);
				btnClassRevDip.Tag="manage.sortingemployproc.tree."+filter;
				btnClassRevAmm.Tag="manage.sortingadminproc.tree."+filter;
				btnClassManAmm.Tag="manage.sortingadminpay.tree."+filter;
                btnClassManDip.Tag = "manage.sortingemploypay.tree." + filter;
                btnClassLiq.Tag="manage.sortingtaxpay.tree."+filter;
				gboxClassRevDip.Tag="AutoManage.txtClassRevDip.tree."+filter;
				gboxClassRevAmm.Tag="AutoManage.txtClassRevAmm.tree."+filter;
				gboxClassManAmm.Tag="AutoManage.txtClassManAmm.tree."+filter;
                gboxClassManDip.Tag = "AutoManage.txtClassManDip.tree." + filter;
                gboxClassLiq.Tag="AutoManage.txtClassLiq.tree."+filter;
				Meta.SetAutoMode(gboxClassRevDip);
				Meta.SetAutoMode(gboxClassRevAmm);
				Meta.SetAutoMode(gboxClassManAmm);
                Meta.SetAutoMode(gboxClassManDip);
                Meta.SetAutoMode(gboxClassLiq);
				//label per il form di selezione della voce di classificazione +"."+ filtro
				DS.sortingemployproc.ExtendedProperties[MetaData.ExtraParams] = Available;
				DS.sortingadminproc.ExtendedProperties[MetaData.ExtraParams] = Available;
				DS.sortingadminpay.ExtendedProperties[MetaData.ExtraParams] = Available;
                DS.sortingemploypay.ExtendedProperties[MetaData.ExtraParams] = Available;
                DS.sortingtaxpay.ExtendedProperties[MetaData.ExtraParams] = Available;
			}
		}

		public void MetaData_AfterFill(){
			SetCodiciClass();
		}
		
		private void chbEredita_CheckedChanged(object sender, System.EventArgs e) {
			if (chbEredita.Checked) {
				gboxClassManAmm.Enabled = false;
				if (!Meta.IsEmpty) {
					txtClassManAmm.Text = "";
					txtDescrClassManAmm.Text = "";
					DS.taxsortingsetup.Rows[0]["idsor_adminpay"] = DBNull.Value;
				}
			}
			else {
				gboxClassManAmm.Enabled = true;
			}
		}

	}
}
