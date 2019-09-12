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

ï»¿namespace csa_contract_partition_elenco {
    partial class Frm_csa_contract_partition_elenco {
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
            this.DS = new csa_contract_partition_elenco.vistaForm();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.txtQuota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpContrattoCSA = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ckbAttivo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoContratto = new System.Windows.Forms.ComboBox();
            this.txtNumOrdine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercContratto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gboxclassSiope = new System.Windows.Forms.GroupBox();
            this.btnCodiceSiope = new System.Windows.Forms.Button();
            this.txtDenomSiope = new System.Windows.Forms.TextBox();
            this.txtCodiceSiope = new System.Windows.Forms.TextBox();
            this.grpBilancioVersamento = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.gboxSpesa = new System.Windows.Forms.GroupBox();
            this.btnSpesa = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gboxImpegnoBudget = new System.Windows.Forms.GroupBox();
            this.btnImpegnoBudget = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbFaseImpBudget = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtNumImpegno = new System.Windows.Forms.TextBox();
            this.txtEsercizioImpegno = new System.Windows.Forms.TextBox();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpContrattoCSA.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gboxclassSiope.SuspendLayout();
            this.grpBilancioVersamento.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxSpesa.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gboxImpegnoBudget.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(635, 24);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(53, 20);
            this.txtEsercizio.TabIndex = 35;
            this.txtEsercizio.Tag = "csa_contract_partition.ayear.year?csa_contract_partitionview.ayear.year";
            // 
            // txtQuota
            // 
            this.txtQuota.Location = new System.Drawing.Point(616, 57);
            this.txtQuota.Name = "txtQuota";
            this.txtQuota.Size = new System.Drawing.Size(72, 20);
            this.txtQuota.TabIndex = 30;
            this.txtQuota.Tag = "csa_contract_partition.quota.fixed.4..%.100";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(561, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Quota:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(554, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 27);
            this.label1.TabIndex = 34;
            this.label1.Text = "Esercizio Ripartizione:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpContrattoCSA
            // 
            this.grpContrattoCSA.Controls.Add(this.textBox1);
            this.grpContrattoCSA.Controls.Add(this.label6);
            this.grpContrattoCSA.Controls.Add(this.ckbAttivo);
            this.grpContrattoCSA.Controls.Add(this.label4);
            this.grpContrattoCSA.Controls.Add(this.cmbTipoContratto);
            this.grpContrattoCSA.Controls.Add(this.txtNumOrdine);
            this.grpContrattoCSA.Controls.Add(this.label3);
            this.grpContrattoCSA.Controls.Add(this.txtEsercContratto);
            this.grpContrattoCSA.Controls.Add(this.label5);
            this.grpContrattoCSA.Location = new System.Drawing.Point(12, 9);
            this.grpContrattoCSA.Name = "grpContrattoCSA";
            this.grpContrattoCSA.Size = new System.Drawing.Size(476, 93);
            this.grpContrattoCSA.TabIndex = 29;
            this.grpContrattoCSA.TabStop = false;
            this.grpContrattoCSA.Text = "Regola specifica CSA";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(297, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 38;
            this.textBox1.Tag = "csa_contract_partition.ndetail?csa_contract_partitionview.ndetail";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(235, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 29);
            this.label6.TabIndex = 37;
            this.label6.Text = "Numero Riga:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckbAttivo
            // 
            this.ckbAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbAttivo.Location = new System.Drawing.Point(386, 61);
            this.ckbAttivo.Name = "ckbAttivo";
            this.ckbAttivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ckbAttivo.Size = new System.Drawing.Size(74, 16);
            this.ckbAttivo.TabIndex = 6;
            this.ckbAttivo.TabStop = false;
            this.ckbAttivo.Tag = "csa_contract.active:S:N?csa_contract_partitionview.active:S:N";
            this.ckbAttivo.Text = "Attivo";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tipo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoContratto
            // 
            this.cmbTipoContratto.DataSource = this.DS.csa_contractkind;
            this.cmbTipoContratto.DisplayMember = "description";
            this.cmbTipoContratto.Location = new System.Drawing.Point(49, 16);
            this.cmbTipoContratto.Name = "cmbTipoContratto";
            this.cmbTipoContratto.Size = new System.Drawing.Size(301, 21);
            this.cmbTipoContratto.TabIndex = 1;
            this.cmbTipoContratto.Tag = "csa_contract.idcsa_contractkind?csa_contracttax_partitionview.idcsa_contractkind";
            this.cmbTipoContratto.ValueMember = "idcsa_contractkind";
            // 
            // txtNumOrdine
            // 
            this.txtNumOrdine.Location = new System.Drawing.Point(170, 57);
            this.txtNumOrdine.Name = "txtNumOrdine";
            this.txtNumOrdine.Size = new System.Drawing.Size(56, 20);
            this.txtNumOrdine.TabIndex = 3;
            this.txtNumOrdine.Tag = "csa_contract.ncontract?csa_contract_partitionview.ncontract";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(108, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercContratto
            // 
            this.txtEsercContratto.Location = new System.Drawing.Point(49, 57);
            this.txtEsercContratto.Name = "txtEsercContratto";
            this.txtEsercContratto.Size = new System.Drawing.Size(56, 20);
            this.txtEsercContratto.TabIndex = 2;
            this.txtEsercContratto.Tag = "csa_contract.ycontract.year?csa_contract_partitionview.ycontract.year";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Eserc.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 111);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(682, 316);
            this.tabControl1.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gboxclassSiope);
            this.tabPage1.Controls.Add(this.grpBilancioVersamento);
            this.tabPage1.Controls.Add(this.gboxUPB);
            this.tabPage1.Controls.Add(this.gboxSpesa);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(674, 290);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Finanziaria";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gboxclassSiope
            // 
            this.gboxclassSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclassSiope.Controls.Add(this.btnCodiceSiope);
            this.gboxclassSiope.Controls.Add(this.txtDenomSiope);
            this.gboxclassSiope.Controls.Add(this.txtCodiceSiope);
            this.gboxclassSiope.Location = new System.Drawing.Point(324, 11);
            this.gboxclassSiope.Name = "gboxclassSiope";
            this.gboxclassSiope.Size = new System.Drawing.Size(336, 132);
            this.gboxclassSiope.TabIndex = 18;
            this.gboxclassSiope.TabStop = false;
            this.gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.treeclassmovimenti";
            this.gboxclassSiope.Text = "Classificazione SIOPE";
            // 
            // btnCodiceSiope
            // 
            this.btnCodiceSiope.Location = new System.Drawing.Point(6, 76);
            this.btnCodiceSiope.Name = "btnCodiceSiope";
            this.btnCodiceSiope.Size = new System.Drawing.Size(88, 23);
            this.btnCodiceSiope.TabIndex = 4;
            this.btnCodiceSiope.TabStop = false;
            this.btnCodiceSiope.Tag = "manage.sorting.tree";
            this.btnCodiceSiope.Text = "Codice";
            this.btnCodiceSiope.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenomSiope
            // 
            this.txtDenomSiope.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenomSiope.Location = new System.Drawing.Point(102, 24);
            this.txtDenomSiope.Multiline = true;
            this.txtDenomSiope.Name = "txtDenomSiope";
            this.txtDenomSiope.ReadOnly = true;
            this.txtDenomSiope.Size = new System.Drawing.Size(226, 76);
            this.txtDenomSiope.TabIndex = 3;
            this.txtDenomSiope.TabStop = false;
            this.txtDenomSiope.Tag = "sorting.description";
            // 
            // txtCodiceSiope
            // 
            this.txtCodiceSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodiceSiope.Location = new System.Drawing.Point(6, 106);
            this.txtCodiceSiope.Name = "txtCodiceSiope";
            this.txtCodiceSiope.Size = new System.Drawing.Size(322, 20);
            this.txtCodiceSiope.TabIndex = 3;
            this.txtCodiceSiope.Tag = "sorting.sortcode?x";
            // 
            // grpBilancioVersamento
            // 
            this.grpBilancioVersamento.Controls.Add(this.txtDescrBilancio);
            this.grpBilancioVersamento.Controls.Add(this.txtBilancio);
            this.grpBilancioVersamento.Controls.Add(this.btnBilancio);
            this.grpBilancioVersamento.Location = new System.Drawing.Point(20, 149);
            this.grpBilancioVersamento.Name = "grpBilancioVersamento";
            this.grpBilancioVersamento.Size = new System.Drawing.Size(298, 127);
            this.grpBilancioVersamento.TabIndex = 16;
            this.grpBilancioVersamento.TabStop = false;
            this.grpBilancioVersamento.Tag = "AutoManage.txtBilancio.trees";
            this.grpBilancioVersamento.Text = "Capitolo Spesa";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancio.Location = new System.Drawing.Point(116, 14);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrBilancio.Size = new System.Drawing.Size(175, 81);
            this.txtDescrBilancio.TabIndex = 0;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "fin.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(6, 101);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(286, 20);
            this.txtBilancio.TabIndex = 2;
            this.txtBilancio.Tag = "fin.codefin?csa_contract_partitionview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(6, 71);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(90, 24);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "manage.fin.trees";
            this.btnBilancio.Text = "Bilancio";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(22, 10);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(296, 133);
            this.gboxUPB.TabIndex = 15;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            this.gboxUPB.Text = "UPB per Imputazone Costo";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 107);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(278, 20);
            this.txtUPB.TabIndex = 9;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(8, 77);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(88, 24);
            this.btnUPB.TabIndex = 1;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "manage.upb.tree";
            this.btnUPB.Text = "UPB";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(120, 14);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(166, 87);
            this.txtDescrUPB.TabIndex = 2;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // gboxSpesa
            // 
            this.gboxSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxSpesa.Controls.Add(this.btnSpesa);
            this.gboxSpesa.Controls.Add(this.label7);
            this.gboxSpesa.Controls.Add(this.txtNum);
            this.gboxSpesa.Controls.Add(this.label13);
            this.gboxSpesa.Controls.Add(this.txtEserc);
            this.gboxSpesa.Controls.Add(this.label12);
            this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
            this.gboxSpesa.Location = new System.Drawing.Point(324, 149);
            this.gboxSpesa.Name = "gboxSpesa";
            this.gboxSpesa.Size = new System.Drawing.Size(336, 127);
            this.gboxSpesa.TabIndex = 14;
            this.gboxSpesa.TabStop = false;
            this.gboxSpesa.Text = "Movimento di Spesa a cui collegare il Lordo";
            // 
            // btnSpesa
            // 
            this.btnSpesa.Location = new System.Drawing.Point(172, 16);
            this.btnSpesa.Name = "btnSpesa";
            this.btnSpesa.Size = new System.Drawing.Size(152, 23);
            this.btnSpesa.TabIndex = 6;
            this.btnSpesa.Text = "Scegli Movimento";
            this.btnSpesa.UseVisualStyleBackColor = true;
            this.btnSpesa.Click += new System.EventHandler(this.btnSpesa_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(45, 50);
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
            this.txtNum.Location = new System.Drawing.Point(225, 75);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(99, 20);
            this.txtNum.TabIndex = 5;
            this.txtNum.Tag = "expenseview.nmov?csa_contract_partitionview.nmov";
            this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(166, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Numero:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(92, 75);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 3;
            this.txtEserc.Tag = "expenseview.ymov.year?csa_contract_partitionview.ymov.year";
            this.txtEserc.Leave += new System.EventHandler(this.txtEserc_Leave);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(11, 76);
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
            this.cmbFaseSpesa.Location = new System.Drawing.Point(92, 51);
            this.cmbFaseSpesa.Name = "cmbFaseSpesa";
            this.cmbFaseSpesa.Size = new System.Drawing.Size(232, 21);
            this.cmbFaseSpesa.TabIndex = 2;
            this.cmbFaseSpesa.Tag = "expenseview.nphase?csa_contract_partitionview.nphaseexpense";
            this.cmbFaseSpesa.ValueMember = "nphase";
            this.cmbFaseSpesa.SelectedIndexChanged += new System.EventHandler(this.cmbFaseSpesa_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gboxImpegnoBudget);
            this.tabPage2.Controls.Add(this.gboxConto);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(677, 290);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gboxImpegnoBudget
            // 
            this.gboxImpegnoBudget.Controls.Add(this.btnImpegnoBudget);
            this.gboxImpegnoBudget.Controls.Add(this.label8);
            this.gboxImpegnoBudget.Controls.Add(this.cmbFaseImpBudget);
            this.gboxImpegnoBudget.Controls.Add(this.label34);
            this.gboxImpegnoBudget.Controls.Add(this.label33);
            this.gboxImpegnoBudget.Controls.Add(this.txtNumImpegno);
            this.gboxImpegnoBudget.Controls.Add(this.txtEsercizioImpegno);
            this.gboxImpegnoBudget.Location = new System.Drawing.Point(18, 132);
            this.gboxImpegnoBudget.Name = "gboxImpegnoBudget";
            this.gboxImpegnoBudget.Size = new System.Drawing.Size(442, 92);
            this.gboxImpegnoBudget.TabIndex = 47;
            this.gboxImpegnoBudget.TabStop = false;
            this.gboxImpegnoBudget.Text = "Impegno di Budget";
            // 
            // btnImpegnoBudget
            // 
            this.btnImpegnoBudget.Location = new System.Drawing.Point(264, 53);
            this.btnImpegnoBudget.Name = "btnImpegnoBudget";
            this.btnImpegnoBudget.Size = new System.Drawing.Size(152, 23);
            this.btnImpegnoBudget.TabIndex = 12;
            this.btnImpegnoBudget.Text = "Scegli Impegno di Budget";
            this.btnImpegnoBudget.UseVisualStyleBackColor = true;
            this.btnImpegnoBudget.Click += new System.EventHandler(this.btnImpegnoBudget_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Fase";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseImpBudget
            // 
            this.cmbFaseImpBudget.DataSource = this.DS.fase_epexp;
            this.cmbFaseImpBudget.DisplayMember = "descrizione";
            this.cmbFaseImpBudget.Location = new System.Drawing.Point(58, 19);
            this.cmbFaseImpBudget.Name = "cmbFaseImpBudget";
            this.cmbFaseImpBudget.Size = new System.Drawing.Size(189, 21);
            this.cmbFaseImpBudget.TabIndex = 11;
            this.cmbFaseImpBudget.Tag = "epexpview.nphase?csa_contract_partitionview.nphaseepexp";
            this.cmbFaseImpBudget.ValueMember = "nphase";
            this.cmbFaseImpBudget.SelectedIndexChanged += new System.EventHandler(this.cmbFaseImpBudget_SelectedIndexChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(114, 58);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 13);
            this.label34.TabIndex = 7;
            this.label34.Text = "Numero";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(7, 59);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "Esercizio";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumImpegno
            // 
            this.txtNumImpegno.Location = new System.Drawing.Point(164, 54);
            this.txtNumImpegno.Name = "txtNumImpegno";
            this.txtNumImpegno.Size = new System.Drawing.Size(64, 20);
            this.txtNumImpegno.TabIndex = 3;
            this.txtNumImpegno.Tag = "epexpview.nepexp?csa_contract_partitionview.nepexp";
            this.txtNumImpegno.Leave += new System.EventHandler(this.txtNumImpegno_Leave);
            // 
            // txtEsercizioImpegno
            // 
            this.txtEsercizioImpegno.Location = new System.Drawing.Point(61, 55);
            this.txtEsercizioImpegno.Name = "txtEsercizioImpegno";
            this.txtEsercizioImpegno.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioImpegno.TabIndex = 2;
            this.txtEsercizioImpegno.Tag = "epexpview.yepexp.year?csa_contract_partitionview.yepexp.year";
            this.txtEsercizioImpegno.Leave += new System.EventHandler(this.txtEsercizioImpegno_Leave);
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button5);
            this.gboxConto.Location = new System.Drawing.Point(18, 28);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(359, 98);
            this.gboxConto.TabIndex = 46;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            this.gboxConto.Text = "Conto EP di Costo";
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
            this.txtCodiceConto.Tag = "account.codeacc?csa_contract_partitionview.codeacc ";
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
            // Frm_csa_contract_partition_elenco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 439);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.txtQuota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpContrattoCSA);
            this.Name = "Frm_csa_contract_partition_elenco";
            this.Text = "Frm_csa_contract_partition_elenco";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpContrattoCSA.ResumeLayout(false);
            this.grpContrattoCSA.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gboxclassSiope.ResumeLayout(false);
            this.gboxclassSiope.PerformLayout();
            this.grpBilancioVersamento.ResumeLayout(false);
            this.grpBilancioVersamento.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxSpesa.ResumeLayout(false);
            this.gboxSpesa.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gboxImpegnoBudget.ResumeLayout(false);
            this.gboxImpegnoBudget.PerformLayout();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public vistaForm DS;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.TextBox txtQuota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpContrattoCSA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoContratto;
        private System.Windows.Forms.TextBox txtNumOrdine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercContratto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox grpBilancioVersamento;
        private System.Windows.Forms.TextBox txtDescrBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.GroupBox gboxUPB;
        public System.Windows.Forms.TextBox txtUPB;
        private System.Windows.Forms.Button btnUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.GroupBox gboxSpesa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEserc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbFaseSpesa;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gboxImpegnoBudget;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbFaseImpBudget;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtNumImpegno;
        private System.Windows.Forms.TextBox txtEsercizioImpegno;
        private System.Windows.Forms.GroupBox gboxConto;
        private System.Windows.Forms.TextBox txtDenominazioneConto;
        private System.Windows.Forms.TextBox txtCodiceConto;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnSpesa;
        private System.Windows.Forms.Button btnImpegnoBudget;
        public System.Windows.Forms.GroupBox gboxclassSiope;
        public System.Windows.Forms.Button btnCodiceSiope;
        private System.Windows.Forms.TextBox txtDenomSiope;
        private System.Windows.Forms.TextBox txtCodiceSiope;
        private System.Windows.Forms.CheckBox ckbAttivo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
    }
}