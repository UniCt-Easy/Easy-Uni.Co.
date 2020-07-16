/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿namespace csa_importriep_partition_expense_detail {
    partial class Frm_csa_importriep_partition_expense_detail {
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
			this.grpImporto = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtNumRiep = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.DS = new csa_importriep_partition_expense_detail.vistaForm();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.gboxSpesa = new System.Windows.Forms.GroupBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNum = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtEserc = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grpImporto.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.gboxSpesa.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpImporto
			// 
			this.grpImporto.Controls.Add(this.label11);
			this.grpImporto.Controls.Add(this.txtImporto);
			this.grpImporto.Location = new System.Drawing.Point(339, 6);
			this.grpImporto.Name = "grpImporto";
			this.grpImporto.Size = new System.Drawing.Size(162, 44);
			this.grpImporto.TabIndex = 14;
			this.grpImporto.TabStop = false;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(5, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 16);
			this.label11.TabIndex = 0;
			this.label11.Text = "Importo:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImporto
			// 
			this.txtImporto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImporto.Location = new System.Drawing.Point(67, 12);
			this.txtImporto.Multiline = true;
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(89, 20);
			this.txtImporto.TabIndex = 14;
			this.txtImporto.TabStop = false;
			this.txtImporto.Tag = "csa_importriep_partition_expense.amount";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtNumRiep);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Location = new System.Drawing.Point(17, 6);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(144, 46);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			this.groupBox4.Tag = "";
			this.groupBox4.Text = "Riepilogo";
			// 
			// txtNumRiep
			// 
			this.txtNumRiep.Location = new System.Drawing.Point(82, 18);
			this.txtNumRiep.Name = "txtNumRiep";
			this.txtNumRiep.Size = new System.Drawing.Size(56, 20);
			this.txtNumRiep.TabIndex = 3;
			this.txtNumRiep.Tag = "csa_importriep_partition_expense.idriep";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(18, 18);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Numero:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(178, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(144, 46);
			this.groupBox1.TabIndex = 19;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "";
			this.groupBox1.Text = "Dettaglio";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(82, 18);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(56, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Tag = "csa_importriep_partition_expense.ndetail";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Numero:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(463, 261);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 21;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(383, 261);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 20;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(208, 52);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account.title";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(8, 72);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(336, 20);
			this.txtCodiceConto.TabIndex = 4;
			this.txtCodiceConto.Tag = "account.codeacc";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(10, 45);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(120, 23);
			this.button5.TabIndex = 1;
			this.button5.TabStop = false;
			this.button5.Tag = "manage.account.tree";
			this.button5.Text = "Conto";
			// 
			// gboxSpesa
			// 
			this.gboxSpesa.Controls.Add(this.txtDescription);
			this.gboxSpesa.Controls.Add(this.label7);
			this.gboxSpesa.Controls.Add(this.txtNum);
			this.gboxSpesa.Controls.Add(this.label13);
			this.gboxSpesa.Controls.Add(this.txtEserc);
			this.gboxSpesa.Controls.Add(this.label12);
			this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
			this.gboxSpesa.Location = new System.Drawing.Point(17, 125);
			this.gboxSpesa.Name = "gboxSpesa";
			this.gboxSpesa.Size = new System.Drawing.Size(523, 125);
			this.gboxSpesa.TabIndex = 22;
			this.gboxSpesa.TabStop = false;
			this.gboxSpesa.Text = "Movimento di Spesa";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(6, 14);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(511, 44);
			this.txtDescription.TabIndex = 6;
			this.txtDescription.Tag = "expenseview.description";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(39, 64);
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
			this.txtNum.Location = new System.Drawing.Point(217, 89);
			this.txtNum.Name = "txtNum";
			this.txtNum.Size = new System.Drawing.Size(97, 20);
			this.txtNum.TabIndex = 5;
			this.txtNum.Tag = "expenseview.nmov";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(158, 89);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(54, 16);
			this.label13.TabIndex = 4;
			this.label13.Text = "Numero:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEserc
			// 
			this.txtEserc.Location = new System.Drawing.Point(86, 89);
			this.txtEserc.Name = "txtEserc";
			this.txtEserc.Size = new System.Drawing.Size(56, 20);
			this.txtEserc.TabIndex = 3;
			this.txtEserc.Tag = "expenseview.ymov";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(5, 90);
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
			this.cmbFaseSpesa.Location = new System.Drawing.Point(86, 65);
			this.cmbFaseSpesa.Name = "cmbFaseSpesa";
			this.cmbFaseSpesa.Size = new System.Drawing.Size(228, 21);
			this.cmbFaseSpesa.TabIndex = 2;
			this.cmbFaseSpesa.Tag = "";
			this.cmbFaseSpesa.ValueMember = "nphase";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(23, 85);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(511, 22);
			this.textBox2.TabIndex = 23;
			this.textBox2.Tag = "expenseview.registry";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(22, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 16);
			this.label2.TabIndex = 24;
			this.label2.Text = "Anagrafica";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Frm_csa_importriep_partition_expense_detail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(552, 298);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.gboxSpesa);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.grpImporto);
			this.Name = "Frm_csa_importriep_partition_expense_detail";
			this.Text = "Frm_csa_importriep_partition_expense_detail";
			this.grpImporto.ResumeLayout(false);
			this.grpImporto.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxSpesa.ResumeLayout(false);
			this.gboxSpesa.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

            }

        #endregion
        public vistaForm DS;
        private System.Windows.Forms.GroupBox grpImporto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNumRiep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtDenominazioneConto;
        private System.Windows.Forms.TextBox txtCodiceConto;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox gboxSpesa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEserc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbFaseSpesa;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
    }