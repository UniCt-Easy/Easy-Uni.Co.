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
using metaeasylibrary;
using metadatalibrary;


namespace meta_upbyearview
{
    /// <summary>
    /// Summary description for Meta_upbyearview.
    /// </summary>
    public class Meta_upbyearview : Meta_easydata
    {
        public Meta_upbyearview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "upbyearview")
        {
            ListingTypes.Add("entrata");
            ListingTypes.Add("spesa");
            ListingTypes.Add("daticontabili");
        }
        public override string GetNoRowFoundMessage(string listingtype) {
            return "Non è stato trovato alcun UPB del responsabile selezionato con disponibilità sufficiente.";
        }

        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "daticontabili") {
                return QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            }
            else {
                return base.GetStaticFilter(ListingType);
            }
        }
        string[] mykey = new string[] { "ayear", "idupb" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "income")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeupb", "Codice", nPos++);
                DescribeAColumn(T, "upb", "Denominazione", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "requested", "Finanziamento richiesto", nPos++);
                DescribeAColumn(T, "granted", "Finanziamento accordato", nPos++);
                DescribeAColumn(T, "assured", "Finanziamento certo", nPos++);
                
                //DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                //DescribeAColumn(T, "active", "U.P.B. Attivo", nPos++);
                //DescribeAColumn(T, "incomeprevision", "Previsione iniziale", nPos++);
                //DescribeAColumn(T, "incomeprevisionvar", "Variazioni previsione", nPos++);
                //DescribeAColumn(T, "currincomeprevision", "Previsione corrente", nPos++);
                //DescribeAColumn(T, "totincomecompetency", "Totale accertamenti", nPos++);
                DescribeAColumn(T, "incomeprevavailable", "Previsione disponibile", nPos++);
            }

            if (ListingType == "expense")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeupb", "Codice", nPos++);
                DescribeAColumn(T, "upb", "Denominazione", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "requested", "Finanziamento richiesto", nPos++);
                DescribeAColumn(T, "granted", "Finanziamento accordato", nPos++);
                DescribeAColumn(T, "assured", "Finanziamento certo", nPos++);
                //DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                //DescribeAColumn(T, "active", "U.P.B. Attivo", nPos++);
                //DescribeAColumn(T, "expenseprevision", "Previsione iniziale", nPos++);
                //DescribeAColumn(T, "expenseprevisionvar", "Variazioni previsione", nPos++);
                //DescribeAColumn(T, "currexpenseprevision", "Previsione corrente", nPos++);
                //DescribeAColumn(T, "totexpensecompetency", "Totale impegni", nPos++);
                DescribeAColumn(T, "expenseprevavailable", "Previsione disponibile", nPos++);
            }

            if (ListingType == "daticontabili") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeupb", "Codice", nPos++);
                DescribeAColumn(T, "upb", "Denominazione", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "codedivision", "Cod.Sezione", nPos++);
                DescribeAColumn(T, "division", "Sezione", nPos++);
                DescribeAColumn(T, "requested", "Finanziamento richiesto", nPos++);
                DescribeAColumn(T, "granted", "Finanziamento accordato", nPos++);
                DescribeAColumn(T, "assured", "Finanziamento certo", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "active", "U.P.B. Attivo", nPos++);
                DescribeAColumn(T, "cupcode", "Codice Unico di Progetto", nPos++);
                DescribeAColumn(T, "initialprevision", "Previsione iniziale Spesa", nPos++);
                DescribeAColumn(T, "currentprevision", "Previsione attuale Spesa", nPos++);
                DescribeAColumn(T, "initialsecondaryprev", "Previsione secondaria iniziale Spesa", nPos++);
                DescribeAColumn(T, "currentsecondaryprev", "Previsione secondaria attuale Spesa", nPos++);
                DescribeAColumn(T, "appropriation", "Impegnato", nPos++);
                DescribeAColumn(T, "expenseprevavailable", "Previsione disponibile Spesa", nPos++);
                DescribeAColumn(T, "payment", "Pagato", nPos++);

                DescribeAColumn(T, "incomeinitialprevision", "Previsione iniziale Entrata", nPos++);
                DescribeAColumn(T, "incomecurrentprevision", "Previsione attuale Entrata", nPos++);
                DescribeAColumn(T, "incomeinitialsecondaryprev", "Previsione secondaria iniziale Entrata", nPos++);
                DescribeAColumn(T, "incomecurrentsecondaryprev", "Previsione secondaria attuale Entrata", nPos++);
                DescribeAColumn(T, "assessment", "Accertato", nPos++);
                DescribeAColumn(T, "incomeprevavailable", "Previsione disponibile Entrata", nPos++);
                DescribeAColumn(T, "proceeds", "Incassato", nPos++);
                DescribeAColumn(T, "activity", "Tipo Attività", nPos++);
               	DescribeAColumn(T, "kindd", "Didattica", nPos++);
                DescribeAColumn(T, "kindr", "Ricerca", nPos++);
                DescribeAColumn(T, "treasurer", "Cassiere", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "cigcode", "CIG", nPos++);
                DescribeAColumn(T, "epupbkind", "Tipo UPB", nPos++);
                DescribeAColumn(T, "expiring", "Scadenza", nPos++);
                DescribeAColumn(T, "revenueprevision", "Ricavi Presunti", nPos++);
                DescribeAColumn(T, "costprevision", "Costi Presunti", nPos++);
            }
        }

    }
}
