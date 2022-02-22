
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace meta_customuser
{
	/// <summary>
	/// Summary description for customuser.
	/// </summary>
	public class Meta_customuser : Meta_easydata
	{
		public Meta_customuser(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "customuser") {		
			EditTypes.Add("default");
            EditTypes.Add("main");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				Name="Utenti";
				DefaultListType="default";
				return MetaData.GetFormByDllName("customuser_default");
			}

            if (FormName == "main") {
                Name = "Utenti";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("customuser_main");
            }
			return null;
		}
		
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
				DescribeAColumn(T,"idcustomuser","Codice utente", nPos++);
                DescribeAColumn(T, "username", "Nome utente", nPos++);
			}
			return;
		}
	}
}
