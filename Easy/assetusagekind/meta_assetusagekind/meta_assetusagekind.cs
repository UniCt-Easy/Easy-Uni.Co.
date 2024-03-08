
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
//Pino: using tipoutilizzoinventario; diventato inutile


 
namespace meta_assetusagekind//meta_tipoutilizzoinventario//
{
	/// <summary>
	/// Summary description for tipoutilizzoinventario.
	/// </summary>
	public class Meta_assetusagekind : Meta_easydata 
	{
		public Meta_assetusagekind(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "assetusagekind") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name="Tipo utilizzo";
				ActAsList();        
				SearchEnabled = false;
				return MetaData.GetFormByDllName("assetusagekind_default");//PinoRana
			}
			return null;
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.MarkAsAutoincrement(T.Columns["idassetusagekind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idassetusagekind");
            if (N < 9999000)
                R["idassetusagekind"] = 9999001;
            else
                R["idassetusagekind"] = N + 1;

            return R;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", 'S');
        }

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "codeassetusagekind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
			}
            if (ListingType == "checkimport"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeassetusagekind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
            }
		}
	}
	
}
