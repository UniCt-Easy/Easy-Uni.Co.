
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using ep_functions;

namespace upbcommessa_default {
    public partial class frmupb_commessa : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC = new CQueryHelper();
        QueryHelper QHS;
        EntityDispatcher Dispatcher;
        int esercizio;
        bool risconta_ammortamenti_futuri = false;
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

           object risconta_ammortamenti_futuriObj = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", esercizio), "risconta_ammortamenti_futuri");
           if (risconta_ammortamenti_futuriObj == DBNull.Value) risconta_ammortamenti_futuriObj = "N";
           risconta_ammortamenti_futuri = risconta_ammortamenti_futuriObj.ToString().ToUpper() == "S";
            

        }

        DataRow getDatiCorrenti( out DataRow rTotAssetAmortization) {
            labelNoCommessaCompletata.Text = "";
            rTotAssetAmortization = null;
            if (Meta.IsEmpty) return null;

            var curr = DS.upbcommessa[0];
            var t = ottieniDettagliAssestamentoCommessaCompletata(curr["idupb"]);
            if (t == null || t.Rows.Count == 0) {
                t = ottieniRateiApertiProgettiInChiusura(curr["idupb"]);
            }

            // se in configurazione annuale ho deciso di riscontare gli ammortamenti futuri
            // per i progetti in chiusura senza ratei aperti
            // leggo i relativi dettagli scritture per ottenere i dati su costi e ricavi 

   
            if ((t == null || t.Rows.Count == 0) && (risconta_ammortamenti_futuri)) {
                t = ottieniProgettiInChiusuraNoRateiAperti(curr["idupb"]);
            }
            else
            {
                //show(@"L'upb non è (più) tra quelli considerati a commessa completata ", @"Errore");
                labelNoCommessaCompletata.Text = "L'upb non è (più) tra quelli considerati a commessa completata ";
                return null;    
            }
            // L'UPB corrente fa parte dei progetti in chiusura senza ratei
            if (t == null || t.Rows.Count == 0) {  
                //show(@"L'upb non è (più) tra quelli considerati a commessa completata ", @"Errore");
                labelNoCommessaCompletata.Text = "L'upb non è (più) tra quelli considerati a commessa completata ";
                return null;
            }
            else
            {
                // se l'UPB corrente rientra nei progetti in chiusura e non ha ratei aperti
                // calcolo gli ammortamenti futuri. 
                DataRow rAmm = ottieniAmmmortamentiFuturiUPB(curr["idupb"]);
                if (rAmm == null) {
                    //show(@"L'upb non è (più) tra quelli considerati a commessa completata ", @"Errore");
                    labelNoCommessaCompletata.Text = "L'upb non è (più) tra quelli considerati a commessa completata ";
                    return null;
                }
                else {
                    rTotAssetAmortization = rAmm;
                }
            }

            return t.Rows[0];
        }

        void AggiornaCampiAttuali() {
            DataRow rAmmFuturi ;
            var r = getDatiCorrenti(out rAmmFuturi);
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

            if (rAmmFuturi!=null) {
                amount = CfgFn.GetNoNullDecimal(rAmmFuturi["amm_futuricespiti"]);
                txtAmmortamentiFuturi.Text = amount.ToString("c");
            }
           
            var curr = DS.upbcommessa[0];
            DataRow totali = ottieniTotaleGenerale(curr["idupb"]); // Dati di riepilogo sulle scritture generate 
            if (totali != null) {
                txtRisultatoTotaleRisconti.Text = CfgFn.GetNoNullDecimal(totali["risconti"]).ToString("c");
                txtRisultatoTotaleCosti.Text = CfgFn.GetNoNullDecimal(totali["cost"]).ToString("c");
                txtRisultatoTotaleRicavi.Text = CfgFn.GetNoNullDecimal(totali["revenue"]).ToString("c");
                txtRisultatoTotaleRateiAttivi.Text = CfgFn.GetNoNullDecimal(totali["accruals"]).ToString("c");
            }

            txtAnnoInizioCorrente.Text = r["yearstart"].ToString();
            txtEPUPBKIndOriginal.Text =
            Conn.DO_READ_VALUE("epupbkind", QHS.CmpEq("idepupbkind", r["idepupbkind"]), "title").ToString();
            txtAnnoFineCorrente.Text = r["yearstop"].ToString();
        }

        private void btnRicalcola_Click(object sender, EventArgs e) {
             // Ricalcola i dati ai fini del calcolo della commessa completata
            DataRow rAmmFuturi ;
           
            var found = getDatiCorrenti(out rAmmFuturi);
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

                if (rAmmFuturi != null) // la stima degli ammortamenti futuri cespiti è calcolata a parte
                {
                    r["assetamortization"] = CfgFn.GetNoNullDecimal(rAmmFuturi["amm_futuricespiti"]);
                }
            }
            Meta.FreshForm();            
        }

        //public void MetaData_AfterActivation() { }
        public void MetaData_AfterClear() {
            txtCodiceUpb.ReadOnly = false;
            txtAnnoInizio.ReadOnly = false;
            txtAnnoFine.ReadOnly = false;
            txtDenominazioneUpb.ReadOnly = false;

            btnRicalcola.Visible = false;
            EPM.mostraEtichette();
            txtCostiAttuale.Text = "";
            txtRicaviAttuale.Text = "";
            txtRiserveAttuale.Text = "";
            txtRateiAttuale.Text = "";
            txtAmmortamentiFuturi.Text = "";
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
            txtAnnoInizio.ReadOnly = true;
            txtAnnoFine.ReadOnly = true;
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


        private DataRow ottieniAmmmortamentiFuturiUPB( object idupb  ) {
            DataTable tAmmortamentiFuturi = new DataTable();

            DataSet Out = Meta.Conn.CallSP("calcola_ammortamenti_futuri_cespiti",
                new Object[3] {Meta.GetSys("esercizio"),
                                Meta.GetSys("datacontabile"),
                                idupb 
							  }, false, 600
                );

            if (Out == null) return null;
            if (Out.Tables.Count == 0) {
                return null;
            }
            tAmmortamentiFuturi = Out.Tables[0];
            if (tAmmortamentiFuturi.Rows.Count == 0) {
                return null;
            }
            return tAmmortamentiFuturi?.Rows[0];
            // Lancio sp calcolo ammortamenti futuri
        }


        private DataRow ottieniTotaleGenerale(object idupb) {
            int currAyear = (int)Meta.GetSys("esercizio");
            string query =
                "select " +
                "sum(case when A.flagaccountusage & 8 <> 0 then ED.amount else 0 end) as risconti, " +
                "-sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end) as cost, " +
                "sum(case when A.flagaccountusage & 128 <> 0 then ED.amount else 0 end) as revenue, " +
                "-sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) as accruals " +
                "from entrydetail ed (nolock) " +
                "join entry e (nolock) on e.yentry=ed.yentry and e.nentry=ed.nentry " +
                "join upb u (nolock) on ed.idupb = u.idupb " +
                "join epupbkindyear EU (nolock)  on EU.idepupbkind = U.idepupbkind " +
                "join account A (nolock) on A.idacc = ed.idacc " +
                " where " +
                QHS.AppAnd(QHS.NullOrLe("year(U.start)", currAyear),
                    QHS.CmpGe("year(U.stop)", currAyear), QHS.CmpEq("EU.ayear", currAyear),
                    QHS.CmpEq("EU.adjustmentkind", "C"), QHS.CmpEq("ED.yentry", currAyear),
                    QHS.CmpEq("e.identrykind", 8),
                    QHS.CmpEq("U.idupb", idupb)
                ) +
                " AND A.flagaccountusage & 524288 = 0 ";  // Escludi da calcolo Commessa completata . Task 15404;

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
                " AND A.flagaccountusage & 524288 = 0 " +  // Escludi da calcolo Commessa completata . Task 15404"
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
                           " AND A.flagaccountusage & 524288 = 0 " +  // Escludi da calcolo Commessa completata . Task 15404
                           " group by ed.idupb, ed.idacc, EU.idacc_cost,EU.idaccmotive_cost," +
                           " EU.idacc_deferredcost, EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue," +
                           " EU.idacc_accruals, EU.idacc_deferredcost,EU.idaccmotive_accruals,year(U.stop),year(U.start),U.idepupbkind,U.title,U.codeupb   " +
                           " having " +
                           " -sum(ed.amount) <> 0 ";  
            DataTable t = Conn.SQLRunner(query, false,600);
            return t;
        }

 
        DataTable ottieniProgettiInChiusuraNoRateiAperti(object idupb) {
            int currAyear = (int)Meta.GetSys("esercizio");
            string strYear = QHS.quote(currAyear);

            string query = "select  -sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end) as cost," +
                           "sum(case when A.flagaccountusage & 128 <> 0 then ED.amount else 0 end) as revenue," +
                           "sum(case when A.flagaccountusage & 2048 <> 0 then ED.amount else 0 end) as reserve,"  +
                           "-sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) as accruals ," +
                           "year(U.stop) as yearstop, year(U.start) as yearstart,ed.idupb, ed.idacc as idacc_accruals,  " +
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
                           " and EU.ayear =" + strYear+    // prende la configurazione tipo UPB di quest'anno
                           " AND "+QHS.CmpEq("ED.idupb",idupb) +
                           " AND year(U.stop) = " + strYear + // UPB in scadenza quest'anno
                           " AND A.flagaccountusage & 524288 = 0 " +  // Escludi da calcolo Commessa completata . Task 15404
                           " group by ed.idupb, ed.idacc, EU.idacc_cost,EU.idaccmotive_cost," +
                           " EU.idacc_deferredcost, EU.idaccmotive_deferredcost, EU.idacc_revenue,EU.idaccmotive_revenue," +
                           " EU.idacc_accruals, EU.idacc_deferredcost,EU.idaccmotive_accruals,year(U.stop),year(U.start),U.idepupbkind,U.title,U.codeupb   " +
                           " having " +  // COSTI < RICAVI
                           "  -sum(case when A.flagaccountusage & (64+131072) <> 0 then ED.amount else 0 end)  <" +
                           "   sum(case when A.flagaccountusage & 128 <> 0 then ED.amount else 0 end) AND " + // NON HANNO RATEI APERTI
                           "  -sum(case when A.idacc = EU.idacc_accruals then ED.amount else 0 end) =  0";  
            DataTable t = Conn.SQLRunner(query, false,600);
            return t;
        }

    }
}
