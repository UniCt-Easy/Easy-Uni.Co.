
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
using metaeasylibrary;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;//funzioni_configurazione
using siopeplus_functions;
using System.Collections.Generic;
using System.Text;
using pagamenti = bankdispositionsetup_siopeplus_pagamenti;
using pp = meta_payment;

namespace payment_docmultiplo{//documentopagamentomultiplo//
	/// <summary>
	/// Summary description for frmdocumentopagamentomultiplo.
	/// Revised By Nino on 9/1/2003
	/// Revised By Nino 26/1/2003
	/// Revised By Nino 21/2/2003
	/// revised By Nino on 8/3/2003
	/// </summary>
	public class Frm_payment_docmultiplo : MetaDataForm {
        QueryHelper QHS;
        CQueryHelper QHC;
        public dsmeta DS;
		private System.Windows.Forms.Button btnCollega;
		private System.Windows.Forms.Button btnScollega;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.DataGrid dgrRigheMandato;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox gboxMovimenti;
		private System.Windows.Forms.Button btnSituazione;
		private System.Windows.Forms.TextBox txtDescrBilancio;
		private System.Windows.Forms.TextBox txtBilancio;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtCreditoreDebitore;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDataStampa;
		private System.Windows.Forms.ComboBox cmbBollo;
		private System.Windows.Forms.Button btnBollo;
		private System.Windows.Forms.ComboBox cmbCodiceIstituto;
		private System.Windows.Forms.Button btnIstitutoCassiere;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNumeroDocumento;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEsercizioDocumento;
        private System.Windows.Forms.GroupBox gboxtipo;
		bool flagcreddeb ;
		bool flagbilancio;
		bool flagrespons;
		bool flagresidui;
        private System.Windows.Forms.Button btnModifica;
		MetaData Meta;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDataAnnullo;
		private System.Windows.Forms.GroupBox gboxBilancio;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.TabPage tabBanca;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtEsitato;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtDaEsitare;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnEsitoInserisci;
		private System.Windows.Forms.Button btnEsitoModifica;
		private System.Windows.Forms.Button btnEsitoElimina;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button btnEsitaTutto;
        private CheckBox chkMisto;
        private CheckBox chkResidui;
        private CheckBox chkCompetenza;
        private TabPage tabDisposizioni;
        private Label label12;
        private DataGrid dataGrid3;
        private TextBox textBox1;
        private TextBox textBox4;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txtIdPayDisposition;
        private GroupBox groupBox8;
        private TextBox txtImportoDisposizione;
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
        private GroupBox groupBox5;
        private TextBox txtImportoNetto;
        private Label label7;
        private TextBox txtNDoc_payment;
        private GroupBox grpTrasmSiope;
        private Button btnControllaFileOPI;
        private System.ComponentModel.IContainer components;

		public Frm_payment_docmultiplo() {
			InitializeComponent();
			QueryCreator.SetTableForPosting(DS.expenselastview,"expenselast");
			QueryCreator.SetTableForPosting(DS.payment_bankview, "payment_bank");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_payment_docmultiplo));
            this.DS = new payment_docmultiplo.dsmeta();
            this.btnScollega = new System.Windows.Forms.Button();
            this.btnCollega = new System.Windows.Forms.Button();
            this.dgrRigheMandato = new System.Windows.Forms.DataGrid();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gboxMovimenti = new System.Windows.Forms.GroupBox();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.gboxBilancio = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCreditoreDebitore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDataStampa = new System.Windows.Forms.TextBox();
            this.cmbBollo = new System.Windows.Forms.ComboBox();
            this.btnBollo = new System.Windows.Forms.Button();
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizioDocumento = new System.Windows.Forms.TextBox();
            this.gboxtipo = new System.Windows.Forms.GroupBox();
            this.chkMisto = new System.Windows.Forms.CheckBox();
            this.chkResidui = new System.Windows.Forms.CheckBox();
            this.chkCompetenza = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataAnnullo = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.grpTrasmSiope = new System.Windows.Forms.GroupBox();
            this.btnControllaFileOPI = new System.Windows.Forms.Button();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.tabBanca = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnEsitaTutto = new System.Windows.Forms.Button();
            this.btnEsitoInserisci = new System.Windows.Forms.Button();
            this.btnEsitoElimina = new System.Windows.Forms.Button();
            this.btnEsitoModifica = new System.Windows.Forms.Button();
            this.txtDaEsitare = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEsitato = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
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
            this.tabDisposizioni = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtImportoDisposizione = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIdPayDisposition = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtImportoNetto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNDoc_payment = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRigheMandato)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gboxMovimenti.SuspendLayout();
            this.gboxBilancio.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxtipo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.grpTrasmSiope.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
            this.tabBanca.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.tabDisposizioni.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnScollega
            // 
            this.btnScollega.Location = new System.Drawing.Point(16, 64);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(75, 24);
            this.btnScollega.TabIndex = 2;
            this.btnScollega.TabStop = false;
            this.btnScollega.Tag = "";
            this.btnScollega.Text = "Rimuovi";
            this.btnScollega.Click += new System.EventHandler(this.btnScollega_Click);
            // 
            // btnCollega
            // 
            this.btnCollega.Location = new System.Drawing.Point(16, 32);
            this.btnCollega.Name = "btnCollega";
            this.btnCollega.Size = new System.Drawing.Size(75, 24);
            this.btnCollega.TabIndex = 1;
            this.btnCollega.TabStop = false;
            this.btnCollega.Tag = "";
            this.btnCollega.Text = "Inserisci";
            this.btnCollega.Click += new System.EventHandler(this.btnCollega_Click);
            // 
            // dgrRigheMandato
            // 
            this.dgrRigheMandato.AllowNavigation = false;
            this.dgrRigheMandato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrRigheMandato.DataMember = "";
            this.dgrRigheMandato.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrRigheMandato.Location = new System.Drawing.Point(104, 16);
            this.dgrRigheMandato.Name = "dgrRigheMandato";
            this.dgrRigheMandato.Size = new System.Drawing.Size(790, 191);
            this.dgrRigheMandato.TabIndex = 3;
            this.dgrRigheMandato.TabStop = false;
            this.dgrRigheMandato.Tag = "expenselastview.documentocollegato";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(6, 19);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.ReadOnly = true;
            this.txtImporto.Size = new System.Drawing.Size(138, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.TabStop = false;
            this.txtImporto.Tag = "";
            this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtImporto);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(774, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 47);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Importo Totale";
            // 
            // gboxMovimenti
            // 
            this.gboxMovimenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxMovimenti.Controls.Add(this.btnModifica);
            this.gboxMovimenti.Controls.Add(this.btnScollega);
            this.gboxMovimenti.Controls.Add(this.btnCollega);
            this.gboxMovimenti.Controls.Add(this.dgrRigheMandato);
            this.gboxMovimenti.Location = new System.Drawing.Point(8, 224);
            this.gboxMovimenti.Name = "gboxMovimenti";
            this.gboxMovimenti.Size = new System.Drawing.Size(910, 215);
            this.gboxMovimenti.TabIndex = 12;
            this.gboxMovimenti.TabStop = false;
            this.gboxMovimenti.Text = "Movimenti di spesa inseriti nel mandato";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(16, 96);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 4;
            this.btnModifica.TabStop = false;
            this.btnModifica.Text = "Modifica...";
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(839, 139);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(75, 23);
            this.btnSituazione.TabIndex = 89;
            this.btnSituazione.TabStop = false;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.Visible = false;
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // gboxBilancio
            // 
            this.gboxBilancio.Controls.Add(this.txtDescrBilancio);
            this.gboxBilancio.Controls.Add(this.txtBilancio);
            this.gboxBilancio.Controls.Add(this.btnBilancio);
            this.gboxBilancio.Location = new System.Drawing.Point(8, 123);
            this.gboxBilancio.Name = "gboxBilancio";
            this.gboxBilancio.Size = new System.Drawing.Size(448, 95);
            this.gboxBilancio.TabIndex = 6;
            this.gboxBilancio.TabStop = false;
            this.gboxBilancio.Tag = "AutoManage.txtBilancio.treealls";
            this.gboxBilancio.Text = "Bilancio";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Location = new System.Drawing.Point(104, 16);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(336, 45);
            this.txtDescrBilancio.TabIndex = 2;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "fin.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(6, 69);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(433, 20);
            this.txtBilancio.TabIndex = 1;
            this.txtBilancio.Tag = "fin.codefin?paymentview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(8, 37);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(80, 24);
            this.btnBilancio.TabIndex = 62;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "manage.fin.treealls";
            this.btnBilancio.Text = "Bilancio:";
            this.btnBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCreditoreDebitore);
            this.groupBox3.Location = new System.Drawing.Point(7, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 37);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtCreditoreDebitore.lista.(active=\'S\')";
            this.groupBox3.Text = "Percipiente";
            // 
            // txtCreditoreDebitore
            // 
            this.txtCreditoreDebitore.Location = new System.Drawing.Point(8, 13);
            this.txtCreditoreDebitore.Name = "txtCreditoreDebitore";
            this.txtCreditoreDebitore.Size = new System.Drawing.Size(432, 20);
            this.txtCreditoreDebitore.TabIndex = 1;
            this.txtCreditoreDebitore.Tag = "registry.title?paymentview.registry";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 86;
            this.label3.Text = "Data trasm.:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(88, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(96, 20);
            this.textBox2.TabIndex = 12;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "paymenttransmission.transmissiondate";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 84;
            this.label4.Text = "Numero:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(88, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(96, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "paymenttransmission.npaymenttransmission";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(463, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 81;
            this.label9.Text = "Data contabile:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(551, 56);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(96, 20);
            this.txtDataContabile.TabIndex = 3;
            this.txtDataContabile.Tag = "payment.adate?paymentview.adate";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(463, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 79;
            this.label8.Text = "Stampa ufficiale:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataStampa
            // 
            this.txtDataStampa.Location = new System.Drawing.Point(551, 24);
            this.txtDataStampa.Name = "txtDataStampa";
            this.txtDataStampa.Size = new System.Drawing.Size(96, 20);
            this.txtDataStampa.TabIndex = 2;
            this.txtDataStampa.Tag = "payment.printdate?paymentview.printdate";
            // 
            // cmbBollo
            // 
            this.cmbBollo.DataSource = this.DS.stamphandling;
            this.cmbBollo.DisplayMember = "description";
            this.cmbBollo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBollo.Location = new System.Drawing.Point(120, 48);
            this.cmbBollo.Name = "cmbBollo";
            this.cmbBollo.Size = new System.Drawing.Size(319, 21);
            this.cmbBollo.TabIndex = 6;
            this.cmbBollo.Tag = "payment.idstamphandling?paymentview.idstamphandling";
            this.cmbBollo.ValueMember = "idstamphandling";
            // 
            // btnBollo
            // 
            this.btnBollo.Location = new System.Drawing.Point(8, 48);
            this.btnBollo.Name = "btnBollo";
            this.btnBollo.Size = new System.Drawing.Size(104, 24);
            this.btnBollo.TabIndex = 75;
            this.btnBollo.TabStop = false;
            this.btnBollo.Tag = "manage.stamphandling.lista";
            this.btnBollo.Text = "Bollo:";
            this.btnBollo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCodiceIstituto
            // 
            this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
            this.cmbCodiceIstituto.DisplayMember = "description";
            this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(120, 16);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(320, 21);
            this.cmbCodiceIstituto.TabIndex = 4;
            this.cmbCodiceIstituto.Tag = "payment.idtreasurer?paymentview.idtreasurer";
            this.cmbCodiceIstituto.ValueMember = "idtreasurer";
            // 
            // btnIstitutoCassiere
            // 
            this.btnIstitutoCassiere.Location = new System.Drawing.Point(8, 16);
            this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(104, 24);
            this.btnIstitutoCassiere.TabIndex = 72;
            this.btnIstitutoCassiere.TabStop = false;
            this.btnIstitutoCassiere.Tag = "choose.treasurer.lista.(active=\'S\')";
            this.btnIstitutoCassiere.Text = "Cassiere:";
            this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumeroDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEsercizioDocumento);
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 73);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Documento";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(76, 42);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(112, 20);
            this.txtNumeroDocumento.TabIndex = 1;
            this.txtNumeroDocumento.Tag = "payment.npay?paymentview.npay";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioDocumento
            // 
            this.txtEsercizioDocumento.Location = new System.Drawing.Point(76, 16);
            this.txtEsercizioDocumento.Name = "txtEsercizioDocumento";
            this.txtEsercizioDocumento.ReadOnly = true;
            this.txtEsercizioDocumento.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizioDocumento.TabIndex = 0;
            this.txtEsercizioDocumento.TabStop = false;
            this.txtEsercizioDocumento.Tag = "payment.ypay?paymentview.ypay";
            // 
            // gboxtipo
            // 
            this.gboxtipo.Controls.Add(this.chkMisto);
            this.gboxtipo.Controls.Add(this.chkResidui);
            this.gboxtipo.Controls.Add(this.chkCompetenza);
            this.gboxtipo.Location = new System.Drawing.Point(238, 3);
            this.gboxtipo.Name = "gboxtipo";
            this.gboxtipo.Size = new System.Drawing.Size(316, 47);
            this.gboxtipo.TabIndex = 2;
            this.gboxtipo.TabStop = false;
            this.gboxtipo.Text = "Tipo";
            // 
            // chkMisto
            // 
            this.chkMisto.AutoSize = true;
            this.chkMisto.Enabled = false;
            this.chkMisto.Location = new System.Drawing.Point(202, 14);
            this.chkMisto.Name = "chkMisto";
            this.chkMisto.Size = new System.Drawing.Size(63, 17);
            this.chkMisto.TabIndex = 6;
            this.chkMisto.Tag = "payment.flag:2?paymentview.flag:2";
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
            this.chkResidui.Tag = "payment.flag:1?paymentview.flag:1";
            this.chkResidui.Text = "C/Residui";
            this.chkResidui.UseVisualStyleBackColor = true;
            this.chkResidui.CheckStateChanged += new System.EventHandler(this.chkResidui_CheckStateChanged);
            // 
            // chkCompetenza
            // 
            this.chkCompetenza.AutoSize = true;
            this.chkCompetenza.Location = new System.Drawing.Point(6, 14);
            this.chkCompetenza.Name = "chkCompetenza";
            this.chkCompetenza.Size = new System.Drawing.Size(97, 17);
            this.chkCompetenza.TabIndex = 4;
            this.chkCompetenza.Tag = "payment.flag:0?paymentview.flag:0";
            this.chkCompetenza.Text = "C/Competenza";
            this.chkCompetenza.UseVisualStyleBackColor = true;
            this.chkCompetenza.CheckStateChanged += new System.EventHandler(this.chkCompetenza_CheckStateChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(462, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 40);
            this.label5.TabIndex = 90;
            this.label5.Text = "Data Annullamento";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataAnnullo
            // 
            this.txtDataAnnullo.Location = new System.Drawing.Point(557, 137);
            this.txtDataAnnullo.Name = "txtDataAnnullo";
            this.txtDataAnnullo.Size = new System.Drawing.Size(100, 20);
            this.txtDataAnnullo.TabIndex = 7;
            this.txtDataAnnullo.Tag = "payment.annulmentdate";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbCodiceIstituto);
            this.groupBox4.Controls.Add(this.btnIstitutoCassiere);
            this.groupBox4.Controls.Add(this.cmbBollo);
            this.groupBox4.Controls.Add(this.btnBollo);
            this.groupBox4.Location = new System.Drawing.Point(8, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 80);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.textBox3);
            this.groupBox6.Location = new System.Drawing.Point(722, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(192, 72);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Distinta di trasmissione";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPrincipale);
            this.tabControl1.Controls.Add(this.tabBanca);
            this.tabControl1.Controls.Add(this.tabAttributi);
            this.tabControl1.Controls.Add(this.tabDisposizioni);
            this.tabControl1.Location = new System.Drawing.Point(8, 89);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(934, 471);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.TabStop = false;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.grpTrasmSiope);
            this.tabPrincipale.Controls.Add(this.gboxResponsabile);
            this.tabPrincipale.Controls.Add(this.txtDataAnnullo);
            this.tabPrincipale.Controls.Add(this.groupBox4);
            this.tabPrincipale.Controls.Add(this.groupBox6);
            this.tabPrincipale.Controls.Add(this.btnSituazione);
            this.tabPrincipale.Controls.Add(this.gboxBilancio);
            this.tabPrincipale.Controls.Add(this.txtDataContabile);
            this.tabPrincipale.Controls.Add(this.label9);
            this.tabPrincipale.Controls.Add(this.label5);
            this.tabPrincipale.Controls.Add(this.txtDataStampa);
            this.tabPrincipale.Controls.Add(this.label8);
            this.tabPrincipale.Controls.Add(this.groupBox3);
            this.tabPrincipale.Controls.Add(this.gboxMovimenti);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(926, 445);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // grpTrasmSiope
            // 
            this.grpTrasmSiope.Controls.Add(this.btnControllaFileOPI);
            this.grpTrasmSiope.Location = new System.Drawing.Point(466, 183);
            this.grpTrasmSiope.Name = "grpTrasmSiope";
            this.grpTrasmSiope.Size = new System.Drawing.Size(446, 39);
            this.grpTrasmSiope.TabIndex = 92;
            this.grpTrasmSiope.TabStop = false;
            this.grpTrasmSiope.Text = "Trasmissione SIOPE+";
            // 
            // btnControllaFileOPI
            // 
            this.btnControllaFileOPI.Location = new System.Drawing.Point(279, 10);
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
            this.gboxResponsabile.Location = new System.Drawing.Point(466, 86);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(448, 40);
            this.gboxResponsabile.TabIndex = 5;
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
            this.tabBanca.Controls.Add(this.groupBox7);
            this.tabBanca.Controls.Add(this.panel1);
            this.tabBanca.Controls.Add(this.label11);
            this.tabBanca.Controls.Add(this.dataGrid2);
            this.tabBanca.Location = new System.Drawing.Point(4, 22);
            this.tabBanca.Name = "tabBanca";
            this.tabBanca.Size = new System.Drawing.Size(926, 445);
            this.tabBanca.TabIndex = 1;
            this.tabBanca.Text = "Banca";
            this.tabBanca.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.btnEsitaTutto);
            this.groupBox7.Controls.Add(this.btnEsitoInserisci);
            this.groupBox7.Controls.Add(this.btnEsitoElimina);
            this.groupBox7.Controls.Add(this.btnEsitoModifica);
            this.groupBox7.Controls.Add(this.txtDaEsitare);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.txtEsitato);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.dataGrid1);
            this.groupBox7.Location = new System.Drawing.Point(8, 216);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(910, 158);
            this.groupBox7.TabIndex = 32;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Dettaglio degli esiti associati al mandato";
            // 
            // btnEsitaTutto
            // 
            this.btnEsitaTutto.Location = new System.Drawing.Point(8, 16);
            this.btnEsitaTutto.Name = "btnEsitaTutto";
            this.btnEsitaTutto.Size = new System.Drawing.Size(128, 22);
            this.btnEsitaTutto.TabIndex = 28;
            this.btnEsitaTutto.Tag = "";
            this.btnEsitaTutto.Text = "Esita tutto il mandato...";
            this.btnEsitaTutto.Click += new System.EventHandler(this.btnEsitaTutto_Click);
            // 
            // btnEsitoInserisci
            // 
            this.btnEsitoInserisci.Location = new System.Drawing.Point(8, 48);
            this.btnEsitoInserisci.Name = "btnEsitoInserisci";
            this.btnEsitoInserisci.Size = new System.Drawing.Size(68, 22);
            this.btnEsitoInserisci.TabIndex = 21;
            this.btnEsitoInserisci.Tag = "insert.payment";
            this.btnEsitoInserisci.Text = "Inserisci...";
            // 
            // btnEsitoElimina
            // 
            this.btnEsitoElimina.Location = new System.Drawing.Point(8, 112);
            this.btnEsitoElimina.Name = "btnEsitoElimina";
            this.btnEsitoElimina.Size = new System.Drawing.Size(68, 22);
            this.btnEsitoElimina.TabIndex = 23;
            this.btnEsitoElimina.Tag = "delete";
            this.btnEsitoElimina.Text = "Elimina";
            // 
            // btnEsitoModifica
            // 
            this.btnEsitoModifica.Location = new System.Drawing.Point(8, 80);
            this.btnEsitoModifica.Name = "btnEsitoModifica";
            this.btnEsitoModifica.Size = new System.Drawing.Size(69, 22);
            this.btnEsitoModifica.TabIndex = 22;
            this.btnEsitoModifica.Tag = "edit.payment";
            this.btnEsitoModifica.Text = "Modifica...";
            // 
            // txtDaEsitare
            // 
            this.txtDaEsitare.Location = new System.Drawing.Point(336, 16);
            this.txtDaEsitare.Name = "txtDaEsitare";
            this.txtDaEsitare.ReadOnly = true;
            this.txtDaEsitare.Size = new System.Drawing.Size(112, 20);
            this.txtDaEsitare.TabIndex = 27;
            this.txtDaEsitare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(200, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Rimasto da esitare:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsitato
            // 
            this.txtEsitato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsitato.Location = new System.Drawing.Point(790, 16);
            this.txtEsitato.Name = "txtEsitato";
            this.txtEsitato.ReadOnly = true;
            this.txtEsitato.Size = new System.Drawing.Size(112, 20);
            this.txtEsitato.TabIndex = 25;
            this.txtEsitato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(678, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Totale esitato";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(88, 48);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(814, 102);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Tag = "banktransaction.payment.payment";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 2);
            this.panel1.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(656, 16);
            this.label11.TabIndex = 29;
            this.label11.Text = "Dettaglio dei movimenti bancari associati al mandato";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(8, 24);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(910, 184);
            this.dataGrid2.TabIndex = 28;
            this.dataGrid2.Tag = "payment_bankview.default";
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
            this.tabAttributi.Size = new System.Drawing.Size(926, 445);
            this.tabAttributi.TabIndex = 3;
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
            this.gboxclass05.Location = new System.Drawing.Point(15, 286);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(465, 64);
            this.gboxclass05.TabIndex = 5;
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
            this.gboxclass04.Location = new System.Drawing.Point(15, 216);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(465, 64);
            this.gboxclass04.TabIndex = 4;
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
            this.gboxclass03.Location = new System.Drawing.Point(15, 146);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(465, 64);
            this.gboxclass03.TabIndex = 3;
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
            this.gboxclass02.Location = new System.Drawing.Point(15, 76);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(465, 64);
            this.gboxclass02.TabIndex = 2;
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
            this.gboxclass01.Location = new System.Drawing.Point(15, 6);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(465, 64);
            this.gboxclass01.TabIndex = 1;
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
            // tabDisposizioni
            // 
            this.tabDisposizioni.Controls.Add(this.groupBox8);
            this.tabDisposizioni.Controls.Add(this.label15);
            this.tabDisposizioni.Controls.Add(this.txtIdPayDisposition);
            this.tabDisposizioni.Controls.Add(this.textBox1);
            this.tabDisposizioni.Controls.Add(this.textBox4);
            this.tabDisposizioni.Controls.Add(this.label13);
            this.tabDisposizioni.Controls.Add(this.label14);
            this.tabDisposizioni.Controls.Add(this.label12);
            this.tabDisposizioni.Controls.Add(this.dataGrid3);
            this.tabDisposizioni.Location = new System.Drawing.Point(4, 22);
            this.tabDisposizioni.Name = "tabDisposizioni";
            this.tabDisposizioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisposizioni.Size = new System.Drawing.Size(926, 445);
            this.tabDisposizioni.TabIndex = 2;
            this.tabDisposizioni.Text = "Disposizioni di Pagamento";
            this.tabDisposizioni.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.txtImportoDisposizione);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(718, 116);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(196, 56);
            this.groupBox8.TabIndex = 38;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Importo Totale Disposizione";
            // 
            // txtImportoDisposizione
            // 
            this.txtImportoDisposizione.Location = new System.Drawing.Point(71, 24);
            this.txtImportoDisposizione.Name = "txtImportoDisposizione";
            this.txtImportoDisposizione.ReadOnly = true;
            this.txtImportoDisposizione.Size = new System.Drawing.Size(117, 20);
            this.txtImportoDisposizione.TabIndex = 1;
            this.txtImportoDisposizione.TabStop = false;
            this.txtImportoDisposizione.Tag = "";
            this.txtImportoDisposizione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(853, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 16);
            this.label15.TabIndex = 37;
            this.label15.Text = "Codice:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIdPayDisposition
            // 
            this.txtIdPayDisposition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdPayDisposition.Location = new System.Drawing.Point(856, 35);
            this.txtIdPayDisposition.Name = "txtIdPayDisposition";
            this.txtIdPayDisposition.ReadOnly = true;
            this.txtIdPayDisposition.Size = new System.Drawing.Size(56, 20);
            this.txtIdPayDisposition.TabIndex = 36;
            this.txtIdPayDisposition.TabStop = false;
            this.txtIdPayDisposition.Tag = "paydisposition.idpaydisposition";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 110);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(424, 62);
            this.textBox1.TabIndex = 35;
            this.textBox1.Tag = "paydisposition.motive";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(11, 20);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(423, 60);
            this.textBox4.TabIndex = 34;
            this.textBox4.Tag = "paydisposition.description";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(9, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 19);
            this.label13.TabIndex = 33;
            this.label13.Text = "Causale:";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(11, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 19);
            this.label14.TabIndex = 32;
            this.label14.Text = "Descrizione:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(656, 15);
            this.label12.TabIndex = 31;
            this.label12.Text = "Dettaglio della disposizione di pagamento associata al mandato";
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(8, 193);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(910, 221);
            this.dataGrid3.TabIndex = 30;
            this.dataGrid3.Tag = "paydispositiondetail.default";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtImportoNetto);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(581, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(152, 47);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Importo Netto";
            // 
            // txtImportoNetto
            // 
            this.txtImportoNetto.Location = new System.Drawing.Point(6, 19);
            this.txtImportoNetto.Name = "txtImportoNetto";
            this.txtImportoNetto.ReadOnly = true;
            this.txtImportoNetto.Size = new System.Drawing.Size(138, 20);
            this.txtImportoNetto.TabIndex = 1;
            this.txtImportoNetto.TabStop = false;
            this.txtImportoNetto.Tag = "";
            this.txtImportoNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(737, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 32);
            this.label7.TabIndex = 94;
            this.label7.Text = "Numero Progr. Cassiere:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNDoc_payment
            // 
            this.txtNDoc_payment.Location = new System.Drawing.Point(851, 63);
            this.txtNDoc_payment.Name = "txtNDoc_payment";
            this.txtNDoc_payment.Size = new System.Drawing.Size(72, 20);
            this.txtNDoc_payment.TabIndex = 93;
            this.txtNDoc_payment.TabStop = false;
            this.txtNDoc_payment.Tag = "payment.npay_treasurer";
            // 
            // Frm_payment_docmultiplo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(944, 567);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNDoc_payment);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gboxtipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_payment_docmultiplo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmdocumentopagamentomultiplo";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRigheMandato)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gboxMovimenti.ResumeLayout(false);
            this.gboxBilancio.ResumeLayout(false);
            this.gboxBilancio.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxtipo.ResumeLayout(false);
            this.gboxtipo.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.grpTrasmSiope.ResumeLayout(false);
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.tabBanca.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
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
            this.tabDisposizioni.ResumeLayout(false);
            this.tabDisposizioni.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		void AfterLinkBody(){
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            GetData.CacheTable(DS.expensephase);
			GetData.CacheTable(DS.config, QHS.CmpEq("ayear", Meta.GetSys("esercizio")),null,false);
            GetData.CacheTable(DS.sortingkind, null, null, false);			
			//GetData.SetSorting(DS.paymentview, "ypay desc, npay desc");
            MetaData.SetDefault(DS.banktransaction, "kind", "D");
            GetData.SetStaticFilter(DS.payment, QHS.CmpEq("ypay", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.expenselastview, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
            DataAccess.SetTableForReading(DS.expense1, "expense");
            HelpForm.SetDenyNull(DS.payment.Columns["idtreasurer"], true);

        }
        DataAccess Conn;
        bool UsoSiope = false;
        public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			AfterLinkBody();

            Conn = Meta.Conn;
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
              null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this,1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }
            UsoSiope = Verifica_Uso_SiopePlus();
            if (!UsoSiope) {
                grpTrasmSiope.Visible = false;
            }
        }

        object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(this);
        }

      
		public void MetaData_BeforeActivation(){
			if (DS.config.Rows.Count==0) {
				Meta.CanSave=false;
				Meta.SearchEnabled=false;
				Meta.CanInsert=false;
				return;
			}
			Meta.myGetData.ReadCached();
			string bilanciofilter = 
                QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.BitSet("flag", 0));
			DataRow rPers = DS.config.Rows[0];
			string maxfasebil = Meta.Conn.DO_READ_VALUE("finlevel", 
				QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "max(nlevel)").ToString();
            byte payment_flag = (byte)rPers["payment_flag"];
            if (((payment_flag & 2) == 2) &&
				(rPers["payment_finlevel"].ToString()!="") &&
				(rPers["payment_finlevel"].ToString()!= maxfasebil)
				) {
                gboxBilancio.Tag = "AutoManage.txtBilancio.trees" + rPers["payment_finlevel"] + "."
                    + QHS.CmpLe("nlevel", rPers["payment_finlevel"]);
				btnBilancio.Tag = "manage.fin.trees"+rPers["payment_finlevel"];
				string descrfasebil = Meta.Conn.DO_READ_VALUE("finlevel", 
                    QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
					QHS.CmpEq("nlevel",rPers["payment_finlevel"])), "description") as string;
                if (descrfasebil != null) {
                    gboxBilancio.Text += " (" + descrfasebil + ")";
                }
			}
			else {
				gboxBilancio.Tag="AutoManage.txtBilancio.trees";
				btnBilancio.Tag="manage.fin.trees";
			}
			GetData.SetStaticFilter(DS.fin, bilanciofilter);					
		}

		public void MetaData_AfterActivation(){
			if (DS.config.Rows.Count==0) return;

			EsaminaFlag();
			CalcolaDefaultPerIstitutoCassiere();
			CalcolaDefaultPerBollo();

            int flag = CfgFn.GetNoNullInt32(DS.payment.Columns["flag"].DefaultValue);
            if (!flagresidui) {
                flag = flag & 0xF8;
                flag = flag + 4;
                DS.payment.Columns["flag"].DefaultValue = flag;
            }
            else {
                flag = flag & 0xF8;
                flag = flag + 1;
                DS.payment.Columns["flag"].DefaultValue = flag;
            }

		}

		void CalcolaDefaultPerBollo(){
			DataRow[] bollo = DS.stamphandling.Select("flagdefault='S'");
			if (bollo.Length!=1) return;
			MetaData.SetDefault(DS.payment,"idstamphandling",bollo[0]["idstamphandling"]);
		}

		void CalcolaDefaultPerIstitutoCassiere(){
			DataRow[] cassiere = DS.treasurer.Select("flagdefault='S'");
            if (cassiere.Length == 1) {
                MetaData.SetDefault(DS.payment, "idtreasurer", cassiere[0]["idtreasurer"]);
                return;
            }
            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                MetaData.SetDefault(DS.payment, "idtreasurer", codiceistituto);
            }
	
		}


		public void MetaData_AfterClear(){
			if (DS.config.Rows.Count==0) return;
			EsaminaFlag();		
			txtEsercizioDocumento.Text=Meta.GetSys("esercizio").ToString();
			btnCollega.Enabled=false;
			btnScollega.Enabled=false;
			btnModifica.Enabled=false;
			btnSituazione.Enabled=false;
            btnControllaFileOPI.Enabled = false;
            txtImporto.Text= "";
            txtImportoNetto.Text = "";
			gestisciBottoniEsito(false);
            DS.expensesorted.Clear();
            DS.expenselastmandatedetail.Clear();
            txtImportoDisposizione.Text = "";
            txtNumeroDocumento.ReadOnly = false;
            btnIstitutoCassiere.Enabled = true;
            cmbCodiceIstituto.Enabled = true;
		    gboxMovimenti.Enabled = true;
            txtNDoc_payment.ReadOnly = false;
		}

		public void MetaData_AfterFill(){
			if (DS.config.Rows.Count==0) return;

			bool ModoInsert = MetaData.GetMetaData(this).InsertMode;

			gestisciBottoniEsito(!Meta.InsertMode);
			string filter = null;
			//if (Meta.FirstFillForThisRow) {
			DataRow Curr = DS.payment.Rows[0];
            string filtraMandato = QHS.CmpKey(Curr);
			
			// Determino i movimenti già esitati
			string listaid = null;
		
			foreach(DataRow rExp in DS.expenselastview.Rows) {
				decimal importoGiaEsitato = 0;
				foreach(DataRow rBTans in DS.banktransaction.Select(QHC.CmpEq("idexp", rExp["idexp"]))) {
						importoGiaEsitato+=CfgFn.GetNoNullDecimal(rBTans["amount"]);
				}
                if (importoGiaEsitato >= CfgFn.GetNoNullDecimal(rExp["curramount"])) {
                    listaid += QHS.quote(rExp["idexp"]) + ",";
                }
			}
			if (listaid != null) {
				listaid = listaid.Substring(0,listaid.Length -1);
				if (listaid.Length >0) {
					filter = "(idexp not in ("+listaid+"))";
				}
				else {
					filter = null;
				}
			}
			filter = GetData.MergeFilters(filtraMandato,filter);
			DS.banktransaction.ExtendedProperties[MetaData.ExtraParams] = filter;
			EsaminaFlag();//reimposta il form in base ai flag
			btnIstitutoCassiere.Enabled=true;
            CalcolaImporto();
			btnCollega.Enabled=true;
			btnScollega.Enabled=true;
			btnModifica.Enabled=true;
			btnSituazione.Enabled=!ModoInsert;
            btnControllaFileOPI.Enabled = !ModoInsert;
            DataRow CurrDoc = DS.payment.Rows[0];
			//DataSet MyDS = (DataSet)dgrRigheMandato.DataSource;
			//DataTable MyTable = MyDS.Tables[dgrRigheMandato.DataMember.ToString()];
			DataTable MyTable=DS.expenselastview;
	
			if (MyTable.Rows.Count > 0) {
				gboxtipo.Enabled=false;
				txtCreditoreDebitore.ReadOnly=true;
				txtResponsabile.Enabled=false;
				txtBilancio.ReadOnly=true;
				btnBilancio.Enabled=false;
			}
			impostaTipoDocumento();
            if (ModoInsert)
            {
               DS.payment_bankview.Clear();
            }

            if (Meta.EditMode) {
                txtNumeroDocumento.ReadOnly = true;

                if (DS.expenselastview.Rows.Count == 0) {
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
            if (Meta.IsEmpty) txtNDoc_payment.ReadOnly = false; else txtNDoc_payment.ReadOnly = true;

        }

        

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (Meta.EditMode && T.TableName == "treasurer" ) {
                if (R == null) {
                    gboxMovimenti.Enabled = false;
                }
                else {
                    object currTr = R["idtreasurer"];
                    object oldTr = DS.payment.Rows[0]["idtreasurer", DataRowVersion.Original];
                    gboxMovimenti.Enabled = (currTr.ToString() == oldTr.ToString());
                }
            }
        }

		private void impostaTipoDocumento() {
			foreach(DataRow rTransazione in DS.banktransaction.Select(null,null,DataViewRowState.Added)) {
				rTransazione["kind"] = "D";
			}
		}

        decimal CalcolaImportoIncassi() {
            if (DS.expenselastview.Select(QHC.IsNotNull("kpay")).Length == 0) return 0;
            string list = QHS.DistinctVal(DS.expenselastview.Select(QHC.IsNotNull("kpay")),"idexp");

            //sottrai ritenute c/pecipiente / recuperi / incassi vincolati / automatismi  CSA
            string sql = "select sum(IIT.curramount) from incometotal IIT " +
              " join income II on II.idinc=IIT.idinc " +
              " join incomelast IL on IL.idinc=II.idinc   " +
              " join expense E on E.idexp = II.idpayment " +
              " where (II.idpayment in (" + list + ")) " +
                //task 5739: filtro l'anag. solo per autokind 4, come la stampa
              " and ((II.autokind = 4 and II.idreg=E.idreg) OR II.autokind in (6,7,14,20,21,30,31))  ";
              //" and II.idreg = E.idreg  ";

            // sottrai contributi c/ente  (temporaneamente sospeso, si deve considerare la coerenza con la stampa)
            /*
            string sql1 = " select sum(IIT.curramount) from incometotal IIT " +
                " join income II on II.idinc=IIT.idinc " +
                " join incomelast IL on IL.idinc=II.idinc  " +
                " join expense E on E.idpayment = I.idpayment " +
                " where (E.idexp in (" + list + ")) " +
                " and II.autokind = 4  AND E.autokind = 4 AND II.autocode = E.autocode " +
                " and II.idreg = E.idreg   "; */
    
            return CfgFn.GetNoNullDecimal(Conn.DO_SYS_CMD(sql));
        }

   private void CalcolaImporto(){
			DataSet MyDS = (DataSet)dgrRigheMandato.DataSource;
			DataTable MyTable = MyDS.Tables[dgrRigheMandato.DataMember.ToString()];
			decimal importo=0;
			importo=MetaData.SumColumn(MyTable, "curramount");
            decimal netto = importo - CalcolaImportoIncassi();
			txtImporto.Text=importo.ToString("C");
            txtImportoNetto.Text = netto.ToString("C");
			decimal esitato=0;
			esitato= MetaData.SumColumn(DS.banktransaction,"amount");
			decimal nonesitato=importo-esitato;
			txtEsitato.Text= esitato.ToString("c");
			txtDaEsitare.Text= nonesitato.ToString("c");
			MetaData.SetDefault(DS.banktransaction,"amount",nonesitato);
            decimal importodisposizione = 0;
            importodisposizione = MetaData.SumColumn(DS.paydispositiondetail, "amount");
            txtImportoDisposizione.Text = importodisposizione.ToString("c");
		}

		private void EsaminaFlag(){	
			if (DS.config.Rows.Count==0) return;

            byte payment_flag = (byte)DS.config.Rows[0]["payment_flag"];
            flagcreddeb = (payment_flag & 4) == 4;
            flagbilancio = (payment_flag & 2) == 2;
            flagrespons = (payment_flag & 16) == 16;
            flagresidui = (payment_flag & 8) == 8;

            txtCreditoreDebitore.ReadOnly = !flagcreddeb;
			txtBilancio.ReadOnly    = !flagbilancio;
			btnBilancio.Enabled     =  flagbilancio;
			txtResponsabile.Enabled =  flagrespons;
			gboxtipo.Enabled        =  flagresidui;
		}

		string CalculateFilterForLinking(bool SQL){
            QueryHelper qh = SQL ? QHS : QHC;
			string MyFilter = "";
            object codicefase = Meta.GetSys("maxexpensephase");
            //int giornianticipo = CfgFn.GetNoNullInt32(DS.Tables["config"].Rows[0]["expense_expiringdays"]);
			
			object codicecreddeb = DS.payment.Rows[0]["idreg"];
			object idbilancio = DS.payment.Rows[0]["idfin"];
			object codiceresponsabile = DS.payment.Rows[0]["idman"];
            int eserccorrente=(int) Meta.GetSys("esercizio");

            MyFilter = qh.AppAnd(qh.CmpEq("nphase", codicefase), qh.IsNull("kpay"), qh.CmpEq("ayear", eserccorrente));
            if (flagcreddeb)
            {
                MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idreg", codicecreddeb));
            }
            if (flagbilancio) {
                if (idbilancio == DBNull.Value)
                {
                    MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idfin"));
                }
                else
                {
                    DataTable FinLink = Meta.Conn.RUN_SELECT("finlink", "idchild", null, QHS.CmpEq("idparent", idbilancio), null, true);
                    string lista = qh.DistinctVal(FinLink.Select(), "idchild");
                    MyFilter = qh.AppAnd(MyFilter, qh.FieldInList("idfin", lista));
                }
            }
			if (flagrespons) {
                MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idman", codiceresponsabile));
			}

			//DateTime scadenza = (DateTime) Meta.GetSys("datacontabile");
			//scadenza = scadenza.AddDays( giornianticipo);
   //         MyFilter = qh.AppAnd(MyFilter, qh.NullOrLe("expiration", scadenza));
			if (flagresidui) {
				if (chkCompetenza.Checked){
                    MyFilter =qh.AppAnd(MyFilter, qh.CmpEq("flagarrear", "C"));
                }
                if (chkResidui.Checked) {
                    MyFilter =qh.AppAnd(MyFilter, qh.CmpEq("flagarrear", "R"));
                }
			}
			return MyFilter;
		}
		private void btnCollega_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count==0) return;

			if (MetaData.Empty(this)) return;
			MetaData.GetFormData(this,true);
			string MyFilter = CalculateFilterForLinking(true);
			string command = "choose.expenselastview.documentocollegato." + MyFilter;
			MetaData.Choose(this,command);
			CalcolaImporto();
            if (UsoSiope) {
                Dictionary<int, DataRow> admitted;
                string res = pp.Meta_payment.SimulaGenerazioneOrdinativo(Conn, DS.expenselastview, out admitted);
                if (res!=null)MetaFactory.factory.getSingleton<IMessageShower>().Show(res, "Informazione");
            }
        }

        //controlla che si debba usare la trasmissione Siope+ 
        public bool Verifica_Uso_SiopePlus() {
            object usesiopeplus = Conn.DO_READ_VALUE("opisiopeplus_config", QHS.CmpEq("code", "opi_siopeplus"), "usesiopeplus", null);
            if (usesiopeplus == null || usesiopeplus == DBNull.Value) return false;
            if (usesiopeplus.ToString() == "S") return true;
            return false;
        }

        private void btnModifica_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count==0) return;

			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			string MyFilter = CalculateFilterForLinking(false);
			string MyFilterSQL = CalculateFilterForLinking(true);
			Meta.MultipleLinkUnlinkRows("Composizione documento",
				"Movimenti inclusi nel documento selezionato", 
				"Movimenti non inclusi in alcun documento",
				DS.expenselastview, MyFilter, MyFilterSQL, "documentocollegato"); 
			ClearWhenNoRowsSelected();
			CalcolaImporto();
            if (UsoSiope) {
                Dictionary<int, DataRow> admitted;
                string res = pp.Meta_payment.SimulaGenerazioneOrdinativo(Conn, DS.expenselastview, out admitted);
                if (res!=null)MetaFactory.factory.getSingleton<IMessageShower>().Show(res, "Informazione");
            }
        }
		
		private void btnScollega_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count==0) return;

			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			MetaData.Unlink_Grid(dgrRigheMandato);
			ClearWhenNoRowsSelected();
			CalcolaImporto();
            if (UsoSiope) {
                Dictionary<int, DataRow> admitted;
                string res = pp.Meta_payment.SimulaGenerazioneOrdinativo(Conn, DS.expenselastview, out admitted);
                if (res!=null)MetaFactory.factory.getSingleton<IMessageShower>().Show(res, "Informazione");
            }
        }

		void ClearWhenNoRowsSelected(){
			return;
		}
        
        // Il bottone collegato a questo evento è not visibile! Bisogna creare la SP (se si vuole usare)
		private void btnSituazione_Click(object sender, System.EventArgs e) {
			string esercdocumento;
			string numdocumento;
			DataAccess Conn=MetaData.GetConnection(this);
			try {
				DataRow MyRow=HelpForm.GetLastSelected(DS.payment);
				esercdocumento=MyRow["ypay"].ToString();
				numdocumento=MyRow["npay"].ToString();
			}
			catch {
				return;
			}
			DataSet Out = Conn.CallSP("sp_sit_docpagamento",
				new Object[3] {Meta.GetSys("datacontabile"),
								  esercdocumento,
								  numdocumento
							  }
				);
			if (Out==null) return;
			Out.Tables[0].TableName= "Situazione documento";
			frmSituazioneViewer View = new frmSituazioneViewer(Out);
            createForm(View, null);
            View.Show();		
		}

		void EliminaVariazioniDiAnnullo(){
			if (DS.config.Rows.Count==0) return;

			if (DS.expenselastview.Rows.Count==0) return;
			DataAccess Conn = Meta.Conn;
			string filter = QHS.AppAnd(QHS.CmpEq("autokind",11), QHS.FieldIn("idexp",DS.expenselastview.Select(),"idexp"));
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.expensevar, null, 
					filter, null, true);
			DataRow []RowsToDel = DS.expensevar.Select(filter);
			foreach (DataRow ToDel in RowsToDel){
				ToDel.Delete();
			}

		}

		void AggiungiVariazioniDiAnnullo(DateTime DataAnnullo) {
			if (DS.config.Rows.Count == 0) return;

			if (DS.expenselastview.Rows.Count == 0) return;
			DataAccess Conn = Meta.Conn;
			string filter = QHS.AppAnd(
				QHS.AppAnd(QHS.CmpEq("autokind", 11), QHS.CmpEq("yvar", Meta.GetSys("esercizio"))),
				QHS.FieldIn("idexp", DS.expenselastview.Select(), "idexp"));
			MetaData MetaVar = MetaData.GetMetaData(this, "expensevar");
			MetaVar.SetDefaults(DS.expensevar);
			MetaData.SetDefault(DS.expensevar, "adate", DataAnnullo);

			DS.expensesorted.Clear();
			DS.expenselastmandatedetail.Clear();

			MetaData.SetDefault(DS.expensevar, "autokind", 11);
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensevar, null, filter, null, true);
			DataRow Curr = DS.payment.Rows[0];
			string descrvar = "Annullamento del mandato " + Curr["ypay"] + "/" + Curr["npay"];
			foreach (DataRow SpesaToAdd in DS.expenselastview.Select()) {
				string filteridspesa = QHC.AppAnd(QHC.CmpEq("idexp", SpesaToAdd["idexp"]), QHC.CmpEq("autokind", 11));
				string filterclass = QHC.CmpEq("idexp", SpesaToAdd["idexp"]);
				DataRow[] VarAnnullo = DS.expensevar.Select(filteridspesa, null);
				if (VarAnnullo.Length == 0) {
					MetaData.SetDefault(DS.expensevar, "idexp", SpesaToAdd["idexp"]);
					DataRow NewVarAnnullo = MetaVar.Get_New_Row(null, DS.expensevar);
					decimal impcorr = CfgFn.GetNoNullDecimal(SpesaToAdd["curramount"]);
					NewVarAnnullo["amount"] = -impcorr;
					NewVarAnnullo["description"] = descrvar;

				}
				else {
					DataRow ExistVarAnnullo = VarAnnullo[0];
					decimal currvar = CfgFn.GetNoNullDecimal(ExistVarAnnullo["amount"]);
					decimal impcorr = CfgFn.GetNoNullDecimal(SpesaToAdd["curramount"]);
					if (impcorr != 0) {
						ExistVarAnnullo["amount"] = currvar - impcorr;
						ExistVarAnnullo["adate"] = DataAnnullo;
						//ExistVarAnnullo["descrizione"]= descrvar;
					}
				}

				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expensesorted, null, filterclass, null, true);
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenselastmandatedetail, null, filterclass, null, true);

			}

			
			foreach (DataRow R in DS.expensesorted.Select()) {
				R["amount"] = 0;
			}

			foreach (DataRow R in DS.expenselastmandatedetail.Select()) {
                R["originalamount"] = R["amount"];
				R["amount"] = 0;
			}

		}

		public void MetaData_BeforePost(){
			if (DS.config.Rows.Count==0) return;

			if (Meta.IsEmpty)return;
			if (DS.payment.Rows.Count==0) return;//provengo da insert/cancel
			DataRow Curr = DS.payment.Rows[0];
			if (Curr.RowState== DataRowState.Deleted){
				EliminaVariazioniDiAnnullo();
			}
			else {
				if (Curr["annulmentdate"]==DBNull.Value){
					EliminaVariazioniDiAnnullo();
				}
				else {
					AggiungiVariazioniDiAnnullo((DateTime)Curr["annulmentdate"]);
				}
			}
			azzeraMovBancarioInSpesa();
		}

		private void azzeraMovBancarioInSpesa() {
			if (DS.payment.Rows.Count == 0) return;
            string filtro = QHC.AppAnd(QHC.IsNull("kpay"), QHC.IsNotNull("idpay"));
			foreach(DataRow R in DS.expenselastview.Select(filtro)) {
				R["idpay"] = DBNull.Value;
			}
		}

		public void MetaData_AfterPost() {
			if (DS.payment.Rows.Count == 0) return;
			fillPaymentBank();
			DS.payment_bankview.Clear();
            DS.expensesorted.Clear();
            DS.expenselastmandatedetail.Clear();
			DataRow Curr = DS.payment.Rows[0];
			string filter = QHS.CmpKey(Curr);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.payment_bankview, "idpay", filter, null, true);
		}

		private void gestisciBottoniEsito(bool abilita) {
			btnEsitoElimina.Enabled = abilita;
			btnEsitoInserisci.Enabled = abilita;
			btnEsitoModifica.Enabled = abilita;
		}

		private void fillPaymentBank() {
			DataRow Curr = DS.payment.Rows[0];
			DataSet Out = Meta.Conn.CallSP("compute_payment_bank",
				new object[] {Curr["kpay"]}, false, 0);
		}

	    DataTable callSp(List<int> idincList) {
	        StringBuilder sb = new StringBuilder();
	        sb.AppendLine("DECLARE @lista AS int_list;");
	        int currblockLen = 0;
	        foreach(int id in idincList) {
	            if (currblockLen == 0) {
	                sb.Append($"insert into @lista values ({id})");
	            }
	            else {
	                sb.Append($",({id})");
	            }

	            currblockLen++;
	            if (currblockLen == 20) {
	                sb.AppendLine(";");
	                currblockLen = 0;
	            }
	        }
	        if (currblockLen>0) sb.AppendLine(";");

            sb.AppendLine($"exec  trasmele_expense_opisiopeplus_ins {Conn.GetEsercizio()},null,'N', @lista");
	        return Conn.SQLRunner(sb.ToString());
	    }

		private void btnEsitaTutto_Click(object sender, System.EventArgs e) {
			if (DS.payment.Rows.Count == 0) return;
			decimal esitato= MetaData.SumColumn(DS.banktransaction,"amount");
			decimal totaleMandato = MetaData.SumColumn(DS.expenselastview,"amount");
			if (esitato == totaleMandato) return;
			// Richiama la finestra per le informazioni
			int lenBankReference = (int) Meta.Conn.DO_READ_VALUE("columntypes",
                QHS.AppAnd(QHS.CmpEq("tablename","banktransaction"),QHS.CmpEq("field","bankreference")),
                "col_len");
			frmAskInfo F = new frmAskInfo(lenBankReference);
            createForm(F, this);
            if (F.ShowDialog(this)!=DialogResult.OK) return;
			object dataOperazione = F.dataOperazione;
			object dataValuta = F.dataValuta;
			object rifBanca = F.rifBanca;
			if (dataOperazione==null) return;
			
			DataRow Curr = DS.payment.Rows[0];
			Meta.GetFormData(false);
			// Ciclo per creare le esitazioni nel dataset
			MetaData metaBT = MetaData.GetMetaData(this, "banktransaction");
			metaBT.SetDefaults(DS.banktransaction);
			
			foreach(DataRow rExp in DS.expenselastview.Rows) {
                decimal importoCorrente = CfgFn.GetNoNullDecimal(rExp["curramount"]);
				decimal importoGiaEsitato = 0;
				decimal importoDaEsitare=0;
				foreach(DataRow rBTans in DS.banktransaction.Select(QHC.CmpEq("idexp", rExp["idexp"]))) {
						importoGiaEsitato+=CfgFn.GetNoNullDecimal(rBTans["amount"]);
				}
				if (importoGiaEsitato == importoCorrente) {
					continue;
				}
				else {
					// Creo la nuova esitazione
					importoDaEsitare = importoCorrente - importoGiaEsitato;
					DataRow rBT = metaBT.Get_New_Row(null,DS.banktransaction); 
					rBT["amount"] = importoDaEsitare;
					rBT["kpay"]   = Curr["kpay"];
                    rBT["idpay"] = rExp["idpay"];
					rBT["bankreference"] = rifBanca;
					rBT["kind"] = "D";
                    rBT["idexp"] = rExp["idexp"];
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
            bool isChecked = (chkResidui.CheckState==CheckState.Checked);
            if (isChecked) {
                chkCompetenza.Checked = !isChecked;
                chkMisto.Checked = !isChecked;
            }
        }

        private void chkMisto_CheckStateChanged (object sender, EventArgs e) {
            bool isChecked = (chkMisto.CheckState==CheckState.Checked);
            if (isChecked) {
                chkResidui.Checked = !isChecked;
                chkCompetenza.Checked = !isChecked;
            }
        }

        private void btnControllaFileOPI_Click(object sender, EventArgs e) {
            Dictionary<int, DataRow> admitted;
            string res = pp.Meta_payment.SimulaGenerazioneOrdinativo(Conn, DS.expenselastview, out admitted);
            if (res == null) res = "L'ordinativo ha già una dimensione accettabile.";
            if (res!=null)MetaFactory.factory.getSingleton<IMessageShower>().Show(res, "Informazione");
            int n = 0;
            Dictionary<int,DataRow> rowPerIdExp = new Dictionary<int, DataRow>();
            foreach (DataRow r in DS.expenselastview.Rows) {
                int idexp = (int) r["idexp"];
                if (!admitted.ContainsKey(idexp)) {
                    r["kpay"] = DBNull.Value;
                }
            }

            foreach (DataRow r in DS.expenselastview.Select()) {
                if (r["kpay"] != DBNull.Value) continue;
                n++;
                if (r["kpay", DataRowVersion.Original] == DBNull.Value) {
                    r.Delete();
                    r.AcceptChanges();
                }
            }

            MetaFactory.factory.getSingleton<IMessageShower>().Show("Sono stati rimossi " + n + " pagamenti dal mandato.", "Avviso");

        }
    }
}
