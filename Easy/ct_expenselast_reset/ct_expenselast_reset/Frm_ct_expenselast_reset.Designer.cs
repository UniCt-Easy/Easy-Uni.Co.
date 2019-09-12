/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿namespace ct_expenselast_reset {
    partial class Frm_ct_expenselast_reset {
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
            this.gridDettagli = new System.Windows.Forms.DataGrid();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAzzera = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.DS = new ct_expenselast_reset.vistaForm();
            this.chkEscludiContabilizzazioni = new System.Windows.Forms.CheckBox();
            this.btnMostraPagamenti = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDettagli
            // 
            this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDettagli.CaptionVisible = false;
            this.gridDettagli.DataMember = "";
            this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDettagli.Location = new System.Drawing.Point(12, 80);
            this.gridDettagli.Name = "gridDettagli";
            this.gridDettagli.Size = new System.Drawing.Size(715, 376);
            this.gridDettagli.TabIndex = 28;
            // 
            // btnSelezionaTutto
            // 
            this.btnSelezionaTutto.Location = new System.Drawing.Point(9, 49);
            this.btnSelezionaTutto.Name = "btnSelezionaTutto";
            this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
            this.btnSelezionaTutto.TabIndex = 32;
            this.btnSelezionaTutto.Text = "Seleziona tutto";
            this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(103, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(624, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più movimenti.";
            // 
            // btnAzzera
            // 
            this.btnAzzera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAzzera.Location = new System.Drawing.Point(530, 462);
            this.btnAzzera.Name = "btnAzzera";
            this.btnAzzera.Size = new System.Drawing.Size(80, 26);
            this.btnAzzera.TabIndex = 33;
            this.btnAzzera.Text = "Azzera";
            this.btnAzzera.UseVisualStyleBackColor = true;
            this.btnAzzera.Click += new System.EventHandler(this.btnAzzera_Click);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(631, 462);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 24);
            this.btnAnnulla.TabIndex = 34;
            this.btnAnnulla.Text = "Annulla";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // chkEscludiContabilizzazioni
            // 
            this.chkEscludiContabilizzazioni.AutoSize = true;
            this.chkEscludiContabilizzazioni.Location = new System.Drawing.Point(12, 12);
            this.chkEscludiContabilizzazioni.Name = "chkEscludiContabilizzazioni";
            this.chkEscludiContabilizzazioni.Size = new System.Drawing.Size(239, 17);
            this.chkEscludiContabilizzazioni.TabIndex = 35;
            this.chkEscludiContabilizzazioni.Text = "Escludi pagamenti che contabilizzano Fatture";
            this.chkEscludiContabilizzazioni.UseVisualStyleBackColor = true;
            this.chkEscludiContabilizzazioni.CheckedChanged += new System.EventHandler(this.chkEscludiContabilizzazioni_CheckedChanged);
            // 
            // btnMostraPagamenti
            // 
            this.btnMostraPagamenti.Location = new System.Drawing.Point(285, 6);
            this.btnMostraPagamenti.Name = "btnMostraPagamenti";
            this.btnMostraPagamenti.Size = new System.Drawing.Size(213, 23);
            this.btnMostraPagamenti.TabIndex = 36;
            this.btnMostraPagamenti.Text = "Mostra elenco pagamenti";
            this.btnMostraPagamenti.Click += new System.EventHandler(this.btnMostraPagamenti_Click);
            // 
            // Frm_ct_expenselast_reset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 498);
            this.Controls.Add(this.btnMostraPagamenti);
            this.Controls.Add(this.chkEscludiContabilizzazioni);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnAzzera);
            this.Controls.Add(this.btnSelezionaTutto);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.gridDettagli);
            this.Name = "Frm_ct_expenselast_reset";
            this.Text = "Frm_ct_expenselast_reset";
            ((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.DataGrid gridDettagli;
        private System.Windows.Forms.Button btnSelezionaTutto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAzzera;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.CheckBox chkEscludiContabilizzazioni;
        private System.Windows.Forms.Button btnMostraPagamenti;

    }
}