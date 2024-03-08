
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


namespace paydisposition_default {
    partial class FrmPayDisposition_Default {
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtNumMandato = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnCreaMovimentiFinanziari = new System.Windows.Forms.Button();
			this.btnSelezionaTutto = new System.Windows.Forms.Button();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dgDetail = new System.Windows.Forms.DataGrid();
			this.btnExcel = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnCBI = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cmbCBImotive = new System.Windows.Forms.ComboBox();
			this.DS = new paydisposition_default.dsmeta();
			this.DSFinancial = new paydisposition_default.DSFinancial();
			this.dsDati = new paydisposition_default.daticbiDataSet();
			this.txtInputFile = new System.Windows.Forms.TextBox();
			this.btnInputFile = new System.Windows.Forms.Button();
			this._MyOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.progressBarImport = new System.Windows.Forms.ProgressBar();
			this.btnRimborsoSpeseUniversitarie = new System.Windows.Forms.Button();
			this.CMenu = new System.Windows.Forms.ContextMenu();
			this.MenuVisualizza = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDetail)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DSFinancial)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsDati)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(1, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Esercizio:";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(4, 26);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(100, 20);
			this.txtEsercizio.TabIndex = 1;
			this.txtEsercizio.TabStop = false;
			this.txtEsercizio.Tag = "paydisposition.ayear.year";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 201);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descrizione:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 264);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(446, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "Causale Principale (vale per tutti i dettagli che non ne specifichino una diversa" +
    "):";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(7, 216);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(683, 45);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "paydisposition.description";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(8, 286);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(683, 43);
			this.textBox3.TabIndex = 4;
			this.textBox3.Tag = "paydisposition.motive";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtNumMandato);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(296, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(186, 40);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "AutoChoose.txtNumMandato.default";
			this.groupBox1.Text = "Mandato";
			// 
			// txtNumMandato
			// 
			this.txtNumMandato.Location = new System.Drawing.Point(71, 15);
			this.txtNumMandato.Name = "txtNumMandato";
			this.txtNumMandato.Size = new System.Drawing.Size(100, 20);
			this.txtNumMandato.TabIndex = 1;
			this.txtNumMandato.Tag = "payment.npay?paydispositionview.npay";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 19);
			this.label5.TabIndex = 2;
			this.label5.Text = "Numero:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.btnCreaMovimentiFinanziari);
			this.groupBox2.Controls.Add(this.btnSelezionaTutto);
			this.groupBox2.Controls.Add(this.txtImporto);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.dgDetail);
			this.groupBox2.Location = new System.Drawing.Point(6, 335);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(683, 242);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Dettagli";
			// 
			// btnCreaMovimentiFinanziari
			// 
			this.btnCreaMovimentiFinanziari.Location = new System.Drawing.Point(426, 16);
			this.btnCreaMovimentiFinanziari.Name = "btnCreaMovimentiFinanziari";
			this.btnCreaMovimentiFinanziari.Size = new System.Drawing.Size(150, 23);
			this.btnCreaMovimentiFinanziari.TabIndex = 12;
			this.btnCreaMovimentiFinanziari.Text = "Crea Movimenti finanziari";
			this.btnCreaMovimentiFinanziari.UseVisualStyleBackColor = true;
			this.btnCreaMovimentiFinanziari.Click += new System.EventHandler(this.btnCreaMovimentiFinanziari_Click);
			// 
			// btnSelezionaTutto
			// 
			this.btnSelezionaTutto.Location = new System.Drawing.Point(582, 16);
			this.btnSelezionaTutto.Name = "btnSelezionaTutto";
			this.btnSelezionaTutto.Size = new System.Drawing.Size(93, 23);
			this.btnSelezionaTutto.TabIndex = 11;
			this.btnSelezionaTutto.Text = "Seleziona tutto";
			this.btnSelezionaTutto.UseVisualStyleBackColor = true;
			this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
			// 
			// txtImporto
			// 
			this.txtImporto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImporto.Location = new System.Drawing.Point(299, 19);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.ReadOnly = true;
			this.txtImporto.Size = new System.Drawing.Size(121, 20);
			this.txtImporto.TabIndex = 5;
			this.txtImporto.TabStop = false;
			this.txtImporto.Tag = "";
			this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(249, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Totale:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(170, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 3;
			this.button3.TabStop = false;
			this.button3.Tag = "delete";
			this.button3.Text = "Elimina";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(88, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.TabStop = false;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Correggi";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.TabStop = false;
			this.button1.Tag = "insert.default";
			this.button1.Text = "Aggiungi";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// dgDetail
			// 
			this.dgDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgDetail.DataMember = "";
			this.dgDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDetail.Location = new System.Drawing.Point(8, 54);
			this.dgDetail.Name = "dgDetail";
			this.dgDetail.Size = new System.Drawing.Size(669, 178);
			this.dgDetail.TabIndex = 0;
			this.dgDetail.Tag = "paydispositiondetail.detail.default";
			// 
			// btnExcel
			// 
			this.btnExcel.Location = new System.Drawing.Point(7, 167);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new System.Drawing.Size(126, 23);
			this.btnExcel.TabIndex = 8;
			this.btnExcel.TabStop = false;
			this.btnExcel.Text = "Esporta in Excel";
			this.btnExcel.UseVisualStyleBackColor = true;
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(130, 26);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "paydisposition.idpaydisposition";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(129, 6);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 19);
			this.label6.TabIndex = 9;
			this.label6.Text = "Numero:";
			// 
			// btnCBI
			// 
			this.btnCBI.Location = new System.Drawing.Point(139, 167);
			this.btnCBI.Name = "btnCBI";
			this.btnCBI.Size = new System.Drawing.Size(126, 23);
			this.btnCBI.TabIndex = 10;
			this.btnCBI.Text = "Esporta in CBI";
			this.btnCBI.UseVisualStyleBackColor = true;
			this.btnCBI.Click += new System.EventHandler(this.btnCBI_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cmbCBImotive);
			this.groupBox3.Location = new System.Drawing.Point(4, 108);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(474, 53);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Causale CBI";
			// 
			// cmbCBImotive
			// 
			this.cmbCBImotive.DataSource = this.DS.cbimotive;
			this.cmbCBImotive.DisplayMember = "description";
			this.cmbCBImotive.FormattingEnabled = true;
			this.cmbCBImotive.Location = new System.Drawing.Point(8, 18);
			this.cmbCBImotive.Name = "cmbCBImotive";
			this.cmbCBImotive.Size = new System.Drawing.Size(455, 21);
			this.cmbCBImotive.TabIndex = 11;
			this.cmbCBImotive.Tag = "paydisposition.idcbimotive";
			this.cmbCBImotive.ValueMember = "idcbimotive";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// DSFinancial
			// 
			this.DSFinancial.DataSetName = "DSFinancial";
			this.DSFinancial.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// dsDati
			// 
			this.dsDati.DataSetName = "daticbiDataSet";
			this.dsDati.EnforceConstraints = false;
			// 
			// txtInputFile
			// 
			this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInputFile.Location = new System.Drawing.Point(191, 55);
			this.txtInputFile.Multiline = true;
			this.txtInputFile.Name = "txtInputFile";
			this.txtInputFile.ReadOnly = true;
			this.txtInputFile.Size = new System.Drawing.Size(490, 22);
			this.txtInputFile.TabIndex = 14;
			// 
			// btnInputFile
			// 
			this.btnInputFile.Location = new System.Drawing.Point(4, 54);
			this.btnInputFile.Name = "btnInputFile";
			this.btnInputFile.Size = new System.Drawing.Size(163, 23);
			this.btnInputFile.TabIndex = 13;
			this.btnInputFile.Text = "Importa dettagli da Excel";
			this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
			// 
			// MyOpenFile
			// 
			this._MyOpenFile.FileName = "openFileDialog";
			this._MyOpenFile.Title = "Selezionare il file Excel da importare";
			// 
			// progressBarImport
			// 
			this.progressBarImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarImport.Location = new System.Drawing.Point(6, 83);
			this.progressBarImport.Name = "progressBarImport";
			this.progressBarImport.Size = new System.Drawing.Size(677, 19);
			this.progressBarImport.TabIndex = 15;
			this.progressBarImport.Visible = false;
			// 
			// btnRimborsoSpeseUniversitarie
			// 
			this.btnRimborsoSpeseUniversitarie.Location = new System.Drawing.Point(350, 167);
			this.btnRimborsoSpeseUniversitarie.Name = "btnRimborsoSpeseUniversitarie";
			this.btnRimborsoSpeseUniversitarie.Size = new System.Drawing.Size(333, 22);
			this.btnRimborsoSpeseUniversitarie.TabIndex = 16;
			this.btnRimborsoSpeseUniversitarie.Text = "Comunicazione dei dati relativi alle spese universitarie";
			this.btnRimborsoSpeseUniversitarie.UseVisualStyleBackColor = true;
			this.btnRimborsoSpeseUniversitarie.Click += new System.EventHandler(this.btnRimborsoSpeseUniversitarie_Click);
			// 
			// CMenu
			// 
			this.CMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuVisualizza});
			// 
			// MenuVisualizza
			// 
			this.MenuVisualizza.Index = 0;
			this.MenuVisualizza.Text = "Visualizza tracciato";
			this.MenuVisualizza.Click += new System.EventHandler(this.menuVisualizza_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = -1;
			this.menuItem1.Text = "";
			// 
			// FrmPayDisposition_Default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(695, 582);
			this.Controls.Add(this.btnRimborsoSpeseUniversitarie);
			this.Controls.Add(this.progressBarImport);
			this.Controls.Add(this.txtInputFile);
			this.Controls.Add(this.btnInputFile);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnCBI);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnExcel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtEsercizio);
			this.Controls.Add(this.label1);
			this.Name = "FrmPayDisposition_Default";
			this.Text = "FrmPayDisposition_Default";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDetail)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DSFinancial)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsDati)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumMandato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGrid dgDetail;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.Label label4;
        public  dsmeta DS;
		public DSFinancial DSFinancial;
		public daticbiDataSet dsDati;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCBI;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbCBImotive;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnInputFile;
      
        private System.Windows.Forms.OpenFileDialog _MyOpenFile;
        private System.Windows.Forms.ProgressBar progressBarImport;
        private System.Windows.Forms.Button btnRimborsoSpeseUniversitarie;
        private System.Windows.Forms.ContextMenu CMenu;
        private System.Windows.Forms.MenuItem MenuVisualizza;
        private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Button btnSelezionaTutto;
		private System.Windows.Forms.Button btnCreaMovimentiFinanziari;
	}
}
