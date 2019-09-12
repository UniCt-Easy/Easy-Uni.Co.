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
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_invoicedetailview//meta_dettdocumentoivaview//
{
	/// <summary>
	/// Summary description for Meta_dettdocumentoivaview
	/// </summary>
	public class Meta_invoicedetailview : Meta_easydata {
		public Meta_invoicedetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoicedetailview") {
			Name="Elenco dettagli documenti IVA";
			ListingTypes.Add("listaimpon");
			ListingTypes.Add("listaimpos");
			ListingTypes.Add("listaspesa");
			ListingTypes.Add("listaentrata");
            ListingTypes.Add("dettaglio");
            ListingTypes.Add("flussocrediti");
            }
        private string[] mykey = new string[] { "idinvkind", "yinv", "ninv","rownum" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "flussocrediti") {
                sorting = "invoicekind asc,yinv desc, ninv desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }
        public override bool FilterRow(DataRow R, string list_type)
		{
			if (list_type=="listaimpon")
			{
				if (R["idexp_taxable"]==DBNull.Value && R["idinc_taxable"]==DBNull.Value)return false;
				return true;
			}
			if (list_type=="listaimpos")
			{
				if (R["idexp_iva"]==DBNull.Value && R["idinc_iva"]==DBNull.Value)return false;
				return true;
			}
			return true;
		}
		public override	 void CalculateFields(DataRow R, string list_type)
		{
			if (list_type=="listaimpon") 
			{
//				if (R.RowState!=DataRowState.Modified) return;

//				if ((R["idexp_taxable"]!=DBNull.Value) &&
//					(R["idexp_iva"]!=DBNull.Value) &&
//					(R["idexp_taxable",DataRowVersion.Original]==DBNull.Value) &&
//					(R["idexp_iva",DataRowVersion.Original]==DBNull.Value)
//					)
//				{
//					R["idexp_iva"]=R["idexp_taxable"];
//				}
//				
//				if ((R["idinc_taxable"]!=DBNull.Value) &&
//					(R["idinc_iva"]!=DBNull.Value) &&
//					(R["idinc_taxable",DataRowVersion.Original]==DBNull.Value) &&
//					(R["idinc_iva",DataRowVersion.Original]==DBNull.Value)
//					)
//				{
//					R["idinc_iva"]=R["idinc_taxable"];
//				}
//
//				if ((R["idexp_taxable"]==DBNull.Value) &&
//					(R["idexp_taxable",DataRowVersion.Original]!=DBNull.Value) &&
//					(R["idexp_iva",DataRowVersion.Original].ToString()==R["idexp_taxable",DataRowVersion.Original].ToString())
//					)
//				{
//					R["idexp_iva"]=R["idexp_taxable"];
//				}
//
//				if ((R["idinc_taxable"]==DBNull.Value) &&
//					(R["idinc_taxable",DataRowVersion.Original]!=DBNull.Value) &&
//					(R["idinc_iva",DataRowVersion.Original].ToString()==R["idinc_taxable",DataRowVersion.Original].ToString())
//					)
//				{
//					R["idinc_iva"]=R["idinc_taxable"];
//				}

			}
			
		}

        //TASK 10706
        public void CompletaCaption(DataTable T) { 

            foreach (DataColumn C in T.Columns) {
                if ((C.ColumnName == "codemotive") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Codice causale");
                    continue;
                }
                if ((C.ColumnName == "codeupb") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Codice upb");
                    continue;
                }
                if ((C.ColumnName == "codeupb_iva") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Codice upb IVA");
                    continue;
                }
                if ((C.ColumnName == "estimkind") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Tipo contratto attivo");
                    continue;
                }
                if ((C.ColumnName == "nestim") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".N.contratto attivo");
                    continue;
                }
                if ((C.ColumnName == "estimrownum") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".N. dettaglio contratto attivo");
                    continue;
                }
                if ((C.ColumnName == "idmankind") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Tipo contratto passivo");
                    continue;
                }
                if ((C.ColumnName == "nman") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".N.contratto passivo");
                    continue;
                }
                if ((C.ColumnName == "manrownum") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".N. dettaglio contratto passivo");
                    continue;
                }
                if ((C.ColumnName == "codesor_siope") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Codice siope");
                    continue;
                }
            }
        }



        public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="listaimpon" || listtype=="listaimpos") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				int nPos = 1;
				DescribeAColumn(T, "rownum","Num. riga",nPos++);
				DescribeAColumn(T, "detaildescription", "Descrizione",nPos++);
                DescribeAColumn(T, "npackage", "Q.tà", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["npackage"], "n");
                DescribeAColumn(T, "number", "Totale Q.tà Ordinata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "taxable_euro", "Imponibile totale", nPos++);
				DescribeAColumn(T, "iva_euro", "Iva",nPos++);
				DescribeAColumn(T,"rowtotal","Totale riga",nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
			    DescribeAColumn(T, "codesor_siope", "Codice siope", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["rowtotal"], "c");
				if (listtype=="listaimpon")
				{
					ComputeRowsAs(T,"listaimpon");
				}
				FilterRows(T);
			}
			if (listtype=="listaspesa" || listtype=="listaentrata") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "rownum", "Num. riga", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "npackage", "Q.tà", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["npackage"], "n");
                DescribeAColumn(T, "number", "Totale Q.tà Ordinata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "taxable_euro", "Imponibile totale", nPos++);
                DescribeAColumn(T, "iva_euro", "Iva", nPos++);
                DescribeAColumn(T, "rowtotal", "Totale riga", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);



                HelpForm.SetFormatForColumn(T.Columns["rowtotal"], "c");
			}

            if (listtype == "dettaglio") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "invoicekind", "Fattura", nPos++);
                DescribeAColumn(T, "yinv", "Eserc. Fattura", nPos++);
                DescribeAColumn(T, "ninv", "Num. Fattura", nPos++);
                DescribeAColumn(T, "registry", "Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "cf", "CF Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "p_iva", "P. IVA Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "flagbuysell", "Acquisto / Vendita", nPos++);
                DescribeAColumn(T, "flagvariation", "Fattura / Nota", nPos++);
                DescribeAColumn(T, "rownum", "Num. riga", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "number", "Q.tà", nPos++);
                DescribeAColumn(T, "description", "Descrizione Fattura", nPos++);
                DescribeAColumn(T, "taxable", "Importo Unitario", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "taxable_euro", "Imponibile totale", nPos++);
                DescribeAColumn(T, "ivakind", "Tipo IVA", nPos++);
                DescribeAColumn(T, "iva_euro", "Iva", nPos++);
                DescribeAColumn(T, "rowtotal", "Totale riga", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                DescribeAColumn(T, "va3typedescription", "Quadro VF26", nPos++);
                DescribeAColumn(T, "code", "Cod.Nomenclatura", nPos++);
                DescribeAColumn(T, "intrastatcode", "Nomenclatura", nPos++);
                DescribeAColumn(T, "intrastatmeasure", "Unità di misura", nPos++);
                DescribeAColumn(T, "intcode", "Cod. Listino", nPos++);

                DescribeAColumn(T, "intrastatoperationkind", "Beni/Servizi", nPos++);
                DescribeAColumn(T, "servicecode", "Cod.Servizi", nPos++);
                DescribeAColumn(T, "intrastatservice", "Servizi", nPos++);
                DescribeAColumn(T, "supplymethodcode", "Cod.Erogazione", nPos++);
                DescribeAColumn(T, "intrastatsupplymethod", "Erogazione", nPos++);
                DescribeAColumn(T, "toincludeinpaymentindicator", "Includi in Indicatore Tempest. dei Pagamenti", nPos++);
                DescribeAColumn(T, "touniqueregister", "Protocolla nel Registro Unico", nPos++);
               
                DescribeAColumn(T, "ymov_taxable", "Eserc. Contab. Imponibile", nPos++);
                DescribeAColumn(T, "nmov_taxable", "Num. Contab. Imponibile", nPos++);
                DescribeAColumn(T, "ymov_iva", "Eserc. Contab. Iva", nPos++);
                DescribeAColumn(T, "nmov_iva", "Num. Contab. Iva", nPos++);

                DescribeAColumn(T, "yepexp", "Eserc. Imp. Budget", nPos++);
                DescribeAColumn(T, "nepexp", "Num. Imp. Budget", nPos++);
                DescribeAColumn(T, "yepacc", "Eserc. Accert. Budget", nPos++);
                DescribeAColumn(T, "nepacc", "Num. Accert. Budget", nPos++);
                
                //TASK 10706
                //CompletaCaption(T);

                DescribeAColumn(T, "codeupb", "Codice upb", nPos++);
                DescribeAColumn(T, "codeupb_iva", "Codice upb IVA", nPos++);
                DescribeAColumn(T, "estimkind", "Tipo contratto attivo", nPos++);
                DescribeAColumn(T, "yestim", "Eserc. contratto attivo", nPos++);
                DescribeAColumn(T, "nestim", "N.contratto attivo", nPos++);
                DescribeAColumn(T, "estimrownum", "N. dettaglio contratto attivo", nPos++);
                DescribeAColumn(T, "idmankind", "Tipo contratto passivo", nPos++);
                DescribeAColumn(T, "yman", "Eserc. contratto passivo", nPos++);
                DescribeAColumn(T, "nman", "N.contratto passivo", nPos++);
                DescribeAColumn(T, "manrownum", "N. dettaglio contratto passivo", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["rowtotal"], "c");

            }
            if (listtype == "flussocrediti") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idinvkind", ".idinvkind", nPos++);
                DescribeAColumn(T, "invoicekind", "Fattura", nPos++);
                DescribeAColumn(T, "yinv", "Eserc. Fattura", nPos++);
                DescribeAColumn(T, "ninv", "Num. Fattura", nPos++);
                DescribeAColumn(T, "rownum", "Num. riga", nPos++);
                DescribeAColumn(T, "registry", "Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "cf", "CF Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "p_iva", "P. IVA Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "flagvariation", "Fattura / Nota", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "number", "Q.tà", nPos++);
                DescribeAColumn(T, "description", "Descrizione Fattura", nPos++);
                DescribeAColumn(T, "taxable", "Importo Unitario", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "taxable_euro", "Imponibile totale", nPos++);
                DescribeAColumn(T, "ivakind", "Tipo IVA", nPos++);
                DescribeAColumn(T, "iva_euro", "Iva", nPos++);
                DescribeAColumn(T, "rowtotal", "Totale riga", nPos++);
                DescribeAColumn(T, "ymov_taxable", "Eserc. Contab. Imponibile", nPos++);
                DescribeAColumn(T, "nmov_taxable", "Num. Contab. Imponibile", nPos++);
                DescribeAColumn(T, "ymov_iva", "Eserc. Contab. Iva", nPos++);
                DescribeAColumn(T, "nmov_iva", "Num. Contab. Iva", nPos++);
                DescribeAColumn(T, "yepexp", "Eserc. Imp. Budget", nPos++);
                DescribeAColumn(T, "nepexp", "Num. Imp. Budget", nPos++);
                DescribeAColumn(T, "yepacc", "Eserc. Accert. Budget", nPos++);
                DescribeAColumn(T, "nepacc", "Num. Accert. Budget", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["rowtotal"], "c");

            }
            }   


	}
}
