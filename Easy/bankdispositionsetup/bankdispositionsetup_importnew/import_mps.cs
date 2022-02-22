
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


    public class ImportazioneEsitiBancariMPS : LetturaTracciati {
        public ImportazioneEsitiBancariMPS(DataAccess Conn)
            :
            base(Conn) {
        }

        public override BANCA getBanca() {
            return BANCA.MPS;
        }
        public bool parseFile(StreamReader sr) {
            ArrayList altriEsercizi = new ArrayList();
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            DS.giornaledicassa.Clear();
            DS.gdc.Clear();

            int numFile = 0;
            
            while (sr.Peek() != -1) {
                int numRecord = 0;
                numFile++;
                DataRow rTC = DS.gdc.NewRow();
                if (!leggiRecordDiTesta(sr, rTC)) return false;
                //				DS.gdc.Rows.Add(rTC);
                int tipoRecord = leggiNumerico(sr, 2);
                while (tipoRecord == 2) {
                    numRecord++;
                    DataRow rDett = DS.giornaledicassa.NewRow();
                    rDett["DATAPRODUZIONEFLUSSO"] = rTC["DATAPRODUZIONEFLUSSO"];
                    rDett["CODICEFILIALE"] = rTC["CODICEFILIALE"];
                    rDett["CODICEENTE"] = rTC["CODICEENTE"];
                    rDett["ESERCIZIOFINANZIARIO"] = rTC["ESERCIZIOFINANZIARIO"];
                    rDett["DATADIRIFERIMENTO"] = rTC["DATADIRIFERIMENTO"];
                    if (!leggiRecordDiDettaglio(sr, rDett)) return false;
                    if (CfgFn.GetNoNullInt32(rDett["ESERCIZIOFINANZIARIO"]) ==esercizio) {
                        DS.giornaledicassa.Rows.Add(rDett);
                    }
                    else {
                        if (!altriEsercizi.Contains(rDett["ESERCIZIOFINANZIARIO"])) {
                            altriEsercizi.Add(rDett["ESERCIZIOFINANZIARIO"]);
                        }
                    }
                    tipoRecord = leggiNumerico(sr, 2);
                }
                if (tipoRecord != 3) {
                    QueryCreator.ShowError(null, "Mi aspettavo il record 3 invece ho ricevuto il record " + tipoRecord, "");
                    return false;
                }
                if (!leggiRecordDiTotali(sr, rTC)) return false;
                if (!leggiRecordDiCoda(sr, rTC)) return false;
            }
            sr.Close();
            copia_Mps_IN020304();
            
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
                MetaFactory.factory.getSingleton<IMessageShower>().Show(messaggio,"Avviso");
            }
            return true;
        }
        private void copia_Mps_IN020304() {
            DS.flussobanca.Clear();
            foreach (DataRow s in DS.giornaledicassa.Rows) {
                DataRow r = DS.flussobanca.NewRow();
                int flagCartacontabile = (int)s["FLAGORDINATIVO_CARTACONTABILE"]; // 0 ordinativo 1 carta contabile
                int flagUscite = (int)s["FLAGENTRATE_USCITE"];      //0 entrate 1 uscite
                int flagStorno = (int)s["STORNO"];      //0 normale 1 storno
                string modalitaEsecuzione = (string)s["MODALITADIESECUZIONE"];
                int tipo = flagCartacontabile * 2 + flagUscite;
                switch (tipo) {
                    case 0: r["TIPDOC"] = "R"; break;
                    case 1: r["TIPDOC"] = "M"; break;
                    case 2: r["TIPDOC"] = "I"; break;
                    case 3: r["TIPDOC"] = "P"; break;
                }
                if (flagCartacontabile == 1) {
                    r["NUMQUI"] = s["NUMEROORDINATIVO_O_CARTACONTABILE"];
                }
                else {
                    if (modalitaEsecuzione == "R") {
                        r["NUMQUI"] = s["CARTACONTABILE"];
                    }
                    else {
                        r["NUMQUI"] = -(int)s["BOLLETTA"];
                    }
                }
                r["SEGNO"] = flagStorno == 1 ? "-" : "+";
                r["INDREG"] = modalitaEsecuzione == "R" ? "R" : " ";

                r["ISTTS"] = s["CODICEFILIALE"];
                r["CODEN"] = s["CODICEENTE"];
                r["ESERC"] = s["ESERCIZIOFINANZIARIO"];
                //				r["TIPDOC"] = s["tipdoc"]; assegnato sopra
                r["NUMDOC"] = s["NUMEROORDINATIVO_O_CARTACONTABILE"];
                r["PRODOC"] = s["PROGRESSIVODISPOSIZIONE"];
                //				r["CAPBIL"] = s[""];
                //				r["ARTBIL"] = s[""];
                //				r["CDMEC"] = s[""];
                //				r["ANNOCO"] = s[""];

                //rende compatibile con le altre importazioni che prevedono che IMPDOC abbia il segno indicato nel campo SEGNO
                r["IMPDOC"] = (flagStorno==1) ? -CfgFn.GetNoNullDecimal( s["IMPORTO"]) : s["IMPORTO"];
                //				r["SEGNO"] = s["segno"]; assegnato sopra
                r["DTELAB"] = s["DATAPRODUZIONEFLUSSO"];
                //				r["DTELAB"] = s["datacaricamento"];coincide con data pagamento
                r["DTPAG"] = s["DATADIRIFERIMENTO"];
                r["DVAL"] = s["DATAVALUTA"];
                //				r["NUMQUI"] = s[""];assegnato sopra
                //				r["NUMDIS"] = s[""];
                //				r["IMPRIT"] = s[""];
                //				r["INDREG"] = s["indreg"];assegnato sopra
                r["DVALBE"] = DBNull.Value;
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
                r["TPAGTS"] = s["MODALITADIESECUZIONE"];
                //				r["CODABI"] = s[""];
                //				r["CODCAB"] = s[""];
                r["CONTO"] = s["CONTOCORRENTE"];
                r["CIN"] = "";
                //				r["IBAN_PAE"] = s[""];
                //				r["IBAN_CHK"] = s[""];
                //				r["IBAN_COO"] = s[""];
                r["NCNT"] = s["CONTOCORRENTE"];
                //				r["CTIPIPU"] = s[""];
                //				r["DESVER"] = s[""];
                //				r["CCGU"] = s[""];
                //				r["CCPV"] = s[""];
                //				r["CCUP"] = s[""];
                //				r["FILLER"] = s[""];
                r["ANABE"] = s["BENEFICIARIO_O_OBBLIGATO"];
                //				r["INDIR"] = s["indirizzo"];
                //				r["CAP"] = s["cap"];
                //				r["LOC"] = s["localita"];
                //				r["CFISC"] = "";
                r["CAUSALE"] = s["DESCRIZIONEOPERAZIONE"];
                //r["FILLER"] = s[""];
                //				r[""] = s["TIPO RECORD"];
                //				r[""] = s["PROGRESSIVO DI FLUSSO"];
                //				r[""] = s["FLAG COMPETENZA/RESIDUI"];
                //				r[""] = s["FLAG FRUTTIFERO/INFRUTTIFERO"];
                //				r[""] = s["IMPORTO FRUTTIFERO"];
                //				r[""] = s["VALUTA SPECIALE"];
                //				r[""] = s["GIROFONDI"];
                //				r[""] = s["DIVISA OPERAZIONE"];
                //				r[""] = s["CONTROVALORE DIVISA OPERAZIONE"];
                //				r[""] = s["DATI RISERVATI ALL’ENTE"];
                //				r[""] = s["CRO/NUMERO ASSEGNO"];
                //				r[""] = s["GIROFONDI"];
                //				r[""] = s["FILLER"];
                DS.flussobanca.Rows.Add(r);
            }
            DS.giornaledicassa.Clear();
        }


        /// <summary>
        /// 	01 - RECORD IDENTIFICATIVO DI FLUSSO
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        bool leggiRecordDiTesta(TextReader tr, DataRow r) {
            int tipoRecord = leggiNumerico(tr, 2);
            r["TIPORECORD1"] = tipoRecord;//NUMERICO		 2		 1
            r["PROGRESSIVODIFLUSSO1"] = leggiNumerico(tr, 5);//	NUMERICO		 5		 2 PROGRESSIVO DEL RECORD ALL’INTERNO DEL FLUSSO
            int tipoFlusso = leggiNumerico(tr, 3);
            r["TIPOFLUSSO"] = tipoFlusso;//NUMERICO		 3		 3 INDICA LA TIPOLOGIA DEL FLUSSO IN TRASMISSIONE:      011    GIORNALE DI CASSA
            r["DATAPRODUZIONEFLUSSO"] = leggiDataAMG(tr, 8);//NUMERICO		 8		 4 ESPRESSO NEL FORMATO DATA   AAAAMMGG
            r["PROGRESSIVOPERDATA"] = leggiNumerico(tr, 1);//NUMERICO		 1		 5 UTILIZZATO IN CASO DI PIU’ FLUSSI INVIATI NELLA STESSA DATA ( PRIMO INVIO = 0 ) 
            r["CODICEFILIALE"] = leggiNumerico(tr, 5);//NUMERICO		 5		 6 CODICE DELLA FILIALE CHE EFFETTUA IL  SERVIZIO DI TESORERIA 
            r["CODICEENTE"] = leggiNumerico(tr, 3);//NUMERICO		 3		 7 CODICE DELL’ENTE FORNITO DALLA DIPENDENZA CHE EFFETTUA IL SERVIZIO DI TESORERIA 
            r["ANAGRAFICAENTE"] = leggiAlfanumerico(tr, 35);//CARATTERE		35
            r["ESERCIZIOFINANZIARIO"] = leggiNumerico(tr, 4);//(AAAA)			NUMERICO		 4
            r["DATADIRIFERIMENTO"] = leggiDataAMG(tr, 8);//NUMERICO		 8		 8 GIORNATA A CUI SI RIFERISCONO LE INFORMAZIONI CONTENUTE NEL FLUSSO (AAAAMMGG)
            r["DIVISA"] = leggiAlfanumerico(tr, 1);//CARATTERE		 1		 9
            r["FILLER1"] = leggiAlfanumerico(tr, 175);//CARATTERE	         175
            if (tipoRecord != 1) {
                QueryCreator.ShowError(null, "Mi aspettavo il record 1 invece ho ricevuto il record " + tipoRecord, "");
                return false;
            }
            if (tipoFlusso != 11) {
                QueryCreator.ShowError(null, "Mi aspettavo il flusso 11 (giornale di cassa) invece ho ricevuto il flusso " + tipoFlusso, "");
                return false;
            }
            return vaiACapo(tr);
        }

        /// <summary>
        /// 02 - RECORD DI DETTAGLIO DEI MOVIMENTI DELLA GIORNATA
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        bool leggiRecordDiDettaglio(TextReader tr, DataRow r) {
            //			r["TIPORECORD"] = leggiNumerico(tr, 2);//NUMERICO		 2		 1
            r["PROGRESSIVODIFLUSSO"] = leggiNumerico(tr, 5);//NUMERICO		 5		 2 PROGRESSIVO DEL RECORD ALL’INTERNO DEL FLUSSO
            r["NUMEROORDINATIVO_O_CARTACONTABILE"] = leggiNumerico(tr, 7);//NUMERICO		 7
            r["PROGRESSIVODISPOSIZIONE"] = leggiNumerico(tr, 5);//NUMERICO		 5		10 INDICA L’ESECUZIONE DI UN SUB_ORDINATIVO
            r["FLAGORDINATIVO_CARTACONTABILE"] = leggiNumerico(tr, 1);//NUMERICO		 1		11 0   =   ORDINATIVO;		1   =  CARTA CONTABILE
            r["BENEFICIARIO_O_OBBLIGATO"] = leggiAlfanumerico(tr, 60);//CARATTERE		60
            r["FLAGCOMPETENZA_RESIDUI"] = leggiNumerico(tr, 1);//NUMERICO		 1		12	0   =   COMPETENZA;		1   =   RESIDUI		
            r["FLAGENTRATE_USCITE"] = leggiNumerico(tr, 1);//NUMERICO		 1		13 0   =   ENTRATE;		1   =   USCITE
            r["IMPORTO"] = leggiDecimale(tr, 15);//NUMERICO		15		14 IMPORTO DELL’OPERAZIONE ESPRESSO NELLA DIVISA CON CUI L’ENTE INTRATTIENE IL 	RAPPORTO CON IL TESORIERE
            r["FLAGFRUTTIFERO_INFRUTTIFERO"] = leggiNumerico(tr, 1);//NUMERICO		 1		15 1   =   FRUTTIFERO;		2   =   INFRUTTIFERO;    PER GLI ENTI IN T.U.   ZERO PER GLI ALTRI
            r["IMPORTOFRUTTIFERO"] = leggiDecimale(tr, 15);//NUMERICO		15		16 EVENTUALE PARTE FRUTTIFERA DELL’IMPORTO TOTALE (14); 	SOLO PER LE USCITE DEGLI ENTI IN T.U.
            r["STORNO"] = leggiNumerico(tr, 1);//NUMERICO		 1		17 1   =   OPERAZIONE STORNATA;	 ZERO NEGLI ALTRI CASI  
            r["BOLLETTA"] = leggiNumerico(tr, 9);//NUMERICO		 9		18 NUMERO DELLA BOLLETTA EMESSA IN AUTOMATICO A FRONTE DI UN INCASSO
            r["CONTOCORRENTE"] = leggiNumerico(tr, 7);//NUMERICO		 7		19 CONTO CORRENTE A CUI E’ IMPUTATA L’OPERAZIONE;	VALORIZZATO SOLO SE CONTO VINCOLO O DI EVIDENZA
            r["DATAVALUTA"] = leggiDataAMG(tr, 8);//NUMERICO		 8		20 VALUTA DELL’OPERAZIONE (AAAAMMGG);   NON VALORIZZATO PER GLI ENTI IN T.U. TAB. A
            r["VALUTASPECIALE"] = leggiNumerico(tr, 1);//NUMERICO		 1		21 INDICA UNA VALUTA FUORI DAGLI STANDARD; NON VALORIZZATO PER ENTI IN T.U. TAB. A  
            r["GIROFONDI"] = leggiNumerico(tr, 1);//NUMERICO		 1		22 INDICA CHE L’OPERAZIONE E’ AVVENUTA CON MODALITA’ GIROFONDI
            r["DIVISAOPERAZIONE"] = leggiAlfanumerico(tr, 1);//CARATTERE		 1		23 INDICA LA DIVISA DELL’OPERAZIONE SE DIVERSA DALLA DIVISA CON CUI L’ENTE INTRATTIENE IL RAPPORTO CON IL TESORIERE (9);	E   =   EURO	L   =   LIRE ; 	  BLANK NEGLI ALTRI CASI
            r["CONTROVALOREDIVISAOPERAZIONE"] = leggiDecimale(tr, 15);//NUMERICO		15		24 24)	CONTROVALORE DERIVATO DALLA CONVERSIONE TRA LE DUE DIVISE ZERO NEL CASO NON SIA STATA EFFETTUATA ALCUNA CONVERSIONE
            r["MODALITADIESECUZIONE"] = leggiAlfanumerico(tr, 1);//CARATTERE		 1		27
            //27)	MODALITA’ DI ESECUZIONE:
            //A = ASSEGNO CIRCOLARE
            //B = BONIFICO
            //C = CASSA
            //G = GIROFONDI
            //I = ASSEGNO CIRCOLARE N.T. INVIATO AL BENEFICIARIO	
            //L = ASSEGNO POSTALE LOCALIZZATO
            //P = BOLLETTINO POSTALE
            //R = REGOLARIZZAZIONE CARTA CONTABILE
            //S = STORNO
            //T = TRATTENUTE
            r["CARTACONTABILE"] = leggiNumerico(tr, 7);//NUMERICO		 7		28 CARTA CONTABILE REGOLARIZZATA DALL’ORDINATIVO/SUB INDICATO
            r["DATIRISERVATIALLENTE"] = leggiAlfanumerico(tr, 7);//CARATTERE		 7		29	 29)	DATI CHE L’ENTE HA INVIATO PER SUOI USI INTERNI
            r["DESCRIZIONEOPERAZIONE"] = leggiAlfanumerico(tr, 50);//CARATTERE 		50
            r["CRO_NUMEROASSEGNO"] = leggiLong(tr, 13);//NUMERICO		13		30 30)	SE LA MODALITA’ DI ESECUZIONE E’  BONIFICO, E’ VALORIZZATO CON IL CRO, SE E’ ASSEGNO CIRCOLARE CON IL NUMERO DELL’ASSEGNO. 
            r["FILLER"] = leggiAlfanumerico(tr, 16);//CARATTERE		16
            return vaiACapo(tr);
        }

        /// <summary>
        /// 03 - RECORD DI TOTALI
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        bool leggiRecordDiTotali(TextReader tr, DataRow r) {
            string segno;
            //			r["TIPORECORD"] = leggiNumerico(tr, 2);//NUMERICO		 2		 1
            r["PROGRESSIVODIFLUSSO3"] = leggiNumerico(tr, 5);//NUMERICO		 5		 2 PROGRESSIVO DEL RECORD ALL’INTERNO DEL FLUSSO
            r["RISCOSSIONIGIORNATA"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["PAGAMENTIGIORNATA"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["RISCOSSIONIGIORNATEPRECEDENTI"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["PAGAMENTIGIORNATEPRECEDENTI"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["RISCOSSIONITOTALI"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["PAGAMENTITOTALI"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["SALDOINIZIALE"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["SALDOALLADATARIFERIMENTO"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["SALDOFRUTTIFERO"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["SALDOINFRUTTIFERO"] = leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["ECCEDENZAGIACENZAMASSIMA"] = leggiDecimale(tr, 15);//NUMERICO		15		26 26)	PER ENTI IN TESORERIA UNICA TABELLA B
            r["FILLER3"] = leggiAlfanumerico(tr, 68);//CARATTERE		68
            return vaiACapo(tr);
        }

        bool leggiRecordDiCoda(TextReader tr, DataRow row) {
            int tipoRecord = leggiNumerico(tr, 2);
            Hashtable r = new Hashtable();
            //			r["TIPORECORD"] = tipoRecord;//NUMERICO		 2		 1
            /*r["PROGRESSIVODIFLUSSO1"] =*/
            leggiNumerico(tr, 5);//	NUMERICO		 5		 2 PROGRESSIVO DEL RECORD ALL’INTERNO DEL FLUSSO
            r["TIPOFLUSSO"] = leggiNumerico(tr, 3);//NUMERICO		 3		 3 INDICA LA TIPOLOGIA DEL FLUSSO IN TRASMISSIONE:      011    GIORNALE DI CASSA
            r["DATAPRODUZIONEFLUSSO"] = leggiDataAMG(tr, 8);//NUMERICO		 8		 4 ESPRESSO NEL FORMATO DATA   AAAAMMGG
            r["PROGRESSIVOPERDATA"] = leggiNumerico(tr, 1);//NUMERICO		 1		 5 UTILIZZATO IN CASO DI PIU’ FLUSSI INVIATI NELLA STESSA DATA ( PRIMO INVIO = 0 ) 
            r["CODICEFILIALE"] = leggiNumerico(tr, 5);//NUMERICO		 5		 6 CODICE DELLA FILIALE CHE EFFETTUA IL  SERVIZIO DI TESORERIA 
            r["CODICEENTE"] = leggiNumerico(tr, 3);//NUMERICO		 3		 7 CODICE DELL’ENTE FORNITO DALLA DIPENDENZA CHE EFFETTUA IL SERVIZIO DI TESORERIA 
            r["ANAGRAFICAENTE"] = leggiAlfanumerico(tr, 35);//CARATTERE		35
            r["ESERCIZIOFINANZIARIO"] = leggiNumerico(tr, 4);//(AAAA)			NUMERICO		 4
            r["DATADIRIFERIMENTO"] = leggiDataAMG(tr, 8);//NUMERICO		 8		 8 GIORNATA A CUI SI RIFERISCONO LE INFORMAZIONI CONTENUTE NEL FLUSSO (AAAAMMGG)
            r["DIVISA"] = leggiAlfanumerico(tr, 1);//CARATTERE		 1		 9
            r["FILLER1"] = leggiAlfanumerico(tr, 175);//CARATTERE	         175
            if (tipoRecord != 99) {
                QueryCreator.ShowError(null, "Mi aspettavo il record 1 invece ho ricevuto il record " + tipoRecord, "");
                return false;
            }
            foreach (DictionaryEntry de in r) {
                if (!row[(string)de.Key].Equals(de.Value)) {
                    QueryCreator.ShowError(null, "Errore durante la lettura del file",
                        "Differenze nella colonna " + de.Key
                        + "\r\nrecord 01: " + row[(string)de.Key]
                        + "\r\nrecord 99: " + de.Value);
                }
            }
            return vaiACapo(tr);
        }


    }

    class import_mps {
        public static DatiImportati ImportaFile(DataAccess Conn, string fname) {
            ImportazioneEsitiBancariMPS import = new ImportazioneEsitiBancariMPS(Conn);


            StreamReader sr = LetturaTracciati.getStreamReader(252, fname);
            if (sr == null) {
                return null;
            }

            bool res = import.parseFile(sr);

            if (!res) return null;

            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            return ConvertiFlussoBanca.GetDataFrom(esercizio, import.DS.flussobanca,true);
        }
    }
}
