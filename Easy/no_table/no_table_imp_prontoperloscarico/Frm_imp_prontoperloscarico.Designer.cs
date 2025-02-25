
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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



namespace no_table_imp_prontoperloscarico {
	partial class Frm_imp_prontoperloscarico {
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
			this.CMenu = new System.Windows.Forms.ContextMenu();
			this.MenuEnterPwd = new System.Windows.Forms.MenuItem();
			this.dgrCespiti = new System.Windows.Forms.DataGrid();
			this.btnApriFile = new System.Windows.Forms.Button();
			this._folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this._openInputFileDlg = new System.Windows.Forms.OpenFileDialog();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.BtnImpostaScarico = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.DS = new no_table_imp_prontoperloscarico.vistaForm();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgrCespiti)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// CMenu
			// 
			this.CMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuEnterPwd});
			// 
			// MenuEnterPwd
			// 
			this.MenuEnterPwd.Index = 0;
			this.MenuEnterPwd.Text = "Visualizza tracciato";
			this.MenuEnterPwd.Click += new System.EventHandler(this.MenuEnterPwd_Click);
			// 
			// dgrCespiti
			// 
			this.dgrCespiti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrCespiti.DataMember = "";
			this.dgrCespiti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrCespiti.Location = new System.Drawing.Point(12, 128);
			this.dgrCespiti.Name = "dgrCespiti";
			this.dgrCespiti.Size = new System.Drawing.Size(800, 397);
			this.dgrCespiti.TabIndex = 8;
			this.dgrCespiti.Tag = "";
			// 
			// btnApriFile
			// 
			this.btnApriFile.Location = new System.Drawing.Point(12, 45);
			this.btnApriFile.Name = "btnApriFile";
			this.btnApriFile.Size = new System.Drawing.Size(135, 30);
			this.btnApriFile.TabIndex = 7;
			this.btnApriFile.Text = "Importa File";
			this.btnApriFile.Click += new System.EventHandler(this.btnApriFile_Click);
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFile.Location = new System.Drawing.Point(153, 51);
			this.txtFile.Name = "txtFile";
			this.txtFile.ReadOnly = true;
			this.txtFile.Size = new System.Drawing.Size(659, 20);
			this.txtFile.TabIndex = 54;
			// 
			// BtnImpostaScarico
			// 
			this.BtnImpostaScarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.BtnImpostaScarico.Location = new System.Drawing.Point(600, 531);
			this.BtnImpostaScarico.Name = "BtnImpostaScarico";
			this.BtnImpostaScarico.Size = new System.Drawing.Size(92, 30);
			this.BtnImpostaScarico.TabIndex = 55;
			this.BtnImpostaScarico.Text = "Esegui";
			this.BtnImpostaScarico.UseVisualStyleBackColor = true;
			this.BtnImpostaScarico.Click += new System.EventHandler(this.BtnImpostaScarico_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(296, 540);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 13);
			this.label1.TabIndex = 56;
			this.label1.Text = "Imposta tutti i cespiti elencati come \"Pronti per lo scarico\".";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(732, 532);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 29);
			this.btnCancel.TabIndex = 57;
			this.btnCancel.Tag = "maincancel";
			this.btnCancel.Text = "Annulla";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(741, 13);
			this.label2.TabIndex = 58;
			this.label2.Text = "Procedura che consente di impostare \"Pronto allo scarico\", in modo massivo, su tu" +
    "tti i cespiti che verranno importati da file Excel";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(13, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(389, 26);
			this.label3.TabIndex = 59;
			this.label3.Text = "Il file dovrà contenere le colonne: Num.Cespite, Num.Parte. \r\nLa prima riga del f" +
    "ile dovrà contenere le intestazioni delle colonne. ";
			// 
			// Frm_imp_prontoperloscarico
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 572);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnImpostaScarico);
			this.Controls.Add(this.txtFile);
			this.Controls.Add(this.dgrCespiti);
			this.Controls.Add(this.btnApriFile);
			this.Name = "Frm_imp_prontoperloscarico";
			this.Text = "Frm_imp_prontoperloscarico";
			((System.ComponentModel.ISupportInitialize)(this.dgrCespiti)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public vistaForm DS;
		private System.Windows.Forms.ContextMenu CMenu;
		private System.Windows.Forms.MenuItem MenuEnterPwd;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.DataGrid dgrCespiti;
		private System.Windows.Forms.Button btnApriFile;
		private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog _openInputFileDlg;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Button BtnImpostaScarico;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}
