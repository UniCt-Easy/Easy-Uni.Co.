
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


namespace sisest_corsolaurea_default {
    partial class frmsisest_corsolaurea_default {
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
            this.lblCodiceCorso = new System.Windows.Forms.Label();
            this.txtCodiceCorso = new System.Windows.Forms.TextBox();
            this.lblDescrizione = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtCorsolaurea = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabAnalitico = new System.Windows.Forms.TabPage();
            this.gboxclass3 = new System.Windows.Forms.GroupBox();
            this.btnCodice3 = new System.Windows.Forms.Button();
            this.txtDenom3 = new System.Windows.Forms.TextBox();
            this.txtCodice3 = new System.Windows.Forms.TextBox();
            this.gboxclass2 = new System.Windows.Forms.GroupBox();
            this.btnCodice2 = new System.Windows.Forms.Button();
            this.txtDenom2 = new System.Windows.Forms.TextBox();
            this.txtCodice2 = new System.Windows.Forms.TextBox();
            this.gboxclass1 = new System.Windows.Forms.GroupBox();
            this.btnCodice1 = new System.Windows.Forms.Button();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtCodice1 = new System.Windows.Forms.TextBox();
            this.DS = new sisest_corsolaurea_default.dsmeta();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabAnalitico.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodiceCorso
            // 
            this.lblCodiceCorso.AutoSize = true;
            this.lblCodiceCorso.Location = new System.Drawing.Point(4, 45);
            this.lblCodiceCorso.Name = "lblCodiceCorso";
            this.lblCodiceCorso.Size = new System.Drawing.Size(70, 13);
            this.lblCodiceCorso.TabIndex = 214;
            this.lblCodiceCorso.Tag = "";
            this.lblCodiceCorso.Text = "Codice Corso";
            // 
            // txtCodiceCorso
            // 
            this.txtCodiceCorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceCorso.Location = new System.Drawing.Point(98, 45);
            this.txtCodiceCorso.Multiline = true;
            this.txtCodiceCorso.Name = "txtCodiceCorso";
            this.txtCodiceCorso.Size = new System.Drawing.Size(333, 46);
            this.txtCodiceCorso.TabIndex = 215;
            this.txtCodiceCorso.Tag = "sisest_corsolaurea.codicecorso";
            // 
            // lblDescrizione
            // 
            this.lblDescrizione.AutoSize = true;
            this.lblDescrizione.Location = new System.Drawing.Point(6, 121);
            this.lblDescrizione.Name = "lblDescrizione";
            this.lblDescrizione.Size = new System.Drawing.Size(62, 13);
            this.lblDescrizione.TabIndex = 218;
            this.lblDescrizione.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(98, 121);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(333, 175);
            this.txtDescrizione.TabIndex = 219;
            this.txtDescrizione.Tag = "sisest_corsolaurea.descrizione";
            // 
            // txtCorsolaurea
            // 
            this.txtCorsolaurea.Location = new System.Drawing.Point(98, 6);
            this.txtCorsolaurea.Name = "txtCorsolaurea";
            this.txtCorsolaurea.Size = new System.Drawing.Size(184, 20);
            this.txtCorsolaurea.TabIndex = 217;
            this.txtCorsolaurea.Tag = "sisest_corsolaurea.idcorsolaurea";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 216;
            this.label12.Text = "Numero Corso";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabAnalitico);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(445, 328);
            this.tabControl1.TabIndex = 220;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCorsolaurea);
            this.tabPage1.Controls.Add(this.txtDescrizione);
            this.tabPage1.Controls.Add(this.lblCodiceCorso);
            this.tabPage1.Controls.Add(this.lblDescrizione);
            this.tabPage1.Controls.Add(this.txtCodiceCorso);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(437, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabAnalitico
            // 
            this.tabAnalitico.Controls.Add(this.gboxclass3);
            this.tabAnalitico.Controls.Add(this.gboxclass2);
            this.tabAnalitico.Controls.Add(this.gboxclass1);
            this.tabAnalitico.Location = new System.Drawing.Point(4, 22);
            this.tabAnalitico.Name = "tabAnalitico";
            this.tabAnalitico.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalitico.Size = new System.Drawing.Size(437, 302);
            this.tabAnalitico.TabIndex = 1;
            this.tabAnalitico.Text = "Analitico";
            this.tabAnalitico.UseVisualStyleBackColor = true;
            // 
            // gboxclass3
            // 
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(11, 196);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(404, 97);
            this.gboxclass3.TabIndex = 6;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(13, 42);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(88, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(112, 19);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(284, 46);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice3.Location = new System.Drawing.Point(8, 71);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(393, 20);
            this.txtCodice3.TabIndex = 4;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(11, 101);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(404, 89);
            this.gboxclass2.TabIndex = 5;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(8, 34);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(88, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(112, 19);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(284, 41);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice2.Location = new System.Drawing.Point(8, 63);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(388, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(11, 6);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(404, 89);
            this.gboxclass1.TabIndex = 4;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(8, 37);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(112, 19);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(284, 41);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice1.Location = new System.Drawing.Point(8, 63);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(388, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // frmsisest_corsolaurea_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 349);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmsisest_corsolaurea_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabAnalitico.ResumeLayout(false);
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public sisest_corsolaurea_default.dsmeta DS;
        private System.Windows.Forms.Label lblCodiceCorso;
        private System.Windows.Forms.TextBox txtCodiceCorso;
        private System.Windows.Forms.Label lblDescrizione;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtCorsolaurea;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabAnalitico;
        public System.Windows.Forms.GroupBox gboxclass3;
        public System.Windows.Forms.Button btnCodice3;
        public System.Windows.Forms.TextBox txtDenom3;
        public System.Windows.Forms.TextBox txtCodice3;
        public System.Windows.Forms.GroupBox gboxclass2;
        public System.Windows.Forms.Button btnCodice2;
        public System.Windows.Forms.TextBox txtDenom2;
        public System.Windows.Forms.TextBox txtCodice2;
        public System.Windows.Forms.GroupBox gboxclass1;
        public System.Windows.Forms.Button btnCodice1;
        public System.Windows.Forms.TextBox txtDenom1;
        public System.Windows.Forms.TextBox txtCodice1;
    }
}

