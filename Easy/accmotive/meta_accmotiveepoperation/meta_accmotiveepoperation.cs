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
using metaeasylibrary;
using metadatalibrary;

namespace meta_accmotiveepoperation {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_accmotiveepoperation : Meta_easydata {
		public Meta_accmotiveepoperation(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finmotivedetail") {
			EditTypes.Add("single");
			ListingTypes.Add("lista");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="single") {
				Name = "Dettaglio applicabilità causale";
				return MetaData.GetFormByDllName("accmotiveepoperation_single");//PinoRana
			}
			return null;
		}

       

          

		 

		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="lista") {
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"",-1);
				int pos=1;
				DescribeAColumn(T, "!codemotive", "Cod. Causale", "accmotive.codemotive",pos++);
				DescribeAColumn(T, "!motive", "Causale", "accmotive.title", pos++);
 
			}
		}   

		public override bool IsValid(DataRow R, out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			if (R["idaccmotive"].ToString()==""){
				errmess="Attenzione! La causale EP non può essere nulla.";
				errfield="idaccmotive";
				return false;
			}
			return true;
		}


	}
}
