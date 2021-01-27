
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


namespace assetacquire_massive {
    partial class FrmAssetacquire_massive {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            InChiusura = true;
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAssetacquire_massive));
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnNuoviDati = new System.Windows.Forms.Button();
            this.btnTermina = new System.Windows.Forms.Button();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.btnMostraCarico = new System.Windows.Forms.Button();
            this.tabInfoAgg = new System.Windows.Forms.TabPage();
            this.tabPageEP = new System.Windows.Forms.TabPage();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.grpAnalitico = new System.Windows.Forms.GroupBox();
            this.gboxclass1 = new System.Windows.Forms.GroupBox();
            this.btnCodice1 = new System.Windows.Forms.Button();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtCodice1 = new System.Windows.Forms.TextBox();
            this.gboxclass3 = new System.Windows.Forms.GroupBox();
            this.btnCodice3 = new System.Windows.Forms.Button();
            this.txtDenom3 = new System.Windows.Forms.TextBox();
            this.txtCodice3 = new System.Windows.Forms.TextBox();
            this.gboxclass2 = new System.Windows.Forms.GroupBox();
            this.btnCodice2 = new System.Windows.Forms.Button();
            this.txtDenom2 = new System.Windows.Forms.TextBox();
            this.txtCodice2 = new System.Windows.Forms.TextBox();
            this.tabPagePrinc = new System.Windows.Forms.TabPage();
            this.grpRigaFattura = new System.Windows.Forms.GroupBox();
            this.cmbTipoFattura = new System.Windows.Forms.ComboBox();
            this.DS = new assetacquire_massive.DS();
            this.btnCollegaRigaFattura = new System.Windows.Forms.Button();
            this.txtNumRigaFattura = new System.Windows.Forms.TextBox();
            this.txtNumFattura = new System.Windows.Forms.TextBox();
            this.txtEsercFattura = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chkConsegnatario = new System.Windows.Forms.CheckBox();
            this.grpConsegnatario = new System.Windows.Forms.GroupBox();
            this.txtConsegnatario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkMultifield = new System.Windows.Forms.CheckBox();
            this.chkIncludi = new System.Windows.Forms.CheckBox();
            this.chkUbicResp = new System.Windows.Forms.CheckBox();
            this.grpResp = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpUbicazione = new System.Windows.Forms.GroupBox();
            this.btnUbicazione = new System.Windows.Forms.Button();
            this.txtDescUbicazione = new System.Windows.Forms.TextBox();
            this.txtUbicazione = new System.Windows.Forms.TextBox();
            this.chkDati = new System.Windows.Forms.CheckBox();
            this.chkHideTipoCarico = new System.Windows.Forms.CheckBox();
            this.chkDescrizione = new System.Windows.Forms.CheckBox();
            this.chkClassInventariale = new System.Windows.Forms.CheckBox();
            this.chkCedente = new System.Windows.Forms.CheckBox();
            this.grpTipoCarico = new System.Windows.Forms.GroupBox();
            this.chkContrattoPassivo = new System.Windows.Forms.CheckBox();
            this.grpRiga = new System.Windows.Forms.GroupBox();
            this.cmbTipoOrdine = new System.Windows.Forms.ComboBox();
            this.btnCollegaRiga = new System.Windows.Forms.Button();
            this.txtNumriga = new System.Windows.Forms.TextBox();
            this.txtNumordine = new System.Windows.Forms.TextBox();
            this.txtEsercordine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioPosseduto = new System.Windows.Forms.RadioButton();
            this.radioNuovo = new System.Windows.Forms.RadioButton();
            this.grpCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImpTotale = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtImpostaTotale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImpConIVA = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAbatable = new System.Windows.Forms.TextBox();
            this.btnSuggerimento = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCausale = new System.Windows.Forms.ComboBox();
            this.grpValore = new System.Windows.Forms.GroupBox();
            this.txtImposta = new System.Windows.Forms.TextBox();
            this.txtSconto = new System.Windows.Forms.TextBox();
            this.txtQuantita = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImponibile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpInventario = new System.Windows.Forms.GroupBox();
            this.btnNumInventario = new System.Windows.Forms.Button();
            this.txtNumIniz = new System.Windows.Forms.TextBox();
            this.cboInventario = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.grpClassif = new System.Windows.Forms.GroupBox();
            this.txtDescClassif = new System.Windows.Forms.TextBox();
            this.txtIdClassif = new System.Windows.Forms.TextBox();
            this.btnClassif = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.chkUPB = new System.Windows.Forms.CheckBox();
            this.tabPageEP.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.grpAnalitico.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.tabPagePrinc.SuspendLayout();
            this.grpRigaFattura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpConsegnatario.SuspendLayout();
            this.grpResp.SuspendLayout();
            this.grpUbicazione.SuspendLayout();
            this.grpTipoCarico.SuspendLayout();
            this.grpRiga.SuspendLayout();
            this.grpCredDeb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpValore.SuspendLayout();
            this.grpInventario.SuspendLayout();
            this.grpClassif.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalva.Location = new System.Drawing.Point(277, 713);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(90, 23);
            this.btnSalva.TabIndex = 2;
            this.btnSalva.TabStop = false;
            this.btnSalva.Tag = "mainsave";
            this.btnSalva.Text = "Salva i dati";
            this.btnSalva.UseVisualStyleBackColor = true;
            // 
            // btnNuoviDati
            // 
            this.btnNuoviDati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuoviDati.Location = new System.Drawing.Point(408, 713);
            this.btnNuoviDati.Name = "btnNuoviDati";
            this.btnNuoviDati.Size = new System.Drawing.Size(147, 23);
            this.btnNuoviDati.TabIndex = 17;
            this.btnNuoviDati.TabStop = false;
            this.btnNuoviDati.Tag = "";
            this.btnNuoviDati.Text = "Nuovo Inserimento";
            this.btnNuoviDati.UseVisualStyleBackColor = true;
            this.btnNuoviDati.Click += new System.EventHandler(this.btnNuoviDati_Click);
            // 
            // btnTermina
            // 
            this.btnTermina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTermina.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTermina.Location = new System.Drawing.Point(763, 713);
            this.btnTermina.Name = "btnTermina";
            this.btnTermina.Size = new System.Drawing.Size(90, 23);
            this.btnTermina.TabIndex = 18;
            this.btnTermina.Tag = "";
            this.btnTermina.Text = "Termina";
            this.btnTermina.UseVisualStyleBackColor = true;
            this.btnTermina.Click += new System.EventHandler(this.btnTermina_Click);
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(24, 742);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ReadOnly = true;
            this.txtComments.Size = new System.Drawing.Size(555, 24);
            this.txtComments.TabIndex = 19;
            this.txtComments.TabStop = false;
            // 
            // btnMostraCarico
            // 
            this.btnMostraCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMostraCarico.Location = new System.Drawing.Point(585, 743);
            this.btnMostraCarico.Name = "btnMostraCarico";
            this.btnMostraCarico.Size = new System.Drawing.Size(147, 23);
            this.btnMostraCarico.TabIndex = 20;
            this.btnMostraCarico.Text = "Visualizza carico";
            this.btnMostraCarico.UseVisualStyleBackColor = true;
            this.btnMostraCarico.Click += new System.EventHandler(this.btnMostraCarico_Click);
            // 
            // tabInfoAgg
            // 
            this.tabInfoAgg.Location = new System.Drawing.Point(4, 22);
            this.tabInfoAgg.Name = "tabInfoAgg";
            this.tabInfoAgg.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfoAgg.Size = new System.Drawing.Size(823, 669);
            this.tabInfoAgg.TabIndex = 2;
            this.tabInfoAgg.Text = "Informazioni aggiuntive";
            this.tabInfoAgg.UseVisualStyleBackColor = true;
            // 
            // tabPageEP
            // 
            this.tabPageEP.Controls.Add(this.chkUPB);
            this.tabPageEP.Controls.Add(this.gboxUPB);
            this.tabPageEP.Controls.Add(this.grpAnalitico);
            this.tabPageEP.Location = new System.Drawing.Point(4, 22);
            this.tabPageEP.Name = "tabPageEP";
            this.tabPageEP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEP.Size = new System.Drawing.Size(823, 669);
            this.tabPageEP.TabIndex = 1;
            this.tabPageEP.Text = "E/P";
            this.tabPageEP.UseVisualStyleBackColor = true;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(6, 21);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(545, 104);
            this.gboxUPB.TabIndex = 10;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 77);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(528, 20);
            this.txtUPB.TabIndex = 5;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(175, 9);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(361, 62);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 51);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb.tree";
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // grpAnalitico
            // 
            this.grpAnalitico.Controls.Add(this.gboxclass1);
            this.grpAnalitico.Controls.Add(this.gboxclass3);
            this.grpAnalitico.Controls.Add(this.gboxclass2);
            this.grpAnalitico.Location = new System.Drawing.Point(6, 131);
            this.grpAnalitico.Name = "grpAnalitico";
            this.grpAnalitico.Size = new System.Drawing.Size(545, 224);
            this.grpAnalitico.TabIndex = 9;
            this.grpAnalitico.TabStop = false;
            this.grpAnalitico.Text = "Analitico";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(15, 20);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(513, 64);
            this.gboxclass1.TabIndex = 4;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice1.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(8, 16);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(160, 16);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(345, 44);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice1.Location = new System.Drawing.Point(8, 40);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(146, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(15, 148);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(513, 64);
            this.gboxclass3.TabIndex = 5;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice3.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(8, 16);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(88, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(160, 16);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(345, 44);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice3.Location = new System.Drawing.Point(8, 40);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(146, 20);
            this.txtCodice3.TabIndex = 4;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(15, 84);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(513, 64);
            this.gboxclass2.TabIndex = 6;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice2.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(8, 16);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(88, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(160, 16);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(345, 44);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice2.Location = new System.Drawing.Point(8, 40);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(146, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // tabPagePrinc
            // 
            this.tabPagePrinc.Controls.Add(this.grpRigaFattura);
            this.tabPagePrinc.Controls.Add(this.chkConsegnatario);
            this.tabPagePrinc.Controls.Add(this.grpConsegnatario);
            this.tabPagePrinc.Controls.Add(this.chkMultifield);
            this.tabPagePrinc.Controls.Add(this.chkIncludi);
            this.tabPagePrinc.Controls.Add(this.chkUbicResp);
            this.tabPagePrinc.Controls.Add(this.grpResp);
            this.tabPagePrinc.Controls.Add(this.grpUbicazione);
            this.tabPagePrinc.Controls.Add(this.chkDati);
            this.tabPagePrinc.Controls.Add(this.chkHideTipoCarico);
            this.tabPagePrinc.Controls.Add(this.chkDescrizione);
            this.tabPagePrinc.Controls.Add(this.chkClassInventariale);
            this.tabPagePrinc.Controls.Add(this.chkCedente);
            this.tabPagePrinc.Controls.Add(this.grpTipoCarico);
            this.tabPagePrinc.Controls.Add(this.grpCredDeb);
            this.tabPagePrinc.Controls.Add(this.groupBox1);
            this.tabPagePrinc.Controls.Add(this.groupBox2);
            this.tabPagePrinc.Controls.Add(this.grpValore);
            this.tabPagePrinc.Controls.Add(this.label5);
            this.tabPagePrinc.Controls.Add(this.grpInventario);
            this.tabPagePrinc.Controls.Add(this.txtDescrizione);
            this.tabPagePrinc.Controls.Add(this.txtDataContabile);
            this.tabPagePrinc.Controls.Add(this.grpClassif);
            this.tabPagePrinc.Controls.Add(this.label6);
            this.tabPagePrinc.Location = new System.Drawing.Point(4, 22);
            this.tabPagePrinc.Name = "tabPagePrinc";
            this.tabPagePrinc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrinc.Size = new System.Drawing.Size(823, 669);
            this.tabPagePrinc.TabIndex = 0;
            this.tabPagePrinc.Text = "Principale";
            this.tabPagePrinc.UseVisualStyleBackColor = true;
            // 
            // grpRigaFattura
            // 
            this.grpRigaFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRigaFattura.Controls.Add(this.cmbTipoFattura);
            this.grpRigaFattura.Controls.Add(this.btnCollegaRigaFattura);
            this.grpRigaFattura.Controls.Add(this.txtNumRigaFattura);
            this.grpRigaFattura.Controls.Add(this.txtNumFattura);
            this.grpRigaFattura.Controls.Add(this.txtEsercFattura);
            this.grpRigaFattura.Controls.Add(this.label17);
            this.grpRigaFattura.Location = new System.Drawing.Point(13, 118);
            this.grpRigaFattura.Name = "grpRigaFattura";
            this.grpRigaFattura.Size = new System.Drawing.Size(669, 47);
            this.grpRigaFattura.TabIndex = 32;
            this.grpRigaFattura.TabStop = false;
            this.grpRigaFattura.Text = "Riga della fattura (Tipo  / Eserc. /  Num.  / Gruppo)";
            // 
            // cmbTipoFattura
            // 
            this.cmbTipoFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoFattura.DataSource = this.DS.invoicekind;
            this.cmbTipoFattura.DisplayMember = "description";
            this.cmbTipoFattura.Location = new System.Drawing.Point(150, 19);
            this.cmbTipoFattura.Name = "cmbTipoFattura";
            this.cmbTipoFattura.Size = new System.Drawing.Size(333, 21);
            this.cmbTipoFattura.TabIndex = 2;
            this.cmbTipoFattura.Tag = "assetacquire.idinvkind";
            this.cmbTipoFattura.ValueMember = "idinvkind";
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.EnforceConstraints = false;
            // 
            // btnCollegaRigaFattura
            // 
            this.btnCollegaRigaFattura.Location = new System.Drawing.Point(8, 19);
            this.btnCollegaRigaFattura.Name = "btnCollegaRigaFattura";
            this.btnCollegaRigaFattura.Size = new System.Drawing.Size(136, 23);
            this.btnCollegaRigaFattura.TabIndex = 1;
            this.btnCollegaRigaFattura.TabStop = false;
            this.btnCollegaRigaFattura.Tag = "";
            this.btnCollegaRigaFattura.Text = "Riga fattura";
            this.btnCollegaRigaFattura.Click += new System.EventHandler(this.btnCollegaRigaFattura_Click);
            // 
            // txtNumRigaFattura
            // 
            this.txtNumRigaFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumRigaFattura.Location = new System.Drawing.Point(605, 19);
            this.txtNumRigaFattura.Name = "txtNumRigaFattura";
            this.txtNumRigaFattura.Size = new System.Drawing.Size(48, 20);
            this.txtNumRigaFattura.TabIndex = 5;
            this.txtNumRigaFattura.Tag = "assetacquire.invrownum";
            // 
            // txtNumFattura
            // 
            this.txtNumFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumFattura.Location = new System.Drawing.Point(543, 18);
            this.txtNumFattura.Name = "txtNumFattura";
            this.txtNumFattura.Size = new System.Drawing.Size(56, 20);
            this.txtNumFattura.TabIndex = 4;
            this.txtNumFattura.Tag = "assetacquire.ninv";
            // 
            // txtEsercFattura
            // 
            this.txtEsercFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercFattura.Location = new System.Drawing.Point(489, 18);
            this.txtEsercFattura.Name = "txtEsercFattura";
            this.txtEsercFattura.Size = new System.Drawing.Size(48, 20);
            this.txtEsercFattura.TabIndex = 3;
            this.txtEsercFattura.Tag = "assetacquire.yinv.year";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(120, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 16);
            this.label17.TabIndex = 0;
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkConsegnatario
            // 
            this.chkConsegnatario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkConsegnatario.Checked = true;
            this.chkConsegnatario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConsegnatario.ForeColor = System.Drawing.Color.Red;
            this.chkConsegnatario.Location = new System.Drawing.Point(694, 254);
            this.chkConsegnatario.Name = "chkConsegnatario";
            this.chkConsegnatario.Size = new System.Drawing.Size(126, 58);
            this.chkConsegnatario.TabIndex = 31;
            this.chkConsegnatario.TabStop = false;
            this.chkConsegnatario.Text = "Mantieni informazione su subconsegnatario";
            this.chkConsegnatario.UseVisualStyleBackColor = true;
            // 
            // grpConsegnatario
            // 
            this.grpConsegnatario.Controls.Add(this.txtConsegnatario);
            this.grpConsegnatario.Controls.Add(this.label4);
            this.grpConsegnatario.Location = new System.Drawing.Point(394, 241);
            this.grpConsegnatario.Name = "grpConsegnatario";
            this.grpConsegnatario.Size = new System.Drawing.Size(300, 71);
            this.grpConsegnatario.TabIndex = 30;
            this.grpConsegnatario.TabStop = false;
            this.grpConsegnatario.Tag = "AutoChoose.txtConsegnatario.default.(active=\'S\')";
            // 
            // txtConsegnatario
            // 
            this.txtConsegnatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsegnatario.Location = new System.Drawing.Point(6, 42);
            this.txtConsegnatario.Name = "txtConsegnatario";
            this.txtConsegnatario.Size = new System.Drawing.Size(286, 20);
            this.txtConsegnatario.TabIndex = 0;
            this.txtConsegnatario.Tag = "manager1.title?x";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Subconsegnatario iniziale";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkMultifield
            // 
            this.chkMultifield.AutoSize = true;
            this.chkMultifield.Checked = true;
            this.chkMultifield.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMultifield.ForeColor = System.Drawing.Color.Red;
            this.chkMultifield.Location = new System.Drawing.Point(634, 326);
            this.chkMultifield.Name = "chkMultifield";
            this.chkMultifield.Size = new System.Drawing.Size(177, 17);
            this.chkMultifield.TabIndex = 29;
            this.chkMultifield.TabStop = false;
            this.chkMultifield.Text = "Mantieni Informazioni aggiuntive";
            this.chkMultifield.UseVisualStyleBackColor = true;
            // 
            // chkIncludi
            // 
            this.chkIncludi.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncludi.Location = new System.Drawing.Point(590, 517);
            this.chkIncludi.Name = "chkIncludi";
            this.chkIncludi.Size = new System.Drawing.Size(184, 19);
            this.chkIncludi.TabIndex = 20;
            this.chkIncludi.Tag = "assetacquire.flag:0";
            this.chkIncludi.Text = "Includere in Buono di Carico";
            this.chkIncludi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncludi.Visible = false;
            // 
            // chkUbicResp
            // 
            this.chkUbicResp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUbicResp.Checked = true;
            this.chkUbicResp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUbicResp.ForeColor = System.Drawing.Color.Red;
            this.chkUbicResp.Location = new System.Drawing.Point(694, 178);
            this.chkUbicResp.Name = "chkUbicResp";
            this.chkUbicResp.Size = new System.Drawing.Size(117, 57);
            this.chkUbicResp.TabIndex = 28;
            this.chkUbicResp.TabStop = false;
            this.chkUbicResp.Text = "Mantieni informazione su ubicazione e responsabile";
            this.chkUbicResp.UseVisualStyleBackColor = true;
            // 
            // grpResp
            // 
            this.grpResp.Controls.Add(this.txtResponsabile);
            this.grpResp.Controls.Add(this.label1);
            this.grpResp.Location = new System.Drawing.Point(394, 164);
            this.grpResp.Name = "grpResp";
            this.grpResp.Size = new System.Drawing.Size(300, 71);
            this.grpResp.TabIndex = 3;
            this.grpResp.TabStop = false;
            this.grpResp.Tag = "AutoChoose.txtResponsabile.default.(active=\'S\')";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(6, 42);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(286, 20);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Responsabile iniziale";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpUbicazione
            // 
            this.grpUbicazione.Controls.Add(this.btnUbicazione);
            this.grpUbicazione.Controls.Add(this.txtDescUbicazione);
            this.grpUbicazione.Controls.Add(this.txtUbicazione);
            this.grpUbicazione.Location = new System.Drawing.Point(13, 164);
            this.grpUbicazione.Name = "grpUbicazione";
            this.grpUbicazione.Size = new System.Drawing.Size(368, 71);
            this.grpUbicazione.TabIndex = 2;
            this.grpUbicazione.TabStop = false;
            this.grpUbicazione.Tag = "AutoManage.txtUbicazione.tree";
            // 
            // btnUbicazione
            // 
            this.btnUbicazione.Location = new System.Drawing.Point(6, 14);
            this.btnUbicazione.Name = "btnUbicazione";
            this.btnUbicazione.Size = new System.Drawing.Size(143, 23);
            this.btnUbicazione.TabIndex = 2;
            this.btnUbicazione.Tag = "manage.locationview.tree";
            this.btnUbicazione.Text = "Ubicazione iniziale";
            // 
            // txtDescUbicazione
            // 
            this.txtDescUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescUbicazione.Location = new System.Drawing.Point(164, 14);
            this.txtDescUbicazione.Multiline = true;
            this.txtDescUbicazione.Name = "txtDescUbicazione";
            this.txtDescUbicazione.ReadOnly = true;
            this.txtDescUbicazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescUbicazione.Size = new System.Drawing.Size(197, 48);
            this.txtDescUbicazione.TabIndex = 4;
            this.txtDescUbicazione.TabStop = false;
            this.txtDescUbicazione.Tag = "locationview.description";
            // 
            // txtUbicazione
            // 
            this.txtUbicazione.Location = new System.Drawing.Point(6, 42);
            this.txtUbicazione.Name = "txtUbicazione";
            this.txtUbicazione.Size = new System.Drawing.Size(152, 20);
            this.txtUbicazione.TabIndex = 3;
            this.txtUbicazione.Tag = "locationview.locationcode?x";
            // 
            // chkDati
            // 
            this.chkDati.ForeColor = System.Drawing.Color.Red;
            this.chkDati.Location = new System.Drawing.Point(572, 577);
            this.chkDati.Name = "chkDati";
            this.chkDati.Size = new System.Drawing.Size(235, 22);
            this.chkDati.TabIndex = 25;
            this.chkDati.TabStop = false;
            this.chkDati.Text = "Mantieni informazione su valori e quantità";
            this.chkDati.UseVisualStyleBackColor = true;
            // 
            // chkHideTipoCarico
            // 
            this.chkHideTipoCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHideTipoCarico.ForeColor = System.Drawing.Color.Red;
            this.chkHideTipoCarico.Location = new System.Drawing.Point(689, 44);
            this.chkHideTipoCarico.Name = "chkHideTipoCarico";
            this.chkHideTipoCarico.Size = new System.Drawing.Size(109, 54);
            this.chkHideTipoCarico.TabIndex = 24;
            this.chkHideTipoCarico.TabStop = false;
            this.chkHideTipoCarico.Text = "Nascondi informazione su tipo carico";
            this.chkHideTipoCarico.UseVisualStyleBackColor = true;
            this.chkHideTipoCarico.CheckStateChanged += new System.EventHandler(this.chkHideTipoCarico_CheckStateChanged);
            // 
            // chkDescrizione
            // 
            this.chkDescrizione.AutoSize = true;
            this.chkDescrizione.ForeColor = System.Drawing.Color.Red;
            this.chkDescrizione.Location = new System.Drawing.Point(130, 343);
            this.chkDescrizione.Name = "chkDescrizione";
            this.chkDescrizione.Size = new System.Drawing.Size(198, 17);
            this.chkDescrizione.TabIndex = 23;
            this.chkDescrizione.TabStop = false;
            this.chkDescrizione.Text = "Mantieni informazione su descrizione";
            this.chkDescrizione.UseVisualStyleBackColor = true;
            // 
            // chkClassInventariale
            // 
            this.chkClassInventariale.AutoSize = true;
            this.chkClassInventariale.Checked = true;
            this.chkClassInventariale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClassInventariale.ForeColor = System.Drawing.Color.Red;
            this.chkClassInventariale.Location = new System.Drawing.Point(394, 326);
            this.chkClassInventariale.Name = "chkClassInventariale";
            this.chkClassInventariale.Size = new System.Drawing.Size(229, 17);
            this.chkClassInventariale.TabIndex = 22;
            this.chkClassInventariale.TabStop = false;
            this.chkClassInventariale.Text = "Mantieni informazione su class. inventariale";
            this.chkClassInventariale.UseVisualStyleBackColor = true;
            // 
            // chkCedente
            // 
            this.chkCedente.AutoSize = true;
            this.chkCedente.Checked = true;
            this.chkCedente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCedente.ForeColor = System.Drawing.Color.Red;
            this.chkCedente.Location = new System.Drawing.Point(13, 241);
            this.chkCedente.Name = "chkCedente";
            this.chkCedente.Size = new System.Drawing.Size(184, 17);
            this.chkCedente.TabIndex = 21;
            this.chkCedente.TabStop = false;
            this.chkCedente.Text = "Mantieni informazione su cedente";
            this.chkCedente.UseVisualStyleBackColor = true;
            // 
            // grpTipoCarico
            // 
            this.grpTipoCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTipoCarico.Controls.Add(this.chkContrattoPassivo);
            this.grpTipoCarico.Controls.Add(this.grpRiga);
            this.grpTipoCarico.Controls.Add(this.radioPosseduto);
            this.grpTipoCarico.Controls.Add(this.radioNuovo);
            this.grpTipoCarico.Location = new System.Drawing.Point(13, 0);
            this.grpTipoCarico.Name = "grpTipoCarico";
            this.grpTipoCarico.Size = new System.Drawing.Size(670, 108);
            this.grpTipoCarico.TabIndex = 1;
            this.grpTipoCarico.TabStop = false;
            this.grpTipoCarico.Text = "Tipo carico";
            // 
            // chkContrattoPassivo
            // 
            this.chkContrattoPassivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkContrattoPassivo.AutoSize = true;
            this.chkContrattoPassivo.ForeColor = System.Drawing.Color.Red;
            this.chkContrattoPassivo.Location = new System.Drawing.Point(436, 21);
            this.chkContrattoPassivo.Name = "chkContrattoPassivo";
            this.chkContrattoPassivo.Size = new System.Drawing.Size(226, 17);
            this.chkContrattoPassivo.TabIndex = 19;
            this.chkContrattoPassivo.TabStop = false;
            this.chkContrattoPassivo.Text = "Mantieni informazione su contratto passivo";
            this.chkContrattoPassivo.UseVisualStyleBackColor = true;
            // 
            // grpRiga
            // 
            this.grpRiga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRiga.Controls.Add(this.cmbTipoOrdine);
            this.grpRiga.Controls.Add(this.btnCollegaRiga);
            this.grpRiga.Controls.Add(this.txtNumriga);
            this.grpRiga.Controls.Add(this.txtNumordine);
            this.grpRiga.Controls.Add(this.txtEsercordine);
            this.grpRiga.Controls.Add(this.label2);
            this.grpRiga.Location = new System.Drawing.Point(8, 44);
            this.grpRiga.Name = "grpRiga";
            this.grpRiga.Size = new System.Drawing.Size(654, 48);
            this.grpRiga.TabIndex = 2;
            this.grpRiga.TabStop = false;
            this.grpRiga.Text = "Riga del contratto passivo (Tipo  / Eserc. /  Num.  / Gruppo)";
            // 
            // cmbTipoOrdine
            // 
            this.cmbTipoOrdine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoOrdine.DisplayMember = "description";
            this.cmbTipoOrdine.Location = new System.Drawing.Point(142, 15);
            this.cmbTipoOrdine.Name = "cmbTipoOrdine";
            this.cmbTipoOrdine.Size = new System.Drawing.Size(333, 21);
            this.cmbTipoOrdine.TabIndex = 1;
            this.cmbTipoOrdine.Tag = "assetacquire.idmankind";
            this.cmbTipoOrdine.ValueMember = "idmankind";
            // 
            // btnCollegaRiga
            // 
            this.btnCollegaRiga.Location = new System.Drawing.Point(8, 15);
            this.btnCollegaRiga.Name = "btnCollegaRiga";
            this.btnCollegaRiga.Size = new System.Drawing.Size(128, 23);
            this.btnCollegaRiga.TabIndex = 4;
            this.btnCollegaRiga.TabStop = false;
            this.btnCollegaRiga.Tag = "";
            this.btnCollegaRiga.Text = "Riga contratto passivo";
            this.btnCollegaRiga.Click += new System.EventHandler(this.btnCollegaRiga_Click);
            // 
            // txtNumriga
            // 
            this.txtNumriga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumriga.Location = new System.Drawing.Point(597, 16);
            this.txtNumriga.Name = "txtNumriga";
            this.txtNumriga.Size = new System.Drawing.Size(48, 20);
            this.txtNumriga.TabIndex = 4;
            this.txtNumriga.Tag = "assetacquire.rownum";
            this.txtNumriga.Leave += new System.EventHandler(this.txtNumriga_Leave);
            // 
            // txtNumordine
            // 
            this.txtNumordine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumordine.Location = new System.Drawing.Point(535, 16);
            this.txtNumordine.Name = "txtNumordine";
            this.txtNumordine.Size = new System.Drawing.Size(56, 20);
            this.txtNumordine.TabIndex = 3;
            this.txtNumordine.Tag = "assetacquire.nman";
            // 
            // txtEsercordine
            // 
            this.txtEsercordine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercordine.Location = new System.Drawing.Point(481, 15);
            this.txtEsercordine.Name = "txtEsercordine";
            this.txtEsercordine.Size = new System.Drawing.Size(48, 20);
            this.txtEsercordine.TabIndex = 2;
            this.txtEsercordine.Tag = "assetacquire.yman.year";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(120, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 0;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // radioPosseduto
            // 
            this.radioPosseduto.Location = new System.Drawing.Point(8, 88);
            this.radioPosseduto.Name = "radioPosseduto";
            this.radioPosseduto.Size = new System.Drawing.Size(600, 24);
            this.radioPosseduto.TabIndex = 3;
            this.radioPosseduto.Tag = "assetacquire.flag::1";
            this.radioPosseduto.Text = "Cespite posseduto (il valore del cespite o dell\'accessorio è già incluso nella si" +
    "tuazione patrimoniale)";
            this.radioPosseduto.CheckedChanged += new System.EventHandler(this.radioPosseduto_CheckedChanged);
            // 
            // radioNuovo
            // 
            this.radioNuovo.Location = new System.Drawing.Point(8, 16);
            this.radioNuovo.Name = "radioNuovo";
            this.radioNuovo.Size = new System.Drawing.Size(160, 16);
            this.radioNuovo.TabIndex = 1;
            this.radioNuovo.Tag = "assetacquire.flag::#1";
            this.radioNuovo.Text = "Nuova acquisizione";
            this.radioNuovo.CheckedChanged += new System.EventHandler(this.radioNuovo_CheckedChanged);
            // 
            // grpCredDeb
            // 
            this.grpCredDeb.Controls.Add(this.txtCredDeb);
            this.grpCredDeb.Location = new System.Drawing.Point(13, 263);
            this.grpCredDeb.Name = "grpCredDeb";
            this.grpCredDeb.Size = new System.Drawing.Size(368, 40);
            this.grpCredDeb.TabIndex = 4;
            this.grpCredDeb.TabStop = false;
            this.grpCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.grpCredDeb.Text = "Cedente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(352, 20);
            this.txtCredDeb.TabIndex = 12;
            this.txtCredDeb.Tag = "registry.title?assetacquireview.registry";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtImpTotale);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtImpostaTotale);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtImpConIVA);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtAbatable);
            this.groupBox1.Controls.Add(this.btnSuggerimento);
            this.groupBox1.Location = new System.Drawing.Point(18, 600);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(731, 64);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Totali";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Imponibile";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImpTotale
            // 
            this.txtImpTotale.Location = new System.Drawing.Point(8, 32);
            this.txtImpTotale.Name = "txtImpTotale";
            this.txtImpTotale.ReadOnly = true;
            this.txtImpTotale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImpTotale.Size = new System.Drawing.Size(96, 20);
            this.txtImpTotale.TabIndex = 5;
            this.txtImpTotale.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(128, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "IVA ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImpostaTotale
            // 
            this.txtImpostaTotale.Location = new System.Drawing.Point(128, 32);
            this.txtImpostaTotale.Name = "txtImpostaTotale";
            this.txtImpostaTotale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtImpostaTotale.Size = new System.Drawing.Size(96, 20);
            this.txtImpostaTotale.TabIndex = 6;
            this.txtImpostaTotale.Tag = "assetacquire.tax";
            this.txtImpostaTotale.TextChanged += new System.EventHandler(this.txtImpostaTotale_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(248, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Totale";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImpConIVA
            // 
            this.txtImpConIVA.Location = new System.Drawing.Point(248, 32);
            this.txtImpConIVA.Name = "txtImpConIVA";
            this.txtImpConIVA.ReadOnly = true;
            this.txtImpConIVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImpConIVA.Size = new System.Drawing.Size(96, 20);
            this.txtImpConIVA.TabIndex = 8;
            this.txtImpConIVA.TabStop = false;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(376, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 9;
            this.label14.Text = "IVA detraibile";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAbatable
            // 
            this.txtAbatable.Location = new System.Drawing.Point(376, 32);
            this.txtAbatable.Name = "txtAbatable";
            this.txtAbatable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAbatable.Size = new System.Drawing.Size(80, 20);
            this.txtAbatable.TabIndex = 10;
            this.txtAbatable.Tag = "assetacquire.abatable";
            // 
            // btnSuggerimento
            // 
            this.btnSuggerimento.Location = new System.Drawing.Point(597, 16);
            this.btnSuggerimento.Name = "btnSuggerimento";
            this.btnSuggerimento.Size = new System.Drawing.Size(128, 40);
            this.btnSuggerimento.TabIndex = 7;
            this.btnSuggerimento.Text = "Suggerimento su come effettuare il carico";
            this.btnSuggerimento.Click += new System.EventHandler(this.btnSuggerimento_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboCausale);
            this.groupBox2.Location = new System.Drawing.Point(13, 303);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 40);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Causale di Carico";
            // 
            // cboCausale
            // 
            this.cboCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCausale.DisplayMember = "description";
            this.cboCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCausale.Location = new System.Drawing.Point(8, 16);
            this.cboCausale.Name = "cboCausale";
            this.cboCausale.Size = new System.Drawing.Size(352, 21);
            this.cboCausale.TabIndex = 14;
            this.cboCausale.Tag = "assetacquire.idmot.(active=\'S\')";
            this.cboCausale.ValueMember = "idmot";
            // 
            // grpValore
            // 
            this.grpValore.Controls.Add(this.txtImposta);
            this.grpValore.Controls.Add(this.txtSconto);
            this.grpValore.Controls.Add(this.txtQuantita);
            this.grpValore.Controls.Add(this.label12);
            this.grpValore.Controls.Add(this.label10);
            this.grpValore.Controls.Add(this.label8);
            this.grpValore.Controls.Add(this.txtImponibile);
            this.grpValore.Controls.Add(this.label7);
            this.grpValore.Location = new System.Drawing.Point(18, 541);
            this.grpValore.Name = "grpValore";
            this.grpValore.Size = new System.Drawing.Size(548, 56);
            this.grpValore.TabIndex = 10;
            this.grpValore.TabStop = false;
            // 
            // txtImposta
            // 
            this.txtImposta.Location = new System.Drawing.Point(312, 32);
            this.txtImposta.Name = "txtImposta";
            this.txtImposta.Size = new System.Drawing.Size(80, 20);
            this.txtImposta.TabIndex = 4;
            this.txtImposta.Tag = "assetacquire.taxrate.fixed.4..%.100";
            this.txtImposta.TextChanged += new System.EventHandler(this.txtImposta_TextChanged);
            // 
            // txtSconto
            // 
            this.txtSconto.Location = new System.Drawing.Point(112, 32);
            this.txtSconto.Name = "txtSconto";
            this.txtSconto.Size = new System.Drawing.Size(80, 20);
            this.txtSconto.TabIndex = 2;
            this.txtSconto.Tag = "assetacquire.discount.fixed.4..%.100";
            this.txtSconto.TextChanged += new System.EventHandler(this.txtSconto_TextChanged);
            // 
            // txtQuantita
            // 
            this.txtQuantita.Location = new System.Drawing.Point(216, 32);
            this.txtQuantita.Name = "txtQuantita";
            this.txtQuantita.Size = new System.Drawing.Size(80, 20);
            this.txtQuantita.TabIndex = 3;
            this.txtQuantita.Tag = "assetacquire.number";
            this.txtQuantita.TextChanged += new System.EventHandler(this.txtQuantita_TextChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(112, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Sconto";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(216, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Quantità";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(312, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Aliquota IVA";
            // 
            // txtImponibile
            // 
            this.txtImponibile.Location = new System.Drawing.Point(16, 32);
            this.txtImponibile.Name = "txtImponibile";
            this.txtImponibile.Size = new System.Drawing.Size(80, 20);
            this.txtImponibile.TabIndex = 1;
            this.txtImponibile.Tag = "assetacquire.taxable";
            this.txtImponibile.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Imponibile";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Descrizione:";
            // 
            // grpInventario
            // 
            this.grpInventario.Controls.Add(this.btnNumInventario);
            this.grpInventario.Controls.Add(this.txtNumIniz);
            this.grpInventario.Controls.Add(this.cboInventario);
            this.grpInventario.Controls.Add(this.label13);
            this.grpInventario.Controls.Add(this.chkAuto);
            this.grpInventario.Location = new System.Drawing.Point(18, 474);
            this.grpInventario.Name = "grpInventario";
            this.grpInventario.Size = new System.Drawing.Size(548, 64);
            this.grpInventario.TabIndex = 9;
            this.grpInventario.TabStop = false;
            this.grpInventario.Text = "Inventario";
            // 
            // btnNumInventario
            // 
            this.btnNumInventario.Location = new System.Drawing.Point(32, 40);
            this.btnNumInventario.Name = "btnNumInventario";
            this.btnNumInventario.Size = new System.Drawing.Size(75, 20);
            this.btnNumInventario.TabIndex = 4;
            this.btnNumInventario.TabStop = false;
            this.btnNumInventario.Text = "N. iniziale";
            // 
            // txtNumIniz
            // 
            this.txtNumIniz.Location = new System.Drawing.Point(112, 40);
            this.txtNumIniz.Name = "txtNumIniz";
            this.txtNumIniz.Size = new System.Drawing.Size(88, 20);
            this.txtNumIniz.TabIndex = 2;
            this.txtNumIniz.Tag = "assetacquire.startnumber";
            // 
            // cboInventario
            // 
            this.cboInventario.DisplayMember = "description";
            this.cboInventario.Location = new System.Drawing.Point(112, 16);
            this.cboInventario.Name = "cboInventario";
            this.cboInventario.Size = new System.Drawing.Size(328, 21);
            this.cboInventario.TabIndex = 1;
            this.cboInventario.Tag = "assetacquire.idinventory.(active=\'S\')?assetacquireview.idinventory";
            this.cboInventario.ValueMember = "idinventory";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Inventario";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAuto
            // 
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(235, 40);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(307, 18);
            this.chkAuto.TabIndex = 3;
            this.chkAuto.Text = "Assegnazione in automatico del numero di inventario";
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(18, 362);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(363, 109);
            this.txtDescrizione.TabIndex = 7;
            this.txtDescrizione.Tag = "assetacquire.description";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(730, 474);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
            this.txtDataContabile.TabIndex = 8;
            this.txtDataContabile.Tag = "assetacquire.adate";
            // 
            // grpClassif
            // 
            this.grpClassif.Controls.Add(this.txtDescClassif);
            this.grpClassif.Controls.Add(this.txtIdClassif);
            this.grpClassif.Controls.Add(this.btnClassif);
            this.grpClassif.Location = new System.Drawing.Point(394, 349);
            this.grpClassif.Name = "grpClassif";
            this.grpClassif.Size = new System.Drawing.Size(423, 86);
            this.grpClassif.TabIndex = 6;
            this.grpClassif.TabStop = false;
            this.grpClassif.Tag = "AutoManage.txtIdClassif.tree";
            this.grpClassif.Text = "Classificazione inventariale";
            // 
            // txtDescClassif
            // 
            this.txtDescClassif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescClassif.Location = new System.Drawing.Point(8, 46);
            this.txtDescClassif.Multiline = true;
            this.txtDescClassif.Name = "txtDescClassif";
            this.txtDescClassif.ReadOnly = true;
            this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescClassif.Size = new System.Drawing.Size(407, 32);
            this.txtDescClassif.TabIndex = 19;
            this.txtDescClassif.TabStop = false;
            this.txtDescClassif.Tag = "inventorytreeview.description";
            // 
            // txtIdClassif
            // 
            this.txtIdClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdClassif.Location = new System.Drawing.Point(134, 20);
            this.txtIdClassif.Name = "txtIdClassif";
            this.txtIdClassif.Size = new System.Drawing.Size(279, 20);
            this.txtIdClassif.TabIndex = 1;
            this.txtIdClassif.Tag = "inventorytreeview.codeinv?assetacquireview.codeinv";
            // 
            // btnClassif
            // 
            this.btnClassif.Image = ((System.Drawing.Image)(resources.GetObject("btnClassif.Image")));
            this.btnClassif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassif.Location = new System.Drawing.Point(8, 17);
            this.btnClassif.Name = "btnClassif";
            this.btnClassif.Size = new System.Drawing.Size(120, 23);
            this.btnClassif.TabIndex = 17;
            this.btnClassif.TabStop = false;
            this.btnClassif.Tag = "manage.inventorytreeview.tree";
            this.btnClassif.Text = "Classificazione";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(642, 474);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Data contabile:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPagePrinc);
            this.tabControl.Controls.Add(this.tabPageEP);
            this.tabControl.Controls.Add(this.tabInfoAgg);
            this.tabControl.Location = new System.Drawing.Point(20, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(831, 695);
            this.tabControl.TabIndex = 1;
            // 
            // chkUPB
            // 
            this.chkUPB.Checked = true;
            this.chkUPB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUPB.ForeColor = System.Drawing.Color.Red;
            this.chkUPB.Location = new System.Drawing.Point(573, 45);
            this.chkUPB.Name = "chkUPB";
            this.chkUPB.Size = new System.Drawing.Size(200, 57);
            this.chkUPB.TabIndex = 29;
            this.chkUPB.TabStop = false;
            this.chkUPB.Text = "Mantieni informazione su UPB";
            this.chkUPB.UseVisualStyleBackColor = true;
            // 
            // FrmAssetacquire_massive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 776);
            this.Controls.Add(this.btnMostraCarico);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.btnTermina);
            this.Controls.Add(this.btnNuoviDati);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAssetacquire_massive";
            this.Text = "FrmAssetacquire_massive";
            this.tabPageEP.ResumeLayout(false);
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.grpAnalitico.ResumeLayout(false);
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.tabPagePrinc.ResumeLayout(false);
            this.tabPagePrinc.PerformLayout();
            this.grpRigaFattura.ResumeLayout(false);
            this.grpRigaFattura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpConsegnatario.ResumeLayout(false);
            this.grpConsegnatario.PerformLayout();
            this.grpResp.ResumeLayout(false);
            this.grpResp.PerformLayout();
            this.grpUbicazione.ResumeLayout(false);
            this.grpUbicazione.PerformLayout();
            this.grpTipoCarico.ResumeLayout(false);
            this.grpTipoCarico.PerformLayout();
            this.grpRiga.ResumeLayout(false);
            this.grpRiga.PerformLayout();
            this.grpCredDeb.ResumeLayout(false);
            this.grpCredDeb.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpValore.ResumeLayout(false);
            this.grpValore.PerformLayout();
            this.grpInventario.ResumeLayout(false);
            this.grpInventario.PerformLayout();
            this.grpClassif.ResumeLayout(false);
            this.grpClassif.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnNuoviDati;
        private System.Windows.Forms.Button btnTermina;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Button btnMostraCarico;
        public DS DS;
        private System.Windows.Forms.TabPage tabInfoAgg;
        private System.Windows.Forms.TabPage tabPageEP;
        private System.Windows.Forms.GroupBox gboxUPB;
        public System.Windows.Forms.TextBox txtUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.Button btnUPBCode;
        private System.Windows.Forms.GroupBox grpAnalitico;
        public System.Windows.Forms.GroupBox gboxclass1;
        public System.Windows.Forms.Button btnCodice1;
        private System.Windows.Forms.TextBox txtDenom1;
        private System.Windows.Forms.TextBox txtCodice1;
        public System.Windows.Forms.GroupBox gboxclass3;
        public System.Windows.Forms.Button btnCodice3;
        private System.Windows.Forms.TextBox txtDenom3;
        private System.Windows.Forms.TextBox txtCodice3;
        public System.Windows.Forms.GroupBox gboxclass2;
        public System.Windows.Forms.Button btnCodice2;
        private System.Windows.Forms.TextBox txtDenom2;
        private System.Windows.Forms.TextBox txtCodice2;
        private System.Windows.Forms.TabPage tabPagePrinc;
        private System.Windows.Forms.CheckBox chkConsegnatario;
        private System.Windows.Forms.GroupBox grpConsegnatario;
        public System.Windows.Forms.TextBox txtConsegnatario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkMultifield;
        private System.Windows.Forms.CheckBox chkIncludi;
        private System.Windows.Forms.CheckBox chkUbicResp;
        private System.Windows.Forms.GroupBox grpResp;
        public System.Windows.Forms.TextBox txtResponsabile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpUbicazione;
        private System.Windows.Forms.Button btnUbicazione;
        private System.Windows.Forms.TextBox txtDescUbicazione;
        private System.Windows.Forms.TextBox txtUbicazione;
        private System.Windows.Forms.CheckBox chkDati;
        private System.Windows.Forms.CheckBox chkHideTipoCarico;
        private System.Windows.Forms.CheckBox chkDescrizione;
        private System.Windows.Forms.CheckBox chkClassInventariale;
        private System.Windows.Forms.CheckBox chkCedente;
        private System.Windows.Forms.GroupBox grpTipoCarico;
        private System.Windows.Forms.CheckBox chkContrattoPassivo;
        private System.Windows.Forms.GroupBox grpRiga;
        private System.Windows.Forms.ComboBox cmbTipoOrdine;
        private System.Windows.Forms.Button btnCollegaRiga;
        private System.Windows.Forms.TextBox txtNumriga;
        private System.Windows.Forms.TextBox txtNumordine;
        private System.Windows.Forms.TextBox txtEsercordine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioPosseduto;
        private System.Windows.Forms.RadioButton radioNuovo;
        private System.Windows.Forms.GroupBox grpCredDeb;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtImpTotale;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtImpostaTotale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImpConIVA;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAbatable;
        private System.Windows.Forms.Button btnSuggerimento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboCausale;
        private System.Windows.Forms.GroupBox grpValore;
        private System.Windows.Forms.TextBox txtImposta;
        private System.Windows.Forms.TextBox txtSconto;
        private System.Windows.Forms.TextBox txtQuantita;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImponibile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpInventario;
        private System.Windows.Forms.Button btnNumInventario;
        private System.Windows.Forms.TextBox txtNumIniz;
        private System.Windows.Forms.ComboBox cboInventario;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.GroupBox grpClassif;
        private System.Windows.Forms.TextBox txtDescClassif;
        private System.Windows.Forms.TextBox txtIdClassif;
        private System.Windows.Forms.Button btnClassif;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.GroupBox grpRigaFattura;
        private System.Windows.Forms.ComboBox cmbTipoFattura;
        private System.Windows.Forms.Button btnCollegaRigaFattura;
        private System.Windows.Forms.TextBox txtNumRigaFattura;
        private System.Windows.Forms.TextBox txtNumFattura;
        private System.Windows.Forms.TextBox txtEsercFattura;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkUPB;
    }
}
