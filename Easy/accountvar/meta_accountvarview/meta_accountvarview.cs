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

ï»¿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_accountvarview {
    /// <summary>
    /// </summary>
    public class Meta_accountvarview : Meta_easydata {
        public Meta_accountvarview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "accountvarview") {
            ListingTypes.Add("default");
            ListingTypes.Add("documentocollegato");
            Name = "Variazioni di Budget";
        }

        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "default") {
                return QHS.CmpEq("yvar", GetSys("esercizio"));
            }
            return base.GetStaticFilter(ListingType);
        }
        string[] mykey = new string[] { "yvar" ,"nvar"};
        public override string[] primaryKey() {
            return mykey;
        }

        public override bool FilterRow(DataRow R, string list_type) {
            if (list_type == "documentocollegato") {
                if (R["idenactment"] == DBNull.Value) return false;
                return true;
            }

            return true;
        }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "documentocollegato") {
                sorting = "yvar desc, nvar asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            switch (ListingType) {
                case "default": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int nPos = 1;
                        DescribeAColumn(T, "yvar", "Eserc. variaz.", nPos++);
                        DescribeAColumn(T, "nvar", "Num. protocollo", nPos++);
                        DescribeAColumn(T, "nofficial", "Num. Var. Ufficiale", nPos++);
                        DescribeAColumn(T, "variationkinddescr", "Tipo var.", nPos++);
                        DescribeAColumn(T, "description", "Desc. variazione", nPos++);
                        DescribeAColumn(T, "enactment", "Provvedimento", nPos++);
                        DescribeAColumn(T, "nenactment", "Num. provv.", nPos++);
                        DescribeAColumn(T, "enactmentdate", "Data provv.", nPos++);
                        DescribeAColumn(T, "adate", "Data cont.", nPos++);
                        DescribeAColumn(T, "enactmentnumber", "Atto Amministrativo", nPos++);
                        DescribeAColumn(T, "aumento", "Aumento", nPos++);
                        DescribeAColumn(T, "diminuzione", "Diminuzione", nPos++);
                        DescribeAColumn(T, "saldo", "Saldo", nPos++);
                        int esercizio = Convert.ToInt32(GetSys("esercizio"));
                        DescribeAColumn(T, "amount2", (++esercizio).ToString());
                        DescribeAColumn(T, "amount3", (++esercizio).ToString());
                        DescribeAColumn(T, "amount4", (++esercizio).ToString());
                        DescribeAColumn(T, "amount5", (++esercizio).ToString());
                        DescribeAColumn(T, "manager", "Responsabile", nPos++);
                        DescribeAColumn(T, "finvarstatus", "Stato", nPos++);
                    break;
                    }
            case "documentocollegato": {
                    foreach (DataColumn C in T.Columns) {
                        DescribeAColumn(T, C.ColumnName, "", -1);
                    }
                    int nPos = 1;
                    DescribeAColumn(T, "accountvarstatus", "Stato", nPos++);
                    DescribeAColumn(T, "yvar", "Esercizio", nPos++);
                    DescribeAColumn(T, "nvar", "Numero", nPos++);
                    DescribeAColumn(T, "description", "Descrizione", nPos++);
                    DescribeAColumn(T, "aumento", "Aumento", nPos++);
                    DescribeAColumn(T, "diminuzione", "Diminuzione", nPos++);
                    int esercizio = Convert.ToInt32(GetSys("esercizio"));
                    DescribeAColumn(T, "amount2", (++esercizio).ToString(), nPos++);
                    DescribeAColumn(T, "amount3", (++esercizio).ToString(), nPos++);
                    DescribeAColumn(T, "amount4", (++esercizio).ToString(), nPos++);
                    DescribeAColumn(T, "amount5", (++esercizio).ToString(), nPos++);
                    DescribeAColumn(T, "adate", "Data cont.", nPos++);
                    DescribeAColumn(T, "reason", "Motivazione", nPos++);
                    FilterRows(T);
                    break;
                }
            }
        }
    }
}

