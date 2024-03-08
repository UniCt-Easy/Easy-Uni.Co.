
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


namespace registryottemperanzalegge68_99_default {
    partial class Frm_registryottemperanzalegge68_99_default {
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
            this.DS = new registryottemperanzalegge68_99_default.vistaForm();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCreDeb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtscadenza = new System.Windows.Forms.TextBox();
            this.txtDataIniziovalidita = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labVisuraFileName = new System.Windows.Forms.Label();
            this.btnVisualizzaOttemperanzaLegge = new System.Windows.Forms.Button();
            this.btnRimuoviOttemperanzaLegge = new System.Windows.Forms.Button();
            this.btnAllegaOttemperanzaLegge = new System.Windows.Forms.Button();
            this._opendlg = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupCredDeb.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCreDeb);
            this.groupCredDeb.Controls.Add(this.label6);
            this.groupCredDeb.Location = new System.Drawing.Point(12, 12);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(510, 48);
            this.groupCredDeb.TabIndex = 2;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCreDeb.anagrafica.(active<>\'N\')";
            this.groupCredDeb.Text = "Anagrafica";
            // 
            // txtCreDeb
            // 
            this.txtCreDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreDeb.Location = new System.Drawing.Point(109, 16);
            this.txtCreDeb.Name = "txtCreDeb";
            this.txtCreDeb.Size = new System.Drawing.Size(393, 20);
            this.txtCreDeb.TabIndex = 1;
            this.txtCreDeb.Tag = "registry.title?registryottemperanzalegge68_99view.registry";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Denominazione:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtscadenza
            // 
            this.txtscadenza.Location = new System.Drawing.Point(373, 109);
            this.txtscadenza.Name = "txtscadenza";
            this.txtscadenza.Size = new System.Drawing.Size(120, 20);
            this.txtscadenza.TabIndex = 188;
            this.txtscadenza.Tag = "registryottemperanzalegge68_99.stop";
            // 
            // txtDataIniziovalidita
            // 
            this.txtDataIniziovalidita.Location = new System.Drawing.Point(125, 109);
            this.txtDataIniziovalidita.Name = "txtDataIniziovalidita";
            this.txtDataIniziovalidita.Size = new System.Drawing.Size(120, 20);
            this.txtDataIniziovalidita.TabIndex = 187;
            this.txtDataIniziovalidita.Tag = "registryottemperanzalegge68_99.start";
            this.txtDataIniziovalidita.Leave += new System.EventHandler(this.txtDataIniziovalidita_Leave);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(280, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 23);
            this.label10.TabIndex = 190;
            this.label10.Text = "Data scadenza";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 30);
            this.label4.TabIndex = 189;
            this.label4.Text = "Data inizio validit�";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(49, 66);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(69, 20);
            this.textBox4.TabIndex = 201;
            this.textBox4.Tag = "registryottemperanzalegge68_99.idregistryottemperanzalegge";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 202;
            this.label12.Text = "#";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labVisuraFileName);
            this.groupBox3.Controls.Add(this.btnVisualizzaOttemperanzaLegge);
            this.groupBox3.Controls.Add(this.btnRimuoviOttemperanzaLegge);
            this.groupBox3.Controls.Add(this.btnAllegaOttemperanzaLegge);
            this.groupBox3.Location = new System.Drawing.Point(12, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(510, 73);
            this.groupBox3.TabIndex = 203;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Allegato Ottemperanza Legge 68/99";
            // 
            // labVisuraFileName
            // 
            this.labVisuraFileName.Location = new System.Drawing.Point(10, 16);
            this.labVisuraFileName.Name = "labVisuraFileName";
            this.labVisuraFileName.Size = new System.Drawing.Size(406, 18);
            this.labVisuraFileName.TabIndex = 75;
            // 
            // btnVisualizzaOttemperanzaLegge
            // 
            this.btnVisualizzaOttemperanzaLegge.Location = new System.Drawing.Point(333, 36);
            this.btnVisualizzaOttemperanzaLegge.Name = "btnVisualizzaOttemperanzaLegge";
            this.btnVisualizzaOttemperanzaLegge.Size = new System.Drawing.Size(79, 24);
            this.btnVisualizzaOttemperanzaLegge.TabIndex = 2;
            this.btnVisualizzaOttemperanzaLegge.Text = "Visualizza";
            this.btnVisualizzaOttemperanzaLegge.UseVisualStyleBackColor = true;
            this.btnVisualizzaOttemperanzaLegge.Click += new System.EventHandler(this.btnVisualizzaVisura_Click);
            // 
            // btnRimuoviOttemperanzaLegge
            // 
            this.btnRimuoviOttemperanzaLegge.Location = new System.Drawing.Point(213, 36);
            this.btnRimuoviOttemperanzaLegge.Name = "btnRimuoviOttemperanzaLegge";
            this.btnRimuoviOttemperanzaLegge.Size = new System.Drawing.Size(99, 24);
            this.btnRimuoviOttemperanzaLegge.TabIndex = 1;
            this.btnRimuoviOttemperanzaLegge.Text = "Rimuovi Allegato";
            this.btnRimuoviOttemperanzaLegge.UseVisualStyleBackColor = true;
            this.btnRimuoviOttemperanzaLegge.Click += new System.EventHandler(this.btnRimuoviVisura_Click);
            // 
            // btnAllegaOttemperanzaLegge
            // 
            this.btnAllegaOttemperanzaLegge.Location = new System.Drawing.Point(117, 36);
            this.btnAllegaOttemperanzaLegge.Name = "btnAllegaOttemperanzaLegge";
            this.btnAllegaOttemperanzaLegge.Size = new System.Drawing.Size(79, 24);
            this.btnAllegaOttemperanzaLegge.TabIndex = 0;
            this.btnAllegaOttemperanzaLegge.Text = "Allega";
            this.btnAllegaOttemperanzaLegge.UseVisualStyleBackColor = true;
            this.btnAllegaOttemperanzaLegge.Click += new System.EventHandler(this.btnAllegaVisura_Click);
            // 
            // opendlg
            // 
            this._opendlg.Title = "Scegli il file da allegare";
            // 
            // Frm_registryottemperanzalegge68_99_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 255);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtscadenza);
            this.Controls.Add(this.txtDataIniziovalidita);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupCredDeb);
            this.Name = "Frm_registryottemperanzalegge68_99_default";
            this.Text = "Frm_registryottemperanzalegge68_99_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupCredDeb;
        private System.Windows.Forms.TextBox txtCreDeb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtscadenza;
        private System.Windows.Forms.TextBox txtDataIniziovalidita;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labVisuraFileName;
        private System.Windows.Forms.Button btnVisualizzaOttemperanzaLegge;
        private System.Windows.Forms.Button btnRimuoviOttemperanzaLegge;
        private System.Windows.Forms.Button btnAllegaOttemperanzaLegge;
        private System.Windows.Forms.OpenFileDialog _opendlg;
        public vistaForm DS;
    }
}
