
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
using metaeasylibrary;
using metadatalibrary;
//Pino: using expstoredprocedure; diventato inutile

namespace meta_exportfunction//meta_expstoredprocedure//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_exportfunction : Meta_easydata {
		public Meta_exportfunction(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "exportfunction") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				Name= "Procedure di esportazione su file ASCII o su Microsoft Excel";
				DefaultListType="default";
				return MetaData.GetFormByDllName("exportfunction_default");//PinoRana
			}
			return null;
		}	
		
		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "webvisible", "N");
		    SetDefault(PrimaryTable, "active", "S");
        }

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

				DescribeAColumn(T,"procedurename","Nome");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"modulename","Modulo");
				DescribeAColumn(T,"fileformat","Tipo file");
			}
		}


//		public override bool IsValid(DataRow R, out string errmess, out string errfield)
//		{
//			if (!base.IsValid(R, out errmess, out errfield)) return false;                 
//
//			if (R["codicemodalita"]==DBNull.Value)
//			{
//				errmess="Non è stata selezionata nessun tipo di modalità pagamento";
//				errfield="codicemodalita";
//				return false;
//			}
//            
//			return true;
//		}
     
	}
}
