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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using SituazioneViewer;

namespace accountyearview_default {
	/// <summary>
	/// Summary description for FrmAccountYearView_Default.
	/// </summary>
	public class FrmAccountYearView_Default : System.Windows.Forms.Form {
		MetaData Meta;
	
        bool isContoOperativo = false;
		public accountyearview_default.vistaForm DS;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.Button btnSituazione;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtCodiceConto;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDenominazioneConto;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList icons;
        private GroupBox gboxUPB;
        private Button btnUPB;
        public TextBox txtUPB;
        public TabControl tabControl2;
        private TabPage tabPage1;
        private GroupBox grpImporto5;
        private TextBox txtImporto5;
        private GroupBox grpImporto4;
        private TextBox txtImporto4;
        private GroupBox grpImporto3;
        private TextBox txtImporto3;
        private GroupBox grpImporto2;
        private TextBox txtImporto2;
        private GroupBox grpImporto1;
        private TextBox txtImporto1;
        private TabPage tabPage2;
        private GroupBox grpImportoC5;
        private TextBox txtCons5;
        private GroupBox grpImportoC4;
        private TextBox txtCons4;
        private GroupBox grpImportoC3;
        private TextBox txtCons3;
        private GroupBox grpImportoC2;
        private TextBox txtCons2;
        private GroupBox grpImportoC1;
        private TextBox txtCons1;
        private Label label4;
        private Button btnCalcola;
        private Button btnSituazioneBudget;
        private TabPage tabPage3;
        private CheckBox chkUpbChilds;
        private Button btnCalcolaTotali;
        private TabControl tabControl3;
        private TabPage tabPage4;
        private Button btnScrittureDare;
        private Button btnScrittureAvere;
        private Button btnVarAccertamenti;
        private Label label15;
        private TextBox txtVarAccertamenti;
        private TextBox txtVarPreaccertamenti;
        private Label label16;
        private Button btnVarPreaccertamenti;
        private Button btnAccertamentiBudget;
        private Label label17;
        private TextBox txtAccertamentiBudget;
        private TextBox txtPreaccertamentiBudget;
        private Label label19;
        private Button btnPreaccertamentiBudget;
        private TextBox txtScrittureAvere;
        private Label label14;
        private TextBox txtScrittureDare;
        private Label label13;
        private Label label12;
        private Label label5;
        private TextBox txtBudgetAttuale;
        private Button btnVarImpegni;
        private Label label3;
        private TextBox txtVarImpegni;
        private TextBox txtVarPreimpegni;
        private Label label6;
        private Button btnVarPreimpegni;
        private Label label11;
        private Button btnImpegniBudget;
        private TextBox txtBudgetIniziale;
        private Label label7;
        private Button btnBudgetIniziale;
        private TextBox txtImpegniBudget;
        private TextBox txtPreimpegniBudget;
        private Label label8;
        private Label label10;
        private Button btnVarBudget;
        private Button btnPreimpegniBudget;
        private Label label9;
        private TextBox txtBudgetDisponibile;
        private TextBox txtVariazioniBudget;
        private Label label18;
        private System.ComponentModel.IContainer components;

		public FrmAccountYearView_Default() {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccountYearView_Default));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSituazioneBudget = new System.Windows.Forms.Button();
            this.grpImporto5 = new System.Windows.Forms.GroupBox();
            this.txtImporto5 = new System.Windows.Forms.TextBox();
            this.grpImporto4 = new System.Windows.Forms.GroupBox();
            this.txtImporto4 = new System.Windows.Forms.TextBox();
            this.grpImporto3 = new System.Windows.Forms.GroupBox();
            this.txtImporto3 = new System.Windows.Forms.TextBox();
            this.grpImporto2 = new System.Windows.Forms.GroupBox();
            this.txtImporto2 = new System.Windows.Forms.TextBox();
            this.grpImporto1 = new System.Windows.Forms.GroupBox();
            this.txtImporto1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCalcola = new System.Windows.Forms.Button();
            this.grpImportoC5 = new System.Windows.Forms.GroupBox();
            this.txtCons5 = new System.Windows.Forms.TextBox();
            this.grpImportoC4 = new System.Windows.Forms.GroupBox();
            this.txtCons4 = new System.Windows.Forms.TextBox();
            this.grpImportoC3 = new System.Windows.Forms.GroupBox();
            this.txtCons3 = new System.Windows.Forms.TextBox();
            this.grpImportoC2 = new System.Windows.Forms.GroupBox();
            this.txtCons2 = new System.Windows.Forms.TextBox();
            this.grpImportoC1 = new System.Windows.Forms.GroupBox();
            this.txtCons1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkUpbChilds = new System.Windows.Forms.CheckBox();
            this.btnCalcolaTotali = new System.Windows.Forms.Button();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnScrittureDare = new System.Windows.Forms.Button();
            this.btnScrittureAvere = new System.Windows.Forms.Button();
            this.btnVarAccertamenti = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtVarAccertamenti = new System.Windows.Forms.TextBox();
            this.txtVarPreaccertamenti = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnVarPreaccertamenti = new System.Windows.Forms.Button();
            this.btnAccertamentiBudget = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAccertamentiBudget = new System.Windows.Forms.TextBox();
            this.txtPreaccertamentiBudget = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnPreaccertamentiBudget = new System.Windows.Forms.Button();
            this.txtScrittureAvere = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtScrittureDare = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBudgetAttuale = new System.Windows.Forms.TextBox();
            this.btnVarImpegni = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVarImpegni = new System.Windows.Forms.TextBox();
            this.txtVarPreimpegni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnVarPreimpegni = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnImpegniBudget = new System.Windows.Forms.Button();
            this.txtBudgetIniziale = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBudgetIniziale = new System.Windows.Forms.Button();
            this.txtImpegniBudget = new System.Windows.Forms.TextBox();
            this.txtPreimpegniBudget = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnVarBudget = new System.Windows.Forms.Button();
            this.btnPreimpegniBudget = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBudgetDisponibile = new System.Windows.Forms.TextBox();
            this.txtVariazioniBudget = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.DS = new accountyearview_default.vistaForm();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpImporto5.SuspendLayout();
            this.grpImporto4.SuspendLayout();
            this.grpImporto3.SuspendLayout();
            this.grpImporto2.SuspendLayout();
            this.grpImporto1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpImportoC5.SuspendLayout();
            this.grpImportoC4.SuspendLayout();
            this.grpImportoC3.SuspendLayout();
            this.grpImportoC2.SuspendLayout();
            this.grpImportoC1.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(219, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 526);
            this.tabControl1.TabIndex = 20;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabControl2);
            this.tabMain.Controls.Add(this.gboxUPB);
            this.tabMain.Controls.Add(this.btnSituazione);
            this.tabMain.Controls.Add(this.groupBox2);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(712, 500);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Principale";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(8, 170);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(633, 172);
            this.tabControl2.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSituazioneBudget);
            this.tabPage1.Controls.Add(this.grpImporto5);
            this.tabPage1.Controls.Add(this.grpImporto4);
            this.tabPage1.Controls.Add(this.grpImporto3);
            this.tabPage1.Controls.Add(this.grpImporto2);
            this.tabPage1.Controls.Add(this.grpImporto1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(625, 146);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSituazioneBudget
            // 
            this.btnSituazioneBudget.Location = new System.Drawing.Point(236, 97);
            this.btnSituazioneBudget.Name = "btnSituazioneBudget";
            this.btnSituazioneBudget.Size = new System.Drawing.Size(142, 23);
            this.btnSituazioneBudget.TabIndex = 36;
            this.btnSituazioneBudget.TabStop = false;
            this.btnSituazioneBudget.Text = "Situazione Budget";
            this.btnSituazioneBudget.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpImporto5
            // 
            this.grpImporto5.Controls.Add(this.txtImporto5);
            this.grpImporto5.Location = new System.Drawing.Point(502, 17);
            this.grpImporto5.Name = "grpImporto5";
            this.grpImporto5.Size = new System.Drawing.Size(116, 48);
            this.grpImporto5.TabIndex = 35;
            this.grpImporto5.TabStop = false;
            this.grpImporto5.Tag = "";
            this.grpImporto5.Text = "Budget anno";
            // 
            // txtImporto5
            // 
            this.txtImporto5.Location = new System.Drawing.Point(6, 18);
            this.txtImporto5.Name = "txtImporto5";
            this.txtImporto5.Size = new System.Drawing.Size(104, 20);
            this.txtImporto5.TabIndex = 1;
            this.txtImporto5.Tag = "accountyearview.prevision5";
            // 
            // grpImporto4
            // 
            this.grpImporto4.Controls.Add(this.txtImporto4);
            this.grpImporto4.Location = new System.Drawing.Point(380, 17);
            this.grpImporto4.Name = "grpImporto4";
            this.grpImporto4.Size = new System.Drawing.Size(116, 48);
            this.grpImporto4.TabIndex = 34;
            this.grpImporto4.TabStop = false;
            this.grpImporto4.Tag = "";
            this.grpImporto4.Text = "Budget anno";
            // 
            // txtImporto4
            // 
            this.txtImporto4.Location = new System.Drawing.Point(6, 18);
            this.txtImporto4.Name = "txtImporto4";
            this.txtImporto4.Size = new System.Drawing.Size(104, 20);
            this.txtImporto4.TabIndex = 1;
            this.txtImporto4.Tag = "accountyearview.prevision4";
            // 
            // grpImporto3
            // 
            this.grpImporto3.Controls.Add(this.txtImporto3);
            this.grpImporto3.Location = new System.Drawing.Point(250, 17);
            this.grpImporto3.Name = "grpImporto3";
            this.grpImporto3.Size = new System.Drawing.Size(119, 48);
            this.grpImporto3.TabIndex = 33;
            this.grpImporto3.TabStop = false;
            this.grpImporto3.Tag = "";
            this.grpImporto3.Text = "Budget anno";
            // 
            // txtImporto3
            // 
            this.txtImporto3.Location = new System.Drawing.Point(6, 18);
            this.txtImporto3.Name = "txtImporto3";
            this.txtImporto3.Size = new System.Drawing.Size(104, 20);
            this.txtImporto3.TabIndex = 1;
            this.txtImporto3.Tag = "accountyearview.prevision3";
            // 
            // grpImporto2
            // 
            this.grpImporto2.Controls.Add(this.txtImporto2);
            this.grpImporto2.Location = new System.Drawing.Point(128, 17);
            this.grpImporto2.Name = "grpImporto2";
            this.grpImporto2.Size = new System.Drawing.Size(116, 48);
            this.grpImporto2.TabIndex = 32;
            this.grpImporto2.TabStop = false;
            this.grpImporto2.Tag = "";
            this.grpImporto2.Text = "Budget anno";
            // 
            // txtImporto2
            // 
            this.txtImporto2.Location = new System.Drawing.Point(6, 18);
            this.txtImporto2.Name = "txtImporto2";
            this.txtImporto2.Size = new System.Drawing.Size(104, 20);
            this.txtImporto2.TabIndex = 1;
            this.txtImporto2.Tag = "accountyearview.prevision2";
            // 
            // grpImporto1
            // 
            this.grpImporto1.Controls.Add(this.txtImporto1);
            this.grpImporto1.Location = new System.Drawing.Point(4, 17);
            this.grpImporto1.Name = "grpImporto1";
            this.grpImporto1.Size = new System.Drawing.Size(118, 48);
            this.grpImporto1.TabIndex = 31;
            this.grpImporto1.TabStop = false;
            this.grpImporto1.Tag = "";
            this.grpImporto1.Text = "Budget anno";
            // 
            // txtImporto1
            // 
            this.txtImporto1.Location = new System.Drawing.Point(6, 18);
            this.txtImporto1.Name = "txtImporto1";
            this.txtImporto1.Size = new System.Drawing.Size(104, 20);
            this.txtImporto1.TabIndex = 1;
            this.txtImporto1.Tag = "accountyearview.prevision";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCalcola);
            this.tabPage2.Controls.Add(this.grpImportoC5);
            this.tabPage2.Controls.Add(this.grpImportoC4);
            this.tabPage2.Controls.Add(this.grpImportoC3);
            this.tabPage2.Controls.Add(this.grpImportoC2);
            this.tabPage2.Controls.Add(this.grpImportoC1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(625, 146);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consolidato";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCalcola
            // 
            this.btnCalcola.Location = new System.Drawing.Point(261, 101);
            this.btnCalcola.Name = "btnCalcola";
            this.btnCalcola.Size = new System.Drawing.Size(75, 23);
            this.btnCalcola.TabIndex = 36;
            this.btnCalcola.Text = "Calcola";
            this.btnCalcola.Click += new System.EventHandler(this.btnCalcola_Click);
            // 
            // grpImportoC5
            // 
            this.grpImportoC5.Controls.Add(this.txtCons5);
            this.grpImportoC5.Location = new System.Drawing.Point(506, 31);
            this.grpImportoC5.Name = "grpImportoC5";
            this.grpImportoC5.Size = new System.Drawing.Size(118, 48);
            this.grpImportoC5.TabIndex = 35;
            this.grpImportoC5.TabStop = false;
            this.grpImportoC5.Tag = "";
            this.grpImportoC5.Text = "Budget anno";
            // 
            // txtCons5
            // 
            this.txtCons5.Location = new System.Drawing.Point(6, 18);
            this.txtCons5.Name = "txtCons5";
            this.txtCons5.ReadOnly = true;
            this.txtCons5.Size = new System.Drawing.Size(104, 20);
            this.txtCons5.TabIndex = 1;
            this.txtCons5.Tag = "";
            this.txtCons5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpImportoC4
            // 
            this.grpImportoC4.Controls.Add(this.txtCons4);
            this.grpImportoC4.Location = new System.Drawing.Point(380, 31);
            this.grpImportoC4.Name = "grpImportoC4";
            this.grpImportoC4.Size = new System.Drawing.Size(120, 48);
            this.grpImportoC4.TabIndex = 34;
            this.grpImportoC4.TabStop = false;
            this.grpImportoC4.Tag = "";
            this.grpImportoC4.Text = "Budget anno";
            // 
            // txtCons4
            // 
            this.txtCons4.Location = new System.Drawing.Point(6, 18);
            this.txtCons4.Name = "txtCons4";
            this.txtCons4.ReadOnly = true;
            this.txtCons4.Size = new System.Drawing.Size(104, 20);
            this.txtCons4.TabIndex = 1;
            this.txtCons4.Tag = "";
            this.txtCons4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpImportoC3
            // 
            this.grpImportoC3.Controls.Add(this.txtCons3);
            this.grpImportoC3.Location = new System.Drawing.Point(255, 31);
            this.grpImportoC3.Name = "grpImportoC3";
            this.grpImportoC3.Size = new System.Drawing.Size(119, 48);
            this.grpImportoC3.TabIndex = 33;
            this.grpImportoC3.TabStop = false;
            this.grpImportoC3.Tag = "";
            this.grpImportoC3.Text = "Budget anno";
            // 
            // txtCons3
            // 
            this.txtCons3.Location = new System.Drawing.Point(6, 18);
            this.txtCons3.Name = "txtCons3";
            this.txtCons3.ReadOnly = true;
            this.txtCons3.Size = new System.Drawing.Size(104, 20);
            this.txtCons3.TabIndex = 1;
            this.txtCons3.Tag = "";
            this.txtCons3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpImportoC2
            // 
            this.grpImportoC2.Controls.Add(this.txtCons2);
            this.grpImportoC2.Location = new System.Drawing.Point(132, 31);
            this.grpImportoC2.Name = "grpImportoC2";
            this.grpImportoC2.Size = new System.Drawing.Size(117, 48);
            this.grpImportoC2.TabIndex = 32;
            this.grpImportoC2.TabStop = false;
            this.grpImportoC2.Tag = "";
            this.grpImportoC2.Text = "Budget anno";
            // 
            // txtCons2
            // 
            this.txtCons2.Location = new System.Drawing.Point(6, 18);
            this.txtCons2.Name = "txtCons2";
            this.txtCons2.ReadOnly = true;
            this.txtCons2.Size = new System.Drawing.Size(104, 20);
            this.txtCons2.TabIndex = 1;
            this.txtCons2.Tag = "";
            this.txtCons2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpImportoC1
            // 
            this.grpImportoC1.Controls.Add(this.txtCons1);
            this.grpImportoC1.Location = new System.Drawing.Point(8, 31);
            this.grpImportoC1.Name = "grpImportoC1";
            this.grpImportoC1.Size = new System.Drawing.Size(118, 48);
            this.grpImportoC1.TabIndex = 31;
            this.grpImportoC1.TabStop = false;
            this.grpImportoC1.Tag = "";
            this.grpImportoC1.Text = "Budget anno";
            // 
            // txtCons1
            // 
            this.txtCons1.Location = new System.Drawing.Point(6, 18);
            this.txtCons1.Name = "txtCons1";
            this.txtCons1.ReadOnly = true;
            this.txtCons1.Size = new System.Drawing.Size(104, 20);
            this.txtCons1.TabIndex = 1;
            this.txtCons1.Tag = "";
            this.txtCons1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Consolidato, sui dati salvati, dei livelli sottostanti l\'UPB.";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Location = new System.Drawing.Point(4, 110);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(552, 48);
            this.gboxUPB.TabIndex = 13;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(12, 17);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(75, 23);
            this.btnUPB.TabIndex = 7;
            this.btnUPB.Tag = "choose.upb.default";
            this.btnUPB.Text = "UPB";
            this.btnUPB.UseVisualStyleBackColor = true;
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(105, 19);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(441, 20);
            this.txtUPB.TabIndex = 6;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(566, 17);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(75, 23);
            this.btnSituazione.TabIndex = 12;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.Visible = false;
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCodiceConto);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDenominazioneConto);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 96);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informazioni sul conto";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(128, 24);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.ReadOnly = true;
            this.txtCodiceConto.Size = new System.Drawing.Size(100, 20);
            this.txtCodiceConto.TabIndex = 2;
            this.txtCodiceConto.Tag = "accountyearview.codeacc";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(128, 56);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(416, 32);
            this.txtDenominazioneConto.TabIndex = 3;
            this.txtDenominazioneConto.Tag = "accountyearview.account";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Denominazione";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkUpbChilds);
            this.tabPage3.Controls.Add(this.btnCalcolaTotali);
            this.tabPage3.Controls.Add(this.tabControl3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(712, 500);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Riepilogo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkUpbChilds
            // 
            this.chkUpbChilds.AutoSize = true;
            this.chkUpbChilds.Location = new System.Drawing.Point(12, 11);
            this.chkUpbChilds.Name = "chkUpbChilds";
            this.chkUpbChilds.Size = new System.Drawing.Size(285, 17);
            this.chkUpbChilds.TabIndex = 73;
            this.chkUpbChilds.Text = "Considera anche gli UPB sottostanti nei dati di riepilogo";
            this.chkUpbChilds.UseVisualStyleBackColor = true;
            this.chkUpbChilds.CheckedChanged += new System.EventHandler(this.chkUpbChilds_CheckedChanged);
            // 
            // btnCalcolaTotali
            // 
            this.btnCalcolaTotali.Location = new System.Drawing.Point(422, 11);
            this.btnCalcolaTotali.Name = "btnCalcolaTotali";
            this.btnCalcolaTotali.Size = new System.Drawing.Size(105, 25);
            this.btnCalcolaTotali.TabIndex = 72;
            this.btnCalcolaTotali.Text = "Calcola totali";
            this.btnCalcolaTotali.UseVisualStyleBackColor = true;
            this.btnCalcolaTotali.Click += new System.EventHandler(this.btnCalcolaTotali_Click);
            // 
            // tabControl3
            // 
            this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl3.Controls.Add(this.tabPage4);
            this.tabControl3.Location = new System.Drawing.Point(8, 52);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(696, 413);
            this.tabControl3.TabIndex = 71;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnScrittureDare);
            this.tabPage4.Controls.Add(this.btnScrittureAvere);
            this.tabPage4.Controls.Add(this.btnVarAccertamenti);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.txtVarAccertamenti);
            this.tabPage4.Controls.Add(this.txtVarPreaccertamenti);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.btnVarPreaccertamenti);
            this.tabPage4.Controls.Add(this.btnAccertamentiBudget);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.txtAccertamentiBudget);
            this.tabPage4.Controls.Add(this.txtPreaccertamentiBudget);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.btnPreaccertamentiBudget);
            this.tabPage4.Controls.Add(this.txtScrittureAvere);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.txtScrittureDare);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.txtBudgetAttuale);
            this.tabPage4.Controls.Add(this.btnVarImpegni);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.txtVarImpegni);
            this.tabPage4.Controls.Add(this.txtVarPreimpegni);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.btnVarPreimpegni);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.btnImpegniBudget);
            this.tabPage4.Controls.Add(this.txtBudgetIniziale);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.btnBudgetIniziale);
            this.tabPage4.Controls.Add(this.txtImpegniBudget);
            this.tabPage4.Controls.Add(this.txtPreimpegniBudget);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.btnVarBudget);
            this.tabPage4.Controls.Add(this.btnPreimpegniBudget);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.txtBudgetDisponibile);
            this.tabPage4.Controls.Add(this.txtVariazioniBudget);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(688, 387);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Budget";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnScrittureDare
            // 
            this.btnScrittureDare.Location = new System.Drawing.Point(374, 275);
            this.btnScrittureDare.Name = "btnScrittureDare";
            this.btnScrittureDare.Size = new System.Drawing.Size(44, 20);
            this.btnScrittureDare.TabIndex = 83;
            this.btnScrittureDare.Text = "H";
            this.btnScrittureDare.UseVisualStyleBackColor = true;
            this.btnScrittureDare.Click += new System.EventHandler(this.btnScrittureDare_Click);
            // 
            // btnScrittureAvere
            // 
            this.btnScrittureAvere.Location = new System.Drawing.Point(374, 303);
            this.btnScrittureAvere.Name = "btnScrittureAvere";
            this.btnScrittureAvere.Size = new System.Drawing.Size(44, 20);
            this.btnScrittureAvere.TabIndex = 84;
            this.btnScrittureAvere.Text = "I";
            this.btnScrittureAvere.UseVisualStyleBackColor = true;
            this.btnScrittureAvere.Click += new System.EventHandler(this.btnScrittureAvere_Click);
            // 
            // btnVarAccertamenti
            // 
            this.btnVarAccertamenti.Location = new System.Drawing.Point(424, 208);
            this.btnVarAccertamenti.Name = "btnVarAccertamenti";
            this.btnVarAccertamenti.Size = new System.Drawing.Size(44, 20);
            this.btnVarAccertamenti.TabIndex = 82;
            this.btnVarAccertamenti.Text = "F";
            this.btnVarAccertamenti.UseVisualStyleBackColor = true;
            this.btnVarAccertamenti.Click += new System.EventHandler(this.btnVarAccertamenti_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(470, 211);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(216, 18);
            this.label15.TabIndex = 80;
            this.label15.Text = "Variazioni ad accertamenti di Budget";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVarAccertamenti
            // 
            this.txtVarAccertamenti.Location = new System.Drawing.Point(321, 208);
            this.txtVarAccertamenti.Name = "txtVarAccertamenti";
            this.txtVarAccertamenti.ReadOnly = true;
            this.txtVarAccertamenti.Size = new System.Drawing.Size(97, 20);
            this.txtVarAccertamenti.TabIndex = 81;
            this.txtVarAccertamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarPreaccertamenti
            // 
            this.txtVarPreaccertamenti.Location = new System.Drawing.Point(321, 156);
            this.txtVarPreaccertamenti.Name = "txtVarPreaccertamenti";
            this.txtVarPreaccertamenti.ReadOnly = true;
            this.txtVarPreaccertamenti.Size = new System.Drawing.Size(97, 20);
            this.txtVarPreaccertamenti.TabIndex = 78;
            this.txtVarPreaccertamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(470, 159);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(191, 18);
            this.label16.TabIndex = 77;
            this.label16.Text = "Variazioni a preaccertamenti di Budget";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVarPreaccertamenti
            // 
            this.btnVarPreaccertamenti.Location = new System.Drawing.Point(424, 156);
            this.btnVarPreaccertamenti.Name = "btnVarPreaccertamenti";
            this.btnVarPreaccertamenti.Size = new System.Drawing.Size(44, 20);
            this.btnVarPreaccertamenti.TabIndex = 79;
            this.btnVarPreaccertamenti.Text = "D";
            this.btnVarPreaccertamenti.UseVisualStyleBackColor = true;
            this.btnVarPreaccertamenti.Click += new System.EventHandler(this.btnVarPreaccertamenti_Click);
            // 
            // btnAccertamentiBudget
            // 
            this.btnAccertamentiBudget.Location = new System.Drawing.Point(425, 182);
            this.btnAccertamentiBudget.Name = "btnAccertamentiBudget";
            this.btnAccertamentiBudget.Size = new System.Drawing.Size(44, 20);
            this.btnAccertamentiBudget.TabIndex = 74;
            this.btnAccertamentiBudget.Text = "E";
            this.btnAccertamentiBudget.UseVisualStyleBackColor = true;
            this.btnAccertamentiBudget.Click += new System.EventHandler(this.btnAccertamentiBudget_Click);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(470, 183);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(168, 18);
            this.label17.TabIndex = 68;
            this.label17.Text = "Accertamenti di Budget";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccertamentiBudget
            // 
            this.txtAccertamentiBudget.Location = new System.Drawing.Point(322, 182);
            this.txtAccertamentiBudget.Name = "txtAccertamentiBudget";
            this.txtAccertamentiBudget.ReadOnly = true;
            this.txtAccertamentiBudget.Size = new System.Drawing.Size(97, 20);
            this.txtAccertamentiBudget.TabIndex = 73;
            this.txtAccertamentiBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPreaccertamentiBudget
            // 
            this.txtPreaccertamentiBudget.Location = new System.Drawing.Point(321, 130);
            this.txtPreaccertamentiBudget.Name = "txtPreaccertamentiBudget";
            this.txtPreaccertamentiBudget.ReadOnly = true;
            this.txtPreaccertamentiBudget.Size = new System.Drawing.Size(97, 20);
            this.txtPreaccertamentiBudget.TabIndex = 71;
            this.txtPreaccertamentiBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(474, 133);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(166, 18);
            this.label19.TabIndex = 70;
            this.label19.Text = "Preaccertamenti di Budget";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPreaccertamentiBudget
            // 
            this.btnPreaccertamentiBudget.Location = new System.Drawing.Point(424, 130);
            this.btnPreaccertamentiBudget.Name = "btnPreaccertamentiBudget";
            this.btnPreaccertamentiBudget.Size = new System.Drawing.Size(44, 20);
            this.btnPreaccertamentiBudget.TabIndex = 72;
            this.btnPreaccertamentiBudget.Text = "C";
            this.btnPreaccertamentiBudget.UseVisualStyleBackColor = true;
            this.btnPreaccertamentiBudget.Click += new System.EventHandler(this.btnPreaccertamentiBudget_Click);
            // 
            // txtScrittureAvere
            // 
            this.txtScrittureAvere.Location = new System.Drawing.Point(270, 302);
            this.txtScrittureAvere.Name = "txtScrittureAvere";
            this.txtScrittureAvere.ReadOnly = true;
            this.txtScrittureAvere.Size = new System.Drawing.Size(97, 20);
            this.txtScrittureAvere.TabIndex = 67;
            this.txtScrittureAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(148, 302);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 18);
            this.label14.TabIndex = 66;
            this.label14.Text = "Scritture EP Avere";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtScrittureDare
            // 
            this.txtScrittureDare.Location = new System.Drawing.Point(270, 276);
            this.txtScrittureDare.Name = "txtScrittureDare";
            this.txtScrittureDare.ReadOnly = true;
            this.txtScrittureDare.Size = new System.Drawing.Size(97, 20);
            this.txtScrittureDare.TabIndex = 65;
            this.txtScrittureDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(148, 276);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 18);
            this.label13.TabIndex = 64;
            this.label13.Text = "Scritture EP Dare";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(372, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 18);
            this.label12.TabIndex = 63;
            this.label12.Text = "A + B";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(147, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 61;
            this.label5.Text = "Budget Attuale";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBudgetAttuale
            // 
            this.txtBudgetAttuale.Location = new System.Drawing.Point(269, 98);
            this.txtBudgetAttuale.Name = "txtBudgetAttuale";
            this.txtBudgetAttuale.ReadOnly = true;
            this.txtBudgetAttuale.Size = new System.Drawing.Size(97, 20);
            this.txtBudgetAttuale.TabIndex = 62;
            this.txtBudgetAttuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnVarImpegni
            // 
            this.btnVarImpegni.Location = new System.Drawing.Point(168, 208);
            this.btnVarImpegni.Name = "btnVarImpegni";
            this.btnVarImpegni.Size = new System.Drawing.Size(44, 20);
            this.btnVarImpegni.TabIndex = 60;
            this.btnVarImpegni.Text = "F";
            this.btnVarImpegni.UseVisualStyleBackColor = true;
            this.btnVarImpegni.Click += new System.EventHandler(this.btnVarImpegni_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 18);
            this.label3.TabIndex = 58;
            this.label3.Text = "Variazioni a impegni di Budget";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarImpegni
            // 
            this.txtVarImpegni.Location = new System.Drawing.Point(218, 209);
            this.txtVarImpegni.Name = "txtVarImpegni";
            this.txtVarImpegni.ReadOnly = true;
            this.txtVarImpegni.Size = new System.Drawing.Size(97, 20);
            this.txtVarImpegni.TabIndex = 59;
            this.txtVarImpegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarPreimpegni
            // 
            this.txtVarPreimpegni.Location = new System.Drawing.Point(218, 157);
            this.txtVarPreimpegni.Name = "txtVarPreimpegni";
            this.txtVarPreimpegni.ReadOnly = true;
            this.txtVarPreimpegni.Size = new System.Drawing.Size(97, 20);
            this.txtVarPreimpegni.TabIndex = 56;
            this.txtVarPreimpegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-13, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 18);
            this.label6.TabIndex = 55;
            this.label6.Text = "Variazioni a preimpegni di Budget";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVarPreimpegni
            // 
            this.btnVarPreimpegni.Location = new System.Drawing.Point(168, 156);
            this.btnVarPreimpegni.Name = "btnVarPreimpegni";
            this.btnVarPreimpegni.Size = new System.Drawing.Size(44, 20);
            this.btnVarPreimpegni.TabIndex = 57;
            this.btnVarPreimpegni.Text = "D";
            this.btnVarPreimpegni.UseVisualStyleBackColor = true;
            this.btnVarPreimpegni.Click += new System.EventHandler(this.btnVarPreimpegni_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(147, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 18);
            this.label11.TabIndex = 44;
            this.label11.Text = "Budget iniziale";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnImpegniBudget
            // 
            this.btnImpegniBudget.Location = new System.Drawing.Point(168, 182);
            this.btnImpegniBudget.Name = "btnImpegniBudget";
            this.btnImpegniBudget.Size = new System.Drawing.Size(44, 20);
            this.btnImpegniBudget.TabIndex = 52;
            this.btnImpegniBudget.Text = "E";
            this.btnImpegniBudget.UseVisualStyleBackColor = true;
            this.btnImpegniBudget.Click += new System.EventHandler(this.btnImpegniBudget_Click);
            // 
            // txtBudgetIniziale
            // 
            this.txtBudgetIniziale.Location = new System.Drawing.Point(269, 41);
            this.txtBudgetIniziale.Name = "txtBudgetIniziale";
            this.txtBudgetIniziale.ReadOnly = true;
            this.txtBudgetIniziale.Size = new System.Drawing.Size(97, 20);
            this.txtBudgetIniziale.TabIndex = 45;
            this.txtBudgetIniziale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(42, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 40;
            this.label7.Text = "Impegni di Budget";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBudgetIniziale
            // 
            this.btnBudgetIniziale.Location = new System.Drawing.Point(372, 39);
            this.btnBudgetIniziale.Name = "btnBudgetIniziale";
            this.btnBudgetIniziale.Size = new System.Drawing.Size(44, 20);
            this.btnBudgetIniziale.TabIndex = 46;
            this.btnBudgetIniziale.Text = "A";
            this.btnBudgetIniziale.UseVisualStyleBackColor = true;
            this.btnBudgetIniziale.Click += new System.EventHandler(this.btnBudgetIniziale_Click);
            // 
            // txtImpegniBudget
            // 
            this.txtImpegniBudget.Location = new System.Drawing.Point(218, 183);
            this.txtImpegniBudget.Name = "txtImpegniBudget";
            this.txtImpegniBudget.ReadOnly = true;
            this.txtImpegniBudget.Size = new System.Drawing.Size(97, 20);
            this.txtImpegniBudget.TabIndex = 51;
            this.txtImpegniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPreimpegniBudget
            // 
            this.txtPreimpegniBudget.Location = new System.Drawing.Point(218, 131);
            this.txtPreimpegniBudget.Name = "txtPreimpegniBudget";
            this.txtPreimpegniBudget.ReadOnly = true;
            this.txtPreimpegniBudget.Size = new System.Drawing.Size(97, 20);
            this.txtPreimpegniBudget.TabIndex = 49;
            this.txtPreimpegniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "G = A + B - C - D";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 18);
            this.label10.TabIndex = 43;
            this.label10.Text = "Preimpegni di Budget";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVarBudget
            // 
            this.btnVarBudget.Location = new System.Drawing.Point(372, 69);
            this.btnVarBudget.Name = "btnVarBudget";
            this.btnVarBudget.Size = new System.Drawing.Size(44, 20);
            this.btnVarBudget.TabIndex = 48;
            this.btnVarBudget.Text = "B";
            this.btnVarBudget.UseVisualStyleBackColor = true;
            this.btnVarBudget.Click += new System.EventHandler(this.btnVarBudget_Click);
            // 
            // btnPreimpegniBudget
            // 
            this.btnPreimpegniBudget.Location = new System.Drawing.Point(168, 130);
            this.btnPreimpegniBudget.Name = "btnPreimpegniBudget";
            this.btnPreimpegniBudget.Size = new System.Drawing.Size(44, 20);
            this.btnPreimpegniBudget.TabIndex = 50;
            this.btnPreimpegniBudget.Text = "C";
            this.btnPreimpegniBudget.UseVisualStyleBackColor = true;
            this.btnPreimpegniBudget.Click += new System.EventHandler(this.btnPreimpegniBudget_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(147, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 18);
            this.label9.TabIndex = 41;
            this.label9.Text = "Variazione Budget";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBudgetDisponibile
            // 
            this.txtBudgetDisponibile.Location = new System.Drawing.Point(269, 250);
            this.txtBudgetDisponibile.Name = "txtBudgetDisponibile";
            this.txtBudgetDisponibile.ReadOnly = true;
            this.txtBudgetDisponibile.Size = new System.Drawing.Size(97, 20);
            this.txtBudgetDisponibile.TabIndex = 53;
            this.txtBudgetDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVariazioniBudget
            // 
            this.txtVariazioniBudget.Location = new System.Drawing.Point(269, 70);
            this.txtVariazioniBudget.Name = "txtVariazioniBudget";
            this.txtVariazioniBudget.ReadOnly = true;
            this.txtVariazioniBudget.Size = new System.Drawing.Size(97, 20);
            this.txtVariazioniBudget.TabIndex = 47;
            this.txtVariazioniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(147, 250);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(116, 18);
            this.label18.TabIndex = 42;
            this.label18.Text = "Budget disponibile";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(216, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 526);
            this.splitter1.TabIndex = 19;
            this.splitter1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.icons;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(216, 526);
            this.treeView1.TabIndex = 18;
            this.treeView1.Tag = "accountyearview.tree";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // FrmAccountYearView_Default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(939, 526);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmAccountYearView_Default";
            this.Text = "FrmAccountYearView_Default";
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpImporto5.ResumeLayout(false);
            this.grpImporto5.PerformLayout();
            this.grpImporto4.ResumeLayout(false);
            this.grpImporto4.PerformLayout();
            this.grpImporto3.ResumeLayout(false);
            this.grpImporto3.PerformLayout();
            this.grpImporto2.ResumeLayout(false);
            this.grpImporto2.PerformLayout();
            this.grpImporto1.ResumeLayout(false);
            this.grpImporto1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.grpImportoC5.ResumeLayout(false);
            this.grpImportoC5.PerformLayout();
            this.grpImportoC4.ResumeLayout(false);
            this.grpImportoC4.PerformLayout();
            this.grpImportoC3.ResumeLayout(false);
            this.grpImportoC3.PerformLayout();
            this.grpImportoC2.ResumeLayout(false);
            this.grpImportoC2.PerformLayout();
            this.grpImportoC1.ResumeLayout(false);
            this.grpImportoC1.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        
        public object MAIN_idacc;

        public void MetaData_AfterLink() {
            QueryCreator.SetTableForPosting(DS.accountyearview, "accountyear");
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            object idAccount = Meta.ExtraParameter;
            int esercizio = (int)Meta.GetSys("esercizio");
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);

            string filter = QHS.AppAnd(QHS.CmpEq("idacc", idAccount), filterEsercizio);
            DataTable AccTable = Meta.Conn.RUN_SELECT("account", "idacc,paridacc,codeacc,title,nlevel", null, filter, null, null, true);
            if (AccTable.Rows.Count > 0) {
                DataRow AccRow = AccTable.Rows[0];
                MetaData.SetDefault(DS.accountyearview, "idacc", AccRow["idacc"]);
                MetaData.SetDefault(DS.accountyearview, "paridacc", AccRow["paridacc"]);
                MetaData.SetDefault(DS.accountyearview, "codeacc", AccRow["codeacc"]);
                MetaData.SetDefault(DS.accountyearview, "account", AccRow["title"]);
                MetaData.SetDefault(DS.accountyearview, "nlevel", AccRow["nlevel"]);
            }
            string filterLevel = QHS.AppAnd(filterEsercizio, QHS.CmpEq("flagusable", "S"));
            object level = Meta.Conn.DO_READ_VALUE("accountlevel", filterLevel, "min(nlevel)");

            if ((level != null) && (level != DBNull.Value)) {
                int levelAcc = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idAccount), "nlevel"));
                isContoOperativo = (levelAcc >= Convert.ToInt32(level));
            }
            Meta.CanInsert = isContoOperativo;
            Meta.CanSave = isContoOperativo;
            //DataTable tabellaPerTree = DataAccess.RUN_SELECT(Meta.Conn,"finyearview","*","codeupb",filter,null,null,true);
            //HelpForm.SetFilterToTree(DS.finyearview,tabellaPerTree);

            GetData.SetStaticFilter(DS.accountyearview, filter);

            DS.accountyearview.ExtendedProperties["idacc"] = idAccount;
            MAIN_idacc = idAccount;

            GetData.SetStaticFilter(DS.accountyear, filter);
            GetData.SetStaticFilter(DS.accountyearview, filter);
            GetData.CacheTable(DS.account, filterEsercizio, null, false);

            cambiaEtichetteEsercizi();

			
		}

        public void MetaData_AfterActivation() {
            azzeraTxtConsolidato();
            if (treeView1.Nodes.Count > 0) {
                if (!treeView1.Nodes[0].IsExpanded) {
                    treeView1.Nodes[0].Expand();
                }
            }
           
        }

        private void cambiaEtichetteEsercizi() {
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            grpImporto1.Text = esercizioCurr.ToString();
            grpImportoC1.Text = esercizioCurr.ToString();

            grpImporto2.Text = (++esercizioCurr).ToString();
            grpImportoC2.Text = esercizioCurr.ToString();

            grpImporto3.Text = (++esercizioCurr).ToString();
            grpImportoC3.Text = esercizioCurr.ToString();

            grpImporto4.Text = (++esercizioCurr).ToString();
            grpImportoC4.Text = esercizioCurr.ToString();

            grpImporto5.Text = (++esercizioCurr).ToString();
            grpImportoC5.Text = esercizioCurr.ToString();

            txtImporto1.ReadOnly = !Meta.CanSave;
            txtImporto2.ReadOnly = !Meta.CanSave;
            txtImporto3.ReadOnly = !Meta.CanSave;
            txtImporto4.ReadOnly = !Meta.CanSave;
            txtImporto5.ReadOnly = !Meta.CanSave;
        }

        bool NoUpbSelected = true;
        public void MetaData_AfterClear() {
            btnUPB.Enabled = true;
            FiltraSelezioneUPB(null);
            azzeraTxtConsolidato();
            btnSituazione.Enabled = true;
            NoUpbSelected = true;
        }




        private void azzeraTxtConsolidato() {
            string empty = "";
            txtCons1.Text = empty;
            txtCons2.Text = empty;
            txtCons3.Text = empty;
            txtCons4.Text = empty;
            txtCons5.Text = empty;
        }

        public void MetaData_AfterFill() {
            if (Meta.InsertMode) {
                azzeraTxtConsolidato();
                btnSituazione.Enabled = false;
            }
            else {
                azzeraTxtConsolidato();
                btnSituazione.Enabled = true;
            }
            if (Meta.InsertMode) {
                AbilitaBottoni(false);
            }
            else {
                DataRow R = HelpForm.GetLastSelected(DS.accountyearview);
                if (R == null)
                    return;
                //if (Operativo(R)) {
                    AbilitaBottoni(true);
                //}
                //else {
                //    AbilitaBottoni(false);
                //    pulisciTextRiepilogo();
                //}
            }
        }
        private void pulisciTextRiepilogo() {
            txtBudgetIniziale.Text = "";
            txtVariazioniBudget.Text = "";
            txtPreimpegniBudget.Text = "";
            txtImpegniBudget.Text = "";
            txtBudgetDisponibile.Text = "";
            txtBudgetAttuale.Text = "";
            txtVarImpegni.Text = "";
            txtVarPreimpegni.Text = "";

            txtPreaccertamentiBudget.Text = "";
            txtAccertamentiBudget.Text = "";
            txtVarAccertamenti.Text = "";
            txtVarPreaccertamenti.Text = "";
            txtScrittureAvere.Text = "";
            txtScrittureDare.Text = "";
        }
        private void AbilitaBottoni(bool Enable) {
            btnBudgetIniziale.Enabled = Enable;
            btnVarBudget.Enabled = Enable;
            btnPreimpegniBudget.Enabled = Enable;
            btnImpegniBudget.Enabled = Enable;
            btnCalcolaTotali.Enabled = Enable;
            btnVarImpegni.Enabled = Enable;
            btnVarPreimpegni.Enabled = Enable;

        }
        public void MetaData_BeforeFill() {
            if (!Meta.InsertMode)
                return;
            if (NoUpbSelected) {
                FiltraSelezioneUPB(QHS.IsNull("paridupb"));
            }
            else {
                DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
                string filter = QHS.CmpEq("paridupb", Curr["paridupb"]);
                FiltraSelezioneUPB(filter);
            }
        }

        object GetUpb() {
            return Meta.GetAutoField(txtUPB);
        }
        void SetUPB(DataRow Curr, object idupb) {
            if (Curr != null)
                Curr["idupb"] = idupb;

            Meta.SetAutoField(idupb, txtUPB);
        }

        void FiltraSelezioneUPB(string filter) {
            MetaData.AutoInfo AI = Meta.GetAutoInfo(txtUPB.Name);
            string myfilter = null;
            if (Meta.InsertMode)
                myfilter = QHS.FieldNotInList("idupb", QHS.DistinctVal(DS.accountyearview.Select(), "idupb"));
            filter = QHS.AppAnd(myfilter, filter);
            AI.startfilter = filter;

            btnUPB.Tag = "choose.upb.default." + filter;
        }

        private void calcolaConsolidato() {
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null) {
                azzeraTxtConsolidato();
                return;
            }


            decimal previsioneCorr = 0;
            decimal previsioneAnno2 = 0;
            decimal previsioneAnno3 = 0;
            decimal previsioneAnno4 = 0;
            decimal previsioneAnno5 = 0;
            string filtro = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", Curr["idupb"]), "(paridupb LIKE '" + Curr["idupb"] + "%')"));
            filtro = QHS.AppAnd(filtro, QHS.CmpEq("idacc", MAIN_idacc));
            string expr = "";
            foreach (string field in new string[]{"prevision","prevision2","prevision3","prevision4","prevision5"}) {
                if (expr != "")
                    expr += ",";
                expr += "SUM(" + field + ") as " + field;
            }
            DataTable T = Conn.SQLRunner("SELECT " + expr + " FROM accountyearview WHERE " + filtro, false);

            foreach (DataRow rAccYear in T.Select()) {
                previsioneCorr += (decimal)isNull(rAccYear["prevision"], 0m);
                previsioneAnno2 += (decimal)isNull(rAccYear["prevision2"], 0m);
                previsioneAnno3 += (decimal)isNull(rAccYear["prevision3"], 0m);
                previsioneAnno4 += (decimal)isNull(rAccYear["prevision4"], 0m);
                previsioneAnno5 += (decimal)isNull(rAccYear["prevision5"], 0m);
            }

            txtCons1.Text = previsioneCorr.ToString("c");
            txtCons2.Text = previsioneAnno2.ToString("c");
            txtCons3.Text = previsioneAnno3.ToString("c");
            txtCons4.Text = previsioneAnno4.ToString("c");
            txtCons5.Text = previsioneAnno5.ToString("c");
        }

        private object isNull(object a, object b) {
            return ((a == null) || (a == DBNull.Value)) ? b : a;
        }

        private void impostaCampiDaSalvare(bool salva) {
            string[] listacampi = new string[] {"account", "codeacc","paridacc","upb","codeupb","paridupb",
                        "nlevel","leveldescr","idsor01","idsor02","idsor03","idsor04","idsor05"};
            if (!salva) {
                string empty = "";
                foreach (string field in listacampi) {
                    QueryCreator.SetColumnNameForPosting(DS.accountyearview.Columns[field], empty);
                }
            }
            else {
                foreach (string field in listacampi) {
                    QueryCreator.SetColumnNameForPosting(DS.accountyearview.Columns[field], field);
                }
            }
        }

        public void MetaData_BeforePost() {
            impostaCampiDaSalvare(false);
        }

        public void MetaData_AfterPost() {
            impostaCampiDaSalvare(true);
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty)
                return;
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (T.TableName == "upb") {
                if (Meta.InsertMode) {
                    if (R == null)
                        return;
                    Curr["codeupb"] = R["codeupb"];
                    Curr["upb"] = R["title"];
                    Curr["paridupb"] = R["paridupb"];
                }
            }
            if (T.TableName == "accountyearview") {
                abilitaDisabilitaInserimento();
                FiltraSelezioneUPB(null);
                if (Curr != null) {
                    SetUPB(Curr, Curr["idupb"]);
                }
                else {
                    SetUPB(null, DBNull.Value);
                }
                azzeraTxtConsolidato();
                pulisciTextRiepilogo();
            }
        }

        private void abilitaDisabilitaInserimento() {
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            string filter;
            if (Curr == null || NoUpbSelected) {
                filter = QHS.IsNull("paridupb");
            }
            else {
                filter = QHS.CmpEq("paridupb", Curr["idupb"]);
            }
            DataTable Childs = Conn.RUN_SELECT("upb", "idupb", null, filter, null, false);
            DataRow[] nFigli = Childs.Select();
            int NOK = 0;
            foreach (DataRow drUpb in nFigli) {
                // Se esiste gi‡ una imputazione per l'UPB selezionato non devo inserirlo nel combo in caso di inserimento
                DataRow[] rowFin = DS.accountyearview.Select(QHS.CmpEq("idupb", drUpb["idupb"]));
                if (rowFin.Length > 0)
                    continue;
                NOK++;
            }

            Meta.CanInsert = (NOK >= 1) && isContoOperativo;
            Meta.FreshToolBar();
        }


      

        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
            //			if (Meta.IsEmpty)return;
            TreeNode TN = e.Node;
            NoUpbSelected = false;
            if (TN.Tag != null)
                return;
            NoUpbSelected = true;
        }

        private void btnCalcola_Click(object sender, EventArgs e) {
            calcolaConsolidato();
        }

        private void btnSituazione_Click(object sender, EventArgs e) {
            object idAccount;
            object idUpb;

            DataRow MyRow = HelpForm.GetLastSelected(DS.accountyearview);
            if (MyRow == null)
                return;
            idAccount = MyRow["idacc"];
            idUpb = MyRow["idupb"];


            DataSet Out = Meta.Conn.CallSP("show_accountyear",
                new Object[3] {Meta.GetSys("datacontabile"),
								  idUpb, idAccount}
                );
            if (Out == null)
                return;
            Out.Tables[0].TableName = "Situazione Budget - U.P.B.";
            frmSituazioneViewer view = new frmSituazioneViewer(Out);
            view.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object idConto;
            object idUpb;

            DataRow MyRow = HelpForm.GetLastSelected(DS.accountyearview);
            if (MyRow == null) return;
            idConto = MyRow["idacc"];
            idUpb = MyRow["idupb"];

            DataSet Out = Meta.Conn.CallSP("show_budget",
                new Object[3] {Meta.GetSys("datacontabile"),
								  idUpb, idConto}
                );
            if (Out == null) return;
            Out.Tables[0].TableName = "Situazione di Budget Conto - UPB ";
            frmSituazioneViewer view = new frmSituazioneViewer(Out);
            view.Show();
        }

        private Decimal CK(Object O) {
            if (O == DBNull.Value)
                return 0;
            return CfgFn.GetNoNullDecimal(O);
        }
        private decimal BudgetIniziale() {
            decimal valore;
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return 0;
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", Curr["idacc"]));
            if (chkUpbChilds.Checked) {
                filter = QHS.AppAnd(filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));

            filter = QHS.AppAnd(filter, Meta.Conn.SelectCondition("accountyearview", true));
            string strExpr = "SUM(prevision)";
            valore = CK(Meta.Conn.DO_READ_VALUE("accountyearview", filter, strExpr));
            return valore;
        }

        private decimal VariazioniBudget() {
            decimal valore;
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return 0;
            //1   Normale
            //2   Ripartizione
            //3   Assestamento
            //4   Storno
            //5   Iniziale
            string filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idaccountvarstatus", "5"));
            filter = QHS.AppAnd(filter, QHS.FieldInList("variationkind", "1,3,4"));
            filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            filter = QHS.AppAnd(filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                filter = QHS.AppAnd(filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            filter = QHS.AppAnd(filter, Meta.Conn.SelectCondition("accountvardetailview", true));
            string strExpr = "SUM(amount)";
            valore = CK(Meta.Conn.DO_READ_VALUE("accountvardetailview", filter, strExpr));
            return valore;
        }
        private decimal PreimpegniPreaccertamentiBudget(string kind) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return 0;
            Filter = QHS.CmpEq("E.nphase", "1");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("EY.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.idupb", Curr["idupb"]));
            }

            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            // quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
            string sql = "";
            if (kind == "I") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EY.amount ELSE -EY.amount END ) as amount from epexpyear EY " +
                        "JOIN epexp E on EY.idepexp = E.idepexp " +
                        "JOIN upb U on EY.idupb = U.idupb " +
                        " WHERE " + Filter;
            }
            if (kind == "A") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EY.amount ELSE -EY.amount END ) as amount from epaccyear EY " +
                        "JOIN epacc E on EY.idepacc = E.idepacc " +
                        "JOIN upb U on EY.idupb = U.idupb " +
                        " WHERE " + Filter;
            }
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }
        private decimal VariazioniPreimpPreaccBudget(string kind) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return 0;

            // Le var. dei suddetti impegni.
            Filter = QHS.CmpEq("E.nphase", "1");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("EY.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "";
            if (kind == "I") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EV.amount ELSE -EV.amount END) as amount from epexpyear EY " +
                    "JOIN epexp E on EY.idepexp = E.idepexp " +
                    "JOIN epexpvar EV on EV.idepexp = EY.idepexp " +
                    "JOIN upb U on EY.idupb = U.idupb " +
                    " WHERE " + Filter;
            }
            if (kind == "A") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EV.amount ELSE -EV.amount END) as amount from epaccyear EY " +
                        "JOIN epacc E on EY.idepacc = E.idepacc " +
                        "JOIN epaccvar EV on EV.idepacc = EY.idepacc " +
                        "JOIN upb U on EY.idupb = U.idupb " +
                        " WHERE " + Filter;
            }
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }

        private decimal ImpegniAccertamentiBudget(string kind) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return 0;
            Filter = QHS.CmpEq("E.nphase", "2");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("EY.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "";
            // quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
            if (kind == "I") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EY.amount ELSE -EY.amount END) as amount from epexpyear EY " +
                             "JOIN epexp E on EY.idepexp = E.idepexp " +
                             "JOIN upb U on EY.idupb = U.idupb " +
                             " WHERE " + Filter;
            }
            if (kind == "A") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EY.amount ELSE -EY.amount END) as amount from epaccyear EY " +
                         "JOIN epacc E on EY.idepacc = E.idepacc " +
                         "JOIN upb U on EY.idupb = U.idupb " +
                         " WHERE " + Filter;
            }
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }

        private decimal ScrittureDare() {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return 0;
            Filter = QHS.CmpLt("D.amount", "0");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("D.yentry", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.Like("D.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("D.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("D.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "SELECT - SUM(D.amount) as amount from entrydetailview D " +
                             " WHERE " + Filter;
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }
        private decimal ScrittureAvere() {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return 0;
            Filter = QHS.CmpGt("D.amount", "0");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("D.yentry", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.Like("D.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("D.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("D.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "SELECT SUM(D.amount) as amount from entrydetailview D " +
                             " WHERE " + Filter;
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);

            return valore;
        }
        private decimal VariazioniImpAccBudget(string kind) {
            decimal valore;
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return 0;


            // Aggiungiamo le var. dei suddetti impegni.
            Filter = QHS.CmpEq("E.nphase", "2");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.Like("EY.idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("EY.idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));
            string sql = "";
            if (kind == "I") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EV.amount ELSE -EV.amount END) as amount from epexpyear EY " +
                            "JOIN epexp E on EY.idepexp = E.idepexp " +
                            "JOIN epexpvar EV on EV.idepexp = EY.idepexp " +
                            "JOIN upb U on EY.idupb = U.idupb " +
                            " WHERE " + Filter;
            }
            if (kind == "A") {
                sql = "SELECT SUM(CASE WHEN(E.flagvariation ='N') then EV.amount ELSE -EV.amount END) as amount from epaccyear EY " +
                            "JOIN epacc E on EY.idepacc = E.idepacc " +
                            "JOIN epaccvar EV on EV.idepacc = EY.idepacc " +
                            "JOIN upb U on EY.idupb = U.idupb " +
                            " WHERE " + Filter;
            }
            valore = CK(Meta.Conn.SQLRunner(sql, false).Rows[0]["amount"]);
            return valore;
        }
        private void btnCalcolaTotali_Click(object sender, EventArgs e) {
            decimal budgetIni = BudgetIniziale();
            txtBudgetIniziale.Text = budgetIni.ToString("c");

            decimal varBudget = VariazioniBudget();
            txtVariazioniBudget.Text = varBudget.ToString("c");

            decimal BudgetAttuale = budgetIni + varBudget;
            txtBudgetAttuale.Text = BudgetAttuale.ToString("c");
            decimal preImp = PreimpegniPreaccertamentiBudget("I");
            txtPreimpegniBudget.Text = preImp.ToString("c");
            decimal preAcc = PreimpegniPreaccertamentiBudget("A");
            txtPreaccertamentiBudget.Text = preAcc.ToString("c");

            decimal varPreImp = VariazioniPreimpPreaccBudget("I");
            txtVarPreimpegni.Text = varPreImp.ToString("c");
            decimal varPreAcc = VariazioniPreimpPreaccBudget("A");
            txtVarPreaccertamenti.Text = varPreAcc.ToString("c");

            txtImpegniBudget.Text = ImpegniAccertamentiBudget("I").ToString("c");
            txtAccertamentiBudget.Text = ImpegniAccertamentiBudget("A").ToString("c");
            txtVarImpegni.Text = VariazioniImpAccBudget("I").ToString("c");
            txtVarAccertamenti.Text = VariazioniImpAccBudget("A").ToString("c");
            txtBudgetDisponibile.Text = (budgetIni + varBudget - preImp - preAcc - varPreImp - varPreAcc).ToString("c");
            decimal ScrittureEPdare = ScrittureDare();
            txtScrittureDare.Text = ScrittureEPdare.ToString("c");

            decimal ScrittureEPavere = ScrittureAvere();
            txtScrittureAvere.Text = ScrittureEPavere.ToString("c");
        }

        private void chkUpbChilds_CheckedChanged(object sender, EventArgs e) {
            pulisciTextRiepilogo();
        }

        private void SelezionaBudget(DataRow MyDR) {
            MetaData newAccyearView = Meta.Dispatcher.Get("accountyearview");
            newAccyearView.ExtraParameter = MyDR["idacc"];
            newAccyearView.Edit(this.ParentForm, "default", false);
            DataRow R2 = newAccyearView.SelectOne(newAccyearView.DefaultListType,
                 QHS.AppAnd(QHS.CmpEq("idacc", MyDR["idacc"]),
                               QHS.CmpEq("idupb", MyDR["idupb"])), "accountyearview", null);
            if (R2 != null)
                newAccyearView.SelectRow(R2, newAccyearView.DefaultListType);
        }
        private void btnBudgetIniziale_Click(object sender, EventArgs e) {
            string VistaScelta;
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return;
            int esercizioCurr = (int)Meta.GetSys("esercizio");

            //Previsione corrente (principale)
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", Curr["idacc"]));
            filter = QHS.AppAnd(filter, QHS.CmpNe("prevision", 0));
            if (chkUpbChilds.Checked) {
                filter = QHS.AppAnd(filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }

            VistaScelta = "accountyearview";
            MetaData MFinyearView = MetaData.GetMetaData(this, VistaScelta);
            MFinyearView.FilterLocked = true;
            MFinyearView.DS = DS;

            DataRow MyDR = MFinyearView.SelectOne("default", filter, null, null);

            if (MyDR != null) {
                SelezionaBudget(MyDR);
            }
        }

        private void SelezionaVariazione(DataRow MyDR) {
            MetaData newAccVarDetail = Meta.Dispatcher.Get("accountvardetail");

            newAccVarDetail.Edit(this.ParentForm, "default", false);
            DataRow R2 = newAccVarDetail.SelectOne("lista",
                QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]),
                QHS.CmpEq("nvar", MyDR["nvar"]), QHS.CmpEq("rownum", MyDR["rownum"])),
                "accountvardetail", null);
            if (R2 != null)
                newAccVarDetail.SelectRow(R2, "lista");
        }
        private void btnVarBudget_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return;

            /*
             *  1	Normale
                2	Ripartizione
                3	Assestamento
                4	Storno
                5	Iniziale
             * */
            string filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idaccountvarstatus", "5"));
            filter = QHS.AppAnd(filter, QHS.FieldInList("variationkind", "1,3,4"));
            filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            filter = QHS.AppAnd(filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                filter = QHS.AppAnd(filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "accountvardetailview";
            MetaData MFinVarDetail = MetaData.GetMetaData(this, VistaScelta);
            MFinVarDetail.FilterLocked = true;
            MFinVarDetail.DS = DS;
            DataRow MyDR = MFinVarDetail.SelectOne("listaestesa", filter, null, null);

            if (MyDR != null) {
                SelezionaVariazione(MyDR);
            }
        }

        private void btnPreimpegniBudget_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "1");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "epexpview";
            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("default", Filter, null, null);
            if (MyDR != null) {
                MetaData newSpesa = Meta.Dispatcher.Get("epexp");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idepexp", MyDR["idepexp"]), "epexp", null);
                if (R2 != null)
                    newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }

        private void btnVarPreimpegni_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "1");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string VistaScelta = "epexpvarview";
            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newVarSpesa = Meta.Dispatcher.Get("epexpvar");
                newVarSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("idepexp", MyDR["idepexp"]), QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("nvar", MyDR["nvar"])), "epexpvar", null);
                if (R2 != null)
                    newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
            }
        }

        private void btnImpegniBudget_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return;
            Filter = QHS.CmpEq("nphase", "2");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "epexpview";
            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("default", Filter, null, null);
            if (MyDR != null) {
                MetaData newSpesa = Meta.Dispatcher.Get("epexp");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idepexp", MyDR["idepexp"]), "epexp", null);
                if (R2 != null)
                    newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }

        private void btnVarImpegni_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "2");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string VistaScelta = "epexpvarview";
            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newVarSpesa = Meta.Dispatcher.Get("epexpvar");
                newVarSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("idepexp", MyDR["idepexp"]), QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("yvar", MyDR["yvar"])), "epexpvar", null);
                if (R2 != null)
                    newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
            }
        }

        private void btnPreaccertamentiBudget_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "1");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "epaccview";
            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("default", Filter, null, null);
            if (MyDR != null) {
                MetaData newSpesa = Meta.Dispatcher.Get("epacc");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idepacc", MyDR["idepacc"]), "epacc", null);
                if (R2 != null)
                    newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }

        private void btnVarPreaccertamenti_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "1");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string VistaScelta = "epaccvarview";
            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newVarSpesa = Meta.Dispatcher.Get("epaccvar");
                newVarSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("idepacc", MyDR["idepacc"]), QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("yvar", MyDR["yvar"])), "epaccvar", null);
                if (R2 != null)
                    newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
            }
        }

        private void btnAccertamentiBudget_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null)
                return;
            Filter = QHS.CmpEq("nphase", "2");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "epaccview";
            MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
            MImpegni.FilterLocked = true;
            MImpegni.DS = DS;
            DataRow MyDR = MImpegni.SelectOne("default", Filter, null, null);
            if (MyDR != null) {
                MetaData newSpesa = Meta.Dispatcher.Get("epacc");
                newSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
                    QHS.CmpEq("idepacc", MyDR["idepacc"]), "epacc", null);
                if (R2 != null)
                    newSpesa.SelectRow(R2, newSpesa.DefaultListType);
            }
        }

        private void btnVarAccertamenti_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null) return;
            Filter = QHS.CmpEq("nphase", "2");
            //Filter = QHS.AppAnd(Filter, QHS.CmpEq("E.yepexp", Meta.GetSys("esercizio"))); task 8469
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
            Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, Meta.Conn.SelectCondition("upb", true));

            string VistaScelta = "epaccvarview";
            MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
            MVarImpegni.FilterLocked = true;
            MVarImpegni.DS = DS;
            DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
            if (MyDR != null) {
                MetaData newVarSpesa = Meta.Dispatcher.Get("epaccvar");
                newVarSpesa.Edit(this.ParentForm, "default", false);
                DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
                    QHS.AppAnd(QHS.CmpEq("idepacc", MyDR["idepacc"]), QHS.CmpEq("yvar", MyDR["yvar"]), QHS.CmpEq("yvar", MyDR["yvar"])), "epaccvar", null);
                if (R2 != null)
                    newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
            }
        }

        private void btnScrittureDare_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null) return;
            Filter = QHS.CmpLt("amount", "0");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yentry", Meta.GetSys("esercizio")));
            //Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "entrydetailview";
            MetaData MDettScritture = MetaData.GetMetaData(this, VistaScelta);
            MDettScritture.FilterLocked = true;
            MDettScritture.DS = DS;
            DataRow MyDR = MDettScritture.SelectOne("listaestesa", Filter, null, null);
            if (MyDR != null) {
                MetaData newDettScrittura = Meta.Dispatcher.Get("entrydetail");
                newDettScrittura.Edit(this.ParentForm, "default", false);
                DataRow R2 = newDettScrittura.SelectOne(newDettScrittura.DefaultListType,
                        QHS.AppAnd(QHS.CmpEq("nentry", MyDR["nentry"]), QHS.CmpEq("yentry", MyDR["yentry"]),
                        QHS.CmpEq("ndetail", MyDR["ndetail"])), "entrydetail", null);
                if (R2 != null)
                    newDettScrittura.SelectRow(R2, newDettScrittura.DefaultListType);
            }
        }

        private void btnScrittureAvere_Click(object sender, EventArgs e) {
            string Filter = "";
            DataRow Curr = HelpForm.GetLastSelected(DS.accountyearview);
            if (Curr == null) return;
            Filter = QHS.CmpGt("amount", "0");
            Filter = QHS.AppAnd(Filter, QHS.CmpEq("yentry", Meta.GetSys("esercizio")));
            //Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
            Filter = QHS.AppAnd(Filter, QHS.Like("idacc", Curr["idacc"].ToString() + "%"));
            if (chkUpbChilds.Checked) {
                Filter = QHS.AppAnd(Filter, QHS.Like("idupb", Curr["idupb"].ToString() + "%"));
            }
            else {
                Filter = QHS.AppAnd(Filter, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            string VistaScelta = "entrydetailview";
            MetaData MDettScritture = MetaData.GetMetaData(this, VistaScelta);
            MDettScritture.FilterLocked = true;
            MDettScritture.DS = DS;
            DataRow MyDR = MDettScritture.SelectOne("listaestesa", Filter, null, null);
            if (MyDR != null) {
                MetaData newDettScrittura = Meta.Dispatcher.Get("entrydetail");
                newDettScrittura.Edit(this.ParentForm, "default", false);
                DataRow R2 = newDettScrittura.SelectOne(newDettScrittura.DefaultListType,
                        QHS.AppAnd(QHS.CmpEq("nentry", MyDR["nentry"]), QHS.CmpEq("yentry", MyDR["yentry"]),
                        QHS.CmpEq("ndetail", MyDR["ndetail"])), "entrydetail", null);
                if (R2 != null)
                    newDettScrittura.SelectRow(R2, newDettScrittura.DefaultListType);
            }
        }
    }
}