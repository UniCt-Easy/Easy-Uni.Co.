
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
using funzioni_configurazione;

namespace meta_epexp
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_epexp : Meta_easydata {
		public Meta_epexp(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "epexp") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
	
		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="default";
				Name="Impegno di Budget";
				return GetFormByDllName("epexp_default");
			}
			return null;
		}
		
		public override bool IsValid(DataRow R, out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;
            int nphase = CfgFn.GetNoNullInt32(R["nphase"]);
			int codicecreddeb = CfgFn.GetNoNullInt32(R["idreg"]);
            string idrelated = R["idrelated"].ToString();
            if (nphase > 1 && codicecreddeb <= 0 && (idrelated.IndexOf("upbcommessa") < 0)) {
                errmess = "Attenzione! E' necessario selezionare un Cliente/Fornitore.";
                errfield = "idreg";
                return false;
            }
            if (nphase > 1){
                if (R["paridepexp"] == DBNull.Value) {
                    errmess = "E' necessario scegliere il preimpegno di budget";
                    errfield = "idepexp";
                    return false;
                }
                
            }
		    if (nphase == 1){
		        if (R["paridepexp"] != DBNull.Value) {
		            errmess = "Non è possibile specificare un movimento parent per i preimpegni";
		            errfield = "paridepexp";
		            return false;
		        }
		    }
			return true;
		}

        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            if (C.ColumnName == "ideexp") return;
            if (C.ColumnName == "paridepexp") return;
            base.InsertCopyColumn(C, Source, Dest);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetMySelector(T.Columns["nepexp"], "nphase", 0);
			RowChange.SetMySelector(T.Columns["nepexp"], "yepexp",0);
			RowChange.MarkAsAutoincrement(T.Columns["nepexp"],null,null,0);
            RowChange.setMinimumTempValue(T.Columns["nepexp"], 99999000);
            RowChange.MarkAsAutoincrement(T.Columns["idepexp"], null, null, 0);
            RowChange.setMinimumTempValue(T.Columns["idepexp"], 99999000);
            DataRow R = base.Get_New_Row(ParentRow, T);

            //int N = MetaData.MaxFromColumn(T, "idepexp");
            //if (N < 999900000)
            //    N = 999900000;
            //else
            //    N = N + 1;
            //R["idepexp"] = N;

            //N = MetaData.MaxFromColumn(T, "nepexp");
            //if (N < 999900000)
            //    N = 999900000;
            //else
            //    N = N + 1;
            //R["nepexp"] = N;

			return R;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="default") {
				return base.SelectOne(ListingType, filter, "epexpview", Exclude);
			}		
			else 
				return base.SelectOne(ListingType, filter, "epexp", Exclude);			
		}
		

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"yepexp", GetSys("esercizio"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile").ToString());
            if (PrimaryTable.Columns["flagvariation"].DefaultValue == DBNull.Value) {
                SetDefault(PrimaryTable, "flagvariation", "N");
            }
            if (PrimaryTable.Columns["nphase"].DefaultValue == DBNull.Value) {
                SetDefault(PrimaryTable, "nphase", 1);
            }
		}
	}
}
