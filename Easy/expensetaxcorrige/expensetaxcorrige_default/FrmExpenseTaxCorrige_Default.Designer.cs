
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


namespace expensetaxcorrige_default {
    partial class FrmExpenseTaxCorrige_Default {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            inChiusura = true;
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
			this.DS = new expensetaxcorrige_default.vistaForm();
			this.gboxentrata = new System.Windows.Forms.GroupBox();
			this.btnSelectMovE = new System.Windows.Forms.Button();
			this.txtNumeroMovimentoE = new System.Windows.Forms.TextBox();
			this.labNum = new System.Windows.Forms.Label();
			this.txtEsercizioMovimentoE = new System.Windows.Forms.TextBox();
			this.labEserc = new System.Windows.Forms.Label();
			this.gBoxGenerale = new System.Windows.Forms.GroupBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtAnnoCompetenza = new System.Windows.Forms.TextBox();
			this.grpRegion = new System.Windows.Forms.GroupBox();
			this.cmbRegioneFiscale = new System.Windows.Forms.ComboBox();
			this.grpCity = new System.Windows.Forms.GroupBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtProvincia = new System.Windows.Forms.TextBox();
			this.txtGeoComune0101 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.btnRitenuta = new System.Windows.Forms.Button();
			this.cmbTipoRitenuta = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDataCompetenza = new System.Windows.Forms.TextBox();
			this.gBoxDip = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtImportoDip = new System.Windows.Forms.TextBox();
			this.gBoxAmm = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtImportoAmm = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.gboxspesa = new System.Windows.Forms.GroupBox();
			this.btnSelectMovS = new System.Windows.Forms.Button();
			this.txtNumeroMovimentoS = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercizioMovimentoS = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEsercLiq = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gboxentrata.SuspendLayout();
			this.gBoxGenerale.SuspendLayout();
			this.grpRegion.SuspendLayout();
			this.grpCity.SuspendLayout();
			this.gBoxDip.SuspendLayout();
			this.gBoxAmm.SuspendLayout();
			this.gboxspesa.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// gboxentrata
			// 
			this.gboxentrata.Controls.Add(this.btnSelectMovE);
			this.gboxentrata.Controls.Add(this.txtNumeroMovimentoE);
			this.gboxentrata.Controls.Add(this.labNum);
			this.gboxentrata.Controls.Add(this.txtEsercizioMovimentoE);
			this.gboxentrata.Controls.Add(this.labEserc);
			this.gboxentrata.Location = new System.Drawing.Point(7, 251);
			this.gboxentrata.Name = "gboxentrata";
			this.gboxentrata.Size = new System.Drawing.Size(347, 54);
			this.gboxentrata.TabIndex = 4;
			this.gboxentrata.TabStop = false;
			this.gboxentrata.Text = "Movimento di Entrata per rimborso";
			// 
			// btnSelectMovE
			// 
			this.btnSelectMovE.Location = new System.Drawing.Point(6, 17);
			this.btnSelectMovE.Name = "btnSelectMovE";
			this.btnSelectMovE.Size = new System.Drawing.Size(75, 23);
			this.btnSelectMovE.TabIndex = 8;
			this.btnSelectMovE.TabStop = false;
			this.btnSelectMovE.Tag = "";
			this.btnSelectMovE.Text = "Seleziona";
			this.btnSelectMovE.Click += new System.EventHandler(this.btnSelectMovE_Click);
			// 
			// txtNumeroMovimentoE
			// 
			this.txtNumeroMovimentoE.Location = new System.Drawing.Point(273, 18);
			this.txtNumeroMovimentoE.Name = "txtNumeroMovimentoE";
			this.txtNumeroMovimentoE.Size = new System.Drawing.Size(58, 20);
			this.txtNumeroMovimentoE.TabIndex = 7;
			this.txtNumeroMovimentoE.Tag = "incomeview.nmov?x";
			this.txtNumeroMovimentoE.Leave += new System.EventHandler(this.txtNumeroMovimentoE_Leave);
			// 
			// labNum
			// 
			this.labNum.Location = new System.Drawing.Point(219, 18);
			this.labNum.Name = "labNum";
			this.labNum.Size = new System.Drawing.Size(48, 20);
			this.labNum.TabIndex = 5;
			this.labNum.Text = "Numero:";
			this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioMovimentoE
			// 
			this.txtEsercizioMovimentoE.Location = new System.Drawing.Point(161, 19);
			this.txtEsercizioMovimentoE.Name = "txtEsercizioMovimentoE";
			this.txtEsercizioMovimentoE.Size = new System.Drawing.Size(52, 20);
			this.txtEsercizioMovimentoE.TabIndex = 6;
			this.txtEsercizioMovimentoE.Tag = "incomeview.ymov.year?x";
			// 
			// labEserc
			// 
			this.labEserc.Location = new System.Drawing.Point(87, 18);
			this.labEserc.Name = "labEserc";
			this.labEserc.Size = new System.Drawing.Size(66, 20);
			this.labEserc.TabIndex = 4;
			this.labEserc.Text = "Esercizio:";
			this.labEserc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gBoxGenerale
			// 
			this.gBoxGenerale.Controls.Add(this.textBox8);
			this.gBoxGenerale.Controls.Add(this.label13);
			this.gBoxGenerale.Controls.Add(this.txtAnnoCompetenza);
			this.gBoxGenerale.Controls.Add(this.grpRegion);
			this.gBoxGenerale.Controls.Add(this.grpCity);
			this.gBoxGenerale.Controls.Add(this.textBox3);
			this.gBoxGenerale.Controls.Add(this.btnRitenuta);
			this.gBoxGenerale.Controls.Add(this.cmbTipoRitenuta);
			this.gBoxGenerale.Controls.Add(this.label4);
			this.gBoxGenerale.Controls.Add(this.txtDataCompetenza);
			this.gBoxGenerale.Location = new System.Drawing.Point(7, 35);
			this.gBoxGenerale.Name = "gBoxGenerale";
			this.gBoxGenerale.Size = new System.Drawing.Size(472, 145);
			this.gBoxGenerale.TabIndex = 1;
			this.gBoxGenerale.TabStop = false;
			this.gBoxGenerale.Text = "Dati Generali della Ritenuta";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(238, 43);
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(228, 20);
			this.textBox8.TabIndex = 20;
			this.textBox8.TabStop = false;
			this.textBox8.Text = "Anno di Competenza";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(16, 42);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(104, 16);
			this.label13.TabIndex = 19;
			this.label13.Text = "Anno Competenza:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAnnoCompetenza
			// 
			this.txtAnnoCompetenza.HideSelection = false;
			this.txtAnnoCompetenza.Location = new System.Drawing.Point(120, 42);
			this.txtAnnoCompetenza.Name = "txtAnnoCompetenza";
			this.txtAnnoCompetenza.Size = new System.Drawing.Size(112, 20);
			this.txtAnnoCompetenza.TabIndex = 2;
			this.txtAnnoCompetenza.Tag = "expensetaxcorrige.ayear";
			// 
			// grpRegion
			// 
			this.grpRegion.Controls.Add(this.cmbRegioneFiscale);
			this.grpRegion.Location = new System.Drawing.Point(6, 96);
			this.grpRegion.Name = "grpRegion";
			this.grpRegion.Size = new System.Drawing.Size(376, 43);
			this.grpRegion.TabIndex = 17;
			this.grpRegion.TabStop = false;
			this.grpRegion.Text = "Regione Fiscale:";
			// 
			// cmbRegioneFiscale
			// 
			this.cmbRegioneFiscale.DataSource = this.DS.fiscaltaxregion;
			this.cmbRegioneFiscale.DisplayMember = "title";
			this.cmbRegioneFiscale.FormattingEnabled = true;
			this.cmbRegioneFiscale.Location = new System.Drawing.Point(6, 16);
			this.cmbRegioneFiscale.Name = "cmbRegioneFiscale";
			this.cmbRegioneFiscale.Size = new System.Drawing.Size(363, 21);
			this.cmbRegioneFiscale.TabIndex = 0;
			this.cmbRegioneFiscale.Tag = "expensetaxcorrige.idfiscaltaxregion";
			this.cmbRegioneFiscale.ValueMember = "idfiscaltaxregion";
			// 
			// grpCity
			// 
			this.grpCity.Controls.Add(this.label20);
			this.grpCity.Controls.Add(this.txtProvincia);
			this.grpCity.Controls.Add(this.txtGeoComune0101);
			this.grpCity.Location = new System.Drawing.Point(6, 91);
			this.grpCity.Name = "grpCity";
			this.grpCity.Size = new System.Drawing.Size(376, 48);
			this.grpCity.TabIndex = 16;
			this.grpCity.TabStop = false;
			this.grpCity.Tag = "AutoChoose.txtGeoComune0101.default";
			this.grpCity.Text = "Comune:";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(300, 16);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(41, 18);
			this.label20.TabIndex = 154;
			this.label20.Text = "Prov.";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtProvincia
			// 
			this.txtProvincia.Location = new System.Drawing.Point(344, 15);
			this.txtProvincia.Name = "txtProvincia";
			this.txtProvincia.ReadOnly = true;
			this.txtProvincia.Size = new System.Drawing.Size(25, 20);
			this.txtProvincia.TabIndex = 153;
			this.txtProvincia.TabStop = false;
			this.txtProvincia.Tag = "geo_cityview.provincecode";
			// 
			// txtGeoComune0101
			// 
			this.txtGeoComune0101.Location = new System.Drawing.Point(8, 16);
			this.txtGeoComune0101.Name = "txtGeoComune0101";
			this.txtGeoComune0101.Size = new System.Drawing.Size(286, 20);
			this.txtGeoComune0101.TabIndex = 3;
			this.txtGeoComune0101.Tag = "geo_cityview.title?x";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(238, 70);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(228, 20);
			this.textBox3.TabIndex = 6;
			this.textBox3.TabStop = false;
			this.textBox3.Text = "Data di Competenza per la liquidazione";
			// 
			// btnRitenuta
			// 
			this.btnRitenuta.Location = new System.Drawing.Point(16, 16);
			this.btnRitenuta.Name = "btnRitenuta";
			this.btnRitenuta.Size = new System.Drawing.Size(96, 23);
			this.btnRitenuta.TabIndex = 0;
			this.btnRitenuta.TabStop = false;
			this.btnRitenuta.Tag = "choose.tax.default";
			this.btnRitenuta.Text = "Ritenuta";
			// 
			// cmbTipoRitenuta
			// 
			this.cmbTipoRitenuta.DataSource = this.DS.tax;
			this.cmbTipoRitenuta.DisplayMember = "description";
			this.cmbTipoRitenuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoRitenuta.Location = new System.Drawing.Point(120, 16);
			this.cmbTipoRitenuta.Name = "cmbTipoRitenuta";
			this.cmbTipoRitenuta.Size = new System.Drawing.Size(346, 21);
			this.cmbTipoRitenuta.TabIndex = 1;
			this.cmbTipoRitenuta.Tag = "expensetaxcorrige.taxcode";
			this.cmbTipoRitenuta.ValueMember = "taxcode";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Data Competenza:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataCompetenza
			// 
			this.txtDataCompetenza.Location = new System.Drawing.Point(120, 70);
			this.txtDataCompetenza.Name = "txtDataCompetenza";
			this.txtDataCompetenza.Size = new System.Drawing.Size(112, 20);
			this.txtDataCompetenza.TabIndex = 3;
			this.txtDataCompetenza.Tag = "expensetaxcorrige.adate";
			// 
			// gBoxDip
			// 
			this.gBoxDip.Controls.Add(this.label7);
			this.gBoxDip.Controls.Add(this.txtImportoDip);
			this.gBoxDip.Location = new System.Drawing.Point(7, 186);
			this.gBoxDip.Name = "gBoxDip";
			this.gBoxDip.Size = new System.Drawing.Size(194, 59);
			this.gBoxDip.TabIndex = 2;
			this.gBoxDip.TabStop = false;
			this.gBoxDip.Text = "Ritenute c/dipendente";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 25);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "Importo:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImportoDip
			// 
			this.txtImportoDip.Location = new System.Drawing.Point(68, 24);
			this.txtImportoDip.Name = "txtImportoDip";
			this.txtImportoDip.Size = new System.Drawing.Size(120, 20);
			this.txtImportoDip.TabIndex = 4;
			this.txtImportoDip.Tag = "expensetaxcorrige.employamount.c";
			this.txtImportoDip.Leave += new System.EventHandler(this.txtImportoDip_Leave);
			// 
			// gBoxAmm
			// 
			this.gBoxAmm.Controls.Add(this.label8);
			this.gBoxAmm.Controls.Add(this.txtImportoAmm);
			this.gBoxAmm.Location = new System.Drawing.Point(207, 186);
			this.gBoxAmm.Name = "gBoxAmm";
			this.gBoxAmm.Size = new System.Drawing.Size(194, 62);
			this.gBoxAmm.TabIndex = 3;
			this.gBoxAmm.TabStop = false;
			this.gBoxAmm.Text = "Contributi c/amministrazione";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 25);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 20;
			this.label8.Text = "Importo:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImportoAmm
			// 
			this.txtImportoAmm.Location = new System.Drawing.Point(68, 25);
			this.txtImportoAmm.Name = "txtImportoAmm";
			this.txtImportoAmm.Size = new System.Drawing.Size(120, 20);
			this.txtImportoAmm.TabIndex = 4;
			this.txtImportoAmm.Tag = "expensetaxcorrige.adminamount.c";
			this.txtImportoAmm.Leave += new System.EventHandler(this.txtImportoAmm_Leave);
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(390, 397);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(88, 23);
			this.btnAnnulla.TabIndex = 18;
			this.btnAnnulla.TabStop = false;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(286, 397);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(88, 23);
			this.btnOK.TabIndex = 17;
			this.btnOK.TabStop = false;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// gboxspesa
			// 
			this.gboxspesa.Controls.Add(this.btnSelectMovS);
			this.gboxspesa.Controls.Add(this.txtNumeroMovimentoS);
			this.gboxspesa.Controls.Add(this.label1);
			this.gboxspesa.Controls.Add(this.txtEsercizioMovimentoS);
			this.gboxspesa.Controls.Add(this.label2);
			this.gboxspesa.Location = new System.Drawing.Point(7, 311);
			this.gboxspesa.Name = "gboxspesa";
			this.gboxspesa.Size = new System.Drawing.Size(347, 54);
			this.gboxspesa.TabIndex = 5;
			this.gboxspesa.TabStop = false;
			this.gboxspesa.Text = "Movimento di Spesa per versamento";
			// 
			// btnSelectMovS
			// 
			this.btnSelectMovS.Location = new System.Drawing.Point(6, 17);
			this.btnSelectMovS.Name = "btnSelectMovS";
			this.btnSelectMovS.Size = new System.Drawing.Size(75, 23);
			this.btnSelectMovS.TabIndex = 8;
			this.btnSelectMovS.TabStop = false;
			this.btnSelectMovS.Tag = "";
			this.btnSelectMovS.Text = "Seleziona";
			this.btnSelectMovS.Click += new System.EventHandler(this.btnSelectMovS_Click);
			// 
			// txtNumeroMovimentoS
			// 
			this.txtNumeroMovimentoS.Location = new System.Drawing.Point(273, 18);
			this.txtNumeroMovimentoS.Name = "txtNumeroMovimentoS";
			this.txtNumeroMovimentoS.Size = new System.Drawing.Size(58, 20);
			this.txtNumeroMovimentoS.TabIndex = 7;
			this.txtNumeroMovimentoS.Tag = "expenseview.nmov?x";
			this.txtNumeroMovimentoS.Leave += new System.EventHandler(this.txtNumeroMovimentoS_Leave);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(219, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Numero:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioMovimentoS
			// 
			this.txtEsercizioMovimentoS.Location = new System.Drawing.Point(161, 19);
			this.txtEsercizioMovimentoS.Name = "txtEsercizioMovimentoS";
			this.txtEsercizioMovimentoS.Size = new System.Drawing.Size(52, 20);
			this.txtEsercizioMovimentoS.TabIndex = 6;
			this.txtEsercizioMovimentoS.Tag = "expenseview.ymov.year?x";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(87, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "Esercizio:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(114, 9);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(40, 20);
			this.textBox2.TabIndex = 7;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "expensetaxcorrige.idexpensetaxcorrige";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(10, 9);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(96, 20);
			this.label12.TabIndex = 8;
			this.label12.Text = "Num. Dettaglio:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.txtEsercLiq);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Location = new System.Drawing.Point(7, 377);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(267, 41);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Liquidazione Ritenute:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(195, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(58, 20);
			this.textBox4.TabIndex = 11;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "expensetaxcorrige.ntaxpay";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(141, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "Numero:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercLiq
			// 
			this.txtEsercLiq.Location = new System.Drawing.Point(83, 17);
			this.txtEsercLiq.Name = "txtEsercLiq";
			this.txtEsercLiq.ReadOnly = true;
			this.txtEsercLiq.Size = new System.Drawing.Size(52, 20);
			this.txtEsercLiq.TabIndex = 10;
			this.txtEsercLiq.TabStop = false;
			this.txtEsercLiq.Tag = "expensetaxcorrige.ytaxpay.year";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Esercizio:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FrmExpenseTaxCorrige_Default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 424);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.gBoxAmm);
			this.Controls.Add(this.gBoxDip);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.gboxspesa);
			this.Controls.Add(this.gboxentrata);
			this.Controls.Add(this.gBoxGenerale);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Name = "FrmExpenseTaxCorrige_Default";
			this.Text = "FrmExpenseTaxCorrige_default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gboxentrata.ResumeLayout(false);
			this.gboxentrata.PerformLayout();
			this.gBoxGenerale.ResumeLayout(false);
			this.gBoxGenerale.PerformLayout();
			this.grpRegion.ResumeLayout(false);
			this.grpCity.ResumeLayout(false);
			this.grpCity.PerformLayout();
			this.gBoxDip.ResumeLayout(false);
			this.gBoxDip.PerformLayout();
			this.gBoxAmm.ResumeLayout(false);
			this.gBoxAmm.PerformLayout();
			this.gboxspesa.ResumeLayout(false);
			this.gboxspesa.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox gboxentrata;
        private System.Windows.Forms.Button btnSelectMovE;
        private System.Windows.Forms.TextBox txtNumeroMovimentoE;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.TextBox txtEsercizioMovimentoE;
        private System.Windows.Forms.Label labEserc;
        private System.Windows.Forms.GroupBox gBoxGenerale;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAnnoCompetenza;
        private System.Windows.Forms.GroupBox grpRegion;
        private System.Windows.Forms.ComboBox cmbRegioneFiscale;
        private System.Windows.Forms.GroupBox grpCity;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtGeoComune0101;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnRitenuta;
        private System.Windows.Forms.ComboBox cmbTipoRitenuta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataCompetenza;
        private System.Windows.Forms.GroupBox gBoxDip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtImportoDip;
        private System.Windows.Forms.GroupBox gBoxAmm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImportoAmm;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gboxspesa;
        private System.Windows.Forms.Button btnSelectMovS;
        private System.Windows.Forms.TextBox txtNumeroMovimentoS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEsercizioMovimentoS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercLiq;
        private System.Windows.Forms.Label label5;

    }
}
