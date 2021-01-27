
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


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using System.IO;
using funzioni_configurazione;
using System.Globalization;
using bankdispositionsetup_import;

namespace bankdispositionsetup_roma {
	/// <summary>
	/// Summary description for FrmRoma.
	/// </summary>
	public class FrmRoma : System.Windows.Forms.Form {
		ImportazioneEsitiBancariRoma import;
		char[] buffer = new char[503];//globale per ottimizzazione lettura dal file
		MetaData Meta;
		private System.Windows.Forms.TextBox txtUltimaEsitazioneDB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtInizioElaborazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFineElaborazione;
		private System.Windows.Forms.Button btnApriRoma;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label labelOperazione;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.Button btnEsita;
		private System.Windows.Forms.DataGrid dataGrid1;
		public bankdispositionsetup_roma.vistaForm DS;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmRoma() {
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
			this.txtUltimaEsitazioneDB = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtInizioElaborazione = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFineElaborazione = new System.Windows.Forms.TextBox();
			this.btnApriRoma = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.labelOperazione = new System.Windows.Forms.Label();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.btnEsita = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.DS = new bankdispositionsetup_roma.vistaForm();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// txtUltimaEsitazioneDB
			// 
			this.txtUltimaEsitazioneDB.Location = new System.Drawing.Point(12, 46);
			this.txtUltimaEsitazioneDB.Name = "txtUltimaEsitazioneDB";
			this.txtUltimaEsitazioneDB.ReadOnly = true;
			this.txtUltimaEsitazioneDB.Size = new System.Drawing.Size(120, 20);
			this.txtUltimaEsitazioneDB.TabIndex = 28;
			this.txtUltimaEsitazioneDB.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 20);
			this.label3.TabIndex = 29;
			this.label3.Text = "Ultima esitazione sul DB";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtInizioElaborazione);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtFineElaborazione);
			this.groupBox1.Location = new System.Drawing.Point(148, 30);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(232, 40);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Elaborazione";
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
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Inizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(120, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Fine:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFineElaborazione
			// 
			this.txtFineElaborazione.Location = new System.Drawing.Point(152, 16);
			this.txtFineElaborazione.Name = "txtFineElaborazione";
			this.txtFineElaborazione.ReadOnly = true;
			this.txtFineElaborazione.Size = new System.Drawing.Size(72, 20);
			this.txtFineElaborazione.TabIndex = 7;
			this.txtFineElaborazione.Text = "";
			// 
			// btnApriRoma
			// 
			this.btnApriRoma.Location = new System.Drawing.Point(412, 38);
			this.btnApriRoma.Name = "btnApriRoma";
			this.btnApriRoma.Size = new System.Drawing.Size(64, 23);
			this.btnApriRoma.TabIndex = 26;
			this.btnApriRoma.Text = "Apri file";
			this.btnApriRoma.Click += new System.EventHandler(this.btnApriRoma_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(148, 414);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(480, 23);
			this.progressBar1.TabIndex = 24;
			// 
			// labelOperazione
			// 
			this.labelOperazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelOperazione.Location = new System.Drawing.Point(4, 414);
			this.labelOperazione.Name = "labelOperazione";
			this.labelOperazione.Size = new System.Drawing.Size(144, 29);
			this.labelOperazione.TabIndex = 25;
			this.labelOperazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFile.Location = new System.Drawing.Point(12, 6);
			this.txtFile.Name = "txtFile";
			this.txtFile.ReadOnly = true;
			this.txtFile.Size = new System.Drawing.Size(560, 20);
			this.txtFile.TabIndex = 20;
			this.txtFile.Text = "";
			// 
			// btnChiudi
			// 
			this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChiudi.Location = new System.Drawing.Point(580, 3);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.Size = new System.Drawing.Size(48, 23);
			this.btnChiudi.TabIndex = 23;
			this.btnChiudi.Text = "Esci";
			this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
			// 
			// btnEsita
			// 
			this.btnEsita.Enabled = false;
			this.btnEsita.Location = new System.Drawing.Point(500, 38);
			this.btnEsita.Name = "btnEsita";
			this.btnEsita.Size = new System.Drawing.Size(64, 23);
			this.btnEsita.TabIndex = 22;
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
			this.dataGrid1.Location = new System.Drawing.Point(12, 70);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(616, 344);
			this.dataGrid1.TabIndex = 21;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// FrmRoma
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 446);
			this.Controls.Add(this.txtUltimaEsitazioneDB);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnApriRoma);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.labelOperazione);
			this.Controls.Add(this.txtFile);
			this.Controls.Add(this.btnChiudi);
			this.Controls.Add(this.btnEsita);
			this.Controls.Add(this.dataGrid1);
			this.Name = "FrmRoma";
			this.Text = "FrmRoma";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Meta.MainRefreshEnabled=false;
			Meta.SearchEnabled=false;
			Meta.CanSave=false;
			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.CanCancel=false;
            DataAccess.SetTableForReading(DS.bankdispositionsetup, "config");
			import = new ImportazioneEsitiBancariRoma(this, true, labelOperazione, progressBar1, Meta.Conn);
			Text = "Importazione esiti dei movimenti Banca di Roma";
            object ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + Meta.GetSys("esercizio") + "')"
                , "max(transactiondate)");
            if (ultimaEsitazioneDB == DBNull.Value){
                ultimaEsitazioneDB=Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + (CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1) + "' )"
                    , "max(transactiondate)");
            }

			if (ultimaEsitazioneDB is DateTime) {
				txtUltimaEsitazioneDB.Text = ((DateTime)ultimaEsitazioneDB).ToShortDateString();
			}
		}

		public void MetaData_AfterFill() {
			Text = "Importazione esiti dei movimenti Banca di Roma";
		}

		public void MetaData_AfterClear() {
			Text = "Importazione esiti dei movimenti Banca di Roma";
		}

		bool parseRomaFile(StreamReader sr) {
            ArrayList altriEsercizi = new ArrayList();
            txtInizioElaborazione.Text = null;
			txtFineElaborazione.Text = null;
			DS.roma.Clear();
			Application.DoEvents();
			Cursor = Cursors.WaitCursor;

			Hashtable ht = new Hashtable();

            ht["GIROFE"] = "I+ ";// Apertura partita pendete incasso, Regolarizzato da Regolarizzazione sospeso entrata
            ht["GIROFU"] = "P+ ";// Apertura partita pendete pagamento, Regolarizzato da Regolarizzazione sospeso uscita

            ht["SOSPEU"] = "P+ ";// Sospeso in uscita, Regolarizzato da Regolarizzazione sospeso uscita 
            ht["STSOSU"] = "P-R";// Storno sospeso in uscita. Regolarizza partita pendente di sospeu

            ht["SOSPEN"] = "I+ ";// Sospeso d’entrata. regolarizzato da regsoe
            ht["STSOSE"] = "I-R";// Storno sospeso in entrat. Regolarizza partita pendente di sospen

			ht["MANDAT"] = "M+ ";
			ht["STOMAN"] = "M- ";//storno di mandat

			ht["REVERS"] = "R+ ";
			ht["STOREV"] = "R- ";//storno di revers

            ht["REGSOU"] = "M+R";//Regolarizzazione sospeso uscita. regolarizza girofu e sospeu
            ht["ANRESU"] = "M-R";//Annullamento regolarizzazione sospeso uscita. storno di regsou

            ht["REGSOE"] = "R+R";//Regolarizzazione sospeso entrata. regolarizza girofe e sospen
            ht["ANRESE"] = "R-R";// Annullamento regolarizzazione sospeso entrata.  storno di regsoe

			progressBar1.Maximum = (int) sr.BaseStream.Length;
			while (sr.Peek()!=-1) {
				DataRow r = DS.roma.NewRow();
				if (!leggiRigaRoma(sr, ht, r)) {
					return false;
				}
                if (CfgFn.GetNoNullInt32(r["esercdocumento"]) == CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"))) {
                    DS.roma.Rows.Add(r);
                }
                else {
                    if (!altriEsercizi.Contains(r["esercdocumento"])) {
                        altriEsercizi.Add(r["esercdocumento"]);
                    }
                }
				progressBar1.Value = (int) sr.BaseStream.Position;
				Application.DoEvents();
			}
			sr.Close();
			copia_Roma_IN020304();
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
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, messaggio);
            }
            return true;
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

		private bool leggiRigaRoma(TextReader tr, Hashtable ht, DataRow r) {
			r["ente"] = import.leggiNumerico(tr, 4);// string(buffer, 0, sr.Read(buffer, 0, 4));
			r["esercdocumento"] = import.leggiNumerico(tr,4);// int.Parse(new string(buffer, 0, sr.Read(buffer, 0, 4)));
			r["numtipomovimento"] = import.leggiAlfanumerico(tr, 2);// new string(buffer, 0, sr.Read(buffer, 0, 5));
			r["rifbanca"] = import.leggiNumerico(tr, 10);// new string(buffer, 0, sr.Read(buffer, 0, 7));
			r["numdocumento"] = import.leggiNumerico(tr, 14);// new string(buffer, 0, sr.Read(buffer, 0, 7));
            r["progrdoc"] = import.leggiNumerico(tr, 7); //import.leggiAlfanumerico(tr, 7);//new string(buffer, 0, sr.Read(buffer, 0, 7));
			r["datapagamento"] = import.leggiDataGMA(tr, 8);// DateTime.ParseExact(new string(buffer, 0, sr.Read(buffer, 0, 8)), "ddMMyyyy", DateTimeFormatInfo.CurrentInfo);
			string divisa, segno;
			r["importo"] = import.leggiDecimaleRoma(tr, out divisa, out segno);
			r["divisa"] = divisa;
			r["codicebollo"] = import.leggiAlfanumerico(tr, 2);
			r["creditoredebitore"] = import.leggiAlfanumerico(tr, 90);// new string(buffer, 0, sr.Read(buffer, 0, 95));
			r["codicessd"] = import.leggiAlfanumerico(tr, 10);// new string(buffer, 0, sr.Read(buffer, 0, 9));
			r["causale"] = import.leggiAlfanumerico(tr, 4);
			string tipo = import.leggiAlfanumerico(tr, 6);// string(buffer, 0, sr.Read(buffer, 0, 6));
			if ((tipo=="ANRESE")||(tipo=="ANRESU")) {
				r["importo"] = - (decimal) r["importo"];
			}
			r["tipo"] = tipo;
			object o = ht[tipo];
			if (o==null) {
				string messaggio = "";
				foreach (object t in ht.Keys) {
					messaggio += ", " + t;
				}
				QueryCreator.ShowError(this, "Tipo di movimento sconosciuto: "+tipo, "I tipi di movimento accettati sono:\n"+messaggio.Substring(2));
				return false;
			}
			string flag = (string) o;
			r["tipdoc"] = flag[0];
			r["segno"] = flag[1];
			r["indreg"] = flag[2];
			bool b1 = segno.Equals(r["segno"]);
			bool b2 = ((tipo == "ANRESE") || (tipo == "ANRESU"));
			if (b1 == b2) {
				QueryCreator.ShowError(this, "Errore nel segno di un importo\n"+tipo+": "+flag, "Errore durante la lettura del file");
				return false;
			}
			r["descrizione"] = import.leggiAlfanumerico(tr, 249);// new string(buffer, 0, sr.Read(buffer, 0, 249));
			r["datavaluta"] = import.leggiDataGMA(tr, 8);// new string(buffer, 0, sr.Read(buffer, 0,  8));
			r["capitolo"] = import.leggiNumerico(tr, 15);// new string(buffer, 0, sr.Read(buffer, 0, 43));
			r["articolo"] = import.leggiNumerico(tr, 10);// new string(buffer, 0, sr.Read(buffer, 0, 43));
			r["annoresiduo"] = import.leggiAlfanumerico(tr, 4);// new string(buffer, 0, sr.Read(buffer, 0, 43));
			r["importooriginalesub"] = import.leggiAlfanumerico(tr, 14);// new string(buffer, 0, sr.Read(buffer, 0, 43));
			r["divisaios"] = import.leggiAlfanumerico(tr, 3);// new string(buffer, 0, sr.Read(buffer, 0,  3));
			r["datacaricamento"] = import.leggiDataGMA(tr, 8);// new string(buffer, 0, sr.Read(buffer, 0,  8));
			r["tipopagamento"] = import.leggiNumerico(tr, 5);// new string(buffer, 0, sr.Read(buffer, 0,  5));
			r["datavalutabeneficiario"] = import.leggiDataGMA(tr, 8);// new string(buffer, 0, sr.Read(buffer, 0,  8));
			r["abi"] = import.leggiNumerico(tr, 5);// new string(buffer, 0, sr.Read(buffer, 0, 22));
			r["cab"] = import.leggiNumerico(tr, 5);// new string(buffer, 0, sr.Read(buffer, 0, 22));
			r["conto"] = import.leggiAlfanumerico(tr, 12);// new string(buffer, 0, sr.Read(buffer, 0, 22));
			r["cin"] = import.leggiAlfanumerico(tr, 1);// new string(buffer, 0, sr.Read(buffer, 0, 51));
			r["indirizzo"] = import.leggiAlfanumerico(tr, 50);// new string(buffer, 0, sr.Read(buffer, 0, 51));
			r["cap"] = import.leggiAlfanumerico(tr, 5);// new string(buffer, 0, sr.Read(buffer, 0,  5));
			r["localita"] = import.leggiAlfanumerico(tr, 50);// new string(buffer, 0, sr.Read(buffer, 0, 53));
			r["voceeconomica"] = import.leggiAlfanumerico(tr, 5);// new string(buffer, 0, sr.Read(buffer, 0, 53));
			r["competenzaresidui"] = import.leggiAlfanumerico(tr, 1);// new string(buffer, 0, sr.Read(buffer, 0,  2));
			r["attribuito"] = import.leggiAlfanumerico(tr, 1);// new string(buffer, 0, sr.Read(buffer, 0,  2));
			r["dataimportazione"] = import.leggiDataGMA(tr, 8);// DateTime.ParseExact(new string(buffer, 0, sr.Read(buffer, 0, 8)), "ddMMyyyy", DateTimeFormatInfo.CurrentInfo);
			return import.vaiACapo(tr);
		}

		private void copia_Roma_IN020304() {
			import.DS.flussobanca.Clear();
			foreach (DataRow s in DS.roma.Rows) {
				string tipoMov = s["tipo"].ToString();
				DataRow r = import.DS.flussobanca.NewRow();
				//				r["ISTTS"] = s[""];
				r["CODEN"] = s["ente"];
				r["ESERC"]  = s["esercdocumento"];
				r["TIPDOC"] = s["tipdoc"];
				r["NUMDOC"] = s["numdocumento"];
				r["PRODOC"] = s["progrdoc"];
				r["CAPBIL"] = s["capitolo"];
				r["ARTBIL"] = s["articolo"];
				//				r["CDMEC"] = s[""];
				//				r["ANNOCO"] = s[""];
				r["IMPDOC"] = s["importo"];
				r["SEGNO"] = s["segno"];
				r["DTELAB"] = s["dataimportazione"];
				//				r["DTELAB"] = s["datacaricamento"];coincide con data pagamento
				r["DTPAG"] = s["datapagamento"];
				r["DVAL"] = s["datavaluta"];
				r["NUMQUI"] = s["rifbanca"];
				//				r["NUMDIS"] = s[""];
				//				r["IMPRIT"] = s[""];
				r["INDREG"] = s["indreg"];
				r["DVALBE"] = s["datavalutabeneficiario"];
				//				r["NUMPRA"] = s[""];
				//				r["CODVER"] = s[""];
				//				r["NUMPRR"] = s[""];
				//				r["PROGPR"] = s[""];
				//				r["IBOLLI"] = s[""];
				//				r["INDBOL"] = s[""];
				//				r["ICOMM"] = s[""];
				//				r["INDCOM"] = s[""];
				//				r["ISPE"] = s[""];
				//				r["INDSPE"] = s[""];
				r["TPAGTS"] = s["tipopagamento"];
				r["CODABI"] = s["abi"];
				r["CODCAB"] = s["cab"];
				r["CONTO"] = s["conto"];
				r["CIN"] = s["cin"];
				//				r["IBAN_PAE"] = s[""];
				//				r["IBAN_CHK"] = s[""];
				//				r["IBAN_COO"] = s[""];
				//				r["NCNT"] = s[""];
				//				r["CTIPIPU"] = s[""];
				//				r["DESVER"] = s[""];
				//				r["CCGU"] = s[""];
				//				r["CCPV"] = s[""];
				//				r["CCUP"] = s[""];
				//				r["FILLER"] = s[""];
				r["ANABE"] = s["creditoredebitore"];
				r["INDIR"] = s["indirizzo"];
				r["CAP"] = s["cap"];
				r["LOC"] = s["localita"];
				r["CFISC"] = "";
				r["CAUSALE"] = s["descrizione"];
				r["FILLER"] = s["tipo"];
				//				r[""] = s["numtipomovimento"];
				//				r[""] = s["divisa"];
				//				r[""] = s["codicebollo"];
				//				r[""] = s["codicessd"];
				//				r[""] = s["causale"];
				//				r[""] = s["annoresiduo"];
				//				r[""] = s["importooriginalesub"];
				//				r[""] = s["divisaios"];
				//				r[""] = s["voceeconomica"];
				//				r[""] = s["competenzaresidui"];
				//				r[""] = s["attribuito"];

				import.DS.flussobanca.Rows.Add(r);
			}
			DS.roma.Clear();
		}

		private void btnApriRoma_Click(object sender, System.EventArgs e) {
			StreamReader sr = import.getStreamReader(648, openFileDialog1, txtFile);
			if (sr == null) {
				return;
			}
			labelOperazione.Text = "Lettura file";

			btnEsita.Enabled = parseRomaFile(sr);

			labelOperazione.Text = null;
			progressBar1.Value = 0;
			Cursor = null;
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			this.Dispose();
		}
		
	}

    public class ImportazioneEsitiBancariRoma : ImportazioneEsitiBancari {
        DataAccess Conn;
        public ImportazioneEsitiBancariRoma(Form form, bool chiusuraAutomaticaPartitePendenti,
            Label labelOperazione, ProgressBar progressBar1, DataAccess Conn)
            :
            base(form, chiusuraAutomaticaPartitePendenti, labelOperazione, progressBar1) {
            this.Conn = Conn;
        }

        public override BANCA getBanca() {
            return BANCA.ROMA;
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
                + "CAUSALE = ISNULL(s.description,'') "//descpagamento
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
                + "CAUSALE=ISNULL(e.description,'') "
                + "FROM income e "
                + "JOIN incomelast el on e.idinc=el.idinc "
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
