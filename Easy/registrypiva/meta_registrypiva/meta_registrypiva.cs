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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_registrypiva {
    class Meta_registrypiva : Meta_easydata {
    public Meta_registrypiva(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "registrypiva") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("unione");
            ListingTypes.Add("unione_con_idreg");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Storicizzazione Partita IVA";
                DefaultListType = "default";
                return GetFormByDllName("registrypiva_default");
            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idreg");
            RowChange.MarkAsAutoincrement(T.Columns["idregistrypiva"], null,
                null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            errmess = CalcolaPartitaIva.controllaPartitaIva(R["p_iva"].ToString());
            if (errmess != null) {
                errfield = "p_iva";
                return false;
            }

            // La data di inizio può assumere valore null solo se nella tabella ho una sola riga
            // e di quella riga la data fine è valorizzata
            if (R["start"] == DBNull.Value) {
                if (SourceRow == null) return true;
                int righePresenti = SourceRow.Table.Rows.Count;
                if ((righePresenti == 1) && (R["stop"] != DBNull.Value)) {
                    return true;
                }
                errmess = "Inserire la data di inizio validità della partita IVA";
                errfield = "start";
                return false;
            }

            return true;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "p_iva", "Partita IVA", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
            }
            if (ListingType == "unione") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "!kk", ".aaaa", nPos++);
                DescribeAColumn(T, "idreg", "#", nPos++);
                DescribeAColumn(T, "p_iva", "Partita IVA", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                DescribeAColumn(T, "lt", "Data ultima mod.", nPos++);
            }

           

        }
    }
}
