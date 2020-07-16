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

namespace bill_default {
    /// <summary>
    /// Summary description for FrmBill_Default.
    /// </summary>
    public class FrmBill_Default : System.Windows.Forms.Form {
        QueryHelper QHS;
        CQueryHelper QHC;
        MetaData Meta;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtApertura;
        private System.Windows.Forms.TextBox txtDataPagamento;
        private System.Windows.Forms.TextBox txtNumBolletta;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDaRegolarizzare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbPagamento;
        private System.Windows.Forms.RadioButton rdbIncasso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public bill_default.vistaForm DS;
        private TextBox textBox4;
        private Label label7;
        private GroupBox groupBox3;
        private ComboBox cmbCodiceIstituto;
        private Button btnIstitutoCassiere;
        private TextBox txtStorni;
        private Label label8;
        private GroupBox groupBox7;
        private TextBox txtDaEsitare;
        private Label label10;
        private DataGrid dgrRegolarizzazioni;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox txtEsiti;
        private Label label11;
        private TextBox txtImportoCorrente;
        private Label label12;
        private DataGrid dataGrid1;
        private Button btnCopertura;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmBill_Default() {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtApertura = new System.Windows.Forms.TextBox();
            this.txtDataPagamento = new System.Windows.Forms.TextBox();
            this.txtNumBolletta = new System.Windows.Forms.TextBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDaRegolarizzare = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbPagamento = new System.Windows.Forms.RadioButton();
            this.rdbIncasso = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DS = new bill_default.vistaForm();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.txtStorni = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgrRegolarizzazioni = new System.Windows.Forms.DataGrid();
            this.txtDaEsitare = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtImportoCorrente = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtEsiti = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCopertura = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRegolarizzazioni)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(76, 149);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(613, 49);
            this.textBox3.TabIndex = 30;
            this.textBox3.Tag = "bill.motive";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(76, 123);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(613, 20);
            this.textBox1.TabIndex = 28;
            this.textBox1.Tag = "bill.registry";
            // 
            // txtApertura
            // 
            this.txtApertura.Location = new System.Drawing.Point(214, 83);
            this.txtApertura.Name = "txtApertura";
            this.txtApertura.Size = new System.Drawing.Size(104, 20);
            this.txtApertura.TabIndex = 25;
            this.txtApertura.Tag = "bill.total";
            // 
            // txtDataPagamento
            // 
            this.txtDataPagamento.Location = new System.Drawing.Point(108, 83);
            this.txtDataPagamento.Name = "txtDataPagamento";
            this.txtDataPagamento.Size = new System.Drawing.Size(72, 20);
            this.txtDataPagamento.TabIndex = 23;
            this.txtDataPagamento.Tag = "bill.adate";
            // 
            // txtNumBolletta
            // 
            this.txtNumBolletta.Location = new System.Drawing.Point(322, 19);
            this.txtNumBolletta.Name = "txtNumBolletta";
            this.txtNumBolletta.Size = new System.Drawing.Size(80, 20);
            this.txtNumBolletta.TabIndex = 20;
            this.txtNumBolletta.Tag = "bill.nbill";
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(192, 19);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 17;
            this.txtEsercizio.Tag = "bill.ybill.year";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(28, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 29;
            this.label6.Text = "Causale";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Anagrafica";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDaRegolarizzare
            // 
            this.chkDaRegolarizzare.Checked = true;
            this.chkDaRegolarizzare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDaRegolarizzare.Location = new System.Drawing.Point(440, 17);
            this.chkDaRegolarizzare.Name = "chkDaRegolarizzare";
            this.chkDaRegolarizzare.Size = new System.Drawing.Size(112, 24);
            this.chkDaRegolarizzare.TabIndex = 26;
            this.chkDaRegolarizzare.Tag = "bill.active:S:N";
            this.chkDaRegolarizzare.Text = "Da regolarizzare";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(211, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Apertura bolletta";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Data contabile";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbPagamento);
            this.groupBox1.Controls.Add(this.rdbIncasso);
            this.groupBox1.Location = new System.Drawing.Point(20, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 64);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Partita pendente";
            // 
            // rdbPagamento
            // 
            this.rdbPagamento.Location = new System.Drawing.Point(8, 16);
            this.rdbPagamento.Name = "rdbPagamento";
            this.rdbPagamento.Size = new System.Drawing.Size(94, 20);
            this.rdbPagamento.TabIndex = 0;
            this.rdbPagamento.Tag = "bill.billkind:D";
            this.rdbPagamento.Text = "di pagamento";
            this.rdbPagamento.CheckedChanged += new System.EventHandler(this.rdbPagamento_CheckedChanged);
            // 
            // rdbIncasso
            // 
            this.rdbIncasso.Location = new System.Drawing.Point(8, 40);
            this.rdbIncasso.Name = "rdbIncasso";
            this.rdbIncasso.Size = new System.Drawing.Size(94, 20);
            this.rdbIncasso.TabIndex = 7;
            this.rdbIncasso.Tag = "bill.billkind:C";
            this.rdbIncasso.Text = "di incasso";
            this.rdbIncasso.CheckedChanged += new System.EventHandler(this.rdbIncasso_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(262, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Numero";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(136, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Esercizio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(3, 30);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(660, 46);
            this.textBox4.TabIndex = 34;
            this.textBox4.Tag = "bill.regularizationnote";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Note per la regolarizzazione";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cmbCodiceIstituto);
            this.groupBox3.Controls.Add(this.btnIstitutoCassiere);
            this.groupBox3.Location = new System.Drawing.Point(12, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(674, 51);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dati Contabili";
            // 
            // cmbCodiceIstituto
            // 
            this.cmbCodiceIstituto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
            this.cmbCodiceIstituto.DisplayMember = "description";
            this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(160, 19);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(508, 21);
            this.cmbCodiceIstituto.TabIndex = 1;
            this.cmbCodiceIstituto.Tag = "bill.idtreasurer?billview.idtreasurer";
            this.cmbCodiceIstituto.ValueMember = "idtreasurer";
            // 
            // btnIstitutoCassiere
            // 
            this.btnIstitutoCassiere.Location = new System.Drawing.Point(68, 16);
            this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(88, 24);
            this.btnIstitutoCassiere.TabIndex = 78;
            this.btnIstitutoCassiere.TabStop = false;
            this.btnIstitutoCassiere.Tag = "choose.treasurer.lista.(active=\'S\')";
            this.btnIstitutoCassiere.Text = "Cassiere:";
            this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStorni
            // 
            this.txtStorni.Location = new System.Drawing.Point(327, 83);
            this.txtStorni.Name = "txtStorni";
            this.txtStorni.ReadOnly = true;
            this.txtStorni.Size = new System.Drawing.Size(104, 20);
            this.txtStorni.TabIndex = 38;
            this.txtStorni.Tag = "bill.reduction";
            this.txtStorni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(324, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Storni";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.dgrRegolarizzazioni);
            this.groupBox7.Location = new System.Drawing.Point(3, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(660, 227);
            this.groupBox7.TabIndex = 39;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Dettaglio delle regolarizzazioni associate alla bolletta";
            // 
            // dgrRegolarizzazioni
            // 
            this.dgrRegolarizzazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrRegolarizzazioni.DataMember = "";
            this.dgrRegolarizzazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrRegolarizzazioni.Location = new System.Drawing.Point(12, 27);
            this.dgrRegolarizzazioni.Name = "dgrRegolarizzazioni";
            this.dgrRegolarizzazioni.Size = new System.Drawing.Size(642, 183);
            this.dgrRegolarizzazioni.TabIndex = 0;
            this.dgrRegolarizzazioni.Tag = "billtransaction.detail.adebito";
            // 
            // txtDaEsitare
            // 
            this.txtDaEsitare.Location = new System.Drawing.Point(562, 84);
            this.txtDaEsitare.Name = "txtDaEsitare";
            this.txtDaEsitare.ReadOnly = true;
            this.txtDaEsitare.Size = new System.Drawing.Size(106, 20);
            this.txtDaEsitare.TabIndex = 27;
            this.txtDaEsitare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(559, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Da regolarizzare";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 260);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(677, 265);
            this.tabControl1.TabIndex = 40;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtImportoCorrente);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.dataGrid1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(669, 239);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Apertura e storni";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtImportoCorrente
            // 
            this.txtImportoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoCorrente.Location = new System.Drawing.Point(553, 14);
            this.txtImportoCorrente.Name = "txtImportoCorrente";
            this.txtImportoCorrente.ReadOnly = true;
            this.txtImportoCorrente.Size = new System.Drawing.Size(106, 20);
            this.txtImportoCorrente.TabIndex = 33;
            this.txtImportoCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(435, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "Importo attuale";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(7, 45);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(651, 188);
            this.dataGrid1.TabIndex = 28;
            this.dataGrid1.Tag = "bankimportbill.detail.adebito";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(669, 239);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Regolarizzazioni";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(669, 239);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Altre informazioni";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtEsiti
            // 
            this.txtEsiti.Location = new System.Drawing.Point(440, 83);
            this.txtEsiti.Name = "txtEsiti";
            this.txtEsiti.ReadOnly = true;
            this.txtEsiti.Size = new System.Drawing.Size(104, 20);
            this.txtEsiti.TabIndex = 42;
            this.txtEsiti.Tag = "";
            this.txtEsiti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(437, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 20);
            this.label11.TabIndex = 41;
            this.label11.Text = "Esiti";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCopertura
            // 
            this.btnCopertura.Location = new System.Drawing.Point(561, 18);
            this.btnCopertura.Name = "btnCopertura";
            this.btnCopertura.Size = new System.Drawing.Size(128, 29);
            this.btnCopertura.TabIndex = 31;
            this.btnCopertura.Tag = "";
            this.btnCopertura.Text = "Documenti a copertura";
            this.btnCopertura.Click += new System.EventHandler(this.btnCopertura_Click);
            // 
            // FrmBill_Default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(701, 542);
            this.Controls.Add(this.txtEsiti);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDaEsitare);
            this.Controls.Add(this.txtStorni);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCopertura);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtApertura);
            this.Controls.Add(this.txtDataPagamento);
            this.Controls.Add(this.txtNumBolletta);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkDaRegolarizzare);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FrmBill_Default";
            this.Text = "FrmBill_Default";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrRegolarizzazioni)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        bool IsAdmin = false;

        DataAccess Conn;
        public void MetaData_AfterLink() {

            HelpForm.SetDenyNull(DS.bill.Columns["active"], true);

            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            if (Meta.GetSys("FlagMenuAdmin") != null)
                IsAdmin = (Meta.GetSys("FlagMenuAdmin").ToString() == "S");
            Meta.MarkTableAsNotEntityChild(DS.billtransaction);
            //btnCollegaBankImport.Tag = btnCollegaBankImport.Tag + "." + QHS.DoPar(QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            //Meta.CanSave = IsAdmin;
            //Meta.CanInsert = IsAdmin;
            //Meta.CanInsertCopy = IsAdmin;
            //Meta.CanCancel = IsAdmin;			
        }

        public void MetaData_AfterClear() {
            chkDaRegolarizzare.Enabled = true;
            btnCopertura.Visible = false;
            txtEsercizio.Text = Meta.Conn.GetSys("esercizio").ToString();
            AzzeratxtCalcolati();
        }

        public void MetaData_AfterFill() {
            chkDaRegolarizzare.Enabled = IsAdmin;
            if (Meta.FirstFillForThisRow) {
                string billkind = DS.bill.Rows[0]["billkind"].ToString().ToUpper();
                ImpostaTag(billkind == "D");
                switch (billkind) {
                    case "C":
                    btnCopertura.Visible = true;
                    btnCopertura.Text = "Incassi a copertura";

                    break;
                    case "D":
                    btnCopertura.Visible = true;
                    btnCopertura.Text = "Pagamenti a copertura";
                    break;
                    default: btnCopertura.Visible = false; break;
                }
            }
            DataRow Curr = DS.bill.Rows[0];
            string filtraBolletta = QHS.CmpKey(Curr);
            Meta.MarkTableAsNotEntityChild(DS.billtransaction);
            DS.billtransaction.ExtendedProperties[MetaData.ExtraParams] = filtraBolletta;
            EffettuaCalcoli();
        }


        private void btnCopertura_Click(object sender, System.EventArgs e) {
            if (DS.bill.Rows.Count == 0) return;
            DataRow R = DS.bill.Rows[0];
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            string filter = QHS.AppAnd(QHS.CmpEq("ayear", R["ybill"]), QHS.CmpEq("ymov", R["ybill"]),QHS.CmpEq("nbill", R["nbill"])); 

            string where_multiplo = QHS.AppAnd(QHS.CmpEq("ybill", R["ybill"]) ,QHS.CmpEq("nbill", R["nbill"]));
            string filtermultiplo = "";

            

            string table = null;
            if (DS.bill.Rows[0]["billkind"].ToString() == "C") {
                table = "income";
                DataTable t = Conn.RUN_SELECT("incomebill", "idinc", null, where_multiplo, null, false);
                if (t!=null && t.Rows.Count > 0) {
                    filtermultiplo = QHS.AppAnd(QHS.CmpEq("ayear", R["ybill"]),QHS.CmpEq("ymov", R["ybill"]),QHS.FieldIn("idinc", t.Select()));
                        //"  (idinc in (select idinc from incomebill EB where " + where_multiplo + "))";
                }
                
            }
            else {
                table = "expense";
                DataTable t = Conn.RUN_SELECT("expensebill", "idexp", null, where_multiplo, null, false);
                if (t != null && t.Rows.Count > 0) {
                    filtermultiplo = QHS.AppAnd(QHS.CmpEq("ayear", R["ybill"]), QHS.CmpEq("ymov", R["ybill"]), QHS.FieldIn("idexp", t.Select()));
                    //filtermultiplo = "  (idexp in (select idexp from expensebill EB where " + where_multiplo + "))";
                }
               
            }

            filter = QHS.DoPar(QHS.AppOr(filter, filtermultiplo));

            MetaData m = MetaData.GetDispatcher(this).Get(table);
            //m.SelectOne("default",filter,null,null);


            int rowsfound = Meta.Conn.RUN_SELECT_COUNT(table + "view", filter, true);
            if (rowsfound == 0) {
                MessageBox.Show("Nessun movimento trovato");
                return;
            }

            m.ContextFilter = filter;
            bool result = m.Edit(Meta.linkedForm.ParentForm, "default", false);
            DataRow RR = m.SelectOne("default", filter, null, null);
            if (RR != null) m.SelectRow(RR, "default");

        }

        private void rdbPagamento_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            ImpostaTag(rdbPagamento.Checked == true);

        }

        private void ImpostaTag(bool pagamento) {
            if (pagamento) {
                //btnEsitoInserisci.Tag = "insert.adebito";
                //btnEsitoModifica.Tag = "edit.adebito";
                dgrRegolarizzazioni.Tag = "billtransaction.detail.adebito";
            }
            else {
                //btnEsitoInserisci.Tag = "insert.acredito";
                //btnEsitoModifica.Tag = "edit.acredito";
                dgrRegolarizzazioni.Tag = "billtransaction.detail.acredito";
            }
        }
        private void rdbIncasso_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            ImpostaTag(rdbIncasso.Checked == false);

        }


        void EffettuaCalcoli() {
            if (Meta.IsEmpty) return;
            DataRow r=DS.bill.Rows[0];
            
            //valore iniziale di default
            decimal start = CfgFn.GetNoNullDecimal(r["total"]);
            decimal storni = CfgFn.GetNoNullDecimal(r["reduction"]);
                        

            //if (DS.bankimportbill.Rows.Count > 0) {
            //    storni = 0;
            //    start = 0;
            //    foreach(DataRow op in DS.bankimportbill.Select(null,"adate asc")){
            //        decimal amount = CfgFn.GetNoNullDecimal(op["amount"]);
            //        if (amount > 0) {
            //            start += amount;
            //        }
            //        else {
            //            storni -= amount;
            //        }
            //    }
            //}
            
            decimal importo_corrente = start - storni;


            decimal esiti = 0;
            foreach (DataRow op in DS.billtransaction.Select()) {
                esiti += CfgFn.GetNoNullDecimal(op["amount"]);
            }
            //per retrocompatibilit‡
            if (r["active"].ToString().ToUpper() == "N") {
                esiti = importo_corrente;
            }

            decimal da_regolarizzare = importo_corrente - esiti;

            if (storni != 0) {
                txtStorni.Text = storni.ToString("c");
            }
            else {
                if (txtStorni.Text != "") txtStorni.Text = storni.ToString("c");
            }
            txtEsiti.Text = esiti.ToString("c");
            txtDaEsitare.Text = da_regolarizzare.ToString("c");

            txtImportoCorrente.Text = importo_corrente.ToString("c");

        }
        void AzzeratxtCalcolati() {
            txtStorni.Text = "";
            txtEsiti.Text = "";
            txtImportoCorrente.Text = "";
            txtDaEsitare.Text = "";
        }
    }
}