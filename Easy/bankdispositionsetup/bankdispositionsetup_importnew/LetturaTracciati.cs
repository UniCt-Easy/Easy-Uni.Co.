
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


using System;
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using System.IO;
using funzioni_configurazione;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using System.Collections;

namespace bankdispositionsetup_importnew {
    
    public abstract class LetturaTracciati {
        string erroreBloccante = "L'elaborazione del file verrà annullata. Si prega di contattare la banca segnalando i riferimenti succitati";
        char[] buffer = new char[503];
        public vistaForm DS = new vistaForm();

        protected CQueryHelper QHC;
        QueryHelper QHS;
        protected DataAccess Conn;
        Form form = null;

        public LetturaTracciati(DataAccess Conn) {
            this.Conn=Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            PostData.MarkAsTemporaryTable(DS.flussobanca, false);
        }

        public int leggiNumerico(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(null, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            string s = new string(buffer, 0, numCifre);
            try {
                return int.Parse(s);
            }
            catch (Exception e) {
                string spazi = "".PadRight(numCifre);
                if (s != spazi) {
                    QueryCreator.ShowException(null, "ERRORE DURANTE LA LETTURA DI UN NUMERICO DAL FILE\r\n" + s, e);
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
            }
            catch (Exception e) {
                QueryCreator.ShowException(form, "ERRORE DURANTE LA LETTURA DI UN LONG DAL FILE\r\n" + s, e);
            }
            return 0;
        }

        public decimal leggiDecimale(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            string s = new string(buffer, 0, numCifre);
            return  decimal.Parse(s,NumberStyles.Currency)/100m;
        }

        public string leggiSegnoConDecimaleAoD(TextReader tr, int numCifre, out decimal decimale) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            if (buffer[0] != 'A' && buffer[0] != 'D') {
                QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Ho incontrato un segno diverso da A o D");
            }

            string segno = buffer[0] == 'A' ? "" : "-";
            string s = segno
                + new string(buffer, 1, numCifre - 3)
                + new string(buffer, numCifre - 2, 2);
            decimale = decimal.Parse(s,NumberStyles.Currency)/100m;
            return buffer[0].ToString();
        }

        public string leggiSegnoConDecimalePiuOMeno(TextReader tr, int numCifre, out decimal decimale) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            if (buffer[0] != '+' && buffer[0] != '-') {
                QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Ho incontrato un segno diverso da + o -");
            }

            //			string segno = buffer[0]=='A'? "": "-";
            string s = new string(buffer, 0, numCifre );
            decimale =  decimal.Parse(s)/100m;
            return buffer[0].ToString();
        }

        public decimal leggiDecimaleConSegno(TextReader tr, int numCifre, out string segno) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            segno = buffer[numCifre - 1].ToString();
            string s = buffer[numCifre - 1]
                + new string(buffer, 0, numCifre - 3)
                + new string(buffer, numCifre - 3, 2);
            return  decimal.Parse(s)/100m;
        }

        public object leggiDataGMA(TextReader tr, int numCifre) {
            if (tr.Read(buffer, 0, numCifre) != numCifre) {
                QueryCreator.ShowError(form, "ERRORE DURANTE LA LETTURA DEL FILE", "Letti meno byte rispetto al previsto");
            }
            try {
                return (object)DateTime.ParseExact(new string(buffer, 0, numCifre), "ddMMyyyy", DateTimeFormatInfo.CurrentInfo);
            }
            catch (Exception e) {
                string s = new string(buffer, 0, numCifre);
                string zeri = "".PadRight(numCifre, '0');
                string spazi = "".PadRight(numCifre, ' ');
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
                return (object)DateTime.ParseExact(s, "yyyyMMdd", DateTimeFormatInfo.CurrentInfo);
            }
            catch (Exception e) {
                if (new string(buffer, 0, numCifre) != "".PadRight(numCifre, '0')) {
                    QueryCreator.ShowException(form, "ERRORE DURANTE LA LETTURA DEL FILE: DATA AMG\r\n" + s, e);
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
                QueryCreator.ShowError(form, "Mi aspettavo il record 01 invece ho ricevuto il record " + tiprec, "");
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
                QueryCreator.ShowError(form, "Mi aspettavo il record 03 invece ho ricevuto il record " + TIPREC, "");
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
                QueryCreator.ShowError(form, "Mi aspettavo il record 04 invece ho ricevuto il record " + tiprec, "");
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
            r["FILTS"] = leggiNumerico(tr, 5);//  	Codice dipendenza  
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

        

        public static StreamReader getStreamReader(long quoziente, string fname) {

            FileInfo fi = new FileInfo(fname);
            long dimensione = fi.Length;
            long modulo = fi.Length % quoziente;
            if (modulo > 0) {
                QueryCreator.ShowError(null, "La dimensione del file non è un multiplo di " + quoziente, "Errore di dimensione del file");
                return null;
            }
            else {
                return new StreamReader(new BufferedStream(new FileStream(fname, FileMode.Open), 1048576), Encoding.Default);
            }

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

     

        private ArrayList valoriDistinti(DataTable t, string filtro, string[] colonne) {
            ArrayList al = new ArrayList();
            foreach (DataRow r in t.Select(filtro)) {
                string condizione = QueryCreator.WHERE_COLNAME_CLAUSE(r, colonne, DataRowVersion.Current, false);
                int pos = al.BinarySearch(condizione);
                if (pos < 0) {
                    al.Insert(-pos - 1, condizione);
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
                new string[] { "TIPDOC", "NUMDOC", "ESERC" });
            // Per ogni regolarizzazione individuata si procede alla cancellazione degli annullamenti
            foreach (string condizione in list) {
                //+" and INDREG='R'"
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

        private object ricavaDescrizioneCassiere(object sottoconto) {
            if (sottoconto.ToString().Trim() == "") return DBNull.Value;
            if (sottoconto.ToString() == "0") return DBNull.Value;
            object treasurer = Conn.DO_READ_VALUE("treasurer", QHS.AppAnd(QHS.CmpEq("trasmcode", sottoconto), QHS.BitClear("flag", 0)), "description");
            if (treasurer == null) treasurer = DBNull.Value;
            return treasurer;
        }

        private object ricavaCodiceCassiere(object sottoconto) {
            if (sottoconto.ToString().Trim() == "") return DBNull.Value;
            if (sottoconto.ToString() == "0") return DBNull.Value;

            object idtreasurer = Conn.DO_READ_VALUE("treasurer",
                QHS.AppAnd(QHS.CmpEq("trasmcode", sottoconto), QHS.BitClear("flag", 0)), "idtreasurer");
            if (idtreasurer == null) idtreasurer = DBNull.Value;
            return idtreasurer;
        }
        /// <summary>
        /// Metodo che elimina eventuali storni presenti nel flusso inviato dalla banca
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Metodo che popola una hashtable dove vengono inseriti i riferimenti dei documenti
        /// presenti nel flusso.
        /// </summary>
        /// <param name="TIPDOC"></param>
        /// <param name="SEGNO"></param>
        /// <returns></returns>
        private Hashtable getElencoMandatiOReversali(string TIPDOC, string SEGNO) {
            Hashtable ht = new Hashtable();
            string filtroRigheBanca = "TIPDOC='" + TIPDOC + "' and SEGNO='" + SEGNO + "'";
            foreach (DataRow r in DS.flussobanca.Select(filtroRigheBanca)) {
                object numdocumento = ht[r["ESERC"]];
                if (numdocumento == null) {
                    ArrayList list = new ArrayList();
                    list.Add(r["NUMDOC"]);
                    ht[r["ESERC"]] = list;
                }
                else {
                    ArrayList list = (ArrayList)numdocumento;
                    if (!list.Contains(r["NUMDOC"])) {
                        list.Add(r["NUMDOC"]);
                    }
                }
            }
            return ht;

        }

        

        private string aggiustaStringa(string stringa) {
            return stringa.Replace('Ç', 'c').Replace('ç', 'c').Replace('€', 'e').Replace('|', ' ').Replace('\\', ' ').Replace('£', ' ').Replace('§', ' ').Replace('@', ' ').Replace('[', ' ').Replace('#', ' ').Replace('!', ' ').Replace('Ù', 'u').Replace(
                'Ö', 'o').Replace('Ü', 'u').Replace('Ñ', 'n').Replace('Ð', 'd').Replace('Ê', 'e').Replace('Ë', 'e').Replace('Î', 'i').Replace('Ï', 'i').Replace('Ô', 'o').Replace('Õ', 'o').Replace('Û', 'u').Replace('Ý', 'y').Replace(
                ']', ' ').Replace('`', ' ').Replace('{', ' ').Replace('}', ' ').Replace('~', ' ').Replace('ü', 'u').Replace('â', 'a').Replace('ä', 'a').Replace('å', 'a').Replace('ê', 'e').Replace('ë', 'e').Replace('ï', 'i').Replace(
                'î', 'i').Replace('Ä', 'a').Replace('Å', 'a').Replace('ô', 'o').Replace('ö', 'o').Replace('û', 'u').Replace('ÿ', 'y').Replace('ñ', 'n').Replace('Â', 'a').Replace('¥', 'y').Replace('ã', 'a').Replace('Ã', 'a').Replace(
                'õ', 'o').Replace('ý', 'y').Replace('é', 'e').Replace('à', 'a').Replace('è', 'e').Replace('ì', 'i').Replace('ò', 'o').Replace('ù', 'u').Replace('á', 'a').Replace('í', 'i').Replace('ó', 'o').Replace('É', 'e').Replace(
                'Á', 'a').Replace('À', 'a').Replace('È', 'e').Replace('Í', 'i').Replace('Ì', 'i').Replace('Ó', 'o').Replace('Ò', 'o').Replace('Ú', 'u').Replace('\t', ' ').Replace('\n', ' ').Replace('\r', ' ').Replace('°', ' ');
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

        public decimal leggiDecimaleCarime(TextReader tr, out string segno) {
            tr.Read(buffer, 0, 16);

            decimal d = decimal.Parse(new string(buffer, 0, 15 ),
                NumberStyles.Currency)/100.0m;
            
            segno = new string(buffer, 15, 1);
            if (segno == "-") {
                return -d;
            }
            return d;
        }

        public enum BANCA { ROMA, UNICREDIT, MPS, CARIME, BPPUGLIESE,BCCFLUMERI,CREDITOSICILIANO,BANCODISARDEGNA };
        abstract public BANCA getBanca();
    }
}
