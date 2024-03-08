
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


namespace invoice_default {
    partial class FrmCreaDaParcellaFE {
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
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnImportaTuttaFESenzaAssociazione = new System.Windows.Forms.Button();
			this.btnEseguiAssociazione = new System.Windows.Forms.Button();
			this.lblTitoloGridCP = new System.Windows.Forms.Label();
			this.dgrParcella = new System.Windows.Forms.DataGrid();
			this.dgrDettagliFE = new System.Windows.Forms.DataGrid();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgrParcella)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFE)).BeginInit();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 33);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(334, 13);
			this.label5.TabIndex = 52;
			this.label5.Text = "importare la Fattura Elettronica senza effettuare alcuna associazione. ";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(448, 13);
			this.label4.TabIndex = 51;
			this.label4.Text = "Scegliere quale Parcella professionale dovrà essere associata alla Fattura Elettr" +
    "onica, oppure,";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnImportaTuttaFESenzaAssociazione
			// 
			this.btnImportaTuttaFESenzaAssociazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImportaTuttaFESenzaAssociazione.Location = new System.Drawing.Point(340, 517);
			this.btnImportaTuttaFESenzaAssociazione.Name = "btnImportaTuttaFESenzaAssociazione";
			this.btnImportaTuttaFESenzaAssociazione.Size = new System.Drawing.Size(228, 36);
			this.btnImportaTuttaFESenzaAssociazione.TabIndex = 50;
			this.btnImportaTuttaFESenzaAssociazione.TabStop = false;
			this.btnImportaTuttaFESenzaAssociazione.Text = "Importa la FE, senza associarla ad alcuna Parcella";
			this.btnImportaTuttaFESenzaAssociazione.Click += new System.EventHandler(this.btnImportaTuttaFESenzaAssociazione_Click);
			// 
			// btnEseguiAssociazione
			// 
			this.btnEseguiAssociazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEseguiAssociazione.Location = new System.Drawing.Point(124, 517);
			this.btnEseguiAssociazione.Name = "btnEseguiAssociazione";
			this.btnEseguiAssociazione.Size = new System.Drawing.Size(122, 36);
			this.btnEseguiAssociazione.TabIndex = 47;
			this.btnEseguiAssociazione.TabStop = false;
			this.btnEseguiAssociazione.Text = "Esegui Associazione con la Parcella";
			this.btnEseguiAssociazione.Click += new System.EventHandler(this.btnEseguiAssociazione_Click);
			// 
			// lblTitoloGridCP
			// 
			this.lblTitoloGridCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitoloGridCP.Location = new System.Drawing.Point(7, 270);
			this.lblTitoloGridCP.Name = "lblTitoloGridCP";
			this.lblTitoloGridCP.Size = new System.Drawing.Size(512, 14);
			this.lblTitoloGridCP.TabIndex = 46;
			this.lblTitoloGridCP.Text = "Parcelle professionali";
			// 
			// dgrParcella
			// 
			this.dgrParcella.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrParcella.DataMember = "";
			this.dgrParcella.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrParcella.Location = new System.Drawing.Point(10, 287);
			this.dgrParcella.Name = "dgrParcella";
			this.dgrParcella.Size = new System.Drawing.Size(707, 205);
			this.dgrParcella.TabIndex = 45;
			this.dgrParcella.Tag = "";
			this.dgrParcella.Paint += new System.Windows.Forms.PaintEventHandler(this.dgrParcella_Paint);
			this.dgrParcella.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgrParcella_KeyUp);
			this.dgrParcella.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgrParcella_MouseUp);
			// 
			// dgrDettagliFE
			// 
			this.dgrDettagliFE.AllowNavigation = false;
			this.dgrDettagliFE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrDettagliFE.DataMember = "";
			this.dgrDettagliFE.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrDettagliFE.Location = new System.Drawing.Point(10, 81);
			this.dgrDettagliFE.Name = "dgrDettagliFE";
			this.dgrDettagliFE.Size = new System.Drawing.Size(707, 166);
			this.dgrDettagliFE.TabIndex = 44;
			this.dgrDettagliFE.Tag = "";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(635, 584);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 43;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Enabled = false;
			this.btnOk.Location = new System.Drawing.Point(541, 584);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 42;
			this.btnOk.Text = "Ok";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(304, 16);
			this.label1.TabIndex = 41;
			this.label1.Text = "Dettagli Fattura contenuti nella Fattura Elettronica";
			// 
			// FrmCreaDaParcellaFE
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 619);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnImportaTuttaFESenzaAssociazione);
			this.Controls.Add(this.btnEseguiAssociazione);
			this.Controls.Add(this.lblTitoloGridCP);
			this.Controls.Add(this.dgrParcella);
			this.Controls.Add(this.dgrDettagliFE);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.label1);
			this.Name = "FrmCreaDaParcellaFE";
			this.Text = "Associazione Fattura Elettronica con Parcella Professionale";
			((System.ComponentModel.ISupportInitialize)(this.dgrParcella)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFE)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImportaTuttaFESenzaAssociazione;
        private System.Windows.Forms.Button btnEseguiAssociazione;
        private System.Windows.Forms.Label lblTitoloGridCP;
        private System.Windows.Forms.DataGrid dgrParcella;
        private System.Windows.Forms.DataGrid dgrDettagliFE;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
    }
}
