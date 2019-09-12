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

ï»¿namespace emens_multidip {
    partial class FrmEmensMultiDip {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgRitenuta = new System.Windows.Forms.DataGrid();
            this.dgPrestazione = new System.Windows.Forms.DataGrid();
            this.txtAnno = new System.Windows.Forms.TextBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApriFile = new System.Windows.Forms.Button();
            this.grpDatiMittente = new System.Windows.Forms.GroupBox();
            this.txtCFSoftwarehouse = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCFMittente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRagSocMittente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCFPersonaMittente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGeneraEmens = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgRitenuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrestazione)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpDatiMittente.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(22, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 16);
            this.label11.TabIndex = 38;
            this.label11.Text = "Ritenute Considerate:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(22, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 16);
            this.label10.TabIndex = 37;
            this.label10.Text = "Prestazioni Considerate:";
            // 
            // dgRitenuta
            // 
            this.dgRitenuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRitenuta.DataMember = "";
            this.dgRitenuta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRitenuta.Location = new System.Drawing.Point(22, 211);
            this.dgRitenuta.Name = "dgRitenuta";
            this.dgRitenuta.Size = new System.Drawing.Size(624, 112);
            this.dgRitenuta.TabIndex = 36;
            // 
            // dgPrestazione
            // 
            this.dgPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPrestazione.DataMember = "";
            this.dgPrestazione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPrestazione.Location = new System.Drawing.Point(22, 347);
            this.dgPrestazione.Name = "dgPrestazione";
            this.dgPrestazione.Size = new System.Drawing.Size(624, 128);
            this.dgPrestazione.TabIndex = 35;
            // 
            // txtAnno
            // 
            this.txtAnno.Location = new System.Drawing.Point(206, 19);
            this.txtAnno.Name = "txtAnno";
            this.txtAnno.Size = new System.Drawing.Size(40, 20);
            this.txtAnno.TabIndex = 26;
            this.txtAnno.Tag = "emens.yearnumber.year";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(94, 19);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(72, 20);
            this.txtDataContabile.TabIndex = 25;
            this.txtDataContabile.Tag = "emens.adate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(22, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 56);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mesi di inizio e fine";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(32, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Tag = "emens.startmonth";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Da";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(32, 20);
            this.textBox2.TabIndex = 17;
            this.textBox2.Tag = "emens.stopmonth";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(72, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "A";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(174, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Anno";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Data contabile";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnApriFile
            // 
            this.btnApriFile.Location = new System.Drawing.Point(30, 155);
            this.btnApriFile.Name = "btnApriFile";
            this.btnApriFile.Size = new System.Drawing.Size(128, 23);
            this.btnApriFile.TabIndex = 31;
            this.btnApriFile.Text = "Vedi Risultato";
            // 
            // grpDatiMittente
            // 
            this.grpDatiMittente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDatiMittente.Controls.Add(this.txtCFSoftwarehouse);
            this.grpDatiMittente.Controls.Add(this.label6);
            this.grpDatiMittente.Controls.Add(this.txtCFMittente);
            this.grpDatiMittente.Controls.Add(this.label5);
            this.grpDatiMittente.Controls.Add(this.txtRagSocMittente);
            this.grpDatiMittente.Controls.Add(this.label4);
            this.grpDatiMittente.Controls.Add(this.txtCFPersonaMittente);
            this.grpDatiMittente.Controls.Add(this.label3);
            this.grpDatiMittente.Location = new System.Drawing.Point(174, 51);
            this.grpDatiMittente.Name = "grpDatiMittente";
            this.grpDatiMittente.Size = new System.Drawing.Size(472, 152);
            this.grpDatiMittente.TabIndex = 30;
            this.grpDatiMittente.TabStop = false;
            this.grpDatiMittente.Text = "Dati mittente";
            // 
            // txtCFSoftwarehouse
            // 
            this.txtCFSoftwarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCFSoftwarehouse.Location = new System.Drawing.Point(112, 120);
            this.txtCFSoftwarehouse.Name = "txtCFSoftwarehouse";
            this.txtCFSoftwarehouse.Size = new System.Drawing.Size(352, 20);
            this.txtCFSoftwarehouse.TabIndex = 14;
            this.txtCFSoftwarehouse.TabStop = false;
            this.txtCFSoftwarehouse.Tag = "emens.cfsoftwarehouse";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "C.F. Softwarehouse";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCFMittente
            // 
            this.txtCFMittente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCFMittente.Location = new System.Drawing.Point(112, 88);
            this.txtCFMittente.Name = "txtCFMittente";
            this.txtCFMittente.Size = new System.Drawing.Size(352, 20);
            this.txtCFMittente.TabIndex = 12;
            this.txtCFMittente.TabStop = false;
            this.txtCFMittente.Tag = "emens.cfsender";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "C.F. Mittente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRagSocMittente
            // 
            this.txtRagSocMittente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRagSocMittente.Location = new System.Drawing.Point(112, 56);
            this.txtRagSocMittente.Name = "txtRagSocMittente";
            this.txtRagSocMittente.Size = new System.Drawing.Size(352, 20);
            this.txtRagSocMittente.TabIndex = 10;
            this.txtRagSocMittente.TabStop = false;
            this.txtRagSocMittente.Tag = "emens.sendercompanyname";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rag. Soc. Mittente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCFPersonaMittente
            // 
            this.txtCFPersonaMittente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCFPersonaMittente.Location = new System.Drawing.Point(112, 24);
            this.txtCFPersonaMittente.Name = "txtCFPersonaMittente";
            this.txtCFPersonaMittente.Size = new System.Drawing.Size(352, 20);
            this.txtCFPersonaMittente.TabIndex = 8;
            this.txtCFPersonaMittente.TabStop = false;
            this.txtCFPersonaMittente.Tag = "emens.cfhumansender";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "C.F. Persona Mittente";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGeneraEmens
            // 
            this.btnGeneraEmens.Location = new System.Drawing.Point(30, 123);
            this.btnGeneraEmens.Name = "btnGeneraEmens";
            this.btnGeneraEmens.Size = new System.Drawing.Size(128, 23);
            this.btnGeneraEmens.TabIndex = 29;
            this.btnGeneraEmens.Text = "Genera E-Mens";
            this.btnGeneraEmens.Click += new System.EventHandler(this.btnGeneraEmens_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DisplayMember = "title";
            this.comboBox1.Location = new System.Drawing.Point(318, 19);
            this.comboBox1.MaxDropDownItems = 40;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(328, 21);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.Tag = "emens.inpscenter";
            this.comboBox1.ValueMember = "idinpscenter";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(254, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "Sede INPS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmEmensMultiDip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 495);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgRitenuta);
            this.Controls.Add(this.dgPrestazione);
            this.Controls.Add(this.txtAnno);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnApriFile);
            this.Controls.Add(this.grpDatiMittente);
            this.Controls.Add(this.btnGeneraEmens);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Name = "FrmEmensMultiDip";
            this.Text = "FrmEmensMultiDip";
            ((System.ComponentModel.ISupportInitialize)(this.dgRitenuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrestazione)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpDatiMittente.ResumeLayout(false);
            this.grpDatiMittente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGrid dgRitenuta;
        private System.Windows.Forms.DataGrid dgPrestazione;
        private System.Windows.Forms.TextBox txtAnno;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApriFile;
        private System.Windows.Forms.GroupBox grpDatiMittente;
        private System.Windows.Forms.TextBox txtCFSoftwarehouse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCFMittente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRagSocMittente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCFPersonaMittente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGeneraEmens;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
    }
}