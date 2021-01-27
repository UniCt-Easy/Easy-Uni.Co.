
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
//using classtreecreddebi;
//using classtreecreddebiview;
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_epaccsorting {//meta_classtreecreddebi//
	/// <summary>
	/// MetaData for classtreecreddebi
	/// </summary>
	public class Meta_epaccsorting : Meta_easydata {
		public Meta_epaccsorting(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "epaccsorting") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			// if (FormName=="default") return new frmClassGerarchica();
			if (FormName=="default") {
				Name = "Classificazione Accertamento di Budget";
				return MetaData.GetFormByDllName("epaccsorting_default");
			}
			return null;
		}			
		
		public override void SetEntityDetail(DataRow SourceRow) {
            DS.Tables["epaccsorting"].ExtendedProperties["importototale"] = 
				SourceRow.Table.ExtendedProperties["importototale"];			
		}   

		public override void CalculateFields(System.Data.DataRow R, string listtype) {
			DataTable Unfiltered= (DataTable) R.Table.ExtendedProperties["UnfilteredTable"];
			if (Unfiltered==null) Unfiltered = R.Table;
            if (Unfiltered.ExtendedProperties["importototale"] == null)
                return;
            decimal tot = CfgFn.GetNoNullDecimal(Unfiltered.ExtendedProperties["importototale"]);
			if (tot==0) {
				R["!percentuale"]="-";
				return;
			}
			decimal perc= CfgFn.GetNoNullDecimal(R["amount"])/tot;
			R["!percentuale"]= perc.ToString("p");
		}
		
		public override bool IsValid(DataRow R, out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (CfgFn.GetNoNullInt32(R["idsor"]) == 0) {
                errmess = "La selezione della classificazione è obbligatoria";
                errfield = "idsor";
                return false;
            }
			if (R["kind"].ToString().ToUpper()=="N" && CfgFn.GetNoNullDecimal(R["amount"])< 0){
				errmess="Attenzione! L'importo di una classificazione di tipo Normale non può essere negativo";
				errfield="amount";
				return false;
			}
			return true;
		}


		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                //DescribeAColumn(T,"idsorkind","Tipo");
                //DescribeAColumn(T,"idsorkind","");
                int nPos = 0;
                //DescribeAColumn(T, "rownum", ".#", nPos++);
                DescribeAColumn(T, "!sortingkind", "Tipo Class.", "sortingview.sortingkind", nPos++);
                DescribeAColumn(T, "!sortcode", "Codice", "sortingview.sortcode", nPos++);
                DescribeAColumn(T, "!sorting", "Classificazione", "sortingview.description", nPos++);
                DescribeAColumn(T, "!percentuale", "%", "", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "adate", "Data", nPos++);
                DescribeAColumn(T, "kind", "Tipo", nPos++);
			
				ComputeRowsAs(T,"default");
			}
		}

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "adate", Conn.GetSys("datacontabile"));
            SetDefault(T, "ayear", CfgFn.GetNoNullInt32( Conn.GetSys("esercizio")));
            SetDefault(T, "kind", 'N');		

        }
	
		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(
				T.Columns["rownum"], 
				null,
				null,
				7,
				false);
            RowChange.SetMySelector(T.Columns["rownum"],"idepacc",0);
			return base.Get_New_Row (ParentRow, T);
		}
	}
}
