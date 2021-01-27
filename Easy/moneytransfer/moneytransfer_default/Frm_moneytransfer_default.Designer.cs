
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


namespace moneytransfer_default
{
    partial class Frm_moneytransfer_default
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
            this.DS = new moneytransfer_default.vistaForm();
            this.btnCassiereOrigine = new System.Windows.Forms.Button();
            this.cmbCassiereorigine = new System.Windows.Forms.ComboBox();
            this.btnCassiereDestinazione = new System.Windows.Forms.Button();
            this.cmbCassieredest = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercizioDocumento = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnCassiereOrigine
            // 
            this.btnCassiereOrigine.Location = new System.Drawing.Point(16, 161);
            this.btnCassiereOrigine.Name = "btnCassiereOrigine";
            this.btnCassiereOrigine.Size = new System.Drawing.Size(133, 24);
            this.btnCassiereOrigine.TabIndex = 9;
            this.btnCassiereOrigine.TabStop = false;
            this.btnCassiereOrigine.Tag = "choose.treasurersource.lista.(active=\'S\')";
            this.btnCassiereOrigine.Text = "Cassiere origine:";
            this.btnCassiereOrigine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCassiereorigine
            // 
            this.cmbCassiereorigine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCassiereorigine.DataSource = this.DS.treasurersource;
            this.cmbCassiereorigine.DisplayMember = "description";
            this.cmbCassiereorigine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCassiereorigine.Location = new System.Drawing.Point(172, 162);
            this.cmbCassiereorigine.Name = "cmbCassiereorigine";
            this.cmbCassiereorigine.Size = new System.Drawing.Size(196, 21);
            this.cmbCassiereorigine.TabIndex = 5;
            this.cmbCassiereorigine.Tag = "moneytransfer.idtreasurersource";
            this.cmbCassiereorigine.ValueMember = "idtreasurer";
            // 
            // btnCassiereDestinazione
            // 
            this.btnCassiereDestinazione.Location = new System.Drawing.Point(17, 192);
            this.btnCassiereDestinazione.Name = "btnCassiereDestinazione";
            this.btnCassiereDestinazione.Size = new System.Drawing.Size(133, 24);
            this.btnCassiereDestinazione.TabIndex = 11;
            this.btnCassiereDestinazione.TabStop = false;
            this.btnCassiereDestinazione.Tag = "choose.treasurerdest.lista.(active=\'S\')";
            this.btnCassiereDestinazione.Text = "Cassiere destinazione:";
            this.btnCassiereDestinazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCassieredest
            // 
            this.cmbCassieredest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCassieredest.DataSource = this.DS.treasurerdest;
            this.cmbCassieredest.DisplayMember = "description";
            this.cmbCassieredest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCassieredest.Location = new System.Drawing.Point(173, 195);
            this.cmbCassieredest.Name = "cmbCassieredest";
            this.cmbCassieredest.Size = new System.Drawing.Size(196, 21);
            this.cmbCassieredest.TabIndex = 6;
            this.cmbCassieredest.Tag = "moneytransfer.idtreasurerdest";
            this.cmbCassieredest.ValueMember = "idtreasurer";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Data";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(644, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Tag = "moneytransfer.adate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Descrizione";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(17, 105);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(733, 51);
            this.textBox2.TabIndex = 4;
            this.textBox2.Tag = "moneytransfer.description";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(606, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Importo";
            // 
            // txtImporto
            // 
            this.txtImporto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImporto.Location = new System.Drawing.Point(654, 164);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(96, 20);
            this.txtImporto.TabIndex = 7;
            this.txtImporto.Tag = "moneytransfer.amount";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(70, 46);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(72, 20);
            this.txtNumeroDocumento.TabIndex = 2;
            this.txtNumeroDocumento.TabStop = false;
            this.txtNumeroDocumento.Tag = "moneytransfer.ntransfer";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Esercizio:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioDocumento
            // 
            this.txtEsercizioDocumento.Location = new System.Drawing.Point(70, 21);
            this.txtEsercizioDocumento.Name = "txtEsercizioDocumento";
            this.txtEsercizioDocumento.ReadOnly = true;
            this.txtEsercizioDocumento.Size = new System.Drawing.Size(72, 20);
            this.txtEsercizioDocumento.TabIndex = 1;
            this.txtEsercizioDocumento.TabStop = false;
            this.txtEsercizioDocumento.Tag = "moneytransfer.ytransfer.year";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButton6);
            this.groupBox2.Controls.Add(this.radioButton5);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(173, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 65);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo trasferimento";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(306, 42);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(134, 17);
            this.radioButton6.TabIndex = 6;
            this.radioButton6.Tag = "moneytransfer.transferkind:V";
            this.radioButton6.Text = "per Variazione di cassa";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(306, 19);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(191, 17);
            this.radioButton5.TabIndex = 5;
            this.radioButton5.Tag = "moneytransfer.transferkind:G";
            this.radioButton5.Text = "Pagamenti o Incassi da girofondare";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(164, 42);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(56, 17);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.Tag = "moneytransfer.transferkind:P";
            this.radioButton4.Text = "Prestiti";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(164, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(119, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Tag = "moneytransfer.transferkind:I";
            this.radioButton3.Text = "per Versamento IVA";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(132, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Tag = "moneytransfer.transferkind:R";
            this.radioButton2.Text = "per Ritenute/Contributi";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Tag = "moneytransfer.transferkind:N";
            this.radioButton1.Text = "Altro";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Frm_moneytransfer_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEsercizioDocumento);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCassiereDestinazione);
            this.Controls.Add(this.cmbCassieredest);
            this.Controls.Add(this.btnCassiereOrigine);
            this.Controls.Add(this.cmbCassiereorigine);
            this.Name = "Frm_moneytransfer_default";
            this.Text = "Frm_moneytransfer_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnCassiereOrigine;
        private System.Windows.Forms.ComboBox cmbCassiereorigine;
        private System.Windows.Forms.Button btnCassiereDestinazione;
        private System.Windows.Forms.ComboBox cmbCassieredest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercizioDocumento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton6;

    }
}
