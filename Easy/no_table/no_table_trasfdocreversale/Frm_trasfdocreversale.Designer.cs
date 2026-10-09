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
namespace no_table_trasfdocreversale {
	partial class Frm_trasfdocreversale {
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
			this.DS = new no_table_trasfdocreversale.vistaForm();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtEsercizioReversale = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.btnSelezionaFolder = new System.Windows.Forms.Button();
			this.txtZipFile = new System.Windows.Forms.TextBox();
			this.btnSelezionaZip = new System.Windows.Forms.Button();
			this.txtNumFine = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNumInizio = new System.Windows.Forms.TextBox();
			this.labelEsercizio = new System.Windows.Forms.Label();
			this.btnEseguidownload = new System.Windows.Forms.Button();
			this.btnEseguidownloadZip = new System.Windows.Forms.Button();
			this.btnInterrompi = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this._folderDlg = new System.Windows.Forms.FolderBrowserDialog();
			this._saveZipDlg = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(438, 54);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(22, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(404, 29);
			this.label2.TabIndex = 2;
			this.label2.Text = "La procedura effettua il download in una unica cartella, di tutti i documenti inf" +
    "ormatici associati alla reversale";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(402, 420);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 12;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(292, 420);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 11;
			this.btnOK.Tag = "";
			this.btnOK.Text = "OK";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtEsercizioReversale);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtFolder);
			this.groupBox1.Controls.Add(this.btnSelezionaFolder);
			this.groupBox1.Controls.Add(this.txtZipFile);
			this.groupBox1.Controls.Add(this.btnSelezionaZip);
			this.groupBox1.Controls.Add(this.txtNumFine);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtNumInizio);
			this.groupBox1.Controls.Add(this.labelEsercizio);
			this.groupBox1.Controls.Add(this.btnInterrompi);
			this.groupBox1.Controls.Add(this.btnEseguidownloadZip);
			this.groupBox1.Controls.Add(this.btnEseguidownload);
			this.groupBox1.Location = new System.Drawing.Point(12, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(465, 290);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			// 
			// txtEsercizioReversale
			// 
			this.txtEsercizioReversale.BackColor = System.Drawing.SystemColors.Window;
			this.txtEsercizioReversale.Location = new System.Drawing.Point(9, 31);
			this.txtEsercizioReversale.Name = "txtEsercizioReversale";
			this.txtEsercizioReversale.Size = new System.Drawing.Size(72, 20);
			this.txtEsercizioReversale.TabIndex = 19;
			this.txtEsercizioReversale.Tag = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Esercizio reversale";
			//
			// txtFolder
			//
			this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFolder.Location = new System.Drawing.Point(6, 102);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(447, 20);
			this.txtFolder.TabIndex = 17;
			//
			// btnSelezionaFolder
			//
			this.btnSelezionaFolder.Location = new System.Drawing.Point(6, 73);
			this.btnSelezionaFolder.Name = "btnSelezionaFolder";
			this.btnSelezionaFolder.Size = new System.Drawing.Size(134, 23);
			this.btnSelezionaFolder.TabIndex = 16;
			this.btnSelezionaFolder.Text = "Seleziona cartella";
			this.btnSelezionaFolder.UseVisualStyleBackColor = true;
			this.btnSelezionaFolder.Click += new System.EventHandler(this.btnSelezionaFolder_Click);
			//
			// txtZipFile
			//
			this.txtZipFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtZipFile.Location = new System.Drawing.Point(6, 209);
			this.txtZipFile.Name = "txtZipFile";
			this.txtZipFile.Size = new System.Drawing.Size(447, 20);
			this.txtZipFile.TabIndex = 22;
			//
			// btnSelezionaZip
			//
			this.btnSelezionaZip.Location = new System.Drawing.Point(6, 180);
			this.btnSelezionaZip.Name = "btnSelezionaZip";
			this.btnSelezionaZip.Size = new System.Drawing.Size(160, 23);
			this.btnSelezionaZip.TabIndex = 21;
			this.btnSelezionaZip.Text = "Seleziona archivio ZIP";
			this.btnSelezionaZip.UseVisualStyleBackColor = true;
			this.btnSelezionaZip.Click += new System.EventHandler(this.btnSelezionaZip_Click);
			// 
			// txtNumFine
			// 
			this.txtNumFine.BackColor = System.Drawing.SystemColors.Window;
			this.txtNumFine.Location = new System.Drawing.Point(280, 31);
			this.txtNumFine.Name = "txtNumFine";
			this.txtNumFine.Size = new System.Drawing.Size(72, 20);
			this.txtNumFine.TabIndex = 9;
			this.txtNumFine.Tag = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(277, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Num. reversale fine";
			// 
			// txtNumInizio
			// 
			this.txtNumInizio.BackColor = System.Drawing.SystemColors.Window;
			this.txtNumInizio.Location = new System.Drawing.Point(150, 31);
			this.txtNumInizio.Name = "txtNumInizio";
			this.txtNumInizio.Size = new System.Drawing.Size(72, 20);
			this.txtNumInizio.TabIndex = 7;
			this.txtNumInizio.Tag = "";
			// 
			// labelEsercizio
			// 
			this.labelEsercizio.AutoSize = true;
			this.labelEsercizio.Location = new System.Drawing.Point(147, 15);
			this.labelEsercizio.Name = "labelEsercizio";
			this.labelEsercizio.Size = new System.Drawing.Size(104, 13);
			this.labelEsercizio.TabIndex = 6;
			this.labelEsercizio.Text = "Num. reversale inizio";
			// 
			// btnEseguidownload
			// 
			this.btnEseguidownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEseguidownload.Location = new System.Drawing.Point(291, 138);
			this.btnEseguidownload.Name = "btnEseguidownload";
			this.btnEseguidownload.Size = new System.Drawing.Size(162, 30);
			this.btnEseguidownload.TabIndex = 1;
			this.btnEseguidownload.Text = "Esegui download";
			this.btnEseguidownload.UseVisualStyleBackColor = true;
			this.btnEseguidownload.Click += new System.EventHandler(this.btnEseguidownload_Click);
			//
			// btnEseguidownloadZip
			//
			this.btnEseguidownloadZip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEseguidownloadZip.Location = new System.Drawing.Point(291, 245);
			this.btnEseguidownloadZip.Name = "btnEseguidownloadZip";
			this.btnEseguidownloadZip.Size = new System.Drawing.Size(162, 30);
			this.btnEseguidownloadZip.TabIndex = 23;
			this.btnEseguidownloadZip.Text = "Esegui download (ZIP)";
			this.btnEseguidownloadZip.UseVisualStyleBackColor = true;
			this.btnEseguidownloadZip.Click += new System.EventHandler(this.btnEseguidownloadZip_Click);
			//
			// btnInterrompi
			//
			this.btnInterrompi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInterrompi.Location = new System.Drawing.Point(123, 245);
			this.btnInterrompi.Name = "btnInterrompi";
			this.btnInterrompi.Size = new System.Drawing.Size(162, 30);
			this.btnInterrompi.TabIndex = 24;
			this.btnInterrompi.Text = "Interrompi";
			this.btnInterrompi.UseVisualStyleBackColor = true;
			this.btnInterrompi.Visible = false;
			this.btnInterrompi.Click += new System.EventHandler(this.btnInterrompi_Click);
			//
			// lblStatus
			//
			this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblStatus.Location = new System.Drawing.Point(12, 370);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(465, 18);
			this.lblStatus.TabIndex = 14;
			this.lblStatus.Text = "";
			this.lblStatus.Visible = false;
			//
			// progressBar1
			//
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(12, 391);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(465, 18);
			this.progressBar1.TabIndex = 15;
			this.progressBar1.Visible = false;
			//
			// _saveZipDlg
			//
			this._saveZipDlg.DefaultExt = "zip";
			this._saveZipDlg.Filter = "Archivio ZIP (*.zip)|*.zip|Tutti i file (*.*)|*.*";
			this._saveZipDlg.Title = "Selezionare l\'archivio ZIP di destinazione";
			//
			// Frm_trasfdocreversale
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 455);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.Name = "Frm_trasfdocreversale";
			this.Text = "Frm_trasfdocreversale";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNumFine;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumInizio;
		private System.Windows.Forms.Label labelEsercizio;
		private System.Windows.Forms.Button btnEseguidownload;
		private System.Windows.Forms.TextBox txtFolder;
		private System.Windows.Forms.Button btnSelezionaFolder;
		private System.Windows.Forms.FolderBrowserDialog _folderDlg;
		private System.Windows.Forms.TextBox txtZipFile;
		private System.Windows.Forms.Button btnSelezionaZip;
		private System.Windows.Forms.Button btnEseguidownloadZip;
		private System.Windows.Forms.Button btnInterrompi;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.SaveFileDialog _saveZipDlg;
		public vistaForm DS;
		private System.Windows.Forms.TextBox txtEsercizioReversale;
		private System.Windows.Forms.Label label3;
	}
}