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
using funzioni_configurazione;

namespace meta_csa_agency
{
	/// <summary>
	/// </summary>
	public class Meta_csa_agency : Meta_easydata {
		public Meta_csa_agency(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_agency") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name= "Ente CSA";
				return MetaData.GetFormByDllName("csa_agency_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"isinternal","N");
           // SetDefault(T, "flag", 0);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idreg"]) == 0) {
                errmess = "Non è stata selezionata nessuna anagrafica";
                errfield = "idreg";
                return false;
            }
            return true;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default") {
				foreach (DataColumn C in T.Columns) 
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
				DescribeAColumn(T,"idcsa_agency","Codice", nPos++);
				DescribeAColumn(T,"description","Descrizione", nPos++);
                DescribeAColumn(T,"ente", "Ente", nPos++);
				DescribeAColumn(T,"isinternal","Ente interno", nPos++);
			}
           
		}
        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_agencyview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_agency"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idcsa_agency");
            if (N < 9999000)
                R["idcsa_agency"] = 9999001;
            else
                R["idcsa_agency"] = N + 1;

            return R;
        }

       
    }

}
