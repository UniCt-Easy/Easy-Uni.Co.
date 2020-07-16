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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;


namespace meta_itinerationrefundkindgroup
{
	/// <summary>
    /// Summary description for itinerationrefundkindgroup.
	/// </summary>
	public class Meta_itinerationrefundkindgroup : Meta_easydata
	{
        public Meta_itinerationrefundkindgroup (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "itinerationrefundkindgroup") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("descrizione");
		}

		protected override Form GetForm(string FormName)
		{
			if (FormName=="default")
			{
				Name="Elenco dei Tipi Rimborsi spese";
				DefaultListType="default";
                ActAsList();
                return MetaData.GetFormByDllName("itinerationrefundkindgroup_default");
			}
			return null;
		}

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["iditinerationrefundkindgroup"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "", -1);
            int nPos = 1;
			if (ListingType=="default"){
                DescribeAColumn(T,"iditinerationrefundkindgroup", "#", nPos++);
				DescribeAColumn(T,"description","Tipo di Rimborso spese",nPos++);
                DescribeAColumn(T,"allowalways", "Consenti Sempre",nPos++);
			}
            if (ListingType == "solodescrizione") {
                DescribeAColumn(T, "description", "Descrizione");
            }
			return;
		}
	}
}
