
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
//Pino: using saldoinizialecassiere; diventato inutile

namespace meta_treasurerstart{//meta_saldoinizialecassiere//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_treasurerstart : Meta_easydata {
		public Meta_treasurerstart(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "treasurerstart") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				Name = "Istituto Cassiere";
				ActAsList();
				return MetaData.GetFormByDllName("treasurerstart_default");//PinoRana
			}
			return null;
		}			

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				//DescribeAColumn(T, "idtreasurer","Cod. istituto");
				DescribeAColumn(T, "!descrizione","Tesoriere", "treasurer.description");
				DescribeAColumn(T, "amount","Saldo iniziale");
			}
		} 

		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			if (R["idtreasurer"]==DBNull.Value){
				errmess="Il campo 'Tesoriere' è obbligatorio";
				errfield="idtreasurer";
				return false;
			}

			if (R["amount"]==DBNull.Value){
				errmess="Il campo 'Importo' è obbligatorio";
				errfield="amount";
				return false;
			}
			return true;
		}
	}
}
