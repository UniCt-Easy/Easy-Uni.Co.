
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_flowchartupb {
    public class Meta_flowchartupb : Meta_easydata{
        public Meta_flowchartupb(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
			base(Conn, Dispatcher, "flowchartupb") {
			EditTypes.Add("single");
			ListingTypes.Add("lista");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="single") {
				Name = "U.P.B. - Organigramma";
				return MetaData.GetFormByDllName("flowchartupb_single");
			}
			return null;
		}			
	

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
		}

		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="lista") {
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"",-1);
				int pos=1;
				DescribeAColumn(T, "!codiceupb", "Codice U.P.B.", "upb.codeupb",pos++);
				DescribeAColumn(T, "!upb", "U.P.B.", "upb.title",pos++);
			}
		}   

		public override bool IsValid(DataRow R, out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			if (R["idupb"].ToString()==""){
				errmess="Attenzione! La U.P.B. non può essere nulla.";
				errfield="idupb";
				return false;
			}
			return true;
		}


	}
}
