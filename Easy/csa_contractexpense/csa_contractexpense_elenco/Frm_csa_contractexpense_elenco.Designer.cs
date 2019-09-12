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

ï»¿namespace csa_contractexpense_elenco {
    partial class Frm_csa_contractexpense_elenco {
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
            this.gboxSpesa = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
            this.DS = new csa_contractexpense_elenco.vistaForm();
            this.txtQuota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpContrattoCSA = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoContratto = new System.Windows.Forms.ComboBox();
            this.txtNumOrdine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercContratto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbAttivo = new System.Windows.Forms.CheckBox();
            this.gboxSpesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpContrattoCSA.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxSpesa
            // 
            this.gboxSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxSpesa.Controls.Add(this.label7);
            this.gboxSpesa.Controls.Add(this.txtNum);
            this.gboxSpesa.Controls.Add(this.label13);
            this.gboxSpesa.Controls.Add(this.txtEserc);
            this.gboxSpesa.Controls.Add(this.label12);
            this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
            this.gboxSpesa.Location = new System.Drawing.Point(153, 122);
            this.gboxSpesa.Name = "gboxSpesa";
            this.gboxSpesa.Size = new System.Drawing.Size(284, 92);
            this.gboxSpesa.TabIndex = 16;
            this.gboxSpesa.TabStop = false;
            this.gboxSpesa.Text = "Movimento di Spesa a cui collegare il Lordo";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(52, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fase";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNum
            // 
            this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNum.Location = new System.Drawing.Point(230, 54);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(47, 20);
            this.txtNum.TabIndex = 5;
            this.txtNum.Tag = "expenseview.nmov?csa_contractexpenseview.nmov";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(171, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Numero:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(98, 54);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 3;
            this.txtEserc.Tag = "expenseview.ymov.year?csa_contractexpenseview.ymov.year";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(18, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Esercizio:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseSpesa
            // 
            this.cmbFaseSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFaseSpesa.DataSource = this.DS.expensephase;
            this.cmbFaseSpesa.DisplayMember = "description";
            this.cmbFaseSpesa.Location = new System.Drawing.Point(98, 30);
            this.cmbFaseSpesa.Name = "cmbFaseSpesa";
            this.cmbFaseSpesa.Size = new System.Drawing.Size(180, 21);
            this.cmbFaseSpesa.TabIndex = 2;
            this.cmbFaseSpesa.Tag = "expenseview.nphase?csa_contractexpenseview.nphase";
            this.cmbFaseSpesa.ValueMember = "nphase";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtQuota
            // 
            this.txtQuota.Location = new System.Drawing.Point(64, 140);
            this.txtQuota.Name = "txtQuota";
            this.txtQuota.Size = new System.Drawing.Size(72, 20);
            this.txtQuota.TabIndex = 14;
            this.txtQuota.Tag = "csa_contractexpense.quota.fixed.4..%.100";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Quota:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // grpContrattoCSA
            // 
            this.grpContrattoCSA.Controls.Add(this.ckbAttivo);
            this.grpContrattoCSA.Controls.Add(this.label4);
            this.grpContrattoCSA.Controls.Add(this.cmbTipoContratto);
            this.grpContrattoCSA.Controls.Add(this.txtNumOrdine);
            this.grpContrattoCSA.Controls.Add(this.label3);
            this.grpContrattoCSA.Controls.Add(this.txtEsercContratto);
            this.grpContrattoCSA.Controls.Add(this.label5);
            this.grpContrattoCSA.Location = new System.Drawing.Point(13, 12);
            this.grpContrattoCSA.Name = "grpContrattoCSA";
            this.grpContrattoCSA.Size = new System.Drawing.Size(428, 72);
            this.grpContrattoCSA.TabIndex = 20;
            this.grpContrattoCSA.TabStop = false;
            this.grpContrattoCSA.Text = "Regola specifica CSA";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tipo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoContratto
            // 
            this.cmbTipoContratto.DataSource = this.DS.csa_contractkind;
            this.cmbTipoContratto.DisplayMember = "description";
            this.cmbTipoContratto.Location = new System.Drawing.Point(80, 16);
            this.cmbTipoContratto.Name = "cmbTipoContratto";
            this.cmbTipoContratto.Size = new System.Drawing.Size(316, 21);
            this.cmbTipoContratto.TabIndex = 1;
            this.cmbTipoContratto.Tag = "csa_contract.idcsa_contractkind?csa_contractexpenseview.idcsa_contractkind";
            this.cmbTipoContratto.ValueMember = "idcsa_contractkind";
            // 
            // txtNumOrdine
            // 
            this.txtNumOrdine.Location = new System.Drawing.Point(216, 48);
            this.txtNumOrdine.Name = "txtNumOrdine";
            this.txtNumOrdine.Size = new System.Drawing.Size(56, 20);
            this.txtNumOrdine.TabIndex = 3;
            this.txtNumOrdine.Tag = "csa_contract.ncontract";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(152, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercContratto
            // 
            this.txtEsercContratto.Location = new System.Drawing.Point(80, 48);
            this.txtEsercContratto.Name = "txtEsercContratto";
            this.txtEsercContratto.Size = new System.Drawing.Size(56, 20);
            this.txtEsercContratto.TabIndex = 2;
            this.txtEsercContratto.Tag = "csa_contract.ycontract.year";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Esercizio:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(80, 112);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizio.TabIndex = 22;
            this.txtEsercizio.Tag = "csa_contractexpense.ayear.year?csa_contractexpenseview.ayear.year";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 32);
            this.label1.TabIndex = 21;
            this.label1.Text = "Esercizio Ripartizione:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ckbAttivo
            // 
            this.ckbAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbAttivo.Location = new System.Drawing.Point(291, 50);
            this.ckbAttivo.Name = "ckbAttivo";
            this.ckbAttivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ckbAttivo.Size = new System.Drawing.Size(74, 16);
            this.ckbAttivo.TabIndex = 7;
            this.ckbAttivo.TabStop = false;
            this.ckbAttivo.Tag = "csa_contract.active:S:N?csa_contractexpenseview.active:S:N";
            this.ckbAttivo.Text = "Attivo";
            // 
            // Frm_csa_contractexpense_elenco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 230);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpContrattoCSA);
            this.Controls.Add(this.gboxSpesa);
            this.Controls.Add(this.txtQuota);
            this.Controls.Add(this.label2);
            this.Name = "Frm_csa_contractexpense_elenco";
            this.Text = "Frm_csa_contractexpense_elenco";
            this.gboxSpesa.ResumeLayout(false);
            this.gboxSpesa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpContrattoCSA.ResumeLayout(false);
            this.grpContrattoCSA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxSpesa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEserc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbFaseSpesa;
        private System.Windows.Forms.TextBox txtQuota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpContrattoCSA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoContratto;
        private System.Windows.Forms.TextBox txtNumOrdine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercContratto;
        private System.Windows.Forms.Label label5;
        public vistaForm DS;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbAttivo;
    }
}