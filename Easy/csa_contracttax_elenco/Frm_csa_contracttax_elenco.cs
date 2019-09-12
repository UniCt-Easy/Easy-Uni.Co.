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

namespace csa_contracttax_elenco {
    public partial class Frm_csa_contracttax_elenco :Form {
        MetaData Meta;
        DataAccess Conn;
        public Frm_csa_contracttax_elenco() {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account, filter);
            GetData.SetStaticFilter(DS.expenseview, filter);
            GetData.SetStaticFilter(DS.csa_contractkindyear, filter);
            GetData.SetStaticFilter(DS.csa_contracttaxview, filter);
            GetData.SetStaticFilter(DS.csa_contract, filter);
            GetData.SetSorting(DS.upb, "codeupb asc");
            DataAccess.SetTableForReading(DS.expenseview2, "expenseview");
 
            DataAccess.SetTableForReading(DS.expenseview3, "expenseview");
 
            DataAccess.SetTableForReading(DS.epexpview3, "epexpview");
            DataAccess.SetTableForReading(DS.fin2, "fin");
            DataAccess.SetTableForReading(DS.upb2, "upb");
            DataAccess.SetTableForReading(DS.account2, "account");
            DataAccess.SetTableForReading(DS.sorting1, "sorting");

            DataAccess.SetTableForReading(DS.epexpview2, "epexpview");
            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                   QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))), "nphase", true);

            string filterSiope = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese"));

            DataTable tSortingkind = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiope, null, null, true);
            if ((tSortingkind != null) && (tSortingkind.Rows.Count > 0)) {
                DataRow R = tSortingkind.Rows[0];
                object idsorkind = R["idsorkind"];
                object idsorkind_main = R["idsorkind"];
                SetGBoxClass(idsorkind);
            }
            Meta.MarkTableAsNotEntityChild(DS.csa_contracttaxexpense);
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);
            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            EnableFaseImpegnoBudget(2, "Impegno di Budget");
        }
        public void MetaData_AfterClear() {
            EnableDisableOggetti(true);
        }
        void EnableFaseImpegnoBudget(int nphase, string descrizione) {
            DataRow R = DS.fase_epexp.NewRow();
            R["nphase"] = nphase;
            R["descrizione"] = descrizione;
            DS.fase_epexp.Rows.Add(R);
            DS.fase_epexp.AcceptChanges();
        }

        public void EnableDisableOggetti(bool enable) {
            gboxConto.Enabled = enable;
            grpBoxImpegniBudget.Enabled = enable;
            gboxUPB.Enabled = enable;
            gboxclassSiope.Enabled = enable;
            grpBilancioVersamento.Enabled = enable;
            grpFinanziaria.Enabled = enable;
            grpImpBudget.Enabled = enable;
            grpRipartizioneUnica.Enabled = enable;
        }
        public void MetaData_AfterFill() {
            EnableDisableOggetti(false);
            if (!Meta.InsertMode) {
                VisualizzaMovimentoSpesa();
                //VisualizzaMovimentoBudget();
            }
            if (DS.epexp.Rows.Count > 0) {
                object currtipo = DS.Tables["epexp"].Rows[0]["nphase"];
                HelpForm.SetComboBoxValue(cmbFaseImpBudget, currtipo);
            }
        }
        private void VisualizzaMovimentoSpesa() {
            if (MetaData.Empty(this)) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object idexp = DS.Tables["csa_contracttax"].Rows[0]["idexp"];
            string filter = QHS.CmpEq("idexp", idexp);
            DataTable DT = Conn.RUN_SELECT("expense", "idexp,ymov,nmov,nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEserc.Text = DT.Rows[0]["ymov"].ToString();
            txtNum.Text = DT.Rows[0]["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = DT.Rows[0]["nphase"];
        }

        //private void VisualizzaMovimentoBudget() {
        //    if (MetaData.Empty(this)) return;
        //    object idepexp = DS.Tables["csa_contracttax"].Rows[0]["idepexp"];
        //    string filter = QHS.CmpEq("idepexp", idepexp);
        //    DataTable DT = Conn.RUN_SELECT("epexp", "idepexp, yepexp, nepexp, nphase", null, filter, null, true);
        //    if (DT.Rows.Count == 0) return;
        //    txtEsercizioImpegno.Text = DT.Rows[0]["yepexp"].ToString();
        //    txtNumImpegno.Text = DT.Rows[0]["nepexp"].ToString();
        //    cmbFaseImpBudget.SelectedValue = DT.Rows[0]["nphase"];
        //}
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

        private void btnSpesa_Click(object sender, EventArgs e) {

        }
    }
}

