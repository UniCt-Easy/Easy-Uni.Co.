
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


namespace notable_scriptcomuni {
	partial class frmNoTable_scriptcomuni {
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
			this.btnFileVariazioneComuniAE = new System.Windows.Forms.Button();
			this.askFileName = new System.Windows.Forms.OpenFileDialog();
			this.txtFileVarComuniAE = new System.Windows.Forms.TextBox();
			this.txtListaComuni = new System.Windows.Forms.TextBox();
			this.btnFileListaComuni = new System.Windows.Forms.Button();
			this.btnCheckCoerenza = new System.Windows.Forms.Button();
			this.txtListaComuniAE = new System.Windows.Forms.TextBox();
			this.btnListaComuniAE = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.DS = new notable_scriptcomuni.dsmeta();
			this.btnRenameScript = new System.Windows.Forms.Button();
			this.btnScriptVariazione = new System.Windows.Forms.Button();
			this.btnViewInfo = new System.Windows.Forms.Button();
			this.btnCheckAllineamento = new System.Windows.Forms.Button();
			this.btnCambioProvincia = new System.Windows.Forms.Button();
			this.btnAggiornaAliquoteComunali = new System.Windows.Forms.Button();
			this.txtFileAliquoteComunali = new System.Windows.Forms.TextBox();
			this.btnFileAliquoteComunali = new System.Windows.Forms.Button();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnFileVariazioneComuniAE
			// 
			this.btnFileVariazioneComuniAE.Location = new System.Drawing.Point(12, 46);
			this.btnFileVariazioneComuniAE.Name = "btnFileVariazioneComuniAE";
			this.btnFileVariazioneComuniAE.Size = new System.Drawing.Size(167, 23);
			this.btnFileVariazioneComuniAE.TabIndex = 3;
			this.btnFileVariazioneComuniAE.Text = "File variazioni comuni AE";
			this.btnFileVariazioneComuniAE.Visible = false;
			this.btnFileVariazioneComuniAE.Click += new System.EventHandler(this.btnFileVariazioneComuni_Click);
			// 
			// askFileName
			// 
			this.askFileName.FileName = "openFileVarComuni";
			this.askFileName.RestoreDirectory = true;
			// 
			// txtFileVarComuniAE
			// 
			this.txtFileVarComuniAE.Location = new System.Drawing.Point(185, 49);
			this.txtFileVarComuniAE.Name = "txtFileVarComuniAE";
			this.txtFileVarComuniAE.Size = new System.Drawing.Size(505, 20);
			this.txtFileVarComuniAE.TabIndex = 1;
			// 
			// txtListaComuni
			// 
			this.txtListaComuni.Location = new System.Drawing.Point(185, 78);
			this.txtListaComuni.Name = "txtListaComuni";
			this.txtListaComuni.Size = new System.Drawing.Size(505, 20);
			this.txtListaComuni.TabIndex = 4;
			// 
			// btnFileListaComuni
			// 
			this.btnFileListaComuni.Location = new System.Drawing.Point(12, 75);
			this.btnFileListaComuni.Name = "btnFileListaComuni";
			this.btnFileListaComuni.Size = new System.Drawing.Size(167, 23);
			this.btnFileListaComuni.TabIndex = 5;
			this.btnFileListaComuni.Text = "File Lista Comuni";
			this.btnFileListaComuni.Visible = false;
			this.btnFileListaComuni.Click += new System.EventHandler(this.btnFileListaComuni_Click);
			// 
			// btnCheckCoerenza
			// 
			this.btnCheckCoerenza.Location = new System.Drawing.Point(1251, 49);
			this.btnCheckCoerenza.Name = "btnCheckCoerenza";
			this.btnCheckCoerenza.Size = new System.Drawing.Size(173, 23);
			this.btnCheckCoerenza.TabIndex = 6;
			this.btnCheckCoerenza.Text = "Trova corrispondenze in db";
			this.btnCheckCoerenza.UseVisualStyleBackColor = true;
			this.btnCheckCoerenza.Click += new System.EventHandler(this.btnCheckCoerenza_Click);
			// 
			// txtListaComuniAE
			// 
			this.txtListaComuniAE.Location = new System.Drawing.Point(185, 20);
			this.txtListaComuniAE.Name = "txtListaComuniAE";
			this.txtListaComuniAE.Size = new System.Drawing.Size(505, 20);
			this.txtListaComuniAE.TabIndex = 7;
			// 
			// btnListaComuniAE
			// 
			this.btnListaComuniAE.Location = new System.Drawing.Point(12, 17);
			this.btnListaComuniAE.Name = "btnListaComuniAE";
			this.btnListaComuniAE.Size = new System.Drawing.Size(167, 23);
			this.btnListaComuniAE.TabIndex = 8;
			this.btnListaComuniAE.Text = "File Lista Comuni AE";
			this.btnListaComuniAE.Click += new System.EventHandler(this.btnListaComuniAE_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(707, 23);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(288, 13);
			this.linkLabel1.TabIndex = 9;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://sister.agenziaentrate.gov.it/CitizenArCom/Report.do";
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new System.Drawing.Point(707, 78);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(241, 13);
			this.linkLabel2.TabIndex = 10;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "http://lab.comuni-italiani.it/download/comuni.html";
			// 
			// txtResult
			// 
			this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResult.Location = new System.Drawing.Point(12, 172);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtResult.Size = new System.Drawing.Size(1514, 435);
			this.txtResult.TabIndex = 11;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// btnRenameScript
			// 
			this.btnRenameScript.Location = new System.Drawing.Point(1055, 84);
			this.btnRenameScript.Name = "btnRenameScript";
			this.btnRenameScript.Size = new System.Drawing.Size(101, 23);
			this.btnRenameScript.TabIndex = 12;
			this.btnRenameScript.Text = "Allinea nomi AE";
			this.btnRenameScript.UseVisualStyleBackColor = true;
			this.btnRenameScript.Click += new System.EventHandler(this.btnRenameScript_Click);
			// 
			// btnScriptVariazione
			// 
			this.btnScriptVariazione.Location = new System.Drawing.Point(1251, 75);
			this.btnScriptVariazione.Name = "btnScriptVariazione";
			this.btnScriptVariazione.Size = new System.Drawing.Size(149, 23);
			this.btnScriptVariazione.TabIndex = 13;
			this.btnScriptVariazione.Text = "Script di variazione Comuni";
			this.btnScriptVariazione.UseVisualStyleBackColor = true;
			this.btnScriptVariazione.Click += new System.EventHandler(this.btnScriptVariazione_Click);
			// 
			// btnViewInfo
			// 
			this.btnViewInfo.Location = new System.Drawing.Point(1055, 17);
			this.btnViewInfo.Name = "btnViewInfo";
			this.btnViewInfo.Size = new System.Drawing.Size(173, 23);
			this.btnViewInfo.TabIndex = 14;
			this.btnViewInfo.Text = "Visualizza informazioni";
			this.btnViewInfo.UseVisualStyleBackColor = true;
			this.btnViewInfo.Click += new System.EventHandler(this.btnViewInfo_Click);
			// 
			// btnCheckAllineamento
			// 
			this.btnCheckAllineamento.Location = new System.Drawing.Point(1055, 49);
			this.btnCheckAllineamento.Name = "btnCheckAllineamento";
			this.btnCheckAllineamento.Size = new System.Drawing.Size(173, 23);
			this.btnCheckAllineamento.TabIndex = 15;
			this.btnCheckAllineamento.Text = "Verifica Dati AE";
			this.btnCheckAllineamento.UseVisualStyleBackColor = true;
			this.btnCheckAllineamento.Click += new System.EventHandler(this.btnCheckAllineamento_Click);
			// 
			// btnCambioProvincia
			// 
			this.btnCambioProvincia.Location = new System.Drawing.Point(1251, 18);
			this.btnCambioProvincia.Name = "btnCambioProvincia";
			this.btnCambioProvincia.Size = new System.Drawing.Size(155, 23);
			this.btnCambioProvincia.TabIndex = 16;
			this.btnCambioProvincia.Text = "Cambio Provincia Manuale";
			this.btnCambioProvincia.UseVisualStyleBackColor = true;
			this.btnCambioProvincia.Click += new System.EventHandler(this.btnCambioProvincia_Click);
			// 
			// btnAggiornaAliquoteComunali
			// 
			this.btnAggiornaAliquoteComunali.Location = new System.Drawing.Point(1055, 113);
			this.btnAggiornaAliquoteComunali.Name = "btnAggiornaAliquoteComunali";
			this.btnAggiornaAliquoteComunali.Size = new System.Drawing.Size(174, 23);
			this.btnAggiornaAliquoteComunali.TabIndex = 17;
			this.btnAggiornaAliquoteComunali.Text = "Elabora Differenze Aliquote";
			this.btnAggiornaAliquoteComunali.UseVisualStyleBackColor = true;
			this.btnAggiornaAliquoteComunali.Click += new System.EventHandler(this.btnAggiornaAliquoteComunali_Click);
			// 
			// txtFileAliquoteComunali
			// 
			this.txtFileAliquoteComunali.Location = new System.Drawing.Point(185, 107);
			this.txtFileAliquoteComunali.Name = "txtFileAliquoteComunali";
			this.txtFileAliquoteComunali.Size = new System.Drawing.Size(505, 20);
			this.txtFileAliquoteComunali.TabIndex = 18;
			// 
			// btnFileAliquoteComunali
			// 
			this.btnFileAliquoteComunali.Location = new System.Drawing.Point(12, 104);
			this.btnFileAliquoteComunali.Name = "btnFileAliquoteComunali";
			this.btnFileAliquoteComunali.Size = new System.Drawing.Size(167, 23);
			this.btnFileAliquoteComunali.TabIndex = 19;
			this.btnFileAliquoteComunali.Text = "File Aliquote Comunali";
			this.btnFileAliquoteComunali.Click += new System.EventHandler(this.btnFileAliquoteComunali_Click);
			// 
			// linkLabel3
			// 
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.Location = new System.Drawing.Point(12, 130);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(569, 13);
			this.linkLabel3.TabIndex = 20;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "https://www1.finanze.gov.it/finanze2/dipartimentopolitichefiscali/fiscalitalocale" +
    "/addirpef_newDF/download/tabella.htm";
			// 
			// frmNoTable_scriptcomuni
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1553, 619);
			this.Controls.Add(this.linkLabel3);
			this.Controls.Add(this.txtFileAliquoteComunali);
			this.Controls.Add(this.btnFileAliquoteComunali);
			this.Controls.Add(this.btnAggiornaAliquoteComunali);
			this.Controls.Add(this.btnCambioProvincia);
			this.Controls.Add(this.btnCheckAllineamento);
			this.Controls.Add(this.btnViewInfo);
			this.Controls.Add(this.btnScriptVariazione);
			this.Controls.Add(this.btnRenameScript);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.txtListaComuniAE);
			this.Controls.Add(this.btnListaComuniAE);
			this.Controls.Add(this.btnCheckCoerenza);
			this.Controls.Add(this.txtListaComuni);
			this.Controls.Add(this.btnFileListaComuni);
			this.Controls.Add(this.txtFileVarComuniAE);
			this.Controls.Add(this.btnFileVariazioneComuniAE);
			this.Name = "frmNoTable_scriptcomuni";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "notable_scriptcomuni";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public notable_scriptcomuni.dsmeta DS;
		private System.Windows.Forms.Button btnFileVariazioneComuniAE;
		private System.Windows.Forms.OpenFileDialog askFileName;
		private System.Windows.Forms.TextBox txtFileVarComuniAE;
		private System.Windows.Forms.TextBox txtListaComuni;
		private System.Windows.Forms.Button btnFileListaComuni;
		private System.Windows.Forms.Button btnCheckCoerenza;
		private System.Windows.Forms.TextBox txtListaComuniAE;
		private System.Windows.Forms.Button btnListaComuniAE;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.Button btnRenameScript;
		private System.Windows.Forms.Button btnScriptVariazione;
		private System.Windows.Forms.Button btnViewInfo;
		private System.Windows.Forms.Button btnCheckAllineamento;
		private System.Windows.Forms.Button btnCambioProvincia;
		private System.Windows.Forms.Button btnAggiornaAliquoteComunali;
		private System.Windows.Forms.TextBox txtFileAliquoteComunali;
		private System.Windows.Forms.Button btnFileAliquoteComunali;
		private System.Windows.Forms.LinkLabel linkLabel3;
	}
}

