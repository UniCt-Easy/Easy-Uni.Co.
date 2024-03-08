
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


namespace admpay_incomesorted_detail {
    partial class FrmAdmPay_IncomeSorted_Detail {
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
            this.DS = new admpay_incomesorted_detail.vistaForm();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtSubmovimento = new System.Windows.Forms.TextBox();
            this.txtPercentuale = new System.Windows.Forms.TextBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPercentuale = new System.Windows.Forms.Label();
            this.lblImporto = new System.Windows.Forms.Label();
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxclass.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 152);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(504, 48);
            this.textBox1.TabIndex = 221;
            this.textBox1.Tag = "admpay_incomesorted.description";
            // 
            // txtSubmovimento
            // 
            this.txtSubmovimento.Location = new System.Drawing.Point(18, 111);
            this.txtSubmovimento.Name = "txtSubmovimento";
            this.txtSubmovimento.ReadOnly = true;
            this.txtSubmovimento.Size = new System.Drawing.Size(100, 20);
            this.txtSubmovimento.TabIndex = 229;
            this.txtSubmovimento.TabStop = false;
            this.txtSubmovimento.Tag = "admpay_incomesorted.idsubclass";
            // 
            // txtPercentuale
            // 
            this.txtPercentuale.Location = new System.Drawing.Point(162, 232);
            this.txtPercentuale.Name = "txtPercentuale";
            this.txtPercentuale.Size = new System.Drawing.Size(80, 20);
            this.txtPercentuale.TabIndex = 223;
            this.txtPercentuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentuale.Leave += new System.EventHandler(this.txtPercentuale_Leave);
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(14, 232);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(100, 20);
            this.txtImporto.TabIndex = 222;
            this.txtImporto.Tag = "admpay_incomesorted.amount";
            this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 231;
            this.label1.Text = "Descrizione";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 230;
            this.label3.Text = "Submovimento";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 228;
            this.label2.Text = "%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPercentuale
            // 
            this.lblPercentuale.Location = new System.Drawing.Point(162, 216);
            this.lblPercentuale.Name = "lblPercentuale";
            this.lblPercentuale.Size = new System.Drawing.Size(100, 23);
            this.lblPercentuale.TabIndex = 227;
            this.lblPercentuale.Text = "Percentuale";
            // 
            // lblImporto
            // 
            this.lblImporto.Location = new System.Drawing.Point(14, 216);
            this.lblImporto.Name = "lblImporto";
            this.lblImporto.Size = new System.Drawing.Size(100, 23);
            this.lblImporto.TabIndex = 226;
            this.lblImporto.Text = "Importo";
            // 
            // gboxclass
            // 
            this.gboxclass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass.Controls.Add(this.txtDescrizione);
            this.gboxclass.Controls.Add(this.txtCodice);
            this.gboxclass.Controls.Add(this.btnCodice);
            this.gboxclass.Location = new System.Drawing.Point(14, 15);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(516, 74);
            this.gboxclass.TabIndex = 220;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(152, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(348, 50);
            this.txtDescrizione.TabIndex = 3;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "sorting.description";
            // 
            // txtCodice
            // 
            this.txtCodice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice.Location = new System.Drawing.Point(8, 48);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(112, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.Tag = "sorting.sortcode?x";
            // 
            // btnCodice
            // 
            this.btnCodice.Location = new System.Drawing.Point(8, 16);
            this.btnCodice.Name = "btnCodice";
            this.btnCodice.Size = new System.Drawing.Size(80, 23);
            this.btnCodice.TabIndex = 1;
            this.btnCodice.TabStop = false;
            this.btnCodice.Tag = "manage.sorting.tree";
            this.btnCodice.Text = "Codice";
            this.btnCodice.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(340, 264);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 224;
            this.btnOk.TabStop = false;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(444, 264);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 225;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // FrmAdmPay_IncomeSorted_Detail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 302);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtSubmovimento);
            this.Controls.Add(this.txtPercentuale);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPercentuale);
            this.Controls.Add(this.lblImporto);
            this.Controls.Add(this.gboxclass);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Name = "FrmAdmPay_IncomeSorted_Detail";
            this.Text = "FrmAdmPay_IncomeSorted_Detail";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxclass.ResumeLayout(false);
            this.gboxclass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtSubmovimento;
        private System.Windows.Forms.TextBox txtPercentuale;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPercentuale;
        private System.Windows.Forms.Label lblImporto;
        private System.Windows.Forms.GroupBox gboxclass;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Button btnCodice;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
    }
}
