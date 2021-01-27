
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_inventory//meta_inventario//
{
	/// <summary>
	/// Summary description for inventario.
	/// </summary>
	public class Meta_inventory : Meta_easydata 
	{
		public Meta_inventory(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "inventory") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("lista");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name="Inventario";
				return MetaData.GetFormByDllName("inventory_default");//PinoRana
			}
			return null;
		}

        public override void SetDefaults(DataTable PrimaryTable){
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", 'S');
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            switch (ListingType.ToLower()) {
                case "default":
                return base.SelectOne(ListingType, filter, "inventoryview", Exclude);
            }
            return base.SelectOne(ListingType,filter,searchtable,Exclude);
        }	

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
           
			if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idinventory", ".#", nPos++);
                DescribeAColumn(T, "codeinventory", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
                DescribeAColumn(T, "!enteinventario", "Ente", "inventoryagency.description", nPos++);
                DescribeAColumn(T, "!tipoinventario", "Tipo", "inventorykind.description", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
			}
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idinventory"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idinventory");
            if (N < 9999000)
                R["idinventory"] = 9999001;
            else
                R["idinventory"] = N + 1;

            return R;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (CfgFn.GetNoNullInt32(R["idinventoryagency"]) == 0) {
                errmess = "E' necessario selezionare l'ente proprietario dei cespiti";
                errfield = "idinventoryagency";
                return false;
            }
            if (CfgFn.GetNoNullInt32(R["idinventorykind"]) == 0) {
                errmess = "E' necessario selezionare il tipo dell'inventario";
                errfield = "idinventorykind";
                return false;
            }
            return base.IsValid(R, out errmess, out errfield);
        }
    }
}
