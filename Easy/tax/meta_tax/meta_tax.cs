
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
using System.Windows.Forms;
//Pino: using tiporitenutalista; diventato inutile
//using tiporitenutasingle;
using metaeasylibrary;
using metadatalibrary;

namespace meta_tax{//meta_tiporitenuta//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_tax : Meta_easydata {
		public Meta_tax(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "tax") {
			EditTypes.Add("default");
			//EditTypes.Add("single");
			ListingTypes.Add("default");
			ListingTypes.Add("solodescrizione");
            ListingTypes.Add("checkimport");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				Name = "Tipi di ritenuta";
				return MetaData.GetFormByDllName("tax_default");//PinoRana
			}
//			if (FormName=="single") {
//				return new frmtiporitenutasingle();
//			}
			return null;
		}
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="solodescrizione"){
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "description", "Descrizione", nPos++);
			}
            //  taxref;description,taxkind,fiscaltaxcode,appliancebasis",
			if (ListingType=="default"){
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"", -1);
                int nPos = 1;
                DescribeAColumn(T, "taxcode", "# ritenuta", nPos++);
                DescribeAColumn(T, "taxref", "Codice ritenuta", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
			}
            if (ListingType == "checkimport"){
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "taxref", "Codice ritenuta", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "taxkind", "Categoria", nPos++);
                DescribeAColumn(T, "fiscaltaxcode", "Codice tributo/Causale contributo", nPos++);
                DescribeAColumn(T, "appliancebasis", "Principio di applicazione", nPos++);
            }

		}
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["taxcode"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }
		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
            SetDefault(PrimaryTable, "taxkind", 6);
            SetDefault(PrimaryTable, "flagunabatable", "N");
            SetDefault(PrimaryTable, "active", "S");
		}

	}

}
