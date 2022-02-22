
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
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using SituazioneViewer;//SituazioneViewer


namespace fin_default {//bilancio//
	/// <summary>
	/// Summary description for frmbilancio.
	/// Revised By Nino on 9/1/2003
	/// </summary>
	public class Frm_fin_default : MetaDataForm {
        public System.Windows.Forms.TabControl MetaDataDetail;
		private System.Windows.Forms.TextBox txtOrdineStampa;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.ComboBox cmbLivello;
		private System.Windows.Forms.Button btnElimina;
		private System.Windows.Forms.Button btnModifica;
		private System.Windows.Forms.Button btnInserisci;
		private System.Windows.Forms.TreeView treeView1;
		public vistaForm DS;
        private System.Windows.Forms.TextBox SubEntity_txtScadenza;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.GroupBox grpParte;
		private System.Windows.Forms.RadioButton rdbSpesa;
		private System.Windows.Forms.RadioButton rdbEntrata;
		private System.Windows.Forms.TabPage tabGeneralita;
		private System.Windows.Forms.CheckBox chbTrasferimenti;
        private System.Windows.Forms.CheckBox chbPartiteGiro;
		private System.Windows.Forms.Splitter splitter1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.GroupBox gboxSecondaPrevisione;
		private System.Windows.Forms.GroupBox gboxPrimaPrevisione;
		private System.Windows.Forms.GroupBox gboxRipartizione;
		private System.Windows.Forms.Label lblRipCorrente;
		private System.Windows.Forms.Label lblEsPrecSeconda;
		private System.Windows.Forms.Label lblEsCorrSeconda;
		private System.Windows.Forms.Label lblEsPrecPrima;
		private System.Windows.Forms.Label lblEsCorrentePrima;
        private System.Windows.Forms.Label lblScadenza;
		private System.Windows.Forms.Label lblOrdineStampa;
		private System.Windows.Forms.Label lblDenominazione;
		private System.Windows.Forms.Label lblCodice;
		private System.Windows.Forms.Label lblLivello;
		private System.Windows.Forms.Label lblRipPrecedente;
		private System.Windows.Forms.DataGrid dGridClassSup;
		public string filteresercizio;
		MetaData Meta;
		DataAccess Conn;
		private System.Windows.Forms.Button btnNewSituazione;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox GrpboxPrevisione;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox SubEntity_txtprevesercizioprec;
		private System.Windows.Forms.TextBox SubEntity_txtpreveserciziocorr;
		private System.Windows.Forms.TextBox SubEntity_txtprevsecesercizioprec;
		private System.Windows.Forms.TextBox SubEntity_txtprevseceserciziocorr;
		private System.Windows.Forms.TextBox SubEntity_txtripartizioneprec;
		private System.Windows.Forms.TextBox SubEntity_txtripartizionecorr;
		bool SP_Called;
		private System.Windows.Forms.Button btnSuddivisioni;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox SubEntity_txtprevision2;
		private System.Windows.Forms.TextBox SubEntity_txtprevision3;
		private System.Windows.Forms.TextBox SubEntity_txtprevision4;
		private System.Windows.Forms.TextBox SubEntity_txtprevision5;
		private System.Windows.Forms.Label lblPrevisione2;
		private System.Windows.Forms.Label lblPrevisione3;
		private System.Windows.Forms.Label lblPrevisione4;
		private System.Windows.Forms.Label lblPrevisione5;
		private System.Windows.Forms.Button btnCreaPrevisioni;
        private CheckBox chkES;
        private Label label5;
        private TextBox SubEntity_cup;
        private TabPage tabPrevisione;
        private Button btnInsPrevisione;
        private Button btnEditPrevisione;
        private Button btnDelPrevisione;
        private DataGrid dgPrevisione;
        private GroupBox groupBox2;
        private DataGrid dgVariazioni;
        private TabPage tabRiepilogo;
        private GroupBox grpPrevCompetenza;
        private Label label1;
        private Button btnVarPrevCompetenza;
        private Label lblVarPrevCompetenza;
        private TextBox txtVarPrevCompetenza;
        private Label lblPrevDispCompetenza;
        private TextBox txtPrevDispCompetenza;
        private Button btnImpegniCompetenza;
        private Label lblImpegniCompetenza;
        private TextBox txtImpegniCompetenza;
        private Button btnPrevInizialeCompetenza;
        private Label lblPrevInizialeCompetenza;
        private TextBox txtPrevInizialeCompetenza;
        private GroupBox grpPrevCassa;
        private Label label2;
        private Button btnVarPrevisioneCassa;
        private Label lblVarPrevisioneCassa;
        private TextBox txtVarPrevisioneCassa;
        private Label lblPrevDispCassaPagInc;
        private Button btnPagamenti;
        private Label lblPagamenti;
        private TextBox txtPagamenti;
        private Button btnPrevInizialeCassa;
        private Label lblPrevInizialeCassa;
        private TextBox txtPrevInizialeCassa;
        private GroupBox grpCrediti;
        private Label label3;
        private Button btnDotazioneCrediti;
        private Label lblDotazioneCrediti;
        private TextBox txtDotazioneCrediti;
        private Label lblCreditiResidui;
        private TextBox txtCreditiResidui;
        private Button btnCreditiAssegnati;
        private Label lblCreditiAssegnati;
        private TextBox txtCreditiAssegnati;
        private GroupBox grpCassa;
        private Label label4;
        private Button btnDotazioneCassa;
        private Label lblDotazioneCassa;
        private TextBox txtDotazioneCassa;
        private Label lblCassaResidua;
        private TextBox txtCassaResidua;
        private Button btnAssegnazioniCassa;
        private Label lblAssegnazioniCassa;
        private TextBox txtAssegnazioniCassa;
        private Button btnAccertamentiCompetenza;
        private Label lblAccertamentiCompetenza;
        private TextBox txtAccertamentiCompetenza;
        private Button btnIncassi;
        private Label lblIncassi;
        private TextBox txtIncassi;
        private Label lblVarDotazioneCrediti;
        private Button btnVarDotazioneCrediti;
        private TextBox txtVarDotazioneCrediti;
        private Button btnVarDotazioneCassa;
        private TextBox txtVarDotazioneCassa;
        private Label lblVarDotazioneCassa;
        private Button btnPagamenti1;
        private Label lblPagamenti1;
        private TextBox txtPagamenti1;
        private Button btnPiccoleSpeseImp;
        private Label lblPiccoleSpeseImp;
        private TextBox txtPiccoleSpeseImp;
        private Button btnPiccoleSpesePagamenti;
        private Label lblPiccoleSpesePagamenti;
        private TextBox txtPiccoleSpesePagamenti;
        private Button btnPiccoleSpesePagamenti1;
        private Label lblPiccoleSpesePagamenti1;
        private TextBox txtPiccoleSpesePagamenti1;
        private TextBox txtPrevDispCassaPerPagInc;
        private TabPage TabClassAutoSpese;
        private TabPage TabClassAutoEntrate;
        private GroupBox groupBox6;
        private DataGrid dGridFilterClassExp;
        private Button btnEliminaFilterS;
        private Button btnModificaFilterS;
        private Button btnInserisciFilterS;
        private GroupBox groupBox7;
        private DataGrid dGridClassAutoExp;
        private Button btnEliminaClassS;
        private Button btnModificaClassS;
        private Button btnInserisciClassS;
        private GroupBox groupBox8;
        private DataGrid dGridFilterClassInc;
        private Button btnEliminaFilterE;
        private Button btnModificaFilterE;
        private Button btnInserisciFilterE;
        private GroupBox groupBox9;
        private DataGrid dGridClassAutoInc;
        private Button btnEliminaClassE;
        private Button btnModificaClassE;
        private Button btnInserisciClassE;
        private CheckBox chkMovProtetta;
        private Button btnCalcolaTotali;
        private TabControl tabControlRiepilogo;
        private TabPage tabCompetenza;
        private TabPage tabCassa;
        private TabPage tabCrediti;
        private TabPage tabAssCassa;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        private CheckBox chkAvanzoEntrata;
        private CheckBox chkAvanzoUscita;
		bool upbUnico = false;
        private Label label7;
        private Label label6;
        private TextBox txtPrevAttualeCompetenza;
        private Label label8;
        private Label label9;
        private TextBox txtPrevAttualeCassa;
        private Label label11;
        private Label labelTotaleCrediti;
        private TextBox txtTotaleCrediti;
        private Label label12;
        private Label labelTotaleCassa;
        private TextBox txtTotaleCassa;
        private CheckBox chkNoContab;
        private TabPage tabClassSupp;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button button1;
        private Button btnAccertamentiAll;
        private Label lblAccertamentiAll;
        private TextBox txtAccertamentiAll;
        private Button btnImpegniAll;
        private Label lblImpegniAll;
        private TextBox txtImpegniAll;
        private TextBox txtPrevDispCassaPerImpegniAccertamenti;
        private Label label10;
        private Label lblPrevDispCassaImpegniAccertamenti;
        private GroupBox gBoxCausalePartiteGiro;
        private TextBox textBox1;
        private TextBox txtCodiceCausaleDeb;
        private Button button6;
        CalcoliFinanziario CalcFin;
		public Frm_fin_default() {
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

        QueryHelper QHS;
        CQueryHelper QHC;
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_fin_default));
			this.MetaDataDetail = new System.Windows.Forms.TabControl();
			this.tabGeneralita = new System.Windows.Forms.TabPage();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SubEntity_cup = new System.Windows.Forms.TextBox();
			this.chkES = new System.Windows.Forms.CheckBox();
			this.btnCreaPrevisioni = new System.Windows.Forms.Button();
			this.btnSuddivisioni = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.GrpboxPrevisione = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtprevision5 = new System.Windows.Forms.TextBox();
			this.SubEntity_txtprevision4 = new System.Windows.Forms.TextBox();
			this.SubEntity_txtprevision3 = new System.Windows.Forms.TextBox();
			this.SubEntity_txtprevision2 = new System.Windows.Forms.TextBox();
			this.lblPrevisione5 = new System.Windows.Forms.Label();
			this.lblPrevisione4 = new System.Windows.Forms.Label();
			this.lblPrevisione3 = new System.Windows.Forms.Label();
			this.lblPrevisione2 = new System.Windows.Forms.Label();
			this.gboxPrimaPrevisione = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtprevesercizioprec = new System.Windows.Forms.TextBox();
			this.lblEsPrecPrima = new System.Windows.Forms.Label();
			this.SubEntity_txtpreveserciziocorr = new System.Windows.Forms.TextBox();
			this.lblEsCorrentePrima = new System.Windows.Forms.Label();
			this.gboxSecondaPrevisione = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtprevsecesercizioprec = new System.Windows.Forms.TextBox();
			this.lblEsPrecSeconda = new System.Windows.Forms.Label();
			this.SubEntity_txtprevseceserciziocorr = new System.Windows.Forms.TextBox();
			this.lblEsCorrSeconda = new System.Windows.Forms.Label();
			this.gboxRipartizione = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtripartizioneprec = new System.Windows.Forms.TextBox();
			this.lblRipPrecedente = new System.Windows.Forms.Label();
			this.SubEntity_txtripartizionecorr = new System.Windows.Forms.TextBox();
			this.lblRipCorrente = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkNoContab = new System.Windows.Forms.CheckBox();
			this.chkAvanzoUscita = new System.Windows.Forms.CheckBox();
			this.chkAvanzoEntrata = new System.Windows.Forms.CheckBox();
			this.chkMovProtetta = new System.Windows.Forms.CheckBox();
			this.chbPartiteGiro = new System.Windows.Forms.CheckBox();
			this.chbTrasferimenti = new System.Windows.Forms.CheckBox();
			this.grpParte = new System.Windows.Forms.GroupBox();
			this.rdbSpesa = new System.Windows.Forms.RadioButton();
			this.rdbEntrata = new System.Windows.Forms.RadioButton();
			this.SubEntity_txtScadenza = new System.Windows.Forms.TextBox();
			this.lblScadenza = new System.Windows.Forms.Label();
			this.txtOrdineStampa = new System.Windows.Forms.TextBox();
			this.lblOrdineStampa = new System.Windows.Forms.Label();
			this.txtDenominazione = new System.Windows.Forms.TextBox();
			this.lblDenominazione = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.lblCodice = new System.Windows.Forms.Label();
			this.lblLivello = new System.Windows.Forms.Label();
			this.cmbLivello = new System.Windows.Forms.ComboBox();
			this.DS = new fin_default.vistaForm();
			this.btnNewSituazione = new System.Windows.Forms.Button();
			this.tabPrevisione = new System.Windows.Forms.TabPage();
			this.dgPrevisione = new System.Windows.Forms.DataGrid();
			this.btnInsPrevisione = new System.Windows.Forms.Button();
			this.btnEditPrevisione = new System.Windows.Forms.Button();
			this.btnDelPrevisione = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgVariazioni = new System.Windows.Forms.DataGrid();
			this.tabClassSupp = new System.Windows.Forms.TabPage();
			this.gBoxCausalePartiteGiro = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.gboxConto = new System.Windows.Forms.GroupBox();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.dGridClassSup = new System.Windows.Forms.DataGrid();
			this.btnElimina = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnInserisci = new System.Windows.Forms.Button();
			this.TabClassAutoSpese = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.dGridFilterClassExp = new System.Windows.Forms.DataGrid();
			this.btnEliminaFilterS = new System.Windows.Forms.Button();
			this.btnModificaFilterS = new System.Windows.Forms.Button();
			this.btnInserisciFilterS = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.dGridClassAutoExp = new System.Windows.Forms.DataGrid();
			this.btnEliminaClassS = new System.Windows.Forms.Button();
			this.btnModificaClassS = new System.Windows.Forms.Button();
			this.btnInserisciClassS = new System.Windows.Forms.Button();
			this.TabClassAutoEntrate = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.dGridFilterClassInc = new System.Windows.Forms.DataGrid();
			this.btnEliminaFilterE = new System.Windows.Forms.Button();
			this.btnModificaFilterE = new System.Windows.Forms.Button();
			this.btnInserisciFilterE = new System.Windows.Forms.Button();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.dGridClassAutoInc = new System.Windows.Forms.DataGrid();
			this.btnEliminaClassE = new System.Windows.Forms.Button();
			this.btnModificaClassE = new System.Windows.Forms.Button();
			this.btnInserisciClassE = new System.Windows.Forms.Button();
			this.tabRiepilogo = new System.Windows.Forms.TabPage();
			this.tabControlRiepilogo = new System.Windows.Forms.TabControl();
			this.tabCompetenza = new System.Windows.Forms.TabPage();
			this.grpPrevCompetenza = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPrevAttualeCompetenza = new System.Windows.Forms.TextBox();
			this.btnPiccoleSpeseImp = new System.Windows.Forms.Button();
			this.lblPiccoleSpeseImp = new System.Windows.Forms.Label();
			this.txtPiccoleSpeseImp = new System.Windows.Forms.TextBox();
			this.btnAccertamentiCompetenza = new System.Windows.Forms.Button();
			this.lblAccertamentiCompetenza = new System.Windows.Forms.Label();
			this.txtAccertamentiCompetenza = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnVarPrevCompetenza = new System.Windows.Forms.Button();
			this.lblVarPrevCompetenza = new System.Windows.Forms.Label();
			this.txtVarPrevCompetenza = new System.Windows.Forms.TextBox();
			this.lblPrevDispCompetenza = new System.Windows.Forms.Label();
			this.txtPrevDispCompetenza = new System.Windows.Forms.TextBox();
			this.btnImpegniCompetenza = new System.Windows.Forms.Button();
			this.lblImpegniCompetenza = new System.Windows.Forms.Label();
			this.txtImpegniCompetenza = new System.Windows.Forms.TextBox();
			this.btnPrevInizialeCompetenza = new System.Windows.Forms.Button();
			this.lblPrevInizialeCompetenza = new System.Windows.Forms.Label();
			this.txtPrevInizialeCompetenza = new System.Windows.Forms.TextBox();
			this.tabCassa = new System.Windows.Forms.TabPage();
			this.grpPrevCassa = new System.Windows.Forms.GroupBox();
			this.txtPrevDispCassaPerImpegniAccertamenti = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.lblPrevDispCassaImpegniAccertamenti = new System.Windows.Forms.Label();
			this.btnAccertamentiAll = new System.Windows.Forms.Button();
			this.lblAccertamentiAll = new System.Windows.Forms.Label();
			this.txtAccertamentiAll = new System.Windows.Forms.TextBox();
			this.btnImpegniAll = new System.Windows.Forms.Button();
			this.lblImpegniAll = new System.Windows.Forms.Label();
			this.txtImpegniAll = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPrevAttualeCassa = new System.Windows.Forms.TextBox();
			this.txtPrevDispCassaPerPagInc = new System.Windows.Forms.TextBox();
			this.btnPiccoleSpesePagamenti = new System.Windows.Forms.Button();
			this.lblPiccoleSpesePagamenti = new System.Windows.Forms.Label();
			this.txtPiccoleSpesePagamenti = new System.Windows.Forms.TextBox();
			this.btnIncassi = new System.Windows.Forms.Button();
			this.lblIncassi = new System.Windows.Forms.Label();
			this.txtIncassi = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnVarPrevisioneCassa = new System.Windows.Forms.Button();
			this.lblVarPrevisioneCassa = new System.Windows.Forms.Label();
			this.txtVarPrevisioneCassa = new System.Windows.Forms.TextBox();
			this.lblPrevDispCassaPagInc = new System.Windows.Forms.Label();
			this.btnPagamenti = new System.Windows.Forms.Button();
			this.lblPagamenti = new System.Windows.Forms.Label();
			this.txtPagamenti = new System.Windows.Forms.TextBox();
			this.btnPrevInizialeCassa = new System.Windows.Forms.Button();
			this.lblPrevInizialeCassa = new System.Windows.Forms.Label();
			this.txtPrevInizialeCassa = new System.Windows.Forms.TextBox();
			this.tabCrediti = new System.Windows.Forms.TabPage();
			this.grpCrediti = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.labelTotaleCrediti = new System.Windows.Forms.Label();
			this.txtTotaleCrediti = new System.Windows.Forms.TextBox();
			this.btnVarDotazioneCrediti = new System.Windows.Forms.Button();
			this.txtVarDotazioneCrediti = new System.Windows.Forms.TextBox();
			this.lblVarDotazioneCrediti = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnDotazioneCrediti = new System.Windows.Forms.Button();
			this.lblDotazioneCrediti = new System.Windows.Forms.Label();
			this.txtDotazioneCrediti = new System.Windows.Forms.TextBox();
			this.lblCreditiResidui = new System.Windows.Forms.Label();
			this.txtCreditiResidui = new System.Windows.Forms.TextBox();
			this.btnCreditiAssegnati = new System.Windows.Forms.Button();
			this.lblCreditiAssegnati = new System.Windows.Forms.Label();
			this.txtCreditiAssegnati = new System.Windows.Forms.TextBox();
			this.tabAssCassa = new System.Windows.Forms.TabPage();
			this.grpCassa = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.labelTotaleCassa = new System.Windows.Forms.Label();
			this.txtTotaleCassa = new System.Windows.Forms.TextBox();
			this.btnPiccoleSpesePagamenti1 = new System.Windows.Forms.Button();
			this.lblPiccoleSpesePagamenti1 = new System.Windows.Forms.Label();
			this.txtPiccoleSpesePagamenti1 = new System.Windows.Forms.TextBox();
			this.btnPagamenti1 = new System.Windows.Forms.Button();
			this.lblPagamenti1 = new System.Windows.Forms.Label();
			this.txtPagamenti1 = new System.Windows.Forms.TextBox();
			this.btnVarDotazioneCassa = new System.Windows.Forms.Button();
			this.txtVarDotazioneCassa = new System.Windows.Forms.TextBox();
			this.lblVarDotazioneCassa = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnDotazioneCassa = new System.Windows.Forms.Button();
			this.lblDotazioneCassa = new System.Windows.Forms.Label();
			this.txtDotazioneCassa = new System.Windows.Forms.TextBox();
			this.lblCassaResidua = new System.Windows.Forms.Label();
			this.txtCassaResidua = new System.Windows.Forms.TextBox();
			this.btnAssegnazioniCassa = new System.Windows.Forms.Button();
			this.lblAssegnazioniCassa = new System.Windows.Forms.Label();
			this.txtAssegnazioniCassa = new System.Windows.Forms.TextBox();
			this.btnCalcolaTotali = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.MetaDataDetail.SuspendLayout();
			this.tabGeneralita.SuspendLayout();
			this.gboxResponsabile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.GrpboxPrevisione.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.gboxPrimaPrevisione.SuspendLayout();
			this.gboxSecondaPrevisione.SuspendLayout();
			this.gboxRipartizione.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpParte.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabPrevisione.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPrevisione)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgVariazioni)).BeginInit();
			this.tabClassSupp.SuspendLayout();
			this.gBoxCausalePartiteGiro.SuspendLayout();
			this.gboxConto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).BeginInit();
			this.TabClassAutoSpese.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridFilterClassExp)).BeginInit();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridClassAutoExp)).BeginInit();
			this.TabClassAutoEntrate.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridFilterClassInc)).BeginInit();
			this.groupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridClassAutoInc)).BeginInit();
			this.tabRiepilogo.SuspendLayout();
			this.tabControlRiepilogo.SuspendLayout();
			this.tabCompetenza.SuspendLayout();
			this.grpPrevCompetenza.SuspendLayout();
			this.tabCassa.SuspendLayout();
			this.grpPrevCassa.SuspendLayout();
			this.tabCrediti.SuspendLayout();
			this.grpCrediti.SuspendLayout();
			this.tabAssCassa.SuspendLayout();
			this.grpCassa.SuspendLayout();
			this.SuspendLayout();
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Controls.Add(this.tabGeneralita);
			this.MetaDataDetail.Controls.Add(this.tabPrevisione);
			this.MetaDataDetail.Controls.Add(this.tabClassSupp);
			this.MetaDataDetail.Controls.Add(this.TabClassAutoSpese);
			this.MetaDataDetail.Controls.Add(this.TabClassAutoEntrate);
			this.MetaDataDetail.Controls.Add(this.tabRiepilogo);
			this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MetaDataDetail.HotTrack = true;
			this.MetaDataDetail.ImageList = this.imageList1;
			this.MetaDataDetail.Location = new System.Drawing.Point(331, 0);
			this.MetaDataDetail.Multiline = true;
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.SelectedIndex = 0;
			this.MetaDataDetail.Size = new System.Drawing.Size(593, 547);
			this.MetaDataDetail.TabIndex = 3;
			// 
			// tabGeneralita
			// 
			this.tabGeneralita.Controls.Add(this.gboxResponsabile);
			this.tabGeneralita.Controls.Add(this.label5);
			this.tabGeneralita.Controls.Add(this.SubEntity_cup);
			this.tabGeneralita.Controls.Add(this.chkES);
			this.tabGeneralita.Controls.Add(this.btnCreaPrevisioni);
			this.tabGeneralita.Controls.Add(this.btnSuddivisioni);
			this.tabGeneralita.Controls.Add(this.pictureBox1);
			this.tabGeneralita.Controls.Add(this.GrpboxPrevisione);
			this.tabGeneralita.Controls.Add(this.groupBox1);
			this.tabGeneralita.Controls.Add(this.grpParte);
			this.tabGeneralita.Controls.Add(this.SubEntity_txtScadenza);
			this.tabGeneralita.Controls.Add(this.lblScadenza);
			this.tabGeneralita.Controls.Add(this.txtOrdineStampa);
			this.tabGeneralita.Controls.Add(this.lblOrdineStampa);
			this.tabGeneralita.Controls.Add(this.txtDenominazione);
			this.tabGeneralita.Controls.Add(this.lblDenominazione);
			this.tabGeneralita.Controls.Add(this.txtCodice);
			this.tabGeneralita.Controls.Add(this.lblCodice);
			this.tabGeneralita.Controls.Add(this.lblLivello);
			this.tabGeneralita.Controls.Add(this.cmbLivello);
			this.tabGeneralita.Controls.Add(this.btnNewSituazione);
			this.tabGeneralita.Location = new System.Drawing.Point(4, 23);
			this.tabGeneralita.Name = "tabGeneralita";
			this.tabGeneralita.Size = new System.Drawing.Size(585, 520);
			this.tabGeneralita.TabIndex = 0;
			this.tabGeneralita.Text = "Principale";
			this.tabGeneralita.UseVisualStyleBackColor = true;
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Location = new System.Drawing.Point(11, 172);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(403, 42);
			this.gboxResponsabile.TabIndex = 7;
			this.gboxResponsabile.TabStop = false;
			this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
			this.gboxResponsabile.Text = "Responsabile";
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(6, 16);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.Size = new System.Drawing.Size(391, 20);
			this.txtResponsabile.TabIndex = 0;
			this.txtResponsabile.Tag = "manager.title?x";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(13, 217);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(173, 17);
			this.label5.TabIndex = 43;
			this.label5.Tag = "";
			this.label5.Text = "Codice Unico di Progetto (CUP)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_cup
			// 
			this.SubEntity_cup.Location = new System.Drawing.Point(13, 235);
			this.SubEntity_cup.Name = "SubEntity_cup";
			this.SubEntity_cup.Size = new System.Drawing.Size(173, 20);
			this.SubEntity_cup.TabIndex = 8;
			this.SubEntity_cup.Tag = "finlast.cupcode?finunified.cupcode";
			// 
			// chkES
			// 
			this.chkES.AutoSize = true;
			this.chkES.Location = new System.Drawing.Point(327, 217);
			this.chkES.Name = "chkES";
			this.chkES.Size = new System.Drawing.Size(56, 17);
			this.chkES.TabIndex = 2;
			this.chkES.TabStop = false;
			this.chkES.Tag = "fin.flag:0";
			this.chkES.Text = "Spesa";
			this.chkES.UseVisualStyleBackColor = true;
			this.chkES.Visible = false;
			this.chkES.CheckStateChanged += new System.EventHandler(this.chkES_CheckedChanged);
			// 
			// btnCreaPrevisioni
			// 
			this.btnCreaPrevisioni.Location = new System.Drawing.Point(458, 232);
			this.btnCreaPrevisioni.Name = "btnCreaPrevisioni";
			this.btnCreaPrevisioni.Size = new System.Drawing.Size(110, 23);
			this.btnCreaPrevisioni.TabIndex = 10;
			this.btnCreaPrevisioni.TabStop = false;
			this.btnCreaPrevisioni.Text = "Crea Previsioni";
			this.btnCreaPrevisioni.Visible = false;
			this.btnCreaPrevisioni.Click += new System.EventHandler(this.btnCreaPrevisioni_Click);
			// 
			// btnSuddivisioni
			// 
			this.btnSuddivisioni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSuddivisioni.Location = new System.Drawing.Point(427, 188);
			this.btnSuddivisioni.Name = "btnSuddivisioni";
			this.btnSuddivisioni.Size = new System.Drawing.Size(152, 23);
			this.btnSuddivisioni.TabIndex = 14;
			this.btnSuddivisioni.TabStop = false;
			this.btnSuddivisioni.Text = "Visualizza le suddivisioni";
			this.btnSuddivisioni.Click += new System.EventHandler(this.btnSuddivisioni_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(387, 39);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(56, 40);
			this.pictureBox1.TabIndex = 13;
			this.pictureBox1.TabStop = false;
			// 
			// GrpboxPrevisione
			// 
			this.GrpboxPrevisione.Controls.Add(this.groupBox4);
			this.GrpboxPrevisione.Controls.Add(this.gboxPrimaPrevisione);
			this.GrpboxPrevisione.Controls.Add(this.gboxSecondaPrevisione);
			this.GrpboxPrevisione.Controls.Add(this.gboxRipartizione);
			this.GrpboxPrevisione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GrpboxPrevisione.Location = new System.Drawing.Point(4, 266);
			this.GrpboxPrevisione.Name = "GrpboxPrevisione";
			this.GrpboxPrevisione.Size = new System.Drawing.Size(572, 224);
			this.GrpboxPrevisione.TabIndex = 11;
			this.GrpboxPrevisione.TabStop = false;
			this.GrpboxPrevisione.Text = "Bilancio di Previsione ";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.SubEntity_txtprevision5);
			this.groupBox4.Controls.Add(this.SubEntity_txtprevision4);
			this.groupBox4.Controls.Add(this.SubEntity_txtprevision3);
			this.groupBox4.Controls.Add(this.SubEntity_txtprevision2);
			this.groupBox4.Controls.Add(this.lblPrevisione5);
			this.groupBox4.Controls.Add(this.lblPrevisione4);
			this.groupBox4.Controls.Add(this.lblPrevisione3);
			this.groupBox4.Controls.Add(this.lblPrevisione2);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.Location = new System.Drawing.Point(8, 144);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(558, 72);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Previsione Esercizi Futuri";
			// 
			// SubEntity_txtprevision5
			// 
			this.SubEntity_txtprevision5.Location = new System.Drawing.Point(344, 48);
			this.SubEntity_txtprevision5.Name = "SubEntity_txtprevision5";
			this.SubEntity_txtprevision5.Size = new System.Drawing.Size(104, 20);
			this.SubEntity_txtprevision5.TabIndex = 7;
			this.SubEntity_txtprevision5.Tag = "";
			this.SubEntity_txtprevision5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SubEntity_txtprevision4
			// 
			this.SubEntity_txtprevision4.Location = new System.Drawing.Point(112, 48);
			this.SubEntity_txtprevision4.Name = "SubEntity_txtprevision4";
			this.SubEntity_txtprevision4.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtprevision4.TabIndex = 6;
			this.SubEntity_txtprevision4.Tag = "";
			this.SubEntity_txtprevision4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SubEntity_txtprevision3
			// 
			this.SubEntity_txtprevision3.Location = new System.Drawing.Point(344, 16);
			this.SubEntity_txtprevision3.Name = "SubEntity_txtprevision3";
			this.SubEntity_txtprevision3.Size = new System.Drawing.Size(104, 20);
			this.SubEntity_txtprevision3.TabIndex = 5;
			this.SubEntity_txtprevision3.Tag = "";
			this.SubEntity_txtprevision3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SubEntity_txtprevision2
			// 
			this.SubEntity_txtprevision2.Location = new System.Drawing.Point(112, 16);
			this.SubEntity_txtprevision2.Name = "SubEntity_txtprevision2";
			this.SubEntity_txtprevision2.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtprevision2.TabIndex = 4;
			this.SubEntity_txtprevision2.Tag = "";
			this.SubEntity_txtprevision2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPrevisione5
			// 
			this.lblPrevisione5.Location = new System.Drawing.Point(240, 48);
			this.lblPrevisione5.Name = "lblPrevisione5";
			this.lblPrevisione5.Size = new System.Drawing.Size(96, 16);
			this.lblPrevisione5.TabIndex = 3;
			this.lblPrevisione5.Text = "n+4";
			this.lblPrevisione5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPrevisione4
			// 
			this.lblPrevisione4.Location = new System.Drawing.Point(8, 48);
			this.lblPrevisione4.Name = "lblPrevisione4";
			this.lblPrevisione4.Size = new System.Drawing.Size(96, 16);
			this.lblPrevisione4.TabIndex = 2;
			this.lblPrevisione4.Text = "n+3";
			this.lblPrevisione4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPrevisione3
			// 
			this.lblPrevisione3.Location = new System.Drawing.Point(240, 16);
			this.lblPrevisione3.Name = "lblPrevisione3";
			this.lblPrevisione3.Size = new System.Drawing.Size(96, 16);
			this.lblPrevisione3.TabIndex = 1;
			this.lblPrevisione3.Text = "n+2";
			this.lblPrevisione3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPrevisione2
			// 
			this.lblPrevisione2.Location = new System.Drawing.Point(8, 16);
			this.lblPrevisione2.Name = "lblPrevisione2";
			this.lblPrevisione2.Size = new System.Drawing.Size(96, 16);
			this.lblPrevisione2.TabIndex = 0;
			this.lblPrevisione2.Text = "n+1";
			this.lblPrevisione2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxPrimaPrevisione
			// 
			this.gboxPrimaPrevisione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxPrimaPrevisione.Controls.Add(this.SubEntity_txtprevesercizioprec);
			this.gboxPrimaPrevisione.Controls.Add(this.lblEsPrecPrima);
			this.gboxPrimaPrevisione.Controls.Add(this.SubEntity_txtpreveserciziocorr);
			this.gboxPrimaPrevisione.Controls.Add(this.lblEsCorrentePrima);
			this.gboxPrimaPrevisione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gboxPrimaPrevisione.Location = new System.Drawing.Point(8, 16);
			this.gboxPrimaPrevisione.Name = "gboxPrimaPrevisione";
			this.gboxPrimaPrevisione.Size = new System.Drawing.Size(556, 40);
			this.gboxPrimaPrevisione.TabIndex = 1;
			this.gboxPrimaPrevisione.TabStop = false;
			this.gboxPrimaPrevisione.Text = "Previsione di competenza";
			// 
			// SubEntity_txtprevesercizioprec
			// 
			this.SubEntity_txtprevesercizioprec.Location = new System.Drawing.Point(448, 16);
			this.SubEntity_txtprevesercizioprec.Name = "SubEntity_txtprevesercizioprec";
			this.SubEntity_txtprevesercizioprec.Size = new System.Drawing.Size(104, 20);
			this.SubEntity_txtprevesercizioprec.TabIndex = 2;
			this.SubEntity_txtprevesercizioprec.Tag = "";
			this.SubEntity_txtprevesercizioprec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblEsPrecPrima
			// 
			this.lblEsPrecPrima.Location = new System.Drawing.Point(344, 16);
			this.lblEsPrecPrima.Name = "lblEsPrecPrima";
			this.lblEsPrecPrima.Size = new System.Drawing.Size(96, 16);
			this.lblEsPrecPrima.TabIndex = 2;
			this.lblEsPrecPrima.Text = "Es. precedente:";
			this.lblEsPrecPrima.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtpreveserciziocorr
			// 
			this.SubEntity_txtpreveserciziocorr.Location = new System.Drawing.Point(112, 16);
			this.SubEntity_txtpreveserciziocorr.Name = "SubEntity_txtpreveserciziocorr";
			this.SubEntity_txtpreveserciziocorr.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtpreveserciziocorr.TabIndex = 1;
			this.SubEntity_txtpreveserciziocorr.Tag = "";
			this.SubEntity_txtpreveserciziocorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblEsCorrentePrima
			// 
			this.lblEsCorrentePrima.Location = new System.Drawing.Point(8, 16);
			this.lblEsCorrentePrima.Name = "lblEsCorrentePrima";
			this.lblEsCorrentePrima.Size = new System.Drawing.Size(96, 16);
			this.lblEsCorrentePrima.TabIndex = 0;
			this.lblEsCorrentePrima.Text = "Es. corrente:";
			this.lblEsCorrentePrima.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxSecondaPrevisione
			// 
			this.gboxSecondaPrevisione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxSecondaPrevisione.Controls.Add(this.SubEntity_txtprevsecesercizioprec);
			this.gboxSecondaPrevisione.Controls.Add(this.lblEsPrecSeconda);
			this.gboxSecondaPrevisione.Controls.Add(this.SubEntity_txtprevseceserciziocorr);
			this.gboxSecondaPrevisione.Controls.Add(this.lblEsCorrSeconda);
			this.gboxSecondaPrevisione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gboxSecondaPrevisione.Location = new System.Drawing.Point(8, 56);
			this.gboxSecondaPrevisione.Name = "gboxSecondaPrevisione";
			this.gboxSecondaPrevisione.Size = new System.Drawing.Size(556, 40);
			this.gboxSecondaPrevisione.TabIndex = 2;
			this.gboxSecondaPrevisione.TabStop = false;
			this.gboxSecondaPrevisione.Text = "Previsione di cassa";
			this.gboxSecondaPrevisione.Enter += new System.EventHandler(this.gboxSecondaPrevisione_Enter);
			// 
			// SubEntity_txtprevsecesercizioprec
			// 
			this.SubEntity_txtprevsecesercizioprec.Location = new System.Drawing.Point(445, 16);
			this.SubEntity_txtprevsecesercizioprec.Name = "SubEntity_txtprevsecesercizioprec";
			this.SubEntity_txtprevsecesercizioprec.Size = new System.Drawing.Size(104, 20);
			this.SubEntity_txtprevsecesercizioprec.TabIndex = 2;
			this.SubEntity_txtprevsecesercizioprec.Tag = "";
			this.SubEntity_txtprevsecesercizioprec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblEsPrecSeconda
			// 
			this.lblEsPrecSeconda.Location = new System.Drawing.Point(341, 16);
			this.lblEsPrecSeconda.Name = "lblEsPrecSeconda";
			this.lblEsPrecSeconda.Size = new System.Drawing.Size(96, 16);
			this.lblEsPrecSeconda.TabIndex = 2;
			this.lblEsPrecSeconda.Text = "Es. precedente:";
			this.lblEsPrecSeconda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtprevseceserciziocorr
			// 
			this.SubEntity_txtprevseceserciziocorr.Location = new System.Drawing.Point(112, 16);
			this.SubEntity_txtprevseceserciziocorr.Name = "SubEntity_txtprevseceserciziocorr";
			this.SubEntity_txtprevseceserciziocorr.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtprevseceserciziocorr.TabIndex = 1;
			this.SubEntity_txtprevseceserciziocorr.Tag = "";
			this.SubEntity_txtprevseceserciziocorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblEsCorrSeconda
			// 
			this.lblEsCorrSeconda.Location = new System.Drawing.Point(8, 16);
			this.lblEsCorrSeconda.Name = "lblEsCorrSeconda";
			this.lblEsCorrSeconda.Size = new System.Drawing.Size(96, 16);
			this.lblEsCorrSeconda.TabIndex = 0;
			this.lblEsCorrSeconda.Text = "Es. corrente:";
			this.lblEsCorrSeconda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxRipartizione
			// 
			this.gboxRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxRipartizione.Controls.Add(this.SubEntity_txtripartizioneprec);
			this.gboxRipartizione.Controls.Add(this.lblRipPrecedente);
			this.gboxRipartizione.Controls.Add(this.SubEntity_txtripartizionecorr);
			this.gboxRipartizione.Controls.Add(this.lblRipCorrente);
			this.gboxRipartizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gboxRipartizione.Location = new System.Drawing.Point(8, 96);
			this.gboxRipartizione.Name = "gboxRipartizione";
			this.gboxRipartizione.Size = new System.Drawing.Size(556, 48);
			this.gboxRipartizione.TabIndex = 3;
			this.gboxRipartizione.TabStop = false;
			this.gboxRipartizione.Text = "Residui dell\'anno precedente";
			// 
			// SubEntity_txtripartizioneprec
			// 
			this.SubEntity_txtripartizioneprec.Location = new System.Drawing.Point(448, 13);
			this.SubEntity_txtripartizioneprec.Name = "SubEntity_txtripartizioneprec";
			this.SubEntity_txtripartizioneprec.Size = new System.Drawing.Size(104, 20);
			this.SubEntity_txtripartizioneprec.TabIndex = 2;
			this.SubEntity_txtripartizioneprec.Tag = "";
			this.SubEntity_txtripartizioneprec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblRipPrecedente
			// 
			this.lblRipPrecedente.Location = new System.Drawing.Point(344, 15);
			this.lblRipPrecedente.Name = "lblRipPrecedente";
			this.lblRipPrecedente.Size = new System.Drawing.Size(96, 16);
			this.lblRipPrecedente.TabIndex = 2;
			this.lblRipPrecedente.Text = "Es. precedente:";
			this.lblRipPrecedente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtripartizionecorr
			// 
			this.SubEntity_txtripartizionecorr.Location = new System.Drawing.Point(112, 14);
			this.SubEntity_txtripartizionecorr.Name = "SubEntity_txtripartizionecorr";
			this.SubEntity_txtripartizionecorr.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtripartizionecorr.TabIndex = 1;
			this.SubEntity_txtripartizionecorr.Tag = "";
			this.SubEntity_txtripartizionecorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblRipCorrente
			// 
			this.lblRipCorrente.Location = new System.Drawing.Point(8, 16);
			this.lblRipCorrente.Name = "lblRipCorrente";
			this.lblRipCorrente.Size = new System.Drawing.Size(96, 16);
			this.lblRipCorrente.TabIndex = 0;
			this.lblRipCorrente.Text = "Es. corrente:";
			this.lblRipCorrente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.chkNoContab);
			this.groupBox1.Controls.Add(this.chkAvanzoUscita);
			this.groupBox1.Controls.Add(this.chkAvanzoEntrata);
			this.groupBox1.Controls.Add(this.chkMovProtetta);
			this.groupBox1.Controls.Add(this.chbPartiteGiro);
			this.groupBox1.Controls.Add(this.chbTrasferimenti);
			this.groupBox1.Location = new System.Drawing.Point(457, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 163);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// chkNoContab
			// 
			this.chkNoContab.Location = new System.Drawing.Point(6, 102);
			this.chkNoContab.Name = "chkNoContab";
			this.chkNoContab.Size = new System.Drawing.Size(108, 55);
			this.chkNoContab.TabIndex = 15;
			this.chkNoContab.Tag = "fin.flag:6";
			this.chkNoContab.Text = "Permetti movim. non legata a contabilizzazione";
			this.chkNoContab.ThreeState = true;
			// 
			// chkAvanzoUscita
			// 
			this.chkAvanzoUscita.Location = new System.Drawing.Point(6, 85);
			this.chkAvanzoUscita.Name = "chkAvanzoUscita";
			this.chkAvanzoUscita.Size = new System.Drawing.Size(108, 19);
			this.chkAvanzoUscita.TabIndex = 14;
			this.chkAvanzoUscita.Tag = "fin.flag:5";
			this.chkAvanzoUscita.Text = "Avanzo (spese)";
			this.chkAvanzoUscita.ThreeState = true;
			this.chkAvanzoUscita.Click += new System.EventHandler(this.chbAvanzo_Click);
			// 
			// chkAvanzoEntrata
			// 
			this.chkAvanzoEntrata.Location = new System.Drawing.Point(6, 66);
			this.chkAvanzoEntrata.Name = "chkAvanzoEntrata";
			this.chkAvanzoEntrata.Size = new System.Drawing.Size(108, 19);
			this.chkAvanzoEntrata.TabIndex = 13;
			this.chkAvanzoEntrata.Tag = "fin.flag:4";
			this.chkAvanzoEntrata.Text = "Avanzo (entrate)";
			this.chkAvanzoEntrata.ThreeState = true;
			this.chkAvanzoEntrata.Click += new System.EventHandler(this.chbAvanzo_Click);
			// 
			// chkMovProtetta
			// 
			this.chkMovProtetta.Location = new System.Drawing.Point(6, 47);
			this.chkMovProtetta.Name = "chkMovProtetta";
			this.chkMovProtetta.Size = new System.Drawing.Size(108, 19);
			this.chkMovProtetta.TabIndex = 12;
			this.chkMovProtetta.Tag = "fin.flag:3";
			this.chkMovProtetta.Text = "Movim. protetta";
			this.chkMovProtetta.ThreeState = true;
			this.chkMovProtetta.Click += new System.EventHandler(this.chbAvanzo_Click);
			// 
			// chbPartiteGiro
			// 
			this.chbPartiteGiro.Location = new System.Drawing.Point(6, 9);
			this.chbPartiteGiro.Name = "chbPartiteGiro";
			this.chbPartiteGiro.Size = new System.Drawing.Size(96, 21);
			this.chbPartiteGiro.TabIndex = 10;
			this.chbPartiteGiro.Tag = "fin.flag:1";
			this.chbPartiteGiro.Text = "Partite di giro";
			this.chbPartiteGiro.ThreeState = true;
			this.chbPartiteGiro.Click += new System.EventHandler(this.chbAvanzo_Click);
			// 
			// chbTrasferimenti
			// 
			this.chbTrasferimenti.Location = new System.Drawing.Point(6, 26);
			this.chbTrasferimenti.Name = "chbTrasferimenti";
			this.chbTrasferimenti.Size = new System.Drawing.Size(100, 23);
			this.chbTrasferimenti.TabIndex = 11;
			this.chbTrasferimenti.Tag = "fin.flag:2";
			this.chbTrasferimenti.Text = "Trasf. interni";
			this.chbTrasferimenti.ThreeState = true;
			this.chbTrasferimenti.Click += new System.EventHandler(this.chbAvanzo_Click);
			// 
			// grpParte
			// 
			this.grpParte.Controls.Add(this.rdbSpesa);
			this.grpParte.Controls.Add(this.rdbEntrata);
			this.grpParte.Location = new System.Drawing.Point(180, 3);
			this.grpParte.Name = "grpParte";
			this.grpParte.Size = new System.Drawing.Size(157, 38);
			this.grpParte.TabIndex = 2;
			this.grpParte.TabStop = false;
			this.grpParte.Text = "Parte";
			// 
			// rdbSpesa
			// 
			this.rdbSpesa.Location = new System.Drawing.Point(78, 14);
			this.rdbSpesa.Name = "rdbSpesa";
			this.rdbSpesa.Size = new System.Drawing.Size(56, 16);
			this.rdbSpesa.TabIndex = 1;
			this.rdbSpesa.Tag = "";
			this.rdbSpesa.Text = "Spesa";
			this.rdbSpesa.CheckedChanged += new System.EventHandler(this.rdbSpesa_CheckedChanged);
			// 
			// rdbEntrata
			// 
			this.rdbEntrata.Location = new System.Drawing.Point(8, 14);
			this.rdbEntrata.Name = "rdbEntrata";
			this.rdbEntrata.Size = new System.Drawing.Size(64, 16);
			this.rdbEntrata.TabIndex = 0;
			this.rdbEntrata.Tag = "";
			this.rdbEntrata.Text = "Entrata";
			this.rdbEntrata.CheckedChanged += new System.EventHandler(this.rdbEntrata_CheckedChanged);
			// 
			// SubEntity_txtScadenza
			// 
			this.SubEntity_txtScadenza.Location = new System.Drawing.Point(207, 236);
			this.SubEntity_txtScadenza.Name = "SubEntity_txtScadenza";
			this.SubEntity_txtScadenza.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtScadenza.TabIndex = 9;
			this.SubEntity_txtScadenza.Tag = "finlast.expiration?finunified.expiration";
			// 
			// lblScadenza
			// 
			this.lblScadenza.Location = new System.Drawing.Point(207, 220);
			this.lblScadenza.Name = "lblScadenza";
			this.lblScadenza.Size = new System.Drawing.Size(88, 16);
			this.lblScadenza.TabIndex = 12;
			this.lblScadenza.Text = "Data Scadenza:";
			this.lblScadenza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtOrdineStampa
			// 
			this.txtOrdineStampa.Location = new System.Drawing.Point(177, 69);
			this.txtOrdineStampa.Name = "txtOrdineStampa";
			this.txtOrdineStampa.Size = new System.Drawing.Size(160, 20);
			this.txtOrdineStampa.TabIndex = 4;
			this.txtOrdineStampa.Tag = "fin.printingorder";
			// 
			// lblOrdineStampa
			// 
			this.lblOrdineStampa.Location = new System.Drawing.Point(177, 50);
			this.lblOrdineStampa.Name = "lblOrdineStampa";
			this.lblOrdineStampa.Size = new System.Drawing.Size(96, 16);
			this.lblOrdineStampa.TabIndex = 8;
			this.lblOrdineStampa.Text = "Ordine di stampa:";
			this.lblOrdineStampa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDenominazione
			// 
			this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazione.Location = new System.Drawing.Point(11, 110);
			this.txtDenominazione.Multiline = true;
			this.txtDenominazione.Name = "txtDenominazione";
			this.txtDenominazione.Size = new System.Drawing.Size(437, 55);
			this.txtDenominazione.TabIndex = 6;
			this.txtDenominazione.Tag = "fin.title";
			// 
			// lblDenominazione
			// 
			this.lblDenominazione.Location = new System.Drawing.Point(11, 91);
			this.lblDenominazione.Name = "lblDenominazione";
			this.lblDenominazione.Size = new System.Drawing.Size(88, 16);
			this.lblDenominazione.TabIndex = 6;
			this.lblDenominazione.Text = "Descrizione:";
			this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(11, 68);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(160, 20);
			this.txtCodice.TabIndex = 3;
			this.txtCodice.Tag = "fin.codefin";
			// 
			// lblCodice
			// 
			this.lblCodice.Location = new System.Drawing.Point(8, 50);
			this.lblCodice.Name = "lblCodice";
			this.lblCodice.Size = new System.Drawing.Size(88, 16);
			this.lblCodice.TabIndex = 4;
			this.lblCodice.Text = "Codice:";
			this.lblCodice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblLivello
			// 
			this.lblLivello.Location = new System.Drawing.Point(8, 3);
			this.lblLivello.Name = "lblLivello";
			this.lblLivello.Size = new System.Drawing.Size(104, 14);
			this.lblLivello.TabIndex = 3;
			this.lblLivello.Text = "Livello gerarchico:";
			this.lblLivello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbLivello
			// 
			this.cmbLivello.DataSource = this.DS.finlevel;
			this.cmbLivello.DisplayMember = "description";
			this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLivello.Location = new System.Drawing.Point(8, 20);
			this.cmbLivello.Name = "cmbLivello";
			this.cmbLivello.Size = new System.Drawing.Size(160, 21);
			this.cmbLivello.TabIndex = 1;
			this.cmbLivello.Tag = "fin.nlevel?finunified.nlevel";
			this.cmbLivello.ValueMember = "nlevel";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// btnNewSituazione
			// 
			this.btnNewSituazione.Location = new System.Drawing.Point(355, 10);
			this.btnNewSituazione.Name = "btnNewSituazione";
			this.btnNewSituazione.Size = new System.Drawing.Size(88, 23);
			this.btnNewSituazione.TabIndex = 2;
			this.btnNewSituazione.TabStop = false;
			this.btnNewSituazione.Text = "Situazione";
			this.btnNewSituazione.Visible = false;
			this.btnNewSituazione.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabPrevisione
			// 
			this.tabPrevisione.Controls.Add(this.dgPrevisione);
			this.tabPrevisione.Controls.Add(this.btnInsPrevisione);
			this.tabPrevisione.Controls.Add(this.btnEditPrevisione);
			this.tabPrevisione.Controls.Add(this.btnDelPrevisione);
			this.tabPrevisione.Controls.Add(this.groupBox2);
			this.tabPrevisione.Location = new System.Drawing.Point(4, 23);
			this.tabPrevisione.Name = "tabPrevisione";
			this.tabPrevisione.Size = new System.Drawing.Size(603, 520);
			this.tabPrevisione.TabIndex = 2;
			this.tabPrevisione.Text = "Previsione";
			this.tabPrevisione.UseVisualStyleBackColor = true;
			// 
			// dgPrevisione
			// 
			this.dgPrevisione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgPrevisione.DataMember = "";
			this.dgPrevisione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgPrevisione.Location = new System.Drawing.Point(95, 5);
			this.dgPrevisione.Name = "dgPrevisione";
			this.dgPrevisione.Size = new System.Drawing.Size(500, 312);
			this.dgPrevisione.TabIndex = 18;
			this.dgPrevisione.Tag = "finyearview.previsionupb.previsionupb";
			// 
			// btnInsPrevisione
			// 
			this.btnInsPrevisione.Location = new System.Drawing.Point(3, 5);
			this.btnInsPrevisione.Name = "btnInsPrevisione";
			this.btnInsPrevisione.Size = new System.Drawing.Size(86, 26);
			this.btnInsPrevisione.TabIndex = 15;
			this.btnInsPrevisione.Tag = "insert.previsionupb";
			this.btnInsPrevisione.Text = "Inserisci";
			// 
			// btnEditPrevisione
			// 
			this.btnEditPrevisione.Location = new System.Drawing.Point(3, 37);
			this.btnEditPrevisione.Name = "btnEditPrevisione";
			this.btnEditPrevisione.Size = new System.Drawing.Size(86, 26);
			this.btnEditPrevisione.TabIndex = 16;
			this.btnEditPrevisione.Tag = "edit.previsionupb";
			this.btnEditPrevisione.Text = "Modifica";
			// 
			// btnDelPrevisione
			// 
			this.btnDelPrevisione.Location = new System.Drawing.Point(3, 69);
			this.btnDelPrevisione.Name = "btnDelPrevisione";
			this.btnDelPrevisione.Size = new System.Drawing.Size(86, 26);
			this.btnDelPrevisione.TabIndex = 17;
			this.btnDelPrevisione.Tag = "delete";
			this.btnDelPrevisione.Text = "Elimina";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.dgVariazioni);
			this.groupBox2.Location = new System.Drawing.Point(10, 323);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(590, 186);
			this.groupBox2.TabIndex = 20;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Variazioni Bilancio";
			// 
			// dgVariazioni
			// 
			this.dgVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgVariazioni.DataMember = "";
			this.dgVariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgVariazioni.Location = new System.Drawing.Point(6, 19);
			this.dgVariazioni.Name = "dgVariazioni";
			this.dgVariazioni.Size = new System.Drawing.Size(579, 157);
			this.dgVariazioni.TabIndex = 20;
			this.dgVariazioni.Tag = "finvardetailview.bilancio";
			// 
			// tabClassSupp
			// 
			this.tabClassSupp.Controls.Add(this.gBoxCausalePartiteGiro);
			this.tabClassSupp.Controls.Add(this.gboxConto);
			this.tabClassSupp.Controls.Add(this.dGridClassSup);
			this.tabClassSupp.Controls.Add(this.btnElimina);
			this.tabClassSupp.Controls.Add(this.btnModifica);
			this.tabClassSupp.Controls.Add(this.btnInserisci);
			this.tabClassSupp.ImageIndex = 0;
			this.tabClassSupp.Location = new System.Drawing.Point(4, 23);
			this.tabClassSupp.Name = "tabClassSupp";
			this.tabClassSupp.Size = new System.Drawing.Size(603, 520);
			this.tabClassSupp.TabIndex = 1;
			this.tabClassSupp.Text = "Classificazione";
			this.tabClassSupp.UseVisualStyleBackColor = true;
			this.tabClassSupp.Visible = false;
			// 
			// gBoxCausalePartiteGiro
			// 
			this.gBoxCausalePartiteGiro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.gBoxCausalePartiteGiro.Controls.Add(this.textBox1);
			this.gBoxCausalePartiteGiro.Controls.Add(this.txtCodiceCausaleDeb);
			this.gBoxCausalePartiteGiro.Controls.Add(this.button6);
			this.gBoxCausalePartiteGiro.Location = new System.Drawing.Point(11, 419);
			this.gBoxCausalePartiteGiro.Name = "gBoxCausalePartiteGiro";
			this.gBoxCausalePartiteGiro.Size = new System.Drawing.Size(367, 80);
			this.gBoxCausalePartiteGiro.TabIndex = 47;
			this.gBoxCausalePartiteGiro.TabStop = false;
			this.gBoxCausalePartiteGiro.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
			this.gBoxCausalePartiteGiro.Text = "Causale EP partite di Giro";
			this.gBoxCausalePartiteGiro.UseCompatibleTextRendering = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(161, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(200, 56);
			this.textBox1.TabIndex = 2;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "accmotiveapplied.motive";
			// 
			// txtCodiceCausaleDeb
			// 
			this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(10, 48);
			this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
			this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(145, 20);
			this.txtCodiceCausaleDeb.TabIndex = 1;
			this.txtCodiceCausaleDeb.Tag = "accmotiveapplied.codemotive?finview.codemotive";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(8, 16);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 23);
			this.button6.TabIndex = 0;
			this.button6.TabStop = false;
			this.button6.Tag = "manage.accmotiveapplied.tree";
			this.button6.Text = "Causale";
			// 
			// gboxConto
			// 
			this.gboxConto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.gboxConto.Controls.Add(this.txtDenominazioneConto);
			this.gboxConto.Controls.Add(this.txtCodiceConto);
			this.gboxConto.Controls.Add(this.button1);
			this.gboxConto.Location = new System.Drawing.Point(8, 305);
			this.gboxConto.Name = "gboxConto";
			this.gboxConto.Size = new System.Drawing.Size(370, 108);
			this.gboxConto.TabIndex = 46;
			this.gboxConto.TabStop = false;
			this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
			this.gboxConto.Text = "Conto EP per la stampa degli OPI";
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Location = new System.Drawing.Point(139, 16);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(223, 52);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account.title";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(9, 76);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(353, 20);
			this.txtCodiceConto.TabIndex = 1;
			this.txtCodiceConto.Tag = "account.codeacc?entrydetailview.codeacc";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 47);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 23);
			this.button1.TabIndex = 0;
			this.button1.TabStop = false;
			this.button1.Tag = "manage.account.tree";
			this.button1.Text = "Conto";
			// 
			// dGridClassSup
			// 
			this.dGridClassSup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dGridClassSup.DataMember = "";
			this.dGridClassSup.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridClassSup.Location = new System.Drawing.Point(88, 8);
			this.dGridClassSup.Name = "dGridClassSup";
			this.dGridClassSup.Size = new System.Drawing.Size(507, 274);
			this.dGridClassSup.TabIndex = 14;
			this.dGridClassSup.Tag = "finsorting.default.single";
			// 
			// btnElimina
			// 
			this.btnElimina.Location = new System.Drawing.Point(8, 72);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(72, 24);
			this.btnElimina.TabIndex = 13;
			this.btnElimina.Tag = "delete";
			this.btnElimina.Text = "Elimina";
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(8, 40);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(72, 24);
			this.btnModifica.TabIndex = 12;
			this.btnModifica.Tag = "edit.single";
			this.btnModifica.Text = "Modifica";
			// 
			// btnInserisci
			// 
			this.btnInserisci.Location = new System.Drawing.Point(8, 8);
			this.btnInserisci.Name = "btnInserisci";
			this.btnInserisci.Size = new System.Drawing.Size(72, 24);
			this.btnInserisci.TabIndex = 11;
			this.btnInserisci.Tag = "insert.single";
			this.btnInserisci.Text = "Inserisci";
			// 
			// TabClassAutoSpese
			// 
			this.TabClassAutoSpese.Controls.Add(this.groupBox6);
			this.TabClassAutoSpese.Controls.Add(this.groupBox7);
			this.TabClassAutoSpese.Location = new System.Drawing.Point(4, 23);
			this.TabClassAutoSpese.Name = "TabClassAutoSpese";
			this.TabClassAutoSpese.Size = new System.Drawing.Size(603, 520);
			this.TabClassAutoSpese.TabIndex = 4;
			this.TabClassAutoSpese.Text = "Class. Autom. Spese";
			this.TabClassAutoSpese.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.dGridFilterClassExp);
			this.groupBox6.Controls.Add(this.btnEliminaFilterS);
			this.groupBox6.Controls.Add(this.btnModificaFilterS);
			this.groupBox6.Controls.Add(this.btnInserisciFilterS);
			this.groupBox6.Location = new System.Drawing.Point(7, 240);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(590, 269);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Filtri Classificazione Automatica delle Spese";
			// 
			// dGridFilterClassExp
			// 
			this.dGridFilterClassExp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dGridFilterClassExp.DataMember = "";
			this.dGridFilterClassExp.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridFilterClassExp.Location = new System.Drawing.Point(84, 19);
			this.dGridFilterClassExp.Name = "dGridFilterClassExp";
			this.dGridFilterClassExp.Size = new System.Drawing.Size(503, 244);
			this.dGridFilterClassExp.TabIndex = 24;
			this.dGridFilterClassExp.Tag = "sortingexpensefilter.fin.single";
			// 
			// btnEliminaFilterS
			// 
			this.btnEliminaFilterS.Location = new System.Drawing.Point(6, 83);
			this.btnEliminaFilterS.Name = "btnEliminaFilterS";
			this.btnEliminaFilterS.Size = new System.Drawing.Size(72, 24);
			this.btnEliminaFilterS.TabIndex = 23;
			this.btnEliminaFilterS.Tag = "delete";
			this.btnEliminaFilterS.Text = "Elimina";
			// 
			// btnModificaFilterS
			// 
			this.btnModificaFilterS.Location = new System.Drawing.Point(6, 51);
			this.btnModificaFilterS.Name = "btnModificaFilterS";
			this.btnModificaFilterS.Size = new System.Drawing.Size(72, 24);
			this.btnModificaFilterS.TabIndex = 22;
			this.btnModificaFilterS.Tag = "edit.single";
			this.btnModificaFilterS.Text = "Modifica";
			// 
			// btnInserisciFilterS
			// 
			this.btnInserisciFilterS.Location = new System.Drawing.Point(6, 19);
			this.btnInserisciFilterS.Name = "btnInserisciFilterS";
			this.btnInserisciFilterS.Size = new System.Drawing.Size(72, 24);
			this.btnInserisciFilterS.TabIndex = 21;
			this.btnInserisciFilterS.Tag = "insert.single";
			this.btnInserisciFilterS.Text = "Inserisci";
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.dGridClassAutoExp);
			this.groupBox7.Controls.Add(this.btnEliminaClassS);
			this.groupBox7.Controls.Add(this.btnModificaClassS);
			this.groupBox7.Controls.Add(this.btnInserisciClassS);
			this.groupBox7.Location = new System.Drawing.Point(6, 9);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(590, 221);
			this.groupBox7.TabIndex = 2;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Configurazione Classificazione Automatica delle Spese";
			// 
			// dGridClassAutoExp
			// 
			this.dGridClassAutoExp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dGridClassAutoExp.DataMember = "";
			this.dGridClassAutoExp.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridClassAutoExp.Location = new System.Drawing.Point(81, 19);
			this.dGridClassAutoExp.Name = "dGridClassAutoExp";
			this.dGridClassAutoExp.Size = new System.Drawing.Size(504, 196);
			this.dGridClassAutoExp.TabIndex = 21;
			this.dGridClassAutoExp.Tag = "autoexpensesorting.fin.single";
			// 
			// btnEliminaClassS
			// 
			this.btnEliminaClassS.Location = new System.Drawing.Point(4, 81);
			this.btnEliminaClassS.Name = "btnEliminaClassS";
			this.btnEliminaClassS.Size = new System.Drawing.Size(72, 24);
			this.btnEliminaClassS.TabIndex = 20;
			this.btnEliminaClassS.Tag = "delete";
			this.btnEliminaClassS.Text = "Elimina";
			// 
			// btnModificaClassS
			// 
			this.btnModificaClassS.Location = new System.Drawing.Point(4, 49);
			this.btnModificaClassS.Name = "btnModificaClassS";
			this.btnModificaClassS.Size = new System.Drawing.Size(72, 24);
			this.btnModificaClassS.TabIndex = 19;
			this.btnModificaClassS.Tag = "edit.single";
			this.btnModificaClassS.Text = "Modifica";
			// 
			// btnInserisciClassS
			// 
			this.btnInserisciClassS.Location = new System.Drawing.Point(4, 17);
			this.btnInserisciClassS.Name = "btnInserisciClassS";
			this.btnInserisciClassS.Size = new System.Drawing.Size(72, 24);
			this.btnInserisciClassS.TabIndex = 18;
			this.btnInserisciClassS.Tag = "insert.single";
			this.btnInserisciClassS.Text = "Inserisci";
			// 
			// TabClassAutoEntrate
			// 
			this.TabClassAutoEntrate.Controls.Add(this.groupBox8);
			this.TabClassAutoEntrate.Controls.Add(this.groupBox9);
			this.TabClassAutoEntrate.Location = new System.Drawing.Point(4, 23);
			this.TabClassAutoEntrate.Name = "TabClassAutoEntrate";
			this.TabClassAutoEntrate.Size = new System.Drawing.Size(603, 520);
			this.TabClassAutoEntrate.TabIndex = 5;
			this.TabClassAutoEntrate.Text = "Class. Autom. Entrate";
			this.TabClassAutoEntrate.UseVisualStyleBackColor = true;
			// 
			// groupBox8
			// 
			this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox8.Controls.Add(this.dGridFilterClassInc);
			this.groupBox8.Controls.Add(this.btnEliminaFilterE);
			this.groupBox8.Controls.Add(this.btnModificaFilterE);
			this.groupBox8.Controls.Add(this.btnInserisciFilterE);
			this.groupBox8.Location = new System.Drawing.Point(8, 240);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(591, 269);
			this.groupBox8.TabIndex = 5;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Filtri Classificazione Automatica delle Entrate";
			// 
			// dGridFilterClassInc
			// 
			this.dGridFilterClassInc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dGridFilterClassInc.DataMember = "";
			this.dGridFilterClassInc.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridFilterClassInc.Location = new System.Drawing.Point(84, 19);
			this.dGridFilterClassInc.Name = "dGridFilterClassInc";
			this.dGridFilterClassInc.Size = new System.Drawing.Size(503, 244);
			this.dGridFilterClassInc.TabIndex = 24;
			this.dGridFilterClassInc.Tag = "sortingincomefilter.fin.single";
			// 
			// btnEliminaFilterE
			// 
			this.btnEliminaFilterE.Location = new System.Drawing.Point(6, 83);
			this.btnEliminaFilterE.Name = "btnEliminaFilterE";
			this.btnEliminaFilterE.Size = new System.Drawing.Size(72, 24);
			this.btnEliminaFilterE.TabIndex = 23;
			this.btnEliminaFilterE.Tag = "delete";
			this.btnEliminaFilterE.Text = "Elimina";
			// 
			// btnModificaFilterE
			// 
			this.btnModificaFilterE.Location = new System.Drawing.Point(6, 51);
			this.btnModificaFilterE.Name = "btnModificaFilterE";
			this.btnModificaFilterE.Size = new System.Drawing.Size(72, 24);
			this.btnModificaFilterE.TabIndex = 22;
			this.btnModificaFilterE.Tag = "edit.single";
			this.btnModificaFilterE.Text = "Modifica";
			// 
			// btnInserisciFilterE
			// 
			this.btnInserisciFilterE.Location = new System.Drawing.Point(6, 19);
			this.btnInserisciFilterE.Name = "btnInserisciFilterE";
			this.btnInserisciFilterE.Size = new System.Drawing.Size(72, 24);
			this.btnInserisciFilterE.TabIndex = 21;
			this.btnInserisciFilterE.Tag = "insert.single";
			this.btnInserisciFilterE.Text = "Inserisci";
			// 
			// groupBox9
			// 
			this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox9.Controls.Add(this.dGridClassAutoInc);
			this.groupBox9.Controls.Add(this.btnEliminaClassE);
			this.groupBox9.Controls.Add(this.btnModificaClassE);
			this.groupBox9.Controls.Add(this.btnInserisciClassE);
			this.groupBox9.Location = new System.Drawing.Point(6, 9);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(590, 221);
			this.groupBox9.TabIndex = 4;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Configurazione Classificazione Automatica delle Entrate";
			// 
			// dGridClassAutoInc
			// 
			this.dGridClassAutoInc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dGridClassAutoInc.DataMember = "";
			this.dGridClassAutoInc.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridClassAutoInc.Location = new System.Drawing.Point(81, 19);
			this.dGridClassAutoInc.Name = "dGridClassAutoInc";
			this.dGridClassAutoInc.Size = new System.Drawing.Size(504, 196);
			this.dGridClassAutoInc.TabIndex = 21;
			this.dGridClassAutoInc.Tag = "autoincomesorting.fin.single";
			// 
			// btnEliminaClassE
			// 
			this.btnEliminaClassE.Location = new System.Drawing.Point(4, 81);
			this.btnEliminaClassE.Name = "btnEliminaClassE";
			this.btnEliminaClassE.Size = new System.Drawing.Size(72, 24);
			this.btnEliminaClassE.TabIndex = 20;
			this.btnEliminaClassE.Tag = "delete";
			this.btnEliminaClassE.Text = "Elimina";
			// 
			// btnModificaClassE
			// 
			this.btnModificaClassE.Location = new System.Drawing.Point(4, 49);
			this.btnModificaClassE.Name = "btnModificaClassE";
			this.btnModificaClassE.Size = new System.Drawing.Size(72, 24);
			this.btnModificaClassE.TabIndex = 19;
			this.btnModificaClassE.Tag = "edit.single";
			this.btnModificaClassE.Text = "Modifica";
			// 
			// btnInserisciClassE
			// 
			this.btnInserisciClassE.Location = new System.Drawing.Point(4, 17);
			this.btnInserisciClassE.Name = "btnInserisciClassE";
			this.btnInserisciClassE.Size = new System.Drawing.Size(72, 24);
			this.btnInserisciClassE.TabIndex = 18;
			this.btnInserisciClassE.Tag = "insert.single";
			this.btnInserisciClassE.Text = "Inserisci";
			// 
			// tabRiepilogo
			// 
			this.tabRiepilogo.Controls.Add(this.tabControlRiepilogo);
			this.tabRiepilogo.Controls.Add(this.btnCalcolaTotali);
			this.tabRiepilogo.Location = new System.Drawing.Point(4, 23);
			this.tabRiepilogo.Name = "tabRiepilogo";
			this.tabRiepilogo.Padding = new System.Windows.Forms.Padding(3);
			this.tabRiepilogo.Size = new System.Drawing.Size(603, 520);
			this.tabRiepilogo.TabIndex = 3;
			this.tabRiepilogo.Text = "Riepilogo";
			this.tabRiepilogo.UseVisualStyleBackColor = true;
			// 
			// tabControlRiepilogo
			// 
			this.tabControlRiepilogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlRiepilogo.Controls.Add(this.tabCompetenza);
			this.tabControlRiepilogo.Controls.Add(this.tabCassa);
			this.tabControlRiepilogo.Controls.Add(this.tabCrediti);
			this.tabControlRiepilogo.Controls.Add(this.tabAssCassa);
			this.tabControlRiepilogo.Location = new System.Drawing.Point(6, 37);
			this.tabControlRiepilogo.Name = "tabControlRiepilogo";
			this.tabControlRiepilogo.SelectedIndex = 0;
			this.tabControlRiepilogo.Size = new System.Drawing.Size(589, 461);
			this.tabControlRiepilogo.TabIndex = 57;
			// 
			// tabCompetenza
			// 
			this.tabCompetenza.Controls.Add(this.grpPrevCompetenza);
			this.tabCompetenza.Location = new System.Drawing.Point(4, 22);
			this.tabCompetenza.Name = "tabCompetenza";
			this.tabCompetenza.Padding = new System.Windows.Forms.Padding(3);
			this.tabCompetenza.Size = new System.Drawing.Size(581, 435);
			this.tabCompetenza.TabIndex = 0;
			this.tabCompetenza.Text = "Previsione di competenza";
			this.tabCompetenza.UseVisualStyleBackColor = true;
			// 
			// grpPrevCompetenza
			// 
			this.grpPrevCompetenza.Controls.Add(this.label7);
			this.grpPrevCompetenza.Controls.Add(this.label6);
			this.grpPrevCompetenza.Controls.Add(this.txtPrevAttualeCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.btnPiccoleSpeseImp);
			this.grpPrevCompetenza.Controls.Add(this.lblPiccoleSpeseImp);
			this.grpPrevCompetenza.Controls.Add(this.txtPiccoleSpeseImp);
			this.grpPrevCompetenza.Controls.Add(this.btnAccertamentiCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.lblAccertamentiCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.txtAccertamentiCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.label1);
			this.grpPrevCompetenza.Controls.Add(this.btnVarPrevCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.lblVarPrevCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.txtVarPrevCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.lblPrevDispCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.txtPrevDispCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.btnImpegniCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.lblImpegniCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.txtImpegniCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.btnPrevInizialeCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.lblPrevInizialeCompetenza);
			this.grpPrevCompetenza.Controls.Add(this.txtPrevInizialeCompetenza);
			this.grpPrevCompetenza.Location = new System.Drawing.Point(6, 6);
			this.grpPrevCompetenza.Name = "grpPrevCompetenza";
			this.grpPrevCompetenza.Size = new System.Drawing.Size(485, 284);
			this.grpPrevCompetenza.TabIndex = 56;
			this.grpPrevCompetenza.TabStop = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(347, 80);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "= A + B";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 79);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(198, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Previsione  attuale di Competenza";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevAttualeCompetenza
			// 
			this.txtPrevAttualeCompetenza.Location = new System.Drawing.Point(220, 77);
			this.txtPrevAttualeCompetenza.Name = "txtPrevAttualeCompetenza";
			this.txtPrevAttualeCompetenza.ReadOnly = true;
			this.txtPrevAttualeCompetenza.Size = new System.Drawing.Size(121, 20);
			this.txtPrevAttualeCompetenza.TabIndex = 14;
			this.txtPrevAttualeCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPiccoleSpeseImp
			// 
			this.btnPiccoleSpeseImp.Location = new System.Drawing.Point(347, 165);
			this.btnPiccoleSpeseImp.Name = "btnPiccoleSpeseImp";
			this.btnPiccoleSpeseImp.Size = new System.Drawing.Size(75, 20);
			this.btnPiccoleSpeseImp.TabIndex = 12;
			this.btnPiccoleSpeseImp.Text = "D ";
			this.btnPiccoleSpeseImp.UseVisualStyleBackColor = true;
			this.btnPiccoleSpeseImp.Click += new System.EventHandler(this.btnPiccoleSpeseImp_Click);
			// 
			// lblPiccoleSpeseImp
			// 
			this.lblPiccoleSpeseImp.Location = new System.Drawing.Point(16, 168);
			this.lblPiccoleSpeseImp.Name = "lblPiccoleSpeseImp";
			this.lblPiccoleSpeseImp.Size = new System.Drawing.Size(198, 13);
			this.lblPiccoleSpeseImp.TabIndex = 10;
			this.lblPiccoleSpeseImp.Text = "Piccole spese non reintegrate";
			this.lblPiccoleSpeseImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPiccoleSpeseImp
			// 
			this.txtPiccoleSpeseImp.Location = new System.Drawing.Point(220, 166);
			this.txtPiccoleSpeseImp.Name = "txtPiccoleSpeseImp";
			this.txtPiccoleSpeseImp.ReadOnly = true;
			this.txtPiccoleSpeseImp.Size = new System.Drawing.Size(121, 20);
			this.txtPiccoleSpeseImp.TabIndex = 11;
			this.txtPiccoleSpeseImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnAccertamentiCompetenza
			// 
			this.btnAccertamentiCompetenza.Location = new System.Drawing.Point(347, 138);
			this.btnAccertamentiCompetenza.Name = "btnAccertamentiCompetenza";
			this.btnAccertamentiCompetenza.Size = new System.Drawing.Size(75, 20);
			this.btnAccertamentiCompetenza.TabIndex = 7;
			this.btnAccertamentiCompetenza.Text = "C";
			this.btnAccertamentiCompetenza.UseVisualStyleBackColor = true;
			this.btnAccertamentiCompetenza.Click += new System.EventHandler(this.btnAccertamentiCompetenza_Click);
			// 
			// lblAccertamentiCompetenza
			// 
			this.lblAccertamentiCompetenza.Location = new System.Drawing.Point(16, 139);
			this.lblAccertamentiCompetenza.Name = "lblAccertamentiCompetenza";
			this.lblAccertamentiCompetenza.Size = new System.Drawing.Size(198, 13);
			this.lblAccertamentiCompetenza.TabIndex = 0;
			this.lblAccertamentiCompetenza.Text = "Accertamenti  di Competenza";
			this.lblAccertamentiCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAccertamentiCompetenza
			// 
			this.txtAccertamentiCompetenza.Location = new System.Drawing.Point(220, 137);
			this.txtAccertamentiCompetenza.Name = "txtAccertamentiCompetenza";
			this.txtAccertamentiCompetenza.ReadOnly = true;
			this.txtAccertamentiCompetenza.Size = new System.Drawing.Size(121, 20);
			this.txtAccertamentiCompetenza.TabIndex = 6;
			this.txtAccertamentiCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(344, 199);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "E = A + B - C - D";
			// 
			// btnVarPrevCompetenza
			// 
			this.btnVarPrevCompetenza.Location = new System.Drawing.Point(347, 43);
			this.btnVarPrevCompetenza.Name = "btnVarPrevCompetenza";
			this.btnVarPrevCompetenza.Size = new System.Drawing.Size(75, 20);
			this.btnVarPrevCompetenza.TabIndex = 3;
			this.btnVarPrevCompetenza.Text = "B";
			this.btnVarPrevCompetenza.UseVisualStyleBackColor = true;
			this.btnVarPrevCompetenza.Click += new System.EventHandler(this.btnVarPrevCompetenza_Click);
			// 
			// lblVarPrevCompetenza
			// 
			this.lblVarPrevCompetenza.Location = new System.Drawing.Point(16, 45);
			this.lblVarPrevCompetenza.Name = "lblVarPrevCompetenza";
			this.lblVarPrevCompetenza.Size = new System.Drawing.Size(198, 13);
			this.lblVarPrevCompetenza.TabIndex = 0;
			this.lblVarPrevCompetenza.Text = "Variazione Previsione  di Competenza";
			this.lblVarPrevCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarPrevCompetenza
			// 
			this.txtVarPrevCompetenza.Location = new System.Drawing.Point(220, 43);
			this.txtVarPrevCompetenza.Name = "txtVarPrevCompetenza";
			this.txtVarPrevCompetenza.ReadOnly = true;
			this.txtVarPrevCompetenza.Size = new System.Drawing.Size(121, 20);
			this.txtVarPrevCompetenza.TabIndex = 2;
			this.txtVarPrevCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPrevDispCompetenza
			// 
			this.lblPrevDispCompetenza.Location = new System.Drawing.Point(16, 197);
			this.lblPrevDispCompetenza.Name = "lblPrevDispCompetenza";
			this.lblPrevDispCompetenza.Size = new System.Drawing.Size(198, 13);
			this.lblPrevDispCompetenza.TabIndex = 0;
			this.lblPrevDispCompetenza.Text = "Previsione Disponibile di Competenza";
			this.lblPrevDispCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevDispCompetenza
			// 
			this.txtPrevDispCompetenza.Location = new System.Drawing.Point(220, 195);
			this.txtPrevDispCompetenza.Name = "txtPrevDispCompetenza";
			this.txtPrevDispCompetenza.ReadOnly = true;
			this.txtPrevDispCompetenza.Size = new System.Drawing.Size(121, 20);
			this.txtPrevDispCompetenza.TabIndex = 8;
			this.txtPrevDispCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnImpegniCompetenza
			// 
			this.btnImpegniCompetenza.Location = new System.Drawing.Point(347, 112);
			this.btnImpegniCompetenza.Name = "btnImpegniCompetenza";
			this.btnImpegniCompetenza.Size = new System.Drawing.Size(75, 20);
			this.btnImpegniCompetenza.TabIndex = 5;
			this.btnImpegniCompetenza.Text = "C";
			this.btnImpegniCompetenza.UseVisualStyleBackColor = true;
			this.btnImpegniCompetenza.Click += new System.EventHandler(this.btnImpegniCompetenza_Click);
			// 
			// lblImpegniCompetenza
			// 
			this.lblImpegniCompetenza.Location = new System.Drawing.Point(16, 113);
			this.lblImpegniCompetenza.Name = "lblImpegniCompetenza";
			this.lblImpegniCompetenza.Size = new System.Drawing.Size(198, 13);
			this.lblImpegniCompetenza.TabIndex = 0;
			this.lblImpegniCompetenza.Text = "Impegni di Competenza";
			this.lblImpegniCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImpegniCompetenza
			// 
			this.txtImpegniCompetenza.Location = new System.Drawing.Point(220, 111);
			this.txtImpegniCompetenza.Name = "txtImpegniCompetenza";
			this.txtImpegniCompetenza.ReadOnly = true;
			this.txtImpegniCompetenza.Size = new System.Drawing.Size(121, 20);
			this.txtImpegniCompetenza.TabIndex = 4;
			this.txtImpegniCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPrevInizialeCompetenza
			// 
			this.btnPrevInizialeCompetenza.Location = new System.Drawing.Point(347, 13);
			this.btnPrevInizialeCompetenza.Name = "btnPrevInizialeCompetenza";
			this.btnPrevInizialeCompetenza.Size = new System.Drawing.Size(75, 20);
			this.btnPrevInizialeCompetenza.TabIndex = 1;
			this.btnPrevInizialeCompetenza.Text = "A";
			this.btnPrevInizialeCompetenza.UseVisualStyleBackColor = true;
			this.btnPrevInizialeCompetenza.Click += new System.EventHandler(this.btnPrevInizialeCompetenza_Click);
			// 
			// lblPrevInizialeCompetenza
			// 
			this.lblPrevInizialeCompetenza.Location = new System.Drawing.Point(16, 16);
			this.lblPrevInizialeCompetenza.Name = "lblPrevInizialeCompetenza";
			this.lblPrevInizialeCompetenza.Size = new System.Drawing.Size(198, 13);
			this.lblPrevInizialeCompetenza.TabIndex = 0;
			this.lblPrevInizialeCompetenza.Text = "Previsione Iniziale di Competenza";
			this.lblPrevInizialeCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevInizialeCompetenza
			// 
			this.txtPrevInizialeCompetenza.Location = new System.Drawing.Point(220, 14);
			this.txtPrevInizialeCompetenza.Name = "txtPrevInizialeCompetenza";
			this.txtPrevInizialeCompetenza.ReadOnly = true;
			this.txtPrevInizialeCompetenza.Size = new System.Drawing.Size(121, 20);
			this.txtPrevInizialeCompetenza.TabIndex = 0;
			this.txtPrevInizialeCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabCassa
			// 
			this.tabCassa.Controls.Add(this.grpPrevCassa);
			this.tabCassa.Location = new System.Drawing.Point(4, 22);
			this.tabCassa.Name = "tabCassa";
			this.tabCassa.Padding = new System.Windows.Forms.Padding(3);
			this.tabCassa.Size = new System.Drawing.Size(403, 435);
			this.tabCassa.TabIndex = 1;
			this.tabCassa.Text = "Previsione di cassa";
			this.tabCassa.UseVisualStyleBackColor = true;
			// 
			// grpPrevCassa
			// 
			this.grpPrevCassa.Controls.Add(this.txtPrevDispCassaPerImpegniAccertamenti);
			this.grpPrevCassa.Controls.Add(this.label10);
			this.grpPrevCassa.Controls.Add(this.lblPrevDispCassaImpegniAccertamenti);
			this.grpPrevCassa.Controls.Add(this.btnAccertamentiAll);
			this.grpPrevCassa.Controls.Add(this.lblAccertamentiAll);
			this.grpPrevCassa.Controls.Add(this.txtAccertamentiAll);
			this.grpPrevCassa.Controls.Add(this.btnImpegniAll);
			this.grpPrevCassa.Controls.Add(this.lblImpegniAll);
			this.grpPrevCassa.Controls.Add(this.txtImpegniAll);
			this.grpPrevCassa.Controls.Add(this.label8);
			this.grpPrevCassa.Controls.Add(this.label9);
			this.grpPrevCassa.Controls.Add(this.txtPrevAttualeCassa);
			this.grpPrevCassa.Controls.Add(this.txtPrevDispCassaPerPagInc);
			this.grpPrevCassa.Controls.Add(this.btnPiccoleSpesePagamenti);
			this.grpPrevCassa.Controls.Add(this.lblPiccoleSpesePagamenti);
			this.grpPrevCassa.Controls.Add(this.txtPiccoleSpesePagamenti);
			this.grpPrevCassa.Controls.Add(this.btnIncassi);
			this.grpPrevCassa.Controls.Add(this.lblIncassi);
			this.grpPrevCassa.Controls.Add(this.txtIncassi);
			this.grpPrevCassa.Controls.Add(this.label2);
			this.grpPrevCassa.Controls.Add(this.btnVarPrevisioneCassa);
			this.grpPrevCassa.Controls.Add(this.lblVarPrevisioneCassa);
			this.grpPrevCassa.Controls.Add(this.txtVarPrevisioneCassa);
			this.grpPrevCassa.Controls.Add(this.lblPrevDispCassaPagInc);
			this.grpPrevCassa.Controls.Add(this.btnPagamenti);
			this.grpPrevCassa.Controls.Add(this.lblPagamenti);
			this.grpPrevCassa.Controls.Add(this.txtPagamenti);
			this.grpPrevCassa.Controls.Add(this.btnPrevInizialeCassa);
			this.grpPrevCassa.Controls.Add(this.lblPrevInizialeCassa);
			this.grpPrevCassa.Controls.Add(this.txtPrevInizialeCassa);
			this.grpPrevCassa.Location = new System.Drawing.Point(6, 6);
			this.grpPrevCassa.Name = "grpPrevCassa";
			this.grpPrevCassa.Size = new System.Drawing.Size(533, 374);
			this.grpPrevCassa.TabIndex = 0;
			this.grpPrevCassa.TabStop = false;
			// 
			// txtPrevDispCassaPerImpegniAccertamenti
			// 
			this.txtPrevDispCassaPerImpegniAccertamenti.Location = new System.Drawing.Point(292, 257);
			this.txtPrevDispCassaPerImpegniAccertamenti.Name = "txtPrevDispCassaPerImpegniAccertamenti";
			this.txtPrevDispCassaPerImpegniAccertamenti.ReadOnly = true;
			this.txtPrevDispCassaPerImpegniAccertamenti.Size = new System.Drawing.Size(122, 20);
			this.txtPrevDispCassaPerImpegniAccertamenti.TabIndex = 61;
			this.txtPrevDispCassaPerImpegniAccertamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(424, 261);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(83, 13);
			this.label10.TabIndex = 60;
			this.label10.Text = "L = F + G - H - L";
			// 
			// lblPrevDispCassaImpegniAccertamenti
			// 
			this.lblPrevDispCassaImpegniAccertamenti.Location = new System.Drawing.Point(6, 250);
			this.lblPrevDispCassaImpegniAccertamenti.Name = "lblPrevDispCassaImpegniAccertamenti";
			this.lblPrevDispCassaImpegniAccertamenti.Size = new System.Drawing.Size(280, 32);
			this.lblPrevDispCassaImpegniAccertamenti.TabIndex = 59;
			this.lblPrevDispCassaImpegniAccertamenti.Text = "Previsione Disponibile di Cassa per Impegni/Accertamenti";
			this.lblPrevDispCassaImpegniAccertamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnAccertamentiAll
			// 
			this.btnAccertamentiAll.Location = new System.Drawing.Point(428, 131);
			this.btnAccertamentiAll.Name = "btnAccertamentiAll";
			this.btnAccertamentiAll.Size = new System.Drawing.Size(75, 20);
			this.btnAccertamentiAll.TabIndex = 58;
			this.btnAccertamentiAll.Text = "H";
			this.btnAccertamentiAll.UseVisualStyleBackColor = true;
			this.btnAccertamentiAll.Click += new System.EventHandler(this.btnAccertamentiAll_Click);
			// 
			// lblAccertamentiAll
			// 
			this.lblAccertamentiAll.Location = new System.Drawing.Point(90, 132);
			this.lblAccertamentiAll.Name = "lblAccertamentiAll";
			this.lblAccertamentiAll.Size = new System.Drawing.Size(196, 18);
			this.lblAccertamentiAll.TabIndex = 53;
			this.lblAccertamentiAll.Text = "Accertamenti";
			this.lblAccertamentiAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAccertamentiAll
			// 
			this.txtAccertamentiAll.Location = new System.Drawing.Point(293, 130);
			this.txtAccertamentiAll.Name = "txtAccertamentiAll";
			this.txtAccertamentiAll.ReadOnly = true;
			this.txtAccertamentiAll.Size = new System.Drawing.Size(121, 20);
			this.txtAccertamentiAll.TabIndex = 57;
			this.txtAccertamentiAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnImpegniAll
			// 
			this.btnImpegniAll.Location = new System.Drawing.Point(428, 105);
			this.btnImpegniAll.Name = "btnImpegniAll";
			this.btnImpegniAll.Size = new System.Drawing.Size(75, 20);
			this.btnImpegniAll.TabIndex = 56;
			this.btnImpegniAll.Text = "H";
			this.btnImpegniAll.UseVisualStyleBackColor = true;
			this.btnImpegniAll.Click += new System.EventHandler(this.btnImpegniAll_Click);
			// 
			// lblImpegniAll
			// 
			this.lblImpegniAll.Location = new System.Drawing.Point(70, 106);
			this.lblImpegniAll.Name = "lblImpegniAll";
			this.lblImpegniAll.Size = new System.Drawing.Size(216, 18);
			this.lblImpegniAll.TabIndex = 54;
			this.lblImpegniAll.Text = "Impegni";
			this.lblImpegniAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImpegniAll
			// 
			this.txtImpegniAll.Location = new System.Drawing.Point(293, 104);
			this.txtImpegniAll.Name = "txtImpegniAll";
			this.txtImpegniAll.ReadOnly = true;
			this.txtImpegniAll.Size = new System.Drawing.Size(121, 20);
			this.txtImpegniAll.TabIndex = 55;
			this.txtImpegniAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(434, 68);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "= F + G";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(32, 68);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(247, 13);
			this.label9.TabIndex = 18;
			this.label9.Text = "Previsione  attuale di Cassa";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevAttualeCassa
			// 
			this.txtPrevAttualeCassa.Location = new System.Drawing.Point(292, 65);
			this.txtPrevAttualeCassa.Name = "txtPrevAttualeCassa";
			this.txtPrevAttualeCassa.ReadOnly = true;
			this.txtPrevAttualeCassa.Size = new System.Drawing.Size(122, 20);
			this.txtPrevAttualeCassa.TabIndex = 19;
			this.txtPrevAttualeCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtPrevDispCassaPerPagInc
			// 
			this.txtPrevDispCassaPerPagInc.Location = new System.Drawing.Point(293, 299);
			this.txtPrevDispCassaPerPagInc.Name = "txtPrevDispCassaPerPagInc";
			this.txtPrevDispCassaPerPagInc.ReadOnly = true;
			this.txtPrevDispCassaPerPagInc.Size = new System.Drawing.Size(122, 20);
			this.txtPrevDispCassaPerPagInc.TabIndex = 17;
			this.txtPrevDispCassaPerPagInc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPiccoleSpesePagamenti
			// 
			this.btnPiccoleSpesePagamenti.Location = new System.Drawing.Point(428, 218);
			this.btnPiccoleSpesePagamenti.Name = "btnPiccoleSpesePagamenti";
			this.btnPiccoleSpesePagamenti.Size = new System.Drawing.Size(75, 20);
			this.btnPiccoleSpesePagamenti.TabIndex = 15;
			this.btnPiccoleSpesePagamenti.Text = " L";
			this.btnPiccoleSpesePagamenti.UseVisualStyleBackColor = true;
			this.btnPiccoleSpesePagamenti.Click += new System.EventHandler(this.btnPiccoleSpesePag_Click);
			// 
			// lblPiccoleSpesePagamenti
			// 
			this.lblPiccoleSpesePagamenti.Location = new System.Drawing.Point(36, 220);
			this.lblPiccoleSpesePagamenti.Name = "lblPiccoleSpesePagamenti";
			this.lblPiccoleSpesePagamenti.Size = new System.Drawing.Size(243, 13);
			this.lblPiccoleSpesePagamenti.TabIndex = 13;
			this.lblPiccoleSpesePagamenti.Text = "Piccole spese non reintegrate";
			this.lblPiccoleSpesePagamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPiccoleSpesePagamenti
			// 
			this.txtPiccoleSpesePagamenti.Location = new System.Drawing.Point(293, 217);
			this.txtPiccoleSpesePagamenti.Name = "txtPiccoleSpesePagamenti";
			this.txtPiccoleSpesePagamenti.ReadOnly = true;
			this.txtPiccoleSpesePagamenti.Size = new System.Drawing.Size(121, 20);
			this.txtPiccoleSpesePagamenti.TabIndex = 14;
			this.txtPiccoleSpesePagamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnIncassi
			// 
			this.btnIncassi.Location = new System.Drawing.Point(428, 191);
			this.btnIncassi.Name = "btnIncassi";
			this.btnIncassi.Size = new System.Drawing.Size(75, 20);
			this.btnIncassi.TabIndex = 7;
			this.btnIncassi.Text = "I";
			this.btnIncassi.UseVisualStyleBackColor = true;
			this.btnIncassi.Click += new System.EventHandler(this.btnIncassi_Click);
			// 
			// lblIncassi
			// 
			this.lblIncassi.Location = new System.Drawing.Point(38, 193);
			this.lblIncassi.Name = "lblIncassi";
			this.lblIncassi.Size = new System.Drawing.Size(243, 13);
			this.lblIncassi.TabIndex = 0;
			this.lblIncassi.Text = "Incassi";
			this.lblIncassi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIncassi
			// 
			this.txtIncassi.Location = new System.Drawing.Point(293, 190);
			this.txtIncassi.Name = "txtIncassi";
			this.txtIncassi.ReadOnly = true;
			this.txtIncassi.Size = new System.Drawing.Size(121, 20);
			this.txtIncassi.TabIndex = 6;
			this.txtIncassi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(425, 303);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "L = F + G - I - L";
			// 
			// btnVarPrevisioneCassa
			// 
			this.btnVarPrevisioneCassa.Location = new System.Drawing.Point(428, 35);
			this.btnVarPrevisioneCassa.Name = "btnVarPrevisioneCassa";
			this.btnVarPrevisioneCassa.Size = new System.Drawing.Size(75, 20);
			this.btnVarPrevisioneCassa.TabIndex = 3;
			this.btnVarPrevisioneCassa.Text = "G";
			this.btnVarPrevisioneCassa.UseVisualStyleBackColor = true;
			this.btnVarPrevisioneCassa.Click += new System.EventHandler(this.btnVarPrevisioneCassa_Click);
			// 
			// lblVarPrevisioneCassa
			// 
			this.lblVarPrevisioneCassa.Location = new System.Drawing.Point(36, 37);
			this.lblVarPrevisioneCassa.Name = "lblVarPrevisioneCassa";
			this.lblVarPrevisioneCassa.Size = new System.Drawing.Size(243, 13);
			this.lblVarPrevisioneCassa.TabIndex = 0;
			this.lblVarPrevisioneCassa.Text = "Variazione Previsione  di Cassa";
			this.lblVarPrevisioneCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarPrevisioneCassa
			// 
			this.txtVarPrevisioneCassa.Location = new System.Drawing.Point(293, 34);
			this.txtVarPrevisioneCassa.Name = "txtVarPrevisioneCassa";
			this.txtVarPrevisioneCassa.ReadOnly = true;
			this.txtVarPrevisioneCassa.Size = new System.Drawing.Size(121, 20);
			this.txtVarPrevisioneCassa.TabIndex = 2;
			this.txtVarPrevisioneCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPrevDispCassaPagInc
			// 
			this.lblPrevDispCassaPagInc.Location = new System.Drawing.Point(6, 290);
			this.lblPrevDispCassaPagInc.Name = "lblPrevDispCassaPagInc";
			this.lblPrevDispCassaPagInc.Size = new System.Drawing.Size(280, 32);
			this.lblPrevDispCassaPagInc.TabIndex = 0;
			this.lblPrevDispCassaPagInc.Text = "Previsione Disponibile di Cassa per Pagamenti/Incassi";
			this.lblPrevDispCassaPagInc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnPagamenti
			// 
			this.btnPagamenti.Location = new System.Drawing.Point(428, 166);
			this.btnPagamenti.Name = "btnPagamenti";
			this.btnPagamenti.Size = new System.Drawing.Size(75, 20);
			this.btnPagamenti.TabIndex = 5;
			this.btnPagamenti.Text = "I";
			this.btnPagamenti.UseVisualStyleBackColor = true;
			this.btnPagamenti.Click += new System.EventHandler(this.btnPagamenti_Click);
			// 
			// lblPagamenti
			// 
			this.lblPagamenti.Location = new System.Drawing.Point(38, 168);
			this.lblPagamenti.Name = "lblPagamenti";
			this.lblPagamenti.Size = new System.Drawing.Size(243, 13);
			this.lblPagamenti.TabIndex = 0;
			this.lblPagamenti.Text = "Pagamenti";
			this.lblPagamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPagamenti
			// 
			this.txtPagamenti.Location = new System.Drawing.Point(293, 164);
			this.txtPagamenti.Name = "txtPagamenti";
			this.txtPagamenti.ReadOnly = true;
			this.txtPagamenti.Size = new System.Drawing.Size(121, 20);
			this.txtPagamenti.TabIndex = 4;
			this.txtPagamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPrevInizialeCassa
			// 
			this.btnPrevInizialeCassa.Location = new System.Drawing.Point(428, 9);
			this.btnPrevInizialeCassa.Name = "btnPrevInizialeCassa";
			this.btnPrevInizialeCassa.Size = new System.Drawing.Size(75, 20);
			this.btnPrevInizialeCassa.TabIndex = 1;
			this.btnPrevInizialeCassa.Text = "F";
			this.btnPrevInizialeCassa.UseVisualStyleBackColor = true;
			this.btnPrevInizialeCassa.Click += new System.EventHandler(this.btnPrevInizialeCassa_Click);
			// 
			// lblPrevInizialeCassa
			// 
			this.lblPrevInizialeCassa.Location = new System.Drawing.Point(36, 11);
			this.lblPrevInizialeCassa.Name = "lblPrevInizialeCassa";
			this.lblPrevInizialeCassa.Size = new System.Drawing.Size(243, 13);
			this.lblPrevInizialeCassa.TabIndex = 0;
			this.lblPrevInizialeCassa.Text = "Previsione Iniziale di Cassa";
			this.lblPrevInizialeCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevInizialeCassa
			// 
			this.txtPrevInizialeCassa.Location = new System.Drawing.Point(293, 8);
			this.txtPrevInizialeCassa.Name = "txtPrevInizialeCassa";
			this.txtPrevInizialeCassa.ReadOnly = true;
			this.txtPrevInizialeCassa.Size = new System.Drawing.Size(121, 20);
			this.txtPrevInizialeCassa.TabIndex = 0;
			this.txtPrevInizialeCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabCrediti
			// 
			this.tabCrediti.Controls.Add(this.grpCrediti);
			this.tabCrediti.Location = new System.Drawing.Point(4, 22);
			this.tabCrediti.Name = "tabCrediti";
			this.tabCrediti.Size = new System.Drawing.Size(581, 435);
			this.tabCrediti.TabIndex = 2;
			this.tabCrediti.Text = "Assegnazione crediti";
			this.tabCrediti.UseVisualStyleBackColor = true;
			// 
			// grpCrediti
			// 
			this.grpCrediti.Controls.Add(this.label11);
			this.grpCrediti.Controls.Add(this.labelTotaleCrediti);
			this.grpCrediti.Controls.Add(this.txtTotaleCrediti);
			this.grpCrediti.Controls.Add(this.btnVarDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.txtVarDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.lblVarDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.label3);
			this.grpCrediti.Controls.Add(this.btnDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.lblDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.txtDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.lblCreditiResidui);
			this.grpCrediti.Controls.Add(this.txtCreditiResidui);
			this.grpCrediti.Controls.Add(this.btnCreditiAssegnati);
			this.grpCrediti.Controls.Add(this.lblCreditiAssegnati);
			this.grpCrediti.Controls.Add(this.txtCreditiAssegnati);
			this.grpCrediti.Location = new System.Drawing.Point(11, 3);
			this.grpCrediti.Name = "grpCrediti";
			this.grpCrediti.Size = new System.Drawing.Size(480, 203);
			this.grpCrediti.TabIndex = 0;
			this.grpCrediti.TabStop = false;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(349, 109);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(65, 13);
			this.label11.TabIndex = 21;
			this.label11.Text = "= M + N + O";
			// 
			// labelTotaleCrediti
			// 
			this.labelTotaleCrediti.Location = new System.Drawing.Point(19, 105);
			this.labelTotaleCrediti.Name = "labelTotaleCrediti";
			this.labelTotaleCrediti.Size = new System.Drawing.Size(148, 13);
			this.labelTotaleCrediti.TabIndex = 9;
			this.labelTotaleCrediti.Text = "Totale Crediti";
			this.labelTotaleCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotaleCrediti
			// 
			this.txtTotaleCrediti.Location = new System.Drawing.Point(188, 102);
			this.txtTotaleCrediti.Name = "txtTotaleCrediti";
			this.txtTotaleCrediti.ReadOnly = true;
			this.txtTotaleCrediti.Size = new System.Drawing.Size(149, 20);
			this.txtTotaleCrediti.TabIndex = 10;
			this.txtTotaleCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnVarDotazioneCrediti
			// 
			this.btnVarDotazioneCrediti.Location = new System.Drawing.Point(349, 42);
			this.btnVarDotazioneCrediti.Name = "btnVarDotazioneCrediti";
			this.btnVarDotazioneCrediti.Size = new System.Drawing.Size(78, 20);
			this.btnVarDotazioneCrediti.TabIndex = 8;
			this.btnVarDotazioneCrediti.Text = "N";
			this.btnVarDotazioneCrediti.UseVisualStyleBackColor = true;
			this.btnVarDotazioneCrediti.Click += new System.EventHandler(this.btnVarDotazioneCrediti_Click);
			// 
			// txtVarDotazioneCrediti
			// 
			this.txtVarDotazioneCrediti.Location = new System.Drawing.Point(188, 42);
			this.txtVarDotazioneCrediti.Name = "txtVarDotazioneCrediti";
			this.txtVarDotazioneCrediti.ReadOnly = true;
			this.txtVarDotazioneCrediti.Size = new System.Drawing.Size(149, 20);
			this.txtVarDotazioneCrediti.TabIndex = 7;
			this.txtVarDotazioneCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblVarDotazioneCrediti
			// 
			this.lblVarDotazioneCrediti.Location = new System.Drawing.Point(19, 45);
			this.lblVarDotazioneCrediti.Name = "lblVarDotazioneCrediti";
			this.lblVarDotazioneCrediti.Size = new System.Drawing.Size(148, 13);
			this.lblVarDotazioneCrediti.TabIndex = 6;
			this.lblVarDotazioneCrediti.Text = "Var. Dotazione Crediti";
			this.lblVarDotazioneCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(349, 147);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "P = M + N + O - C - D";
			// 
			// btnDotazioneCrediti
			// 
			this.btnDotazioneCrediti.Location = new System.Drawing.Point(349, 13);
			this.btnDotazioneCrediti.Name = "btnDotazioneCrediti";
			this.btnDotazioneCrediti.Size = new System.Drawing.Size(78, 20);
			this.btnDotazioneCrediti.TabIndex = 1;
			this.btnDotazioneCrediti.Text = "M";
			this.btnDotazioneCrediti.UseVisualStyleBackColor = true;
			this.btnDotazioneCrediti.Click += new System.EventHandler(this.btnDotazioneCrediti_Click);
			// 
			// lblDotazioneCrediti
			// 
			this.lblDotazioneCrediti.Location = new System.Drawing.Point(19, 16);
			this.lblDotazioneCrediti.Name = "lblDotazioneCrediti";
			this.lblDotazioneCrediti.Size = new System.Drawing.Size(148, 13);
			this.lblDotazioneCrediti.TabIndex = 0;
			this.lblDotazioneCrediti.Text = "Dotazione Iniziale Crediti";
			this.lblDotazioneCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDotazioneCrediti
			// 
			this.txtDotazioneCrediti.Location = new System.Drawing.Point(188, 13);
			this.txtDotazioneCrediti.Name = "txtDotazioneCrediti";
			this.txtDotazioneCrediti.ReadOnly = true;
			this.txtDotazioneCrediti.Size = new System.Drawing.Size(149, 20);
			this.txtDotazioneCrediti.TabIndex = 0;
			this.txtDotazioneCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblCreditiResidui
			// 
			this.lblCreditiResidui.Location = new System.Drawing.Point(19, 146);
			this.lblCreditiResidui.Name = "lblCreditiResidui";
			this.lblCreditiResidui.Size = new System.Drawing.Size(148, 13);
			this.lblCreditiResidui.TabIndex = 0;
			this.lblCreditiResidui.Text = "Crediti Residui";
			this.lblCreditiResidui.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCreditiResidui
			// 
			this.txtCreditiResidui.Location = new System.Drawing.Point(188, 143);
			this.txtCreditiResidui.Name = "txtCreditiResidui";
			this.txtCreditiResidui.ReadOnly = true;
			this.txtCreditiResidui.Size = new System.Drawing.Size(149, 20);
			this.txtCreditiResidui.TabIndex = 4;
			this.txtCreditiResidui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnCreditiAssegnati
			// 
			this.btnCreditiAssegnati.Location = new System.Drawing.Point(349, 70);
			this.btnCreditiAssegnati.Name = "btnCreditiAssegnati";
			this.btnCreditiAssegnati.Size = new System.Drawing.Size(78, 20);
			this.btnCreditiAssegnati.TabIndex = 3;
			this.btnCreditiAssegnati.Text = "O";
			this.btnCreditiAssegnati.UseVisualStyleBackColor = true;
			this.btnCreditiAssegnati.Click += new System.EventHandler(this.btnCreditiAssegnati_Click);
			// 
			// lblCreditiAssegnati
			// 
			this.lblCreditiAssegnati.Location = new System.Drawing.Point(19, 72);
			this.lblCreditiAssegnati.Name = "lblCreditiAssegnati";
			this.lblCreditiAssegnati.Size = new System.Drawing.Size(148, 13);
			this.lblCreditiAssegnati.TabIndex = 0;
			this.lblCreditiAssegnati.Text = "Totale Assegnazioni di Crediti";
			this.lblCreditiAssegnati.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCreditiAssegnati
			// 
			this.txtCreditiAssegnati.Location = new System.Drawing.Point(188, 69);
			this.txtCreditiAssegnati.Name = "txtCreditiAssegnati";
			this.txtCreditiAssegnati.ReadOnly = true;
			this.txtCreditiAssegnati.Size = new System.Drawing.Size(149, 20);
			this.txtCreditiAssegnati.TabIndex = 2;
			this.txtCreditiAssegnati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabAssCassa
			// 
			this.tabAssCassa.Controls.Add(this.grpCassa);
			this.tabAssCassa.Location = new System.Drawing.Point(4, 22);
			this.tabAssCassa.Name = "tabAssCassa";
			this.tabAssCassa.Size = new System.Drawing.Size(581, 435);
			this.tabAssCassa.TabIndex = 3;
			this.tabAssCassa.Text = "Assegnazioni di cassa";
			this.tabAssCassa.UseVisualStyleBackColor = true;
			// 
			// grpCassa
			// 
			this.grpCassa.Controls.Add(this.label12);
			this.grpCassa.Controls.Add(this.labelTotaleCassa);
			this.grpCassa.Controls.Add(this.txtTotaleCassa);
			this.grpCassa.Controls.Add(this.btnPiccoleSpesePagamenti1);
			this.grpCassa.Controls.Add(this.lblPiccoleSpesePagamenti1);
			this.grpCassa.Controls.Add(this.txtPiccoleSpesePagamenti1);
			this.grpCassa.Controls.Add(this.btnPagamenti1);
			this.grpCassa.Controls.Add(this.lblPagamenti1);
			this.grpCassa.Controls.Add(this.txtPagamenti1);
			this.grpCassa.Controls.Add(this.btnVarDotazioneCassa);
			this.grpCassa.Controls.Add(this.txtVarDotazioneCassa);
			this.grpCassa.Controls.Add(this.lblVarDotazioneCassa);
			this.grpCassa.Controls.Add(this.label4);
			this.grpCassa.Controls.Add(this.btnDotazioneCassa);
			this.grpCassa.Controls.Add(this.lblDotazioneCassa);
			this.grpCassa.Controls.Add(this.txtDotazioneCassa);
			this.grpCassa.Controls.Add(this.lblCassaResidua);
			this.grpCassa.Controls.Add(this.txtCassaResidua);
			this.grpCassa.Controls.Add(this.btnAssegnazioniCassa);
			this.grpCassa.Controls.Add(this.lblAssegnazioniCassa);
			this.grpCassa.Controls.Add(this.txtAssegnazioniCassa);
			this.grpCassa.Location = new System.Drawing.Point(3, 3);
			this.grpCassa.Name = "grpCassa";
			this.grpCassa.Size = new System.Drawing.Size(488, 252);
			this.grpCassa.TabIndex = 3;
			this.grpCassa.TabStop = false;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(365, 105);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(63, 13);
			this.label12.TabIndex = 24;
			this.label12.Text = "= Q + R + S";
			// 
			// labelTotaleCassa
			// 
			this.labelTotaleCassa.Location = new System.Drawing.Point(50, 101);
			this.labelTotaleCassa.Name = "labelTotaleCassa";
			this.labelTotaleCassa.Size = new System.Drawing.Size(148, 13);
			this.labelTotaleCassa.TabIndex = 22;
			this.labelTotaleCassa.Text = "Totale Cassa";
			this.labelTotaleCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotaleCassa
			// 
			this.txtTotaleCassa.Location = new System.Drawing.Point(204, 98);
			this.txtTotaleCassa.Name = "txtTotaleCassa";
			this.txtTotaleCassa.ReadOnly = true;
			this.txtTotaleCassa.Size = new System.Drawing.Size(149, 20);
			this.txtTotaleCassa.TabIndex = 23;
			this.txtTotaleCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPiccoleSpesePagamenti1
			// 
			this.btnPiccoleSpesePagamenti1.Location = new System.Drawing.Point(359, 168);
			this.btnPiccoleSpesePagamenti1.Name = "btnPiccoleSpesePagamenti1";
			this.btnPiccoleSpesePagamenti1.Size = new System.Drawing.Size(75, 20);
			this.btnPiccoleSpesePagamenti1.TabIndex = 18;
			this.btnPiccoleSpesePagamenti1.Text = "U";
			this.btnPiccoleSpesePagamenti1.UseVisualStyleBackColor = true;
			this.btnPiccoleSpesePagamenti1.Click += new System.EventHandler(this.btnPiccoleSpesePagIncassi_Click);
			// 
			// lblPiccoleSpesePagamenti1
			// 
			this.lblPiccoleSpesePagamenti1.Location = new System.Drawing.Point(6, 164);
			this.lblPiccoleSpesePagamenti1.Name = "lblPiccoleSpesePagamenti1";
			this.lblPiccoleSpesePagamenti1.Size = new System.Drawing.Size(192, 13);
			this.lblPiccoleSpesePagamenti1.TabIndex = 16;
			this.lblPiccoleSpesePagamenti1.Text = "Piccole spese non reintegrate";
			this.lblPiccoleSpesePagamenti1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPiccoleSpesePagamenti1
			// 
			this.txtPiccoleSpesePagamenti1.Location = new System.Drawing.Point(204, 168);
			this.txtPiccoleSpesePagamenti1.Name = "txtPiccoleSpesePagamenti1";
			this.txtPiccoleSpesePagamenti1.ReadOnly = true;
			this.txtPiccoleSpesePagamenti1.Size = new System.Drawing.Size(149, 20);
			this.txtPiccoleSpesePagamenti1.TabIndex = 17;
			this.txtPiccoleSpesePagamenti1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPagamenti1
			// 
			this.btnPagamenti1.Location = new System.Drawing.Point(359, 138);
			this.btnPagamenti1.Name = "btnPagamenti1";
			this.btnPagamenti1.Size = new System.Drawing.Size(75, 20);
			this.btnPagamenti1.TabIndex = 12;
			this.btnPagamenti1.Text = "T";
			this.btnPagamenti1.UseVisualStyleBackColor = true;
			this.btnPagamenti1.Click += new System.EventHandler(this.btnPagamenti_Click);
			// 
			// lblPagamenti1
			// 
			this.lblPagamenti1.Location = new System.Drawing.Point(6, 138);
			this.lblPagamenti1.Name = "lblPagamenti1";
			this.lblPagamenti1.Size = new System.Drawing.Size(192, 13);
			this.lblPagamenti1.TabIndex = 10;
			this.lblPagamenti1.Text = "Pagamenti";
			this.lblPagamenti1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPagamenti1
			// 
			this.txtPagamenti1.Location = new System.Drawing.Point(204, 138);
			this.txtPagamenti1.Name = "txtPagamenti1";
			this.txtPagamenti1.ReadOnly = true;
			this.txtPagamenti1.Size = new System.Drawing.Size(149, 20);
			this.txtPagamenti1.TabIndex = 11;
			this.txtPagamenti1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnVarDotazioneCassa
			// 
			this.btnVarDotazioneCassa.Location = new System.Drawing.Point(359, 38);
			this.btnVarDotazioneCassa.Name = "btnVarDotazioneCassa";
			this.btnVarDotazioneCassa.Size = new System.Drawing.Size(75, 20);
			this.btnVarDotazioneCassa.TabIndex = 9;
			this.btnVarDotazioneCassa.Text = "R";
			this.btnVarDotazioneCassa.UseVisualStyleBackColor = true;
			this.btnVarDotazioneCassa.Click += new System.EventHandler(this.btnVarDotazioneCassa_Click);
			// 
			// txtVarDotazioneCassa
			// 
			this.txtVarDotazioneCassa.Location = new System.Drawing.Point(204, 37);
			this.txtVarDotazioneCassa.Name = "txtVarDotazioneCassa";
			this.txtVarDotazioneCassa.ReadOnly = true;
			this.txtVarDotazioneCassa.Size = new System.Drawing.Size(149, 20);
			this.txtVarDotazioneCassa.TabIndex = 8;
			this.txtVarDotazioneCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblVarDotazioneCassa
			// 
			this.lblVarDotazioneCassa.Location = new System.Drawing.Point(6, 40);
			this.lblVarDotazioneCassa.Name = "lblVarDotazioneCassa";
			this.lblVarDotazioneCassa.Size = new System.Drawing.Size(192, 13);
			this.lblVarDotazioneCassa.TabIndex = 7;
			this.lblVarDotazioneCassa.Text = "Var. Dotazione Cassa";
			this.lblVarDotazioneCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(356, 202);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(106, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "V = Q + R + S - T - U";
			// 
			// btnDotazioneCassa
			// 
			this.btnDotazioneCassa.Location = new System.Drawing.Point(359, 13);
			this.btnDotazioneCassa.Name = "btnDotazioneCassa";
			this.btnDotazioneCassa.Size = new System.Drawing.Size(75, 20);
			this.btnDotazioneCassa.TabIndex = 1;
			this.btnDotazioneCassa.Text = "Q";
			this.btnDotazioneCassa.UseVisualStyleBackColor = true;
			this.btnDotazioneCassa.Click += new System.EventHandler(this.btnDotazioneCassa_Click);
			// 
			// lblDotazioneCassa
			// 
			this.lblDotazioneCassa.Location = new System.Drawing.Point(6, 16);
			this.lblDotazioneCassa.Name = "lblDotazioneCassa";
			this.lblDotazioneCassa.Size = new System.Drawing.Size(192, 13);
			this.lblDotazioneCassa.TabIndex = 0;
			this.lblDotazioneCassa.Text = "Dotazione Iniziale Cassa";
			this.lblDotazioneCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDotazioneCassa
			// 
			this.txtDotazioneCassa.Location = new System.Drawing.Point(204, 13);
			this.txtDotazioneCassa.Name = "txtDotazioneCassa";
			this.txtDotazioneCassa.ReadOnly = true;
			this.txtDotazioneCassa.Size = new System.Drawing.Size(149, 20);
			this.txtDotazioneCassa.TabIndex = 0;
			this.txtDotazioneCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblCassaResidua
			// 
			this.lblCassaResidua.Location = new System.Drawing.Point(6, 197);
			this.lblCassaResidua.Name = "lblCassaResidua";
			this.lblCassaResidua.Size = new System.Drawing.Size(192, 13);
			this.lblCassaResidua.TabIndex = 0;
			this.lblCassaResidua.Text = "Assegnazioni di Cassa Residue";
			this.lblCassaResidua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCassaResidua
			// 
			this.txtCassaResidua.Location = new System.Drawing.Point(204, 195);
			this.txtCassaResidua.Name = "txtCassaResidua";
			this.txtCassaResidua.ReadOnly = true;
			this.txtCassaResidua.Size = new System.Drawing.Size(149, 20);
			this.txtCassaResidua.TabIndex = 4;
			this.txtCassaResidua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnAssegnazioniCassa
			// 
			this.btnAssegnazioniCassa.Location = new System.Drawing.Point(359, 64);
			this.btnAssegnazioniCassa.Name = "btnAssegnazioniCassa";
			this.btnAssegnazioniCassa.Size = new System.Drawing.Size(75, 20);
			this.btnAssegnazioniCassa.TabIndex = 3;
			this.btnAssegnazioniCassa.Text = "S";
			this.btnAssegnazioniCassa.UseVisualStyleBackColor = true;
			this.btnAssegnazioniCassa.Click += new System.EventHandler(this.btnAssegnazioniCassa_Click);
			// 
			// lblAssegnazioniCassa
			// 
			this.lblAssegnazioniCassa.Location = new System.Drawing.Point(6, 66);
			this.lblAssegnazioniCassa.Name = "lblAssegnazioniCassa";
			this.lblAssegnazioniCassa.Size = new System.Drawing.Size(192, 13);
			this.lblAssegnazioniCassa.TabIndex = 0;
			this.lblAssegnazioniCassa.Text = "Totale Assegnazioni di Cassa";
			this.lblAssegnazioniCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAssegnazioniCassa
			// 
			this.txtAssegnazioniCassa.Location = new System.Drawing.Point(204, 63);
			this.txtAssegnazioniCassa.Name = "txtAssegnazioniCassa";
			this.txtAssegnazioniCassa.ReadOnly = true;
			this.txtAssegnazioniCassa.Size = new System.Drawing.Size(149, 20);
			this.txtAssegnazioniCassa.TabIndex = 2;
			this.txtAssegnazioniCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnCalcolaTotali
			// 
			this.btnCalcolaTotali.Location = new System.Drawing.Point(12, 6);
			this.btnCalcolaTotali.Name = "btnCalcolaTotali";
			this.btnCalcolaTotali.Size = new System.Drawing.Size(105, 25);
			this.btnCalcolaTotali.TabIndex = 1;
			this.btnCalcolaTotali.Text = "Calcola totali";
			this.btnCalcolaTotali.UseVisualStyleBackColor = true;
			this.btnCalcolaTotali.Click += new System.EventHandler(this.btnCalcolaTotali_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.HideSelection = false;
			this.treeView1.ImageIndex = 1;
			this.treeView1.ImageList = this.icons;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.ShowPlusMinus = false;
			this.treeView1.Size = new System.Drawing.Size(331, 547);
			this.treeView1.TabIndex = 2;
			this.treeView1.Tag = "fin.treeES";
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// icons
			// 
			this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
			this.icons.TransparentColor = System.Drawing.Color.Transparent;
			this.icons.Images.SetKeyName(0, "");
			this.icons.Images.SetKeyName(1, "");
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(331, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(1, 547);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// Frm_fin_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(924, 547);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.treeView1);
			this.Name = "Frm_fin_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.MetaDataDetail.ResumeLayout(false);
			this.tabGeneralita.ResumeLayout(false);
			this.tabGeneralita.PerformLayout();
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.GrpboxPrevisione.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.gboxPrimaPrevisione.ResumeLayout(false);
			this.gboxPrimaPrevisione.PerformLayout();
			this.gboxSecondaPrevisione.ResumeLayout(false);
			this.gboxSecondaPrevisione.PerformLayout();
			this.gboxRipartizione.ResumeLayout(false);
			this.gboxRipartizione.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.grpParte.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabPrevisione.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgPrevisione)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgVariazioni)).EndInit();
			this.tabClassSupp.ResumeLayout(false);
			this.gBoxCausalePartiteGiro.ResumeLayout(false);
			this.gBoxCausalePartiteGiro.PerformLayout();
			this.gboxConto.ResumeLayout(false);
			this.gboxConto.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).EndInit();
			this.TabClassAutoSpese.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridFilterClassExp)).EndInit();
			this.groupBox7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridClassAutoExp)).EndInit();
			this.TabClassAutoEntrate.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridFilterClassInc)).EndInit();
			this.groupBox9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridClassAutoInc)).EndInit();
			this.tabRiepilogo.ResumeLayout(false);
			this.tabControlRiepilogo.ResumeLayout(false);
			this.tabCompetenza.ResumeLayout(false);
			this.grpPrevCompetenza.ResumeLayout(false);
			this.grpPrevCompetenza.PerformLayout();
			this.tabCassa.ResumeLayout(false);
			this.grpPrevCassa.ResumeLayout(false);
			this.grpPrevCassa.PerformLayout();
			this.tabCrediti.ResumeLayout(false);
			this.grpCrediti.ResumeLayout(false);
			this.grpCrediti.PerformLayout();
			this.tabAssCassa.ResumeLayout(false);
			this.grpCassa.ResumeLayout(false);
			this.grpCassa.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		
		void AfterLinkBody(){
			Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            pagamento =  Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", Conn.GetSys("maxexpensephase")), "description");
            impegno = Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", Conn.GetSys("appropriationphase")), "description");

            incasso = Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", Conn.GetSys("maxincomephase")), "description");
            accertamento = Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", Conn.GetSys("assessmentphase")), "description");

            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.fin, filteresercizio);

            CalcFin= new CalcoliFinanziario(Meta, this);

            //object nUpb = Meta.Conn.DO_READ_VALUE("upb", null, "count(*)");
            upbUnico = false; //(nUpb == DBNull.Value) || ((int)nUpb == 1);


            //			string filtraSuUpbLibero = filteresercizio + " AND (idupb = '0001')";

            GetData.SetStaticFilter(DS.finview, QHS.AppAnd(filteresercizio, QHS.CmpEq("idupb", "0001")));
			GetData.SetStaticFilter(DS.finunified,filteresercizio);
            string FilterFinyearview="";
            if (!upbUnico) FilterFinyearview=
                 "(isnull(prevision,0) <>0 or isnull(secondaryprev,0)<>0 or isnull(previousprevision,0)<>0 "+
                    " or isnull(previoussecondaryprev,0)<>0 )  ";
            FilterFinyearview = QHS.AppAnd(FilterFinyearview, filteresercizio);
            GetData.SetStaticFilter(DS.finyearview, FilterFinyearview);
            GetData.SetStaticFilter(DS.finvardetailview, QHS.CmpEq("yvar", Meta.GetSys("esercizio"))); 
            GetData.SetSorting(DS.fin, "printingorder");
            GetData.SetSorting(DS.finvardetailview, "nvar,rownum");
//			GetData.SetSorting(DS.finview,"printingorder");
			GetData.CacheTable(DS.finlevel,filteresercizio,null,true);		
			GetData.CacheTable(DS.config,filteresercizio,null,false);
            GetData.SetStaticFilter(DS.sortingview, filteresercizio);
			SP_Called=false;
			cambiaEtichetteEsercizi();
            //impostaTagTxtPrevisione(); //questo metodo consentiva di scrivere le prev. sul TabPage principale se l'upb è unico

            // I text della previsione devono essere sempre NON editabili
			//txtPrevisioneInSolaLettura(!upbUnico);
            txtPrevisioneInSolaLettura(true);
			btnSuddivisioni.Enabled = false;

            AbilitaBtnPrevisione(false);
            CalcolaEtichette();
            
		}

        void CalcolaEtichette() {            

            if (pagamento != null) {
                lblPagamenti.Text = "Tot. fase " + pagamento.ToString().ToLower();
                lblPagamenti1.Text = "Tot. fase " + pagamento.ToString().ToLower();
                //lblPrevDispCassaPagInc.Text = "Previsione Disponibile di cassa su " + pagamento.ToString().ToLower();
            }
            else {
                show("Non è stata definita la fase di pagamento (ultima fase di spesa)", "Avviso");
            }
            if (incasso != null) {
                lblIncassi.Text = "Tot. fase " + incasso.ToString().ToLower();
                //lblPrevDispCassaPagInc.Text = "Previsione Disponibile di cassa su " + incasso.ToString().ToLower();
            }
            else {
                show("Non è stata definita la fase di incasso (ultima fase di entrata)", "Avviso");
            }

            if (impegno != null) {
                lblImpegniCompetenza.Text = "Tot. fase " + impegno.ToString().ToLower() + " competenza";
                lblImpegniAll.Text = "Tot. fase " + impegno.ToString().ToLower() ;
                //lblPrevDispCassaImpegniAccertamenti.Text = "Previsione Disponibile di cassa su " + impegno.ToString().ToLower();
            }
            else {
                show("Non è stata definita la fase di impegno (prima fase di spesa)", "Avviso");
            }

            
            if (accertamento != null) {
                lblAccertamentiCompetenza.Text = "Tot. fase " + accertamento.ToString().ToLower() + " competenza";
                lblAccertamentiAll.Text = "Tot. fase " + accertamento.ToString().ToLower();
                //lblPrevDispCassaImpegniAccertamenti.Text = "Previsione Disponibile di cassa su " + accertamento.ToString().ToLower();
            }
            else {
                show("Non è stata definita la fase di accertamento (prima fase di entrata)", "Avviso");
            }

        }

		/// <summary>
		/// TRUE: Imposta i text box della previsione in sola lettura; FALSE: Consente di modificarli
		/// </summary>
		/// <param name="solaLettura"></param>
		private void txtPrevisioneInSolaLettura(bool solaLettura) {
			SubEntity_txtpreveserciziocorr.ReadOnly = solaLettura;
			SubEntity_txtprevesercizioprec.ReadOnly = solaLettura;
			SubEntity_txtprevseceserciziocorr.ReadOnly = solaLettura;
			SubEntity_txtprevsecesercizioprec.ReadOnly = solaLettura;
			SubEntity_txtripartizionecorr.ReadOnly = solaLettura;
			SubEntity_txtripartizioneprec.ReadOnly = solaLettura;
			SubEntity_txtprevision2.ReadOnly = solaLettura;
			SubEntity_txtprevision3.ReadOnly = solaLettura;
			SubEntity_txtprevision4.ReadOnly = solaLettura;
			SubEntity_txtprevision5.ReadOnly = solaLettura;
		}
		/// <summary>
		/// Metodo che imposta i Tag dei text box inerenti la previsione in base al numero di UPB presenti.
		/// Se esiste un solo UPB si potrà scrivere nella tabella FINYEAR dal form di bilancio altrimenti
		/// bisognerà scrivere dal form di imputazione
        /// In seguito all'introduzione del TabPage delle previsioni, in cui si utilizza la vista, 
        /// modifichiamo questo form affinchè lavori sempre e solo con la vista.
		/// </summary>
        //private void impostaTagTxtPrevisione() {
        //    string nomeTabella = "finyearview";
        //    if (upbUnico) {
        //        SubEntity_txtpreveserciziocorr.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtpreveserciziocorr);
        //        SubEntity_txtprevesercizioprec.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtprevesercizioprec);
        //        SubEntity_txtprevseceserciziocorr.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtprevseceserciziocorr);
        //        SubEntity_txtprevsecesercizioprec.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtprevsecesercizioprec);
        //        SubEntity_txtripartizionecorr.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtripartizionecorr);
        //        SubEntity_txtripartizioneprec.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtripartizioneprec);
        //        SubEntity_txtprevision2.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtprevision2);
        //        SubEntity_txtprevision3.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtprevision3);
        //        SubEntity_txtprevision4.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtprevision4);
        //        SubEntity_txtprevision5.Tag = nomeTabella + selezionaNomeCampo(SubEntity_txtprevision5);
        //    }
        //}

		private string selezionaNomeCampo(TextBox txt) {
			string nomeTag = txt.Tag.ToString();
			string campo = nomeTag.Substring(nomeTag.IndexOf("."));
			return campo;
		}

		private void cambiaEtichetteEsercizi() {
			int esercizioCurr = (int)Meta.GetSys("esercizio");
			int esercizioPrec = esercizioCurr - 1;
			lblEsCorrentePrima.Text = esercizioCurr.ToString();
			lblEsCorrSeconda.Text = esercizioCurr.ToString();
            lblRipCorrente.Text = "Presunti del " + esercizioPrec.ToString();
			lblEsPrecPrima.Text = esercizioPrec.ToString();
			lblEsPrecSeconda.Text = esercizioPrec.ToString();
            lblRipPrecedente.Text = "Effettivi del " + esercizioPrec.ToString();

			lblPrevisione2.Text = (++esercizioCurr).ToString();
			lblPrevisione3.Text = (++esercizioCurr).ToString();
			lblPrevisione4.Text = (++esercizioCurr).ToString();
			lblPrevisione5.Text = (++esercizioCurr).ToString();
		}

        object pagamento ;
        object impegno;

        object incasso;
        object accertamento ;

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QueryCreator.SetTableForPosting(DS.finyearview, "finyear");

			AfterLinkBody();
            PostData.SetPostingOrder(DS.finyearview, "idupb");
            string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter = QHS.AppAnd(QHS.IsNull("idupb"), QHS.IsNull("idman"), QHS.IsNull("idsorreg"), QHS.IsNull("idsorkindreg"));
            filter = QHS.AppAnd(filter, filtereserc);
            GetData.SetStaticFilter(DS.sortingincomefilter, filter);
            GetData.SetStaticFilter(DS.sortingexpensefilter, filter);
            GetData.SetStaticFilter(DS.autoexpensesorting, filter);
            GetData.SetStaticFilter(DS.autoincomesorting, filter);
            GetData.SetStaticFilter(DS.account, filtereserc);
            GetData.SetStaticFilter(DS.sortingview, filtereserc);

            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) {
                //grpPrevCompetenza.Visible = false;         //cassa
                tabControlRiepilogo.TabPages.Remove(tabCompetenza);
            }
          
            string filterEpOperation = QHS.CmpEq("idepoperation", "pgiro");
            GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperation);
            DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;



		}


        private void impostaCampiDaSalvare(bool salva) {
            string[] field_finyearview = new string[]{"finance","codefin","paridfin","upb","codeupb","paridupb","flag",
                                        "finpart","nlevel","leveldescr","idsor01","idsor02","idsor03","idsor04","idsor05"};
            if (!salva) {
                string empty = "";
                foreach (string field in field_finyearview) {
                    QueryCreator.SetColumnNameForPosting(DS.finyearview.Columns[field], empty);
                }
               
            }
            else {
                foreach (string field in field_finyearview) {
                    QueryCreator.SetColumnNameForPosting(DS.finyearview.Columns[field], field);
                }
                


            }
        }


        public void MetaData_AfterPost(){
            impostaCampiDaSalvare(true);
            DataRow rBilancio = HelpForm.GetLastSelected(DS.fin);
            if (rBilancio == null) return;
            object idfin = rBilancio["idfin"];
            string filter = QHS.CmpEq("idfin", idfin);
            string FilterFinyearview = "(isnull(prevision,0) <>0 or isnull(secondaryprev,0)<>0)";
            filter = QHS.AppAnd(FilterFinyearview, filter);

            Conn.RUN_SELECT_INTO_TABLE(DS.finyearview, null, filter, null, true);
            Meta.FreshForm();
        }


		public void MetaData_BeforeFill() {
            //if (HelpForm.GetLastSelected(DS.fin)== null)
            //    Meta.CanInsert = false;
            //else
            //    Meta.CanInsert = true;
            DataRow drBilancio = HelpForm.GetLastSelected(DS.fin);
            if (drBilancio != null) {
                CalcFin.Enabled = true;
                CalcFin.SetMask(drBilancio["idfin"], DBNull.Value, DBNull.Value);
            }

			if ((Meta.InsertMode) && (upbUnico)) {
				CreateFinYearRow();
			}
            CreateFinLastRow();
		}
        public void CreateFinLastRow() {
            if (Meta.IsEmpty) return;
            DataRow drBilancio = HelpForm.GetLastSelected(DS.fin);
            if (!Foglia(drBilancio)) return;
            if (DS.Tables["finlast"].Rows.Count == 0) {
                MetaData metaFL = MetaData.GetMetaData(this, "finlast");
                metaFL.SetDefaults(DS.finlast);
                DataRow DR = metaFL.Get_New_Row(drBilancio, DS.finlast);
            }
        }

		public void CreateFinYearRow() {
			if (Meta.IsEmpty) return;
			if (DS.Tables["finyearview"].Rows.Count == 0) {
               	DataRow drBilancio = HelpForm.GetLastSelected(DS.fin);
                 string filter = QHS.AppAnd (
                                 QHS.CmpEq("ayear",Meta.GetSys("esercizio")),
                                 QHS.CmpEq("idfin", drBilancio["idfin"]), 
                                 QHS.CmpEq("idupb", "0001"));
                DataTable FinYear = Conn.RUN_SELECT("finyear", "*", null, filter, null, false);
                Conn.RUN_SELECT_INTO_TABLE(DS.finyearview, null, filter, null, false);
                if (DS.Tables["finyearview"].Rows.Count == 0)
                {
                    MetaData metaFY = MetaData.GetMetaData(this, "finyearview");
                    metaFY.SetDefaults(DS.finyearview);
                    MetaData.SetDefault(DS.finyearview, "idupb", "0001"); // UPB Radice
                    MetaData.SetDefault(DS.finyearview, "ayear", Meta.GetSys("esercizio")); // UPB Radice
                    MetaData.SetDefault(DS.finyearview, "nlevel", drBilancio["nlevel"]); // 
                    MetaData.SetDefault(DS.finyearview, "paridfin", drBilancio["paridfin"]); // 
                    MetaData.SetDefault(DS.finyearview, "flag", drBilancio["flag"]); // 
                    MetaData.SetDefault(DS.finyearview, "codefin", drBilancio["codefin"]); // 
                    MetaData.SetDefault(DS.finyearview, "finance", drBilancio["title"]); // 
                    DataRow DR = metaFY.Get_New_Row(drBilancio, DS.finyearview);
                }

			}
		}

		public void MetaData_AfterActivation() {

			if (treeView1.Nodes.Count > 0) {
				if (!treeView1.Nodes[0].IsExpanded) {
					treeView1.Nodes[0].Expand();
					
				}

				if (treeView1.Nodes[0].Nodes.Count > 0) {
					treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
				}
			}
			if (treeView1.Nodes.Count > 1) {
				if (!treeView1.Nodes[1].IsExpanded) {
					treeView1.Nodes[1].Expand();
				}
			}



			//Imposta groupbox previsioni competenza 
			if (DS.config.Rows.Count==0) return;
			DataRow R = DS.config.Rows[0];

            string nomeprevsecondaria = CfgFn.NomePrevisioneSecondaria(Meta.Conn);
			if (nomeprevsecondaria==null)
				gboxSecondaPrevisione.Visible=false;
			else
				gboxSecondaPrevisione.Text= nomeprevsecondaria;

            gboxPrimaPrevisione.Text = CfgFn.NomePrevisionePrincipale(Meta.Conn);				
			ImpostaLabelRipartizione(R);
		}

		/// <summary>
		/// Imposta le Label personalizzate (se presenti) per la ripartizione
		/// </summary>
		private void ImpostaLabelRipartizione(DataRow R) {
			string RipGroupBox=R["boxpartitiontitle"].ToString();
			string RipCorrente=R["currpartitiontitle"].ToString();
			string RipPrecedente=R["prevpartitiontitle"].ToString();
			if (RipGroupBox!="") gboxRipartizione.Text=RipGroupBox;
			if (RipCorrente!="") lblRipCorrente.Text=RipCorrente;
			if (RipPrecedente!="") lblRipPrecedente.Text=RipPrecedente;
		}

		private bool Operativo(DataRow R){
			if (R==null) return false;
            int levelop = CfgFn.GetNoNullInt32(Meta.GetSys("finusablelevel"));
            int thislevel= CfgFn.GetNoNullInt32(R["nlevel"]);
            if (thislevel< levelop) return false;
            //object livellorow=R["nlevel"];
            //DataRow[] Res = DS.finlevel.Select(QHS.AppAnd(filteresercizio, QHS.CmpEq("nlevel",livellorow)));
            //if (Res.Length!=1) return false;
            //int flag = CfgFn.GetNoNullInt32(Res[0]["flag"]);
            ////string operativo=Res[0]["flagusable"].ToString().ToUpper();
            //if ((flag & 2)==0) return false;
			return true;
		}
        bool Foglia(DataRow R) {
            if (R == null) return false;
            if (Meta.InsertMode) return true;
            string filter = QHS.CmpEq("paridfin", R["idfin"]);
            int N = Conn.RUN_SELECT_COUNT("fin", filter, true);
            if (N == 0) return true;
            return false;

        }
		private bool TipoNumerico(object codicelivello){
            DataRow[] Res = DS.finlevel.Select(QHS.AppAnd(filteresercizio, QHS.CmpEq("nlevel", codicelivello)));
			if (Res.Length!=1) return false;
            int flag = CfgFn.GetNoNullInt32(Res[0]["flag"]);
            //string operativo=Res[0]["flagusable"].ToString().ToUpper();
            if ((flag & 1) == 0) return true;
            //string tipocodice = Res[0]["codekind"].ToString().ToUpper();
            //if (tipocodice=="N") return true;
			return false;
		}

        public void MetaData_BeforePost() {
            impostaCampiDaSalvare(false);

            if (!Meta.InsertMode) return;
            DataRow drBilancio = HelpForm.GetLastSelected(DS.fin);
            if (drBilancio == null) return;
            object livsup = drBilancio["paridfin"];
            if (livsup == DBNull.Value) return;            
            Conn.RUN_SELECT_INTO_TABLE(DS.finlast, null, QHS.CmpEq("idfin", livsup), null, true);
            DataRow[] R = DS.finlast.Select(QHC.CmpEq("idfin", livsup));
            if (R.Length == 0) return;
            R[0].Delete();
        }
        


		public void MetaData_AfterFill(){
            if (!Meta.CanInsert) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }

			//abilita/disabilita i controlli
			bool ModoInsert= Meta.InsertMode;
			if (Meta.EditMode) {
				SP_Called=false;
				//EnableControls(false);
				if ((DS.finyearview.Rows.Count == 0) && (Meta.EditMode)) { // sa
					DataRow R = HelpForm.GetLastSelected(DS.fin);
                    btnCreaPrevisioni.Visible = Operativo(R);
				}
				else {
					btnCreaPrevisioni.Visible = false;
				}

			}

			btnNewSituazione.Enabled=!ModoInsert;
			grpParte.Enabled=false;
			cmbLivello.Enabled=false;

		    CheckTxtReadOnly();
			

            impostaCampiReadonly(false);
            if (Meta.InsertMode){
               	AbilitaBottoni(false);
            }
            else{
                DataRow R = HelpForm.GetLastSelected(DS.fin);
                if (R == null) return;
                //if (Meta.FirstFillForThisRow) {
                    CalcolaValoriTxtPrevisione(R);
                //}
                    AbilitaBottoni(true);

                /*
                if (Operativo(R)){
                    AbilitaBottoni(true);

                }
                else{
                    AbilitaBottoni(false);
                    pulisciTextRiepilogo();
                }
                 */
            }
            AbilitaSezioniRiepilogo();
            //AbilitaDisabilitaGrpPrevisione();
		}

	    void CheckTxtReadOnly() {
	        bool ModoInsert= Meta.InsertMode;

	        if (ModoInsert){
	            DataRow R = HelpForm.GetLastSelected(DS.fin);
	            if (R == null) return;
	            if (Operativo(R)){
	          
	                if ((!SP_Called) && (upbUnico)){
	                    CalcolaPrevisioni(R["paridfin"]);
	                    SP_Called=true;
	                }
	            }
	         
	        }

	        calcolaEnableDisableSuRigaBilancio(HelpForm.GetLastSelected(DS.fin));

	    }



         private string FilterPrevInizialeCompetenza(object idfin, string VistaScelta,string finpart) {
            string filter = "";
            filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            if (idfin != DBNull.Value) filter = QHS.AppAnd(filter, finCompPrevision(VistaScelta + ".idfin", idfin));
            if (idfin == DBNull.Value && VistaScelta=="finyearview") {
                int levelop = CfgFn.GetNoNullInt32(Meta.GetSys("finusablelevel"));
                filter = QHS.AppAnd(filter, QHS.CmpEq("nlevel", levelop));
            }
            if (finpart != "") filter = QHS.AppAnd(filter, QHS.CmpEq("finpart", finpart));
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));
            return filter;
        }

         delegate string myFinComparator(string field, object value);
        string FinCompareEqual(string field, object value) {
            return QHS.CmpEq(field, value);
        }

        bool voceBilancioFoglia=false;
        bool voceBilancioOperativa=false;

        string FinGetAllChilds(string field, object value) {
            if (voceBilancioFoglia) {
                return QHS.CmpEq(field, value);
            }
            else {
                return "(" + field + " in (select idchild from finlink FFL where FFL.idparent=" + QHS.quote(value) + "))";
            }
        }
        string FinGetChildsLivOperativo(string field, object value) {
            int minlevelop = CfgFn.GetNoNullInt32(Conn.GetSys("finusablelevel"));
            return "(" + field + " in (select idchild from finlink FqL where FqL.idparent=" + QHS.quote(value)
                        + ")) AND ( (select nlevel from fin fq5 where fq5.idfin="+field+")="+QHS.quote(minlevelop)+")";
        }

        void ChooseComparators() {
           
            if (voceBilancioOperativa) {
                finCompPrevision = FinCompareEqual;
            }
            else {
                finCompPrevision = FinGetChildsLivOperativo;
            }

        }
        
        private string FilterPrevInizialeCompetenza(object idfin) {
            ChooseComparators();
            string filter = "";
            string VistaScelta = "finyearview";
            filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, finCompPrevision(VistaScelta + ".idfin", idfin));                        
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));
            return filter;
        }



        

       
        myFinComparator finCompPrevision;

        private void CalcolaValoriTxtPrevisione(DataRow R) {
            string Filter = Conn.SelectCondition("finyearview", true);
            if ((Filter!=null) && (Filter!="")) {
                //Applichiamo la sicurezza
                DataRow CurrFin = HelpForm.GetLastSelected(DS.fin);
                if (CurrFin == null) return;
                int nlevel = CfgFn.GetNoNullInt32(CurrFin["nlevel"]);
                //Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                //Filter = QHS.AppAnd(Filter, QHS.CmpEq("finlink.idparent", CurrFin["idfin"]));
                Filter = QHS.AppAnd(Filter,FilterPrevInizialeCompetenza(R["idfin"]));
                string sql = "SELECT SUM(prevision) as prevision, SUM(previousprevision) as previousprevision, "+
                            " SUM(secondaryprev) as secondaryprev, SUM(previoussecondaryprev) as previoussecondaryprev, " +
                            " SUM(currentarrears) as currentarrears, SUM(previousarrears) as previousarrears, " +
                            " SUM(prevision2) as prevision2, SUM(prevision3) as prevision3, "+
                            " SUM(prevision4) as prevision4, SUM(prevision5) as prevision5 " +
                            " FROM finyearview " +
                            " WHERE " + Filter;

                DataTable Previsioni = Conn.SQLRunner(sql, false);
                if (Previsioni.Rows.Count > 0) {
                    DataRow rPrevisioni = Previsioni.Rows[0];
                    SubEntity_txtpreveserciziocorr.Text = CK(rPrevisioni["prevision"]).ToString("c");
                    SubEntity_txtprevesercizioprec.Text = CK(rPrevisioni["previousprevision"]).ToString("c");
                    SubEntity_txtprevseceserciziocorr.Text = CK(rPrevisioni["secondaryprev"]).ToString("c");
                    SubEntity_txtprevsecesercizioprec.Text = CK(rPrevisioni["previoussecondaryprev"]).ToString("c");
                    SubEntity_txtripartizionecorr.Text = CK(rPrevisioni["currentarrears"]).ToString("c");
                    SubEntity_txtripartizioneprec.Text = CK(rPrevisioni["previousarrears"]).ToString("c");
                    SubEntity_txtprevision2.Text = CK(rPrevisioni["prevision2"]).ToString("c");
                    SubEntity_txtprevision3.Text = CK(rPrevisioni["prevision3"]).ToString("c");
                    SubEntity_txtprevision4.Text = CK(rPrevisioni["prevision4"]).ToString("c");
                    SubEntity_txtprevision5.Text = CK(rPrevisioni["prevision5"]).ToString("c");
                }
            }
            else {
                //Leggiamo da finunified, come prima.
                if (DS.finunified.Rows.Count > 0) {
                    DataRow CurrFinunified = DS.finunified.Rows[0];
                    SubEntity_txtpreveserciziocorr.Text = CK(CurrFinunified["prevision"]).ToString("c");
                    SubEntity_txtprevesercizioprec.Text = CK(CurrFinunified["previousprevision"]).ToString("c");
                    SubEntity_txtprevseceserciziocorr.Text = CK(CurrFinunified["secondaryprev"]).ToString("c");
                    SubEntity_txtprevsecesercizioprec.Text = CK(CurrFinunified["previoussecondaryprev"]).ToString("c");
                    SubEntity_txtripartizionecorr.Text = CK(CurrFinunified["currentarrears"]).ToString("c");
                    SubEntity_txtripartizioneprec.Text = CK(CurrFinunified["previousarrears"]).ToString("c");
                    SubEntity_txtprevision2.Text = CK(CurrFinunified["prevision2"]).ToString("c");
                    SubEntity_txtprevision3.Text = CK(CurrFinunified["prevision3"]).ToString("c");
                    SubEntity_txtprevision4.Text = CK(CurrFinunified["prevision4"]).ToString("c");
                    SubEntity_txtprevision5.Text = CK(CurrFinunified["prevision5"]).ToString("c");
                }
            }
        }

        private void AbilitaDisabilitaGrpPrevisione() {
            int nUpb = Conn.RUN_SELECT_COUNT("upb", null, true);
            if (nUpb == 1) {
                GrpboxPrevisione.Visible = true;
            }
            else {
                GrpboxPrevisione.Visible = false;
            }

        }

        private void AbilitaBottoni(bool abilita)
        {
         
            btnAccertamentiCompetenza.Enabled = abilita;
            btnAssegnazioniCassa.Enabled = abilita;
            btnCreditiAssegnati.Enabled = abilita;
            btnDelPrevisione.Enabled = abilita;
            btnDotazioneCassa.Enabled = abilita;
            btnDotazioneCrediti.Enabled = abilita;
            btnVarDotazioneCrediti.Enabled = abilita;
            btnVarDotazioneCassa.Enabled = abilita;
            btnImpegniCompetenza.Enabled = abilita;
            btnIncassi.Enabled = abilita;
            btnPagamenti.Enabled = abilita;
            btnPagamenti1.Enabled = abilita;
            btnPrevInizialeCassa.Enabled = abilita;
            btnPrevInizialeCompetenza.Enabled = abilita;
            btnVarPrevCompetenza.Enabled = abilita;
            btnVarPrevisioneCassa.Enabled = abilita;
            btnPiccoleSpeseImp.Enabled = abilita; ;
            btnPiccoleSpesePagamenti.Enabled = abilita;
            btnPiccoleSpesePagamenti1.Enabled = abilita;
            btnAccertamentiAll.Enabled = abilita;
            btnImpegniAll.Enabled = abilita;
            DataRow R = HelpForm.GetLastSelected(DS.fin);
            if (R != null)
            {
                int flag = CfgFn.GetNoNullInt32(R["flag"]);
                if ((flag & 1) == 1)
                {
                    //  finpart = "S";
                    lblAccertamentiCompetenza.Visible = false;
                    txtAccertamentiCompetenza.Visible = false;
                    btnAccertamentiCompetenza.Visible = false;
                    lblAccertamentiAll.Visible = false;
                    txtAccertamentiAll.Visible = false;
                    btnAccertamentiAll.Visible = false;
                    lblIncassi.Visible = false;
                    txtIncassi.Visible = false;
                    btnIncassi.Visible = false;

                    lblImpegniCompetenza.Visible = true;
                    txtImpegniCompetenza.Visible = true;
                    btnImpegniCompetenza.Visible = true;

                    lblImpegniAll.Visible = true;
                    txtImpegniAll.Visible = true;
                    btnImpegniAll.Visible = true;

                    lblPiccoleSpeseImp.Visible = true;
                    txtPiccoleSpeseImp.Visible = true;
                    btnPiccoleSpeseImp.Visible = true;

                    lblPagamenti.Visible = true;
                    txtPagamenti.Visible = true;
                    btnPagamenti.Visible = true;

                    lblPagamenti1.Visible = true;
                    txtPagamenti1.Visible = true;
                    btnPagamenti1.Visible = true;

                    lblPiccoleSpesePagamenti.Visible = true;
                    txtPiccoleSpesePagamenti.Visible = true;
                    btnPiccoleSpesePagamenti.Visible = true;

                    lblPiccoleSpesePagamenti1.Visible = true;
                    txtPiccoleSpesePagamenti1.Visible = true;
                    btnPiccoleSpesePagamenti1.Visible = true;
                    if (pagamento != null) {
                        lblPrevDispCassaPagInc.Text = "Previsione Disponibile di cassa su " + pagamento.ToString().ToLower();
                    }
                    if (impegno != null) {
                        lblPrevDispCassaImpegniAccertamenti.Text = "Previsione Disponibile di cassa su " + impegno.ToString().ToLower();
                    }

                }

                else
                {
                    //  finpart = "E";
                    lblAccertamentiCompetenza.Visible = true;
                    txtAccertamentiCompetenza.Visible = true;
                    btnAccertamentiCompetenza.Visible = true;
                    lblAccertamentiAll.Visible = true;
                    txtAccertamentiAll.Visible = true;
                    btnAccertamentiAll.Visible = true;
                    lblIncassi.Visible = true;
                    txtIncassi.Visible = true;
                    btnIncassi.Visible = true;

                    lblImpegniCompetenza.Visible = false;
                    txtImpegniCompetenza.Visible = false;
                    btnImpegniCompetenza.Visible = false;
                    lblImpegniAll.Visible = false;
                    txtImpegniAll.Visible = false;
                    btnImpegniAll.Visible = false;

                    lblPiccoleSpeseImp.Visible = false;
                    txtPiccoleSpeseImp.Visible = false;
                    btnPiccoleSpeseImp.Visible = false;

                    lblPagamenti.Visible = false;
                    txtPagamenti.Visible = false;
                    btnPagamenti.Visible = false;

                    lblPagamenti1.Visible = false;
                    txtPagamenti1.Visible = false;
                    btnPagamenti1.Visible = false;

                    lblPiccoleSpesePagamenti.Visible = false;
                    txtPiccoleSpesePagamenti.Visible = false;
                    btnPiccoleSpesePagamenti.Visible = false;

                    lblPiccoleSpesePagamenti1.Visible = false;
                    txtPiccoleSpesePagamenti1.Visible = false;
                    btnPiccoleSpesePagamenti1.Visible = false;
                    if (incasso != null) {
                        lblPrevDispCassaPagInc.Text = "Previsione Disponibile di cassa per " + incasso.ToString().ToLower();
                    }
                    if (accertamento != null) {

                        lblPrevDispCassaImpegniAccertamenti.Text = "Previsione Disponibile di cassa per " + accertamento.ToString().ToLower();
                    }
                }
            }
            btnCalcolaTotali.Enabled = abilita;
        }

        void VisualizzaInTabCassaSolo(string pattern ) {
            foreach (Control C in grpPrevCassa.Controls) {
                if (C.Name.ToLower().Contains(pattern) )
                    C.Visible = true;
                else
                    C.Visible = false;
            }
        }
        void VisualizzaInTabCassaTranne(string pattern1, string pattern2) {
            foreach (Control C in grpPrevCassa.Controls) {
                if ( C.Name.ToLower().Contains(pattern1) || C.Name.ToLower().Contains(pattern2) )
                    C.Visible = false;
                else
                    C.Visible = true;
            }
        }


        private void AbilitaSezioniRiepilogo() {
            grpPrevCompetenza.Enabled = true;
            DataRow R = HelpForm.GetLastSelected(DS.fin);
            if (R == null) return;
            int flag = CfgFn.GetNoNullInt32(R["flag"]);

            string what;
            if ((flag & 1) == 1)
                what = "pagamenti";
            else
                what = "incassi";

            string whatnot1;
            string whatnot2;
            if ((flag & 1) == 1) {
                whatnot1 = "accertamenti";
                whatnot2 = "incassi";
            }
            else {
                whatnot1 = "pagamenti";
                whatnot2 = "impegni";
            }

            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 1) VisualizzaInTabCassaSolo(what); //competenza
            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) grpPrevCompetenza.Visible = false;         //cassa
            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 3) VisualizzaInTabCassaTranne(whatnot1, whatnot2); //comp e cassa



            if ((DS.config.Rows[0]["flagcredit"].ToString() == "S") && ((flag & 1) == 1)) // spesa
                grpCrediti.Visible = true;
            else
                grpCrediti.Visible = false;

            if ((DS.config.Rows[0]["flagproceeds"].ToString() == "S") && ((flag & 1) == 1)) // spesa
            {
                grpCassa.Visible = true;
            }
            else
                grpCassa.Visible = false;

        }


        private void CalcolaValoriText(){
            DataRow R = HelpForm.GetLastSelected(DS.fin);
            if (R == null) return;
            int flag = CfgFn.GetNoNullInt32(R["flag"]);

            decimal totprevinicomp=  CalcFin.TotPrevInizialeCompetenza("");
            txtPrevInizialeCompetenza.Text =totprevinicomp.ToString("C");
            decimal totvarprevcomp = CalcFin.TotVarPrevCompetenza("");
            txtVarPrevCompetenza.Text = totvarprevcomp.ToString("C");
            decimal totPrevComp = totprevinicomp + totvarprevcomp;
            txtPrevAttualeCompetenza.Text = totPrevComp.ToString("C");

            decimal totImpegniCompetenza = CalcFin.TotImpegniCompetenza();
            txtImpegniCompetenza.Text = totImpegniCompetenza.ToString("C");
            decimal totImpegniAll = CalcFin.TotImpegniAll();
            txtImpegniAll.Text = totImpegniAll.ToString("C");

            decimal totpreviniCassa = CalcFin.TotPrevInizialeCassa("");
            txtPrevInizialeCassa.Text = totpreviniCassa.ToString("C");
            decimal totvatprevCassa = CalcFin.TotVarPrevCassa("");
            txtVarPrevisioneCassa.Text = totvatprevCassa.ToString("C");
            decimal totPrevCassa = totpreviniCassa + totvatprevCassa;
            txtPrevAttualeCassa.Text = totPrevCassa.ToString("C");

            decimal totPagamenti = CalcFin.TotPagamenti();
            txtPagamenti.Text = totPagamenti.ToString("C");
            txtPagamenti1.Text = totPagamenti.ToString("C");

            decimal totPiccoleSpeseImp =CalcFin.TotPiccoleSpeseImp();
            txtPiccoleSpeseImp.Text = totPiccoleSpeseImp.ToString("C");

            decimal totPiccoleSpesePag =  CalcFin.TotPiccoleSpesePag();
            txtPiccoleSpesePagamenti.Text = totPiccoleSpesePag.ToString("C");
            txtPiccoleSpesePagamenti1.Text = totPiccoleSpesePag.ToString("C");

            decimal totAccertamentiComp = CalcFin.TotAccertamentiCompetenza();
            txtAccertamentiCompetenza.Text = totAccertamentiComp.ToString("C");
            decimal totAccertamentiAll = CalcFin.TotAccertamentiAll();
            txtAccertamentiAll.Text = totAccertamentiAll.ToString("C");
            decimal totIncassi = CalcFin.TotIncassi();
            txtIncassi.Text = totIncassi.ToString("C");


            if ((flag & 1) == 1) // spesa
            {
                txtPrevDispCompetenza.Text = (totPrevComp - totImpegniCompetenza - totPiccoleSpeseImp).ToString("C");
                txtPrevDispCassaPerImpegniAccertamenti.Text = (totPrevCassa - totImpegniAll - totPiccoleSpesePag).ToString("C");
                txtPrevDispCassaPerPagInc.Text = (totPrevCassa - totPagamenti - totPiccoleSpesePag).ToString("C");
            }
            else
            {
                txtPrevDispCompetenza.Text = (totPrevComp - totAccertamentiComp).ToString("C");
                txtPrevDispCassaPerImpegniAccertamenti.Text = (totPrevCassa - totAccertamentiAll).ToString("C");
                txtPrevDispCassaPerPagInc.Text = (totPrevCassa - totIncassi).ToString("C");
                
            }
            decimal totdotCreditiIniziale = CalcFin.TotVarRipartizioneCrediti();
            txtDotazioneCrediti.Text = totdotCreditiIniziale.ToString("C");
            decimal totVarDotCrediti  = CalcFin.TotVarNormaleCrediti();
            txtVarDotazioneCrediti.Text = totVarDotCrediti.ToString("C");
            decimal totAssCrediti = CalcFin.TotAssegnazioniCrediti();
            txtCreditiAssegnati.Text = totAssCrediti.ToString("C");
            decimal totaleCrediti = totdotCreditiIniziale + totVarDotCrediti + totAssCrediti;
            txtTotaleCrediti.Text = totaleCrediti.ToString("C");

            txtCreditiResidui.Text = (totaleCrediti - totImpegniCompetenza - totPiccoleSpeseImp).ToString("C");

            decimal totDotinizialeCassa = CalcFin.TotVarRipartizioneCassa();
            txtDotazioneCassa.Text = totDotinizialeCassa.ToString("C");
            decimal totVarDotazioneCassa = CalcFin.TotVarNormaleCassa();
            txtVarDotazioneCassa.Text = totVarDotazioneCassa.ToString("C");
            decimal totAssCassa = CalcFin.TotAssegnazioniIncassi();
            txtAssegnazioniCassa.Text = totAssCassa.ToString("C");
            decimal totaleCassa = totDotinizialeCassa + totVarDotazioneCassa + totAssCassa;
            txtTotaleCassa.Text = totAssCassa.ToString("C");

            txtCassaResidua.Text = (totaleCassa - totPagamenti - totPiccoleSpesePag).ToString("C");

        }




        private void impostaCampiReadonly(bool abilita){
            DS.finyearview.Columns["finpart"].ReadOnly = abilita;
        }

		public void MetaData_AfterClear(){
            CalcFin.Enabled = false;
            EnableControls(true, false);//Enable, SolaLettura
			grpParte.Enabled=true;
			cmbLivello.Enabled=true;
			txtCodice.ReadOnly=false;
			txtOrdineStampa.ReadOnly=false;
			txtDenominazione.ReadOnly=false;

            txtResponsabile.ReadOnly = false;
            SubEntity_txtScadenza.ReadOnly = false;
            SubEntity_cup.ReadOnly = false;
			btnNewSituazione.Enabled=false;
			btnSuddivisioni.Enabled = false;
            AbilitaBtnPrevisione(false);
			//AbilitaClassificazione(false);
			pulisciTxtPrevisione();
			btnCreaPrevisioni.Visible = false;
            // Abbiamo deciso che in ricerca non posso inserire x evitare sgraditi effetti ottici
            Meta.CanInsert = false;
            chkAvanzoEntrata.Visible = rdbEntrata.Checked;
            chkAvanzoUscita.Visible = rdbSpesa.Checked;
            voceBilancioFoglia = false;
            voceBilancioOperativa=false;

            pulisciTextRiepilogo();
            AbilitaBottoni(false);
			rdbEntrata.Checked = false;
			rdbSpesa.Checked = false;
			chkES.CheckState = CheckState.Indeterminate;
		}

        private void pulisciTextRiepilogo()
        {
            txtPrevInizialeCompetenza.Text = "";
            txtVarPrevCompetenza.Text = "";
            txtImpegniCompetenza.Text = "";
            txtPrevDispCompetenza.Text = "";
            txtPrevInizialeCassa.Text = "";
            txtVarPrevisioneCassa.Text = "";
            txtPagamenti.Text = "";
            txtPagamenti1.Text = "";
            txtPrevDispCassaPerPagInc.Text = "";
            txtDotazioneCrediti.Text = "";
            txtCreditiAssegnati.Text = "";
            txtCreditiResidui.Text = "";
            txtDotazioneCassa.Text = "";
            txtVarDotazioneCrediti.Text = "";
            txtVarDotazioneCassa.Text = "";
            txtAssegnazioniCassa.Text = "";
            txtCassaResidua.Text = "";
            txtAccertamentiCompetenza.Text = "";
            txtIncassi.Text = "";
            txtPiccoleSpeseImp.Text = "";
            txtPiccoleSpesePagamenti.Text = "";
            txtPiccoleSpesePagamenti1.Text = "";

            txtTotaleCassa.Text = "";
            txtTotaleCrediti.Text = "";
            txtPrevAttualeCompetenza.Text = "";
            txtPrevAttualeCassa.Text = "";
        }
		private void pulisciTxtPrevisione() {
			string empty = "";
			SubEntity_txtpreveserciziocorr.Text = empty;
			SubEntity_txtprevesercizioprec.Text = empty;
			SubEntity_txtprevseceserciziocorr.Text = empty;
			SubEntity_txtprevsecesercizioprec.Text = empty;
			SubEntity_txtripartizionecorr.Text = empty;
			SubEntity_txtripartizioneprec.Text = empty;
			SubEntity_txtprevision2.Text = empty;
			SubEntity_txtprevision3.Text = empty;
			SubEntity_txtprevision4.Text = empty;
			SubEntity_txtprevision5.Text = empty;
		}

		void AbilitaClassificazione(bool enable){
			btnElimina.Enabled=enable;
			btnInserisci.Enabled=enable;
			btnModifica.Enabled=enable;
		}

        private void EnableControls(bool enable, bool solaLettura) {



            int nRowFinYear = DS.finyearview.Rows.Count;    
			DataRow R = HelpForm.GetLastSelected(DS.fin);
            // I text della previsione non devono essere mai editabili
			SubEntity_txtpreveserciziocorr.ReadOnly		= solaLettura;
			SubEntity_txtprevesercizioprec.ReadOnly		= solaLettura;
			SubEntity_txtprevseceserciziocorr.ReadOnly	= solaLettura;
			SubEntity_txtprevsecesercizioprec.ReadOnly	= solaLettura;
			SubEntity_txtripartizionecorr.ReadOnly		= solaLettura;
			SubEntity_txtripartizioneprec.ReadOnly		= solaLettura;
			SubEntity_txtprevision2.ReadOnly			= solaLettura;
			SubEntity_txtprevision3.ReadOnly			= solaLettura;
			SubEntity_txtprevision4.ReadOnly			= solaLettura;
			SubEntity_txtprevision5.ReadOnly			= solaLettura;
			bool visibile = !upbUnico && enable;
			btnSuddivisioni.Enabled						= visibile;

			//AbilitaClassificazione(enable);
							
			chbPartiteGiro.Enabled				=enable;
            chbTrasferimenti.Enabled = enable;
            chkMovProtetta.Enabled = enable;
            chkNoContab.Enabled = enable;
            AbilitaBtnPrevisione(enable);
            chkAvanzoEntrata.Enabled = enable;
            chkAvanzoUscita.Enabled = enable;
		}

        void AbilitaBtnPrevisione(bool enable){
            btnInsPrevisione.Enabled = enable;
            btnEditPrevisione.Enabled = enable;
            btnDelPrevisione.Enabled = enable;
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T.TableName != "fin") return;
		    CheckTxtReadOnly();
		}

	    void calcolaEnableDisableSuRigaBilancio(DataRow R) {
              if (R != null) {
                CalcFin.Enabled = true;
                CalcFin.SetMask(R["idfin"], DBNull.Value, DBNull.Value);
                voceBilancioFoglia =  Foglia(R);
                voceBilancioOperativa = Operativo(R);

            }
            else {
                CalcFin.Enabled = false;
                voceBilancioFoglia = false;
                voceBilancioOperativa=false;
            }
            
            pulisciTextRiepilogo();
			if (Meta.EditMode) SP_Called=false;
			bool ModoInsert=Meta.InsertMode;
			//txtEsercizio.ReadOnly=!ModoInsert;
			cmbLivello.Enabled=false;
			btnNewSituazione.Enabled=!ModoInsert;
			grpParte.Enabled=false;
			if (Operativo(R)){
                EnableControls(true, true); //Enable, SolaLettura
				//show(txtCodice.Text);
				object livello = R["nlevel"];
				txtCodice.ReadOnly=!(ModoInsert && !TipoNumerico(livello));
				txtOrdineStampa.ReadOnly=TipoNumerico(livello);
                if (Foglia(R)) {
                    gboxConto.Enabled = true; 
                    txtResponsabile.ReadOnly = false;
                    SubEntity_txtScadenza.ReadOnly = false;
                    SubEntity_cup.ReadOnly = false;
                    gBoxCausalePartiteGiro.Enabled = (CfgFn.GetNoNullInt32(R["flag"])& 2)!=0;
                }
                else {
                    gboxConto.Enabled = false;
                    txtResponsabile.ReadOnly = true;
                    SubEntity_txtScadenza.ReadOnly = true;
                    SubEntity_cup.ReadOnly = true;
                    gBoxCausalePartiteGiro.Enabled = false;
                }

            }
			else{
			    object livello = (R==null)? 0:R["nlevel"];
                EnableControls(false, true);//Enable, SolaLettura
			    txtCodice.ReadOnly= !(ModoInsert && !TipoNumerico(livello));
                txtOrdineStampa.ReadOnly=TipoNumerico(livello);
                if (Foglia(R)) {
                    gboxConto.Enabled = true;
                    txtResponsabile.ReadOnly = false;
                    SubEntity_txtScadenza.ReadOnly = false;
                    SubEntity_cup.ReadOnly = false;
                    gBoxCausalePartiteGiro.Enabled = (CfgFn.GetNoNullInt32(R["flag"])& 2)!=0;
                }
                else {
                    gboxConto.Enabled = false;
                    txtResponsabile.ReadOnly = true;
                    SubEntity_txtScadenza.ReadOnly = true;
                    SubEntity_cup.ReadOnly = true;
                    gBoxCausalePartiteGiro.Enabled = false;
                }
                SubEntity_txtScadenza.ReadOnly = true;
                SubEntity_cup.ReadOnly = true;
                if (R == null) {
                    pulisciTxtPrevisione();//Stiamo sulla root
                }
			}
			//if (R!=null) MetaData.SetDefault(T,"idman",R["idman"]);
            if (R != null){
                MetaData.SetDefault(DS.autoexpensesorting, "idfin", R["idfin"]);
                MetaData.SetDefault(DS.autoincomesorting, "idfin", R["idfin"]);
                MetaData.SetDefault(DS.sortingexpensefilter, "idfin", R["idfin"]);
                MetaData.SetDefault(DS.sortingincomefilter, "idfin", R["idfin"]);
            }
	    }


		private void rdbEntrata_CheckedChanged(object sender, System.EventArgs e) {
            DataRow Last = HelpForm.GetLastSelected(DS.fin);
            if (Meta.IsEmpty)
                Last = null;
               

            if (!rdbEntrata.Checked && !rdbSpesa.Checked) {
                chkES.CheckState = CheckState.Indeterminate;
            }
			if (rdbEntrata.Checked){
				MetaData.SetDefault(DS.fin, "flag", 0);
                if ((chkES.Checked)||(chkES.CheckState==CheckState.Indeterminate)) chkES.CheckState =  CheckState.Unchecked;
                chkAvanzoEntrata.Visible = true;
                chkAvanzoUscita.Visible = false;
                if (Last!=null) chkAvanzoUscita.CheckState = CheckState.Unchecked;
			}
		}

		private void rdbSpesa_CheckedChanged(object sender, System.EventArgs e) {
            DataRow Last = HelpForm.GetLastSelected(DS.fin);
            if (Meta.IsEmpty)
                Last = null;

            if (!rdbEntrata.Checked && !rdbSpesa.Checked) {
                chkES.CheckState = CheckState.Indeterminate;
            }
            if (rdbSpesa.Checked) {
				MetaData.SetDefault(DS.fin, "flag", 1);
                if ((!chkES.Checked) || (chkES.CheckState == CheckState.Indeterminate)) {
                    chkES.CheckState = CheckState.Checked;
                }
                chkAvanzoUscita.Visible = true;
                chkAvanzoEntrata.Visible = false;
                if (Last != null) chkES.CheckState = CheckState.Checked;
            }
		}

		private void chbAvanzo_Click(object sender, System.EventArgs e) {
			if (!MetaData.GetMetaData(this).IsEmpty){
				if (((CheckBox)sender).CheckState==CheckState.Indeterminate)
					((CheckBox)sender).CheckState=CheckState.Unchecked;
			}

			if (sender == chbPartiteGiro && !Meta.IsEmpty) {
				Meta.GetFormData(true);
				CheckTxtReadOnly();
			}
		}
		
		void CalcolaPrevisioni(object livsupid){

			string []parnames = new string[7]{	"@paridfin",
												"@prevision",
												"@secondaryprev",
												"@currentarrears",
												"@previousprevision",
												"@previoussecondaryprev",
												"@previousarrears"};
			SqlDbType []partypes = new SqlDbType[7]{
													   SqlDbType.Int,
													   SqlDbType.Decimal,
													   SqlDbType.Decimal,
													   SqlDbType.Decimal,
													   SqlDbType.Decimal,
													   SqlDbType.Decimal,
													   SqlDbType.Decimal};
			int []parlen = new int[7]{39,0,0,0,0,0,0};
			ParameterDirection []pardir = new ParameterDirection[7]{
																	   ParameterDirection.Input,
																	   ParameterDirection.Output,
																	   ParameterDirection.Output,
																	   ParameterDirection.Output,
																	   ParameterDirection.Output,
																	   ParameterDirection.Output,
																	   ParameterDirection.Output};
			object []parval= new object[7]{livsupid, DBNull.Value, DBNull.Value, DBNull.Value,
											  DBNull.Value, DBNull.Value, DBNull.Value};

			bool res = Meta.Conn.CallSPParameter("compute_availableprevision",
				parnames,partypes,parlen,pardir,ref parval,false,-1);
			if (!res) return;

			//ora vanno esaminati i valori di ritorno dei parametri OUT
			//DS.fin.Columns["prevision"].DefaultValue=parval[0];
			if (parval[1]!=DBNull.Value)
				SubEntity_txtpreveserciziocorr.Text=Convert.ToDecimal(parval[1]).ToString("c");
			else
				SubEntity_txtpreveserciziocorr.Text="";
			//DS.fin.Columns["previousprevision"].DefaultValue=parval[1];
			if (parval[4]!=DBNull.Value)
				SubEntity_txtprevesercizioprec.Text=Convert.ToDecimal(parval[4]).ToString("c");
			else
				SubEntity_txtprevesercizioprec.Text="";
			if (gboxSecondaPrevisione.Visible){
				//DS.fin.Columns["secondaryprev"].DefaultValue=parval[2];
				if (parval[2]!=DBNull.Value)
					SubEntity_txtprevseceserciziocorr.Text=Convert.ToDecimal(parval[2]).ToString("c");
				else
					SubEntity_txtprevseceserciziocorr.Text="";
				//DS.fin.Columns["previoussecondaryprev"].DefaultValue=parval[3];
				if (parval[5]!=DBNull.Value)
					SubEntity_txtprevsecesercizioprec.Text=Convert.ToDecimal(parval[5]).ToString("c");
				else
					SubEntity_txtprevsecesercizioprec.Text="";
			}
			//DS.fin.Columns["currentarrears"].DefaultValue=parval[4];
			if (parval[3]!=DBNull.Value)
				SubEntity_txtripartizionecorr.Text=Convert.ToDecimal(parval[3]).ToString("c");
			else
				SubEntity_txtripartizionecorr.Text="";
			//DS.fin.Columns["previousarrears"].DefaultValue=parval[5];
			if (parval[6]!=DBNull.Value)
				SubEntity_txtripartizioneprec.Text=Convert.ToDecimal(parval[6]).ToString("c");
			else
				SubEntity_txtripartizioneprec.Text="";
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			//			if (Meta.IsEmpty)return;
            if ((!Meta.IsEmpty) && (!Meta.CanInsert)) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
			TreeNode TN = e.Node;
			if (TN.Tag!=null) return;
			if (TN.Text.ToUpper()=="E"){
				DS.Tables["fin"].Columns["flag"].DefaultValue=0;
                chkES.Checked = false;
                rdbSpesa.Checked = false;
                rdbEntrata.Checked = true;
            }
			else {
                DS.Tables["fin"].Columns["flag"].DefaultValue = 1;
                chkES.Checked = true;
                rdbEntrata.Checked = false;
                rdbSpesa.Checked = true;
            }
		}

		private void button1_Click(object sender, System.EventArgs e) {
			object idbilancio=DBNull.Value;
            object finpart = DBNull.Value;
			DataRow MyRow=HelpForm.GetLastSelected(DS.fin);
			if (MyRow==null) {
				//passa di qui solo se sono sui nodi "E" o "S"
				TreeNode CurrNode = treeView1.SelectedNode;
				finpart=CurrNode.Text;
			}
			else {
				idbilancio=MyRow["idfin"];
                int flag= CfgFn.GetNoNullInt32(MyRow["flag"]);
                if ((flag & 1) == 1)
                    finpart = "S";
                else
                    finpart = "E";
			}
            Cursor = Cursors.WaitCursor;
            btnNewSituazione.Enabled = false;
            Application.DoEvents();
			DataSet Out = Conn.CallSP("show_fin",
				new Object[3] {Meta.GetSys("datacontabile"),
								  idbilancio,finpart
							  },false, 600
				);
            Cursor = Cursors.Default;
            btnNewSituazione.Enabled = true;
            Application.DoEvents();
            if(Out == null) return;
            if(Out.Tables.Count == 0) {
                string err = Conn.LastError;
                if (err == null)
                    err = "";
                QueryCreator.ShowError(this,"Errore nel calcolo della situazione",err);
                Meta.LogError("Errore nel calcolo della situazione"+err);
                return;
            }
			Out.Tables[0].TableName= "Situazione bilancio";

			frmSituazioneViewer view = new frmSituazioneViewer(Out);
			view.Show();

		}

		private void btnSuddivisioni_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow bilancioRow = HelpForm.GetLastSelected(DS.fin);
			if (bilancioRow == null)return;

			object idBilancio = bilancioRow["idfin"];
			DS.finyearview.ExtendedProperties[MetaData.ExtraParams] = idBilancio;   
			Meta.Dispatcher.Edit(this.ParentForm,"finyearview","default",false,idBilancio);
		}

		private void btnCreaPrevisioni_Click(object sender, System.EventArgs e) {
			btnCreaPrevisioni.Visible = false;
			CreateFinYearRow();
            EnableControls(true, true); //Enable, SolaLettura
		}

        private void chkES_CheckedChanged(object sender, EventArgs e) {
            if (chkES.CheckState == CheckState.Indeterminate) {
                return;
            }
            if (chkES.Checked) {
                if (!rdbSpesa.Checked) {
                    MetaData.SetDefault(DS.fin, "flag", 1);
                    rdbSpesa.Checked = true;
                }
            }
            if (!chkES.Checked) {
                if (!rdbEntrata.Checked) {
                    MetaData.SetDefault(DS.fin, "flag", 0);
                    rdbEntrata.Checked = true;
                }
            }
        }

        private Decimal CK(Object O){
            if (O == DBNull.Value) return 0;
            return CfgFn.GetNoNullDecimal(O);
        }


        private void btnPagamenti_Click(object sender, EventArgs e) {            
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;

            CalcFin.ElencoPagamenti();
        }

        private void btnPrevInizialeCompetenza_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaPrevisioneInizialeCompetenza("");
        }

        private void btnImpegniCompetenza_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;

            CalcFin.ElencaImpegniCompetenza();

        }

       


        private void btnAccertamentiCompetenza_Click(object sender, EventArgs e){            
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;

            CalcFin.ElencaAccertamentiCompetenza();
        }
        
        private void btnIncassi_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaIncassi();
        }

       

        private void btnCreditiAssegnati_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaAssegnazioniCrediti();

        }

        private void btnAssegnazioniCassa_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaAssegnazioniIncassi();
        }




        private void btnVarPrevCompetenza_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaVariazionePrevCompetenza("");
        }


        private void btnVarPrevisioneCassa_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaVarPrevisioneCassa("");
        }





        private void btnDotazioneCrediti_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaVarRipartizioneCrediti();
           
        }

        private void btnDotazioneCassa_Click(object sender, EventArgs e) {
            //VisualizzaFinvarDetail("flagproceeds", "init");
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaVarRipartizioneCassa();
        }

    


        private void btnVarDotazioneCrediti_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaVarNormaleCrediti();
            
        }


        
        
        private void btnVarDotazioneCassa_Click(object sender, EventArgs e) {
            //VisualizzaFinvarDetail("flagproceeds", "var");
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaVarNormaleCassa();
        }

        

        private void btnPrevInizialeCassa_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaPrevInizialeCassa("");

        }

       

       
        private void btnPiccoleSpeseImp_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;

            CalcFin.ElencaPiccoleSpeseImp();


        }

       
        

        private void btnPiccoleSpesePag_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaPiccoleSpesePag();
        }

        private void btnPiccoleSpesePagIncassi_Click(object sender, EventArgs e){
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;
            CalcFin.ElencaPiccoleSpese();

            
        }

        private void btnCalcolaTotali_Click(object sender, EventArgs e) {
            CalcolaValoriText();
        }

        private void gboxSecondaPrevisione_Enter(object sender, EventArgs e) {

        }

        private void btnImpegniAll_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;

            CalcFin.ElencaImpegniAll();
        }

        private void btnAccertamentiAll_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.fin);
            if (Curr == null) return;

            CalcFin.ElencaAccertamentiAll();
        }
    }
}
