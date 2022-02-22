
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


namespace ct_asscred_default {
    partial class Frm_ct_asscred_default {
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
            this.grpBilancioEntrata = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancioEntrata = new System.Windows.Forms.TextBox();
            this.txtBilancioEntrata = new System.Windows.Forms.TextBox();
            this.btnBilancioEntrata = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumAssegnazione = new System.Windows.Forms.TextBox();
            this.DS = new ct_asscred_default.VistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDettagli = new System.Windows.Forms.TabPage();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.txtDenom = new System.Windows.Forms.TextBox();
            this.grpBilancioEntrata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDettagli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.gboxclass.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBilancioEntrata
            // 
            this.grpBilancioEntrata.Controls.Add(this.txtDescrBilancioEntrata);
            this.grpBilancioEntrata.Controls.Add(this.txtBilancioEntrata);
            this.grpBilancioEntrata.Controls.Add(this.btnBilancioEntrata);
            this.grpBilancioEntrata.Location = new System.Drawing.Point(12, 57);
            this.grpBilancioEntrata.Name = "grpBilancioEntrata";
            this.grpBilancioEntrata.Size = new System.Drawing.Size(303, 109);
            this.grpBilancioEntrata.TabIndex = 2;
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
            this.txtBilancioEntrata.Tag = "fin.codefin?ct_asscredview.finincomecode";
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumAssegnazione
            // 
            this.txtNumAssegnazione.Location = new System.Drawing.Point(79, 19);
            this.txtNumAssegnazione.Name = "txtNumAssegnazione";
            this.txtNumAssegnazione.Size = new System.Drawing.Size(96, 20);
            this.txtNumAssegnazione.TabIndex = 37;
            this.txtNumAssegnazione.Tag = "ct_asscred.idct_asscred";
            // 
            // DS
            // 
            this.DS.DataSetName = "VistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDettagli);
            this.tabControl1.Location = new System.Drawing.Point(12, 182);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(633, 167);
            this.tabControl1.TabIndex = 39;
            this.tabControl1.TabStop = false;
            // 
            // tabDettagli
            // 
            this.tabDettagli.Controls.Add(this.btnInserisci);
            this.tabDettagli.Controls.Add(this.btnModifica);
            this.tabDettagli.Controls.Add(this.btnElimina);
            this.tabDettagli.Controls.Add(this.dataGrid1);
            this.tabDettagli.Location = new System.Drawing.Point(4, 22);
            this.tabDettagli.Name = "tabDettagli";
            this.tabDettagli.Padding = new System.Windows.Forms.Padding(3);
            this.tabDettagli.Size = new System.Drawing.Size(625, 141);
            this.tabDettagli.TabIndex = 1;
            this.tabDettagli.Text = "Dettagli assegnazioni";
            this.tabDettagli.UseVisualStyleBackColor = true;
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(6, 20);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(86, 26);
            this.btnInserisci.TabIndex = 12;
            this.btnInserisci.TabStop = false;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(6, 52);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(86, 26);
            this.btnModifica.TabIndex = 13;
            this.btnModifica.TabStop = false;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(6, 84);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(86, 26);
            this.btnElimina.TabIndex = 14;
            this.btnElimina.TabStop = false;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(98, 6);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(518, 129);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.Tag = "ct_asscreddetail.default.single";
            // 
            // gboxclass
            // 
            this.gboxclass.Controls.Add(this.txtCodice);
            this.gboxclass.Controls.Add(this.btnCodice);
            this.gboxclass.Controls.Add(this.txtDenom);
            this.gboxclass.Location = new System.Drawing.Point(321, 57);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(324, 109);
            this.gboxclass.TabIndex = 40;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "AutoChoose.txtCodice.tree";
            this.gboxclass.Text = "Classificazione 1";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(6, 83);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(310, 20);
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
            this.txtDenom.Size = new System.Drawing.Size(202, 59);
            this.txtDenom.TabIndex = 3;
            this.txtDenom.TabStop = false;
            this.txtDenom.Tag = "sorting.description";
            // 
            // Frm_ct_asscred_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 361);
            this.Controls.Add(this.gboxclass);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumAssegnazione);
            this.Controls.Add(this.grpBilancioEntrata);
            this.Name = "Frm_ct_asscred_default";
            this.Text = "Frm_ct_asscred_default";
            this.grpBilancioEntrata.ResumeLayout(false);
            this.grpBilancioEntrata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDettagli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.gboxclass.ResumeLayout(false);
            this.gboxclass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBilancioEntrata;
        private System.Windows.Forms.TextBox txtDescrBilancioEntrata;
        private System.Windows.Forms.TextBox txtBilancioEntrata;
        private System.Windows.Forms.Button btnBilancioEntrata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumAssegnazione;
        public VistaForm DS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDettagli;
        private System.Windows.Forms.Button btnInserisci;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.DataGrid dataGrid1;
        public System.Windows.Forms.GroupBox gboxclass;
        public System.Windows.Forms.TextBox txtCodice;
        public System.Windows.Forms.Button btnCodice;
        private System.Windows.Forms.TextBox txtDenom;
    }
}
