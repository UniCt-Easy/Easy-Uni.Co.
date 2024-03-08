
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
//Pino: using tipobuonoscaricoinv; diventato inutile

namespace meta_assetunloadkind//meta_tipobuonoscaricoinv//
{
	/// <summary>
	/// Summary description for tipobuonoscaricoinv.
	/// </summary>
	public class Meta_assetunloadkind : Meta_easydata 
	{
		public Meta_assetunloadkind(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "assetunloadkind") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Tipi di buoni di scarico";
				return MetaData.GetFormByDllName("assetunloadkind_default");
			}
			return null;
		}


		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idassetunloadkind", ".#", nPos++);
                DescribeAColumn(T, "codeassetunloadkind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
			}
		}

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "flag", 1);
            SetDefault(T, "active", 'S');
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idassetunloadkind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idassetunloadkind");
            if (N < 9999000)
                R["idassetunloadkind"] = 9999001;
            else
                R["idassetunloadkind"] = N + 1;

            return R;
        }
	}
	
}
