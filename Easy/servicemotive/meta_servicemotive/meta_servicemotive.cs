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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;
//Pino: using cdcausaleprestazione; diventato inutile

namespace meta_servicemotive//meta_cdcausaleprestazione//
{
	/// <summary>
	/// Summary description for Meta_cdcausaleprestazione.
	/// </summary>
	public class Meta_servicemotive : Meta_easydata {
		public Meta_servicemotive(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "servicemotive") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="default";
				Name= "Causale prestazione";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("servicemotive_default");//PinoRana
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default") {
				foreach (DataColumn C in T.Columns) 
					DescribeAColumn(T, C.ColumnName, "");

				DescribeAColumn(T,"idmot","Codice");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"ayear","Esercizio");
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idmotive"],null,null,6);
			return base.Get_New_Row (ParentRow, T);
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable, "ayear", this.Conn.sys["esercizio"]);
		}

	}
}
