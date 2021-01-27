
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_assetacquireview {//meta_caricobeneinventarioview//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_assetacquireview : Meta_easydata {
		public Meta_assetacquireview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "assetacquireview") {
			Name= "carichi cespiti inventariabili";
			ListingTypes.Add("default");
			ListingTypes.Add("buonodicarico");
			ListingTypes.Add("buonoautomatico");
		}
        private string[] mykey = new string[] { "nassetacquire" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override bool FilterRow(DataRow R, string list_type) {
			if (list_type=="buonodicarico"){
                if (R["idassetload"] == DBNull.Value) return false;
                //if (R["idassetloadkind"]==DBNull.Value ||
                //    R["yassetload"]==DBNull.Value ||
                //    R["nassetload"]==DBNull.Value) return false;
				return true;
			}
			return true;
		}

        public override void CalculateFields (System.Data.DataRow R, string listtype) {
            string isPieceAcquire = R["ispieceacquire"].ToString().ToUpper();
            if (isPieceAcquire=="N") {
                R["!pieceorasset"] = "C";
            }
            else {
                R["!pieceorasset"] = "A";
            }
        }
        public override string GetSorting(string ListingType){
            string sorting;
            if (ListingType == "default"){
                sorting = "nassetacquire desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

				int nPos = 1;
				DescribeAColumn(T, "nassetacquire", "Num. carico",nPos++);
				DescribeAColumn(T, "idmankind", "Tipo  Contr. Passivo",nPos++);
				DescribeAColumn(T, "yman", "Eserc.  Contr. Passivo",nPos++);
				DescribeAColumn(T, "nman", "Num.  Contr. Passivo",nPos++);
				DescribeAColumn(T, "rownum", "Gruppo",nPos++);

                DescribeAColumn(T, "invoicekind", "Tipo Fattura", nPos++);
                DescribeAColumn(T, "yinv", "Eserc.Fattura", nPos++);
                DescribeAColumn(T, "ninv", "Num. Fattura", nPos++);
                DescribeAColumn(T, "invrownum", "Gruppo Fattura", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "invrownum", "Gruppo Fattura", nPos++);
                DescribeAColumn(T, "registry", "Cedente",nPos++);
				DescribeAColumn(T, "assetloadmotive", "Causale",nPos++);
				DescribeAColumn(T, "codeinv", "Codice class.",nPos++);
				DescribeAColumn(T, "inventorytree", "Desc. class",nPos++);
                DescribeAColumn(T, "intcode", "codice listino", nPos++);
                DescribeAColumn(T, "list", "Listino", nPos++);
                DescribeAColumn(T, "description", "Descrizione",nPos++);
				DescribeAColumn(T, "inventory", "Inventario",nPos++);
				DescribeAColumn(T, "assetloadkind", "Tipo buono",nPos++);
				DescribeAColumn(T, "yassetload", "Eserc. buono",nPos++);
				DescribeAColumn(T, "nassetload", "Num. buono",nPos++);
				DescribeAColumn(T, "ratificationdate", "Data ratifica", nPos++);
				DescribeAColumn(T, "number", "Q.tà",nPos++);
				DescribeAColumn(T, "taxable", "Imponibile",nPos++);
				DescribeAColumn(T, "taxrate", "Aliquota IVA",nPos++);
				//DescribeAColumn(T, "taxabletotal", "Tot. imp. (IVA incl.)",nPos++);
				DescribeAColumn(T, "total", "Tot. imp. (IVA incl.)",nPos++);
				DescribeAColumn(T, "cost", "Costo ",nPos++);
				DescribeAColumn(T,"abatable","IVA detraibile",nPos++);
				DescribeAColumn(T, "discount", "Sconto",nPos++);
				DescribeAColumn(T, "startnumber", "Num. iniziale",nPos++);
				DescribeAColumn(T, "adate", "Data cont.",nPos++);
				DescribeAColumn(T, "loadkind", "Flag tipo carico",nPos++);
				DescribeAColumn(T, "flagload", "Flag buono",nPos++);
                HelpForm.SetFormatForColumn(T.Columns["discount"],"p");
				HelpForm.SetFormatForColumn(T.Columns["taxrate"],"p");
			}
			if (ListingType=="buonodicarico") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;

                //DescribeAColumn(T, "nassetacquire", "Numero carico", nPos++);
                DescribeAColumn(T, "startnumber", "Num. iniz.", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                //DescribeAColumn(T, "adate", "Data acquisizione", nPos++);
                //DescribeAColumn(T, "inventorytree", "Class.inventariale", nPos++);
                DescribeAColumn(T, "number", "Quantità", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile unit.", nPos++);
                DescribeAColumn(T, "taxrate", "Aliquota IVA", nPos++);
                DescribeAColumn(T, "discount", "Sconto", nPos++);
                DescribeAColumn(T, "total", "Tot. imp. (IVA incl.)", nPos++);
                DescribeAColumn(T, "abatable", "IVA detraibile", nPos++);
                DescribeAColumn(T, "!pieceorasset", "Cespite/Accessorio", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
                HelpForm.SetFormatForColumn(T.Columns["taxrate"], "p");
                ComputeRowsAs(T, ListingType);
				FilterRows(T);
			}
			if (ListingType=="buonoautomatico") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

				DescribeAColumn(T, "nassetacquire", "Num. carico");
				DescribeAColumn(T, "registry", "Cedente");
				DescribeAColumn(T, "assetloadmotive", "Causale");
				DescribeAColumn(T, "codeinv", "Codice class.");
				DescribeAColumn(T, "inventorytree", "Desc. class");
                DescribeAColumn(T, "intcode", "codice listino");
                DescribeAColumn(T, "list", "Listino");
                DescribeAColumn(T, "description", "Descrizione");
				DescribeAColumn(T, "inventory", "Inventario");
				DescribeAColumn(T, "number", "Q.tà");
				DescribeAColumn(T, "taxable", "Imponibile");
				DescribeAColumn(T, "taxrate", "Aliquota IVA");
				DescribeAColumn(T, "discount", "Sconto");
				DescribeAColumn(T, "startnumber", "Num. iniziale");
				DescribeAColumn(T, "adate", "Data cont.");
				HelpForm.SetFormatForColumn(T.Columns["discount"],"p");
				HelpForm.SetFormatForColumn(T.Columns["taxrate"],"p");
			}
		}
	}
}
