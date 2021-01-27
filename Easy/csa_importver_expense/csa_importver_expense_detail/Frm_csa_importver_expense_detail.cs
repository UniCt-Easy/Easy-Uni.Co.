
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using AskInfo;

namespace csa_importver_expense_detail {
    public partial class Frm_csa_importver_expense_detail :Form {
        MetaData Meta;
        DataAccess Conn;
        public Frm_csa_importver_expense_detail() {
            InitializeComponent();
            }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                   QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))), "nphase", true);
            HelpForm.SetDenyNull(DS.csa_importver_expense.Columns["idexp"], true);

            }

        public void MetaData_AfterFill() {
                VisualizzaMovimentoSpesa();
            }
        private void VisualizzaMovimentoSpesa() {
            if (MetaData.Empty(this)) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object idexp = DS.Tables["csa_importver_expense"].Rows[0]["idexp"];
            string filter = QHS.CmpEq("idexp", idexp);
            DataTable DT = Conn.RUN_SELECT("expense", "idexp,ymov,nmov,nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEserc.Text = DT.Rows[0]["ymov"].ToString();
            txtNum.Text = DT.Rows[0]["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = DT.Rows[0]["nphase"];
            }

        object Get_Registry_Auto() {
            if (Meta.IsEmpty) return DBNull.Value;
            object esercizio = Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
            if (t == null) return DBNull.Value;
            if (t.Rows.Count == 0) return DBNull.Value;
            DataRow rConfig = t.Rows[0];
            return rConfig["idregauto"];
            }
        private void btnSpesa_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            DataRow Curr = DS.csa_importver_expense.Rows[0];
            string filter = "";
            object idregauto = Get_Registry_Auto();

            int selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            if (selectedfase > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", selectedfase));//,
                                                                               //QHS.DoPar(QHS.NullOrEq("idreg", idregauto)));
                }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                         QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))); //,
                                                                               //QHS.DoPar(QHS.NullOrEq("idreg", idregauto)));
                }

            var ymov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
            var nmov = CfgFn.GetNoNullInt32(txtNum.Text.Trim());
            if (ymov != 0 && nmov != 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov));
                }
            else {
                var f = new FrmAskInfo(Meta, "S", true).EnableManagerSelection(false);
                if (f.ShowDialog() != DialogResult.OK) return;

                if (ymov != 0) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
                }

                if (nmov != 0) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
                }

                var filterUpb = QHC.CmpEq("idupb", "0001");
                var filterFin = "";
                // Aggiunta filtro dell'UPB e del Bilancio
                if (f.GetUPB() != DBNull.Value) {
                    filterUpb = QHS.CmpEq("idupb", f.GetUPB());
                    if (f.GetFin() != DBNull.Value) {
                        filterFin = QHS.CmpEq("idfin", f.GetFin());
                    }
                }

                filter = QHS.AppAnd(filter, filterUpb);
                if (filterFin != "") {
                    filter = QHS.AppAnd(filter, filterFin);
                }
            }

            var E = Meta.Dispatcher.Get("expense");
            E.FilterLocked = true;
            E.DS = DS.Clone();
            DataRow Choosen = E.SelectOne("default", filter, "expense", null);
            if (Choosen == null) return;
            int oldIdExp = CfgFn.GetNoNullInt32(Curr["idexp"]);
            int newIdExp = CfgFn.GetNoNullInt32(Choosen["idexp"]);
            Curr["idexp"] = Choosen["idexp"];

            DS.expenseview.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview, null,
                QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
                null, true);
            txtEserc.Text = Choosen["ymov"].ToString();
            txtNum.Text = Choosen["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = Choosen["nphase"];
            Meta.FreshForm(false);
            }

        private void txtEserc_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEserc);
            if (Meta.IsEmpty) return;
            DataRow curr = DS.csa_importver_expense.Rows[0];
            if (curr["idexp"] != DBNull.Value) {
                if (txtEserc.Text.Trim() == "") {
                    txtNum.Text = "";
                    DS.expenseview.Clear();
                    curr["idexp"] = DBNull.Value;
                }
                else {
                    if (DS.expenseview._hasRows()) {
                        var oldYmov = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["ymov"]);
                        var newYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
                        if (oldYmov != newYmov) {
                            txtNum.Text = "";
                            DS.expenseview.Clear();
                            curr["idexp"] = DBNull.Value;
                        }
                    }
                }
            }
        }

        private void txtNum_Leave(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (txtNum.ReadOnly) return;
            DataRow Curr = DS.csa_importver_expense.Rows[0];
            if (Curr["idexp"] != DBNull.Value && (txtNum.Text.Trim() == "")) {
                DS.expenseview.Clear();
                Curr["idexp"] = DBNull.Value;
                }
            btnSpesa_Click(sender, e);
            }

        private void cmbFaseSpesa_SelectedIndexChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            DataRow Curr = DS.csa_importver_expense.Rows[0];
            if (Curr["idexp"] != DBNull.Value) {
                int oldNphase = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["nphase"]);
                int newNPhase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
                if (oldNphase != newNPhase) {
                    txtNum.Text = "";
                    txtEserc.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp"] = DBNull.Value;
                    }
                }
            }
        }
    }
