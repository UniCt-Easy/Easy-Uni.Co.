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
using ep_functions;

namespace csa_importver_epexp_detail {
    public partial class Frm_csa_importver_epexp_detail : Form {
        MetaData Meta;
        DataAccess Conn;

        public Frm_csa_importver_epexp_detail() {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            HelpForm.SetDenyNull(DS.csa_importver_epexp.Columns["idepexp"], true);
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);

            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            EnableFaseImpegnoBudget(2, "Impegno di Budget");
        }

        private bool dontDetach = false;
        public void MetaData_AfterFill() {
            dontDetach = true;
            VisualizzaMovimentoSpesa();
            dontDetach = false;
        }


        private void VisualizzaMovimentoSpesa() {
            if (MetaData.Empty(this)) return;
            if (DS.Tables["csa_importver_epexp"] == null) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object idepexp = DS.Tables["csa_importver_epexp"].Rows[0]["idepexp"];
            string filter = QHS.CmpEq("idepexp", idepexp);
            DataTable DT = Conn.RUN_SELECT("epexp", "idepexp,yepexp,nepexp,nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEsercizioImpegno.Text = DT.Rows[0]["yepexp"].ToString();
            txtNumImpegno.Text = DT.Rows[0]["nepexp"].ToString();
            dontDetach = true;
            HelpForm.SetComboBoxValue(cmbFaseImpBudget, DT.Rows[0]["nphase"]);
            dontDetach = false;

        }



        void EnableFaseImpegnoBudget(int nphase, string descrizione) {
            DataRow R = DS.fase_epexp.NewRow();
            R["nphase"] = nphase;
            R["descrizione"] = descrizione;
            DS.fase_epexp.Rows.Add(R);
            DS.fase_epexp.AcceptChanges();
        }

        private void btnLinkEpExp_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.csa_importver_epexp.Rows[0];
            MetaData.GetFormData(this, true);
            EP_functions ep = new EP_functions(Meta.Dispatcher);
            object nphase = cmbFaseImpBudget.SelectedValue; // Impegno
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter_fase = "";
            if (CfgFn.GetNoNullInt32(nphase) == 0) {
                filter_fase = QHS.AppOr(QHS.DoPar(QHS.CmpEq("nphase", 1)),
                    QHS.DoPar(QHS.CmpEq("nphase", 2)));
            }
            if ((CfgFn.GetNoNullInt32(nphase) == 1) || (CfgFn.GetNoNullInt32(nphase) == 2)) {
                filter_fase = QHS.CmpEq("nphase", nphase);
            }
            filter = QHS.AppAnd(filter, filter_fase);
            String fAmount = QHS.CmpGt("(totcurramount - isnull(totalcost,0))", 0); // condizione sul disponibile
            filter = QHS.AppAnd(filter, fAmount);

            string VistaScelta = "epexpview";

            MetaData mepexp = Meta.Dispatcher.Get(VistaScelta);
            mepexp.FilterLocked = true;
            mepexp.DS = DS;
            DataRow myDr = mepexp.SelectOne("default", filter, null, null);

            if (myDr != null) {
                curr["idepexp"] = myDr["idepexp"];
                dontDetach = true;
                Meta.FreshForm();
                dontDetach = false;
            }
        }

       

        

        private void cmbFaseImpBudget_SelectedIndexChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (dontDetach) return;
            DataRow Curr = DS.csa_importver_epexp.Rows[0];
            if (Curr["idepexp"] != DBNull.Value ) {
                int oldNphase = 0;
                if (DS.epexp.Rows.Count > 0) oldNphase=CfgFn.GetNoNullInt32(DS.epexp.Rows[0]["nphase"]);
                int newNPhase = CfgFn.GetNoNullInt32(cmbFaseImpBudget.SelectedValue);
                if (oldNphase != newNPhase) {
                    txtNumImpegno.Text = "";
                    txtEsercizioImpegno.Text = "";
                    DS.epexp.Clear();
                    Curr["idepexp"] = DBNull.Value;
                }
            }
        }

        private void btnRemoveEpExp_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_importver_epexp.Rows[0];
            Curr["idepexp"] = DBNull.Value;
            DS.epexp.Clear();
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            cmbFaseImpBudget.SelectedIndex = -1;
            Meta.FreshForm();
        }
    }
}
