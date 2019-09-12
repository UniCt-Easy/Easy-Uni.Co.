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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace underwritingappropriation_detail {
    public partial class Frm_underwritingappropriation_detail : Form {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        public Frm_underwritingappropriation_detail() {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            if (Meta.InsertMode) {
                btnFinanziamento.Enabled = true;
                txtUnderwriting.ReadOnly = false;
            }
            else {
                btnFinanziamento.Enabled = false;
                txtUnderwriting.ReadOnly = true;
            }
        }
        private void btnFinanziamento_Click(object sender, EventArgs e) {
            if (!Meta.InsertMode) return;
            string filter = "";
            object idfin=null;
            object idupb=null;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            filter = QHS.CmpEq("ayear", esercizio);

            DataRow rUnderwritingappropriation = Meta.SourceRow;
            DataRow rExpense = rUnderwritingappropriation.GetParentRow("expense_underwritingappropriation");
            if (rExpense != null) {
                DataRow rExpenseYear = null;
                DataRow[] ExpenseYear = rExpense.GetChildRows("expenseexpenseyear");
                if ((ExpenseYear != null) && (ExpenseYear.Length > 0)) {
                    rExpenseYear = ExpenseYear[0];
                }
                if (rExpenseYear != null) {
                    idfin = rExpenseYear["idfin"];
                    idupb = rExpenseYear["idupb"];
                }
            }
            if ((idfin != DBNull.Value) && (idfin != null)) {
                filter = GetData.MergeFilters(filter, QHS.CmpEq("idfin", idfin));
            }
            if ((idupb != DBNull.Value) && (idupb != null)) {
                filter = GetData.MergeFilters(filter, QHS.CmpEq("idupb", idupb));
            }
            
            filter = GetData.MergeFilters(filter,QHS.CmpGt("expenseprevavailable" ,0));

            MetaData MetaUpbunderwritingyearview = MetaData.GetMetaData(this, "upbunderwritingyearview");
            MetaUpbunderwritingyearview.DS = new DataSet();
            MetaUpbunderwritingyearview.LinkedForm = this;
            MetaUpbunderwritingyearview.FilterLocked = true;
            DataRow Upbunderwritingyearview = MetaUpbunderwritingyearview.SelectOne("impegni", filter, "upbunderwritingyearview", null);
            if (Upbunderwritingyearview == null) return;
            txtUnderwriting.Text = Upbunderwritingyearview["underwriting"].ToString();
            DataRow curr = DS.underwritingappropriation.Rows[0];
            curr["idunderwriting"] = Upbunderwritingyearview["idunderwriting"];

        }

        private void txtUnderwriting_Leave(object sender, EventArgs e) {
            if (!Meta.InsertMode) return;
            if (txtUnderwriting.Text == "") return;
            if (DS.underwritingappropriation.Rows.Count == 0) return;
            string Fin = txtUnderwriting.Text;
            if (!Fin.EndsWith("%")){
                Fin += "%";
            }
            string filter = QHS.Like("underwriting", Fin);
            //Filtri sulla coppia upb/bilancio
            object idfin = null;
            object idupb = null;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            filter = QHS.CmpEq("ayear", esercizio);

            DataRow rUnderwritingappropriation = Meta.SourceRow;
            DataRow rExpense = rUnderwritingappropriation.GetParentRow("expense_underwritingappropriation");
            if (rExpense == null) {
                rExpense = rUnderwritingappropriation.GetParentRow("expenseview_underwritingappropriation");
            }
            DataRow rExpenseYear = null;
            DataRow[] ExpenseYear = rExpense.GetChildRows("expenseexpenseyear");
            if (ExpenseYear.Length > 0) {
                rExpenseYear = ExpenseYear[0];
            }
            if (rExpenseYear != null) {
                idfin = rExpenseYear["idfin"];
                idupb = rExpenseYear["idupb"];
            }
            if ((idfin != DBNull.Value) && (idfin != null)) {
                filter = GetData.MergeFilters(filter, QHS.CmpEq("idfin", idfin));
            }
            if ((idupb != DBNull.Value) && (idupb != null)) {
                filter = GetData.MergeFilters(filter, QHS.CmpEq("idupb", idupb));
            }

            filter = GetData.MergeFilters(filter, QHS.CmpGt("expenseprevavailable", 0));

            DataTable tupbunderwritingyearview = DataAccess.CreateTableByName(Meta.Conn, "upbunderwritingyearview", "*");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tupbunderwritingyearview, null, filter, null, true);
            if (tupbunderwritingyearview.Rows.Count == 0) {
                MessageBox.Show(this, "Nessun finanziamento trovato");
                return;
            }
            MetaData MetaUpbunderwritingyearview = MetaData.GetMetaData(this, "upbunderwritingyearview");

            MetaUpbunderwritingyearview.FilterLocked = true;
            MetaUpbunderwritingyearview.DS = DS.Clone();
            DataRow Upbunderwritingyearview = MetaUpbunderwritingyearview.SelectOne("impegni", filter, null, null);
            if (Upbunderwritingyearview == null) return;
            DataRow Curr = DS.underwritingappropriation.Rows[0];
            Curr["idunderwriting"] = Upbunderwritingyearview["idunderwriting"];
            txtUnderwriting.Text = Upbunderwritingyearview["underwriting"].ToString();

        }
    }
}