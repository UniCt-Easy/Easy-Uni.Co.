
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_mandatedetail {
    /// <summary>
    /// </summary>
    public class Meta_mandatedetail : Meta_easydata {
        public Meta_mandatedetail(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "mandatedetail") {
            EditTypes.Add("default");
            EditTypes.Add("single");
            ListingTypes.Add("lista");
            ListingTypes.Add("listaimpon");
            ListingTypes.Add("default");
            ListingTypes.Add("dettaglio");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "yman");
            RowChange.SetSelector(T, "nman");
            RowChange.SetSelector(T, "idmankind");
            RowChange.MarkAsAutoincrement(T.Columns["rownum"], null, null, 6);
            RowChange.MarkAsAutoincrement(T.Columns["idgroup"], null, null, 6);
            DataRow R = base.Get_New_Row(ParentRow, T);
            RowChange.ClearAutoIncrement(T.Columns["idgroup"]);

            return R;
        }

        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            if ((C.ColumnName == "idexp_taxable") || (C.ColumnName == "idexp_iva")) return;
            if (C.ColumnName == "idepexp") return;
            if (C.ColumnName == "cigcode") return;
            if (C.ColumnName == "idavcp") return;
            if (C.ColumnName == "idavcp_choice") return;
            if (C.ColumnName == "avcp_startcontract") return;
            base.InsertCopyColumn(C, Source, Dest);
        }

        protected override Form GetForm(string FormName) {

            if (FormName == "single") {
                Name = "Dettaglio contratto passivo";
                return MetaData.GetFormByDllName("mandatedetail_single"); //PinoRana
            }

            if (FormName == "default") {
                Name = "Dettaglio contratto passivo";
                DefaultListType = "dettaglio";
                return GetFormByDllName("mandatedetail_default");
            }

            return null;
        }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "lista") {
                sorting = "idgroup asc, rownum asc";
                return sorting;
            }

            return base.GetSorting(ListingType);
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idgroup", "Gruppo", nPos++);
                DescribeAColumn(T, "rownum", "Numero Riga", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "npackage", "Q.tà", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["npackage"], "n");
                DescribeAColumn(T, "number", "Totale Q.tà Ordinata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");

                DescribeAColumn(T, "taxable", "Importo unitario", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");

                DescribeAColumn(T, "!imponibile", "Imponibile tot.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!imponibile"], "n");

                DescribeAColumn(T, "!tipoiva", "Tipo Iva", "ivakind.description", nPos++);

                DescribeAColumn(T, "taxrate", "% IVA", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxrate"], "p");

                DescribeAColumn(T, "!iva", "Tot.Iva", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!iva"], "n");

                DescribeAColumn(T, "discount", "Sconto", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
                DescribeAColumn(T, "!totaleriga", "Totale riga", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!totaleriga"], "n");
                DescribeAColumn(T, "start", "Inizio val.", nPos++);
                DescribeAColumn(T, "stop", "Fine val.", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                DescribeAColumn(T, "!codeupb", "UPB", "upb_detail.codeupb", nPos++);
                DescribeAColumn(T, "!registry", "Fornitore", "registry.title", nPos++);
                DescribeAColumn(T, "!list", "Listino", "list.description", nPos++);
                DescribeAColumn(T, "cupcode", "CUP", nPos++);
                DescribeAColumn(T, "epkind", ".Tipo EP", nPos++);

                ComputeRowsAs(T, listtype);
            }


            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idmankind", ".idmankind", nPos++);
                DescribeAColumn(T, "yman", ".yman", nPos++);
                DescribeAColumn(T, "nman", ".nman", nPos++);
                DescribeAColumn(T, "rownum", ".rownum", nPos++);
                DescribeAColumn(T, "idgroup", "#", nPos++);
                DescribeAColumn(T, "!codeupb", "UPB", nPos++);
                DescribeAColumn(T, "!registry", "Fornitore", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "npackage", "Q.tà", nPos++);
                DescribeAColumn(T, "number", "Totale Q.tà Ordinata", nPos++);
                DescribeAColumn(T, "taxable", "Importo unitario", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                HelpForm.SetFormatForColumn(T.Columns["npackage"], "n");
                HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
                DescribeAColumn(T, "taxrate", "IVA", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxrate"], "p");
                DescribeAColumn(T, "discount", "Sconto", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
                DescribeAColumn(T, "!totaleriga", "Totale riga", nPos++);
                DescribeAColumn(T, "start", "Inizio val.", nPos++);
                DescribeAColumn(T, "stop", "Fine val.", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!totaleriga"], "n");
                DescribeAColumn(T, "cupcode", "CUP", nPos++);
                ComputeRowsAs(T, listtype);
            }

        }

        public override void CalculateFields(DataRow R, string list_type) {
            if (list_type == "lista" || list_type == "listaimpon" || list_type == "listaimpos" ||
                list_type == "default") {
                decimal imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                double imponibilereale = Convert.ToDouble(imponibile);
                double imposta = CfgFn.GetNoNullDouble(R["taxrate"]);
                double sconto = CfgFn.GetNoNullDouble(R["discount"]);
                double quantita = CfgFn.GetNoNullDouble(R["npackage"]);
                double impo = CfgFn.RoundValuta(imponibilereale * quantita * (1 - sconto));
                double iva = CfgFn.GetNoNullDouble(R["tax"]);
                //CfgFn.RoundValuta(imponibilereale*quantita*(1-sconto)*imposta);

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
            if (R["idmankind"].ToString() == "") {
                errfield = "idmankind";
                errmess = "E' necessario scegliere il tipo contratto";
                return false;
            }

            if (CfgFn.GetNoNullDecimal(R["taxable"]) < 0) {
                errmess = "E' necessario che l'imponibile sia positivo";
                errfield = "taxable";
                return false;
            }


            if (R["npackage"] == DBNull.Value) {
                errmess = "E' necessario specificare la quantità";
                errfield = "npackage";
                return false;
            }

            if (R["detaildescription"].ToString().Trim() == "") {
                errmess = "E' necessario specificare la descrizione";
                errfield = "detaildescription";
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
                if (stop.Year < CfgFn.GetNoNullInt32(R["yman"])) {
                    errmess = "La data di annullamento deve essere successiva all'anno di creazione del contratto";
                    errfield = "stop";
                    return false;
                }
            }

            if (R["start"] != DBNull.Value) {
                DateTime start = (DateTime) R["start"];
                if (start.Year < CfgFn.GetNoNullInt32(R["yman"])) {
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

            if (R.Table.Columns.Contains("epkind")) {
                object epkind = R["epkind"];

                if (epkind != DBNull.Value) {
                    // Ratei (con task 11884 abbiamo escluso le fatt.a ric.)
                    if ((epkind.ToString() == "R") &&
                        ((R["competencystart"] == DBNull.Value) || (R["competencystop"] == DBNull.Value))) {
                        errmess = "Le date di inizio e fine competenza devono essere entrambe valorizzate";
                        errfield = "competencystart";
                        return false;
                    }
                }
            }

            object Omultireg = Conn.DO_READ_VALUE("mandatekind", "(idmankind=" +
                                                                 QueryCreator.quotedstrvalue(R["idmankind"], true) +
                                                                 ")", "multireg");
            if (Omultireg == null) Omultireg = "N";
            string multireg = Omultireg.ToString();

            DataRow ParentRow = R.GetParentRow("mandatemandatedetail");
            string flagtenderresult = "A";
            if (ParentRow != null)
                flagtenderresult = ParentRow["flagtenderresult"].ToString();

            if ((R["idreg"] == DBNull.Value) && (multireg == "S") &&
                (flagtenderresult == "A")) {
                errmess = "Il campo 'Fornitore' è obbligatorio";
                errfield = "idreg";
                return false;
            }

            if (!base.IsValid(R, out errmess, out errfield)) return false;
            return true;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "assetkind", "O");
            SetDefault(PrimaryTable, "toinvoice", "S");
            SetDefault(PrimaryTable, "flagto_unload", "N");
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "dettaglio") {
                return base.SelectOne(ListingType, filter, "mandatedetail_extview", ToMerge);
            }

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

    }
}
