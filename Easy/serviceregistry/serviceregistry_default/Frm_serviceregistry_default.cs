/*
    Easy
    Copyright (C) 2019 Universit‡ degli Studi di Catania (www.unict.it)

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
using funzioni_configurazione;

namespace serviceregistry_default
{
	/// <summary>
	/// Summary description for Frm_serviceregistry_default.
	/// </summary>
	public class Frm_serviceregistry_default : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaData Meta;
        DataAccess Conn;
		string filteresercizio = "";
		private System.Windows.Forms.TabControl Principale;
		private System.Windows.Forms.TabPage tabPrincipale;
		public serviceregistry_default.vistaForm DS;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.GroupBox grbIncaricato;
		private System.Windows.Forms.RadioButton rdbdipendente;
		private System.Windows.Forms.RadioButton rdbconsulente01;
		private System.Windows.Forms.GroupBox grpContratto;
		private System.Windows.Forms.CheckBox chkischanged;
		private System.Windows.Forms.CheckBox chkisdelivery;
		private System.Windows.Forms.CheckBox chkis_annulled;
		private System.Windows.Forms.TextBox txteser;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumIncarico;
		private System.Windows.Forms.GroupBox grbincarico;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.CheckBox chkofficeduty;
		private System.Windows.Forms.TextBox txtvariaizoneincarico;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtDataautorizzazione;
		private System.Windows.Forms.TextBox txtstop;
		private System.Windows.Forms.TextBox txtstart;
		private System.Windows.Forms.TextBox txtdescription;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbattivitaeconomica;
		private System.Windows.Forms.Button btnattivitaeconomica;
		private System.Windows.Forms.ComboBox cmbtiporapporto;
		private System.Windows.Forms.Button btnTiporapporto;
		private System.Windows.Forms.Button btnmodacquisizione;
		private System.Windows.Forms.ComboBox cmbmodacquisizione;
		private System.Windows.Forms.ComboBox cmbtipologiaincarico;
		private System.Windows.Forms.Button btntipologiaincaricato;
		private System.Windows.Forms.TextBox txtsemestreriferimento;
		private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpincaricato;
		private System.Windows.Forms.ComboBox cmbQualifica;
		private System.Windows.Forms.Button btnqualifica;
		private System.Windows.Forms.TabPage tabConferente;
		private System.Windows.Forms.ComboBox cmbdepartment;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtDataNascita;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblPartitaIVA;
		private System.Windows.Forms.TextBox txtPartitaIva;
		private System.Windows.Forms.Label lblCodiceFiscale;
		private System.Windows.Forms.TextBox txtCodiceFiscale;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtforename;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtsurname;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox grbSesso;
		private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkestero;
		private System.Windows.Forms.TextBox txtidservice;
        private System.Windows.Forms.RadioButton rdbgenderf;
		private System.Windows.Forms.ComboBox cmbdipertimento;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtRelazioneAccompagnamento;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox grbconferente;
		private System.Windows.Forms.CheckBox chkblocked;
        private System.Windows.Forms.Label lblincaricoblocato;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtimportoprevisto;
        private System.Windows.Forms.TextBox txtpa_code;
        private GroupBox grpRiferimentoNormativo;
        private CheckBox chkNormativa;
        private Label label26;
        private Label label18;
        private Label label16;
        private Label label15;
        private ComboBox cmbRiferimentoNormativo;
        private Label label9;
        private TextBox txtDataNormativa;
        private TextBox txtArticoloNormativa;
        private TextBox txtNumeroNormativa;
        private TextBox txtCommaNormativa;
        private CheckBox chkregulation;
        private TextBox txtDataAffidamento;
        private Label label27;
        private Label label21;
        private TextBox txtGeoComune;
        private Label label7;
        private GroupBox grpAttivitaEconomica;
        private TextBox txtDescAttivitaEconomica;
        private TextBox txtIdAttivitaEconomica;
        private Button btnAPAttvitaEconomica;
        private TextBox txtIdMittente;
        private Label label29;
        private Label label28;
        private CheckBox checkPersonafisica;
        private TabPage tabPubblicazione;
        private TextBox txtStrutturaConferente;
        private Label lblComponentiVariabili;
        private Label lblAttivit‡Professionali;
        private Label lblAltriCarichi;
        private Label lblLinkBando;
        private Label lblRifAttoConferimento;
        private Label lblLinkAutorizzazione;
        private Label lblStrutturacheAutorizza;
        private Label lblLinkDecreto;
        private Label lblStrutturaConferente;
        private TextBox txtLinkDecreto;
        private TextBox txtStrutturacheAutorizza;
        private TextBox txtLinkAutorizzazione;
        private TextBox txtRifAttoConferimento;
        private TextBox txtLinkBando;
        private TextBox txtAltriIncarichi;
        private TextBox txtAttivit‡Professionali;
        private TextBox txtComponentiVariabili;
        private ComboBox cmbTipologia;
        private Button button2;
        private GroupBox grpPubblicazione;
        private Label lblStatoCV;
        private RadioButton rdbconsulente02;
        private TabPage tabPagamento;
        private GroupBox GBoxPagamento;
        private Button btnDeletePag;
        private Button btnEditPag;
        private Button btnInsertPag;
        private DataGrid gridPagamento;
        private Label label22;
        private GroupBox grpAnagraficaConferente;
        private GroupBox groupBox4;
        private TextBox txtGeoComuneConferente;
        private Label label30;
        private GroupBox grpSessoConferente;
        private RadioButton rdbGenderFCoferente;
        private RadioButton rdbGenderMCoferente;
        private TextBox txtDatanascitaConferente;
        private Label label31;
        private Label label32;
        private TextBox txtPivaConferente;
        private CheckBox chkEsteroConferente;
        private Label label33;
        private TextBox txtCFconferente;
        private TextBox txtDenominazioneConferente;
        private Label label34;
        private TextBox txtNomeConferente;
        private Label label35;
        private TextBox txtCognomeConferente;
        private Label label36;
        private ComboBox cmbtipologiaconferente;
        private Button btnTipologiaConferente;
        private Button btnTipologiaSocieta;
        private ComboBox cmbTipologiaSocieta;
        private TextBox txtDurataIncarico;
        private Label lblDurataIncarico;
        private Label label24;
        private TextBox txtNote;
        private TabPage tabAttributi;
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
        private TextBox txtattestazioneConflittiInteresse;
        private Label lblAttestazioneConflittiInteresse;
        private Label txtBozza;
        private CheckBox chkwebSite_annulled;
        private GroupBox groupBox2;
        private RadioButton rdbSaldoNoLiq;
        private RadioButton rdbSaldoNo;
        private RadioButton rdbSaldatoSi;
		private System.Windows.Forms.RadioButton rdbgenderm;
		
		public Frm_serviceregistry_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            DataAccess.SetTableForReading(DS.conferente, "registry");
            DataAccess.SetTableForReading(DS.geo_city_conferente, "geo_city");
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.DS = new serviceregistry_default.vistaForm();
            this.Principale = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.txtBozza = new System.Windows.Forms.Label();
            this.grpAnagraficaConferente = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtGeoComuneConferente = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.grpSessoConferente = new System.Windows.Forms.GroupBox();
            this.rdbGenderFCoferente = new System.Windows.Forms.RadioButton();
            this.rdbGenderMCoferente = new System.Windows.Forms.RadioButton();
            this.txtDatanascitaConferente = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtPivaConferente = new System.Windows.Forms.TextBox();
            this.chkEsteroConferente = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtCFconferente = new System.Windows.Forms.TextBox();
            this.txtDenominazioneConferente = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtNomeConferente = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtCognomeConferente = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cmbtipologiaconferente = new System.Windows.Forms.ComboBox();
            this.btnTipologiaConferente = new System.Windows.Forms.Button();
            this.cmbTipologia = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.grpContratto = new System.Windows.Forms.GroupBox();
            this.lblincaricoblocato = new System.Windows.Forms.Label();
            this.chkblocked = new System.Windows.Forms.CheckBox();
            this.chkischanged = new System.Windows.Forms.CheckBox();
            this.chkisdelivery = new System.Windows.Forms.CheckBox();
            this.chkis_annulled = new System.Windows.Forms.CheckBox();
            this.txteser = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumIncarico = new System.Windows.Forms.TextBox();
            this.grbincarico = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbSaldoNoLiq = new System.Windows.Forms.RadioButton();
            this.rdbSaldoNo = new System.Windows.Forms.RadioButton();
            this.rdbSaldatoSi = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.grpAttivitaEconomica = new System.Windows.Forms.GroupBox();
            this.txtDescAttivitaEconomica = new System.Windows.Forms.TextBox();
            this.txtIdAttivitaEconomica = new System.Windows.Forms.TextBox();
            this.btnAPAttvitaEconomica = new System.Windows.Forms.Button();
            this.txtDataAffidamento = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtimportoprevisto = new System.Windows.Forms.TextBox();
            this.txtidservice = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.chkofficeduty = new System.Windows.Forms.CheckBox();
            this.txtvariaizoneincarico = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDataautorizzazione = new System.Windows.Forms.TextBox();
            this.txtstop = new System.Windows.Forms.TextBox();
            this.txtstart = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbattivitaeconomica = new System.Windows.Forms.ComboBox();
            this.btnattivitaeconomica = new System.Windows.Forms.Button();
            this.cmbtiporapporto = new System.Windows.Forms.ComboBox();
            this.btnTiporapporto = new System.Windows.Forms.Button();
            this.btnmodacquisizione = new System.Windows.Forms.Button();
            this.cmbmodacquisizione = new System.Windows.Forms.ComboBox();
            this.cmbtipologiaincarico = new System.Windows.Forms.ComboBox();
            this.btntipologiaincaricato = new System.Windows.Forms.Button();
            this.txtsemestreriferimento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grpincaricato = new System.Windows.Forms.GroupBox();
            this.btnTipologiaSocieta = new System.Windows.Forms.Button();
            this.cmbTipologiaSocieta = new System.Windows.Forms.ComboBox();
            this.checkPersonafisica = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtGeoComune = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grbSesso = new System.Windows.Forms.GroupBox();
            this.rdbgenderf = new System.Windows.Forms.RadioButton();
            this.rdbgenderm = new System.Windows.Forms.RadioButton();
            this.txtDataNascita = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPartitaIVA = new System.Windows.Forms.Label();
            this.txtPartitaIva = new System.Windows.Forms.TextBox();
            this.chkestero = new System.Windows.Forms.CheckBox();
            this.lblCodiceFiscale = new System.Windows.Forms.Label();
            this.txtCodiceFiscale = new System.Windows.Forms.TextBox();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtforename = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsurname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbQualifica = new System.Windows.Forms.ComboBox();
            this.btnqualifica = new System.Windows.Forms.Button();
            this.grbIncaricato = new System.Windows.Forms.GroupBox();
            this.rdbconsulente02 = new System.Windows.Forms.RadioButton();
            this.rdbdipendente = new System.Windows.Forms.RadioButton();
            this.rdbconsulente01 = new System.Windows.Forms.RadioButton();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.tabPubblicazione = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.grpPubblicazione = new System.Windows.Forms.GroupBox();
            this.chkwebSite_annulled = new System.Windows.Forms.CheckBox();
            this.txtattestazioneConflittiInteresse = new System.Windows.Forms.TextBox();
            this.lblAttestazioneConflittiInteresse = new System.Windows.Forms.Label();
            this.txtDurataIncarico = new System.Windows.Forms.TextBox();
            this.lblDurataIncarico = new System.Windows.Forms.Label();
            this.lblStatoCV = new System.Windows.Forms.Label();
            this.txtComponentiVariabili = new System.Windows.Forms.TextBox();
            this.txtAttivit‡Professionali = new System.Windows.Forms.TextBox();
            this.txtAltriIncarichi = new System.Windows.Forms.TextBox();
            this.txtLinkBando = new System.Windows.Forms.TextBox();
            this.txtRifAttoConferimento = new System.Windows.Forms.TextBox();
            this.txtLinkAutorizzazione = new System.Windows.Forms.TextBox();
            this.txtStrutturacheAutorizza = new System.Windows.Forms.TextBox();
            this.txtLinkDecreto = new System.Windows.Forms.TextBox();
            this.txtStrutturaConferente = new System.Windows.Forms.TextBox();
            this.lblComponentiVariabili = new System.Windows.Forms.Label();
            this.lblAttivit‡Professionali = new System.Windows.Forms.Label();
            this.lblAltriCarichi = new System.Windows.Forms.Label();
            this.lblLinkBando = new System.Windows.Forms.Label();
            this.lblRifAttoConferimento = new System.Windows.Forms.Label();
            this.lblLinkAutorizzazione = new System.Windows.Forms.Label();
            this.lblStrutturacheAutorizza = new System.Windows.Forms.Label();
            this.lblLinkDecreto = new System.Windows.Forms.Label();
            this.lblStrutturaConferente = new System.Windows.Forms.Label();
            this.tabPagamento = new System.Windows.Forms.TabPage();
            this.GBoxPagamento = new System.Windows.Forms.GroupBox();
            this.btnDeletePag = new System.Windows.Forms.Button();
            this.btnEditPag = new System.Windows.Forms.Button();
            this.btnInsertPag = new System.Windows.Forms.Button();
            this.gridPagamento = new System.Windows.Forms.DataGrid();
            this.tabConferente = new System.Windows.Forms.TabPage();
            this.grbconferente = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtIdMittente = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.chkregulation = new System.Windows.Forms.CheckBox();
            this.grpRiferimentoNormativo = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbRiferimentoNormativo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataNormativa = new System.Windows.Forms.TextBox();
            this.txtArticoloNormativa = new System.Windows.Forms.TextBox();
            this.txtNumeroNormativa = new System.Windows.Forms.TextBox();
            this.txtCommaNormativa = new System.Windows.Forms.TextBox();
            this.chkNormativa = new System.Windows.Forms.CheckBox();
            this.cmbdipertimento = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtRelazioneAccompagnamento = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtpa_code = new System.Windows.Forms.TextBox();
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
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.cmbdepartment = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.Principale.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.grpAnagraficaConferente.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpSessoConferente.SuspendLayout();
            this.grpContratto.SuspendLayout();
            this.grbincarico.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpAttivitaEconomica.SuspendLayout();
            this.grpincaricato.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grbSesso.SuspendLayout();
            this.grbIncaricato.SuspendLayout();
            this.tabPubblicazione.SuspendLayout();
            this.grpPubblicazione.SuspendLayout();
            this.tabPagamento.SuspendLayout();
            this.GBoxPagamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamento)).BeginInit();
            this.tabConferente.SuspendLayout();
            this.grbconferente.SuspendLayout();
            this.grpRiferimentoNormativo.SuspendLayout();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Principale
            // 
            this.Principale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Principale.Controls.Add(this.tabPrincipale);
            this.Principale.Controls.Add(this.tabPubblicazione);
            this.Principale.Controls.Add(this.tabPagamento);
            this.Principale.Controls.Add(this.tabConferente);
            this.Principale.Controls.Add(this.tabAttributi);
            this.Principale.Location = new System.Drawing.Point(2, 1);
            this.Principale.Name = "Principale";
            this.Principale.SelectedIndex = 0;
            this.Principale.Size = new System.Drawing.Size(832, 687);
            this.Principale.TabIndex = 0;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.txtBozza);
            this.tabPrincipale.Controls.Add(this.grpAnagraficaConferente);
            this.tabPrincipale.Controls.Add(this.cmbtipologiaconferente);
            this.tabPrincipale.Controls.Add(this.btnTipologiaConferente);
            this.tabPrincipale.Controls.Add(this.cmbTipologia);
            this.tabPrincipale.Controls.Add(this.button2);
            this.tabPrincipale.Controls.Add(this.grpContratto);
            this.tabPrincipale.Controls.Add(this.label1);
            this.tabPrincipale.Controls.Add(this.txtNumIncarico);
            this.tabPrincipale.Controls.Add(this.grbincarico);
            this.tabPrincipale.Controls.Add(this.grpincaricato);
            this.tabPrincipale.Controls.Add(this.txtEsercizio);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(824, 661);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // txtBozza
            // 
            this.txtBozza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBozza.AutoSize = true;
            this.txtBozza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBozza.Location = new System.Drawing.Point(737, 9);
            this.txtBozza.Name = "txtBozza";
            this.txtBozza.Size = new System.Drawing.Size(48, 13);
            this.txtBozza.TabIndex = 190;
            this.txtBozza.Text = "BOZZA";
            // 
            // grpAnagraficaConferente
            // 
            this.grpAnagraficaConferente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnagraficaConferente.Controls.Add(this.groupBox4);
            this.grpAnagraficaConferente.Controls.Add(this.grpSessoConferente);
            this.grpAnagraficaConferente.Controls.Add(this.txtDatanascitaConferente);
            this.grpAnagraficaConferente.Controls.Add(this.label31);
            this.grpAnagraficaConferente.Controls.Add(this.label32);
            this.grpAnagraficaConferente.Controls.Add(this.txtPivaConferente);
            this.grpAnagraficaConferente.Controls.Add(this.chkEsteroConferente);
            this.grpAnagraficaConferente.Controls.Add(this.label33);
            this.grpAnagraficaConferente.Controls.Add(this.txtCFconferente);
            this.grpAnagraficaConferente.Controls.Add(this.txtDenominazioneConferente);
            this.grpAnagraficaConferente.Controls.Add(this.label34);
            this.grpAnagraficaConferente.Controls.Add(this.txtNomeConferente);
            this.grpAnagraficaConferente.Controls.Add(this.label35);
            this.grpAnagraficaConferente.Controls.Add(this.txtCognomeConferente);
            this.grpAnagraficaConferente.Controls.Add(this.label36);
            this.grpAnagraficaConferente.Location = new System.Drawing.Point(8, 534);
            this.grpAnagraficaConferente.Name = "grpAnagraficaConferente";
            this.grpAnagraficaConferente.Size = new System.Drawing.Size(792, 122);
            this.grpAnagraficaConferente.TabIndex = 189;
            this.grpAnagraficaConferente.TabStop = false;
            this.grpAnagraficaConferente.Tag = "AutoChoose.txtDenominazioneConferente.lista.(active=\'S\')";
            this.grpAnagraficaConferente.Text = "Conferente";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtGeoComuneConferente);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Location = new System.Drawing.Point(436, 75);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 46);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "AutoChoose.txtGeoComuneConferente.default";
            // 
            // txtGeoComuneConferente
            // 
            this.txtGeoComuneConferente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeoComuneConferente.Location = new System.Drawing.Point(5, 22);
            this.txtGeoComuneConferente.Name = "txtGeoComuneConferente";
            this.txtGeoComuneConferente.Size = new System.Drawing.Size(347, 20);
            this.txtGeoComuneConferente.TabIndex = 28;
            this.txtGeoComuneConferente.Tag = "geo_city_conferente.title?serviceregistryview.conferring_city";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(5, 8);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(76, 14);
            this.label30.TabIndex = 196;
            this.label30.Text = "Comune Sede";
            // 
            // grpSessoConferente
            // 
            this.grpSessoConferente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSessoConferente.Controls.Add(this.rdbGenderFCoferente);
            this.grpSessoConferente.Controls.Add(this.rdbGenderMCoferente);
            this.grpSessoConferente.Location = new System.Drawing.Point(671, 9);
            this.grpSessoConferente.Name = "grpSessoConferente";
            this.grpSessoConferente.Size = new System.Drawing.Size(111, 44);
            this.grpSessoConferente.TabIndex = 30;
            this.grpSessoConferente.TabStop = false;
            this.grpSessoConferente.Text = "Sesso";
            // 
            // rdbGenderFCoferente
            // 
            this.rdbGenderFCoferente.Location = new System.Drawing.Point(41, 19);
            this.rdbGenderFCoferente.Name = "rdbGenderFCoferente";
            this.rdbGenderFCoferente.Size = new System.Drawing.Size(32, 16);
            this.rdbGenderFCoferente.TabIndex = 2;
            this.rdbGenderFCoferente.Tag = "serviceregistry.conferring_gender:F";
            this.rdbGenderFCoferente.Text = "F";
            // 
            // rdbGenderMCoferente
            // 
            this.rdbGenderMCoferente.Location = new System.Drawing.Point(6, 18);
            this.rdbGenderMCoferente.Name = "rdbGenderMCoferente";
            this.rdbGenderMCoferente.Size = new System.Drawing.Size(28, 18);
            this.rdbGenderMCoferente.TabIndex = 1;
            this.rdbGenderMCoferente.Tag = "serviceregistry.conferring_gender:M";
            this.rdbGenderMCoferente.Text = "M";
            // 
            // txtDatanascitaConferente
            // 
            this.txtDatanascitaConferente.Location = new System.Drawing.Point(383, 55);
            this.txtDatanascitaConferente.Name = "txtDatanascitaConferente";
            this.txtDatanascitaConferente.Size = new System.Drawing.Size(120, 20);
            this.txtDatanascitaConferente.TabIndex = 26;
            this.txtDatanascitaConferente.Tag = "serviceregistry.conferring_birthdate";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(311, 59);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 18);
            this.label31.TabIndex = 195;
            this.label31.Text = "Data nascita";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(14, 84);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 19);
            this.label32.TabIndex = 193;
            this.label32.Text = "Partita IVA";
            this.label32.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPivaConferente
            // 
            this.txtPivaConferente.Location = new System.Drawing.Point(87, 81);
            this.txtPivaConferente.Name = "txtPivaConferente";
            this.txtPivaConferente.Size = new System.Drawing.Size(225, 20);
            this.txtPivaConferente.TabIndex = 27;
            this.txtPivaConferente.Tag = "serviceregistry.conferring_piva";
            // 
            // chkEsteroConferente
            // 
            this.chkEsteroConferente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEsteroConferente.Location = new System.Drawing.Point(320, 86);
            this.chkEsteroConferente.Name = "chkEsteroConferente";
            this.chkEsteroConferente.Size = new System.Drawing.Size(159, 19);
            this.chkEsteroConferente.TabIndex = 22;
            this.chkEsteroConferente.Tag = "serviceregistry.conferring_flagforeign:S:N";
            this.chkEsteroConferente.Text = "Sede legale estero";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(7, 60);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(80, 19);
            this.label33.TabIndex = 182;
            this.label33.Text = "Codice fiscale";
            this.label33.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCFconferente
            // 
            this.txtCFconferente.Location = new System.Drawing.Point(87, 57);
            this.txtCFconferente.Name = "txtCFconferente";
            this.txtCFconferente.Size = new System.Drawing.Size(224, 20);
            this.txtCFconferente.TabIndex = 25;
            this.txtCFconferente.Tag = "serviceregistry.pa_cf";
            // 
            // txtDenominazioneConferente
            // 
            this.txtDenominazioneConferente.Location = new System.Drawing.Point(88, 11);
            this.txtDenominazioneConferente.Name = "txtDenominazioneConferente";
            this.txtDenominazioneConferente.Size = new System.Drawing.Size(572, 20);
            this.txtDenominazioneConferente.TabIndex = 22;
            this.txtDenominazioneConferente.Tag = "conferente.title?serviceregistry.pa_title";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(3, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(85, 15);
            this.label34.TabIndex = 185;
            this.label34.Text = "Denominazione";
            this.label34.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNomeConferente
            // 
            this.txtNomeConferente.Location = new System.Drawing.Point(382, 33);
            this.txtNomeConferente.Name = "txtNomeConferente";
            this.txtNomeConferente.Size = new System.Drawing.Size(278, 20);
            this.txtNomeConferente.TabIndex = 24;
            this.txtNomeConferente.Tag = "serviceregistry.conferring_forename";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(345, 37);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(40, 16);
            this.label35.TabIndex = 184;
            this.label35.Text = "Nome";
            // 
            // txtCognomeConferente
            // 
            this.txtCognomeConferente.Location = new System.Drawing.Point(88, 34);
            this.txtCognomeConferente.Name = "txtCognomeConferente";
            this.txtCognomeConferente.Size = new System.Drawing.Size(248, 20);
            this.txtCognomeConferente.TabIndex = 23;
            this.txtCognomeConferente.Tag = "serviceregistry.conferring_surname";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(10, 37);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 16);
            this.label36.TabIndex = 183;
            this.label36.Text = "Cognome";
            this.label36.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbtipologiaconferente
            // 
            this.cmbtipologiaconferente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbtipologiaconferente.DataSource = this.DS.apregistrykind;
            this.cmbtipologiaconferente.DisplayMember = "description";
            this.cmbtipologiaconferente.Location = new System.Drawing.Point(142, 507);
            this.cmbtipologiaconferente.Name = "cmbtipologiaconferente";
            this.cmbtipologiaconferente.Size = new System.Drawing.Size(559, 21);
            this.cmbtipologiaconferente.TabIndex = 188;
            this.cmbtipologiaconferente.Tag = "serviceregistry.idapregistrykind";
            this.cmbtipologiaconferente.ValueMember = "idapregistrykind";
            // 
            // btnTipologiaConferente
            // 
            this.btnTipologiaConferente.Location = new System.Drawing.Point(8, 506);
            this.btnTipologiaConferente.Name = "btnTipologiaConferente";
            this.btnTipologiaConferente.Size = new System.Drawing.Size(128, 24);
            this.btnTipologiaConferente.TabIndex = 187;
            this.btnTipologiaConferente.TabStop = false;
            this.btnTipologiaConferente.Tag = "manage.apregistrykind.default";
            this.btnTipologiaConferente.Text = "Tipologia Conferente";
            // 
            // cmbTipologia
            // 
            this.cmbTipologia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipologia.DataSource = this.DS.serviceregistrykind;
            this.cmbTipologia.DisplayMember = "title";
            this.cmbTipologia.ItemHeight = 13;
            this.cmbTipologia.Location = new System.Drawing.Point(142, 6);
            this.cmbTipologia.Name = "cmbTipologia";
            this.cmbTipologia.Size = new System.Drawing.Size(589, 21);
            this.cmbTipologia.TabIndex = 23;
            this.cmbTipologia.Tag = "serviceregistry.idserviceregistrykind";
            this.cmbTipologia.ValueMember = "idserviceregistrykind";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 24);
            this.button2.TabIndex = 22;
            this.button2.TabStop = false;
            this.button2.Tag = "Choose.serviceregistrykind.default";
            this.button2.Text = "Tipologia Incarico";
            // 
            // grpContratto
            // 
            this.grpContratto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpContratto.Controls.Add(this.lblincaricoblocato);
            this.grpContratto.Controls.Add(this.chkblocked);
            this.grpContratto.Controls.Add(this.chkischanged);
            this.grpContratto.Controls.Add(this.chkisdelivery);
            this.grpContratto.Controls.Add(this.chkis_annulled);
            this.grpContratto.Controls.Add(this.txteser);
            this.grpContratto.Controls.Add(this.textBox1);
            this.grpContratto.Controls.Add(this.label3);
            this.grpContratto.Controls.Add(this.label2);
            this.grpContratto.Location = new System.Drawing.Point(8, 30);
            this.grpContratto.Name = "grpContratto";
            this.grpContratto.Size = new System.Drawing.Size(808, 42);
            this.grpContratto.TabIndex = 7;
            this.grpContratto.TabStop = false;
            this.grpContratto.Text = "Incarico";
            // 
            // lblincaricoblocato
            // 
            this.lblincaricoblocato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblincaricoblocato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblincaricoblocato.ForeColor = System.Drawing.Color.Black;
            this.lblincaricoblocato.Location = new System.Drawing.Point(536, 8);
            this.lblincaricoblocato.Name = "lblincaricoblocato";
            this.lblincaricoblocato.Size = new System.Drawing.Size(264, 32);
            this.lblincaricoblocato.TabIndex = 8;
            this.lblincaricoblocato.Text = "Il movimento Ë sospeso perchË in attesa di conferma da parte dell\'Amministrazione" +
    "";
            // 
            // chkblocked
            // 
            this.chkblocked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkblocked.Location = new System.Drawing.Point(520, 8);
            this.chkblocked.Name = "chkblocked";
            this.chkblocked.Size = new System.Drawing.Size(248, 32);
            this.chkblocked.TabIndex = 7;
            this.chkblocked.Tag = "serviceregistry.is_blocked:S:N";
            this.chkblocked.Text = "Il movimento Ë sospeso perchË in attesa di conferma da parte dell\'Amministrazione" +
    "";
            // 
            // chkischanged
            // 
            this.chkischanged.Location = new System.Drawing.Point(344, 16);
            this.chkischanged.Name = "chkischanged";
            this.chkischanged.Size = new System.Drawing.Size(96, 16);
            this.chkischanged.TabIndex = 5;
            this.chkischanged.TabStop = false;
            this.chkischanged.Tag = "serviceregistry.is_changed:S:N";
            this.chkischanged.Text = "Da modificare";
            this.chkischanged.CheckedChanged += new System.EventHandler(this.chkischanged_CheckedChanged);
            // 
            // chkisdelivery
            // 
            this.chkisdelivery.Location = new System.Drawing.Point(264, 16);
            this.chkisdelivery.Name = "chkisdelivery";
            this.chkisdelivery.Size = new System.Drawing.Size(80, 16);
            this.chkisdelivery.TabIndex = 3;
            this.chkisdelivery.TabStop = false;
            this.chkisdelivery.Tag = "serviceregistry.is_delivered:S:N";
            this.chkisdelivery.Text = "Trasmesso";
            // 
            // chkis_annulled
            // 
            this.chkis_annulled.Location = new System.Drawing.Point(440, 16);
            this.chkis_annulled.Name = "chkis_annulled";
            this.chkis_annulled.Size = new System.Drawing.Size(72, 16);
            this.chkis_annulled.TabIndex = 6;
            this.chkis_annulled.TabStop = false;
            this.chkis_annulled.Tag = "serviceregistry.is_annulled:S:N";
            this.chkis_annulled.Text = "Annullato";
            this.chkis_annulled.CheckedChanged += new System.EventHandler(this.chkis_annulled_CheckedChanged);
            // 
            // txteser
            // 
            this.txteser.Location = new System.Drawing.Point(64, 16);
            this.txteser.Name = "txteser";
            this.txteser.Size = new System.Drawing.Size(64, 20);
            this.txteser.TabIndex = 1;
            this.txteser.Tag = "serviceregistry.yservreg.year";
            this.txteser.Leave += new System.EventHandler(this.txteser_Leave);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(184, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "serviceregistry.nservreg";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Esercizio";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Numero";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 8;
            // 
            // txtNumIncarico
            // 
            this.txtNumIncarico.Location = new System.Drawing.Point(0, 0);
            this.txtNumIncarico.Name = "txtNumIncarico";
            this.txtNumIncarico.Size = new System.Drawing.Size(100, 20);
            this.txtNumIncarico.TabIndex = 9;
            // 
            // grbincarico
            // 
            this.grbincarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbincarico.Controls.Add(this.groupBox2);
            this.grbincarico.Controls.Add(this.label28);
            this.grbincarico.Controls.Add(this.grpAttivitaEconomica);
            this.grbincarico.Controls.Add(this.txtDataAffidamento);
            this.grbincarico.Controls.Add(this.label27);
            this.grbincarico.Controls.Add(this.label17);
            this.grbincarico.Controls.Add(this.txtimportoprevisto);
            this.grbincarico.Controls.Add(this.txtidservice);
            this.grbincarico.Controls.Add(this.label20);
            this.grbincarico.Controls.Add(this.chkofficeduty);
            this.grbincarico.Controls.Add(this.txtvariaizoneincarico);
            this.grbincarico.Controls.Add(this.label19);
            this.grbincarico.Controls.Add(this.label14);
            this.grbincarico.Controls.Add(this.label13);
            this.grbincarico.Controls.Add(this.label12);
            this.grbincarico.Controls.Add(this.txtDataautorizzazione);
            this.grbincarico.Controls.Add(this.txtstop);
            this.grbincarico.Controls.Add(this.txtstart);
            this.grbincarico.Controls.Add(this.txtdescription);
            this.grbincarico.Controls.Add(this.label11);
            this.grbincarico.Controls.Add(this.cmbattivitaeconomica);
            this.grbincarico.Controls.Add(this.btnattivitaeconomica);
            this.grbincarico.Controls.Add(this.cmbtiporapporto);
            this.grbincarico.Controls.Add(this.btnTiporapporto);
            this.grbincarico.Controls.Add(this.btnmodacquisizione);
            this.grbincarico.Controls.Add(this.cmbmodacquisizione);
            this.grbincarico.Controls.Add(this.cmbtipologiaincarico);
            this.grbincarico.Controls.Add(this.btntipologiaincaricato);
            this.grbincarico.Controls.Add(this.txtsemestreriferimento);
            this.grbincarico.Controls.Add(this.label10);
            this.grbincarico.Location = new System.Drawing.Point(8, 286);
            this.grbincarico.Name = "grbincarico";
            this.grbincarico.Size = new System.Drawing.Size(808, 216);
            this.grbincarico.TabIndex = 15;
            this.grbincarico.TabStop = false;
            this.grbincarico.Text = "Incarico";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdbSaldoNoLiq);
            this.groupBox2.Controls.Add(this.rdbSaldoNo);
            this.groupBox2.Controls.Add(this.rdbSaldatoSi);
            this.groupBox2.Location = new System.Drawing.Point(650, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 74);
            this.groupBox2.TabIndex = 118;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Incarico Saldato";
            // 
            // rdbSaldoNoLiq
            // 
            this.rdbSaldoNoLiq.AutoSize = true;
            this.rdbSaldoNoLiq.Location = new System.Drawing.Point(6, 54);
            this.rdbSaldoNoLiq.Name = "rdbSaldoNoLiq";
            this.rdbSaldoNoLiq.Size = new System.Drawing.Size(98, 17);
            this.rdbSaldoNoLiq.TabIndex = 2;
            this.rdbSaldoNoLiq.TabStop = true;
            this.rdbSaldoNoLiq.Tag = "serviceregistry.payment:Q";
            this.rdbSaldoNoLiq.Text = "Non Liquidabile";
            this.rdbSaldoNoLiq.UseVisualStyleBackColor = true;
            // 
            // rdbSaldoNo
            // 
            this.rdbSaldoNo.AutoSize = true;
            this.rdbSaldoNo.Location = new System.Drawing.Point(6, 35);
            this.rdbSaldoNo.Name = "rdbSaldoNo";
            this.rdbSaldoNo.Size = new System.Drawing.Size(39, 17);
            this.rdbSaldoNo.TabIndex = 1;
            this.rdbSaldoNo.TabStop = true;
            this.rdbSaldoNo.Tag = "serviceregistry.payment:N";
            this.rdbSaldoNo.Text = "No";
            this.rdbSaldoNo.UseVisualStyleBackColor = true;
            // 
            // rdbSaldatoSi
            // 
            this.rdbSaldatoSi.AutoSize = true;
            this.rdbSaldatoSi.Location = new System.Drawing.Point(6, 18);
            this.rdbSaldatoSi.Name = "rdbSaldatoSi";
            this.rdbSaldatoSi.Size = new System.Drawing.Size(34, 17);
            this.rdbSaldatoSi.TabIndex = 0;
            this.rdbSaldatoSi.TabStop = true;
            this.rdbSaldatoSi.Tag = "serviceregistry.payment:S";
            this.rdbSaldatoSi.Text = "Si";
            this.rdbSaldatoSi.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label28.Location = new System.Drawing.Point(137, 171);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(275, 16);
            this.label28.TabIndex = 117;
            this.label28.Text = "Fino al 2 marzo 2011 (data affidamento)";
            // 
            // grpAttivitaEconomica
            // 
            this.grpAttivitaEconomica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAttivitaEconomica.Controls.Add(this.txtDescAttivitaEconomica);
            this.grpAttivitaEconomica.Controls.Add(this.txtIdAttivitaEconomica);
            this.grpAttivitaEconomica.Controls.Add(this.btnAPAttvitaEconomica);
            this.grpAttivitaEconomica.Location = new System.Drawing.Point(490, 140);
            this.grpAttivitaEconomica.Name = "grpAttivitaEconomica";
            this.grpAttivitaEconomica.Size = new System.Drawing.Size(318, 71);
            this.grpAttivitaEconomica.TabIndex = 116;
            this.grpAttivitaEconomica.TabStop = false;
            this.grpAttivitaEconomica.Tag = "AutoManage.txtIdAttivitaEconomica.tree";
            this.grpAttivitaEconomica.Text = "Attivit‡ economica dal 3 marzo 2011 (data affidamento)";
            // 
            // txtDescAttivitaEconomica
            // 
            this.txtDescAttivitaEconomica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescAttivitaEconomica.Location = new System.Drawing.Point(128, 16);
            this.txtDescAttivitaEconomica.Multiline = true;
            this.txtDescAttivitaEconomica.Name = "txtDescAttivitaEconomica";
            this.txtDescAttivitaEconomica.ReadOnly = true;
            this.txtDescAttivitaEconomica.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescAttivitaEconomica.Size = new System.Drawing.Size(182, 49);
            this.txtDescAttivitaEconomica.TabIndex = 3;
            this.txtDescAttivitaEconomica.TabStop = false;
            this.txtDescAttivitaEconomica.Tag = "apfinancialactivityview.description";
            // 
            // txtIdAttivitaEconomica
            // 
            this.txtIdAttivitaEconomica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIdAttivitaEconomica.Location = new System.Drawing.Point(6, 45);
            this.txtIdAttivitaEconomica.Name = "txtIdAttivitaEconomica";
            this.txtIdAttivitaEconomica.Size = new System.Drawing.Size(112, 20);
            this.txtIdAttivitaEconomica.TabIndex = 41;
            this.txtIdAttivitaEconomica.Tag = "apfinancialactivityview.apfinancialactivitycode?serviceregistryview.apfinancialac" +
    "tivitycode";
            // 
            // btnAPAttvitaEconomica
            // 
            this.btnAPAttvitaEconomica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAPAttvitaEconomica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAPAttvitaEconomica.Location = new System.Drawing.Point(6, 14);
            this.btnAPAttvitaEconomica.Name = "btnAPAttvitaEconomica";
            this.btnAPAttvitaEconomica.Size = new System.Drawing.Size(112, 23);
            this.btnAPAttvitaEconomica.TabIndex = 1;
            this.btnAPAttvitaEconomica.TabStop = false;
            this.btnAPAttvitaEconomica.Tag = "manage.apfinancialactivityview.tree";
            this.btnAPAttvitaEconomica.Text = "Attivita Economica";
            // 
            // txtDataAffidamento
            // 
            this.txtDataAffidamento.Location = new System.Drawing.Point(114, 67);
            this.txtDataAffidamento.Name = "txtDataAffidamento";
            this.txtDataAffidamento.Size = new System.Drawing.Size(70, 20);
            this.txtDataAffidamento.TabIndex = 31;
            this.txtDataAffidamento.Tag = "serviceregistry.expectationsdate";
            this.txtDataAffidamento.Leave += new System.EventHandler(this.txtDataAffidamento_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(20, 70);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(88, 13);
            this.label27.TabIndex = 45;
            this.label27.Text = "Data affidamento";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(60, 93);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 16);
            this.label17.TabIndex = 42;
            this.label17.Text = "Importo";
            // 
            // txtimportoprevisto
            // 
            this.txtimportoprevisto.Location = new System.Drawing.Point(114, 91);
            this.txtimportoprevisto.Name = "txtimportoprevisto";
            this.txtimportoprevisto.Size = new System.Drawing.Size(70, 20);
            this.txtimportoprevisto.TabIndex = 29;
            this.txtimportoprevisto.Tag = "serviceregistry.expectedamount";
            // 
            // txtidservice
            // 
            this.txtidservice.Location = new System.Drawing.Point(114, 15);
            this.txtidservice.Name = "txtidservice";
            this.txtidservice.Size = new System.Drawing.Size(216, 20);
            this.txtidservice.TabIndex = 34;
            this.txtidservice.Tag = "serviceregistry.id_service";
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(24, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 16);
            this.label20.TabIndex = 31;
            this.label20.Text = "Codice incarico";
            // 
            // chkofficeduty
            // 
            this.chkofficeduty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkofficeduty.Location = new System.Drawing.Point(688, 90);
            this.chkofficeduty.Name = "chkofficeduty";
            this.chkofficeduty.Size = new System.Drawing.Size(113, 18);
            this.chkofficeduty.TabIndex = 40;
            this.chkofficeduty.Tag = "serviceregistry.officeduty:S:N";
            this.chkofficeduty.Text = "Doveri ufficio";
            // 
            // txtvariaizoneincarico
            // 
            this.txtvariaizoneincarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtvariaizoneincarico.Location = new System.Drawing.Point(439, 64);
            this.txtvariaizoneincarico.Multiline = true;
            this.txtvariaizoneincarico.Name = "txtvariaizoneincarico";
            this.txtvariaizoneincarico.ReadOnly = true;
            this.txtvariaizoneincarico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtvariaizoneincarico.Size = new System.Drawing.Size(205, 33);
            this.txtvariaizoneincarico.TabIndex = 36;
            this.txtvariaizoneincarico.Tag = "serviceregistry.servicevariation";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(336, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 21);
            this.label19.TabIndex = 24;
            this.label19.Text = "Variazioni incarico";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(11, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 36);
            this.label14.TabIndex = 23;
            this.label14.Tag = "";
            this.label14.Text = "Data conferimento / autorizzazione";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(201, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Data fine";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(197, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "Data inizio";
            // 
            // txtDataautorizzazione
            // 
            this.txtDataautorizzazione.Location = new System.Drawing.Point(114, 42);
            this.txtDataautorizzazione.Name = "txtDataautorizzazione";
            this.txtDataautorizzazione.Size = new System.Drawing.Size(70, 20);
            this.txtDataautorizzazione.TabIndex = 30;
            this.txtDataautorizzazione.Tag = "serviceregistry.authorizationdate";
            this.txtDataautorizzazione.Leave += new System.EventHandler(this.txtDataautorizzazione_Leave);
            // 
            // txtstop
            // 
            this.txtstop.Location = new System.Drawing.Point(261, 67);
            this.txtstop.Name = "txtstop";
            this.txtstop.Size = new System.Drawing.Size(70, 20);
            this.txtstop.TabIndex = 33;
            this.txtstop.Tag = "serviceregistry.stop";
            this.txtstop.Leave += new System.EventHandler(this.txtstop_TextChanged);
            // 
            // txtstart
            // 
            this.txtstart.Location = new System.Drawing.Point(261, 42);
            this.txtstart.Name = "txtstart";
            this.txtstart.Size = new System.Drawing.Size(70, 20);
            this.txtstart.TabIndex = 32;
            this.txtstart.Tag = "serviceregistry.start";
            this.txtstart.Leave += new System.EventHandler(this.txtstart_TextChanged);
            // 
            // txtdescription
            // 
            this.txtdescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdescription.Location = new System.Drawing.Point(406, 15);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdescription.Size = new System.Drawing.Size(238, 40);
            this.txtdescription.TabIndex = 35;
            this.txtdescription.Tag = "serviceregistry.description";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(336, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 16;
            this.label11.Text = "Descrizione";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbattivitaeconomica
            // 
            this.cmbattivitaeconomica.DataSource = this.DS.financialactivity;
            this.cmbattivitaeconomica.DisplayMember = "description";
            this.cmbattivitaeconomica.Location = new System.Drawing.Point(139, 188);
            this.cmbattivitaeconomica.Name = "cmbattivitaeconomica";
            this.cmbattivitaeconomica.Size = new System.Drawing.Size(311, 21);
            this.cmbattivitaeconomica.TabIndex = 40;
            this.cmbattivitaeconomica.Tag = "serviceregistry.idfinancialactivity";
            this.cmbattivitaeconomica.ValueMember = "idfinancialactivity";
            // 
            // btnattivitaeconomica
            // 
            this.btnattivitaeconomica.Location = new System.Drawing.Point(8, 187);
            this.btnattivitaeconomica.Name = "btnattivitaeconomica";
            this.btnattivitaeconomica.Size = new System.Drawing.Size(128, 24);
            this.btnattivitaeconomica.TabIndex = 14;
            this.btnattivitaeconomica.TabStop = false;
            this.btnattivitaeconomica.Tag = "manage.financialactivity.default";
            this.btnattivitaeconomica.Text = "Attivit‡ economica ";
            this.btnattivitaeconomica.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbtiporapporto
            // 
            this.cmbtiporapporto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbtiporapporto.DataSource = this.DS.apcontractkind;
            this.cmbtiporapporto.DisplayMember = "description";
            this.cmbtiporapporto.Location = new System.Drawing.Point(548, 114);
            this.cmbtiporapporto.Name = "cmbtiporapporto";
            this.cmbtiporapporto.Size = new System.Drawing.Size(254, 21);
            this.cmbtiporapporto.TabIndex = 38;
            this.cmbtiporapporto.Tag = "serviceregistry.idapcontractkind";
            this.cmbtiporapporto.ValueMember = "idapcontractkind";
            // 
            // btnTiporapporto
            // 
            this.btnTiporapporto.Location = new System.Drawing.Point(455, 114);
            this.btnTiporapporto.Name = "btnTiporapporto";
            this.btnTiporapporto.Size = new System.Drawing.Size(88, 24);
            this.btnTiporapporto.TabIndex = 12;
            this.btnTiporapporto.TabStop = false;
            this.btnTiporapporto.Tag = "manage.apcontractkind.default";
            this.btnTiporapporto.Text = "Tipo Rapporto";
            // 
            // btnmodacquisizione
            // 
            this.btnmodacquisizione.Location = new System.Drawing.Point(8, 146);
            this.btnmodacquisizione.Name = "btnmodacquisizione";
            this.btnmodacquisizione.Size = new System.Drawing.Size(128, 24);
            this.btnmodacquisizione.TabIndex = 11;
            this.btnmodacquisizione.TabStop = false;
            this.btnmodacquisizione.Tag = "manage.acquirekind.default";
            this.btnmodacquisizione.Text = "Modalit‡ acquisizione";
            // 
            // cmbmodacquisizione
            // 
            this.cmbmodacquisizione.DataSource = this.DS.acquirekind;
            this.cmbmodacquisizione.DisplayMember = "description";
            this.cmbmodacquisizione.Location = new System.Drawing.Point(140, 146);
            this.cmbmodacquisizione.Name = "cmbmodacquisizione";
            this.cmbmodacquisizione.Size = new System.Drawing.Size(217, 21);
            this.cmbmodacquisizione.TabIndex = 39;
            this.cmbmodacquisizione.Tag = "serviceregistry.idacquirekind";
            this.cmbmodacquisizione.ValueMember = "idacquirekind";
            // 
            // cmbtipologiaincarico
            // 
            this.cmbtipologiaincarico.DataSource = this.DS.apactivitykind;
            this.cmbtipologiaincarico.DisplayMember = "description";
            this.cmbtipologiaincarico.Location = new System.Drawing.Point(140, 119);
            this.cmbtipologiaincarico.Name = "cmbtipologiaincarico";
            this.cmbtipologiaincarico.Size = new System.Drawing.Size(308, 21);
            this.cmbtipologiaincarico.TabIndex = 37;
            this.cmbtipologiaincarico.Tag = "serviceregistry.idapactivitykind";
            this.cmbtipologiaincarico.ValueMember = "idapactivitykind";
            // 
            // btntipologiaincaricato
            // 
            this.btntipologiaincaricato.Location = new System.Drawing.Point(8, 118);
            this.btntipologiaincaricato.Name = "btntipologiaincaricato";
            this.btntipologiaincaricato.Size = new System.Drawing.Size(128, 24);
            this.btntipologiaincaricato.TabIndex = 7;
            this.btntipologiaincaricato.TabStop = false;
            this.btntipologiaincaricato.Tag = "manage.apactivitykind.default";
            this.btntipologiaincaricato.Text = "Oggetto dell\'incarico";
            // 
            // txtsemestreriferimento
            // 
            this.txtsemestreriferimento.Location = new System.Drawing.Point(313, 90);
            this.txtsemestreriferimento.Name = "txtsemestreriferimento";
            this.txtsemestreriferimento.Size = new System.Drawing.Size(32, 20);
            this.txtsemestreriferimento.TabIndex = 34;
            this.txtsemestreriferimento.Tag = "serviceregistry.referencesemester";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(194, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 24);
            this.label10.TabIndex = 1;
            this.label10.Text = "Semestre di riferimento";
            // 
            // grpincaricato
            // 
            this.grpincaricato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpincaricato.Controls.Add(this.btnTipologiaSocieta);
            this.grpincaricato.Controls.Add(this.cmbTipologiaSocieta);
            this.grpincaricato.Controls.Add(this.checkPersonafisica);
            this.grpincaricato.Controls.Add(this.groupBox1);
            this.grpincaricato.Controls.Add(this.cmbQualifica);
            this.grpincaricato.Controls.Add(this.btnqualifica);
            this.grpincaricato.Controls.Add(this.grbIncaricato);
            this.grpincaricato.Location = new System.Drawing.Point(8, 74);
            this.grpincaricato.Name = "grpincaricato";
            this.grpincaricato.Size = new System.Drawing.Size(808, 209);
            this.grpincaricato.TabIndex = 13;
            this.grpincaricato.TabStop = false;
            this.grpincaricato.Text = "Incaricato";
            // 
            // btnTipologiaSocieta
            // 
            this.btnTipologiaSocieta.Location = new System.Drawing.Point(378, 13);
            this.btnTipologiaSocieta.Name = "btnTipologiaSocieta";
            this.btnTipologiaSocieta.Size = new System.Drawing.Size(119, 23);
            this.btnTipologiaSocieta.TabIndex = 190;
            this.btnTipologiaSocieta.TabStop = false;
            this.btnTipologiaSocieta.Tag = "manage.consultingkind.default";
            this.btnTipologiaSocieta.Text = "Tipologia Societ‡";
            // 
            // cmbTipologiaSocieta
            // 
            this.cmbTipologiaSocieta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipologiaSocieta.DataSource = this.DS.consultingkind;
            this.cmbTipologiaSocieta.DisplayMember = "description";
            this.cmbTipologiaSocieta.DropDownWidth = 128;
            this.cmbTipologiaSocieta.Location = new System.Drawing.Point(503, 15);
            this.cmbTipologiaSocieta.Name = "cmbTipologiaSocieta";
            this.cmbTipologiaSocieta.Size = new System.Drawing.Size(298, 21);
            this.cmbTipologiaSocieta.TabIndex = 189;
            this.cmbTipologiaSocieta.Tag = "serviceregistry.idconsultingkind";
            this.cmbTipologiaSocieta.ValueMember = "idconsultingkind";
            // 
            // checkPersonafisica
            // 
            this.checkPersonafisica.Location = new System.Drawing.Point(280, 17);
            this.checkPersonafisica.Name = "checkPersonafisica";
            this.checkPersonafisica.Size = new System.Drawing.Size(97, 19);
            this.checkPersonafisica.TabIndex = 186;
            this.checkPersonafisica.Tag = "serviceregistry.flaghuman:S:N";
            this.checkPersonafisica.Text = "Persona fisica";
            this.checkPersonafisica.CheckedChanged += new System.EventHandler(this.checkPersonafisica_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.grbSesso);
            this.groupBox1.Controls.Add(this.txtDataNascita);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblPartitaIVA);
            this.groupBox1.Controls.Add(this.txtPartitaIva);
            this.groupBox1.Controls.Add(this.chkestero);
            this.groupBox1.Controls.Add(this.lblCodiceFiscale);
            this.groupBox1.Controls.Add(this.txtCodiceFiscale);
            this.groupBox1.Controls.Add(this.txtDenominazione);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtforename);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtsurname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(6, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 125);
            this.groupBox1.TabIndex = 185;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoChoose.txtDenominazione.lista.(active=\'S\')";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtGeoComune);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(436, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 46);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtGeoComune.default";
            // 
            // txtGeoComune
            // 
            this.txtGeoComune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeoComune.Location = new System.Drawing.Point(5, 22);
            this.txtGeoComune.Name = "txtGeoComune";
            this.txtGeoComune.Size = new System.Drawing.Size(347, 20);
            this.txtGeoComune.TabIndex = 28;
            this.txtGeoComune.Tag = "geo_city.title?serviceregistryview.city";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 14);
            this.label7.TabIndex = 196;
            this.label7.Text = "Comune Sede";
            // 
            // grbSesso
            // 
            this.grbSesso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSesso.Controls.Add(this.rdbgenderf);
            this.grbSesso.Controls.Add(this.rdbgenderm);
            this.grbSesso.Location = new System.Drawing.Point(671, 9);
            this.grbSesso.Name = "grbSesso";
            this.grbSesso.Size = new System.Drawing.Size(111, 44);
            this.grbSesso.TabIndex = 30;
            this.grbSesso.TabStop = false;
            this.grbSesso.Text = "Sesso";
            // 
            // rdbgenderf
            // 
            this.rdbgenderf.Location = new System.Drawing.Point(41, 19);
            this.rdbgenderf.Name = "rdbgenderf";
            this.rdbgenderf.Size = new System.Drawing.Size(32, 16);
            this.rdbgenderf.TabIndex = 2;
            this.rdbgenderf.Tag = "serviceregistry.gender:F";
            this.rdbgenderf.Text = "F";
            // 
            // rdbgenderm
            // 
            this.rdbgenderm.Location = new System.Drawing.Point(6, 18);
            this.rdbgenderm.Name = "rdbgenderm";
            this.rdbgenderm.Size = new System.Drawing.Size(28, 18);
            this.rdbgenderm.TabIndex = 1;
            this.rdbgenderm.Tag = "serviceregistry.gender:M";
            this.rdbgenderm.Text = "M";
            // 
            // txtDataNascita
            // 
            this.txtDataNascita.Location = new System.Drawing.Point(383, 55);
            this.txtDataNascita.Name = "txtDataNascita";
            this.txtDataNascita.Size = new System.Drawing.Size(120, 20);
            this.txtDataNascita.TabIndex = 26;
            this.txtDataNascita.Tag = "serviceregistry.birthdate";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(311, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 195;
            this.label8.Text = "Data nascita";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartitaIVA
            // 
            this.lblPartitaIVA.Location = new System.Drawing.Point(14, 84);
            this.lblPartitaIVA.Name = "lblPartitaIVA";
            this.lblPartitaIVA.Size = new System.Drawing.Size(64, 19);
            this.lblPartitaIVA.TabIndex = 193;
            this.lblPartitaIVA.Text = "Partita IVA";
            this.lblPartitaIVA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPartitaIva
            // 
            this.txtPartitaIva.Location = new System.Drawing.Point(87, 81);
            this.txtPartitaIva.Name = "txtPartitaIva";
            this.txtPartitaIva.Size = new System.Drawing.Size(225, 20);
            this.txtPartitaIva.TabIndex = 27;
            this.txtPartitaIva.Tag = "serviceregistry.p_iva";
            // 
            // chkestero
            // 
            this.chkestero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkestero.Location = new System.Drawing.Point(320, 86);
            this.chkestero.Name = "chkestero";
            this.chkestero.Size = new System.Drawing.Size(159, 19);
            this.chkestero.TabIndex = 22;
            this.chkestero.Tag = "serviceregistry.flagforeign:S:N";
            this.chkestero.Text = "Sede legale estero";
            this.chkestero.CheckedChanged += new System.EventHandler(this.chkestero_CheckedChanged);
            // 
            // lblCodiceFiscale
            // 
            this.lblCodiceFiscale.Location = new System.Drawing.Point(7, 60);
            this.lblCodiceFiscale.Name = "lblCodiceFiscale";
            this.lblCodiceFiscale.Size = new System.Drawing.Size(80, 19);
            this.lblCodiceFiscale.TabIndex = 182;
            this.lblCodiceFiscale.Text = "Codice fiscale";
            this.lblCodiceFiscale.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCodiceFiscale
            // 
            this.txtCodiceFiscale.Location = new System.Drawing.Point(87, 57);
            this.txtCodiceFiscale.Name = "txtCodiceFiscale";
            this.txtCodiceFiscale.Size = new System.Drawing.Size(224, 20);
            this.txtCodiceFiscale.TabIndex = 25;
            this.txtCodiceFiscale.Tag = "serviceregistry.cf";
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Location = new System.Drawing.Point(88, 11);
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(572, 20);
            this.txtDenominazione.TabIndex = 22;
            this.txtDenominazione.Tag = "registry.title?serviceregistry.title";
            this.txtDenominazione.Leave += new System.EventHandler(this.txtDenominazione_Leave);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 185;
            this.label6.Text = "Denominazione";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtforename
            // 
            this.txtforename.Location = new System.Drawing.Point(382, 33);
            this.txtforename.Name = "txtforename";
            this.txtforename.Size = new System.Drawing.Size(278, 20);
            this.txtforename.TabIndex = 24;
            this.txtforename.Tag = "serviceregistry.forename";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(345, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 184;
            this.label5.Text = "Nome";
            // 
            // txtsurname
            // 
            this.txtsurname.Location = new System.Drawing.Point(88, 34);
            this.txtsurname.Name = "txtsurname";
            this.txtsurname.Size = new System.Drawing.Size(248, 20);
            this.txtsurname.TabIndex = 23;
            this.txtsurname.Tag = "serviceregistry.surname";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 183;
            this.label4.Text = "Cognome";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbQualifica
            // 
            this.cmbQualifica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQualifica.DataSource = this.DS.apmanager;
            this.cmbQualifica.DisplayMember = "description";
            this.cmbQualifica.ItemHeight = 13;
            this.cmbQualifica.Location = new System.Drawing.Point(414, 45);
            this.cmbQualifica.Name = "cmbQualifica";
            this.cmbQualifica.Size = new System.Drawing.Size(387, 21);
            this.cmbQualifica.TabIndex = 21;
            this.cmbQualifica.Tag = "serviceregistry.idapmanager";
            this.cmbQualifica.ValueMember = "idapmanager";
            // 
            // btnqualifica
            // 
            this.btnqualifica.Location = new System.Drawing.Point(280, 42);
            this.btnqualifica.Name = "btnqualifica";
            this.btnqualifica.Size = new System.Drawing.Size(124, 24);
            this.btnqualifica.TabIndex = 8;
            this.btnqualifica.TabStop = false;
            this.btnqualifica.Tag = "manage.apmanager.default";
            this.btnqualifica.Text = "Qualifica Dipendente";
            // 
            // grbIncaricato
            // 
            this.grbIncaricato.Controls.Add(this.rdbconsulente02);
            this.grbIncaricato.Controls.Add(this.rdbdipendente);
            this.grbIncaricato.Controls.Add(this.rdbconsulente01);
            this.grbIncaricato.Location = new System.Drawing.Point(7, 14);
            this.grbIncaricato.Name = "grbIncaricato";
            this.grbIncaricato.Size = new System.Drawing.Size(265, 60);
            this.grbIncaricato.TabIndex = 11;
            this.grbIncaricato.TabStop = false;
            // 
            // rdbconsulente02
            // 
            this.rdbconsulente02.Location = new System.Drawing.Point(5, 35);
            this.rdbconsulente02.Name = "rdbconsulente02";
            this.rdbconsulente02.Size = new System.Drawing.Size(257, 20);
            this.rdbconsulente02.TabIndex = 2;
            this.rdbconsulente02.Tag = "serviceregistry.employkind:A";
            this.rdbconsulente02.Text = "Dipendente di altri Enti Pubblici";
            this.rdbconsulente02.CheckedChanged += new System.EventHandler(this.rdbconsulenti02_CheckedChanged);
            // 
            // rdbdipendente
            // 
            this.rdbdipendente.Location = new System.Drawing.Point(91, 13);
            this.rdbdipendente.Name = "rdbdipendente";
            this.rdbdipendente.Size = new System.Drawing.Size(163, 20);
            this.rdbdipendente.TabIndex = 1;
            this.rdbdipendente.Tag = "serviceregistry.employkind:D";
            this.rdbdipendente.Text = "Dipendente dello stesso Ente";
            this.rdbdipendente.CheckedChanged += new System.EventHandler(this.rdbdipendente_CheckedChanged);
            // 
            // rdbconsulente01
            // 
            this.rdbconsulente01.Location = new System.Drawing.Point(6, 13);
            this.rdbconsulente01.Name = "rdbconsulente01";
            this.rdbconsulente01.Size = new System.Drawing.Size(84, 20);
            this.rdbconsulente01.TabIndex = 0;
            this.rdbconsulente01.Tag = "serviceregistry.employkind:C";
            this.rdbconsulente01.Text = "Consulente";
            this.rdbconsulente01.CheckedChanged += new System.EventHandler(this.rdbconsulente_CheckedChanged);
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(0, 0);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(100, 20);
            this.txtEsercizio.TabIndex = 10;
            // 
            // tabPubblicazione
            // 
            this.tabPubblicazione.Controls.Add(this.label22);
            this.tabPubblicazione.Controls.Add(this.grpPubblicazione);
            this.tabPubblicazione.Location = new System.Drawing.Point(4, 22);
            this.tabPubblicazione.Name = "tabPubblicazione";
            this.tabPubblicazione.Size = new System.Drawing.Size(840, 661);
            this.tabPubblicazione.TabIndex = 2;
            this.tabPubblicazione.Text = "Pubblicazione";
            this.tabPubblicazione.UseVisualStyleBackColor = true;
            this.tabPubblicazione.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(515, 13);
            this.label22.TabIndex = 49;
            this.label22.Text = "Informazioni non previste dall\'anagrafe delle prestazioni ma utili per la pubblic" +
    "azione sul sito web istituzionale.";
            // 
            // grpPubblicazione
            // 
            this.grpPubblicazione.Controls.Add(this.chkwebSite_annulled);
            this.grpPubblicazione.Controls.Add(this.txtattestazioneConflittiInteresse);
            this.grpPubblicazione.Controls.Add(this.lblAttestazioneConflittiInteresse);
            this.grpPubblicazione.Controls.Add(this.txtDurataIncarico);
            this.grpPubblicazione.Controls.Add(this.lblDurataIncarico);
            this.grpPubblicazione.Controls.Add(this.lblStatoCV);
            this.grpPubblicazione.Controls.Add(this.txtComponentiVariabili);
            this.grpPubblicazione.Controls.Add(this.txtAttivit‡Professionali);
            this.grpPubblicazione.Controls.Add(this.txtAltriIncarichi);
            this.grpPubblicazione.Controls.Add(this.txtLinkBando);
            this.grpPubblicazione.Controls.Add(this.txtRifAttoConferimento);
            this.grpPubblicazione.Controls.Add(this.txtLinkAutorizzazione);
            this.grpPubblicazione.Controls.Add(this.txtStrutturacheAutorizza);
            this.grpPubblicazione.Controls.Add(this.txtLinkDecreto);
            this.grpPubblicazione.Controls.Add(this.txtStrutturaConferente);
            this.grpPubblicazione.Controls.Add(this.lblComponentiVariabili);
            this.grpPubblicazione.Controls.Add(this.lblAttivit‡Professionali);
            this.grpPubblicazione.Controls.Add(this.lblAltriCarichi);
            this.grpPubblicazione.Controls.Add(this.lblLinkBando);
            this.grpPubblicazione.Controls.Add(this.lblRifAttoConferimento);
            this.grpPubblicazione.Controls.Add(this.lblLinkAutorizzazione);
            this.grpPubblicazione.Controls.Add(this.lblStrutturacheAutorizza);
            this.grpPubblicazione.Controls.Add(this.lblLinkDecreto);
            this.grpPubblicazione.Controls.Add(this.lblStrutturaConferente);
            this.grpPubblicazione.Location = new System.Drawing.Point(5, 42);
            this.grpPubblicazione.Name = "grpPubblicazione";
            this.grpPubblicazione.Size = new System.Drawing.Size(759, 609);
            this.grpPubblicazione.TabIndex = 48;
            this.grpPubblicazione.TabStop = false;
            this.grpPubblicazione.Text = "Dati da pubblicare";
            // 
            // chkwebSite_annulled
            // 
            this.chkwebSite_annulled.Location = new System.Drawing.Point(17, 61);
            this.chkwebSite_annulled.Name = "chkwebSite_annulled";
            this.chkwebSite_annulled.Size = new System.Drawing.Size(253, 16);
            this.chkwebSite_annulled.TabIndex = 52;
            this.chkwebSite_annulled.TabStop = false;
            this.chkwebSite_annulled.Tag = "serviceregistry.website_annulled:S:N";
            this.chkwebSite_annulled.Text = "Annullato sul sito Web Istituzionale";
            this.chkwebSite_annulled.CheckedChanged += new System.EventHandler(this.chkwebSite_annulled_CheckedChanged);
            // 
            // txtattestazioneConflittiInteresse
            // 
            this.txtattestazioneConflittiInteresse.Location = new System.Drawing.Point(201, 557);
            this.txtattestazioneConflittiInteresse.Multiline = true;
            this.txtattestazioneConflittiInteresse.Name = "txtattestazioneConflittiInteresse";
            this.txtattestazioneConflittiInteresse.Size = new System.Drawing.Size(556, 38);
            this.txtattestazioneConflittiInteresse.TabIndex = 48;
            this.txtattestazioneConflittiInteresse.Tag = "serviceregistry.certinterestconflicts";
            // 
            // lblAttestazioneConflittiInteresse
            // 
            this.lblAttestazioneConflittiInteresse.AutoSize = true;
            this.lblAttestazioneConflittiInteresse.Location = new System.Drawing.Point(6, 560);
            this.lblAttestazioneConflittiInteresse.Name = "lblAttestazioneConflittiInteresse";
            this.lblAttestazioneConflittiInteresse.Size = new System.Drawing.Size(157, 13);
            this.lblAttestazioneConflittiInteresse.TabIndex = 51;
            this.lblAttestazioneConflittiInteresse.Text = "Attestazione conflitti di interesse";
            // 
            // txtDurataIncarico
            // 
            this.txtDurataIncarico.Location = new System.Drawing.Point(107, 93);
            this.txtDurataIncarico.Multiline = true;
            this.txtDurataIncarico.Name = "txtDurataIncarico";
            this.txtDurataIncarico.Size = new System.Drawing.Size(650, 21);
            this.txtDurataIncarico.TabIndex = 38;
            this.txtDurataIncarico.Tag = "serviceregistry.employtime";
            // 
            // lblDurataIncarico
            // 
            this.lblDurataIncarico.AutoSize = true;
            this.lblDurataIncarico.Location = new System.Drawing.Point(7, 96);
            this.lblDurataIncarico.Name = "lblDurataIncarico";
            this.lblDurataIncarico.Size = new System.Drawing.Size(80, 13);
            this.lblDurataIncarico.TabIndex = 49;
            this.lblDurataIncarico.Text = "Durata Incarico";
            // 
            // lblStatoCV
            // 
            this.lblStatoCV.AutoSize = true;
            this.lblStatoCV.Location = new System.Drawing.Point(14, 31);
            this.lblStatoCV.Name = "lblStatoCV";
            this.lblStatoCV.Size = new System.Drawing.Size(162, 13);
            this.lblStatoCV.TabIndex = 48;
            this.lblStatoCV.Text = "Lebel che notifica lo stato del CV";
            // 
            // txtComponentiVariabili
            // 
            this.txtComponentiVariabili.Location = new System.Drawing.Point(10, 515);
            this.txtComponentiVariabili.Multiline = true;
            this.txtComponentiVariabili.Name = "txtComponentiVariabili";
            this.txtComponentiVariabili.Size = new System.Drawing.Size(747, 36);
            this.txtComponentiVariabili.TabIndex = 47;
            this.txtComponentiVariabili.Tag = "serviceregistry.componentsvariable";
            // 
            // txtAttivit‡Professionali
            // 
            this.txtAttivit‡Professionali.Location = new System.Drawing.Point(12, 460);
            this.txtAttivit‡Professionali.Multiline = true;
            this.txtAttivit‡Professionali.Name = "txtAttivit‡Professionali";
            this.txtAttivit‡Professionali.Size = new System.Drawing.Size(747, 36);
            this.txtAttivit‡Professionali.TabIndex = 46;
            this.txtAttivit‡Professionali.Tag = "serviceregistry.professionalservice";
            // 
            // txtAltriIncarichi
            // 
            this.txtAltriIncarichi.Location = new System.Drawing.Point(11, 401);
            this.txtAltriIncarichi.Multiline = true;
            this.txtAltriIncarichi.Name = "txtAltriIncarichi";
            this.txtAltriIncarichi.Size = new System.Drawing.Size(747, 36);
            this.txtAltriIncarichi.TabIndex = 45;
            this.txtAltriIncarichi.Tag = "serviceregistry.otherservice";
            // 
            // txtLinkBando
            // 
            this.txtLinkBando.Location = new System.Drawing.Point(9, 360);
            this.txtLinkBando.Name = "txtLinkBando";
            this.txtLinkBando.Size = new System.Drawing.Size(748, 20);
            this.txtLinkBando.TabIndex = 44;
            this.txtLinkBando.Tag = "serviceregistry.announcementlink";
            // 
            // txtRifAttoConferimento
            // 
            this.txtRifAttoConferimento.Location = new System.Drawing.Point(201, 306);
            this.txtRifAttoConferimento.Multiline = true;
            this.txtRifAttoConferimento.Name = "txtRifAttoConferimento";
            this.txtRifAttoConferimento.Size = new System.Drawing.Size(556, 38);
            this.txtRifAttoConferimento.TabIndex = 43;
            this.txtRifAttoConferimento.Tag = "serviceregistry.actreference";
            // 
            // txtLinkAutorizzazione
            // 
            this.txtLinkAutorizzazione.Location = new System.Drawing.Point(9, 280);
            this.txtLinkAutorizzazione.Name = "txtLinkAutorizzazione";
            this.txtLinkAutorizzazione.Size = new System.Drawing.Size(748, 20);
            this.txtLinkAutorizzazione.TabIndex = 42;
            this.txtLinkAutorizzazione.Tag = "serviceregistry.authorizinglink";
            // 
            // txtStrutturacheAutorizza
            // 
            this.txtStrutturacheAutorizza.Location = new System.Drawing.Point(139, 223);
            this.txtStrutturacheAutorizza.Multiline = true;
            this.txtStrutturacheAutorizza.Name = "txtStrutturacheAutorizza";
            this.txtStrutturacheAutorizza.Size = new System.Drawing.Size(618, 38);
            this.txtStrutturacheAutorizza.TabIndex = 41;
            this.txtStrutturacheAutorizza.Tag = "serviceregistry.authorizingstructure";
            // 
            // txtLinkDecreto
            // 
            this.txtLinkDecreto.Location = new System.Drawing.Point(9, 194);
            this.txtLinkDecreto.Name = "txtLinkDecreto";
            this.txtLinkDecreto.Size = new System.Drawing.Size(748, 20);
            this.txtLinkDecreto.TabIndex = 40;
            this.txtLinkDecreto.Tag = "serviceregistry.ordinancelink";
            this.txtLinkDecreto.TextChanged += new System.EventHandler(this.txtLinkDecreto_TextChanged);
            // 
            // txtStrutturaConferente
            // 
            this.txtStrutturaConferente.Location = new System.Drawing.Point(9, 141);
            this.txtStrutturaConferente.Multiline = true;
            this.txtStrutturaConferente.Name = "txtStrutturaConferente";
            this.txtStrutturaConferente.Size = new System.Drawing.Size(748, 36);
            this.txtStrutturaConferente.TabIndex = 39;
            this.txtStrutturaConferente.Tag = "serviceregistry.conferringstructure";
            // 
            // lblComponentiVariabili
            // 
            this.lblComponentiVariabili.AutoSize = true;
            this.lblComponentiVariabili.Location = new System.Drawing.Point(12, 499);
            this.lblComponentiVariabili.Name = "lblComponentiVariabili";
            this.lblComponentiVariabili.Size = new System.Drawing.Size(170, 13);
            this.lblComponentiVariabili.TabIndex = 38;
            this.lblComponentiVariabili.Text = "Componenti variabili del compenso";
            // 
            // lblAttivit‡Professionali
            // 
            this.lblAttivit‡Professionali.AutoSize = true;
            this.lblAttivit‡Professionali.Location = new System.Drawing.Point(8, 444);
            this.lblAttivit‡Professionali.Name = "lblAttivit‡Professionali";
            this.lblAttivit‡Professionali.Size = new System.Drawing.Size(146, 13);
            this.lblAttivit‡Professionali.TabIndex = 37;
            this.lblAttivit‡Professionali.Text = "Eventuali attivit‡ professionali";
            // 
            // lblAltriCarichi
            // 
            this.lblAltriCarichi.AutoSize = true;
            this.lblAltriCarichi.Location = new System.Drawing.Point(8, 385);
            this.lblAltriCarichi.Name = "lblAltriCarichi";
            this.lblAltriCarichi.Size = new System.Drawing.Size(300, 13);
            this.lblAltriCarichi.TabIndex = 36;
            this.lblAltriCarichi.Text = "Altri incarichi o cariche in enti di diritto privato finanziati da P.A.";
            // 
            // lblLinkBando
            // 
            this.lblLinkBando.AutoSize = true;
            this.lblLinkBando.Location = new System.Drawing.Point(9, 344);
            this.lblLinkBando.Name = "lblLinkBando";
            this.lblLinkBando.Size = new System.Drawing.Size(71, 13);
            this.lblLinkBando.TabIndex = 35;
            this.lblLinkBando.Text = "Link al bando";
            // 
            // lblRifAttoConferimento
            // 
            this.lblRifAttoConferimento.AutoSize = true;
            this.lblRifAttoConferimento.Location = new System.Drawing.Point(6, 309);
            this.lblRifAttoConferimento.Name = "lblRifAttoConferimento";
            this.lblRifAttoConferimento.Size = new System.Drawing.Size(175, 13);
            this.lblRifAttoConferimento.TabIndex = 34;
            this.lblRifAttoConferimento.Text = "Riferimento dellíatto di conferimento";
            // 
            // lblLinkAutorizzazione
            // 
            this.lblLinkAutorizzazione.AutoSize = true;
            this.lblLinkAutorizzazione.Location = new System.Drawing.Point(9, 262);
            this.lblLinkAutorizzazione.Name = "lblLinkAutorizzazione";
            this.lblLinkAutorizzazione.Size = new System.Drawing.Size(142, 13);
            this.lblLinkAutorizzazione.TabIndex = 33;
            this.lblLinkAutorizzazione.Text = "Link allíatto di autorizzazione";
            // 
            // lblStrutturacheAutorizza
            // 
            this.lblStrutturacheAutorizza.AutoSize = true;
            this.lblStrutturacheAutorizza.Location = new System.Drawing.Point(6, 226);
            this.lblStrutturacheAutorizza.Name = "lblStrutturacheAutorizza";
            this.lblStrutturacheAutorizza.Size = new System.Drawing.Size(113, 13);
            this.lblStrutturacheAutorizza.TabIndex = 32;
            this.lblStrutturacheAutorizza.Text = "Struttura che autorizza";
            this.lblStrutturacheAutorizza.Click += new System.EventHandler(this.label41_Click);
            // 
            // lblLinkDecreto
            // 
            this.lblLinkDecreto.AutoSize = true;
            this.lblLinkDecreto.Location = new System.Drawing.Point(6, 180);
            this.lblLinkDecreto.Name = "lblLinkDecreto";
            this.lblLinkDecreto.Size = new System.Drawing.Size(211, 13);
            this.lblLinkDecreto.TabIndex = 31;
            this.lblLinkDecreto.Text = "Link al decreto di conferimento dellíincarico";
            // 
            // lblStrutturaConferente
            // 
            this.lblStrutturaConferente.AutoSize = true;
            this.lblStrutturaConferente.Location = new System.Drawing.Point(6, 125);
            this.lblStrutturaConferente.Name = "lblStrutturaConferente";
            this.lblStrutturaConferente.Size = new System.Drawing.Size(101, 13);
            this.lblStrutturaConferente.TabIndex = 30;
            this.lblStrutturaConferente.Text = "Struttura conferente";
            // 
            // tabPagamento
            // 
            this.tabPagamento.Controls.Add(this.GBoxPagamento);
            this.tabPagamento.Location = new System.Drawing.Point(4, 22);
            this.tabPagamento.Name = "tabPagamento";
            this.tabPagamento.Size = new System.Drawing.Size(840, 661);
            this.tabPagamento.TabIndex = 3;
            this.tabPagamento.Text = "Pagamento";
            this.tabPagamento.UseVisualStyleBackColor = true;
            // 
            // GBoxPagamento
            // 
            this.GBoxPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBoxPagamento.Controls.Add(this.btnDeletePag);
            this.GBoxPagamento.Controls.Add(this.btnEditPag);
            this.GBoxPagamento.Controls.Add(this.btnInsertPag);
            this.GBoxPagamento.Controls.Add(this.gridPagamento);
            this.GBoxPagamento.Location = new System.Drawing.Point(8, 20);
            this.GBoxPagamento.Name = "GBoxPagamento";
            this.GBoxPagamento.Size = new System.Drawing.Size(824, 201);
            this.GBoxPagamento.TabIndex = 17;
            this.GBoxPagamento.TabStop = false;
            this.GBoxPagamento.Text = "Pagamento";
            // 
            // btnDeletePag
            // 
            this.btnDeletePag.Location = new System.Drawing.Point(8, 80);
            this.btnDeletePag.Name = "btnDeletePag";
            this.btnDeletePag.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePag.TabIndex = 27;
            this.btnDeletePag.Tag = "delete";
            this.btnDeletePag.Text = "Elimina";
            // 
            // btnEditPag
            // 
            this.btnEditPag.Location = new System.Drawing.Point(8, 48);
            this.btnEditPag.Name = "btnEditPag";
            this.btnEditPag.Size = new System.Drawing.Size(75, 23);
            this.btnEditPag.TabIndex = 26;
            this.btnEditPag.Tag = "edit.detail";
            this.btnEditPag.Text = "Modifica...";
            // 
            // btnInsertPag
            // 
            this.btnInsertPag.Location = new System.Drawing.Point(8, 16);
            this.btnInsertPag.Name = "btnInsertPag";
            this.btnInsertPag.Size = new System.Drawing.Size(75, 23);
            this.btnInsertPag.TabIndex = 25;
            this.btnInsertPag.Tag = "insert.detail";
            this.btnInsertPag.Text = "Inserisci...";
            // 
            // gridPagamento
            // 
            this.gridPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPagamento.DataMember = "";
            this.gridPagamento.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridPagamento.Location = new System.Drawing.Point(88, 16);
            this.gridPagamento.Name = "gridPagamento";
            this.gridPagamento.Size = new System.Drawing.Size(728, 177);
            this.gridPagamento.TabIndex = 30;
            this.gridPagamento.Tag = "servicepayment.default.detail";
            // 
            // tabConferente
            // 
            this.tabConferente.Controls.Add(this.grbconferente);
            this.tabConferente.Location = new System.Drawing.Point(4, 22);
            this.tabConferente.Name = "tabConferente";
            this.tabConferente.Size = new System.Drawing.Size(840, 661);
            this.tabConferente.TabIndex = 1;
            this.tabConferente.Text = "Altro";
            this.tabConferente.UseVisualStyleBackColor = true;
            // 
            // grbconferente
            // 
            this.grbconferente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbconferente.Controls.Add(this.label24);
            this.grbconferente.Controls.Add(this.txtNote);
            this.grbconferente.Controls.Add(this.label21);
            this.grbconferente.Controls.Add(this.txtIdMittente);
            this.grbconferente.Controls.Add(this.label29);
            this.grbconferente.Controls.Add(this.chkregulation);
            this.grbconferente.Controls.Add(this.grpRiferimentoNormativo);
            this.grbconferente.Controls.Add(this.chkNormativa);
            this.grbconferente.Controls.Add(this.cmbdipertimento);
            this.grbconferente.Controls.Add(this.button1);
            this.grbconferente.Controls.Add(this.textBox8);
            this.grbconferente.Controls.Add(this.label23);
            this.grbconferente.Controls.Add(this.txtRelazioneAccompagnamento);
            this.grbconferente.Controls.Add(this.label25);
            this.grbconferente.Controls.Add(this.txtpa_code);
            this.grbconferente.Location = new System.Drawing.Point(8, 0);
            this.grbconferente.Name = "grbconferente";
            this.grbconferente.Size = new System.Drawing.Size(815, 651);
            this.grbconferente.TabIndex = 0;
            this.grbconferente.TabStop = false;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(15, 553);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(113, 20);
            this.label24.TabIndex = 61;
            this.label24.Text = "Note";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Location = new System.Drawing.Point(138, 550);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(662, 56);
            this.txtNote.TabIndex = 60;
            this.txtNote.Tag = "serviceregistry.notes";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(174, 13);
            this.label21.TabIndex = 59;
            this.label21.Text = "ID della PA o della UO che dichiara";
            // 
            // txtIdMittente
            // 
            this.txtIdMittente.Location = new System.Drawing.Point(185, 39);
            this.txtIdMittente.Name = "txtIdMittente";
            this.txtIdMittente.ReadOnly = true;
            this.txtIdMittente.Size = new System.Drawing.Size(158, 20);
            this.txtIdMittente.TabIndex = 58;
            this.txtIdMittente.Tag = "serviceregistry.senderreporting";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(29, 43);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(147, 13);
            this.label29.TabIndex = 57;
            this.label29.Text = "Identificativo incarico mittente";
            // 
            // chkregulation
            // 
            this.chkregulation.AutoSize = true;
            this.chkregulation.Location = new System.Drawing.Point(9, 452);
            this.chkregulation.Name = "chkregulation";
            this.chkregulation.Size = new System.Drawing.Size(514, 17);
            this.chkregulation.TabIndex = 51;
            this.chkregulation.Tag = "serviceregistry.regulation:S:N";
            this.chkregulation.Text = "Per la modalit‡ di selezione si Ë fatto riferimento ad un regolamento all\'uopo ad" +
    "ottato dall\'amministrazione";
            this.chkregulation.UseVisualStyleBackColor = true;
            // 
            // grpRiferimentoNormativo
            // 
            this.grpRiferimentoNormativo.Controls.Add(this.label26);
            this.grpRiferimentoNormativo.Controls.Add(this.label18);
            this.grpRiferimentoNormativo.Controls.Add(this.label16);
            this.grpRiferimentoNormativo.Controls.Add(this.label15);
            this.grpRiferimentoNormativo.Controls.Add(this.cmbRiferimentoNormativo);
            this.grpRiferimentoNormativo.Controls.Add(this.label9);
            this.grpRiferimentoNormativo.Controls.Add(this.txtDataNormativa);
            this.grpRiferimentoNormativo.Controls.Add(this.txtArticoloNormativa);
            this.grpRiferimentoNormativo.Controls.Add(this.txtNumeroNormativa);
            this.grpRiferimentoNormativo.Controls.Add(this.txtCommaNormativa);
            this.grpRiferimentoNormativo.Location = new System.Drawing.Point(6, 140);
            this.grpRiferimentoNormativo.Name = "grpRiferimentoNormativo";
            this.grpRiferimentoNormativo.Size = new System.Drawing.Size(754, 172);
            this.grpRiferimentoNormativo.TabIndex = 50;
            this.grpRiferimentoNormativo.TabStop = false;
            this.grpRiferimentoNormativo.Text = "Riferimento Normativo Incarico";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(81, 127);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(42, 13);
            this.label26.TabIndex = 9;
            this.label26.Text = "Comma";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(80, 103);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Articolo";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(92, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Data";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(79, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Numero";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRiferimentoNormativo
            // 
            this.cmbRiferimentoNormativo.DataSource = this.DS.referencerule;
            this.cmbRiferimentoNormativo.DisplayMember = "description";
            this.cmbRiferimentoNormativo.FormattingEnabled = true;
            this.cmbRiferimentoNormativo.Location = new System.Drawing.Point(132, 24);
            this.cmbRiferimentoNormativo.Name = "cmbRiferimentoNormativo";
            this.cmbRiferimentoNormativo.Size = new System.Drawing.Size(616, 21);
            this.cmbRiferimentoNormativo.TabIndex = 5;
            this.cmbRiferimentoNormativo.Tag = "serviceregistry.idreferencerule";
            this.cmbRiferimentoNormativo.ValueMember = "idreferencerule";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Riferimento normativo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataNormativa
            // 
            this.txtDataNormativa.Location = new System.Drawing.Point(132, 77);
            this.txtDataNormativa.Name = "txtDataNormativa";
            this.txtDataNormativa.Size = new System.Drawing.Size(77, 20);
            this.txtDataNormativa.TabIndex = 7;
            this.txtDataNormativa.Tag = "serviceregistry.referencedate";
            // 
            // txtArticoloNormativa
            // 
            this.txtArticoloNormativa.Location = new System.Drawing.Point(132, 103);
            this.txtArticoloNormativa.Multiline = true;
            this.txtArticoloNormativa.Name = "txtArticoloNormativa";
            this.txtArticoloNormativa.Size = new System.Drawing.Size(428, 18);
            this.txtArticoloNormativa.TabIndex = 8;
            this.txtArticoloNormativa.Tag = "serviceregistry.article";
            // 
            // txtNumeroNormativa
            // 
            this.txtNumeroNormativa.Location = new System.Drawing.Point(132, 51);
            this.txtNumeroNormativa.Multiline = true;
            this.txtNumeroNormativa.Name = "txtNumeroNormativa";
            this.txtNumeroNormativa.Size = new System.Drawing.Size(616, 20);
            this.txtNumeroNormativa.TabIndex = 6;
            this.txtNumeroNormativa.Tag = "serviceregistry.articlenumber";
            // 
            // txtCommaNormativa
            // 
            this.txtCommaNormativa.Location = new System.Drawing.Point(132, 127);
            this.txtCommaNormativa.Multiline = true;
            this.txtCommaNormativa.Name = "txtCommaNormativa";
            this.txtCommaNormativa.Size = new System.Drawing.Size(616, 37);
            this.txtCommaNormativa.TabIndex = 9;
            this.txtCommaNormativa.Tag = "serviceregistry.paragraph";
            // 
            // chkNormativa
            // 
            this.chkNormativa.AutoSize = true;
            this.chkNormativa.Location = new System.Drawing.Point(8, 106);
            this.chkNormativa.Name = "chkNormativa";
            this.chkNormativa.Size = new System.Drawing.Size(290, 17);
            this.chkNormativa.TabIndex = 49;
            this.chkNormativa.Tag = "serviceregistry.rulespecifics:S:N";
            this.chkNormativa.Text = "Incarico conferito in applicazione di una specifica norma";
            this.chkNormativa.UseVisualStyleBackColor = true;
            this.chkNormativa.CheckedChanged += new System.EventHandler(this.chkNormativa_CheckedChanged);
            // 
            // cmbdipertimento
            // 
            this.cmbdipertimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbdipertimento.DataSource = this.DS.department;
            this.cmbdipertimento.DisplayMember = "description";
            this.cmbdipertimento.Location = new System.Drawing.Point(354, 39);
            this.cmbdipertimento.Name = "cmbdipertimento";
            this.cmbdipertimento.Size = new System.Drawing.Size(455, 21);
            this.cmbdipertimento.TabIndex = 37;
            this.cmbdipertimento.Tag = "serviceregistry.iddepartment";
            this.cmbdipertimento.ValueMember = "iddepartment";
            this.cmbdipertimento.Visible = false;
            this.cmbdipertimento.SelectedIndexChanged += new System.EventHandler(this.cmbdipertimento_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 24);
            this.button1.TabIndex = 45;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.department.default";
            this.button1.Text = "Dipartimento";
            this.button1.Visible = false;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Location = new System.Drawing.Point(141, 489);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(662, 41);
            this.textBox8.TabIndex = 11;
            this.textBox8.Tag = "serviceregistry.referencerule";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(6, 489);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(113, 20);
            this.label23.TabIndex = 44;
            this.label23.Text = "Riferimenti Normativi";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRelazioneAccompagnamento
            // 
            this.txtRelazioneAccompagnamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelazioneAccompagnamento.Location = new System.Drawing.Point(138, 360);
            this.txtRelazioneAccompagnamento.Multiline = true;
            this.txtRelazioneAccompagnamento.Name = "txtRelazioneAccompagnamento";
            this.txtRelazioneAccompagnamento.Size = new System.Drawing.Size(671, 75);
            this.txtRelazioneAccompagnamento.TabIndex = 10;
            this.txtRelazioneAccompagnamento.Tag = "serviceregistry.annotation";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(6, 338);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(445, 30);
            this.label25.TabIndex = 40;
            this.label25.Tag = "";
            this.label25.Text = "Relazione di accompagnamento contenente i dati richiesti dalla legge n. 190/2012." +
    " \t\r\n";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtpa_code
            // 
            this.txtpa_code.Location = new System.Drawing.Point(185, 14);
            this.txtpa_code.Name = "txtpa_code";
            this.txtpa_code.ReadOnly = true;
            this.txtpa_code.Size = new System.Drawing.Size(158, 20);
            this.txtpa_code.TabIndex = 35;
            this.txtpa_code.Tag = "serviceregistry.pa_code";
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
            this.tabAttributi.Size = new System.Drawing.Size(840, 661);
            this.tabAttributi.TabIndex = 4;
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
            this.gboxclass05.Location = new System.Drawing.Point(13, 293);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(625, 64);
            this.gboxclass05.TabIndex = 38;
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
            this.txtDenom05.Size = new System.Drawing.Size(383, 52);
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
            this.gboxclass04.Location = new System.Drawing.Point(13, 223);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(625, 64);
            this.gboxclass04.TabIndex = 37;
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
            this.txtDenom04.Size = new System.Drawing.Size(383, 46);
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
            this.gboxclass03.Location = new System.Drawing.Point(13, 153);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(625, 64);
            this.gboxclass03.TabIndex = 35;
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
            this.txtDenom03.Size = new System.Drawing.Size(384, 52);
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
            this.gboxclass02.Location = new System.Drawing.Point(13, 83);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(625, 64);
            this.gboxclass02.TabIndex = 36;
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
            this.txtDenom02.Size = new System.Drawing.Size(384, 52);
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
            this.gboxclass01.Location = new System.Drawing.Point(13, 13);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(625, 64);
            this.gboxclass01.TabIndex = 34;
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
            this.txtDenom01.Size = new System.Drawing.Size(384, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(0, 0);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 24);
            this.radioButton2.TabIndex = 0;
            // 
            // cmbdepartment
            // 
            this.cmbdepartment.Location = new System.Drawing.Point(0, 0);
            this.cmbdepartment.Name = "cmbdepartment";
            this.cmbdepartment.Size = new System.Drawing.Size(121, 21);
            this.cmbdepartment.TabIndex = 0;
            // 
            // Frm_serviceregistry_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(836, 693);
            this.Controls.Add(this.Principale);
            this.Name = "Frm_serviceregistry_default";
            this.Text = "Frm_serviceregistry_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.Principale.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.grpAnagraficaConferente.ResumeLayout(false);
            this.grpAnagraficaConferente.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpSessoConferente.ResumeLayout(false);
            this.grpContratto.ResumeLayout(false);
            this.grpContratto.PerformLayout();
            this.grbincarico.ResumeLayout(false);
            this.grbincarico.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpAttivitaEconomica.ResumeLayout(false);
            this.grpAttivitaEconomica.PerformLayout();
            this.grpincaricato.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grbSesso.ResumeLayout(false);
            this.grbIncaricato.ResumeLayout(false);
            this.tabPubblicazione.ResumeLayout(false);
            this.tabPubblicazione.PerformLayout();
            this.grpPubblicazione.ResumeLayout(false);
            this.grpPubblicazione.PerformLayout();
            this.tabPagamento.ResumeLayout(false);
            this.GBoxPagamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPagamento)).EndInit();
            this.tabConferente.ResumeLayout(false);
            this.grbconferente.ResumeLayout(false);
            this.grbconferente.PerformLayout();
            this.grpRiferimentoNormativo.ResumeLayout(false);
            this.grpRiferimentoNormativo.PerformLayout();
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
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			//Meta.CanInsertCopy = false;   12786
			QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            Conn = Meta.Conn;
            //////////string filtereserc_service = QHS.CmpEq("yservreg", Meta.GetSys("esercizio"));
            //////////GetData.SetStaticFilter(DS.serviceregistry,filtereserc_service);

			GetData.CacheTable(DS.serviceagency,Conn.SelectCondition("serviceagency",true),null,false);
            //string filter_active = QHS.CmpEq("active", "S");
            //GetData.SetStaticFilter(DS.apmanager,filteresercizio);
            //GetData.SetStaticFilter(DS.consultingkind,filteresercizio);
            //GetData.SetStaticFilter(DS.apcontractkind, filter_active);
            //GetData.SetStaticFilter(DS.financialactivity, filter_active);
            //GetData.SetStaticFilter(DS.acquirekind, filter_active);
            //GetData.SetStaticFilter(DS.apregistrykind,filteresercizio);
            //GetData.SetStaticFilter(DS.apactivitykind,filteresercizio);
 
            QueryCreator.setSkipInsertCopy(DS.servicepayment , true);

			HelpForm.SetDenyNull(DS.serviceregistry.Columns["is_annulled"], true);
            HelpForm.SetDenyNull(DS.serviceregistry.Columns["website_annulled"], true);
			HelpForm.SetDenyNull(DS.serviceregistry.Columns["is_delivered"], true);
			HelpForm.SetDenyNull(DS.serviceregistry.Columns["is_changed"], true);
			HelpForm.SetDenyNull(DS.serviceregistry.Columns["is_blocked"], true);
            HelpForm.SetDenyNull(DS.serviceregistry.Columns["regulation"], true);
            HelpForm.SetDenyNull(DS.serviceregistry.Columns["rulespecifics"], true);
            HelpForm.SetDenyNull(DS.serviceregistry.Columns["flaghuman"], true);
            HelpForm.SetDenyNull(DS.serviceregistry.Columns["flagforeign"], true);
            HelpForm.SetDenyNull(DS.serviceregistry.Columns["conferring_flagforeign"], true);

            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Meta.Conn.RUN_SELECT("uniconfig", "*", null,
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
                    Principale.TabPages.Remove(tabAttributi);
                    }
                }
		}

        public void MetaData_AfterPost() {
          if (DS.serviceregistry.Rows.Count==0) return; //It was an insert-cancel

			DataRow Curr=DS.serviceregistry.Rows[0];

          	if (Curr.RowState==DataRowState.Deleted){
				//Should delete the related entries 
				return;
			}
            //Vale solo per i Dipendenti
			if((Curr["employkind"].ToString().ToUpper() == "D")&& (Curr["authorizationdate"]==DBNull.Value)) {
                MessageBox.Show("Non Ë stata inserita la data Conferimento/Autorizzazione. Questo causer‡ lo scarto dell'incarico nella pubblicazione sul sito Web Istituzionale"
                + " e nel file di trasmissione a PerlaPA.", "Avviso");
			}
        }
  
		public void MetaData_AfterClear() 
		{
			txtidservice.Enabled=true;
			chkisdelivery.Enabled = true;
			chkischanged.Enabled = true;	
			chkis_annulled.Enabled = true;
            chkwebSite_annulled.Enabled = true;
			chkblocked.Enabled = true;
//			chkblocked.Visible = true;

			btnTipologiaSocieta.Enabled = true;
			cmbTipologiaSocieta.Enabled = true;
            checkPersonafisica.Enabled = true;
			btnqualifica.Enabled = true;
			cmbQualifica.Enabled = true;
			btnTipologiaConferente.Enabled = true;
			cmbtipologiaconferente.Enabled = true;
			btntipologiaincaricato.Enabled = true;
			cmbtipologiaincarico.Enabled = true;
			btnmodacquisizione.Enabled = true;
			cmbmodacquisizione.Enabled = true;
			btnTiporapporto.Enabled = true;
			cmbtiporapporto.Enabled = true;
			btnattivitaeconomica.Enabled = true;
			cmbattivitaeconomica.Enabled = true;
            grpAttivitaEconomica.Enabled = true;
			txtDenominazione.ReadOnly = false;
			txtsurname.Enabled =true;
			txtforename.Enabled=true;
			txtCodiceFiscale.Enabled =true;
			txtDataNascita.Enabled =true;
			txtPartitaIva.Enabled =true;
			rdbgenderm.Enabled =true;
			rdbgenderf.Enabled =true;
			txtGeoComune.Text = "";
			txtGeoComune.ReadOnly=false;
			txtGeoComune.Enabled=true;

            txtDenominazioneConferente.ReadOnly = false;
            txtCognomeConferente.Enabled = true;
            txtNomeConferente.Enabled = true;
            txtCFconferente.Enabled = true;
            txtDatanascitaConferente.Enabled = true;
            txtPivaConferente.Enabled = true;
            rdbGenderFCoferente.Enabled = true;
            rdbGenderMCoferente.Enabled = true;
            txtGeoComuneConferente.Text = "";
            txtGeoComuneConferente.ReadOnly = false;
            txtGeoComuneConferente.Enabled = true;

            cmbTipologia.Enabled = true;

			abilitaGruppi(true);
            txteser.Text = Meta.GetSys("esercizio").ToString();
            AbilitaCodiciValidi();
            AbilitaRiferimentoNormativo();
            lblStatoCV.Text = "";
            txtBozza.Visible = false;
            btnTipologiaSocieta.Text = "Tipologia Societ‡";
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.serviceregistry.Rows[0];
            if (R == null) return;

            if (T.TableName == "registry" && Meta.DrawStateIsDone) {
                CleanTxtRegistry();
                RiempieOggettiCD(R);
                Curr["title"] = R["title"];
                //VisualizzaStatoCV(R["idreg"]);
                if (R == null) {
                    txtGeoComune.Text = "";
                    Curr["idcity"] = null;
                    return;
                }
                else {
                    RicavaComuneDaIdreg("I");//Incaricato
                }
            }
            if (T.TableName == "conferente" && Meta.DrawStateIsDone) {
                CleanTxtConferente();
                RiempieOggettiConferente(R);
                Curr["pa_title"] = R["title"];
                if (R == null) {
                    txtGeoComuneConferente.Text = "";
                    Curr["conferring_idcity"] = null;
                    return;
                }
                else {
                    //RicavaComuneConferenteDaIdregConferente();
                    RicavaComuneDaIdreg("C");//Conferente
                }
            }

            if (!Meta.IsEmpty && (T.TableName == "geo_city") && (R != null)) {
                object idgeo = R["idcity"];
                ImpostaComune(idgeo);
            }

            if (T.TableName == "apregistrykind" && Meta.DrawStateIsDone) {
                if (!Meta.IsEmpty) Meta.GetFormData(true);
                abilitaControlli();
            }

            if (!Meta.IsEmpty && (T.TableName == "geo_city_conferente") && (R != null)) {
                object idgeo = R["idcity"];
                ImpostaComuneConferente(idgeo);
            }
            if (T.TableName == "serviceregistrykind" && Meta.DrawStateIsDone) {
                ImpostaTipoIncaricato(R);
                Curr["idserviceregistrykind"] = R["idserviceregistrykind"];
                AbilitaCampidaPubblicare(R);
                EvidenziaCampiDaPubblicare(R);
                //ImpostaTipoIncaricato(R);
                if (!Meta.IsEmpty) Meta.GetFormData(true);
                if (Curr["employkind"].ToString() == "D") {
                    abilitaControlli(false); ;
                }
                else {
                    abilitaControlli(true);
                }

                //if (rdbconsulente01.Checked || rdbconsulente02.Checked) {
                //        abilita_consulente(true);
                //    }
                //if(rdbdipendente.Checked){
                //        abilita_consulente(false);
                //    }
            }

        }


        private void ImpostaTipoIncaricato(DataRow rServiceregistrykind) {
            string employkind = "";
            DataRow Curr = DS.serviceregistry.Rows[0];
            Curr["employkind"] = rServiceregistrykind["employkind"];
            employkind = Curr["employkind"].ToString();

            if (employkind == "C") {
                rdbconsulente01.Checked = true;
            }
            if (employkind == "A") {
                rdbconsulente02.Checked = true;
            }
            if (employkind == "D") {
                rdbdipendente.Checked = true;
            }
            if (rServiceregistrykind["otherservice"].ToString() != "")
                txtAltriIncarichi.Text = rServiceregistrykind["otherservice"].ToString();

            if (rServiceregistrykind["professionalservice"].ToString() != "")
                txtAttivit‡Professionali.Text = rServiceregistrykind["professionalservice"].ToString();

            if (rServiceregistrykind["componentsvariable"].ToString() != "")
                txtComponentiVariabili.Text = rServiceregistrykind["componentsvariable"].ToString();

            if (rServiceregistrykind["certinterestconflicts"].ToString() != "")
                txtattestazioneConflittiInteresse.Text = rServiceregistrykind["certinterestconflicts"].ToString();

        }
		private void RiempieOggettiCD(DataRow R) {
			txtsurname.Text= R["surname"].ToString();
			txtforename.Text=R["forename"].ToString();
			
			if  ((R["birthdate"])!= DBNull.Value &&(DateTime)R["birthdate"]!=QueryCreator.EmptyDate())
			{
				DateTime data = (DateTime)R["birthdate"];
				txtDataNascita.Text=data.ToString("d");
			}

            //if (!(chkestero.Checked)){
                txtCodiceFiscale.Text = R["cf"].ToString();
                txtPartitaIva.Text = R["p_iva"].ToString();
            //}
			string gender="";
			gender = R["gender"].ToString().ToUpper();
			if (gender =="M"){
				rdbgenderm.Checked=true;
				rdbgenderf.Checked=false;
			}
			if (gender =="F"){
				rdbgenderm.Checked = false;
				rdbgenderf.Checked = true;
			}
            string  flaghuman = Conn.DO_READ_VALUE("registryclass",QHS.CmpEq("idregistryclass",R["idregistryclass"]), "flaghuman").ToString();
             if(flaghuman=="S"){
                checkPersonafisica.Checked=true;
            }else{
                checkPersonafisica.Checked=false ;
            }
		}

        private void RiempieOggettiConferente(DataRow R) {
            txtCognomeConferente.Text = R["surname"].ToString();
            txtNomeConferente.Text = R["forename"].ToString();

            if ((R["birthdate"]) != DBNull.Value && (DateTime)R["birthdate"] != QueryCreator.EmptyDate()) {
                DateTime data = (DateTime)R["birthdate"];
                txtDatanascitaConferente.Text = data.ToString("d");
            }

            txtCFconferente.Text = R["cf"].ToString();
            txtPivaConferente.Text = R["p_iva"].ToString();

            string gender = "";
            gender = R["gender"].ToString().ToUpper();
            if (gender == "M") {
                rdbGenderMCoferente.Checked = true;
                rdbGenderFCoferente.Checked = false;
            }
            if (gender == "F") {
                rdbGenderMCoferente.Checked = false;
                rdbGenderFCoferente.Checked = true;
            }
        }

		void ConsentiElimina(bool elimina) 
		{
			Meta.CanCancel = elimina;
			Meta.FreshToolBar();
		}

		private void gestioneFlag() 
		{
		    if (Meta.IsEmpty) {
		        //abilitaGruppi(true);
		        return;
		    }

            bool annullato = (chkis_annulled.CheckState==CheckState.Checked || chkwebSite_annulled.CheckState==CheckState.Checked); 
			if 	(chkblocked.Checked){
				abilitaGruppi(false);
				ConsentiElimina(false); 
				chkis_annulled.Enabled = false;
				chkischanged.Enabled=false;
				chkisdelivery.Enabled=false;
                chkwebSite_annulled.Enabled = false;

				return;
			}

			if (chkisdelivery.Checked)
			{
				ConsentiElimina(false);
                if (annullato && chkisdelivery.Checked)	
				{// Se Tx e Ax : disabilita Ax e Mx.
					chkis_annulled.Enabled=false;
                    chkwebSite_annulled.Enabled = false;
					chkischanged.Enabled=false;				
				}
				else
				{// Se Tx abilita Ax e Mx perchË puoi Ax e Mx.
                    chkis_annulled.Enabled = !chkwebSite_annulled.Checked;
                    chkwebSite_annulled.Enabled = !chkis_annulled.Checked;
                    chkischanged.Enabled = !annullato;				
				}

                if (chkischanged.Checked && !annullato)
				{
					// Se Tx e Mx abilita i gruppi.
					abilitaGruppi(true);
				}
				else
				{//  Se Tx e non vuoi modificare disabilita tutto.
					abilitaGruppi(false);
				}
			}
			else // Se non Ë Tx abilita tutti i gruppi 
			{	//	I Mx e Ax sono disabilitati in fase di inserimento, altrimenti sono abilitati
                abilitaGruppi(!annullato);
                ConsentiElimina(!annullato);
                chkischanged.Enabled = chkischanged.Checked;//!chkis_annulled.Checked;
                chkis_annulled.Enabled = false;
                chkwebSite_annulled.Enabled = true;
			}
		}
		private void abilitaGruppi(bool abilita) 
		{
			grpincaricato.Enabled = abilita;
			grbincarico.Enabled = abilita;
			grbconferente.Enabled = abilita;
            grpPubblicazione.Enabled = abilita;
            grpAnagraficaConferente.Enabled = abilita;
            cmbtipologiaconferente.Enabled = abilita;
            btnTipologiaConferente.Enabled = abilita;
            GBoxPagamento.Enabled = abilita;

        }

        private void txtstart_TextChanged(object sender, System.EventArgs e){
        }

        void calcolaSemestre(){
            //if (txtsemestreriferimento.Text != "")return;

            object Affidamento = HelpForm.GetObjectFromString(typeof(DateTime), txtDataAffidamento.Text, txtDataAffidamento.Tag.ToString());
            if (Affidamento is DateTime) {
                DateTime dataAffidamento = (DateTime)Affidamento;
                int mese = dataAffidamento.Month;
                if (mese <= 6){
                    txtsemestreriferimento.Text = "1";
                }
                else{
                    txtsemestreriferimento.Text = "2";
                }
            }
        }

        void VerificaCoerenzaEsercizio(string kind){
            if (txteser.Text == "") return;
            if ((kind=="C") && (txtDataAffidamento.Text.ToString()=="" )) return;
            if ((kind == "D") && (txtDataautorizzazione.Text.ToString() == "")) return;

            int Esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            HelpForm.FormatLikeYear(txteser);

            
            if (txteser.Text.ToString() != "") {
                int anno;
                if (Int32.TryParse(txteser.Text, out anno)) {
                    Esercizio = anno;
                }
            }

            if (kind == "C") {
                object riferimento = HelpForm.GetObjectFromString(typeof(DateTime), txtDataAffidamento.Text, txtDataAffidamento.Tag.ToString());
                if (riferimento is DateTime) {
                    DateTime dataRiferimento = (DateTime)riferimento;
                    int Anno = dataRiferimento.Year;
                    if (Anno != Esercizio) {
                        MessageBox.Show(this, "L'anno di Affidamento deve essere uguale all'esercizio incarico.");
                    }
                }
            }
            // D
            else {
                object riferimento = HelpForm.GetObjectFromString(typeof(DateTime), txtDataautorizzazione.Text, txtDataautorizzazione.Tag.ToString());
                if (riferimento is DateTime) {
                    DateTime dataRiferimento = (DateTime)riferimento;
                    int Anno = dataRiferimento.Year;
                    if (Anno != Esercizio) {
                        MessageBox.Show(this, "L'anno di Conferimento/Autorizzazione deve essere uguale all'esercizio incarico.");
                    }
                }
            }
        }

        // La gestione Ë stata spostata nel MetaDato
        //public void CalcolaValorizzaidMittente(){
        //    // idmittente = yservreg[4] + nservreg[5] + license.iddb[5]
        //    if (DS.serviceregistry.Rows.Count == 0){
        //        return;
        //    }
        //    DataRow Curr = DS.serviceregistry.Rows[0];
        //    if (Curr.RowState == DataRowState.Deleted) {
        //        return;
        //    }

        //    DataTable Tlicense = Meta.Conn.RUN_SELECT("license", "*", null, null, null, true);
        //    object iddb = Tlicense.Rows[0]["iddb"];

        //    string idMittente = Curr["yservreg"].ToString() + Curr["nservreg"].ToString().PadLeft(5, '0') + iddb.ToString().PadLeft(5, '0');
        //    Curr["senderreporting"] = idMittente;
        //    txtIdMittente.Text = idMittente;
        //}

        

		public void MetaData_AfterFill() {
			if (Meta.IsEmpty) return;

			txtidservice.Enabled = false;
			chkisdelivery.Enabled = false;
			chkblocked.Enabled = false;
		
			txtsurname.Enabled = false;
			txtforename.Enabled= false;
			txtCodiceFiscale.Enabled =false;
			txtDataNascita.Enabled =false;
			txtPartitaIva.Enabled =false;
			rdbgenderm.Enabled =false;
			rdbgenderf.Enabled =false;
			if (Meta.InsertMode || Meta.EditMode){
				if (DS.serviceregistry.Rows.Count == 0) return;
				DataRow Curr = DS.serviceregistry.Rows[0];
				
				lblincaricoblocato.Visible = (Curr["is_blocked"].ToString().ToUpper()=="S"?true:false);

                AbilitaCodiciValidi();
				if (Curr["employkind"] == DBNull.Value) return;

                if (Curr["employkind"].ToString().ToUpper() == "D") {
                    abilitaControlli(false);
                }
                else {
                    abilitaControlli(true);
                }
			}
            AbilitaRiferimentoNormativo();
            if (Meta.InsertMode){
                if (DS.serviceregistry.Rows.Count == 0) return;
                RicavaComuneDaIdreg("I");
                RicavaComuneDaIdreg("C");
            }
            VisualizzaStatoCV();
            gestioneFlag();
            txtBozza.Visible = false;
            if (!Meta.InsertMode) {
                if (DS.serviceregistry.Rows.Count == 0)
                    return;
                DataRow Curr = DS.serviceregistry.Rows[0];
                if (Curr["employkind"] == DBNull.Value) return;
                // Se Ë un Dipendete visualizza o meno l'etichetta Bozza a seconda che sia valorizzata data Conferimento
                if (Curr["employkind"].ToString().ToUpper() == "D") {
                    if (Curr["authorizationdate"] == DBNull.Value) {
                        txtBozza.Visible = true;
                    }
                }
            }
            AggiornamentoSaldoIncarico();
		}

        private void AggiornamentoSaldoIncarico(){
            if (Meta.IsEmpty) return;
            if (DS.serviceregistry.Rows.Count == 0)
                return;
            if (DS.servicepayment.Rows.Count == 0)
                return;
            if (rdbSaldatoSi.Checked) return;
            if (chkblocked.Checked) return;
            DataRow Curr = DS.serviceregistry.Rows[0];
            decimal expectedamount = CfgFn.GetNoNullDecimal(Curr["expectedamount"]);
            foreach (DataRow P in DS.servicepayment.Select()) {
                expectedamount = expectedamount - CfgFn.GetNoNullDecimal(P["payedamount"]);
                }
            if (expectedamount == 0) {
                if (MessageBox.Show("Aggiorno il campo Incarico Saldato ponendolo uguale a SÏ?",
                  "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                    rdbSaldatoSi.Checked = true;
                    Curr["is_changed"] = "S";
                }
            }
        }
        private void VisualizzaStatoCV() {
            if (DS.serviceregistry.Rows.Count == 0) return;
            bool CVObbligatorio = false;
			DataRow Curr = DS.serviceregistry.Rows[0];
            object idreg = Curr["idreg"];
            if (idreg == DBNull.Value) {
                lblStatoCV.Text = "";
                return;
            }
            int idserviceregistrykind = CfgFn.GetNoNullInt32(Curr["idserviceregistrykind"]);
            if (idserviceregistrykind != 0) {
                string filtersrk = QHC.CmpEq("idserviceregistrykind", Curr["idserviceregistrykind"]);
                
                if (DS.serviceregistrykind.Select(filtersrk).Length > 0) {
                    DataRow  row_serviceregistrykind = DS.serviceregistrykind.Select(filtersrk)[0];
                    byte flagcvattachment = CfgFn.GetNoNullByte(row_serviceregistrykind["flagcvattachment"]);
                    if ((flagcvattachment & 2) != 0) {
                        //Obbligatorio
                        CVObbligatorio = true;
                    }
                }
            }

            object maxreferencedate;
            maxreferencedate = Meta.Conn.DO_READ_VALUE("registrycvattachment", QHS.CmpEq("idreg", idreg), "max(referencedate)");
            if (maxreferencedate == DBNull.Value) {
                lblStatoCV.Text = "Per l'incaricato indicato non Ë stato inserito alcun Curriculum Vitae nella relativa scheda Anagrafica";
                if (CVObbligatorio) {
                    MessageBox.Show("La Tipologia Incarico scelta, prevede la presenza del CV dell'incaricato. Inserirlo nella scheda Anagrafica.");
                }
            }
            else{
                lblStatoCV.Text="Per l'incaricato indicato il Curriculum Vitae, nella relativa scheda Anagrafica, Ë aggiornato al "
                    + HelpForm.StringValue(maxreferencedate, null);
            }
     
            
        }

        private void AbilitaCodiciValidi()
        {
            QHS = Meta.Conn.GetQueryHelper();
            string filtrobtn_ayear = "";
            string filtrocmb_ayear = "";
            int anno=0;
            if (txteser.Text.ToString()!=""){
                HelpForm.FormatLikeYear(txteser);
               
                if (Int32.TryParse(txteser.Text, out anno)) {
                    filtrobtn_ayear = "." + QHS.CmpEq("ayear",anno);
                    filtrocmb_ayear = QHS.CmpEq("ayear", anno);
                }

            }
            string filtro_active = "";
            //TipoRapporto
            btnTiporapporto.Tag = "manage.apcontractkind.default" + filtrobtn_ayear;
            DS.apcontractkind.Clear();
            cmbtiporapporto.DataSource = null;
            filtro_active = QHS.AppAnd(filtrocmb_ayear, QHS.CmpEq("active", "S"));
            GetData.Add_Blank_Row(DS.apcontractkind);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.apcontractkind, null, filtro_active, null, true);
            cmbtiporapporto.DataSource = DS.apcontractkind;
            cmbtiporapporto.DisplayMember = "description";
            cmbtiporapporto.ValueMember = "idapcontractkind";
            Meta.myHelpForm.PreFillControlsTable(cmbtiporapporto, null);
            if (DS.serviceregistry.Rows.Count > 0){
                HelpForm.SetComboBoxValue(cmbtiporapporto,DS.serviceregistry.Rows[0]["idapcontractkind"]);
                    }

            //Formacontrattuale
            btnmodacquisizione.Tag = "manage.acquirekind.default" + filtrobtn_ayear;
            DS.acquirekind.Clear();
            cmbmodacquisizione.DataSource = null;
            filtro_active = QHS.AppAnd(filtrocmb_ayear, QHS.CmpEq("active", "S"));
            GetData.Add_Blank_Row(DS.acquirekind);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.acquirekind, null, filtro_active, null, true);
            cmbmodacquisizione.DataSource = DS.acquirekind;
            cmbmodacquisizione.DisplayMember = "description";
            cmbmodacquisizione.ValueMember = "idacquirekind";
            Meta.myHelpForm.PreFillControlsTable(cmbmodacquisizione, null);
            if (DS.serviceregistry.Rows.Count > 0){
                HelpForm.SetComboBoxValue(cmbmodacquisizione,DS.serviceregistry.Rows[0]["idacquirekind"]);
            }
      
            //Attivit‡Economica
            btnattivitaeconomica.Tag = "manage.financialactivity.default" + filtrobtn_ayear;
            DS.financialactivity.Clear();
            cmbattivitaeconomica.DataSource = null;
            filtro_active = QHS.AppAnd(filtrocmb_ayear, QHS.CmpEq("active", "S"));
            GetData.Add_Blank_Row(DS.financialactivity);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.financialactivity, null, filtro_active, null, true);
            cmbattivitaeconomica.DataSource = DS.financialactivity;
            cmbattivitaeconomica.DisplayMember = "description";
            cmbattivitaeconomica.ValueMember = "idfinancialactivity";
            Meta.myHelpForm.PreFillControlsTable(cmbattivitaeconomica, null);
            if (DS.serviceregistry.Rows.Count > 0){
                HelpForm.SetComboBoxValue(cmbattivitaeconomica,DS.serviceregistry.Rows[0]["idfinancialactivity"]);
            }

            // Tipologia CONSULENTE >> diventa>> Tipologia SOCIETA' 
            btnTipologiaSocieta.Tag = "manage.consultingkind.default" + filtrobtn_ayear;
            DS.consultingkind.Clear();
            cmbTipologiaSocieta.DataSource = null;
            filtro_active = QHS.AppAnd(filtrocmb_ayear, QHS.CmpEq("active", "S"));
            GetData.Add_Blank_Row(DS.consultingkind);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.consultingkind, null, filtro_active, null, true);
            cmbTipologiaSocieta.DataSource = DS.consultingkind;
            cmbTipologiaSocieta.DisplayMember = "description";
            cmbTipologiaSocieta.ValueMember = "idconsultingkind";
            Meta.myHelpForm.PreFillControlsTable(cmbTipologiaSocieta, null);
            if (DS.serviceregistry.Rows.Count > 0){
                HelpForm.SetComboBoxValue(cmbTipologiaSocieta, DS.serviceregistry.Rows[0]["idconsultingkind"]);
            }

            // Qualifica 
            btnqualifica.Tag = "manage.apmanager.default" + filtrobtn_ayear;
            DS.apmanager.Clear();
            cmbQualifica.DataSource = null;
            filtro_active = QHS.AppAnd(filtrocmb_ayear, QHS.CmpEq("active", "S"));
            GetData.Add_Blank_Row(DS.apmanager);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.apmanager, null, filtro_active, null, true);
            cmbQualifica.DataSource = DS.apmanager;
            cmbQualifica.DisplayMember = "description";
            cmbQualifica.ValueMember = "idapmanager";
            Meta.myHelpForm.PreFillControlsTable(cmbQualifica, null);
            if (DS.serviceregistry.Rows.Count > 0){
                HelpForm.SetComboBoxValue(cmbQualifica, DS.serviceregistry.Rows[0]["idapmanager"]);
            }

            // Tipologia Conferente 
            btnTipologiaConferente.Tag = "manage.apregistrykind.default" + filtrobtn_ayear;
            DS.apregistrykind.Clear();
            cmbtipologiaconferente.DataSource = null;
            filtro_active = QHS.AppAnd(filtrocmb_ayear, QHS.CmpEq("active", "S"));
            GetData.Add_Blank_Row(DS.apregistrykind);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.apregistrykind, null, filtro_active, null, true);
            cmbtipologiaconferente.DataSource = DS.apregistrykind;
            cmbtipologiaconferente.DisplayMember = "description";
            cmbtipologiaconferente.ValueMember = "idapregistrykind";
            Meta.myHelpForm.PreFillControlsTable(cmbtipologiaconferente, null);
            if (DS.serviceregistry.Rows.Count > 0){
                HelpForm.SetComboBoxValue(cmbtipologiaconferente, DS.serviceregistry.Rows[0]["idapregistrykind"]);
            }

            // Tipologia Incarico
            btntipologiaincaricato.Tag = "manage.apactivitykind.default" + filtrobtn_ayear;
            DS.apactivitykind.Clear();
            cmbtipologiaincarico.DataSource = null;
            filtro_active = QHS.AppAnd(filtrocmb_ayear, QHS.CmpEq("active", "S"));
            GetData.Add_Blank_Row(DS.apactivitykind);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.apactivitykind, null, filtro_active, null, true);
            cmbtipologiaincarico.DataSource = DS.apactivitykind;
            cmbtipologiaincarico.DisplayMember = "description";
            cmbtipologiaincarico.ValueMember = "idapactivitykind";
            Meta.myHelpForm.PreFillControlsTable(cmbtipologiaincarico, null);
            if (DS.serviceregistry.Rows.Count > 0){
                HelpForm.SetComboBoxValue(cmbtipologiaincarico, DS.serviceregistry.Rows[0]["idapactivitykind"]);
            }


            int Esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            if (anno!=0){
                Esercizio = anno;
            }
            // Nel 2011 l'attivit‡ econominca diventa una gerarchia, quindi viene gestista con un'altra tabella:
            // esercizio < 2011 attivitaEconomica = idfinancialactivity
            // esercizio >= 2011 attivitaEconomica = idspfinancialactivity
            grpAttivitaEconomica.Enabled = ((rdbconsulente01.Checked || rdbconsulente02.Checked) && (Esercizio >= 2011));
            cmbattivitaeconomica.Enabled = ((rdbconsulente01.Checked || rdbconsulente02.Checked) && (Esercizio <= 2012));
            btnattivitaeconomica.Enabled = ((rdbconsulente01.Checked || rdbconsulente02.Checked) && (Esercizio <= 2012));

            if (Esercizio >= 2011){
                // Non la devo svuotare perchË mi serve come riferimento per valorizzare la nuova
                //if (cmbattivitaeconomica.SelectedIndex > 0){
                //    cmbattivitaeconomica.SelectedIndex = -1;
                //}
                //if ((!MetaData.Empty(this))){
                //    DS.serviceregistry.Rows[0]["idfinancialactivity"] = DBNull.Value;
                //}
            }
            else{
                txtIdAttivitaEconomica.Text = "";
                txtDescAttivitaEconomica.Text = "";
                if ((!MetaData.Empty(this))){
                    DS.serviceregistry.Rows[0]["idapfinancialactivity"] = DBNull.Value;
                   }
            }


        }


        private void ImpostaComune(object idComune) {
			object	codice = 0;	
			object maxversion;
			string filter1 = QHS.AppAnd(QHS.CmpEq("idcity", idComune), QHS.CmpEq("idagency", 1), QHS.CmpEq("idcode", 1));
			maxversion = Meta.Conn.DO_READ_VALUE("geo_city_agency", filter1, "max(version)");
			if (maxversion!= DBNull.Value){
				string filter2 = QHS.CmpEq("version", maxversion);
				string filter= GetData.MergeFilters(filter1,filter2);
				object o = Meta.Conn.DO_READ_VALUE("geo_city_agency", filter, "value");
				if (o != null){
						codice = o;
                        DS.serviceregistry.Rows[0]["codcity"] = codice;
                        DS.serviceregistry.Rows[0]["idcity"] = idComune;
                        txtGeoComune.Text = ricavaDenominazioneComune(idComune);
                        //if (DS.geo_city.Rows.Count > 0){
                        //    txtGeoComune.Text = DS.geo_city.Rows[0]["title"].ToString();
                        //}
                        //else{
                        //    txtGeoComune.Text=ricavaDenominazioneComune(idComune);
                        //}
					}
			}
			else{
				MessageBox.Show("Il Comune Sede selezionato non Ë valido");
				txtGeoComune.Text="";
				if ((!MetaData.Empty(this))){
					DS.serviceregistry.Rows[0]["idcity"]=DBNull.Value;
                    DS.serviceregistry.Rows[0]["codcity"] = DBNull.Value;
				}
				
			}
		}
        private void ImpostaComuneConferente(object idComune) {
            object codice = 0;
            object maxversion;
            string filter1 = QHS.AppAnd(QHS.CmpEq("idcity", idComune), QHS.CmpEq("idagency", 1), QHS.CmpEq("idcode", 1));
            maxversion = Meta.Conn.DO_READ_VALUE("geo_city_agency", filter1, "max(version)");
            if (maxversion != DBNull.Value) {
                string filter2 = QHS.CmpEq("version", maxversion);
                string filter = GetData.MergeFilters(filter1, filter2);
                object o = Meta.Conn.DO_READ_VALUE("geo_city_agency", filter, "value");
                if (o != null) {
                    codice = o;
                    DS.serviceregistry.Rows[0]["conferring_codcity"] = codice;
                    DS.serviceregistry.Rows[0]["conferring_idcity"] = idComune;
                    txtGeoComuneConferente.Text = ricavaDenominazioneComune(idComune);
                    //if (DS.geo_city_conferente.Rows.Count > 0) {
                    //    txtGeoComuneConferente.Text = DS.geo_city_conferente.Rows[0]["title"].ToString();
                    //}
                    //else {
                    //    txtGeoComuneConferente.Text = ricavaDenominazioneComune(idComune);
                    //}
                }
            }
            else {
                MessageBox.Show("Il Comune Sede selezionato non Ë valido");
                txtGeoComune.Text = "";
                if ((!MetaData.Empty(this))) {
                    DS.serviceregistry.Rows[0]["conferring_idcity"] = DBNull.Value;
                    DS.serviceregistry.Rows[0]["conferring_codcity"] = DBNull.Value;
                }

            }
        }

        private void EvidenziaCampiDaPubblicare(DataRow R) {
             if (ToPublish() != "S") return;

                byte flagconferringstructure = 0;
                flagconferringstructure = CfgFn.GetNoNullByte(R["flagconferringstructure"]);
                if ((flagconferringstructure & 2) != 0) {
                    lblStrutturaConferente.Text = "Struttura Conferente (*)";
                    lblStrutturaConferente.ForeColor = System.Drawing.Color.Red;
                }
                else {
                    lblStrutturaConferente.Text = "Struttura Conferente";
                    lblStrutturaConferente.ForeColor = System.Drawing.SystemColors.ControlText;

                }

                byte flagordinancelink = 0;
                flagordinancelink = CfgFn.GetNoNullByte(R["flagordinancelink"]);
                if ((flagordinancelink & 2) != 0) {
                    lblLinkDecreto.Text = "Link al decreto di conferimento dellíincarico (*)";
                    lblLinkDecreto.ForeColor = System.Drawing.Color.Red;
                }
                else {
                    lblLinkDecreto.Text = "Link al decreto di conferimento dellíincarico";
                    lblLinkDecreto.ForeColor = System.Drawing.SystemColors.ControlText; 
                }

                byte flagauthorizingstructure = 0;
                flagauthorizingstructure = CfgFn.GetNoNullByte(R["flagauthorizingstructure"]);
                if ((flagauthorizingstructure & 2) != 0) {
                    lblStrutturacheAutorizza.Text = "Struttura che autorizza (*)";
                    lblStrutturacheAutorizza.ForeColor = System.Drawing.Color.Red;
                }
                else {
                    lblStrutturacheAutorizza.Text = "Struttura che autorizza";
                    lblStrutturacheAutorizza.ForeColor = System.Drawing.SystemColors.ControlText; 
                }

                byte flagauthorizinglink = 0;
                flagauthorizinglink = CfgFn.GetNoNullByte(R["flagauthorizinglink"]);
                if ((flagauthorizinglink & 2) != 0) {
                    lblLinkAutorizzazione.Text = "Link allíatto di autorizzazione (*)";
                    lblLinkAutorizzazione.ForeColor = System.Drawing.Color.Red;
                }
                else {
                    lblLinkAutorizzazione.Text = "Link allíatto di autorizzazione";
                    lblLinkAutorizzazione.ForeColor = System.Drawing.SystemColors.ControlText;
                }

                byte flagactreference = 0;
                flagactreference = CfgFn.GetNoNullByte(R["flagactreference"]);
                if ((flagactreference & 2) != 0) {
                    lblRifAttoConferimento.Text = "Riferimento dellíatto di conferimento (*)";
                    lblRifAttoConferimento.ForeColor = System.Drawing.Color.Red;
                }
                else {
                    lblRifAttoConferimento.Text = "Riferimento dellíatto di conferimento";
                    lblRifAttoConferimento.ForeColor = System.Drawing.SystemColors.ControlText;
                }

                byte flagannouncementlink = 0;
                flagannouncementlink = CfgFn.GetNoNullByte(R["flagannouncementlink"]);
                if ((flagannouncementlink & 2) != 0) {
                    lblLinkBando.Text = "Link al bando (*)";
                    lblLinkBando.ForeColor=System.Drawing.Color.Red;
                }
                else{
                    lblLinkBando.Text = "Link al bando";
                    lblLinkBando.ForeColor=System.Drawing.SystemColors.ControlText;
                }

                byte flagotherservice = 0;
                flagotherservice = CfgFn.GetNoNullByte(R["flagotherservice"]);
                if ((flagotherservice & 2) != 0){
                    lblAltriCarichi.Text = "Altri incarichi o cariche in enti di diritto privato finanziati da P.A. (*)";
                    lblAltriCarichi.ForeColor=System.Drawing.Color.Red;
                }
                else{
                    lblAltriCarichi.Text = "Altri incarichi o cariche in enti di diritto privato finanziati da P.A.";
                    lblAltriCarichi.ForeColor=System.Drawing.SystemColors.ControlText;
                }

                byte flagprofessionalservice = 0;
                flagprofessionalservice = CfgFn.GetNoNullByte(R["flagprofessionalservice"]);
                if ((flagprofessionalservice & 2) != 0) {
                    lblAttivit‡Professionali.Text = "Eventuali attivit‡ professionali (*)";
                    lblAttivit‡Professionali.ForeColor=System.Drawing.Color.Red;
                }
            else {
                    lblAttivit‡Professionali.Text = "Eventuali attivit‡ professionali";
                    lblAttivit‡Professionali.ForeColor=System.Drawing.SystemColors.ControlText;
                }

                byte flagcomponentsvariable = 0;
                flagcomponentsvariable = CfgFn.GetNoNullByte(R["flagcomponentsvariable"]);
                if ((flagcomponentsvariable & 2) != 0) {
                    lblComponentiVariabili.Text = "Eventuali componenti variabili del compenso (*)";
                    lblComponentiVariabili.ForeColor=System.Drawing.Color.Red;
                }
            else{
                    lblComponentiVariabili.Text = "Eventuali componenti variabili del compenso";
                    lblComponentiVariabili.ForeColor=System.Drawing.SystemColors.ControlText;
                }

            byte flagemploytime = 0;
                flagemploytime = CfgFn.GetNoNullByte(R["flagemploytime"]);
                if ((flagemploytime & 2) != 0) {
                    lblDurataIncarico.Text = "Durata incarico (*)";
                    lblDurataIncarico.ForeColor=System.Drawing.Color.Red;
                }
            else{
                    lblDurataIncarico.Text = "Durata incarico";
                    lblDurataIncarico.ForeColor=System.Drawing.SystemColors.ControlText;
                }

                byte flagcertinterestconflicts = 0;
                flagcertinterestconflicts = CfgFn.GetNoNullByte(R["flagcertinterestconflicts"]);
                if ((flagcertinterestconflicts & 2) != 0) {
                    lblAttestazioneConflittiInteresse.Text = "Attestazione conflitti di interesse (*)";
                    lblAttestazioneConflittiInteresse.ForeColor = System.Drawing.Color.Red;
                }
            else {
                    lblAttestazioneConflittiInteresse.Text = "Attestazione conflitti di interesse";
                    lblAttestazioneConflittiInteresse.ForeColor = System.Drawing.SystemColors.ControlText;
                }


        }
        private void AbilitaCampidaPubblicare(DataRow R) {
            byte flagconferringstructure = 0;
            flagconferringstructure = CfgFn.GetNoNullByte(R["flagconferringstructure"]);
            if((flagconferringstructure & 1) != 0){
                //Visibile
                lblStrutturaConferente.Visible=true;
                txtStrutturaConferente.Visible=true;

            }
            else {
            if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["conferringstructure"] != DBNull.Value) {
                lblStrutturaConferente.Visible = true;
                txtStrutturaConferente.Visible = true;
                }
                else{
                lblStrutturaConferente.Visible = false;
                txtStrutturaConferente.Visible = false;
                }
            }
            /*
             * 
Riferimento dellíatto di conferimento(actreference)
Link al bando(announcementlink)
Curriculum Vitae(flagcvattachment)
Altri incarichi o cariche in enti di diritto privato finanziati da P.A.( otherservice)
Eventuali attivit‡ professionali(professionalservice)
Componenti variabili del compenso(componentsvariable)
             * */

            byte flagordinancelink = 0;
            flagordinancelink = CfgFn.GetNoNullByte(R["flagordinancelink"]);
            if ((flagordinancelink & 1) != 0) {
                //Visibile
                lblLinkDecreto.Visible = true;
                txtLinkDecreto.Visible = true;

            }
            else {
            if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["ordinancelink"] != DBNull.Value) {
                lblLinkDecreto.Visible = true;
                txtLinkDecreto.Visible = true;
                }
            else {
                lblLinkDecreto.Visible = false;
                txtLinkDecreto.Visible = false;
                }
            }

            byte flagauthorizingstructure = 0;
            flagauthorizingstructure = CfgFn.GetNoNullByte(R["flagauthorizingstructure"]);
            if ((flagauthorizingstructure & 1) != 0) {
                //Visibile
                lblStrutturacheAutorizza.Visible = true;
                txtStrutturacheAutorizza.Visible = true;

            }
            else {
                lblStrutturacheAutorizza.Visible = false;
                txtStrutturacheAutorizza.Visible = false;
                if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["authorizingstructure"] != DBNull.Value) {
                    lblStrutturacheAutorizza.Visible = true;
                    txtStrutturacheAutorizza.Visible = true;
                    }
                else {
                    lblStrutturacheAutorizza.Visible = false;
                    txtStrutturacheAutorizza.Visible = false;
                }
            }

            byte flagauthorizinglink = 0;
            flagauthorizinglink = CfgFn.GetNoNullByte(R["flagauthorizinglink"]);
            if ((flagauthorizinglink & 1) != 0) {
                //Visibile
                lblLinkAutorizzazione.Visible = true;
                txtLinkAutorizzazione.Visible = true;

            }
            else {
                lblLinkAutorizzazione.Visible = false;
                txtLinkAutorizzazione.Visible = false;
                if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["authorizinglink"] != DBNull.Value) {
                    lblLinkAutorizzazione.Visible = true;
                    txtLinkAutorizzazione.Visible = true;
                    }
                else {
                    lblLinkAutorizzazione.Visible = false;
                    txtLinkAutorizzazione.Visible = false;
                }
            }

            byte flagactreference = 0;
            flagactreference = CfgFn.GetNoNullByte(R["flagactreference"]);
            if ((flagactreference & 1) != 0) {
                //Visibile
                lblRifAttoConferimento.Visible = true;
                txtRifAttoConferimento.Visible = true;

            }
            else {
                lblRifAttoConferimento.Visible = false;
                txtRifAttoConferimento.Visible = false;
                if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["actreference"] != DBNull.Value) {
                    lblRifAttoConferimento.Visible = true;
                    txtRifAttoConferimento.Visible = true;
                    }
                else {
                    lblRifAttoConferimento.Visible = false;
                    txtRifAttoConferimento.Visible = false;
                }
            }

            byte flagannouncementlink = 0;
            flagannouncementlink = CfgFn.GetNoNullByte(R["flagannouncementlink"]);
            if ((flagannouncementlink & 1) != 0) {
                //Visibile
                lblLinkBando.Visible = true;
                txtLinkBando.Visible = true;

            }
            else {
                lblLinkBando.Visible = false;
                txtLinkBando.Visible = false;
                if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["announcementlink"] != DBNull.Value) {
                    lblLinkBando.Visible = true;
                    txtLinkBando.Visible = true;
                    }
                else {
                    lblLinkBando.Visible = false;
                    txtLinkBando.Visible = false;
                    }
            }

            byte flagotherservice = 0;
            flagotherservice = CfgFn.GetNoNullByte(R["flagotherservice"]);
            if ((flagotherservice & 1) != 0) {
                //Visibile
                lblAltriCarichi.Visible = true;
                txtAltriIncarichi.Visible = true;

            }
            else {
                lblAltriCarichi.Visible = false;
                txtAltriIncarichi.Visible = false;
                if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["otherservice"] != DBNull.Value) {
                    lblAltriCarichi.Visible = true;
                    txtAltriIncarichi.Visible = true;
                    }
                else {
                    lblAltriCarichi.Visible = false;
                    txtAltriIncarichi.Visible = false;                    
                }
            }

            byte flagprofessionalservice = 0;
            flagprofessionalservice = CfgFn.GetNoNullByte(R["flagprofessionalservice"]);
            if ((flagprofessionalservice & 1) != 0) {
                //Visibile
                lblAttivit‡Professionali.Visible = true;
                txtAttivit‡Professionali.Visible = true;

            }
            else {
                lblAttivit‡Professionali.Visible = false;
                txtAttivit‡Professionali.Visible = false;
                if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["professionalservice"] != DBNull.Value) {
                    lblAttivit‡Professionali.Visible = true;
                    txtAttivit‡Professionali.Visible = true;
                    }
                else {
                    lblAttivit‡Professionali.Visible = false;
                    txtAttivit‡Professionali.Visible = false;                    
                }
            }
            byte flagcomponentsvariable = 0;
            flagcomponentsvariable = CfgFn.GetNoNullByte(R["flagcomponentsvariable"]);
            if ((flagcomponentsvariable & 1) != 0) {
                //Visibile
                lblComponentiVariabili.Visible = true;
                txtComponentiVariabili.Visible = true;

            }
            else {
                lblComponentiVariabili.Visible = false;
                txtComponentiVariabili.Visible = false;
                if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["componentsvariable"] != DBNull.Value) {
                    lblComponentiVariabili.Visible = true;
                    txtComponentiVariabili.Visible = true;
                    }
                else {
                    lblComponentiVariabili.Visible = false;
                    txtComponentiVariabili.Visible = false;                   
                }
            }

            byte flagemploytime = 0;
            flagemploytime = CfgFn.GetNoNullByte(R["flagemploytime"]);
            if ((flagemploytime & 1) != 0) {
                //Visibile
                lblDurataIncarico.Visible = true;
                txtDurataIncarico.Visible = true;

            }
            else {
                lblDurataIncarico.Visible = false;
                txtDurataIncarico.Visible = false;
                if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["employtime"] != DBNull.Value) {
                    lblDurataIncarico.Visible = true;
                    txtDurataIncarico.Visible = true;
                    }
                else {
                    lblDurataIncarico.Visible = false;
                    txtDurataIncarico.Visible = false;                    
                }
            }
            // IL CV lo mettiamo sempre visibile, per il momento
            //byte flagcvattachment = 0;
            //flagcvattachment = CfgFn.GetNoNullByte(R["flagcvattachment"]);
            //if ((flagcvattachment & 1) != 0) {
            //    //Visibile
            //}
            //else {
            //    Principale.TabPages.Remove(tabCVAllegati); 
            //    if ((!MetaData.Empty(this))) {
            //        //pulisce i child
            //        foreach (DataRow rServiceregistryattachment in DS.serviceregistryattachment.Rows) {
            //            rServiceregistryattachment.Delete();
            //        }
            //    }
            //}
            byte flagcertinterestconflicts = 0;
            flagcertinterestconflicts = CfgFn.GetNoNullByte(R["flagcertinterestconflicts"]);
            if ((flagcertinterestconflicts & 1) != 0) {
                //Visibile
                lblAttestazioneConflittiInteresse.Visible = true;
                txtattestazioneConflittiInteresse.Visible = true;

            }
            else {
                lblAttestazioneConflittiInteresse.Visible = false;
                txtattestazioneConflittiInteresse.Visible = false;
                if ((!MetaData.Empty(this)) && DS.serviceregistry.Rows[0]["certinterestconflicts"] != DBNull.Value) {
                    lblAttestazioneConflittiInteresse.Visible = true;
                    txtattestazioneConflittiInteresse.Visible = true;
                }
                else {
                    lblAttestazioneConflittiInteresse.Visible = false;
                    txtattestazioneConflittiInteresse.Visible = false;
                }
            }

       }
        
        private string ToPublish() {
            string topublish = "N";
            if ((!MetaData.Empty(this)) && (cmbTipologia.SelectedIndex >0)) {
                DataRow Curr = DS.serviceregistry.Rows[0];
                if (Curr["idserviceregistrykind"] != DBNull.Value) {
                    topublish = Meta.Conn.DO_READ_VALUE("serviceregistrykind", QHS.CmpEq("idserviceregistrykind", Curr["idserviceregistrykind"]), "topublish").ToString();
                }
            }
            return topublish;
        }
        void abilitaControlli() {
            abilitaControlli(rdbconsulente01.Checked || rdbconsulente02.Checked);
        }

        private void abilitaControlli(bool consulente)	{
            // Tipologia Societ‡ va abilitato sia per i dipendenti che per i consulenti.
            //btnTipologiaSocieta.Enabled=consulente;
            //cmbTipologiaSocieta.Enabled=consulente;
            //if (!consulente){
            //    if (cmbTipologiaSocieta.SelectedIndex >0){
            //        cmbTipologiaSocieta.SelectedIndex=-1;
            //    }
            //    if ((!MetaData.Empty(this))){
            //        DS.serviceregistry.Rows[0]["idconsultingkind"]=DBNull.Value; 
            //    }
            //}

            
            //Se la tipologia Incarico Ë Abilita alla pubblicazione dobbiamo abilitare sempre:
            //1) Ente conferente

            //if (ToPublish() == "S") {//Il controllo Ë presente nell'IsValid
            //    grpAnagraficaConferente.Enabled = true;
            //}
            //else {
            //    if (consulente) {
            //        grpAnagraficaConferente.Enabled = false;
            //    }
            //    else {
            //        grpAnagraficaConferente.Enabled = true;
            //    }
            //}
            //RIPRISTINATO col Task 4934
            if (consulente) {
                grpAnagraficaConferente.Enabled = false;
            }
            else {
                grpAnagraficaConferente.Enabled = true;
            }

            if (consulente) {
                checkPersonafisica.Enabled = true;
            }
            else {
                checkPersonafisica.Enabled = false;
                checkPersonafisica.Checked = true;
                if ((!MetaData.Empty(this))) {
                    DS.serviceregistry.Rows[0]["flaghuman"] = "S";
                }
            }

            bool abilitaSelezioneTipologiaConsulente_AziendaConferente = (checkPersonafisica.Checked == false);
            if (!Meta.IsEmpty) {
                int idapregistrykind = CfgFn.GetNoNullInt32(DS.serviceregistry.Rows[0]["idapregistrykind"]);
                if (idapregistrykind == 5 || idapregistrykind == 6) abilitaSelezioneTipologiaConsulente_AziendaConferente = true;
            }
            else {
                abilitaSelezioneTipologiaConsulente_AziendaConferente = true;
            }
            btnTipologiaSocieta.Enabled = abilitaSelezioneTipologiaConsulente_AziendaConferente;
            cmbTipologiaSocieta.Enabled = abilitaSelezioneTipologiaConsulente_AziendaConferente;

            if (consulente) {
                btnTipologiaSocieta.Text = "Tipologia Consulente";
            }
            else {
                btnTipologiaSocieta.Text = "Azienda Conferente";
            }

			btnqualifica.Enabled=!consulente;
			cmbQualifica.Enabled=!consulente;

			if (consulente){
				if (cmbQualifica.SelectedIndex >0){
					cmbQualifica.SelectedIndex=-1;
				}
				if ((!MetaData.Empty(this))){
					DS.serviceregistry.Rows[0]["idapmanager"]=DBNull.Value; 
				}
			}
            btnTipologiaConferente.Enabled = (consulente==false);
            cmbtipologiaconferente.Enabled = (consulente == false);

               
            if (consulente) {
                if (cmbtipologiaconferente.SelectedIndex > 0) {
                    cmbtipologiaconferente.SelectedIndex = -1;
                }
                if ((!MetaData.Empty(this))) {
                    DS.serviceregistry.Rows[0]["idapregistrykind"] = DBNull.Value;
                }
            }
//Se la tipologia Incarico Ë Abilita alla pubblicazione dobbiamo abilitare sempre:
//3) Oggetto dell'incarico
            if (ToPublish() == "S") {//Il controllo Ë presente nell'IsValid
                btntipologiaincaricato.Enabled = true;
                cmbtipologiaincarico.Enabled = true;
            }
            else {
                btntipologiaincaricato.Enabled = !consulente;
                cmbtipologiaincarico.Enabled = !consulente;
                if (consulente) {
                    if (cmbtipologiaincarico.SelectedIndex > 0) {
                        cmbtipologiaincarico.SelectedIndex = -1;
                    }
                    if ((!MetaData.Empty(this))) {
                        DS.serviceregistry.Rows[0]["idapactivitykind"] = DBNull.Value;
                    }
                }
            }
			cmbmodacquisizione.Enabled = consulente;
			btnmodacquisizione.Enabled = consulente;
			if (!consulente){
				if (cmbmodacquisizione.SelectedIndex >0){
					cmbmodacquisizione.SelectedIndex=-1;
				}
				if ((!MetaData.Empty(this))){
					DS.serviceregistry.Rows[0]["idacquirekind"]=DBNull.Value; 
				}
			}


            // A SEGUITO DEL TASK 6234 su disabilita il tipo rapporto nel caso in cui sia dipendente, A PRESCINDERE dal fatto che sia o meno da pubblicare

            //Se la tipologia Incarico Ë Abilita alla pubblicazione dobbiamo abilitare sempre:
            //6) Tipologia Rapporto
            //if (ToPublish() == "S") {//Il controllo Ë presente nell'IsValid
            //    cmbtiporapporto.Enabled = true;
            //    btnTiporapporto.Enabled = true;
            //}
            //else {
                cmbtiporapporto.Enabled = consulente;
                btnTiporapporto.Enabled = consulente;
                if (!consulente) {
                    if (cmbtiporapporto.SelectedIndex > 0) {
                        cmbtiporapporto.SelectedIndex = -1;
                    }
                    if ((!MetaData.Empty(this))) {
                        DS.serviceregistry.Rows[0]["idapcontractkind"] = DBNull.Value;
                    }
                }
            //}

            int Esercizio=CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            int anno = 0;
            HelpForm.FormatLikeYear(txteser);
            if (txteser.Text.ToString() != "" && Int32.TryParse(txteser.Text, out anno)) {
                Esercizio = anno;
            }

            bool abititaAttivita = ( Esercizio <= 2012);

            cmbattivitaeconomica.Enabled = consulente & abititaAttivita;
            btnattivitaeconomica.Enabled = consulente & abititaAttivita;
			if (!consulente){
				if (cmbattivitaeconomica.SelectedIndex >0){
					cmbattivitaeconomica.SelectedIndex=-1;
				}
				if ((!MetaData.Empty(this))){
					DS.serviceregistry.Rows[0]["idfinancialactivity"]=DBNull.Value; 
				}
			}

            grpAttivitaEconomica.Enabled = (consulente && (Esercizio>=2011));
            if (!consulente){
                txtIdAttivitaEconomica.Text = "";
                txtDescAttivitaEconomica.Text = "";
                if ((!MetaData.Empty(this))){
                    DS.serviceregistry.Rows[0]["idapfinancialactivity"] = DBNull.Value;
                }
            }
            
            
            ////Se la tipologia Incarico Ë Abilita alla pubblicazione dobbiamo abilitare sempre:
            ////2) Data conferimento incarico
            //if (ToPublish() == "S") {//Il controllo Ë presente nell'IsValid
            //    txtDataautorizzazione.ReadOnly = false;
            //}
            //else {
            //    txtDataautorizzazione.ReadOnly = consulente;
            //    if (consulente) {
            //        if ((!MetaData.Empty(this))) {
            //            txtDataautorizzazione.Text = "";
            //            DS.serviceregistry.Rows[0]["authorizationdate"] = DBNull.Value;
            //        }
            //    }
            //}
            // RIPRISTINATO col Task 4934
            txtDataautorizzazione.ReadOnly = consulente;
            if (consulente) {
                if ((!MetaData.Empty(this))) {
                    txtDataautorizzazione.Text = "";
                    DS.serviceregistry.Rows[0]["authorizationdate"] = DBNull.Value;
                }
            }
            

            ////Se la tipologia Incarico Ë Abilita alla pubblicazione dobbiamo abilitare sempre:
            ////5)Data affidamento
            //if (ToPublish() == "S") {//Il controllo Ë presente nell'IsValid
            //    txtDataAffidamento.ReadOnly = false;
            //}
            //else {
                txtDataAffidamento.ReadOnly = !consulente;
                if (!consulente) {
                    if ((!MetaData.Empty(this))) {
                        txtDataAffidamento.Text = "";
                        DS.serviceregistry.Rows[0]["expectationsdate"] = DBNull.Value;
                    }
                }
            //}

			chkofficeduty.Enabled=!consulente;
            chkregulation.Enabled = consulente;

            //Visto che il comune di sede Ë letto dall'anagrafica, lo valorizziamo sempre, ma lo trasmettiamo solo per i Consulenti
            
            //  Dipende da 'estero'
            txtGeoComune.ReadOnly = (chkestero.Checked);
            txtGeoComune.Enabled = !(chkestero.Checked);

            //chkestero.Enabled = consulente;
            //if (!consulente) {
            //    chkestero.Checked = false;
            //    if ((!MetaData.Empty(this))) {
            //        DS.serviceregistry.Rows[0]["flagforeign"] = DBNull.Value;
            //    }
            //}

            //if (consulente){
            //    // se Ë un Consulente dipende da 'estero'
            //    txtGeoComune.ReadOnly=(chkestero.Checked);
            //    txtGeoComune.Enabled=!(chkestero.Checked);
            //}
            //else
            //{// se Ë un Dip inibisce il comune
            //    txtGeoComune.ReadOnly=(!consulente);
            //    txtGeoComune.Enabled = consulente;
            //    if ((!MetaData.Empty(this))){
            //        DS.serviceregistry.Rows[0]["idcity"]=DBNull.Value; 
            //        DS.serviceregistry.Rows[0]["codcity"]=DBNull.Value; 
            //        txtGeoComune.Text="";
            //    }
            //}


			txtsemestreriferimento.ReadOnly= !consulente;
            // La descrizione Ë sempre editabile. Task 4934
            //txtdescription.ReadOnly=!consulente;
            //if (!consulente) {
            //    txtdescription.Text="";
            //    if ((!MetaData.Empty(this))){
            //        DS.serviceregistry.Rows[0]["description"]=DBNull.Value;
            //    }
            //}

            //txtvariaizoneincarico.ReadOnly=!consulente;
            //if (!consulente){
            //    txtvariaizoneincarico.Text="";
            //    if ((!MetaData.Empty(this))){
            //        DS.serviceregistry.Rows[0]["servicevariation"]=DBNull.Value;
            //    }
            //}

            //task 6820: si chiede che il txtRelazioneAccompagnamento sia abilitato solo per i dipendenti stesso ente
            txtRelazioneAccompagnamento.ReadOnly = consulente;
		}


		private void rdbconsulente_CheckedChanged(object sender, System.EventArgs e){
			if ((Meta!=null)&&Meta.DrawStateIsDone) {
                if (Meta.IsEmpty) return;
                if (rdbconsulente01.Checked) {
                    if (!Meta.IsEmpty) Meta.GetFormData(true);
                    abilitaControlli(true);
                }
			}
		}

		private void rdbdipendente_CheckedChanged(object sender, System.EventArgs e){
			if ((Meta!=null)&&Meta.DrawStateIsDone) {
                if (Meta.IsEmpty) return;
                if (rdbdipendente.Checked) {
                    if (!Meta.IsEmpty) Meta.GetFormData(true);
                    abilitaControlli(false);
                }
			}
		}

		private void chkestero_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkestero.Checked)
			{
				txtGeoComune.Text="";
				if ((!MetaData.Empty(this))){
					DS.serviceregistry.Rows[0]["idcity"]=DBNull.Value; 
					DS.serviceregistry.Rows[0]["codcity"]=DBNull.Value;
				}
				txtGeoComune.ReadOnly=true;
				txtGeoComune.Enabled=false;
			}
			else{
				txtGeoComune.ReadOnly=false;
				txtGeoComune.Enabled=true;
			}
		
		}

		private void chkis_annulled_CheckedChanged(object sender, System.EventArgs e)
		{
            bool annullato = (chkis_annulled.Checked || chkwebSite_annulled.Checked);

		    

            if ((Meta!=null)&&Meta.DrawStateIsDone)
			{
                if (Meta.IsEmpty) return;
                chkisdelivery.Checked = !annullato;
                chkwebSite_annulled.Checked = chkis_annulled.Checked;
				gestioneFlag();
			}
	
		}

		private void chkischanged_CheckedChanged(object sender, System.EventArgs e)
		{
			if ((Meta!=null)&&Meta.DrawStateIsDone){
				gestioneFlag();
			}
		}

        private void txteser_Leave(object sender, EventArgs e){
            AbilitaCodiciValidi();
        }

        private void AbilitaRiferimentoNormativo(){
            if (chkNormativa.Checked){
                grpRiferimentoNormativo.Enabled = true;
            }
            else{
                grpRiferimentoNormativo.Enabled = false;
                if ((!MetaData.Empty(this))){
                    txtArticoloNormativa.Text = "";
                    DS.serviceregistry.Rows[0]["article"] = DBNull.Value;
                    
                    txtNumeroNormativa.Text = "";
                    DS.serviceregistry.Rows[0]["articlenumber"] = DBNull.Value;

                    txtCommaNormativa.Text = "";
                    DS.serviceregistry.Rows[0]["paragraph"] = DBNull.Value;

                    txtDataNormativa.Text = "";
                    DS.serviceregistry.Rows[0]["referencedate"] = DBNull.Value;
                    if (cmbRiferimentoNormativo.SelectedIndex > 0){
                        cmbRiferimentoNormativo.SelectedIndex = -1;
                    }
                    DS.serviceregistry.Rows[0]["idreferencerule"] = DBNull.Value;
                }
            }
        }

        private void chkNormativa_CheckedChanged(object sender, EventArgs e){
            AbilitaRiferimentoNormativo();
            
        }

        private void CleanTxtConferente() {
            txtCognomeConferente.Text = "";
            txtNomeConferente.Text = "";
            txtCFconferente.Text = "";
            txtPivaConferente.Text = "";
            txtDatanascitaConferente.Text = "";
            rdbGenderFCoferente.Checked = false;
            rdbGenderMCoferente.Checked = false;

            DS.serviceregistry.Rows[0]["conferring_idcity"] = DBNull.Value;
            DS.serviceregistry.Rows[0]["conferring_codcity"] = DBNull.Value;
            txtGeoComuneConferente.Text = "";          
        }

        private void CleanTxtRegistry() {
            txtsurname.Text = "";
            txtforename.Text = "";
            txtCodiceFiscale.Text = "";
            txtPartitaIva.Text = "";
            txtDataNascita.Text = "";
            rdbgenderm.Checked = false;
            rdbgenderf.Checked = false;

            txtGeoComune.Text = ""; 
            DS.serviceregistry.Rows[0]["idcity"] = DBNull.Value;
            DS.serviceregistry.Rows[0]["codcity"] = DBNull.Value;
        }

        private void txtDenominazione_Leave(object sender, EventArgs e){
        }

        private void txtstop_TextChanged(object sender, System.EventArgs e){
            RicavaComuneDaIdreg("I");
        }

        //private void RicavaComuneConferenteDaIdregConferente() {
        //    if (Meta.IsEmpty) return;
        //    if (DS.serviceregistry.Rows[0]["conferring_idcity"] != DBNull.Value) return;
        //    if ((DS.serviceregistry.Rows[0]["employkind"] == DBNull.Value) || (DS.serviceregistry.Rows[0]["employkind"].ToString() != "C")) return;

        //    DateTime fineIncarico = DateTime.MaxValue;
        //    object fine = HelpForm.GetObjectFromString(typeof(DateTime), txtstop.Text, txtstop.Tag.ToString());
        //    if (fine is DateTime) {
        //        fineIncarico = (DateTime)fine;
        //    }
        //    if (fineIncarico == DateTime.MaxValue) return;
        //    int idconferring = CfgFn.GetNoNullInt32(DS.serviceregistry.Rows[0]["idconferring"]);
        //    object idComuneSede = null;
        //    idComuneSede = calcolaComuneIndirizzoValido(Meta.Conn, idconferring, fineIncarico);
        //    //txtGeoComune.Text = ricavaDenominazioneComune(idComuneSede);
        //    if ((idComuneSede != DBNull.Value) && (idComuneSede != null)) {
        //        DS.serviceregistry.Rows[0]["conferring_idcity"] = idComuneSede;
        //        ImpostaComune(idComuneSede);
        //    }
        //}

        private void RicavaComuneDaIdreg(string registrykind){
            string idcity="";
            string idregistry = "";
            string codcity = "";
            if (registrykind == "I") {
                //Incaricato
                idcity="idcity";
                idregistry = "idreg";
                codcity = "codcity";
            }else{
                //Conferente
                idcity="conferring_idcity";
                idregistry = "idconferring";
                codcity = "conferring_codcity";
            }
            if (Meta.IsEmpty) return;
            if (DS.serviceregistry.Rows[0][idcity] != DBNull.Value) return;
            // Il codice comune Sede lo valorizziamo per tutti, ma lo trasmettiamo solo per i consulenti e conferenti.
            //if ((DS.serviceregistry.Rows[0]["employkind"] == DBNull.Value) || (DS.serviceregistry.Rows[0]["employkind"].ToString() != "C")) return;
            DateTime fineIncarico;
            if (registrykind == "I") {
                fineIncarico = DateTime.MaxValue;
                object fine = HelpForm.GetObjectFromString(typeof(DateTime), txtstop.Text, txtstop.Tag.ToString());
                if (fine is DateTime) {
                    fineIncarico = (DateTime)fine;
                }
                if (fineIncarico == DateTime.MaxValue) return;
            }
            else {
                fineIncarico = (DateTime)Meta.GetSys("datacontabile");
            }

            int idreg = CfgFn.GetNoNullInt32(DS.serviceregistry.Rows[0][idregistry]);
            if (registrykind == "I") {
                chkestero.Checked = FlagEstero(Meta.Conn, idreg, fineIncarico);
                if (chkestero.Checked) {
                    DS.serviceregistry.Rows[0]["flagforeign"] = "S";
                }
                else {
                    DS.serviceregistry.Rows[0]["flagforeign"] = "N";
                }
            }
            else {
                chkEsteroConferente.Checked = FlagEstero(Meta.Conn, idreg, fineIncarico);
                if (chkEsteroConferente.Checked) {
                    DS.serviceregistry.Rows[0]["conferring_flagforeign"] = "S";
                }
                else {
                    DS.serviceregistry.Rows[0]["conferring_flagforeign"] = "N";
                }
            }
            object idComuneSede = null;
            idComuneSede = calcolaComuneIndirizzoValido(Meta.Conn, idreg, fineIncarico);
            if ((idComuneSede != DBNull.Value) && (idComuneSede != null)) {
                DS.serviceregistry.Rows[0][idcity] = idComuneSede;
                if (registrykind == "I") {
                    ImpostaComune(idComuneSede);
                }
                else {
                    ImpostaComuneConferente(idComuneSede);
                }
            }
            else {
                DS.serviceregistry.Rows[0][idcity] = DBNull.Value;
                DS.serviceregistry.Rows[0][codcity] = DBNull.Value;
                if (registrykind == "I") {
                    txtGeoComune.Text = "";
                }
                else {
                    txtGeoComuneConferente.Text = "";
                }
            }
        }

        
        static public object calcolaComuneIndirizzoValido(DataAccess Conn, int idreg, DateTime date){
            QueryHelper QHS = Conn.GetQueryHelper();

            if (date == QueryCreator.EmptyDate()) return null;
            // Verifico esistenza di un domicilio fiscale alla data di riferimento
            object idDomFiscale = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");
            object idResidenza = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");

            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("idaddresskind", idDomFiscale),
                            "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + QHS.quote(date) + "))");
            object idComune = Conn.DO_READ_VALUE("registryaddress", filter, "idcity");
            idComune = trovaComuneAttuale(Conn, idComune);
            if ((idComune == DBNull.Value) || (idComune == null)){
                // in assenza di un domicilio fiscale verifico l'esistenza di un indirizzo di residenza ala data di riferimento
                filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("idaddresskind", idResidenza),
                           "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + QHS.quote(date) + "))");
                idComune = Conn.DO_READ_VALUE("registryaddress", filter, "idcity");
                idComune = trovaComuneAttuale(Conn, idComune);
            }
            if ((idComune != DBNull.Value) && (idComune != null)){
                return idComune;
            }
            else{
                return null;
            }
        }


        static public bool FlagEstero(DataAccess Conn, int idreg, DateTime date) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object idresidence = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg), "residence");
            if (idresidence != DBNull.Value) {
                object coderes = Conn.DO_READ_VALUE("residence", QHS.CmpEq("idresidence", idresidence), "coderesidence");
                if (coderes != null) {
                    if (coderes.ToString().ToUpper() == "X") return true;
                    if (coderes.ToString().ToUpper() == "J") return true;
                }
            }
            if (date == QueryCreator.EmptyDate()) return false;
            // Verifico esistenza di un domicilio fiscale alla data di riferimento
            object idDomFiscale = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");
            object idResidenza = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");

            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("idaddresskind", idDomFiscale),
                            "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + QHS.quote(date) + "))");
            object flagforeign = Conn.DO_READ_VALUE("registryaddress", filter, "flagforeign");
            if ((flagforeign == DBNull.Value) || (flagforeign == null)) {
                // in assenza di un domicilio fiscale verifico l'esistenza di un indirizzo di residenza ala data di riferimento
                filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("idaddresskind", idResidenza),
                           "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + QHS.quote(date) + "))");
                flagforeign = Conn.DO_READ_VALUE("registryaddress", filter, "flagforeign");
            }
            if ((flagforeign != DBNull.Value) && (flagforeign != null)) {
                return (flagforeign.ToString()=="S");
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Metodo che ottiene l'ID del comune attuale partendo da un ID di un comune che puÚ essere "antico"
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="idcomune"></param>
        /// <returns></returns>
        static public object trovaComuneAttuale(DataAccess Conn, object idcomune){
            QueryHelper QHS = Conn.GetQueryHelper();
            // Se il comune passato Ë associato ad un nuovo comune (campo newcity) viene preso il newcity altrimenti
            // resta l'idcomune ricevuto in input
            if (idcomune != null && idcomune != DBNull.Value){
                object newcomune = idcomune;
                while (newcomune != DBNull.Value){
                    newcomune = Conn.DO_READ_VALUE("geo_city",
                                QHS.CmpEq("idcity", idcomune), "newcity", "idcity");
                    if (newcomune == DBNull.Value) return idcomune;
                    else{
                        idcomune = newcomune;
                    }
                }
                return newcomune;
            }
            else return idcomune;
        }

        private string ricavaDenominazioneComune(object idcity){
            object nomeCitta = Meta.Conn.DO_READ_VALUE("geo_city", QHS.CmpEq("idcity", idcity), "title");
            return nomeCitta == null ? "" : nomeCitta.ToString();
        }

        private void cmbdipertimento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkPersonafisica_CheckedChanged(object sender, EventArgs e) {
            if (Meta== null || !Meta.DrawStateIsDone) return;
            if (checkPersonafisica.Checked) {
                if (cmbTipologiaSocieta.SelectedIndex > 0) {
                    cmbTipologiaSocieta.SelectedIndex = -1;
                }
                if ((!MetaData.Empty(this))) {
                    DS.serviceregistry.Rows[0]["idconsultingkind"] = DBNull.Value;
                }
                if (!Meta.IsEmpty) Meta.GetFormData(true);
                abilitaControlli();
            }
            else {
                if ((!MetaData.Empty(this))) {
                    DS.serviceregistry.Rows[0]["flaghuman"] = "N";
                }
                if (!Meta.IsEmpty) Meta.GetFormData(true);
                abilitaControlli();
            }


        }

        private void TxtCFconferente_TextChanged(object sender, EventArgs e) {

        }

        private void chkEsteroConferente_CheckedChanged(object sender, EventArgs e) {
            if (chkEsteroConferente.Checked) {
                txtGeoComuneConferente.Text = "";
                if ((!MetaData.Empty(this))) {
                    DS.serviceregistry.Rows[0]["conferring_idcity"] = DBNull.Value;
                    DS.serviceregistry.Rows[0]["conferring_codcity"] = DBNull.Value;
                }
                txtGeoComuneConferente.ReadOnly = true;
                txtGeoComuneConferente.Enabled = false;
            }
            else {
                txtGeoComuneConferente.ReadOnly = false;
                txtGeoComuneConferente.Enabled = true;
            }
        }

        private void label41_Click(object sender, EventArgs e) {

        }

        private void txtLinkDecreto_TextChanged(object sender, EventArgs e) {

        }

        private void tabPage3_Click(object sender, EventArgs e) {

        }

        private void rdbconsulenti02_CheckedChanged(object sender, EventArgs e) {
            if ((Meta != null) && Meta.DrawStateIsDone) {
                if (Meta.IsEmpty) return;
                if (rdbconsulente02.Checked) {
                    if (!Meta.IsEmpty) Meta.GetFormData(true);
                    abilitaControlli(true);
                }
            }
        }

        private void txtDataAffidamento_Leave(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (Meta.IsEmpty) return;
            if ((Meta.InsertMode || Meta.EditMode) && ((rdbconsulente01.Checked) || rdbconsulente02.Checked)) {
                calcolaSemestre();
            }
            if ((Meta.InsertMode || Meta.EditMode) && ((rdbconsulente01.Checked) || rdbconsulente02.Checked)) {
                //Per i consulenti verifica la coerenza con la data Affidamento
                VerificaCoerenzaEsercizio("C");
            }
        }

        private void txtDataautorizzazione_Leave(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (Meta.IsEmpty) return;
            if ((Meta.InsertMode || Meta.EditMode) && (rdbdipendente.Checked)) {
                //Per i dipendenti verifica la coerenza con la data conserimento
                VerificaCoerenzaEsercizio("D");
            }
        }

        private void chkwebSite_annulled_CheckedChanged(object sender, EventArgs e) {
            bool annullato = (chkis_annulled.Checked || chkwebSite_annulled.Checked);

            if ((Meta != null) && Meta.DrawStateIsDone) {
                chkisdelivery.Checked = !annullato;
                gestioneFlag();
            }
        }

	}
}


