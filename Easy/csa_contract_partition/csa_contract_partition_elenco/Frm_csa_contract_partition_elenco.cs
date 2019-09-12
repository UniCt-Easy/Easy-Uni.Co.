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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using AskInfo;

namespace csa_contract_partition_elenco {
    public partial class Frm_csa_contract_partition_elenco :Form {
        MetaData Meta;
        DataAccess Conn;
        public Frm_csa_contract_partition_elenco() {
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
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.csa_contract_partition, filter);
			GetData.SetStaticFilter(DS.csa_contract_partitionview, filter);
			GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account, QHS.AppAnd(filter));

            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.CanCancel = false;
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);
            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            ///EnableFaseImpegnoBudget(2, "Impegno di Budget");
            string filterSiope = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese"));

            DataTable tSortingkind = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiope, null, null, true);
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
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclassSiope.Text = title;
                gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.tree." + filter;
                btnCodiceSiope.Tag = "manage.sorting.tree." + filter;
            }
        }

        void EnableFaseImpegnoBudget(int nphase, string descrizione) {
            DataRow R = DS.fase_epexp.NewRow();
            R["nphase"] = nphase;
            R["descrizione"] = descrizione;
            DS.fase_epexp.Rows.Add(R);
            DS.fase_epexp.AcceptChanges();
        }
        private void enableControls(bool abilita) {
            bool readOnly = !abilita;
            gboxSpesa.Enabled = abilita;
            grpContrattoCSA.Enabled = abilita;
            txtQuota.ReadOnly = readOnly;
            txtEsercizio.ReadOnly = readOnly;
            gboxConto.Enabled = abilita;
            gboxUPB.Enabled = abilita;
            grpBilancioVersamento.Enabled = abilita;
            gboxImpegnoBudget.Enabled = abilita;
        }


        public void MetaData_AfterFill() {
            enableControls(false);
            VisualizzaFaseImpegno();
        }

        private void VisualizzaFaseImpegno() {
            if (DS.epexpview.Rows.Count > 0) {
                object currtipo = DS.Tables["epexpview"].Rows[0]["nphase"];
                HelpForm.SetComboBoxValue(cmbFaseImpBudget, currtipo);
            }
        }


        public void MetaData_AfterClear() {
            enableControls(true);
            txtEserc.Text = "";
            txtNum.Text = "";
            cmbFaseSpesa.SelectedIndex = 0;
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            cmbFaseImpBudget.SelectedIndex = 0;
        }
        object Get_Registry_Csa() {
            object esercizio = Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
            if (t == null) return DBNull.Value;
            if (t.Rows.Count == 0) return DBNull.Value;
            DataRow rConfig = t.Rows[0];
            return rConfig["idreg_csa"];
        
    }
        private void cmbFaseSpesa_SelectedIndexChanged(object sender, EventArgs e) {
           
            int newNPhase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            if (newNPhase == 0) {
                txtNum.Text = "";
                txtEserc.Text = "";
                DS.expenseview.Clear();
            }

        }

        private void txtEserc_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEserc);
            if (txtEserc.Text.Trim() == "") {
                txtNum.Text = "";
                DS.expenseview.Clear();
            }
        }
        private void txtEsercizioImpegno_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizioImpegno);
            if (txtEsercizioImpegno.Text.Trim() == "") {
                txtNumImpegno.Text = "";
                DS.epexpview.Clear();
            }
        }

        private void btnRemoveEpExp_Click(object sender, EventArgs e) {
            DS.epexpview.Clear();
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            cmbFaseImpBudget.SelectedIndex = -1;
        }

        private void cmbFaseImpBudget_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbFaseImpBudget.SelectedIndex <= 0) {
                btnRemoveEpExp_Click(sender, e);
            }
        }


        private void txtNum_Leave(object sender, EventArgs e) {
            if (txtNum.ReadOnly) return;
            if (txtNum.Text.Trim() == "") {
                DS.expenseview.Clear();
            }
            btnSpesa_Click(sender, e);
        }

        private void txtNumImpegno_Leave(object sender, EventArgs e) {
            if (txtNumImpegno.ReadOnly) return;
            if (txtNumImpegno.Text.Trim() == "") {
                DS.epexpview.Clear();
            }
            btnImpegnoBudget_Click(sender, e);
        }



        private void btnSpesa_Click(object sender, EventArgs e) {
            Meta.GetFormData(true);

            string filter = "";
            object idreg_csa = Get_Registry_Csa();

            int selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            if (selectedfase > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", selectedfase));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                         QHS.CmpGe("nphase", Meta.GetSys("expensefinphase")),
                         QHS.CmpLt("nphase", Meta.GetSys("expenseregphase"))); 
            }

            int ymov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
            int nmov = CfgFn.GetNoNullInt32(txtNum.Text.Trim());
            if (ymov != 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
            }
            if ((nmov != 0)) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
            }
           
            MetaData E = Meta.Dispatcher.Get("expense");
            E.FilterLocked = true;
            E.DS = DS.Clone();
            DataRow Choosen = E.SelectOne("default", filter, "expense", null);
            if (Choosen == null) return;
         

            DS.expenseview.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview, null,
                QHS.AppAnd(QHS.CmpEq("idexp", Choosen["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
                null, true);
            txtEserc.Text = Choosen["ymov"].ToString();
            txtNum.Text = Choosen["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = Choosen["nphase"];
          //  Meta.FreshForm(false);
        }

        private void btnImpegnoBudget_Click(object sender, EventArgs e) {
            MetaData.GetFormData(this, true);
            //EP_functions ep = new EP_functions (MetaData.d);

            object nphase = cmbFaseImpBudget.SelectedValue; // Impegno
            string filter = "";
            int yepexp = CfgFn.GetNoNullInt32(txtEsercizioImpegno.Text.Trim());
            if (yepexp != 0) {
                filter = QHS.CmpEq("yepexp", yepexp);
            }
            else {
                filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
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
 

    
            string VistaScelta = "epexpview";
            MetaData mepexp = Meta.Dispatcher.Get(VistaScelta);
            mepexp.FilterLocked = true;
            mepexp.DS = DS.Clone();
          
            DataRow Choosen = mepexp.SelectOne("default", filter, null, null);


            if (Choosen != null) {
 
                DS.epexpview.Clear();
                Conn.RUN_SELECT_INTO_TABLE(DS.epexpview, null,
                    QHS.AppAnd(QHS.CmpEq("idepexp", Choosen["idepexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
                    null, true);
                //Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", curr["idacc"]),
                // null, true);
                //Conn.RUN_SELECT_INTO_TABLE(DS.upb, null,
                // QHS.CmpEq("idupb", curr["idupb"]),
                // null, true);
                txtEsercizioImpegno.Text = Choosen["yepexp"].ToString();
                txtNumImpegno.Text = Choosen["nepexp"].ToString();
                cmbFaseImpBudget.SelectedValue = Choosen["nphase"];
               // Meta.FreshForm(false);
            }
        }
    }
}
