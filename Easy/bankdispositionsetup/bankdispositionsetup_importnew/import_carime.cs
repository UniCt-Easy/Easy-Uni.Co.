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


    public class ImportazioneEsitiBancariCarime : LetturaTracciati {
        public ImportazioneEsitiBancariCarime(DataAccess Conn)
            :
            base(Conn) {
        }

        public override BANCA getBanca() {
            return BANCA.CARIME;
        }


        public bool parseCarimeFile(StreamReader sr) {
            ArrayList altriEsercizi = new ArrayList();
            DS.carime.Clear();

            Hashtable ht = new Hashtable();
            // La 1° posizione indica il Tipo Documento= TIPDOC, assume valori:
            //          M = mandato, R = reversale, I = part pend. incasso, P = part. Pend. pagamento
            // La 2° posizione indica il SEGNO.
            // La 3° posizione INDREG indica la regolarizzazione. Se valorizzaro a “R” trattasi di regolarizzazione.
            // Il movimento che agisce sulla bolletta c'ha sempre la R, sia esso Storno, Regolarizzazione, Annullo
            // L'apertura bolletta: non ha R, nella 3° posizione.
            // Chiusura bolletta, storno bolletta e regolarizzazione: ha R nella 3° posizione.
            // Il segno meno va inserito se e solo se Storni.

            ht["001"] = "R+ ";  //Riscossione Reversale
            ht["002"] = "R- ";  //Storno di Reversale  (banca fornisce il segno +)
            ht["021"] = "R+R";  //Regolarizzazione Reversale
            ht["022"] = "R-R";  //Annullo regolarizzazione reversale = storno movimento reversale  (banca fornisce il segno +)

            ht["003"] = "I+ ";  //Apertura partita pendente incasso. 
            ht["004"] = "I- ";  //Storno Provvisorio Entrata (banca fornisce il segno -)
            ht["023"] = "I+R";  //Regolarizzazione provvisorio entrata. Verranno Saltati non ci serve il dato della regolarizzazione della bolletta, perchè è un dato che non memorizziamo.
                                        //(banca fornisce il segno -)
            ht["024"] = "I-R";  //Annullo Regolarizzazione provvisorio entrata= Storno movimenti provvisorio entrata.  (banca fornisce il segno +)


            ht["011"] = "M+ ";  //Pagamento Mandato 
            ht["012"] = "M- ";  //Storno Mandati (banca fornisce il segno +)
            ht["031"] = "M+R";  //Regolarizzazione Mandato
            ht["032"] = "M-R";  //Annullo regolarizzazione Mandato = storno movimento Mandato (banca fornisce il segno +)
            
            ht["013"] = "P+ ";  //Apertura partita pendente pagamento
            ht["014"] = "P- ";  //Storno Provvisorio Uscita (banca fornisce il segno -)
            ht["033"] = "P+R";  //Regolarizzazione provvisorio Uscita. Verranno Saltati non ci serve il dato della regolarizzazione della bolletta, perchè è un dato che non memorizziamo.
                                        //(banca fornisce il segno -)
            ht["034"] = "P-R";  //Annullo Regolarizzazione provvisorio Uscita = Storno movimenti provvisorio Uscita.  (banca fornisce il segno +)

            ht["015"] = "M+ ";  //Disposizioni Uscita se NSUB > 0, è un Provvisorio di Uscita = 013 se NSUB= 0
            ht["016"] = "M- ";  //Storno Disposizioni Uscita      (banca fornisce il segno +)

            //segni da cambiare: 002 012 022 023 024  032 033 034 016








            while (sr.Peek() != -1) {
                DataRow r = DS.carime.NewRow();
                if (!leggiRigaCarime(sr, ht, r)) {
                    return false;
                }
                if (CfgFn.GetNoNullInt32(r["codiceesercizio"]) == CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"))) {
                    if (
                        //r["tipomovimento"].ToString() != "024") && 
                        (r["tipomovimento"].ToString() != "040")
                        && (r["tipomovimento"].ToString() != "049")
                        && (r["tipomovimento"].ToString() != "042")
                        && (r["tipomovimento"].ToString() != "043")
                        && (r["tipomovimento"].ToString() != "044")
                        && (r["tipomovimento"].ToString() != "050")
                        && (r["tipomovimento"].ToString() != "051")
                        && (r["tipomovimento"].ToString() != "052")
                        && (r["tipomovimento"].ToString() != "053")
                        && (r["tipomovimento"].ToString() != "054")
                        ) {
                        DS.carime.Rows.Add(r);
                    }
                }
                else {
                    if (!altriEsercizi.Contains(r["codiceesercizio"])) {
                        altriEsercizi.Add(r["codiceesercizio"]);
                    }
                }
            }
            sr.Close();
            copia_Carime_IN020304();

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
                MessageBox.Show(messaggio,"Avviso");
            }
            return true;
        }

        private bool leggiRigaCarime(TextReader tr, Hashtable ht, DataRow r) {
            r["codiceistituto"] = leggiNumerico(tr, 5);          //CIST
            r["codicedipendenza"] = leggiNumerico(tr, 5);         //CDIP
            r["codiceente"] = leggiNumerico(tr, 7);              //CENT
            r["codiceesercizio"] = leggiNumerico(tr, 4);         //CESE
            r["codicedivisaente"] =leggiAlfanumerico(tr, 3);    //CDIVENT
            r["abi"] = leggiNumerico(tr, 5);                     //CABICCO
            r["cab"] = leggiNumerico(tr, 5);                     //CCABCCO
            r["numeroconto"] = leggiAlfanumerico(tr, 12);        //NCNTCCO
            r["datamovimento"] = leggiDataAMG(tr, 8);            //DMOV

            string tipomovimento = leggiAlfanumerico(tr, 3);     //CMOV

            r["numdocumento"] = leggiNumerico(tr, 7);        //NDOC
            r["numsub"] = leggiNumerico(tr, 7);              //NSUB

            // Il Tipo mov. 15-'Disp. di uscita' equivale al mov. 11-'Pagamento mandato' se NSUB >0
            // Il Tipo mov. 15-'Disp. di uscita' equivale al mov. 13-'Apertura partita pendente pagamento' se NSUB = 0
            int NSUB = CfgFn.GetNoNullInt32(r["numsub"]);
            if (tipomovimento == "015") {
                if (NSUB > 0) {
                    r["tipomovimento"] = "011";
                    tipomovimento = "011";
                }
                else {
                    r["tipomovimento"] = "013";
                    tipomovimento = "013";
                }
            }
            else {
                r["tipomovimento"] = tipomovimento;
            }




            r["numricevuta"] = leggiNumerico(tr, 7);         //NRIC
            r["numcapitolo"] = leggiNumerico(tr, 7);         //NCAP
            r["numarticolo"] = leggiNumerico(tr, 3);         //NART
            r["annoresiduo"] = leggiNumerico(tr, 2);
            r["codicedivisacliente"] = leggiAlfanumerico(tr, 3); //CDIVCLI
            r["importodivisacliente"] = leggiDecimale(tr, 15);   //IDIVCLI

            string segno;
            r["importoricevuta"] = leggiDecimaleCarime(tr, out segno);//IRIC
            
            // Nel caso di
            // Storno Reversale,Storno Mandati,Storno Disposizione di Uscita,Annullo Regolarizzazione Reversale,Annullo Regolarizzazione Mandato
            // noi consideriamo l'importo negativo
            // In questi 4 casi l'importo segnalato dalla banca è positivo ma noi lo cambiamo perché la nostra gestione prevede un segno opposto
            //    segni da cambiare:002 012 016 022 023 024  032 033 034 
            if ((tipomovimento == "002") || (tipomovimento == "012") || (tipomovimento == "016")
                    || (tipomovimento == "022") || (tipomovimento == "023")  || (tipomovimento == "024")
                    || (tipomovimento == "032") || (tipomovimento == "033") || (tipomovimento == "034")
                     
                ) {
                r["importoricevuta"] = -(decimal)r["importoricevuta"];
            }

            r["segno"] = segno;

            if (tipomovimento == "016") {
                if (NSUB > 0) {  //Storno Disposizione di Uscita con nsub lo consideriamo come uno Storno Mandati 
                    r["tipomovimento"] = "012";
                    tipomovimento = "012";
                }
                else {   //Storno disposizione di Uscita senza nsub lo consideriamo come uno Storno Provvisorio Uscita
                    r["tipomovimento"] = "014";
                    tipomovimento = "014";
                    segno = "-";
                    r["segno"] = segno;
                }
            }
            else {
                r["tipomovimento"] = tipomovimento;
            }

            // A quanto dice lui, 4 Storno Provvisorio Entrata  14 Storno Provvisorio Uscita 23 Regolarizzazione Provvisorio Entrata e 33 Regolarizzazione Provvisorio Uscita
            // dovrebbero avere il segno - 


            // In base alla combinazione dei 3 campi della Hashtable, valorizza TIPDOC, SEGNO e INDREG
            object o = ht[tipomovimento];

            // I tipi 040 e 049, 042,043,044, 050,051,052 sono NON UTILIZZATO, però posso essere presenti nel file degli esiti, quindi li trascuriamo e NON li aggiungeremo 
            // alla tabella. 
            bool tipoInutilizzato = (
                    //(tipomovimento == "023") || (tipomovimento == "024") || (tipomovimento == "033") || (tipomovimento == "034") ||
                     (tipomovimento == "042") || (tipomovimento == "043") || (tipomovimento == "044")
                    || (tipomovimento == "040") || (tipomovimento == "049")   
                    || (tipomovimento == "050")|| (tipomovimento == "051") || (tipomovimento == "052")
                    || (tipomovimento == "053") || (tipomovimento == "054")
                    );


            if ((o == null) && (!tipoInutilizzato)) {
                string messaggio = "";
                foreach (object t in ht.Keys) {
                    messaggio += ", " + t;
                }
                QueryCreator.ShowError(null, "Tipo di movimento sconosciuto: " + tipomovimento, "I tipi di movimento accettati sono:\n" + messaggio.Substring(2));
                return false;
            }

            if (!tipoInutilizzato) {
                //flag[1] è il segno atteso in base alla nostra conoscenza dell'operazione
                //segno è il segno trovato nel campo importo
                // ai tipi 2,12,16,22,32 però abbiamo cambiato il segno del movimento perché il tracciato lavora in logica positiva mentre a noi serviva il segno negativo.
                //  in part
                //verifica che il segno dell'importo deve essere quello della hash table tranne per i casi 2 12 16 22 32
                string flag = (string)o;
                r["tipdoc"] = flag[0];
                r["segno"] = flag[1];
                r["indreg"] = flag[2];
                bool b1 = segno.Equals(r["segno"]);
                //002 012 016 022 023 024  032 033 034 
                bool b2 = ((tipomovimento == "002") || (tipomovimento == "012")  || (tipomovimento == "016")
                            || (tipomovimento == "022") || (tipomovimento == "023") || (tipomovimento == "024")
                            || (tipomovimento == "032") || (tipomovimento == "033") || (tipomovimento == "034")                                                        
                            );
                if (b1 == b2) {
                    QueryCreator.ShowError(null, "Errore nel segno di un importo\n" + tipomovimento + ": " + flag, "Errore durante la lettura del file");
                    return false;
                }
            }



            r["codiceesecuzione"] = leggiNumerico(tr, 3);            //CECZ
            r["codicebolli"] = leggiNumerico(tr, 3);                 //CBLL
            r["importibolli"] = leggiDecimale(tr, 9);                //IBLL
            r["codicespese"] = leggiNumerico(tr, 3);                 //CSPE
            r["importospese"] = leggiDecimale(tr, 9);                //ISPE
            r["datavaluta"] = leggiDataAMG(tr, 8);                   //DVAL
            r["numdocrif"] = leggiNumerico(tr, 7);                   //NDOCRIF
            r["numsubrif"] = leggiNumerico(tr, 3);                   //NSUBRIF
            r["abicliente"] = leggiNumerico(tr, 5);                  //CABICLI
            r["cabcliente"] = leggiNumerico(tr, 5);                  //CCABCLI
            r["descrizionecliente"] = leggiAlfanumerico(tr, 30);       //ZANACLI
            r["codicecausale"] = leggiNumerico(tr, 3);               //CCAU
            r["causale1"] = leggiAlfanumerico(tr, 30);               //ZCAU1
            r["causale2"] = leggiAlfanumerico(tr, 30);               //ZCAU2 
            r["causale3"] = leggiAlfanumerico(tr, 30);               //ZCAU3
            r["codicetipoimputazione"] = leggiAlfanumerico(tr, 3);       //CTIPIPU

            r["imputazionefruttifera"] = leggiNumerico(tr, 1);       //SFRUIPU
            r["imputazioneinfruttifera"] = leggiNumerico(tr, 1);     //SIFRIPU
            r["imputazionevincolata"] = leggiNumerico(tr, 1);        //SVINIPU
            r["imputazionedelegazioni"] = leggiNumerico(tr, 1);      //SDELIPU
            r["imputazionegiornaliera"] = leggiNumerico(tr, 1);      //SGIOIPU
            r["destfruttiferainfruttifera"] = leggiNumerico(tr, 1);  //S001IPU
            r["indicatoreadisposizione"] = leggiNumerico(tr, 1);     //S002IPU
            r["entratauscita"] = leggiAlfanumerico(tr, 1);           //SEOU
            r["codicedivisaesercizio"] = leggiAlfanumerico(tr, 3);   //CDIVESE
            r["importodivisaente"] = leggiDecimale(tr, 17);          //IDIVENT
            r["space01"] = leggiAlfanumerico(tr, 10);                //CCOD1
            r["space02"] = leggiAlfanumerico(tr, 10);                //CCOD2
            r["space03"] = leggiAlfanumerico(tr, 10);                //CCOD3
            r["codiceresiduo"] = leggiNumerico(tr, 4);               //CRES
            r["numerosubcaricati"] = leggiNumerico(tr, 7);           //NSUBCAR
            r["numerosottoconto"] = leggiAlfanumerico(tr, 7);            //NCNT
            r["cf"] = leggiAlfanumerico(tr, 16);                     //CFISCLI
            r["codicefornitore"] = leggiNumerico(tr, 7);             //CFOR
            r["numerocro"] = leggiAlfanumerico(tr, 16);              //NCRO
            r["numeroassegnoda"] = leggiAlfanumerico(tr, 16);        //NASSDA
            r["numeroassegnoa"] = leggiAlfanumerico(tr, 16);         // NASSA
            r["descrizionecausaleaggiuntiva"] = leggiAlfanumerico(tr, 90);  //ZCAU4
            r["codicebeneficiario"] = leggiAlfanumerico(tr, 16);     //CBEN
            r["filler"] = leggiAlfanumerico(tr, 242);                //FILLER
            return vaiACapo(tr);
        }
        private void copia_Carime_IN020304() {
            //Quando viene regolarizzato un mandato, ossia in presenza del TipoMov 031 vi è anche il TipoMov 033 (regolarizz. provv.uscita). Idem per 021 e 023, per le reversali.
            //Per quanto riguarda gli annullamenti di regolarizzazioni, la situazione è speculare.
            //Quando viene annullata la regolarizzazione di un mandato, ossia in presenza del TipoMov 032 vi è anche il TipoMov 034. 
            // Idem per 022 e 024, per le reversali.
            // Nel 031 abbiamo l'info del num.doc., mentre nel 033 abbiamo l'info del num. bolletta. Il legame tra i due è dato da NRIC.
            // Quindi, facciamo un ciclo preliminare per elaborare  i record 023, 024, 033, 034 e memorizzare in quattro hashtable NRIC. 
            // Queste verranno interrogate dopo

            //queste rappresentano n. di bolletta, le leggiamo dai record 23,24,33,34
            Hashtable nbolletta_entrata = new Hashtable(); //Regolarizzazione e annullo Provvisorio Entrata  23,24 
            Hashtable nbolletta_uscita = new Hashtable(); //Regolarizzazione e annullo Provvisorio Uscita 33,34
            
            //queste rappresentano i record corrispondenti, nei documenti
            //Hashtable doc_entrata  = new Hashtable(); //Regolarizzazione e annullo  Reversale 21,22
            //Hashtable doc_uscita = new Hashtable(); //Regolarizzazione e annullo Mandato 31,32

            string filtroRec023Rec033 = QHC.AppOr(QHC.CmpEq("tipomovimento", "023"), QHC.CmpEq("tipomovimento", "033"), QHC.CmpEq("tipomovimento", "024"),
               QHC.CmpEq("tipomovimento", "034"));

            //i tipi 23,24,33,34 a nel campo numdocumento hanno il n.bolletta mentre nel campo numricevuta un numero imprecisato
            foreach (DataRow s in DS.carime.Select(filtroRec023Rec033)) {
                if (s["numricevuta"].ToString() == "") continue;
                object nric = s["numricevuta"];
                if (s["tipomovimento"].ToString() == "023" || s["tipomovimento"].ToString() == "024") {
                    nbolletta_entrata[nric] = s["numdocumento"];
                }
                if (s["tipomovimento"].ToString() == "033" || s["tipomovimento"].ToString() == "034") {
                    nbolletta_uscita[nric] = s["numdocumento"];
                }

                ////// new
                ////if (s["tipomovimento"].ToString() == "033"){
                ////    object NBolletta = s["numdocumento"];
                ////    HT033_[NBolletta] = s["numricevuta"];
                ////}
                ////if (s["tipomovimento"].ToString() == "031"){
                ////    object NRIC = s["numricevuta"];
                ////    HT031_[NBolletta] = s["beneficiario"];
                ////}
            }


            //string filtroRec021Rec031 = QHC.AppOr(QHC.CmpEq("tipomovimento", "021"), QHC.CmpEq("tipomovimento", "022"), QHC.CmpEq("tipomovimento", "031"),
            //   QHC.CmpEq("tipomovimento", "032"));
            //foreach (DataRow s in DS.carime.Select(filtroRec021Rec031)) {
            //    if (s["numricevuta"].ToString() == "") continue;
            //    object nric = s["numricevuta"];

            //    if (s["tipomovimento"].ToString() == "021" || s["tipomovimento"].ToString() == "022") {
            //        doc_entrata[nric] = s;
            //    }
            //    if (s["tipomovimento"].ToString() == "031" || s["tipomovimento"].ToString() == "032") {
            //        doc_uscita[nric] = s;
            //    }
                
            //}



            DS.flussobanca.Clear();
            foreach (DataRow s in DS.carime.Rows) {
                string tipoMov = s["tipomovimento"].ToString();
                DataRow r = DS.flussobanca.NewRow();
                r["CODEN"] = s["codiceente"];
                r["ESERC"] = s["codiceesercizio"];
                r["TIPDOC"] = s["tipdoc"];

                // Per i TipoMov. 003, 013, 004 e 014 Il numero documento rappresenta il numero del Provvisorio, ossia il numero della bolletta.
                if ((s["tipomovimento"].ToString() == "003") || (s["tipomovimento"].ToString() == "013") ||
                    (s["tipomovimento"].ToString() == "004") || (s["tipomovimento"].ToString() == "014")
                    ) {
                    r["NUMDOC"] = DBNull.Value;
                    r["NUMQUI"] = s["numdocumento"];
                }
                /*
                // Il TipoMov 016 è lo storno della disposizione di Uscita. 
                if (s["tipomovimento"].ToString() == "016") {
                        if(CfgFn.GetNoNullInt32(s["numsub"])>0){
                            // NSUB >0 : identifica lo storno di un mandato
                                r["NUMDOC"] = s["numdocumento"];
                                r["NUMQUI"] = DBNull.Value;
                            }
                        else {
                            // NSUB = 0 : identifica lo storno di un provvisorio
                            r["NUMDOC"] = DBNull.Value;
                            r["NUMQUI"] = s["numdocumento"];
                            }
                    }
                */
                //riscossione/annullo mandati e reversali
                if ((s["tipomovimento"].ToString() == "001") || (s["tipomovimento"].ToString() == "002") ||
                    (s["tipomovimento"].ToString() == "011") || (s["tipomovimento"].ToString() == "012")) {
                    r["NUMDOC"] = s["numdocumento"];
                    r["NUMQUI"] = DBNull.Value;
                }

                ////i tipi 23,24, regolarizzazione e annullo bolletta entrata. In numdocumento c'è il num.bolletta
                if ((s["tipomovimento"].ToString() == "023") || (s["tipomovimento"].ToString() == "024")
                        ) {                            
                            r["NUMQUI"] = s["numdocumento"];
                            //object nric = r["numricevuta"];
                            //if (nric.ToString() != "" && doc_entrata[nric] != null) {
                            //    DataRow source = (DataRow)doc_entrata[nric];
                            //    r["NUMDOC"] = source["numdocumento"];
                            //    r["numsub"] = source["numsub"];
                            //}
                            //else {
                            //    r["NUMDOC"] = DBNull.Value;
                            //    r["numsub"] = DBNull.Value;
                            //}
                            r["NUMDOC"] = DBNull.Value;
                            s["numsub"] = DBNull.Value;
                }

                if ((s["tipomovimento"].ToString() == "033") || (s["tipomovimento"].ToString() == "034")){                            
                            r["NUMQUI"] = s["numdocumento"];
                            //object nric = r["numricevuta"];
                            //if (nric.ToString() != "" && doc_uscita[nric] != null) {
                            //    DataRow source = (DataRow)doc_uscita[nric];
                            //    r["NUMDOC"] = source["numdocumento"];
                            //    r["numsub"] = source["numsub"];
                            //}
                            //else {
                            //    r["NUMDOC"] = DBNull.Value;
                            //    r["numsub"] = DBNull.Value;
                            //}
                            r["NUMDOC"] = DBNull.Value;
                            s["numsub"] = DBNull.Value;
                }


                //Regolarizzazione o annullo Reversale
                // nell'annullo di regolarizzazione di reversale si deve valorizzare il numero di provvisorio 
                // prendendolo dalla riga 023 (regolarizzazione provvisorio entrata), solo che questa riga potrebbe essere assente
                // si potrebbe leggere il numero provvisorio anche dalla riga 024 con lo stesso numero ricevuta
                if (s["tipomovimento"].ToString() == "021" || s["tipomovimento"].ToString() == "022") { 
                    object NRIC = s["numricevuta"];
                    r["NUMDOC"] = s["numdocumento"];
                    if (nbolletta_entrata[NRIC] != null)
                        r["NUMQUI"] = nbolletta_entrata[NRIC];
                    else
                        r["NUMQUI"] = DBNull.Value;
                }

                if (s["tipomovimento"].ToString() == "031" || s["tipomovimento"].ToString() == "032") {
                    object NRIC = s["numricevuta"];
                    r["NUMDOC"] = s["numdocumento"];
                    if (nbolletta_uscita[NRIC] != null)
                        r["NUMQUI"] = nbolletta_uscita[NRIC];
                    else
                        r["NUMQUI"] = DBNull.Value;
                }
               

                r["PRODOC"] = s["numsub"];
                r["CAPBIL"] = s["numcapitolo"];
                r["ARTBIL"] = s["numarticolo"];
                r["IMPDOC"] = s["importoricevuta"];
                r["SEGNO"] = s["segno"];
                r["DTELAB"] = s["datamovimento"];// Da rivedere (?)
                r["DTPAG"] = s["datamovimento"];                
                r["DVAL"] = s["datavaluta"];

                if (s["tipomovimento"].ToString() == "021" || s["tipomovimento"].ToString() == "031"
                     || s["tipomovimento"].ToString() == "022" || s["tipomovimento"].ToString() == "032") {
                    if (s["datamovimento"] == DBNull.Value && s["datavaluta"] != DBNull.Value) {
                        r["DTPAG"] = s["datavaluta"];
                    }
                }

                r["INDREG"] = s["indreg"];
                r["DVALBE"] = DBNull.Value; // s["datavalutabeneficiario"];// Da rivedere (?)
                r["IBOLLI"] = s["importibolli"];
                r["INDBOL"] = s["codicebolli"];
                r["ISPE"] = s["importospese"];
                r["INDSPE"] = s["codicespese"];
                r["TPAGTS"] = s["codiceesecuzione"];// Da rivedere 
                r["CODABI"] = s["abicliente"];
                r["CODCAB"] = s["cabcliente"];
                //r["CONTO"] = s["conto"];    // DA RIVEDERE : NEL TRACCIATO MANCA
                //r["CIN"] = s["cin"];// DA RIVEDERE : NEL TRACCIATO MANCA
                r["NCNT"] = s["numerosottoconto"];
                r["ANABE"] = s["descrizionecliente"];
                r["CFISC"] = s["cf"];
                r["CAUSALE"] = s["codicecausale"];
                r["FILLER"] = s["tipomovimento"];
                r["CAUSALE"] = s["causale1"].ToString() + s["causale2"].ToString() + s["causale3"].ToString();
                if ((s["tipomovimento"].ToString() == "003") || (s["tipomovimento"].ToString() == "013"))
                    r["CAUSALE"] = "(Imputaz." + s["codicetipoimputazione"].ToString() + ")" + r["CAUSALE"].ToString();

                // I TipiRec 023 e 033 e anche 024 - 034non li passiamo al motore degli esiti, sono serviti solo per valorizzare il num.bolletta di Rec. 021 e 031
                //if ((s["tipomovimento"].ToString() != "023") && (s["tipomovimento"].ToString() != "033") &&
                //    (s["tipomovimento"].ToString() != "024") && (s["tipomovimento"].ToString() != "034")) {
                //    DS.flussobanca.Rows.Add(r);
                //}
                DS.flussobanca.Rows.Add(r);
            }
            DS.carime.Clear();
        }

    }

    public static class import_carime {

        public static DatiImportati ImportaFile(DataAccess Conn, string fname) {
            ImportazioneEsitiBancariCarime import = new ImportazioneEsitiBancariCarime(Conn);

            StreamReader sr = LetturaTracciati.getStreamReader(802, fname);
            if (sr == null) {
                return null;
            }

            bool res = import.parseCarimeFile(sr);
            if (!res) return null;
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            return ConvertiFlussoBanca.GetDataFrom(esercizio,import.DS.flussobanca);
        }
        
    }
}