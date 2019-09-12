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
using metaeasylibrary;
using metadatalibrary;
using System.Data;


namespace meta_estimatedetailview {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_estimatedetailview: Meta_easydata {
		public Meta_estimatedetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "estimatedetailview") {
			Name= "Riga contratto attivo";
			ListingTypes.Add("dettaglio");
			ListingTypes.Add("listaimpon");
			ListingTypes.Add("listaimpos");
			ListingTypes.Add("listaentrata");
		}
		public override bool FilterRow(DataRow R, string list_type)
		{
			if (list_type=="listaimpon")
			{
				if (R["idinc_taxable"]==DBNull.Value)return false;
				return true;
			}
			if (list_type=="listaimpos")
			{
				if (R["idinc_iva"]==DBNull.Value)return false;
				return true;
			}
			return true;
		}
		public override	 void CalculateFields(DataRow R, string list_type)
		{
			if (list_type=="listaimpon") 
			{
                //if (R.RowState!=DataRowState.Modified) return;

                //if ((R["idinc_taxable"]!=DBNull.Value) &&
                //    (R["idinc_iva"]!=DBNull.Value) &&
                //    (R["idinc_taxable",DataRowVersion.Original]==DBNull.Value) &&
                //    (R["idinc_iva",DataRowVersion.Original]==DBNull.Value)
                //    )
                //{
                //    R["idinc_iva"]=R["idinc_taxable"];
                //}
                //if ((R["idinc_taxable"]==DBNull.Value) &&
                //    (R["idinc_taxable",DataRowVersion.Original]!=DBNull.Value) &&
                //    (R["idinc_iva",DataRowVersion.Original].ToString()==R["idinc_taxable",DataRowVersion.Original].ToString())
                //    )
                //{
                //    R["idinc_iva"]=R["idinc_taxable"];
                //}

			}
			
		}

		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="dettaglio") {
				sorting = "estimkind asc,yestim desc,nestim desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
        private string[] mykey = new string[] { "idestimkind", "yestim", "nestim", "rownum" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="dettaglio") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "estimkind", "Tipo", nPos++);
                DescribeAColumn(T, "yestim", "Esercizio", nPos++);
                DescribeAColumn(T, "nestim", "Numero", nPos++);
                DescribeAColumn(T, "rownum", "Num. riga", nPos++);
                DescribeAColumn(T, "description", "Descr. Contratto Att.", nPos++);
                DescribeAColumn(T, "idinv", "Class. inventariale", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "number", "Q.tà ordinata", nPos++);
                DescribeAColumn(T, "start", "Inizio val.", nPos++);
                DescribeAColumn(T, "stop", "Fine val.", nPos++);
                DescribeAColumn(T, "codemotive", "Causale EP", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                DescribeAColumn(T, "flagintracom", "Intracom", nPos++);

                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
			}
            if(listtype=="flussocrediti"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idestimkind", ".idestimkind", nPos++);
                DescribeAColumn(T, "estimkind", "Tipo", nPos++);
                DescribeAColumn(T, "yestim", "Esercizio", nPos++);
                DescribeAColumn(T, "nestim", "Numero", nPos++);
                DescribeAColumn(T, "rownum", "Num. riga", nPos++);
                DescribeAColumn(T, "description", "Descr. Contratto Att.", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "number", "Q.tà ordinata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                }
            if (listtype=="listaimpon" || listtype=="listaimpos") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				
				DescribeAColumn(T, "rownum","Num. riga",1);
				DescribeAColumn(T, "detaildescription", "Descrizione",2);
				DescribeAColumn(T, "number", "Q.tà",3);
				HelpForm.SetFormatForColumn(T.Columns["number"], "n");				
				DescribeAColumn(T, "taxable_euro", "Imponibile totale",4);
				DescribeAColumn(T, "iva_euro", "Iva",5);
				DescribeAColumn(T,"rowtotal","Totale riga",6);
				HelpForm.SetFormatForColumn(T.Columns["rowtotal"], "c");
				if (listtype=="listaimpon")
				{
					ComputeRowsAs(T,"listaimpon");
				}
                DescribeAColumn(T, "competencystart", "Inizio comp.", 7);
                DescribeAColumn(T, "competencystop", "Fine comp.", 8);
                DescribeAColumn(T, "flagintracom", "Intracom", 9);
                DescribeAColumn(T, "epkind", ".Tipo EP", 10);
                FilterRows(T);
			}


			if (listtype=="listaentrata") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T, "rownum","Num. riga",1);
				DescribeAColumn(T, "detaildescription", "Descrizione",2);
				DescribeAColumn(T, "number", "Q.tà",3);
				HelpForm.SetFormatForColumn(T.Columns["number"], "n");				
				DescribeAColumn(T, "taxable_euro", "Imponibile totale",4);
				DescribeAColumn(T, "iva_euro", "Iva",5);
				DescribeAColumn(T,"rowtotal","Totale riga",6);
				HelpForm.SetFormatForColumn(T.Columns["rowtotal"], "c");
                DescribeAColumn(T, "competencystart", "Inizio comp.", 7);
                DescribeAColumn(T, "competencystop", "Fine comp.", 8);
                DescribeAColumn(T, "flagintracom", "Intracom", 9);
                DescribeAColumn(T, "epkind", ".Tipo EP", 10);
            }
		}   
	
	}
}
