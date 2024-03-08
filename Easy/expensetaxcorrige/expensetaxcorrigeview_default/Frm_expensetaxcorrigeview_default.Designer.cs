
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


namespace expensetaxcorrigeview_default
{
    partial class Frm_expensetaxcorrigeview_default
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DS = new expensetaxcorrigeview_default.vistaForm();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtEsercMov = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCreDeb = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gboxentrata = new System.Windows.Forms.GroupBox();
            this.txtNumeroMovimentoE = new System.Windows.Forms.TextBox();
            this.labNum = new System.Windows.Forms.Label();
            this.txtEsercizioMovimentoE = new System.Windows.Forms.TextBox();
            this.labEserc = new System.Windows.Forms.Label();
            this.txtEsercizioMovimentoS = new System.Windows.Forms.TextBox();
            this.gboxspesa = new System.Windows.Forms.GroupBox();
            this.txtNumeroMovimentoS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpCity = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtGeoComune0101 = new System.Windows.Forms.TextBox();
            this.grpRegion = new System.Windows.Forms.GroupBox();
            this.cmbRegioneFiscale = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gboxentrata.SuspendLayout();
            this.gboxspesa.SuspendLayout();
            this.grpCity.SuspendLayout();
            this.grpRegion.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 48);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ritenuta";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.tax;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.Location = new System.Drawing.Point(29, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(440, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "expensetaxcorrigeview.taxcode";
            this.comboBox1.ValueMember = "taxcode";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.txtEsercMov);
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 80);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movimento";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(72, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "expensetaxcorrigeview.nmov";
            // 
            // txtEsercMov
            // 
            this.txtEsercMov.Location = new System.Drawing.Point(72, 20);
            this.txtEsercMov.Name = "txtEsercMov";
            this.txtEsercMov.ReadOnly = true;
            this.txtEsercMov.Size = new System.Drawing.Size(104, 20);
            this.txtEsercMov.TabIndex = 1;
            this.txtEsercMov.Tag = "expensetaxcorrigeview.ymov.year";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox17);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Location = new System.Drawing.Point(211, 62);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(184, 80);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Liquidazione";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(72, 48);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(104, 20);
            this.textBox17.TabIndex = 2;
            this.textBox17.Tag = "expensetaxcorrigeview.ntaxpay";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "expensetaxcorrigeview.ytaxpay.year";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 1;
            this.label17.Text = "Numero";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 0;
            this.label16.Text = "Esercizio";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreDeb
            // 
            this.txtCreDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCreDeb.Name = "txtCreDeb";
            this.txtCreDeb.Size = new System.Drawing.Size(456, 20);
            this.txtCreDeb.TabIndex = 1;
            this.txtCreDeb.Tag = "registry.title?expensetaxcorrigeview.registry";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCreDeb);
            this.groupBox5.Location = new System.Drawing.Point(12, 149);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(472, 48);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoChoose.txtCreDeb.default";
            this.groupBox5.Text = "Percipiente";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(97, 341);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(112, 20);
            this.textBox19.TabIndex = 27;
            this.textBox19.Tag = "expensetaxcorrigeview.adminamount";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(9, 348);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 24);
            this.label11.TabIndex = 26;
            this.label11.Text = "Importo c/ammin";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(97, 307);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(112, 20);
            this.textBox18.TabIndex = 25;
            this.textBox18.Tag = "expensetaxcorrigeview.employamount";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 318);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 24);
            this.label10.TabIndex = 24;
            this.label10.Text = "Importo c/dip";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(97, 259);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(381, 44);
            this.textBox4.TabIndex = 22;
            this.textBox4.Tag = "expensetaxcorrigeview.expensedescription";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Descrizione:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(165, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Numero:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxentrata
            // 
            this.gboxentrata.Controls.Add(this.txtNumeroMovimentoE);
            this.gboxentrata.Controls.Add(this.labNum);
            this.gboxentrata.Controls.Add(this.txtEsercizioMovimentoE);
            this.gboxentrata.Controls.Add(this.labEserc);
            this.gboxentrata.Location = new System.Drawing.Point(12, 387);
            this.gboxentrata.Name = "gboxentrata";
            this.gboxentrata.Size = new System.Drawing.Size(322, 54);
            this.gboxentrata.TabIndex = 29;
            this.gboxentrata.TabStop = false;
            this.gboxentrata.Text = "Movimento di Entrata per rimborso";
            // 
            // txtNumeroMovimentoE
            // 
            this.txtNumeroMovimentoE.Location = new System.Drawing.Point(222, 20);
            this.txtNumeroMovimentoE.Name = "txtNumeroMovimentoE";
            this.txtNumeroMovimentoE.Size = new System.Drawing.Size(58, 20);
            this.txtNumeroMovimentoE.TabIndex = 7;
            this.txtNumeroMovimentoE.Tag = "expensetaxcorrigeview.incomelinkednmov";
            // 
            // labNum
            // 
            this.labNum.Location = new System.Drawing.Point(165, 19);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(48, 20);
            this.labNum.TabIndex = 5;
            this.labNum.Text = "Numero:";
            this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimentoE
            // 
            this.txtEsercizioMovimentoE.Location = new System.Drawing.Point(90, 19);
            this.txtEsercizioMovimentoE.Name = "txtEsercizioMovimentoE";
            this.txtEsercizioMovimentoE.Size = new System.Drawing.Size(52, 20);
            this.txtEsercizioMovimentoE.TabIndex = 6;
            this.txtEsercizioMovimentoE.Tag = "expensetaxcorrigeview.incomelinkedymov.year";
            // 
            // labEserc
            // 
            this.labEserc.Location = new System.Drawing.Point(8, 17);
            this.labEserc.Name = "labEserc";
            this.labEserc.Size = new System.Drawing.Size(66, 20);
            this.labEserc.TabIndex = 4;
            this.labEserc.Text = "Esercizio:";
            this.labEserc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimentoS
            // 
            this.txtEsercizioMovimentoS.Location = new System.Drawing.Point(90, 19);
            this.txtEsercizioMovimentoS.Name = "txtEsercizioMovimentoS";
            this.txtEsercizioMovimentoS.Size = new System.Drawing.Size(52, 20);
            this.txtEsercizioMovimentoS.TabIndex = 6;
            this.txtEsercizioMovimentoS.Tag = "expensetaxcorrigeview.expenselinkedymov.year";
            // 
            // gboxspesa
            // 
            this.gboxspesa.Controls.Add(this.txtNumeroMovimentoS);
            this.gboxspesa.Controls.Add(this.label4);
            this.gboxspesa.Controls.Add(this.txtEsercizioMovimentoS);
            this.gboxspesa.Controls.Add(this.label7);
            this.gboxspesa.Location = new System.Drawing.Point(12, 447);
            this.gboxspesa.Name = "gboxspesa";
            this.gboxspesa.Size = new System.Drawing.Size(322, 54);
            this.gboxspesa.TabIndex = 30;
            this.gboxspesa.TabStop = false;
            this.gboxspesa.Text = "Movimento di Spesa per versamento";
            // 
            // txtNumeroMovimentoS
            // 
            this.txtNumeroMovimentoS.Location = new System.Drawing.Point(222, 20);
            this.txtNumeroMovimentoS.Name = "txtNumeroMovimentoS";
            this.txtNumeroMovimentoS.Size = new System.Drawing.Size(58, 20);
            this.txtNumeroMovimentoS.TabIndex = 7;
            this.txtNumeroMovimentoS.Tag = "expensetaxcorrigeview.expenselinkednmov";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Esercizio:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpCity
            // 
            this.grpCity.Controls.Add(this.label20);
            this.grpCity.Controls.Add(this.txtProvincia);
            this.grpCity.Controls.Add(this.txtGeoComune0101);
            this.grpCity.Location = new System.Drawing.Point(12, 205);
            this.grpCity.Name = "grpCity";
            this.grpCity.Size = new System.Drawing.Size(376, 48);
            this.grpCity.TabIndex = 31;
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
            this.txtGeoComune0101.Tag = "geo_cityview.title?expensetaxcorrigeview.city";
            // 
            // grpRegion
            // 
            this.grpRegion.Controls.Add(this.cmbRegioneFiscale);
            this.grpRegion.Location = new System.Drawing.Point(9, 207);
            this.grpRegion.Name = "grpRegion";
            this.grpRegion.Size = new System.Drawing.Size(379, 47);
            this.grpRegion.TabIndex = 33;
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
            this.cmbRegioneFiscale.Tag = "expensetaxcorrigeview.idfiscaltaxregion";
            this.cmbRegioneFiscale.ValueMember = "idfiscaltaxregion";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(249, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 16);
            this.label13.TabIndex = 39;
            this.label13.Text = "Anno Competenza:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(365, 309);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 20);
            this.textBox2.TabIndex = 38;
            this.textBox2.Tag = "expensetaxcorrigeview.ayear";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(249, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Data Competenza:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(365, 334);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(112, 20);
            this.textBox6.TabIndex = 34;
            this.textBox6.Tag = "expensetaxcorrigeview.adate";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(365, 360);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(111, 20);
            this.textBox8.TabIndex = 35;
            this.textBox8.Tag = "expensetaxcorrigeview.expenseadate";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(249, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 18);
            this.label6.TabIndex = 37;
            this.label6.Text = "Data Pagamento:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_expensetaxcorrigeview_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 526);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grpRegion);
            this.Controls.Add(this.grpCity);
            this.Controls.Add(this.gboxentrata);
            this.Controls.Add(this.gboxspesa);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Frm_expensetaxcorrigeview_default";
            this.Text = "Frm_expensetaxcorrigeview_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gboxentrata.ResumeLayout(false);
            this.gboxentrata.PerformLayout();
            this.gboxspesa.ResumeLayout(false);
            this.gboxspesa.PerformLayout();
            this.grpCity.ResumeLayout(false);
            this.grpCity.PerformLayout();
            this.grpRegion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtEsercMov;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCreDeb;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gboxentrata;
        private System.Windows.Forms.TextBox txtNumeroMovimentoE;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.TextBox txtEsercizioMovimentoE;
        private System.Windows.Forms.Label labEserc;
        private System.Windows.Forms.TextBox txtEsercizioMovimentoS;
        private System.Windows.Forms.GroupBox gboxspesa;
        private System.Windows.Forms.TextBox txtNumeroMovimentoS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpCity;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtGeoComune0101;
        private System.Windows.Forms.GroupBox grpRegion;
        private System.Windows.Forms.ComboBox cmbRegioneFiscale;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label6;

    }
}
