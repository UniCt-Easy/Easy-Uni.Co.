
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


namespace billtransaction_default {
    partial class Frm_billtransaction_default {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoCredito = new System.Windows.Forms.RadioButton();
            this.rdoDebito = new System.Windows.Forms.RadioButton();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtImportoEsito = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumBolletta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DS = new billtransaction_default.vistaForm();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Esercizio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoCredito);
            this.groupBox1.Controls.Add(this.rdoDebito);
            this.groupBox1.Location = new System.Drawing.Point(294, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 57);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Partita Pendente";
            // 
            // rdoCredito
            // 
            this.rdoCredito.Location = new System.Drawing.Point(8, 32);
            this.rdoCredito.Name = "rdoCredito";
            this.rdoCredito.Size = new System.Drawing.Size(96, 19);
            this.rdoCredito.TabIndex = 1;
            this.rdoCredito.Tag = "billtransaction.kind:C";
            this.rdoCredito.Text = "di incasso";
            // 
            // rdoDebito
            // 
            this.rdoDebito.Location = new System.Drawing.Point(8, 14);
            this.rdoDebito.Name = "rdoDebito";
            this.rdoDebito.Size = new System.Drawing.Size(96, 20);
            this.rdoDebito.TabIndex = 2;
            this.rdoDebito.Tag = "billtransaction.kind:D";
            this.rdoDebito.Text = "di pagamento";
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(106, 13);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(100, 20);
            this.txtEsercizio.TabIndex = 15;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "";
            this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Numero";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(106, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.Tag = "billtransaction.nbilltran";
            // 
            // txtImportoEsito
            // 
            this.txtImportoEsito.Location = new System.Drawing.Point(107, 113);
            this.txtImportoEsito.Name = "txtImportoEsito";
            this.txtImportoEsito.Size = new System.Drawing.Size(100, 20);
            this.txtImportoEsito.TabIndex = 27;
            this.txtImportoEsito.Tag = "billtransaction.amount";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(319, 113);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 23;
            this.textBox8.Tag = "billtransaction.adate";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(207, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 26;
            this.label8.Text = "Data Operazione:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(24, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 23);
            this.label10.TabIndex = 29;
            this.label10.Text = "Importo:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumBolletta
            // 
            this.txtNumBolletta.Location = new System.Drawing.Point(138, 74);
            this.txtNumBolletta.Name = "txtNumBolletta";
            this.txtNumBolletta.Size = new System.Drawing.Size(68, 20);
            this.txtNumBolletta.TabIndex = 34;
            this.txtNumBolletta.Tag = "billtransaction.nbill";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "N.Partita Pendente";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_billtransaction_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 158);
            this.Controls.Add(this.txtNumBolletta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtImportoEsito);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Name = "Frm_billtransaction_default";
            this.Text = "Frm_billtransaction_default";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoCredito;
        private System.Windows.Forms.RadioButton rdoDebito;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtImportoEsito;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumBolletta;
        private System.Windows.Forms.Label label7;
    }
}
