
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
//Pino: using enteinventario; diventato inutile


namespace meta_inventoryagency//meta_enteinventario//
{
	/// <summary>
	/// Summary description for enteinventario.
	/// </summary>
	public class Meta_inventoryagency : Meta_easydata 
	{
		public Meta_inventoryagency(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "inventoryagency") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name="Ente inventariale";
				return MetaData.GetFormByDllName("inventoryagency_default");//PinoRana
			}
			return null;
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.MarkAsAutoincrement(T.Columns["idinventoryagency"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idinventoryagency");
            if (N < 9999000)
                R["idinventoryagency"] = 9999001;
            else
                R["idinventoryagency"] = N + 1;

            return R;
        }

		public override void SetDefaults(DataTable T){
            base.SetDefaults(T);
            SetDefault(T, "active", 'S');
        }
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
            if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"codeinventoryagency","Codice",1);
				DescribeAColumn(T,"description","Descrizione",2);
                DescribeAColumn(T, "active", "Attivo", 3);
			}
		}
	}
	
}
