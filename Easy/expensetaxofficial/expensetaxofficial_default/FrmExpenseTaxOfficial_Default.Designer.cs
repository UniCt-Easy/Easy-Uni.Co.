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

namespace expensetaxofficial_default {
    partial class FrmExpenseTaxOfficial_Default {
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
            this.DS = new expensetaxofficial_default.vistaForm();
            this.gBoxGenerale = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpRegion = new System.Windows.Forms.GroupBox();
            this.cmbRegioneFiscale = new System.Windows.Forms.ComboBox();
            this.grpCity = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtGeoComune0101 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtImponibileLordo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuotaEsente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRitenuta = new System.Windows.Forms.Button();
            this.cmbTipoRitenuta = new System.Windows.Forms.ComboBox();
            this.gBoxScaglione = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtDetrazioni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImponibileNetto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtImportoDip = new System.Windows.Forms.TextBox();
            this.txtQuotaDip2 = new System.Windows.Forms.TextBox();
            this.txtQuotaDip1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAliquotaDip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImportoAmm = new System.Windows.Forms.TextBox();
            this.txtQuotaAmm2 = new System.Windows.Forms.TextBox();
            this.txtQuotaAmm1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAliquotaAmm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gBoxGenerale.SuspendLayout();
            this.grpRegion.SuspendLayout();
            this.grpCity.SuspendLayout();
            this.gBoxScaglione.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // gBoxGenerale
            // 
            this.gBoxGenerale.Controls.Add(this.textBox8);
            this.gBoxGenerale.Controls.Add(this.label13);
            this.gBoxGenerale.Controls.Add(this.textBox1);
            this.gBoxGenerale.Controls.Add(this.grpRegion);
            this.gBoxGenerale.Controls.Add(this.grpCity);
            this.gBoxGenerale.Controls.Add(this.textBox5);
            this.gBoxGenerale.Controls.Add(this.textBox4);
            this.gBoxGenerale.Controls.Add(this.txtImponibileLordo);
            this.gBoxGenerale.Controls.Add(this.label1);
            this.gBoxGenerale.Controls.Add(this.txtQuotaEsente);
            this.gBoxGenerale.Controls.Add(this.label2);
            this.gBoxGenerale.Controls.Add(this.btnRitenuta);
            this.gBoxGenerale.Controls.Add(this.cmbTipoRitenuta);
            this.gBoxGenerale.Location = new System.Drawing.Point(7, 6);
            this.gBoxGenerale.Name = "gBoxGenerale";
            this.gBoxGenerale.Size = new System.Drawing.Size(488, 226);
            this.gBoxGenerale.TabIndex = 15;
            this.gBoxGenerale.TabStop = false;
            this.gBoxGenerale.Text = "Dati Generali della Ritenuta";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(238, 54);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(242, 20);
            this.textBox8.TabIndex = 20;
            this.textBox8.TabStop = false;
            this.textBox8.Text = "Anno di Competenza per la liquidazione";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "Anno Competenza:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Tag = "expensetaxofficial.ayear.year";
            // 
            // grpRegion
            // 
            this.grpRegion.Controls.Add(this.cmbRegioneFiscale);
            this.grpRegion.Location = new System.Drawing.Point(6, 172);
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
            this.cmbRegioneFiscale.Tag = "expensetaxofficial.idfiscaltaxregion";
            this.cmbRegioneFiscale.ValueMember = "idfiscaltaxregion";
            // 
            // grpCity
            // 
            this.grpCity.Controls.Add(this.label20);
            this.grpCity.Controls.Add(this.txtProvincia);
            this.grpCity.Controls.Add(this.txtGeoComune0101);
            this.grpCity.Location = new System.Drawing.Point(6, 167);
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
            this.txtGeoComune0101.Tag = "geo_cityview.title?expensetaxview.city";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(238, 134);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(242, 32);
            this.textBox5.TabIndex = 8;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Totale delle deduzioni associate alla ritenuta (uguale per tutti gli scaglioni)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(238, 94);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(242, 32);
            this.textBox4.TabIndex = 7;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Imponibile Lordo complessivo della ritenuta (uguale per tutti gli scaglioni)";
            // 
            // txtImponibileLordo
            // 
            this.txtImponibileLordo.Location = new System.Drawing.Point(120, 94);
            this.txtImponibileLordo.Name = "txtImponibileLordo";
            this.txtImponibileLordo.Size = new System.Drawing.Size(112, 20);
            this.txtImponibileLordo.TabIndex = 3;
            this.txtImponibileLordo.Tag = "expensetaxofficial.taxablegross.c";
            this.txtImponibileLordo.Leave += new System.EventHandler(this.txtImponibileLordo_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Imponibile Lordo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuotaEsente
            // 
            this.txtQuotaEsente.Location = new System.Drawing.Point(120, 134);
            this.txtQuotaEsente.Name = "txtQuotaEsente";
            this.txtQuotaEsente.Size = new System.Drawing.Size(112, 20);
            this.txtQuotaEsente.TabIndex = 4;
            this.txtQuotaEsente.Tag = "expensetaxofficial.exemptionquota.c";
            this.txtQuotaEsente.Leave += new System.EventHandler(this.txtQuotaEsente_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quota Esente / Deduzioni:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbTipoRitenuta.Size = new System.Drawing.Size(360, 21);
            this.cmbTipoRitenuta.TabIndex = 1;
            this.cmbTipoRitenuta.Tag = "expensetaxofficial.taxcode";
            this.cmbTipoRitenuta.ValueMember = "taxcode";
            // 
            // gBoxScaglione
            // 
            this.gBoxScaglione.Controls.Add(this.textBox7);
            this.gBoxScaglione.Controls.Add(this.textBox6);
            this.gBoxScaglione.Controls.Add(this.label12);
            this.gBoxScaglione.Controls.Add(this.textBox2);
            this.gBoxScaglione.Controls.Add(this.txtDetrazioni);
            this.gBoxScaglione.Controls.Add(this.label3);
            this.gBoxScaglione.Controls.Add(this.txtImponibileNetto);
            this.gBoxScaglione.Controls.Add(this.label11);
            this.gBoxScaglione.Controls.Add(this.groupBox1);
            this.gBoxScaglione.Controls.Add(this.groupBox2);
            this.gBoxScaglione.Location = new System.Drawing.Point(7, 238);
            this.gBoxScaglione.Name = "gBoxScaglione";
            this.gBoxScaglione.Size = new System.Drawing.Size(881, 169);
            this.gBoxScaglione.TabIndex = 16;
            this.gBoxScaglione.TabStop = false;
            this.gBoxScaglione.Text = "Dati inerenti lo scaglione";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(238, 76);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(594, 20);
            this.textBox7.TabIndex = 10;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "Detrazioni applicate sulla ritenuta scaglionata";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(238, 42);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(594, 22);
            this.textBox6.TabIndex = 9;
            this.textBox6.TabStop = false;
            this.textBox6.Text = "Imponibile su cui si applicano effettivamente le aliquote della ritenuta";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(24, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Num. Scaglione:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "expensetaxofficial.nbracket";
            // 
            // txtDetrazioni
            // 
            this.txtDetrazioni.Location = new System.Drawing.Point(128, 76);
            this.txtDetrazioni.Name = "txtDetrazioni";
            this.txtDetrazioni.Size = new System.Drawing.Size(104, 20);
            this.txtDetrazioni.TabIndex = 2;
            this.txtDetrazioni.Tag = "expensetaxofficial.abatements.c";
            this.txtDetrazioni.Leave += new System.EventHandler(this.txtDetrazioni_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Detrazioni:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImponibileNetto
            // 
            this.txtImponibileNetto.Location = new System.Drawing.Point(128, 44);
            this.txtImponibileNetto.Name = "txtImponibileNetto";
            this.txtImponibileNetto.Size = new System.Drawing.Size(104, 20);
            this.txtImponibileNetto.TabIndex = 1;
            this.txtImponibileNetto.Tag = "expensetaxofficial.taxablenet.c";
            this.txtImponibileNetto.Leave += new System.EventHandler(this.txtImponibileNetto_Leave);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(24, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Imponibile Netto:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtImportoDip);
            this.groupBox1.Controls.Add(this.txtQuotaDip2);
            this.groupBox1.Controls.Add(this.txtQuotaDip1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAliquotaDip);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(8, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 62);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ritenute c/dipendente";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(280, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Importo:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImportoDip
            // 
            this.txtImportoDip.Location = new System.Drawing.Point(280, 32);
            this.txtImportoDip.Name = "txtImportoDip";
            this.txtImportoDip.Size = new System.Drawing.Size(120, 20);
            this.txtImportoDip.TabIndex = 4;
            this.txtImportoDip.Tag = "expensetaxofficial.employtax.c";
            // 
            // txtQuotaDip2
            // 
            this.txtQuotaDip2.Location = new System.Drawing.Point(192, 38);
            this.txtQuotaDip2.Name = "txtQuotaDip2";
            this.txtQuotaDip2.Size = new System.Drawing.Size(74, 20);
            this.txtQuotaDip2.TabIndex = 3;
            this.txtQuotaDip2.Tag = "expensetaxofficial.employdenominator.n";
            this.txtQuotaDip2.Leave += new System.EventHandler(this.txtQuotaDip2_Leave);
            // 
            // txtQuotaDip1
            // 
            this.txtQuotaDip1.Location = new System.Drawing.Point(192, 14);
            this.txtQuotaDip1.Name = "txtQuotaDip1";
            this.txtQuotaDip1.Size = new System.Drawing.Size(74, 20);
            this.txtQuotaDip1.TabIndex = 2;
            this.txtQuotaDip1.Tag = "expensetaxofficial.employnumerator.n";
            this.txtQuotaDip1.Leave += new System.EventHandler(this.txtQuotaDip1_Leave);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(144, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Quota:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAliquotaDip
            // 
            this.txtAliquotaDip.Location = new System.Drawing.Point(8, 32);
            this.txtAliquotaDip.Name = "txtAliquotaDip";
            this.txtAliquotaDip.Size = new System.Drawing.Size(120, 20);
            this.txtAliquotaDip.TabIndex = 1;
            this.txtAliquotaDip.Tag = "expensetaxofficial.employrate.fixed.4..%.100";
            this.txtAliquotaDip.Leave += new System.EventHandler(this.txtAliquotaDip_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Aliquota:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtImportoAmm);
            this.groupBox2.Controls.Add(this.txtQuotaAmm2);
            this.groupBox2.Controls.Add(this.txtQuotaAmm1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtAliquotaAmm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(432, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 62);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contributi c/amministrazione";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(280, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Importo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImportoAmm
            // 
            this.txtImportoAmm.Location = new System.Drawing.Point(280, 28);
            this.txtImportoAmm.Name = "txtImportoAmm";
            this.txtImportoAmm.Size = new System.Drawing.Size(120, 20);
            this.txtImportoAmm.TabIndex = 4;
            this.txtImportoAmm.Tag = "expensetaxofficial.admintax.c";
            // 
            // txtQuotaAmm2
            // 
            this.txtQuotaAmm2.Location = new System.Drawing.Point(192, 36);
            this.txtQuotaAmm2.Name = "txtQuotaAmm2";
            this.txtQuotaAmm2.Size = new System.Drawing.Size(74, 20);
            this.txtQuotaAmm2.TabIndex = 3;
            this.txtQuotaAmm2.Tag = "expensetaxofficial.admindenominator.n";
            this.txtQuotaAmm2.Leave += new System.EventHandler(this.txtQuotaAmm2_Leave);
            // 
            // txtQuotaAmm1
            // 
            this.txtQuotaAmm1.Location = new System.Drawing.Point(192, 12);
            this.txtQuotaAmm1.Name = "txtQuotaAmm1";
            this.txtQuotaAmm1.Size = new System.Drawing.Size(74, 20);
            this.txtQuotaAmm1.TabIndex = 2;
            this.txtQuotaAmm1.Tag = "expensetaxofficial.adminnumerator.n";
            this.txtQuotaAmm1.Leave += new System.EventHandler(this.txtQuotaAmm1_Leave);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(144, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Quota:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAliquotaAmm
            // 
            this.txtAliquotaAmm.Location = new System.Drawing.Point(8, 32);
            this.txtAliquotaAmm.Name = "txtAliquotaAmm";
            this.txtAliquotaAmm.Size = new System.Drawing.Size(120, 20);
            this.txtAliquotaAmm.TabIndex = 1;
            this.txtAliquotaAmm.Tag = "expensetaxofficial.adminrate.fixed.4..%.100";
            this.txtAliquotaAmm.Leave += new System.EventHandler(this.txtAliquotaAmm_Leave);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "Aliquota:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(723, 462);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(88, 23);
            this.btnAnnulla.TabIndex = 18;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(617, 462);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.TabStop = false;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.textBox10);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.textBox9);
            this.groupBox5.Location = new System.Drawing.Point(7, 413);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(488, 44);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Validità Dettaglio:";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(256, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 16);
            this.label15.TabIndex = 9;
            this.label15.Text = "Data Fine:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(360, 16);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(112, 20);
            this.textBox10.TabIndex = 8;
            this.textBox10.Tag = "expensetaxofficial.stop";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(11, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 7;
            this.label14.Text = "Data Inizio:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(115, 16);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(112, 20);
            this.textBox9.TabIndex = 6;
            this.textBox9.Tag = "expensetaxofficial.start";
            // 
            // FrmExpenseTaxOfficial_Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 497);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gBoxGenerale);
            this.Controls.Add(this.gBoxScaglione);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmExpenseTaxOfficial_Default";
            this.Text = "FrmExpenseTaxOfficial_Default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gBoxGenerale.ResumeLayout(false);
            this.gBoxGenerale.PerformLayout();
            this.grpRegion.ResumeLayout(false);
            this.grpCity.ResumeLayout(false);
            this.grpCity.PerformLayout();
            this.gBoxScaglione.ResumeLayout(false);
            this.gBoxScaglione.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox gBoxGenerale;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox grpRegion;
        private System.Windows.Forms.ComboBox cmbRegioneFiscale;
        private System.Windows.Forms.GroupBox grpCity;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtGeoComune0101;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtImponibileLordo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuotaEsente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRitenuta;
        private System.Windows.Forms.ComboBox cmbTipoRitenuta;
        private System.Windows.Forms.GroupBox gBoxScaglione;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtDetrazioni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImponibileNetto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtImportoDip;
        private System.Windows.Forms.TextBox txtQuotaDip2;
        private System.Windows.Forms.TextBox txtQuotaDip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAliquotaDip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImportoAmm;
        private System.Windows.Forms.TextBox txtQuotaAmm2;
        private System.Windows.Forms.TextBox txtQuotaAmm1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAliquotaAmm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox9;

    }
}