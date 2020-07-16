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
using System.Text;
using metadatalibrary;
using System.IO;
using funzioni_configurazione;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using System.Collections;


namespace bankdispositionsetup_importnew {
    public static class ConvertiFlussoBanca {
        public static DatiImportati GetDataFrom(int esercizio, DataTable flusso) {
            return GetDataFrom(esercizio, flusso, false);
        }

        public static DatiImportati GetDataFrom(int esercizio,DataTable flusso,bool SimulaEsitiBollette) {
            DatiImportati I=new DatiImportati(esercizio);
            foreach (DataRow r in flusso.Rows) {

                int ndoc = CfgFn.GetNoNullInt32(r["NUMDOC"]);
                int ydoc = CfgFn.GetNoNullInt32(r["ESERC"]);
                if (ydoc != esercizio) continue;

                string indreg = r["INDREG"].ToString().ToUpper();

                string segno = r["SEGNO"].ToString(); //+ o -
                decimal amount = CfgFn.GetNoNullDecimal(r["IMPDOC"]); //l'importo ha già il segno presente in "SEGNO"
                //if (segno == "-") amount = -amount;
                int nprog = CfgFn.GetNoNullInt32(r["PRODOC"]);
                object datavaluta = r["DVAL"];
                object datatrans = r["DTPAG"];
                int nbolletta = CfgFn.GetNoNullInt32(r["NUMQUI"]);
                string beneficiario = r["ANABE"].ToString();
                string causale = r["CAUSALE"].ToString();
                string tipo = r["TIPDOC"].ToString().ToUpper();
                object sottoconto= r["NCNT"];

                if (tipo == "M") {
                    I.Mandati.Add(new RigaMandato(ydoc, ndoc, amount, datatrans, datavaluta,
                        beneficiario, causale, nbolletta, nprog));

                    //Se deve simulare l'esito delle bollette aggiunge l'esito della bolletta ove il movimento sia a copertura e c'è una bolletta
                    if (SimulaEsitiBollette && nbolletta > 0 && indreg == "R") {
                        //anche qui importo con segno perché devono andare di pari passo
                        I.EsitiBolletteSpesa.Add(new EsitoProvvisorio(ydoc, nbolletta, amount, datatrans));
                    }
                }

                if (tipo == "R") {
                    I.Reversali.Add(new RigaReversale(ydoc, ndoc, amount, datatrans, datavaluta,
                        beneficiario, causale, nbolletta, nprog));

                    //Se deve simulare l'esito delle bollette aggiunge l'esito della bolletta ove il movimento sia a copertura e c'è una bolletta
                    if (SimulaEsitiBollette && nbolletta > 0 && indreg == "R") {
                        //anche qui importo con segno perché devono andare di pari passo
                        I.EsitiBolletteEntrata.Add(new EsitoProvvisorio(ydoc, nbolletta, amount, datatrans));
                    }
                }

                //importazione bollette
                if (tipo == "I" && indreg!="R") {
                    I.BolletteEntrata.Add(new ProvvisorioEntrata(ydoc, nbolletta, amount, causale, beneficiario,
                                    datatrans, sottoconto));
                }

                if (tipo == "P" && indreg != "R") {
                    I.BolletteSpesa.Add(new ProvvisorioSpesa(ydoc, nbolletta, amount, causale, beneficiario,
                                    datatrans, sottoconto));
                }

                //esiti bollette
                if (tipo == "I" && indreg == "R" && !SimulaEsitiBollette) {
                    I.EsitiBolletteEntrata.Add(new EsitoProvvisorio(ydoc, nbolletta, amount, datatrans));
                }
                if (tipo == "P" && indreg == "R" && !SimulaEsitiBollette) {
                    I.EsitiBolletteSpesa.Add(new EsitoProvvisorio(ydoc, nbolletta, amount, datatrans));
                }
                    
            }
            return I;
        }
    }
}
