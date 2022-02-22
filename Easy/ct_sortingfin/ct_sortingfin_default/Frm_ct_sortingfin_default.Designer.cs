
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


namespace ct_sortingfin_default {
    partial class Frm_ct_sortingfin_default {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            InChiusura = true;
            if (disposing && (components != null))
            {
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
            this.gboxBilancio = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.rdbEntrata = new System.Windows.Forms.RadioButton();
            this.rdbSpesa = new System.Windows.Forms.RadioButton();
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.txtDenom = new System.Windows.Forms.TextBox();
            this.DS = new ct_sortingfin_default.vistaForm();
            this.gboxBilancio.SuspendLayout();
            this.gboxclass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxBilancio
            // 
            this.gboxBilancio.Controls.Add(this.chkListTitle);
            this.gboxBilancio.Controls.Add(this.txtDescrBilancio);
            this.gboxBilancio.Controls.Add(this.txtBilancio);
            this.gboxBilancio.Controls.Add(this.btnBilancio);
            this.gboxBilancio.Controls.Add(this.rdbEntrata);
            this.gboxBilancio.Controls.Add(this.rdbSpesa);
            this.gboxBilancio.Location = new System.Drawing.Point(360, 25);
            this.gboxBilancio.Name = "gboxBilancio";
            this.gboxBilancio.Size = new System.Drawing.Size(329, 103);
            this.gboxBilancio.TabIndex = 6;
            this.gboxBilancio.TabStop = false;
            this.gboxBilancio.Tag = "";
            this.gboxBilancio.Text = "Bilancio";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 33);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(151, 16);
            this.chkListTitle.TabIndex = 33;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancio.Location = new System.Drawing.Point(165, 14);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(158, 56);
            this.txtDescrBilancio.TabIndex = 32;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "finview.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(2, 76);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(321, 20);
            this.txtBilancio.TabIndex = 6;
            this.txtBilancio.Tag = "finview.codefin?ct_sortingfinview.codefin";
            this.txtBilancio.Leave += new System.EventHandler(this.txtBilancio_Leave);
            // 
            // btnBilancio
            // 
            this.btnBilancio.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(2, 50);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(104, 20);
            this.btnBilancio.TabIndex = 5;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // rdbEntrata
            // 
            this.rdbEntrata.Checked = true;
            this.rdbEntrata.Location = new System.Drawing.Point(5, 15);
            this.rdbEntrata.Name = "rdbEntrata";
            this.rdbEntrata.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrata.TabIndex = 0;
            this.rdbEntrata.TabStop = true;
            this.rdbEntrata.Tag = "finview.finpart:E?x";
            this.rdbEntrata.Text = "Entrata";
            // 
            // rdbSpesa
            // 
            this.rdbSpesa.Location = new System.Drawing.Point(85, 15);
            this.rdbSpesa.Name = "rdbSpesa";
            this.rdbSpesa.Size = new System.Drawing.Size(64, 16);
            this.rdbSpesa.TabIndex = 1;
            this.rdbSpesa.Tag = "finview.finpart:S?x";
            this.rdbSpesa.Text = "Spesa";
            // 
            // gboxclass
            // 
            this.gboxclass.Controls.Add(this.txtCodice);
            this.gboxclass.Controls.Add(this.btnCodice);
            this.gboxclass.Controls.Add(this.txtDenom);
            this.gboxclass.Location = new System.Drawing.Point(21, 25);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(324, 103);
            this.gboxclass.TabIndex = 41;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "AutoChoose.txtCodice.tree";
            this.gboxclass.Text = "Classificazione 1";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(6, 74);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(310, 20);
            this.txtCodice.TabIndex = 5;
            this.txtCodice.Tag = "sorting.sortcode?x";
            // 
            // btnCodice
            // 
            this.btnCodice.Location = new System.Drawing.Point(6, 46);
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
            this.txtDenom.Location = new System.Drawing.Point(114, 16);
            this.txtDenom.Multiline = true;
            this.txtDenom.Name = "txtDenom";
            this.txtDenom.ReadOnly = true;
            this.txtDenom.Size = new System.Drawing.Size(202, 53);
            this.txtDenom.TabIndex = 3;
            this.txtDenom.TabStop = false;
            this.txtDenom.Tag = "sorting.description";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_ct_sortingfin_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 154);
            this.Controls.Add(this.gboxclass);
            this.Controls.Add(this.gboxBilancio);
            this.Name = "Frm_ct_sortingfin_default";
            this.Text = "Frm_ct_sortingfin_default";
            this.gboxBilancio.ResumeLayout(false);
            this.gboxBilancio.PerformLayout();
            this.gboxclass.ResumeLayout(false);
            this.gboxclass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox gboxBilancio;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.TextBox txtDescrBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.RadioButton rdbEntrata;
        private System.Windows.Forms.RadioButton rdbSpesa;
        public System.Windows.Forms.GroupBox gboxclass;
        public System.Windows.Forms.TextBox txtCodice;
        public System.Windows.Forms.Button btnCodice;
        private System.Windows.Forms.TextBox txtDenom;
    }
}
