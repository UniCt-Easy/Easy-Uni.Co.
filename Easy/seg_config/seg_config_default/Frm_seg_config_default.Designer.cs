
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



namespace seg_config_default {
	partial class Frm_seg_config_default {
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
			this.DS = new seg_config_default.vistaForm();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.chkTableRegistryCSA = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(510, 115);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(88, 24);
			this.btnAnnulla.TabIndex = 18;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(413, 115);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(88, 24);
			this.btnOK.TabIndex = 17;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// chkTableRegistryCSA
			// 
			this.chkTableRegistryCSA.AutoSize = true;
			this.chkTableRegistryCSA.Location = new System.Drawing.Point(12, 47);
			this.chkTableRegistryCSA.Name = "chkTableRegistryCSA";
			this.chkTableRegistryCSA.Size = new System.Drawing.Size(599, 17);
			this.chkTableRegistryCSA.TabIndex = 19;
			this.chkTableRegistryCSA.Tag = "seg_config.flag:0";
			this.chkTableRegistryCSA.Text = "Non valorizzare le tabelle: Anagrafica docenti, Anagrafica amministrativi e contr" +
    "atto nella \"Importazione anagrafiche CSA\".";
			this.chkTableRegistryCSA.UseVisualStyleBackColor = true;
			// 
			// Frm_seg_config_default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(631, 163);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.chkTableRegistryCSA);
			this.Name = "Frm_seg_config_default";
			this.Text = "Frm_seg_config_default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.CheckBox chkTableRegistryCSA;
		public vistaForm DS;
	}
}
