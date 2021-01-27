
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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Globalization;
using funzioni_configurazione;//funzioni_configurazione

namespace incomesorted_default//ImpClassEntrata//
{
	/// <summary>
	/// Summary description for FrmImpClassEntrata.
	/// </summary>
	public class Frm_incomesorted_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkIncompleto;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
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
		private System.Windows.Forms.TextBox txtPercentuale;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.TextBox txtSubmovimento;
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
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelignoradate;
		private System.Windows.Forms.CheckBox chkIgnoraDate;
		private System.Windows.Forms.Label labelslash;
		private System.Windows.Forms.Label datalabel;
		public System.Windows.Forms.TextBox DataFine;
		public System.Windows.Forms.TextBox DataInizio;
		private System.Windows.Forms.Label lblPercentuale;
		private System.Windows.Forms.Label lblImporto;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtCodiceClass;
		private System.Windows.Forms.TextBox txtDescrizioneClass;
		private System.Windows.Forms.Label label3;
		public /*Rana:ImpClassEntrata.*/vistaForm DS;
		bool HasBeenActivated;

		decimal importototale;
		decimal importoresiduo;
		decimal importomovimento;
		decimal importooriginale;
		MetaData Meta;
		public System.Windows.Forms.TextBox valoreV5;
		public System.Windows.Forms.TextBox valoreV4;
		public System.Windows.Forms.TextBox valoreV3;
		public System.Windows.Forms.TextBox valoreV2;
		public System.Windows.Forms.TextBox valoreV1;
		public System.Windows.Forms.Label labelV5;
		public System.Windows.Forms.Label labelV4;
		public System.Windows.Forms.Label labelV3;
		public System.Windows.Forms.Label labelV2;
		public System.Windows.Forms.Label labelV1;
		bool primolivello=false;
		bool secondolivello=false;
		bool terzolivello=false;
		bool formcorto=false;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		public Frm_incomesorted_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			HasBeenActivated=false;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_incomesorted_default));
            this.label1 = new System.Windows.Forms.Label();
            this.chkIncompleto = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
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
            this.txtPercentuale = new System.Windows.Forms.TextBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtSubmovimento = new System.Windows.Forms.TextBox();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelignoradate = new System.Windows.Forms.Label();
            this.chkIgnoraDate = new System.Windows.Forms.CheckBox();
            this.labelslash = new System.Windows.Forms.Label();
            this.datalabel = new System.Windows.Forms.Label();
            this.DataFine = new System.Windows.Forms.TextBox();
            this.DataInizio = new System.Windows.Forms.TextBox();
            this.lblPercentuale = new System.Windows.Forms.Label();
            this.lblImporto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtCodiceClass = new System.Windows.Forms.TextBox();
            this.txtDescrizioneClass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DS = new incomesorted_default.vistaForm();
            this.valoreV5 = new System.Windows.Forms.TextBox();
            this.valoreV4 = new System.Windows.Forms.TextBox();
            this.valoreV3 = new System.Windows.Forms.TextBox();
            this.valoreV2 = new System.Windows.Forms.TextBox();
            this.valoreV1 = new System.Windows.Forms.TextBox();
            this.labelV5 = new System.Windows.Forms.Label();
            this.labelV4 = new System.Windows.Forms.Label();
            this.labelV3 = new System.Windows.Forms.Label();
            this.labelV2 = new System.Windows.Forms.Label();
            this.labelV1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 226;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIncompleto
            // 
            this.chkIncompleto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIncompleto.Location = new System.Drawing.Point(8, 312);
            this.chkIncompleto.Name = "chkIncompleto";
            this.chkIncompleto.Size = new System.Drawing.Size(152, 32);
            this.chkIncompleto.TabIndex = 4;
            this.chkIncompleto.Tag = "incomesorted.tobecontinued:S:N";
            this.chkIncompleto.Text = "Da completare in seguito";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(608, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 1000;
            this.btnCancel.Text = "&Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(728, 312);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 23);
            this.btnOk.TabIndex = 1001;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "&OK";
            // 
            // valoreS5
            // 
            this.valoreS5.Location = new System.Drawing.Point(528, 272);
            this.valoreS5.Name = "valoreS5";
            this.valoreS5.Size = new System.Drawing.Size(144, 20);
            this.valoreS5.TabIndex = 222;
            this.valoreS5.Tag = "";
            this.valoreS5.Visible = false;
            // 
            // valoreN5
            // 
            this.valoreN5.Location = new System.Drawing.Point(376, 272);
            this.valoreN5.Name = "valoreN5";
            this.valoreN5.Size = new System.Drawing.Size(144, 20);
            this.valoreN5.TabIndex = 221;
            this.valoreN5.Tag = "";
            this.valoreN5.Visible = false;
            // 
            // valoreS4
            // 
            this.valoreS4.Location = new System.Drawing.Point(528, 232);
            this.valoreS4.Name = "valoreS4";
            this.valoreS4.Size = new System.Drawing.Size(144, 20);
            this.valoreS4.TabIndex = 220;
            this.valoreS4.Tag = "";
            this.valoreS4.Visible = false;
            // 
            // valoreN4
            // 
            this.valoreN4.Location = new System.Drawing.Point(376, 232);
            this.valoreN4.Name = "valoreN4";
            this.valoreN4.Size = new System.Drawing.Size(144, 20);
            this.valoreN4.TabIndex = 219;
            this.valoreN4.Tag = "";
            this.valoreN4.Visible = false;
            // 
            // valoreN2
            // 
            this.valoreN2.Location = new System.Drawing.Point(376, 152);
            this.valoreN2.Name = "valoreN2";
            this.valoreN2.Size = new System.Drawing.Size(144, 20);
            this.valoreN2.TabIndex = 207;
            this.valoreN2.Tag = "";
            this.valoreN2.Visible = false;
            // 
            // valoreS3
            // 
            this.valoreS3.Location = new System.Drawing.Point(528, 192);
            this.valoreS3.Name = "valoreS3";
            this.valoreS3.Size = new System.Drawing.Size(144, 20);
            this.valoreS3.TabIndex = 216;
            this.valoreS3.Tag = "";
            this.valoreS3.Visible = false;
            // 
            // valoreS2
            // 
            this.valoreS2.Location = new System.Drawing.Point(528, 152);
            this.valoreS2.Name = "valoreS2";
            this.valoreS2.Size = new System.Drawing.Size(144, 20);
            this.valoreS2.TabIndex = 215;
            this.valoreS2.Tag = "";
            this.valoreS2.Visible = false;
            // 
            // valoreN1
            // 
            this.valoreN1.Location = new System.Drawing.Point(376, 112);
            this.valoreN1.Name = "valoreN1";
            this.valoreN1.Size = new System.Drawing.Size(144, 20);
            this.valoreN1.TabIndex = 206;
            this.valoreN1.Tag = "";
            this.valoreN1.Visible = false;
            // 
            // valoreN3
            // 
            this.valoreN3.Location = new System.Drawing.Point(376, 192);
            this.valoreN3.Name = "valoreN3";
            this.valoreN3.Size = new System.Drawing.Size(144, 20);
            this.valoreN3.TabIndex = 208;
            this.valoreN3.Tag = "";
            this.valoreN3.Visible = false;
            // 
            // valoreS1
            // 
            this.valoreS1.Location = new System.Drawing.Point(528, 112);
            this.valoreS1.Name = "valoreS1";
            this.valoreS1.Size = new System.Drawing.Size(144, 20);
            this.valoreS1.TabIndex = 214;
            this.valoreS1.Tag = "";
            this.valoreS1.Visible = false;
            // 
            // txtPercentuale
            // 
            this.txtPercentuale.Location = new System.Drawing.Point(168, 104);
            this.txtPercentuale.Name = "txtPercentuale";
            this.txtPercentuale.Size = new System.Drawing.Size(80, 20);
            this.txtPercentuale.TabIndex = 3;
            this.txtPercentuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentuale.Leave += new System.EventHandler(this.txtPercentuale_Leave);
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(8, 104);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(144, 20);
            this.txtImporto.TabIndex = 2;
            this.txtImporto.Tag = "incomesorted.amount";
            this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(8, 40);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(328, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "incomesorted.description";
            // 
            // txtSubmovimento
            // 
            this.txtSubmovimento.Location = new System.Drawing.Point(236, 16);
            this.txtSubmovimento.Name = "txtSubmovimento";
            this.txtSubmovimento.ReadOnly = true;
            this.txtSubmovimento.Size = new System.Drawing.Size(100, 20);
            this.txtSubmovimento.TabIndex = 193;
            this.txtSubmovimento.TabStop = false;
            this.txtSubmovimento.Tag = "incomesorted.idsubclass";
            // 
            // labelS5
            // 
            this.labelS5.Location = new System.Drawing.Point(528, 256);
            this.labelS5.Name = "labelS5";
            this.labelS5.Size = new System.Drawing.Size(144, 16);
            this.labelS5.TabIndex = 218;
            this.labelS5.Tag = "";
            this.labelS5.Text = "labelS5";
            this.labelS5.Visible = false;
            // 
            // labelS4
            // 
            this.labelS4.Location = new System.Drawing.Point(528, 216);
            this.labelS4.Name = "labelS4";
            this.labelS4.Size = new System.Drawing.Size(144, 16);
            this.labelS4.TabIndex = 217;
            this.labelS4.Tag = "";
            this.labelS4.Text = "labelS4";
            this.labelS4.Visible = false;
            // 
            // labelS3
            // 
            this.labelS3.Location = new System.Drawing.Point(528, 176);
            this.labelS3.Name = "labelS3";
            this.labelS3.Size = new System.Drawing.Size(144, 16);
            this.labelS3.TabIndex = 213;
            this.labelS3.Tag = "";
            this.labelS3.Text = "labelS3";
            this.labelS3.Visible = false;
            // 
            // labelS2
            // 
            this.labelS2.Location = new System.Drawing.Point(528, 136);
            this.labelS2.Name = "labelS2";
            this.labelS2.Size = new System.Drawing.Size(144, 16);
            this.labelS2.TabIndex = 212;
            this.labelS2.Tag = "";
            this.labelS2.Text = "labelS2";
            this.labelS2.Visible = false;
            // 
            // labelS1
            // 
            this.labelS1.Location = new System.Drawing.Point(528, 96);
            this.labelS1.Name = "labelS1";
            this.labelS1.Size = new System.Drawing.Size(144, 16);
            this.labelS1.TabIndex = 211;
            this.labelS1.Tag = "";
            this.labelS1.Text = "labelS1";
            this.labelS1.Visible = false;
            // 
            // labelN5
            // 
            this.labelN5.Location = new System.Drawing.Point(376, 256);
            this.labelN5.Name = "labelN5";
            this.labelN5.Size = new System.Drawing.Size(144, 16);
            this.labelN5.TabIndex = 210;
            this.labelN5.Tag = "";
            this.labelN5.Text = "labelN5";
            this.labelN5.Visible = false;
            // 
            // labelN4
            // 
            this.labelN4.Location = new System.Drawing.Point(376, 216);
            this.labelN4.Name = "labelN4";
            this.labelN4.Size = new System.Drawing.Size(144, 16);
            this.labelN4.TabIndex = 209;
            this.labelN4.Tag = "";
            this.labelN4.Text = "labelN4";
            this.labelN4.Visible = false;
            // 
            // labelN3
            // 
            this.labelN3.Location = new System.Drawing.Point(376, 176);
            this.labelN3.Name = "labelN3";
            this.labelN3.Size = new System.Drawing.Size(144, 16);
            this.labelN3.TabIndex = 205;
            this.labelN3.Tag = "";
            this.labelN3.Text = "labelN3";
            this.labelN3.Visible = false;
            // 
            // labelN2
            // 
            this.labelN2.Location = new System.Drawing.Point(376, 136);
            this.labelN2.Name = "labelN2";
            this.labelN2.Size = new System.Drawing.Size(144, 16);
            this.labelN2.TabIndex = 204;
            this.labelN2.Tag = "";
            this.labelN2.Text = "labelN2";
            this.labelN2.Visible = false;
            // 
            // labelN1
            // 
            this.labelN1.Location = new System.Drawing.Point(376, 96);
            this.labelN1.Name = "labelN1";
            this.labelN1.Size = new System.Drawing.Size(144, 16);
            this.labelN1.TabIndex = 203;
            this.labelN1.Tag = "";
            this.labelN1.Text = "labelN1";
            this.labelN1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelignoradate);
            this.panel1.Controls.Add(this.chkIgnoraDate);
            this.panel1.Controls.Add(this.labelslash);
            this.panel1.Controls.Add(this.datalabel);
            this.panel1.Controls.Add(this.DataFine);
            this.panel1.Controls.Add(this.DataInizio);
            this.panel1.Location = new System.Drawing.Point(0, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 80);
            this.panel1.TabIndex = 3;
            // 
            // labelignoradate
            // 
            this.labelignoradate.Location = new System.Drawing.Point(32, 16);
            this.labelignoradate.Name = "labelignoradate";
            this.labelignoradate.Size = new System.Drawing.Size(312, 16);
            this.labelignoradate.TabIndex = 1002;
            this.labelignoradate.Tag = "sortingkind.nodatelabel";
            this.labelignoradate.Text = "ignora date custom";
            // 
            // chkIgnoraDate
            // 
            this.chkIgnoraDate.Location = new System.Drawing.Point(12, 16);
            this.chkIgnoraDate.Name = "chkIgnoraDate";
            this.chkIgnoraDate.Size = new System.Drawing.Size(20, 16);
            this.chkIgnoraDate.TabIndex = 1;
            this.chkIgnoraDate.Tag = "incomesorted.flagnodate:S:N";
            this.chkIgnoraDate.CheckStateChanged += new System.EventHandler(this.chkIgnoraDate_CheckStateChanged);
            // 
            // labelslash
            // 
            this.labelslash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelslash.Location = new System.Drawing.Point(172, 50);
            this.labelslash.Name = "labelslash";
            this.labelslash.Size = new System.Drawing.Size(12, 16);
            this.labelslash.TabIndex = 144;
            this.labelslash.Text = "--";
            // 
            // datalabel
            // 
            this.datalabel.Location = new System.Drawing.Point(88, 34);
            this.datalabel.Name = "datalabel";
            this.datalabel.Size = new System.Drawing.Size(176, 16);
            this.datalabel.TabIndex = 143;
            this.datalabel.Tag = "sortingkind.labelfordate";
            this.datalabel.Text = "datalabel";
            this.datalabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataFine
            // 
            this.DataFine.Location = new System.Drawing.Point(188, 50);
            this.DataFine.Name = "DataFine";
            this.DataFine.Size = new System.Drawing.Size(144, 20);
            this.DataFine.TabIndex = 3;
            this.DataFine.Tag = "incomesorted.stop";
            // 
            // DataInizio
            // 
            this.DataInizio.Location = new System.Drawing.Point(20, 50);
            this.DataInizio.Name = "DataInizio";
            this.DataInizio.Size = new System.Drawing.Size(144, 20);
            this.DataInizio.TabIndex = 2;
            this.DataInizio.Tag = "incomesorted.start";
            // 
            // lblPercentuale
            // 
            this.lblPercentuale.Location = new System.Drawing.Point(168, 88);
            this.lblPercentuale.Name = "lblPercentuale";
            this.lblPercentuale.Size = new System.Drawing.Size(100, 16);
            this.lblPercentuale.TabIndex = 199;
            this.lblPercentuale.Text = "Percentuale";
            // 
            // lblImporto
            // 
            this.lblImporto.Location = new System.Drawing.Point(8, 88);
            this.lblImporto.Name = "lblImporto";
            this.lblImporto.Size = new System.Drawing.Size(48, 16);
            this.lblImporto.TabIndex = 198;
            this.lblImporto.Text = "Importo";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 197;
            this.label2.Text = "Descrizione";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtCodiceClass);
            this.groupBox1.Controls.Add(this.txtDescrizioneClass);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoManage.txtCodiceClass.tree";
            this.groupBox1.Text = "Selezione voce della classificazione";
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(8, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 24);
            this.button1.TabIndex = 10;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.sorting.tree";
            this.button1.Text = "Codice:";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // txtCodiceClass
            // 
            this.txtCodiceClass.Location = new System.Drawing.Point(8, 44);
            this.txtCodiceClass.Name = "txtCodiceClass";
            this.txtCodiceClass.Size = new System.Drawing.Size(100, 20);
            this.txtCodiceClass.TabIndex = 1;
            this.txtCodiceClass.Tag = "sorting.sortcode?x";
            // 
            // txtDescrizioneClass
            // 
            this.txtDescrizioneClass.Location = new System.Drawing.Point(120, 16);
            this.txtDescrizioneClass.Multiline = true;
            this.txtDescrizioneClass.Name = "txtDescrizioneClass";
            this.txtDescrizioneClass.ReadOnly = true;
            this.txtDescrizioneClass.Size = new System.Drawing.Size(216, 48);
            this.txtDescrizioneClass.TabIndex = 156;
            this.txtDescrizioneClass.TabStop = false;
            this.txtDescrizioneClass.Tag = "sorting.description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(208, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 194;
            this.label3.Text = "#";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // valoreV5
            // 
            this.valoreV5.Location = new System.Drawing.Point(680, 272);
            this.valoreV5.Name = "valoreV5";
            this.valoreV5.Size = new System.Drawing.Size(144, 20);
            this.valoreV5.TabIndex = 236;
            this.valoreV5.Tag = "";
            this.valoreV5.Visible = false;
            // 
            // valoreV4
            // 
            this.valoreV4.Location = new System.Drawing.Point(680, 232);
            this.valoreV4.Name = "valoreV4";
            this.valoreV4.Size = new System.Drawing.Size(144, 20);
            this.valoreV4.TabIndex = 235;
            this.valoreV4.Tag = "";
            this.valoreV4.Visible = false;
            // 
            // valoreV3
            // 
            this.valoreV3.Location = new System.Drawing.Point(680, 192);
            this.valoreV3.Name = "valoreV3";
            this.valoreV3.Size = new System.Drawing.Size(144, 20);
            this.valoreV3.TabIndex = 232;
            this.valoreV3.Tag = "";
            this.valoreV3.Visible = false;
            // 
            // valoreV2
            // 
            this.valoreV2.Location = new System.Drawing.Point(680, 152);
            this.valoreV2.Name = "valoreV2";
            this.valoreV2.Size = new System.Drawing.Size(144, 20);
            this.valoreV2.TabIndex = 231;
            this.valoreV2.Tag = "";
            this.valoreV2.Visible = false;
            // 
            // valoreV1
            // 
            this.valoreV1.Location = new System.Drawing.Point(680, 112);
            this.valoreV1.Name = "valoreV1";
            this.valoreV1.Size = new System.Drawing.Size(144, 20);
            this.valoreV1.TabIndex = 230;
            this.valoreV1.Tag = "";
            this.valoreV1.Visible = false;
            // 
            // labelV5
            // 
            this.labelV5.Location = new System.Drawing.Point(680, 256);
            this.labelV5.Name = "labelV5";
            this.labelV5.Size = new System.Drawing.Size(144, 16);
            this.labelV5.TabIndex = 234;
            this.labelV5.Tag = "";
            this.labelV5.Text = "labelN5";
            this.labelV5.Visible = false;
            // 
            // labelV4
            // 
            this.labelV4.Location = new System.Drawing.Point(680, 216);
            this.labelV4.Name = "labelV4";
            this.labelV4.Size = new System.Drawing.Size(144, 16);
            this.labelV4.TabIndex = 233;
            this.labelV4.Tag = "";
            this.labelV4.Text = "labelN4";
            this.labelV4.Visible = false;
            // 
            // labelV3
            // 
            this.labelV3.Location = new System.Drawing.Point(680, 176);
            this.labelV3.Name = "labelV3";
            this.labelV3.Size = new System.Drawing.Size(144, 16);
            this.labelV3.TabIndex = 229;
            this.labelV3.Tag = "";
            this.labelV3.Text = "labelN3";
            this.labelV3.Visible = false;
            // 
            // labelV2
            // 
            this.labelV2.Location = new System.Drawing.Point(680, 136);
            this.labelV2.Name = "labelV2";
            this.labelV2.Size = new System.Drawing.Size(144, 16);
            this.labelV2.TabIndex = 228;
            this.labelV2.Tag = "";
            this.labelV2.Text = "labelN2";
            this.labelV2.Visible = false;
            // 
            // labelV1
            // 
            this.labelV1.Location = new System.Drawing.Point(680, 96);
            this.labelV1.Name = "labelV1";
            this.labelV1.Size = new System.Drawing.Size(144, 16);
            this.labelV1.TabIndex = 227;
            this.labelV1.Tag = "";
            this.labelV1.Text = "labelN1";
            this.labelV1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPercentuale);
            this.groupBox2.Controls.Add(this.lblPercentuale);
            this.groupBox2.Controls.Add(this.lblImporto);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtImporto);
            this.groupBox2.Controls.Add(this.txtDescrizione);
            this.groupBox2.Controls.Add(this.txtSubmovimento);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(8, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 128);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dati contabile";
            // 
            // Frm_incomesorted_default
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(826, 357);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.valoreV5);
            this.Controls.Add(this.valoreV4);
            this.Controls.Add(this.valoreV3);
            this.Controls.Add(this.valoreV2);
            this.Controls.Add(this.valoreV1);
            this.Controls.Add(this.valoreS5);
            this.Controls.Add(this.valoreN5);
            this.Controls.Add(this.valoreS4);
            this.Controls.Add(this.valoreN4);
            this.Controls.Add(this.valoreN2);
            this.Controls.Add(this.valoreS3);
            this.Controls.Add(this.valoreS2);
            this.Controls.Add(this.valoreN1);
            this.Controls.Add(this.valoreN3);
            this.Controls.Add(this.valoreS1);
            this.Controls.Add(this.labelV5);
            this.Controls.Add(this.labelV4);
            this.Controls.Add(this.labelV3);
            this.Controls.Add(this.labelV2);
            this.Controls.Add(this.labelV1);
            this.Controls.Add(this.chkIncompleto);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelS5);
            this.Controls.Add(this.labelS4);
            this.Controls.Add(this.labelS3);
            this.Controls.Add(this.labelS2);
            this.Controls.Add(this.labelS1);
            this.Controls.Add(this.labelN5);
            this.Controls.Add(this.labelN4);
            this.Controls.Add(this.labelN3);
            this.Controls.Add(this.labelN2);
            this.Controls.Add(this.labelN1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_incomesorted_default";
            this.Text = "FrmImpClassEntrata";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        
        CQueryHelper QHC;
        QueryHelper QHS;

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			DS.sorting.ExtendedProperties[MetaData.ExtraParams] = Meta.ExtraParameter;
			HelpForm.SetDenyNull(DS.incomesorted.Columns["tobecontinued"],true);
		}

		TextBox GetTxtByName(string Name){
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			TextBox T =  (TextBox) Ctrl.GetValue(this);                        
			return T;
		}
		Label GetLabByName(string Name){
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			Label L =  (Label) Ctrl.GetValue(this);                        
			return L;
		}

		bool IsChiocciola(string suffix){
			if (DS.sortingtranslation.Rows.Count==0) return false;
			string field="default"+suffix.ToLower();
			DataRow CurrTrad = DS.sortingtranslation.Rows[0];
			if (CurrTrad[field].ToString().Trim()=="@") return true;
			return false;
		}

		bool MustAsk(string suffix){
			if (DS.sortingtranslation.Rows.Count==0) return true;
			DataRow CurrTrad = DS.sortingtranslation.Rows[0];
			string field="default"+suffix.ToLower();
			if (CurrTrad[field].ToString().Trim()=="?") return true;
			return false;
		}

		/// <summary>
		/// Restituisce un textbox ed imposta in automatico le variabili primo,secondo e terzolivello
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		TextBox GetTextBoxNum(int i){
			int col = (i-1)/5;
			int row = ((i-1) % 5)+1;
			string suffix="";
			switch (col){
				case 0:suffix="N";
					primolivello=true;
					break;
				case 1:suffix="S";
					secondolivello=true;
					break;
				case 2:suffix="V";
					terzolivello=true;
					break;
			}
			suffix+=row.ToString();
			TextBox T = GetTxtByName("valore"+suffix);
			return T;

		}

		/// <summary>
		/// Restituisce un textbox ed imposta in automatico le variabili fromcorto,
		///			primo,secondo e terzolivello
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		Label GetLabelNum(int i){
			int col = (i-1)/5;
			int row = ((i-1) % 5)+1;
			if (row>3) formcorto=false;
			string suffix="";
			switch (col){
				case 0:suffix="N";
					break;
				case 1:suffix="S";
					break;
				case 2:suffix="V";
					break;
			}
			suffix+=row.ToString();
			Label L = GetLabByName("label"+suffix);
			return L;

		}

		public void MetaData_AfterFill(){
			AnalizzaCheckIgnoraDate();
            if (Meta.FirstFillForThisRow) txtCodiceClass.Focus();
		}

		public void MetaData_AfterActivation(){
			if (DS.incomesorted.Rows.Count==0) return;

			DataRow CurrRow = DS.incomesorted.Rows[0];
			importomovimento= CfgFn.GetNoNullDecimal(CurrRow["amount"]);
			importoresiduo= CfgFn.GetNoNullDecimal(DS.incomesorted.ExtendedProperties["importoresiduo"]);
			importototale= CfgFn.GetNoNullDecimal(DS.incomesorted.ExtendedProperties["importototale"]);
			importooriginale= importomovimento;
			int NControls=0;

			bool read_only=false;
			if (CurrRow["paridsor"] != DBNull.Value){
				read_only=true;
			}
			//bool read_only=false;
			
			txtImporto.ReadOnly=false; //read_only;
			txtPercentuale.ReadOnly=false; //read_only;

            object filterObj = DS.incomesorted.ExtendedProperties["CustomParentRelation"];
            string filter = "";
            if (filterObj != null) {
                filter = filterObj.ToString();
                filter = filter.Replace("!", "");
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.sortingkind, null, filter, null, true);
            }

			if (DS.sortingkind.Rows.Count==0) return;
			DataRow Rtipo = DS.sortingkind.Rows[0];
			if (Rtipo["totalexpression"].ToString()==""){
				importoresiduo=importototale-importooriginale;
			}

			if (Rtipo["flagdate"].ToString().ToLower()!="s"){
				chkIgnoraDate.Visible = false;
				labelignoradate.Visible=false;
				datalabel.Visible = false;
				labelslash.Visible=false;
				DataInizio.Visible = false;
				DataFine.Visible= false;                
				formcorto=true;
			}
			else {
				HelpForm.SetDenyNull(DS.incomesorted.Columns["flagnodate"],true);
				formcorto=false;
			}
			HasBeenActivated=true;

			foreach(string kind in new string[]{"n","s","v"}){
				for (int i=1; i<=5; i++){
					string suffix= kind+i.ToString();
					if (Rtipo["label"+suffix].ToString()=="")continue;
					NControls++;
					TextBox T = GetTextBoxNum(NControls);
					T.Visible=true;
					Label L= GetLabelNum(NControls);
					L.Visible=true;
					T.Tag="incomesorted.value"+kind+i.ToString();
					Meta.myHelpForm.AddEvents(T);

					if (kind=="v") T.Tag=T.Tag.ToString()+".N";
					L.Tag="sortingkind.label"+kind+i.ToString();

					switch (Rtipo["locked"+suffix].ToString().ToLower()) 
					{
						case "s": 
						{
							T.Visible = false;
							break;
						}
						case "n": 
						{
							T.Visible = true;
							T.ReadOnly = read_only && !MustAsk(suffix);
							break;
						}
						default: 
						{
							T.Visible = true;
							T.ReadOnly = !MustAsk(suffix);
							break;
						}
					}

					if (Rtipo["forced"+suffix].ToString().ToLower()=="s")
					{
						if (CurrRow["value"+suffix]==DBNull.Value) 
						{
							if (kind=="n")CurrRow["value"+suffix]=0;
							if (kind=="v")CurrRow["value"+suffix]=0;
							if (kind=="s")CurrRow["value"+suffix]="";
						}
						T.Visible = true;
						T.ReadOnly = false;
						HelpForm.SetDenyNull(DS.Tables["incomesorted"].Columns["value"+suffix],true);
					}
				}
			}


			decimal percentuale = 100;
			if (importototale!=0) percentuale= importomovimento/importototale*100;
			decimal rounded = Math.Round(percentuale, 4);
			txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");

            GetData.SetStaticFilter(DS.sorting, filter);

			if (terzolivello){
				Width=928;
			}
			else {
				if (secondolivello){
					Width=712;
				}
				else {
					if (primolivello)
						Width=544;
					else
						Width=464;			
				}
			}
			if (formcorto) Height=288;
			CenterToScreen();			
		}

		void UpdateCampiChiocciola(){
			foreach (string kind in new string[]{"N","S","V"}){
				for (int i=1;i<=5;i++){
					string suffix=kind+i.ToString();
					if (IsChiocciola(suffix)){
						TextBox T = GetTxtByName("valore"+suffix);
						T.Text= importomovimento.ToString("c");
					}
				}
			}
		}

		private void txtPercentuale_Leave(object sender, System.EventArgs e) {
			// ripristina l'importo originale
			if (!txtPercentuale.Modified) return;
			if(!checkpercentuale()) {
				decimal percentuale = 100;
				if (importototale!=0) percentuale= importomovimento/importototale*100;
				decimal rounded = Math.Round(percentuale, 4);                
				// calcola la percentuale in base all'importo
				txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");                
			}
			else {
				// calcola l'importo in base alla percentuale
				decimal perc = Decimal.Parse(txtPercentuale.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				importomovimento = perc* importototale /100;
				txtImporto.Text = importomovimento.ToString("c");                
			}
			UpdateCampiChiocciola();
		}
		private bool checkpercentuale() {           
			bool OK = false;
			if (txtPercentuale.Text == "") return false;           
			decimal percentmax = 0;
			if (importototale!=0) percentmax= (importoresiduo + importooriginale)/importototale*100; 
			string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
				"tra 0 e " + percentmax.ToString("n") + ". Proseguo comunque?";
			try {
				decimal percent = Decimal.Parse(txtPercentuale.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				if ((percent < 0) || (percent > percentmax)) {
					OK = (MetaFactory.factory.getSingleton<IMessageShower>().Show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
				else {
					OK=true;
				}
  
			}
			catch {                
				MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario digitare un numero" ,"Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}            
			return OK;
		}

		private void txtImporto_Leave(object sender, System.EventArgs e) {        
			if (!txtImporto.Modified) return;              
			if(!checkimporto()) {
				// ripristina l'importo originale
				txtImporto.Text = importomovimento.ToString("c");
			}
			else {
				importomovimento= CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));

				decimal percentuale = 100;
				if (importototale!=0) percentuale= importomovimento/importototale*100;

				decimal rounded = Math.Round(percentuale, 4);                
				// calcola la percentuale in base all'importo
				txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");            
			}
			UpdateCampiChiocciola();
		}   

		private bool checkimporto() {
			bool OK = false;

			if (txtImporto.Text == "") return false;
			string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
				"tra 0 e " + (importoresiduo + importooriginale).ToString("c") + ". Proseguo comunque?";
			try {
				decimal importo = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
				if ((importo >= 0) && (importo <= (importoresiduo + importooriginale))) {
					OK = true;
				}
				else{
					OK = (MetaFactory.factory.getSingleton<IMessageShower>().Show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
  
			}
			catch {                
				MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario inserire un numero","Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return OK;
		}

		void AnalizzaCheckIgnoraDate(){
			if (chkIgnoraDate.Visible==false) return;
			if (chkIgnoraDate.CheckState== CheckState.Indeterminate) chkIgnoraDate.CheckState= CheckState.Unchecked;
			bool MostraDataInizioFine = !(chkIgnoraDate.CheckState== CheckState.Checked);			
			datalabel.Visible=MostraDataInizioFine;
			DataInizio.Visible=MostraDataInizioFine;
			DataFine.Visible=MostraDataInizioFine;
			labelslash.Visible= MostraDataInizioFine;			
		}
		private void chkIgnoraDate_CheckStateChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (!HasBeenActivated) return;
			AnalizzaCheckIgnoraDate();
		}

	
	
	}
}
