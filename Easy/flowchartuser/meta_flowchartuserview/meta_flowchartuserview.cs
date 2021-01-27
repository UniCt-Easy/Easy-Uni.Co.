
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_flowchartuserview {
    public class Meta_flowchartuserview : Meta_easydata {
        int esercizio;
        public Meta_flowchartuserview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
                base(Conn, Dispatcher, "flowchartuserview") {
            Name = "Utenti Organigramma";
            ListingTypes.Add("default");
            esercizio = Convert.ToInt32(GetSys("esercizio"));
        }


        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "default") {
                string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            object idsorkind01 = DBNull.Value;
            object idsorkind02 = DBNull.Value;
            object idsorkind03 = DBNull.Value;
            object idsorkind04 = DBNull.Value;
            object idsorkind05 = DBNull.Value;
            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null, null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                idsorkind01 = r["idsorkind01"];
                idsorkind02 = r["idsorkind02"];
                idsorkind03 = r["idsorkind03"];
                idsorkind04 = r["idsorkind04"];
                idsorkind05 = r["idsorkind05"];
            }
            string sorkind01 = "";
            string sorkind02 = "";
            string sorkind03 = "";
            string sorkind04 = "";
            string sorkind05 = "";
            if (idsorkind01 != DBNull.Value) {
                sorkind01 = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind01), "description").ToString();
            }
            if (idsorkind02 != DBNull.Value) {
                sorkind02 = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind02), "description").ToString();
            }
            if (idsorkind03 != DBNull.Value) {
                sorkind03 = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind03), "description").ToString();
            }
            if (idsorkind04 != DBNull.Value) {
                sorkind04 = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind04), "description").ToString();
            }
            if (idsorkind05 != DBNull.Value) {
                sorkind05 = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind05), "description").ToString();
            }

            if (ListingType == "default")  {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "flowchart", "Organigramma", nPos++);
                DescribeAColumn(T, "title", "Ruolo", nPos++);
                DescribeAColumn(T, "username", "Utente", nPos++);
                if (sorkind01 != "") {
                    DescribeAColumn(T, "sortcode01", sorkind01 , nPos++);
                    DescribeAColumn(T, "sorkind01_withchilds","sottostanti(1)", nPos++);
                    DescribeAColumn(T, "all_sorkind01", "veditutto(1)", nPos++);
                }
                if (sorkind02 != "") {
                    DescribeAColumn(T, "sortcode02", sorkind02, nPos++);
                    DescribeAColumn(T, "sorkind02_withchilds", "sottostanti(2)", nPos++);
                    DescribeAColumn(T, "all_sorkind02", "veditutto(2)", nPos++);
                }
                if (sorkind03 != "") {
                    DescribeAColumn(T, "sortcode03", sorkind03, nPos++);
                    DescribeAColumn(T, "sorkind03_withchilds", "sottostanti(31)", nPos++);
                    DescribeAColumn(T, "all_sorkind03", "veditutto(3)", nPos++);
                }
                if (sorkind04 != "") {
                    DescribeAColumn(T, "sortcode04", sorkind04, nPos++);
                    DescribeAColumn(T, "sorkind04_withchilds", "sottostanti(4)", nPos++);
                    DescribeAColumn(T, "all_sorkind04", "veditutto(4)", nPos++);
                }
                if (sorkind05 != "") {
                    DescribeAColumn(T, "sortcode05", sorkind05, nPos++);
                    DescribeAColumn(T, "sorkind05_withchilds", "sottostanti(5)", nPos++);
                    DescribeAColumn(T, "all_sorkind05", "veditutto(5)", nPos++);
                }
            }
        }
    }
}
