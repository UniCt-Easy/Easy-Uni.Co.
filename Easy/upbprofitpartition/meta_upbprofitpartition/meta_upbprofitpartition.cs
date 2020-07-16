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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_upbprofitpartition{
	/// <summary>
	/// Summary description for Meta_upbsorting.
	/// </summary>
	public class Meta_upbprofitpartition : Meta_easydata {
        public Meta_upbprofitpartition(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "upbprofitpartition") {
			EditTypes.Add("single");
			ListingTypes.Add("default");
            //EditTypes.Add("imputazione");
		}

		protected override Form GetForm(string FormName) {
			
			if (FormName=="single") {
				Name = "Destinazione Utile Progetto a Scadenza";
				DefaultListType = "default";
                return GetFormByDllName("upbprofitpartition_single");
			}
           
			return null;
		}

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable Exclude) {
            return base.SelectOne(ListingType, filter, "upbprofitpartition", Exclude);
        }

        override public bool IsValid(DataRow R, out string errmess, out string errfield) {
        if (!base.IsValid(R, out errmess, out errfield)) return false;
        if ( CfgFn.GetNoNullDecimal( R["quota"]) == 0) {
            errmess = "L'importo della quota deve sempre essere specificato";
            errfield = "quota";
            return false;
        }
        return true;
        }

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
            // Da Visualizzare nel form upb_default
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int npos = 1;
                DescribeAColumn(T, "idupb","", npos++);
                DescribeAColumn(T, "idupb_dest", "", npos++);
                DescribeAColumn(T, "!codeupb_dest", "Cod. UPB Dest.", "upb_dest.codeupb", npos++);
                DescribeAColumn(T, "!titleupb_dest", "Descr. UPB Dest.", "upb_dest.title", npos++);
                DescribeAColumn(T, "quota", "Quota", npos++);
                HelpForm.SetFormatForColumn(T.Columns["quota"], "p");
            }
		}
	}
}