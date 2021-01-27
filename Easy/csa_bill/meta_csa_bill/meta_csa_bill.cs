
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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

namespace meta_csa_bill
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_csa_bill : Meta_easydata {
		public Meta_csa_bill(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_bill") {
            EditTypes.Add("detail");
            EditTypes.Add("default");
            ListingTypes.Add("lista");
        }
		protected override Form GetForm(string FormName){
			if (FormName== "default")
			{
				//DefaultListType="default";
				Name = "Associazione sospesi a importazione CSA";
				return MetaData.GetFormByDllName("csa_bill_default");
			}
            if (FormName == "detail") {
                //DefaultListType="default";
                Name = "Dettaglio della ripartizione";
                return MetaData.GetFormByDllName("csa_bill_detail");
            }
            return null;
		}		

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcsa_import");
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_bill"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);

            int N = MetaData.MaxFromColumn(T, "idcsa_bill");
            if (N < 9999000)
                R["idcsa_bill"] = 9999001;
            else
                R["idcsa_bill"] = N + 1;

            return R;
        }


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idcsa_import", ".#Import.", nPos++);
                DescribeAColumn(T, "idcsa_bill", ".#Dett.", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "!registry", "Anagrafica", "registry_sospesi.title", nPos++);
                DescribeAColumn(T, "nbill", "Numero sospeso", nPos++);
                DescribeAColumn(T, "!motive", "Causale", "bill_ripartizione.motive", nPos++);
                DescribeAColumn(T, "!datasospeso", "Data cont.", "bill_ripartizione.adate", nPos++);
            }
        }
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullDecimal(R["amount"]) <=0 ) {
                errmess = "E' necessario specificare un importo positivo";
                errfield = "amount";
                return false;
            }
            if (CfgFn.GetNoNullInt32(R["idreg"]) == 0) {
                errmess = "Non � stata valorizzata un'anagrafica";
                errfield = "idreg";
                return false;
            }
            if (CfgFn.GetNoNullInt32(R["nbill"]) == 0) {
                errmess = "Non � stato valorizzato il numero del sospeso";
                errfield = "nbill";
                return false;
            }
            return true;
        }
        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_billview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
	}
}
