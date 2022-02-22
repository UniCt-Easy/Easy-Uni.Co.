
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


namespace csa_importver_partition_expense_elenco {
    partial class Frm_csa_importver_partition_expense_elenco {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.DS = new csa_importver_partition_expense_elenco.vistaForm();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.gboxSpesa = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.cmbTipoMov = new System.Windows.Forms.ComboBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNum = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtEserc = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.gBoxCompetenza = new System.Windows.Forms.GroupBox();
			this.txtCompetenza = new System.Windows.Forms.TextBox();
			this.gBoxDatiCSA = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtEnteCsa = new System.Windows.Forms.TextBox();
			this.txtVoceCsa = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtRuoloCsa = new System.Windows.Forms.TextBox();
			this.txtCapitoloCsa = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.gboxtipo = new System.Windows.Forms.GroupBox();
			this.rdbCompetenza = new System.Windows.Forms.RadioButton();
			this.rdbResidui = new System.Windows.Forms.RadioButton();
			this.gBoxImportazione = new System.Windows.Forms.GroupBox();
			this.txtNumImport = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtEsercImport = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.gBoxVersamento = new System.Windows.Forms.GroupBox();
			this.txtNumVer = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.gBoxDettaglio = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.gBoxImporto = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.gBoxAnagraficaEnte = new System.Windows.Forms.GroupBox();
			this.txtCredDebEnte = new System.Windows.Forms.TextBox();
			this.gBoxEnte = new System.Windows.Forms.GroupBox();
			this.cmbEnte = new System.Windows.Forms.ComboBox();
			this.gBoxAnagraficaVer = new System.Windows.Forms.GroupBox();
			this.txtCredDebVer = new System.Windows.Forms.TextBox();
			this.gBoxAnagrafica = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gboxSpesa.SuspendLayout();
			this.gBoxCompetenza.SuspendLayout();
			this.gBoxDatiCSA.SuspendLayout();
			this.gboxtipo.SuspendLayout();
			this.gBoxImportazione.SuspendLayout();
			this.gBoxVersamento.SuspendLayout();
			this.gBoxDettaglio.SuspendLayout();
			this.gBoxImporto.SuspendLayout();
			this.gBoxAnagraficaEnte.SuspendLayout();
			this.gBoxEnte.SuspendLayout();
			this.gBoxAnagraficaVer.SuspendLayout();
			this.gBoxAnagrafica.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(208, 52);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account.title";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(8, 72);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(336, 20);
			this.txtCodiceConto.TabIndex = 4;
			this.txtCodiceConto.Tag = "account.codeacc";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(10, 45);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(120, 23);
			this.button5.TabIndex = 1;
			this.button5.TabStop = false;
			this.button5.Tag = "manage.account.tree";
			this.button5.Text = "Conto";
			// 
			// gboxSpesa
			// 
			this.gboxSpesa.Controls.Add(this.label15);
			this.gboxSpesa.Controls.Add(this.cmbTipoMov);
			this.gboxSpesa.Controls.Add(this.txtDescription);
			this.gboxSpesa.Controls.Add(this.label7);
			this.gboxSpesa.Controls.Add(this.txtNum);
			this.gboxSpesa.Controls.Add(this.label13);
			this.gboxSpesa.Controls.Add(this.txtEserc);
			this.gboxSpesa.Controls.Add(this.label12);
			this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
			this.gboxSpesa.Location = new System.Drawing.Point(9, 412);
			this.gboxSpesa.Name = "gboxSpesa";
			this.gboxSpesa.Size = new System.Drawing.Size(620, 152);
			this.gboxSpesa.TabIndex = 22;
			this.gboxSpesa.TabStop = false;
			this.gboxSpesa.Text = "Movimento di Spesa";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(38, 65);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 16);
			this.label15.TabIndex = 10;
			this.label15.Text = "Tipo";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbTipoMov
			// 
			this.cmbTipoMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoMov.DataSource = this.DS.csa_movkind;
			this.cmbTipoMov.DisplayMember = "description";
			this.cmbTipoMov.Location = new System.Drawing.Point(86, 64);
			this.cmbTipoMov.Name = "cmbTipoMov";
			this.cmbTipoMov.Size = new System.Drawing.Size(520, 21);
			this.cmbTipoMov.TabIndex = 9;
			this.cmbTipoMov.Tag = "csa_movkind.movkind?csa_importver_partition_expenseview.movkind";
			this.cmbTipoMov.ValueMember = "movkind";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(6, 14);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(600, 44);
			this.txtDescription.TabIndex = 6;
			this.txtDescription.Tag = "expenseview.description";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(39, 92);
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
			this.txtNum.Location = new System.Drawing.Point(217, 117);
			this.txtNum.Name = "txtNum";
			this.txtNum.Size = new System.Drawing.Size(194, 20);
			this.txtNum.TabIndex = 5;
			this.txtNum.Tag = "expenseview.nmov?csa_importver_partition_expenseview.nmov";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(158, 117);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(54, 16);
			this.label13.TabIndex = 4;
			this.label13.Text = "Numero:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEserc
			// 
			this.txtEserc.Location = new System.Drawing.Point(86, 117);
			this.txtEserc.Name = "txtEserc";
			this.txtEserc.Size = new System.Drawing.Size(56, 20);
			this.txtEserc.TabIndex = 3;
			this.txtEserc.Tag = "expenseview.ymov.year?csa_importver_partition_expenseview.ymov.year";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(5, 118);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(75, 16);
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
			this.cmbFaseSpesa.Location = new System.Drawing.Point(86, 93);
			this.cmbFaseSpesa.Name = "cmbFaseSpesa";
			this.cmbFaseSpesa.Size = new System.Drawing.Size(325, 21);
			this.cmbFaseSpesa.TabIndex = 2;
			this.cmbFaseSpesa.Tag = "expenseview.nphase?csa_importver_partition_expenseview.nphaseexpense";
			this.cmbFaseSpesa.ValueMember = "nphase";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(6, 20);
			this.txtCredDeb.Multiline = true;
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(383, 22);
			this.txtCredDeb.TabIndex = 23;
			this.txtCredDeb.Tag = "registry_main.title?csa_importver_partition_expenseview.registry_main";
			// 
			// gBoxCompetenza
			// 
			this.gBoxCompetenza.Controls.Add(this.txtCompetenza);
			this.gBoxCompetenza.Location = new System.Drawing.Point(10, 73);
			this.gBoxCompetenza.Name = "gBoxCompetenza";
			this.gBoxCompetenza.Size = new System.Drawing.Size(123, 50);
			this.gBoxCompetenza.TabIndex = 38;
			this.gBoxCompetenza.TabStop = false;
			this.gBoxCompetenza.Text = "Competenza";
			// 
			// txtCompetenza
			// 
			this.txtCompetenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCompetenza.Location = new System.Drawing.Point(6, 18);
			this.txtCompetenza.Multiline = true;
			this.txtCompetenza.Name = "txtCompetenza";
			this.txtCompetenza.Size = new System.Drawing.Size(105, 20);
			this.txtCompetenza.TabIndex = 1;
			this.txtCompetenza.TabStop = false;
			this.txtCompetenza.Tag = "csa_importver.competenza?csa_importver_partition_expenseview.competenza";
			// 
			// gBoxDatiCSA
			// 
			this.gBoxDatiCSA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gBoxDatiCSA.Controls.Add(this.textBox2);
			this.gBoxDatiCSA.Controls.Add(this.label2);
			this.gBoxDatiCSA.Controls.Add(this.textBox4);
			this.gBoxDatiCSA.Controls.Add(this.label4);
			this.gBoxDatiCSA.Controls.Add(this.label5);
			this.gBoxDatiCSA.Controls.Add(this.txtEnteCsa);
			this.gBoxDatiCSA.Controls.Add(this.txtVoceCsa);
			this.gBoxDatiCSA.Controls.Add(this.label3);
			this.gBoxDatiCSA.Controls.Add(this.label6);
			this.gBoxDatiCSA.Controls.Add(this.txtRuoloCsa);
			this.gBoxDatiCSA.Controls.Add(this.txtCapitoloCsa);
			this.gBoxDatiCSA.Controls.Add(this.label8);
			this.gBoxDatiCSA.Location = new System.Drawing.Point(11, 127);
			this.gBoxDatiCSA.Name = "gBoxDatiCSA";
			this.gBoxDatiCSA.Size = new System.Drawing.Size(619, 113);
			this.gBoxDatiCSA.TabIndex = 40;
			this.gBoxDatiCSA.TabStop = false;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(416, 73);
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(167, 20);
			this.textBox2.TabIndex = 8;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "csa_importver.matricola?csa_importver_partition_expenseview.matricola";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(416, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 16);
			this.label2.TabIndex = 7;
			this.label2.Text = "Matricola:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(184, 75);
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(215, 20);
			this.textBox4.TabIndex = 6;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "csa_importver.vocecsaunified?csa_importver_partition_expenseview.vocecsaunified";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(182, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(190, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Voce CSA per Raggruppamento:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(182, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Ente CSA:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEnteCsa
			// 
			this.txtEnteCsa.Location = new System.Drawing.Point(185, 33);
			this.txtEnteCsa.Name = "txtEnteCsa";
			this.txtEnteCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEnteCsa.Size = new System.Drawing.Size(171, 20);
			this.txtEnteCsa.TabIndex = 2;
			this.txtEnteCsa.TabStop = false;
			this.txtEnteCsa.Tag = "csa_importver.ente?csa_importver_partition_expenseview.ente";
			// 
			// txtVoceCsa
			// 
			this.txtVoceCsa.Location = new System.Drawing.Point(11, 75);
			this.txtVoceCsa.Name = "txtVoceCsa";
			this.txtVoceCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtVoceCsa.Size = new System.Drawing.Size(167, 20);
			this.txtVoceCsa.TabIndex = 4;
			this.txtVoceCsa.TabStop = false;
			this.txtVoceCsa.Tag = "csa_importver.vocecsa?csa_importver_partition_expenseview.vocecsa";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Voce CSA:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(413, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(127, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Ruolo CSA:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRuoloCsa
			// 
			this.txtRuoloCsa.Location = new System.Drawing.Point(417, 33);
			this.txtRuoloCsa.Name = "txtRuoloCsa";
			this.txtRuoloCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtRuoloCsa.Size = new System.Drawing.Size(170, 20);
			this.txtRuoloCsa.TabIndex = 3;
			this.txtRuoloCsa.TabStop = false;
			this.txtRuoloCsa.Tag = "csa_importver.ruolocsa?csa_importver_partition_expenseview.ruolocsa";
			// 
			// txtCapitoloCsa
			// 
			this.txtCapitoloCsa.Location = new System.Drawing.Point(8, 33);
			this.txtCapitoloCsa.Name = "txtCapitoloCsa";
			this.txtCapitoloCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCapitoloCsa.Size = new System.Drawing.Size(170, 20);
			this.txtCapitoloCsa.TabIndex = 1;
			this.txtCapitoloCsa.TabStop = false;
			this.txtCapitoloCsa.Tag = "csa_importver.capitolocsa?csa_importver_partition_expenseview.capitolocsa";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(105, 16);
			this.label8.TabIndex = 0;
			this.label8.Text = "Capitolo CSA:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gboxtipo
			// 
			this.gboxtipo.Controls.Add(this.rdbCompetenza);
			this.gboxtipo.Controls.Add(this.rdbResidui);
			this.gboxtipo.Location = new System.Drawing.Point(416, 64);
			this.gboxtipo.Name = "gboxtipo";
			this.gboxtipo.Size = new System.Drawing.Size(114, 59);
			this.gboxtipo.TabIndex = 37;
			this.gboxtipo.TabStop = false;
			this.gboxtipo.Text = "Tipo";
			// 
			// rdbCompetenza
			// 
			this.rdbCompetenza.Location = new System.Drawing.Point(11, 16);
			this.rdbCompetenza.Name = "rdbCompetenza";
			this.rdbCompetenza.Size = new System.Drawing.Size(90, 16);
			this.rdbCompetenza.TabIndex = 1;
			this.rdbCompetenza.Tag = "csa_importver.flagcr:C?csa_importver_partition_expenseview.flagcr:C";
			this.rdbCompetenza.Text = "Competenza";
			// 
			// rdbResidui
			// 
			this.rdbResidui.Location = new System.Drawing.Point(11, 36);
			this.rdbResidui.Name = "rdbResidui";
			this.rdbResidui.Size = new System.Drawing.Size(90, 16);
			this.rdbResidui.TabIndex = 1;
			this.rdbResidui.Tag = "csa_importver.flagcr:R?csa_importver_partition_expenseview.flagcr:R";
			this.rdbResidui.Text = "Residui";
			// 
			// gBoxImportazione
			// 
			this.gBoxImportazione.Controls.Add(this.txtNumImport);
			this.gBoxImportazione.Controls.Add(this.label9);
			this.gBoxImportazione.Controls.Add(this.txtEsercImport);
			this.gBoxImportazione.Controls.Add(this.label10);
			this.gBoxImportazione.Location = new System.Drawing.Point(139, 73);
			this.gBoxImportazione.Name = "gBoxImportazione";
			this.gBoxImportazione.Size = new System.Drawing.Size(271, 50);
			this.gBoxImportazione.TabIndex = 39;
			this.gBoxImportazione.TabStop = false;
			this.gBoxImportazione.Tag = "AutoChoose.txtNumImport.default";
			this.gBoxImportazione.Text = "Importazione";
			// 
			// txtNumImport
			// 
			this.txtNumImport.Location = new System.Drawing.Point(195, 15);
			this.txtNumImport.Name = "txtNumImport";
			this.txtNumImport.Size = new System.Drawing.Size(56, 20);
			this.txtNumImport.TabIndex = 2;
			this.txtNumImport.Tag = "csa_import.nimport?csa_importver_partition_expenseview.nimport";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(137, 17);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.TabIndex = 0;
			this.label9.Text = "Numero:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercImport
			// 
			this.txtEsercImport.Location = new System.Drawing.Point(68, 15);
			this.txtEsercImport.Name = "txtEsercImport";
			this.txtEsercImport.ReadOnly = true;
			this.txtEsercImport.Size = new System.Drawing.Size(56, 20);
			this.txtEsercImport.TabIndex = 1;
			this.txtEsercImport.Tag = "csa_import.yimport.year?csa_importver_partition_expenseview.yimport.year";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(6, 17);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 16);
			this.label10.TabIndex = 0;
			this.label10.Text = "Esercizio:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gBoxVersamento
			// 
			this.gBoxVersamento.Controls.Add(this.txtNumVer);
			this.gBoxVersamento.Controls.Add(this.label14);
			this.gBoxVersamento.Location = new System.Drawing.Point(12, 12);
			this.gBoxVersamento.Name = "gBoxVersamento";
			this.gBoxVersamento.Size = new System.Drawing.Size(105, 59);
			this.gBoxVersamento.TabIndex = 36;
			this.gBoxVersamento.TabStop = false;
			this.gBoxVersamento.Tag = "";
			this.gBoxVersamento.Text = "Versamento";
			// 
			// txtNumVer
			// 
			this.txtNumVer.Location = new System.Drawing.Point(22, 35);
			this.txtNumVer.Name = "txtNumVer";
			this.txtNumVer.Size = new System.Drawing.Size(56, 20);
			this.txtNumVer.TabIndex = 2;
			this.txtNumVer.Tag = "csa_importver.idver?csa_importver_partition_expenseview.idver";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(12, 17);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 16);
			this.label14.TabIndex = 0;
			this.label14.Text = "Numero:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gBoxDettaglio
			// 
			this.gBoxDettaglio.Controls.Add(this.textBox1);
			this.gBoxDettaglio.Controls.Add(this.label1);
			this.gBoxDettaglio.Location = new System.Drawing.Point(129, 20);
			this.gBoxDettaglio.Name = "gBoxDettaglio";
			this.gBoxDettaglio.Size = new System.Drawing.Size(144, 46);
			this.gBoxDettaglio.TabIndex = 35;
			this.gBoxDettaglio.TabStop = false;
			this.gBoxDettaglio.Tag = "";
			this.gBoxDettaglio.Text = "Dettaglio";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(82, 18);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(56, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Tag = "csa_importver_partition_expense.ndetail?csa_importver_partition_expenseview.ndeta" +
    "il";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Numero:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gBoxImporto
			// 
			this.gBoxImporto.Controls.Add(this.label11);
			this.gBoxImporto.Controls.Add(this.txtImporto);
			this.gBoxImporto.Location = new System.Drawing.Point(284, 20);
			this.gBoxImporto.Name = "gBoxImporto";
			this.gBoxImporto.Size = new System.Drawing.Size(144, 46);
			this.gBoxImporto.TabIndex = 34;
			this.gBoxImporto.TabStop = false;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(5, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 16);
			this.label11.TabIndex = 0;
			this.label11.Text = "Importo:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImporto
			// 
			this.txtImporto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImporto.Location = new System.Drawing.Point(67, 12);
			this.txtImporto.Multiline = true;
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(71, 20);
			this.txtImporto.TabIndex = 14;
			this.txtImporto.TabStop = false;
			this.txtImporto.Tag = "csa_importver_partition_expense.amount?csa_importver_partition_expenseview.amount" +
    "";
			// 
			// gBoxAnagraficaEnte
			// 
			this.gBoxAnagraficaEnte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gBoxAnagraficaEnte.Controls.Add(this.txtCredDebEnte);
			this.gBoxAnagraficaEnte.Location = new System.Drawing.Point(314, 300);
			this.gBoxAnagraficaEnte.Name = "gBoxAnagraficaEnte";
			this.gBoxAnagraficaEnte.Size = new System.Drawing.Size(325, 47);
			this.gBoxAnagraficaEnte.TabIndex = 53;
			this.gBoxAnagraficaEnte.TabStop = false;
			this.gBoxAnagraficaEnte.Tag = "AutoChoose.txtCredDebEnte.lista.(active=\'S\')";
			this.gBoxAnagraficaEnte.Text = "Anagrafica associata all\'Ente ";
			// 
			// txtCredDebEnte
			// 
			this.txtCredDebEnte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDebEnte.Location = new System.Drawing.Point(8, 17);
			this.txtCredDebEnte.Name = "txtCredDebEnte";
			this.txtCredDebEnte.Size = new System.Drawing.Size(311, 20);
			this.txtCredDebEnte.TabIndex = 1;
			this.txtCredDebEnte.Tag = "registry_agency.title?csa_importver_partition_expenseview.registry_agency";
			// 
			// gBoxEnte
			// 
			this.gBoxEnte.Controls.Add(this.cmbEnte);
			this.gBoxEnte.Location = new System.Drawing.Point(7, 299);
			this.gBoxEnte.Name = "gBoxEnte";
			this.gBoxEnte.Size = new System.Drawing.Size(301, 48);
			this.gBoxEnte.TabIndex = 52;
			this.gBoxEnte.TabStop = false;
			this.gBoxEnte.Text = "Ente";
			// 
			// cmbEnte
			// 
			this.cmbEnte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbEnte.DataSource = this.DS.csa_agency;
			this.cmbEnte.DisplayMember = "description";
			this.cmbEnte.Location = new System.Drawing.Point(9, 19);
			this.cmbEnte.Name = "cmbEnte";
			this.cmbEnte.Size = new System.Drawing.Size(286, 21);
			this.cmbEnte.TabIndex = 1;
			this.cmbEnte.Tag = "csa_agency.idcsa_agency?csa_importver_partitionview.idcsa_agency";
			this.cmbEnte.ValueMember = "idcsa_agency";
			// 
			// gBoxAnagraficaVer
			// 
			this.gBoxAnagraficaVer.Controls.Add(this.txtCredDebVer);
			this.gBoxAnagraficaVer.Location = new System.Drawing.Point(9, 246);
			this.gBoxAnagraficaVer.Name = "gBoxAnagraficaVer";
			this.gBoxAnagraficaVer.Size = new System.Drawing.Size(415, 48);
			this.gBoxAnagraficaVer.TabIndex = 51;
			this.gBoxAnagraficaVer.TabStop = false;
			this.gBoxAnagraficaVer.Tag = "AutoChoose.txtCredDebVer.lista.(active=\'S\')";
			this.gBoxAnagraficaVer.Text = "Anagrafica Regola specifica CSA";
			// 
			// txtCredDebVer
			// 
			this.txtCredDebVer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDebVer.Location = new System.Drawing.Point(8, 17);
			this.txtCredDebVer.Name = "txtCredDebVer";
			this.txtCredDebVer.Size = new System.Drawing.Size(401, 20);
			this.txtCredDebVer.TabIndex = 1;
			this.txtCredDebVer.Tag = "registry.title?csa_importver_partition_expenseview.registry";
			// 
			// gBoxAnagrafica
			// 
			this.gBoxAnagrafica.Controls.Add(this.txtCredDeb);
			this.gBoxAnagrafica.Location = new System.Drawing.Point(11, 353);
			this.gBoxAnagrafica.Name = "gBoxAnagrafica";
			this.gBoxAnagrafica.Size = new System.Drawing.Size(411, 48);
			this.gBoxAnagrafica.TabIndex = 54;
			this.gBoxAnagrafica.TabStop = false;
			this.gBoxAnagrafica.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
			this.gBoxAnagrafica.Text = "Anagrafica Movimento";
			// 
			// Frm_csa_importver_partition_expense_elenco
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(642, 571);
			this.Controls.Add(this.gBoxAnagrafica);
			this.Controls.Add(this.gBoxAnagraficaEnte);
			this.Controls.Add(this.gBoxEnte);
			this.Controls.Add(this.gBoxAnagraficaVer);
			this.Controls.Add(this.gBoxCompetenza);
			this.Controls.Add(this.gBoxDatiCSA);
			this.Controls.Add(this.gboxtipo);
			this.Controls.Add(this.gBoxImportazione);
			this.Controls.Add(this.gBoxVersamento);
			this.Controls.Add(this.gBoxDettaglio);
			this.Controls.Add(this.gBoxImporto);
			this.Controls.Add(this.gboxSpesa);
			this.Name = "Frm_csa_importver_partition_expense_elenco";
			this.Text = "Frm_csa_importver_partition_expense_elenco";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gboxSpesa.ResumeLayout(false);
			this.gboxSpesa.PerformLayout();
			this.gBoxCompetenza.ResumeLayout(false);
			this.gBoxCompetenza.PerformLayout();
			this.gBoxDatiCSA.ResumeLayout(false);
			this.gBoxDatiCSA.PerformLayout();
			this.gboxtipo.ResumeLayout(false);
			this.gBoxImportazione.ResumeLayout(false);
			this.gBoxImportazione.PerformLayout();
			this.gBoxVersamento.ResumeLayout(false);
			this.gBoxVersamento.PerformLayout();
			this.gBoxDettaglio.ResumeLayout(false);
			this.gBoxDettaglio.PerformLayout();
			this.gBoxImporto.ResumeLayout(false);
			this.gBoxImporto.PerformLayout();
			this.gBoxAnagraficaEnte.ResumeLayout(false);
			this.gBoxAnagraficaEnte.PerformLayout();
			this.gBoxEnte.ResumeLayout(false);
			this.gBoxAnagraficaVer.ResumeLayout(false);
			this.gBoxAnagraficaVer.PerformLayout();
			this.gBoxAnagrafica.ResumeLayout(false);
			this.gBoxAnagrafica.PerformLayout();
			this.ResumeLayout(false);

            }

        #endregion
        public vistaForm DS;
        private System.Windows.Forms.TextBox txtDenominazioneConto;
        private System.Windows.Forms.TextBox txtCodiceConto;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox gboxSpesa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEserc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbFaseSpesa;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.GroupBox gBoxCompetenza;
        private System.Windows.Forms.TextBox txtCompetenza;
        private System.Windows.Forms.GroupBox gBoxDatiCSA;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEnteCsa;
        private System.Windows.Forms.TextBox txtVoceCsa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRuoloCsa;
        private System.Windows.Forms.TextBox txtCapitoloCsa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gboxtipo;
        private System.Windows.Forms.RadioButton rdbCompetenza;
        private System.Windows.Forms.RadioButton rdbResidui;
        private System.Windows.Forms.GroupBox gBoxImportazione;
        private System.Windows.Forms.TextBox txtNumImport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEsercImport;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gBoxVersamento;
        private System.Windows.Forms.TextBox txtNumVer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gBoxDettaglio;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBoxImporto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbTipoMov;
        private System.Windows.Forms.GroupBox gBoxAnagraficaEnte;
        private System.Windows.Forms.TextBox txtCredDebEnte;
        private System.Windows.Forms.GroupBox gBoxEnte;
        private System.Windows.Forms.ComboBox cmbEnte;
        private System.Windows.Forms.GroupBox gBoxAnagraficaVer;
        private System.Windows.Forms.TextBox txtCredDebVer;
        private System.Windows.Forms.GroupBox gBoxAnagrafica;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
    }
