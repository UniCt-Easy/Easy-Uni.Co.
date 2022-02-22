
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using AskInfo;
using funzioni_configurazione;
using ep_functions;
namespace csa_contracttax_default {
	/// <summary>
	/// </summary>
	public class Frm_csa_contracttax_default : MetaDataForm {
		private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancButton;
        public vistaForm DS;
        private TextBox tipo;
        private Label label2;
        private TextBox txtEsercDoc;
        private Label labEsercizio;
        MetaData Meta;
        DataAccess Conn;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox gboxSpesa;
        private Label label7;
        private TextBox txtNum;
        private Label label13;
        private TextBox txtEserc;
        private Label label12;
        private ComboBox cmbFaseSpesa;
        private Button btnSpesa;
        private CheckBox chkSpesa;
        private GroupBox groupBox2;
        public GroupBox gboxclassSiope;
        public Button btnCodiceSiope;
        private TextBox txtDenomSiope;
        private TextBox txtCodiceSiope;
        private GroupBox grpBilancioVersamento;
        private TextBox txtDescrBilancio;
        private TextBox txtBilancio;
        private Button btnBilancio;
        private GroupBox gboxUPB;
        private Button btnUPB;
        private TextBox txtDescrUPB;
        private TabPage tabPage2;
        public TextBox txtUPB;
        private GroupBox groupBox1;
        private Button btnInserisci;
        private Button btnModifica;
        private Button btnElimina;
        private DataGrid dataGrid1;
        private GroupBox groupBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGrid dataGrid2;
        private TabPage tabPage3;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button button5;
        private GroupBox gboxImponibile;
        private Label label34;
        private Label label33;
        private Button btnLinkEpExp;
        private Button btnRemoveEpExp;
        private TextBox txtNumImpegno;
        private TextBox txtEsercizioImpegno;
        private Label label1;
        private ComboBox cmbFaseImpBudget;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private GroupBox gboxRipartizioneUnica;
        private Button button4;
        private Button button6;
        private Button button7;
        private DataGrid dataGrid3;
        private TabPage tabPage5;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Frm_csa_contracttax_default() {
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.tipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercDoc = new System.Windows.Forms.TextBox();
            this.labEsercizio = new System.Windows.Forms.Label();
            this.DS = new csa_contracttax_default.vistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gboxSpesa = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
            this.btnSpesa = new System.Windows.Forms.Button();
            this.chkSpesa = new System.Windows.Forms.CheckBox();
            this.grpBilancioVersamento = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gboxclassSiope = new System.Windows.Forms.GroupBox();
            this.btnCodiceSiope = new System.Windows.Forms.Button();
            this.txtDenomSiope = new System.Windows.Forms.TextBox();
            this.txtCodiceSiope = new System.Windows.Forms.TextBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gboxImponibile = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFaseImpBudget = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btnLinkEpExp = new System.Windows.Forms.Button();
            this.btnRemoveEpExp = new System.Windows.Forms.Button();
            this.txtNumImpegno = new System.Windows.Forms.TextBox();
            this.txtEsercizioImpegno = new System.Windows.Forms.TextBox();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gboxRipartizioneUnica = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gboxSpesa.SuspendLayout();
            this.grpBilancioVersamento.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxclassSiope.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.gboxImponibile.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gboxRipartizioneUnica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(905, 586);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 7;
            this.OkButton.Tag = "mainsave";
            this.OkButton.Text = "Ok";
            // 
            // CancButton
            // 
            this.CancButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancButton.Location = new System.Drawing.Point(992, 586);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(75, 23);
            this.CancButton.TabIndex = 8;
            this.CancButton.Text = "Annulla";
            // 
            // tipo
            // 
            this.tipo.Location = new System.Drawing.Point(107, 26);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(366, 20);
            this.tipo.TabIndex = 2;
            this.tipo.Tag = "csa_contracttax.vocecsa";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(107, 9);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Voce CSA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(13, 26);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.ReadOnly = true;
            this.txtEsercDoc.Size = new System.Drawing.Size(80, 20);
            this.txtEsercDoc.TabIndex = 1;
            this.txtEsercDoc.Tag = "csa_contracttax.ayear";
            // 
            // labEsercizio
            // 
            this.labEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEsercizio.Location = new System.Drawing.Point(13, 9);
            this.labEsercizio.Name = "labEsercizio";
            this.labEsercizio.Size = new System.Drawing.Size(55, 16);
            this.labEsercizio.TabIndex = 0;
            this.labEsercizio.Text = "Esercizio:";
            this.labEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1031, 459);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gboxSpesa);
            this.tabPage1.Controls.Add(this.chkSpesa);
            this.tabPage1.Controls.Add(this.grpBilancioVersamento);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1023, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gboxSpesa
            // 
            this.gboxSpesa.Controls.Add(this.label7);
            this.gboxSpesa.Controls.Add(this.txtNum);
            this.gboxSpesa.Controls.Add(this.label13);
            this.gboxSpesa.Controls.Add(this.txtEserc);
            this.gboxSpesa.Controls.Add(this.label12);
            this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
            this.gboxSpesa.Controls.Add(this.btnSpesa);
            this.gboxSpesa.Location = new System.Drawing.Point(438, 232);
            this.gboxSpesa.Name = "gboxSpesa";
            this.gboxSpesa.Size = new System.Drawing.Size(269, 108);
            this.gboxSpesa.TabIndex = 6;
            this.gboxSpesa.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(23, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fase";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNum.Location = new System.Drawing.Point(194, 64);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(69, 20);
            this.txtNum.TabIndex = 6;
            this.txtNum.Tag = "";
            this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(135, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Numero:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(70, 64);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 4;
            this.txtEserc.Tag = "";
            this.txtEserc.Leave += new System.EventHandler(this.txtEserc_Leave);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Esercizio:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseSpesa
            // 
            this.cmbFaseSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFaseSpesa.DataSource = this.DS.expensephase;
            this.cmbFaseSpesa.DisplayMember = "description";
            this.cmbFaseSpesa.Location = new System.Drawing.Point(70, 40);
            this.cmbFaseSpesa.Name = "cmbFaseSpesa";
            this.cmbFaseSpesa.Size = new System.Drawing.Size(193, 21);
            this.cmbFaseSpesa.TabIndex = 2;
            this.cmbFaseSpesa.Tag = "";
            this.cmbFaseSpesa.ValueMember = "nphase";
            this.cmbFaseSpesa.SelectedIndexChanged += new System.EventHandler(this.cmbFaseSpesa_SelectedIndexChanged);
            // 
            // btnSpesa
            // 
            this.btnSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpesa.Location = new System.Drawing.Point(142, 16);
            this.btnSpesa.Name = "btnSpesa";
            this.btnSpesa.Size = new System.Drawing.Size(121, 23);
            this.btnSpesa.TabIndex = 1;
            this.btnSpesa.TabStop = false;
            this.btnSpesa.Text = "Scegli Movimento";
            this.btnSpesa.Click += new System.EventHandler(this.btnSpesa_Click);
            // 
            // chkSpesa
            // 
            this.chkSpesa.Location = new System.Drawing.Point(439, 199);
            this.chkSpesa.Name = "chkSpesa";
            this.chkSpesa.Size = new System.Drawing.Size(321, 33);
            this.chkSpesa.TabIndex = 5;
            this.chkSpesa.Text = "Seleziona  movimento di spesa per il Costo dei  Contributi";
            this.chkSpesa.CheckedChanged += new System.EventHandler(this.chkSpesa_CheckedChanged);
            // 
            // grpBilancioVersamento
            // 
            this.grpBilancioVersamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBilancioVersamento.Controls.Add(this.txtDescrBilancio);
            this.grpBilancioVersamento.Controls.Add(this.txtBilancio);
            this.grpBilancioVersamento.Controls.Add(this.btnBilancio);
            this.grpBilancioVersamento.Location = new System.Drawing.Point(431, 17);
            this.grpBilancioVersamento.Name = "grpBilancioVersamento";
            this.grpBilancioVersamento.Size = new System.Drawing.Size(582, 138);
            this.grpBilancioVersamento.TabIndex = 2;
            this.grpBilancioVersamento.TabStop = false;
            this.grpBilancioVersamento.Tag = "AutoManage.txtBilancio.trees";
            this.grpBilancioVersamento.Text = "Capitolo di spesa";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancio.Location = new System.Drawing.Point(120, 16);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrBilancio.Size = new System.Drawing.Size(455, 90);
            this.txtDescrBilancio.TabIndex = 2;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "fin.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(5, 112);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(420, 20);
            this.txtBilancio.TabIndex = 2;
            this.txtBilancio.Tag = "fin.codefin?x";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(8, 82);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(90, 24);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "manage.fin.trees";
            this.btnBilancio.Text = "Bilancio";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gboxclassSiope);
            this.groupBox2.Controls.Add(this.gboxUPB);
            this.groupBox2.Location = new System.Drawing.Point(1, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 336);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Imputazione Costo Contributo";
            // 
            // gboxclassSiope
            // 
            this.gboxclassSiope.Controls.Add(this.btnCodiceSiope);
            this.gboxclassSiope.Controls.Add(this.txtDenomSiope);
            this.gboxclassSiope.Controls.Add(this.txtCodiceSiope);
            this.gboxclassSiope.Location = new System.Drawing.Point(10, 157);
            this.gboxclassSiope.Name = "gboxclassSiope";
            this.gboxclassSiope.Size = new System.Drawing.Size(398, 129);
            this.gboxclassSiope.TabIndex = 3;
            this.gboxclassSiope.TabStop = false;
            this.gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.treeclassmovimenti";
            this.gboxclassSiope.Text = "Classificazione SIOPE";
            // 
            // btnCodiceSiope
            // 
            this.btnCodiceSiope.Location = new System.Drawing.Point(8, 71);
            this.btnCodiceSiope.Name = "btnCodiceSiope";
            this.btnCodiceSiope.Size = new System.Drawing.Size(88, 23);
            this.btnCodiceSiope.TabIndex = 4;
            this.btnCodiceSiope.TabStop = false;
            this.btnCodiceSiope.Tag = "manage.sorting.tree";
            this.btnCodiceSiope.Text = "Codice";
            this.btnCodiceSiope.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenomSiope
            // 
            this.txtDenomSiope.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenomSiope.Location = new System.Drawing.Point(102, 16);
            this.txtDenomSiope.Multiline = true;
            this.txtDenomSiope.Name = "txtDenomSiope";
            this.txtDenomSiope.ReadOnly = true;
            this.txtDenomSiope.Size = new System.Drawing.Size(288, 85);
            this.txtDenomSiope.TabIndex = 3;
            this.txtDenomSiope.TabStop = false;
            this.txtDenomSiope.Tag = "sorting.description";
            // 
            // txtCodiceSiope
            // 
            this.txtCodiceSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodiceSiope.Location = new System.Drawing.Point(7, 103);
            this.txtCodiceSiope.Name = "txtCodiceSiope";
            this.txtCodiceSiope.Size = new System.Drawing.Size(383, 20);
            this.txtCodiceSiope.TabIndex = 3;
            this.txtCodiceSiope.Tag = "sorting.sortcode?x";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(8, 15);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(406, 136);
            this.gboxUPB.TabIndex = 1;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(6, 110);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(394, 20);
            this.txtUPB.TabIndex = 7;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(9, 82);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(88, 24);
            this.btnUPB.TabIndex = 1;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "manage.upb.tree";
            this.btnUPB.Text = "UPB";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(117, 14);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrUPB.Size = new System.Drawing.Size(283, 92);
            this.txtDescrUPB.TabIndex = 2;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ripartizioni";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.dataGrid2);
            this.groupBox3.Location = new System.Drawing.Point(10, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(856, 148);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Impegni di Budget";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 26);
            this.button1.TabIndex = 23;
            this.button1.Tag = "insert.detail";
            this.button1.Text = "Inserisci";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 26);
            this.button2.TabIndex = 25;
            this.button2.Tag = "edit.detail";
            this.button2.Text = "Modifica";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 26);
            this.button3.TabIndex = 26;
            this.button3.Tag = "delete";
            this.button3.Text = "Elimina";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(107, 19);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(734, 125);
            this.dataGrid2.TabIndex = 24;
            this.dataGrid2.Tag = "csa_contracttaxepexp.default.detail";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInserisci);
            this.groupBox1.Controls.Add(this.btnModifica);
            this.groupBox1.Controls.Add(this.btnElimina);
            this.groupBox1.Controls.Add(this.dataGrid1);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 147);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Finanziaria";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(15, 20);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(86, 26);
            this.btnInserisci.TabIndex = 23;
            this.btnInserisci.Tag = "insert.detail";
            this.btnInserisci.Text = "Inserisci";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(15, 52);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(86, 26);
            this.btnModifica.TabIndex = 25;
            this.btnModifica.Tag = "edit.detail";
            this.btnModifica.Text = "Modifica";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(15, 84);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(86, 26);
            this.btnElimina.TabIndex = 26;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(107, 19);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(734, 124);
            this.dataGrid1.TabIndex = 24;
            this.dataGrid1.Tag = "csa_contracttaxexpense.default.detail";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gboxImponibile);
            this.tabPage3.Controls.Add(this.gboxConto);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(876, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "EP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gboxImponibile
            // 
            this.gboxImponibile.Controls.Add(this.label1);
            this.gboxImponibile.Controls.Add(this.cmbFaseImpBudget);
            this.gboxImponibile.Controls.Add(this.label34);
            this.gboxImponibile.Controls.Add(this.label33);
            this.gboxImponibile.Controls.Add(this.btnLinkEpExp);
            this.gboxImponibile.Controls.Add(this.btnRemoveEpExp);
            this.gboxImponibile.Controls.Add(this.txtNumImpegno);
            this.gboxImponibile.Controls.Add(this.txtEsercizioImpegno);
            this.gboxImponibile.Location = new System.Drawing.Point(20, 138);
            this.gboxImponibile.Name = "gboxImponibile";
            this.gboxImponibile.Size = new System.Drawing.Size(475, 102);
            this.gboxImponibile.TabIndex = 46;
            this.gboxImponibile.TabStop = false;
            this.gboxImponibile.Text = "Impegno di Budget";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fase";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseImpBudget
            // 
            this.cmbFaseImpBudget.DataSource = this.DS.fase_epexp;
            this.cmbFaseImpBudget.DisplayMember = "descrizione";
            this.cmbFaseImpBudget.Location = new System.Drawing.Point(60, 31);
            this.cmbFaseImpBudget.Name = "cmbFaseImpBudget";
            this.cmbFaseImpBudget.Size = new System.Drawing.Size(189, 21);
            this.cmbFaseImpBudget.TabIndex = 9;
            this.cmbFaseImpBudget.Tag = "";
            this.cmbFaseImpBudget.ValueMember = "nphase";
            this.cmbFaseImpBudget.SelectedIndexChanged += new System.EventHandler(this.cmbFaseImpBudget_SelectedIndexChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(113, 61);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 13);
            this.label34.TabIndex = 7;
            this.label34.Text = "Numero";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 62);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "Esercizio";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLinkEpExp
            // 
            this.btnLinkEpExp.Location = new System.Drawing.Point(268, 55);
            this.btnLinkEpExp.Name = "btnLinkEpExp";
            this.btnLinkEpExp.Size = new System.Drawing.Size(89, 23);
            this.btnLinkEpExp.TabIndex = 5;
            this.btnLinkEpExp.TabStop = false;
            this.btnLinkEpExp.Text = "Collega";
            this.btnLinkEpExp.Click += new System.EventHandler(this.btnLinkEpExp_Click);
            // 
            // btnRemoveEpExp
            // 
            this.btnRemoveEpExp.Location = new System.Drawing.Point(367, 55);
            this.btnRemoveEpExp.Name = "btnRemoveEpExp";
            this.btnRemoveEpExp.Size = new System.Drawing.Size(95, 23);
            this.btnRemoveEpExp.TabIndex = 4;
            this.btnRemoveEpExp.TabStop = false;
            this.btnRemoveEpExp.Text = "Scollega";
            this.btnRemoveEpExp.Click += new System.EventHandler(this.btnRemoveEpExp_Click);
            // 
            // txtNumImpegno
            // 
            this.txtNumImpegno.Location = new System.Drawing.Point(163, 57);
            this.txtNumImpegno.Name = "txtNumImpegno";
            this.txtNumImpegno.Size = new System.Drawing.Size(64, 20);
            this.txtNumImpegno.TabIndex = 3;
            this.txtNumImpegno.TabStop = false;
            this.txtNumImpegno.Tag = "";
            this.txtNumImpegno.Leave += new System.EventHandler(this.txtNumImpegno_Leave);
            // 
            // txtEsercizioImpegno
            // 
            this.txtEsercizioImpegno.Location = new System.Drawing.Point(60, 58);
            this.txtEsercizioImpegno.Name = "txtEsercizioImpegno";
            this.txtEsercizioImpegno.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioImpegno.TabIndex = 2;
            this.txtEsercizioImpegno.TabStop = false;
            this.txtEsercizioImpegno.Tag = "";
            this.txtEsercizioImpegno.Leave += new System.EventHandler(this.txtEsercizioImpegno_Leave);
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button5);
            this.gboxConto.Location = new System.Drawing.Point(23, 25);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(400, 106);
            this.gboxConto.TabIndex = 5;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            this.gboxConto.Text = "Conto EP di Costo";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(256, 58);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "account.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(6, 80);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(386, 20);
            this.txtCodiceConto.TabIndex = 4;
            this.txtCodiceConto.Tag = "account.codeacc?x";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(10, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 23);
            this.button5.TabIndex = 1;
            this.button5.TabStop = false;
            this.button5.Tag = "manage.account.tree";
            this.button5.Text = "Conto";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(16, 70);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1051, 510);
            this.tabControl2.TabIndex = 13;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gboxRipartizioneUnica);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1043, 484);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Ripartizione Unica";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gboxRipartizioneUnica
            // 
            this.gboxRipartizioneUnica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxRipartizioneUnica.Controls.Add(this.button4);
            this.gboxRipartizioneUnica.Controls.Add(this.button6);
            this.gboxRipartizioneUnica.Controls.Add(this.button7);
            this.gboxRipartizioneUnica.Controls.Add(this.dataGrid3);
            this.gboxRipartizioneUnica.Location = new System.Drawing.Point(6, 21);
            this.gboxRipartizioneUnica.Name = "gboxRipartizioneUnica";
            this.gboxRipartizioneUnica.Size = new System.Drawing.Size(1021, 457);
            this.gboxRipartizioneUnica.TabIndex = 26;
            this.gboxRipartizioneUnica.TabStop = false;
            this.gboxRipartizioneUnica.Text = "Ripartizione unica";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(15, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 26);
            this.button4.TabIndex = 23;
            this.button4.Tag = "insert.detail";
            this.button4.Text = "Inserisci";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(15, 52);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(86, 26);
            this.button6.TabIndex = 25;
            this.button6.Tag = "edit.detail";
            this.button6.Text = "Modifica";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(15, 84);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(86, 26);
            this.button7.TabIndex = 26;
            this.button7.Tag = "delete";
            this.button7.Text = "Elimina";
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(107, 19);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(899, 434);
            this.dataGrid3.TabIndex = 24;
            this.dataGrid3.Tag = "csa_contracttax_partition.default.detail";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tabControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1043, 484);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Vecchia Configurazione";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Frm_csa_contracttax_default
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.CancButton;
            this.ClientSize = new System.Drawing.Size(1083, 621);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.txtEsercDoc);
            this.Controls.Add(this.labEsercizio);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancButton);
            this.Name = "Frm_csa_contracttax_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gboxSpesa.ResumeLayout(false);
            this.gboxSpesa.PerformLayout();
            this.grpBilancioVersamento.ResumeLayout(false);
            this.grpBilancioVersamento.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gboxclassSiope.ResumeLayout(false);
            this.gboxclassSiope.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.gboxImponibile.ResumeLayout(false);
            this.gboxImponibile.PerformLayout();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.gboxRipartizioneUnica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", esercizioCurr);

            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account, filter);
            GetData.SetStaticFilter(DS.expenseview, filter);
            GetData.SetSorting(DS.upb, "codeupb asc");
            DataAccess.SetTableForReading(DS.expenseview2, "expenseview");
            DataAccess.SetTableForReading(DS.expenseview3, "expenseview");

            DataAccess.SetTableForReading(DS.epexpview2, "epexpview");
            DataAccess.SetTableForReading(DS.epexpview3, "epexpview");
            DataAccess.SetTableForReading(DS.fin2, "fin");
            DataAccess.SetTableForReading(DS.upb2, "upb");
            DataAccess.SetTableForReading(DS.account2, "account");
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            GetData.SetStaticFilter(DS.fin2, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account2, filter);
            GetData.SetStaticFilter(DS.expenseview3, filter);
            GetData.SetStaticFilter(DS.epexpview3, filter);
            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                   QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))), "nphase", true);

            string filterSiope = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese"));

            DataTable tSortingkind = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiope, null, null, true);
            if ((tSortingkind != null) && (tSortingkind.Rows.Count > 0))
            {
                DataRow R = tSortingkind.Rows[0];
                object idsorkind = R["idsorkind"];
                object idsorkind_main = R["idsorkind"];
                SetGBoxClass(idsorkind);
            }
            Meta.MarkTableAsNotEntityChild(DS.csa_contracttaxexpense);
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);
            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            EnableFaseImpegnoBudget(2, "Impegno di Budget");
        }

        void SetGBoxClass(object sortingkind){
            if (sortingkind != DBNull.Value){
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.sorting, filter);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclassSiope.Text = title;
                gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.tree." + filter;
                btnCodiceSiope.Tag = "manage.sorting.tree." + filter;
            }
        }

         private void chkSpesa_CheckedChanged (object sender, System.EventArgs e) {
             chkSpesa_CheckedChanged(sender, e, true);
         }

         private void chkSpesa_CheckedChanged (object sender, System.EventArgs e, bool DispMessage) {
             if (chkSpesa.Checked) {
                 EnableDisable(false);
                 if (Meta.IsEmpty) return;
                 DataRow R = DS.csa_contracttax.Rows[0];
                 if ((R["idfin"] != DBNull.Value) ||
                     (R["idupb"] != DBNull.Value)) {

                     if (DispMessage) {
                         if (show("Per abilitare la selezione del movimento di spesa è necessario annullare le altre " +
                             "attribuzioni su questo contratto. Proseguo?", "Conferma",
                             MessageBoxButtons.OKCancel) != DialogResult.OK) {
                             chkSpesa.Checked = false;
                             return;
                         }
                     }
                     R["idfin"] = DBNull.Value;
                     R["idupb"] = DBNull.Value;
                     DS.fin.Clear();
                     txtBilancio.Text = "";
                     txtDescrBilancio.Text = "";
                     Meta.SetAutoField(DBNull.Value, txtUPB);
                     txtDescrUPB.Text = "";
                     return;
                 }
                 return;
             }
             if (Meta.IsEmpty) return;
             EnableDisable(true);

             DataRow RR = DS.csa_contracttax.Rows[0];

             if (RR["idexp"] != DBNull.Value) {
                 if (DispMessage) {
                     if (show("Per abilitare la selezione delle attribuzioni normali su questo contratto è necessario annullare il collegamento al movimento di spesa " +
                         ". Proseguo?", "Conferma",
                         MessageBoxButtons.OKCancel) != DialogResult.OK) {
                         chkSpesa.Checked = true;
                         return;
                     }
                 }
                 RR["idexp"] = DBNull.Value;
                 DS.expenseview.Clear();
                 cmbFaseSpesa.SelectedIndex = 0;
                 txtEserc.Text = "";
                 txtNum.Text = "";
             }
         }

         void EnableDisableParteSpesa (bool enable) {
             txtEserc.ReadOnly = !enable;
             txtNum.ReadOnly = !enable;
             cmbFaseSpesa.SelectedIndex = 0;
             cmbFaseSpesa.Enabled = enable;
             btnSpesa.Enabled = enable;
         }
         void EnableDisableParteNormale (bool enable) {
             btnBilancio.Enabled = enable;
             btnUPB.Enabled = enable;
             txtUPB.ReadOnly = !enable;
             txtBilancio.ReadOnly = !enable;
         }

         void EnableDisable (bool parteNormale) {
             EnableDisableParteNormale(parteNormale);
             EnableDisableParteSpesa(!parteNormale);
         }

        object Get_Registry_Auto () {
            if (Meta.IsEmpty) return DBNull.Value;
            object esercizio = Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
            if (t == null) return DBNull.Value;
            if (t.Rows.Count == 0) return DBNull.Value;
            DataRow rConfig = t.Rows[0];
            return rConfig["idregauto"];
        }

         private void btnSpesa_Click (object sender, EventArgs e) {
             if (Meta.IsEmpty) return;
             Meta.GetFormData(true);

             DataRow Curr = DS.csa_contracttax.Rows[0];
             string filter = "";
             object idregauto = Get_Registry_Auto();
         
             int selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
             if (selectedfase > 0) {
                 filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", selectedfase));//,
                          //QHS.DoPar(QHS.NullOrEq("idreg", idregauto)));
             }
             else {
                 filter = QHS.AppAnd(filter, QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                          QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))); //,
                          //QHS.DoPar(QHS.NullOrEq("idreg", idregauto)));
             }
           
             int ymov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
             int nmov = CfgFn.GetNoNullInt32(txtNum.Text.Trim());
             if ((ymov != 0) && (nmov != 0)) {
                 filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov));
             }
             else {
                 var f = new FrmAskInfo(Meta, "S", true).EnableManagerSelection(false);                 
                 if (f.ShowDialog() != DialogResult.OK) return;

                 if (ymov != 0) {
                     filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
                 }
                 if ((nmov != 0)) {
                     filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
                 }
                 string filterUpb = QHC.CmpEq("idupb", "0001");
                 string filterFin = "";
                 // Aggiunta filtro dell'UPB e del Bilancio
                 if (f.GetUPB()!=DBNull.Value) {                     
                         filterUpb = QHS.CmpEq("idupb", f.GetUPB());                     
                 }
                 if (f.GetFin()!=DBNull.Value) {
                     filterFin = QHS.CmpEq("idfin",f.GetFin());
                 }
                 filter = QHS.AppAnd(filter, filterUpb);
                 if (filterFin != "") {
                     filter = QHS.AppAnd(filter, filterFin);
                 }
             }

             MetaData E = Meta.Dispatcher.Get("expense");
             E.FilterLocked = true;
             E.DS = DS.Clone();
             DataRow Choosen = E.SelectOne("default", filter, "expense", null);
             if (Choosen == null) return;
             int oldIdExp = CfgFn.GetNoNullInt32(Curr["idexp"]);
             int newIdExp = CfgFn.GetNoNullInt32(Choosen["idexp"]);
             Curr["idexp"] = Choosen["idexp"];

             DS.expenseview.Clear();
             Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview, null,
                 QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
                 null, true);
             txtEserc.Text = Choosen["ymov"].ToString();
             txtNum.Text = Choosen["nmov"].ToString();
             cmbFaseSpesa.SelectedValue = Choosen["nphase"];
             Meta.FreshForm(false);
         }

         public void MetaData_AfterFill () {
             if (Meta.FirstFillForThisRow)
                 ImpostaCheckSpesa();
             if (!Meta.InsertMode) {
                 VisualizzaMovimentoSpesa();
                VisualizzaMovimentoBudget();
            }
            if (DS.epexp.Rows.Count > 0)
             {
                 object currtipo = DS.Tables["epexp"].Rows[0]["nphase"];
                 HelpForm.SetComboBoxValue(cmbFaseImpBudget, currtipo);
             }
         }

         public void MetaData_AfterClear () {
             ImpostaCheckSpesa();
             txtEserc.Text = "";
             txtNum.Text = "";
             cmbFaseSpesa.SelectedIndex = 0;
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            cmbFaseImpBudget.SelectedIndex = 0;
        }

         void ImpostaCheckSpesa () {
             if (Meta.IsEmpty) {
                 EnableDisable(true);
                 return;
             }
             DataRow R = DS.csa_contracttax.Rows[0];
             if (R["idexp"] != DBNull.Value)
                 chkSpesa.Checked = true;
             else
                 chkSpesa.Checked = false;
             chkSpesa_CheckedChanged(null, null, false);
         }


         private void VisualizzaMovimentoSpesa () {
             if (MetaData.Empty(this)) return;
             //Calcola e riempie i campi relativi alla fase precedente:
             object idexp = DS.Tables["csa_contracttax"].Rows[0]["idexp"];
             string filter = QHS.CmpEq("idexp", idexp);
             DataTable DT = Conn.RUN_SELECT("expense", "idexp,ymov,nmov,nphase", null, filter, null, true);
             if (DT.Rows.Count == 0) return;
             txtEserc.Text = DT.Rows[0]["ymov"].ToString();
             txtNum.Text = DT.Rows[0]["nmov"].ToString();
             cmbFaseSpesa.SelectedValue = DT.Rows[0]["nphase"];
         }

        private void VisualizzaMovimentoBudget() {
            if (MetaData.Empty(this)) return;
            object idepexp = DS.Tables["csa_contracttax"].Rows[0]["idepexp"];
            string filter = QHS.CmpEq("idepexp", idepexp);
            DataTable DT = Conn.RUN_SELECT("epexp", "idepexp, yepexp, nepexp, nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEsercizioImpegno.Text = DT.Rows[0]["yepexp"].ToString();
            txtNumImpegno.Text = DT.Rows[0]["nepexp"].ToString();
            cmbFaseImpBudget.SelectedValue = DT.Rows[0]["nphase"];
        }

        private void txtNum_Leave (object sender, EventArgs e) {
            if (Meta.formController.isClosing || Meta.destroyed) return;
             if (Meta.IsEmpty || DS.csa_contracttax.Rows.Count==0) return;
             if (txtNum.ReadOnly) return;
             DataRow Curr = DS.csa_contracttax.Rows[0];
             if ((Curr["idexp"] != DBNull.Value) && (txtNum.Text.Trim() == "")) {
                 DS.expenseview.Clear();
                 Curr["idexp"] = DBNull.Value;
             }
             btnSpesa_Click(sender, e);
         }

         private void txtEserc_Leave (object sender, EventArgs e) {
             HelpForm.FormatLikeYear(txtEserc);
            if (Meta.formController.isClosing || Meta.destroyed) return;
            if (Meta.IsEmpty || DS.csa_contracttax.Rows.Count == 0) return;
            DataRow Curr = DS.csa_contracttax.Rows[0];
             if (Curr["idexp"] != DBNull.Value) {
                 if (txtEserc.Text.Trim() == "") {
                     txtNum.Text = "";
                     DS.expenseview.Clear();
                     Curr["idexp"] = DBNull.Value;
                 }
                 else {
                     int oldYmov = 0;
                     if (DS.expenseview.Rows.Count > 0) {
                        oldYmov = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["ymov"]);;
                    }                    
                     int newYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
                     if (oldYmov != newYmov) {
                         txtNum.Text = "";
                         DS.expenseview.Clear();
                         Curr["idexp"] = DBNull.Value;
                     }
                 }

             }

         }

         private void cmbFaseSpesa_SelectedIndexChanged (object sender, EventArgs e) {
             if (Meta.IsEmpty) return;
             if (!Meta.DrawStateIsDone) return;
             DataRow Curr = DS.csa_contracttax.Rows[0];
             if (Curr["idexp"] != DBNull.Value) {
                 int oldNphase = 0;
                 if (DS.expenseview.Rows.Count > 0) {
                    oldNphase = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["nphase"]);
                }
                  
                 int newNPhase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
                 if (oldNphase != newNPhase) {
                     txtNum.Text = "";
                     txtEserc.Text = "";
                     DS.expenseview.Clear();
                     Curr["idexp"] = DBNull.Value;
                 }
             }
         }

         void EnableFaseImpegnoBudget(int nphase, string descrizione)
         {
             DataRow R = DS.fase_epexp.NewRow();
             R["nphase"] = nphase;
             R["descrizione"] = descrizione;
             DS.fase_epexp.Rows.Add(R);
             DS.fase_epexp.AcceptChanges();
         }
   
         private void btnLinkEpExp_Click(object sender, EventArgs e)
         {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.csa_contracttax.Rows[0];
            MetaData.GetFormData(this, true);
            EP_functions ep = new EP_functions(Meta.Dispatcher);

            object nphase = cmbFaseImpBudget.SelectedValue; // Impegno
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            int yepexp = CfgFn.GetNoNullInt32(txtEsercizioImpegno.Text.Trim());
            if (yepexp != 0) {
                filter = QHS.CmpEq("yepexp", yepexp);
            }
            else {
                filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            }
            int nepexp = CfgFn.GetNoNullInt32(txtNumImpegno.Text.Trim());
            if (nepexp != 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nepexp", nepexp));
            }
            string filter_fase = "";
             if (CfgFn.GetNoNullInt32(nphase) == 0) 
             {
                 filter_fase = QHS.AppOr(QHS.DoPar(QHS.CmpEq("nphase", 1)),
                                         QHS.DoPar(QHS.CmpEq("nphase", 2)));
             }
             if ((CfgFn.GetNoNullInt32(nphase) == 1)|| (CfgFn.GetNoNullInt32(nphase) == 2))
             {
                 filter_fase = QHS.CmpEq("nphase", nphase);
             }
             
             filter = QHS.AppAnd(filter, filter_fase);
  
             String fAmount = QHS.CmpGt("(isnull(totcurramount,0) - isnull(totalcost,0))", 0); // condizione sul disponibile
             filter = QHS.AppAnd(filter, fAmount);

            // Introduco un filtro su UPB E CONTO 
            object selectedUPB = curr["idupb"];
            object selectedAccount = curr["idacc"];

            var filterUpb = "";
            if (selectedUPB != DBNull.Value)

                filterUpb = QHC.CmpEq("idupb", selectedUPB);
            var filterAccount = "";
            if (selectedAccount != DBNull.Value)
                filterAccount = QHC.CmpEq("idacc", selectedAccount);

            filter = QHS.AppAnd(filter, filterUpb);
            if (filterAccount != "") {
                filter = QHS.AppAnd(filter, filterAccount);
            }
            string VistaScelta = "epexpview";

             MetaData mepexp = Meta.Dispatcher.Get(VistaScelta);
             mepexp.FilterLocked = true;
             mepexp.DS = DS;
             DataRow myDr = mepexp.SelectOne("default", filter, null, null);

             if (myDr != null)
             {
                curr["idepexp"] = myDr["idepexp"];
                curr["idacc"] = myDr["idacc"];
                curr["idupb"] = myDr["idupb"];
                Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", curr["idacc"]),
                 null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.upb, null,
                 QHS.CmpEq("idupb", curr["idupb"]),
                 null, true);
                txtEsercizioImpegno.Text = myDr["yepexp"].ToString();
                txtNumImpegno.Text = myDr["nepexp"].ToString();
                cmbFaseImpBudget.SelectedValue = myDr["nphase"];
                Meta.FreshForm();
             }
         }

         private void btnRemoveEpExp_Click(object sender, EventArgs e)
         {
             if (Meta.IsEmpty) return;
             DataRow Curr = DS.csa_contracttax.Rows[0];
             Curr["idepexp"] = DBNull.Value;
             DS.epexp.Clear();
             txtEsercizioImpegno.Text = "";
             txtNumImpegno.Text = "";
             cmbFaseImpBudget.SelectedIndex = -1;
             Meta.FreshForm();
         }

         private void cmbFaseImpBudget_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (Meta.IsEmpty) return;
             if (cmbFaseImpBudget.SelectedIndex <= 0)
             {
                 btnRemoveEpExp_Click(sender, e);
             }
         }

        private void txtEsercizioImpegno_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizioImpegno);
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_contracttax.Rows[0];
            if (Curr["idepexp"] != DBNull.Value) {
                if (txtEsercizioImpegno.Text.Trim() == "") {
                    txtNumImpegno.Text = "";
                    DS.epexpview2.Clear();
                    Curr["idepexp"] = DBNull.Value;
                }
                else {
                    int newYmov = CfgFn.GetNoNullInt32(txtEsercizioImpegno.Text.Trim());
                    int oldYmov = newYmov;
                    if (DS.epexpview2.Rows.Count > 0)
                        oldYmov = CfgFn.GetNoNullInt32(DS.epexpview2.Rows[0]["yepexp"]);
                    if (oldYmov != newYmov) {
                        txtNumImpegno.Text = "";
                        DS.epexpview2.Clear();
                        Curr["idepexp"] = DBNull.Value;
                    }
                }

            }
        }

        private void txtNumImpegno_Leave(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (txtNumImpegno.ReadOnly) return;
            DataRow Curr = DS.csa_contracttax.Rows[0];
            if ((Curr["idepexp"] != DBNull.Value) && (txtNumImpegno.Text.Trim() == "")) {
                DS.epexpview2.Clear();
                Curr["idepexp"] = DBNull.Value;
            }
            btnLinkEpExp_Click(sender, e);
        }
    }
}
