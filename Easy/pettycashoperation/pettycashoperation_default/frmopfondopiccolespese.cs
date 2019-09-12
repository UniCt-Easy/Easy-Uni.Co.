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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;//funzioni_configurazione
using ep_functions;
using calcolooccasionale;
using AskInfo;
using gestioneclassificazioni;
using q  = metadatalibrary.MetaExpression;

namespace pettycashoperation_default {//opfondopiccolespese//
	/// <summary>
	/// Summary description for frmopfondopiccolespese.
	/// </summary>
	public class Frm_pettycashoperation_default : System.Windows.Forms.Form {
		private MetaData Meta;
		DataAccess Conn;
        GestioneClassificazioni ManageClassificazioni;
        private System.Windows.Forms.Button btnBilancio;
		public System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.TabControl tabOpfondops;
		private System.Windows.Forms.TabPage tabOperazione;
		private System.Windows.Forms.TabPage tabMovimenti;
		private System.Windows.Forms.ComboBox cmbFondoPS;
		private System.Windows.Forms.GroupBox grpOperazione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercOp;
		private System.Windows.Forms.TextBox txtNumOp;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpTipoOperazione;
		private System.Windows.Forms.GroupBox grpTipoSpesa;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtDataDoc;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Label label8;
		public vistaForm DS;
        public System.Windows.Forms.GroupBox grpBilancio;
		private System.Windows.Forms.DataGrid dgrPSMovSpesa;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.DataGrid dgrPSMovEntrata;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.GroupBox gboxSpesa;
		private System.Windows.Forms.Button btnSpesa;
		private System.Windows.Forms.CheckBox chkSpesa;
		//private System.Windows.Forms.GroupBox gboxNormale;
		private System.Windows.Forms.TextBox txtNum;
		private System.Windows.Forms.TextBox txtEserc;
		private System.Windows.Forms.ComboBox cmbFaseSpesa;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox gboxreintegro;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox txtImportoCollegato;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkListTitle;
		private System.Windows.Forms.CheckBox chkListManager;
        private System.Windows.Forms.CheckBox chkFilterAvailable;
		private System.Windows.Forms.TabPage tabClassSup;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.DataGrid DGridDettagliClassificazioni;
		private System.Windows.Forms.Button btnDelClass;
		private System.Windows.Forms.Button btnEditClass;
		private System.Windows.Forms.Button btnInsertClass;
		private System.Windows.Forms.DataGrid DGridClassificazioni;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gboxDocumento;
		private System.Windows.Forms.Button btnDocumento;
		private System.Windows.Forms.Label labEsercizio;
		private System.Windows.Forms.ComboBox cmbTipoDocumento;
		private System.Windows.Forms.TextBox txtNumDoc;
		private System.Windows.Forms.Label labNum;
		private System.Windows.Forms.TextBox txtEsercDoc;
		private System.Windows.Forms.Label labelTipoDocumento;
		private System.Windows.Forms.ComboBox cmbCausale;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipoContabilizzazione;
		private System.ComponentModel.IContainer components;
		bool InChiusura=false;


		
		DataRow MissionLinked;
		DataRow MissioneMovSpesaLinked;
		int CurrCausaleMissione;
		bool MissionLinkedMustBeEvalued;


		DataRow OccasionaleLinked;
		DataRow OccasionaleMovSpesaLinked;
		int CurrCausaleOccasionale;
		bool OccasionaleLinkedMustBeEvalued;


		DataRow ProfessionaleLinked;
		DataRow ProfessionaleMovSpesaLinked;
		int CurrCausaleProfessionale;
		bool ProfessionaleLinkedMustBeEvalued;

	
		DataRow IvaLinked;
		DataRow IvaMovSpesaLinked;
        int CurrCausaleIva;
		private System.Windows.Forms.GroupBox gboxCurrAmount;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.CheckBox chkDocumentata;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCausale;
        private CheckBox chkChiusura;
        private CheckBox chkReintegro;
        private CheckBox chkApertura;
        private CheckBox chkOpSpesa;
		bool IvaLinkedMustBeEvalued;
        private GroupBox grpNList;
        private TextBox txtNList;
        private Label label11;
        private TabPage tabAttributi;
        private TabPage tabFinanziamenti;
        private DataGrid dgridFinanziamenti;
        private Button btnDelFinanziamenti;
        private Button btnEditFinanziamenti;
        private Button btnInsertFinanziamenti;
        private TextBox txtTotFinanziato;
        private Label label22;
        private GroupBox gboxBolletta;
        private TextBox txtBolletta;
        private Button btnBolletta;
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
        private TabPage tabAnalitico;
        private GroupBox groupBox8;
        private TextBox txtFineCompetenza;
        private TextBox txtInizioCompetenza;
        private Label label10;
        private Label label9;
        public GroupBox gboxclass3;
        public Button btnCodice3;
        private TextBox txtDenom3;
        public TextBox txtCodice3;
        private Button btnGeneraEpExp;
        private GroupBox gboxDebito;
        private TextBox txtDenomCausaleDebito;
        private TextBox txtCodiceCausaleDebito;
        private Button button1;
        private Button btnVisualizzaEpExp;
        public GroupBox gboxclass2;
        public Button btnCodice2;
        private TextBox txtDenom2;
        public TextBox txtCodice2;
        private Button btnGeneraEP;
        private GroupBox gboxCosto;
        private TextBox txtDenomCausaleCosto;
        private TextBox txtCodiceCausaleCosto;
        private Button button2;
        private Button btnVisualizzaEP;
        private Label labEP;
        public GroupBox gboxclass1;
        public Button btnCodice1;
        private TextBox txtDenom1;
        public TextBox txtCodice1;
        private GroupBox gboxImporto;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        private GroupBox gboxAnalitico;
        private GroupBox groupCredDeb;
        public TextBox txtCredDeb;
        private Button btnGenPreimpegni;
        private Button btnViewPreimpegni;
        private GroupBox grpBoxSiopeEP;
        private Button btnSiope;
        private TextBox txtDescSiope;
        private TextBox txtCodSiope;
        private Button btnGeneraClassAutomatiche;
        bool TipoClassAvailableEvalued;

		
		public Frm_pettycashoperation_default() {
			InitializeComponent();
			//HelpForm.SetDenyNull(DS.pettycashoperation.Columns["flagdocumented"], true);
            dgridFinanziamenti.DataSource = DS.pettycashoperationunderwriting;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				InChiusura=true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_pettycashoperation_default));
            this.tabOpfondops = new System.Windows.Forms.TabControl();
            this.tabOperazione = new System.Windows.Forms.TabPage();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.gboxImporto = new System.Windows.Forms.GroupBox();
            this.txtImportoCollegato = new System.Windows.Forms.TextBox();
            this.gboxBolletta = new System.Windows.Forms.GroupBox();
            this.txtBolletta = new System.Windows.Forms.TextBox();
            this.btnBolletta = new System.Windows.Forms.Button();
            this.grpNList = new System.Windows.Forms.GroupBox();
            this.txtNList = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelCausale = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gboxCurrAmount = new System.Windows.Forms.GroupBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFondoPS = new System.Windows.Forms.ComboBox();
            this.DS = new pettycashoperation_default.vistaForm();
            this.gboxreintegro = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.grpTipoSpesa = new System.Windows.Forms.GroupBox();
            this.chkDocumentata = new System.Windows.Forms.CheckBox();
            this.grpTipoOperazione = new System.Windows.Forms.GroupBox();
            this.chkChiusura = new System.Windows.Forms.CheckBox();
            this.chkReintegro = new System.Windows.Forms.CheckBox();
            this.chkApertura = new System.Windows.Forms.CheckBox();
            this.chkOpSpesa = new System.Windows.Forms.CheckBox();
            this.grpOperazione = new System.Windows.Forms.GroupBox();
            this.txtNumOp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercOp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtDataDoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gboxDocumento = new System.Windows.Forms.GroupBox();
            this.btnDocumento = new System.Windows.Forms.Button();
            this.labEsercizio = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.labNum = new System.Windows.Forms.Label();
            this.txtEsercDoc = new System.Windows.Forms.TextBox();
            this.labelTipoDocumento = new System.Windows.Forms.Label();
            this.cmbCausale = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoContabilizzazione = new System.Windows.Forms.ComboBox();
            this.grpBilancio = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.chkListManager = new System.Windows.Forms.CheckBox();
            this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.gboxSpesa = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
            this.btnSpesa = new System.Windows.Forms.Button();
            this.chkSpesa = new System.Windows.Forms.CheckBox();
            this.tabClassSup = new System.Windows.Forms.TabPage();
            this.btnGeneraClassAutomatiche = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DGridDettagliClassificazioni = new System.Windows.Forms.DataGrid();
            this.btnDelClass = new System.Windows.Forms.Button();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnInsertClass = new System.Windows.Forms.Button();
            this.DGridClassificazioni = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMovimenti = new System.Windows.Forms.TabPage();
            this.dgrPSMovEntrata = new System.Windows.Forms.DataGrid();
            this.dgrPSMovSpesa = new System.Windows.Forms.DataGrid();
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
            this.tabAnalitico = new System.Windows.Forms.TabPage();
            this.gboxAnalitico = new System.Windows.Forms.GroupBox();
            this.grpBoxSiopeEP = new System.Windows.Forms.GroupBox();
            this.btnSiope = new System.Windows.Forms.Button();
            this.txtDescSiope = new System.Windows.Forms.TextBox();
            this.txtCodSiope = new System.Windows.Forms.TextBox();
            this.btnGenPreimpegni = new System.Windows.Forms.Button();
            this.btnViewPreimpegni = new System.Windows.Forms.Button();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.gboxclass1 = new System.Windows.Forms.GroupBox();
            this.btnCodice1 = new System.Windows.Forms.Button();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtCodice1 = new System.Windows.Forms.TextBox();
            this.gboxclass3 = new System.Windows.Forms.GroupBox();
            this.btnCodice3 = new System.Windows.Forms.Button();
            this.txtDenom3 = new System.Windows.Forms.TextBox();
            this.txtCodice3 = new System.Windows.Forms.TextBox();
            this.btnGeneraEpExp = new System.Windows.Forms.Button();
            this.gboxclass2 = new System.Windows.Forms.GroupBox();
            this.btnCodice2 = new System.Windows.Forms.Button();
            this.txtDenom2 = new System.Windows.Forms.TextBox();
            this.txtCodice2 = new System.Windows.Forms.TextBox();
            this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
            this.gboxDebito = new System.Windows.Forms.GroupBox();
            this.txtDenomCausaleDebito = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleDebito = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGeneraEP = new System.Windows.Forms.Button();
            this.gboxCosto = new System.Windows.Forms.GroupBox();
            this.txtDenomCausaleCosto = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleCosto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnVisualizzaEP = new System.Windows.Forms.Button();
            this.labEP = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtFineCompetenza = new System.Windows.Forms.TextBox();
            this.txtInizioCompetenza = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabFinanziamenti = new System.Windows.Forms.TabPage();
            this.txtTotFinanziato = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dgridFinanziamenti = new System.Windows.Forms.DataGrid();
            this.btnDelFinanziamenti = new System.Windows.Forms.Button();
            this.btnEditFinanziamenti = new System.Windows.Forms.Button();
            this.btnInsertFinanziamenti = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabOpfondops.SuspendLayout();
            this.tabOperazione.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
            this.gboxImporto.SuspendLayout();
            this.gboxBolletta.SuspendLayout();
            this.grpNList.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gboxCurrAmount.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxreintegro.SuspendLayout();
            this.grpTipoSpesa.SuspendLayout();
            this.grpTipoOperazione.SuspendLayout();
            this.grpOperazione.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gboxDocumento.SuspendLayout();
            this.grpBilancio.SuspendLayout();
            this.gboxSpesa.SuspendLayout();
            this.tabClassSup.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).BeginInit();
            this.tabMovimenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPSMovEntrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPSMovSpesa)).BeginInit();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.tabAnalitico.SuspendLayout();
            this.gboxAnalitico.SuspendLayout();
            this.grpBoxSiopeEP.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.gboxDebito.SuspendLayout();
            this.gboxCosto.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabFinanziamenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridFinanziamenti)).BeginInit();
            this.SuspendLayout();
            // 
            // tabOpfondops
            // 
            this.tabOpfondops.Controls.Add(this.tabOperazione);
            this.tabOpfondops.Controls.Add(this.tabClassSup);
            this.tabOpfondops.Controls.Add(this.tabMovimenti);
            this.tabOpfondops.Controls.Add(this.tabAttributi);
            this.tabOpfondops.Controls.Add(this.tabAnalitico);
            this.tabOpfondops.Controls.Add(this.tabFinanziamenti);
            this.tabOpfondops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOpfondops.ImageList = this.imageList1;
            this.tabOpfondops.Location = new System.Drawing.Point(0, 0);
            this.tabOpfondops.Name = "tabOpfondops";
            this.tabOpfondops.SelectedIndex = 0;
            this.tabOpfondops.Size = new System.Drawing.Size(955, 520);
            this.tabOpfondops.TabIndex = 0;
            this.tabOpfondops.SelectedIndexChanged += new System.EventHandler(this.tabClassSup_Enter);
            // 
            // tabOperazione
            // 
            this.tabOperazione.Controls.Add(this.gboxUPB);
            this.tabOperazione.Controls.Add(this.gboxResponsabile);
            this.tabOperazione.Controls.Add(this.gboxImporto);
            this.tabOperazione.Controls.Add(this.gboxBolletta);
            this.tabOperazione.Controls.Add(this.grpNList);
            this.tabOperazione.Controls.Add(this.labelCausale);
            this.tabOperazione.Controls.Add(this.groupBox7);
            this.tabOperazione.Controls.Add(this.gboxCurrAmount);
            this.tabOperazione.Controls.Add(this.groupBox2);
            this.tabOperazione.Controls.Add(this.groupBox1);
            this.tabOperazione.Controls.Add(this.gboxreintegro);
            this.tabOperazione.Controls.Add(this.grpTipoSpesa);
            this.tabOperazione.Controls.Add(this.grpTipoOperazione);
            this.tabOperazione.Controls.Add(this.grpOperazione);
            this.tabOperazione.Controls.Add(this.groupBox3);
            this.tabOperazione.Controls.Add(this.gboxDocumento);
            this.tabOperazione.Controls.Add(this.cmbCausale);
            this.tabOperazione.Controls.Add(this.label5);
            this.tabOperazione.Controls.Add(this.cmbTipoContabilizzazione);
            this.tabOperazione.Controls.Add(this.grpBilancio);
            this.tabOperazione.Controls.Add(this.gboxSpesa);
            this.tabOperazione.Controls.Add(this.chkSpesa);
            this.tabOperazione.Location = new System.Drawing.Point(4, 23);
            this.tabOperazione.Name = "tabOperazione";
            this.tabOperazione.Size = new System.Drawing.Size(947, 493);
            this.tabOperazione.TabIndex = 0;
            this.tabOperazione.Text = "Principale";
            this.tabOperazione.UseVisualStyleBackColor = true;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(8, 114);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(453, 104);
            this.gboxUPB.TabIndex = 6;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 77);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(436, 20);
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
            this.txtDescrUPB.Size = new System.Drawing.Size(269, 62);
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
            this.btnUPBCode.Tag = " manage.upb.tree";
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Location = new System.Drawing.Point(8, 222);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(453, 40);
            this.gboxResponsabile.TabIndex = 7;
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
            this.txtResponsabile.Size = new System.Drawing.Size(442, 20);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // gboxImporto
            // 
            this.gboxImporto.Controls.Add(this.txtImportoCollegato);
            this.gboxImporto.Location = new System.Drawing.Point(221, 392);
            this.gboxImporto.Name = "gboxImporto";
            this.gboxImporto.Size = new System.Drawing.Size(240, 42);
            this.gboxImporto.TabIndex = 76;
            this.gboxImporto.TabStop = false;
            this.gboxImporto.Text = "Totale movimenti collegati";
            // 
            // txtImportoCollegato
            // 
            this.txtImportoCollegato.Location = new System.Drawing.Point(103, 14);
            this.txtImportoCollegato.Name = "txtImportoCollegato";
            this.txtImportoCollegato.ReadOnly = true;
            this.txtImportoCollegato.Size = new System.Drawing.Size(128, 20);
            this.txtImportoCollegato.TabIndex = 11;
            this.txtImportoCollegato.TabStop = false;
            this.txtImportoCollegato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gboxBolletta
            // 
            this.gboxBolletta.Controls.Add(this.txtBolletta);
            this.gboxBolletta.Controls.Add(this.btnBolletta);
            this.gboxBolletta.Location = new System.Drawing.Point(476, 435);
            this.gboxBolletta.Name = "gboxBolletta";
            this.gboxBolletta.Size = new System.Drawing.Size(201, 46);
            this.gboxBolletta.TabIndex = 17;
            this.gboxBolletta.TabStop = false;
            this.gboxBolletta.Tag = "AutoChoose.txtBolletta.spesa.(active=\'S\')";
            // 
            // txtBolletta
            // 
            this.txtBolletta.Location = new System.Drawing.Point(104, 12);
            this.txtBolletta.Name = "txtBolletta";
            this.txtBolletta.Size = new System.Drawing.Size(86, 20);
            this.txtBolletta.TabIndex = 1;
            this.txtBolletta.Tag = "bill.nbill?pettycashoperationview.nbill";
            // 
            // btnBolletta
            // 
            this.btnBolletta.Location = new System.Drawing.Point(8, 12);
            this.btnBolletta.Name = "btnBolletta";
            this.btnBolletta.Size = new System.Drawing.Size(88, 23);
            this.btnBolletta.TabIndex = 0;
            this.btnBolletta.TabStop = false;
            this.btnBolletta.Tag = "choose.bill.spesa.(active=\'S\')";
            this.btnBolletta.Text = "N. bolletta";
            this.btnBolletta.Click += new System.EventHandler(this.btnBolletta_Click);
            // 
            // grpNList
            // 
            this.grpNList.Controls.Add(this.txtNList);
            this.grpNList.Controls.Add(this.label11);
            this.grpNList.Location = new System.Drawing.Point(683, 435);
            this.grpNList.Name = "grpNList";
            this.grpNList.Size = new System.Drawing.Size(196, 46);
            this.grpNList.TabIndex = 18;
            this.grpNList.TabStop = false;
            this.grpNList.Text = "Nota Spese";
            // 
            // txtNList
            // 
            this.txtNList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNList.Location = new System.Drawing.Point(53, 14);
            this.txtNList.Name = "txtNList";
            this.txtNList.Size = new System.Drawing.Size(113, 20);
            this.txtNList.TabIndex = 6;
            this.txtNList.Tag = "pettycashoperation.nlist";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Num.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCausale
            // 
            this.labelCausale.Location = new System.Drawing.Point(490, 144);
            this.labelCausale.Name = "labelCausale";
            this.labelCausale.Size = new System.Drawing.Size(64, 16);
            this.labelCausale.TabIndex = 73;
            this.labelCausale.Text = "Causale";
            this.labelCausale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtDataContabile);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Location = new System.Drawing.Point(8, 392);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(191, 40);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Data";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDataContabile.Location = new System.Drawing.Point(68, 14);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(96, 20);
            this.txtDataContabile.TabIndex = 1;
            this.txtDataContabile.Tag = "pettycashoperation.adate";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Contabile:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxCurrAmount
            // 
            this.gboxCurrAmount.Controls.Add(this.txtImporto);
            this.gboxCurrAmount.Location = new System.Drawing.Point(8, 80);
            this.gboxCurrAmount.Name = "gboxCurrAmount";
            this.gboxCurrAmount.Size = new System.Drawing.Size(312, 32);
            this.gboxCurrAmount.TabIndex = 5;
            this.gboxCurrAmount.TabStop = false;
            this.gboxCurrAmount.Text = "Importo";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(160, 8);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(144, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.Tag = "pettycashoperation.amount";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtDescrizione);
            this.groupBox2.Location = new System.Drawing.Point(327, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 72);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(596, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "pettycashoperation.description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFondoPS);
            this.groupBox1.Location = new System.Drawing.Point(8, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 40);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fondo Economale";
            // 
            // cmbFondoPS
            // 
            this.cmbFondoPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFondoPS.DataSource = this.DS.pettycash;
            this.cmbFondoPS.DisplayMember = "description";
            this.cmbFondoPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFondoPS.Location = new System.Drawing.Point(8, 16);
            this.cmbFondoPS.Name = "cmbFondoPS";
            this.cmbFondoPS.Size = new System.Drawing.Size(296, 21);
            this.cmbFondoPS.TabIndex = 1;
            this.cmbFondoPS.Tag = "pettycashoperation.idpettycash";
            this.cmbFondoPS.ValueMember = "idpettycash";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // gboxreintegro
            // 
            this.gboxreintegro.Controls.Add(this.textBox3);
            this.gboxreintegro.Controls.Add(this.label15);
            this.gboxreintegro.Controls.Add(this.textBox1);
            this.gboxreintegro.Controls.Add(this.label14);
            this.gboxreintegro.Location = new System.Drawing.Point(8, 435);
            this.gboxreintegro.Name = "gboxreintegro";
            this.gboxreintegro.Size = new System.Drawing.Size(270, 48);
            this.gboxreintegro.TabIndex = 10;
            this.gboxreintegro.TabStop = false;
            this.gboxreintegro.Text = "Reintegro";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(170, 20);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 24;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "pettycashoperation.nrestore";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(116, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 16);
            this.label15.TabIndex = 23;
            this.label15.Text = "Numero";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(56, 20);
            this.textBox1.TabIndex = 22;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "pettycashoperation.yrestore";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(4, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 21;
            this.label14.Text = "Esercizio";
            // 
            // grpTipoSpesa
            // 
            this.grpTipoSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTipoSpesa.Controls.Add(this.chkDocumentata);
            this.grpTipoSpesa.Location = new System.Drawing.Point(476, 230);
            this.grpTipoSpesa.Name = "grpTipoSpesa";
            this.grpTipoSpesa.Size = new System.Drawing.Size(463, 32);
            this.grpTipoSpesa.TabIndex = 14;
            this.grpTipoSpesa.TabStop = false;
            this.grpTipoSpesa.Text = "Tipo di spesa";
            // 
            // chkDocumentata
            // 
            this.chkDocumentata.Location = new System.Drawing.Point(96, 8);
            this.chkDocumentata.Name = "chkDocumentata";
            this.chkDocumentata.Size = new System.Drawing.Size(136, 16);
            this.chkDocumentata.TabIndex = 1;
            this.chkDocumentata.Tag = "pettycashoperation.flag:4";
            this.chkDocumentata.Text = "Spese Documentate";
            this.chkDocumentata.CheckedChanged += new System.EventHandler(this.chkDocumentata_CheckedChanged);
            // 
            // grpTipoOperazione
            // 
            this.grpTipoOperazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTipoOperazione.Controls.Add(this.chkChiusura);
            this.grpTipoOperazione.Controls.Add(this.chkReintegro);
            this.grpTipoOperazione.Controls.Add(this.chkApertura);
            this.grpTipoOperazione.Controls.Add(this.chkOpSpesa);
            this.grpTipoOperazione.Location = new System.Drawing.Point(327, 3);
            this.grpTipoOperazione.Name = "grpTipoOperazione";
            this.grpTipoOperazione.Size = new System.Drawing.Size(427, 40);
            this.grpTipoOperazione.TabIndex = 2;
            this.grpTipoOperazione.TabStop = false;
            this.grpTipoOperazione.Text = "Tipo dell\'operazione";
            // 
            // chkChiusura
            // 
            this.chkChiusura.AutoSize = true;
            this.chkChiusura.Location = new System.Drawing.Point(259, 14);
            this.chkChiusura.Name = "chkChiusura";
            this.chkChiusura.Size = new System.Drawing.Size(67, 17);
            this.chkChiusura.TabIndex = 3;
            this.chkChiusura.TabStop = false;
            this.chkChiusura.Tag = "pettycashoperation.flag:2";
            this.chkChiusura.Text = "Chiusura";
            this.chkChiusura.UseVisualStyleBackColor = true;
            this.chkChiusura.CheckStateChanged += new System.EventHandler(this.chkChiusura_CheckStateChanged);
            // 
            // chkReintegro
            // 
            this.chkReintegro.AutoSize = true;
            this.chkReintegro.Location = new System.Drawing.Point(183, 14);
            this.chkReintegro.Name = "chkReintegro";
            this.chkReintegro.Size = new System.Drawing.Size(72, 17);
            this.chkReintegro.TabIndex = 2;
            this.chkReintegro.TabStop = false;
            this.chkReintegro.Tag = "pettycashoperation.flag:1";
            this.chkReintegro.Text = "Reintegro";
            this.chkReintegro.UseVisualStyleBackColor = true;
            this.chkReintegro.CheckStateChanged += new System.EventHandler(this.chkReintegro_CheckStateChanged);
            // 
            // chkApertura
            // 
            this.chkApertura.AutoSize = true;
            this.chkApertura.Location = new System.Drawing.Point(110, 14);
            this.chkApertura.Name = "chkApertura";
            this.chkApertura.Size = new System.Drawing.Size(66, 17);
            this.chkApertura.TabIndex = 1;
            this.chkApertura.TabStop = false;
            this.chkApertura.Tag = "pettycashoperation.flag:0";
            this.chkApertura.Text = "Apertura";
            this.chkApertura.UseVisualStyleBackColor = true;
            this.chkApertura.CheckStateChanged += new System.EventHandler(this.chkApertura_CheckStateChanged);
            // 
            // chkOpSpesa
            // 
            this.chkOpSpesa.AutoSize = true;
            this.chkOpSpesa.Location = new System.Drawing.Point(7, 14);
            this.chkOpSpesa.Name = "chkOpSpesa";
            this.chkOpSpesa.Size = new System.Drawing.Size(56, 17);
            this.chkOpSpesa.TabIndex = 0;
            this.chkOpSpesa.TabStop = false;
            this.chkOpSpesa.Tag = "pettycashoperation.flag:3";
            this.chkOpSpesa.Text = "Spesa";
            this.chkOpSpesa.UseVisualStyleBackColor = true;
            this.chkOpSpesa.CheckStateChanged += new System.EventHandler(this.chkOpSpesa_CheckStateChanged);
            // 
            // grpOperazione
            // 
            this.grpOperazione.Controls.Add(this.txtNumOp);
            this.grpOperazione.Controls.Add(this.label3);
            this.grpOperazione.Controls.Add(this.txtEsercOp);
            this.grpOperazione.Controls.Add(this.label2);
            this.grpOperazione.Location = new System.Drawing.Point(8, 0);
            this.grpOperazione.Name = "grpOperazione";
            this.grpOperazione.Size = new System.Drawing.Size(312, 40);
            this.grpOperazione.TabIndex = 1;
            this.grpOperazione.TabStop = false;
            this.grpOperazione.Text = "Operazione";
            // 
            // txtNumOp
            // 
            this.txtNumOp.Location = new System.Drawing.Point(232, 16);
            this.txtNumOp.Name = "txtNumOp";
            this.txtNumOp.Size = new System.Drawing.Size(72, 20);
            this.txtNumOp.TabIndex = 1;
            this.txtNumOp.Tag = "pettycashoperation.noperation";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(184, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercOp
            // 
            this.txtEsercOp.Location = new System.Drawing.Point(128, 16);
            this.txtEsercOp.Name = "txtEsercOp";
            this.txtEsercOp.ReadOnly = true;
            this.txtEsercOp.Size = new System.Drawing.Size(56, 20);
            this.txtEsercOp.TabIndex = 1;
            this.txtEsercOp.TabStop = false;
            this.txtEsercOp.Tag = "pettycashoperation.yoperation";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(64, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtDocumento);
            this.groupBox3.Controls.Add(this.txtDataDoc);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(476, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(463, 56);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Documento collegato";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(144, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Descrizione:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(8, 24);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(208, 20);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.Tag = "pettycashoperation.doc";
            // 
            // txtDataDoc
            // 
            this.txtDataDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataDoc.Location = new System.Drawing.Point(232, 24);
            this.txtDataDoc.Name = "txtDataDoc";
            this.txtDataDoc.Size = new System.Drawing.Size(223, 20);
            this.txtDataDoc.TabIndex = 2;
            this.txtDataDoc.Tag = "pettycashoperation.docdate";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(232, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Data:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gboxDocumento
            // 
            this.gboxDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxDocumento.Controls.Add(this.btnDocumento);
            this.gboxDocumento.Controls.Add(this.labEsercizio);
            this.gboxDocumento.Controls.Add(this.cmbTipoDocumento);
            this.gboxDocumento.Controls.Add(this.txtNumDoc);
            this.gboxDocumento.Controls.Add(this.labNum);
            this.gboxDocumento.Controls.Add(this.txtEsercDoc);
            this.gboxDocumento.Controls.Add(this.labelTipoDocumento);
            this.gboxDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.gboxDocumento.Location = new System.Drawing.Point(476, 166);
            this.gboxDocumento.Name = "gboxDocumento";
            this.gboxDocumento.Size = new System.Drawing.Size(463, 64);
            this.gboxDocumento.TabIndex = 13;
            this.gboxDocumento.TabStop = false;
            this.gboxDocumento.Text = "Documento da contabilizzare";
            // 
            // btnDocumento
            // 
            this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumento.Location = new System.Drawing.Point(8, 40);
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Size = new System.Drawing.Size(120, 20);
            this.btnDocumento.TabIndex = 2;
            this.btnDocumento.TabStop = false;
            this.btnDocumento.Text = "Documento";
            this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
            // 
            // labEsercizio
            // 
            this.labEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEsercizio.Location = new System.Drawing.Point(136, 40);
            this.labEsercizio.Name = "labEsercizio";
            this.labEsercizio.Size = new System.Drawing.Size(48, 16);
            this.labEsercizio.TabIndex = 0;
            this.labEsercizio.Text = "Eserc.";
            this.labEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDocumento.Location = new System.Drawing.Point(72, 16);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(383, 21);
            this.cmbTipoDocumento.TabIndex = 1;
            this.cmbTipoDocumento.Tag = "";
            this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocumentoGenerico_SelectedIndexChanged);
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDoc.Location = new System.Drawing.Point(264, 40);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(191, 20);
            this.txtNumDoc.TabIndex = 4;
            this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
            // 
            // labNum
            // 
            this.labNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNum.Location = new System.Drawing.Point(232, 40);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(32, 16);
            this.labNum.TabIndex = 0;
            this.labNum.Text = "Num.";
            this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(184, 40);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.Size = new System.Drawing.Size(48, 20);
            this.txtEsercDoc.TabIndex = 3;
            this.txtEsercDoc.Leave += new System.EventHandler(this.txtEsercDoc_Leave);
            // 
            // labelTipoDocumento
            // 
            this.labelTipoDocumento.Location = new System.Drawing.Point(40, 16);
            this.labelTipoDocumento.Name = "labelTipoDocumento";
            this.labelTipoDocumento.Size = new System.Drawing.Size(32, 16);
            this.labelTipoDocumento.TabIndex = 0;
            this.labelTipoDocumento.Text = "Tipo";
            this.labelTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCausale
            // 
            this.cmbCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCausale.DataSource = this.DS.tipomovimento;
            this.cmbCausale.DisplayMember = "descrizione";
            this.cmbCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.cmbCausale.ItemHeight = 13;
            this.cmbCausale.Location = new System.Drawing.Point(562, 142);
            this.cmbCausale.Name = "cmbCausale";
            this.cmbCausale.Size = new System.Drawing.Size(369, 21);
            this.cmbCausale.TabIndex = 12;
            this.cmbCausale.ValueMember = "idtipo";
            this.cmbCausale.SelectedIndexChanged += new System.EventHandler(this.cmbCausale_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(498, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 70;
            this.label5.Text = "Tipo contabilizzazione";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoContabilizzazione
            // 
            this.cmbTipoContabilizzazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoContabilizzazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoContabilizzazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.cmbTipoContabilizzazione.ItemHeight = 13;
            this.cmbTipoContabilizzazione.Location = new System.Drawing.Point(626, 118);
            this.cmbTipoContabilizzazione.Name = "cmbTipoContabilizzazione";
            this.cmbTipoContabilizzazione.Size = new System.Drawing.Size(305, 21);
            this.cmbTipoContabilizzazione.TabIndex = 11;
            this.cmbTipoContabilizzazione.SelectedIndexChanged += new System.EventHandler(this.cmbTipoContabilizzazione_SelectedIndexChanged);
            // 
            // grpBilancio
            // 
            this.grpBilancio.Controls.Add(this.chkListTitle);
            this.grpBilancio.Controls.Add(this.chkListManager);
            this.grpBilancio.Controls.Add(this.chkFilterAvailable);
            this.grpBilancio.Controls.Add(this.btnBilancio);
            this.grpBilancio.Controls.Add(this.txtCodiceBilancio);
            this.grpBilancio.Controls.Add(this.txtDenominazioneBilancio);
            this.grpBilancio.Location = new System.Drawing.Point(8, 266);
            this.grpBilancio.Name = "grpBilancio";
            this.grpBilancio.Size = new System.Drawing.Size(453, 120);
            this.grpBilancio.TabIndex = 8;
            this.grpBilancio.TabStop = false;
            this.grpBilancio.Tag = "AutoManage.txtCodiceBilancio.treesupb";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 48);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(156, 16);
            this.chkListTitle.TabIndex = 3;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // chkListManager
            // 
            this.chkListManager.Location = new System.Drawing.Point(8, 32);
            this.chkListManager.Name = "chkListManager";
            this.chkListManager.Size = new System.Drawing.Size(145, 16);
            this.chkListManager.TabIndex = 2;
            this.chkListManager.TabStop = false;
            this.chkListManager.Text = "Elenca per responsabile";
            // 
            // chkFilterAvailable
            // 
            this.chkFilterAvailable.Checked = true;
            this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAvailable.Location = new System.Drawing.Point(8, 16);
            this.chkFilterAvailable.Name = "chkFilterAvailable";
            this.chkFilterAvailable.Size = new System.Drawing.Size(156, 16);
            this.chkFilterAvailable.TabIndex = 1;
            this.chkFilterAvailable.TabStop = false;
            this.chkFilterAvailable.Text = "Filtra per disponibilità";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(8, 64);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(120, 23);
            this.btnBilancio.TabIndex = 4;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio:";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 88);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(439, 20);
            this.txtCodiceBilancio.TabIndex = 5;
            this.txtCodiceBilancio.Tag = "finview.codefin?pettycashoperationview.codefin";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(187, 14);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(260, 68);
            this.txtDenominazioneBilancio.TabIndex = 6;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // gboxSpesa
            // 
            this.gboxSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxSpesa.Controls.Add(this.label7);
            this.gboxSpesa.Controls.Add(this.txtNum);
            this.gboxSpesa.Controls.Add(this.label13);
            this.gboxSpesa.Controls.Add(this.txtEserc);
            this.gboxSpesa.Controls.Add(this.label12);
            this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
            this.gboxSpesa.Controls.Add(this.btnSpesa);
            this.gboxSpesa.Location = new System.Drawing.Point(476, 345);
            this.gboxSpesa.Name = "gboxSpesa";
            this.gboxSpesa.Size = new System.Drawing.Size(463, 86);
            this.gboxSpesa.TabIndex = 16;
            this.gboxSpesa.TabStop = false;
            this.gboxSpesa.Text = "Movimento di Spesa a cui collegare il reintegro";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(48, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Fase";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNum.Location = new System.Drawing.Point(248, 61);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(207, 20);
            this.txtNum.TabIndex = 4;
            this.txtNum.Tag = "";
            this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(208, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Num.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(144, 61);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 3;
            this.txtEserc.Tag = "";
            this.txtEserc.Leave += new System.EventHandler(this.txtEserc_Leave);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(104, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Eserc.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseSpesa
            // 
            this.cmbFaseSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFaseSpesa.DataSource = this.DS.expensephase;
            this.cmbFaseSpesa.DisplayMember = "description";
            this.cmbFaseSpesa.Location = new System.Drawing.Point(96, 37);
            this.cmbFaseSpesa.Name = "cmbFaseSpesa";
            this.cmbFaseSpesa.Size = new System.Drawing.Size(359, 21);
            this.cmbFaseSpesa.TabIndex = 2;
            this.cmbFaseSpesa.Tag = "";
            this.cmbFaseSpesa.ValueMember = "nphase";
            this.cmbFaseSpesa.SelectedIndexChanged += new System.EventHandler(this.cmbFaseSpesa_SelectedIndexChanged);
            // 
            // btnSpesa
            // 
            this.btnSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpesa.Location = new System.Drawing.Point(326, 11);
            this.btnSpesa.Name = "btnSpesa";
            this.btnSpesa.Size = new System.Drawing.Size(128, 23);
            this.btnSpesa.TabIndex = 1;
            this.btnSpesa.TabStop = false;
            this.btnSpesa.Text = "Scegli Movimento";
            this.btnSpesa.Click += new System.EventHandler(this.btnSpesa_Click);
            // 
            // chkSpesa
            // 
            this.chkSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSpesa.Location = new System.Drawing.Point(476, 324);
            this.chkSpesa.Name = "chkSpesa";
            this.chkSpesa.Size = new System.Drawing.Size(347, 16);
            this.chkSpesa.TabIndex = 15;
            this.chkSpesa.Text = "Seleziona  movimento di spesa per reintegro";
            this.chkSpesa.CheckedChanged += new System.EventHandler(this.chkSpesa_CheckedChanged);
            // 
            // tabClassSup
            // 
            this.tabClassSup.Controls.Add(this.btnGeneraClassAutomatiche);
            this.tabClassSup.Controls.Add(this.groupBox5);
            this.tabClassSup.Controls.Add(this.DGridClassificazioni);
            this.tabClassSup.Controls.Add(this.label1);
            this.tabClassSup.ImageIndex = 1;
            this.tabClassSup.Location = new System.Drawing.Point(4, 23);
            this.tabClassSup.Name = "tabClassSup";
            this.tabClassSup.Size = new System.Drawing.Size(947, 493);
            this.tabClassSup.TabIndex = 3;
            this.tabClassSup.Text = "Classificazioni";
            this.tabClassSup.UseVisualStyleBackColor = true;
            // 
            // btnGeneraClassAutomatiche
            // 
            this.btnGeneraClassAutomatiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraClassAutomatiche.Location = new System.Drawing.Point(730, 8);
            this.btnGeneraClassAutomatiche.Name = "btnGeneraClassAutomatiche";
            this.btnGeneraClassAutomatiche.Size = new System.Drawing.Size(192, 23);
            this.btnGeneraClassAutomatiche.TabIndex = 32;
            this.btnGeneraClassAutomatiche.Text = "Genera Classificazioni automatiche";
            this.btnGeneraClassAutomatiche.Click += new System.EventHandler(this.btnGeneraClassAutomatiche_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.DGridDettagliClassificazioni);
            this.groupBox5.Controls.Add(this.btnDelClass);
            this.groupBox5.Controls.Add(this.btnEditClass);
            this.groupBox5.Controls.Add(this.btnInsertClass);
            this.groupBox5.Location = new System.Drawing.Point(5, 178);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(934, 307);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Dettagli Classificazioni";
            // 
            // DGridDettagliClassificazioni
            // 
            this.DGridDettagliClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridDettagliClassificazioni.DataMember = "";
            this.DGridDettagliClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridDettagliClassificazioni.Location = new System.Drawing.Point(8, 56);
            this.DGridDettagliClassificazioni.Name = "DGridDettagliClassificazioni";
            this.DGridDettagliClassificazioni.Size = new System.Drawing.Size(918, 243);
            this.DGridDettagliClassificazioni.TabIndex = 7;
            this.DGridDettagliClassificazioni.Tag = "pettycashoperationsorted.default";
            this.DGridDettagliClassificazioni.DoubleClick += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnDelClass
            // 
            this.btnDelClass.Location = new System.Drawing.Point(184, 24);
            this.btnDelClass.Name = "btnDelClass";
            this.btnDelClass.Size = new System.Drawing.Size(75, 23);
            this.btnDelClass.TabIndex = 6;
            this.btnDelClass.Tag = "delete";
            this.btnDelClass.Text = "Cancella";
            this.btnDelClass.Click += new System.EventHandler(this.btnDelClass_Click);
            // 
            // btnEditClass
            // 
            this.btnEditClass.Location = new System.Drawing.Point(96, 24);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(75, 23);
            this.btnEditClass.TabIndex = 5;
            this.btnEditClass.Tag = "";
            this.btnEditClass.Text = "Correggi";
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnInsertClass
            // 
            this.btnInsertClass.Location = new System.Drawing.Point(8, 24);
            this.btnInsertClass.Name = "btnInsertClass";
            this.btnInsertClass.Size = new System.Drawing.Size(75, 23);
            this.btnInsertClass.TabIndex = 4;
            this.btnInsertClass.Tag = "";
            this.btnInsertClass.Text = "Aggiungi";
            this.btnInsertClass.Click += new System.EventHandler(this.btnInsertClass_Click);
            // 
            // DGridClassificazioni
            // 
            this.DGridClassificazioni.AllowNavigation = false;
            this.DGridClassificazioni.AllowSorting = false;
            this.DGridClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridClassificazioni.DataMember = "";
            this.DGridClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridClassificazioni.Location = new System.Drawing.Point(5, 37);
            this.DGridClassificazioni.Name = "DGridClassificazioni";
            this.DGridClassificazioni.Size = new System.Drawing.Size(926, 135);
            this.DGridClassificazioni.TabIndex = 4;
            this.DGridClassificazioni.Tag = "sortingkind.default";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Classificazioni";
            // 
            // tabMovimenti
            // 
            this.tabMovimenti.Controls.Add(this.dgrPSMovEntrata);
            this.tabMovimenti.Controls.Add(this.dgrPSMovSpesa);
            this.tabMovimenti.Location = new System.Drawing.Point(4, 23);
            this.tabMovimenti.Name = "tabMovimenti";
            this.tabMovimenti.Size = new System.Drawing.Size(947, 493);
            this.tabMovimenti.TabIndex = 2;
            this.tabMovimenti.Text = "Movimenti";
            this.tabMovimenti.UseVisualStyleBackColor = true;
            // 
            // dgrPSMovEntrata
            // 
            this.dgrPSMovEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrPSMovEntrata.DataMember = "";
            this.dgrPSMovEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrPSMovEntrata.Location = new System.Drawing.Point(16, 3);
            this.dgrPSMovEntrata.Name = "dgrPSMovEntrata";
            this.dgrPSMovEntrata.Size = new System.Drawing.Size(928, 482);
            this.dgrPSMovEntrata.TabIndex = 1;
            this.dgrPSMovEntrata.Tag = "pettycashincomeview.lista";
            // 
            // dgrPSMovSpesa
            // 
            this.dgrPSMovSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrPSMovSpesa.DataMember = "";
            this.dgrPSMovSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrPSMovSpesa.Location = new System.Drawing.Point(16, 8);
            this.dgrPSMovSpesa.Name = "dgrPSMovSpesa";
            this.dgrPSMovSpesa.Size = new System.Drawing.Size(923, 477);
            this.dgrPSMovSpesa.TabIndex = 0;
            this.dgrPSMovSpesa.Tag = "pettycashexpenseview.lista";
            // 
            // tabAttributi
            // 
            this.tabAttributi.Controls.Add(this.gboxclass05);
            this.tabAttributi.Controls.Add(this.gboxclass04);
            this.tabAttributi.Controls.Add(this.gboxclass03);
            this.tabAttributi.Controls.Add(this.gboxclass02);
            this.tabAttributi.Controls.Add(this.gboxclass01);
            this.tabAttributi.Location = new System.Drawing.Point(4, 23);
            this.tabAttributi.Name = "tabAttributi";
            this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributi.Size = new System.Drawing.Size(947, 493);
            this.tabAttributi.TabIndex = 5;
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
            this.gboxclass05.Location = new System.Drawing.Point(8, 286);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(653, 64);
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
            this.txtDenom05.Size = new System.Drawing.Size(411, 52);
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
            this.gboxclass04.Location = new System.Drawing.Point(8, 216);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(653, 64);
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
            this.txtDenom04.Size = new System.Drawing.Size(411, 46);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(8, 146);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(653, 64);
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
            this.txtDenom03.Size = new System.Drawing.Size(412, 52);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(8, 76);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(653, 64);
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
            this.txtDenom02.Size = new System.Drawing.Size(412, 52);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(8, 6);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(653, 64);
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
            this.txtDenom01.Size = new System.Drawing.Size(412, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // tabAnalitico
            // 
            this.tabAnalitico.Controls.Add(this.gboxAnalitico);
            this.tabAnalitico.Controls.Add(this.groupBox8);
            this.tabAnalitico.Location = new System.Drawing.Point(4, 23);
            this.tabAnalitico.Name = "tabAnalitico";
            this.tabAnalitico.Size = new System.Drawing.Size(947, 493);
            this.tabAnalitico.TabIndex = 4;
            this.tabAnalitico.Text = "E/P";
            this.tabAnalitico.UseVisualStyleBackColor = true;
            // 
            // gboxAnalitico
            // 
            this.gboxAnalitico.Controls.Add(this.grpBoxSiopeEP);
            this.gboxAnalitico.Controls.Add(this.btnGenPreimpegni);
            this.gboxAnalitico.Controls.Add(this.btnViewPreimpegni);
            this.gboxAnalitico.Controls.Add(this.groupCredDeb);
            this.gboxAnalitico.Controls.Add(this.gboxclass1);
            this.gboxAnalitico.Controls.Add(this.gboxclass3);
            this.gboxAnalitico.Controls.Add(this.btnGeneraEpExp);
            this.gboxAnalitico.Controls.Add(this.gboxclass2);
            this.gboxAnalitico.Controls.Add(this.btnVisualizzaEpExp);
            this.gboxAnalitico.Controls.Add(this.gboxDebito);
            this.gboxAnalitico.Controls.Add(this.btnGeneraEP);
            this.gboxAnalitico.Controls.Add(this.gboxCosto);
            this.gboxAnalitico.Controls.Add(this.btnVisualizzaEP);
            this.gboxAnalitico.Controls.Add(this.labEP);
            this.gboxAnalitico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxAnalitico.Location = new System.Drawing.Point(0, 0);
            this.gboxAnalitico.Name = "gboxAnalitico";
            this.gboxAnalitico.Size = new System.Drawing.Size(947, 493);
            this.gboxAnalitico.TabIndex = 22;
            this.gboxAnalitico.TabStop = false;
            // 
            // grpBoxSiopeEP
            // 
            this.grpBoxSiopeEP.Controls.Add(this.btnSiope);
            this.grpBoxSiopeEP.Controls.Add(this.txtDescSiope);
            this.grpBoxSiopeEP.Controls.Add(this.txtCodSiope);
            this.grpBoxSiopeEP.Location = new System.Drawing.Point(410, 20);
            this.grpBoxSiopeEP.Name = "grpBoxSiopeEP";
            this.grpBoxSiopeEP.Size = new System.Drawing.Size(264, 103);
            this.grpBoxSiopeEP.TabIndex = 50;
            this.grpBoxSiopeEP.TabStop = false;
            this.grpBoxSiopeEP.Tag = "AutoChoose.txtCodSiope.tree";
            this.grpBoxSiopeEP.Text = "Class.SIOPE";
            // 
            // btnSiope
            // 
            this.btnSiope.Location = new System.Drawing.Point(11, 46);
            this.btnSiope.Name = "btnSiope";
            this.btnSiope.Size = new System.Drawing.Size(56, 20);
            this.btnSiope.TabIndex = 10;
            this.btnSiope.Text = "Codice";
            this.btnSiope.UseVisualStyleBackColor = true;
            // 
            // txtDescSiope
            // 
            this.txtDescSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescSiope.Location = new System.Drawing.Point(73, 16);
            this.txtDescSiope.Multiline = true;
            this.txtDescSiope.Name = "txtDescSiope";
            this.txtDescSiope.ReadOnly = true;
            this.txtDescSiope.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescSiope.Size = new System.Drawing.Size(185, 52);
            this.txtDescSiope.TabIndex = 2;
            this.txtDescSiope.Tag = "sorting_siope.description";
            // 
            // txtCodSiope
            // 
            this.txtCodSiope.Location = new System.Drawing.Point(6, 72);
            this.txtCodSiope.Name = "txtCodSiope";
            this.txtCodSiope.ReadOnly = true;
            this.txtCodSiope.Size = new System.Drawing.Size(252, 20);
            this.txtCodSiope.TabIndex = 9;
            this.txtCodSiope.Tag = "sorting_siope.sortcode?x";
            // 
            // btnGenPreimpegni
            // 
            this.btnGenPreimpegni.Location = new System.Drawing.Point(410, 286);
            this.btnGenPreimpegni.Name = "btnGenPreimpegni";
            this.btnGenPreimpegni.Size = new System.Drawing.Size(264, 23);
            this.btnGenPreimpegni.TabIndex = 23;
            this.btnGenPreimpegni.TabStop = false;
            this.btnGenPreimpegni.Text = "Genera Impegni di Budget";
            // 
            // btnViewPreimpegni
            // 
            this.btnViewPreimpegni.Location = new System.Drawing.Point(410, 257);
            this.btnViewPreimpegni.Name = "btnViewPreimpegni";
            this.btnViewPreimpegni.Size = new System.Drawing.Size(264, 23);
            this.btnViewPreimpegni.TabIndex = 22;
            this.btnViewPreimpegni.TabStop = false;
            this.btnViewPreimpegni.Text = "Visualizza preimpegni di Budget";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(404, 315);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(535, 39);
            this.groupCredDeb.TabIndex = 3;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupCredDeb.Text = "Percipiente (da usare per anticipi di varia natura)";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Location = new System.Drawing.Point(6, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(523, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title?x";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(6, 261);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(392, 103);
            this.gboxclass1.TabIndex = 4;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice1.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(6, 48);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(76, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.TabStop = false;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(128, 16);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(256, 55);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice1.Location = new System.Drawing.Point(4, 77);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(380, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(404, 370);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(454, 103);
            this.gboxclass3.TabIndex = 6;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice3.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(9, 48);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(65, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.TabStop = false;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(127, 12);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(318, 59);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice3.Location = new System.Drawing.Point(9, 77);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(436, 20);
            this.txtCodice3.TabIndex = 2;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // btnGeneraEpExp
            // 
            this.btnGeneraEpExp.Location = new System.Drawing.Point(715, 283);
            this.btnGeneraEpExp.Name = "btnGeneraEpExp";
            this.btnGeneraEpExp.Size = new System.Drawing.Size(224, 23);
            this.btnGeneraEpExp.TabIndex = 21;
            this.btnGeneraEpExp.TabStop = false;
            this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(6, 370);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(392, 104);
            this.gboxclass2.TabIndex = 5;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice2.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(8, 47);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(76, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.TabStop = false;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(128, 16);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(256, 56);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice2.Location = new System.Drawing.Point(6, 78);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(378, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // btnVisualizzaEpExp
            // 
            this.btnVisualizzaEpExp.Location = new System.Drawing.Point(715, 254);
            this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
            this.btnVisualizzaEpExp.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEpExp.TabIndex = 20;
            this.btnVisualizzaEpExp.TabStop = false;
            this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
            // 
            // gboxDebito
            // 
            this.gboxDebito.Controls.Add(this.txtDenomCausaleDebito);
            this.gboxDebito.Controls.Add(this.txtCodiceCausaleDebito);
            this.gboxDebito.Controls.Add(this.button1);
            this.gboxDebito.Location = new System.Drawing.Point(6, 145);
            this.gboxDebito.Name = "gboxDebito";
            this.gboxDebito.Size = new System.Drawing.Size(392, 100);
            this.gboxDebito.TabIndex = 2;
            this.gboxDebito.TabStop = false;
            this.gboxDebito.Tag = "AutoManage.txtCodiceCausaleDebito.tree.(in_use=\'S\')";
            this.gboxDebito.Text = "Causale per il debito (da usare per anticipi di varia natura)";
            // 
            // txtDenomCausaleDebito
            // 
            this.txtDenomCausaleDebito.Location = new System.Drawing.Point(120, 16);
            this.txtDenomCausaleDebito.Multiline = true;
            this.txtDenomCausaleDebito.Name = "txtDenomCausaleDebito";
            this.txtDenomCausaleDebito.ReadOnly = true;
            this.txtDenomCausaleDebito.Size = new System.Drawing.Size(264, 50);
            this.txtDenomCausaleDebito.TabIndex = 2;
            this.txtDenomCausaleDebito.TabStop = false;
            this.txtDenomCausaleDebito.Tag = "accmotiveapplied_debit.motive";
            // 
            // txtCodiceCausaleDebito
            // 
            this.txtCodiceCausaleDebito.Location = new System.Drawing.Point(10, 72);
            this.txtCodiceCausaleDebito.Name = "txtCodiceCausaleDebito";
            this.txtCodiceCausaleDebito.Size = new System.Drawing.Size(374, 20);
            this.txtCodiceCausaleDebito.TabIndex = 1;
            this.txtCodiceCausaleDebito.Tag = "accmotiveapplied_debit.codemotive?x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "manage.accmotiveapplied_debit.tree";
            this.button1.Text = "Causale";
            // 
            // btnGeneraEP
            // 
            this.btnGeneraEP.Location = new System.Drawing.Point(411, 197);
            this.btnGeneraEP.Name = "btnGeneraEP";
            this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
            this.btnGeneraEP.TabIndex = 19;
            this.btnGeneraEP.TabStop = false;
            this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
            // 
            // gboxCosto
            // 
            this.gboxCosto.Controls.Add(this.txtDenomCausaleCosto);
            this.gboxCosto.Controls.Add(this.txtCodiceCausaleCosto);
            this.gboxCosto.Controls.Add(this.button2);
            this.gboxCosto.Location = new System.Drawing.Point(6, 20);
            this.gboxCosto.Name = "gboxCosto";
            this.gboxCosto.Size = new System.Drawing.Size(392, 116);
            this.gboxCosto.TabIndex = 1;
            this.gboxCosto.TabStop = false;
            this.gboxCosto.Tag = "AutoManage.txtCodiceCausaleCosto.tree.(in_use=\'S\')";
            this.gboxCosto.Text = "Causale per il costo (se documento non gestito altrove nel programma)";
            // 
            // txtDenomCausaleCosto
            // 
            this.txtDenomCausaleCosto.Location = new System.Drawing.Point(120, 16);
            this.txtDenomCausaleCosto.Multiline = true;
            this.txtDenomCausaleCosto.Name = "txtDenomCausaleCosto";
            this.txtDenomCausaleCosto.ReadOnly = true;
            this.txtDenomCausaleCosto.Size = new System.Drawing.Size(266, 68);
            this.txtDenomCausaleCosto.TabIndex = 2;
            this.txtDenomCausaleCosto.TabStop = false;
            this.txtDenomCausaleCosto.Tag = "accmotiveapplied_cost.motive";
            // 
            // txtCodiceCausaleCosto
            // 
            this.txtCodiceCausaleCosto.Location = new System.Drawing.Point(10, 90);
            this.txtCodiceCausaleCosto.Name = "txtCodiceCausaleCosto";
            this.txtCodiceCausaleCosto.Size = new System.Drawing.Size(376, 20);
            this.txtCodiceCausaleCosto.TabIndex = 1;
            this.txtCodiceCausaleCosto.Tag = "accmotiveapplied_cost.codemotive?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 0;
            this.button2.Tag = "manage.accmotiveapplied_cost.tree";
            this.button2.Text = "Causale";
            // 
            // btnVisualizzaEP
            // 
            this.btnVisualizzaEP.Location = new System.Drawing.Point(410, 168);
            this.btnVisualizzaEP.Name = "btnVisualizzaEP";
            this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEP.TabIndex = 18;
            this.btnVisualizzaEP.TabStop = false;
            this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
            // 
            // labEP
            // 
            this.labEP.Location = new System.Drawing.Point(410, 145);
            this.labEP.Name = "labEP";
            this.labEP.Size = new System.Drawing.Size(383, 20);
            this.labEP.TabIndex = 16;
            this.labEP.Text = "Le scritture in partita doppia sono state generate.";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtFineCompetenza);
            this.groupBox8.Controls.Add(this.txtInizioCompetenza);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Location = new System.Drawing.Point(422, 145);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(177, 80);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Date di Competenza";
            // 
            // txtFineCompetenza
            // 
            this.txtFineCompetenza.Location = new System.Drawing.Point(69, 45);
            this.txtFineCompetenza.Name = "txtFineCompetenza";
            this.txtFineCompetenza.Size = new System.Drawing.Size(100, 20);
            this.txtFineCompetenza.TabIndex = 3;
            this.txtFineCompetenza.Tag = "pettycashoperation.stop";
            // 
            // txtInizioCompetenza
            // 
            this.txtInizioCompetenza.Location = new System.Drawing.Point(69, 16);
            this.txtInizioCompetenza.Name = "txtInizioCompetenza";
            this.txtInizioCompetenza.Size = new System.Drawing.Size(100, 20);
            this.txtInizioCompetenza.TabIndex = 2;
            this.txtInizioCompetenza.Tag = "pettycashoperation.start";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Fine:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Inizio:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabFinanziamenti
            // 
            this.tabFinanziamenti.Controls.Add(this.txtTotFinanziato);
            this.tabFinanziamenti.Controls.Add(this.label22);
            this.tabFinanziamenti.Controls.Add(this.dgridFinanziamenti);
            this.tabFinanziamenti.Controls.Add(this.btnDelFinanziamenti);
            this.tabFinanziamenti.Controls.Add(this.btnEditFinanziamenti);
            this.tabFinanziamenti.Controls.Add(this.btnInsertFinanziamenti);
            this.tabFinanziamenti.Location = new System.Drawing.Point(4, 23);
            this.tabFinanziamenti.Name = "tabFinanziamenti";
            this.tabFinanziamenti.Size = new System.Drawing.Size(947, 493);
            this.tabFinanziamenti.TabIndex = 6;
            this.tabFinanziamenti.Text = "Finanziamenti";
            this.tabFinanziamenti.UseVisualStyleBackColor = true;
            // 
            // txtTotFinanziato
            // 
            this.txtTotFinanziato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotFinanziato.Location = new System.Drawing.Point(791, 16);
            this.txtTotFinanziato.Name = "txtTotFinanziato";
            this.txtTotFinanziato.ReadOnly = true;
            this.txtTotFinanziato.Size = new System.Drawing.Size(133, 20);
            this.txtTotFinanziato.TabIndex = 45;
            this.txtTotFinanziato.TabStop = false;
            this.txtTotFinanziato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(700, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 13);
            this.label22.TabIndex = 44;
            this.label22.Text = "Totale finanziato";
            // 
            // dgridFinanziamenti
            // 
            this.dgridFinanziamenti.AllowNavigation = false;
            this.dgridFinanziamenti.AllowSorting = false;
            this.dgridFinanziamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgridFinanziamenti.DataMember = "";
            this.dgridFinanziamenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgridFinanziamenti.Location = new System.Drawing.Point(5, 42);
            this.dgridFinanziamenti.Name = "dgridFinanziamenti";
            this.dgridFinanziamenti.Size = new System.Drawing.Size(922, 431);
            this.dgridFinanziamenti.TabIndex = 10;
            this.dgridFinanziamenti.Tag = "pettycashoperationunderwriting.lista.detail";
            // 
            // btnDelFinanziamenti
            // 
            this.btnDelFinanziamenti.Location = new System.Drawing.Point(185, 13);
            this.btnDelFinanziamenti.Name = "btnDelFinanziamenti";
            this.btnDelFinanziamenti.Size = new System.Drawing.Size(75, 23);
            this.btnDelFinanziamenti.TabIndex = 9;
            this.btnDelFinanziamenti.Tag = "delete";
            this.btnDelFinanziamenti.Text = "Cancella";
            // 
            // btnEditFinanziamenti
            // 
            this.btnEditFinanziamenti.Location = new System.Drawing.Point(97, 13);
            this.btnEditFinanziamenti.Name = "btnEditFinanziamenti";
            this.btnEditFinanziamenti.Size = new System.Drawing.Size(75, 23);
            this.btnEditFinanziamenti.TabIndex = 8;
            this.btnEditFinanziamenti.Tag = "edit.detail";
            this.btnEditFinanziamenti.Text = "Correggi";
            // 
            // btnInsertFinanziamenti
            // 
            this.btnInsertFinanziamenti.Location = new System.Drawing.Point(9, 13);
            this.btnInsertFinanziamenti.Name = "btnInsertFinanziamenti";
            this.btnInsertFinanziamenti.Size = new System.Drawing.Size(75, 23);
            this.btnInsertFinanziamenti.TabIndex = 7;
            this.btnInsertFinanziamenti.Tag = "insert.detail";
            this.btnInsertFinanziamenti.Text = "Aggiungi";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            // 
            // Frm_pettycashoperation_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(955, 520);
            this.Controls.Add(this.tabOpfondops);
            this.MaximizeBox = false;
            this.Name = "Frm_pettycashoperation_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmopfondopiccolespese";
            this.tabOpfondops.ResumeLayout(false);
            this.tabOperazione.ResumeLayout(false);
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.gboxImporto.ResumeLayout(false);
            this.gboxImporto.PerformLayout();
            this.gboxBolletta.ResumeLayout(false);
            this.gboxBolletta.PerformLayout();
            this.grpNList.ResumeLayout(false);
            this.grpNList.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.gboxCurrAmount.ResumeLayout(false);
            this.gboxCurrAmount.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxreintegro.ResumeLayout(false);
            this.gboxreintegro.PerformLayout();
            this.grpTipoSpesa.ResumeLayout(false);
            this.grpTipoOperazione.ResumeLayout(false);
            this.grpTipoOperazione.PerformLayout();
            this.grpOperazione.ResumeLayout(false);
            this.grpOperazione.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gboxDocumento.ResumeLayout(false);
            this.gboxDocumento.PerformLayout();
            this.grpBilancio.ResumeLayout(false);
            this.grpBilancio.PerformLayout();
            this.gboxSpesa.ResumeLayout(false);
            this.gboxSpesa.PerformLayout();
            this.tabClassSup.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).EndInit();
            this.tabMovimenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrPSMovEntrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPSMovSpesa)).EndInit();
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
            this.tabAnalitico.ResumeLayout(false);
            this.gboxAnalitico.ResumeLayout(false);
            this.grpBoxSiopeEP.ResumeLayout(false);
            this.grpBoxSiopeEP.PerformLayout();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.gboxDebito.ResumeLayout(false);
            this.gboxDebito.PerformLayout();
            this.gboxCosto.ResumeLayout(false);
            this.gboxCosto.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabFinanziamenti.ResumeLayout(false);
            this.tabFinanziamenti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridFinanziamenti)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        int esercizio;
	    private EP_Manager EPM;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
			Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            esercizio = CfgFn.GetNoNullInt32( Meta.GetSys("esercizio"));
            AccMotiveManager AM = new AccMotiveManager(gboxCosto);
            AccMotiveManager AM01 = new AccMotiveManager(gboxDebito);

            string filteresercizio = QHS.CmpEq("ayear", esercizio);
            string filterUPBFinPart = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'),QHS.CmpEq("idupb","0001"));
		    string filterFinPart = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'));
			grpBilancio.Tag+="."+filterUPBFinPart;
			btnBilancio.Tag+="."+filterUPBFinPart;

            GetData.SetSorting(DS.bill, "nbill desc");
            //GetData.SetSorting(DS.billview, "nbill desc");

            string billfilter = QHS.AppAnd(QHS.CmpEq("billkind", 'D'), QHS.CmpEq("ybill", esercizio));
            object idflowchart = Meta.GetSys("idflowchart");
            if (idflowchart != null && idflowchart != DBNull.Value) {
                int flagtreasurer = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("uniconfig", null, "(isnull(flag,0)&1)"));
                if (flagtreasurer != 0)
                    billfilter = QHS.AppAnd(billfilter, QHS.IsNotNull("idtreasurer"));
            }
            GetData.SetStaticFilter(DS.bill, billfilter);
            GetData.SetStaticFilter(DS.billview, billfilter);


			GetData.SetStaticFilter(DS.finview, filterFinPart);
			GetData.CacheTable(DS.config,filteresercizio,null,false);
			GetData.CacheTable(DS.pettycashsetup,filteresercizio,null,false);
			GetData.CacheTable(DS.clawbacksetup,filteresercizio,null,false);
			DataAccess.SetTableForReading(DS.accmotiveapplied_cost,"accmotiveapplied");
			DataAccess.SetTableForReading(DS.accmotiveapplied_debit,"accmotiveapplied");
			GetData.SetStaticFilter(DS.pettycashincomeview,filteresercizio);
			GetData.SetStaticFilter(DS.pettycashexpenseview,filteresercizio);
			GetData.SetStaticFilter(DS.expenseview,filteresercizio);
			GetData.SetSorting(DS.upb,"codeupb");
			DataAccess.SetTableForReading(DS.sorting1,"sorting");
			DataAccess.SetTableForReading(DS.sorting2,"sorting");
			DataAccess.SetTableForReading(DS.sorting3,"sorting");
            GetData.SetSorting(DS.expensephase, "nphase");
            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                       QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))), "nphase", true);
            /*
                        GetData.SetStaticFilter(DS.expensephase, QHC.AppOr(QHC.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                                    QHC.CmpGe("nphase", Meta.GetSys("expensefinphase")))) ;*/

            string filterfasespesa = QHS.IsNotNull("nphaseexpense");
			GetData.CacheTable(DS.sortingkind, filterfasespesa,null,false);
			DS.pettycashoperationsorted.ExtendedProperties["gridmaster"]="sortingkind";

            string filterEpOperationEP = QHC.CmpEq("idepoperation", "fondoeco");
            string filterEpOperationSF = QHC.CmpEq("idepoperation", "fondoeco");
            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperationEP = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationEP, Meta.Conn);
            filterEpOperationSF = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationSF, Meta.Conn);

            GetData.SetStaticFilter(DS.accmotiveapplied_cost, filterEpOperationSF);
            DS.accmotiveapplied_cost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationEP;

			GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationSF);
			DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams]=filterEpOperationEP;

			PostData.MarkAsTemporaryTable(DS.tipomovimento,false);
			GetData.CacheTable(DS.invoicekind,
                QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2))
                , null, true);

            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
                filteresercizio, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow R = tExpSetup.Rows[0];
                object idsorkind1 = R["idsortingkind1"];
                object idsorkind2 = R["idsortingkind2"];
                object idsorkind3 = R["idsortingkind3"];
                CfgFn.SetGBoxClass(this,1, idsorkind1);
                CfgFn.SetGBoxClass(this, 2, idsorkind2);
                CfgFn.SetGBoxClass(this, 3, idsorkind3);
            }
            TipoClassAvailableEvalued = false;

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
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabOpfondops.TabPages.Remove(tabAttributi);
                }
            }
		    EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGenPreimpegni, btnViewPreimpegni, btnGeneraEP,
		        btnVisualizzaEP,
		        labEP, null, "pettycashoperation");
            SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, true, DS.sorting_siope);
        }

        siope_helper SiopeObj;



        object GetCtrlByName(string Name){
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			//if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			//Label L =  (Label) Ctrl.GetValue(this);                        
			//return L;
			return Ctrl.GetValue(this);
		}


        void SetGBoxClass (int num, object sortingkind) {
            if (sortingkind == DBNull.Value) {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                G.Visible = false;
            }
            else {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting" + num.ToString()], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + num.ToString());
                gboxclass.Tag = "AutoManage.txtCodice" + num.ToString() + ".tree." + filter;
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting" + num.ToString() + ".tree." + filter;
                DS.Tables["sorting" + num.ToString()].ExtendedProperties[MetaData.ExtraParams] = sortingkind;
            }
        }

        void SetGBoxClass0(int num, object sortingkind) {
            string nums = num.ToString();
            if (sortingkind == DBNull.Value) {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass0" + nums);
                G.Visible = false;
                ComboBox C = (ComboBox)GetCtrlByName("cmbCodice0" + nums);
                C.Tag = null;
                C.DataSource = null;
            }
            else {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting0" + nums], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass0" + nums);
                Button btnCodice = (Button)GetCtrlByName("btnCodice0" + nums);
                //gboxclass.Tag = "AutoManage.txtCodice0" + nums + ".tree." + filter;
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting0" + nums + ".tree." + filter;
                DS.Tables["sorting0" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }

		public void MetaData_AfterActivation() {
			btnInsertClass.BackColor = formcolors.GridButtonBackColor();
			btnInsertClass.ForeColor = formcolors.GridButtonForeColor();
			btnEditClass.BackColor = formcolors.GridButtonBackColor();
			btnEditClass.ForeColor = formcolors.GridButtonForeColor();
			btnDelClass.BackColor = formcolors.GridButtonBackColor();
			btnDelClass.ForeColor = formcolors.GridButtonForeColor();
            //MetaData.SetDefault(DS.pettycashoperation, "idupb", "0001");
		}

		public void MetaData_AfterClear() {
			ImpostaCheckSpesa();
			grpTipoOperazione.Enabled=true;
			txtImporto.ReadOnly=false;
			EnableDisableDocumenti(chkDocumentata.Checked);			
			txtEsercOp.Text=Meta.GetSys("esercizio").ToString();
			gboxreintegro.Visible=false;
            grpNList.Visible = true;
			if (Meta.IsRealClear) GestioneFasePerDocumentoCollegato();
            CalcTotFinanziamenti();
			grpTipoSpesa.Enabled=true;
			EnableDisable(true);
			txtImportoCollegato.Visible=false;
			gboxImporto.Visible=false;

			lastimportofreshed=Decimal.MinValue;

			if (cmbTipoContabilizzazione.SelectedIndex>0) {
				cmbTipoContabilizzazione.SelectedIndex = 0;
			}
			ResetMissione();
			ResetIva();
			ResetOccasionale();
			ResetProfessionale();

			ClearComboCausale();
			ClearStartFilter();
			AbilitaDisabilitaCreditoreDebitore(true);
            txtImporto.ReadOnly = false;
            TipoClassAvailableEvalued = false;
            txtEserc.Text = "";
            txtNum.Text = "";
            cmbFaseSpesa.SelectedIndex = 0;
            btnBolletta.Tag = "choose.bill.spesa.(active='S')";
		    EPM.mostraEtichette();
            SiopeObj.setCausaleEPCorrente(null);

        }

		void ClearStartFilter(){
			Meta.StartFilter= null;
		}
        void ManageBollettaChange(DataRow Bolletta) {
            if (Meta.IsEmpty) return;
            if (txtDescrizione.Text != "") {
                if (MessageBox.Show("Aggiorno il campo descrizione in base alla Bolletta selezionata?",
                    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    txtDescrizione.Text = Bolletta["motive"].ToString();
            }
            if (txtDescrizione.Text == "") txtDescrizione.Text = Bolletta["motive"].ToString();
            //if (SubEntity_txtImportoMovimento.Text==""){
            decimal impcorrente = CfgFn.GetNoNullDecimal(
                    HelpForm.GetObjectFromString(typeof(decimal), txtImporto.Text,
                                "x.y.c"));

            string filter = QueryCreator.WHERE_KEY_CLAUSE(Bolletta, DataRowVersion.Default, true);
            filter = GetData.MergeFilters(filter,
                "(billkind='D')and(ybill='" + Meta.GetSys("esercizio").ToString() + "')");
            object imp = Meta.Conn.DO_READ_VALUE("billview", filter,
                "isnull(total,0)-isnull(reduction,0)-isnull(covered,0)");

            decimal importo = CfgFn.GetNoNullDecimal(imp);
            if (importo < 0) importo = 0;
            if (importo < impcorrente || impcorrente == 0) {
                SetImporto(importo);
            }
            //}
        }


		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "upb"){
				if (Meta.DrawStateIsDone){
					AggiornaBilancioResponsabile(R);
				}
				string idupb="0001";
				if (R!=null)idupb= R["idupb"].ToString();
				MetaData.AutoInfo AI;
				AI = Meta.GetAutoInfo(txtCodiceBilancio.Name);
				string filter="(idupb='"+idupb+"')";
				if (AI!=null) AI.startfilter=filter;
				DS.finview.ExtendedProperties[MetaData.ExtraParams]= filter;
                TipoClassAvailableEvalued = false;

				return;
			}

            if (T.TableName == "bill") {
                if (R != null) ManageBollettaChange(R);
            }


			if (T.TableName == "finview"){
				if ((Meta.InsertMode || Meta.EditMode)&&(R!=null)){
                    object getman = Meta.GetAutoField(txtResponsabile);
					if ((R["idman"]!=DBNull.Value)&&
                        ((getman == DBNull.Value) ||
                        ((getman != DBNull.Value) &&
                        (getman.ToString() != R["idman"].ToString())
						)
						)
						) {
						if ((getman==DBNull.Value)||
							MessageBox.Show("Cambio il responsabile in base alla voce di bilancio selezionata?",
							"Conferma",MessageBoxButtons.OKCancel)==DialogResult.OK) {
                            Meta.SetAutoField(R["idman"], txtResponsabile);
						}
					}
                }
                TipoClassAvailableEvalued = false;
            }

			if ((T.TableName == "sortingkind")&& Meta.DrawStateIsDone) {				
                ManageTipoClassMovimentiRowChanged(
					GetImportoPerClassificazione(), R);
				return;
			}
			if (T.TableName=="pettycash" && Meta.InsertMode && Meta.DrawStateIsDone){
				foreach(string tabname in new string[]{
														  "pettycashoperationcasualcontract",
														  "pettycashoperationinvoice",
														  "pettycashoperationitineration",
														  "pettycashoperationprofservice",
                                                          "pettycashoperationsorted",}){
					foreach (DataRow RR in DS.Tables[tabname].Select()){
						if (R==null)							
							RR["idpettycash"]=0;
						else {
							RR["idpettycash"]=R["idpettycash"];					
						}
					}
					if (R!=null){
						MetaData.SetDefault(DS.Tables[tabname],"idpettycash",R["idpettycash"]);
					}
					else {
						MetaData.SetDefault(DS.Tables[tabname],"idpettycash","");
					}
				}
																					
			}
			if ((T.TableName=="pettycash")&&(R!=null)) {
				object idpettycash= R["idpettycash"];
                string filterpcash = QHC.CmpEq("idpettycash", idpettycash);
				DataRow []PettyCash= DS.pettycashsetup.Select(filterpcash);
				if (PettyCash.Length!=0){
					DataRow PCash= PettyCash[0];
					object idacc_pettycash=PCash["idacc"];
					bool tabAnalDeveApparire = idacc_pettycash != DBNull.Value;
                    gboxAnalitico.Enabled = tabAnalDeveApparire;
                    //if (!tabAnalDeveApparire && tabOpfondops.TabPages.Contains(tabAnalitico)) {
                    //    tabOpfondops.TabPages.Remove(tabAnalitico);
                    //}
                    //if (tabAnalDeveApparire && !tabOpfondops.TabPages.Contains(tabAnalitico)) {
                    //    tabOpfondops.TabPages.Add(tabAnalitico);
                    //}
				}
			}
            if (T.TableName == "accmotiveapplied_cost") {
                if (!Meta.DrawStateIsDone)
                    return;
                SiopeObj.setCausaleEPCorrente(R?["idaccmotive"]);
                SiopeObj.selectSiope();
            }
        }

         string lastfilterPrev=null;
		DataRow LastPrevRow=null;
		bool CambioUpbPilotato=false;
		void AggiornaBilancioResponsabile(DataRow UPB){
			if (UPB==null) return;
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.pettycashoperation.Rows[0];
           
            if (UPB["idman"] != DBNull.Value) {
                Curr["idman"] = UPB["idman"];
                Meta.SetAutoField(UPB["idman"], txtResponsabile);
            }

            string filterprev = QHS.AppAnd(QHS.CmpEq("ayear", esercizio),
                QHS.CmpEq("finpart", "S"), QHS.CmpEq("idupb", UPB["idupb"]));
			if (filterprev!=lastfilterPrev && (CambioUpbPilotato==false)){
				DataTable Previsione= Meta.Conn.RUN_SELECT("finyearview",
					"idfin,idupb","idfin",filterprev,"2",null,true);
				if ((CambioUpbPilotato==false) && ((Previsione==null) || (Previsione.Rows.Count!=1))) {
					//Valuta se cancellare il capitolo corrente
					DS.finview.Clear();
					Curr["idfin"]=DBNull.Value;
					txtCodiceBilancio.Text="";
					txtDenominazioneBilancio.Text="";
					LastPrevRow=null;
					MetaData_AfterRowSelect(DS.finview, null);
					return;
				}
				lastfilterPrev=filterprev;
				LastPrevRow= Previsione.Rows[0];
			}

			if (LastPrevRow==null) return;			
		
			if (Curr["idfin"].Equals(LastPrevRow["idfin"])) return;
			Curr["idfin"]= LastPrevRow["idfin"];
			DS.finview.Clear();
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.finview, null, 
                QHS.AppAnd(QHS.CmpEq("idupb",UPB["idupb"]),QHS.CmpEq("idfin",Curr["idfin"])),null,true);
			if (DS.finview.Rows.Count>0){
				DataRow Bil = DS.finview.Rows[0];
				txtCodiceBilancio.Text= Bil["codefin"].ToString();
				txtDenominazioneBilancio.Text=Bil["title"].ToString();
				MetaData_AfterRowSelect(DS.finview, Bil);
			}
			else {
				txtCodiceBilancio.Text="";
				txtDenominazioneBilancio.Text="";
				MetaData_AfterRowSelect(DS.finview, null);
			}

		}

		/// <summary>
		/// Abilita/disabilita il checkbox Spesa e la parte di attribuzione bilancio/idspesa
		/// </summary>
		void ImpostaCheckSpesa(){
			if (Meta.IsEmpty){
				EnableDisable(true);
				//gboxNormale.Visible=true;
				gboxUPB.Visible=true;
				grpBilancio.Visible = true;
				gboxResponsabile.Visible = true;
				gboxSpesa.Visible=false;
				chkSpesa.Visible=false;
				return;
			}
			chkSpesa.Visible=true;
			DataRow R = DS.pettycashoperation.Rows[0];
            byte flag = (byte)R["flag"];
            bool isSpesa = (flag & 8) != 0;
            //non è una spesa	
			if (!isSpesa){
				//in questo caso tutta la parte è sempre e comunque disabilitata
				//gboxNormale.Visible=false;
                gboxUPB.Visible = false;
				grpBilancio.Visible = false;
                gboxResponsabile.Visible = false;
				gboxSpesa.Visible=false;
				chkSpesa.Visible=false;
				//foreach (Control C in tabAttribuzione.Controls) C.Enabled=false;
				chkSpesa.Visible=false;				
				return;
			}
			//gboxNormale.Visible=true;
            gboxUPB.Visible = true;
			grpBilancio.Visible = true;
            gboxResponsabile.Visible = true;
			gboxSpesa.Visible=true;
			chkSpesa.Visible=true;

			//E' una spesa
			if (R["yrestore"]!=DBNull.Value) {
				//E' una spesa già reintegrata
				//gboxNormale.Visible=true;
                gboxUPB.Visible = true;
				grpBilancio.Visible = true;
                gboxResponsabile.Visible = true;
				gboxSpesa.Visible=true;
				chkSpesa.Visible=false;			
				DisableAll(); //disabilita tutto
				return;
			}
			chkSpesa.Visible=true;


			if (R["idexp"]!=DBNull.Value) 
				chkSpesa.Checked=true;
			else 
				chkSpesa.Checked=false;
			chkSpesa_CheckedChanged(null,null);
		}

		void EnableDisableClassificazioni(bool enable){
			btnInsertClass.Enabled = enable;
			btnEditClass.Enabled = enable;
			btnDelClass.Enabled = enable;
		}

        void EnableDisableFinanziamenti(bool enable){
            btnInsertFinanziamenti.Enabled = enable;
            btnEditFinanziamenti.Enabled = enable;
            btnDelFinanziamenti.Enabled = enable;
        }
		decimal lastimportofreshed=-1;
		public void MetaData_AfterFill() {
            
            DataRow CurrSorKind = HelpForm.GetLastSelected(DS.sortingkind);
            if (CurrSorKind != null) {
                string f = QHC.CmpEq("!idsorkind", CurrSorKind["idsorkind"]);
                DS.pettycashoperationsorted.ExtendedProperties["CustomParentRelation"] = f;
            }

			if (Meta.FirstFillForThisRow) 
            ImpostaCheckSpesa();
			grpTipoOperazione.Enabled=false;
			
			EnableDisableDocumenti(chkDocumentata.Checked);
            CalcTotFinanziamenti();
			if (DS.pettycashoperation.Rows.Count > 0) {
                byte flag = (byte)DS.pettycashoperation.Rows[0]["flag"];
                bool isSpesa = (flag & 8) !=0;
				if (!isSpesa) {
					EnableDisableClassificazioni(false);
                    //Disabilita l'inserimento del Finanziamento
                    EnableDisableFinanziamenti(false);
				}
				else {
					EnableDisableClassificazioni(true);
                    //Abilita l'inserimento del Finanziamento
                    EnableDisableFinanziamenti(true);
				}
			}

			if (!Meta.InsertMode) {
				//se non si tratta di operazione di spesa
				//disabilita il groupbox "tipo spesa" e i controlli nel tab Attribuzione
				//bool Tipo_Is_Spesa=	(DS.opfondopiccolespese.Rows[0]["tipooperazione"].ToString()=="S");
				//grpTipoSpesa.Enabled= Tipo_Is_Spesa;
				//foreach (Control C in tabAttribuzione.Controls) C.Enabled=Tipo_Is_Spesa;
				// se trattasi di operazione di Apertura/Reintegro/Spesa...
                byte flag = (byte)DS.pettycashoperation.Rows[0]["flag"];
                bool isSpesa        = (flag & 8) != 0;
                bool isApertura     = (flag & 1) != 0;
                bool isReintegro    = (flag & 2) != 0;
                bool isChiusura     = (flag & 4) != 0;
				decimal importo=0;
				if (isSpesa){ 
                    gboxImporto.Visible = false;
					txtImportoCollegato.Visible=false;
					gboxreintegro.Visible=true;
                    VisualizzaMovimentoPerReintegro();
                    grpNList.Visible = true;
				}
                if (isApertura) {
                    gboxImporto.Text = "Totale movimenti di spesa collegati:";
                    gboxImporto.Visible = true;
					txtImportoCollegato.Visible=true;
					gboxreintegro.Visible=false;
                    grpNList.Visible = false;
				}
                if (isReintegro) {
                    gboxImporto.Text = "Totale operazioni reintegrate:";
                    gboxImporto.Visible = true;
					txtImportoCollegato.Visible=true;
					gboxreintegro.Visible=false;
                    grpNList.Visible = false;
                }
                if (isChiusura){
                    gboxImporto.Text = "Totale movimenti di entrata collegati:";
                    gboxImporto.Visible = true;
					txtImportoCollegato.Visible=true;
					gboxreintegro.Visible=false;
                    grpNList.Visible = false;
				}
                if ((isSpesa) || (isApertura) || (isReintegro)) {
                    if (!isSpesa) dgrPSMovSpesa.Visible = true;
					else dgrPSMovSpesa.Visible=false;
					dgrPSMovEntrata.Visible=false;
					importo=CalcolaImporto(DS.pettycashexpenseview);
					txtImportoCollegato.Text=importo.ToString("C");
				}
					//... se invece trattasi di chiusura...
				else {
					dgrPSMovSpesa.Visible=false;
					dgrPSMovEntrata.Visible=true;
					txtImportoCollegato.Text=CalcolaImporto(DS.pettycashincomeview).ToString("C");
				}			   
			}

			
			if ((MissionLinkedMustBeEvalued==false)&&(MissionLinked!=null) &&
				(MissionLinked.RowState==DataRowState.Detached)){
				if (DS.itineration.Rows.Count>0){
					MissionLinked= DS.itineration.Rows[0];
					MissioneMovSpesaLinked=DS.pettycashoperationitineration.Rows[0];
				}
				else 
					ResetMissione();
			}
			if ((OccasionaleLinkedMustBeEvalued==false)&&(OccasionaleLinked!=null) &&
				(OccasionaleLinked.RowState==DataRowState.Detached)){
				if (DS.casualcontract.Rows.Count>0){
					OccasionaleLinked= DS.casualcontract.Rows[0];
					OccasionaleMovSpesaLinked= DS.pettycashoperationcasualcontract.Rows[0];
				}
				else 
					ResetOccasionale();
			}

			if ((ProfessionaleLinkedMustBeEvalued==false)&&(ProfessionaleLinked!=null) &&
				(ProfessionaleLinked.RowState==DataRowState.Detached)){
				if (DS.profservice.Rows.Count>0){
					ProfessionaleLinked= DS.profservice.Rows[0];
					ProfessionaleMovSpesaLinked= DS.pettycashoperationprofservice.Rows[0];
				}
				else 
					ResetProfessionale();
			}

			if ((IvaLinkedMustBeEvalued==false)&&(IvaLinked!=null) &&
				(IvaLinked.RowState==DataRowState.Detached)){
				if (DS.invoice.Rows.Count>0){
					IvaLinked= DS.invoice.Rows[0];
					IvaMovSpesaLinked = DS.pettycashoperationinvoice.Rows[0];
				}
				else 
					ResetIva();
			}


			bool MissionWasToLink = MissionLinkedMustBeEvalued;
			RintracciaMissione();
			if (MissionWasToLink) {
				if (MissionLinked!=null){
					CollegaMissione(MissionLinked);
					lastimportofreshed= decimal.MinValue;
					//Implicitely done through UpdateImportoDependencies:
					//if (faseMaxInclusa()) RicalcolaPrestazioneMissione();
				}
			}

			bool IvaWasToLink = IvaLinkedMustBeEvalued;
			RintracciaIva();
			if (IvaWasToLink){
				if (IvaLinked !=null) {
					CollegaIva(IvaLinked);
					lastimportofreshed = decimal.MinValue;
				}
			}

			bool OccasionaleWasToLink = OccasionaleLinkedMustBeEvalued;
			RintracciaOccasionale();
			if (OccasionaleWasToLink){
				if (OccasionaleLinked !=null) {
					CollegaOccasionale(OccasionaleLinked);
					lastimportofreshed = decimal.MinValue;
				}
			}

			bool ProfessionaleWasToLink = ProfessionaleLinkedMustBeEvalued;
			RintracciaProfessionale();
			if (ProfessionaleWasToLink){
				if (ProfessionaleLinked !=null) {
					CollegaProfessionale(ProfessionaleLinked);
					lastimportofreshed = decimal.MinValue;
				}
			}


			AbilitaDisabilitaControlliContabilizzazione(!Meta.EditMode);
			//metaprofiler.StopTimer(handle);
			//handle = metaprofiler.StartTimer("SPESA fase 5");

			if (Meta.EditMode){
				DeduciContabilizzazione();
			}

			if ((!Meta.IsEmpty)&&(lastimportofreshed!=GetImporto())){
				lastimportofreshed= GetImporto();
				//UpdateImportoDependencies();
			}
			//metaprofiler.StopTimer(handle);
			//handle = metaprofiler.StartTimer("SPESA fase 6a");

			if (!Meta.EditMode) GestioneFasePerDocumentoCollegato();
			if (Meta.EditMode) UpdateComboCausale();


			// CONTRATTO OCCASIONALE
			if ((DS.pettycashoperationcasualcontract.Columns["ycon"].DefaultValue!=DBNull.Value)&&
				(DS.pettycashoperationcasualcontract.Columns["ncon"].DefaultValue!=DBNull.Value) &&
				Meta.InsertMode &&
				DS.pettycashoperationcasualcontract.Rows.Count==0 
				) {
				SetContabilizzazione(tipocont.cont_occasionale);
				txtNumDoc.Text= DS.pettycashoperationcasualcontract.Columns["ncon"].DefaultValue.ToString();
				txtEsercDoc.Text= DS.pettycashoperationcasualcontract.Columns["ycon"].DefaultValue.ToString();
				DS.pettycashoperationcasualcontract.Columns["ycon"].DefaultValue=DBNull.Value;
				DS.pettycashoperationcasualcontract.Columns["ncon"].DefaultValue=DBNull.Value;
				btnOccasionale_Click(txtNumDoc,null);
			}

			// CONTRATTO PROFESSIONALE
			if ((DS.pettycashoperationprofservice.Columns["ycon"].DefaultValue!=DBNull.Value)&&
				(DS.pettycashoperationprofservice.Columns["ncon"].DefaultValue!=DBNull.Value) &&
				Meta.InsertMode &&
				DS.pettycashoperationprofservice.Rows.Count==0 
				) {
				SetContabilizzazione(tipocont.cont_professionale);
				txtNumDoc.Text= DS.pettycashoperationprofservice.Columns["ncon"].DefaultValue.ToString();
				txtEsercDoc.Text= DS.pettycashoperationprofservice.Columns["ycon"].DefaultValue.ToString();
				DS.pettycashoperationprofservice.Columns["ycon"].DefaultValue=DBNull.Value;
				DS.pettycashoperationprofservice.Columns["ncon"].DefaultValue=DBNull.Value;
				btnProfessionale_Click(txtNumDoc,null);
			}



			// IVA
			if ((DS.pettycashoperationinvoice.Columns["idinvkind"].DefaultValue!=DBNull.Value) &&
				(DS.pettycashoperationinvoice.Columns["yinv"].DefaultValue!=DBNull.Value)&&
				(DS.pettycashoperationinvoice.Columns["ninv"].DefaultValue!=DBNull.Value) &&
				Meta.InsertMode &&
				DS.pettycashoperationinvoice.Rows.Count==0 
				){
				SetContabilizzazione(tipocont.cont_iva);
				HelpForm.SetComboBoxValue(cmbTipoDocumento, DS.pettycashoperationinvoice.Columns["idinvkind"].DefaultValue);
				txtNumDoc.Text= DS.pettycashoperationinvoice.Columns["ninv"].DefaultValue.ToString();
				txtEsercDoc.Text= DS.pettycashoperationinvoice.Columns["yinv"].DefaultValue.ToString();
				DS.pettycashoperationinvoice.Columns["yinv"].DefaultValue=DBNull.Value;
				DS.pettycashoperationinvoice.Columns["ninv"].DefaultValue=DBNull.Value;
				btnIva_Click(txtNumDoc,null);
			}

			// MISSIONE
			if ((DS.pettycashoperationitineration.Columns["iditineration"].DefaultValue!=DBNull.Value)&&
				Meta.InsertMode &&
				DS.pettycashoperationitineration.Rows.Count==0 
				){
				SetContabilizzazione(tipocont.cont_missione);
                txtNumDoc.Text = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("itineration",
                        "(iditineration=" + QueryCreator.quotedstrvalue(DS.pettycashoperationitineration.Columns["iditineration"].DefaultValue
                         , true) + ")", "nitineration")).ToString();
                txtEsercDoc.Text = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("itineration",
                        "(iditineration=" + QueryCreator.quotedstrvalue(DS.pettycashoperationitineration.Columns["iditineration"].DefaultValue
                            , true) + ")", "yitineration")).ToString();
                DS.pettycashoperationitineration.Columns["iditineration"].DefaultValue = DBNull.Value;
				btnMissione_Click(txtNumDoc,null);

			}
			
            if (Meta.FirstFillForThisRow)
            {
                decimal importoperclassificazione = GetImportoPerClassificazione();
                CalcImpClassMovHeaders(importoperclassificazione);
            }
            // Gestione filtro su partite pendenti
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                btnBolletta.Tag = "choose.bill.spesa.((active='S') AND (isnull(total,0)-isnull(reduction,0)>covered) AND (ISNULL(toregularize,0)>0)) ";
            }

            EPM.mostraEtichette();
            DataRow curr = DS.pettycashoperation.Rows[0];
            SiopeObj.setCausaleEPCorrente(curr["idaccmotive_cost"]);
        }
		
		decimal GetImporto(){
			DataRow R = DS.pettycashoperation.Rows[0];
			if (R["amount"]==DBNull.Value) return 0;
			return Convert.ToDecimal(R["amount"]);
		}


		private decimal CalcolaImporto(DataTable Tabella) {
			if (Tabella.Rows.Count>0) {
				decimal somma=0;
				int maxfase=MetaData.MaxFromColumn(Tabella, "nphase");
				DataRow [] res = Tabella.Select(QHC.CmpEq("nphase",maxfase));
				if (res.Length==0) return 0;
				foreach (DataRow R in res)
					somma+= CfgFn.GetNoNullDecimal(R["curramount"]);
				return somma;
			}
			return 0;
		}

		/// <summary>
		/// Abilito/disabilito i textbox Documento e DataDocumento
		/// </summary>
		/// <param name="enable"></param>
		void EnableDisableDocumenti(bool enable){
			txtDocumento.ReadOnly= !enable;
			txtDataDoc.ReadOnly=!enable;
			if (!enable)txtDocumento.Text="";
			if (!enable)txtDataDoc.Text="";
		}

        private void VisualizzaMovimentoPerReintegro() {
             if (MetaData.Empty(this)) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object idexp = DS.Tables["pettycashoperation"].Rows[0]["idexp"];
            string filter = QHS.CmpEq("idexp",idexp);
            DataTable DT = Conn.RUN_SELECT("expense", "idexp,ymov,nmov,nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEserc.Text = DT.Rows[0]["ymov"].ToString();
            txtNum.Text = DT.Rows[0]["nmov"].ToString();
            cambioFasePilotato = true;
            cmbFaseSpesa.SelectedValue = DT.Rows[0]["nphase"];
            cambioFasePilotato = false;
        }

        private void btnSpesa_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty)return;
			Meta.GetFormData(true);

			DataRow Curr=DS.pettycashoperation.Rows[0];
            object idpettycash = Curr["idpettycash"];
            if (idpettycash.ToString() == "0") {
                MessageBox.Show("Selezionare prima il fondo economale.");
                return;
            }
            string filterpcash = QHC.CmpEq("idpettycash", idpettycash);
            DataRow[] PettyCash = DS.pettycashsetup.Select(filterpcash);
            if (PettyCash.Length == 0) {
                MessageBox.Show("Non è stata inserita la configuraz. del fondo economale per quest'anno");
                return;
            }
            
            object idpettycashreg = PettyCash[0]["registrymanager"];//          Meta.Conn.DO_READ_VALUE("pettycashsetup", filterpcash, "registrymanager");
            string filterreg = QHS.NullOrEq("idreg", idpettycashreg);
			decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);
            string filter = "";
            int selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            if (selectedfase > 0) {
                filter = QHS.AppAnd(filter, filterreg, QHS.CmpEq("nphase", selectedfase));
            }
            else {
                  filter = QHS.AppAnd(filter,  
                             QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                                        filterreg,
                                        QHS.CmpGe("nphase", Meta.GetSys("expensefinphase")) 
                                        ));
            }
            int ymov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
            int nmov = CfgFn.GetNoNullInt32(txtNum.Text.Trim());
            if (importo > 0) filter = QHS.AppAnd(filter, QHS.CmpGe("available", importo));
            if ((ymov != 0) && (nmov != 0)) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov));
            }
            else {
                FrmAskInfo F = new FrmAskInfo(Meta, "S", true)
                    //.SetManager(DBNull.Value)
                    //.SetUPB(idupb)
                           .EnableFilterAvailable(importo)
                           .EnableUPBSelection(true)
                           .AllowNoFinSelection(true)
                           .AllowNoFinSelection(true)
                           .AllowNoManagerSelection(true);
                          




                //FrmAskFase F = new FrmAskFase("S", importo, DS.manager, DS.upb, DS.finview, Meta.Dispatcher, Meta.Conn);
                if (F.ShowDialog() != DialogResult.OK) return;

                if (ymov != 0) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
                }
                if ((nmov != 0)) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
                }
                // Aggiunta filtro dell'UPB e del Bilancio
                    if (F.GetUPB() != DBNull.Value && F.GetUPB()!=null) {
                        filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", F.GetUPB()));
                    }
                    if (F.GetFin() != DBNull.Value && F.GetFin()!=null) {
                        filter = QHS.AppAnd(filter, QHS.CmpEq("idfin", F.GetFin()));
                    }
                
               
                if (F.GetManager() != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idman",F.GetManager()));
                }
            }
           
			MetaData E = Meta.Dispatcher.Get("expense");
			E.FilterLocked=true;
			E.DS= DS.Clone();
			DataRow Choosen  = E.SelectOne("default",filter,"expense",null);
			if (Choosen==null) return;
            int oldIdExp =  CfgFn.GetNoNullInt32(Curr["idexp"]);
            int newIdExp  = CfgFn.GetNoNullInt32(Choosen["idexp"]);
			Curr["idexp"] = Choosen["idexp"];
            DS.finview.Clear();
            DS.upb.Clear();
            DS.manager.Clear();
			DS.expenseview.Clear();
			Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview,null,
                QHS.AppAnd(QHS.CmpEq("idexp",Curr["idexp"]),QHS.CmpEq("ayear",esercizio)),
				null,true);
            //DataRow Rexp = DS.expenseview.Rows[0];
            //Meta.SetAutoField(Rexp["idupb"], txtUPB);
            //if (Rexp["idman"] != DBNull.Value) Meta.SetAutoField(Rexp["idman"], txtResponsabile);
            //Meta.SetAutoField(Rexp["idfin"], txtCodiceBilancio);
            //Curr["idfin"] = Choosen["idfin"];
            //Curr["idupb"] = Choosen["idupb"];
            //Curr["idman"] = Choosen["idman"];
            txtEserc.Text = Choosen["ymov"].ToString();
            txtNum.Text = Choosen["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = Choosen["nphase"];
            object NuovoDocumento = Choosen["doc"];
            object NuovoDataDocumento = Choosen["docdate"];
            object NuovoDescrDocumento = Choosen["description"];
            if (oldIdExp != newIdExp) {
                if (MessageBox.Show(this, "Aggiorno i campi descrizione, documento e data documento dell'operazione " +
                         "in base al movimento di spesa selezionato?", "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    if ((NuovoDescrDocumento != null)) {
                        Curr["description"] = NuovoDescrDocumento;
                    }
                    if ((NuovoDocumento != null) && (NuovoDocumento != DBNull.Value)) {
                        Curr["doc"] = NuovoDocumento;
                        Curr["docdate"] = NuovoDataDocumento;
                    }
                    
                }
            }
            ProponiFinanziamenti(Choosen);
			Meta.FreshForm(false);
		}
        object GetFaseCrediti(object idexp) {
            return Meta.Conn.DO_READ_VALUE("expenselink",
                                QHS.AppAnd(QHS.CmpEq("idchild", idexp),
                                        QHS.CmpEq("nlevel", Meta.Conn.GetSys("appropriationphase"))
                                        ), "idparent");
        }

        bool UsaCrediti() {
            if (DS.config.Rows.Count == 0) return false;
            if (DS.config.Rows[0]["flagcredit"].ToString().ToUpper() == "S") return true;
            return false;
        }
        bool UsaCassa() {
            if (DS.config.Rows.Count == 0) return false;
            if (DS.config.Rows[0]["flagproceeds"].ToString().ToUpper() == "S") return true;
            return false;
        }
        bool UsaPrevCompetenza() {
            if (DS.config.Rows.Count == 0) return false;
            int finkind = CfgFn.GetNoNullInt32(DS.config.Rows[0]["fin_kind"]);
            if (finkind == 1 || finkind == 3) return true;
            return false;
        }

        /// <summary>
        /// Assume che sia stata collegata rExpenseView come riga parent
        /// </summary>
        /// <param name="rExpenseView"></param>
        void ProponiFinanziamenti(DataRow rExpenseView) {
            if (Meta.IsEmpty) return;

            DataRow CurrOp = DS.pettycashoperation.Rows[0];

            if (!(UsaCrediti() || UsaPrevCompetenza())) {
                CercaFinanziamento_SolaCassa(rExpenseView);
                return;
            }

            int esercizio = Conn.GetEsercizio();

            string fieldtouse = "paymentsavailable";  // = disp. a pagare
            if (UsaCassa()) {
                fieldtouse = "proceedsavailable"; //incassi disponibili
            }


            object idfin = rExpenseView["idfin"];
            object idupb = rExpenseView["idupb"];


            //Cerca la fase di spesa dell'impegno
            object idFaseCrediti = GetFaseCrediti(rExpenseView["idexp"]);



            DataTable F = Conn.RUN_SELECT("expensecreditproceedsview", "idunderwriting, idupb, idfin, topay,paymentsavailable,proceedsavailable", fieldtouse + " asc",
                    QHS.AppAnd(QHS.CmpEq("idexp", idFaseCrediti),
                            QHS.CmpGt(fieldtouse, 0), QHS.CmpGt("topay", 0)), null, false);
            Conn.RUN_SELECT_INTO_TABLE(F, fieldtouse + " desc",
                        QHS.AppAnd(QHS.CmpEq("idexp", idFaseCrediti),
                                QHS.CmpLe(fieldtouse, 0), QHS.CmpGt("topay", 0)), null, false);

            if (F.Rows.Count == 0) {
                return;
            }


            foreach (DataRow R in DS.pettycashoperationunderwriting.Select())
                R.Delete();

            MetaData MetaUA = Meta.Dispatcher.Get("pettycashoperationunderwriting");

            decimal to_cover = GetImporto(); //prende l'importo corrente



            foreach (DataRow Rf in F.Rows) {
                object idunderwriting_found = Rf["idunderwriting"];
                string filterunderwriting = QHC.CmpEq("idunderwriting", idunderwriting_found);

                DataRow newrow = null;

                decimal available = CfgFn.GetNoNullDecimal(Rf["topay"]);
                if (available == 0) continue;

                //vede se in memoria c'era già una riga con pari idfin e idupb
                if (DS.pettycashoperationunderwriting.Select(filterunderwriting, null, DataViewRowState.Deleted).Length > 0) {
                    DataRow torestore =
                        DS.pettycashoperationunderwriting.Select(filterunderwriting, null,
                            DataViewRowState.Deleted)[0];
                    torestore.RejectChanges();
                    decimal oldval = CfgFn.GetNoNullDecimal(torestore["amount"]);
                    //available += oldval;
                    torestore["amount"] = 0;
                    newrow = torestore;
                }
                else {
                    MetaUA.SetDefaults(DS.pettycashoperationunderwriting);
                    DataRow toadd = MetaUA.Get_New_Row(CurrOp, DS.pettycashoperationunderwriting);
                    toadd["idunderwriting"] = idunderwriting_found;
                    //DS.underwriting.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(DS.underwriting, null, QHS.CmpEq("idunderwriting", idunderwriting_found),
                                            null, false);
                    DataRow Rfound = DS.underwriting.Select(QHC.CmpEq("idunderwriting", idunderwriting_found))[0];
                    toadd["!codeunderwriting"] = Rfound["codeunderwriting"];
                    toadd["!underwriting"] = Rfound["title"];
                    newrow = toadd;
                }

                if (to_cover <= available) {
                    newrow["amount"] = to_cover;
                    to_cover = 0;
                }
                else {
                    newrow["amount"] = available;
                    to_cover -= available;
                }
                if (to_cover == 0) break;
            }


            Meta.FreshForm(false);
        }


        void CercaFinanziamento_SolaCassa(DataRow rExpenseView) {
            if (Meta.IsEmpty) return;
            string fieldtouse = "paymentprevavailable";  // = disp. a pagare
            DataRow CurrOp = DS.pettycashoperation.Rows[0];

            int esercizio = Conn.GetEsercizio();
            object idfin = rExpenseView["idfin"];
            object idupb = rExpenseView["idupb"];

            DataTable F = Conn.RUN_SELECT("upbunderwritingyearview", "*", fieldtouse + " asc",
                        QHS.AppAnd(QHS.CmpEq("idfin", idfin), QHS.CmpEq("idupb", idupb), QHS.CmpGt(fieldtouse, 0)), null, false);
            if (F == null || F.Rows.Count == 0) {
                //MessageBox.Show(this, "Non ci sono finanziamenti per questa coppia progetto-voce di bilancio",
                //    "Informazione");
                return;
            }


            if (DS.pettycashoperationunderwriting.Select().Length > 0) {
                foreach (DataRow todel in DS.pettycashoperationunderwriting.Select()) todel.Delete();
            }

            MetaData MetaUA = Meta.Dispatcher.Get("pettycashoperationunderwriting");

            decimal to_cover = GetImporto(); //prende l'importo corrente


            foreach (DataRow Rf in F.Rows) {
                object idfin_found = Rf["idfin"];
                object idupb_found = Rf["idupb"];
                object idunderwriting_found = Rf["idunderwriting"];
                string filterunderwriting = QHC.CmpEq("idunderwriting", idunderwriting_found);
                DataRow newrow = null;

                decimal available = CfgFn.GetNoNullDecimal(Rf[fieldtouse]);

                //vede se in memoria c'era già una riga con pari idunderwriting
                if (DS.pettycashoperationunderwriting.Select(filterunderwriting, null, DataViewRowState.Deleted).Length > 0) {
                    DataRow torestore =
                        DS.pettycashoperationunderwriting.Select(filterunderwriting, null,
                            DataViewRowState.Deleted)[0];
                    torestore.RejectChanges();
                    decimal oldval = CfgFn.GetNoNullDecimal(torestore["amount"]);
                    //available += oldval;
                    torestore["amount"] = 0;
                    newrow = torestore;
                }
                else {
                    MetaUA.SetDefaults(DS.pettycashoperationunderwriting);
                    DataRow toadd = MetaUA.Get_New_Row(CurrOp, DS.pettycashoperationunderwriting);
                    toadd["idunderwriting"] = idunderwriting_found;
                    Conn.RUN_SELECT_INTO_TABLE(DS.underwriting, null, QHS.CmpEq("idunderwriting", idunderwriting_found),
                                            null, false);
                    DataRow Rfound = DS.underwriting.Select(QHC.CmpEq("idunderwriting", idunderwriting_found))[0];
                    toadd["!codeunderwriting"] = Rfound["codeunderwriting"];
                    toadd["!underwriting"] = Rfound["title"];
                    newrow = toadd;
                }

                if (to_cover <= available) {
                    newrow["amount"] = to_cover;
                    to_cover = 0;
                }
                else {
                    newrow["amount"] = available;
                    to_cover -= available;
                }
                if (to_cover == 0) break;
            }


        }

        //void CorreggiImportiToPay(DataTable CreditiAssegnati) {
        //    foreach (DataRow R in DS.pettycashoperationunderwriting.Rows) {
        //        if (R.RowState == DataRowState.Unchanged) continue;
        //        if (R.RowState == DataRowState.Added) {
        //            FaiSingolaCorrezione(CreditiAssegnati, -CfgFn.GetNoNullDecimal(R["amount"]), R["idunderwriting"]);
        //            continue;
        //        }
        //        if (R.RowState == DataRowState.Deleted) {
        //            FaiSingolaCorrezione(CreditiAssegnati, CfgFn.GetNoNullDecimal(R["amount", DataRowVersion.Original]),
        //                                                            R["idunderwriting", DataRowVersion.Original]);
        //            continue;
        //        }
        //        if (R.RowState == DataRowState.Modified) {
        //            FaiSingolaCorrezione(CreditiAssegnati, CfgFn.GetNoNullDecimal(R["amount"]), R["idunderwriting"]);
        //            FaiSingolaCorrezione(CreditiAssegnati, -CfgFn.GetNoNullDecimal(R["amount", DataRowVersion.Original]),
        //                                            R["idunderwriting"]);
        //            continue;
        //        }


        //    }
        //}





        void CercaFinanziamentoCrediti() {
            if (Meta.IsEmpty) return;

            string fieldtouse = "expenseprevavailable";  // = disp. a impegnare
            if (UsaCrediti()) {
                fieldtouse = "creditavailable"; //crediti disponibili
            }

            Meta.GetFormData(true);
            DataRow CurrOp = DS.pettycashoperation.Rows[0];
            int esercizio = Conn.GetEsercizio();

            object idfin = CurrOp["idfin"];
            object idupb = CurrOp["idupb"];
            if (idfin == DBNull.Value || idupb == DBNull.Value) {
                return;
            }


            DataTable F = Conn.RUN_SELECT("upbunderwritingyearview", "*", fieldtouse + " asc",
                        QHS.AppAnd(QHS.CmpEq("idfin", idfin), QHS.CmpEq("idupb", idupb), QHS.CmpGt(fieldtouse, 0)), null, false);
            if (F == null || F.Rows.Count == 0) {                
                return;
            }

            if (DS.pettycashoperationunderwriting.Select().Length > 0) {

                foreach (DataRow todel in DS.pettycashoperationunderwriting.Select()) todel.Delete();
            }
            MetaData MetaUA = Meta.Dispatcher.Get("pettycashoperationunderwriting");

            decimal to_cover = GetImporto(); //prende l'importo corrente


            foreach (DataRow Rf in F.Rows) {
                object idfin_found = Rf["idfin"];
                object idupb_found = Rf["idupb"];
                object idunderwriting_found = Rf["idunderwriting"];
                string filterunderwriting = QHC.CmpEq("idunderwriting", idunderwriting_found);
                DataRow newrow = null;

                decimal available = CfgFn.GetNoNullDecimal(Rf[fieldtouse]);

                //vede se in memoria c'era già una riga con pari idfin e idupb
                if (DS.pettycashoperationunderwriting.Select(filterunderwriting, null, DataViewRowState.Deleted).Length > 0) {
                    DataRow torestore =
                        DS.pettycashoperationunderwriting.Select(filterunderwriting, null,
                            DataViewRowState.Deleted)[0];
                    torestore.RejectChanges();
                    decimal oldval = CfgFn.GetNoNullDecimal(torestore["amount"]);
                    //available += oldval;
                    torestore["amount"] = 0;
                    newrow = torestore;
                }
                else {
                    MetaUA.SetDefaults(DS.pettycashoperationunderwriting);
                    DataRow toadd = MetaUA.Get_New_Row(CurrOp, DS.pettycashoperationunderwriting);
                    toadd["idunderwriting"] = idunderwriting_found;

                    DataRow Rfound = DS.underwriting.Select(QHC.CmpEq("idunderwriting", idunderwriting_found))[0];
                    toadd["!codeunderwriting"] = Rfound["codeunderwriting"];
                    toadd["!underwriting"] = Rfound["title"];
                    newrow = toadd;
                }

                if (to_cover <= available) {
                    newrow["amount"] = to_cover;
                    to_cover = 0;
                }
                else {
                    newrow["amount"] = available;
                    to_cover -= available;
                }
                if (to_cover == 0) break;
            }

            Meta.FreshForm(false);

        }




		private void chkSpesa_CheckedChanged(object sender, System.EventArgs e) {
			if (chkSpesa.Checked){
				EnableDisable(false);
				if (Meta.IsEmpty) return;
				DataRow R= DS.pettycashoperation.Rows[0];
                object getman = Meta.GetAutoField(txtResponsabile);
				if ((R["idfin"]!=DBNull.Value) ||
					(R["idupb"]!=DBNull.Value) ||
					getman!=DBNull.Value )
					{
					if (MessageBox.Show("Per abilitare la selezione del movimento di spesa è necessario annullare le altre "+
						"attribuzioni su questa operazione. Proseguo?","Conferma",
						MessageBoxButtons.OKCancel)!=DialogResult.OK) {
						chkSpesa.Checked=false;
						return;
					}
					R["idfin"]=DBNull.Value;
					R["idupb"]=DBNull.Value;
					R["idman"]=DBNull.Value;
					DS.finview.Clear();
					txtCodiceBilancio.Text="";
					txtDenominazioneBilancio.Text="";
                    Meta.SetAutoField(DBNull.Value, txtUPB);
                    Meta.SetAutoField(DBNull.Value, txtResponsabile);
					return;
				}
				return;
			}
           
			if (Meta.IsEmpty) return;
			EnableDisable(true);

			DataRow RR= DS.pettycashoperation.Rows[0];

			if ( RR["idexp"]!=DBNull.Value){
				if (MessageBox.Show("Per abilitare la selezione delle attribuzioni normali su questa operazione è necessario annullare il collegamento al movimento di spesa "+
					". Proseguo?","Conferma",
					MessageBoxButtons.OKCancel)!=DialogResult.OK) {
					chkSpesa.Checked=true;
					return;
				}
				RR["idexp"]=DBNull.Value;
				DS.expenseview.Clear();
				cmbFaseSpesa.SelectedIndex=0;
				txtEserc.Text="";
				txtNum.Text="";
			}
           
						
		}

		void DisableAll(){
			EnableDisableParteNormale(false);
			EnableDisableParteSpesa(false);
		}

		void EnableDisableParteSpesa(bool enable){
            txtEserc.ReadOnly = !enable;
            txtNum.ReadOnly = !enable;
            cmbFaseSpesa.SelectedIndex = 0;
            cmbFaseSpesa.Enabled = enable;
            btnSpesa.Enabled = enable;

		}
		void EnableDisableParteNormale(bool enable){
			btnBilancio.Enabled = enable;
			btnUPBCode.Enabled = enable;
			txtUPB.ReadOnly= !enable;
			txtCodiceBilancio.ReadOnly = !enable;
			txtResponsabile.ReadOnly= !enable;
			chkFilterAvailable.Enabled=enable;
			chkListManager.Enabled=enable;
			chkListTitle.Enabled=enable;
		}

		void EnableDisable(bool parteNormale){
			EnableDisableParteNormale(parteNormale);
			EnableDisableParteSpesa(!parteNormale);
		}

        //
        public void RicalcolaTipoClassificazioni (int faseinizio, int fasemovfine, bool forced) {
            if ((!forced) && TipoClassAvailableEvalued) return;
            TipoClassAvailableEvalued = true;

            //Cancella le classmovimenti fuori range
            foreach (DataRow ClassMovRow in DS.sorting.Select()) {
                if (ClassMovRow.RowState == DataRowState.Deleted) continue;
                DataRow[] TipoClassFound = DS.sortingkind.Select(
                    QHC.CmpEq("idsorkind", ClassMovRow["idsorkind"]));
                if (TipoClassFound.Length == 0) {
                    ClassMovRow.Delete();
                    try {
                        ClassMovRow.AcceptChanges();
                    }
                    catch { };
                    continue;
                }
                ClassMovRow.Delete();
                ClassMovRow.AcceptChanges();
            }
            DS.sorting.Clear();
            GetData.ReCache(DS.sortingkind);
            string filtercl = "";

            filtercl = QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                            QHS.NullOrGe("stop", Meta.GetSys("esercizio")));
            Meta.myGetData.DO_GET_TABLE(DS.sortingkind.TableName, filtercl);
            //Cancella i tipoclassmovimenti fuori range
            /*foreach (DataRow TipoClassMovRow in DS.sortingkind.Select()) {
                if (TipoClassMovRow.RowState == DataRowState.Deleted) continue;
                TipoClassMovRow.Delete();
                TipoClassMovRow.AcceptChanges();
            }*/
            CalcTipoClassAllowed(faseinizio, fasemovfine);
        }

        public void CalcTipoClassAllowed (int faseinizio, int fasemovfine) {

            int OldIndex = DGridClassificazioni.CurrentRowIndex;

            DataTable TipoClassAllowed = null;
            DataSet OutDS = null;

            object IDForSP = DBNull.Value;
 
            if (DS.pettycashoperation.Rows.Count == 0) return;
            DataRow Curr = DS.pettycashoperation.Rows[0];
            decimal curramount = CfgFn.GetNoNullDecimal(Curr["amount"]);
 
            string sp_root_tipo = "compute_root_sortingkind_expense";
            for (int i = faseinizio; i <= fasemovfine; i++) {
                //Calls sp_root_tipoclasses_spesa to get roots classes available
                OutDS = Meta.Conn.CallSP(sp_root_tipo,
                    new object[8] {Meta.GetSys("esercizio"),
									   IDForSP,
									   GetIdRegPerFase(Curr,i),
									   GetIdUpbPerFase(Curr,i),
									   i,
									   GetIdFinPerFase(Curr,i),
									   Curr["idman"],
									   curramount
								   });

                if (OutDS == null) continue;
                if (OutDS.Tables.Count == 0) continue;
                if (TipoClassAllowed == null) {
                    TipoClassAllowed = OutDS.Tables[0];
                }
                else {
                    TipoClassAllowed.Clear();
                    QueryCreator.MergeDataTable(TipoClassAllowed, OutDS.Tables[0]);
                }
               // QueryCreator.MergeDataTable(TipoClassAllowed, OutDS.Tables[0]);
            }
            QueryCreator.MergeDataTable(TipoClassAllowed, DS.sortingkind);
            TipoClassAllowed.TableName = "sortingkind";
            HelpForm.SetDataGrid(DGridClassificazioni, TipoClassAllowed);
            if (TipoClassAllowed.Rows.Count > OldIndex) {
                DGridClassificazioni.CurrentRowIndex = OldIndex;
            }
            else {
                if (TipoClassAllowed.Rows.Count > 0)
                    DGridClassificazioni.CurrentRowIndex = 0;
            }

        }
        //

        /*
            expensefinphase	tinyint
            incomefinphase	tinyint
            expenseregphase	tinyint
            incomeregphase	tinyint
        */

        private object GetIdFin(DataRow R) {
            if (CfgFn.GetNoNullDecimal(R["idexp"]) == 0) {
                return CfgFn.GetNoNullInt32(R["idfin"]);
            }
            else {
                string filter = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.CmpEq("idexp", R["idexp"]));
                object idfin  = Meta.Conn.DO_READ_VALUE("expenseyear", filter, "idfin");
                return idfin;
            }
        }

        private object GetIdFinPerFase (DataRow R, int nphase) {
            int faseattivazione = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));
            if (nphase < faseattivazione) return DBNull.Value;
            return GetIdFin(R);
        }

        private object GetIdUpb(DataRow R) {
            if (CfgFn.GetNoNullInt32(R["idexp"]) == 0) {
                return R["idupb"].ToString();
            }
            else {
                string filter = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.CmpEq("idexp",R["idexp"]));
                object idupb = Meta.Conn.DO_READ_VALUE("expenseyear", filter, "idupb");
                return idupb;
            }
        }

        private object GetIdUpbPerFase (DataRow R, int nphase) {
            int faseattivazione = CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase"));
            if (nphase < faseattivazione) return DBNull.Value;
            return GetIdUpb(R);
        }

        private object GetIdReg (DataRow R) {
            if (CfgFn.GetNoNullDecimal(R["idexp"]) == 0) {
                return CfgFn.GetNoNullInt32(R["idreg"]);
            }
            else {
                string filter = QHS.CmpEq("idexp", R["idexp"]);
                object idupb = Meta.Conn.DO_READ_VALUE("expense", filter, "idreg");
                return idupb;
            }
        }

        private object GetIdRegPerFase (DataRow R, int nphase) {
            int faseattivazione = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
            if (nphase < faseattivazione) return DBNull.Value;
            return GetIdReg(R);
        }

		private void btnBilancio_Click(object sender, System.EventArgs e) {
			string filter;

			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitSet("flag", 0));
                //"(idfin like '"+esercizio.ToString().Substring(2)+"S%')";
						
			//Il filtro sull'UPB c'è sempre
            object getupb = Meta.GetAutoField(txtUPB);
            if (getupb!=DBNull.Value) {
                filter = QHS.CmpEq("idupb", getupb);
			}
			else {
                filter = QHS.CmpEq("idupb", "0001");
            }
            filter = QHS.AppAnd(filter, filteridfin);
			
			//Aggiunge eventualmente il filtro sul disponibile
			if (chkFilterAvailable.Checked){
				decimal currval=0;
				
					if (txtImporto.Text.Trim()!=""){
						currval= CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
							typeof(decimal),txtImporto.Text,"x.y.c"));
					}

                    filter = QHS.AppAnd(filter, QHS.CmpGe("availableprevision", currval));
            }

			string filteroperativo= "(idfin in (SELECT idfin from finusable where "+
                QHS.CmpEq("ayear",esercizio)+"))";

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                filter = GetData.MergeFilters(filter, filteroperativo);
            }


            object getman = Meta.GetAutoField(txtResponsabile);
			if (chkListManager.Checked){
                if (getman!=DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idman", getman));
				}
				else {
                    filter = QHS.AppAnd(filter, QHS.IsNull("idman"));
				}
				filter= GetData.MergeFilters(filter,filteroperativo);
				MetaData.DoMainCommand(this,"choose.finview.manager."+filter);
				return;
			}
		    if (chkListTitle.Checked|| chkFilterAvailable.Checked) {
                filter = GetData.MergeFilters(filter, filteroperativo);
                MetaData.DoMainCommand(this, "choose.finview.default." + filter);
		        return;
		    }

		    DS.finview.ExtendedProperties[MetaData.ExtraParams]=filter;
			MetaData.DoMainCommand(this,"manage.finview.treesupb");
		}

		private void tabClassSup_Enter(object sender, System.EventArgs e) {
			if (Meta==null) return;
			if (!Meta.DrawStateIsDone) return;
			if (tabOpfondops.SelectedTab==tabClassSup){
				EnterTabClassificazioni();
			}
		}
        public void MetaData_BeforeRowSelect(DataTable T, DataRow R)
        {
            if (Meta.DrawStateIsDone && T.TableName == "sortingkind") {
                if (R != null) {
                    string f = QHC.CmpEq("!idsorkind", R["idsorkind"]);
                    DS.pettycashoperationsorted.ExtendedProperties["CustomParentRelation"] = f;
                }
            }
        }

		public void MetaData_BeforeFill() {
			CalcolaTotaliClassificazioni();
			if (DS.pettycashoperation.Rows.Count > 0) {
                byte flag = (byte)DS.pettycashoperation.Rows[0]["flag"];
                bool isSpesa = (flag & 8) != 0;
                bool isApertura = (flag & 1) != 0;
                bool isReintegro = (flag & 2) != 0;
                bool isChiusura = (flag & 4) != 0;
		        if (isApertura || isReintegro || isChiusura) {
					Meta.CanInsertCopy = false;
				}
				else 
				{
					Meta.CanInsertCopy = true;
				}
			}
		}

		#region Gestione Classificazioni
		private void btnInsertClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.pettycashoperation.Rows.Count == 0) return;
			Meta.GetFormData(true);
			DataRow Curr = DS.pettycashoperation.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);

			CalcImpClassMovDefaults(importo); 

			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
			if (!res) return;
			if (CurrTipoClass==null) return;
            string filter = QHS.CmpEq("idsorkind", CurrTipoClass["idsorkind"]);
			DataTable ClassMovAllowed = DS.sorting.Clone();
			ClassMovAllowed.Clear();
			Meta.Conn.RUN_SELECT_INTO_TABLE(ClassMovAllowed,null,filter,null,true);
			if (ClassMovAllowed.Rows.Count == 0) return;

			DS.pettycashoperationsorted.ExtendedProperties[MetaData.ExtraParams]= ClassMovAllowed;
			DS.pettycashoperationsorted.ExtendedProperties["importoresiduo"]= Convert.ToDecimal(0);

			DataRow Added = MetaData.Insert_Grid(DGridDettagliClassificazioni, "default");
			if (Added==null) return;

			Meta.FreshForm(true);
		}

		private void btnEditClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.pettycashoperation.Rows.Count == 0) return;
			Meta.GetFormData(true);
			DataRow Curr = DS.pettycashoperation.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);
			CalcImpClassMovDefaults(importo);

			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
			if (!res) return;
			if (CurrTipoClass==null) return;
			DataTable SourceTable;
			DataRow CurrDR;            
			res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni, out SourceTable, out CurrDR);
			if (!res) return;
			if (CurrDR==null) return;

            string filter = QHS.CmpEq("idsorkind", CurrTipoClass["idsorkind"]);
			DataTable ClassMovAllowed = DS.sorting.Clone();
			ClassMovAllowed.Clear();
			Meta.Conn.RUN_SELECT_INTO_TABLE(ClassMovAllowed,null,filter,null,true);
			if (ClassMovAllowed.Rows.Count == 0) return;
			DS.pettycashoperationsorted.ExtendedProperties[MetaData.ExtraParams]= ClassMovAllowed;
			DataRow Modified = MetaData.Edit_Grid(DGridDettagliClassificazioni, "default");
			if (Modified==null) return;

			Meta.FreshForm(true);
		}

		private void btnDelClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.pettycashoperation.Rows.Count == 0) return;
			Meta.GetFormData(true);
			DataRow Curr = DS.pettycashoperation.Rows[0];
			
			DataTable SourceTable;
			DataRow CurrDR;
            
			bool res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni, 
				out SourceTable, out CurrDR);
			if (!res) return ;
			if (CurrDR==null) return;

			
			if (MessageBox.Show(
				"Cancello la classificazione selezionata?",
				"Richiesta di conferma", 
				MessageBoxButtons.YesNo)!=DialogResult.Yes) return;


			DeleteImpClassMov(CurrDR);
			
			HelpForm.SetLastSelected(SourceTable,null);
			Meta.myHelpForm.SetDataRowRelated(DGridClassificazioni.FindForm(), SourceTable, null);
			Meta.myHelpForm.ControlChanged(DGridClassificazioni,null);
			Meta.FreshForm();
		}

		void AbilitaSubMovimenti() {
			RowChange.MarkAsAutoincrement(
				DS.pettycashoperationsorted.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
			RowChange.SetSelector(DS.pettycashoperationsorted, "idpettycash");
			RowChange.SetSelector(DS.pettycashoperationsorted, "yoperation");
			RowChange.SetSelector(DS.pettycashoperationsorted, "noperation");
            //RowChange.SetSelector(DS.pettycashoperationsorted, "idsorkind");
			RowChange.SetSelector(DS.pettycashoperationsorted, "idsor");
		}

		public void CalcImpClassMovDefaults(decimal ImportoPerClassificazione) {
			DataTable T;
			DataRow Curr;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out Curr);
			if (Curr==null)return;

            DS.pettycashoperationsorted.Columns["!idsorkind"].DefaultValue = Curr["idsorkind"];

			AbilitaSubMovimenti();
			DataRow CurrMov = DS.pettycashoperation.Rows[0];
            
            decimal importoclassificato = CfgFn.GetNoNullDecimal(DS.pettycashoperationsorted.Compute("SUM(amount)",
                QHC.CmpEq("!idsorkind", Curr["idsorkind"])));
					
			decimal importototale  = ImportoPerClassificazione;
			decimal importoresiduo = importototale - importoclassificato;

			if (Curr["totalexpression"].ToString()=="")
				DS.pettycashoperationsorted.Columns["amount"].DefaultValue = importoresiduo;
			else 
				DS.pettycashoperationsorted.Columns["amount"].DefaultValue = 0;

			DS.pettycashoperationsorted.ExtendedProperties["importoresiduo"]= importoresiduo;
			DS.pettycashoperationsorted.ExtendedProperties["importototale"]= importototale;
			btnEditClass.Enabled=true;
			btnInsertClass.Enabled=true;
			btnDelClass.Enabled=true;
		}

		/// <summary>
		/// Deletes epexp with all sub-autoclasses
		/// </summary>
		/// <param name="R"></param>
		void DeleteImpClassMov(DataRow R) {
			R.Delete();
		}

		public void EnterTabClassificazioni(){
			if (Meta.IsEmpty) return;
            int maxphase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            RicalcolaTipoClassificazioni(1, maxphase, false);
			CalcolaTotaliClassificazioni();
			SelectTipoClassMovimenti();
		}

		public void ManageTipoClassMovimentiRowChanged(decimal ImportoPerClassificazione,
			DataRow Curr) {
            if (DS.pettycashoperation.Rows.Count == 0) Curr = null;


			if (Curr==null) {
				btnEditClass.Enabled=false;
				btnInsertClass.Enabled=false;
				btnDelClass.Enabled=false;
				return;
			}
            byte flag = (byte)DS.pettycashoperation.Rows[0]["flag"];
            bool isSpesa = (flag & 8) != 0;

            btnEditClass.Enabled = isSpesa;
            btnInsertClass.Enabled = isSpesa;
            btnDelClass.Enabled = isSpesa;
            
			CalcImpClassMovHeaders(ImportoPerClassificazione);
		}

		/// <summary>
		/// Calcs column names of impclassspesa grid and freshes grid
		/// </summary>
		void CalcImpClassMovHeaders(decimal importoperclassificazione) {
			DataTable T;
			DataRow Curr;

			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out Curr);
			if (Curr==null)return;

			RefillDettagliClassificazioni(importoperclassificazione);
		}

		/// <summary>
		/// redraws grid
		/// </summary>
		/// <param name="importoperclassificazione"></param>
		public void RefillDettagliClassificazioni(decimal importoperclassificazione){
			if (Meta.IsEmpty) return;
			DS.pettycashoperationsorted.ExtendedProperties["TotaleImporto"]= importoperclassificazione;
			GetData.CalculateTable(DS.pettycashoperationsorted);
			DGridDettagliClassificazioni.TableStyles.Clear();
			HelpForm.SetGridStyle(DGridDettagliClassificazioni, DS.pettycashoperationsorted);
			if (DGridDettagliClassificazioni.DataSource==null) return;
			formatgrids format = new formatgrids(DGridDettagliClassificazioni);
			format.AutosizeColumnWidth();	
			HelpForm.SetDataGrid(DGridDettagliClassificazioni, DS.pettycashoperationsorted);
		}

		public void CalcolaTotaliClassificazioni(){
			foreach (DataRow TR in DS.sortingkind.Rows) {
				decimal importo=0;
                string filter = QHS.CmpEq("!idsorkind", TR["idsorkind"]); 
				string expression= TR["totalexpression"].ToString();
				if (expression=="")expression="SUM(amount)";
				object importoo = null;
				try {
					importoo= DS.pettycashoperationsorted.Compute(expression,filter);
				}
				catch {
				}
				importo = CfgFn.GetNoNullDecimal(importoo);
				TR["!importo"]=importo;
				TR.AcceptChanges();
			}

		}

		decimal GetImportoPerClassificazione(){
			DataRow R = DS.pettycashoperation.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(R["amount"]);
			return importo;
		}

		public void SelectTipoClassMovimenti(){		
			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out CurrTipoClass);
			if (!res) {
				return;
			}
			if (CurrTipoClass!=null) {
				if (DGridDettagliClassificazioni.DataSource==null)
					Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
				return;
			}
			if (T.Rows.Count==0) {
				return;
			}
			DGridDettagliClassificazioni.CurrentRowIndex=0;
			Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
			res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out CurrTipoClass);
		}
		#endregion



		#region Gestione ComboBox Causali (generico)


		public enum tipocont {cont_none,cont_missione,cont_iva,cont_occasionale,cont_professionale};
		string NomeContabilizzazione(tipocont TIPO){
			switch (TIPO){
				case tipocont.cont_missione: return "Missione";
				case tipocont.cont_iva: return "Documento Iva";
				case tipocont.cont_occasionale: return "Prestazione Occasionale";
				case tipocont.cont_professionale: return "Prestazione Professionale";
				case tipocont.cont_none: return "";
			}
			return null;
		}
		tipocont CodiceContabilizzazione(string nomecont){
			switch(nomecont){
				case "Missione": return tipocont.cont_missione;
				case "Documento Iva": return tipocont.cont_iva;
				case "Prestazione Occasionale": return tipocont.cont_occasionale;
				case "Prestazione Professionale": return tipocont.cont_professionale;
				case "":return tipocont.cont_none;
			}
			return tipocont.cont_none;
		}
		/// <summary>
		/// Svuota la tabella DS.tipomovimento, a cui è agganciato il combo causale
		/// </summary>
		void ClearComboCausale(){
			DataTable TCombo= DS.tipomovimento;
			TCombo.Clear();
			cmbCausale.Enabled=false;
		}

		void EnableTipoMovimento(int IDtipo, string descrtipo){
			DataRow R = DS.tipomovimento.NewRow();
			R["idtipo"]= IDtipo;
			R["descrizione"]= descrtipo;
			DS.tipomovimento.Rows.Add(R);
			DS.tipomovimento.AcceptChanges();
		}

		bool DisabilitaEventiTipoDocumento=false;
		/// <summary>
		/// Restituisce la contabilizzazione selezionata nel combobox cmbTipoContabilizz.
		/// </summary>
		/// <returns></returns>
		tipocont ContabilizzazioneSelezionata(){
			if (cmbTipoContabilizzazione.Items.Count==0) return tipocont.cont_none;
			if (cmbTipoContabilizzazione.SelectedItem == null) return tipocont.cont_none;
			string currTipo = cmbTipoContabilizzazione.SelectedItem.ToString();
			tipocont codecont= CodiceContabilizzazione(currTipo);
			return codecont;
		}
		private void cmbTipoContabilizzazione_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (DisabilitaEventiTipoDocumento)return;
			tipocont codecont = ContabilizzazioneSelezionata();
			AttivaContabilizzazione(codecont);
		}
		
		
		void UpdateComboCausale(){
			if (!Meta.EditMode) return;
			tipocont curr = ContabilizzazioneSelezionata();
			switch (curr){
				case tipocont.cont_missione:
					UpdateComboCausaleMissione();
					break;
				case tipocont.cont_iva:
					UpdateComboCausaleIva();
					break;
				case tipocont.cont_occasionale:
					UpdateComboCausaleOccasionale();
					break;
				case tipocont.cont_professionale:
					UpdateComboCausaleProfessionale();
					break;
			}
		}

		bool ContabilizzazioneAttivabile(tipocont codecont){
			if (codecont== tipocont.cont_none) return false;
			if (Meta.IsEmpty) return true;
			DataRow Curr= DS.pettycashoperation.Rows[0];
            byte flag = (byte)DS.pettycashoperation.Rows[0]["flag"];
            bool isSpesa = (flag & 8) !=0;
            if (isSpesa) return true;
			return false;
		}

		/// <summary>
		/// Imposta il valore del combobox ed aggiorna l'importo del movimento
		/// </summary>
		/// <param name="tipomovimento"></param>
		void SetValueComboCausale(string tipomovimento){
			cmbCausale.SelectedValue= tipomovimento;
			RecalcImporto();
		}

		void RecalcImporto(){
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_missione:
					ReCalcImporto_Missione();
					return;
				case tipocont.cont_iva:
					ReCalcImporto_Iva();
					return;
				case tipocont.cont_occasionale:
					ReCalcImporto_Occasionale();
					return;
				case tipocont.cont_professionale:
					ReCalcImporto_Professionale();
					return;
				case tipocont.cont_none:
					return;

			}
		}


		#endregion


		#region Gestione Documenti Contabilizzazione

		private void cmbCausale_SelectedIndexChanged(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_missione:
					cmbCausaleMissione_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_iva:
					cmbCausaleIva_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_occasionale:
					cmbCausaleOccasionale_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_professionale:
					cmbCausaleProfessionale_SelectedIndexChanged(sender,e);
					break;
			}
		}

		private void btnDocumento_Click(object sender, System.EventArgs e) {
			if (!Meta.IsEmpty) Meta.GetFormData(true);
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_missione:
					btnMissione_Click(sender,e);
					break;
				case tipocont.cont_iva:
					btnIva_Click(sender,e);
					break;
				case tipocont.cont_occasionale:
					btnOccasionale_Click(sender,e);
					break;
				case tipocont.cont_professionale:
					btnProfessionale_Click(sender,e);
					break;
			}
		}

		private void txtEsercDoc_Leave(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_missione:
					txtEsercMissione_Leave(sender,e);
					break;
				case tipocont.cont_iva:
					txtEsercIva_Leave(sender,e);
					break;
				case tipocont.cont_occasionale:
					txtEsercOccasionale_Leave(sender,e);
					break;
				case tipocont.cont_professionale:
					txtEsercProfessionale_Leave(sender,e);
					break;
			}
		}

		bool LeavingtxtNumDoc=false;
		private void txtNumDoc_Leave(object sender, System.EventArgs e) {
            if (!Meta.IsEmpty) Meta.GetFormData(true);
			if (LeavingtxtNumDoc)return;
			LeavingtxtNumDoc=true;
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_missione:
					txtNumMissione_Leave(sender,e);
					break;
				case tipocont.cont_iva:
					txtNumIva_Leave(sender,e);
					break;
				case tipocont.cont_occasionale:
					txtNumOccasionale_Leave(sender,e);
					break;
				case tipocont.cont_professionale:
					txtNumProfessionale_Leave(sender,e);
					break;
			}
			LeavingtxtNumDoc=false;
		}

		private void cmbTipoDocumentoGenerico_SelectedIndexChanged(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					cmbTipoDocumento_SelectedIndexChanged(sender,e);
					break;
			}
		}

		tipocont DeduciTipoContabilizzazione(){
			if (DS.pettycashoperationitineration.Rows.Count>0) return tipocont.cont_missione;
			if (DS.pettycashoperationinvoice.Rows.Count>0) return tipocont.cont_iva;
			if (DS.pettycashoperationcasualcontract.Rows.Count>0) return tipocont.cont_occasionale;
			if (DS.pettycashoperationprofservice.Rows.Count>0) return tipocont.cont_professionale;
			return tipocont.cont_none;
		}


		void DeduciContabilizzazione(){
			tipocont currcont = DeduciTipoContabilizzazione();
			VisualizzaControlliContabilizzazione(currcont);
		
			/// HERE!
			DisabilitaEventiTipoDocumento=true;
			CalcolaContabilizzazioniPossibili();
			SetContabilizzazione(currcont);
			DisabilitaEventiTipoDocumento=false;

			switch (currcont){
				case tipocont.cont_missione:
					SetEditComboCausaleMissione();
					break;

				case tipocont.cont_iva:
					SetEditComboCausaleIva();
					break;

				case tipocont.cont_occasionale:
					SetEditComboCausaleOccasionale();
					break;
			
				case tipocont.cont_professionale:
					SetEditComboCausaleProfessionale();
					break;
			}
						   
			

		}

		/// <summary>
		/// Imposta il combo del tipo contabilizzazione con un valore assegnato
		/// </summary>
		/// <param name="tipo"></param>
		void SetContabilizzazione(tipocont tipo){
			for (int i=0; i< cmbTipoContabilizzazione.Items.Count; i++){
				if (cmbTipoContabilizzazione.Items[i].ToString()== 
					NomeContabilizzazione(tipo)){
					if (cmbTipoContabilizzazione.SelectedIndex!=i){
						if ((i!=0)||(cmbTipoContabilizzazione.SelectedIndex!=-1)){
							cmbTipoContabilizzazione.SelectedIndex=i;
						}
					}

				}
			}
		}

		/// <summary>
		/// Ricalcola il combo delle contabilizzazioni in base alle fasi selezionate,
		///  ed eventualmente scollega i documenti non più collegabili
		/// </summary>
		void GestioneFasePerDocumentoCollegato(){
			DisabilitaEventiTipoDocumento=true;
			tipocont oldcont = ContabilizzazioneSelezionata();
			cmbTipoContabilizzazione.Items.Clear();
			CalcolaContabilizzazioniPossibili();
			if (ContabilizzazioneAttivabile(oldcont)){
				SetContabilizzazione(oldcont);
				VisualizzaControlliContabilizzazione(oldcont);
				DisabilitaEventiTipoDocumento=false;
				cmbTipoContabilizzazione.Enabled=(!Meta.EditMode);
				return;
			}
			cmbTipoContabilizzazione.Enabled=(!Meta.EditMode);
			SetContabilizzazione(tipocont.cont_none);
			AttivaContabilizzazione(tipocont.cont_none);
			DisabilitaEventiTipoDocumento=false;
		}

		void AbilitaDisabilitaControlliContabilizzazione(bool abilita){
			cmbCausale.Enabled= abilita && (!Meta.EditMode);
			cmbTipoDocumento.Enabled= abilita && (!Meta.EditMode);
			btnDocumento.Enabled=abilita && (!Meta.EditMode);
			txtEsercDoc.ReadOnly=(!abilita) || Meta.EditMode;
			txtNumDoc.ReadOnly=(!abilita)||Meta.EditMode;
			cmbTipoContabilizzazione.Enabled=abilita && (!Meta.EditMode);
		}

		void CambiaTagControlliComuni(string tablevista){
            txtBolletta.Tag = "bill.nbill?" + tablevista + ".nbill";
		}

		void AbilitaDisabilitaCreditoreDebitore(bool abilita){
			if (Meta.IsEmpty){
				gboxCosto.Enabled=true;
				gboxDebito.Enabled=true;
				txtCredDeb.ReadOnly=false;
				return;
			}

			if (!abilita){
                txtCredDeb.ReadOnly = true;
				gboxCosto.Enabled=false;
				gboxDebito.Enabled=true;
				return;
			}
			//bool CreditoreAbilitato = true;
			if (!Meta.IsEmpty){
				if (!chkOpSpesa.Checked){
					//CreditoreAbilitato=false;
                    txtCredDeb.ReadOnly = true;
					gboxCosto.Enabled=false;
					gboxDebito.Enabled=false;
                    gboxBolletta.Enabled = false;
				}
				else {
                    txtCredDeb.ReadOnly = false;
					gboxCosto.Enabled=abilita;
					gboxDebito.Enabled=!abilita;
                    gboxBolletta.Enabled = true;
				}	
			}
		}

		/// <summary>
		/// Visualizza/Nasconde i controlli relativi alla contabilizzazione scelta, 
		///  (inclusi btn, txtCredDeb, etc. ) impostandone anche i tag. 
		/// </summary>
		/// <param name="codecont"></param>
		void VisualizzaControlliContabilizzazione(tipocont codecont){
			txtEsercDoc.ReadOnly= Meta.EditMode;
			txtNumDoc.ReadOnly=Meta.EditMode;
			btnDocumento.Enabled= !Meta.EditMode;
			cmbTipoDocumento.Enabled = !Meta.EditMode;

			switch(codecont){
				case tipocont.cont_missione:
					cmbCausale.Visible=true;
					labelCausale.Visible=true;
					gboxDocumento.Visible=true;
					labEsercizio.Text="Eserc.";
					labNum.Text="Num.";

					labelTipoDocumento.Visible=false;
					cmbTipoDocumento.Visible=false;
					btnDocumento.Text="Missione";
					txtEsercDoc.Tag=
						"itineration.yitineration?"+
						"pettycashopitinerationview.yitineration";
					txtNumDoc.Tag="itineration.nitineration?"+
						"pettycashopitinerationview.nitineration";
					cmbTipoDocumento.Tag= null;
					if (Meta.IsEmpty)	{
						AbilitaDisabilitaCreditoreDebitore(true);
					}
					else {
						AbilitaDisabilitaCreditoreDebitore(DS.pettycashoperationitineration.Rows.Count==0);
					}

					break;
				case tipocont.cont_occasionale:
					cmbCausale.Visible=false;
					labelCausale.Visible=false;
					gboxDocumento.Visible=true;
					labEsercizio.Text="Eserc.";
					labNum.Text="Num.";

					labelTipoDocumento.Visible=false;
					cmbTipoDocumento.Visible=false;
					btnDocumento.Text="Contr.Occasionale";
					txtEsercDoc.Tag=
						"pettycashoperationcasualcontract.ycon?"+
						"pettycashopcasualcontractview.ycon";
					txtNumDoc.Tag="pettycashoperationcasualcontract.ncon?"+
						"pettycashopcasualcontractview.ncon";
					cmbTipoDocumento.Tag= null;
					if (Meta.IsEmpty)	{
						AbilitaDisabilitaCreditoreDebitore(true);
                        txtImporto.ReadOnly = false;
					}
					else {
						AbilitaDisabilitaCreditoreDebitore(DS.pettycashoperationcasualcontract.Rows.Count==0);
                        txtImporto.ReadOnly = true;
					}

					break;
				case tipocont.cont_professionale:
					cmbCausale.Visible=true;
					labelCausale.Visible=true;
					gboxDocumento.Visible=true;
					labEsercizio.Text="Eserc.";
					labNum.Text="Num.";

					labelTipoDocumento.Visible=false;
					cmbTipoDocumento.Visible=false;
					btnDocumento.Text="Contr.Professionale";
					txtEsercDoc.Tag=
						"pettycashoperationprofservice.ycon?"+
						"pettycashopprofserviceview.ycon";
					txtNumDoc.Tag="pettycashoperationprofservice.ncon?"+
						"pettycashopprofserviceview.ncon";
					cmbTipoDocumento.Tag= null;

					if (Meta.IsEmpty)	{
						AbilitaDisabilitaCreditoreDebitore(true);
					}
					else {
						AbilitaDisabilitaCreditoreDebitore(DS.pettycashoperationprofservice.Rows.Count==0);
					}

					break;

				case tipocont.cont_iva:
					cmbCausale.Visible=true;
					labelCausale.Visible=true;
					gboxDocumento.Visible=true;
					labEsercizio.Text="Eserc.";
					labNum.Text="Num.";
					txtImporto.ReadOnly = (Meta.EditMode ||Meta.InsertMode);

					labelTipoDocumento.Visible=true;
					cmbTipoDocumento.Visible=true;
					btnDocumento.Text="Documento";
					txtEsercDoc.Tag=
						"pettycashoperationinvoice.yinv?"+
						"pettycashopinvoiceview.yinv";
					txtNumDoc.Tag=
						"pettycashoperationinvoice.ninv?"+
						"pettycashopinvoiceview.ninv";
					cmbTipoDocumento.Tag=
						"pettycashoperationinvoice.idinvkind?"+
						"pettycashopinvoiceview.idinvkind";
					ImpostaComboInvoiceKind();
					if (Meta.IsEmpty)	{
						AbilitaDisabilitaCreditoreDebitore(true);
					}
					else {
						AbilitaDisabilitaCreditoreDebitore(DS.pettycashoperationinvoice.Rows.Count==0);
					}


					break;

				case tipocont.cont_none:
					cmbTipoDocumento.Tag= null;
					txtEsercDoc.Tag=null;
					txtNumDoc.Tag=null;
					NascondiControlliContabilizzazione();
					AbilitaDisabilitaCreditoreDebitore(true);
					break;
			}
		}


		void ImpostaComboInvoiceKind(){
			if (cmbTipoDocumento.DataSource!=null){
				DataTable T = cmbTipoDocumento.DataSource as DataTable;
				if (T.Columns["idinvkind"]!=null) return;
			}
			TipoDocChangePilotato=true;
			cmbTipoDocumento.DataSource = DS.invoicekind;
			cmbTipoDocumento.DisplayMember = "description";
			cmbTipoDocumento.ValueMember = "idinvkind";
			Meta.myHelpForm.PreFillControlsTable(cmbTipoDocumento,null);
			TipoDocChangePilotato=false;
		}


		void NascondiControlliContabilizzazione(){
			if (gboxDocumento.Visible) gboxDocumento.Visible=false;
			if (cmbCausale.Visible) cmbCausale.Visible=false;
			if (labelCausale.Visible) labelCausale.Visible=false;
		}

		public tipocont currcont;


		/// <summary>
		/// Riempie il Combo del tipo di Contabilizzazione con
		///  le scelte possibili in base alla fase corrente
		/// </summary>
		void CalcolaContabilizzazioniPossibili(){
			cmbTipoContabilizzazione.Items.Clear();
			cmbTipoContabilizzazione.Items.Add("");
			foreach (tipocont codecont in new tipocont[] {
															 tipocont.cont_missione, 
															 tipocont.cont_iva,
															 tipocont.cont_occasionale,
															 tipocont.cont_professionale
														 }){			
				if (ContabilizzazioneAttivabile(codecont))
					cmbTipoContabilizzazione.Items.Add(
						NomeContabilizzazione(codecont));
			}																								   
		}
		


		/// <summary>
		/// Funzione chiamata quando cambia il combo delle contabilizzazioni
		/// Disattiva tutte le contabilizzazioni e poi attiva quella indicata.
		/// Scollega qualsiasi documento collegato
		/// </summary>
		/// <param name="codecont"></param>
		void AttivaContabilizzazione(tipocont codecont){
			foreach(tipocont disattivacont in new tipocont[]{
																tipocont.cont_missione, 
																tipocont.cont_iva,
																tipocont.cont_occasionale,	
																tipocont.cont_professionale
															}){
				DisattivaContabilizzazione(disattivacont);
			}
			txtEsercDoc.Text="";
			txtNumDoc.Text="";
			switch(codecont){
				case tipocont.cont_missione:
					CambiaTagControlliComuni("pettycashopitinerationview");
					Meta.DefaultListType="missione";
					break;
				case tipocont.cont_iva:
					CambiaTagControlliComuni("pettycashopinvoiceview");
					Meta.DefaultListType="iva";
					break;
				case tipocont.cont_occasionale:
					CambiaTagControlliComuni("pettycashopcasualcontractview");
					Meta.DefaultListType="occasionale";
					break;
				case tipocont.cont_professionale:
					CambiaTagControlliComuni("pettycashopprofserviceview");
					Meta.DefaultListType="professionale";
					break;
				case tipocont.cont_none:
					CambiaTagControlliComuni("pettycashoperationview");
					Meta.DefaultListType="lista";
					break;
			}
			VisualizzaControlliContabilizzazione(codecont);
			ClearComboCausale();
		}

		void DisattivaContabilizzazione(tipocont codecont){
			if (!Meta.InsertMode) return;
			switch(codecont){
				case tipocont.cont_missione:
					ScollegaMissione();
					return;
				case tipocont.cont_iva:
					ScollegaIva();
					return;
				case tipocont.cont_occasionale:
					ScollegaOccasionale();
					return;
				case tipocont.cont_professionale:
					ScollegaProfessionale();
					return;
			}

		}

		void GetDocMissione(out DataRow MissioneRow, 
			out DataRow CurrMissioneMovSpesaRow,
			out int CurrCausaleMissione){
			CurrCausaleMissione=0;
			DataRow MiddleRow;
			MissioneRow= GetDocRow("itineration","pettycashoperationitineration",out MiddleRow);
			CurrMissioneMovSpesaRow= MiddleRow;
			if (MissioneRow==null)return;
			if (MiddleRow!=null) CurrCausaleMissione= CfgFn.GetNoNullInt32( MiddleRow["movkind"]);
		}


		void GetDocOccasionale(out DataRow OccasionaleRow, 
			out DataRow CurrOccasionaleMovSpesaRow,
			out int CurrCausaleOccasionale){
			CurrCausaleOccasionale=0;
			DataRow MiddleRow;
			OccasionaleRow= GetDocRow("casualcontract","pettycashoperationcasualcontract",out MiddleRow);
			CurrOccasionaleMovSpesaRow= MiddleRow;
			if (OccasionaleRow==null)return;
			if (OccasionaleRow!=null) CurrCausaleOccasionale= 4;
		}

		void GetDocProfessionale(out DataRow ProfessionaleRow, 
			out DataRow CurrProfessionaleMovSpesaRow,
			out int CurrCausaleProfessionale){
			CurrCausaleProfessionale=0;
			DataRow MiddleRow;
			ProfessionaleRow= GetDocRow("profservice","pettycashoperationprofservice",out MiddleRow);
			CurrProfessionaleMovSpesaRow= MiddleRow;
			if (ProfessionaleRow==null)return;
			if (MiddleRow!=null) CurrCausaleProfessionale= 4;
		}

		void GetDocIva(out DataRow IvaRow, 
			out DataRow CurrIvaMovSpesaRow,
			out int CurrCausaleIva){
			CurrCausaleIva=0;
			DataRow MiddleRow;
			IvaRow= GetDocRow("invoice","pettycashoperationinvoice",out MiddleRow);
			CurrIvaMovSpesaRow= MiddleRow;
			if (IvaRow==null)return;
			if (MiddleRow!=null) CurrCausaleIva= 4;
		}


		/// <summary>
		/// Restituisce il documento contabilizzato con il movimento corrente
		/// </summary>
		/// <param name="tablename">nome tabella documento</param>
		/// <param name="middletablename">nome tabella intermedia del DataSet</param>
		/// <param name="faseattivazione">fase di contabilizzazione del documento</param>
		/// <param name="CurrMiddleDocRow">Riga intermedia associata a questo movimento</param>
		/// <returns>Documento contabilizzato dal movimento corrente</returns>
		DataRow GetDocRow(string tablename, string middletablename, 
			out DataRow CurrMiddleDocRow
			){
			CurrMiddleDocRow=null;
			if (Meta.IsEmpty) return null;
			if (DS.Tables[tablename].Rows.Count==0) return null;
			CurrMiddleDocRow= DS.Tables[middletablename].Rows[0];
			return DS.Tables[tablename].Rows[0];
		}
		#endregion

		#region Gestione ComboBox Causale Missione
		decimal totlordo;
		decimal totanticipo;
		decimal contabilizzato_ANPAG;
		decimal contabilizzato_ANGIR;
		decimal contabilizzato_SALDO;
		decimal contabilizzato_VARIAZIONI;

		void SetEditComboCausaleMissione(){
			if (!Meta.EditMode)return;
			ClearComboCausale();
			EnableTipoMovimento(5,"Anticipo della missione su partita di giro");
			EnableTipoMovimento(6,"Anticipo della missione sul capitolo di spesa");
			//EnableTipoMovimento("SALDO","Pagamento o saldo della missione");
			object currtipo = DS.pettycashoperationitineration.Rows[0]["movkind"];
			HelpForm.SetComboBoxValue(cmbCausale, currtipo);
		}

		void UpdateComboCausaleMissione(){
			if (MissioneMovSpesaLinked!=null){
				object currtipo = MissioneMovSpesaLinked["movkind"];
				HelpForm.SetComboBoxValue(cmbCausale, currtipo);
			}
		}


		string lastMissEvalued=null;
		void CalcolaContabilizzatiMissione(DataRow Missione){
			string filtermiss = "(yitineration='"+Missione["yitineration"].ToString()+"')AND"+
				"(nitineration='"+Missione["nitineration"].ToString()+"')";
			decimal totlordo= CfgFn.GetNoNullDecimal(Missione["totalgross"]);

			if (filtermiss==lastMissEvalued) return;
			lastMissEvalued= filtermiss;

			DataTable Residuo = Conn.RUN_SELECT("itinerationresidual","*",null,filtermiss,null,true);

			DataRow CurrResid = Residuo.Rows[0];
			contabilizzato_ANGIR= CfgFn.GetNoNullDecimal(CurrResid["linkedangir"]);
			contabilizzato_ANPAG= CfgFn.GetNoNullDecimal(CurrResid["linkedanpag"]);
			contabilizzato_SALDO= CfgFn.GetNoNullDecimal(CurrResid["linkedsaldo"]);
			decimal residuo = CfgFn.GetNoNullDecimal(CurrResid["residual"]);
			contabilizzato_VARIAZIONI= -(totlordo-residuo-contabilizzato_ANPAG-contabilizzato_SALDO);

		}

		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleMissione(DataRow Missione){
			totlordo= CfgFn.GetNoNullDecimal(Missione["totalgross"]);
			totanticipo =  CfgFn.GetNoNullDecimal(Missione["totadvance"]);

			CalcolaContabilizzatiMissione(Missione);

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;

			if ((Meta.EditMode) || 
				((contabilizzato_SALDO==0) && (contabilizzato_ANPAG==0) &&
				(contabilizzato_ANGIR< totanticipo))
				){
				EnableTipoMovimento(5,"Anticipo della missione su partita di giro");
			}

			if ((Meta.EditMode) || 
				((contabilizzato_SALDO==0) && (contabilizzato_ANGIR==0) &&
				(contabilizzato_ANPAG< totanticipo))
				){
				EnableTipoMovimento(6,"Anticipo della missione sul capitolo di spesa");
			}
			if ((cmbCausale.SelectedValue!=null) && (cmbCausale.SelectedValue!=DBNull.Value)){
				DS.pettycashoperationitineration.Rows[0]["movkind"]=	 cmbCausale.SelectedValue;
			}
			cmbCausale.Enabled=Meta.InsertMode;
			ReCalcImporto_Missione();
			
		}

	
		/// <summary>
		/// Deve essere preceduto da GetFormData() e seguito da FreshForm()
		/// </summary>
		void ImpostaBilancioMissione(){
			if (!Meta.InsertMode) return;
			if (MissionLinked==null) return;
			if (MissioneMovSpesaLinked==null) return;
			if (MissioneMovSpesaLinked.RowState==DataRowState.Detached){
				return;
			}
			DataRow Curr = DS.pettycashoperation.Rows[0];

			int tipomovimento= CfgFn.GetNoNullInt32( MissioneMovSpesaLinked["movkind"]);
			if (tipomovimento!=5) {
				DS.accmotiveapplied_debit.Clear();
				txtCodiceCausaleDebito.Text="";
				txtDenomCausaleDebito.Text ="";
				Curr["idaccmotive_debit"]=DBNull.Value;
				return;
			}


			if (DS.config.Rows.Count==0) return;
			DataRow rPersMiss = DS.config.Rows[0];
			Curr["idfin"]= rPersMiss["idfinexpense"];
			Curr["idupb"]= "0001";
			DS.finview.Clear();
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.finview, null, 
                QHS.CmpEq("idfin",Curr["idfin"]),null,true);
			if (DS.finview.Rows.Count>0){
				DataRow Bil = DS.finview.Rows[0];
				CambioUpbPilotato=true;
                Meta.SetAutoField(Bil["idupb"], txtUPB);
				Bil = DS.finview.Rows[0];
				DataRow UPB= DS.upb.Select(QHC.CmpEq("idupb",Bil["idupb"]))[0];
				MetaData_AfterRowSelect(DS.upb,UPB);
				CambioUpbPilotato=false;
				if (DS.finview.Rows.Count>0){
					try {
						Bil = DS.finview.Rows[0];
						txtCodiceBilancio.Text= Bil["codefin"].ToString();
						txtDenominazioneBilancio.Text=Bil["title"].ToString();
						//				Curr["idfin"]= PersMiss["idfinexpense"];
						//				Curr["idupb"]= "0001";
					}
					catch {}
				}
			}
			else {				
				txtCodiceBilancio.Text="";
				txtDenominazioneBilancio.Text="";
				try {
                    Meta.SetAutoField(DBNull.Value, txtUPB);
				}
				catch {}
				Curr["idfin"]= DBNull.Value;
				Curr["idupb"]= DBNull.Value;

			}

			//Impostazione automatica della causale di debito associata ai recuperi su partita di giro
			object codrecuperoant= rPersMiss["idclawback"];
			if (codrecuperoant==DBNull.Value)return;
            string filtercodice = QHC.CmpEq("idclawback", codrecuperoant);
			DataRow []Recupero = DS.clawbacksetup.Select(filtercodice);
			if (Recupero.Length>0) {
				object codiceCausale = Recupero[0]["idaccmotive"];
				if (codiceCausale!=DBNull.Value) {
					DS.accmotiveapplied_debit.Clear();
					DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.accmotiveapplied_debit, null, 
                        GetData.MergeFilters(QHS.CmpEq("idaccmotive",codiceCausale), DS.accmotiveapplied_debit ),null,true);
					if (DS.accmotiveapplied_debit.Rows.Count>0){
						txtCodiceCausaleDebito.Text=DS.accmotiveapplied_debit.Rows[0]["codemotive"].ToString();
						txtDenomCausaleDebito.Text =DS.accmotiveapplied_debit.Rows[0]["motive"].ToString();
						Curr["idaccmotive_debit"]= Recupero[0]["idaccmotive"];
					}
				}
			}
			
		}

		/// <summary>
		/// Ricalcola l'importo della missione in base al cambiamento del combo causale
		/// </summary>
		void ReCalcImporto_Missione(){
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.pettycashoperation.Rows[0];
			if (cmbCausale.SelectedValue==null) return;

			int tipomovimento = CfgFn.GetNoNullInt32( cmbCausale.SelectedValue);

			decimal importo=0;
			if (tipomovimento==5){
				importo= totanticipo-contabilizzato_ANGIR;
			}
			if (tipomovimento==6){
				importo= totanticipo-contabilizzato_ANPAG;
			}

			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;				
			SetImporto(importo); //Richiama indirettamente il ricalcolo della prestazione
			txtImporto.Text= importo.ToString("c");
		}

		private void cmbCausaleMissione_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (Meta.InsertMode) {
				//Meta.GetFormData(true);
				GetCausaleMissione();
				ReCalcImporto_Missione();//Richiama indirettamente RicalcolaPrestazioneMissione();
				ImpostaBilancioMissione();
			}
		}

		
		/// <summary>
		/// Legge la causale dal combobox e la mette in tipomovimento ove 
		///  possibile. La pone anche in CurrCausaleMissione
		/// </summary>
		int GetCausaleMissione(){
			CurrCausaleMissione= 0;
			if (!Meta.InsertMode) return 0;
			if (DS.pettycashoperationitineration.Rows.Count==0) return 0;
			if (ContabilizzazioneSelezionata()!=tipocont.cont_missione)return 0;
			if (cmbCausale.SelectedValue!=null)
				DS.pettycashoperationitineration.Rows[0]["movkind"]= cmbCausale.SelectedValue;
			else
				DS.pettycashoperationitineration.Rows[0]["movkind"]= DBNull.Value;
			CurrCausaleMissione= CfgFn.GetNoNullInt32( DS.pettycashoperationitineration.Rows[0]["movkind"]);
			return CurrCausaleMissione; 
			//ReCalcImporto();
		}

		#endregion


		#region Gestione Selezione Missione 

		private void txtEsercMissione_Leave(object sender, System.EventArgs e) {
			if (InChiusura)return;
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
		}

		string GetFilterMissione(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			string filterupb=null;
            object getupb = Meta.GetAutoField(txtUPB);
			if (getupb!=DBNull.Value && Meta.InsertMode) {
                filterupb = QHS.NullOrEq("idupb", getupb);                  
			}
			string FilterMissione="(yitineration<='"+esercizio.ToString()+"')";
			FilterMissione=GetData.MergeFilters(FilterMissione,filterupb);
			if(txtEsercDoc.Text != ""){
				int esercmissione= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					if (esercmissione <= esercizio) 
						FilterMissione="(yitineration='"+esercmissione.ToString()+"')";
					else 
						FilterMissione = GetData.MergeFilters(FilterMissione,
							"(yitineration='"+esercmissione.ToString()+"')");
				}
				catch {
				}
			} 
			if (FiltraNum){
				int nummissione= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterMissione = GetData.MergeFilters(FilterMissione,
						"(nitineration='"+nummissione.ToString()+"')");
				} 
			}

			if (Meta.InsertMode){
				FilterMissione+="AND(residual>'0')AND(linkedangir+linkedanpag<totadvance)AND(linkedsaldo='0')"+
					"AND((active is null)OR(active='S'))";
			}

			return FilterMissione;
		}


		private void btnMissione_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);

			string MyMissioneFilter;
			if (((Control)sender).Name == "txtNumDoc")
				MyMissioneFilter = GetFilterMissione(true);
			else
				MyMissioneFilter = GetFilterMissione(false);

            object getreg = Meta.GetAutoField(txtCredDeb);
            if (getreg != DBNull.Value) {
                MyMissioneFilter= QHS.AppAnd(MyMissioneFilter,QHS.CmpEq("idreg",getreg));
            }

			MetaData MMissione;
			DataRow MyDRMissione;

			if (Meta.IsEmpty){
				MMissione = MetaData.GetMetaData(this,"itinerationlinked");
				MMissione.FilterLocked=true;			
				MMissione.DS = new DataSet();//DS.Clone();
				MyDRMissione = MMissione.SelectOne("default",MyMissioneFilter,null,null);
				if (MyDRMissione==null) {
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
						return;
					}
					return;
				}
				txtEsercDoc.Text= MyDRMissione["yitineration"].ToString();
				txtNumDoc.Text= MyDRMissione["nitineration"].ToString();
				return;
			}

			MMissione = MetaData.GetMetaData(this,"itinerationresidual");
			MMissione.FilterLocked=true;
			MMissione.DS = new DataSet(); //DS.Clone();
			
			MyDRMissione = MMissione.SelectOne("default",MyMissioneFilter,
				//GetData.MergeFilters( MyMissioneFilter,"(residuo>'0')"),
				null,null);
			
			if(MyDRMissione == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
			string selectmis= "(yitineration='"+MyDRMissione["yitineration"].ToString()+"')AND"+
				"(nitineration='"+MyDRMissione["nitineration"].ToString()+"')";


			string columnlist = QueryCreator.ColumnNameList(DS.itineration)
				+",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("itinerationview",columnlist,null,selectmis,null,null,true);
			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			if(Meta.InsertMode) {
				ResetMissione();
				CollegaMissione(MyDR);
				//RintracciaMissione();
				//RicalcolaPrestazioneMissione();
			}
	
		}

		private void txtNumMissione_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (txtNumDoc.ReadOnly)return;
			if (Meta.EditMode) return;
			//if (!Meta.InsertMode) return;

			if (txtNumDoc.Text.Trim()=="") {
				if (Meta.InsertMode) ScollegaMissione();				
				return;
			}
			btnMissione_Click(sender,e);
		}

		void AbilitaDisabilitaControlliMissione(bool abilita){
		}

		void ClearControlliMissione(){
			txtDescrizione.Text= "";
            txtCredDeb.Text = "";
			DS.registry.Clear();
			txtDocumento.Text= "";
			txtDataDoc.Text = "";
			AbilitaDisabilitaCreditoreDebitore(true);
			DS.accmotiveapplied_debit.Clear();
			txtCodiceCausaleDebito.Text="";
			txtDenomCausaleDebito.Text ="";
            txtInizioCompetenza.Text = "";
            txtFineCompetenza.Text = "";
		}

		/// <summary>
		/// Collega la riga missione al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		bool CollegaMissione(DataRow Missione2){
			if (Meta.EditMode){
				txtNumDoc.Text= Missione2["nitineration"].ToString();
				txtEsercDoc.Text= Missione2["yitineration"].ToString();
				return false;
			}
			if (Meta.IsEmpty) return false;
			
			Hashtable ValoriMissione = new Hashtable();
			foreach (DataColumn C in DS.itineration.Columns) 
				ValoriMissione[C.ColumnName]= Missione2[C.ColumnName];

			//AzzeraPadre();
			ScollegaMissione();
			DataRow CurrRow= DS.pettycashoperation.Rows[0];

			//Se la fase missione è presente, legge la riga missione e la collega al
			// movimento di spesa corrente
				DataRow NewMissR = DS.itineration.NewRow();
				foreach (DataColumn C in DS.itineration.Columns){
					NewMissR[C.ColumnName]= ValoriMissione[C.ColumnName];
				}
				DS.itineration.Rows.Add(NewMissR);
				NewMissR.AcceptChanges();
				Missione2= NewMissR;

				MetaData MovMis = MetaData.GetMetaData(this,"pettycashoperationitineration");
				MovMis.SetDefaults(DS.pettycashoperationitineration);
                DS.pettycashoperationitineration.Columns["iditineration"].DefaultValue = ValoriMissione["iditineration"];
				DataRow RMovMis = MovMis.Get_New_Row(CurrRow, DS.pettycashoperationitineration);
                DS.pettycashoperationitineration.Columns["iditineration"].DefaultValue = DBNull.Value;
				txtNumDoc.Text= ValoriMissione["nitineration"].ToString();
				txtEsercDoc.Text= ValoriMissione["yitineration"].ToString();

			//Imposta i campi che devono essere ereditati dalla missione e li aggiorna 
			// anche a video.
			CurrRow["idreg"] = ValoriMissione["idreg"];
			CurrRow["description"] = ValoriMissione["description"];
			txtDescrizione.Text= ValoriMissione["description"].ToString();

			CurrRow["doc"] = "Mis."+
				ValoriMissione["yitineration"].ToString().Substring(2,2)+"/"+
				ValoriMissione["nitineration"].ToString().PadLeft(6,'0');
			//"Ord."+ValoriOrdine["documento"];
			txtDocumento.Text = CurrRow["doc"].ToString();

			CurrRow["docdate"] = ValoriMissione["adate"];
			txtDataDoc.Text= HelpForm.StringValue(CurrRow["docdate"],txtDataDoc.Tag.ToString());

            CurrRow["flag"] = CfgFn.GetNoNullInt32(CurrRow["flag"]) | 0x10;
			chkDocumentata.Checked=true;

            CurrRow["start"] = ValoriMissione["start"];
            txtInizioCompetenza.Text = HelpForm.StringValue(CurrRow["start"], txtDataDoc.Tag.ToString());
            CurrRow["stop"] = ValoriMissione["stop"];
            txtFineCompetenza.Text = HelpForm.StringValue(CurrRow["stop"], txtDataDoc.Tag.ToString());
			
			if (DS.accmotiveapplied_cost.Rows.Count>0){
				DS.accmotiveapplied_cost.Clear();
				CurrRow["idaccmotive_cost"]=DBNull.Value;
				txtCodiceCausaleCosto.Text="";
				txtDenomCausaleCosto.Text="";
			}

			if (DS.registry.Rows.Count>0){
				DataRow Cred = DS.registry.Rows[0];
				if (Cred["idreg"].ToString() != ValoriMissione["idreg"].ToString()){
					DS.registry.Clear();
				}
			}

			if (DS.registry.Rows.Count==0){
				LeggiDatiSuCredDeb(CurrRow["idreg"].ToString());
			}
			if (DS.registry.Rows.Count>0){
				DataRow CredDeb= DS.registry.Rows[0];
				txtCredDeb.Text= CredDeb["title"].ToString();
			}
            
            CurrRow["idaccmotive_debit"] = ValoriMissione["idaccmotivedebit"];
            if (CurrRow["idaccmotive_debit"] != DBNull.Value) {
                DS.accmotiveapplied_debit.Clear();
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit, null,
                                    GetData.MergeFilters(QHS.CmpEq("idaccmotive", CurrRow["idaccmotive_debit"]), DS.accmotiveapplied_debit ) , 
                    null, false);                
                DataRow CDeb = DS.accmotiveapplied_debit.Rows[0];
                txtCodiceCausaleDebito.Text = CDeb["codemotive"].ToString();
                txtDenomCausaleDebito.Text = CDeb["motive"].ToString();
            }

            MissionLinkedMustBeEvalued = true;
			RintracciaMissione();
			AbilitaDisabilitaControlliMissione(false);
			AbilitaDisabilitaCreditoreDebitore(false);
			CalcolaContabilizzatiMissione(Missione2);
			SetComboCausaleMissione(Missione2);
			ImpostaBilancioMissione();
			return true;
		}

		
		void ScollegaMissione(){
			ResetMissione();
			if (DS.pettycashoperationitineration.Rows.Count==0) {
				AbilitaDisabilitaControlliMissione(true);
				AbilitaDisabilitaCreditoreDebitore(true);
				return;
			}
			DS.pettycashoperationitineration.Clear();
			DS.itineration.Clear();
			DataRow CurrRow= DS.pettycashoperation.Rows[0];
		
			CurrRow["idreg"] = DBNull.Value;
			txtCredDeb.Text = "";		
			DS.registry.Clear();

			CurrRow["description"] = "";
			CurrRow["doc"] = DBNull.Value;
			CurrRow["docdate"] = DBNull.Value;
			CurrRow["idaccmotive_debit"]=DBNull.Value;
            CurrRow["start"] = DBNull.Value;
            CurrRow["stop"] = DBNull.Value;

			ClearControlliMissione();
			ClearComboCausale();
			AbilitaDisabilitaControlliMissione(true);
			AbilitaDisabilitaCreditoreDebitore(true);
		}


	
		#endregion


		#region Gestione Selezione Contratto Occasionale

		private void txtEsercOccasionale_Leave(object sender, System.EventArgs e) {
			if (InChiusura)return;
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
		}

		string GetFilterOccasionale(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			string filterupb=null;
            object getupb = Meta.GetAutoField(txtUPB);
			if (getupb!=DBNull.Value && Meta.InsertMode) {
                filterupb = QHS.NullOrEq("idupb", getupb);
			}
			string FilterOccasionale="(ycon<='"+esercizio.ToString()+"')";
			FilterOccasionale=GetData.MergeFilters(FilterOccasionale,filterupb);

			if(txtEsercDoc.Text != ""){
				int eserccontratto= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					if (eserccontratto <= esercizio) 
						FilterOccasionale="(ycon='"+eserccontratto.ToString()+"')";
					else 
						FilterOccasionale = GetData.MergeFilters(FilterOccasionale,
							"(ycon='"+eserccontratto.ToString()+"')");
				}
				catch {
				}
			} 
			if (FiltraNum){
				int numcontratto= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterOccasionale = GetData.MergeFilters(FilterOccasionale,
						"(ncon='"+numcontratto.ToString()+"')");
				} 
			}

            //FilterOccasionale = QHS.AppAnd(FilterOccasionale, QHS.CmpEq("linkedtotal", 0));
			return FilterOccasionale;
		}


		private void btnOccasionale_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);

			string MyOccasionaleFilter;
			if (((Control)sender).Name == "txtNumDoc")
				MyOccasionaleFilter = GetFilterOccasionale(true);
			else
				MyOccasionaleFilter = GetFilterOccasionale(false);

            if ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != "")) {
					MyOccasionaleFilter = GetData.MergeFilters(MyOccasionaleFilter,
						"(registry="+
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
			}

			MetaData MOccasionale;
			DataRow MyDROccasionale;

			if (Meta.IsEmpty) {
				MOccasionale = MetaData.GetMetaData(this,"casualcontractlinked");
				MOccasionale.FilterLocked=true;			
				MOccasionale.DS = new DataSet();//DS.Clone();
				MyDROccasionale = MOccasionale.SelectOne("default",MyOccasionaleFilter,null,null);
				if (MyDROccasionale==null) {
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
						return;
					}
					return;
				}
				txtEsercDoc.Text= MyDROccasionale["ycon"].ToString();
				txtNumDoc.Text= MyDROccasionale["ncon"].ToString();
				return;
			}

			MOccasionale = MetaData.GetMetaData(this,"casualcontractavailable");
			MOccasionale.FilterLocked=true;
			MOccasionale.DS = new DataSet(); //DS.Clone();

            MyDROccasionale = MOccasionale.SelectOne("default", QHS.AppAnd(MyOccasionaleFilter, QHS.CmpEq("linkedtotal", 0)),
				//GetData.MergeFilters( MyMissioneFilter,"(residuo>'0')"),
				null,null);
			
			if(MyDROccasionale == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
			string selectocc= "(ycon='"+MyDROccasionale["ycon"].ToString()+"')AND"+
				"(ncon='"+MyDROccasionale["ncon"].ToString()+"')";

			string columnlist = QueryCreator.ColumnNameList(DS.casualcontract)
				+",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("casualcontractview",columnlist,null,selectocc,null,null,true);
			
			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			if(Meta.InsertMode) {
				ResetOccasionale();
				CollegaOccasionale(MyDR);
				//RintracciaOccasionale();
				//RicalcolaPrestazioneOccasionale();
			}
	
		}

		private void txtNumOccasionale_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (txtNumDoc.ReadOnly)return;
			if (Meta.EditMode) return;
			//if (!Meta.InsertMode) return;

			if (txtNumDoc.Text.Trim()=="") {
				if (Meta.InsertMode) ScollegaOccasionale();				
				return;
			}
			btnOccasionale_Click(sender,e);
		}

		void AbilitaDisabilitaControlliOccasionale(bool abilita){
		}

		void ClearControlliOccasionale(){
			txtDescrizione.Text= "";
			txtCredDeb.Text="";
			DS.registry.Clear();
			txtDocumento.Text= "";
			txtDataDoc.Text = "";
			AbilitaDisabilitaControlliOccasionale(true);
            txtInizioCompetenza.Text = "";
            txtFineCompetenza.Text = "";
		}

		/// <summary>
		/// Collega la riga missione al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		bool CollegaOccasionale(DataRow ContrattoOcc2){
			if (Meta.EditMode){
				txtEsercDoc.Text= ContrattoOcc2["ycon"].ToString();
				txtNumDoc.Text= ContrattoOcc2["ncon"].ToString();
				return false;
			}
			if (Meta.IsEmpty) return false;
			
			Hashtable ValoriOccasionale = new Hashtable();
			foreach (DataColumn C in DS.casualcontract.Columns) 
				ValoriOccasionale[C.ColumnName]= ContrattoOcc2[C.ColumnName];

			//AzzeraPadre();
			ScollegaOccasionale();
			DataRow CurrRow= DS.pettycashoperation.Rows[0];

			//Se la fase missione è presente, legge la riga missione e la collega al
			// movimento di spesa corrente
				DataRow NewOccR = DS.casualcontract.NewRow();
				foreach (DataColumn C in DS.casualcontract.Columns){
					NewOccR[C.ColumnName]= ValoriOccasionale[C.ColumnName];
				}
				DS.casualcontract.Rows.Add(NewOccR);
				NewOccR.AcceptChanges();
				ContrattoOcc2= NewOccR;

				MetaData MovOcc = MetaData.GetMetaData(this,"pettycashoperationcasualcontract");
				MovOcc.SetDefaults(DS.pettycashoperationcasualcontract);
				DS.pettycashoperationcasualcontract.Columns["ycon"].DefaultValue= ValoriOccasionale["ycon"];
				DS.pettycashoperationcasualcontract.Columns["ncon"].DefaultValue= ValoriOccasionale["ncon"];
				DataRow RMovOcc = MovOcc.Get_New_Row(CurrRow, DS.pettycashoperationcasualcontract);
				DS.pettycashoperationcasualcontract.Columns["ycon"].DefaultValue= DBNull.Value;
				DS.pettycashoperationcasualcontract.Columns["ncon"].DefaultValue= DBNull.Value;
				txtEsercDoc.Text= ValoriOccasionale["ycon"].ToString();
				txtNumDoc.Text= ValoriOccasionale["ncon"].ToString();

			//Imposta i campi che devono essere ereditati dalla missione e li aggiorna 
			// anche a video.
			object codicecreddeb= ValoriOccasionale["idreg"];
			object esercontratto= ValoriOccasionale["ycon"];
			object numcontratto= ValoriOccasionale["ncon"];


			CurrRow["idreg"] = codicecreddeb;
			CurrRow["description"] = ValoriOccasionale["description"].ToString();
			//ValoriCedolino["descrizione"];

			txtDescrizione.Text= CurrRow["description"].ToString();
			CurrRow["doc"] = "Contratto Occasionale "+
				ValoriOccasionale["ycon"].ToString().Substring(2,2)+"/"+
				ValoriOccasionale["ncon"].ToString().PadLeft(6,'0');
			txtDocumento.Text = CurrRow["doc"].ToString();
			CurrRow["docdate"] = ValoriOccasionale["adate"];
			txtDataDoc.Text=   HelpForm.StringValue( ValoriOccasionale["adate"], txtDataDoc.Tag.ToString());
            CurrRow["flag"] = CfgFn.GetNoNullInt32(CurrRow["flag"]) | 0x10;
			chkDocumentata.Checked=true;

            CurrRow["start"] = ValoriOccasionale["start"];
            txtInizioCompetenza.Text = HelpForm.StringValue(CurrRow["start"], txtDataDoc.Tag.ToString());
            CurrRow["stop"] = ValoriOccasionale["stop"];
            txtFineCompetenza.Text = HelpForm.StringValue(CurrRow["stop"], txtDataDoc.Tag.ToString());

			if (DS.accmotiveapplied_cost.Rows.Count>0){
				DS.accmotiveapplied_cost.Clear();
				CurrRow["idaccmotive_cost"]=DBNull.Value;
				txtCodiceCausaleCosto.Text="";
				txtDenomCausaleCosto.Text="";
			}
            CurrRow["idaccmotive_debit"] = ValoriOccasionale["idaccmotivedebit"];
            if (CurrRow["idaccmotive_debit"] != DBNull.Value) {
                DS.accmotiveapplied_debit.Clear();
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit, null,
                                GetData.MergeFilters(QHS.CmpEq("idaccmotive", CurrRow["idaccmotive_debit"]), DS.accmotiveapplied_debit), 
                    null, false);
                DataRow CDeb = DS.accmotiveapplied_debit.Rows[0];
                txtCodiceCausaleDebito.Text = CDeb["codemotive"].ToString();
                txtDenomCausaleDebito.Text = CDeb["motive"].ToString();
            }

            if (DS.registry.Rows.Count>0){
				DataRow Cred = DS.registry.Rows[0];
				if (Cred["idreg"].ToString() != codicecreddeb.ToString()){
					DS.registry.Clear();
				}
			}

			if (DS.registry.Rows.Count==0){
				LeggiDatiSuCredDeb(CurrRow["idreg"].ToString());
			}
			if (DS.registry.Rows.Count>0){
				DataRow CredDeb= DS.registry.Rows[0];
				txtCredDeb.Text= CredDeb["title"].ToString();
			}

			OccasionaleLinkedMustBeEvalued=true;
			RintracciaOccasionale();
			AbilitaDisabilitaControlliOccasionale(false);
			AbilitaDisabilitaCreditoreDebitore(false);
            txtImporto.ReadOnly = true;

			CalcolaContabilizzatiOccasionale(ContrattoOcc2);
			SetComboCausaleOccasionale(ContrattoOcc2);
			return true;
		}

		
		void ScollegaOccasionale(){
			ResetOccasionale();
			if (DS.pettycashoperationcasualcontract.Rows.Count==0) {
				AbilitaDisabilitaControlliOccasionale(true);
				AbilitaDisabilitaCreditoreDebitore(true);
                txtImporto.ReadOnly = false;
				return;
			}
			DS.pettycashoperationcasualcontract.Clear();
			DS.casualcontract.Clear();
			DataRow CurrRow= DS.pettycashoperation.Rows[0];

			CurrRow["idreg"] = DBNull.Value;
			txtCredDeb.Text = "";		
			DS.registry.Clear();

			CurrRow["description"] = "";
			CurrRow["doc"] = DBNull.Value;
			CurrRow["docdate"] = DBNull.Value;
            CurrRow["start"] = DBNull.Value;
            CurrRow["stop"] = DBNull.Value;

			ClearControlliOccasionale();
			ClearComboCausale();
			AbilitaDisabilitaControlliOccasionale(true);
			AbilitaDisabilitaCreditoreDebitore(true);
            txtImporto.ReadOnly = false;
		}

		//		bool RitenuteDevonoEssereCalcolate(){
		//			int faseritenute = fasespesamax;
		//			if (fasespesafine < faseritenute) return false;
		//			if ((fasemissione>=faseinizio) &&
		//				(ContabilizzazioneSelezionata()!=tipocont.cont_missione)) return false;
		//			if (fasemissione<faseinizio) return true;
		//			if ((faseinizio <= fasemissione) && 
		//				(fasemissione <= fasespesafine) &&
		//				(DS.missione.Rows.Count>0))return true;
		//			return false;
		//		}

	
		#endregion


		#region Gestione ComboBox Causale Occasionale

		decimal occasionalenetto;
		decimal contabilizzatooccasionale;
        

		void SetEditComboCausaleOccasionale(){
			if (!Meta.EditMode)return;
			ClearComboCausale();
			EnableTipoMovimento(4,"Pagamento");
			int currtipo = 4; //DS.Tables["cedolinomovspesa"].Rows[0]["tipomovimento"].ToString();
			HelpForm.SetComboBoxValue(cmbCausale, currtipo);
		}

		void UpdateComboCausaleOccasionale(){
			if (OccasionaleMovSpesaLinked!=null){
				int currtipo = 4;
				HelpForm.SetComboBoxValue(cmbCausale, currtipo);
			}
		}



		string lastOccEvalued=null;

		void CalcolaContabilizzatiOccasionale(DataRow ContrattoOcc){
			string filterocc = "(ycon='"+ContrattoOcc["ycon"].ToString()+"')AND"+
				"(ncon='"+ContrattoOcc["ncon"].ToString()+"')";
			decimal totlordo= CfgFn.GetNoNullDecimal(ContrattoOcc["feegross"]);
            calcOccasionale mycalc = new calcOccasionale(Conn, ContrattoOcc);
            decimal nettoresiduo = mycalc.GetNettoResiduo();

            //decimal ritenute = CfgFn.GetNoNullDecimal(
            //    Conn.DO_READ_VALUE("casualcontracttaxbracket", filterocc, "sum(employtax)"));
            occasionalenetto = nettoresiduo;
			if (filterocc==lastOccEvalued) return;
			lastOccEvalued= filterocc;
		    
			DataTable Residuo = Conn.RUN_SELECT("casualcontractresidual","*",null,filterocc,null,true);
		    if (Residuo == null || Residuo.Rows.Count == 0) {
		        contabilizzatooccasionale = totlordo; //almeno non va in eccezione
                return;
		    }

			DataRow CurrResid = Residuo.Rows[0];
			contabilizzatooccasionale= CfgFn.GetNoNullDecimal(CurrResid["linkedtotal"]); //dovrebbe essere 0
			//decimal residuo = CfgFn.GetNoNullDecimal( CurrResid["residuo"]);
			//contabilizzato_VARIAZIONI= -(totlordo-residuo-contabilizzatooccasionale);
		}


		
		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleOccasionale(DataRow ContrattoOcc){
			//occasionalelordo= CfgFn.GetNoNullDecimal(ContrattoOcc["feegross"]);

			//CalcolaContabilizzatiMissione(Missione);

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;

			if ( (Meta.EditMode) || 
				(contabilizzatooccasionale< occasionalenetto)
				){
				EnableTipoMovimento(4,"Pagamento");
			}

			//DS.missionemovspesa.Rows[0]["tipomovimento"]=	 cmbCausale.SelectedValue;
			cmbCausale.Enabled=false; //Meta.InsertMode;
			ReCalcImporto_Occasionale();
			
		}


		void ReCalcImporto_Occasionale(){
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.pettycashoperation.Rows[0];
			if (cmbCausale.SelectedValue==null) return;

			string tipomovimento = cmbCausale.SelectedValue.ToString();

			decimal importo=occasionalenetto-contabilizzatooccasionale;
            if(importo < 0) {
                importo = 0;
                MessageBox.Show("Di questa prestazione è stato già contabilizzato l'importo netto");
            }

			SetImporto(importo);
			txtImporto.Text= importo.ToString("c");
		}

		private void cmbCausaleOccasionale_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (Meta.InsertMode) {
				//Meta.GetFormData(true);
				GetCausaleOccasionale();
				ReCalcImporto_Occasionale();//Richiama indirettamente RicalcolaPrestazioneMissione();
			}
		}

		
		/// <summary>
		/// Legge la causale dal combobox e la mette in tipomovimento ove 
		///  possibile.
		/// </summary>
		int GetCausaleOccasionale(){
			CurrCausaleOccasionale= 0;
			if (!Meta.InsertMode) return 0;
			if (DS.pettycashoperationcasualcontract.Rows.Count==0) return 0;
			if (ContabilizzazioneSelezionata()!=tipocont.cont_occasionale)return 0;
			CurrCausaleOccasionale= 4;
			//DS.cedolinomovspesa.Rows[0]["tipomovimento"].ToString();
			return CurrCausaleOccasionale; 
			//ReCalcImporto();
		}

		#endregion

		#region Gestione Selezione Contratto Professionale

		private void txtEsercProfessionale_Leave(object sender, System.EventArgs e) {
			if (InChiusura)return;
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
		}

		string GetFilterProfessionale(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			string filterupb=null;
            object getupb = Meta.GetAutoField(txtUPB);
            if (getupb != DBNull.Value && Meta.InsertMode)
                filterupb = QHS.NullOrEq("idupb", getupb);
			string FilterProfessionale="(ycon<='"+esercizio.ToString()+"')";
			FilterProfessionale=GetData.MergeFilters(FilterProfessionale,filterupb);
			if(txtEsercDoc.Text != ""){
				int eserccontratto= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					if (eserccontratto <= esercizio) 
						FilterProfessionale="(ycon='"+eserccontratto.ToString()+"')";
					else 
						FilterProfessionale = GetData.MergeFilters(FilterProfessionale,
							"(ycon='"+eserccontratto.ToString()+"')");
				}
				catch {
				}
			} 
			if (FiltraNum){
				int numcontratto= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterProfessionale = GetData.MergeFilters(FilterProfessionale,
						"(ncon='"+numcontratto.ToString()+"')");
				} 
			}						
			if (Meta.InsertMode){
				FilterProfessionale+="AND(residual>'0')AND(linkedimpos='0')and(linkedimpon='0')";
			}

			return FilterProfessionale;
		}


		private void btnProfessionale_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);

			string MyProfessionaleFilter;
			if (((Control)sender).Name == "txtNumDoc")
				MyProfessionaleFilter = GetFilterProfessionale(true);
			else
				MyProfessionaleFilter = GetFilterProfessionale(false);

            if ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != "")) {
				MyProfessionaleFilter = GetData.MergeFilters(MyProfessionaleFilter,
					"(registry="+
                    QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
			}
			

			MetaData MProfessionale;
			DataRow MyDRProfessionale;

			if (Meta.IsEmpty) {
				MProfessionale = MetaData.GetMetaData(this,"profservicelinked");
				MProfessionale.FilterLocked=true;			
				MProfessionale.DS = new DataSet(); //DS.Clone();
				MyDRProfessionale = MProfessionale.SelectOne("default",MyProfessionaleFilter,null,null);
				if (MyDRProfessionale==null) {
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
						return;
					}
					return;
				}
				txtEsercDoc.Text= MyDRProfessionale["ycon"].ToString();
				txtNumDoc.Text= MyDRProfessionale["ncon"].ToString();
				return;
			}

			MProfessionale = MetaData.GetMetaData(this,"profserviceresidual");
			MProfessionale.FilterLocked=true;
			MProfessionale.DS = new DataSet(); //DS.Clone();
			
			MyDRProfessionale = MProfessionale.SelectOne("default",MyProfessionaleFilter,
				//GetData.MergeFilters( MyMissioneFilter,"(residuo>'0')"),
				null,null);
			
			if(MyDRProfessionale == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
			string selectocc= "(ycon='"+MyDRProfessionale["ycon"].ToString()+"')AND"+
				"(ncon='"+MyDRProfessionale["ncon"].ToString()+"')";

			string columnlist = QueryCreator.ColumnNameList(DS.profservice)
				+",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("profserviceview",columnlist,null,selectocc,null,null,true);
			
			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			if(Meta.InsertMode) {
				ResetProfessionale();
				CollegaProfessionale(MyDR);
				//RintracciaProfessionale();
				//RicalcolaPrestazioneProfessionale();
			}
	
		}

		private void txtNumProfessionale_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (txtNumDoc.ReadOnly)return;
			if (Meta.EditMode) return;
			//if (!Meta.InsertMode) return;

			if (txtNumDoc.Text.Trim()=="") {
				if (Meta.InsertMode) ScollegaProfessionale();				
				return;
			}
			btnProfessionale_Click(sender,e);
		}

		void AbilitaDisabilitaControlliProfessionale(bool abilita){
		}

		void ClearControlliProfessionale(){
			txtDescrizione.Text= "";
			txtCredDeb.Text="";
			DS.registry.Clear();
			txtDocumento.Text= "";
			txtDataDoc.Text = "";
			AbilitaDisabilitaControlliProfessionale(true);
            txtInizioCompetenza.Text = "";
            txtFineCompetenza.Text = "";
		}

		/// <summary>
		/// Collega la riga missione al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		bool CollegaProfessionale(DataRow ContrattoProf2){
			if (Meta.EditMode){
				txtEsercDoc.Text= ContrattoProf2["ycon"].ToString();
				txtNumDoc.Text= ContrattoProf2["ncon"].ToString();
				return false;
			}
			if (Meta.IsEmpty) return false;
			
			Hashtable ValoriProfessionale = new Hashtable();
			foreach (DataColumn C in DS.profservice.Columns) 
				ValoriProfessionale[C.ColumnName]= ContrattoProf2[C.ColumnName];

			//AzzeraPadre();
			ScollegaProfessionale();
			DataRow CurrRow= DS.pettycashoperation.Rows[0];

			//Se la fase missione è presente, legge la riga missione e la collega al
			// movimento di spesa corrente
				DataRow NewProfR = DS.profservice.NewRow();
				foreach (DataColumn C in DS.profservice.Columns){
					NewProfR[C.ColumnName]= ValoriProfessionale[C.ColumnName];
				}
				DS.profservice.Rows.Add(NewProfR);
				NewProfR.AcceptChanges();
				ContrattoProf2= NewProfR;

				MetaData MovProf = MetaData.GetMetaData(this,"pettycashoperationprofservice");
				MovProf.SetDefaults(DS.pettycashoperationprofservice);
				DS.pettycashoperationprofservice.Columns["ycon"].DefaultValue= ValoriProfessionale["ycon"];
				DS.pettycashoperationprofservice.Columns["ncon"].DefaultValue= ValoriProfessionale["ncon"];
				DataRow RMovProf = MovProf.Get_New_Row(CurrRow, DS.pettycashoperationprofservice);
				DS.pettycashoperationprofservice.Columns["ycon"].DefaultValue= DBNull.Value;
				DS.pettycashoperationprofservice.Columns["ncon"].DefaultValue= DBNull.Value;
				txtEsercDoc.Text= ValoriProfessionale["ycon"].ToString();
				txtNumDoc.Text= ValoriProfessionale["ncon"].ToString();

			//Imposta i campi che devono essere ereditati dalla missione e li aggiorna 
			// anche a video.
			object codicecreddeb= ValoriProfessionale["idreg"];
			object esercontratto= ValoriProfessionale["ycon"];
			object numcontratto= ValoriProfessionale["ncon"];


			CurrRow["idreg"] = codicecreddeb;
			CurrRow["description"] = ValoriProfessionale["description"].ToString();
			//ValoriCedolino["descrizione"];

			txtDescrizione.Text= CurrRow["description"].ToString();
			CurrRow["doc"] = ValoriProfessionale["doc"];
			txtDocumento.Text = CurrRow["doc"].ToString();
			CurrRow["docdate"] = ValoriProfessionale["docdate"];
			txtDataDoc.Text=   HelpForm.StringValue( ValoriProfessionale["docdate"], 
				txtDataDoc.Tag.ToString());

            CurrRow["flag"] = CfgFn.GetNoNullInt32(CurrRow["flag"]) | 0x10;
			chkDocumentata.Checked=true;

            CurrRow["start"] = ValoriProfessionale["start"];
            txtInizioCompetenza.Text = HelpForm.StringValue(CurrRow["start"], txtDataDoc.Tag.ToString());
            CurrRow["stop"] = ValoriProfessionale["stop"];
            txtFineCompetenza.Text = HelpForm.StringValue(CurrRow["stop"], txtDataDoc.Tag.ToString());

			if (DS.accmotiveapplied_cost.Rows.Count>0){
				DS.accmotiveapplied_cost.Clear();
				CurrRow["idaccmotive_cost"]=DBNull.Value;
				txtCodiceCausaleCosto.Text="";
				txtDenomCausaleCosto.Text="";
			}                        
            CurrRow["idaccmotive_debit"] = ValoriProfessionale["idaccmotivedebit"];
            if (CurrRow["idaccmotive_debit"] != DBNull.Value) {
                DS.accmotiveapplied_debit.Clear();
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit, null, 
                                GetData.MergeFilters(QHS.CmpEq("idaccmotive", CurrRow["idaccmotive_debit"]),DS.accmotiveapplied_debit), 
                    
                    null, false);
                DataRow CDeb = DS.accmotiveapplied_debit.Rows[0];
                txtCodiceCausaleDebito.Text = CDeb["codemotive"].ToString();
                txtDenomCausaleDebito.Text = CDeb["motive"].ToString();
            }

            if (DS.registry.Rows.Count>0){
				DataRow Cred = DS.registry.Rows[0];
				if (Cred["idreg"].ToString() != codicecreddeb.ToString()){
					DS.registry.Clear();
				}
			}

			if (DS.registry.Rows.Count==0){
				LeggiDatiSuCredDeb(CurrRow["idreg"].ToString());
			}
			if (DS.registry.Rows.Count>0){
				DataRow CredDeb= DS.registry.Rows[0];
				txtCredDeb.Text= CredDeb["title"].ToString();
			}

			ProfessionaleLinkedMustBeEvalued=true;
			RintracciaProfessionale();
			AbilitaDisabilitaControlliProfessionale(false);
			AbilitaDisabilitaCreditoreDebitore(false);
			CalcolaContabilizzatiProfessionale(ContrattoProf2);
			SetComboCausaleProfessionale(ContrattoProf2);
			return true;
		}

		
		void ScollegaProfessionale(){
			ResetProfessionale();
			if (DS.pettycashoperationprofservice.Rows.Count==0) {
				AbilitaDisabilitaControlliProfessionale(true);
				AbilitaDisabilitaCreditoreDebitore(true);
				return;
			}
			DS.pettycashoperationprofservice.Clear();
			DS.profservice.Clear();
			DataRow CurrRow= DS.pettycashoperation.Rows[0];

			CurrRow["idreg"] = DBNull.Value;
			txtCredDeb.Text = "";		
			DS.registry.Clear();

			CurrRow["description"] = "";
			CurrRow["doc"] = DBNull.Value;
			CurrRow["docdate"] = DBNull.Value;
            CurrRow["start"] = DBNull.Value;
            CurrRow["stop"] = DBNull.Value;

			ClearControlliProfessionale();
			ClearComboCausale();
			AbilitaDisabilitaControlliProfessionale(true);
			AbilitaDisabilitaCreditoreDebitore(true);
		}

		//		bool RitenuteDevonoEssereCalcolate(){
		//			int faseritenute = fasespesamax;
		//			if (fasespesafine < faseritenute) return false;
		//			if ((fasemissione>=faseinizio) &&
		//				(ContabilizzazioneSelezionata()!=tipocont.cont_missione)) return false;
		//			if (fasemissione<faseinizio) return true;
		//			if ((faseinizio <= fasemissione) && 
		//				(fasemissione <= fasespesafine) &&
		//				(DS.missione.Rows.Count>0))return true;
		//			return false;
		//		}

	
		#endregion




		#region Gestione ComboBox Causale Professionale


		decimal totprofnetto;
		decimal totprofiva;
        decimal totprofrit;
		decimal assigned_profimponibile;
		decimal assigned_profiva;
		decimal assigned_profgen;



		void SetEditComboCausaleProfessionale(){
			if (!Meta.EditMode)return;
			ClearComboCausale();
			EnableTipoMovimento(1,"Contabilizzazione Totale Fattura");
			//cmbCausale.SelectedValue= DS.Tables["ordinegenericomovspesa"].Rows[0]["tipomovimento"].ToString();
			int currtipo = 1; //ex 4!!
			HelpForm.SetComboBoxValue(cmbCausale, currtipo);

		}

		
		string lastProfEvalued=null;
		void CalcolaContabilizzatiProfessionale(DataRow ContrattoProf){
			string filterprof = "(ycon='"+ContrattoProf["ycon"].ToString()+"')AND"+
				"(ncon='"+ContrattoProf["ncon"].ToString()+"')";
			if (filterprof==lastProfEvalued) return;
			lastProfEvalued= filterprof;
            decimal importobenef = CfgFn.GetNoNullDecimal(ContrattoProf["totalgross"]);			
			totprofiva=CfgFn.GetNoNullDecimal( ContrattoProf["ivaamount"]);
            //decimal totprofimponibile = importobenef - totprofiva;
            totprofrit=CfgFn.GetNoNullDecimal(
                        Conn.DO_READ_VALUE("profservicetax", filterprof, "sum(employtax)"));
            totprofnetto = importobenef - totprofrit;

			DataTable Residuo = Conn.RUN_SELECT("profserviceresidual","*",null,filterprof,null,true);

			DataRow CurrResid = Residuo.Rows[0];
			assigned_profimponibile= CfgFn.GetNoNullDecimal(CurrResid["linkedimpon"]);
			assigned_profiva= CfgFn.GetNoNullDecimal(CurrResid["linkedimpos"]);
			assigned_profgen= CfgFn.GetNoNullDecimal(CurrResid["linkeddocum"]);
			//decimal residuo = CfgFn.GetNoNullDecimal(CurrResid["residuo"]);
			//contabilizzato_VARIAZIONI= 0; //-(totlordo-residuo-contabilizzato_ANPAG-contabilizzato_SALDO);

		}



		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleProfessionale(DataRow ContrattoProf){
			DataAccess Conn= Meta.Conn;

			CalcolaContabilizzatiProfessionale(ContrattoProf);

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;

			if ((Meta.EditMode) || 
				((assigned_profimponibile+assigned_profiva)==0) && 
				(assigned_profgen< totprofnetto)
				){
				EnableTipoMovimento(1,"Contabilizzazione Totale Fattura");
			}

			//DS.expenseprofservice.Rows[0]["movkind"]=	 cmbCausale.SelectedValue;
			cmbCausale.Enabled=Meta.InsertMode;
			ReCalcImporto_Professionale();
			
		}


		void ReCalcImporto_Professionale(){
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.pettycashoperation.Rows[0];
			if (cmbCausale.SelectedValue==null) return;

			int tipomovimento = CfgFn.GetNoNullInt32( cmbCausale.SelectedValue);

			decimal importo=0;
			if (tipomovimento==1){
				importo= totprofnetto-assigned_profgen;
			}
            if(importo < 0) {
                MessageBox.Show("E' stato già contabilizzato il netto di questo contratto");
                importo = 0;
            }

			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;				
			SetImporto(importo);
			txtImporto.Text= importo.ToString("c");

		}

		private void cmbCausaleProfessionale_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.InsertMode) return;
			GetCausaleProfessionale();
			ReCalcImporto_Professionale();
		}

		int GetCausaleProfessionale(){
			CurrCausaleProfessionale= 0;
			if (!Meta.InsertMode) return 0;
			if (DS.pettycashoperationprofservice.Rows.Count==0) return 0;
			CurrCausaleProfessionale= 4;
			return CurrCausaleProfessionale;
			//ReCalcImporto();
		}


		void UpdateComboCausaleProfessionale(){
			if (ProfessionaleMovSpesaLinked!=null){
				int currtipo = 4;
				HelpForm.SetComboBoxValue(cmbCausale, currtipo);
			}
		}

		#endregion

		private void FormattaDataDelTexBox(TextBox TB) {
			if(!TB.Modified)return;
			HelpForm.FormatLikeYear(TB);
		}


		#region Gestione Selezione Documento Iva 

		string FilterIva;

		//		void AbilitaDisabilitaBtnOrdine(){
		//			bool SelezioneOrdineAttiva = ((Meta.IsEmpty)||(Meta.InsertMode));
		//			btnOrdine.Enabled=  SelezioneOrdineAttiva;
		//			txtNumOrdine.ReadOnly= !SelezioneOrdineAttiva;
		//			txtEsercOrdine.ReadOnly= !SelezioneOrdineAttiva;
		//			cmbCausale.Enabled= Meta.InsertMode && (txtNumOrdine.Text.Trim()!="");
		//			txtCredDeb.ReadOnly = !Meta.IsEmpty;
		//		}

		private void txtEsercIva_Leave(object sender, System.EventArgs e) {
			if (InChiusura)return;
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
			//CalcolaStartFilter(null);
		}

		string GetFilterIva(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			FilterIva="(yinv<='"+esercizio.ToString()+"')";
			if(txtEsercDoc.Text != ""){
				int esercdocumento= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					if (esercdocumento <= esercizio) 
						FilterIva="(yinv='"+esercdocumento.ToString()+"')";
					else 
						FilterIva = GetData.MergeFilters(FilterIva,
							"(yinv='"+esercdocumento.ToString()+"')");
				}
				catch {
				}
			} 
			if (FiltraNum){
				int numdocumento= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterIva = GetData.MergeFilters(FilterIva,
						"(ninv='"+numdocumento.ToString()+"')");
				} 
			}
			string filtertipodoc;
			if (cmbTipoDocumento.SelectedIndex<=0){
                filtertipodoc = QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2));
			}
			else {
				filtertipodoc = "(idinvkind="+
					QueryCreator.quotedstrvalue(cmbTipoDocumento.SelectedValue,true)+")";
			}
			FilterIva = GetData.MergeFilters(FilterIva, filtertipodoc);

			if (Meta.InsertMode){
//				FilterIva+="AND(residual>'0')AND(linkedimpos='0')and(linkedimpon='0')"+
//					"AND((active is null)OR(active='S'))AND(ycon is null)";
				FilterIva+="AND(residual= (taxabletotal + ivatotal) )AND(linkedimpos='0')and(linkedimpon='0')"+
                    "AND((active is null)OR(active='S'))AND(ycon is null)";

				
			}

			return FilterIva;

		}


		private void btnIva_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);
			string MyIvaFilter;
			string MyFilterDocumentoIva;
			string MyFilterIvaOperativo;
			if (((Control)sender).Name == "txtNumDoc")
				MyIvaFilter = GetFilterIva(true);
			else
				MyIvaFilter = GetFilterIva(false);

			MyFilterDocumentoIva= MyIvaFilter;
			MyFilterIvaOperativo= MyIvaFilter;

			if (Meta.InsertMode){
				DataRow Curr = DS.pettycashoperation.Rows[0];
                if ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != "")) {
					DataRow Cred=DS.registry.Rows[0];
					if (Curr["idreg"]!=DBNull.Value){
						MyFilterDocumentoIva = GetData.MergeFilters(MyFilterDocumentoIva,
							"(idreg="+
							QueryCreator.quotedstrvalue(Cred["idreg"],true)+")");
					}
				}
			}

            if ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != "")) {
					MyFilterIvaOperativo= GetData.MergeFilters(MyFilterIvaOperativo,
						"(registry="+
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
			}

			MetaData MDocumentoIva;
			DataRow MyDRIva;

			if (Meta.IsEmpty) {
                MDocumentoIva = MetaData.GetMetaData(this, "invoiceresidual");
				MDocumentoIva.FilterLocked=true;			
				MDocumentoIva.DS = new DataSet();//DS.Clone();
				MyDRIva = MDocumentoIva.SelectOne("default",MyFilterDocumentoIva,null,null);
				if (MyDRIva==null) {
					if (sender is TextBox) {
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
						return;
					}
					return;
				}
				TipoDocChangePilotato=true;				
				HelpForm.SetComboBoxValue(cmbTipoDocumento,MyDRIva["idinvkind"]);
				TipoDocChangePilotato=false;
				txtEsercDoc.Text= MyDRIva["yinv"].ToString();
				txtNumDoc.Text= MyDRIva["ninv"].ToString();
				return;
			}

			MDocumentoIva = MetaData.GetMetaData(this,"invoiceresidual");
			MDocumentoIva.FilterLocked=true;
			MDocumentoIva.DS = new DataSet();//DS.Clone();
			
			MyDRIva = MDocumentoIva.SelectOne("default",MyFilterIvaOperativo,null,null);
			
			if(MyDRIva == null) {
				if (sender is TextBox){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
            
			string columnlist = QueryCreator.ColumnNameList(DS.invoice)+",registry";
		    var Temp = Conn.readFromTable("invoiceview",  q.mCmp(MyDRIva, "idinvkind", "yinv", "ninv"), columnlist);
			
			if (Temp.Rows.Count==0) return;
			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			if(Meta.InsertMode) {
				ResetIva();
				CollegaIva(MyDR);
				RintracciaIva();
			}
	
		}

		private void txtNumIva_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (txtNumDoc.ReadOnly)return;
			if (Meta.EditMode) return;
			//if (!Meta.InsertMode) return;
			//CalcolaStartFilter(null);


			if (txtNumDoc.Text.Trim()==""){
				if (Meta.InsertMode) ScollegaIva(true);				
				ClearControlliIva(true);
				txtCredDeb.Text="";
				return;
			}


			btnIva_Click(sender,e);
		}

		void ClearControlliIva(bool skipTipoDoc){
            txtCredDeb.Text = "";		
			DS.registry.Clear();
			txtDescrizione.Text= "";
			txtDocumento.Text= "";
			txtDataDoc.Text = "";
            Meta.SetAutoField(DBNull.Value, txtResponsabile);
			if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex=0;
			AbilitaDisabilitaCreditoreDebitore(true);
            txtInizioCompetenza.Text = "";
            txtFineCompetenza.Text = "";
		}

	
		void AbilitaDisabilitaControlliIva(bool abilita){
			txtImporto.ReadOnly = (abilita);
//			AbilitaDisabilitaCreditoreDebitore(abilita);
//			txtCredDeb.ReadOnly=!abilita;
		}
	


		/// <summary>
		/// Collega la riga al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		void CollegaIva(DataRow Iva2){
			if (Meta.EditMode){
				cmbTipoDocumento.Tag=
					"pettycashoperationinvoice.idinvkind?"+
					"pettycashopinvoiceview.idinvkind";

				txtNumDoc.Text= Iva2["ninv"].ToString();
				txtEsercDoc.Text = Iva2["yinv"].ToString();
				ImpostaComboInvoiceKind();
				TipoDocChangePilotato=true;
				HelpForm.SetComboBoxValue(cmbTipoDocumento,	Iva2["idinvkind"]);
				TipoDocChangePilotato=false;
				return;
			}
			if (Meta.IsEmpty) return;
			//Meta.GetFormData(true);
			//AzzeraPadre();
			Hashtable ValoriDocumentoIva = new Hashtable();
			foreach (DataColumn C in DS.invoice.Columns) 
				ValoriDocumentoIva[C.ColumnName]= Iva2[C.ColumnName];

			ScollegaIva();

			DataRow NewIvaR = DS.invoice.NewRow();

			foreach (DataColumn C in DS.invoice.Columns){
				NewIvaR[C.ColumnName]= ValoriDocumentoIva[C.ColumnName];
			}

			DS.invoice.Rows.Add(NewIvaR);
			NewIvaR.AcceptChanges();

			DataRow CurrRow= DS.pettycashoperation.Rows[0];
			MetaData MovIva = MetaData.GetMetaData(this,"pettycashoperationinvoice");
			MovIva.SetDefaults(DS.pettycashoperationinvoice);
			DS.pettycashoperationinvoice.Columns["idinvkind"].DefaultValue=ValoriDocumentoIva["idinvkind"];
			DS.pettycashoperationinvoice.Columns["ninv"].DefaultValue= ValoriDocumentoIva["ninv"];
			DS.pettycashoperationinvoice.Columns["yinv"].DefaultValue= ValoriDocumentoIva["yinv"];
			txtNumDoc.Text=ValoriDocumentoIva["ninv"].ToString();
			txtEsercDoc.Text=ValoriDocumentoIva["yinv"].ToString();
			TipoDocChangePilotato=true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,ValoriDocumentoIva["idinvkind"]);
			TipoDocChangePilotato=false;

			DataRow RMovIva = MovIva.Get_New_Row(CurrRow, DS.pettycashoperationinvoice);
			DS.pettycashoperationinvoice.Columns["idinvkind"].DefaultValue = DBNull.Value;
			DS.pettycashoperationinvoice.Columns["ninv"].DefaultValue= DBNull.Value;
			DS.pettycashoperationinvoice.Columns["yinv"].DefaultValue= DBNull.Value;

			CurrRow["idreg"] = ValoriDocumentoIva["idreg"];
			CurrRow["description"] = ValoriDocumentoIva["description"];
			txtDescrizione.Text= ValoriDocumentoIva["description"].ToString();
			

			CurrRow["doc"] = "Doc."+ValoriDocumentoIva["doc"];
			txtDocumento.Text = "Doc."+ValoriDocumentoIva["doc"];
			CurrRow["docdate"] = ValoriDocumentoIva["docdate"];
			txtDataDoc.Text=   HelpForm.StringValue( ValoriDocumentoIva["docdate"], txtDataDoc.Tag.ToString());
			//CurrRow["codiceresponsabile"] = ValoriDocumentoIva["codiceresponsabile"];
			//HelpForm.SetComboBoxValue(cmbResponsabile, 	ValoriDocumentoIva["codiceresponsabile"].ToString());

            CurrRow["flag"] = CfgFn.GetNoNullInt32(CurrRow["flag"])| 0x10;
			chkDocumentata.Checked=true;

			if (DS.accmotiveapplied_cost.Rows.Count>0){
				DS.accmotiveapplied_cost.Clear();
				CurrRow["idaccmotive_cost"]=DBNull.Value;
				txtCodiceCausaleCosto.Text="";
				txtDenomCausaleCosto.Text="";
			}

			if (DS.registry.Rows.Count>0){
				DataRow Cred = DS.registry.Rows[0];
				if (Cred["idreg"].ToString() != ValoriDocumentoIva["idreg"].ToString()){
					DS.registry.Clear();
				}
			}

            CurrRow["idaccmotive_debit"] = ValoriDocumentoIva["idaccmotivedebit"];
            if (CurrRow["idaccmotive_debit"] != DBNull.Value) {
                DS.accmotiveapplied_debit.Clear();
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit, null, 
                        GetData.MergeFilters(QHS.CmpEq("idaccmotive", CurrRow["idaccmotive_debit"]),DS.accmotiveapplied_debit), 
                    null, false);
                DataRow CDeb = DS.accmotiveapplied_debit.Rows[0];
                txtCodiceCausaleDebito.Text = CDeb["codemotive"].ToString();
                txtDenomCausaleDebito.Text = CDeb["motive"].ToString();
            }

            if (DS.registry.Rows.Count==0){
				LeggiDatiSuCredDeb(CurrRow["idreg"].ToString());
			}
			if (DS.registry.Rows.Count>0){
				DataRow CredDeb= DS.registry.Rows[0];
                txtCredDeb.Text = CredDeb["title"].ToString();
			}

			//Meta.myHelpForm.FillControls(tabMovFin.Controls);
			IvaLinkedMustBeEvalued=true;
			RintracciaIva();
			SetComboCausaleIva(NewIvaR);
			AbilitaDisabilitaControlliIva(true);
			AbilitaDisabilitaCreditoreDebitore(false);

		}

		void ScollegaIva(){
			ScollegaIva(false);
		}

		void ScollegaIva(bool skiptipodoc){
			ResetIva();
			if (DS.pettycashoperationinvoice.Rows.Count==0) 	{
				AbilitaDisabilitaControlliIva(false);
				return;
			}
			DS.pettycashoperationinvoice.Clear();
			DS.invoice.Clear();
			ClearComboCausale();
			DataRow CurrRow= DS.pettycashoperation.Rows[0];
			CurrRow["idreg"] = DBNull.Value;
			DS.registry.Clear();
            txtCredDeb.Text = "";	
//			CurrRow["amount"] = DBNull.Value;
//			txtImporto.Text="";
//			txtImporto.ReadOnly=false;
			AbilitaDisabilitaControlliIva(false);

			CurrRow["doc"] = DBNull.Value;
			CurrRow["docdate"] = DBNull.Value;
			//CurrRow["codiceresponsabile"]=DBNull.Value;
			CurrRow["description"]="";
            CurrRow["start"] = DBNull.Value;
            CurrRow["stop"] = DBNull.Value;
			ClearControlliIva(skiptipodoc);
		}

		#endregion

		#region Gestione ComboBox Causale Iva


		decimal totimponibile_dociva;
		decimal totiva_dociva;
		decimal assigned_imponibile_dociva;
		decimal assigned_iva_dociva;
		decimal assigned_gen_dociva;



		void SetEditComboCausaleIva(){
			if (!Meta.EditMode)return;
			ClearComboCausale();
			EnableTipoMovimento(1,"Contabilizzazione importo totale documento");
			//EnableTipoMovimento("IMPON","Contabilizzazione imponibile documento");
			//EnableTipoMovimento("IMPOS","Contabilizzazione iva documento");
			//cmbCausale.SelectedValue= DS.Tables["ordinegenericomovspesa"].Rows[0]["tipomovimento"].ToString();
			int currtipo = 1; //ex 4
			HelpForm.SetComboBoxValue(cmbCausale, currtipo);

		}
		
		


		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleIva(DataRow Ordine){
			DataAccess Conn= Meta.Conn;
			string filteriva = 
				"(idinvkind="+QueryCreator.quotedstrvalue( Ordine["idinvkind"],true)+")AND"+
				"(yinv='"+Ordine["yinv"].ToString()+"')AND"+
				"(ninv='"+Ordine["ninv"].ToString()+"')";

			
			DataTable T= Conn.RUN_SELECT("invoiceresidual","*",null,filteriva,null,true);
			if ((T!=null)&&(T.Rows.Count>0)){
				DataRow R=T.Rows[0];
				totimponibile_dociva=CfgFn.GetNoNullDecimal( R["taxabletotal"]);
				totiva_dociva=CfgFn.GetNoNullDecimal( R["ivatotal"]);
				assigned_imponibile_dociva= CfgFn.GetNoNullDecimal( R["linkedimpon"]);
				assigned_iva_dociva= CfgFn.GetNoNullDecimal( R["linkedimpos"]);
				assigned_gen_dociva=CfgFn.GetNoNullDecimal( R["linkeddocum"]);

			}
			else {
				totimponibile_dociva= 0;
				totiva_dociva =  0;
				assigned_imponibile_dociva= 0;
				assigned_iva_dociva= 0;
				assigned_gen_dociva= 0;
			}

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;

			if ((Meta.EditMode) || 
				((assigned_imponibile_dociva+assigned_iva_dociva)==0) && 
				(assigned_gen_dociva< (totimponibile_dociva+totiva_dociva))
				){
				EnableTipoMovimento(1,"Contabilizzazione importo totale documento");
			}

//			if ((Meta.EditMode) || 
//				( (assigned_gen_dociva==0) &&(assigned_imponibile_dociva < totimponibile_dociva))
//				){
//				EnableTipoMovimento("IMPON","Contabilizzazione imponibile documento");
//			}
//
//			if ( (Meta.EditMode) || 
//				( (assigned_gen_dociva==0) &&(assigned_iva_dociva< totiva_dociva))
//				){
//				EnableTipoMovimento("IMPOS","Contabilizzazione iva documento");
//			}
			//DS.pettycashoperationinvoice.Rows[0]["movkind"]=	 cmbCausale.SelectedValue;
			cmbCausale.Enabled=!(Meta.EditMode);
			ReCalcImporto_Iva();
			
		}



		void ReCalcImporto_Iva(){
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.pettycashoperation.Rows[0];
			if (cmbCausale.SelectedValue==null) return;

			int tipomovimento = CfgFn.GetNoNullInt32( cmbCausale.SelectedValue);

			decimal importo=0;
//			if (tipomovimento=="IMPOS"){
//				importo= totiva_dociva-assigned_iva_dociva;
//			}
//			if (tipomovimento=="IMPON"){
//				importo= totimponibile_dociva-assigned_imponibile_dociva;
//			}
			if (tipomovimento==1){
				importo= totimponibile_dociva+totiva_dociva-assigned_gen_dociva;
			}


			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;
	
			SetImporto(importo);
			txtImporto.Text= importo.ToString("c");

		}

		private void cmbCausaleIva_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.InsertMode) return;
			GetCausaleIva();
			ReCalcImporto_Iva();
		}

		int GetCausaleIva(){
			CurrCausaleIva= 0;
			if (!Meta.InsertMode) return 0;
			if (DS.pettycashoperationinvoice.Rows.Count==0) return 0;
			CurrCausaleIva= 4;
			return CurrCausaleIva;
			//ReCalcImporto();
		}


		void UpdateComboCausaleIva(){
			if (IvaMovSpesaLinked!=null){
				int currtipo = 4;
				HelpForm.SetComboBoxValue(cmbCausale, currtipo);
			}
		}


		bool TipoDocChangePilotato=false;
		private void cmbTipoDocumento_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (TipoDocChangePilotato) return;
			TipoDocChangePilotato=true;
			if (Meta.InsertMode) ScollegaIva(true);
			ClearControlliIva(true);
			txtEsercDoc.Text="";
			txtNumDoc.Text="";
			TipoDocChangePilotato=false;
		}

		#endregion



		#region Reset / Rintraccia documenti
		void ResetMissione(){
			MissionLinkedMustBeEvalued=true;
			MissionLinked=null;
			MissioneMovSpesaLinked=null;
			lastMissEvalued=null;
		}
		void RintracciaMissione(){
			if (!MissionLinkedMustBeEvalued)return;
			GetDocMissione(out MissionLinked, 
				out MissioneMovSpesaLinked, 
				out CurrCausaleMissione);
			if (MissionLinked!=null){
				CalcolaContabilizzatiMissione(MissionLinked);
			}
			MissionLinkedMustBeEvalued=false;
		}

		void ResetOccasionale(){
			OccasionaleLinkedMustBeEvalued=true;
			OccasionaleLinked=null;
			OccasionaleMovSpesaLinked=null;
			lastOccEvalued=null;
		}

		void RintracciaOccasionale(){
			if (!OccasionaleLinkedMustBeEvalued)return;
			GetDocOccasionale(out OccasionaleLinked, 
				out OccasionaleMovSpesaLinked, 
				out CurrCausaleOccasionale);
			if (OccasionaleLinked!=null){
				CalcolaContabilizzatiOccasionale(OccasionaleLinked);
			}
			OccasionaleLinkedMustBeEvalued=false;
		}

		void ResetProfessionale(){
			ProfessionaleLinkedMustBeEvalued=true;
			ProfessionaleLinked=null;
			ProfessionaleMovSpesaLinked=null;
			lastProfEvalued=null;
		}

		void RintracciaProfessionale(){
			if (!ProfessionaleLinkedMustBeEvalued)return;
			GetDocProfessionale(out ProfessionaleLinked, 
				out ProfessionaleMovSpesaLinked, 
				out CurrCausaleProfessionale);
			if (ProfessionaleLinked!=null){
				CalcolaContabilizzatiProfessionale(ProfessionaleLinked);
			}
			ProfessionaleLinkedMustBeEvalued=false;
		}



		void ResetIva(){
			IvaLinkedMustBeEvalued=true;
			IvaLinked=null;
			IvaMovSpesaLinked=null;
		}

		void RintracciaIva(){
			if (!IvaLinkedMustBeEvalued)return;
			GetDocIva(out IvaLinked, 
				out IvaMovSpesaLinked, 
				out CurrCausaleIva);
			if (IvaLinked!=null){
				//CalcolaContabilizzatiMissione(MissionLinked);
			}
			IvaLinkedMustBeEvalued=false;
		}

		#endregion


		void LeggiDatiSuCredDeb(string codicecredddeb){
			if (codicecredddeb=="") return;
			QueryCreator.MyClear( DS.registry);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.registry, null,
				"(idreg="+QueryCreator.quotedstrvalue(codicecredddeb,true)+")",null,true);
		}

		void SetImporto(decimal Importo){
           
			DataRow R = DS.pettycashoperation.Rows[0];
			R["amount"]= Importo;
			txtImporto.Text= HelpForm.StringValue(
				Importo, txtImporto.Tag.ToString());
			//MetaData_AfterGetFormData();
		}

        
		
       
        Dictionary<int, decimal> ottieniImportiImpegnoDaTabella(DataTable t, string fieldIdEpExp, string fieldAmount) {
            Dictionary<int, decimal> importiImpegno = new Dictionary<int, decimal>();
            foreach (DataRow r in t.Select()) {
                int idepexp = CfgFn.GetNoNullInt32(r[fieldIdEpExp]);
                decimal amount = CfgFn.GetNoNullDecimal(r[fieldAmount]);
                if (importiImpegno.ContainsKey(idepexp)) {
                    importiImpegno[idepexp] += amount;
                }
                else {
                    importiImpegno[idepexp] = amount;
                }
            }
            return importiImpegno;
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

        void aggiornaImporti(Dictionary<int, decimal> valori, int id, decimal valore) {
            if (valori.ContainsKey(id)) {
                valori[id] += valore;
            }
            else {
                valori[id] = valore;
            }
        }

	    Dictionary<int, decimal> getImportiFattura(object idinvkind, object yinv, object ninv) {
	        Dictionary<int, decimal> importiImpegno = new Dictionary<int, decimal>();

	        //Vede se è contabilizzazione fattura
	        DataTable dettFattura = Meta.Conn.RUN_SELECT("invoicedetailview", "idepexp,taxable_euro", null,
	            QHS.AppAnd(QHS.CmpEq("idinvkind", idinvkind), QHS.CmpEq("yinv", yinv), QHS.CmpEq("ninv", "ninv")), null,
	            false);
	        if (dettFattura != null && dettFattura.Rows.Count > 0) {
	            double abatablerate = CfgFn.GetNoNullDouble(Meta.Conn.DO_READ_VALUE("invoicekindyearview",
	                QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.CmpEq("idinvkind", dettFattura.Rows[0]["idinvkind"])),
	                "abatablerate"));
	            foreach (DataRow rDett in dettFattura.Select()) {
	                double imponibile = CfgFn.GetNoNullDouble(rDett["taxable_euro"]);
	                double iva = CfgFn.GetNoNullDouble(rDett["iva_eur"]);
	                double ivaIndetraibileLorda = CfgFn.GetNoNullDouble(rDett["unabatable_euro"]);
	                double ivaDetraibileLorda = iva - ivaIndetraibileLorda;
	                double ivaDetraibile = CfgFn.RoundValuta(ivaDetraibileLorda*abatablerate);
	                double ivaIndetraibile = iva - ivaDetraibile;
	                decimal imponibileDec = Convert.ToDecimal(imponibile);
	                decimal ivaIndetraibileDec = Convert.ToDecimal(ivaIndetraibile);
	                //Se 1 totale 2 tot.iva 3 imponibile  
	                //Se è split va saltata? no
	                decimal amount = imponibileDec + ivaIndetraibileDec;
	                aggiornaImporti(importiImpegno, CfgFn.GetNoNullInt32(rDett["idepexp"]), amount);
	            }
	        }
	        return importiImpegno;
	    }
        

		
		public void MetaData_BeforePost() {
		    EPM.beforePost();

		}

		public void MetaData_AfterPost() {
		    EPM.afterPost();
		}
		


		
		
		

		private void chkDocumentata_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			EnableDisableDocumenti(chkDocumentata.Checked);
		}

        private void chkOpSpesa_CheckStateChanged (object sender, EventArgs e) {
            bool isChecked = (chkOpSpesa.CheckState == CheckState.Checked);
            if (isChecked)
            {
                chkApertura.Checked = !isChecked;
                chkChiusura.Checked = !isChecked;
                chkReintegro.Checked = !isChecked;
                grpNList.Visible = true;
            }
            else
            {
                grpNList.Visible = false;
                txtNList.Text = "";
            }
        }

        private void chkApertura_CheckStateChanged (object sender, EventArgs e) {
            bool isChecked = (chkApertura.CheckState == CheckState.Checked);
            if (isChecked) {
                chkOpSpesa.Checked = !isChecked;
                chkChiusura.Checked = !isChecked;
                chkReintegro.Checked = !isChecked;
            }
        }

        private void chkChiusura_CheckStateChanged (object sender, EventArgs e) {
            bool isChecked = (chkChiusura.CheckState == CheckState.Checked);
            if (isChecked) {
                chkApertura.Checked = !isChecked;
                chkOpSpesa.Checked = !isChecked;
                chkReintegro.Checked = !isChecked;
            }
        }

        private void chkReintegro_CheckStateChanged (object sender, EventArgs e) {
            bool isChecked = (chkReintegro.CheckState == CheckState.Checked);
            if (isChecked) {
                chkApertura.Checked = !isChecked;
                chkChiusura.Checked = !isChecked;
                chkOpSpesa.Checked = !isChecked;
            }
        }

        private void txtNum_Leave (object sender, EventArgs e) {
           
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.pettycashoperation.Rows[0];
            if ((Curr["idexp"]!=DBNull.Value)&&(txtNum.Text.Trim() == "")) {
                DS.expenseview.Clear();
                Curr["idexp"] = DBNull.Value;
            } 
            btnSpesa_Click(sender, e);
        }

        private void txtEserc_Leave (object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEserc);
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.pettycashoperation.Rows[0];
            if  (Curr["idexp"]!=DBNull.Value) {
                if (txtEserc.Text.Trim() == "") {
                    txtNum.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp"] = DBNull.Value;
                }
                else {
                    int oldYmov = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["ymov"]);
                    int newYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
                    if (oldYmov != newYmov) {
                        txtNum.Text = "";
                        DS.expenseview.Clear();
                        Curr["idexp"] = DBNull.Value;
                    }
                }
             
            }
            
        }

	    private bool cambioFasePilotato = false;
        private void cmbFaseSpesa_SelectedIndexChanged (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (cambioFasePilotato) return;
            DataRow Curr = DS.pettycashoperation.Rows[0];
            if (Curr["idexp"] != DBNull.Value) {
                if (DS.expenseview.Rows.Count == 0) {
                    Conn.RUN_SELECT_INTO_TABLE(DS.expenseview, null,
                        QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp"]), QHS.CmpEq("ayear", Conn.GetEsercizio())), null,
                        false);
                }

                int oldNphase = 0;
                if (DS.expenseview.Rows.Count>0) oldNphase= CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["nphase"]);
                int newNPhase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
                if (oldNphase != newNPhase) {
                    txtNum.Text = "";
                    txtEserc.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp"] = DBNull.Value;
                }
            }
        }
        void CalcTotFinanziamenti()
        {
            if (Meta.IsEmpty)
            {
                txtTotFinanziato.Text = "";
                return;
            }
            decimal tot = MetaData.SumColumn(DS.pettycashoperationunderwriting, "amount");
            txtTotFinanziato.Text = tot.ToString("c");
        }

        private void btnBolletta_Click(object sender, EventArgs e) {

        }

        private void btnGeneraClassAutomatiche_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            if (DS.pettycashoperationsorted.Select().Length > 0) {
                if (MessageBox.Show("Cancello le classificazioni esistenti?",
                    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    foreach (DataRow R in DS.pettycashoperationsorted.Select()) {
                        R.Delete();
                    }
                }
            }
            string newcomputesorting = Meta.Conn.DO_READ_VALUE("siopekind", QHC.CmpEq("codesorkind_siopespese", Meta.GetSys("codesorkind_siopespese")), "newcomputesorting").ToString();
            if (newcomputesorting == "S"){
                //Classifica il movimento in base all'idsor_siope specificato nel documento contabilizzato
                ManageClassificazioni = new GestioneClassificazioni(Meta, null, null, null, null, null, null, null, null);
                ManageClassificazioni.ClassificaTramiteClassDocumento(DS, null);
            }
        }
    }
}