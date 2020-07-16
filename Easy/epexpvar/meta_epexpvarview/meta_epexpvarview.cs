/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace meta_epexpvarview {
    /// <summary>
    /// Summary description for meta_epexpvar.
    /// </summary>
    /// 

    public class Meta_epexpvarview : Meta_easydata {
        public Meta_epexpvarview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "epexpvarview") {
 
            ListingTypes.Add("lista");
            Name = "Variazione movimento Impegno di Budget";
        }
        private string[] mykey = new string[] { "idepexp", "nvar" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            int pos = 1;
            if (listtype == "lista")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                DescribeAColumn(T, "phase", "Fase", pos++);
                DescribeAColumn(T, "yepexp", "Eserc. mov.", pos++);
                DescribeAColumn(T, "nepexp", "Num. mov.", pos++);
                DescribeAColumn(T, "yvar", "Eserc. variaz.", pos++);
                DescribeAColumn(T, "nvar", "Num. variaz.", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "amount", "Importo", pos++);
               /* DescribeAColumn(T, "amount2", "Importo", pos++);
                DescribeAColumn(T, "amount3", "Importo", pos++);
                DescribeAColumn(T, "amount4", "Importo", pos++);
                DescribeAColumn(T, "amount5", "Importo", pos++);*/
                DescribeAColumn(T, "adate", "Data cont.", pos++);
                DescribeAColumn(T, "codeacc", "Cod.Bil.", pos++);
                DescribeAColumn(T, "account", "Bil.", pos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", pos++);
                DescribeAColumn(T, "upb", "UPB", pos++);
 
            }

            if (listtype == "budgetupb") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                } 
                DescribeAColumn(T, "phase", "Fase", pos++);
                DescribeAColumn(T, "yepexp", "Eserc. mov.", pos++);
                DescribeAColumn(T, "nepexp", "Num. mov.", pos++);
                DescribeAColumn(T, "yvar", "Eserc. variaz.", pos++);
                DescribeAColumn(T, "nvar", "Num. variaz.", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "amountwithsign", esercizio.ToString() + " (Importo +/-)", pos++);
                DescribeAColumn(T, "adate", "Data cont.", pos++);
                DescribeAColumn(T, "codeacc", "Cod.Bil.", pos++);
                DescribeAColumn(T, "account", "Bil.", pos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", pos++);
                DescribeAColumn(T, "upb", "UPB", pos++);

            }

        }


    
    }
}
