
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


namespace no_table_trasf_paydisposition {
    partial class FrmTrasfPaydisposition {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
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
        private void InitializeComponent () {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtEsercizioInizio = new System.Windows.Forms.TextBox();
			this.labelEsercizio = new System.Windows.Forms.Label();
			this.btnTrasferisciDisposizioni = new System.Windows.Forms.Button();
			this.DS = new no_table_trasf_paydisposition.vistaForm();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtEsercizioInizio);
			this.groupBox1.Controls.Add(this.labelEsercizio);
			this.groupBox1.Controls.Add(this.btnTrasferisciDisposizioni);
			this.groupBox1.Location = new System.Drawing.Point(12, 67);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(481, 88);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// txtEsercizioInizio
			// 
			this.txtEsercizioInizio.BackColor = System.Drawing.SystemColors.Window;
			this.txtEsercizioInizio.Enabled = false;
			this.txtEsercizioInizio.Location = new System.Drawing.Point(32, 42);
			this.txtEsercizioInizio.Name = "txtEsercizioInizio";
			this.txtEsercizioInizio.ReadOnly = true;
			this.txtEsercizioInizio.Size = new System.Drawing.Size(76, 20);
			this.txtEsercizioInizio.TabIndex = 7;
			this.txtEsercizioInizio.Tag = "";
			this.txtEsercizioInizio.Leave += new System.EventHandler(this.txtEsercizio_Leave);
			// 
			// labelEsercizio
			// 
			this.labelEsercizio.AutoSize = true;
			this.labelEsercizio.Location = new System.Drawing.Point(29, 26);
			this.labelEsercizio.Name = "labelEsercizio";
			this.labelEsercizio.Size = new System.Drawing.Size(107, 13);
			this.labelEsercizio.TabIndex = 6;
			this.labelEsercizio.Text = "Esercizio da trasferire";
			// 
			// btnTrasferisciDisposizioni
			// 
			this.btnTrasferisciDisposizioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTrasferisciDisposizioni.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnTrasferisciDisposizioni.Location = new System.Drawing.Point(277, 26);
			this.btnTrasferisciDisposizioni.Name = "btnTrasferisciDisposizioni";
			this.btnTrasferisciDisposizioni.Size = new System.Drawing.Size(192, 45);
			this.btnTrasferisciDisposizioni.TabIndex = 1;
			this.btnTrasferisciDisposizioni.Text = "Trasferisci Disposizioni";
			this.btnTrasferisciDisposizioni.UseVisualStyleBackColor = true;
			this.btnTrasferisciDisposizioni.Click += new System.EventHandler(this.btnTrasferisciDisposizioni_Click);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(12, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(481, 49);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(22, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(447, 29);
			this.label2.TabIndex = 2;
			this.label2.Text = "La procedura consente di trasferire le disposizioni non pagate da un esercizio ad" +
    " un altro";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.dataGrid);
			this.groupBox5.Location = new System.Drawing.Point(12, 161);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(481, 241);
			this.groupBox5.TabIndex = 15;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Disposizioni Trasferite";
			// 
			// dataGrid
			// 
			this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid.DataMember = "";
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(12, 19);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.Size = new System.Drawing.Size(463, 216);
			this.dataGrid.TabIndex = 4;
			this.dataGrid.Tag = " ";
			// 
			// FrmTrasfPaydisposition
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnTrasferisciDisposizioni;
			this.ClientSize = new System.Drawing.Size(505, 414);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "FrmTrasfPaydisposition";
			this.Text = "Trasferimento Organigramma";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTrasferisciDisposizioni;
        private System.Windows.Forms.TextBox txtEsercizioInizio;
        private System.Windows.Forms.Label labelEsercizio;
        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGrid dataGrid;

    }
}
