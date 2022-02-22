
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


namespace csa_contractregistry_elenco {
    partial class Frm_csa_contractregistry_elenco {
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
            this.DS = new csa_contractregistry_elenco.vistaForm();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.txtEsercDoc = new System.Windows.Forms.TextBox();
            this.labEsercizio = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpContrattoCSA = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoContratto = new System.Windows.Forms.ComboBox();
            this.txtNumOrdine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEsercContratto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupCredDeb.SuspendLayout();
            this.grpContrattoCSA.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(8, 146);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(427, 56);
            this.groupCredDeb.TabIndex = 8;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupCredDeb.Text = "Anagrafica";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 24);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(411, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title?x";
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(10, 122);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.ReadOnly = true;
            this.txtEsercDoc.Size = new System.Drawing.Size(80, 20);
            this.txtEsercDoc.TabIndex = 6;
            this.txtEsercDoc.Tag = "csa_contractregistry.ayear";
            // 
            // labEsercizio
            // 
            this.labEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEsercizio.Location = new System.Drawing.Point(10, 105);
            this.labEsercizio.Name = "labEsercizio";
            this.labEsercizio.Size = new System.Drawing.Size(55, 16);
            this.labEsercizio.TabIndex = 4;
            this.labEsercizio.Text = "Esercizio:";
            this.labEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tipo
            // 
            this.tipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tipo.Location = new System.Drawing.Point(104, 122);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(331, 20);
            this.tipo.TabIndex = 7;
            this.tipo.Tag = "csa_contractregistry.extmatricula";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(104, 105);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Matricola:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpContrattoCSA
            // 
            this.grpContrattoCSA.Controls.Add(this.label4);
            this.grpContrattoCSA.Controls.Add(this.cmbTipoContratto);
            this.grpContrattoCSA.Controls.Add(this.txtNumOrdine);
            this.grpContrattoCSA.Controls.Add(this.label3);
            this.grpContrattoCSA.Controls.Add(this.txtEsercContratto);
            this.grpContrattoCSA.Controls.Add(this.label5);
            this.grpContrattoCSA.Location = new System.Drawing.Point(10, 12);
            this.grpContrattoCSA.Name = "grpContrattoCSA";
            this.grpContrattoCSA.Size = new System.Drawing.Size(428, 72);
            this.grpContrattoCSA.TabIndex = 19;
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
            this.cmbTipoContratto.Tag = "csa_contract.idcsa_contractkind";
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
            // Frm_csa_contractregistry_elenco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 214);
            this.Controls.Add(this.grpContrattoCSA);
            this.Controls.Add(this.groupCredDeb);
            this.Controls.Add(this.txtEsercDoc);
            this.Controls.Add(this.labEsercizio);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.label2);
            this.Name = "Frm_csa_contractregistry_elenco";
            this.Text = "Frm_csa_contractregistry_elenco";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.grpContrattoCSA.ResumeLayout(false);
            this.grpContrattoCSA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupCredDeb;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.TextBox txtEsercDoc;
        private System.Windows.Forms.Label labEsercizio;
        private System.Windows.Forms.TextBox tipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpContrattoCSA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoContratto;
        private System.Windows.Forms.TextBox txtNumOrdine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercContratto;
        private System.Windows.Forms.Label label5;
    }
}
