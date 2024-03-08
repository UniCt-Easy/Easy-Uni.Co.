
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;//funzioni_configurazione
using System.Collections.Generic;
using siopeplus_functions;
using System.Linq;
using incassi = bankdispositionsetup_siopeplus_incassi;
using pp = meta_proceeds;

namespace proceeds_reversalemultipla{//documentoincasso_multiplo//
	/// <summary>
	/// Summary description for frmdocumentoincasso_multiplo.
	/// Revised By Nino 26/1/2003
	/// revised By Nino 21/2/2003
	/// revised By Nino on 8/3/2003
	/// </summary>
	public class Frm_proceeds_reversalemultipla : MetaDataForm {
        QueryHelper QHS;
        CQueryHelper QHC = new CQueryHelper();
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtDataStampa;
		private System.Windows.Forms.Button btnScollega;
		private System.Windows.Forms.Button btnCollega;
		private System.Windows.Forms.TextBox txtImporto;
		public  dsmeta DS;
		private System.Windows.Forms.DataGrid dgrRigheReversale;
		private System.Windows.Forms.Button btnSituazione;
		private System.Windows.Forms.GroupBox gboxMovimenti;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnIstitutoCassiere;
		private System.Windows.Forms.ComboBox cmbCodiceIstituto;
		private System.Windows.Forms.GroupBox grpConto;
		private System.Windows.Forms.RadioButton rdbInfruttifero;
		private System.Windows.Forms.RadioButton rdbFruttifero;
		private System.Windows.Forms.GroupBox grpBilancio;
		private System.Windows.Forms.TextBox txtDescrBilancio;
		private System.Windows.Forms.TextBox txtBilancio;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.GroupBox grpCredDeb;
        private System.Windows.Forms.TextBox txtCreditoreDebitore;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNumeroDocumento;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEsercizioDocumento;
		bool flagcreddeb;
		bool flagbilancio;
		bool flagrespons;
		bool flagresidui;
        private System.Windows.Forms.Button btnModifica;
		MetaData Meta;
		private System.Windows.Forms.TextBox txtDataAnnullo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.TabPage tabBanca;
		private System.Windows.Forms.TextBox txtDaEsitare;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtEsitato;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DataGrid dataGrid3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnEsitoInserisci;
		private System.Windows.Forms.Button btnEsitoModifica;
		private System.Windows.Forms.Button btnEsitoElimina;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button btnEsitaTutto;
        private GroupBox gboxtipo;
        private CheckBox chkMisto;
        private CheckBox chkResidui;
        private CheckBox chkCompetenza;
        private ComboBox cmbBollo;
        private Button btnBollo;
        private TabPage tabAttributi;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        public GroupBox gboxclass05;
        public TextBox txtCodice05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public TextBox txtCodice04;
        public Button btnCodice04;
        private TextBox txtDenom04;
        public GroupBox gboxclass03;
        public TextBox txtCodice03;
        public Button btnCodice03;
        private TextBox txtDenom03;
        public GroupBox gboxclass02;
        public TextBox txtCodice02;
        public Button btnCodice02;
        private TextBox txtDenom02;
        public GroupBox gboxclass01;
        public TextBox txtCodice01;
        public Button btnCodice01;
        private TextBox txtDenom01;
        private Label label7;
        private TextBox txtNPro_Treasurer;
        private Button btnFlussoCrediti;
        private GroupBox grpTrasmSiope;
        private Button btnControllaFileOPI;
        private System.ComponentModel.IContainer components;

		public Frm_proceeds_reversalemultipla() {
			InitializeComponent();
			QueryCreator.SetTableForPosting(DS.incomelastview, "incomelast");
			QueryCreator.SetTableForPosting(DS.proceeds_bankview, "proceeds_bank");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_proceeds_reversalemultipla));
			this.DS = new proceeds_reversalemultipla.dsmeta();
			this.btnSituazione = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDataStampa = new System.Windows.Forms.TextBox();
			this.btnScollega = new System.Windows.Forms.Button();
			this.btnCollega = new System.Windows.Forms.Button();
			this.dgrRigheReversale = new System.Windows.Forms.DataGrid();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.gboxMovimenti = new System.Windows.Forms.GroupBox();
			this.btnFlussoCrediti = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cmbBollo = new System.Windows.Forms.ComboBox();
			this.btnBollo = new System.Windows.Forms.Button();
			this.btnIstitutoCassiere = new System.Windows.Forms.Button();
			this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
			this.grpConto = new System.Windows.Forms.GroupBox();
			this.rdbInfruttifero = new System.Windows.Forms.RadioButton();
			this.rdbFruttifero = new System.Windows.Forms.RadioButton();
			this.grpBilancio = new System.Windows.Forms.GroupBox();
			this.txtDescrBilancio = new System.Windows.Forms.TextBox();
			this.txtBilancio = new System.Windows.Forms.TextBox();
			this.btnBilancio = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.grpCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCreditoreDebitore = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercizioDocumento = new System.Windows.Forms.TextBox();
			this.txtDataAnnullo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.grpTrasmSiope = new System.Windows.Forms.GroupBox();
			this.btnControllaFileOPI = new System.Windows.Forms.Button();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.tabBanca = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btnEsitaTutto = new System.Windows.Forms.Button();
			this.btnEsitoInserisci = new System.Windows.Forms.Button();
			this.btnEsitoModifica = new System.Windows.Forms.Button();
			this.btnEsitoElimina = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.txtDaEsitare = new System.Windows.Forms.TextBox();
			this.txtEsitato = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.label11 = new System.Windows.Forms.Label();
			this.tabAttributi = new System.Windows.Forms.TabPage();
			this.gboxclass05 = new System.Windows.Forms.GroupBox();
			this.txtCodice05 = new System.Windows.Forms.TextBox();
			this.btnCodice05 = new System.Windows.Forms.Button();
			this.txtDenom05 = new System.Windows.Forms.TextBox();
			this.gboxclass04 = new System.Windows.Forms.GroupBox();
			this.txtCodice04 = new System.Windows.Forms.TextBox();
			this.btnCodice04 = new System.Windows.Forms.Button();
			this.txtDenom04 = new System.Windows.Forms.TextBox();
			this.gboxclass03 = new System.Windows.Forms.GroupBox();
			this.txtCodice03 = new System.Windows.Forms.TextBox();
			this.btnCodice03 = new System.Windows.Forms.Button();
			this.txtDenom03 = new System.Windows.Forms.TextBox();
			this.gboxclass02 = new System.Windows.Forms.GroupBox();
			this.txtCodice02 = new System.Windows.Forms.TextBox();
			this.btnCodice02 = new System.Windows.Forms.Button();
			this.txtDenom02 = new System.Windows.Forms.TextBox();
			this.gboxclass01 = new System.Windows.Forms.GroupBox();
			this.txtCodice01 = new System.Windows.Forms.TextBox();
			this.btnCodice01 = new System.Windows.Forms.Button();
			this.txtDenom01 = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.gboxtipo = new System.Windows.Forms.GroupBox();
			this.chkMisto = new System.Windows.Forms.CheckBox();
			this.chkResidui = new System.Windows.Forms.CheckBox();
			this.chkCompetenza = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNPro_Treasurer = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgrRigheReversale)).BeginInit();
			this.gboxMovimenti.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.grpConto.SuspendLayout();
			this.grpBilancio.SuspendLayout();
			this.grpCredDeb.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPrincipale.SuspendLayout();
			this.grpTrasmSiope.SuspendLayout();
			this.gboxResponsabile.SuspendLayout();
			this.tabBanca.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.gboxtipo.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnSituazione
			// 
			this.btnSituazione.Location = new System.Drawing.Point(842, 144);
			this.btnSituazione.Name = "btnSituazione";
			this.btnSituazione.Size = new System.Drawing.Size(75, 23);
			this.btnSituazione.TabIndex = 80;
			this.btnSituazione.TabStop = false;
			this.btnSituazione.Text = "Situazione";
			this.btnSituazione.Visible = false;
			this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click_1);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 66;
			this.label3.Text = "Data trasm.:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(88, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(96, 20);
			this.textBox2.TabIndex = 11;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "proceedstransmission.transmissiondate";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 64;
			this.label4.Text = "Numero:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(88, 16);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(96, 20);
			this.textBox3.TabIndex = 10;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "proceedstransmission.nproceedstransmission";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(487, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 16);
			this.label9.TabIndex = 60;
			this.label9.Text = "Data contabile:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(575, 48);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(96, 20);
			this.txtDataContabile.TabIndex = 9;
			this.txtDataContabile.Tag = "proceeds.adate?proceedsview.adate";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(479, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 16);
			this.label8.TabIndex = 58;
			this.label8.Text = "Stampa ufficiale:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataStampa
			// 
			this.txtDataStampa.Location = new System.Drawing.Point(575, 24);
			this.txtDataStampa.Name = "txtDataStampa";
			this.txtDataStampa.Size = new System.Drawing.Size(96, 20);
			this.txtDataStampa.TabIndex = 8;
			this.txtDataStampa.Tag = "proceeds.printdate?proceedsview.printdate";
			// 
			// btnScollega
			// 
			this.btnScollega.Location = new System.Drawing.Point(8, 56);
			this.btnScollega.Name = "btnScollega";
			this.btnScollega.Size = new System.Drawing.Size(96, 23);
			this.btnScollega.TabIndex = 2;
			this.btnScollega.Tag = "";
			this.btnScollega.Text = "Rimuovi";
			this.btnScollega.Click += new System.EventHandler(this.btnScollega_Click);
			// 
			// btnCollega
			// 
			this.btnCollega.Location = new System.Drawing.Point(8, 24);
			this.btnCollega.Name = "btnCollega";
			this.btnCollega.Size = new System.Drawing.Size(96, 23);
			this.btnCollega.TabIndex = 1;
			this.btnCollega.Tag = "";
			this.btnCollega.Text = "Inserisci";
			this.btnCollega.Click += new System.EventHandler(this.btnCollega_Click);
			// 
			// dgrRigheReversale
			// 
			this.dgrRigheReversale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrRigheReversale.DataMember = "";
			this.dgrRigheReversale.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrRigheReversale.Location = new System.Drawing.Point(110, 16);
			this.dgrRigheReversale.Name = "dgrRigheReversale";
			this.dgrRigheReversale.Size = new System.Drawing.Size(792, 189);
			this.dgrRigheReversale.TabIndex = 3;
			this.dgrRigheReversale.TabStop = false;
			this.dgrRigheReversale.Tag = "incomelastview.documentocollegato";
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(6, 16);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.ReadOnly = true;
			this.txtImporto.Size = new System.Drawing.Size(140, 20);
			this.txtImporto.TabIndex = 1;
			this.txtImporto.TabStop = false;
			this.txtImporto.Tag = "";
			// 
			// gboxMovimenti
			// 
			this.gboxMovimenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxMovimenti.Controls.Add(this.btnFlussoCrediti);
			this.gboxMovimenti.Controls.Add(this.btnModifica);
			this.gboxMovimenti.Controls.Add(this.dgrRigheReversale);
			this.gboxMovimenti.Controls.Add(this.btnScollega);
			this.gboxMovimenti.Controls.Add(this.btnCollega);
			this.gboxMovimenti.Location = new System.Drawing.Point(8, 224);
			this.gboxMovimenti.Name = "gboxMovimenti";
			this.gboxMovimenti.Size = new System.Drawing.Size(910, 213);
			this.gboxMovimenti.TabIndex = 12;
			this.gboxMovimenti.TabStop = false;
			this.gboxMovimenti.Text = "Movimenti di entrata inseriti nella reversale";
			// 
			// btnFlussoCrediti
			// 
			this.btnFlussoCrediti.Location = new System.Drawing.Point(7, 182);
			this.btnFlussoCrediti.Name = "btnFlussoCrediti";
			this.btnFlussoCrediti.Size = new System.Drawing.Size(97, 23);
			this.btnFlussoCrediti.TabIndex = 100;
			this.btnFlussoCrediti.Text = "Flusso crediti";
			this.btnFlussoCrediti.UseVisualStyleBackColor = true;
			this.btnFlussoCrediti.Visible = false;
			this.btnFlussoCrediti.Click += new System.EventHandler(this.btnFlussoCrediti_Click);
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(8, 88);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(96, 23);
			this.btnModifica.TabIndex = 5;
			this.btnModifica.Text = "Modifica...";
			this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtImporto);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.Location = new System.Drawing.Point(786, 5);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(152, 47);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Importo totale";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cmbBollo);
			this.groupBox3.Controls.Add(this.btnBollo);
			this.groupBox3.Controls.Add(this.btnIstitutoCassiere);
			this.groupBox3.Controls.Add(this.cmbCodiceIstituto);
			this.groupBox3.Location = new System.Drawing.Point(8, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(448, 80);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			// 
			// cmbBollo
			// 
			this.cmbBollo.DataSource = this.DS.stamphandling;
			this.cmbBollo.DisplayMember = "description";
			this.cmbBollo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBollo.Location = new System.Drawing.Point(120, 46);
			this.cmbBollo.Name = "cmbBollo";
			this.cmbBollo.Size = new System.Drawing.Size(322, 21);
			this.cmbBollo.TabIndex = 76;
			this.cmbBollo.Tag = "proceeds.idstamphandling?proceedsview.idstamphandling";
			this.cmbBollo.ValueMember = "idstamphandling";
			// 
			// btnBollo
			// 
			this.btnBollo.Location = new System.Drawing.Point(7, 46);
			this.btnBollo.Name = "btnBollo";
			this.btnBollo.Size = new System.Drawing.Size(104, 24);
			this.btnBollo.TabIndex = 77;
			this.btnBollo.TabStop = false;
			this.btnBollo.Tag = "manage.stamphandling.lista";
			this.btnBollo.Text = "Bollo:";
			this.btnBollo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnIstitutoCassiere
			// 
			this.btnIstitutoCassiere.Location = new System.Drawing.Point(8, 16);
			this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
			this.btnIstitutoCassiere.Size = new System.Drawing.Size(104, 24);
			this.btnIstitutoCassiere.TabIndex = 45;
			this.btnIstitutoCassiere.TabStop = false;
			this.btnIstitutoCassiere.Tag = "choose.treasurer.lista.(active=\'S\')";
			this.btnIstitutoCassiere.Text = "Cassiere:";
			this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbCodiceIstituto
			// 
			this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
			this.cmbCodiceIstituto.DisplayMember = "description";
			this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCodiceIstituto.Location = new System.Drawing.Point(120, 16);
			this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
			this.cmbCodiceIstituto.Size = new System.Drawing.Size(322, 21);
			this.cmbCodiceIstituto.TabIndex = 1;
			this.cmbCodiceIstituto.Tag = "proceeds.idtreasurer?proceedsview.idtreasurer";
			this.cmbCodiceIstituto.ValueMember = "idtreasurer";
			// 
			// grpConto
			// 
			this.grpConto.Controls.Add(this.rdbInfruttifero);
			this.grpConto.Controls.Add(this.rdbFruttifero);
			this.grpConto.Location = new System.Drawing.Point(610, 5);
			this.grpConto.Name = "grpConto";
			this.grpConto.Size = new System.Drawing.Size(170, 49);
			this.grpConto.TabIndex = 3;
			this.grpConto.TabStop = false;
			this.grpConto.Text = "Conto";
			// 
			// rdbInfruttifero
			// 
			this.rdbInfruttifero.Location = new System.Drawing.Point(87, 17);
			this.rdbInfruttifero.Name = "rdbInfruttifero";
			this.rdbInfruttifero.Size = new System.Drawing.Size(80, 19);
			this.rdbInfruttifero.TabIndex = 1;
			this.rdbInfruttifero.Tag = "proceeds.flag::#3";
			this.rdbInfruttifero.Text = "Infruttifero";
			// 
			// rdbFruttifero
			// 
			this.rdbFruttifero.Location = new System.Drawing.Point(7, 18);
			this.rdbFruttifero.Name = "rdbFruttifero";
			this.rdbFruttifero.Size = new System.Drawing.Size(83, 19);
			this.rdbFruttifero.TabIndex = 0;
			this.rdbFruttifero.Tag = "proceeds.flag::3";
			this.rdbFruttifero.Text = "Fruttifero";
			// 
			// grpBilancio
			// 
			this.grpBilancio.Controls.Add(this.txtDescrBilancio);
			this.grpBilancio.Controls.Add(this.txtBilancio);
			this.grpBilancio.Controls.Add(this.btnBilancio);
			this.grpBilancio.Location = new System.Drawing.Point(8, 123);
			this.grpBilancio.Name = "grpBilancio";
			this.grpBilancio.Size = new System.Drawing.Size(448, 95);
			this.grpBilancio.TabIndex = 7;
			this.grpBilancio.TabStop = false;
			this.grpBilancio.Tag = "AutoManage.txtBilancio.treee";
			this.grpBilancio.Text = "Bilancio";
			// 
			// txtDescrBilancio
			// 
			this.txtDescrBilancio.Location = new System.Drawing.Point(122, 15);
			this.txtDescrBilancio.Multiline = true;
			this.txtDescrBilancio.Name = "txtDescrBilancio";
			this.txtDescrBilancio.ReadOnly = true;
			this.txtDescrBilancio.Size = new System.Drawing.Size(320, 48);
			this.txtDescrBilancio.TabIndex = 2;
			this.txtDescrBilancio.TabStop = false;
			this.txtDescrBilancio.Tag = "fin.title";
			// 
			// txtBilancio
			// 
			this.txtBilancio.Location = new System.Drawing.Point(8, 69);
			this.txtBilancio.Name = "txtBilancio";
			this.txtBilancio.Size = new System.Drawing.Size(434, 20);
			this.txtBilancio.TabIndex = 1;
			this.txtBilancio.Tag = "fin.codefin?proceedsview.codefin";
			// 
			// btnBilancio
			// 
			this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBilancio.ImageIndex = 0;
			this.btnBilancio.ImageList = this.imageList1;
			this.btnBilancio.Location = new System.Drawing.Point(8, 39);
			this.btnBilancio.Name = "btnBilancio";
			this.btnBilancio.Size = new System.Drawing.Size(80, 24);
			this.btnBilancio.TabIndex = 62;
			this.btnBilancio.TabStop = false;
			this.btnBilancio.Tag = "manage.fin.treee";
			this.btnBilancio.Text = "Bilancio:";
			this.btnBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// grpCredDeb
			// 
			this.grpCredDeb.Controls.Add(this.txtCreditoreDebitore);
			this.grpCredDeb.Location = new System.Drawing.Point(7, 84);
			this.grpCredDeb.Name = "grpCredDeb";
			this.grpCredDeb.Size = new System.Drawing.Size(448, 37);
			this.grpCredDeb.TabIndex = 6;
			this.grpCredDeb.TabStop = false;
			this.grpCredDeb.Tag = "AutoChoose.txtCreditoreDebitore.lista.(active=\'S\')";
			this.grpCredDeb.Text = "Versante";
			// 
			// txtCreditoreDebitore
			// 
			this.txtCreditoreDebitore.Location = new System.Drawing.Point(8, 14);
			this.txtCreditoreDebitore.Name = "txtCreditoreDebitore";
			this.txtCreditoreDebitore.Size = new System.Drawing.Size(434, 20);
			this.txtCreditoreDebitore.TabIndex = 1;
			this.txtCreditoreDebitore.Tag = "registry.title?proceedsview.registry";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtNumeroDocumento);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtEsercizioDocumento);
			this.groupBox1.Location = new System.Drawing.Point(8, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(325, 47);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Documento";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(155, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Numero:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumeroDocumento
			// 
			this.txtNumeroDocumento.Location = new System.Drawing.Point(224, 16);
			this.txtNumeroDocumento.Name = "txtNumeroDocumento";
			this.txtNumeroDocumento.Size = new System.Drawing.Size(95, 20);
			this.txtNumeroDocumento.TabIndex = 2;
			this.txtNumeroDocumento.Tag = "proceeds.npro?proceedsview.npro";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioDocumento
			// 
			this.txtEsercizioDocumento.Location = new System.Drawing.Point(92, 16);
			this.txtEsercizioDocumento.Name = "txtEsercizioDocumento";
			this.txtEsercizioDocumento.ReadOnly = true;
			this.txtEsercizioDocumento.Size = new System.Drawing.Size(56, 20);
			this.txtEsercizioDocumento.TabIndex = 1;
			this.txtEsercizioDocumento.TabStop = false;
			this.txtEsercizioDocumento.Tag = "proceeds.ypro?proceedsview.ypro";
			// 
			// txtDataAnnullo
			// 
			this.txtDataAnnullo.Location = new System.Drawing.Point(575, 139);
			this.txtDataAnnullo.Name = "txtDataAnnullo";
			this.txtDataAnnullo.Size = new System.Drawing.Size(100, 20);
			this.txtDataAnnullo.TabIndex = 93;
			this.txtDataAnnullo.Tag = "proceeds.annulmentdate";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(484, 131);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 40);
			this.label5.TabIndex = 92;
			this.label5.Text = "Data Annullamento";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Controls.Add(this.textBox3);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.textBox2);
			this.groupBox5.Location = new System.Drawing.Point(728, 10);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(192, 72);
			this.groupBox5.TabIndex = 94;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Distinta di trasmissione";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPrincipale);
			this.tabControl1.Controls.Add(this.tabBanca);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Location = new System.Drawing.Point(8, 102);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(934, 469);
			this.tabControl1.TabIndex = 95;
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.Controls.Add(this.grpTrasmSiope);
			this.tabPrincipale.Controls.Add(this.gboxResponsabile);
			this.tabPrincipale.Controls.Add(this.groupBox3);
			this.tabPrincipale.Controls.Add(this.label8);
			this.tabPrincipale.Controls.Add(this.btnSituazione);
			this.tabPrincipale.Controls.Add(this.grpBilancio);
			this.tabPrincipale.Controls.Add(this.label5);
			this.tabPrincipale.Controls.Add(this.groupBox5);
			this.tabPrincipale.Controls.Add(this.grpCredDeb);
			this.tabPrincipale.Controls.Add(this.label9);
			this.tabPrincipale.Controls.Add(this.txtDataContabile);
			this.tabPrincipale.Controls.Add(this.txtDataStampa);
			this.tabPrincipale.Controls.Add(this.txtDataAnnullo);
			this.tabPrincipale.Controls.Add(this.gboxMovimenti);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Size = new System.Drawing.Size(926, 443);
			this.tabPrincipale.TabIndex = 0;
			this.tabPrincipale.Text = "Principale";
			this.tabPrincipale.UseVisualStyleBackColor = true;
			// 
			// grpTrasmSiope
			// 
			this.grpTrasmSiope.Controls.Add(this.btnControllaFileOPI);
			this.grpTrasmSiope.Location = new System.Drawing.Point(472, 176);
			this.grpTrasmSiope.Name = "grpTrasmSiope";
			this.grpTrasmSiope.Size = new System.Drawing.Size(446, 39);
			this.grpTrasmSiope.TabIndex = 96;
			this.grpTrasmSiope.TabStop = false;
			this.grpTrasmSiope.Text = "Trasmissione SIOPE+";
			// 
			// btnControllaFileOPI
			// 
			this.btnControllaFileOPI.Location = new System.Drawing.Point(285, 10);
			this.btnControllaFileOPI.Name = "btnControllaFileOPI";
			this.btnControllaFileOPI.Size = new System.Drawing.Size(157, 23);
			this.btnControllaFileOPI.TabIndex = 91;
			this.btnControllaFileOPI.Text = "Controlla dimensione file";
			this.btnControllaFileOPI.UseVisualStyleBackColor = true;
			this.btnControllaFileOPI.Click += new System.EventHandler(this.btnControllaFileOPI_Click);
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Location = new System.Drawing.Point(472, 88);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(448, 40);
			this.gboxResponsabile.TabIndex = 95;
			this.gboxResponsabile.TabStop = false;
			this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
			this.gboxResponsabile.Text = "Responsabile";
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(5, 14);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.Size = new System.Drawing.Size(437, 20);
			this.txtResponsabile.TabIndex = 0;
			this.txtResponsabile.Tag = "manager.title?x";
			// 
			// tabBanca
			// 
			this.tabBanca.Controls.Add(this.groupBox6);
			this.tabBanca.Controls.Add(this.panel1);
			this.tabBanca.Controls.Add(this.dataGrid3);
			this.tabBanca.Controls.Add(this.label11);
			this.tabBanca.Location = new System.Drawing.Point(4, 22);
			this.tabBanca.Name = "tabBanca";
			this.tabBanca.Size = new System.Drawing.Size(926, 443);
			this.tabBanca.TabIndex = 1;
			this.tabBanca.Text = "Banca";
			this.tabBanca.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.btnEsitaTutto);
			this.groupBox6.Controls.Add(this.btnEsitoInserisci);
			this.groupBox6.Controls.Add(this.btnEsitoModifica);
			this.groupBox6.Controls.Add(this.btnEsitoElimina);
			this.groupBox6.Controls.Add(this.label10);
			this.groupBox6.Controls.Add(this.txtDaEsitare);
			this.groupBox6.Controls.Add(this.txtEsitato);
			this.groupBox6.Controls.Add(this.label6);
			this.groupBox6.Controls.Add(this.dataGrid2);
			this.groupBox6.Location = new System.Drawing.Point(8, 192);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(910, 245);
			this.groupBox6.TabIndex = 41;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Dettaglio degli esiti associati alla reversale";
			// 
			// btnEsitaTutto
			// 
			this.btnEsitaTutto.Location = new System.Drawing.Point(8, 16);
			this.btnEsitaTutto.Name = "btnEsitaTutto";
			this.btnEsitaTutto.Size = new System.Drawing.Size(128, 22);
			this.btnEsitaTutto.TabIndex = 37;
			this.btnEsitaTutto.Tag = "";
			this.btnEsitaTutto.Text = "Esita tutta la reversale...";
			this.btnEsitaTutto.Click += new System.EventHandler(this.btnEsitaTutto_Click);
			// 
			// btnEsitoInserisci
			// 
			this.btnEsitoInserisci.Location = new System.Drawing.Point(8, 48);
			this.btnEsitoInserisci.Name = "btnEsitoInserisci";
			this.btnEsitoInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnEsitoInserisci.TabIndex = 29;
			this.btnEsitoInserisci.Tag = "insert.proceeds";
			this.btnEsitoInserisci.Text = "Inserisci...";
			// 
			// btnEsitoModifica
			// 
			this.btnEsitoModifica.Location = new System.Drawing.Point(8, 80);
			this.btnEsitoModifica.Name = "btnEsitoModifica";
			this.btnEsitoModifica.Size = new System.Drawing.Size(69, 22);
			this.btnEsitoModifica.TabIndex = 30;
			this.btnEsitoModifica.Tag = "edit.proceeds";
			this.btnEsitoModifica.Text = "Modifica...";
			// 
			// btnEsitoElimina
			// 
			this.btnEsitoElimina.Location = new System.Drawing.Point(8, 112);
			this.btnEsitoElimina.Name = "btnEsitoElimina";
			this.btnEsitoElimina.Size = new System.Drawing.Size(68, 22);
			this.btnEsitoElimina.TabIndex = 31;
			this.btnEsitoElimina.Tag = "delete";
			this.btnEsitoElimina.Text = "Elimina";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(232, 16);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 16);
			this.label10.TabIndex = 34;
			this.label10.Text = "Rimasto da esitare:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDaEsitare
			// 
			this.txtDaEsitare.Location = new System.Drawing.Point(360, 16);
			this.txtDaEsitare.Name = "txtDaEsitare";
			this.txtDaEsitare.ReadOnly = true;
			this.txtDaEsitare.Size = new System.Drawing.Size(112, 20);
			this.txtDaEsitare.TabIndex = 35;
			this.txtDaEsitare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtEsitato
			// 
			this.txtEsitato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEsitato.Location = new System.Drawing.Point(790, 16);
			this.txtEsitato.Name = "txtEsitato";
			this.txtEsitato.ReadOnly = true;
			this.txtEsitato.Size = new System.Drawing.Size(112, 20);
			this.txtEsitato.TabIndex = 33;
			this.txtEsitato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(686, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 32;
			this.label6.Text = "Totale esitato";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(88, 48);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(814, 189);
			this.dataGrid2.TabIndex = 36;
			this.dataGrid2.Tag = "banktransaction.proceeds.proceeds";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(13, 184);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(900, 2);
			this.panel1.TabIndex = 40;
			// 
			// dataGrid3
			// 
			this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(8, 24);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(910, 160);
			this.dataGrid3.TabIndex = 39;
			this.dataGrid3.Tag = "proceeds_bankview.default";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 8);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(656, 16);
			this.label11.TabIndex = 37;
			this.label11.Text = "Dettaglio dei movimenti bancari associati alla reversale";
			// 
			// tabAttributi
			// 
			this.tabAttributi.Controls.Add(this.gboxclass05);
			this.tabAttributi.Controls.Add(this.gboxclass04);
			this.tabAttributi.Controls.Add(this.gboxclass03);
			this.tabAttributi.Controls.Add(this.gboxclass02);
			this.tabAttributi.Controls.Add(this.gboxclass01);
			this.tabAttributi.Location = new System.Drawing.Point(4, 22);
			this.tabAttributi.Name = "tabAttributi";
			this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
			this.tabAttributi.Size = new System.Drawing.Size(926, 443);
			this.tabAttributi.TabIndex = 2;
			this.tabAttributi.Text = "Attributi";
			this.tabAttributi.UseVisualStyleBackColor = true;
			// 
			// gboxclass05
			// 
			this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass05.Controls.Add(this.txtCodice05);
			this.gboxclass05.Controls.Add(this.btnCodice05);
			this.gboxclass05.Controls.Add(this.txtDenom05);
			this.gboxclass05.Location = new System.Drawing.Point(6, 286);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(465, 64);
			this.gboxclass05.TabIndex = 10;
			this.gboxclass05.TabStop = false;
			this.gboxclass05.Tag = "";
			this.gboxclass05.Text = "Classificazione 5";
			// 
			// txtCodice05
			// 
			this.txtCodice05.Location = new System.Drawing.Point(9, 38);
			this.txtCodice05.Name = "txtCodice05";
			this.txtCodice05.Size = new System.Drawing.Size(219, 20);
			this.txtCodice05.TabIndex = 6;
			// 
			// btnCodice05
			// 
			this.btnCodice05.Location = new System.Drawing.Point(8, 16);
			this.btnCodice05.Name = "btnCodice05";
			this.btnCodice05.Size = new System.Drawing.Size(88, 23);
			this.btnCodice05.TabIndex = 4;
			this.btnCodice05.Tag = "manage.sorting05.tree";
			this.btnCodice05.Text = "Codice";
			this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom05
			// 
			this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom05.Location = new System.Drawing.Point(234, 8);
			this.txtDenom05.Multiline = true;
			this.txtDenom05.Name = "txtDenom05";
			this.txtDenom05.ReadOnly = true;
			this.txtDenom05.Size = new System.Drawing.Size(223, 52);
			this.txtDenom05.TabIndex = 3;
			this.txtDenom05.TabStop = false;
			this.txtDenom05.Tag = "sorting05.description";
			// 
			// gboxclass04
			// 
			this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass04.Controls.Add(this.txtCodice04);
			this.gboxclass04.Controls.Add(this.btnCodice04);
			this.gboxclass04.Controls.Add(this.txtDenom04);
			this.gboxclass04.Location = new System.Drawing.Point(6, 216);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(465, 64);
			this.gboxclass04.TabIndex = 9;
			this.gboxclass04.TabStop = false;
			this.gboxclass04.Tag = "";
			this.gboxclass04.Text = "Classificazione 4";
			// 
			// txtCodice04
			// 
			this.txtCodice04.Location = new System.Drawing.Point(9, 38);
			this.txtCodice04.Name = "txtCodice04";
			this.txtCodice04.Size = new System.Drawing.Size(219, 20);
			this.txtCodice04.TabIndex = 6;
			// 
			// btnCodice04
			// 
			this.btnCodice04.Location = new System.Drawing.Point(8, 16);
			this.btnCodice04.Name = "btnCodice04";
			this.btnCodice04.Size = new System.Drawing.Size(88, 23);
			this.btnCodice04.TabIndex = 4;
			this.btnCodice04.Tag = "manage.sorting04.tree";
			this.btnCodice04.Text = "Codice";
			this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom04
			// 
			this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom04.Location = new System.Drawing.Point(234, 12);
			this.txtDenom04.Multiline = true;
			this.txtDenom04.Name = "txtDenom04";
			this.txtDenom04.ReadOnly = true;
			this.txtDenom04.Size = new System.Drawing.Size(223, 46);
			this.txtDenom04.TabIndex = 3;
			this.txtDenom04.TabStop = false;
			this.txtDenom04.Tag = "sorting04.description";
			// 
			// gboxclass03
			// 
			this.gboxclass03.Controls.Add(this.txtCodice03);
			this.gboxclass03.Controls.Add(this.btnCodice03);
			this.gboxclass03.Controls.Add(this.txtDenom03);
			this.gboxclass03.Location = new System.Drawing.Point(6, 146);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(465, 64);
			this.gboxclass03.TabIndex = 8;
			this.gboxclass03.TabStop = false;
			this.gboxclass03.Tag = "";
			this.gboxclass03.Text = "Classificazione 3";
			// 
			// txtCodice03
			// 
			this.txtCodice03.Location = new System.Drawing.Point(8, 38);
			this.txtCodice03.Name = "txtCodice03";
			this.txtCodice03.Size = new System.Drawing.Size(219, 20);
			this.txtCodice03.TabIndex = 6;
			// 
			// btnCodice03
			// 
			this.btnCodice03.Location = new System.Drawing.Point(8, 16);
			this.btnCodice03.Name = "btnCodice03";
			this.btnCodice03.Size = new System.Drawing.Size(88, 23);
			this.btnCodice03.TabIndex = 4;
			this.btnCodice03.Tag = "manage.sorting03.tree";
			this.btnCodice03.Text = "Codice";
			this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom03
			// 
			this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom03.Location = new System.Drawing.Point(233, 8);
			this.txtDenom03.Multiline = true;
			this.txtDenom03.Name = "txtDenom03";
			this.txtDenom03.ReadOnly = true;
			this.txtDenom03.Size = new System.Drawing.Size(224, 52);
			this.txtDenom03.TabIndex = 3;
			this.txtDenom03.TabStop = false;
			this.txtDenom03.Tag = "sorting03.description";
			// 
			// gboxclass02
			// 
			this.gboxclass02.Controls.Add(this.txtCodice02);
			this.gboxclass02.Controls.Add(this.btnCodice02);
			this.gboxclass02.Controls.Add(this.txtDenom02);
			this.gboxclass02.Location = new System.Drawing.Point(6, 76);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(465, 64);
			this.gboxclass02.TabIndex = 7;
			this.gboxclass02.TabStop = false;
			this.gboxclass02.Tag = "";
			this.gboxclass02.Text = "Classificazione 2";
			// 
			// txtCodice02
			// 
			this.txtCodice02.Location = new System.Drawing.Point(8, 38);
			this.txtCodice02.Name = "txtCodice02";
			this.txtCodice02.Size = new System.Drawing.Size(219, 20);
			this.txtCodice02.TabIndex = 6;
			// 
			// btnCodice02
			// 
			this.btnCodice02.Location = new System.Drawing.Point(8, 16);
			this.btnCodice02.Name = "btnCodice02";
			this.btnCodice02.Size = new System.Drawing.Size(88, 23);
			this.btnCodice02.TabIndex = 4;
			this.btnCodice02.Tag = "manage.sorting02.tree";
			this.btnCodice02.Text = "Codice";
			this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom02
			// 
			this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom02.Location = new System.Drawing.Point(233, 8);
			this.txtDenom02.Multiline = true;
			this.txtDenom02.Name = "txtDenom02";
			this.txtDenom02.ReadOnly = true;
			this.txtDenom02.Size = new System.Drawing.Size(224, 52);
			this.txtDenom02.TabIndex = 3;
			this.txtDenom02.TabStop = false;
			this.txtDenom02.Tag = "sorting02.description";
			// 
			// gboxclass01
			// 
			this.gboxclass01.Controls.Add(this.txtCodice01);
			this.gboxclass01.Controls.Add(this.btnCodice01);
			this.gboxclass01.Controls.Add(this.txtDenom01);
			this.gboxclass01.Location = new System.Drawing.Point(6, 6);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(465, 64);
			this.gboxclass01.TabIndex = 6;
			this.gboxclass01.TabStop = false;
			this.gboxclass01.Tag = "";
			this.gboxclass01.Text = "Classificazione 1";
			// 
			// txtCodice01
			// 
			this.txtCodice01.Location = new System.Drawing.Point(7, 40);
			this.txtCodice01.Name = "txtCodice01";
			this.txtCodice01.Size = new System.Drawing.Size(220, 20);
			this.txtCodice01.TabIndex = 5;
			// 
			// btnCodice01
			// 
			this.btnCodice01.Location = new System.Drawing.Point(8, 16);
			this.btnCodice01.Name = "btnCodice01";
			this.btnCodice01.Size = new System.Drawing.Size(88, 23);
			this.btnCodice01.TabIndex = 4;
			this.btnCodice01.Tag = "manage.sorting01.tree";
			this.btnCodice01.Text = "Codice";
			this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom01
			// 
			this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom01.Location = new System.Drawing.Point(233, 8);
			this.txtDenom01.Multiline = true;
			this.txtDenom01.Name = "txtDenom01";
			this.txtDenom01.ReadOnly = true;
			this.txtDenom01.Size = new System.Drawing.Size(224, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(130, 80);
			this.dataGrid1.TabIndex = 0;
			// 
			// gboxtipo
			// 
			this.gboxtipo.Controls.Add(this.chkMisto);
			this.gboxtipo.Controls.Add(this.chkResidui);
			this.gboxtipo.Controls.Add(this.chkCompetenza);
			this.gboxtipo.Location = new System.Drawing.Point(339, 3);
			this.gboxtipo.Name = "gboxtipo";
			this.gboxtipo.Size = new System.Drawing.Size(265, 47);
			this.gboxtipo.TabIndex = 96;
			this.gboxtipo.TabStop = false;
			this.gboxtipo.Text = "Tipo";
			// 
			// chkMisto
			// 
			this.chkMisto.AutoSize = true;
			this.chkMisto.Location = new System.Drawing.Point(189, 14);
			this.chkMisto.Name = "chkMisto";
			this.chkMisto.Size = new System.Drawing.Size(63, 17);
			this.chkMisto.TabIndex = 6;
			this.chkMisto.Tag = "proceeds.flag:2?proceedsview.flag:2";
			this.chkMisto.Text = "C/Misto";
			this.chkMisto.UseVisualStyleBackColor = true;
			this.chkMisto.CheckStateChanged += new System.EventHandler(this.chkMisto_CheckStateChanged);
			// 
			// chkResidui
			// 
			this.chkResidui.AutoSize = true;
			this.chkResidui.Location = new System.Drawing.Point(112, 14);
			this.chkResidui.Name = "chkResidui";
			this.chkResidui.Size = new System.Drawing.Size(73, 17);
			this.chkResidui.TabIndex = 5;
			this.chkResidui.Tag = "proceeds.flag:1?proceedsview.flag:1";
			this.chkResidui.Text = "C/Residui";
			this.chkResidui.UseVisualStyleBackColor = true;
			this.chkResidui.CheckStateChanged += new System.EventHandler(this.chkResidui_CheckStateChanged);
			// 
			// chkCompetenza
			// 
			this.chkCompetenza.AutoSize = true;
			this.chkCompetenza.Location = new System.Drawing.Point(9, 14);
			this.chkCompetenza.Name = "chkCompetenza";
			this.chkCompetenza.Size = new System.Drawing.Size(97, 17);
			this.chkCompetenza.TabIndex = 4;
			this.chkCompetenza.Tag = "proceeds.flag:0?proceedsview.flag:0";
			this.chkCompetenza.Text = "C/Competenza";
			this.chkCompetenza.UseVisualStyleBackColor = true;
			this.chkCompetenza.CheckStateChanged += new System.EventHandler(this.chkCompetenza_CheckStateChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(749, 67);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(108, 32);
			this.label7.TabIndex = 99;
			this.label7.Text = "Numero Progr. Cassiere:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNPro_Treasurer
			// 
			this.txtNPro_Treasurer.Location = new System.Drawing.Point(863, 76);
			this.txtNPro_Treasurer.Name = "txtNPro_Treasurer";
			this.txtNPro_Treasurer.Size = new System.Drawing.Size(72, 20);
			this.txtNPro_Treasurer.TabIndex = 98;
			this.txtNPro_Treasurer.TabStop = false;
			this.txtNPro_Treasurer.Tag = "proceeds.npro_treasurer";
			// 
			// Frm_proceeds_reversalemultipla
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(944, 578);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtNPro_Treasurer);
			this.Controls.Add(this.gboxtipo);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpConto);
			this.Controls.Add(this.groupBox4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Frm_proceeds_reversalemultipla";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmdocumentoincasso_multiplo";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgrRigheReversale)).EndInit();
			this.gboxMovimenti.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.grpConto.ResumeLayout(false);
			this.grpBilancio.ResumeLayout(false);
			this.grpBilancio.PerformLayout();
			this.grpCredDeb.ResumeLayout(false);
			this.grpCredDeb.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPrincipale.ResumeLayout(false);
			this.tabPrincipale.PerformLayout();
			this.grpTrasmSiope.ResumeLayout(false);
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.tabBanca.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.tabAttributi.ResumeLayout(false);
			this.gboxclass05.ResumeLayout(false);
			this.gboxclass05.PerformLayout();
			this.gboxclass04.ResumeLayout(false);
			this.gboxclass04.PerformLayout();
			this.gboxclass03.ResumeLayout(false);
			this.gboxclass03.PerformLayout();
			this.gboxclass02.ResumeLayout(false);
			this.gboxclass02.PerformLayout();
			this.gboxclass01.ResumeLayout(false);
			this.gboxclass01.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.gboxtipo.ResumeLayout(false);
			this.gboxtipo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		void afterLinkBody(){
			DS.incomephase.CacheTable();
			DS.config.CacheTable(QHS.CmpEq("ayear",esercizio),null,false);
			DS.fin.setStaticFilter( QHS.AppAnd(QHS.CmpEq("ayear",esercizio), QHS.BitClear("flag",0)));
            DS.sortingkind.CacheTable();
            
            MetaData.SetDefault(DS.banktransaction, "kind", "C");
            DS.proceeds.setStaticFilter(QHS.CmpEq("ypro", esercizio));
            DS.incomelastview.setStaticFilter(QHS.CmpEq("ymov", esercizio));
            DataAccess.SetTableForReading(DS.income1, "income");
            HelpForm.SetDenyNull(DS.proceeds.Columns["idtreasurer"], true);

        }

        bool UsoSiope = false;
        private IDataAccess Conn;

        private IFormController controller;
        private ISecurity security;
        private IMetaModel model;
        //private IHelpForm helpForm;
        private IMetaDataDispatcher dispatcher;
        private IGetData getData;
        private int esercizio;

        public void MetaData_AfterLink(){

			Meta = MetaData.GetMetaData(this);
            Conn = this.getInstance<IDataAccess>();

            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            controller = this.getInstance<IFormController>();
            security = this.getInstance<ISecurity>();
            model = MetaFactory.factory.getSingleton<IMetaModel>();
            //helpForm = this.getInstance<IHelpForm>();
            dispatcher = this.getInstance<IMetaDataDispatcher>();
            //comboManager = this.getInstance<IComboBoxManager>();
            esercizio = security.GetEsercizio();
            getData = this.getInstance<IGetData>();

			afterLinkBody();

          
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            var tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
              null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                var r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }
            UsoSiope = verifica_Uso_SiopePlus();
            if (!UsoSiope) {
                grpTrasmSiope.Visible = false;
            }
        }

        //controlla che si debba usare la trasmissione Siope+ 
        public bool verifica_Uso_SiopePlus() {
            object usesiopeplus = Conn.DO_READ_VALUE("opisiopeplus_config", QHS.CmpEq("code", "opi_siopeplus"), "usesiopeplus", null);
            if (usesiopeplus == null || usesiopeplus == DBNull.Value) return false;
            if (usesiopeplus.ToString() == "S") return true;
            return false;
        }
        //object GetCtrlByName(string Name) {
        //    System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
        //    if (Ctrl == null) return null;
        //    //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
        //    //Label L =  (Label) Ctrl.GetValue(this);                        
        //    //return L;
        //    return Ctrl.GetValue(this);
        //}

        public void MetaData_BeforeActivation(){
			if (DS.config.Rows.Count==0) {
				Meta.CanSave=false;
				Meta.SearchEnabled=false;
				Meta.CanInsert=false;
				return;
			}
            getData.ReadCached();
			string bilanciofilter = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitClear("flag", 0));
			var Pers = DS.config.Rows[0];
			string maxfasebil = Conn.DO_READ_VALUE("finlevel", QHS.CmpEq("ayear",esercizio), "max(nlevel)").ToString();
            byte proceeds_flag = (byte)Pers["proceeds_flag"];
            if (((proceeds_flag & 2) == 2) &&
                (Pers["proceeds_finlevel"].ToString() != "") &&
				(Pers["proceeds_finlevel"].ToString()!= maxfasebil)) {
				grpBilancio.Tag="AutoManage.txtBilancio.treee"+Pers["proceeds_finlevel"]+
					".(nlevel<='"+Pers["proceeds_finlevel"].ToString()+"')";
				btnBilancio.Tag="manage.fin.treee"+Pers["proceeds_finlevel"].ToString();
				object descrfasebil = Conn.DO_READ_VALUE("finlevel", "(ayear='"+esercizio+"')AND"+
					"(nlevel='"+Pers["proceeds_finlevel"]+"')", "description");
				if (descrfasebil!=null)		grpBilancio.Text += " ("+descrfasebil+")";
			}
			else {
				grpBilancio.Tag="AutoManage.txtBilancio.treee";
				btnBilancio.Tag="manage.fin.treee";
			}
			DS.fin.setStaticFilter(bilanciofilter);					
		}


		public void MetaData_AfterActivation(){
			if (DS.config.Rows.Count==0) return;
			esaminaFlag();
            calcolaDefaultPerIstitutoCassiere();
            calcolaDefaultPerBollo();
            int flag = CfgFn.GetNoNullInt32(DS.proceeds.Columns["flag"].DefaultValue);
            if (!flagresidui) {
                flag &= 0xF8;
                flag += 4;

            }
            else {
                flag &= 0xF8;
                flag += 1;

            }
            flag &= 0xF7;
            flag |= 0x08;
            DS.proceeds.Columns["flag"].DefaultValue = flag;
		}

        void calcolaDefaultPerBollo(){
            DataRow[] bollo = DS.stamphandling.Select("flagdefault='S'");
            if (bollo.Length != 1) return;
            MetaData.SetDefault(DS.proceeds, "idstamphandling", bollo[0]["idstamphandling"]);
        }

		void calcolaDefaultPerIstitutoCassiere() {
			DataRow[] cassiere = DS.treasurer.Select("flagdefault='S'");
            if (cassiere.Length == 1) {
                MetaData.SetDefault(DS.proceeds, "idtreasurer", cassiere[0]["idtreasurer"]);
                return;
            }
            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                MetaData.SetDefault(DS.proceeds, "idtreasurer", codiceistituto);
            }
		}

	    private bool modalitaMultiRegForzato = false;

		public void MetaData_AfterClear() {
		    modalitaMultiRegForzato = false;
		    btnCollega.Visible = true;
		    btnModifica.Visible = true;
			if (DS.config.Rows.Count==0) return;
			esaminaFlag();
			txtEsercizioDocumento.Text=esercizio.ToString();
			btnCollega.Enabled=false;
			btnScollega.Enabled=false;
			btnModifica.Enabled=false;
			btnSituazione.Enabled=false;
            btnControllaFileOPI.Enabled = false;
            txtImporto.Text= "";
			gestisciBottoniEsito(false);
            DS.incomesorted.Clear();
			DS.incomelastestimatedetail.Clear();
            txtNumeroDocumento.ReadOnly = false;
            btnIstitutoCassiere.Enabled = true;
            cmbCodiceIstituto.Enabled = true;
		    gboxMovimenti.Enabled = true;
            txtNPro_Treasurer.ReadOnly = false;

//			if (Convert.ToInt16(Meta.GetSys("esercizio")) > 2001)
//				chbEuro.Visible=false;
		}

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (controller.IsEmpty) return;
            if (T.TableName == "treasurer" && R != null && 
                    (controller.DrawStateIsDone || (controller.InsertMode && controller.firstFillForThisRow)
                    )
                ) {
                var RInc = DS.proceeds.Rows[0];
                int flag = CfgFn.GetNoNullInt32(RInc["flag"]);

                if (R["flagfruitful"].ToString().ToUpper() == "F") {
                    rdbInfruttifero.Checked = false;
                    rdbFruttifero.Checked = true;
                    flag |= 8;
                }
                else {
                    rdbFruttifero.Checked = false;
                    rdbInfruttifero.Checked = true;
                    flag &= 0xF7;
                }
                RInc["flag"] = flag;
            }

            if (controller.DrawStateIsDone && controller.EditMode && T.TableName == "treasurer") {
                if (R == null) {
                    gboxMovimenti.Enabled = false;
                }
                else {
                    object currTr = R["idtreasurer"];
                    object oldTr = DS.proceeds.Rows[0]["idtreasurer", DataRowVersion.Original];
                    gboxMovimenti.Enabled = (currTr.ToString() == oldTr.ToString());
                }
            }
        }

		public void MetaData_AfterFill(){
			if (DS.config.Rows.Count==0) return;
		    if (DS.incomelastview.Rows.Count == 0) modalitaMultiRegForzato = false;
		    if (modalitaMultiRegForzato) {
		        btnCollega.Visible = false;
		        btnModifica.Visible = false;
		    }
		    else {
		        btnCollega.Visible = true;
		        btnModifica.Visible = true;
		    }
			bool ModoInsert = controller.InsertMode;
			string filter = null;
			gestisciBottoniEsito(!controller.InsertMode);
			var Curr = DS.proceeds.Rows[0];
            string filtraReversale = QHS.CmpKey(Curr);
			 // Determino i movimenti già esitati
			string listaid = null;
		
			foreach(DataRow rInc in DS.incomelastview.Rows) {
				decimal importoGiaEsitato = 0;
				foreach(var rBTans in DS.banktransaction.Select(QHC.CmpEq("idinc", rInc["idinc"]))) {
						importoGiaEsitato+=CfgFn.GetNoNullDecimal(rBTans["amount"]);				
				}
                if (importoGiaEsitato >= CfgFn.GetNoNullDecimal(rInc["curramount"])) {
                    listaid += QHS.quote(rInc["idinc"]) + ",";
                }
			}
			if (listaid != null) {
				listaid = listaid.Substring(0,listaid.Length -1);
				if (listaid.Length >0) {
					filter = QHS.FieldNotInList("idinc",listaid);
				}
				else {
					filter = null;
				}
			}
			filter = GetData.MergeFilters(filtraReversale,filter);
            model.setExtraParams(DS.banktransaction, filter);
			//DS.banktransaction.ExtendedProperties[MetaData.ExtraParams] = filter;
			
			esaminaFlag();//reimposta il form in base ai flag
			btnIstitutoCassiere.Enabled=true;
			calcolaImporto();
			btnCollega.Enabled=true;
			btnScollega.Enabled=true;
			btnModifica.Enabled=true;
			btnSituazione.Enabled=!ModoInsert;
            btnControllaFileOPI.Enabled = !ModoInsert;
            var CurrDoc = DS.proceeds.Rows[0];
			//DataSet MyDS = (DataSet)dgrRigheReversale.DataSource;
			//DataTable MyTable = MyDS.Tables[dgrRigheReversale.DataMember.ToString()];
			DataTable MyTable = DS.incomelastview;

			if  (MyTable.Rows.Count > 0) {
				gboxtipo.Enabled=false;
				txtCreditoreDebitore.ReadOnly=true;
                txtResponsabile.Enabled = false;
				txtBilancio.ReadOnly=true;
				btnBilancio.Enabled=false;
			}
			impostaTipoDocumento();

            if (ModoInsert)
            {
                DS.proceeds_bankview.Clear();
            }
            if (controller.EditMode)
            {
                txtNumeroDocumento.ReadOnly = true;
                if (DS.incomelastview.Rows.Count == 0) {
                    btnIstitutoCassiere.Enabled = true;
                    cmbCodiceIstituto.Enabled = true;
                }
                else {
                    btnIstitutoCassiere.Enabled = false;
                    cmbCodiceIstituto.Enabled = false;
                }

                object currTr = CurrDoc["idtreasurer", DataRowVersion.Current];
                object oldTr = CurrDoc["idtreasurer", DataRowVersion.Original];
                gboxMovimenti.Enabled = (currTr.ToString() == oldTr.ToString());
            }

            if (controller.IsEmpty) txtNPro_Treasurer.ReadOnly = false; else txtNPro_Treasurer.ReadOnly = true;
		}
		
		private void impostaTipoDocumento() {
			foreach(var rTransazione in DS.banktransaction.Select(null,null,DataViewRowState.Added)) {
				rTransazione["kind"] = "C";
			}
		}

        private void calcolaImporto(){
			var MyDS = (DataSet)dgrRigheReversale.DataSource;
			var MyTable = MyDS.Tables[dgrRigheReversale.DataMember.ToString()];
            var importo = MetaData.SumColumn(MyTable, "curramount");
            txtImporto.Text=importo.ToString("C");
            var esitato = MetaData.SumColumn(DS.banktransaction, "amount");
            decimal nonesitato=importo-esitato;
			txtEsitato.Text= esitato.ToString("c");
			txtDaEsitare.Text= nonesitato.ToString("c");
			MetaData.SetDefault(DS.banktransaction,"amount",nonesitato);
		}


		private void esaminaFlag(){
			if (DS.config.Rows.Count==0) return;
            byte proceeds_flag = (byte)DS.Tables["config"].Rows[0]["proceeds_flag"];
            flagcreddeb = (proceeds_flag & 4) == 4;
            flagbilancio = (proceeds_flag & 2) == 2;
            flagrespons = (proceeds_flag & 16) == 16;
            flagresidui = (proceeds_flag & 8) == 8;
			txtCreditoreDebitore.ReadOnly = modalitaMultiRegForzato | !flagcreddeb;
			txtBilancio.ReadOnly    = !flagbilancio;
			btnBilancio.Enabled     = flagbilancio;
            txtResponsabile.Enabled = flagrespons;
			gboxtipo.Enabled        = flagresidui;
            if (flagresidui) chkMisto.Enabled = false;
			//if (flagresidui!="S") rdbMisto.Checked=true;			
		}

		string calculateFilterForLinking(bool SQL){
            var qh = SQL ? QHS : QHC;
            var codicefase = CfgFn.GetNoNullInt32(security.GetSys("maxincomephase"));
			//int giornianticipo = CfgFn.GetNoNullInt32(DS.Tables["config"].Rows[0]["income_expiringdays"]);
           
			object codicecreddeb = DS.proceeds.Rows[0]["idreg"];
            object idbilancio = DS.proceeds.Rows[0]["idfin"];
            object codiceresponsabile = DS.proceeds.Rows[0]["idman"];

			//if (codicecreddeb==DBNull.Value.ToString()||idbilancio==DBNull.Value.ToString()||codiceresponsabile==DBNull.Value.ToString()) return;
			
			int eserccorrente=esercizio;
            //string esercsuffix=eserccorrente.Substring(2,2);

            var MyFilter = qh.AppAnd(qh.CmpEq("nphase", codicefase), qh.IsNull("kpro"), qh.CmpEq("ayear", eserccorrente));
            if (flagcreddeb){
                MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idreg", codicecreddeb));
            }
			if (flagbilancio){
                if (idbilancio == DBNull.Value) {
                    MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idfin"));
                }
                else {
                    var FinLink = Conn.RUN_SELECT("finlink", "idchild", null, QHS.CmpEq("idparent", idbilancio), null, true);
                    string lista = qh.DistinctVal(FinLink.Select(), "idchild");
                    MyFilter = qh.AppAnd(MyFilter, qh.FieldInList("idfin", lista));

                    //MyFilter = qh.AppAnd(MyFilter, qh.FieldInList("idfin", " select idchild from finlink where "
                    //            + qh.CmpEq("idparent", idbilancio)));
                }
			}
			if (flagrespons){
                MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idman", codiceresponsabile));
            }

			//DateTime scadenza = (DateTime) Meta.GetSys("datacontabile");
			//scadenza = scadenza.AddDays( giornianticipo);
            //MyFilter = qh.AppAnd(MyFilter, qh.NullOrLe("expiration", scadenza));


            if (flagresidui) {
                if (chkCompetenza.Checked) {
                    MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("flagarrear", "C"));
                }
                if (chkResidui.Checked) {
                    MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("flagarrear", "R"));
                }
            }			
			return MyFilter;
		}
		private void btnCollega_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count==0) return;

			if (controller.IsEmpty) return;
			MetaData.GetFormData(this,true);
			string MyFilter = calculateFilterForLinking(true);
			string command = "choose.incomelastview.documentocollegato." + MyFilter;
			MetaData.Choose(this,command);
			calcolaImporto();
            if (UsoSiope) {
                Dictionary<int, DataRow> admitted;
                string res = pp.Meta_proceeds.SimulaGenerazioneOrdinativo(Conn as DataAccess, DS.incomelastview, out  admitted);
                if (res!=null)MetaFactory.factory.getSingleton<IMessageShower>().Show(res, "Informazione");
                
            }
        }

		private void btnModifica_Click(object sender, EventArgs e) {
			if (DS.config.Rows.Count==0) return;

			if (controller.IsEmpty) return;
            controller.GetFormData(true);
			string MyFilter = calculateFilterForLinking(false);
			string MyFilterSQL = calculateFilterForLinking(true);
			Meta.MultipleLinkUnlinkRows("Composizione documento",
				"Movimenti inclusi nel documento selezionato", 
				"Movimenti non inclusi in alcun documento",
				DS.incomelastview, MyFilter, MyFilterSQL, "documentocollegato");
			clearWhenNoRowsSelected();
			calcolaImporto();
            if (UsoSiope) {
                Dictionary<int, DataRow> admitted;
                string res = pp.Meta_proceeds.SimulaGenerazioneOrdinativo(Conn as DataAccess, DS.incomelastview, out  admitted);
                if (res!=null)MetaFactory.factory.getSingleton<IMessageShower>().Show(res, "Informazione");
            }
        }

		private void btnScollega_Click(object sender, EventArgs e) {
			if (DS.config.Rows.Count==0) return;

			if (controller.IsEmpty) return; 
			controller.GetFormData(true);
			MetaData.Unlink_Grid(dgrRigheReversale);
			clearWhenNoRowsSelected();
			calcolaImporto();
            if (UsoSiope) {
                Dictionary<int, DataRow> admitted;
                string res = pp.Meta_proceeds.SimulaGenerazioneOrdinativo(Conn as DataAccess, DS.incomelastview, out  admitted);
                if (res!=null)MetaFactory.factory.getSingleton<IMessageShower>().Show(res, "Informazione");
            }
        }

		void clearWhenNoRowsSelected(){
			return;
		}

        // Il bottone collegato a questo evento è not visibile! Bisogna creare la SP (se si vuole usare)
		private void btnSituazione_Click_1(object sender, System.EventArgs e) {
			string esercdocumento;
			string numdocumento;
			try {
				var MyRow=HelpForm.GetLastSelected(DS.proceeds);
				esercdocumento=MyRow["ypro"].ToString();
				numdocumento=MyRow["npro"].ToString();
			}
			catch {
				return;
			}
			var Out = Conn.CallSP("sp_sit_docincasso",
				new object[3] {security.GetDataContabile(), esercdocumento, numdocumento}
				);
			if (Out==null) return;
			Out.Tables[0].TableName= "Situazione documento";
            frmSituazioneViewer View = new frmSituazioneViewer(Out);
            createForm(View, null);
            View.Show();		
		}


		void eliminaVariazioniDiAnnullo()   {
			if (DS.config.Rows.Count==0) return;
			if (DS.incomelastview.Rows.Count==0) return;
			string filter = QHS.AppAnd(QHS.CmpEq("autokind",11), QHS.FieldIn("idinc",DS.incomelastview.Select(), "idinc"));
			Conn.RUN_SELECT_INTO_TABLE(DS.incomevar, null, filter, null, true);
			DataRow []RowsToDel = DS.incomevar.Select(filter);
			foreach (DataRow ToDel in RowsToDel){
				ToDel.Delete();
			}

		}

		void aggiungiVariazioniDiAnnullo(DateTime DataAnnullo) {
			if (DS.config.Rows.Count == 0) return;
			if (DS.incomelastview.Rows.Count == 0) return;
			string filter = QHS.AppAnd(QHS.AppAnd(QHS.CmpEq("autokind", 11), QHS.CmpEq("yvar", esercizio)),
				QHS.FieldIn("idinc", DS.incomelastview.Select(), "idinc"));
			var MetaVar = MetaData.GetMetaData(this, "incomevar");
			MetaVar.SetDefaults(DS.incomevar);
			MetaData.SetDefault(DS.incomevar, "adate", DataAnnullo);
			MetaData.SetDefault(DS.incomevar, "autokind", 11);

			DS.incomesorted.Clear();
			DS.incomelastestimatedetail.Clear();

			Conn.RUN_SELECT_INTO_TABLE(DS.incomevar, null, filter, null, true);
			DataRow Curr = DS.proceeds.Rows[0];
			string descrvar = "Annullamento della reversale di incasso " + Curr["ypro"] + "/" +
			                  Curr["npro"];
			foreach (DataRow EntrataToAdd in DS.incomelastview.Select()) {
				string filteridentrata = QHC.AppAnd(
					QHC.CmpEq("idinc", EntrataToAdd["idinc"]),
					QHC.CmpEq("autokind", 11));
				string filterclass = QHC.CmpEq("idinc", EntrataToAdd["idinc"]);
				DataRow[] VarAnnullo = DS.incomevar.Select(filteridentrata, null);
				if (VarAnnullo.Length == 0) {
					MetaData.SetDefault(DS.incomevar, "idinc", EntrataToAdd["idinc"]);
					var NewVarAnnullo = MetaVar.Get_New_Row(null, DS.incomevar);
					decimal impcorr = CfgFn.GetNoNullDecimal(EntrataToAdd["curramount"]);
					NewVarAnnullo["amount"] = -impcorr;
					NewVarAnnullo["description"] = descrvar;

				}
				else {
					var ExistVarAnnullo = VarAnnullo[0];
					decimal currvar = CfgFn.GetNoNullDecimal(ExistVarAnnullo["amount"]);
					decimal impcorr = CfgFn.GetNoNullDecimal(EntrataToAdd["curramount"]);
					if (impcorr != 0) {
						ExistVarAnnullo["amount"] = currvar - impcorr;
						ExistVarAnnullo["adate"] = DataAnnullo;
						//ExistVarAnnullo["descrizione"]= descrvar;
					}
				}

				Conn.RUN_SELECT_INTO_TABLE(DS.incomesorted, null, filterclass, null, true);
				Conn.RUN_SELECT_INTO_TABLE(DS.incomelastestimatedetail, null, filterclass, null, true);
			}

			foreach (DataRow R in DS.incomesorted.Select()) {
				R["amount"] = 0;
			}
			foreach (DataRow R in DS.incomelastestimatedetail.Select()) {
				R["originalamount"] = R["amount"];
				R["amount"] = 0;
			}

		}

		public void MetaData_BeforePost(){
			if (DS.config.Rows.Count==0) return;
			if (controller.IsEmpty)return;
			if (DS.proceeds.Rows.Count==0) return;//provengo da insert/cancel
			var Curr = DS.proceeds.Rows[0];

			if (Curr.RowState== DataRowState.Deleted){
				eliminaVariazioniDiAnnullo();
			}
			else {
				if (Curr["annulmentdate"]==DBNull.Value){
					eliminaVariazioniDiAnnullo();
				}
				else {
					aggiungiVariazioniDiAnnullo((DateTime)Curr["annulmentdate"]);
				}
			}
			azzeraMovBancarioInEntrata();
		}

		private void azzeraMovBancarioInEntrata() {
			if (DS.proceeds.Rows.Count == 0) return;
            string filtro = QHC.AppAnd(QHC.IsNull("kpro"), QHC.IsNotNull("idpro"));
			foreach(var R in DS.incomelastview.Select(filtro)) {
				R["idpro"] = DBNull.Value;
			}
		}

		public void MetaData_AfterPost() {
			if (DS.proceeds.Rows.Count == 0) return;
			fillProceedsBank();
			DS.proceeds_bankview.Clear();
            DS.incomesorted.Clear();
			DS.incomelastestimatedetail.Clear();
			var Curr = DS.proceeds.Rows[0];
            string filter = QHS.CmpKey(Curr);
			Conn.RUN_SELECT_INTO_TABLE( DS.proceeds_bankview, "idpro", filter, null, false);
		}

		private void gestisciBottoniEsito(bool abilita) {
			btnEsitoElimina.Enabled = abilita;
			btnEsitoInserisci.Enabled = abilita;
			btnEsitoModifica.Enabled = abilita;
		}

		private void fillProceedsBank() {
			var Curr = DS.proceeds.Rows[0];
			var Out = Conn.CallSP("compute_proceeds_bank", new object[] {Curr["kpro"]}, false, 0);
		}

		private void btnEsitaTutto_Click(object sender, System.EventArgs e) {
			if (DS.proceeds.Rows.Count == 0) return;
			decimal esitato= MetaData.SumColumn(DS.banktransaction,"amount");
			decimal totaleReversale = MetaData.SumColumn(DS.incomelastview,"amount");
			if (esitato == totaleReversale) return;
			// Richiama la finestra per le informazioni
			int lenBankReference = (int) Conn.DO_READ_VALUE("columntypes",
                 QHS.AppAnd(QHS.CmpEq("tablename", "banktransaction"), QHS.CmpEq("field", "bankreference")), 
                 "col_len");
			var F = new frmAskInfo(lenBankReference);
            createForm(F, this);
            if (F.ShowDialog(this)!=DialogResult.OK) return;
			object dataOperazione = F.dataOperazione;
			object dataValuta = F.dataValuta;
			object rifBanca = F.rifBanca;
			if (dataOperazione==null) return;
			
			var Curr = DS.proceeds.Rows[0];
            controller.GetFormData(false);
			// Ciclo per creare le esitazioni nel dataset
			var metaBT = MetaData.GetMetaData(this, "banktransaction");
			metaBT.SetDefaults(DS.banktransaction);
			
			foreach(DataRow rInc in DS.incomelastview.Rows) {
				decimal importoCorrente = CfgFn.GetNoNullDecimal(rInc["curramount"]);
				decimal importoGiaEsitato = 0;
				decimal importoDaEsitare=0;
                foreach (DataRow rBTans in DS.banktransaction.Select(QHC.CmpEq("idinc", rInc["idinc"]))) {
						importoGiaEsitato+=CfgFn.GetNoNullDecimal(rBTans["amount"]);
                }
				if (importoGiaEsitato == importoCorrente) {
					continue;
				}
				else {
					// Creo la nuova esitazione
					importoDaEsitare = importoCorrente - importoGiaEsitato;
					var rBT = metaBT.Get_New_Row(null,DS.banktransaction); 
					rBT["amount"] = importoDaEsitare;
					rBT["kpro"]   = Curr["kpro"];
					rBT["idpro"]  = rInc["idpro"];
					rBT["bankreference"] = rifBanca;
					rBT["kind"] = "C";
					rBT["idinc"] = rInc["idinc"];
					rBT["transactiondate"] = dataOperazione;
					rBT["valuedate"] = dataValuta;
				}
			}
			Meta.FreshForm();
		}

        private void chkCompetenza_CheckStateChanged (object sender, EventArgs e) {
            bool isChecked = (chkCompetenza.CheckState==CheckState.Checked);
            if (isChecked) {
                chkResidui.Checked = !isChecked;
                chkMisto.Checked = !isChecked;
            }
        }

        private void chkResidui_CheckStateChanged (object sender, EventArgs e) {
            bool isChecked = (chkResidui.CheckState == CheckState.Checked);
            if (isChecked) {
                chkCompetenza.Checked = !isChecked;
                chkMisto.Checked = !isChecked;
            }
        }

        private void chkMisto_CheckStateChanged (object sender, EventArgs e) {
            bool isChecked = (chkMisto.CheckState == CheckState.Checked);
            if (isChecked) {
                chkResidui.Checked = !isChecked;
                chkCompetenza.Checked = !isChecked;
            }
        }

        private void btnFlussoCrediti_Click(object sender, EventArgs e) {
            if (controller.IsEmpty)return;
            btnFlussoCrediti.Visible = false;
            controller.GetFormData(true);

            var f = new frmFlussoCrediti(Conn as DataAccess,dispatcher as MetaDataDispatcher);
            if (f.errore) {
                btnFlussoCrediti.Visible = true;
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore leggendo gli incassi da includere", "Avviso");
                return;
            }

            createForm(f, this);
            if (f.ShowDialog(this) != DialogResult.OK) {
                btnFlussoCrediti.Visible = true;
                return;
            }
         
            DataRow curr = DS.proceeds.Rows[0];

            var ex = new Dictionary<int, DataRow>();
            foreach (DataRow rEx in DS.incomelastview.Rows) {
                if (rEx.RowState == DataRowState.Deleted) {
                    ex[CfgFn.GetNoNullInt32(rEx["idinc", DataRowVersion.Original])] = rEx;
                    continue;
                }
                ex[CfgFn.GetNoNullInt32(rEx["idinc"])] = rEx;
            }

            var selectedRows = f.getSelectedRows();

            var selectedIdInc = (from DataRow r in selectedRows select CfgFn.GetNoNullInt32(r["idinc"])).ToArray();
            var MyDS = (DataSet)f.grid.DataSource;
            var MyTable = MyDS.Tables[f.grid.DataMember.ToString()];
            var selectedIdIncDic = new Dictionary<int, bool>();
            foreach (var idx in selectedIdInc) selectedIdIncDic[idx] = true;

            for (int i = 0; i < MyTable.Rows.Count; i++) {

                var rGrid = MyTable.Rows[i];
                int idinc = CfgFn.GetNoNullInt32(rGrid["idinc"]);

                if (!selectedIdIncDic.ContainsKey(idinc)) {
                    if (ex.ContainsKey(idinc)) {
                        //toglie la riga dal ds
                        var r = ex[idinc];
                        if (r.RowState!=DataRowState.Deleted) r.Delete();
                        r.AcceptChanges();//r is now detached
                        ex.Remove(idinc);
                    }

                    continue;
                }

                if (ex.ContainsKey(idinc)) {
                    DataRow rEx = ex[idinc];
                    if (rEx.RowState == DataRowState.Deleted) {
                        rEx.RejectChanges();
                        continue;
                    }
                    rEx["kpro"] = curr["kpro"];
                    continue;
                }

                var rNew = DS.incomelastview.NewRow();
                foreach (DataColumn cc in DS.incomelastview.Columns) {
                    if (!rGrid.Table.Columns.Contains(cc.ColumnName))continue;
                    rNew[cc.ColumnName] = rGrid[cc.ColumnName];
                }
                DS.incomelastview.Rows.Add(rNew);
                model.MarkTableAsNotEntityChild(DS.proceeds, DS.incomelastview);
                rNew.AcceptChanges();
                rNew["kpro"] = curr["kpro"];
                ex[idinc] = rNew;//probabilmente superfluo
                modalitaMultiRegForzato = true;
            }
            Meta.FreshForm(true);

            if (UsoSiope) {
                Dictionary<int, DataRow> admitted;
                string res = pp.Meta_proceeds.SimulaGenerazioneOrdinativo(Conn as DataAccess, DS.incomelastview, out  admitted);
                if (res!=null)MetaFactory.factory.getSingleton<IMessageShower>().Show(res, "Informazione");
            }

            btnFlussoCrediti.Visible = true;
        }

        private void btnGeneraFilePagamenti_Click(object sender, EventArgs e) {

        }

        private void btnGeneraFileOPI_Click(object sender, EventArgs e) {

        }

        private void btnControllaFileOPI_Click(object sender, EventArgs e) {
            Dictionary<int, DataRow> admitted;
            var res = pp.Meta_proceeds.SimulaGenerazioneOrdinativo(Conn as DataAccess, DS.incomelastview, out  admitted);
            if (res == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("L'ordinativo ha già una dimensione accettabile.","Avviso");
                return;
            }

            int n = 0;
            var rowPerIdInc = new Dictionary<int, DataRow>();
            foreach (DataRow r in DS.incomelastview.Rows) {
                int idinc = (int) r["idinc"];
                if (!admitted.ContainsKey(idinc)) {
                    r["kpro"] = DBNull.Value;
                }
            }

            foreach (DataRow r in DS.incomelastview.Select()) {
                if (r["kpro"] != DBNull.Value) continue;
                n++;
                if (r["kpro", DataRowVersion.Original] == DBNull.Value) {
                    r.Delete();
                    r.AcceptChanges();
                }
            }

            MetaFactory.factory.getSingleton<IMessageShower>().Show($"Sono stati rimossi {n} incassi dalla reversale.", "Avviso");
        }
    }
}
