/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using itinerationFunctions;//FunzioniMissione
using AskCurrencyExchange;
using CurrencyManager;
using System.IO;

namespace itinerationrefund_lista
{
	/// <summary>
	/// Summary description for FrmMissioneSpesa.
	/// </summary>
	public class Frm_itinerationrefund_lista :MetaDataForm
	{
		bool inChiusura = false;
		private TextBox txtDescrizione;
		private Label label4;
		private ComboBox cmbClassificazione;
		private Button btnClassificazione;
		public vistaForm DS;
		DataRow ParentMissione;
		MetaData Meta;
		private ImageList imageList1;
		private GroupBox grpIndennita;
		private TextBox txtIndennSuppl;
		private Label label7;
		private GroupBox grpAnticipo;
		private Label label9;
		private TextBox txtPercAnticipoItaliaEstero;
		private Label label10;
		private TextBox txtAnticipo;
		private GroupBox grpLocalita;
		private RadioButton rdoUe;
		private RadioButton rdoItaly;
		private RadioButton rdoExtraUe;
		private Label label12;
		private Label label11;
		private TextBox txtDataFine;
		private TextBox txtDataInizio;
		private GroupBox grpLimite;
		private TextBox txtLimiteMax;
		private Label label2;
		private GroupBox grpApplicabilita;
		private RadioButton rdbSaldo;
		private RadioButton rdbAnticipo;
		private GroupBox grpDocCollegato;
		private Label label3;
		private TextBox txtDocumento;
		private Label label5;
		private TextBox txtDataDoc;
		public TextBox txtImportoRichiestoEUR;
		public TextBox txtImportoRichiestoValuta;
		private GroupBox grpImporti;
		public TextBox txtImportoEffettivoValuta;
		public TextBox txtImportoEffettivoEUR;
		public TextBox txtImportoDocValuta;
		public TextBox txtImportoDocEUR;
		private Label label8;
		private Label label6;
		private Label label13;
		private Label label17;
		private Label label16;
		private Label label15;
		private Label label14;
		private Label label18;
		private TextBox txtComunicazioni;
		private Button btnArea;
		private ComboBox cmbArea;
		private TextBox txtImpNonRendicontabile;
		private Label label19;
		private TabControl tabControl1;
		private TabPage tabSpesa;
		private TabPage tabAllegati;
		private GroupBox grpBoxAllegati;
		private DataGrid dataGridAllegati;
		private Button btnVisualizzaAllegato;
		private IContainer components;
		private GroupBox gBoxValuta;
		private TextBox txtValuta;
		private Button btnValuta;
		private Label label1;
		private TextBox txtCambio;
		private CheckBox chkTaxableExpense;
		private GroupBox grpMissione;
		private Label label20;
		private TextBox txtEsercizio;
		private TextBox txtNumero;
		private Label label21;
		private GroupBox grpIncaricato;
		private TextBox txtIncaricato;
		private ComboBox cmbPrestazione;
		private Button btnPrestazione;
		private GroupBox gboxStato;
		private ComboBox cmbStatus;
		private TextBox txtQualifica;
		private Label label22;
		private CheckBox chkWeb;
		private CheckBox chkUtilizzabile;
		private CheckBox chkPagabile;
		private GroupBox gboxDate;
		private Label label23;
		private TextBox txtDataContabile;
		private Label label24;
		private TextBox txtDataAut;
		private Label label25;
		private TextBox txtMainDataFine;
		private Label label26;
		private TextBox txtMainDataInizio;
		private TextBox txtMainDescription;
		private Label label27;
		private CheckBox chkTraceability;
		private Manager currencyManager;

		public Frm_itinerationrefund_lista()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			inChiusura = true;
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_itinerationrefund_lista));
			this.DS = new itinerationrefund_lista.vistaForm();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbClassificazione = new System.Windows.Forms.ComboBox();
			this.btnClassificazione = new System.Windows.Forms.Button();
			this.gBoxValuta = new System.Windows.Forms.GroupBox();
			this.txtValuta = new System.Windows.Forms.TextBox();
			this.btnValuta = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCambio = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.grpAnticipo = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPercAnticipoItaliaEstero = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtAnticipo = new System.Windows.Forms.TextBox();
			this.grpIndennita = new System.Windows.Forms.GroupBox();
			this.txtIndennSuppl = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.grpLocalita = new System.Windows.Forms.GroupBox();
			this.rdoExtraUe = new System.Windows.Forms.RadioButton();
			this.rdoUe = new System.Windows.Forms.RadioButton();
			this.rdoItaly = new System.Windows.Forms.RadioButton();
			this.grpLimite = new System.Windows.Forms.GroupBox();
			this.txtLimiteMax = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grpApplicabilita = new System.Windows.Forms.GroupBox();
			this.rdbSaldo = new System.Windows.Forms.RadioButton();
			this.rdbAnticipo = new System.Windows.Forms.RadioButton();
			this.grpDocCollegato = new System.Windows.Forms.GroupBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDataDoc = new System.Windows.Forms.TextBox();
			this.txtImportoDocEUR = new System.Windows.Forms.TextBox();
			this.txtImportoDocValuta = new System.Windows.Forms.TextBox();
			this.txtImportoRichiestoEUR = new System.Windows.Forms.TextBox();
			this.txtImportoRichiestoValuta = new System.Windows.Forms.TextBox();
			this.grpImporti = new System.Windows.Forms.GroupBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtImportoEffettivoValuta = new System.Windows.Forms.TextBox();
			this.txtImportoEffettivoEUR = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtComunicazioni = new System.Windows.Forms.TextBox();
			this.btnArea = new System.Windows.Forms.Button();
			this.cmbArea = new System.Windows.Forms.ComboBox();
			this.txtImpNonRendicontabile = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabSpesa = new System.Windows.Forms.TabPage();
			this.chkTraceability = new System.Windows.Forms.CheckBox();
			this.chkTaxableExpense = new System.Windows.Forms.CheckBox();
			this.tabAllegati = new System.Windows.Forms.TabPage();
			this.grpBoxAllegati = new System.Windows.Forms.GroupBox();
			this.dataGridAllegati = new System.Windows.Forms.DataGrid();
			this.btnVisualizzaAllegato = new System.Windows.Forms.Button();
			this.grpMissione = new System.Windows.Forms.GroupBox();
			this.txtMainDescription = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.gboxDate = new System.Windows.Forms.GroupBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.txtDataAut = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txtMainDataFine = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.txtMainDataInizio = new System.Windows.Forms.TextBox();
			this.chkPagabile = new System.Windows.Forms.CheckBox();
			this.chkWeb = new System.Windows.Forms.CheckBox();
			this.chkUtilizzabile = new System.Windows.Forms.CheckBox();
			this.txtQualifica = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.gboxStato = new System.Windows.Forms.GroupBox();
			this.cmbStatus = new System.Windows.Forms.ComboBox();
			this.cmbPrestazione = new System.Windows.Forms.ComboBox();
			this.btnPrestazione = new System.Windows.Forms.Button();
			this.grpIncaricato = new System.Windows.Forms.GroupBox();
			this.txtIncaricato = new System.Windows.Forms.TextBox();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gBoxValuta.SuspendLayout();
			this.grpAnticipo.SuspendLayout();
			this.grpIndennita.SuspendLayout();
			this.grpLocalita.SuspendLayout();
			this.grpLimite.SuspendLayout();
			this.grpApplicabilita.SuspendLayout();
			this.grpDocCollegato.SuspendLayout();
			this.grpImporti.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabSpesa.SuspendLayout();
			this.tabAllegati.SuspendLayout();
			this.grpBoxAllegati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridAllegati)).BeginInit();
			this.grpMissione.SuspendLayout();
			this.gboxDate.SuspendLayout();
			this.gboxStato.SuspendLayout();
			this.grpIncaricato.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(87, 37);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(573, 48);
			this.txtDescrizione.TabIndex = 1;
			this.txtDescrizione.Tag = "itinerationrefund.description";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 24);
			this.label4.TabIndex = 21;
			this.label4.Text = "Descrizione:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbClassificazione
			// 
			this.cmbClassificazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbClassificazione.DataSource = this.DS.itinerationrefundkind;
			this.cmbClassificazione.DisplayMember = "description";
			this.cmbClassificazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClassificazione.Location = new System.Drawing.Point(131, 8);
			this.cmbClassificazione.Name = "cmbClassificazione";
			this.cmbClassificazione.Size = new System.Drawing.Size(360, 21);
			this.cmbClassificazione.TabIndex = 1;
			this.cmbClassificazione.Tag = "itinerationrefund.iditinerationrefundkind";
			this.cmbClassificazione.ValueMember = "iditinerationrefundkind";
			// 
			// btnClassificazione
			// 
			this.btnClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClassificazione.Location = new System.Drawing.Point(11, 8);
			this.btnClassificazione.Name = "btnClassificazione";
			this.btnClassificazione.Size = new System.Drawing.Size(112, 23);
			this.btnClassificazione.TabIndex = 18;
			this.btnClassificazione.TabStop = false;
			this.btnClassificazione.Tag = "Choose.itinerationrefundkind.default";
			this.btnClassificazione.Text = "Rimborso Spese";
			// 
			// gBoxValuta
			// 
			this.gBoxValuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.gBoxValuta.Controls.Add(this.txtValuta);
			this.gBoxValuta.Controls.Add(this.btnValuta);
			this.gBoxValuta.Controls.Add(this.label1);
			this.gBoxValuta.Controls.Add(this.txtCambio);
			this.gBoxValuta.Location = new System.Drawing.Point(545, 227);
			this.gBoxValuta.Name = "gBoxValuta";
			this.gBoxValuta.Size = new System.Drawing.Size(272, 98);
			this.gBoxValuta.TabIndex = 55;
			this.gBoxValuta.TabStop = false;
			this.gBoxValuta.Tag = "AutoChoose.txtValuta.default.(active = \'S\')";
			// 
			// txtValuta
			// 
			this.txtValuta.Location = new System.Drawing.Point(85, 24);
			this.txtValuta.Name = "txtValuta";
			this.txtValuta.Size = new System.Drawing.Size(179, 20);
			this.txtValuta.TabIndex = 58;
			this.txtValuta.Tag = "currency.description?x";
			// 
			// btnValuta
			// 
			this.btnValuta.Location = new System.Drawing.Point(5, 21);
			this.btnValuta.Name = "btnValuta";
			this.btnValuta.Size = new System.Drawing.Size(72, 23);
			this.btnValuta.TabIndex = 56;
			this.btnValuta.TabStop = false;
			this.btnValuta.Tag = "choose.currency.default";
			this.btnValuta.Text = "Valuta:";
			this.btnValuta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 23);
			this.label1.TabIndex = 57;
			this.label1.Text = "Tasso di Cambio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCambio
			// 
			this.txtCambio.Location = new System.Drawing.Point(118, 63);
			this.txtCambio.Name = "txtCambio";
			this.txtCambio.ReadOnly = true;
			this.txtCambio.Size = new System.Drawing.Size(100, 20);
			this.txtCambio.TabIndex = 55;
			this.txtCambio.Tag = "itinerationrefund.exchangerate.fixed.8...1";
			this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label12.Location = new System.Drawing.Point(536, 116);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(60, 19);
			this.label12.TabIndex = 52;
			this.label12.Text = "Data Fine:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label11.Location = new System.Drawing.Point(417, 117);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(66, 19);
			this.label11.TabIndex = 51;
			this.label11.Text = "Data Inizio:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataFine
			// 
			this.txtDataFine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtDataFine.Location = new System.Drawing.Point(527, 136);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(100, 20);
			this.txtDataFine.TabIndex = 50;
			this.txtDataFine.Tag = "itinerationrefund.stoptime.g";
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtDataInizio.Location = new System.Drawing.Point(410, 136);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(100, 20);
			this.txtDataInizio.TabIndex = 49;
			this.txtDataInizio.Tag = "itinerationrefund.starttime.g";
			// 
			// grpAnticipo
			// 
			this.grpAnticipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpAnticipo.Controls.Add(this.label9);
			this.grpAnticipo.Controls.Add(this.txtPercAnticipoItaliaEstero);
			this.grpAnticipo.Controls.Add(this.label10);
			this.grpAnticipo.Controls.Add(this.txtAnticipo);
			this.grpAnticipo.Location = new System.Drawing.Point(405, 227);
			this.grpAnticipo.Name = "grpAnticipo";
			this.grpAnticipo.Size = new System.Drawing.Size(131, 98);
			this.grpAnticipo.TabIndex = 6;
			this.grpAnticipo.TabStop = false;
			this.grpAnticipo.Text = "Anticipo";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(9, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 16);
			this.label9.TabIndex = 64;
			this.label9.Text = "Importo";
			this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// txtPercAnticipoItaliaEstero
			// 
			this.txtPercAnticipoItaliaEstero.Location = new System.Drawing.Point(12, 31);
			this.txtPercAnticipoItaliaEstero.Name = "txtPercAnticipoItaliaEstero";
			this.txtPercAnticipoItaliaEstero.Size = new System.Drawing.Size(112, 20);
			this.txtPercAnticipoItaliaEstero.TabIndex = 62;
			this.txtPercAnticipoItaliaEstero.Tag = "itinerationrefund.advancepercentage.fixed.4..%.100";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(10, 12);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 16);
			this.label10.TabIndex = 63;
			this.label10.Text = "Percentuale";
			this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// txtAnticipo
			// 
			this.txtAnticipo.Location = new System.Drawing.Point(13, 71);
			this.txtAnticipo.Name = "txtAnticipo";
			this.txtAnticipo.ReadOnly = true;
			this.txtAnticipo.Size = new System.Drawing.Size(112, 20);
			this.txtAnticipo.TabIndex = 65;
			this.txtAnticipo.TabStop = false;
			this.txtAnticipo.Tag = "";
			this.txtAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpIndennita
			// 
			this.grpIndennita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpIndennita.Controls.Add(this.txtIndennSuppl);
			this.grpIndennita.Controls.Add(this.label7);
			this.grpIndennita.Location = new System.Drawing.Point(3, 119);
			this.grpIndennita.Name = "grpIndennita";
			this.grpIndennita.Size = new System.Drawing.Size(185, 45);
			this.grpIndennita.TabIndex = 65;
			this.grpIndennita.TabStop = false;
			this.grpIndennita.Text = "Indennità Supplementare";
			// 
			// txtIndennSuppl
			// 
			this.txtIndennSuppl.Location = new System.Drawing.Point(60, 18);
			this.txtIndennSuppl.Name = "txtIndennSuppl";
			this.txtIndennSuppl.ReadOnly = true;
			this.txtIndennSuppl.Size = new System.Drawing.Size(112, 20);
			this.txtIndennSuppl.TabIndex = 61;
			this.txtIndennSuppl.TabStop = false;
			this.txtIndennSuppl.Tag = "itinerationrefund.extraallowance";
			this.txtIndennSuppl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 18);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 16);
			this.label7.TabIndex = 60;
			this.label7.Text = "Importo";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpLocalita
			// 
			this.grpLocalita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.grpLocalita.Controls.Add(this.rdoExtraUe);
			this.grpLocalita.Controls.Add(this.rdoUe);
			this.grpLocalita.Controls.Add(this.rdoItaly);
			this.grpLocalita.Location = new System.Drawing.Point(665, 140);
			this.grpLocalita.Name = "grpLocalita";
			this.grpLocalita.Size = new System.Drawing.Size(153, 87);
			this.grpLocalita.TabIndex = 7;
			this.grpLocalita.TabStop = false;
			this.grpLocalita.Text = "Località";
			// 
			// rdoExtraUe
			// 
			this.rdoExtraUe.AutoSize = true;
			this.rdoExtraUe.Location = new System.Drawing.Point(6, 62);
			this.rdoExtraUe.Name = "rdoExtraUe";
			this.rdoExtraUe.Size = new System.Drawing.Size(146, 17);
			this.rdoExtraUe.TabIndex = 2;
			this.rdoExtraUe.TabStop = true;
			this.rdoExtraUe.Tag = "itinerationrefund.flag_geo:E";
			this.rdoExtraUe.Text = "Fuori dall\'Unione Europea";
			this.rdoExtraUe.UseVisualStyleBackColor = true;
			// 
			// rdoUe
			// 
			this.rdoUe.AutoSize = true;
			this.rdoUe.Location = new System.Drawing.Point(6, 39);
			this.rdoUe.Name = "rdoUe";
			this.rdoUe.Size = new System.Drawing.Size(102, 17);
			this.rdoUe.TabIndex = 1;
			this.rdoUe.TabStop = true;
			this.rdoUe.Tag = "itinerationrefund.flag_geo:U";
			this.rdoUe.Text = "Unione Europea";
			this.rdoUe.UseVisualStyleBackColor = true;
			// 
			// rdoItaly
			// 
			this.rdoItaly.AutoSize = true;
			this.rdoItaly.Location = new System.Drawing.Point(6, 19);
			this.rdoItaly.Name = "rdoItaly";
			this.rdoItaly.Size = new System.Drawing.Size(47, 17);
			this.rdoItaly.TabIndex = 0;
			this.rdoItaly.TabStop = true;
			this.rdoItaly.Tag = "itinerationrefund.flag_geo:I";
			this.rdoItaly.Text = "Italia";
			this.rdoItaly.UseVisualStyleBackColor = true;
			// 
			// grpLimite
			// 
			this.grpLimite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpLimite.Controls.Add(this.txtLimiteMax);
			this.grpLimite.Controls.Add(this.label2);
			this.grpLimite.Location = new System.Drawing.Point(203, 119);
			this.grpLimite.Name = "grpLimite";
			this.grpLimite.Size = new System.Drawing.Size(192, 45);
			this.grpLimite.TabIndex = 68;
			this.grpLimite.TabStop = false;
			this.grpLimite.Text = "Limite Massimo per Classe di Spesa";
			// 
			// txtLimiteMax
			// 
			this.txtLimiteMax.Location = new System.Drawing.Point(58, 17);
			this.txtLimiteMax.Name = "txtLimiteMax";
			this.txtLimiteMax.ReadOnly = true;
			this.txtLimiteMax.Size = new System.Drawing.Size(112, 20);
			this.txtLimiteMax.TabIndex = 61;
			this.txtLimiteMax.TabStop = false;
			this.txtLimiteMax.Tag = "";
			this.txtLimiteMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 16);
			this.label2.TabIndex = 60;
			this.label2.Text = "Importo";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpApplicabilita
			// 
			this.grpApplicabilita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.grpApplicabilita.Controls.Add(this.rdbSaldo);
			this.grpApplicabilita.Controls.Add(this.rdbAnticipo);
			this.grpApplicabilita.Location = new System.Drawing.Point(666, 84);
			this.grpApplicabilita.Name = "grpApplicabilita";
			this.grpApplicabilita.Size = new System.Drawing.Size(152, 50);
			this.grpApplicabilita.TabIndex = 69;
			this.grpApplicabilita.TabStop = false;
			this.grpApplicabilita.Text = "Applicabilità";
			// 
			// rdbSaldo
			// 
			this.rdbSaldo.AutoSize = true;
			this.rdbSaldo.Location = new System.Drawing.Point(75, 19);
			this.rdbSaldo.Name = "rdbSaldo";
			this.rdbSaldo.Size = new System.Drawing.Size(52, 17);
			this.rdbSaldo.TabIndex = 1;
			this.rdbSaldo.TabStop = true;
			this.rdbSaldo.Tag = "itinerationrefund.flagadvancebalance:S";
			this.rdbSaldo.Text = "Saldo";
			this.rdbSaldo.UseVisualStyleBackColor = true;
			// 
			// rdbAnticipo
			// 
			this.rdbAnticipo.AutoSize = true;
			this.rdbAnticipo.Location = new System.Drawing.Point(6, 19);
			this.rdbAnticipo.Name = "rdbAnticipo";
			this.rdbAnticipo.Size = new System.Drawing.Size(63, 17);
			this.rdbAnticipo.TabIndex = 0;
			this.rdbAnticipo.TabStop = true;
			this.rdbAnticipo.Tag = "itinerationrefund.flagadvancebalance:A";
			this.rdbAnticipo.Text = "Anticipo";
			this.rdbAnticipo.UseVisualStyleBackColor = true;
			// 
			// grpDocCollegato
			// 
			this.grpDocCollegato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpDocCollegato.Controls.Add(this.label17);
			this.grpDocCollegato.Controls.Add(this.label8);
			this.grpDocCollegato.Controls.Add(this.label3);
			this.grpDocCollegato.Controls.Add(this.txtDocumento);
			this.grpDocCollegato.Controls.Add(this.label6);
			this.grpDocCollegato.Controls.Add(this.label5);
			this.grpDocCollegato.Controls.Add(this.txtDataDoc);
			this.grpDocCollegato.Controls.Add(this.txtImportoDocEUR);
			this.grpDocCollegato.Controls.Add(this.txtImportoDocValuta);
			this.grpDocCollegato.Location = new System.Drawing.Point(4, 166);
			this.grpDocCollegato.Name = "grpDocCollegato";
			this.grpDocCollegato.Size = new System.Drawing.Size(638, 55);
			this.grpDocCollegato.TabIndex = 70;
			this.grpDocCollegato.TabStop = false;
			this.grpDocCollegato.Text = "Documento collegato (scontrino/fattura/altro)";
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.Location = new System.Drawing.Point(348, 25);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(43, 14);
			this.label17.TabIndex = 56;
			this.label17.Text = "Importo";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(516, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 14);
			this.label8.TabIndex = 53;
			this.label8.Text = "in €";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Documento";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDocumento
			// 
			this.txtDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDocumento.Location = new System.Drawing.Point(72, 23);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(160, 20);
			this.txtDocumento.TabIndex = 4;
			this.txtDocumento.Tag = "itinerationrefund.doc";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(398, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 14);
			this.label6.TabIndex = 52;
			this.label6.Text = "in valuta";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(237, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Data";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataDoc
			// 
			this.txtDataDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataDoc.Location = new System.Drawing.Point(270, 23);
			this.txtDataDoc.Name = "txtDataDoc";
			this.txtDataDoc.Size = new System.Drawing.Size(69, 20);
			this.txtDataDoc.TabIndex = 5;
			this.txtDataDoc.Tag = "itinerationrefund.docdate";
			// 
			// txtImportoDocEUR
			// 
			this.txtImportoDocEUR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoDocEUR.Location = new System.Drawing.Point(515, 24);
			this.txtImportoDocEUR.Name = "txtImportoDocEUR";
			this.txtImportoDocEUR.ReadOnly = true;
			this.txtImportoDocEUR.Size = new System.Drawing.Size(112, 20);
			this.txtImportoDocEUR.TabIndex = 2;
			this.txtImportoDocEUR.TabStop = false;
			this.txtImportoDocEUR.Tag = "itinerationrefund.docamount";
			this.txtImportoDocEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoDocValuta
			// 
			this.txtImportoDocValuta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoDocValuta.Location = new System.Drawing.Point(397, 24);
			this.txtImportoDocValuta.Name = "txtImportoDocValuta";
			this.txtImportoDocValuta.Size = new System.Drawing.Size(112, 20);
			this.txtImportoDocValuta.TabIndex = 2;
			this.txtImportoDocValuta.Tag = "itinerationrefund.docamount_c.fixed.8...1";
			this.txtImportoDocValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoRichiestoEUR
			// 
			this.txtImportoRichiestoEUR.Location = new System.Drawing.Point(276, 36);
			this.txtImportoRichiestoEUR.Name = "txtImportoRichiestoEUR";
			this.txtImportoRichiestoEUR.ReadOnly = true;
			this.txtImportoRichiestoEUR.Size = new System.Drawing.Size(112, 20);
			this.txtImportoRichiestoEUR.TabIndex = 2;
			this.txtImportoRichiestoEUR.TabStop = false;
			this.txtImportoRichiestoEUR.Tag = "itinerationrefund.requiredamount";
			this.txtImportoRichiestoEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoRichiestoValuta
			// 
			this.txtImportoRichiestoValuta.Location = new System.Drawing.Point(154, 36);
			this.txtImportoRichiestoValuta.Name = "txtImportoRichiestoValuta";
			this.txtImportoRichiestoValuta.Size = new System.Drawing.Size(112, 20);
			this.txtImportoRichiestoValuta.TabIndex = 1;
			this.txtImportoRichiestoValuta.Tag = "itinerationrefund.requiredamount_c.fixed.8...1";
			this.txtImportoRichiestoValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpImporti
			// 
			this.grpImporti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpImporti.Controls.Add(this.label16);
			this.grpImporti.Controls.Add(this.label15);
			this.grpImporti.Controls.Add(this.label14);
			this.grpImporti.Controls.Add(this.label13);
			this.grpImporti.Controls.Add(this.txtImportoEffettivoValuta);
			this.grpImporti.Controls.Add(this.txtImportoRichiestoEUR);
			this.grpImporti.Controls.Add(this.txtImportoEffettivoEUR);
			this.grpImporti.Controls.Add(this.txtImportoRichiestoValuta);
			this.grpImporti.Location = new System.Drawing.Point(4, 227);
			this.grpImporti.Name = "grpImporti";
			this.grpImporti.Size = new System.Drawing.Size(391, 98);
			this.grpImporti.TabIndex = 3;
			this.grpImporti.TabStop = false;
			this.grpImporti.Text = "Importo";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(2, 62);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(146, 14);
			this.label16.TabIndex = 71;
			this.label16.Text = "Accordato (obbligatorio)";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(17, 38);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(131, 14);
			this.label15.TabIndex = 55;
			this.label15.Text = "Richiesto (opzionale)";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(277, 19);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(76, 14);
			this.label14.TabIndex = 54;
			this.label14.Text = "in €";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(153, 19);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(104, 14);
			this.label13.TabIndex = 53;
			this.label13.Text = "in valuta";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImportoEffettivoValuta
			// 
			this.txtImportoEffettivoValuta.Location = new System.Drawing.Point(154, 62);
			this.txtImportoEffettivoValuta.Name = "txtImportoEffettivoValuta";
			this.txtImportoEffettivoValuta.Size = new System.Drawing.Size(112, 20);
			this.txtImportoEffettivoValuta.TabIndex = 2;
			this.txtImportoEffettivoValuta.Tag = "itinerationrefund.amount_c.fixed.8...1";
			this.txtImportoEffettivoValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoEffettivoEUR
			// 
			this.txtImportoEffettivoEUR.Location = new System.Drawing.Point(277, 63);
			this.txtImportoEffettivoEUR.Name = "txtImportoEffettivoEUR";
			this.txtImportoEffettivoEUR.ReadOnly = true;
			this.txtImportoEffettivoEUR.Size = new System.Drawing.Size(112, 20);
			this.txtImportoEffettivoEUR.TabIndex = 2;
			this.txtImportoEffettivoEUR.TabStop = false;
			this.txtImportoEffettivoEUR.Tag = "itinerationrefund.amount";
			this.txtImportoEffettivoEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label18
			// 
			this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label18.Location = new System.Drawing.Point(251, 331);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(114, 29);
			this.label18.TabIndex = 71;
			this.label18.Text = "Comunicazioni per \r\nil Responsabile";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtComunicazioni
			// 
			this.txtComunicazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtComunicazioni.Location = new System.Drawing.Point(371, 331);
			this.txtComunicazioni.Multiline = true;
			this.txtComunicazioni.Name = "txtComunicazioni";
			this.txtComunicazioni.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtComunicazioni.Size = new System.Drawing.Size(443, 46);
			this.txtComunicazioni.TabIndex = 72;
			this.txtComunicazioni.Tag = "itinerationrefund.webwarn";
			// 
			// btnArea
			// 
			this.btnArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnArea.Location = new System.Drawing.Point(11, 93);
			this.btnArea.Name = "btnArea";
			this.btnArea.Size = new System.Drawing.Size(88, 23);
			this.btnArea.TabIndex = 73;
			this.btnArea.TabStop = false;
			this.btnArea.Tag = "choose.foreigncountry.default";
			this.btnArea.Text = "Località Estera:";
			this.btnArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbArea
			// 
			this.cmbArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbArea.DataSource = this.DS.foreigncountry;
			this.cmbArea.DisplayMember = "description";
			this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbArea.Location = new System.Drawing.Point(105, 93);
			this.cmbArea.Name = "cmbArea";
			this.cmbArea.Size = new System.Drawing.Size(320, 21);
			this.cmbArea.TabIndex = 74;
			this.cmbArea.Tag = "itinerationrefund.idforeigncountry";
			this.cmbArea.ValueMember = "idforeigncountry";
			// 
			// txtImpNonRendicontabile
			// 
			this.txtImpNonRendicontabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtImpNonRendicontabile.Location = new System.Drawing.Point(52, 352);
			this.txtImpNonRendicontabile.Name = "txtImpNonRendicontabile";
			this.txtImpNonRendicontabile.Size = new System.Drawing.Size(112, 20);
			this.txtImpNonRendicontabile.TabIndex = 76;
			this.txtImpNonRendicontabile.Tag = "itinerationrefund.noaccount";
			this.txtImpNonRendicontabile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label19
			// 
			this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label19.Location = new System.Drawing.Point(38, 324);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(140, 32);
			this.label19.TabIndex = 75;
			this.label19.Text = "Importo non rendicontabile";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabSpesa);
			this.tabControl1.Controls.Add(this.tabAllegati);
			this.tabControl1.Location = new System.Drawing.Point(8, 213);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(831, 408);
			this.tabControl1.TabIndex = 77;
			// 
			// tabSpesa
			// 
			this.tabSpesa.Controls.Add(this.chkTraceability);
			this.tabSpesa.Controls.Add(this.label4);
			this.tabSpesa.Controls.Add(this.txtDescrizione);
			this.tabSpesa.Controls.Add(this.gBoxValuta);
			this.tabSpesa.Controls.Add(this.chkTaxableExpense);
			this.tabSpesa.Controls.Add(this.btnArea);
			this.tabSpesa.Controls.Add(this.label12);
			this.tabSpesa.Controls.Add(this.txtDataFine);
			this.tabSpesa.Controls.Add(this.cmbClassificazione);
			this.tabSpesa.Controls.Add(this.grpApplicabilita);
			this.tabSpesa.Controls.Add(this.btnClassificazione);
			this.tabSpesa.Controls.Add(this.label11);
			this.tabSpesa.Controls.Add(this.grpLocalita);
			this.tabSpesa.Controls.Add(this.txtDataInizio);
			this.tabSpesa.Controls.Add(this.txtImpNonRendicontabile);
			this.tabSpesa.Controls.Add(this.grpImporti);
			this.tabSpesa.Controls.Add(this.label19);
			this.tabSpesa.Controls.Add(this.grpAnticipo);
			this.tabSpesa.Controls.Add(this.label18);
			this.tabSpesa.Controls.Add(this.grpIndennita);
			this.tabSpesa.Controls.Add(this.txtComunicazioni);
			this.tabSpesa.Controls.Add(this.grpLimite);
			this.tabSpesa.Controls.Add(this.cmbArea);
			this.tabSpesa.Controls.Add(this.grpDocCollegato);
			this.tabSpesa.Location = new System.Drawing.Point(4, 22);
			this.tabSpesa.Name = "tabSpesa";
			this.tabSpesa.Padding = new System.Windows.Forms.Padding(3);
			this.tabSpesa.Size = new System.Drawing.Size(823, 382);
			this.tabSpesa.TabIndex = 0;
			this.tabSpesa.Text = "Spesa";
			this.tabSpesa.UseVisualStyleBackColor = true;
			// 
			// chkTraceability
			// 
			this.chkTraceability.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkTraceability.Location = new System.Drawing.Point(672, 41);
			this.chkTraceability.Name = "chkTraceability";
			this.chkTraceability.Size = new System.Drawing.Size(126, 17);
			this.chkTraceability.TabIndex = 79;
			this.chkTraceability.Tag = "itinerationrefundkind.flagtraceability:0?itinerationrefundview.flagtraceability:0" +
    "";
			this.chkTraceability.Text = "Richiesta tracciabilità";
			// 
			// chkTaxableExpense
			// 
			this.chkTaxableExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkTaxableExpense.AutoSize = true;
			this.chkTaxableExpense.Location = new System.Drawing.Point(521, 11);
			this.chkTaxableExpense.Name = "chkTaxableExpense";
			this.chkTaxableExpense.Size = new System.Drawing.Size(261, 17);
			this.chkTaxableExpense.TabIndex = 78;
			this.chkTaxableExpense.Tag = "itinerationrefund.flagtaxableexpense:0";
			this.chkTaxableExpense.Text = "Assenza pagamento tracciabile (Spesa imponibile)";
			this.chkTaxableExpense.UseVisualStyleBackColor = true;
			// 
			// tabAllegati
			// 
			this.tabAllegati.Controls.Add(this.grpBoxAllegati);
			this.tabAllegati.Location = new System.Drawing.Point(4, 22);
			this.tabAllegati.Name = "tabAllegati";
			this.tabAllegati.Padding = new System.Windows.Forms.Padding(3);
			this.tabAllegati.Size = new System.Drawing.Size(823, 382);
			this.tabAllegati.TabIndex = 1;
			this.tabAllegati.Text = "Allegati";
			this.tabAllegati.UseVisualStyleBackColor = true;
			// 
			// grpBoxAllegati
			// 
			this.grpBoxAllegati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpBoxAllegati.Controls.Add(this.dataGridAllegati);
			this.grpBoxAllegati.Controls.Add(this.btnVisualizzaAllegato);
			this.grpBoxAllegati.Location = new System.Drawing.Point(7, 6);
			this.grpBoxAllegati.Name = "grpBoxAllegati";
			this.grpBoxAllegati.Size = new System.Drawing.Size(810, 371);
			this.grpBoxAllegati.TabIndex = 5;
			this.grpBoxAllegati.TabStop = false;
			this.grpBoxAllegati.Text = "Dettagli";
			// 
			// dataGridAllegati
			// 
			this.dataGridAllegati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridAllegati.DataMember = "";
			this.dataGridAllegati.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridAllegati.Location = new System.Drawing.Point(80, 29);
			this.dataGridAllegati.Name = "dataGridAllegati";
			this.dataGridAllegati.Size = new System.Drawing.Size(724, 336);
			this.dataGridAllegati.TabIndex = 20;
			this.dataGridAllegati.Tag = "itinerationrefundattachment.single";
			// 
			// btnVisualizzaAllegato
			// 
			this.btnVisualizzaAllegato.Location = new System.Drawing.Point(5, 31);
			this.btnVisualizzaAllegato.Name = "btnVisualizzaAllegato";
			this.btnVisualizzaAllegato.Size = new System.Drawing.Size(69, 22);
			this.btnVisualizzaAllegato.TabIndex = 18;
			this.btnVisualizzaAllegato.Tag = "";
			this.btnVisualizzaAllegato.Text = "Visualizza";
			this.btnVisualizzaAllegato.Click += new System.EventHandler(this.btnVisualizzaAllegato_Click);
			// 
			// grpMissione
			// 
			this.grpMissione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpMissione.Controls.Add(this.txtMainDescription);
			this.grpMissione.Controls.Add(this.label27);
			this.grpMissione.Controls.Add(this.gboxDate);
			this.grpMissione.Controls.Add(this.chkPagabile);
			this.grpMissione.Controls.Add(this.chkWeb);
			this.grpMissione.Controls.Add(this.chkUtilizzabile);
			this.grpMissione.Controls.Add(this.txtQualifica);
			this.grpMissione.Controls.Add(this.label22);
			this.grpMissione.Controls.Add(this.gboxStato);
			this.grpMissione.Controls.Add(this.cmbPrestazione);
			this.grpMissione.Controls.Add(this.btnPrestazione);
			this.grpMissione.Controls.Add(this.grpIncaricato);
			this.grpMissione.Controls.Add(this.txtNumero);
			this.grpMissione.Controls.Add(this.label21);
			this.grpMissione.Controls.Add(this.txtEsercizio);
			this.grpMissione.Controls.Add(this.label20);
			this.grpMissione.Location = new System.Drawing.Point(8, 3);
			this.grpMissione.Name = "grpMissione";
			this.grpMissione.Size = new System.Drawing.Size(827, 204);
			this.grpMissione.TabIndex = 79;
			this.grpMissione.TabStop = false;
			this.grpMissione.Text = "Missione";
			// 
			// txtMainDescription
			// 
			this.txtMainDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMainDescription.Location = new System.Drawing.Point(8, 62);
			this.txtMainDescription.Multiline = true;
			this.txtMainDescription.Name = "txtMainDescription";
			this.txtMainDescription.Size = new System.Drawing.Size(442, 60);
			this.txtMainDescription.TabIndex = 109;
			this.txtMainDescription.Tag = "itineration.description?itinerationrefundview.maindescription";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(11, 40);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(68, 20);
			this.label27.TabIndex = 110;
			this.label27.Text = "Descrizione:";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gboxDate
			// 
			this.gboxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDate.Controls.Add(this.label23);
			this.gboxDate.Controls.Add(this.txtDataContabile);
			this.gboxDate.Controls.Add(this.label24);
			this.gboxDate.Controls.Add(this.txtDataAut);
			this.gboxDate.Controls.Add(this.label25);
			this.gboxDate.Controls.Add(this.txtMainDataFine);
			this.gboxDate.Controls.Add(this.label26);
			this.gboxDate.Controls.Add(this.txtMainDataInizio);
			this.gboxDate.Location = new System.Drawing.Point(456, 92);
			this.gboxDate.Name = "gboxDate";
			this.gboxDate.Size = new System.Drawing.Size(362, 70);
			this.gboxDate.TabIndex = 108;
			this.gboxDate.TabStop = false;
			this.gboxDate.Text = "Date della Missione";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(177, 40);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(86, 16);
			this.label23.TabIndex = 19;
			this.label23.Text = "Data contabile:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(263, 40);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
			this.txtDataContabile.TabIndex = 4;
			this.txtDataContabile.Tag = "itineration.adate?itinerationrefundview.adate";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(9, 40);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(78, 16);
			this.label24.TabIndex = 17;
			this.label24.Text = "Data autorizz.:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataAut
			// 
			this.txtDataAut.Location = new System.Drawing.Point(87, 40);
			this.txtDataAut.Name = "txtDataAut";
			this.txtDataAut.Size = new System.Drawing.Size(80, 20);
			this.txtDataAut.TabIndex = 3;
			this.txtDataAut.Tag = "itineration.authorizationdate?itinerationrefundview.authorizationdate";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(205, 16);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(58, 16);
			this.label25.TabIndex = 15;
			this.label25.Text = "Data fine:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtMainDataFine
			// 
			this.txtMainDataFine.Location = new System.Drawing.Point(263, 16);
			this.txtMainDataFine.Name = "txtMainDataFine";
			this.txtMainDataFine.Size = new System.Drawing.Size(80, 20);
			this.txtMainDataFine.TabIndex = 2;
			this.txtMainDataFine.Tag = "itineration.stop?itinerationrefundview.stop";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(15, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(72, 16);
			this.label26.TabIndex = 13;
			this.label26.Text = "Data inizio:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtMainDataInizio
			// 
			this.txtMainDataInizio.Location = new System.Drawing.Point(87, 16);
			this.txtMainDataInizio.Name = "txtMainDataInizio";
			this.txtMainDataInizio.Size = new System.Drawing.Size(80, 20);
			this.txtMainDataInizio.TabIndex = 1;
			this.txtMainDataInizio.Tag = "itineration.start?itinerationrefundview.start";
			// 
			// chkPagabile
			// 
			this.chkPagabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkPagabile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkPagabile.Location = new System.Drawing.Point(632, 71);
			this.chkPagabile.Name = "chkPagabile";
			this.chkPagabile.Size = new System.Drawing.Size(190, 24);
			this.chkPagabile.TabIndex = 107;
			this.chkPagabile.Tag = "itineration.completed:S:N?itinerationrefundview.completed:S:N";
			this.chkPagabile.Text = "Considera eseguito quindi pagabile";
			// 
			// chkWeb
			// 
			this.chkWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkWeb.Location = new System.Drawing.Point(632, 18);
			this.chkWeb.Name = "chkWeb";
			this.chkWeb.Size = new System.Drawing.Size(160, 30);
			this.chkWeb.TabIndex = 106;
			this.chkWeb.TabStop = false;
			this.chkWeb.Tag = "itineration.flagweb:S:N?itinerationrefundview.flagweb:S:N";
			this.chkWeb.Text = "Missione inserita mediante interfaccia web";
			// 
			// chkUtilizzabile
			// 
			this.chkUtilizzabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkUtilizzabile.Location = new System.Drawing.Point(632, 48);
			this.chkUtilizzabile.Name = "chkUtilizzabile";
			this.chkUtilizzabile.Size = new System.Drawing.Size(80, 24);
			this.chkUtilizzabile.TabIndex = 105;
			this.chkUtilizzabile.TabStop = false;
			this.chkUtilizzabile.Tag = "itineration.active:S:N?itinerationrefundview.active:S:N";
			this.chkUtilizzabile.Text = "Utilizzabile";
			// 
			// txtQualifica
			// 
			this.txtQualifica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtQualifica.Location = new System.Drawing.Point(84, 176);
			this.txtQualifica.Name = "txtQualifica";
			this.txtQualifica.Size = new System.Drawing.Size(286, 20);
			this.txtQualifica.TabIndex = 26;
			this.txtQualifica.TabStop = false;
			this.txtQualifica.Tag = "position.description?itinerationrefundview.positiondescription";
			// 
			// label22
			// 
			this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label22.Location = new System.Drawing.Point(18, 173);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(57, 23);
			this.label22.TabIndex = 25;
			this.label22.Text = "Qualifica:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxStato
			// 
			this.gboxStato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxStato.Controls.Add(this.cmbStatus);
			this.gboxStato.Location = new System.Drawing.Point(359, 9);
			this.gboxStato.Name = "gboxStato";
			this.gboxStato.Size = new System.Drawing.Size(263, 42);
			this.gboxStato.TabIndex = 14;
			this.gboxStato.TabStop = false;
			this.gboxStato.Text = "Stato";
			// 
			// cmbStatus
			// 
			this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatus.DataSource = this.DS.itinerationstatus;
			this.cmbStatus.DisplayMember = "description";
			this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatus.Location = new System.Drawing.Point(14, 15);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new System.Drawing.Size(244, 21);
			this.cmbStatus.TabIndex = 43;
			this.cmbStatus.Tag = "itineration.iditinerationstatus?itinerationrefundview.iditinerationstatus";
			this.cmbStatus.ValueMember = "iditinerationstatus";
			// 
			// cmbPrestazione
			// 
			this.cmbPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPrestazione.DataSource = this.DS.service;
			this.cmbPrestazione.DisplayMember = "description";
			this.cmbPrestazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPrestazione.Location = new System.Drawing.Point(533, 174);
			this.cmbPrestazione.Name = "cmbPrestazione";
			this.cmbPrestazione.Size = new System.Drawing.Size(288, 21);
			this.cmbPrestazione.TabIndex = 12;
			this.cmbPrestazione.Tag = "itineration.idser?itinerationrefundview.idser";
			this.cmbPrestazione.ValueMember = "idser";
			// 
			// btnPrestazione
			// 
			this.btnPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrestazione.Location = new System.Drawing.Point(433, 173);
			this.btnPrestazione.Name = "btnPrestazione";
			this.btnPrestazione.Size = new System.Drawing.Size(92, 24);
			this.btnPrestazione.TabIndex = 13;
			this.btnPrestazione.TabStop = false;
			this.btnPrestazione.Tag = "choose.service.default";
			this.btnPrestazione.Text = "Prestazione:";
			this.btnPrestazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpIncaricato
			// 
			this.grpIncaricato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpIncaricato.Controls.Add(this.txtIncaricato);
			this.grpIncaricato.Location = new System.Drawing.Point(8, 125);
			this.grpIncaricato.Name = "grpIncaricato";
			this.grpIncaricato.Size = new System.Drawing.Size(408, 42);
			this.grpIncaricato.TabIndex = 6;
			this.grpIncaricato.TabStop = false;
			this.grpIncaricato.Tag = "AutoChoose.txtIncaricato.default.((human=\'S\') and (active = \'S\') AND (idreg IN(SE" +
    "LECT idreg FROM registrylegalstatus WHERE idposition IS NOT NULL and (active = \'" +
    "S\')  ))";
			this.grpIncaricato.Text = "Percipiente";
			// 
			// txtIncaricato
			// 
			this.txtIncaricato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIncaricato.Location = new System.Drawing.Point(8, 16);
			this.txtIncaricato.Name = "txtIncaricato";
			this.txtIncaricato.Size = new System.Drawing.Size(392, 20);
			this.txtIncaricato.TabIndex = 0;
			this.txtIncaricato.Tag = "registry.title?itinerationrefundview.registrytitle";
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(239, 18);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(100, 20);
			this.txtNumero.TabIndex = 3;
			this.txtNumero.Tag = "itineration.nitineration?itinerationrefundview.nitineration";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(192, 20);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(44, 13);
			this.label21.TabIndex = 2;
			this.label21.Text = "Numero";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(68, 18);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(100, 20);
			this.txtEsercizio.TabIndex = 1;
			this.txtEsercizio.Tag = "itineration.yitineration.year?itinerationrefundview.yitineration.year";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(11, 20);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(55, 16);
			this.label20.TabIndex = 0;
			this.label20.Text = "Esercizio";
			// 
			// Frm_itinerationrefund_lista
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(838, 623);
			this.Controls.Add(this.grpMissione);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Frm_itinerationrefund_lista";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmMissioneSpesa";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gBoxValuta.ResumeLayout(false);
			this.gBoxValuta.PerformLayout();
			this.grpAnticipo.ResumeLayout(false);
			this.grpAnticipo.PerformLayout();
			this.grpIndennita.ResumeLayout(false);
			this.grpIndennita.PerformLayout();
			this.grpLocalita.ResumeLayout(false);
			this.grpLocalita.PerformLayout();
			this.grpLimite.ResumeLayout(false);
			this.grpLimite.PerformLayout();
			this.grpApplicabilita.ResumeLayout(false);
			this.grpApplicabilita.PerformLayout();
			this.grpDocCollegato.ResumeLayout(false);
			this.grpDocCollegato.PerformLayout();
			this.grpImporti.ResumeLayout(false);
			this.grpImporti.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabSpesa.ResumeLayout(false);
			this.tabSpesa.PerformLayout();
			this.tabAllegati.ResumeLayout(false);
			this.grpBoxAllegati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridAllegati)).EndInit();
			this.grpMissione.ResumeLayout(false);
			this.grpMissione.PerformLayout();
			this.gboxDate.ResumeLayout(false);
			this.gboxDate.PerformLayout();
			this.gboxStato.ResumeLayout(false);
			this.grpIncaricato.ResumeLayout(false);
			this.grpIncaricato.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		DataAccess Conn;
		CfgItineration Cfg;
		CQueryHelper QHC;
		QueryHelper QHS;
		private IFormController controller;

		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
			QHC = new CQueryHelper();
			QHS = Meta.Conn.GetQueryHelper();
			controller = this.getInstance<IFormController>();

			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.CanCancel = false;
			Meta.CanSave = false;

			HelpForm.SetFormatForColumn(DS.itinerationrefund.Columns["stoptime"], "g");
			HelpForm.SetFormatForColumn(DS.itinerationrefund.Columns["starttime"], "g");
		}
		
		void enableControls(bool abilita)
		{
			cmbClassificazione.Enabled = abilita;
			grpLocalita.Enabled = abilita;
			grpApplicabilita.Enabled = abilita;
			btnClassificazione.Enabled = abilita;
			chkTaxableExpense.Enabled = abilita;
			btnArea.Enabled = abilita;
			cmbArea.Enabled = abilita;
			cmbStatus.Enabled = abilita;
			chkWeb.Enabled = abilita;
			chkUtilizzabile.Enabled = abilita;
			chkPagabile.Enabled = abilita;
			cmbPrestazione.Enabled = abilita;
			btnValuta.Enabled = abilita;
			btnPrestazione.Enabled = abilita;
			chkTraceability.Enabled = abilita;

			btnVisualizzaAllegato.Enabled = (DS.itinerationrefundattachment.Rows.Count > 0);

			txtImportoEffettivoValuta.ReadOnly = !abilita;
			txtComunicazioni.Enabled = abilita;
			txtImpNonRendicontabile.ReadOnly = !abilita;
			txtImportoRichiestoValuta.ReadOnly = !abilita;
			txtDescrizione.ReadOnly = !abilita;
			txtDataInizio.ReadOnly = !abilita;
			txtDataFine.ReadOnly = !abilita;
			txtEsercizio.ReadOnly = !abilita;
			txtNumero.ReadOnly = !abilita;
			txtMainDescription.ReadOnly = !abilita;
			txtIncaricato.ReadOnly = !abilita;
			txtQualifica.ReadOnly = !abilita;
			txtMainDataInizio.ReadOnly = !abilita;
			txtMainDataFine.ReadOnly = !abilita;
			txtDataAut.ReadOnly = !abilita;
			txtDataContabile.ReadOnly = !abilita;
			txtDocumento.ReadOnly = !abilita;
			txtDataDoc.ReadOnly = !abilita;
			txtImportoDocValuta.ReadOnly = !abilita;
			txtImportoRichiestoValuta.ReadOnly = !abilita;
			txtImportoEffettivoValuta.ReadOnly = !abilita;
			txtPercAnticipoItaliaEstero.ReadOnly = !abilita;
			txtValuta.ReadOnly = !abilita;
		}

		public void MetaData_AfterFill()
		{
			if ((!controller.IsEmpty) && (controller.firstFillForThisRow))
			{
				grpIncaricato.Tag = "AutoChoose.txtIncaricato.default.((active = 'S') AND (human='S') AND " +
									" (idreg IN (SELECT idreg FROM registrylegalstatus WHERE idposition IS NOT NULL and (active = \'S\') ))  " +
									" )";
				controller.SetAutoMode(grpIncaricato);
			}

			enableControls(false);
		}

		public void MetaData_AfterClear()
		{
			enableControls(true);
			txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
			grpIncaricato.Tag = "AutoChoose.txtIncaricato.default.((active = 'S') AND (human='S') " +
								"AND (idreg IN(SELECT idreg FROM registrylegalstatus WHERE idposition IS NOT NULL and (active = \'S\') )) ) ";
			controller.SetAutoMode(grpIncaricato);
			chkTraceability.CheckState = CheckState.Indeterminate;
		}

		private void btnVisualizzaAllegato_Click(object sender, EventArgs e)
		{
			string FilePath = Path.GetTempPath();
			string prefix = "SWATTACHMENT";
			string filenametodelete = FilePath + prefix + "*.*";
			string[] existingreports = Directory.GetFiles(FilePath, prefix + "*.*");
			foreach (string filename in existingreports)
			{
				try
				{
					File.Delete(filename);
				}
				catch { }
			}

			//sw è il nome del file temporaneo che hai creato
			DateTime oggi_dt = DateTime.Now;
			string oggi = oggi_dt.Ticks.ToString();

			if (DS.itinerationrefundattachment.Rows.Count == 0 || dataGridAllegati.CurrentRowIndex < 0) return;

			DataRow Curr = DS.itinerationrefundattachment.Rows[dataGridAllegati.CurrentRowIndex];
			if (Curr["attachment"] == DBNull.Value && Curr["idfilestorage"] == DBNull.Value) return;

            // File preso dall'attachment o dal MongoDb
            byte[] ByteArray = { };

            if (Curr["attachment"] != DBNull.Value)
            {
                // Attachment
                ByteArray = (byte[])Curr["attachment"];
            }
            else
            {
                // MongoDb
                ByteArray = metaeasylibrary.HttpFileStorage.DownloadFile(this.conn, this.meta.PrimaryDataTable.TableName, Curr["idfilestorage"].ToString()).GetAwaiter().GetResult();
                if (ByteArray == null)
                {
                    show("Servizio Download degli Allegati non disponibile");
                    return;
                }
            }

			int offset = 0;
			string fname = Curr["filename"].ToString();
			string estensione = Path.GetExtension(fname).Trim();

			bool extensionDenied = CfgFn.ExtensionDenied(estensione);

			if (extensionDenied)
			{
				show("Impossibile aprire questo tipo di file");
				return;
			}
			if (!CfgFn.ExtensionAllowed(estensione))
			{
				DialogResult dr = show("Si sta aprendo un file con estensione " + estensione +". Sei sicuro di voler aprire questo file?", "Attenzione!", MessageBoxButtons.YesNo);
				if (dr == DialogResult.No)
					return;
			}

			string sw = Path.Combine(FilePath, prefix + oggi.ToString() + estensione);
			try
			{
				ScriviFile(sw, ByteArray, offset);

				runProcess(sw, true);
			}
			catch (Exception E)
			{
				QueryCreator.ShowException(E);
			}
		}

		void ScriviFile(string sw, byte[] documento, int offset)
		{
			// Legge il documento memorizzato nel DB e lo scrive nel file temp.
			if (Meta.IsEmpty)
				return;
			if (!Meta.GetFormData(true))
				return;

			FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);

			int n = documento.Length - offset;
			if (n == 0)
				return;
			try
			{
				FS.Write(documento, offset, n);//<<<<<<<<<
				FS.Flush();
				FS.Close();
			}
			catch { }
		}
	}
}
