
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


namespace no_table_fill_unifiedtax {
    partial class FrmFillUnifiedTax {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
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
        private void InitializeComponent () {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFillUnifiedClawback = new System.Windows.Forms.Button();
            this.txtDataRiferimento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.labelEsercizio = new System.Windows.Forms.Label();
            this.btnFillExpensetax = new System.Windows.Forms.Button();
            this.DS = new no_table_fill_unifiedtax.vistaForm();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnFillUnifiedClawback);
            this.groupBox1.Controls.Add(this.txtDataRiferimento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.labelEsercizio);
            this.groupBox1.Controls.Add(this.btnFillExpensetax);
            this.groupBox1.Location = new System.Drawing.Point(12, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(878, 159);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnFillUnifiedClawback
            // 
            this.btnFillUnifiedClawback.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFillUnifiedClawback.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFillUnifiedClawback.Location = new System.Drawing.Point(192, 86);
            this.btnFillUnifiedClawback.Name = "btnFillUnifiedClawback";
            this.btnFillUnifiedClawback.Size = new System.Drawing.Size(667, 45);
            this.btnFillUnifiedClawback.TabIndex = 10;
            this.btnFillUnifiedClawback.Text = "Raccogli Recuperi Interventi Sostitutivi  dai Dipartimenti";
            this.btnFillUnifiedClawback.UseVisualStyleBackColor = true;
            this.btnFillUnifiedClawback.Click += new System.EventHandler(this.btnFillUnifiedClawback_Click);
            // 
            // txtDataRiferimento
            // 
            this.txtDataRiferimento.BackColor = System.Drawing.SystemColors.Window;
            this.txtDataRiferimento.Location = new System.Drawing.Point(32, 86);
            this.txtDataRiferimento.Name = "txtDataRiferimento";
            this.txtDataRiferimento.Size = new System.Drawing.Size(104, 20);
            this.txtDataRiferimento.TabIndex = 9;
            this.txtDataRiferimento.Tag = "";
            this.txtDataRiferimento.Leave += new System.EventHandler(this.txtDataRiferimento_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Data di riferimento";
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.BackColor = System.Drawing.SystemColors.Window;
            this.txtEsercizio.Location = new System.Drawing.Point(32, 42);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(72, 20);
            this.txtEsercizio.TabIndex = 7;
            this.txtEsercizio.Tag = "";
            this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
            // 
            // labelEsercizio
            // 
            this.labelEsercizio.AutoSize = true;
            this.labelEsercizio.Location = new System.Drawing.Point(29, 26);
            this.labelEsercizio.Name = "labelEsercizio";
            this.labelEsercizio.Size = new System.Drawing.Size(49, 13);
            this.labelEsercizio.TabIndex = 6;
            this.labelEsercizio.Text = "Esercizio";
            // 
            // btnFillExpensetax
            // 
            this.btnFillExpensetax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFillExpensetax.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFillExpensetax.Location = new System.Drawing.Point(192, 17);
            this.btnFillExpensetax.Name = "btnFillExpensetax";
            this.btnFillExpensetax.Size = new System.Drawing.Size(667, 45);
            this.btnFillExpensetax.TabIndex = 1;
            this.btnFillExpensetax.Text = "Raccogli Dettagli Ritenute dai Dipartimenti";
            this.btnFillExpensetax.UseVisualStyleBackColor = true;
            this.btnFillExpensetax.Click += new System.EventHandler(this.btnFillExpensetax_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(719, 360);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(815, 360);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 8;
            this.btnAnnulla.Text = "Annulla";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(878, 180);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(30, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(844, 28);
            this.label5.TabIndex = 7;
            this.label5.Text = "Dopo l\'inserimento nella tabella centralizzata, tali dati non saranno più modific" +
    "abili.";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(29, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(844, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "La procedura consente di raccogliere anche  i Recuperi per Interventi Sostitutivi" +
    " che l\'Ente deve effettuare.";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(843, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "N.B. Verranno considerate quindi, tutte le ritenute e correzioni, applicate anche" +
    " se non già liquidate purché non ancora consolidate.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(29, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(844, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "La procedura inserisce in tabelle centralizzate i dati delle ritenute di tutti i " +
    "dipartimenti, al fine di consentire la creazione di un F24EP  da parte dell\'Ammi" +
    "nstrazione Centrale";
            // 
            // FrmFillUnifiedTax
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFillExpensetax;
            this.ClientSize = new System.Drawing.Size(902, 400);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmFillUnifiedTax";
            this.Text = "Consolidamento Ritenute per F24EP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFillExpensetax;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label labelEsercizio;
        private System.Windows.Forms.TextBox txtDataRiferimento;
        private System.Windows.Forms.Label label1;
        public vistaForm DS;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFillUnifiedClawback;
        private System.Windows.Forms.Label label5;
    }
}
