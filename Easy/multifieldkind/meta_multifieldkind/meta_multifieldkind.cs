/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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


namespace meta_multifieldkind
{
	/// <summary>
    /// Summary description for multifieldkind.
	/// </summary>
	public class Meta_multifieldkind : Meta_easydata 
	{
		public Meta_multifieldkind(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "multifieldkind") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("solodescrizione");
		}
		
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name="Campi aggiuntivi per cespiti";
				ActAsList();        
				SearchEnabled = true;
                return MetaData.GetFormByDllName("multifieldkind_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
            SetDefault(PrimaryTable, "allownull", 'S');
		}
	

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
            if ( ListingType=="default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idinventorykind", ".#", nPos++);
                DescribeAColumn(T, "fieldcode", "Codice", nPos++);
                DescribeAColumn(T, "fieldname", "Descrizione", nPos++);
                DescribeAColumn(T, "tabname", "sezione", nPos++);
                DescribeAColumn(T, "ordernumber", "ordine", nPos++);
                DescribeAColumn(T, "allownull", "Facoltativo", nPos++);
			}
            if (ListingType == "solodescrizione") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "fieldname", "Descrizione", nPos++);
                DescribeAColumn(T, "allownull", "Facoltativo", nPos++);
            }
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idmultifieldkind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idmultifieldkind");
            if (N < 9999000)
                R["idmultifieldkind"] = 9999001;
            else
                R["idmultifieldkind"] = N + 1;

            return R;
        }
	}
	
}
