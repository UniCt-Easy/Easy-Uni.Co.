
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


namespace meta_servicecsamask
{
	/// <summary>
    /// Summary description for servicecsamask.
	/// </summary>
	public class Meta_servicecsamask : Meta_easydata 
	{
		public Meta_servicecsamask(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "servicecsamask") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("solodescrizione");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name="Filtri usabilità  Prestazioni per CSA - Record 8000";
                //ActAsList();        
                //SearchEnabled = true;
                return MetaData.GetFormByDllName("servicecsamask_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
		}
	

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
            if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                //DescribeAColumn(T, "idmask", ".#", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "value", "Valore Maschera", nPos++);
			}
            if (ListingType == "solodescrizione") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idmask"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idmask");
            if (N < 9999000)
                R["idmask"] = 9999001;
            else
                R["idmask"] = N + 1;

            return R;
        }
	}
	
}
