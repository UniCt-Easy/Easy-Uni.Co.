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

namespace meta_epacc
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_epacc : Meta_easydata {
		public Meta_epacc(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "epacc") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
	
		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="default";
				Name="Accertamento di Budget";
				return GetFormByDllName("epacc_default");
			}
			return null;
		}
        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            if (C.ColumnName == "ideacc") return;
            if (C.ColumnName == "paridepacc") return;
            base.InsertCopyColumn(C, Source, Dest);
        }
        public override bool IsValid(DataRow R, out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;
            int nphase = CfgFn.GetNoNullInt32(R["nphase"]);
			int codicecreddeb = CfgFn.GetNoNullInt32(R["idreg"]);
            if (nphase > 1 && codicecreddeb <= 0) {
    			errmess="Attenzione! E' necessario selezionare un Cliente/Fornitore.";
				errfield="idreg";
				return false;
			}
            if (nphase > 1){
                if (R["paridepacc"] == DBNull.Value) {
                    errmess = "E' necessario scegliere il preaccertamento di budget";
                    errfield = "idepacc";
                    return false;
                }
            }
            if (nphase == 1){
                if (R["paridepacc"] != DBNull.Value) {
                    errmess = "Non è possibile specificare un movimento parent per i preaccertamenti";
                    errfield = "paridepaccc";
                    return false;
                }
            }
			return true;
		}

        
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetMySelector(T.Columns["nepacc"], "nphase", 0);
			RowChange.SetMySelector(T.Columns["nepacc"], "yepacc",0);
			RowChange.MarkAsAutoincrement(T.Columns["nepacc"],null,null,0);
            RowChange.setMinimumTempValue(T.Columns["nepacc"], 99999000);
            RowChange.MarkAsAutoincrement(T.Columns["idepacc"], null, null, 0);
            RowChange.setMinimumTempValue(T.Columns["idepacc"], 99999000);
            DataRow R = base.Get_New_Row(ParentRow, T);

            //int N = MetaData.MaxFromColumn(T, "idepacc");
            //if (N < 999900000)
            //    N = 999900000;
            //else
            //    N = N + 1;
            //R["idepacc"] = N;

            //N = MetaData.MaxFromColumn(T, "nepacc");
            //if (N < 999900000)
            //    N = 999900000;
            //else
            //    N = N + 1;
            //R["nepacc"] = N;

			return R;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="default") {
				return base.SelectOne(ListingType, filter, "epaccview", Exclude);
			}		
			else 
				return base.SelectOne(ListingType, filter, "epacc", Exclude);			
		}
		

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"yepacc", GetSys("esercizio"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile").ToString());
            SetDefault(PrimaryTable, "nphase", 1);
            SetDefault(PrimaryTable, "flagvariation", "N");
		}
	}
}
