
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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

namespace registry_anagrafica//CreditoreDebitoreAnagrafica//
{
	/// <summary>
	/// Summary description for frmCreditoreDebitoreAnagrafica.
	/// </summary>
	public class Frm_registry_anagrafica : MetaDataForm {
		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDenominazione;
        private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.CheckBox chkUtilizzabile;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.DataGrid dgrPagamento;
		private System.Windows.Forms.Button btnPagElimina;
		private System.Windows.Forms.Button btnPagModifica;
		private System.Windows.Forms.Button btnPagInserisci;
		private System.Windows.Forms.DataGrid dgrIndirizzo;
		private System.Windows.Forms.Button btnIndElimina;
		private System.Windows.Forms.Button btnIndModifica;
		private System.Windows.Forms.Button btnIndInserisci;
		private System.Windows.Forms.DataGrid dgrPosGiuridica;
		private System.Windows.Forms.Button btnPosgiuElimina;
		private System.Windows.Forms.Button btnPosgiuModifica;
		private System.Windows.Forms.Button btnPosgiuInserisci;
		private System.Windows.Forms.DataGrid dgrContatto;
		private System.Windows.Forms.Button btnContElimina;
		private System.Windows.Forms.Button btnContModifica;
		private System.Windows.Forms.Button btnContInserisci;
		private System.Windows.Forms.DataGrid dgrClassSupp;
		private System.Windows.Forms.Button btnClassElimina;
		private System.Windows.Forms.Button btnClassModifica;
		private System.Windows.Forms.Button btnClassInserisci;
		MetaData Meta;
		public dsmeta DS;
		private System.Windows.Forms.Label lblDenominazione;
		private System.Windows.Forms.GroupBox grbSesso;
		private System.Windows.Forms.RadioButton rdbSessoM;
		private System.Windows.Forms.RadioButton rdbSessoF;
		private System.Windows.Forms.ComboBox cmbStatoCivile;
		private System.Windows.Forms.Button btnStatoCivile;
		private System.Windows.Forms.ComboBox cmbTitolo;
		private System.Windows.Forms.Button btnTitolo;
		private System.Windows.Forms.ComboBox cmbCodTipoClass;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.TextBox txtCognome;
		private System.Windows.Forms.GroupBox grpGeo;
		private System.Windows.Forms.Label lblNome;
		private System.Windows.Forms.Label lblCognome;
		private System.Windows.Forms.Button btnCF;
		private System.Windows.Forms.TextBox txtCodFiscEstero;
		private System.Windows.Forms.Label lblCodFiscEstero;
		private System.Windows.Forms.TextBox txtCognomeAcq;
		private System.Windows.Forms.Label lblCognomeAcq;
		private System.Windows.Forms.Label lblPartitaIVA;
		private System.Windows.Forms.TextBox txtPartitaIva;
		private System.Windows.Forms.Label lblCodiceFiscale;
		private System.Windows.Forms.TextBox txtCodiceFiscale;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox txtDataNascita;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TabPage tabGeneralita;
		private System.Windows.Forms.TabPage tabIndirizzo;
		private System.Windows.Forms.TabPage tabPosGiuridica;
		private System.Windows.Forms.TabPage tabContatto;
		private System.Windows.Forms.TabPage tabPagamento;
		private System.Windows.Forms.TabPage tabClassSup;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label lblComuneStato;
		private System.Windows.Forms.GroupBox grpItaliano;
		private System.Windows.Forms.GroupBox grpEstero;
		private System.Windows.Forms.TextBox txtGeoNazione;
		private System.Windows.Forms.TextBox txtLocalitaGeo;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtProvincia;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkItaliano;
		private System.Windows.Forms.TextBox txtLocalita;
		private System.Windows.Forms.Button btnCFInfo;
		private System.Windows.Forms.Button btnAggiornaComune;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGrid dgrPosRetributiva;
		private System.Windows.Forms.Button btnPosretElimina;
		private System.Windows.Forms.Button btnPosretModifica;
        private System.Windows.Forms.Button btnPosretInserisci;
        private System.Windows.Forms.ImageList imageList1;
        private TabPage tabCF;
        private DataGrid dataGrid1;
        private Button button1;
        private Button button2;
        private Button button3;
        private GroupBox grpCF;
        private GroupBox grpPIVA;
        private Button button6;
        private DataGrid dataGrid2;
        private Button button7;
        private Button button8;
        private Label label4;
        private Label label3;
        private CheckBox checkBox2;
        private TabPage tabAltriDati;
        private GroupBox groupBox5;
        private TextBox textBox2;
        private TextBox txtCodiceCausaleCredit;
        private Button button10;
        private GroupBox groupBox10;
        private TextBox textBox1;
        private TextBox txtCodiceCausaleDeb;
        private Button button9;
        private CheckBox checkBox1;
        private GroupBox groupBox4;
        private ComboBox cmbCategoria;
        private Button button5;
        private Label lblMatricolaext;
        private TextBox txtMatricolaext;
        private Label lblBadge;
        private TextBox txtBadge;
        private GroupBox groupBox3;
        private Button buttonVecchiaClassificazione;
        private ComboBox comboBoxVecchiaClassificazione;
        private Button cmdClassificazione;
        private ComboBox cmbClassificazione;
        private TextBox txtDescrizione;
        private Label label6;
        private TabPage tabPage1;
        private DataGrid dtgDurc;
        private Button button11;
        private Button button12;
        private Button button13;
        private Label lblStatoDurc;
        private GroupBox groupBox6;
        private TextBox txtCCP;
        private Label label8;
        private CheckBox chkBankItaliaProceeds;
        private TextBox textBox3;
        private CheckBox chhEntePubblico;
        private TabPage tabMod770;
        private DataGrid dataGrid4;
        private Button button14;
        private Button button15;
        private Button button16;
        private GroupBox groupBox7;
        private CheckBox chkRifAmm;
        private TextBox textBox4;
        private Label label11;
        private TabPage tabDocAmm;
        private Button button17;
        private Button button18;
        private Button button19;
		private TextBox textBox5;
		private Label label13;
		private TextBox txtIndirizzoEmail;
		private Label label10;
		private Label label12;
		private TextBox textBox6;
		private Label label14;
		private TabControl tabControl2;
		private TabPage tabVisura;
		private TabPage tabCasellarioG;
		private TabPage tabCasellarioA;
		private GroupBox grpCV;
		private DataGrid datagrid3;
		private Button button22;
		private Button button21;
		private Button button20;
		private DataGrid dataGrid6;
		private Button button25;
		private Button button24;
		private Button button23;
		private DataGrid dataGrid5;
		private DataGrid dataGrid7;
		private Button button28;
		private Button button27;
		private Button button26;
		private TabPage tabOttempLegge68_99;
		private DataGrid dataGrid8;
		private Button button29;
		private Button button30;
		private Button button31;
		private TabPage tabRegolaritaFiscale;
		private DataGrid dataGrid9;
		private Button button32;
		private Button button33;
		private Button button34;
		private TabPage tabVerificaAnac;
		private DataGrid dataGrid10;
		private Button button35;
		private Button button36;
		private Button button37;
		private Label label15;
		private Label label16;
		private Label label17;
		private Label label18;
		private Label label19;
		private Label label20;
		private TabPage tabAllegati;
		private DataGrid dataGrid11;
		private Button btnDelAtt;
		private Button btnEditAtt;
		private Button btnInsAtt;
		private TabPage tabPattointegrita;
		private Label label21;
		private DataGrid dgridPattointegrita;
		private Button button38;
		private Button button39;
		private Button button40;
		private TabControl tabControl3;
		private TabPage tabPrincipale;
		private TabPage tabFatture;
		private TabPage tabClassificazioni;
		private GroupBox groupBox12;
		private GroupBox groupBox8;
		private TabPage tabAltro;
		private Label label22;
		private ComboBox cmbistituto;
		private GroupBox gboxAteco;
		public TextBox txtUPB;
		private TextBox txtDescrUPB;
		private GroupBox grpNace;
		public TextBox textBox7;
		private TextBox textBox8;
		private Label label23;
		private Label label24;
		private ComboBox cmbDip;
		private ComboBox cmbNaturagiu;
		private Label label25;
		private TextBox textBox9;
		private object idgeo=DBNull.Value;

		public Frm_registry_anagrafica() {
			InitializeComponent();
			DataAccess.SetTableForReading(DS.geo_nazione_alias, "geo_nation");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_registry_anagrafica));
			this.cmbTipo = new System.Windows.Forms.ComboBox();
			this.DS = new registry_anagrafica.dsmeta();
			this.label5 = new System.Windows.Forms.Label();
			this.lblDenominazione = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDenominazione = new System.Windows.Forms.TextBox();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.chkUtilizzabile = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabGeneralita = new System.Windows.Forms.TabPage();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.btnCFInfo = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.btnCF = new System.Windows.Forms.Button();
			this.txtCodFiscEstero = new System.Windows.Forms.TextBox();
			this.lblCodFiscEstero = new System.Windows.Forms.Label();
			this.txtCognomeAcq = new System.Windows.Forms.TextBox();
			this.lblCognomeAcq = new System.Windows.Forms.Label();
			this.lblPartitaIVA = new System.Windows.Forms.Label();
			this.txtPartitaIva = new System.Windows.Forms.TextBox();
			this.lblCodiceFiscale = new System.Windows.Forms.Label();
			this.txtCodiceFiscale = new System.Windows.Forms.TextBox();
			this.grpGeo = new System.Windows.Forms.GroupBox();
			this.chkItaliano = new System.Windows.Forms.CheckBox();
			this.txtLocalita = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grpEstero = new System.Windows.Forms.GroupBox();
			this.txtGeoNazione = new System.Windows.Forms.TextBox();
			this.grpItaliano = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtProvincia = new System.Windows.Forms.TextBox();
			this.txtLocalitaGeo = new System.Windows.Forms.TextBox();
			this.txtDataNascita = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lblComuneStato = new System.Windows.Forms.Label();
			this.btnAggiornaComune = new System.Windows.Forms.Button();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.lblNome = new System.Windows.Forms.Label();
			this.txtCognome = new System.Windows.Forms.TextBox();
			this.lblCognome = new System.Windows.Forms.Label();
			this.cmbStatoCivile = new System.Windows.Forms.ComboBox();
			this.btnStatoCivile = new System.Windows.Forms.Button();
			this.cmbTitolo = new System.Windows.Forms.ComboBox();
			this.btnTitolo = new System.Windows.Forms.Button();
			this.grbSesso = new System.Windows.Forms.GroupBox();
			this.rdbSessoM = new System.Windows.Forms.RadioButton();
			this.rdbSessoF = new System.Windows.Forms.RadioButton();
			this.cmbCodTipoClass = new System.Windows.Forms.ComboBox();
			this.tabPagamento = new System.Windows.Forms.TabPage();
			this.dgrPagamento = new System.Windows.Forms.DataGrid();
			this.btnPagElimina = new System.Windows.Forms.Button();
			this.btnPagModifica = new System.Windows.Forms.Button();
			this.btnPagInserisci = new System.Windows.Forms.Button();
			this.tabIndirizzo = new System.Windows.Forms.TabPage();
			this.dgrIndirizzo = new System.Windows.Forms.DataGrid();
			this.btnIndElimina = new System.Windows.Forms.Button();
			this.btnIndModifica = new System.Windows.Forms.Button();
			this.btnIndInserisci = new System.Windows.Forms.Button();
			this.tabAltriDati = new System.Windows.Forms.TabPage();
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
			this.button9 = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleCredit = new System.Windows.Forms.TextBox();
			this.button10 = new System.Windows.Forms.Button();
			this.tabFatture = new System.Windows.Forms.TabPage();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtIndirizzoEmail = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.chkRifAmm = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.chhEntePubblico = new System.Windows.Forms.CheckBox();
			this.chkBankItaliaProceeds = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.tabClassificazioni = new System.Windows.Forms.TabPage();
			this.label25 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbDip = new System.Windows.Forms.ComboBox();
			this.cmbNaturagiu = new System.Windows.Forms.ComboBox();
			this.grpNace = new System.Windows.Forms.GroupBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.gboxAteco = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label22 = new System.Windows.Forms.Label();
			this.cmbistituto = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.buttonVecchiaClassificazione = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.comboBoxVecchiaClassificazione = new System.Windows.Forms.ComboBox();
			this.cmdClassificazione = new System.Windows.Forms.Button();
			this.cmbClassificazione = new System.Windows.Forms.ComboBox();
			this.tabAltro = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.txtCCP = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cmbCategoria = new System.Windows.Forms.ComboBox();
			this.button5 = new System.Windows.Forms.Button();
			this.lblMatricolaext = new System.Windows.Forms.Label();
			this.txtMatricolaext = new System.Windows.Forms.TextBox();
			this.lblBadge = new System.Windows.Forms.Label();
			this.txtBadge = new System.Windows.Forms.TextBox();
			this.tabContatto = new System.Windows.Forms.TabPage();
			this.dgrContatto = new System.Windows.Forms.DataGrid();
			this.btnContElimina = new System.Windows.Forms.Button();
			this.btnContModifica = new System.Windows.Forms.Button();
			this.btnContInserisci = new System.Windows.Forms.Button();
			this.tabPosGiuridica = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgrPosRetributiva = new System.Windows.Forms.DataGrid();
			this.btnPosretElimina = new System.Windows.Forms.Button();
			this.btnPosretModifica = new System.Windows.Forms.Button();
			this.btnPosretInserisci = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgrPosGiuridica = new System.Windows.Forms.DataGrid();
			this.btnPosgiuElimina = new System.Windows.Forms.Button();
			this.btnPosgiuModifica = new System.Windows.Forms.Button();
			this.btnPosgiuInserisci = new System.Windows.Forms.Button();
			this.tabClassSup = new System.Windows.Forms.TabPage();
			this.dgrClassSupp = new System.Windows.Forms.DataGrid();
			this.btnClassElimina = new System.Windows.Forms.Button();
			this.btnClassModifica = new System.Windows.Forms.Button();
			this.btnClassInserisci = new System.Windows.Forms.Button();
			this.tabCF = new System.Windows.Forms.TabPage();
			this.grpCV = new System.Windows.Forms.GroupBox();
			this.datagrid3 = new System.Windows.Forms.DataGrid();
			this.button22 = new System.Windows.Forms.Button();
			this.button21 = new System.Windows.Forms.Button();
			this.button20 = new System.Windows.Forms.Button();
			this.grpPIVA = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.grpCF = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lblStatoDurc = new System.Windows.Forms.Label();
			this.dtgDurc = new System.Windows.Forms.DataGrid();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.tabDocAmm = new System.Windows.Forms.TabPage();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabVisura = new System.Windows.Forms.TabPage();
			this.label15 = new System.Windows.Forms.Label();
			this.dataGrid5 = new System.Windows.Forms.DataGrid();
			this.button19 = new System.Windows.Forms.Button();
			this.button17 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.tabCasellarioG = new System.Windows.Forms.TabPage();
			this.label16 = new System.Windows.Forms.Label();
			this.dataGrid6 = new System.Windows.Forms.DataGrid();
			this.button25 = new System.Windows.Forms.Button();
			this.button24 = new System.Windows.Forms.Button();
			this.button23 = new System.Windows.Forms.Button();
			this.tabCasellarioA = new System.Windows.Forms.TabPage();
			this.label17 = new System.Windows.Forms.Label();
			this.dataGrid7 = new System.Windows.Forms.DataGrid();
			this.button28 = new System.Windows.Forms.Button();
			this.button27 = new System.Windows.Forms.Button();
			this.button26 = new System.Windows.Forms.Button();
			this.tabOttempLegge68_99 = new System.Windows.Forms.TabPage();
			this.label18 = new System.Windows.Forms.Label();
			this.dataGrid8 = new System.Windows.Forms.DataGrid();
			this.button29 = new System.Windows.Forms.Button();
			this.button30 = new System.Windows.Forms.Button();
			this.button31 = new System.Windows.Forms.Button();
			this.tabRegolaritaFiscale = new System.Windows.Forms.TabPage();
			this.label19 = new System.Windows.Forms.Label();
			this.dataGrid9 = new System.Windows.Forms.DataGrid();
			this.button32 = new System.Windows.Forms.Button();
			this.button33 = new System.Windows.Forms.Button();
			this.button34 = new System.Windows.Forms.Button();
			this.tabVerificaAnac = new System.Windows.Forms.TabPage();
			this.label20 = new System.Windows.Forms.Label();
			this.dataGrid10 = new System.Windows.Forms.DataGrid();
			this.button35 = new System.Windows.Forms.Button();
			this.button36 = new System.Windows.Forms.Button();
			this.button37 = new System.Windows.Forms.Button();
			this.tabPattointegrita = new System.Windows.Forms.TabPage();
			this.label21 = new System.Windows.Forms.Label();
			this.dgridPattointegrita = new System.Windows.Forms.DataGrid();
			this.button38 = new System.Windows.Forms.Button();
			this.button39 = new System.Windows.Forms.Button();
			this.button40 = new System.Windows.Forms.Button();
			this.tabAllegati = new System.Windows.Forms.TabPage();
			this.dataGrid11 = new System.Windows.Forms.DataGrid();
			this.btnDelAtt = new System.Windows.Forms.Button();
			this.btnEditAtt = new System.Windows.Forms.Button();
			this.btnInsAtt = new System.Windows.Forms.Button();
			this.tabMod770 = new System.Windows.Forms.TabPage();
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.button14 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button16 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabGeneralita.SuspendLayout();
			this.grpGeo.SuspendLayout();
			this.grpEstero.SuspendLayout();
			this.grpItaliano.SuspendLayout();
			this.grbSesso.SuspendLayout();
			this.tabPagamento.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPagamento)).BeginInit();
			this.tabIndirizzo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrIndirizzo)).BeginInit();
			this.tabAltriDati.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tabPrincipale.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabFatture.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.tabClassificazioni.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.grpNace.SuspendLayout();
			this.gboxAteco.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabAltro.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabContatto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrContatto)).BeginInit();
			this.tabPosGiuridica.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPosRetributiva)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPosGiuridica)).BeginInit();
			this.tabClassSup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSupp)).BeginInit();
			this.tabCF.SuspendLayout();
			this.grpCV.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.datagrid3)).BeginInit();
			this.grpPIVA.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.grpCF.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgDurc)).BeginInit();
			this.tabDocAmm.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabVisura.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).BeginInit();
			this.tabCasellarioG.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid6)).BeginInit();
			this.tabCasellarioA.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid7)).BeginInit();
			this.tabOttempLegge68_99.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid8)).BeginInit();
			this.tabRegolaritaFiscale.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid9)).BeginInit();
			this.tabVerificaAnac.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid10)).BeginInit();
			this.tabPattointegrita.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridPattointegrita)).BeginInit();
			this.tabAllegati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid11)).BeginInit();
			this.tabMod770.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbTipo
			// 
			this.cmbTipo.DataSource = this.DS.residence;
			this.cmbTipo.DisplayMember = "description";
			this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipo.Location = new System.Drawing.Point(112, 72);
			this.cmbTipo.Name = "cmbTipo";
			this.cmbTipo.Size = new System.Drawing.Size(328, 21);
			this.cmbTipo.TabIndex = 8;
			this.cmbTipo.Tag = "registry.residence";
			this.cmbTipo.ValueMember = "idresidence";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 19);
			this.label5.TabIndex = 43;
			this.label5.Text = "Tipo residenza";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDenominazione
			// 
			this.lblDenominazione.Location = new System.Drawing.Point(16, 104);
			this.lblDenominazione.Name = "lblDenominazione";
			this.lblDenominazione.Size = new System.Drawing.Size(88, 18);
			this.lblDenominazione.TabIndex = 32;
			this.lblDenominazione.Text = "Denominazione";
			this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 19);
			this.label1.TabIndex = 30;
			this.label1.Text = "Codice";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtDenominazione
			// 
			this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazione.Location = new System.Drawing.Point(112, 104);
			this.txtDenominazione.Name = "txtDenominazione";
			this.txtDenominazione.Size = new System.Drawing.Size(767, 20);
			this.txtDenominazione.TabIndex = 11;
			this.txtDenominazione.Tag = "registry.title";
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(112, 16);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(80, 20);
			this.txtCodice.TabIndex = 0;
			this.txtCodice.TabStop = false;
			this.txtCodice.Tag = "registry.idreg";
			// 
			// chkUtilizzabile
			// 
			this.chkUtilizzabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkUtilizzabile.Location = new System.Drawing.Point(814, 476);
			this.chkUtilizzabile.Name = "chkUtilizzabile";
			this.chkUtilizzabile.Size = new System.Drawing.Size(88, 16);
			this.chkUtilizzabile.TabIndex = 0;
			this.chkUtilizzabile.Tag = "registry.active:S:N";
			this.chkUtilizzabile.Text = "Utilizzabile";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabGeneralita);
			this.tabControl1.Controls.Add(this.tabPagamento);
			this.tabControl1.Controls.Add(this.tabIndirizzo);
			this.tabControl1.Controls.Add(this.tabAltriDati);
			this.tabControl1.Controls.Add(this.tabContatto);
			this.tabControl1.Controls.Add(this.tabPosGiuridica);
			this.tabControl1.Controls.Add(this.tabClassSup);
			this.tabControl1.Controls.Add(this.tabCF);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabDocAmm);
			this.tabControl1.Controls.Add(this.tabAllegati);
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point(0, -2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(918, 526);
			this.tabControl1.TabIndex = 45;
			this.tabControl1.Tag = "oneredetraibilecreddeb.anagraficadetail.anagraficadetail";
			// 
			// tabGeneralita
			// 
			this.tabGeneralita.Controls.Add(this.checkBox2);
			this.tabGeneralita.Controls.Add(this.btnCFInfo);
			this.tabGeneralita.Controls.Add(this.button4);
			this.tabGeneralita.Controls.Add(this.btnCF);
			this.tabGeneralita.Controls.Add(this.txtCodFiscEstero);
			this.tabGeneralita.Controls.Add(this.lblCodFiscEstero);
			this.tabGeneralita.Controls.Add(this.txtCognomeAcq);
			this.tabGeneralita.Controls.Add(this.lblCognomeAcq);
			this.tabGeneralita.Controls.Add(this.lblPartitaIVA);
			this.tabGeneralita.Controls.Add(this.txtPartitaIva);
			this.tabGeneralita.Controls.Add(this.lblCodiceFiscale);
			this.tabGeneralita.Controls.Add(this.txtCodiceFiscale);
			this.tabGeneralita.Controls.Add(this.grpGeo);
			this.tabGeneralita.Controls.Add(this.txtNome);
			this.tabGeneralita.Controls.Add(this.lblNome);
			this.tabGeneralita.Controls.Add(this.txtCognome);
			this.tabGeneralita.Controls.Add(this.lblCognome);
			this.tabGeneralita.Controls.Add(this.cmbStatoCivile);
			this.tabGeneralita.Controls.Add(this.btnStatoCivile);
			this.tabGeneralita.Controls.Add(this.cmbTitolo);
			this.tabGeneralita.Controls.Add(this.btnTitolo);
			this.tabGeneralita.Controls.Add(this.grbSesso);
			this.tabGeneralita.Controls.Add(this.cmbCodTipoClass);
			this.tabGeneralita.Controls.Add(this.cmbTipo);
			this.tabGeneralita.Controls.Add(this.label5);
			this.tabGeneralita.Controls.Add(this.lblDenominazione);
			this.tabGeneralita.Controls.Add(this.label1);
			this.tabGeneralita.Controls.Add(this.txtDenominazione);
			this.tabGeneralita.Controls.Add(this.txtCodice);
			this.tabGeneralita.Controls.Add(this.chkUtilizzabile);
			this.tabGeneralita.Location = new System.Drawing.Point(4, 23);
			this.tabGeneralita.Name = "tabGeneralita";
			this.tabGeneralita.Size = new System.Drawing.Size(910, 499);
			this.tabGeneralita.TabIndex = 0;
			this.tabGeneralita.Text = "Principale";
			this.tabGeneralita.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox2.Location = new System.Drawing.Point(569, 475);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(229, 16);
			this.checkBox2.TabIndex = 175;
			this.checkBox2.Tag = "registry.multi_cf:S:N";
			this.checkBox2.Text = "Consenti duplicazione CF/P. IVA";
			// 
			// btnCFInfo
			// 
			this.btnCFInfo.Location = new System.Drawing.Point(480, 272);
			this.btnCFInfo.Name = "btnCFInfo";
			this.btnCFInfo.Size = new System.Drawing.Size(200, 23);
			this.btnCFInfo.TabIndex = 17;
			this.btnCFInfo.TabStop = false;
			this.btnCFInfo.Text = "Ricava informazioni da codice fiscale";
			this.btnCFInfo.Click += new System.EventHandler(this.btnCFInfo_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(16, 40);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(88, 22);
			this.button4.TabIndex = 4;
			this.button4.TabStop = false;
			this.button4.Tag = "manage.registryclass.anagrafica";
			this.button4.Text = "Tipologia";
			// 
			// btnCF
			// 
			this.btnCF.Location = new System.Drawing.Point(344, 272);
			this.btnCF.Name = "btnCF";
			this.btnCF.Size = new System.Drawing.Size(128, 23);
			this.btnCF.TabIndex = 16;
			this.btnCF.TabStop = false;
			this.btnCF.Text = "Calcola Codice Fiscale";
			this.btnCF.Click += new System.EventHandler(this.btnCF_Click);
			// 
			// txtCodFiscEstero
			// 
			this.txtCodFiscEstero.Location = new System.Drawing.Point(152, 339);
			this.txtCodFiscEstero.Name = "txtCodFiscEstero";
			this.txtCodFiscEstero.Size = new System.Drawing.Size(184, 20);
			this.txtCodFiscEstero.TabIndex = 19;
			this.txtCodFiscEstero.Tag = "registry.foreigncf";
			// 
			// lblCodFiscEstero
			// 
			this.lblCodFiscEstero.Location = new System.Drawing.Point(8, 325);
			this.lblCodFiscEstero.Name = "lblCodFiscEstero";
			this.lblCodFiscEstero.Size = new System.Drawing.Size(139, 46);
			this.lblCodFiscEstero.TabIndex = 174;
			this.lblCodFiscEstero.Text = "CF estero, partita iva ExtraUE o codice identificativo IVA";
			this.lblCodFiscEstero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCognomeAcq
			// 
			this.txtCognomeAcq.Location = new System.Drawing.Point(152, 380);
			this.txtCognomeAcq.Name = "txtCognomeAcq";
			this.txtCognomeAcq.Size = new System.Drawing.Size(184, 20);
			this.txtCognomeAcq.TabIndex = 24;
			this.txtCognomeAcq.Tag = "registry.maritalsurname";
			// 
			// lblCognomeAcq
			// 
			this.lblCognomeAcq.Location = new System.Drawing.Point(43, 380);
			this.lblCognomeAcq.Name = "lblCognomeAcq";
			this.lblCognomeAcq.Size = new System.Drawing.Size(104, 18);
			this.lblCognomeAcq.TabIndex = 173;
			this.lblCognomeAcq.Text = "Cognome acquisito";
			this.lblCognomeAcq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPartitaIVA
			// 
			this.lblPartitaIVA.Location = new System.Drawing.Point(19, 304);
			this.lblPartitaIVA.Name = "lblPartitaIVA";
			this.lblPartitaIVA.Size = new System.Drawing.Size(128, 19);
			this.lblPartitaIVA.TabIndex = 172;
			this.lblPartitaIVA.Text = "Partita IVA italiana o UE";
			this.lblPartitaIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPartitaIva
			// 
			this.txtPartitaIva.Location = new System.Drawing.Point(153, 304);
			this.txtPartitaIva.Name = "txtPartitaIva";
			this.txtPartitaIva.Size = new System.Drawing.Size(183, 20);
			this.txtPartitaIva.TabIndex = 18;
			this.txtPartitaIva.Tag = "registry.p_iva";
			// 
			// lblCodiceFiscale
			// 
			this.lblCodiceFiscale.Location = new System.Drawing.Point(60, 268);
			this.lblCodiceFiscale.Name = "lblCodiceFiscale";
			this.lblCodiceFiscale.Size = new System.Drawing.Size(88, 32);
			this.lblCodiceFiscale.TabIndex = 171;
			this.lblCodiceFiscale.Text = "Codice Fiscale italiano";
			this.lblCodiceFiscale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCodiceFiscale
			// 
			this.txtCodiceFiscale.Location = new System.Drawing.Point(153, 272);
			this.txtCodiceFiscale.Name = "txtCodiceFiscale";
			this.txtCodiceFiscale.Size = new System.Drawing.Size(183, 20);
			this.txtCodiceFiscale.TabIndex = 15;
			this.txtCodiceFiscale.Tag = "registry.cf";
			// 
			// grpGeo
			// 
			this.grpGeo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpGeo.Controls.Add(this.chkItaliano);
			this.grpGeo.Controls.Add(this.txtLocalita);
			this.grpGeo.Controls.Add(this.label2);
			this.grpGeo.Controls.Add(this.grpEstero);
			this.grpGeo.Controls.Add(this.grpItaliano);
			this.grpGeo.Controls.Add(this.txtDataNascita);
			this.grpGeo.Controls.Add(this.label7);
			this.grpGeo.Controls.Add(this.lblComuneStato);
			this.grpGeo.Controls.Add(this.btnAggiornaComune);
			this.grpGeo.Location = new System.Drawing.Point(8, 160);
			this.grpGeo.Name = "grpGeo";
			this.grpGeo.Size = new System.Drawing.Size(871, 104);
			this.grpGeo.TabIndex = 14;
			this.grpGeo.TabStop = false;
			this.grpGeo.Tag = "";
			this.grpGeo.Text = "Dati di nascita";
			// 
			// chkItaliano
			// 
			this.chkItaliano.Location = new System.Drawing.Point(216, 69);
			this.chkItaliano.Name = "chkItaliano";
			this.chkItaliano.Size = new System.Drawing.Size(72, 24);
			this.chkItaliano.TabIndex = 3;
			this.chkItaliano.Text = "Italiano";
			this.chkItaliano.CheckedChanged += new System.EventHandler(this.chkItaliano_CheckedChanged);
			// 
			// txtLocalita
			// 
			this.txtLocalita.Location = new System.Drawing.Point(352, 71);
			this.txtLocalita.Name = "txtLocalita";
			this.txtLocalita.Size = new System.Drawing.Size(312, 20);
			this.txtLocalita.TabIndex = 4;
			this.txtLocalita.Tag = "registry.location";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(296, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 18);
			this.label2.TabIndex = 158;
			this.label2.Text = "Localit�";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpEstero
			// 
			this.grpEstero.Controls.Add(this.txtGeoNazione);
			this.grpEstero.Location = new System.Drawing.Point(96, 16);
			this.grpEstero.Name = "grpEstero";
			this.grpEstero.Size = new System.Drawing.Size(344, 48);
			this.grpEstero.TabIndex = 1;
			this.grpEstero.TabStop = false;
			this.grpEstero.Tag = "AutoChoose.txtGeoNazione.default";
			this.grpEstero.Visible = false;
			// 
			// txtGeoNazione
			// 
			this.txtGeoNazione.Location = new System.Drawing.Point(8, 16);
			this.txtGeoNazione.Name = "txtGeoNazione";
			this.txtGeoNazione.Size = new System.Drawing.Size(328, 20);
			this.txtGeoNazione.TabIndex = 3;
			this.txtGeoNazione.Tag = "geo_nazione_alias.title?registrymainview.nation";
			// 
			// grpItaliano
			// 
			this.grpItaliano.Controls.Add(this.label9);
			this.grpItaliano.Controls.Add(this.txtProvincia);
			this.grpItaliano.Controls.Add(this.txtLocalitaGeo);
			this.grpItaliano.Location = new System.Drawing.Point(96, 16);
			this.grpItaliano.Name = "grpItaliano";
			this.grpItaliano.Size = new System.Drawing.Size(448, 48);
			this.grpItaliano.TabIndex = 0;
			this.grpItaliano.TabStop = false;
			this.grpItaliano.Tag = "AutoChoose.txtLocalitaGeo.default";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(344, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 18);
			this.label9.TabIndex = 154;
			this.label9.Text = "Provincia";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtProvincia
			// 
			this.txtProvincia.Location = new System.Drawing.Point(400, 15);
			this.txtProvincia.Name = "txtProvincia";
			this.txtProvincia.ReadOnly = true;
			this.txtProvincia.Size = new System.Drawing.Size(40, 20);
			this.txtProvincia.TabIndex = 153;
			this.txtProvincia.TabStop = false;
			this.txtProvincia.Tag = "geo_cityview.provincecode";
			// 
			// txtLocalitaGeo
			// 
			this.txtLocalitaGeo.Location = new System.Drawing.Point(8, 16);
			this.txtLocalitaGeo.Name = "txtLocalitaGeo";
			this.txtLocalitaGeo.Size = new System.Drawing.Size(328, 20);
			this.txtLocalitaGeo.TabIndex = 3;
			this.txtLocalitaGeo.Tag = "geo_cityview.title?registrymainview.city";
			// 
			// txtDataNascita
			// 
			this.txtDataNascita.Location = new System.Drawing.Point(104, 71);
			this.txtDataNascita.Name = "txtDataNascita";
			this.txtDataNascita.Size = new System.Drawing.Size(88, 20);
			this.txtDataNascita.TabIndex = 2;
			this.txtDataNascita.Tag = "registry.birthdate";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(56, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 18);
			this.label7.TabIndex = 148;
			this.label7.Text = "Data";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblComuneStato
			// 
			this.lblComuneStato.Location = new System.Drawing.Point(8, 40);
			this.lblComuneStato.Name = "lblComuneStato";
			this.lblComuneStato.Size = new System.Drawing.Size(80, 16);
			this.lblComuneStato.TabIndex = 146;
			this.lblComuneStato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnAggiornaComune
			// 
			this.btnAggiornaComune.Location = new System.Drawing.Point(544, 32);
			this.btnAggiornaComune.Name = "btnAggiornaComune";
			this.btnAggiornaComune.Size = new System.Drawing.Size(122, 23);
			this.btnAggiornaComune.TabIndex = 155;
			this.btnAggiornaComune.TabStop = false;
			this.btnAggiornaComune.Text = "Aggiorna Stato estero";
			this.btnAggiornaComune.Visible = false;
			this.btnAggiornaComune.Click += new System.EventHandler(this.btnAggiornaComune_Click);
			// 
			// txtNome
			// 
			this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNome.Location = new System.Drawing.Point(424, 136);
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(455, 20);
			this.txtNome.TabIndex = 13;
			this.txtNome.Tag = "registry.forename";
			this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
			// 
			// lblNome
			// 
			this.lblNome.Location = new System.Drawing.Point(376, 136);
			this.lblNome.Name = "lblNome";
			this.lblNome.Size = new System.Drawing.Size(40, 19);
			this.lblNome.TabIndex = 163;
			this.lblNome.Text = "Nome:";
			this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCognome
			// 
			this.txtCognome.Location = new System.Drawing.Point(112, 136);
			this.txtCognome.Name = "txtCognome";
			this.txtCognome.Size = new System.Drawing.Size(256, 20);
			this.txtCognome.TabIndex = 12;
			this.txtCognome.Tag = "registry.surname";
			this.txtCognome.TextChanged += new System.EventHandler(this.txtCognome_TextChanged);
			// 
			// lblCognome
			// 
			this.lblCognome.Location = new System.Drawing.Point(16, 136);
			this.lblCognome.Name = "lblCognome";
			this.lblCognome.Size = new System.Drawing.Size(88, 18);
			this.lblCognome.TabIndex = 161;
			this.lblCognome.Text = "Cognome";
			this.lblCognome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmbStatoCivile
			// 
			this.cmbStatoCivile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatoCivile.DataSource = this.DS.maritalstatus;
			this.cmbStatoCivile.DisplayMember = "description";
			this.cmbStatoCivile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatoCivile.ItemHeight = 13;
			this.cmbStatoCivile.Location = new System.Drawing.Point(536, 72);
			this.cmbStatoCivile.Name = "cmbStatoCivile";
			this.cmbStatoCivile.Size = new System.Drawing.Size(343, 21);
			this.cmbStatoCivile.TabIndex = 10;
			this.cmbStatoCivile.Tag = "registry.idmaritalstatus";
			this.cmbStatoCivile.ValueMember = "idmaritalstatus";
			// 
			// btnStatoCivile
			// 
			this.btnStatoCivile.Location = new System.Drawing.Point(456, 72);
			this.btnStatoCivile.Name = "btnStatoCivile";
			this.btnStatoCivile.Size = new System.Drawing.Size(72, 22);
			this.btnStatoCivile.TabIndex = 9;
			this.btnStatoCivile.TabStop = false;
			this.btnStatoCivile.Tag = "manage.maritalstatus.default";
			this.btnStatoCivile.Text = "Stato civile";
			// 
			// cmbTitolo
			// 
			this.cmbTitolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTitolo.DataSource = this.DS.title;
			this.cmbTitolo.DisplayMember = "description";
			this.cmbTitolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTitolo.ItemHeight = 13;
			this.cmbTitolo.Location = new System.Drawing.Point(536, 40);
			this.cmbTitolo.Name = "cmbTitolo";
			this.cmbTitolo.Size = new System.Drawing.Size(343, 21);
			this.cmbTitolo.TabIndex = 7;
			this.cmbTitolo.Tag = "registry.idtitle";
			this.cmbTitolo.ValueMember = "idtitle";
			// 
			// btnTitolo
			// 
			this.btnTitolo.Location = new System.Drawing.Point(456, 40);
			this.btnTitolo.Name = "btnTitolo";
			this.btnTitolo.Size = new System.Drawing.Size(72, 22);
			this.btnTitolo.TabIndex = 6;
			this.btnTitolo.TabStop = false;
			this.btnTitolo.Tag = "manage.title.default";
			this.btnTitolo.Text = "Titolo";
			// 
			// grbSesso
			// 
			this.grbSesso.Controls.Add(this.rdbSessoM);
			this.grbSesso.Controls.Add(this.rdbSessoF);
			this.grbSesso.Location = new System.Drawing.Point(342, 0);
			this.grbSesso.Name = "grbSesso";
			this.grbSesso.Size = new System.Drawing.Size(96, 40);
			this.grbSesso.TabIndex = 1;
			this.grbSesso.TabStop = false;
			this.grbSesso.Text = "Sesso";
			// 
			// rdbSessoM
			// 
			this.rdbSessoM.Location = new System.Drawing.Point(12, 16);
			this.rdbSessoM.Name = "rdbSessoM";
			this.rdbSessoM.Size = new System.Drawing.Size(28, 18);
			this.rdbSessoM.TabIndex = 5;
			this.rdbSessoM.Tag = "registry.gender:M";
			this.rdbSessoM.Text = "M";
			// 
			// rdbSessoF
			// 
			this.rdbSessoF.Location = new System.Drawing.Point(56, 16);
			this.rdbSessoF.Name = "rdbSessoF";
			this.rdbSessoF.Size = new System.Drawing.Size(30, 19);
			this.rdbSessoF.TabIndex = 6;
			this.rdbSessoF.Tag = "registry.gender:F";
			this.rdbSessoF.Text = "F";
			// 
			// cmbCodTipoClass
			// 
			this.cmbCodTipoClass.DataSource = this.DS.registryclass;
			this.cmbCodTipoClass.DisplayMember = "description";
			this.cmbCodTipoClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCodTipoClass.Location = new System.Drawing.Point(112, 40);
			this.cmbCodTipoClass.Name = "cmbCodTipoClass";
			this.cmbCodTipoClass.Size = new System.Drawing.Size(328, 21);
			this.cmbCodTipoClass.TabIndex = 5;
			this.cmbCodTipoClass.Tag = "registry.idregistryclass";
			this.cmbCodTipoClass.ValueMember = "idregistryclass";
			// 
			// tabPagamento
			// 
			this.tabPagamento.Controls.Add(this.dgrPagamento);
			this.tabPagamento.Controls.Add(this.btnPagElimina);
			this.tabPagamento.Controls.Add(this.btnPagModifica);
			this.tabPagamento.Controls.Add(this.btnPagInserisci);
			this.tabPagamento.Location = new System.Drawing.Point(4, 23);
			this.tabPagamento.Name = "tabPagamento";
			this.tabPagamento.Size = new System.Drawing.Size(910, 499);
			this.tabPagamento.TabIndex = 2;
			this.tabPagamento.Text = "Modalit� di Pagamento";
			this.tabPagamento.UseVisualStyleBackColor = true;
			// 
			// dgrPagamento
			// 
			this.dgrPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrPagamento.CaptionVisible = false;
			this.dgrPagamento.DataMember = "";
			this.dgrPagamento.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrPagamento.Location = new System.Drawing.Point(16, 48);
			this.dgrPagamento.Name = "dgrPagamento";
			this.dgrPagamento.ReadOnly = true;
			this.dgrPagamento.Size = new System.Drawing.Size(878, 445);
			this.dgrPagamento.TabIndex = 7;
			this.dgrPagamento.Tag = "registrypaymethod.anagrafica.anagrafica";
			// 
			// btnPagElimina
			// 
			this.btnPagElimina.Location = new System.Drawing.Point(176, 16);
			this.btnPagElimina.Name = "btnPagElimina";
			this.btnPagElimina.Size = new System.Drawing.Size(68, 22);
			this.btnPagElimina.TabIndex = 6;
			this.btnPagElimina.Tag = "Delete";
			this.btnPagElimina.Text = "Elimina";
			// 
			// btnPagModifica
			// 
			this.btnPagModifica.Location = new System.Drawing.Point(96, 16);
			this.btnPagModifica.Name = "btnPagModifica";
			this.btnPagModifica.Size = new System.Drawing.Size(69, 22);
			this.btnPagModifica.TabIndex = 5;
			this.btnPagModifica.Tag = "edit.anagrafica";
			this.btnPagModifica.Text = "Modifica...";
			// 
			// btnPagInserisci
			// 
			this.btnPagInserisci.Location = new System.Drawing.Point(16, 16);
			this.btnPagInserisci.Name = "btnPagInserisci";
			this.btnPagInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnPagInserisci.TabIndex = 4;
			this.btnPagInserisci.Tag = "Insert.anagrafica";
			this.btnPagInserisci.Text = "Inserisci...";
			// 
			// tabIndirizzo
			// 
			this.tabIndirizzo.Controls.Add(this.dgrIndirizzo);
			this.tabIndirizzo.Controls.Add(this.btnIndElimina);
			this.tabIndirizzo.Controls.Add(this.btnIndModifica);
			this.tabIndirizzo.Controls.Add(this.btnIndInserisci);
			this.tabIndirizzo.Location = new System.Drawing.Point(4, 23);
			this.tabIndirizzo.Name = "tabIndirizzo";
			this.tabIndirizzo.Size = new System.Drawing.Size(910, 499);
			this.tabIndirizzo.TabIndex = 3;
			this.tabIndirizzo.Text = "Indirizzi";
			this.tabIndirizzo.UseVisualStyleBackColor = true;
			// 
			// dgrIndirizzo
			// 
			this.dgrIndirizzo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrIndirizzo.CaptionVisible = false;
			this.dgrIndirizzo.DataMember = "";
			this.dgrIndirizzo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrIndirizzo.Location = new System.Drawing.Point(16, 48);
			this.dgrIndirizzo.Name = "dgrIndirizzo";
			this.dgrIndirizzo.ReadOnly = true;
			this.dgrIndirizzo.Size = new System.Drawing.Size(878, 445);
			this.dgrIndirizzo.TabIndex = 11;
			this.dgrIndirizzo.Tag = "registryaddress.anagraficasingle.anagraficasingle";
			// 
			// btnIndElimina
			// 
			this.btnIndElimina.Location = new System.Drawing.Point(176, 16);
			this.btnIndElimina.Name = "btnIndElimina";
			this.btnIndElimina.Size = new System.Drawing.Size(68, 22);
			this.btnIndElimina.TabIndex = 10;
			this.btnIndElimina.Tag = "delete";
			this.btnIndElimina.Text = "Elimina";
			// 
			// btnIndModifica
			// 
			this.btnIndModifica.Location = new System.Drawing.Point(96, 16);
			this.btnIndModifica.Name = "btnIndModifica";
			this.btnIndModifica.Size = new System.Drawing.Size(69, 22);
			this.btnIndModifica.TabIndex = 9;
			this.btnIndModifica.Tag = "edit.anagraficasingle";
			this.btnIndModifica.Text = "Modifica...";
			// 
			// btnIndInserisci
			// 
			this.btnIndInserisci.Location = new System.Drawing.Point(16, 16);
			this.btnIndInserisci.Name = "btnIndInserisci";
			this.btnIndInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnIndInserisci.TabIndex = 8;
			this.btnIndInserisci.Tag = "insert.anagraficasingle";
			this.btnIndInserisci.Text = "Inserisci...";
			// 
			// tabAltriDati
			// 
			this.tabAltriDati.Controls.Add(this.tabControl3);
			this.tabAltriDati.Location = new System.Drawing.Point(4, 23);
			this.tabAltriDati.Name = "tabAltriDati";
			this.tabAltriDati.Size = new System.Drawing.Size(910, 499);
			this.tabAltriDati.TabIndex = 9;
			this.tabAltriDati.Text = "Altri Dati";
			this.tabAltriDati.UseVisualStyleBackColor = true;
			// 
			// tabControl3
			// 
			this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl3.Controls.Add(this.tabPrincipale);
			this.tabControl3.Controls.Add(this.tabFatture);
			this.tabControl3.Controls.Add(this.tabClassificazioni);
			this.tabControl3.Controls.Add(this.tabAltro);
			this.tabControl3.Location = new System.Drawing.Point(8, 6);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(885, 490);
			this.tabControl3.TabIndex = 73;
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.Controls.Add(this.groupBox10);
			this.tabPrincipale.Controls.Add(this.groupBox5);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Size = new System.Drawing.Size(877, 464);
			this.tabPrincipale.TabIndex = 3;
			this.tabPrincipale.Text = "EP";
			this.tabPrincipale.UseVisualStyleBackColor = true;
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.textBox1);
			this.groupBox10.Controls.Add(this.txtCodiceCausaleDeb);
			this.groupBox10.Controls.Add(this.button9);
			this.groupBox10.Location = new System.Drawing.Point(7, 17);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(410, 80);
			this.groupBox10.TabIndex = 47;
			this.groupBox10.TabStop = false;
			this.groupBox10.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
			this.groupBox10.Text = "Causale di debito";
			this.groupBox10.UseCompatibleTextRendering = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(182, 13);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(222, 56);
			this.textBox1.TabIndex = 2;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "accmotiveapplied_debit.motive";
			// 
			// txtCodiceCausaleDeb
			// 
			this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(10, 48);
			this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
			this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(166, 20);
			this.txtCodiceCausaleDeb.TabIndex = 1;
			this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_debit.codemotive?registrymainview.codemotivedebit";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(8, 16);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(104, 23);
			this.button9.TabIndex = 0;
			this.button9.Tag = "manage.accmotiveapplied_debit.tree";
			this.button9.Text = "Causale";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.textBox2);
			this.groupBox5.Controls.Add(this.txtCodiceCausaleCredit);
			this.groupBox5.Controls.Add(this.button10);
			this.groupBox5.Location = new System.Drawing.Point(461, 17);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(370, 80);
			this.groupBox5.TabIndex = 48;
			this.groupBox5.TabStop = false;
			this.groupBox5.Tag = "AutoManage.txtCodiceCausaleCredit.tree.(in_use = \'S\')";
			this.groupBox5.Text = "Causale di credito";
			this.groupBox5.UseCompatibleTextRendering = true;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(120, 13);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(244, 56);
			this.textBox2.TabIndex = 2;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "accmotiveapplied_credit.motive";
			// 
			// txtCodiceCausaleCredit
			// 
			this.txtCodiceCausaleCredit.Location = new System.Drawing.Point(10, 48);
			this.txtCodiceCausaleCredit.Name = "txtCodiceCausaleCredit";
			this.txtCodiceCausaleCredit.Size = new System.Drawing.Size(104, 20);
			this.txtCodiceCausaleCredit.TabIndex = 1;
			this.txtCodiceCausaleCredit.Tag = "accmotiveapplied_credit.codemotive?registrymainview.codemotivecredit";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(8, 16);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(104, 23);
			this.button10.TabIndex = 0;
			this.button10.Tag = "manage.accmotiveapplied_credit.tree";
			this.button10.Text = "Causale";
			// 
			// tabFatture
			// 
			this.tabFatture.Controls.Add(this.textBox3);
			this.tabFatture.Controls.Add(this.groupBox7);
			this.tabFatture.Controls.Add(this.label12);
			this.tabFatture.Controls.Add(this.chhEntePubblico);
			this.tabFatture.Controls.Add(this.chkBankItaliaProceeds);
			this.tabFatture.Controls.Add(this.checkBox1);
			this.tabFatture.Controls.Add(this.label14);
			this.tabFatture.Controls.Add(this.textBox6);
			this.tabFatture.Location = new System.Drawing.Point(4, 22);
			this.tabFatture.Name = "tabFatture";
			this.tabFatture.Padding = new System.Windows.Forms.Padding(3);
			this.tabFatture.Size = new System.Drawing.Size(877, 464);
			this.tabFatture.TabIndex = 1;
			this.tabFatture.Text = "Fatture";
			this.tabFatture.UseVisualStyleBackColor = true;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(247, 13);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(83, 20);
			this.textBox3.TabIndex = 54;
			this.textBox3.Tag = "registry.ipa_fe";
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.textBox5);
			this.groupBox7.Controls.Add(this.label13);
			this.groupBox7.Controls.Add(this.txtIndirizzoEmail);
			this.groupBox7.Controls.Add(this.label10);
			this.groupBox7.Controls.Add(this.textBox4);
			this.groupBox7.Controls.Add(this.label11);
			this.groupBox7.Controls.Add(this.chkRifAmm);
			this.groupBox7.Location = new System.Drawing.Point(6, 84);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(671, 100);
			this.groupBox7.TabIndex = 64;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Fatturazione elettronica";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(72, 70);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(551, 20);
			this.textBox5.TabIndex = 71;
			this.textBox5.Tag = "registry.pec_fe";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(6, 74);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(65, 16);
			this.label13.TabIndex = 72;
			this.label13.Text = "Pec:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIndirizzoEmail
			// 
			this.txtIndirizzoEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIndirizzoEmail.Location = new System.Drawing.Point(72, 42);
			this.txtIndirizzoEmail.Name = "txtIndirizzoEmail";
			this.txtIndirizzoEmail.Size = new System.Drawing.Size(551, 20);
			this.txtIndirizzoEmail.TabIndex = 69;
			this.txtIndirizzoEmail.Tag = "registry.email_fe";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 46);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 16);
			this.label10.TabIndex = 70;
			this.label10.Text = "E-Mail:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(500, 18);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(123, 20);
			this.textBox4.TabIndex = 2;
			this.textBox4.Tag = "registry.sdi_defrifamm";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(249, 20);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(252, 13);
			this.label11.TabIndex = 1;
			this.label11.Text = "rif.amm. da assumere ove assente in fattura ricevuta";
			// 
			// chkRifAmm
			// 
			this.chkRifAmm.AutoSize = true;
			this.chkRifAmm.Location = new System.Drawing.Point(6, 19);
			this.chkRifAmm.Name = "chkRifAmm";
			this.chkRifAmm.Size = new System.Drawing.Size(186, 17);
			this.chkRifAmm.TabIndex = 0;
			this.chkRifAmm.Tag = "registry.sdi_norifamm:S:N";
			this.chkRifAmm.Text = "Non rifiutare in assenza di rif.amm.";
			this.chkRifAmm.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(73, 39);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(145, 19);
			this.label12.TabIndex = 71;
			this.label12.Text = "Codice IPA soggetto conferente PerlaPA";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chhEntePubblico
			// 
			this.chhEntePubblico.Location = new System.Drawing.Point(6, 229);
			this.chhEntePubblico.Name = "chhEntePubblico";
			this.chhEntePubblico.Size = new System.Drawing.Size(389, 28);
			this.chhEntePubblico.TabIndex = 63;
			this.chhEntePubblico.Tag = "registry.flag_pa:S:N";
			this.chhEntePubblico.Text = "Applica lo split payment  (per le fatture di vendita)";
			// 
			// chkBankItaliaProceeds
			// 
			this.chkBankItaliaProceeds.Location = new System.Drawing.Point(6, 202);
			this.chkBankItaliaProceeds.Name = "chkBankItaliaProceeds";
			this.chkBankItaliaProceeds.Size = new System.Drawing.Size(346, 28);
			this.chkBankItaliaProceeds.TabIndex = 52;
			this.chkBankItaliaProceeds.Tag = "registry.flagbankitaliaproceeds:S:N";
			this.chkBankItaliaProceeds.Text = "Regolarizzazione Riscossioni presso  T.P.S. - Banca d\'Italia";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(6, 263);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(303, 17);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Tag = "registry.authorization_free:S:N";
			this.checkBox1.Text = "Esente ai fini dell\'autorizzazione dell\' Agente di Riscossione";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(3, 13);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(216, 17);
			this.label14.TabIndex = 72;
			this.label14.Text = "Codice IPA/Codice destinatario per la FE";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(247, 39);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(83, 20);
			this.textBox6.TabIndex = 65;
			this.textBox6.Tag = "registry.ipa_perlapa";
			// 
			// tabClassificazioni
			// 
			this.tabClassificazioni.Controls.Add(this.label25);
			this.tabClassificazioni.Controls.Add(this.textBox9);
			this.tabClassificazioni.Controls.Add(this.groupBox12);
			this.tabClassificazioni.Controls.Add(this.groupBox8);
			this.tabClassificazioni.Controls.Add(this.groupBox3);
			this.tabClassificazioni.Location = new System.Drawing.Point(4, 22);
			this.tabClassificazioni.Name = "tabClassificazioni";
			this.tabClassificazioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabClassificazioni.Size = new System.Drawing.Size(877, 464);
			this.tabClassificazioni.TabIndex = 0;
			this.tabClassificazioni.Text = "Classificazioni";
			this.tabClassificazioni.UseVisualStyleBackColor = true;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(626, 13);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(50, 13);
			this.label25.TabIndex = 26;
			this.label25.Text = "Tipologia";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(699, 10);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(164, 20);
			this.textBox9.TabIndex = 25;
			this.textBox9.Tag = "registry.extension";
			// 
			// groupBox12
			// 
			this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox12.Controls.Add(this.label23);
			this.groupBox12.Controls.Add(this.label24);
			this.groupBox12.Controls.Add(this.cmbDip);
			this.groupBox12.Controls.Add(this.cmbNaturagiu);
			this.groupBox12.Controls.Add(this.grpNace);
			this.groupBox12.Controls.Add(this.gboxAteco);
			this.groupBox12.Location = new System.Drawing.Point(8, 119);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(863, 201);
			this.groupBox12.TabIndex = 18;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Enti e Aziende";
			this.groupBox12.Enter += new System.EventHandler(this.groupBox12_Enter);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(19, 150);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 13);
			this.label23.TabIndex = 24;
			this.label23.Text = "Numero dipartimenti";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(37, 114);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(81, 13);
			this.label24.TabIndex = 23;
			this.label24.Text = "Natura giuridica";
			// 
			// cmbDip
			// 
			this.cmbDip.DataSource = this.DS.numerodip;
			this.cmbDip.DisplayMember = "sortcode";
			this.cmbDip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDip.Location = new System.Drawing.Point(124, 147);
			this.cmbDip.Name = "cmbDip";
			this.cmbDip.Size = new System.Drawing.Size(328, 21);
			this.cmbDip.TabIndex = 22;
			this.cmbDip.Tag = "registry.idnumerodip";
			this.cmbDip.ValueMember = "idnumerodip";
			// 
			// cmbNaturagiu
			// 
			this.cmbNaturagiu.DataSource = this.DS.naturagiur;
			this.cmbNaturagiu.DisplayMember = "title";
			this.cmbNaturagiu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNaturagiu.Location = new System.Drawing.Point(124, 108);
			this.cmbNaturagiu.Name = "cmbNaturagiu";
			this.cmbNaturagiu.Size = new System.Drawing.Size(328, 21);
			this.cmbNaturagiu.TabIndex = 21;
			this.cmbNaturagiu.Tag = "registry.idnaturagiur";
			this.cmbNaturagiu.ValueMember = "idnaturagiur";
			// 
			// grpNace
			// 
			this.grpNace.Controls.Add(this.textBox7);
			this.grpNace.Controls.Add(this.textBox8);
			this.grpNace.Location = new System.Drawing.Point(454, 19);
			this.grpNace.Name = "grpNace";
			this.grpNace.Size = new System.Drawing.Size(393, 67);
			this.grpNace.TabIndex = 20;
			this.grpNace.TabStop = false;
			this.grpNace.Tag = "";
			this.grpNace.Text = "NACE";
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.Location = new System.Drawing.Point(8, 32);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(113, 20);
			this.textBox7.TabIndex = 5;
			this.textBox7.Tag = "nace.idnace?x";
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(127, 11);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(257, 44);
			this.textBox8.TabIndex = 4;
			this.textBox8.TabStop = false;
			this.textBox8.Tag = "nace.activity";
			// 
			// gboxAteco
			// 
			this.gboxAteco.Controls.Add(this.txtUPB);
			this.gboxAteco.Controls.Add(this.txtDescrUPB);
			this.gboxAteco.Location = new System.Drawing.Point(8, 19);
			this.gboxAteco.Name = "gboxAteco";
			this.gboxAteco.Size = new System.Drawing.Size(366, 67);
			this.gboxAteco.TabIndex = 19;
			this.gboxAteco.TabStop = false;
			this.gboxAteco.Tag = "";
			this.gboxAteco.Text = "ATECO";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(9, 33);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(121, 20);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "ateco.codice?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(135, 12);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(228, 44);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "ateco.title";
			// 
			// groupBox8
			// 
			this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox8.Controls.Add(this.label22);
			this.groupBox8.Controls.Add(this.cmbistituto);
			this.groupBox8.Location = new System.Drawing.Point(8, 37);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(863, 73);
			this.groupBox8.TabIndex = 16;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Docenti";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(22, 42);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(116, 13);
			this.label22.TabIndex = 85;
			this.label22.Text = "Istituto, Ente o Azienda";
			// 
			// cmbistituto
			// 
			this.cmbistituto.DataSource = this.DS.registry_istituti;
			this.cmbistituto.DisplayMember = "title";
			this.cmbistituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbistituto.Location = new System.Drawing.Point(144, 39);
			this.cmbistituto.Name = "cmbistituto";
			this.cmbistituto.Size = new System.Drawing.Size(618, 21);
			this.cmbistituto.TabIndex = 84;
			this.cmbistituto.Tag = "registry.idreg_istituti";
			this.cmbistituto.ValueMember = "idreg";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.buttonVecchiaClassificazione);
			this.groupBox3.Controls.Add(this.comboBoxVecchiaClassificazione);
			this.groupBox3.Controls.Add(this.cmdClassificazione);
			this.groupBox3.Controls.Add(this.cmbClassificazione);
			this.groupBox3.Location = new System.Drawing.Point(8, 346);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(863, 48);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Classificazioni";
			// 
			// buttonVecchiaClassificazione
			// 
			this.buttonVecchiaClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonVecchiaClassificazione.ImageIndex = 0;
			this.buttonVecchiaClassificazione.ImageList = this.imageList1;
			this.buttonVecchiaClassificazione.Location = new System.Drawing.Point(8, 16);
			this.buttonVecchiaClassificazione.Name = "buttonVecchiaClassificazione";
			this.buttonVecchiaClassificazione.Size = new System.Drawing.Size(104, 22);
			this.buttonVecchiaClassificazione.TabIndex = 1;
			this.buttonVecchiaClassificazione.Tag = "manage.registrykind.lista";
			this.buttonVecchiaClassificazione.Text = "Classificazione:";
			this.buttonVecchiaClassificazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// comboBoxVecchiaClassificazione
			// 
			this.comboBoxVecchiaClassificazione.DataSource = this.DS.registrykind;
			this.comboBoxVecchiaClassificazione.DisplayMember = "description";
			this.comboBoxVecchiaClassificazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxVecchiaClassificazione.Location = new System.Drawing.Point(112, 16);
			this.comboBoxVecchiaClassificazione.Name = "comboBoxVecchiaClassificazione";
			this.comboBoxVecchiaClassificazione.Size = new System.Drawing.Size(216, 21);
			this.comboBoxVecchiaClassificazione.TabIndex = 2;
			this.comboBoxVecchiaClassificazione.Tag = "registry.idregistrykind";
			this.comboBoxVecchiaClassificazione.ValueMember = "idregistrykind";
			// 
			// cmdClassificazione
			// 
			this.cmdClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.cmdClassificazione.ImageIndex = 0;
			this.cmdClassificazione.ImageList = this.imageList1;
			this.cmdClassificazione.Location = new System.Drawing.Point(333, 16);
			this.cmdClassificazione.Name = "cmdClassificazione";
			this.cmdClassificazione.Size = new System.Drawing.Size(129, 22);
			this.cmdClassificazione.TabIndex = 3;
			this.cmdClassificazione.Tag = "manage.centralizedcategory.lista";
			this.cmdClassificazione.Text = "Classif. centralizzata";
			this.cmdClassificazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbClassificazione
			// 
			this.cmbClassificazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbClassificazione.DataSource = this.DS.centralizedcategory;
			this.cmbClassificazione.DisplayMember = "description";
			this.cmbClassificazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClassificazione.Location = new System.Drawing.Point(462, 16);
			this.cmbClassificazione.Name = "cmbClassificazione";
			this.cmbClassificazione.Size = new System.Drawing.Size(393, 21);
			this.cmbClassificazione.TabIndex = 4;
			this.cmbClassificazione.Tag = "registry.idcentralizedcategory";
			this.cmbClassificazione.ValueMember = "idcentralizedcategory";
			// 
			// tabAltro
			// 
			this.tabAltro.Controls.Add(this.groupBox6);
			this.tabAltro.Controls.Add(this.txtDescrizione);
			this.tabAltro.Controls.Add(this.label6);
			this.tabAltro.Controls.Add(this.groupBox4);
			this.tabAltro.Location = new System.Drawing.Point(4, 22);
			this.tabAltro.Name = "tabAltro";
			this.tabAltro.Size = new System.Drawing.Size(877, 464);
			this.tabAltro.TabIndex = 2;
			this.tabAltro.Text = "Altro";
			this.tabAltro.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.txtCCP);
			this.groupBox6.Controls.Add(this.label8);
			this.groupBox6.Location = new System.Drawing.Point(13, 31);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(269, 48);
			this.groupBox6.TabIndex = 51;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Conto Corrente Postale";
			// 
			// txtCCP
			// 
			this.txtCCP.Location = new System.Drawing.Point(114, 20);
			this.txtCCP.Name = "txtCCP";
			this.txtCCP.Size = new System.Drawing.Size(138, 20);
			this.txtCCP.TabIndex = 50;
			this.txtCCP.Tag = "registry.ccp";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 26);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(99, 13);
			this.label8.TabIndex = 49;
			this.label8.Text = "CCP di Riscossione";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(13, 357);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrizione.Size = new System.Drawing.Size(849, 94);
			this.txtDescrizione.TabIndex = 4;
			this.txtDescrizione.Tag = "registry.annotation";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 330);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 19);
			this.label6.TabIndex = 46;
			this.label6.Text = "Annotazioni";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.cmbCategoria);
			this.groupBox4.Controls.Add(this.button5);
			this.groupBox4.Controls.Add(this.lblMatricolaext);
			this.groupBox4.Controls.Add(this.txtMatricolaext);
			this.groupBox4.Controls.Add(this.lblBadge);
			this.groupBox4.Controls.Add(this.txtBadge);
			this.groupBox4.Location = new System.Drawing.Point(13, 102);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(849, 50);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Altre Informazioni";
			// 
			// cmbCategoria
			// 
			this.cmbCategoria.DataSource = this.DS.category;
			this.cmbCategoria.DisplayMember = "description";
			this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCategoria.ItemHeight = 13;
			this.cmbCategoria.Location = new System.Drawing.Point(80, 16);
			this.cmbCategoria.Name = "cmbCategoria";
			this.cmbCategoria.Size = new System.Drawing.Size(160, 21);
			this.cmbCategoria.TabIndex = 2;
			this.cmbCategoria.Tag = "registry.idcategory";
			this.cmbCategoria.ValueMember = "idcategory";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(8, 16);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(70, 22);
			this.button5.TabIndex = 1;
			this.button5.Tag = "manage.category.default";
			this.button5.Text = "Categoria";
			// 
			// lblMatricolaext
			// 
			this.lblMatricolaext.Location = new System.Drawing.Point(486, 16);
			this.lblMatricolaext.Name = "lblMatricolaext";
			this.lblMatricolaext.Size = new System.Drawing.Size(56, 15);
			this.lblMatricolaext.TabIndex = 164;
			this.lblMatricolaext.Text = "Matricola";
			this.lblMatricolaext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtMatricolaext
			// 
			this.txtMatricolaext.Location = new System.Drawing.Point(550, 16);
			this.txtMatricolaext.Name = "txtMatricolaext";
			this.txtMatricolaext.Size = new System.Drawing.Size(87, 20);
			this.txtMatricolaext.TabIndex = 8;
			this.txtMatricolaext.Tag = "registry.extmatricula";
			// 
			// lblBadge
			// 
			this.lblBadge.Location = new System.Drawing.Point(312, 16);
			this.lblBadge.Name = "lblBadge";
			this.lblBadge.Size = new System.Drawing.Size(56, 15);
			this.lblBadge.TabIndex = 163;
			this.lblBadge.Text = "Badge";
			this.lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBadge
			// 
			this.txtBadge.Location = new System.Drawing.Point(376, 16);
			this.txtBadge.Name = "txtBadge";
			this.txtBadge.Size = new System.Drawing.Size(88, 20);
			this.txtBadge.TabIndex = 7;
			this.txtBadge.Tag = "registry.badgecode";
			// 
			// tabContatto
			// 
			this.tabContatto.Controls.Add(this.dgrContatto);
			this.tabContatto.Controls.Add(this.btnContElimina);
			this.tabContatto.Controls.Add(this.btnContModifica);
			this.tabContatto.Controls.Add(this.btnContInserisci);
			this.tabContatto.Location = new System.Drawing.Point(4, 23);
			this.tabContatto.Name = "tabContatto";
			this.tabContatto.Size = new System.Drawing.Size(910, 499);
			this.tabContatto.TabIndex = 6;
			this.tabContatto.Text = "Contatti";
			this.tabContatto.UseVisualStyleBackColor = true;
			// 
			// dgrContatto
			// 
			this.dgrContatto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrContatto.CaptionVisible = false;
			this.dgrContatto.DataMember = "";
			this.dgrContatto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrContatto.Location = new System.Drawing.Point(16, 48);
			this.dgrContatto.Name = "dgrContatto";
			this.dgrContatto.ReadOnly = true;
			this.dgrContatto.Size = new System.Drawing.Size(878, 445);
			this.dgrContatto.TabIndex = 11;
			this.dgrContatto.Tag = "registryreference.default.default";
			// 
			// btnContElimina
			// 
			this.btnContElimina.Location = new System.Drawing.Point(176, 16);
			this.btnContElimina.Name = "btnContElimina";
			this.btnContElimina.Size = new System.Drawing.Size(68, 22);
			this.btnContElimina.TabIndex = 10;
			this.btnContElimina.Tag = "delete";
			this.btnContElimina.Text = "Elimina";
			// 
			// btnContModifica
			// 
			this.btnContModifica.Location = new System.Drawing.Point(96, 16);
			this.btnContModifica.Name = "btnContModifica";
			this.btnContModifica.Size = new System.Drawing.Size(69, 22);
			this.btnContModifica.TabIndex = 9;
			this.btnContModifica.Tag = "edit.default";
			this.btnContModifica.Text = "Modifica...";
			// 
			// btnContInserisci
			// 
			this.btnContInserisci.Location = new System.Drawing.Point(16, 16);
			this.btnContInserisci.Name = "btnContInserisci";
			this.btnContInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnContInserisci.TabIndex = 8;
			this.btnContInserisci.Tag = "insert.default";
			this.btnContInserisci.Text = "Inserisci...";
			// 
			// tabPosGiuridica
			// 
			this.tabPosGiuridica.Controls.Add(this.groupBox2);
			this.tabPosGiuridica.Controls.Add(this.groupBox1);
			this.tabPosGiuridica.Location = new System.Drawing.Point(4, 23);
			this.tabPosGiuridica.Name = "tabPosGiuridica";
			this.tabPosGiuridica.Size = new System.Drawing.Size(910, 499);
			this.tabPosGiuridica.TabIndex = 4;
			this.tabPosGiuridica.Text = "Dati per Missioni";
			this.tabPosGiuridica.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.dgrPosRetributiva);
			this.groupBox2.Controls.Add(this.btnPosretElimina);
			this.groupBox2.Controls.Add(this.btnPosretModifica);
			this.groupBox2.Controls.Add(this.btnPosretInserisci);
			this.groupBox2.Location = new System.Drawing.Point(8, 216);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(894, 277);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Reddito Annuo Presunto";
			// 
			// dgrPosRetributiva
			// 
			this.dgrPosRetributiva.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrPosRetributiva.CaptionVisible = false;
			this.dgrPosRetributiva.DataMember = "";
			this.dgrPosRetributiva.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrPosRetributiva.Location = new System.Drawing.Point(16, 56);
			this.dgrPosRetributiva.Name = "dgrPosRetributiva";
			this.dgrPosRetributiva.ReadOnly = true;
			this.dgrPosRetributiva.Size = new System.Drawing.Size(870, 212);
			this.dgrPosRetributiva.TabIndex = 15;
			this.dgrPosRetributiva.Tag = "registrytaxablestatus.anagraficadetail.anagraficadetail";
			// 
			// btnPosretElimina
			// 
			this.btnPosretElimina.Location = new System.Drawing.Point(176, 24);
			this.btnPosretElimina.Name = "btnPosretElimina";
			this.btnPosretElimina.Size = new System.Drawing.Size(68, 22);
			this.btnPosretElimina.TabIndex = 14;
			this.btnPosretElimina.Tag = "delete";
			this.btnPosretElimina.Text = "Elimina";
			// 
			// btnPosretModifica
			// 
			this.btnPosretModifica.Location = new System.Drawing.Point(96, 24);
			this.btnPosretModifica.Name = "btnPosretModifica";
			this.btnPosretModifica.Size = new System.Drawing.Size(69, 22);
			this.btnPosretModifica.TabIndex = 13;
			this.btnPosretModifica.Tag = "edit.anagraficadetail";
			this.btnPosretModifica.Text = "Modifica...";
			// 
			// btnPosretInserisci
			// 
			this.btnPosretInserisci.Location = new System.Drawing.Point(16, 24);
			this.btnPosretInserisci.Name = "btnPosretInserisci";
			this.btnPosretInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnPosretInserisci.TabIndex = 12;
			this.btnPosretInserisci.Tag = "insert.anagraficadetail";
			this.btnPosretInserisci.Text = "Inserisci...";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.dgrPosGiuridica);
			this.groupBox1.Controls.Add(this.btnPosgiuElimina);
			this.groupBox1.Controls.Add(this.btnPosgiuModifica);
			this.groupBox1.Controls.Add(this.btnPosgiuInserisci);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(894, 200);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Inquadramento";
			// 
			// dgrPosGiuridica
			// 
			this.dgrPosGiuridica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrPosGiuridica.CaptionVisible = false;
			this.dgrPosGiuridica.DataMember = "";
			this.dgrPosGiuridica.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrPosGiuridica.Location = new System.Drawing.Point(16, 56);
			this.dgrPosGiuridica.Name = "dgrPosGiuridica";
			this.dgrPosGiuridica.ReadOnly = true;
			this.dgrPosGiuridica.Size = new System.Drawing.Size(870, 136);
			this.dgrPosGiuridica.TabIndex = 11;
			this.dgrPosGiuridica.Tag = "registrylegalstatus.anagraficadetail.anagraficadetail";
			// 
			// btnPosgiuElimina
			// 
			this.btnPosgiuElimina.Location = new System.Drawing.Point(176, 24);
			this.btnPosgiuElimina.Name = "btnPosgiuElimina";
			this.btnPosgiuElimina.Size = new System.Drawing.Size(68, 22);
			this.btnPosgiuElimina.TabIndex = 10;
			this.btnPosgiuElimina.Tag = "delete";
			this.btnPosgiuElimina.Text = "Elimina";
			// 
			// btnPosgiuModifica
			// 
			this.btnPosgiuModifica.Location = new System.Drawing.Point(96, 24);
			this.btnPosgiuModifica.Name = "btnPosgiuModifica";
			this.btnPosgiuModifica.Size = new System.Drawing.Size(69, 22);
			this.btnPosgiuModifica.TabIndex = 9;
			this.btnPosgiuModifica.Tag = "edit.anagraficadetail";
			this.btnPosgiuModifica.Text = "Modifica...";
			// 
			// btnPosgiuInserisci
			// 
			this.btnPosgiuInserisci.Location = new System.Drawing.Point(16, 24);
			this.btnPosgiuInserisci.Name = "btnPosgiuInserisci";
			this.btnPosgiuInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnPosgiuInserisci.TabIndex = 8;
			this.btnPosgiuInserisci.Tag = "insert.anagraficadetail";
			this.btnPosgiuInserisci.Text = "Inserisci...";
			// 
			// tabClassSup
			// 
			this.tabClassSup.Controls.Add(this.dgrClassSupp);
			this.tabClassSup.Controls.Add(this.btnClassElimina);
			this.tabClassSup.Controls.Add(this.btnClassModifica);
			this.tabClassSup.Controls.Add(this.btnClassInserisci);
			this.tabClassSup.ImageIndex = 0;
			this.tabClassSup.Location = new System.Drawing.Point(4, 23);
			this.tabClassSup.Name = "tabClassSup";
			this.tabClassSup.Size = new System.Drawing.Size(910, 499);
			this.tabClassSup.TabIndex = 7;
			this.tabClassSup.Text = "Classificazione";
			this.tabClassSup.UseVisualStyleBackColor = true;
			// 
			// dgrClassSupp
			// 
			this.dgrClassSupp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrClassSupp.CaptionVisible = false;
			this.dgrClassSupp.DataMember = "";
			this.dgrClassSupp.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrClassSupp.Location = new System.Drawing.Point(16, 48);
			this.dgrClassSupp.Name = "dgrClassSupp";
			this.dgrClassSupp.ReadOnly = true;
			this.dgrClassSupp.Size = new System.Drawing.Size(878, 445);
			this.dgrClassSupp.TabIndex = 15;
			this.dgrClassSupp.Tag = "registrysorting.default.default";
			// 
			// btnClassElimina
			// 
			this.btnClassElimina.Location = new System.Drawing.Point(176, 16);
			this.btnClassElimina.Name = "btnClassElimina";
			this.btnClassElimina.Size = new System.Drawing.Size(68, 22);
			this.btnClassElimina.TabIndex = 14;
			this.btnClassElimina.Tag = "delete";
			this.btnClassElimina.Text = "Elimina";
			// 
			// btnClassModifica
			// 
			this.btnClassModifica.Location = new System.Drawing.Point(96, 16);
			this.btnClassModifica.Name = "btnClassModifica";
			this.btnClassModifica.Size = new System.Drawing.Size(69, 22);
			this.btnClassModifica.TabIndex = 13;
			this.btnClassModifica.Tag = "edit.default";
			this.btnClassModifica.Text = "Modifica...";
			// 
			// btnClassInserisci
			// 
			this.btnClassInserisci.Location = new System.Drawing.Point(16, 16);
			this.btnClassInserisci.Name = "btnClassInserisci";
			this.btnClassInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnClassInserisci.TabIndex = 12;
			this.btnClassInserisci.Tag = "insert.default";
			this.btnClassInserisci.Text = "Inserisci...";
			// 
			// tabCF
			// 
			this.tabCF.Controls.Add(this.grpCV);
			this.tabCF.Controls.Add(this.grpPIVA);
			this.tabCF.Controls.Add(this.grpCF);
			this.tabCF.Location = new System.Drawing.Point(4, 23);
			this.tabCF.Name = "tabCF";
			this.tabCF.Size = new System.Drawing.Size(910, 499);
			this.tabCF.TabIndex = 10;
			this.tabCF.Text = "CV e Dati Storici";
			this.tabCF.UseVisualStyleBackColor = true;
			// 
			// grpCV
			// 
			this.grpCV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpCV.Controls.Add(this.datagrid3);
			this.grpCV.Controls.Add(this.button22);
			this.grpCV.Controls.Add(this.button21);
			this.grpCV.Controls.Add(this.button20);
			this.grpCV.Location = new System.Drawing.Point(8, 3);
			this.grpCV.Name = "grpCV";
			this.grpCV.Size = new System.Drawing.Size(897, 268);
			this.grpCV.TabIndex = 18;
			this.grpCV.TabStop = false;
			// 
			// datagrid3
			// 
			this.datagrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.datagrid3.CaptionVisible = false;
			this.datagrid3.DataMember = "";
			this.datagrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.datagrid3.Location = new System.Drawing.Point(8, 42);
			this.datagrid3.Name = "datagrid3";
			this.datagrid3.ReadOnly = true;
			this.datagrid3.Size = new System.Drawing.Size(883, 221);
			this.datagrid3.TabIndex = 16;
			this.datagrid3.Tag = "registrycvattachment.lista.default";
			// 
			// button22
			// 
			this.button22.Location = new System.Drawing.Point(168, 13);
			this.button22.Name = "button22";
			this.button22.Size = new System.Drawing.Size(69, 22);
			this.button22.TabIndex = 2;
			this.button22.Tag = "delete";
			this.button22.Text = "Elimina";
			this.button22.UseVisualStyleBackColor = true;
			// 
			// button21
			// 
			this.button21.Location = new System.Drawing.Point(88, 13);
			this.button21.Name = "button21";
			this.button21.Size = new System.Drawing.Size(69, 22);
			this.button21.TabIndex = 1;
			this.button21.Tag = "edit.default";
			this.button21.Text = "Modifica...";
			this.button21.UseVisualStyleBackColor = true;
			// 
			// button20
			// 
			this.button20.Location = new System.Drawing.Point(9, 13);
			this.button20.Name = "button20";
			this.button20.Size = new System.Drawing.Size(68, 22);
			this.button20.TabIndex = 0;
			this.button20.Tag = "insert.default";
			this.button20.Text = "Inserisci...";
			this.button20.UseVisualStyleBackColor = true;
			// 
			// grpPIVA
			// 
			this.grpPIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpPIVA.Controls.Add(this.label4);
			this.grpPIVA.Controls.Add(this.button6);
			this.grpPIVA.Controls.Add(this.dataGrid2);
			this.grpPIVA.Controls.Add(this.button7);
			this.grpPIVA.Controls.Add(this.button8);
			this.grpPIVA.Location = new System.Drawing.Point(8, 277);
			this.grpPIVA.Name = "grpPIVA";
			this.grpPIVA.Size = new System.Drawing.Size(409, 223);
			this.grpPIVA.TabIndex = 17;
			this.grpPIVA.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(297, 25);
			this.label4.TabIndex = 17;
			this.label4.Text = "Inserire le partite IVA vecchie e, se si vuole anche la corrente";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(8, 19);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(68, 22);
			this.button6.TabIndex = 12;
			this.button6.Tag = "insert.default";
			this.button6.Text = "Inserisci...";
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(5, 69);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.ReadOnly = true;
			this.dataGrid2.Size = new System.Drawing.Size(397, 149);
			this.dataGrid2.TabIndex = 15;
			this.dataGrid2.Tag = "registrypiva.default.default";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(88, 19);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(69, 22);
			this.button7.TabIndex = 13;
			this.button7.Tag = "edit.default";
			this.button7.Text = "Modifica...";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(168, 19);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(68, 22);
			this.button8.TabIndex = 14;
			this.button8.Tag = "delete";
			this.button8.Text = "Elimina";
			// 
			// grpCF
			// 
			this.grpCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.grpCF.Controls.Add(this.label3);
			this.grpCF.Controls.Add(this.button3);
			this.grpCF.Controls.Add(this.dataGrid1);
			this.grpCF.Controls.Add(this.button2);
			this.grpCF.Controls.Add(this.button1);
			this.grpCF.Location = new System.Drawing.Point(488, 277);
			this.grpCF.Name = "grpCF";
			this.grpCF.Size = new System.Drawing.Size(417, 224);
			this.grpCF.TabIndex = 16;
			this.grpCF.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(322, 23);
			this.label3.TabIndex = 16;
			this.label3.Text = "Inserire solamente i vecchi codici fiscali e non quello attuale dell\'anagrafica";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 19);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(68, 22);
			this.button3.TabIndex = 12;
			this.button3.Tag = "insert.default";
			this.button3.Text = "Inserisci...";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(6, 69);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(405, 149);
			this.dataGrid1.TabIndex = 15;
			this.dataGrid1.Tag = "registrycf.default.default";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(88, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(69, 22);
			this.button2.TabIndex = 13;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Modifica...";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(168, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(68, 22);
			this.button1.TabIndex = 14;
			this.button1.Tag = "delete";
			this.button1.Text = "Elimina";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lblStatoDurc);
			this.tabPage1.Controls.Add(this.dtgDurc);
			this.tabPage1.Controls.Add(this.button11);
			this.tabPage1.Controls.Add(this.button12);
			this.tabPage1.Controls.Add(this.button13);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(910, 499);
			this.tabPage1.TabIndex = 11;
			this.tabPage1.Text = "DURC";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// lblStatoDurc
			// 
			this.lblStatoDurc.AutoSize = true;
			this.lblStatoDurc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatoDurc.Location = new System.Drawing.Point(319, 19);
			this.lblStatoDurc.Name = "lblStatoDurc";
			this.lblStatoDurc.Size = new System.Drawing.Size(76, 13);
			this.lblStatoDurc.TabIndex = 16;
			this.lblStatoDurc.Text = "Stato DURC";
			// 
			// dtgDurc
			// 
			this.dtgDurc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtgDurc.CaptionVisible = false;
			this.dtgDurc.DataMember = "";
			this.dtgDurc.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgDurc.Location = new System.Drawing.Point(16, 48);
			this.dtgDurc.Name = "dtgDurc";
			this.dtgDurc.ReadOnly = true;
			this.dtgDurc.Size = new System.Drawing.Size(878, 445);
			this.dtgDurc.TabIndex = 15;
			this.dtgDurc.Tag = "registrydurc.anagraficadetail.anagraficadetail";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(176, 16);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(68, 22);
			this.button11.TabIndex = 14;
			this.button11.Tag = "delete";
			this.button11.Text = "Elimina";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(96, 16);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(69, 22);
			this.button12.TabIndex = 13;
			this.button12.Tag = "edit.anagraficadetail";
			this.button12.Text = "Modifica...";
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(16, 16);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(68, 22);
			this.button13.TabIndex = 12;
			this.button13.Tag = "insert.anagraficadetail";
			this.button13.Text = "Inserisci...";
			// 
			// tabDocAmm
			// 
			this.tabDocAmm.Controls.Add(this.tabControl2);
			this.tabDocAmm.Location = new System.Drawing.Point(4, 23);
			this.tabDocAmm.Name = "tabDocAmm";
			this.tabDocAmm.Size = new System.Drawing.Size(910, 499);
			this.tabDocAmm.TabIndex = 14;
			this.tabDocAmm.Text = "Documenti Amministrativi";
			this.tabDocAmm.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabVisura);
			this.tabControl2.Controls.Add(this.tabCasellarioG);
			this.tabControl2.Controls.Add(this.tabCasellarioA);
			this.tabControl2.Controls.Add(this.tabOttempLegge68_99);
			this.tabControl2.Controls.Add(this.tabRegolaritaFiscale);
			this.tabControl2.Controls.Add(this.tabVerificaAnac);
			this.tabControl2.Controls.Add(this.tabPattointegrita);
			this.tabControl2.Location = new System.Drawing.Point(2, 3);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(907, 497);
			this.tabControl2.TabIndex = 20;
			// 
			// tabVisura
			// 
			this.tabVisura.Controls.Add(this.label15);
			this.tabVisura.Controls.Add(this.dataGrid5);
			this.tabVisura.Controls.Add(this.button19);
			this.tabVisura.Controls.Add(this.button17);
			this.tabVisura.Controls.Add(this.button18);
			this.tabVisura.Location = new System.Drawing.Point(4, 22);
			this.tabVisura.Name = "tabVisura";
			this.tabVisura.Padding = new System.Windows.Forms.Padding(3);
			this.tabVisura.Size = new System.Drawing.Size(899, 471);
			this.tabVisura.TabIndex = 0;
			this.tabVisura.Text = "Visura";
			this.tabVisura.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(319, 19);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(113, 15);
			this.label15.TabIndex = 20;
			this.label15.Text = "Visura Camerale";
			// 
			// dataGrid5
			// 
			this.dataGrid5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid5.CaptionVisible = false;
			this.dataGrid5.DataMember = "";
			this.dataGrid5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid5.Location = new System.Drawing.Point(5, 48);
			this.dataGrid5.Name = "dataGrid5";
			this.dataGrid5.ReadOnly = true;
			this.dataGrid5.Size = new System.Drawing.Size(881, 411);
			this.dataGrid5.TabIndex = 19;
			this.dataGrid5.Tag = "registryvisura.anagraficadetail.anagraficadetail";
			// 
			// button19
			// 
			this.button19.Location = new System.Drawing.Point(5, 21);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(68, 21);
			this.button19.TabIndex = 16;
			this.button19.Tag = "insert.anagraficadetail";
			this.button19.Text = "Inserisci...";
			// 
			// button17
			// 
			this.button17.Location = new System.Drawing.Point(167, 21);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(69, 21);
			this.button17.TabIndex = 18;
			this.button17.Tag = "delete";
			this.button17.Text = "Elimina";
			// 
			// button18
			// 
			this.button18.Location = new System.Drawing.Point(87, 21);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(68, 21);
			this.button18.TabIndex = 17;
			this.button18.Tag = "edit.anagraficadetail";
			this.button18.Text = "Modifica...";
			// 
			// tabCasellarioG
			// 
			this.tabCasellarioG.Controls.Add(this.label16);
			this.tabCasellarioG.Controls.Add(this.dataGrid6);
			this.tabCasellarioG.Controls.Add(this.button25);
			this.tabCasellarioG.Controls.Add(this.button24);
			this.tabCasellarioG.Controls.Add(this.button23);
			this.tabCasellarioG.Location = new System.Drawing.Point(4, 22);
			this.tabCasellarioG.Name = "tabCasellarioG";
			this.tabCasellarioG.Padding = new System.Windows.Forms.Padding(3);
			this.tabCasellarioG.Size = new System.Drawing.Size(899, 471);
			this.tabCasellarioG.TabIndex = 1;
			this.tabCasellarioG.Text = "Casellario Giudiziale";
			this.tabCasellarioG.UseVisualStyleBackColor = true;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(319, 19);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(141, 15);
			this.label16.TabIndex = 4;
			this.label16.Text = "Casellario Giudiziale";
			// 
			// dataGrid6
			// 
			this.dataGrid6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid6.CaptionVisible = false;
			this.dataGrid6.DataMember = "";
			this.dataGrid6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid6.Location = new System.Drawing.Point(5, 48);
			this.dataGrid6.Name = "dataGrid6";
			this.dataGrid6.Size = new System.Drawing.Size(881, 409);
			this.dataGrid6.TabIndex = 3;
			this.dataGrid6.Tag = "registrycasellariogiudiziale.anagraficadetail.anagraficadetail";
			// 
			// button25
			// 
			this.button25.Location = new System.Drawing.Point(167, 21);
			this.button25.Name = "button25";
			this.button25.Size = new System.Drawing.Size(69, 21);
			this.button25.TabIndex = 2;
			this.button25.Tag = "delete";
			this.button25.Text = "Elimina";
			this.button25.UseVisualStyleBackColor = true;
			// 
			// button24
			// 
			this.button24.Location = new System.Drawing.Point(87, 21);
			this.button24.Name = "button24";
			this.button24.Size = new System.Drawing.Size(68, 21);
			this.button24.TabIndex = 1;
			this.button24.Tag = "edit.anagraficadetail";
			this.button24.Text = "Modifica...";
			this.button24.UseVisualStyleBackColor = true;
			// 
			// button23
			// 
			this.button23.Location = new System.Drawing.Point(5, 21);
			this.button23.Name = "button23";
			this.button23.Size = new System.Drawing.Size(68, 21);
			this.button23.TabIndex = 0;
			this.button23.Tag = "insert.anagraficadetail";
			this.button23.Text = "Inserisci...";
			this.button23.UseVisualStyleBackColor = true;
			// 
			// tabCasellarioA
			// 
			this.tabCasellarioA.Controls.Add(this.label17);
			this.tabCasellarioA.Controls.Add(this.dataGrid7);
			this.tabCasellarioA.Controls.Add(this.button28);
			this.tabCasellarioA.Controls.Add(this.button27);
			this.tabCasellarioA.Controls.Add(this.button26);
			this.tabCasellarioA.Location = new System.Drawing.Point(4, 22);
			this.tabCasellarioA.Name = "tabCasellarioA";
			this.tabCasellarioA.Padding = new System.Windows.Forms.Padding(3);
			this.tabCasellarioA.Size = new System.Drawing.Size(899, 471);
			this.tabCasellarioA.TabIndex = 1;
			this.tabCasellarioA.Text = "Casellario Amministrativo";
			this.tabCasellarioA.UseVisualStyleBackColor = true;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(319, 19);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(170, 15);
			this.label17.TabIndex = 4;
			this.label17.Text = "Casellario Amministrativo";
			// 
			// dataGrid7
			// 
			this.dataGrid7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid7.CaptionVisible = false;
			this.dataGrid7.DataMember = "";
			this.dataGrid7.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid7.Location = new System.Drawing.Point(5, 48);
			this.dataGrid7.Name = "dataGrid7";
			this.dataGrid7.Size = new System.Drawing.Size(881, 409);
			this.dataGrid7.TabIndex = 3;
			this.dataGrid7.Tag = "registrycasellarioamministrativo.anagraficadetail.anagraficadetail";
			// 
			// button28
			// 
			this.button28.Location = new System.Drawing.Point(167, 21);
			this.button28.Name = "button28";
			this.button28.Size = new System.Drawing.Size(69, 21);
			this.button28.TabIndex = 2;
			this.button28.Tag = "delete";
			this.button28.Text = "Elimina";
			this.button28.UseVisualStyleBackColor = true;
			// 
			// button27
			// 
			this.button27.Location = new System.Drawing.Point(87, 21);
			this.button27.Name = "button27";
			this.button27.Size = new System.Drawing.Size(68, 21);
			this.button27.TabIndex = 1;
			this.button27.Tag = "edit.anagraficadetail";
			this.button27.Text = "Modifica...";
			this.button27.UseVisualStyleBackColor = true;
			// 
			// button26
			// 
			this.button26.Location = new System.Drawing.Point(5, 21);
			this.button26.Name = "button26";
			this.button26.Size = new System.Drawing.Size(68, 21);
			this.button26.TabIndex = 0;
			this.button26.Tag = "insert.anagraficadetail";
			this.button26.Text = "Inserisci...";
			this.button26.UseVisualStyleBackColor = true;
			// 
			// tabOttempLegge68_99
			// 
			this.tabOttempLegge68_99.Controls.Add(this.label18);
			this.tabOttempLegge68_99.Controls.Add(this.dataGrid8);
			this.tabOttempLegge68_99.Controls.Add(this.button29);
			this.tabOttempLegge68_99.Controls.Add(this.button30);
			this.tabOttempLegge68_99.Controls.Add(this.button31);
			this.tabOttempLegge68_99.Location = new System.Drawing.Point(4, 22);
			this.tabOttempLegge68_99.Name = "tabOttempLegge68_99";
			this.tabOttempLegge68_99.Padding = new System.Windows.Forms.Padding(3);
			this.tabOttempLegge68_99.Size = new System.Drawing.Size(899, 471);
			this.tabOttempLegge68_99.TabIndex = 2;
			this.tabOttempLegge68_99.Text = "Ottemperanza Legge 68/99";
			this.tabOttempLegge68_99.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.Location = new System.Drawing.Point(319, 19);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(181, 15);
			this.label18.TabIndex = 8;
			this.label18.Text = "Ottemperanza Legge 68/99";
			// 
			// dataGrid8
			// 
			this.dataGrid8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid8.CaptionVisible = false;
			this.dataGrid8.DataMember = "";
			this.dataGrid8.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid8.Location = new System.Drawing.Point(5, 48);
			this.dataGrid8.Name = "dataGrid8";
			this.dataGrid8.Size = new System.Drawing.Size(881, 409);
			this.dataGrid8.TabIndex = 7;
			this.dataGrid8.Tag = "registryottemperanzalegge68_99.anagraficadetail.anagraficadetail";
			// 
			// button29
			// 
			this.button29.Location = new System.Drawing.Point(167, 21);
			this.button29.Name = "button29";
			this.button29.Size = new System.Drawing.Size(69, 21);
			this.button29.TabIndex = 6;
			this.button29.Tag = "delete";
			this.button29.Text = "Elimina";
			this.button29.UseVisualStyleBackColor = true;
			// 
			// button30
			// 
			this.button30.Location = new System.Drawing.Point(87, 21);
			this.button30.Name = "button30";
			this.button30.Size = new System.Drawing.Size(68, 21);
			this.button30.TabIndex = 5;
			this.button30.Tag = "edit.anagraficadetail";
			this.button30.Text = "Modifica...";
			this.button30.UseVisualStyleBackColor = true;
			// 
			// button31
			// 
			this.button31.Location = new System.Drawing.Point(5, 21);
			this.button31.Name = "button31";
			this.button31.Size = new System.Drawing.Size(68, 21);
			this.button31.TabIndex = 4;
			this.button31.Tag = "insert.anagraficadetail";
			this.button31.Text = "Inserisci...";
			this.button31.UseVisualStyleBackColor = true;
			// 
			// tabRegolaritaFiscale
			// 
			this.tabRegolaritaFiscale.Controls.Add(this.label19);
			this.tabRegolaritaFiscale.Controls.Add(this.dataGrid9);
			this.tabRegolaritaFiscale.Controls.Add(this.button32);
			this.tabRegolaritaFiscale.Controls.Add(this.button33);
			this.tabRegolaritaFiscale.Controls.Add(this.button34);
			this.tabRegolaritaFiscale.Location = new System.Drawing.Point(4, 22);
			this.tabRegolaritaFiscale.Name = "tabRegolaritaFiscale";
			this.tabRegolaritaFiscale.Padding = new System.Windows.Forms.Padding(3);
			this.tabRegolaritaFiscale.Size = new System.Drawing.Size(899, 471);
			this.tabRegolaritaFiscale.TabIndex = 3;
			this.tabRegolaritaFiscale.Text = "Regolarit� Fiscale";
			this.tabRegolaritaFiscale.UseVisualStyleBackColor = true;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.Location = new System.Drawing.Point(319, 19);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(124, 15);
			this.label19.TabIndex = 12;
			this.label19.Text = "Regolarit� Fiscale";
			// 
			// dataGrid9
			// 
			this.dataGrid9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid9.CaptionVisible = false;
			this.dataGrid9.DataMember = "";
			this.dataGrid9.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid9.Location = new System.Drawing.Point(5, 48);
			this.dataGrid9.Name = "dataGrid9";
			this.dataGrid9.Size = new System.Drawing.Size(881, 409);
			this.dataGrid9.TabIndex = 11;
			this.dataGrid9.Tag = "registryregolaritafiscale.anagraficadetail.anagraficadetail";
			// 
			// button32
			// 
			this.button32.Location = new System.Drawing.Point(167, 21);
			this.button32.Name = "button32";
			this.button32.Size = new System.Drawing.Size(69, 21);
			this.button32.TabIndex = 10;
			this.button32.Tag = "delete";
			this.button32.Text = "Elimina";
			this.button32.UseVisualStyleBackColor = true;
			// 
			// button33
			// 
			this.button33.Location = new System.Drawing.Point(87, 21);
			this.button33.Name = "button33";
			this.button33.Size = new System.Drawing.Size(68, 21);
			this.button33.TabIndex = 9;
			this.button33.Tag = "edit.anagraficadetail";
			this.button33.Text = "Modifica...";
			this.button33.UseVisualStyleBackColor = true;
			// 
			// button34
			// 
			this.button34.Location = new System.Drawing.Point(5, 21);
			this.button34.Name = "button34";
			this.button34.Size = new System.Drawing.Size(68, 21);
			this.button34.TabIndex = 8;
			this.button34.Tag = "insert.anagraficadetail";
			this.button34.Text = "Inserisci...";
			this.button34.UseVisualStyleBackColor = true;
			// 
			// tabVerificaAnac
			// 
			this.tabVerificaAnac.Controls.Add(this.label20);
			this.tabVerificaAnac.Controls.Add(this.dataGrid10);
			this.tabVerificaAnac.Controls.Add(this.button35);
			this.tabVerificaAnac.Controls.Add(this.button36);
			this.tabVerificaAnac.Controls.Add(this.button37);
			this.tabVerificaAnac.Location = new System.Drawing.Point(4, 22);
			this.tabVerificaAnac.Name = "tabVerificaAnac";
			this.tabVerificaAnac.Padding = new System.Windows.Forms.Padding(3);
			this.tabVerificaAnac.Size = new System.Drawing.Size(899, 471);
			this.tabVerificaAnac.TabIndex = 4;
			this.tabVerificaAnac.Text = "Verifica Anac";
			this.tabVerificaAnac.UseVisualStyleBackColor = true;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.Location = new System.Drawing.Point(319, 19);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(94, 15);
			this.label20.TabIndex = 16;
			this.label20.Text = "Verifica ANAC";
			// 
			// dataGrid10
			// 
			this.dataGrid10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid10.CaptionVisible = false;
			this.dataGrid10.DataMember = "";
			this.dataGrid10.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid10.Location = new System.Drawing.Point(5, 48);
			this.dataGrid10.Name = "dataGrid10";
			this.dataGrid10.Size = new System.Drawing.Size(881, 409);
			this.dataGrid10.TabIndex = 15;
			this.dataGrid10.Tag = "registryverificaanac.anagraficadetail.anagraficadetail";
			// 
			// button35
			// 
			this.button35.Location = new System.Drawing.Point(167, 21);
			this.button35.Name = "button35";
			this.button35.Size = new System.Drawing.Size(69, 21);
			this.button35.TabIndex = 14;
			this.button35.Tag = "delete";
			this.button35.Text = "Elimina";
			this.button35.UseVisualStyleBackColor = true;
			// 
			// button36
			// 
			this.button36.Location = new System.Drawing.Point(87, 21);
			this.button36.Name = "button36";
			this.button36.Size = new System.Drawing.Size(68, 21);
			this.button36.TabIndex = 13;
			this.button36.Tag = "edit.anagraficadetail";
			this.button36.Text = "Modifica...";
			this.button36.UseVisualStyleBackColor = true;
			// 
			// button37
			// 
			this.button37.Location = new System.Drawing.Point(5, 21);
			this.button37.Name = "button37";
			this.button37.Size = new System.Drawing.Size(68, 21);
			this.button37.TabIndex = 12;
			this.button37.Tag = "insert.anagraficadetail";
			this.button37.Text = "Inserisci...";
			this.button37.UseVisualStyleBackColor = true;
			// 
			// tabPattointegrita
			// 
			this.tabPattointegrita.Controls.Add(this.label21);
			this.tabPattointegrita.Controls.Add(this.dgridPattointegrita);
			this.tabPattointegrita.Controls.Add(this.button38);
			this.tabPattointegrita.Controls.Add(this.button39);
			this.tabPattointegrita.Controls.Add(this.button40);
			this.tabPattointegrita.Location = new System.Drawing.Point(4, 22);
			this.tabPattointegrita.Name = "tabPattointegrita";
			this.tabPattointegrita.Size = new System.Drawing.Size(899, 471);
			this.tabPattointegrita.TabIndex = 5;
			this.tabPattointegrita.Text = "Patto di integrit�";
			this.tabPattointegrita.UseVisualStyleBackColor = true;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.Location = new System.Drawing.Point(323, 15);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(113, 15);
			this.label21.TabIndex = 25;
			this.label21.Text = "Patto di Integrit�";
			// 
			// dgridPattointegrita
			// 
			this.dgridPattointegrita.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgridPattointegrita.CaptionVisible = false;
			this.dgridPattointegrita.DataMember = "";
			this.dgridPattointegrita.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridPattointegrita.Location = new System.Drawing.Point(9, 44);
			this.dgridPattointegrita.Name = "dgridPattointegrita";
			this.dgridPattointegrita.ReadOnly = true;
			this.dgridPattointegrita.Size = new System.Drawing.Size(881, 411);
			this.dgridPattointegrita.TabIndex = 24;
			this.dgridPattointegrita.Tag = "registrypattointegrita.anagraficadetail.anagraficadetail";
			// 
			// button38
			// 
			this.button38.Location = new System.Drawing.Point(9, 17);
			this.button38.Name = "button38";
			this.button38.Size = new System.Drawing.Size(68, 21);
			this.button38.TabIndex = 21;
			this.button38.Tag = "insert.anagraficadetail";
			this.button38.Text = "Inserisci...";
			// 
			// button39
			// 
			this.button39.Location = new System.Drawing.Point(171, 17);
			this.button39.Name = "button39";
			this.button39.Size = new System.Drawing.Size(69, 21);
			this.button39.TabIndex = 23;
			this.button39.Tag = "delete";
			this.button39.Text = "Elimina";
			// 
			// button40
			// 
			this.button40.Location = new System.Drawing.Point(91, 17);
			this.button40.Name = "button40";
			this.button40.Size = new System.Drawing.Size(68, 21);
			this.button40.TabIndex = 22;
			this.button40.Tag = "edit.anagraficadetail";
			this.button40.Text = "Modifica...";
			// 
			// tabAllegati
			// 
			this.tabAllegati.Controls.Add(this.dataGrid11);
			this.tabAllegati.Controls.Add(this.btnDelAtt);
			this.tabAllegati.Controls.Add(this.btnEditAtt);
			this.tabAllegati.Controls.Add(this.btnInsAtt);
			this.tabAllegati.Location = new System.Drawing.Point(4, 23);
			this.tabAllegati.Name = "tabAllegati";
			this.tabAllegati.Padding = new System.Windows.Forms.Padding(3);
			this.tabAllegati.Size = new System.Drawing.Size(910, 499);
			this.tabAllegati.TabIndex = 15;
			this.tabAllegati.Text = "Allegati";
			this.tabAllegati.UseVisualStyleBackColor = true;
			// 
			// dataGrid11
			// 
			this.dataGrid11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid11.DataMember = "";
			this.dataGrid11.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid11.Location = new System.Drawing.Point(7, 42);
			this.dataGrid11.Name = "dataGrid11";
			this.dataGrid11.ReadOnly = true;
			this.dataGrid11.Size = new System.Drawing.Size(895, 451);
			this.dataGrid11.TabIndex = 23;
			this.dataGrid11.Tag = "registryattachment.lista.default";
			// 
			// btnDelAtt
			// 
			this.btnDelAtt.Location = new System.Drawing.Point(198, 7);
			this.btnDelAtt.Name = "btnDelAtt";
			this.btnDelAtt.Size = new System.Drawing.Size(82, 28);
			this.btnDelAtt.TabIndex = 22;
			this.btnDelAtt.Tag = "delete";
			this.btnDelAtt.Text = "Elimina";
			// 
			// btnEditAtt
			// 
			this.btnEditAtt.Location = new System.Drawing.Point(102, 7);
			this.btnEditAtt.Name = "btnEditAtt";
			this.btnEditAtt.Size = new System.Drawing.Size(83, 28);
			this.btnEditAtt.TabIndex = 21;
			this.btnEditAtt.Tag = "edit.default";
			this.btnEditAtt.Text = "Modifica...";
			// 
			// btnInsAtt
			// 
			this.btnInsAtt.Location = new System.Drawing.Point(7, 7);
			this.btnInsAtt.Name = "btnInsAtt";
			this.btnInsAtt.Size = new System.Drawing.Size(81, 28);
			this.btnInsAtt.TabIndex = 20;
			this.btnInsAtt.Tag = "insert.default";
			this.btnInsAtt.Text = "Inserisci...";
			// 
			// tabMod770
			// 
			this.tabMod770.Controls.Add(this.dataGrid4);
			this.tabMod770.Controls.Add(this.button14);
			this.tabMod770.Controls.Add(this.button15);
			this.tabMod770.Controls.Add(this.button16);
			this.tabMod770.Location = new System.Drawing.Point(4, 25);
			this.tabMod770.Name = "tabMod770";
			this.tabMod770.Size = new System.Drawing.Size(796, 476);
			this.tabMod770.TabIndex = 13;
			this.tabMod770.Text = "Mod.770";
			this.tabMod770.UseVisualStyleBackColor = true;
			// 
			// dataGrid4
			// 
			this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid4.CaptionVisible = false;
			this.dataGrid4.DataMember = "";
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(19, 50);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.ReadOnly = true;
			this.dataGrid4.Size = new System.Drawing.Size(756, 409);
			this.dataGrid4.TabIndex = 19;
			this.dataGrid4.Tag = "registryspecialcategory770.detail";
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(211, 13);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(82, 25);
			this.button14.TabIndex = 18;
			this.button14.Tag = "delete";
			this.button14.Text = "Elimina";
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(115, 13);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(83, 25);
			this.button15.TabIndex = 17;
			this.button15.Tag = "edit.detail";
			this.button15.Text = "Modifica...";
			// 
			// button16
			// 
			this.button16.Location = new System.Drawing.Point(19, 13);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(82, 25);
			this.button16.TabIndex = 16;
			this.button16.Tag = "insert.default";
			this.button16.Text = "Inserisci...";
			// 
			// Frm_registry_anagrafica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(920, 536);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_registry_anagrafica";
			this.Text = "frmRegistry";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabGeneralita.ResumeLayout(false);
			this.tabGeneralita.PerformLayout();
			this.grpGeo.ResumeLayout(false);
			this.grpGeo.PerformLayout();
			this.grpEstero.ResumeLayout(false);
			this.grpEstero.PerformLayout();
			this.grpItaliano.ResumeLayout(false);
			this.grpItaliano.PerformLayout();
			this.grbSesso.ResumeLayout(false);
			this.tabPagamento.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrPagamento)).EndInit();
			this.tabIndirizzo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrIndirizzo)).EndInit();
			this.tabAltriDati.ResumeLayout(false);
			this.tabControl3.ResumeLayout(false);
			this.tabPrincipale.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabFatture.ResumeLayout(false);
			this.tabFatture.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.tabClassificazioni.ResumeLayout(false);
			this.tabClassificazioni.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.grpNace.ResumeLayout(false);
			this.grpNace.PerformLayout();
			this.gboxAteco.ResumeLayout(false);
			this.gboxAteco.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.tabAltro.ResumeLayout(false);
			this.tabAltro.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.tabContatto.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrContatto)).EndInit();
			this.tabPosGiuridica.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrPosRetributiva)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrPosGiuridica)).EndInit();
			this.tabClassSup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSupp)).EndInit();
			this.tabCF.ResumeLayout(false);
			this.grpCV.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.datagrid3)).EndInit();
			this.grpPIVA.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.grpCF.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgDurc)).EndInit();
			this.tabDocAmm.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabVisura.ResumeLayout(false);
			this.tabVisura.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).EndInit();
			this.tabCasellarioG.ResumeLayout(false);
			this.tabCasellarioG.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid6)).EndInit();
			this.tabCasellarioA.ResumeLayout(false);
			this.tabCasellarioA.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid7)).EndInit();
			this.tabOttempLegge68_99.ResumeLayout(false);
			this.tabOttempLegge68_99.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid8)).EndInit();
			this.tabRegolaritaFiscale.ResumeLayout(false);
			this.tabRegolaritaFiscale.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid9)).EndInit();
			this.tabVerificaAnac.ResumeLayout(false);
			this.tabVerificaAnac.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid10)).EndInit();
			this.tabPattointegrita.ResumeLayout(false);
			this.tabPattointegrita.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridPattointegrita)).EndInit();
			this.tabAllegati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid11)).EndInit();
			this.tabMod770.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			object MDVer = Meta.Conn.GetSys("MetaDataVersion");
			if (MDVer.ToString().CompareTo("1.30.75.0")<0){
				show("Per poter eseguire il form richiesto � necessario attendere "+
					"il completamento del live-update del software, poi chiudere e riaprire il programma.");
				Meta.CanSave=false;
				Meta.SearchEnabled=false;
				Meta.CanInsert=false;
				tabControl1.Enabled=false;
				return;
			};
            GetData.SetStaticFilter(DS.sortingview, QHS.CmpEq("ayear",Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.specialcategory770, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.registryspecialcategory770, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            if (Meta.edit_type == "anagrafica") {
                GetData.SetStaticFilter(DS.registry, Meta.GetFilterForSearch(DS.registry));
                Meta.StartFilter = Meta.GetFilterForSearch(DS.registry);
            }
            HelpForm.SetDenyNull(DS.registry.Columns["authorization_free"], true);
            HelpForm.SetDenyNull(DS.registry.Columns["multi_cf"], true);
            HelpForm.SetDenyNull(DS.registry.Columns["flagbankitaliaproceeds"], true);
            HelpForm.SetDenyNull(DS.registry.Columns["flag_pa"], true);
            HelpForm.SetDenyNull(DS.registry.Columns["sdi_norifamm"], true);
 
			HelpForm.SetDenyZero(DS.registry.Columns["residence"], true);
 
			GetData.CacheTable(DS.address);

            string filterEpOperationCred = QHS.CmpEq("idepoperation", "registry_cred");
            GetData.SetStaticFilter(DS.accmotiveapplied_credit, filterEpOperationCred);
            DataAccess.SetTableForReading(DS.accmotiveapplied_credit, "accmotiveapplied");
            DS.accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;

            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "registry_deb");
            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");
            DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
			GetData.SetSorting(DS.registrylegalstatus, "start desc");


		}
	
		public void MetaData_AfterClear() {		    
			//tabControl1.SelectedIndex=0;
			ConfiguraCredDebi(null);
			//chkItaliano.Checked=true;
			ConfiguraCampiNascita(false);
			VisualizzaBottoneComune(null, null);
            lblStatoDurc.Text = "";
            MetaData.SetDefault(DS.registryreference, "referencename","");

		}

        public void MetaData_AfterFill() {
            if (Meta.IsEmpty) return;

            if (DS.registry.Rows.Count > 0) {
                DataRow Rprimary = DS.registry.Rows[0];
                DataRow rowTipo = Rprimary.GetParentRow("registryclassregistry");
                ConfiguraCredDebi(rowTipo);
                //SetTipoClassExtraParam(Rprimary["idregistryclass"].ToString());
                if (Meta.FirstFillForThisRow) {
                    chkItaliano.Checked = IsItalian(Rprimary);
                    ConfiguraCampiNascita(false);
                }
                if (chkItaliano.Checked) {
                    idgeo = Rprimary["idcity"];
                    VisualizzaBottoneComune(idgeo, null);
                }
                else {
                    idgeo = Rprimary["idnation"];
                    VisualizzaBottoneComune(null, idgeo);
                }
            }

            if (DS.registrypaymethod.Select(QHC.CmpEq("flagstandard", 'S')).Length == 0) {
                MetaData.SetDefault(DS.registrypaymethod, "flagstandard", "S");
            }
            else {
                MetaData.SetDefault(DS.registrypaymethod, "flagstandard", "N");
            }

            if (DS.address.Select(QHC.CmpEq("codeaddress", "07_SW_DEF")).Length == 1) {
                DataRow def = DS.address.Select(QHC.CmpEq("codeaddress", "07_SW_DEF"))[0];
                MetaData.SetDefault(DS.registryaddress,"idaddresskind", def["idaddress"]);
            }

            if ((Meta.InsertMode ||Meta.EditMode)&& DS.registrydurc.Rows.Count >= 1) {
                string filter_durc = "";
                filter_durc = QHC.AppAnd(QHC.CmpLe("start", Meta.GetSys("datacontabile")),QHC.CmpGe("stop", Meta.GetSys("datacontabile")));
                DataRow[] Durc = DS.registrydurc.Select(filter_durc,"iddurckind DESC");
                string labelDURC = "";
                if (Durc.Length > 0){
                    int iddurckind = CfgFn.GetNoNullInt32(Durc[0]["iddurckind"]);
                    labelDURC = ( iddurckind == 3 ) ? "un DURC valido" : "un' Autocertificazone valida";
                    ImpostaLabelDURC(labelDURC, true);
                }
                else
                    ImpostaLabelDURC(labelDURC, false);
            }
        }

        private void ImpostaLabelDURC(string labelDURC, bool attivo) {
            if (attivo){
                lblStatoDurc.Text = "Esiste "+ labelDURC+ " per la data odierna";
            }
            else
                lblStatoDurc.Text = "NON esiste un DURC valido per la data odierna";
        }


		public void MetaData_AfterGetFormData() 
		{
			//aggiornaDenominazione();
			Meta.PrimaryDataTable.Rows[0]["title"] = txtDenominazione.Text;
            MetaData.SetDefault(DS.registryreference, "referencename", txtDenominazione.Text);

			//Crea la riga in registry_aziende
			
			if (Meta.InsertMode) {
				//prima svuota tutto perch� deve essere certo di non lasciare cadaveri
				DS.registry.Rows[0]["extension"]=DBNull.Value;
			
				DataRow Curr = DS.registry.Rows[0];
				object curr_idregistryclass = Curr["idregistryclass"];
				if (curr_idregistryclass == DBNull.Value) return;
				if ((curr_idregistryclass.ToString() != "21") && (curr_idregistryclass.ToString() != "23"))
					return;

				MetaData Aziende = MetaData.GetMetaData(this, "registry_aziende");
				DS.registry.Rows[0]["extension"] = "aziende";
			}
			if (Meta.EditMode) {
				DataRow R = DS.registry.Rows[0];
				// Se la riga di registry � stata modificata e la tipologia � stata cambiata in 21 o 23,
				// allora inserisce la riga in Aziende MA SOLO se non esiste gi� perch�
				// se Registry nasce con 21(azienda), e poi lo cambio a 22(persona fisica), non viene fatta la delete su Aziende(!),
				// quindi se poi da  22(persona fisica) la passo di nuovo a 21(azienda) non deve rifare la insert.
				// Stessa cosa per 23.

				if (R.RowState == DataRowState.Modified) {
					if (R["idregistryclass"] != DBNull.Value 
						&& (R["idregistryclass", DataRowVersion.Current] != R["idregistryclass", DataRowVersion.Original])
						&& (R["idregistryclass", DataRowVersion.Original].ToString() != "21" && R["idregistryclass", DataRowVersion.Original].ToString() != "23")
						&& (R["idregistryclass", DataRowVersion.Current].ToString() == "21" || R["idregistryclass", DataRowVersion.Current].ToString() == "23")
						) {
						DS.registry.Rows[0]["extension"] = "aziende";
					}
				}
			}

		}
		public void MetaData_BeforeFill() {
			if (Meta.InsertMode || Meta.EditMode) {
				bool allineaTabRegistry = false;
				//Se ci sono righe aggiunte o modificate, e se non vi � alcuna riga nella tabelle Estendenti
				// allora chiama la funzione che provveder� ad allineare opportunamente le due tabelle
				foreach (DataRow RLS in DS.registrylegalstatus.Select()) {
					if (
						((RLS.RowState == DataRowState.Added) || (RLS.RowState == DataRowState.Modified))
						) {
						allineaTabRegistry = true;
					}
				}
				if (allineaTabRegistry) AllineaTabelleEstendenti();

			}
		}
		public void AllineaTabelleEstendenti() {
			if (Meta.InsertMode || Meta.EditMode) {
				DataRow R = DS.registry.Rows[0];
				foreach (DataRow RLS in DS.registrylegalstatus.Select()) {
					if (RLS.RowState == DataRowState.Added) {
						DataRow rPosition = getQualifica(RLS);
						if (rPosition == null) continue;

						object tipopersonale = rPosition["tipopersonale"];
						if (tipopersonale == null) continue;

						if ((tipopersonale.ToString() == "D") || (tipopersonale.ToString() == "R")) {
							R["extension"] = "docenti";
						}
						else {
							R["extension"] = "amministrativi";
						}
					}
				}
			}
		}
		public DataRow getQualifica(DataRow Rregistrylegalstatus) {
			object flag_seg_config = conn.DO_READ_VALUE("seg_config", null, "flag");
			if (flag_seg_config == null || flag_seg_config == DBNull.Value)
				return null;
			byte flag = CfgFn.GetNoNullByte(flag_seg_config);
			if ((flag & 1) != 0) {
				return null;
			}
			DataTable Tposition = conn.RUN_SELECT("position", "*", null,
				QHS.CmpEq("idposition", Rregistrylegalstatus["idposition"]), null, true);
			if ((Tposition == null) || Tposition.Rows.Count == 0) {
				return null;
			}
			else {
				return Tposition.Rows[0];
			}
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (!Meta.DrawStateIsDone) return;
			
			if (T.TableName == "registryclass") {
				ConfiguraCredDebi(R);
//				if (R==null)
//					SetTipoClassExtraParam("");
//				else
//					SetTipoClassExtraParam(R["idregistryclass"].ToString());
			}

			if (T.TableName == "title") 
			{
				aggiornaDenominazione();
			}

			//in fase di ricerca il codice fiscale non mi � utile
			if (!Meta.IsEmpty && T.TableName == "geo_cityview" && R!=null) {
                idgeo = R["idcity"];
				VisualizzaBottoneComune(idgeo, null);
			}

			//in fase di ricerca il codice fiscale non mi � utile
			if (!Meta.IsEmpty && T.TableName == "geo_nazione_alias" && R!=null) {
                idgeo = R["idnation"];
				VisualizzaBottoneComune(null, idgeo);
			}
		}

		/// <summary>
		/// True se idcomune <> null (se idcomune e idstatoestero sono entrambi <> null
		/// allora viene considerato idcomune
		/// </summary>
		/// <param name="Rcred">Riga di creditoredebitore</param>
		private bool IsItalian(DataRow Rcred) {
			if (Rcred==null) return true;
			return (Rcred["idnation"]==DBNull.Value);
		}

		/// <summary>
		/// Aggiorna i campi in base allo stato di nascita
		/// </summary>
		/// <param name="Aggiorna">True se provengo dall'evento del checkbox</param>
		private void ConfiguraCampiNascita(bool Aggiorna) {
			//if (!grpGeo.Visible) return;
			if (chkItaliano.Checked) {
				grpItaliano.Visible=true;
				grpEstero.Visible=false;
				lblComuneStato.Text="Comune";
				if (!Meta.IsEmpty) {
					DS.registry.Rows[0]["idnation"]=DBNull.Value;
					DS.geo_nazione_alias.Rows.Clear();
					if (Aggiorna) 
					{
						Meta.myHelpForm.FillControls(grpEstero.Controls);
						//Meta.FreshForm(grpEstero.Controls, true, "creditoredebitore");
					}
				}
			}
			else {
				grpItaliano.Visible=false;
				grpEstero.Visible=true;
				lblComuneStato.Text="Stato estero";
				if (!Meta.IsEmpty) {
					DS.registry.Rows[0]["idcity"]=DBNull.Value;
					DS.geo_cityview.Rows.Clear();
					if (Aggiorna)
					{
						Meta.myHelpForm.FillControls(grpItaliano.Controls);
					}
				}
			}
		}

		private void chkItaliano_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			ConfiguraCampiNascita(true);
			idgeo="";
		}

		private void ConfiguraCredDebi(DataRow R) {
			//Se non mi trovo sul primo tab non aggiorno nulla
			//if (tabControl1.SelectedIndex!=0) return;

			txtDenominazione.ReadOnly = ! Meta.IsEmpty && ! ValoreCampoTrue(R,"flagtitle");
			
			lblCodiceFiscale.Visible=ValoreCampoTrue(R,"flagCF");
			txtCodiceFiscale.Visible=ValoreCampoTrue(R,"flagCF");//lblCodiceFiscale.Visible;

            grpCF.Enabled = ValoreCampoTrue(R, "flagCF");

			lblCodFiscEstero.Visible=ValoreCampoTrue(R,"flagforeigncf");
			txtCodFiscEstero.Visible=ValoreCampoTrue(R,"flagforeigncf");//lblCodFiscEstero.Visible;

			//se uno dei due codici fiscali � visibile tutti i campi dipendenti lo sono
			bool generalita=true;
			generalita=ValoreCampoTrue(R,"flaghuman");
			lblCognome.Visible=generalita;
			txtCognome.Visible=generalita;
			lblNome.Visible=generalita;
			txtNome.Visible=generalita;
			grpGeo.Visible=generalita;
			grbSesso.Visible=generalita;

			//Bottoni codice fiscale
			btnCF.Visible=ValoreCampoTrue(R,"flagcfbutton");
			btnCFInfo.Visible=ValoreCampoTrue(R,"flaginfofromcfbutton");

			lblPartitaIVA.Visible=ValoreCampoTrue(R,"flagp_iva");
			txtPartitaIva.Visible=ValoreCampoTrue(R,"flagp_iva");//lblPartitaIVA.Visible;

            grpPIVA.Visible = ValoreCampoTrue(R, "flagp_iva");

			btnTitolo.Visible=ValoreCampoTrue(R,"flagqualification");
			cmbTitolo.Visible=ValoreCampoTrue(R,"flagqualification");//btnTitolo.Visible;
				
			lblMatricolaext.Visible = ValoreCampoTrue(R,"flagextmatricula");
			// 13.07.05 Rusciano G. Questa riga � stata commentata in quanto sembra ci siano problemi
			// nel settare la propriet� Visible di una Label quando questa non � presente nel tabControl attivo
			// Questo concetto vale per tutte le righe di codice che settano il Visible delle TextBox
			//txtMatricolaext.Visible = lblMatricolaext.Visible;
			txtMatricolaext.Visible = ValoreCampoTrue(R,"flagextmatricula");

			lblBadge.Visible = ValoreCampoTrue(R,"flagbadgecode");
			txtBadge.Visible = ValoreCampoTrue(R,"flagbadgecode");//lblBadge.Visible;

			btnStatoCivile.Visible=ValoreCampoTrue(R,"flagmaritalstatus");
			cmbStatoCivile.Visible=ValoreCampoTrue(R,"flagmaritalstatus");//btnStatoCivile.Visible;

			lblCognomeAcq.Visible=ValoreCampoTrue(R,"flagmaritalsurname");
			txtCognomeAcq.Visible=ValoreCampoTrue(R,"flagmaritalsurname");//lblCognomeAcq.Visible;
		}

		/// <summary>
		/// True se R=null o se R[field]='S'
		/// </summary>
		private bool ValoreCampoTrue(DataRow R, string field) {
			if (R==null) return Meta.IsEmpty;
			return (R[field].ToString().ToUpper()=="S");
		}

//		private void SetTipoClassExtraParam(string valore) {
//			if (valore!="")
//				DS.registryrole.ExtendedProperties[MetaData.ExtraParams]=
//					"idregistryclass="+QueryCreator.quotedstrvalue(valore,true);
//			else
//				DS.registryrole.ExtendedProperties[MetaData.ExtraParams]=null;
//		}

		private void btnCF_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			string nome=txtNome.Text;
			string cognome=txtCognome.Text;
			object datanascita = HelpForm.GetObjectFromString(typeof(DateTime),txtDataNascita.Text,null);

			string sesso="";
			if (rdbSessoF.Checked) sesso="F";
			if (rdbSessoM.Checked) sesso="M";

			string tipoGeo = (chkItaliano.Checked?"C":"N");
			bool IsValid=true;
			string errori="";
			string codice=CalcolaCodiceFiscale.Make(Meta.Conn,nome,cognome,datanascita,				
				idgeo.ToString(),sesso,tipoGeo,out IsValid,out errori);
			if (IsValid) 
				txtCodiceFiscale.Text=codice;
			else
				show("Sono stati riscontrati i seguenti errori "+
					"durante il calcolo del codice fiscale:\r\r"+errori,"Calcolo Codice Fiscale",
					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}

		private void btnCFInfo_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			bool ok = Meta.GetFormData(true);
			DataRow R=DS.registry.Rows[0];
			string codicefiscale=R["cf"].ToString().ToUpper();
			if (codicefiscale.Length!=16) 
			{
				show(this, "Il codice fiscale deve essere composto da 16 caratteri!", "Elaborazione del codice fiscale",
					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			bool IsValid;
			char lastChar =  CalcolaCodiceFiscale.GetLastChar(codicefiscale.Substring(0,15), out IsValid);
			if ((!IsValid)||(codicefiscale[15] != lastChar)) 
			{
				show(this, "Il codice fiscale � errato!", "Verifica dell'ultimo carattere del codice fiscale '"+lastChar+"'",
					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			codicefiscale = CalcolaCodiceFiscale.normalizza(codicefiscale);
			chkItaliano.Checked = (codicefiscale[11] != 'Z');
			string sesso=InfoDaCodiceFiscale.Sesso(codicefiscale);
			object datanascita=InfoDaCodiceFiscale.DataNascita(Meta.Conn, codicefiscale);
			if (sesso!=null) R["gender"]=sesso;
			if (datanascita!=null) R["birthdate"]=datanascita;
			if (chkItaliano.Checked) 
			{
				string idcomune=InfoDaCodiceFiscale.Comune(Meta.Conn, codicefiscale);
				if ((idcomune!=null)&&(idcomune!=""))
				{
					R["idcity"]=idcomune;
					idgeo = idcomune;
				} 
				else 
				{
					show(this, "Impossibile ricavare il comune dal codice '"+codicefiscale.Substring(11,4)+"'", "Elaborazione del codice fiscale",
						MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			} 
			else 
			{
				string idnazione=InfoDaCodiceFiscale.Nazione(Meta.Conn, codicefiscale);
				if ((idnazione!=null)&&(idnazione!=""))
				{
					R["idnation"]=idnazione;
					idgeo = idnazione;
				} 
				else 
				{
					show(this, "Impossibile ricavare lo stato estero dal codice '"+codicefiscale.Substring(11,4)+"'", "Elaborazione del codice fiscale",
						MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
			Meta.FreshForm(true);
		}

		/// <summary>
		/// Visualliza il bottone aggiorna comune in base all'idcomune
		/// </summary>
		/// <param name="R">riga di creditoredebitore</param>
		private void VisualizzaBottoneComune(object idcomune, object idnazione) {
			bool visible=false;
			if ((idcomune!=null) && (idcomune!=DBNull.Value)) {
				object val=Meta.Conn.DO_READ_VALUE("geo_cityusable", QHS.CmpEq("idcity", idcomune), "idcity");
				if (val==null) 
				{
					btnAggiornaComune.Text = "Aggiorna Comune";
					visible = true;
				}
			}
            //if ((idnazione!=null) && (idnazione!=DBNull.Value))
            //{
            //    object val=Meta.Conn.DO_READ_VALUE("geo_nationusable", QHS.CmpEq("idnation", idnazione), "idnation");
            //    if (val==null) 
            //    {
            //        btnAggiornaComune.Text = "Aggiorna Stato estero";
            //        visible = true;
            //    }
            //}
			btnAggiornaComune.Visible=visible;
		}

		private void aggiornaStatoEstero() 
		{
			object idstatoestero=DS.registry.Rows[0]["idnation"];
			if (idstatoestero == DBNull.Value) return;
			object[] list=new object[]{idstatoestero,"S"};
			DataSet DSout=Meta.Conn.CallSP("compute_history_nation",list,true,-1);
			if (DSout==null || DSout.Tables.Count==0 || DS.Tables[0].Rows.Count==0) return;
			DataTable T=DSout.Tables[0];
			if (T.Rows.Count==1) 
			{
				DS.registry.Rows[0]["idnation"]=T.Rows[0]["idnation"];
			}
			else 
			{
				string valori = QueryCreator.ColumnValues(T, null, "idnation", true);
				if (valori != "") {
					string filtro = QHS.FieldInList("idnation", valori);
					MetaData metaStatoEstero = MetaData.GetMetaData(this, "geo_nation");
					metaStatoEstero.DS = DS.Copy();
					metaStatoEstero.FilterLocked = true;

					DataRow r = metaStatoEstero.SelectOne("default", filtro, null, null);

					if (r!=null) {
						DS.registry.Rows[0]["idnation"]=r["idnation"];
					}
				}
			}
		}

		private void aggiornaComune() 
		{
			object idcomune=DS.registry.Rows[0]["idcity"];
			if (idcomune == DBNull.Value) return;
			object[] list=new object[]{idcomune,"S"};
			DataSet DSout=Meta.Conn.CallSP("compute_history_city",list,true,-1);
			if (DSout==null || DSout.Tables.Count==0 || DS.Tables[0].Rows.Count==0) return;
			DataTable T=DSout.Tables[0];
			if (T.Rows.Count==1) 
			{
                DS.registry.Rows[0]["idcity"] = T.Rows[0]["idcity"];
			}
			else 
			{
				string valori = QueryCreator.ColumnValues(T, null, "idcity", true);
				if (valori != "") {
					string filtro = QHS.FieldInList("idcity", valori);
					MetaData metaComune = MetaData.GetMetaData(this, "geo_cityview");
					metaComune.DS = DS.Copy();
					metaComune.FilterLocked = true;

					DataRow r = metaComune.SelectOne("storia", filtro, null, null);

					if (r!=null) {
						DS.registry.Rows[0]["idcity"]=r["idcity"];
					}
				}
			}
		}

		private void btnAggiornaComune_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (chkItaliano.Checked) 
			{
				aggiornaComune();
			} 
			else 
			{
				aggiornaStatoEstero();
			}
			Meta.FreshForm(true);
		}

		private void aggiornaDenominazione() 
		{
			if (Meta == null) return;
            //if (!Meta.InsertMode) return ;
			if (txtDenominazione.ReadOnly) 
			{
				string denominazione = txtCognome.Text.Trim();
				if (cmbTitolo.Text != "") 
				{
					string titolo = cmbTitolo.Text;
					string s = txtCognome.Text + txtNome.Text;
					if (s.ToUpper()==s) 
					{
						titolo = titolo.ToUpper();
					}
					denominazione += " " + titolo;
				}
				if (txtNome.Text != "") 
				{
					denominazione += " " + txtNome.Text.Trim();
				}
				txtDenominazione.Text = denominazione;
			}
		}

		private void txtCognome_TextChanged(object sender, System.EventArgs e)
		{
			if (Meta!=null && Meta.DrawStateIsDone) aggiornaDenominazione();
		}

		private void txtNome_TextChanged(object sender, System.EventArgs e)
		{
            if (Meta != null && Meta.DrawStateIsDone)  aggiornaDenominazione();
		}

		private void groupBox12_Enter(object sender, EventArgs e) {

		}
	}
}
