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

namespace no_table_entry_rettifica {
    partial class Frmno_table_entry_rettifica {
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
			this.DS = new no_table_entry_rettifica.vistaForm();
			this.btnOperazione = new System.Windows.Forms.Button();
			this.labelDescrizione = new System.Windows.Forms.Label();
			this.chkCommerciale = new System.Windows.Forms.CheckBox();
			this.progBar = new System.Windows.Forms.ProgressBar();
			this.txtCurrent = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.labelFase = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// btnOperazione
			// 
			this.btnOperazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOperazione.Location = new System.Drawing.Point(357, 106);
			this.btnOperazione.Name = "btnOperazione";
			this.btnOperazione.Size = new System.Drawing.Size(147, 23);
			this.btnOperazione.TabIndex = 3;
			this.btnOperazione.Text = "Inizia";
			this.btnOperazione.UseVisualStyleBackColor = true;
			this.btnOperazione.Click += new System.EventHandler(this.btnRettifica_Click);
			// 
			// labelDescrizione
			// 
			this.labelDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDescrizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDescrizione.Location = new System.Drawing.Point(12, 9);
			this.labelDescrizione.Name = "labelDescrizione";
			this.labelDescrizione.Size = new System.Drawing.Size(842, 46);
			this.labelDescrizione.TabIndex = 2;
			this.labelDescrizione.Text = "Procedura che consente l\'integrazione dei Risconti precedentemente rettificati e " +
    "la chiusura dei Ratei da Percentuale di completamento";
			this.labelDescrizione.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// chkCommerciale
			// 
			this.chkCommerciale.AutoSize = true;
			this.chkCommerciale.Location = new System.Drawing.Point(15, 73);
			this.chkCommerciale.Name = "chkCommerciale";
			this.chkCommerciale.Size = new System.Drawing.Size(204, 17);
			this.chkCommerciale.TabIndex = 5;
			this.chkCommerciale.Text = "Assumi Anno commerciale (360 giorni)";
			this.chkCommerciale.UseVisualStyleBackColor = true;
			// 
			// progBar
			// 
			this.progBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progBar.Location = new System.Drawing.Point(12, 182);
			this.progBar.Name = "progBar";
			this.progBar.Size = new System.Drawing.Size(842, 23);
			this.progBar.TabIndex = 6;
			// 
			// txtCurrent
			// 
			this.txtCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCurrent.Location = new System.Drawing.Point(108, 159);
			this.txtCurrent.Name = "txtCurrent";
			this.txtCurrent.ReadOnly = true;
			this.txtCurrent.Size = new System.Drawing.Size(746, 20);
			this.txtCurrent.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 166);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Oggetto corrente:";
			// 
			// labelFase
			// 
			this.labelFase.Location = new System.Drawing.Point(12, 135);
			this.labelFase.Name = "labelFase";
			this.labelFase.Size = new System.Drawing.Size(492, 23);
			this.labelFase.TabIndex = 9;
			// 
			// Frmno_table_entry_rettifica
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(866, 215);
			this.Controls.Add(this.labelFase);
			this.Controls.Add(this.txtCurrent);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.progBar);
			this.Controls.Add(this.chkCommerciale);
			this.Controls.Add(this.btnOperazione);
			this.Controls.Add(this.labelDescrizione);
			this.Name = "Frmno_table_entry_rettifica";
			this.Text = "Frmno_table_entry_rettifica";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnOperazione;
        private System.Windows.Forms.Label labelDescrizione;
        private System.Windows.Forms.CheckBox chkCommerciale;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelFase;
    }
}