
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


namespace no_table_wiz_cfpiva_duplicata {
    partial class frmUnisciInformazioni {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
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
            this.gridmodpag = new System.Windows.Forms.DataGrid();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabModPag = new System.Windows.Forms.TabPage();
            this.btnChangeRegModeCode = new System.Windows.Forms.Button();
            this.btnImpostaModPagamento = new System.Windows.Forms.Button();
            this.TabIndirizzi = new System.Windows.Forms.TabPage();
            this.btnImpostaIndirizzi = new System.Windows.Forms.Button();
            this.gridindirizzi = new System.Windows.Forms.DataGrid();
            this.tabMissioni = new System.Windows.Forms.TabPage();
            this.btnImpostaPosGiur = new System.Windows.Forms.Button();
            this.gridposgiur = new System.Windows.Forms.DataGrid();
            this.tabImponibile = new System.Windows.Forms.TabPage();
            this.btnImponibile = new System.Windows.Forms.Button();
            this.gridimponibile = new System.Windows.Forms.DataGrid();
            this.tabReference = new System.Windows.Forms.TabPage();
            this.btnContatti = new System.Windows.Forms.Button();
            this.gridreference = new System.Windows.Forms.DataGrid();
            this.tabCF = new System.Windows.Forms.TabPage();
            this.btnCF = new System.Windows.Forms.Button();
            this.gridcfstorico = new System.Windows.Forms.DataGrid();
            this.tabIva = new System.Windows.Forms.TabPage();
            this.btnPIva = new System.Windows.Forms.Button();
            this.gridivastorico = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridmodpag)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabModPag.SuspendLayout();
            this.TabIndirizzi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridindirizzi)).BeginInit();
            this.tabMissioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridposgiur)).BeginInit();
            this.tabImponibile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridimponibile)).BeginInit();
            this.tabReference.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridreference)).BeginInit();
            this.tabCF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridcfstorico)).BeginInit();
            this.tabIva.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridivastorico)).BeginInit();
            this.SuspendLayout();
            // 
            // gridmodpag
            // 
            this.gridmodpag.AllowNavigation = false;
            this.gridmodpag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridmodpag.DataMember = "";
            this.gridmodpag.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridmodpag.Location = new System.Drawing.Point(17, 6);
            this.gridmodpag.Name = "gridmodpag";
            this.gridmodpag.ReadOnly = true;
            this.gridmodpag.Size = new System.Drawing.Size(997, 421);
            this.gridmodpag.TabIndex = 67;
            this.gridmodpag.Tag = "registrymainview.anagrafica";
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabModPag);
            this.tabs.Controls.Add(this.TabIndirizzi);
            this.tabs.Controls.Add(this.tabMissioni);
            this.tabs.Controls.Add(this.tabImponibile);
            this.tabs.Controls.Add(this.tabReference);
            this.tabs.Controls.Add(this.tabCF);
            this.tabs.Controls.Add(this.tabIva);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1028, 528);
            this.tabs.TabIndex = 68;
            // 
            // tabModPag
            // 
            this.tabModPag.Controls.Add(this.btnChangeRegModeCode);
            this.tabModPag.Controls.Add(this.btnImpostaModPagamento);
            this.tabModPag.Controls.Add(this.gridmodpag);
            this.tabModPag.Location = new System.Drawing.Point(4, 22);
            this.tabModPag.Name = "tabModPag";
            this.tabModPag.Padding = new System.Windows.Forms.Padding(3);
            this.tabModPag.Size = new System.Drawing.Size(1020, 502);
            this.tabModPag.TabIndex = 0;
            this.tabModPag.Text = "Modalità di pagamento";
            this.tabModPag.UseVisualStyleBackColor = true;
            // 
            // btnChangeRegModeCode
            // 
            this.btnChangeRegModeCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeRegModeCode.Location = new System.Drawing.Point(114, 452);
            this.btnChangeRegModeCode.Name = "btnChangeRegModeCode";
            this.btnChangeRegModeCode.Size = new System.Drawing.Size(157, 23);
            this.btnChangeRegModeCode.TabIndex = 69;
            this.btnChangeRegModeCode.Text = "Cambia nome modalità";
            this.btnChangeRegModeCode.UseVisualStyleBackColor = true;
            this.btnChangeRegModeCode.Click += new System.EventHandler(this.btnChangeRegModeCode_Click);
            // 
            // btnImpostaModPagamento
            // 
            this.btnImpostaModPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImpostaModPagamento.Location = new System.Drawing.Point(425, 433);
            this.btnImpostaModPagamento.Name = "btnImpostaModPagamento";
            this.btnImpostaModPagamento.Size = new System.Drawing.Size(316, 61);
            this.btnImpostaModPagamento.TabIndex = 68;
            this.btnImpostaModPagamento.Text = "Imposta per l\'anagrafica scelta le modalità selezionate (cancellando eventualment" +
    "e quelle esistenti)";
            this.btnImpostaModPagamento.UseVisualStyleBackColor = true;
            this.btnImpostaModPagamento.Click += new System.EventHandler(this.btnImpostaModPagamento_Click);
            // 
            // TabIndirizzi
            // 
            this.TabIndirizzi.Controls.Add(this.btnImpostaIndirizzi);
            this.TabIndirizzi.Controls.Add(this.gridindirizzi);
            this.TabIndirizzi.Location = new System.Drawing.Point(4, 22);
            this.TabIndirizzi.Name = "TabIndirizzi";
            this.TabIndirizzi.Padding = new System.Windows.Forms.Padding(3);
            this.TabIndirizzi.Size = new System.Drawing.Size(1048, 502);
            this.TabIndirizzi.TabIndex = 1;
            this.TabIndirizzi.Text = "Indirizzi";
            this.TabIndirizzi.UseVisualStyleBackColor = true;
            // 
            // btnImpostaIndirizzi
            // 
            this.btnImpostaIndirizzi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImpostaIndirizzi.Location = new System.Drawing.Point(302, 411);
            this.btnImpostaIndirizzi.Name = "btnImpostaIndirizzi";
            this.btnImpostaIndirizzi.Size = new System.Drawing.Size(316, 61);
            this.btnImpostaIndirizzi.TabIndex = 69;
            this.btnImpostaIndirizzi.Text = "Imposta per l\'anagrafica scelta gli indirizzi selezionati (cancellando eventualme" +
    "nte quelli esistenti)";
            this.btnImpostaIndirizzi.UseVisualStyleBackColor = true;
            this.btnImpostaIndirizzi.Click += new System.EventHandler(this.btnImpostaIndirizzi_Click);
            // 
            // gridindirizzi
            // 
            this.gridindirizzi.AllowNavigation = false;
            this.gridindirizzi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridindirizzi.DataMember = "";
            this.gridindirizzi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridindirizzi.Location = new System.Drawing.Point(6, 6);
            this.gridindirizzi.Name = "gridindirizzi";
            this.gridindirizzi.ReadOnly = true;
            this.gridindirizzi.Size = new System.Drawing.Size(936, 399);
            this.gridindirizzi.TabIndex = 68;
            this.gridindirizzi.Tag = "registrymainview.anagrafica";
            // 
            // tabMissioni
            // 
            this.tabMissioni.Controls.Add(this.btnImpostaPosGiur);
            this.tabMissioni.Controls.Add(this.gridposgiur);
            this.tabMissioni.Location = new System.Drawing.Point(4, 22);
            this.tabMissioni.Name = "tabMissioni";
            this.tabMissioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabMissioni.Size = new System.Drawing.Size(1048, 502);
            this.tabMissioni.TabIndex = 2;
            this.tabMissioni.Text = "Inquadramento";
            this.tabMissioni.UseVisualStyleBackColor = true;
            // 
            // btnImpostaPosGiur
            // 
            this.btnImpostaPosGiur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImpostaPosGiur.Location = new System.Drawing.Point(309, 419);
            this.btnImpostaPosGiur.Name = "btnImpostaPosGiur";
            this.btnImpostaPosGiur.Size = new System.Drawing.Size(316, 61);
            this.btnImpostaPosGiur.TabIndex = 69;
            this.btnImpostaPosGiur.Text = "Imposta per l\'anagrafica scelta le informazioni selezionate (cancellando eventual" +
    "mente quelle esistenti)";
            this.btnImpostaPosGiur.UseVisualStyleBackColor = true;
            this.btnImpostaPosGiur.Click += new System.EventHandler(this.btnImpostaPosGiur_Click);
            // 
            // gridposgiur
            // 
            this.gridposgiur.AllowNavigation = false;
            this.gridposgiur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridposgiur.DataMember = "";
            this.gridposgiur.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridposgiur.Location = new System.Drawing.Point(6, 6);
            this.gridposgiur.Name = "gridposgiur";
            this.gridposgiur.ReadOnly = true;
            this.gridposgiur.Size = new System.Drawing.Size(936, 407);
            this.gridposgiur.TabIndex = 68;
            this.gridposgiur.Tag = "registrymainview.anagrafica";
            // 
            // tabImponibile
            // 
            this.tabImponibile.Controls.Add(this.btnImponibile);
            this.tabImponibile.Controls.Add(this.gridimponibile);
            this.tabImponibile.Location = new System.Drawing.Point(4, 22);
            this.tabImponibile.Name = "tabImponibile";
            this.tabImponibile.Size = new System.Drawing.Size(1048, 502);
            this.tabImponibile.TabIndex = 6;
            this.tabImponibile.Text = "Imponibile Presunto";
            this.tabImponibile.UseVisualStyleBackColor = true;
            // 
            // btnImponibile
            // 
            this.btnImponibile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImponibile.Location = new System.Drawing.Point(314, 420);
            this.btnImponibile.Name = "btnImponibile";
            this.btnImponibile.Size = new System.Drawing.Size(316, 61);
            this.btnImponibile.TabIndex = 71;
            this.btnImponibile.Text = "Imposta per l\'anagrafica scelta le informazioni selezionate (cancellando eventual" +
    "mente quelle esistenti)";
            this.btnImponibile.UseVisualStyleBackColor = true;
            this.btnImponibile.Click += new System.EventHandler(this.btnImponibile_Click);
            // 
            // gridimponibile
            // 
            this.gridimponibile.AllowNavigation = false;
            this.gridimponibile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridimponibile.DataMember = "";
            this.gridimponibile.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridimponibile.Location = new System.Drawing.Point(11, 7);
            this.gridimponibile.Name = "gridimponibile";
            this.gridimponibile.ReadOnly = true;
            this.gridimponibile.Size = new System.Drawing.Size(936, 407);
            this.gridimponibile.TabIndex = 70;
            this.gridimponibile.Tag = "registrymainview.anagrafica";
            // 
            // tabReference
            // 
            this.tabReference.Controls.Add(this.btnContatti);
            this.tabReference.Controls.Add(this.gridreference);
            this.tabReference.Location = new System.Drawing.Point(4, 22);
            this.tabReference.Name = "tabReference";
            this.tabReference.Size = new System.Drawing.Size(1048, 502);
            this.tabReference.TabIndex = 3;
            this.tabReference.Text = "Contatti";
            this.tabReference.UseVisualStyleBackColor = true;
            // 
            // btnContatti
            // 
            this.btnContatti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContatti.Location = new System.Drawing.Point(309, 417);
            this.btnContatti.Name = "btnContatti";
            this.btnContatti.Size = new System.Drawing.Size(316, 61);
            this.btnContatti.TabIndex = 69;
            this.btnContatti.Text = "Imposta per l\'anagrafica scelta i contatti selezionati (cancellando eventualmente" +
    " quelli esistenti)";
            this.btnContatti.UseVisualStyleBackColor = true;
            this.btnContatti.Click += new System.EventHandler(this.btnContatti_Click);
            // 
            // gridreference
            // 
            this.gridreference.AllowNavigation = false;
            this.gridreference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridreference.DataMember = "";
            this.gridreference.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridreference.Location = new System.Drawing.Point(3, 13);
            this.gridreference.Name = "gridreference";
            this.gridreference.ReadOnly = true;
            this.gridreference.Size = new System.Drawing.Size(936, 398);
            this.gridreference.TabIndex = 68;
            this.gridreference.Tag = "registrymainview.anagrafica";
            // 
            // tabCF
            // 
            this.tabCF.Controls.Add(this.btnCF);
            this.tabCF.Controls.Add(this.gridcfstorico);
            this.tabCF.Location = new System.Drawing.Point(4, 22);
            this.tabCF.Name = "tabCF";
            this.tabCF.Size = new System.Drawing.Size(1048, 502);
            this.tabCF.TabIndex = 4;
            this.tabCF.Text = "CF storico";
            this.tabCF.UseVisualStyleBackColor = true;
            // 
            // btnCF
            // 
            this.btnCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCF.Location = new System.Drawing.Point(321, 413);
            this.btnCF.Name = "btnCF";
            this.btnCF.Size = new System.Drawing.Size(316, 61);
            this.btnCF.TabIndex = 69;
            this.btnCF.Text = "Imposta per l\'anagrafica scelta i CF selezionati  (cancellando eventualmente quel" +
    "li esistenti)";
            this.btnCF.UseVisualStyleBackColor = true;
            this.btnCF.Click += new System.EventHandler(this.btnCF_Click);
            // 
            // gridcfstorico
            // 
            this.gridcfstorico.AllowNavigation = false;
            this.gridcfstorico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridcfstorico.DataMember = "";
            this.gridcfstorico.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridcfstorico.Location = new System.Drawing.Point(8, 12);
            this.gridcfstorico.Name = "gridcfstorico";
            this.gridcfstorico.ReadOnly = true;
            this.gridcfstorico.Size = new System.Drawing.Size(936, 395);
            this.gridcfstorico.TabIndex = 68;
            this.gridcfstorico.Tag = "registrymainview.anagrafica";
            // 
            // tabIva
            // 
            this.tabIva.Controls.Add(this.btnPIva);
            this.tabIva.Controls.Add(this.gridivastorico);
            this.tabIva.Location = new System.Drawing.Point(4, 22);
            this.tabIva.Name = "tabIva";
            this.tabIva.Size = new System.Drawing.Size(1048, 502);
            this.tabIva.TabIndex = 5;
            this.tabIva.Text = "P.Iva storico";
            this.tabIva.UseVisualStyleBackColor = true;
            // 
            // btnPIva
            // 
            this.btnPIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPIva.Location = new System.Drawing.Point(336, 419);
            this.btnPIva.Name = "btnPIva";
            this.btnPIva.Size = new System.Drawing.Size(316, 61);
            this.btnPIva.TabIndex = 69;
            this.btnPIva.Text = "Imposta per l\'anagrafica scelta le modalità selezionate (cancellando eventualment" +
    "e quelle esistenti)";
            this.btnPIva.UseVisualStyleBackColor = true;
            this.btnPIva.Click += new System.EventHandler(this.btnPIva_Click);
            // 
            // gridivastorico
            // 
            this.gridivastorico.AllowNavigation = false;
            this.gridivastorico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridivastorico.DataMember = "";
            this.gridivastorico.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridivastorico.Location = new System.Drawing.Point(8, 13);
            this.gridivastorico.Name = "gridivastorico";
            this.gridivastorico.ReadOnly = true;
            this.gridivastorico.Size = new System.Drawing.Size(936, 400);
            this.gridivastorico.TabIndex = 68;
            this.gridivastorico.Tag = "registrymainview.anagrafica";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(627, 534);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 69;
            this.button1.Text = "Annulla";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(267, 534);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(108, 23);
            this.btnOk.TabIndex = 70;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnRead
            // 
            this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRead.Location = new System.Drawing.Point(923, 534);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(109, 37);
            this.btnRead.TabIndex = 71;
            this.btnRead.Text = "Rileggi senza ottimizzare";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // frmUnisciInformazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 569);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabs);
            this.Name = "frmUnisciInformazioni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUnisciInformazioni";
            ((System.ComponentModel.ISupportInitialize)(this.gridmodpag)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabModPag.ResumeLayout(false);
            this.TabIndirizzi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridindirizzi)).EndInit();
            this.tabMissioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridposgiur)).EndInit();
            this.tabImponibile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridimponibile)).EndInit();
            this.tabReference.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridreference)).EndInit();
            this.tabCF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridcfstorico)).EndInit();
            this.tabIva.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridivastorico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid gridmodpag;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabModPag;
        private System.Windows.Forms.TabPage TabIndirizzi;
        private System.Windows.Forms.Button btnImpostaModPagamento;
        private System.Windows.Forms.TabPage tabMissioni;
        private System.Windows.Forms.TabPage tabReference;
        private System.Windows.Forms.TabPage tabCF;
        private System.Windows.Forms.TabPage tabIva;
        private System.Windows.Forms.DataGrid gridindirizzi;
        private System.Windows.Forms.DataGrid gridposgiur;
        private System.Windows.Forms.DataGrid gridreference;
        private System.Windows.Forms.DataGrid gridcfstorico;
        private System.Windows.Forms.DataGrid gridivastorico;
        private System.Windows.Forms.Button btnImpostaIndirizzi;
        private System.Windows.Forms.Button btnImpostaPosGiur;
        private System.Windows.Forms.Button btnContatti;
        private System.Windows.Forms.Button btnCF;
        private System.Windows.Forms.Button btnPIva;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabPage tabImponibile;
        private System.Windows.Forms.Button btnImponibile;
        private System.Windows.Forms.DataGrid gridimponibile;
        private System.Windows.Forms.Button btnChangeRegModeCode;
        private System.Windows.Forms.Button btnRead;
    }
}
