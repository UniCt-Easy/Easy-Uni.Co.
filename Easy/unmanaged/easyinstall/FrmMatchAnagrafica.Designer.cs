
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


namespace EasyInstall {
    partial class FrmMatchAnagrafica {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotSource = new System.Windows.Forms.TextBox();
            this.txtTotDitte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotPersone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotEnti = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotComplementari = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEsaminateComm = new System.Windows.Forms.TextBox();
            this.txtEsaminateComplementari = new System.Windows.Forms.TextBox();
            this.txtEsaminateTotali = new System.Windows.Forms.TextBox();
            this.txtEsaminatePersone = new System.Windows.Forms.TextBox();
            this.txtEsaminateEnti = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPresentiComm = new System.Windows.Forms.TextBox();
            this.txtPresentiComplementari = new System.Windows.Forms.TextBox();
            this.txtPresentiTotali = new System.Windows.Forms.TextBox();
            this.txtPresentiPersone = new System.Windows.Forms.TextBox();
            this.txtPresentiEnti = new System.Windows.Forms.TextBox();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Totale Anagrafiche";
            // 
            // txtTotSource
            // 
            this.txtTotSource.Location = new System.Drawing.Point(590, 19);
            this.txtTotSource.Name = "txtTotSource";
            this.txtTotSource.ReadOnly = true;
            this.txtTotSource.Size = new System.Drawing.Size(100, 20);
            this.txtTotSource.TabIndex = 1;
            // 
            // txtTotDitte
            // 
            this.txtTotDitte.Location = new System.Drawing.Point(99, 19);
            this.txtTotDitte.Name = "txtTotDitte";
            this.txtTotDitte.ReadOnly = true;
            this.txtTotDitte.Size = new System.Drawing.Size(100, 20);
            this.txtTotDitte.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ditte Commerciali";
            // 
            // txtTotPersone
            // 
            this.txtTotPersone.Location = new System.Drawing.Point(212, 19);
            this.txtTotPersone.Name = "txtTotPersone";
            this.txtTotPersone.ReadOnly = true;
            this.txtTotPersone.Size = new System.Drawing.Size(100, 20);
            this.txtTotPersone.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Persone fisiche";
            // 
            // txtTotEnti
            // 
            this.txtTotEnti.Location = new System.Drawing.Point(325, 19);
            this.txtTotEnti.Name = "txtTotEnti";
            this.txtTotEnti.ReadOnly = true;
            this.txtTotEnti.Size = new System.Drawing.Size(100, 20);
            this.txtTotEnti.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Enti non commerciali";
            // 
            // txtTotComplementari
            // 
            this.txtTotComplementari.Location = new System.Drawing.Point(435, 19);
            this.txtTotComplementari.Name = "txtTotComplementari";
            this.txtTotComplementari.ReadOnly = true;
            this.txtTotComplementari.Size = new System.Drawing.Size(100, 20);
            this.txtTotComplementari.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Anagrafiche Complementari";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotDitte);
            this.groupBox1.Controls.Add(this.txtTotComplementari);
            this.groupBox1.Controls.Add(this.txtTotSource);
            this.groupBox1.Controls.Add(this.txtTotPersone);
            this.groupBox1.Controls.Add(this.txtTotEnti);
            this.groupBox1.Location = new System.Drawing.Point(22, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 54);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anagrafiche nel db di origine";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEsaminateComm);
            this.groupBox2.Controls.Add(this.txtEsaminateComplementari);
            this.groupBox2.Controls.Add(this.txtEsaminateTotali);
            this.groupBox2.Controls.Add(this.txtEsaminatePersone);
            this.groupBox2.Controls.Add(this.txtEsaminateEnti);
            this.groupBox2.Location = new System.Drawing.Point(22, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 54);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Anagrafiche esaminate";
            // 
            // txtEsaminateComm
            // 
            this.txtEsaminateComm.Location = new System.Drawing.Point(99, 19);
            this.txtEsaminateComm.Name = "txtEsaminateComm";
            this.txtEsaminateComm.ReadOnly = true;
            this.txtEsaminateComm.Size = new System.Drawing.Size(100, 20);
            this.txtEsaminateComm.TabIndex = 3;
            // 
            // txtEsaminateComplementari
            // 
            this.txtEsaminateComplementari.Location = new System.Drawing.Point(435, 19);
            this.txtEsaminateComplementari.Name = "txtEsaminateComplementari";
            this.txtEsaminateComplementari.ReadOnly = true;
            this.txtEsaminateComplementari.Size = new System.Drawing.Size(100, 20);
            this.txtEsaminateComplementari.TabIndex = 9;
            // 
            // txtEsaminateTotali
            // 
            this.txtEsaminateTotali.Location = new System.Drawing.Point(590, 19);
            this.txtEsaminateTotali.Name = "txtEsaminateTotali";
            this.txtEsaminateTotali.ReadOnly = true;
            this.txtEsaminateTotali.Size = new System.Drawing.Size(100, 20);
            this.txtEsaminateTotali.TabIndex = 1;
            // 
            // txtEsaminatePersone
            // 
            this.txtEsaminatePersone.Location = new System.Drawing.Point(212, 19);
            this.txtEsaminatePersone.Name = "txtEsaminatePersone";
            this.txtEsaminatePersone.ReadOnly = true;
            this.txtEsaminatePersone.Size = new System.Drawing.Size(100, 20);
            this.txtEsaminatePersone.TabIndex = 5;
            // 
            // txtEsaminateEnti
            // 
            this.txtEsaminateEnti.Location = new System.Drawing.Point(325, 19);
            this.txtEsaminateEnti.Name = "txtEsaminateEnti";
            this.txtEsaminateEnti.ReadOnly = true;
            this.txtEsaminateEnti.Size = new System.Drawing.Size(100, 20);
            this.txtEsaminateEnti.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPresentiComm);
            this.groupBox3.Controls.Add(this.txtPresentiComplementari);
            this.groupBox3.Controls.Add(this.txtPresentiTotali);
            this.groupBox3.Controls.Add(this.txtPresentiPersone);
            this.groupBox3.Controls.Add(this.txtPresentiEnti);
            this.groupBox3.Location = new System.Drawing.Point(22, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(734, 54);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Anagrafiche che erano già presenti nel db di destinazione";
            // 
            // txtPresentiComm
            // 
            this.txtPresentiComm.Location = new System.Drawing.Point(99, 19);
            this.txtPresentiComm.Name = "txtPresentiComm";
            this.txtPresentiComm.ReadOnly = true;
            this.txtPresentiComm.Size = new System.Drawing.Size(100, 20);
            this.txtPresentiComm.TabIndex = 3;
            // 
            // txtPresentiComplementari
            // 
            this.txtPresentiComplementari.Location = new System.Drawing.Point(435, 19);
            this.txtPresentiComplementari.Name = "txtPresentiComplementari";
            this.txtPresentiComplementari.ReadOnly = true;
            this.txtPresentiComplementari.Size = new System.Drawing.Size(100, 20);
            this.txtPresentiComplementari.TabIndex = 9;
            // 
            // txtPresentiTotali
            // 
            this.txtPresentiTotali.Location = new System.Drawing.Point(590, 19);
            this.txtPresentiTotali.Name = "txtPresentiTotali";
            this.txtPresentiTotali.ReadOnly = true;
            this.txtPresentiTotali.Size = new System.Drawing.Size(100, 20);
            this.txtPresentiTotali.TabIndex = 1;
            // 
            // txtPresentiPersone
            // 
            this.txtPresentiPersone.Location = new System.Drawing.Point(212, 19);
            this.txtPresentiPersone.Name = "txtPresentiPersone";
            this.txtPresentiPersone.ReadOnly = true;
            this.txtPresentiPersone.Size = new System.Drawing.Size(100, 20);
            this.txtPresentiPersone.TabIndex = 5;
            // 
            // txtPresentiEnti
            // 
            this.txtPresentiEnti.Location = new System.Drawing.Point(325, 19);
            this.txtPresentiEnti.Name = "txtPresentiEnti";
            this.txtPresentiEnti.ReadOnly = true;
            this.txtPresentiEnti.Size = new System.Drawing.Size(100, 20);
            this.txtPresentiEnti.TabIndex = 7;
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(22, 280);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(876, 23);
            this.pBar.TabIndex = 13;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(802, 324);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Interrompi";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // FrmMatchAnagrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 370);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMatchAnagrafica";
            this.Text = "FrmMatchAnagrafica";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotSource;
        private System.Windows.Forms.TextBox txtTotDitte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotPersone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotEnti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotComplementari;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEsaminateComm;
        private System.Windows.Forms.TextBox txtEsaminateComplementari;
        private System.Windows.Forms.TextBox txtEsaminateTotali;
        private System.Windows.Forms.TextBox txtEsaminatePersone;
        private System.Windows.Forms.TextBox txtEsaminateEnti;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPresentiComm;
        private System.Windows.Forms.TextBox txtPresentiComplementari;
        private System.Windows.Forms.TextBox txtPresentiTotali;
        private System.Windows.Forms.TextBox txtPresentiPersone;
        private System.Windows.Forms.TextBox txtPresentiEnti;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button btnStop;
    }
}
