
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


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Text;
using metadatalibrary;
using System.IO;
using funzioni_configurazione;
using System.Globalization;

namespace emens_default//DenunceRetributiveMensili//
{
	/// <summary>
	/// Summary description for FrmDenunceRetributiveMensili.
	/// </summary>
	public class Frm_emens_default : MetaDataForm
	{
		private XmlTextWriter writer;
		public vistaForm DS;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btnGeneraEmens;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCFPersonaMittente;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtRagSocMittente;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCFMittente;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtCFSoftwarehouse;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnApriFile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAnno;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtNomeFile;
		private System.Windows.Forms.Button btnSalvaFile;
		MetaData meta;
		private System.Windows.Forms.GroupBox grpDatiMittente;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DataGrid dgPrestazione;
		private System.Windows.Forms.DataGrid dgRitenuta;
		private System.Windows.Forms.Label lblAvviso;
		public VistaEmens dsEmens;
		private System.Windows.Forms.OpenFileDialog _openFileDialog1;
		private string filter_eserc="";
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        bool Unified = false;
        private TextBox txtUnified;
        DataTable T_unified = new DataTable("T_unified");
        private Button btnGeneraUniEmens;
        string unif_suffix = "";
        public IOpenFileDialog openFileDialog1;

		public Frm_emens_default()
		{
			InitializeComponent();

			// Caption per tabella EMENS
			dsEmens.Emens.Columns["AnnoMeseDenuncia"].Caption = "Mese denuncia";
			dsEmens.Emens.Columns["CFAzienda"].Caption = "C.F. Azienda";
			dsEmens.Emens.Columns["CFCollaboratore"].Caption = "C.F. Collaboratore";
			dsEmens.Emens.Columns["Cognome"].Caption = "Cognome";
			dsEmens.Emens.Columns["Nome"].Caption = "Nome";
            dsEmens.Emens.Columns["CodiceComune"].Caption = "Codice Comune";
			dsEmens.Emens.Columns["TipoRapporto"].Caption = "Tipo rapporto";
			dsEmens.Emens.Columns["CodiceAttivita"].Caption = "Codice attività";
			dsEmens.Emens.Columns["Imponibile"].Caption = "Imponibile";
			dsEmens.Emens.Columns["Aliquota"].Caption = "Aliquota";
			dsEmens.Emens.Columns["AltraAss"].Caption = "Altra ass.";
			dsEmens.Emens.Columns["Dal"].Caption = "Dal";
			dsEmens.Emens.Columns["Al"].Caption = "Al";
			dsEmens.Emens.Columns["CodCalamita"].Caption = "";
            dsEmens.Emens.Columns["CodCertificazione"].Caption = "";
            openFileDialog1 = createOpenFileDialog(_openFileDialog1);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_emens_default));
            this.btnGeneraEmens = new System.Windows.Forms.Button();
            this.DS = new emens_default.vistaForm();
            this.dsEmens = new emens_default.VistaEmens();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.grpDatiMittente = new System.Windows.Forms.GroupBox();
            this.txtCFSoftwarehouse = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCFMittente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRagSocMittente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCFPersonaMittente = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnApriFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNomeFile = new System.Windows.Forms.TextBox();
            this.btnSalvaFile = new System.Windows.Forms.Button();
            this.dgPrestazione = new System.Windows.Forms.DataGrid();
            this.dgRitenuta = new System.Windows.Forms.DataGrid();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAvviso = new System.Windows.Forms.Label();
            this._openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtUnified = new System.Windows.Forms.TextBox();
            this.btnGeneraUniEmens = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmens)).BeginInit();
            this.grpDatiMittente.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrestazione)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRitenuta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneraEmens
            // 
            this.btnGeneraEmens.Location = new System.Drawing.Point(16, 162);
            this.btnGeneraEmens.Name = "btnGeneraEmens";
            this.btnGeneraEmens.Size = new System.Drawing.Size(128, 23);
            this.btnGeneraEmens.TabIndex = 4;
            this.btnGeneraEmens.Text = "Genera E-Mens";
            this.btnGeneraEmens.Click += new System.EventHandler(this.btnGeneraEmens_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // dsEmens
            // 
            this.dsEmens.DataSetName = "VistaEmens";
            this.dsEmens.EnforceConstraints = false;
            this.dsEmens.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "C.F. Persona Mittente";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpDatiMittente
            // 
            this.grpDatiMittente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDatiMittente.Controls.Add(this.txtCFSoftwarehouse);
            this.grpDatiMittente.Controls.Add(this.label6);
            this.grpDatiMittente.Controls.Add(this.txtCFMittente);
            this.grpDatiMittente.Controls.Add(this.label5);
            this.grpDatiMittente.Controls.Add(this.txtRagSocMittente);
            this.grpDatiMittente.Controls.Add(this.label4);
            this.grpDatiMittente.Controls.Add(this.txtCFPersonaMittente);
            this.grpDatiMittente.Controls.Add(this.label3);
            this.grpDatiMittente.Location = new System.Drawing.Point(296, 106);
            this.grpDatiMittente.Name = "grpDatiMittente";
            this.grpDatiMittente.Size = new System.Drawing.Size(495, 152);
            this.grpDatiMittente.TabIndex = 4;
            this.grpDatiMittente.TabStop = false;
            this.grpDatiMittente.Text = "Dati mittente";
            // 
            // txtCFSoftwarehouse
            // 
            this.txtCFSoftwarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCFSoftwarehouse.Location = new System.Drawing.Point(112, 120);
            this.txtCFSoftwarehouse.Name = "txtCFSoftwarehouse";
            this.txtCFSoftwarehouse.Size = new System.Drawing.Size(375, 20);
            this.txtCFSoftwarehouse.TabIndex = 14;
            this.txtCFSoftwarehouse.TabStop = false;
            this.txtCFSoftwarehouse.Tag = "emens.cfsoftwarehouse";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "C.F. Softwarehouse";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCFMittente
            // 
            this.txtCFMittente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCFMittente.Location = new System.Drawing.Point(112, 88);
            this.txtCFMittente.Name = "txtCFMittente";
            this.txtCFMittente.Size = new System.Drawing.Size(375, 20);
            this.txtCFMittente.TabIndex = 12;
            this.txtCFMittente.TabStop = false;
            this.txtCFMittente.Tag = "emens.cfsender";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "C.F. Mittente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRagSocMittente
            // 
            this.txtRagSocMittente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRagSocMittente.Location = new System.Drawing.Point(112, 56);
            this.txtRagSocMittente.Name = "txtRagSocMittente";
            this.txtRagSocMittente.Size = new System.Drawing.Size(375, 20);
            this.txtRagSocMittente.TabIndex = 10;
            this.txtRagSocMittente.TabStop = false;
            this.txtRagSocMittente.Tag = "emens.sendercompanyname";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rag. Soc. Mittente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCFPersonaMittente
            // 
            this.txtCFPersonaMittente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCFPersonaMittente.Location = new System.Drawing.Point(112, 24);
            this.txtCFPersonaMittente.Name = "txtCFPersonaMittente";
            this.txtCFPersonaMittente.Size = new System.Drawing.Size(375, 20);
            this.txtCFPersonaMittente.TabIndex = 8;
            this.txtCFPersonaMittente.TabStop = false;
            this.txtCFPersonaMittente.Tag = "emens.cfhumansender";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.dsEmens.inpscenter;
            this.comboBox1.DisplayMember = "title";
            this.comboBox1.Location = new System.Drawing.Point(304, 80);
            this.comboBox1.MaxDropDownItems = 40;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(487, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Tag = "emens.inpscenter";
            this.comboBox1.ValueMember = "idinpscenter";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(240, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Sede INPS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnApriFile
            // 
            this.btnApriFile.Location = new System.Drawing.Point(163, 112);
            this.btnApriFile.Name = "btnApriFile";
            this.btnApriFile.Size = new System.Drawing.Size(128, 23);
            this.btnApriFile.TabIndex = 5;
            this.btnApriFile.Text = "Vedi Risultato";
            this.btnApriFile.Click += new System.EventHandler(this.btnApriFile_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Data contabile";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(80, 80);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(72, 20);
            this.txtDataContabile.TabIndex = 0;
            this.txtDataContabile.Tag = "emens.adate";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(160, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Anno";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAnno
            // 
            this.txtAnno.Location = new System.Drawing.Point(192, 80);
            this.txtAnno.Name = "txtAnno";
            this.txtAnno.Size = new System.Drawing.Size(40, 20);
            this.txtAnno.TabIndex = 1;
            this.txtAnno.Tag = "emens.yearnumber.year";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Da";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(32, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.Tag = "emens.startmonth";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(72, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "A";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(32, 20);
            this.textBox2.TabIndex = 17;
            this.textBox2.Tag = "emens.stopmonth";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(8, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 44);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mesi di inizio e fine";
            // 
            // txtNomeFile
            // 
            this.txtNomeFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeFile.Location = new System.Drawing.Point(88, 48);
            this.txtNomeFile.Name = "txtNomeFile";
            this.txtNomeFile.ReadOnly = true;
            this.txtNomeFile.Size = new System.Drawing.Size(703, 20);
            this.txtNomeFile.TabIndex = 19;
            // 
            // btnSalvaFile
            // 
            this.btnSalvaFile.Location = new System.Drawing.Point(8, 48);
            this.btnSalvaFile.Name = "btnSalvaFile";
            this.btnSalvaFile.Size = new System.Drawing.Size(75, 23);
            this.btnSalvaFile.TabIndex = 20;
            this.btnSalvaFile.Text = "File Xml";
            this.btnSalvaFile.Click += new System.EventHandler(this.btnSalvaFile_Click);
            // 
            // dgPrestazione
            // 
            this.dgPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPrestazione.DataMember = "";
            this.dgPrestazione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPrestazione.Location = new System.Drawing.Point(8, 430);
            this.dgPrestazione.Name = "dgPrestazione";
            this.dgPrestazione.Size = new System.Drawing.Size(783, 151);
            this.dgPrestazione.TabIndex = 21;
            // 
            // dgRitenuta
            // 
            this.dgRitenuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRitenuta.DataMember = "";
            this.dgRitenuta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRitenuta.Location = new System.Drawing.Point(8, 286);
            this.dgRitenuta.Name = "dgRitenuta";
            this.dgRitenuta.Size = new System.Drawing.Size(783, 122);
            this.dgRitenuta.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 411);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Prestazioni Considerate:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Ritenute Considerate:";
            // 
            // lblAvviso
            // 
            this.lblAvviso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvviso.Location = new System.Drawing.Point(8, 8);
            this.lblAvviso.Name = "lblAvviso";
            this.lblAvviso.Size = new System.Drawing.Size(783, 40);
            this.lblAvviso.TabIndex = 25;
            this.lblAvviso.Text = resources.GetString("lblAvviso.Text");
            this.lblAvviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnified
            // 
            this.txtUnified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnified.Location = new System.Drawing.Point(8, 211);
            this.txtUnified.Multiline = true;
            this.txtUnified.Name = "txtUnified";
            this.txtUnified.ReadOnly = true;
            this.txtUnified.Size = new System.Drawing.Size(282, 53);
            this.txtUnified.TabIndex = 26;
            this.txtUnified.Text = "Attenzione, sarà generato una denuncia consolidata di ateneo con i dati di tutti " +
    "i dipartimenti presenti nel database.";
            // 
            // btnGeneraUniEmens
            // 
            this.btnGeneraUniEmens.Location = new System.Drawing.Point(150, 162);
            this.btnGeneraUniEmens.Name = "btnGeneraUniEmens";
            this.btnGeneraUniEmens.Size = new System.Drawing.Size(128, 23);
            this.btnGeneraUniEmens.TabIndex = 27;
            this.btnGeneraUniEmens.Text = "Genera UniE-Mens";
            this.btnGeneraUniEmens.Click += new System.EventHandler(this.btnGeneraUniEmens_Click);
            // 
            // Frm_emens_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(799, 591);
            this.Controls.Add(this.btnGeneraUniEmens);
            this.Controls.Add(this.txtUnified);
            this.Controls.Add(this.lblAvviso);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgRitenuta);
            this.Controls.Add(this.dgPrestazione);
            this.Controls.Add(this.btnSalvaFile);
            this.Controls.Add(this.txtNomeFile);
            this.Controls.Add(this.txtAnno);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnApriFile);
            this.Controls.Add(this.grpDatiMittente);
            this.Controls.Add(this.btnGeneraEmens);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Name = "Frm_emens_default";
            this.Text = "FrmDenunceRetributiveMensili";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmens)).EndInit();
            this.grpDatiMittente.ResumeLayout(false);
            this.grpDatiMittente.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrestazione)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRitenuta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void scriviXml(DataRow row, string[] col, string []sourcecol) 
		{
			for (int i=0;i<col.Length;i++) {
				string c=col[i];
				string source=sourcecol[i];
				if (!(row[source] is DBNull)) {
					if (row[source] is DateTime) {
						DateTime d = (DateTime) row[source];
						writer.WriteElementString(c, d.ToString("yyyy-MM-dd"));
					} 
					else {
						writer.WriteElementString(c, row[source].ToString().ToUpper());
					}
				}
			}
		}

        private void Esegui() 
		{
			string filter_auto="";
			DateTime Datainizio, Datafine;

            int taxkind = 0;
            foreach (DataRow R in DS.tax.Rows) {
                taxkind = CfgFn.GetNoNullInt32(R["taxkind"]);
                switch (taxkind)
                {
                    case 1: R["!taxcategory"] = "Fiscale"; break;
                    case 2: R["!taxcategory"] = "Assistenziale"; break;
                    case 3: R["!taxcategory"] = "Previdenziale"; break;
                    case 4: R["!taxcategory"] = "Assicurativa"; break;
                    case 5: R["!taxcategory"] = "Arretrati"; break;
                    case 6: R["!taxcategory"] = "Altro"; break;
                }
            }
            Make_T_unified();
			foreach (DataRow R in DS.tax.Rows) 
			{
				filter_auto = "(taxcode = "+QueryCreator.quotedstrvalue(R["taxcode"],false)+ ") AND " +	filter_eserc;
				DataTable Ttaxsetup = meta.Conn.RUN_SELECT("taxsetup","*",null, filter_auto, null, true);
				DataRow[] Rauto = Ttaxsetup.Select(filter_auto, null);

				if (Rauto.Length==0) continue;
				if (!ControllaConfRitenuta(Rauto[0])) continue;
				Datainizio=new DateTime(1,1,1);
				Datafine=new DateTime(1,1,1);
				CalcolaDateDaPeriodo(Rauto[0],out Datainizio,out Datafine);
				if (!CallStoredProcedure(R["taxcode"],Datainizio,Datafine)) continue;
				else 
				{
                    if (meta.edit_type != "unified")
                    {
                        show("Ci sono ritenute applicate e non liquidate", "Informazioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MetaData Metataxpay = MetaData.GetMetaData(this, "taxpay");
                        Metataxpay.Edit(meta.linkedForm.ParentForm, "ritenutedapagare", true);

                        return;
                    }
				}
			}

            if ((meta.edit_type == "unified") && (T_unified.Rows.Count>0))
                {
                    ImpostaCaptionRitDaLiquidare(T_unified);
                    DataSet DSunified = new DataSet();
                    DSunified.Tables.Add(T_unified);
                    FrmDettaglioRisultati X = new FrmDettaglioRisultati(DSunified.Tables["T_unified"]);
                    X.Text = "Ritenute applicate ma non liquidate";
                    X.ShowDialog(this);
                }
            T_unified.Clear();
            
		}

		private bool ControllaConfRitenuta(DataRow RigaAutRiten) 
		{
			if (RigaAutRiten["expiringday"].ToString()=="") return false;
			if (Convert.ToInt32(RigaAutRiten["expiringday"]) < 1) return false;
			if (RigaAutRiten["idexpirationkind"].ToString()=="") return false;
			int mesiperiodicita=Convert.ToInt32(RigaAutRiten["idexpirationkind"]);
			if ((mesiperiodicita < 1) || (mesiperiodicita > 12) || (mesiperiodicita==5) ||
				(mesiperiodicita==7) || (mesiperiodicita==8) || (mesiperiodicita==9) || 
				(mesiperiodicita==10) || (mesiperiodicita==11)) 
				return false;
			return true;
		}
		private int CalcolaPeriodo (int mese, int mesiperiodicita, DataRow RigaAutRiten) 
		{
			if (
                  ((CfgFn.GetNoNullInt32(RigaAutRiten["flag"]) & 0x08) == 0) && 
				mese <= mesiperiodicita) return 1;
			int periodo = mese / mesiperiodicita;
			if (mese % mesiperiodicita > 0) periodo++;
            if ((CfgFn.GetNoNullInt32(RigaAutRiten["flag"]) & 0x08) != 0)
			{
				int day=((DateTime)meta.GetSys("datacontabile")).Day;
				if (day <= Convert.ToInt16(RigaAutRiten["expiringday"])) periodo--;
			}
			return periodo;
		}

		private bool CalcolaDateDaPeriodo (DataRow RigaAutRiten, out DateTime DataInizio,
			out DateTime DataFine) 
		{
			int mesiperiodicita = Convert.ToInt32(RigaAutRiten["idexpirationkind"]);
			DataInizio = new DateTime(1,1,1);
			DataFine = new DateTime(1,1,1);
			if (12 % mesiperiodicita > 0) 
			{
				// periodo non ammesso!
				return false;
			}
			int annocorrente = (int)meta.GetSys("esercizio");//(int)Conn.sys["esercizio"];
			int mesecorrente = ((DateTime)meta.GetSys("datacontabile")).Month;
			int periodocorrente = CalcolaPeriodo(mesecorrente, mesiperiodicita, RigaAutRiten);
			if (periodocorrente < 1) 
			{ // vero se tipoperiodo=P e se il periodo è il primo dell'anno
				// si posiziona sull'ultimo periodo dell'anno precedente
				periodocorrente=12/mesiperiodicita;
				annocorrente--;
			}

			int meseinizioperiodo = mesiperiodicita*(periodocorrente-1)+1;
			int mesefineperiodo = mesiperiodicita*periodocorrente;
			DataInizio = new DateTime(annocorrente, meseinizioperiodo, 1);
			DataFine = new DateTime(annocorrente, mesefineperiodo, 
			DateTime.DaysInMonth(annocorrente, mesefineperiodo));
			return true;
		}

        private void Make_T_unified()
        {
            T_unified.Columns.Add("tax");
            T_unified.Columns.Add("taxref");
            T_unified.Columns.Add("nmov");
            T_unified.Columns.Add("ymov");
            T_unified.Columns.Add("amount");
            T_unified.Columns.Add("ayear");
            T_unified.Columns.Add("refmonth");
            T_unified.Columns.Add("departmentname");
        }

		private bool CallStoredProcedure(object codiceritenuta, DateTime datainizio, DateTime datafine) 
		{
			DataSet Out = meta.Conn.CallSP("compute_taxpay"+unif_suffix, 
				new object[] {datainizio.Year, codiceritenuta, datafine},true,-1);

			if (Out==null) return false;
			if (Out.Tables.Count==0) return false;
            //if (Out.Tables[0].Rows.Count == 0) return true;
            foreach (DataRow R in Out.Tables[0].Select()) 
            {
                DataRow Rrit = T_unified.NewRow();
                Rrit["nmov"] = R["nmov"];
                Rrit["ymov"] = R["ymov"];
                Rrit["amount"] = R["amount"];
                Rrit["ayear"] = R["ayear"];
                Rrit["refmonth"] = R["refmonth"];
                Rrit["tax"] = R["tax"];
                Rrit["taxref"] = R["taxref"];
                Rrit["departmentname"] = R["departmentname"];
                T_unified.Rows.Add(Rrit);
            }
            return (Out.Tables[0].Rows.Count > 0);
    	}

		void impostaCaption(DataTable dt) {
			dt.Columns["severity"].Caption = "Gravità";
			dt.Columns["errore"].Caption = "Errore";
			dt.Columns["soluzione"].Caption = "Soluzione";
            if (Unified) dt.Columns["dipartimento"].Caption = "Dipartimento";
		}
        void ImpostaCaptionRitDaLiquidare(DataTable dt) {
            dt.Columns["taxref"].Caption = "Cod.Ritenute";
            dt.Columns["tax"].Caption = "Ritenute";
            dt.Columns["nmov"].Caption = "Num.Mov";
            dt.Columns["ymov"].Caption = "Eserc.Mov";
            dt.Columns["amount"].Caption = "Importo";
            dt.Columns["ayear"].Caption = "Esercizio";
            dt.Columns["refmonth"].Caption = "Mese Riferimento";
            if (Unified) dt.Columns["departmentname"].Caption = "Dipartimento";
       }
        bool checkEmens(object adate, object yearnumber, object startmonth, object stopmonth)
        {
            // Chiamata della S.P. di controllo
            string errMsg;
            object unified;
            if (meta.edit_type == "unified") {
                unified = 'S';
                    }
                    else { 
                unified = 'N'; }
            DataSet dsCheck = meta.Conn.CallSP("check_emens",
                new object[] { DBNull.Value, yearnumber, startmonth, stopmonth, unified }, -1, out errMsg);
            if (errMsg != null)
            {
                show(this, errMsg);
                return false;
            }

            if (dsCheck.Tables != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0].Rows.Count > 0)
            {
                impostaCaption(dsCheck.Tables[0]);
                FrmDettaglioRisultati X = new FrmDettaglioRisultati(dsCheck.Tables[0]);
                X.ShowDialog(this);

                DataRow[] R = dsCheck.Tables[0].Select("severity = 'S'");
                if (R.Length > 0)
                {
                    show(this, "Sono stati riscontrati degli errori bloccanti, l'E-Mens non verrà generato!\nCorreggere prima tali errori");
                    return false;
                }
                else
                {
                    show(this, "Sono stati riscontrati degli errori non bloccanti, l'E-Mens verrà comunque generato ma potrebbe essere comunicati dati non corretti");
                }
            }
            return true;
        }

        private string sostituiscipuntoconvirgola(decimal importo) {
            string group = System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
            string dec = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            string s1 = importo.ToString("g").Replace(group, "");
            return s1.Replace(dec, ",");
        }

        private void GeneraEmens(string emensKind){
            meta.GetFormData(true);
            DataRow Curr = DS.emens.Rows[0];

            // Controllo che siano presenti i dati editabili nel form
            string messaggio1 = "";
            if (Curr["adate"] == DBNull.Value) messaggio1 += ", 'Data contabile'";
            if (Curr["startmonth"] == DBNull.Value) messaggio1 += ", 'Mese inizio'";
            if (Curr["stopmonth"] == DBNull.Value) messaggio1 += ", 'Mese fine'";
            if (Curr["yearnumber"] == DBNull.Value) messaggio1 += ", 'Anno'";
            if (Curr["inpscenter"] == DBNull.Value) messaggio1 += ", 'Sede inps'";

            bool eseguiGenerazione = messaggio1 == "";
            if (!eseguiGenerazione)
            {
                show(this, "Inserire " + messaggio1.Substring(1));
                return;
            }
            // Controllo che siano presenti i dati non editabili nel form
            string messaggio2 = "";
            if (Curr["cfhumansender"].ToString() == "") messaggio2 += ", Codice Fiscale del Responsabile";
            if (Curr["sendercompanyname"].ToString() == "") messaggio2 += ", Ragione Sociale del Mittente";
            if (Curr["cfsender"].ToString() == "") messaggio2 += ", Codice Fiscale del Mittente";
            if (Curr["cfsoftwarehouse"].ToString() == "") messaggio2 += ", Codice Fiscale Software House";

            eseguiGenerazione = messaggio2 == "";
            if (!eseguiGenerazione)
            {
                show(this, "Inserire una nuova denuncia, l'attuale non può essere utilizzata in quanto mancano i seguenti dati:\n" + messaggio2.Substring(1));
                return;
            }

            bool res = checkEmens(DS.emens.Rows[0]["adate"],
                                 DS.emens.Rows[0]["yearnumber"],
                                 DS.emens.Rows[0]["startmonth"],
                                 DS.emens.Rows[0]["stopmonth"]);
            if (!res) return;

            string errMsg;
            DataSet dsAziende = meta.Conn.CallSP("emens_getAziende",
                new object[] {DS.emens.Rows[0]["adate"],
								 DS.emens.Rows[0]["yearnumber"],
								 DS.emens.Rows[0]["startmonth"],
								 DS.emens.Rows[0]["stopmonth"]},
                -1, out errMsg);
            if (errMsg != null){
                show(this, errMsg);
                return;
            }
            StringWriter sw = new StringWriter();
            writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented;

            if (emensKind == "E"){
                writer.WriteStartElement("DenunceRetributiveMensili");
                writer.WriteStartElement("DatiMittente");
            }
            else {
                writer.WriteStartElement("DenunceMensili");
                writer.WriteStartElement("DatiMittente");
                writer.WriteAttributeString("Tipo", "1");
            }

            scriviXml(DS.emens.Rows[0],
                new string[] { "CFPersonaMittente", "RagSocMittente", "CFMittente", "CFSoftwarehouse", "SedeINPS" },
                new string[] { "cfhumansender", "sendercompanyname", "cfsender", "cfsoftwarehouse", "inpscenter" });
            writer.WriteEndElement();//"DatiMittente"

            int numCollaboratori = 0;
            int numLavorSpettacolo = 0;
            foreach (DataRow rAzienda in dsAziende.Tables[0].Rows) {
                int meseDenuncia = (int)rAzienda["mesedenuncia"];
                string annoMeseDenuncia = rAzienda["annodenuncia"] + "-" + meseDenuncia.ToString("00");

                // Il parametro @adate per il momento è DBNull.Value, è stato introdotto per il il futuro annullamento.
                object[] paramValues = new object[6] {rAzienda["annodenuncia"], rAzienda["mesedenuncia"], rAzienda["cfazienda"],
                                        DBNull.Value, null, null};
                DataSet dsListaCollaboratori = meta.Conn.CallSPParameterDataSet("emens_getListaCollaboratori",
                    new string[] { "@ycommunication", "@mcommunication", "@cf_enterprise", "@adate", "@cap", "@istat" },
                    new SqlDbType[] {SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.DateTime, 
                                    SqlDbType.VarChar, SqlDbType.VarChar},
                    new int[] { 0, 0, 0, 0, 5, 5 },
                    new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input,
                                    ParameterDirection.Input, ParameterDirection.Output, ParameterDirection.Output },
                    ref paramValues, -1, out errMsg);

                if (errMsg != null){
                    show(this, errMsg);
                    writer.Close();
                    return;
                }
                //string estraiEnpals = "N";

                //if (chkCompilaEnpals.Checked) estraiEnpals = "S";

               //Chiama SP per PosContributiva PER LE PRESTAZIONI ENPALS
               //object[] paramValues_poscontr = new object[6] {rAzienda["annodenuncia"], rAzienda["mesedenuncia"],  rAzienda["mesedenuncia"], "E",
               //                         DBNull.Value, estraiEnpals};
               // DataSet dsDatiPosContributiva = meta.Conn.CallSPParameterDataSet("emens_datiPosContributiva",
               //     new string[] { "@ycommunication", "@startmonth", "@stopmonth", "@parentsp", "@adate","@estrai" },
               //     new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.DateTime, SqlDbType.VarChar },
               //     new int[] { 0, 0, 0, 5, 5, 1},
               //     new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input },
               //     ref paramValues_poscontr, -1, out errMsg);

               // if (errMsg != null){
               //     show(this, errMsg);
               //     writer.Close();
               //     return;
               // }

                numCollaboratori += dsListaCollaboratori.Tables[0].Rows.Count;
                //numLavorSpettacolo+=dsDatiPosContributiva.Tables[0].Rows.Count;
                if ((dsListaCollaboratori.Tables[0].Rows.Count == 0) ) { //&& (dsDatiPosContributiva.Tables[0].Rows.Count==0)
                    continue;
                }
                int countCollaborazioni = dsListaCollaboratori.Tables[0].Rows.Count;// + dsDatiPosContributiva.Tables[0].Rows.Count;
                show(this,
                                "Trovate " + countCollaborazioni.ToString() + " collaborazioni per il mese di " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(meseDenuncia) + ".",
                                "Informazioni");
                writer.WriteStartElement("Azienda");
                writer.WriteElementString("AnnoMeseDenuncia", annoMeseDenuncia);
                scriviXml(rAzienda, new string[] { "CFAzienda", "RagSocAzienda" },
                                    new string[] { "CFAzienda", "RagSocAzienda" });

                // Apre <PosContributiva>
                //if(dsDatiPosContributiva.Tables[0].Rows.Count>0) {
                //    writer.WriteStartElement("PosContributiva");
                //    writer.WriteAttributeString("Composizione", "CP");
                //    string agencynumber = meta.Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", rAzienda["annodenuncia"]), "agencynumber").ToString();
                //    if (agencynumber.Length<10) {
                //        show(this, "Inserire la Matricola aziendale INPS(10 caratteri numerici) in Configurazione Annuale-Compensi.");
                //        return;
                //    }
                //    if (agencynumber.Length > 10) {
                //        agencynumber = agencynumber.Substring(0, 10);
                //    }
                //    decimal epsilon = 0.5M;
                //    writer.WriteElementString("Matricola", agencynumber);
                //    foreach (DataRow rDenunciaIndividuale in dsDatiPosContributiva.Tables[0].Rows) {
                //        writer.WriteStartElement("DenunciaIndividuale");
                //        scriviXml(rDenunciaIndividuale, new string[] {"CFLavoratore", "Cognome", "Nome", 
                //            "Qualifica1", "Qualifica2","Qualifica3","RegimePost95","Cittadinanza","CodiceComune","CodiceContratto","TipoPaga"},
                //            new string[] {"CFLavoratore", "Cognome", "Nome","Qualifica1", "Qualifica2","Qualifica3",
                //            "RegimePost95","Cittadinanza","CodiceComune","CodiceContratto", "TipoPaga"}
                //            );
                        
                        

                //        foreach (DataRow rDatiRetributivi in dsDatiPosContributiva.Tables[0].Select(QHS.CmpEq("CFLavoratore",rDenunciaIndividuale["CFLavoratore"]))){
                //            writer.WriteStartElement("DatiRetributivi");
                //            writer.WriteElementString("TipoLavoratore", rDatiRetributivi["tipolavoratore"].ToString());
                //            int imponibile = (int)(CfgFn.GetNoNullDecimal(rDatiRetributivi["imponibile"]) + epsilon);
                //            writer.WriteElementString("Imponibile", imponibile.ToString());
                //            decimal contributo = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rDatiRetributivi["contributo"]));
                //            writer.WriteElementString("Contributo", sostituiscipuntoconvirgola(contributo));

                //            //ContribuzioneAggiuntiva  
                //            if (CfgFn.GetNoNullDecimal(rDatiRetributivi["ImponibileCtrAgg"])>0){
                //                writer.WriteStartElement("ContribuzioneAggiuntiva");
                //                writer.WriteStartElement("Contrib1PerCento");
                //                int ImponibileCtrAgg = (int)(CfgFn.GetNoNullDecimal(rDatiRetributivi["ImponibileCtrAgg"]) + epsilon);
                //                writer.WriteElementString("ImponibileCtrAgg", ImponibileCtrAgg.ToString());
                //                decimal ContribAggCorrente = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rDatiRetributivi["ContribAggCorrente"]));
                //                writer.WriteElementString("ContribAggCorrente", sostituiscipuntoconvirgola(ContribAggCorrente));
                //                writer.WriteEndElement();
                //                writer.WriteEndElement();
                //            }                           
                //            writer.WriteElementString("RetribTeorica", imponibile.ToString());

                //            DateTime start = (DateTime) rDatiRetributivi["start"];
                //            DateTime stop = (DateTime)rDatiRetributivi["stop"];
                //            DateTime gg = start;
                //            while (gg.CompareTo(stop) < 0) {
                //                writer.WriteStartElement("Giorno");
                //                writer.WriteAttributeString("GG", gg.Day.ToString());
                //                writer.WriteElementString("Lavorato", "S");
                //                writer.WriteElementString("TipoCoperturaGiorn", "X");
                //                writer.WriteEndElement();
                //                gg = gg.AddDays(1);
                //            }
                //            writer.WriteElementString("GiorniContribuiti", CfgFn.GetNoNullInt32(rDatiRetributivi["GiorniContribuiti"]).ToString());

                //            writer.WriteStartElement("DatiParticolari");

                //            if (CfgFn.GetNoNullDecimal(rDatiRetributivi["ImpEccMassSpet"]) > 0) {
                                
                //                writer.WriteStartElement("EccMassSportSpet");
                //                writer.WriteStartElement("EccMassSpet");
                //                int ImpEccMassSpet = (int)(CfgFn.GetNoNullDecimal(rDatiRetributivi["ImpEccMassSpet"]) + epsilon);
                //                writer.WriteElementString("ImpEccMassSpet", ImpEccMassSpet.ToString());
                //                decimal ContrEccMassSpet = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rDatiRetributivi["ContrEccMassSpet"]));
                //                writer.WriteElementString("ContrEccMassSpet", sostituiscipuntoconvirgola(ContrEccMassSpet));
                //                writer.WriteElementString("ContrSolidarietaSpet", rDatiRetributivi["ContrSolidarietaSpet"].ToString());
                //                writer.WriteEndElement();//chiudeEccMassSportSpet
                //                writer.WriteEndElement();//EccMassSportSpet
                //            }
                //            writer.WriteStartElement("TipoLavSportSpet");
                //            writer.WriteElementString("TipoRapportoLav", rDatiRetributivi["TipoRapportoLav"].ToString());
                //            //writer.WriteElementString("CodiceQualifica", rDatiRetributivi["TipoRapportoLav"].ToString());                            
                //            writer.WriteEndElement();

                //            writer.WriteEndElement();//DatiParticolari

                //            writer.WriteEndElement();//DatiRetributivi
                //        }
                //        writer.WriteEndElement();//"DenunciaIndividuale"
                //    }
                //    DataRow rDenunciaAziendale = dsDatiPosContributiva.Tables[0].Rows[0];
                //    writer.WriteStartElement("DenunciaAziendale");
                //        writer.WriteElementString("TrattQuotaLav", rDenunciaAziendale["TrattQuotaLav"].ToString());
                //        writer.WriteElementString("NumLavoratori", rDenunciaAziendale["NumLavoratori"].ToString());
                //        writer.WriteElementString("ForzaAziendale", rDenunciaAziendale["ForzaAziendale"].ToString());
                //        writer.WriteStartElement("DatiQuadraturaRetrContr");
                //            writer.WriteElementString("NumDenIndiv", rDenunciaAziendale["NumDenIndiv"].ToString());
                //            int TotaleADebito = (int)(CfgFn.GetNoNullDecimal(rDenunciaAziendale["TotaleADebito"]) + epsilon);
                //            writer.WriteElementString("TotaleADebito", TotaleADebito.ToString());
                //            writer.WriteElementString("TotaleACredito", rDenunciaAziendale["TotaleACredito"].ToString());
                //        writer.WriteEndElement();//chiude DatiQuadraturaRetrContr

                //    writer.WriteEndElement();// chiude DenunciaAziendale
                //    writer.WriteEndElement();// Chiude </PosContributiva>
                //}

                if (dsListaCollaboratori.Tables[0].Rows.Count>0){
                    // Apre <ListaCollaboratori>
                    writer.WriteStartElement("ListaCollaboratori");
                    writer.WriteElementString("CAP", paramValues[4].ToString());
                    writer.WriteElementString("ISTAT", paramValues[5].ToString());

                    if (dsListaCollaboratori.Tables[0].Rows.Count > 0){
                        string errore = (emensKind == "E" ? "L' E-emens" : "L' UniE-emens");
                            errore=errore+
                                  " non sarà valido, sarà necessaria una ulteriore elaborazione perchè i seguenti "
                                + "collaboratori sono presenti più volte con le stesse"
                                + "\n informazioni, violando pertanto, requisiti tecnici per la compilazione dei flussi delle "
                                + "denunce retributive mensili : \n";
                        int counterr = 0;
                        string filtro = "";
                        DateTime dal, al;
                        foreach (DataRow r in dsListaCollaboratori.Tables[0].Rows){
                            filtro = QHC.AppAnd(
                            QHC.CmpEq("CFCollaboratore", r["CFCollaboratore"]),
                            QHC.CmpEq("TipoRapporto", r["TipoRapporto"]),
                            QHC.CmpEq("Aliquota", r["Aliquota"]));
                            if (dsListaCollaboratori.Tables[0].Select(filtro).Length > 1)
                            {
                                counterr++;
                                dal = (DateTime)(HelpForm.GetObjectFromString(typeof(DateTime), r["dal"].ToString(), "x.y"));
                                al = (DateTime)(HelpForm.GetObjectFromString(typeof(DateTime), r["al"].ToString(), "x.y"));
                                errore += "\n CFCollaboratore: " + r["CFCollaboratore"]
                                    + "  - TipoRapporto: " + r["TipoRapporto"]
                                    + "  - Aliquota: " + r["Aliquota"]
                                    + "  - CodiceAttivita: " + r["CodiceAttivita"]
                                    + "  - AltraAss: " + r["AltraAss"]
                                    + "  - Dal: " + dal.Day.ToString() + "/" + dal.Month.ToString() + "/" + dal.Year.ToString()
                                    + " Al: " + al.Day.ToString() + "/" + al.Month.ToString() + "/" + al.Year.ToString()
                                    + ". ("+filtro+")";
                            }
                        }
                        errore += "\n\n L'E-mens verrà comunque generato.";
                        if (counterr != 0)
                            show(this, errore, "Informazioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    foreach (DataRow rCollaboratore in dsListaCollaboratori.Tables[0].Rows){
                        writer.WriteStartElement("Collaboratore");
                        scriviXml(rCollaboratore, new string[] {"CFCollaboratore", "Cognome", "Nome", "CodiceComune",
                            "TipoRapporto", "CodiceAttivita"},
                            new string[] {"CFCollaboratore", "Cognome", "Nome", "CodiceComune", "TipoRapporto", 
										     "CodiceAttivita"}
                            );
                        decimal epsilon = 0.5M;
                        int imponibile = (int)(CfgFn.GetNoNullDecimal(rCollaboratore["imponibile"]) + epsilon);
                        writer.WriteElementString("Imponibile", imponibile.ToString());
                        int moltiplicatore = 10000;
                        int aliquota = (int)(CfgFn.GetNoNullDecimal(rCollaboratore["aliquota"]) * moltiplicatore + epsilon);

                        writer.WriteElementString("Aliquota", aliquota.ToString());
                        scriviXml(rCollaboratore,
                            new string[] { "AltraAss", "Dal", "Al", "CodCalamita", "CodCertificazione" },
                            new string[] { "AltraAss", "Dal", "Al", "CodCalamita", "CodCertificazione" }
                            );
                        writer.WriteEndElement();//"Collaboratore"
                    }
                    writer.WriteEndElement();// Chiude </ListaCollaboratori>
                }//chiude l'if sul count di ListaCollaboratori

                writer.WriteEndElement();//Chiude </Azienda>
            }//fine foeach Azienda
            writer.WriteEndElement();//"DenunceRetributiveMensili"
            writer.Close();

            if (numCollaboratori + numLavorSpettacolo  == 0) {
                show(this, "Nel periodo indicato non ci sono ritenute INPS, pertanto l'E-Mens generato non sarà valido."
                    + "\nAnno: " + DS.emens.Rows[0]["yearnumber"]
                    + "\nMese inizio: " + DS.emens.Rows[0]["startmonth"]
                    + "\nMese fine: " + DS.emens.Rows[0]["stopmonth"]);
            }
            string xmlString = sw.ToString();

            byte[] xml = new UTF8Encoding().GetBytes(xmlString);

            DS.emens.Rows[0]["rtf"] = xml;

            DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;
            txtNomeFile.Text = saveFileDialog1.FileName;

            StreamWriter stw = new StreamWriter(saveFileDialog1.OpenFile());
            stw.Write(sw.ToString());
            stw.Close();

            btnApriFile.Enabled = true;
            btnSalvaFile.Enabled = true;

        }

		private void btnGeneraEmens_Click(object sender, System.EventArgs e){
            GeneraEmens("E");
		}

		private void btnApriFile_Click(object sender, System.EventArgs e)
		{
			XmlDocument document = new XmlDocument();
			DialogResult dr = openFileDialog1.ShowDialog(this);
			if (dr != DialogResult.OK) return;
			txtNomeFile.Text = openFileDialog1.FileName;
			try
			{
				runProcess(txtNomeFile.Text, true);
				document.Load(txtNomeFile.Text);
			}
			catch(Exception ex)
			{
				string messaggio = "Non riesco ad aprire il file: " + txtNomeFile.Text +
					"\nErrore: " + ex.Message;
				show(this,messaggio);
				return;
			}
			dsEmens.Emens.Clear();
			
			XmlElement DenunceRetributiveMensili = document.DocumentElement;
			XmlElement DatiMittente = DenunceRetributiveMensili["DatiMittente"];
			foreach (XmlElement Azienda in DenunceRetributiveMensili.GetElementsByTagName("Azienda")) 
			{
                string filtroEsercizio = QHC.CmpEq("ayear", Azienda["AnnoMeseDenuncia"].InnerText.Substring(0, 4));
                    //"(ayear = " + Azienda["AnnoMeseDenuncia"].InnerText.Substring(0,4) + ")";
				XmlElement ListaCollaboratori = Azienda["ListaCollaboratori"];
				foreach (XmlElement Collaboratore in ListaCollaboratori.GetElementsByTagName("Collaboratore"))
				{
                    DataRow rEmens = dsEmens.Emens.NewRow();
                    rEmens["AnnoMeseDenuncia"] = mese(Azienda["AnnoMeseDenuncia"]);
                    rEmens["CFAzienda"] = valore(Azienda["CFAzienda"], true);
                    rEmens["CFCollaboratore"] = valore(Collaboratore["CFCollaboratore"], true);
                    rEmens["Cognome"] = valore(Collaboratore["Cognome"], false);
                    rEmens["Nome"] = valore(Collaboratore["Nome"], false);
                    rEmens["CodiceComune"] = valore(Collaboratore["CodiceComune"], false);
                    rEmens["TipoRapporto"] = decodifica(Collaboratore["TipoRapporto"], dsEmens.emenscontractkind, filtroEsercizio, "idemenscontractkind", "description");
                    rEmens["CodiceAttivita"] = decodifica(Collaboratore["CodiceAttivita"], dsEmens.inpsactivity, filtroEsercizio, "activitycode", "description");
                    rEmens["Imponibile"] = valuta(Collaboratore["Imponibile"]);
                    rEmens["Aliquota"] = percentuale(Collaboratore["Aliquota"], true);
                    rEmens["AltraAss"] = decodifica(Collaboratore["AltraAss"], dsEmens.otherinsurance, filtroEsercizio, "idotherinsurance", "description");
                    rEmens["Dal"] = giorno(Collaboratore["Dal"]);
                    rEmens["Al"] = giorno(Collaboratore["Al"]);
                    rEmens["CodCalamita"] = valore(Collaboratore["CodCalamita"], false);
                    rEmens["CodCertificazione"] = valore(Collaboratore["CodCertificazione"], false);
					
                    dsEmens.Emens.Rows.Add(rEmens);
				}
			}
			new FrmDettaglioRisultati(dsEmens.Emens).ShowDialog(this);
		}

		void salvaFile()
		{
			DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
			if (dialogResult==DialogResult.Cancel) return;
			txtNomeFile.Text = saveFileDialog1.FileName;

            byte[] xml = (byte[])DS.emens.Rows[0]["rtf"];

			Stream stream = saveFileDialog1.OpenFile();
			stream.Write(xml, 0, xml.Length);
			stream.Close();
		}

		private void btnSalvaFile_Click(object sender, System.EventArgs e)
		{
			salvaFile();
		}

		public void MetaData_AfterClear() 
		{
			meta.CanSave = true;
			txtNomeFile.Text = null;
			btnApriFile.Enabled = true;
			btnSalvaFile.Enabled = false;
			btnGeneraEmens.Enabled = false;
            btnGeneraUniEmens.Enabled = false;
			gestisciGrpDatiMittente(true);
		}

		public void MetaData_BeforeFill() 
		{
			btnGeneraEmens.Enabled = true;
            btnGeneraUniEmens.Enabled = true;
			string errMess;
			if (!meta.FirstFillForThisRow) return;
			if (meta.InsertMode)
			{	
				btnApriFile.Enabled = false;
				DataSet dsMittente = 
					meta.Conn.CallSP("emens_getDatiMittente",new object [] {meta.GetSys("esercizio")},-1,out errMess);
				if (dsMittente == null) return;
				if (dsMittente.Tables.Count == 0) return;
				DataRow Source=dsMittente.Tables[0].Rows[0];
				DataRow Curr=DS.emens.Rows[0];
				Curr["cfsender"]=Source["cfmittente"];
				Curr["cfhumansender"]=Source["cfpersonamittente"];
				Curr["cfhumansender"]=Source["cfpersonamittente"];
				Curr["cfsoftwarehouse"]=Source["cfsoftwarehouse"];
				Curr["sendercompanyname"]=Source["ragsocmittente"];
			}
			gestisciGrpDatiMittente(false);
			if (meta.EditMode)
			{
				btnApriFile.Enabled = true;
			}
		}

		public void MetaData_AfterActivation() 
		{
           Esegui();
		}
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink()
		{
			meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = meta.Conn.GetQueryHelper();
			GetData.CacheTable(DS.inpscenter,null,"title",true);
			riempiGridPrestazioneERitenuta();
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.emenscontractkind, null, null, null, true);
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.inpsactivity, null, null, null, true);
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.otherinsurance, null, null, null, true);

            filter_eserc = QHC.CmpEq("ayear", meta.GetSys("esercizio"));

            txtUnified.Visible = false;
            if (meta.edit_type == "unified") {
                Unified = true;
                unif_suffix = "_unified";
                txtUnified.Visible = true;
            }

		    btnGeneraEmens.Visible = meta.Conn.GetEsercizio() <= 2016;
		    //chkCompilaEnpals.Checked = false;

		}

		private void azzeraCaption(DataTable dt)
		{
			foreach(DataColumn C in dt.Columns)
			{
				C.Caption = "";
			}
		}

		int numValoriAssenti = 0;
		private string valore(XmlElement nodo,bool isKey)
		{
			if (isKey && nodo==null)
			{
				numValoriAssenti++;
				return "VALORE ASSENTE " + numValoriAssenti;
			}
			if (nodo==null) return null;
			return nodo.InnerText.Trim();
		}

		private string mese(XmlElement nodo) 
		{
			if (nodo==null) return null;
			try {
				DateTime dateTime = DateTime.ParseExact(nodo.InnerText.Trim(), "yyyy-MM", DateTimeFormatInfo.CurrentInfo);
				return dateTime.ToString("MMMM yyyy");
			} 
			catch {
				show("Data "+nodo.InnerText+ " non in formato yyyy-MM.");
				return "";
			}
		}

		private string giorno(XmlElement nodo) 
		{
			if (nodo==null) return null;
			try {
				DateTime dateTime = DateTime.ParseExact(nodo.InnerText.Trim(), "yyyy-MM-dd", DateTimeFormatInfo.CurrentInfo);
				return dateTime.ToShortDateString();
			}
			catch {
				show("Data "+nodo.InnerText+ " non in formato yyyy-MM-dd");
				return "";
			}
		}

		private string decodifica(XmlElement nodo, DataTable tab, string filtroEsercizio, string valueMember, string displayMember) 
		{
			if (nodo==null) return null;
			DataRow[] r = tab.Select(QHC.AppAnd(filtroEsercizio,QHC.CmpEq(valueMember,nodo.InnerText)));
			if (r.Length==0) 
			{
				return "DECODIFICA DI "+nodo.InnerText+" NON RIUSCITA";
			}
			return r[0][displayMember].ToString();
		}

		private string percentuale(XmlElement nodo, bool isKey) 
		{
			if (isKey && nodo == null)
			{
				return "-1";
			}
			if (nodo==null) return null;
			try {
				decimal p = Decimal.Parse(nodo.InnerText.Trim())/10000;
				return p.ToString("p");
			}
			catch {
				show("Percentuale "+nodo.InnerText+ " non riconosciuta");				
				return "";
			}
		}

		private string valuta(XmlElement nodo) 
		{
			if (nodo==null) return null;
			try {
				decimal p = Decimal.Parse(nodo.InnerText.Trim());
				return p.ToString("c");
			}
			catch {
				show("Importo "+nodo.InnerText+ " non riconosciuto");				
				return "";
			}
		}

		private void riempiGridPrestazioneERitenuta()
		{
			string filtroPrestazione = "(module IN ('OCCASIONALE','COCOCO','PROFESSIONALE'))";
			GetData.CacheTable(DS.service,filtroPrestazione,"idser",false);
			azzeraCaption(DS.service);
			DS.service.Columns["idser"].Caption = "Cod. Prestazione";
			DS.service.Columns["description"].Caption = "Descr. Prestazione";
			HelpForm.SetDataGrid(dgPrestazione,DS.service);
			new formatgrids(dgPrestazione).AutosizeColumnWidth();

			string filtroRitenuta = "(taxkind = 3) AND (taxref LIKE '%INPS%' or taxref like '%ENPALS%' )";
            GetData.CacheTable(DS.tax, filtroRitenuta, "taxref", false);
			azzeraCaption(DS.tax);

			DS.tax.Columns["taxref"].Caption = "Codice Ritenuta";
			DS.tax.Columns["description"].Caption = "Descr. Ritenuta";
            DS.tax.Columns["!taxcategory"].Caption = "Categoria";

			HelpForm.SetDataGrid(dgRitenuta,DS.tax);
			new formatgrids(dgRitenuta).AutosizeColumnWidth();
		}

		public void gestisciGrpDatiMittente(bool abilita)
		{
			txtCFPersonaMittente.ReadOnly = !abilita;
			txtCFMittente.ReadOnly = !abilita;
			txtCFSoftwarehouse.ReadOnly = !abilita;
			txtRagSocMittente.ReadOnly = !abilita;
		}

		private void txtSedeINPS_Leave(object sender, System.EventArgs e)
		{
			meta.FreshForm();
		}

        private void btnGeneraUniEmens_Click(object sender, EventArgs e){
            GeneraEmens("U");
        }
	}
}
