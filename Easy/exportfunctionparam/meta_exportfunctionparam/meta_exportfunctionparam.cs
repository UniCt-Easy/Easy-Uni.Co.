
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

namespace meta_exportfunctionparam
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_exportfunctionparam : Meta_easydata {
		public Meta_exportfunctionparam(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "exportfunctionparam") {
			EditTypes.Add("single");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="single") {
				Name= "Parametro della procedura";
				return MetaData.GetFormByDllName("exportfunctionparam_single");
			}
			return null;
		}	

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "systype", "String");
            SetDefault(PrimaryTable, "tag", "");
            SetDefault(PrimaryTable, "hintkind", "NOHINT");
			SetDefault(PrimaryTable, "iscombobox", "N");
			SetDefault(PrimaryTable, "noselectionforall", "N");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "number", "Numero", nPos++);
                DescribeAColumn(T, "paramname", "Nome", nPos++);
                DescribeAColumn(T, "description", "Titolo", nPos++);
                DescribeAColumn(T, "systype", "Tipo", nPos++);
                DescribeAColumn(T, "tag", "Tag", nPos++);
			}
		}


		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			if (R["number"]==DBNull.Value) {
				errmess="Il campo \"Numero\" è obbligatorio";
				errfield="number";
				return false;
			}

			if (Convert.ToInt16(R["number"]) < 0 || Convert.ToInt16(R["number"]) > 100) {
				errmess="Il campo \"Numero\" ammette valori compresi tra 0 e 100";
				errfield="number";
				return false;
			}

            if (R["hint"] == DBNull.Value && R["hintkind"].ToString() == "O") {
                errmess = "Il campo \"Altro valore\" è obbligatorio";
                errfield = "hint";
                return false;
            }

			return true;
		}
     
	}
}
