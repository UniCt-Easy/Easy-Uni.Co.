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

namespace meta_registrysortingview //meta_classtreecreddebiview//
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_registrysortingview : Meta_easydata {
        public Meta_registrysortingview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            //
            // TODO: Add constructor logic here
            //
            base(Conn, Dispatcher, "registrysortingview") {
            Name = "Classificazione anagrafica";
            ListingTypes.Add("anagrafica"); //M. Smaldino 11 04 2005
        }

        private string[] mykey = new string[] {"idreg", "idsor"};

        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "anagrafica") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "sortingkind", "Tipo", nPos++);
                DescribeAColumn(T, "registry", "Denominazione", nPos++);
                DescribeAColumn(T, "sortcode", "Codice", nPos++);
                DescribeAColumn(T, "sorting", "Descrizione", nPos++);
                DescribeAColumn(T, "quota", "Quota", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["quota"], "p");
            }

            if (ListingType.StartsWith("lista")) {
                string[] splittedlistingtype = ListingType.Split(".".ToCharArray());
                string idsorkind = splittedlistingtype[1];
                DataTable TipoClass = Conn.RUN_SELECT("sortingkind", "*", null,
                    "(idsorkind=" + QueryCreator.quotedstrvalue(idsorkind, true) + ")",
                    null, true);
                if (TipoClass.Rows.Count != 1) return;
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "sortingkind", "Tipo", nPos++);
                DescribeAColumn(T, "registry", "Denominazione", nPos++);
                DescribeAColumn(T, "idsor", "", nPos++);
                DescribeAColumn(T, "sortcode", "Codice", nPos++);
                DescribeAColumn(T, "sorting", "Descrizione", nPos++);
                DescribeAColumn(T, "codesorkind", "Tipo", nPos++);
                DescribeAColumn(T, "quota", "Quota", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["quota"], "p");
            }
        }
    }
}
