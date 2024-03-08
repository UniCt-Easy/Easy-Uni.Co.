
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


namespace taxfinmotive_single {
    partial class Frm_taxfinmotive_single {
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
            this.DS = new taxfinmotive_single.vistaForm();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpPrestazione = new System.Windows.Forms.GroupBox();
            this.btnTipoPrestazione = new System.Windows.Forms.Button();
            this.cmbTipoPrestazione = new System.Windows.Forms.ComboBox();
            this.gboxCausale = new System.Windows.Forms.GroupBox();
            this.TxtDescrCausaleDeb = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleEntrataContributi = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleSpesaContributiLiq = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleSpesaContributi = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleSpesaRitenuteLiq = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleEntrataRit = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpPrestazione.SuspendLayout();
            this.gboxCausale.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(502, 482);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 17;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(603, 482);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // grpPrestazione
            // 
            this.grpPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPrestazione.Controls.Add(this.btnTipoPrestazione);
            this.grpPrestazione.Controls.Add(this.cmbTipoPrestazione);
            this.grpPrestazione.Location = new System.Drawing.Point(12, 12);
            this.grpPrestazione.Name = "grpPrestazione";
            this.grpPrestazione.Size = new System.Drawing.Size(662, 48);
            this.grpPrestazione.TabIndex = 1;
            this.grpPrestazione.TabStop = false;
            this.grpPrestazione.Text = "Prestazione";
            // 
            // btnTipoPrestazione
            // 
            this.btnTipoPrestazione.Location = new System.Drawing.Point(8, 16);
            this.btnTipoPrestazione.Name = "btnTipoPrestazione";
            this.btnTipoPrestazione.Size = new System.Drawing.Size(75, 24);
            this.btnTipoPrestazione.TabIndex = 1;
            this.btnTipoPrestazione.TabStop = false;
            this.btnTipoPrestazione.Tag = "manage.service.default";
            this.btnTipoPrestazione.Text = "Tipo";
            // 
            // cmbTipoPrestazione
            // 
            this.cmbTipoPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoPrestazione.DataSource = this.DS.service;
            this.cmbTipoPrestazione.DisplayMember = "description";
            this.cmbTipoPrestazione.ItemHeight = 13;
            this.cmbTipoPrestazione.Location = new System.Drawing.Point(96, 16);
            this.cmbTipoPrestazione.Name = "cmbTipoPrestazione";
            this.cmbTipoPrestazione.Size = new System.Drawing.Size(558, 21);
            this.cmbTipoPrestazione.TabIndex = 2;
            this.cmbTipoPrestazione.Tag = "taxfinmotive.idser";
            this.cmbTipoPrestazione.ValueMember = "idser";
            // 
            // gboxCausale
            // 
            this.gboxCausale.Controls.Add(this.TxtDescrCausaleDeb);
            this.gboxCausale.Controls.Add(this.txtCodiceCausaleEntrataContributi);
            this.gboxCausale.Controls.Add(this.button6);
            this.gboxCausale.Location = new System.Drawing.Point(10, 31);
            this.gboxCausale.Name = "gboxCausale";
            this.gboxCausale.Size = new System.Drawing.Size(328, 104);
            this.gboxCausale.TabIndex = 3;
            this.gboxCausale.TabStop = false;
            this.gboxCausale.Tag = "AutoManage.txtCodiceCausaleEntrataContributi.tree.(active = \'S\')";
            this.gboxCausale.Text = "Causale di entrata";
            this.gboxCausale.UseCompatibleTextRendering = true;
            // 
            // TxtDescrCausaleDeb
            // 
            this.TxtDescrCausaleDeb.Location = new System.Drawing.Point(120, 16);
            this.TxtDescrCausaleDeb.Multiline = true;
            this.TxtDescrCausaleDeb.Name = "TxtDescrCausaleDeb";
            this.TxtDescrCausaleDeb.ReadOnly = true;
            this.TxtDescrCausaleDeb.Size = new System.Drawing.Size(200, 56);
            this.TxtDescrCausaleDeb.TabIndex = 2;
            this.TxtDescrCausaleDeb.TabStop = false;
            this.TxtDescrCausaleDeb.Tag = "finmotive_incomeintra.title";
            // 
            // txtCodiceCausaleEntrataContributi
            // 
            this.txtCodiceCausaleEntrataContributi.Location = new System.Drawing.Point(8, 78);
            this.txtCodiceCausaleEntrataContributi.Name = "txtCodiceCausaleEntrataContributi";
            this.txtCodiceCausaleEntrataContributi.Size = new System.Drawing.Size(312, 20);
            this.txtCodiceCausaleEntrataContributi.TabIndex = 10;
            this.txtCodiceCausaleEntrataContributi.Tag = "finmotive_incomeintra.codemotive?x";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 45);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 23);
            this.button6.TabIndex = 0;
            this.button6.TabStop = false;
            this.button6.Tag = "manage.finmotive_incomeintra.tree";
            this.button6.Text = "Causale";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.gboxCausale);
            this.groupBox4.Location = new System.Drawing.Point(2, 67);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(679, 251);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gestione dei CONTRIBUTI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.txtCodiceCausaleSpesaContributiLiq);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(10, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 104);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoManage.txtCodiceCausaleSpesaContributiLiq.tree.(active = \'S\')";
            this.groupBox2.Text = "Causale di spesa per Liquidazione periodica";
            this.groupBox2.UseCompatibleTextRendering = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(120, 16);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(200, 56);
            this.textBox3.TabIndex = 2;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "finmotive_expensecontra.title";
            // 
            // txtCodiceCausaleSpesaContributiLiq
            // 
            this.txtCodiceCausaleSpesaContributiLiq.Location = new System.Drawing.Point(8, 78);
            this.txtCodiceCausaleSpesaContributiLiq.Name = "txtCodiceCausaleSpesaContributiLiq";
            this.txtCodiceCausaleSpesaContributiLiq.Size = new System.Drawing.Size(312, 20);
            this.txtCodiceCausaleSpesaContributiLiq.TabIndex = 30;
            this.txtCodiceCausaleSpesaContributiLiq.Tag = "finmotive_expensecontra.codemotive?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.finmotive_expensecontra.tree";
            this.button2.Text = "Causale";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox7);
            this.groupBox6.Controls.Add(this.txtCodiceCausaleSpesaContributi);
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Location = new System.Drawing.Point(344, 32);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(328, 104);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Tag = "AutoManage.txtCodiceCausaleSpesaContributi.tree.(active = \'S\')";
            this.groupBox6.Text = "Causale di spesa";
            this.groupBox6.UseCompatibleTextRendering = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(120, 16);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(200, 56);
            this.textBox7.TabIndex = 2;
            this.textBox7.TabStop = false;
            this.textBox7.Tag = "finmotive_admintax.title";
            // 
            // txtCodiceCausaleSpesaContributi
            // 
            this.txtCodiceCausaleSpesaContributi.Location = new System.Drawing.Point(8, 78);
            this.txtCodiceCausaleSpesaContributi.Name = "txtCodiceCausaleSpesaContributi";
            this.txtCodiceCausaleSpesaContributi.Size = new System.Drawing.Size(312, 20);
            this.txtCodiceCausaleSpesaContributi.TabIndex = 20;
            this.txtCodiceCausaleSpesaContributi.Tag = "finmotive_admintax.codemotive?x";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 0;
            this.button4.TabStop = false;
            this.button4.Tag = "manage.finmotive_admintax.tree";
            this.button4.Text = "Causale";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Location = new System.Drawing.Point(2, 320);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(679, 137);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Gestione delle RITENUTE c/DIPENDENTE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtCodiceCausaleSpesaRitenuteLiq);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(341, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 104);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoManage.txtCodiceCausaleSpesaRitenuteLiq.tree.(active = \'S\')";
            this.groupBox1.Text = "Causale di spesa per Liquidazione periodica";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(200, 56);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "finmotive_expenseemploy.title";
            // 
            // txtCodiceCausaleSpesaRitenuteLiq
            // 
            this.txtCodiceCausaleSpesaRitenuteLiq.Location = new System.Drawing.Point(8, 78);
            this.txtCodiceCausaleSpesaRitenuteLiq.Name = "txtCodiceCausaleSpesaRitenuteLiq";
            this.txtCodiceCausaleSpesaRitenuteLiq.Size = new System.Drawing.Size(312, 20);
            this.txtCodiceCausaleSpesaRitenuteLiq.TabIndex = 50;
            this.txtCodiceCausaleSpesaRitenuteLiq.Tag = "finmotive_expenseemploy.codemotive?x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.finmotive_expenseemploy.tree";
            this.button1.Text = "Causale";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.txtCodiceCausaleEntrataRit);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 104);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoManage.txtCodiceCausaleEntrataRit.tree.(active = \'S\')";
            this.groupBox3.Text = "Causale di entrata";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(120, 16);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(200, 56);
            this.textBox4.TabIndex = 2;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "finmotive_incomeemploy.title";
            // 
            // txtCodiceCausaleEntrataRit
            // 
            this.txtCodiceCausaleEntrataRit.Location = new System.Drawing.Point(8, 78);
            this.txtCodiceCausaleEntrataRit.Name = "txtCodiceCausaleEntrataRit";
            this.txtCodiceCausaleEntrataRit.Size = new System.Drawing.Size(312, 20);
            this.txtCodiceCausaleEntrataRit.TabIndex = 40;
            this.txtCodiceCausaleEntrataRit.Tag = "finmotive_incomeemploy.codemotive?x";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Tag = "manage.finmotive_incomeemploy.tree";
            this.button3.Text = "Causale";
            // 
            // Frm_taxfinmotive_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 517);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpPrestazione);
            this.Name = "Frm_taxfinmotive_single";
            this.Text = "Frm_taxfinmotive_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpPrestazione.ResumeLayout(false);
            this.gboxCausale.ResumeLayout(false);
            this.gboxCausale.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grpPrestazione;
        private System.Windows.Forms.Button btnTipoPrestazione;
        private System.Windows.Forms.ComboBox cmbTipoPrestazione;
        private System.Windows.Forms.GroupBox gboxCausale;
        private System.Windows.Forms.TextBox TxtDescrCausaleDeb;
        private System.Windows.Forms.TextBox txtCodiceCausaleEntrataContributi;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtCodiceCausaleSpesaContributiLiq;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox txtCodiceCausaleSpesaContributi;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCodiceCausaleSpesaRitenuteLiq;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtCodiceCausaleEntrataRit;
        private System.Windows.Forms.Button button3;

    }
}
