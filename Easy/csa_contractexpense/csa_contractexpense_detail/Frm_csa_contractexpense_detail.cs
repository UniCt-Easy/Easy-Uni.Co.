
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
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using q=metadatalibrary.MetaExpression;
using AskInfo;

namespace csa_contractexpense_detail {
    public partial class Frm_csa_contractexpense_detail : Form {
        IDataAccess _conn;
        private ISecurity _security;
        private IFormController _controller;
        private IMetaDataDispatcher _dispatcher;
        private IMetaData _meta;

        public Frm_csa_contractexpense_detail() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            _conn = this.getInstance<IDataAccess>();
            _security = this.getInstance<ISecurity>();
            _controller = this.getInstance<IFormController>();
            _dispatcher = this.getInstance<IMetaDataDispatcher>();
            _meta = this.getInstance<IMetaData>();

            QHC = new CQueryHelper();
            QHS = _conn.GetQueryHelper();

            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", _security.GetSys("maxexpensephase")),
                QHS.CmpGe("nphase", _security.GetSys("expensefinphase"))), "nphase", true);
            HelpForm.SetDenyNull(DS.csa_contractexpense.Columns["idexp"], true);

        }

        public void MetaData_AfterFill() {
            visualizzaMovimentoSpesa();
        }


        private void visualizzaMovimentoSpesa() {
            if (_controller.IsEmpty) return;
            if (DS.Tables["csa_contractexpense"] == null) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            var idexp = DS.Tables["csa_contractexpense"].Rows[0]["idexp"];
            var o = _conn.readObject("expense", q.eq("idexp", idexp), "ymov,nmov,nphase");
            if (o == null) return;
            txtEserc.Text = o["ymov"].ToString();
            txtNum.Text = o["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = o["nphase"];
        }

        object Get_Registry_Csa() {
            if (_controller.IsEmpty) return DBNull.Value;
            return _conn.readValue("config", q.eq("ayear", _security.GetEsercizio()), "idreg_csa") ?? DBNull.Value;
        }

        private void btnSpesa_Click(object sender, EventArgs e) {
            if (_controller.IsEmpty) return;
            _controller.GetFormData(true);

            var curr = DS.csa_contractexpense.Rows[0];
            var filter = "";
            var selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            var idregcsa = Get_Registry_Csa();
            if (selectedfase > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", selectedfase),
                    QHS.DoPar(QHS.NullOrEq("idreg", idregcsa)));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpNe("nphase", _security.GetSys("maxexpensephase")),
                    QHS.CmpGe("nphase", _security.GetSys("expensefinphase")),
                    QHS.DoPar(QHS.NullOrEq("idreg", idregcsa)));
            }

            var ymov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
            var nmov = CfgFn.GetNoNullInt32(txtNum.Text.Trim());
            if ((ymov != 0) && (nmov != 0)) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov));
            }
            else {
                var ff = new FrmAskInfo(_meta as MetaData, "S", true).EnableManagerSelection(false);
                if (ff.ShowDialog() != DialogResult.OK) return;
                //var f = new FrmAskFase("S", _dispatcher as EntityDispatcher, _conn as DataAccess);
                //if (f.ShowDialog() != DialogResult.OK) return;

                if (ymov != 0) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
                }

                if ((nmov != 0)) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
                }

                var filterUpb = QHC.CmpEq("idupb", "0001");
                var filterFin = "";
                // Aggiunta filtro dell'UPB e del Bilancio
                if (ff.GetUPB() != DBNull.Value) {
                    filterUpb = QHS.CmpEq("idupb", ff.GetUPB());
                    if (ff.GetFin() != DBNull.Value) {
                        filterFin = QHS.CmpEq("idfin", ff.GetFin());
                    }
                }                

                filter = QHS.AppAnd(filter, filterUpb);
                if (filterFin != "") {
                    filter = QHS.AppAnd(filter, filterFin);
                }
            }

            var expense = _dispatcher.Get("expense");
            expense.FilterLocked = true;
            expense.DS = DS.Clone();
            var choosen = expense.SelectOne("default", filter, "expense", null);
            if (choosen == null) return;

            curr["idexp"] = choosen["idexp"];

            DS.expenseview.Clear();
            _conn.RUN_SELECT_INTO_TABLE(DS.expenseview, null,
                QHS.AppAnd(QHS.CmpEq("idexp", curr["idexp"]), QHS.CmpEq("ayear", _security.GetEsercizio())),
                null, true);
            txtEserc.Text = choosen["ymov"].ToString();
            txtNum.Text = choosen["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = choosen["nphase"];

            _controller.FreshForm(false, false);
        }

        private void cmbFaseSpesa_SelectedIndexChanged(object sender, EventArgs e) {
            if (_controller.IsEmpty) return;
            if (!_controller.DrawStateIsDone) return;
            if (DS.csa_contractexpense.Rows.Count == 0) return;
            var curr = DS.csa_contractexpense.Rows[0];
            if (curr["idexp"] == DBNull.Value) return;
            int oldNphase = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["nphase"]);
            int newNPhase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            if (oldNphase == newNPhase) return;
            txtNum.Text = "";
            txtEserc.Text = "";
            DS.expenseview.Clear();
            curr["idexp"] = DBNull.Value;
        }

        private void txtEserc_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEserc);
            if (_controller.IsEmpty) return;
            var curr = DS.csa_contractexpense.Rows[0];
            if (curr["idexp"] == DBNull.Value) return;
            if (txtEserc.Text.Trim() == "") {
                txtNum.Text = "";
                DS.expenseview.Clear();
                curr["idexp"] = DBNull.Value;
            }
            else {
                var oldYmov = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["ymov"]);
                var newYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
                if (oldYmov == newYmov) return;
                txtNum.Text = "";
                DS.expenseview.Clear();
                curr["idexp"] = DBNull.Value;
            }
        }

        private void txtNum_Leave(object sender, EventArgs e) {
            if (_controller.IsEmpty) return;
            if (txtNum.ReadOnly) return;
            var curr = DS.csa_contractexpense.Rows[0];
            if ((curr["idexp"] != DBNull.Value) && (txtNum.Text.Trim() == "")) {
                DS.expenseview.Clear();
                curr["idexp"] = DBNull.Value;
            }

            btnSpesa_Click(sender, e);
        }
    }
}
