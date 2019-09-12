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

ï»¿using System;
using System.Data;
using System.Collections.Generic;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;
//using System.Windows.Forms;

namespace meta_viterbo_finvar {
    public class Meta_viterbo_finvar :Meta_easydata {
        public Meta_viterbo_finvar(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "viterbo_finvar") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            EditTypes.Add("ct_asscred_reset");
        }
        
        //  Non SERVE PER PROGETTO WEB
        //protected override Form GetForm(string FormName) {
        //    if (FormName == "default") {
        //        DefaultListType = "default";
        //        Name = "Variazione/Storno";
        //        return GetFormByDllName("finvar_default");
        //    }
        //    if (FormName == "ct_asscred_reset") {
        //        CanInsert = false;
        //        SearchEnabled = false;
        //        MainRefreshEnabled = false;
        //        Name = "Azzeramento Previsione Iniziale";
        //        return MetaData.GetFormByDllName("ct_finyear_asscred_reset");
        //    }

        //    return null;
        //}

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            if (PrimaryTable.Columns["flagprevision"].DefaultValue.ToString() == "")
                SetDefault(PrimaryTable, "flagprevision", "N");

            if (PrimaryTable.Columns["flagcredit"].DefaultValue.ToString() == "")
                SetDefault(PrimaryTable, "flagcredit", "N");

            if (PrimaryTable.Columns["flagproceeds"].DefaultValue.ToString() == "")
                SetDefault(PrimaryTable, "flagproceeds", "N");

            if (PrimaryTable.Columns["flagsecondaryprev"].DefaultValue.ToString() == "")
                SetDefault(PrimaryTable, "flagsecondaryprev", "N");

            if (PrimaryTable.Columns["variationkind"].DefaultValue.ToString() == "" ||
                PrimaryTable.Columns["variationkind"].DefaultValue.ToString() == "0"
                )
                SetDefault(PrimaryTable, "variationkind", 1);

            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "varflag", 0);
            SetDefault(PrimaryTable, "yvar", GetSys("esercizio"));
            string filter = QHS.CmpEq("ayear", GetSys("esercizio"));
            object finvarofficial_default = Conn.DO_READ_VALUE("config", filter, "finvarofficial_default");
            if (finvarofficial_default == null) finvarofficial_default = DBNull.Value;
            SetDefault(PrimaryTable, "official", finvarofficial_default);


        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "yvar");
            RowChange.MarkAsAutoincrement(T.Columns["nvar"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int finkind = CfgFn.GetNoNullInt32(GetSys("fin_kind"));
            string flagcredit = GetSys("flagcredit").ToString().ToUpper();
            string flagproceeds = GetSys("flagproceeds").ToString().ToUpper();
            // sola competenza/sola cassa senza assegnazione/dotazione crediti o cassa
            if (((finkind == 1) || (finkind == 2)) && (flagcredit == "N") && (flagproceeds == "N")) {
                R["flagprevision"] = "S";
                R["flagsecondaryprev"] = "N";
                R["flagcredit"] = "N";
                R["flagproceeds"] = "N";
            }
            return R;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default" || ListingType == "documentocollegato") return base.SelectOne(ListingType, filter, "viterbo_finvarview", Exclude);
            return base.SelectOne(ListingType, filter, "viterbo_finvar", Exclude);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            string flagvalue = "S";
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            //if (R.RowState != DataRowState.Added) return true;

            if (CfgFn.GetNoNullInt32(R["variationkind"]) == 0) {
                errmess = "Attenzione! Selezionare un Tipo Variazione";
                errfield = "";
                return false;
            }

            if (R["flagprevision"].ToString() != flagvalue && R["flagsecondaryprev"].ToString() != flagvalue &&
                R["flagcredit"].ToString() != flagvalue && R["flagproceeds"].ToString() != flagvalue) {
                errmess = "Attenzione! Selezionare un Tipo Previsione/Dotazione";
                errfield = "";
                return false;
            }

            if (R.RowState == DataRowState.Modified && R["official"].ToString() == "S" && R["nofficial"] == DBNull.Value) {
                errmess = "Attenzione! Inserire un numero ufficiale per la variazione";
                errfield = "nofficial";
                return false;
            }

            if (R.RowState == DataRowState.Added && R["official"].ToString() == "N" && R["flagprevision"].ToString() == flagvalue) {
                // Verifico che non si tratta di storni tra articoli di uno stesso capitolo o nell'ambito di uno stesso
                // capitolo tra diversi UPB
                Dictionary<int, decimal> h = new Dictionary<int, decimal>();
                DataTable Details = R.Table.DataSet.Tables["viterbo_finvardetail"];
                object finusablelevel = GetSys("finusablelevel");
                foreach (DataRow RD in Details.Select()) {
                    string filter = QHS.AppAnd(QHS.CmpEq("idchild", RD["idfin"]), QHS.CmpEq("nlevel", finusablelevel));
                    int idfinParent = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("finlink", filter, "idparent"));
                    if (h.ContainsKey(idfinParent)) {
                        h[idfinParent] += CfgFn.GetNoNullDecimal(RD["amount"]);
                    }
                    else {
                        h[idfinParent] = CfgFn.GetNoNullDecimal(RD["amount"]);
                    }
                }
                foreach (KeyValuePair<int, decimal> coppia in h) {
                    if (coppia.Value != 0) {
                        string message = "Si sta inserendo una variazione NON ufficiale " +
                                         "con saldo su qualche capitolo diverso da 0. Continuare lo stesso? ";
                        Console.WriteLine(message);

                        // Lasciato per promemoria, verificare sulla gestione nella app web
                        //if (this.ShowClientMsg(message, "Attenzione!", MessageBoxButtons.OKCancel)) {
                        //    continue;
                        //}
                        //else return false;
                    }
                }
                return true;
            }
            return true;
        }

    }
}