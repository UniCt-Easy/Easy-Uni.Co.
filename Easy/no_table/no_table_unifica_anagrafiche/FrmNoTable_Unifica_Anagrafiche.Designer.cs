
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


namespace no_table_unifica_anagrafiche {
    partial class FrmNoTable_Unifica_Anagrafiche {
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
			this.grpUnifica = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.btnUnifica = new System.Windows.Forms.Button();
			this.grpChoose = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.DS = new no_table_unifica_anagrafiche.vistaForm();
			this.btnOK = new System.Windows.Forms.Button();
			this.GridAnagrafiche = new System.Windows.Forms.DataGrid();
			this.grpUnifica.SuspendLayout();
			this.grpChoose.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GridAnagrafiche)).BeginInit();
			this.SuspendLayout();
			// 
			// grpUnifica
			// 
			this.grpUnifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpUnifica.Controls.Add(this.textBox3);
			this.grpUnifica.Controls.Add(this.btnUnifica);
			this.grpUnifica.Location = new System.Drawing.Point(12, 468);
			this.grpUnifica.Name = "grpUnifica";
			this.grpUnifica.Size = new System.Drawing.Size(544, 80);
			this.grpUnifica.TabIndex = 0;
			this.grpUnifica.TabStop = false;
			this.grpUnifica.Text = "Operazioni sulle anagrafiche visualizzate";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(228, 16);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(306, 54);
			this.textBox3.TabIndex = 0;
			this.textBox3.Tag = "";
			this.textBox3.Text = "Questa operazione sarà eseguita per tutte le anagrafiche marcate come \"Da unifica" +
    "re\"";
			// 
			// btnUnifica
			// 
			this.btnUnifica.Location = new System.Drawing.Point(8, 16);
			this.btnUnifica.Name = "btnUnifica";
			this.btnUnifica.Size = new System.Drawing.Size(214, 56);
			this.btnUnifica.TabIndex = 0;
			this.btnUnifica.TabStop = false;
			this.btnUnifica.Tag = "";
			this.btnUnifica.Text = "Unifica le anagrafiche marcate come unificabili con l\'unica anagrafica che deve r" +
    "imanere attiva.";
			this.btnUnifica.Click += new System.EventHandler(this.btnUnifica_Click);
			// 
			// grpChoose
			// 
			this.grpChoose.Controls.Add(this.label3);
			this.grpChoose.Location = new System.Drawing.Point(8, 9);
			this.grpChoose.Name = "grpChoose";
			this.grpChoose.Size = new System.Drawing.Size(548, 53);
			this.grpChoose.TabIndex = 0;
			this.grpChoose.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(528, 37);
			this.label3.TabIndex = 0;
			this.label3.Text = "Queste anagrafiche sono state contrassegnate per essere unificate con un\'anagrafi" +
    "ca scelta.  Per visualizzarla fare doppio click su ogni riga.";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(475, 589);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Tag = "";
			this.btnOK.Text = "Chiudi";
			// 
			// GridAnagrafiche
			// 
			this.GridAnagrafiche.AllowNavigation = false;
			this.GridAnagrafiche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GridAnagrafiche.DataMember = "";
			this.GridAnagrafiche.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.GridAnagrafiche.Location = new System.Drawing.Point(8, 68);
			this.GridAnagrafiche.Name = "GridAnagrafiche";
			this.GridAnagrafiche.ReadOnly = true;
			this.GridAnagrafiche.Size = new System.Drawing.Size(548, 394);
			this.GridAnagrafiche.TabIndex = 1;
			this.GridAnagrafiche.Tag = "";
			this.GridAnagrafiche.DoubleClick += new System.EventHandler(this.GridAnagrafiche_DoubleClick);
			// 
			// FrmNoTable_Unifica_Anagrafiche
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(560, 624);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.grpChoose);
			this.Controls.Add(this.grpUnifica);
			this.Controls.Add(this.GridAnagrafiche);
			this.Name = "FrmNoTable_Unifica_Anagrafiche";
			this.Text = "Unifica Anagrafiche";
			this.grpUnifica.ResumeLayout(false);
			this.grpUnifica.PerformLayout();
			this.grpChoose.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GridAnagrafiche)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUnifica;
        private System.Windows.Forms.GroupBox grpChoose;
        private System.Windows.Forms.Label label3;
        public vistaForm DS;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnUnifica;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGrid GridAnagrafiche;
    }
}
