
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
using System.IO;
using System.Data;
using System.Collections;
using metadatalibrary;
using System.Windows.Forms;
using funzioni_configurazione;
using System.Globalization;
using System.Text;

namespace bankdispositionsetup_import {
	/// <summary>
	/// Summary description for ImportazioneEsitiBancari.
	/// </summary>
	public abstract class ImportazioneEsitiBancari {
		string erroreBloccante = "L'elaborazione del file verrà annullata. Si prega di contattare la banca segnalando i riferimenti succitati";
		char[] buffer = new char[503];
		public vistaForm DS = new vistaForm();
		protected Form form;
		Label labelOperazione;
		ProgressBar progressBar1;
		MetaData Meta, metaDMB, metaPP;
		bool chiusuraAutomaticaPartitePendenti;
        CQueryHelper QHC;
        QueryHelper QHS;

		public ImportazioneEsitiBancari(Form form, bool chiusuraAutomaticaPartitePendenti,
			Label labelOperazione, ProgressBar progressBar1) {
			this.chiusuraAutomaticaPartitePendenti = chiusuraAutomaticaPartitePendenti;
			this.form = form;
			this.labelOperazione = labelOperazione;
			this.progressBar1 = progressBar1;
			Meta = MetaData.GetMetaData(form);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			metaDMB = MetaData.GetMetaData(form, "banktransaction");
			metaPP = MetaData.GetMetaData(form, "bill");
			
			PostData.MarkAsTemporaryTable(DS.flussobanca, false);
		}

		public int leggiNumerico(TextReader tr, int numCifre) {
			if (tr.Read(buffer, 0, numCifre) != numCifre) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
			}
			string s = new string(buffer, 0, numCifre);
			try {
				return int.Parse(s);
			} catch (Exception e) {
				string spazi = "".PadRight(numCifre);
				if (s != spazi) {
					QueryCreator.ShowException(form, "ERRORE DURANTE LA LETTURA DI UN NUMERICO DAL FILE\r\n"+s, e);
				}
				return 0;
			}
		}

		public long leggiLong(TextReader tr, int numCifre) {
			if (tr.Read(buffer, 0, numCifre) != numCifre) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
			}
			string s = new string(buffer, 0, numCifre);
			try {
				return long.Parse(s);
			} catch (Exception e) {
				QueryCreator.ShowException(form, "ERRORE DURANTE LA LETTURA DI UN LONG DAL FILE\r\n"+s, e);
			}
			return 0;
		}

		public decimal leggiDecimale(TextReader tr, int numCifre) {
			if (tr.Read(buffer, 0, numCifre) != numCifre) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
			}
			string s = new string(buffer, 0, numCifre-2)
				+ NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
				+ new string(buffer, numCifre-2, 2);
			return decimal.Parse(s);
		}

		public string leggiSegnoConDecimaleAoD(TextReader tr, int numCifre, out decimal decimale) {
			if (tr.Read(buffer, 0, numCifre) != numCifre) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
			}
			if (buffer[0]!='A'&& buffer[0]!='D'){
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Ho incontrato un segno diverso da A o D");
			}

			string segno = buffer[0]=='A'? "": "-";
			string s = segno 
				+  new string(buffer, 1, numCifre-3)
				+ NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
				+ new string(buffer, numCifre-2, 2);
			decimale = decimal.Parse(s);
			return buffer[0].ToString();
		}
		
		public string leggiSegnoConDecimalePiuOMeno(TextReader tr, int numCifre, out decimal decimale) {
			if (tr.Read(buffer, 0, numCifre) != numCifre) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
			}
			if (buffer[0]!='+'&& buffer[0]!='-'){
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Ho incontrato un segno diverso da + o -");
			}

			//			string segno = buffer[0]=='A'? "": "-";
			string s =  
				new string(buffer, 0, numCifre-2)
				+ NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
				+ new string(buffer, numCifre-2, 2);
			decimale = decimal.Parse(s);
			return buffer[0].ToString();
		}

		public decimal leggiDecimaleConSegno(TextReader tr, int numCifre, out string segno) {
			if (tr.Read(buffer, 0, numCifre) != numCifre) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
			}
			segno = buffer[numCifre-1].ToString();
			string s = buffer[numCifre-1]
				+ new string(buffer, 0, numCifre-3)
				+ NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
				+ new string(buffer, numCifre-3, 2);
			return decimal.Parse(s);
		}

		public object leggiDataGMA(TextReader tr, int numCifre) {
			if (tr.Read(buffer, 0, numCifre) != numCifre) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
			}
			try {
				return (object)DateTime.ParseExact(new string(buffer, 0, numCifre), "ddMMyyyy", DateTimeFormatInfo.CurrentInfo);
			} catch (Exception e) {
                string s = new string(buffer, 0, numCifre);
				string zeri = "".PadRight(numCifre,'0');
				string spazi = "".PadRight(numCifre,' ');
				if ((s != zeri) && (s != spazi)) {
					QueryCreator.ShowException(form, "ERRORE DURANTE LA LETTURA DEL FILE: DATA GMA", e);
				}
                return DBNull.Value;
			}
		}
		
		public object leggiDataAMG(TextReader tr, int numCifre) {
			if (tr.Read(buffer, 0, numCifre) != numCifre) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
			}
            string s = new string(buffer, 0, numCifre);
			try {
                return (object) DateTime.ParseExact(s, "yyyyMMdd", DateTimeFormatInfo.CurrentInfo);
			} catch (Exception e) { 
				if (new string(buffer, 0, numCifre) != "".PadRight(numCifre,'0')) {
					QueryCreator.ShowException(form, "ERRORE DURANTE LA LETTURA DEL FILE: DATA AMG\r\n"+s, e);
				}
                return DBNull.Value;
			}
		}

		public string leggiAlfanumerico(TextReader tr, int numCifre) {
			if (tr.Read(buffer, 0, numCifre) != numCifre) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
			}
			return new string(buffer, 0, numCifre).Trim();
		}


		public bool vaiACapo(TextReader tr) {
			if (tr.Read(buffer, 0, 2) != 2) {
				QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
				return false;
			}
			if ((buffer[0] != 13) || (buffer[1] != 10)) {
				QueryCreator.ShowError(form, "Manca l'interruzione di riga", "Manca l'interruzione di riga");
				return false;
			}
			return true;
		}

		#region lettura ef07

		bool leggiEF07RecordDiTesta(TextReader tr, DataRow r) {
			r["ISTTS"] = leggiNumerico(tr, 5);//  	Codice istituto
			r["CODEN"] = leggiNumerico(tr, 7);//  	Codice ente  
			r["ESERC"] = leggiNumerico(tr, 4);//  	Anno esercizio   
			string tiprec = leggiAlfanumerico(tr, 2);//  	Tipo record  
			r["DESC"] = leggiAlfanumerico(tr, 50);//  	Descrizione ente 
			r["NDG"] = leggiLong(tr, 11);//  	Codice anagrafico ente
			r["DTELAB"] = leggiDataGMA(tr, 8);//	Data elaborazione (nel formato GGMMAAAA)
			r["FILLER"] = leggiAlfanumerico(tr, 413);//  	Campo a disposizione 
			if (tiprec != "01") {
				QueryCreator.ShowError(form, "Mi aspettavo il record 01 invece ho ricevuto il record "+tiprec,"");
				return false;
			}
			return vaiACapo(tr);
		}

		bool leggiEF07RecordDiDettaglio(TextReader tr, DataRow r) {
			//			dettaglio.ISTTS = leggiNumerico(tr, 5);//  	Codice istituto
			//			dettaglio.CODEN = leggiNumerico(tr, 7);//  	Codice ente  
			//			dettaglio.ESERC = leggiNumerico(tr, 4);//  	Anno esercizio   
			//			dettaglio.TIPREC = leggiAlfanumerico(tr, 2);//  	Tipo record  
			r["TIPDOC"] = leggiAlfanumerico(tr, 1);//  	Tipo documento (M = mandato R = reversale I = part pend. incasso P = part. Pend. pagamento)      
			r["NUMDOC"] = leggiAlfanumerico(tr, 7);//  	Numero documento  
			r["PRODOC"] = leggiAlfanumerico(tr, 7);//  	Progressivo documento 
			r["CAPBIL"] = leggiNumerico(tr, 7);//  	Capitolo bilancio  
			r["ARTBIL"] = leggiNumerico(tr, 4);//  	Articolo bilancio  
			r["CDMEC"] = leggiNumerico(tr, 9);//  	Codice meccanografico   
			r["ANNOCO"] = leggiNumerico(tr, 4);//  	Anno competenza  
			string segno;
			r["IMPDOC"] = leggiDecimaleConSegno(tr, 16, out segno);//  	Importo documento al lordo delle ritenute (gli ultimi due bytes sono da considerarsi decimali)  
			r["SEGNO"] = segno;//  	Segno operazione (+ per operazioni standard, - per storni)
			r["DTPAG"] = leggiDataGMA(tr, 8);//  	Data pagamento /incasso (nel formato GGMMAAAA)  
			r["DVAL"] = leggiDataGMA(tr, 8);//  	Data valuta pagamento /incasso (nel formato GGMMAAAA)  
			r["NUMQUI"] = leggiNumerico(tr, 7);//  	Numero progr. quietanza 
			r["NUMDIS"] = leggiNumerico(tr, 7);//	Numero distinta
			r["IMPRIT"] = leggiDecimale(tr, 15);//  	Importo ritenute (gli ultimi due bytes sono da considerarsi decimali)   
			r["INDREG"] = leggiAlfanumerico(tr, 1);//  	Indicativo regolazione (se contiene il valore “R” trattasi di regolazione)  
			r["DVALBE"] = leggiDataGMA(tr, 8);//  	Data valuta beneficiario (nel formato GGMMAAAA)  
			r["NUMPRA"] = leggiAlfanumerico(tr, 16);//  	Numero pratica  
			r["CODVER"] = leggiAlfanumerico(tr, 5);//	Codice versamento
			r["NUMPRR"] = leggiAlfanumerico(tr, 7);//  	Numero proposta di reversale 
			r["PROGPR"] = leggiAlfanumerico(tr, 4);//  	Progressivo proposta di reversale  
			r["IBOLLI"] = leggiDecimale(tr, 9);//  	Importo bolli (gli ultimi due bytes sono da considerarsi decimali)  
			r["INDBOL"] = leggiAlfanumerico(tr, 1);//  	Indicatore bolli (valorizzato solo per campi non esenti (C = cliente E  = ente I = istituto) 
			r["ICOMM"] = leggiDecimale(tr, 9);//  	Importo commissioni (gli ultimi due bytes sono da considerarsi decimali)  
			r["INDCOM"] = leggiAlfanumerico(tr, 1);//  	Indicatore commissioni ( C = cliente E = ente)  
			r["ISPE"] = leggiDecimale(tr, 9);//  	Importo spese (gli ultimi due bytes sono da considerarsi decimali)
			r["INDSPE"] = leggiAlfanumerico(tr, 1);//  	Indicatore spese ( C = cliente E = ente I = istituto)  
			r["TPAGTS"] = leggiNumerico(tr, 2);//  	Tipo pagamento   
			r["CODABI"] = leggiNumerico(tr, 5);//  	Codice ABI  
			r["CODCAB"] = leggiNumerico(tr, 5);//  	Codice CAB  
			r["CONTO"] = leggiAlfanumerico(tr, 12);//  	Numero del conto corrente    
			r["CIN"] = leggiAlfanumerico(tr, 1);//  	CIN conto corrente   
			r["IBAN_PAE"] = leggiAlfanumerico(tr, 2);//	Codice IBAN paese
			r["IBAN_CHK"] = leggiNumerico(tr, 2);//	Codice IBAN check digit
			r["IBAN_COO"] = leggiAlfanumerico(tr, 30);//	Codice IBAN coordinate
            r["NCNT"] = leggiAlfanumerico(tr, 7);//	Numero conto tesoreria
			r["CTIPIPU"] = leggiNumerico(tr, 3);//	Tipo imputazione
			r["DESVER"] = leggiAlfanumerico(tr, 60);//	Descrizione codice versamento
			r["CCGU"] = leggiAlfanumerico(tr, 10);//	Codice Gestionale (CGE/CGU) 
			r["CCPV"] = leggiAlfanumerico(tr, 14);//	Common procurement vocabulary (CPV)
			r["CCUP"] = leggiAlfanumerico(tr, 15);//	Codice unico di progetto (CUP)
			r["FILLER"] = leggiAlfanumerico(tr, 143);//  	Campo a disposizione
			//			Console.WriteLine(r["TIPDOC"]+"\t"+r["NUMDOC"]+"\t"+r["PRODOC"]+"\t"+r["IMPDOC"]+"\t"+r["NUMQUI"]+"\t'"+r["INDREG"]+"'");
			return vaiACapo(tr);
		}

		bool leggiEF07RecordBeneficiario(TextReader tr, DataRow r) {
			int ISTTS = leggiNumerico(tr, 5);//	Codice istituto
			int CODEN = leggiNumerico(tr, 7);//	Codice ente
			int ESERC = leggiNumerico(tr, 4);//	Anno esercizio
			string TIPREC = leggiAlfanumerico(tr, 2);//	Tipo record	
			r["TIPDOC"] = leggiAlfanumerico(tr, 1);//	Tipo documento
			r["NUMDOC"] = leggiAlfanumerico(tr, 7);//	Numero documento
			r["PRODOC"] = leggiAlfanumerico(tr, 7);//	Progressivo documento
			r["ANABE"] = leggiAlfanumerico(tr, 300);//	Anagrafica beneficiario
			r["INDIR"] = leggiAlfanumerico(tr, 30);//	Indirizzo beneficiario
			r["CAP"] = leggiAlfanumerico(tr, 5);//	CAP beneficiario
			r["LOC"] = leggiAlfanumerico(tr, 30);//	Località beneficiario
			r["CFISC"] = leggiAlfanumerico(tr, 16);//	Codice fiscale beneficiario
			r["FILLER"] = leggiAlfanumerico(tr, 86);//	Campo a disposizione
			if (TIPREC != "03") {
				QueryCreator.ShowError(form, "Mi aspettavo il record 03 invece ho ricevuto il record "+TIPREC, "");
				return false;
			}
			if (!ISTTS.Equals(r["ISTTS"]) || !CODEN.Equals(r["CODEN"]) || !ESERC.Equals(r["ESERC"])) {
				QueryCreator.ShowError(form, "Errore nell'intestazione del record 03", "");
				return false;
			}
			return vaiACapo(tr);
		}

		bool leggiEF07RecordCausale(TextReader tr, DataRow r) {
			int ISTTS = leggiNumerico(tr, 5);//	Codice istituto
			int CODEN = leggiNumerico(tr, 7);//	Codice ente
			int ESERC = leggiNumerico(tr, 4);//	Anno esercizio
			string tiprec = leggiAlfanumerico(tr, 2);//	Tipo record
			r["TIPDOC"] = leggiAlfanumerico(tr, 1);//	Tipo documento
			r["NUMDOC"] = leggiAlfanumerico(tr, 7);//	Numero documento
			r["PRODOC"] = leggiAlfanumerico(tr, 7);//	Progressivo documento
			r["CAUSALE"] = leggiAlfanumerico(tr, 400);//	Causale descrittiva
			r["FILLER"] = leggiAlfanumerico(tr, 67);//	Campo a disposizione
			if (tiprec != "04") {
				QueryCreator.ShowError(form, "Mi aspettavo il record 04 invece ho ricevuto il record "+tiprec, "");
				return false;
			}
			if (!ISTTS.Equals(r["ISTTS"]) || !CODEN.Equals(r["CODEN"]) || !ESERC.Equals(r["ESERC"])) {
				QueryCreator.ShowError(form, "Errore nell'intestazione del record 04", "");
				return false;
			}
			return vaiACapo(tr);
		}

		bool leggiEF07FileDiCoda(TextReader tr, DataRow r) {
			//			coda.ISTTS = leggiNumerico(tr, 5);//  	Codice istituto
			//			coda.CODEN = leggiNumerico(tr, 7);//  	Codice ente  
			//			coda.ESERC = leggiNumerico(tr, 4);//  	Anno esercizio   
			//			coda.TIPREC = leggiAlfanumerico(tr, 2);//  	Tipo record  
			r["FILTS"] = leggiNumerico (tr, 5);//  	Codice dipendenza  
			r["SEG_FDO"] = leggiAlfanumerico(tr, 1);//  	Segno del fondo di cassa
			r["FDO"] = leggiDecimale(tr, 15);//  	Importo del fondo di cassa (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["REV_INC"] = leggiDecimale(tr, 15);//  	Importo delle reversali incassate (gli ultimi 2 bytes sono da considerarsi decimali)
			r["REV_CAR"] = leggiDecimale(tr, 15);//  	Importo delle reversali caricate e non incassate (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_PPI"] = leggiDecimale(tr, 15);//  	Importo delle partite pendenti di incasso (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["MAN_PAG"] = leggiDecimale(tr, 15);//  	Importo dei mandati pagati (gli ultimi 2 bytes sono da considerarsi decimali)
			r["MAN_CAR"] = leggiDecimale(tr, 15);//  	Importo dei mandati caricati  e non pagati (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_PPP"] = leggiDecimale(tr, 15);//  	Importo delle partite pendenti di pagamento (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["SAL_DIR"] = leggiDecimale(tr, 15);//  	Importo saldo di diritto (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["SAL_FAT"] = leggiDecimale(tr, 15);//  	Importo saldo di fatto (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["FIDO"] = leggiDecimale(tr, 15);//  	Importo del fido accordato (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_LIB"] = leggiDecimale(tr, 15);//  	Importo totale delle somme libere (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_NTU"] = leggiDecimale(tr, 15);//  	Importo totale delle somme vincolate non TU (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_TU"] = leggiDecimale(tr, 15);//  	Importo totale delle somme vincolate TU (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["IMP_ANT"] = leggiDecimale(tr, 15);//  	Importo totale delle somme del conto anticipi (gli ultimi 2 bytes sono da considerarsi decimali) 
			r["FILLER"] = leggiAlfanumerico(tr, 266);//  	Campo a disposizione 
			//			Console.WriteLine(r["FILTS"]+" "+r["SEG_FDO"]+" "+r["FDO"]+" "+r["REV_INC"]+" "+r["REV_CAR"]+" "+r["IMP_PPI"] 
			//				+" "+r["MAN_PAG"]+" "+r["MAN_CAR"]+" "+r["IMP_PPP"]+" "+r["SAL_DIR"]+" "+r["SAL_FAT"]+" "+r["FIDO"] 
			//				+" "+r["IMP_LIB"]+" "+r["IMP_NTU"]+" "+r["IMP_TU"]+" "+r["IMP_ANT"]);
			return vaiACapo(tr);
		}

		#endregion

        /// <summary>
        /// Metodo che apre il file contenente gli esiti ritornando uno StreamReader
        /// </summary>
        /// <param name="quoziente"></param>
        /// <param name="openFileDialog1"></param>
        /// <param name="txtFile"></param>
        /// <returns></returns>
		public StreamReader getStreamReader(long quoziente, OpenFileDialog openFileDialog1, TextBox txtFile) {
			openFileDialog1.FileName = txtFile.Text;
			DialogResult dr = openFileDialog1.ShowDialog(form);
			if (dr == DialogResult.OK) {
				txtFile.Text = openFileDialog1.FileName;
				FileInfo fi = new FileInfo(openFileDialog1.FileName);
				long dimensione = fi.Length;
				long modulo = fi.Length % quoziente;
				if (modulo > 0) {
					QueryCreator.ShowError(form, "La dimensione del file non è un multiplo di "+quoziente, "Errore di dimensione del file");
					return null;
				}
				try {
					return new StreamReader(new BufferedStream(openFileDialog1.OpenFile(), 1048576), Encoding.Default);
				} catch (Exception e2) {
					QueryCreator.ShowException(form, "Errore durante l'apertura del file selezionato!", e2);
				}
			} else {
				QueryCreator.ShowError(form, "Nessun file selezionato!", "Scegliere un file trasmesso dalla banca");
			}
			return null;
		}

		private string leggiIntestazioneRecord(TextReader tr, DataRow r) {
			int ISTTS = leggiNumerico(tr, 5);//  	Codice istituto
			int CODEN = leggiNumerico(tr, 7);//  	Codice ente  
			int ESERC = leggiNumerico(tr, 4);//  	Anno esercizio   
			if (!ISTTS.Equals(r["ISTTS"]) || !CODEN.Equals(r["CODEN"]) || !ESERC.Equals(r["ESERC"])) {
				QueryCreator.ShowError(form, "Errore nell'intestazione di un record 02 o 09", "");
				return null;
			}
			return leggiAlfanumerico(tr, 2);//  	Tipo record  
		}

		private void cambiaNomiAlleColonne() {
			foreach (DataColumn c in DS.flussobanca.Columns) {
				switch (c.ColumnName) {
                    case "SEGNO": c.Caption = "Segno"; break;//
					case "ESERC": c.Caption = "Esercizio"; break;//
					case "TIPDOC": c.Caption = "Tipo"; break;//
					case "NUMDOC": c.Caption = "Num. doc."; break;//
					case "PRODOC": c.Caption = "Progr. doc."; break;
					case "IMPDOC": c.Caption = "Importo"; break;//
					case "NUMQUI": c.Caption = "Bolletta"; break;//
					case "INDREG": c.Caption = "Reg."; break;
					case "ANABE": c.Caption = "Beneficiario"; break;//
					case "CAUSALE": c.Caption = "Causale"; break;//
					case "DTPAG": c.Caption = "Data"; break;//
					case "tipomovbancario": c.Caption = "c/d"; break;
					default: c.Caption = null; break;
				}
			}
			foreach (DataRow r in DS.flussobanca.Rows) {
                if (r.RowState == DataRowState.Deleted) continue;

				object DTELAB = (r["DTELAB"]);
                object DTPAG = (r["DTPAG"]);
                object DVAL = (r["DVAL"]);
                object DVALBE = (r["DVALBE"]);
				if (DTPAG != DTELAB) {
					DS.flussobanca.Columns["DTELAB"].Caption = "Elaborazione";
				}
				if (DTPAG != DVAL) {
					DS.flussobanca.Columns["DVAL"].Caption = "Valuta";
				}
				if (DVALBE != DBNull.Value) {
					DS.flussobanca.Columns["DVALBE"].Caption = "Valuta beneficiario";
				}
			}
		}

		private string salva() {
			PostData P = Meta.Get_PostData();
			string errore = P.InitClass(DS, Meta.Conn);
			if (errore != null) {
				return errore;
			}
			if (!P.DO_POST()) {
				return "Esitazione non portata a termine.\r\n"+P.GetErrorMsg;
			}
			return null;
		}

		private ArrayList valoriDistinti(DataTable t, string filtro, string[] colonne) {
			ArrayList al = new ArrayList();
			foreach (DataRow r in t.Select(filtro)) {
				string condizione = QueryCreator.WHERE_COLNAME_CLAUSE(r, colonne, DataRowVersion.Current, false);
				int pos = al.BinarySearch(condizione);
				if (pos < 0) {
					al.Insert(-pos-1, condizione);
				}
			}
			return al;
		}

        /// <summary>
        /// Metodo che elimina gli annullamenti della regolarizzazione.
        /// </summary>
        /// <returns></returns>
		private bool eliminaAnnullamentiRegolazione() {
            // La regolarizzazione è individiata secondo il filtro successivo. Viene riempito un arraylist con
            // le coppie TIPDOC, NUMQUI
            //ArrayList list = valoriDistinti(DS.flussobanca, "SEGNO='+' and TIPDOC in ('I','P') and INDREG='R'",
            //    new string[] { "TIPDOC", "NUMQUI" });
            ArrayList list = valoriDistinti(DS.flussobanca, "TIPDOC in ('M','R')",
                new string[] { "TIPDOC",  "NUMDOC", "ESERC"});
            // Per ogni regolarizzazione individuata si procede alla cancellazione degli annullamenti
			foreach (string condizione in list) {
                                        //+" and INDREG='R'"
				DataRow[] rReg = DS.flussobanca.Select(condizione, "SEGNO");//-prima il segno meno
                decimal val0 = Math.Abs((decimal) rReg[0]["IMPDOC"]);
                if (rReg[0]["SEGNO"].ToString() == "-") val0 = -val0;
				for (int i=1; i<rReg.Length; i++) {
                    if (rReg[i]["SEGNO"].ToString() == "+") {
                        val0 += (decimal)rReg[i]["IMPDOC"];
                    }
                    else {
                        val0 -= Math.Abs((decimal)rReg[i]["IMPDOC"]);
                    }
					//rReg[0]["IMPDOC"] = (decimal) rReg[0]["IMPDOC"] + (decimal) rReg[i]["IMPDOC"];
					rReg[i].Delete();
				}
                if (val0 >= 0) {
                    rReg[0]["SEGNO"] = "+";
                    rReg[0]["IMPDOC"] = val0;
                }
                else {
                    rReg[0]["SEGNO"] = "-";
                    rReg[0]["IMPDOC"] = -val0;
                }
                if (val0 == 0) rReg[0].Delete();
			}
            /*
             * Il codice seguente viene commentato in quanto esegue un errato accorpamento delle righe, che impedisce di 
             * effettuare le esitazioni quando nello stesso file si trova l'apertura del provvisorio e regolarizzazioni parziali
             * */
            /*
            list = valoriDistinti(DS.flussobanca, "TIPDOC in ('I','P')",
                new string[] { "TIPDOC", "NUMQUI", "NUMDOC","ESERC" });

            foreach (string condizione in list) {
                DataRow[] rReg = DS.flussobanca.Select(condizione, "SEGNO");//-prima il segno meno
                decimal val0 = Math.Abs((decimal)rReg[0]["IMPDOC"]);
                if (rReg[0]["SEGNO"].ToString() == "-") val0 = -val0;
                for (int i = 1; i < rReg.Length; i++) {
                    if (rReg[i]["SEGNO"].ToString() == "+") {
                        val0 += (decimal)rReg[i]["IMPDOC"];
                    }
                    else {
                        val0 -= Math.Abs((decimal)rReg[i]["IMPDOC"]);
                    }
                    //rReg[0]["IMPDOC"] = (decimal) rReg[0]["IMPDOC"] + (decimal) rReg[i]["IMPDOC"];
                    rReg[i].AcceptChanges();
                    rReg[i].Delete();
                }
                if (val0 >= 0) {
                    rReg[0]["SEGNO"] = "+";
                    rReg[0]["IMPDOC"] = val0;
                }
                else {
                    rReg[0]["SEGNO"] = "-";
                    rReg[0]["IMPDOC"] = -val0;
                }
                if (val0 == 0)
                {
                    rReg[0].AcceptChanges();
                    rReg[0].Delete();
                }
            }
            */
            //// Stessa operazione eseguita precedentemente si effettua sulle regolarizzazioni con segno "-"
            //list = valoriDistinti(DS.flussobanca, "SEGNO='-' and TIPDOC in ('M','R') and INDREG='R'", 
            //    new string[] {"TIPDOC", "NUMDOC", "NUMQUI"});
            //foreach (string condizione in list) {
            //    DataRow[] rReg = DS.flussobanca.Select(condizione+" and INDREG='R'", "SEGNO DESC");//+prima il segno più
            //    for (int i=1; i<rReg.Length; i++) {
            //        rReg[0]["IMPDOC"] = (decimal) rReg[0]["IMPDOC"] + (decimal) rReg[i]["IMPDOC"];
            //        rReg[i].Delete();
            //    }
            //}
			return true;
		}

        private object ricavaDescrizioneCassiere(object sottoconto){
            if (sottoconto.ToString().Trim() == "") return DBNull.Value;
            if (sottoconto.ToString() == "0") return DBNull.Value;
            object treasurer = Meta.Conn.DO_READ_VALUE("treasurer", QHS.AppAnd(QHS.CmpEq("trasmcode", sottoconto), QHS.BitClear("flag", 0)), "description");
            if (treasurer == null) treasurer = DBNull.Value;
            return treasurer;
        }

        private object ricavaCodiceCassiere(object sottoconto)
        {
            if (sottoconto.ToString().Trim() == "") return DBNull.Value;
            if (sottoconto.ToString() == "0") return DBNull.Value;
           
            object idtreasurer = Meta.Conn.DO_READ_VALUE("treasurer",
                QHS.AppAnd(QHS.CmpEq("trasmcode", sottoconto), QHS.BitClear("flag", 0)), "idtreasurer");
            if (idtreasurer == null) idtreasurer = DBNull.Value;
            return idtreasurer;
        }
        /// <summary>
        /// Metodo che elimina eventuali storni presenti nel flusso inviato dalla banca
        /// </summary>
        /// <returns></returns>
		private bool eliminaStorni() {
			if (!eliminaAnnullamentiRegolazione()) return false;
            DataRow[] rStorni = DS.flussobanca.Select("SEGNO='-' and TIPDOC in ('M','R')");
			progressBar1.Maximum = rStorni.Length;
			labelOperazione.Text = "Eliminazione storni";
			Application.DoEvents();
			foreach (DataRow r in rStorni) {
				decimal importo = Math.Abs(((decimal) r["IMPDOC"]));
				//				if (r["INDREG"].ToString()!="R") {
				//importo = -importo;
				//				}
				//Aggiunto il filtro su tipodoc perchè possono esserci storni dello stesso importo
				//nella stessa giornata sulle partite pendenti ( da testare)

                //// Per Carime è stato modificata la costruzione del filtro, perchè in presenza di Storni 016
                // Il n° di ricevuta, ovvero NUMQUI è diverso tra le due righe, perchè per gli storni effettuati fuori giornata viene 
                // creato un nuovo numero di ricevuta corrispondente all'operazione di storno
                ////string filter = "(SEGNO='+') and (ESERC="+r["ESERC"]+") and (TIPDOC='"+r["TIPDOC"]+"') AND (NUMQUI="+r["NUMQUI"]+
                ////        ") and (IMPDOC="+	QueryCreator.quotedstrvalue(importo, false)
                ////    + ") and (NUMDOC = '" + r["NUMDOC"] + "')";
                string filter = "(SEGNO='+') and (ESERC=" + r["ESERC"] + ") and (IMPDOC=" + QueryCreator.quotedstrvalue(importo, false)
                    + ")";

                if (r["NUMDOC"] != DBNull.Value){
                    filter = QHC.AppAnd(filter, QHC.CmpEq("NUMDOC", r["NUMDOC"]));
                }
                
                if (r["TIPDOC"] != DBNull.Value){
                    filter = QHC.AppAnd(filter, QHC.CmpEq("TIPDOC", r["TIPDOC"]));
                }
                if (r["NUMQUI"] != DBNull.Value){
                    filter = QHC.AppAnd(filter, QHC.CmpEq("NUMQUI", r["NUMQUI"]));
                }
                
				//								") and (TIPDOC in ('R','M'))";	
				DataRow[] rDaEliminare = DS.flussobanca.Select(filter);
                if (rDaEliminare.Length != 0)
                {
                    if (rDaEliminare.Length > 1)
                    {
                        string messaggio = "PROBLEMA SU UNO STORNO\r\nA fronte di una riga con importo negativo sono state trovate " + rDaEliminare.Length;
                        QueryCreator.ShowError(form, messaggio + " righe con importo positivo.",
                            "Esercizio: " + r["ESERC"]
                            + "\r\nTipo documento: " + r["TIPDOC"]
                            + "\r\nNum. bolletta: " + r["NUMQUI"]
                            + "\r\nNum. documento: " + r["NUMDOC"]
                            + "\r\nImporto: " + r["IMPDOC"]);
                    }
                    r.Delete();
                    if (rDaEliminare.Length >= 1)
                    {
                        rDaEliminare[0].Delete();
                    }
                }
				
				progressBar1.Value ++;
			}
			return true;
		}

        /// <summary>
        /// Metodo che popola una hashtable dove vengono inseriti i riferimenti dei documenti
        /// presenti nel flusso.
        /// </summary>
        /// <param name="TIPDOC"></param>
        /// <param name="SEGNO"></param>
        /// <returns></returns>
		private Hashtable getElencoMandatiOReversali(string TIPDOC, string SEGNO){
			Hashtable ht = new Hashtable();
			string filtroRigheBanca = "TIPDOC='"+TIPDOC+"' and SEGNO='"+SEGNO+"'";
			foreach (DataRow r in DS.flussobanca.Select(filtroRigheBanca)) {
				object numdocumento = ht[r["ESERC"]];
				if (numdocumento == null) {
					ArrayList list = new ArrayList();
					list.Add(r["NUMDOC"]);
					ht[r["ESERC"]] = list;
				} else {
					ArrayList list = (ArrayList) numdocumento;
					if (!list.Contains(r["NUMDOC"])) {
						list.Add(r["NUMDOC"]); 
					}
				}
			}
			return ht;

		}

        /// <summary>
        /// Metodo che esita mandati e reversali.
        /// La scelta di esitare mandati e/o reversali dipende dai parametri di input
        /// </summary>
        /// <param name="TIPDOC">M per Mandato; R per Reversale</param>
        /// <param name="SEGNO">Valori ammessi: "+", "-"</param>
        /// <returns></returns>
		private bool esitaMandatiOReversali(string TIPDOC, string SEGNO) {
            // Si riempie la hashtable per ottenere l'elenco dei documenti finanziari
			Hashtable ht = getElencoMandatiOReversali(TIPDOC, SEGNO);
				
            // Sezione dichiarativa - Si valorizzano le variabili in base al tipo di esitazione
            // se è sui mandati o sulle reversali
			string tipomovbancario = TIPDOC == "M" ? "D" : "C";
			string nomeDocumenti = TIPDOC=="M" ? "mandati" : "reversali";
			string movBancario = TIPDOC == "M" ? "payment_bankview" : "proceeds_bankview";
			string ydoc_field = TIPDOC == "M" ? "ypay" : "ypro";
			string ndoc_field = TIPDOC == "M" ? "npay" : "npro";
            string kdoc_field = TIPDOC == "M" ? "kpay" : "kpro";
			string iddoc_field = TIPDOC == "M" ? "idpay" : "idpro";

            // Per ogni elemento della hashtable si cerca il movimento bancario presente sul DB che si vuole esitare.
            // Si effettua questa ricerca per "somiglianza" in quanto i dati forniti dalla banca nel flusso di ritorno non sempre
            // corrispondono precisamente con quelli presenti sul "db", per via ad esempio del submovimento che è calcolato
            // in modo differente dalle varie banche rispetto a quello che memorizziamo noi come parte della chiave
            // del movimento bancario (sia esso legato ad un mandato o ad una reversale)
			foreach (DictionaryEntry de in ht) {
				ArrayList list = (ArrayList)de.Value;
				progressBar1.Maximum = list.Count;
				progressBar1.Value = 0;
				labelOperazione.Text = "Esitazione "+nomeDocumenti+" "+de.Key.ToString();
				foreach (object numDoc in list) {
                    string filter = QHS.AppAnd(QHS.CmpEq(ydoc_field, de.Key),
                                        QHS.CmpEq(ndoc_field, numDoc));
                    string gialetti = QHS.DistinctVal(DS.Tables[movBancario].Select(filter), ndoc_field);
					//string filtroGiaLetti = QueryCreator.ColumnValues(DS.Tables[movBancario], filter, ndoc_field, true);
                    //if (filtroGiaLetti != "") {
                    //    filter += " and ("+ ndoc_field + " not in (" + filtroGiaLetti + "))";
                    //}
                    if (gialetti != "")
                        filter = QHS.AppAnd(filter, QHS.FieldNotInList(ndoc_field, gialetti));

					DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.Tables[movBancario], null, filter, null, true);
                    
					DataTable tInfo = TIPDOC=="M" 
						? getInfoMandati(de.Key, numDoc)
						: getInfoReversali(de.Key, numDoc);

					if (tInfo == null) {
                        QueryCreator.ShowError(form, "Tabella VUOTA!","Tabella VUOTA!");
						return false;
					}

					// esitazione del documento corrente
                    string filtroRigheBanca = QHC.AppAnd(
                        QHC.CmpEq("SEGNO", SEGNO), QHC.CmpEq("TIPDOC", TIPDOC),
                                    QHC.CmpEq("ESERC", de.Key), QHC.CmpEq("NUMDOC", numDoc));
                        //"SEGNO='"+SEGNO
                        //+ "' and TIPDOC = '" + TIPDOC + "' AND (ESERC="+de.Key+") and (NUMDOC = "+numDoc+ ")";
					foreach (DataRow rBanca in DS.flussobanca.Select(filtroRigheBanca)) {
                        string filtro = QHC.AppAnd(QHC.CmpEq(ydoc_field, rBanca["ESERC"]),
                                        QHC.CmpEq(ndoc_field,rBanca["NUMDOC"]));
                            
                        if (getBanca()==BANCA.UNICREDIT) {
                            filtro = QHC.AppAnd(filtro, QHC.CmpEq(iddoc_field, rBanca["PRODOC"]));
                        }

                        decimal importoBanca = (decimal) rBanca["IMPDOC"];
						// JTR In questo momento sto individuando una sola operazione del movimento bancario
						// Può accadere che sul DB tale movimento non esista in quanto la banca ritorna il PRODDOC
						// a fatti suoi.
						DataRow [] rMovBanc = DS.Tables[movBancario].Select(filtro);
                        bool disponibileSuDbInsufficiente = true;
						if (rMovBanc.Length == 1) {
							decimal importoGiaEsitato = calcolaEsitato(rMovBanc[0]);

                            if (rBanca["SEGNO"].ToString() == "+") { //((decimal)rBanca["IMPDOC"] > 0) {
                                filtro += " and (amount>" + QueryCreator.quotedstrvalue(importoGiaEsitato, false) + ")";
                            }
                            else {
                                if (importoGiaEsitato==0)
                                    filtro += " and (amount<>amount)"; //forza il non trovare alcuna riga
                            }
                            //else {
                            //    filtro += " and (amount<=" + QueryCreator.quotedstrvalue(importoGiaEsitato, false) + ")";
                            //}
							// JTR Per come sono le cose l'array di sotto potrà avere o 0 o 1 datarow
							DataRow[] rMovimenti = DS.Tables[movBancario].Select(filtro);
							
							if (rMovimenti.Length == 1) {
								decimal importoDisponibileSulDb = CfgFn.GetNoNullDecimal(rMovimenti[0]["amount"])
									- importoGiaEsitato;
                                if (  ((rBanca["SEGNO"].ToString() == "+")&& (importoDisponibileSulDb >= importoBanca))
                                      ||
                                      ((rBanca["SEGNO"].ToString() == "-") && importoGiaEsitato>0)
                                    )    
                                {
                                    disponibileSuDbInsufficiente = false;
                                    // JTR Attenzione prima di esitare un movimento bancario, devo controllare che questo
                                    // abbia una effettiva corrispondenza sul DB e non che per pura coincidenza 
                                    // il movimento comunicato dalla banca abbia i campi chiave di un movimento
                                    // finanziario differente da quello che si vuole esitare
                                    int differenza = verificaMovimento(rMovimenti[0], rBanca, tInfo, TIPDOC);
                                    if (differenza == -1) return false;
                                    decimal iEsitato;
                                    if (!esitaUnMovimento(tipomovbancario, rMovimenti[0], rBanca, importoDisponibileSulDb, importoBanca, out iEsitato)) {
                                        raiseError(rBanca);
                                        return false;
                                    }
                                }
							}
                            if ((rMovimenti.Length == 1) && (disponibileSuDbInsufficiente)){
                                if (!esitaPiuMovimenti(rBanca, TIPDOC, importoBanca, tInfo)) {
                                    raiseError(rBanca);
                                    return false;
                                }
                            }

                            if (rMovimenti.Length != 1) {
                                if (!esitaPiuMovimenti(rBanca, TIPDOC, importoBanca, tInfo)) {
                                    raiseError(rBanca);
                                    return false;
                                }
                            }
						}
						else {
							if (!esitaPiuMovimenti(rBanca, TIPDOC, importoBanca, tInfo)) {
                                raiseError(rBanca);
								return false;
							}
						}
						if (chiusuraAutomaticaPartitePendenti && (rBanca["INDREG"].ToString()=="R")) {
							if (!chiusuraEventualeDiPartitaPendente(rBanca)) {
                                raiseError(rBanca);
								return false;
							}
						}
					}
					progressBar1.Value ++;
					Application.DoEvents();
				}
			}
			return true;
		}

        private DataRow [] fillEmptyBankTransactionFromDB(string filtro, string filtroSQL, string kind) {
            
            // Se trovo qualcosa in memoria vuol dire che sono riuscito a mettere queste righe in una chiamata
            // precedente a questo metodo e quindi esco
            if (DS.banktransaction.Select(filtro).Length > 0) {
                return DS.banktransaction.Select(filtro);
            }

            string nDoc = (kind == "C") ? "npro" : "npay";
            string yDoc = (kind == "C") ? "ypro" : "ypay";
            string kDoc = (kind == "C") ? "kpro" : "kpay";

            string q = "(select distinct " + kDoc + " from banktransaction where " + filtroSQL + ")";
            DataTable tApp = Meta.Conn.SQLRunner(q);
            // Se non ci sono esiti su DB torno un array con zero elementi
            if ((tApp == null) || (tApp.Rows.Count == 0)) return DS.banktransaction.Select(filtro);

            //string kDocList = QueryCreator.ColumnValues(tApp, null, nDoc, false);
            //string filter = "(" + kDoc + " IN (" + kDocList + ")) AND (" + yDoc + " = '" + Meta.GetSys("esercizio") + "')";

            string filter = QHS.FieldIn(kDoc, tApp.Select());

            DataTable tApp2 = DataAccess.CreateTableByName(Meta.Conn, "banktransaction", "*");
            tApp2 = DataAccess.RUN_SELECT(Meta.Conn, "banktransaction", "*", null, filter, null, null, true);
            QueryCreator.MergeDataTable(DS.banktransaction, tApp2);

            return DS.banktransaction.Select(filtro);
        }

        /// <summary>
        /// Metodo che esita un movimento bancario
        /// </summary>
        /// <param name="tipoDoc"></param>
        /// <param name="rOpMovBancario"></param>
        /// <param name="rRigaBanca"></param>
        /// <param name="importoDisponibile"></param>
        /// <param name="importoBanca"></param>
        /// <param name="importoEsitato"></param>
        /// <returns></returns>
        private bool esitaUnMovimento(string tipoDoc, DataRow rOpMovBancario, DataRow rRigaBanca,
            decimal importoDisponibile, decimal importoBanca, out decimal importoEsitato) 
        {
            // Si valuta il segno del movimento presente nel flusso, se negativo si procede ad esitare un
            // movimento negativo, altrimenti un positivo
            string segno = rRigaBanca["segno"].ToString();
            if (segno == "-") {
                return esitaUnMovimentoNegativo(tipoDoc, rOpMovBancario, rRigaBanca,
                    importoBanca, out importoEsitato);
            }
            return esitaUnMovimentoPositivo(tipoDoc, rOpMovBancario, rRigaBanca,
                importoDisponibile, importoBanca, out importoEsitato);
        }

        /// <summary>
        /// Metodo che esita un movimento bancario positivo
        /// </summary>
        /// <param name="tipoDoc"></param>
        /// <param name="rOpMovBancario"></param>
        /// <param name="rRigaBanca"></param>
        /// <param name="importoDisponibile"></param>
        /// <param name="importoBanca"></param>
        /// <param name="importoEsitato"></param>
        /// <returns></returns>
        private bool esitaUnMovimentoPositivo(string tipoDoc, DataRow rOpMovBancario, DataRow rRigaBanca, 
            decimal importoDisponibile, decimal importoBanca, out decimal importoEsitato) 
        {
            importoEsitato = 0;
			string tMov = (tipoDoc == "D") ? "expenseview" : "incomeview";
			string idmov = (tipoDoc == "D") ? "idexp" : "idinc";
			
			string filtroKey = QueryCreator.WHERE_KEY_CLAUSE(rOpMovBancario, DataRowVersion.Current, false);
            // Si selezionano i movimenti finanziari associati al movimento bancario
			DataRow [] rMovimentiFin = DS.Tables[tMov].Select(filtroKey);

			// Se non ci sono mov. finanziari associati all'esito mi preoccupo
			if (rMovimentiFin.Length == 0) return false;

            decimal residuoBanca = importoBanca;
            decimal disponibileMovBan = importoDisponibile;
            foreach (DataRow rMovFin in rMovimentiFin) {
                if ((importoBanca == 0)) return true;
                if (disponibileMovBan == 0) break;
                decimal importoDaEsitare = CfgFn.GetNoNullDecimal(rMovFin["curramount"]);
                
                // Si ottengono gli esiti presenti su DB
                string f = QHC.CmpEq(idmov, rMovFin[idmov]);
                string fSQL = QHS.CmpEq(idmov, rMovFin[idmov]);
                DataRow[] rEsito = fillEmptyBankTransactionFromDB(f, fSQL, tipoDoc);

                if (rEsito.Length != 0) {
                    foreach (DataRow r in rEsito) {
                        importoDaEsitare -= CfgFn.GetNoNullDecimal(r["amount"]);
                    }
                }
                if (importoDaEsitare <= 0) 
                    continue;

                if (disponibileMovBan < importoDaEsitare) {
                    importoDaEsitare = disponibileMovBan;
                }

                if (residuoBanca < importoDaEsitare) {
                    importoDaEsitare = residuoBanca;
                }

                creaEsitazione(rOpMovBancario, rRigaBanca, importoDaEsitare, tipoDoc, rMovFin);
                residuoBanca -= importoDaEsitare;
                disponibileMovBan -= importoDaEsitare;
                importoEsitato += importoDaEsitare;
            }

			return (importoEsitato == importoBanca);
		}

        /// <summary>
        /// Metodo che esita un movimento bancario negativo
        /// </summary>
        /// <param name="tipoDoc"></param>
        /// <param name="rOpMovBancario"></param>
        /// <param name="rRigaBanca"></param>
        /// <param name="importoDisponibile"></param>
        /// <param name="importoBanca"></param>
        /// <param name="importoEsitato"></param>
        /// <returns></returns>
        private bool esitaUnMovimentoNegativo(string tipoDoc, DataRow rOpMovBancario, DataRow rRigaBanca,
             decimal importoBanca, out decimal importoEsitato) 
        {
            importoEsitato = 0;
            string tMov = (tipoDoc == "D") ? "expenseview" : "incomeview";
            string idmov = (tipoDoc == "D") ? "idexp" : "idinc";

            string filtroKey = QueryCreator.WHERE_KEY_CLAUSE(rOpMovBancario, DataRowVersion.Current, false);
            // Si selezionano i movimenti finanziari associati al movimento bancario
            DataRow[] rMovimentiFin = DS.Tables[tMov].Select(filtroKey);

            // Se non ci sono mov. finanziari associati all'esito mi preoccupo
            if (rMovimentiFin.Length == 0) return false;

            decimal residuoBanca = - Math.Abs( importoBanca);//negativo, valore DA ESITARE (ossia sottrarre all'esitato)
            //decimal disponibileMovBan = importoDisponibile;//negativo>residuobanca
            foreach (DataRow rMovFin in rMovimentiFin) {
                if (residuoBanca == 0) break;
                //if (disponibileMovBan == 0) break;
                decimal importoDaEsitare = 0;

                // Si ottengono gli esiti presenti su DB
                string f = QHC.CmpEq(idmov, rMovFin[idmov]);
                string fSQL = QHS.CmpEq(idmov, rMovFin[idmov]);
                DataRow[] rEsito = fillEmptyBankTransactionFromDB(f, fSQL, tipoDoc);

                if (rEsito.Length != 0) {
                    foreach (DataRow r in rEsito) {
                        importoDaEsitare -= CfgFn.GetNoNullDecimal(r["amount"]);
                    }
                }
                if (importoDaEsitare >= 0)
                    continue;//non posso disesitare nulla perchè nulla è stato esitato

                //l'importo da esitare = max(-importogiàesitato, disponibileMovBan, residuoBanca)
                //dove: importogiàesitato>0, disponibileMovBan<0, residuoBanca<0

                //if (disponibileMovBan > importoDaEsitare) {
                //    importoDaEsitare = disponibileMovBan;
                //}

                if (residuoBanca > importoDaEsitare) {
                    importoDaEsitare = residuoBanca;
                }

                creaEsitazione(rOpMovBancario, rRigaBanca, importoDaEsitare, tipoDoc, rMovFin);
                //importoDaEsitare<0
                residuoBanca -= importoDaEsitare;//residuoBanca aumenta (si avvicina a 0)
                //disponibileMovBan -= importoDaEsitare;//disponibileMovBanca aumenta (si avvicina a 0)
                importoEsitato += importoDaEsitare;//importoEsitato diminuisce (si avvicina a 0)
            }

            return (importoEsitato == -Math.Abs(importoBanca));
        }

        /// <summary>
        /// Metodo che scrive sulla tabella BANKTRANSACTION
        /// </summary>
        /// <param name="rOperazione"></param>
        /// <param name="rRigaBanca"></param>
        /// <param name="importo"></param>
        /// <param name="tipoDoc"></param>
        /// <param name="rMov"></param>
        private void creaEsitazione(DataRow rOperazione, DataRow rRigaBanca, decimal importo, string tipoDoc, DataRow rMov) {
			string idmov = (tipoDoc == "D") ? "idexp" : "idinc";

			metaDMB.SetDefaults(DS.Tables["banktransaction"]);
            
			DataRow rBankTrans = metaDMB.Get_New_Row(rOperazione, DS.Tables["banktransaction"]);
			rBankTrans["bankreference"] = rRigaBanca["NUMQUI"];
			rBankTrans["transactiondate"] = rRigaBanca["DTPAG"];
			rBankTrans["valuedate"] = rRigaBanca["DVAL"];
			rBankTrans["amount"] = importo;
			rBankTrans[idmov] = rMov[idmov];
			rBankTrans["kind"] = tipoDoc;
		}

        /// <summary>
        /// Metodo che chiude una partita pendente lasciata aperta
        /// </summary>
        /// <param name="rBanca"></param>
        /// <returns></returns>
		bool chiusuraEventualeDiPartitaPendente(DataRow rBanca) {
            // Si ottiene l'elenco delle partite pendenti presenti nel dataset che rispondono ad un certo filtro
			string tipoDoc = rBanca["TIPDOC"].ToString() == "M" ? "D" : "C";
            string filtroPP = QHC.AppAnd(QHC.CmpEq("ybill", rBanca["ESERC"]),
                QHC.CmpEq("nbill", rBanca["NUMQUI"]), QHC.CmpEq("billkind", tipoDoc));
            string filtroSQL = QHS.AppAnd(QHS.CmpEq("ybill", rBanca["ESERC"]),
                QHS.CmpEq("nbill", rBanca["NUMQUI"]), QHS.CmpEq("billkind", tipoDoc));

     
            DataRow[] rPP = DS.bill.Select(filtroPP);
			if (rPP.Length == 0) {
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.bill, null, filtroPP, null, true);
                rPP = DS.bill.Select(filtroPP);
			}
			if (rPP.Length != 1) {
                string filterDel = rBanca["TIPDOC"].Equals("M") ?
                                    QHC.AppAnd(QHC.CmpEq("TIPDOC", 'P'), QHC.CmpEq("SEGNO", '+'),
                                    QHC.CmpEq("ESERC", rBanca["ESERC"]), QHC.CmpEq("NUMQUI", rBanca["NUMQUI"]))
                                    :
                                    QHC.AppAnd(QHC.CmpEq("TIPDOC", 'I'), QHC.CmpEq("SEGNO", '+'),
                                    QHC.CmpEq("ESERC", rBanca["ESERC"]), QHC.CmpEq("NUMQUI", rBanca["NUMQUI"]));

			}

            object numQUi = rBanca["numqui"].ToString();
            if (numQUi.ToString() == "") numQUi = DBNull.Value;
            string qDs = QHC.AppAnd(QHC.CmpEq("yban", rBanca["ESERC"]), QHC.CmpEq("bankreference", numQUi),
                QHC.CmpEq("kind", tipoDoc));
            string qDs_SQL = QHS.AppAnd(QHS.CmpEq("yban", rBanca["ESERC"]), QHS.CmpEq("bankreference", numQUi),
                QHS.CmpEq("kind", tipoDoc));
            DataRow[] rDMB = fillEmptyBankTransactionFromDB(qDs, qDs_SQL, tipoDoc);

			decimal importoCoperto = 0;

			foreach (DataRow r in rDMB) {
				importoCoperto += (decimal) r["amount"];
			}

			string movBancario = tipoDoc == "D" ? "payment_bank" : "proceeds_bank";
			string ydoc_field = tipoDoc == "D" ? "ypay" : "ypro";
			string ndoc_field = tipoDoc == "D" ? "npay" : "npro";
            string kdoc_field = tipoDoc == "D" ? "kpay" : "kpro";
			string iddoc_field = tipoDoc == "D" ? "idpay" : "idpro";
            string mov = tipoDoc == "D" ? "expenselast" : "incomelast";

            
            /*string qDb1 = "select sum(bt.amount) from banktransaction bt join " + movBancario + " pb on "
                + "(bt." + kdoc_field + " = pb." + kdoc_field + ") and (bt." + iddoc_field + " = pb." + iddoc_field + ") "
                + " join  " + mov + " ls on "
                + "(ls." + kdoc_field + " = pb." + kdoc_field + ") and (ls." + iddoc_field + " = pb." + iddoc_field + ") " 
                + " WHERE " + QHS.AppAnd(QHS.CmpEq("bt.yban", rBanca["ESERC"]), QHS.CmpEq("ls.nbill", rBanca["NUMQUI"]),
                QHS.CmpEq("kind", tipoDoc));*/

            // La query precedente era errata in quanto assumeve che ci fosse una corispondenza 1:1 tra movimenti bancari e movimenti finanziari
            // e quindi duplicava le righe 
            string qDb = " select SUM(S.amount) FROM ( select distinct bt.amount, bt.yban, bt.nban from banktransaction bt join " + movBancario + " pb on "
                + "(bt." + kdoc_field + " = pb." + kdoc_field + ") and (bt." + iddoc_field + " = pb." + iddoc_field + ") "
                + " join  " + mov + " ls on "
                + "(ls." + kdoc_field + " = pb." + kdoc_field + ") and (ls." + iddoc_field + " = pb." + iddoc_field + ") "
                + " WHERE " + QHS.AppAnd(QHS.CmpEq("bt.yban", rBanca["ESERC"]), QHS.CmpEq("ls.nbill", rBanca["NUMQUI"]),
                QHS.CmpEq("kind", tipoDoc))  + ") AS S";
                
			string errMsg;
			DataTable t = Meta.Conn.SQLRunner(qDb, -1, out errMsg);
			if ((t==null)||(t.Rows.Count==0)) {
				QueryCreator.ShowError(form, "Errore durante l'esecuzione della query:\r\n"+qDb, errMsg);
				return false;
			}
			importoCoperto += CfgFn.GetNoNullDecimal(t.Rows[0][0]);

            if (rPP.Length != 0)
            {
                decimal importoDaCoprire = (decimal)rPP[0]["total"];

                if (importoCoperto >= importoDaCoprire)
                {
                    rPP[0]["active"] = "N";
                }
                if ((importoCoperto < importoDaCoprire) && rBanca["SEGNO"].Equals("-"))
                {
                    rPP[0]["active"] = "S";
                }
            }
            //questo controllo va omesso in quanto unicredit non tiene minimamente conto della corrispondenza
            //tra importo di apertura della bolletta e somme delle righe di esito riferite a quella bolletta
            //non può essere quindi considerato come errore bloccante
            /*
            if (importoCoperto > importoDaCoprire)
            {
                string messaggio = rBanca["TIPDOC"].ToString() == "M"
                    ? "L'importo della partita pendente di pagamento ("
                    : "L'importo della partita pendente di incasso (";
                
                QueryCreator.ShowError(form, messaggio + rBanca["ESERC"]
                    + ", " + rBanca["NUMQUI"] + ") è minore della somma degli importi esitati",
                    "")
                return true;
            }*/
			return true;
		}


		private string aggiustaStringa(string stringa) {
			return stringa.Replace('Ç','c').Replace('ç','c').Replace('€','e').Replace('|',' ').Replace('\\',' ').Replace('£',' ').Replace('§',' ').Replace('@',' ').Replace('[',' ').Replace('#',' ').Replace('!',' ').Replace('Ù','u').Replace(
				'Ö','o').Replace('Ü','u').Replace('Ñ','n').Replace('Ð','d').Replace('Ê','e').Replace('Ë','e').Replace('Î','i').Replace('Ï','i').Replace('Ô','o').Replace('Õ','o').Replace('Û','u').Replace('Ý','y').Replace(
				']',' ').Replace('`',' ').Replace('{',' ').Replace('}',' ').Replace('~',' ').Replace('ü','u').Replace('â','a').Replace('ä','a').Replace('å','a').Replace('ê','e').Replace('ë','e').Replace('ï','i').Replace(
				'î','i').Replace('Ä','a').Replace('Å','a').Replace('ô','o').Replace('ö','o').Replace('û','u').Replace('ÿ','y').Replace('ñ','n').Replace('Â','a').Replace('¥','y').Replace('ã','a').Replace('Ã','a').Replace(
				'õ','o').Replace('ý','y').Replace('é','e').Replace('à','a').Replace('è','e').Replace('ì','i').Replace('ò','o').Replace('ù','u').Replace('á','a').Replace('í','i').Replace('ó','o').Replace('É','e').Replace(
				'Á','a').Replace('À','a').Replace('È','e').Replace('Í','i').Replace('Ì','i').Replace('Ó','o').Replace('Ò','o').Replace('Ú','u').Replace('\t',' ').Replace('\n',' ').Replace('\r',' ').Replace('°',' ');
		}



		public virtual DataTable getInfoMandati(object esercDocPagamento, object numDocPagamento) {
			string query = "SELECT s.ymov as ypay, sl.kpay, p.npay, sl.idpay, PRODOC = sl.idpay, NUMQUI=sl.nbill,"
				//SEMPRE DIVERSO				+ "INDREG=ISNULL(s.flagcopertura,'N'), "//flagcopertura
				+ "TPAGTS=m.methodbankcode, "//codicemodalitaCass
				+ "sCODABI=sl.idbank, "//codiceabi
				+ "sCODCAB=sl.idcab, "//codicecab
				+ "CONTO=REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(ISNULL(s.cc,''),',',''),'.',''),'_',''),'-',''),'*',''),'+',''),'/',''),':',''),';',''), "//contocorrente
				+ "CIN=ISNULL(sl.cin,''), "//cin
				+ "ANABE=ISNULL(c.title,''), "//denominazioneben
				+ "CFISC=CASE WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL THEN c.cf WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN REPLICATE('9',16) ELSE '' END, "//codicefiscaleben
				+ "CAUSALE=ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'') "//descpagamento
				+ "FROM expense s "	
                + "JOIN expenselast sl on s.idexp=sl.idexp "
                + "JOIN payment p on p.kpay = sl.kpay "
				+ "JOIN paymethod m ON (sl.idpaymethod = m.idpaymethod) "
				+ "JOIN registry c ON (c.idreg = s.idreg) "
				+ "JOIN registryclass ctc ON (ctc.idregistryclass = c.idregistryclass) "
				+ "WHERE (p.ypay = "+esercDocPagamento
				+ ") and (p.npay = "+numDocPagamento
				+ ") AND (sl.idpay is not null)";
			string errMsg;
			DataTable tInfo = Meta.Conn.SQLRunner(query, -1, out errMsg);
			if (tInfo == null) {
				QueryCreator.ShowError(form, "Errore durante l'esecuzione della query:\r\n"+query, errMsg);
			}
			tInfo.Columns.Add("CODABI", typeof(string));
			tInfo.Columns.Add("CODCAB", typeof(string));
			foreach (DataRow r in tInfo.Rows) {
				r["CODABI"] = r["sCODABI"];
				r["CODCAB"] = r["sCODCAB"];
			}
			return tInfo;
		}

		public virtual DataTable getInfoReversali(object esercDocIncasso, object numDocIncasso) {
			string query = "SELECT e.ymov as ypro, el.kpro, p.npro, el.idpro, PRODOC = el.idpro, TPAGTS='', CODABI=0, CODCAB=0, CONTO='', CIN='', NUMQUI=el.nbill,"
				+ "ANABE=ISNULL(c.title,''), "
				+ "CFISC=CASE WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL THEN c.cf WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN REPLICATE('9',16) ELSE '' END, "
				+ "CAUSALE=ISNULL(e.doc,'') + ISNULL(CONVERT(varchar(12),e.docdate),'') + ISNULL(e.description,'')"
				+ "FROM income e "
                + "JOIN incomelast el ON e.idinc=el.idinc "
                + "JOIN proceeds p ON p.kpro = el.kpro "
                + "JOIN registry c ON c.idreg = e.idreg "
				+ "JOIN registryclass ctc ON ctc.idregistryclass = c.idregistryclass "
				+ "WHERE p.ypro = "+esercDocIncasso
				+ " AND p.npro = "+numDocIncasso
				+ " AND el.idpro is not null";
			string errMsg;
			DataTable tInfo = Meta.Conn.SQLRunner(query, -1, out errMsg);
			if (tInfo == null) {
				QueryCreator.ShowError(form, "Errore durante l'esecuzione della query:\r\n"+query, errMsg);
			}
			return tInfo;
		}

        /// <summary>
        /// Metodo che verifica se un movimento bancario preso dal DB è somigliante a quello trasmesso dalla banca
        /// </summary>
        /// <param name="rMovimento">DataRow del movimento bancario da valutare</param>
        /// <param name="rBanca">DataRow del flusso bancario (riga di DS.flussobanca)</param>
        /// <param name="tInfo">Tabella dei movimenti finanziari (di entrata o di spesa a seconda del tipo documento)</param>
        /// <param name="tipoDoc">Tipo del documento</param>
        /// <returns>-1 Errore (Bloccante), 0 movimento uguale, > 0 movimento somigliante ma non uguale</returns>
		private int verificaMovimento(DataRow rMovimento, DataRow rBanca, DataTable tInfo, string tipoDoc) {

			string ydoc_field = (tipoDoc == "M") ? "ypay" : "ypro";
			string ndoc_field = (tipoDoc == "M") ? "npay" : "npro";
            string kdoc_field = (tipoDoc == "M") ? "kpay" : "kpro";
			string iddoc_field = (tipoDoc == "M") ? "idpay" : "idpro";
			// Sostituire questo controllo con un controllo sugli importi in quanto il flagesito non esiste più
//			string flagEsito = rMovimento["flagesito"].ToString();
//			if ((flagEsito != "N") && (flagEsito != "P")) {
//				QueryCreator.ShowError(form, "ERRORE INTERNO 6", "Tentativo di esitare un movimento bancario già esitato");
//				return -1;
//			}

            // Costruzione del filtro che seleziona i movimenti finanziari
			string queryMov = QHC.MCmp(rMovimento, new string [] {ydoc_field, ndoc_field, iddoc_field});
            
			DataRow[] tInfoMov = tInfo.Select(queryMov);

            // Se non ci sono movimenti finanziari che soddisfano il filtro si esce dal metodo ritornando -1
            // valore che indica errore. La procedura sarà terminata.
			string nomeMovimento = rBanca["TIPDOC"].ToString() == "M" ? "spesa" : "entrata";
			if (tInfoMov.Length == 0) {
				QueryCreator.ShowError(form, "Errore di incoerenza nei dati nel db", 
					"Impossibile trovare il movimento di "+nomeMovimento+" associato al movimento bancario ("
					+ rMovimento[ydoc_field]+","+rMovimento[ndoc_field]+")");
				return -1;
			}
            // Scelta dei campi sui quali verificare la somiglianza tra movimento del DB e quello presente nel flusso
            // Per tutte le banche si adoperano determinati campi, mentre per banca di Roma si ne adoperano altri.
            string[] campiCarime = { "PRODOC", "TPAGTS", "CFISC", "CODABI", "CODCAB", "CAUSALE", "ANABE" };
            string[] campiRoma = { "PRODOC", "TPAGTS", "CFISC", "CODABI", "CODCAB", "CONTO", "CIN", "CAUSALE", "ANABE" };
            string[] campiAltreBanche = { "PRODOC", "TPAGTS", "CFISC", "CODABI", "CODCAB", "CONTO", "CIN", "ANABE", "CAUSALE" };
            string[] campi = getBanca() == BANCA.ROMA ? campiRoma : campiAltreBanche;

			DataRow rInfo = tInfoMov[0];

            // Se si sta analizzando una regolarizzazione si verifica anche il campo dove è registrato il numero di bolletta (o quietanza)
			if (rBanca["INDREG"].ToString() == "R") {
				int numBollettaBanca = (int) rBanca["NUMQUI"];
				object onb = rInfo["NUMQUI"];
				if (onb != DBNull.Value) {
					int nb = (int) onb;
					if (nb == numBollettaBanca) {
						return 0;
					}
				}
			}
			
            // Si formatta il conto corrente
			string s = rInfo["CONTO"].ToString();
			if (s.Length <= 12) {
				s = s.PadLeft(12, '0');
			}
			if (s == "000000000000") {
				s = "            ";
			}
			rInfo["CONTO"] = s;

			if (tipoDoc!="M") {
				rInfo["TPAGTS"] = rBanca["TPAGTS"];
			}
			
	        // Per ogni campo presente nell'elenco prima definito, si verifica che i dati combacino
            // se tutti i campi sono uguali la procedura ritornerà zero, altrimenti ritornerà una distanza differente
            // dallo zero quanto più è prioritario il campo analizzato.
            // Esempio:
            // Supponiamo di importare dati da Unicredit. Se il campo "CAUSALE" è differente, verrà tornata una differenza alta
            // Se è differente "CFISC" la differenza sarà più bassa. Nel caso ci siano più movimenti che devono essere confrontati
            // il chiamante scarterà quelli con differenza maggiore scegliendo appunto il più "somigliante"
            //string allfield;
			for (int j=campi.Length-1; j>=0; j--) {
				string c = campi[j];
				if (!rInfo[c].Equals(rBanca[c])) {
					Type t1 = rInfo[c].GetType();
					Type t2 = rBanca[c].GetType();
					if (t1 != t2 && rInfo[c]!=DBNull.Value && rBanca[c]!=DBNull.Value) {
						QueryCreator.ShowError(form, "ERRORE INTERNO 8", "Tipo di dato "+c+" differente nel file rispetto al db\r\n"+t1+"\t"+t2+
                            " Valori:"+rInfo[c].ToString()+" e "+rBanca[c].ToString());
						return -1;
					}
					if (t1 == typeof(string)) {
						string aggiustata = aggiustaStringa(rInfo[c].ToString()).ToUpper();
						if (aggiustata.Equals(rBanca[c])) {
							continue;
						} else {
							return j+1;
						}
					}
					return j+1;
				}
			}
			return 0;
		}


		/// <summary>
		/// Metodo che calcola l'importo esitato di un movimento bancario
		/// </summary>
		/// <param name="rMovBancario">DataRow del movimento bancario su cui calcolare l'esitato</param>
		/// <returns>Importo Esitato</returns>
		private decimal calcolaEsitato(DataRow rMovBancario) {
            string tipoDoc = (rMovBancario.Table.TableName == "payment_bankview") ? "D" : "C";
			string filtro = QHC.CmpKey(rMovBancario);
            string filtroSQL = QHS.CmpKey(rMovBancario);
            DataRow[] rEsiti = fillEmptyBankTransactionFromDB(filtro, filtroSQL, tipoDoc);

			decimal importoEsitato = 0;
			foreach(DataRow rEsito in rEsiti) {
				importoEsitato += CfgFn.GetNoNullDecimal(rEsito["amount"]);
			}
			return importoEsitato;
		}

        /// <summary>
        /// Metodo che esita più movimenti bancari
        /// </summary>
        /// <param name="rBanca"></param>
        /// <param name="TIPDOC"></param>
        /// <param name="importoBanca"></param>
        /// <param name="tInfo"></param>
        /// <returns></returns>
		private bool esitaPiuMovimenti(DataRow rBanca, string TIPDOC, decimal importoBanca, DataTable tInfo) {
            // Sezione dichiarativa in base al tipo di documento
			string nomeDocumento = TIPDOC=="M" ? "il mandato" : "la reversale";
			string tipomovbancario = TIPDOC=="M" ? "D" : "C";
			string movBancario = TIPDOC == "M" ? "payment_bankview" : "proceeds_bankview";
			string ydoc_field = (TIPDOC == "M") ? "ypay" : "ypro";
			string ndoc_field = (TIPDOC == "M") ? "npay" : "npro";
			string iddoc_field = (TIPDOC == "M") ? "idpay" : "idpro";

            string filtroMovimenti = QHC.AppAnd(QHC.CmpEq(ydoc_field, rBanca["ESERC"]), 
                            QHC.CmpEq(ndoc_field, rBanca["NUMDOC"]));

			// Questo controllo lo commento, lo utilizzerò più in avanti in modo diverso
			//			if (rBanca["SEGNO"].ToString()=="+") {
			//				filtroMovimenti += " and amount>isnull(performed,0)";
			//			}

            // Elenco dei movimenti bancari sulla base del mandato o reversale (non si considera il progressivo)
			DataRow[] rMovimenti = DS.Tables[movBancario].Select(filtroMovimenti);

            int nRighe = rMovimenti.Length;
            bool esistonoMov = (nRighe > 0);
            if ((esistonoMov) && (rBanca["SEGNO"].ToString()=="+")) {
                foreach(DataRow rMovimento in rMovimenti) {

                    decimal totEsito = calcolaEsitato(rMovimento);
                    decimal importoMov = CfgFn.GetNoNullDecimal(rMovimento["amount"]);
                    if (importoMov <= totEsito) {
                        nRighe--;
                    }
                }
            }

             //Se non ci sono righe esci subito
            if (nRighe == 0) {
                if (!"R".Equals(rBanca["INDREG"])) {
                    QueryCreator.ShowError(form, "Non esistono movimenti bancari per "+nomeDocumento+" ("+rBanca["ESERC"]+","+rBanca["NUMDOC"]
                        +")\r\n\r\n"+erroreBloccante
                        , filtroMovimenti);
                    return false;
                }
                return true;
            }
            
			int minimaDifferenza = 100;
            decimal importoDisponibileMovBanSel = 0;
			DataRow rMovDaEsitare = null;
            int count = 0;
			//Vediamo se riesco ad esitare con un unico movimento
			foreach (DataRow rMovimento in rMovimenti) {
					
				decimal importo = CfgFn.GetNoNullDecimal(rMovimento["amount"]);
				decimal importoEsitato = calcolaEsitato(rMovimento);

                decimal importoDisponibile = importo - importoEsitato;
                if (rBanca["SEGNO"].ToString() == "+") {
                    if (importoBanca <= importoDisponibile) {
                        int differenza = verificaMovimento(rMovimento, rBanca, tInfo, TIPDOC);
                        if (differenza == -1) return false;
                        if (differenza == 0) {
                            decimal iEsitato;
                            //Capperi! Ho trovato sul db un movimento bancario corrispondente a quello della banca! Esito subito!
                            bool esitato = esitaUnMovimento(tipomovbancario, rMovimento, rBanca, importoDisponibile, importoBanca, out iEsitato);
                            //importoBanca = esitaUnMovimento(rMovimento, rBanca, importoBanca);
                            if (esitato) {
                                //if (importoBanca == 0) {
                                return true;
                            }
                        }
                        if (differenza < minimaDifferenza) {
                            minimaDifferenza = differenza;
                            rMovDaEsitare = rMovimento;
                            importoDisponibileMovBanSel = importoDisponibile;
                        }
                    }
                }
                else {
                    if (importoEsitato>0) {
                        int differenza = verificaMovimento(rMovimento, rBanca, tInfo, TIPDOC);
                        if (differenza == -1) return false;
                        if (differenza == 0) {
                            decimal iEsitato;
                            //Capperi! Ho trovato sul db un movimento bancario corrispondente a quello della banca! Esito subito!
                            bool esitato = esitaUnMovimento(tipomovbancario, rMovimento, rBanca, importoDisponibile, importoBanca, out iEsitato);
                            //importoBanca = esitaUnMovimento(rMovimento, rBanca, importoBanca);
                            if (esitato) {
                                //if (importoBanca == 0) {
                                return true;
                            }
                        }
                        if (differenza < minimaDifferenza) {
                            minimaDifferenza = differenza;
                            rMovDaEsitare = rMovimento;
                            importoDisponibileMovBanSel = importoDisponibile;
                            count = 1;
                        }
                        else{
                            if (differenza == minimaDifferenza) count++;
                        }
                    }

                }
			}
			//Mi accontento del movimento capiente con minima differenza
			if (minimaDifferenza<100 && count==1) {
                decimal iEsitato;
                return esitaUnMovimento(tipomovbancario, rMovDaEsitare, rBanca, importoDisponibileMovBanSel, importoBanca, out iEsitato);
				//return true;
			}
			//Siamo nei >1! Non riesco ad esitare l'intero importo in un unico movimento.
			//Allora esito a partire dai movimenti che più si assomigliano a quelli della banca
			Hashtable ht = new Hashtable();
			foreach (DataRow rMovimento in rMovimenti) {
				int differenza = verificaMovimento(rMovimento, rBanca, tInfo, TIPDOC);
				if (differenza==-1) return false;
				object movimenti = ht[differenza];
				ArrayList list;
				if (movimenti == null) {
					list = new ArrayList();
					ht[differenza] = list;
				} else {
					list = (ArrayList) movimenti;
				}
				list.Add(rMovimento);
			}
			ArrayList differenze = new ArrayList(ht.Keys);
			differenze.Sort();
            decimal residuoProgressivo = importoBanca;
			foreach (int diff in differenze) {
				ArrayList list = (ArrayList) ht[diff];
				foreach (DataRow rMovimento in list) {
                    decimal iEsitato;
                    esitaUnMovimento(tipomovbancario, rMovimento, rBanca, residuoProgressivo, importoBanca, out iEsitato);
                    if (rBanca["SEGNO"].ToString() == "+"){
                        residuoProgressivo -= iEsitato;
                    }
                    else{
                        residuoProgressivo += iEsitato;// Essendo l'importo da esitare negativo, dobbiamo aggiungerlo al Residuo per decrementarlo
                    }
					//importoBanca = esitaUnMovimento(rMovimento, rBanca, importoBanca);
					//if (importoBanca == 0) {
                    //if ((rBanca["SEGNO"].ToString()=="+")&&(residuoProgressivo == 0)) {
                    //    return true;
                    //}
                    if (residuoProgressivo == 0){
                        return true;
                    }
				}
			}
            //raiseError(rBanca);
			return false;
		}

        /// <summary>
        /// Metodo che mostra un messaggio di errore visualizzando i riferimenti presenti nella riga del flusso
        /// della banca
        /// </summary>
        /// <param name="rBanca"></param>
        private void raiseError(DataRow rBanca) {
            QueryCreator.ShowError(form, "Esitazione impossibile",
                "Impossibile esitare il seguente movimento bancario:"
                + "\r\nEsercizio: " + rBanca["ESERC"]
                + "\r\nTipo documento: " + rBanca["TIPDOC"]
                + "\r\nNumero documento: " + rBanca["NUMDOC"]
                + "\r\nProgressivo documento: " + rBanca["PRODOC"]
                + "\r\nNum. bolletta: " + rBanca["NUMQUI"]
                + "\r\nImporto: " + rBanca["IMPDOC"]
                + "\r\nBeneficiario: " + rBanca["ANABE"]
                + "\r\nCausale: " + rBanca["CAUSALE"]
                + "\r\n\r\n" + erroreBloccante);
        }

        /// <summary>
        /// Metodo che fa partire la procedura di esitazione automatica.
        /// </summary>
        /// <returns></returns>
		public bool esita(bool multibill) {
			DS.bill.Clear();
			DS.banktransaction.Clear();
			DS.payment_bankview.Clear();
			DS.proceeds_bankview.Clear();

			if (!eliminaStorni()) return false;
			if (!apriPartitePendenti(multibill)) return false;
          
            string filtroMandati = QHS.AppAnd(QHS.CmpEq("ypay", Meta.GetSys("esercizio")),
                QHS.FieldIn("npay", DS.flussobanca.Select("TIPDOC='M'"), "NUMDOC"));
            DataTable tMandati = Meta.Conn.RUN_SELECT("payment", "kpay", null, filtroMandati, null, true);
            string filtroMovSpesa = QHS.FieldIn("kpay", tMandati.Select());
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenseview, null, filtroMovSpesa, null, true);
            if (!esitaMandatiOReversali("M", "-")) return false;
            if (!esitaMandatiOReversali("M", "+")) return false;

            string filtroReversali = QHS.AppAnd(QHS.CmpEq("ypro", Meta.GetSys("esercizio")),
                QHS.FieldIn("npro", DS.flussobanca.Select("TIPDOC='R'"), "NUMDOC"));
            DataTable tReversali = Meta.Conn.RUN_SELECT("proceeds", "kpro", null, filtroReversali, null, true);
            string filtroMovEntrata = QHS.FieldIn("kpro", tReversali.Select());
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.incomeview, null, filtroMovEntrata, null, true);
            if (!esitaMandatiOReversali("R", "-")) return false;
            if (!esitaMandatiOReversali("R", "+")) return false;
           
            if (!StornaPartitePendenti()) return false;
			labelOperazione.Text = "Salvataggio dei dati";
			progressBar1.Value = 0;
			Application.DoEvents();
			string erroreSalvataggio = salva();
			if (erroreSalvataggio != null) {
				QueryCreator.ShowError(form, "Errore durante il salvataggio dei dati", erroreSalvataggio);
				return false;
			} else {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(form, "ESITAZIONE COMPLETATA!");
			}
			return true;
		}

        /// <summary>
        /// Metodo che apre le partite pendenti
        /// </summary>
        /// <param name="multibill">Se true ammette bolletta aperta più volte</param>
        /// <returns></returns>
		private bool apriPartitePendenti(bool multibill) {
            // Si selezionano le partite pendenti mediante il filtro seguente.
			DataRow[] rPartPend = DS.flussobanca.Select("TIPDOC in ('I','P') and SEGNO='+'");
			if (rPartPend.Length == 0) {
				return true;
			}
			labelOperazione.Text = "Apertura Partite pendenti";
			progressBar1.Maximum = rPartPend.Length;
			progressBar1.Value = 0;
			int lenBeneficiario = (int) Meta.Conn.DO_READ_VALUE("columntypes", "(tablename='bill') and (field='registry')", "col_len");
			int lenCausale = (int) Meta.Conn.DO_READ_VALUE("columntypes", "(tablename='bill') and (field='motive')", "col_len");
            // Ciclo sulle partite pendenti del flusso
			foreach (DataRow r in rPartPend) {
				string tipomovbancario = "P".Equals(r["TIPDOC"]) ? "D" : "C";
                string filtro = "";
                string filtrosql = "";
                filtro = QHC.AppAnd(QHC.CmpEq("nbill", r["NUMQUI"]),
                    QHC.CmpEq("billkind", tipomovbancario), QHC.CmpEq("ybill", r["ESERC"]));
                filtrosql = QHS.AppAnd(QHS.CmpEq("nbill", r["NUMQUI"]),
                    QHS.CmpEq("billkind", tipomovbancario), QHS.CmpEq("ybill", r["ESERC"]));
                if (DS.bill.Select(filtro).Length == 0) {
                    // Si riempie la tabella BILL (se la partita pendente è stata già inserita in passato)
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.bill, null, filtrosql, null, true);
                }
				object o = DS.bill.Compute("count(nbill)", filtro);
                // Se la partita pendente è già presente sul DB viene comunicato un messaggio di errore
                // che avvisa l'utente che la stessa non può essere aperta in quanto lo è già
                // stata in passato. Errore Bloccante - Procedura Stoppata
                if (DS.bill.Select(filtro).Length > 0 && !multibill) {
                    string tipoDoc = "";
                    switch (r["TIPDOC"].ToString()) {
                        case "M": tipoDoc = " (mandato di pagamento)"; break;
                        case "R": tipoDoc = " (reversale di incasso)"; break;
                        case "P": tipoDoc = " (partita pendente di pagamento)"; break;
                        case "I": tipoDoc = " (partita pendente di incasso)"; break;
                    }
                    QueryCreator.ShowError(form, "Impossibile aprire la partita pendente n° " + r["NUMQUI"]
                        + " in quanto risulta già aperta!",
                        "Esercizio bolletta: " + r["ESERC"]
                        + "\r\nTipo documento: " + r["TIPDOC"] + tipoDoc
                        + "\r\nNumero bolletta: " + r["NUMQUI"]
                        + "\r\nCassiere: " + ricavaDescrizioneCassiere(r["NCNT"])
                        + "\r\n\r\n" + erroreBloccante
                        + "\r\n\r\n" + filtro);
                    return false;
                }
                DataRow rPP = null;
                if (DS.bill.Select(filtro).Length > 0) {
                    rPP = DS.bill.Select(filtro)[0];
                    rPP["total"] = CfgFn.GetNoNullDecimal(rPP["total"]) + CfgFn.GetNoNullDecimal(r["IMPDOC"]);
                    string causale = rPP["motive"].ToString() + "," + r["CAUSALE"].ToString();
                    if (causale.Length <= lenCausale) {
                        rPP["motive"] = causale;
                    }
                }
                else {
                    // Creazione della partita pendente
                    metaPP.SetDefaults(DS.bill);
                    MetaData.SetDefault(DS.bill, "ybill", r["ESERC"]);
                    MetaData.SetDefault(DS.bill, "nbill", r["NUMQUI"]);
                    MetaData.SetDefault(DS.bill, "billkind", tipomovbancario);
                    rPP = metaPP.Get_New_Row(null, DS.bill);
                    rPP["adate"] = r["DTPAG"];
                    string beneficiario = r["ANABE"].ToString();
                    if (beneficiario.Length > lenBeneficiario) {
                        beneficiario = beneficiario.Substring(0, lenBeneficiario);
                    }
                    rPP["registry"] = beneficiario;
                    string causale = r["CAUSALE"].ToString();
                    if (causale.Length > lenCausale) {
                        causale = causale.Substring(0, lenCausale);
                    }
                    rPP["motive"] = causale;
                    rPP["total"] = r["IMPDOC"];
                    rPP["active"] = "S";
                    rPP["idtreasurer"] = ricavaCodiceCassiere(r["NCNT"]);
                }
                rPP["active"] = "S";

				progressBar1.Value ++;
				Application.DoEvents();
			}
			return true;
		}

        /// <summary>
        /// Metodo che chiude le partite pendenti precedentemente aperte.
        /// </summary>
        /// <returns></returns>
    private bool StornaPartitePendenti() {
            // In questo metodo si elaborano le righe relative alle partite pendenti
            // aventi segno negativo e si cerca di chiuderle oppure di decurtarne l'importo
            // se si tratta di storni parziali

            // Si estraggono le righe di chiusura di partite pendenti presenti nel flusso
            // in questo caso particolare andremo a gestire gli storni dell'importo 
            // di una bolletta quando l'importo risulta essere infeirore all'importo di apertura
            DataRow[] rPartPend = DS.flussobanca.Select("TIPDOC in ('I','P') and SEGNO='-'");
            labelOperazione.Text = "Storno Partite pendenti";
            progressBar1.Maximum = rPartPend.Length;
            progressBar1.Value = 0;
            foreach (DataRow r in rPartPend)
            {
                string tipomovbancario = "P".Equals(r["TIPDOC"]) ? "D" : "C";
                
                string filtroC = QHC.AppAnd(QHC.CmpEq("ybill", r["ESERC"]),
                    QHC.CmpEq("nbill", r["NUMQUI"]), QHC.CmpEq("billkind", tipomovbancario), QHC.CmpEq("active", "S"));
                string filtroSQL = QHS.AppAnd(QHS.CmpEq("ybill", r["ESERC"]),
                    QHS.CmpEq("nbill", r["NUMQUI"]), QHS.CmpEq("billkind", tipomovbancario), QHS.CmpEq("active", "S"));
                DataRow[] rPPAperte = DS.bill.Select(filtroC);
                if (rPPAperte.Length == 0)
                {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.bill, null, filtroSQL, null, true);
                    rPPAperte = DS.bill.Select(filtroC);
                }
                string tipoDoc = "";
                switch (r["TIPDOC"].ToString())
                {
                    case "P": tipoDoc = " (partita pendente di pagamento)"; break;
                    case "I": tipoDoc = " (partita pendente di incasso)"; break;
                }
                
                if (rPPAperte.Length != 1)
                {
                    // Commento il messaggio perchè le partite pendenti potrebbero essere state chiuse in virtù della
                    // esitazione e quindi non si tratta di una situazione di errore

                   /* QueryCreator.ShowError(form, "Trovato storno di un provvisorio non aperto; verrà ignorato.",
                        "\r\nEsercizio bolletta: " + r["ESERC"]
                        + "\r\nTipo documento: " + r["TIPDOC"]
                        + "\r\nNumero bolletta: " + r["NUMQUI"] + tipoDoc
                        + "\r\n\r\n"//+erroreBloccante
                        + filtroC);*/
                    continue; // elabora la riga successiva
                }


                // 1) STORNI TOTALI: controllo che non vi siano pagamenti o incassi a regolarizzazione associati a questa nel presente file
                // fa anche un controllo tra importo di apertura e importo di chiusura e se sono uguali le chiude
               
                string filterRegC = "TIPDOC in ('M','R') and SEGNO='+' and NUMQUI = " + r["NUMQUI"];
                DataRow[] DT = DS.flussobanca.Select(filterRegC);
                // posso chiudere la bolletta se l'importo di apertura e quello di chiusura coincidono
                if ((DT.Length == 0) && (CfgFn.GetNoNullDecimal(rPPAperte[0]["total"]) == - CfgFn.GetNoNullDecimal(r["IMPDOC"])))
                {
                    rPPAperte[0]["active"] = "N";
                }

                else
                {
                    // 2)STORNI PARZIALI: Potrebbe trattarsi di storno parziale dell'importo del provvisorio
                    // indipendentemente dalla presenza di eventuali regolarizzazioni. In questo caso dopo aver decurtato l'importo
                    // della bolletta potrebbe esserci un residuo del provvisorio da regolarizzare in futuro, in caso contrario si può chiudere
                    decimal totAmountPP = CfgFn.GetNoNullDecimal(rPPAperte[0]["total"]);
                    decimal rowAmount = - CfgFn.GetNoNullDecimal(r["IMPDOC"]); // l'importo è negativo
                    decimal totStornato = 0;
                    string  filterChiusure = QHC.AppAnd(
                                       QHC.CmpEq("TIPDOC", r["TIPDOC"]), QHC.CmpEq("SEGNO", "-"),
                                       QHC.CmpEq("NUMQUI", r["NUMQUI"]));

                    DataRow[] rBolletteChiuse = DS.flussobanca.Select(filterChiusure);
                    foreach (DataRow chiusura in rBolletteChiuse)
                    {
                        totStornato += CfgFn.GetNoNullDecimal(chiusura["IMPDOC"]);
                    }
                    totStornato = -totStornato; // l'importo è negativo
                    if (totAmountPP >= totStornato)
                    {
                        // Se dopo aver decurtato l'importo totale di tutte le righe di storno del presente file, 
                        // il residuo da regolarizzare è pari a zero, si può chiudere
                        if ((totAmountPP - totStornato) == 0)
                        {
                            rPPAperte[0]["active"] = "N";
                        }
                        // Altrimenti si storna il provvisorio trovato decurtando l'importo totale dell'importo della riga del file 
                        // attualmente elaborata se possibile
                        else
                        {
                            rPPAperte[0]["total"] = totAmountPP - rowAmount;
                        }
                    }
                    else
                    {
                        QueryCreator.ShowError(form, "Non è possibile procedere allo storno del provvisorio:",
                        "\r\nEsercizio bolletta: " + r["ESERC"]
                        + "\r\nTipo documento: " + r["TIPDOC"]
                        + "\r\nNumero bolletta: " + r["NUMQUI"] + tipoDoc
                        + "\r\n\r\n"
                        + filtroC);
                        return false;
                    }

                }
                progressBar1.Value++;
                Application.DoEvents();
        }
        return true;
        }
    
		public decimal leggiDecimaleRoma(TextReader tr, out string divisa, out string segno) {
			tr.Read(buffer, 0, 18);
			divisa = new string(buffer, 14, 3);
			segno = new string(buffer, 17, 1);
			decimal d = decimal.Parse(new string(buffer, 0, 14));
			if (segno == "-") {
				return -d;
			}
			return d;
		}

        public decimal leggiDecimaleCarime(TextReader tr, out string segno){
            tr.Read(buffer, 0, 16);

            decimal d = decimal.Parse(new string(buffer, 0, 15 - 2)
            + NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
            + new string(buffer, 15 - 2, 2));
            segno = new string(buffer, 15, 1);
            if (segno == "-")
            {
                return -d;
            }
            return d;
        }

		public bool completaParsing(DataGrid dataGrid1, TextBox txtInizioElaborazione, TextBox txtFineElaborazione) {
            if (!verificaAperturaProvvisori()) return false;
            DS.flussobanca.Columns["tipomovbancario"].Expression = "iif(TIPDOC in ('R','I'), 'C', 'D')";
			cambiaNomiAlleColonne();
			HelpForm.SetDataGrid(dataGrid1, DS.flussobanca);
			object ultimaEsitazioneSulDB = Meta.Conn.DO_READ_VALUE("banktransaction", QHS.CmpEq("yban", Meta.GetSys("esercizio")), 
                "max(transactiondate)");
			object minData = DS.flussobanca.Compute("min(DTPAG)", null);
			if (minData != DBNull.Value) {
				txtInizioElaborazione.Text = ((DateTime)minData).ToShortDateString();
			}
			object maxData = DS.flussobanca.Compute("max(DTPAG)", null);
			if (maxData != DBNull.Value) {
				txtFineElaborazione.Text = ((DateTime)maxData).ToShortDateString();
			}
			DateTime dDB = new DateTime();
			try {
				dDB = Convert.ToDateTime(ultimaEsitazioneSulDB);
			} catch (Exception) {
				Console.WriteLine(dDB);
			}
			object oFile = DS.flussobanca.Compute("min(DTPAG)", null);
			if (oFile is DateTime) {
				DateTime dFile = (DateTime) oFile;
				if (dFile <= dDB) {
                    string messError = "La data del primo movimento nel file scelto ("
                            + dFile.ToShortDateString()
                            + ") precede o coincide con l'ultima data di esitazione sul db ("
                            + dDB.ToShortDateString()
                            + ")";
                     bool IsAdmin = false;
                    if (Meta.GetSys("manage_prestazioni") != null) {
                        IsAdmin = (Meta.GetSys("manage_prestazioni").ToString().ToUpper() == "S");
                    }
                    if (getBanca() == BANCA.UNICREDIT)
                    {
                        IsAdmin = true; //  SOLO PER IL 31/12 CI PUò ESSERE SOVRAPPOSIZIONE
                    }
                    if (!IsAdmin) {
					    QueryCreator.ShowError(form, messError, "Probabilmente nel file sono contenuti movimenti bancari che erano stati già esitati."
						    + "\r\nScaricare nuovamente il file ponendo, come data di inizio, il giorno "+dDB.AddDays(1).ToShortDateString());
					    return false;
                    }
                    else {
                        if (MetaFactory.factory.getSingleton<IMessageShower>().Show( messError + "." + " Si desidera proseguire l''elaborazione se si è sicuri che non ci sia intersezione " +
                            " con i movimenti bancari già esitati ?","Errore",
				        MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) 
				            return true;
                        else
                            return false;
                    }
				}
			}
			return true;
		}


        public bool verificaAperturaProvvisori()
        {
            object ultimaAperturaProvvSulDB = Meta.Conn.DO_READ_VALUE("bill", QHS.CmpEq("ybill", Meta.GetSys("esercizio")),
                "max(adate)");
          
            DateTime dDB = new DateTime();
            try
            {
                dDB = Convert.ToDateTime(ultimaAperturaProvvSulDB);
            }
            catch (Exception)
            {
                Console.WriteLine(dDB);
            }
            object oFile = DS.flussobanca.Compute("min(DTPAG)", "TIPDOC in ('I','P') and SEGNO='+'");
            if (oFile is DateTime)
            {
                DateTime dFile = (DateTime)oFile;
                if (dFile <= dDB)
                {
                    string messError = "La data della prima apertura di provvisorio nel file scelto ("
                            + dFile.ToShortDateString()
                            + ") precede o coincide con l'ultima data di sul db ("
                            + dDB.ToShortDateString()
                            + ")";
                    //bool IsAdmin = false;
                    if (MetaFactory.factory.getSingleton<IMessageShower>().Show(messError + "." + " Si desidera proseguire l''elaborazione se si è sicuri che non ci sia intersezione " +
                       " con i provvisori già importati ?", "Errore",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }

        public enum BANCA {ROMA, UNICREDIT, MPS, CARIME};
        abstract public BANCA getBanca();
	}
}
