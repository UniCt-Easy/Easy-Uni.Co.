/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace sorting_default {//classmovimenti//
	/// <summary>
	/// Summary description for frmclassmovimenti.
	/// </summary>
	public class Frm_sorting_default : System.Windows.Forms.Form {
		public System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.Splitter splitter1;
		public System.Windows.Forms.TabControl MetaDataDetail;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbLivello;
		private System.Windows.Forms.TextBox txtDescrizione;
		public vistaForm DS;
		private System.Windows.Forms.Button btnSituazioneClassificazione;
		MetaData Meta;
        DataAccess Conn;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.TextBox SubEntity_txtPrevSpese;
		private System.Windows.Forms.TextBox SubEntity_txtPrevEntrate;
		private System.Windows.Forms.Label labPrevSpese;
		private System.Windows.Forms.Label labPrevEntrate;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox txtOrdineStampa;
        private System.Windows.Forms.Label lblOrdineStampa;
		private System.Windows.Forms.Button btnBudget;
		private System.Windows.Forms.GroupBox groupBox1;
        private GroupBox gboxManager;
        private ComboBox cmbResponsabile;
        private TextBox textBox2;
        private Label label5;
        private TextBox textBox1;
        private Label label1;
        private TabPage tabPage2;
        private TextBox textBox3;
        private Label label7;
        private Label label6;
        private TextBox textBox4;
        private Button btnSuddivisioni;
		string filteresercizio;
        private TabControl tabControl1;
        private TabPage tabPageLabels;
        public TextBox valoreV5;
        public TextBox valoreV4;
        public TextBox valoreV2;
        public TextBox valoreV1;
        public TextBox valoreV3;
        private Label labelV5;
        private Label labelV4;
        private Label labelV3;
        private Label labelV2;
        private Label labelV1;
        private Panel panel1;
        private Label labelignoradate;
        private CheckBox chkIgnoraDate;
        public TextBox valoreS5;
        public TextBox valoreN5;
        public TextBox valoreS4;
        public TextBox valoreN4;
        public TextBox valoreN2;
        public TextBox valoreS3;
        public TextBox valoreS2;
        public TextBox valoreN1;
        public TextBox valoreN3;
        public TextBox valoreS1;
        private Label labelS5;
        private Label labelS4;
        private Label labelS3;
        private Label labelS2;
        private Label labelS1;
        private Label labelN5;
        private Label labelN4;
        private Label labelN3;
        private Label labelN2;
        private Label labelN1;
        private TabPage tabPagePrevBudget;
        private GroupBox GrpboxPrevisione;
        private GroupBox groupBox4;
        private TextBox SubEntity_txtprevision5;
        private TextBox SubEntity_txtprevision4;
        private TextBox SubEntity_txtprevision3;
        private TextBox SubEntity_txtprevision2;
        private Label lblPrevisione5;
        private Label lblPrevisione4;
        private Label lblPrevisione3;
        private Label lblPrevisione2;
        private GroupBox gboxPrimaPrevisione;
        private TextBox SubEntity_txtprevesercizioprec;
        private Label lblEsPrecPrima;
        private TextBox SubEntity_txtpreveserciziocorr;
        private Label lblEsCorrentePrima;
        bool upbUnico = false;
        private TabPage tabPagePrevisioni;
        private TabPage tabPageRiepilogo;
        private DataGrid dgPrevisione;
        private Button btnInsPrevisione;
        private Button btnEditPrevisione;
        private Button btnDelPrevisione;
        private GroupBox groupBox2;
        private DataGrid dgVariazioni;
        private GroupBox grpPrevCompetenza;
        private Label label8;
        private Button btnVarPrev;
        private Label lblVarPrevCompetenza;
        private TextBox txtVarPrev;
        private Label lblPrevDispCompetenza;
        private TextBox txtPrevCorrente;
        private Button btnPrevIniziale;
        private Label lblPrevInizialeCompetenza;
        private TextBox txtPrevIniziale;
        private Button btnCalcolaTotali;
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
        bool accSortingKind = false;

		public Frm_sorting_default() {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_sorting_default));
            this.tree = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePrevBudget = new System.Windows.Forms.TabPage();
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
            this.btnBudget = new System.Windows.Forms.Button();
            this.tabPageLabels = new System.Windows.Forms.TabPage();
            this.valoreV5 = new System.Windows.Forms.TextBox();
            this.valoreV4 = new System.Windows.Forms.TextBox();
            this.valoreV2 = new System.Windows.Forms.TextBox();
            this.valoreV1 = new System.Windows.Forms.TextBox();
            this.valoreV3 = new System.Windows.Forms.TextBox();
            this.labelV5 = new System.Windows.Forms.Label();
            this.labelV4 = new System.Windows.Forms.Label();
            this.labelV3 = new System.Windows.Forms.Label();
            this.labelV2 = new System.Windows.Forms.Label();
            this.labelV1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelignoradate = new System.Windows.Forms.Label();
            this.chkIgnoraDate = new System.Windows.Forms.CheckBox();
            this.valoreS5 = new System.Windows.Forms.TextBox();
            this.valoreN5 = new System.Windows.Forms.TextBox();
            this.valoreS4 = new System.Windows.Forms.TextBox();
            this.valoreN4 = new System.Windows.Forms.TextBox();
            this.valoreN2 = new System.Windows.Forms.TextBox();
            this.valoreS3 = new System.Windows.Forms.TextBox();
            this.valoreS2 = new System.Windows.Forms.TextBox();
            this.valoreN1 = new System.Windows.Forms.TextBox();
            this.valoreN3 = new System.Windows.Forms.TextBox();
            this.valoreS1 = new System.Windows.Forms.TextBox();
            this.labelS5 = new System.Windows.Forms.Label();
            this.labelS4 = new System.Windows.Forms.Label();
            this.labelS3 = new System.Windows.Forms.Label();
            this.labelS2 = new System.Windows.Forms.Label();
            this.labelS1 = new System.Windows.Forms.Label();
            this.labelN5 = new System.Windows.Forms.Label();
            this.labelN4 = new System.Windows.Forms.Label();
            this.labelN3 = new System.Windows.Forms.Label();
            this.labelN2 = new System.Windows.Forms.Label();
            this.labelN1 = new System.Windows.Forms.Label();
            this.btnSuddivisioni = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxManager = new System.Windows.Forms.GroupBox();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.DS = new sorting_default.vistaForm();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtPrevSpese = new System.Windows.Forms.TextBox();
            this.labPrevSpese = new System.Windows.Forms.Label();
            this.SubEntity_txtPrevEntrate = new System.Windows.Forms.TextBox();
            this.labPrevEntrate = new System.Windows.Forms.Label();
            this.txtOrdineStampa = new System.Windows.Forms.TextBox();
            this.lblOrdineStampa = new System.Windows.Forms.Label();
            this.btnSituazioneClassificazione = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLivello = new System.Windows.Forms.ComboBox();
            this.tabPagePrevisioni = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgVariazioni = new System.Windows.Forms.DataGrid();
            this.btnInsPrevisione = new System.Windows.Forms.Button();
            this.btnEditPrevisione = new System.Windows.Forms.Button();
            this.btnDelPrevisione = new System.Windows.Forms.Button();
            this.dgPrevisione = new System.Windows.Forms.DataGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageRiepilogo = new System.Windows.Forms.TabPage();
            this.btnCalcolaTotali = new System.Windows.Forms.Button();
            this.grpPrevCompetenza = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnVarPrev = new System.Windows.Forms.Button();
            this.lblVarPrevCompetenza = new System.Windows.Forms.Label();
            this.txtVarPrev = new System.Windows.Forms.TextBox();
            this.lblPrevDispCompetenza = new System.Windows.Forms.Label();
            this.txtPrevCorrente = new System.Windows.Forms.TextBox();
            this.btnPrevIniziale = new System.Windows.Forms.Button();
            this.lblPrevInizialeCompetenza = new System.Windows.Forms.Label();
            this.txtPrevIniziale = new System.Windows.Forms.TextBox();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MetaDataDetail.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPagePrevBudget.SuspendLayout();
            this.GrpboxPrevisione.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gboxPrimaPrevisione.SuspendLayout();
            this.tabPageLabels.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gboxManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPagePrevisioni.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVariazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrevisione)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPageRiepilogo.SuspendLayout();
            this.grpPrevCompetenza.SuspendLayout();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Left;
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 1;
            this.tree.ImageList = this.icons;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowPlusMinus = false;
            this.tree.Size = new System.Drawing.Size(295, 583);
            this.tree.TabIndex = 0;
            this.tree.Tag = "sorting.tree";
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
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
            this.splitter1.Location = new System.Drawing.Point(295, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 583);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabPage1);
            this.MetaDataDetail.Controls.Add(this.tabPagePrevisioni);
            this.MetaDataDetail.Controls.Add(this.tabPage2);
            this.MetaDataDetail.Controls.Add(this.tabPageRiepilogo);
            this.MetaDataDetail.Controls.Add(this.tabAttributi);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.Location = new System.Drawing.Point(298, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(547, 583);
            this.MetaDataDetail.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl1);
            this.tabPage1.Controls.Add(this.btnSuddivisioni);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.gboxManager);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtOrdineStampa);
            this.tabPage1.Controls.Add(this.lblOrdineStampa);
            this.tabPage1.Controls.Add(this.btnSituazioneClassificazione);
            this.tabPage1.Controls.Add(this.txtDescrizione);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtCodice);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbLivello);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(539, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPagePrevBudget);
            this.tabControl1.Controls.Add(this.tabPageLabels);
            this.tabControl1.Location = new System.Drawing.Point(23, 264);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 297);
            this.tabControl1.TabIndex = 228;
            // 
            // tabPagePrevBudget
            // 
            this.tabPagePrevBudget.Controls.Add(this.GrpboxPrevisione);
            this.tabPagePrevBudget.Controls.Add(this.btnBudget);
            this.tabPagePrevBudget.Location = new System.Drawing.Point(4, 22);
            this.tabPagePrevBudget.Name = "tabPagePrevBudget";
            this.tabPagePrevBudget.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrevBudget.Size = new System.Drawing.Size(525, 271);
            this.tabPagePrevBudget.TabIndex = 1;
            this.tabPagePrevBudget.Text = "Budget";
            this.tabPagePrevBudget.UseVisualStyleBackColor = true;
            // 
            // GrpboxPrevisione
            // 
            this.GrpboxPrevisione.Controls.Add(this.groupBox4);
            this.GrpboxPrevisione.Controls.Add(this.gboxPrimaPrevisione);
            this.GrpboxPrevisione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpboxPrevisione.Location = new System.Drawing.Point(8, 12);
            this.GrpboxPrevisione.Name = "GrpboxPrevisione";
            this.GrpboxPrevisione.Size = new System.Drawing.Size(480, 228);
            this.GrpboxPrevisione.TabIndex = 221;
            this.GrpboxPrevisione.TabStop = false;
            this.GrpboxPrevisione.Text = " ";
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
            this.groupBox4.Location = new System.Drawing.Point(10, 58);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(464, 72);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Budget Esercizi Futuri";
            // 
            // SubEntity_txtprevision5
            // 
            this.SubEntity_txtprevision5.Location = new System.Drawing.Point(344, 48);
            this.SubEntity_txtprevision5.Name = "SubEntity_txtprevision5";
            this.SubEntity_txtprevision5.ReadOnly = true;
            this.SubEntity_txtprevision5.Size = new System.Drawing.Size(104, 20);
            this.SubEntity_txtprevision5.TabIndex = 7;
            this.SubEntity_txtprevision5.Tag = "";
            this.SubEntity_txtprevision5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SubEntity_txtprevision4
            // 
            this.SubEntity_txtprevision4.Location = new System.Drawing.Point(112, 48);
            this.SubEntity_txtprevision4.Name = "SubEntity_txtprevision4";
            this.SubEntity_txtprevision4.ReadOnly = true;
            this.SubEntity_txtprevision4.Size = new System.Drawing.Size(112, 20);
            this.SubEntity_txtprevision4.TabIndex = 6;
            this.SubEntity_txtprevision4.Tag = "";
            this.SubEntity_txtprevision4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SubEntity_txtprevision3
            // 
            this.SubEntity_txtprevision3.Location = new System.Drawing.Point(344, 16);
            this.SubEntity_txtprevision3.Name = "SubEntity_txtprevision3";
            this.SubEntity_txtprevision3.ReadOnly = true;
            this.SubEntity_txtprevision3.Size = new System.Drawing.Size(104, 20);
            this.SubEntity_txtprevision3.TabIndex = 5;
            this.SubEntity_txtprevision3.Tag = "";
            this.SubEntity_txtprevision3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SubEntity_txtprevision2
            // 
            this.SubEntity_txtprevision2.Location = new System.Drawing.Point(112, 16);
            this.SubEntity_txtprevision2.Name = "SubEntity_txtprevision2";
            this.SubEntity_txtprevision2.ReadOnly = true;
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
            this.gboxPrimaPrevisione.Size = new System.Drawing.Size(464, 40);
            this.gboxPrimaPrevisione.TabIndex = 1;
            this.gboxPrimaPrevisione.TabStop = false;
            this.gboxPrimaPrevisione.Text = "Budget di competenza";
            // 
            // SubEntity_txtprevesercizioprec
            // 
            this.SubEntity_txtprevesercizioprec.Location = new System.Drawing.Point(344, 16);
            this.SubEntity_txtprevesercizioprec.Name = "SubEntity_txtprevesercizioprec";
            this.SubEntity_txtprevesercizioprec.ReadOnly = true;
            this.SubEntity_txtprevesercizioprec.Size = new System.Drawing.Size(104, 20);
            this.SubEntity_txtprevesercizioprec.TabIndex = 2;
            this.SubEntity_txtprevesercizioprec.Tag = "";
            this.SubEntity_txtprevesercizioprec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEsPrecPrima
            // 
            this.lblEsPrecPrima.Location = new System.Drawing.Point(240, 16);
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
            this.SubEntity_txtpreveserciziocorr.ReadOnly = true;
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
            // btnBudget
            // 
            this.btnBudget.Location = new System.Drawing.Point(314, 246);
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.Size = new System.Drawing.Size(176, 23);
            this.btnBudget.TabIndex = 220;
            this.btnBudget.Text = "Budget Economico Patrimoniale";
            this.btnBudget.Click += new System.EventHandler(this.btnBudget_Click);
            // 
            // tabPageLabels
            // 
            this.tabPageLabels.Controls.Add(this.valoreV5);
            this.tabPageLabels.Controls.Add(this.valoreV4);
            this.tabPageLabels.Controls.Add(this.valoreV2);
            this.tabPageLabels.Controls.Add(this.valoreV1);
            this.tabPageLabels.Controls.Add(this.valoreV3);
            this.tabPageLabels.Controls.Add(this.labelV5);
            this.tabPageLabels.Controls.Add(this.labelV4);
            this.tabPageLabels.Controls.Add(this.labelV3);
            this.tabPageLabels.Controls.Add(this.labelV2);
            this.tabPageLabels.Controls.Add(this.labelV1);
            this.tabPageLabels.Controls.Add(this.panel1);
            this.tabPageLabels.Controls.Add(this.valoreS5);
            this.tabPageLabels.Controls.Add(this.valoreN5);
            this.tabPageLabels.Controls.Add(this.valoreS4);
            this.tabPageLabels.Controls.Add(this.valoreN4);
            this.tabPageLabels.Controls.Add(this.valoreN2);
            this.tabPageLabels.Controls.Add(this.valoreS3);
            this.tabPageLabels.Controls.Add(this.valoreS2);
            this.tabPageLabels.Controls.Add(this.valoreN1);
            this.tabPageLabels.Controls.Add(this.valoreN3);
            this.tabPageLabels.Controls.Add(this.valoreS1);
            this.tabPageLabels.Controls.Add(this.labelS5);
            this.tabPageLabels.Controls.Add(this.labelS4);
            this.tabPageLabels.Controls.Add(this.labelS3);
            this.tabPageLabels.Controls.Add(this.labelS2);
            this.tabPageLabels.Controls.Add(this.labelS1);
            this.tabPageLabels.Controls.Add(this.labelN5);
            this.tabPageLabels.Controls.Add(this.labelN4);
            this.tabPageLabels.Controls.Add(this.labelN3);
            this.tabPageLabels.Controls.Add(this.labelN2);
            this.tabPageLabels.Controls.Add(this.labelN1);
            this.tabPageLabels.Location = new System.Drawing.Point(4, 22);
            this.tabPageLabels.Name = "tabPageLabels";
            this.tabPageLabels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLabels.Size = new System.Drawing.Size(525, 271);
            this.tabPageLabels.TabIndex = 0;
            this.tabPageLabels.Text = "Etichette aggiuntive";
            this.tabPageLabels.UseVisualStyleBackColor = true;
            // 
            // valoreV5
            // 
            this.valoreV5.Location = new System.Drawing.Point(347, 183);
            this.valoreV5.Name = "valoreV5";
            this.valoreV5.Size = new System.Drawing.Size(144, 20);
            this.valoreV5.TabIndex = 234;
            this.valoreV5.Tag = "sorting.defaultv5.N";
            // 
            // valoreV4
            // 
            this.valoreV4.Location = new System.Drawing.Point(347, 143);
            this.valoreV4.Name = "valoreV4";
            this.valoreV4.Size = new System.Drawing.Size(144, 20);
            this.valoreV4.TabIndex = 233;
            this.valoreV4.Tag = "sorting.defaultv4.N";
            // 
            // valoreV2
            // 
            this.valoreV2.Location = new System.Drawing.Point(347, 63);
            this.valoreV2.Name = "valoreV2";
            this.valoreV2.Size = new System.Drawing.Size(144, 20);
            this.valoreV2.TabIndex = 231;
            this.valoreV2.Tag = "sorting.defaultv2.N";
            // 
            // valoreV1
            // 
            this.valoreV1.Location = new System.Drawing.Point(347, 23);
            this.valoreV1.Name = "valoreV1";
            this.valoreV1.Size = new System.Drawing.Size(144, 20);
            this.valoreV1.TabIndex = 230;
            this.valoreV1.Tag = "sorting.defaultv1.N";
            // 
            // valoreV3
            // 
            this.valoreV3.Location = new System.Drawing.Point(347, 103);
            this.valoreV3.Name = "valoreV3";
            this.valoreV3.Size = new System.Drawing.Size(144, 20);
            this.valoreV3.TabIndex = 232;
            this.valoreV3.Tag = "sorting.defaultv3.N";
            // 
            // labelV5
            // 
            this.labelV5.Location = new System.Drawing.Point(347, 167);
            this.labelV5.Name = "labelV5";
            this.labelV5.Size = new System.Drawing.Size(144, 16);
            this.labelV5.TabIndex = 250;
            this.labelV5.Tag = "sortingkind.labelv5";
            // 
            // labelV4
            // 
            this.labelV4.Location = new System.Drawing.Point(347, 127);
            this.labelV4.Name = "labelV4";
            this.labelV4.Size = new System.Drawing.Size(144, 16);
            this.labelV4.TabIndex = 249;
            this.labelV4.Tag = "sortingkind.labelv4";
            // 
            // labelV3
            // 
            this.labelV3.Location = new System.Drawing.Point(347, 87);
            this.labelV3.Name = "labelV3";
            this.labelV3.Size = new System.Drawing.Size(144, 16);
            this.labelV3.TabIndex = 248;
            this.labelV3.Tag = "sortingkind.labelv3";
            // 
            // labelV2
            // 
            this.labelV2.Location = new System.Drawing.Point(347, 47);
            this.labelV2.Name = "labelV2";
            this.labelV2.Size = new System.Drawing.Size(144, 16);
            this.labelV2.TabIndex = 247;
            this.labelV2.Tag = "sortingkind.labelv2";
            // 
            // labelV1
            // 
            this.labelV1.Location = new System.Drawing.Point(347, 7);
            this.labelV1.Name = "labelV1";
            this.labelV1.Size = new System.Drawing.Size(144, 16);
            this.labelV1.TabIndex = 246;
            this.labelV1.Tag = "sortingkind.labelv1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelignoradate);
            this.panel1.Controls.Add(this.chkIgnoraDate);
            this.panel1.Location = new System.Drawing.Point(6, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 40);
            this.panel1.TabIndex = 245;
            // 
            // labelignoradate
            // 
            this.labelignoradate.Location = new System.Drawing.Point(38, 17);
            this.labelignoradate.Name = "labelignoradate";
            this.labelignoradate.Size = new System.Drawing.Size(118, 16);
            this.labelignoradate.TabIndex = 1;
            this.labelignoradate.Tag = "sortingkind.nodatelabel";
            this.labelignoradate.Text = "ignora date custom";
            // 
            // chkIgnoraDate
            // 
            this.chkIgnoraDate.Location = new System.Drawing.Point(12, 16);
            this.chkIgnoraDate.Name = "chkIgnoraDate";
            this.chkIgnoraDate.Size = new System.Drawing.Size(20, 16);
            this.chkIgnoraDate.TabIndex = 23;
            this.chkIgnoraDate.Tag = "sorting.flagnodate:S:N";
            // 
            // valoreS5
            // 
            this.valoreS5.Location = new System.Drawing.Point(179, 183);
            this.valoreS5.Name = "valoreS5";
            this.valoreS5.Size = new System.Drawing.Size(144, 20);
            this.valoreS5.TabIndex = 229;
            this.valoreS5.Tag = "sorting.defaults5";
            // 
            // valoreN5
            // 
            this.valoreN5.Location = new System.Drawing.Point(11, 183);
            this.valoreN5.Name = "valoreN5";
            this.valoreN5.Size = new System.Drawing.Size(144, 20);
            this.valoreN5.TabIndex = 224;
            this.valoreN5.Tag = "sorting.defaultn5";
            // 
            // valoreS4
            // 
            this.valoreS4.Location = new System.Drawing.Point(179, 143);
            this.valoreS4.Name = "valoreS4";
            this.valoreS4.Size = new System.Drawing.Size(144, 20);
            this.valoreS4.TabIndex = 228;
            this.valoreS4.Tag = "sorting.defaults4";
            // 
            // valoreN4
            // 
            this.valoreN4.Location = new System.Drawing.Point(11, 143);
            this.valoreN4.Name = "valoreN4";
            this.valoreN4.Size = new System.Drawing.Size(144, 20);
            this.valoreN4.TabIndex = 223;
            this.valoreN4.Tag = "sorting.defaultn4";
            // 
            // valoreN2
            // 
            this.valoreN2.Location = new System.Drawing.Point(11, 63);
            this.valoreN2.Name = "valoreN2";
            this.valoreN2.Size = new System.Drawing.Size(144, 20);
            this.valoreN2.TabIndex = 221;
            this.valoreN2.Tag = "sorting.defaultn2";
            // 
            // valoreS3
            // 
            this.valoreS3.Location = new System.Drawing.Point(179, 103);
            this.valoreS3.Name = "valoreS3";
            this.valoreS3.Size = new System.Drawing.Size(144, 20);
            this.valoreS3.TabIndex = 227;
            this.valoreS3.Tag = "sorting.defaults3";
            // 
            // valoreS2
            // 
            this.valoreS2.Location = new System.Drawing.Point(179, 63);
            this.valoreS2.Name = "valoreS2";
            this.valoreS2.Size = new System.Drawing.Size(144, 20);
            this.valoreS2.TabIndex = 226;
            this.valoreS2.Tag = "sorting.defaults2";
            // 
            // valoreN1
            // 
            this.valoreN1.Location = new System.Drawing.Point(11, 23);
            this.valoreN1.Name = "valoreN1";
            this.valoreN1.Size = new System.Drawing.Size(144, 20);
            this.valoreN1.TabIndex = 220;
            this.valoreN1.Tag = "sorting.defaultn1";
            // 
            // valoreN3
            // 
            this.valoreN3.Location = new System.Drawing.Point(11, 103);
            this.valoreN3.Name = "valoreN3";
            this.valoreN3.Size = new System.Drawing.Size(144, 20);
            this.valoreN3.TabIndex = 222;
            this.valoreN3.Tag = "sorting.defaultn3";
            // 
            // valoreS1
            // 
            this.valoreS1.Location = new System.Drawing.Point(179, 23);
            this.valoreS1.Name = "valoreS1";
            this.valoreS1.Size = new System.Drawing.Size(144, 20);
            this.valoreS1.TabIndex = 225;
            this.valoreS1.Tag = "sorting.defaults1";
            // 
            // labelS5
            // 
            this.labelS5.Location = new System.Drawing.Point(179, 167);
            this.labelS5.Name = "labelS5";
            this.labelS5.Size = new System.Drawing.Size(144, 16);
            this.labelS5.TabIndex = 244;
            this.labelS5.Tag = "sortingkind.labels5";
            // 
            // labelS4
            // 
            this.labelS4.Location = new System.Drawing.Point(179, 127);
            this.labelS4.Name = "labelS4";
            this.labelS4.Size = new System.Drawing.Size(144, 16);
            this.labelS4.TabIndex = 243;
            this.labelS4.Tag = "sortingkind.labels4";
            // 
            // labelS3
            // 
            this.labelS3.Location = new System.Drawing.Point(179, 87);
            this.labelS3.Name = "labelS3";
            this.labelS3.Size = new System.Drawing.Size(144, 16);
            this.labelS3.TabIndex = 242;
            this.labelS3.Tag = "sortingkind.labels3";
            // 
            // labelS2
            // 
            this.labelS2.Location = new System.Drawing.Point(179, 47);
            this.labelS2.Name = "labelS2";
            this.labelS2.Size = new System.Drawing.Size(144, 16);
            this.labelS2.TabIndex = 241;
            this.labelS2.Tag = "sortingkind.labels2";
            // 
            // labelS1
            // 
            this.labelS1.Location = new System.Drawing.Point(179, 7);
            this.labelS1.Name = "labelS1";
            this.labelS1.Size = new System.Drawing.Size(144, 16);
            this.labelS1.TabIndex = 240;
            this.labelS1.Tag = "sortingkind.labels1";
            // 
            // labelN5
            // 
            this.labelN5.Location = new System.Drawing.Point(11, 167);
            this.labelN5.Name = "labelN5";
            this.labelN5.Size = new System.Drawing.Size(144, 16);
            this.labelN5.TabIndex = 239;
            this.labelN5.Tag = "sortingkind.labeln5";
            // 
            // labelN4
            // 
            this.labelN4.Location = new System.Drawing.Point(11, 127);
            this.labelN4.Name = "labelN4";
            this.labelN4.Size = new System.Drawing.Size(144, 16);
            this.labelN4.TabIndex = 238;
            this.labelN4.Tag = "sortingkind.labeln4";
            // 
            // labelN3
            // 
            this.labelN3.Location = new System.Drawing.Point(11, 87);
            this.labelN3.Name = "labelN3";
            this.labelN3.Size = new System.Drawing.Size(144, 16);
            this.labelN3.TabIndex = 237;
            this.labelN3.Tag = "sortingkind.labeln3";
            // 
            // labelN2
            // 
            this.labelN2.Location = new System.Drawing.Point(11, 47);
            this.labelN2.Name = "labelN2";
            this.labelN2.Size = new System.Drawing.Size(144, 16);
            this.labelN2.TabIndex = 236;
            this.labelN2.Tag = "sortingkind.labeln2";
            // 
            // labelN1
            // 
            this.labelN1.Location = new System.Drawing.Point(11, 7);
            this.labelN1.Name = "labelN1";
            this.labelN1.Size = new System.Drawing.Size(144, 16);
            this.labelN1.TabIndex = 235;
            this.labelN1.Tag = "sortingkind.labeln1";
            // 
            // btnSuddivisioni
            // 
            this.btnSuddivisioni.Location = new System.Drawing.Point(349, 228);
            this.btnSuddivisioni.Name = "btnSuddivisioni";
            this.btnSuddivisioni.Size = new System.Drawing.Size(144, 23);
            this.btnSuddivisioni.TabIndex = 227;
            this.btnSuddivisioni.TabStop = false;
            this.btnSuddivisioni.Text = "Visualizza le suddivisioni";
            this.btnSuddivisioni.Click += new System.EventHandler(this.btnSuddivisioni_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(230, 211);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(66, 20);
            this.textBox2.TabIndex = 25;
            this.textBox2.Tag = "sorting.stop.year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 225;
            this.label5.Text = "Anno fine";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 211);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 20);
            this.textBox1.TabIndex = 24;
            this.textBox1.Tag = "sorting.start.year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 223;
            this.label1.Text = "Anno inizio";
            // 
            // gboxManager
            // 
            this.gboxManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxManager.Controls.Add(this.cmbResponsabile);
            this.gboxManager.Location = new System.Drawing.Point(16, 162);
            this.gboxManager.Name = "gboxManager";
            this.gboxManager.Size = new System.Drawing.Size(436, 40);
            this.gboxManager.TabIndex = 6;
            this.gboxManager.TabStop = false;
            this.gboxManager.Text = "Responsabile";
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResponsabile.DataSource = this.DS.manager;
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.ItemHeight = 13;
            this.cmbResponsabile.Location = new System.Drawing.Point(8, 14);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(420, 21);
            this.cmbResponsabile.TabIndex = 1;
            this.cmbResponsabile.Tag = "managersorting.idman?sortingyearview.idman";
            this.cmbResponsabile.ValueMember = "idman";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SubEntity_txtPrevSpese);
            this.groupBox1.Controls.Add(this.labPrevSpese);
            this.groupBox1.Controls.Add(this.SubEntity_txtPrevEntrate);
            this.groupBox1.Controls.Add(this.labPrevEntrate);
            this.groupBox1.Location = new System.Drawing.Point(16, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 48);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Budget";
            // 
            // SubEntity_txtPrevSpese
            // 
            this.SubEntity_txtPrevSpese.Location = new System.Drawing.Point(280, 16);
            this.SubEntity_txtPrevSpese.Name = "SubEntity_txtPrevSpese";
            this.SubEntity_txtPrevSpese.Size = new System.Drawing.Size(112, 20);
            this.SubEntity_txtPrevSpese.TabIndex = 6;
            this.SubEntity_txtPrevSpese.Tag = "sortingprev.expenseprevision";
            // 
            // labPrevSpese
            // 
            this.labPrevSpese.Location = new System.Drawing.Point(208, 16);
            this.labPrevSpese.Name = "labPrevSpese";
            this.labPrevSpese.Size = new System.Drawing.Size(72, 24);
            this.labPrevSpese.TabIndex = 14;
            this.labPrevSpese.Text = "Costi previsti:";
            this.labPrevSpese.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SubEntity_txtPrevEntrate
            // 
            this.SubEntity_txtPrevEntrate.Location = new System.Drawing.Point(96, 16);
            this.SubEntity_txtPrevEntrate.Name = "SubEntity_txtPrevEntrate";
            this.SubEntity_txtPrevEntrate.Size = new System.Drawing.Size(112, 20);
            this.SubEntity_txtPrevEntrate.TabIndex = 5;
            this.SubEntity_txtPrevEntrate.Tag = "sortingprev.incomeprevision";
            // 
            // labPrevEntrate
            // 
            this.labPrevEntrate.Location = new System.Drawing.Point(4, 16);
            this.labPrevEntrate.Name = "labPrevEntrate";
            this.labPrevEntrate.Size = new System.Drawing.Size(84, 24);
            this.labPrevEntrate.TabIndex = 8;
            this.labPrevEntrate.Text = "Ricavi previsti:";
            this.labPrevEntrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrdineStampa
            // 
            this.txtOrdineStampa.Location = new System.Drawing.Point(96, 32);
            this.txtOrdineStampa.Name = "txtOrdineStampa";
            this.txtOrdineStampa.Size = new System.Drawing.Size(128, 20);
            this.txtOrdineStampa.TabIndex = 3;
            this.txtOrdineStampa.Tag = "sorting.printingorder";
            // 
            // lblOrdineStampa
            // 
            this.lblOrdineStampa.Location = new System.Drawing.Point(8, 32);
            this.lblOrdineStampa.Name = "lblOrdineStampa";
            this.lblOrdineStampa.Size = new System.Drawing.Size(88, 24);
            this.lblOrdineStampa.TabIndex = 211;
            this.lblOrdineStampa.Text = "Ordine stampa";
            this.lblOrdineStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSituazioneClassificazione
            // 
            this.btnSituazioneClassificazione.Location = new System.Drawing.Point(424, 112);
            this.btnSituazioneClassificazione.Name = "btnSituazioneClassificazione";
            this.btnSituazioneClassificazione.Size = new System.Drawing.Size(72, 23);
            this.btnSituazioneClassificazione.TabIndex = 7;
            this.btnSituazioneClassificazione.TabStop = false;
            this.btnSituazioneClassificazione.Text = "Situazione";
            this.btnSituazioneClassificazione.Click += new System.EventHandler(this.btnSituazioneClassificazione_Click);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(96, 56);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(320, 56);
            this.txtDescrizione.TabIndex = 4;
            this.txtDescrizione.Tag = "sorting.description";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descrizione:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(288, 8);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(128, 20);
            this.txtCodice.TabIndex = 2;
            this.txtCodice.Tag = "sorting.sortcode";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(232, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Codice:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Livello Class.:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbLivello
            // 
            this.cmbLivello.DataSource = this.DS.sortinglevel;
            this.cmbLivello.DisplayMember = "description";
            this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivello.Enabled = false;
            this.cmbLivello.Location = new System.Drawing.Point(96, 8);
            this.cmbLivello.Name = "cmbLivello";
            this.cmbLivello.Size = new System.Drawing.Size(128, 21);
            this.cmbLivello.TabIndex = 1;
            this.cmbLivello.Tag = "sorting.nlevel";
            this.cmbLivello.ValueMember = "nlevel";
            // 
            // tabPagePrevisioni
            // 
            this.tabPagePrevisioni.Controls.Add(this.groupBox2);
            this.tabPagePrevisioni.Controls.Add(this.btnInsPrevisione);
            this.tabPagePrevisioni.Controls.Add(this.btnEditPrevisione);
            this.tabPagePrevisioni.Controls.Add(this.btnDelPrevisione);
            this.tabPagePrevisioni.Controls.Add(this.dgPrevisione);
            this.tabPagePrevisioni.Location = new System.Drawing.Point(4, 22);
            this.tabPagePrevisioni.Name = "tabPagePrevisioni";
            this.tabPagePrevisioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrevisioni.Size = new System.Drawing.Size(539, 557);
            this.tabPagePrevisioni.TabIndex = 2;
            this.tabPagePrevisioni.Text = "Budget";
            this.tabPagePrevisioni.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgVariazioni);
            this.groupBox2.Location = new System.Drawing.Point(14, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 227);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Variazioni Budget";
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
            this.dgVariazioni.Size = new System.Drawing.Size(505, 198);
            this.dgVariazioni.TabIndex = 20;
            this.dgVariazioni.Tag = "budgetvardetailview.classificazione";
            // 
            // btnInsPrevisione
            // 
            this.btnInsPrevisione.Location = new System.Drawing.Point(14, 6);
            this.btnInsPrevisione.Name = "btnInsPrevisione";
            this.btnInsPrevisione.Size = new System.Drawing.Size(86, 26);
            this.btnInsPrevisione.TabIndex = 20;
            this.btnInsPrevisione.Tag = "insert.previsionupb";
            this.btnInsPrevisione.Text = "Inserisci";
            // 
            // btnEditPrevisione
            // 
            this.btnEditPrevisione.Location = new System.Drawing.Point(14, 38);
            this.btnEditPrevisione.Name = "btnEditPrevisione";
            this.btnEditPrevisione.Size = new System.Drawing.Size(86, 26);
            this.btnEditPrevisione.TabIndex = 21;
            this.btnEditPrevisione.Tag = "edit.previsionupb";
            this.btnEditPrevisione.Text = "Modifica";
            // 
            // btnDelPrevisione
            // 
            this.btnDelPrevisione.Location = new System.Drawing.Point(14, 70);
            this.btnDelPrevisione.Name = "btnDelPrevisione";
            this.btnDelPrevisione.Size = new System.Drawing.Size(86, 26);
            this.btnDelPrevisione.TabIndex = 22;
            this.btnDelPrevisione.Tag = "delete";
            this.btnDelPrevisione.Text = "Elimina";
            // 
            // dgPrevisione
            // 
            this.dgPrevisione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPrevisione.DataMember = "";
            this.dgPrevisione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPrevisione.Location = new System.Drawing.Point(111, 6);
            this.dgPrevisione.Name = "dgPrevisione";
            this.dgPrevisione.Size = new System.Drawing.Size(420, 312);
            this.dgPrevisione.TabIndex = 19;
            this.dgPrevisione.Tag = "budgetprevisionview.previsionupb.previsionupb";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(539, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Organigramma";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(3, 130);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(494, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Tag = "sorting.email";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(3, 6);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(528, 60);
            this.textBox3.TabIndex = 2;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Le informazioni in questa pagina sono usate nel caso in cui questa classificazion" +
    "e Ë usata come attributo per la gestione della sicurezza.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(2, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(523, 39);
            this.label6.TabIndex = 0;
            this.label6.Text = "Indirizzo email per la notifica di richieste ordine, variazioni bilancio e missio" +
    "ni e magazzino ove siano assenti altre email specifiche";
            // 
            // tabPageRiepilogo
            // 
            this.tabPageRiepilogo.Controls.Add(this.btnCalcolaTotali);
            this.tabPageRiepilogo.Controls.Add(this.grpPrevCompetenza);
            this.tabPageRiepilogo.Location = new System.Drawing.Point(4, 22);
            this.tabPageRiepilogo.Name = "tabPageRiepilogo";
            this.tabPageRiepilogo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRiepilogo.Size = new System.Drawing.Size(539, 557);
            this.tabPageRiepilogo.TabIndex = 3;
            this.tabPageRiepilogo.Text = "Riepilogo";
            this.tabPageRiepilogo.UseVisualStyleBackColor = true;
            // 
            // btnCalcolaTotali
            // 
            this.btnCalcolaTotali.Location = new System.Drawing.Point(22, 16);
            this.btnCalcolaTotali.Name = "btnCalcolaTotali";
            this.btnCalcolaTotali.Size = new System.Drawing.Size(105, 25);
            this.btnCalcolaTotali.TabIndex = 58;
            this.btnCalcolaTotali.Text = "Calcola totali";
            this.btnCalcolaTotali.UseVisualStyleBackColor = true;
            this.btnCalcolaTotali.Click += new System.EventHandler(this.btnCalcolaTotali_Click);
            // 
            // grpPrevCompetenza
            // 
            this.grpPrevCompetenza.Controls.Add(this.label8);
            this.grpPrevCompetenza.Controls.Add(this.btnVarPrev);
            this.grpPrevCompetenza.Controls.Add(this.lblVarPrevCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.txtVarPrev);
            this.grpPrevCompetenza.Controls.Add(this.lblPrevDispCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.txtPrevCorrente);
            this.grpPrevCompetenza.Controls.Add(this.btnPrevIniziale);
            this.grpPrevCompetenza.Controls.Add(this.lblPrevInizialeCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.txtPrevIniziale);
            this.grpPrevCompetenza.Location = new System.Drawing.Point(22, 47);
            this.grpPrevCompetenza.Name = "grpPrevCompetenza";
            this.grpPrevCompetenza.Size = new System.Drawing.Size(499, 103);
            this.grpPrevCompetenza.TabIndex = 57;
            this.grpPrevCompetenza.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(301, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "C = A + B ";
            // 
            // btnVarPrev
            // 
            this.btnVarPrev.Location = new System.Drawing.Point(301, 45);
            this.btnVarPrev.Name = "btnVarPrev";
            this.btnVarPrev.Size = new System.Drawing.Size(75, 20);
            this.btnVarPrev.TabIndex = 3;
            this.btnVarPrev.Text = "B";
            this.btnVarPrev.UseVisualStyleBackColor = true;
            this.btnVarPrev.Click += new System.EventHandler(this.btnVarPrev_Click);
            // 
            // lblVarPrevCompetenza
            // 
            this.lblVarPrevCompetenza.Location = new System.Drawing.Point(16, 45);
            this.lblVarPrevCompetenza.Name = "lblVarPrevCompetenza";
            this.lblVarPrevCompetenza.Size = new System.Drawing.Size(130, 13);
            this.lblVarPrevCompetenza.TabIndex = 0;
            this.lblVarPrevCompetenza.Text = "Variazioni di Budget";
            this.lblVarPrevCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarPrev
            // 
            this.txtVarPrev.Location = new System.Drawing.Point(152, 44);
            this.txtVarPrev.Name = "txtVarPrev";
            this.txtVarPrev.ReadOnly = true;
            this.txtVarPrev.Size = new System.Drawing.Size(121, 20);
            this.txtVarPrev.TabIndex = 2;
            this.txtVarPrev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrevDispCompetenza
            // 
            this.lblPrevDispCompetenza.Location = new System.Drawing.Point(16, 71);
            this.lblPrevDispCompetenza.Name = "lblPrevDispCompetenza";
            this.lblPrevDispCompetenza.Size = new System.Drawing.Size(130, 13);
            this.lblPrevDispCompetenza.TabIndex = 0;
            this.lblPrevDispCompetenza.Text = "Budget Corrente";
            this.lblPrevDispCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevCorrente
            // 
            this.txtPrevCorrente.Location = new System.Drawing.Point(152, 70);
            this.txtPrevCorrente.Name = "txtPrevCorrente";
            this.txtPrevCorrente.ReadOnly = true;
            this.txtPrevCorrente.Size = new System.Drawing.Size(121, 20);
            this.txtPrevCorrente.TabIndex = 8;
            this.txtPrevCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrevIniziale
            // 
            this.btnPrevIniziale.Location = new System.Drawing.Point(301, 15);
            this.btnPrevIniziale.Name = "btnPrevIniziale";
            this.btnPrevIniziale.Size = new System.Drawing.Size(75, 20);
            this.btnPrevIniziale.TabIndex = 1;
            this.btnPrevIniziale.Text = "A";
            this.btnPrevIniziale.UseVisualStyleBackColor = true;
            this.btnPrevIniziale.Click += new System.EventHandler(this.btnPrevIniziale_Click);
            // 
            // lblPrevInizialeCompetenza
            // 
            this.lblPrevInizialeCompetenza.Location = new System.Drawing.Point(16, 16);
            this.lblPrevInizialeCompetenza.Name = "lblPrevInizialeCompetenza";
            this.lblPrevInizialeCompetenza.Size = new System.Drawing.Size(130, 13);
            this.lblPrevInizialeCompetenza.TabIndex = 0;
            this.lblPrevInizialeCompetenza.Text = "Budget Iniziale";
            this.lblPrevInizialeCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevIniziale
            // 
            this.txtPrevIniziale.Location = new System.Drawing.Point(152, 15);
            this.txtPrevIniziale.Name = "txtPrevIniziale";
            this.txtPrevIniziale.ReadOnly = true;
            this.txtPrevIniziale.Size = new System.Drawing.Size(121, 20);
            this.txtPrevIniziale.TabIndex = 0;
            this.txtPrevIniziale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.tabAttributi.Size = new System.Drawing.Size(539, 557);
            this.tabAttributi.TabIndex = 4;
            this.tabAttributi.Text = "Attributi";
            this.tabAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(13, 434);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(498, 115);
            this.gboxclass05.TabIndex = 33;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 81);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(468, 20);
            this.txtCodice05.TabIndex = 6;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(9, 52);
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
            this.txtDenom05.Location = new System.Drawing.Point(119, 19);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(358, 55);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(13, 331);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(486, 97);
            this.gboxclass04.TabIndex = 32;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(9, 75);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(468, 20);
            this.txtCodice04.TabIndex = 6;
            // 
            // btnCodice04
            // 
            this.btnCodice04.Location = new System.Drawing.Point(9, 46);
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
            this.txtDenom04.Location = new System.Drawing.Point(115, 19);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(362, 50);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(13, 222);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(485, 103);
            this.gboxclass03.TabIndex = 30;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(8, 77);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(469, 20);
            this.txtCodice03.TabIndex = 6;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(9, 48);
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
            this.txtDenom03.Location = new System.Drawing.Point(119, 19);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(358, 54);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(13, 119);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(485, 97);
            this.gboxclass02.TabIndex = 31;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(9, 71);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(471, 20);
            this.txtCodice02.TabIndex = 6;
            // 
            // btnCodice02
            // 
            this.btnCodice02.Location = new System.Drawing.Point(9, 42);
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
            this.txtDenom02.Location = new System.Drawing.Point(119, 19);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(360, 48);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(14, 18);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(485, 95);
            this.gboxclass01.TabIndex = 29;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(8, 69);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(468, 20);
            this.txtCodice01.TabIndex = 5;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(8, 44);
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
            this.txtDenom01.Location = new System.Drawing.Point(118, 19);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(361, 48);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // Frm_sorting_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(845, 583);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_sorting_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmclassmovimenti";
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPagePrevBudget.ResumeLayout(false);
            this.GrpboxPrevisione.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gboxPrimaPrevisione.ResumeLayout(false);
            this.gboxPrimaPrevisione.PerformLayout();
            this.tabPageLabels.ResumeLayout(false);
            this.tabPageLabels.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gboxManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPagePrevisioni.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVariazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrevisione)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPageRiepilogo.ResumeLayout(false);
            this.grpPrevCompetenza.ResumeLayout(false);
            this.grpPrevCompetenza.PerformLayout();
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
			//labelsfilled=false;
			Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            PostData.SetPostingOrder(DS.budgetprevisionview, "idupb");
            GetData.SetSorting(DS.sorting, "printingorder");
			GetData.SetStaticFilter(DS.sortingprev, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			string filter = (string)Meta.ExtraParameter;
			MetaData.SetDefault(DS.sorting,"idsorkind", (string)Meta.ExtraParameter);
			string filtercodice = QHS.CmpEq("idsorkind", filter);
            GetData.CacheTable(DS.sortinglevel, filtercodice,null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.sortingkind, "description", filtercodice, null, false);
            if (Meta.edit_type != "history") {
                filtercodice = QHS.AppAnd(filtercodice,
                            QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                            QHS.NullOrGe("stop", Meta.GetSys("esercizio")));
            }
        
			GetData.SetStaticFilter(DS.sorting, filtercodice);
			filteresercizio=QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.sortingyearview, QHS.AppAnd(filtercodice,filteresercizio));
		    //GetData.SetStaticFilter(DS.sortingview,  filteresercizio);

            GetData.SetStaticFilter(DS.budgetvardetailview, QHS.CmpEq("ybudgetvar", Meta.GetSys("esercizio")));
            GetData.SetSorting(DS.budgetvardetailview, "nbudgetvar,rownum");

            object nUpb = Meta.Conn.DO_READ_VALUE("upb", null, "count(*)");
            upbUnico = (nUpb == DBNull.Value) || ((int)nUpb == 1);
            string FilterBudgetPrevisionview = "";
            if (!upbUnico) FilterBudgetPrevisionview =
                 "(isnull(prevision,0) <>0 or isnull(previousprevision,0)<>0 " +
                    ")  ";
            FilterBudgetPrevisionview = QHS.AppAnd(FilterBudgetPrevisionview, filteresercizio);
            GetData.SetStaticFilter(DS.budgetprevisionview, FilterBudgetPrevisionview);
            QueryCreator.SetTableForPosting(DS.budgetprevisionview, "budgetprevision");
            cambiaEtichetteEsercizi();
            btnSuddivisioni.Enabled = false;
            AbilitaBtnPrevisione(false);
            DataAccess.SetTableForReading(DS.sorting01, "sortingall");
            DataAccess.SetTableForReading(DS.sorting02, "sortingall");
            DataAccess.SetTableForReading(DS.sorting03, "sortingall");
            DataAccess.SetTableForReading(DS.sorting04, "sortingall");
            DataAccess.SetTableForReading(DS.sorting05, "sortingall");
		    

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
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }
        }
		
		public void MetaData_AfterActivation(){
			if (DS.sortingkind.Rows.Count>0){
				DataRow CurrTipo = DS.sortingkind.Rows[0];
				Meta.Name = "Classificazione \""+CurrTipo["description"].ToString()+"\"";
				GetLabels();
			}
			else {
				MessageBox.Show("Non ho trovato il tipo classificazione "+ (Meta.ExtraParameter as string)+
					". Provare ad aggiornare il menu da File/Menu/Aggiorna Menu ");
				btnBudget.Enabled = false;
				return;
			}
			string filtro = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			DataTable tConfig = DataAccess.RUN_SELECT(Meta.Conn, "config",
				"idsortingkind1,idsortingkind2,idsortingkind3", null, filtro, null, null, true);
			
			if ((tConfig == null) || (tConfig.Rows.Count == 0)) {
				btnBudget.Enabled = false;
				return;
			}
			DataRow Curr = DS.sortingkind.Rows[0];
			string currSor = Curr["idsorkind"].ToString();

            int i_accSortingKind = CfgFn.GetNoNullInt32(Curr["flag"]) & 4;
            accSortingKind = (i_accSortingKind != 0); // Tipo Class collegata al piano dei conti

            if (!accSortingKind)
            {
                btnSuddivisioni.Enabled = false;
                if (tabControl1.TabPages.Contains(tabPagePrevBudget))
                {
                    tabControl1.TabPages.Remove(tabPagePrevBudget);
                }
                
                if (MetaDataDetail.TabPages.Contains(tabPagePrevisioni))
                {
                    MetaDataDetail.TabPages.Remove(tabPagePrevisioni);
                }
                if (MetaDataDetail.TabPages.Contains(tabPageRiepilogo))
                {
                    MetaDataDetail.TabPages.Remove(tabPageRiepilogo);
                }
            }
            
			DataRow rConfig = tConfig.Rows[0];

			if ((currSor != rConfig["idsortingkind1"].ToString())
				&& (currSor != rConfig["idsortingkind2"].ToString())
				&& (currSor != rConfig["idsortingkind3"].ToString())) {
				btnBudget.Enabled = false;
				return;
			}
		}

		/// <summary>
		/// Visualizza o nasconde le label e textbox relative alle previsioni
		/// </summary>
		void VisualizzaPrevisioni(){
			DataRow CurrTipoClass= DS.sortingkind.Rows[0];
			DataRow CurrRow = HelpForm.GetLastSelected(DS.sorting);
			if (Meta.IsEmpty) CurrRow=null;
			//Se non c'Ë un codicefaseentrata associato nasconde la prev. entrata
			if ((CurrTipoClass["nphaseincome"]==DBNull.Value)||(CurrRow==null)){
				labPrevEntrate.Visible=false;
				SubEntity_txtPrevEntrate.Visible=false;
			}
			//Se non c'Ë un codicefasespesa associato nasconde la prev. spesa
			if ((CurrTipoClass["nphaseexpense"]==DBNull.Value)||(CurrRow==null)){
				labPrevSpese.Visible=false;
				SubEntity_txtPrevSpese.Visible=false;
			}
			if (CurrRow==null) return;

			DataRow CurrClass= HelpForm.GetLastSelected(DS.sorting);
			int currlevel=-1;
			if (CurrClass!=null) currlevel= Convert.ToInt32(CurrClass["nlevel"]);
			int maxlevel = MetaData.MaxFromColumn(DS.sortinglevel,"nlevel");
			SubEntity_txtPrevEntrate.ReadOnly= (maxlevel==currlevel);
			SubEntity_txtPrevSpese.ReadOnly= (maxlevel==currlevel);


		}

        private void CalcolaValoriText()
        {
            DataRow R = HelpForm.GetLastSelected(DS.sorting);
            if (R == null) return;
   
            txtPrevIniziale.Text = TotPrevIniziale().ToString("C");
            txtVarPrev.Text = TotVarPrev().ToString("C");
            txtPrevCorrente.Text = (TotPrevIniziale() + TotVarPrev()).ToString("C");
        }


        private string FilterPrevIniziale(DataRow Curr)
        {
            string filter = "";
            filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idsor", Curr["idsor"]));
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));
            return filter;
        }

        private decimal TotPrevIniziale()
        {
            decimal valore;
            DataRow Curr = HelpForm.GetLastSelected(DS.sorting);
            if (Curr == null) return 0;         

            // Previsione corrente (principale)
            string Filter = FilterPrevIniziale(Curr);
            Filter = QHS.AppAnd(Filter, Conn.SelectCondition("budgetprevisionview", true));
            string strExpr = "SUM(prevision)";
            valore = CK(Conn.DO_READ_VALUE("budgetprevisionview", Filter, strExpr));
            return valore;
        }

        private void btnPrevIniziale_Click(object sender, EventArgs e)
        {
            string VistaScelta;
            DataRow Curr = HelpForm.GetLastSelected(DS.sorting);
            if (Curr == null) return;
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            //Previsione corrente (principale)
            string Filter = FilterPrevIniziale(Curr);
            VistaScelta = "budgetprevisionview";
            MetaData MBudgetPrevisionView = MetaData.GetMetaData(this, VistaScelta);
            MBudgetPrevisionView.FilterLocked = true;
            MBudgetPrevisionView.DS = DS;

            DataRow MyDR = MBudgetPrevisionView.SelectOne("default", Filter, null, null);

            if (MyDR != null)
            {
                SelezionaPrevisione(MyDR);
            }
        }

        private void SelezionaPrevisione(DataRow MyDR)
        {
            MetaData newBudgetPrevisionView = Meta.Dispatcher.Get("budgetprevisionview");
            newBudgetPrevisionView.ExtraParameter = MyDR["idsor"];
            newBudgetPrevisionView.Edit(this.ParentForm, "default", false);
            DataRow R2 = newBudgetPrevisionView.SelectOne(newBudgetPrevisionView.DefaultListType,
                 QHS.AppAnd(QHS.CmpEq("idsor", MyDR["idsor"]),
                               QHS.CmpEq("idupb", MyDR["idupb"]),
                               QHS.CmpEq("ayear",Conn.GetEsercizio())), "budgetprevisionview", null);
            if (R2 != null) newBudgetPrevisionView.SelectRow(R2, newBudgetPrevisionView.DefaultListType);
        }

        private string FilterVarPrev(DataRow Curr)
        {
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            string filter = "";
            filter = QHS.CmpEq("ybudgetvar", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idbudgetvarstatus", "5"));
            filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idsor", Curr["idsor"]));
            return filter;
        }

        private decimal TotVarPrev()
        {
            decimal valore;
            DataRow Curr = HelpForm.GetLastSelected(DS.sorting);
            if (Curr == null) return 0;
            string filter = FilterVarPrev(Curr);
            filter = QHS.AppAnd(filter, Conn.SelectCondition("budgetvardetailview", true));
            string strExpr = "SUM(amount)";
            valore = CK(Conn.DO_READ_VALUE("budgetvardetailview", filter, strExpr));

            return valore;
        }

        private void btnVarPrev_Click(object sender, EventArgs e)
        {
            DataRow Curr = HelpForm.GetLastSelected(DS.sorting);
            if (Curr == null) return;

            string filter = FilterVarPrev(Curr);
            string VistaScelta = "budgetvardetailview";
            MetaData MBudgetVarDetail = MetaData.GetMetaData(this, VistaScelta);
            MBudgetVarDetail.FilterLocked = true;
            MBudgetVarDetail.DS = DS;
            DataRow MyDR = MBudgetVarDetail.SelectOne("listaestesa", filter, null, null);

            if (MyDR != null)
            {
                SelezionaVariazione(MyDR);
            }
        }


        private void SelezionaVariazione(DataRow MyDR)
        {
            MetaData newBudgetVarDetail = Meta.Dispatcher.Get("budgetvardetail");
            newBudgetVarDetail.ExtraParameter = MyDR["idsorkind"].ToString();
            newBudgetVarDetail.Edit(this.ParentForm, "default", false);
            DataRow R2 = newBudgetVarDetail.SelectOne("lista",
                QHS.AppAnd(QHS.CmpEq("ybudgetvar", MyDR["ybudgetvar"]),
                QHS.CmpEq("nbudgetvar", MyDR["nbudgetvar"]), QHS.CmpEq("rownum", MyDR["rownum"])),
                "budgetvardetail", null);
            if (R2 != null) newBudgetVarDetail.SelectRow(R2, "lista");
        }


		private bool Operativo(DataRow R){
			if (R==null) return false;
			object livellorow=R["nlevel"];
			DataRow[] Res = DS.sortinglevel.Select(QHC.CmpEq("nlevel", livellorow));
			if (Res.Length!=1) return false;
            int operativo = CfgFn.GetNoNullInt32(Res[0]["flag"]) & 2;
			if (operativo==0) return false;
			//if (R.GetChildRows("classmovimenticlassmovimenti").Length>0) return false;
			return true;
		}

        bool Foglia(DataRow R)
        {
            if (R == null) return false;
            if (Meta.InsertMode) return true;
            string filter = QHS.CmpEq("paridsor", R["idsor"]);
            int N = Conn.RUN_SELECT_COUNT("sorting", filter, true);
            if (N == 0) return true;
            return false;

        }

		void SetAsOperativo(bool operativo){
			SubEntity_txtPrevEntrate.ReadOnly = !operativo;
			SubEntity_txtPrevSpese.ReadOnly = !operativo;
			for (int i=1; i<=5; i++) {
				SetTextBoxReadOnly("valuen"+i.ToString(), !operativo);
				SetTextBoxReadOnly("values"+i.ToString(), !operativo);
			}	
			chkIgnoraDate.Enabled= operativo;
		}

		void AbilitaDisabilitaPrevisioniEDatiAggiuntivi(){
			DataRow CurrClass= HelpForm.GetLastSelected(DS.sorting);
			if (CurrClass==null) {
				SetAsOperativo(false);
				return;
			}

			string livello = CurrClass["nlevel"].ToString();
			if (livello=="") {
				SetAsOperativo(false);
				return;
			}

			bool enable=false;
			if (CurrClass.GetChildRows("sortingsortingprev").Length>0)
				enable=true;
			enable = enable && Operativo(CurrClass);
			SetAsOperativo(enable);
		}

		public void MetaData_AfterFill() {
            if (!Meta.CanInsert) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
            //abilita/disabilita i controlli
            bool ModoInsert = Meta.InsertMode;
            if ((Meta.EditMode) &&(accSortingKind))
            {  
               DataRow R = HelpForm.GetLastSelected(DS.sorting);
               CalcolaValoriTxtPrevisione(R);
               if (Operativo(R) && (Foglia(R)))
               {
                   btnSuddivisioni.Enabled = true;
                   AbilitaBtnPrevisione(true);
               }
               else
               {
                   pulisciTextRiepilogo();
                   AbilitaBtnPrevisione(false);
               }
            }
			txtDescrizione.ReadOnly=false;
			btnSituazioneClassificazione.Enabled=!Meta.InsertMode;
			Calcolo_CurrClass();
		}


		public void Calcolo_CurrClass() {
			DataRow CurrClass= HelpForm.GetLastSelected(DS.sorting);
			AbilitaDisabilitaPrevisioniEDatiAggiuntivi();

			if (CurrClass==null) {
				txtCodice.ReadOnly=true;
				return;
			}
			object livello = CurrClass["nlevel"];
			if (Meta.InsertMode)
				txtCodice.ReadOnly=TipoNumerico(livello);
			else
                txtCodice.ReadOnly = TipoNumerico(livello)|| (!LunghezzaZero(livello)) ;
			GetLabels();
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "sorting")
            {
                Calcolo_CurrClass();
                pulisciTextRiepilogo();
            }
		}
		private bool TipoNumerico(object codicelivello){
			DataRow[] Res = DS.sortinglevel.Select(QHC.CmpEq("nlevel", codicelivello));
			if (Res.Length!=1) return false;
			int tipocodice = CfgFn.GetNoNullInt32(Res[0]["flag"]) & 1;
			if (tipocodice==0)
				return true;
			else
				return false;
		}

        private bool LunghezzaZero(object codicelivello) {
            DataRow[] Res = DS.sortinglevel.Select(QHC.CmpEq("nlevel", codicelivello));
            if (Res.Length != 1) return false;

            int len = CfgFn.GetNoNullInt32(Res[0]["flag"]) >> 8;
            if (len == 0)
                return true;
            else
                return false;
        }

		public void MetaData_AfterClear() {
			btnSituazioneClassificazione.Enabled=false;
			SubEntity_txtPrevEntrate.ReadOnly = false;
			SubEntity_txtPrevSpese.ReadOnly = false;
			txtDescrizione.ReadOnly=false;
			txtCodice.ReadOnly=false;
            cmbResponsabile.Enabled = true;
            Meta.CanInsert = false;
            btnSuddivisioni.Enabled = false;
            pulisciTxtPrevisione();
            pulisciTextRiepilogo();
            AbilitaBtnPrevisione(false);
		}
        private void pulisciTextRiepilogo()
        {
            txtPrevIniziale.Text = "";
            txtVarPrev.Text = "";
            txtPrevCorrente.Text = "";
        }

        private void pulisciTxtPrevisione()
        {
            string empty = "";
            SubEntity_txtpreveserciziocorr.Text = empty;
            SubEntity_txtprevesercizioprec.Text = empty;
            SubEntity_txtprevision2.Text = empty;
            SubEntity_txtprevision3.Text = empty;
            SubEntity_txtprevision4.Text = empty;
            SubEntity_txtprevision5.Text = empty;
        }

		public void MetaData_BeforeFill() {
            cmbResponsabile.Enabled = false;
			//Controlla che vi sia o Crea una nuova riga nel DataTable "previsioneclassmovimenti"
			//con valori di default.
			if(Meta.InsertMode)
				CreatePrevisioneClassmovimentiRow();			
		}

        public void MetaData_BeforePost()
        {
            if (!accSortingKind) return; 
            impostaCampiDaSalvare(false);
 
        }

        private void impostaCampiDaSalvare(bool salva)
        {
            if (!salva)
            {
                string empty = "";
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsorkind"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["codesorkind"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sortingkind"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sorting"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sortcode"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["paridsor"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["upb"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["codeupb"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["paridupb"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["nlevel"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["leveldescr"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor01"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor02"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor03"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor04"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor05"], empty);
            }
            else
            {
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsorkind"], "idsorkind");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["codesorkind"], "codesorkind");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sortingkind"], "sortingkind");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sorting"], "sorting");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sortcode"], "sortcode");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["paridsor"], "paridsor");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["upb"], "upb");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["codeupb"], "codeupb");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["paridupb"], "paridupb");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["nlevel"], "nlevel");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["leveldescr"], "leveldescr");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor01"], "idsor01");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor02"], "idsor02");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor03"], "idsor03");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor04"], "idsor04");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor05"], "idsor05");
            }
        }

        public void MetaData_AfterPost()
        {
            if (!accSortingKind) return;
            impostaCampiDaSalvare(true);
            DataRow rSorting = HelpForm.GetLastSelected(DS.sorting);
            if (rSorting == null) return;
            object idsor = rSorting["idsor"];
            string filter = QHS.CmpEq("idsor", idsor);
            string FilterBudgetPrevisionview = "(isnull(prevision,0) <>0)";
            filter = QHS.AppAnd(FilterBudgetPrevisionview, filter,QHS.CmpEq("ayear",Conn.GetEsercizio()));

            Conn.RUN_SELECT_INTO_TABLE(DS.budgetprevisionview, null, filter, null, true);
            Meta.FreshForm();
        }

		public void CreatePrevisioneClassmovimentiRow() {
			if (Meta.IsEmpty) return;
			DataRow CurrentClassMovimenti = HelpForm.GetLastSelected(DS.sorting);
			if (CurrentClassMovimenti==null) return;
			if (!Operativo(CurrentClassMovimenti)) return;
			
			if(CurrentClassMovimenti.GetChildRows("sortingsortingprev").Length==0) {
				try {					
					DataRow NewRigaPrevisione = DS.sortingprev.NewRow();			
					NewRigaPrevisione["idsor"] = CurrentClassMovimenti["idsor"];
					NewRigaPrevisione["ayear"] = Meta.GetSys("esercizio");
					//Questi valori verranno sovrascritti dalla libreria
					NewRigaPrevisione["cu"] = "AAA";
					NewRigaPrevisione["ct"] = System.DateTime.Now;
					NewRigaPrevisione["lu"] = "AAA";
					NewRigaPrevisione["lt"] = System.DateTime.Now;
					DS.sortingprev.Rows.Add(NewRigaPrevisione);
				}
				catch {
				}
			}
		}

        void AbilitaBtnPrevisione(bool enable)
        {
            btnInsPrevisione.Enabled = enable;
            btnEditPrevisione.Enabled = enable;
            btnDelPrevisione.Enabled = enable;
        }
		void ShowHideTextBox(string name, bool show) {
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(name);
			if (Ctrl==null) return ;
			if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return;                         
			TextBox T =  (TextBox) Ctrl.GetValue(this);                        
			T.Visible=show;
		}

		void SetTextBoxReadOnly(string name, bool read_only) {
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(name);
			if (Ctrl==null) return ;
			if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return;                         
			TextBox T =  (TextBox) Ctrl.GetValue(this);                        
			T.ReadOnly=read_only;
		}
		
		void LockTextBox(string name, bool Lock) {
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(name);
			if (Ctrl==null) return ;
			if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return ;                         
			TextBox T =  (TextBox) Ctrl.GetValue(this);                        
			T.ReadOnly=Lock;
		}

		private void GetLabels() {	
			//if (Meta.IsEmpty) return;
			//DataRow CurrRow = DS.classmovimenti.Rows[0];
			//bool read_only=false;
			if (DS.sortingkind.Rows.Count==0) return;
			DataRow Rtipo = DS.sortingkind.Rows[0];
			
	
			if (Rtipo["flagdate"].ToString().ToLower()!="s") {
				chkIgnoraDate.Visible = false;
				labelignoradate.Visible=false;
			}
			for (int i=1; i<=5; i++) {
				string suffix= "n"+i.ToString();
				if (Rtipo["label"+suffix].ToString()=="") {
					ShowHideTextBox("valore"+suffix.ToUpper(),false);
				}

				if ((Rtipo["forced"+suffix].ToString().ToLower()=="s")&&(Rtipo["locked"+suffix].ToString().ToLower()=="s")) {
					HelpForm.SetDenyNull(DS.Tables["sorting"].Columns["default"+suffix],true);
				}
			}
			for (int i=1; i<=5; i++) {
				string suffix= "v"+i.ToString();
				if (Rtipo["label"+suffix].ToString()=="") {
					ShowHideTextBox("valore"+suffix.ToUpper(),false);
				}

				if ((Rtipo["forced"+suffix].ToString().ToLower()=="s")&&(Rtipo["locked"+suffix].ToString().ToLower()=="s")) {
					HelpForm.SetDenyNull(DS.Tables["sorting"].Columns["default"+suffix],true);
				}
			}

			for (int i=1; i<=5; i++) {
				string ssuffix= "s"+i.ToString();
				if (Rtipo["label"+ssuffix].ToString()=="") {
					ShowHideTextBox("valore"+ssuffix.ToUpper(),false);
				}

				if ((Rtipo["forced"+ssuffix].ToString().ToLower()=="s")&&(Rtipo["locked"+ssuffix].ToString().ToLower()=="s")) {
					HelpForm.SetDenyNull(DS.Tables["sorting"].Columns["default"+ssuffix],true);
				}
			}

			if (Rtipo["flagdate"].ToString().ToLower()!="s"){
				panel1.Visible=false;
				//HelpForm.SetDenyNull(DS.Tables["classmovimenti"].Columns["default"+ssuffix],false);
			}
			else {
				panel1.Visible=true;
				HelpForm.SetDenyNull(DS.Tables["sorting"].Columns["flagnodate"],true);
			}
																  
		}

		// Eliminato perchË scatta l'AfterFill
		//		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
		//			if (T.TableName=="classmovimenti"){
		//				txtDescrizione.ReadOnly= (R==null);
		//				AbilitaDisabilitaPrevisioniEDatiAggiuntivi();
		//			}
		//		}
		private void btnSituazioneClassificazione_Click(object sender, System.EventArgs e) {
			// Esempio di chiamata a sp_sit_classmovimenti:
			// sp_sit_classmovimenti 'feb 11 2002 12:00:00:000AM', 'PROVA', '0003', 2002				
            object codicetipoclass = null;
            object idclass = null;
			DataAccess Conn=MetaData.GetConnection(this);
			try {
				DataRow MyRow=HelpForm.GetLastSelected(DS.sorting);
				codicetipoclass=MyRow["idsorkind"];
				idclass=MyRow["idsor"];
			}
			catch {
				return;
			}
			DataSet Out = Conn.CallSP("show_sorting",
				new Object[4] {Meta.GetSys("datacontabile"),
							   codicetipoclass,
							   idclass,
			 				   Meta.GetSys("esercizio")
							  }
				);
			if (Out==null) return;
			Out.Tables[0].TableName= "Situazione classificazione";
			frmSituazioneViewer View= new frmSituazioneViewer(Out);
			View.Show();
		}

		private void btnBudget_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow sortingRow = HelpForm.GetLastSelected(DS.sorting);
			if (sortingRow == null)return;

			object idSorKind = sortingRow["idsorkind"];
            object idSor = sortingRow["idsor"];
			string sortingPassed = idSorKind + "ß" + idSor;
			DS.accountprevisionview.ExtendedProperties[MetaData.ExtraParams] = sortingPassed;
			Meta.Dispatcher.Edit(this.ParentForm,"accountprevisionview","prevision",false,sortingPassed);
		}

        private void tree_AfterSelect(object sender, TreeViewEventArgs e) {
            if ((!Meta.IsEmpty) && (!Meta.CanInsert)) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
        }

    

        public void CreateBudgetPrevisionRow()
        {
            if (Meta.IsEmpty) return;
            if (DS.Tables["budgetprevisionview"].Rows.Count == 0)
            {
                DataRow drSorting = HelpForm.GetLastSelected(DS.sorting);
                MetaData metaBP = MetaData.GetMetaData(this, "budgetprevisionview");
                metaBP.SetDefaults(DS.budgetprevisionview);
                MetaData.SetDefault(DS.budgetprevisionview, "idupb", "0001"); // UPB Radice
                MetaData.SetDefault(DS.budgetprevisionview, "ayear", Meta.GetSys("esercizio")); // UPB Radice
                MetaData.SetDefault(DS.budgetprevisionview, "nlevel", drSorting["nlevel"]); // 
                MetaData.SetDefault(DS.budgetprevisionview, "paridsor", drSorting["paridsor"]); // 
                MetaData.SetDefault(DS.budgetprevisionview, "sortcode", drSorting["sortcode"]); // 
                MetaData.SetDefault(DS.budgetprevisionview, "sorting", drSorting["description"]); // 
                DataRow DR = metaBP.Get_New_Row(drSorting, DS.budgetprevisionview);

            }
        }

        private void btnSuddivisioni_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DataRow sortingRow= HelpForm.GetLastSelected(DS.sorting);
            if (sortingRow == null) return;

            object idSorting = sortingRow["idsor"];
            DS.budgetprevisionview.ExtendedProperties[MetaData.ExtraParams] = idSorting;
            Meta.Dispatcher.Edit(this.ParentForm, "budgetprevisionview", "default", false, idSorting);
        }
        private Decimal CK(Object O)
        {
            if (O == DBNull.Value) return 0;
            return CfgFn.GetNoNullDecimal(O);
        }

        private void cambiaEtichetteEsercizi()
        {
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            int esercizioPrec = esercizioCurr - 1;
            lblEsCorrentePrima.Text = esercizioCurr.ToString();
            lblEsPrecPrima.Text = esercizioPrec.ToString();
            lblPrevisione2.Text = (++esercizioCurr).ToString();
            lblPrevisione3.Text = (++esercizioCurr).ToString();
            lblPrevisione4.Text = (++esercizioCurr).ToString();
            lblPrevisione5.Text = (++esercizioCurr).ToString();
        }

        private void CalcolaValoriTxtPrevisione(DataRow R)
        {
            if (R == null) return;
            string Filter = Conn.SelectCondition("budgetprevisionview", true);
           
                //Applichiamo la sicurezza
                DataRow CurrSorting= HelpForm.GetLastSelected(DS.sorting);
                if (CurrSorting == null) return;
                int nlevel = CfgFn.GetNoNullInt32(CurrSorting["nlevel"]);
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("sortinglink.idparent", CurrSorting["idsor"]));
                string sql = "SELECT SUM(prevision) as prevision, SUM(previousprevision) as previousprevision, " +
                            " SUM(prevision2) as prevision2, SUM(prevision3) as prevision3, " +
                            " SUM(prevision4) as prevision4, SUM(prevision5) as prevision5 " +
                            " FROM budgetprevisionview " +
                            " LEFT OUTER JOIN sortinglink " +
                            "   ON sortinglink.idchild = budgetprevisionview.idsor and sortinglink.nlevel = " + nlevel +
                            " WHERE " + Filter;

                DataTable Previsioni = Conn.SQLRunner(sql, false);
                if (Previsioni.Rows.Count > 0)
                {
                    DataRow rPrevisioni = Previsioni.Rows[0];
                    SubEntity_txtpreveserciziocorr.Text = CK(rPrevisioni["prevision"]).ToString("c");
                    SubEntity_txtprevesercizioprec.Text = CK(rPrevisioni["previousprevision"]).ToString("c");
                    SubEntity_txtprevision2.Text = CK(rPrevisioni["prevision2"]).ToString("c");
                    SubEntity_txtprevision3.Text = CK(rPrevisioni["prevision3"]).ToString("c");
                    SubEntity_txtprevision4.Text = CK(rPrevisioni["prevision4"]).ToString("c");
                    SubEntity_txtprevision5.Text = CK(rPrevisioni["prevision5"]).ToString("c");
                }
            
           
        }

        
        private void btnCalcolaTotali_Click(object sender, EventArgs e)
        {
            CalcolaValoriText();
        }

    }
}