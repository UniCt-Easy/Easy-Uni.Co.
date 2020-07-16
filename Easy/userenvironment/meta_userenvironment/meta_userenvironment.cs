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
//Pino: using userenvironment; diventato inutile

namespace meta_userenvironment//meta_userenvironment//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_userenvironment : Meta_easydata {
		public Meta_userenvironment(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "userenvironment") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType = "lista";
				Name = "Variabili d'ambiente";
				return MetaData.GetFormByDllName("userenvironment_default");//PinoRana
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"kind","K");
			SetDefault(T,"flagadmin", "N");
		}


		public override void CalculateFields(DataRow R, string list_type) {
			base.CalculateFields (R, list_type);
			string varname= R["variablename"].ToString();
			if ((bool)GetSys("IsSystemAdmin")==true){
				if (GetUsr( varname)!=null) R["!attuale"]= GetUsr( varname).ToString();
			}
			else {
				if (R["idcustomuser"].ToString()==GetSys("idcustomuser").ToString()){
					if (GetUsr( varname)!=null) R["!attuale"]= GetUsr( varname).ToString();
				}
			}
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "username", "Nome utente");
				DescribeAColumn(T, "variablename", "Nome var.");
				DescribeAColumn(T, "value", "Valore var.");
				DescribeAColumn(T, "kind", "Tipo var.");
				DescribeAColumn(T, "flagadmin", "Protetta");
				DescribeAColumn(T, "!attuale", "attuale");
				ComputeRowsAs(T, ListingType);
			}
		}




	}
}
