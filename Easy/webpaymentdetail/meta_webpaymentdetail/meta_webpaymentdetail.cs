
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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_webpaymentdetail {
    public class Meta_webpaymentdetail :Meta_easydata {
        public Meta_webpaymentdetail(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "webpaymentdetail") {
            ListingTypes.Add("list");
            ListingTypes.Add("default");
            EditTypes.Add("single");
            EditTypes.Add("default");
            Name = "Dettaglio Prenotazione pagamento";
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "list") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "!list", "Articolo", "list.description", nPos++);
                DescribeAColumn(T, "number", "Quantità", nPos++);

				DescribeAColumn(T, "price", "Imponibile unitario", nPos++);
				DescribeAColumn(T, "tax", "Iva totale", nPos++);
				DescribeAColumn(T, "!totale","Totale", nPos++);

				DescribeAColumn(T, "!store", "Magazzino", "store.description", nPos++);
				DescribeAColumn(T, "annotations", "Annotazioni", nPos++);
				ComputeRowsAs(T, ListingType);
			}
        }
        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "flag_showcase", 0);
            }

        public override void CalculateFields(DataRow R, string list_type) {
			if (list_type == "list") {
				decimal imponibile=CfgFn.GetNoNullDecimal(R["price"]);
				decimal imposta=CfgFn.GetNoNullDecimal(R["tax"]);
				decimal quantita=CfgFn.GetNoNullDecimal(R["number"]);

				if (R.Table.Columns.Contains("!totale")) {
					R["!totale"] = (imponibile * quantita) + imposta;
				}
			}
		}

		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idwebpayment");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;

        }
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "webpaymentdetailview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }


        protected override Form GetForm(string FormName) {
            //DefaultListType = "default";
            if (FormName == "single") {
                return MetaData.GetFormByDllName("webpaymentdetail_single");
            }
            return null;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idlist"]) == 0) {
                errmess = "Il campo 'Articolo' è obbligatorio";
                errfield = "idlist";
                return false;
            }

            if (CfgFn.GetNoNullDecimal(R["number"]) == 0) {
                errmess = "Il campo 'Quantità' è obbligatorio";
                errfield = "number";
                return false;
            }
            if (CfgFn.GetNoNullDecimal(R["price"]) == 0) {
                errmess = "Il campo 'Prezzo unitario' non può essere zero";
                errfield = "price";
                return false;
            }

            if (CfgFn.GetNoNullDecimal(R["number"]) < 0) {
                errmess = "Il campo 'Quantità' dev'essere positivo";
                errfield = "number";
                return false;
            }
            return true;
        }

    }
}
