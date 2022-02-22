
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
using System.Windows.Forms;
using System.Data;


namespace meta_bankimportbill {
   public class Meta_bankimportbill : Meta_easydata {
		public Meta_bankimportbill(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "bankimportbill") {
           EditTypes.Add("default");
           ListingTypes.Add("default");
           ListingTypes.Add("detail");
		}
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idbankimport");
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null,
                null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);

            return R;
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Operazione su Partita Pendente";
                return GetFormByDllName("bankimportbill_default");
            }
            return null;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "detail") {
                foreach (DataColumn c in T.Columns) {
                    DescribeAColumn(T, c.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idbankimport", "Num. importazione", nPos++);
                DescribeAColumn(T, "ybill", "Esercizio", nPos++);
                DescribeAColumn(T, "nbill", "Num. bolletta", nPos++);
                DescribeAColumn(T, "billkind", "Tipo", nPos++);
                DescribeAColumn(T, "adate", "Data operazione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "motive", "Causale", nPos++);
                DescribeAColumn(T, "banknum", "Num.Banca", nPos++);
                DescribeAColumn(T, "bankcode", "Codice Banca", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);                
            }
        }
   }
}
