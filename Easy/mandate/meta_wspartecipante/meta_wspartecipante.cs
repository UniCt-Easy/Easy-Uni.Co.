
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

namespace meta_wsgara {
    /// <summary>
    /// 
    /// </summary>
    public class Meta_wspartecipante : Meta_easydata {
        public Meta_wspartecipante(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "wspartecipante") {
            ListingTypes.Add("default");
            Name = "gare";
        }
        private string[] mykey = new string[] { "idLotto", "idPartecipante" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "idLotto asc, idPartecipante asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public void CompletaCaption(DataTable T) {

            foreach (DataColumn C in T.Columns) {
                if ((C.ColumnName == "idPartecipante") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".#Id Partecipante");
                    continue;
                }
                if ((C.ColumnName == "idLotto") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".#Id Lotto");
                    continue;
                }
                if ((C.ColumnName == "codicefiscale") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Codice Fiscale");
                    continue;
                }
                if ((C.ColumnName == "ragionesociale") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Ragione Sociale");
                    continue;
                }
                if ((C.ColumnName == "identificativoFiscaleEstero") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Identificativo Fiscale Estero");
                    continue;
                }
                if ((C.ColumnName == "ruolo") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Ruolo");
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
                DescribeAColumn(T, "idLotto", "Id Lotto", nPos++);
                DescribeAColumn(T, "codicefiscale", "Codice Fiscale", nPos++);
                DescribeAColumn(T, "ragionesociale", "Ragione Sociale", nPos++);
                DescribeAColumn(T, "identificativoFiscaleEstero", "Identificativo Fiscale Estero", nPos++);
                DescribeAColumn(T, "ruolo", "Ruolo", nPos++);
            }
        }
    }
}
