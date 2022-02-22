
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_assetloadexpense//meta_buonocaricospesa//
{
	/// <summary>
	/// Summary description for Meta_buonocaricospesa.
	/// </summary>
	public class Meta_assetloadexpense : Meta_easydata {
		public Meta_assetloadexpense(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher,"assetloadexpense") {

			ListingTypes.Add("buonodicarico");
			Name="Movimenti di spesa collegati a buoni di carico";
		}

		public override void DescribeColumns(System.Data.DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="buonodicarico") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"!ymov","Eserc. movimento","expense.ymov");
				DescribeAColumn(T,"!nmov","Num. movimento","expense.nmov");
				DescribeAColumn(T,"!expensedescription","Descrizione","expense.description");
				DescribeAColumn(T,"!npay","Num. doc. pagamento","expenselast.npay");
				DescribeAColumn(T,"!expensedoc","Documento","expense.doc");
				DescribeAColumn(T,"!amount","Importo","expense.amount");
                //DescribeAColumn(T,"!employtaxamount","Ritenute","expense.employtaxamount");
                //DescribeAColumn(T,"!admintaxamount","Contributi","expense.admintaxamount");
                //DescribeAColumn(T,"!clawbackamount","Recuperi","expense.clawbackamount");
				HelpForm.SetFormatForColumn(T.Columns["!amount"],"c");
                //HelpForm.SetFormatForColumn(T.Columns["!employtaxamount"],"c");
                //HelpForm.SetFormatForColumn(T.Columns["!admintaxamount"],"c");
                //HelpForm.SetFormatForColumn(T.Columns["!clawbackamount"],"c");
				ComputeRowsAs(T,ListingType);
			}
			if (ListingType=="ratifica") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"!ymov","Eserc. movimento","historypaymentview.ymov");
                DescribeAColumn(T, "!nmov", "Num. movimento", "historypaymentview.nmov");
                DescribeAColumn(T, "!expensedescription", "Descrizione", "historypaymentview.description");
                DescribeAColumn(T, "!npay", "Num. doc. pagamento", "historypaymentview.npay");
                DescribeAColumn(T, "!expensedoc", "Documento", "historypaymentview.doc");
                DescribeAColumn(T, "!amount", "Importo", "historypaymentview.amount");
				HelpForm.SetFormatForColumn(T.Columns["!amount"],"c");
				ComputeRowsAs(T,ListingType);
			}
		}

        public override void CalculateFields(DataRow R, string list_type)
        {// da rivedere
        //    if (list_type=="buonodicarico") {
        //        if (R["!clawbackamount"].ToString()=="") R["!clawbackamount"]=0;
        //    }
        }

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);

            //SetDefault(PrimaryTable,"!clawbackamount",0);
		}
	}
}
