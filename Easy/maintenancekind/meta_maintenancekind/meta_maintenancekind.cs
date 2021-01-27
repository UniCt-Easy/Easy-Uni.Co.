
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
//Pino: using tipoeventotecnico; diventato inutile


namespace meta_maintenancekind//meta_tipoeventotecnico//
{
	/// <summary>
	/// Summary description for tipoeventotecnico.
	/// </summary>
	public class Meta_maintenancekind : Meta_easydata {

		public Meta_maintenancekind(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "maintenancekind") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Tipo Manutenzione";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("maintenancekind_default");//PinoRana
			}
			return null;
		}

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", 'S');
        }
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idmaintenancekind", ".#", nPos++);
                DescribeAColumn(T, "codemaintenancekind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
			}
            if (ListingType == "checkimport"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codemaintenancekind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idmaintenancekind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idmaintenancekind");
            if (N < 9999000)
                R["idmaintenancekind"] = 9999001;
            else
                R["idmaintenancekind"] = N + 1;

            return R;
        }
	}
	
}
