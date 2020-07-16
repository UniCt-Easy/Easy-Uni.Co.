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

﻿namespace assetsubmanager_single {
    partial class Frm_assetsubmanager_single {
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
            this.DS = new assetsubmanager_single.vistaForm();
            this.label3 = new System.Windows.Forms.Label();
            this.grpSubManager = new System.Windows.Forms.GroupBox();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpSubManager.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Per inserire il subconsegnatario originale non inserire la data";
            // 
            // grpSubManager
            // 
            this.grpSubManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSubManager.Controls.Add(this.gboxResponsabile);
            this.grpSubManager.Controls.Add(this.textBox2);
            this.grpSubManager.Controls.Add(this.label1);
            this.grpSubManager.Location = new System.Drawing.Point(10, 36);
            this.grpSubManager.Name = "grpSubManager";
            this.grpSubManager.Size = new System.Drawing.Size(474, 126);
            this.grpSubManager.TabIndex = 8;
            this.grpSubManager.TabStop = false;
            this.grpSubManager.Tag = "";
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Location = new System.Drawing.Point(6, 75);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(462, 40);
            this.gboxResponsabile.TabIndex = 13;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(active=\'S\')";
            this.gboxResponsabile.Text = "Subconsegnatario";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(5, 14);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(451, 20);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(88, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Tag = "assetsubmanager.start";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Data inizio";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(327, 168);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(415, 168);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(69, 23);
            this.btnAnnulla.TabIndex = 10;
            this.btnAnnulla.Text = "Annulla";
            // 
            // Frm_assetsubmanager_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 223);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpSubManager);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Name = "Frm_assetsubmanager_single";
            this.Text = "Frm_assetsubmanager_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpSubManager.ResumeLayout(false);
            this.grpSubManager.PerformLayout();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpSubManager;
        private System.Windows.Forms.GroupBox gboxResponsabile;
        public System.Windows.Forms.TextBox txtResponsabile;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;

    }
}