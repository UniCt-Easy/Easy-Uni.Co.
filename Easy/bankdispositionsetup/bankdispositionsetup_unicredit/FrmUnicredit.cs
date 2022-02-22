
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
using System.IO;
using System.Globalization;
using System.Text;
using metadatalibrary;
using funzioni_configurazione;
using System.Data;
using bankdispositionsetup_import;

namespace bankdispositionsetup_unicredit {
	/// <summary>
	/// Summary description for FrmUnicredit.
	/// </summary>
	public class FrmUnicredit : MetaDataForm {
		ImportazioneEsitiBancariUnicredit import;
		char[] buffer = new char[503];//globale per ottimizzazione lettura dal file
		MetaData Meta, metaMB, metaPP;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtInizioElaborazione;
		private System.Windows.Forms.TextBox txtFineElaborazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUltimaEsitazioneDB;
		private System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnApriEF07;
		private System.Windows.Forms.Button btnApriEF06;
		private System.Windows.Forms.Label labelOperazione;
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.Button btnEsita;
		private System.Windows.Forms.DataGrid dataGrid1;
		public bankdispositionsetup_unicredit.vistaForm DS;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmUnicredit() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtInizioElaborazione = new System.Windows.Forms.TextBox();
			this.txtFineElaborazione = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUltimaEsitazioneDB = new System.Windows.Forms.TextBox();
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnApriEF07 = new System.Windows.Forms.Button();
			this.btnApriEF06 = new System.Windows.Forms.Button();
			this.labelOperazione = new System.Windows.Forms.Label();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.btnEsita = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.DS = new bankdispositionsetup_unicredit.vistaForm();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtInizioElaborazione);
			this.groupBox2.Controls.Add(this.txtFineElaborazione);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(140, 9);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(224, 40);
			this.groupBox2.TabIndex = 27;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Elaborazione";
			// 
			// txtInizioElaborazione
			// 
			this.txtInizioElaborazione.Location = new System.Drawing.Point(40, 16);
			this.txtInizioElaborazione.Name = "txtInizioElaborazione";
			this.txtInizioElaborazione.ReadOnly = true;
			this.txtInizioElaborazione.Size = new System.Drawing.Size(72, 20);
			this.txtInizioElaborazione.TabIndex = 5;
			this.txtInizioElaborazione.Text = "";
			// 
			// txtFineElaborazione
			// 
			this.txtFineElaborazione.Location = new System.Drawing.Point(144, 16);
			this.txtFineElaborazione.Name = "txtFineElaborazione";
			this.txtFineElaborazione.ReadOnly = true;
			this.txtFineElaborazione.Size = new System.Drawing.Size(72, 20);
			this.txtFineElaborazione.TabIndex = 7;
			this.txtFineElaborazione.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Inizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(112, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Fine:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtUltimaEsitazioneDB
			// 
			this.txtUltimaEsitazioneDB.Location = new System.Drawing.Point(12, 25);
			this.txtUltimaEsitazioneDB.Name = "txtUltimaEsitazioneDB";
			this.txtUltimaEsitazioneDB.ReadOnly = true;
			this.txtUltimaEsitazioneDB.Size = new System.Drawing.Size(120, 20);
			this.txtUltimaEsitazioneDB.TabIndex = 29;
			this.txtUltimaEsitazioneDB.Text = "";
			// 
			// txtTipo
			// 
			this.txtTipo.Location = new System.Drawing.Point(12, 57);
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.ReadOnly = true;
			this.txtTipo.Size = new System.Drawing.Size(32, 20);
			this.txtTipo.TabIndex = 26;
			this.txtTipo.Text = "";
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFile.Location = new System.Drawing.Point(44, 57);
			this.txtFile.Name = "txtFile";
			this.txtFile.ReadOnly = true;
			this.txtFile.Size = new System.Drawing.Size(584, 20);
			this.txtFile.TabIndex = 19;
			this.txtFile.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 20);
			this.label3.TabIndex = 28;
			this.label3.Text = "Ultima esitazione sul DB";
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(148, 417);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(480, 23);
			this.progressBar1.TabIndex = 23;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnApriEF07);
			this.groupBox1.Controls.Add(this.btnApriEF06);
			this.groupBox1.Location = new System.Drawing.Point(372, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 48);
			this.groupBox1.TabIndex = 25;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Apri File";
			// 
			// btnApriEF07
			// 
			this.btnApriEF07.Location = new System.Drawing.Point(64, 16);
			this.btnApriEF07.Name = "btnApriEF07";
			this.btnApriEF07.Size = new System.Drawing.Size(48, 23);
			this.btnApriEF07.TabIndex = 1;
			this.btnApriEF07.Text = "EF07";
			this.btnApriEF07.Click += new System.EventHandler(this.btnApriEF07_Click);
			// 
			// btnApriEF06
			// 
			this.btnApriEF06.Location = new System.Drawing.Point(8, 16);
			this.btnApriEF06.Name = "btnApriEF06";
			this.btnApriEF06.Size = new System.Drawing.Size(48, 23);
			this.btnApriEF06.TabIndex = 0;
			this.btnApriEF06.Text = "EF06";
			this.btnApriEF06.Click += new System.EventHandler(this.btnApriEF06_Click);
			// 
			// labelOperazione
			// 
			this.labelOperazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelOperazione.Location = new System.Drawing.Point(4, 417);
			this.labelOperazione.Name = "labelOperazione";
			this.labelOperazione.Size = new System.Drawing.Size(144, 29);
			this.labelOperazione.TabIndex = 24;
			this.labelOperazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnChiudi
			// 
			this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChiudi.Location = new System.Drawing.Point(572, 17);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.Size = new System.Drawing.Size(56, 23);
			this.btnChiudi.TabIndex = 22;
			this.btnChiudi.Text = "Esci";
			this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
			// 
			// btnEsita
			// 
			this.btnEsita.Enabled = false;
			this.btnEsita.Location = new System.Drawing.Point(500, 17);
			this.btnEsita.Name = "btnEsita";
			this.btnEsita.Size = new System.Drawing.Size(64, 23);
			this.btnEsita.TabIndex = 21;
			this.btnEsita.Text = "Esita";
			this.btnEsita.Click += new System.EventHandler(this.btnEsita_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(12, 81);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(616, 336);
			this.dataGrid1.TabIndex = 20;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// FrmUnicredit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 446);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.txtUltimaEsitazioneDB);
			this.Controls.Add(this.txtTipo);
			this.Controls.Add(this.txtFile);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.labelOperazione);
			this.Controls.Add(this.btnChiudi);
			this.Controls.Add(this.btnEsita);
			this.Controls.Add(this.dataGrid1);
			this.Name = "FrmUnicredit";
			this.Text = "FrmUnicredit";
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			metaMB = MetaData.GetMetaData(this, "banktransaction");
			metaPP = MetaData.GetMetaData(this, "bill");
			PostData.MarkAsTemporaryTable(DS.EF06_TestaCoda, false); 
			PostData.MarkAsTemporaryTable(DS.EF06, false);
            DataAccess.SetTableForReading(DS.bankdispositionsetup, "config");
			Meta.MainRefreshEnabled=false;
			Meta.SearchEnabled=false;
			Meta.CanSave=false;
			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.CanCancel=false;
            // Per la modifca del parametro chiusuraAutomaticaPartitePendenti vedi task 3070 
			import = new ImportazioneEsitiBancariUnicredit(this, true, labelOperazione, progressBar1, Meta.Conn);
			Text = "Importazione esiti dei movimenti UniCredit";
            object ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + Meta.GetSys("esercizio") + "')"
                , "max(transactiondate)");
            if (ultimaEsitazioneDB == DBNull.Value) {
                ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + 
                    (CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1) + "' )", "max(transactiondate)");
            }
			if (ultimaEsitazioneDB is DateTime) {
				txtUltimaEsitazioneDB.Text = ((DateTime)ultimaEsitazioneDB).ToShortDateString();
			}
		}

		public void MetaData_AfterFill() {
			Text = "Importazione esiti dei movimenti UniCredit";
		}

		public void MetaData_AfterClear() {
			Text = "Importazione esiti dei movimenti UniCredit";
		}

		#region lettura ef07

		bool leggiEF07RecordDiTesta(TextReader tr, DataRow r) {
			r["ISTTS"] = import.leggiNumerico(tr, 5);//  	Codice istituto
			r["CODEN"] = import.leggiNumerico(tr, 7);//  	Codice ente  
			r["ESERC"] = import.leggiNumerico(tr, 4);//  	Anno esercizio   
			string tiprec = import.leggiAlfanumerico(tr, 2);//  	Tipo record  
			r["DESC"] = import.leggiAlfanumerico(tr, 50);//  	Descrizione ente 
			r["NDG"] = import.leggiLong(tr, 11);//  	Codice anagrafico ente
			r["DTELAB"] = import.leggiDataGMA(tr, 8);//	Data elaborazione (nel formato GGMMAAAA)
			r["FILLER"] = import.leggiAlfanumerico(tr, 413);//  	Campo a disposizione 
			if (tiprec != "01") {
				QueryCreator.ShowError(this, "Mi aspettavo il record 01 invece ho ricevuto il record "+tiprec,"");
				return false;
			}
			return import.vaiACapo(tr);
		}

		bool leggiEF07RecordDiDettaglio(TextReader tr, DataRow r) {
			//			dettaglio.ISTTS = import.leggiNumerico(tr, 5);//  	Codice istituto
			//			dettaglio.CODEN = import.leggiNumerico(tr, 7);//  	Codice ente  
			//			dettaglio.ESERC = import.leggiNumerico(tr, 4);//  	Anno esercizio   
			//			dettaglio.TIPREC = import.leggiAlfanumerico(tr, 2);//  	Tipo record  
			r["TIPDOC"] = import.leggiAlfanumerico(tr, 1);//  	Tipo documento (M = mandato R = reversale I = part pend. incasso P = part. Pend. pagamento)      
            r["NUMDOC"] = import.leggiNumerico(tr, 7); //import.leggiAlfanumerico(tr, 7);//  	Numero documento  
            r["PRODOC"] = import.leggiNumerico(tr, 7); //import.leggiAlfanumerico(tr, 7);//  	Progressivo documento 
			r["CAPBIL"] = import.leggiNumerico(tr, 7);//  	Capitolo bilancio  
			r["ARTBIL"] = import.leggiNumerico(tr, 4);//  	Articolo bilancio  
			r["CDMEC"] = import.leggiNumerico(tr, 9);//  	Codice meccanografico   
			r["ANNOCO"] = import.leggiNumerico(tr, 4);//  	Anno competenza  
			string segno;
			r["IMPDOC"] = import.leggiDecimaleConSegno(tr, 16, out segno);//  	Importo documento al lordo delle ritenute (gli ultimi due bytes sono da considerarsi decimali)  
			r["SEGNO"] = segno;//  	Segno operazione (+ per operazioni standard, - per storni)
			r["DTPAG"] = import.leggiDataGMA(tr, 8);//  	Data pagamento /incasso (nel formato GGMMAAAA)  
			r["DVAL"] = import.leggiDataGMA(tr, 8);//  	Data valuta pagamento /incasso (nel formato GGMMAAAA)  
			r["NUMQUI"] = import.leggiNumerico(tr, 7);//  	Numero progr. quietanza 
			r["NUMDIS"] = import.leggiNumerico(tr, 7);//	Numero distinta
			r["IMPRIT"] = import.leggiDecimale(tr, 15);//  	Importo ritenute (gli ultimi due bytes sono da considerarsi decimali)   
			r["INDREG"] = import.leggiAlfanumerico(tr, 1);//  	Indicativo regolazione (se contiene il valore “R” trattasi di regolazione)  
			r["DVALBE"] = import.leggiDataGMA(tr, 8);//  	Data valuta beneficiario (nel formato GGMMAAAA)  
			r["NUMPRA"] = import.leggiAlfanumerico(tr, 16);//  	Numero pratica  
			r["CODVER"] = import.leggiAlfanumerico(tr, 5);//	Codice versamento
			r["NUMPRR"] = import.leggiAlfanumerico(tr, 7);//  	Numero proposta di reversale 
			r["PROGPR"] = import.leggiAlfanumerico(tr, 4);//  	Progressivo proposta di reversale  
			r["IBOLLI"] = import.leggiDecimale(tr, 9);//  	Importo bolli (gli ultimi due bytes sono da considerarsi decimali)  
			r["INDBOL"] = import.leggiAlfanumerico(tr, 1);//  	Indicatore bolli (valorizzato solo per campi non esenti (C = cliente E  = ente I = istituto) 
			r["ICOMM"] = import.leggiDecimale(tr, 9);//  	Importo commissioni (gli ultimi due bytes sono da considerarsi decimali)  
			r["INDCOM"] = import.leggiAlfanumerico(tr, 1);//  	Indicatore commissioni ( C = cliente E = ente)  
			r["ISPE"] = import.leggiDecimale(tr, 9);//  	Importo spese (gli ultimi due bytes sono da considerarsi decimali)
			r["INDSPE"] = import.leggiAlfanumerico(tr, 1);//  	Indicatore spese ( C = cliente E = ente I = istituto)  
			r["TPAGTS"] = import.leggiNumerico(tr, 2);//  	Tipo pagamento   
			r["CODABI"] = import.leggiNumerico(tr, 5);//  	Codice ABI  
			r["CODCAB"] = import.leggiNumerico(tr, 5);//  	Codice CAB  
			r["CONTO"] = import.leggiAlfanumerico(tr, 12);//  	Numero del conto corrente    
			r["CIN"] = import.leggiAlfanumerico(tr, 1);//  	CIN conto corrente   
			r["IBAN_PAE"] = import.leggiAlfanumerico(tr, 2);//	Codice IBAN paese
			r["IBAN_CHK"] = import.leggiNumerico(tr, 2);//	Codice IBAN check digit
			r["IBAN_COO"] = import.leggiAlfanumerico(tr, 30);//	Codice IBAN coordinate
            r["NCNT"] = import.leggiAlfanumerico(tr, 7);//	Numero conto tesoreria
			r["CTIPIPU"] = import.leggiNumerico(tr, 3);//	Tipo imputazione
			r["DESVER"] = import.leggiAlfanumerico(tr, 60);//	Descrizione codice versamento
			r["CCGU"] = import.leggiAlfanumerico(tr, 10);//	Codice Gestionale (CGE/CGU) 
			r["CCPV"] = import.leggiAlfanumerico(tr, 14);//	Common procurement vocabulary (CPV)
			r["CCUP"] = import.leggiAlfanumerico(tr, 15);//	Codice unico di progetto (CUP)
			r["FILLER"] = import.leggiAlfanumerico(tr, 143);//  	Campo a disposizione
			//			Console.WriteLine(r["TIPDOC"]+"\t"+r["NUMDOC"]+"\t"+r["PRODOC"]+"\t"+r["IMPDOC"]+"\t"+r["NUMQUI"]+"\t'"+r["INDREG"]+"'");
			return import.vaiACapo(tr);
		}

		bool leggiEF07RecordBeneficiario(TextReader tr, DataRow r) {
			int ISTTS = import.leggiNumerico(tr, 5);//	Codice istituto
			int CODEN = import.leggiNumerico(tr, 7);//	Codice ente
			int ESERC = import.leggiNumerico(tr, 4);//	Anno esercizio
			string TIPREC = import.leggiAlfanumerico(tr, 2);//	Tipo record	
			r["TIPDOC"] = import.leggiAlfanumerico(tr, 1);//	Tipo documento
			r["NUMDOC"] = import.leggiAlfanumerico(tr, 7);//	Numero documento
			r["PRODOC"] = import.leggiAlfanumerico(tr, 7);//	Progressivo documento
			r["ANABE"] = import.leggiAlfanumerico(tr, 300);//	Anagrafica beneficiario
			r["INDIR"] = import.leggiAlfanumerico(tr, 30);//	Indirizzo beneficiario
			r["CAP"] = import.leggiAlfanumerico(tr, 5);//	CAP beneficiario
			r["LOC"] = import.leggiAlfanumerico(tr, 30);//	Località beneficiario
			r["CFISC"] = import.leggiAlfanumerico(tr, 16);//	Codice fiscale beneficiario
			r["FILLER"] = import.leggiAlfanumerico(tr, 86);//	Campo a disposizione
			if (TIPREC != "03") {
				QueryCreator.ShowError(this, "Mi aspettavo il record 03 invece ho ricevuto il record "+TIPREC, "");
				return false;
			}
			if (!ISTTS.Equals(r["ISTTS"]) || !CODEN.Equals(r["CODEN"]) || !ESERC.Equals(r["ESERC"])) {
				QueryCreator.ShowError(this, "Errore nell'intestazione del record 03", "");
				return false;
			}
			return import.vaiACapo(tr);
		}

		bool leggiEF07RecordCausale(TextReader tr, DataRow r) {
			int ISTTS = import.leggiNumerico(tr, 5);//	Codice istituto
			int CODEN = import.leggiNumerico(tr, 7);//	Codice ente
			int ESERC = import.leggiNumerico(tr, 4);//	Anno esercizio
			string tiprec = import.leggiAlfanumerico(tr, 2);//	Tipo record
			r["TIPDOC"] = import.leggiAlfanumerico(tr, 1);//	Tipo documento
			r["NUMDOC"] = import.leggiAlfanumerico(tr, 7);//	Numero documento
			r["PRODOC"] = import.leggiAlfanumerico(tr, 7);//	Progressivo documento
			r["CAUSALE"] = import.leggiAlfanumerico(tr, 400);//	Causale descrittiva
			r["FILLER"] = import.leggiAlfanumerico(tr, 67);//	Campo a disposizione
			if (tiprec != "04") {
				QueryCreator.ShowError(this, "Mi aspettavo il record 04 invece ho ricevuto il record "+tiprec, "");
				return false;
			}
			if (!ISTTS.Equals(r["ISTTS"]) || !CODEN.Equals(r["CODEN"]) || !ESERC.Equals(r["ESERC"])) {
				QueryCreator.ShowError(this, "Errore nell'intestazione del record 04", "");
				return false;
			}
			return import.vaiACapo(tr);
		}

		bool leggiEF07FileDiCoda(TextReader tr, DataRow r) {
			//			coda.ISTTS = import.leggiNumerico(tr, 5);//  	Codice istituto
			//			coda.CODEN = import.leggiNumerico(tr, 7);//  	Codice ente  
			//			coda.ESERC = import.leggiNumerico(tr, 4);//  	Anno esercizio   
			//			coda.TIPREC = import.leggiAlfanumerico(tr, 2);//  	Tipo record  
			r["FILTS"] = import.leggiNumerico (tr, 5);//  	Codice dipendenza  
			r["SEG_FDO"] = import.leggiAlfanumerico(tr, 1);//  	Segno del fondo di cassa
			r["FDO"] = import.leggiDecimale(tr, 15);//  	Importo del fondo di cassa (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["REV_INC"] = import.leggiDecimale(tr, 15);//  	Importo delle reversali incassate (gli ultimi 2 bytes sono da considerarsi decimali)
			r["REV_CAR"] = import.leggiDecimale(tr, 15);//  	Importo delle reversali caricate e non incassate (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_PPI"] = import.leggiDecimale(tr, 15);//  	Importo delle partite pendenti di incasso (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["MAN_PAG"] = import.leggiDecimale(tr, 15);//  	Importo dei mandati pagati (gli ultimi 2 bytes sono da considerarsi decimali)
			r["MAN_CAR"] = import.leggiDecimale(tr, 15);//  	Importo dei mandati caricati  e non pagati (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_PPP"] = import.leggiDecimale(tr, 15);//  	Importo delle partite pendenti di pagamento (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["SAL_DIR"] = import.leggiDecimale(tr, 15);//  	Importo saldo di diritto (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["SAL_FAT"] = import.leggiDecimale(tr, 15);//  	Importo saldo di fatto (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["FIDO"] = import.leggiDecimale(tr, 15);//  	Importo del fido accordato (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_LIB"] = import.leggiDecimale(tr, 15);//  	Importo totale delle somme libere (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_NTU"] = import.leggiDecimale(tr, 15);//  	Importo totale delle somme vincolate non TU (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_TU"] = import.leggiDecimale(tr, 15);//  	Importo totale delle somme vincolate TU (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_ANT"] = import.leggiDecimale(tr, 15);//  	Importo totale delle somme del conto anticipi (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["FILLER"] = import.leggiAlfanumerico(tr, 266);//  	Campo a disposizione 
			//			Console.WriteLine(r["FILTS"]+" "+r["SEG_FDO"]+" "+r["FDO"]+" "+r["REV_INC"]+" "+r["REV_CAR"]+" "+r["IMP_PPI"] 
			//				+" "+r["MAN_PAG"]+" "+r["MAN_CAR"]+" "+r["IMP_PPP"]+" "+r["SAL_DIR"]+" "+r["SAL_FAT"]+" "+r["FIDO"] 
			//				+" "+r["IMP_LIB"]+" "+r["IMP_NTU"]+" "+r["IMP_TU"]+" "+r["IMP_ANT"]);
			return import.vaiACapo(tr);
		}

		#endregion


		private string leggiIntestazioneRecord(TextReader tr, DataRow r) {
			int ISTTS = import.leggiNumerico(tr, 5);//  	Codice istituto
			int CODEN = import.leggiNumerico(tr, 7);//  	Codice ente  
			int ESERC = import.leggiNumerico(tr, 4);//  	Anno esercizio   
			if (!ISTTS.Equals(r["ISTTS"]) || !CODEN.Equals(r["CODEN"]) || !ESERC.Equals(r["ESERC"])) {
				QueryCreator.ShowError(this, "Errore nell'intestazione di un record 02 o 09", "");
				return null;
			}
			return import.leggiAlfanumerico(tr, 2);//  	Tipo record  
		}


		private void btnApriEF06_Click(object sender, System.EventArgs e) {
			txtTipo.Text = "EF06";
			labelOperazione.Text = "Lettura file";

			btnEsita.Enabled = parseEF06File();
			
			labelOperazione.Text = null;
			progressBar1.Value = 0;
			Cursor = null;
		}

        /// <summary>
        /// Metodo che effettua il parse del file in formato EF06
        /// </summary>
        /// <returns></returns>
		bool parseEf07File() {
			StreamReader sr = import.getStreamReader(502, openFileDialog1, txtFile);
			if (sr == null) {
				return false;
			}
            ArrayList altriEsercizi = new ArrayList();
            txtInizioElaborazione.Text = null;
			txtFineElaborazione.Text = null;
			DS.IN0109.Clear();
			import.DS.flussobanca.Clear();
			Application.DoEvents();
			Cursor = Cursors.WaitCursor;
			int numFile=0;
			progressBar1.Maximum = (int) sr.BaseStream.Length;
			dataGrid1.DataSource = null;
			while (sr.Peek()!=-1) {
				int numRecord=0;
				numFile++;
				DataRow rTC = DS.IN0109.NewRow();
				if (!leggiEF07RecordDiTesta(sr, rTC)) return false;
				DS.IN0109.Rows.Add(rTC);
				string tiprec = leggiIntestazioneRecord(sr, rTC);
				while (tiprec == "02") {
					numRecord++;
					DataRow rDett = import.DS.flussobanca.NewRow();
					rDett["DTELAB"] = rTC["DTELAB"];
					rDett["ISTTS"] = rTC["ISTTS"];
					rDett["CODEN"] = rTC["CODEN"];
					rDett["ESERC"] = rTC["ESERC"];
					if (!leggiEF07RecordDiDettaglio(sr, rDett)) return false;
					if (!leggiEF07RecordBeneficiario(sr, rDett)) return false;
					if (!leggiEF07RecordCausale(sr, rDett)) return false;
                    if (CfgFn.GetNoNullInt32(rDett["ESERC"]) == CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"))) {
                        import.DS.flussobanca.Rows.Add(rDett);
                    }
                    else {
                        if (!altriEsercizi.Contains(rDett["ESERC"])) {
                            altriEsercizi.Add(rDett["ESERC"]);
                        }
                    }
					tiprec = leggiIntestazioneRecord(sr, rTC);
					progressBar1.Value = (int) sr.BaseStream.Position;
					Application.DoEvents();
				}
				if (tiprec != "09") {
					QueryCreator.ShowError(this, "Mi aspettavo il record 09 invece ho ricevuto il record "+tiprec, "");
					return false;
				}
				if (!leggiEF07FileDiCoda(sr, rTC)) return false;
				//				Console.WriteLine(numFile+" "+numRecord);
			}
			sr.Close();
			DS.IN0109.Clear();
			if (!import.completaParsing(dataGrid1, txtInizioElaborazione, txtFineElaborazione)) {
				return false;
			}
			return true;
		}

		private void btnApriEF07_Click(object sender, System.EventArgs e) {
			txtTipo.Text = "EF07";
			labelOperazione.Text = "Lettura file";
	
			btnEsita.Enabled = parseEf07File();
			
			labelOperazione.Text = null;
			progressBar1.Value = 0;
			Cursor = null;
		}

		private void btnEsita_Click(object sender, System.EventArgs e) {
			Cursor = Cursors.WaitCursor;

			btnEsita.Enabled = !import.esita(false);

			labelOperazione.Text = null;
			progressBar1.Value = 0;
			Cursor = null;

            object ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + Meta.GetSys("esercizio") + "')"
                , "max(transactiondate)");
			if (ultimaEsitazioneDB is DateTime) {
				txtUltimaEsitazioneDB.Text = ((DateTime)ultimaEsitazioneDB).ToShortDateString();
			}
		}

		bool leggiEF06RecordDiTesta(TextReader tr, DataRow r) {
			r["ISTTS1"] = import.leggiNumerico(tr, 3);		//	1	3	N	Codice Istituto Tesoriere
			r["FILTESE"] = import.leggiAlfanumerico(tr, 3);//	4	3	A	Filiale Tesoreria
			r["CODENT1"] = import.leggiNumerico(tr, 9);	//	7	9	N	Codice Ente
			r["ESERC1"] = import.leggiNumerico(tr, 4);		//	16	4	N	Esercizio
			//int tiprec = import.leggiNumerico(tr, 2);
			//r["TIPREC"] = tiprec;		//	20	2	N	Tipo record –Fisso 01
			string tiprec = import.leggiAlfanumerico(tr,2);
			r["TIPREC"] = tiprec; ////	20	2	A	Tipo record –Fisso 01   Maria tracciato aggiornato
			r["WA035"] = import.leggiAlfanumerico(tr, 35);	//	22	35	A	Descrizione flusso prima parte
			r["WA040"] = import.leggiAlfanumerico(tr, 40);	//	57	40	A	Descrizione flusso seconda parte
			r["FILLER"] = import.leggiAlfanumerico(tr,405);//	97	404	A	Campo vuoto
			Console.WriteLine(r["WA035"]);
			if (tiprec != "01") {
				QueryCreator.ShowError(this, "Errore durante la lettura del file", "Era atteso il record 01 invece si è incontrato il record "+tiprec);
				return false;
			}
			return import.vaiACapo(tr);
		}

		bool leggiEF06DettaglioMovimenti(TextReader tr, DataRow r) {
			//			r["ISTTS1"] = import.leggiNumerico(tr, 3);		//	1	3	N	Codice Istituto Tesoriere
			//			r["FILTESE"] = import.leggiAlfanumerico(tr, 3);//	4	3	A	Filiale Tesoreria
			//			r["CODENT1"] = import.leggiNumerico(tr, 9);	//	7	9	N	Codice Ente
			//			r["ESERC1"] = import.leggiNumerico(tr, 4);		//	16	4	N	Esercizio
			//			r["TIPREC"] = import.leggiNumerico(tr, 2);		//	20	2	N	Tipo record –Fisso 02
			r["TIPDOC"] = import.leggiAlfanumerico(tr, 1);	//	22	1	A	Tipo documento – NoteTIPDOC: I = Incasso; R = Reversale; P = Pagamento; M = Mandato
			//			r["NUMDO1"] = import.leggiNumerico(tr, 7);		//	23	7	N	Numero documento
			r["NUMDO1"] = import.leggiAlfanumerico(tr, 7);	//	23	7	A	Numero documento (Maria tracciato aggiornato)
			//			r["PRODO1"] = import.leggiNumerico(tr, 7);		//	30	7	N	Progressivo documento
			r["PRODO1"] = import.leggiAlfanumerico(tr, 7);	//	30	7	A	Progressivo documento (Maria tracciato aggiornato)
			r["CAPBI2"] = import.leggiNumerico(tr, 7);		//	37	7	N	Capitolo di bilancio
			r["ARBTI2"] = import.leggiNumerico(tr, 4);		//	45	4	N	Articolo di bilancio
			r["ANNOC1"] = import.leggiNumerico(tr, 4);		//	48	4	N	Anno competenza
			string segno;
			r["IMPMA1"] = import.leggiDecimaleConSegno(tr, 16, out segno);	//	52	15	N	Importo mandato/reversale indicato in centesimi di euro
			r["SEGNOP"] = segno;					//	67	1	A	Segno operazione
			r["DTPAG9"] = import.leggiDataAMG(tr, 8);			//	68	8	N	Data pagamento/incasso
			r["DVALP2"] = import.leggiDataAMG(tr, 8);			//	76	8	N	Data valuta
			r["PROST1"] = import.leggiNumerico(tr, 7);		//	84	7	N	Progressivo Quietanza
			r["ANABE"] = import.leggiAlfanumerico(tr, 60);	//	91	60	A	Anagrafica beneficiario/versante
			r["DCAP"] = import.leggiAlfanumerico(tr, 60);	//	151	60	A	Descrizione causale operazione
			r["CODGEN"] = import.leggiAlfanumerico(tr, 20);//	211	20	A	Codifica generica (ad uso dell’Ente)
			r["IMPRI1"] = import.leggiDecimale(tr, 15);	//	231	15	N	Importo ritenute indicato in centesimi di euro
			r["INDREG"] = import.leggiAlfanumerico(tr, 1);		//	246	1	A	Indicativo regolazione – NoteINDREG: R = Regolazione (operazione a copertura)
			r["DESTU"] = import.leggiAlfanumerico(tr, 1);	//	247	1	A	Destinazione TU – NoteDESTTU: F = Fruttifera; I = Infruttifera
			r["INDCBI"] = import.leggiAlfanumerico(tr, 1); //	248	1	A	Indicativo BankItalia – NoteINDCBI: O = Ordinaria; C = Capitale
			r["CAUTS"] = import.leggiAlfanumerico(tr, 2);	//	249	2	A	Causale tesoreria
			//			r["NUMOA1"] = import.leggiNumerico(tr, 7);		//	251	7	N	Numero O A
			r["NUMOA1"] = import.leggiAlfanumerico(tr, 7);	//	251	7	A	Numero O A (Maria nuovo tracciato)
			//			r["PROGA1"] = import.leggiNumerico(tr, 7);		//	258	7	N	Progressivo A
			r["PROGA1"] = import.leggiAlfanumerico(tr, 7);	//	258	7	A	Progressivo A (Maria nuovo tracciato)
			r["DVALB2"] = import.leggiDataAMG(tr, 8);		//	265	8	N	Data valuta beneficiario (Maria nel nuovo tracciato da alfanum diventa numerico)
			//			r["CODVER"] = import.leggiNumerico(tr, 5);		//	273	5	N	Codice versamento
			r["CODVER"] = import.leggiAlfanumerico(tr, 5);	//	273	5	A	Codice versamento (Maria nuovo tracciato)
			r["NUMPRA"] = import.leggiAlfanumerico(tr, 10);//	278	10	N	Numero pratica (su segnal. Fabbri da ignorare) 
			r["DESVER"] = import.leggiAlfanumerico(tr, 60);//	288	60	A	Descrizione versamento
			r["NUMPR1"] = import.leggiAlfanumerico(tr, 7);	//	348	7	A	Numero proposta reversale
			r["PROGP1"] = import.leggiAlfanumerico(tr, 4);	//	355	4	A	Progressivo proposta reversale
			r["MANRI1"] = import.leggiAlfanumerico(tr, 7);	//	359	7	A	Numero mandato delle ritenute
			r["PRORI1"] = import.leggiAlfanumerico(tr, 7);	//	366	7	A	Progressivo mand. ritenute
			r["DTELT2"] = import.leggiDataAMG(tr, 8);		//	373	8	N	Data elaborazione
			r["IBOLL1"] = import.leggiNumerico(tr, 5);		//	381	5	N	Importo bolli
			r["INDBOL"] = import.leggiAlfanumerico(tr, 1);	//	386	1	A	Indicatore bolli
			r["ICOMT1"] = import.leggiNumerico(tr, 7);		//	387	7	N	Importo commissioni tesoreria
			r["INDCOM"] = import.leggiAlfanumerico(tr, 1);	//	394	1	A	Indicatore commissioni tesoreria
			r["ISPEP1"] = import.leggiNumerico(tr, 5);		//	395	5	N	Importo spese postali
			r["INDSPT"] = import.leggiAlfanumerico(tr, 1);	//	400	1	A	Indicatore spese tesoreria
			r["BYTLEU"] = import.leggiAlfanumerico(tr, 1); //	401	1	A	Indicatore divisa
			r["BYTLEC"] = import.leggiAlfanumerico(tr, 1); //	402	1	A	
			r["INDMO"] = import.leggiAlfanumerico(tr, 1);	//	403	1	A	Indicatore mo
			r["INDSI"] = import.leggiAlfanumerico(tr, 1);	//	404	1	A	Indicatore SI
			r["TPAGTS"] = import.leggiNumerico(tr, 2);		//	405	2	N	Tipo pagamento tesoreria
			r["CABIT1"] = import.leggiNumerico(tr, 5);		//	407	5	N	Cab it
			string cab = import.leggiAlfanumerico(tr, 5);
			try {
				r["CABDTX"] = int.Parse(cab); 
			} catch (Exception) {
				r["CABDTX"] = 0;
			}
			//			r["CABDTX"] = import.leggiNumerico(tr, 5);		//	412	5	A	Cab dtx
			r["NUMBO"] = import.leggiAlfanumerico(tr, 12);	//	417	12	A	Numero bo
			r["CINRT"] = import.leggiAlfanumerico(tr, 1);	//	429	1	A	
			r["CDMEC2"] = import.leggiLong(tr, 10);		//	430	10	N	Codice meccanografico
			r["IMPMA2"] = import.leggiDecimale(tr, 15);	//	440	15	N	Importo ma
			r["FILLER"] = import.leggiAlfanumerico(tr, 47);//	455	46	A	Campo vuoto
			return import.vaiACapo(tr);
		}				

		bool leggiEF06RecordDiCoda(TextReader tr, DataRow r) {
			//			r["ISTTS1"] = import.leggiNumerico(tr, 3);		//	1	3	N	Codice Istituto Tesoriere
			//			r["FILTESE"] = import.leggiAlfanumerico(tr, 3);//	4	3	A	Filiale tesoriere
			//			r["CODENT1"] = import.leggiAlfanumerico(tr, 9);//	7	9	N	Codice Ente
			//			r["ESERC1"] = import.leggiNumerico(tr, 4);		//	16	4	N	Esercizio
			//			r["TIPREC"] = import.leggiNumerico(tr, 2);		//	20	2	N	Tipo record –Fisso 03
			r["NOINC"] = import.leggiNumerico(tr, 7);		//	22	7	N	Numero operazioni incasso
			decimal decimale;
			r["SEGNO1"] = import.leggiSegnoConDecimaleAoD(tr,16, out decimale);	//	29	1	A	(Maria) Segno incasso modifica temporanea dovuta a errore nel file 
			r["ITOIN2"] = decimale;		//	30	15	N	Importo totale incasso
			r["NOPPAG"] = import.leggiNumerico(tr, 7);		//	45	7	N	Numero operazioni pagamento
			r["SEGNOP"] = import.leggiSegnoConDecimalePiuOMeno(tr, 16, out decimale);	//	52	1	A	Segno pagamento
			r["ITOPA2"] = decimale;					//	53	15	N	Importo totale pagamenti
			r["SEGNOG"] = import.leggiSegnoConDecimalePiuOMeno(tr, 16, out decimale);	//	68	1	A	Segno giacenza
			r["IGIACZ"] = decimale;					//	69	15	N	Importo giacenza
			r["IUTANZ"] = import.leggiDecimale(tr, 15);	//	84	15	N	Importo anticipazione utilizzata
			r["IVIANZ"] = import.leggiDecimale(tr, 15);	//	99	15	N	Importo anticipazione vincolata
			r["IPROI1"] = import.leggiDecimale(tr, 15);	//	114	15	N	Importo progressivo Reversali incassate
			r["IPROP1"] = import.leggiDecimale(tr, 15);	//	129	15	N	Importo progressivo mandati pagati
			string segno;
			r["IFCPR1"] = import.leggiDecimaleConSegno(tr, 16, out segno);	//	144	15	N	Imp. fondo cassa precedente
			r["SEGNOF"] = segno;					//	159	1	A	Segno fondo cassa precedente
			r["BYTLEU"] = import.leggiAlfanumerico(tr, 1);	//	160	1	A	Indicatore divisa
			r["NOINC_"] = import.leggiNumerico(tr, 7);		//	161	7	N	Numero operazione incasso
			r["SEGNO1_"] = import.leggiSegnoConDecimaleAoD(tr, 16, out decimale);	//	168	1	A	Segno incasso
			r["ITOIN2_"] = decimale;				//	169	15	N	Importo totale incasso
			r["NOPPAG_"] = import.leggiNumerico(tr, 7);	//	183	7	N	Numero operazione incasso
			r["SEGNOP_"] = import.leggiSegnoConDecimalePiuOMeno(tr, 16, out decimale);	//	191	1	A	Segno pagamento
			r["ITOPA2_"] = decimale;				//	192	15	N	Importo totale pagamenti
			r["SEGNOG_"] = import.leggiSegnoConDecimalePiuOMeno(tr, 16, out decimale);	//	207	1	A	Segno giacenza
			r["IGIACZ_"] = decimale;				//	208	15	N	Importo giacenza
			r["IUTANZ_"] = import.leggiDecimale(tr, 15);	//	223	15	N	
			r["IVIANZ_"] = import.leggiDecimale(tr, 15);	//	238	15	N	
			r["IPROI1_"] = import.leggiDecimale(tr, 15);	//	253	15	N	
			r["IPROP1_"] = import.leggiDecimale(tr, 15);	//	268	15	N	
			r["IFCPR1_"] = import.leggiDecimale(tr, 15);	//	283	15	N	
			r["SEGNOF_"] = import.leggiAlfanumerico(tr, 1);//	298	1	A	
			r["BYTLEU_"] = import.leggiAlfanumerico(tr, 1);//	299	1	A	Indicatore divisa
			r["FILLER"] = import.leggiAlfanumerico(tr,	202);//300	201	A	Campo vuoto
			return import.vaiACapo(tr);
		}

		private void copia_EF06_IN020304() {
			DS.EF06_TestaCoda.Clear();
			import.DS.flussobanca.Clear();
			foreach (DataRow s in DS.EF06.Rows) {
				DataRow r = import.DS.flussobanca.NewRow();
				r["CFISC"] = "";
				r["ESERC"]  = s["ESERC1"];
				r["TIPDOC"] = s["TIPDOC"];
				r["NUMDOC"] = s["NUMDO1"];
				r["PRODOC"] = s["PRODO1"];
				r["CAPBIL"] = s["CAPBI2"];
				r["ARTBIL"] = s["ARBTI2"];
				r["ANNOCO"] = s["ANNOC1"];
				r["IMPDOC"] = s["IMPMA1"];
				r["SEGNO"] = s["SEGNOP"];
				r["DTPAG"] = s["DTPAG9"];
				r["DVAL"] = s["DVALP2"];
				r["NUMQUI"] = s["PROST1"];
				r["ANABE"] = s["ANABE"];
				r["CAUSALE"] = s["DCAP"];
				r["IMPRIT"] = s["IMPRI1"];
				r["INDREG"] = s["INDREG"];
				r["DVALBE"] = s["DVALB2"];
				r["CODVER"] = s["CODVER"];
				r["NUMPRA"] = s["NUMPRA"];
				r["DESVER"] = s["DESVER"];
				r["NUMPRR"] = s["NUMPR1"];
				r["PROGPR"] = s["PROGP1"];
				r["DTELAB"] = s["DTELT2"];
				r["IBOLLI"] = s["IBOLL1"];
				r["INDBOL"] = s["INDBOL"];
				r["ICOMM"] = s["ICOMT1"];
				r["INDCOM"] = s["INDCOM"];
				r["ISPE"] = s["ISPEP1"];
				r["INDSPE"] = s["INDSPT"];
				r["TPAGTS"] = s["TPAGTS"];
				r["CODABI"] = s["CABIT1"];
				r["CODCAB"] = s["CABDTX"];
				r["CONTO"] = s["NUMBO"];
				r["CIN"] = s["CINRT"];
				r["CDMEC"] = s["CDMEC2"];
				import.DS.flussobanca.Rows.Add(r);
			}
			DS.EF06.Clear();
		}

		private string leggiEF06IntestazioneRecord(TextReader tr, DataRow r) {
			int ISTTS1 = import.leggiNumerico(tr, 3);		//	1	3	N	Codice Istituto Tesoriere
			string FILTESE = import.leggiAlfanumerico(tr, 3);//	4	3	A	Filiale Tesoreria
			int CODENT1 = import.leggiNumerico(tr, 9);	//	7	9	N	Codice Ente
			int ESERC1 = import.leggiNumerico(tr, 4);		//	16	4	N	Esercizio
			if (!ISTTS1.Equals(r["ISTTS1"]) || !FILTESE.Equals(r["FILTESE"]) || !CODENT1.Equals(r["CODENT1"]) 
				|| !ESERC1.Equals(r["ESERC1"])) {
				QueryCreator.ShowError(this, "Errore durante la lettura del file", "Errore nell'intestazione di un record dettaglio o record di coda");
				return null;
			}
			return import.leggiAlfanumerico(tr,2);		//	20	2	N	Tipo record –Fisso 01
		}

        /// <summary>
        /// Metodo che effettua il parse del file in formato EF06
        /// </summary>
        /// <returns></returns>
		bool parseEF06File() {
            ArrayList altriEsercizi = new ArrayList();
			StreamReader sr = import.getStreamReader(503, openFileDialog1, txtFile);
			if (sr == null) {
				return false;
			}
			//			int i=1;
			//			int letti = sr.Read(buffer, 0, 503);
			//			while ((buffer[501]==13)||(buffer[502]==10)) {
			//				i++;
			//				letti = sr.Read(buffer, 0, 503);
			//			}
			//			Console.WriteLine(i+": "+new string(buffer,0,503));
			//			letti = sr.Read(buffer,0,100);
			//			Console.WriteLine(new string(buffer,0,100));
			txtInizioElaborazione.Text = null;
			txtFineElaborazione.Text = null;
			DS.EF06_TestaCoda.Clear();
			DS.EF06.Clear();
			Application.DoEvents();
			Cursor = Cursors.WaitCursor;
			int numFile=0;
			progressBar1.Maximum = (int) sr.BaseStream.Length;
			while (sr.Peek()!=-1) {
				int numRecord=0;
				numFile++;
				DataRow rTC = DS.EF06_TestaCoda.NewRow();
				if (!leggiEF06RecordDiTesta(sr, rTC)) 
					return false;
				DS.EF06_TestaCoda.Rows.Add(rTC);
				string tiprec = leggiEF06IntestazioneRecord(sr, rTC);
				while (tiprec == "02") {
					numRecord++;
					DataRow rDett = DS.EF06.NewRow();
					//rDett["DTELT2"] = rTC["DTELT2"];
					rDett["ISTTS1"] = rTC["ISTTS1"];
					rDett["FILTESE"] = rTC["FILTESE"];
					rDett["CODENT1"] = rTC["CODENT1"];
					rDett["ESERC1"] = rTC["ESERC1"];
					if (!leggiEF06DettaglioMovimenti(sr, rDett)) 
						return false;
                    if (CfgFn.GetNoNullInt32(rDett["ESERC1"]) == CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"))) {
                        DS.EF06.Rows.Add(rDett);
                    }
                    else {
                        if (!altriEsercizi.Contains(rDett["ESERC1"])) {
                            altriEsercizi.Add(rDett["ESERC1"]);
                        }
                    }
					tiprec = leggiEF06IntestazioneRecord(sr, rTC);
					progressBar1.Value = (int) sr.BaseStream.Position;
					Application.DoEvents();
				}
				if (tiprec != "03") {
					QueryCreator.ShowError(this, "Errore durante la lettura del file", "Atteso il record 3; incontrato invece il record "+tiprec);
					return false;
				}
				if (!leggiEF06RecordDiCoda(sr, rTC)) 
					return false;
				//				Console.WriteLine(numFile+" "+numRecord);
			}
			sr.Close();
			copia_EF06_IN020304();
			if (!import.completaParsing(dataGrid1, txtInizioElaborazione, txtFineElaborazione)) {
				return false;
			}
            if (altriEsercizi.Count > 0) {
                string messaggio = "Nel file ci sono esitazioni relative ad esercizi diversi.\nDopo aver esitato nel "
                + Meta.GetSys("esercizio")
                + ", se necessario, occorrerà ripetere l'operazione anche per ";
                if (altriEsercizi.Count == 1) {
                    messaggio += "l'esercizio " + altriEsercizi[0];
                }
                if (altriEsercizi.Count > 1) {
                    messaggio += "gli esercizi " + altriEsercizi[0];
                    for (int i = 1; i < altriEsercizi.Count - 1; i++) {
                        messaggio += ", " + altriEsercizi[i];
                    }
                    messaggio += " e " + altriEsercizi[altriEsercizi.Count - 1];
                }
                show(this, messaggio);
            }
			return true;
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			this.Dispose();
		}
	}

    public class ImportazioneEsitiBancariUnicredit : ImportazioneEsitiBancari {
        DataAccess Conn;
        public ImportazioneEsitiBancariUnicredit(Form form, bool chiusuraAutomaticaPartitePendenti,
            Label labelOperazione, ProgressBar progressBar1, DataAccess Conn)
            :
            base(form, chiusuraAutomaticaPartitePendenti, labelOperazione, progressBar1) {
            this.Conn = Conn;
        
        }

        public override BANCA getBanca() {
            return BANCA.UNICREDIT;
        }

        public override DataTable getInfoMandati(object esercDocPagamento, object numDocPagamento) {
            string query = "SELECT s.ymov as ypay, sl.kpay, p.npay, sl.idpay, PRODOC = sl.idpay, NUMQUI=sl.nbill,"
                + "TPAGTS=m.methodbankcode, "//codicemodalitaCass
                + "sCODABI=sl.idbank, "//codiceabi
                + "sCODCAB=sl.idcab, "//codicecab
                + "CONTO=REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(ISNULL(sl.cc,''),',',''),'.',''),'_',''),'-',''),'*',''),'+',''),'/',''),':',''),';',''), "//contocorrente
                + "CIN=ISNULL(sl.cin,''), "//cin
                + "ANABE=ISNULL(c.title,''), "//denominazioneben
                + "CFISC=CASE WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL THEN c.cf WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN REPLICATE('9',16) ELSE '' END, "//codicefiscaleben
                + "CAUSALE = CASE WHEN (SELECT COUNT(*) FROM expense s1 join expenselast sl1 on s1.idexp=sl1.idexp "
                + " WHERE s1.ymov = s.ymov AND sl1.kpay = sl.kpay AND sl1.idpay = sl.idpay) > 1 THEN 'ACCORPAMENTO PAGAMENTI' "
                + " ELSE ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'') END "
                + "FROM expense s "
                + "JOIN expenselast sl on s.idexp=sl.idexp "
                + " JOIN payment p ON p.kpay = sl.kpay "
                + "JOIN paymethod m ON (sl.idpaymethod = m.idpaymethod) "
                + "JOIN registry c ON (c.idreg = s.idreg) "
                + "JOIN registryclass ctc ON (ctc.idregistryclass = c.idregistryclass) "
                + "WHERE (p.ypay = " + esercDocPagamento
                + ") and (p.npay = " + numDocPagamento
                + ") AND (sl.idpay is not null)";
            string errMsg;
            DataTable tInfo = Conn.SQLRunner(query, -1, out errMsg);
            if (tInfo == null) {
                QueryCreator.ShowError(form, "Errore durante l'esecuzione della query:\r\n" + query, errMsg);
            }
            tInfo.Columns.Add("CODABI", typeof(string));
            tInfo.Columns.Add("CODCAB", typeof(string));
            foreach (DataRow r in tInfo.Rows) {
                r["CODABI"] = r["sCODABI"];
                r["CODCAB"] = r["sCODCAB"];
            }
            return tInfo;
        }

        public override DataTable getInfoReversali(object esercDocIncasso, object numDocIncasso) {
            string query = "SELECT e.ymov as ypro, el.kpro, p.npro, el.idpro, PRODOC = el.idpro, TPAGTS='', CODABI='', CODCAB='', CONTO='', CIN='', NUMQUI=el.nbill,"
                + "ANABE=ISNULL(c.title,''), "
                + "CFISC=CASE WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL THEN c.cf WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN REPLICATE('9',16) ELSE '' END, "
                + "CAUSALE=CASE WHEN (SELECT COUNT(*) FROM income e1 join incomelast el1 on e1.idinc=el1.idinc "
                + " WHERE e1.ymov = e.ymov AND el1.kpro = el.kpro "
                + " AND el1.idpro = el.idpro) > 1 THEN 'ACCORPAMENTO INCASSI' ELSE "
                + " ISNULL(e.doc,'') + ISNULL(CONVERT(varchar(12),e.docdate),'') + ISNULL(e.description,'') END "
                + " FROM income e "
                + " JOIN incomelast el on e.idinc=el.idinc "
                + " JOIN proceeds p ON p.kpro = el.kpro "
                + "JOIN registry c ON c.idreg = e.idreg "
                + "JOIN registryclass ctc ON ctc.idregistryclass = c.idregistryclass "
                + "WHERE p.ypro = " + esercDocIncasso
                + " AND p.npro = " + numDocIncasso
                + " AND el.idpro is not null";
            string errMsg;
            DataTable tInfo = Conn.SQLRunner(query, -1, out errMsg);
            if (tInfo == null) {
                QueryCreator.ShowError(form, "Errore durante l'esecuzione della query:\r\n" + query, errMsg);
            }
            return tInfo;
        }
    }
}
