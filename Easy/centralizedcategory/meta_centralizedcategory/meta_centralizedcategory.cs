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
//Pino: using cdclasscreddebicentra_anagrafica; diventato inutile


namespace meta_centralizedcategory//meta_cdclasscreddebicentra//
{
	/// <summary>
	/// Summary description for cdclasscreddebicentra.
	/// </summary>
	public class Meta_centralizedcategory : Meta_easydata {
		public Meta_centralizedcategory(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "centralizedcategory") {		
			EditTypes.Add("lista");
			ListingTypes.Add("lista");
            ListingTypes.Add("checkimport");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="lista") 
			{
				DefaultListType="lista";
				Name= "Classificazione centralizzata anagrafica";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("centralizedcategory_lista");//PinoRana
			}
			return null;
		}

		public override void SetDefaults(DataTable T) 
		{
			base.SetDefaults(T);
			SetDefault(T,"active","S");
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="lista")
			{
				DescribeAColumn(T,"idcentralizedcategory","Codice");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"active","");
			}
            if (ListingType == "checkimport") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "description", "Descrizione");
            }
		}
	}
}