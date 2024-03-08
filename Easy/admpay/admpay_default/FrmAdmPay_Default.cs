
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.Data.OleDb;
using funzioni_configurazione;
using System.IO;
using metaeasylibrary;
using movimentofunctions;
using ep_functions;

namespace admpay_default {
	/// <summary>
	/// Summary description for FrmAdmPay_Default.
	/// </summary>
	public class FrmAdmPay_Default : MetaDataForm {
		MetaData Meta;
		string ConnectionString;
        /// <summary>
        /// Contenuto del foglio Excel, letto dal metodo ReadCurrentSheet a sua volta chiamato da LeggiFile
        /// </summary>
		DataTable mData = new DataTable();

        DataTable mDataGrouped = new DataTable();
		DataTable tErrorLog = new DataTable();
        enum TipoOperazione { Lordi, Reversali, Contributi };
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnDelAppropriation;
		private System.Windows.Forms.Button btnEditAppropriation;
        private System.Windows.Forms.Button btnInsertAppropriation;
		private System.Windows.Forms.TextBox txtEsercAdmPay;
		private System.Windows.Forms.TextBox txtNumAdmPay;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.DataGrid DGridImpegni;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtImportoAssegnare;
		private System.Windows.Forms.Button btnGenera;
		private System.Windows.Forms.OpenFileDialog _openFileDialog1;
		public admpay_default.dsImport dsImport;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnGeneraMovFin;
        public admpay_default.dsFinancial dsFinancial;
        private GroupBox groupBox4;
        private Button btnDelAssessment;
        private Button btnEditAssessment;
        private Button btnInsertAssessment;
        private DataGrid DGridAccertamenti;
        public vistaForm DS;
        private TabControl tabControl1;
        private TabPage tabGenerale;
        private TabPage tabEP;
        private Button btnVisualizzaEP_V;
        private Button btnVisualizzaEP_R;
        private Button btnVisualizzaEP_L;
        public IOpenFileDialog openFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmAdmPay_Default() {
			InitializeComponent();
            openFileDialog1 = createOpenFileDialog(_openFileDialog1);
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercAdmPay = new System.Windows.Forms.TextBox();
            this.txtNumAdmPay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelAppropriation = new System.Windows.Forms.Button();
            this.btnEditAppropriation = new System.Windows.Forms.Button();
            this.btnInsertAppropriation = new System.Windows.Forms.Button();
            this.DGridImpegni = new System.Windows.Forms.DataGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImportoAssegnare = new System.Windows.Forms.TextBox();
            this.btnGenera = new System.Windows.Forms.Button();
            this._openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGeneraMovFin = new System.Windows.Forms.Button();
            this.dsFinancial = new admpay_default.dsFinancial();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDelAssessment = new System.Windows.Forms.Button();
            this.btnEditAssessment = new System.Windows.Forms.Button();
            this.btnInsertAssessment = new System.Windows.Forms.Button();
            this.DGridAccertamenti = new System.Windows.Forms.DataGrid();
            this.dsImport = new admpay_default.dsImport();
            this.DS = new admpay_default.vistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGenerale = new System.Windows.Forms.TabPage();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.btnVisualizzaEP_L = new System.Windows.Forms.Button();
            this.btnVisualizzaEP_R = new System.Windows.Forms.Button();
            this.btnVisualizzaEP_V = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridImpegni)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsFinancial)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridAccertamenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGenerale.SuspendLayout();
            this.tabEP.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEsercAdmPay);
            this.groupBox1.Controls.Add(this.txtNumAdmPay);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercAdmPay
            // 
            this.txtEsercAdmPay.Location = new System.Drawing.Point(72, 16);
            this.txtEsercAdmPay.Name = "txtEsercAdmPay";
            this.txtEsercAdmPay.Size = new System.Drawing.Size(80, 20);
            this.txtEsercAdmPay.TabIndex = 3;
            this.txtEsercAdmPay.Tag = "admpay.yadmpay.year";
            // 
            // txtNumAdmPay
            // 
            this.txtNumAdmPay.Location = new System.Drawing.Point(72, 48);
            this.txtNumAdmPay.Name = "txtNumAdmPay";
            this.txtNumAdmPay.Size = new System.Drawing.Size(80, 20);
            this.txtNumAdmPay.TabIndex = 4;
            this.txtNumAdmPay.Tag = "admpay.nadmpay";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Descrizione:";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(3, 23);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(578, 48);
            this.textBox3.TabIndex = 1;
            this.textBox3.Tag = "admpay.description";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Importo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(62, 76);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(104, 20);
            this.txtImporto.TabIndex = 2;
            this.txtImporto.Tag = "admpay.amount";
            this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(405, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Data Contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(495, 169);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 3;
            this.textBox5.Tag = "admpay.adate";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Location = new System.Drawing.Point(174, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 24);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Tag = "admpay.processed:S:N";
            this.checkBox1.Text = "Elaborato";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDelAppropriation);
            this.groupBox2.Controls.Add(this.btnEditAppropriation);
            this.groupBox2.Controls.Add(this.btnInsertAppropriation);
            this.groupBox2.Controls.Add(this.DGridImpegni);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtImportoAssegnare);
            this.groupBox2.Location = new System.Drawing.Point(6, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 159);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meta Impegni";
            // 
            // btnDelAppropriation
            // 
            this.btnDelAppropriation.Location = new System.Drawing.Point(184, 16);
            this.btnDelAppropriation.Name = "btnDelAppropriation";
            this.btnDelAppropriation.Size = new System.Drawing.Size(75, 23);
            this.btnDelAppropriation.TabIndex = 6;
            this.btnDelAppropriation.TabStop = false;
            this.btnDelAppropriation.Tag = "delete";
            this.btnDelAppropriation.Text = "Cancella";
            // 
            // btnEditAppropriation
            // 
            this.btnEditAppropriation.Location = new System.Drawing.Point(96, 16);
            this.btnEditAppropriation.Name = "btnEditAppropriation";
            this.btnEditAppropriation.Size = new System.Drawing.Size(75, 23);
            this.btnEditAppropriation.TabIndex = 5;
            this.btnEditAppropriation.TabStop = false;
            this.btnEditAppropriation.Tag = "";
            this.btnEditAppropriation.Text = "Correggi";
            this.btnEditAppropriation.Click += new System.EventHandler(this.btnEditAppropriation_Click);
            // 
            // btnInsertAppropriation
            // 
            this.btnInsertAppropriation.Location = new System.Drawing.Point(8, 16);
            this.btnInsertAppropriation.Name = "btnInsertAppropriation";
            this.btnInsertAppropriation.Size = new System.Drawing.Size(75, 23);
            this.btnInsertAppropriation.TabIndex = 4;
            this.btnInsertAppropriation.TabStop = false;
            this.btnInsertAppropriation.Tag = "";
            this.btnInsertAppropriation.Text = "Aggiungi";
            this.btnInsertAppropriation.Click += new System.EventHandler(this.btnInsertAppropriation_Click);
            // 
            // DGridImpegni
            // 
            this.DGridImpegni.AllowNavigation = false;
            this.DGridImpegni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridImpegni.DataMember = "";
            this.DGridImpegni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridImpegni.Location = new System.Drawing.Point(8, 48);
            this.DGridImpegni.Name = "DGridImpegni";
            this.DGridImpegni.Size = new System.Drawing.Size(559, 103);
            this.DGridImpegni.TabIndex = 0;
            this.DGridImpegni.Tag = "admpay_appropriation.detail.detail";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(264, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Importo disponibile da assegnare:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImportoAssegnare
            // 
            this.txtImportoAssegnare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoAssegnare.Location = new System.Drawing.Point(455, 16);
            this.txtImportoAssegnare.Name = "txtImportoAssegnare";
            this.txtImportoAssegnare.ReadOnly = true;
            this.txtImportoAssegnare.Size = new System.Drawing.Size(112, 20);
            this.txtImportoAssegnare.TabIndex = 15;
            this.txtImportoAssegnare.TabStop = false;
            this.txtImportoAssegnare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGenera
            // 
            this.btnGenera.Location = new System.Drawing.Point(6, 16);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(152, 23);
            this.btnGenera.TabIndex = 9;
            this.btnGenera.TabStop = false;
            this.btnGenera.Text = "Meta Movimenti";
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGeneraMovFin);
            this.groupBox3.Controls.Add(this.btnGenera);
            this.groupBox3.Location = new System.Drawing.Point(434, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 80);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generazione";
            // 
            // btnGeneraMovFin
            // 
            this.btnGeneraMovFin.Location = new System.Drawing.Point(6, 48);
            this.btnGeneraMovFin.Name = "btnGeneraMovFin";
            this.btnGeneraMovFin.Size = new System.Drawing.Size(152, 23);
            this.btnGeneraMovFin.TabIndex = 10;
            this.btnGeneraMovFin.TabStop = false;
            this.btnGeneraMovFin.Text = "Movimenti Finanziari";
            this.btnGeneraMovFin.Click += new System.EventHandler(this.btnGeneraMovFin_Click);
            // 
            // dsFinancial
            // 
            this.dsFinancial.DataSetName = "dsFinancial";
            this.dsFinancial.EnforceConstraints = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnDelAssessment);
            this.groupBox4.Controls.Add(this.btnEditAssessment);
            this.groupBox4.Controls.Add(this.btnInsertAssessment);
            this.groupBox4.Controls.Add(this.DGridAccertamenti);
            this.groupBox4.Location = new System.Drawing.Point(6, 267);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(577, 157);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Meta Accertamenti";
            // 
            // btnDelAssessment
            // 
            this.btnDelAssessment.Location = new System.Drawing.Point(184, 16);
            this.btnDelAssessment.Name = "btnDelAssessment";
            this.btnDelAssessment.Size = new System.Drawing.Size(75, 23);
            this.btnDelAssessment.TabIndex = 6;
            this.btnDelAssessment.TabStop = false;
            this.btnDelAssessment.Tag = "delete";
            this.btnDelAssessment.Text = "Cancella";
            // 
            // btnEditAssessment
            // 
            this.btnEditAssessment.Location = new System.Drawing.Point(96, 16);
            this.btnEditAssessment.Name = "btnEditAssessment";
            this.btnEditAssessment.Size = new System.Drawing.Size(75, 23);
            this.btnEditAssessment.TabIndex = 5;
            this.btnEditAssessment.TabStop = false;
            this.btnEditAssessment.Tag = "";
            this.btnEditAssessment.Text = "Correggi";
            this.btnEditAssessment.Click += new System.EventHandler(this.btnEditAssessment_Click);
            // 
            // btnInsertAssessment
            // 
            this.btnInsertAssessment.Location = new System.Drawing.Point(8, 16);
            this.btnInsertAssessment.Name = "btnInsertAssessment";
            this.btnInsertAssessment.Size = new System.Drawing.Size(75, 23);
            this.btnInsertAssessment.TabIndex = 4;
            this.btnInsertAssessment.TabStop = false;
            this.btnInsertAssessment.Tag = "";
            this.btnInsertAssessment.Text = "Aggiungi";
            this.btnInsertAssessment.Click += new System.EventHandler(this.btnInsertAssessment_Click);
            // 
            // DGridAccertamenti
            // 
            this.DGridAccertamenti.AllowNavigation = false;
            this.DGridAccertamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridAccertamenti.DataMember = "";
            this.DGridAccertamenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DGridAccertamenti.Location = new System.Drawing.Point(8, 48);
            this.DGridAccertamenti.Name = "DGridAccertamenti";
            this.DGridAccertamenti.Size = new System.Drawing.Size(561, 101);
            this.DGridAccertamenti.TabIndex = 0;
            this.DGridAccertamenti.Tag = "admpay_assessment.detail.detail";
            // 
            // dsImport
            // 
            this.dsImport.DataSetName = "dsImport";
            this.dsImport.EnforceConstraints = false;
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
            this.tabControl1.Controls.Add(this.tabGenerale);
            this.tabControl1.Controls.Add(this.tabEP);
            this.tabControl1.Location = new System.Drawing.Point(8, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(595, 456);
            this.tabControl1.TabIndex = 11;
            // 
            // tabGenerale
            // 
            this.tabGenerale.Controls.Add(this.textBox3);
            this.tabGenerale.Controls.Add(this.groupBox4);
            this.tabGenerale.Controls.Add(this.label3);
            this.tabGenerale.Controls.Add(this.label4);
            this.tabGenerale.Controls.Add(this.groupBox2);
            this.tabGenerale.Controls.Add(this.txtImporto);
            this.tabGenerale.Location = new System.Drawing.Point(4, 22);
            this.tabGenerale.Name = "tabGenerale";
            this.tabGenerale.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerale.Size = new System.Drawing.Size(587, 430);
            this.tabGenerale.TabIndex = 0;
            this.tabGenerale.Text = "Generale";
            this.tabGenerale.UseVisualStyleBackColor = true;
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.btnVisualizzaEP_V);
            this.tabEP.Controls.Add(this.btnVisualizzaEP_R);
            this.tabEP.Controls.Add(this.btnVisualizzaEP_L);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Padding = new System.Windows.Forms.Padding(3);
            this.tabEP.Size = new System.Drawing.Size(587, 430);
            this.tabEP.TabIndex = 1;
            this.tabEP.Text = "E/P";
            this.tabEP.UseVisualStyleBackColor = true;
            // 
            // btnVisualizzaEP_L
            // 
            this.btnVisualizzaEP_L.Location = new System.Drawing.Point(6, 15);
            this.btnVisualizzaEP_L.Name = "btnVisualizzaEP_L";
            this.btnVisualizzaEP_L.Size = new System.Drawing.Size(294, 23);
            this.btnVisualizzaEP_L.TabIndex = 20;
            this.btnVisualizzaEP_L.Text = "Visualizza le scritture in partita doppia - Lordi";
            this.btnVisualizzaEP_L.Click += new System.EventHandler(this.btnVisualizzaEP_L_Click);
            // 
            // btnVisualizzaEP_R
            // 
            this.btnVisualizzaEP_R.Location = new System.Drawing.Point(7, 53);
            this.btnVisualizzaEP_R.Name = "btnVisualizzaEP_R";
            this.btnVisualizzaEP_R.Size = new System.Drawing.Size(293, 23);
            this.btnVisualizzaEP_R.TabIndex = 21;
            this.btnVisualizzaEP_R.Text = "Visualizza le scritture in partita doppia - Reversali";
            this.btnVisualizzaEP_R.Click += new System.EventHandler(this.btnVisualizzaEP_R_Click);
            // 
            // btnVisualizzaEP_V
            // 
            this.btnVisualizzaEP_V.Location = new System.Drawing.Point(7, 92);
            this.btnVisualizzaEP_V.Name = "btnVisualizzaEP_V";
            this.btnVisualizzaEP_V.Size = new System.Drawing.Size(293, 23);
            this.btnVisualizzaEP_V.TabIndex = 22;
            this.btnVisualizzaEP_V.Text = "Visualizza le scritture in partita doppia - Versamenti";
            this.btnVisualizzaEP_V.Click += new System.EventHandler(this.btnVisualizzaEP_V_Click);
            // 
            // FrmAdmPay_Default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(605, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAdmPay_Default";
            this.Text = "FrmAdmPay_Default";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridImpegni)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsFinancial)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridAccertamenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGenerale.ResumeLayout(false);
            this.tabGenerale.PerformLayout();
            this.tabEP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			ClearDataSet.RemoveConstraints(dsImport);
            ClearDataSet.RemoveConstraints(dsFinancial);

			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

			HelpForm.SetDenyNull(DS.admpay.Columns["processed"], true);
			string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.expenseview, filterEsercizio);
            GetData.SetStaticFilter(DS.incomeview, filterEsercizio);
            GetData.CacheTable(DS.fin, filterEsercizio, null, false);
            GetData.CacheTable(DS.upb);
			// Aggiunta dei campi nriga e errore nella tabella tErrorLog
			// (questa tabella viene usata nella generazione dei pseudo movimenti) per segnalare eventuali errori
			tErrorLog.Columns.Add("nriga", typeof(int));
			tErrorLog.Columns["nriga"].Caption = "Progressivo";
			tErrorLog.Columns.Add("errore", typeof(string));
			tErrorLog.Columns["errore"].Caption = "Descrizione Errore";
            tErrorLog.Columns.Add("occorrenze", typeof(int));
            tErrorLog.Columns["occorrenze"].Caption = "N.occorrenze";

		}

		public void MetaData_AfterClear() {
			txtEsercAdmPay.Text = Meta.GetSys("esercizio").ToString();
			txtEsercAdmPay.ReadOnly = false;
			btnInsertAppropriation.Enabled = false;
			btnEditAppropriation.Enabled = false;
            btnInsertAssessment.Enabled = false;
            btnEditAssessment.Enabled = false;
			btnGenera.Enabled = false;
			btnGeneraMovFin.Enabled = false;
		}

		public void MetaData_AfterActivation() {
			btnInsertAppropriation.BackColor = formcolors.GridButtonBackColor();
			btnInsertAppropriation.ForeColor = formcolors.GridButtonForeColor();
			btnEditAppropriation.BackColor = formcolors.GridButtonBackColor();
			btnEditAppropriation.ForeColor = formcolors.GridButtonForeColor();

            btnInsertAssessment.BackColor = formcolors.GridButtonBackColor();
            btnInsertAssessment.ForeColor = formcolors.GridButtonForeColor();
            btnEditAssessment.BackColor = formcolors.GridButtonBackColor();
            btnEditAssessment.ForeColor = formcolors.GridButtonForeColor();
		}

		public void MetaData_AfterFill() {
			txtEsercAdmPay.ReadOnly=true;
			UpdateImportoDependencies();
			if (Meta.FirstFillForThisRow) {
				btnInsertAppropriation.Enabled = true;
				btnEditAppropriation.Enabled = true;
                btnInsertAssessment.Enabled = true;
                btnEditAssessment.Enabled = true;
			}
			if ((Meta.InsertMode) || (Meta.IsEmpty)){
				btnGenera.Enabled = false;
				btnGeneraMovFin.Enabled = false;
			}
			else {
				bool processato = (DS.admpay.Rows[0]["processed"].ToString().ToUpper() == "S");
				btnGenera.Enabled = !processato;
				btnGeneraMovFin.Enabled = !processato;
			}

            foreach (DataRow rApp in DS.Tables["admpay_appropriation"].Rows) {
                if (rApp.RowState != DataRowState.Deleted) continue;
                cancellaFigli(rApp);
            }

            foreach (DataRow rAss in DS.Tables["admpay_assessment"].Rows) {
                if (rAss.RowState != DataRowState.Deleted) continue;
                cancellaFigli(rAss);
            }
		}

        private void cancellaFigli(DataRow rAppAss) {
            if (rAppAss == null) return;
            string tMetaMov = (rAppAss.Table.TableName == "admpay_appropriation") ? "admpay_expense" : "admpay_income";
            string tMetaSor = (rAppAss.Table.TableName == "admpay_appropriation") ? "admpay_expensesorted" : "admpay_incomesorted";
            string f = QHC.CmpKey(rAppAss);
            // Cancellazione dei metamovimenti
            string fieldMov = (tMetaMov == "admpay_expense") ? "nexpense" : "nincome";

            //Controllo che i figli di meta movimenti cancellati siano anche loro cancellati
            foreach (DataRow rMovDel in DS.Tables[tMetaMov].Rows) {
                if (rMovDel.RowState != DataRowState.Deleted) continue;
                DataRowVersion toConsider = DataRowVersion.Original;
                string fMov = QHC.AppAnd(QHC.CmpEq("yadmpay", rMovDel["yadmpay", toConsider]),
                    QHC.CmpEq("nadmpay", rMovDel["nadmpay", toConsider]),
                    QHC.CmpEq(fieldMov, rMovDel[fieldMov, toConsider]));
                foreach (DataRow rSor in DS.Tables[tMetaSor].Select(fMov)) {
                    if (rSor.RowState == DataRowState.Deleted) continue;
                    rSor.Delete();
                }
            }

            // Cancello i meta movimenti non ancora marcati come cancellati
            foreach (DataRow rMov in DS.Tables[tMetaMov].Select(f)) {
                string fMov = QHC.CmpKey(rMov);
                foreach (DataRow rSor in DS.Tables[tMetaSor].Select(fMov)) {
                    rSor.Delete();
                }
                rMov.Delete();
            }
        }

		private void txtImporto_Leave(object sender, System.EventArgs e) {
			Meta.GetFormData(true);
			UpdateImportoDependencies();
		}

		private void UpdateImportoDependencies() {
			if (DS.admpay.Rows.Count == 0) return;
			DataRow Curr = DS.admpay.Rows[0];
            decimal importo = calcolaImportoRimanente(null);
            RefillImportoAssegnazioni(importo);
		}

		void RefillImportoAssegnazioni(decimal Importo){
            string tName = "admpay_appropriation";
			// valorizzare i textbox degli importi ancora da assegnare
			// e impostare i valori di default degli importi delle assegnazioni
			DS.Tables[tName].Columns["amount"].DefaultValue=Importo;
            txtImportoAssegnare.Text = Importo.ToString("c");
		}
		/// <summary>
		/// Metodo che calcola l'importo residuo del pagamento stipendi
		/// </summary>
		/// <param name="currImpegno">Riga dell'impegno corrente</param>
		/// <returns></returns>
		private decimal calcolaImportoRimanente(DataRow currMov) {
			if (DS.admpay.Rows.Count == 0) return 0;

            string nObjField = "nappropriation";
            string tName = "admpay_appropriation";
			DataRow Curr = DS.admpay.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(Curr["amount"]);
			string filter = "";
            if (currMov != null) {
                filter = QHC.AppAnd(QHC.MCmp(currMov, new string [] {"yadmpay", "nadmpay"}),
                    QHC.CmpNe(nObjField, currMov[nObjField]));
			}
			foreach(DataRow rMov in DS.Tables[tName].Select(filter)) {
                importo -= CfgFn.GetNoNullDecimal(rMov["amount"]);
			}
			return importo;
		}

		private void btnInsertAppropriation_Click(object sender, System.EventArgs e) {
			decimal importoPerImpegno = calcolaImportoRimanente(null);
			DS.admpay_appropriation.ExtendedProperties[MetaData.ExtraParams]= importoPerImpegno;
			Meta.Insert_Grid_Row(DGridImpegni, "detail");
		}

		private void btnEditAppropriation_Click(object sender, System.EventArgs e) {
			DataRow currImpegno = HelpForm.GetLastSelected(DS.admpay_appropriation);
			decimal importoPerImpegno = calcolaImportoRimanente(currImpegno);
			DS.admpay_appropriation.ExtendedProperties[MetaData.ExtraParams]= importoPerImpegno;
			MetaData.Edit_Grid(DGridImpegni, "detail");
		}

		private void btnGenera_Click(object sender, System.EventArgs e) {
            AskTask compito = new AskTask(0);
			createForm(compito, null);
            DialogResult dr = compito.ShowDialog();
            if (dr != DialogResult.OK) {
                show(this, "Non è stato scelto alcun compito", "Avvertimento");
                return;
            }

            //Riempie il datatable MData leggendo dal foglio Excel
            if (!LeggiFile()) {
                show(this, "Errore nell'apertura del file");
                return;
            }
            //Arrotonda a due cifre decimali la colonna importo (dovrebbe esistere)
            if (mData.Columns.Contains("IMPORTO")) {
                foreach (DataRow R in mData.Rows) {
                    if (R["IMPORTO"]!=DBNull.Value)
                        R["IMPORTO"] = CfgFn.Round(CfgFn.GetNoNullDecimal(R["IMPORTO"]), 2);
                }
            }

            //Crea le Hash Table (una per ogni coordinata) a partire da Mdata
            if (!CreaHashTable(compito.Choosen)) {
                FrmError frm = new FrmError(tErrorLog);
				createForm(frm, null);
                DialogResult dr1 = frm.ShowDialog();
                show(this, "Errore nella fase di raggruppamento dei dati");
                return;
            }

            string IoE = "";
            switch (compito.Choosen) {
                case "L": {
                        IoE = "E";
                        break;
                    }
                case "R": {
                        IoE = "I";
                        break;
                    }
                case "V": {
                        IoE = "E";
                        break;
                    }
            }

			string errMess;
            if (!generaMovimenti(mData, IoE, compito.Choosen, out errMess)) {
                FrmError frm = new FrmError(tErrorLog);
				createForm(frm, null);
                DialogResult dr1 = frm.ShowDialog();
                if (dr1 != DialogResult.OK) {
                    tErrorLog.Clear();
                    tErrorLog.AcceptChanges();
                    dsImport.Clear();
                    dsImport.AcceptChanges();
                }
                else {
                    SaveData(compito.Choosen);
                }
            }
            else {
                if (tErrorLog.Rows.Count > 0) {
                    FrmError frm = new FrmError(tErrorLog);
					createForm(frm, null);
                    DialogResult dr1 = frm.ShowDialog();
                    if (dr1 != DialogResult.OK) {
                        tErrorLog.Clear();
                        tErrorLog.AcceptChanges();
                        dsImport.Clear();
                        dsImport.AcceptChanges();
                        return;
                    }
                }
                SaveData(compito.Choosen);
            }
            return;
		}

		private void SaveData(string kind) {
			Easy_PostData MyPostData = new Easy_PostData();
			MyPostData.InitClass(dsImport, Meta.Conn);

			string msg = "";
			MessageBoxIcon mbi = MessageBoxIcon.Information;
            if (MyPostData.DO_POST()) {
                msg = "Pseudo Movimenti generati con successo!";
                ricopiaImpegnativeAccertamentiInDS("admpay_appropriation");
                ricopiaImpegnativeAccertamentiInDS("admpay_assessment");
                if (kind != null) {
                    GeneraScritture(mData, kind);
                }
            }
            else {
                msg = "Generazione dei Pseudo Movimenti fallita!";
                mbi = MessageBoxIcon.Error;
            }
			show(this, msg, "Responso Salvataggio", MessageBoxButtons.OK, mbi);
			dsImport.Clear();
			dsImport.AcceptChanges();
		}

        private void ricopiaImpegnativeAccertamentiInDS(string tName) {
            string tNameMov = (tName == "admpay_appropriation")
                ? "admpay_expense" : "admpay_income";

            string tNameSort = (tName == "admpay_appropriation")
                ? "admpay_expensesorted" : "admpay_incomesorted";

			foreach(DataRow rImp in dsImport.Tables[tName].Rows) {
				DataRow rImpDS = DS.Tables[tName].NewRow();
				foreach(DataColumn C in DS.Tables[tName].Columns) {
					if (!dsImport.Tables[tName].Columns.Contains(C.ColumnName)) continue;
					rImpDS[C.ColumnName] = rImp[C.ColumnName];
				}
				DS.Tables[tName].Rows.Add(rImpDS);
                ricopiaMetaMovimentiInDS(tNameMov, rImp, rImpDS);
			}
            Meta.myGetData.GetTemporaryValues(DS.Tables[tName]);

            DS.Tables[tName].AcceptChanges();
            DS.Tables[tNameMov].AcceptChanges();
            DS.Tables[tNameSort].AcceptChanges();
		}

        /// <summary>
        /// Metodo che ricopia nel dataset principale (DS) le tabelle figlie delle impegnative / accertamenti
        /// </summary>
        /// <param name="tName">Tabella da ricopiare</param>
        /// <param name="tParent">Tabella padre</param>
        /// <param name="rParent">Riga padre</param>
        /// <param name="rParentDS">Riga padre in DS</param>
        private void ricopiaMetaMovimentiInDS(string tName, DataRow rParent, DataRow parentRowDest) {
            string tNameSort = tName + "sorted";

            DataTable tSorg = dsImport.Tables[tName];
            DataTable tDest = DS.Tables[tName];
            MetaData metaTabella = MetaData.GetMetaData(this, tName);
            metaTabella.SetDefaults(tDest);

            string filtro = QHC.CmpKey(parentRowDest);
            foreach(DataRow rowSorg in tSorg.Select(filtro)) {
                string campiChiave = QHS.CmpKey(rowSorg);
                DataRow [] rInDS = tDest.Select(campiChiave);
                DataRow rowDS = (rInDS.Length != 0) ? rInDS[0] : metaTabella.Get_New_Row(parentRowDest, tDest);

                foreach (DataColumn C in tSorg.Columns) {
                    if (!tDest.Columns.Contains(C.ColumnName)) continue;
                    rowDS[C.ColumnName] = rowSorg[C];
                }

                ricopiaSortedInDS(tNameSort, rowSorg, rowDS);
            }
        }


        private void ricopiaSortedInDS(string tName, DataRow rParent, DataRow parentRowDest) {
            DataTable tSorg = dsImport.Tables[tName];
            DataTable tDest = DS.Tables[tName];
            MetaData metaTabella = MetaData.GetMetaData(this, tName);
            metaTabella.SetDefaults(tDest);

            string filtro = QHC.CmpKey(parentRowDest);
            foreach (DataRow rowSorg in tSorg.Select(filtro)) {
                string campiChiave = QHS.CmpKey(rowSorg);
                DataRow[] rInDS = tDest.Select(campiChiave);
                DataRow rowDS = (rInDS.Length != 0) ? rInDS[0] : metaTabella.Get_New_Row(parentRowDest, tDest);

                foreach (DataColumn C in tSorg.Columns) {
                    if (!tDest.Columns.Contains(C.ColumnName)) continue;
                    rowDS[C.ColumnName] = rowSorg[C];
                }
            }
        }

        private bool GeneraScritture(DataTable tSource, string kind) {
            if (DS.admpay.Rows.Count == 0) return true;
            DataRow Curr = DS.admpay.Rows[0];
            DataTable tWageImportSetup = DataAccess.CreateTableByName(Meta.Conn, "wageimportsetup", "*");
            string filter = QHS.CmpEq("kind", kind);

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tWageImportSetup, null, filter, null, true);
            if (tWageImportSetup.Rows.Count == 0) return true;

            DataRow rWageImportSetup = tWageImportSetup.Rows[0];

            object idsorkind_idaccmotivegroup1 = rWageImportSetup["idsorkind_accmotivegroup1"];
            object idsorkind_idaccmotivegroup2 = rWageImportSetup["idsorkind_accmotivegroup2"];
            if ((idsorkind_idaccmotivegroup1 == DBNull.Value) && (idsorkind_idaccmotivegroup2 == DBNull.Value)) {
                show(this, "Non sono state impostate le classificazioni per la generazione delle scritture E/P");
                return true;
            }

            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return false;
            GetEntryForDocument(EP);

            MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            
            DataRow rEntry = SetEntry(EP, MetaEntry, Curr, kind);

            string idepcontext1 = "PAGAM";
            string idepcontext2 = "INCAS";
            foreach (DataRow rSource in tSource.Rows) {
                object idreg = rSource["!idreg"];
                object idupb = rSource["!idupb"];
                decimal amount = CfgFn.GetNoNullDecimal(rSource["IMPORTO"]);
                if (amount == 0) continue;
                
                object idaccmotive1 = rSource["!idaccmotive1"];
                if (idaccmotive1 != DBNull.Value) {
                    DataRow[] Conti_Grp1 = EP.GetAccMotiveDetails(idaccmotive1);

                    foreach (DataRow conto_Grp1 in Conti_Grp1) {
                        EP.EffettuaScrittura(idepcontext1, amount,
                                conto_Grp1["idacc"],
                                idreg, idupb,
                                null, null,
                                null, idaccmotive1);
                    }
                }

                object idaccmotive2 = rSource["!idaccmotive2"];
                if (idaccmotive2 != DBNull.Value) {
                    DataRow[] Conti_Grp2 = EP.GetAccMotiveDetails(idaccmotive2);

                    foreach (DataRow conto_Grp2 in Conti_Grp2) {
                        EP.EffettuaScrittura(idepcontext2, amount,
                                conto_Grp2["idacc"],
                                idreg, idupb,
                                null, null,
                                null, idaccmotive2);
                    }
                }
            }

            EP.RemoveEmptyDetails();

            PostData Post = MetaEntry.Get_PostData();

            Post.InitClass(EP.D, Meta.Conn);
            if (Post.DO_POST()) {
                DataRow rEntryPosted = EP.D.Tables["entry"].Rows[0];
                EditEntry(rEntryPosted);
            }

            return true;
        }

        public void GetEntryForDocument(EP_functions EP) {
            DataAccess Conn = Meta.Conn;
            int esercizio = CfgFn.GetNoNullInt32(Meta.Conn);
            EP.D = new DataSet();
            DataTable T = DataAccess.CreateTableByName(Meta.Conn, "entry", "*");
            EP.D.Tables.Add(T);
            if (T.Rows.Count == 0) {
                DataTable TT2 = Conn.CreateTableByName("entrydetail", "*");
                EP.D.Tables.Add(TT2);
                EP.D.Relations.Add("entryentrydetail",
                    new DataColumn[] { T.Columns["yentry"], T.Columns["nentry"] },
                    new DataColumn[] { TT2.Columns["yentry"], TT2.Columns["nentry"] }, false);
                return;
            }
            DataRow Entry = T.Rows[0];
            string key = QHS.CmpKey(Entry);
            string filtercurryeardetail = QHS.AppAnd(key, QHS.CmpEq("yentry", esercizio));
            DataTable TT = Conn.RUN_SELECT("entrydetail", "*", null, filtercurryeardetail, null, true);
            EP.D.Tables.Add(TT);
            EP.D.Relations.Add("entryentrydetail",
                new DataColumn[] { T.Columns["yentry"], T.Columns["nentry"] },
                new DataColumn[] { TT.Columns["yentry"], TT.Columns["nentry"] }, false);

            DataTable TT3 = Conn.RUN_SELECT("entrydetailaccrual", "*", null, filtercurryeardetail, null, true);
            EP.D.Tables.Add(TT3);
            EP.D.Relations.Add("entrydetailentrydetailaccrual",
                new DataColumn[] { TT.Columns["yentry"], TT.Columns["nentry"], TT.Columns["ndetail"] },
                new DataColumn[] { TT3.Columns["yentry"], TT3.Columns["nentry"], TT3.Columns["ndetail"] },
                false);
            if (TT3.Rows.Count > 0) {
                show("Ci sono ratei associati alle scritture che saranno scollegati. Sarà " +
                    "necessario ricollegarli a mano");
                foreach (DataRow R3 in TT3.Rows) R3.Delete();
            }
            //string filterprev= GetData.MergeFilters(filterrelated,
            //	"(yentry<"+QueryCreator.quotedstrvalue(esercizio-1,true)+")");
            //int num= Conn.RUN_SELECT_COUNT("entry",filterprev,false);
            //if (num==0) SottraiRatei=false; //Non c'è necessita di sotrarre risconti poichè non ve ne sono.
        }

        void EditEntry(DataRow R) {
            if (R == null) return;
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            EP.EditRelatedEntryByKey(Meta, R);
        }

        private DataRow SetEntry(EP_functions EP, MetaData MetaEntry, DataRow Curr, string kind) {
            DataTable Entry = EP.D.Tables["entry"];
            DataRow R;
            if (Entry.Rows.Count == 0) {
                MetaEntry.SetDefaults(Entry);
                R = MetaEntry.Get_New_Row(null, Entry);
            }
            else {
                R = Entry.Rows[0];
            }

            string idRelated = "admpay" + "§" + Curr["yadmpay"].ToString()
                + "§" + Curr["nadmpay"].ToString() + "§" + kind;

            R["idrelated"] = idRelated;
            R["description"] = Curr["description"];
            R["doc"] = "Pagamento Stipendi " + Curr["nadmpay"] + "/" + Curr["yadmpay"];
            R["adate"] = Curr["adate"];
            return R;
        }

		/// 
		/// Read the data from the selected sheet and write it into class member mData
		/// 
		private void ReadCurrentSheet() {
            try {
                // open the connection to the file
                using (OleDbConnection connection =
                           new OleDbConnection(ConnectionString)) {
                    connection.Open();
                    DataTable sheetData = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string foglioLavoro = sheetData.Rows[0]["TABLE_NAME"].ToString();
                    string sql =
                        string.Format("select * from [{0}]", foglioLavoro);
                    // create an adapter
                    using (OleDbDataAdapter adapter =
                               new OleDbDataAdapter(sql, connection)) {
                        // clear the datatable to avoid old data persistance
                        mData.Clear();
                        mData.Columns.Clear();

                        // fille the datatable
                        adapter.Fill(mData);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) {
                show(this, ex.Message);
            }
		}

        /// <summary>
        /// Metodo che riempie le tabelle di configurazione
        /// </summary>
        /// <param name="task">Parametro che indica l'operazione che si sta compiendo. Valori Ammessi 1: Lordo; 2: Reversale; 3: Versamento</param>
		private void tabelleCached(string task) {
			if (dsImport.tax.Rows.Count == 0) {
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImport.tax, "taxcode", null, null, true);
			}

			if (dsImport.wageimportsetup.Rows.Count == 0) {
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImport.wageimportsetup, null, null, null, true);
			}

			if (dsImport.wageimportsetup.Rows.Count == 0) return;
            string filter = QHC.CmpEq("kind", task);

            DataRow rWageImportSetup = dsImport.wageimportsetup.Select(filter)[0];

            //if (dsImport.sorting.Rows.Count == 0) {
            //    string filterS = "";
            //    foreach(DataColumn C in dsImport.wageimportsetup.Columns) {
            //        if ((C.ColumnName == "idwageimportsetup")
            //            || (C.ColumnName == "ct")
            //            || (C.ColumnName == "cu")
            //            || (C.ColumnName == "lt")
            //            || (C.ColumnName == "lu")) continue;
            //        if (rWageImportSetup[C.ColumnName] == DBNull.Value) continue;

            //        filterS = QHC.AppOr(filterS, QHC.CmpEq("idsorkind", rWageImportSetup[C.ColumnName]));
					
            //    }
            //    if (filterS != "") {
            //        DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImport.sorting, null, filterS, null, true);
            //    }
            //}

            //string filterTaxSor = QHC.CmpEq("idsorkind", rWageImportSetup["idsorkind_tax"]);
            //if (dsImport.taxsorting.Rows.Count == 0) {
            //    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImport.taxsorting, null, filterTaxSor, null, true);
            //}

            //string filterClawBackSor = QHC.CmpEq("idsorkind", rWageImportSetup["idsorkind_clawback"]);
            //if (dsImport.clawbacksorting.Rows.Count == 0) {
            //    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImport.clawbacksorting, null, filterClawBackSor, null, true);
            //}
		}

		private string leggiAltriCampi(DataRow rSource) {
			string listaCampi = dsImport.Tables["wageimportsetup"].Rows[0]["listfield"].ToString();
			
			string [] altriCampi = listaCampi.Split(',');

			string fAltri = "";
			foreach(string ac in altriCampi) {
                if (!rSource.Table.Columns.Contains(ac)) continue;
                fAltri = QHC.AppAnd(fAltri, QHC.CmpEq(ac, rSource[ac]));
			}
			return fAltri;
		}

		MetaData MetaAdmPay_EoI;
        private DataRow scriviAdmPay_Expense_o_Income(DataRow rSource, DataRow rImpegnativa, string IoE) {
			if (rSource == null) return null;
            if (rSource["!idreg"]==DBNull.Value) return null;
            string tName = (IoE == "I") ? "admpay_income" : "admpay_expense";
			if (dsImport.admpay.Rows.Count == 0) return null;
			DataRow rAdmPay = dsImport.admpay.Rows[0];

            string fService = "";
            if (IoE == "E") {
                fService = QHC.CmpEq("idser", rSource["!idser"]);
            }

            string fRegistry = QHC.CmpEq("idreg", rSource["!idreg"]);

			string f1 = GetData.MergeFilters(fService, fRegistry);
			string fAltri = leggiAltriCampi(rSource);
            string fParent = QHC.CmpKey(rImpegnativa);
			string fFinale = QHC.AppAnd(f1, fAltri, fParent);

            string amountField = "IMPORTO";
			DataRow [] PseudoMov = dsImport.Tables[tName].Select(fFinale);
			DataRow rAPE;
			if (PseudoMov.Length > 0) {
				rAPE = PseudoMov[0];
				rAPE["amount"] = CfgFn.GetNoNullDecimal(rAPE["amount"]) + CfgFn.GetNoNullDecimal(rSource[amountField]);
			}
			else {
                MetaAdmPay_EoI = MetaData.GetMetaData(this, tName);
                MetaAdmPay_EoI.SetDefaults(dsImport.Tables[tName]);
                MetaData.SetDefault(dsImport.Tables[tName], "yadmpay", rAdmPay["yadmpay"]);
                MetaData.SetDefault(dsImport.Tables[tName], "nadmpay", rAdmPay["nadmpay"]);

                rAPE = MetaAdmPay_EoI.Get_New_Row(rAdmPay, dsImport.Tables[tName]);
			
				rAPE["amount"] = CfgFn.GetNoNullDecimal(rSource[amountField]);
                DataRow CurrStip = DS.admpay.Rows[0];
                rAPE["description"] = CurrStip["description"]; //"Pagamento Stipendi"; 
				rAPE["idreg"] = rSource["!idreg"];

                string nObject = (IoE == "I") ? "nassessment" : "nappropriation";
				if (rImpegnativa != null) {
					// Imposto il riferimento all'impegnativa
					rAPE[nObject] = rImpegnativa[nObject];
				}

                if (dsImport.Tables[tName].Columns.Contains("idser")) {
                    rAPE["idser"] = rSource["!idser"];
                }
			}
			return rAPE;
		}
        /*
		private void scriviAdmPay_Tax(DataRow rSource, DataRow rParent, int nRow) {
			if (rSource == null) return;
			if (rParent == null) return;
			if (dsImport.wageimportsetup.Rows.Count == 0) return;
			DataRow rWageImportSetup = dsImport.wageimportsetup.Rows[0];
            string fClassTax = QHC.CmpEq("idsorkind", rWageImportSetup["idsorkind_tax"]);

            DataTable tSorting = DataAccess.CreateTableByName(Meta.Conn, "sorting", "*");
            string fClassTaxSQL = QHS.CmpEq("idsorkind", rWageImportSetup["idsorkind_tax"]);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tSorting, null, fClassTaxSQL, null, true);

			foreach(DataRow R in tSorting.Rows) {
				string ext_taxcode = R["defaults1"].ToString();
				if (!rSource.Table.Columns.Contains(ext_taxcode)) continue;
				decimal amount = CfgFn.GetNoNullDecimal(rSource[ext_taxcode]);
				if (amount == 0) continue;

				//string fTax = "(taxcode = " + QueryCreator.quotedstrvalue(R["defaults1"], false) + ")";
				string fTax = QHC.CmpEq("idsor", R["idsor"]);
                //fTax = GetData.MergeFilters(fClassTax, fTax);

				DataRow [] TaxSorting = dsImport.taxsorting.Select(fTax);
				if (TaxSorting.Length == 0) {
                    
					string errMess = "RITENUTA " + R["defaults1"]
						+ " NON CONFIGURATA! nella riga del file di importazione num. " + nRow;
                    fillLog(errMess);
					continue;
				}
				

				string kind = R["defaults2"].ToString().ToUpper();
				DataRow rTaxSorting = TaxSorting[0];
				
				string tName = "";
				switch(kind) {
					case "A" : {
						// Crea una riga in admpay_admintax
						tName = "admpay_admintax";
						break;
					}

					case "D" : {
						// Crea una riga in admpay_employtax
						tName = "admpay_employtax";
						break;
					}

					default : {
						string errMess = "RITENUTA " + rTaxSorting["taxcode"]
							+ " NON CONFIGURATA CORRETTAMENTE! nella riga del file di importazione num. " + nRow;
                        fillLog(errMess);
						continue;
					}
				}

				MetaData MetaAdmPay_Tax = MetaData.GetMetaData(this, tName);
				MetaAdmPay_Tax.SetDefaults(dsImport.Tables[tName]);
				string filterExist = QHC.AppAnd(QHC.MCmp(rParent, new string [] {"yadmpay", "nadmpay"}),
					QHC.CmpEq("taxcode", rTaxSorting["taxcode"]));

				if (dsImport.Tables[tName].Select(filterExist).Length > 0) {
					DataRow rAPT = dsImport.Tables[tName].Select(filterExist)[0];
					rAPT["amount"] = CfgFn.GetNoNullDecimal(rAPT["amount"]) + amount;
				}
				else {
					MetaData.SetDefault(dsImport.Tables[tName], "yadmpay", rParent["yadmpay"]);
					MetaData.SetDefault(dsImport.Tables[tName], "nadmpay", rParent["nadmpay"]);
					MetaData.SetDefault(dsImport.Tables[tName], "nexpense", rParent["nexpense"]);
					MetaData.SetDefault(dsImport.Tables[tName], "taxcode", rTaxSorting["taxcode"]);
					DataRow rAPT = MetaAdmPay_Tax.Get_New_Row(rParent, dsImport.Tables[tName]);
					rAPT["amount"] = amount;
				}
			}
		}
        */
          
        /*
		private void scriviAdmPay_ClawBack(DataRow rSource, DataRow rParent, int nRow) {
			if (rSource == null) return;
			if (rParent == null) return;
			if (dsImport.wageimportsetup.Rows.Count == 0) return;
			DataRow rWageImportSetup = dsImport.wageimportsetup.Rows[0];
            string fClassClw = QHC.CmpEq("idsorkind", rWageImportSetup["idsorkind_clawback"]);

            DataTable tSorting = DataAccess.CreateTableByName(Meta.Conn, "sorting", "*");
            string fClassClwSQL = QHS.CmpEq("idsorkind", rWageImportSetup["idsorkind_clawback"]);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tSorting, null, fClassClwSQL, null, true);

			foreach(DataRow R in tSorting.Rows) {
				string ext_idclawback = R["defaults1"].ToString();
				if (!rSource.Table.Columns.Contains(ext_idclawback)) continue;
				decimal amount = CfgFn.GetNoNullDecimal(rSource[ext_idclawback]);
				if (amount == 0) continue;

				//string fClw = "(idclawback = " + QueryCreator.quotedstrvalue(ext_idclawback, false) + ")";
				string fClw = QHC.CmpEq("idsor", R["idsor"]);
                //fClw = GetData.MergeFilters(fClassClw, fClw);

				DataRow [] ClawBackSorting = dsImport.clawbacksorting.Select(fClw);
				if (ClawBackSorting.Length == 0) {
					string errMess = "RECUPERO " + R["defaults1"]
						+ " NON CONFIGURATO! nella riga del file di importazione num. " + nRow;
                    fillLog(errMess);
                    continue;
				}
				DataRow rClawBackSorting = ClawBackSorting[0];

				MetaData MetaAdmPay_ClawBack = MetaData.GetMetaData(this, "admpay_clawback");
				MetaAdmPay_ClawBack.SetDefaults(dsImport.Tables["admpay_clawback"]);
				string filterExist = QHC.AppAnd(QHC.MCmp(rParent, new string [] {"yadmpay", "nadmpay"}),
                    QHC.CmpEq("idclawback", rClawBackSorting["idclawback"]));

				if (dsImport.Tables["admpay_clawback"].Select(filterExist).Length > 0) {
					DataRow rAPCB = dsImport.Tables["admpay_clawback"].Select(filterExist)[0];
					rAPCB["amount"] = CfgFn.GetNoNullDecimal(rAPCB["amount"]) + amount;
				}
				else {
					MetaData.SetDefault(dsImport.Tables["admpay_clawback"], "yadmpay", rParent["yadmpay"]);
					MetaData.SetDefault(dsImport.Tables["admpay_clawback"], "nadmpay", rParent["nadmpay"]);
					MetaData.SetDefault(dsImport.Tables["admpay_clawback"], "nexpense", rParent["nexpense"]);
					MetaData.SetDefault(dsImport.Tables["admpay_clawback"], "idclawback", rClawBackSorting["idclawback"]);
					DataRow rAPCB = MetaAdmPay_ClawBack.Get_New_Row(rParent, dsImport.Tables["admpay_clawback"]);
					rAPCB["amount"] = amount;
				}
			}
		}
        */
        private void scriviAdmPay_Expense_o_Income_Sorted(DataRow rSource, DataRow rParent, string IoE,
            ArrayList numClassToProcess, string task) {
			if (rSource == null) return;
            //if (dsImport.wageimportsetup.Rows.Count == 0) return;
            string fWIS = QHC.CmpEq("kind", task);
            DataRow rWageImportSetup = dsImport.wageimportsetup.Select(fWIS)[0];
            if (numClassToProcess.Count == 0) return;

			foreach(int i in numClassToProcess) {
				object SKM = rWageImportSetup["idsorkind_sortingmaster" + i];
				object SKC = rWageImportSetup["idsorkind_sortingchild" + i];

				string sortField;
				string tMasterName = "sortingmaster" + i;
				string filter = costruisciFiltro(tMasterName, rSource, task, out sortField);
				if (filter == null) continue;
				filter = filter.Replace("defaults", "M.defaults");

				string query = "SELECT M.idsor, M.defaults1, M.defaults2, M.defaults3, M.defaults4, M.defaults5 FROM sortingtranslation ST "
					+ " JOIN sorting M "
					+ " ON M.idsor = ST.idsortingmaster "
					+ " WHERE " + QHS.AppAnd(filter,
					" EXISTS(SELECT * FROM sortingtranslation ST2 "
                    + " JOIN sorting C "
                    + " ON C.idsor = ST2.idsortingchild "
					+ "	WHERE " +
                    QHS.AppAnd(QHS.CmpEq("ST2.idsortingmaster", QHS.Field("ST.idsortingmaster")),
                    QHS.CmpEq("C.idsorkind", SKC)) + ")", 
                    QHS.CmpEq("M.idsorkind", SKM));

				DataTable tOut = DataAccess.SQLRunner(Meta.Conn, query, true);
				if ((tOut == null) || (tOut.Rows.Count == 0)) continue;

				int min = 100;
				DataRow SelectedRow = null;
				foreach(DataRow rOut in tOut.Rows){
					int nNull = 0;
					foreach(DataColumn C in tOut.Columns) {
                        if (C.ColumnName == "idsor") continue;
						if (rOut[C] == DBNull.Value) nNull++;
					}
					if (nNull < min) {
						min = nNull;
						SelectedRow = rOut;
					}
				}
                string amount_field = "IMPORTO";
				addClass(SelectedRow, SKM, SKC, rParent, CfgFn.GetNoNullDecimal(rSource[amount_field]), IoE);
			}
		}

		private long calcolaMinimoComuneMultiplo(long x, long y) {

			long mcm = (x * y);
			long MCD = calcolaMassimoComuneDivisore(x, y);
			if (MCD != 0) mcm /= MCD;
			return mcm;
		}

		public long calcolaMassimoComuneDivisore(long x, long y) {
			while (y != 0) {
				long m = x % y;
				x = y;
				y = m;
			}
			return x;
		}

		/// <summary>
		/// Metodo che crea le righe in ADMPAY_EXPENSESORTED
		/// </summary>
		/// <param name="idSorChild"></param>
		/// <param name="SelectedRow"></param>
		/// <param name="rParent"></param>
		/// <param name="amount"></param>
        MetaData MetaAdmPay_EISorted;
		private void addClass(DataRow SelectedRow, object idSorMaster, object idSorChild,
            DataRow rParent, decimal amount, string IoE) {
			if (SelectedRow == null) return;
			if (idSorChild == DBNull.Value) return;
			if (amount == 0) return;
            string tName = (IoE == "I") ? "admpay_incomesorted" : "admpay_expensesorted";

			string query = "SELECT ST.idsortingchild, ST.denominator, ST.numerator FROM sortingtranslation ST " +
            " JOIN sorting M ON ST.idsortingmaster = M.idsor " +
            " JOIN sroting C ON ST.idsortingchild = C.idsor " +
            " WHERE " +
                QHS.AppAnd(QHS.CmpEq("M.idsorkind", idSorMaster),
                QHS.CmpEq("ST.idsortingmaster", SelectedRow["idsor"]),
                QHS.CmpEq("C.idsorkind", idSorChild));

			DataTable tSorting = DataAccess.SQLRunner(Meta.Conn, query, true);

			if ((tSorting == null) || (tSorting.Rows.Count == 0)) return;

			long mcm = 1;
			foreach(DataRow rSorting in tSorting.Rows) {
				long den = 1;
				if ((rSorting["numerator"] != DBNull.Value) && (rSorting["denominator"] != DBNull.Value)) {
					den = CfgFn.GetNoNullInt32(rSorting["denominator"]);
				}
				mcm = calcolaMinimoComuneMultiplo(mcm, den);
			}

			long sommaNum = 0;
			foreach(DataRow rSorting in tSorting.Rows) {
				int den = 0;
				int num = 0;
				if ((rSorting["numerator"] == DBNull.Value) && (rSorting["denominator"] == DBNull.Value)) {
					sommaNum += mcm;
				}
				else {
					den = CfgFn.GetNoNullInt32(rSorting["denominator"]);
					num = CfgFn.GetNoNullInt32(rSorting["numerator"]);
					if (den != 0) {
						sommaNum += (mcm / den) * num;
					}
				}
			}
			bool suUltimoVaiATappo = (sommaNum == mcm);

            string fieldMov = (IoE == "I") ? "nincome" : "nexpense";

			decimal progAmount = 0;
            int i = 0;
            foreach(DataRow rSorting in tSorting.Rows) {
                MetaAdmPay_EISorted = MetaData.GetMetaData(this, tName);
                MetaAdmPay_EISorted.SetDefaults(dsImport.Tables[tName]);
				MetaData.SetDefault(dsImport.Tables[tName], "yadmpay", rParent["yadmpay"]);
                MetaData.SetDefault(dsImport.Tables[tName], "nadmpay", rParent["nadmpay"]);
                MetaData.SetDefault(dsImport.Tables[tName], fieldMov, rParent[fieldMov]);
                MetaData.SetDefault(dsImport.Tables[tName], "idsor", rSorting["idsortingchild"]);
                DataRow rAPes = MetaAdmPay_EISorted.Get_New_Row(rParent, dsImport.Tables[tName]);
				
				decimal currAmount = amount;
				int currNum = 1;
				int currDen = 1;
				
				if ((rSorting["numerator"] != DBNull.Value) || (rSorting["denominator"] != DBNull.Value)) {
					currNum = CfgFn.GetNoNullInt32(rSorting["numerator"]);
					currDen = CfgFn.GetNoNullInt32(rSorting["denominator"]);
				}

				if ((suUltimoVaiATappo) && (i == tSorting.Rows.Count - 1)) {
					currAmount -= progAmount;
				}
				else {
					if (currDen != 0) {
						currAmount = currAmount * currNum / currDen;
					}
					else {
						currAmount = 0;
					}
				}
				currAmount = CfgFn.GetNoNullDecimal(currAmount);
				progAmount += currAmount;
				rAPes["amount"] = currAmount;

                i++;
			}
		}

        private DataRow scriviAdmPay_Appropriation_o_Assessment(DataRow rSource, string IoE) {
            string fFin = QHC.CmpEq("idfin", rSource["!idfin"]);

            string fUpb = QHC.CmpEq("idupb", rSource["!idupb"]);
            
			string f1 = GetData.MergeFilters(fFin, fUpb);
			string fAltri = leggiAltriCampi(rSource);
			string fFinale = GetData.MergeFilters(f1, fAltri);

            string tName = (IoE == "I") ? "admpay_assessment" : "admpay_appropriation";
			DataRow [] Impegnative = dsImport.Tables[tName].Select(fFinale);
			if (Impegnative.Length > 0) {
                Impegnative[0]["amount"] = CfgFn.GetNoNullDecimal(Impegnative[0]["amount"]) + CfgFn.GetNoNullDecimal(rSource["IMPORTO"]);
				return Impegnative[0];
			}
			return creaImpegnativaAccertamento(rSource, IoE);
		}

        private DataRow creaImpegnativaAccertamento(DataRow rSource, string IoE) {
            DataRow CurrStip = DS.admpay.Rows[0];
            string tName = (IoE == "I") ? "admpay_assessment" : "admpay_appropriation";
            string amountField = "IMPORTO";
			DataRow rParent = dsImport.Tables["admpay"].Rows[0];
			MetaData MetaAdmPay_Appropriation = MetaData.GetMetaData(this, tName);
			MetaAdmPay_Appropriation.SetDefaults(dsImport.Tables[tName]);
			DataRow rAPApp = MetaAdmPay_Appropriation.Get_New_Row(rParent, dsImport.Tables[tName]);
			rAPApp["amount"] = rSource[amountField];
            rAPApp["description"] = CurrStip["description"];// "Pagamento Stipendi";
			rAPApp["idfin"] = rSource["!idfin"];
			rAPApp["idupb"] = rSource["!idupb"];
			return rAPApp;
		}

        /// <summary>
        /// Data una riga (rSource) individua un oggetto ad essa correlata
        /// </summary>
        /// <param name="rSource">riga da processare</param>
        /// <param name="tName">informazione da ottenere (fin/registry..)</param>
        /// <param name="field">nome del campo da ottenere</param>
        /// <param name="IoE">per entrate o spese</param>
        /// <param name="task">L= Lordo, V=versamento, R=ritenute</param>
        /// <returns>valore associato</returns>
		private object individuaOggetto(DataRow rSource, string tName, string field, string IoE, string task) {
            string info = "nessun filtro";
            if (dsImport.wageimportsetup.Rows.Count == 0) {
                fillLog("Configurazione importazione stipendi inesistente");
                return null;
            }
            string fWIS = QHC.CmpEq("kind", task);
            DataRow [] WageImportSetup = dsImport.wageimportsetup.Select(fWIS);
            if (WageImportSetup.Length == 0) {
                string nomeTask = "";
                switch(task) {
                    case "L": {
                        nomeTask = "lordo";
                        break;
                    }
                    case "V": {
                        nomeTask = "versamento";
                        break;
                    }
                    case "R": {
                        nomeTask = "ritenute";
                        break;
                    }
                }
                fillLog("La configurazione del task " + nomeTask + " non è specificata");
                return null;
            }
            DataRow rWageImportSetup = WageImportSetup[0];
			string sortField;
            //Ottiene la condizione per prendere l'informazione su rSource relativa a tName
			string filter = costruisciFiltro(tName, rSource, task, out sortField);
            if (filter == null) return null;
			string f2 = QHS.CmpEq("S.idsorkind", rWageImportSetup["idsorkind_" + tName]);
			filter = GetData.MergeFilters(f2, filter);

            if (IoE != null) {
                string filtroUlteriore = "";
                if (tName == "fin") {
                    filtroUlteriore = (IoE == "I") ? QHS.BitClear("F.flag", 0)
                        : QHS.BitSet("F.flag", 0);
                    filtroUlteriore = QHS.AppAnd(filtroUlteriore, QHS.CmpEq("F.ayear", Meta.GetSys("esercizio")));
                }
                filter = GetData.MergeFilters(filter, filtroUlteriore);
            }

			// In base al filtro ottenuto vengono estratte N righe dalla classificazione
			// della tabella tNameSORTING
			// Verrà presa la voce che avrà meno null associati.
            string tNameChild = "";

            if (tName.StartsWith("accmotive")) {
                tNameChild = "accmotivesorting";
            }
            else {
                tNameChild = tName + "sorting";
            }

			// In listaCampi aggiungo tutti i campi derivanti dal metodo costruisci filtro e aggiungo la virgola davanti
			string listaCampi = (sortField != "") ? "," + sortField : "";
            string fieldForQuery = (field.StartsWith("idaccmotive")) ? "idaccmotive" : field;
            info = filter;
            string query = "";
            if (tName != "fin") {
                query = "SELECT " + fieldForQuery + listaCampi + " FROM sorting S "
                    + " JOIN " + tNameChild + " C "
                    + " ON S.idsor = C.idsor "
                    + " WHERE " + filter;
            }
            else {
                query = "SELECT F." + fieldForQuery + listaCampi + " FROM sorting S "
                    + " JOIN " + tNameChild + " C "
                    + " ON S.idsor = C.idsor "
                    + " JOIN fin F "
                    + " ON F.idfin = C.idfin"
                    + " WHERE " + filter;
            }

			DataTable tOut = DataAccess.SQLRunner(Meta.Conn, query, true);
            if ((tOut == null) || (tOut.Rows.Count == 0)) {
                fillLog(tName,info);
                return null;
            }
			int min = 100;
			object idobj = DBNull.Value;
			foreach(DataRow rOut in tOut.Rows) {
				int nNull = 0;
				foreach(DataColumn C in tOut.Columns) {
					if (C.ColumnName == fieldForQuery) continue;
					if ((rOut[C.ColumnName] == DBNull.Value) || (rOut[C.ColumnName].ToString().Trim() == ""))
                        nNull++;
				}
				if (nNull < min) {
					min = nNull;
					idobj = rOut[fieldForQuery];
				}
			}
			return idobj;
		}

		/// <summary>
		/// Metodo che restituisce il filtro che interrogherà la tabella di classificazione associata alla tabella tName
		/// </summary>
		/// <param name="tName">Nome della tabella principale</param>
		/// <param name="rSource">DataRow del foglio Excel</param>
        /// <param name="sortField">campi su cui è effettuato il confronto (usati in filtro result)</param>
		/// <returns></returns>
		private string costruisciFiltro(string tName, DataRow rSource, string task, out string sortField ) {
			sortField = "";
			// Dato preso dalla tabella di configurazione WAGEIMPORTSETUP
			if (dsImport.Tables["wageimportsetup"].Rows.Count == 0) return null;
            string fWIS = QHC.CmpEq("kind", task);
            DataRow [] WageImportSetup = dsImport.Tables["wageimportsetup"].Select(fWIS);
            if (WageImportSetup.Length == 0) return null;
            DataRow rWageImportSetup = WageImportSetup[0];

			// Dati del tipo di Classificazione impostata in WAGEIMPORTSETUP per la tabella tName
			string filter = QHC.CmpEq("idsorkind", rWageImportSetup["idsorkind_" + tName]);
			if (dsImport.Tables["sortingkind"].Select(filter).Length == 0) {
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImport.Tables["sortingkind"], null, filter, null, true);
			}

			if (dsImport.Tables["sortingkind"].Select(filter).Length == 0) return null;
			DataRow rSorKind = dsImport.Tables["sortingkind"].Select(filter)[0];

			// Costruzione del filtro
			// Attenzione: Nella tabella SORTINGKIND possono essere valorizzati i campi da labels1 a labels5
			// Per ogni labels valorizzata il filtro sarà costruito sull'uguaglianza altrimenti sul NULL
			int MAXLABEL = 5;
			string fS = "";
			for(int i = 1; i <= MAXLABEL; i++) {
				string colName = rSorKind["labels" + i].ToString();
				if (rSource.Table.Columns.Contains(colName)) {
                    string defname = "defaults" + i.ToString();
					sortField += defname + ",";
                    fS = QHS.AppAnd(fS, QHS.DoPar(QHS.AppOr(QHS.NullOrEq(defname, rSource[colName]),
                                QHS.CmpEq(defname, ""))));
				}
			}

			if (sortField != "") sortField = sortField.Substring(0,sortField.Length-1);

			// Il filtro prodotto sarà del tipo
			// (IDSORKIND = 'TIPOCLASSIFICAZIONE') AND ((DEFAULTS1 = 'AAA') OR (DEFAULTS1 IS NULL) OR (DEFAULTS1=''))
            // AND ((DEFAULTS2 = 'BBB') OR (DEFAULTS2 IS NULL) OR (DEFAULTS2='')) AND ((DEFAULTS3 IS NULL) etc.
			return fS;
		}

		private string ottieniListaCampi(DataRow rSource) {
			if (dsImport.Tables["sortingkind"].Rows.Count == 0) return null;
			DataRow rSorKind = dsImport.Tables["sortingkind"].Rows[0];
			string listaCampi = "";
			int MAXLABEL = 5;
			for(int i = 1; i <= MAXLABEL; i++) {
				
				if (rSource.Table.Columns.Contains(rSorKind["labels" + i].ToString())) {
					string colName = rSorKind["labels" + i].ToString();
					if (listaCampi != "") {
						listaCampi += ",";
					}
					if (colName != "") {
						listaCampi += rSource[colName].ToString();
					}
				}
			}
			return listaCampi;
		}
        /*
		private bool proiettaDati(DataTable tSource, string IoE, string task) {
			if (!tSource.Columns.Contains("!idfin")) {
				tSource.Columns.Add("!idfin");
			}

			if (!tSource.Columns.Contains("!idupb")) {
				tSource.Columns.Add("!idupb");
			}

			if (!tSource.Columns.Contains("!idser")) {
				tSource.Columns.Add("!idser");
			}

			if (!tSource.Columns.Contains("!idreg")) {
				tSource.Columns.Add("!idreg");
			}
            QueryCreator.MarkEvent("Inizio Proiezione: " + DateTime.Now);
            int hdl = metaprofiler.StartTimer("INIZIO PROIEZIONE...");
            FrmMeter FM = new FrmMeter("Proiezione dei dati");

            FM.pBar.Maximum = tSource.Rows.Count;
            FM.Show();
            bool problemi=false;
            int nRow = 0;
			foreach(DataRow rSource in tSource.Rows) {
                FM.pBar.Increment(1);
                nRow++;
                if ((nRow % 10) == 0) {
                    Application.DoEvents();
                    Cursor.Current = Cursors.WaitCursor;
                }
				object idfin = individuaOggetto(rSource, "fin", "idfin", IoE, task);
                rSource["!idfin"] = idfin;
                object idupb = individuaOggetto(rSource, "upb", "idupb", null, task);
                rSource["!idupb"] = idupb;
                object idser = individuaOggetto(rSource, "service", "idser", null, task);
                rSource["!idser"] = idser;
                object idreg = individuaOggetto(rSource, "registry", "idreg", null, task);
                rSource["!idreg"] = idreg;
                if (idreg == DBNull.Value) problemi = true;
            }

            FM.Close();
            Cursor.Current = Cursors.Default;
            Application.DoEvents();
            metaprofiler.StopTimer(hdl);
            QueryCreator.MarkEvent("Fine Proiezione: " + DateTime.Now);
			return !problemi;
		}
        */

        private void fillLog(string msg) {
            DataRow[] elenco = tErrorLog.Select(QHC.CmpEq("errore", msg));
            if (elenco.Length == 0) {
                DataRow rErrorLog = tErrorLog.NewRow();
                rErrorLog["nriga"] = 1 + CfgFn.GetNoNullInt32(tErrorLog.Compute("max(nriga)", null));
                rErrorLog["errore"] = msg;
                rErrorLog["occorrenze"] = 1;
                tErrorLog.Rows.Add(rErrorLog);
            }
            else {
                int N = CfgFn.GetNoNullInt32(elenco[0]["occorrenze"]) + 1;
                elenco[0]["occorrenze"] = N;
            }          
        }

        private void fillLog(string oggetto, string info) {
            string descr_oggetto = "";
            switch (oggetto) {
                case "fin": {
                    descr_oggetto = "la voce di bilancio";
                    break;
                }
                case "upb": {
                    descr_oggetto = "la U.P.B.";
                    break;
                }
                case "service": {
                    descr_oggetto = "la prestazione";
                    break;
                }
                case "registry": {
                    descr_oggetto = "l'anagrafica";
                    break;
                }
                default: {
                    descr_oggetto = "Oggetto non definito";
                    break;
                }
            }
            string msg = "Non è stato possibile ottenere " + descr_oggetto +
                " con la condizione " + info;
            fillLog(msg);

        }

        /// <summary>
        /// Metodo che riempie la struttura intermedia (tabelle figlie di admpay)
        /// </summary>
        /// <param name="tSource">DataTable con le righe del file di input</param>
        /// <param name="IoE">I = Meta movimenti di Entrata: E = Meta movimenti di spesa</param>
        /// <param name="task">Tipo di generazione: Valori Ammessi 1: Lordi; 2: Reversali; 3: Contributi</param>
        /// <param name="errMess">Messaggio di errore</param>
        /// <returns></returns>
		public bool generaMovimenti(DataTable tSource, string IoE, string task, out string errMess) {
            Cursor.Current = Cursors.WaitCursor;
			errMess = null;
			if (DS.admpay.Rows.Count == 0) { 
				errMess = "Non esiste alcuna riga di ADMPAY";
                Cursor.Current = Cursors.Default;
				return false;
			}
			tabelleCached(task);

            if (dsImport.wageimportsetup.Rows.Count == 0) return false;
            string fWIS = QHC.CmpEq("kind", task);
            DataRow rWageImportSetup = dsImport.wageimportsetup.Select(fWIS)[0];

            int maxNumClass = 5;
            ArrayList numClassToProcess = new ArrayList();
            for (int i = 1; i <= maxNumClass; i++) {
                if (rWageImportSetup["idsorkind_sortingmaster" + i] == DBNull.Value) continue;
                if (rWageImportSetup["idsorkind_sortingchild" + i] == DBNull.Value) continue;
                numClassToProcess.Add(i);
            }

			DataRow rAdmPayMaster = DS.admpay.Rows[0];
			DataRow rAdmPay = dsImport.admpay.NewRow();
			foreach(DataColumn C in DS.admpay.Columns) {
				rAdmPay[C.ColumnName] = rAdmPayMaster[C];
			}
			dsImport.admpay.Rows.Add(rAdmPay);
			dsImport.admpay.AcceptChanges();
			// Passo 1. Proiezione
            //bool res = proiettaDati(tSource, IoE, task);
            //if (!res) {
            //    show(this, "Si sono verificati dei problemi nella codifica dei dati",
            //        "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            FrmMeter FM = new FrmMeter("Generazione pseudo movimenti");

            FM.pBar.Maximum = tSource.Rows.Count;
            FM.Show();
            Cursor.Current = Cursors.WaitCursor;

			// Passo 2. Raggruppamento
			int nRow = 0;
            QueryCreator.MarkEvent("Inizio Raggruppamento Meta Movimenti: " + DateTime.Now + "\n\r");
            int hdl = metaprofiler.StartTimer("INIZIO RAGGRUPPAMENTO META MOVIMENTI...");
			foreach(DataRow rSource in tSource.Rows) {
                FM.pBar.Increment(1);
                nRow++;
                if ((nRow % 10) == 0) {
                    Application.DoEvents();
                }
                if (CfgFn.GetNoNullDecimal(rSource["IMPORTO"]) == 0) continue;
                DataRow rImpegnativa = scriviAdmPay_Appropriation_o_Assessment(rSource, IoE);
                DataRow rAPI = scriviAdmPay_Expense_o_Income(rSource, rImpegnativa, IoE);
                if (rAPI == null) continue;
                scriviAdmPay_Expense_o_Income_Sorted(rSource, rAPI, IoE, numClassToProcess, task);
                //if (IoE == "E") {
                    //scriviAdmPay_Tax(rSource, rAPE, nRow);
                    //scriviAdmPay_ClawBack(rSource, rAPE, nRow);
                //}
			}
            Cursor.Current = Cursors.Default;
            FM.Close();
            Application.DoEvents();
            metaprofiler.StopTimer(hdl);
            QueryCreator.MarkEvent("Fine Raggruppamento Meta Movimenti: " + DateTime.Now + "\n\r");
			return (tErrorLog.Rows.Count == 0);
		}

        ArrayList colFin = new ArrayList();
        ArrayList colUpb = new ArrayList();
        ArrayList colReg = new ArrayList();
        ArrayList colSer = new ArrayList();
        ArrayList colAm1 = new ArrayList();
        ArrayList colAm2 = new ArrayList();

        private bool addColInArrayList(string task) {
            tabelleCached(task);

            DataRow [] WIS = dsImport.Tables["wageimportsetup"].Select(QHC.CmpEq("kind", task));
            if (WIS.Length == 0) {
                string msg = "Tabella di configurazione importazione stipendi vuota per il compito scelto";
                show(this, msg);
                fillLog(msg);
                return false;
            }

            DataRow rWis = WIS[0];
            string [] sorKindToRead = new string [] {"idsorkind_fin", "idsorkind_upb", "idsorkind_registry", "idsorkind_service",
            "idsorkind_accmotivegroup1", "idsorkind_accmotivegroup2"};
            foreach (string field in sorKindToRead) {
                if (rWis[field] == DBNull.Value) continue;
                string query = "SELECT labels1, labels2, labels3, labels4, labels5 FROM sortingkind " +
                    " WHERE " + QHS.CmpEq("idsorkind", rWis[field]);
                DataTable tSK = Meta.Conn.SQLRunner(query);
                if (tSK == null) {
                    string msg1 = "Errore nell'estrazione dei dati dal tipo classificazione " + field;
                    show(this, msg1);
                    fillLog(msg1);
                    return false;
                }
                if (tSK.Rows.Count == 0) continue;
                int MAXLEN = 5;
                DataRow rSK = tSK.Rows[0];
                for(int i = 1; i <= MAXLEN; i++) {
                    string name = "labels" + i;
                    if ((rSK[name] == DBNull.Value) || (rSK[name].ToString() == "")) continue;
                    string colToAdd = rSK[name].ToString().ToUpper();
                    string tName = field.Replace("idsorkind_", "");
                    switch(tName) {
                        case "fin": {
                                colFin.Add(colToAdd);
                                break;
                            }
                        case "upb": {
                                colUpb.Add(colToAdd);
                                break;
                            }
                        case "registry": {
                                colReg.Add(colToAdd);
                                break;
                        }
                        case "service": {
                                colSer.Add(colToAdd);
                                break;
                        }
                        case "accmotivegroup1": {
                            colAm1.Add(colToAdd);
                            break;
                        }
                        case "accmotivegroup2": {
                            colAm2.Add(colToAdd);
                            break;
                        }
                    }
                }
            }
            return true;
        }

        Hashtable hFin = new Hashtable();
        Hashtable hUpb = new Hashtable();
        Hashtable hReg = new Hashtable();
        Hashtable hSer = new Hashtable();
        Hashtable hAm1 = new Hashtable();
        Hashtable hAm2 = new Hashtable();

        private bool CreaHashTable(string task) {
            if (!addColInArrayList(task)) {
                return false;
            }
            //addTableToDs();
            QueryCreator.MarkEvent("Inizio Creazione HashTable File Input: " + DateTime.Now + "\r\n");
            int hdl = metaprofiler.StartTimer("INIZIO Creazione HashTable...");

            FrmMeter FM = new FrmMeter("Creazione HashTable dal file di input");

            FM.pBar.Maximum = mData.Rows.Count;
            FM.Show();

            if (!mData.Columns.Contains("!idfin")) {
                mData.Columns.Add("!idfin");
            }
            if (!mData.Columns.Contains("!idupb")) {
                mData.Columns.Add("!idupb");
            }
            if (!mData.Columns.Contains("!idreg")) {
                mData.Columns.Add("!idreg");
            }
            if (!mData.Columns.Contains("!idser")) {
                mData.Columns.Add("!idser");
            }
            if (!mData.Columns.Contains("!idaccmotive1")) {
                mData.Columns.Add("!idaccmotive1");
            }
            if (!mData.Columns.Contains("!idaccmotive2")) {
                mData.Columns.Add("!idaccmotive2");
            }

            int nRow = 0;
            bool isOk = true;
            
            foreach (DataRow rData in mData.Rows) {
                FM.pBar.Increment(1);
                if (nRow % 20 == 0) {
                    Application.DoEvents();
                }
                nRow++;

                // Fin
                bool step1Ok = fillHt(colFin, rData, hFin, "fin", task);
                // Upb
                bool step2Ok = fillHt(colUpb, rData, hUpb, "upb", task);
                // Registry
                bool step3Ok = fillHt(colReg, rData, hReg, "registry", task);
                // Service
                bool step4Ok = fillHt(colSer, rData, hSer, "service", task);

                fillHt(colAm1, rData, hAm1, "accmotivegroup1", task);
                fillHt(colAm2, rData, hAm2, "accmotivegroup2", task);

                if (isOk) isOk = step1Ok && step2Ok && step3Ok && step4Ok;
            }
            FM.Close();
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
            metaprofiler.StopTimer(hdl);
            QueryCreator.MarkEvent("Fine Creazione HashTable File Input: " + DateTime.Now + "\n\r");
            return isOk;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="al">Elenco campi su cui creare l'hash</param>
        /// <param name="rSource">Riga di cui creare l'hash</param>
        /// <param name="htDest">Hash table in cui aggiungere l'hash</param>
        /// <param name="tName">Tabella oggetto dell'hash</param>
        /// <param name="task">tipo di hash (R o altro)</param>
        /// <returns></returns>
        private bool fillHt(ArrayList al, DataRow rSource, Hashtable htDest, string tName, string task) {
            string key = "";
            foreach (string c in al) {
                if (rSource[c] != DBNull.Value) {
                    key += rSource[c].ToString().ToUpper() +"§";
                }
                else {
                    key += "NULL§";
                }
            }

            if (key != "") {
                key = key.Remove(key.Length - 1);
            }

            string field = ottieniNomeCampo(tName);
            string tempField = "!" + field;
            if (htDest[key] == null) {
                string IoE = null;
                if (tName == "fin") {
                    IoE = (task == "R") ? "I" : "E";
                }
                //Ottiene l'oggetto in base alla sua classificazione
                object oggetto = individuaOggetto(rSource, tName, field, IoE, task);
                rSource[tempField] = oggetto;
                htDest[key] = oggetto;
            }
            else {
                rSource[tempField] = htDest[key];
            }

            if (tName == "registry") {
                if (rSource["!idreg"] == DBNull.Value) return false;
            }
            return true;
        }

        /// <summary>
        /// Restituisce il nome della chiave di una tabella
        /// </summary>
        /// <param name="tName"></param>
        /// <returns></returns>
        private string ottieniNomeCampo(string tName) {
            switch (tName) {
                case "fin":
                    return "idfin";
                case "upb":
                    return "idupb";
                case "registry":
                    return "idreg";
                case "service":
                    return "idser";
                case "accmotivegroup1":
                    return "idaccmotive1";
                case "accmotivegroup2":
                    return "idaccmotive2";
                default:
                    return null;
            }
        }

		private int getIntSys(string nome) {
			int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
			if (s==0) return 99;
			return s;
		}

		private void btnGeneraMovFin_Click(object sender, System.EventArgs e) {
            string fEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            dsFinancial.Clear();
			if (dsFinancial.config.Rows.Count == 0) {
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsFinancial.config,
					null, fEsercizio, null, true);
			}

			if (dsFinancial.sortingkind.Rows.Count == 0) {
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsFinancial.sortingkind, 
					null, null, null, true);
			}
            dsImport.Clear();
            riempiTabelle();
            if (!generaMovPrincipali("I")) {
                show(this, "Errore nella generazione dei movimenti finanziari di entrata");
                dsFinancial.Clear();
                dsFinancial.AcceptChanges();
                return;
            };
            if (!generaMovPrincipali("E")) {
                show(this, "Errore nella generazione dei movimenti finanziari di spesa");
                dsFinancial.Clear();
                dsFinancial.AcceptChanges();
                return;
            }
            doSave();
		}

        private void riempiTabelle() {
            if (DS.admpay.Rows.Count == 0) return;
            DataRow rAP = DS.admpay.Rows[0];
            string filter = QueryCreator.WHERE_KEY_CLAUSE(rAP, DataRowVersion.Current, true);
            ArrayList tableToFill = new ArrayList();

            tableToFill.Add("admpay_assessment");
            tableToFill.Add("admpay_income");
            tableToFill.Add("admpay_incomesorted");
            tableToFill.Add("admpay_appropriation");
            tableToFill.Add("admpay_expense");
            tableToFill.Add("admpay_expensesorted");
            // Attualmente queste 3 tabelle non vengono gestite
            //tableToFill.Add("admpay_employtax");
            //tableToFill.Add("admpay_admintax");
            //tableToFill.Add("admpay_clawback");

            foreach (string tName in tableToFill) {
                //if (dsImport.Tables[tName].Rows.Count == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsImport.Tables[tName], null, filter, null, true);
                //}
            }
        }

		void AddVoceBilancio(object ID){
			if ((ID==null)||(ID == DBNull.Value)) return;
			if (dsFinancial.fin.Select(QHC.CmpEq("idfin", ID)).Length>0)return;
			object codefin = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", ID), "codefin");
			DataRow NewBil = dsFinancial.fin.NewRow();
			NewBil["idfin"]=ID;
			NewBil["codefin"]=codefin;
			dsFinancial.fin.Rows.Add(NewBil);
			NewBil.AcceptChanges();
		}

		void AddVoceUpb(object ID){
            if ((ID == null) || (ID == DBNull.Value)) return;
            if (dsFinancial.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;
			object codeupb = Meta.Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", ID), "codeupb");
			DataRow NewUpb = dsFinancial.upb.NewRow();
			NewUpb["idupb"]=ID;
			NewUpb["codeupb"]=codeupb;
			dsFinancial.upb.Rows.Add(NewUpb);
			NewUpb.AcceptChanges();
		}

		void AddVoceCreditore(object codice){
			if ((codice == null) || (codice==DBNull.Value))return;
			if (dsFinancial.registry.Select(QHC.CmpEq("idreg", codice)).Length>0)return;
			object registry = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codice), "title");
			DataRow NewCred = dsFinancial.registry.NewRow();
			NewCred["idreg"]=codice;
			NewCred["title"]=registry;
			dsFinancial.registry.Rows.Add(NewCred);
			NewCred.AcceptChanges();
		}

		void AddVociCollegate(DataRow rExpense, DataRow rAppropriation){
			AddVoceBilancio(rAppropriation["idfin"]);
			AddVoceUpb(rAppropriation["idupb"]);
			AddVoceCreditore(rExpense["idreg"]);
		}

		void FillMovimento(DataRow E_S, DataRow Auto){ //, string idmovimento)
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			DateTime DataCont= Convert.ToDateTime(Meta.GetSys("datacontabile"));
			E_S.BeginEdit();
			E_S["ymov"]= esercizio;
			E_S["adate"]= DataCont;
			
			string [] fields_to_copy=new string[] {"idman","idreg","description"};
			foreach(string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (E_S.Table.Columns.Contains(field))E_S[field]= Auto[field];
			}
			E_S.EndEdit();
		}


		void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto, object importo){
			string [] fields_to_copy=new string[] {"idfin","idupb","codefin"};
			foreach(string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (ImpMov.Table.Columns[field] == null) continue;
				ImpMov[field]= Auto[field];
			}
			ImpMov["amount"]= CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(importo));
		}

        void RemoveDummyCols() {
            if (dsImport.Tables["admpay_assessment"].Columns.Contains("idmovimento")) {
                dsImport.Tables["admpay_assessment"].Columns.Remove("idmovimento");
            }
            if (dsImport.Tables["admpay_appropriation"].Columns.Contains("idmovimento")) {
                dsImport.Tables["admpay_appropriation"].Columns.Remove("idmovimento");
            }
            if (dsImport.Tables["admpay_income"].Columns.Contains("idmovimento")) {
                dsImport.Tables["admpay_income"].Columns.Remove("idmovimento");
            }
            if (dsImport.Tables["admpay_expense"].Columns.Contains("idmovimento")) {
                dsImport.Tables["admpay_expense"].Columns.Remove("idmovimento");
            }

        }
		private bool generaMovPrincipali(string IoE) {
			
            string tMain = (IoE == "I") ? "income" : "expense";
            string tMainYear = (IoE == "I") ? "incomeyear" : "expenseyear";
            string tMainLast = (IoE == "I") ? "incomelast" : "expenselast";
            string tMainSorted = (IoE == "I") ? "incomesorted" : "expensesorted";
			MetaData MetaM= Meta.Dispatcher.Get(tMain);
			MetaM.SetDefaults(dsFinancial.Tables[tMain]);

            MetaData MetaL = Meta.Dispatcher.Get(tMainLast);
            MetaL.SetDefaults(dsFinancial.Tables[tMainLast]);

			MetaData MetaImputazioneMov = Meta.Dispatcher.Get(tMainYear);
            MetaImputazioneMov.SetDefaults(dsFinancial.Tables[tMainYear]);

            string maxPhaseName = (IoE == "I") ? "maxincomephase" : "maxexpensephase";
            int fasemax = getIntSys(maxPhaseName);

            string regPhaseName = (IoE == "I") ? "incomeregphase" : "expenseregphase";
			int faseCreditoreDebitore = getIntSys(regPhaseName);

            string finPhaseName = (IoE == "I") ? "incomefinphase" : "expensefinphase";
            int faseBilancio = getIntSys(finPhaseName);

            string nAppAss = (IoE == "I") ? "nassessment" : "nappropriation";
            string tAppAss = (IoE == "I") ? "admpay_assessment" : "admpay_appropriation";
            string idMovField = (IoE == "I") ? "idinc" : "idexp";
            string idParMovField = (IoE == "I") ? "parentidinc" : "parentidexp";

            int esercizio = getIntSys("esercizio");

			DataTable Mov = dsFinancial.Tables[tMain];
			DataTable ImpMov = dsFinancial.Tables[tMainYear];


            string tAdmPayMov = (IoE == "I") ? "admpay_income" : "admpay_expense";

            //Ogni admpay_income/expense  punta alla propria ultima fase in income/expense
			if (!dsImport.Tables[tAdmPayMov].Columns.Contains("idmovimento")) {
                dsImport.Tables[tAdmPayMov].Columns.Add("idmovimento",typeof(int));
			}
            
            QueryCreator.SetColumnNameForPosting(dsImport.Tables[tAdmPayMov].Columns["idmovimento"], "");

            //Ogni meta-accertamento/impegno punta alla propria corrispondente fase in income/expense
            if (!dsImport.Tables[tAppAss].Columns.Contains("idmovimento")) {
                dsImport.Tables[tAppAss].Columns.Add("idmovimento", typeof(int));
            }

            //Riempie idfin/idupb di ogni impegno, in modo da poter poi copiare i dati alle fasi succ.
            string filter_getimp = QHS.AppAnd(QHS.CmpEq("ayear", esercizio),
                            QHS.FieldIn(idMovField, dsImport.Tables[tAppAss].Select(QHC.IsNotNull(idMovField))));
            DataTable DBImpMov = Meta.Conn.RUN_SELECT(tMainYear, "*", null, filter_getimp, null, false);
            foreach (DataRow myMImp in dsImport.Tables[tAppAss].Select(QHC.IsNotNull(idMovField))) {
                string filterimp = QHS.CmpEq(idMovField, myMImp[idMovField]);
                DataRow[] MImp = DBImpMov.Select(filterimp);
                if (MImp.Length == 0) {
                    show("Errore, il movimento con " + idMovField + "=" + myMImp[idMovField].ToString() +
                        " non è stato trovato nell'anno corrente.");
                    RemoveDummyCols();
                    return false;
                }
                myMImp["idfin"] = MImp[0]["idfin"];
                myMImp["idupb"] = MImp[0]["idupb"];
            }

            foreach (DataRow myMImp in dsImport.Tables[tAppAss].Select()) {
                string filter = QHC.CmpKey(myMImp);
                if (dsImport.Tables[tAdmPayMov].Select(filter).Length == 0) {
                    if (IoE == "I")
                        show("Il meta-accertamento n." + myMImp["nassessment"].ToString() +
                            " non ha incassi collegati e sarà ignorato");
                    else
                        show("Il meta-impegno n." + myMImp["nappropriation"].ToString() +
                            " non ha pagamenti collegati e sarà ignorato");
                    myMImp.Delete();
                }
            }
            dsImport.AcceptChanges();

            foreach (DataRow R in dsImport.Tables[tAdmPayMov].Rows) {

                string fAppr = QHC.AppAnd(QHC.MCmp(R, new string[] { "yadmpay", "nadmpay" }), QHC.CmpEq(nAppAss, R[nAppAss]));
				DataRow []rAppAss_LISTA = dsImport.Tables[tAppAss].Select(fAppr);
                if (rAppAss_LISTA.Length == 0) {
                    if (IoE=="I"){
                        show("Il meta movimento di entrata n." + R["nincome"].ToString() + " non è associato ad un meta accertamento");
                        RemoveDummyCols();
                        return false;
                    }
                    if (IoE == "E") {
                        show("Il meta movimento di spesa n." + R["nexpense"].ToString() + " non è associato ad un meta impegno");
                        RemoveDummyCols();
                        return false;
                    }

                }
                DataRow rAppAss = rAppAss_LISTA[0];
                object IDMOV_TOLINK = rAppAss[idMovField];
                int nfasetolink = 0;
                if (IDMOV_TOLINK != DBNull.Value)
                    nfasetolink = CfgFn.GetNoNullInt32(
                            Meta.Conn.DO_READ_VALUE(tMain, QHS.CmpEq(idMovField, IDMOV_TOLINK), "nphase"));

				AddVociCollegate(R, rAppAss);
				object parentidmov=DBNull.Value;

				for(int faseCorrente = 1; faseCorrente <= fasemax; faseCorrente++) {
                    if (IDMOV_TOLINK == DBNull.Value) {
                        if (faseCorrente <= faseBilancio) {
                            //SE IL META ACCERTAMENTO/IMPEGNO E' STATO GIA' CREATO NON DEVE FARE NULLA, SOLO SALTARE LA FASE
                            if (rAppAss["idmovimento"] != DBNull.Value) continue;
                        }
                    }
                    if (IDMOV_TOLINK != DBNull.Value) {
                        if (faseCorrente <= nfasetolink) continue;
                    }

					Mov.Columns["nphase"].DefaultValue= faseCorrente;

					DataRow NewMovRow = MetaM.Get_New_Row(null, Mov);
                    NewMovRow[idParMovField] = parentidmov;
                    parentidmov = NewMovRow[idMovField];
                    if (IDMOV_TOLINK == DBNull.Value) {
                        if (faseCorrente == faseBilancio) {                           
                            //Marca IL META ACC/IMP associandolo a questo movimento
                            rAppAss["idmovimento"] = NewMovRow[idMovField];
                        }

                        if (faseCorrente == faseBilancio + 1) {
                            //Deve associare, ove necessario, come parent il mov. di spesa associato al meta-accertamento/impegno
                            //AL POSTO DI QUELLO  creato nel passo precedente
                            NewMovRow[idParMovField] = rAppAss["idmovimento"];
                        }
                    }
                    if ((IDMOV_TOLINK != DBNull.Value) && (faseCorrente == nfasetolink + 1)) {
                        //Collega il mov. corrente a quello su db
                        NewMovRow[idParMovField] = IDMOV_TOLINK;
                    }

					FillMovimento(NewMovRow,R);
                    if (faseCorrente <= faseBilancio) {
                        NewMovRow["description"] = rAppAss["description"];
                    }

					R["idmovimento"]= NewMovRow[idMovField];
                    NewMovRow["nphase"] = faseCorrente;

					if (faseCorrente < faseCreditoreDebitore) {
						NewMovRow["idreg"] = DBNull.Value;
					}
	
                    if (faseCorrente==fasemax){
                        DataRow NewLastRow = MetaL.Get_New_Row(NewMovRow, dsFinancial.Tables[tMainLast]);
                        if (IoE == "E") {

                            object codicecreddeb = R["idreg"];
                            object registry = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codicecreddeb), "title");
                            DataRow ModPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, codicecreddeb);
                            if (ModPagam == null) {
                                show(this,
                                    "E' necessario che sia definita almeno una modalità di pagamento per il percipiente " +
                                    "\"" + registry.ToString() + "\"\n\n" +
                                    "Dati non salvati", "Errore", MessageBoxButtons.OK);
                                RemoveDummyCols();
                                return false;
                            }

                            //aggiungere le informazioni della modalità di pagamento
                            NewLastRow["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
                            NewLastRow["idpaymethod"] = ModPagam["idpaymethod"];
                            NewLastRow["iban"] = ModPagam["iban"];
                            NewLastRow["cin"] = ModPagam["cin"];
                            NewLastRow["idbank"] = ModPagam["idbank"];
                            NewLastRow["idcab"] = ModPagam["idcab"];
                            NewLastRow["cc"] = ModPagam["cc"];
                            NewLastRow["iddeputy"] = ModPagam["iddeputy"];
                            NewLastRow["refexternaldoc"] = ModPagam["refexternaldoc"];
                            NewLastRow["paymentdescr"] = ModPagam["paymentdescr"];
                        }
                        NewLastRow["flag"] = 0;
                        //fillExpenseTax(NewSpesaRow, R);
                        //fillExpenseClawBack(NewSpesaRow, R);
						
					}
                    fillMovSorted(NewMovRow, R);

					DataRow NewImpMov = ImpMov.NewRow();
                    object importo = DBNull.Value;
                    if (faseCorrente <= faseBilancio)
                        importo = rAppAss["amount"];
                    else
                        importo = R["amount"];

                    FillImputazioneMovimento(NewImpMov, rAppAss, importo);
                    NewImpMov[idMovField] = NewMovRow[idMovField];
					NewImpMov["ayear"]= esercizio;

					if (faseCorrente < faseBilancio) {
						NewImpMov["idfin"] = DBNull.Value;
						NewImpMov["idupb"] = DBNull.Value;
					}
					ImpMov.Rows.Add(NewImpMov);

                }
			}

            ////Imposta il livsupid di tutte le righe per cui è necessario
            //string tName = Mov.TableName;
            //string paridfield = (tName == "expense") ? "parentidexp" : "parentidinc";
            //foreach (DataRow R in dsImport.Tables[tAdmPayMov].Rows) {
            //    if (R[nAppAss] == DBNull.Value) continue;
            //    string fAppr = QHC.AppAnd(QHC.MCmp(R, new string[] { "yadmpay", "nadmpay" }),
            //        QHC.CmpEq(nAppAss, R[nAppAss]));
            //    DataRow[] AppAss = dsImport.Tables[tAppAss].Select(fAppr);
            //    if (AppAss.Length == 0) continue;
            //    object idtolink = AppAss[0][idMovField];
            //    if (idtolink == DBNull.Value) continue;

            //    object idmov = R["idmovimento"];

            //    int nfasetolink = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE(tName, QHS.CmpEq(idMovField, idtolink), "nphase"));
            //    if (nfasetolink == 0) continue;
            //    DataRow MovSel = Mov.Select(QHC.CmpEq(idMovField, idmov))[0];
            //    int currfase = CfgFn.GetNoNullInt32(MovSel["nphase"]);

            //    while (currfase > (nfasetolink + 1)) {
            //        idmov = MovSel[paridfield];
            //        MovSel = Mov.Select(QHC.CmpEq(idMovField, idmov))[0];
            //        currfase--;
            //    }
            //    MovSel[paridfield] = idtolink;
            //}


            //Cancella tutto ciò che non ha figli e non è di ultima fase sino a che non trova + nulla
            bool keep = true;
            while (keep) {
                keep = false;
                string filternolastphase = QHC.CmpNe("nphase", fasemax);
                foreach (DataRow Parent in Mov.Select(filternolastphase)) {
                    object idpar = Parent[idMovField];
                    string filterchild = QHC.CmpEq("parent" + idMovField, idpar);
                    if (Mov.Select(filterchild).Length == 0) {
                        string filterimp = QHC.CmpEq(idMovField, idpar);
                        DataRow Imp = ImpMov.Select(filterimp)[0];
                        Imp.Delete();
                        Parent.Delete();
                        keep = true;
                    }
                }
            }

            //Ricalcola tutti gli importi partendo dalla penultima fase per arrivare alla prima ove presente
            for (int myfase = fasemax - 1; myfase > 0; myfase--) {
                foreach (DataRow ToCalc in  Mov.Select(QHC.CmpEq("nphase", myfase))) {
                    //Prende tutte le righe figlie
                    string filterchild = QHS.FieldIn(idMovField,
                                Mov.Select(QHC.CmpEq(idParMovField, ToCalc[idMovField])));
                    object somma = ImpMov.Compute("SUM(amount)", filterchild);
                    DataRow ToAssign = ImpMov.Select(QHC.CmpEq(idMovField, ToCalc[idMovField]))[0];
                    ToAssign["amount"] = somma;
                }
            }
            RemoveDummyCols();
            return true;
		}

        private void doSave() {
            int faseMax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

            GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, dsFinancial,
            faseMax, faseMax, "expense", true);
            ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
            bool res = ga.GeneraAutomatismiAfterPost(true);
            if (!res) {
                show(this, "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
            }
            else {
                res = ga.doPost(Meta.Dispatcher);
                if (res) {
                    show(this, "Salvataggio dei movimenti finanziari avvenuto con successo");
                    if (DS.admpay.Rows.Count > 0) {
                        DS.admpay.Rows[0]["processed"] = "S";
                        Meta.SaveFormData();
                    }
                    // Qui devo ricopiare i dati nel Dataset principale
                }
                else {
                    show(this, "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                }
            }
            dsFinancial.Clear();
            dsFinancial.AcceptChanges();
        }

		/// <summary>
		/// Metodo che riempie la tabella EXPENSETAX da ADMPAY_EMPLOYTAX e da ADMPAY_ADMINTAX
		/// </summary>
		/// <param name="rExpense"></param>
		/// <param name="rAdmPay_Expense"></param>
		private void fillExpenseTax(DataRow rExpense, DataRow rAdmPay_Expense) {
			MetaData MetaExpenseTax = MetaData.GetMetaData(this, "expensetax");
			MetaExpenseTax.SetDefaults(dsFinancial.expensetax);
            string filter = QHC.CmpKey(rAdmPay_Expense);
			foreach(DataRow rEmploy in dsImport.admpay_employtax.Select(filter)) {
				// Viene sempre impostato l'nbracket pari a 1
				string fTax = QHC.AppAnd(QHC.CmpEq("taxcode", rEmploy["taxcode"]),
                    QHC.CmpEq("nbracket", 1));

				DataRow [] ExpTax = dsFinancial.expensetax.Select(fTax);
				if (ExpTax.Length > 0) {
					ExpTax[0]["employtax"] = CfgFn.GetNoNullDecimal(ExpTax[0]["employtax"]) +
						CfgFn.GetNoNullDecimal(rEmploy["amount"]);
				}
				else {
					DataRow rExpenseTax = MetaExpenseTax.Get_New_Row(rExpense, dsFinancial.expensetax);
					rExpenseTax["taxcode"] = rEmploy["taxcode"];
					rExpenseTax["nbracket"] = 1;
					rExpenseTax["employtax"] = rEmploy["amount"];
				}	
			}

			foreach(DataRow rAdmin in dsImport.admpay_admintax.Select(filter)) {
				// Viene sempre impostato l'nbracket pari a 1
				string fTax = QHC.AppAnd(QHC.CmpEq("taxcode", rAdmin["taxcode"]), QHC.CmpEq("nbracket", 1));

				DataRow [] ExpTax = dsFinancial.expensetax.Select(fTax);
				if (ExpTax.Length > 0) {
					ExpTax[0]["admintax"] = CfgFn.GetNoNullDecimal(ExpTax[0]["admintax"]) +
						CfgFn.GetNoNullDecimal(rAdmin["amount"]);
				}
				else {
					DataRow rExpenseTax = MetaExpenseTax.Get_New_Row(rExpense, dsFinancial.expensetax);
					rExpenseTax["taxcode"] = rAdmin["taxcode"];
					rExpenseTax["nbracket"] = 1;
					rExpenseTax["admintax"] = rAdmin["amount"];
				}
			}
		}

		private void fillExpenseClawBack(DataRow rExpense, DataRow rAdmPay_Expense) {
			MetaData MetaExpenseClawBack = MetaData.GetMetaData(this, "expenseclawback");
			MetaExpenseClawBack.SetDefaults(dsFinancial.expenseclawback);
			string filter = QHC.CmpKey(rAdmPay_Expense);
			foreach(DataRow rClawBack in dsImport.admpay_clawback.Select(filter)) {
				DataRow rExpenseClawBack = MetaExpenseClawBack.Get_New_Row(rExpense, dsFinancial.expenseclawback);
				rExpenseClawBack["idclawback"] = rClawBack["idclawback"];
				rExpenseClawBack["amount"] = rClawBack["amount"];
			}
		}

		private void fillMovSorted(DataRow rMov, DataRow rAdmPay_Mov) {
            string tMov = rMov.Table.TableName;
            string tMain = (tMov == "income") ? "incomesorted" : "expensesorted";
			MetaData MetaMovSorted = MetaData.GetMetaData(this, tMain);
            MetaMovSorted.SetDefaults(dsFinancial.Tables[tMain]);
			string filter = QHC.CmpKey(rAdmPay_Mov);

            string idMovField = (tMov == "income") ? "idinc" : "idexp";
            string tAdmPaySorted = (tMov == "income") ? "admpay_incomesorted" : "admpay_expensesorted";
            string movPhase = (tMov == "income") ? "nphaseincome" : "nphaseexpense";
			int phasemov = CfgFn.GetNoNullInt32(rMov["nphase"]);
			foreach(DataRow rMovSor in dsImport.Tables[tAdmPaySorted].Select(filter)) {
                object idsor = rMovSor["idsor"];
                string fSor = QHC.CmpEq("idsor", idsor);
                string fSorSQL = QHS.CmpEq("idsor", rMovSor["idsor"]);
                if (dsFinancial.Tables["sorting"].Select(fSor).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsFinancial.sorting, null,
                        fSorSQL, null, true);
                }
                if (dsFinancial.Tables["sorting"].Select(fSor).Length == 0) continue;
                DataRow rSorting = dsFinancial.Tables["sorting"].Select(fSor)[0];
                object idsorkind = rSorting["idsorkind"];
				DataRow [] Class = dsFinancial.sortingkind.Select(QHC.CmpEq("idsorkind", idsorkind));
				if (Class.Length == 0) continue;
				int sort_phase = CfgFn.GetNoNullInt32(Class[0][movPhase]);
                if (phasemov != sort_phase ) continue;
                MetaData.SetDefault(dsFinancial.Tables[tMain], "idsor", rMovSor["idsor"]);
                MetaData.SetDefault(dsFinancial.Tables[tMain], "idsubclass", rMovSor["idsubclass"]);
                DataRow rMovSorted = MetaMovSorted.Get_New_Row(rMov, dsFinancial.Tables[tMain]);
				rMovSorted["amount"] = rMovSor["amount"];
			}
        }

        /// <summary>
        /// Riempie il datatable MData leggendo dal foglio Excel
        /// </summary>
        /// <returns></returns>
        private bool LeggiFile() {
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr != DialogResult.OK) return false;
            try {
                string fileName = openFileDialog1.FileName;
                ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                    ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
                ReadCurrentSheet();
            }
            catch (Exception ex) {
                show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
                return false;
            }

            return true;
        }

        private void btnInsertAssessment_Click(object sender, EventArgs e) {
            Meta.Insert_Grid_Row(DGridAccertamenti, "detail");
        }

        private void btnEditAssessment_Click(object sender, EventArgs e) {
            MetaData.Edit_Grid(DGridAccertamenti, "detail");
        }

        private void btnVisualizzaEP_L_Click(object sender, EventArgs e) {
            EditEntry("L");
        }

        private void btnVisualizzaEP_R_Click(object sender, EventArgs e) {
            EditEntry("R");
        }

        private void btnVisualizzaEP_V_Click(object sender, EventArgs e) {
            EditEntry("V");
        }

        void EditEntry(string kind) {
            if (DS.admpay.Rows.Count == 0) return;
            DataRow R = DS.admpay.Rows[0];

            string idRelated = "admpay" + "§" + R["yadmpay"].ToString()
                + "§" + R["nadmpay"].ToString() + "§" + kind;

            EP_functions EP = new EP_functions(Meta.Dispatcher);
            EP.EditRelatedEntry(Meta, idRelated);
        }
	}
}
