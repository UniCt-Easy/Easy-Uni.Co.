
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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using ep_functions;
using System.Collections.Generic;
using q = metadatalibrary.MetaExpression;

namespace mandatedetail_single//dettordinegenericosingle//
{
	/// <summary>
	/// Summary description for frmdettordinegenericosingle.
	/// </summary>
	public class Frm_mandatedetail_single : MetaDataForm
	{
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Label lblidunit;
		private System.Windows.Forms.TextBox txtQuantita;
		private System.Windows.Forms.TextBox txtImponibile;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lblImportoUnitario;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
		public dsmeta DS;
		private System.Windows.Forms.TextBox txtIvaEUR;
		private System.Windows.Forms.TextBox txtImponibileEUR;
		private System.Windows.Forms.TextBox txtAppunti;
		public object codicevaluta;
		public double tassocambio;
		private double aliquota=0;
		private double percindeduc=0;
		public object codiceresponsabile;
        CQueryHelper QHC;
        QueryHelper QHS;
        public bool GruppiDisabilitati = false;
        private System.Windows.Forms.TextBox txtSconto;
		private System.Windows.Forms.GroupBox grpValoreUnitInValuta;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnClassif;
		private System.Windows.Forms.TextBox txtCodClassif;
		private System.Windows.Forms.TextBox txtDescClassif;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtResiduo;
		private System.Windows.Forms.GroupBox gboxIVA;
        private System.Windows.Forms.GroupBox gboxImponibile;
		private System.Windows.Forms.TextBox txtNumeroIva;
		private System.Windows.Forms.TextBox txtEsercizioIva;
		private System.Windows.Forms.TextBox txtNumImponibile;
		private System.Windows.Forms.TextBox txtEsercizioImponibile;
        private System.Windows.Forms.GroupBox gboxUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.Button btnUPBCode;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnCodice;
		private System.Windows.Forms.TabPage tabFatturazione;
        public System.Windows.Forms.GroupBox gboxclass1;
        public TextBox txtDenom1;
        public TextBox txtCodice1;
		public System.Windows.Forms.Button btnCodice1;
		public System.Windows.Forms.GroupBox gboxclass2;
        public System.Windows.Forms.Button btnCodice2;
        public TextBox txtDenom2;
        public TextBox txtCodice2;
		private System.Windows.Forms.TabPage tabAnalitico;
		public System.Windows.Forms.GroupBox gboxclass3;
        public System.Windows.Forms.Button btnCodice3;
        public TextBox txtDenom3;
        public TextBox txtCodice3;
		private System.Windows.Forms.Button btnUPB;
		private System.Windows.Forms.GroupBox grpInventario;
        private System.Windows.Forms.TextBox txtNInvoiced;
		private System.Windows.Forms.RadioButton radioServizi;
		private System.Windows.Forms.RadioButton radioInvent;
        private System.Windows.Forms.RadioButton radioNonInvent;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox TxtImponibileValutaTot;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtDescrizioneCausale;
		private System.Windows.Forms.TextBox txtCodiceCausale;
		private System.Windows.Forms.Button btnCausaleEP;
		private System.Windows.Forms.GroupBox grpTipoIva;
		private System.Windows.Forms.Button btnTipo;
		private System.Windows.Forms.ComboBox cmbTipoIVA;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtPercIndeduc;
		private System.Windows.Forms.TextBox txtImpDeducEUR;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.CheckBox chkPromiscuo;
		private System.Windows.Forms.TextBox txtTaxRate;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox grpRegistry;
		private System.Windows.Forms.TextBox txtStart;
		private System.Windows.Forms.TextBox txtStop;
		private System.Windows.Forms.GroupBox grpTipoBene;
		private System.Windows.Forms.GroupBox grpCausale;
		private System.Windows.Forms.Button btnCalcoloSconto;
        private GroupBox grpCausaleAnnullamento;
        private TextBox textBox2;
        private TextBox txtCodiceCausaleAnnullamento;
        private Button btnCausaleAnnullamento;
        private RadioButton rdbIstituzionale;
        private RadioButton rdbQualsiasi;
        private RadioButton rdbCommerciale;
        private GroupBox grpAttivita;
        private GroupBox groupBox1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private Label label17;
        private TextBox textBox6;
        private GroupBox gboxListino;
        private TextBox txtCoeffConversione;
        private Label label20;
        private ComboBox cmbUnitaMisuraAcquisto;
        private Label lblIcmbdpackage;
        private Label label25;
        private ComboBox cmbUnitaMisuraCS;
        private CheckBox chkListDescription;
        private Button btnListino;
        private TextBox txtListino;
        private TextBox txtDescrizioneListino;
        private TextBox txtQuantitaConfezioni;
        private Label lblidpackage;
        private TabPage tabMagazzino;
        private Label label1;
        private DataGrid dgrDettMagazzino;
        private RadioButton rdbAltro;
        private Label label18;
        private TextBox txtCupCode;
        private TabPage tabPage5;
        private Label lblcig;
        private CheckBox chktounload;
        private RadioButton rdbPromiscua;
        private RadioButton radioMagazzino;
        public TextBox txtUPB;
        private GroupBox gboxCompetenzaEconomica;
        private TextBox txtEPStart;
        private Label label7;
        private RadioButton rdEPKind_F;
        private RadioButton rdEPKind_R;
        private TextBox txtEPStop;
        private Label label8;
        private RadioButton rdEPKind_N;
        private ComboBox cmbCIG;
        private TabPage tabPCC;
        public GroupBox grpRipartizioneCosti;
        public Button button3;
        public TextBox textBox1;
        public TextBox txtCodiceRipartizione;
        private GroupBox grpPcc;
        private Button btnCasuale;
        private TextBox txtCausale;
        private Label label30;
        private ComboBox cmbStatodelDebito;
        private GroupBox grpNaturadiSpesa;
        private RadioButton rdbContoCapitale;
        private RadioButton rdbSpesaCorrente;
        private GroupBox grpBoxAccertamentiBudget;
        private Button btnRemoveEpAcc;
        private Button btnLinkEpAcc;
        private Label label11;
        private Label label12;
        private TextBox txtNumAccBudget;
        private TextBox txtEsercAccBudget;
        private GroupBox grpBoxImpegniBudget;
        private Label label34;
        private Label label33;
        private TextBox txtNumIxBudget;
        private TextBox txtEsercIxBudget;
        private GroupBox grpAutoLocation;
        private Button btnUbicazione;
        private TextBox txtDescUbicazione;
        private TextBox txtUbicazione;
        private GroupBox gBoxupbIVA;
        public TextBox txtUPBiva;
        private Label label14;
        private Button buttonupbIVA;
        private TextBox textBox3;
        private GroupBox grpBoxSiopeEP;
        private TextBox txtDescSiope;
        private TextBox txtCodSiope;
        private Button btnSiope;
        private Button btnSuggerimento;
        private GroupBox groupBox3;
        private Button btnScollegaPreimpegno;
        private Button btnCollegaPreimpegno;
        private Label label15;
        private Label label24;
        private TextBox txtNumPreimpegno;
        private TextBox txtEsercPreImpegno;
        private TextBox txtPrezzounitarioListino;
        private Label label26;
		private GroupBox gboxPagato;
		private TextBox txtPagato;
		private TabPage tabPrincipale;
		MetaData Meta;

		public Frm_mandatedetail_single()
		{
			InitializeComponent();

			
		}
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
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
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.lblidunit = new System.Windows.Forms.Label();
			this.txtQuantita = new System.Windows.Forms.TextBox();
			this.grpValoreUnitInValuta = new System.Windows.Forms.GroupBox();
			this.label19 = new System.Windows.Forms.Label();
			this.TxtImponibileValutaTot = new System.Windows.Forms.TextBox();
			this.txtSconto = new System.Windows.Forms.TextBox();
			this.txtImponibile = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.lblImportoUnitario = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtImpDeducEUR = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtIvaEUR = new System.Windows.Forms.TextBox();
			this.txtImponibileEUR = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAppunti = new System.Windows.Forms.TextBox();
			this.grpInventario = new System.Windows.Forms.GroupBox();
			this.txtDescClassif = new System.Windows.Forms.TextBox();
			this.txtCodClassif = new System.Windows.Forms.TextBox();
			this.btnClassif = new System.Windows.Forms.Button();
			this.grpTipoBene = new System.Windows.Forms.GroupBox();
			this.radioMagazzino = new System.Windows.Forms.RadioButton();
			this.rdbAltro = new System.Windows.Forms.RadioButton();
			this.radioServizi = new System.Windows.Forms.RadioButton();
			this.radioInvent = new System.Windows.Forms.RadioButton();
			this.radioNonInvent = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtStart = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtStop = new System.Windows.Forms.TextBox();
			this.gboxIVA = new System.Windows.Forms.GroupBox();
			this.txtNumeroIva = new System.Windows.Forms.TextBox();
			this.txtEsercizioIva = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtNInvoiced = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtResiduo = new System.Windows.Forms.TextBox();
			this.gboxImponibile = new System.Windows.Forms.GroupBox();
			this.txtNumImponibile = new System.Windows.Forms.TextBox();
			this.txtEsercizioImponibile = new System.Windows.Forms.TextBox();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.btnUPB = new System.Windows.Forms.Button();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.DS = new mandatedetail_single.dsmeta();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.grpRegistry = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.gboxListino = new System.Windows.Forms.GroupBox();
			this.txtPrezzounitarioListino = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.txtCoeffConversione = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.cmbUnitaMisuraAcquisto = new System.Windows.Forms.ComboBox();
			this.lblIcmbdpackage = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.cmbUnitaMisuraCS = new System.Windows.Forms.ComboBox();
			this.chkListDescription = new System.Windows.Forms.CheckBox();
			this.btnListino = new System.Windows.Forms.Button();
			this.txtListino = new System.Windows.Forms.TextBox();
			this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
			this.txtQuantitaConfezioni = new System.Windows.Forms.TextBox();
			this.lblidpackage = new System.Windows.Forms.Label();
			this.chkPromiscuo = new System.Windows.Forms.CheckBox();
			this.btnSuggerimento = new System.Windows.Forms.Button();
			this.gboxPagato = new System.Windows.Forms.GroupBox();
			this.txtPagato = new System.Windows.Forms.TextBox();
			this.grpAttivita = new System.Windows.Forms.GroupBox();
			this.rdbPromiscua = new System.Windows.Forms.RadioButton();
			this.rdbCommerciale = new System.Windows.Forms.RadioButton();
			this.rdbQualsiasi = new System.Windows.Forms.RadioButton();
			this.rdbIstituzionale = new System.Windows.Forms.RadioButton();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.grpTipoIva = new System.Windows.Forms.GroupBox();
			this.btnTipo = new System.Windows.Forms.Button();
			this.cmbTipoIVA = new System.Windows.Forms.ComboBox();
			this.txtTaxRate = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.txtPercIndeduc = new System.Windows.Forms.TextBox();
			this.btnCalcoloSconto = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gBoxupbIVA = new System.Windows.Forms.GroupBox();
			this.txtUPBiva = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.buttonupbIVA = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.cmbCIG = new System.Windows.Forms.ComboBox();
			this.lblcig = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.txtCupCode = new System.Windows.Forms.TextBox();
			this.tabAnalitico = new System.Windows.Forms.TabPage();
			this.grpRipartizioneCosti = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtCodiceRipartizione = new System.Windows.Forms.TextBox();
			this.gboxclass3 = new System.Windows.Forms.GroupBox();
			this.btnCodice3 = new System.Windows.Forms.Button();
			this.txtDenom3 = new System.Windows.Forms.TextBox();
			this.txtCodice3 = new System.Windows.Forms.TextBox();
			this.gboxclass2 = new System.Windows.Forms.GroupBox();
			this.btnCodice2 = new System.Windows.Forms.Button();
			this.txtDenom2 = new System.Windows.Forms.TextBox();
			this.txtCodice2 = new System.Windows.Forms.TextBox();
			this.gboxclass1 = new System.Windows.Forms.GroupBox();
			this.btnCodice1 = new System.Windows.Forms.Button();
			this.txtDenom1 = new System.Windows.Forms.TextBox();
			this.txtCodice1 = new System.Windows.Forms.TextBox();
			this.tabFatturazione = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label13 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.grpAutoLocation = new System.Windows.Forms.GroupBox();
			this.btnUbicazione = new System.Windows.Forms.Button();
			this.txtDescUbicazione = new System.Windows.Forms.TextBox();
			this.txtUbicazione = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnScollegaPreimpegno = new System.Windows.Forms.Button();
			this.btnCollegaPreimpegno = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.txtNumPreimpegno = new System.Windows.Forms.TextBox();
			this.txtEsercPreImpegno = new System.Windows.Forms.TextBox();
			this.grpBoxSiopeEP = new System.Windows.Forms.GroupBox();
			this.btnSiope = new System.Windows.Forms.Button();
			this.txtDescSiope = new System.Windows.Forms.TextBox();
			this.txtCodSiope = new System.Windows.Forms.TextBox();
			this.grpBoxAccertamentiBudget = new System.Windows.Forms.GroupBox();
			this.btnRemoveEpAcc = new System.Windows.Forms.Button();
			this.btnLinkEpAcc = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtNumAccBudget = new System.Windows.Forms.TextBox();
			this.txtEsercAccBudget = new System.Windows.Forms.TextBox();
			this.grpBoxImpegniBudget = new System.Windows.Forms.GroupBox();
			this.label34 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.txtNumIxBudget = new System.Windows.Forms.TextBox();
			this.txtEsercIxBudget = new System.Windows.Forms.TextBox();
			this.gboxCompetenzaEconomica = new System.Windows.Forms.GroupBox();
			this.rdEPKind_N = new System.Windows.Forms.RadioButton();
			this.rdEPKind_F = new System.Windows.Forms.RadioButton();
			this.rdEPKind_R = new System.Windows.Forms.RadioButton();
			this.txtEPStop = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtEPStart = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.grpCausaleAnnullamento = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleAnnullamento = new System.Windows.Forms.TextBox();
			this.btnCausaleAnnullamento = new System.Windows.Forms.Button();
			this.grpCausale = new System.Windows.Forms.GroupBox();
			this.txtDescrizioneCausale = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.btnCausaleEP = new System.Windows.Forms.Button();
			this.tabMagazzino = new System.Windows.Forms.TabPage();
			this.chktounload = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgrDettMagazzino = new System.Windows.Forms.DataGrid();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.tabPCC = new System.Windows.Forms.TabPage();
			this.grpPcc = new System.Windows.Forms.GroupBox();
			this.grpNaturadiSpesa = new System.Windows.Forms.GroupBox();
			this.rdbContoCapitale = new System.Windows.Forms.RadioButton();
			this.rdbSpesaCorrente = new System.Windows.Forms.RadioButton();
			this.btnCasuale = new System.Windows.Forms.Button();
			this.txtCausale = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.cmbStatodelDebito = new System.Windows.Forms.ComboBox();
			this.btnCodice = new System.Windows.Forms.Button();
			this.grpValoreUnitInValuta.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpInventario.SuspendLayout();
			this.grpTipoBene.SuspendLayout();
			this.gboxIVA.SuspendLayout();
			this.gboxImponibile.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPrincipale.SuspendLayout();
			this.grpRegistry.SuspendLayout();
			this.gboxListino.SuspendLayout();
			this.gboxPagato.SuspendLayout();
			this.grpAttivita.SuspendLayout();
			this.grpTipoIva.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gBoxupbIVA.SuspendLayout();
			this.tabAnalitico.SuspendLayout();
			this.grpRipartizioneCosti.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.tabFatturazione.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.grpAutoLocation.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.grpBoxSiopeEP.SuspendLayout();
			this.grpBoxAccertamentiBudget.SuspendLayout();
			this.grpBoxImpegniBudget.SuspendLayout();
			this.gboxCompetenzaEconomica.SuspendLayout();
			this.grpCausaleAnnullamento.SuspendLayout();
			this.grpCausale.SuspendLayout();
			this.tabMagazzino.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettMagazzino)).BeginInit();
			this.tabPage5.SuspendLayout();
			this.tabPCC.SuspendLayout();
			this.grpPcc.SuspendLayout();
			this.grpNaturadiSpesa.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(7, 76);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrizione.Size = new System.Drawing.Size(472, 69);
			this.txtDescrizione.TabIndex = 2;
			this.txtDescrizione.Tag = "mandatedetail.detaildescription";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(7, 62);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 14);
			this.label6.TabIndex = 0;
			this.label6.Text = "Descrizione:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(810, 541);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 11;
			this.btnOK.TabStop = false;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(908, 541);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 12;
			this.btnAnnulla.TabStop = false;
			this.btnAnnulla.Text = "Annulla";
			// 
			// lblidunit
			// 
			this.lblidunit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblidunit.Location = new System.Drawing.Point(126, 255);
			this.lblidunit.Name = "lblidunit";
			this.lblidunit.Size = new System.Drawing.Size(131, 16);
			this.lblidunit.TabIndex = 16;
			this.lblidunit.Text = "Totale Quantità Ordinata:";
			this.lblidunit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtQuantita
			// 
			this.txtQuantita.Location = new System.Drawing.Point(129, 270);
			this.txtQuantita.Name = "txtQuantita";
			this.txtQuantita.ReadOnly = true;
			this.txtQuantita.Size = new System.Drawing.Size(88, 20);
			this.txtQuantita.TabIndex = 31;
			this.txtQuantita.TabStop = false;
			this.txtQuantita.Tag = "mandatedetail.number.N";
			this.txtQuantita.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
			// 
			// grpValoreUnitInValuta
			// 
			this.grpValoreUnitInValuta.Controls.Add(this.label19);
			this.grpValoreUnitInValuta.Controls.Add(this.TxtImponibileValutaTot);
			this.grpValoreUnitInValuta.Controls.Add(this.txtSconto);
			this.grpValoreUnitInValuta.Controls.Add(this.txtImponibile);
			this.grpValoreUnitInValuta.Controls.Add(this.label16);
			this.grpValoreUnitInValuta.Controls.Add(this.lblImportoUnitario);
			this.grpValoreUnitInValuta.Location = new System.Drawing.Point(437, 315);
			this.grpValoreUnitInValuta.Name = "grpValoreUnitInValuta";
			this.grpValoreUnitInValuta.Size = new System.Drawing.Size(287, 66);
			this.grpValoreUnitInValuta.TabIndex = 8;
			this.grpValoreUnitInValuta.TabStop = false;
			this.grpValoreUnitInValuta.Text = "Valore in valuta ";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(186, 23);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(93, 16);
			this.label19.TabIndex = 1;
			this.label19.Text = "Importo totale";
			// 
			// TxtImponibileValutaTot
			// 
			this.TxtImponibileValutaTot.Location = new System.Drawing.Point(187, 39);
			this.TxtImponibileValutaTot.Name = "TxtImponibileValutaTot";
			this.TxtImponibileValutaTot.ReadOnly = true;
			this.TxtImponibileValutaTot.Size = new System.Drawing.Size(88, 20);
			this.TxtImponibileValutaTot.TabIndex = 4;
			this.TxtImponibileValutaTot.TabStop = false;
			this.TxtImponibileValutaTot.Tag = "";
			this.TxtImponibileValutaTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSconto
			// 
			this.txtSconto.Location = new System.Drawing.Point(112, 39);
			this.txtSconto.Name = "txtSconto";
			this.txtSconto.Size = new System.Drawing.Size(64, 20);
			this.txtSconto.TabIndex = 3;
			this.txtSconto.Tag = "mandatedetail.discount.fixed.4..%.100";
			this.txtSconto.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
			// 
			// txtImponibile
			// 
			this.txtImponibile.Location = new System.Drawing.Point(8, 39);
			this.txtImponibile.Name = "txtImponibile";
			this.txtImponibile.Size = new System.Drawing.Size(88, 20);
			this.txtImponibile.TabIndex = 2;
			this.txtImponibile.Tag = "mandatedetail.taxable.fixed.5...1";
			this.txtImponibile.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(110, 22);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 16);
			this.label16.TabIndex = 36;
			this.label16.Text = "Sconto:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblImportoUnitario
			// 
			this.lblImportoUnitario.Location = new System.Drawing.Point(8, 20);
			this.lblImportoUnitario.Name = "lblImportoUnitario";
			this.lblImportoUnitario.Size = new System.Drawing.Size(88, 19);
			this.lblImportoUnitario.TabIndex = 34;
			this.lblImportoUnitario.Text = "Importo unitario:";
			this.lblImportoUnitario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtImpDeducEUR);
			this.groupBox2.Controls.Add(this.label23);
			this.groupBox2.Controls.Add(this.txtIvaEUR);
			this.groupBox2.Controls.Add(this.txtImponibileEUR);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(437, 243);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(287, 66);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Valore totale in EUR";
			// 
			// txtImpDeducEUR
			// 
			this.txtImpDeducEUR.Location = new System.Drawing.Point(184, 30);
			this.txtImpDeducEUR.Name = "txtImpDeducEUR";
			this.txtImpDeducEUR.Size = new System.Drawing.Size(88, 20);
			this.txtImpDeducEUR.TabIndex = 3;
			this.txtImpDeducEUR.Tag = "mandatedetail.unabatable";
			this.txtImpDeducEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(184, 14);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(88, 16);
			this.label23.TabIndex = 48;
			this.label23.Text = "Iva indetraibile";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtIvaEUR
			// 
			this.txtIvaEUR.Location = new System.Drawing.Point(104, 30);
			this.txtIvaEUR.Name = "txtIvaEUR";
			this.txtIvaEUR.Size = new System.Drawing.Size(72, 20);
			this.txtIvaEUR.TabIndex = 2;
			this.txtIvaEUR.Tag = "mandatedetail.tax.fixed.2...1";
			this.txtIvaEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIvaEUR.TextChanged += new System.EventHandler(this.TxtIvaValutaTot_TextChanged);
			// 
			// txtImponibileEUR
			// 
			this.txtImponibileEUR.Location = new System.Drawing.Point(8, 30);
			this.txtImponibileEUR.Name = "txtImponibileEUR";
			this.txtImponibileEUR.ReadOnly = true;
			this.txtImponibileEUR.Size = new System.Drawing.Size(88, 20);
			this.txtImponibileEUR.TabIndex = 1;
			this.txtImponibileEUR.TabStop = false;
			this.txtImponibileEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(104, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 35;
			this.label3.Text = "IVA:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 34;
			this.label4.Text = "Imponibile:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAppunti
			// 
			this.txtAppunti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAppunti.Location = new System.Drawing.Point(6, 21);
			this.txtAppunti.Multiline = true;
			this.txtAppunti.Name = "txtAppunti";
			this.txtAppunti.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtAppunti.Size = new System.Drawing.Size(949, 470);
			this.txtAppunti.TabIndex = 19;
			this.txtAppunti.Tag = "mandatedetail.annotations";
			// 
			// grpInventario
			// 
			this.grpInventario.Controls.Add(this.txtDescClassif);
			this.grpInventario.Controls.Add(this.txtCodClassif);
			this.grpInventario.Controls.Add(this.btnClassif);
			this.grpInventario.Location = new System.Drawing.Point(159, 20);
			this.grpInventario.Name = "grpInventario";
			this.grpInventario.Size = new System.Drawing.Size(390, 104);
			this.grpInventario.TabIndex = 2;
			this.grpInventario.TabStop = false;
			this.grpInventario.Tag = "AutoManage.txtCodClassif.tree";
			this.grpInventario.Text = "Inventario";
			// 
			// txtDescClassif
			// 
			this.txtDescClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescClassif.Location = new System.Drawing.Point(118, 16);
			this.txtDescClassif.Multiline = true;
			this.txtDescClassif.Name = "txtDescClassif";
			this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescClassif.Size = new System.Drawing.Size(264, 48);
			this.txtDescClassif.TabIndex = 2;
			this.txtDescClassif.Tag = "inventorytreeview.description";
			// 
			// txtCodClassif
			// 
			this.txtCodClassif.Location = new System.Drawing.Point(6, 72);
			this.txtCodClassif.Name = "txtCodClassif";
			this.txtCodClassif.Size = new System.Drawing.Size(376, 20);
			this.txtCodClassif.TabIndex = 9;
			this.txtCodClassif.Tag = "inventorytreeview.codeinv?x";
			// 
			// btnClassif
			// 
			this.btnClassif.Location = new System.Drawing.Point(6, 40);
			this.btnClassif.Name = "btnClassif";
			this.btnClassif.Size = new System.Drawing.Size(88, 23);
			this.btnClassif.TabIndex = 3;
			this.btnClassif.TabStop = false;
			this.btnClassif.Tag = "manage.inventorytreeview.tree";
			this.btnClassif.Text = "Classificazione";
			// 
			// grpTipoBene
			// 
			this.grpTipoBene.Controls.Add(this.radioMagazzino);
			this.grpTipoBene.Controls.Add(this.rdbAltro);
			this.grpTipoBene.Controls.Add(this.radioServizi);
			this.grpTipoBene.Controls.Add(this.radioInvent);
			this.grpTipoBene.Controls.Add(this.radioNonInvent);
			this.grpTipoBene.Location = new System.Drawing.Point(7, 20);
			this.grpTipoBene.Name = "grpTipoBene";
			this.grpTipoBene.Size = new System.Drawing.Size(146, 186);
			this.grpTipoBene.TabIndex = 1;
			this.grpTipoBene.TabStop = false;
			this.grpTipoBene.Text = "Tipo bene";
			// 
			// radioMagazzino
			// 
			this.radioMagazzino.Location = new System.Drawing.Point(8, 114);
			this.radioMagazzino.Name = "radioMagazzino";
			this.radioMagazzino.Size = new System.Drawing.Size(100, 17);
			this.radioMagazzino.TabIndex = 10;
			this.radioMagazzino.Tag = "mandatedetail.assetkind:M";
			this.radioMagazzino.Text = "Magazzino";
			// 
			// rdbAltro
			// 
			this.rdbAltro.Location = new System.Drawing.Point(8, 144);
			this.rdbAltro.Name = "rdbAltro";
			this.rdbAltro.Size = new System.Drawing.Size(100, 16);
			this.rdbAltro.TabIndex = 9;
			this.rdbAltro.Tag = "mandatedetail.assetkind:O";
			this.rdbAltro.Text = "Altro";
			// 
			// radioServizi
			// 
			this.radioServizi.Location = new System.Drawing.Point(8, 84);
			this.radioServizi.Name = "radioServizi";
			this.radioServizi.Size = new System.Drawing.Size(100, 16);
			this.radioServizi.TabIndex = 8;
			this.radioServizi.Tag = "mandatedetail.assetkind:S";
			this.radioServizi.Text = "Servizi";
			// 
			// radioInvent
			// 
			this.radioInvent.Location = new System.Drawing.Point(8, 24);
			this.radioInvent.Name = "radioInvent";
			this.radioInvent.Size = new System.Drawing.Size(104, 16);
			this.radioInvent.TabIndex = 6;
			this.radioInvent.Tag = "mandatedetail.assetkind:A";
			this.radioInvent.Text = "Inventariabile";
			// 
			// radioNonInvent
			// 
			this.radioNonInvent.Location = new System.Drawing.Point(8, 54);
			this.radioNonInvent.Name = "radioNonInvent";
			this.radioNonInvent.Size = new System.Drawing.Size(120, 16);
			this.radioNonInvent.TabIndex = 7;
			this.radioNonInvent.Tag = "mandatedetail.assetkind:P";
			this.radioNonInvent.Text = "Aumento di valore";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(70, 306);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(448, 16);
			this.label2.TabIndex = 17;
			this.label2.Text = "Data contabile (da inserire se questo dettaglio non era presente nel contratto or" +
    "iginale)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtStart
			// 
			this.txtStart.Location = new System.Drawing.Point(524, 302);
			this.txtStart.Name = "txtStart";
			this.txtStart.Size = new System.Drawing.Size(104, 20);
			this.txtStart.TabIndex = 5;
			this.txtStart.Tag = "mandatedetail.start";
			this.txtStart.Leave += new System.EventHandler(this.txtStart_Leave);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(35, 330);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(483, 16);
			this.label5.TabIndex = 19;
			this.label5.Text = "Data annullamento (da inserire se il dettaglio è stato annullato o sostituito da " +
    "un altro dettaglio)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtStop
			// 
			this.txtStop.Location = new System.Drawing.Point(524, 326);
			this.txtStop.Name = "txtStop";
			this.txtStop.ReadOnly = true;
			this.txtStop.Size = new System.Drawing.Size(104, 20);
			this.txtStop.TabIndex = 6;
			this.txtStop.Tag = "mandatedetail.stop";
			this.txtStop.Leave += new System.EventHandler(this.txtStop_Leave);
			// 
			// gboxIVA
			// 
			this.gboxIVA.Controls.Add(this.txtNumeroIva);
			this.gboxIVA.Controls.Add(this.txtEsercizioIva);
			this.gboxIVA.Location = new System.Drawing.Point(326, 227);
			this.gboxIVA.Name = "gboxIVA";
			this.gboxIVA.Size = new System.Drawing.Size(214, 45);
			this.gboxIVA.TabIndex = 4;
			this.gboxIVA.TabStop = false;
			this.gboxIVA.Text = "Contabilizzazione IVA in finanziario";
			// 
			// txtNumeroIva
			// 
			this.txtNumeroIva.Location = new System.Drawing.Point(64, 16);
			this.txtNumeroIva.Name = "txtNumeroIva";
			this.txtNumeroIva.ReadOnly = true;
			this.txtNumeroIva.Size = new System.Drawing.Size(64, 20);
			this.txtNumeroIva.TabIndex = 3;
			this.txtNumeroIva.TabStop = false;
			this.txtNumeroIva.Tag = "expense_iva.nmov";
			// 
			// txtEsercizioIva
			// 
			this.txtEsercizioIva.Location = new System.Drawing.Point(8, 16);
			this.txtEsercizioIva.Name = "txtEsercizioIva";
			this.txtEsercizioIva.ReadOnly = true;
			this.txtEsercizioIva.Size = new System.Drawing.Size(40, 20);
			this.txtEsercizioIva.TabIndex = 2;
			this.txtEsercizioIva.TabStop = false;
			this.txtEsercizioIva.Tag = "expense_iva.ymov";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 27);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(152, 17);
			this.label9.TabIndex = 21;
			this.label9.Text = "Quantità inserita in fatture:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNInvoiced
			// 
			this.txtNInvoiced.Location = new System.Drawing.Point(11, 44);
			this.txtNInvoiced.Name = "txtNInvoiced";
			this.txtNInvoiced.ReadOnly = true;
			this.txtNInvoiced.Size = new System.Drawing.Size(100, 20);
			this.txtNInvoiced.TabIndex = 22;
			this.txtNInvoiced.Tag = "";
			this.txtNInvoiced.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(163, 27);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(120, 17);
			this.label10.TabIndex = 23;
			this.label10.Text = "Non inserita in fatture:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtResiduo
			// 
			this.txtResiduo.Location = new System.Drawing.Point(166, 44);
			this.txtResiduo.Name = "txtResiduo";
			this.txtResiduo.ReadOnly = true;
			this.txtResiduo.Size = new System.Drawing.Size(100, 20);
			this.txtResiduo.TabIndex = 24;
			this.txtResiduo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// gboxImponibile
			// 
			this.gboxImponibile.Controls.Add(this.txtNumImponibile);
			this.gboxImponibile.Controls.Add(this.txtEsercizioImponibile);
			this.gboxImponibile.Location = new System.Drawing.Point(326, 156);
			this.gboxImponibile.Name = "gboxImponibile";
			this.gboxImponibile.Size = new System.Drawing.Size(214, 66);
			this.gboxImponibile.TabIndex = 3;
			this.gboxImponibile.TabStop = false;
			this.gboxImponibile.Text = "Contabilizzazione imponibile in finanziario";
			// 
			// txtNumImponibile
			// 
			this.txtNumImponibile.Location = new System.Drawing.Point(63, 31);
			this.txtNumImponibile.Name = "txtNumImponibile";
			this.txtNumImponibile.ReadOnly = true;
			this.txtNumImponibile.Size = new System.Drawing.Size(64, 20);
			this.txtNumImponibile.TabIndex = 3;
			this.txtNumImponibile.TabStop = false;
			this.txtNumImponibile.Tag = "expense_imponibile.nmov";
			// 
			// txtEsercizioImponibile
			// 
			this.txtEsercizioImponibile.Location = new System.Drawing.Point(8, 31);
			this.txtEsercizioImponibile.Name = "txtEsercizioImponibile";
			this.txtEsercizioImponibile.ReadOnly = true;
			this.txtEsercizioImponibile.Size = new System.Drawing.Size(40, 20);
			this.txtEsercizioImponibile.TabIndex = 2;
			this.txtEsercizioImponibile.TabStop = false;
			this.txtEsercizioImponibile.Tag = "expense_imponibile.ymov";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.btnUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Location = new System.Drawing.Point(4, 27);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(316, 124);
			this.gboxUPB.TabIndex = 1;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(4, 100);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(304, 20);
			this.txtUPB.TabIndex = 6;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// btnUPB
			// 
			this.btnUPB.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPB.Location = new System.Drawing.Point(6, 71);
			this.btnUPB.Name = "btnUPB";
			this.btnUPB.Size = new System.Drawing.Size(112, 20);
			this.btnUPB.TabIndex = 5;
			this.btnUPB.TabStop = false;
			this.btnUPB.Tag = "manage.upb.tree";
			this.btnUPB.Text = "UPB:";
			this.btnUPB.UseVisualStyleBackColor = false;
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(126, 8);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(182, 83);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.Location = new System.Drawing.Point(0, 0);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(75, 23);
			this.btnUPBCode.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPrincipale);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabAnalitico);
			this.tabControl1.Controls.Add(this.tabFatturazione);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabMagazzino);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPCC);
			this.tabControl1.Location = new System.Drawing.Point(14, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(969, 523);
			this.tabControl1.TabIndex = 10;
			this.tabControl1.TabStop = false;
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.BackColor = System.Drawing.SystemColors.Control;
			this.tabPrincipale.Controls.Add(this.grpRegistry);
			this.tabPrincipale.Controls.Add(this.gboxListino);
			this.tabPrincipale.Controls.Add(this.txtQuantitaConfezioni);
			this.tabPrincipale.Controls.Add(this.txtDescrizione);
			this.tabPrincipale.Controls.Add(this.lblidpackage);
			this.tabPrincipale.Controls.Add(this.chkPromiscuo);
			this.tabPrincipale.Controls.Add(this.label6);
			this.tabPrincipale.Controls.Add(this.btnSuggerimento);
			this.tabPrincipale.Controls.Add(this.gboxPagato);
			this.tabPrincipale.Controls.Add(this.txtQuantita);
			this.tabPrincipale.Controls.Add(this.grpAttivita);
			this.tabPrincipale.Controls.Add(this.grpValoreUnitInValuta);
			this.tabPrincipale.Controls.Add(this.lblidunit);
			this.tabPrincipale.Controls.Add(this.textBox6);
			this.tabPrincipale.Controls.Add(this.label17);
			this.tabPrincipale.Controls.Add(this.groupBox2);
			this.tabPrincipale.Controls.Add(this.grpTipoIva);
			this.tabPrincipale.Controls.Add(this.btnCalcoloSconto);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Padding = new System.Windows.Forms.Padding(3);
			this.tabPrincipale.Size = new System.Drawing.Size(961, 497);
			this.tabPrincipale.TabIndex = 8;
			this.tabPrincipale.Text = "Principale";
			// 
			// grpRegistry
			// 
			this.grpRegistry.Controls.Add(this.txtCredDeb);
			this.grpRegistry.Location = new System.Drawing.Point(6, 10);
			this.grpRegistry.Name = "grpRegistry";
			this.grpRegistry.Size = new System.Drawing.Size(473, 41);
			this.grpRegistry.TabIndex = 1;
			this.grpRegistry.TabStop = false;
			this.grpRegistry.Tag = "AutoChoose.txtCredDeb.default.(active=\'S\')";
			this.grpRegistry.Text = "Fornitore";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(6, 16);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(461, 20);
			this.txtCredDeb.TabIndex = 6;
			this.txtCredDeb.Tag = "registrymainview.title?mandatedetailview.registry";
			// 
			// gboxListino
			// 
			this.gboxListino.Controls.Add(this.txtPrezzounitarioListino);
			this.gboxListino.Controls.Add(this.label26);
			this.gboxListino.Controls.Add(this.txtCoeffConversione);
			this.gboxListino.Controls.Add(this.label20);
			this.gboxListino.Controls.Add(this.cmbUnitaMisuraAcquisto);
			this.gboxListino.Controls.Add(this.lblIcmbdpackage);
			this.gboxListino.Controls.Add(this.label25);
			this.gboxListino.Controls.Add(this.cmbUnitaMisuraCS);
			this.gboxListino.Controls.Add(this.chkListDescription);
			this.gboxListino.Controls.Add(this.btnListino);
			this.gboxListino.Controls.Add(this.txtListino);
			this.gboxListino.Controls.Add(this.txtDescrizioneListino);
			this.gboxListino.Location = new System.Drawing.Point(486, 10);
			this.gboxListino.Name = "gboxListino";
			this.gboxListino.Size = new System.Drawing.Size(463, 214);
			this.gboxListino.TabIndex = 3;
			this.gboxListino.TabStop = false;
			this.gboxListino.Tag = "";
			// 
			// txtPrezzounitarioListino
			// 
			this.txtPrezzounitarioListino.Location = new System.Drawing.Point(306, 178);
			this.txtPrezzounitarioListino.Name = "txtPrezzounitarioListino";
			this.txtPrezzounitarioListino.ReadOnly = true;
			this.txtPrezzounitarioListino.Size = new System.Drawing.Size(118, 20);
			this.txtPrezzounitarioListino.TabIndex = 35;
			this.txtPrezzounitarioListino.Tag = "";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(303, 160);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(94, 16);
			this.label26.TabIndex = 36;
			this.label26.Text = "Prezzo unitario";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCoeffConversione
			// 
			this.txtCoeffConversione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCoeffConversione.Location = new System.Drawing.Point(306, 87);
			this.txtCoeffConversione.Name = "txtCoeffConversione";
			this.txtCoeffConversione.ReadOnly = true;
			this.txtCoeffConversione.Size = new System.Drawing.Size(85, 20);
			this.txtCoeffConversione.TabIndex = 8;
			this.txtCoeffConversione.TabStop = false;
			this.txtCoeffConversione.Tag = "mandatedetail.unitsforpackage?x";
			// 
			// label20
			// 
			this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(303, 73);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(107, 13);
			this.label20.TabIndex = 22;
			this.label20.Text = "Coeff. di conversione";
			// 
			// cmbUnitaMisuraAcquisto
			// 
			this.cmbUnitaMisuraAcquisto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbUnitaMisuraAcquisto.DataSource = this.DS.package;
			this.cmbUnitaMisuraAcquisto.DisplayMember = "description";
			this.cmbUnitaMisuraAcquisto.Enabled = false;
			this.cmbUnitaMisuraAcquisto.FormattingEnabled = true;
			this.cmbUnitaMisuraAcquisto.Location = new System.Drawing.Point(306, 37);
			this.cmbUnitaMisuraAcquisto.Name = "cmbUnitaMisuraAcquisto";
			this.cmbUnitaMisuraAcquisto.Size = new System.Drawing.Size(118, 21);
			this.cmbUnitaMisuraAcquisto.TabIndex = 7;
			this.cmbUnitaMisuraAcquisto.Tag = "mandatedetail.idpackage";
			this.cmbUnitaMisuraAcquisto.ValueMember = "idpackage";
			// 
			// lblIcmbdpackage
			// 
			this.lblIcmbdpackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblIcmbdpackage.AutoSize = true;
			this.lblIcmbdpackage.Location = new System.Drawing.Point(303, 23);
			this.lblIcmbdpackage.Name = "lblIcmbdpackage";
			this.lblIcmbdpackage.Size = new System.Drawing.Size(106, 13);
			this.lblIcmbdpackage.TabIndex = 21;
			this.lblIcmbdpackage.Text = "U.tà di misura imballo";
			// 
			// label25
			// 
			this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(304, 116);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(71, 13);
			this.label25.TabIndex = 23;
			this.label25.Text = "U.tà di misura";
			// 
			// cmbUnitaMisuraCS
			// 
			this.cmbUnitaMisuraCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbUnitaMisuraCS.DataSource = this.DS.unit;
			this.cmbUnitaMisuraCS.DisplayMember = "description";
			this.cmbUnitaMisuraCS.Enabled = false;
			this.cmbUnitaMisuraCS.FormattingEnabled = true;
			this.cmbUnitaMisuraCS.Location = new System.Drawing.Point(306, 130);
			this.cmbUnitaMisuraCS.Name = "cmbUnitaMisuraCS";
			this.cmbUnitaMisuraCS.Size = new System.Drawing.Size(118, 21);
			this.cmbUnitaMisuraCS.TabIndex = 9;
			this.cmbUnitaMisuraCS.Tag = "mandatedetail.idunit";
			this.cmbUnitaMisuraCS.ValueMember = "idunit";
			// 
			// chkListDescription
			// 
			this.chkListDescription.Location = new System.Drawing.Point(11, 11);
			this.chkListDescription.Name = "chkListDescription";
			this.chkListDescription.Size = new System.Drawing.Size(277, 20);
			this.chkListDescription.TabIndex = 4;
			this.chkListDescription.TabStop = false;
			this.chkListDescription.Text = "Fitra per Descrizione/Class.Merceologica";
			// 
			// btnListino
			// 
			this.btnListino.BackColor = System.Drawing.SystemColors.Control;
			this.btnListino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnListino.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnListino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnListino.ImageIndex = 0;
			this.btnListino.Location = new System.Drawing.Point(6, 75);
			this.btnListino.Name = "btnListino";
			this.btnListino.Size = new System.Drawing.Size(57, 23);
			this.btnListino.TabIndex = 1;
			this.btnListino.TabStop = false;
			this.btnListino.Tag = "";
			this.btnListino.Text = "Listino";
			this.btnListino.UseVisualStyleBackColor = false;
			this.btnListino.Click += new System.EventHandler(this.btnListino_Click);
			// 
			// txtListino
			// 
			this.txtListino.Location = new System.Drawing.Point(6, 104);
			this.txtListino.Name = "txtListino";
			this.txtListino.Size = new System.Drawing.Size(269, 20);
			this.txtListino.TabIndex = 6;
			this.txtListino.Tag = "";
			this.txtListino.TextChanged += new System.EventHandler(this.txtListino_TextChanged);
			this.txtListino.Enter += new System.EventHandler(this.txtListino_Enter);
			this.txtListino.Leave += new System.EventHandler(this.txtListino_Leave);
			// 
			// txtDescrizioneListino
			// 
			this.txtDescrizioneListino.Location = new System.Drawing.Point(76, 37);
			this.txtDescrizioneListino.Multiline = true;
			this.txtDescrizioneListino.Name = "txtDescrizioneListino";
			this.txtDescrizioneListino.ReadOnly = true;
			this.txtDescrizioneListino.Size = new System.Drawing.Size(199, 61);
			this.txtDescrizioneListino.TabIndex = 9;
			this.txtDescrizioneListino.TabStop = false;
			this.txtDescrizioneListino.Tag = "";
			// 
			// txtQuantitaConfezioni
			// 
			this.txtQuantitaConfezioni.Location = new System.Drawing.Point(6, 270);
			this.txtQuantitaConfezioni.Name = "txtQuantitaConfezioni";
			this.txtQuantitaConfezioni.Size = new System.Drawing.Size(88, 20);
			this.txtQuantitaConfezioni.TabIndex = 4;
			this.txtQuantitaConfezioni.Tag = "mandatedetail.npackage.N";
			this.txtQuantitaConfezioni.Leave += new System.EventHandler(this.txtNumConfezioni_Leave);
			// 
			// lblidpackage
			// 
			this.lblidpackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblidpackage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblidpackage.Location = new System.Drawing.Point(5, 254);
			this.lblidpackage.Name = "lblidpackage";
			this.lblidpackage.Size = new System.Drawing.Size(53, 16);
			this.lblidpackage.TabIndex = 27;
			this.lblidpackage.Text = "Quantità";
			this.lblidpackage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkPromiscuo
			// 
			this.chkPromiscuo.ForeColor = System.Drawing.Color.DarkRed;
			this.chkPromiscuo.Location = new System.Drawing.Point(310, 266);
			this.chkPromiscuo.Name = "chkPromiscuo";
			this.chkPromiscuo.Size = new System.Drawing.Size(80, 24);
			this.chkPromiscuo.TabIndex = 30;
			this.chkPromiscuo.TabStop = false;
			this.chkPromiscuo.Tag = "mandatedetail.flagmixed:S:N";
			this.chkPromiscuo.Text = "Promiscuo";
			this.chkPromiscuo.Visible = false;
			// 
			// btnSuggerimento
			// 
			this.btnSuggerimento.Location = new System.Drawing.Point(6, 402);
			this.btnSuggerimento.Name = "btnSuggerimento";
			this.btnSuggerimento.Size = new System.Drawing.Size(162, 40);
			this.btnSuggerimento.TabIndex = 32;
			this.btnSuggerimento.Text = "Suggerimento su come effettuare l\'inserimento";
			this.btnSuggerimento.Click += new System.EventHandler(this.btnSuggerimento_Click);
			// 
			// gboxPagato
			// 
			this.gboxPagato.Controls.Add(this.txtPagato);
			this.gboxPagato.Location = new System.Drawing.Point(730, 243);
			this.gboxPagato.Name = "gboxPagato";
			this.gboxPagato.Size = new System.Drawing.Size(225, 66);
			this.gboxPagato.TabIndex = 33;
			this.gboxPagato.TabStop = false;
			this.gboxPagato.Text = "Pagato";
			// 
			// txtPagato
			// 
			this.txtPagato.Location = new System.Drawing.Point(6, 30);
			this.txtPagato.Name = "txtPagato";
			this.txtPagato.ReadOnly = true;
			this.txtPagato.Size = new System.Drawing.Size(213, 20);
			this.txtPagato.TabIndex = 0;
			this.txtPagato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpAttivita
			// 
			this.grpAttivita.Controls.Add(this.rdbPromiscua);
			this.grpAttivita.Controls.Add(this.rdbCommerciale);
			this.grpAttivita.Controls.Add(this.rdbQualsiasi);
			this.grpAttivita.Controls.Add(this.rdbIstituzionale);
			this.grpAttivita.Location = new System.Drawing.Point(730, 315);
			this.grpAttivita.Name = "grpAttivita";
			this.grpAttivita.Size = new System.Drawing.Size(186, 93);
			this.grpAttivita.TabIndex = 9;
			this.grpAttivita.TabStop = false;
			this.grpAttivita.Text = "Attività";
			// 
			// rdbPromiscua
			// 
			this.rdbPromiscua.Location = new System.Drawing.Point(6, 74);
			this.rdbPromiscua.Name = "rdbPromiscua";
			this.rdbPromiscua.Size = new System.Drawing.Size(84, 16);
			this.rdbPromiscua.TabIndex = 6;
			this.rdbPromiscua.Tag = "mandatedetail.flagactivity:3";
			this.rdbPromiscua.Text = "Promiscua";
			this.rdbPromiscua.CheckedChanged += new System.EventHandler(this.rdbQualsiasi_CheckedChanged);
			// 
			// rdbCommerciale
			// 
			this.rdbCommerciale.Location = new System.Drawing.Point(6, 57);
			this.rdbCommerciale.Name = "rdbCommerciale";
			this.rdbCommerciale.Size = new System.Drawing.Size(96, 16);
			this.rdbCommerciale.TabIndex = 3;
			this.rdbCommerciale.Tag = "mandatedetail.flagactivity:2";
			this.rdbCommerciale.Text = "Commerciale";
			this.rdbCommerciale.CheckedChanged += new System.EventHandler(this.rdbQualsiasi_CheckedChanged);
			// 
			// rdbQualsiasi
			// 
			this.rdbQualsiasi.Location = new System.Drawing.Point(6, 16);
			this.rdbQualsiasi.Name = "rdbQualsiasi";
			this.rdbQualsiasi.Size = new System.Drawing.Size(160, 22);
			this.rdbQualsiasi.TabIndex = 1;
			this.rdbQualsiasi.Tag = "mandatedetail.flagactivity:4";
			this.rdbQualsiasi.Text = "Qualsiasi/Non specificata";
			this.rdbQualsiasi.CheckedChanged += new System.EventHandler(this.rdbQualsiasi_CheckedChanged);
			// 
			// rdbIstituzionale
			// 
			this.rdbIstituzionale.Location = new System.Drawing.Point(6, 36);
			this.rdbIstituzionale.Name = "rdbIstituzionale";
			this.rdbIstituzionale.Size = new System.Drawing.Size(96, 20);
			this.rdbIstituzionale.TabIndex = 2;
			this.rdbIstituzionale.Tag = "mandatedetail.flagactivity:1";
			this.rdbIstituzionale.Text = "Istituzionale";
			this.rdbIstituzionale.CheckedChanged += new System.EventHandler(this.rdbQualsiasi_CheckedChanged);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(7, 328);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox6.Size = new System.Drawing.Size(424, 53);
			this.textBox6.TabIndex = 7;
			this.textBox6.Tag = "mandatedetail.ivanotes";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(7, 310);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(142, 23);
			this.label17.TabIndex = 0;
			this.label17.Text = "Note sull\'IVA del dettaglio:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpTipoIva
			// 
			this.grpTipoIva.Controls.Add(this.btnTipo);
			this.grpTipoIva.Controls.Add(this.cmbTipoIVA);
			this.grpTipoIva.Controls.Add(this.txtTaxRate);
			this.grpTipoIva.Controls.Add(this.label21);
			this.grpTipoIva.Controls.Add(this.label22);
			this.grpTipoIva.Controls.Add(this.txtPercIndeduc);
			this.grpTipoIva.Location = new System.Drawing.Point(6, 156);
			this.grpTipoIva.Name = "grpTipoIva";
			this.grpTipoIva.Size = new System.Drawing.Size(474, 68);
			this.grpTipoIva.TabIndex = 5;
			this.grpTipoIva.TabStop = false;
			// 
			// btnTipo
			// 
			this.btnTipo.Location = new System.Drawing.Point(6, 13);
			this.btnTipo.Name = "btnTipo";
			this.btnTipo.Size = new System.Drawing.Size(64, 23);
			this.btnTipo.TabIndex = 7;
			this.btnTipo.TabStop = false;
			this.btnTipo.Tag = "choose.ivakind.default";
			this.btnTipo.Text = "Tipo IVA";
			// 
			// cmbTipoIVA
			// 
			this.cmbTipoIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoIVA.DataSource = this.DS.ivakind;
			this.cmbTipoIVA.DisplayMember = "description";
			this.cmbTipoIVA.Location = new System.Drawing.Point(6, 39);
			this.cmbTipoIVA.Name = "cmbTipoIVA";
			this.cmbTipoIVA.Size = new System.Drawing.Size(322, 21);
			this.cmbTipoIVA.TabIndex = 2;
			this.cmbTipoIVA.Tag = "mandatedetail.idivakind";
			this.cmbTipoIVA.ValueMember = "idivakind";
			// 
			// txtTaxRate
			// 
			this.txtTaxRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTaxRate.Location = new System.Drawing.Point(333, 40);
			this.txtTaxRate.Name = "txtTaxRate";
			this.txtTaxRate.ReadOnly = true;
			this.txtTaxRate.Size = new System.Drawing.Size(60, 20);
			this.txtTaxRate.TabIndex = 2;
			this.txtTaxRate.TabStop = false;
			this.txtTaxRate.Tag = "mandatedetail.taxrate.fixed.4..%.100";
			this.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label21
			// 
			this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label21.Location = new System.Drawing.Point(331, 24);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(53, 16);
			this.label21.TabIndex = 35;
			this.label21.Text = "Aliquota";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label22
			// 
			this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label22.Location = new System.Drawing.Point(390, 24);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(83, 16);
			this.label22.TabIndex = 39;
			this.label22.Text = "% Indetraibilità";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtPercIndeduc
			// 
			this.txtPercIndeduc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercIndeduc.Location = new System.Drawing.Point(398, 40);
			this.txtPercIndeduc.Name = "txtPercIndeduc";
			this.txtPercIndeduc.ReadOnly = true;
			this.txtPercIndeduc.Size = new System.Drawing.Size(70, 20);
			this.txtPercIndeduc.TabIndex = 3;
			this.txtPercIndeduc.TabStop = false;
			this.txtPercIndeduc.Tag = "ivakind.unabatabilitypercentage.fixed.4..%.100";
			this.txtPercIndeduc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnCalcoloSconto
			// 
			this.btnCalcoloSconto.Location = new System.Drawing.Point(10, 463);
			this.btnCalcoloSconto.Name = "btnCalcoloSconto";
			this.btnCalcoloSconto.Size = new System.Drawing.Size(125, 28);
			this.btnCalcoloSconto.TabIndex = 60;
			this.btnCalcoloSconto.Text = "Calcolo Sconto";
			this.btnCalcoloSconto.Visible = false;
			this.btnCalcoloSconto.Click += new System.EventHandler(this.btnCalcoloSconto_Click);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gBoxupbIVA);
			this.tabPage1.Controls.Add(this.cmbCIG);
			this.tabPage1.Controls.Add(this.lblcig);
			this.tabPage1.Controls.Add(this.label18);
			this.tabPage1.Controls.Add(this.txtCupCode);
			this.tabPage1.Controls.Add(this.gboxUPB);
			this.tabPage1.Controls.Add(this.gboxImponibile);
			this.tabPage1.Controls.Add(this.gboxIVA);
			this.tabPage1.Controls.Add(this.txtStart);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.txtStop);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(961, 497);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Finanziario";
			// 
			// gBoxupbIVA
			// 
			this.gBoxupbIVA.Controls.Add(this.txtUPBiva);
			this.gBoxupbIVA.Controls.Add(this.label14);
			this.gBoxupbIVA.Controls.Add(this.buttonupbIVA);
			this.gBoxupbIVA.Controls.Add(this.textBox3);
			this.gBoxupbIVA.Location = new System.Drawing.Point(326, 25);
			this.gBoxupbIVA.Name = "gBoxupbIVA";
			this.gBoxupbIVA.Size = new System.Drawing.Size(302, 126);
			this.gBoxupbIVA.TabIndex = 61;
			this.gBoxupbIVA.TabStop = false;
			this.gBoxupbIVA.Tag = "AutoChoose.txtUPBiva.default.(active=\'S\')";
			this.gBoxupbIVA.Text = "UPB per la Contabilizzazione IVA";
			// 
			// txtUPBiva
			// 
			this.txtUPBiva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPBiva.Location = new System.Drawing.Point(9, 100);
			this.txtUPBiva.Name = "txtUPBiva";
			this.txtUPBiva.Size = new System.Drawing.Size(287, 20);
			this.txtUPBiva.TabIndex = 7;
			this.txtUPBiva.Tag = "upb_iva.codeupb?x";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(7, 24);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(95, 50);
			this.label14.TabIndex = 6;
			this.label14.Text = "Utilizzare solo se diverso dal principale";
			// 
			// buttonupbIVA
			// 
			this.buttonupbIVA.BackColor = System.Drawing.SystemColors.Control;
			this.buttonupbIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonupbIVA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.buttonupbIVA.Location = new System.Drawing.Point(10, 77);
			this.buttonupbIVA.Name = "buttonupbIVA";
			this.buttonupbIVA.Size = new System.Drawing.Size(76, 20);
			this.buttonupbIVA.TabIndex = 5;
			this.buttonupbIVA.TabStop = false;
			this.buttonupbIVA.Tag = "manage.upb_iva.tree";
			this.buttonupbIVA.Text = "UPB";
			this.buttonupbIVA.UseVisualStyleBackColor = false;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(112, 16);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(185, 78);
			this.textBox3.TabIndex = 4;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "upb_iva.title";
			// 
			// cmbCIG
			// 
			this.cmbCIG.FormattingEnabled = true;
			this.cmbCIG.Location = new System.Drawing.Point(11, 173);
			this.cmbCIG.Name = "cmbCIG";
			this.cmbCIG.Size = new System.Drawing.Size(188, 21);
			this.cmbCIG.TabIndex = 60;
			// 
			// lblcig
			// 
			this.lblcig.Location = new System.Drawing.Point(10, 156);
			this.lblcig.Name = "lblcig";
			this.lblcig.Size = new System.Drawing.Size(173, 19);
			this.lblcig.TabIndex = 59;
			this.lblcig.Tag = "";
			this.lblcig.Text = "Codice Identificativo di Gara(CIG)";
			this.lblcig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(10, 211);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(170, 16);
			this.label18.TabIndex = 23;
			this.label18.Text = "Codice Unico di Progetto (CUP)";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCupCode
			// 
			this.txtCupCode.Location = new System.Drawing.Point(11, 228);
			this.txtCupCode.Name = "txtCupCode";
			this.txtCupCode.Size = new System.Drawing.Size(188, 20);
			this.txtCupCode.TabIndex = 2;
			this.txtCupCode.Tag = "mandatedetail.cupcode";
			// 
			// tabAnalitico
			// 
			this.tabAnalitico.Controls.Add(this.grpRipartizioneCosti);
			this.tabAnalitico.Controls.Add(this.gboxclass3);
			this.tabAnalitico.Controls.Add(this.gboxclass2);
			this.tabAnalitico.Controls.Add(this.gboxclass1);
			this.tabAnalitico.Location = new System.Drawing.Point(4, 22);
			this.tabAnalitico.Name = "tabAnalitico";
			this.tabAnalitico.Size = new System.Drawing.Size(961, 497);
			this.tabAnalitico.TabIndex = 3;
			this.tabAnalitico.Text = "Analitico";
			// 
			// grpRipartizioneCosti
			// 
			this.grpRipartizioneCosti.Controls.Add(this.button3);
			this.grpRipartizioneCosti.Controls.Add(this.textBox1);
			this.grpRipartizioneCosti.Controls.Add(this.txtCodiceRipartizione);
			this.grpRipartizioneCosti.Location = new System.Drawing.Point(426, 102);
			this.grpRipartizioneCosti.Name = "grpRipartizioneCosti";
			this.grpRipartizioneCosti.Size = new System.Drawing.Size(382, 96);
			this.grpRipartizioneCosti.TabIndex = 4;
			this.grpRipartizioneCosti.TabStop = false;
			this.grpRipartizioneCosti.Tag = "AutoChoose.txtCodiceRipartizione.default.(active=\'S\')";
			this.grpRipartizioneCosti.Text = "Ripartizione dei Costi";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(13, 41);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 23);
			this.button3.TabIndex = 4;
			this.button3.Tag = "choose.costpartition.default.(active=\'S\')";
			this.button3.Text = "Codice";
			this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(107, 19);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(269, 45);
			this.textBox1.TabIndex = 3;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "costpartition.title";
			// 
			// txtCodiceRipartizione
			// 
			this.txtCodiceRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceRipartizione.Location = new System.Drawing.Point(8, 70);
			this.txtCodiceRipartizione.Name = "txtCodiceRipartizione";
			this.txtCodiceRipartizione.Size = new System.Drawing.Size(368, 20);
			this.txtCodiceRipartizione.TabIndex = 2;
			this.txtCodiceRipartizione.Tag = "costpartition.costpartitioncode?x";
			// 
			// gboxclass3
			// 
			this.gboxclass3.Controls.Add(this.btnCodice3);
			this.gboxclass3.Controls.Add(this.txtDenom3);
			this.gboxclass3.Controls.Add(this.txtCodice3);
			this.gboxclass3.Location = new System.Drawing.Point(3, 101);
			this.gboxclass3.Name = "gboxclass3";
			this.gboxclass3.Size = new System.Drawing.Size(409, 97);
			this.gboxclass3.TabIndex = 3;
			this.gboxclass3.TabStop = false;
			this.gboxclass3.Tag = "AutoManage.txtCodice.treeclassmovimenti";
			this.gboxclass3.Text = "Classificazione 3";
			// 
			// btnCodice3
			// 
			this.btnCodice3.Location = new System.Drawing.Point(13, 42);
			this.btnCodice3.Name = "btnCodice3";
			this.btnCodice3.Size = new System.Drawing.Size(88, 23);
			this.btnCodice3.TabIndex = 4;
			this.btnCodice3.Tag = "manage.sorting3.tree";
			this.btnCodice3.Text = "Codice";
			this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom3
			// 
			this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom3.Location = new System.Drawing.Point(166, 19);
			this.txtDenom3.Multiline = true;
			this.txtDenom3.Name = "txtDenom3";
			this.txtDenom3.ReadOnly = true;
			this.txtDenom3.Size = new System.Drawing.Size(235, 46);
			this.txtDenom3.TabIndex = 3;
			this.txtDenom3.TabStop = false;
			this.txtDenom3.Tag = "sorting3.description";
			// 
			// txtCodice3
			// 
			this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice3.Location = new System.Drawing.Point(8, 71);
			this.txtCodice3.Name = "txtCodice3";
			this.txtCodice3.Size = new System.Drawing.Size(393, 20);
			this.txtCodice3.TabIndex = 4;
			this.txtCodice3.Tag = "sorting3.sortcode?x";
			// 
			// gboxclass2
			// 
			this.gboxclass2.Controls.Add(this.btnCodice2);
			this.gboxclass2.Controls.Add(this.txtDenom2);
			this.gboxclass2.Controls.Add(this.txtCodice2);
			this.gboxclass2.Location = new System.Drawing.Point(426, 3);
			this.gboxclass2.Name = "gboxclass2";
			this.gboxclass2.Size = new System.Drawing.Size(382, 89);
			this.gboxclass2.TabIndex = 2;
			this.gboxclass2.TabStop = false;
			this.gboxclass2.Tag = "AutoManage.txtCodice.treeclassmovimenti";
			this.gboxclass2.Text = "Classificazione 2";
			// 
			// btnCodice2
			// 
			this.btnCodice2.Location = new System.Drawing.Point(8, 34);
			this.btnCodice2.Name = "btnCodice2";
			this.btnCodice2.Size = new System.Drawing.Size(88, 23);
			this.btnCodice2.TabIndex = 4;
			this.btnCodice2.Tag = "manage.sorting2.tree";
			this.btnCodice2.Text = "Codice";
			this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom2
			// 
			this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom2.Location = new System.Drawing.Point(112, 19);
			this.txtDenom2.Multiline = true;
			this.txtDenom2.Name = "txtDenom2";
			this.txtDenom2.ReadOnly = true;
			this.txtDenom2.Size = new System.Drawing.Size(262, 41);
			this.txtDenom2.TabIndex = 3;
			this.txtDenom2.TabStop = false;
			this.txtDenom2.Tag = "sorting2.description";
			// 
			// txtCodice2
			// 
			this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice2.Location = new System.Drawing.Point(8, 63);
			this.txtCodice2.Name = "txtCodice2";
			this.txtCodice2.Size = new System.Drawing.Size(366, 20);
			this.txtCodice2.TabIndex = 2;
			this.txtCodice2.Tag = "sorting2.sortcode?x";
			// 
			// gboxclass1
			// 
			this.gboxclass1.Controls.Add(this.btnCodice1);
			this.gboxclass1.Controls.Add(this.txtDenom1);
			this.gboxclass1.Controls.Add(this.txtCodice1);
			this.gboxclass1.Location = new System.Drawing.Point(8, 3);
			this.gboxclass1.Name = "gboxclass1";
			this.gboxclass1.Size = new System.Drawing.Size(404, 89);
			this.gboxclass1.TabIndex = 1;
			this.gboxclass1.TabStop = false;
			this.gboxclass1.Tag = "AutoManage.txtCodice.treeclassmovimenti";
			this.gboxclass1.Text = "Classificazione 1";
			// 
			// btnCodice1
			// 
			this.btnCodice1.Location = new System.Drawing.Point(8, 37);
			this.btnCodice1.Name = "btnCodice1";
			this.btnCodice1.Size = new System.Drawing.Size(88, 23);
			this.btnCodice1.TabIndex = 4;
			this.btnCodice1.Tag = "manage.sorting1.tree";
			this.btnCodice1.Text = "Codice";
			this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom1
			// 
			this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom1.Location = new System.Drawing.Point(161, 19);
			this.txtDenom1.Multiline = true;
			this.txtDenom1.Name = "txtDenom1";
			this.txtDenom1.ReadOnly = true;
			this.txtDenom1.Size = new System.Drawing.Size(235, 41);
			this.txtDenom1.TabIndex = 3;
			this.txtDenom1.TabStop = false;
			this.txtDenom1.Tag = "sorting1.description";
			// 
			// txtCodice1
			// 
			this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice1.Location = new System.Drawing.Point(8, 63);
			this.txtCodice1.Name = "txtCodice1";
			this.txtCodice1.Size = new System.Drawing.Size(388, 20);
			this.txtCodice1.TabIndex = 2;
			this.txtCodice1.Tag = "sorting1.sortcode?x";
			// 
			// tabFatturazione
			// 
			this.tabFatturazione.Controls.Add(this.groupBox1);
			this.tabFatturazione.Controls.Add(this.checkBox1);
			this.tabFatturazione.Controls.Add(this.label13);
			this.tabFatturazione.Controls.Add(this.dataGrid1);
			this.tabFatturazione.Controls.Add(this.txtNInvoiced);
			this.tabFatturazione.Controls.Add(this.label10);
			this.tabFatturazione.Controls.Add(this.txtResiduo);
			this.tabFatturazione.Controls.Add(this.label9);
			this.tabFatturazione.Location = new System.Drawing.Point(4, 22);
			this.tabFatturazione.Name = "tabFatturazione";
			this.tabFatturazione.Size = new System.Drawing.Size(961, 497);
			this.tabFatturazione.TabIndex = 1;
			this.tabFatturazione.Text = "Fatturazione";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton6);
			this.groupBox1.Controls.Add(this.radioButton5);
			this.groupBox1.Controls.Add(this.radioButton4);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Location = new System.Drawing.Point(11, 90);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(932, 55);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ripartizione totale acquisti - Quadro VF";
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(757, 19);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(151, 17);
			this.radioButton6.TabIndex = 32;
			this.radioButton6.TabStop = true;
			this.radioButton6.Tag = "mandatedetail.va3type:A";
			this.radioButton6.Text = " Altri acquisti e importazioni";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(174, 19);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(335, 17);
			this.radioButton5.TabIndex = 31;
			this.radioButton5.TabStop = true;
			this.radioButton5.Tag = "mandatedetail.va3type:R";
			this.radioButton5.Text = "Beni destinati alla rivendita ovvero alla produzione di beni e servizi";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(541, 19);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(187, 17);
			this.radioButton4.TabIndex = 30;
			this.radioButton4.TabStop = true;
			this.radioButton4.Tag = "mandatedetail.va3type:N";
			this.radioButton4.Text = "Beni strumentali non ammortizzabili";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(17, 19);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(113, 17);
			this.radioButton3.TabIndex = 29;
			this.radioButton3.TabStop = true;
			this.radioButton3.Tag = "mandatedetail.va3type:S";
			this.radioButton3.Text = "Beni ammortizzabili";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(653, 44);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(290, 24);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Tag = "mandatedetail.toinvoice:N:S";
			this.checkBox1.Text = "Non proporre più il dettaglio per l\'inserimento in fatture";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 167);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(169, 22);
			this.label13.TabIndex = 27;
			this.label13.Text = "Elenco dettagli fatture associati";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(11, 189);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(932, 302);
			this.dataGrid1.TabIndex = 26;
			this.dataGrid1.Tag = "invoicedetail.dettordine";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.grpAutoLocation);
			this.tabPage3.Controls.Add(this.grpInventario);
			this.tabPage3.Controls.Add(this.grpTipoBene);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(961, 497);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Patrimonio";
			// 
			// grpAutoLocation
			// 
			this.grpAutoLocation.Controls.Add(this.btnUbicazione);
			this.grpAutoLocation.Controls.Add(this.txtDescUbicazione);
			this.grpAutoLocation.Controls.Add(this.txtUbicazione);
			this.grpAutoLocation.Location = new System.Drawing.Point(159, 124);
			this.grpAutoLocation.Name = "grpAutoLocation";
			this.grpAutoLocation.Size = new System.Drawing.Size(390, 82);
			this.grpAutoLocation.TabIndex = 33;
			this.grpAutoLocation.TabStop = false;
			this.grpAutoLocation.Tag = "AutoChoose.txtUbicazione.default.(active=\'S\')";
			// 
			// btnUbicazione
			// 
			this.btnUbicazione.Location = new System.Drawing.Point(6, 13);
			this.btnUbicazione.Name = "btnUbicazione";
			this.btnUbicazione.Size = new System.Drawing.Size(88, 23);
			this.btnUbicazione.TabIndex = 5;
			this.btnUbicazione.Tag = "manage.locationview.tree.(active=\'S\')";
			this.btnUbicazione.Text = "Ubicazione";
			// 
			// txtDescUbicazione
			// 
			this.txtDescUbicazione.Location = new System.Drawing.Point(110, 37);
			this.txtDescUbicazione.Multiline = true;
			this.txtDescUbicazione.Name = "txtDescUbicazione";
			this.txtDescUbicazione.ReadOnly = true;
			this.txtDescUbicazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescUbicazione.Size = new System.Drawing.Size(272, 37);
			this.txtDescUbicazione.TabIndex = 7;
			this.txtDescUbicazione.Tag = "locationview.description";
			// 
			// txtUbicazione
			// 
			this.txtUbicazione.Location = new System.Drawing.Point(110, 13);
			this.txtUbicazione.Name = "txtUbicazione";
			this.txtUbicazione.Size = new System.Drawing.Size(272, 20);
			this.txtUbicazione.TabIndex = 6;
			this.txtUbicazione.Tag = "locationview.locationcode?x";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnRemoveEpAcc);
			this.tabPage2.Controls.Add(this.groupBox3);
			this.tabPage2.Controls.Add(this.btnLinkEpAcc);
			this.tabPage2.Controls.Add(this.grpBoxSiopeEP);
			this.tabPage2.Controls.Add(this.grpBoxAccertamentiBudget);
			this.tabPage2.Controls.Add(this.grpBoxImpegniBudget);
			this.tabPage2.Controls.Add(this.gboxCompetenzaEconomica);
			this.tabPage2.Controls.Add(this.grpCausaleAnnullamento);
			this.tabPage2.Controls.Add(this.grpCausale);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(961, 497);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Text = "E/P";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnScollegaPreimpegno);
			this.groupBox3.Controls.Add(this.btnCollegaPreimpegno);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.label24);
			this.groupBox3.Controls.Add(this.txtNumPreimpegno);
			this.groupBox3.Controls.Add(this.txtEsercPreImpegno);
			this.groupBox3.Location = new System.Drawing.Point(8, 367);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(347, 64);
			this.groupBox3.TabIndex = 50;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Preimpegno di Budget selezionato manualmente";
			// 
			// btnScollegaPreimpegno
			// 
			this.btnScollegaPreimpegno.Location = new System.Drawing.Point(263, 29);
			this.btnScollegaPreimpegno.Name = "btnScollegaPreimpegno";
			this.btnScollegaPreimpegno.Size = new System.Drawing.Size(75, 23);
			this.btnScollegaPreimpegno.TabIndex = 15;
			this.btnScollegaPreimpegno.TabStop = false;
			this.btnScollegaPreimpegno.Tag = "";
			this.btnScollegaPreimpegno.Text = "Scollega";
			this.btnScollegaPreimpegno.Click += new System.EventHandler(this.btnScollegaPreimpegno_Click);
			// 
			// btnCollegaPreimpegno
			// 
			this.btnCollegaPreimpegno.Location = new System.Drawing.Point(180, 29);
			this.btnCollegaPreimpegno.Name = "btnCollegaPreimpegno";
			this.btnCollegaPreimpegno.Size = new System.Drawing.Size(75, 23);
			this.btnCollegaPreimpegno.TabIndex = 14;
			this.btnCollegaPreimpegno.TabStop = false;
			this.btnCollegaPreimpegno.Tag = "";
			this.btnCollegaPreimpegno.Text = "Collega";
			this.btnCollegaPreimpegno.Click += new System.EventHandler(this.btnCollegaPreimpegno_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(86, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(44, 13);
			this.label15.TabIndex = 7;
			this.label15.Text = "Numero";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(6, 16);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(49, 13);
			this.label24.TabIndex = 6;
			this.label24.Text = "Esercizio";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumPreimpegno
			// 
			this.txtNumPreimpegno.Location = new System.Drawing.Point(89, 32);
			this.txtNumPreimpegno.Name = "txtNumPreimpegno";
			this.txtNumPreimpegno.ReadOnly = true;
			this.txtNumPreimpegno.Size = new System.Drawing.Size(64, 20);
			this.txtNumPreimpegno.TabIndex = 3;
			this.txtNumPreimpegno.TabStop = false;
			this.txtNumPreimpegno.Tag = "pre_epexp.nepexp";
			// 
			// txtEsercPreImpegno
			// 
			this.txtEsercPreImpegno.Location = new System.Drawing.Point(6, 32);
			this.txtEsercPreImpegno.Name = "txtEsercPreImpegno";
			this.txtEsercPreImpegno.ReadOnly = true;
			this.txtEsercPreImpegno.Size = new System.Drawing.Size(64, 20);
			this.txtEsercPreImpegno.TabIndex = 2;
			this.txtEsercPreImpegno.TabStop = false;
			this.txtEsercPreImpegno.Tag = "pre_epexp.yepexp";
			// 
			// grpBoxSiopeEP
			// 
			this.grpBoxSiopeEP.Controls.Add(this.btnSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtDescSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtCodSiope);
			this.grpBoxSiopeEP.Location = new System.Drawing.Point(8, 145);
			this.grpBoxSiopeEP.Name = "grpBoxSiopeEP";
			this.grpBoxSiopeEP.Size = new System.Drawing.Size(242, 103);
			this.grpBoxSiopeEP.TabIndex = 49;
			this.grpBoxSiopeEP.TabStop = false;
			this.grpBoxSiopeEP.Tag = "AutoChoose.txtCodSiope.tree";
			this.grpBoxSiopeEP.Text = "Class.SIOPE";
			// 
			// btnSiope
			// 
			this.btnSiope.Location = new System.Drawing.Point(6, 46);
			this.btnSiope.Name = "btnSiope";
			this.btnSiope.Size = new System.Drawing.Size(61, 20);
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
			this.txtDescSiope.Size = new System.Drawing.Size(163, 52);
			this.txtDescSiope.TabIndex = 2;
			this.txtDescSiope.Tag = "sorting_siope.description";
			// 
			// txtCodSiope
			// 
			this.txtCodSiope.Location = new System.Drawing.Point(6, 72);
			this.txtCodSiope.Name = "txtCodSiope";
			this.txtCodSiope.ReadOnly = true;
			this.txtCodSiope.Size = new System.Drawing.Size(230, 20);
			this.txtCodSiope.TabIndex = 9;
			this.txtCodSiope.Tag = "sorting_siope.sortcode?x";
			// 
			// grpBoxAccertamentiBudget
			// 
			this.grpBoxAccertamentiBudget.Controls.Add(this.label11);
			this.grpBoxAccertamentiBudget.Controls.Add(this.label12);
			this.grpBoxAccertamentiBudget.Controls.Add(this.txtNumAccBudget);
			this.grpBoxAccertamentiBudget.Controls.Add(this.txtEsercAccBudget);
			this.grpBoxAccertamentiBudget.Location = new System.Drawing.Point(576, 367);
			this.grpBoxAccertamentiBudget.Name = "grpBoxAccertamentiBudget";
			this.grpBoxAccertamentiBudget.Size = new System.Drawing.Size(168, 64);
			this.grpBoxAccertamentiBudget.TabIndex = 48;
			this.grpBoxAccertamentiBudget.TabStop = false;
			this.grpBoxAccertamentiBudget.Text = "Accertamento di Budget";
			// 
			// btnRemoveEpAcc
			// 
			this.btnRemoveEpAcc.Location = new System.Drawing.Point(865, 389);
			this.btnRemoveEpAcc.Name = "btnRemoveEpAcc";
			this.btnRemoveEpAcc.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveEpAcc.TabIndex = 13;
			this.btnRemoveEpAcc.TabStop = false;
			this.btnRemoveEpAcc.Tag = "";
			this.btnRemoveEpAcc.Text = "Scollega";
			this.btnRemoveEpAcc.Visible = false;
			this.btnRemoveEpAcc.Click += new System.EventHandler(this.btnRemoveEpAcc_Click);
			// 
			// btnLinkEpAcc
			// 
			this.btnLinkEpAcc.Location = new System.Drawing.Point(784, 389);
			this.btnLinkEpAcc.Name = "btnLinkEpAcc";
			this.btnLinkEpAcc.Size = new System.Drawing.Size(75, 23);
			this.btnLinkEpAcc.TabIndex = 12;
			this.btnLinkEpAcc.TabStop = false;
			this.btnLinkEpAcc.Tag = "";
			this.btnLinkEpAcc.Text = "Collega";
			this.btnLinkEpAcc.Visible = false;
			this.btnLinkEpAcc.Click += new System.EventHandler(this.btnLinkEpAcc_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(90, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 13);
			this.label11.TabIndex = 7;
			this.label11.Text = "Numero";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(49, 13);
			this.label12.TabIndex = 6;
			this.label12.Text = "Esercizio";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumAccBudget
			// 
			this.txtNumAccBudget.Location = new System.Drawing.Point(89, 32);
			this.txtNumAccBudget.Name = "txtNumAccBudget";
			this.txtNumAccBudget.ReadOnly = true;
			this.txtNumAccBudget.Size = new System.Drawing.Size(64, 20);
			this.txtNumAccBudget.TabIndex = 3;
			this.txtNumAccBudget.TabStop = false;
			this.txtNumAccBudget.Tag = "epacc.nepacc";
			// 
			// txtEsercAccBudget
			// 
			this.txtEsercAccBudget.Location = new System.Drawing.Point(6, 32);
			this.txtEsercAccBudget.Name = "txtEsercAccBudget";
			this.txtEsercAccBudget.ReadOnly = true;
			this.txtEsercAccBudget.Size = new System.Drawing.Size(64, 20);
			this.txtEsercAccBudget.TabIndex = 2;
			this.txtEsercAccBudget.TabStop = false;
			this.txtEsercAccBudget.Tag = "epacc.yepacc";
			// 
			// grpBoxImpegniBudget
			// 
			this.grpBoxImpegniBudget.Controls.Add(this.label34);
			this.grpBoxImpegniBudget.Controls.Add(this.label33);
			this.grpBoxImpegniBudget.Controls.Add(this.txtNumIxBudget);
			this.grpBoxImpegniBudget.Controls.Add(this.txtEsercIxBudget);
			this.grpBoxImpegniBudget.Location = new System.Drawing.Point(381, 367);
			this.grpBoxImpegniBudget.Name = "grpBoxImpegniBudget";
			this.grpBoxImpegniBudget.Size = new System.Drawing.Size(168, 64);
			this.grpBoxImpegniBudget.TabIndex = 47;
			this.grpBoxImpegniBudget.TabStop = false;
			this.grpBoxImpegniBudget.Text = "Impegno di Budget";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(86, 16);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(44, 13);
			this.label34.TabIndex = 7;
			this.label34.Text = "Numero";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(6, 16);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(49, 13);
			this.label33.TabIndex = 6;
			this.label33.Text = "Esercizio";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumIxBudget
			// 
			this.txtNumIxBudget.Location = new System.Drawing.Point(89, 32);
			this.txtNumIxBudget.Name = "txtNumIxBudget";
			this.txtNumIxBudget.ReadOnly = true;
			this.txtNumIxBudget.Size = new System.Drawing.Size(64, 20);
			this.txtNumIxBudget.TabIndex = 3;
			this.txtNumIxBudget.TabStop = false;
			this.txtNumIxBudget.Tag = "epexp.nepexp";
			// 
			// txtEsercIxBudget
			// 
			this.txtEsercIxBudget.Location = new System.Drawing.Point(6, 32);
			this.txtEsercIxBudget.Name = "txtEsercIxBudget";
			this.txtEsercIxBudget.ReadOnly = true;
			this.txtEsercIxBudget.Size = new System.Drawing.Size(64, 20);
			this.txtEsercIxBudget.TabIndex = 2;
			this.txtEsercIxBudget.TabStop = false;
			this.txtEsercIxBudget.Tag = "epexp.yepexp";
			// 
			// gboxCompetenzaEconomica
			// 
			this.gboxCompetenzaEconomica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxCompetenzaEconomica.Controls.Add(this.rdEPKind_N);
			this.gboxCompetenzaEconomica.Controls.Add(this.rdEPKind_F);
			this.gboxCompetenzaEconomica.Controls.Add(this.rdEPKind_R);
			this.gboxCompetenzaEconomica.Controls.Add(this.txtEPStop);
			this.gboxCompetenzaEconomica.Controls.Add(this.label8);
			this.gboxCompetenzaEconomica.Controls.Add(this.txtEPStart);
			this.gboxCompetenzaEconomica.Controls.Add(this.label7);
			this.gboxCompetenzaEconomica.Location = new System.Drawing.Point(8, 269);
			this.gboxCompetenzaEconomica.Name = "gboxCompetenzaEconomica";
			this.gboxCompetenzaEconomica.Size = new System.Drawing.Size(937, 67);
			this.gboxCompetenzaEconomica.TabIndex = 3;
			this.gboxCompetenzaEconomica.TabStop = false;
			this.gboxCompetenzaEconomica.Text = "Competenza economica";
			// 
			// rdEPKind_N
			// 
			this.rdEPKind_N.AutoSize = true;
			this.rdEPKind_N.Location = new System.Drawing.Point(273, 33);
			this.rdEPKind_N.Name = "rdEPKind_N";
			this.rdEPKind_N.Size = new System.Drawing.Size(279, 17);
			this.rdEPKind_N.TabIndex = 6;
			this.rdEPKind_N.Tag = "mandatedetail.epkind:N";
			this.rdEPKind_N.Text = "Non generare ratei o scritture automatiche a fine anno";
			this.rdEPKind_N.UseVisualStyleBackColor = true;
			// 
			// rdEPKind_F
			// 
			this.rdEPKind_F.AutoSize = true;
			this.rdEPKind_F.Location = new System.Drawing.Point(734, 34);
			this.rdEPKind_F.Name = "rdEPKind_F";
			this.rdEPKind_F.Size = new System.Drawing.Size(114, 17);
			this.rdEPKind_F.TabIndex = 5;
			this.rdEPKind_F.Tag = "mandatedetail.epkind:F";
			this.rdEPKind_F.Text = "Fattura da ricevere";
			this.rdEPKind_F.UseVisualStyleBackColor = true;
			// 
			// rdEPKind_R
			// 
			this.rdEPKind_R.AutoSize = true;
			this.rdEPKind_R.Location = new System.Drawing.Point(568, 33);
			this.rdEPKind_R.Name = "rdEPKind_R";
			this.rdEPKind_R.Size = new System.Drawing.Size(143, 17);
			this.rdEPKind_R.TabIndex = 4;
			this.rdEPKind_R.Tag = "mandatedetail.epkind:R";
			this.rdEPKind_R.Text = "Genera rateo a fine anno";
			this.rdEPKind_R.UseVisualStyleBackColor = true;
			// 
			// txtEPStop
			// 
			this.txtEPStop.Location = new System.Drawing.Point(134, 33);
			this.txtEPStop.Name = "txtEPStop";
			this.txtEPStop.Size = new System.Drawing.Size(108, 20);
			this.txtEPStop.TabIndex = 3;
			this.txtEPStop.Tag = "mandatedetail.competencystop";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(130, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Data fine comp. econ.";
			// 
			// txtEPStart
			// 
			this.txtEPStart.Location = new System.Drawing.Point(10, 33);
			this.txtEPStart.Name = "txtEPStart";
			this.txtEPStart.Size = new System.Drawing.Size(114, 20);
			this.txtEPStart.TabIndex = 1;
			this.txtEPStart.Tag = "mandatedetail.competencystart";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 17);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(118, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Data inizio comp. econ.";
			// 
			// grpCausaleAnnullamento
			// 
			this.grpCausaleAnnullamento.Controls.Add(this.textBox2);
			this.grpCausaleAnnullamento.Controls.Add(this.txtCodiceCausaleAnnullamento);
			this.grpCausaleAnnullamento.Controls.Add(this.btnCausaleAnnullamento);
			this.grpCausaleAnnullamento.Location = new System.Drawing.Point(275, 36);
			this.grpCausaleAnnullamento.Name = "grpCausaleAnnullamento";
			this.grpCausaleAnnullamento.Size = new System.Drawing.Size(242, 103);
			this.grpCausaleAnnullamento.TabIndex = 2;
			this.grpCausaleAnnullamento.TabStop = false;
			this.grpCausaleAnnullamento.Tag = "AutoManage.txtCodiceCausaleAnnullamento.tree.(in_use=\'S\')";
			this.grpCausaleAnnullamento.Text = "Causale annullamento";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(91, 16);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(145, 56);
			this.textBox2.TabIndex = 2;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "accmotiveappliedannulment.motive";
			// 
			// txtCodiceCausaleAnnullamento
			// 
			this.txtCodiceCausaleAnnullamento.Location = new System.Drawing.Point(8, 74);
			this.txtCodiceCausaleAnnullamento.Name = "txtCodiceCausaleAnnullamento";
			this.txtCodiceCausaleAnnullamento.Size = new System.Drawing.Size(228, 20);
			this.txtCodiceCausaleAnnullamento.TabIndex = 1;
			this.txtCodiceCausaleAnnullamento.Tag = "accmotiveappliedannulment.codemotive?x";
			// 
			// btnCausaleAnnullamento
			// 
			this.btnCausaleAnnullamento.Location = new System.Drawing.Point(6, 47);
			this.btnCausaleAnnullamento.Name = "btnCausaleAnnullamento";
			this.btnCausaleAnnullamento.Size = new System.Drawing.Size(79, 23);
			this.btnCausaleAnnullamento.TabIndex = 0;
			this.btnCausaleAnnullamento.Tag = "manage.accmotiveappliedannulment.tree";
			this.btnCausaleAnnullamento.Text = "Causale";
			// 
			// grpCausale
			// 
			this.grpCausale.Controls.Add(this.txtDescrizioneCausale);
			this.grpCausale.Controls.Add(this.txtCodiceCausale);
			this.grpCausale.Controls.Add(this.btnCausaleEP);
			this.grpCausale.Location = new System.Drawing.Point(8, 36);
			this.grpCausale.Name = "grpCausale";
			this.grpCausale.Size = new System.Drawing.Size(242, 103);
			this.grpCausale.TabIndex = 1;
			this.grpCausale.TabStop = false;
			this.grpCausale.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
			this.grpCausale.Text = "Causale";
			// 
			// txtDescrizioneCausale
			// 
			this.txtDescrizioneCausale.Location = new System.Drawing.Point(95, 16);
			this.txtDescrizioneCausale.Multiline = true;
			this.txtDescrizioneCausale.Name = "txtDescrizioneCausale";
			this.txtDescrizioneCausale.ReadOnly = true;
			this.txtDescrizioneCausale.Size = new System.Drawing.Size(141, 56);
			this.txtDescrizioneCausale.TabIndex = 2;
			this.txtDescrizioneCausale.TabStop = false;
			this.txtDescrizioneCausale.Tag = "accmotiveapplied.motive";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(6, 75);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(230, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?x";
			// 
			// btnCausaleEP
			// 
			this.btnCausaleEP.Location = new System.Drawing.Point(6, 46);
			this.btnCausaleEP.Name = "btnCausaleEP";
			this.btnCausaleEP.Size = new System.Drawing.Size(83, 23);
			this.btnCausaleEP.TabIndex = 0;
			this.btnCausaleEP.Tag = "manage.accmotiveapplied.tree";
			this.btnCausaleEP.Text = "Causale";
			// 
			// tabMagazzino
			// 
			this.tabMagazzino.Controls.Add(this.chktounload);
			this.tabMagazzino.Controls.Add(this.label1);
			this.tabMagazzino.Controls.Add(this.dgrDettMagazzino);
			this.tabMagazzino.Location = new System.Drawing.Point(4, 22);
			this.tabMagazzino.Name = "tabMagazzino";
			this.tabMagazzino.Padding = new System.Windows.Forms.Padding(3);
			this.tabMagazzino.Size = new System.Drawing.Size(961, 497);
			this.tabMagazzino.TabIndex = 5;
			this.tabMagazzino.Text = "Magazzino";
			this.tabMagazzino.UseVisualStyleBackColor = true;
			// 
			// chktounload
			// 
			this.chktounload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chktounload.AutoSize = true;
			this.chktounload.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chktounload.Location = new System.Drawing.Point(705, 37);
			this.chktounload.Name = "chktounload";
			this.chktounload.Size = new System.Drawing.Size(243, 17);
			this.chktounload.TabIndex = 32;
			this.chktounload.Tag = "mandatedetail.flagto_unload:S:N";
			this.chktounload.Text = "Scarico immediato, non transita dal magazzino";
			this.chktounload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chktounload.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 16);
			this.label1.TabIndex = 31;
			this.label1.Text = "Elenco merce in magazzino";
			// 
			// dgrDettMagazzino
			// 
			this.dgrDettMagazzino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrDettMagazzino.DataMember = "";
			this.dgrDettMagazzino.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrDettMagazzino.Location = new System.Drawing.Point(11, 60);
			this.dgrDettMagazzino.Name = "dgrDettMagazzino";
			this.dgrDettMagazzino.Size = new System.Drawing.Size(937, 430);
			this.dgrDettMagazzino.TabIndex = 30;
			this.dgrDettMagazzino.Tag = "stockview.dettordine";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.txtAppunti);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(961, 497);
			this.tabPage5.TabIndex = 6;
			this.tabPage5.Text = "Appunti";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// tabPCC
			// 
			this.tabPCC.Controls.Add(this.grpPcc);
			this.tabPCC.Location = new System.Drawing.Point(4, 22);
			this.tabPCC.Name = "tabPCC";
			this.tabPCC.Size = new System.Drawing.Size(961, 497);
			this.tabPCC.TabIndex = 7;
			this.tabPCC.Text = "PCC";
			this.tabPCC.UseVisualStyleBackColor = true;
			// 
			// grpPcc
			// 
			this.grpPcc.Controls.Add(this.grpNaturadiSpesa);
			this.grpPcc.Controls.Add(this.btnCasuale);
			this.grpPcc.Controls.Add(this.txtCausale);
			this.grpPcc.Controls.Add(this.label30);
			this.grpPcc.Controls.Add(this.cmbStatodelDebito);
			this.grpPcc.Location = new System.Drawing.Point(3, 19);
			this.grpPcc.Name = "grpPcc";
			this.grpPcc.Size = new System.Drawing.Size(805, 191);
			this.grpPcc.TabIndex = 29;
			this.grpPcc.TabStop = false;
			// 
			// grpNaturadiSpesa
			// 
			this.grpNaturadiSpesa.Controls.Add(this.rdbContoCapitale);
			this.grpNaturadiSpesa.Controls.Add(this.rdbSpesaCorrente);
			this.grpNaturadiSpesa.Location = new System.Drawing.Point(556, 19);
			this.grpNaturadiSpesa.Name = "grpNaturadiSpesa";
			this.grpNaturadiSpesa.Size = new System.Drawing.Size(243, 69);
			this.grpNaturadiSpesa.TabIndex = 33;
			this.grpNaturadiSpesa.TabStop = false;
			this.grpNaturadiSpesa.Text = "Natura di spesa";
			// 
			// rdbContoCapitale
			// 
			this.rdbContoCapitale.AutoSize = true;
			this.rdbContoCapitale.Location = new System.Drawing.Point(8, 37);
			this.rdbContoCapitale.Name = "rdbContoCapitale";
			this.rdbContoCapitale.Size = new System.Drawing.Size(93, 17);
			this.rdbContoCapitale.TabIndex = 25;
			this.rdbContoCapitale.TabStop = true;
			this.rdbContoCapitale.Tag = "mandatedetail.expensekind:CA";
			this.rdbContoCapitale.Text = "Conto capitale";
			this.rdbContoCapitale.UseVisualStyleBackColor = true;
			// 
			// rdbSpesaCorrente
			// 
			this.rdbSpesaCorrente.AutoSize = true;
			this.rdbSpesaCorrente.Location = new System.Drawing.Point(8, 14);
			this.rdbSpesaCorrente.Name = "rdbSpesaCorrente";
			this.rdbSpesaCorrente.Size = new System.Drawing.Size(97, 17);
			this.rdbSpesaCorrente.TabIndex = 24;
			this.rdbSpesaCorrente.TabStop = true;
			this.rdbSpesaCorrente.Tag = "mandatedetail.expensekind:CO";
			this.rdbSpesaCorrente.Text = "Spesa corrente";
			this.rdbSpesaCorrente.UseVisualStyleBackColor = true;
			// 
			// btnCasuale
			// 
			this.btnCasuale.BackColor = System.Drawing.SystemColors.Control;
			this.btnCasuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCasuale.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCasuale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCasuale.ImageIndex = 0;
			this.btnCasuale.Location = new System.Drawing.Point(9, 87);
			this.btnCasuale.Name = "btnCasuale";
			this.btnCasuale.Size = new System.Drawing.Size(57, 23);
			this.btnCasuale.TabIndex = 31;
			this.btnCasuale.TabStop = false;
			this.btnCasuale.Tag = "";
			this.btnCasuale.Text = "Causale";
			this.btnCasuale.UseVisualStyleBackColor = false;
			this.btnCasuale.Click += new System.EventHandler(this.btnCasuale_Click);
			// 
			// txtCausale
			// 
			this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCausale.Location = new System.Drawing.Point(10, 116);
			this.txtCausale.Multiline = true;
			this.txtCausale.Name = "txtCausale";
			this.txtCausale.ReadOnly = true;
			this.txtCausale.Size = new System.Drawing.Size(381, 69);
			this.txtCausale.TabIndex = 32;
			this.txtCausale.TabStop = false;
			this.txtCausale.Tag = "";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(6, 19);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(96, 21);
			this.label30.TabIndex = 30;
			this.label30.Text = "Stato del debito";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbStatodelDebito
			// 
			this.cmbStatodelDebito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatodelDebito.DataSource = this.DS.pccdebitstatus;
			this.cmbStatodelDebito.DisplayMember = "description";
			this.cmbStatodelDebito.Location = new System.Drawing.Point(10, 40);
			this.cmbStatodelDebito.Name = "cmbStatodelDebito";
			this.cmbStatodelDebito.Size = new System.Drawing.Size(455, 21);
			this.cmbStatodelDebito.TabIndex = 29;
			this.cmbStatodelDebito.Tag = "mandatedetail.idpccdebitstatus";
			this.cmbStatodelDebito.ValueMember = "idpccdebitstatus";
			// 
			// btnCodice
			// 
			this.btnCodice.Location = new System.Drawing.Point(0, 0);
			this.btnCodice.Name = "btnCodice";
			this.btnCodice.Size = new System.Drawing.Size(75, 23);
			this.btnCodice.TabIndex = 0;
			// 
			// Frm_mandatedetail_single
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(995, 576);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Frm_mandatedetail_single";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmdettordinegenericosingle";
			this.grpValoreUnitInValuta.ResumeLayout(false);
			this.grpValoreUnitInValuta.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.grpInventario.ResumeLayout(false);
			this.grpInventario.PerformLayout();
			this.grpTipoBene.ResumeLayout(false);
			this.gboxIVA.ResumeLayout(false);
			this.gboxIVA.PerformLayout();
			this.gboxImponibile.ResumeLayout(false);
			this.gboxImponibile.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPrincipale.ResumeLayout(false);
			this.tabPrincipale.PerformLayout();
			this.grpRegistry.ResumeLayout(false);
			this.grpRegistry.PerformLayout();
			this.gboxListino.ResumeLayout(false);
			this.gboxListino.PerformLayout();
			this.gboxPagato.ResumeLayout(false);
			this.gboxPagato.PerformLayout();
			this.grpAttivita.ResumeLayout(false);
			this.grpTipoIva.ResumeLayout(false);
			this.grpTipoIva.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.gBoxupbIVA.ResumeLayout(false);
			this.gBoxupbIVA.PerformLayout();
			this.tabAnalitico.ResumeLayout(false);
			this.grpRipartizioneCosti.ResumeLayout(false);
			this.grpRipartizioneCosti.PerformLayout();
			this.gboxclass3.ResumeLayout(false);
			this.gboxclass3.PerformLayout();
			this.gboxclass2.ResumeLayout(false);
			this.gboxclass2.PerformLayout();
			this.gboxclass1.ResumeLayout(false);
			this.gboxclass1.PerformLayout();
			this.tabFatturazione.ResumeLayout(false);
			this.tabFatturazione.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.grpAutoLocation.ResumeLayout(false);
			this.grpAutoLocation.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.grpBoxSiopeEP.ResumeLayout(false);
			this.grpBoxSiopeEP.PerformLayout();
			this.grpBoxAccertamentiBudget.ResumeLayout(false);
			this.grpBoxAccertamentiBudget.PerformLayout();
			this.grpBoxImpegniBudget.ResumeLayout(false);
			this.grpBoxImpegniBudget.PerformLayout();
			this.gboxCompetenzaEconomica.ResumeLayout(false);
			this.gboxCompetenzaEconomica.PerformLayout();
			this.grpCausaleAnnullamento.ResumeLayout(false);
			this.grpCausaleAnnullamento.PerformLayout();
			this.grpCausale.ResumeLayout(false);
			this.grpCausale.PerformLayout();
			this.tabMagazzino.ResumeLayout(false);
			this.tabMagazzino.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettMagazzino)).EndInit();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPCC.ResumeLayout(false);
			this.grpPcc.ResumeLayout(false);
			this.grpPcc.PerformLayout();
			this.grpNaturadiSpesa.ResumeLayout(false);
			this.grpNaturadiSpesa.PerformLayout();
			this.ResumeLayout(false);

		}
        #endregion

        void VisualizzaControlliContabilizzazioneImpAccBudget() {            
            DataRow Curr = DS.mandatedetail.Rows[0];            
            //if (Curr["idepacc"] == DBNull.Value) {
            //    btnLinkEpAcc.Visible = true; // Collega accertamento di Budget
            //    btnRemoveEpAcc.Visible = false; // Scollega accertamento di Budget
            //}
            //else {
            //    btnLinkEpAcc.Visible = false;
            //    btnRemoveEpAcc.Visible = true;
            //}
            bool AccertamentoDiBudgetAbilitato = false;

            object idaccmotive = Curr["idaccmotiveannulment"];
            if (idaccmotive != DBNull.Value) {
                DataTable t = Conn.RUN_SELECT("accmotivedetail", "*", null,
                    QHS.AppAnd(QHS.CmpEq("ayear", Conn.GetEsercizio()), QHS.CmpEq("idaccmotive", idaccmotive)), null,
                    false);
                if (t != null && t.Rows.Count == 1) {
                    int flagaccountusage = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account",
                                    QHS.CmpEq("idacc", t.Rows[0]["idacc"]),
                                "flagaccountusage"));
                    //if ((flagaccountusage & 320) != 0) ImpegnoDiBudgetAbilitato = true;
                    if ((flagaccountusage & 128) != 0) AccertamentoDiBudgetAbilitato = true;

                }
            }

            grpBoxAccertamentiBudget.Enabled = AccertamentoDiBudgetAbilitato;

        }
        private void btnLinkEpAcc_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            DataRow Curr = DS.mandatedetail.Rows[0];
            MetaData.GetFormData(this, true);

            string FilterAccBudget = GetFilterForEpacc(Curr);

            string VistaScelta = "epaccview";

            MetaData Mepacc = Meta.Dispatcher.Get(VistaScelta);
            Mepacc.FilterLocked = true;
            Mepacc.DS = DS;
            DataRow MyDR = Mepacc.SelectOne("default", FilterAccBudget, null, null);

            if (MyDR != null) {
                Curr["idepacc"] = MyDR["idepacc"];
                Meta.FreshForm();
            }

        }

        private void btnRemoveEpAcc_Click(object sender, EventArgs e) {
            DataRow Curr = DS.mandatedetail.Rows[0];
            Curr["idepacc"] = DBNull.Value;
            DS.epacc.Clear();
            txtEsercAccBudget.Text = "";
            txtNumAccBudget.Text = "";
            Meta.FreshForm();
        }

        //La funzione fornisce un filtro sui potenziali accertamenti di budget da selezionare
        public string GetFilterForEpacc(DataRow Curr) {
            int nphase = 2; // Accertamento
            string Filterbase = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("nphase", nphase));

            //Se la fattura è collegata a dettaglio C.A., prenderemo l'accertamento di budget di quel dettaglio.            
            //La scelta va fatta solo sugli Accertamenti di Budget imputati a Conti di Ricavi
            Filterbase = QHS.AppAnd(Filterbase, QHS.CmpEq("revenue", "S"));
            if (Curr["idupb"] != null && Curr["idupb"] != DBNull.Value) {
                Filterbase = QHS.AppAnd(Filterbase, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            return Filterbase;
        }

	    public string GetFilterForEpExp(DataRow Curr) {
	        int nphase = 1; // Preimpegno
	        string Filterbase = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("nphase", nphase));

	        //Se la fattura è collegata a dettaglio C.A., prenderemo l'accertamento di budget di quel dettaglio.            
	        //La scelta va fatta solo sugli Accertamenti di Budget imputati a Conti di Ricavi
	        Filterbase = QHS.AppAnd(Filterbase,QHS.CmpGt("totavailable",0),
	                QHS.DoPar(QHS.AppOr(QHS.CmpEq("fixedassets","S"),QHS.CmpEq("cost", "S")))) ;
	        if (Curr["idupb"] != null && Curr["idupb"] != DBNull.Value) {
	            Filterbase = QHS.AppAnd(Filterbase, QHS.CmpEq("idupb", Curr["idupb"]));
	        }

	        return Filterbase;
	    }

        bool abilitaLotti(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            int flag = CfgFn.GetNoNullInt32(r[0]["flag"]) & 1;
            if (flag == 0) return true;

            return false;
        }
        bool abilitaConsip(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            int flag = CfgFn.GetNoNullInt32(r[0]["flag"]) & 2;
            if (flag == 0) return true;

            return false;
        }
        bool abilitaMagazzino(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            int flag = CfgFn.GetNoNullInt32(r[0]["assetkind"]) & 8;
            if (flag != 0) return true;

            return false;
        }
        bool abilitaTipoIva(object idmankind)
        {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            object ivakind_forced = r[0]["idivakind_forced"];
            if (ivakind_forced == DBNull.Value) return true;

            return false;
        }
        /// <summary>
        /// Filtro calcolato in base al tipo documento collegabile o meno al tipo fattura (aliquote=0 o tutte)
        /// </summary>
	    private string basefilteriva = "";

	

		DataAccess Conn;
        string filterEpOperation;
	    private string filterEpAnnullOperation;

	    public void MetaData_AfterLink() {
	        Meta = MetaData.GetMetaData(this);
	        Conn = Meta.Conn;
	        QHC = new CQueryHelper();
	        QHS = Conn.GetQueryHelper();
	        AccMotiveManager AM = new AccMotiveManager(grpCausale);
	        AccMotiveManager AM01 = new AccMotiveManager(grpCausaleAnnullamento);
	        HelpForm.SetDenyNull(DS.mandatedetail.Columns["toinvoice"], true);
	        HelpForm.SetDenyNull(DS.mandatedetail.Columns["tax"], true);
	        tassocambio = 1;
	        codiceresponsabile = DBNull.Value;
	        Hashtable h = (Hashtable) Meta.ExtraParameter;
	        if (h == null) {
	            grpValoreUnitInValuta.Text += "(non impostata)";
	            tassocambio = 1;
	            codiceresponsabile = DBNull.Value;
	        }
	        else {
	            grpValoreUnitInValuta.Text += "(" + h["nomevaluta"].ToString() + ")";
	            tassocambio = Convert.ToDouble(h["cambio"]);
	            codiceresponsabile = h["codiceresponsabile"];
	        }

            DS.pre_epexp.setTableForReading("epexp");

	        filterEpOperation = QHS.CmpEq("idepoperation", "fatacq"); //maria
	        filterEpAnnullOperation = QHS.CmpEq("idepoperation", "fatacq");
	        //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
	        filterEpOperation = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperation, Conn);
	        DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation; //maria
	        DS.accmotiveappliedannulment.ExtendedProperties[MetaData.ExtraParams] = filterEpAnnullOperation; //maria

	        GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperation); //maria
	        GetData.SetStaticFilter(DS.accmotiveappliedannulment, filterEpAnnullOperation); //maria


	        //string filterCapogruppo = Meta.ExtraParameter as string;
	        //GetData.SetStaticFilter(DS.mandateavcp, filterCapogruppo);


	        DataRow DR = Meta.SourceRow;

	        if (DR["stop"] != DBNull.Value) {
	            DateTime stop = (DateTime) DR["stop"];
                if (stop.Year != Conn.GetEsercizio() && (DR.RowState != DataRowState.Added)) txtStop.ReadOnly = true;
                if (DR.RowState==DataRowState.Unchanged)txtStop.ReadOnly = true;
	            if (DR.RowState==DataRowState.Modified 
                    && DR["stop",DataRowVersion.Original]!=DBNull.Value)txtStop.ReadOnly = true;
	        }

            
	        if (DR.RowState!=DataRowState.Added) txtStart.ReadOnly = true;

		
			DataTable MandateKind = Conn.RUN_SELECT("mandatekind", "*", null,
	            QHS.CmpEq("idmankind", DR["idmankind"]), null, null, true);

	        if (MandateKind == null || MandateKind.Rows.Count == 0) {
	            show("E' necessario scegliere prima il tipo contratto nel contratto passivo", "Errore");
	            Meta.ErroreIrrecuperabile = true;
	            return;
	        }
	        string statfilterivakind = "";
	        bool isrequest = false;
	        bool ShowRegistry = true;

	        string multiReg = MandateKind.Rows[0]["multireg"].ToString();
	        isrequest = MandateKind.Rows[0]["isrequest"].ToString().ToUpper() == "S";
	        if (multiReg == "S") {
	            grpRegistry.Visible = true;
	        }
	        else {
	            grpRegistry.Visible = false;
	            ShowRegistry = false;
	            //MakeSpaceFrom(grpRegistry);

	        }
			string filterthis = null;
	            if (Meta.EditMode) filterthis = QHS.CmpEq("idivakind", DR["idivakind"]);

	        string linktoinvoice = MandateKind.Rows[0]["linktoinvoice"].ToString();
	        if (linktoinvoice == "N" && (isrequest == false)) {
	          
	            statfilterivakind = QHS.AppAnd(QHS.NullOrEq("active", "S"), QHS.NullOrEq("rate", 0));
	        }
	        DataTable parentTable = DR.Table.DataSet.Tables["mandate"];
	        DataRow drParent = DR.GetParentRow(QueryCreator.GetParentChildRel(parentTable, DR.Table));
	        if (drParent.RowState != DataRowState.Added && linktoinvoice=="S") {
                //Verifica se ci sono ratei o scritture di fatt. a ricevere 
	            string idrelated = EP_functions.GetIdForDocument(drParent);
	            idrelated = idrelated + "§" + DR["rownum"];
	            int nRatei = Conn.RUN_SELECT_COUNT("entrydetail", QHS.CmpEq("idrelated", idrelated), false);
	            if (nRatei > 0) {
	                gboxCompetenzaEconomica.Enabled = false;
	            }
	        }

            if (linktoinvoice == "N") {
	            rdEPKind_F.Enabled = false;
	            rdEPKind_R.Enabled = false;
	            grpRipartizioneCosti.Enabled = true;
	        }
	        else {
	            grpRipartizioneCosti.Enabled = false;
	        }
	        //if (linktoinvoice == "N") {
	        //    grpPcc.Enabled = true;
	        //}
	        //else {
	        //    grpPcc.Enabled = false;
	        //}


	        //Filtriamo gli upb con lo stesso tipo attività del Tipo contratto passivo.
	        //Le upb con tipoattività 'qualsiasi' verranno sempre mostrate
	        int flagactivity = 0;

	        flagactivity = CfgFn.GetNoNullInt32(MandateKind.Rows[0]["flagactivity"]);

	        string filterAactivityUpb = "";

	        if (flagactivity == 1) {
	            //istituzionale
	            rdbCommerciale.Enabled = rdbPromiscua.Enabled = rdbQualsiasi.Enabled = false;
	            filterAactivityUpb = QHS.CmpEq("flagactivity", 1);
	        }

	        if (flagactivity == 2) {
	            //commerciale
	            rdbPromiscua.Enabled = rdbIstituzionale.Enabled = rdbAltro.Enabled = false;
	            filterAactivityUpb = QHS.CmpEq("flagactivity", 2);
	        }

	        //if (flagactivity == 3) { //promiscua
	        //    rdbCommerciale.Enabled = rdbIstituzionale.Enabled = rdbAltro.Enabled = false;
	        //    filterAactivityUpb = QHS.CmpEq("flagactivity", 4);
	        //}

	        if (filterAactivityUpb != "") {
	            filterAactivityUpb = QHS.AppOr(QHS.CmpEq("flagactivity", 4), filterAactivityUpb);
	        }
	        



	        ImpostaTageFiltriUPB(CfgFn.GetNoNullInt32(DR["flagactivity"]), DR["idupb"]);


	        int flag = 0;
	        flag = CfgFn.GetNoNullInt32(MandateKind.Rows[0]["flagactivity"]);

	        string filterivakind = "";
	        if (flag == 1) filterivakind = QHS.BitSet("flag", 0);
	        if (flag == 2) filterivakind = QHS.BitSet("flag", 1);
	        if (flag == 3) filterivakind = QHS.BitSet("flag", 2);

	        DataRow DRP = Meta.SourceRow.GetParentRow("mandatemandatedetail");
	        string flagintracom = DRP["flagintracom"].ToString();

	        if (flagintracom == "N") filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 6)); //Italia
	        if (flagintracom == "S") filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 7)); //Intra-UE
	        if (flagintracom == "X") filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 8)); //Extra-UE


	        if (filterivakind != "" && DR["idivakind"] != DBNull.Value) {
	            filterivakind = QHS.AppOr(QHS.CmpEq("idivakind", DR["idivakind"]), filterivakind);
	        }
	        statfilterivakind = QHS.AppAnd(statfilterivakind, filterivakind);

			statfilterivakind= QHS.AppOr(statfilterivakind, filterthis);
			if (statfilterivakind!="")statfilterivakind = QHS.DoPar(statfilterivakind);

	        GetData.SetStaticFilter(DS.ivakind, statfilterivakind);


	        DataAccess.SetTableForReading(DS.sorting1, "sorting");
	        DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.upb_iva, "upb");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
	        DataAccess.SetTableForReading(DS.expense_imponibile, "expense");
	        DataAccess.SetTableForReading(DS.expense_iva, "expense");
	        DataAccess.SetTableForReading(DS.accmotiveappliedannulment, "accmotiveapplied");
	        DataTable tConfig = Conn.RUN_SELECT("config", "*", null,
	            QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);

	        if (tConfig == null || tConfig.Rows.Count == 0) {
	            show("Configurazione annuale non trovata.", "Errore");
	            Meta.ErroreIrrecuperabile = true;
	            return;
	        }

	        DataRow R = tConfig.Rows[0];
	        object idsorkind1 = R["idsortingkind1"];
	        object idsorkind2 = R["idsortingkind2"];
	        object idsorkind3 = R["idsortingkind3"];
	        CfgFn.SetGBoxClass(this, 1, idsorkind1);
	        CfgFn.SetGBoxClass(this, 2, idsorkind2);
	        CfgFn.SetGBoxClass(this, 3, idsorkind3);
	        if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
	            tabControl1.TabPages.Remove(tabAnalitico);
	        }

	        bool removeIvaTab = true;
	        foreach (string COL in new string[] {
	            "agencycode", "deferredexpensephase", "deferredincomephase",
	            "flagpayment", "flagrefund", "idfinivapayment", "idfinivarefund", "idivapayperiodicity", "minpayment",
	            "minrefund", "paymentagency", "refundagency"
	        }) {
	            if (R[COL] == DBNull.Value) continue;
	            removeIvaTab = false;
	            break;
	        }

	        if (removeIvaTab) {
	            tabControl1.TabPages.Remove(tabFatturazione);
	        }

            //MODIFICHE TASK 10565 (commentato codice sottostante poiché inutile)
            //DataTable DetailsMandate = DR.Table.DataSet.Tables["mandatedetail"];
            //string filter = QHC.CmpEq("idgroup", DR["idgroup"]);
            //DataRow[] Selected = DetailsMandate.Select(filter);
            //FINE MODIFICHE TASK 10565
            //decimal detailsGroup = Selected.Length;
            //if (detailsGroup > 1) {
            //    DisableEditGroup();
            //DisableIfBrother(Selected);//Disabilita i text se un fratello è stato contabilizzato
            //if ((DR["idexp_iva"] != DBNull.Value) || (DR["idexp_taxable"] != DBNull.Value)) {
            //DisablePostLinked();  // Anche se il dett.è contabilizzato tutte le info saranno editabili
            //    }
            //}

            int countList = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("list", null, "count(*)"));
	        if (countList == 0) {
	            gboxListino.Visible = false;
	            this.Controls.Remove(gboxListino);
	            //MakeSpaceFrom(gboxListino);
	        }
	        else {
	            gboxListino.Visible = true;
	        }

	        if (ShowRegistry == false && (countList == 0)) {
	            MakeSpaceFrom(grpRegistry);
	        }
	        List<string> ls = new List<string>();
	        ls.Add("");

	        string oldval = DR["cigcode"].ToString();

	        DataTable cigs = DR.Table.DataSet.Tables["mandatecig"];
	        if (cigs.Select().Length > 0) {
	            foreach (DataRow rc in cigs.Select()) {
	                ls.Add(rc["cigcode"].ToString());
	            }

	            if (oldval != "" && !ls.Contains(oldval)) ls.Add(oldval);

	            cmbCIG.DropDownStyle = ComboBoxStyle.DropDownList;
	            cmbCIG.DataSource = ls.ToArray();
	            cmbCIG.Text = oldval;
	            if (ls.Count == 1) {
	                cmbCIG.Enabled = false;
	                if (oldval == "") cmbCIG.Text = ls[0];
	            }
	        }
	        else {
	            DataTable mdet = DR.Table.DataSet.Tables["mandatedetail"];
	            foreach (DataRow rc in mdet.Select()) {
	                string c = rc["cigcode"].ToString();
	                if (c == "") continue;
	                if (ls.Contains(c)) continue;
	                ls.Add(c);
	            }
	            cmbCIG.DropDownStyle = ComboBoxStyle.DropDown;
	            cmbCIG.DataSource = ls.ToArray();
	            cmbCIG.Text = oldval;
	        }
	        GetData.CacheTable(DS.pccdebitmotive);
	        GetData.SetSorting(DS.pccdebitmotive, "listingorder asc");
	        GetData.SetSorting(DS.pccdebitstatus, "listingorder asc");
             SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, true, DS.sorting_siope);

			int esercizio = Conn.GetEsercizio();
			int yman = CfgFn.GetNoNullInt32(DR["yman"]);
			DateTime primoGennaio = new DateTime(esercizio, 1, 1);

			if ((yman < esercizio) && (DR["idepexp"] != DBNull.Value)) {
				//Non modifica la causale EP per dettagli degli anni precedenti associati a impegni di budget
				btnListino.Enabled = false;
			    txtListino.ReadOnly = true;
                btnCausaleEP.Enabled = false;
                txtCodiceCausale.ReadOnly = true;
                //btnCausaleAnnullamento.Enabled = false;
                //txtCodiceCausaleAnnullamento.ReadOnly = true;
                btnUPB.Enabled = false;
                txtUPB.ReadOnly = true;
                buttonupbIVA.Enabled = false;
                txtUPBiva.ReadOnly = true;
			}
		
		}

		siope_helper SiopeObj;
        void VisualizzaNascondiLotti(bool visualizza) {            
            lblcig.Visible = visualizza;
            cmbCIG.Visible = visualizza;
        }

        void VisualizzaNascondiMagazzino(bool visualizza) {
            if (visualizza) {
                if (!tabControl1.TabPages.Contains(tabMagazzino)) {
                    tabControl1.TabPages.Insert(5, tabMagazzino);

                }
            }
            else {
                if (tabControl1.TabPages.Contains(tabMagazzino)) {
                    tabControl1.TabPages.Remove(tabMagazzino);

                }
            }
        }
        void ForzaTipoIvaDaTipoContratto(bool forzaTipoIva)
        {
            if (forzaTipoIva)
            {
                grpTipoIva.Enabled = true;

            }
            else
            {
                grpTipoIva.Enabled = false; ;
            }
        }
        bool abilitaFattura(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            string flag = r[0]["linktoinvoice"].ToString().ToUpper();
            if (flag == "S") return true;

            return false;
        }

        void VisualizzaNascondiFattura(bool visualizza) {
            if (visualizza) {
                if (!tabControl1.TabPages.Contains(tabFatturazione)) {
                    tabControl1.TabPages.Insert(2, tabFatturazione);

                }
            }
            else {
                if (tabControl1.TabPages.Contains(tabFatturazione)) {
                    tabControl1.TabPages.Remove(tabFatturazione);

                }
            }
        }
        void MakeSpaceFrom(GroupBox G) {
			TabPage T = (TabPage)G.Parent;
			int disp = G.Height;
			int y0 = G.Location.Y;
			T.SuspendLayout();
			foreach (Control C in T.Controls) {
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
			T.Size = new Size(T.Size.Width, T.Size.Height - disp);
			T.ResumeLayout();
		}
		object GetCtrlByName(string Name){
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			//if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			//Label L =  (Label) Ctrl.GetValue(this);                        
			//return L;
			return Ctrl.GetValue(this);
		}

        //MODIFICHE TASK 10565 (commentato codice sottostante poiché inutile)
        //void DisablePostLinked()
        //{
        //    txtImponibile.Enabled = false;
        //    //TxtIvaValutaTot.Enabled=false;
        //    //txtImpDeducValuta.Enabled=false;
        //    gboxUPB.Enabled = false;
        //    gboxUPB.Tag = null;
        //    txtUPB.Enabled = false;
        //    btnUPB.Enabled = false;
        //}
        //FINE MODIFICHE TASK 10565

        //void DisableIfBrother(DataRow[] rBrother) {
        //    int nContabilizzazioni = 0;
        //    foreach (DataRow R in rBrother) {
        //        if ((R["idexp_iva"] != DBNull.Value) || (R["idexp_taxable"] != DBNull.Value)) {
        //            nContabilizzazioni++;
        //        }
        //    }
        //    if(nContabilizzazioni>0){
        //        grpCausale.Enabled = false;
        //        grpCausaleAnnullamento.Enabled = false;
        //        grpRegistry.Enabled = false;
        //        grpTipoIva.Enabled = false;
        //        txtQuantita.Enabled = false;
        //        txtQuantitaConfezioni.Enabled = false;
        //        txtSconto.Enabled = false;
        //        txtDescrizione.Enabled = false;
        //        txtStart.Enabled = false;
        //        grpTipoBene.Enabled = false;
        //        grpInventario.Enabled = false;
        //        chkPromiscuo.Enabled = false;
        //        grpAttivita.Enabled = false;
        //        gboxListino.Enabled = false;
        //        GruppiDisabilitati = true;
        //        chktounload.Enabled = false;

        //        txtImponibile.Enabled = false;
        //        txtStop.Enabled = false;
        //        //gboxCompetenza.Enabled = false;
        //    }
        //}



        //MODIFICHE TASK 10565 (commentato codice sottostante poiché inutile)

        //void DisableEditGroup(){
        //          grpCausale.Enabled = false;
        //          grpCausaleAnnullamento.Enabled = false;
        //	grpRegistry.Enabled = false;
        //          grpTipoIva.Enabled = false;
        //          txtQuantita.Enabled = false;
        //          txtQuantitaConfezioni.Enabled = false;
        //          txtSconto.Enabled = false;
        //	txtDescrizione.Enabled = false; 
        //	txtStart.Enabled= false;
        //          grpTipoBene.Enabled = false;
        //          grpInventario.Enabled = false;
        //          chkPromiscuo.Enabled = false;
        //          grpAttivita.Enabled = false;
        //          gboxListino.Enabled = false;
        //          GruppiDisabilitati = true;
        //          chktounload.Enabled = false;

        //          txtImponibile.Enabled = false;
        //          txtStop.Enabled = false;
        //          //gboxCompetenza.Enabled = false;

        //      }

        //FINE MODIFICHE TASK 10565

        public void MetaData_AfterGetFormData() {
            DataRow curr = DS.mandatedetail.Rows[0];


            //MOFICIHE TASK 10671
            if (curr["stop"] != DBNull.Value && curr["stop"].ToString() != "") {
                curr["toinvoice"] = "N";
            }

            if (cmbCIG.Text.Trim() == "") {
                curr["cigcode"] = DBNull.Value;
            }
            else {
                curr["cigcode"] = cmbCIG.Text.Trim();
            }

        }

        public void MetaData_AfterPost() {



            Meta.SourceRow.Table.ExtendedProperties["RigaModificata"] = Meta.SourceRow;
        }
        public void MetaData_BeforeFill() {
            DataRow curr = DS.mandatedetail.Rows[0];

            if (Meta.FirstFillForThisRow) {
                VisualizzaNascondiMagazzino(abilitaMagazzino(curr["idmankind"]));
                VisualizzaNascondiLotti(abilitaLotti(curr["idmankind"]));
                VisualizzaNascondiFattura(abilitaFattura(curr["idmankind"]));
                ForzaTipoIvaDaTipoContratto(abilitaTipoIva(curr["idmankind"]));
            }
        }
        public void MetaData_AfterFill() {
            DataRow curr = DS.mandatedetail.Rows[0];
            SiopeObj.setCausaleEPCorrente(curr["idaccmotive"]);
            cmbCIG.Text = curr["cigcode"].ToString();
            CalcolaImponibileValuta();
            CalcolaImportiEUR(false);
            VisualizzaControlliContabilizzazione();
            VisualizzaControlliContabilizzazioneImpAccBudget();
            CalcolaResiduo(false);
			if (Meta.FirstFillForThisRow) calcolaPagato();
			HelpForm.SetDenyNull(DS.mandatedetail.Columns["idivakind"], true);
            SetLabel();
            DataRow Curr = DS.mandatedetail.Rows[0];

            if (Curr.RowState != DataRowState.Added) {
                if (Curr["idepexp", DataRowVersion.Original] != DBNull.Value) {
                    txtStart.ReadOnly = true;
                }
				
			}
			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			object datacontabile = Meta.GetSys("datacontabile");
			if ((CfgFn.GetNoNullInt32(Curr["yman"]) < esercizio) && (Curr.RowState == DataRowState.Added)) {
				txtStart.Text = HelpForm.StringValue(datacontabile,
				txtStart.Tag.ToString());
			}


			object idlist = Curr["idlist"];
            if (idlist != DBNull.Value) {
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.listview, null, QHS.CmpEq("idlist", idlist), null, true);
                if (DS.listview.Rows.Count != 0) {
                    riempiOggetti(DS.listview.Rows[0]);
                }
            }
            if (Meta.EditMode) {
                EnabledDisableListino();
            }
            EnabledDisableTipoBene();
            ImpostaFiltroAliqIva();
            ImpostaTageFiltriUPB(getActivitySelection(), Curr["idupb"]);

            // Se è un C.P.  documento equivalente di pagamento, allora vanno indicati tutti i campi per la PCC
            if (abilitaPCC(curr["idmankind"])) {
                btnCasuale.Enabled = true;
                cmbStatodelDebito.Enabled = true;
                if (Curr["idpccdebitmotive"] != DBNull.Value) {
                    txtCausale.Text = DS.pccdebitmotive.Select(QHC.CmpEq("idpccdebitmotive", Curr["idpccdebitmotive"]))[0]["description"].ToString();
                }
                EnableDisableNaturadispesa();
            }
            // Se è un C.P. collegabile a fattura, va indicara solo la natura di spesa, perchè sarà ereditata dai dettagli fattura con la funzione Aggiungi da Ordine
            else {
                rdbSpesaCorrente.Enabled = true;
                rdbContoCapitale.Enabled = true;
                txtCausale.Text = "";
                btnCasuale.Enabled = false;
                if (cmbStatodelDebito.SelectedIndex > 0) {
                    cmbStatodelDebito.SelectedIndex = -1;
                    show(this, "Lo stato del debito è stato azzerato poichè il contratto è collegabile a fattura.");
                }
                cmbStatodelDebito.Enabled = false;
            }
            if (Curr["idexp_iva"] != DBNull.Value) {
                gBoxupbIVA.Enabled = false;
                object idupb_iva = Conn.DO_READ_VALUE("expenseyear", QHS.CmpEq("idexp", Curr["idexp_iva"]),
                                "max(idupb)");
                if (Curr["idupb_iva"] == DBNull.Value && (Curr["idupb"].ToString() != idupb_iva.ToString())) {
                    if (Meta.IsFirstFillForThisRow) {
                        if (show(this,
                            "Aggiorno l'upb dell'iva in base a quello usato in fase di contabilizzazione?", "Avviso",
                            MessageBoxButtons.YesNo) == DialogResult.Yes) {
                            Curr["idupb_iva"] = idupb_iva;
                            Conn.RUN_SELECT_INTO_TABLE(DS.upb_iva, null, QHS.CmpEq("idupb", Curr["idupb_iva"]), null,
                                false);
                            Meta.myHelpForm.FillControls(gBoxupbIVA.Controls);
                        }
                    }
                }
            }
            if (Curr["idexp_taxable"] != DBNull.Value) {
                gboxUPB.Enabled = false;
                object idupb_taxable = Conn.DO_READ_VALUE("expenseyear", QHS.CmpEq("idexp", Curr["idexp_taxable"]),
                                "max(idupb)");
                if (Curr["idupb"] == DBNull.Value && (Curr["idupb"].ToString() != idupb_taxable.ToString())) {
                    if (Meta.IsFirstFillForThisRow) {
                        if (show(this,
                            "Aggiorno l'upb in base a quello usato in fase di contabilizzazione?", "Avviso",
                            MessageBoxButtons.YesNo) == DialogResult.Yes) {
                            Curr["idupb"] = idupb_taxable;
                            Conn.RUN_SELECT_INTO_TABLE(DS.upb, null, QHS.CmpEq("idupb", Curr["idupb"]), null,
                                false);
                            Meta.myHelpForm.FillControls(gboxUPB.Controls);
                        }
                    }
                }
            }
        }

        bool abilitaPCC(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0)
                return true;
            object touniqueregister = r[0]["touniqueregister"];
            if (touniqueregister.ToString() == "S")
                return true;

            return false;
        }

        private void EnableDisableNaturadispesa() {
            // Gestione Natura di Spesa
            object statodeldebito = DBNull.Value;
            if (cmbStatodelDebito.SelectedIndex > 0)
                statodeldebito = cmbStatodelDebito.SelectedValue;
            List<string> stati_con_natura = new List<string>(
                new string[] { "LIQ", "LIQdaSOSP", "LIQdaNL", "SOSPdaLIQ", "NLdaLIQ" });
            if (stati_con_natura.Contains(statodeldebito.ToString())) {
                rdbSpesaCorrente.Enabled = true;
                rdbContoCapitale.Enabled = true;
            }
            else {
                rdbSpesaCorrente.Enabled = false;
                rdbContoCapitale.Enabled = false;
            }
        }

	    private bool tipoBeneLockedCalcolato = false;
	    private bool tipoBeneLocked = false;

	    void calcolaTipoBeneLocked() {
	        if (tipoBeneLockedCalcolato) return;
            tipoBeneLocked = false;
            if (Meta.InsertMode) {
                tipoBeneLockedCalcolato = true;	            
                return;
	        }
	        DataRow r = DS.mandatedetail.Rows[0];
	        int N = Conn.RUN_SELECT_COUNT("assetacquire", QHS.AppAnd(
                QHS.CmpEq("idmankind",r["idmankind"]),
                QHS.CmpEq("yman",r["yman"]),
                QHS.CmpEq("nman",r["nman"]),
                QHS.CmpEq("rownum",r["idgroup"])
                ), false);
	        //if (N == 0) {
         //       Conn.RUN_SELECT_COUNT("invoicedetail", QHS.AppAnd(
         //           QHS.CmpEq("idmankind",r["idmankind"]),QHS.CmpEq("yman",r["yman"]),QHS.CmpEq("nman",r["nman"]),
         //           QHS.CmpEq("manrownum",r["rownum"])
         //           ), false);
         //   }
	        if (N > 0) {
                tipoBeneLocked = true;
	        }
            tipoBeneLockedCalcolato = true;
        }
        private void EnabledDisableTipoBene() {
            calcolaTipoBeneLocked();
            if (tipoBeneLocked) {
                radioInvent.Enabled = false;
                radioNonInvent.Enabled = false;
                radioServizi.Enabled = false;
                radioMagazzino.Enabled = false;
                rdbAltro.Enabled = false;
                return;
            }
            DataRow Curr = DS.mandatedetail.Rows[0];
            

            string filter = QHS.CmpEq("idmankind", Curr["idmankind"]);
            object AssetKind = Conn.DO_READ_VALUE("mandatekind", filter, "assetkind");
            int IAssetKind = CfgFn.GetNoNullInt32(AssetKind);
            radioInvent.Enabled = ((IAssetKind & 1) != 0);
            radioNonInvent.Enabled = ((IAssetKind & 2) != 0);
            radioServizi.Enabled = ((IAssetKind & 4) != 0);
            radioMagazzino.Enabled = ((IAssetKind & 8) != 0);
            rdbAltro.Enabled = ((IAssetKind & 16) != 0);
        }
        private void EnabledDisableListino(){
            if (GruppiDisabilitati) return;
            DataRow rMandatedetail = Meta.SourceRow;
            DataRow rMandate = rMandatedetail.GetParentRow("mandatemandatedetail");
            if (rMandate.RowState == DataRowState.Added) {
                gboxListino.Enabled = true;
                txtQuantitaConfezioni.ReadOnly = false;
            }
            else {
                if (rMandate["idstore", DataRowVersion.Original].Equals(rMandate["idstore", DataRowVersion.Current])) {
                    gboxListino.Enabled = true;
                    txtQuantitaConfezioni.ReadOnly = false;
                }
                else {
                    gboxListino.Enabled = false;
                    txtQuantitaConfezioni.ReadOnly = true;
                }
            }
        }

        private void SetLabel(){
            DataRow Curr = DS.mandatedetail.Rows[0];
            object idpackage = Curr["idpackage"];
            object idunit = Curr["idunit"];

            if (idpackage == null || idpackage == DBNull.Value || CfgFn.GetNoNullInt32(idpackage)==0){
                lblidpackage.Text = "Q.tà";
                //lblImportoUnitario.Text = "Importo unitario";
            }
            else{
                string UnitaAcquisto = Conn.DO_READ_VALUE("package", QHS.CmpEq("idpackage", idpackage), "description").ToString();
                lblidpackage.Text = UnitaAcquisto;//                "N." + UnitaAcquisto;
                //lblImportoUnitario.Text = "Importo (per " + UnitaAcquisto + ")";
            }

            if (idunit == null || idunit == DBNull.Value || CfgFn.GetNoNullInt32(idunit) == 0) {
                lblidunit.Text = "Totale quantità Ordinata";
            }
            else{
                string UnitaCarico = Conn.DO_READ_VALUE("unit", QHS.CmpEq("idunit", idunit), "description").ToString();
                lblidunit.Text = UnitaCarico; //                "N." + UnitaCarico;
            }
        }

     
        private void ImpostaNaturadiSpesa(DataRow R) {
            DataRow Curr = DS.mandatedetail.Rows[0];

            if (R["expensekind"] != DBNull.Value) {
                if ((Curr["expensekind"] != DBNull.Value) && (Curr["expensekind"].ToString()!=R["expensekind"].ToString())) {
                    if (show("Imposto la Natura di Spesa in base alla Causale?",
                                "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                        Curr["expensekind"] = R["expensekind"];
                        if (R["expensekind"].ToString() == "CO")
                            rdbSpesaCorrente.Checked = true;
                        if (R["expensekind"].ToString() == "CA")
                            rdbContoCapitale.Checked = true;
                    }
                }
                else {
                    Curr["expensekind"] = R["expensekind"];
                    if (R["expensekind"].ToString() == "CO")
                        rdbSpesaCorrente.Checked = true;
                    if (R["expensekind"].ToString() == "CA")
                        rdbContoCapitale.Checked = true;
                }

            }
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "accmotiveapplied") {
                if (!Meta.DrawStateIsDone)
                    return;
                if (Meta.IsEmpty)
                    return;
                if (R == null) {
                    return;
                }

                if (R.RowState == DataRowState.Detached) return;
                SiopeObj.setCausaleEPCorrente(R?["idaccmotive"]);
                SiopeObj.selectSiope();
                ImpostaNaturadiSpesa(R);
             }
            
            if (( T.TableName == "accmotiveappliedannulment") && Meta.DrawStateIsDone) {
                Meta.GetFormData(true);
                VisualizzaControlliContabilizzazioneImpAccBudget();
            }

            if (T.TableName == "ivakind") {
				if (R!=null) {
					aliquota=CfgFn.GetNoNullDouble(R["rate"]);
					percindeduc=CfgFn.GetNoNullDouble(R["unabatabilitypercentage"]);
				}
				else {
					aliquota=0;
					percindeduc=0;
				}
				if (Meta.DrawStateIsDone) {
					CalcolaImportiValuta(Meta.DrawStateIsDone);
					CalcolaImportiEUR(Meta.DrawStateIsDone);
				}
			}

            if (T.TableName == "upb") {
                if (!Meta.DrawStateIsDone) return;
                if (Meta.IsEmpty) return;
                if (R == null) return;
                if (R.RowState == DataRowState.Detached) return;
                if (R["cupcode"].ToString() != "") txtCupCode.Text = R["cupcode"].ToString();
				// L'UPB scelto non ha CUP, ma il campo CUP è valorizzato perchè magari associato all'UPB precedente.
				if ((R["cupcode"].ToString() == "") && (txtCupCode.Text != "")){
					if (show("L'UPB selezionato non ha un CUP associato. Cancello il CUP dal dettaglio?", "Conferma",
						MessageBoxButtons.OKCancel) == DialogResult.OK){
						txtCupCode.Text = "";
						DataRow Curr = DS.mandatedetail.Rows[0];
						Curr["cupcode"] = DBNull.Value;
					}
				}
				impostaAttivita(R);
                return;
            }

            if (T.TableName == "pccdebitstatus") {
                if (!Meta.DrawStateIsDone)
                    return;
                if (Meta.IsEmpty)
                    return;
                if (R == null) {
                    //rdbSpesaCorrente.Checked = false;
                    //rdbContoCapitale.Checked = false;
                    rdbSpesaCorrente.Enabled = false;
                    rdbContoCapitale.Enabled = false;
                    return;
                }


                DataRow Curr = DS.mandatedetail.Rows[0];
                //Gestione Casuale
                if (Curr["idpccdebitstatus"].ToString() != R["idpccdebitstatus"].ToString()) {
                    txtCausale.Text = "";
                    Curr["idpccdebitmotive"] = DBNull.Value;
                }
                // Gestione Natura di Spesa
                //DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", Curr["idmankind"]));
                //if (r.Length == 0)
                //    return;
                //string LinkToInvoice = r[0]["linktoinvoice"].ToString().ToUpper();

                //object statodeldebito = DBNull.Value;
                //if (cmbStatodelDebito.SelectedIndex > 0)
                //    statodeldebito = cmbStatodelDebito.SelectedValue;

                //List<string> stati_con_natura = new List<string>(
                //    new string[] { "LIQ", "LIQdaSOSP", "LIQdaNL", "SOSPdaLIQ", "NLdaLIQ" });
                //if (LinkToInvoice.ToString() != "S") {
                    EnableDisableNaturadispesa();
                    //if (stati_con_natura.Contains(statodeldebito.ToString())) {
                    //    rdbSpesaCorrente.Enabled = true;
                    //    rdbContoCapitale.Enabled = true;
                    //}
                    //else {
                    //    rdbSpesaCorrente.Enabled = false;
                    //    rdbContoCapitale.Enabled = false;
                    //}
                //}
                //else {
                //    rdbSpesaCorrente.Enabled = true;
                //    rdbContoCapitale.Enabled = true;
                //}


            }

			if (T.TableName == "mandatekind") {
				if (!Meta.DrawStateIsDone) return;
				if (Meta.IsEmpty) return;
				if (R==null) return;
				if (R["multireg"]==DBNull.Value)return;
				string multiReg = R["multireg"].ToString();
				if (multiReg == "S") {
					grpRegistry.Enabled = true;
				}
				else {
					grpRegistry.Enabled = false;
				}
				
				return;
			}

            if (T.TableName == "package"){
                if (!Meta.DrawStateIsDone) return;
                if (Meta.IsEmpty) return;
                if (R == null){
                    lblidpackage.Text = "Q.tà";
                    //lblImportoUnitario.Text = "Importo unitario";
                    return;
                }
                string UnitaAcquisto = R["description"].ToString();
                lblidpackage.Text = UnitaAcquisto; //                "N." + UnitaAcquisto;
                //lblImportoUnitario.Text = "Importo (per " + UnitaAcquisto + ")";
            }
            if (T.TableName == "unit")
            {
                if (!Meta.DrawStateIsDone) return;
                if (Meta.IsEmpty) return;
                if (R == null)
                {
                    lblidunit.Text = "Totale quantità Ordinata";
                    return;
                }
                string UnitaCarico = R["description"].ToString();
                lblidunit.Text = UnitaCarico; //                "N." + UnitaCarico;
            }
		}


        void impostaAttivita(DataRow Rupb){
            DataRow Curr = DS.mandatedetail.Rows[0];
            object upb_flagactivity = Rupb["flagactivity"];
            if ((Curr["flagactivity"].ToString() != upb_flagactivity.ToString()) 
                && (upb_flagactivity.ToString() == "1" || upb_flagactivity.ToString() == "2"))
            {
               if (show("Cambio il Tipo attività in base all'UPB selezionato?",
							"Conferma",MessageBoxButtons.OKCancel)==DialogResult.OK) {
                                Curr["flagactivity"]=upb_flagactivity;
                                if (upb_flagactivity.ToString() == "1") {
                                    rdbIstituzionale.Checked = true;
                                }

                                if (upb_flagactivity.ToString() == "2") {
                                    rdbCommerciale.Checked=true;
                                }
                            }
            }
        }

		void calcolaPagato() {
			if (Meta.InsertMode) return;
			if (!gboxPagato.Visible) return;
			decimal pagato = CfgFn.GetNoNullDecimal(Conn.readValue("mandatedetail_extview",
				q.keyCmp(DS.mandatedetail.Rows[0]), "cashed"));
			txtPagato.Text = pagato.ToString("c");
			}

		decimal NInvoiced;
		bool NInvoicedEvalued=false;
		void CalcolaResiduo(bool LeggiDati){
			if (Meta.InsertMode){
				txtResiduo.Text="";
				return;
			}
			if (LeggiDati) Meta.GetFormData(true);
			DataRow Curr = DS.mandatedetail.Rows[0];
            decimal Npackage = CfgFn.GetNoNullDecimal(Curr["npackage"]);
			if (!NInvoicedEvalued){
				string filter=QueryCreator.WHERE_KEY_CLAUSE(Curr,DataRowVersion.Default,true);
				NInvoiced= CfgFn.GetNoNullDecimal(
					Conn.DO_READ_VALUE("mandatedetailtoinvoice",filter,"invoiced"));
			}
			decimal INVOICED = NInvoiced;
            decimal residual = Npackage - INVOICED;

			if (NInvoiced>=0){
				txtNInvoiced.Text= NInvoiced.ToString("n");
			}
			else {
				txtNInvoiced.Text="";
			}

			if (residual>=0){
				txtResiduo.Text= residual.ToString("n");
			}
			else {
				txtResiduo.Text="";
			}
		}

		void VisualizzaControlliContabilizzazione(){
			DataRow Curr = DS.mandatedetail.Rows[0];
			if (Meta.InsertMode){
				gboxImponibile.Visible=false;
				gboxIVA.Visible=false;
				return;
			}
		}


		private void Calcola(){						
//			Meta.GetFormData(true);
//			DataRow Curr = DS.mandatedetail.Rows[0];
//
//			try{
//				double imponibile= CfgFn.GetNoNullDouble(Curr["taxable"]);
//				double quantita  = CfgFn.GetNoNullDouble(Curr["number"]);
//				double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
//			    double sconto    = CfgFn.GetNoNullDouble(Curr["discount"]);
//				double tax    = CfgFn.GetNoNullDouble(Curr["tax"]);//<-
//				double imponibileEUR =(imponibile*quantita*(1-sconto))*tassocambio;		
//				double imponibiletot = CfgFn.RoundValuta((imponibile*quantita*(1-sconto)));// <-
//				double iva        = CfgFn.RoundValuta(imponibiletot*aliquota);//<-
//				double ivaEUR        = imponibileEUR*aliquota;
//				imponibileEUR	 = CfgFn.RoundValuta(imponibileEUR);
//				ivaEUR = CfgFn.RoundValuta(ivaEUR);
//				txtImponibileEUR.Text = imponibileEUR.ToString("c");
//				txtIvaEUR.Text        = ivaEUR.ToString("c");
//				
//				TxtImponibileValutaTot.Text = imponibiletot.ToString("n");//<-
//				TxtIvaValutaTot.Text  =	iva.ToString("n");//<-
//			}
//			catch{
//				txtImponibileEUR.Text="";
//				txtIvaEUR.Text ="";
//				TxtIvaValutaTot.Text="";//<-
//			}			
		}


		private void CalcolaImportiEUR(bool LeggiDati)
		{						
			if (LeggiDati) Meta.GetFormData(true);
			DataRow Curr = DS.mandatedetail.Rows[0];

			try
			{
				double imponibile= CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["npackage"]);
				//double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
				double sconto    = CfgFn.GetNoNullDouble(Curr["discount"]);
				double imponibiletotEUR = CfgFn.RoundValuta((imponibile*quantita*(1-sconto))*tassocambio);
				//double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot);			
                //double iva        = CfgFn.GetNoNullDouble(Curr["tax"]);
                //double ivaEUR     = CfgFn.RoundValuta(iva*tassocambio);
                //double impindeduc=	CfgFn.GetNoNullDouble(Curr["unabatable"]);
                //double impindeducEUR=	CfgFn.RoundValuta(impindeduc*tassocambio);

                txtImponibileEUR.Text = HelpForm.StringValue(imponibiletotEUR,
                    "x.y.fixed.2...1");
                    //imponibiletotEUR.ToString("n");
                    //txtIvaEUR.Text = HelpForm.StringValue(ivaEUR,
                    //    "x.y.fixed.2...1"); //                .ToString("n");
                    //txtImpDeducEUR.Text = HelpForm.StringValue(impindeducEUR,
                    //    "x.y.fixed.2...1");//                .ToString("n");
			}
			catch
			{
				txtImponibileEUR.Text="";
                //txtIvaEUR.Text ="";	
                //txtImpDeducEUR.Text="";
			}			

		}

        private void CalcolaImportiValuta(bool LeggiDati)
		{						
			if (LeggiDati) Meta.GetFormData(true);
			DataRow Curr = DS.mandatedetail.Rows[0];

			try
			{
				double imponibile= CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["npackage"]);
				//double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
				double sconto    = CfgFn.GetNoNullDouble(Curr["discount"]);
				double imponibiletot = CfgFn.RoundValuta((imponibile*quantita*(1-sconto)));
				double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot*tassocambio);
                double ivaEUR = CfgFn.RoundValuta(imponibiletotEUR * aliquota);	
				//double iva        = CfgFn.RoundValuta(imponibiletot*aliquota);
				//double ivaEUR     = CfgFn.RoundValuta(iva*tassocambio);
				//double impindeduc=	CfgFn.RoundValuta(iva*percindeduc);
				//double impindeducEUR=	CfgFn.RoundValuta(impindeduc*tassocambio);
                double impindeducEUR = CfgFn.RoundValuta(ivaEUR * percindeduc);
                TxtImponibileValutaTot.Text = HelpForm.StringValue(imponibiletot,
                    "x.y.fixed.2...1");//             imponibiletot.ToString("n");
                txtIvaEUR.Text = HelpForm.StringValue(ivaEUR, "x.y.fixed.2...1");//   iva.ToString("n");
                txtImpDeducEUR.Text = HelpForm.StringValue(impindeducEUR, "x.y.fixed.2...1");//  impindeduc.ToString("n");
				Curr["taxrate"] = aliquota;
                txtTaxRate.Text = HelpForm.StringValue(aliquota, txtTaxRate.Tag.ToString());
                    //aliquota.ToString("p04");
			}
			catch
			{
				TxtImponibileValutaTot.Text="";
                txtIvaEUR.Text = "";
                txtImpDeducEUR.Text = "";
				txtTaxRate.Text="";
			}			
		}

		
		private void CalcolaImponibileValuta()
		{						
			DataRow Curr = DS.mandatedetail.Rows[0];

			try
			{
				double imponibile= CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["npackage"]);
				//double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
				double sconto    = CfgFn.GetNoNullDouble(Curr["discount"]);
				double imponibiletot = CfgFn.RoundValuta((imponibile*quantita*(1-sconto)));
                TxtImponibileValutaTot.Text = HelpForm.StringValue(imponibiletot,"x.y.fixed.2...1");//         imponibiletot.ToString("n");
			}
			catch
			{
				TxtImponibileValutaTot.Text="";
			}			
		}
		

		private void txtImponibile_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone)return;
//			Calcola();
			CalcolaImportiValuta(true);
			CalcolaImportiEUR(true);
			if (sender==txtQuantita)CalcolaResiduo(true);
		}

		private void btnRemoveImponibile_Click(object sender, System.EventArgs e) {
			if (show(this,"Rimuovendo la contabilizzazione del DETTAGLIO il movimento finanziario continuerà "+
				"comunque a contabilizzare il contratto passivo, tuttavia in forma 'generica'. Per rimuovere la contabilizzazione "+
				"del il contratto passivo è necessario eseguire la procedura guidata 'Rimuovi contabilizzazione'.\r"+
				"Procedo a rimuovere la contabilizzazione del dettaglio?","Avviso",MessageBoxButtons.YesNo)!=
				DialogResult.Yes) return;
			DataRow Curr = DS.mandatedetail.Rows[0];			
			Curr["idexp_taxable"]=DBNull.Value;
			DS.expense_imponibile.Clear();
			txtEsercizioImponibile.Text="";
			txtNumImponibile.Text="";
			if (Curr["idexp_iva",DataRowVersion.Original].ToString()==
				Curr["idexp_taxable",DataRowVersion.Original].ToString()){
				Curr["idexp_iva"]=DBNull.Value;
				DS.expense_iva.Clear();
				txtEsercizioIva.Text="";
				txtNumeroIva.Text="";				
			}
		}


        //private void radioInvent_CheckedChanged(object sender, System.EventArgs e) {
        //    if (radioInvent.Checked)  
        //    {   
        //        gboxCompetenza.Visible=false;
        //        txtCompetencyStart.Text = "";
        //        txtCompetencyStop.Text = "";
        //    }
        //}

        //private void radioNonInvent_CheckedChanged(object sender, System.EventArgs e) {
        //    if (radioNonInvent.Checked)
        //    {   gboxCompetenza.Visible=false;
        //        txtCompetencyStart.Text = "";
        //        txtCompetencyStop.Text = "";
        //    }
        //}

        //private void radioServizi_CheckedChanged(object sender, System.EventArgs e) {
        //    if (radioServizi.Checked)gboxCompetenza.Visible=true;
        //}
        //private void rdbAltro_CheckedChanged(object sender, EventArgs e) {
        //    if (rdbAltro.Checked) {
        //        gboxCompetenza.Visible = false;
        //        txtCompetencyStart.Text = "";
        //        txtCompetencyStop.Text = "";
        //    }
        //}
		private void TxtIvaValutaTot_TextChanged(object sender, System.EventArgs e)	{
			if (!Meta.DrawStateIsDone) return;
			//CalcolaImportiEUR(true);
            RicalcolaIvaIndeducibile(true);
        }
        
        void RicalcolaIvaIndeducibile(bool LeggiDati) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;

            if (LeggiDati) Meta.GetFormData(true);
            DataRow Curr = DS.mandatedetail.Rows[0];

            try {
                double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"]);
                //double ivaEUR     = CfgFn.RoundValuta(iva*tassocambio);
                //double impindeduc=	CfgFn.GetNoNullDouble(Curr["unabatable"]);
                //double impindeducEUR=	CfgFn.RoundValuta(impindeduc*tassocambio);

                double percindet = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtPercIndeduc.Text, "x.y.fixed.4..%.100"));

                double impindeducEUR=	CfgFn.RoundValuta(percindet*ivaEUR);
                txtImpDeducEUR.Text = impindeducEUR.ToString("c");
                Curr["unabatable"] = impindeducEUR;
            }
            catch {
                //txtImpDeducEUR.Text = "";
                //txtIvaEUR.Text ="";	
                //txtImpDeducEUR.Text="";
            }	

        }


		private void txtImpDeducValuta_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
				CalcolaImportiEUR(true);
		}

        private void radioButton5_CheckedChanged(object sender, EventArgs e) {

        }

        
        private void btnListino_Click(object sender, EventArgs e){
            if (Meta.IsEmpty) return;
            if (Meta.ErroreIrrecuperabile) return;
            Meta.GetFormData(true);
            DataRow Curr = DS.mandatedetail.Rows[0];
            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1)); //bit 1: visibile nei c. passivi. BitSet confronta con <> 0
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            if(chkListDescription.Checked){
                FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                if (FR.Selected != null){
                        object idlistclass = FR.Selected["idlistclass"];
                        filter = QHS.AppAnd(filter, QHS.CmpEq("idlistclass",FR.Selected["idlistclass"]));
                        }
                if (FR.txtDescrizione.Text != ""){
                        string Description = FR.txtDescrizione.Text;
                        if (!Description.EndsWith("%")) Description += "%";
                        if (!Description.StartsWith("%")) Description = "%" + Description;
                        filter = QHS.AppAnd(filter, QHS.Like("description", Description));
                        }
            }

            string filterManKind = QHS.CmpEq("idmankind", Curr["idmankind"]);
            object AssetKind = Conn.DO_READ_VALUE("mandatekind", filterManKind, "assetkind");
            int IAssetKind = CfgFn.GetNoNullInt32(AssetKind);
           
            string filterAssetKind = "";
            ArrayList Alist = new ArrayList();
         
            if ((IAssetKind & 1) != 0)  Alist.Add("A");
            if ((IAssetKind & 2) != 0)  Alist.Add("P");
            if ((IAssetKind & 4) != 0)  Alist.Add("S");
            if ((IAssetKind & 8) != 0)  Alist.Add("M");
            if ((IAssetKind & 16) != 0) Alist.Add("O");

            foreach (string value in Alist)
            {
                filterAssetKind = QHS.AppOr(filterAssetKind, QHS.CmpEq("assetkind", value));
            }
            filterAssetKind = QHS.AppOr(filterAssetKind, QHS.IsNull("assetkind"));
            filter = QHS.AppAnd(filter,QHS.DoPar(filterAssetKind));

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;

            AggiornaListino(Choosen);
            return;
        }

        private void riempiOggetti(DataRow listRow){
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";
            txtCoeffConversione.Text = (listRow != null) ? listRow["unitsforpackage"].ToString() : "";
            txtPrezzounitarioListino.Text = (listRow != null) ? listRow["price"].ToString() : "";
            HelpForm.SetComboBoxValue(cmbUnitaMisuraCS, listRow["idunit"]);
            HelpForm.SetComboBoxValue(cmbUnitaMisuraAcquisto, listRow["idpackage"]);
       }

        private void AdeguaQuantitaTotale(){
            if (txtCoeffConversione.Text == "")
            {
                // Se cancello il Coeff. di Conversione, la q.tà totale sarà uguale alla q.tà per l'imballo.
                double npackage = CfgFn.GetNoNullDouble(txtQuantitaConfezioni.Text);
                txtQuantita.Text = HelpForm.StringValue(npackage, "x.y");
                return;
            }
            else
            {
                double npackage = CfgFn.GetNoNullDouble(txtQuantitaConfezioni.Text);
                int unitsforpackage = CfgFn.GetNoNullInt32(txtCoeffConversione.Text);
                double number = npackage * unitsforpackage;
                txtQuantita.Text = HelpForm.StringValue(number, "x.y");
            }
        }
        private void svuotaOggetti(){
            txtDescrizioneListino.Text = "";
            txtCoeffConversione.Text = "";
            txtPrezzounitarioListino.Text = "";
            if (cmbUnitaMisuraCS.SelectedIndex >= 0){
                cmbUnitaMisuraCS.SelectedIndex = -1;
            }
            if (cmbUnitaMisuraAcquisto.SelectedIndex >= 0){
                cmbUnitaMisuraAcquisto.SelectedIndex = -1;
            }

            if ((!MetaData.Empty(this))){
                DS.mandatedetail.Rows[0]["idunit"] = DBNull.Value;
                DS.mandatedetail.Rows[0]["idpackage"] = DBNull.Value;
                DS.mandatedetail.Rows[0]["unitsforpackage"] = DBNull.Value;
                DS.mandatedetail.Rows[0]["idlist"] = DBNull.Value;
            }
        }

        void AggiornaListino(DataRow Choosen) {
            //Meta.GetFormData(true);
            DataRow Curr = DS.mandatedetail.Rows[0];
            if (txtDescrizione.Text != "") {
                if (CfgFn.GetNoNullInt32(Curr["idlist"]) != CfgFn.GetNoNullInt32(Choosen["idlist"])) {
                    if (show("Aggiorno il campo descrizione in base al listino selezionato?",
                        "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        txtDescrizione.Text = Choosen["description"].ToString();
                        Curr["detaildescription"] = Choosen["description"].ToString();
                    }

                }
            }
            else {
                Curr["detaildescription"] = Choosen["description"].ToString();
                txtDescrizione.Text = Choosen["description"].ToString();
            }
            string filterManKind = QHS.CmpEq("idmankind", Curr["idmankind"]);
            object linkToInvoice = Conn.DO_READ_VALUE("mandatekind", filterManKind, "linktoinvoice");
            if (linkToInvoice == null) linkToInvoice = DBNull.Value;
            object idlistclasssel = Choosen["idlistclass"];
            string filterListClass = QHS.CmpEq("idlistclass", idlistclasssel);
            DataTable ListClass = Conn.RUN_SELECT("listclass", "*", null, filterListClass, null, true);
            if ((ListClass != null) && (ListClass.Rows.Count > 0) &&
                    (ListClass.Rows[0]["idinv"] != DBNull.Value ||
                     ListClass.Rows[0]["assetkind"] != DBNull.Value ||
                     ListClass.Rows[0]["va3type"] != DBNull.Value)) {

                Curr["idinv"] = ListClass.Rows[0]["idinv"];
                Curr["assetkind"] = ListClass.Rows[0]["assetkind"];

                object flagva3 = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "flagva3");
                if ((flagva3 == DBNull.Value) || (flagva3 == null)) flagva3 = "N";

                if ((linkToInvoice.ToString() != "N") && (flagva3.ToString() != "N"))
                    Curr["va3type"] = ListClass.Rows[0]["va3type"];
                //txtCodClassif.Text = ListClass.Rows[0]["codeinv"].ToString();
                //txtDescClassif.Text = ListClass.Rows[0]["inventorytree"].ToString();
                Meta.FreshForm();

            }

            Curr["idlist"] = Choosen["idlist"];
            Curr["idunit"] = Choosen["idunit"];
            Curr["idpackage"] = Choosen["idpackage"];
            Curr["unitsforpackage"] = Choosen["unitsforpackage"];
		
			
			// Legge la causale EP associata alla classificazione merceologica del listino, e la scrive nella causale EP del dettaglio ordine.
			object idaccmotive = Conn.DO_READ_VALUE("listclass", QHS.CmpEq("idlistclass", Choosen["idlistclass"]), "idaccmotive");
            DS.accmotiveapplied.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied, null, QHS.AppAnd(filterEpOperation, QHS.CmpEq("idaccmotive", idaccmotive)), null, false);
            if (DS.accmotiveapplied.Rows.Count > 0) {
                DataRow AccMotive = DS.accmotiveapplied.Rows[0];
                txtCodiceCausale.Text = AccMotive["codemotive"].ToString();
                txtDescrizioneCausale.Text = AccMotive["motive"].ToString();
                Curr["idaccmotive"] = AccMotive["idaccmotive"].ToString();

                ImpostaNaturadiSpesa(AccMotive);
            }
            else {
                txtCodiceCausale.Text = "";
                txtDescrizioneCausale.Text = "";
                Curr["idaccmotive"] = DBNull.Value;
            }

            SiopeObj.setCausaleEPCorrente(Curr?["idaccmotive"]);
            SiopeObj.selectSiope();
			riempiOggetti(Choosen);
			AdeguaQuantitaTotale();

		}
		private string lastCodice;
        private void txtListino_Enter(object sender, EventArgs e) {
            lastCodice = txtListino.Text;
        }

        private void txtListino_Leave(object sender, EventArgs e){
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (txtListino.Text == "") {
                svuotaOggetti();
                AdeguaQuantitaTotale();
                return;
            }
            if (lastCodice == txtListino.Text) return;

            if (DS.mandatedetail.Rows.Count == 0) return;
            Meta.GetFormData(true);

            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1)); //bit 1: visibile nei c. passivi. BitSet confronta con <> 0
            string IntCode = txtListino.Text;
            if (!IntCode.EndsWith("%")) IntCode += "%";
            filter = QHC.AppAnd(filter, QHS.Like("intcode", IntCode));
            
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) {
                txtListino.Focus();
                lastCodice = null;
                return;
            }

            AggiornaListino(Choosen);

        }

        private void txtNumConfezioni_Leave(object sender, EventArgs e){
            if (txtQuantitaConfezioni.Text == ""){
                txtQuantita.Text = "";
                return;
            }

            double npackage = CfgFn.GetNoNullDouble(txtQuantitaConfezioni.Text);
            int unitsforpackage = CfgFn.GetNoNullInt32(txtCoeffConversione.Text);
            if (unitsforpackage == 0) 
                    unitsforpackage = 1;
                double number = npackage * unitsforpackage;
            txtQuantita.Text = HelpForm.StringValue(number,"x.y");
        }
        object getCurrIdUpb() {
            if (DS.mandatedetail.Rows.Count == 0) return DBNull.Value;
            return DS.mandatedetail.Rows[0]["idupb"];
        }


        private void rdbQualsiasi_CheckedChanged(object sender, EventArgs e) {
            RadioButton rdb = sender as RadioButton;
            if (!Meta.DrawStateIsDone) return;
            if (rdb == null) return;
            if (!rdb.Checked) return;
            ImpostaFiltroAliqIva();
            ImpostaTageFiltriUPB(getActivitySelection(), getCurrIdUpb());
        }

	    private void ImpostaFiltroAliqIva() {
            if (Meta == null)
                return;
            if (!Meta.DrawStateIsDone)
                return;
	        string filteraliquote = CalcolaFiltroAliqIva();

            //if (filteraliquote == "")
            //    btnTipo.Tag = "choose.ivakind.default";
            //else
            //    btnTipo.Tag = "choose.ivakind.default." + filteraliquote;

            GetData.SetStaticFilter(DS.ivakind, filteraliquote);
	        GetData.CacheTable(DS.ivakind);
            Meta.myHelpForm.FilteredPreFillCombo(cmbTipoIVA,filteraliquote,false);
	    }

        int getActivitySelection() {
            if (rdbQualsiasi.Checked)
                return 4; //nessun filtro
            if (rdbCommerciale.Checked)
                return 2;  //tipo attività commerciale 
            if (rdbIstituzionale.Checked)
                return 1;  //tipo attività istituzionale
            if (rdbPromiscua.Checked)
                return 3;  //tipo attività promiscua/altro
            return 4;
        }

	    private string CalcolaFiltroAliqIva() {
            string filteriva = "";
	        if (QHS == null) return basefilteriva;
            DataRow DRP =  Meta.SourceRow.GetParentRow("mandatemandatedetail");
            string flagintracom = DRP["flagintracom"].ToString();
            
	        if (rdbCommerciale.Checked)
                filteriva = QHS.AppAnd(basefilteriva, QHS.BitSet("flag", 1));  //tipo attività commerciale 
            if (rdbIstituzionale.Checked)
                filteriva = QHS.AppAnd(basefilteriva, QHS.BitSet("flag", 0));  //tipo attività istituzionale
            if (rdbPromiscua.Checked)
                filteriva = QHS.AppAnd(basefilteriva, QHS.BitSet("flag", 2));  //tipo attività promiscua/altro

            if (flagintracom=="N")
                filteriva = QHS.AppAnd(filteriva, QHS.BitSet("flag", 6));  //Italia
            if (flagintracom =="S")
                filteriva = QHS.AppAnd(filteriva, QHS.BitSet("flag", 7));  //Intra-UE
            if (flagintracom == "X")
                filteriva = QHS.AppAnd(filteriva, QHS.BitSet("flag", 8));  //Extra-UE

            return QHS.AppAnd(basefilteriva,filteriva);
	    }

        //private string GetFiltroUPB() {
        //    if (QHS == null)
        //        return CalcolaFiltroUPB(4); //qualsiasi/non specificata
           
        //    return CalcolaFiltroUPB(getActivitySelection()); //qualsiasi/non specificata;
        //}

        private string CalcolaFiltroUPB(int mandatedetail_flagactivity) {
            string filter_upb = "";
            if (mandatedetail_flagactivity == 1 || mandatedetail_flagactivity == 2) {
                //I valori di istituzionale e commerciale sono identici per le tabelle upb e mandatedetail
                filter_upb = QHS.AppAnd(filter_upb, QHS.CmpEq("flagactivity", mandatedetail_flagactivity));
                filter_upb = QHS.DoPar(QHS.AppOr(QHS.CmpEq("flagactivity", 4), filter_upb));
            }
            if (codiceresponsabile != DBNull.Value) {
                filter_upb = QHS.AppAnd(filter_upb, QHS.NullOrEq("idman", codiceresponsabile));
            }
            return filter_upb;
        }

	    private void ImpostaTageFiltriUPB(int mandatedetailFlagactivity, object idupbToinclude) {
	        string upbfilter = CalcolaFiltroUPB(mandatedetailFlagactivity);
	        string filteradd = upbfilter;
	        string filteractive = QHS.AppAnd(upbfilter, QHS.CmpEq("active", "S"));

            if (idupbToinclude != DBNull.Value && upbfilter!="") {
                filteradd = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupbToinclude), QHS.DoPar(upbfilter)));               
            }

            GetData.SetStaticFilter(DS.upb, filteradd);          

            if (upbfilter != "") {
                btnUPB.Tag = "choose.upb.default." + filteractive;
            }
            else {
                btnUPB.Tag = "manage.upb.tree";
            }
            if (gboxUPB.Tag != null)
                gboxUPB.Tag = "AutoChoose.txtUPB.default." + filteractive;
            Meta.SetAutoMode(gboxUPB);
	    }

        private void btnCasuale_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            DataRow Curr = DS.mandatedetail.Rows[0];
            object idpccdebitstatus = DBNull.Value;
            string filter = "";
            if (cmbStatodelDebito.SelectedIndex > 0)
                idpccdebitstatus = cmbStatodelDebito.SelectedValue;
            if (idpccdebitstatus != DBNull.Value) {
                int maskorder = CfgFn.GetNoNullInt32(DS.pccdebitstatus.Select(QHC.CmpEq("idpccdebitstatus", idpccdebitstatus))[0]["flag"]);
                filter = "( flagstatus & " + QueryCreator.unquotedstrvalue(maskorder, true) + " <>0 )";
            }
            MetaData MCausali = MetaData.GetMetaData(this, "pccdebitmotive");
            MCausali.FilterLocked = true;
            MCausali.DS = DS.Clone();

            DataRow Choosen = MCausali.SelectOne("default", filter, "pccdebitmotive", null);
            if (Choosen == null)
                return;

            Curr["idpccdebitmotive"] = Choosen["idpccdebitmotive"];
            txtCausale.Text = Choosen["description"].ToString();
        }

        private void txtListino_TextChanged(object sender, EventArgs e) {
            
        }

        private void btnSiope_Click(object sender, EventArgs e) {
        }

        private void btnSuggerimento_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            decimal imponibileUnitario= CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtImponibile.Text, txtImponibile.Tag.ToString()));
            decimal totiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtIvaEUR.Text, txtIvaEUR.Tag.ToString()));
            decimal totdetraibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtImpDeducEUR.Text, txtImpDeducEUR.Tag.ToString()));
            double sconto = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(
                typeof(double), txtSconto.Text, txtSconto.Tag.ToString()));
            int quantita = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(
                typeof(decimal), txtQuantita.Text, txtQuantita.Tag.ToString()));
            if (quantita == 0) return;

            frmHint F = new frmHint(imponibileUnitario,totiva, totdetraibile, quantita, tassocambio, sconto);
            F.Show();
        }

        private void btnCollegaPreimpegno_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)return;
            var Curr = DS.mandatedetail.First();
            if (Curr.rownum_originValue != DBNull.Value) {
                show("Non è possibile collegare un preimpegno ad un contratto passivo collegato ad una richiesta d'ordine",
                    "Errore");
                return;
            }
            MetaData.GetFormData(this, true);
            if (Curr["idepexp"] != DBNull.Value) {
                show("Non è possibile collegare un preimpegno avendo già generato l'impegno di budget",
                    "Errore");
                return;
            }

            string FilterExpBudget = GetFilterForEpExp(Curr);

            string VistaScelta = "epexpview";

            MetaData Mepexp = Meta.Dispatcher.Get(VistaScelta);
            Mepexp.FilterLocked = true;
            Mepexp.DS = DS;
            DataRow MyDR = Mepexp.SelectOne("default", FilterExpBudget, null, null);

            if (MyDR != null) {
                Curr["idepexp_pre"] = MyDR["idepexp"];
                Meta.FreshForm();
            }
        }

        private void btnScollegaPreimpegno_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)return;
            MetaData.GetFormData(this, true);

            DataRow Curr = DS.mandatedetail.Rows[0];
            if (Curr["idepexp"] != DBNull.Value) {
                show("Non è possibile scollegare un preimpegno avendo già generato l'impegno di budget",
                    "Errore");
                return;
            }

            Curr["idepexp_pre"] = DBNull.Value;
            DS.pre_epexp.Clear();
            txtEsercPreImpegno.Text = "";
            txtNumPreimpegno.Text = "";
            Meta.FreshForm();
        }

        private void txtStop_Leave(object sender, EventArgs e) {
            if (txtStop.ReadOnly)return;
            if (txtStop.Text.Trim()=="")return;
            object d = HelpForm.GetObjectFromString(typeof(DateTime), txtStop.Text, txtStop.Tag.ToString());
            if (d==null)return;
            if (((DateTime) d).Year != Conn.GetEsercizio()) {
                show("E' necessario che la data di fine validità sia dell'esercizio.", "Errore");
                txtStop.Text = "";
            }
            if (Meta.DrawStateIsDone &&!Meta.IsEmpty) {
                var curr = DS.mandatedetail[0];
                if (((DateTime) d).Year < curr.yman) {
                    show("E' necessario che la data di fine validità non preceda l'anno di creazione del contratto.", "Errore");
                    txtStop.Text = "";
                }
            }
        }

        private void txtStart_Leave(object sender, EventArgs e) {
            if (txtStart.ReadOnly)return;
            if (txtStart.Text.Trim()=="")return;
            object d = HelpForm.GetObjectFromString(typeof(DateTime), txtStart.Text, txtStart.Tag.ToString());
            if (d==null)return;
            if (((DateTime) d).Year != Conn.GetEsercizio()) {
                show("E' necessario che la data di inizio validità sia dell'esercizio.", "Errore");
                txtStart.Text = "";
            }

            if (Meta.DrawStateIsDone &&!Meta.IsEmpty) {
                var curr = DS.mandatedetail[0];
                if (((DateTime) d).Year < curr.yman) {
                    show("E' necessario che la data di inizio validità non preceda l'anno di creazione del contratto.", "Errore");
                    txtStart.Text = "";
                }
            }
        }
		
		private void btnCalcoloSconto_Click(object sender, EventArgs e) {
			double sconto = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double), txtSconto.Text, txtSconto.Tag.ToString()));
			double taxrate = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double), txtTaxRate.Text, txtTaxRate.Tag.ToString()));

			decimal ImponibileValutaTot = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), TxtImponibileValutaTot.Text, TxtImponibileValutaTot.Tag.ToString()));
			decimal imponibileUnitario = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtImponibile.Text, txtImponibile.Tag.ToString()));
			decimal totiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtIvaEUR.Text, txtIvaEUR.Tag.ToString()));
			decimal ImponibileEUR = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtImponibileEUR.Text, "x.y.fixed.2...1"));
			int quantita = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(decimal), txtQuantita.Text, txtQuantita.Tag.ToString()));


			FormCalculateDiscount F = new FormCalculateDiscount(ImponibileValutaTot, sconto, imponibileUnitario,
																	quantita, totiva, ImponibileEUR, taxrate);			
            DialogResult D = F.ShowDialog(this);
            if (D != DialogResult.OK) return;
			this.txtSconto.Text = HelpForm.StringValue(F.sconto, "x.y.fixed.4....%.100");		
		}
	}
}
