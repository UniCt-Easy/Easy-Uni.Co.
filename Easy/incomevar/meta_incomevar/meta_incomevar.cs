/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

namespace meta_incomevar//meta_variazioneentrata//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_incomevar : Meta_easydata {
		public Meta_incomevar(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "incomevar") {
			EditTypes.Add("default");
			EditTypes.Add("detail");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
			ListingTypes.Add("dociva");
            ListingTypes.Add("documentitrasmessi");
		
			Name = "Variazione movimento di entrata";
		}

        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest)
        {
            if (C.ColumnName == "kproceedstransmission") return;
            base.InsertCopyColumn(C, Source, Dest);
        }

        public override bool FilterRow(DataRow R, string list_type)
        {
            if (list_type == "documentitrasmessi")
            {
                if (R["kproceedstransmission"] == DBNull.Value) return false;
                return true;
            }
            return true;
        }

		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="lista";
				return MetaData.GetFormByDllName("incomevar_default");//PinoRana
			}
			if (FormName=="detail"){
				return MetaData.GetFormByDllName("incomevar_detail");//PinoRana
			}

			return null;
		}			

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			RowChange.SetSelector(T, "idinc");
			RowChange.MarkAsAutoincrement(T.Columns["nvar"],null,
				null,7);
			DataRow R = base.Get_New_Row(ParentRow, T);
			//R["numvariazione"]=-1;
			return R;
		}
		
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "yvar", "Eserc. variaz.");
				DescribeAColumn(T, "nvar", "Num. variaz.");
				DescribeAColumn(T, "description", "Descrizione");
				DescribeAColumn(T, "amount", "Importo");
				DescribeAColumn(T, "adate", "Data cont.");
				DescribeAColumn(T, "transferkind", "Tipo trasf.");
			}
            if (listtype == "documentitrasmessi")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "yvar", "Eserc.", nPos++);
                DescribeAColumn(T, "nvar", "Numero", nPos++);
                DescribeAColumn(T, "adate", "Data emiss.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                FilterRows(T);
            }
			
		}   
		
		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"yvar",GetSys("esercizio"));
			SetDefault(T,"adate", GetSys("datacontabile"));
			SetDefault(T,"amount",0);
			SetDefault(T,"transferkind","A");
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default" || ListingType == "documentitrasmessi")
            {
				return base.SelectOne(ListingType, filter, "incomevar", Exclude);
			}
			else {
				return base.SelectOne(ListingType, filter, "incomevarview", Exclude);
			}
		}		
		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R,out errmess,out errfield))return false;
            if ((CfgFn.GetNoNullDecimal(R["amount"]) == 0) && (CfgFn.GetNoNullInt32(R["autokind"]) != 22))
            {
                // 22 --> variazione di tipo EDIT, indicante la possibilit‡ di correggere i dati di incassi trasmessi
                // ai fini dell'ordinativo informatico
                errmess = "E' necessario specificare l'importo della variazione";
                errfield = "amount";
                return false;
            }

            if ((CfgFn.GetNoNullDecimal(R["amount"]) != 0) && (CfgFn.GetNoNullInt32(R["autokind"]) == 22))
            {
                // 22 --> variazione di tipo EDIT, indicante la possibilit‡ di correggere i dati di incassi trasmessi
                // ai fini dell'ordinativo informatico
                errmess = "L'importo della variazione per modifica incassi trasmessi deve essere pari a zero";
                errfield = "amount";
                return false;
            }

            if (R.Table.Columns.Contains("idinvkind")
                && R.Table.Columns.Contains("yinv")
                && R.Table.Columns.Contains("ninv")
                && R.Table.Columns.Contains("movkind")) {
                if ((R["idinvkind"] != DBNull.Value) &&
                    (R["yinv"] != DBNull.Value) &&
                    (R["ninv"] != DBNull.Value)) {
                    if (CfgFn.GetNoNullInt32(R["movkind"]) == 0) {
                        errmess = "Bisogna selezionare la causale di contabilizzazione";
                        errfield = "movkind";
                        return false;
                    }

                }
            }
			return true;
		}

	}
}
