
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


namespace csa_contract_annulment {
    partial class frmcsa_contract_annulment {
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
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgrRegoleSpecifiche = new System.Windows.Forms.DataGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.chkKeepAlive = new System.Windows.Forms.CheckBox();
			this.btnElabora = new System.Windows.Forms.Button();
			this._openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.DS = new csa_contract_annulment.dsmeta();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrRegoleSpecifiche)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(12, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(683, 27);
			this.label9.TabIndex = 29;
			this.label9.Tag = "";
			this.label9.Text = "Selezionare le Regole Specifiche e cliccare su Elabora";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.dgrRegoleSpecifiche);
			this.groupBox3.Location = new System.Drawing.Point(11, 39);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(681, 424);
			this.groupBox3.TabIndex = 28;
			this.groupBox3.TabStop = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 20);
			this.label2.TabIndex = 11;
			this.label2.Tag = "";
			this.label2.Text = "Regole specifiche:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgrRegoleSpecifiche
			// 
			this.dgrRegoleSpecifiche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrRegoleSpecifiche.DataMember = "";
			this.dgrRegoleSpecifiche.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrRegoleSpecifiche.Location = new System.Drawing.Point(14, 35);
			this.dgrRegoleSpecifiche.Name = "dgrRegoleSpecifiche";
			this.dgrRegoleSpecifiche.Size = new System.Drawing.Size(655, 376);
			this.dgrRegoleSpecifiche.TabIndex = 10;
			this.dgrRegoleSpecifiche.Tag = "";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.chkKeepAlive);
			this.panel1.Controls.Add(this.btnElabora);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Location = new System.Drawing.Point(12, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(703, 515);
			this.panel1.TabIndex = 7;
			// 
			// chkKeepAlive
			// 
			this.chkKeepAlive.Location = new System.Drawing.Point(291, 10);
			this.chkKeepAlive.Name = "chkKeepAlive";
			this.chkKeepAlive.Size = new System.Drawing.Size(130, 27);
			this.chkKeepAlive.TabIndex = 12;
			this.chkKeepAlive.TabStop = false;
			this.chkKeepAlive.Tag = "";
			this.chkKeepAlive.Text = "Disattivare";
			this.chkKeepAlive.CheckedChanged += new System.EventHandler(this.chkKeepAlive_CheckedChanged);
			// 
			// btnElabora
			// 
			this.btnElabora.Location = new System.Drawing.Point(11, 469);
			this.btnElabora.Name = "btnElabora";
			this.btnElabora.Size = new System.Drawing.Size(258, 23);
			this.btnElabora.TabIndex = 30;
			this.btnElabora.Text = "Elabora ";
			this.btnElabora.UseVisualStyleBackColor = true;
			this.btnElabora.Click += new System.EventHandler(this.btnElabora_Click);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(650, 523);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 22);
			this.btnAnnulla.TabIndex = 317;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmcsa_contract_annulment
			// 
			this.ClientSize = new System.Drawing.Size(731, 556);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.panel1);
			this.Name = "frmcsa_contract_annulment";
			this.Text = "frmcsa_contract_annulment";
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrRegoleSpecifiche)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        public csa_contract_annulment.dsmeta DS;
		private System.Windows.Forms.OpenFileDialog _openInputFileDlg;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dgrRegoleSpecifiche;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnElabora;
		private System.Windows.Forms.CheckBox chkKeepAlive;
	}
}

