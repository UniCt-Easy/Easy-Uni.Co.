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
using metaeasylibrary;
using metadatalibrary;
//Pino: using DettUtilizzoCarico; diventato inutile
using System.Windows.Forms;
using System.Data;

namespace meta_assetusage//meta_utilizzocarico//
{
	/// <summary>
	/// Summary description for utilizzocarico.
	/// </summary>
	public class Meta_assetusage : Meta_easydata {
		public Meta_assetusage(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetusage") {				

			Name= "Utilizzo carico";
			EditTypes.Add("dettaglioquota");
			ListingTypes.Add("dettaglioquota");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="dettaglioquota") {
				Name="Quota utilizzo";
				return MetaData.GetFormByDllName("assetusage_dettaglioquota");//PinoRana
			}
			return null;
		}			
		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			switch(ListingType.ToLower()) {
				case "dettaglioquota":
					return base.SelectOne(ListingType, filter, "assetusage", Exclude);
			}
			return null;
		}		
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			if (ListingType=="dettaglioquota") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

                DescribeAColumn(T, "!codeassetusagekind", "Codice", "assetusagekind.codeassetusagekind");
				DescribeAColumn(T, "!description", "Descrizione", "assetusagekind.description");
				DescribeAColumn(T, "usagequota", "Quota");
				HelpForm.SetFormatForColumn(T.Columns["usagequota"], "p");
			}
		}
	}
}
