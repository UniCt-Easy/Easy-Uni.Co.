
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
//Pino: using TipoRiduzione; diventato inutile


namespace meta_reduction//meta_tiporiduzione//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_reduction : Meta_easydata 
	{
		public Meta_reduction(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "reduction") 
		{		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("solodescrizione");
		}
		
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Tipi di riduzione della diaria";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("reduction_default");//PinoRana
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default")
			{
				DescribeAColumn(T,"idreduction","Codice");
				DescribeAColumn(T,"description","Descrizione");
			}
            if (ListingType == "solodescrizione") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "description", "Descrizione");
            }
		}
	}
}

