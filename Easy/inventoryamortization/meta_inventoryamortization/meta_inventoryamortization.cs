
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
using metadatalibrary;
using metaeasylibrary;
//using tiporivalinventario;


namespace meta_inventoryamortization//meta_tiporivalinventario//
{
	/// <summary>
	/// Summary description for tiporivalinventario.
	/// </summary>
	public class Meta_inventoryamortization : Meta_easydata 
	{
		public Meta_inventoryamortization(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "inventoryamortization") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Tipo Ammortamento";
				return GetFormByDllName("inventoryamortization_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable)
		{
			base.SetDefaults (PrimaryTable);
            // default_
            // bit 0: tipo di calcolo 0 (A)
            // bit 1: ufficiale 0 (N)
            // bit 2: applicazione dell'iva 0 (N)
            // bit 3: Ammortamento 8 (S)
			SetDefault(PrimaryTable,"flag", 8);
            SetDefault(PrimaryTable, "active", 'S');
		}


		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"", -1);
                int nPos = 1;
				DescribeAColumn(T, "codeinventoryamortization","Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "age", "Età minima", nPos++);
                DescribeAColumn(T, "agemax", "Età massima", nPos++);
                DescribeAColumn(T, "valuemin", "Valore minimo", nPos++);
                DescribeAColumn(T, "valuemax", "Valore massimo", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
            }
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idinventoryamortization"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idinventoryamortization");
            if (N < 9999000)
                R["idinventoryamortization"] = 9999001;
            else
                R["idinventoryamortization"] = N + 1;

            return R;
        }
	}
	
}
