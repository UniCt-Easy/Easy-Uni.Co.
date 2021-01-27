
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using gestioneclassificazioni;
using movimentofunctions;
using ep_functions;
//using spesa_automatismi;

namespace taxpay_wiz_liquidperiodica //liquidazioneritenuta//
{
    /// <summary>
    /// Summary description for frmliquidazioneritenuta.
    /// </summary>
    public class Frm_taxpay_wiz_liquidperiodica : System.Windows.Forms.Form {
        //private string elencoSpeseDaLiquidare;
        private string elencoSpeseDaLiquidareRit;
        private string elencoSpeseDaLiquidareCor;
        private string CustomTitle = "Calcolo Liquidazione";

        DataTable tErrorLiq;
        DataTable tErrorFin;
        DataTable tAppGroupLiq;
        DataTable tAppGroupFin;

        Hashtable hAppGroupLiq = new Hashtable();
        Hashtable hAppGroupFin = new Hashtable();
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public vistaForm DS;
        private System.Windows.Forms.Label label6;
        MetaData Meta;
        DataAccess Conn;
        string esercizio;
        bool CanSave;
        DataTable SP_Result;
        DateTime datainizioform, datainiziodati, datafine;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbRitenuta;
        private System.Windows.Forms.TextBox txtDataInizio;
        private System.Windows.Forms.TextBox txtDataFine;
        private System.Windows.Forms.DataGrid gridMovSpesa;
        private System.Windows.Forms.Button btnScollegaS;
        private System.Windows.Forms.Button btnCollegaS;
        int maxfasespesa;
        Hashtable RighePadri;
        private System.Windows.Forms.DataGrid dgDettaglioRitenute;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtIniziale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtImporto2;
        private System.Windows.Forms.TextBox txtImporto1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSelezionaTutto;
        private System.Windows.Forms.Button btnCambiaBilancio;

       

        QueryHelper QHS;
        CQueryHelper QHC;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public Frm_taxpay_wiz_liquidperiodica() {
            InitializeComponent();

            RighePadri = new Hashtable();

            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
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
        private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_taxpay_wiz_liquidperiodica));
			this.label2 = new System.Windows.Forms.Label();
			this.cmbRitenuta = new System.Windows.Forms.ComboBox();
			this.DS = new taxpay_wiz_liquidperiodica.vistaForm();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.gridMovSpesa = new System.Windows.Forms.DataGrid();
			this.label6 = new System.Windows.Forms.Label();
			this.txtImporto2 = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnScollegaS = new System.Windows.Forms.Button();
			this.btnCollegaS = new System.Windows.Forms.Button();
			this.dgDettaglioRitenute = new System.Windows.Forms.DataGrid();
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
			this.txtIniziale = new System.Windows.Forms.TextBox();
			this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
			this.btnSelezionaTutto = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtImporto1 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
			this.btnCambiaBilancio = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridMovSpesa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgDettaglioRitenute)).BeginInit();
			this.tabController.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(381, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ritenuta:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbRitenuta
			// 
			this.cmbRitenuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbRitenuta.DataSource = this.DS.tax;
			this.cmbRitenuta.DisplayMember = "description";
			this.cmbRitenuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRitenuta.Location = new System.Drawing.Point(459, 32);
			this.cmbRitenuta.MaxDropDownItems = 40;
			this.cmbRitenuta.Name = "cmbRitenuta";
			this.cmbRitenuta.Size = new System.Drawing.Size(648, 23);
			this.cmbRitenuta.TabIndex = 2;
			this.cmbRitenuta.Tag = "";
			this.cmbRitenuta.ValueMember = "taxcode";
			this.cmbRitenuta.SelectedIndexChanged += new System.EventHandler(this.cmbRitenuta_SelectedIndexChanged);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 21);
			this.label3.TabIndex = 3;
			this.label3.Text = "Periodo dal:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(140, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(24, 21);
			this.label4.TabIndex = 4;
			this.label4.Text = "al:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(82, 31);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.ReadOnly = true;
			this.txtDataInizio.Size = new System.Drawing.Size(60, 23);
			this.txtDataInizio.TabIndex = 5;
			// 
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(170, 32);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.ReadOnly = true;
			this.txtDataFine.Size = new System.Drawing.Size(64, 23);
			this.txtDataFine.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(1127, 20);
			this.label5.TabIndex = 7;
			this.label5.Text = "Se l\'operazione viene confermata verranno generati i seguenti movimenti di contab" +
    "ilità finanziaria.";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gridMovSpesa
			// 
			this.gridMovSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridMovSpesa.DataMember = "";
			this.gridMovSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridMovSpesa.Location = new System.Drawing.Point(8, 32);
			this.gridMovSpesa.Name = "gridMovSpesa";
			this.gridMovSpesa.Size = new System.Drawing.Size(1099, 408);
			this.gridMovSpesa.TabIndex = 8;
			this.gridMovSpesa.Paint += new System.Windows.Forms.PaintEventHandler(this.gridMovSpesa_Paint);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.Location = new System.Drawing.Point(8, 448);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 9;
			this.label6.Text = "Importo:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImporto2
			// 
			this.txtImporto2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtImporto2.Location = new System.Drawing.Point(64, 444);
			this.txtImporto2.Name = "txtImporto2";
			this.txtImporto2.ReadOnly = true;
			this.txtImporto2.Size = new System.Drawing.Size(120, 23);
			this.txtImporto2.TabIndex = 10;
			this.txtImporto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(600, 524);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(72, 23);
			this.btnAnnulla.TabIndex = 17;
			this.btnAnnulla.Text = "Chiudi";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(656, 444);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(64, 23);
			this.btnOK.TabIndex = 16;
			this.btnOK.Tag = "";
			this.btnOK.Text = "Salva";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnScollegaS
			// 
			this.btnScollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnScollegaS.Enabled = false;
			this.btnScollegaS.Location = new System.Drawing.Point(376, 444);
			this.btnScollegaS.Name = "btnScollegaS";
			this.btnScollegaS.Size = new System.Drawing.Size(136, 23);
			this.btnScollegaS.TabIndex = 19;
			this.btnScollegaS.Text = "Annulla il collegamento";
			this.btnScollegaS.Click += new System.EventHandler(this.btnScollegaS_Click);
			// 
			// btnCollegaS
			// 
			this.btnCollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCollegaS.Enabled = false;
			this.btnCollegaS.Location = new System.Drawing.Point(192, 444);
			this.btnCollegaS.Name = "btnCollegaS";
			this.btnCollegaS.Size = new System.Drawing.Size(176, 23);
			this.btnCollegaS.TabIndex = 18;
			this.btnCollegaS.Text = "Collega a movimento esistente...";
			this.btnCollegaS.Click += new System.EventHandler(this.btnCollega_Click);
			// 
			// dgDettaglioRitenute
			// 
			this.dgDettaglioRitenute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgDettaglioRitenute.DataMember = "";
			this.dgDettaglioRitenute.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDettaglioRitenute.Location = new System.Drawing.Point(8, 90);
			this.dgDettaglioRitenute.Name = "dgDettaglioRitenute";
			this.dgDettaglioRitenute.Size = new System.Drawing.Size(1099, 378);
			this.dgDettaglioRitenute.TabIndex = 20;
			this.dgDettaglioRitenute.Paint += new System.Windows.Forms.PaintEventHandler(this.dgDettaglioRitenute_Paint);
			// 
			// tabController
			// 
			this.tabController.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(0, 0);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 0;
			this.tabController.SelectedTab = this.tabPage1;
			this.tabController.Size = new System.Drawing.Size(1119, 508);
			this.tabController.TabIndex = 21;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
			// 
			// tabPage1
			// 
			this.tabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage1.Controls.Add(this.txtIniziale);
			this.tabPage1.Location = new System.Drawing.Point(0, 0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(1119, 483);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Title = "Presentazione";
			// 
			// txtIniziale
			// 
			this.txtIniziale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIniziale.Location = new System.Drawing.Point(8, 8);
			this.txtIniziale.Multiline = true;
			this.txtIniziale.Name = "txtIniziale";
			this.txtIniziale.ReadOnly = true;
			this.txtIniziale.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtIniziale.Size = new System.Drawing.Size(1099, 464);
			this.txtIniziale.TabIndex = 0;
			this.txtIniziale.Text = resources.GetString("txtIniziale.Text");
			// 
			// tabPage2
			// 
			this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage2.Controls.Add(this.btnSelezionaTutto);
			this.tabPage2.Controls.Add(this.dgDettaglioRitenute);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.cmbRitenuta);
			this.tabPage2.Controls.Add(this.txtDataFine);
			this.tabPage2.Controls.Add(this.txtImporto1);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.txtDataInizio);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Location = new System.Drawing.Point(0, 0);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Selected = false;
			this.tabPage2.Size = new System.Drawing.Size(1119, 483);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Title = "Ritenute da liquidare";
			// 
			// btnSelezionaTutto
			// 
			this.btnSelezionaTutto.Location = new System.Drawing.Point(8, 60);
			this.btnSelezionaTutto.Name = "btnSelezionaTutto";
			this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
			this.btnSelezionaTutto.TabIndex = 24;
			this.btnSelezionaTutto.Text = "Seleziona tutto";
			this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(100, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(791, 23);
			this.label8.TabIndex = 23;
			this.label8.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più ritenute da liquidare";
			// 
			// txtImporto1
			// 
			this.txtImporto1.Location = new System.Drawing.Point(302, 32);
			this.txtImporto1.Name = "txtImporto1";
			this.txtImporto1.ReadOnly = true;
			this.txtImporto1.Size = new System.Drawing.Size(82, 23);
			this.txtImporto1.TabIndex = 22;
			this.txtImporto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(240, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 21);
			this.label7.TabIndex = 21;
			this.label7.Text = "Importo:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabPage3
			// 
			this.tabPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage3.Controls.Add(this.btnCambiaBilancio);
			this.tabPage3.Controls.Add(this.gridMovSpesa);
			this.tabPage3.Controls.Add(this.btnScollegaS);
			this.tabPage3.Controls.Add(this.btnCollegaS);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.label6);
			this.tabPage3.Controls.Add(this.txtImporto2);
			this.tabPage3.Controls.Add(this.btnOK);
			this.tabPage3.Location = new System.Drawing.Point(0, 0);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Selected = false;
			this.tabPage3.Size = new System.Drawing.Size(1119, 483);
			this.tabPage3.TabIndex = 5;
			this.tabPage3.Title = "Liquidazione";
			// 
			// btnCambiaBilancio
			// 
			this.btnCambiaBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCambiaBilancio.Location = new System.Drawing.Point(520, 444);
			this.btnCambiaBilancio.Name = "btnCambiaBilancio";
			this.btnCambiaBilancio.Size = new System.Drawing.Size(128, 23);
			this.btnCambiaBilancio.TabIndex = 20;
			this.btnCambiaBilancio.Text = "Cambia Voce Bilancio";
			this.btnCambiaBilancio.Click += new System.EventHandler(this.btnCambiaBilancio_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBack.Location = new System.Drawing.Point(312, 524);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(75, 23);
			this.btnBack.TabIndex = 22;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNext.Location = new System.Drawing.Point(408, 524);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 23;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.tabController);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1119, 508);
			this.panel1.TabIndex = 24;
			// 
			// Frm_taxpay_wiz_liquidperiodica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1135, 554);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnAnnulla);
			this.Name = "Frm_taxpay_wiz_liquidperiodica";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmliquidazioneritenuta";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridMovSpesa)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgDettaglioRitenute)).EndInit();
			this.tabController.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private EP_Manager EPM;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            this.Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            esercizio = Meta.GetSys("esercizio").ToString();
            DS.tax.ExtendedProperties["sort_by"] = "description";
            string filter = QHS.AppAnd(QHS.NullOrEq("active", 'S'), QHS.IsNull("maintaxcode"));
            string filterDaPagare = GetRitenutedapagare(filter);
            GetData.CacheTable(DS.tax, filterDaPagare, null, true);
            GetData.CacheTable(DS.expensephase);
            GetData.SetSorting(DS.expenseview, "ymov desc, nmov desc");
            string filteresercizio = QHS.CmpEq("ayear", esercizio);
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            CanSave = false;
            tErrorLiq = new DataTable();
            tErrorLiq.Columns.Add("nrow");
            tErrorLiq.Columns.Add("description");

            tErrorFin = new DataTable();
            tErrorFin.Columns.Add("nrow");
            tErrorFin.Columns.Add("description");

            tAppGroupLiq = new DataTable();
            tAppGroupLiq.Columns.Add("taxcode");
            tAppGroupLiq.Columns.Add("idcity");
            tAppGroupLiq.Columns.Add("idfiscaltaxregion");
            tAppGroupLiq.Columns.Add("fiscaltaxcode");
            tAppGroupLiq.Columns.Add("amount", typeof (decimal));
            tAppGroupLiq.Columns.Add("ayear", typeof (int));
            tAppGroupLiq.Columns.Add("id", typeof (int));
            tAppGroupLiq.Columns.Add("refmonth", typeof (int));

            tAppGroupFin = new DataTable();
            tAppGroupFin.Columns.Add("taxcode");
            tAppGroupFin.Columns.Add("idreg");
            tAppGroupFin.Columns.Add("idfin", typeof (int));
            tAppGroupFin.Columns.Add("idupb");
            tAppGroupFin.Columns.Add("idman", typeof (int));
            tAppGroupFin.Columns.Add("amount", typeof (decimal));
            tAppGroupFin.Columns.Add("id", typeof (int));

            metaMonTr = MetaData.GetDispatcher(this).Get("moneytransfer");
            metaMonTr.SetDefaults(DS.moneytransfer);

            idtres_default = Conn.DO_READ_VALUE("treasurer", QHS.CmpEq("flagdefault", "S"), "idtreasurer");
            if (idtres_default == null) {
                MessageBox.Show("E' necessario configurare un cassiere predefinito, i girofondi non saranno generati.",
                    "Errore");
                return;
            }

            //Apre il form delle ritenute non liquiodate 
            //MetaData MetaRitdapagare = MetaData.GetMetaData(this, "taxpay");
            //MetaRitdapagare.Edit(Meta.LinkedForm.ParentForm, "ritenutedapagare", false);
            //if (MetaRitdapagare.destroyed) return;


        }
        public string GetRitenutedapagare(string filter) {
            DataTable MyTax = Conn.RUN_SELECT("tax", "*", null, filter, null, false);
            DataTable MyTaxsetup = Conn.RUN_SELECT("taxsetup", "*", null, QHS.CmpEq("ayear", esercizio), null, false);
            string filter_auto = "";
            string filter_eserc = QHS.CmpEq("ayear", esercizio);
            DateTime Datainizio, Datafine;
            string myList = "";
            foreach (DataRow R in MyTax.Rows) {
                filter_auto = QHC.AppAnd(QHC.CmpEq("taxcode", R["taxcode"]), filter_eserc);
                DataRow[] Rauto = MyTaxsetup.Select(filter_auto);
                if (Rauto.Length == 0) continue;
                if (!ControllaConfRitenuta(Rauto[0])) continue;
                Datainizio = new DateTime(1, 1, 1);
                Datafine = new DateTime(1, 1, 1);
                CalcolaDateDaPeriodo(Rauto[0], out Datainizio, out Datafine);
                if (!CallStoredProcedure(R["taxcode"], Datafine)) continue;
                if (myList != "") myList += ",";
                myList += QHS.quote(R["taxcode"]);
            }
            string filterTax = QHS.FieldInList("taxcode", myList);
            return filterTax;
        }

        private bool CallStoredProcedure(object codiceritenuta, DateTime datafine) {
            DataSet Out = Conn.CallSP("compute_taxpay",
                new object[] { esercizio, codiceritenuta, datafine }, true, -1);
            if (Out == null) return false;
            if (Out.Tables.Count == 0) return false; //no answer from sp
            return (Out.Tables[0].Rows.Count > 0);
        }

        private bool CalcolaDateDaPeriodo(DataRow RigaAutRiten, out DateTime DataInizio,
    out DateTime DataFine) {

            int mesiperiodicita = CfgFn.GetNoNullInt32(RigaAutRiten["idexpirationkind"]);
            DataInizio = new DateTime(1, 1, 1);
            DataFine = new DateTime(1, 1, 1);
            if (12 % mesiperiodicita > 0) {
                // periodo non ammesso!
                return false;
            }
            int annocorrente = (int)Meta.GetSys("esercizio");
            int mesecorrente = ((DateTime)Meta.GetSys("datacontabile")).Month;
            //((DateTime)Conn.sys["datacontabile"]).Month;
            int periodocorrente = CalcolaPeriodo(mesecorrente, mesiperiodicita, RigaAutRiten);
            if (periodocorrente < 1) { // vero se tipoperiodo=P e se il periodo è il primo dell'anno
                                       // si posiziona sull'ultimo periodo dell'anno precedente
                periodocorrente = 12 / mesiperiodicita;
                annocorrente--;
            }

            int meseinizioperiodo = mesiperiodicita * (periodocorrente - 1) + 1;
            int mesefineperiodo = mesiperiodicita * periodocorrente;
            DataInizio = new DateTime(annocorrente, 1, 1);
            DataFine = new DateTime(annocorrente, mesefineperiodo,
                DateTime.DaysInMonth(annocorrente, mesefineperiodo));

            return true;
        }
        object idtres_default;

        public void MetaData_AfterClear() {
            this.Text = "Liquidazione periodica ritenuta";
        }

        public void MetaData_AfterFill() {
            this.Text = "Liquidazione periodica ritenuta";
        }


        public void MetaData_AfterActivation() {
            maxfasespesa = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
        }

/*
		void SetGridColumnCaptions(DataTable T) {
			T.Columns[0].Caption="";
			T.Columns[1].Caption="";
			T.Columns[2].Caption="Fase";
			T.Columns[3].Caption="";
			T.Columns[4].Caption="Cred./deb.";
			T.Columns[5].Caption="";
			T.Columns[6].Caption="Bilancio";
			T.Columns[7].Caption="Fondo";
			T.Columns[8].Caption="Ripartizione";
			T.Columns[9].Caption="Descrizione";
			T.Columns[10].Caption="Importo";
			T.Columns[11].Caption="";
		}
*/


        bool ControllaConfRitenuta(DataRow RigaAutRiten) {
            int flag = CfgFn.GetNoNullInt32(RigaAutRiten["flag"]);
            if ((flag & 0x08) != 0) {
                //periodo precedente
                if (RigaAutRiten["expiringday"] == DBNull.Value) return false;
                if (CfgFn.GetNoNullInt32(RigaAutRiten["expiringday"]) < 1) return false;
            }

            if (RigaAutRiten["idexpirationkind"] == DBNull.Value) return false;
            int mesiperiodicita = Convert.ToInt32(RigaAutRiten["idexpirationkind"]);
            if ((mesiperiodicita < 1) || (mesiperiodicita > 12) || (mesiperiodicita == 5) ||
                (mesiperiodicita == 7) || (mesiperiodicita == 8) || (mesiperiodicita == 9) ||
                (mesiperiodicita == 10) || (mesiperiodicita == 11))
                return false;

            return true;
        }

        /// <summary>
        /// Restituisce il n. del periodo da liquidare, es. se trimestrale, 1 indica il primo trimestre. 
        ///      0 indica il periodo precedente
        /// </summary>
        /// <param name="mese">mese corrente</param>
        /// <param name="mesiperiodicita">periodicità da considerare</param>
        /// <param name="RigaAutRiten"></param>
        /// <returns></returns>
        int CalcolaPeriodo(int mese, int mesiperiodicita, DataRow RigaAutRiten) {
            if (
                ((CfgFn.GetNoNullInt32(RigaAutRiten["flag"]) & 0x08) == 0) && //periodo corrente
                mese <= mesiperiodicita) return 1;

            int periodo = mese/mesiperiodicita;
            if (mese%mesiperiodicita > 0) periodo++;
            if ((CfgFn.GetNoNullInt32(RigaAutRiten["flag"]) & 0x08) != 0) {
                if (((DateTime) Meta.GetSys("datacontabile")).Day <=
                    CfgFn.GetNoNullInt32(RigaAutRiten["expiringday"]))
                    periodo--;
                //else
                //MessageBox.Show(this, "Avvertimento: la data di scadenza delle liquidazioni relative al periodo precedente è stata superata.\n"+
                //    "Di consequenza, la liquidazione successiva interesserà il periodo CORRENTE.\n" +
                //    "Per operare sul periodo precedente, è necessario che la data contabile non sia successiva al " +
                //    RigaAutRiten["expiringday"].ToString()+"/"+
                //    ((DateTime)Meta.GetSys("datacontabile")).Month.ToString()+"/"+
                //    ((DateTime)Meta.GetSys("datacontabile")).Year.ToString()+".", "Avvertimento");
            }
            return periodo;
        }

        bool CalcolaDateDaPeriodo(DataRow RigaAutRiten, out DateTime DataInizio, out DateTime DataInizioFORM,
            out DateTime DataFine) {
            int mesiperiodicita = Convert.ToInt32(RigaAutRiten["idexpirationkind"]);
            DataInizio = new DateTime(1, 1, 1);
            DataFine = new DateTime(1, 1, 1);
            DataInizioFORM = new DateTime(1, 1, 1);
            if (12%mesiperiodicita > 0) {
                // periodo non ammesso!
                return false;
            }
            int annocorrente = (int) Meta.GetSys("esercizio");
            int mesecorrente = ((DateTime) Meta.GetSys("datacontabile")).Month;
            int periodocorrente = CalcolaPeriodo(mesecorrente, mesiperiodicita, RigaAutRiten);
            if (periodocorrente < 1) // vero se tipoperiodo=P e se il periodo è il primo dell'anno
            {
                // si posiziona sull'ultimo periodo dell'anno precedente
                periodocorrente = 12/mesiperiodicita;
                annocorrente--;
            }

            int meseinizioperiodo = mesiperiodicita*(periodocorrente - 1) + 1;
            int mesefineperiodo = mesiperiodicita*periodocorrente;
            DataInizio = new DateTime(annocorrente, 1, 1);
            DataInizioFORM = new DateTime(annocorrente, meseinizioperiodo, 1);
            DataFine = new DateTime(annocorrente, mesefineperiodo,
                DateTime.DaysInMonth(annocorrente, mesefineperiodo));

            return true;
        }



        void AddRowToTable(DataRow R, DataTable T, string str, int i) {
            DataRow NewR = T.NewRow();
            if (T.TableName == "incomeview") {
                NewR["idinc"] = i;
            }
            if (T.TableName == "expenseview") {
                NewR["idexp"] = i;
            }

            //NewR["ymov"]=R["esercmovimento"];
            //NewR["nmov"]=R["nummovimento"];
            NewR["amount"] = R["amount"];
            NewR["nphase"] = 1;
            //NewR["phase"]=R["descfase"];
            NewR["idreg"] = R["idreg"];
            NewR["registry"] = R["registry"];
            NewR["idfin"] = R["idfin"];
            NewR["idupb"] = R["idupb"];
            //NewR["ymov"]=R["datacompetenza"];
            NewR["codefin"] = R["codefin"];
            NewR["codeupb"] = R["codeupb"];
            //NewR["idexp"]=R["idspesa"];
            //NewR["ymov"]=R["denompercipiente"];
            //NewR["ymov"]=R["localita"];
            //NewR["ymov"]=R["datacompetenza"];

            string descrmovimento = "Liquidazione periodica " + str +
                                    " - Periodo dal " + datainizioform.ToShortDateString() +
                                    " al " + datafine.ToShortDateString();
            if (R["location"] != DBNull.Value) {
                descrmovimento += " (" + R["location"].ToString() + ")";
            }
            NewR["description"] = descrmovimento;
            T.Rows.Add(NewR);
        }


        void FillTables(DataTable Automatismi) {
            MetaDataDispatcher Disp;
            Disp = Meta.Dispatcher;

            object codiceritenuta = cmbRitenuta.SelectedValue;
            DataRow[] descr = DS.tax.Select(QHC.CmpEq("taxcode", codiceritenuta));
            string descrizione = descr[0]["description"].ToString();
            txtImporto1.Text = "";
            txtImporto2.Text = "";

            DS.expenseview.Clear();
            double importoLiquidazione = 0;
            for (int i = 0; i < Automatismi.Rows.Count; i++) {
                DataRow R = Automatismi.Rows[i];
                importoLiquidazione += CfgFn.GetNoNullDouble(R["amount"]);
                AddRowToTable(R, DS.expenseview, descrizione, i);
            }
            txtImporto1.Text = importoLiquidazione.ToString("c");
            txtImporto2.Text = importoLiquidazione.ToString("c");
            MetaData MSpesaView = Disp.Get("expenseview");
            MSpesaView.DescribeColumns(DS.expenseview, "autogeneratips");

            HelpForm.SetDataGrid(gridMovSpesa, DS.expenseview);

            RicalcolaCampiCalcolati();
        }


        bool chiamaStoredProcedure() {
            object codiceritenuta = cmbRitenuta.SelectedValue;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            DataSet Out = Conn.CallSP("compute_taxpay",
                new object[] {esercizio, codiceritenuta, datafine});
            if (Out == null) return false;
            if (Out.Tables.Count == 0) return false; //no answer from sp

            //DataRow TipoRiten= DS.tax.Select("(taxcode="+
            //QueryCreator.quotedstrvalue(codiceritenuta,false)+")")[0];
            Out.Tables[0].Columns["movkind"].Caption = ""; //"Tipo movimento";
            Out.Tables[0].Columns["idreg"].Caption = ""; //"Codice cred./deb.";
            Out.Tables[0].Columns["registry"].Caption = ""; //"Denominazione";
            if (Out.Tables[0].Columns["payee_title"] != null) {
                Out.Tables[0].Columns["payee_title"].Caption = "Percipiente";
            }
            Out.Tables[0].Columns["idfin"].Caption = "";
            Out.Tables[0].Columns["departmentname"].Caption = "";
            Out.Tables[0].Columns["department"].Caption = "Dipartimento";
            Out.Tables[0].Columns["idtreasurer"].Caption = "";
            Out.Tables[0].Columns["taxref"].Caption = "";
            Out.Tables[0].Columns["tax"].Caption = "";
            Out.Tables[0].Columns["codefin"].Caption = "Codice bilancio"; //"Codice bilancio";
            Out.Tables[0].Columns["idupb"].Caption = "";
            Out.Tables[0].Columns["codeupb"].Caption = "Codice UPB"; //"Codice UPB";
            Out.Tables[0].Columns["amount"].Caption = "Importo";
            Out.Tables[0].Columns["competencydate"].Caption = "Data competenza";
            Out.Tables[0].Columns["ymov"].Caption = "Eserc.Mov.";
            Out.Tables[0].Columns["nmov"].Caption = "Num.Mov.";
            Out.Tables[0].Columns["idexp"].Caption = "";
            Out.Tables[0].Columns["sourcekind"].Caption = "";
            Out.Tables[0].Columns["city"].Caption = "Comune";
            Out.Tables[0].Columns["fiscaltaxregion"].Caption = "Regione Fiscale";
            Out.Tables[0].Columns["fiscaltaxcode"].Caption = "Codice Tributo";
            Out.Tables[0].Columns["idcity"].Caption = "";
            Out.Tables[0].Columns["idfiscaltaxregion"].Caption = "";
            Out.Tables[0].Columns["idser"].Caption = "";
            Out.Tables[0].Columns["codeser"].Caption = "Codice prestazione";
            Out.Tables[0].Columns["service"].Caption = "Prestazione";
            Out.Tables[0].Columns["taxcode"].Caption = "";
            Out.Tables[0].Columns["ayear"].Caption = "Anno Fiscale";
            Out.Tables[0].Columns["refmonth"].Caption = "Mese Riferimento";
            try {
                Out.Tables[0].Columns["idman"].Caption = "";
                Out.Tables[0].Columns["manager"].Caption = "";
            }
            catch {
            }
            int tipoapp = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("taxsetup",
                QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("taxcode", codiceritenuta)),
                "flag"));

            Out.Tables[0].Columns["location"].Caption = "";
            if ((tipoapp & 0x02) != 0) {
                object tipoente = Conn.DO_READ_VALUE("taxregionsetup",
                    QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("taxcode", codiceritenuta)),
                    "(MAX(kind))");
                if (tipoente == null) tipoente = "";
                string xx = tipoente.ToString().ToUpper();
                if (xx == "R") Out.Tables[0].Columns["location"].Caption = "Regione";
                if (xx == "P") Out.Tables[0].Columns["location"].Caption = "Provincia";
                //if (xx == "E") Out.Tables[0].Columns["location"].Caption = "Stato";
            }
            Out.Tables[0].AcceptChanges();
            elencoSpeseDaLiquidareCor = "";
            elencoSpeseDaLiquidareRit = "";
            dgDettaglioRitenute.TableStyles.Clear();

            HelpForm.SetDataGrid(dgDettaglioRitenute, Out.Tables[0]);
            selezionaTuttiIDettagliRitenute();


            return true;
        }

        bool selezioneCambiata(DataTable t) {
            //string esercizio = Conn.sys["esercizio"].ToString();
//			DataSet Out=  Conn.CallSP("sp_calc_liquidritenuta", 
//				new object[] {esercizio, codiceritenuta, datainizio, datafine});
/*			DataSet Out=  Conn.CallSP("sp_calc_liquidritenuta", 
				new object[] {datainizio.Year, codiceritenuta, datainizio, datafine});
			if (Out==null) return false;
			if (Out.Tables.Count==0) return false; //no answer from sp*/
            t.Columns.Add("idmovimento", typeof (int));
            //t.Columns.Add("#", typeof(int));
            FillTables(t);
            t.Columns.Add("livsupid", typeof (int));

            SP_Result = t.Copy();

            //SP_Result.Columns.Add("idmovimento", typeof(string));
            foreach (DataRow R in SP_Result.Rows) {
                R["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["amount"]));
            }
            SP_Result.AcceptChanges();
            return true;
        }

        void AddVoceBilancio(object ID, string codbil) {
            if (ID == DBNull.Value) return;
            if (DS.fin.Select(QHC.CmpEq("idfin", ID)).Length > 0) return;
            DataRow NewBil = DS.fin.NewRow();
            NewBil["idfin"] = ID;
            NewBil["codefin"] = codbil;
            DS.fin.Rows.Add(NewBil);
            NewBil.AcceptChanges();
        }

        void AddVoceUPB(object ID, string codupb) {
            if (DS.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;
            DataRow Newupb = DS.upb.NewRow();
            Newupb["idupb"] = ID;
            Newupb["codeupb"] = codupb;
            DS.upb.Rows.Add(Newupb);
            Newupb.AcceptChanges();
        }

        void AddVoceManager(object ID, string title) {
            if (ID == DBNull.Value) return;
            if (DS.manager.Select(QHC.CmpEq("idman", ID)).Length > 0) return;
            DataRow NewMan = DS.manager.NewRow();
            NewMan["idman"] = ID;
            NewMan["title"] = title;
            DS.manager.Rows.Add(NewMan);
            NewMan.AcceptChanges();
        }


        void AddVoceCreditore(object codice, string denominazione) {
            if (codice == DBNull.Value) return;
            if (DS.registry.Select(QHC.CmpEq("idreg", codice)).Length > 0) return;
            DataRow NewCred = DS.registry.NewRow();
            NewCred["idreg"] = codice;
            NewCred["title"] = denominazione;
            DS.registry.Rows.Add(NewCred);
            NewCred.AcceptChanges();
        }

        void AddVociCollegate(DataRow SP_Row) {
            //AddVoceFase(SP_Row["codicefase"].ToString(),SP_Row["descfase"].ToString());
            AddVoceBilancio(SP_Row["idfin"],
                SP_Row["codefin"].ToString());
            AddVoceUPB(SP_Row["idupb"],
                SP_Row["codeupb"].ToString());
            AddVoceCreditore(SP_Row["idreg"],
                SP_Row["registry"].ToString());
            AddVoceManager(SP_Row["idman"],
                SP_Row["manager"].ToString());
        }



        /*
		tipomovimento            varchar(128)   NULL,
		codicefase               varchar(10)    NULL,
		descfase                 varchar(35)    NULL,
		codicecreddeb            int            NULL,
									 denominazione            varchar(50)    NULL,
		idbilancio               varchar(36)    NULL,
		codicebilancio           varchar(30)    NULL,
		codicefondo              varchar(10)    NULL,
		codiceripartizione       varchar(10)    NULL,
		importo                  float          NULL
		*/

        void FillMovimento(DataRow E_S, DataRow Auto) {
            //, string idmovimento)
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
            E_S["ymov"] = esercizio;
            //E_S["ycreation"]= esercizio;
            E_S["adate"] = DataCont;
            //E_S["fulfilled"]="N";
            //if (E_S.Table.Columns.Contains("autotaxflag"))E_S["autotaxflag"]="N";
            //if (E_S.Table.Columns.Contains("autoclawbackflag"))E_S["autoclawbackflag"]="N";

            //E_S["idman"]= Auto["codiceresponsabile"];
            E_S["idreg"] = Auto["idreg"];
            //E_S["description"]= Auto["descrizione"];
            //E_S["autokind"]= Auto["tipoautomatismo"];
            E_S["idman"] = Auto["idman"];

            //E_S["amount"]= CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
        }




        void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto) {
            ImpMov["idfin"] = Auto["idfin"];
            ImpMov["idupb"] = Auto["idupb"];
            //ImpMov[field]= Auto["codicebilancio"];
            //ImpMov[field]= Auto["codicebilpluriennale"];
            //ImpMov[field]= Auto["codicecentrospesa"];
            ImpMov["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
            ImpMov["ayear"] = Meta.GetSys("esercizio");
        }

        private int getIntSys(string nome) {
            object O = Conn.GetSys(nome);
            if (O == null) return 99;
            return Convert.ToInt32(O);
        }
        //associa idexp con il relativo dictionary int,decimal di serviceOfMov
        Dictionary<int, Dictionary<int, decimal>> serviceForIdExp = new Dictionary<int, Dictionary<int, decimal>>();
        private bool SaveData() {
            MetaData MetaSpesa = Meta.Dispatcher.Get("expense");
            MetaSpesa.SetDefaults(DS.expense);
            MetaData MetaImputazioneSpesa = Meta.Dispatcher.Get("expenseyear");
            MetaImputazioneSpesa.SetDefaults(DS.expenseyear);
            MetaData MetaSpesaLast = Meta.Dispatcher.Get("expenselast");
            MetaSpesaLast.SetDefaults(DS.expenselast);

            DS.expenseview.AcceptChanges();
            serviceForIdExp.Clear();
            DS.Tables["expense"].Clear();
            DS.taxpay.Clear();
            DS.taxpayexpense.Clear();
            DS.Tables["expenseyear"].Clear();
            DS.Tables["expenselast"].Clear();
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensesorted.Clear();
            DS.sortingkind.Clear();

            AzzeraGirofondi();

            object codiceritenuta = cmbRitenuta.SelectedValue;
            string filterRitenutaPrincipale = QHS.CmpEq("ISNULL(maintaxcode,taxcode)", codiceritenuta);
            DataTable ritenuteGruppo = DataAccess.RUN_SELECT(Meta.Conn, "tax", "taxcode", "taxcode",
                filterRitenutaPrincipale, null, null, false);
            DataRow[] descr = DS.tax.Select(QHC.CmpEq("taxcode", codiceritenuta));
            string descrizione = descr[0]["description"].ToString();

            DataRow[] Ordered_SP_Res = SP_Result.Select();

            // Crea i movimenti di spesa corredati da imputazionespesa
            // modificato da Pino il 24/1/04

            int faseCreditoreDebitoreSpesa = getIntSys("expenseregphase");
            int faseBilancioSpesa = getIntSys("expensefinphase");
            // è necessario cambiare il filtro per la lettura dei dettagli ritenute 
            // 
            if (ritenuteGruppo.Rows.Count > 0) {
                //string filtro = QHS.AppAnd(QHS.FieldIn("taxcode", ritenuteGruppo.Select()),
                //            QHS.FieldInList("idexp", elencoSpeseDaLiquidare));

                string filtroRit = QHS.AppAnd(QHS.FieldIn("taxcode", ritenuteGruppo.Select()),
                    QHS.FieldInList("idexp", elencoSpeseDaLiquidareRit));

                string filtroCor = QHS.AppAnd(QHS.FieldIn("taxcode", ritenuteGruppo.Select()),
                    QHS.FieldInList("idexp", elencoSpeseDaLiquidareCor));
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expensetax, null, filtroRit, null, true);
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expensetaxcorrige, null, filtroCor, null, true);
            }

            Meta.SetDefaults(DS.taxpay);
            DataRow NewLiquidRitenRow = Meta.Get_New_Row(null, DS.taxpay);
            double importoLiquidazione = 0;

            DataRow[] TGirof = getRighePerGirofondi().Select();
            for (int i_g = 0; i_g < TGirof.Length; i_g++) {
                DataRow AutoG = TGirof[i_g];
                decimal total = CfgFn.GetNoNullDecimal(AutoG["amount"]);
                //Per ogni ritenuta a ogni dipartimento, crea una riga girofondo
                addGirofondo(codiceritenuta, descrizione, AutoG["idtreasurer"], total);
            }
 
			for (int i = 0; i < Ordered_SP_Res.Length; i++) {
                importoLiquidazione += CfgFn.GetNoNullDouble(Ordered_SP_Res[i]["amount"]);
                DataRow Auto = Ordered_SP_Res[i];
                int idSP = CfgFn.GetNoNullInt32(Auto["#"]);
              
                AddVociCollegate(Auto);
                DataRow parentRow = null;

                string filtro = QHC.FieldInList("idexp", Auto["elencoidspese"].ToString());

                foreach (DataRow rDettaglioRitenuta in DS.expensetax.Select(filtro)) {
                    if (rDettaglioRitenuta["ytaxpay"] == DBNull.Value) {
                        rDettaglioRitenuta["ytaxpay"] = NewLiquidRitenRow["ytaxpay"];
                        rDettaglioRitenuta["ntaxpay"] = NewLiquidRitenRow["ntaxpay"];

                    }
                }

                foreach (DataRow rCorrezione in DS.expensetaxcorrige.Select(filtro)) {
                    if (rCorrezione["ytaxpay"] == DBNull.Value) {
                        rCorrezione["ytaxpay"] = NewLiquidRitenRow["ytaxpay"];
                        rCorrezione["ntaxpay"] = NewLiquidRitenRow["ntaxpay"];
                    }
                }


            foreach (DataRow rFase in DS.expensephase.Select(null, "nphase")) {

                    DS.Tables["expense"].Columns["nphase"].DefaultValue = rFase["nphase"];
                    DataRow NewSpesaRow = MetaSpesa.Get_New_Row(parentRow, DS.expense);
                    object s = NewSpesaRow["idexp"];
                    serviceForIdExp[CfgFn.GetNoNullInt32(s)] = serviceOfMov[idSP];
                    parentRow = NewSpesaRow;
                    int faseCorrente = Convert.ToInt32(rFase["nphase"]);
                   
                    FillMovimento(NewSpesaRow, Auto);

                    if (faseCorrente < faseCreditoreDebitoreSpesa) {
                        NewSpesaRow["idreg"] = DBNull.Value;
                    }

                    string descrmovimento = "Liquidazione periodica " + descrizione +
                                            " - Periodo dal " + datainizioform.ToShortDateString() +
                                            " al " + datafine.ToShortDateString();
                    if (Auto["location"] != DBNull.Value) {
                        descrmovimento += " (" + Auto["location"].ToString() + ")";
                    }
                    NewSpesaRow["description"] = descrmovimento;

				 
					if (faseCorrente == maxfasespesa) {
                        object codicecreddeb = Auto["idreg"];
                        if (codicecreddeb == DBNull.Value) {
                            MessageBox.Show(this,
                                "Errata configurazione di Imputazione ritenuta; il percipiente risulta assente\n\n" +
                                "Dati non salvati", "Errore", MessageBoxButtons.OK);
                            return false;
                        }
                        DataRow ModPagam = CfgFn.ModalitaPagamentoDefault(Conn, codicecreddeb);
                        if (ModPagam == null) {
                            MessageBox.Show(this,
                                "E' necessario che sia definita almeno una modalità di pagamento per il percipiente " +
                                "\"" + Auto["registry"].ToString() + "\"\n\n" +
                                "Dati non salvati", "Errore", MessageBoxButtons.OK);
                            return false;
                        }

                        Auto["idmovimento"] = NewSpesaRow["idexp"];

                        DataRow NewLastMov = MetaSpesaLast.Get_New_Row(NewSpesaRow, DS.expenselast);
                        NewLastMov["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
                        NewLastMov["idpaymethod"] = ModPagam["idpaymethod"];
                        NewLastMov["iban"] = ModPagam["iban"];
                        NewLastMov["cin"] = ModPagam["cin"];
                        NewLastMov["idbank"] = ModPagam["idbank"];
                        NewLastMov["idcab"] = ModPagam["idcab"];
                        NewLastMov["cc"] = ModPagam["cc"];
                        NewLastMov["paymentdescr"] = ModPagam["paymentdescr"];
                        NewLastMov["iddeputy"] = ModPagam["iddeputy"];
                        NewLastMov["refexternaldoc"] = ModPagam["refexternaldoc"];
                        NewLastMov["biccode"] = ModPagam["biccode"];
                        NewLastMov["extracode"] = ModPagam["extracode"];
                        NewLastMov["idchargehandling"] = ModPagam["idchargehandling"];
                        if (LeggiFlagEsenteBancaPredefinita()) {
                            int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                            int flag_exemption = (CfgFn.GetNoNullInt32(NewLastMov["flag"]) & 0xF7) |
                                                 ((CfgFn.GetNoNullInt32(ModPagam["flag"]) & 1) << 3);
                            NewLastMov["flag"] = flag_exemption;
                        }
                        object idpaymethod = ModPagam["idpaymethod"];
                        string filterpaymethod = QHS.CmpEq("idpaymethod", idpaymethod);

                        DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);

                        if ((TPaymethod != null) && (TPaymethod.Rows.Count > 0)) {
                            object paymethod_allowdeputy = TPaymethod.Rows[0]["allowdeputy"];
                            object paymethod_flag = TPaymethod.Rows[0]["flag"];
                            NewLastMov["paymethod_allowdeputy"] = paymethod_allowdeputy;
                            NewLastMov["paymethod_flag"] = paymethod_flag;
                        }
                        // valorizzo l'importo del reintegro
                    }

                    DataRow NewImpMov = DS.Tables["expenseyear"].NewRow();

                    FillImputazioneMovimento(NewImpMov, Auto);
                    NewImpMov["idexp"] = NewSpesaRow["idexp"];
                    NewImpMov["ayear"] = Meta.GetSys("esercizio");

                    if (faseCorrente < faseBilancioSpesa) {
                        NewImpMov["idfin"] = DBNull.Value;
                        NewImpMov["idupb"] = DBNull.Value;
                    }
                    DS.Tables["expenseyear"].Rows.Add(NewImpMov);
                }
            }


            //Imposta il livsupid di tutte le righe per cui è necessario
            foreach (DataRow R in Ordered_SP_Res) {
                if (R["livsupid"] == DBNull.Value) continue;
                object idtolink = R["livsupid"];

                object idmov = R["idmovimento"];  

                int nfasetolink =
                    CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", idtolink), "nphase"));
                DataRow MovSel = DS.expense.Select(QHC.CmpEq("idexp", idmov))[0];
                int currfase = CfgFn.GetNoNullInt32(MovSel["nphase"]);

                while (currfase > (nfasetolink + 1)) {
                    idmov = MovSel["parentidexp"];
                    MovSel = DS.expense.Select(QHC.CmpEq("idexp", idmov))[0];
                    currfase--;
                }
                MovSel["parentidexp"] = idtolink;

            }

           //Cancella tutto ciò che non ha figli e non è di ultima fase sino a che non trova + nulla
            bool keep = true;
            while (keep) {
                keep = false;
                string filternolastphase = QHC.CmpNe("nphase", maxfasespesa);
                foreach (DataRow Parent in DS.expense.Select(filternolastphase)) {
                    object idpar = Parent["idexp"];
                    string filterchild = QHC.CmpEq("parentidexp", idpar);
                    if (DS.expense.Select(filterchild).Length == 0) {
                        string filterimp = QHC.CmpEq("idexp", Parent["idexp"]);
                        DataRow Imp = DS.expenseyear.Select(filterimp)[0];
                        Imp.Delete();
                        Parent.Delete();
                        keep = true;
                    }
                }
            }

			NewLiquidRitenRow["taxcode"] = codiceritenuta;
            //NewLiquidRitenRow["esercliquidazione"]=esercizio;
            //NewLiquidRitenRow["numliquidazione"]=MetaData.MaxFromColumn(DS.Tables["liquidazioneritenuta"],"numliquidazione")+1;
            NewLiquidRitenRow["amount"] = importoLiquidazione;
            NewLiquidRitenRow["description"] = "Liquidazione periodica " + descrizione +
                                               " - Periodo dal " + datainizioform.ToShortDateString() +
                                               " al " + datafine.ToShortDateString();

            foreach (DataRow R in DS.expense.Rows) {
                DataRow NewLiquidRiten_SpesaRow = DS.taxpayexpense.NewRow();
                NewLiquidRiten_SpesaRow["ytaxpay"] = NewLiquidRitenRow["ytaxpay"];
                NewLiquidRiten_SpesaRow["ntaxpay"] = NewLiquidRitenRow["ntaxpay"];
                NewLiquidRiten_SpesaRow["taxcode"] = NewLiquidRitenRow["taxcode"];
                NewLiquidRiten_SpesaRow["idexp"] = R["idexp"];
                NewLiquidRiten_SpesaRow["cu"] = "AAAA";
                NewLiquidRiten_SpesaRow["ct"] = DateTime.Now;
                NewLiquidRiten_SpesaRow["lu"] = "AAAAA";
                NewLiquidRiten_SpesaRow["lt"] = DateTime.Now;
                DS.taxpayexpense.Rows.Add(NewLiquidRiten_SpesaRow);
            }

            foreach (DataRow R in DS.expense.Rows) {
                R["autokind"] = 2; //versamento ritenute
                R["autocode"] = codiceritenuta;
            }

            GeneraClassificazioniRit();
            GeneraClassificazioniAutomatiche();
            //GeneraClassificazioniIndirette(); Questo lo fa già GeneraAutomatismiAfterPost

            if (VerificaGestioneGirofondi()) {
                if (MessageBox.Show(
                    "Genero i girofondi da o verso i dipartimenti a compensazione delle ritenute versate ?",
                    "Avviso", MessageBoxButtons.YesNo) != DialogResult.Yes) {
                    AzzeraGirofondi();
                }
            }

            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher,
                DS, fasespesamax, fasespesamax, "taxpay", true);
            bool res = ga.GeneraAutomatismiAfterPost(true, true);
            if (!res) {
                MessageBox.Show(this,
                    "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                return false;
            }

            //ga.GeneraClassificazioniIndirette(ga.DSP, true);
            res = ga.doPost(Meta.Dispatcher);
            bool girofondigenerati = (DS.moneytransfer.Rows.Count > 0);
            if (res) {
                DS.AcceptChanges();
                if (girofondigenerati) {
                    MessageBox.Show(this, "I Girofondi sono stati generati!");
                }
                EPM = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "taxpay");
                EPM.setForcedCurrentRow(ga.DSP.Tables["taxpay"].Rows[0]);
                EPM.beforePost();
                EPM.afterPost();
                EPM = null;
                ViewAutomatismi(ga.DSP);

                return true;
            }

            return false;
        }


     

      

        DataTable AllTipoClassMov;
        Dictionary<int, DataRow> AllTransfer = new Dictionary<int, DataRow>();

        /// <summary>
        /// Aggiunge un importo da girofondare VERSO il tesoriere specificato, sommando ad altri eventualmente già presenti
        /// </summary>
        /// <param name="codiceRitenuta"></param>
        /// <param name="descrRitenuta"></param>
        /// <param name="idtreasurer"></param>
        /// <param name="amount"></param>
        void addGirofondo(object codiceRitenuta, string descrRitenuta, object idtreasurer, decimal amount) {
            if (idtreasurer == DBNull.Value || idtres_default == null || idtres_default == DBNull.Value ||
                idtreasurer.ToString() == idtres_default.ToString())
                return;
            DataRow gf;
            if (AllTransfer.ContainsKey(CfgFn.GetNoNullInt32(idtreasurer))) {
                gf = AllTransfer[CfgFn.GetNoNullInt32(idtreasurer)];
                gf["amount"] = CfgFn.GetNoNullDecimal(gf["amount"]) + amount;
            }
            else {
                gf = metaMonTr.Get_New_Row(null, DS.moneytransfer);
                gf["amount"] = amount;
                gf["idtreasurersource"] = idtreasurer;
                gf["idtreasurerdest"] = idtres_default;

                gf["transferkind"] = "R";
                gf["description"] = "Girofondo a compensazione di liq.ritenuta " + descrRitenuta +
                                    " dal " + txtDataInizio.Text + " al " + txtDataFine.Text;
                AllTransfer[CfgFn.GetNoNullInt32(idtreasurer)] = gf;
            }

        }

        bool VerificaGestioneGirofondi() {
            bool check = false;
            foreach (DataRow r in AllTransfer.Values) {
                decimal amount = CfgFn.GetNoNullDecimal(r["amount"]);
                if (amount == 0) {
                    r.Delete();
                    continue;
                }
                check = true;
                if (amount < 0) {
                    r["amount"] = -amount;
                    object idtreas1 = r["idtreasurersource"];
                    object idtreas2 = r["idtreasurerdest"];
                    r["idtreasurerdest"] = idtreas1;
                    r["idtreasurersource"] = idtreas2;
                }
            }

            return check;
        }

        MetaData metaMonTr;

        private bool LeggiFlagEsenteBancaPredefinita() {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null,
                QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }

        void AzzeraGirofondi() {
            AllTransfer = new Dictionary<int, DataRow>();
            DS.moneytransfer.Clear();
        }

        /// <summary>
        /// Calcola le classificazioni automatiche
        /// </summary>
        /// <param name="CurrImpClass"></param>
        void CalcAutoClasses(DataRow CurrImpClass, DataRow CurrTipoClass,
            DataRow CurrMov, DataRow CurrImputazioneMov, DataTable ImpClass) {

            int currfase = CfgFn.GetNoNullInt32(CurrMov["nphase"]);
            string movtable = CurrMov.Table.TableName;
            string idmovimento = movtable == "expense" ? "idexp" : "idinc";

            object IDForSP = DBNull.Value;
            if (!Meta.InsertMode) IDForSP = CurrMov[idmovimento];

            DataSet OutDS;
            try {
                OutDS = Meta.Conn.CallSP("create_autoclasses_" + movtable,
                    new object[] {
                        Meta.GetSys("esercizio"),
                        IDForSP,
                        CurrMov["idreg"],
                        CurrImputazioneMov["idupb"],
                        currfase,
                        CurrImputazioneMov["idfin"],
                        CurrMov["idman"],
                        CurrImputazioneMov["amount"],
//									CurrTipoClass["idsorkind"],
                        CurrImpClass["idsor"],
                        CurrImpClass["idsubclass"],
                        CurrImpClass["amount"],
                        CurrImpClass["description"],
                        CurrImpClass["flagnodate"],
                        CurrImpClass["tobecontinued"],
                        CurrImpClass["start"],
                        CurrImpClass["stop"],
                        CurrImpClass["valueN1"],
                        CurrImpClass["valueN2"],
                        CurrImpClass["valueN3"],
                        CurrImpClass["valueN4"],
                        CurrImpClass["valueN5"],
                        CurrImpClass["valueS1"],
                        CurrImpClass["valueS2"],
                        CurrImpClass["valueS3"],
                        CurrImpClass["valueS4"],
                        CurrImpClass["valueS5"],
                        CurrImpClass["valueV1"],
                        CurrImpClass["valueV2"],
                        CurrImpClass["valueV3"],
                        CurrImpClass["valueV4"],
                        CurrImpClass["valueV5"]
                    });
            }
            catch (Exception E) {
                MessageBox.Show(E.Message);
                return;
            }
            if ((OutDS == null) || (OutDS.Tables.Count == 0)) return; //no autoclass

            RowChange.MarkAsAutoincrement(
                ImpClass.Columns["idsubclass"],
                null,
                null,
                7,
                false);
            //RowChange.SetSelector(ImpClass, "idsorkind");
            RowChange.SetSelector(ImpClass, idmovimento);
            RowChange.SetSelector(ImpClass, "idsor");

            DataTable AutoClasses = OutDS.Tables[0];
            //for every row in OutDS.Tables[0]:
            // - add row to impclassspesa
            // - evaluates temporary AutoIncrement fields
            foreach (DataRow AutoClass in AutoClasses.Rows) {
                DataRow MyDR = ImpClass.NewRow();
                foreach (DataColumn DC in ImpClass.Columns) {
                    if (DC.ColumnName.StartsWith("!")) continue;
                    MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
                }
                ///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
                if (MyDR[idmovimento] == DBNull.Value)
                    MyDR[idmovimento] = CurrMov[idmovimento];
                RowChange.CalcTemporaryID(MyDR);
                ImpClass.Rows.Add(MyDR);
                object currcodtipoclass = CurrTipoClass["idsorkind"];

                GestioneClassificazioni.CalcFlag(Meta.Conn, MyDR, currcodtipoclass);


            }
        }



        void GeneraClassificazioniAutomatichePerAutomatismi(string movtable) {
            if (DS.Tables[movtable] == null) return;
            if (AllTipoClassMov == null)
                AllTipoClassMov = Meta.Conn.RUN_SELECT("sortingkind",
                    "idsorkind, nphaseincome, nphaseexpense", null, null, null, true);
            DataTable ImpClass = DS.Tables[movtable + "sorted"];

            string idmovimento = movtable == "expense" ? "idexp" : "idinc";

            DataTable MySorting = Conn.CreateTableByName("sorting", "idsor,idsorkind");
            DataSet D = new DataSet();
            D.Tables.Add(MySorting);

            foreach (DataRow CurrMov in DS.Tables[movtable].Select()) {
                string filterid = QHC.CmpEq(idmovimento, CurrMov[idmovimento]);
                DataRow CurrImputazioneMov = DS.Tables[movtable + "year"].Select(filterid)[0];

                int currfase = CfgFn.GetNoNullInt32(CurrMov["nphase"]);

                object IDForSP = DBNull.Value;
                if (!Meta.InsertMode) IDForSP = CurrMov[idmovimento];

                DataSet OutDS;
                try {
                    OutDS = Meta.Conn.CallSP("sort_auto_single" + movtable,
                        new object[] {
                            Meta.GetSys("esercizio"),
                            IDForSP,
                            CurrMov["idreg"],
                            CurrImputazioneMov["idupb"],
                            currfase,
                            currfase,
                            CurrImputazioneMov["idfin"],
                            CurrMov["idman"],
                            CurrImputazioneMov["amount"],
                            CurrMov["parentidexp"]
                        });
                }
                catch (Exception E) {
                    MessageBox.Show(E.Message);
                    return;
                }
                if ((OutDS == null) || (OutDS.Tables.Count == 0)) return; //no autoclass

                DataTable AutoClasses = OutDS.Tables[0];
                List<SelectBuilder> selList = new List<SelectBuilder>();

                //Determina i tipi classificazione già presenti per questo movimento
                MySorting.Clear();
                DataRow[] existent_sorting = ImpClass.Select(filterid);
                foreach (DataRow ExClass in existent_sorting) {
                    MultiCompare MultiComp = new MultiCompare(new string[] {"idsor"}, new object[] {ExClass["idsor"]});
                    string mfilter = QHS.CmpEq("idsor", ExClass["idsor"]);
                    selList.Add(new SelectBuilder().IntoTable(MySorting).Where(mfilter).MultiCompare(MultiComp));
                }
                if (selList.Count > 0) {
                    Conn.MULTI_RUN_SELECT(selList);
                }

                //Cancella le classificazioni il cui TIPO è GIA' PRESENTE NEL MOVIMENTO
                foreach (DataRow AutoClass in AutoClasses.Select()) {
                    if (MySorting.Select(QHC.CmpEq("idsorkind", AutoClass["idsorkind"])).Length > 0) {
                        AutoClass.Delete();
                    }
                }
                AutoClasses.AcceptChanges();




                RowChange.MarkAsAutoincrement(
                    ImpClass.Columns["idsubclass"],
                    null,
                    null,
                    7,
                    false);
                //RowChange.SetSelector(ImpClass, "idsorkind");
                RowChange.SetSelector(ImpClass, idmovimento);
                RowChange.SetSelector(ImpClass, "idsor");


                //for every row in OutDS.Tables[0]:
                // - add row to impclassspesa
                // - evaluates temporary AutoIncrement fields
                foreach (DataRow AutoClass in AutoClasses.Rows) {
                    DataRow MyDR = ImpClass.NewRow();
                    foreach (DataColumn DC in ImpClass.Columns) {
                        if (DC.ColumnName.StartsWith("!")) continue;
                        MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
                    }
                    ///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
                    if (MyDR[idmovimento] == DBNull.Value)
                        MyDR[idmovimento] = CurrMov[idmovimento];
                    RowChange.CalcTemporaryID(MyDR);
                    ImpClass.Rows.Add(MyDR);

                    GestioneClassificazioni.CalcFlag(Meta.Conn, MyDR, AutoClass["idsorkind"]);

                    object currcodtipoclass = AutoClass["idsorkind"];
                    DataRow[] ArrCurrTipo = AllTipoClassMov.Select(QHC.CmpEq("idsorkind", currcodtipoclass));
                    if ((ArrCurrTipo != null) && (ArrCurrTipo.Length > 0)) {
                        DataRow CurrTipo = ArrCurrTipo[0];
                        CalcAutoClasses(MyDR, CurrTipo, CurrMov, CurrImputazioneMov, ImpClass);
                    }
                }
            }
        }

        void GeneraClassificazioniAutomatiche() {
            GeneraClassificazioniAutomatichePerAutomatismi("expense");
        }


        //Questa roba è presa copiandola da void GeneraClassificazioniRit di MovimentoFunctions.GestioneAutomatismi
        // classifica i movimenti sulla base della configurazione ritenute (taxsortingsetup)
        //Solo se la configurazione ritenute è assente, allora calcola le class.automatiche 
        void GeneraClassificazioniRit() {

            DataAccess Conn = Meta.Conn;
            DataTable AutoRit = Conn.RUN_SELECT("taxsortingsetup", "*", null,
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                null, true);

            ///Solo se la tabella taxsortingsetup vuota  prova a generare le class. automatiche di altro genere
            if (AutoRit.Rows.Count == 0) {
                //SOLO se la configurazione ritenute manca del tutto allora genera le class.automatiche
                GeneraClassificazioniAutomatiche();
                return;
            }

            //Genera le class.automatiche per ogni automatismo di entrata/spesa
            MetaData MetaImpClassSpesa = Meta.Dispatcher.Get("expensesorted");
            DataTable ImpClassSpesa = DS.Tables["expensesorted"];
            MetaImpClassSpesa.SetDefaults(ImpClassSpesa);
            if (AllTipoClassMov == null)
                AllTipoClassMov = Conn.RUN_SELECT("sortingkind",
                    "idsorkind, nphaseincome, nphaseexpense", null, null, null, true);


            //Esaminiamo i PAGAMENTI
            // solo se non sono collegati a movimento esistente applica le classificazioni
            // delle ritenute configurate
            if (DS.Tables["expense"] != null) {
                DataTable T = DS.Tables["expense"];
                foreach (DataRow R in T.Rows) {
                    int idexp = CfgFn.GetNoNullInt32(R["idexp"]);
                    Dictionary<int, decimal> currServices = serviceForIdExp[idexp];

                    if (CfgFn.GetNoNullInt32(R["autokind"]) != 2) continue; //"LIQRT"
                    object codicerit = R["autocode"];
                    
                    string filterrit = QHC.CmpEq("taxcode", codicerit);
                    

                    string filtercoderitNoSer = QHC.AppAnd(filterrit, QHC.IsNull("idser"));
                    DataRow[] foundNoSer = AutoRit.Select(filtercoderitNoSer);

                    foreach (int idSer in currServices.Keys) {
                        DataRow []foundConfig = foundNoSer;
                        if (idSer != 0) {
                            foundConfig = AutoRit.Select(QHC.AppAnd(filterrit, QHC.CmpEq("idser",idSer)));
                            if (foundConfig.Length == 0) foundConfig = foundNoSer;
                        }
                        if (foundConfig.Length==0) continue;
                        decimal amount = currServices[idSer];
                        //DataRow Rexpenseyear = DS.expenseyear.Select(QHC.CmpEq("idexp", R["idexp"]))[0];
                        //object amount = Rexpenseyear["amount"];
                                                
                        foreach (DataRow AR in foundConfig) {
                            //Genera una class. automatica 
                            object tipoclass = AR["idsorkind"];
                            if (tipoclass == DBNull.Value) continue;
                            string filtertipoclass = QHC.CmpEq("idsorkind", tipoclass);
                            DataRow TipoR = AllTipoClassMov.Select(filtertipoclass)[0];
                            if (TipoR["nphaseexpense"].ToString() != R["nphase"].ToString()) continue;

                            object idclass = AR["idsor_taxpay"];
                            if (idclass == DBNull.Value) continue;

                            //MetaData.SetDefault(ImpClassSpesa,"idsorkind",tipoclass);
                            MetaData.SetDefault(ImpClassSpesa, "idsor", idclass);
                            DataRow RImp = MetaImpClassSpesa.Get_New_Row(R, ImpClassSpesa);
                            RImp["amount"] = amount;
                            GestioneClassificazioni.CalcFlag(Conn, RImp, tipoclass);
                        }

                    }
                    
                    
                }
            }
        }

        void ViewAutomatismi(DataSet DS) {
            string varspesa = null;
            if (DS.Tables["expensevar"] != null) {
                DataTable Var = DS.Tables["expensevar"];
                foreach (DataRow R in Var.Rows) {
                    varspesa = QHS.AppOr(varspesa, QHS.DoPar(QHS.MCmp(R, "idexp", "nvar")));
                }
            }
            string spesa = null;
            if (DS.Tables["expense"] != null) {
                DataTable Exp = DS.Tables["expense"];
                spesa = QHS.FieldIn("idexp", Exp.Select());
            }
            string entrata = null;
            if (DS.Tables["income"] != null) {
                DataTable Inc = DS.Tables["income"];
                entrata = QHS.FieldIn("idinc", Inc.Select());
            }
            Form F = ShowAutomatismi.Show(Meta, spesa, entrata, varspesa, null);
            if (F != null) F.ShowDialog(this);
        }

        string GetFilterForSelection(DataRow[] Selected, string table, int livello) {
            string filter = "";
            //int minfasebil=  GetFaseInfo("flagfinance",table);
            //int minfasecred = GetFaseInfo("flagregistry",table);
            int minfasecred = 99;
            int minfasebil = 99;
            if (table == "expense") {
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income") {
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }

            //int minfasefondo = GetFaseInfo("flagresfund",table);
            //int minfasebilpluri = GetFaseInfo("flagfinance",table);
            if (livello >= minfasebil) {
                object O = Selected[0]["idfin"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idfin", O));
                }
                object P = Selected[0]["idupb"];
                if (P != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", P));
                }
            }

            if (livello >= minfasecred) {
                object O = Selected[0]["idreg"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", O));
                }
            }

            return filter;
        }

        int GetMaxFaseForSelection(DataRow[] Selected, string table) {
            //int minfasebil= GetFaseInfo("flagfinance",table);
            //int minfasecred = GetFaseInfo("flagregistry",table);
            int minfasecred = 99;
            int minfasebil = 99;
            if (table == "expense") {
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income") {
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }

//			int minfasefondo = GetFaseInfo("flagresfund",table);
//			int minfasebilpluri = GetFaseInfo("flagfinance",table);
            int fasecurr = 99;
            if (table == "income") {
                //fasecurr=Convert.ToInt32(maxfaseentrata)-1;
            }
            else {
                fasecurr = Convert.ToInt32(maxfasespesa) - 1;
            }
            if (nvaloridiversi("idfin", Selected) > 1) {
                if (fasecurr >= minfasebil) fasecurr = minfasebil - 1;
            }
            if ((nvaloridiversi("idupb", Selected) > 1)) {
                if (fasecurr >= minfasebil) fasecurr = minfasebil - 1;
            }

            if (nvaloridiversi("idreg", Selected) > 1) {
                if (fasecurr >= minfasecred) fasecurr = minfasecred - 1;
            }

            return fasecurr;
        }


        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }

        private void btnCollega_Click(object sender, System.EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridMovSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            string rowfilter;
            int maxfase = GetMaxFaseForSelection(RigheSelezionate, "expense");
            if (maxfase < 1) {
                MessageBox.Show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n" +
                                "Le informazioni di bilancio,creditore,fondo,suddivisione e bil.pluriennale sono " +
                                "troppo diverse tra loro.", "Errore");
                return;
            }
            int selectedfase = maxfase;
            if (maxfase > 1) {
                DataTable Fasi2 = DS.expensephase.Copy();
                foreach (DataRow ToDel in Fasi2.Select(QHC.CmpGt("nphase", maxfase))) {
                    ToDel.Delete();
                }
                Fasi2.AcceptChanges();
                FrmAskFase F = new FrmAskFase(Fasi2);
                if (F.ShowDialog() != DialogResult.OK) return;
                selectedfase = Convert.ToInt32(F.cmbFasi.SelectedValue);
            }
            rowfilter = GetFilterForSelection(RigheSelezionate, "expense", selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHC.CmpEq("nphase", selectedfase));
            decimal tot = 0;
            foreach (DataRow R in RigheSelezionate) {
                tot += CfgFn.GetNoNullDecimal(R["amount"]);
            }
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available", tot));
            MetaData E = Meta.Dispatcher.Get("expense");
            E.FilterLocked = true;
            E.DS = DS.Clone();
            DataRow Choosen = E.SelectOne("default", rowfilter, "expense", null);
            if (Choosen == null) return;
            RighePadri[Choosen["idexp"]] = Choosen;
            foreach (DataRow R in RigheSelezionate) {
                R["parentidexp"] = Choosen["idexp"];
                if (Choosen["idman"] != DBNull.Value) {
                    R["idman"] = Choosen["idman"];
                    R["manager"] = Choosen["manager"];
                }

                int I = Convert.ToInt32(R["idexp"]);
                SP_Result.Rows[I]["livsupid"] = Choosen["idexp"];
                if (Choosen["idman"] != DBNull.Value) {
                    SP_Result.Rows[I]["idman"] = Choosen["idman"];
                    SP_Result.Rows[I]["manager"] = Choosen["manager"];
                    R["idman"] = Choosen["idman"];
                    R["manager"] = Choosen["manager"];
                }

            }
            RicalcolaCampiCalcolati();
        }

        //int GetFaseInfo(string flag, string table){
        //    string fasitable=table+"phase";
        //    DataTable Fase= DS.Tables[fasitable];//expensephase
        //    int faseattivazione;

        //    DataRow[] MyDRfase;
        //    MyDRfase  = Fase.Select(QHC.CmpEq(flag,"S"),"nphase");			
        //    if (MyDRfase.Length > 0)
        //        faseattivazione = (Convert.ToInt32(MyDRfase[0]["nphase"]));
        //    else 
        //        faseattivazione = 99;
        //    return faseattivazione;
        //}

        int nvaloridiversi(string column, DataRow[] ROWS) {
            string outstring = "";
            int diversi = 0;
            foreach (DataRow R in ROWS) {
                //if (R[column]==DBNull.Value) continue;
                string quoted = QueryCreator.quotedstrvalue(R[column], false);
                if (outstring.IndexOf(quoted) >= 0) continue;
                if (outstring != "") outstring += ",";
                outstring += quoted;
                diversi++;
            }
            return diversi;
        }

       void RicalcolaCampiCalcolati() {
            foreach (DataRow RS in DS.expenseview.Rows) {
//				RS["!fondorip"]= RS["idres"].ToString()+"#"+RS["idpar"].ToString();
                object livsup = RS["parentidexp"];
                int nfasesup = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", livsup), "nphase"));
                if (livsup != DBNull.Value) {
                    DataRow Sup = (DataRow) RighePadri[livsup];
                    string nomefasesup =
                        DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup))[0]["description"].ToString();
                    string nomefasesup2 =
                        DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup + 1))[0]["description"].ToString();
                    RS["!livprecedente"] = nomefasesup + " " +
                                           Sup["ymov"].ToString() + "/" +
                                           Sup["nmov"].ToString();
                    string nomefasemax =
                        DS.expensephase.Select(QHC.CmpEq("nphase", maxfasespesa))[0]["description"].ToString();
                    if (nomefasesup2 != nomefasemax)
                        RS["phase"] = nomefasesup2 + " - " + nomefasemax;
                    else
                        RS["phase"] = nomefasemax;
                }
                else {
                    RS["!livprecedente"] = "";
                    RS["phase"] = "Tutte";
                }


            }
            formatgrids FGSpesa = new formatgrids(gridMovSpesa);
            FGSpesa.AutosizeColumnWidth();
        }

        private void btnScollegaS_Click(object sender, System.EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridMovSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            foreach (DataRow R in RigheSelezionate) {
                R["parentidexp"] = DBNull.Value;
                int I = Convert.ToInt32(R["idexp"]);
                //SP_Result.Rows[I]["livsupid"]= DBNull.Value;
                SP_Result.Rows[I].RejectChanges();
            }
            RicalcolaCampiCalcolati();

        }

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            if (MyTable.TableName == "expenseview")
                filter = QHC.CmpEq("idexp", G[index, 0]);
            else
                filter = QHC.CmpEq("idinc", G[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }

        private void leggiIDettagliDiUnaRitenuta() {
            Cursor = Cursors.WaitCursor;
            DS.expenseview.Clear();
            dgDettaglioRitenute.DataSource = null;
            txtDataInizio.Text = "";
            txtDataFine.Text = "";
            txtImporto1.Text = "";
            txtImporto2.Text = "";
            CanSave = false;
            if (cmbRitenuta.SelectedIndex <= 0) {
                Cursor = null;
                return;
            }
            object ritenuta = cmbRitenuta.SelectedValue;
            string filtro = QHS.AppAnd(QHS.CmpEq("taxcode", ritenuta), QHS.CmpEq("ayear", esercizio));
            DataTable Periodo = Meta.Conn.RUN_SELECT("taxsetup",
                "idexpirationkind, expiringday, flag", null, filtro, null, true);
            if (Periodo.Rows.Count == 0) {
                Cursor = null;
                MessageBox.Show(this,
                    "Errore: i dati relativi all'imputazione e alla liquidazione della ritenuta non sono presenti!",
                    "Errore configurazione");
                btnOK.Enabled = false;
                CanSave = false;
                return;
            }
            DataRow RigaPeriodo = Periodo.Rows[0];
            if (!ControllaConfRitenuta(RigaPeriodo)) {
                Cursor = null;
                MessageBox.Show(this, "Errore: i dati relativi alla liquidazione della ritenuta sono errati!",
                    "Errore configurazione");
                btnOK.Enabled = false;
                CanSave = false;
                return;
            }

            string query = "SELECT distinct expense.nmov,expense.ymov "
                           + " FROM expensetaxview "
                           + " JOIN expense "
                           + "     ON expense.idexp = expensetaxview.idexp "
                           + " JOIN expenseyear "
                           + "     ON expenseyear.idexp = expense.idexp "
                           + " WHERE expensetaxview.taxcode = " + ritenuta
                           + " AND expensetaxview.ytaxpay IS NULL "
                           + " AND expensetaxview.datetaxpay IS NULL "
                           + " AND expenseyear.ayear = " + esercizio
                           + " ORDER BY expense.nmov";

            DataTable t = Meta.Conn.SQLRunner(query);
            if (t.Rows.Count > 0) {
                string errore = "Le seguenti prestazioni, in  base alla configurazione presente in Configurazione / Versamento "
                                + " Imposte, NON SONO CONSIDERATE PAGATE ai fini della liquidazione delle Ritenute: ";
                foreach (DataRow r in t.Rows) {
                    errore += "\n " + r["ymov"] + " / " + r["nmov"] + ";";
                }
                MessageBox.Show(errore, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            datainizioform = new DateTime(1, 1, 1);
            datainiziodati = new DateTime(1, 1, 1);
            datafine = new DateTime(1, 1, 1);
            CalcolaDateDaPeriodo(RigaPeriodo, out datainiziodati, out datainizioform, out datafine);
            txtDataInizio.Text = datainizioform.ToShortDateString();
            txtDataFine.Text = datafine.ToShortDateString();
            if (!chiamaStoredProcedure()) {
                Cursor = null;
                return;
            }
            /*			if (DS.spesaview.Rows.Count==0)
						{
							btnOK.Enabled=false;
							CanSave=false;
							MessageBox.Show(this,"Non ci sono ritenute da liquidare","Avvertimento");
							return;
						}*/
            btnOK.Enabled = true;
            CanSave = true;
            MetaData.SetDefault(DS.taxpay, "start", datainizioform);
            MetaData.SetDefault(DS.taxpay, "stop", datafine);
            Cursor = null;
            return;
        }

        private void cmbRitenuta_SelectedIndexChanged(object sender, System.EventArgs e) {
            leggiIDettagliDiUnaRitenuta();
        }

        private void btnOK_Click(object sender, System.EventArgs e) {
            btnOK.Enabled = false;
            if (DS.expenseview.Rows.Count == 0) return;
            bool res = false;
            if (CanSave) res = SaveData();
            if (res) {
                leggiIDettagliDiUnaRitenuta();
            }
            else {
                btnOK.Enabled = true;
            }
        }

        private DataTable getRighePerGirofondi() {
            object dataSource = dgDettaglioRitenute.DataSource;
            if (dataSource == null) return null;

            CurrencyManager cm = (CurrencyManager)
                dgDettaglioRitenute.BindingContext[dataSource, dgDettaglioRitenute.DataMember];

            DataView view = cm.List as DataView;
            object codiceritenuta = cmbRitenuta.SelectedValue;
            DataRow[] descr = DS.tax.Select(QHC.CmpEq("taxcode", codiceritenuta));
            string descrrit = descr[0]["description"].ToString();

            DataTable t = new DataTable();
            string[] nomiColonne = {
                "idtreasurer", "department"
            };
            foreach (string col in nomiColonne) {
                if (col == "idreg" || col == "idtreasurer" || col == "idfin" || col == "idman" || col == "idcity"
                    || col == "idfiscaltaxregion")
                    t.Columns.Add(col, typeof (Int32));
                else
                    t.Columns.Add(col, typeof (String));
            }

            t.Columns.Add("amount", typeof (decimal));


            for (int i = 0; i < view.Count; i++) {
                if (dgDettaglioRitenute.IsSelected(i)) {
                    DataRow RV = view[i].Row;
                    string idSpesa = QHC.quote(view[i]["idexp"]);

                    string filtro = QHC.MCmp(RV, "idtreasurer");

                    DataRow[] r1 = t.Select(filtro);

                    if (r1.Length == 0) {
                        DataRow r = t.NewRow();
                        foreach (string col in nomiColonne) {
                            r[col] = view[i][col];
                        }
                        r["amount"] = view[i]["amount"];
                        t.Rows.Add(r);
                    }
                    else {
                        r1[0]["amount"] = CfgFn.GetNoNullDecimal(r1[0]["amount"]) +
                                          CfgFn.GetNoNullDecimal(view[i]["amount"]);

                    }
                }
            }
            return t;
        }

        Dictionary<int,Dictionary<int,decimal>> serviceOfMov  = new Dictionary<int, Dictionary<int, decimal>>();
        private DataTable getMovimentiCheLiquidanoLeRitenute(DataView view) {
            serviceOfMov.Clear();
            object codiceritenuta = cmbRitenuta.SelectedValue;
            DataRow[] descr = DS.tax.Select(QHC.CmpEq("taxcode", codiceritenuta));
            string descrrit = descr[0]["description"].ToString();

            DataTable t = new DataTable();
            string[] nomiColonne = {
                "#",
                "movkind", "idreg", "registry", //"idtreasurer","department",
                "idfin", "codefin",
                "idupb", "codeupb",
                "idman", "manager",
                "location",
                "idcity", "city", "idfiscaltaxregion", "fiscaltaxregion"
                //,"idser","codeser","service"

            };
            foreach (string col in nomiColonne) {
                if (col=="#" || col == "idreg" || col == "idtreasurer" || col == "idfin" || col == "idman" || col == "idcity"
                    || col == "idfiscaltaxregion")
                    t.Columns.Add(col, typeof (Int32));
                else
                    t.Columns.Add(col, typeof (String));
            }

            t.Columns.Add("amount", typeof (decimal));
            t.Columns.Add("elencoidspese");

            int nRows = 0;
            for (int i = 0; i < view.Count; i++) {
                if (dgDettaglioRitenute.IsSelected(i)) {
                    DataRow RV = view[i].Row;
                    string idSpesa = QHC.quote(view[i]["idexp"]);

                    string filtro = QHC.MCmp(RV, "movkind", "idreg", "idfin", "idupb", "idman", "location");
                        // "idtreasurer",

                    DataRow[] r1 = t.Select(filtro);
                    DataRow found = null;
                    if (r1.Length == 0) {
                        DataRow r = t.NewRow();
                        foreach (string col in nomiColonne) {
                            if (!view.Table.Columns.Contains(col)) continue;
                            r[col] = view[i][col];
                        }
                        r["elencoIdSpese"] = idSpesa;
                        r["amount"] = view[i]["amount"];
                        r["#"] = nRows;
                        nRows++;
                        t.Rows.Add(r);
                        found = r;
                    }
                    else {
                        string elencoIdSpese = r1[0]["elencoidspese"].ToString();

                        r1[0]["amount"] = CfgFn.GetNoNullDecimal(r1[0]["amount"]) +
                                          CfgFn.GetNoNullDecimal(view[i]["amount"]);

                        if (elencoIdSpese.IndexOf(idSpesa) == -1) {
                            r1[0]["elencoIdSpese"] = elencoIdSpese + "," + idSpesa;
                        }

                        found = r1[0];
                    }

                    int id = CfgFn.GetNoNullInt32(found["#"]);
                    if (!serviceOfMov.ContainsKey(id)) {
                        serviceOfMov[id]= new Dictionary<int, decimal>();
                    }

                    int idser = CfgFn.GetNoNullInt32(RV["idser"]);
                    Dictionary<int, decimal> ser = serviceOfMov[id];
                    if (!ser.ContainsKey(idser)) {
                        ser[idser] = 0;
                    }

                    ser[idser] = ser[idser] + CfgFn.GetNoNullDecimal(view[i]["amount"]);

                }
            }
            return t;
        }

        private void dgDettaglioRitenute_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            object dataSource = dgDettaglioRitenute.DataSource;
            if (dataSource == null) return;

            CurrencyManager cm = (CurrencyManager)
                dgDettaglioRitenute.BindingContext[dataSource, dgDettaglioRitenute.DataMember];

            DataView view = cm.List as DataView;

            if (view != null) {
                //string elencoSpeseSelezionate = "";
                string elencoSpeseSelezionateRit = "";
                string elencoSpeseSelezionateCor = "";

                for (int i = 0; i < view.Count; i++) {
                    if (dgDettaglioRitenute.IsSelected(i)) {
                        DataRow RV = view[i].Row;

                        // tipo può valere C o R
                        string tipo = RV["sourcekind"].ToString().ToUpper();

                        if (tipo == "R") {
                            elencoSpeseSelezionateRit += "," + QHS.quote(view[i]["idexp"]);
                        }
                        else {
                            elencoSpeseSelezionateCor += "," + QHS.quote(view[i]["idexp"]);
                        }


                    }
                }

                btnOK.Enabled = (elencoSpeseSelezionateRit.Length +
                                 elencoSpeseSelezionateCor.Length) > 0;

                if (elencoSpeseSelezionateCor.Length > 0) {
                    elencoSpeseSelezionateCor = elencoSpeseSelezionateCor.Substring(1);
                }

                if (elencoSpeseSelezionateRit.Length > 0) {
                    elencoSpeseSelezionateRit = elencoSpeseSelezionateRit.Substring(1);
                }



                if ((elencoSpeseDaLiquidareRit != elencoSpeseSelezionateRit) ||
                    (elencoSpeseDaLiquidareCor != elencoSpeseSelezionateCor)) {
                    DataTable t = getMovimentiCheLiquidanoLeRitenute(view);
                    selezioneCambiata(t);
                    elencoSpeseDaLiquidareRit = elencoSpeseSelezionateRit;
                    elencoSpeseDaLiquidareCor = elencoSpeseSelezionateCor;
                }
            }
        }

        private void gridMovSpesa_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            object dataSource = gridMovSpesa.DataSource;
            if (dataSource == null) return;

            CurrencyManager cm = (CurrencyManager)
                gridMovSpesa.BindingContext[dataSource, gridMovSpesa.DataMember];

            DataView view = cm.List as DataView;

            bool esisteSelezione = false;

            if (view != null) {
                for (int i = 0; i < view.Count; i++) {
                    if (gridMovSpesa.IsSelected(i)) {
                        esisteSelezione = true;
                        string livPrecedente = view[i]["!livprecedente"].ToString();
                        if (livPrecedente != "") {
                            btnCollegaS.Enabled = false;
                            btnCambiaBilancio.Enabled = false;
                            btnScollegaS.Enabled = true;
                            return;
                        }
                    }
                }
            }
            btnCollegaS.Enabled = esisteSelezione;
            btnCambiaBilancio.Enabled = esisteSelezione;
            btnScollegaS.Enabled = false;
        }

        #region gestione tabcontrol


        /// <summary>
        /// Displays tab n. NewTab and updates buttons
        /// </summary>
        /// <param name="newTab"></param>
        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            btnNext.Visible = (newTab != tabController.TabPages.Count - 1);
/*			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Fine.";
			else
				btnNext.Text="Avanti >";*/
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }

/*		/// <summary>
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool CustomChangeTab(int oldTab, int newTab) 
		{
			return true;
		}
*/

        /// <summary>
        /// Changes tab backward/forward
        /// </summary>
        /// <param name="step"></param>
        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if ((oldTab == 1) && (newTab == 2)) {

                if ((cmbRitenuta.SelectedValue != null) && (cmbRitenuta.SelectedValue != DBNull.Value)
                    && (CfgFn.GetNoNullInt32(cmbRitenuta.SelectedValue) != 0)) {
                    bool isOk = checkVincoloLiquidazione();
                    isOk = checkVincoloFinanziario();
                    if (!checkVincoloLiquidazione() || !checkVincoloFinanziario()) {
                        object taxCode = cmbRitenuta.SelectedValue;
                        object taxPayKind = null;

                        if (DS.taxsetup.Select(QHC.CmpEq("taxcode", taxCode)).Length > 0) {
                            DataRow rTaxSetup = DS.taxsetup.Select(QHC.CmpEq("taxcode", taxCode))[0];
                            taxPayKind = rTaxSetup["taxpaykind"].ToString().ToUpper();
                        }
                        else {
                            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.taxsetup, null, QHS.CmpEq("taxcode", taxCode),
                                null, true);
                            if (DS.taxsetup.Select(QHC.CmpEq("taxcode", taxCode)).Length > 0) {
                                DataRow rTaxSetup = DS.taxsetup.Select(QHC.CmpEq("taxcode", taxCode))[0];
                                taxPayKind = rTaxSetup["taxpaykind"].ToString().ToUpper();
                            }
                        }
                        if (taxPayKind == null) {
                            MessageBox.Show("La ritenuta selezionata non è adatta per il modello F24 o F24EP", "Errore");
                            deselezionaDettagli();
                            DisplayTabs(oldTab);
                            return;
                        }
                        FrmError frm = new FrmError(tErrorLiq, tErrorFin, taxPayKind);
                        frm.ShowDialog();
                        if (!frm.IgnoraSegnalazione) {
                            deselezionaDettagli();
                            DisplayTabs(oldTab);
                            return;
                        }

                    }
                }
            }
            if (newTab == tabController.TabPages.Count) {
                DialogResult = DialogResult.OK;
                return;
            }
            DisplayTabs(newTab);
        }

        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }

        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        #endregion

        private void deselezionaDettagli() {
            object dataSource = dgDettaglioRitenute.DataSource;
            if (dataSource == null) {
                return;
            }

            CurrencyManager cm = (CurrencyManager)
                dgDettaglioRitenute.BindingContext[dataSource, dgDettaglioRitenute.DataMember];

            DataView view = cm.List as DataView;

            if (view != null) {
                foreach (DataRow rApp in tAppGroupLiq.Select(QHC.CmpLt("amount", 0))) {
                    int id = CfgFn.GetNoNullInt32(rApp["id"]);
                    ArrayList l = (ArrayList) hAppGroupLiq[id];
                    foreach (int elem in l) {
                        if (dgDettaglioRitenute.IsSelected(elem)) {
                            dgDettaglioRitenute.UnSelect(elem);
                        }
                    }
                }

                foreach (DataRow rApp in tAppGroupFin.Select(QHC.CmpLt("amount", 0))) {
                    int id = CfgFn.GetNoNullInt32(rApp["id"]);
                    ArrayList l = (ArrayList) hAppGroupFin[id];
                    foreach (int elem in l) {
                        if (dgDettaglioRitenute.IsSelected(elem)) {
                            dgDettaglioRitenute.UnSelect(elem);
                        }
                    }
                }
            }
        }

        private bool checkVincoloLiquidazione() {
            tErrorLiq.Clear();
            tAppGroupLiq.Clear();
            hAppGroupLiq.Clear();

            object taxCode = cmbRitenuta.SelectedValue;

            string taxPayKind = null;
            if (DS.taxsetup.Select(QHC.CmpEq("taxcode", taxCode)).Length > 0) {
                DataRow rTaxSetup = DS.taxsetup.Select(QHC.CmpEq("taxcode", taxCode))[0];
                taxPayKind = rTaxSetup["taxpaykind"].ToString().ToUpper();
            }
            else {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.taxsetup, null, QHS.CmpEq("taxcode", taxCode),
                    null, true);
                if (DS.taxsetup.Select(QHC.CmpEq("taxcode", taxCode)).Length > 0) {
                    DataRow rTaxSetup = DS.taxsetup.Select(QHC.CmpEq("taxcode", taxCode))[0];
                    taxPayKind = rTaxSetup["taxpaykind"].ToString().ToUpper();
                }
                else {
                    DataRow rErrorLiq = tErrorLiq.NewRow();
                    rErrorLiq["nrow"] = 1;
                    rErrorLiq["description"] = "Configurazione Ritenuta Assente!";
                    tErrorLiq.Rows.Add(rErrorLiq);
                    return false;
                }
            }

            object dataSource = dgDettaglioRitenute.DataSource;
            if (dataSource == null) {
                DataRow rErrorLiq = tErrorLiq.NewRow();
                rErrorLiq["nrow"] = 1;
                rErrorLiq["description"] = "Sorgente Dati mancante! Contattare il servizio assistenza";
                tErrorLiq.Rows.Add(rErrorLiq);
                return false;
            }

            CurrencyManager cm = (CurrencyManager)
                dgDettaglioRitenute.BindingContext[dataSource, dgDettaglioRitenute.DataMember];

            DataView view = cm.List as DataView;

            string[] fieldList = null;
            string captionCampiPerMsg = "";
            //I = F24; E = F24EP
            if (taxPayKind == "I") {
                // si raggruppa per taxcode
                fieldList = new string[] {"taxcode"};
                captionCampiPerMsg = "Cod. Ritenuta";
            }
            else {
                // si raggruppa per idcity, idfiscaltaxregion, fiscaltaxcode, ayear, refmonth
                fieldList = new string[] {"fiscaltaxcode", "idcity", "idfiscaltaxregion", "ayear", "refmonth"};
                captionCampiPerMsg = "Cod. Tributo, Comune - Regione Fiscale (ove presente)";
            }

            for (int i = 0; i < view.Count; i++) {
                int currId = 0;
                if (dgDettaglioRitenute.IsSelected(i)) {
                    DataRow RV = view[i].Row;

                    string filtro = QHC.MCmp(RV, fieldList);
                    if (tAppGroupLiq.Select(filtro).Length > 0) {
                        DataRow rApp = tAppGroupLiq.Select(filtro)[0];
                        rApp["amount"] = CfgFn.GetNoNullDecimal(rApp["amount"]) +
                                         CfgFn.GetNoNullDecimal(RV["amount"]);

                        currId = CfgFn.GetNoNullInt32(rApp["id"]);

                        ArrayList list = (ArrayList) hAppGroupLiq[currId];
                        list.Add(i);
                        hAppGroupLiq[currId] = list;
                    }
                    else {
                        DataRow rApp = tAppGroupLiq.NewRow();
                        rApp["taxcode"] = RV["taxcode"];
                        foreach (string colName in fieldList) {
                            rApp[colName] = RV[colName];
                        }
                        rApp["amount"] = RV["amount"];

                        currId = 1 + CfgFn.GetNoNullInt32(tAppGroupLiq.Compute("MAX(id)", null));
                        rApp["id"] = currId;
                        tAppGroupLiq.Rows.Add(rApp);

                        ArrayList list = new ArrayList();
                        list.Add(i);
                        hAppGroupLiq[currId] = list;
                    }
                }
            }

            if (tAppGroupLiq.Select(QHC.CmpLt("amount", 0)).Length > 0) {
                foreach (DataRow rApp in tAppGroupLiq.Select(QHC.CmpLt("amount", 0))) {
                    int id = CfgFn.GetNoNullInt32(rApp["id"]);
                    ArrayList l = (ArrayList) hAppGroupLiq[id];
                    foreach (int elem in l) {
                        DataRow RV = view[elem].Row;

                        string modello = (taxPayKind == "I") ? "F24" : "F24EP";
                        DataRow r = tErrorLiq.NewRow();
                        r["nrow"] = 1 + CfgFn.GetNoNullInt32(tErrorLiq.Compute("MAX(nrow)", null));
                        r["description"] = "Il movimento n." + RV["nmov"] + "/" + RV["ymov"] + " imputato a " +
                                           RV["payee_title"] + " non rispetta i vincoli della liquidazione dell'" +
                                           modello +
                                           " Raggruppamento eseguito per: " + captionCampiPerMsg;

                        tErrorLiq.Rows.Add(r);
                    }
                }
                return false;
            }

            return true;
        }

        private bool checkVincoloFinanziario() {
            tErrorFin.Clear();
            tAppGroupFin.Clear();
            hAppGroupFin.Clear();

            object taxCode = cmbRitenuta.SelectedValue;

            object dataSource = dgDettaglioRitenute.DataSource;
            if (dataSource == null) {
                DataRow rErrorFin = tErrorFin.NewRow();
                rErrorFin["nrow"] = 1;
                rErrorFin["description"] = "Sorgente Dati mancante! Contattare il servizio assistenza";
                tErrorFin.Rows.Add(rErrorFin);
                return false;
            }

            CurrencyManager cm = (CurrencyManager)
                dgDettaglioRitenute.BindingContext[dataSource, dgDettaglioRitenute.DataMember];

            DataView view = cm.List as DataView;

            string[] fieldList = null;
            string captionCampiPerMsg = "";

            fieldList = new string[] {"idreg", "idfin", "idupb", "idman"};

            captionCampiPerMsg = "Cod. Ritenuta";

            for (int i = 0; i < view.Count; i++) {
                int currId = 0;
                if (dgDettaglioRitenute.IsSelected(i)) {
                    DataRow RV = view[i].Row;

                    string filtro = QHC.MCmp(RV, fieldList);
                    if (tAppGroupFin.Select(filtro).Length > 0) {
                        DataRow rApp = tAppGroupFin.Select(filtro)[0];
                        rApp["amount"] = CfgFn.GetNoNullDecimal(rApp["amount"]) +
                                         CfgFn.GetNoNullDecimal(RV["amount"]);

                        currId = CfgFn.GetNoNullInt32(rApp["id"]);

                        ArrayList list = (ArrayList) hAppGroupFin[currId];
                        list.Add(i);
                        hAppGroupFin[currId] = list;
                    }
                    else {
                        DataRow rApp = tAppGroupFin.NewRow();
                        rApp["taxcode"] = RV["taxcode"];
                        foreach (string colName in fieldList) {
                            rApp[colName] = RV[colName];
                        }
                        rApp["amount"] = RV["amount"];

                        currId = 1 + CfgFn.GetNoNullInt32(tAppGroupFin.Compute("MAX(id)", null));
                        rApp["id"] = currId;
                        tAppGroupFin.Rows.Add(rApp);

                        ArrayList list = new ArrayList();
                        list.Add(i);
                        hAppGroupFin[currId] = list;
                    }
                }
            }

            if (tAppGroupFin.Select(QHC.CmpLt("amount", 0)).Length > 0) {
                foreach (DataRow rApp in tAppGroupFin.Select(QHC.CmpLt("amount", 0))) {
                    int id = CfgFn.GetNoNullInt32(rApp["id"]);
                    ArrayList l = (ArrayList) hAppGroupFin[id];
                    foreach (int elem in l) {
                        DataRow RV = view[elem].Row;

                        DataRow r = tErrorFin.NewRow();
                        r["nrow"] = 1 + CfgFn.GetNoNullInt32(tErrorFin.Compute("MAX(nrow)", null));
                        r["description"] = "Il movimento n." + RV["nmov"] + "/" + RV["ymov"] + " imputato a " +
                                           RV["payee_title"] + " appartiene ad un raggruppamento finanziario NEGATIVO!" +
                                           " Raggruppamento eseguito per: " + captionCampiPerMsg;

                        tErrorFin.Rows.Add(r);
                    }
                }
                return false;
            }

            return true;
        }

        private void selezionaTuttiIDettagliRitenute() {
            object dataSource = dgDettaglioRitenute.DataSource;
            if (dataSource == null) return;

            CurrencyManager cm = (CurrencyManager)
                dgDettaglioRitenute.BindingContext[dataSource, dgDettaglioRitenute.DataMember];

            DataView view = cm.List as DataView;

            if (view != null) {
                for (int i = 0; i < view.Count; i++) {
                    dgDettaglioRitenute.Select(i);
                }
            }
        }

        private void btnSelezionaTutto_Click(object sender, System.EventArgs e) {
            selezionaTuttiIDettagliRitenute();
        }

        private void btnCambiaBilancio_Click(object sender, System.EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridMovSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;

            object idupb = RigheSelezionate[0]["idupb"];
            object idfin = RigheSelezionate[0]["idfin"];
            decimal importo = 0;
            foreach (DataRow riga in RigheSelezionate) {
                importo += CfgFn.GetNoNullDecimal(riga["amount"]);
            }
            FrmAskBilancio Bil = new FrmAskBilancio(idupb, idfin, importo,
                Meta.Dispatcher, Conn);
            if (Bil.ShowDialog() != DialogResult.OK) return;
            if (Bil.Selected == null) return;
            if (Bil.Selected["idfin"] == DBNull.Value) return;

            for (int i = 0; i < RigheSelezionate.Length; i++) {
                RigheSelezionate[i]["idfin"] = Bil.Selected["idfin"];
                RigheSelezionate[i]["codefin"] = Bil.Selected["codefin"];
                RigheSelezionate[i]["idupb"] = Bil.Selected["idupb"];
                RigheSelezionate[i]["codeupb"] = Bil.Selected["codeupb"];
                if (Bil.Selected["idman"] != DBNull.Value) {
                    RigheSelezionate[i]["idman"] = Bil.Selected["idman"];
                    RigheSelezionate[i]["manager"] = Bil.Selected["manager"];
                }
                else {
                    if (Bil.cmbResponsabile.SelectedIndex > 0) {
                        RigheSelezionate[i]["idman"] = Bil.cmbResponsabile.SelectedValue;
                        RigheSelezionate[i]["manager"] = Bil.cmbResponsabile.Text;
                    }
                }


                int N = Convert.ToInt32(RigheSelezionate[i]["idexp"]);
                SP_Result.Rows[N]["idfin"] = Bil.Selected["idfin"];
                SP_Result.Rows[N]["codefin"] = Bil.Selected["codefin"];
                SP_Result.Rows[N]["idupb"] = Bil.Selected["idupb"];
                SP_Result.Rows[N]["codeupb"] = Bil.Selected["codeupb"];
                if (Bil.Selected["idman"] != DBNull.Value) {
                    SP_Result.Rows[N]["idman"] = Bil.Selected["idman"];
                    SP_Result.Rows[N]["manager"] = Bil.Selected["manager"];
                }
                else {
                    if (Bil.cmbResponsabile.SelectedIndex > 0) {
                        SP_Result.Rows[N]["idman"] = Bil.cmbResponsabile.SelectedValue;
                        SP_Result.Rows[N]["manager"] = Bil.cmbResponsabile.Text;
                    }
                }
                SP_Result.AcceptChanges();
            }
        }





        static string _composeObjects(params object[] o) {
            if (o == null) return null;
            if (o.Length == 0) return null;
            string res = "";
            foreach (object oo in o) {
                if (res != "") res += "§";
                res += oo.ToString();
            }
            return res;
        }
    }
}
