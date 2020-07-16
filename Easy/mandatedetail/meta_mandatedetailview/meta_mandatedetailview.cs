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
using metaeasylibrary;
using metadatalibrary;
using System.Data;


namespace meta_mandatedetailview {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_mandatedetailview: Meta_easydata {
		public Meta_mandatedetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "mandatedetailview") {
			Name= "Riga Contratto Passivo";
			ListingTypes.Add("dettaglio");
			ListingTypes.Add("listaimpon");
			ListingTypes.Add("listaimpos");
			ListingTypes.Add("listaspesa");
		}
		public override bool FilterRow(DataRow R, string list_type){
			if (list_type=="listaimpon"){
				if (R["idexp_taxable"]==DBNull.Value)return false;
				return true;
			}
			if (list_type=="listaimpos"){
				if (R["idexp_iva"]==DBNull.Value)return false;
				return true;
			}

			return true;
		}
        private string[] mykey = new string[] { "idmankind", "yman", "nman", "rownum" };
        public override string[] primaryKey() {
            return mykey;
        }


        public override	 void CalculateFields(DataRow R, string list_type){
			if (list_type=="listaimpon") {
//				if (R.RowState!=DataRowState.Modified) return;
//
//				if ((R["idexp_taxable"]!=DBNull.Value) &&
//					(R["idexp_iva"]!=DBNull.Value) &&
//					(R["idexp_taxable",DataRowVersion.Original]==DBNull.Value) &&
//					(R["idexp_iva",DataRowVersion.Original]==DBNull.Value)
//					){
//					R["idexp_iva"]=R["idexp_taxable"];
//				}
//				if ((R["idexp_taxable"]==DBNull.Value) &&
//					(R["idexp_taxable",DataRowVersion.Original]!=DBNull.Value) &&
//					(R["idexp_iva",DataRowVersion.Original].ToString()==R["idexp_taxable",DataRowVersion.Original].ToString())
//					){
//					R["idexp_iva"]=R["idexp_taxable"];
//				}

			}
			
		}

		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="dettaglio") {
				sorting = "mankind asc,yman desc,nman desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
	
		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="dettaglio") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "mankind", "Tipo", nPos++);
                DescribeAColumn(T, "yman", "Esercizio", nPos++);
                DescribeAColumn(T, "nman", "Numero", nPos++);
                DescribeAColumn(T, "rownum", "Num. riga", nPos++);
                DescribeAColumn(T, "description", "Descr. Contr. Pass.", nPos++);
                DescribeAColumn(T, "codeinv", "Class. inventariale", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "list", "Listino", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "number", "Q.t‡", nPos++);
                DescribeAColumn(T, "start", "Inizio val.", nPos++);
                DescribeAColumn(T, "stop", "Fine val.", nPos++);
                DescribeAColumn(T, "codemotive", "Causale EP", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                DescribeAColumn(T, "flagintracom", "Intracom", nPos++);
                DescribeAColumn(T, "cupcode", "CUP", nPos++);
                DescribeAColumn(T, "yepexp", "Anno impegno di B.", nPos++);
                DescribeAColumn(T, "nepexp", "N. impegno di B.", nPos++);
                DescribeAColumn(T, "yexpimpo", "Anno impegno impon.", nPos++);
                DescribeAColumn(T, "nexpimpo", "N. impegno impon.", nPos++);
                DescribeAColumn(T, "yexpiva", "Anno impegno iva", nPos++);
                DescribeAColumn(T, "nexpiva", "N. impegno iva", nPos++);


                HelpForm.SetFormatForColumn(T.Columns["number"], "n");				
			}
			if (listtype=="listaimpon" || listtype=="listaimpos") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "rownum", "Num. riga", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "npackage", "Q.t‡", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["npackage"], "n");
                DescribeAColumn(T, "number", "Totale Q.t‡ Ordinata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "taxable_euro", "Imponibile totale", nPos++);
                DescribeAColumn(T, "iva_euro", "Iva", nPos++);
                DescribeAColumn(T, "rowtotal", "Totale riga", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                DescribeAColumn(T, "epkind", "Tipo EP", nPos++);
                DescribeAColumn(T, "flagintracom", "Intracom", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["rowtotal"], "c");
				if (listtype=="listaimpon"){
					ComputeRowsAs(T,"listaimpon");
				}
				FilterRows(T);
			}


			if (listtype=="listaspesa") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
				DescribeAColumn(T, "rownum","Num. riga",nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "npackage", "Q.t‡", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["npackage"], "n");
                DescribeAColumn(T, "number", "Totale Q.t‡ Ordinata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "taxable_euro", "Imponibile totale", nPos++);
                DescribeAColumn(T, "iva_euro", "Iva", nPos++);
                DescribeAColumn(T, "rowtotal", "Totale riga", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                DescribeAColumn(T, "epkind", "Tipo EP", nPos++);
                DescribeAColumn(T, "flagintracom", "Intracom", nPos++);
                DescribeAColumn(T, "cupcode", "CUP", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["rowtotal"], "c");
			}

		}   
	
	}
}
