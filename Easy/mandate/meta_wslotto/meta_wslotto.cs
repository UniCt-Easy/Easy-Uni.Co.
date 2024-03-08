
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_wslotto {
    /// <summary>
    /// 
    /// </summary>
    public class Meta_wslotto : Meta_easydata {
        public Meta_wslotto(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "wslotto") {
            ListingTypes.Add("default");
            Name = "gare";
        }
        private string[] mykey = new string[] { "idGara", "idLotto" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "idGara asc, idLotto asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public void CompletaCaption(DataTable T) {

            foreach (DataColumn C in T.Columns) {
                if ((C.ColumnName == "idLotto") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".#Id Lotto");
                    continue;
                }
                if ((C.ColumnName == "idGara") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".#Id Gara");
                    continue;
                }
                if ((C.ColumnName == "cig") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".CIG");
                    continue;
                }
                if ((C.ColumnName == "spCodiceFiscale") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".SP Codice Fiscale");
                    continue;
                }
                if ((C.ColumnName == "spDenominazione") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".SP Denominazione");
                    continue;
                }
                if ((C.ColumnName == "oggetto") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Oggetto");
                    continue;
                }
                if ((C.ColumnName == "sceltaContraente") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Scelta Contraente");
                    continue;
                }
                if ((C.ColumnName == "importoAggiudicazione") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Importo Aggiudicazione");
                    continue;
                }
                if ((C.ColumnName == "dataInizio") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Data Inizio");
                    continue;
                }
                if ((C.ColumnName == "dataUltimazione") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Data Ultimazione");
                    continue;
                }
                if ((C.ColumnName == "importoSommeLiquidate") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Importo Somme Liquidate");
                    continue;
                }
            }
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idGara", "Id Gara", nPos++);
                DescribeAColumn(T, "cig", "CIG", nPos++);
                DescribeAColumn(T, "spCodicefiscale", "SP Codice Fiscale", nPos++);
                DescribeAColumn(T, "spDenominazione", "SP Denominazione", nPos++);
                DescribeAColumn(T, "oggetto", "Oggetto", nPos++);
                DescribeAColumn(T, "sceltaContraente", "Scelta Contraente", nPos++);
                DescribeAColumn(T, "importoAggiudicazione", "Importo Aggiudicazione", nPos++);
                DescribeAColumn(T, "dataInizio", "Data Inizio", nPos++);
                DescribeAColumn(T, "dataUltimazione", "Data Ultimazione", nPos++);
                DescribeAColumn(T, "importoSommeLiquidate", "Importo Somme Liquidate", nPos++);
            }
        }
    }
}
