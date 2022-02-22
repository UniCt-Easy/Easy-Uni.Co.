
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using itinerationFunctions;//FunzioniMissione

namespace itinerationrefund_default{
	/// <summary>
	/// Summary description for FrmMissioneSpesa.
	/// </summary>
	public class Frm_itinerationrefund_default : MetaDataForm {
        bool inChiusura = false;
		private System.Windows.Forms.ComboBox cmbValuta;
        private System.Windows.Forms.Button btnValuta;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmbClassificazione;
		private System.Windows.Forms.Button btnClassificazione;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCambio;
		public vistaForm DS;
		DataRow ParentMissione;
		MetaData Meta;
        private System.Windows.Forms.GroupBox grpDatiGenerali;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox grpIndennita;
		private System.Windows.Forms.TextBox txtIndennSuppl;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox grpAnticipo;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtPercAnticipoItaliaEstero;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtAnticipo;
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
		private Button btnIndElimina;
		private Button btnIndInserisci;
		private Button btnIndModifica;
		private System.ComponentModel.IContainer components;

		public Frm_itinerationrefund_default() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
            inChiusura = true;
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_itinerationrefund_default));
            this.cmbValuta = new System.Windows.Forms.ComboBox();
            this.DS = new itinerationrefund_default.vistaForm();
            this.btnValuta = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbClassificazione = new System.Windows.Forms.ComboBox();
            this.btnClassificazione = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.grpDatiGenerali = new System.Windows.Forms.GroupBox();
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
            this.tabAllegati = new System.Windows.Forms.TabPage();
            this.grpBoxAllegati = new System.Windows.Forms.GroupBox();
            this.dataGridAllegati = new System.Windows.Forms.DataGrid();
            this.btnIndElimina = new System.Windows.Forms.Button();
            this.btnIndInserisci = new System.Windows.Forms.Button();
            this.btnIndModifica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpDatiGenerali.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // cmbValuta
            // 
            this.cmbValuta.DataSource = this.DS.currency;
            this.cmbValuta.DisplayMember = "description";
            this.cmbValuta.Location = new System.Drawing.Point(88, 70);
            this.cmbValuta.Name = "cmbValuta";
            this.cmbValuta.Size = new System.Drawing.Size(176, 21);
            this.cmbValuta.TabIndex = 3;
            this.cmbValuta.Tag = "itinerationrefund.idcurrency";
            this.cmbValuta.ValueMember = "idcurrency";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnValuta
            // 
            this.btnValuta.Location = new System.Drawing.Point(8, 70);
            this.btnValuta.Name = "btnValuta";
            this.btnValuta.Size = new System.Drawing.Size(72, 23);
            this.btnValuta.TabIndex = 24;
            this.btnValuta.TabStop = false;
            this.btnValuta.Tag = "manage.currency.lista";
            this.btnValuta.Text = "Valuta:";
            this.btnValuta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(88, 13);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(384, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "itinerationrefund.description";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 21;
            this.label4.Text = "Descrizione:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbClassificazione
            // 
            this.cmbClassificazione.DataSource = this.DS.itinerationrefundkind;
            this.cmbClassificazione.DisplayMember = "description";
            this.cmbClassificazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassificazione.Location = new System.Drawing.Point(128, 8);
            this.cmbClassificazione.Name = "cmbClassificazione";
            this.cmbClassificazione.Size = new System.Drawing.Size(360, 21);
            this.cmbClassificazione.TabIndex = 1;
            this.cmbClassificazione.Tag = "itinerationrefund.iditinerationrefundkind";
            this.cmbClassificazione.ValueMember = "iditinerationrefundkind";
            // 
            // btnClassificazione
            // 
            this.btnClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassificazione.Location = new System.Drawing.Point(8, 8);
            this.btnClassificazione.Name = "btnClassificazione";
            this.btnClassificazione.Size = new System.Drawing.Size(112, 23);
            this.btnClassificazione.TabIndex = 18;
            this.btnClassificazione.TabStop = false;
            this.btnClassificazione.Tag = "manage.itinerationrefundkind.default";
            this.btnClassificazione.Text = "Rimborso Spese";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(756, 534);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 9;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(676, 534);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(272, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "Tasso di Cambio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCambio
            // 
            this.txtCambio.Location = new System.Drawing.Point(372, 70);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(100, 20);
            this.txtCambio.TabIndex = 4;
            this.txtCambio.Tag = "itinerationrefund.exchangerate.fixed.8...1";
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCambio.TextChanged += new System.EventHandler(this.txtCambio_TextChanged);
            // 
            // grpDatiGenerali
            // 
            this.grpDatiGenerali.Controls.Add(this.label12);
            this.grpDatiGenerali.Controls.Add(this.label11);
            this.grpDatiGenerali.Controls.Add(this.txtDataFine);
            this.grpDatiGenerali.Controls.Add(this.txtDataInizio);
            this.grpDatiGenerali.Controls.Add(this.txtDescrizione);
            this.grpDatiGenerali.Controls.Add(this.label4);
            this.grpDatiGenerali.Controls.Add(this.cmbValuta);
            this.grpDatiGenerali.Controls.Add(this.btnValuta);
            this.grpDatiGenerali.Controls.Add(this.label1);
            this.grpDatiGenerali.Controls.Add(this.txtCambio);
            this.grpDatiGenerali.Location = new System.Drawing.Point(8, 38);
            this.grpDatiGenerali.Name = "grpDatiGenerali";
            this.grpDatiGenerali.Size = new System.Drawing.Size(480, 130);
            this.grpDatiGenerali.TabIndex = 2;
            this.grpDatiGenerali.TabStop = false;
            this.grpDatiGenerali.Text = "Dati generali";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(306, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Data Fine:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 23);
            this.label11.TabIndex = 51;
            this.label11.Text = "Data Inizio:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataFine
            // 
            this.txtDataFine.Location = new System.Drawing.Point(372, 102);
            this.txtDataFine.Name = "txtDataFine";
            this.txtDataFine.Size = new System.Drawing.Size(100, 20);
            this.txtDataFine.TabIndex = 50;
            this.txtDataFine.Tag = "itinerationrefund.stoptime.g";
            this.txtDataFine.TextChanged += new System.EventHandler(this.txtDataFine_Leave);
            this.txtDataFine.Leave += new System.EventHandler(this.txtDataFine_Leave_1);
            // 
            // txtDataInizio
            // 
            this.txtDataInizio.Location = new System.Drawing.Point(88, 104);
            this.txtDataInizio.Name = "txtDataInizio";
            this.txtDataInizio.Size = new System.Drawing.Size(100, 20);
            this.txtDataInizio.TabIndex = 49;
            this.txtDataInizio.Tag = "itinerationrefund.starttime.g";
            this.txtDataInizio.TextChanged += new System.EventHandler(this.txtDataInizio_Leave);
            this.txtDataInizio.Leave += new System.EventHandler(this.txtDataInizio_Leave_1);
            // 
            // grpAnticipo
            // 
            this.grpAnticipo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grpAnticipo.Controls.Add(this.label9);
            this.grpAnticipo.Controls.Add(this.txtPercAnticipoItaliaEstero);
            this.grpAnticipo.Controls.Add(this.label10);
            this.grpAnticipo.Controls.Add(this.txtAnticipo);
            this.grpAnticipo.Location = new System.Drawing.Point(405, 149);
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
            this.txtPercAnticipoItaliaEstero.TextChanged += new System.EventHandler(this.txtPercAnticipoItaliaEstero_TextChanged);
            this.txtPercAnticipoItaliaEstero.Leave += new System.EventHandler(this.txtPercAnticipoItaliaEstero_Leave);
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
            this.grpIndennita.Controls.Add(this.txtIndennSuppl);
            this.grpIndennita.Controls.Add(this.label7);
            this.grpIndennita.Location = new System.Drawing.Point(3, 41);
            this.grpIndennita.Name = "grpIndennita";
            this.grpIndennita.Size = new System.Drawing.Size(264, 45);
            this.grpIndennita.TabIndex = 65;
            this.grpIndennita.TabStop = false;
            this.grpIndennita.Text = "Indennità Supplementare";
            // 
            // txtIndennSuppl
            // 
            this.txtIndennSuppl.Location = new System.Drawing.Point(143, 17);
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
            this.label7.Location = new System.Drawing.Point(73, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 60;
            this.label7.Text = "Importo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpLocalita
            // 
            this.grpLocalita.Controls.Add(this.rdoExtraUe);
            this.grpLocalita.Controls.Add(this.rdoUe);
            this.grpLocalita.Controls.Add(this.rdoItaly);
            this.grpLocalita.Location = new System.Drawing.Point(658, 73);
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
            this.rdoExtraUe.CheckedChanged += new System.EventHandler(this.rdoExtraUe_CheckedChanged);
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
            this.rdoUe.CheckedChanged += new System.EventHandler(this.rdoUe_CheckedChanged);
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
            this.rdoItaly.CheckedChanged += new System.EventHandler(this.rdoItaly_CheckedChanged);
            // 
            // grpLimite
            // 
            this.grpLimite.Controls.Add(this.txtLimiteMax);
            this.grpLimite.Controls.Add(this.label2);
            this.grpLimite.Location = new System.Drawing.Point(274, 43);
            this.grpLimite.Name = "grpLimite";
            this.grpLimite.Size = new System.Drawing.Size(264, 43);
            this.grpLimite.TabIndex = 68;
            this.grpLimite.TabStop = false;
            this.grpLimite.Text = "Limite Massimo per Classe di Spesa";
            // 
            // txtLimiteMax
            // 
            this.txtLimiteMax.Location = new System.Drawing.Point(141, 18);
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
            this.label2.Location = new System.Drawing.Point(68, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Importo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpApplicabilita
            // 
            this.grpApplicabilita.Controls.Add(this.rdbSaldo);
            this.grpApplicabilita.Controls.Add(this.rdbAnticipo);
            this.grpApplicabilita.Location = new System.Drawing.Point(658, 15);
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
            this.grpDocCollegato.Controls.Add(this.label17);
            this.grpDocCollegato.Controls.Add(this.label8);
            this.grpDocCollegato.Controls.Add(this.label3);
            this.grpDocCollegato.Controls.Add(this.txtDocumento);
            this.grpDocCollegato.Controls.Add(this.label6);
            this.grpDocCollegato.Controls.Add(this.label5);
            this.grpDocCollegato.Controls.Add(this.txtDataDoc);
            this.grpDocCollegato.Controls.Add(this.txtImportoDocEUR);
            this.grpDocCollegato.Controls.Add(this.txtImportoDocValuta);
            this.grpDocCollegato.Location = new System.Drawing.Point(4, 88);
            this.grpDocCollegato.Name = "grpDocCollegato";
            this.grpDocCollegato.Size = new System.Drawing.Size(638, 55);
            this.grpDocCollegato.TabIndex = 70;
            this.grpDocCollegato.TabStop = false;
            this.grpDocCollegato.Text = "Documento collegato (scontrino/fattura/altro)";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(348, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 14);
            this.label17.TabIndex = 56;
            this.label17.Text = "Importo";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(516, 8);
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
            this.txtDocumento.Location = new System.Drawing.Point(73, 25);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(160, 20);
            this.txtDocumento.TabIndex = 4;
            this.txtDocumento.Tag = "itinerationrefund.doc";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(398, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 52;
            this.label6.Text = "in valuta";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(237, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Data";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataDoc
            // 
            this.txtDataDoc.Location = new System.Drawing.Point(273, 25);
            this.txtDataDoc.Name = "txtDataDoc";
            this.txtDataDoc.Size = new System.Drawing.Size(69, 20);
            this.txtDataDoc.TabIndex = 5;
            this.txtDataDoc.Tag = "itinerationrefund.docdate";
            // 
            // txtImportoDocEUR
            // 
            this.txtImportoDocEUR.Location = new System.Drawing.Point(516, 25);
            this.txtImportoDocEUR.Name = "txtImportoDocEUR";
            this.txtImportoDocEUR.ReadOnly = true;
            this.txtImportoDocEUR.Size = new System.Drawing.Size(112, 20);
            this.txtImportoDocEUR.TabIndex = 2;
            this.txtImportoDocEUR.TabStop = false;
            this.txtImportoDocEUR.Tag = "itinerationrefund.docamount.c";
            this.txtImportoDocEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImportoDocValuta
            // 
            this.txtImportoDocValuta.Location = new System.Drawing.Point(397, 24);
            this.txtImportoDocValuta.Name = "txtImportoDocValuta";
            this.txtImportoDocValuta.Size = new System.Drawing.Size(112, 20);
            this.txtImportoDocValuta.TabIndex = 2;
            this.txtImportoDocValuta.Tag = "";
            this.txtImportoDocValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImportoDocValuta.TextChanged += new System.EventHandler(this.txtImportoValuta_TextChanged);
            this.txtImportoDocValuta.Enter += new System.EventHandler(this.txtImportoValuta_Enter);
            this.txtImportoDocValuta.Leave += new System.EventHandler(this.txtImportoValuta_Leave);
            // 
            // txtImportoRichiestoEUR
            // 
            this.txtImportoRichiestoEUR.Location = new System.Drawing.Point(276, 36);
            this.txtImportoRichiestoEUR.Name = "txtImportoRichiestoEUR";
            this.txtImportoRichiestoEUR.ReadOnly = true;
            this.txtImportoRichiestoEUR.Size = new System.Drawing.Size(112, 20);
            this.txtImportoRichiestoEUR.TabIndex = 2;
            this.txtImportoRichiestoEUR.TabStop = false;
            this.txtImportoRichiestoEUR.Tag = "itinerationrefund.requiredamount.c";
            this.txtImportoRichiestoEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImportoRichiestoEUR.TextChanged += new System.EventHandler(this.txtImportoEffettivoEUR_TextChanged);
            // 
            // txtImportoRichiestoValuta
            // 
            this.txtImportoRichiestoValuta.Location = new System.Drawing.Point(154, 36);
            this.txtImportoRichiestoValuta.Name = "txtImportoRichiestoValuta";
            this.txtImportoRichiestoValuta.Size = new System.Drawing.Size(112, 20);
            this.txtImportoRichiestoValuta.TabIndex = 1;
            this.txtImportoRichiestoValuta.Tag = "";
            this.txtImportoRichiestoValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImportoRichiestoValuta.TextChanged += new System.EventHandler(this.txtImportoValuta_TextChanged);
            this.txtImportoRichiestoValuta.Enter += new System.EventHandler(this.txtImportoValuta_Enter);
            this.txtImportoRichiestoValuta.Leave += new System.EventHandler(this.txtImportoValuta_Leave);
            // 
            // grpImporti
            // 
            this.grpImporti.Controls.Add(this.label16);
            this.grpImporti.Controls.Add(this.label15);
            this.grpImporti.Controls.Add(this.label14);
            this.grpImporti.Controls.Add(this.label13);
            this.grpImporti.Controls.Add(this.txtImportoEffettivoValuta);
            this.grpImporti.Controls.Add(this.txtImportoRichiestoEUR);
            this.grpImporti.Controls.Add(this.txtImportoEffettivoEUR);
            this.grpImporti.Controls.Add(this.txtImportoRichiestoValuta);
            this.grpImporti.Location = new System.Drawing.Point(4, 146);
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
            this.txtImportoEffettivoValuta.Tag = "";
            this.txtImportoEffettivoValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImportoEffettivoValuta.TextChanged += new System.EventHandler(this.txtImportoValuta_TextChanged);
            this.txtImportoEffettivoValuta.Enter += new System.EventHandler(this.txtImportoValuta_Enter);
            this.txtImportoEffettivoValuta.Leave += new System.EventHandler(this.txtImportoValuta_Leave);
            // 
            // txtImportoEffettivoEUR
            // 
            this.txtImportoEffettivoEUR.Location = new System.Drawing.Point(277, 63);
            this.txtImportoEffettivoEUR.Name = "txtImportoEffettivoEUR";
            this.txtImportoEffettivoEUR.ReadOnly = true;
            this.txtImportoEffettivoEUR.Size = new System.Drawing.Size(112, 20);
            this.txtImportoEffettivoEUR.TabIndex = 2;
            this.txtImportoEffettivoEUR.TabStop = false;
            this.txtImportoEffettivoEUR.Tag = "itinerationrefund.amount.c";
            this.txtImportoEffettivoEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(11, 281);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(180, 19);
            this.label18.TabIndex = 71;
            this.label18.Text = "Comunicazioni per il Responsabile";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComunicazioni
            // 
            this.txtComunicazioni.Location = new System.Drawing.Point(199, 281);
            this.txtComunicazioni.Multiline = true;
            this.txtComunicazioni.Name = "txtComunicazioni";
            this.txtComunicazioni.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComunicazioni.Size = new System.Drawing.Size(443, 46);
            this.txtComunicazioni.TabIndex = 72;
            this.txtComunicazioni.Tag = "itinerationrefund.webwarn";
            // 
            // btnArea
            // 
            this.btnArea.Location = new System.Drawing.Point(11, 15);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(88, 23);
            this.btnArea.TabIndex = 73;
            this.btnArea.TabStop = false;
            this.btnArea.Tag = "manage.foreigncountry.default";
            this.btnArea.Text = "Località Estera:";
            this.btnArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbArea
            // 
            this.cmbArea.DataSource = this.DS.foreigncountry;
            this.cmbArea.DisplayMember = "description";
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.Location = new System.Drawing.Point(105, 15);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(320, 21);
            this.cmbArea.TabIndex = 74;
            this.cmbArea.Tag = "itinerationrefund.idforeigncountry";
            this.cmbArea.ValueMember = "idforeigncountry";
            // 
            // txtImpNonRendicontabile
            // 
            this.txtImpNonRendicontabile.Location = new System.Drawing.Point(199, 247);
            this.txtImpNonRendicontabile.Name = "txtImpNonRendicontabile";
            this.txtImpNonRendicontabile.Size = new System.Drawing.Size(112, 20);
            this.txtImpNonRendicontabile.TabIndex = 76;
            this.txtImpNonRendicontabile.Tag = "itinerationrefund.noaccount";
            this.txtImpNonRendicontabile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(12, 240);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(179, 32);
            this.label19.TabIndex = 75;
            this.label19.Text = "Importo non rendicontabile";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSpesa);
            this.tabControl1.Controls.Add(this.tabAllegati);
            this.tabControl1.Location = new System.Drawing.Point(8, 174);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 361);
            this.tabControl1.TabIndex = 77;
            // 
            // tabSpesa
            // 
            this.tabSpesa.Controls.Add(this.btnArea);
            this.tabSpesa.Controls.Add(this.grpApplicabilita);
            this.tabSpesa.Controls.Add(this.grpLocalita);
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
            this.tabSpesa.Size = new System.Drawing.Size(823, 335);
            this.tabSpesa.TabIndex = 0;
            this.tabSpesa.Text = "Spesa";
            this.tabSpesa.UseVisualStyleBackColor = true;
            // 
            // tabAllegati
            // 
            this.tabAllegati.Controls.Add(this.grpBoxAllegati);
            this.tabAllegati.Location = new System.Drawing.Point(4, 22);
            this.tabAllegati.Name = "tabAllegati";
            this.tabAllegati.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllegati.Size = new System.Drawing.Size(823, 335);
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
            this.grpBoxAllegati.Controls.Add(this.btnIndElimina);
            this.grpBoxAllegati.Controls.Add(this.btnIndInserisci);
            this.grpBoxAllegati.Controls.Add(this.btnIndModifica);
            this.grpBoxAllegati.Location = new System.Drawing.Point(7, 6);
            this.grpBoxAllegati.Name = "grpBoxAllegati";
            this.grpBoxAllegati.Size = new System.Drawing.Size(810, 323);
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
            this.dataGridAllegati.Size = new System.Drawing.Size(724, 288);
            this.dataGridAllegati.TabIndex = 20;
            this.dataGridAllegati.Tag = "itinerationrefundattachment.single";
            // 
            // btnIndElimina
            // 
            this.btnIndElimina.Location = new System.Drawing.Point(5, 85);
            this.btnIndElimina.Name = "btnIndElimina";
            this.btnIndElimina.Size = new System.Drawing.Size(68, 22);
            this.btnIndElimina.TabIndex = 19;
            this.btnIndElimina.Tag = "delete";
            this.btnIndElimina.Text = "Elimina";
            this.btnIndElimina.Visible = false;
            // 
            // btnIndInserisci
            // 
            this.btnIndInserisci.Location = new System.Drawing.Point(6, 29);
            this.btnIndInserisci.Name = "btnIndInserisci";
            this.btnIndInserisci.Size = new System.Drawing.Size(68, 22);
            this.btnIndInserisci.TabIndex = 17;
            this.btnIndInserisci.Tag = "insert.single";
            this.btnIndInserisci.Text = "Inserisci...";
            // 
            // btnIndModifica
            // 
            this.btnIndModifica.Location = new System.Drawing.Point(5, 57);
            this.btnIndModifica.Name = "btnIndModifica";
            this.btnIndModifica.Size = new System.Drawing.Size(69, 22);
            this.btnIndModifica.TabIndex = 18;
            this.btnIndModifica.Tag = "edit.single";
            this.btnIndModifica.Text = "Modifica...";
            // 
            // Frm_itinerationrefund_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(838, 566);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpDatiGenerali);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbClassificazione);
            this.Controls.Add(this.btnClassificazione);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_itinerationrefund_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMissioneSpesa";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpDatiGenerali.ResumeLayout(false);
            this.grpDatiGenerali.PerformLayout();
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
            this.ResumeLayout(false);

		}
		#endregion

	    private bool disabilitatoAllAvvio = false;
        DataAccess Conn;
        CfgItineration Cfg;
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            HelpForm.SetFormatForColumn(DS.itinerationrefund.Columns["stoptime"], "g");
            HelpForm.SetFormatForColumn(DS.itinerationrefund.Columns["starttime"], "g");
            object oggi = Meta.Conn.DO_SYS_CMD("select getdate()");

            string filterKind = "";
            grpApplicabilita.Enabled = true; //false;

            Cfg = (CfgItineration) Meta.ExtraParameter ;
            EnableDisableControls(false, false);
            disabilitatoAllAvvio = true;
            bool anticipo = (Meta.edit_type == "advance");
            if (Meta.edit_type == "advance") {
                //MetaData.SetDefault(DS.itinerationrefund, "flagadvancebalance", "A");
                grpDocCollegato.Visible = false;
                MakeSpaceFrom(grpDocCollegato);
                ParentMissione = Meta.SourceRow.GetParentRow("itinerationitinerationrefund");
                filterKind = QHS.CmpEq("flagadvance", "S");
                //GetData.SetStaticFilter(DS.itinerationrefundkind, QHS.CmpEq("flagadvance","S"));
                //Se è passata la data inizio non si possono più mettere le spese di anticipo
                if ((DateTime) oggi >= (DateTime) Meta.SourceRow["starttime"]) {
                    EnableDisableControls(false, true);
                    disabilitatoAllAvvio = true;
                }
                else {
                    EnableDisableControls(true, true);
                    disabilitatoAllAvvio = false;
                }
           }
           else {
                //MetaData.SetDefault(DS.itinerationrefund, "flagadvancebalance", "S");
                grpAnticipo.Visible = false;
                ParentMissione = Meta.SourceRow.GetParentRow("itineration_itinerationrefund_balance");
                filterKind = QHS.CmpEq("flagbalance", "S");
                //GetData.SetStaticFilter(DS.itinerationrefundkind, QHS.CmpEq("flagbalance", "S"));
                if ((DateTime)oggi >= (DateTime)Meta.SourceRow["stoptime"]) {
                    EnableDisableControls(true, false);
                    disabilitatoAllAvvio = false;
                }
                else {
                    EnableDisableControls(true, false);
                    disabilitatoAllAvvio = false;
                }
            }
            if (ParentMissione["flagweb"].ToString().ToUpper() == "S") {
                //rimosso gestione disabilitazione per task 8583
                //if ((DateTime)oggi >= (DateTime)Meta.SourceRow["stoptime"]) {
                //    EnableDisableControls(true, anticipo);
                //    disabilitatoAllAvvio = false;
                //}

                //EnableDisableControls(false,false);
                //disabilitatoAllAvvio = true;
                if (ParentMissione["idauthmodel"] != DBNull.Value) {
                    string filterAuthModel = QHS.FieldInList("iditinerationrefundkind",
                        "SELECT iditinerationrefundkind from authmodelitinerationrefundkind where " +
                        QHS.CmpEq("idauthmodel", ParentMissione["idauthmodel"]));
                    filterKind = QHS.AppAnd(filterKind, filterAuthModel);
                 }
            }
            GetData.SetStaticFilter(DS.itinerationrefundkind, filterKind);
		}

        //Enable comanda la maggior parte dei controlli, tranne l'importo effettivo che 
        void EnableDisableControls (bool enable, bool advance) {
            
            cmbClassificazione.Enabled = enable;
            grpDatiGenerali.Enabled = enable;
            grpDocCollegato.Enabled = enable;
            if (advance) {
                txtImportoEffettivoValuta.ReadOnly = (!enable) || IsRimborsoForfettario();
                txtComunicazioni.Enabled = enable;
            }
            else {
                txtImportoEffettivoValuta.ReadOnly = !enable;
            }
            txtImpNonRendicontabile.ReadOnly = !enable;

            grpIndennita.Enabled = enable;
            grpLimite.Enabled = enable;
            grpLocalita.Enabled = enable;
            grpAnticipo.Enabled = enable;
            //Se non è una missione web allora l'importo richiesto è abilitato/disabilitato in base ad Enable
            if (ParentMissione != null && ParentMissione["flagweb"].ToString().ToUpper() == "S") {
                txtImportoRichiestoValuta.ReadOnly = true;
            }
            else {
                txtImportoRichiestoValuta.ReadOnly = !enable;
            }
            if (txtImportoRichiestoValuta.ReadOnly) txtImportoRichiestoValuta.TabStop = false;

            grpApplicabilita.Enabled = enable;

        }

        void MakeSpaceFrom (GroupBox G) {
			Form T = G.FindForm();;
            Form F = G.FindForm();
            int disp = G.Height;
            int y0 = G.Location.Y;
            T.SuspendLayout();
            tabControl1.SuspendLayout();
            tabSpesa.SuspendLayout();
            tabAllegati.SuspendLayout();
            foreach (Control C in tabSpesa.Controls) {
                if (C.Location.Y < y0) continue;
                if ((C.Anchor & AnchorStyles.Bottom) == 0)
                    C.Location = new Point(C.Location.X, C.Location.Y - disp);
                else {
                    if ((C.Anchor & AnchorStyles.Top) != 0) {
                        C.Size = new Size(C.Size.Width, C.Size.Height + disp);
                        C.Location = new Point(C.Location.X, C.Location.Y - disp);
                    }
                }
            }
            foreach (Control C in tabAllegati.Controls){
                if (C.Location.Y < y0) continue;
                if ((C.Anchor & AnchorStyles.Bottom) == 0)
                    C.Location = new Point(C.Location.X, C.Location.Y - disp);
                else{
                    if ((C.Anchor & AnchorStyles.Top) != 0){
                        C.Size = new Size(C.Size.Width, C.Size.Height + disp);
                        C.Location = new Point(C.Location.X, C.Location.Y - disp);
                    }
                }
            }
            tabSpesa.Size = new Size(tabSpesa.Size.Width, tabSpesa.Size.Height - disp);
            tabAllegati.Size = new Size(tabAllegati.Size.Width, tabAllegati.Size.Height - disp);

            tabControl1.Size = new Size(tabControl1.Size.Width, tabControl1.Size.Height - disp);
            T.Size = new Size(F.Size.Width, F.Size.Height - disp);
            tabSpesa.ResumeLayout();
            tabAllegati.ResumeLayout();
            tabControl1.ResumeLayout();

            T.ResumeLayout();
        }

		public void MetaData_AfterActivation() {
			string filter = MissFun.GetQualificaClasseFilter(Cfg.idposition,Cfg.incomeclass);

			if ( filter==null || filter=="") return; // || Meta.InsertMode
			DataRow Curr = DS.itinerationrefund.Rows[0];
            //string MyFilter = "(iditinerationrefundkind="+
            //    QueryCreator.quotedstrvalue(Curr["iditinerationrefundkind"], true)+") AND "+
            //    filter;

			if (ParentMissione.RowState!=DataRowState.Added){
				string ff=QHS.AppAnd(QHS.MCmp(Curr, "iditineration"), QHS.CmpNe("movkind", 4));
                int N= Meta.Conn.RUN_SELECT_COUNT("expenseitineration",ff,false);
                ff = QHS.MCmp(Curr,"iditineration");
				N += Meta.Conn.RUN_SELECT_COUNT("pettycashoperationitineration",ff,false);
				if ((N>0)&&(Meta.edit_type == "advance")) show(
							 "Avendo già contabilizzato l'anticipo di questa missione, le modifiche alle spese "+
							 "non saranno tenute in considerazione ai fini del calcolo dell'anticipo della missione.","Avviso");
			}
		
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (!Meta.DrawStateIsDone) return;

			if (T.TableName == "currency") {
				AggiornaValuta(R);
			}

			if (T.TableName == "itinerationrefundkind") {
				Meta.GetFormData(true);
				AggiornaPerc(R);
                AggiornaLimite(R);
                AbilitadisabilitaArea(R);
                AggiornaRimborsoForfettario();
                txtImportoEffettivoValuta.ReadOnly = IsRimborsoForfettario()|| disabilitatoAllAvvio;
			}

            if (T.TableName == "foreigncountry") {
                AbilitadisabilitaGrpLocalita(R);
                AggiornaRimborsoForfettario();
            }
		}

        private void AbilitadisabilitaGrpLocalita(DataRow R){
            if (R == null){
                grpLocalita.Enabled = true;
                rdoItaly.Checked = true;
            }
            else{
                if (R["flag_ue"].ToString() == "U"){
                    rdoUe.Checked = true;
                }
                else{
                    rdoExtraUe.Checked = true;
                }
                grpLocalita.Enabled = false;
            }
        }

        bool IsRimborsoForfettario() {
            if (Meta.IsEmpty) return false;
            object O = cmbClassificazione.SelectedValue;
            if (O == null || O == DBNull.Value) return false;

            string filter = QHC.CmpEq("iditinerationrefundkind", O);
            DataRow[] RefundKind = DS.itinerationrefundkind.Select(filter);
            if (RefundKind.Length == 0){
                return false;
            }

            DataRow rRefundKind = RefundKind[0];
            if (CfgFn.GetNoNullInt32(rRefundKind["iditinerationrefundkindgroup"]) == 5) {
                return true;
            }

            return false;
        }

        void AzzeraRimborso() {
            DataRow Curr = DS.itinerationrefund.Rows[0];
            Curr["amount"] = 0;
            Meta.FreshForm(false);            
        }

        /// <summary>
        /// Aggiorna l'importo del rimborso in base  a qualifica, durata, paese e limite di anticipabilità imposto dalle ritenute
        /// </summary>
        void AggiornaRimborsoForfettario() {
            if (!IsRimborsoForfettario()) return;
            if (Cfg.foreignclass == "") return;
            Meta.GetFormData(true);
            DataRow Curr= DS.itinerationrefund.Rows[0];
            DateTime Start;
            DateTime Stop;
            if (Curr["starttime"] == DBNull.Value || (Curr["stoptime"] == DBNull.Value)) {
                AzzeraRimborso();
                return;
            }
                
            Start = (DateTime)Curr["starttime"];
            Stop = (DateTime)Curr["stoptime"];

            double frazfgiorni = MissFun.IF_CalcolaFrazGiorni(Start, Stop);
            
            //classe estera per il rimborso forfettario
            string IF_class = Cfg.foreignclass;
            object idforeigncountry = Curr["idforeigncountry"];
            if (idforeigncountry == DBNull.Value) {
                AzzeraRimborso();
                return;
            }

        DataRow[] fc = DS.foreigncountry.Select(QHC.CmpEq("idforeigncountry", idforeigncountry));
        if (fc.Length == 0) {
            AzzeraRimborso();
            return;
        }
        object idmacroarea = fc[0]["idmacroarea"];
        if (idmacroarea == DBNull.Value) {
            AzzeraRimborso();
            return;
        }
        string filter = QHS.AppAnd(QHS.CmpEq("idmacroarea", idmacroarea),
                                    QHS.CmpLe("start", ParentMissione[MissFun.CampoDataPerPosGiuridica]),
                                    QHS.NullOrLt("stop", ParentMissione[MissFun.CampoDataPerPosGiuridica]));
        string field = "amount_" + IF_class.ToLower();
            decimal amount = CfgFn.GetNoNullDecimal( Conn.DO_READ_VALUE("macroarea", filter, field));
            if (amount == 0) {
                AzzeraRimborso();//Controllare se azzera anche l'anticipo
                return;
            }
            amount = amount * Convert.ToDecimal(frazfgiorni);

            Curr["amount"] = amount;
            txtImportoEffettivoEUR.Text = HelpForm.StringValue(amount, txtImportoEffettivoEUR.Tag.ToString());

            //RicalcolaImportoEffettivoValuta();

            // La percentuale di anticipo deve essere ricalcolata anche quando cambia la località:
            // AggiornaPerc()  vuole la riga del Rimborso spese ma in realtà non la utilizza, quindi per il momento gli passiamo la riga di 
            string filterTipoRimborso = QHC.CmpEq("iditinerationrefundkind", Curr["iditinerationrefundkind"]);
            DataRow[] RefundKind = DS.itinerationrefundkind.Select(filterTipoRimborso);
            if (RefundKind.Length == 0){
                AggiornaPerc(null);
            }
            else{
                AggiornaPerc(RefundKind[0]);
            }
            RicalcolaAnticipo();//Chiamato implicitamente da AggiornaPerc(). Se non cambia la % può cambiare l'importo 
            RicalcolaImportoEffettivoValuta(false);
            CheckLimiteAnticipo();


        }

        /// <summary>
        /// Verifica se il limite anticipo supera l'importo totale netto da pagare.
        /// </summary>
        /// <returns>true se il valore è accettabile</returns>
        bool CheckLimiteAnticipo() {
            if (!IsRimborsoForfettario()) return true;
            if (Cfg.foreignclass == "") return true;
            Meta.GetFormData(true);
            
            DataRow Curr = DS.itinerationrefund.Rows[0];

            //si basa sul valore di Curr["amount"]
            decimal lordo = CfgFn.GetNoNullDecimal(Curr["amount"]);
            decimal imponibile = MissFun.IF_ImponibileSpesa(Curr, DS.itinerationrefundkind, Cfg);
            decimal aliquota = Cfg.totaltaxrate;
            decimal tax = imponibile * aliquota;

            decimal netto = lordo - tax;

            decimal percanticipo = CfgFn.GetNoNullDecimal( Curr["advancepercentage"]);
            decimal anticipo = lordo * percanticipo;
            if (anticipo==0) return true;
            decimal maxanticipo = netto;
            decimal maxpercanticipo = Decimal.Round(netto / lordo,6);

            if (percanticipo > maxpercanticipo) {
                string msg = "L'anticipo calcolato è superiore all'importo da pagare al netto delle ritenute. Questo " +
                    "determinerà la necessità di effettuare un conguaglio negativo al pagamento del saldo della missione." +
                    " Vuole procedere comunque (altamente sconsigliato)?";
                if (show(msg, "Avviso", MessageBoxButtons.YesNo) == DialogResult.No) {
                    Curr["advancepercentage"] = maxpercanticipo;
                    txtPercAnticipoItaliaEstero.Text = HelpForm.StringValue(maxpercanticipo, txtPercAnticipoItaliaEstero.Tag.ToString());
                    show("La percentuale di anticipo è stata reimpostata al valore massimo  possibile per non " +
                        "incorrere in un conguaglio negativo al saldo della missione", "Avviso");
                    
                    RicalcolaAnticipo();
                    return false;
                }
            }


            return true;
        }

        public void MetaData_AfterFill() {
            DataRow Curr = DS.itinerationrefund.Rows[0];
            AggiornaLimite(Curr);
            RicalcolaAnticipo();
            RicalcolaImportoEffettivoValuta(true);
            if (Meta.EditMode && Meta.FirstFillForThisRow)
            {
                CheckLimiteAnticipo();
                AbilitadisabilitaArea(Curr);
            }
            txtImportoEffettivoValuta.ReadOnly = IsRimborsoForfettario()||disabilitatoAllAvvio;

            object idforeigncountry = Curr["idforeigncountry"];
            if (idforeigncountry == DBNull.Value){
                return;
            }
            else{
                DataRow[] fc = DS.foreigncountry.Select(QHC.CmpEq("idforeigncountry", idforeigncountry));
                AbilitadisabilitaGrpLocalita(fc[0]);
            }
		}
		public void MetaData_BeforeFill() {
			Meta.MarkTableAsNotEntityChild(DS.itinerationrefundattachment);
			
		}
		bool do_checklimite = true;
        void RicalcolaImportoEffettivoValuta(bool checklimite) {
            if (DS.itinerationrefund.Rows.Count == 0) return;
            DataRow Curr = DS.itinerationrefund.Rows[0];
            double importoEuro = CfgFn.GetNoNullDouble(Curr["amount"]);
            double importoDocEuro = CfgFn.GetNoNullDouble(Curr["docamount"]);
            double importoRichiestoEuro = CfgFn.GetNoNullDouble(Curr["requiredamount"]);
            double exchangeRate = CfgFn.GetNoNullDouble(Curr["exchangerate"]);
            double importoValuta = 0;
            double importoDocValuta = 0;
            double importoRichiestoValuta = 0;
            if (exchangeRate != 0) {
                importoValuta = importoEuro / exchangeRate;
                importoDocValuta = importoDocEuro / exchangeRate;
                importoRichiestoValuta = importoRichiestoEuro / exchangeRate;
            }
            double x= CfgFn.Round(Convert.ToDouble(importoValuta), 2);
            double x1 = CfgFn.Round(Convert.ToDouble(importoDocValuta), 2);
            double x2 = CfgFn.Round(Convert.ToDouble(importoRichiestoValuta), 2);
            if (!checklimite) do_checklimite = false;
            txtImportoEffettivoValuta.Text = HelpForm.StringValue(x, "x.y.fixed.8...1");
            txtImportoDocValuta.Text = HelpForm.StringValue(x1, "x.y.fixed.8...1");
            txtImportoRichiestoValuta.Text = HelpForm.StringValue(x2, "x.y.fixed.8...1");
            checklimite = true;
        }

        void ClearPerc() {
            DataRow Curr = DS.itinerationrefund.Rows[0];
            Curr["advancepercentage"] = 0;
            txtPercAnticipoItaliaEstero.Text = HelpForm.StringValue(
                Curr["advancepercentage"], txtPercAnticipoItaliaEstero.Tag.ToString());
        }

        private int calcolaOre(object dataInizio, object dataFine) {
            DateTime inizio;
            try {
                inizio = (DateTime)dataInizio;
            }
            catch {
                return -1;
            }

            if (inizio.Year < 1000) return -1;
            DateTime fine;
            try {
                fine = (DateTime)dataFine;
            }
            catch {
                return -1;
            }
            if (fine.Year < 1000) return -1;

            double dinizio = 0;
            double dfine = 0;

            try {
                dinizio = inizio.ToOADate();
                dfine = fine.ToOADate();
            }
            catch {
                return -1;
            }

			
            int ngiorniinteri = Convert.ToInt32(Math.Floor(dfine - dinizio));
			int nore= Convert.ToInt32(
				Math.Floor(
				(dfine-dinizio- Math.Floor(dfine-dinizio))*24.0 + 0.5
				));
            nore += (ngiorniinteri * 24);
            return nore;
        }

        private string calcolaFiltroApplicazioneGeo() {
            if (DS.itinerationrefund.Rows.Count == 0) return "";
            DataRow Curr = DS.itinerationrefund.Rows[0];
            if (Curr["flag_geo"] == DBNull.Value) return "";
            string flaggeo = Curr["flag_geo"].ToString().ToUpper();
            string filter = "";
            if (rdoItaly.Checked) filter = QHS.CmpEq("flag_italy", 'S');
            if (rdoUe.Checked) filter = QHS.CmpEq("flag_eu", 'S');
            if (rdoExtraUe.Checked) filter = QHS.CmpEq("flag_extraeu", 'S');
            return filter;
        }

        void AbilitadisabilitaArea(DataRow R){
            if (R == null){
                return;
            }
            string filter = QHC.CmpEq("iditinerationrefundkind", R["iditinerationrefundkind"]);
            DataRow[] RefundKind = DS.itinerationrefundkind.Select(filter);
            if (RefundKind.Length == 0){
                return;
            }

            DataRow rRefundKind = RefundKind[0];
            //Se è una spesa di tipo rimborso forfettario oppure
            //Se è una spesa di tipo Vitto in località Ue oExtraUe verrà abilitato il combo delle località
            if ((CfgFn.GetNoNullInt32(rRefundKind["iditinerationrefundkindgroup"]) == 5)
            || ((CfgFn.GetNoNullInt32(rRefundKind["iditinerationrefundkindgroup"]) == 1) && (!(rdoItaly.Checked)))
            ){
                cmbArea.Enabled = true;
                btnArea.Enabled = true;
            }
            else{
                cmbArea.SelectedIndex = -1;
                DS.itinerationrefund.Rows[0]["idforeigncountry"] = DBNull.Value;
                cmbArea.Enabled = false;
                btnArea.Enabled = false;
            }

        }

        void AggiornaLimite(DataRow R) {
            if (R == null) {
                txtLimiteMax.Text = "";
                return;
            }
            bool esisteConf;
            if (IsRimborsoForfettario() && rdoItaly.Checked){
                txtLimiteMax.Text = "";
                return;
            }
            DataRow AttribRow = ottieniRigaRegolamentoSpesa(out esisteConf);
            if (AttribRow == null) {
                txtLimiteMax.Text = "";
                if (!esisteConf) {
                    show(this, "Le informazioni relative agli attributi " +
                        "di classificazione delle spese sono incomplete o mancanti.",
                        "Avviso");
                }
                return;
            }
            txtLimiteMax.Text = CfgFn.GetNoNullDecimal(AttribRow["limit"]).ToString();
        }

        void AggiornaPerc(DataRow R) {
            if (R == null) {
                ClearPerc();
                return;
            }

            bool esisteConf;
            if (IsRimborsoForfettario() && rdoItaly.Checked){
                ClearPerc();
                return;
            }
            DataRow AttribRow = ottieniRigaRegolamentoSpesa(out esisteConf);

            if (AttribRow == null) {
                ClearPerc();
                if (!esisteConf) {
                    show(this, "Le informazioni relative agli attributi " +
                        "di classificazione delle spese sono incomplete o mancanti.",
                        "Avviso");
                }
                return;
            }

            DataRow Curr = DS.itinerationrefund.Rows[0];
            Curr["advancepercentage"] = CfgFn.GetNoNullDouble(AttribRow["advancepercentage"]);
            txtPercAnticipoItaliaEstero.Text = HelpForm.StringValue(
                Curr["advancepercentage"], txtPercAnticipoItaliaEstero.Tag.ToString());
        }

        private DataRow ottieniRigaRegolamentoSpesa(out bool esisteConf) {
            esisteConf = true;
            
            DataRow Curr = DS.itinerationrefund.Rows[0];
            object dataInizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
            object dataFine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());

            int nOre = calcolaOre(dataInizio, dataFine);

            if (nOre == -1) {
                return null;
            }

            string fSuApplicazioneGeo = calcolaFiltroApplicazioneGeo();
            if (fSuApplicazioneGeo == "") {
                return null;
            }

            string f = QHC.CmpEq("iditinerationrefundkind", Curr["iditinerationrefundkind"]);
            DataRow[] RefundKind = DS.itinerationrefundkind.Select(f);
            if (RefundKind.Length == 0) {
                return null;
            }

            DataTable tRule = DataAccess.CreateTableByName(Meta.Conn, "itinerationrefundrule", "*");
            string fRule = QHS.CmpLe("start", dataInizio);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tRule, "start desc", fRule, null, true);
            if (tRule.Rows.Count == 0) {
                return null;
            }

            DataRow rRule = tRule.Rows[0];
            string fRuleDetail = QueryCreator.WHERE_KEY_CLAUSE(rRule, DataRowVersion.Current, false);
            string fPos = MissFun.GetQualificaClasseFilter(Cfg.idposition, Cfg.incomeclass);
            fRuleDetail = GetData.MergeFilters(fRuleDetail, fPos);

            DataRow rRefundKind = RefundKind[0];
            string fRefundKind = QHS.CmpEq("iditinerationrefundkindgroup", rRefundKind["iditinerationrefundkindgroup"]);
            fRuleDetail = GetData.MergeFilters(fRuleDetail, fRefundKind);

            string fHour = QHS.AppAnd(QHS.NullOrLt("nhour_min", nOre), QHS.NullOrGt("nhour_max", nOre));
            fRuleDetail = GetData.MergeFilters(fRuleDetail, fHour);
            fRuleDetail = GetData.MergeFilters(fRuleDetail, fSuApplicazioneGeo);

            DataTable tRuleDetail = DataAccess.CreateTableByName(Meta.Conn, "itinerationrefundruledetail", "*");

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tRuleDetail, "iddetail",
                fRuleDetail, null, false);

            if (tRuleDetail.Rows.Count == 0) {
                esisteConf = false;
                return null;
            }
            return tRuleDetail.Rows[0];
        }

        void AggiornaValuta(DataRow ValutaRow) {
			if (ValutaRow==null) {
				txtCambio.Text= "";
				txtCambio.ReadOnly=false;
				return;
			}
			double xx = 1;
			txtCambio.Text= HelpForm.StringValue(xx, txtCambio.Tag.ToString());

		}

		bool inConverti=false;

		void ConvertiIntoValuta(TextBox Eur, TextBox Val) {
			if (inConverti) return;
			inConverti=true;
			object Ocambio = HelpForm.GetObjectFromString(typeof(double),
				txtCambio.Text, txtCambio.Tag.ToString());
			if ((Ocambio==null)||(Ocambio==DBNull.Value)) {
				Val.Text="";
				inConverti=false;
				return;
			}
			double cambio = CfgFn.GetNoNullDouble(Ocambio);
			object  eur = HelpForm.GetObjectFromString(typeof(decimal), 
				Eur.Text, Eur.Tag.ToString());
			if ((eur==null) ||(eur==DBNull.Value)) {
				Val.Text="";
			}
			else {
				if (cambio==0){
					Val.Text="";
				}
				else {
					double x = Convert.ToDouble(eur)/cambio;
					x = CfgFn.RoundValuta(x);
					Val.Text= HelpForm.StringValue(x,"x.y.fixed.8...1");
				}
			}
			inConverti=false;
		}
		

		void ConvertiFromValuta(TextBox Eur, TextBox Val) {
			if (inConverti) return;
			inConverti=true;
			object Ocambio = HelpForm.GetObjectFromString(typeof(double),
				txtCambio.Text, txtCambio.Tag.ToString());
			if ((Ocambio==null)||(Ocambio==DBNull.Value)) {
				Eur.Text="";
				inConverti=false;
				return;
			}
			double cambio = CfgFn.GetNoNullDouble(Ocambio);
			object  x = HelpForm.GetObjectFromString(typeof(double),
                Val.Text, "x.y.fixed.8...1");
			if ((x==null) ||(x==DBNull.Value)) {
				Eur.Text="";
			}
			else {
				decimal eur = Convert.ToDecimal(Convert.ToDouble(x)*cambio);
				eur= CfgFn.RoundValuta(eur);
				Eur.Text= eur.ToString("c");
			}
			inConverti=false;
		}

		bool CalculatingAnticipo=false;

		void RicalcolaAnticipo() {
            if (Meta.edit_type == "balance") {
                ClearPerc();
                return;
            }
			if (CalculatingAnticipo) return;
			CalculatingAnticipo = true;
			Meta.GetFormData(true);
			DataRow Curr = DS.itinerationrefund.Rows[0];
			decimal anticipo = MissFun.GetAnticipoSpesa(Curr);
			txtAnticipo.Text= anticipo.ToString("c");
			CalculatingAnticipo=false;
		}

		decimal RicalcolaPercentualeAnticipo() {
			if (CalculatingAnticipo) return 0;
			CalculatingAnticipo=true;
			Meta.GetFormData(true);
			object vanticipo = HelpForm.GetObjectFromString(typeof(decimal), 
				txtAnticipo.Text, "x.y.c");
			DataRow Curr = DS.itinerationrefund.Rows[0];
			decimal importo= MissFun.GetBasePerAnticipoSpesa(Curr);
			decimal anticipo = CfgFn.GetNoNullDecimal(vanticipo);
            if (anticipo == 0) return 0;
			decimal percanticipo = importo/anticipo;
			txtPercAnticipoItaliaEstero.Text= HelpForm.StringValue(percanticipo,
				txtPercAnticipoItaliaEstero.Tag.ToString());

			CalculatingAnticipo=false;
            return percanticipo;
		}

        TextBox GetTxtByName (string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return null;
            TextBox T = (TextBox)Ctrl.GetValue(this);
            return T;
        }

		private void txtImportoValuta_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
            TextBox T = (TextBox)sender;
            string prefix = T.Name.Substring(0, T.Name.Length - 6);
            TextBox T1 = GetTxtByName(prefix + "EUR");
			ConvertiFromValuta(T1, T);
            RicalcolaAnticipo();
            if (do_checklimite) CheckLimiteAnticipo();
		}

		private void txtImportoEffettivoEUR_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone)return;
			RicalcolaAnticipo();
		}

		private void txtPercAnticipoItaliaEstero_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return; 
			RicalcolaAnticipo();
		}

		private void txtImportoValuta_Enter(object sender, System.EventArgs e) {
            TextBox T = (TextBox)sender;
            HelpForm.ExtEnterNumTextBox(T, "x.y.fixed.8...1");		
		}

		private void txtImportoValuta_Leave(object sender, System.EventArgs e) {
            TextBox T = (TextBox)sender;
            HelpForm.ExtLeaveNumTextBox(T, "x.y.fixed.8...1");
		}

        private void txtDataInizio_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            if (DS.itinerationrefund.Rows.Count == 0) return;
            object d = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
            if (d == null) return;
            DataRow Curr = DS.itinerationrefund.Rows[0];
            AggiornaPerc(Curr);
            AggiornaLimite(Curr);
        }

        private void txtDataFine_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            if (DS.itinerationrefund.Rows.Count == 0) return;
            object d = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
            if (d == null) return;
            DataRow Curr = DS.itinerationrefund.Rows[0];
            AggiornaPerc(Curr);
            AggiornaLimite(Curr);
        }

        private void rdoItaly_CheckedChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            if (DS.itinerationrefund.Rows.Count == 0) return;
            DataRow Curr = DS.itinerationrefund.Rows[0];
            AggiornaPerc(Curr);
            AggiornaLimite(Curr);
        }

        private void rdoUe_CheckedChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            if (DS.itinerationrefund.Rows.Count == 0) return;
            DataRow Curr = DS.itinerationrefund.Rows[0];
            AggiornaPerc(Curr);
            AggiornaLimite(Curr);
            AbilitadisabilitaArea(Curr);
        }

        private void rdoExtraUe_CheckedChanged(object sender, EventArgs e) {
            if (inChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            if (DS.itinerationrefund.Rows.Count == 0) return;
            DataRow Curr = DS.itinerationrefund.Rows[0];
            AggiornaPerc(Curr);
            AggiornaLimite(Curr);
            AbilitadisabilitaArea(Curr);
        }

        private void txtCambio_TextChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            ConvertiFromValuta(txtImportoRichiestoEUR, txtImportoRichiestoValuta);
            ConvertiFromValuta(txtImportoEffettivoEUR, txtImportoEffettivoValuta);
            ConvertiFromValuta(txtImportoDocEUR, txtImportoDocValuta);
        }

        private void txtPercAnticipoItaliaEstero_Leave(object sender, EventArgs e) {
            if (Meta.formController.isClosing) return;
            if (!CheckLimiteAnticipo()) DialogResult = DialogResult.None;

        }

        private void txtDataInizio_Leave_1(object sender, EventArgs e) {
            AggiornaRimborsoForfettario();

        }

        private void txtDataFine_Leave_1(object sender, EventArgs e) {
            AggiornaRimborsoForfettario();

        }
	}
}
