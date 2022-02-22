
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using HelpWeb;

namespace meta_upbitinerationavailable {
    /// <summary>
    /// Summary description for Meta_upbitinerationavailable.
    /// </summary>
    public class Meta_upbitinerationavailable :Meta_easydata {
        public Meta_upbitinerationavailable(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "upbitinerationavailable") {
            Name = "U.P.B. con disponibile";
            ListingTypes.Add("default");
            ListingTypes.Add("missioni");
        }

        public override string GetSorting(string ListingType) {
            if (ListingType == "missioni") return "printingorder asc";
            return base.GetSorting(ListingType);
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if ((ListingType == "missioni")|| (ListingType=="default")) {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                //Denominazione della UPB
                //Disponibilità Impegni Provvisori(1)  --Intesa come la somma delle disponibilità delle fasi 2
                //Missioni non contabilizzate(2)-- Intesa come la somma del lordo delle missioni imputate sulla UPB non ancora contabilizzate
                //Differenza Disponibilità(1 - 2) -Intesa come la differenza tra la disponibilità delle fasi 1  e l'importo delle missioni ancora da contabilizzare
                //scadenza della UPB

                int nPos = 1;
                DescribeAColumn(T, "codeupb", "UPB", nPos++);
                DescribeAColumn(T, "title", "Denominazione della UPB", nPos++);
                //DescribeAColumn(T, "previsionedisponibile_impegni", "Prev.disponibile per Imp.Provv.", nPos++);
                DescribeAColumn(T, "disponibilita_impegni", "Disponibilità Impegni Provvisori(1)", nPos++);// Colonna B
                DescribeAColumn(T, "missioniupbnoncontabilizzate", "Missioni non contabilizzate(2)", nPos++); // Colonna C
                DescribeAColumn(T, "differenzadisponibilita", "Differenza Disponibilità(1-2)", nPos++); // B-C
                DescribeAColumn(T, "expiration", "Scadenza della uPB", nPos++);
            }
        }

        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "missioni") {
                return QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            }
            else {
                return base.GetStaticFilter(ListingType);
            }
        }

        string[] mykey = new string[] { "ayear", "idupb" };
        public override string[] primaryKey() {
            return mykey;
        }

    }
}
