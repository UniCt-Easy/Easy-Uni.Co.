
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
//Pino: using updatedbversion; diventato inutile
using System.Data;


namespace meta_updatedbversion//meta_updatedbversion//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_updatedbversion : Meta_easydata {
		public Meta_updatedbversion(IDataAccess conn, IMetaDataDispatcher dispatcher):
			base(conn as DataAccess, dispatcher as MetaDataDispatcher, "updatedbversion") {		
			Name= "Gestione versioni Database";
			EditTypes.Add("default");			
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string formName){
			if (formName=="default") {
				DefaultListType= "default";
				return GetFormByDllName("updatedbversion_default");//PinoRana
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T, "flagadmin", "0");
			SetDefault(T, "flagerror", "0");
		}

		public override void DescribeColumns(DataTable T, string listingType) {
			base.DescribeColumns (T);
			if (listingType == "default") {
				foreach (DataColumn c in T.Columns)
					DescribeAColumn(T,c.ColumnName,"",-1);
			    var pos = 0;
			    DescribeAColumn(T, "flagerror", "Flag Erore",pos++);
				DescribeAColumn(T, "versionname", "Versione DB",pos++);
			    DescribeAColumn(T, "description", "Descrizione",pos++);
			    DescribeAColumn(T, "scriptlist", "Elenco script",pos++);
				DescribeAColumn(T, "swversion", "Versione del software",pos++);
			}
		}
	}
}
