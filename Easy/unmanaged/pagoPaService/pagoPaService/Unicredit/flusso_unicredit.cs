
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


using metadatalibrary;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;

namespace Unicredit {

    public static class FlussoIncassi {


        public static string ElaboraUbi(string fileName, out DataTable tFlussoBanca) {
	        string all = File.ReadAllText(fileName,Encoding.UTF8);
            
            var sr= new StringReader(all);
	        //var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1048576);
	        //var sr= new StreamReader(fs, Encoding.Default);
            tFlussoBanca = generaStruttura();
            while (sr.Peek() != -1) {
                string err=null;
                               
                while (true) {
                    var rDett = tFlussoBanca.NewRow();
                    err = leggiRecordDiDettaglio(sr, rDett, "ubi");
                    if (err != null) {
	                    sr.Close();
	                    sr.Dispose();
	                    return err;
                    }
                    tFlussoBanca.Rows.Add(rDett);
                    if (sr.Peek() == -1) break;
                    leggiAlfanumerico(sr, 0, out err);
                    //tiprec = leggiIntestazioneRecord(sr,out err);
                    //if (err != null) return err;
                }

                if (sr.Peek() == -1) {
                    sr.Close();
                    sr.Dispose();
                    return null;
                }
            }
            return "Fine file inaspettata";
        }

        //override per vecchio metodo eventuali chiamate da esterno
        public static string Elabora(string fileName, bool withHeaderTail, out DataTable tFlussoBanca) {
            return ElaboraUnicredit(fileName, withHeaderTail, out tFlussoBanca);
        }

        public static string Elabora(string fileName, out DataTable tFlussoBanca) {  //usata da BPS su sdiftp in paymentService NINO: non è vero
	       

	        string all = File.ReadAllText(fileName,Encoding.UTF8);
	        var sr= new StringReader(all);
            
            tFlussoBanca = generaStruttura();
            while (sr.Peek() != -1) {
                var err = leggiRecordDiTesta(sr);
                if (err != null) return "Record di testa:"+ err; //Controllare che serva.
                var tiprec = leggiIntestazioneRecord(sr,out err);
                if (err != null) return err;
                while ((tiprec != "A") && (tiprec != "Z")) {
                    var rDett = tFlussoBanca.NewRow();
                    err = leggiRecordDiDettaglio(sr, rDett);
                    if (err != null) {
	                    sr.Close();
	                    sr.Dispose();
	                    return "Record di dettaglio:"+err;
                    }
                    tFlussoBanca.Rows.Add(rDett);
                    tiprec = leggiIntestazioneRecord(sr,out err);
                    if (err != null) {
	                    sr.Close();
	                    sr.Dispose();
	                    return "leggiIntestazioneRecord:"+err;
                    }
                }
                if (tiprec == "Z") {
                    sr.Close();
                    sr.Dispose();
                    return null;
                }
            }
            sr.Close();
            sr.Dispose();
            return "Fine file inaspettata";
        }

        public static bool IntestazionePresenteUnicredit(string fileName) {
	        string all = File.ReadAllText(fileName,Encoding.UTF8);
	        var sr= new StringReader(all);

	        while (sr.Peek() != -1) {
                string err = null;
                var tiprec = leggiIntestazioneRecord(sr, out err);
                sr.Close();
                sr.Dispose();
                if (tiprec == "A") 
                    return true;
                else
                    return false;
            }
            sr.Close();
            sr.Dispose();
            return false;
        }

        public static string Elabora(string fileName, bool withHeaderTail, out DataTable tFlussoBanca, string banca) {
            if (banca.ToLower()=="unicredit") {
                return ElaboraUnicredit(fileName, withHeaderTail, out tFlussoBanca);
            }
            return ElaboraUbi(fileName, out tFlussoBanca);
        }

        public static string ElaboraUnicredit(string fileName, bool withHeaderTail, out DataTable tFlussoBanca) {
	        string all = File.ReadAllText(fileName,Encoding.UTF8);
	        var sr= new StringReader(all);
            tFlussoBanca = generaStruttura();
            while (sr.Peek() != -1) {
                string err=null;
                if (withHeaderTail) {
                    err= leggiRecordDiTesta(sr);
                    if (err != null) {
	                    sr.Close();
	                    sr.Dispose();
	                    return "Record di testa:"+err; //Controllare che serva.
}
                }
                var tiprec = leggiIntestazioneRecord(sr,out err);
                if (err != null) {
	                sr.Close();
	                sr.Dispose();
	                return "leggiIntestazioneRecord:"+err; //Controllare che serva.
                }

                while ((tiprec != "A") && (tiprec != "Z") ) {
                    var rDett = tFlussoBanca.NewRow();
                    err = leggiRecordDiDettaglio(sr, rDett, "unicredit");
                    if (err != null) {
	                    sr.Close();
	                    sr.Dispose();
	                    return "leggiRecordDiDettaglio:"+err; 
                    }
                    tFlussoBanca.Rows.Add(rDett);
                    if (sr.Peek()==-1) break;
                    tiprec = leggiIntestazioneRecord(sr,out err);
                    if (err != null) {
	                    sr.Close();
	                    sr.Dispose();
	                    

	                    return "leggiIntestazioneRecord:"+err; 
                    }
                }

                if (tiprec == "Z" || sr.Peek()==-1) {
                    sr.Close();
                    sr.Dispose();
                    
                    return null;
                }
            }
            sr.Close();
            sr.Dispose();
            return "Fine file inaspettata";
        }

        //private static StreamReader getStreamReader(string fileName) {
        //    var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1048576);
        //    return new StreamReader(fs, Encoding.Default);
        //}

        private static DataTable generaStruttura() {
            var t = new DataTable("flussobanca");

            t.Columns.Add(new DataColumn("CABIRIC", typeof(int)));
            t.Columns.Add(new DataColumn("CSERV", typeof(int)));
            t.Columns.Add(new DataColumn("CSSERV", typeof(int)));
            t.Columns.Add(new DataColumn("CTIPSER", typeof(string)));
            t.Columns.Add(new DataColumn("CTIPFIL", typeof(string)));
            t.Columns.Add(new DataColumn("DCRE", typeof(DateTime)));
            t.Columns.Add(new DataColumn("NPRGFLS", typeof(int)));
            t.Columns.Add(new DataColumn("CODT", typeof(string)));
            t.Columns.Add(new DataColumn("IDTRS", typeof(string)));
            t.Columns.Add(new DataColumn("NPRGREC", typeof(int)));
            t.Columns.Add(new DataColumn("SOPE", typeof(string)));
            t.Columns.Add(new DataColumn("SRIFCRD", typeof(string)));
            t.Columns.Add(new DataColumn("CRIFCRD", typeof(string)));
            t.Columns.Add(new DataColumn("SRIFPRS", typeof(string)));
            t.Columns.Add(new DataColumn("CRIFPRS", typeof(string)));
            t.Columns.Add(new DataColumn("CIUV", typeof(string)));
            t.Columns.Add(new DataColumn("CKEY1", typeof(string)));
            t.Columns.Add(new DataColumn("CKEY2", typeof(string)));
            t.Columns.Add(new DataColumn("CKEY3", typeof(string)));
            t.Columns.Add(new DataColumn("CKEY4", typeof(string)));
            t.Columns.Add(new DataColumn("CKEY5", typeof(string)));
            t.Columns.Add(new DataColumn("CKEY6", typeof(string)));
            t.Columns.Add(new DataColumn("DSCA", typeof(DateTime)));
            t.Columns.Add(new DataColumn("IIMPVER", typeof(decimal)));
            t.Columns.Add(new DataColumn("IIMPDEB", typeof(decimal)));
            t.Columns.Add(new DataColumn("IIMPCRT", typeof(decimal)));
            t.Columns.Add(new DataColumn("IIMPCOM", typeof(decimal)));
            t.Columns.Add(new DataColumn("ZCAU", typeof(string)));
            t.Columns.Add(new DataColumn("SAVV", typeof(string)));
            t.Columns.Add(new DataColumn("SDATPA", typeof(string)));
            t.Columns.Add(new DataColumn("ZDATPA", typeof(string)));
            t.Columns.Add(new DataColumn("STIPVER", typeof(string)));
            t.Columns.Add(new DataColumn("SIDNVER", typeof(string)));
            t.Columns.Add(new DataColumn("CIDNVER", typeof(string)));
            t.Columns.Add(new DataColumn("ZANAVER", typeof(string)));
            t.Columns.Add(new DataColumn("IBANVER", typeof(string)));
            t.Columns.Add(new DataColumn("ZINDVER", typeof(string)));
            t.Columns.Add(new DataColumn("NCIVVER", typeof(string)));
            t.Columns.Add(new DataColumn("NCAPVER", typeof(string)));
            t.Columns.Add(new DataColumn("ZLOCVER", typeof(string)));
            t.Columns.Add(new DataColumn("ZPROVER", typeof(string)));
            t.Columns.Add(new DataColumn("ZSTAVER", typeof(string)));
            t.Columns.Add(new DataColumn("ZNOTVER", typeof(string)));
            t.Columns.Add(new DataColumn("NCELVER", typeof(string)));
            t.Columns.Add(new DataColumn("DDATPAG", typeof(DateTime)));
            t.Columns.Add(new DataColumn("DDATINC", typeof(DateTime)));
            t.Columns.Add(new DataColumn("CESE", typeof(int)));
            t.Columns.Add(new DataColumn("NPRO", typeof(int)));
            t.Columns.Add(new DataColumn("CRTE", typeof(string)));
            t.Columns.Add(new DataColumn("CCNL", typeof(string)));
            t.Columns.Add(new DataColumn("CSTR", typeof(string)));
            t.Columns.Add(new DataColumn("NBOLIVV", typeof(string)));
            t.Columns.Add(new DataColumn("IIMPPAG", typeof(decimal)));
            t.Columns.Add(new DataColumn("CTIPPAG", typeof(string)));
            t.Columns.Add(new DataColumn("CCNTPAG", typeof(string)));
            t.Columns.Add(new DataColumn("ICOMPA", typeof(decimal)));
            t.Columns.Add(new DataColumn("ICOMVER", typeof(decimal)));
            t.Columns.Add(new DataColumn("CBICADD", typeof(string)));
            t.Columns.Add(new DataColumn("SALTPAG", typeof(string)));
            t.Columns.Add(new DataColumn("SSOLPAG", typeof(string)));
            t.Columns.Add(new DataColumn("ZEMLPAG", typeof(string)));
            t.Columns.Add(new DataColumn("ZINDPST1", typeof(string)));
            t.Columns.Add(new DataColumn("ZINDPST2", typeof(string)));
            t.Columns.Add(new DataColumn("ZINDPST3", typeof(string)));
            t.Columns.Add(new DataColumn("ZINDPST4", typeof(string)));
            t.Columns.Add(new DataColumn("ZINDPST5", typeof(string)));
            t.Columns.Add(new DataColumn("NCCP", typeof(int)));
            t.Columns.Add(new DataColumn("FILLER", typeof(string)));

            return t;
        }

        private static string vaiACapo(TextReader tr) {
            var buffer = new char[2];
            if (tr.Read(buffer, 0, 2) != 2) {
                return "ERRORE DURANTE LA LETTURA DEL FILE: Letti meno byte rispetto al previsto";                
            }
            //var utf8 = Encoding.UTF8;
            //byte[] utfBytes = utf8.GetBytes(buffer);
            //if ((utfBytes[0] != 0x0a) || (utfBytes[1] != 0x0d)) {
            //    return $"ERRORE DURANTE LA LETTURA DEL FILE : Manca l'interruzione di riga (trovato {utfBytes[0]} {utfBytes[0]} utf16 {buffer[0]} {buffer[1]})";
            //}

            if ((buffer[0] != 0x0D) || (buffer[1] != 0x0A)) {
	            return $"ERRORE DURANTE LA LETTURA DEL FILE : Manca l'interruzione di riga (trovato {buffer[0]} {buffer[0]} ";
            }
            return null;
        }

        private static string leggiAlfanumerico(TextReader tr, int numCifre, out string err) {
            err = null;
            var buffer = new char[numCifre];
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                err= "ERRORE DURANTE LA LETTURA DEL FILE: Letti meno byte rispetto al previsto";
            }
            return new string(buffer, 0, numCifre).Trim();
        }

        private static int leggiNumerico(TextReader tr, int numCifre, out string err) {
            err = null;
            var buffer = new char[numCifre];
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                err= "ERRORE DURANTE LA LETTURA DEL FILE: Letti meno byte rispetto al previsto";
            }
            string s = new string(buffer, 0, numCifre);
            try {
                return int.Parse(s);
            }
            catch (Exception e) {
                string spazi = "".PadRight(numCifre);
                if (s != spazi) {
                   err= "ERRORE DURANTE LA LETTURA DI UN NUMERICO DAL FILE\r\n" + s+" "+ e;
                    return 0;
                }
                return 0;
            }
        }

        private static decimal leggiDecimale(TextReader tr, int numCifre, out string err) {
            err = null;
            var buffer = new char[numCifre];
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                err = "ERRORE DURANTE LA LETTURA DEL FILE: Letti meno byte rispetto al previsto";
                return 0;
            }
            string s = new string(buffer, 0, numCifre - 2)
                + NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator
                + new string(buffer, numCifre - 2, 2);
            return decimal.Parse(s);
        }

        private static object leggiDataAmg(TextReader tr, int numCifre, out string err) {
            err = null;
            var buffer = new char[numCifre];
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                err = "ERRORE DURANTE LA LETTURA DEL FILE: Letti meno byte rispetto al previsto";
            }
            string s = new string(buffer, 0, numCifre);
            try {
                return DateTime.ParseExact(s, "yyyyMMdd", DateTimeFormatInfo.CurrentInfo);
            }
            catch (Exception e) {
                if (new string(buffer, 0, numCifre) != "".PadRight(numCifre, '0')) {
                    err = "ERRORE DURANTE LA LETTURA DEL FILE: DATA AMG\r\n" + s + " " + e;
                }
                
                return DBNull.Value;
            }
        }

        private static string leggiRecordDiTesta(TextReader tr) {
            string err;
            leggiAlfanumerico(tr, 2000, out err);
            return err ?? vaiACapo(tr);
        }

        private static string leggiIntestazioneRecord(TextReader tr, out string err) {
            return leggiAlfanumerico(tr, 1,out err); // Tipo record  
        }

        private static string leggiRecordDiDettaglio(TextReader tr, DataRow r, string banca = "unicredit") {
            string err;
            //Ha già letto il primo carattere, per controllare se fosse un Record di Testa o di cosa, per cui
            if (banca.ToLower()=="unicredit") {
                //Per CABIRIC dobbiamo leggere 4 caratteri, e non 5, tanto è un campo a valore costante che non ci serve.
                r["CABIRIC"] = leggiNumerico(tr, 4,out err);        //len:	5	NUMERICO 	int:	5	 dec:	0	OBB	Codice Abi Istituto, deve essere uguale a quello indicato nel record di testa 
            } else {
                r["CABIRIC"] = leggiNumerico(tr, 5,out err);        //len:	5	NUMERICO 	int:	5	 dec:	0	OBB	Codice Abi Istituto, deve essere uguale a quello indicato nel record di testa 
            }
            if (err != null) return err;
            r["CSERV"] = leggiAlfanumerico(tr, 7, out err);      //len:	7	NUMERICO 	int:	7	 dec:	0	OBB	Codice Cliente censito sulla Piattaforma  Incassi ed attribuito alla PA, deve essere uguale a quello indicato nel record di testa   
            if (err != null) return err;
            r["CSSERV"] = leggiAlfanumerico(tr, 7, out err);     //len:	7	NUMERICO 	int:	7	 dec:	0		Codice Servizio d’incasso censito sulla Piattaforma Incassi, non deve essere indicato dalla PA in quanto  recuperato in fase di upload del flusso dalla macro di normalizzazione, qualora indicato dalla PA, sarà soggetto a controlli (presenza del dato nella Piattaforma Incassi)
            if (err != null) return err;
            r["CTIPSER"] = leggiAlfanumerico(tr, 3, out err);    //len:	3	CARATTERE						Codice Modello Operativo utilizzato per configurare il servizio d’incasso, non deve essere indicato dalla PA in quanto  recuperato in fase di upload del flusso in base al Servizio d’Incasso, qualora indicato dalla PA, sarà soggetto a controlli (presenza del dato nella Piattaforma Incassi)
            if (err != null) return err;
            r["CTIPFIL"] = leggiAlfanumerico(tr, 8, out err);    //len:	8	CARATTERE					OBB	Codice Tipo Flusso censito ed associato al servizio d’incasso (es. “MASTER0C0”, “MENSA0C0”), deve essere uguale a quello indicato nel record di testa  
            if (err != null) return err;
            r["DCRE"] = leggiDataAmg(tr, 8, out err);            //len:	8	NUMERICO 	int:	8	 dec:	0	OBB	Data Creazione Flusso, deve essere uguale a quella indicata nel record di testa (formato SSAAMMGG)
            if (err != null) return err;
            r["NPRGFLS"] = leggiNumerico(tr, 11, out err);       //len:	11	NUMERICO 	int:	11	 dec:	0		Numero progressivo d’invio flusso, la PA lo può indicare nel caso in cui volesse avere e tenere traccia della progressività dei flussi inviati giornalmente, qualora indicato dalla PA, sarà soggetto a controlli (congruenza della progressività dei flussi rispetto alla data creazione)
            if (err != null) return err;
            r["CODT"] = leggiAlfanumerico(tr, 2, out err);       //len:	2	CARATTERE						Canale trasmissione, non deve essere indicato dalla PA, di default assume valore ‘BT’ (Batch), attualmente su tale campo non viene effettuato nessun controllo
            if (err != null) return err;
            r["IDTRS"] = leggiAlfanumerico(tr, 26, out err);     //len:	26	CARATTERE						Identificativo trasmissione attribuito dalla Piattaforma Incassi in fase di acquisizione ed elaborazione del flusso, non deve essere indicato dalla PA pena lo scarto del record 
            if (err != null) return err;
            r["NPRGREC"] = leggiNumerico(tr, 13, out err);       //len:	13	NUMERICO 	int:	13	 dec:	0	OBB	Numero progressivo record all’interno del flusso, deve essere congruente rispetto alla progressività dei record presenti nel flusso
            if (err != null) return err;
            r["SOPE"] = leggiAlfanumerico(tr, 3, out err);       //len:	3	CARATTERE					OBB	TIPO OPERAZIONE. IN FASE DI ACQUISIZIONE:INS = INSERIMENTO POSIZIONE, CAN = CANCELLAZIONE LOGICA POSIZIONE, IN FASE DI RENDICONTAZIONE: RIS = RISCOSSIONE, RIV = RIVERSATO (PER RICONCILIAZIONE FINANZIARIO, OVVERO CON I PROVVISORI D’ENTRATA ASSOCIATI)
            if (err != null) return err;
            r["SRIFCRD"] = leggiAlfanumerico(tr, 35, out err);   //len:	35	CARATTERE					OBB	Tipo Riferimento Creditore/PA                             (ES. “AVVISO”, “FATTURA”, “BOLLETTA”, “VERBALE”), rappresenta,  in abbinamento con il campo successivo, la chiave/identificativo univoco della posizione debitoria sul repository della Piattaforma Incassi 
            if (err != null) return err;
            r["CRIFCRD"] = leggiAlfanumerico(tr, 35, out err);   //len:	35	CARATTERE					OBB	Codice Riferimento Creditore (codice/identificativo che si riferisce al campo precedente), rappresenta, in abbinamento con il campo precedente, la chiave/identificativo univoco della posizione debitoria sul repository della Piattaforma Incassi
            if (err != null) return err;
            r["SRIFPRS"] = leggiAlfanumerico(tr, 6, out err);    //len:	6	CARATTERE						Tipo Riferimento Presentatore/Debitore (ES. “AVVISO”), deve essere valorizzato, pena lo scarto del record, dalla PA qualora la generazione del N.Avviso/IUV sia a proprio carico, attualmente la Piattaforma Incassi effettua solo un controllo sulla presenza del dato 
            if (err != null) return err;
            r["CRIFPRS"] = leggiAlfanumerico(tr, 35, out err);   //len:	35	CARATTERE						Codice Identificativo Presentatore, deve essere valorizzato, pena lo scarto del record,  dalla PA qualora la generazione del N.Avviso (che implica anche la generazione dell’IUV) sia a proprio carico, la Piattaforma Incassi effettua un controllo di congruenza con il campo successivo (IUV) rispetto alla regole definite dalle Linee Guida Agid, ovvero l’IUV deve essere preceduta da tre cifre rappresentate dall’aux digit (1 cifra- sempre ‘0’) e application code (2 cifre) censite in anagrafica della Piattaforma Incassi a livello di Servizio
            if (err != null) return err;
            r["CIUV"] = leggiAlfanumerico(tr, 35, out err);      //len:	35	CARATTERE						Identificativo Univoco Versamento (ultimi 15 caratteri del campo precedente relativo al N. Avviso), deve essere valorizzato, pena lo scarto del record, dalla PA qualora la generazione dell’IUV (che implica anche la generazione del N. Avviso) sia a proprio carico, la Piattaforma Incassi verifica che tale campo sia rappresentato dalle ultime 15 cifre del campo precedente (N. Avviso)
            if (err != null) return err;
            r["CKEY1"] = leggiAlfanumerico(tr, 35, out err);     //len:	35	CARATTERE						Valore Chiave ID 1, Identificativo custom che può essere determinato in fase di configurazione dell’IPRS  all’interno della Piattaforma Incassi e che può essere utilizzato come Chiave di ricerca di Back Office  (valore modello operativo standard “Rata”)
            if (err != null) return err;
            r["CKEY2"] = leggiAlfanumerico(tr, 35, out err);     //len:	35	CARATTERE						Valore Chiave ID 2 (vedere specifiche CKEY1) (valore modello operativo standard “Id. Lotto”, può essere utilizzato per la bollettazione del File Lotto)
            if (err != null) return err;
            r["CKEY3"] = leggiAlfanumerico(tr, 35, out err);     //len:	35	CARATTERE						Valore Chiave ID 3 (vedere specifiche CKEY1) (valore modello operativo standard “Codice Lotto”, può essere utilizzato per la bollettazione del File Lotto )
            if (err != null) return err;
            r["CKEY4"] = leggiAlfanumerico(tr, 35, out err);     //len:	35	CARATTERE						Valore Chiave ID 4 (vedere specifiche CKEY1) (valore modello operativo standard “Id. Utenza”, può essere utilizzato per indicare il codice debitore così come conosciuto dalla PA)
            if (err != null) return err;
            r["CKEY5"] = leggiAlfanumerico(tr, 35, out err);     //len:	35	CARATTERE						Valore Chiave ID 5 (vedere specifiche CKEY1) (valore modello operativo standard “Identificativo 1”, può essere utilizzato per indicare un identificativo generico utile alla PA per particolari esigenze rispetto a quel determinato servizio d’incasso)
            if (err != null) return err;
            r["CKEY6"] = leggiAlfanumerico(tr, 35, out err);     //len:	35	CARATTERE						Valore Chiave ID 6 (vedere specifiche CKEY1) (valore modello operativo standard “Identificativo 2”, può essere utilizzato per indicare un identificativo generico utile alla PA per particolari esigenze rispetto a quel determinato servizio d’incasso)
            if (err != null) return err;
            r["DSCA"] = leggiDataAmg(tr, 8, out err);            //len:	8	NUMERICO 	int:	8	 dec:	0	OBB	DATA SCADENZA, deve essere una data valida, in ottica Nodo dei Pagamenti la data rappresenta un dato obbligatorio ed in caso di pagamento post data scadenza il Nodo non consente il pagamento (formato SSAAMMGG)
            if (err != null) return err;
            r["IIMPVER"] = leggiDecimale(tr, 15, out err);       //len:	15	NUMERICO 	int:	13	 dec:	2	OBB	Importo Totale Versamento
            if (err != null) return err;
            r["IIMPDEB"] = leggiDecimale(tr, 15, out err);       //len:	15	NUMERICO 	int:	13	 dec:	2		Importo a debito, non deve essere valorizzato dalla PA, attualmente non è previsto nessun controllo dalla Piattaforma Incassi 
            if (err != null) return err;
            r["IIMPCRT"] = leggiDecimale(tr, 15, out err);       //len:	15	NUMERICO 	int:	13	 dec:	2		Importo a credito, non deve essere valorizzato dalla PA, attualmente non è previsto nessun controllo dalla Piattaforma Incassi
            if (err != null) return err;
            r["IIMPCOM"] = leggiDecimale(tr, 15, out err);       //len:	15	NUMERICO 	int:	13	 dec:	2		Importo commissioni, non deve essere valorizzato dalla PA, attualmente non è previsto nessun controllo dalla Piattaforma Incassi 
            if (err != null) return err;
            r["ZCAU"] = leggiAlfanumerico(tr, 140, out err);     //len:	140	CARATTERE					OBB	Causale Versamento
            if (err != null) return err;
            r["SAVV"] = leggiAlfanumerico(tr, 3, out err);       //len:	3	CARATTERE						Tipologia Avvisatura.Valorizzare come concordato in sede di attivazione del servizio. Possibili valori:SE,PO,PM,SS,RS,RR,AG,DE,EM
            if (err != null) return err;
            r["SDATPA"] = leggiAlfanumerico(tr, 3, out err);     //len:	3	CARATTERE						Tipologia Dato PA:0 = Capitolo e articolo di entrata del bilancio dello Stato,1 = Numero della contabilità speciale, 2 = Codice SIOPE, 9 = Altro codice ad uso dell'ente creditore
            if (err != null) return err;
            r["ZDATPA"] = leggiAlfanumerico(tr, 50, out err);    //len:	50	CARATTERE						Dato PA,Rappresenta l'indicazione dell'imputazione della specifica entrata a fronte della Tipologia Dato PA indicato nel campo precedente (Tale dato obbligatorio per Il Nodo dei Pagamenti ai fini dell’emissione RPT è presente a livello di configurazione del Servizio, pertanto, occorre valorizzare il dato sull’IPRS solo nel caso di eccezione rispetto a quello presente in anagrafica della Piattaforma Incassi a livello di Servizio)   
            if (err != null) return err;
            r["STIPVER"] = leggiAlfanumerico(tr, 3, out err);    //len:	3	CARATTERE						Tipologia  Versante:‘F’ = Persona Fisica,‘G’ = Persona Giuridica
            if (err != null) return err;
            r["SIDNVER"] = leggiAlfanumerico(tr, 2, out err);    //len:	2	CARATTERE					OBB	Tipo Id Versante:‘CF ‘ = CODICE FISCALE (default in caso la PA non indichi nulla),‘PI’ = PARTITA IVA
            if (err != null) return err;
            r["CIDNVER"] = leggiAlfanumerico(tr, 35, out err);   //len:	35	CARATTERE					OBB	Codice Id Versante:Campo alfanumerico che può contenere il codice fiscale o, in alternativa, la partita IVA del soggetto pagatore. Quando non è possibile identificare fiscalmente il soggetto, può essere utilizzato il valore "ANONIMO"
            if (err != null) return err;
            r["ZANAVER"] = leggiAlfanumerico(tr, 50, out err);   //len:	50	CARATTERE					OBB	Anagrafica Versante.Campo alfanumerico che può contenere l’anagrafica del soggetto pagatore. Quando non è possibile identificare fiscalmente il soggetto, può essere utilizzato il valore "ANONIMO"
            if (err != null) return err;
            r["IBANVER"] = leggiAlfanumerico(tr, 35, out err);   //len:	35	CARATTERE						IBAN Addebito Versante per l’eventuale addebito in conto
            if (err != null) return err;
            r["ZINDVER"] = leggiAlfanumerico(tr, 50, out err);   //len:	50	CARATTERE						Indirizzo Versante, nessun controllo da parte della piattaforma incassi
            if (err != null) return err;
            r["NCIVVER"] = leggiAlfanumerico(tr, 5, out err);    //len:	5	CARATTERE						Numero Civico Versante, nessun controllo da parte della piattaforma incassi
            if (err != null) return err;
            r["NCAPVER"] = leggiAlfanumerico(tr, 5, out err);    //len:	5	CARATTERE						Numero CAP Versante, nessun controllo da parte della piattaforma incassi
            if (err != null) return err;
            r["ZLOCVER"] = leggiAlfanumerico(tr, 50, out err);   //len:	50	CARATTERE						Localita’ Versante, nessun controllo da parte della piattaforma incassi
            if (err != null) return err;
            r["ZPROVER"] = leggiAlfanumerico(tr, 2, out err);    //len:	2	CARATTERE						Provincia Versante, nessun controllo da parte della piattaforma incassi
            if (err != null) return err;
            r["ZSTAVER"] = leggiAlfanumerico(tr, 35, out err);   //len:	35	CARATTERE						Stato Versante, nessun controllo da parte della piattaforma incassi
            if (err != null) return err;
            r["ZNOTVER"] = leggiAlfanumerico(tr, 35, out err);   //len:	35	CARATTERE						Note Versante, nessun controllo da parte della piattaforma incassi
            if (err != null) return err;
            r["NCELVER"] = leggiAlfanumerico(tr, 35, out err);   //len:	35	CARATTERE						Cellulare Versante, nessun controllo da parte della piattaforma incassi
            if (err != null) return err;
            r["DDATPAG"] = leggiDataAmg(tr, 8, out err);         //len:	8	NUMERICO 	int:	8	 dec:	0		Data effettivo pagamento da parte del Versante, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record(formato SSAAMMGG)
            if (err != null) return err;
            r["DDATINC"] = leggiDataAmg(tr, 8, out err);         //len:	8	NUMERICO 	int:	8	 dec:	0		Data di registrazione dell’incasso sulla Piattaforma Incassi, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record(formato SSAAMMGG)
            if (err != null) return err;
            r["CESE"] = leggiNumerico(tr, 4, out err);           //len:	4	NUMERICO 	int:	4	 dec:	0		Esercizio di riferimento del provvisorio di Tesoreria associato all’incasso, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione del riconciliato (SOPE = ’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["NPRO"] = leggiNumerico(tr, 7, out err);           //len:	7	NUMERICO 	int:	7	 dec:	0		Numero del provvisorio della Procedura di Tesoreria, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione del riconciliato (SOPE = ’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["CRTE"] = leggiAlfanumerico(tr, 3, out err);       //len:	3	CARATTERE						Codice Rete d’incasso(ES. ‘UNI’ = UNICREDIT, ‘NDP’ = NODO DEI PAGAMENTI), dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["CCNL"] = leggiAlfanumerico(tr, 3, out err);       //len:	3	CARATTERE						Codice Canale d’incasso(ES. ‘ATM’ = ATM, ‘SPO’ = SPORTELLO, ‘WEB’ = INTERNET BANKING, ‘NDP’ = NODO DEI PAGAMENTI), dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record  
            if (err != null) return err;
            r["CSTR"] = leggiAlfanumerico(tr, 3, out err);       //len:	3	CARATTERE						Codice Strumento d’incasso(ES. ’ADC’ = ADDEBITO IN CONTO, ‘CON’ = CONTANTI, ‘NDP’ = NODO DEI PAGAMENTI), dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["NBOLIVV"] = leggiAlfanumerico(tr, 13, out err);       //len:	13	NUMERICO 	int:	13	 dec:	0		Numero Bolletta interno alla Piattaforma Incassi, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["IIMPPAG"] = leggiDecimale(tr, 15, out err);       //len:	15	NUMERICO 	int:	13	 dec:	2		Importo Pagato, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["CTIPPAG"] = leggiAlfanumerico(tr, 3, out err);    //len:	3	CARATTERE						Tipo ID Canale di pagamento (Es. ‘ATM’, ‘SPO’, ‘WEB’, ‘NDP’), dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["CCNTPAG"] = leggiAlfanumerico(tr, 50, out err);    //len:	50	CARATTERE						ID Canale di pagamento, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["ICOMPA"] = leggiDecimale(tr, 15, out err);        //len:	15	NUMERICO 	int:	13	 dec:	2		Importo Commissione a carico PA, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["ICOMVER"] = leggiDecimale(tr, 15, out err);       //len:	15	NUMERICO 	int:	13	 dec:	2		Importo Commissione a carico Versante, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["CBICADD"] = leggiAlfanumerico(tr, 11, out err);   //len:	11	CARATTERE						BIC Addebito Debitore per l’eventuale addebito in conto
            if (err != null) return err;
            r["SALTPAG"] = leggiAlfanumerico(tr, 3, out err);    //len:	3	CARATTERE						Tipo Alert Pagatore:‘E-M’ = E-mail, ‘PEC’ = PEC, ‘SMS’ =SMS
            if (err != null) return err;
            r["SSOLPAG"] = leggiAlfanumerico(tr, 3, out err);    //len:	3	CARATTERE						Tipo Sollecito Pagatore:‘E-M’ = E-mail, ‘PEC’ = PEC,‘SMS’ = SMS
            if (err != null) return err;
            r["ZEMLPAG"] = leggiAlfanumerico(tr, 120, out err);  //len:	120	CARATTERE						E-MAIL/PEC Pagatore, nessun controllo da parte della Piattaforma Incassi
            if (err != null) return err;
            r["ZINDPST1"] = leggiAlfanumerico(tr, 50, out err);  //len:	50	CARATTERE						Indirizzo Postale 1, nessun controllo da parte della Piattaforma Incassi
            if (err != null) return err;
            r["ZINDPST2"] = leggiAlfanumerico(tr, 50, out err);  //len:	50	CARATTERE						Indirizzo Postale 2, nessun controllo da parte della Piattaforma Incassi
            if (err != null) return err;
            r["ZINDPST3"] = leggiAlfanumerico(tr, 50, out err);  //len:	50	CARATTERE						Indirizzo Postale 3, nessun controllo da parte della Piattaforma Incassi
            if (err != null) return err;
            r["ZINDPST4"] = leggiAlfanumerico(tr, 50, out err);  //len:	50	CARATTERE						Indirizzo Postale 4, nessun controllo da parte della Piattaforma Incassi
            if (err != null) return err;
            r["ZINDPST5"] = leggiAlfanumerico(tr, 50, out err);  //len:	50	CARATTERE						Indirizzo Postale 5, nessun controllo da parte della Piattaforma Incassi
            if (err != null) return err;
            r["NCCP"] = leggiNumerico(tr, 12, out err);          //len:	12	NUMERICO						Numero CCP qualora la PA voglia ricevere in unico flusso anche la rendicontazione dei pagamenti effettuati sui CCP, dato trasmesso dalla Piattaforma Incassi alla PA in fase di rendicontazione sia del riscosso che del riconciliato (SOPE = ‘RIS’/’RIV’), pertanto, la PA non lo deve valorizzare in fase di invio del flusso pena lo scarto del record
            if (err != null) return err;
            r["FILLER"] = leggiAlfanumerico(tr, 399, out err);   //len:	399	CARATTERE						Campo a disposizione
            if (err != null) return err;
            return vaiACapo(tr);
        }

        private static string leggiRecordDiCoda(TextReader tr) {
            string err;
            leggiAlfanumerico(tr, 2000, out err);
            return err ?? vaiACapo(tr);
        }

    }

}
