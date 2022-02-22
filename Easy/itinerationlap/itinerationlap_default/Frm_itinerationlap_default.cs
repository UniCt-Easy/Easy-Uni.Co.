
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
using metaeasylibrary;
using funzioni_configurazione;//funzioni_configurazione
using itinerationFunctions;//FunzioniMissione

namespace itinerationlap_default{//missionetappa//
	/// <summary>
	/// Summary description for frmmissionetappa.
	/// </summary>
	public class Frm_itinerationlap_default : MetaDataForm {
		#region dich. controlli

		private System.Windows.Forms.TextBox txtDataOraInizio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDataOraTermine;
		private System.Windows.Forms.Button btnLocalita;
		private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnAnnulla;
		public /*Rana:missionetappa.*/vistaForm DS;
        private System.Windows.Forms.ComboBox cmbLocalita;
		private System.Windows.Forms.TextBox txtGiorni;
        private System.Windows.Forms.TextBox txtOre;
		private System.Windows.Forms.TextBox txtIndennCorrispEUR;
		private System.Windows.Forms.TextBox txtIndennTotEUR;
		#endregion
		private System.ComponentModel.IContainer components;

		MetaData Meta;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtFrazioneGiorni;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtQuotaEsenteTappa;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtQuotaImponibileTappa;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ToolTip myTip;
		private System.Windows.Forms.TextBox txtHelpAnticipo;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtIndennLorda;
		private System.Windows.Forms.TextBox txtHelpIndennLorda;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txtQuotaEsenteGiornaliera;
		private System.Windows.Forms.TextBox txtHelpQuotaEsenteGiornaliera;
		private System.Windows.Forms.TextBox txtHelpIndennitaTotale;
		private System.Windows.Forms.TextBox txtHelpQuotaEsenteTappa;
		private System.Windows.Forms.TextBox txtHelpQuotaImponibile;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbTipoRiduzione;
		private System.Windows.Forms.Button btnTipoRiduzione;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPercRidDiaria;
		private System.Windows.Forms.CheckBox chkitaliaestero;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtAnticipo;
		private System.Windows.Forms.TextBox txtPercAnticipo;
        private Label label3;
        private TextBox txtIndennEUR;
        private TextBox txtmaxPerc;
        private Label label7;
        private Label label8;
		DataRow ParentMissione;

		public Frm_itinerationlap_default() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
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
            this.txtDataOraInizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataOraTermine = new System.Windows.Forms.TextBox();
            this.btnLocalita = new System.Windows.Forms.Button();
            this.cmbLocalita = new System.Windows.Forms.ComboBox();
            this.DS = new itinerationlap_default.vistaForm();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGiorni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIndennCorrispEUR = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIndennTotEUR = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.txtHelpIndennitaTotale = new System.Windows.Forms.TextBox();
            this.txtHelpAnticipo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFrazioneGiorni = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtQuotaEsenteTappa = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtQuotaImponibileTappa = new System.Windows.Forms.TextBox();
            this.txtHelpQuotaEsenteTappa = new System.Windows.Forms.TextBox();
            this.txtHelpQuotaImponibile = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtmaxPerc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIndennEUR = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAnticipo = new System.Windows.Forms.TextBox();
            this.txtPercAnticipo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkitaliaestero = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoRiduzione = new System.Windows.Forms.ComboBox();
            this.btnTipoRiduzione = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPercRidDiaria = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtHelpQuotaEsenteGiornaliera = new System.Windows.Forms.TextBox();
            this.txtQuotaEsenteGiornaliera = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtHelpIndennLorda = new System.Windows.Forms.TextBox();
            this.txtIndennLorda = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.myTip = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDataOraInizio
            // 
            this.txtDataOraInizio.Location = new System.Drawing.Point(120, 59);
            this.txtDataOraInizio.Name = "txtDataOraInizio";
            this.txtDataOraInizio.Size = new System.Drawing.Size(160, 20);
            this.txtDataOraInizio.TabIndex = 1;
            this.txtDataOraInizio.Tag = "itinerationlap.starttime.g";
            this.txtDataOraInizio.TextChanged += new System.EventHandler(this.txtDataOraInizio_TextChanged);
            this.txtDataOraInizio.Leave += new System.EventHandler(this.txtDataOraInizio_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data/ora inizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data/ora termine:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataOraTermine
            // 
            this.txtDataOraTermine.Location = new System.Drawing.Point(120, 91);
            this.txtDataOraTermine.Name = "txtDataOraTermine";
            this.txtDataOraTermine.Size = new System.Drawing.Size(160, 20);
            this.txtDataOraTermine.TabIndex = 4;
            this.txtDataOraTermine.Tag = "itinerationlap.stoptime.g";
            this.txtDataOraTermine.TextChanged += new System.EventHandler(this.txtDataOraTermine_TextChanged);
            // 
            // btnLocalita
            // 
            this.btnLocalita.Location = new System.Drawing.Point(160, 195);
            this.btnLocalita.Name = "btnLocalita";
            this.btnLocalita.Size = new System.Drawing.Size(88, 23);
            this.btnLocalita.TabIndex = 7;
            this.btnLocalita.TabStop = false;
            this.btnLocalita.Tag = "manage.foreigncountry.default";
            this.btnLocalita.Text = "Località Estera:";
            this.btnLocalita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbLocalita
            // 
            this.cmbLocalita.DataSource = this.DS.foreigncountry;
            this.cmbLocalita.DisplayMember = "description";
            this.cmbLocalita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalita.Location = new System.Drawing.Point(264, 195);
            this.cmbLocalita.Name = "cmbLocalita";
            this.cmbLocalita.Size = new System.Drawing.Size(320, 21);
            this.cmbLocalita.TabIndex = 8;
            this.cmbLocalita.Tag = "itinerationlap.idforeigncountry";
            this.cmbLocalita.ValueMember = "idforeigncountry";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(152, 131);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(432, 48);
            this.txtDescrizione.TabIndex = 5;
            this.txtDescrizione.Tag = "itinerationlap.description";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Descrizione:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(288, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Giorni:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGiorni
            // 
            this.txtGiorni.Location = new System.Drawing.Point(344, 59);
            this.txtGiorni.Name = "txtGiorni";
            this.txtGiorni.Size = new System.Drawing.Size(88, 20);
            this.txtGiorni.TabIndex = 2;
            this.txtGiorni.Tag = "itinerationlap.days";
            this.txtGiorni.TextChanged += new System.EventHandler(this.txtGiorni_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(440, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 23;
            this.label6.Text = "Ore:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOre
            // 
            this.txtOre.Location = new System.Drawing.Point(496, 59);
            this.txtOre.Name = "txtOre";
            this.txtOre.Size = new System.Drawing.Size(88, 20);
            this.txtOre.TabIndex = 3;
            this.txtOre.Tag = "itinerationlap.hours";
            this.txtOre.TextChanged += new System.EventHandler(this.txtOre_TextChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(59, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 21);
            this.label10.TabIndex = 29;
            this.label10.Text = "Indenn. giornaliera corrisposta Euro:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIndennCorrispEUR
            // 
            this.txtIndennCorrispEUR.Location = new System.Drawing.Point(217, 267);
            this.txtIndennCorrispEUR.Name = "txtIndennCorrispEUR";
            this.txtIndennCorrispEUR.Size = new System.Drawing.Size(96, 20);
            this.txtIndennCorrispEUR.TabIndex = 12;
            this.txtIndennCorrispEUR.Tag = "itinerationlap.allowance.c";
            this.txtIndennCorrispEUR.TextChanged += new System.EventHandler(this.txtIndennCorrispEUR_TextChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(16, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 23);
            this.label12.TabIndex = 33;
            this.label12.Text = "Indennità totale Euro:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIndennTotEUR
            // 
            this.txtIndennTotEUR.Location = new System.Drawing.Point(168, 12);
            this.txtIndennTotEUR.Name = "txtIndennTotEUR";
            this.txtIndennTotEUR.ReadOnly = true;
            this.txtIndennTotEUR.Size = new System.Drawing.Size(96, 20);
            this.txtIndennTotEUR.TabIndex = 32;
            this.txtIndennTotEUR.TabStop = false;
            this.txtIndennTotEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndennTotEUR.TextChanged += new System.EventHandler(this.txtIndennTotEUR_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(384, 509);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 44;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(216, 509);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 45;
            this.btnAnnulla.Text = "Annulla";
            // 
            // txtHelpIndennitaTotale
            // 
            this.txtHelpIndennitaTotale.Location = new System.Drawing.Point(280, 12);
            this.txtHelpIndennitaTotale.Multiline = true;
            this.txtHelpIndennitaTotale.Name = "txtHelpIndennitaTotale";
            this.txtHelpIndennitaTotale.ReadOnly = true;
            this.txtHelpIndennitaTotale.Size = new System.Drawing.Size(312, 48);
            this.txtHelpIndennitaTotale.TabIndex = 46;
            this.txtHelpIndennitaTotale.TabStop = false;
            this.txtHelpIndennitaTotale.Text = "L\'indennità totale è data dal prodotto dell\'indennità giornaliera corrisposta * (" +
                "n. giorni frazionario) * (1-percentuale riduzione diaria)";
            // 
            // txtHelpAnticipo
            // 
            this.txtHelpAnticipo.Location = new System.Drawing.Point(296, 379);
            this.txtHelpAnticipo.Multiline = true;
            this.txtHelpAnticipo.Name = "txtHelpAnticipo";
            this.txtHelpAnticipo.ReadOnly = true;
            this.txtHelpAnticipo.Size = new System.Drawing.Size(312, 80);
            this.txtHelpAnticipo.TabIndex = 47;
            this.txtHelpAnticipo.TabStop = false;
            this.txtHelpAnticipo.Text = "L\'anticipo è calcolato come il prodotto dell\'indennità corrisposta *(1-percentual" +
                "e riduzione diaria) * n. giorni frazionario * percentuale anticipo";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(328, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 16);
            this.label11.TabIndex = 48;
            this.label11.Text = "N. giorni frazionario";
            // 
            // txtFrazioneGiorni
            // 
            this.txtFrazioneGiorni.Location = new System.Drawing.Point(448, 91);
            this.txtFrazioneGiorni.Name = "txtFrazioneGiorni";
            this.txtFrazioneGiorni.ReadOnly = true;
            this.txtFrazioneGiorni.Size = new System.Drawing.Size(136, 20);
            this.txtFrazioneGiorni.TabIndex = 49;
            this.txtFrazioneGiorni.TabStop = false;
            this.txtFrazioneGiorni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(24, 124);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 23);
            this.label17.TabIndex = 50;
            this.label17.Text = "Quota esente tappa";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuotaEsenteTappa
            // 
            this.txtQuotaEsenteTappa.Location = new System.Drawing.Point(168, 124);
            this.txtQuotaEsenteTappa.Name = "txtQuotaEsenteTappa";
            this.txtQuotaEsenteTappa.ReadOnly = true;
            this.txtQuotaEsenteTappa.Size = new System.Drawing.Size(96, 20);
            this.txtQuotaEsenteTappa.TabIndex = 51;
            this.txtQuotaEsenteTappa.TabStop = false;
            this.txtQuotaEsenteTappa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuotaEsenteTappa.TextChanged += new System.EventHandler(this.txtQuotaEsenteGiornaliera_TextChanged);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(16, 172);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(144, 23);
            this.label18.TabIndex = 52;
            this.label18.Text = "Quota imponibile tappa";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuotaImponibileTappa
            // 
            this.txtQuotaImponibileTappa.Location = new System.Drawing.Point(168, 172);
            this.txtQuotaImponibileTappa.Name = "txtQuotaImponibileTappa";
            this.txtQuotaImponibileTappa.ReadOnly = true;
            this.txtQuotaImponibileTappa.Size = new System.Drawing.Size(96, 20);
            this.txtQuotaImponibileTappa.TabIndex = 53;
            this.txtQuotaImponibileTappa.TabStop = false;
            this.txtQuotaImponibileTappa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuotaImponibileTappa.TextChanged += new System.EventHandler(this.txtQuotaEsenteGiornaliera_TextChanged);
            // 
            // txtHelpQuotaEsenteTappa
            // 
            this.txtHelpQuotaEsenteTappa.Location = new System.Drawing.Point(280, 124);
            this.txtHelpQuotaEsenteTappa.Multiline = true;
            this.txtHelpQuotaEsenteTappa.Name = "txtHelpQuotaEsenteTappa";
            this.txtHelpQuotaEsenteTappa.ReadOnly = true;
            this.txtHelpQuotaEsenteTappa.Size = new System.Drawing.Size(312, 32);
            this.txtHelpQuotaEsenteTappa.TabIndex = 54;
            this.txtHelpQuotaEsenteTappa.TabStop = false;
            this.txtHelpQuotaEsenteTappa.Text = "= Quota Esente giornaliera * (1-perc.riduzione quota esente) * n.giorni frazionar" +
                "io";
            // 
            // txtHelpQuotaImponibile
            // 
            this.txtHelpQuotaImponibile.Location = new System.Drawing.Point(280, 172);
            this.txtHelpQuotaImponibile.Multiline = true;
            this.txtHelpQuotaImponibile.Name = "txtHelpQuotaImponibile";
            this.txtHelpQuotaImponibile.ReadOnly = true;
            this.txtHelpQuotaImponibile.Size = new System.Drawing.Size(312, 20);
            this.txtHelpQuotaImponibile.TabIndex = 55;
            this.txtHelpQuotaImponibile.TabStop = false;
            this.txtHelpQuotaImponibile.Text = "= (Ind. totale Euro - Quota Esente Tappa)* Coeff. di lordizzazione";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 495);
            this.tabControl1.TabIndex = 56;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtmaxPerc);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtIndennEUR);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.chkitaliaestero);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtFrazioneGiorni);
            this.tabPage1.Controls.Add(this.txtDataOraInizio);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtDataOraTermine);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtGiorni);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtOre);
            this.tabPage1.Controls.Add(this.txtDescrizione);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnLocalita);
            this.tabPage1.Controls.Add(this.cmbLocalita);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtIndennCorrispEUR);
            this.tabPage1.Controls.Add(this.txtHelpAnticipo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(624, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            // 
            // txtmaxPerc
            // 
            this.txtmaxPerc.Location = new System.Drawing.Point(443, 238);
            this.txtmaxPerc.Name = "txtmaxPerc";
            this.txtmaxPerc.ReadOnly = true;
            this.txtmaxPerc.Size = new System.Drawing.Size(96, 20);
            this.txtmaxPerc.TabIndex = 56;
            this.txtmaxPerc.TabStop = false;
            this.txtmaxPerc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(319, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 28);
            this.label7.TabIndex = 55;
            this.label7.Text = "Percentuale anticipo Concedibile:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 28);
            this.label3.TabIndex = 54;
            this.label3.Text = "Massima indennità giornaliera Concedibile: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIndennEUR
            // 
            this.txtIndennEUR.Location = new System.Drawing.Point(217, 238);
            this.txtIndennEUR.Name = "txtIndennEUR";
            this.txtIndennEUR.ReadOnly = true;
            this.txtIndennEUR.Size = new System.Drawing.Size(96, 20);
            this.txtIndennEUR.TabIndex = 53;
            this.txtIndennEUR.TabStop = false;
            this.txtIndennEUR.Tag = "";
            this.txtIndennEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAnticipo);
            this.groupBox2.Controls.Add(this.txtPercAnticipo);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(40, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 88);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Anticipo";
            // 
            // txtAnticipo
            // 
            this.txtAnticipo.Location = new System.Drawing.Point(136, 48);
            this.txtAnticipo.Name = "txtAnticipo";
            this.txtAnticipo.Size = new System.Drawing.Size(96, 20);
            this.txtAnticipo.TabIndex = 19;
            this.txtAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAnticipo.TextChanged += new System.EventHandler(this.txtAnticipo_TextChanged);
            this.txtAnticipo.Leave += new System.EventHandler(this.txtAnticipo_Leave);
            this.txtAnticipo.Enter += new System.EventHandler(this.txtAnticipo_Enter);
            // 
            // txtPercAnticipo
            // 
            this.txtPercAnticipo.Location = new System.Drawing.Point(136, 16);
            this.txtPercAnticipo.Name = "txtPercAnticipo";
            this.txtPercAnticipo.Size = new System.Drawing.Size(96, 20);
            this.txtPercAnticipo.TabIndex = 18;
            this.txtPercAnticipo.Tag = "itinerationlap.advancepercentage.fixed.5..%.100";
            this.txtPercAnticipo.TextChanged += new System.EventHandler(this.txtPercAnticipo_TextChanged);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(48, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 23);
            this.label16.TabIndex = 42;
            this.label16.Text = "Percentuale:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(64, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 23);
            this.label14.TabIndex = 38;
            this.label14.Text = "Importo:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkitaliaestero
            // 
            this.chkitaliaestero.Location = new System.Drawing.Point(48, 202);
            this.chkitaliaestero.Name = "chkitaliaestero";
            this.chkitaliaestero.Size = new System.Drawing.Size(72, 16);
            this.chkitaliaestero.TabIndex = 51;
            this.chkitaliaestero.TabStop = false;
            this.chkitaliaestero.Tag = "itinerationlap.flagitalian:S:N";
            this.chkitaliaestero.Text = "Italia";
            this.chkitaliaestero.CheckedChanged += new System.EventHandler(this.chkitaliaestero_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoRiduzione);
            this.groupBox1.Controls.Add(this.btnTipoRiduzione);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtPercRidDiaria);
            this.groupBox1.Location = new System.Drawing.Point(40, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 80);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Riduzione";
            // 
            // cmbTipoRiduzione
            // 
            this.cmbTipoRiduzione.DataSource = this.DS.reduction;
            this.cmbTipoRiduzione.DisplayMember = "description";
            this.cmbTipoRiduzione.Location = new System.Drawing.Point(8, 48);
            this.cmbTipoRiduzione.Name = "cmbTipoRiduzione";
            this.cmbTipoRiduzione.Size = new System.Drawing.Size(288, 21);
            this.cmbTipoRiduzione.TabIndex = 45;
            this.cmbTipoRiduzione.Tag = "itinerationlap.idreduction";
            this.cmbTipoRiduzione.ValueMember = "idreduction";
            // 
            // btnTipoRiduzione
            // 
            this.btnTipoRiduzione.Location = new System.Drawing.Point(8, 16);
            this.btnTipoRiduzione.Name = "btnTipoRiduzione";
            this.btnTipoRiduzione.Size = new System.Drawing.Size(104, 24);
            this.btnTipoRiduzione.TabIndex = 44;
            this.btnTipoRiduzione.TabStop = false;
            this.btnTipoRiduzione.Tag = "manage.reduction.default";
            this.btnTipoRiduzione.Text = "Tipo:";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(330, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 23);
            this.label13.TabIndex = 48;
            this.label13.Text = "Percentuale  riduzione";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPercRidDiaria
            // 
            this.txtPercRidDiaria.Location = new System.Drawing.Point(456, 48);
            this.txtPercRidDiaria.Name = "txtPercRidDiaria";
            this.txtPercRidDiaria.Size = new System.Drawing.Size(106, 20);
            this.txtPercRidDiaria.TabIndex = 46;
            this.txtPercRidDiaria.Tag = "itinerationlap.reductionpercentage.fixed.5..%.100";
            this.txtPercRidDiaria.TextChanged += new System.EventHandler(this.txtPercRidDiaria_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtHelpQuotaEsenteGiornaliera);
            this.tabPage2.Controls.Add(this.txtQuotaEsenteGiornaliera);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.txtHelpIndennLorda);
            this.tabPage2.Controls.Add(this.txtIndennLorda);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.txtHelpIndennitaTotale);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.txtQuotaEsenteTappa);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.txtQuotaImponibileTappa);
            this.tabPage2.Controls.Add(this.txtHelpQuotaEsenteTappa);
            this.tabPage2.Controls.Add(this.txtHelpQuotaImponibile);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtIndennTotEUR);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(624, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Totali";
            // 
            // txtHelpQuotaEsenteGiornaliera
            // 
            this.txtHelpQuotaEsenteGiornaliera.Location = new System.Drawing.Point(280, 76);
            this.txtHelpQuotaEsenteGiornaliera.Name = "txtHelpQuotaEsenteGiornaliera";
            this.txtHelpQuotaEsenteGiornaliera.ReadOnly = true;
            this.txtHelpQuotaEsenteGiornaliera.Size = new System.Drawing.Size(312, 20);
            this.txtHelpQuotaEsenteGiornaliera.TabIndex = 61;
            this.txtHelpQuotaEsenteGiornaliera.TabStop = false;
            this.txtHelpQuotaEsenteGiornaliera.Text = "Quota esente giornaliera predefinita";
            // 
            // txtQuotaEsenteGiornaliera
            // 
            this.txtQuotaEsenteGiornaliera.Location = new System.Drawing.Point(168, 76);
            this.txtQuotaEsenteGiornaliera.Name = "txtQuotaEsenteGiornaliera";
            this.txtQuotaEsenteGiornaliera.ReadOnly = true;
            this.txtQuotaEsenteGiornaliera.Size = new System.Drawing.Size(100, 20);
            this.txtQuotaEsenteGiornaliera.TabIndex = 60;
            this.txtQuotaEsenteGiornaliera.TabStop = false;
            this.txtQuotaEsenteGiornaliera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuotaEsenteGiornaliera.TextChanged += new System.EventHandler(this.txtQuotaEsenteGiornaliera_TextChanged);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(32, 76);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(128, 23);
            this.label20.TabIndex = 59;
            this.label20.Text = "Quota esente giornaliera";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHelpIndennLorda
            // 
            this.txtHelpIndennLorda.Location = new System.Drawing.Point(280, 212);
            this.txtHelpIndennLorda.Multiline = true;
            this.txtHelpIndennLorda.Name = "txtHelpIndennLorda";
            this.txtHelpIndennLorda.ReadOnly = true;
            this.txtHelpIndennLorda.Size = new System.Drawing.Size(312, 48);
            this.txtHelpIndennLorda.TabIndex = 58;
            this.txtHelpIndennLorda.TabStop = false;
            this.txtHelpIndennLorda.Text = "Se l\' Indennità totale è maggiore di Quota esente, allora l\'Indennità lorda è ugu" +
                "ale a Quota imponibile+Quota esente, altrimenti l\'Indennità lorda è uguale a Ind" +
                "ennità Totale ";
            // 
            // txtIndennLorda
            // 
            this.txtIndennLorda.Location = new System.Drawing.Point(168, 212);
            this.txtIndennLorda.Name = "txtIndennLorda";
            this.txtIndennLorda.ReadOnly = true;
            this.txtIndennLorda.Size = new System.Drawing.Size(96, 20);
            this.txtIndennLorda.TabIndex = 57;
            this.txtIndennLorda.TabStop = false;
            this.txtIndennLorda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(64, 212);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 23);
            this.label19.TabIndex = 56;
            this.label19.Text = "Indennità lorda";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // myTip
            // 
            this.myTip.AutomaticDelay = 30;
            this.myTip.AutoPopDelay = 30000;
            this.myTip.InitialDelay = 30;
            this.myTip.ReshowDelay = 6;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(589, 29);
            this.label8.TabIndex = 57;
            this.label8.Text = "Attenzione: per assicurare un corretto calcolo dell\'indennità da corrispondere, è" +
                " importante verificare il numero dei giorni e delle ore relativi alla tappa, all" +
                "a luce del regolamento delle missioni.";
            // 
            // Frm_itinerationlap_default
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(666, 544);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_itinerationlap_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmmissionetappa";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        CfgItineration Cfg;
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			ParentMissione = Meta.SourceRow.GetParentRow("itinerationitinerationlap");

            Cfg = (CfgItineration) Meta.ExtraParameter ;
		}



		public void MetaData_AfterFill(){
//			if (filter==null){
//				show("I dati inseriti nella scheda Generalità sono incompleti o mancanti");
//				DialogResult = DialogResult.Cancel;
//				return;
//			}	
            if (Meta.FirstFillForThisRow) {
                if (chkitaliaestero.Checked) {
                    AggiornaInfoItalia();
                }
                else {
                    AggiornaSoloInfoEstero();
                }
            }
			//In questa sezione sono riempiti TextBox SENZA TAG, ossia che non influenzano il DataSet
			ImpostaItaliaEstero(true);

			if (Meta.InsertMode){
				DataRow Curr = DS.itinerationlap.Rows[0];
				if ((Curr["reductionpercentage"]==DBNull.Value)){
					AggiornaTipoRiduzione();
					ImpostaItaliaEstero(false);
				}
				else {
					ImpostaItaliaEstero(true);
				}
			}

			RicalcolaNGiorniFrazionario();
			RicalcolaIndennitaTotale();
			RicalcolaAnticipo();
			RicalcolaIndennitaLorda();
		}

		decimal GetQuotaEsenteTappa(){
			if (Meta.IsEmpty) return 0;
			Meta.GetFormData(true);
			DataRow Missione = Meta.SourceRow.GetParentRow("itinerationitinerationlap");
			return MissFun.QuotaEsenteTappa(Missione, DS.itinerationlap.Rows[0],Cfg);
		}

		void RicalcolaQuotaEsenteTappa(){
			txtQuotaEsenteTappa.Text = GetQuotaEsenteTappa().ToString("c");
			double perc = CfgFn.GetNoNullDouble(
				HelpForm.GetObjectFromString(
				typeof(double),txtPercRidDiaria.Text,
                txtPercRidDiaria.Tag.ToString()));

			string Help= txtQuotaEsenteGiornaliera.Text+"*"+
				"(1-"+perc.ToString("n")+")*"+txtFrazioneGiorni.Text;
			SetToolTip(txtHelpQuotaEsenteTappa, Help);


		}

		void RicalcolaQuotaImponibileTappa(){
			if (Meta.IsEmpty) return;
			DataRow Tappa = DS.itinerationlap.Rows[0];
			DataRow Missione = Meta.SourceRow.GetParentRow("itinerationitinerationlap");
			decimal Imponibile = MissFun.ImponibileTappa(Missione,Tappa, Cfg);
			txtQuotaImponibileTappa.Text = Imponibile.ToString("c");
			double CoeffLord = CfgFn.GetNoNullDouble(Missione["grossfactor"]);
			string Help= "("+txtIndennTotEUR.Text+"-"+
					txtQuotaEsenteTappa.Text+")*"+
				    CoeffLord.ToString("n");
			SetToolTip(txtHelpQuotaImponibile, Help);
		}

		public void MetaData_AfterActivation(){
			//if (filter==null)return;

			AbilitaDisabilitaTipoRiduzione();
			DataRow Curr = DS.itinerationlap.Rows[0];
			if (ParentMissione.RowState!=DataRowState.Added){
                string filter = QHS.AppAnd(QHS.MCmp(Curr, "iditineration"),
                    QHS.CmpNe("movkind", 4));
				int N= Meta.Conn.RUN_SELECT_COUNT("expenseitineration",filter,false);

                filter = QHS.MCmp(Curr, "iditineration");
				N += Meta.Conn.RUN_SELECT_COUNT("pettycashoperationitineration",filter,false);
				if (N>0) show(
							 "Avendo già contabilizzato l'anticipo di questa missione, le modifiche alla tappa "+
							 "non saranno tenute in considerazione ai fini del calcolo dell'anticipo della missione.","Avviso");
			}

		}
		
		

		bool CalculatingAnticipo=false;
		void RicalcolaAnticipo(){
			//Anticipo = percAnticipo * importotot * 
			if (CalculatingAnticipo) return;
			CalculatingAnticipo = true;
			Meta.GetFormData(true);
			DataRow Curr = DS.itinerationlap.Rows[0];
			decimal anticipo = MissFun.GetAnticipo(Curr);
			txtAnticipo.Text= anticipo.ToString("c");
			string ToolTip= txtIndennCorrispEUR.Text+"*"+txtFrazioneGiorni.Text+"*"+
				txtPercAnticipo.Text;
            ToolTip += "*(1-" + txtPercRidDiaria.Text + ")";
			SetToolTip(txtHelpAnticipo, ToolTip);

			CalculatingAnticipo=false;
		}

		void RicalcolaPercentualeAnticipo(){
			if (CalculatingAnticipo) return;
			CalculatingAnticipo=true;
			object vanticipo = HelpForm.GetObjectFromString(typeof(decimal), 
				txtAnticipo.Text, "x.y.c");
			decimal anticipo = CfgFn.GetNoNullDecimal(vanticipo);
			DataRow Curr = DS.itinerationlap.Rows[0];
			double BasePerAnticipo = MissFun.GetBasePerAnticipo(Curr);
			if ((BasePerAnticipo==0)||(anticipo==0)) {
				CalculatingAnticipo=false;
				return;
			}


			double percanticipo = Convert.ToDouble(anticipo)/BasePerAnticipo;
			txtPercAnticipo.Text= HelpForm.StringValue(percanticipo,
					txtPercAnticipo.Tag.ToString());

			CalculatingAnticipo=false;
		}

		
		
		#region Gestione Calcolo Indennità di trasferta
		

        //string lastfilteritalia=null;

        void AggiornaInfoItalia() {
            decimal indennitaEUR;
            if (DS.itinerationlap.Rows.Count == 0) return;
            DataRow Curr = DS.itinerationlap.Rows[0];

            object datarif = Curr["starttime"];
            if (datarif == DBNull.Value) return;
            
            string filterstart = QHS.CmpLe("start", datarif);
            object idallowancerule = Meta.Conn.DO_READ_VALUE("allowancerule", filterstart,
                          "max(idallowancerule)");

            string filter = MissFun.GetQualificaClasseFilter(Cfg.idposition, Cfg.incomeclass);
            filter = QHS.AppAnd(QHS.CmpEq("idallowancerule", idallowancerule), filter);

            DataTable TempTable = Meta.Conn.RUN_SELECT("allowanceruledetail",
                "amount, advancepercentage", null, filter, null, false);
            double percanticipoitalia = 0;
            if ((TempTable == null) || (TempTable.Rows.Count == 0)) {
                show("Le informazioni relative alla diaria sono incomplete o mancanti. ", "Avviso");
                return;
            }
            indennitaEUR = CfgFn.GetNoNullDecimal(TempTable.Rows[0]["amount"]);
            double percanticipo = CfgFn.GetNoNullDouble(TempTable.Rows[0]["advancepercentage"]);
            txtmaxPerc.Text = HelpForm.StringValue(percanticipoitalia, txtPercAnticipo.Tag.ToString());
            txtIndennEUR.Text = indennitaEUR.ToString("c");            
        }
        
		/// <summary>
		/// Rilegge dal DB Indennità Euro, Indennità Corrisp. Euro, Percentuale Anticipo  per l'italia
		/// L'indennità corrisposta è inizializzata all'indennità
		/// Chiamato quando:
		///  - ChkBox Italia/estero cambia
		///  - Località cambia
		/// </summary>
		private void ImpostaIndTrasfertaItalia() {
			decimal indennitaEUR;
			lastfilterestero=null;
            if (DS.itinerationlap.Rows.Count == 0) return;
			DataRow Curr = DS.itinerationlap.Rows[0];
			Curr["flagitalian"]="S";

            object datarif = Curr["starttime"];
            if (datarif == DBNull.Value) return;
            string filterstart = QHS.CmpLe("start", datarif);
            object idallowancerule = Meta.Conn.DO_READ_VALUE("allowancerule", filterstart,
                          "max(idallowancerule)");

            string filter = MissFun.GetQualificaClasseFilter(Cfg.idposition,Cfg.incomeclass);
            filter = QHS.AppAnd(QHS.CmpEq("idallowancerule", idallowancerule), filter);

            DataTable TempTable = Meta.Conn.RUN_SELECT("allowanceruledetail",
                "amount, advancepercentage", null, filter, null, false);
            if ((TempTable == null) || (TempTable.Rows.Count == 0)) {
                show("Le informazioni relative alla diaria sono incomplete o mancanti. ", "Avviso");
                ImpostaIndennitaPercTappa(0, 0);
                return;
            }
     		indennitaEUR= CfgFn.GetNoNullDecimal(TempTable.Rows[0]["amount"]);
			double percanticipo = CfgFn.GetNoNullDouble(TempTable.Rows[0]["advancepercentage"]);
			ImpostaIndennitaPercTappa(indennitaEUR, percanticipo);
			txtIndennCorrispEUR.Text=indennitaEUR.ToString("C");
			DS.itinerationlap.Rows[0]["allowance"]=indennitaEUR;
        }

		void ImpostaIndennitaPercTappa(decimal indennitaEUR, double percanticipo){
			DataRow Tappa = DS.itinerationlap.Rows[0];
			Tappa["allowance"]=indennitaEUR;
			txtIndennEUR.Text=indennitaEUR.ToString("C");
			Tappa["advancepercentage"]=percanticipo;			
			txtPercAnticipo.Text= HelpForm.StringValue(percanticipo, txtPercAnticipo.Tag.ToString());
            txtmaxPerc.Text = HelpForm.StringValue(percanticipo, txtPercAnticipo.Tag.ToString());
            txtIndennEUR.Text = indennitaEUR.ToString("c");

		}

	
	

		void ClearIndennitaTrasfertaEstero(){
			ImpostaIndennitaPercTappa(0,0);
		}


		string lastfilterestero=null;

        void AggiornaSoloInfoEstero() {
            DataRow Curr = DS.itinerationlap.Rows[0];
            object codicelocalita = Curr["idforeigncountry"];
            if ((codicelocalita == DBNull.Value) || (Curr["starttime"] == DBNull.Value)) {
                return;
            }
            object datarif = Curr["starttime"];
            if (datarif == DBNull.Value) return;
            string filterstart = QHS.CmpLe("start", datarif);

            object idforeignallowancerule = Meta.Conn.DO_READ_VALUE("foreignallowancerule",
                QHS.AppAnd(QHS.CmpEq("idforeigncountry", Curr["idforeigncountry"]), filterstart),
                "max(idforeignallowancerule)");
            string filter = QHS.AppAnd(QHS.CmpEq("idforeignallowancerule", idforeignallowancerule),
                QHS.Between(QHS.quote(Cfg.foreigngroupnumber), QHS.Field("minforeigngroupnumber"), QHS.Field("maxforeigngroupnumber")));

            if (filter == lastfilterestero) return;
            lastfilterestero = filter;

            DataTable dettind = Meta.Conn.RUN_SELECT("foreignallowanceruledetail",
                "amount,advancepercentage", null, filter, null, false);
            if ((dettind == null) || (dettind.Rows.Count == 0)) {
                show("Le informazioni relative alla diaria estera sono incomplete o mancanti." +
                    "(Tappa n." + Curr["lapnumber"].ToString() + ")"
                    , "Avviso");
                return;
            }

            DataRow DettIndRow = dettind.Rows[0];
            decimal importo = CfgFn.GetNoNullDecimal(DettIndRow["amount"]);
            double perc = CfgFn.GetNoNullDouble(DettIndRow["advancepercentage"]);

            txtmaxPerc.Text = HelpForm.StringValue(perc, txtPercAnticipo.Tag.ToString());
            txtIndennEUR.Text = importo.ToString("c");

        }
        
        private void ImpostaIndTrasfertaEstero() {
			Meta.GetFormData(true);
			//lastfilteritalia=null;
			DataRow Curr = DS.itinerationlap.Rows[0]; 
			Curr["flagitalian"]="N";
			object codicelocalita = Curr["idforeigncountry"];
			if ((codicelocalita==DBNull.Value)||(Curr["starttime"]==DBNull.Value)) {
				DS.itinerationlap.Rows[0]["allowance"]=0;
				ClearIndennitaTrasfertaEstero();
				lastfilterestero=null;
				return;
			}
            object datarif = Curr["starttime"];
            if (datarif == DBNull.Value) return;
            string filterstart = QHS.CmpLe("start", datarif);

            object idforeignallowancerule = Meta.Conn.DO_READ_VALUE("foreignallowancerule",
                QHS.AppAnd(QHS.CmpEq("idforeigncountry", Curr["idforeigncountry"]), filterstart),
                "max(idforeignallowancerule)");
            string filter = QHS.AppAnd(QHS.CmpEq("idforeignallowancerule", idforeignallowancerule),
                                QHS.Between(QHS.quote(Cfg.foreigngroupnumber), QHS.Field("minforeigngroupnumber"), QHS.Field("maxforeigngroupnumber")));

            if (filter == lastfilterestero) return;
            lastfilterestero = filter;

            DataTable dettind = Meta.Conn.RUN_SELECT("foreignallowanceruledetail",
                "amount,advancepercentage", null, filter, null, false);
            if ((dettind == null) || (dettind.Rows.Count == 0)) {
                show("Le informazioni relative alla diaria estera sono incomplete o mancanti." +
                    "(Tappa n." + Curr["lapnumber"].ToString() + ")"
                    , "Avviso");
                ClearIndennitaTrasfertaEstero();
                return;
            }

			DataRow DettIndRow = dettind.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(DettIndRow["amount"]);
			double perc = CfgFn.GetNoNullDouble(DettIndRow["advancepercentage"]);

			DS.itinerationlap.Rows[0]["advancepercentage"]= perc;
			DS.itinerationlap.Rows[0]["allowance"]=importo;

			txtPercAnticipo.Text= HelpForm.StringValue(perc, txtPercAnticipo.Tag.ToString());
            txtmaxPerc.Text = HelpForm.StringValue(perc, txtPercAnticipo.Tag.ToString());
            txtIndennCorrispEUR.Text = importo.ToString("c");
            txtIndennEUR.Text = importo.ToString("c");
		}





		
		
		private void ImpostaItaliaEstero(bool EnableDisableOnly) {
			
			if (chkitaliaestero.Checked){
				//(rdbItalia.Checked) {
				btnLocalita.Enabled=false;
				cmbLocalita.Enabled=false;
				cmbLocalita.SelectedIndex=0;
				txtQuotaEsenteGiornaliera.Text= 
					CfgFn.GetNoNullDecimal(Cfg.italianexemption).ToString("c");
				
				if (!EnableDisableOnly) ImpostaIndTrasfertaItalia();
				lastfilterestero=null;
			}

			//if (rdbEstero.Checked)
			else{
				btnLocalita.Enabled=true;
				cmbLocalita.Enabled=true;

				txtQuotaEsenteGiornaliera.Text= 
					CfgFn.GetNoNullDecimal(Cfg.foreignexemption).ToString("c");

				if (!EnableDisableOnly) ImpostaIndTrasfertaEstero();
			}
		}

		#endregion


		private void rdbItalia_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			ImpostaItaliaEstero(false);
			RicalcolaGiorniOreMissione();
		}

		private void rdbEstero_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			ImpostaItaliaEstero(false);
		}

		void RicalcolaGiorniOreMissione() {
		    if (Meta.IsEmpty) return;
		    if (Meta.formController.isClosing) return;
			Meta.GetFormData(true);
		    DataRow Curr = DS.itinerationlap.Rows[0];

			DataRow MissioneRow = Meta.SourceRow.GetParentRow("itinerationitinerationlap");
			MissFun.RicalcolaOreGiorniTappa(MissioneRow, Curr,Cfg);
			int ngiorni = CfgFn.GetNoNullInt32(Curr["days"]);
			int nore = CfgFn.GetNoNullInt32(Curr["hours"]);
			txtGiorni.Text= ngiorni.ToString();
			txtOre.Text= nore.ToString();

			
		}


	
		private void txtDataOraInizio_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone)return;
			RicalcolaGiorniOreMissione();
			RicalcolaIndennitaTotale();
			//RicalcolaIndennitaTrasferta();
		}

		private void txtDataOraTermine_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone)return;
			RicalcolaGiorniOreMissione();
			RicalcolaIndennitaTotale();
		}


		#region Gestione calcolo riduzione
		void AbilitaDisabilitaTipoRiduzione(bool abilita){
			txtPercRidDiaria.ReadOnly=!abilita;
			DataRow Curr = DS.itinerationlap.Rows[0];

		}

		void AbilitaDisabilitaTipoRiduzione(){
			DataRow Curr = DS.itinerationlap.Rows[0];
			if (Curr["idreduction"]==DBNull.Value){
			}

			if (cmbTipoRiduzione.SelectedIndex<=0){
				AbilitaDisabilitaTipoRiduzione(true);
			}
			else {
				AbilitaDisabilitaTipoRiduzione(false);
			}
		}
			
		void AggiornaTipoRiduzione(){
			Meta.GetFormData(true);
			DataRow Curr = DS.itinerationlap.Rows[0];
			if (Curr["idreduction"]==DBNull.Value) {
				AggiornaTipoRiduzione(null);
			}
			else {
				AggiornaTipoRiduzione(Curr.GetParentRow("reductionitinerationlap"));
			}
		}

		string lastfilterriduzioneevalued=null;
		void AggiornaTipoRiduzione(DataRow Rid){			
			DataRow Curr = DS.itinerationlap.Rows[0];

			if (Rid==null){
				Curr["reductionpercentage"]=0;
				double  xdou=0;
				lastfilterriduzioneevalued=null;
				txtPercRidDiaria.Text=  HelpForm.StringValue(xdou, txtPercRidDiaria.Tag.ToString());
				AbilitaDisabilitaTipoRiduzione(true);
				RicalcolaQuotaEsenteTappa();
				return;
			}
            if (Curr["starttime"] == DBNull.Value) return;

            object datarif = Curr["starttime"];
            if ((datarif == null) || (datarif == DBNull.Value)) return;
            string filterstart = QHS.CmpLe("start", datarif);

			string myfilter = QHS.CmpEq("idreduction", Rid["idreduction"]);
			if (myfilter+filterstart==lastfilterriduzioneevalued) return;
			lastfilterriduzioneevalued=myfilter+filterstart;

            object idreductionrule = Meta.Conn.DO_READ_VALUE("reductionrule", filterstart, "max(idreductionrule)");
            string filter = QHS.AppAnd(QHS.CmpEq("idreductionrule", idreductionrule), myfilter);

            DataTable TempItalia = Meta.Conn.RUN_SELECT("reductionruledetail", "reductionpercentage", 
                                null, filter, null, false);

            if ((TempItalia == null) || (TempItalia.Rows.Count == 0)) {
				show("Le informazioni relative alla riduzione sono incomplete o mancanti.");
                Curr["reductionpercentage"] = 0;
				AbilitaDisabilitaTipoRiduzione(true);
			}
			else {
                Curr["reductionpercentage"] = TempItalia.Rows[0]["reductionpercentage"];
				AbilitaDisabilitaTipoRiduzione(false);
			}
			//txtPercChangePilotato=true;
            txtPercRidDiaria.Text = HelpForm.StringValue(Curr["reductionpercentage"], 
                txtPercRidDiaria.Tag.ToString());
			//txtPercChangePilotato=false;
			RicalcolaQuotaEsenteTappa();
		}

		//bool txtPercChangePilotato=false;



		#endregion

		


		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (!Meta.DrawStateIsDone) return;
			if (T.TableName == "reduction"){
				Meta.GetFormData(true);
				AggiornaTipoRiduzione(R);
			}
			if (T.TableName == "foreigncountry"){
				Meta.GetFormData(true);
				ImpostaIndTrasfertaEstero();
			}
			

		}



		//Assume GetFormData() chiamato
		double GetNfrazionarioGiorni(){
			if (DS.itinerationlap.Rows.Count==0) return 0;
			return MissFun.GetNFrazionarioGiorni(DS.itinerationlap.Rows[0]);
		}

//		//Assume GetFomData() chiamato
//		double IndennitaTotaleNonRidotta(){
//			if (DS.missionetappa.Rows.Count==0) return 0;
//			DataRow Curr= DS.missionetappa.Rows[0];
//			return MissFun.IndennitaTotaleNonRidotta(Curr);
//		}

		void RicalcolaIndennitaTotale(){
			Meta.GetFormData(true);
			if (DS.itinerationlap.Rows.Count==0) return;
			DataRow Curr= DS.itinerationlap.Rows[0];
			decimal indtot =  MissFun.IndennitaTotale(Curr); // GIA' IN EURO!!!
			//indtot = MissFun.DecToEuro(Curr,indtot);
			txtIndennTotEUR.Text = indtot.ToString("c"); //TextBox senza tag

			double perc = CfgFn.GetNoNullDouble(
					HelpForm.GetObjectFromString(
						typeof(double),txtPercRidDiaria.Text,
						txtPercRidDiaria.Tag.ToString()));

			string Help= txtIndennCorrispEUR.Text+"*"+
				txtFrazioneGiorni.Text+"*(1-"+perc.ToString("n")+")";

			SetToolTip(txtHelpIndennitaTotale,Help);
			RicalcolaQuotaImponibileTappa();
		}

	
		private void txtIndennCorrispEUR_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			RicalcolaIndennitaTotale();
			RicalcolaAnticipo();
		}

		private void txtDataOraInizio_Leave(object sender, System.EventArgs e) {
			//AggiornaTipoRiduzione(); inutile
		}


	
		private void txtPercRidDiaria_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			RicalcolaIndennitaTotale();
			RicalcolaAnticipo();
		}

		private void txtCambio_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			RicalcolaIndennitaTotale();
			RicalcolaAnticipo();
		}

		private void txtPercAnticipo_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			RicalcolaAnticipo();
		}

		private void txtAnticipo_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			RicalcolaPercentualeAnticipo();
		}

		private void txtAnticipo_Enter(object sender, System.EventArgs e) {
//			HelpForm.EnterNumTextBox(sender, e);
		}

		private void txtAnticipo_Leave(object sender, System.EventArgs e) {
			TextBox T = (TextBox)sender;
			if (!T.Enabled) return;
			if (T.Text=="") return;
			string tag= "x.y.c";
			try {
				object O = HelpForm.GetObjectFromString(typeof(decimal), T.Text, tag);
				T.Text= HelpForm.StringValue(O, tag);
			}
			catch {
			}
		}

		void RicalcolaNGiorniFrazionario(){
			double ngg = GetNfrazionarioGiorni();
			string NGG = HelpForm.StringValue(ngg,"x.y.fixed.5...1");
			txtFrazioneGiorni.Text=  NGG;
			RicalcolaQuotaEsenteTappa();
		}

		private void txtGiorni_TextChanged(object sender, System.EventArgs e) {			
			if (!Meta.DrawStateIsDone) return;
			Meta.GetFormData(true);
			RicalcolaNGiorniFrazionario();
			RicalcolaIndennitaTotale();
			RicalcolaAnticipo();
		}

		private void txtOre_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			Meta.GetFormData(true);
			RicalcolaNGiorniFrazionario();
			RicalcolaIndennitaTotale();
			RicalcolaAnticipo();
		}

		void RicalcolaIndennitaLorda(){
			decimal indlorda;
			decimal indtot= CfgFn.GetNoNullDecimal(
				HelpForm.GetObjectFromString(typeof(decimal),
					txtIndennTotEUR.Text,null));
			decimal quotaes= CfgFn.GetNoNullDecimal(
				HelpForm.GetObjectFromString(typeof(decimal),
					txtQuotaEsenteTappa.Text,null));
			decimal quotaimp= CfgFn.GetNoNullDecimal(
					HelpForm.GetObjectFromString(typeof(decimal),
					txtQuotaImponibileTappa.Text,null));
			string help;
			if (indtot>quotaes){
				indlorda = quotaes+quotaimp;
				help = quotaes.ToString("c")+"+"+quotaimp.ToString("c");
			}
			else {
				indlorda = indtot;
				help = indtot.ToString("c");
			}
			txtIndennLorda.Text= indlorda.ToString("c");
			SetToolTip(txtHelpIndennLorda, help);
		}

		private void txtIndennTotEUR_TextChanged(object sender, System.EventArgs e) {
			//if (!Meta.DrawStateIsDone)return;
			RicalcolaIndennitaLorda();
			//RicalcolaAnticipo(); spostato in IndennCorr/Ore/gg/PercRidDiaria Text Changed
		}

//		private void txtIndennEUR_TextChanged(object sender, System.EventArgs e) {
//			if (!Meta.DrawStateIsDone)return;
//			if (rdbItalia.Checked) return;
//			//ConvertiIntoValuta2(txtIndennEUR, txtIndennValuta);
//		}


		void SetToolTip(Control C, string tip){
			myTip.SetToolTip(C, tip);
		}

		private void txtQuotaEsenteGiornaliera_TextChanged(object sender, System.EventArgs e) {
			RicalcolaIndennitaLorda();
		}

		private void chkitaliaestero_CheckedChanged(object sender, System.EventArgs e){
			if (!Meta.DrawStateIsDone) return;
			ImpostaItaliaEstero(false);
			RicalcolaGiorniOreMissione();
		
		}

	}
}
