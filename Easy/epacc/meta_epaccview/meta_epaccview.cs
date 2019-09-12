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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_epaccview
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_epaccview : Meta_easydata {
		public Meta_epaccview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "epaccview") {
			ListingTypes.Add("default");
            ListingTypes.Add("elencofaseprec");
            ListingTypes.Add("autogenerati");
			DefaultListType = "default";
		}
        private string[] mykey = new string[] { "idepacc", "ayear" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetStaticFilter(string ListingType) {
            string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
            string basefilter = base.GetStaticFilter(ListingType);
            if (basefilter == null || basefilter == "")
                return filteresercizio;
            return QHS.AppAnd(basefilter, filteresercizio);
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "elencofaseprec" || ListingType == "default") {
                sorting = "yliv1 desc, nliv1 desc, yepacc desc,nepacc desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }
        public void CompletaCaption(DataTable T) {

            foreach (DataColumn C in T.Columns) {
                if ((C.ColumnName == "nphase") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".n_fase");
                    continue;
                }
                if ((C.ColumnName == "phase") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".fase");
                    continue;
                }
                if ((C.ColumnName == "yepmov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".esercizio mov");
                    continue;
                }
                if ((C.ColumnName == "nepmov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Numero mov");
                    continue;
                }
                if ((C.ColumnName == "parentyepmov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Esercizio padre");
                    continue;
                }
                if ((C.ColumnName == "parentnepmov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Numero padre");
                    continue;
                }
                if ((C.ColumnName == "ayear") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Esercizio contabile");
                    continue;
                }
                if ((C.ColumnName == "codeacc") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod Conto");
                    continue;
                }
                if ((C.ColumnName == "account") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Conto");
                    continue;
                }
                if ((C.ColumnName == "codeupb") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod UPB");
                    continue;
                }
                if ((C.ColumnName == "upb") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".UPB");
                    continue;
                }
                if ((C.ColumnName == "idreg") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod Anagrafica");
                    continue;
                }
                if ((C.ColumnName == "registry") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Anagrafica");
                    continue;
                }
                if ((C.ColumnName == "cf") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Cod Fiscale");
                    continue;
                }
                if ((C.ColumnName == "p_iva") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Partita iva");
                    continue;
                }
                if ((C.ColumnName == "manager") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Responsabile");
                    continue;
                }
                if ((C.ColumnName == "doc") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Doc Collegato");
                    continue;
                }
                if ((C.ColumnName == "docdate") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Data Doc Collegato");
                    continue;
                }
                if ((C.ColumnName == "description") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Descrizione");
                    continue;
                }
                if ((C.ColumnName == "amount") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Importo Originale");
                    continue;
                }
                if ((C.ColumnName == "curramount") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Importo Corrente");
                    continue;
                }
                if ((C.ColumnName == "available") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Importo Disponibile");
                    continue;
                }
                //Campi per esercizi futuri
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                if ((C.ColumnName == "amount2") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Importo Originale " + (++esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "curramount2") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Importo Corrente " +(++esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "available2") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Importo Disponibile "+(++esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "amount3") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    esercizio = esercizio + 2;
                    DescribeAColumn(T, C.ColumnName, ".Importo Originale " + (esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "curramount3") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    esercizio = esercizio + 2;
                    DescribeAColumn(T, C.ColumnName, ".Importo Corrente " + (esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "available3") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    esercizio = esercizio + 2;
                    DescribeAColumn(T, C.ColumnName, ".Importo Disponibile " + (esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "amount4") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    esercizio = esercizio + 3;
                    DescribeAColumn(T, C.ColumnName, ".Importo Originale " + (esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "curramount4") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    esercizio = esercizio + 3;
                    DescribeAColumn(T, C.ColumnName, ".Importo Corrente " + (esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "available4") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    esercizio = esercizio + 3;
                    DescribeAColumn(T, C.ColumnName, ".Importo Disponibile " + (esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "amount5") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    esercizio = esercizio + 4;
                    DescribeAColumn(T, C.ColumnName, ".Importo Originale " + (esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "curramount5") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    esercizio = esercizio + 4;
                    DescribeAColumn(T, C.ColumnName, ".Importo Corrente " + (esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "available5") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    esercizio = esercizio + 4;
                    DescribeAColumn(T, C.ColumnName, ".Importo Disponibile " + (esercizio).ToString());
                    continue;
                }
                if ((C.ColumnName == "adate") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Data Contabile");
                    continue;
                }
                if ((C.ColumnName == "txt") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".appunti");
                    continue;
                }
                if ((C.ColumnName == "cost") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Costo");
                    continue;
                }
                if ((C.ColumnName == "revenue") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Ricavo");
                    continue;
                }
                if ((C.ColumnName == "credit") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Credito");
                    continue;
                }
                if ((C.ColumnName == "debit") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Debito");
                    continue;
                }
                if ((C.ColumnName == "fixedassets") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Immobilizzazioni");
                    continue;
                }
                if ((C.ColumnName == "freeusesurplus") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Avanzo libero");
                    continue;
                }
                if ((C.ColumnName == "rateiattivi") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Ratei attivi");
                    continue;
                }
                if ((C.ColumnName == "rateipassivi") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Ratei Passivi");
                    continue;
                }
                if ((C.ColumnName == "captiveusesurplus") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Avanzo vincolato");
                    continue;
                }
                if ((C.ColumnName == "reserve") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Riserva");
                    continue;
                }
            }
        }
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "yepacc", "Esercizio", nPos++);
                DescribeAColumn(T, "nepacc", "Numero", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "registry", "Fornitore/Cliente", nPos++);
                DescribeAColumn(T, "codeacc", "Codice conto", nPos++);
                DescribeAColumn(T, "account", "Conto", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "upb", "U.P.B.", nPos++);
                DescribeAColumn(T, "flagvariation", "Nota di Variazione", nPos++);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "curramount", esercizio.ToString(), nPos++);
                DescribeAColumn(T, "available", "Disp." + esercizio, nPos++);
                DescribeAColumn(T, "curramount2", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "available2", "Disp." + esercizio, nPos++);
                DescribeAColumn(T, "curramount3", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "available3", "Disp." + esercizio, nPos++);
                DescribeAColumn(T, "curramount4", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "available4", "Disp." + esercizio, nPos++);
                DescribeAColumn(T, "curramount5", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "available5", "Disp." + esercizio, nPos++);
                DescribeAColumn(T, "revenueavailable", "Disp.per Ricavi", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
                DescribeAColumn(T, "start", "Inizio Competenza", nPos++);
                DescribeAColumn(T, "stop", "Fine Competenza", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data Documento", nPos++);
                DescribeAColumn(T, "totalrevenue", "Ricavi totali", nPos++);
                DescribeAColumn(T, "totalcredit", "Crediti totali", nPos++);
                DescribeAColumn(T, "totamount", "Tolale Iniziale Pluriennale ", nPos++);
                DescribeAColumn(T, "totavailable", "Totale Disp. Pluriennale", nPos++);
                DescribeAColumn(T, "totcurramount", "Totale Corrente Pluriennale", nPos++);
                CompletaCaption(T);
			}
            if (listtype == "budgetupb") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "yepacc", "Esercizio", nPos++);
                DescribeAColumn(T, "nepacc", "Numero", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "registry", "Fornitore/Cliente", nPos++);
                DescribeAColumn(T, "codeacc", "Codice conto", nPos++);
                DescribeAColumn(T, "account", "Conto", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "upb", "U.P.B.", nPos++);
                DescribeAColumn(T, "flagvariation", "Nota di variazione", nPos++);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "amountwithsign", esercizio.ToString() + " (+/-, escluse var.)", nPos++);
                DescribeAColumn(T, "amountwithsign2", (++esercizio).ToString() + " (+/-, escluse var.)", nPos++);
                DescribeAColumn(T, "amountwithsign3", (++esercizio).ToString() + " (+/-, escluse var.)", nPos++);
                DescribeAColumn(T, "amountwithsign4", (++esercizio).ToString() + " (+/-, escluse var.)", nPos++);
                DescribeAColumn(T, "amountwithsign5", (++esercizio).ToString() + " (+/-, escluse var.)", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
                DescribeAColumn(T, "start", "Inizio Competenza", nPos++);
                DescribeAColumn(T, "stop", "Fine Competenza", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data Documento", nPos++);
                CompletaCaption(T);
            }
            if (listtype== "elencofaseprec") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int nPos = 1;
                DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                DescribeAColumn(T, "codeacc", "Cod Conto", nPos++);
                DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "curramount", "Imp. corrente", nPos++);
                DescribeAColumn(T, "available", "Disponibile", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
                CompletaCaption(T);
			}

             if(listtype== "autogenerati") {
				foreach(DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
				}
                int nPos = 1;
                DescribeAColumn(T, "idepacc", ".idepacc", nPos++);
                DescribeAColumn(T, "!livprecedente", "Livello Superiore", nPos++);
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "codeacc", "Conto", nPos++);
                DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "codemotive", "Causale EP", nPos++);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "amount", esercizio.ToString(), nPos++);              
                DescribeAColumn(T, "amount2", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "amount3", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "amount4", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "amount5", (++esercizio).ToString(), nPos++);
                CompletaCaption(T);                    
			}
		}  

	}
}
