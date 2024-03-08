
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


namespace no_table_entry_rateo {
    partial class FrmNoTable_entry_rateo {
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
            this.chkCommerciale = new System.Windows.Forms.CheckBox();
            this.btnGenera = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new no_table_entry_rateo.vistaForm();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // chkCommerciale
            // 
            this.chkCommerciale.AutoSize = true;
            this.chkCommerciale.Location = new System.Drawing.Point(12, 105);
            this.chkCommerciale.Name = "chkCommerciale";
            this.chkCommerciale.Size = new System.Drawing.Size(204, 17);
            this.chkCommerciale.TabIndex = 8;
            this.chkCommerciale.Text = "Assumi Anno commerciale (360 giorni)";
            this.chkCommerciale.UseVisualStyleBackColor = true;
            // 
            // btnGenera
            // 
            this.btnGenera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenera.Location = new System.Drawing.Point(560, 99);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(125, 23);
            this.btnGenera.TabIndex = 7;
            this.btnGenera.Text = "Inizia Generazione";
            this.btnGenera.UseVisualStyleBackColor = true;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(673, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "PROCEDURA CHE GENERA LE SCRITTURE AUTOMATICHE DI RATEO E DI FATTURE DA RICEVERE/E" +
    "METTERE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(651, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ATTENZIONE! Per il calcolo automatico delle fatture da ricevere verranno consider" +
    "ati solo i dettagli di contratti passivi successivi al 2016";
            // 
            // FrmNoTable_entry_rateo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 196);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkCommerciale);
            this.Controls.Add(this.btnGenera);
            this.Controls.Add(this.label1);
            this.Name = "FrmNoTable_entry_rateo";
            this.Text = "alias RATEI E FATTURE DA RICEVERE";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCommerciale;
        private System.Windows.Forms.Button btnGenera;
        private System.Windows.Forms.Label label1;
        public vistaForm DS;
        private System.Windows.Forms.Label label2;
    }
}
