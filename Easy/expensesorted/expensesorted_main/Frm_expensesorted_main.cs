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

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using gestioneclassificazioni;
//using movimentofunctions;//movimentofunctions

namespace expensesorted_main//impclassspesa_main//
{
	/// <summary>
	/// Summary description for frmimpclassspesa_main.
	/// </summary>
	public class Frm_expensesorted_main : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox chkIncompleto;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelignoradate;
		private System.Windows.Forms.CheckBox chkIgnoraDate;
		private System.Windows.Forms.Label labelslash;
		private System.Windows.Forms.Label datalabel;
		public System.Windows.Forms.TextBox DataFine;
		public System.Windows.Forms.TextBox DataInizio;
		private System.Windows.Forms.TextBox txtSubMov;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox grpClassificazione;
		private System.Windows.Forms.TextBox txtDescrClass;
		private System.Windows.Forms.TextBox txtCodiceClass;
		private System.Windows.Forms.Button btnClassificazione;
		private System.Windows.Forms.GroupBox grpMovimento;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnMovimento;
		public /*Rana:impclassspesa_main.*/vistaForm DS;
		MetaData Meta;
		public string param;
		bool InChiusura=false;


		bool HasBeenActivated;
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
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		bool primolivello=false;
		bool secondolivello=false;
		bool terzolivello=false;
		bool formcorto=false;

		decimal importototale;
		private System.Windows.Forms.TextBox txtPercentuale;
		private System.Windows.Forms.Label lblPercentuale;
		private System.Windows.Forms.Label labelPerc;
		decimal importoresiduo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		string lastidspesa="";
		//decimal importooriginale;
		//decimal importomovimento;

			
		public Frm_expensesorted_main()
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
			InChiusura=true;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Frm_expensesorted_main));
			this.chkIncompleto = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelignoradate = new System.Windows.Forms.Label();
			this.chkIgnoraDate = new System.Windows.Forms.CheckBox();
			this.labelslash = new System.Windows.Forms.Label();
			this.datalabel = new System.Windows.Forms.Label();
			this.DataFine = new System.Windows.Forms.TextBox();
			this.DataInizio = new System.Windows.Forms.TextBox();
			this.txtSubMov = new System.Windows.Forms.TextBox();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.grpClassificazione = new System.Windows.Forms.GroupBox();
			this.txtDescrClass = new System.Windows.Forms.TextBox();
			this.txtCodiceClass = new System.Windows.Forms.TextBox();
			this.btnClassificazione = new System.Windows.Forms.Button();
			this.grpMovimento = new System.Windows.Forms.GroupBox();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnMovimento = new System.Windows.Forms.Button();
			this.DS = new expensesorted_main.vistaForm();
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
			this.labelPerc = new System.Windows.Forms.Label();
			this.txtPercentuale = new System.Windows.Forms.TextBox();
			this.lblPercentuale = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.grpClassificazione.SuspendLayout();
			this.grpMovimento.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkIncompleto
			// 
			this.chkIncompleto.Location = new System.Drawing.Point(16, 376);
			this.chkIncompleto.Name = "chkIncompleto";
			this.chkIncompleto.Size = new System.Drawing.Size(152, 24);
			this.chkIncompleto.TabIndex = 274;
			this.chkIncompleto.Tag = "expensesorted.tobecontinued:S:N";
			this.chkIncompleto.Text = "Da completare in seguito";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.labelignoradate);
			this.panel1.Controls.Add(this.chkIgnoraDate);
			this.panel1.Controls.Add(this.labelslash);
			this.panel1.Controls.Add(this.datalabel);
			this.panel1.Controls.Add(this.DataFine);
			this.panel1.Controls.Add(this.DataInizio);
			this.panel1.Location = new System.Drawing.Point(8, 320);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(360, 56);
			this.panel1.TabIndex = 273;
			// 
			// labelignoradate
			// 
			this.labelignoradate.Location = new System.Drawing.Point(24, 0);
			this.labelignoradate.Name = "labelignoradate";
			this.labelignoradate.Size = new System.Drawing.Size(280, 16);
			this.labelignoradate.TabIndex = 146;
			this.labelignoradate.Tag = "";
			this.labelignoradate.Text = "ignora date custom";
			// 
			// chkIgnoraDate
			// 
			this.chkIgnoraDate.Location = new System.Drawing.Point(8, 0);
			this.chkIgnoraDate.Name = "chkIgnoraDate";
			this.chkIgnoraDate.Size = new System.Drawing.Size(20, 16);
			this.chkIgnoraDate.TabIndex = 145;
			this.chkIgnoraDate.Tag = "expensesorted.flagnodate:S:N";
			this.chkIgnoraDate.CheckStateChanged += new System.EventHandler(this.chkIgnoraDate_CheckStateChanged);
			// 
			// labelslash
			// 
			this.labelslash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelslash.Location = new System.Drawing.Point(152, 32);
			this.labelslash.Name = "labelslash";
			this.labelslash.Size = new System.Drawing.Size(12, 16);
			this.labelslash.TabIndex = 144;
			this.labelslash.Text = "--";
			// 
			// datalabel
			// 
			this.datalabel.Location = new System.Drawing.Point(16, 16);
			this.datalabel.Name = "datalabel";
			this.datalabel.Size = new System.Drawing.Size(280, 16);
			this.datalabel.TabIndex = 143;
			this.datalabel.Tag = "";
			this.datalabel.Text = "datalabel";
			this.datalabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// DataFine
			// 
			this.DataFine.Location = new System.Drawing.Point(168, 32);
			this.DataFine.Name = "DataFine";
			this.DataFine.Size = new System.Drawing.Size(128, 20);
			this.DataFine.TabIndex = 142;
			this.DataFine.Tag = "expensesorted.stop";
			this.DataFine.Text = "";
			// 
			// DataInizio
			// 
			this.DataInizio.Location = new System.Drawing.Point(16, 32);
			this.DataInizio.Name = "DataInizio";
			this.DataInizio.Size = new System.Drawing.Size(128, 20);
			this.DataInizio.TabIndex = 141;
			this.DataInizio.Tag = "expensesorted.start";
			this.DataInizio.Text = "";
			// 
			// txtSubMov
			// 
			this.txtSubMov.Location = new System.Drawing.Point(264, 16);
			this.txtSubMov.Name = "txtSubMov";
			this.txtSubMov.Size = new System.Drawing.Size(80, 20);
			this.txtSubMov.TabIndex = 1;
			this.txtSubMov.TabStop = false;
			this.txtSubMov.Tag = "expensesorted.idsubclass?expensesortedview.idsubclass";
			this.txtSubMov.Text = "";
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(8, 128);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(104, 20);
			this.txtImporto.TabIndex = 3;
			this.txtImporto.Tag = "expensesorted.amount?expensesortedview.amount";
			this.txtImporto.Text = "";
			this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(8, 48);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(336, 53);
			this.txtDescrizione.TabIndex = 2;
			this.txtDescrizione.Tag = "expensesorted.description?expensesortedview.description";
			this.txtDescrizione.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(240, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(16, 24);
			this.label5.TabIndex = 252;
			this.label5.Text = "#";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 250;
			this.label4.Text = "Importo:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpClassificazione
			// 
			this.grpClassificazione.Controls.Add(this.txtDescrClass);
			this.grpClassificazione.Controls.Add(this.txtCodiceClass);
			this.grpClassificazione.Controls.Add(this.btnClassificazione);
			this.grpClassificazione.Location = new System.Drawing.Point(8, 64);
			this.grpClassificazione.Name = "grpClassificazione";
			this.grpClassificazione.Size = new System.Drawing.Size(360, 80);
			this.grpClassificazione.TabIndex = 2;
			this.grpClassificazione.TabStop = false;
			this.grpClassificazione.Tag = "AutoManage.txtCodiceClass.tree";
			this.grpClassificazione.Text = "Classificazione (è necessario scegliere prima il movimento)";
			// 
			// txtDescrClass
			// 
			this.txtDescrClass.Location = new System.Drawing.Point(144, 16);
			this.txtDescrClass.Multiline = true;
			this.txtDescrClass.Name = "txtDescrClass";
			this.txtDescrClass.ReadOnly = true;
			this.txtDescrClass.Size = new System.Drawing.Size(200, 53);
			this.txtDescrClass.TabIndex = 5;
			this.txtDescrClass.TabStop = false;
			this.txtDescrClass.Tag = "sorting.description";
			this.txtDescrClass.Text = "";
			// 
			// txtCodiceClass
			// 
			this.txtCodiceClass.Location = new System.Drawing.Point(16, 48);
			this.txtCodiceClass.Name = "txtCodiceClass";
			this.txtCodiceClass.Size = new System.Drawing.Size(104, 20);
			this.txtCodiceClass.TabIndex = 4;
			this.txtCodiceClass.Tag = "sorting.sortcode?expensesortedview.sortcode";
			this.txtCodiceClass.Text = "";
			// 
			// btnClassificazione
			// 
			this.btnClassificazione.Image = ((System.Drawing.Image)(resources.GetObject("btnClassificazione.Image")));
			this.btnClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClassificazione.Location = new System.Drawing.Point(16, 16);
			this.btnClassificazione.Name = "btnClassificazione";
			this.btnClassificazione.Size = new System.Drawing.Size(104, 23);
			this.btnClassificazione.TabIndex = 0;
			this.btnClassificazione.TabStop = false;
			this.btnClassificazione.Tag = "manage.sorting.tree";
			this.btnClassificazione.Text = "Classificazione:";
			this.btnClassificazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpMovimento
			// 
			this.grpMovimento.Controls.Add(this.txtNumero);
			this.grpMovimento.Controls.Add(this.label2);
			this.grpMovimento.Controls.Add(this.txtEsercizio);
			this.grpMovimento.Controls.Add(this.label1);
			this.grpMovimento.Controls.Add(this.btnMovimento);
			this.grpMovimento.Location = new System.Drawing.Point(8, 8);
			this.grpMovimento.Name = "grpMovimento";
			this.grpMovimento.Size = new System.Drawing.Size(360, 56);
			this.grpMovimento.TabIndex = 1;
			this.grpMovimento.TabStop = false;
			this.grpMovimento.Tag = "AutoChoose.txtNumero.movimentiaperti";
			this.grpMovimento.Text = "Movimento di Spesa";
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(288, 24);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(64, 20);
			this.txtNumero.TabIndex = 3;
			this.txtNumero.Tag = "expenseview.nmov?expensesortedview.nmov";
			this.txtNumero.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(240, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Numero:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(176, 24);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
			this.txtEsercizio.TabIndex = 2;
			this.txtEsercizio.Tag = "expenseview.ymov.year?expensesortedview.ymov.year";
			this.txtEsercizio.Text = "";
			this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercSpesa_Leave);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(120, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnMovimento
			// 
			this.btnMovimento.Location = new System.Drawing.Point(8, 20);
			this.btnMovimento.Name = "btnMovimento";
			this.btnMovimento.Size = new System.Drawing.Size(112, 24);
			this.btnMovimento.TabIndex = 1;
			this.btnMovimento.TabStop = false;
			this.btnMovimento.Tag = "";
			this.btnMovimento.Text = "Fase movimento";
			this.btnMovimento.Click += new System.EventHandler(this.btnMovimento_Click);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// valoreV5
			// 
			this.valoreV5.Location = new System.Drawing.Point(632, 248);
			this.valoreV5.Name = "valoreV5";
			this.valoreV5.Size = new System.Drawing.Size(120, 20);
			this.valoreV5.TabIndex = 304;
			this.valoreV5.Tag = "";
			this.valoreV5.Text = "";
			this.valoreV5.Visible = false;
			// 
			// valoreV4
			// 
			this.valoreV4.Location = new System.Drawing.Point(632, 208);
			this.valoreV4.Name = "valoreV4";
			this.valoreV4.Size = new System.Drawing.Size(120, 20);
			this.valoreV4.TabIndex = 303;
			this.valoreV4.Tag = "";
			this.valoreV4.Text = "";
			this.valoreV4.Visible = false;
			// 
			// valoreV3
			// 
			this.valoreV3.Location = new System.Drawing.Point(632, 168);
			this.valoreV3.Name = "valoreV3";
			this.valoreV3.Size = new System.Drawing.Size(120, 20);
			this.valoreV3.TabIndex = 300;
			this.valoreV3.Tag = "";
			this.valoreV3.Text = "";
			this.valoreV3.Visible = false;
			// 
			// valoreV2
			// 
			this.valoreV2.Location = new System.Drawing.Point(632, 128);
			this.valoreV2.Name = "valoreV2";
			this.valoreV2.Size = new System.Drawing.Size(120, 20);
			this.valoreV2.TabIndex = 299;
			this.valoreV2.Tag = "";
			this.valoreV2.Text = "";
			this.valoreV2.Visible = false;
			// 
			// valoreV1
			// 
			this.valoreV1.Location = new System.Drawing.Point(632, 88);
			this.valoreV1.Name = "valoreV1";
			this.valoreV1.Size = new System.Drawing.Size(120, 20);
			this.valoreV1.TabIndex = 298;
			this.valoreV1.Tag = "";
			this.valoreV1.Text = "";
			this.valoreV1.Visible = false;
			// 
			// labelV5
			// 
			this.labelV5.Location = new System.Drawing.Point(632, 232);
			this.labelV5.Name = "labelV5";
			this.labelV5.Size = new System.Drawing.Size(120, 16);
			this.labelV5.TabIndex = 302;
			this.labelV5.Tag = "";
			this.labelV5.Text = "labelN5";
			this.labelV5.Visible = false;
			// 
			// labelV4
			// 
			this.labelV4.Location = new System.Drawing.Point(632, 192);
			this.labelV4.Name = "labelV4";
			this.labelV4.Size = new System.Drawing.Size(120, 16);
			this.labelV4.TabIndex = 301;
			this.labelV4.Tag = "";
			this.labelV4.Text = "labelN4";
			this.labelV4.Visible = false;
			// 
			// labelV3
			// 
			this.labelV3.Location = new System.Drawing.Point(632, 152);
			this.labelV3.Name = "labelV3";
			this.labelV3.Size = new System.Drawing.Size(120, 16);
			this.labelV3.TabIndex = 297;
			this.labelV3.Tag = "";
			this.labelV3.Text = "labelN3";
			this.labelV3.Visible = false;
			// 
			// labelV2
			// 
			this.labelV2.Location = new System.Drawing.Point(632, 112);
			this.labelV2.Name = "labelV2";
			this.labelV2.Size = new System.Drawing.Size(120, 16);
			this.labelV2.TabIndex = 296;
			this.labelV2.Tag = "";
			this.labelV2.Text = "labelN2";
			this.labelV2.Visible = false;
			// 
			// labelV1
			// 
			this.labelV1.Location = new System.Drawing.Point(632, 72);
			this.labelV1.Name = "labelV1";
			this.labelV1.Size = new System.Drawing.Size(120, 16);
			this.labelV1.TabIndex = 295;
			this.labelV1.Tag = "";
			this.labelV1.Text = "labelN1";
			this.labelV1.Visible = false;
			// 
			// valoreS5
			// 
			this.valoreS5.Location = new System.Drawing.Point(504, 248);
			this.valoreS5.Name = "valoreS5";
			this.valoreS5.Size = new System.Drawing.Size(120, 20);
			this.valoreS5.TabIndex = 294;
			this.valoreS5.Tag = "";
			this.valoreS5.Text = "";
			this.valoreS5.Visible = false;
			// 
			// valoreN5
			// 
			this.valoreN5.Location = new System.Drawing.Point(376, 248);
			this.valoreN5.Name = "valoreN5";
			this.valoreN5.Size = new System.Drawing.Size(120, 20);
			this.valoreN5.TabIndex = 293;
			this.valoreN5.Tag = "";
			this.valoreN5.Text = "";
			this.valoreN5.Visible = false;
			// 
			// valoreS4
			// 
			this.valoreS4.Location = new System.Drawing.Point(504, 208);
			this.valoreS4.Name = "valoreS4";
			this.valoreS4.Size = new System.Drawing.Size(120, 20);
			this.valoreS4.TabIndex = 292;
			this.valoreS4.Tag = "";
			this.valoreS4.Text = "";
			this.valoreS4.Visible = false;
			// 
			// valoreN4
			// 
			this.valoreN4.Location = new System.Drawing.Point(376, 208);
			this.valoreN4.Name = "valoreN4";
			this.valoreN4.Size = new System.Drawing.Size(120, 20);
			this.valoreN4.TabIndex = 291;
			this.valoreN4.Tag = "";
			this.valoreN4.Text = "";
			this.valoreN4.Visible = false;
			// 
			// valoreN2
			// 
			this.valoreN2.Location = new System.Drawing.Point(376, 128);
			this.valoreN2.Name = "valoreN2";
			this.valoreN2.Size = new System.Drawing.Size(120, 20);
			this.valoreN2.TabIndex = 279;
			this.valoreN2.Tag = "";
			this.valoreN2.Text = "";
			this.valoreN2.Visible = false;
			// 
			// valoreS3
			// 
			this.valoreS3.Location = new System.Drawing.Point(504, 168);
			this.valoreS3.Name = "valoreS3";
			this.valoreS3.Size = new System.Drawing.Size(120, 20);
			this.valoreS3.TabIndex = 288;
			this.valoreS3.Tag = "";
			this.valoreS3.Text = "";
			this.valoreS3.Visible = false;
			// 
			// valoreS2
			// 
			this.valoreS2.Location = new System.Drawing.Point(504, 128);
			this.valoreS2.Name = "valoreS2";
			this.valoreS2.Size = new System.Drawing.Size(120, 20);
			this.valoreS2.TabIndex = 287;
			this.valoreS2.Tag = "";
			this.valoreS2.Text = "";
			this.valoreS2.Visible = false;
			// 
			// valoreN1
			// 
			this.valoreN1.Location = new System.Drawing.Point(376, 88);
			this.valoreN1.Name = "valoreN1";
			this.valoreN1.Size = new System.Drawing.Size(120, 20);
			this.valoreN1.TabIndex = 278;
			this.valoreN1.Tag = "";
			this.valoreN1.Text = "";
			this.valoreN1.Visible = false;
			// 
			// valoreN3
			// 
			this.valoreN3.Location = new System.Drawing.Point(376, 168);
			this.valoreN3.Name = "valoreN3";
			this.valoreN3.Size = new System.Drawing.Size(120, 20);
			this.valoreN3.TabIndex = 280;
			this.valoreN3.Tag = "";
			this.valoreN3.Text = "";
			this.valoreN3.Visible = false;
			// 
			// valoreS1
			// 
			this.valoreS1.Location = new System.Drawing.Point(504, 88);
			this.valoreS1.Name = "valoreS1";
			this.valoreS1.Size = new System.Drawing.Size(120, 20);
			this.valoreS1.TabIndex = 286;
			this.valoreS1.Tag = "";
			this.valoreS1.Text = "";
			this.valoreS1.Visible = false;
			// 
			// labelS5
			// 
			this.labelS5.Location = new System.Drawing.Point(504, 232);
			this.labelS5.Name = "labelS5";
			this.labelS5.Size = new System.Drawing.Size(120, 16);
			this.labelS5.TabIndex = 290;
			this.labelS5.Tag = "";
			this.labelS5.Text = "labelS5";
			this.labelS5.Visible = false;
			// 
			// labelS4
			// 
			this.labelS4.Location = new System.Drawing.Point(504, 192);
			this.labelS4.Name = "labelS4";
			this.labelS4.Size = new System.Drawing.Size(120, 16);
			this.labelS4.TabIndex = 289;
			this.labelS4.Tag = "";
			this.labelS4.Text = "labelS4";
			this.labelS4.Visible = false;
			// 
			// labelS3
			// 
			this.labelS3.Location = new System.Drawing.Point(504, 152);
			this.labelS3.Name = "labelS3";
			this.labelS3.Size = new System.Drawing.Size(120, 16);
			this.labelS3.TabIndex = 285;
			this.labelS3.Tag = "";
			this.labelS3.Text = "labelS3";
			this.labelS3.Visible = false;
			// 
			// labelS2
			// 
			this.labelS2.Location = new System.Drawing.Point(504, 112);
			this.labelS2.Name = "labelS2";
			this.labelS2.Size = new System.Drawing.Size(120, 16);
			this.labelS2.TabIndex = 284;
			this.labelS2.Tag = "";
			this.labelS2.Text = "labelS2";
			this.labelS2.Visible = false;
			// 
			// labelS1
			// 
			this.labelS1.Location = new System.Drawing.Point(504, 72);
			this.labelS1.Name = "labelS1";
			this.labelS1.Size = new System.Drawing.Size(120, 16);
			this.labelS1.TabIndex = 283;
			this.labelS1.Tag = "";
			this.labelS1.Text = "labelS1";
			this.labelS1.Visible = false;
			// 
			// labelN5
			// 
			this.labelN5.Location = new System.Drawing.Point(376, 232);
			this.labelN5.Name = "labelN5";
			this.labelN5.Size = new System.Drawing.Size(120, 16);
			this.labelN5.TabIndex = 282;
			this.labelN5.Tag = "";
			this.labelN5.Text = "labelN5";
			this.labelN5.Visible = false;
			// 
			// labelN4
			// 
			this.labelN4.Location = new System.Drawing.Point(376, 192);
			this.labelN4.Name = "labelN4";
			this.labelN4.Size = new System.Drawing.Size(120, 16);
			this.labelN4.TabIndex = 281;
			this.labelN4.Tag = "";
			this.labelN4.Text = "labelN4";
			this.labelN4.Visible = false;
			// 
			// labelN3
			// 
			this.labelN3.Location = new System.Drawing.Point(376, 152);
			this.labelN3.Name = "labelN3";
			this.labelN3.Size = new System.Drawing.Size(120, 16);
			this.labelN3.TabIndex = 277;
			this.labelN3.Tag = "";
			this.labelN3.Text = "labelN3";
			this.labelN3.Visible = false;
			// 
			// labelN2
			// 
			this.labelN2.Location = new System.Drawing.Point(376, 112);
			this.labelN2.Name = "labelN2";
			this.labelN2.Size = new System.Drawing.Size(120, 16);
			this.labelN2.TabIndex = 276;
			this.labelN2.Tag = "";
			this.labelN2.Text = "labelN2";
			this.labelN2.Visible = false;
			// 
			// labelN1
			// 
			this.labelN1.Location = new System.Drawing.Point(376, 72);
			this.labelN1.Name = "labelN1";
			this.labelN1.Size = new System.Drawing.Size(120, 16);
			this.labelN1.TabIndex = 275;
			this.labelN1.Tag = "";
			this.labelN1.Text = "labelN1";
			this.labelN1.Visible = false;
			// 
			// labelPerc
			// 
			this.labelPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelPerc.Location = new System.Drawing.Point(232, 128);
			this.labelPerc.Name = "labelPerc";
			this.labelPerc.Size = new System.Drawing.Size(16, 16);
			this.labelPerc.TabIndex = 307;
			this.labelPerc.Text = "%";
			this.labelPerc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPercentuale
			// 
			this.txtPercentuale.Location = new System.Drawing.Point(136, 128);
			this.txtPercentuale.Name = "txtPercentuale";
			this.txtPercentuale.Size = new System.Drawing.Size(88, 20);
			this.txtPercentuale.TabIndex = 4;
			this.txtPercentuale.Text = "";
			this.txtPercentuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPercentuale.Leave += new System.EventHandler(this.txtPercentuale_Leave);
			// 
			// lblPercentuale
			// 
			this.lblPercentuale.Location = new System.Drawing.Point(136, 112);
			this.lblPercentuale.Name = "lblPercentuale";
			this.lblPercentuale.Size = new System.Drawing.Size(88, 16);
			this.lblPercentuale.TabIndex = 306;
			this.lblPercentuale.Text = "Percentuale";
			this.lblPercentuale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtSubMov);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtDescrizione);
			this.groupBox1.Controls.Add(this.txtImporto);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.labelPerc);
			this.groupBox1.Controls.Add(this.txtPercentuale);
			this.groupBox1.Controls.Add(this.lblPercentuale);
			this.groupBox1.Location = new System.Drawing.Point(8, 152);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(360, 168);
			this.groupBox1.TabIndex = 308;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dati Contabili";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 24);
			this.label6.TabIndex = 248;
			this.label6.Text = "Descrizione:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Frm_expensesorted_main
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(762, 408);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.valoreV5);
			this.Controls.Add(this.valoreV4);
			this.Controls.Add(this.valoreV3);
			this.Controls.Add(this.valoreV2);
			this.Controls.Add(this.valoreV1);
			this.Controls.Add(this.labelV5);
			this.Controls.Add(this.labelV4);
			this.Controls.Add(this.labelV3);
			this.Controls.Add(this.labelV2);
			this.Controls.Add(this.labelV1);
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
			this.Controls.Add(this.chkIncompleto);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.grpClassificazione);
			this.Controls.Add(this.grpMovimento);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Frm_expensesorted_main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmimpclassspesa_main";
			this.panel1.ResumeLayout(false);
			this.grpClassificazione.ResumeLayout(false);
			this.grpMovimento.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            object idsorkind = null;
			if(Meta.edit_type!="relation" )
			{
			    if (Meta.ExtraParameter==null){
			        MessageBox.Show("Non ho trovato il tipo classificazione da considerare. Provare ad aggiornare il menu da File/Menu/Aggiorna Menu ");
			        Meta.CanSave=false;
			        return;

			    }
				param = Meta.ExtraParameter.ToString();
				DataTable DescrClass=Meta.Conn.RUN_SELECT("sortingkind","description",null,
						QHS.CmpEq("idsorkind", param), null, null, true);
				if (DescrClass.Rows.Count==0)
					Meta.Name = "Imputazione spesa a \""+param+"\"";
				else
					Meta.Name = "Imputazione spesa a \""+
						DescrClass.Rows[0]["description"].ToString()+"\"";
				
				Meta.DefaultListType="lista."+param;
                idsorkind = param;
			}

            object classname = "";
			if(Meta.edit_type=="relation") 
			{
				//Extract parameter from context filter 
				string fieldname="idsor";
				int posizione = Meta.ContextFilter.IndexOf(fieldname);
				if (posizione!=-1) {
				    int start= posizione+fieldname.Length+2;//skips fieldname='
				    int stop=Meta.ContextFilter.IndexOf("'",start);
				    if (stop > start) {
				        param=Meta.ContextFilter.Substring(start,stop-start);
				        Meta.DefaultListType="lista."+param;
				    }
				}
                idsorkind = Meta.Conn.DO_READ_VALUE("sorting",QHS.CmpEq("idsor", param), "idsorkind");

                classname = Meta.Conn.DO_READ_VALUE("sortingkind",QHS.CmpEq("idsorkind", idsorkind), "description");
				if (classname!=null){
					Meta.Name = "Imputazione spesa a \""+classname.ToString()+"\"";
				}
									
			}
			
			string filter = QHS.CmpEq("idsorkind", idsorkind);
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string f = QHS.AppAnd(filter, filterEsercizio);
            GetData.SetStaticFilter(DS.expensesorted, filterEsercizio);
			GetData.SetStaticFilter(DS.expensesortedview, f);
			GetData.SetSorting(DS.expensesortedview,"ymov desc, nmov desc");
			GetData.SetStaticFilter(DS.expenseview, filterEsercizio);

			GetData.CacheTable(DS.sortingkind, filter, null, false);
			grpClassificazione.Tag+="."+filter;
			btnClassificazione.Tag+="."+filter;
			HelpForm.SetDenyNull(DS.expensesorted.Columns["tobecontinued"],true);

            DataTable ConfClassMovimento = Meta.Conn.RUN_SELECT("sortingkindview", "*", null,
                    QHS.CmpEq("idsorkind", idsorkind), null, true);
			if (ConfClassMovimento== null || ConfClassMovimento.Rows.Count==0){
				MessageBox.Show("Non ho trovato il tipo classificazione "+ classname.ToString()+
					". Provare ad aggiornare il menu da File/Menu/Aggiorna Menu ");
				Meta.CanSave=false;
				return;

			}
			/*
			if (ConfClassMovimento.Rows[0]["flagsubmovimento"].ToString()=="N")
			{
				MetaData.SetDefault(DS.expensesorted, "submovimento", 1);
				txtSubMov.ReadOnly=true;
			}
			*/

			string fase = ConfClassMovimento.Rows[0]["expensephase"].ToString();
			string codicefase = ConfClassMovimento.Rows[0]["nphaseexpense"].ToString();
			if (codicefase==""){
				MessageBox.Show("Non è stata configurata la Fase di Spesa per  il tipo classificazione "+ (param as string)+
					". Completare la configurazione dal menu Configurazione/Classificazione/Tipo di Classificazione ");
			}
			grpMovimento.Text = fase;
			btnMovimento.Text = fase;
			string filtermovimento = QHC.CmpEq("nphase", codicefase);
			grpMovimento.Tag+="."+filtermovimento;
			btnMovimento.Tag+="."+filtermovimento;
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R)
		{
			
			if (T.TableName == "expenseview" && R!=null)
			{
				if (Meta.InsertMode) {
					grpClassificazione.Enabled=true;
					txtCodiceClass.ReadOnly=false;
				}
				if (Meta.InsertMode && (DS.sortingkind.Rows.Count>0) )
				{
					DataRow CurrTipo=DS.sortingkind.Rows[0];
					importototale=GetNoNullDecimal(R["curramount"]);
                    object codicetipoclass = CurrTipo["idsorkind"];
					decimal importoclassificato= GetNoNullDecimal( Meta.Conn.DO_READ_VALUE("expensesortedview",
                        QHS.AppAnd(QHS.CmpEq("idexp", R["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                        QHS.CmpEq("idsorkind", codicetipoclass)), "ISNULL(SUM(amount),0)"));
					if (CurrTipo["totalexpression"].ToString()==""){
						importoresiduo=importototale-importoclassificato;
						txtImporto.Text=GetNoNullDecimal(importoresiduo).ToString("C");		
						ImpostaPercentuale(importoresiduo);
					}
					else  {
						importoresiduo=importototale;
						decimal importo = GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
							txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
						ImpostaPercentuale(importo);
					}

					GestioneClassificazioni.CalcAvailableIDClassesFor(DS.sorting, Meta,codicetipoclass,R,"expense");
					if (R["idexp"].ToString()!=lastidspesa){
						lastidspesa=R["idexp"].ToString();
						DS.expensesorted.Rows[0]["idsor"]=0;
						txtCodiceClass.Text="";
						txtDescrClass.Text="";
						DS.sorting.Clear();
					}
				
					//DS.impclassspesa.Rows[0]["importo"]=R["importocorrente"];
					//Meta.FreshForm();
				}
			}
			if ((Meta.EditMode ||Meta.InsertMode) &&(T.TableName == "expenseview") && (R==null)){
				DS.expensesorted.Rows[0]["idsor"]=0;
				lastidspesa="";
				txtCodiceClass.Text="";
				txtDescrClass.Text="";
				DS.sorting.Clear();
				grpClassificazione.Enabled=false;
				txtCodiceClass.ReadOnly=true;
			}

		}

		public void MetaData_AfterFill()
		{
			txtPercentuale.Visible=true;
			labelPerc.Visible=true;
			lblPercentuale.Visible=true;

			AnalizzaCheckIgnoraDate();
			if (Meta.FirstFillForThisRow &&(DS.sortingkind.Rows.Count>0)){
				DataRow R= DS.expensesorted.Rows[0];
				if (R!=null){
					lastidspesa=R["idexp"].ToString();
					DataRow CurrTipo=DS.sortingkind.Rows[0];
                    object codicetipoclass = CurrTipo["idsorkind"];
					DataTable TCurrSpesa= Meta.Conn.RUN_SELECT("expenseview","*",null,
                        QHS.AppAnd(QHS.CmpEq("idexp",R["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),null,true);
					DataRow CurrSpesa=null;
					if ((TCurrSpesa!=null) && (TCurrSpesa.Rows.Count>0))
						CurrSpesa=TCurrSpesa.Rows[0];
					if (CurrSpesa!=null){
                        if (Meta.InsertMode) {
                            grpClassificazione.Enabled = true;
                            txtCodiceClass.ReadOnly = false;
                        }
                        else {
                            grpClassificazione.Enabled = false;
                            txtCodiceClass.ReadOnly = true;
                        }
						importototale=GetNoNullDecimal( CurrSpesa["curramount"]);
						decimal importoclassificato= GetNoNullDecimal( Meta.Conn.DO_READ_VALUE("expensesortedview",
                            QHS.AppAnd(QHS.CmpEq("idexp", R["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                        QHS.CmpEq("idsorkind", codicetipoclass)), "ISNULL(SUM(amount),0)"));
						if (CurrTipo["totalexpression"].ToString()==""){
							importoresiduo=importototale-importoclassificato;
						}
						else 
							importoresiduo=importototale;

						decimal percentuale = 100;
						decimal importomovimento= GetNoNullDecimal(R["amount"]);
						if (importototale!=0) percentuale= importomovimento/importototale*100;
						decimal rounded = Math.Round(percentuale, 4);
						txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");  
						//rounded.ToString("n");

						GestioneClassificazioni.CalcAvailableIDClassesFor(DS.sorting,
							Meta,codicetipoclass,CurrSpesa,"expense");
						
					}
					else {
						txtPercentuale.Text="";
                        grpClassificazione.Enabled = false;
                        txtCodiceClass.ReadOnly = true;
                    }
				}
			}
           
		}

		public void MetaData_AfterClear()
		{
			//txtEsercizio.Text=Meta.GetSys("esercizio").ToString();
			txtPercentuale.Visible=false;
			labelPerc.Visible=false;
			lblPercentuale.Visible=false;
			txtPercentuale.Text="";
			grpClassificazione.Enabled=true;
			txtCodiceClass.ReadOnly=false;
		}

		TextBox GetTxtByName(string Name)
		{
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

		Label GetLblByname(string Name)
		{
			foreach (Control L in this.Controls)
				if (L.GetType().ToString()=="System.Windows.Forms.Label" && L.Name==Name) return (Label)L;
			return null;
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



		public void MetaData_AfterActivation() {
			if (DS.sortingkind.Rows.Count==0) return;
			DataRow Rtipo = DS.sortingkind.Rows[0];
			//txtPercentuale.Leave+=new EventHandler();
			int NControls=0;
			bool read_only=false;

			if (Rtipo["flagdate"].ToString().ToLower()!="s") {
				chkIgnoraDate.Visible = false;
				labelignoradate.Visible=false;
				datalabel.Visible = false;
				labelslash.Visible=false;
				DataInizio.Visible = false;
				DataFine.Visible= false;     
				chkIncompleto.Visible=false;
				formcorto=true;
			}
			else {
				HelpForm.SetDenyNull(DS.expensesorted.Columns["flagnodate"],true);
				formcorto=false;
			}
			labelignoradate.Text= Rtipo["nodatelabel"].ToString();
			datalabel.Text= Rtipo["labelfordate"].ToString();
			HasBeenActivated=true;

			foreach(string kind in new string[]{"n","s","v"}){ 
				for (int i=1; i<=5; i++) {
					string suffix= kind+i.ToString();
					if (Rtipo["label"+suffix].ToString()=="")continue;
					NControls++;
					TextBox T = GetTextBoxNum(NControls);
					T.Visible=true;
					Label L= GetLabelNum(NControls);
					L.Visible=true;
					T.Tag="expensesorted.value"+kind+i.ToString();
					Meta.myHelpForm.AddEvents(T);

					if (kind=="v") T.Tag=T.Tag.ToString()+".N";
					L.Text=Rtipo["label"+kind+i.ToString()].ToString();
					//L.Tag="tipoclassmovimenti.etichetta"+kind+i.ToString();

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
                        if (DS.expensesorted.Columns["value" + suffix].DefaultValue == DBNull.Value) 
						{
							if (kind=="n") MetaData.SetDefault(DS.expensesorted, "value"+suffix, 0);
							if (kind=="v") MetaData.SetDefault(DS.expensesorted, "value"+suffix, 0);
							if (kind=="s") MetaData.SetDefault(DS.expensesorted, "value"+suffix, "");
						}
						T.Visible = true;
						T.ReadOnly = false;
						HelpForm.SetDenyNull(DS.Tables["expensesorted"].Columns["value"+suffix],true);
					}
				}
			}
		

		
			if (terzolivello){
				Width=864;
			}
			else {
				if (secondolivello) {
					Width=704;
				}
				else {
					if (primolivello)
						Width=536;
					else
						Width=376;			
				}
			}
			if (formcorto) Height=440;

			// Rusciano G. 20.07.2005
			// La riga che chiama il metodo CenterToScreen è stata ricommentata in quanto il posizionamento
			// al centro dello schermo non funziona nel caso in cui la finestra di MetaData non è impostata
			// a tutto schermo
			AutoScrollMinSize = new System.Drawing.Size(Size.Width-8,Size.Height-30);//-8,-30
			FormBorderStyle= FormBorderStyle.FixedDialog;
			AutoScroll=false;
			FrmCenter();

//			CenterToScreen();
		}

		bool MustAsk(string suffix){
			if (DS.sortingtranslation.Rows.Count==0) return true;
			DataRow CurrTrad = DS.sortingtranslation.Rows[0];
			string field="default"+suffix;
			if (CurrTrad[field].ToString().Trim()=="?") return true;
			return false;
		}


		void FrmCenter()
		{
			Form Par = MdiParent;
			int posx = (Par.Size.Width- Size.Width - 8)/2;
			int posy = (Par.Size.Height- Size.Height - 130)/2;
			if (posy<0) posy=0;
			if (posx<0) posx=0;
			StartPosition= FormStartPosition.Manual;
			Location = new System.Drawing.Point(posx,posy);
		}

		void AnalizzaCheckIgnoraDate()
		{
			if (chkIgnoraDate.Visible==false) return;
			if (chkIgnoraDate.CheckState== CheckState.Indeterminate) chkIgnoraDate.CheckState= CheckState.Unchecked;
			bool MostraDataInizioFine = !(chkIgnoraDate.CheckState== CheckState.Checked);			
			datalabel.Visible=MostraDataInizioFine;
			DataInizio.Visible=MostraDataInizioFine;
			DataFine.Visible=MostraDataInizioFine;
			labelslash.Visible= MostraDataInizioFine;			
		}

		private void chkIgnoraDate_CheckStateChanged(object sender, System.EventArgs e)
		{
			if (!Meta.DrawStateIsDone) return;
			if (!HasBeenActivated) return;
			AnalizzaCheckIgnoraDate();
		}

		void ImpostaPercentuale(decimal importomovimento){
			decimal percentuale = 100;
			if (importototale!=0) percentuale= importomovimento/importototale*100;
			decimal rounded = Math.Round(percentuale, 4);                
			// calcola la percentuale in base all'importo
			txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");  
		}
		private void txtImporto_Leave(object sender, System.EventArgs e) {
			if (!txtImporto.Modified) return;              
			if (Meta.IsEmpty)return;
//			importomovimento= Decimal.Parse(txtImporto.Text,
//				NumberStyles.Currency,
//				NumberFormatInfo.CurrentInfo);

			decimal importo=0;
			if(!checkimporto()) {
				// ripristina l'importo originale
				decimal importomovimento;
				if (Meta.EditMode)
					importomovimento= GetNoNullDecimal( DS.expensesorted.Rows[0]["amount",DataRowVersion.Original]);
				else 
					importomovimento= GetNoNullDecimal( DS.expensesorted.Rows[0]["amount",DataRowVersion.Default]);

				if(Meta.EditMode){
					txtImporto.Text = importomovimento.ToString("c");
					importo=importomovimento;
				}
			}
			else {
				decimal importomovimento= GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
				ImpostaPercentuale(importomovimento);
			}


			UpdateCampiChiocciola(importo);

		}
		void UpdateCampiChiocciola(decimal importo){
			foreach (string kind in new string[]{"N","S","V"}){
				for (int i=1;i<=5;i++){
					string suffix=kind+i.ToString();
					if (IsChiocciola(suffix)){
						TextBox T = GetTxtByName("valore"+suffix);
						T.Text= importo.ToString("c");
					}
				}
			}
		}

		bool IsChiocciola(string suffix){
			if (DS.sortingtranslation.Rows.Count==0) return false;
			string field="default"+suffix.ToLower();
			DataRow CurrTrad = DS.sortingtranslation.Rows[0];
			if (CurrTrad[field].ToString().Trim()=="@") return true;
			return false;
		}

		private void txtEsercSpesa_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (Meta.EditMode) return;

			string esercspesa=txtEsercizio.Text.Trim();
			if (esercspesa=="") {
				MetaData.Choose(this, "choose.expenseview.unknown.clear");
				return;
			}
			
			//if txtEsercEntrata is not Empty:
			if (Meta.IsEmpty) return;
				
			if(DS.expenseview.Rows.Count>0 ) {
				if (esercspesa== DS.expenseview.Rows[0]["ymov"].ToString())
					return;
				else {
					ClearSpesa(false);
					return;
				}	
			}		
		}
		private void ClearSpesa(bool ClearEsercizio) {
			//causa errore dopo un getformdata
			//			txtNumVariazione.Text="";
			txtNumero.Text="";
			if (ClearEsercizio) txtEsercizio.Text="";
			if (Meta.IsEmpty) return;
			if (!Meta.InsertMode) return; //idpsesa can be changed only on insert!
			DS.expensesorted.Rows[0]["idexp"]=0;
		}


		private void txtPercentuale_Leave(object sender, System.EventArgs e) {
			// ripristina l'importo originale
			if (!txtPercentuale.Modified) return;

			if(!checkpercentuale()) {
				decimal percentuale = 100;
				decimal importomovimento=0;
				try {
					importomovimento= GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
								txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));

				}
				catch{}
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
				decimal importo = perc* importototale /100;
				txtImporto.Text = importo.ToString("c");                
				UpdateCampiChiocciola(importo);
				txtPercentuale.Text = HelpForm.StringValue(perc,"x.y.fixed.4...1");  
			}
		}

		private bool checkpercentuale() {           
			bool OK = false;
			if (txtPercentuale.Text == "") return false;           
			decimal percentmax=0;
			decimal importooriginale=0;
			if (Meta.EditMode) importooriginale=GetNoNullDecimal(DS.expensesorted.Rows[0]["amount",DataRowVersion.Original]);
			if (importototale!=0) percentmax = (importoresiduo + importooriginale)/importototale*100; 
			string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
				"tra 0 e " + percentmax.ToString("n") + ". Proseguo comunque?";
			try {
				decimal percent = Decimal.Parse(txtPercentuale.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				if ((percent < 0) || (percent > percentmax)) {
					OK = (MessageBox.Show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
				else {
					OK=true;
				}
  
			}
			catch {                
				MessageBox.Show("E' necessario digitare un numero" ,"Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}            
			return OK;
		}

		private bool checkimporto() {
			bool OK = false;
			decimal importooriginale=0;
			if (Meta.EditMode) importooriginale= GetNoNullDecimal( DS.expensesorted.Rows[0]["amount",
												DataRowVersion.Original]);

			if (txtImporto.Text == "") return false;
			string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
				"tra 0 e " + (importoresiduo + importooriginale).ToString("c") + ". Proseguo comunque?";
			try {
				decimal importo = GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
					
				if ((importo >= 0) && (importo <= (importoresiduo + importooriginale))) {
					OK = true;
				}
				else{
					OK = (MessageBox.Show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
  
			}
			catch {                
				MessageBox.Show("E' necessario inserire un numero","Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return OK;
		}
		public static decimal GetNoNullDecimal(object O){
			if (O==null) return 0;
			if (O == DBNull.Value) return 0;
			try {
				return Convert.ToDecimal(O);
			}
			catch {
				return 0;
			}
		}
		public static int GetNoNullInt32(object O){
			if (O==null) return 0;
			if (O == DBNull.Value) return 0;
			try {
				return Convert.ToInt32(O);
			}
			catch {
				return 0;
			}
		}

		private void btnMovimento_Click(object sender, System.EventArgs e) {
			
			string MyFilter; 
			int esercizio= (int) Meta.GetSys("esercizio");
			int esercText= CfgFn.GetNoNullInt32(txtEsercizio.Text);
			//if (esercText==0) esercText=esercizio;
			MyFilter= QHS.CmpEq("ayear", esercizio.ToString());
			if (esercText !=0)	MyFilter = GetData.MergeFilters(MyFilter,
				QHS.CmpEq("ymov", esercText));
            Meta.DoMainCommand("choose.expenseview.movimentiaperti." + MyFilter);
            //MetaData Exp= MetaData.GetMetaData(this,"expenseview");
            //Exp.FilterLocked=true;
            //Exp.DS= new DataSet();
            //DataRow M= Exp.SelectOne("movimentiaperti",MyFilter,null,null);
            //if (M==null) return;
            //txtEsercizio.Text= M["ymov"].ToString();
            //txtNumero.Text=M["nmov"].ToString();
            //MetaData_AfterRowSelect(M.Table, M);
		
		}
	}
}
