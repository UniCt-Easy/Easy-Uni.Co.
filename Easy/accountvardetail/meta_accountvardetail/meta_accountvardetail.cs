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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_accountvardetail {
	/// <summary>
	/// Summary description for Meta_accountvardetail.
	/// </summary>
	public class Meta_accountvardetail : Meta_easydata {
		public Meta_accountvardetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accountvardetail") {
			EditTypes.Add("default");
			EditTypes.Add("single");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
			ListingTypes.Add("listaestesa");
            ListingTypes.Add("listaweb");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="listaestesa";
				Name = "Dettaglio variazione";
				return MetaData.GetFormByDllName("accountvardetail_default");
			}
			if (FormName=="single") {
				Name = "Dettaglio variazione";
				return MetaData.GetFormByDllName("accountvardetail_single");
			}
			return null;
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "yvar");
            RowChange.SetSelector(T, "nvar");
            RowChange.MarkAsAutoincrement(T.Columns["rownum"], null,null, 7);
            return base.Get_New_Row(ParentRow, T);
        }
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yvar", GetSys("esercizio"));
            SetDefault(PrimaryTable, "amount", 0);
            SetDefault(PrimaryTable, "amount2", 0);
            SetDefault(PrimaryTable, "amount3", 0);
            SetDefault(PrimaryTable, "amount4", 0);
            SetDefault(PrimaryTable, "amount5", 0);
		}
		
		public override void CalculateFields(System.Data.DataRow R, string listtype) {
			decimal amount = CfgFn.GetNoNullDecimal(R["amount"]);
			if (amount >= 0) {
				R["!aumento"] = amount;
			}
			else {
				R["!diminuzione"] = -amount;
			}
            if ((listtype == "default")|| (listtype == "listaweb")) {
                object underwritingkind = R["underwritingkind"];
                object underwritingkind_desc = DBNull.Value;

                switch (underwritingkind.ToString()) {
                case "C":
                    underwritingkind_desc = "CONTRIBUTI DA TERZI FINALIZZATI(IN CONTO CAPITALE E/O CONTO IMPIANTI)";
                    break;
                case "I":
                    underwritingkind_desc = "RISORSE DA INDEBITAMENTO";
                    break;
                case "P":
                    underwritingkind_desc = "RISORSE PROPRIE";
                    break;
                }
                if (R.Table.Columns.Contains("!underwritingkind_desc")) {
                    R["!underwritingkind_desc"] = underwritingkind_desc;
                }
            }
        }
		
		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
            if (listtype=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);	 
				}
				int nPos = 1;
				DescribeAColumn(T, "!codeacc", "Conto", "account.codeacc", nPos++);
                DescribeAColumn(T, "!codeupb", "Upb", "upb.codeupb", nPos++);
                DescribeAColumn(T, "description", "Descr. Dett.", nPos++);
                DescribeAColumn(T, "!aumento", "Aumento", nPos++);
				DescribeAColumn(T, "!diminuzione", "Diminuzione", nPos++);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "amount2", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "amount3", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "amount4", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "amount5", (++esercizio).ToString(), nPos++);
                if (Conn.GetSys("idsortingkind1") != DBNull.Value) {
                    DescribeAColumn(T, "!codesor1", Conn.GetSys("titlesortingkind1").ToString(), "sorting1.sortcode", nPos++);
                }
                if (Conn.GetSys("idsortingkind02") != DBNull.Value) {
                    DescribeAColumn(T, "!codesor2", Conn.GetSys("titlesortingkind2").ToString(), "sorting2.sortcode", nPos++);
                }
                if (Conn.GetSys("idsortingkind03") != DBNull.Value) {
                    DescribeAColumn(T, "!codesor3", Conn.GetSys("titlesortingkind3").ToString(), "sorting3.sortcode", nPos++);
                }
                DescribeAColumn(T, "!underwritingkind_desc", "Fonte Finanziamento", nPos++);
                DescribeAColumn(T, "!costpartitioncode", "Codice Ripartizione", "costpartition.costpartitioncode", nPos++);
                ComputeRowsAs(T, listtype);
			}
			if (listtype=="lista") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "yvar", "Eserc. variaz.", nPos++);
				DescribeAColumn(T, "nvar", "Num. variaz.", nPos++);
			}
            if (listtype == "listaweb") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!codeacc", "Conto", "account.codeacc", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "!codeupb", "Upb", "upb.codeupb", nPos++);
                DescribeAColumn(T, "!aumento", "Aumento", nPos++);
                DescribeAColumn(T, "!diminuzione", "Diminuzione", nPos++);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "amount2", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "amount3", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "amount4", (++esercizio).ToString(), nPos++);
                DescribeAColumn(T, "amount5", (++esercizio).ToString(), nPos++);
                if (Conn.GetSys("idsortingkind1") != DBNull.Value) {
                    DescribeAColumn(T, "!codesor1", Conn.GetSys("titlesortingkind1").ToString(), "sorting1.sortcode", nPos++);
                }
                if (Conn.GetSys("idsortingkind02") != DBNull.Value) {
                    DescribeAColumn(T, "!codesor2", Conn.GetSys("titlesortingkind2").ToString(), "sorting2.sortcode", nPos++);
                }
                if (Conn.GetSys("idsortingkind03") != DBNull.Value) {
                    DescribeAColumn(T, "!codesor3", Conn.GetSys("titlesortingkind3").ToString(), "sorting3.sortcode", nPos++);
                }
                DescribeAColumn(T, "!costpartitioncode", "CodiceRipartizione", "costpartition.costpartitioncode", nPos++);
                DescribeAColumn(T, "!underwritingkind_desc", "Fonte Finanziamento", nPos++);
                ComputeRowsAs(T, listtype);
            }
		}   

		public override bool IsValid(DataRow R, out string errmess, out string errfield){            
			        
			if (R["amount"]==DBNull.Value){
				errmess="Attenzione! L'importo non può essere nullo.";
				errfield="amount";
				return false;
			}
			if (R["idacc"]==DBNull.Value){
				errmess="Attenzione! Il Conto non può essere nullo.";
				errfield="idacc";
				return false;
			}
            if (R["idupb"] == DBNull.Value) {
                errmess = "Attenzione! L'upb non può essere nullo.";
                errfield = "idupb";
                return false;
            }

			DataRelation Rfound=null;
			foreach (DataRelation Rp in PrimaryDataTable.ParentRelations){
				if (Rp.ParentTable.TableName != "accountvar")continue;
				Rfound=Rp;
				break;
			}
            if (Rfound != null) {
                DataRow ParentRow = R.GetParentRow(Rfound);
                if (ParentRow == null) {
                    errmess = "E' necessario selezionare una variazione";
                    errfield = "nvar";
                    return false;
                }
            }

            return base.IsValid(R, out errmess, out errfield);
                
		}


		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="listaestesa")
				return base.SelectOne(ListingType, filter, "accountvardetailview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "accountvardetail", Exclude);
		}	
	}
}