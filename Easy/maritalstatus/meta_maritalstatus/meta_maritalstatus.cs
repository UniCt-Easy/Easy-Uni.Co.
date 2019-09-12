/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
//Pino: using cdstatocivile; diventato inutile


namespace meta_maritalstatus//meta_cdstatocivile//
{
	/// <summary>
	/// Summary description for cdstatocivile.
	/// </summary>
	public class Meta_maritalstatus : Meta_easydata {
		public Meta_maritalstatus(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "maritalstatus") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name= "Stato civile";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("maritalstatus_default");//PinoRana
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"active","S");
		}		

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default") {
				foreach (DataColumn C in T.Columns) 
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"idmaritalstatus","Codice");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"active","Flag attivo");
			}
            if (ListingType == "checkimport"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "description", "Descrizione");
            }
		}
	}

}
