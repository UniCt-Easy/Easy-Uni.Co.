
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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;


namespace meta_historyproceedsview {
    class Meta_historyproceedsview : Meta_easydata{
        public Meta_historyproceedsview(DataAccess Conn,
                MetaDataDispatcher Dispatcher)
            :
                base(Conn, Dispatcher, "historyproceedsview") {
            ListingTypes.Add("default");
            ListingTypes.Add("scarico");
        }
        private string[] mykey = new string[] { "idinc" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idinc", ".identrata", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. Movim.", nPos++);
                DescribeAColumn(T, "nmov", "Num.Movim.", nPos++);
                DescribeAColumn(T, "adate", "Data", nPos++);
                DescribeAColumn(T, "idreg", ".Id Versante", nPos++);
                DescribeAColumn(T, "idman", ".Id Responsabile", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data Doc.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "competencydate", "Data Comp.", nPos++);
                DescribeAColumn(T, "amount", "Imp. Originale", nPos++);
                DescribeAColumn(T, "curramount", "Imp. Corrente", nPos++);
                DescribeAColumn(T, "totflag", "Tot flag", nPos++);
                DescribeAColumn(T, "flagarrear", "Flag Comp.", nPos++);
                DescribeAColumn(T, "ypro", "Eserc. Rev.", nPos++);
                DescribeAColumn(T, "npro", "Num. Rev.", nPos++);
                DescribeAColumn(T, "idfin", "IdFin", nPos++);
                DescribeAColumn(T, "idupb", "IdUpb", nPos++);
            }
            if (listtype == "scarico") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "ymov", "Eserc. Movim.", nPos++);
                DescribeAColumn(T, "nmov", "Num. Movim.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "ypro", "Eserc. Rev.", nPos++);
                DescribeAColumn(T, "npro", "Num. Rev.", nPos++);
                DescribeAColumn(T, "competencydate", "Data Comp.", nPos++); 
                DescribeAColumn(T, "curramount", "Imp. Corrente", nPos++);
                DescribeAColumn(T, "adate", "Data", nPos++);
            }

        }  


    }
}
