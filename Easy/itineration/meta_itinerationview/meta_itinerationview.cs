
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_itinerationview//meta_missioneview//
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_itinerationview : Meta_easydata {
        public Meta_itinerationview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "itinerationview") {
            ListingTypes.Add("lista");
            ListingTypes.Add("weblista");
            Name = "Missione";
        }

        public override string GetStaticFilter(string ListingType) {
            return base.GetStaticFilter(ListingType);
        }

        private string[] mykey = new string[] { "iditineration" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "lista") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "yitineration", "Eserc. miss.", nPos++);
                DescribeAColumn(T, "nitineration", "Num. miss.", nPos++);
                DescribeAColumn(T, "yref", "Eserc. miss. Riferimento", nPos++);
                DescribeAColumn(T, "nref", "Num. miss. Riferimento", nPos++);
                DescribeAColumn(T, "idreg", ".Cod. Percipiente", nPos++);
                DescribeAColumn(T, "registry", "Denom. Percipiente", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "location", "Località", nPos++);
                DescribeAColumn(T, "itinerationstatus", "Stato", nPos++);
                DescribeAColumn(T, "codeser", ".Cod. Prestazione", nPos++);
                DescribeAColumn(T, "service", "Prestazione", nPos++);
                DescribeAColumn(T, "authorizationdate", "Data autorizz.", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "adate", ".Data contabile", nPos++);
                DescribeAColumn(T, "grossfactor", ".Coeff. di lordizzazione", nPos++);
                DescribeAColumn(T, "netfee", "Importo Netto", nPos++);
                DescribeAColumn(T, "totalgross", "Importo Lordo", nPos++);
                DescribeAColumn(T, "total", "Costo Totale", nPos++);
                DescribeAColumn(T, "totadvance", "Anticipo", nPos++);
                DescribeAColumn(T, "advancelinked", "Anticipo Erogato", nPos++);
                DescribeAColumn(T, "totlinked", "Totale Erogato", nPos++);
                DescribeAColumn(T, "totresidual", "Residuo da erogare", nPos++);

                //DescribeAColumn(T, "position", "Qualifica", nPos++);
                //DescribeAColumn(T, "incomeclass", "Classe stip.", nPos++);
                //DescribeAColumn(T, "incomeclassvalidity", "Decorrenza classe stip.", nPos++);
                DescribeAColumn(T, "extmatricula", ".Matricola", nPos++);
                DescribeAColumn(T, "foreigngroupnumber", "Gruppo estero", nPos++);
                DescribeAColumn(T, "totnoaccountsaldo", "Totale non rendicontabile", nPos++);

                DescribeAColumn(T, "codemotive", "Cod.Causale di costo", nPos++);
                DescribeAColumn(T, "accmotive", "Causale di costo", nPos++);
                DescribeAColumn(T, "codemotivedebit", "Cod.Causale di debito", nPos++);
                DescribeAColumn(T, "accmotivedebit", "Causale di debito", nPos++);
                DescribeAColumn(T, "codemotivedebit_crg", "Cod.Causale di debito aggiornata", nPos++);
                DescribeAColumn(T, "accmotive_crg", "Causale di debito aggiornata", nPos++);
                DescribeAColumn(T, "idaccmotivedebit_datacrg", "Data Correz. Causale di debito", nPos++);
                DescribeAColumn(T, "datecompleted", "Data Doc. Definitiva", nPos++);
                DescribeAColumn(T, "codeupb", ".Codice UPB", nPos++);
                DescribeAColumn(T, "owncarkm", ".Km mezzo proprio", nPos++);
                DescribeAColumn(T, "owncarkmcost", ".EUR Km mezzo proprio", nPos++);
                DescribeAColumn(T, "admincarkm", ".Km mezzo amministrazione", nPos++);
                DescribeAColumn(T, "admincarkmcost", ".Eur Km mezzo amministrazione", nPos++);
            }


            if (listtype == "weblista") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "statusimage", "Stato", nPos++);
                DescribeAColumn(T, "yitineration", "Eserc. miss.", nPos++);
                DescribeAColumn(T, "nitineration", "Num. miss.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "idreg", ".Cod. Percipiente", nPos++);
                DescribeAColumn(T, "registry", "Denom. Percipiente", nPos++);
                //DescribeAColumn(T, "codeser", ".Cod. Prestazione", nPos++);
                DescribeAColumn(T, "service", "Prestazione", nPos++);
                //DescribeAColumn(T, "authorizationdate", "Data autorizz.", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
                //DescribeAColumn(T, "grossfactor", "Coeff. di lordizzazione", nPos++);
                //DescribeAColumn(T, "netfee", "Importo Netto", nPos++);
                //DescribeAColumn(T, "totalgross", "Importo Lordo", nPos++);
                DescribeAColumn(T, "total", "Costo Totale", nPos++);
                DescribeAColumn(T, "totadvance", "Anticipo", nPos++);
                //DescribeAColumn(T, "position", "Qualifica", nPos++);
                //DescribeAColumn(T, "incomeclass", "Classe stip.", nPos++);
                //DescribeAColumn(T, "incomeclassvalidity", "Decorrenza classe stip.", nPos++);
                //DescribeAColumn(T, "extmatricula", "Matricola", nPos++);
                //DescribeAColumn(T, "foreigngroupnumber", "Gruppo estero", nPos++);
                DescribeAColumn(T, "totnoaccountsaldo", "Totale non rendicontabile", nPos++);
                DescribeAColumn(T, "advancelinked", "Anticipo Erogato", nPos++);
                DescribeAColumn(T, "totlinked", "Totale Erogato", nPos++);
                DescribeAColumn(T, "totresidual", "Residuo da erogare", nPos++);
                DescribeAColumn(T, "datecompleted", "Data Doc. Definitiva", nPos++);
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);

            }

        }
    }
}
