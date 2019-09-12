/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Windows.Forms;

namespace meta_upbcommessaview {
    public class Meta_upbcommessaview : Meta_easydata {
        public Meta_upbcommessaview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "upbcommessaview") {
            //EditTypes.Add("default");
            //ListingTypes.Add("default");
        }

        /// <summary>
        /// Impostare la chiave, serve per le viste, non per le tabelle!!
        /// </summary>
//private string[] mykey = new string[] { "campo chiave" /*,...campi chiave*/ };
//public override string[] primaryKey() {
//    return mykey;
//}

        protected override Form GetForm(string FormName) {
            //if (FormName == "default") {
            //    DefaultListType = "default";
            //    Name = "Descrizione Form";
            //    return MetaData.GetFormByDllName("upbcommessaview_default");
            //}
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            //SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
        }

        public override string GetStaticFilter(string ListingType) {
            return QHS.CmpEq("ayear", Conn.GetEsercizio());
            //return base.GetStaticFilter(ListingType);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            //RowChange.SetMySelector(T.Columns["nupbcommessaview"], "nphase", 0);  //campo nphase  è selettore per calcolo di nupbcommessaview
            //RowChange.SetMySelector(T.Columns["nupbcommessaview"], "yupbcommessaview", 0);//campo yupbcommessaview  è selettore per calcolo di nupbcommessaview
            //RowChange.MarkAsAutoincrement(T.Columns["nupbcommessaview"], null, null, 0);  //nupbcommessaview è campo ad autoincremento
            //RowChange.MarkAsAutoincrement(T.Columns["idupbcommessaview"], null, null, 0);  //idupbcommessaview è campo ad autoincremento

            //RowChange.setMinimumTempValue(T.Columns["idupbcommessaview"], 999900000);     //Da impostare  in caso di pericolo di conflitto
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        /// <summary>
        /// FilterRow, si usa per i grid filtrati
        /// </summary>
        /// <param name="R"></param>
        /// <param name="list_type"></param>
        /// <returns></returns>
        public override bool FilterRow(DataRow R, string list_type) {
            //if (list_type == "form_contenitore") {
            //    if (R["chiave contenitore"] == DBNull.Value) return false;
            //    return true;
            //}

            return true;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            //if (condizione di errore) {
            //    errmess = "Messaggio di errore";
            //    errfield = "Nome campo su cui posizionare il focus";
            //    return false;
            //}


            return true;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            //if (ListingType == "lista")
            //    return base.SelectOne(ListingType, filter, "upbcommessaviewview", Exclude);
            //else
            return base.SelectOne(ListingType, filter, "upbcommessaview", Exclude);
        }


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            switch (ListingType) {
                case "default": {
                    foreach (DataColumn C in T.Columns) {
                        DescribeAColumn(T, C.ColumnName, "", -1);
                    }

                    int nPos = 1;
                    //DescribeAColumn(T, "ayear", "esercizio", nPos++);
                    DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                    DescribeAColumn(T, "title", "Denominazione UPB", nPos++);
                    DescribeAColumn(T, "yearstart", "Anno inizio", nPos++);
                    DescribeAColumn(T, "yearstop", "Anno fine", nPos++);
                    DescribeAColumn(T, "epupbkind", "Tipo UPB", nPos++);
                    DescribeAColumn(T, "codemotive_cost", "Codice causale Costo", nPos++);
                    DescribeAColumn(T, "codeacc_cost", "Codice conto costo", nPos++);
                    DescribeAColumn(T, "codemotive_revenue", "Codice causale Ricavo", nPos++);
                    DescribeAColumn(T, "codeacc_revenue", "Codice conto Ricavo", nPos++);
                    DescribeAColumn(T, "codemotive_accruals", "Codice causale Rateo attivo", nPos++);
                    DescribeAColumn(T, "codeacc_accruals", "Codice conto Rateo attivo", nPos++);
                    DescribeAColumn(T, "codemotive_deferredcost", "Codice causale Risconto passivo", nPos++);
                    DescribeAColumn(T, "codeacc_deferredcost", "Codice conto Risconto passivo", nPos++);
                    DescribeAColumn(T, "cost", "Totale costi", nPos++);
                    DescribeAColumn(T, "reserve", "Totale riserve", nPos++);
                    DescribeAColumn(T, "revenue", "Totale ricavi", nPos++);
                    DescribeAColumn(T, "accruals", "Totale ratei attivi", nPos++);

                    DescribeAColumn(T, "costi", "Costi in scritture", nPos++);
                    DescribeAColumn(T, "risconti", "Risconti in scritture", nPos++);
                    DescribeAColumn(T, "rateiattivi", "Ratei attivi in scritture", nPos++);
                  
                    break;

                }
            }
        }
    }
}
