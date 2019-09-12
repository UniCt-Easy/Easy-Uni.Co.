/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.IO;
using System.Data;
using metadatalibrary;
using System.Text;
using System.Globalization;
using funzioni_configurazione;

namespace emens_consolida//consolidaEmens//
{
	/// <summary>
	/// Summary description for FrmConsolidaEmens.
	/// </summary>
	public class Frm_consolidaEmens : System.Windows.Forms.Form
	{
		private MetaData meta;
		private System.Windows.Forms.Button btnDirectory;
		private System.Windows.Forms.TextBox txtDirectory;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button btnLeggi;
		public vistaForm DS;
		private VistaEmens dsEmens;
		private System.Windows.Forms.DataGrid gridFile;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btnFileXml;
		private System.Windows.Forms.TextBox txtFileXml;
		private System.Windows.Forms.Button btnApriXml;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCFPersonaMittente;
		private System.Windows.Forms.TextBox txtRagSocMittente;
		private System.Windows.Forms.TextBox txtCFMittente;
		private System.Windows.Forms.TextBox txtCFSoftwarehouse;
		private System.Windows.Forms.ComboBox cmbSedeInps;
		private System.Windows.Forms.GroupBox groupBox1;
        QueryHelper QHS;
        CQueryHelper QHC;
        private Button btnLeggiUniemens;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_consolidaEmens()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			dsEmens.log.Columns["nomefile"].Caption = "Nome del file";
			dsEmens.log.Columns["esitolettura"].Caption = "Esito della lettura";

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
            this.btnDirectory = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLeggi = new System.Windows.Forms.Button();
            this.DS = new emens_consolida.vistaForm();
            this.dsEmens = new emens_consolida.VistaEmens();
            this.gridFile = new System.Windows.Forms.DataGrid();
            this.btnFileXml = new System.Windows.Forms.Button();
            this.txtFileXml = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnApriXml = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCFPersonaMittente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRagSocMittente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCFMittente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCFSoftwarehouse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSedeInps = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLeggiUniemens = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS.emens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFile)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDirectory
            // 
            this.btnDirectory.Location = new System.Drawing.Point(8, 8);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(72, 23);
            this.btnDirectory.TabIndex = 0;
            this.btnDirectory.Text = "Cartella file";
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(88, 8);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.ReadOnly = true;
            this.txtDirectory.Size = new System.Drawing.Size(520, 20);
            this.txtDirectory.TabIndex = 1;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Indicare la cartella dove sono presenti i file Emens da consolidare:";
            // 
            // btnLeggi
            // 
            this.btnLeggi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeggi.Location = new System.Drawing.Point(237, 328);
            this.btnLeggi.Name = "btnLeggi";
            this.btnLeggi.Size = new System.Drawing.Size(114, 24);
            this.btnLeggi.TabIndex = 2;
            this.btnLeggi.Text = "Consolida Emens";
            this.btnLeggi.Click += new System.EventHandler(this.btnLeggi_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            // 
            // 
            // 
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // dsEmens
            // 
            this.dsEmens.DataSetName = "VistaEmens";
            this.dsEmens.EnforceConstraints = false;
            this.dsEmens.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // gridFile
            // 
            this.gridFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFile.DataMember = "";
            this.gridFile.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFile.Location = new System.Drawing.Point(8, 144);
            this.gridFile.Name = "gridFile";
            this.gridFile.Size = new System.Drawing.Size(600, 176);
            this.gridFile.TabIndex = 3;
            // 
            // btnFileXml
            // 
            this.btnFileXml.Location = new System.Drawing.Point(8, 40);
            this.btnFileXml.Name = "btnFileXml";
            this.btnFileXml.Size = new System.Drawing.Size(72, 23);
            this.btnFileXml.TabIndex = 4;
            this.btnFileXml.Text = "File Xml";
            this.btnFileXml.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFileXml
            // 
            this.txtFileXml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileXml.Location = new System.Drawing.Point(88, 40);
            this.txtFileXml.Name = "txtFileXml";
            this.txtFileXml.ReadOnly = true;
            this.txtFileXml.Size = new System.Drawing.Size(520, 20);
            this.txtFileXml.TabIndex = 5;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Title = "Specificare il nome del file da produrre:";
            // 
            // btnApriXml
            // 
            this.btnApriXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApriXml.Location = new System.Drawing.Point(435, 328);
            this.btnApriXml.Name = "btnApriXml";
            this.btnApriXml.Size = new System.Drawing.Size(80, 24);
            this.btnApriXml.TabIndex = 6;
            this.btnApriXml.Text = "Vedi file xml";
            this.btnApriXml.Click += new System.EventHandler(this.btnApriXml_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(104, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "C.F. Persona";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCFPersonaMittente
            // 
            this.txtCFPersonaMittente.Location = new System.Drawing.Point(168, 16);
            this.txtCFPersonaMittente.Name = "txtCFPersonaMittente";
            this.txtCFPersonaMittente.ReadOnly = true;
            this.txtCFPersonaMittente.Size = new System.Drawing.Size(120, 20);
            this.txtCFPersonaMittente.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(288, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rag.Soc.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRagSocMittente
            // 
            this.txtRagSocMittente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRagSocMittente.Location = new System.Drawing.Point(336, 16);
            this.txtRagSocMittente.Name = "txtRagSocMittente";
            this.txtRagSocMittente.ReadOnly = true;
            this.txtRagSocMittente.Size = new System.Drawing.Size(256, 20);
            this.txtRagSocMittente.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "C.F.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCFMittente
            // 
            this.txtCFMittente.Location = new System.Drawing.Point(32, 16);
            this.txtCFMittente.Name = "txtCFMittente";
            this.txtCFMittente.ReadOnly = true;
            this.txtCFMittente.Size = new System.Drawing.Size(72, 20);
            this.txtCFMittente.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(408, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "C.F. Softwarehouse";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCFSoftwarehouse
            // 
            this.txtCFSoftwarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCFSoftwarehouse.Location = new System.Drawing.Point(520, 72);
            this.txtCFSoftwarehouse.Name = "txtCFSoftwarehouse";
            this.txtCFSoftwarehouse.ReadOnly = true;
            this.txtCFSoftwarehouse.Size = new System.Drawing.Size(88, 20);
            this.txtCFSoftwarehouse.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Sede INPS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSedeInps
            // 
            this.cmbSedeInps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSedeInps.DataSource = this.dsEmens.inpscenter;
            this.cmbSedeInps.DisplayMember = "title";
            this.cmbSedeInps.Location = new System.Drawing.Point(88, 72);
            this.cmbSedeInps.MaxDropDownItems = 50;
            this.cmbSedeInps.Name = "cmbSedeInps";
            this.cmbSedeInps.Size = new System.Drawing.Size(320, 21);
            this.cmbSedeInps.TabIndex = 16;
            this.cmbSedeInps.ValueMember = "idinpscenter";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCFPersonaMittente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCFMittente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRagSocMittente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 40);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mittente";
            // 
            // btnLeggiUniemens
            // 
            this.btnLeggiUniemens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeggiUniemens.Location = new System.Drawing.Point(107, 328);
            this.btnLeggiUniemens.Name = "btnLeggiUniemens";
            this.btnLeggiUniemens.Size = new System.Drawing.Size(124, 24);
            this.btnLeggiUniemens.TabIndex = 18;
            this.btnLeggiUniemens.Text = "Consolida UniE-mens";
            this.btnLeggiUniemens.Click += new System.EventHandler(this.btnLeggiUniemens_Click);
            // 
            // Frm_consolidaEmens
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 358);
            this.Controls.Add(this.btnLeggiUniemens);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCFSoftwarehouse);
            this.Controls.Add(this.gridFile);
            this.Controls.Add(this.cmbSedeInps);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnApriXml);
            this.Controls.Add(this.txtFileXml);
            this.Controls.Add(this.btnFileXml);
            this.Controls.Add(this.btnLeggi);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.btnDirectory);
            this.Name = "Frm_consolidaEmens";
            this.Text = "Consolidamento denunce retributive E-mens";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink()
		{
			meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = meta.Conn.GetQueryHelper();

			meta.CanCancel = false;
			meta.CanInsert = false;
			meta.CanInsertCopy = false;
			meta.CanSave = false;
			meta.SearchEnabled = false;
			meta.MainRefreshEnabled = false;
			string errMess;
			DataSet dsMittente = meta.Conn.CallSP("emens_getDatiMittente", new object[] { meta.GetSys("esercizio") }, -1, out errMess);
			txtCFPersonaMittente.Text = dsMittente.Tables[0].Rows[0]["cfpersonamittente"].ToString().ToUpper();
			txtRagSocMittente.Text = dsMittente.Tables[0].Rows[0]["ragsocmittente"].ToString().ToUpper();
			txtCFMittente.Text = dsMittente.Tables[0].Rows[0]["cfmittente"].ToString().ToUpper();
			txtCFSoftwarehouse.Text = dsMittente.Tables[0].Rows[0]["cfsoftwarehouse"].ToString().ToUpper();

			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.emenscontractkind, null, null, null, true);
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.inpsactivity, null, null, null, true);
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.otherinsurance, null, null, null, true);
		}

		public void MetaData_AfterClear()
		{
			Text = "Consolidamento denunce retributive E-mens";
            DataRow rInps = dsEmens.inpscenter.NewRow();
            foreach (DataColumn c in dsEmens.inpscenter.Columns) {
                rInps[c.ColumnName] = "";
            }
            dsEmens.inpscenter.Rows.Add(rInps);
			DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, dsEmens.inpscenter, "title", null, null, true);
		}

		public void MetaData_AfterFill()
		{
			Text = "Consolidamento denunce retributive E-mens";
		}

		private void chiediCartella() 
		{
			DialogResult dr = folderBrowserDialog1.ShowDialog(this);
			if (dr==DialogResult.Cancel) return;
			txtDirectory.Text = folderBrowserDialog1.SelectedPath;
		}

		private void btnDirectory_Click(object sender, System.EventArgs e)
		{
			chiediCartella();
		}

		private string valore(XmlElement nodo) 
		{
			if (nodo==null) return null;
			return nodo.InnerText;
		}

        private bool CodiceAttivitaObbligatorio(string TipoRapporto){
            // Controlla se per il TipoRapporto corrente è obbligatorio specificare il codice Attività
            string filtro = QHC.AppAnd(
                        QHC.CmpEq("idemenscontractkind", TipoRapporto),
                        QHC.CmpEq("flagactivityrequested", "S"));
            if (dsEmens.emenscontractkind.Select(filtro).Length == 0) return false;

            return true;
        }

		private void writeElementString(XmlTextWriter writer, string campo, DataRow riga) 
		{
			if (riga[campo] != DBNull.Value)
			{
				writer.WriteElementString(campo, riga[campo].ToString());
			}
		}

		/// <summary>
		/// Riempie il dataset dsEmens leggendo i dati dai file 
		/// </summary>
        private void leggiFiles()
        {
 
            DirectoryInfo di = new DirectoryInfo(txtDirectory.Text);

            foreach (FileInfo fi in di.GetFiles())
            {
                XmlDocument document = new XmlDocument();
                try
                {
                    document.Load(fi.FullName);
                }
                catch (XmlException e)
                {
                    DataRow rLog = dsEmens.log.NewRow();
                    rLog["nomefile"] = fi.Name;
                    rLog["esitolettura"] = e.Message;
                    dsEmens.log.Rows.Add(rLog);
                    continue;
                }
                XmlElement DenunceRetributiveMensili = document.DocumentElement;
                XmlElement DatiMittente = DenunceRetributiveMensili["DatiMittente"];
                foreach (XmlElement Azienda in DenunceRetributiveMensili.GetElementsByTagName("Azienda"))
                {
                    XmlElement ListaCollaboratori = Azienda["ListaCollaboratori"];
                    if (ListaCollaboratori == null)
                    {
                        DataRow rLog2 = dsEmens.log.NewRow();
                        rLog2["nomefile"] = fi.Name;
                        rLog2["AnnoMeseDenuncia"] = valore(Azienda["AnnoMeseDenuncia"]);
                        rLog2["CFAzienda"] = valore(Azienda["CFAzienda"]);
                        rLog2["esitolettura"] = "Manca la ListaCollaboratori";
                        dsEmens.log.Rows.Add(rLog2);
                        continue;
                    }

                    string filtroAzienda = QHC.AppAnd(
                        QHC.CmpEq("AnnoMeseDenuncia", Azienda["AnnoMeseDenuncia"].FirstChild.Value),
                        QHC.CmpEq("CFAzienda", Azienda["CFAzienda"].FirstChild.Value));
                    DataRow[] rAz = dsEmens.Azienda.Select(filtroAzienda);
                    if (rAz.Length == 0)
                    {
                        DataRow rAzienda = dsEmens.Azienda.NewRow();
                        rAzienda["AnnoMeseDenuncia"] = valore(Azienda["AnnoMeseDenuncia"]);
                        rAzienda["CFAzienda"] = valore(Azienda["CFAzienda"]);
                        rAzienda["RagSocAzienda"] = valore(Azienda["RagSocAzienda"]);
                        rAzienda["CAP"] = valore(ListaCollaboratori["CAP"]);
                        rAzienda["ISTAT"] = valore(ListaCollaboratori["ISTAT"]);
                        dsEmens.Azienda.Rows.Add(rAzienda);
                    }

                    foreach (XmlElement Collaboratore in ListaCollaboratori.GetElementsByTagName("Collaboratore"))
                    {
                        string filtroCollaboratore = QHC.AppAnd(
                            QHC.CmpEq("CFCollaboratore", Collaboratore["CFCollaboratore"].FirstChild.Value),
                            QHC.CmpEq("TipoRapporto", Collaboratore["TipoRapporto"].FirstChild.Value),
                            QHC.CmpEq("Aliquota", Collaboratore["Aliquota"].FirstChild.Value),
                            QHC.CmpEq("AnnoMeseDenuncia", Azienda["AnnoMeseDenuncia"].FirstChild.Value),
                            QHC.CmpEq("CFAzienda", Azienda["CFAzienda"].FirstChild.Value)
                            //Nella documentazione, si legge che :
                            //<Collaboratore>
                            //Dati della collaborazione il cui compenso è stato corrisposto nel mese oggetto 
                            //della denuncia. Può essere presente più volte, identificato in modo univoco dagli elementi 
                            //<CFCollaboratore>, <TipoRapporto> e <Aliquota>. 

                            //QHC.CmpEq("CodiceAttivita",valore(Collaboratore["CodiceAttivita"])),
                            //QHC.CmpEq("AltraAss",valore(Collaboratore["AltraAss"]))
                            );

                        //DataRow[] coll = dsEmens.Collaboratore.Select(filtroCollaboratore);
                        //if (coll.Length == 0)
                        //{
                            DataRow rColl = dsEmens.Collaboratore.NewRow();
                            rColl["CFCollaboratore"] = valore(Collaboratore["CFCollaboratore"]);
                            rColl["Cognome"] = valore(Collaboratore["Cognome"]);
                            rColl["Nome"] = valore(Collaboratore["Nome"]);
                            rColl["CodiceComune"] = valore(Collaboratore["CodiceComune"]);
                            rColl["TipoRapporto"] = valore(Collaboratore["TipoRapporto"]);
                            rColl["CodiceAttivita"] = valore(Collaboratore["CodiceAttivita"]);
                            rColl["Imponibile"] = valore(Collaboratore["Imponibile"]);
                            rColl["Aliquota"] = valore(Collaboratore["Aliquota"]);
                            rColl["AltraAss"] = valore(Collaboratore["AltraAss"]);
                            rColl["Dal"] = valore(Collaboratore["Dal"]);
                            rColl["Al"] = valore(Collaboratore["Al"]);
                            rColl["CodCalamita"] = valore(Collaboratore["CodCalamita"]);
                            rColl["CodCertificazione"] = valore(Collaboratore["CodCertificazione"]);
                            rColl["AnnoMeseDenuncia"] = valore(Azienda["AnnoMeseDenuncia"]);
                            rColl["CFAzienda"] = valore(Azienda["CFAzienda"]);

                            dsEmens.Collaboratore.Rows.Add(rColl);
                        //}

                        DataRow rLog3 = dsEmens.log.NewRow();
                        rLog3["nomefile"] = fi.Name;
                        rLog3["AnnoMeseDenuncia"] = valore(Azienda["AnnoMeseDenuncia"]);
                        rLog3["CFAzienda"] = valore(Azienda["CFAzienda"]);
                        rLog3["esitolettura"] = "OK";

                        dsEmens.log.Rows.Add(rLog3);
                    }
                }
            }
        }

		private DirectoryInfo getDirectoryInfo(out string messaggio) 
		{
			messaggio = null;
			try 
			{
				return new DirectoryInfo(txtDirectory.Text);
			} 
			catch (ArgumentException e) 
			{
				messaggio = e.Message;
				return null;
			}

		}

		private XmlTextWriter getXmlTextWriter(out string messaggio) 
		{
			messaggio = null;
			try 
			{
				return new XmlTextWriter(txtFileXml.Text, Encoding.UTF8);
			} 
			catch (ArgumentException e) 
			{
				messaggio = e.Message;
				return null;
			}
		}

        private void Leggi(string emensKind)
        {
            if ((cmbSedeInps.SelectedValue == null) || (cmbSedeInps.SelectedValue.ToString() == ""))
            {
                MessageBox.Show(this, "Scegliere la Sede INPS");
                return;
            }

            string messaggio;
            DirectoryInfo di = getDirectoryInfo(out messaggio);
            if (di == null)
            {
                chiediCartella();
                di = getDirectoryInfo(out messaggio);
                if (di == null)
                {
                    MessageBox.Show(this, "Errore: " + messaggio
                        + "\n\nE' necessario indicare la cartella dalla quale prelevare i file Emens dei vari dipartimenti!");
                    return;
                }
            }
            XmlTextWriter writer = getXmlTextWriter(out messaggio);
            if (writer == null)
            {
                chiediFileDoveScrivere();
                writer = getXmlTextWriter(out messaggio);
                if (writer == null)
                {
                    MessageBox.Show(this, "Errore: " + messaggio
                        + "\n\nE' necessario indicare il nome del file dove andare a scrivere l'Emens consolidato!");
                    return;
                }
            }

            writer.Formatting = Formatting.Indented;

            dsEmens.Collaboratore.Clear();
            dsEmens.Azienda.Clear();
            dsEmens.log.Clear();

            leggiFiles();

            HelpForm.SetDataGrid(gridFile, dsEmens.log);
            new formatgrids(gridFile).AutosizeColumnWidth();

            if (emensKind == "E")
            {
                writer.WriteStartElement("DenunceRetributiveMensili");
                writer.WriteStartElement("DatiMittente");
            }
            else
            {
                writer.WriteStartElement("DenunceMensili");
                writer.WriteStartElement("DatiMittente");
                writer.WriteAttributeString("Tipo", "1");
            }

            writer.WriteElementString("CFPersonaMittente", txtCFPersonaMittente.Text);
            writer.WriteElementString("RagSocMittente", txtRagSocMittente.Text);
            writer.WriteElementString("CFMittente", txtCFMittente.Text);
            writer.WriteElementString("CFSoftwarehouse", txtCFSoftwarehouse.Text);
            writer.WriteElementString("SedeINPS", cmbSedeInps.SelectedValue.ToString());
            writer.WriteEndElement();//"DatiMittente"

            foreach (DataRow rigaAzienda in dsEmens.Azienda.Select(null, "CFAzienda,AnnoMeseDenuncia"))
            {
                writer.WriteStartElement("Azienda");
                writeElementString(writer, "AnnoMeseDenuncia", rigaAzienda);
                writeElementString(writer, "CFAzienda", rigaAzienda);
                writeElementString(writer, "RagSocAzienda", rigaAzienda);

                writer.WriteStartElement("ListaCollaboratori");
                writeElementString(writer, "CAP", rigaAzienda);
                writeElementString(writer, "ISTAT", rigaAzienda);

                foreach (DataRow rigaCollaboratore in rigaAzienda.GetChildRows("AziendaCollaboratore"))
                {
                    writer.WriteStartElement("Collaboratore");
                    writeElementString(writer, "CFCollaboratore", rigaCollaboratore);
                    writeElementString(writer, "Cognome", rigaCollaboratore);
                    writeElementString(writer, "Nome", rigaCollaboratore);
                    writeElementString(writer, "CodiceComune", rigaCollaboratore);
                    writeElementString(writer, "TipoRapporto", rigaCollaboratore);
                    writeElementString(writer, "CodiceAttivita", rigaCollaboratore);
                    writeElementString(writer, "Imponibile", rigaCollaboratore);
                    writeElementString(writer, "Aliquota", rigaCollaboratore);
                    writeElementString(writer, "AltraAss", rigaCollaboratore);
                    writeElementString(writer, "Dal", rigaCollaboratore);
                    writeElementString(writer, "Al", rigaCollaboratore);
                    writeElementString(writer, "CodCalamita", rigaCollaboratore);
                    writeElementString(writer, "CodCertificazione", rigaCollaboratore);
                    writer.WriteEndElement();//"Collaboratore"
                }
                writer.WriteEndElement();//"ListaCollaboratori"
                writer.WriteEndElement();//"Azienda"
            }
            writer.WriteEndElement();//"DenunceRetributiveMensili"
            writer.Close();
            visualizzaXml();

        }

		private void btnLeggi_Click(object sender, System.EventArgs e)
		{
            Leggi("E");
		}

		private void chiediFileDoveScrivere() 
		{
			DialogResult dr = saveFileDialog1.ShowDialog(this);
			if (dr==DialogResult.Cancel) return;
			txtFileXml.Text = saveFileDialog1.FileName;
		}

		private void btnFile_Click(object sender, System.EventArgs e)
		{
			chiediFileDoveScrivere();
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

		private string percentuale(XmlElement nodo) 
		{
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

		private void visualizzaXml()
		{
			XmlDocument document = new XmlDocument();
			try 
			{
				System.Diagnostics.Process.Start(txtFileXml.Text);
				document.Load(txtFileXml.Text);
			} 
			catch (Exception ex) 
			{
				MessageBox.Show(this, "Impossibile aprire il file Xml specificato.\n"+ex.Message);
				return;
			}
			dsEmens.Emens.Clear();

			XmlElement DenunceRetributiveMensili = document.DocumentElement;
			XmlElement DatiMittente = DenunceRetributiveMensili["DatiMittente"];
			foreach (XmlElement Azienda in DenunceRetributiveMensili.GetElementsByTagName("Azienda")) 
			{
				string filtroEsercizio = "(ayear="+Azienda["AnnoMeseDenuncia"].InnerText.Substring(0,4)+")";
				XmlElement ListaCollaboratori = Azienda["ListaCollaboratori"];
				foreach (XmlElement Collaboratore in ListaCollaboratori.GetElementsByTagName("Collaboratore"))
				{
                    DataRow rEmens = dsEmens.Emens.NewRow();
                    rEmens["CFAzienda"] = valore(Azienda["CFAzienda"]);
                    rEmens["AnnoMeseDenuncia"] = mese(Azienda["AnnoMeseDenuncia"]);
                    rEmens["CFCollaboratore"] = valore(Collaboratore["CFCollaboratore"]);
                    rEmens["Cognome"] = valore(Collaboratore["Cognome"]);
                    rEmens["Nome"] = valore(Collaboratore["Nome"]);
                    rEmens["CodiceComune"] = valore(Collaboratore["CodiceComune"]);
                    rEmens["TipoRapporto"] = decodifica(Collaboratore["TipoRapporto"], dsEmens.emenscontractkind, filtroEsercizio,
                            "idemenscontractkind", "description");
                    rEmens["CodiceAttivita"] = decodifica(Collaboratore["CodiceAttivita"], dsEmens.inpsactivity, filtroEsercizio,
                            "activitycode", "description");
                    rEmens["Imponibile"] = valuta(Collaboratore["Imponibile"]);
                    rEmens["Aliquota"] = percentuale(Collaboratore["Aliquota"]);
                    rEmens["AltraAss"] = decodifica(Collaboratore["AltraAss"], dsEmens.otherinsurance, filtroEsercizio,
							"idotherinsurance", "description");
                    rEmens["Dal"] = giorno(Collaboratore["Dal"]);
                    rEmens["Al"] = giorno(Collaboratore["Al"]);
                    rEmens["CodCalamita"] = valore(Collaboratore["CodCalamita"]);
                    rEmens["CodCertificazione"] = valore(Collaboratore["CodCertificazione"]);

                    dsEmens.Emens.Rows.Add(rEmens);
				}
			}
			new FrmDettaglioRisultati(dsEmens.Emens).ShowDialog(this);
		}

		private void btnApriXml_Click(object sender, System.EventArgs e)
		{
			visualizzaXml();
		}

        private void btnLeggiUniemens_Click(object sender, EventArgs e)
        {
            Leggi("U");
        }
			
	}
}
