
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


namespace storeunload_default {
    partial class frmstoreunload_default {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtYddt = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataBolla = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCausale = new System.Windows.Forms.ComboBox();
            this.DS = new storeunload_default.vistaForm();
            this.griddetail = new System.Windows.Forms.DataGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.gBoxFornitore = new System.Windows.Forms.GroupBox();
            this.btnAggiungiDaPrenotazione = new System.Windows.Forms.Button();
            this.btnAggiungiDaMagazzino = new System.Windows.Forms.Button();
            this.cmbMagazzino = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAutorizzazione = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labEPnongenerato = new System.Windows.Forms.Label();
            this.btnVisualizzaEP = new System.Windows.Forms.Button();
            this.labEPgenerato = new System.Windows.Forms.Label();
            this.btnScarichiImmediati = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.griddetail)).BeginInit();
            this.gBoxFornitore.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio";
            // 
            // txtYddt
            // 
            this.txtYddt.Location = new System.Drawing.Point(15, 25);
            this.txtYddt.Name = "txtYddt";
            this.txtYddt.Size = new System.Drawing.Size(69, 20);
            this.txtYddt.TabIndex = 1;
            this.txtYddt.Tag = "storeunload.ystoreunload.year";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(94, 25);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "storeunload.nstoreunload";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(582, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "storeunload.idstoreunload";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(652, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "#";
            // 
            // txtDataBolla
            // 
            this.txtDataBolla.Location = new System.Drawing.Point(229, 25);
            this.txtDataBolla.Name = "txtDataBolla";
            this.txtDataBolla.Size = new System.Drawing.Size(100, 20);
            this.txtDataBolla.TabIndex = 3;
            this.txtDataBolla.Tag = "storeunload.adate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data scarico";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Causale";
            // 
            // cmbCausale
            // 
            this.cmbCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCausale.DataSource = this.DS.storeunload_motive;
            this.cmbCausale.DisplayMember = "description";
            this.cmbCausale.FormattingEnabled = true;
            this.cmbCausale.Location = new System.Drawing.Point(368, 131);
            this.cmbCausale.Name = "cmbCausale";
            this.cmbCausale.Size = new System.Drawing.Size(295, 21);
            this.cmbCausale.TabIndex = 7;
            this.cmbCausale.Tag = "storeunload.idstoreunload_motive";
            this.cmbCausale.ValueMember = "idstoreunload_motive";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // griddetail
            // 
            this.griddetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.griddetail.DataMember = "";
            this.griddetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.griddetail.Location = new System.Drawing.Point(87, 35);
            this.griddetail.Name = "griddetail";
            this.griddetail.Size = new System.Drawing.Size(549, 161);
            this.griddetail.TabIndex = 17;
            this.griddetail.Tag = "storeunloaddetail.dettaglio.single";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Merce collegata";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 21);
            this.button2.TabIndex = 20;
            this.button2.Tag = "delete";
            this.button2.Text = "Rimuovi";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(6, 62);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 21);
            this.btnModifica.TabIndex = 21;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica..";
            this.btnModifica.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(15, 177);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(340, 44);
            this.textBox4.TabIndex = 8;
            this.textBox4.Tag = "storeunload.description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Descrizione";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(6, 19);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(328, 20);
            this.txtCredDeb.TabIndex = 9;
            this.txtCredDeb.Tag = "registry.title?x";
            // 
            // gBoxFornitore
            // 
            this.gBoxFornitore.Controls.Add(this.txtCredDeb);
            this.gBoxFornitore.Location = new System.Drawing.Point(15, 52);
            this.gBoxFornitore.Name = "gBoxFornitore";
            this.gBoxFornitore.Size = new System.Drawing.Size(340, 54);
            this.gBoxFornitore.TabIndex = 6;
            this.gBoxFornitore.TabStop = false;
            this.gBoxFornitore.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.gBoxFornitore.Text = "Fornitore per Reso";
            // 
            // btnAggiungiDaPrenotazione
            // 
            this.btnAggiungiDaPrenotazione.Location = new System.Drawing.Point(321, 6);
            this.btnAggiungiDaPrenotazione.Name = "btnAggiungiDaPrenotazione";
            this.btnAggiungiDaPrenotazione.Size = new System.Drawing.Size(157, 23);
            this.btnAggiungiDaPrenotazione.TabIndex = 22;
            this.btnAggiungiDaPrenotazione.Text = "Aggiungi da Prenotazione";
            this.btnAggiungiDaPrenotazione.UseVisualStyleBackColor = true;
            this.btnAggiungiDaPrenotazione.Click += new System.EventHandler(this.btnAggiungiDaPrenotazione_Click);
            // 
            // btnAggiungiDaMagazzino
            // 
            this.btnAggiungiDaMagazzino.Location = new System.Drawing.Point(484, 6);
            this.btnAggiungiDaMagazzino.Name = "btnAggiungiDaMagazzino";
            this.btnAggiungiDaMagazzino.Size = new System.Drawing.Size(149, 23);
            this.btnAggiungiDaMagazzino.TabIndex = 23;
            this.btnAggiungiDaMagazzino.Text = "Aggiungi da Magazzino";
            this.btnAggiungiDaMagazzino.UseVisualStyleBackColor = true;
            this.btnAggiungiDaMagazzino.Click += new System.EventHandler(this.btnAggiungiDaMagazzino_Click);
            // 
            // cmbMagazzino
            // 
            this.cmbMagazzino.DataSource = this.DS.store;
            this.cmbMagazzino.DisplayMember = "description";
            this.cmbMagazzino.FormattingEnabled = true;
            this.cmbMagazzino.Location = new System.Drawing.Point(15, 131);
            this.cmbMagazzino.Name = "cmbMagazzino";
            this.cmbMagazzino.Size = new System.Drawing.Size(340, 21);
            this.cmbMagazzino.TabIndex = 24;
            this.cmbMagazzino.Tag = "storeunload.idstore";
            this.cmbMagazzino.ValueMember = "idstore";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Magazzino";
            // 
            // lblAutorizzazione
            // 
            this.lblAutorizzazione.AutoSize = true;
            this.lblAutorizzazione.Location = new System.Drawing.Point(365, 177);
            this.lblAutorizzazione.Name = "lblAutorizzazione";
            this.lblAutorizzazione.Size = new System.Drawing.Size(0, 13);
            this.lblAutorizzazione.TabIndex = 26;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 227);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 225);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnScarichiImmediati);
            this.tabPage2.Controls.Add(this.btnAggiungiDaPrenotazione);
            this.tabPage2.Controls.Add(this.btnAggiungiDaMagazzino);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.griddetail);
            this.tabPage2.Controls.Add(this.btnModifica);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(639, 199);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Principale";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labEPnongenerato);
            this.tabPage1.Controls.Add(this.btnVisualizzaEP);
            this.tabPage1.Controls.Add(this.labEPgenerato);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(577, 199);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "E/P";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labEPnongenerato
            // 
            this.labEPnongenerato.Location = new System.Drawing.Point(20, 63);
            this.labEPnongenerato.Name = "labEPnongenerato";
            this.labEPnongenerato.Size = new System.Drawing.Size(352, 16);
            this.labEPnongenerato.TabIndex = 12;
            this.labEPnongenerato.Text = "Le scritture in partita doppia NON sono state ancora generate.";
            // 
            // btnVisualizzaEP
            // 
            this.btnVisualizzaEP.Location = new System.Drawing.Point(298, 10);
            this.btnVisualizzaEP.Name = "btnVisualizzaEP";
            this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEP.TabIndex = 6;
            this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
            this.btnVisualizzaEP.UseVisualStyleBackColor = true;
            this.btnVisualizzaEP.Click += new System.EventHandler(this.btnVisualizzaEP_Click);
            // 
            // labEPgenerato
            // 
            this.labEPgenerato.AutoSize = true;
            this.labEPgenerato.Location = new System.Drawing.Point(20, 20);
            this.labEPgenerato.Name = "labEPgenerato";
            this.labEPgenerato.Size = new System.Drawing.Size(237, 13);
            this.labEPgenerato.TabIndex = 4;
            this.labEPgenerato.Text = "Le scritture in partita doppia sono state generate.";
            // 
            // btnScarichiImmediati
            // 
            this.btnScarichiImmediati.Location = new System.Drawing.Point(116, 6);
            this.btnScarichiImmediati.Name = "btnScarichiImmediati";
            this.btnScarichiImmediati.Size = new System.Drawing.Size(170, 23);
            this.btnScarichiImmediati.TabIndex = 24;
            this.btnScarichiImmediati.Text = "Aggiungi scarichi immediati";
            this.btnScarichiImmediati.UseVisualStyleBackColor = true;
            this.btnScarichiImmediati.Click += new System.EventHandler(this.btnScarichiImmediati_Click);
            // 
            // frmstoreunload_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 461);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblAutorizzazione);
            this.Controls.Add(this.cmbMagazzino);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.cmbCausale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gBoxFornitore);
            this.Controls.Add(this.txtDataBolla);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtYddt);
            this.Controls.Add(this.label1);
            this.Name = "frmstoreunload_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmstoreunload_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.griddetail)).EndInit();
            this.gBoxFornitore.ResumeLayout(false);
            this.gBoxFornitore.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYddt;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataBolla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCausale;
        private System.Windows.Forms.DataGrid griddetail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnModifica;
        public vistaForm DS;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.GroupBox gBoxFornitore;
        private System.Windows.Forms.Button btnAggiungiDaPrenotazione;
        private System.Windows.Forms.Button btnAggiungiDaMagazzino;
        private System.Windows.Forms.ComboBox cmbMagazzino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAutorizzazione;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnVisualizzaEP;
        private System.Windows.Forms.Label labEPgenerato;
        private System.Windows.Forms.Label labEPnongenerato;
        private System.Windows.Forms.Button btnScarichiImmediati;
    }
}
