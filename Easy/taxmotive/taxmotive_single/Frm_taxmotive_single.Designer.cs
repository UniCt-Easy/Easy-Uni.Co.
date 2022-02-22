
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace taxmotive_single {
    partial class Frm_taxmotive_single {
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
            this.DS = new taxmotive_single.vistaForm();
            this.grpCausale = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneCausale = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.grpPrestazione = new System.Windows.Forms.GroupBox();
            this.btnTipoPrestazione = new System.Windows.Forms.Button();
            this.cmbTipoPrestazione = new System.Windows.Forms.ComboBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpCausale.SuspendLayout();
            this.grpPrestazione.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grpCausale
            // 
            this.grpCausale.Controls.Add(this.txtDescrizioneCausale);
            this.grpCausale.Controls.Add(this.txtCodiceCausale);
            this.grpCausale.Controls.Add(this.button2);
            this.grpCausale.Location = new System.Drawing.Point(12, 103);
            this.grpCausale.Name = "grpCausale";
            this.grpCausale.Size = new System.Drawing.Size(328, 116);
            this.grpCausale.TabIndex = 2;
            this.grpCausale.TabStop = false;
            this.grpCausale.Tag = "AutoManage.txtCodiceCausale.tree";
            this.grpCausale.Text = "Causale di Costo";
            // 
            // txtDescrizioneCausale
            // 
            this.txtDescrizioneCausale.Location = new System.Drawing.Point(120, 16);
            this.txtDescrizioneCausale.Multiline = true;
            this.txtDescrizioneCausale.Name = "txtDescrizioneCausale";
            this.txtDescrizioneCausale.ReadOnly = true;
            this.txtDescrizioneCausale.Size = new System.Drawing.Size(202, 56);
            this.txtDescrizioneCausale.TabIndex = 2;
            this.txtDescrizioneCausale.TabStop = false;
            this.txtDescrizioneCausale.Tag = "accmotiveapplied.motive";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Location = new System.Drawing.Point(6, 83);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(316, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 0;
            this.button2.Tag = "manage.accmotiveapplied.tree";
            this.button2.Text = "Causale";
            // 
            // grpPrestazione
            // 
            this.grpPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPrestazione.Controls.Add(this.btnTipoPrestazione);
            this.grpPrestazione.Controls.Add(this.cmbTipoPrestazione);
            this.grpPrestazione.Location = new System.Drawing.Point(12, 49);
            this.grpPrestazione.Name = "grpPrestazione";
            this.grpPrestazione.Size = new System.Drawing.Size(505, 48);
            this.grpPrestazione.TabIndex = 9;
            this.grpPrestazione.TabStop = false;
            this.grpPrestazione.Text = "Prestazione";
            // 
            // btnTipoPrestazione
            // 
            this.btnTipoPrestazione.Location = new System.Drawing.Point(8, 16);
            this.btnTipoPrestazione.Name = "btnTipoPrestazione";
            this.btnTipoPrestazione.Size = new System.Drawing.Size(75, 24);
            this.btnTipoPrestazione.TabIndex = 1;
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
            this.cmbTipoPrestazione.Size = new System.Drawing.Size(401, 21);
            this.cmbTipoPrestazione.TabIndex = 2;
            this.cmbTipoPrestazione.Tag = "taxmotive.idser";
            this.cmbTipoPrestazione.ValueMember = "idser";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(374, 234);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 14;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(475, 234);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // Frm_taxmotive_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 284);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpPrestazione);
            this.Controls.Add(this.grpCausale);
            this.Name = "Frm_taxmotive_single";
            this.Text = "Frm_taxmotive_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpCausale.ResumeLayout(false);
            this.grpCausale.PerformLayout();
            this.grpPrestazione.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox grpCausale;
        private System.Windows.Forms.TextBox txtDescrizioneCausale;
        private System.Windows.Forms.TextBox txtCodiceCausale;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox grpPrestazione;
        private System.Windows.Forms.Button btnTipoPrestazione;
        private System.Windows.Forms.ComboBox cmbTipoPrestazione;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;

    }
}
