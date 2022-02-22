
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

namespace meta_payroll{//meta_cedolino//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_payroll : Meta_easydata {
		public Meta_payroll(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payroll") {		
			EditTypes.Add("default");
            EditTypes.Add("readonly_dettaglio"); // grid cedolini altri esercizi
            EditTypes.Add("readonly"); // sola visione
            EditTypes.Add("nontrasferibile");
			EditTypes.Add("trasf_cedolino");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
		}

		protected override Form GetForm(string FormName) {
			switch (FormName) {
				case "default": {
                    Name = "Cedolino";
					return GetFormByDllName("payroll_default");
				}
            case "readonly_dettaglio": {
                    Name = "Cedolino di altro esercizio";
                    return GetFormByDllName("payroll_default");
                }
            case "readonly": {
                    Name = "Cedolino";
                    DefaultListType = "default";
                    return GetFormByDllName("payroll_default");
                }
            case "nontrasferibile": {
					Name = "Cedolini non Trasferibili";
					ActAsList();
					return GetFormByDllName("payroll_nontrasferibile");
				}
			case "trasf_cedolino": {
					Name = "Wizard Trasferimento dei cedolini";
					return GetFormByDllName("payroll_trasf_cedolino");
				}
				default: return null;
			}
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType== "default") {
				return base.SelectOne(ListingType,filter,"payrollview",ToMerge);
			}
			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idpayroll"],null,null,0,false);
            RowChange.setMinimumTempValue(T.Columns["idpayroll"],999999000);
			return base.Get_New_Row (ParentRow, T);
		}
		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			DataRow app = R.GetParentRow("parasubcontractviewpayroll");
		    if (app == null) {
		        errmess = "Non è possibile modificare il cedolino se in questo esercizio";
		        errfield = "fiscalyear";
		        return false;
		    }
			int annofiscale = (int) R["fiscalyear"];
			int eserccontratto = (int) app["ycon"];
			if (annofiscale < eserccontratto) {
				errmess = "Non è possibile inserire un anno fiscale antecedente all'esercizio di creazione del contratto";
				errfield = "fiscalyear";
				return false;
			}
			return true;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
            SetDefault(PrimaryTable,"flagcomputed","N");
            SetDefault(PrimaryTable, "flagsummarybalance", "N");
		}


		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
            int nPos = 1;
			if (ListingType=="default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "idpayroll", "Num. Cedolino", nPos++);
                DescribeAColumn(T, "flagcomputed", "Calcolato", nPos++);
                DescribeAColumn(T, "fiscalyear", "Anno fiscale", nPos++);
                DescribeAColumn(T, "npayroll", "Progressivo Anno", nPos++);
                DescribeAColumn(T, "flagbalance", "Conguaglio", nPos++);
                DescribeAColumn(T, "flagsummarybalance", "Riepilogo", nPos++);
                DescribeAColumn(T, "disbursementdate", "Erogazione", nPos++);
                DescribeAColumn(T, "feegross", "Comp.lordo", nPos++);
                DescribeAColumn(T, "netfee", "Comp.netto", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
				DescribeAColumn(T, "!codeupb", "Codice UPB", "upb_payroll.codeupb", nPos++);
				DescribeAColumn(T, "!codeupb_other", "Codice UPB", "upb_payrollother.codeupb", nPos++);
			}
		}
	}
}
