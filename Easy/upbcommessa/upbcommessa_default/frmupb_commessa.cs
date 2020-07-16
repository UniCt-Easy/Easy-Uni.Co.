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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using ep_functions;

namespace upbcommessa_default {
    public partial class frmupb_commessa :Form {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC = new CQueryHelper();
        QueryHelper QHS;
        EntityDispatcher Dispatcher;
        int esercizio;
        private EP_Manager EPM;
        public frmupb_commessa() {
            InitializeComponent();
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Dispatcher = Meta.Dispatcher as EntityDispatcher;
            Conn = Meta.Conn;
            esercizio = Conn.GetEsercizio();
            QHS = Conn.GetQueryHelper();
            //bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
            DataAccess.SetTableForReading(DS.accmotive_accruals,"accmotive");
            DataAccess.SetTableForReading(DS.accmotive_accruals_original, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_cost, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_cost_original, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_deferredcost, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_deferredcost_original, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_revenue, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_revenue_original, "accmotive");
            DataAccess.SetTableForReading(DS.account_accruals, "account");
            DataAccess.SetTableForReading(DS.account_accruals_original, "account");
            DataAccess.SetTableForReading(DS.account_cost, "account");
            DataAccess.SetTableForReading(DS.account_cost_original, "account");
            DataAccess.SetTableForReading(DS.account_deferredcost, "account");
            DataAccess.SetTableForReading(DS.account_deferredcost_original, "account");
            DataAccess.SetTableForReading(DS.account_revenue, "account");
            DataAccess.SetTableForReading(DS.account_revenue_original, "account");
            DataAccess.SetTableForReading(DS.epupbkind_original, "epupbkind");

            GetData.SetStaticFilter(DS.upbcommessa, QHS.CmpEq("ayear", esercizio));
            GetData.SetStaticFilter(DS.epupbkindyear, QHS.CmpEq("ayear", esercizio));

            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreimpegni, btnVisualizzaPreimpegni,
                btnGeneraEP, btnVisualizzaEP,

                labEP, null, "upbcommessa");

        }

        DataRow getDatiCorrenti() {
            if (Meta.IsEmpty) return null;

            var curr = DS.upbcommessa[0];
            var t = ottieniDettagliAssestamentoCommessaCompletata(curr["idupb"]);
            if (t == null || t.Rows.Count == 0) {
                t = ottieniRateiApertiProgettiInChiusura(curr["idupb"]);
            }

            if (t == null || t.Rows.Count == 0) {
                MessageBox.Show(@"L'upb non è (più) tra quelli considerati tra quelli a commessa completata ", @"Errore");
                return null;
            }

            return t.Rows[0];
        }

        void AggiornaCampiAttuali() {
            var r = getDatiCorrenti();
            if (r==null)return;
            decimal amount = 0;
            if (r.Table.Columns.Contains("cost")) {
                amount = CfgFn.GetNoNullDecimal(r["cost"]);
                txtCostiAttuale.Text = amount.ToString("c");
            }

            if (r.Table.Columns.Contains("revenue")) {
                amount = CfgFn.GetNoNullDecimal(r["revenue"]);
                txtRicaviAttuale.Text = amount.ToString("c");
            }

            if (r.Table.Columns.Contains("reserve")) {
                amount = CfgFn.GetNoNullDecimal(r["reserve"]);
                txtRiserveAttuale.Text = amount.ToString("c");
            }

            if (r.Table.Columns.Contains("accruals")) {
                amount = CfgFn.GetNoNullDecimal(r["accruals"]);
                txtRateiAttuale.Text = amount.ToString("c");
            }

            var curr = DS.upbcommessa[0];
            DataRow totali = ottieniTotaleGenerale(curr["idupb"]);
            if (totali != null) {
                txtRisultatoTotaleRisconti.Text = CfgFn.GetNoNullDecimal(totali["risconti"]).ToString("c");
                txtRisultatoTotaleCosti.Text = CfgFn.GetNoNullDecimal(totali["cost"]).ToString("c");
                txtRisultatoTotaleRateiAttivi.Text = CfgFn.GetNoNullDecimal(totali["accruals"]).ToString("c");
            }

            txtAnnoInizioCorrente.Text = r["yearstart"].ToString();
            txtEPUPBKIndOriginal.Text =
                Conn.DO_READ_VALUE("epupbkind", QHS.CmpEq("idepupbkind", r["idepupbkind"]), "title").ToString();
            txtAnnoFineCorrente.Text = r["yearstop"].ToString();
            //object idaccmotive = r["idaccmotive_cost"];
            //txtCausaleCostoAttuale.Text = "";
            //if (idaccmotive != DBNull.Value) {
            //    txtCausaleCostoAttuale.Text = Conn.DO_READ_VALUE("accmotive", QHS.CmpEq("idaccmotive",idaccmotive),"description").ToString();
            //}
            //idaccmotive = r["idaccmotive_revenue"];
            //txtCausaleRicavoAttuale.Text = "";
            //if (idaccmotive != DBNull.Value) {
            //    txtCausaleRicavoAttuale.Text = Conn.DO_READ_VALUE("accmotive", QHS.CmpEq("idaccmotive", idaccmotive), "description").ToString();
            //}
            //idaccmotive = r["idaccmotive_deferredcost"];
            //txtCausaleRiscontoAttuale.Text = "";
            //if (idaccmotive != DBNull.Value) {
            //    txtCausaleRiscontoAttuale.Text = Conn.DO_READ_VALUE("accmotive", QHS.CmpEq("idaccmotive", idaccmotive), "description").ToString();
            //}
            //idaccmotive = r["idaccmotive_accruals"];
            //txtCausaleRateoAttuale.Text = "";
            //if (idaccmotive != DBNull.Value) {
            //    txtCausaleRateoAttuale.Text = Conn.DO_READ_VALUE("accmotive", QHS.CmpEq("idaccmotive", idaccmotive), "description").ToString();
            //}

        }

        private void btnRicalcola_Click(object sender, EventArgs e) {
            var found = getDatiCorrenti();
            if (found == null)return;

            var r = DS.upbcommessa[0];
            Meta.GetFormData(false);
            
            foreach (var field in new[] {
                "codeupb", "title",
                "yearstart", "yearstop", "idepupbkind",
                "idaccmotive_cost", "idaccmotive_revenue", "idaccmotive_deferredcost", "idaccmotive_accruals",
                "idacc_cost", "idacc_revenue", "idacc_deferredcost", "idacc_accruals",
                "cost", "reserve", "revenue", "accruals"
            }) {
                if (found.Table.Columns.Contains(field)) r[field] = found[field];
            }
            Meta.FreshForm();            
        }

        //public void MetaData_AfterActivation() { }
        public void MetaData_AfterClear() {
            txtCodiceUpb.ReadOnly = false;
            txtDenominazioneUpb.ReadOnly = false;

            btnRicalcola.Visible = false;
            EPM.mostraEtichette();
            txtCostiAttuale.Text = "";
            txtRicaviAttuale.Text = "";
            txtRiserveAttuale.Text = "";
            txtRateiAttuale.Text = "";

            txtAnnoInizioCorrente.Text = "";
            txtAnnoFineCorrente.Text = "";

            txtEPUPBKIndOriginal.Text = "";

            txtRisultatoTotaleCosti.Text = "";
            txtRisultatoTotaleRateiAttivi.Text = "";
            txtRisultatoTotaleRisconti.Text = "";


        }

        //public void MetaData_BeforeFill() {}

        public void MetaData_AfterFill() {
            txtCodiceUpb.ReadOnly = true;
            txtDenominazioneUpb.ReadOnly = true;
            if (EPM.esistonoScrittureCollegate()) Meta.CanCancel = false;
            EPM.mostraEtichette();
            btnRicalcola.Visible = true;
            AggiornaCampiAttuali();
        }
        //public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
        public void MetaData_BeforePost() {
            EPM.beforePost();
        }

        public void MetaData_AfterPost() {
            EPM.afterPost();
        }

        private DataRow ottieniTotaleGenerale(object idupb) {
            int currAyear = (int)Meta.GetSys("esercizio");
            string query =
                "select " +
                "sum(case when A.flagaccountusage & 8 <> 0 then ED.amount else 0 end) as risconti, "  +
                "-sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end) as cost," +
                "-sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) as accruals " +
                "from entrydetail ed (nolock) " +
                " join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry "+
                "join upb u (nolock) on ed.idupb = u.idupb " +
                "join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind " +
                "join account A (nolock) on A.idacc = ed.idacc " +
                " where " +
                QHS.AppAnd(QHS.NullOrLe("year(U.start)", currAyear),
                    QHS.CmpGt("year(U.stop)", currAyear), QHS.CmpEq("EU.ayear", currAyear),
                    QHS.CmpEq("EU.adjustmentkind", "C"), QHS.CmpEq("ED.yentry", currAyear),
                    QHS.CmpEq("e.identrykind",8),
                    QHS.CmpEq("U.idupb",idupb)
                );

            DataTable result = Meta.Conn.SQLRunner(query, false, 600);
            return result?.Rows[0];
        }

        private DataTable ottieniDettagliAssestamentoCommessaCompletata(object idupb) {
            int currAyear = (int)Meta.GetSys("esercizio");

            string query =
                "select U.idupb,  " +
                "-sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end) as cost," +
                "sum(case when A.flagaccountusage & 128 <> 0 then ED.amount else 0 end) as revenue," +
                "sum(case when A.flagaccountusage & 2048 <> 0 then ED.amount else 0 end) as reserve," +
                "-sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) as accruals," +
                "EU.idacc_cost, EU.idacc_revenue, 	EU.idacc_deferredcost,EU.idacc_accruals," +
                "EU.idaccmotive_cost, EU.idaccmotive_revenue, 	EU.idaccmotive_deferredcost,EU.idaccmotive_accruals," +
                "year(U.stop) as yearstop, year(U.start) as yearstart,   EU.adjustmentkind,U.idepupbkind,U.codeupb,U.title " +
                "from entrydetail ed (nolock) " +
                " join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry "+
                "join upb u (nolock) on ed.idupb = u.idupb " +
                "join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind " +
                "join account A (nolock) on A.idacc = ed.idacc " +
                " where " +
                QHS.AppAnd(QHS.NullOrLe("year(U.start)", currAyear),
                            QHS.CmpGt("year(U.stop)", currAyear), QHS.CmpEq("EU.ayear", currAyear),
                    QHS.CmpEq("EU.adjustmentkind", "C"), QHS.CmpEq("ED.yentry", currAyear),
                    QHS.FieldNotIn("e.identrykind",new Object[]{ 8,11,12}),
                    QHS.CmpEq("U.idupb",idupb)
                    ) +

                " group by U.idupb,EU.idacc_cost, EU.idacc_revenue, 	EU.idacc_deferredcost,EU.idacc_accruals, " +
                " EU.idaccmotive_cost, EU.idaccmotive_revenue, 	EU.idaccmotive_deferredcost,EU.idaccmotive_accruals," +
                " EU.adjustmentkind,year(U.stop),year(U.start),U.idepupbkind,U.codeupb,U.title  ";


            DataTable tPluri = DataAccess.SQLRunner(Meta.Conn, query, false, 600);
            return tPluri;
        }


          //La scrittura sui ratei va fatta comunque prima di capire se i costi hanno superato  i ricavi, ossia bisogna portare i ratei attivi a costo
        // Infatti questa scrittura è fatta nell'anno della chiusura, mentre l'utile/perdita sarà valutato l'anno successivo
        DataTable ottieniRateiApertiProgettiInChiusura(object idupb) {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);

            string query = "select  -sum(ed.amount) as accruals ,year(U.stop) as yearstop, year(U.start) as yearstart,ed.idupb, ed.idacc as idacc_accruals,  " +
                           "EU.idacc_deferredcost, 	EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue,U.idepupbkind,U.title,U.codeupb ," +
                           "EU.idacc_cost,EU.idaccmotive_cost,EU.idacc_accruals, EU.idaccmotive_accruals " +//ed.idepexp, commentato con task 11624
                           " from entrydetail ed " +
                           " join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry "+
                           " join account A on ED.idacc=A.idacc " +
                           " join UPB U on ED.idupb=U.idupb " +
                           " join epupbkindyear EU on EU.idepupbkind = U.idepupbkind " +
                           " WHERE " +
                           " ED.yentry= " + strYear +  //scritture di quest'anno
                           " AND E.identrykind not in (8,11,12) "+
                           " AND ED.idacc=EU.idacc_accruals "+
                           " and EU.ayear =" + strYear+    // prende la configurazione tipo UPB di quest'anno
                           " AND "+QHS.CmpEq("ED.idupb",idupb) +
                           " AND year(U.stop) = " + strYear + // UPB in scadenza quest'anno
                           " group by ed.idupb, ed.idacc, EU.idacc_cost,EU.idaccmotive_cost,"+
                           " EU.idacc_deferredcost, EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue," +
                           " EU.idacc_accruals, EU.idacc_deferredcost,EU.idaccmotive_accruals,year(U.stop),year(U.start),U.idepupbkind,U.title,U.codeupb   "; // ed.idepacc,ed.idepexp,
            DataTable t = Conn.SQLRunner(query, false,600);
            return t;
        }

    }
}
