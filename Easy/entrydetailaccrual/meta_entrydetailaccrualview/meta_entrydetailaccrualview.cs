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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_entrydetailaccrualview
{   /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_entrydetailaccrualview : Meta_easydata
    {
        public Meta_entrydetailaccrualview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "entrydetailaccrualview")
        {
            ListingTypes.Add("default");
        }
        private string[] mykey = new string[] { "yentry", "nentry", "ndetail" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype)
        {
            base.DescribeColumns(T, listtype);
            if (listtype == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "yentry", "Eserc. Scrittura", nPos++);
                DescribeAColumn(T, "nentry", "Num. Scrittura", nPos++);
                DescribeAColumn(T, "ndetail", "Dett. scrittura", nPos++);
                DescribeAColumn(T, "codeacc", "Cod. Conto", nPos++);
                DescribeAColumn(T, "account", "Conto", nPos++);
                DescribeAColumn(T, "registry", "Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "upb", "U.P.B.", nPos++); 
                DescribeAColumn(T, "amount", "Importo Dettaglio", nPos++);
                DescribeAColumn(T, "available", "Importo Disponibile", nPos++);
                DescribeAColumn(T, "description", "Descrizione Scrittura", nPos++);
                DescribeAColumn(T, "codemotive", "Cod. Causale", nPos++);
                DescribeAColumn(T, "accmotive", "Causale", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio competenza", nPos++);
                DescribeAColumn(T, "competencystop", "Fine competenza", nPos++);
                ComputeRowsAs(T, listtype);
            }
        }

    }
}