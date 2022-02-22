
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
using metadatalibrary;
using metaeasylibrary;
//Pino: using businessrulecontrols; diventato inutile

namespace meta_auditcheck//meta_ruleenforcement//
{
	/// <summary>
	/// Summary description for Meta_ruleenforcement.
	/// </summary>
	public class Meta_auditcheck : Meta_easydata
	{
		public Meta_auditcheck(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "auditcheck") {
			ListingTypes.Add("default");
			EditTypes.Add("default");
			EditTypes.Add("child");
			Name = "Controlli";
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				//annullo tutti i nomi delle colonne...
				foreach (DataColumn DC in (DataColumnCollection)T.Columns)
					DescribeAColumn(T, DC.ColumnName, "");
				//... e mi definisco quelli che mi servono
				DescribeAColumn(T, "idaudit","Codice Regola");
				DescribeAColumn(T, "tablename", "tabella");
				DescribeAColumn(T, "opkind","Op.");
				DescribeAColumn(T, "idcheck","#");
				DescribeAColumn(T, "message","Messaggio utente");
			}
		}


		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idcheck"],null,null,6);
			RowChange.SetSelector(T,"idaudit");
			RowChange.SetSelector(T,"tablename");
			RowChange.SetSelector(T,"opkind");
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"precheck","S");
		}

	
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") {
				return MetaData.GetFormByDllName("auditcheck_child");//PinoRana
			}
			if (FormName=="child") {
				return MetaData.GetFormByDllName("auditcheck_child");//PinoRana
			}
			return null;
		}			

	}
}

