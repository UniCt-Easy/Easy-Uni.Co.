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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
//Pino: using dettdocumentoivasingle; diventato inutile
using funzioni_configurazione;//funzioni_configurazione

namespace meta_invoicedetail{//meta_dettdocumentoiva//
	/// <summary>
	/// Revised by Nino on 30/1/2003
	/// </summary>
	public class Meta_invoicedetail : Meta_easydata {
		public Meta_invoicedetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoicedetail") {
			ListingTypes.Add("documento");
			ListingTypes.Add("dettordine");
			ListingTypes.Add("wizardiva");
            ListingTypes.Add("default");
            ListingTypes.Add("dettaglio");
            ListingTypes.Add("flussocrediti");
            EditTypes.Add("single");
            EditTypes.Add("default");
			Name="Dettaglio documento IVA";
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			RowChange.SetSelector(T, "idinvkind");
			RowChange.SetSelector(T, "yinv");
			RowChange.SetSelector(T, "ninv");
			RowChange.MarkAsAutoincrement(T.Columns["rownum"], null, null, 6);
		    RowChange.setMinimumTempValue(T.Columns["rownum"], 10000);
			RowChange.MarkAsAutoincrement(T.Columns["idgroup"], null, null, 6);//sa
			DataRow R = base.Get_New_Row(ParentRow, T);
			RowChange.ClearAutoIncrement(T.Columns["idgroup"]);//sa
			return R;
		}

		protected override Form GetForm(string FormName){
            if (FormName == "single") {
                return MetaData.GetFormByDllName("invoicedetail_single");
            }
            if (FormName == "default") {
                Name = "Dettaglio Doc. IVA";
                DefaultListType = "dettaglio";
                return GetFormByDllName("invoicedetail_default");
            }
			return null;
		}			

		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="documento") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				int nPos = 1;
                DescribeAColumn(T, "idgroup", "Gruppo", nPos++);
                DescribeAColumn(T, "rownum", "Numero Riga", nPos++);
                DescribeAColumn(T, "!tipoiva","Tipo IVA","ivakind.description",nPos++);
				DescribeAColumn(T, "detaildescription","Descrizione",nPos++);
				DescribeAColumn(T, "!aliquota", "Aliquota","ivakind.rate",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["!aliquota"], "p");
				DescribeAColumn(T, "!percindetraibilita", "% Indetr.", "ivakind.unabatabilitypercentage",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["!percindetraibilita"], "p");
				DescribeAColumn(T, "taxable","Importo Unitario",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
                DescribeAColumn(T, "!imponibile", "Imponibile tot.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!imponibile"], "n");
				DescribeAColumn(T, "number","Quantità",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["number"], "n");
				DescribeAColumn(T, "tax","Imposta",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["tax"], "n");
				DescribeAColumn(T,"unabatable", "Indetraibile",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["unabatable"], "n");
				DescribeAColumn(T, "discount","Sconto",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
				DescribeAColumn(T,"!totaleriga","Imp. (IVA incl.)",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["!totaleriga"], "n");
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
			    if (T.Columns.Contains("!codesorsiope")) {
			        DescribeAColumn(T, "!codesorsiope", "Codice siope", "sorting_siope.sortcode", nPos++);
			    }

			    ComputeRowsAs(T, listtype);
			}
			if (listtype=="dettordine") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				int nPos = 1;
				DescribeAColumn(T, "!tipodocumento","Tipo documento","invoicekind.description",nPos++);
				DescribeAColumn(T,"yinv","Esercizio",nPos++);
				DescribeAColumn(T,"ninv","Numero",nPos++);
				DescribeAColumn(T,"rownum","Dettaglio",nPos++);
				DescribeAColumn(T, "number","Quantità",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
				ComputeRowsAs(T, listtype);
			}
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                
                DescribeAColumn(T, "idinvkind", "Cod. Fatt.", nPos++);
                DescribeAColumn(T, "yinv", "Eserc. Fatt.", nPos++);
                DescribeAColumn(T, "ninv", "Num. Fatt.", nPos++);
                DescribeAColumn(T, "rownum", "Num. Dettaglio", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile Unitario", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
                DescribeAColumn(T, "number", "Quantità", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "tax", "Imposta", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["tax"], "n");
                DescribeAColumn(T, "unabatable", "Indetraibile", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["unabatable"], "n");
                DescribeAColumn(T, "discount", "Sconto", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
                DescribeAColumn(T, "!totaleriga", "Imp. (IVA incl.)", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["!totaleriga"], "n");
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                ComputeRowsAs(T, listtype);
            }
			if (listtype=="wizardiva") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				int nPos = 1;
				DescribeAColumn(T,"rownum",".riga",nPos++);
				DescribeAColumn(T, "!codeupb","UPB",nPos++);
                DescribeAColumn(T, "!codeupb_iva", "UPB iva", nPos++);
                DescribeAColumn(T, "!tipoiva", "Tipo IVA", "ivakind.description", nPos++);
				DescribeAColumn(T, "detaildescription","Descrizione",nPos++);
				DescribeAColumn(T, "!aliquota", "Aliquota","ivakind.rate",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["!aliquota"], "p");
				DescribeAColumn(T, "taxable","Importo Unitario",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
                DescribeAColumn(T, "npackage", "Q.tà", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["npackage"], "n");
                DescribeAColumn(T, "number", "Totale Q.tà Ordinata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
				DescribeAColumn(T, "tax","Imposta",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["tax"], "n");
				DescribeAColumn(T,"unabatable", "Indetraibile",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["unabatable"], "n");
				DescribeAColumn(T, "discount","Sconto",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
				DescribeAColumn(T,"!totaleriga","Imp. (IVA incl.)",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["!totaleriga"], "n");
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
				ComputeRowsAs(T, listtype);
			}
		}
		
		public override void CalculateFields(DataRow R, string list_type) {
			if (list_type=="documento"||list_type=="wizardiva" || list_type == "default") {
				double imponibile= CfgFn.GetNoNullDouble(R["taxable"]);
                double quantitaConfezioni = CfgFn.GetNoNullDouble(R["npackage"]);
				double sconto    = CfgFn.GetNoNullDouble(R["discount"]);
				double imponibilereale = CfgFn.RoundValuta((imponibile*quantitaConfezioni*(1-sconto)));
				double imposta=CfgFn.GetNoNullDouble(R["tax"]);
                if (R.Table.Columns.Contains("!imponibile"))
                        R["!imponibile"] = imponibilereale;                    
               if (R.Table.Columns.Contains("!totaleriga"))
				           R["!totaleriga"]=imponibilereale+imposta;
			}
		}
		
		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			DataTable T = C.Table;
			if ((C.ColumnName == "idexp_iva") || (C.ColumnName == "idexp_taxable")
				|| (C.ColumnName == "idinc_iva") || (C.ColumnName == "idinc_taxable")
				|| (C.ColumnName == "idmankind") || (C.ColumnName == "manrownum")
				|| (C.ColumnName == "nman") || (C.ColumnName == "yman")
                || (C.ColumnName == "idepexp") || (C.ColumnName == "idepacc")
                || (C.ColumnName == "ycon") || (C.ColumnName == "ncon")
                || (C.ColumnName == "estimrownum") || (C.ColumnName == "idestimkind")
			    || (C.ColumnName == "codicetipo") || (C.ColumnName == "codicevalore")
                || (C.ColumnName == "nestim") || (C.ColumnName == "yestim")) {
				return;
			}
			base.InsertCopyColumn (C, Source, Dest);
		}

        private bool RegistryHasToDeclareIntrastat(object idreg) {
            if (idreg == DBNull.Value) return true;

            DataTable TRegistry = Conn.RUN_SELECT("registry", "idreg,p_iva,residence,idregistryclass", null, QHS.CmpEq("idreg", idreg), null, false);
            if (TRegistry.Rows.Count == 0) return false;
            DataRow Reg = TRegistry.Rows[0];
            object p_iva = Reg["p_iva"];
            object idresidence = Reg["residence"];

            object Ocoderesidence = Conn.DO_READ_VALUE("residence", QHS.CmpEq("idresidence", idresidence),
                                             "coderesidence");
            if (Ocoderesidence == null || Ocoderesidence == DBNull.Value) return false;
            string coderesidence = Ocoderesidence.ToString().ToUpper();
            // Qualora l'anagrafica sia configurata come:
            //- ente non commerciale;
            //- soggetto residente in altri paesi dell'UE;
            //- non abbia valorizzato la partita IVA;

            //non deve essere richiesta la compilazione dell'INTRASTAT sia:
            //nella fattura
            //nel dettaglio della fattura
            if ((coderesidence == "J") && (p_iva == DBNull.Value) && (CfgFn.GetNoNullInt32(Reg["idregistryclass"]) == 23)) {
                return false;
            }

            return true;

        }

        object getIdReg(DataRow r) {
            
            if (r.RowState == DataRowState.Added) {
                if (SourceRow == null) return DBNull.Value;
                DataSet dMain = SourceRow.Table.DataSet;
                if (!dMain.Tables.Contains("invoice")) return DBNull.Value;
                string filter = QHC.MCmp(r, new string[] { "idinvkind", "yinv", "ninv" });
                if (dMain.Tables["invoice"].Select(filter).Length == 0) return DBNull.Value;
                return dMain.Tables["invoice"].Select(filter)[0]["idreg"];
            }
            if (SourceRow != null) {
                DataSet dMain = SourceRow.Table.DataSet;
                if (dMain.Tables.Contains("invoice")) {
                    string filter = QHC.MCmp(r,new string[]{"idinvkind","yinv","ninv"});
                    if (dMain.Tables["invoice"].Select(filter).Length > 0) {
                        return dMain.Tables["invoice"].Select(filter)[0]["idreg"];
                    }
                }
            }
            return Conn.DO_READ_VALUE("invoice",  QHC.MCmp(r,new string[]{"idinvkind","yinv","ninv"}), "idreg");
        }

		public override bool IsValid(DataRow R, out string errmess, out string errfield){
			if (!base.IsValid(R,out errmess,out errfield))return false;
            if (CfgFn.GetNoNullInt32(R["idivakind"]) == 0) {
                errmess = "E' necessario specificare il tipo di iva";
                errfield = "idivakind";
                return false;
            }
            if (R["taxable"] == DBNull.Value) {
				errmess= "E' necessario specificare l'imponibile";
				errfield="taxable";
				return false;
			}
			if (R["detaildescription"].ToString().Trim()== "") {
				errmess= "E' necessario specificare la descrizione";
				errfield="detaildescription";
				return false;
			}
		    if (R.Table.Columns.Contains("flagbit")) {
		        object flagObj = R["flagbit"];
		        int flagInvoice = CfgFn.GetNoNullInt32(flagObj);
		        bool isValoreDoganale = (flagInvoice & 1) != 0; // Bit 0
		        bool isAnticipoSpese = (flagInvoice & 2) != 0; // Bit 1

                if (isValoreDoganale && isAnticipoSpese) {
                    errmess = "Le righe valore doganale non possono essere anche anticipo spese";
                    errfield = "flagbit";
                    return false;
                }

            }
            if ((R["competencystart"] != DBNull.Value) && (R["competencystop"] != DBNull.Value)) {
                DateTime competencystart = (DateTime)R["competencystart"];
                DateTime competencystop = (DateTime)R["competencystop"];
                if (competencystop < competencystart) {
                    errmess = "La data di fine competenza deve essere successiva alla data inizio competenza";
                    errfield = "competencystart";
                    return false;
                }
            }

            if (RegistryHasToDeclareIntrastat(getIdReg(R))) {
                if (R["intrastatoperationkind"].ToString() == "B") {
                    if (R["idintrastatcode"] == DBNull.Value) {
                        errmess = "E' necessario scegliere un codice di nomenclatura";
                        errfield = "idintrastatcode";
                        return false;
                    }
                    if (CfgFn.GetNoNullInt32(R["idintrastatcode"]) != 0) {
                        object Ocode = Conn.DO_READ_VALUE("intrastatcode", QHS.CmpEq("idintrastatcode", R["idintrastatcode"]), "code");
                        if (Ocode == null) {
                            errmess = "Il codice " + R["idintrastatcode"] + " non è stato trovato nella tabella intrastatcode";
                            errfield = "idintrastatcode";
                            return false;
                        }
                        string code = Ocode.ToString();
                        if ((code.Length) < 8) {
                            errmess = "E' necessario scegliere un codice di nomenclatura di 8 caratteri";
                            //errfield = "detaildescription";
                            return false;
                        }
                    }
                    if ((CfgFn.GetNoNullInt32(R["idintrastatcode"]) != 0) &&
                        (CfgFn.GetNoNullInt32(R["idintrastatmeasure"]) != 0) &&
                        (CfgFn.GetNoNullDecimal(R["weight"]) == 0)) {
                        errmess = "E' necessario valorizzare la massa netta in Kg";
                        errfield = "idintrastatmeasure";
                        return false;
                    }
                }
                if (R["intrastatoperationkind"].ToString() == "S") {
                    if (R["idintrastatservice"] == DBNull.Value) {
                        errmess = "E' necessario scegliere un codice servizi";
                        errfield = "idintrastatservice";
                        return false;
                    }

                    if (CfgFn.GetNoNullInt32(R["idintrastatservice"]) != 0) {
                        object Ocodeser = Conn.DO_READ_VALUE("intrastatservice", QHS.CmpEq("idintrastatservice", R["idintrastatservice"]), "code");
                        if (Ocodeser == null) {
                            errmess = "Il codice " + R["idintrastatservice"] + " non è stato trovato nella tabella intrastatservice";
                            errfield = "idintrastatservice";
                            return false;
                        }
                        int maxLencode = 5;
                     
                        string codeSer = Ocodeser.ToString();
                        if ((codeSer.Length) < maxLencode) {
                            errmess = "E' necessario scegliere un codice Servizi di " + maxLencode.ToString() + " caratteri";
                            errfield = "idintrastatservice";
                            return false;
                        }
                    }

                    if (R["idintrastatsupplymethod"] == DBNull.Value) {
                        errmess = "E' necessario scegliere una modalità di erogazione";
                        errfield = "idintrastatsupplymethod";
                        return false;
                    }
                }

            }
            if (!CfgFn.IsValidString(R["cigcode"].ToString())) {
                errmess = "Il CIG contiene caratteri non validi.I caratteri ammessi sono solo numeri e lettere. ";
                errfield = "cigcode";
                return false;
            }
            return true;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
            SetDefault(PrimaryTable, "flag", "2");
            SetDefault(PrimaryTable, "exception12", "N");
            SetDefault(PrimaryTable, "move12", "N");
            SetDefault(PrimaryTable, "leasing", "N");
            SetDefault(PrimaryTable, "resetresidualmandate", "N");
            SetDefault(PrimaryTable, "flagbit", 0);
		    SetDefault(PrimaryTable, "rounding", "N");
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if ((ListingType == "dettaglio")||(ListingType=="flussocrediti")) {
                return base.SelectOne(ListingType, filter, "invoicedetailview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
	}
}
