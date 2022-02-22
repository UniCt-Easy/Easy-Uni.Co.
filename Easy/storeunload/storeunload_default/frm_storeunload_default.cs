
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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using ep_functions;
using stockmail;

namespace storeunload_default {
    public partial class frmstoreunload_default : MetaDataForm {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        public DataSet D;//usato per cancellare le scritture
        public frmstoreunload_default() {
            InitializeComponent();
        }
        bool booking_on_invoice;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            object Obooking_on_invoice = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "booking_on_invoice");
            if (Obooking_on_invoice == null || Obooking_on_invoice == DBNull.Value || Obooking_on_invoice.ToString() == "") Obooking_on_invoice = "N";
            booking_on_invoice = (Obooking_on_invoice.ToString().ToUpper()=="S");
            if (booking_on_invoice) {
                btnAggiungiDaMagazzino.Visible = false;
                btnScarichiImmediati.Visible = false;
            }
        }

        private void btnAggiungiDaPrenotazione_Click (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            DataRow Curr = DS.storeunload.Rows[0];
            if (CfgFn.GetNoNullInt32(Curr["idstore"]) == 0) {
                show("Selezionare prima il magazzino.");
                return;
            }

            string filter = CalculateFilterForLinking(true);
            FrmSelectDetailsFromBooking F = new FrmSelectDetailsFromBooking(Meta, filter, DS);
            if (F.ShowDialog(this) != DialogResult.OK) return;
            DataRow[] Selected = F.SelectedRows;
            if (Selected == null) return;
            if (Selected.Length == 0) return;
            MetaData MStoreUnloadDetail = MetaData.GetMetaData(this, "storeunloaddetail");
            MStoreUnloadDetail.SetDefaults(DS.storeunloaddetail);
            DataTable TStockView = Conn.CreateTableByName("stockview", "*");
            TStockView.PrimaryKey = new DataColumn[] { TStockView.Columns["idstock"] };

            string filtertouse;

            foreach (DataRow R in Selected) {  // riga di prenotazione
                decimal tounload = CfgFn.GetNoNullDecimal(R["allocated"]);

                string filterbooking = QHS.CmpEq("idbooking", R["idbooking"]);
                string filterbookingdetail = QHS.AppAnd(filterbooking,
                                             QHS.CmpEq("idlist", R["idlist"]));

                DataTable B = Meta.Conn.RUN_SELECT("bookingdetail", "*", null, filterbookingdetail, null, false);
                DataTable Bmain = Meta.Conn.RUN_SELECT("booking", "*", null, filterbooking, null, false);

                DataRow BookingDetail = null;

                string filterstock = QHS.AppAnd(QHS.CmpEq("idstore", R["idstore"]),
                                                      QHS.CmpEq("idlist", R["idlist"]),
                                                      QHS.CmpGt("residual", 0));
                string filterstockds = QHC.AppAnd(QHC.CmpEq("idstore", R["idstore"]),
                                                      QHC.CmpEq("idlist", R["idlist"]), 
                                                      QHC.CmpGt("residual", 0));

                if (booking_on_invoice) {
                    filterstock = QHS.AppAnd(filterstock, QHS.CmpEq("idstock", R["idstock"]));
                    filterstockds = QHC.AppAnd(filterstockds, QHC.CmpEq("idstock", R["idstock"]));
                }

                if (TStockView.Select(filterstockds).Length == 0) {
                    Conn.RUN_SELECT_INTO_TABLE(TStockView, "expiry asc, idstock asc", filterstock, null, true);
                }

                //Al massimo c'è una riga interessata perché stiamo filtrando idstock
                filtertouse = filterstockds;


                DataRow[] SViewRows = TStockView.Select(filtertouse, "expiry asc, idstock asc");
                //DataTable T = Meta.Conn.RUN_SELECT("stockview", "*", "expiry asc, idstock asc", filterstock, null, false);

                if (SViewRows.Length == 0) {
                    show("Non ho potuto aggiungere la riga di scarico relativa a:" + R["list"] + " perché non c'è giacenza sufficiente", "Errore");
                    continue;  //si riferisce ora al ciclo su dotry
                }
                DataRow RS;

                int i = 0;
                while (i < SViewRows.Length && tounload > 0) {
                    DataRow RStock = SViewRows[i];
                    decimal unloadable = CfgFn.GetNoNullDecimal(RStock["residual"]);
                    if (unloadable > tounload) {
                        unloadable = tounload;
                    }
                    string fbooking = filterbooking;
                    //devo scaricare unloadable
                    fbooking = QHC.AppAnd(fbooking, QHC.CmpEq("idstock", RStock["idstock"]));

                    if (DS.storeunloaddetail.Select(fbooking).Length > 0) {
                        RS = DS.storeunloaddetail.Select(fbooking)[0];
                        RS["number"] = CfgFn.GetNoNullDecimal(RS["number"]) + unloadable;
                    }
                    else {
                        RS = MStoreUnloadDetail.Get_New_Row(Curr, DS.storeunloaddetail);
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

                if (tounload > 0) {
                    show("Non ho potuto scaricare completamente la merce:" + R["list"] + " perché non c'è giacenza sufficiente", "Errore");
                }


            }
            Meta.FreshForm();
        }

        string CalculateFilterForLinking(bool SQL) {
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";

            object idstore = DS.storeunload.Rows[0]["idstore"];
            if (idstore!=DBNull.Value) MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idstore", idstore));
          
            return MyFilter;
        }


        public void MetaData_AfterFill () {
            btnAggiungiDaMagazzino.Enabled = true;
            btnAggiungiDaPrenotazione.Enabled = true;
            btnScarichiImmediati.Enabled = (DS.storeunloaddetail.Rows.Count==0);

            if (DS.storeunloaddetail.Rows.Count > 0) {
                cmbMagazzino.Enabled = false;
                SetLabel();
            }
            else {
                cmbMagazzino.Enabled = true;
            }
            GetData.CacheTable(DS.manager);

            if (Meta.FirstFillForThisRow && Meta.EditMode){
                VisualizzaEtichetteEP();
            }
        }

        void SetLabel() {
            if (DS.stockview.Select(QHC.CmpEq("authrequired", "S")).Length>0)
                lblAutorizzazione.Text = "Necessaria autorizzazione";
            else
                lblAutorizzazione.Text = "";
            }

        public void MetaData_AfterClear () {
            SetLabel();
            VisualizzaEtichetteEP();
            btnAggiungiDaMagazzino.Enabled = false;
            btnAggiungiDaPrenotazione.Enabled = false;
            btnScarichiImmediati.Enabled = false;
        }

        string idrelated = "";
        bool fromDelete = false;
        StoreUnloadSendMail SM;

        public void MetaData_BeforePost(){
            SM = null;
            if (DS.storeunload.Rows.Count == 0){
                return;
            }
            DataRow Curr = DS.storeunload.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                idrelated = GetIdForDocument(DS.storeunload.Rows[0]);
                fromDelete = true;
            }
            else {
                SM = new StoreUnloadSendMail(Conn);
                SM.PrepareMailToSend(DS);
            }
        }

        public void MetaData_AfterPost(){
            if (fromDelete) {
                cancellaScritture();
                idrelated = "";
                fromDelete = false;
            }
            else {
                if (SM!=null) SM.SendMail();
            }
        }

        private void cancellaScritture(){
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return;
            GetEntryForDocument(idrelated);

            foreach (DataRow rEntry in D.Tables["entry"].Rows){
                rEntry.Delete();
            }

            foreach (DataRow rEntryDetail in D.Tables["entrydetail"].Rows){
                rEntryDetail.Delete();
            }

            MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            PostData Post = MetaEntry.Get_PostData();

            Post.InitClass(D, Meta.Conn);
            if (!Post.DO_POST()){
                show(this, "Errore durante la cancellazione delle scritture in PD");
            }
        }

        public void GetEntryForDocument(string idrelated){
            D = new DataSet();
            string filterrelated = QHS.AppAnd(QHS.Like("idrelated", idrelated),
                    QHS.CmpEq("yentry", Meta.GetSys("esercizio")));
            DataTable T = Conn.RUN_SELECT("entry", "*", null, filterrelated, null, true);
            D.Tables.Add(T);
            if (T.Rows.Count == 0)
            {
                DataTable TT2 = Conn.CreateTableByName("entrydetail", "*");
                D.Tables.Add(TT2);
                D.Relations.Add("entryentrydetail",
                    new DataColumn[] { T.Columns["yentry"], T.Columns["nentry"] },
                    new DataColumn[] { TT2.Columns["yentry"], TT2.Columns["nentry"] }, false);
                return;
            }
            DataRow Entry = T.Rows[0];
            string key = QHS.CmpKey(Entry);
            string filtercurryeardetail = key;
            DataTable TT = Conn.RUN_SELECT("entrydetail", "*", null, filtercurryeardetail, null, true);
            D.Tables.Add(TT);
            D.Relations.Add("entryentrydetail",
                new DataColumn[] { T.Columns["yentry"], T.Columns["nentry"] },
                new DataColumn[] { TT.Columns["yentry"], TT.Columns["nentry"] }, false);

            DataTable TT3 = Conn.RUN_SELECT("entrydetailaccrual", "*", null, filtercurryeardetail, null, true);
            D.Tables.Add(TT3);
            D.Relations.Add("entrydetailentrydetailaccrual",
                new DataColumn[] { TT.Columns["yentry"], TT.Columns["nentry"], TT.Columns["ndetail"] },
                new DataColumn[] { TT3.Columns["yentry"], TT3.Columns["nentry"], TT3.Columns["ndetail"] },
                false);
            if (TT3.Rows.Count > 0)
            {
                show("Ci sono ratei associati alle scritture che saranno scollegati. Sarà " +
                    "necessario ricollegarli a mano");
                foreach (DataRow R3 in TT3.Rows) R3.Delete();
            }
        }

        private void btnAggiungiDaMagazzino_Click (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            DataRow Curr = DS.storeunload.Rows[0];
            if (CfgFn.GetNoNullInt32(Curr["idstore"]) == 0) {
                show("Selezionare prima il magazzino.");
                return;
            }

            string filter = CalculateFilterForLinking(true);
            FrmSelectDetailsFromStock F = new FrmSelectDetailsFromStock(Meta, filter, DS);
            



            if (F.ShowDialog(this) != DialogResult.OK) return;
            object idsor1 = DBNull.Value;
            if (F.CSM1 != null) idsor1 = F.CSM1.GetValue();
            if (idsor1 == null) idsor1 = DBNull.Value;
            object idsor2 = DBNull.Value;
            if (F.CSM2 != null) idsor2 = F.CSM2.GetValue();
            if (idsor2 == null) idsor2 = DBNull.Value;
            object idsor3 = DBNull.Value;
            if (F.CSM3 != null) idsor3 = F.CSM3.GetValue();
            if (idsor3 == null) idsor3 = DBNull.Value;

            decimal quantita = F.quantita;
            object idman = F.idman;
            DataRow rStock = F.RStock;
            scaricaQuantita(rStock["idstore"], rStock["idlist"], quantita, idman, idsor1, idsor2, idsor3);
            Meta.FreshForm();
        }


        private void scaricaQuantita(object idstore, object idlist, decimal q, object idman,object idsor1,object idsor2,object idsor3)
        {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.storeunload.Rows[0];

            if (idman == null) idman = DBNull.Value;
            if (q == 0) return;
            //Allora, devi fare innanzitutto una query su stock per beccarti 
            //tutte le righe che hanno del disponibile da scaricare.
            string field_to_consider;

            if (booking_on_invoice) {
                field_to_consider = "available";
            }
            else {
                field_to_consider = "residual";
            }


            string filter = QHS.AppAnd(QHS.CmpEq("idstore",  idstore),
                                       QHS.CmpEq("idlist", idlist),
                                       QHS.CmpGt(field_to_consider, 0));

            DataTable Stockview = Conn.RUN_SELECT("stockview", null, "expiry asc, idstock asc", filter, null, true);
            string filteridman = QHC.AppAnd(QHC.CmpEq("idman", idman), QHC.CmpEq("idsor1", idsor1), QHC.CmpEq("idsor2", idsor2), QHC.CmpEq("idsor3", idsor3));
            foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Select(filteridman)) {
                if (rDetail.RowState != DataRowState.Deleted) continue;
                rDetail.RejectChanges();
                decimal number = CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Original]);
                decimal residual = 0;

                DataRow[] RStock = Stockview.Select(QHC.CmpEq("idstock", rDetail["idstock"]));
                if (RStock.Length == 0) continue;
                if ((RStock.Length > 0) && (RStock[0]["idlist"].ToString() != idlist.ToString()) ) continue;

                if (RStock.Length > 0) residual = CfgFn.GetNoNullDecimal(RStock[0][field_to_consider]);
               
                decimal available = number + residual;

                if (available >= q) {
                    rDetail["number"] = q;
                    q = 0;
                }
                else {
                    rDetail["number"] = available;
                    q = q - available;
                }
                if (RStock.Length > 0) RStock[0].Delete();
            }

            foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Select(filteridman)) {
                if (q == 0) break;
                if ((rDetail.RowState != DataRowState.Modified)&&
                   (rDetail.RowState  != DataRowState.Unchanged))
                    continue;
                decimal number_prev = CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Original]);
                decimal number_curr = CfgFn.GetNoNullDecimal(rDetail["number", DataRowVersion.Current]);
                decimal residual = 0;

                DataRow[] RStock = Stockview.Select(QHC.CmpEq("idstock", rDetail["idstock"]));
                if (RStock.Length == 0) continue;

                if ((RStock.Length > 0) && (RStock[0]["idlist"].ToString() != idlist.ToString())) continue;

                if (RStock.Length > 0) residual = CfgFn.GetNoNullDecimal(RStock[0][field_to_consider]);

                decimal available = number_prev + residual - number_curr;
                if (available >= q) {
                    rDetail["number"] = CfgFn.GetNoNullDecimal(rDetail["number"]) + q;
                    q = 0;
                }
                else {
                    rDetail["number"] = CfgFn.GetNoNullDecimal(rDetail["number"])+ available;
                    q = q - available;
                }
                if (RStock.Length > 0) RStock[0].Delete();
            }

            foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Select(filteridman)) {
                if (q == 0) break;
                if (rDetail.RowState != DataRowState.Added) continue;
                decimal number_curr = CfgFn.GetNoNullDecimal(rDetail["number"]);
                decimal residual = 0;

                DataRow[] RStock = Stockview.Select(QHC.CmpEq("idstock", rDetail["idstock"]));
                if (RStock.Length == 0) continue;
                if ((RStock.Length > 0) && (RStock[0]["idlist"].ToString() != idlist.ToString())) continue;


                if (RStock.Length > 0) residual = CfgFn.GetNoNullDecimal(RStock[0][field_to_consider]);
               
                decimal available = residual - number_curr ;
                if (available >= q) {
                    rDetail["number"] = CfgFn.GetNoNullDecimal(rDetail["number"])+ q;
                    q = 0;
                    
                }
                else {
                    rDetail["number"] = CfgFn.GetNoNullDecimal(rDetail["number"]) + available;
                    q = q - available;
                }
                if (RStock.Length > 0) RStock[0].Delete();
            }

            Stockview.AcceptChanges();

            foreach (DataRow R in Stockview.Select()) {

                
                // Righe non collegate a nessuna riga in memoria
                if (q == 0) break;
                decimal available = CfgFn.GetNoNullDecimal(R[field_to_consider]);
                MetaData MetaDetail = Meta.Dispatcher.Get("storeunloaddetail");
                MetaDetail.SetDefaults(DS.storeunloaddetail);
                DataRow RNew = MetaDetail.Get_New_Row(Curr, DS.storeunloaddetail);
                RNew["idstock"] = R["idstock"];
                RNew["idman"] = idman;
                RNew["idsor1"] = idsor1;
                RNew["idsor2"] = idsor2;
                RNew["idsor3"] = idsor3;

                if (available >= q) {
                    RNew["number"] = q;
                    q = 0;
                }
                else {
                    RNew["number"] = available;
                    q = q - available;
                }
            }
            // fare un ciclo di storeunload detail per cancellare quelle con il number pari a 0
            foreach (DataRow rDetail in DS.Tables["storeunloaddetail"].Select(filteridman)) {
                decimal number = CfgFn.GetNoNullDecimal(rDetail["number"]);
                if (number == 0) rDetail.Delete();
            }
        }

        //private void btnGeneraEP_Click(object sender, EventArgs e){

        //}

        private void btnVisualizzaEP_Click(object sender, EventArgs e){
            if (DS.storeunload.Rows.Count == 0) return;
            EditRelatedEntry(DS.storeunload.Rows[0] );
        }


        public void EditRelatedEntry(DataRow Curr){
            MetaData ToMeta = Meta.Dispatcher.Get("entry");
            if (ToMeta == null) return;
            string idrelated = GetIdForDocument(Curr);

            string checkfilter = QHS.Like("idrelated", idrelated);
            checkfilter = QHS.AppAnd(checkfilter, QHS.CmpEq("yentry", Meta.GetSys("esercizio")));
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }

        string GetIdForDocument(DataRow R){
            if (R==null) return null;
			DataRowVersion toConsider = DataRowVersion.Current;
			if (R.RowState == DataRowState.Deleted) toConsider = DataRowVersion.Original;
            string idrelated = "storeunloaddetail" + "§" + R["idstoreunload", toConsider].ToString() + "§" + "%";
            return idrelated;
        }

        void VisualizzaEtichetteEP(){
            if (Meta.InsertMode || DS.storeunload.Rows.Count == 0 ){
                btnVisualizzaEP.Visible = false;
                labEPnongenerato.Visible = false;
                labEPgenerato.Visible = false;
                return;
            }

            string idrelated = GetIdForDocument(DS.storeunload.Rows[0]);
            if (Meta.Conn.RUN_SELECT_COUNT("entry", QHS.Like("idrelated", idrelated), true) == 0){
                labEPnongenerato.Visible = true;
                labEPgenerato.Visible = false;
                btnVisualizzaEP.Visible = false;
            }
            else{
                labEPnongenerato.Visible = false;
                labEPgenerato.Visible = true;
                btnVisualizzaEP.Visible = true;
            }
        }

        private void btnScarichiImmediati_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            DataRow Curr = DS.storeunload.Rows[0];
            if (CfgFn.GetNoNullInt32(Curr["idstore"]) == 0) {
                show("Selezionare prima il magazzino.");
                return;
            }

            string filter = CalculateFilterForLinking(true);
            filter = QHS.AppAnd(filter, QHS.CmpEq("flagto_unload", "S"), QHS.CmpGt("residual", 0));


            DataTable Stockview = Conn.RUN_SELECT("stockview", null, "expiry asc, idstock asc", filter, null, true);

            foreach (DataRow R in Stockview.Select()) {
                decimal available = CfgFn.GetNoNullDecimal(R["residual"]);
                MetaData MetaDetail = Meta.Dispatcher.Get("storeunloaddetail");
                MetaDetail.SetDefaults(DS.storeunloaddetail);
                DataRow RNew = MetaDetail.Get_New_Row(Curr, DS.storeunloaddetail);
                RNew["idstock"] = R["idstock"];
                RNew["idman"] = GetIDManForUnload(R);
                RNew["number"] = available;
            }

            Meta.FreshForm();
        }

        object GetIDManForUnload(DataRow Stock) {
            if (Stock["idmankind"] == DBNull.Value) return DBNull.Value;
            string filter = QHS.MCmp(Stock, "idmankind", "yman", "nman");
            object O = Conn.DO_READ_VALUE("mandate", filter, "idman");
            if (O == null) return DBNull.Value; 
                //qui andrebbe aggiunta un domani la gestione del responsabile su fattura ove presente
            return O;
        }


    }
}
