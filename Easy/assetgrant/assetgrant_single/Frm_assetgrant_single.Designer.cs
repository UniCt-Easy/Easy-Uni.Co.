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

﻿namespace assetgrant_single {
    partial class Frm_assetgrant_single {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public vistaForm DS;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataDocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpBoxImpegniBudget;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtNumIxBudget;
        private System.Windows.Forms.TextBox txtEsercIxBudget;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing) {
        //    if (disposing && (components != null)) {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //#region Windows Form Designer generated code

        ///// <summary>
        ///// Required method for Designer support - do not modify
        ///// the contents of this method with the code editor.
        ///// </summary>
        //private void InitializeComponent() {
        //    this.btnOk = new System.Windows.Forms.Button();
        //    this.btnAnnulla = new System.Windows.Forms.Button();
        //    this.grpSubManager = new System.Windows.Forms.GroupBox();
        //    this.txtImporto = new System.Windows.Forms.TextBox();
        //    this.txtAnnoRisc = new System.Windows.Forms.TextBox();
        //    this.label2 = new System.Windows.Forms.Label();
        //    this.label1 = new System.Windows.Forms.Label();
        //    this.groupBox1 = new System.Windows.Forms.GroupBox();
        //    this.textBox3 = new System.Windows.Forms.TextBox();
        //    this.txtCodiceCausale = new System.Windows.Forms.TextBox();
        //    this.button4 = new System.Windows.Forms.Button();
        //    this.gboxFinanziamento = new System.Windows.Forms.GroupBox();
        //    this.txtFinanziamento = new System.Windows.Forms.TextBox();
        //    this.btnFinanziamento = new System.Windows.Forms.Button();
        //    this.grpBoxImpegniBudget = new System.Windows.Forms.GroupBox();
        //    this.label34 = new System.Windows.Forms.Label();
        //    this.label33 = new System.Windows.Forms.Label();
        //    this.txtNumIxBudget = new System.Windows.Forms.TextBox();
        //    this.txtEsercIxBudget = new System.Windows.Forms.TextBox();
        //    this.grpSubManager.SuspendLayout();
        //    this.groupBox1.SuspendLayout();
        //    this.gboxFinanziamento.SuspendLayout();
        //    this.grpBoxImpegniBudget.SuspendLayout();
        //    this.SuspendLayout();
        //    // 
        //    // btnOk
        //    // 
        //    this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        //    this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        //    this.btnOk.Location = new System.Drawing.Point(416, 344);
        //    this.btnOk.Name = "btnOk";
        //    this.btnOk.Size = new System.Drawing.Size(69, 23);
        //    this.btnOk.TabIndex = 15;
        //    this.btnOk.Tag = "mainsave";
        //    this.btnOk.Text = "Ok";
        //    // 
        //    // btnAnnulla
        //    // 
        //    this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        //    this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        //    this.btnAnnulla.Location = new System.Drawing.Point(511, 344);
        //    this.btnAnnulla.Name = "btnAnnulla";
        //    this.btnAnnulla.Size = new System.Drawing.Size(69, 23);
        //    this.btnAnnulla.TabIndex = 17;
        //    this.btnAnnulla.Text = "Annulla";
        //    // 
        //    // grpSubManager
        //    // 
        //    this.grpSubManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        //    | System.Windows.Forms.AnchorStyles.Left)
        //    | System.Windows.Forms.AnchorStyles.Right)));
        //    this.grpSubManager.Controls.Add(this.grpBoxImpegniBudget);
        //    this.grpSubManager.Controls.Add(this.gboxFinanziamento);
        //    this.grpSubManager.Controls.Add(this.groupBox1);
        //    this.grpSubManager.Controls.Add(this.txtImporto);
        //    this.grpSubManager.Controls.Add(this.txtAnnoRisc);
        //    this.grpSubManager.Controls.Add(this.label2);
        //    this.grpSubManager.Controls.Add(this.label1);
        //    this.grpSubManager.Location = new System.Drawing.Point(12, 12);
        //    this.grpSubManager.Name = "grpSubManager";
        //    this.grpSubManager.Size = new System.Drawing.Size(568, 312);
        //    this.grpSubManager.TabIndex = 16;
        //    this.grpSubManager.TabStop = false;
        //    this.grpSubManager.Tag = "";
        //    // 
        //    // txtImporto
        //    // 
        //    this.txtImporto.Location = new System.Drawing.Point(118, 262);
        //    this.txtImporto.Name = "txtImporto";
        //    this.txtImporto.Size = new System.Drawing.Size(112, 20);
        //    this.txtImporto.TabIndex = 16;
        //    this.txtImporto.Tag = "assetgrant.amount";
        //    // 
        //    // txtAnnoRisc
        //    // 
        //    this.txtAnnoRisc.Location = new System.Drawing.Point(118, 228);
        //    this.txtAnnoRisc.Name = "txtAnnoRisc";
        //    this.txtAnnoRisc.Size = new System.Drawing.Size(112, 20);
        //    this.txtAnnoRisc.TabIndex = 15;
        //    this.txtAnnoRisc.Tag = "assetgrant.ygrant";
        //    // 
        //    // label2
        //    // 
        //    this.label2.Location = new System.Drawing.Point(16, 265);
        //    this.label2.Name = "label2";
        //    this.label2.Size = new System.Drawing.Size(96, 17);
        //    this.label2.TabIndex = 11;
        //    this.label2.Text = "Importo risconto";
        //    // 
        //    // label1
        //    // 
        //    this.label1.Location = new System.Drawing.Point(16, 228);
        //    this.label1.Name = "label1";
        //    this.label1.Size = new System.Drawing.Size(80, 16);
        //    this.label1.TabIndex = 9;
        //    this.label1.Text = "Anno risconto";
        //    // 
        //    // groupBox1
        //    // 
        //    this.groupBox1.Controls.Add(this.textBox3);
        //    this.groupBox1.Controls.Add(this.txtCodiceCausale);
        //    this.groupBox1.Controls.Add(this.button4);
        //    this.groupBox1.Location = new System.Drawing.Point(19, 19);
        //    this.groupBox1.Name = "groupBox1";
        //    this.groupBox1.Size = new System.Drawing.Size(520, 84);
        //    this.groupBox1.TabIndex = 36;
        //    this.groupBox1.TabStop = false;
        //    this.groupBox1.Tag = "AutoManage.txtCodiceCausale.tree";
        //    this.groupBox1.Text = "Causale di Reddito";
        //    // 
        //    // textBox3
        //    // 
        //    this.textBox3.Location = new System.Drawing.Point(288, 18);
        //    this.textBox3.Multiline = true;
        //    this.textBox3.Name = "textBox3";
        //    this.textBox3.ReadOnly = true;
        //    this.textBox3.Size = new System.Drawing.Size(128, 56);
        //    this.textBox3.TabIndex = 2;
        //    this.textBox3.Tag = "accmotive.title?x";
        //    // 
        //    // txtCodiceCausale
        //    // 
        //    this.txtCodiceCausale.Location = new System.Drawing.Point(132, 22);
        //    this.txtCodiceCausale.Name = "txtCodiceCausale";
        //    this.txtCodiceCausale.Size = new System.Drawing.Size(104, 20);
        //    this.txtCodiceCausale.TabIndex = 1;
        //    this.txtCodiceCausale.Tag = "accmotive.codemotive?x";
        //    // 
        //    // button4
        //    // 
        //    this.button4.Location = new System.Drawing.Point(8, 18);
        //    this.button4.Name = "button4";
        //    this.button4.Size = new System.Drawing.Size(104, 24);
        //    this.button4.TabIndex = 0;
        //    this.button4.Tag = "manage.accmotive.tree";
        //    this.button4.Text = "Causale";
        //    // 
        //    // gboxFinanziamento
        //    // 
        //    this.gboxFinanziamento.Controls.Add(this.txtFinanziamento);
        //    this.gboxFinanziamento.Controls.Add(this.btnFinanziamento);
        //    this.gboxFinanziamento.Location = new System.Drawing.Point(19, 109);
        //    this.gboxFinanziamento.Name = "gboxFinanziamento";
        //    this.gboxFinanziamento.Size = new System.Drawing.Size(520, 39);
        //    this.gboxFinanziamento.TabIndex = 37;
        //    this.gboxFinanziamento.TabStop = false;
        //    this.gboxFinanziamento.Tag = "AutoChoose.txtFinanziamento.default.(active = \'S\')";
        //    // 
        //    // txtFinanziamento
        //    // 
        //    this.txtFinanziamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        //    | System.Windows.Forms.AnchorStyles.Right)));
        //    this.txtFinanziamento.Location = new System.Drawing.Point(112, 11);
        //    this.txtFinanziamento.Multiline = true;
        //    this.txtFinanziamento.Name = "txtFinanziamento";
        //    this.txtFinanziamento.Size = new System.Drawing.Size(400, 22);
        //    this.txtFinanziamento.TabIndex = 2;
        //    this.txtFinanziamento.TabStop = false;
        //    this.txtFinanziamento.Tag = "underwriting.title";
        //    // 
        //    // btnFinanziamento
        //    // 
        //    this.btnFinanziamento.Location = new System.Drawing.Point(6, 9);
        //    this.btnFinanziamento.Name = "btnFinanziamento";
        //    this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
        //    this.btnFinanziamento.TabIndex = 0;
        //    this.btnFinanziamento.Tag = "choose.underwriting.default";
        //    this.btnFinanziamento.Text = "Finanziamento";
        //    this.btnFinanziamento.UseVisualStyleBackColor = true;
        //    // 
        //    // grpBoxImpegniBudget
        //    // 
        //    this.grpBoxImpegniBudget.Controls.Add(this.label34);
        //    this.grpBoxImpegniBudget.Controls.Add(this.label33);
        //    this.grpBoxImpegniBudget.Controls.Add(this.txtNumIxBudget);
        //    this.grpBoxImpegniBudget.Controls.Add(this.txtEsercIxBudget);
        //    this.grpBoxImpegniBudget.Location = new System.Drawing.Point(19, 154);
        //    this.grpBoxImpegniBudget.Name = "grpBoxImpegniBudget";
        //    this.grpBoxImpegniBudget.Size = new System.Drawing.Size(454, 52);
        //    this.grpBoxImpegniBudget.TabIndex = 49;
        //    this.grpBoxImpegniBudget.TabStop = false;
        //    this.grpBoxImpegniBudget.Text = "Accertamento di Budget";
        //    // 
        //    // label34
        //    // 
        //    this.label34.AutoSize = true;
        //    this.label34.Location = new System.Drawing.Point(224, 22);
        //    this.label34.Name = "label34";
        //    this.label34.Size = new System.Drawing.Size(44, 13);
        //    this.label34.TabIndex = 7;
        //    this.label34.Text = "Numero";
        //    // 
        //    // label33
        //    // 
        //    this.label33.AutoSize = true;
        //    this.label33.Location = new System.Drawing.Point(9, 25);
        //    this.label33.Name = "label33";
        //    this.label33.Size = new System.Drawing.Size(49, 13);
        //    this.label33.TabIndex = 6;
        //    this.label33.Text = "Esercizio";
        //    this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        //    // 
        //    // txtNumIxBudget
        //    // 
        //    this.txtNumIxBudget.Location = new System.Drawing.Point(288, 18);
        //    this.txtNumIxBudget.Name = "txtNumIxBudget";
        //    this.txtNumIxBudget.ReadOnly = true;
        //    this.txtNumIxBudget.Size = new System.Drawing.Size(64, 20);
        //    this.txtNumIxBudget.TabIndex = 3;
        //    this.txtNumIxBudget.TabStop = false;
        //    this.txtNumIxBudget.Tag = "epacc.nepacc";
        //    // 
        //    // txtEsercIxBudget
        //    // 
        //    this.txtEsercIxBudget.Location = new System.Drawing.Point(78, 19);
        //    this.txtEsercIxBudget.Name = "txtEsercIxBudget";
        //    this.txtEsercIxBudget.ReadOnly = true;
        //    this.txtEsercIxBudget.Size = new System.Drawing.Size(64, 20);
        //    this.txtEsercIxBudget.TabIndex = 2;
        //    this.txtEsercIxBudget.TabStop = false;
        //    this.txtEsercIxBudget.Tag = "epacc.yepacc";
        //    // 
        //    // Frm_assetgrant_single
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(592, 396);
        //    this.Controls.Add(this.btnOk);
        //    this.Controls.Add(this.btnAnnulla);
        //    this.Controls.Add(this.grpSubManager);
        //    this.Name = "Frm_assetgrant_single";
        //    this.Text = "frmassetgrantsingle";
        //    this.grpSubManager.ResumeLayout(false);
        //    this.grpSubManager.PerformLayout();
        //    this.groupBox1.ResumeLayout(false);
        //    this.groupBox1.PerformLayout();
        //    this.gboxFinanziamento.ResumeLayout(false);
        //    this.gboxFinanziamento.PerformLayout();
        //    this.grpBoxImpegniBudget.ResumeLayout(false);
        //    this.grpBoxImpegniBudget.PerformLayout();
        //    this.ResumeLayout(false);

        //}

        //#endregion

        //private System.Windows.Forms.Button btnOk;
        //private System.Windows.Forms.Button btnAnnulla;
        //private System.Windows.Forms.GroupBox grpSubManager;
        //private System.Windows.Forms.TextBox txtImporto;
        //private System.Windows.Forms.TextBox txtAnnoRisc;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.GroupBox gboxFinanziamento;
        //private System.Windows.Forms.TextBox txtFinanziamento;
        //private System.Windows.Forms.Button btnFinanziamento;
        //private System.Windows.Forms.GroupBox groupBox1;
        //private System.Windows.Forms.TextBox textBox3;
        //private System.Windows.Forms.TextBox txtCodiceCausale;
        //private System.Windows.Forms.Button button4;
        //private System.Windows.Forms.GroupBox grpBoxImpegniBudget;
        //private System.Windows.Forms.Label label34;
        //private System.Windows.Forms.Label label33;
        //private System.Windows.Forms.TextBox txtNumIxBudget;
        //private System.Windows.Forms.TextBox txtEsercIxBudget;
    }
}