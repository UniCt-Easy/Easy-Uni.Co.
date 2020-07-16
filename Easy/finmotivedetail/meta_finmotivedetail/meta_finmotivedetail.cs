/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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

namespace meta_finmotivedetail {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_finmotivedetail : Meta_easydata {
		public Meta_finmotivedetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finmotivedetail") {
			EditTypes.Add("single");
			ListingTypes.Add("lista");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="single") {
				Name = "Dettaglio causale";
				return MetaData.GetFormByDllName("finmotivedetail_single");//PinoRana
			}
			return null;
		}

        public override void CalculateFields(System.Data.DataRow R, string listtype) {

        if (R.Table.DataSet.Tables["fin"] != null) {
            DataTable tFin = R.Table.DataSet.Tables["fin"];
            string filterFin = QHC.CmpEq("idfin", R["idfin"]);
            if (tFin.Select(filterFin).Length > 0) {
                DataRow rFin = tFin.Select(filterFin)[0];
                object flagObj = rFin["flag"];
                if (flagObj == null) return;
                byte flag = Convert.ToByte(flagObj);
                bool isEntrata = (flag & 1) == 0;
                if (listtype == "lista") {
                    if (isEntrata) {
                        R["!E/S"] = "E";
                    }
                    else {
                        R["!E/S"] = "S";
                    }
                }
            }
        }

        }

          

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
		}

		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="lista") {
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"",-1);
				int pos=1;
                DescribeAColumn(T, "!E/S", "E/S", pos++);
				DescribeAColumn(T, "!codicebilancio", "Codice Bilancio", "fin.codefin",pos++);
				DescribeAColumn(T, "!bilancio", "Bilancio", "fin.title",pos++);
                ComputeRowsAs(T, listtype);
			}
		}   

		public override bool IsValid(DataRow R, out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			if (R["idfin"].ToString()==""){
				errmess="Attenzione! La voce di bilancio non può essere nulla.";
				errfield="idfin";
				return false;
			}
			return true;
		}


	}
}
