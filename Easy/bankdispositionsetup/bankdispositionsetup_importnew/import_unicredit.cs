/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows;
using metadatalibrary;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using funzioni_configurazione;
using System.Drawing;
using System.ComponentModel;

namespace bankdispositionsetup_importnew {
    

    public class ImportazioneEsitiBancariUnicredit : LetturaTracciati {
        public ImportazioneEsitiBancariUnicredit(DataAccess Conn)
            :
            base(Conn) {
        }

        public override BANCA getBanca() {
            return BANCA.UNICREDIT;
        }
        public static string detectType(string fname) {
            FileInfo fi = new FileInfo(fname);
            long dimensione = fi.Length;
            //EF06  503
            //Ef07  502
            if (fi.Length % 502 == 0) return "EF07";
            if (fi.Length % 503 == 0) return "EF06";
            QueryCreator.ShowError(null, "La dimensione del file non è un multiplo di 502 o 503.","Errore di dimensione del file");

            return null;
            
        }
        #region lettura ef06 
        public bool parseEF06File(string fname) {
            ArrayList altriEsercizi = new ArrayList();
            StreamReader sr = getStreamReader(503, fname);
            if (sr == null) {
                return false;
            }
         
            DS.EF06_TestaCoda.Clear();
            DS.EF06.Clear();
           int numFile = 0;
           int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            while (sr.Peek() != -1) {
                int numRecord = 0;
                numFile++;
                DataRow rTC = DS.EF06_TestaCoda.NewRow();
                if (!leggiEF06RecordDiTesta(sr, rTC)) return false;
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
                    if (!leggiEF06DettaglioMovimenti(sr, rDett)) return false;
                    if (CfgFn.GetNoNullInt32(rDett["ESERC1"]) == esercizio) {
                        DS.EF06.Rows.Add(rDett);
                    }
                    else {
                        if (!altriEsercizi.Contains(rDett["ESERC1"])) {
                            altriEsercizi.Add(rDett["ESERC1"]);
                        }
                    }
                    tiprec = leggiEF06IntestazioneRecord(sr, rTC);
                }
                if (tiprec != "03") {
                    QueryCreator.ShowError(null, "Errore durante la lettura del file", "Atteso il record 3; incontrato invece il record " + tiprec);
                    return false;
                }
                if (!leggiEF06RecordDiCoda(sr, rTC))
                    return false;
                //				Console.WriteLine(numFile+" "+numRecord);
            }
            sr.Close();
            copia_EF06_IN020304();

            if (altriEsercizi.Count > 0) {
                string messaggio = "Nel file ci sono esitazioni relative ad esercizi diversi.\nDopo aver esitato nel "
                + Conn.GetSys("esercizio")
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
                messaggio += ". Non è necessario a tal fine manipolare il file in alcun modo.";
                MessageBox.Show( messaggio,"Avviso");
            }
            return true;
        }

        bool leggiEF06RecordDiTesta(TextReader tr, DataRow r) {
            r["ISTTS1"] = leggiNumerico(tr, 3);		//	1	3	N	Codice Istituto Tesoriere
            r["FILTESE"] = leggiAlfanumerico(tr, 3);//	4	3	A	Filiale Tesoreria
            r["CODENT1"] = leggiNumerico(tr, 9);	//	7	9	N	Codice Ente
            r["ESERC1"] = leggiNumerico(tr, 4);		//	16	4	N	Esercizio
            //int tiprec = leggiNumerico(tr, 2);
            //r["TIPREC"] = tiprec;		//	20	2	N	Tipo record –Fisso 01
            string tiprec = leggiAlfanumerico(tr, 2);
            r["TIPREC"] = tiprec; ////	20	2	A	Tipo record –Fisso 01   Maria tracciato aggiornato
            r["WA035"] = leggiAlfanumerico(tr, 35);	//	22	35	A	Descrizione flusso prima parte
            r["WA040"] = leggiAlfanumerico(tr, 40);	//	57	40	A	Descrizione flusso seconda parte
            r["FILLER"] = leggiAlfanumerico(tr, 405);//	97	404	A	Campo vuoto
            Console.WriteLine(r["WA035"]);
            if (tiprec != "01") {
                QueryCreator.ShowError(null, "Errore durante la lettura del file", "Era atteso il record 01 invece si è incontrato il record " + tiprec);
                return false;
            }
            return vaiACapo(tr);
        }

        bool leggiEF06DettaglioMovimenti(TextReader tr, DataRow r) {
            //			r["ISTTS1"] = leggiNumerico(tr, 3);		//	1	3	N	Codice Istituto Tesoriere
            //			r["FILTESE"] = leggiAlfanumerico(tr, 3);//	4	3	A	Filiale Tesoreria
            //			r["CODENT1"] = leggiNumerico(tr, 9);	//	7	9	N	Codice Ente
            //			r["ESERC1"] = leggiNumerico(tr, 4);		//	16	4	N	Esercizio
            //			r["TIPREC"] = leggiNumerico(tr, 2);		//	20	2	N	Tipo record –Fisso 02
            r["TIPDOC"] = leggiAlfanumerico(tr, 1);	//	22	1	A	Tipo documento – NoteTIPDOC: I = Incasso; R = Reversale; P = Pagamento; M = Mandato
            //			r["NUMDO1"] = leggiNumerico(tr, 7);		//	23	7	N	Numero documento
            r["NUMDO1"] = leggiAlfanumerico(tr, 7);	//	23	7	A	Numero documento (Maria tracciato aggiornato)
            //			r["PRODO1"] = leggiNumerico(tr, 7);		//	30	7	N	Progressivo documento
            r["PRODO1"] = leggiAlfanumerico(tr, 7);	//	30	7	A	Progressivo documento (Maria tracciato aggiornato)
            r["CAPBI2"] = leggiNumerico(tr, 7);		//	37	7	N	Capitolo di bilancio
            r["ARBTI2"] = leggiNumerico(tr, 4);		//	45	4	N	Articolo di bilancio
            r["ANNOC1"] = leggiNumerico(tr, 4);		//	48	4	N	Anno competenza
            string segno;
            r["IMPMA1"] = leggiDecimaleConSegno(tr, 16, out segno);	//	52	15	N	Importo mandato/reversale indicato in centesimi di euro
            r["SEGNOP"] = segno;					//	67	1	A	Segno operazione
            r["DTPAG9"] = leggiDataAMG(tr, 8);			//	68	8	N	Data pagamento/incasso
            r["DVALP2"] = leggiDataAMG(tr, 8);			//	76	8	N	Data valuta
            r["PROST1"] = leggiNumerico(tr, 7);		//	84	7	N	Progressivo Quietanza
            r["ANABE"] = leggiAlfanumerico(tr, 60);	//	91	60	A	Anagrafica beneficiario/versante
            r["DCAP"] = leggiAlfanumerico(tr, 60);	//	151	60	A	Descrizione causale operazione
            r["CODGEN"] = leggiAlfanumerico(tr, 20);//	211	20	A	Codifica generica (ad uso dell’Ente)
            r["IMPRI1"] = leggiDecimale(tr, 15);	//	231	15	N	Importo ritenute indicato in centesimi di euro
            r["INDREG"] = leggiAlfanumerico(tr, 1);		//	246	1	A	Indicativo regolazione – NoteINDREG: R = Regolazione (operazione a copertura)
            r["DESTU"] = leggiAlfanumerico(tr, 1);	//	247	1	A	Destinazione TU – NoteDESTTU: F = Fruttifera; I = Infruttifera
            r["INDCBI"] = leggiAlfanumerico(tr, 1); //	248	1	A	Indicativo BankItalia – NoteINDCBI: O = Ordinaria; C = Capitale
            r["CAUTS"] = leggiAlfanumerico(tr, 2);	//	249	2	A	Causale tesoreria
            //			r["NUMOA1"] = leggiNumerico(tr, 7);		//	251	7	N	Numero O A
            r["NUMOA1"] = leggiAlfanumerico(tr, 7);	//	251	7	A	Numero O A (Maria nuovo tracciato)
            //			r["PROGA1"] = leggiNumerico(tr, 7);		//	258	7	N	Progressivo A
            r["PROGA1"] = leggiAlfanumerico(tr, 7);	//	258	7	A	Progressivo A (Maria nuovo tracciato)
            r["DVALB2"] = leggiDataAMG(tr, 8);		//	265	8	N	Data valuta beneficiario (Maria nel nuovo tracciato da alfanum diventa numerico)
            //			r["CODVER"] = leggiNumerico(tr, 5);		//	273	5	N	Codice versamento
            r["CODVER"] = leggiAlfanumerico(tr, 5);	//	273	5	A	Codice versamento (Maria nuovo tracciato)
            r["NUMPRA"] = leggiAlfanumerico(tr, 10);//	278	10	N	Numero pratica (su segnal. Fabbri da ignorare) 
            r["DESVER"] = leggiAlfanumerico(tr, 60);//	288	60	A	Descrizione versamento
            r["NUMPR1"] = leggiAlfanumerico(tr, 7);	//	348	7	A	Numero proposta reversale
            r["PROGP1"] = leggiAlfanumerico(tr, 4);	//	355	4	A	Progressivo proposta reversale
            r["MANRI1"] = leggiAlfanumerico(tr, 7);	//	359	7	A	Numero mandato delle ritenute
            r["PRORI1"] = leggiAlfanumerico(tr, 7);	//	366	7	A	Progressivo mand. ritenute
            r["DTELT2"] = leggiDataAMG(tr, 8);		//	373	8	N	Data elaborazione
            r["IBOLL1"] = leggiNumerico(tr, 5);		//	381	5	N	Importo bolli
            r["INDBOL"] = leggiAlfanumerico(tr, 1);	//	386	1	A	Indicatore bolli
            r["ICOMT1"] = leggiNumerico(tr, 7);		//	387	7	N	Importo commissioni tesoreria
            r["INDCOM"] = leggiAlfanumerico(tr, 1);	//	394	1	A	Indicatore commissioni tesoreria
            r["ISPEP1"] = leggiNumerico(tr, 5);		//	395	5	N	Importo spese postali
            r["INDSPT"] = leggiAlfanumerico(tr, 1);	//	400	1	A	Indicatore spese tesoreria
            r["BYTLEU"] = leggiAlfanumerico(tr, 1); //	401	1	A	Indicatore divisa
            r["BYTLEC"] = leggiAlfanumerico(tr, 1); //	402	1	A	
            r["INDMO"] = leggiAlfanumerico(tr, 1);	//	403	1	A	Indicatore mo
            r["INDSI"] = leggiAlfanumerico(tr, 1);	//	404	1	A	Indicatore SI
            r["TPAGTS"] = leggiNumerico(tr, 2);		//	405	2	N	Tipo pagamento tesoreria
            r["CABIT1"] = leggiNumerico(tr, 5);		//	407	5	N	Cab it
            string cab = leggiAlfanumerico(tr, 5);
            try {
                r["CABDTX"] = int.Parse(cab);
            }
            catch (Exception) {
                r["CABDTX"] = 0;
            }
            //			r["CABDTX"] = leggiNumerico(tr, 5);		//	412	5	A	Cab dtx
            r["NUMBO"] = leggiAlfanumerico(tr, 12);	//	417	12	A	Numero bo
            r["CINRT"] = leggiAlfanumerico(tr, 1);	//	429	1	A	
            r["CDMEC2"] = leggiLong(tr, 10);		//	430	10	N	Codice meccanografico
            r["IMPMA2"] = leggiDecimale(tr, 15);	//	440	15	N	Importo ma
            r["FILLER"] = leggiAlfanumerico(tr, 47);//	455	46	A	Campo vuoto
            return vaiACapo(tr);
        }

        bool leggiEF06RecordDiCoda(TextReader tr, DataRow r) {
            //			r["ISTTS1"] = import.leggiNumerico(tr, 3);		//	1	3	N	Codice Istituto Tesoriere
            //			r["FILTESE"] = import.leggiAlfanumerico(tr, 3);//	4	3	A	Filiale tesoriere
            //			r["CODENT1"] = import.leggiAlfanumerico(tr, 9);//	7	9	N	Codice Ente
            //			r["ESERC1"] = leggiNumerico(tr, 4);		//	16	4	N	Esercizio
            //			r["TIPREC"] = leggiNumerico(tr, 2);		//	20	2	N	Tipo record –Fisso 03
            r["NOINC"] = leggiNumerico(tr, 7);		//	22	7	N	Numero operazioni incasso
            decimal decimale;
            r["SEGNO1"] = leggiSegnoConDecimaleAoD(tr, 16, out decimale);	//	29	1	A	(Maria) Segno incasso modifica temporanea dovuta a errore nel file 
            r["ITOIN2"] = decimale;		//	30	15	N	Importo totale incasso
            r["NOPPAG"] = leggiNumerico(tr, 7);		//	45	7	N	Numero operazioni pagamento
            r["SEGNOP"] = leggiSegnoConDecimalePiuOMeno(tr, 16, out decimale);	//	52	1	A	Segno pagamento
            r["ITOPA2"] = decimale;					//	53	15	N	Importo totale pagamenti
            r["SEGNOG"] = leggiSegnoConDecimalePiuOMeno(tr, 16, out decimale);	//	68	1	A	Segno giacenza
            r["IGIACZ"] = decimale;					//	69	15	N	Importo giacenza
            r["IUTANZ"] = leggiDecimale(tr, 15);	//	84	15	N	Importo anticipazione utilizzata
            r["IVIANZ"] = leggiDecimale(tr, 15);	//	99	15	N	Importo anticipazione vincolata
            r["IPROI1"] = leggiDecimale(tr, 15);	//	114	15	N	Importo progressivo Reversali incassate
            r["IPROP1"] = leggiDecimale(tr, 15);	//	129	15	N	Importo progressivo mandati pagati
            string segno;
            r["IFCPR1"] = leggiDecimaleConSegno(tr, 16, out segno);	//	144	15	N	Imp. fondo cassa precedente
            r["SEGNOF"] = segno;					//	159	1	A	Segno fondo cassa precedente
            r["BYTLEU"] = leggiAlfanumerico(tr, 1);	//	160	1	A	Indicatore divisa
            r["NOINC_"] = leggiNumerico(tr, 7);		//	161	7	N	Numero operazione incasso
            r["SEGNO1_"] = leggiSegnoConDecimaleAoD(tr, 16, out decimale);	//	168	1	A	Segno incasso
            r["ITOIN2_"] = decimale;				//	169	15	N	Importo totale incasso
            r["NOPPAG_"] = leggiNumerico(tr, 7);	//	183	7	N	Numero operazione incasso
            r["SEGNOP_"] = leggiSegnoConDecimalePiuOMeno(tr, 16, out decimale);	//	191	1	A	Segno pagamento
            r["ITOPA2_"] = decimale;				//	192	15	N	Importo totale pagamenti
            r["SEGNOG_"] = leggiSegnoConDecimalePiuOMeno(tr, 16, out decimale);	//	207	1	A	Segno giacenza
            r["IGIACZ_"] = decimale;				//	208	15	N	Importo giacenza
            r["IUTANZ_"] = leggiDecimale(tr, 15);	//	223	15	N	
            r["IVIANZ_"] = leggiDecimale(tr, 15);	//	238	15	N	
            r["IPROI1_"] = leggiDecimale(tr, 15);	//	253	15	N	
            r["IPROP1_"] = leggiDecimale(tr, 15);	//	268	15	N	
            r["IFCPR1_"] = leggiDecimale(tr, 15);	//	283	15	N	
            r["SEGNOF_"] = leggiAlfanumerico(tr, 1);//	298	1	A	
            r["BYTLEU_"] = leggiAlfanumerico(tr, 1);//	299	1	A	Indicatore divisa
            r["FILLER"] = leggiAlfanumerico(tr, 202);//300	201	A	Campo vuoto
            return vaiACapo(tr);
        }

        private void copia_EF06_IN020304() {
            DS.EF06_TestaCoda.Clear();
            DS.flussobanca.Clear();
            foreach (DataRow s in DS.EF06.Rows) {
                DataRow r = DS.flussobanca.NewRow();
                r["CFISC"] = "";
                r["ESERC"] = s["ESERC1"];
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
                DS.flussobanca.Rows.Add(r);
            }
            DS.EF06.Clear();
        }

        private string leggiEF06IntestazioneRecord(TextReader tr, DataRow r) {
            int ISTTS1 = leggiNumerico(tr, 3);		//	1	3	N	Codice Istituto Tesoriere
            string FILTESE = leggiAlfanumerico(tr, 3);//	4	3	A	Filiale Tesoreria
            int CODENT1 = leggiNumerico(tr, 9);	//	7	9	N	Codice Ente
            int ESERC1 = leggiNumerico(tr, 4);		//	16	4	N	Esercizio
            if (!ISTTS1.Equals(r["ISTTS1"]) || !FILTESE.Equals(r["FILTESE"]) || !CODENT1.Equals(r["CODENT1"])
                || !ESERC1.Equals(r["ESERC1"])) {
                QueryCreator.ShowError(null, "Errore durante la lettura del file", "Errore nell'intestazione di un record dettaglio o record di coda");
                return null;
            }
            return leggiAlfanumerico(tr, 2);		//	20	2	N	Tipo record –Fisso 01
        }
        #endregion

        public bool parseEF07File(string fname) {
            StreamReader sr = getStreamReader(502, fname);
            if (sr == null) {
                return false;
            }
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            ArrayList altriEsercizi = new ArrayList();
            DS.IN0109.Clear();
            DS.flussobanca.Clear();
            int numFile = 0;
            while (sr.Peek() != -1) {
                int numRecord = 0;
                numFile++;
                DataRow rTC = DS.IN0109.NewRow();
                if (!leggiEF07RecordDiTesta(sr, rTC)) return false;
                DS.IN0109.Rows.Add(rTC);
                string tiprec = leggiIntestazioneRecord(sr, rTC);
                while (tiprec == "02") {
                    numRecord++;
                    DataRow rDett = DS.flussobanca.NewRow();
                    rDett["DTELAB"] = rTC["DTELAB"];
                    rDett["ISTTS"] = rTC["ISTTS"];
                    rDett["CODEN"] = rTC["CODEN"];
                    rDett["ESERC"] = rTC["ESERC"];
                    if (!leggiEF07RecordDiDettaglio(sr, rDett)) return false;
                    if (!leggiEF07RecordBeneficiario(sr, rDett)) return false;
                    if (!leggiEF07RecordCausale(sr, rDett)) return false;
                    if (CfgFn.GetNoNullInt32(rDett["ESERC"]) == esercizio) {
                        DS.flussobanca.Rows.Add(rDett);
                    }
                    else {
                        if (!altriEsercizi.Contains(rDett["ESERC"])) {
                            altriEsercizi.Add(rDett["ESERC"]);
                        }
                    }
                    tiprec = leggiIntestazioneRecord(sr, rTC);
                    
                }
                if (tiprec != "09") {
                    QueryCreator.ShowError(null, "Mi aspettavo il record 09 invece ho ricevuto il record " + tiprec, "");
                    return false;
                }
                if (!leggiEF07FileDiCoda(sr, rTC)) return false;
                //				Console.WriteLine(numFile+" "+numRecord);
            }
            sr.Close();
            DS.IN0109.Clear();
         
            return true;
        }

        private string leggiIntestazioneRecord(TextReader tr, DataRow r) {
            int ISTTS = leggiNumerico(tr, 5);//  	Codice istituto
            int CODEN = leggiNumerico(tr, 7);//  	Codice ente  
            int ESERC = leggiNumerico(tr, 4);//  	Anno esercizio   
            if (!ISTTS.Equals(r["ISTTS"]) || !CODEN.Equals(r["CODEN"]) || !ESERC.Equals(r["ESERC"])) {
                QueryCreator.ShowError(null, "Errore nell'intestazione di un record 02 o 09", "");
                return null;
            }
            return leggiAlfanumerico(tr, 2);//  	Tipo record  
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
                QueryCreator.ShowError(null, "Mi aspettavo il record 01 invece ho ricevuto il record " + tiprec, "");
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
            r["NUMDOC"] = leggiNumerico(tr, 7); //leggiAlfanumerico(tr, 7);//  	Numero documento  
            r["PRODOC"] = leggiNumerico(tr, 7); //leggiAlfanumerico(tr, 7);//  	Progressivo documento 
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

            if (r["INDREG"].ToString().ToUpper() == "R" &&
                    (r["TIPDOC"].ToString().ToUpper() == "I" || r["TIPDOC"].ToString().ToUpper() == "P")) {
                        r["IMPDOC"] = -CfgFn.GetNoNullDecimal(r["IMPDOC"]);
            }
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
                QueryCreator.ShowError(null, "Mi aspettavo il record 03 invece ho ricevuto il record " + TIPREC, "");
                return false;
            }
            if (!ISTTS.Equals(r["ISTTS"]) || !CODEN.Equals(r["CODEN"]) || !ESERC.Equals(r["ESERC"])) {
                QueryCreator.ShowError(null, "Errore nell'intestazione del record 03", "");
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
                QueryCreator.ShowError(null, "Mi aspettavo il record 04 invece ho ricevuto il record " + tiprec, "");
                return false;
            }
            if (!ISTTS.Equals(r["ISTTS"]) || !CODEN.Equals(r["CODEN"]) || !ESERC.Equals(r["ESERC"])) {
                QueryCreator.ShowError(null, "Errore nell'intestazione del record 04", "");
                return false;
            }
            return vaiACapo(tr);
        }

        bool leggiEF07FileDiCoda(TextReader tr, DataRow r) {
            //			coda.ISTTS = import.leggiNumerico(tr, 5);//  	Codice istituto
            //			coda.CODEN = import.leggiNumerico(tr, 7);//  	Codice ente  
            //			coda.ESERC = import.leggiNumerico(tr, 4);//  	Anno esercizio   
            //			coda.TIPREC = import.leggiAlfanumerico(tr, 2);//  	Tipo record  
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

    }

    class import_unicredit {

        public static DatiImportati ImportaFile(DataAccess Conn, string fname) {
            ImportazioneEsitiBancariUnicredit import = new ImportazioneEsitiBancariUnicredit(Conn);

            string tipo = ImportazioneEsitiBancariUnicredit.detectType(fname);
            if (tipo == null) return null;
            bool res;
            if (tipo == "EF06") {
                res = import.parseEF06File(fname);
            }
            else {
                res = import.parseEF07File(fname);
            }
             
            if (!res) return null;

            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            return ConvertiFlussoBanca.GetDataFrom(esercizio,import.DS.flussobanca);
        }
        
    }
}
