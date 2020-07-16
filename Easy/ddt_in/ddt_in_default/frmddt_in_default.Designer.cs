/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace ddt_in_default {
    partial class frmddt_in_default {
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
            this.txtDataBolla = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.gBoxFornitore = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCausale = new System.Windows.Forms.ComboBox();
            this.DS = new ddt_in_default.vistaForm();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMagazzino = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.griddetriten = new System.Windows.Forms.DataGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnAggiungiDaOrdini = new System.Windows.Forms.Button();
            this.cmbCausaleCarico = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gBoxFornitore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.griddetriten)).BeginInit();
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
            this.txtYddt.Tag = "ddt_in.yddt_in.year";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(94, 25);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "ddt_in.nddt_in";
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // txtDataBolla
            // 
            this.txtDataBolla.Location = new System.Drawing.Point(229, 25);
            this.txtDataBolla.Name = "txtDataBolla";
            this.txtDataBolla.Size = new System.Drawing.Size(100, 20);
            this.txtDataBolla.TabIndex = 3;
            this.txtDataBolla.Tag = "ddt_in.adate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data bolletta";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(6, 19);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(328, 20);
            this.txtCredDeb.TabIndex = 9;
            this.txtCredDeb.Tag = "registry.title?ddt_inview.registry";
            // 
            // gBoxFornitore
            // 
            this.gBoxFornitore.Controls.Add(this.txtCredDeb);
            this.gBoxFornitore.Location = new System.Drawing.Point(12, 98);
            this.gBoxFornitore.Name = "gBoxFornitore";
            this.gBoxFornitore.Size = new System.Drawing.Size(340, 54);
            this.gBoxFornitore.TabIndex = 6;
            this.gBoxFornitore.TabStop = false;
            this.gBoxFornitore.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.gBoxFornitore.Text = "Fornitore";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Causale";
            // 
            // cmbCausale
            // 
            this.cmbCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCausale.DataSource = this.DS.ddt_in_motive;
            this.cmbCausale.DisplayMember = "description";
            this.cmbCausale.FormattingEnabled = true;
            this.cmbCausale.Location = new System.Drawing.Point(361, 77);
            this.cmbCausale.Name = "cmbCausale";
            this.cmbCausale.Size = new System.Drawing.Size(330, 21);
            this.cmbCausale.TabIndex = 7;
            this.cmbCausale.Tag = "ddt_in.idddt_in_motive";
            this.cmbCausale.ValueMember = "idddt_in_motive";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(15, 171);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(676, 44);
            this.textBox4.TabIndex = 8;
            this.textBox4.Tag = "ddt_in.terms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Termini di consegna";
            // 
            // cmbMagazzino
            // 
            this.cmbMagazzino.DataSource = this.DS.store;
            this.cmbMagazzino.DisplayMember = "description";
            this.cmbMagazzino.FormattingEnabled = true;
            this.cmbMagazzino.Location = new System.Drawing.Point(21, 74);
            this.cmbMagazzino.Name = "cmbMagazzino";
            this.cmbMagazzino.Size = new System.Drawing.Size(330, 21);
            this.cmbMagazzino.TabIndex = 5;
            this.cmbMagazzino.Tag = "ddt_in.idstore";
            this.cmbMagazzino.ValueMember = "idstore";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Magazzino";
            // 
            // griddetriten
            // 
            this.griddetriten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.griddetriten.DataMember = "";
            this.griddetriten.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.griddetriten.Location = new System.Drawing.Point(94, 258);
            this.griddetriten.Name = "griddetriten";
            this.griddetriten.Size = new System.Drawing.Size(597, 188);
            this.griddetriten.TabIndex = 17;
            this.griddetriten.Tag = "stock.ddt_in.ddt_in";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Merce collegata";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Tag = "insert.ddt_in";
            this.button1.Text = "Aggiungi";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Tag = "delete";
            this.button2.Text = "Rimuovi";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(9, 304);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 21;
            this.btnModifica.Tag = "edit.ddt_in";
            this.btnModifica.Text = "Modifica..";
            this.btnModifica.UseVisualStyleBackColor = true;
            // 
            // btnAggiungiDaOrdini
            // 
            this.btnAggiungiDaOrdini.Location = new System.Drawing.Point(313, 229);
            this.btnAggiungiDaOrdini.Name = "btnAggiungiDaOrdini";
            this.btnAggiungiDaOrdini.Size = new System.Drawing.Size(149, 23);
            this.btnAggiungiDaOrdini.TabIndex = 22;
            this.btnAggiungiDaOrdini.Tag = "";
            this.btnAggiungiDaOrdini.Text = "Aggiungi da ordini";
            this.btnAggiungiDaOrdini.UseVisualStyleBackColor = true;
            this.btnAggiungiDaOrdini.Click += new System.EventHandler(this.btnAggiungiDaOrdini_Click);
            // 
            // cmbCausaleCarico
            // 
            this.cmbCausaleCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCausaleCarico.DataSource = this.DS.storeload_motive;
            this.cmbCausaleCarico.DisplayMember = "description";
            this.cmbCausaleCarico.Enabled = false;
            this.cmbCausaleCarico.FormattingEnabled = true;
            this.cmbCausaleCarico.Location = new System.Drawing.Point(361, 117);
            this.cmbCausaleCarico.Name = "cmbCausaleCarico";
            this.cmbCausaleCarico.Size = new System.Drawing.Size(330, 21);
            this.cmbCausaleCarico.TabIndex = 23;
            this.cmbCausaleCarico.Tag = "ddt_in.idstoreload_motive";
            this.cmbCausaleCarico.ValueMember = "idstoreload_motive";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(358, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Causale di Carico";
            // 
            // frmddt_in_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 458);
            this.Controls.Add(this.cmbCausaleCarico);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAggiungiDaOrdini);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.griddetriten);
            this.Controls.Add(this.cmbMagazzino);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.cmbCausale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gBoxFornitore);
            this.Controls.Add(this.txtDataBolla);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtYddt);
            this.Controls.Add(this.label1);
            this.Name = "frmddt_in_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmddt_in_default";
            this.gBoxFornitore.ResumeLayout(false);
            this.gBoxFornitore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.griddetriten)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYddt;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataBolla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.GroupBox gBoxFornitore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCausale;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMagazzino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGrid griddetriten;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnAggiungiDaOrdini;
        public vistaForm DS;
        private System.Windows.Forms.ComboBox cmbCausaleCarico;
        private System.Windows.Forms.Label label9;
    }
}