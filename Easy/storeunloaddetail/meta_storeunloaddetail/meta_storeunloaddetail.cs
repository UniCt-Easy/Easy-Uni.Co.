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

namespace meta_storeunloaddetail
{
	/// <summary>
	/// </summary>
	public class Meta_storeunloaddetail : Meta_easydata {
		public Meta_storeunloaddetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "storeunloaddetail") {
			EditTypes.Add("default");
			EditTypes.Add("single");
			ListingTypes.Add("default");
            ListingTypes.Add("dettaglio");
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.SetSelector(T, "idstoreunload");
            RowChange.MarkAsAutoincrement(T.Columns["idstoreunloaddetail"], null, null, 6);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		protected override Form GetForm(string FormName)
		{
			
            if (FormName == "single") {
                Name = "Dettaglio scarico magazzino ";
                return MetaData.GetFormByDllName("storeunloaddetail_single");
            }
            return null;
		}

        public override void DescribeColumns (DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "dettaglio") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                //DescribeAColumn(T, "idstoreunloaddetail", "#", nPos++);
                //DescribeAColumn(T, "idstock", "Stock", nPos++);
                DescribeAColumn(T, "number", "Quant.", nPos++);
                //DescribeAColumn(T, "!intcode", "Cod. Art.", "stockview.intcode", nPos++);
                DescribeAColumn(T, "!list", "Art.", "stockview.list", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"],"n");
                DescribeAColumn(T, "!surname", "Cognome", "booking.surname", nPos++);
                DescribeAColumn(T, "!forename", "Nome", "bookig.forename", nPos++);
                //DescribeAColumn(T, "!idstore", "", "stockview.idstore", -1);
                DescribeAColumn(T, "!manager", "Respons.","manager.title", nPos++);
                DescribeAColumn(T, "!store", "Magazzino", "stockview.store", nPos++);
                DescribeAColumn(T, "!ybooking", "Es.Pren.", "booking.ybooking", nPos++);
                DescribeAColumn(T, "!nbooking", "N.Pren.", "booking.nbooking", nPos++);
                //DescribeAColumn(T, "invkind", "Tipo Fatt.", nPos++);
                //DescribeAColumn(T, "yinv", "Eserc. Fatt.", nPos++);
                //DescribeAColumn(T, "ninv", "Num. Fatt.", nPos++);
                //DescribeAColumn(T, "rownum", "Num. Dett. Fattura", nPos++);
            }
        }   

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "storeunloaddetailview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (CfgFn.GetNoNullDecimal(R["number"]) <= 0) {
                errmess = "La quantit‡ scaricata non puÚ essere minore o uguale a zero.";
                errfield = "number";
                return false;
            }

            return true;        }
	}
}
