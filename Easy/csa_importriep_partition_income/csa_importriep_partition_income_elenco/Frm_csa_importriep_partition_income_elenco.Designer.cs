/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿namespace csa_importriep_partition_income_elenco {
    partial class Frm_csa_importriep_partition_income_elenco {
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
            this.DS = new csa_importriep_partition_income_elenco.vistaForm();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.gboxEntrata = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoMov = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseEntrata = new System.Windows.Forms.ComboBox();
            this.gBoxCapitoloCSA = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRuoloCsa = new System.Windows.Forms.TextBox();
            this.txtCapitoloCsa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gBoxCompetenza = new System.Windows.Forms.GroupBox();
            this.txtCompetenza = new System.Windows.Forms.TextBox();
            this.gBoxImportazione = new System.Windows.Forms.GroupBox();
            this.txtNumImport = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEsercImport = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gboxtipo = new System.Windows.Forms.GroupBox();
            this.rdbCompetenza = new System.Windows.Forms.RadioButton();
            this.rdbResidui = new System.Windows.Forms.RadioButton();
            this.grpMatricola = new System.Windows.Forms.GroupBox();
            this.txtMatricola = new System.Windows.Forms.TextBox();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.gBoxRegolaSpecifica = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTipoContratto = new System.Windows.Forms.ComboBox();
            this.txtNumContratto = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEsercContratto = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gBoxDettaglio = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gBoxRiepilogo = new System.Windows.Forms.GroupBox();
            this.txtNumRiep = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gBoxImporto = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.gBoxAnagraficaRiep = new System.Windows.Forms.GroupBox();
            this.txtCredDebRiep = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxEntrata.SuspendLayout();
            this.gBoxCapitoloCSA.SuspendLayout();
            this.gBoxCompetenza.SuspendLayout();
            this.gBoxImportazione.SuspendLayout();
            this.gboxtipo.SuspendLayout();
            this.grpMatricola.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.gBoxRegolaSpecifica.SuspendLayout();
            this.gBoxDettaglio.SuspendLayout();
            this.gBoxRiepilogo.SuspendLayout();
            this.gBoxImporto.SuspendLayout();
            this.gBoxAnagraficaRiep.SuspendLayout();
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
            // gboxEntrata
            // 
            this.gboxEntrata.Controls.Add(this.label2);
            this.gboxEntrata.Controls.Add(this.cmbTipoMov);
            this.gboxEntrata.Controls.Add(this.txtDescription);
            this.gboxEntrata.Controls.Add(this.label7);
            this.gboxEntrata.Controls.Add(this.txtNum);
            this.gboxEntrata.Controls.Add(this.label13);
            this.gboxEntrata.Controls.Add(this.txtEserc);
            this.gboxEntrata.Controls.Add(this.label12);
            this.gboxEntrata.Controls.Add(this.cmbFaseEntrata);
            this.gboxEntrata.Location = new System.Drawing.Point(11, 308);
            this.gboxEntrata.Name = "gboxEntrata";
            this.gboxEntrata.Size = new System.Drawing.Size(523, 152);
            this.gboxEntrata.TabIndex = 22;
            this.gboxEntrata.TabStop = false;
            this.gboxEntrata.Text = "Movimento di Entrata";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tipo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoMov
            // 
            this.cmbTipoMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoMov.DataSource = this.DS.csa_movkind;
            this.cmbTipoMov.DisplayMember = "description";
            this.cmbTipoMov.Location = new System.Drawing.Point(82, 67);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Size = new System.Drawing.Size(435, 21);
            this.cmbTipoMov.TabIndex = 11;
            this.cmbTipoMov.Tag = "csa_movkind.movkind?csa_importriep_partition_incomeview.movkind";
            this.cmbTipoMov.ValueMember = "movkind";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(6, 18);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(511, 43);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.Tag = "incomeview.description";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(35, 93);
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
            this.txtNum.Location = new System.Drawing.Point(213, 118);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(97, 20);
            this.txtNum.TabIndex = 5;
            this.txtNum.Tag = "incomeview.nmov?csa_importriep_partition_incomeview.nmov";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(154, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Numero:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(82, 118);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 3;
            this.txtEserc.Tag = "incomeview.ymov.year?csa_importriep_partition_incomeview.ymov.year";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(1, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Esercizio:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseEntrata
            // 
            this.cmbFaseEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFaseEntrata.DataSource = this.DS.incomephase;
            this.cmbFaseEntrata.DisplayMember = "description";
            this.cmbFaseEntrata.Location = new System.Drawing.Point(82, 94);
            this.cmbFaseEntrata.Name = "cmbFaseEntrata";
            this.cmbFaseEntrata.Size = new System.Drawing.Size(228, 21);
            this.cmbFaseEntrata.TabIndex = 2;
            this.cmbFaseEntrata.Tag = "incomeview.nphase?csa_importriep_partition_incomeview.nphaseincome";
            this.cmbFaseEntrata.ValueMember = "nphase";
            // 
            // gBoxCapitoloCSA
            // 
            this.gBoxCapitoloCSA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxCapitoloCSA.Controls.Add(this.label3);
            this.gBoxCapitoloCSA.Controls.Add(this.txtRuoloCsa);
            this.gBoxCapitoloCSA.Controls.Add(this.txtCapitoloCsa);
            this.gBoxCapitoloCSA.Controls.Add(this.label4);
            this.gBoxCapitoloCSA.Location = new System.Drawing.Point(384, 178);
            this.gBoxCapitoloCSA.Name = "gBoxCapitoloCSA";
            this.gBoxCapitoloCSA.Size = new System.Drawing.Size(209, 72);
            this.gBoxCapitoloCSA.TabIndex = 50;
            this.gBoxCapitoloCSA.TabStop = false;
            this.gBoxCapitoloCSA.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(31, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ruolo CSA:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRuoloCsa
            // 
            this.txtRuoloCsa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuoloCsa.Location = new System.Drawing.Point(113, 43);
            this.txtRuoloCsa.Name = "txtRuoloCsa";
            this.txtRuoloCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRuoloCsa.Size = new System.Drawing.Size(82, 20);
            this.txtRuoloCsa.TabIndex = 14;
            this.txtRuoloCsa.TabStop = false;
            this.txtRuoloCsa.Tag = "csa_importriep.ruolocsa?csa_importriep_partition_incomeview.ruolocsa";
            // 
            // txtCapitoloCsa
            // 
            this.txtCapitoloCsa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCapitoloCsa.Location = new System.Drawing.Point(113, 11);
            this.txtCapitoloCsa.Name = "txtCapitoloCsa";
            this.txtCapitoloCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCapitoloCsa.Size = new System.Drawing.Size(82, 20);
            this.txtCapitoloCsa.TabIndex = 13;
            this.txtCapitoloCsa.TabStop = false;
            this.txtCapitoloCsa.Tag = "csa_importriep.capitolocsa?csa_importriep_partition_incomeview.capitolocsa";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(33, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Capitolo CSA:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gBoxCompetenza
            // 
            this.gBoxCompetenza.Controls.Add(this.txtCompetenza);
            this.gBoxCompetenza.Location = new System.Drawing.Point(11, 116);
            this.gBoxCompetenza.Name = "gBoxCompetenza";
            this.gBoxCompetenza.Size = new System.Drawing.Size(110, 56);
            this.gBoxCompetenza.TabIndex = 45;
            this.gBoxCompetenza.TabStop = false;
            this.gBoxCompetenza.Text = "Competenza";
            // 
            // txtCompetenza
            // 
            this.txtCompetenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompetenza.Location = new System.Drawing.Point(12, 23);
            this.txtCompetenza.Multiline = true;
            this.txtCompetenza.Name = "txtCompetenza";
            this.txtCompetenza.Size = new System.Drawing.Size(92, 20);
            this.txtCompetenza.TabIndex = 14;
            this.txtCompetenza.TabStop = false;
            this.txtCompetenza.Tag = "csa_importriep.competenza.year?csa_importriep_partition_incomeview.competenza.yea" +
    "r";
            // 
            // gBoxImportazione
            // 
            this.gBoxImportazione.Controls.Add(this.txtNumImport);
            this.gBoxImportazione.Controls.Add(this.label8);
            this.gBoxImportazione.Controls.Add(this.txtEsercImport);
            this.gBoxImportazione.Controls.Add(this.label9);
            this.gBoxImportazione.Location = new System.Drawing.Point(161, 12);
            this.gBoxImportazione.Name = "gBoxImportazione";
            this.gBoxImportazione.Size = new System.Drawing.Size(313, 46);
            this.gBoxImportazione.TabIndex = 46;
            this.gBoxImportazione.TabStop = false;
            this.gBoxImportazione.Tag = "AutoChoose.txtNumImport.default";
            this.gBoxImportazione.Text = "Importazione";
            // 
            // txtNumImport
            // 
            this.txtNumImport.Location = new System.Drawing.Point(234, 15);
            this.txtNumImport.Name = "txtNumImport";
            this.txtNumImport.Size = new System.Drawing.Size(70, 20);
            this.txtNumImport.TabIndex = 3;
            this.txtNumImport.Tag = "csa_import.nimport?csa_importriep_partition_incomeview.nimport";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(167, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Numero:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercImport
            // 
            this.txtEsercImport.Location = new System.Drawing.Point(76, 15);
            this.txtEsercImport.Name = "txtEsercImport";
            this.txtEsercImport.Size = new System.Drawing.Size(70, 20);
            this.txtEsercImport.TabIndex = 2;
            this.txtEsercImport.Tag = "csa_import.yimport.year?csa_importriep_partition_incomeview.yimport.year";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Esercizio:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxtipo
            // 
            this.gboxtipo.Controls.Add(this.rdbCompetenza);
            this.gboxtipo.Controls.Add(this.rdbResidui);
            this.gboxtipo.Location = new System.Drawing.Point(479, 12);
            this.gboxtipo.Name = "gboxtipo";
            this.gboxtipo.Size = new System.Drawing.Size(217, 46);
            this.gboxtipo.TabIndex = 44;
            this.gboxtipo.TabStop = false;
            this.gboxtipo.Text = "Tipo";
            // 
            // rdbCompetenza
            // 
            this.rdbCompetenza.Location = new System.Drawing.Point(11, 18);
            this.rdbCompetenza.Name = "rdbCompetenza";
            this.rdbCompetenza.Size = new System.Drawing.Size(90, 24);
            this.rdbCompetenza.TabIndex = 2;
            this.rdbCompetenza.Tag = "csa_importriep.flagcr:C?csa_importriep_partition_incomeview.flagcr:C";
            this.rdbCompetenza.Text = "Competenza";
            // 
            // rdbResidui
            // 
            this.rdbResidui.Location = new System.Drawing.Point(118, 22);
            this.rdbResidui.Name = "rdbResidui";
            this.rdbResidui.Size = new System.Drawing.Size(90, 16);
            this.rdbResidui.TabIndex = 3;
            this.rdbResidui.Tag = "csa_importriep.flagcr:R?csa_importriep_partition_incomeview.flagcr:R";
            this.rdbResidui.Text = "Residui";
            // 
            // grpMatricola
            // 
            this.grpMatricola.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMatricola.Controls.Add(this.txtMatricola);
            this.grpMatricola.Location = new System.Drawing.Point(125, 116);
            this.grpMatricola.Name = "grpMatricola";
            this.grpMatricola.Size = new System.Drawing.Size(122, 56);
            this.grpMatricola.TabIndex = 49;
            this.grpMatricola.TabStop = false;
            this.grpMatricola.Text = "Matricola";
            // 
            // txtMatricola
            // 
            this.txtMatricola.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatricola.Location = new System.Drawing.Point(10, 23);
            this.txtMatricola.Multiline = true;
            this.txtMatricola.Name = "txtMatricola";
            this.txtMatricola.Size = new System.Drawing.Size(106, 20);
            this.txtMatricola.TabIndex = 14;
            this.txtMatricola.TabStop = false;
            this.txtMatricola.Tag = "csa_importriep.matricola?csa_importriep_partition_incomeview.matricola";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(11, 256);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(366, 46);
            this.groupCredDeb.TabIndex = 47;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupCredDeb.Text = "Anagrafica Movimento";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 13);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(350, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry_main.title?csa_importriep_partition_incomeview.registry_main";
            // 
            // gBoxRegolaSpecifica
            // 
            this.gBoxRegolaSpecifica.Controls.Add(this.label10);
            this.gBoxRegolaSpecifica.Controls.Add(this.cmbTipoContratto);
            this.gBoxRegolaSpecifica.Controls.Add(this.txtNumContratto);
            this.gBoxRegolaSpecifica.Controls.Add(this.label14);
            this.gBoxRegolaSpecifica.Controls.Add(this.txtEsercContratto);
            this.gBoxRegolaSpecifica.Controls.Add(this.label15);
            this.gBoxRegolaSpecifica.Location = new System.Drawing.Point(11, 178);
            this.gBoxRegolaSpecifica.Name = "gBoxRegolaSpecifica";
            this.gBoxRegolaSpecifica.Size = new System.Drawing.Size(367, 72);
            this.gBoxRegolaSpecifica.TabIndex = 48;
            this.gBoxRegolaSpecifica.TabStop = false;
            this.gBoxRegolaSpecifica.Tag = "AutoChoose.txtNumContratto.default";
            this.gBoxRegolaSpecifica.Text = "Regola specifica CSA";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(19, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tipo:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoContratto
            // 
            this.cmbTipoContratto.DataSource = this.DS.csa_contractkind;
            this.cmbTipoContratto.DisplayMember = "description";
            this.cmbTipoContratto.Location = new System.Drawing.Point(80, 16);
            this.cmbTipoContratto.Name = "cmbTipoContratto";
            this.cmbTipoContratto.Size = new System.Drawing.Size(278, 21);
            this.cmbTipoContratto.TabIndex = 1;
            this.cmbTipoContratto.Tag = "csa_importriep.idcsa_contractkind?csa_importriep_partition_incomeview.idcsa_contr" +
    "actkind";
            this.cmbTipoContratto.ValueMember = "idcsa_contractkind";
            // 
            // txtNumContratto
            // 
            this.txtNumContratto.Location = new System.Drawing.Point(216, 48);
            this.txtNumContratto.Name = "txtNumContratto";
            this.txtNumContratto.Size = new System.Drawing.Size(56, 20);
            this.txtNumContratto.TabIndex = 3;
            this.txtNumContratto.Tag = "csa_contract.ncontract?csa_importriep_partition_incomeview.ncontract";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(152, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Numero:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercContratto
            // 
            this.txtEsercContratto.Location = new System.Drawing.Point(80, 48);
            this.txtEsercContratto.Name = "txtEsercContratto";
            this.txtEsercContratto.Size = new System.Drawing.Size(56, 20);
            this.txtEsercContratto.TabIndex = 2;
            this.txtEsercContratto.Tag = "csa_contract.ycontract.year?csa_importriep_partition_incomeview.ycontract.year";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Esercizio:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gBoxDettaglio
            // 
            this.gBoxDettaglio.Controls.Add(this.textBox1);
            this.gBoxDettaglio.Controls.Add(this.label1);
            this.gBoxDettaglio.Location = new System.Drawing.Point(11, 64);
            this.gBoxDettaglio.Name = "gBoxDettaglio";
            this.gBoxDettaglio.Size = new System.Drawing.Size(144, 46);
            this.gBoxDettaglio.TabIndex = 43;
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
            this.textBox1.Tag = "csa_importriep_partition_income.ndetail?csa_importriep_partition_incomeview.ndeta" +
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
            // gBoxRiepilogo
            // 
            this.gBoxRiepilogo.Controls.Add(this.txtNumRiep);
            this.gBoxRiepilogo.Controls.Add(this.label6);
            this.gBoxRiepilogo.Location = new System.Drawing.Point(11, 12);
            this.gBoxRiepilogo.Name = "gBoxRiepilogo";
            this.gBoxRiepilogo.Size = new System.Drawing.Size(144, 46);
            this.gBoxRiepilogo.TabIndex = 42;
            this.gBoxRiepilogo.TabStop = false;
            this.gBoxRiepilogo.Tag = "";
            this.gBoxRiepilogo.Text = "Riepilogo";
            // 
            // txtNumRiep
            // 
            this.txtNumRiep.Location = new System.Drawing.Point(82, 18);
            this.txtNumRiep.Name = "txtNumRiep";
            this.txtNumRiep.Size = new System.Drawing.Size(56, 20);
            this.txtNumRiep.TabIndex = 3;
            this.txtNumRiep.Tag = "csa_importriep_partition_income.idriep?csa_importriep_partition_incomeview.idriep" +
    "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Numero:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gBoxImporto
            // 
            this.gBoxImporto.Controls.Add(this.label11);
            this.gBoxImporto.Controls.Add(this.txtImporto);
            this.gBoxImporto.Location = new System.Drawing.Point(161, 64);
            this.gBoxImporto.Name = "gBoxImporto";
            this.gBoxImporto.Size = new System.Drawing.Size(162, 46);
            this.gBoxImporto.TabIndex = 41;
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
            this.txtImporto.Size = new System.Drawing.Size(89, 20);
            this.txtImporto.TabIndex = 14;
            this.txtImporto.TabStop = false;
            this.txtImporto.Tag = "csa_importriep_partition_income.amount?csa_importriep_partition_incomeview.amount" +
    "";
            // 
            // gBoxAnagraficaRiep
            // 
            this.gBoxAnagraficaRiep.Controls.Add(this.txtCredDebRiep);
            this.gBoxAnagraficaRiep.Location = new System.Drawing.Point(255, 116);
            this.gBoxAnagraficaRiep.Name = "gBoxAnagraficaRiep";
            this.gBoxAnagraficaRiep.Size = new System.Drawing.Size(365, 56);
            this.gBoxAnagraficaRiep.TabIndex = 52;
            this.gBoxAnagraficaRiep.TabStop = false;
            this.gBoxAnagraficaRiep.Tag = "AutoChoose.txtCredDebRiep.lista.(active=\'S\')";
            this.gBoxAnagraficaRiep.Text = "Anagrafica Regola specifica CSA";
            // 
            // txtCredDebRiep
            // 
            this.txtCredDebRiep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDebRiep.Location = new System.Drawing.Point(8, 23);
            this.txtCredDebRiep.Name = "txtCredDebRiep";
            this.txtCredDebRiep.Size = new System.Drawing.Size(348, 20);
            this.txtCredDebRiep.TabIndex = 1;
            this.txtCredDebRiep.Tag = "registry.title?csa_importriep_partition_incomeview.registry";
            // 
            // Frm_csa_importriep_partition_income_elenco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 472);
            this.Controls.Add(this.gBoxAnagraficaRiep);
            this.Controls.Add(this.gBoxCapitoloCSA);
            this.Controls.Add(this.gBoxCompetenza);
            this.Controls.Add(this.gBoxImportazione);
            this.Controls.Add(this.gboxtipo);
            this.Controls.Add(this.grpMatricola);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.gBoxRegolaSpecifica);
            this.Controls.Add(this.gBoxDettaglio);
            this.Controls.Add(this.gBoxRiepilogo);
            this.Controls.Add(this.gBoxImporto);
            this.Controls.Add(this.gboxEntrata);
            this.Name = "Frm_csa_importriep_partition_income_elenco";
            this.Text = "Frm_csa_importriep_partition_income_elenco";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxEntrata.ResumeLayout(false);
            this.gboxEntrata.PerformLayout();
            this.gBoxCapitoloCSA.ResumeLayout(false);
            this.gBoxCapitoloCSA.PerformLayout();
            this.gBoxCompetenza.ResumeLayout(false);
            this.gBoxCompetenza.PerformLayout();
            this.gBoxImportazione.ResumeLayout(false);
            this.gBoxImportazione.PerformLayout();
            this.gboxtipo.ResumeLayout(false);
            this.grpMatricola.ResumeLayout(false);
            this.grpMatricola.PerformLayout();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.gBoxRegolaSpecifica.ResumeLayout(false);
            this.gBoxRegolaSpecifica.PerformLayout();
            this.gBoxDettaglio.ResumeLayout(false);
            this.gBoxDettaglio.PerformLayout();
            this.gBoxRiepilogo.ResumeLayout(false);
            this.gBoxRiepilogo.PerformLayout();
            this.gBoxImporto.ResumeLayout(false);
            this.gBoxImporto.PerformLayout();
            this.gBoxAnagraficaRiep.ResumeLayout(false);
            this.gBoxAnagraficaRiep.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        public vistaForm DS;
        private System.Windows.Forms.TextBox txtDenominazioneConto;
        private System.Windows.Forms.TextBox txtCodiceConto;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox gboxEntrata;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEserc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbFaseEntrata;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox gBoxCapitoloCSA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRuoloCsa;
        private System.Windows.Forms.TextBox txtCapitoloCsa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gBoxCompetenza;
        private System.Windows.Forms.TextBox txtCompetenza;
        private System.Windows.Forms.GroupBox gBoxImportazione;
        private System.Windows.Forms.TextBox txtNumImport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEsercImport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gboxtipo;
        private System.Windows.Forms.RadioButton rdbCompetenza;
        private System.Windows.Forms.RadioButton rdbResidui;
        private System.Windows.Forms.GroupBox grpMatricola;
        private System.Windows.Forms.TextBox txtMatricola;
        private System.Windows.Forms.GroupBox groupCredDeb;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.GroupBox gBoxRegolaSpecifica;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTipoContratto;
        private System.Windows.Forms.TextBox txtNumContratto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEsercContratto;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gBoxDettaglio;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBoxRiepilogo;
        private System.Windows.Forms.TextBox txtNumRiep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gBoxImporto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoMov;
        private System.Windows.Forms.GroupBox gBoxAnagraficaRiep;
        private System.Windows.Forms.TextBox txtCredDebRiep;
    }
    }