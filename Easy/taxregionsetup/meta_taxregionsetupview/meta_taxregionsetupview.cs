
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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;
//Pino: using automatismiregionegeosingle; diventato inutile

namespace meta_taxregionsetupview{//meta_automatismiregionegeoview//
	/// <summary>
	/// Summary description for meta_automatismiregionegeoview
	/// </summary>
	public class Meta_taxregionsetupview : Meta_easydata {
		public Meta_taxregionsetupview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "taxregionsetupview") {
			ListingTypes.Add("enteesattore");
			EditTypes.Add("single");
			Name = "";
		}
		
		protected override System.Windows.Forms.Form GetForm(string EditType) {
			if (EditType=="single") {
				Name="Ente esattore regionale o provinciale";
				return MetaData.GetFormByDllName("taxregionsetupview_single");//PinoRana
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="enteesattore") {
				foreach (DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
                DescribeAColumn(T,"taxref", "Codice ritenuta");
				DescribeAColumn(T,"place","Regione / Prov. autonoma");
				DescribeAColumn(T,"regionalagencytitle","Ente esattore");
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T,"taxcode");
			RowChange.SetSelector(T,"ayear");
			RowChange.MarkAsAutoincrement(T.Columns["autoid"],null,null,7);
			return base.Get_New_Row (ParentRow, T);
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"kind","R");
		}
	}
}
