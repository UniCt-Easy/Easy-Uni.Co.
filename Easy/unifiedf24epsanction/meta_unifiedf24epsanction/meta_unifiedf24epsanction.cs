
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_unifiedf24epsanction
{
	/// <summary>
	/// Summary description for Meta_casualrefund.
	/// </summary>
    public class Meta_unifiedf24epsanction : Meta_easydata
	{
		public Meta_unifiedf24epsanction(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "unifiedf24epsanction") 
		{
			EditTypes.Add("single");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="single")
			{
				Name = "Sanzione F24 EP";
		        return GetFormByDllName("unifiedf24epsanction_single");
			}
			return null;
		}

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                int nPos = 1;
                DescribeAColumn(T, "!fiscaltaxcode", "Codice Tributo","f24epsanctionkind.fiscaltaxcode",nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "ayear", "Anno di Riferimento",nPos++);
                
            }
        }
        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idunifiedf24ep");
            RowChange.MarkAsAutoincrement(T.Columns["idsanctionf24"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
            
        }
        public override bool IsValid (DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["amount"]) <= 0) {
                errmess = "Inserire un importo valido";
                errfield = "amount";
                return false;
            }
            if (CfgFn.GetNoNullInt32(R["ayear"]) == 0) {
                errmess = "Inserire l'anno di riferimento";
                errfield = "ayear";
                return false;
            }
            string fiscaltaxcode = Conn.DO_READ_VALUE("f24epsanctionkind", 
                                   QHS.CmpEq("idsanction", R["idsanction"]),"fiscaltaxcode").ToString();
            if (fiscaltaxcode != "") {
                if ((fiscaltaxcode == "891E") && (CfgFn.GetNoNullInt32(R["idcity"]) == 0)) {
                    errmess = "Inserire il comune di riferimento";
                    errfield = "ayear";
                    return false;
                }

                if (((fiscaltaxcode == "892E") || (fiscaltaxcode == "893E")) 
                    && (CfgFn.GetNoNullInt32(R["idfiscaltaxregion"]) == 0)) {
                    errmess = "Inserire la regione di riferimento";
                    errfield = "ayear";
                    return false;
                }
            }
            return true;
        }
	}
}
