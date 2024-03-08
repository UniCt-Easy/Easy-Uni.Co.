
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


namespace no_table_trasf_flowchart {
    partial class FrmTrasfFlowchart {
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
            this.txtEsercizioFine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizioInizio = new System.Windows.Forms.TextBox();
            this.labelEsercizio = new System.Windows.Forms.Label();
            this.btnTrasferisciOrganigramma = new System.Windows.Forms.Button();
            this.DS = new no_table_trasf_flowchart.vistaForm();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.Controls.Add(this.txtEsercizioFine);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEsercizioInizio);
            this.groupBox1.Controls.Add(this.labelEsercizio);
            this.groupBox1.Controls.Add(this.btnTrasferisciOrganigramma);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtEsercizioFine
            // 
            this.txtEsercizioFine.BackColor = System.Drawing.SystemColors.Window;
            this.txtEsercizioFine.Enabled = false;
            this.txtEsercizioFine.Location = new System.Drawing.Point(32, 86);
            this.txtEsercizioFine.Name = "txtEsercizioFine";
            this.txtEsercizioFine.Size = new System.Drawing.Size(72, 20);
            this.txtEsercizioFine.TabIndex = 9;
            this.txtEsercizioFine.Tag = "";
            this.txtEsercizioFine.Leave += new System.EventHandler(this.txtEsercizio_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Esercizio fine";
            // 
            // txtEsercizioInizio
            // 
            this.txtEsercizioInizio.BackColor = System.Drawing.SystemColors.Window;
            this.txtEsercizioInizio.Enabled = false;
            this.txtEsercizioInizio.Location = new System.Drawing.Point(32, 42);
            this.txtEsercizioInizio.Name = "txtEsercizioInizio";
            this.txtEsercizioInizio.ReadOnly = true;
            this.txtEsercizioInizio.Size = new System.Drawing.Size(72, 20);
            this.txtEsercizioInizio.TabIndex = 7;
            this.txtEsercizioInizio.Tag = "";
            this.txtEsercizioInizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
            // 
            // labelEsercizio
            // 
            this.labelEsercizio.AutoSize = true;
            this.labelEsercizio.Location = new System.Drawing.Point(29, 26);
            this.labelEsercizio.Name = "labelEsercizio";
            this.labelEsercizio.Size = new System.Drawing.Size(75, 13);
            this.labelEsercizio.TabIndex = 6;
            this.labelEsercizio.Text = "Esercizio inizio";
            // 
            // btnTrasferisciOrganigramma
            // 
            this.btnTrasferisciOrganigramma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrasferisciOrganigramma.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTrasferisciOrganigramma.Location = new System.Drawing.Point(191, 42);
            this.btnTrasferisciOrganigramma.Name = "btnTrasferisciOrganigramma";
            this.btnTrasferisciOrganigramma.Size = new System.Drawing.Size(201, 45);
            this.btnTrasferisciOrganigramma.TabIndex = 1;
            this.btnTrasferisciOrganigramma.Text = "Trasferisci Organigramma";
            this.btnTrasferisciOrganigramma.UseVisualStyleBackColor = true;
            this.btnTrasferisciOrganigramma.Click += new System.EventHandler(this.btnTrasferisciOrganigramma_Click);
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
            this.btnOK.Location = new System.Drawing.Point(253, 211);
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
            this.btnAnnulla.Location = new System.Drawing.Point(349, 211);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 8;
            this.btnAnnulla.Text = "Annulla";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 49);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(22, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(378, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "La procedura consente di trasferire l\'organigramma da un esercizio ad un altro";
            // 
            // FrmTrasfFlowchart
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnTrasferisciOrganigramma;
            this.ClientSize = new System.Drawing.Size(436, 251);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmTrasfFlowchart";
            this.Text = "Trasferimento Organigramma";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTrasferisciOrganigramma;
        private System.Windows.Forms.TextBox txtEsercizioInizio;
        private System.Windows.Forms.Label labelEsercizio;
        private System.Windows.Forms.TextBox txtEsercizioFine;
        private System.Windows.Forms.Label label1;
        public vistaForm DS;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;

    }
}
