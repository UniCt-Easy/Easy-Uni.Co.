/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
//Pino: using tiporegistroiva; diventato inutile

namespace meta_ivaregisterkind//meta_tiporegistroiva//
{
	/// <summary>
	/// Summary description for tiporegistroiva.
	/// </summary>
	public class Meta_ivaregisterkind : Meta_easydata {
		public Meta_ivaregisterkind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "ivaregisterkind") 
			{		
				EditTypes.Add("default");
				ListingTypes.Add("default");
			}
		
		protected override Form GetForm(string FormName) {
			if (FormName=="default")
			{
				DefaultListType="default";
				Name="Registro IVA";
				return MetaData.GetFormByDllName("ivaregisterkind_default");//PinoRana
			}
			return null;
		}

        public override void SetDefaults(DataTable T) {
            if (T.Columns.Contains("compensation"))
                MetaData.SetDefault(T,"compensation","N");
            base.SetDefaults(T);
        }
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			
			if ( ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"codeivaregisterkind","Codice registro");
				DescribeAColumn(T,"description","Descrizione");
				DescribeAColumn(T,"registerclass","Classe registro");
                DescribeAColumn(T, "compensation", "Corrispettivi");
                DescribeAColumn(T, "idivaregisterkindunified", "Codice di Consolidamento");
                
            }
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idivaregisterkind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idivaregisterkind");
            if (N < 9999000)
                R["idivaregisterkind"] = 9999001;
            else
                R["idivaregisterkind"] = N + 1;

            return R;
        }
    }
}
