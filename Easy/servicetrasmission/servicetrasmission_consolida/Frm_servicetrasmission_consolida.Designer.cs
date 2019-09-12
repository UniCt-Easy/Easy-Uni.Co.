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

namespace servicetrasmission_consolida
{
    partial class Frm_servicetrasmission_consolida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_servicetrasmission_consolida));
            this.DS = new servicetrasmission_consolida.vistaForm();
            this.btnConsolidaConsulenti = new System.Windows.Forms.Button();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsolidaDipendenti = new System.Windows.Forms.Button();
            this.txtNomeFile = new System.Windows.Forms.TextBox();
            this.btnSalvaFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkyear = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEsito = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnConsolidaConsulenti
            // 
            this.btnConsolidaConsulenti.Location = new System.Drawing.Point(187, 178);
            this.btnConsolidaConsulenti.Name = "btnConsolidaConsulenti";
            this.btnConsolidaConsulenti.Size = new System.Drawing.Size(104, 38);
            this.btnConsolidaConsulenti.TabIndex = 0;
            this.btnConsolidaConsulenti.Text = "Consolida Consulenti";
            this.btnConsolidaConsulenti.UseVisualStyleBackColor = true;
            this.btnConsolidaConsulenti.Click += new System.EventHandler(this.btnConsolida_Click);
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(69, 16);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(72, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Esercizio";
            // 
            // btnConsolidaDipendenti
            // 
            this.btnConsolidaDipendenti.Location = new System.Drawing.Point(327, 178);
            this.btnConsolidaDipendenti.Name = "btnConsolidaDipendenti";
            this.btnConsolidaDipendenti.Size = new System.Drawing.Size(104, 38);
            this.btnConsolidaDipendenti.TabIndex = 3;
            this.btnConsolidaDipendenti.Text = "Consolida Dipendenti";
            this.btnConsolidaDipendenti.UseVisualStyleBackColor = true;
            this.btnConsolidaDipendenti.Click += new System.EventHandler(this.btnConsolidaDipendenti_Click);
            // 
            // txtNomeFile
            // 
            this.txtNomeFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeFile.Location = new System.Drawing.Point(101, 65);
            this.txtNomeFile.Name = "txtNomeFile";
            this.txtNomeFile.ReadOnly = true;
            this.txtNomeFile.Size = new System.Drawing.Size(443, 20);
            this.txtNomeFile.TabIndex = 25;
            // 
            // btnSalvaFile
            // 
            this.btnSalvaFile.Location = new System.Drawing.Point(20, 63);
            this.btnSalvaFile.Name = "btnSalvaFile";
            this.btnSalvaFile.Size = new System.Drawing.Size(75, 23);
            this.btnSalvaFile.TabIndex = 26;
            this.btnSalvaFile.Text = "File Xml";
            this.btnSalvaFile.Click += new System.EventHandler(this.btnSalvaFile_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            // 
            // chkyear
            // 
            this.chkyear.AutoSize = true;
            this.chkyear.Location = new System.Drawing.Point(147, 19);
            this.chkyear.Name = "chkyear";
            this.chkyear.Size = new System.Drawing.Size(221, 17);
            this.chkyear.TabIndex = 39;
            this.chkyear.Text = "Esporta gli incarichii dell\'esercizio indicato";
            this.chkyear.UseVisualStyleBackColor = true;
            this.chkyear.CheckedChanged += new System.EventHandler(this.chkyear_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(559, 39);
            this.label3.TabIndex = 40;
            this.label3.Text = resources.GetString("label3.Text");
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkyear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Location = new System.Drawing.Point(20, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 46);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // btnEsito
            // 
            this.btnEsito.Location = new System.Drawing.Point(467, 181);
            this.btnEsito.Name = "btnEsito";
            this.btnEsito.Size = new System.Drawing.Size(104, 33);
            this.btnEsito.TabIndex = 42;
            this.btnEsito.Text = "Visualizza Esito";
            this.btnEsito.UseVisualStyleBackColor = true;
            this.btnEsito.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm_servicetrasmission_consolida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 230);
            this.Controls.Add(this.btnEsito);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomeFile);
            this.Controls.Add(this.btnSalvaFile);
            this.Controls.Add(this.btnConsolidaDipendenti);
            this.Controls.Add(this.btnConsolidaConsulenti);
            this.Name = "Frm_servicetrasmission_consolida";
            this.Text = "Frm_servicetrasmission_consolida";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnConsolidaConsulenti;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsolidaDipendenti;
        private System.Windows.Forms.TextBox txtNomeFile;
        private System.Windows.Forms.Button btnSalvaFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkyear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEsito;

    }
}