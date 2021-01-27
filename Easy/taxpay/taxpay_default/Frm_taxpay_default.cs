
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using ep_functions;

namespace taxpay_default{//liquidazioneritenutaperiodica//
	/// <summary>
	/// Summary description for frmliquidazioneritperiodica.
	/// </summary>
	public class Frm_taxpay_default : System.Windows.Forms.Form {
		public vistaForm DS;
		MetaData Meta;
	    IDataAccess Conn;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.TextBox txtTotRitenute;
		private System.Windows.Forms.TextBox txtMovSpesa;
		private System.Windows.Forms.TextBox txtDataCont;
		private System.Windows.Forms.TextBox txtDataA;
		private System.Windows.Forms.TextBox txtDataDa;
        private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.TextBox txtImporto;
        private DataGrid dataGrid3;
        private TabControl tabControl1;
        private TabPage tabFin;
        private TabPage tabDett;
        private TabPage tabCorr;
        private TabPage tabPage1;
        private Button btnGeneraEP;
        private Button btnVisualizzaEP;
        private Label labEP;
	    private EP_Manager EPM;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Frm_taxpay_default() {
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
            this.DS = new taxpay_default.vistaForm();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txtDataCont = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataDa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotRitenute = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMovSpesa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFin = new System.Windows.Forms.TabPage();
            this.tabDett = new System.Windows.Forms.TabPage();
            this.tabCorr = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGeneraEP = new System.Windows.Forms.Button();
            this.btnVisualizzaEP = new System.Windows.Forms.Button();
            this.labEP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabFin.SuspendLayout();
            this.tabDett.SuspendLayout();
            this.tabCorr.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.txtEsercizio);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 80);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Liquidazione";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "taxpay.ntaxpay";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(64, 48);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(112, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.Tag = "taxpay.ytaxpay";
            this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "Esercizio:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "Ritenuta:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(176, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 20);
            this.label13.TabIndex = 14;
            this.label13.Text = "Numero:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.DS.tax;
            this.comboBox2.DisplayMember = "description";
            this.comboBox2.Location = new System.Drawing.Point(64, 16);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(272, 21);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.Tag = "taxpay.taxcode";
            this.comboBox2.ValueMember = "taxcode";
            // 
            // txtDataCont
            // 
            this.txtDataCont.Location = new System.Drawing.Point(232, 128);
            this.txtDataCont.Name = "txtDataCont";
            this.txtDataCont.Size = new System.Drawing.Size(120, 20);
            this.txtDataCont.TabIndex = 5;
            this.txtDataCont.Tag = "taxpay.adate";
            this.txtDataCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(200, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Data: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(72, 128);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(120, 20);
            this.txtImporto.TabIndex = 4;
            this.txtImporto.Tag = "taxpay.amount";
            this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Importo: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescr
            // 
            this.txtDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescr.Location = new System.Drawing.Point(360, 88);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(257, 64);
            this.txtDescr.TabIndex = 3;
            this.txtDescr.Tag = "taxpay.description";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(440, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Descrizione: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataA
            // 
            this.txtDataA.Location = new System.Drawing.Point(232, 96);
            this.txtDataA.Name = "txtDataA";
            this.txtDataA.Size = new System.Drawing.Size(120, 20);
            this.txtDataA.TabIndex = 2;
            this.txtDataA.Tag = "taxpay.stop";
            this.txtDataA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(200, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "al: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataDa
            // 
            this.txtDataDa.Location = new System.Drawing.Point(72, 96);
            this.txtDataDa.Name = "txtDataDa";
            this.txtDataDa.Size = new System.Drawing.Size(120, 20);
            this.txtDataDa.TabIndex = 1;
            this.txtDataDa.Tag = "taxpay.start";
            this.txtDataDa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Periodo dal: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(2, 6);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(602, 246);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Tag = "taxpayexpenseview.default";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTotRitenute);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtMovSpesa);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(360, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 64);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Totale importi";
            // 
            // txtTotRitenute
            // 
            this.txtTotRitenute.Location = new System.Drawing.Point(144, 32);
            this.txtTotRitenute.Name = "txtTotRitenute";
            this.txtTotRitenute.ReadOnly = true;
            this.txtTotRitenute.Size = new System.Drawing.Size(104, 20);
            this.txtTotRitenute.TabIndex = 1;
            this.txtTotRitenute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(152, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "Ritenute liquidate: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMovSpesa
            // 
            this.txtMovSpesa.Location = new System.Drawing.Point(8, 32);
            this.txtMovSpesa.Name = "txtMovSpesa";
            this.txtMovSpesa.ReadOnly = true;
            this.txtMovSpesa.Size = new System.Drawing.Size(124, 20);
            this.txtMovSpesa.TabIndex = 0;
            this.txtMovSpesa.Tag = "";
            this.txtMovSpesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Movimenti di spesa collegati: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(5, 6);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(596, 246);
            this.dataGrid2.TabIndex = 33;
            this.dataGrid2.Tag = "payedtaxview.default";
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(2, 3);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(602, 253);
            this.dataGrid3.TabIndex = 0;
            this.dataGrid3.Tag = "expensetaxcorrigeview.liquidazione";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabFin);
            this.tabControl1.Controls.Add(this.tabDett);
            this.tabControl1.Controls.Add(this.tabCorr);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 154);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 285);
            this.tabControl1.TabIndex = 36;
            // 
            // tabFin
            // 
            this.tabFin.Controls.Add(this.dataGrid1);
            this.tabFin.Location = new System.Drawing.Point(4, 22);
            this.tabFin.Name = "tabFin";
            this.tabFin.Padding = new System.Windows.Forms.Padding(3);
            this.tabFin.Size = new System.Drawing.Size(607, 259);
            this.tabFin.TabIndex = 0;
            this.tabFin.Text = "Movimenti Finanziari";
            this.tabFin.UseVisualStyleBackColor = true;
            // 
            // tabDett
            // 
            this.tabDett.Controls.Add(this.dataGrid2);
            this.tabDett.Location = new System.Drawing.Point(4, 22);
            this.tabDett.Name = "tabDett";
            this.tabDett.Padding = new System.Windows.Forms.Padding(3);
            this.tabDett.Size = new System.Drawing.Size(607, 259);
            this.tabDett.TabIndex = 1;
            this.tabDett.Text = "Dettaglio Ritenute";
            this.tabDett.UseVisualStyleBackColor = true;
            // 
            // tabCorr
            // 
            this.tabCorr.Controls.Add(this.dataGrid3);
            this.tabCorr.Location = new System.Drawing.Point(4, 22);
            this.tabCorr.Name = "tabCorr";
            this.tabCorr.Size = new System.Drawing.Size(607, 259);
            this.tabCorr.TabIndex = 2;
            this.tabCorr.Text = "Correzioni alle Ritenute";
            this.tabCorr.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnGeneraEP);
            this.tabPage1.Controls.Add(this.btnVisualizzaEP);
            this.tabPage1.Controls.Add(this.labEP);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(607, 259);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "EP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnGeneraEP
            // 
            this.btnGeneraEP.Location = new System.Drawing.Point(380, 38);
            this.btnGeneraEP.Name = "btnGeneraEP";
            this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
            this.btnGeneraEP.TabIndex = 16;
            this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
            // 
            // btnVisualizzaEP
            // 
            this.btnVisualizzaEP.Location = new System.Drawing.Point(380, 6);
            this.btnVisualizzaEP.Name = "btnVisualizzaEP";
            this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEP.TabIndex = 15;
            this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
            // 
            // labEP
            // 
            this.labEP.Location = new System.Drawing.Point(9, 13);
            this.labEP.Name = "labEP";
            this.labEP.Size = new System.Drawing.Size(352, 16);
            this.labEP.TabIndex = 14;
            this.labEP.Text = "Le scritture in partita doppia sono state generate.";
            // 
            // Frm_taxpay_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(625, 440);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtDataCont);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDataA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDataDa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Name = "Frm_taxpay_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmliquidazioneritperiodica";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabFin.ResumeLayout(false);
            this.tabDett.ResumeLayout(false);
            this.tabCorr.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        QueryHelper QHS;
        CQueryHelper QHC;
	    private ISecurity sec;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            this.Conn = this.getInstance<IDataAccess>();
		    sec = this.getInstance<ISecurity>();
		    QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			//Meta.CanCancel=false;
			Meta.CanInsert=false;
			Meta.CanInsertCopy = false;
            GetData.SetStaticFilter(DS.taxpayexpenseview,QHS.CmpEq("ayear",Meta.GetSys("esercizio")));
            
		    EPM = new EP_Manager(Meta, null, null, null, null, btnGeneraEP, btnVisualizzaEP, labEP, null, "taxpay");
            //DS.taxpayexpenseview.setTableForPosting("expensetax");
            // grid movimenti finanziari è taxpayexpenseview
            // grid  ritenute è payedtaxview
            // grid correz.ritenute è expensetaxcorrigeview
            
            //DS.taxpayexpenseview.setTableForPosting("expensetax");
            DS.payedtaxview.setTableForPosting("expensetax");
            
            //DS.Relations["taxpaytaxpayexpenseview"].ExtendedProperties["isSubentity"] = false;
            DS.Relations["taxpay_payedtaxview"].ExtendedProperties["isSubentity"] = false;
            //Meta.CanSave =false;
		}

	    
		public void MetaData_AfterClear () {
		    EPM.mostraEtichette();
			txtEsercizio.Text =sec.GetEsercizio().ToString();
			txtMovSpesa.Text="";
			txtTotRitenute.Text="";
			txtDataA.ReadOnly=false;
			txtDataDa.ReadOnly=false;
			txtDataCont.ReadOnly=false;
			txtTotRitenute.ReadOnly=false;
			txtImporto.ReadOnly=false;
		}
	
		public void MetaData_AfterFill() {
            EPM.mostraEtichette();
            txtDataA.ReadOnly=true;
			txtDataDa.ReadOnly=true;
			txtDataCont.ReadOnly=true;
			txtTotRitenute.ReadOnly=true;
			txtImporto.ReadOnly=true;

			decimal totale = CfgFn.GetNoNullDecimal(
				DS.taxpayexpenseview.Compute("SUM(curramount)",
                QHC.CmpEq("nphase",Conn.GetSys("maxexpensephase"))));
			try {
				txtMovSpesa.Text= totale.ToString("C");
			}
			catch (Exception E) {
				MessageBox.Show(E.Message);
			}

            decimal totrit = MetaData.SumColumn(DS.payedtaxview, "employtax") +
                        MetaData.SumColumn(DS.payedtaxview, "admintax") +
                        MetaData.SumColumn(DS.expensetaxcorrigeview, "employamount") +
                        MetaData.SumColumn(DS.expensetaxcorrigeview, "adminamount");

            txtTotRitenute.Text = totrit.ToString("C");
		}

	    public void MetaData_BeforePost() {
	        EPM.beforePost();
	    }

	    public void MetaData_AfterPost() {
	        EPM.afterPost();
	    }
	}
}
