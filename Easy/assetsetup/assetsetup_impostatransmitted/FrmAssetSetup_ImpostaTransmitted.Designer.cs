
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


namespace assetsetup_impostatransmitted {
    partial class FrmAssetSetup_ImpostaTransmitted {
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
            this.cmbEnte = new System.Windows.Forms.ComboBox();
            this.DS = new assetsetup_impostatransmitted.vistaForm();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercizioInizio = new System.Windows.Forms.TextBox();
            this.txtEsercizioFine = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ente Inventariale:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbEnte
            // 
            this.cmbEnte.DataSource = this.DS.inventoryagency;
            this.cmbEnte.DisplayMember = "description";
            this.cmbEnte.FormattingEnabled = true;
            this.cmbEnte.Location = new System.Drawing.Point(15, 35);
            this.cmbEnte.Name = "cmbEnte";
            this.cmbEnte.Size = new System.Drawing.Size(431, 21);
            this.cmbEnte.TabIndex = 1;
            this.cmbEnte.ValueMember = "idinventoryagency";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Esercizio Inizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(346, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Esercizio Fine:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtEsercizioInizio
            // 
            this.txtEsercizioInizio.Location = new System.Drawing.Point(24, 119);
            this.txtEsercizioInizio.Name = "txtEsercizioInizio";
            this.txtEsercizioInizio.Size = new System.Drawing.Size(100, 20);
            this.txtEsercizioInizio.TabIndex = 4;
            this.txtEsercizioInizio.Leave += new System.EventHandler(this.txtEsercizioInizio_Leave);
            // 
            // txtEsercizioFine
            // 
            this.txtEsercizioFine.Location = new System.Drawing.Point(348, 118);
            this.txtEsercizioFine.Name = "txtEsercizioFine";
            this.txtEsercizioFine.Size = new System.Drawing.Size(100, 20);
            this.txtEsercizioFine.TabIndex = 5;
            this.txtEsercizioFine.Leave += new System.EventHandler(this.txtEsercizioFine_Leave);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(186, 161);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FrmAssetSetup_ImpostaTransmitted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 212);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtEsercizioFine);
            this.Controls.Add(this.txtEsercizioInizio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEnte);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmAssetSetup_ImpostaTransmitted";
            this.Text = "FrmAssetSetup_ImpostaTransmitted";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEnte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercizioInizio;
        private System.Windows.Forms.TextBox txtEsercizioFine;
        private System.Windows.Forms.Button btnStart;
        public vistaForm DS;
    }
}
