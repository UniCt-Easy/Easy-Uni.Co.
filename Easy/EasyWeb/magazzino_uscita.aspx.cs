
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using metadatalibrary;
using metaeasylibrary;
using HelpWeb;
using System.IO;
using AllDataSet;
using funzioni_configurazione;
using stockmail;

namespace EasyWebReport {
    public partial class magazzino_uscita : System.Web.UI.Page {


        void ConnectToDepartment(string codice, string user, string pwd, DateTime datacontabile) {
            string error;
            DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);

            if (codice.Trim().Length == 0) {
                labExtMessage.Text = "Non è stato selezionato alcun dipartimento";
                return;
            }
            //Attenzione: leggere da XML IP del server e NomeDB
            //Inserire da codice NomeUtente e Password
            string filterdip = "(codicedipartimento=" + QueryCreator.quotedstrvalue(codice, true) + ")";
            DataTable CodDip = Conn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);

            if ((CodDip == null) || (CodDip.Rows.Count == 0)) {
                //Dati non corretti
                WebLog.Log(this, codice + ": Codice non corretto");
                labExtMessage.Text = "Il codice inserito non è corretto.";
                return;
            }
            if (CodDip.Rows.Count > 1) {
                //Attenzione nel DB non è garantita l'unicità dei dati.
                labExtMessage.Text = "Chiedere al Responsabile del servizio " +
                    "l'assegnazione di un nuovo Codice";
                WebLog.Log(this, "Attenzione !!! Duplicazione di codici per " + codice);
                return;
            }

            string err = "";
            DataRow myDr = CodDip.Rows[0];
            Session["Dipartimento"] = myDr["Dipartimento"].ToString();


            //Creo la connessione.
            DataAccess UsrConn = GetVars.CreateUserConn(this, myDr, user, pwd, datacontabile, out err);
            if (UsrConn == null) {
                err = "Connessione per l'utente '" + user + "' rifiutata. Controllare Nome Utente e/o Password";
                string err2 = "Connessione al db del dipartimento " + codice +
                    " non riuscita. <br/>" + err;
                labExtMessage.Text = err2;
                WebLog.Log(this, err2);
                return;
            }

        }

        bool error_dep = false;
        protected void Page_Load(object sender, EventArgs e) {
            //Master.SetTitle("WebEasy - Accesso Servizi Dipartimento  ");
            lblMessaggio.Text = "";
            labExtMessage.Text = "";
            error_dep = false;
            if (!Page.IsPostBack || Page.Session.IsNewSession) {
                Session["utente"] = "";
                Session["Responsabile"] = "";
                Session["Fornitore"] = "";
                Session["CodiceResponsabile"] = null;
                Session["CodiceFornitore"] = null;
            }
            if (Request!= null) {
                if (Request.Params["x"] != null && Request.Params["x"].ToString() != "") {
                    Session["DepCode"] = Request.Params["x"];
                }
            }
            if (Session["DepCode"] == null || Session["DepCode"].ToString() == "") {
                lblMessaggio.Text = "E' necessario chiamare la pagina magazzino_out.aspx con il parametro dep=codice dipartimento";
                WebLog.Log(this, "Parametro dep non fornito.");
                error_dep = true;
                return;

            }

            //if (Session["DoLogon"] == null || !((bool)Session["DoLogon"])) {
            //    lblMessaggio.Text = "Applicazione non inizializzata correttamente.";
            //    WebLog.Log(this, "Applicazione non inizializzata correttamente.");
            //    return;
            //}

            DataSet Cfg = GetVars.GetConfigDataSet(this);
            if (Cfg.Tables[0].Rows.Count == 0) {
                lblMessaggio.Text = "Servizio non installato correttamente. Manca il file di configurazione.";
                WebLog.Log(this, "Connessione al db di sistema non riuscita.");
                return;
            }
            MetaMaster MM = Master as MetaMaster;
            //if (MM != null) MM.ShowClientMessage("NINO", false);

            string error;

            DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);
            if (Conn == null) {
                //lblMessaggio.Text = "Connessione al DB di sistema non riuscita." + error;
                //Attenzione qui l'errore contiene la password del Database !
                lblMessaggio.Text = "Connessione al DB di sistema non riuscita.";
                WebLog.Log(this, "Connessione al db di sistema non riuscita.");
                return;
            }
            lblMessaggio.Text = "Il servizio Web è attivo";
            GetVars.ClearUserConn(this);

           




        }

        void ScaricaPrenotazione(DataAccess Conn, string idbooking) {
            vistaform_storeunload_magazzino DS = new vistaform_storeunload_magazzino();
            CQueryHelper QHC = new CQueryHelper();

            QueryHelper QHS = Conn.GetQueryHelper();

            //WebLog.Log(this, "Visualizza Login_Servizi");
            object Obooking_on_invoice = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "booking_on_invoice");
            if (Obooking_on_invoice == null || Obooking_on_invoice == DBNull.Value || Obooking_on_invoice.ToString() == "") Obooking_on_invoice = "N";
            Obooking_on_invoice = Obooking_on_invoice.ToString().ToUpper();
            bool booking_on_invoice = (Obooking_on_invoice.ToString() == "S");




            DataTable BookingToUnload = Conn.RUN_SELECT("booktotalview", "*", null,
                    QHS.AppAnd(QHS.CmpGt("allocated", 0), QHS.CmpEq("idbooking", idbooking)), null, true);

            DataTable TStockView = Conn.CreateTableByName("stockview", "*");
            TStockView.PrimaryKey = new DataColumn[] { TStockView.Columns["idstock"] };

            Meta_EasyDispatcher Disp = new Meta_EasyDispatcher(Conn);

            MetaData MetaStoreUnload = Disp.Get("storeunload");
            MetaStoreUnload.SetDefaults(DS.storeunload);
            MetaData MetaStoreUnloadDetail = Disp.Get("storeunloaddetail");
            MetaStoreUnloadDetail.SetDefaults(DS.storeunloaddetail);


            DataRow[] Selected = BookingToUnload.Select();
            if (Selected.Length == 0) {
                //niente da scaricare
                lblMessaggio.Text = "Non c'è nulla da scaricare";
                txtCodice.Text = "";
                return;
            }

            DataRow RStoreUnload = MetaStoreUnload.Get_New_Row(null, DS.storeunload);
            RStoreUnload["description"] = "Scarico prenotazione da magazzino";
            RStoreUnload["idstore"] = Selected[0]["idstore"];
            RStoreUnload["adate"] = DateTime.Now;

            Hashtable idlistToStock = new Hashtable();//l'elemento della hashtable è un list<int>
            //Prende una riga di prenotazione 
            foreach (DataRow R in Selected) {  // riga di prenotazione
                string filterbooking = QHS.CmpEq("idbooking", R["idbooking"]);
                string filterbookingdetail = QHS.AppAnd(filterbooking,
                                             QHS.CmpEq("idlist", R["idlist"]));

                DataTable B = Conn.RUN_SELECT("bookingdetail", "*", null, filterbookingdetail, null, false);
                DataTable Bmain = Conn.RUN_SELECT("booking", "*", null, filterbooking, null, false);

                DataRow BookingDetail = null;


                string filterstock = QHS.AppAnd(QHS.CmpEq("idstore", R["idstore"]),
                                                     QHS.CmpEq("idlist", R["idlist"]),
                                                     QHS.CmpGt("residual", 0));
                string filterstockds = QHC.AppAnd(QHC.CmpEq("idstore", R["idstore"]),
                                                      QHC.CmpEq("idlist", R["idlist"]),
                                                      QHC.CmpGt("residual", 0));


                //legge in TStockView i cespiti di stock disponibili ad essere scaricati

                if (booking_on_invoice) {
                    filterstock = QHS.AppAnd(filterstock, QHS.CmpEq("idstock", R["idstock"]));
                    filterstockds = QHC.AppAnd(filterstockds, QHC.CmpEq("idstock", R["idstock"]));
                }
                
                if (TStockView.Select(filterstockds).Length == 0) {
                    Conn.RUN_SELECT_INTO_TABLE(TStockView, "expiry asc, idstock asc", filterstock, null, true);
                }

                ///SViewRows = cespiti disponibili (da stockview) allo scarico 
                DataRow[] SViewRows = TStockView.Select(filterstockds);
                if (SViewRows.Length == 0) continue;

                DataRow RS;
                decimal tounload = CfgFn.GetNoNullDecimal(R["allocated"]);

                int i = 0;
                //Cerca di scaricare prendendo le righe in SViewRows
                while (i < SViewRows.Length && tounload > 0) {
                    DataRow RStock = SViewRows[i];
                    decimal unloadable = CfgFn.GetNoNullDecimal(RStock["residual"]);
                    if (unloadable > tounload) {
                        unloadable = tounload;
                    }
                    //devo scaricare unloadable
                    string fbooking = filterbooking;


                    //devo scaricare unloadable
                    fbooking = QHC.AppAnd(fbooking, QHC.CmpEq("idstock", RStock["idstock"]));

                    //cerca una riga in storeunloaddetail di pari idstock e idbooking (idstock è sempre noto a questo punto)
                    if (DS.storeunloaddetail.Select(fbooking).Length > 0) {
                        RS = DS.storeunloaddetail.Select(fbooking)[0];
                        RS["number"] = CfgFn.GetNoNullDecimal(RS["number"]) + unloadable;
                    }
                    else {
                        RS = MetaStoreUnloadDetail.Get_New_Row(DS.storeunload.Rows[0], DS.storeunloaddetail);
                        RS["number"] = unloadable;
                        RS["idbooking"] = R["idbooking"];
                        // Determino idstock
                        // io ho una serie di di idlist e idstore 
                        // in base ai dettagli selezionati mi servono 
                        // per accedere alla vista delle giacenze di stock e creo 
                        // una tabella che deve essere filtrata per idlist 
                        // idstore e giacenza > 0
                        RS["idstock"] = RStock["idstock"];//T.Rows[0]["idstock"];
                        if (B.Rows.Count > 0) {
                            BookingDetail = B.Rows[0];
                            RS["idsor1"] = BookingDetail["idsor1"];
                            RS["idsor2"] = BookingDetail["idsor2"];
                            RS["idsor3"] = BookingDetail["idsor3"];
                            RS["idman"] = Bmain.Rows[0]["idman"];
                        }
                    }
                    tounload -= unloadable;
                    RStock["residual"] = CfgFn.GetNoNullDecimal(RStock["residual"]) - unloadable;
                    i++;
                }


            }
            StoreUnloadSendMail SUSM = new StoreUnloadSendMail(Conn);
            SUSM.PrepareMailToSend(DS);

            Easy_PostData EP = new Easy_PostData();
            EP.InitClass(DS, Conn);
            ProcedureMessageCollection PC = EP.DO_POST_SERVICE();
            if (PC.Count>0){
                string err = "";
                foreach (EasyProcedureMessage PM in PC) {
                    err += PM.AuditID + "/" + PM.TableName + "/" + PM.Operation + "/" + PM.EnforcementNumber + "(" + PM.LongMess + ") ";
                }
                string data = "";
                foreach (DataRow r in DS.storeunloaddetail.Rows) {
                    data += "[idstock=" + r["idstock"].ToString() + ",number=" + r["number"].ToString() + ",idbooking=" + r["idbooking"].ToString() +
                            ",idman=" + r["idman"].ToString() + "] ";        
                }
                lblMessaggio.Text = "Errore in fase di salvataggio dati: "+err+" Data: "+data;
                GetVars.ClearUserConn(this);

            }
            else {
                EP.DO_POST_SERVICE();
                DataRow Curr = DS.storeunload.Rows[0];
                StampaReport(Conn, CfgFn.GetNoNullInt32(Curr["idstoreunload"]));
                SUSM.SendMail();
                lblMessaggio.Text = "Scarico effettuato.";
                txtCodice.Text = "";

            }

        }


        string CalculateFilterForLinking(bool SQL, DataAccess Conn, object idstore) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";
            if (idstore != DBNull.Value) MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idstore", idstore));

            return MyFilter;
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) {
            if (error_dep) return;

            string error;
            DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);
            if (Conn == null) return;

            DateTime D = DateTime.Now;

            object Onedip = Session["DepCode"];
            if (Onedip == null) {
                MetaPage.SessionTimeOut(this);
                return;
            }
            //Onedip = "amministrazione";

            ConnectToDepartment(Onedip.ToString(), null, null, D);
            Easy_DataAccess UsrConnTemp = GetVars.GetUserConn(this);
            if (UsrConnTemp==null || UsrConnTemp.Open() == false) {
                //Il Server del Dipartimento non è in rete. 
                //Il servizio non è disponibile in quanto il computer potrebbe essere spento.
                labExtMessage.Text = "Il Server del Dipartimento "+Onedip.ToString() +" non risponde.\r" +
                    "Potrebbe essere spento o momentaneamente fuori rete. \r" +
                    "Provi in seguito";
                txtCodice.ReadOnly = true;
                WebLog.Log(this, "Il Server del dipartimento " + Onedip.ToString() + "non risponde.");
                return;
            }



            DataSet DDecode = UsrConnTemp.CallSP("calc_bookingid", new object[] { txtCodice.Text }, true);
            UsrConnTemp.Close();
            if (DDecode == null || DDecode.Tables.Count == 0) {
                lblMessaggio.Text = "Errore nel contattare il dipartimento o codice errato.";
                return;
            }

            DataTable TDecode = DDecode.Tables[0];
            if (TDecode.Rows.Count == 0) {
                lblMessaggio.Text = "Errore nel contattare il dipartimento  o codice errato.";
                return;
            }

            DataRow RCode = TDecode.Rows[0];
            if (RCode["iddep"].ToString() == "") {
                lblMessaggio.Text = "Errore nella lettura del codice a barre";
                txtCodice.Text = "";
                return;

            }
            string depcode = RCode["iddep"].ToString();
            string idbooking = RCode["idbooking"].ToString();

            ConnectToDepartment(depcode, null, null, D);

            Easy_DataAccess UsrConn = GetVars.GetUserConn(this);
            if (UsrConn==null || UsrConn.Open() == false) {
                //Il Server del Dipartimento non è in rete. 
                //Il servizio non è disponibile in quanto il computer potrebbe essere spento.
                labExtMessage.Text = "Il Server del Dipartimento "+depcode+" non risponde.\r" +
                    "Potrebbe essere spento o momentaneamente fuori rete. \r" +
                    "Provi in seguito";
                txtCodice.ReadOnly = true;
                WebLog.Log(this, "Il Server del dipartimento " + depcode + "non risponde.");
                return;
            }

            labExtMessage.Text = "Connessione al server effettuata.";



            ScaricaPrenotazione(UsrConn, idbooking);


        }


        void StampaReport(DataAccess Conn, int idstoreunload) {
            //Crea un datatable con i parametri per la stampa
            string error;
            DataTable T = new DataTable("tabella");
            T.Columns.Add("idstoreunload", typeof(int));
            DataRow R = T.NewRow();
            R["idstoreunload"] = idstoreunload;
            T.Rows.Add(R);
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable Modulereport = Conn.RUN_SELECT("report", "*", null, QHS.CmpEq("reportname", "rpt_uscitamagazzino"), null, true);


            /*
            DataTable T = new DataTable("tabella");
            T.Columns.Add("ayear", typeof(int));
            DataRow R = T.NewRow();
            R["ayear"] = 2011;
            T.Rows.Add(R);
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable Modulereport = Conn.RUN_SELECT("report", "*", null, QHS.CmpEq("reportname", "avanzocassapresunto"), null, true);
            */



            Session["UserPar"] = T;
            Session["ModuleReportRow"] = Modulereport.Rows[0];
            Session["PageToCameBack"] = this.Request.Url;

            string F = "window.open('WebPDFView.aspx');";
            if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
                 Page.ClientScript.RegisterClientScriptBlock(
                        typeof(Page), "openwin", F, true);
            txtCodice.Text = "";


        }
    }
}
