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

﻿namespace ct_asscreddetail_default {
    partial class Frm_ct_asscreddetail_default {
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
            this.DS = new ct_asscreddetail_default.VistaForm();
            this.txtPercentuale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBilancioSpesa = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioSpesa = new System.Windows.Forms.TextBox();
            this.txtBilancioSpesa = new System.Windows.Forms.TextBox();
            this.btnBilancioSpesa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumAssegnazione = new System.Windows.Forms.TextBox();
            this.grpBilancioEntrata = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioEntrata = new System.Windows.Forms.TextBox();
            this.txtBilancioEntrata = new System.Windows.Forms.TextBox();
            this.btnBilancioEntrata = new System.Windows.Forms.Button();
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.txtDenom = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpBilancioSpesa.SuspendLayout();
            this.grpBilancioEntrata.SuspendLayout();
            this.gboxclass.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "VistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtPercentuale
            // 
            this.txtPercentuale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercentuale.Location = new System.Drawing.Point(601, 304);
            this.txtPercentuale.Name = "txtPercentuale";
            this.txtPercentuale.Size = new System.Drawing.Size(72, 20);
            this.txtPercentuale.TabIndex = 76;
            this.txtPercentuale.Tag = "ct_asscreddetail.quota.fixed.2..%.100";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(433, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 77;
            this.label2.Text = "Percentuale di assegnazione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBilancioSpesa
            // 
            this.grpBilancioSpesa.Controls.Add(this.txtDescrBilancioSpesa);
            this.grpBilancioSpesa.Controls.Add(this.txtBilancioSpesa);
            this.grpBilancioSpesa.Controls.Add(this.btnBilancioSpesa);
            this.grpBilancioSpesa.Location = new System.Drawing.Point(330, 171);
            this.grpBilancioSpesa.Name = "grpBilancioSpesa";
            this.grpBilancioSpesa.Size = new System.Drawing.Size(348, 112);
            this.grpBilancioSpesa.TabIndex = 75;
            this.grpBilancioSpesa.TabStop = false;
            this.grpBilancioSpesa.Tag = "AutoManage.txtBilancioSpesa.treeS";
            this.grpBilancioSpesa.Text = "Voce di bilancio di spesa";
            // 
            // txtDescrBilancioSpesa
            // 
            this.txtDescrBilancioSpesa.Location = new System.Drawing.Point(126, 16);
            this.txtDescrBilancioSpesa.Multiline = true;
            this.txtDescrBilancioSpesa.Name = "txtDescrBilancioSpesa";
            this.txtDescrBilancioSpesa.ReadOnly = true;
            this.txtDescrBilancioSpesa.Size = new System.Drawing.Size(217, 64);
            this.txtDescrBilancioSpesa.TabIndex = 54;
            this.txtDescrBilancioSpesa.TabStop = false;
            this.txtDescrBilancioSpesa.Tag = "finspesa.title";
            // 
            // txtBilancioSpesa
            // 
            this.txtBilancioSpesa.Location = new System.Drawing.Point(8, 86);
            this.txtBilancioSpesa.Name = "txtBilancioSpesa";
            this.txtBilancioSpesa.Size = new System.Drawing.Size(335, 20);
            this.txtBilancioSpesa.TabIndex = 52;
            this.txtBilancioSpesa.Tag = "finspesa.codefin?ct_asscreddetailview.finexpensecode";
            // 
            // btnBilancioSpesa
            // 
            this.btnBilancioSpesa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioSpesa.ImageIndex = 0;
            this.btnBilancioSpesa.Location = new System.Drawing.Point(8, 60);
            this.btnBilancioSpesa.Name = "btnBilancioSpesa";
            this.btnBilancioSpesa.Size = new System.Drawing.Size(112, 20);
            this.btnBilancioSpesa.TabIndex = 62;
            this.btnBilancioSpesa.TabStop = false;
            this.btnBilancioSpesa.Tag = "manage.fin.treeS";
            this.btnBilancioSpesa.Text = "Bilancio:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumAssegnazione
            // 
            this.txtNumAssegnazione.Location = new System.Drawing.Point(86, 21);
            this.txtNumAssegnazione.Name = "txtNumAssegnazione";
            this.txtNumAssegnazione.Size = new System.Drawing.Size(96, 20);
            this.txtNumAssegnazione.TabIndex = 80;
            this.txtNumAssegnazione.Tag = "ct_asscreddetail.idct_asscred?ct_asscreddetailview.idct_asscred";
            // 
            // grpBilancioEntrata
            // 
            this.grpBilancioEntrata.Controls.Add(this.txtDescrBilancioEntrata);
            this.grpBilancioEntrata.Controls.Add(this.txtBilancioEntrata);
            this.grpBilancioEntrata.Controls.Add(this.btnBilancioEntrata);
            this.grpBilancioEntrata.Location = new System.Drawing.Point(12, 47);
            this.grpBilancioEntrata.Name = "grpBilancioEntrata";
            this.grpBilancioEntrata.Size = new System.Drawing.Size(303, 109);
            this.grpBilancioEntrata.TabIndex = 78;
            this.grpBilancioEntrata.TabStop = false;
            this.grpBilancioEntrata.Tag = "AutoManage.txtBilancioEntrata.treeE";
            this.grpBilancioEntrata.Text = "Voce di bilancio di entrata";
            // 
            // txtDescrBilancioEntrata
            // 
            this.txtDescrBilancioEntrata.Location = new System.Drawing.Point(140, 10);
            this.txtDescrBilancioEntrata.Multiline = true;
            this.txtDescrBilancioEntrata.Name = "txtDescrBilancioEntrata";
            this.txtDescrBilancioEntrata.ReadOnly = true;
            this.txtDescrBilancioEntrata.Size = new System.Drawing.Size(158, 65);
            this.txtDescrBilancioEntrata.TabIndex = 54;
            this.txtDescrBilancioEntrata.TabStop = false;
            this.txtDescrBilancioEntrata.Tag = "fin.title";
            // 
            // txtBilancioEntrata
            // 
            this.txtBilancioEntrata.Location = new System.Drawing.Point(6, 83);
            this.txtBilancioEntrata.Name = "txtBilancioEntrata";
            this.txtBilancioEntrata.Size = new System.Drawing.Size(291, 20);
            this.txtBilancioEntrata.TabIndex = 52;
            this.txtBilancioEntrata.Tag = "fin.codefin?ct_asscreddetailview.finincomecode";
            // 
            // btnBilancioEntrata
            // 
            this.btnBilancioEntrata.ImageIndex = 0;
            this.btnBilancioEntrata.Location = new System.Drawing.Point(6, 58);
            this.btnBilancioEntrata.Name = "btnBilancioEntrata";
            this.btnBilancioEntrata.Size = new System.Drawing.Size(112, 20);
            this.btnBilancioEntrata.TabIndex = 62;
            this.btnBilancioEntrata.TabStop = false;
            this.btnBilancioEntrata.Tag = "manage.fin.treeE";
            this.btnBilancioEntrata.Text = "Bilancio:";
            // 
            // gboxclass
            // 
            this.gboxclass.Controls.Add(this.txtCodice);
            this.gboxclass.Controls.Add(this.btnCodice);
            this.gboxclass.Controls.Add(this.txtDenom);
            this.gboxclass.Location = new System.Drawing.Point(330, 47);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(348, 109);
            this.gboxclass.TabIndex = 82;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "AutoChoose.txtCodice.tree";
            this.gboxclass.Text = "Classificazione 1";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(6, 83);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(334, 20);
            this.txtCodice.TabIndex = 5;
            this.txtCodice.Tag = "sorting.sortcode?x";
            // 
            // btnCodice
            // 
            this.btnCodice.Location = new System.Drawing.Point(6, 52);
            this.btnCodice.Name = "btnCodice";
            this.btnCodice.Size = new System.Drawing.Size(102, 23);
            this.btnCodice.TabIndex = 4;
            this.btnCodice.Tag = "manage.sorting.treeall";
            this.btnCodice.Text = "Codice";
            this.btnCodice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom
            // 
            this.txtDenom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom.Location = new System.Drawing.Point(114, 19);
            this.txtDenom.Multiline = true;
            this.txtDenom.Name = "txtDenom";
            this.txtDenom.ReadOnly = true;
            this.txtDenom.Size = new System.Drawing.Size(226, 59);
            this.txtDenom.TabIndex = 3;
            this.txtDenom.TabStop = false;
            this.txtDenom.Tag = "sorting.description";
            // 
            // Frm_ct_asscreddetail_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 381);
            this.Controls.Add(this.gboxclass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumAssegnazione);
            this.Controls.Add(this.grpBilancioEntrata);
            this.Controls.Add(this.txtPercentuale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpBilancioSpesa);
            this.Name = "Frm_ct_asscreddetail_default";
            this.Text = "Frm_ct_asscreddetail_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpBilancioSpesa.ResumeLayout(false);
            this.grpBilancioSpesa.PerformLayout();
            this.grpBilancioEntrata.ResumeLayout(false);
            this.grpBilancioEntrata.PerformLayout();
            this.gboxclass.ResumeLayout(false);
            this.gboxclass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public VistaForm DS;
        private System.Windows.Forms.TextBox txtPercentuale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpBilancioSpesa;
        private System.Windows.Forms.TextBox txtDescrBilancioSpesa;
        private System.Windows.Forms.TextBox txtBilancioSpesa;
        private System.Windows.Forms.Button btnBilancioSpesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumAssegnazione;
        private System.Windows.Forms.GroupBox grpBilancioEntrata;
        private System.Windows.Forms.TextBox txtDescrBilancioEntrata;
        private System.Windows.Forms.TextBox txtBilancioEntrata;
        private System.Windows.Forms.Button btnBilancioEntrata;
        public System.Windows.Forms.GroupBox gboxclass;
        public System.Windows.Forms.TextBox txtCodice;
        public System.Windows.Forms.Button btnCodice;
        private System.Windows.Forms.TextBox txtDenom;

    }
}