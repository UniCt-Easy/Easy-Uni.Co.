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
//using classtreesezionesingle;
using metaeasylibrary;
using metadatalibrary;

namespace meta_divisionsorting//meta_classtreesezione//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_divisionsorting : Meta_easydata {
		public Meta_divisionsorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "divisionsorting") {
			EditTypes.Add("default");
//			EditTypes.Add("single");
			ListingTypes.Add("default");
			Name = "Classificazione Sezione";
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				return GetFormByDllName("divisionsorting_default");
				//return new frmclasstreesezionesingle();
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns)
            {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }
            int nPos = 1;
            DescribeAColumn(T, "!sortingkind", "Tipo", "sortingview.sortingkind", nPos++);
		    DescribeAColumn(T, "!codiceclass", "Codice", "sortingview.sortcode", nPos++);
            DescribeAColumn(T, "!descrizione", "Descrizione", "sortingview.description", nPos++);
            DescribeAColumn(T, "quota", "Quota", nPos++);
			HelpForm.SetFormatForColumn(T.Columns["quota"],"p");
		}   
	}
}
