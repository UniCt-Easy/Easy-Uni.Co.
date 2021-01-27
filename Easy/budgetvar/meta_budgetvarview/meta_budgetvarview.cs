
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_budgetvarview {
    /// <summary>
    /// </summary>
    public class Meta_budgetvarview : Meta_easydata {
        public Meta_budgetvarview (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "budgetvarview") {
            ListingTypes.Add("default");
            //ListingTypes.Add("webdefault");
            //ListingTypes.Add("webdefaultstatuses");
            //ListingTypes.Add("documentocollegato");
            Name = "Variazioni di Budget";
        }

        public override string GetStaticFilter (string ListingType) {
            if (ListingType == "default") {
                return QHS.CmpEq("ybudgetvar", GetSys("esercizio"));
            }
            return base.GetStaticFilter(ListingType);
        }

     

        public override string GetSorting(string ListingType)
        {
        //    string sorting;
        //    if (ListingType == "webdefault")
        //    {
        //        sorting = "yvar desc, nvar asc";
        //        return sorting;
        //    }
        //    if (ListingType == "webdefaultstatuses")
        //    {
        //        sorting = "listingorder asc,yvar desc, nvar asc";
        //        return sorting;
        //    }
            return base.GetSorting(ListingType);
        }

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            switch (ListingType) {

                //case "webdefault":
                //    {
                //        foreach (DataColumn C in T.Columns)
                //        {
                //            DescribeAColumn(T, C.ColumnName, "", -1);
                //        }
                //        int nPos = 1;
                //        DescribeAColumn(T, "statusimage", "Stato", nPos++);
                //        DescribeAColumn(T, "yvar", "Eserc. variaz.", nPos++);
                //        DescribeAColumn(T, "nvar", "Num. protocollo", nPos++);
                //        DescribeAColumn(T, "nofficial", "Num. Var. Ufficiale", nPos++);
                //        DescribeAColumn(T, "variationkinddescr", "Tipo var.", nPos++);
                //        DescribeAColumn(T, "description", "Desc. variazione", nPos++);
                //        DescribeAColumn(T, "enactment", "Provvedimento", nPos++);
                //        DescribeAColumn(T, "nenactment", "Num. provv.", nPos++);
                //        DescribeAColumn(T, "enactmentdate", "Data provv.", nPos++);
                //        DescribeAColumn(T, "adate", "Data cont.", nPos++);
                //        DescribeAColumn(T, "incometotal", "Tot. Entrata", nPos++);
                //        DescribeAColumn(T, "expensetotal", "Tot. Spesa", nPos++);
                //        DescribeAColumn(T, "total", "Saldo", nPos++);
                //        DescribeAColumn(T, "official", "Ufficiale", nPos++);
                //        DescribeAColumn(T, "manager", "Responsabile", nPos++);
                    
                //    }
                //    break;

                //case "webdefaultstatuses":
                //    {
                //        foreach (DataColumn C in T.Columns)
                //        {
                //            DescribeAColumn(T, C.ColumnName, "", -1);
                //        }
                //        int nPos = 1;
                //        DescribeAColumn(T, "statusimage", "Stato", nPos++);
                //        DescribeAColumn(T, "yvar", "Eserc. variaz.", nPos++);
                //        DescribeAColumn(T, "nvar", "Num. protocollo", nPos++);
                //        DescribeAColumn(T, "nofficial", "Num. Var. Ufficiale", nPos++);
                //        DescribeAColumn(T, "variationkinddescr", "Tipo var.", nPos++);
                //        DescribeAColumn(T, "description", "Desc. variazione", nPos++);
                //        DescribeAColumn(T, "enactment", "Provvedimento", nPos++);
                //        DescribeAColumn(T, "nenactment", "Num. provv.", nPos++);
                //        DescribeAColumn(T, "enactmentdate", "Data provv.", nPos++);
                //        DescribeAColumn(T, "adate", "Data cont.", nPos++);
                //        DescribeAColumn(T, "incometotal", "Tot. Entrata", nPos++);
                //        DescribeAColumn(T, "expensetotal", "Tot. Spesa", nPos++);
                //        DescribeAColumn(T, "total", "Saldo", nPos++);
                //        DescribeAColumn(T, "official", "Ufficiale", nPos++);
                //        DescribeAColumn(T, "manager", "Responsabile", nPos++);
                    
                //    }
                //    break;
                case "default": {
                    foreach (DataColumn C in T.Columns) {
                        DescribeAColumn(T, C.ColumnName, "", -1);
                    }
                    int nPos = 1;
                    DescribeAColumn(T, "ybudgetvar", "Eserc. variaz.", nPos++);
                    DescribeAColumn(T, "nbudgetvar", "Num. protocollo", nPos++);
                    DescribeAColumn(T, "nofficial", "Num. Var. Ufficiale", nPos++);
                    DescribeAColumn(T, "description", "Desc. variazione", nPos++);
                    DescribeAColumn(T, "sortingkind", "Classificaizone", nPos++);
                    DescribeAColumn(T, "adate", "Data cont.", nPos++);
                    DescribeAColumn(T, "total", "Saldo", nPos++);
                    DescribeAColumn(T, "official", "Ufficiale", nPos++);
                    DescribeAColumn(T, "manager", "Responsabile", nPos++);
                    DescribeAColumn(T, "budgetvarstatus", "Stato", nPos++);
     
                    break;
                }
                //case "documentocollegato": {
                //    foreach (DataColumn C in T.Columns) {
                //        DescribeAColumn(T, C.ColumnName, "", -1);
                //    }
                //    int nPos = 1;
                //    DescribeAColumn(T, "budgetvarstatus", "Stato", nPos++);
                //    DescribeAColumn(T, "yvar", "Esercizio", nPos++);
                //    DescribeAColumn(T, "nvar", "Numero", nPos++);
                //    DescribeAColumn(T, "nofficial", "Numero ufficiale", nPos++);
                //    DescribeAColumn(T, "description", "Descrizione", nPos++);
                //    DescribeAColumn(T, "incometotal", "Tot. Entrata", nPos++);
                //    DescribeAColumn(T, "expensetotal", "Tot. Spesa", nPos++);
                //    DescribeAColumn(T, "adate", "Data cont.", nPos++);
                //    DescribeAColumn(T, "reason", "Motivazione", nPos++);
                //    FilterRows(T);
                //    break;
                //}
            }
        }
    }
}

