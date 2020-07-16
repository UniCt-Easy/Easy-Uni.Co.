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

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using ep_functions;
using funzioni_configurazione;

namespace payroll_default {//cedolino//
	/// <summary>
	/// Summary description for FrmCedolino.
	/// </summary>
	public class Frm_payroll_default : System.Windows.Forms.Form {
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		public vistaForm DS;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox grpComune;
		private System.Windows.Forms.TextBox txtGeoComune;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtGGlavorati;
		private System.Windows.Forms.CheckBox chkCompleto;
		private System.Windows.Forms.TextBox txtArrotondamento;
        private System.Windows.Forms.CheckBox chktaxrelief;
		MetaData Meta;
		private System.Windows.Forms.GroupBox gboxContratto;
		private System.Windows.Forms.Label labAnnoFiscale;
		private System.Windows.Forms.TextBox txtAnnoFiscale;
		private System.Windows.Forms.TextBox txtErogazione;
		private System.Windows.Forms.TextBox txtCompensoLordo;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabGenerale;
		private System.Windows.Forms.TabPage tabDettDeduzioni;
		private System.Windows.Forms.TabPage tabDettDetrazioni;
		private System.Windows.Forms.TabPage tabRitenuta;
		string filteresercizio;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.CheckBox chkConguaglio;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtDataInizio;
		private System.Windows.Forms.TextBox txtDataFine;
		private System.Windows.Forms.Button btnEliminaRitenuta;
		private System.Windows.Forms.Button btnModificaRitenuta;
		private System.Windows.Forms.Button btnInserisciRitenuta;
		private System.Windows.Forms.Button btnEliminaDeduzione;
		private System.Windows.Forms.Button btnModificaDeduzione;
		private System.Windows.Forms.Button btnInserisciDeduzione;
		private System.Windows.Forms.Button btnEliminaDetrazione;
		private System.Windows.Forms.Button btnModificaDetrazione;
		private System.Windows.Forms.Button btnInserisciDetrazione;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtCompensoNetto;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.DataGrid gridCedolinoRitenuta;
		private System.Windows.Forms.DataGrid gridDettaglioDeduzioneCedolino;
		private System.Windows.Forms.DataGrid gridDettaglioDetrazioneCedolino;
		private System.Windows.Forms.TextBox txtNPayroll;
        private TabPage tabStorno;
        private DataGrid gridStorno;
        private Button btnEliminaStorno;
        private Button btnModificaStorno;
        private Button btnInserisciStorno;
        private TabPage tabPage1;
        private Button btnVisualizzaEpExp;
        private Button btnGeneraEP;
        private Button btnVisualizzaEP;
        private Button btnGeneraEpExp;
        private Label labEP;
        private Button btnGeneraPreImpegni;
        private Button btnViewPreimpegni;
		private GroupBox gboxUPB;
		public TextBox txtUPB;
		private TextBox txtDescrUPB;
		private Button btnUPBCode;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_payroll_default() {
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
			this.gboxContratto = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtErogazione = new System.Windows.Forms.TextBox();
			this.grpComune = new System.Windows.Forms.GroupBox();
			this.txtGeoComune = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtGGlavorati = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtCompensoLordo = new System.Windows.Forms.TextBox();
			this.chkCompleto = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtArrotondamento = new System.Windows.Forms.TextBox();
			this.labAnnoFiscale = new System.Windows.Forms.Label();
			this.txtAnnoFiscale = new System.Windows.Forms.TextBox();
			this.chktaxrelief = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabGenerale = new System.Windows.Forms.TabPage();
			this.txtNPayroll = new System.Windows.Forms.TextBox();
			this.txtCompensoNetto = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.chkConguaglio = new System.Windows.Forms.CheckBox();
			this.tabRitenuta = new System.Windows.Forms.TabPage();
			this.gridCedolinoRitenuta = new System.Windows.Forms.DataGrid();
			this.btnEliminaRitenuta = new System.Windows.Forms.Button();
			this.btnModificaRitenuta = new System.Windows.Forms.Button();
			this.btnInserisciRitenuta = new System.Windows.Forms.Button();
			this.tabDettDeduzioni = new System.Windows.Forms.TabPage();
			this.btnEliminaDeduzione = new System.Windows.Forms.Button();
			this.btnModificaDeduzione = new System.Windows.Forms.Button();
			this.btnInserisciDeduzione = new System.Windows.Forms.Button();
			this.gridDettaglioDeduzioneCedolino = new System.Windows.Forms.DataGrid();
			this.tabDettDetrazioni = new System.Windows.Forms.TabPage();
			this.btnEliminaDetrazione = new System.Windows.Forms.Button();
			this.btnModificaDetrazione = new System.Windows.Forms.Button();
			this.btnInserisciDetrazione = new System.Windows.Forms.Button();
			this.gridDettaglioDetrazioneCedolino = new System.Windows.Forms.DataGrid();
			this.tabStorno = new System.Windows.Forms.TabPage();
			this.gridStorno = new System.Windows.Forms.DataGrid();
			this.btnEliminaStorno = new System.Windows.Forms.Button();
			this.btnModificaStorno = new System.Windows.Forms.Button();
			this.btnInserisciStorno = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnGeneraPreImpegni = new System.Windows.Forms.Button();
			this.btnViewPreimpegni = new System.Windows.Forms.Button();
			this.labEP = new System.Windows.Forms.Label();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.DS = new payroll_default.vistaForm();
			this.gboxContratto.SuspendLayout();
			this.grpComune.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabGenerale.SuspendLayout();
			this.tabRitenuta.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCedolinoRitenuta)).BeginInit();
			this.tabDettDeduzioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettaglioDeduzioneCedolino)).BeginInit();
			this.tabDettDetrazioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettaglioDetrazioneCedolino)).BeginInit();
			this.tabStorno.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridStorno)).BeginInit();
			this.tabPage1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// gboxContratto
			// 
			this.gboxContratto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxContratto.Controls.Add(this.textBox5);
			this.gboxContratto.Controls.Add(this.label5);
			this.gboxContratto.Controls.Add(this.textBox4);
			this.gboxContratto.Controls.Add(this.label4);
			this.gboxContratto.Controls.Add(this.textBox3);
			this.gboxContratto.Controls.Add(this.label3);
			this.gboxContratto.Controls.Add(this.textBox2);
			this.gboxContratto.Controls.Add(this.label2);
			this.gboxContratto.Controls.Add(this.textBox1);
			this.gboxContratto.Controls.Add(this.label1);
			this.gboxContratto.Controls.Add(this.label6);
			this.gboxContratto.Controls.Add(this.textBox6);
			this.gboxContratto.Location = new System.Drawing.Point(8, 8);
			this.gboxContratto.Name = "gboxContratto";
			this.gboxContratto.Size = new System.Drawing.Size(688, 80);
			this.gboxContratto.TabIndex = 0;
			this.gboxContratto.TabStop = false;
			this.gboxContratto.Text = "Contratto";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(400, 48);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(280, 20);
			this.textBox5.TabIndex = 6;
			this.textBox5.Tag = "parasubcontractview.payroll?payrollview.descrcedolino";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(344, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Descriz.";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(176, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(64, 20);
			this.textBox4.TabIndex = 2;
			this.textBox4.Tag = "parasubcontractview.ncon?payrollview.ncon";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(128, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 24);
			this.label4.TabIndex = 6;
			this.label4.Text = "Num.";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(80, 16);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(48, 20);
			this.textBox3.TabIndex = 1;
			this.textBox3.Tag = "parasubcontractview.ycon.year?payrollview.ycon.year";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Esercizio";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(624, 16);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(56, 20);
			this.textBox2.TabIndex = 4;
			this.textBox2.Tag = "parasubcontractview.matricula?payrollview.matricula";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(584, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Matr.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(328, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(240, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Tag = "parasubcontractview.registry?payrollview.registry";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(256, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Percipiente";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 24);
			this.label6.TabIndex = 11;
			this.label6.Text = "Tipo Prestazione";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(112, 48);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(216, 20);
			this.textBox6.TabIndex = 5;
			this.textBox6.Tag = "parasubcontractview.service?payrollview.service";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(264, 96);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 20);
			this.label8.TabIndex = 3;
			this.label8.Text = "Progressivo";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(464, 256);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 23);
			this.label9.TabIndex = 5;
			this.label9.Text = "Data Erogazione";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtErogazione
			// 
			this.txtErogazione.Location = new System.Drawing.Point(576, 256);
			this.txtErogazione.Name = "txtErogazione";
			this.txtErogazione.Size = new System.Drawing.Size(104, 20);
			this.txtErogazione.TabIndex = 14;
			this.txtErogazione.Tag = "payroll.disbursementdate";
			// 
			// grpComune
			// 
			this.grpComune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpComune.Controls.Add(this.txtGeoComune);
			this.grpComune.Location = new System.Drawing.Point(8, 120);
			this.grpComune.Name = "grpComune";
			this.grpComune.Size = new System.Drawing.Size(688, 48);
			this.grpComune.TabIndex = 9;
			this.grpComune.TabStop = false;
			this.grpComune.Tag = "AutoChoose.txtGeoComune.default";
			this.grpComune.Text = "Comune di residenza";
			// 
			// txtGeoComune
			// 
			this.txtGeoComune.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtGeoComune.Location = new System.Drawing.Point(8, 16);
			this.txtGeoComune.Name = "txtGeoComune";
			this.txtGeoComune.Size = new System.Drawing.Size(672, 20);
			this.txtGeoComune.TabIndex = 0;
			this.txtGeoComune.Tag = "geo_cityview.title?payrollview.residencecity";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(32, 240);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 23);
			this.label10.TabIndex = 10;
			this.label10.Text = "Giorni lavorati";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtGGlavorati
			// 
			this.txtGGlavorati.Location = new System.Drawing.Point(120, 240);
			this.txtGGlavorati.Name = "txtGGlavorati";
			this.txtGGlavorati.Size = new System.Drawing.Size(104, 20);
			this.txtGGlavorati.TabIndex = 11;
			this.txtGGlavorati.Tag = "payroll.workingdays";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(232, 184);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 23);
			this.label11.TabIndex = 12;
			this.label11.Text = "Compenso lordo";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCompensoLordo
			// 
			this.txtCompensoLordo.Location = new System.Drawing.Point(328, 184);
			this.txtCompensoLordo.Name = "txtCompensoLordo";
			this.txtCompensoLordo.Size = new System.Drawing.Size(104, 20);
			this.txtCompensoLordo.TabIndex = 13;
			this.txtCompensoLordo.Tag = "payroll.feegross";
			// 
			// chkCompleto
			// 
			this.chkCompleto.Location = new System.Drawing.Point(528, 96);
			this.chkCompleto.Name = "chkCompleto";
			this.chkCompleto.Size = new System.Drawing.Size(72, 24);
			this.chkCompleto.TabIndex = 7;
			this.chkCompleto.Tag = "payroll.flagcomputed:S:N";
			this.chkCompleto.Text = "Completo";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(432, 216);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(136, 16);
			this.label12.TabIndex = 15;
			this.label12.Text = "Arrotondamento attuale";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtArrotondamento
			// 
			this.txtArrotondamento.Location = new System.Drawing.Point(576, 216);
			this.txtArrotondamento.Name = "txtArrotondamento";
			this.txtArrotondamento.Size = new System.Drawing.Size(104, 20);
			this.txtArrotondamento.TabIndex = 12;
			this.txtArrotondamento.Tag = "payroll.currentrounding";
			// 
			// labAnnoFiscale
			// 
			this.labAnnoFiscale.Location = new System.Drawing.Point(56, 96);
			this.labAnnoFiscale.Name = "labAnnoFiscale";
			this.labAnnoFiscale.Size = new System.Drawing.Size(88, 20);
			this.labAnnoFiscale.TabIndex = 17;
			this.labAnnoFiscale.Text = "Anno fiscale";
			this.labAnnoFiscale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAnnoFiscale
			// 
			this.txtAnnoFiscale.Location = new System.Drawing.Point(120, 96);
			this.txtAnnoFiscale.Name = "txtAnnoFiscale";
			this.txtAnnoFiscale.Size = new System.Drawing.Size(104, 20);
			this.txtAnnoFiscale.TabIndex = 6;
			this.txtAnnoFiscale.Tag = "payroll.fiscalyear.year";
			// 
			// chktaxrelief
			// 
			this.chktaxrelief.Location = new System.Drawing.Point(16, 272);
			this.chktaxrelief.Name = "chktaxrelief";
			this.chktaxrelief.Size = new System.Drawing.Size(432, 24);
			this.chktaxrelief.TabIndex = 18;
			this.chktaxrelief.Tag = "payroll.enabletaxrelief:S:N";
			this.chktaxrelief.Text = "Il percipiente ha richiesto l\'applicazione delle agevolazioni fiscali per questo " +
    "mese";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabGenerale);
			this.tabControl1.Controls.Add(this.tabRitenuta);
			this.tabControl1.Controls.Add(this.tabDettDeduzioni);
			this.tabControl1.Controls.Add(this.tabDettDetrazioni);
			this.tabControl1.Controls.Add(this.tabStorno);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(712, 328);
			this.tabControl1.TabIndex = 21;
			// 
			// tabGenerale
			// 
			this.tabGenerale.Controls.Add(this.txtNPayroll);
			this.tabGenerale.Controls.Add(this.txtCompensoNetto);
			this.tabGenerale.Controls.Add(this.label15);
			this.tabGenerale.Controls.Add(this.txtDataFine);
			this.tabGenerale.Controls.Add(this.txtDataInizio);
			this.tabGenerale.Controls.Add(this.label14);
			this.tabGenerale.Controls.Add(this.label13);
			this.tabGenerale.Controls.Add(this.chkConguaglio);
			this.tabGenerale.Controls.Add(this.chktaxrelief);
			this.tabGenerale.Controls.Add(this.label11);
			this.tabGenerale.Controls.Add(this.txtCompensoLordo);
			this.tabGenerale.Controls.Add(this.label9);
			this.tabGenerale.Controls.Add(this.txtErogazione);
			this.tabGenerale.Controls.Add(this.label12);
			this.tabGenerale.Controls.Add(this.txtArrotondamento);
			this.tabGenerale.Controls.Add(this.label10);
			this.tabGenerale.Controls.Add(this.txtGGlavorati);
			this.tabGenerale.Controls.Add(this.grpComune);
			this.tabGenerale.Controls.Add(this.label8);
			this.tabGenerale.Controls.Add(this.txtAnnoFiscale);
			this.tabGenerale.Controls.Add(this.chkCompleto);
			this.tabGenerale.Controls.Add(this.labAnnoFiscale);
			this.tabGenerale.Controls.Add(this.gboxContratto);
			this.tabGenerale.Location = new System.Drawing.Point(4, 22);
			this.tabGenerale.Name = "tabGenerale";
			this.tabGenerale.Size = new System.Drawing.Size(704, 302);
			this.tabGenerale.TabIndex = 0;
			this.tabGenerale.Text = "Generale";
			this.tabGenerale.UseVisualStyleBackColor = true;
			// 
			// txtNPayroll
			// 
			this.txtNPayroll.Location = new System.Drawing.Point(328, 96);
			this.txtNPayroll.Name = "txtNPayroll";
			this.txtNPayroll.Size = new System.Drawing.Size(104, 20);
			this.txtNPayroll.TabIndex = 22;
			this.txtNPayroll.Tag = "payroll.npayroll";
			// 
			// txtCompensoNetto
			// 
			this.txtCompensoNetto.Location = new System.Drawing.Point(328, 224);
			this.txtCompensoNetto.Name = "txtCompensoNetto";
			this.txtCompensoNetto.Size = new System.Drawing.Size(104, 20);
			this.txtCompensoNetto.TabIndex = 21;
			this.txtCompensoNetto.Tag = "payroll.netfee";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(240, 224);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 23);
			this.label15.TabIndex = 20;
			this.label15.Text = "Compenso netto";
			// 
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(120, 176);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(104, 20);
			this.txtDataFine.TabIndex = 16;
			this.txtDataFine.Tag = "payroll.stop";
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(120, 208);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(104, 20);
			this.txtDataInizio.TabIndex = 15;
			this.txtDataInizio.Tag = "payroll.start";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 176);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 23);
			this.label14.TabIndex = 19;
			this.label14.Text = "Data Fine:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(24, 208);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(88, 23);
			this.label13.TabIndex = 18;
			this.label13.Text = "Data Inizio:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkConguaglio
			// 
			this.chkConguaglio.Location = new System.Drawing.Point(528, 176);
			this.chkConguaglio.Name = "chkConguaglio";
			this.chkConguaglio.Size = new System.Drawing.Size(144, 24);
			this.chkConguaglio.TabIndex = 17;
			this.chkConguaglio.Tag = "payroll.flagbalance:S:N";
			this.chkConguaglio.Text = "Cedolino di conguaglio";
			// 
			// tabRitenuta
			// 
			this.tabRitenuta.Controls.Add(this.gridCedolinoRitenuta);
			this.tabRitenuta.Controls.Add(this.btnEliminaRitenuta);
			this.tabRitenuta.Controls.Add(this.btnModificaRitenuta);
			this.tabRitenuta.Controls.Add(this.btnInserisciRitenuta);
			this.tabRitenuta.Location = new System.Drawing.Point(4, 22);
			this.tabRitenuta.Name = "tabRitenuta";
			this.tabRitenuta.Size = new System.Drawing.Size(704, 302);
			this.tabRitenuta.TabIndex = 3;
			this.tabRitenuta.Text = "Ritenute";
			this.tabRitenuta.UseVisualStyleBackColor = true;
			// 
			// gridCedolinoRitenuta
			// 
			this.gridCedolinoRitenuta.AllowNavigation = false;
			this.gridCedolinoRitenuta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridCedolinoRitenuta.CaptionVisible = false;
			this.gridCedolinoRitenuta.DataMember = "";
			this.gridCedolinoRitenuta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridCedolinoRitenuta.Location = new System.Drawing.Point(8, 48);
			this.gridCedolinoRitenuta.Name = "gridCedolinoRitenuta";
			this.gridCedolinoRitenuta.Size = new System.Drawing.Size(688, 248);
			this.gridCedolinoRitenuta.TabIndex = 3;
			this.gridCedolinoRitenuta.Tag = "payrolltax.default.default";
			// 
			// btnEliminaRitenuta
			// 
			this.btnEliminaRitenuta.Location = new System.Drawing.Point(208, 16);
			this.btnEliminaRitenuta.Name = "btnEliminaRitenuta";
			this.btnEliminaRitenuta.Size = new System.Drawing.Size(75, 23);
			this.btnEliminaRitenuta.TabIndex = 2;
			this.btnEliminaRitenuta.Tag = "delete";
			this.btnEliminaRitenuta.Text = "Elimina";
			// 
			// btnModificaRitenuta
			// 
			this.btnModificaRitenuta.Location = new System.Drawing.Point(112, 16);
			this.btnModificaRitenuta.Name = "btnModificaRitenuta";
			this.btnModificaRitenuta.Size = new System.Drawing.Size(75, 23);
			this.btnModificaRitenuta.TabIndex = 1;
			this.btnModificaRitenuta.Tag = "edit.default";
			this.btnModificaRitenuta.Text = "Modifica";
			// 
			// btnInserisciRitenuta
			// 
			this.btnInserisciRitenuta.Location = new System.Drawing.Point(16, 16);
			this.btnInserisciRitenuta.Name = "btnInserisciRitenuta";
			this.btnInserisciRitenuta.Size = new System.Drawing.Size(75, 23);
			this.btnInserisciRitenuta.TabIndex = 0;
			this.btnInserisciRitenuta.Tag = "insert.default";
			this.btnInserisciRitenuta.Text = "Inserisci";
			// 
			// tabDettDeduzioni
			// 
			this.tabDettDeduzioni.Controls.Add(this.btnEliminaDeduzione);
			this.tabDettDeduzioni.Controls.Add(this.btnModificaDeduzione);
			this.tabDettDeduzioni.Controls.Add(this.btnInserisciDeduzione);
			this.tabDettDeduzioni.Controls.Add(this.gridDettaglioDeduzioneCedolino);
			this.tabDettDeduzioni.Location = new System.Drawing.Point(4, 22);
			this.tabDettDeduzioni.Name = "tabDettDeduzioni";
			this.tabDettDeduzioni.Size = new System.Drawing.Size(704, 302);
			this.tabDettDeduzioni.TabIndex = 1;
			this.tabDettDeduzioni.Text = "Deduzioni";
			this.tabDettDeduzioni.UseVisualStyleBackColor = true;
			// 
			// btnEliminaDeduzione
			// 
			this.btnEliminaDeduzione.Location = new System.Drawing.Point(208, 16);
			this.btnEliminaDeduzione.Name = "btnEliminaDeduzione";
			this.btnEliminaDeduzione.Size = new System.Drawing.Size(75, 23);
			this.btnEliminaDeduzione.TabIndex = 6;
			this.btnEliminaDeduzione.Tag = "delete";
			this.btnEliminaDeduzione.Text = "Elimina";
			// 
			// btnModificaDeduzione
			// 
			this.btnModificaDeduzione.Location = new System.Drawing.Point(112, 16);
			this.btnModificaDeduzione.Name = "btnModificaDeduzione";
			this.btnModificaDeduzione.Size = new System.Drawing.Size(75, 23);
			this.btnModificaDeduzione.TabIndex = 5;
			this.btnModificaDeduzione.Tag = "edit.default";
			this.btnModificaDeduzione.Text = "Modifica";
			// 
			// btnInserisciDeduzione
			// 
			this.btnInserisciDeduzione.Location = new System.Drawing.Point(16, 16);
			this.btnInserisciDeduzione.Name = "btnInserisciDeduzione";
			this.btnInserisciDeduzione.Size = new System.Drawing.Size(75, 23);
			this.btnInserisciDeduzione.TabIndex = 4;
			this.btnInserisciDeduzione.Tag = "insert.default";
			this.btnInserisciDeduzione.Text = "Inserisci";
			// 
			// gridDettaglioDeduzioneCedolino
			// 
			this.gridDettaglioDeduzioneCedolino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettaglioDeduzioneCedolino.CaptionVisible = false;
			this.gridDettaglioDeduzioneCedolino.DataMember = "";
			this.gridDettaglioDeduzioneCedolino.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettaglioDeduzioneCedolino.Location = new System.Drawing.Point(8, 48);
			this.gridDettaglioDeduzioneCedolino.Name = "gridDettaglioDeduzioneCedolino";
			this.gridDettaglioDeduzioneCedolino.Size = new System.Drawing.Size(688, 248);
			this.gridDettaglioDeduzioneCedolino.TabIndex = 3;
			this.gridDettaglioDeduzioneCedolino.Tag = "payrolldeduction.default.default";
			// 
			// tabDettDetrazioni
			// 
			this.tabDettDetrazioni.Controls.Add(this.btnEliminaDetrazione);
			this.tabDettDetrazioni.Controls.Add(this.btnModificaDetrazione);
			this.tabDettDetrazioni.Controls.Add(this.btnInserisciDetrazione);
			this.tabDettDetrazioni.Controls.Add(this.gridDettaglioDetrazioneCedolino);
			this.tabDettDetrazioni.Location = new System.Drawing.Point(4, 22);
			this.tabDettDetrazioni.Name = "tabDettDetrazioni";
			this.tabDettDetrazioni.Size = new System.Drawing.Size(704, 302);
			this.tabDettDetrazioni.TabIndex = 2;
			this.tabDettDetrazioni.Text = "Detrazioni";
			this.tabDettDetrazioni.UseVisualStyleBackColor = true;
			// 
			// btnEliminaDetrazione
			// 
			this.btnEliminaDetrazione.Location = new System.Drawing.Point(208, 16);
			this.btnEliminaDetrazione.Name = "btnEliminaDetrazione";
			this.btnEliminaDetrazione.Size = new System.Drawing.Size(75, 23);
			this.btnEliminaDetrazione.TabIndex = 6;
			this.btnEliminaDetrazione.Tag = "delete";
			this.btnEliminaDetrazione.Text = "Elimina";
			// 
			// btnModificaDetrazione
			// 
			this.btnModificaDetrazione.Location = new System.Drawing.Point(112, 16);
			this.btnModificaDetrazione.Name = "btnModificaDetrazione";
			this.btnModificaDetrazione.Size = new System.Drawing.Size(75, 23);
			this.btnModificaDetrazione.TabIndex = 5;
			this.btnModificaDetrazione.Tag = "edit.default";
			this.btnModificaDetrazione.Text = "Modifica";
			// 
			// btnInserisciDetrazione
			// 
			this.btnInserisciDetrazione.Location = new System.Drawing.Point(16, 16);
			this.btnInserisciDetrazione.Name = "btnInserisciDetrazione";
			this.btnInserisciDetrazione.Size = new System.Drawing.Size(75, 23);
			this.btnInserisciDetrazione.TabIndex = 4;
			this.btnInserisciDetrazione.Tag = "insert.default";
			this.btnInserisciDetrazione.Text = "Inserisci";
			// 
			// gridDettaglioDetrazioneCedolino
			// 
			this.gridDettaglioDetrazioneCedolino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettaglioDetrazioneCedolino.CaptionVisible = false;
			this.gridDettaglioDetrazioneCedolino.DataMember = "";
			this.gridDettaglioDetrazioneCedolino.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettaglioDetrazioneCedolino.Location = new System.Drawing.Point(8, 48);
			this.gridDettaglioDetrazioneCedolino.Name = "gridDettaglioDetrazioneCedolino";
			this.gridDettaglioDetrazioneCedolino.Size = new System.Drawing.Size(688, 248);
			this.gridDettaglioDetrazioneCedolino.TabIndex = 3;
			this.gridDettaglioDetrazioneCedolino.Tag = "payrollabatement.default.default";
			// 
			// tabStorno
			// 
			this.tabStorno.Controls.Add(this.gridStorno);
			this.tabStorno.Controls.Add(this.btnEliminaStorno);
			this.tabStorno.Controls.Add(this.btnModificaStorno);
			this.tabStorno.Controls.Add(this.btnInserisciStorno);
			this.tabStorno.Location = new System.Drawing.Point(4, 22);
			this.tabStorno.Name = "tabStorno";
			this.tabStorno.Size = new System.Drawing.Size(704, 302);
			this.tabStorno.TabIndex = 4;
			this.tabStorno.Text = "Storni";
			this.tabStorno.UseVisualStyleBackColor = true;
			// 
			// gridStorno
			// 
			this.gridStorno.AllowNavigation = false;
			this.gridStorno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridStorno.CaptionVisible = false;
			this.gridStorno.DataMember = "";
			this.gridStorno.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridStorno.Location = new System.Drawing.Point(12, 42);
			this.gridStorno.Name = "gridStorno";
			this.gridStorno.Size = new System.Drawing.Size(688, 248);
			this.gridStorno.TabIndex = 6;
			this.gridStorno.Tag = "payrolltaxcorrige.default.default";
			// 
			// btnEliminaStorno
			// 
			this.btnEliminaStorno.Location = new System.Drawing.Point(204, 13);
			this.btnEliminaStorno.Name = "btnEliminaStorno";
			this.btnEliminaStorno.Size = new System.Drawing.Size(75, 23);
			this.btnEliminaStorno.TabIndex = 5;
			this.btnEliminaStorno.Tag = "delete";
			this.btnEliminaStorno.Text = "Elimina";
			// 
			// btnModificaStorno
			// 
			this.btnModificaStorno.Location = new System.Drawing.Point(108, 13);
			this.btnModificaStorno.Name = "btnModificaStorno";
			this.btnModificaStorno.Size = new System.Drawing.Size(75, 23);
			this.btnModificaStorno.TabIndex = 4;
			this.btnModificaStorno.Tag = "edit.default";
			this.btnModificaStorno.Text = "Modifica";
			// 
			// btnInserisciStorno
			// 
			this.btnInserisciStorno.Location = new System.Drawing.Point(12, 13);
			this.btnInserisciStorno.Name = "btnInserisciStorno";
			this.btnInserisciStorno.Size = new System.Drawing.Size(75, 23);
			this.btnInserisciStorno.TabIndex = 3;
			this.btnInserisciStorno.Tag = "insert.default";
			this.btnInserisciStorno.Text = "Inserisci";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gboxUPB);
			this.tabPage1.Controls.Add(this.btnGeneraPreImpegni);
			this.tabPage1.Controls.Add(this.btnViewPreimpegni);
			this.tabPage1.Controls.Add(this.labEP);
			this.tabPage1.Controls.Add(this.btnGeneraEpExp);
			this.tabPage1.Controls.Add(this.btnVisualizzaEpExp);
			this.tabPage1.Controls.Add(this.btnGeneraEP);
			this.tabPage1.Controls.Add(this.btnVisualizzaEP);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(704, 302);
			this.tabPage1.TabIndex = 5;
			this.tabPage1.Text = "E/P";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnGeneraPreImpegni
			// 
			this.btnGeneraPreImpegni.Location = new System.Drawing.Point(19, 91);
			this.btnGeneraPreImpegni.Name = "btnGeneraPreImpegni";
			this.btnGeneraPreImpegni.Size = new System.Drawing.Size(282, 23);
			this.btnGeneraPreImpegni.TabIndex = 29;
			this.btnGeneraPreImpegni.Text = "Genera preimpegni di Budget";
			// 
			// btnViewPreimpegni
			// 
			this.btnViewPreimpegni.Location = new System.Drawing.Point(19, 123);
			this.btnViewPreimpegni.Name = "btnViewPreimpegni";
			this.btnViewPreimpegni.Size = new System.Drawing.Size(282, 23);
			this.btnViewPreimpegni.TabIndex = 28;
			this.btnViewPreimpegni.Text = "Visualizza preimpegni di Budget";
			// 
			// labEP
			// 
			this.labEP.Location = new System.Drawing.Point(16, 13);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(298, 16);
			this.labEP.TabIndex = 27;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(320, 91);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEpExp.TabIndex = 26;
			this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(320, 120);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEpExp.TabIndex = 19;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
			this.btnVisualizzaEpExp.Visible = false;
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(320, 54);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEP.TabIndex = 18;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(320, 22);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEP.TabIndex = 17;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.Location = new System.Drawing.Point(488, 352);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 22;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "OK";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(608, 352);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Tag = "";
			this.btnCancel.Text = "Annulla";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(19, 160);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(305, 104);
			this.gboxUPB.TabIndex = 30;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(8, 77);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(288, 20);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(175, 9);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(121, 62);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(8, 51);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
			this.btnUPBCode.TabIndex = 2;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "manage.upb.tree";
			this.btnUPBCode.Text = "UPB:";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_payroll_default
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(728, 390);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_payroll_default";
			this.Text = "FrmCedolino";
			this.gboxContratto.ResumeLayout(false);
			this.gboxContratto.PerformLayout();
			this.grpComune.ResumeLayout(false);
			this.grpComune.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabGenerale.ResumeLayout(false);
			this.tabGenerale.PerformLayout();
			this.tabRitenuta.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridCedolinoRitenuta)).EndInit();
			this.tabDettDeduzioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridDettaglioDeduzioneCedolino)).EndInit();
			this.tabDettDetrazioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridDettaglioDetrazioneCedolino)).EndInit();
			this.tabStorno.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridStorno)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
        QueryHelper QHS;
        CQueryHelper QHC;
        private EP_Manager EPM;
        DataAccess Conn;
        int esercizio;
        bool isAdmin;
		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			object flagMenuAdmin = Meta.GetSys("manage_prestazioni");
			isAdmin = (flagMenuAdmin != null) && (flagMenuAdmin.ToString() == "S");
			abilitaControlli();
			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
		
            esercizio= (int)Meta.GetSys("esercizio");
            filteresercizio = QHS.CmpEq("ayear", esercizio);
            string filterannofiscale = QHS.CmpEq("fiscalyear", esercizio);
			GetData.SetStaticFilter(DS.parasubcontractview,filteresercizio);
			GetData.SetStaticFilter(DS.payrollview,filterannofiscale);
			btnInserisciRitenuta.Visible = isAdmin;
			btnEliminaRitenuta.Visible = isAdmin;
			btnInserisciDeduzione.Visible = isAdmin;
			btnEliminaDeduzione.Visible = isAdmin;
			btnInserisciDetrazione.Visible = isAdmin;
			btnEliminaDetrazione.Visible = isAdmin;
            btnInserisciStorno.Visible = isAdmin;
            btnEliminaStorno.Visible = isAdmin;
            GetData.SetStaticFilter(DS.abatementcode, filteresercizio);
            GetData.SetStaticFilter(DS.deductioncode, filteresercizio);
            if (Meta.edit_type == "readonly") {
                btnOk.Visible = false;
                btnCancel.Visible = false;
            }
            if (Meta.edit_type == "default"|| Meta.edit_type == "readonly") {
                EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreImpegni, btnViewPreimpegni,
                btnGeneraEP, btnVisualizzaEP, labEP, null, "payroll");
            }
            else 
                if (Meta.edit_type == "readonly_dettaglio") {
                EPM = new EP_Manager(Meta, null, btnVisualizzaEpExp, null, btnViewPreimpegni,
                null, btnVisualizzaEP, labEP, null, "payroll");
                btnGeneraEpExp.Visible  = false;
                btnGeneraPreImpegni.Visible = false;
                btnGeneraEP.Visible = false;
                Meta.CanSave = false;
                btnOk.Visible = false;
            }
            HelpForm.SetDenyNull(DS.payroll.Columns["flagbalance"],true);
        }

        public void MetaData_AfterClear() {
            abilitaControlli();
            EPM.mostraEtichette();
        }

        public void MetaData_AfterFill() {
            if (Meta.FirstFillForThisRow) {
                abilitaControlli();
            }
            EPM.mostraEtichette();

        }

		void abilitaControlli(){
            bool abilita = isAdmin || Meta.IsEmpty;
			gridCedolinoRitenuta.Tag = isAdmin 
				? "payrolltax.default.default" 
				: "payrolltax.default.readonly";	
			gridDettaglioDeduzioneCedolino.Tag = isAdmin
				? "payrolldeduction.default.default"
				: "payrolldeduction.default.readonly";
			gridDettaglioDetrazioneCedolino.Tag = isAdmin
				? "payrollabatement.default.default"
				: "payrollabatement.default.readonly";
            gridStorno.Tag = isAdmin
                ? "payrolltaxcorrige.default.default"
                : "payrolltaxcorrige.default.readonly";
			btnModificaDeduzione.Text = isAdmin ? "Modifica" : "Visualizza";
			btnModificaDetrazione.Text = isAdmin ? "Modifica" : "Visualizza";
			btnModificaRitenuta.Text = isAdmin ? "Modifica" : "Visualizza";
            btnModificaStorno.Text = isAdmin ? "Modifica" : "Visualizza";
			btnModificaRitenuta.Tag = isAdmin ? "edit.default" : "edit.readonly";
			btnModificaDeduzione.Tag = isAdmin ? "edit.default" : "edit.readonly";
			btnModificaDetrazione.Tag = isAdmin ? "edit.default" : "edit.readonly";
            btnModificaStorno.Tag = isAdmin ? "edit.default" : "edit.readonly";
            gboxContratto.Enabled = abilita;
            txtAnnoFiscale.ReadOnly = !abilita;
//			txtAnnoRif.ReadOnly = !isAdmin;
//			cmbMeseRif.Enabled = isAdmin;
            chkCompleto.Enabled = abilita;
            txtArrotondamento.ReadOnly = !abilita;
            txtErogazione.ReadOnly = !abilita;
            txtCompensoLordo.ReadOnly = !abilita;
            txtCompensoNetto.ReadOnly = !abilita;
            txtGGlavorati.ReadOnly = !abilita;
            grpComune.Enabled = abilita;
            chkConguaglio.Enabled = abilita;
            txtDataInizio.ReadOnly = !abilita;
            txtDataFine.ReadOnly = !abilita;
            chktaxrelief.Enabled = abilita;
		}

       


      

	}
}