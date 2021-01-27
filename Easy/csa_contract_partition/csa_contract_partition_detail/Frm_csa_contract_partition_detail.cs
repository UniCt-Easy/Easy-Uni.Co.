
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
using System.Data;
using q=metadatalibrary.MetaExpression;
using ep_functions;
using AskInfo;

namespace csa_contract_partition_detail {
    public partial class Frm_csa_contract_partition_detail : Form {
        IDataAccess _conn;
        private ISecurity _security;
        private IFormController _controller;
        private IMetaDataDispatcher _dispatcher;
        private IMetaData _meta;

        public Frm_csa_contract_partition_detail() {
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
                QHS.CmpGe("nphase", _security.GetSys("expensefinphase")), QHS.CmpLt("nphase", _security.GetSys("expenseregphase"))), "nphase", true);

            int esercizioCurr = (int)_meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", esercizioCurr);

            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account, filter);
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);
            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            //EnableFaseImpegnoBudget(2, "Impegno di Budget");
            string filterSiope = QHS.CmpEq("codesorkind", _security.GetSys("codesorkind_siopespese"));

            DataTable tSortingkind = _conn.RUN_SELECT("sortingkind", "*", null, filterSiope, null, null, true);
            if ((tSortingkind != null) && (tSortingkind.Rows.Count > 0)) {
                DataRow R = tSortingkind.Rows[0];
                object idsorkind = R["idsorkind"];
                object idsorkind_main = R["idsorkind"];
                SetGBoxClass(idsorkind);
            }
        }
        void SetGBoxClass(object sortingkind) {
            if (sortingkind != DBNull.Value) {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.sorting, filter);
                string title = _conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclassSiope.Text = title;
                gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.tree." + filter;
                btnCodiceSiope.Tag = "manage.sorting.tree." + filter;
            }
        }

        public void MetaData_AfterFill() {
            visualizzaMovimentoSpesa();
            visualizzaImpegnoBudget();
            var idexp = DS.Tables["csa_contract_partition"].Rows[0]["idexp"];
            var idepexp = DS.Tables["csa_contract_partition"].Rows[0]["idepexp"];
            gboxUPB.Enabled = (idexp == DBNull.Value && idepexp == DBNull.Value);
            gboxConto.Enabled = (idepexp == DBNull.Value);
            grpBilancioVersamento.Enabled = (idexp == DBNull.Value );

        }


        private void visualizzaMovimentoSpesa() {
            if (_controller.IsEmpty) return;
            if (DS.Tables["csa_contract_partition"] == null) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            var idexp = DS.Tables["csa_contract_partition"].Rows[0]["idexp"];
            var o = _conn.readObject("expense", q.eq("idexp", idexp), "ymov,nmov,nphase");
            if (o == null) return;
            txtEserc.Text = o["ymov"].ToString();
            txtNum.Text = o["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = o["nphase"];
        }


        private void visualizzaImpegnoBudget() {
            if (_controller.IsEmpty) return;
            if (_controller.ErroreIrrecuperabile)return;
            if (DS.Tables["csa_contract_partition"] == null) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            var idepexp = DS.Tables["csa_contract_partition"].Rows[0]["idepexp"];
            var o = _conn.readObject("epexp", q.eq("idepexp", idepexp), "yepexp,nepexp,nphase");
            if (o == null) return;
            txtEsercizioImpegno.Text = o["yepexp"].ToString();
            txtNumImpegno.Text = o["nepexp"].ToString();
            cmbFaseImpBudget.SelectedValue = o["nphase"];
        }

        object Get_Registry_Csa() {
            if (_controller.IsEmpty) return DBNull.Value;
            return _conn.readValue("config", q.eq("ayear", _security.GetEsercizio()), "idreg_csa") ?? DBNull.Value;
        }

        private void btnSpesa_Click(object sender, EventArgs e) {
            if (_controller.IsEmpty) return;
            if (_controller.ErroreIrrecuperabile)return;
            _controller.GetFormData(true);

            var curr = DS.csa_contract_partition.Rows[0];
            var filter = "";
            var selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            var idregcsa = Get_Registry_Csa();
            if (selectedfase > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", selectedfase));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpNe("nphase", _security.GetSys("maxexpensephase")),
                    QHS.CmpGe("nphase", _security.GetSys("expensefinphase")),
                    QHS.CmpLt("nphase", _security.GetSys("expenseregphase")));
            }

            var ymov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
            var nmov = CfgFn.GetNoNullInt32(txtNum.Text.Trim());
            if ((ymov != 0) && (nmov != 0)) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov));
            }
            else {
                object selectedUPB = curr["idupb"];
                object selectedFin = curr["idfin"];
                if (ymov != 0) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
                }

                if ((nmov != 0)) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
                }
                
                if (selectedUPB != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", selectedUPB));
                }

                if (selectedFin != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idfin", selectedFin));
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
            curr["idfin"] = choosen["idfin"];
            curr["idupb"] = choosen["idupb"];
            _conn.RUN_SELECT_INTO_TABLE(DS.fin, null,QHS.CmpEq("idfin", curr["idfin"]), null, true);
            _conn.RUN_SELECT_INTO_TABLE(DS.upb, null,  QHS.CmpEq("idupb", curr["idupb"]), null, true);
            _controller.FreshForm(false, false);
        }

        private void cmbFaseSpesa_SelectedIndexChanged(object sender, EventArgs e) {
            if (_controller.IsEmpty) return;
            if (!_controller.DrawStateIsDone) return;
            if (_controller.ErroreIrrecuperabile)return;
            if (DS.csa_contract_partition.Rows.Count == 0) return;
            var curr = DS.csa_contract_partition.Rows[0];
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
            if (_controller.ErroreIrrecuperabile)return;
            if (!_controller.DrawStateIsDone) return;
            var curr = DS.csa_contract_partition.Rows[0];
            if (curr["idexp"] == DBNull.Value) return;
            if (txtEserc.Text.Trim() == "") {
                txtNum.Text = "";
                DS.expenseview.Clear();
                curr["idexp"] = DBNull.Value;
            }
            else {
                if (DS.epexpview.Rows.Count == 0) {
                    return;
                }
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
            if (!_controller.DrawStateIsDone) return;
            if (_controller.ErroreIrrecuperabile)return;
            if (txtNum.ReadOnly) return;
            var curr = DS.csa_contract_partition.Rows[0];
            if ((curr["idexp"] != DBNull.Value) && (txtNum.Text.Trim() == "")) {
                DS.expenseview.Clear();
                curr["idexp"] = DBNull.Value;
            }

            btnSpesa_Click(sender, e);
        }
        void EnableDisableParteSpesa(bool enable) {
            txtEserc.ReadOnly = !enable;
            txtNum.ReadOnly = !enable;
            cmbFaseSpesa.SelectedIndex = 0;
            cmbFaseSpesa.Enabled = enable;
            btnSpesa.Enabled = enable;
        }
        void EnableDisableParteNormale(bool enable) {
            btnBilancio.Enabled = enable;
            btnUPB.Enabled = enable;
            txtUPB.ReadOnly = !enable;
            txtBilancio.ReadOnly = !enable;
        }

        void EnableDisable(bool parteNormale) {
            EnableDisableParteNormale(parteNormale);
            EnableDisableParteSpesa(!parteNormale);
        }


        void EnableFaseImpegnoBudget(int nphase, string descrizione) {
            DataRow R = DS.fase_epexp.NewRow();
            R["nphase"] = nphase;
            R["descrizione"] = descrizione;
            DS.fase_epexp.Rows.Add(R);
            DS.fase_epexp.AcceptChanges();
        }

        private void btnLinkEpExp_Click(object sender, EventArgs e) {
            if (_controller.IsEmpty) return;
            DataRow curr = DS.csa_contract_partition.Rows[0];
            MetaData.GetFormData(this, true);
            //EP_functions ep = new EP_functions (MetaData.d);

            object nphase = cmbFaseImpBudget.SelectedValue; // Impegno
            string filter = "";
            int yepexp = CfgFn.GetNoNullInt32(txtEsercizioImpegno.Text.Trim());
            if (yepexp != 0) {
                filter = QHS.CmpEq("yepexp", yepexp);
            }
            else {
                filter = QHS.CmpEq("ayear", _security.GetEsercizio());
            }
            int nepexp = CfgFn.GetNoNullInt32(txtNumImpegno.Text.Trim());
            if (nepexp != 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nepexp", nepexp));
            }

            string filter_fase = "";
            if (CfgFn.GetNoNullInt32(nphase) == 0) {
                filter_fase =  QHS.CmpEq("nphase", 1) ;
            }
            if (CfgFn.GetNoNullInt32(nphase) == 1) {
                filter_fase = QHS.CmpEq("nphase", nphase);
            }
             
            filter = QHS.AppAnd(filter, filter_fase);
            //  Filter = QHS.AppAnd(Filter, EP.GetFilterForEpexp(Meta, Curr["idrelated"].ToString()));
            String fAmount = QHS.CmpGt("isnull(totcurramount,0) - isnull(totalcost,0)", 0); // condizione sul disponibile
            filter = QHS.AppAnd(filter, fAmount);

            object selectedUPB = curr["idupb"];
            object selectedAccount = curr["idacc"];

            var filterUpb = "";
            if (selectedUPB != DBNull.Value) filterUpb = QHC.CmpEq("idupb", selectedUPB);
            var filterAccount = "";
            if (selectedAccount != DBNull.Value)
                filterAccount = QHC.CmpEq("idacc", selectedAccount);

            filter = QHS.AppAnd(filter, filterUpb);
            if (filterAccount != "") {
                filter = QHS.AppAnd(filter, filterAccount);
            }

            string VistaScelta = "epexpview";
            MetaData mepexp = _dispatcher.Get(VistaScelta);
            mepexp.FilterLocked = true;
            mepexp.DS = DS;
            DataRow Choosen = mepexp.SelectOne("default", filter, null, null);
          

            if (Choosen != null) {
                curr["idepexp"] = Choosen["idepexp"];
                DS.epexpview.Clear();
                _conn.RUN_SELECT_INTO_TABLE(DS.epexpview, null,
                    QHS.AppAnd(QHS.CmpEq("idepexp", curr["idepexp"]), QHS.CmpEq("ayear", _security.GetEsercizio())),
                    null, true);
                curr["idacc"] = Choosen["idacc"];
                curr["idupb"] = Choosen["idupb"];
                _conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", curr["idacc"]),
                 null, true);
                _conn.RUN_SELECT_INTO_TABLE(DS.upb, null,
                 QHS.CmpEq("idupb", curr["idupb"]),
                 null, true);
                txtEsercizioImpegno.Text = Choosen["yepexp"].ToString();
                txtNumImpegno.Text = Choosen["nepexp"].ToString();
                cmbFaseImpBudget.SelectedValue = Choosen["nphase"];
                _controller.FreshForm(true, false);
            }
        }

        private void btnRemoveEpExp_Click(object sender, EventArgs e) {
            if (_controller.IsEmpty) return;
            DataRow Curr = DS.csa_contract_partition.Rows[0];
            Curr["idepexp"] = DBNull.Value;
            DS.epexpview.Clear();
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            cmbFaseImpBudget.SelectedIndex = -1;
            _controller.FreshForm(true, false);
        }

        private void cmbFaseImpBudget_SelectedIndexChanged(object sender, EventArgs e) {
            if (_controller.IsEmpty) return;
            if (cmbFaseImpBudget.SelectedIndex <= 0) {
                btnRemoveEpExp_Click(sender, e);
            }
        }

        private void txtEsercizioImpegno_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizioImpegno);
            if (_controller.destroyed || _controller.isClosing) return;
            if (_controller.IsEmpty || DS.csa_contract_partition.Rows.Count == 0) return;
            DataRow Curr = DS.csa_contract_partition.Rows[0];
            if (Curr["idepexp"] != DBNull.Value) {
                if (txtEsercizioImpegno.Text.Trim() == "") {
                    txtNumImpegno.Text = "";
                    DS.epexpview.Clear();
                    Curr["idepexp"] = DBNull.Value;
                }
                else {
                    if (DS.epexpview.Rows.Count > 0) {
                        int oldYmov = CfgFn.GetNoNullInt32(DS.epexpview.Rows[0]["yepexp"]);
                        int newYmov = CfgFn.GetNoNullInt32(txtEsercizioImpegno.Text.Trim());
                        if (oldYmov != newYmov) {
                            txtNumImpegno.Text = "";
                            DS.epexpview.Clear();
                            Curr["idepexp"] = DBNull.Value;
                        }
                    }
                    else {
                        txtNumImpegno.Text = "";
                        Curr["idepexp"] = DBNull.Value;
                    }
                }

            }
        }

        private void txtNumImpegno_Leave(object sender, EventArgs e) {
            if (_controller.destroyed || _controller.isClosing) return;
            if (_controller.IsEmpty || DS.csa_contract_partition.Rows.Count == 0) return;
            if (txtNumImpegno.ReadOnly) return;
            DataRow Curr = DS.csa_contract_partition.Rows[0];
            if ((Curr["idepexp"] != DBNull.Value) && (txtNumImpegno.Text.Trim() == "")) {
                DS.epexpview.Clear();
                Curr["idepexp"] = DBNull.Value;
            }
            btnLinkEpExp_Click(sender, e);
        }
    }
}
