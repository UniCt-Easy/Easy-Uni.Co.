
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


namespace manage_var {
    partial class AskDescription {
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
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxFinanziamento = new System.Windows.Forms.GroupBox();
            this.txtUnderwriting = new System.Windows.Forms.TextBox();
            this.btnFinanziamento = new System.Windows.Forms.Button();
            this.gboxFinanziamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(336, 157);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 7;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(248, 157);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(7, 24);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(400, 56);
            this.txtDescrizione.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descrizione:";
            // 
            // gboxFinanziamento
            // 
            this.gboxFinanziamento.Controls.Add(this.txtUnderwriting);
            this.gboxFinanziamento.Controls.Add(this.btnFinanziamento);
            this.gboxFinanziamento.Location = new System.Drawing.Point(4, 86);
            this.gboxFinanziamento.Name = "gboxFinanziamento";
            this.gboxFinanziamento.Size = new System.Drawing.Size(400, 65);
            this.gboxFinanziamento.TabIndex = 8;
            this.gboxFinanziamento.TabStop = false;
            this.gboxFinanziamento.Text = "Finanziamento";
            // 
            // txtUnderwriting
            // 
            this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderwriting.Location = new System.Drawing.Point(116, 24);
            this.txtUnderwriting.Name = "txtUnderwriting";
            this.txtUnderwriting.Size = new System.Drawing.Size(278, 20);
            this.txtUnderwriting.TabIndex = 5;
            this.txtUnderwriting.Tag = "";
            this.txtUnderwriting.Leave += new System.EventHandler(this.txtUnderwriting_Leave);
            // 
            // btnFinanziamento
            // 
            this.btnFinanziamento.Location = new System.Drawing.Point(6, 21);
            this.btnFinanziamento.Name = "btnFinanziamento";
            this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
            this.btnFinanziamento.TabIndex = 4;
            this.btnFinanziamento.Tag = "";
            this.btnFinanziamento.Text = "Finanziamento";
            this.btnFinanziamento.UseVisualStyleBackColor = true;
            this.btnFinanziamento.Click += new System.EventHandler(this.btnFinanziamento_Click);
            // 
            // AskDescription
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 195);
            this.Controls.Add(this.gboxFinanziamento);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label1);
            this.Name = "AskDescription";
            this.Text = "Cambia Descrizione";
            this.gboxFinanziamento.ResumeLayout(false);
            this.gboxFinanziamento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboxFinanziamento;
        private System.Windows.Forms.TextBox txtUnderwriting;
        private System.Windows.Forms.Button btnFinanziamento;
    }
}
