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

﻿namespace pcc_default {
    partial class frmDifferenze {
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
            this.grdTrasmesso = new System.Windows.Forms.DataGrid();
            this.grdEsito = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProcedi = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrasmesso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEsito)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTrasmesso
            // 
            this.grdTrasmesso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTrasmesso.DataMember = "";
            this.grdTrasmesso.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdTrasmesso.Location = new System.Drawing.Point(12, 34);
            this.grdTrasmesso.Name = "grdTrasmesso";
            this.grdTrasmesso.Size = new System.Drawing.Size(970, 198);
            this.grdTrasmesso.TabIndex = 1;
            // 
            // grdEsito
            // 
            this.grdEsito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEsito.DataMember = "";
            this.grdEsito.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdEsito.Location = new System.Drawing.Point(12, 269);
            this.grdEsito.Name = "grdEsito";
            this.grdEsito.Size = new System.Drawing.Size(970, 209);
            this.grdEsito.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Righe del file trasmesso che non hanno corrispondenza nell\'esito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Righe del file di esito che non hanno corrispondenza nel  file trasmesso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(506, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Se si ritiene che il file dell\'esito si riferisca al file trasmesso procedere con" +
    " l\'operazione altrimenti la si annulli.";
            // 
            // btnProcedi
            // 
            this.btnProcedi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcedi.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnProcedi.Location = new System.Drawing.Point(779, 499);
            this.btnProcedi.Name = "btnProcedi";
            this.btnProcedi.Size = new System.Drawing.Size(75, 23);
            this.btnProcedi.TabIndex = 6;
            this.btnProcedi.Text = "Procedi";
            this.btnProcedi.UseVisualStyleBackColor = true;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(907, 499);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 7;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            // 
            // frmDifferenze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 544);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnProcedi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdEsito);
            this.Controls.Add(this.grdTrasmesso);
            this.Name = "frmDifferenze";
            this.Text = "frmDifferenze";
            ((System.ComponentModel.ISupportInitialize)(this.grdTrasmesso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEsito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGrid grdTrasmesso;
        private System.Windows.Forms.DataGrid grdEsito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcedi;
        private System.Windows.Forms.Button btnAnnulla;
    }
}