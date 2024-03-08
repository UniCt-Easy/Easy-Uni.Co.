
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_ct_asscredview  {
    /// <summary>
    /// Summary description for ct_asscredview.
    /// </summary>
    public class Meta_ct_asscredview  : Meta_easydata {
        public Meta_ct_asscredview (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "ct_asscredview ") {
            ListingTypes.Add("default");
            Name = "Configurazione Assegnazione Crediti";
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idct_asscred", "#", nPos++);
                DescribeAColumn(T, "yfinincome", "Eserc.Bilancio Entrata", nPos++);
                DescribeAColumn(T, "finincomecode", "Codice Bilancio Entrata", nPos++);
                DescribeAColumn(T, "finincometitle", "Bilancio Entrata", nPos++);
                DescribeAColumn(T, "sortcode", "Codice Classificazione", nPos++);
                DescribeAColumn(T, "sorting", "Classificazione", nPos++);
            }
        }

        public override string GetStaticFilter(string ListingType) {
            string filteresercizio;
            if (ListingType == "lista") {
                filteresercizio = "(yfinincome='" + GetSys("esercizio").ToString() + "')";
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }
    }
}

