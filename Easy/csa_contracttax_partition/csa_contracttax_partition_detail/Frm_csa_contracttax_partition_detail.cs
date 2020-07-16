/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using AskInfo;
using metadatalibrary;
using funzioni_configurazione;


namespace csa_contracttax_partition_detail {
    public partial class Frm_csa_contracttax_partition_detail : Form {
        MetaData Meta;
        DataAccess Conn;

        public Frm_csa_contracttax_partition_detail() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                QHS.CmpGe("nphase", Meta.GetSys("expensefinphase")), QHS.CmpLt("nphase", Meta.GetSys("expenseregphase"))), "nphase", true);
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);
            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            //EnableFaseImpegnoBudget(2, "Impegno di Budget");
            string filterSiope = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese"));

            DataTable tSortingkind = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiope, null, null, true);
            if ((tSortingkind != null) && (tSortingkind.Rows.Count > 0)) {
                DataRow R = tSortingkind.Rows[0];
                object idsorkind = R["idsorkind"];
                object idsorkind_main = R["idsorkind"];
                SetGBoxClass(idsorkind);
            }

            int esercizioCurr = (int)Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", esercizioCurr);

            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account, QHS.AppAnd(filter));
        }
        void SetGBoxClass(object sortingkind) {
            if (sortingkind != DBNull.Value) {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.sorting, filter);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclassSiope.Text = title;
                gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.tree." + filter;
                btnCodiceSiope.Tag = "manage.sorting.tree." + filter;
            }
        }
        public void MetaData_AfterFill() {
            VisualizzaMovimentoSpesa();
            VisualizzaImpegnoBudget();
        }
        void EnableFaseImpegnoBudget(int nphase, string descrizione) {
            DataRow R = DS.fase_epexp.NewRow();
            R["nphase"] = nphase;
            R["descrizione"] = descrizione;
            DS.fase_epexp.Rows.Add(R);
            DS.fase_epexp.AcceptChanges();
        }

        private void VisualizzaImpegnoBudget() {
            if (MetaData.Empty(this)) return;
            if (DS.Tables["csa_contracttax_partition"] == null) return;
            object idepexp = DS.Tables["csa_contracttax_partition"].Rows[0]["idepexp"];
            string filter = QHS.CmpEq("idepexp", idepexp);
            DataTable DT = Conn.RUN_SELECT("epexp", "yepexp,nepexp,nphase" ,null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEsercizioImpegno.Text = DT.Rows[0]["yepexp"].ToString();
            txtNumImpegno.Text = DT.Rows[0]["nepexp"].ToString();
            cmbFaseImpBudget.SelectedValue = DT.Rows[0]["nphase"];
        }

     

        private void VisualizzaMovimentoSpesa() {
            if (MetaData.Empty(this)) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object idexp = DS.Tables["csa_contracttax_partition"].Rows[0]["idexp"];
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

            DataRow Curr = DS.csa_contracttax_partition.Rows[0];
            string filter = "";
            object idregauto = Get_Registry_Auto();

            int selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            if (selectedfase > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", selectedfase)); //,
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                    QHS.CmpGe("nphase", Meta.GetSys("expensefinphase")),
                    QHS.CmpLt("nphase", Meta.GetSys("expenseregphase"))); 
            }

            int ymov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
            int nmov = CfgFn.GetNoNullInt32(txtNum.Text.Trim());
            if ((ymov != 0) && (nmov != 0)) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov));
            }
            else {

                object selectedUPB = Curr["idupb"];
                object selectedFin = Curr["idfin"];
                if (ymov != 0) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
                }

                if ((nmov != 0)) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
                }

                var filterUpb = "";
                if (selectedUPB != DBNull.Value)
                     
                    filterUpb = QHC.CmpEq("idupb", selectedUPB);
                var filterFin = "";
                if (selectedFin != DBNull.Value)
                    filterFin = QHC.CmpEq("idfin", selectedFin);

                filter = QHS.AppAnd(filter, filterUpb);
                if (filterFin != "") {
                    filter = QHS.AppAnd(filter, filterFin);
                }
            }

       

        MetaData E = Meta.Dispatcher.Get("expense");
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


            Curr["idfin"] = Choosen["idfin"];
            Curr["idupb"] = Choosen["idupb"];
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.fin, null, QHS.CmpEq("idfin", Curr["idfin"]),
             null, true);
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.upb, null,
             QHS.CmpEq("idupb", Curr["idupb"]),
             null, true);
          

            Meta.FreshForm(false);
        }

        private void txtEserc_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEserc);
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_contracttax_partition.Rows[0];
            if (Curr["idexp"] != DBNull.Value) {
                if (txtEserc.Text.Trim() == "") {
                    txtNum.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp"] = DBNull.Value;
                }
                else {
                    if (DS.expenseview.Rows.Count > 0) {
                        int oldYmov = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["ymov"]);
                        int newYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
                        if (oldYmov != newYmov) {
                            txtNum.Text = "";
                            DS.expenseview.Clear();
                            Curr["idexp"] = DBNull.Value;
                        }
                    }
                }

            }
        }

        private void txtNum_Leave(object sender, EventArgs e) {

            if (Meta.IsEmpty) return;
            if (txtNum.ReadOnly) return;
            DataRow Curr = DS.csa_contracttax_partition.Rows[0];
            if ((Curr["idexp"] != DBNull.Value) && (txtNum.Text.Trim() == "")) {
                DS.expenseview.Clear();
                Curr["idexp"] = DBNull.Value;
            }

            btnSpesa_Click(sender, e);
        }

        private void cmbFaseSpesa_SelectedIndexChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            DataRow Curr = DS.csa_contracttax_partition.Rows[0];
            if (Curr["idexp"] != DBNull.Value) {
                int oldNphase = 0;
                if (DS.expenseview.Rows.Count > 0) {
                    oldNphase = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["nphase"]);                    
                }
                
                int newNPhase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
                if (oldNphase != newNPhase) {
                    txtNum.Text = "";
                    txtEserc.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp"] = DBNull.Value;
                }
            }

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

        private void btnLinkEpExp_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.csa_contracttax_partition.Rows[0];
            MetaData.GetFormData(this, true);
            //EP_functions ep = new EP_functions (MetaData.d);

            object nphase = cmbFaseImpBudget.SelectedValue; // Impegno
            string filter = "";
            int yepexp = CfgFn.GetNoNullInt32(txtEsercizioImpegno.Text.Trim());
            if (yepexp != 0) {
                filter = QHS.CmpEq("yepexp", yepexp);
            }
            else {
                filter = QHS.CmpEq("ayear",Meta.GetSys("esercizio"));
            }
            int nepexp = CfgFn.GetNoNullInt32(txtNumImpegno.Text.Trim());
            if (nepexp != 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nepexp", nepexp));
            }

            string filter_fase = "";
            if (CfgFn.GetNoNullInt32(nphase) == 0) {
                filter_fase =  QHS.CmpEq("nphase", 1);
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
            if (selectedUPB != DBNull.Value)
               
                filterUpb = QHC.CmpEq("idupb", selectedUPB);
            var filterAccount = "";
            if (selectedAccount != DBNull.Value)
                filterAccount = QHC.CmpEq("idacc", selectedAccount);

            filter = QHS.AppAnd(filter, filterUpb);
            if (filterAccount != "") {
                filter = QHS.AppAnd(filter, filterAccount);
            }

            string VistaScelta = "epexpview";
            MetaData mepexp = Meta.Dispatcher.Get(VistaScelta);
            mepexp.FilterLocked = true;
            mepexp.DS = DS;
            DataRow Choosen = mepexp.SelectOne("default", filter, null, null);


            if (Choosen != null) {
                curr["idepexp"] = Choosen["idepexp"];
                DS.epexpview.Clear();
                Conn.RUN_SELECT_INTO_TABLE(DS.epexpview, null,
                    QHS.AppAnd(QHS.CmpEq("idepexp", curr["idepexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
                    null, true);
                curr["idacc"] = Choosen["idacc"];
                curr["idupb"] = Choosen["idupb"];
                Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", curr["idacc"]),
                 null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.upb, null,
                 QHS.CmpEq("idupb", curr["idupb"]),
                 null, true);
                txtEsercizioImpegno.Text = Choosen["yepexp"].ToString();
                txtNumImpegno.Text = Choosen["nepexp"].ToString();
                cmbFaseImpBudget.SelectedValue = Choosen["nphase"];
                Meta.FreshForm();
            }
        }

        private void btnRemoveEpExp_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_contracttax_partition.Rows[0];
            Curr["idepexp"] = DBNull.Value;
            DS.epexpview.Clear();
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            cmbFaseImpBudget.SelectedIndex = -1;
            Meta.FreshForm();
        }

        private void cmbFaseImpBudget_SelectedIndexChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (cmbFaseImpBudget.SelectedIndex <= 0) {
                btnRemoveEpExp_Click(sender, e);
            }
        }

        private void txtEsercizioImpegno_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizioImpegno);
            if ( Meta.formController.isClosing) return;
            if (Meta.IsEmpty || DS.csa_contracttax_partition.Rows.Count == 0) return;
            DataRow Curr = DS.csa_contracttax_partition.Rows[0];
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
            if (Meta.formController.isClosing) return;
            if (Meta.IsEmpty || DS.csa_contracttax_partition.Rows.Count == 0) return;
            if (txtNumImpegno.ReadOnly) return;
            DataRow Curr = DS.csa_contracttax_partition.Rows[0];
            if ((Curr["idepexp"] != DBNull.Value) && (txtNumImpegno.Text.Trim() == "")) {
                DS.epexpview.Clear();
                Curr["idepexp"] = DBNull.Value;
            }
            btnLinkEpExp_Click(sender, e);
        }

    
    }
}