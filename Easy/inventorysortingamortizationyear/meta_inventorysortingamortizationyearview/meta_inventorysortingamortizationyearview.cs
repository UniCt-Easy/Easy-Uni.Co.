/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace meta_inventorysortingamortizationyearview 
{
	/// <summary>
	/// Summary description  
	/// </summary>
	public class Meta_inventorysortingamortizationyearview : Meta_easydata
	{
        public Meta_inventorysortingamortizationyearview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "inventorysortingamortizationyearview") 
		{		
			ListingTypes.Add("elenco");
       
		}

	
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
            if (ListingType == "elenco")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "leveldescr", "Livello", nPos++);
                DescribeAColumn(T, "codeinv", "Cod. Class. Inventariale", nPos++);
                DescribeAColumn(T, "description", "Class. Inventariale", nPos++);
                DescribeAColumn(T, "codeinventoryamortization", "Cod. Ammortamento", nPos++);
                DescribeAColumn(T, "inventoryamortization", "Tipo Ammortamento", nPos++);
                DescribeAColumn(T, "amortizationquota", "Quota");
                DescribeAColumn(T, "official", "Ufficiale");
                DescribeAColumn(T, "ammort_sval", "Ammortamento/Svalutazione");
                DescribeAColumn(T, "age", "Et‡ min");
                DescribeAColumn(T, "agemax", "Et‡ max");
                DescribeAColumn(T, "valuemin", "Valore Min");
                DescribeAColumn(T, "valuemax", "Valore Max");
    
                HelpForm.SetFormatForColumn(T.Columns["amortizationquota"], "p");
            }
		}

	}
}
