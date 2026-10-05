/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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


namespace no_table_fin_mef_afam {
    partial class Frm_no_table_fin_mef_afam {
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

				wb.Close();
				xlApp.Quit();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
				System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
			}
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.DS = new no_table_fin_mef_afam.vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabConsuntivo = new System.Windows.Forms.TabPage();
			this.btnElabora_c = new System.Windows.Forms.Button();
			this.btnClassificazione_c = new System.Windows.Forms.Button();
			this.cmbClassificazione_c = new System.Windows.Forms.ComboBox();
			this.txtEsercizio_c = new System.Windows.Forms.TextBox();
			this.lblEsercizio_c = new System.Windows.Forms.Label();
			this.tabPreventivo = new System.Windows.Forms.TabPage();
			this.btnElabora_p = new System.Windows.Forms.Button();
			this.btnClassificazione_p = new System.Windows.Forms.Button();
			this.cmbClassificazione_p = new System.Windows.Forms.ComboBox();
			this.txtEsercizio_p = new System.Windows.Forms.TextBox();
			this.lblEsercizio_p = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabConsuntivo.SuspendLayout();
			this.tabPreventivo.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabConsuntivo);
			this.tabControl1.Controls.Add(this.tabPreventivo);
			this.tabControl1.Location = new System.Drawing.Point(0, 1);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(471, 232);
			this.tabControl1.TabIndex = 0;
			// 
			// tabConsuntivo
			// 
			this.tabConsuntivo.Controls.Add(this.btnElabora_c);
			this.tabConsuntivo.Controls.Add(this.btnClassificazione_c);
			this.tabConsuntivo.Controls.Add(this.cmbClassificazione_c);
			this.tabConsuntivo.Controls.Add(this.txtEsercizio_c);
			this.tabConsuntivo.Controls.Add(this.lblEsercizio_c);
			this.tabConsuntivo.Location = new System.Drawing.Point(4, 22);
			this.tabConsuntivo.Name = "tabConsuntivo";
			this.tabConsuntivo.Padding = new System.Windows.Forms.Padding(3);
			this.tabConsuntivo.Size = new System.Drawing.Size(463, 206);
			this.tabConsuntivo.TabIndex = 0;
			this.tabConsuntivo.Text = "Consuntivo";
			this.tabConsuntivo.UseVisualStyleBackColor = true;
			// 
			// btnElabora_c
			// 
			this.btnElabora_c.Location = new System.Drawing.Point(125, 139);
			this.btnElabora_c.Name = "btnElabora_c";
			this.btnElabora_c.Size = new System.Drawing.Size(216, 23);
			this.btnElabora_c.TabIndex = 4;
			this.btnElabora_c.Text = "Elabora File Consuntivo Mef (Excel)";
			this.btnElabora_c.UseVisualStyleBackColor = true;
			this.btnElabora_c.Click += new System.EventHandler(this.btnElabora_c_Click);
			// 
			// btnClassificazione_c
			// 
			this.btnClassificazione_c.Location = new System.Drawing.Point(57, 81);
			this.btnClassificazione_c.Name = "btnClassificazione_c";
			this.btnClassificazione_c.Size = new System.Drawing.Size(95, 23);
			this.btnClassificazione_c.TabIndex = 3;
			this.btnClassificazione_c.Tag = "choose.sortingkind_c.default";
			this.btnClassificazione_c.Text = "Classificazione";
			this.btnClassificazione_c.UseVisualStyleBackColor = true;
			// 
			// cmbClassificazione_c
			// 
			this.cmbClassificazione_c.DataSource = this.DS.sortingkind_c;
			this.cmbClassificazione_c.DisplayMember = "description";
			this.cmbClassificazione_c.FormattingEnabled = true;
			this.cmbClassificazione_c.Location = new System.Drawing.Point(168, 83);
			this.cmbClassificazione_c.Name = "cmbClassificazione_c";
			this.cmbClassificazione_c.Size = new System.Drawing.Size(228, 21);
			this.cmbClassificazione_c.TabIndex = 2;
			this.cmbClassificazione_c.Tag = "sortingkind_c.idsorkind";
			this.cmbClassificazione_c.ValueMember = "idsorkind";
			// 
			// txtEsercizio_c
			// 
			this.txtEsercizio_c.Location = new System.Drawing.Point(168, 29);
			this.txtEsercizio_c.Name = "txtEsercizio_c";
			this.txtEsercizio_c.Size = new System.Drawing.Size(100, 20);
			this.txtEsercizio_c.TabIndex = 1;
			// 
			// lblEsercizio_c
			// 
			this.lblEsercizio_c.AutoSize = true;
			this.lblEsercizio_c.Location = new System.Drawing.Point(103, 32);
			this.lblEsercizio_c.Name = "lblEsercizio_c";
			this.lblEsercizio_c.Size = new System.Drawing.Size(49, 13);
			this.lblEsercizio_c.TabIndex = 0;
			this.lblEsercizio_c.Text = "Esercizio";
			// 
			// tabPreventivo
			// 
			this.tabPreventivo.Controls.Add(this.btnElabora_p);
			this.tabPreventivo.Controls.Add(this.btnClassificazione_p);
			this.tabPreventivo.Controls.Add(this.cmbClassificazione_p);
			this.tabPreventivo.Controls.Add(this.txtEsercizio_p);
			this.tabPreventivo.Controls.Add(this.lblEsercizio_p);
			this.tabPreventivo.Location = new System.Drawing.Point(4, 22);
			this.tabPreventivo.Name = "tabPreventivo";
			this.tabPreventivo.Padding = new System.Windows.Forms.Padding(3);
			this.tabPreventivo.Size = new System.Drawing.Size(463, 206);
			this.tabPreventivo.TabIndex = 1;
			this.tabPreventivo.Text = "Preventivo";
			this.tabPreventivo.UseVisualStyleBackColor = true;
			// 
			// btnElabora_p
			// 
			this.btnElabora_p.Location = new System.Drawing.Point(125, 139);
			this.btnElabora_p.Name = "btnElabora_p";
			this.btnElabora_p.Size = new System.Drawing.Size(216, 23);
			this.btnElabora_p.TabIndex = 11;
			this.btnElabora_p.Text = "Elabora File Preventivo Mef (Excel)";
			this.btnElabora_p.UseVisualStyleBackColor = true;
			this.btnElabora_p.Click += new System.EventHandler(this.btnElabora_p_Click);
			// 
			// btnClassificazione_p
			// 
			this.btnClassificazione_p.Location = new System.Drawing.Point(57, 81);
			this.btnClassificazione_p.Name = "btnClassificazione_p";
			this.btnClassificazione_p.Size = new System.Drawing.Size(95, 23);
			this.btnClassificazione_p.TabIndex = 10;
			this.btnClassificazione_p.Tag = "choose.sortingkind_p.default";
			this.btnClassificazione_p.Text = "Classificazione";
			this.btnClassificazione_p.UseVisualStyleBackColor = true;
			// 
			// cmbClassificazione_p
			// 
			this.cmbClassificazione_p.DataSource = this.DS.sortingkind_p;
			this.cmbClassificazione_p.DisplayMember = "description";
			this.cmbClassificazione_p.FormattingEnabled = true;
			this.cmbClassificazione_p.Location = new System.Drawing.Point(168, 83);
			this.cmbClassificazione_p.Name = "cmbClassificazione_p";
			this.cmbClassificazione_p.Size = new System.Drawing.Size(228, 21);
			this.cmbClassificazione_p.TabIndex = 9;
			this.cmbClassificazione_p.Tag = "sortingkind_p.idsorkind";
			this.cmbClassificazione_p.ValueMember = "idsorkind";
			// 
			// txtEsercizio_p
			// 
			this.txtEsercizio_p.Location = new System.Drawing.Point(168, 29);
			this.txtEsercizio_p.Name = "txtEsercizio_p";
			this.txtEsercizio_p.Size = new System.Drawing.Size(100, 20);
			this.txtEsercizio_p.TabIndex = 8;
			// 
			// lblEsercizio_p
			// 
			this.lblEsercizio_p.AutoSize = true;
			this.lblEsercizio_p.Location = new System.Drawing.Point(103, 32);
			this.lblEsercizio_p.Name = "lblEsercizio_p";
			this.lblEsercizio_p.Size = new System.Drawing.Size(49, 13);
			this.lblEsercizio_p.TabIndex = 7;
			this.lblEsercizio_p.Text = "Esercizio";
			// 
			// Frm_no_table_fin_mef_afam
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(473, 233);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_no_table_fin_mef_afam";
			this.Text = "Frm_no_table_fin_mef_afam";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabConsuntivo.ResumeLayout(false);
			this.tabConsuntivo.PerformLayout();
			this.tabPreventivo.ResumeLayout(false);
			this.tabPreventivo.PerformLayout();
			this.ResumeLayout(false);

        }

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabConsuntivo;
		private System.Windows.Forms.Button btnElabora_c;
		private System.Windows.Forms.Button btnClassificazione_c;
		private System.Windows.Forms.ComboBox cmbClassificazione_c;
		private System.Windows.Forms.TextBox txtEsercizio_c;
		private System.Windows.Forms.Label lblEsercizio_c;
		private System.Windows.Forms.TabPage tabPreventivo;
		private System.Windows.Forms.Button btnElabora_p;
		private System.Windows.Forms.Button btnClassificazione_p;
		private System.Windows.Forms.ComboBox cmbClassificazione_p;
		private System.Windows.Forms.TextBox txtEsercizio_p;
		private System.Windows.Forms.Label lblEsercizio_p;
	}


}