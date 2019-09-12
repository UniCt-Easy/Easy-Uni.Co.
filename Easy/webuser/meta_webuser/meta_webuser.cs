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

namespace meta_webuser
{
	/// <summary>
	/// Summary description for webuser.
	/// </summary>
	public class Meta_webuser : Meta_easydata
	{
		public Meta_webuser(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "webuser") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				Name="Utenti";
				DefaultListType="default";
				return MetaData.GetFormByDllName("webuser_default");
			}

			return null;
		}
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (R["nome"].ToString()=="" ) {
                errmess = "Il nome è obbligatorio";
                errfield = "nome";
                return false;
            }
            if (R["cognome"].ToString() == "") {
                errmess = "Il nome è obbligatorio";
                errfield = "cognome";
                return false;
            }
            return base.IsValid(R, out errmess, out errfield);
        }

        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "username", GetSys("user"));
        }

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "username", "Nome utente", nPos++);
                DescribeAColumn(T, "titolo", "Titolo", nPos++);
                DescribeAColumn(T, "nome", "Nome", nPos++);
                DescribeAColumn(T, "cognome", "Cognome", nPos++);
                DescribeAColumn(T, "token", "Token", nPos++);
            }
			return;
		}
	}
}
