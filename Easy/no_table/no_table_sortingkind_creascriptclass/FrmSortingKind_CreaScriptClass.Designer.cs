
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


namespace no_table_sortingkind_creascriptclass {
    partial class Frmno_table_sortingkind_creascriptclass {
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
            this.btnInstall = new System.Windows.Forms.Button();
            this.txtTipoClass = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DS = new no_table_sortingkind_creascriptclass.vistaForm();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblFile = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDati = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(455, 13);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(110, 41);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "Genera Script";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // txtTipoClass
            // 
            this.txtTipoClass.Location = new System.Drawing.Point(106, 13);
            this.txtTipoClass.Name = "txtTipoClass";
            this.txtTipoClass.Size = new System.Drawing.Size(292, 20);
            this.txtTipoClass.TabIndex = 3;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(106, 46);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(292, 20);
            this.txtDescrizione.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descrizione";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFile
            // 
            this.lblFile.Location = new System.Drawing.Point(6, 90);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(392, 23);
            this.lblFile.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInstall);
            this.groupBox1.Controls.Add(this.lblFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTipoClass);
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 130);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fase 1: Classificazione sulla Classificazione Inventariale";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnDati);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 64);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fase 2: Classificazione Inventariale";
            // 
            // btnDati
            // 
            this.btnDati.Location = new System.Drawing.Point(455, 18);
            this.btnDati.Name = "btnDati";
            this.btnDati.Size = new System.Drawing.Size(110, 39);
            this.btnDati.TabIndex = 0;
            this.btnDati.Text = "Genera Dati";
            this.btnDati.UseVisualStyleBackColor = true;
            this.btnDati.Click += new System.EventHandler(this.btnDati_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(443, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Questa fase serve per generare lo script dei dati della classificazione inventari" +
                "ale che sarà uniforme per tutti i dipartimenti";
            // 
            // Frmno_table_sortingkind_creascriptclass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 217);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frmno_table_sortingkind_creascriptclass";
            this.Text = "Frmno_table_sortingkind_creascriptclass";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.TextBox txtTipoClass;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label2;
        public vistaForm DS;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDati;
    }
}
