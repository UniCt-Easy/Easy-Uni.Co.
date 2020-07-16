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

﻿namespace csa_contractkinddata_elenco {
    partial class Frm_csa_contractkinddata_elenco {
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
            this.gboxclassSiope = new System.Windows.Forms.GroupBox();
            this.btnCodiceSiope = new System.Windows.Forms.Button();
            this.txtDenomSiope = new System.Windows.Forms.TextBox();
            this.txtCodiceSiope = new System.Windows.Forms.TextBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox69 = new System.Windows.Forms.GroupBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.txtEsercDoc = new System.Windows.Forms.TextBox();
            this.labEsercizio = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gboxtipo = new System.Windows.Forms.GroupBox();
            this.rdbCompetenza = new System.Windows.Forms.RadioButton();
            this.rdbResidui = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DS = new csa_contractkinddata_elenco.vistaForm();
            this.gboxclassSiope.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.groupBox69.SuspendLayout();
            this.gboxtipo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxclassSiope
            // 
            this.gboxclassSiope.Controls.Add(this.btnCodiceSiope);
            this.gboxclassSiope.Controls.Add(this.txtDenomSiope);
            this.gboxclassSiope.Controls.Add(this.txtCodiceSiope);
            this.gboxclassSiope.Location = new System.Drawing.Point(19, 271);
            this.gboxclassSiope.Name = "gboxclassSiope";
            this.gboxclassSiope.Size = new System.Drawing.Size(428, 135);
            this.gboxclassSiope.TabIndex = 13;
            this.gboxclassSiope.TabStop = false;
            this.gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.treeclassmovimenti";
            this.gboxclassSiope.Text = "Classificazione SIOPE";
            // 
            // btnCodiceSiope
            // 
            this.btnCodiceSiope.Location = new System.Drawing.Point(6, 81);
            this.btnCodiceSiope.Name = "btnCodiceSiope";
            this.btnCodiceSiope.Size = new System.Drawing.Size(88, 23);
            this.btnCodiceSiope.TabIndex = 4;
            this.btnCodiceSiope.TabStop = false;
            this.btnCodiceSiope.Tag = "manage.sorting.tree";
            this.btnCodiceSiope.Text = "Codice";
            this.btnCodiceSiope.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenomSiope
            // 
            this.txtDenomSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenomSiope.Location = new System.Drawing.Point(102, 16);
            this.txtDenomSiope.Multiline = true;
            this.txtDenomSiope.Name = "txtDenomSiope";
            this.txtDenomSiope.ReadOnly = true;
            this.txtDenomSiope.Size = new System.Drawing.Size(318, 88);
            this.txtDenomSiope.TabIndex = 3;
            this.txtDenomSiope.TabStop = false;
            this.txtDenomSiope.Tag = "sorting.description";
            // 
            // txtCodiceSiope
            // 
            this.txtCodiceSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodiceSiope.Location = new System.Drawing.Point(8, 110);
            this.txtCodiceSiope.Name = "txtCodiceSiope";
            this.txtCodiceSiope.Size = new System.Drawing.Size(412, 20);
            this.txtCodiceSiope.TabIndex = 2;
            this.txtCodiceSiope.Tag = "sorting.sortcode?x";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(19, 132);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(428, 133);
            this.gboxUPB.TabIndex = 11;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            this.gboxUPB.Text = "UPB per Imputazione Costo";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 107);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(414, 20);
            this.txtUPB.TabIndex = 9;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(8, 77);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(88, 24);
            this.btnUPB.TabIndex = 1;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "manage.upb.tree";
            this.btnUPB.Text = "UPB";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(120, 14);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(302, 87);
            this.txtDescrUPB.TabIndex = 2;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button2);
            this.gboxConto.Location = new System.Drawing.Point(464, 276);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(438, 130);
            this.gboxConto.TabIndex = 14;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            this.gboxConto.Text = "Conto EP di  Costo";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(116, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(316, 82);
            this.txtDenominazioneConto.TabIndex = 0;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "account.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(8, 104);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(424, 20);
            this.txtCodiceConto.TabIndex = 2;
            this.txtCodiceConto.Tag = "account.codeacc?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.account.tree";
            this.button2.Text = "Conto";
            // 
            // groupBox69
            // 
            this.groupBox69.Controls.Add(this.textBox23);
            this.groupBox69.Controls.Add(this.txtCodiceBilancio);
            this.groupBox69.Controls.Add(this.button16);
            this.groupBox69.Location = new System.Drawing.Point(464, 132);
            this.groupBox69.Name = "groupBox69";
            this.groupBox69.Size = new System.Drawing.Size(438, 133);
            this.groupBox69.TabIndex = 12;
            this.groupBox69.TabStop = false;
            this.groupBox69.Tag = "AutoManage.txtCodiceBilancio.trees";
            this.groupBox69.Text = "Voce di Bilancio per Imputazione Costo";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(116, 20);
            this.textBox23.Multiline = true;
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(316, 81);
            this.textBox23.TabIndex = 0;
            this.textBox23.TabStop = false;
            this.textBox23.Tag = "fin.title";
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(6, 107);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(426, 20);
            this.txtCodiceBilancio.TabIndex = 2;
            this.txtCodiceBilancio.Tag = "fin.codefin?x";
            // 
            // button16
            // 
            this.button16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button16.ImageIndex = 0;
            this.button16.Location = new System.Drawing.Point(8, 77);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(93, 24);
            this.button16.TabIndex = 1;
            this.button16.TabStop = false;
            this.button16.Tag = "manage.fin.trees";
            this.button16.Text = "Bilancio";
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(519, 41);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.Size = new System.Drawing.Size(80, 20);
            this.txtEsercDoc.TabIndex = 9;
            this.txtEsercDoc.TabStop = false;
            this.txtEsercDoc.Tag = "csa_contractkinddata.ayear";
            // 
            // labEsercizio
            // 
            this.labEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEsercizio.Location = new System.Drawing.Point(462, 43);
            this.labEsercizio.Name = "labEsercizio";
            this.labEsercizio.Size = new System.Drawing.Size(55, 16);
            this.labEsercizio.TabIndex = 7;
            this.labEsercizio.Text = "Esercizio";
            this.labEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tipo
            // 
            this.tipo.Location = new System.Drawing.Point(463, 100);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(433, 20);
            this.tipo.TabIndex = 10;
            this.tipo.Tag = "csa_contractkinddata.vocecsa";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(463, 74);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Voce CSA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(347, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 20);
            this.textBox3.TabIndex = 20;
            this.textBox3.Tag = "csa_contractkind.idcsa_contractkind";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(344, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 15;
            this.label4.Tag = "";
            this.label4.Text = "Numero";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gboxtipo
            // 
            this.gboxtipo.Controls.Add(this.rdbCompetenza);
            this.gboxtipo.Controls.Add(this.rdbResidui);
            this.gboxtipo.Location = new System.Drawing.Point(205, 8);
            this.gboxtipo.Name = "gboxtipo";
            this.gboxtipo.Size = new System.Drawing.Size(135, 56);
            this.gboxtipo.TabIndex = 19;
            this.gboxtipo.TabStop = false;
            this.gboxtipo.Text = "Tipo";
            // 
            // rdbCompetenza
            // 
            this.rdbCompetenza.Location = new System.Drawing.Point(18, 16);
            this.rdbCompetenza.Name = "rdbCompetenza";
            this.rdbCompetenza.Size = new System.Drawing.Size(96, 16);
            this.rdbCompetenza.TabIndex = 2;
            this.rdbCompetenza.Tag = "csa_contractkind.flagcr:C";
            this.rdbCompetenza.Text = "Competenza";
            // 
            // rdbResidui
            // 
            this.rdbResidui.Location = new System.Drawing.Point(18, 35);
            this.rdbResidui.Name = "rdbResidui";
            this.rdbResidui.Size = new System.Drawing.Size(96, 16);
            this.rdbResidui.TabIndex = 3;
            this.rdbResidui.Tag = "csa_contractkind.flagcr:R";
            this.rdbResidui.Text = "Residui";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Descrizione:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Tag = "csa_contractkind.contractkindcode";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(5, 90);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(417, 20);
            this.textBox2.TabIndex = 21;
            this.textBox2.Tag = "csa_contractkind.description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Codice:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.gboxtipo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 114);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regola generale CSA";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_csa_contractkinddata_elenco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 417);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxclassSiope);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.gboxConto);
            this.Controls.Add(this.groupBox69);
            this.Controls.Add(this.txtEsercDoc);
            this.Controls.Add(this.labEsercizio);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.label2);
            this.Name = "Frm_csa_contractkinddata_elenco";
            this.Text = "Frm_csa_contractkinddata_elenco";
            this.gboxclassSiope.ResumeLayout(false);
            this.gboxclassSiope.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.groupBox69.ResumeLayout(false);
            this.groupBox69.PerformLayout();
            this.gboxtipo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        public System.Windows.Forms.GroupBox gboxclassSiope;
        public System.Windows.Forms.Button btnCodiceSiope;
        private System.Windows.Forms.TextBox txtDenomSiope;
        private System.Windows.Forms.TextBox txtCodiceSiope;
        private System.Windows.Forms.GroupBox gboxUPB;
        public System.Windows.Forms.TextBox txtUPB;
        private System.Windows.Forms.Button btnUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.GroupBox gboxConto;
        private System.Windows.Forms.TextBox txtDenominazioneConto;
        private System.Windows.Forms.TextBox txtCodiceConto;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox69;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox txtCodiceBilancio;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.TextBox txtEsercDoc;
        private System.Windows.Forms.Label labEsercizio;
        private System.Windows.Forms.TextBox tipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gboxtipo;
        private System.Windows.Forms.RadioButton rdbCompetenza;
        private System.Windows.Forms.RadioButton rdbResidui;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}