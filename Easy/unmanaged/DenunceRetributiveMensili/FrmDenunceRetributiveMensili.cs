
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

namespace DenunceRetributiveMensili//DenunceRetributiveMensili//
{
	/// <summary>
	/// Summary description for FrmDenunceRetributiveMensili.
	/// </summary>
	public class Frm_DenunceRetributiveMensili : System.Windows.Forms.Form
	{
		private XmlTextWriter writer;
		public /*Rana:DenunceRetributiveMensili.*/vistaForm DS;
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
		public /*Rana:DenunceRetributiveMensili.*/VistaEmens dsEmens;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_DenunceRetributiveMensili()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Caption per tabella EMENS
			dsEmens.Emens.AnnoMeseDenunciaColumn.Caption = "Mese denuncia";
			dsEmens.Emens.CFAziendaColumn.Caption = "C.F. Azienda";
			dsEmens.Emens.CFCollaboratoreColumn.Caption = "C.F. Collaboratore";
			dsEmens.Emens.CognomeColumn.Caption = "Cognome";
			dsEmens.Emens.NomeColumn.Caption = "Nome";
			dsEmens.Emens.TipoRapportoColumn.Caption = "Tipo rapporto";
			dsEmens.Emens.CodiceAttivitaColumn.Caption = "Codice attività";
			dsEmens.Emens.ImponibileColumn.Caption = "Imponibile";
			dsEmens.Emens.AliquotaColumn.Caption = "Aliquota";
			dsEmens.Emens.AltraAssColumn.Caption = "Altra ass.";
			dsEmens.Emens.DalColumn.Caption = "Dal";
			dsEmens.Emens.AlColumn.Caption = "Al";
			dsEmens.Emens.CodCalamitaColumn.Caption = "";
			dsEmens.Emens.CodCertificazioneColumn.Caption = "";
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.btnGeneraEmens = new System.Windows.Forms.Button();
			this.DS = new /*Rana:DenunceRetributiveMensili.*/vistaForm();
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
			this.dsEmens = new /*Rana:DenunceRetributiveMensili.*/VistaEmens();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpDatiMittente.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPrestazione)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgRitenuta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmens)).BeginInit();
			this.SuspendLayout();
			// 
			// btnGeneraEmens
			// 
			this.btnGeneraEmens.Location = new System.Drawing.Point(16, 184);
			this.btnGeneraEmens.Name = "btnGeneraEmens";
			this.btnGeneraEmens.Size = new System.Drawing.Size(128, 23);
			this.btnGeneraEmens.TabIndex = 4;
			this.btnGeneraEmens.Text = "Genera E-Mens";
			this.btnGeneraEmens.Click += new System.EventHandler(this.btnGeneraEmens_Click);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
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
			this.grpDatiMittente.Location = new System.Drawing.Point(160, 112);
			this.grpDatiMittente.Name = "grpDatiMittente";
			this.grpDatiMittente.Size = new System.Drawing.Size(472, 152);
			this.grpDatiMittente.TabIndex = 4;
			this.grpDatiMittente.TabStop = false;
			this.grpDatiMittente.Text = "Dati mittente";
			// 
			// txtCFSoftwarehouse
			// 
			this.txtCFSoftwarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCFSoftwarehouse.Location = new System.Drawing.Point(112, 120);
			this.txtCFSoftwarehouse.Name = "txtCFSoftwarehouse";
			this.txtCFSoftwarehouse.Size = new System.Drawing.Size(352, 20);
			this.txtCFSoftwarehouse.TabIndex = 14;
			this.txtCFSoftwarehouse.TabStop = false;
			this.txtCFSoftwarehouse.Tag = "emens.cfsoftwarehouse";
			this.txtCFSoftwarehouse.Text = "";
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
			this.txtCFMittente.Size = new System.Drawing.Size(352, 20);
			this.txtCFMittente.TabIndex = 12;
			this.txtCFMittente.TabStop = false;
			this.txtCFMittente.Tag = "emens.cfsender";
			this.txtCFMittente.Text = "";
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
			this.txtRagSocMittente.Size = new System.Drawing.Size(352, 20);
			this.txtRagSocMittente.TabIndex = 10;
			this.txtRagSocMittente.TabStop = false;
			this.txtRagSocMittente.Tag = "emens.sendercompanyname";
			this.txtRagSocMittente.Text = "";
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
			this.txtCFPersonaMittente.Size = new System.Drawing.Size(352, 20);
			this.txtCFPersonaMittente.TabIndex = 8;
			this.txtCFPersonaMittente.TabStop = false;
			this.txtCFPersonaMittente.Tag = "emens.cfhumansender";
			this.txtCFPersonaMittente.Text = "";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DataSource = this.DS.inpscenter;
			this.comboBox1.DisplayMember = "denominazione";
			this.comboBox1.Location = new System.Drawing.Point(304, 80);
			this.comboBox1.MaxDropDownItems = 40;
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(328, 21);
			this.comboBox1.TabIndex = 2;
			this.comboBox1.Tag = "emens.inpscenter";
			this.comboBox1.ValueMember = "codicesede";
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
			this.btnApriFile.Location = new System.Drawing.Point(16, 216);
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
			this.txtDataContabile.Text = "";
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
			this.txtAnno.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 20);
			this.label8.TabIndex = 14;
			this.label8.Text = "Da";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(32, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(32, 20);
			this.textBox1.TabIndex = 15;
			this.textBox1.Tag = "emens.startmonth";
			this.textBox1.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(72, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(16, 20);
			this.label9.TabIndex = 16;
			this.label9.Text = "A";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(96, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(32, 20);
			this.textBox2.TabIndex = 17;
			this.textBox2.Tag = "emens.stopmonth";
			this.textBox2.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.textBox2);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Location = new System.Drawing.Point(8, 112);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(136, 56);
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
			this.txtNomeFile.Size = new System.Drawing.Size(544, 20);
			this.txtNomeFile.TabIndex = 19;
			this.txtNomeFile.Text = "";
			// 
			// btnSalvaFile
			// 
			this.btnSalvaFile.Location = new System.Drawing.Point(8, 48);
			this.btnSalvaFile.Name = "btnSalvaFile";
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
			this.dgPrestazione.Location = new System.Drawing.Point(8, 408);
			this.dgPrestazione.Name = "dgPrestazione";
			this.dgPrestazione.Size = new System.Drawing.Size(624, 128);
			this.dgPrestazione.TabIndex = 21;
			// 
			// dgRitenuta
			// 
			this.dgRitenuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgRitenuta.DataMember = "";
			this.dgRitenuta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgRitenuta.Location = new System.Drawing.Point(8, 272);
			this.dgRitenuta.Name = "dgRitenuta";
			this.dgRitenuta.Size = new System.Drawing.Size(624, 112);
			this.dgRitenuta.TabIndex = 22;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 392);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(152, 16);
			this.label10.TabIndex = 23;
			this.label10.Text = "Prestazioni Considerate:";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 256);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(152, 16);
			this.label11.TabIndex = 24;
			this.label11.Text = "Ritenute Considerate:";
			// 
			// lblAvviso
			// 
			this.lblAvviso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblAvviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblAvviso.Location = new System.Drawing.Point(8, 8);
			this.lblAvviso.Name = "lblAvviso";
			this.lblAvviso.Size = new System.Drawing.Size(624, 40);
			this.lblAvviso.TabIndex = 25;
			this.lblAvviso.Text = "ATTENZIONE VENGONO CONSIDERATI SOLO I MOVIMENTI TRASMESSI NEI MESI COMPRESI TRA Q" +
				"UELLO DI INIZIO E QUELLO DI FINE - NON VERRANNO CONSIDERATI ICREDITORI/DEBITORI " +
				"CON TIPOLOGIA O RUOLO \"PER MANDATI COLLETTIVI\"";
			this.lblAvviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dsEmens
			// 
			this.dsEmens.DataSetName = "VistaEmens";
			this.dsEmens.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// FrmDenunceRetributiveMensili
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 546);
			this.Controls.Add(this.lblAvviso);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.dgRitenuta);
			this.Controls.Add(this.dgPrestazione);
			this.Controls.Add(this.btnSalvaFile);
			this.Controls.Add(this.txtNomeFile);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.txtAnno);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtDataContabile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnApriFile);
			this.Controls.Add(this.grpDatiMittente);
			this.Controls.Add(this.btnGeneraEmens);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label7);
			this.Name = "FrmDenunceRetributiveMensili";
			this.Text = "FrmDenunceRetributiveMensili";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpDatiMittente.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgPrestazione)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgRitenuta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsEmens)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void scriviXml(DataRow row, string[] col) 
		{
			foreach (string c in col) 
			{
				if (!(row[c] is DBNull)) 
				{
					if (row[c] is DateTime) 
					{
						DateTime d = (DateTime) row[c];
						writer.WriteElementString(c, d.ToString("yyyy-MM-dd"));
					} 
					else 
					{
						writer.WriteElementString(c, row[c].ToString().ToUpper());
					}
				}
			}
		}

		private bool controllaAliquota(int aliquota)
		{
			// Questi valori sono stati presi dal sito www.inps.it nella sezione EMENS
			switch(aliquota)
			{
				case 1000:
				{return true;}
				case 1500:
				{return true;}
				case 1750:
				{return true;}
				case 1800:
				{return true;}
				case 1850:
				{return true;}
				case 1900:
				{return true;}
				default:
				{return false;}
			}
		}

		private void btnGeneraEmens_Click(object sender, System.EventArgs e)
		{
			meta.GetFormData(true);
			DataRow Curr = DS.emens[0];
			string messaggio1 = "";
			if (Curr["adate"] == DBNull.Value) messaggio1 += ", 'Data contabile'";
			if (Curr["startmonth"] == DBNull.Value) messaggio1 += ", 'Mese inizio'";
			if (Curr["stopmonth"] == DBNull.Value) messaggio1 += ", 'Mese fine'";
			if (Curr["yearnumber"] == DBNull.Value) messaggio1 += ", 'Anno'";
			if (Curr["inpscenter"] == DBNull.Value) messaggio1 += ", 'Sede inps'";
			bool eseguiGenerazione = messaggio1 == "";
			if (!eseguiGenerazione)
			{
				MessageBox.Show(this,"Inserire "+messaggio1.Substring(1));
				return;
			}
			string errMsg;
			DataSet dsAziende = meta.Conn.CallSP("emens_getAziende",
				new object[] {DS.emens[0]["datacontabile"],
								 DS.emens[0]["anno"],
								 DS.emens[0]["meseinizio"],
								 DS.emens[0]["mesefine"]},
				-1, out errMsg);
			if (errMsg != null)
			{
				MessageBox.Show(this,errMsg);
				return;
			}
			StringWriter sw = new StringWriter();
			writer = new XmlTextWriter(sw);
			writer.Formatting = Formatting.Indented;
		
			writer.WriteStartElement("DenunceRetributiveMensili");

			writer.WriteStartElement("DatiMittente");
			scriviXml(DS.emens[0], new string[] {"CFPersonaMittente", "RagSocMittente", "CFMittente", "CFSoftwarehouse", "SedeINPS"});
			writer.WriteEndElement();//"DatiMittente"

			bool visualizzaMessaggio = true;
			int numCollaboratori = 0;
			foreach (DataRow rAzienda in dsAziende.Tables[0].Rows) 
			{
				
				int meseDenuncia = (int) rAzienda["mesedenuncia"];
				string annoMeseDenuncia = rAzienda["annodenuncia"]+"-"+meseDenuncia.ToString("00");


				object[] paramValues = new object[5] {rAzienda["annodenuncia"], rAzienda["mesedenuncia"], rAzienda["cfazienda"], null, null};
				DataSet dsListaCollaboratori = meta.Conn.CallSPParameterDataSet("emens_getListaCollaboratori",
					new string[] {"@annodenuncia", "@mesedenuncia", "@cfazienda", "@cap", "@istat"},
					new SqlDbType[] {SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar},
					new int[] {0, 0, 0 , 5, 5},
					new ParameterDirection[] {ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Output, ParameterDirection.Output},
					ref paramValues, -1, out errMsg);

				if (errMsg != null)
				{
					MessageBox.Show(this,errMsg);
					writer.Close();
					return;
				}
				numCollaboratori += dsListaCollaboratori.Tables[0].Rows.Count;

				if (dsListaCollaboratori.Tables[0].Rows.Count == 0)
				{
					continue;
				}
				writer.WriteStartElement("Azienda");
				writer.WriteElementString("AnnoMeseDenuncia", annoMeseDenuncia);
				scriviXml(rAzienda, new string[] {"CFAzienda", "RagSocAzienda"});

				writer.WriteStartElement("ListaCollaboratori");
				writer.WriteElementString("CAP", paramValues[3].ToString());
				writer.WriteElementString("ISTAT", paramValues[4].ToString());
				
				foreach (DataRow rCollaboratore in dsListaCollaboratori.Tables[0].Rows) 
				{
					writer.WriteStartElement("Collaboratore");
					scriviXml(rCollaboratore, new string[] {
						"CFCollaboratore", "Cognome", "Nome", "TipoRapporto", 
						"CodiceAttivita"});
					decimal epsilon = 0.5M;
					int imponibile = (int) (CfgFn.GetNoNullDecimal(rCollaboratore["imponibile"]) + epsilon);
					writer.WriteElementString("Imponibile",imponibile.ToString());
					int moltiplicatore = 10000;
					int aliquota = (int) (CfgFn.GetNoNullDecimal(rCollaboratore["aliquota"]) * moltiplicatore + epsilon);

					string fineMessaggio = "\n\nSegnalare ulteriori errori?"
						+ "\n\nPremere SI per visualizzare altri messaggi di errore;"
						+ "\nPremere NO per generare l'E-Mens senza segnalare gli errori incontrati.";
					string errori;
					CalcolaCodiceFiscale.CheckCF(rCollaboratore["cfcollaboratore"].ToString().ToUpper(), out errori);
					if ((errori!="") && (visualizzaMessaggio))
					{
						string messaggio = "Errore nel codice fiscale del collaboratore "
							+ rCollaboratore["cognome"] + " " + rCollaboratore["nome"]
							+ ":\nCodice fiscale: " + rCollaboratore["cfcollaboratore"]
							+"\nErrore riscontrato: "+errori
							+ fineMessaggio;
						DialogResult dr = MessageBox.Show(this, messaggio, "Codice fiscale Errato", MessageBoxButtons.YesNo);
						visualizzaMessaggio = dr == DialogResult.Yes;
					}
					bool aliquotaValida = controllaAliquota(aliquota);
					if ((!aliquotaValida) && (visualizzaMessaggio))
					{
						string messaggio = "Al collaboratore: " + rCollaboratore["cognome"] + " " + rCollaboratore["nome"] +
							" è stata applicata una aliquota non corretta rispetto a quelle indicate" +
							" dalla tabella Aliquote dell'EMENS \n(consultabile all'indirizzo http://www.inps.it/servizi/emens/Specifiche/Aliquota.htm)." +
							"\nLe aliquote valide sono 10%, 15%, 17,50%, 18%, 18,50%, 19%\n" +
							"\nCFCollaboratore: " + rCollaboratore["cfcollaboratore"] +
							"\nDal: " + rCollaboratore["dal"] + 
							"\nAl: " + rCollaboratore["al"] + 
							"\nAliquota: " + CfgFn.GetNoNullDecimal(rCollaboratore["aliquota"]).ToString("p")
							+ fineMessaggio;
						DialogResult dr = MessageBox.Show(this,messaggio,"Aliquota Errata",MessageBoxButtons.YesNo);
						visualizzaMessaggio = dr == DialogResult.Yes;
					}

					writer.WriteElementString("Aliquota",aliquota.ToString());
					scriviXml(rCollaboratore, new string[] {
						"AltraAss", "Dal", "Al", 
						"CodCalamita", "CodCertificazione"});
					writer.WriteEndElement();//"Collaboratore"
				}
				writer.WriteEndElement();//"ListaCollaboratori"
				writer.WriteEndElement();//"Azienda"
			}
			writer.WriteEndElement();//"DenunceRetributiveMensili"
			writer.Close();

			if (numCollaboratori==0) 
			{
				MessageBox.Show(this, "Nel periodo indicato non ci sono ritenute INPS, pertanto l'E-Mens generato non sarà valido."
					+ "\nAnno: "+DS.emens[0]["anno"]
					+ "\nMese inizio: "+DS.emens[0]["meseinizio"]
					+ "\nMese fine: "+DS.emens[0]["mesefine"]);
			}
			string xmlString = sw.ToString();

			byte[] xml = new UTF8Encoding().GetBytes(xmlString);

			DS.emens[0]["olenotes"] = xml;

			DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
			if (dialogResult==DialogResult.Cancel) return;
			txtNomeFile.Text = saveFileDialog1.FileName;

			StreamWriter stw = new StreamWriter(saveFileDialog1.OpenFile());
			stw.Write(sw.ToString());
			stw.Close();

			btnApriFile.Enabled = true;
			btnSalvaFile.Enabled = true;
		}

		private void btnApriFile_Click(object sender, System.EventArgs e)
		{
			XmlDocument document = new XmlDocument();
			DialogResult dr = openFileDialog1.ShowDialog(this);
			if (dr != DialogResult.OK) return;
			txtNomeFile.Text = openFileDialog1.FileName;
			try
			{
				System.Diagnostics.Process.Start(txtNomeFile.Text);
				document.Load(txtNomeFile.Text);
			}
			catch(Exception ex)
			{
				string messaggio = "Non riesco ad aprire il file: " + txtNomeFile.Text +
					"\nErrore: " + ex.Message;
				MessageBox.Show(this,messaggio);
				return;
			}
			dsEmens.Emens.Clear();
			
			XmlElement DenunceRetributiveMensili = document.DocumentElement;
			XmlElement DatiMittente = DenunceRetributiveMensili["DatiMittente"];
			foreach (XmlElement Azienda in /*Rana:DenunceRetributiveMensili.*/GetElementsByTagName("Azienda")) 
			{
				string filtroEsercizio = "(esercizio = " + Azienda["AnnoMeseDenuncia"].InnerText.Substring(0,4) + ")";
				XmlElement ListaCollaboratori = Azienda["ListaCollaboratori"];
				foreach (XmlElement Collaboratore in ListaCollaboratori.GetElementsByTagName("Collaboratore"))
				{
					dsEmens.Emens.AddEmensRow(
						mese(Azienda["AnnoMeseDenuncia"]),
						valore(Azienda["CFAzienda"],true),
						valore(Collaboratore["CFCollaboratore"],true),
						valore(Collaboratore["Cognome"],false),
						valore(Collaboratore["Nome"],false),
						decodifica(Collaboratore["TipoRapporto"], dsEmens.emenstiporapporto, filtroEsercizio,"codicerapporto", "descrizione"),
						decodifica(Collaboratore["CodiceAttivita"], dsEmens.attivitaprevidenzialeinps, filtroEsercizio,"codiceattivita", "descrizione"),
						valuta(Collaboratore["Imponibile"]),
						percentuale(Collaboratore["Aliquota"],true),
						decodifica(Collaboratore["AltraAss"], dsEmens.altraformaassicurativa, filtroEsercizio,"codiceforma", "descrizione"),
						giorno(Collaboratore["Dal"]),
						giorno(Collaboratore["Al"]),
						valore(Collaboratore["CodCalamita"],false),
						valore(Collaboratore["CodCertificazione"],false));
				}
			}
			new FrmDettaglioRisultati(dsEmens.Emens).ShowDialog(this);
		}

		void salvaFile()
		{
			DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
			if (dialogResult==DialogResult.Cancel) return;
			txtNomeFile.Text = saveFileDialog1.FileName;

			byte[] xml = (byte[]) DS.emens[0]["olenotes"];

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
			gestisciGrpDatiMittente(true);
		}

		private bool controllaDatiMittente(DataRow Curr)
		{
			string chiusura = "\n\nL'EMENS non verrà generato.\nChiudere la finestra e correggere gli errori";
			if (Curr["flagesisteresponsabile"].Equals("N"))
			{
				string messaggio = "Non esiste il Responsabile alla Trasmissione dell'EMENS!"
					+ "\n\nPer correggere questo errore:"
					+ "\nandare in 'Configurazione - Responsabile Trasmissione - Configurazione',"
					+ "\ninserire un responsabile per la trasmissione del modello E-Mens";
				MessageBox.Show(this, messaggio+chiusura);
				return false;
			}
			if (Curr["cfsender"].ToString() == "")
			{
				string messaggio = "Manca il Codice Fiscale del Mittente!"
					+ "\n\nPer correggere questo errore:"
					+ "\nandare in 'Configurazione - Informazioni Ente' ed inserire il codice fiscale.";
				MessageBox.Show(this, messaggio+chiusura);
				return false;
			}
			int lunghCF = Curr["cfsender"].ToString().Length;
			if (lunghCF != 11)
			{
				string messaggio = "Il Codice Fiscale del Mittente deve essere composto da 11 caratteri e non "+lunghCF+"."
					+ "\nCodice fiscale attualmente inserito: "+Curr["cfsender"]
					+ "\n\nPer correggere questo errore:"
					+ "\nandare in 'Configurazione - Informazioni Ente' e modificare il codice fiscale.";
				MessageBox.Show(this, messaggio+chiusura);
				return false;
			}
			if (Curr["cfhumansender"] == DBNull.Value)
			{
				string messaggio = "Manca il codice fiscale del Responsabile alla Trasmissione dell'EMENS!"
					+ "\n\nPer correggere questo errore:"
					+ "\nandare in 'Tabelle - Creditore/Debitore - Creditore/debitore',"
					+ "\nscegliere il creditore/debitore responsabile della trasmissione dell'E-Mens"
					+ "\n(precedentemente configurato in Configurazione - Responsabile Trasmissione - Configurazione)"
					+ "\ned inserire il codice fiscale.";
				MessageBox.Show(this, messaggio+chiusura);
				return false;
			}
			string errori = "";
			CalcolaCodiceFiscale.CheckCF(Curr["cfhumansender"].ToString().ToUpper(),out errori);
			if (errori != "")
			{
				string messaggio = "Sono stati riscontrati i seguenti errori nel codice fiscale del Responsabile alla Trasmissione dell'EMENS:\n" +
					errori
					+ "\n\nPer correggere:"
					+ "\nandare in 'Tabelle - Creditore/Debitore - Creditore/debitore',"
					+ "\nscegliere il creditore/debitore responsabile della trasmissione EMENS'"
					+ "\n(precedentemente configurato in Configurazione - Responsabile Trasmissione - Configurazione)"
					+ "\ne modificare il codice fiscale.";
				MessageBox.Show(this, messaggio+chiusura, "Errori nel codice fiscale del Responsabile alla Trasmissione dell'EMENS");
				return false;
			}
			return true;
		}

		public void MetaData_BeforeFill() 
		{
			btnGeneraEmens.Enabled = true;
			string errMess;
			if (!meta.FirstFillForThisRow) return;
			if (meta.InsertMode)
			{	
				btnApriFile.Enabled = false;
				DataSet dsMittente = meta.Conn.CallSP("emens_getDatiMittente",new object [] {meta.GetSys("esercizio")},-1,out errMess);
				if (dsMittente == null) return;
				if (dsMittente.Tables.Count == 0) return;
				foreach(DataColumn C in dsMittente.Tables[0].Columns)
				{
					if (C.ColumnName != "flagesisteresponsabile") 
					{
						DS.emens.Rows[0][C.ColumnName] = dsMittente.Tables[0].Rows[0][C];
					}
				}
				bool datiMittenteValidi = controllaDatiMittente(dsMittente.Tables[0].Rows[0]);
				if (!datiMittenteValidi)
				{
					btnGeneraEmens.Enabled = false;
					meta.CanSave = false;
				}
			}
			gestisciGrpDatiMittente(false);
			if (meta.EditMode)
			{
				btnApriFile.Enabled = true;
			}
		}

		public void MetaData_AfterLink()
		{
			meta = MetaData.GetMetaData(this);
			GetData.CacheTable(DS.inpscenter,null,"denominazione",true);
			riempiGridPrestazioneERitenuta();
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.emenstiporapporto, null, null, null, true);
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.attivitaprevidenzialeinps, null, null, null, true);
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.altraformaassicurativa, null, null, null, true);
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
			return nodo.InnerText;
		}

		private string mese(XmlElement nodo) 
		{
			if (nodo==null) return null;
			DateTime dateTime = DateTime.ParseExact(nodo.InnerText, "yyyy-MM", DateTimeFormatInfo.CurrentInfo);
			return dateTime.ToString("MMMM yyyy");
		}

		private string giorno(XmlElement nodo) 
		{
			if (nodo==null) return null;
			DateTime dateTime = DateTime.ParseExact(nodo.InnerText, "yyyy-MM-dd", DateTimeFormatInfo.CurrentInfo);
			return dateTime.ToShortDateString();
		}

		private string decodifica(XmlElement nodo, DataTable tab, string filtroEsercizio, string valueMember, string displayMember) 
		{
			if (nodo==null) return null;
			DataRow[] r = tab.Select(filtroEsercizio+" and ("+valueMember+"='"+nodo.InnerText+"')");
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
			decimal p = Decimal.Parse(nodo.InnerText)/10000;
			return p.ToString("p");
		}

		private string valuta(XmlElement nodo) 
		{
			if (nodo==null) return null;
			decimal p = Decimal.Parse(nodo.InnerText);
			return p.ToString("c");
		}

		private void riempiGridPrestazioneERitenuta()
		{
//			string filtroPrestazione = "((tipoprestazione IN ('OCCASIONALE','COCOCO','ASSEGNIRIC')) " +
//				" OR (codiceprestazione IN ('PRESTOCC','97PRESTOCC','PRESTCOOR','PRESTCOORN','ASSRICERCA')))";
			string filtroPrestazione = "(tipoprestazione IN ('OCCASIONALE','COCOCO'))";
			GetData.CacheTable(DS.service,filtroPrestazione,"codiceprestazione",false);
			azzeraCaption(DS.service);
			DS.service.Columns["idser"].Caption = "Cod. Prestazione";
			DS.service.Columns["description"].Caption = "Descr. Prestazione";
			HelpForm.SetDataGrid(dgPrestazione,DS.service);
			new formatgrids(dgPrestazione).AutosizeColumnWidth();

			string filtroRitenuta = "(tiporitenuta = 'P') AND (codiceritenuta LIKE '%INPS%')";
			GetData.CacheTable(DS.tax,filtroRitenuta,"codiceritenuta",false);
			azzeraCaption(DS.tax);
			DS.tax.Columns["taxcode"].Caption = "Cod. Ritenuta";
			DS.tax.Columns["description"].Caption = "Descr. Ritenuta";
			DS.tax.Columns["taxkind"].Caption = "Tipo Ritenuta";
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
	}
}
