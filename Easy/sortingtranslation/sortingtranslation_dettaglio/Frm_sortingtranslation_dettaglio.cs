
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;

namespace sortingtranslation_dettaglio//traduzioneclassificazioni_dettaglio//
{
	/// <summary>
	/// Summary description for FrmTraduzioneClassificazioni_Dettaglio.
	/// </summary>
	public class Frm_sortingtranslation_dettaglio : MetaDataForm
	{
		MetaData Meta;
		DataAccess Conn;

		private System.Windows.Forms.TextBox TxtDenominatore;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TxtNumeratore;
		private System.Windows.Forms.Label lblPercentuale;
		public System.Windows.Forms.CheckBox chkIgnoraDate;
		public System.Windows.Forms.TextBox valoreS5;
		public System.Windows.Forms.TextBox valoreN5;
		public System.Windows.Forms.TextBox valoreS4;
		public System.Windows.Forms.TextBox valoreN4;
		public System.Windows.Forms.TextBox valoreN2;
		public System.Windows.Forms.TextBox valoreS3;
		public System.Windows.Forms.TextBox valoreS2;
		public System.Windows.Forms.TextBox valoreN1;
		public System.Windows.Forms.TextBox valoreN3;
		public System.Windows.Forms.TextBox valoreS1;
		public System.Windows.Forms.Label labelS5;
		public System.Windows.Forms.Label labelS4;
		public System.Windows.Forms.Label labelS3;
		public System.Windows.Forms.Label labelS2;
		public System.Windows.Forms.Label labelS1;
		public System.Windows.Forms.Label labelN5;
		public System.Windows.Forms.Label labelN4;
		public System.Windows.Forms.Label labelN3;
		public System.Windows.Forms.Label labelN2;
		public System.Windows.Forms.Label labelN1;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		public vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox TxtCodiceOrigine;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label labelDescrizione;
		private System.Windows.Forms.Label labelTipoOrigine;
		private System.Windows.Forms.Label labelTipo;
		private System.Windows.Forms.ComboBox cmbTipoOrig;
        private System.Windows.Forms.TextBox TxtDescrOrigine;
		private System.Windows.Forms.TextBox txtCodiceDest;
		private System.Windows.Forms.TextBox txtDescrizioneDest;
		private System.Windows.Forms.Button btnCodiceDest;
		private System.Windows.Forms.GroupBox gboxClassDest;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label labelPorzione;
		public System.Windows.Forms.Label labelV1;
		public System.Windows.Forms.Label labelV2;
		public System.Windows.Forms.Label labelV3;
		public System.Windows.Forms.Label labelV4;
		public System.Windows.Forms.Label labelV5;
		public System.Windows.Forms.TextBox valoreV1;
		public System.Windows.Forms.TextBox valoreV2;
		public System.Windows.Forms.TextBox valoreV3;
		public System.Windows.Forms.TextBox valoreV4;
		public System.Windows.Forms.TextBox valoreV5;
        private TextBox txtTipoDest;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_sortingtranslation_dettaglio()
		{
			InitializeComponent();
			DataAccess.SetTableForReading(DS.sorting_master, "sorting");
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.DS = new sortingtranslation_dettaglio.vistaForm();
            this.TxtDenominatore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNumeratore = new System.Windows.Forms.TextBox();
            this.lblPercentuale = new System.Windows.Forms.Label();
            this.chkIgnoraDate = new System.Windows.Forms.CheckBox();
            this.valoreS5 = new System.Windows.Forms.TextBox();
            this.valoreN5 = new System.Windows.Forms.TextBox();
            this.valoreS4 = new System.Windows.Forms.TextBox();
            this.valoreN4 = new System.Windows.Forms.TextBox();
            this.valoreN2 = new System.Windows.Forms.TextBox();
            this.valoreS3 = new System.Windows.Forms.TextBox();
            this.valoreS2 = new System.Windows.Forms.TextBox();
            this.valoreN1 = new System.Windows.Forms.TextBox();
            this.valoreN3 = new System.Windows.Forms.TextBox();
            this.valoreS1 = new System.Windows.Forms.TextBox();
            this.labelS5 = new System.Windows.Forms.Label();
            this.labelS4 = new System.Windows.Forms.Label();
            this.labelS3 = new System.Windows.Forms.Label();
            this.labelS2 = new System.Windows.Forms.Label();
            this.labelS1 = new System.Windows.Forms.Label();
            this.labelN5 = new System.Windows.Forms.Label();
            this.labelN4 = new System.Windows.Forms.Label();
            this.labelN3 = new System.Windows.Forms.Label();
            this.labelN2 = new System.Windows.Forms.Label();
            this.labelN1 = new System.Windows.Forms.Label();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbTipoOrig = new System.Windows.Forms.ComboBox();
            this.labelTipoOrigine = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtCodiceOrigine = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtDescrOrigine = new System.Windows.Forms.TextBox();
            this.gboxClassDest = new System.Windows.Forms.GroupBox();
            this.labelTipo = new System.Windows.Forms.Label();
            this.labelDescrizione = new System.Windows.Forms.Label();
            this.txtDescrizioneDest = new System.Windows.Forms.TextBox();
            this.txtCodiceDest = new System.Windows.Forms.TextBox();
            this.btnCodiceDest = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.labelPorzione = new System.Windows.Forms.Label();
            this.labelV1 = new System.Windows.Forms.Label();
            this.labelV2 = new System.Windows.Forms.Label();
            this.labelV3 = new System.Windows.Forms.Label();
            this.labelV4 = new System.Windows.Forms.Label();
            this.labelV5 = new System.Windows.Forms.Label();
            this.valoreV1 = new System.Windows.Forms.TextBox();
            this.valoreV2 = new System.Windows.Forms.TextBox();
            this.valoreV3 = new System.Windows.Forms.TextBox();
            this.valoreV4 = new System.Windows.Forms.TextBox();
            this.valoreV5 = new System.Windows.Forms.TextBox();
            this.txtTipoDest = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.gboxClassDest.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // TxtDenominatore
            // 
            this.TxtDenominatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDenominatore.Location = new System.Drawing.Point(408, 272);
            this.TxtDenominatore.Name = "TxtDenominatore";
            this.TxtDenominatore.Size = new System.Drawing.Size(80, 22);
            this.TxtDenominatore.TabIndex = 265;
            this.TxtDenominatore.Tag = "sortingtranslation.denominator";
            this.TxtDenominatore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(384, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 8);
            this.label4.TabIndex = 264;
            this.label4.Text = "__________________________";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TxtNumeratore
            // 
            this.TxtNumeratore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeratore.Location = new System.Drawing.Point(408, 232);
            this.TxtNumeratore.Name = "TxtNumeratore";
            this.TxtNumeratore.Size = new System.Drawing.Size(80, 22);
            this.TxtNumeratore.TabIndex = 263;
            this.TxtNumeratore.Tag = "sortingtranslation.numerator";
            this.TxtNumeratore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPercentuale
            // 
            this.lblPercentuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentuale.Location = new System.Drawing.Point(384, 216);
            this.lblPercentuale.Name = "lblPercentuale";
            this.lblPercentuale.Size = new System.Drawing.Size(136, 16);
            this.lblPercentuale.TabIndex = 262;
            this.lblPercentuale.Text = "Porzione da classificare";
            // 
            // chkIgnoraDate
            // 
            this.chkIgnoraDate.Location = new System.Drawing.Point(32, 264);
            this.chkIgnoraDate.Name = "chkIgnoraDate";
            this.chkIgnoraDate.Size = new System.Drawing.Size(80, 16);
            this.chkIgnoraDate.TabIndex = 260;
            this.chkIgnoraDate.Tag = "sortingtranslation.flagnodate:S:N";
            this.chkIgnoraDate.Text = "Ignora date";
            // 
            // valoreS5
            // 
            this.valoreS5.Location = new System.Drawing.Point(552, 184);
            this.valoreS5.Name = "valoreS5";
            this.valoreS5.Size = new System.Drawing.Size(144, 20);
            this.valoreS5.TabIndex = 289;
            this.valoreS5.Tag = "sortingtranslation.defaults5";
            // 
            // valoreN5
            // 
            this.valoreN5.Location = new System.Drawing.Point(392, 184);
            this.valoreN5.Name = "valoreN5";
            this.valoreN5.Size = new System.Drawing.Size(144, 20);
            this.valoreN5.TabIndex = 288;
            this.valoreN5.Tag = "sortingtranslation.defaultn5";
            // 
            // valoreS4
            // 
            this.valoreS4.Location = new System.Drawing.Point(552, 144);
            this.valoreS4.Name = "valoreS4";
            this.valoreS4.Size = new System.Drawing.Size(144, 20);
            this.valoreS4.TabIndex = 285;
            this.valoreS4.Tag = "sortingtranslation.defaults4";
            // 
            // valoreN4
            // 
            this.valoreN4.Location = new System.Drawing.Point(392, 144);
            this.valoreN4.Name = "valoreN4";
            this.valoreN4.Size = new System.Drawing.Size(144, 20);
            this.valoreN4.TabIndex = 284;
            this.valoreN4.Tag = "sortingtranslation.defaultn4";
            // 
            // valoreN2
            // 
            this.valoreN2.Location = new System.Drawing.Point(392, 64);
            this.valoreN2.Name = "valoreN2";
            this.valoreN2.Size = new System.Drawing.Size(144, 20);
            this.valoreN2.TabIndex = 276;
            this.valoreN2.Tag = "sortingtranslation.defaultn2";
            // 
            // valoreS3
            // 
            this.valoreS3.Location = new System.Drawing.Point(552, 104);
            this.valoreS3.Name = "valoreS3";
            this.valoreS3.Size = new System.Drawing.Size(144, 20);
            this.valoreS3.TabIndex = 281;
            this.valoreS3.Tag = "sortingtranslation.defaults3";
            // 
            // valoreS2
            // 
            this.valoreS2.Location = new System.Drawing.Point(552, 64);
            this.valoreS2.Name = "valoreS2";
            this.valoreS2.Size = new System.Drawing.Size(144, 20);
            this.valoreS2.TabIndex = 277;
            this.valoreS2.Tag = "sortingtranslation.defaults2";
            // 
            // valoreN1
            // 
            this.valoreN1.Location = new System.Drawing.Point(392, 24);
            this.valoreN1.Name = "valoreN1";
            this.valoreN1.Size = new System.Drawing.Size(144, 20);
            this.valoreN1.TabIndex = 272;
            this.valoreN1.Tag = "sortingtranslation.defaultn1";
            // 
            // valoreN3
            // 
            this.valoreN3.Location = new System.Drawing.Point(392, 104);
            this.valoreN3.Name = "valoreN3";
            this.valoreN3.Size = new System.Drawing.Size(144, 20);
            this.valoreN3.TabIndex = 280;
            this.valoreN3.Tag = "sortingtranslation.defaultn3";
            // 
            // valoreS1
            // 
            this.valoreS1.Location = new System.Drawing.Point(552, 24);
            this.valoreS1.Name = "valoreS1";
            this.valoreS1.Size = new System.Drawing.Size(144, 20);
            this.valoreS1.TabIndex = 273;
            this.valoreS1.Tag = "sortingtranslation.defaults1";
            // 
            // labelS5
            // 
            this.labelS5.Location = new System.Drawing.Point(552, 168);
            this.labelS5.Name = "labelS5";
            this.labelS5.Size = new System.Drawing.Size(144, 16);
            this.labelS5.TabIndex = 287;
            this.labelS5.Tag = "sortingkind.labels5";
            this.labelS5.Text = "labelS5";
            // 
            // labelS4
            // 
            this.labelS4.Location = new System.Drawing.Point(552, 128);
            this.labelS4.Name = "labelS4";
            this.labelS4.Size = new System.Drawing.Size(144, 16);
            this.labelS4.TabIndex = 283;
            this.labelS4.Tag = "sortingkind.labels4";
            this.labelS4.Text = "labelS4";
            // 
            // labelS3
            // 
            this.labelS3.Location = new System.Drawing.Point(552, 88);
            this.labelS3.Name = "labelS3";
            this.labelS3.Size = new System.Drawing.Size(144, 16);
            this.labelS3.TabIndex = 279;
            this.labelS3.Tag = "sortingkind.labels3";
            this.labelS3.Text = "labelS3";
            // 
            // labelS2
            // 
            this.labelS2.Location = new System.Drawing.Point(552, 48);
            this.labelS2.Name = "labelS2";
            this.labelS2.Size = new System.Drawing.Size(144, 16);
            this.labelS2.TabIndex = 275;
            this.labelS2.Tag = "sortingkind.labels2";
            this.labelS2.Text = "labelS2";
            // 
            // labelS1
            // 
            this.labelS1.Location = new System.Drawing.Point(552, 8);
            this.labelS1.Name = "labelS1";
            this.labelS1.Size = new System.Drawing.Size(144, 16);
            this.labelS1.TabIndex = 271;
            this.labelS1.Tag = "sortingkind.labels1";
            this.labelS1.Text = "labelS1";
            // 
            // labelN5
            // 
            this.labelN5.Location = new System.Drawing.Point(392, 168);
            this.labelN5.Name = "labelN5";
            this.labelN5.Size = new System.Drawing.Size(144, 16);
            this.labelN5.TabIndex = 286;
            this.labelN5.Tag = "sortingkind.labeln5";
            this.labelN5.Text = "labelN5";
            // 
            // labelN4
            // 
            this.labelN4.Location = new System.Drawing.Point(392, 128);
            this.labelN4.Name = "labelN4";
            this.labelN4.Size = new System.Drawing.Size(144, 16);
            this.labelN4.TabIndex = 282;
            this.labelN4.Tag = "sortingkind.labeln4";
            this.labelN4.Text = "labelN4";
            // 
            // labelN3
            // 
            this.labelN3.Location = new System.Drawing.Point(392, 88);
            this.labelN3.Name = "labelN3";
            this.labelN3.Size = new System.Drawing.Size(144, 16);
            this.labelN3.TabIndex = 278;
            this.labelN3.Tag = "sortingkind.labeln3";
            this.labelN3.Text = "labelN3";
            // 
            // labelN2
            // 
            this.labelN2.Location = new System.Drawing.Point(392, 48);
            this.labelN2.Name = "labelN2";
            this.labelN2.Size = new System.Drawing.Size(144, 16);
            this.labelN2.TabIndex = 274;
            this.labelN2.Tag = "sortingkind.labeln2";
            this.labelN2.Text = "labelN2";
            // 
            // labelN1
            // 
            this.labelN1.Location = new System.Drawing.Point(392, 8);
            this.labelN1.Name = "labelN1";
            this.labelN1.Size = new System.Drawing.Size(144, 16);
            this.labelN1.TabIndex = 270;
            this.labelN1.Tag = "sortingkind.labeln1";
            this.labelN1.Text = "labelN1";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(0, 0);
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(100, 20);
            this.txtDenominazioneBilancio.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbTipoOrig);
            this.groupBox4.Controls.Add(this.labelTipoOrigine);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.TxtCodiceOrigine);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.TxtDescrOrigine);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(372, 112);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Classificazione origine";
            // 
            // cmbTipoOrig
            // 
            this.cmbTipoOrig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoOrig.DataSource = this.DS.sortingkind;
            this.cmbTipoOrig.DisplayMember = "description";
            this.cmbTipoOrig.Enabled = false;
            this.cmbTipoOrig.Location = new System.Drawing.Point(80, 16);
            this.cmbTipoOrig.Name = "cmbTipoOrig";
            this.cmbTipoOrig.Size = new System.Drawing.Size(280, 21);
            this.cmbTipoOrig.TabIndex = 9;
            this.cmbTipoOrig.Tag = "sorting_master.idsorkind";
            this.cmbTipoOrig.ValueMember = "idsorkind";
            // 
            // labelTipoOrigine
            // 
            this.labelTipoOrigine.Location = new System.Drawing.Point(8, 16);
            this.labelTipoOrigine.Name = "labelTipoOrigine";
            this.labelTipoOrigine.Size = new System.Drawing.Size(64, 23);
            this.labelTipoOrigine.TabIndex = 8;
            this.labelTipoOrigine.Text = "Tipo";
            this.labelTipoOrigine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Codice";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtCodiceOrigine
            // 
            this.TxtCodiceOrigine.Location = new System.Drawing.Point(80, 48);
            this.TxtCodiceOrigine.Name = "TxtCodiceOrigine";
            this.TxtCodiceOrigine.ReadOnly = true;
            this.TxtCodiceOrigine.Size = new System.Drawing.Size(280, 20);
            this.TxtCodiceOrigine.TabIndex = 5;
            this.TxtCodiceOrigine.Tag = "sorting_master.sortcode";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Descrizione";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtDescrOrigine
            // 
            this.TxtDescrOrigine.Location = new System.Drawing.Point(80, 80);
            this.TxtDescrOrigine.Name = "TxtDescrOrigine";
            this.TxtDescrOrigine.ReadOnly = true;
            this.TxtDescrOrigine.Size = new System.Drawing.Size(280, 20);
            this.TxtDescrOrigine.TabIndex = 6;
            this.TxtDescrOrigine.Tag = "sorting_master.description";
            // 
            // gboxClassDest
            // 
            this.gboxClassDest.Controls.Add(this.txtTipoDest);
            this.gboxClassDest.Controls.Add(this.labelTipo);
            this.gboxClassDest.Controls.Add(this.labelDescrizione);
            this.gboxClassDest.Controls.Add(this.txtDescrizioneDest);
            this.gboxClassDest.Controls.Add(this.txtCodiceDest);
            this.gboxClassDest.Controls.Add(this.btnCodiceDest);
            this.gboxClassDest.Location = new System.Drawing.Point(8, 128);
            this.gboxClassDest.Name = "gboxClassDest";
            this.gboxClassDest.Size = new System.Drawing.Size(372, 112);
            this.gboxClassDest.TabIndex = 14;
            this.gboxClassDest.TabStop = false;
            this.gboxClassDest.Tag = "AutoManage.txtCodiceDest.tree";
            this.gboxClassDest.Text = "Classificazione destinazione";
            // 
            // labelTipo
            // 
            this.labelTipo.Location = new System.Drawing.Point(8, 16);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(64, 23);
            this.labelTipo.TabIndex = 13;
            this.labelTipo.Text = "Tipo";
            this.labelTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDescrizione
            // 
            this.labelDescrizione.Location = new System.Drawing.Point(8, 88);
            this.labelDescrizione.Name = "labelDescrizione";
            this.labelDescrizione.Size = new System.Drawing.Size(64, 16);
            this.labelDescrizione.TabIndex = 8;
            this.labelDescrizione.Text = "Descrizione";
            this.labelDescrizione.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDescrizioneDest
            // 
            this.txtDescrizioneDest.Location = new System.Drawing.Point(80, 80);
            this.txtDescrizioneDest.Multiline = true;
            this.txtDescrizioneDest.Name = "txtDescrizioneDest";
            this.txtDescrizioneDest.ReadOnly = true;
            this.txtDescrizioneDest.Size = new System.Drawing.Size(280, 24);
            this.txtDescrizioneDest.TabIndex = 6;
            this.txtDescrizioneDest.TabStop = false;
            this.txtDescrizioneDest.Tag = "sorting.description";
            // 
            // txtCodiceDest
            // 
            this.txtCodiceDest.Location = new System.Drawing.Point(80, 48);
            this.txtCodiceDest.Name = "txtCodiceDest";
            this.txtCodiceDest.Size = new System.Drawing.Size(280, 20);
            this.txtCodiceDest.TabIndex = 7;
            this.txtCodiceDest.Tag = "sorting.sortcode?x";
            // 
            // btnCodiceDest
            // 
            this.btnCodiceDest.Location = new System.Drawing.Point(8, 48);
            this.btnCodiceDest.Name = "btnCodiceDest";
            this.btnCodiceDest.Size = new System.Drawing.Size(64, 23);
            this.btnCodiceDest.TabIndex = 2;
            this.btnCodiceDest.Tag = "manage.sorting.tree";
            this.btnCodiceDest.Text = "Codice";
            this.btnCodiceDest.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(832, 248);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 293;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(736, 248);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 292;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // labelPorzione
            // 
            this.labelPorzione.Location = new System.Drawing.Point(520, 216);
            this.labelPorzione.Name = "labelPorzione";
            this.labelPorzione.Size = new System.Drawing.Size(184, 23);
            this.labelPorzione.TabIndex = 294;
            // 
            // labelV1
            // 
            this.labelV1.Location = new System.Drawing.Point(704, 8);
            this.labelV1.Name = "labelV1";
            this.labelV1.Size = new System.Drawing.Size(144, 16);
            this.labelV1.TabIndex = 295;
            this.labelV1.Tag = "sortingkind.labelv1";
            this.labelV1.Text = "labelV1";
            // 
            // labelV2
            // 
            this.labelV2.Location = new System.Drawing.Point(704, 48);
            this.labelV2.Name = "labelV2";
            this.labelV2.Size = new System.Drawing.Size(144, 16);
            this.labelV2.TabIndex = 297;
            this.labelV2.Tag = "sortingkind.labelv2";
            this.labelV2.Text = "labelV2";
            // 
            // labelV3
            // 
            this.labelV3.Location = new System.Drawing.Point(704, 88);
            this.labelV3.Name = "labelV3";
            this.labelV3.Size = new System.Drawing.Size(144, 16);
            this.labelV3.TabIndex = 299;
            this.labelV3.Tag = "sortingkind.labelv3";
            this.labelV3.Text = "labelV3";
            // 
            // labelV4
            // 
            this.labelV4.Location = new System.Drawing.Point(704, 128);
            this.labelV4.Name = "labelV4";
            this.labelV4.Size = new System.Drawing.Size(144, 16);
            this.labelV4.TabIndex = 301;
            this.labelV4.Tag = "sortingkind.labelv4";
            this.labelV4.Text = "labelV4";
            // 
            // labelV5
            // 
            this.labelV5.Location = new System.Drawing.Point(704, 168);
            this.labelV5.Name = "labelV5";
            this.labelV5.Size = new System.Drawing.Size(144, 16);
            this.labelV5.TabIndex = 303;
            this.labelV5.Tag = "sortingkind.labelv5";
            this.labelV5.Text = "labelV5";
            // 
            // valoreV1
            // 
            this.valoreV1.Location = new System.Drawing.Point(704, 24);
            this.valoreV1.Name = "valoreV1";
            this.valoreV1.Size = new System.Drawing.Size(144, 20);
            this.valoreV1.TabIndex = 296;
            this.valoreV1.Tag = "sortingtranslation.defaultv1";
            // 
            // valoreV2
            // 
            this.valoreV2.Location = new System.Drawing.Point(704, 64);
            this.valoreV2.Name = "valoreV2";
            this.valoreV2.Size = new System.Drawing.Size(144, 20);
            this.valoreV2.TabIndex = 298;
            this.valoreV2.Tag = "sortingtranslation.defaultv2";
            // 
            // valoreV3
            // 
            this.valoreV3.Location = new System.Drawing.Point(704, 104);
            this.valoreV3.Name = "valoreV3";
            this.valoreV3.Size = new System.Drawing.Size(144, 20);
            this.valoreV3.TabIndex = 300;
            this.valoreV3.Tag = "sortingtranslation.defaultv3";
            // 
            // valoreV4
            // 
            this.valoreV4.Location = new System.Drawing.Point(704, 144);
            this.valoreV4.Name = "valoreV4";
            this.valoreV4.Size = new System.Drawing.Size(144, 20);
            this.valoreV4.TabIndex = 302;
            this.valoreV4.Tag = "sortingtranslation.defaultv4";
            // 
            // valoreV5
            // 
            this.valoreV5.Location = new System.Drawing.Point(704, 184);
            this.valoreV5.Name = "valoreV5";
            this.valoreV5.Size = new System.Drawing.Size(144, 20);
            this.valoreV5.TabIndex = 304;
            this.valoreV5.Tag = "sortingtranslation.defaultv5";
            // 
            // txtTipoDest
            // 
            this.txtTipoDest.Location = new System.Drawing.Point(78, 16);
            this.txtTipoDest.Name = "txtTipoDest";
            this.txtTipoDest.ReadOnly = true;
            this.txtTipoDest.Size = new System.Drawing.Size(282, 20);
            this.txtTipoDest.TabIndex = 14;
            // 
            // Frm_sortingtranslation_dettaglio
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(912, 302);
            this.Controls.Add(this.labelV1);
            this.Controls.Add(this.labelV2);
            this.Controls.Add(this.labelV3);
            this.Controls.Add(this.labelV4);
            this.Controls.Add(this.labelV5);
            this.Controls.Add(this.valoreV1);
            this.Controls.Add(this.valoreV2);
            this.Controls.Add(this.valoreV3);
            this.Controls.Add(this.valoreV4);
            this.Controls.Add(this.valoreV5);
            this.Controls.Add(this.valoreS1);
            this.Controls.Add(this.valoreN3);
            this.Controls.Add(this.valoreN1);
            this.Controls.Add(this.valoreS2);
            this.Controls.Add(this.valoreS3);
            this.Controls.Add(this.valoreN2);
            this.Controls.Add(this.valoreN4);
            this.Controls.Add(this.valoreS4);
            this.Controls.Add(this.valoreN5);
            this.Controls.Add(this.valoreS5);
            this.Controls.Add(this.TxtNumeratore);
            this.Controls.Add(this.TxtDenominatore);
            this.Controls.Add(this.labelPorzione);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.labelN3);
            this.Controls.Add(this.labelN4);
            this.Controls.Add(this.labelN5);
            this.Controls.Add(this.labelS1);
            this.Controls.Add(this.labelS2);
            this.Controls.Add(this.labelS3);
            this.Controls.Add(this.labelS4);
            this.Controls.Add(this.labelS5);
            this.Controls.Add(this.chkIgnoraDate);
            this.Controls.Add(this.lblPercentuale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelN1);
            this.Controls.Add(this.labelN2);
            this.Controls.Add(this.gboxClassDest);
            this.Name = "Frm_sortingtranslation_dettaglio";
            this.Text = "FrmTraduzioneClassificazioni_Dettaglio";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gboxClassDest.ResumeLayout(false);
            this.gboxClassDest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        CQueryHelper QHC;
        QueryHelper QHS;
        DataRow SortingKindChild;
		public void MetaData_AfterLink()
		{
			Meta= MetaData.GetMetaData(this);
			Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            SortingKindChild = Meta.ExtraParameter as DataRow;
            txtTipoDest.Text = SortingKindChild["description"].ToString();
            
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R)
		{
			if (T.TableName == "sortingkind") 
			{
                //if (MetaData.GetMetaData(this).DrawState== MetaData.form_drawstates.done) 
                //{
                //    if ((!MetaData.Empty(this)))
                //    {
                //        DS.sortingtranslation.Rows[0]["idsortingchild"]=0;
                //    }
                //    txtCodiceDest.Text="";
                //    txtDescrizioneDest.Text="";
                //    DS.sorting.Clear();
                //}
				SetCodiceMovim();
				AggiornaEtichette();
			}
		}

		void SetCodiceMovim()
		{
            btnCodiceDest.Enabled = true; // (cmbTipoDest.SelectedIndex != 0);
            txtCodiceDest.ReadOnly = false; // (cmbTipoDest.SelectedIndex == 0);
            //if (cmbTipoDest.SelectedIndex==0)
            //{
            //    txtCodiceDest.Text="";
            //    txtDescrizioneDest.Text="";
            //}
            //else 
            //{
				string filter = QHS.CmpEq("idsorkind", SortingKindChild["idsorkind"]);
                                // cmbTipoDest.SelectedValue);
				DataTable Available= Conn.RUN_SELECT("sorting","*",null,filter,null,null,true);
				btnCodiceDest.Tag="manage.sorting.tree."+filter;
				gboxClassDest.Tag="AutoManage.txtCodiceDest.tree."+filter;
				Meta.SetAutoMode(gboxClassDest);
				//label per il form di selezione della voce di classificazione +"."+ filtro
				DS.sorting.ExtendedProperties[MetaData.ExtraParams]=Available;
            //}
		}


		public void MetaData_AfterClear()
		{
			TxtDenominatore.TextAlign= HorizontalAlignment.Center;
			TxtNumeratore.TextAlign= HorizontalAlignment.Center;
		}

		public void MetaData_AfterFill()
		{
            if (Meta.FirstFillForThisRow) {
                SetCodiceMovim();
                AggiornaEtichette();
            }
//Pino			SetCodiceCredDeb();
			TxtDenominatore.TextAlign = HorizontalAlignment.Center;
			TxtNumeratore.TextAlign = HorizontalAlignment.Center;
            //cmbTipoDest.Tag = null;
			SetCodiceMovim();
			long sommaNum, sommaDen;
			getPorzioneAncoraDaClassificare(DS.sortingtranslation.Rows[0], out sommaNum, out sommaDen);
			if ((sommaDen != 0) && (sommaNum > 0))
			{
				labelPorzione.Text = "(valore massimo: "+sommaNum+"/"+sommaDen+")";
			}
		}

		public long massimoComuneDivisore(long x, long y) 
		{
			while (y != 0) 
			{
				long m = x % y;
				x = y;
				y = m;
			}
			return x;
		}

		public void getPorzioneAncoraDaClassificare(DataRow R, out long sommaNum, out long sommaDen) 
		{
			sommaDen = 1;
			sommaNum = 1;
            object codiceTipoClassChild = SortingKindChild["idsorkind"]; // R["sortingkindchild"];
			object idClassChild = R["idsortingchild"];
			DataTable tradClassOrig = Meta.SourceRow.Table;
			string filtro = QHC.AppAnd(QHC.CmpEq("!sortingkindchild", codiceTipoClassChild),
                QHC.CmpNe("idsortingchild", idClassChild));

			foreach (DataRow r in tradClassOrig.Select(filtro)) 
			{
				if ((r["numerator"] != DBNull.Value) && (r["denominator"] != DBNull.Value))
				{
					long numeratore = (int) r["numerator"];
					long denominatore = (int) r["denominator"];
					sommaNum = sommaNum * denominatore - sommaDen * numeratore;
					sommaDen *= denominatore;
					long mcd = massimoComuneDivisore(sommaNum, sommaDen);
					if (mcd == 0) return;
					sommaNum /= mcd;
					sommaDen /= mcd;
				}
			}
			if (sommaDen < 0) 
			{
				sommaNum = -sommaNum;
				sommaDen = -sommaDen;
			}
		}

		void AggiornaEtichette()
		{
            //if (cmbTipoDest.SelectedIndex<=0) 
            //{
            //    return;
            //}
            //string codtipomov = SortingKindChild["idsorkind"]; cmbTipoDest.SelectedValue.ToString();
            DataRow Rtipo = SortingKindChild;
                //DS.sortingkind.Select(QHC.CmpEq("idsorkind", codtipomov))[0];
			
			if (Rtipo["flagdate"].ToString().ToLower()!="s") 
			{
				chkIgnoraDate.Visible = false;
			}
			else 
			{
				chkIgnoraDate.Visible = true;
				HelpForm.SetDenyNull(DS.sortingtranslation.Columns["flagnodate"],true);
			}

			foreach(string kind in new string[]{"n","s","v"}) 
			{
				for (int i=1; i<=5; i++) 
				{
					string suffix= kind+i.ToString();
					TextBox T = GetTxtByName("valore"+suffix.ToUpper());
					Label L = GetLblByname("label"+suffix.ToUpper());
					if (Rtipo["label"+suffix].ToString()=="") 
					{
						L.Visible=false;
						T.Visible=false;
						T.Text="";
					}
					else 
					{
						L.Visible=true;
						L.Text= Rtipo["label"+suffix].ToString();
						T.Visible=true;
					}
					
					if (Rtipo["forced"+suffix].ToString().ToLower()=="s") 
					{
						//						if (CurrRow["valore"+suffix]==DBNull.Value) 
						//						{
						//							if (kind=="N")CurrRow["valore"+suffix]=0;
						//							if (kind=="S")CurrRow["valore"+suffix]="";
						if (kind=="n") 
							MetaData.SetDefault(DS.sortingtranslation, "default"+suffix, 0);
						if (kind=="s") 
							MetaData.SetDefault(DS.sortingtranslation, "default"+suffix, "");
						if (kind=="v") 
							MetaData.SetDefault(DS.sortingtranslation, "default"+suffix, 0);
						//						}
						HelpForm.SetDenyNull(DS.Tables["sortingtranslation"].Columns["default"+suffix],true);
					}
				}
			}

		}

		void NascondiEtichette()
		{
			chkIgnoraDate.Visible = false;
			foreach(string kind in new string[]{"n","s","v"}) 
			{
				for (int i=1; i<=5; i++) 
				{
					string suffix= kind+i.ToString();
					TextBox T = GetTxtByName("valore"+suffix.ToUpper());
					Label L = GetLblByname("label"+suffix.ToUpper());
					L.Visible=false;
					T.Visible=false;		
					T.Text="";
				}
			}

		}

		TextBox GetTxtByName(string Name) 
		{
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			TextBox T =  (TextBox) Ctrl.GetValue(this);                        
			return T;
		}

		Label GetLblByname(string Name) 
		{
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;
			Label L = (Label) Ctrl.GetValue(this);
			return L; 
		}

	}
}
