
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
//Pino: using livelloclassinventario; diventato inutile


namespace meta_inventorysortinglevel//meta_livelloclassinventario//
{
	/// <summary>
	/// Summary description for livelloclassinventario.
	/// </summary>
	public class Meta_inventorysortinglevel : Meta_easydata 
	{
		public Meta_inventorysortinglevel(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "inventorysortinglevel") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Livelli della classificazione inventariale";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("inventorysortinglevel_default");//PinoRana
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["nlevel"],null,null,1);
			return base.Get_New_Row(ParentRow, T);
		}
	

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
           	if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"nlevel","Codice Livello");
				DescribeAColumn(T,"description","Denominazione");
				/*DescribeAColumn(T,"flagrestart","");
				DescribeAColumn(T,"flagusable","");*/
			}
            if (ListingType == "checkimport")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "nlevel", "Codice Livello", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
		}
	}
	
}
