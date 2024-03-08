
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using metadatalibrary;
using System.Text;

namespace geo_city_default//geo_comune//
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Frm_geo_city_default : System.Windows.Forms.Form
	{
		private Tabelle tabelle;
		private bool occupato;

		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		public /*Rana:geo_comune.*/vistaForm DS;
		private System.Windows.Forms.TabControl tabController;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnNext;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGrid dataGridImportazione;
		private System.Windows.Forms.DataGrid dataGridDettagli;
		private System.Windows.Forms.DataGrid dataGridCoppie;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.DataGrid dataGridSingle1;
		private System.Windows.Forms.DataGrid dataGridSingle2;
		private System.Windows.Forms.DataGrid dataGridLogScrittura;
		private System.Windows.Forms.ComboBox comboBoxProvincia;
		private System.Windows.Forms.Button buttonDisaccoppia;
		private System.Windows.Forms.Button buttonAccoppia;
		private System.Windows.Forms.DataGrid dataGridDatiCorretti;
		private System.Windows.Forms.DataGrid dataGridGeoComune;
		private System.Windows.Forms.Label labelTabellaDaImportare;
		private System.Windows.Forms.Label labelGeoComune;
		private System.Windows.Forms.Button buttonPrecProvincia;
		private System.Windows.Forms.Button buttonSuccProvincia;
		private System.Windows.Forms.ComboBox comboBoxProvinciaIniziale;
		private System.Windows.Forms.NumericUpDown numericUpDownQuanteProvince;
		private System.Windows.Forms.Label labelProvinceSelezionate;
		private System.Windows.Forms.Label labelQuanteProvince;
		private System.Windows.Forms.Label labelProvinciaCorrente;
		private System.Windows.Forms.Label labelImportazioneSelezionata;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.TextBox textBoxImpIdente;
		private System.Windows.Forms.TextBox textBoxImpNomeImportazione;
		private System.Windows.Forms.TextBox textBoxImpTabellaSorgente;
		private System.Windows.Forms.TextBox textBoxImpClnValore;
		private System.Windows.Forms.TextBox textBoxImpClnDenominazione;
		private System.Windows.Forms.TextBox textBoxImpClnSiglaProvincia;
		private System.Windows.Forms.TextBox textBoxImpClnDataInizio;
		private System.Windows.Forms.TextBox textBoxImpClnDataFine;
		private System.Windows.Forms.TextBox textBoxImpClnIstat;
		private System.Windows.Forms.TextBox textBoxImpClnFisco;
		private System.Windows.Forms.TextBox textBoxImpClnCatasto;
		private System.Windows.Forms.TextBox textBoxImpClnCap;
		private System.Windows.Forms.Label labelImpIdente;
		private System.Windows.Forms.Label labelImpTabellaSorgente;
		private System.Windows.Forms.Label labelImpClnDenominazione;
		private System.Windows.Forms.Label labelImpClnIdProvincia;
		private System.Windows.Forms.Label labelImpClnSiglaProvincia;
		private System.Windows.Forms.Label labelPrimaProvinciaDaImportare;
		private System.Windows.Forms.CheckBox checkBoxImpCorrezioneSiglaProvincia;
		private System.Windows.Forms.Label labelImpDataInizio;
		private System.Windows.Forms.Label labelImpNomeImportazione;
		private System.Windows.Forms.TextBox textBoxImpClnIdProvincia;
		private System.Windows.Forms.Label labelImpClnDataFine;
		private System.Windows.Forms.Label labelImpClnIstat;
		private System.Windows.Forms.Label labelImpClnFisco;
		private System.Windows.Forms.Label labelImpClnCatasto;
		private System.Windows.Forms.Label labelImpClnCap;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.NumericUpDown numericUpDownPrimaProvincia;
		private System.Windows.Forms.Label labelImpClnValore1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label labelImpClnValore2;
		private System.Windows.Forms.CheckBox checkBoxImpCorrezioneDataInizio;
		private string CustomTitle="Importazione dati dei comuni ";

		public Frm_geo_city_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
//			GetData.CacheTable(DS.geo_provincia, null, "sigla", false);
			HelpForm.SetDenyNull(DS.geo_importazione_dati.correzione_fofc_pspuColumn, true);
			HelpForm.SetDenyNull(DS.geo_importazione_dati.correzione_datainizio_1960_01_01Column, true);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGeo_comune));
			this.tabController = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.numericUpDownPrimaProvincia = new System.Windows.Forms.NumericUpDown();
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			this.labelImpClnValore2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.labelImpClnCap = new System.Windows.Forms.Label();
			this.labelImpClnCatasto = new System.Windows.Forms.Label();
			this.labelImpClnFisco = new System.Windows.Forms.Label();
			this.labelImpClnIstat = new System.Windows.Forms.Label();
			this.labelImpClnDataFine = new System.Windows.Forms.Label();
			this.checkBoxImpCorrezioneSiglaProvincia = new System.Windows.Forms.CheckBox();
			this.labelImpDataInizio = new System.Windows.Forms.Label();
			this.labelImpClnSiglaProvincia = new System.Windows.Forms.Label();
			this.labelImpClnIdProvincia = new System.Windows.Forms.Label();
			this.labelImpClnDenominazione = new System.Windows.Forms.Label();
			this.labelImpClnValore1 = new System.Windows.Forms.Label();
			this.labelImpTabellaSorgente = new System.Windows.Forms.Label();
			this.labelImpNomeImportazione = new System.Windows.Forms.Label();
			this.labelImpIdente = new System.Windows.Forms.Label();
			this.textBoxImpClnCap = new System.Windows.Forms.TextBox();
			this.textBoxImpClnCatasto = new System.Windows.Forms.TextBox();
			this.textBoxImpClnFisco = new System.Windows.Forms.TextBox();
			this.textBoxImpClnIstat = new System.Windows.Forms.TextBox();
			this.textBoxImpClnDataFine = new System.Windows.Forms.TextBox();
			this.textBoxImpClnDataInizio = new System.Windows.Forms.TextBox();
			this.textBoxImpClnSiglaProvincia = new System.Windows.Forms.TextBox();
			this.textBoxImpClnIdProvincia = new System.Windows.Forms.TextBox();
			this.textBoxImpClnDenominazione = new System.Windows.Forms.TextBox();
			this.textBoxImpClnValore = new System.Windows.Forms.TextBox();
			this.textBoxImpTabellaSorgente = new System.Windows.Forms.TextBox();
			this.textBoxImpNomeImportazione = new System.Windows.Forms.TextBox();
			this.textBoxImpIdente = new System.Windows.Forms.TextBox();
			this.labelImportazioneSelezionata = new System.Windows.Forms.Label();
			this.labelQuanteProvince = new System.Windows.Forms.Label();
			this.labelPrimaProvinciaDaImportare = new System.Windows.Forms.Label();
			this.labelProvinceSelezionate = new System.Windows.Forms.Label();
			this.numericUpDownQuanteProvince = new System.Windows.Forms.NumericUpDown();
			this.comboBoxProvinciaIniziale = new System.Windows.Forms.ComboBox();
			this.DS = new /*Rana:geo_comune.*/vistaForm();
			this.dataGridImportazione = new System.Windows.Forms.DataGrid();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.labelGeoComune = new System.Windows.Forms.Label();
			this.labelTabellaDaImportare = new System.Windows.Forms.Label();
			this.dataGridGeoComune = new System.Windows.Forms.DataGrid();
			this.dataGridDatiCorretti = new System.Windows.Forms.DataGrid();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.buttonSuccProvincia = new System.Windows.Forms.Button();
			this.buttonPrecProvincia = new System.Windows.Forms.Button();
			this.buttonAccoppia = new System.Windows.Forms.Button();
			this.buttonDisaccoppia = new System.Windows.Forms.Button();
			this.labelProvinciaCorrente = new System.Windows.Forms.Label();
			this.comboBoxProvincia = new System.Windows.Forms.ComboBox();
			this.dataGridSingle2 = new System.Windows.Forms.DataGrid();
			this.dataGridSingle1 = new System.Windows.Forms.DataGrid();
			this.dataGridDettagli = new System.Windows.Forms.DataGrid();
			this.dataGridCoppie = new System.Windows.Forms.DataGrid();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.dataGridLogScrittura = new System.Windows.Forms.DataGrid();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.checkBoxImpCorrezioneDataInizio = new System.Windows.Forms.CheckBox();
			this.tabController.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrimaProvincia)).BeginInit();
			this.MetaDataDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuanteProvince)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridImportazione)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridGeoComune)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridDatiCorretti)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSingle2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSingle1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridDettagli)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridCoppie)).BeginInit();
			this.tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridLogScrittura)).BeginInit();
			this.SuspendLayout();
			// 
			// tabController
			// 
			this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabController.Controls.Add(this.tabPage1);
			this.tabController.Controls.Add(this.tabPage2);
			this.tabController.Controls.Add(this.tabPage3);
			this.tabController.Controls.Add(this.tabPage5);
			this.tabController.Location = new System.Drawing.Point(8, 0);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 0;
			this.tabController.Size = new System.Drawing.Size(1086, 608);
			this.tabController.TabIndex = 0;
			this.tabController.SelectedIndexChanged += new System.EventHandler(this.tabController_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.numericUpDownPrimaProvincia);
			this.tabPage1.Controls.Add(this.MetaDataDetail);
			this.tabPage1.Controls.Add(this.labelImportazioneSelezionata);
			this.tabPage1.Controls.Add(this.labelQuanteProvince);
			this.tabPage1.Controls.Add(this.labelPrimaProvinciaDaImportare);
			this.tabPage1.Controls.Add(this.labelProvinceSelezionate);
			this.tabPage1.Controls.Add(this.numericUpDownQuanteProvince);
			this.tabPage1.Controls.Add(this.comboBoxProvinciaIniziale);
			this.tabPage1.Controls.Add(this.dataGridImportazione);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(1078, 582);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Configurazione";
			// 
			// numericUpDownPrimaProvincia
			// 
			this.numericUpDownPrimaProvincia.Location = new System.Drawing.Point(160, 408);
			this.numericUpDownPrimaProvincia.Name = "numericUpDownPrimaProvincia";
			this.numericUpDownPrimaProvincia.Size = new System.Drawing.Size(64, 20);
			this.numericUpDownPrimaProvincia.TabIndex = 15;
			this.numericUpDownPrimaProvincia.ValueChanged += new System.EventHandler(this.numericUpDownPrimaProvincia_ValueChanged);
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Controls.Add(this.checkBoxImpCorrezioneDataInizio);
			this.MetaDataDetail.Controls.Add(this.labelImpClnValore2);
			this.MetaDataDetail.Controls.Add(this.textBox1);
			this.MetaDataDetail.Controls.Add(this.labelImpClnCap);
			this.MetaDataDetail.Controls.Add(this.labelImpClnCatasto);
			this.MetaDataDetail.Controls.Add(this.labelImpClnFisco);
			this.MetaDataDetail.Controls.Add(this.labelImpClnIstat);
			this.MetaDataDetail.Controls.Add(this.labelImpClnDataFine);
			this.MetaDataDetail.Controls.Add(this.checkBoxImpCorrezioneSiglaProvincia);
			this.MetaDataDetail.Controls.Add(this.labelImpDataInizio);
			this.MetaDataDetail.Controls.Add(this.labelImpClnSiglaProvincia);
			this.MetaDataDetail.Controls.Add(this.labelImpClnIdProvincia);
			this.MetaDataDetail.Controls.Add(this.labelImpClnDenominazione);
			this.MetaDataDetail.Controls.Add(this.labelImpClnValore1);
			this.MetaDataDetail.Controls.Add(this.labelImpTabellaSorgente);
			this.MetaDataDetail.Controls.Add(this.labelImpNomeImportazione);
			this.MetaDataDetail.Controls.Add(this.labelImpIdente);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnCap);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnCatasto);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnFisco);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnIstat);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnDataFine);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnDataInizio);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnSiglaProvincia);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnIdProvincia);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnDenominazione);
			this.MetaDataDetail.Controls.Add(this.textBoxImpClnValore);
			this.MetaDataDetail.Controls.Add(this.textBoxImpTabellaSorgente);
			this.MetaDataDetail.Controls.Add(this.textBoxImpNomeImportazione);
			this.MetaDataDetail.Controls.Add(this.textBoxImpIdente);
			this.MetaDataDetail.Location = new System.Drawing.Point(8, 184);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(1064, 144);
			this.MetaDataDetail.TabIndex = 14;
			this.MetaDataDetail.TabStop = false;
			this.MetaDataDetail.Text = "Dettaglio importazione";
			// 
			// labelImpClnValore2
			// 
			this.labelImpClnValore2.Location = new System.Drawing.Point(496, 24);
			this.labelImpClnValore2.Name = "labelImpClnValore2";
			this.labelImpClnValore2.TabIndex = 32;
			this.labelImpClnValore2.Text = "colonna \"valore2\"";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(496, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 31;
			this.textBox1.Tag = "geo_importazione_dati.cln_valore2";
			this.textBox1.Text = "cln_valore2";
			// 
			// labelImpClnCap
			// 
			this.labelImpClnCap.Location = new System.Drawing.Point(608, 88);
			this.labelImpClnCap.Name = "labelImpClnCap";
			this.labelImpClnCap.TabIndex = 30;
			this.labelImpClnCap.Text = "colonna \"cap\"";
			// 
			// labelImpClnCatasto
			// 
			this.labelImpClnCatasto.Location = new System.Drawing.Point(496, 88);
			this.labelImpClnCatasto.Name = "labelImpClnCatasto";
			this.labelImpClnCatasto.TabIndex = 29;
			this.labelImpClnCatasto.Text = "colonna \"catasto\"";
			// 
			// labelImpClnFisco
			// 
			this.labelImpClnFisco.Location = new System.Drawing.Point(384, 88);
			this.labelImpClnFisco.Name = "labelImpClnFisco";
			this.labelImpClnFisco.TabIndex = 28;
			this.labelImpClnFisco.Text = "colonna \"fisco\"";
			// 
			// labelImpClnIstat
			// 
			this.labelImpClnIstat.Location = new System.Drawing.Point(272, 88);
			this.labelImpClnIstat.Name = "labelImpClnIstat";
			this.labelImpClnIstat.TabIndex = 27;
			this.labelImpClnIstat.Text = "colonna \"istat\"";
			// 
			// labelImpClnDataFine
			// 
			this.labelImpClnDataFine.Location = new System.Drawing.Point(160, 88);
			this.labelImpClnDataFine.Name = "labelImpClnDataFine";
			this.labelImpClnDataFine.TabIndex = 26;
			this.labelImpClnDataFine.Text = "colonna \"data fine\"";
			// 
			// checkBoxImpCorrezioneSiglaProvincia
			// 
			this.checkBoxImpCorrezioneSiglaProvincia.Location = new System.Drawing.Point(728, 112);
			this.checkBoxImpCorrezioneSiglaProvincia.Name = "checkBoxImpCorrezioneSiglaProvincia";
			this.checkBoxImpCorrezioneSiglaProvincia.Size = new System.Drawing.Size(248, 24);
			this.checkBoxImpCorrezioneSiglaProvincia.TabIndex = 25;
			this.checkBoxImpCorrezioneSiglaProvincia.Tag = "geo_importazione_dati.correzione_fofc_pspu:S:N";
			this.checkBoxImpCorrezioneSiglaProvincia.Text = "correzione sigla provincia \'fo\'->\'fc\' e \'ps\'->\'pu\'";
			// 
			// labelImpDataInizio
			// 
			this.labelImpDataInizio.Location = new System.Drawing.Point(48, 88);
			this.labelImpDataInizio.Name = "labelImpDataInizio";
			this.labelImpDataInizio.Size = new System.Drawing.Size(112, 23);
			this.labelImpDataInizio.TabIndex = 24;
			this.labelImpDataInizio.Text = "colonna \"data inizio\"";
			// 
			// labelImpClnSiglaProvincia
			// 
			this.labelImpClnSiglaProvincia.Location = new System.Drawing.Point(856, 24);
			this.labelImpClnSiglaProvincia.Name = "labelImpClnSiglaProvincia";
			this.labelImpClnSiglaProvincia.Size = new System.Drawing.Size(128, 23);
			this.labelImpClnSiglaProvincia.TabIndex = 23;
			this.labelImpClnSiglaProvincia.Text = "colonna \"sigla provincia\"";
			// 
			// labelImpClnIdProvincia
			// 
			this.labelImpClnIdProvincia.Location = new System.Drawing.Point(736, 24);
			this.labelImpClnIdProvincia.Name = "labelImpClnIdProvincia";
			this.labelImpClnIdProvincia.Size = new System.Drawing.Size(120, 23);
			this.labelImpClnIdProvincia.TabIndex = 22;
			this.labelImpClnIdProvincia.Text = "colonna \"id. provincia\"";
			// 
			// labelImpClnDenominazione
			// 
			this.labelImpClnDenominazione.Location = new System.Drawing.Point(600, 24);
			this.labelImpClnDenominazione.Name = "labelImpClnDenominazione";
			this.labelImpClnDenominazione.Size = new System.Drawing.Size(136, 23);
			this.labelImpClnDenominazione.TabIndex = 21;
			this.labelImpClnDenominazione.Text = "colonna \"denominazione\"";
			// 
			// labelImpClnValore1
			// 
			this.labelImpClnValore1.Location = new System.Drawing.Point(384, 24);
			this.labelImpClnValore1.Name = "labelImpClnValore1";
			this.labelImpClnValore1.TabIndex = 20;
			this.labelImpClnValore1.Text = "colonna \"valore1\"";
			// 
			// labelImpTabellaSorgente
			// 
			this.labelImpTabellaSorgente.Location = new System.Drawing.Point(272, 24);
			this.labelImpTabellaSorgente.Name = "labelImpTabellaSorgente";
			this.labelImpTabellaSorgente.TabIndex = 19;
			this.labelImpTabellaSorgente.Text = "Tabella sorgente";
			// 
			// labelImpNomeImportazione
			// 
			this.labelImpNomeImportazione.Location = new System.Drawing.Point(160, 24);
			this.labelImpNomeImportazione.Name = "labelImpNomeImportazione";
			this.labelImpNomeImportazione.Size = new System.Drawing.Size(104, 23);
			this.labelImpNomeImportazione.TabIndex = 18;
			this.labelImpNomeImportazione.Text = "Nome importazione";
			// 
			// labelImpIdente
			// 
			this.labelImpIdente.Location = new System.Drawing.Point(48, 24);
			this.labelImpIdente.Name = "labelImpIdente";
			this.labelImpIdente.TabIndex = 16;
			this.labelImpIdente.Text = "Id. ente";
			// 
			// textBoxImpClnCap
			// 
			this.textBoxImpClnCap.Location = new System.Drawing.Point(608, 112);
			this.textBoxImpClnCap.Name = "textBoxImpClnCap";
			this.textBoxImpClnCap.TabIndex = 14;
			this.textBoxImpClnCap.Tag = "geo_importazione_dati.cln_cap";
			this.textBoxImpClnCap.Text = "cln_cap";
			// 
			// textBoxImpClnCatasto
			// 
			this.textBoxImpClnCatasto.Location = new System.Drawing.Point(496, 112);
			this.textBoxImpClnCatasto.Name = "textBoxImpClnCatasto";
			this.textBoxImpClnCatasto.TabIndex = 13;
			this.textBoxImpClnCatasto.Tag = "geo_importazione_dati.cln_catasto";
			this.textBoxImpClnCatasto.Text = "cln_catasto";
			// 
			// textBoxImpClnFisco
			// 
			this.textBoxImpClnFisco.Location = new System.Drawing.Point(384, 112);
			this.textBoxImpClnFisco.Name = "textBoxImpClnFisco";
			this.textBoxImpClnFisco.TabIndex = 12;
			this.textBoxImpClnFisco.Tag = "geo_importazione_dati.cln_fisco";
			this.textBoxImpClnFisco.Text = "cln_fisco";
			// 
			// textBoxImpClnIstat
			// 
			this.textBoxImpClnIstat.Location = new System.Drawing.Point(272, 112);
			this.textBoxImpClnIstat.Name = "textBoxImpClnIstat";
			this.textBoxImpClnIstat.TabIndex = 11;
			this.textBoxImpClnIstat.Tag = "geo_importazione_dati.cln_istat";
			this.textBoxImpClnIstat.Text = "cln_istat";
			// 
			// textBoxImpClnDataFine
			// 
			this.textBoxImpClnDataFine.Location = new System.Drawing.Point(160, 112);
			this.textBoxImpClnDataFine.Name = "textBoxImpClnDataFine";
			this.textBoxImpClnDataFine.TabIndex = 10;
			this.textBoxImpClnDataFine.Tag = "geo_importazione_dati.cln_data_fine";
			this.textBoxImpClnDataFine.Text = "cln_data_fine";
			// 
			// textBoxImpClnDataInizio
			// 
			this.textBoxImpClnDataInizio.Location = new System.Drawing.Point(48, 112);
			this.textBoxImpClnDataInizio.Name = "textBoxImpClnDataInizio";
			this.textBoxImpClnDataInizio.TabIndex = 9;
			this.textBoxImpClnDataInizio.Tag = "geo_importazione_dati.cln_data_inizio";
			this.textBoxImpClnDataInizio.Text = "cln_data_inizio";
			// 
			// textBoxImpClnSiglaProvincia
			// 
			this.textBoxImpClnSiglaProvincia.Location = new System.Drawing.Point(872, 48);
			this.textBoxImpClnSiglaProvincia.Name = "textBoxImpClnSiglaProvincia";
			this.textBoxImpClnSiglaProvincia.TabIndex = 8;
			this.textBoxImpClnSiglaProvincia.Tag = "geo_importazione_dati.cln_sigla_provincia";
			this.textBoxImpClnSiglaProvincia.Text = "cln_sigla_provincia";
			// 
			// textBoxImpClnIdProvincia
			// 
			this.textBoxImpClnIdProvincia.Location = new System.Drawing.Point(744, 48);
			this.textBoxImpClnIdProvincia.Name = "textBoxImpClnIdProvincia";
			this.textBoxImpClnIdProvincia.TabIndex = 7;
			this.textBoxImpClnIdProvincia.Tag = "geo_importazione_dati.cln_id_provincia";
			this.textBoxImpClnIdProvincia.Text = "cln_id_provincia";
			// 
			// textBoxImpClnDenominazione
			// 
			this.textBoxImpClnDenominazione.Location = new System.Drawing.Point(608, 48);
			this.textBoxImpClnDenominazione.Name = "textBoxImpClnDenominazione";
			this.textBoxImpClnDenominazione.TabIndex = 6;
			this.textBoxImpClnDenominazione.Tag = "geo_importazione_dati.cln_denominazione";
			this.textBoxImpClnDenominazione.Text = "cln_denominazione";
			// 
			// textBoxImpClnValore
			// 
			this.textBoxImpClnValore.Location = new System.Drawing.Point(384, 48);
			this.textBoxImpClnValore.Name = "textBoxImpClnValore";
			this.textBoxImpClnValore.TabIndex = 5;
			this.textBoxImpClnValore.Tag = "geo_importazione_dati.cln_valore1";
			this.textBoxImpClnValore.Text = "cln_valore1";
			// 
			// textBoxImpTabellaSorgente
			// 
			this.textBoxImpTabellaSorgente.Location = new System.Drawing.Point(272, 48);
			this.textBoxImpTabellaSorgente.Name = "textBoxImpTabellaSorgente";
			this.textBoxImpTabellaSorgente.TabIndex = 4;
			this.textBoxImpTabellaSorgente.Tag = "geo_importazione_dati.tabella_sorgente";
			this.textBoxImpTabellaSorgente.Text = "tabella_sorgente";
			// 
			// textBoxImpNomeImportazione
			// 
			this.textBoxImpNomeImportazione.Location = new System.Drawing.Point(160, 48);
			this.textBoxImpNomeImportazione.Name = "textBoxImpNomeImportazione";
			this.textBoxImpNomeImportazione.TabIndex = 3;
			this.textBoxImpNomeImportazione.Tag = "geo_importazione_dati.nome_importazione";
			this.textBoxImpNomeImportazione.Text = "nome_importazione";
			// 
			// textBoxImpIdente
			// 
			this.textBoxImpIdente.Location = new System.Drawing.Point(48, 48);
			this.textBoxImpIdente.Name = "textBoxImpIdente";
			this.textBoxImpIdente.TabIndex = 1;
			this.textBoxImpIdente.Tag = "geo_importazione_dati.idente";
			this.textBoxImpIdente.Text = "idente";
			// 
			// labelImportazioneSelezionata
			// 
			this.labelImportazioneSelezionata.Location = new System.Drawing.Point(24, 456);
			this.labelImportazioneSelezionata.Name = "labelImportazioneSelezionata";
			this.labelImportazioneSelezionata.Size = new System.Drawing.Size(224, 23);
			this.labelImportazioneSelezionata.TabIndex = 13;
			this.labelImportazioneSelezionata.Text = "Tabella selezionata:";
			// 
			// labelQuanteProvince
			// 
			this.labelQuanteProvince.Location = new System.Drawing.Point(392, 408);
			this.labelQuanteProvince.Name = "labelQuanteProvince";
			this.labelQuanteProvince.Size = new System.Drawing.Size(160, 23);
			this.labelQuanteProvince.TabIndex = 12;
			this.labelQuanteProvince.Text = "Numero province da importare:";
			// 
			// labelPrimaProvinciaDaImportare
			// 
			this.labelPrimaProvinciaDaImportare.Location = new System.Drawing.Point(160, 384);
			this.labelPrimaProvinciaDaImportare.Name = "labelPrimaProvinciaDaImportare";
			this.labelPrimaProvinciaDaImportare.Size = new System.Drawing.Size(152, 16);
			this.labelPrimaProvinciaDaImportare.TabIndex = 11;
			this.labelPrimaProvinciaDaImportare.Text = "Prima provincia da importare:";
			// 
			// labelProvinceSelezionate
			// 
			this.labelProvinceSelezionate.Location = new System.Drawing.Point(24, 488);
			this.labelProvinceSelezionate.Name = "labelProvinceSelezionate";
			this.labelProvinceSelezionate.Size = new System.Drawing.Size(1064, 40);
			this.labelProvinceSelezionate.TabIndex = 10;
			this.labelProvinceSelezionate.Text = "Province selezionate: ";
			// 
			// numericUpDownQuanteProvince
			// 
			this.numericUpDownQuanteProvince.Location = new System.Drawing.Point(568, 408);
			this.numericUpDownQuanteProvince.Minimum = new System.Decimal(new int[] {
																						1,
																						0,
																						0,
																						0});
			this.numericUpDownQuanteProvince.Name = "numericUpDownQuanteProvince";
			this.numericUpDownQuanteProvince.Size = new System.Drawing.Size(56, 20);
			this.numericUpDownQuanteProvince.TabIndex = 9;
			this.numericUpDownQuanteProvince.Value = new System.Decimal(new int[] {
																					  10,
																					  0,
																					  0,
																					  0});
			this.numericUpDownQuanteProvince.ValueChanged += new System.EventHandler(this.numericUpDownQuanteProvince_ValueChanged);
			// 
			// comboBoxProvinciaIniziale
			// 
			this.comboBoxProvinciaIniziale.DataSource = this.DS.geo_country;
			this.comboBoxProvinciaIniziale.DisplayMember = "sigla";
			this.comboBoxProvinciaIniziale.ItemHeight = 13;
			this.comboBoxProvinciaIniziale.Location = new System.Drawing.Point(248, 408);
			this.comboBoxProvinciaIniziale.MaxDropDownItems = 30;
			this.comboBoxProvinciaIniziale.Name = "comboBoxProvinciaIniziale";
			this.comboBoxProvinciaIniziale.Size = new System.Drawing.Size(64, 21);
			this.comboBoxProvinciaIniziale.TabIndex = 8;
			this.comboBoxProvinciaIniziale.Tag = "";
			this.comboBoxProvinciaIniziale.ValueMember = "idprovincia";
			this.comboBoxProvinciaIniziale.SelectedIndexChanged += new System.EventHandler(this.comboBoxProvinciaIniziale_SelectedIndexChanged);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaGeo_Comune1";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataGridImportazione
			// 
			this.dataGridImportazione.DataMember = "";
			this.dataGridImportazione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridImportazione.Location = new System.Drawing.Point(8, 8);
			this.dataGridImportazione.Name = "dataGridImportazione";
			this.dataGridImportazione.Size = new System.Drawing.Size(1064, 168);
			this.dataGridImportazione.TabIndex = 7;
			this.dataGridImportazione.Tag = "geo_importazione_dati.default";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.labelGeoComune);
			this.tabPage2.Controls.Add(this.labelTabellaDaImportare);
			this.tabPage2.Controls.Add(this.dataGridGeoComune);
			this.tabPage2.Controls.Add(this.dataGridDatiCorretti);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(1078, 582);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Lettura dati";
			// 
			// labelGeoComune
			// 
			this.labelGeoComune.Location = new System.Drawing.Point(752, 8);
			this.labelGeoComune.Name = "labelGeoComune";
			this.labelGeoComune.Size = new System.Drawing.Size(128, 23);
			this.labelGeoComune.TabIndex = 3;
			this.labelGeoComune.Text = "Tabella geo_comune";
			// 
			// labelTabellaDaImportare
			// 
			this.labelTabellaDaImportare.Location = new System.Drawing.Point(200, 8);
			this.labelTabellaDaImportare.Name = "labelTabellaDaImportare";
			this.labelTabellaDaImportare.Size = new System.Drawing.Size(208, 23);
			this.labelTabellaDaImportare.TabIndex = 2;
			this.labelTabellaDaImportare.Text = "Tabella da importare";
			// 
			// dataGridGeoComune
			// 
			this.dataGridGeoComune.DataMember = "";
			this.dataGridGeoComune.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridGeoComune.Location = new System.Drawing.Point(544, 40);
			this.dataGridGeoComune.Name = "dataGridGeoComune";
			this.dataGridGeoComune.Size = new System.Drawing.Size(530, 540);
			this.dataGridGeoComune.TabIndex = 1;
			// 
			// dataGridDatiCorretti
			// 
			this.dataGridDatiCorretti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridDatiCorretti.DataMember = "";
			this.dataGridDatiCorretti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridDatiCorretti.Location = new System.Drawing.Point(8, 40);
			this.dataGridDatiCorretti.Name = "dataGridDatiCorretti";
			this.dataGridDatiCorretti.Size = new System.Drawing.Size(530, 540);
			this.dataGridDatiCorretti.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.buttonSuccProvincia);
			this.tabPage3.Controls.Add(this.buttonPrecProvincia);
			this.tabPage3.Controls.Add(this.buttonAccoppia);
			this.tabPage3.Controls.Add(this.buttonDisaccoppia);
			this.tabPage3.Controls.Add(this.labelProvinciaCorrente);
			this.tabPage3.Controls.Add(this.comboBoxProvincia);
			this.tabPage3.Controls.Add(this.dataGridSingle2);
			this.tabPage3.Controls.Add(this.dataGridSingle1);
			this.tabPage3.Controls.Add(this.dataGridDettagli);
			this.tabPage3.Controls.Add(this.dataGridCoppie);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(1078, 582);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Matching";
			// 
			// buttonSuccProvincia
			// 
			this.buttonSuccProvincia.Location = new System.Drawing.Point(544, 96);
			this.buttonSuccProvincia.Name = "buttonSuccProvincia";
			this.buttonSuccProvincia.Size = new System.Drawing.Size(32, 23);
			this.buttonSuccProvincia.TabIndex = 9;
			this.buttonSuccProvincia.Text = ">";
			this.buttonSuccProvincia.Click += new System.EventHandler(this.buttonSuccProvincia_Click);
			// 
			// buttonPrecProvincia
			// 
			this.buttonPrecProvincia.Location = new System.Drawing.Point(512, 96);
			this.buttonPrecProvincia.Name = "buttonPrecProvincia";
			this.buttonPrecProvincia.Size = new System.Drawing.Size(32, 23);
			this.buttonPrecProvincia.TabIndex = 8;
			this.buttonPrecProvincia.Text = "<";
			this.buttonPrecProvincia.Click += new System.EventHandler(this.buttonPrecProvincia_Click);
			// 
			// buttonAccoppia
			// 
			this.buttonAccoppia.Enabled = false;
			this.buttonAccoppia.Location = new System.Drawing.Point(744, 96);
			this.buttonAccoppia.Name = "buttonAccoppia";
			this.buttonAccoppia.TabIndex = 7;
			this.buttonAccoppia.Text = "<- Accoppia";
			this.buttonAccoppia.Click += new System.EventHandler(this.buttonAccoppia_Click);
			// 
			// buttonDisaccoppia
			// 
			this.buttonDisaccoppia.Enabled = false;
			this.buttonDisaccoppia.Location = new System.Drawing.Point(128, 96);
			this.buttonDisaccoppia.Name = "buttonDisaccoppia";
			this.buttonDisaccoppia.TabIndex = 6;
			this.buttonDisaccoppia.Text = "Disaccoppia ->";
			this.buttonDisaccoppia.Click += new System.EventHandler(this.buttonDisaccoppia_Click);
			// 
			// labelProvinciaCorrente
			// 
			this.labelProvinciaCorrente.Location = new System.Drawing.Point(344, 96);
			this.labelProvinciaCorrente.Name = "labelProvinciaCorrente";
			this.labelProvinciaCorrente.TabIndex = 5;
			this.labelProvinciaCorrente.Text = "Provincia";
			// 
			// comboBoxProvincia
			// 
			this.comboBoxProvincia.DataSource = this.DS.province_selezionate;
			this.comboBoxProvincia.DisplayMember = "sigla";
			this.comboBoxProvincia.Location = new System.Drawing.Point(448, 96);
			this.comboBoxProvincia.MaxDropDownItems = 30;
			this.comboBoxProvincia.Name = "comboBoxProvincia";
			this.comboBoxProvincia.Size = new System.Drawing.Size(64, 21);
			this.comboBoxProvincia.TabIndex = 4;
			this.comboBoxProvincia.Tag = "";
			this.comboBoxProvincia.ValueMember = "idprovincia";
			this.comboBoxProvincia.SelectedIndexChanged += new System.EventHandler(this.comboBoxProvincia_SelectedIndexChanged);
			// 
			// dataGridSingle2
			// 
			this.dataGridSingle2.DataMember = "";
			this.dataGridSingle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridSingle2.Location = new System.Drawing.Point(768, 136);
			this.dataGridSingle2.Name = "dataGridSingle2";
			this.dataGridSingle2.RowHeaderWidth = 0;
			this.dataGridSingle2.Size = new System.Drawing.Size(300, 430);
			this.dataGridSingle2.TabIndex = 3;
			this.dataGridSingle2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridSingle2_MouseUp);
			this.dataGridSingle2.CurrentCellChanged += new System.EventHandler(this.dataGridSingle2_CurrentCellChanged);
			// 
			// dataGridSingle1
			// 
			this.dataGridSingle1.DataMember = "";
			this.dataGridSingle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridSingle1.Location = new System.Drawing.Point(456, 136);
			this.dataGridSingle1.Name = "dataGridSingle1";
			this.dataGridSingle1.RowHeaderWidth = 0;
			this.dataGridSingle1.Size = new System.Drawing.Size(300, 430);
			this.dataGridSingle1.TabIndex = 2;
			this.dataGridSingle1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridSingle1_MouseUp);
			this.dataGridSingle1.CurrentCellChanged += new System.EventHandler(this.dataGridSingle1_CurrentCellChanged);
			// 
			// dataGridDettagli
			// 
			this.dataGridDettagli.DataMember = "";
			this.dataGridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridDettagli.Location = new System.Drawing.Point(8, 16);
			this.dataGridDettagli.Name = "dataGridDettagli";
			this.dataGridDettagli.RowHeaderWidth = 0;
			this.dataGridDettagli.Size = new System.Drawing.Size(1056, 64);
			this.dataGridDettagli.TabIndex = 1;
			// 
			// dataGridCoppie
			// 
			this.dataGridCoppie.DataMember = "";
			this.dataGridCoppie.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridCoppie.Location = new System.Drawing.Point(8, 136);
			this.dataGridCoppie.Name = "dataGridCoppie";
			this.dataGridCoppie.RowHeaderWidth = 0;
			this.dataGridCoppie.Size = new System.Drawing.Size(430, 430);
			this.dataGridCoppie.TabIndex = 0;
			this.dataGridCoppie.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridCoppie_MouseUp);
			this.dataGridCoppie.CurrentCellChanged += new System.EventHandler(this.dataGridCoppie_CurrentCellChanged);
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.dataGridLogScrittura);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(1078, 582);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Scrittura sul database";
			// 
			// dataGridLogScrittura
			// 
			this.dataGridLogScrittura.DataMember = "";
			this.dataGridLogScrittura.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridLogScrittura.Location = new System.Drawing.Point(8, 8);
			this.dataGridLogScrittura.Name = "dataGridLogScrittura";
			this.dataGridLogScrittura.Size = new System.Drawing.Size(1064, 560);
			this.dataGridLogScrittura.TabIndex = 0;
			// 
			// btnBack
			// 
			this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnBack.Location = new System.Drawing.Point(480, 616);
			this.btnBack.Name = "btnBack";
			this.btnBack.TabIndex = 3;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnNext.Location = new System.Drawing.Point(568, 616);
			this.btnNext.Name = "btnNext";
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.button2_Click);
			// 
			// images
			// 
			this.images.ImageSize = new System.Drawing.Size(30, 30);
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// checkBoxImpCorrezioneDataInizio
			// 
			this.checkBoxImpCorrezioneDataInizio.Location = new System.Drawing.Point(728, 88);
			this.checkBoxImpCorrezioneDataInizio.Name = "checkBoxImpCorrezioneDataInizio";
			this.checkBoxImpCorrezioneDataInizio.Size = new System.Drawing.Size(232, 24);
			this.checkBoxImpCorrezioneDataInizio.TabIndex = 33;
			this.checkBoxImpCorrezioneDataInizio.Tag = "geo_importazione_dati.correzione_datainizio_1960_01_01:S:N";
			this.checkBoxImpCorrezioneDataInizio.Text = "correzione data inizio \'1960-01-01\'->null";
			// 
			// frmGeo_comune
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1102, 656);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.tabController);
			this.Controls.Add(this.btnBack);
			this.Name = "frmGeo_comune";
			this.Text = "Form1";
			this.tabController.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrimaProvincia)).EndInit();
			this.MetaDataDetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuanteProvince)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridImportazione)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridGeoComune)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridDatiCorretti)).EndInit();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridSingle2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSingle1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridDettagli)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridCoppie)).EndInit();
			this.tabPage5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridLogScrittura)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink()
		{
			MetaData meta = MetaData.GetMetaData(this); 
			tabelle = new Tabelle(meta, DS, dataGridDettagli, comboBoxProvincia);
			numericUpDownPrimaProvincia.Maximum = comboBoxProvinciaIniziale.Items.Count - 1;
			numericUpDownQuanteProvince.Maximum = comboBoxProvinciaIniziale.Items.Count - comboBoxProvinciaIniziale.SelectedIndex;
			visualizzaProvinceSelezionate();
			StandardChangeTab(0);
		}

		public void MetaData_AfterRowSelect(DataTable t, DataRow r)
		{
			labelImportazioneSelezionata.Text = "Tabella selezionata: "+r["nome_importazione"];
			labelTabellaDaImportare.Text = "Tabella "+r["tabella_sorgente"];
		}

		private void eseguiMatching() 
		{
			this.Cursor = Cursors.WaitCursor;

			DS.tutte_le_coppie.Clear();
			DS.tutti_i_single1.Clear();
			DS.tutti_i_single2.Clear();
			
			for (int h = 0; h < DS.province_selezionate.Rows.Count; h++) 
			{
				vistaForm.province_selezionateRow rProvincia = (vistaForm.province_selezionateRow) DS.province_selezionate.Rows[h];
				Console.WriteLine(rProvincia.idprovincia+" "+rProvincia.sigla);
				ArrayList coppie = new ArrayList();
				DataRow[] rComuniDaImportare = DS.geo_comuni_da_importare.Select("idprovincia="+rProvincia.idprovincia
					);
				vistaForm.geo_comuneRow[] geoComuniDiUnaProvincia = (vistaForm.geo_comuneRow[]) DS.geo_city.Select("idcountry="+rProvincia.idprovincia
					);
				for (int i=0; i<rComuniDaImportare.Length; i++) {
					vistaForm.geo_comuni_da_importareRow rComuneDaImportare = (vistaForm.geo_comuni_da_importareRow) rComuniDaImportare[i]; 
//					string nomeComuneDaImportare = Matching.eliminaAccenti(rComuneDaImportare.nome);

					bool[] geoComuniNuovi = new bool[geoComuniDiUnaProvincia.Length];
					for (int j=0; j<geoComuniDiUnaProvincia.Length; j++) 
					{
						vistaForm.geo_comuneRow geoComune = (vistaForm.geo_comuneRow) geoComuniDiUnaProvincia[j];
						geoComuniNuovi[j] = tabelle.isGeoComuneNuovo(geoComune);
					}

					int[] valoriDiMatching = new int[geoComuniDiUnaProvincia.Length];

					Matching.confrontaComuneDaImportareConGeoComuni ( 
						tabelle, 
						rComuneDaImportare,
						geoComuniDiUnaProvincia,
						out valoriDiMatching
						);

					for (int j=0; j<geoComuniDiUnaProvincia.Length; j++) 
					{
						if (valoriDiMatching[j]<=Matching.MASSIMO_ACCETTABILE)
						{
							vistaForm.geo_comuneRow rGeoComune = (vistaForm.geo_comuneRow) geoComuniDiUnaProvincia[j];
							coppie.Add(new int[] {valoriDiMatching[j], i, j});
						}
					}
				}
				int[] partnerDiTabInGeo;
				int[] partnerDiGeoInTab;
				Matching.getCoppie (
					tabelle,
					rProvincia.sigla,
					coppie,
					rComuniDaImportare,
					geoComuniDiUnaProvincia,
					out partnerDiTabInGeo,
					out partnerDiGeoInTab
				);
			}
			selezionaLaProvincia();
			this.Cursor = null;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			StandardChangeTab(+1);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			StandardChangeTab(-1);
		}

		/// <summary>
		/// Changes tab backward/forward
		/// </summary>
		/// <param name="step"></param>
		void StandardChangeTab(int step) 
		{
			int oldTab= tabController.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>tabController.TabPages.Count))return;
			if (!CustomChangeTab(oldTab,newTab))return;
			if (newTab==tabController.TabPages.Count) 
			{
				DialogResult= DialogResult.OK;
				return;
			}
			DisplayTabs(newTab);
		}



		/// <summary>
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool CustomChangeTab(int oldTab, int newTab) 
		{
			//if (oldTab==0) 	return true ; // 0->1: nothing to do
			if ((oldTab==1)&&(newTab==0)) 
			{
				btnNext.Enabled=true;
				return true; //1->0:nothing to do!
			}
			if ((oldTab==0)&&(newTab==1)) 
			{
				eseguiLettura();
				return true;
			}
			if ((oldTab==1)&&(newTab==2)) 
			{
				eseguiMatching();
				return true;
			}
			if ((oldTab==2)&&(newTab==3)) 
			{
				eseguiVisualizzazioneLog();
				return true;
			}
			if ((oldTab==3)&&(newTab==4)) 
			{
				eseguiScrittura();
				return true;
			}
			return true;
		}
		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab) 
		{
			tabController.SelectedIndex= newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Fine.";
			else
				btnNext.Text="Avanti >";
			Text = CustomTitle+ " (Pagina "+(newTab+1)+" di "+tabController.TabPages.Count+")";
		}

		public void eseguiLettura() 
		{
			this.Cursor = Cursors.WaitCursor;
			visualizzaProvinceSelezionate();
			labelProvinceSelezionate.Refresh();
			tabelle.letturaTabelle(this, dataGridDatiCorretti, dataGridGeoComune);
			this.Cursor = null;
		}

		private void comboBoxProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			selezionaLaProvincia();
		}

		private void selezionaLaProvincia() 
		{
			labelProvinciaCorrente.Text = "Provincia "+comboBoxProvincia.SelectedValue;
			buttonSuccProvincia.Enabled = (comboBoxProvincia.SelectedIndex < comboBoxProvincia.Items.Count-1);
			buttonPrecProvincia.Enabled = (comboBoxProvincia.SelectedIndex > 0);

			if (comboBoxProvincia.SelectedValue!=null) 
			{
				int idProvincia = (int) comboBoxProvincia.SelectedValue;
				tabelle.setProvincia ( 
					idProvincia,
					dataGridCoppie,
					dataGridSingle1,
					dataGridSingle2
					);
			}
		}

		private void selezionaUnaCoppiaNelGrid(int id1, int id2) 
		{
			DataRowView cRowView = (DataRowView) dataGridCoppie.BindingContext[DS, dataGridCoppie.DataMember].Current;
			DataView coppieView = cRowView.DataView;
			for (int i=0; i<coppieView.Count; i++) 
			{
				DataRowView coppieRowView = coppieView[i];
				vistaForm.coppie_della_provincia_correnteRow rCoppie = (vistaForm.coppie_della_provincia_correnteRow) coppieRowView.Row;
				if ((rCoppie.idcomune1==id1)&&(rCoppie.idcomune2==id2)) 
				{
					dataGridCoppie.Select(i);
					return;
				}
			}
		}

		private void selezionaUnSingle1NelGrid(int id1) 
		{
			DataRowView s1RowView = (DataRowView) dataGridSingle1.BindingContext[DS, dataGridSingle1.DataMember].Current;
			DataView single1View = s1RowView.DataView;
			for (int i=0; i<single1View.Count; i++) 
			{
				DataRowView single1RowView = single1View[i];
				vistaForm.single1_della_provincia_correnteRow rSingle1 = (vistaForm.single1_della_provincia_correnteRow) single1RowView.Row;
				if (rSingle1.idcomune==id1) 
				{
					dataGridSingle1.Select(i);
					return;
				}
			}
		}

		private void selezionaUnSingle2NelGrid(int id2) 
		{
			DataRowView s2RowView = (DataRowView) dataGridSingle2.BindingContext[DS, dataGridSingle2.DataMember].Current;
			DataView single2View = s2RowView.DataView;
			for (int i=0; i<single2View.Count; i++) 
			{
				DataRowView single2RowView = single2View[i];
				vistaForm.single2_della_provincia_correnteRow rSingle2 = (vistaForm.single2_della_provincia_correnteRow) single2RowView.Row;
				if (rSingle2.idcomune==id2) 
				{
					dataGridSingle2.Select(i);
					return;
				}
			}
		}

		private void buttonSuccProvincia_Click(object sender, System.EventArgs e)
		{
			comboBoxProvincia.SelectedIndex ++;
			if (comboBoxProvincia.SelectedIndex==comboBoxProvincia.Items.Count-1) buttonSuccProvincia.Enabled = false;
		}

		private void buttonPrecProvincia_Click(object sender, System.EventArgs e)
		{
			comboBoxProvincia.SelectedIndex --;
			if (comboBoxProvincia.SelectedIndex==0) buttonPrecProvincia.Enabled = false;
		}

		private void buttonDisaccoppia_Click(object sender, System.EventArgs e)
		{
			buttonDisaccoppia.Enabled = false;
			int id1, id2;
			tabelle.disaccoppiaLaCoppiaContenutaInDettagli(out id1, out id2);
			dataGridCoppie.UnSelect(dataGridCoppie.CurrentRowIndex);
			selezionaUnSingle1NelGrid(id1);
			selezionaUnSingle2NelGrid(id2);
			buttonAccoppia.Enabled = true;
		}

		private void buttonAccoppia_Click(object sender, System.EventArgs e)
		{
			buttonAccoppia.Enabled = false;
			int id1, id2;
			tabelle.accoppiaIDueSingleContenutiInDettagli(out id1, out id2);
			if (dataGridSingle1.CurrentRowIndex >= 0) 
			{
				dataGridSingle1.UnSelect(dataGridSingle1.CurrentRowIndex);
			}
			if (dataGridSingle2.CurrentRowIndex >= 0) 
			{
				dataGridSingle2.UnSelect(dataGridSingle2.CurrentRowIndex);
			}
			selezionaUnaCoppiaNelGrid(id1, id2);
			buttonDisaccoppia.Enabled= true;
		}

		private DataRow getRigaCorrenteDalGrid(DataGrid grid) 
		{
			string dataMember = grid.DataMember;
			DataRowView rowView = (DataRowView) grid.BindingContext[DS, dataMember].Current;
			return rowView.Row;

		}

		private void selezionaUnaCoppia() 
		{
			DataRow rCoppia = getRigaCorrenteDalGrid(dataGridCoppie);
			int id1 = tabelle.getIdComune1DaCoppia(rCoppia);
			int id2 = tabelle.getIdComune2DaCoppia(rCoppia);
			if (tabelle.inserisciUnaCoppiaNeiDettagli(id1, id2))
			{
				buttonAccoppia.Enabled = false;
				new formatgrids(dataGridDettagli).AutosizeColumnWidth();
				dataGridCoppie.Select(dataGridCoppie.CurrentRowIndex);
				for (int i=0; i<DS.single1_della_provincia_corrente.Rows.Count; i++)
					dataGridSingle1.UnSelect(i);
				for (int i=0; i<DS.single2_della_provincia_corrente.Rows.Count; i++)
					dataGridSingle2.UnSelect(i);
				buttonDisaccoppia.Enabled = true;
			}
		}


		private void selezionaUnSingle1() 
		{
			DataRow rSingle1 = getRigaCorrenteDalGrid(dataGridSingle1);
			int id1 = tabelle.getIdComuneDaSingle1(rSingle1);
			if (tabelle.inserisciUnSingle1NeiDettagli(id1, dataGridSingle1.CurrentRowIndex)) 
			{
				buttonDisaccoppia.Enabled = false;
				new formatgrids(dataGridDettagli).AutosizeColumnWidth();
				dataGridSingle1.Select(dataGridSingle1.CurrentRowIndex);
				for (int i=0; i<DS.coppie_della_provincia_corrente.Rows.Count; i++)
					dataGridCoppie.UnSelect(i);
				buttonAccoppia.Enabled = tabelle.isValidSingle2();
			}
		}

		private void selezionaUnSingle2() 
		{
			DataRow rSingle2 = getRigaCorrenteDalGrid(dataGridSingle2);
			int id2 = tabelle.getIdComuneDaSingle2(rSingle2);
			if (tabelle.inserisciUnSingle2NeiDettagli(id2, dataGridSingle2.CurrentRowIndex)) 
			{
				buttonDisaccoppia.Enabled = false;
				new formatgrids(dataGridDettagli).AutosizeColumnWidth();
				dataGridSingle2.Select(dataGridSingle2.CurrentRowIndex);
				for (int i=0; i<DS.coppie_della_provincia_corrente.Rows.Count; i++)
					dataGridCoppie.UnSelect(i);
				buttonAccoppia.Enabled = tabelle.isValidSingle1();
			}
		}

		private void dataGridCoppie_CurrentCellChanged(object sender, System.EventArgs e)
		{
			selezionaUnaCoppia();
		}


		private void dataGridCoppie_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dataGridCoppie.CurrentRowIndex>=0) 
			{
				selezionaUnaCoppia();
			}
		}

		private void dataGridSingle1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			selezionaUnSingle1();
		}

		private void dataGridSingle1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dataGridSingle1.CurrentRowIndex>=0) 
			{
				selezionaUnSingle1();
			}
		}

		private void dataGridSingle2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			selezionaUnSingle2();
		}

		private void dataGridSingle2_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dataGridSingle2.CurrentRowIndex>=0) 
			{
				selezionaUnSingle2();
			}
		}

		private void comboBoxProvinciaIniziale_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			Console.WriteLine("comboBoxProvinciaIniziale_SelectedIndexChanged");
			numericUpDownPrimaProvincia.Value = comboBoxProvinciaIniziale.SelectedIndex;
			numericUpDownQuanteProvince.Maximum = comboBoxProvinciaIniziale.Items.Count - comboBoxProvinciaIniziale.SelectedIndex;
			visualizzaProvinceSelezionate();
		}

		private void numericUpDownQuanteProvince_ValueChanged(object sender, System.EventArgs e)
		{
			visualizzaProvinceSelezionate();
		}

		private void visualizzaProvinceSelezionate() 
		{
			if (occupato) 
			{
				return;
			}
			occupato = true;
			DataRowView selectedItem = (DataRowView) comboBoxProvinciaIniziale.SelectedItem;
			StringBuilder sbSigle = new StringBuilder();
			StringBuilder sbIdProv = new StringBuilder();
			DS.province_selezionate.Clear();

			int primaProvincia = Convert.ToInt16(numericUpDownPrimaProvincia.Value);
			int quanteProvince = Convert.ToInt16(numericUpDownQuanteProvince.Value);
//			Console.WriteLine("A partire dalla "+primaProvincia+"ª, leggo "+quanteProvince+" province");
			for (int i = primaProvincia; 
				i < primaProvincia + quanteProvince; 
				i++
				) 
			{
				vistaForm.province_selezionateRow newRow = (vistaForm.province_selezionateRow) DS.province_selezionate.NewRow();
				newRow.idprovincia = Convert.ToInt16(DS.geo_country.Rows[i]["idcountry"]);
				newRow.sigla = DS.geo_country.Rows[i]["province"].ToString();
				DS.province_selezionate.Addprovince_selezionateRow(newRow);
				sbSigle.Append(","+newRow.sigla);
				sbIdProv.Append(","+newRow.idprovincia);
			}
			DS.province_selezionate.AcceptChanges();
			string sigleProvince = sbSigle.ToString().Remove(0,1);
			labelProvinceSelezionate.Text = "Province selezionate: "+sigleProvince;
			string idProvince = sbIdProv.ToString().Remove(0,1);
			tabelle.setProvinceSelezionate(idProvince);
			occupato = false;
		}


		private void eseguiVisualizzazioneLog() 
		{
			this.Cursor = Cursors.WaitCursor;
			tabelle.aggiungiLeCoppieEISingle1AlDB(this, dataGridLogScrittura); 
			this.Cursor = null;
		}

		private void eseguiScrittura() 
		{
			MetaData meta = MetaData.GetMetaData(this); 
			PostData postData = new PostData();
			postData.InitClass(DS, meta.Conn);
			if (postData.DO_POST()) 
			{
				MessageBox.Show("Comuni importati con successo");
			} 
			else 
			{
				MessageBox.Show("Errore durante la scrittura sul db");
			}
		}

		private void numericUpDownPrimaProvincia_ValueChanged(object sender, System.EventArgs e)
		{
//			Console.WriteLine("numericUpDownPrimaProvincia_ValueChanged");
			decimal valore = numericUpDownPrimaProvincia.Value;
			comboBoxProvinciaIniziale.SelectedIndex = Convert.ToInt16(valore);
		}

		private void tabController_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			StandardChangeTab(0);
		}

	}
}
