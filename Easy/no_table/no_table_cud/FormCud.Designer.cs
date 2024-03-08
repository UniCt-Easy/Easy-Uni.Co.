
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


namespace no_table_cud {
    partial class FormCud {
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
            this.btnGeneraCud = new System.Windows.Forms.Button();
            this.DS = new no_table_cud.vistaForm();
            this._folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtCartella = new System.Windows.Forms.TextBox();
            this.btnCartella = new System.Windows.Forms.Button();
            this.btnProblemi = new System.Windows.Forms.Button();
            this.btnPrestazioni = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneraCud
            // 
            this.btnGeneraCud.AutoSize = true;
            this.btnGeneraCud.Location = new System.Drawing.Point(230, 186);
            this.btnGeneraCud.Name = "btnGeneraCud";
            this.btnGeneraCud.Size = new System.Drawing.Size(136, 34);
            this.btnGeneraCud.TabIndex = 0;
            this.btnGeneraCud.Text = "Genera modelli Cud 2010";
            this.btnGeneraCud.UseVisualStyleBackColor = true;
            this.btnGeneraCud.Click += new System.EventHandler(this.btnGeneraCud_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtCartella
            // 
            this.txtCartella.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCartella.Location = new System.Drawing.Point(65, 12);
            this.txtCartella.Name = "txtCartella";
            this.txtCartella.ReadOnly = true;
            this.txtCartella.Size = new System.Drawing.Size(511, 20);
            this.txtCartella.TabIndex = 1;
            // 
            // btnCartella
            // 
            this.btnCartella.AutoSize = true;
            this.btnCartella.Location = new System.Drawing.Point(7, 10);
            this.btnCartella.Name = "btnCartella";
            this.btnCartella.Size = new System.Drawing.Size(52, 23);
            this.btnCartella.TabIndex = 2;
            this.btnCartella.Text = "Cartella";
            this.btnCartella.UseVisualStyleBackColor = true;
            this.btnCartella.Click += new System.EventHandler(this.btnCartella_Click);
            // 
            // btnProblemi
            // 
            this.btnProblemi.AutoSize = true;
            this.btnProblemi.Location = new System.Drawing.Point(182, 138);
            this.btnProblemi.Name = "btnProblemi";
            this.btnProblemi.Size = new System.Drawing.Size(237, 23);
            this.btnProblemi.TabIndex = 4;
            this.btnProblemi.Text = "Incoerenze nella configurazione per Cud e 770";
            this.btnProblemi.UseVisualStyleBackColor = true;
            this.btnProblemi.Click += new System.EventHandler(this.btnProblemi_Click);
            // 
            // btnPrestazioni
            // 
            this.btnPrestazioni.AutoSize = true;
            this.btnPrestazioni.Location = new System.Drawing.Point(171, 97);
            this.btnPrestazioni.Name = "btnPrestazioni";
            this.btnPrestazioni.Size = new System.Drawing.Size(254, 23);
            this.btnPrestazioni.TabIndex = 5;
            this.btnPrestazioni.Text = "Prestazioni configurate per essere inserite nel Cud";
            this.btnPrestazioni.UseVisualStyleBackColor = true;
            this.btnPrestazioni.Click += new System.EventHandler(this.btnPrestazioni_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 47);
            this.label1.TabIndex = 6;
            this.label1.Text = "Per fare in modo che una prestazione venga inserita nel modello Cud andare in \'Co" +
                "nfigurazione\\Compensi\\Imposte\\Tipo prestazione\' ed impostare \'Modello Cud\' come " +
                "\'Modello cert. fiscale\'";
            // 
            // FormCud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 252);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrestazioni);
            this.Controls.Add(this.btnProblemi);
            this.Controls.Add(this.btnCartella);
            this.Controls.Add(this.txtCartella);
            this.Controls.Add(this.btnGeneraCud);
            this.Name = "FormCud";
            this.Text = "FormCud";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeneraCud;
        public vistaForm DS;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtCartella;
        private System.Windows.Forms.Button btnCartella;
        private System.Windows.Forms.Button btnProblemi;
        private System.Windows.Forms.Button btnPrestazioni;
        private System.Windows.Forms.Label label1;
    }
}
