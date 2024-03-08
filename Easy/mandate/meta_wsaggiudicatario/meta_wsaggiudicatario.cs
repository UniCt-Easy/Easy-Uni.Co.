
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
    public class Meta_wsaggiudicatario : Meta_easydata {
        public Meta_wsaggiudicatario(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "wsaggiudicatario") {
            ListingTypes.Add("default");
            Name = "gare";
        }
        private string[] mykey = new string[] { "idLotto", "idaggiudicatario" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "idLotto asc, idaggiudicatario asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idmankind");
            RowChange.SetSelector(T, "yman");
            RowChange.SetSelector(T, "nman");
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public void CompletaCaption(DataTable T) {

            foreach (DataColumn C in T.Columns) {
                if ((C.ColumnName == "idaggiudicatario") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".#Id Aggiudicatario");
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
                if ((C.ColumnName == "yman") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".yman");
                    continue;
                }
                if ((C.ColumnName == "nman") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".nman");
                    continue;
                }
                if ((C.ColumnName == "idmankind") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".idmankind");
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
                DescribeAColumn(T, "yman", "yman", nPos++);
                DescribeAColumn(T, "nman", "nman", nPos++);
                DescribeAColumn(T, "idmankind", "idmankind", nPos++);
            }
        }
    }
}
