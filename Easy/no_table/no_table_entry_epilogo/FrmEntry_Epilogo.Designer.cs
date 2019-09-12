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

namespace no_table_entry_epilogo {
    partial class Frmno_table_entry_epilogo {
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
            this.btnEpilogoEconomico = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new no_table_entry_epilogo.vistaForm();
            this.btnEpilogoStatoPatrimoniale = new System.Windows.Forms.Button();
            this.btnRisultatoEconomico = new System.Windows.Forms.Button();
            this.labAllDone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEpilogoEconomico
            // 
            this.btnEpilogoEconomico.Location = new System.Drawing.Point(156, 58);
            this.btnEpilogoEconomico.Name = "btnEpilogoEconomico";
            this.btnEpilogoEconomico.Size = new System.Drawing.Size(179, 23);
            this.btnEpilogoEconomico.TabIndex = 3;
            this.btnEpilogoEconomico.Text = "Epilogo conto economico";
            this.btnEpilogoEconomico.UseVisualStyleBackColor = true;
            this.btnEpilogoEconomico.Click += new System.EventHandler(this.btnEpilogo_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "PROCEDURA CHE EFFETTUA L\'EPILOGO DELLE SCRITTURE PER L\'ESERCIZIO IN CORSO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnEpilogoStatoPatrimoniale
            // 
            this.btnEpilogoStatoPatrimoniale.Location = new System.Drawing.Point(156, 160);
            this.btnEpilogoStatoPatrimoniale.Name = "btnEpilogoStatoPatrimoniale";
            this.btnEpilogoStatoPatrimoniale.Size = new System.Drawing.Size(179, 23);
            this.btnEpilogoStatoPatrimoniale.TabIndex = 8;
            this.btnEpilogoStatoPatrimoniale.Text = "Epilogo stato patrimoniale";
            this.btnEpilogoStatoPatrimoniale.UseVisualStyleBackColor = true;
            this.btnEpilogoStatoPatrimoniale.Click += new System.EventHandler(this.btnEpilogoStatoPatrimoniale_Click);
            // 
            // btnRisultatoEconomico
            // 
            this.btnRisultatoEconomico.Location = new System.Drawing.Point(156, 107);
            this.btnRisultatoEconomico.Name = "btnRisultatoEconomico";
            this.btnRisultatoEconomico.Size = new System.Drawing.Size(179, 23);
            this.btnRisultatoEconomico.TabIndex = 9;
            this.btnRisultatoEconomico.Text = "Rilevazione risultato economico";
            this.btnRisultatoEconomico.UseVisualStyleBackColor = true;
            this.btnRisultatoEconomico.Click += new System.EventHandler(this.btnRisultatoEconomico_Click);
            // 
            // labAllDone
            // 
            this.labAllDone.AutoSize = true;
            this.labAllDone.Location = new System.Drawing.Point(121, 133);
            this.labAllDone.Name = "labAllDone";
            this.labAllDone.Size = new System.Drawing.Size(248, 13);
            this.labAllDone.TabIndex = 10;
            this.labAllDone.Text = "Tutte le operazioni di chiusura sono state effettuate";
            this.labAllDone.Visible = false;
            // 
            // Frmno_table_entry_epilogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 226);
            this.Controls.Add(this.labAllDone);
            this.Controls.Add(this.btnRisultatoEconomico);
            this.Controls.Add(this.btnEpilogoStatoPatrimoniale);
            this.Controls.Add(this.btnEpilogoEconomico);
            this.Controls.Add(this.label1);
            this.Name = "Frmno_table_entry_epilogo";
            this.Text = "Frmno_table_entry_epilogo";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEpilogoEconomico;
        private System.Windows.Forms.Label label1;
        public vistaForm DS;
        private System.Windows.Forms.Button btnEpilogoStatoPatrimoniale;
        private System.Windows.Forms.Button btnRisultatoEconomico;
        private System.Windows.Forms.Label labAllDone;
    }
}