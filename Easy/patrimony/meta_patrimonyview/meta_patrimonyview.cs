
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

namespace meta_patrimonyview
{
	/// <summary>
	/// Summary description for meta_patrimonyview.
	/// </summary>
	public class Meta_patrimonyview : Meta_easydata 
	{
		public Meta_patrimonyview(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "patrimonyview")
		{		
		ListingTypes.Add("default");
		}
        private string[] mykey = new string[] { "idpatrimony" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default")
			{
				foreach (DataColumn C in T.Columns)
				DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T,"ayear",".Esercizio",-1);
				DescribeAColumn(T,"patpart","Parte",1);
				DescribeAColumn(T,"codepatrimony", "Codice",2);
				DescribeAColumn(T, "title","Denominazione",3);
			
			}
		}

	}
}
