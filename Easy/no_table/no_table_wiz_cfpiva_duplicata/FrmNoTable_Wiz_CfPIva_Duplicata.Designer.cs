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

namespace no_table_wiz_cfpiva_duplicata {
    partial class FrmNoTable_Wiz_CfPIva_Duplicata {
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInizia = new System.Windows.Forms.Button();
            this.btnSuccessivo = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DetailGrid = new System.Windows.Forms.DataGrid();
            this.grpConferma = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnUnifica = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMultiCF = new System.Windows.Forms.Button();
            this.btnAttivo = new System.Windows.Forms.Button();
            this.grpChoose = new System.Windows.Forms.GroupBox();
            this.cmbRegistryClass = new System.Windows.Forms.ComboBox();
            this.chkNonAttive = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoPIVA = new System.Windows.Forms.RadioButton();
            this.rdoCF = new System.Windows.Forms.RadioButton();
            this.DS = new no_table_wiz_cfpiva_duplicata.vistaForm();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.btnSpecialAction = new System.Windows.Forms.Button();
            this.txtCF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).BeginInit();
            this.grpConferma.SuspendLayout();
            this.grpChoose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInizia);
            this.groupBox3.Controls.Add(this.btnSuccessivo);
            this.groupBox3.Controls.Add(this.btnChiudi);
            this.groupBox3.Location = new System.Drawing.Point(8, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 48);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operazioni";
            // 
            // btnInizia
            // 
            this.btnInizia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInizia.Location = new System.Drawing.Point(8, 16);
            this.btnInizia.Name = "btnInizia";
            this.btnInizia.Size = new System.Drawing.Size(80, 23);
            this.btnInizia.TabIndex = 68;
            this.btnInizia.TabStop = false;
            this.btnInizia.Text = "Inizia Ricerca";
            this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
            // 
            // btnSuccessivo
            // 
            this.btnSuccessivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuccessivo.Enabled = false;
            this.btnSuccessivo.Location = new System.Drawing.Point(96, 16);
            this.btnSuccessivo.Name = "btnSuccessivo";
            this.btnSuccessivo.Size = new System.Drawing.Size(80, 23);
            this.btnSuccessivo.TabIndex = 69;
            this.btnSuccessivo.TabStop = false;
            this.btnSuccessivo.Text = "Prossimo >>";
            this.btnSuccessivo.Click += new System.EventHandler(this.btnSuccessivo_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChiudi.Location = new System.Drawing.Point(184, 16);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(80, 23);
            this.btnChiudi.TabIndex = 70;
            this.btnChiudi.TabStop = false;
            this.btnChiudi.Text = "Termina";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.DetailGrid);
            this.groupBox4.Location = new System.Drawing.Point(12, 162);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(870, 243);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Elenco delle anagrafiche";
            // 
            // DetailGrid
            // 
            this.DetailGrid.AllowNavigation = false;
            this.DetailGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailGrid.DataMember = "";
            this.DetailGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DetailGrid.Location = new System.Drawing.Point(8, 16);
            this.DetailGrid.Name = "DetailGrid";
            this.DetailGrid.ReadOnly = true;
            this.DetailGrid.Size = new System.Drawing.Size(856, 221);
            this.DetailGrid.TabIndex = 66;
            this.DetailGrid.Tag = "registrymainview.anagrafica";
            this.DetailGrid.DoubleClick += new System.EventHandler(this.DetailGrid_DoubleClick);
            // 
            // grpConferma
            // 
            this.grpConferma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpConferma.Controls.Add(this.textBox3);
            this.grpConferma.Controls.Add(this.btnUnifica);
            this.grpConferma.Controls.Add(this.textBox2);
            this.grpConferma.Controls.Add(this.textBox1);
            this.grpConferma.Controls.Add(this.btnMultiCF);
            this.grpConferma.Controls.Add(this.btnAttivo);
            this.grpConferma.Enabled = false;
            this.grpConferma.Location = new System.Drawing.Point(12, 411);
            this.grpConferma.Name = "grpConferma";
            this.grpConferma.Size = new System.Drawing.Size(467, 203);
            this.grpConferma.TabIndex = 9;
            this.grpConferma.TabStop = false;
            this.grpConferma.Text = "Operazioni sull\'anagrafica";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(228, 78);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(214, 54);
            this.textBox3.TabIndex = 78;
            this.textBox3.Tag = "";
            this.textBox3.Text = "Questa operazione può essere eseguita per tutte le anagrafiche";
            // 
            // btnUnifica
            // 
            this.btnUnifica.Location = new System.Drawing.Point(8, 78);
            this.btnUnifica.Name = "btnUnifica";
            this.btnUnifica.Size = new System.Drawing.Size(214, 56);
            this.btnUnifica.TabIndex = 77;
            this.btnUnifica.TabStop = false;
            this.btnUnifica.Tag = "";
            this.btnUnifica.Text = "Marca le anagrafiche come unificabili con l\'unica anagrafica che deve rimanere at" +
                "tiva";
            this.btnUnifica.Click += new System.EventHandler(this.btnUnifica_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(228, 138);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(214, 54);
            this.textBox2.TabIndex = 76;
            this.textBox2.Tag = "";
            this.textBox2.Text = "Questa operazione può essere eseguita per tutte le anagrafiche tranne che per le " +
                "PERSONE FISICHE";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(214, 54);
            this.textBox1.TabIndex = 75;
            this.textBox1.Tag = "";
            this.textBox1.Text = "Questa operazione può essere eseguita per tutte le anagrafiche";
            // 
            // btnMultiCF
            // 
            this.btnMultiCF.Location = new System.Drawing.Point(8, 138);
            this.btnMultiCF.Name = "btnMultiCF";
            this.btnMultiCF.Size = new System.Drawing.Size(214, 56);
            this.btnMultiCF.TabIndex = 74;
            this.btnMultiCF.TabStop = false;
            this.btnMultiCF.Tag = "";
            this.btnMultiCF.Text = "Marca le anagrafiche come anagrafiche aventi codice fiscale o partita IVA non uni" +
                "voco";
            this.btnMultiCF.Click += new System.EventHandler(this.btnMultiCF_Click);
            // 
            // btnAttivo
            // 
            this.btnAttivo.Location = new System.Drawing.Point(8, 16);
            this.btnAttivo.Name = "btnAttivo";
            this.btnAttivo.Size = new System.Drawing.Size(214, 56);
            this.btnAttivo.TabIndex = 72;
            this.btnAttivo.TabStop = false;
            this.btnAttivo.Text = "Imposta l\'anagrafica scelta come attiva mentre le altre diventano NON attive";
            this.btnAttivo.Click += new System.EventHandler(this.btnAttivo_Click);
            // 
            // grpChoose
            // 
            this.grpChoose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChoose.Controls.Add(this.label1);
            this.grpChoose.Controls.Add(this.txtCF);
            this.grpChoose.Controls.Add(this.cmbRegistryClass);
            this.grpChoose.Controls.Add(this.chkNonAttive);
            this.grpChoose.Controls.Add(this.label3);
            this.grpChoose.Controls.Add(this.rdoPIVA);
            this.grpChoose.Controls.Add(this.rdoCF);
            this.grpChoose.Location = new System.Drawing.Point(8, 9);
            this.grpChoose.Name = "grpChoose";
            this.grpChoose.Size = new System.Drawing.Size(868, 93);
            this.grpChoose.TabIndex = 14;
            this.grpChoose.TabStop = false;
            this.grpChoose.Text = "Criteri di Scelta";
            // 
            // cmbRegistryClass
            // 
            this.cmbRegistryClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRegistryClass.FormattingEnabled = true;
            this.cmbRegistryClass.Location = new System.Drawing.Point(535, 38);
            this.cmbRegistryClass.Name = "cmbRegistryClass";
            this.cmbRegistryClass.Size = new System.Drawing.Size(312, 21);
            this.cmbRegistryClass.TabIndex = 4;
            // 
            // chkNonAttive
            // 
            this.chkNonAttive.AutoSize = true;
            this.chkNonAttive.Location = new System.Drawing.Point(535, 15);
            this.chkNonAttive.Name = "chkNonAttive";
            this.chkNonAttive.Size = new System.Drawing.Size(215, 17);
            this.chkNonAttive.TabIndex = 3;
            this.chkNonAttive.TabStop = false;
            this.chkNonAttive.Text = "Considera anche anagrafiche non attive";
            this.chkNonAttive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(107, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(433, 43);
            this.label3.TabIndex = 2;
            this.label3.Text = "Se si sceglie Codice Fiscale, verranno visualizzate le anagrafiche con codice fis" +
                "cale duplicato, se si sceglie partita IVA verranno visualizzate le anagrafiche c" +
                "on partita IVA duplicata";
            // 
            // rdoPIVA
            // 
            this.rdoPIVA.AutoSize = true;
            this.rdoPIVA.Location = new System.Drawing.Point(6, 42);
            this.rdoPIVA.Name = "rdoPIVA";
            this.rdoPIVA.Size = new System.Drawing.Size(75, 17);
            this.rdoPIVA.TabIndex = 1;
            this.rdoPIVA.TabStop = true;
            this.rdoPIVA.Text = "Partita IVA";
            this.rdoPIVA.UseVisualStyleBackColor = true;
            // 
            // rdoCF
            // 
            this.rdoCF.AutoSize = true;
            this.rdoCF.Location = new System.Drawing.Point(7, 19);
            this.rdoCF.Name = "rdoCF";
            this.rdoCF.Size = new System.Drawing.Size(94, 17);
            this.rdoCF.TabIndex = 0;
            this.rdoCF.TabStop = true;
            this.rdoCF.Text = "Codice Fiscale";
            this.rdoCF.UseVisualStyleBackColor = true;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(763, 124);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(115, 23);
            this.btnRefresh.TabIndex = 71;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Text = "Aggiorna Selezione";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(286, 124);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(472, 23);
            this.pBar.TabIndex = 72;
            // 
            // btnSpecialAction
            // 
            this.btnSpecialAction.Location = new System.Drawing.Point(606, 444);
            this.btnSpecialAction.Name = "btnSpecialAction";
            this.btnSpecialAction.Size = new System.Drawing.Size(189, 72);
            this.btnSpecialAction.TabIndex = 73;
            this.btnSpecialAction.Text = "Integra l\'anagrafica selezionata";
            this.btnSpecialAction.UseVisualStyleBackColor = true;
            this.btnSpecialAction.Click += new System.EventHandler(this.btnSpecialAction_Click);
            // 
            // txtCF
            // 
            this.txtCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCF.Location = new System.Drawing.Point(535, 66);
            this.txtCF.Name = "txtCF";
            this.txtCF.Size = new System.Drawing.Size(312, 20);
            this.txtCF.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filtro per CF/P.Iva";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmNoTable_Wiz_CfPIva_Duplicata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 624);
            this.Controls.Add(this.btnSpecialAction);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpChoose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grpConferma);
            this.Name = "FrmNoTable_Wiz_CfPIva_Duplicata";
            this.Text = "FrmNoTable_Wiz_CfPIva_Duplicata";
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).EndInit();
            this.grpConferma.ResumeLayout(false);
            this.grpConferma.PerformLayout();
            this.grpChoose.ResumeLayout(false);
            this.grpChoose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInizia;
        private System.Windows.Forms.Button btnSuccessivo;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGrid DetailGrid;
        private System.Windows.Forms.GroupBox grpConferma;
        private System.Windows.Forms.Button btnMultiCF;
        private System.Windows.Forms.Button btnAttivo;
        private System.Windows.Forms.GroupBox grpChoose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoPIVA;
        private System.Windows.Forms.RadioButton rdoCF;
        public vistaForm DS;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnUnifica;
        private System.Windows.Forms.CheckBox chkNonAttive;
        private System.Windows.Forms.ComboBox cmbRegistryClass;
        private System.Windows.Forms.Button btnSpecialAction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCF;
    }
}