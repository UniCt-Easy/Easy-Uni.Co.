
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_csa_contractkindview
{
	/// <summary>
    /// Summary description for Meta_csa_contractkindview.
	/// </summary>
	public class Meta_csa_contractkindview : Meta_easydata
	{
        public Meta_csa_contractkindview (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "csa_contractkindview") 
		{		
		}
        string[] mykey = new string[] { "ayear","idcsa_contractkind" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Eserc.", nPos++);
                DescribeAColumn(T, "idcsa_contractkind", "#", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "csa_contractkindcode", "Cod. Regola generale CSA", nPos++);
                DescribeAColumn(T, "codeupb", "UPB", nPos++);
                DescribeAColumn(T, "codeacc_main", "Conto E/P", nPos++);
                DescribeAColumn(T, "codefin_main", "Bilancio", nPos++);
                DescribeAColumn(T, "sortcode_main", "SIOPE", nPos++);
                DescribeAColumn(T, "flagcr", "Comp./Residui", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
            }
        }
	}
}
