
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

namespace meta_estimatedetail {
    /// <summary>

    /// </summary>
    public class Meta_estimatedetail : Meta_easydata {
        public Meta_estimatedetail(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "estimatedetail") {
            EditTypes.Add("single");
            EditTypes.Add("default");
            ListingTypes.Add("lista");
            ListingTypes.Add("annullati");
            ListingTypes.Add("default");
            ListingTypes.Add("dettaglio");
            ListingTypes.Add("contabilizza");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "yestim");
            RowChange.SetSelector(T, "nestim");
            RowChange.setMinimumTempValue(T.Columns["nestim"],999000);
            RowChange.SetSelector(T, "idestimkind");
            RowChange.MarkAsAutoincrement(T.Columns["rownum"], null, null, 6);
            RowChange.MarkAsAutoincrement(T.Columns["idgroup"], null, null, 6); //sa
            DataRow R = base.Get_New_Row(ParentRow, T);
            RowChange.ClearAutoIncrement(T.Columns["idgroup"]); //sa
            return R;
        }

        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            if ((C.ColumnName == "idinc_taxable") || (C.ColumnName == "idinc_iva") ||
                (C.ColumnName == "iduniqueformcode") || (C.ColumnName == "nform")) return;
            if (C.ColumnName == "idepacc") return;
            if (C.ColumnName == "stop") return;
            if (C.ColumnName == "start") return;
            if (C.ColumnName == "epkind") return;
            base.InsertCopyColumn(C, Source, Dest);
        }

        protected override Form GetForm(string FormName) {

            if (FormName == "single") {
                Name = "Dettaglio contratto attivo";
                return MetaData.GetFormByDllName("estimatedetail_single");
            }

            if (FormName == "default") {
                Name = "Dettaglio contratto attivo";
                DefaultListType = "dettaglio";
                return GetFormByDllName("estimatedetail_default");
            }

            return null;
        }

        public override bool FilterRow(DataRow R, string list_type) {
	        if (list_type == "lista") {
		        //if (!R.Table.Columns.Contains("rownum_main")) return true;
		        //   if (R["rownum_main"] != DBNull.Value) return false;
		        //   return true;
		        if (R["stop"] == DBNull.Value) return true;
		        return false;
	        }
	        //if (list_type == "listacollegati") {
	        //	if (!R.Table.Columns.Contains("rownum_main")) return false;
	        //	if (R["rownum_main"] == DBNull.Value) return false;
	        //	Consente di visualizzare i dettagli annullati collegati, nel grid di sotto.

	        //	object MainRownum = R.Table.ExtendedProperties["rownum"];
	        //	if (MainRownum != null) {
	        //		if (R["rownum_main"].ToString() != MainRownum.ToString()) return false;
	        //	}
	        //	return true;
	        //}
	        if (list_type == "annullati") {
		        if (R["stop"] != DBNull.Value) return true;
		        return false;
	        }
	        return true;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if ((listtype == "lista")|| (listtype == "annullati")) {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idgroup", "Gruppo", nPos++);
                DescribeAColumn(T, "rownum", "Numero Riga", nPos++);
                DescribeAColumn(T, "rownum_main", "Riga principale", nPos++);
                DescribeAColumn(T, "start", "Inizio validità", nPos++);
                DescribeAColumn(T, "stop", "Fine validità", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "number", "Q.tà", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
                DescribeAColumn(T, "!imponibile", "Imponibile tot.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!imponibile"], "n");
                DescribeAColumn(T, "!tipoiva", "Tipo Iva", "ivakind.description", nPos++);
                DescribeAColumn(T, "taxrate", "% IVA", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxrate"], "p");
                DescribeAColumn(T, "!iva", "Tot.Iva", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!iva"], "n");
                DescribeAColumn(T, "discount", "Sconto", nPos++);
                DescribeAColumn(T, "!totaleriga", "Totale riga", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
                HelpForm.SetFormatForColumn(T.Columns["!totaleriga"], "n");
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                DescribeAColumn(T, "!codeupb", "UPB", "upb_detail.codeupb", nPos++);
                DescribeAColumn(T, "!registry", "Cliente", "registry.title", nPos++);
                DescribeAColumn(T, "epkind", ".Tipo EP", nPos++);
                ComputeRowsAs(T, listtype);
                if (T.Columns.Contains("rownum_main")) FilterRows(T);
            }

            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idestimkind", ".idestimkind", nPos++);
                DescribeAColumn(T, "yestim", ".yestim", nPos++);
                DescribeAColumn(T, "nestim", ".nestim", nPos++);
                DescribeAColumn(T, "rownum", ".rownum", nPos++);
                DescribeAColumn(T, "idgroup", "#", nPos++);
                DescribeAColumn(T, "!codeupb", "UPB", nPos++);
                DescribeAColumn(T, "!codeupb_iva", "UPB iva", "upb_iva.codeupb", nPos++);
                DescribeAColumn(T, "!registry", "Cliente", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "number", "Q.tà", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
                DescribeAColumn(T, "taxrate", "IVA", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxrate"], "p");
                DescribeAColumn(T, "discount", "Sconto", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
                DescribeAColumn(T, "!totaleriga", "Totale riga", nPos++);
                DescribeAColumn(T, "start", "Data inizio validità", nPos++);
                DescribeAColumn(T, "stop", "Fine val.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!totaleriga"], "n");
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                ComputeRowsAs(T, listtype);
            }

            if (listtype == "contabilizza") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idestimkind", ".idestimkind", nPos++);
                DescribeAColumn(T, "!estimkind", "Tipo Contratto", nPos++);
                DescribeAColumn(T, "yestim", "Esercizio", nPos++);
                DescribeAColumn(T, "nestim", "Numero", nPos++);
                DescribeAColumn(T, "rownum", ".rownum", nPos++);
                DescribeAColumn(T, "!registry", "Cliente", "registry2.title", nPos++);
                DescribeAColumn(T, "idgroup", "#", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "!codeupb", "UPB", "upb_estimdetail.codeupb", nPos++);
                DescribeAColumn(T, "!codeupb_iva", "UPB iva", "upb_estimdetail_iva.codeupb", nPos++);
                DescribeAColumn(T, "number", "Q.tà", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
                DescribeAColumn(T, "taxrate", "IVA", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxrate"], "p");
                DescribeAColumn(T, "discount", "Sconto", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
                DescribeAColumn(T, "!totaleriga", "Totale riga", nPos++);
                DescribeAColumn(T, "iduniqueformcode", "Cod. bollettino univoco", nPos++);
                DescribeAColumn(T, "start", "Data inizio validità", nPos++);
                DescribeAColumn(T, "stop", "Fine val.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!totaleriga"], "n");
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                ComputeRowsAs(T, listtype);
            }

        }

        public override void CalculateFields(DataRow R, string list_type) {
            if (list_type == "lista" || list_type == "listaimpon" || list_type == "listaimpos" ||
                list_type == "default" || list_type == "contabilizza") {
                decimal imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                double imponibilereale = Convert.ToDouble(imponibile);
                double imposta = CfgFn.GetNoNullDouble(R["taxrate"]);
                double sconto = CfgFn.GetNoNullDouble(R["discount"]);
                double quantita = CfgFn.GetNoNullDouble(R["number"]);
                double impo = CfgFn.RoundValuta(imponibilereale * quantita * (1 - sconto));
                double iva = CfgFn.GetNoNullDouble(R["tax"]);

                if (R.Table.Columns.Contains("!imponibile")) {
                    R["!imponibile"] = impo;
                }

                if (R.Table.Columns.Contains("!iva")) {
                    R["!iva"] = iva;
                }

                R["!totaleriga"] = impo + iva;
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {


            if (R["idestimkind"].ToString() == "") {
                errmess = "Il codice tipo contratto è obbligatorio, annullare l'inserimento ed inserirlo nel contratto";
                errfield = "idestimkind";
                return false;
            }

            if (R["number"] == DBNull.Value) {
                errmess = "E' necessario specificare la quantità";
                errfield = "number";
                return false;
            }

            if (R["detaildescription"].ToString().Trim() == "") {
                errmess = "E' necessario specificare la descrizione";
                errfield = "detaildescription";
                return false;
            }

            if (R["taxable"] == DBNull.Value) {
                errmess = "E' necessario specificare l'imponibile";
                errfield = "taxable";
                return false;
            }

            if (CfgFn.GetNoNullDecimal(R["taxable"]) < 0) {
                errmess = "E' necessario che l'imponibile sia positivo";
                errfield = "taxable";
                return false;
            }

            string multireg = Conn.DO_READ_VALUE("estimatekind", "(idestimkind=" +
                                                                 QueryCreator.quotedstrvalue(R["idestimkind"], true) +
                                                                 ")", "multireg").ToString();

            if ((R["idreg"] == DBNull.Value) && (multireg == "S")) {
                errmess = "Il 'Cliente' è obbligatorio";
                errfield = "idreg";
                return false;
            }

            if ((R["competencystart"] != DBNull.Value) && (R["competencystop"] != DBNull.Value)) {
                DateTime competencystart = (DateTime) R["competencystart"];
                DateTime competencystop = (DateTime) R["competencystop"];
                if (competencystop < competencystart) {
                    errmess = "La data di fine competenza deve essere successiva alla data inizio competenza";
                    errfield = "competencystart";
                    return false;
                }
            }

            if (R["stop"] != DBNull.Value) {
                DateTime stop = (DateTime) R["stop"];
                if (stop.Year < CfgFn.GetNoNullInt32(R["yestim"])) {
                    errmess = "La data di annullamento deve essere successiva all'anno di creazione del contratto";
                    errfield = "stop";
                    return false;
                }
            }

            if (R["start"] != DBNull.Value) {
                DateTime start = (DateTime) R["start"];
                if (start.Year < CfgFn.GetNoNullInt32(R["yestim"])) {
                    errmess = "La data di inizio validità deve essere successiva all'anno di creazione del contratto";
                    errfield = "start";
                    return false;
                }
            }

            if ((R["start"] != DBNull.Value) && (R["stop"] != DBNull.Value)) {
                DateTime start = (DateTime) R["start"];
                DateTime stop = (DateTime) R["stop"];
                if (stop < start) {
                    errmess = "La data di annullamento deve essere successiva alla data inizio";
                    errfield = "start";
                    return false;
                }
            }

            if (R["taxable"] == DBNull.Value) {
				errmess= "E' necessario specificare l'imponibile";
				errfield="taxable";
				return false;
			}

            if (!base.IsValid(R, out errmess, out errfield)) return false;
            return true;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "toinvoice", "S");
            SetDefault(PrimaryTable, "flag", 0);
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "dettaglio") {
                return base.SelectOne(ListingType, filter, "estimatedetail_extview", ToMerge);
            }

            if (ListingType == "flussocrediti") {
                return base.SelectOne(ListingType, filter, "estimatedetailview", ToMerge);
            }

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
    }
}
