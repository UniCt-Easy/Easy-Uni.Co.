/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace stockmail {
    public class StockItem {
        public int idlist;
        public int idstore;

        public StockItem(int idlist, int idstore) {
            this.idlist = idlist;
            this.idstore = idstore;
        }
        public string GetKey() {
            return idlist.ToString() + "-" + idstore.ToString();
        }
    }

    public class StockBooking {
        public int idlist;
        public int idstore;
        public int idbooking;
        public decimal number;

        public StockBooking(int idlist, int idstore, int idbooking, decimal number) {
            this.idlist = idlist;
            this.idstore = idstore;
            this.idbooking = idbooking;
            this.number = number;
        }
    }


    public class StockMail {
        ArrayList StockBookingList; //contiene StockBooking
        DataRow bookdetail;
        string email;
        public StockMail(string email, DataRow bookdetail) {
            StockBookingList = new ArrayList();
            this.email = email;
            this.bookdetail = bookdetail;
        }

        public void AddItem(StockBooking Stoadd) {
            foreach (StockBooking S in StockBookingList) {
                if (S.idlist == Stoadd.idlist && S.idstore == Stoadd.idstore && S.idbooking == Stoadd.idbooking) {
                    S.number += Stoadd.number;
                    return;
                }
            }
            StockBookingList.Add(Stoadd);
        }
        public string GetMsgBody(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            string S = "Messaggio dalla gestione magazzino\r\n";
            S += "E' presente in magazzino della merce che era stata prenotata.\r\n";
            Hashtable Mag = new Hashtable();
            //organizza la merce raggruppandola per magazzino
            foreach (StockBooking SB in StockBookingList) {
                if (Mag[SB.idstore] == null) Mag[SB.idstore] = SB.idstore;
            }
            int nstore = Conn.RUN_SELECT_COUNT("store", null, false);
            foreach (object idstore in Mag.Values) {
                object StoreName = Conn.DO_READ_VALUE("store", QHS.CmpEq("idstore", idstore), "description");
                if (nstore > 1) S += "Magazzino: " + StoreName + "\r\n";
                foreach (StockBooking SB in StockBookingList) {
                    object itemname = Conn.DO_READ_VALUE("list", QHS.CmpEq("idlist", SB.idlist), "description");
                    S += "Articolo: " + itemname.ToString();
                    if (SB.number != 1) S += " (quantit‡: " + SB.number.ToString() + ")";
                    S += "\r\n";
                }
                S += "\r\n\r\n";
            }
            return S;
        }

        public void UpdateMailSent(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            foreach (StockBooking SB in StockBookingList) {
                string update = "update booktotal set lastmail= allocated where " +
                     QHS.AppAnd(QHS.CmpEq("idstore", SB.idstore), QHS.CmpEq("idlist", SB.idlist), QHS.CmpEq("idbooking", SB.idbooking));
                Conn.SQLRunner(update);
            }
        }


        public static string GetErrorMailAddress(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object email = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "email");
            if (email == null) email = DBNull.Value;
            return email.ToString();
        }

        public bool SendMail(DataAccess Conn) {
            SendMail SM = new SendMail();
            SM.UseSMTPLoginAsFromField = true;
            if (email != "@@@") {
                SM.To = email;
                SM.Subject = "Notifica di arrivo merce in magazzino";
            }
            else {
                SM.To = GetErrorMailAddress(Conn);
                SM.Subject = "EMAIL NON INVIATA per mancanza indirizzo email: Notifica di arrivo merce in magazzino";
            }
            SM.MessageBody = GetMsgBody(Conn);
            SM.Conn = Conn;
            if (!SM.Send()) {
                if (SM.ErrorMessage.Trim() != "")
                    MessageBox.Show(SM.ErrorMessage, "Errore");
                return false;
                //ShowClientMessage(SM.ErrorMessage, "Errore");
            }
            return true;
        }
    }

    /// <summary>
    /// Classe che si occupa di mandare la mail  a chi ha fatto prenotazioni quando arriva la merce in magazzino.
    /// </summary>
    public class StockSendMail {
        DataAccess Conn;
        Hashtable Stock = new Hashtable(); //contiene StockItem

        Hashtable Mails = new Hashtable(); //contiene StockMail
        QueryHelper QHS;

        public StockSendMail(DataAccess Conn) {
            this.Conn = Conn;
            this.QHS = Conn.GetQueryHelper();
        }

        public void getItemsFromInvoice(DataRow InvoiceDetail) {
            DataTable T = Conn.RUN_SELECT("stock", "*", null,
                QHS.AppAnd(QHS.CmpEq("idinvkind", InvoiceDetail["idinvkind"]),
                            QHS.CmpEq("yinv", InvoiceDetail["yinv"]),
                             QHS.CmpEq("ninv", InvoiceDetail["ninv"]),
                              QHS.CmpEq("inv_idgroup", InvoiceDetail["idgroup"])), null, false);
            foreach (DataRow R in T.Rows)
                AddStockItem(R["idstore"], R["idlist"]);

        }
        public void getItemsFromDDT_IN(DataRow DDT_IN) {
            DataTable T = Conn.RUN_SELECT("stock", "*", null,
                        QHS.CmpEq("idddt_in", DDT_IN["idddt_in"]), null, false);
            foreach (DataRow R in T.Rows)
                AddStockItem(R["idstore"], R["idlist"]);

        }
        public void getItemsFromStock(DataRow Stock) {
            AddStockItem(Stock["idstore"], Stock["idlist"]);
        }

        void AddStockItem(object idstore, object idlist) {
            StockItem S = new StockItem(CfgFn.GetNoNullInt32(idlist), CfgFn.GetNoNullInt32(idstore));
            if (Stock[S.GetKey()] != null) return;
            Stock[S.GetKey()] = S;
        }


        /// <summary>
        /// In base al contenuto di StockItem, crea un elenco di mail da mandare ai vari destinatari
        /// </summary>
        void CompileStockMail() {

            Mails = new Hashtable();
            foreach (StockItem S in Stock.Values) {
                string filterBookTotal = QHS.AppAnd(QHS.CmpEq("idlist", S.idlist), QHS.CmpEq("idstore", S.idstore),
                        QHS.CmpNe("isnull(lastmail,0)", QHS.Field("allocated"))
                    );
                DataTable T = Conn.RUN_SELECT("booktotal", "*", null, filterBookTotal, null, true);
                foreach (DataRow R in T.Rows) {
                    //idlist, idstore, idbookimg, number, allocated, lastmail
                    //prende l'idcustomuser da booking
                    int idbooking = CfgFn.GetNoNullInt32(R["idbooking"]);
                    //prende la riga da bookdetail 
                    string filterbookdetail = QHS.AppAnd(QHS.CmpEq("idlist", S.idlist),
                                            QHS.CmpEq("idstore", S.idstore),
                                                    QHS.CmpEq("idbooking", idbooking));
                    DataTable BookDetail = Conn.RUN_SELECT("bookingdetail", "*", null, filterbookdetail, null, true);
                    if (BookDetail.Rows.Count == 0) continue;
                    DataRow bookdetail = BookDetail.Rows[0];
                    string email = Conn.DO_READ_VALUE("booking", QHS.CmpEq("idbooking", idbooking), "email").ToString();
                    if (email.ToString() == "") {
                        email = "@@@";
                    }
                    decimal diff = CfgFn.GetNoNullDecimal(R["allocated"]) - CfgFn.GetNoNullDecimal(R["lastmail"]);
                    StockMail SMail = Mails[email] as StockMail;
                    if (SMail == null) {
                        SMail = new StockMail(email, bookdetail);
                        Mails[email] = SMail;
                    }
                    SMail.AddItem(new StockBooking(S.idlist, S.idstore, idbooking, diff));
                }

            }

        }

        public void SendMailToBookers() {
            CompileStockMail();
            foreach (StockMail SM in Mails.Values) {

                if (SM.SendMail(Conn)) {
                    SM.UpdateMailSent(Conn);
                }
            }

        }
    }
    public class MailToSend {
        public string obj;
        public string message;
        public string email;
        public MailToSend(string obj, string message, string email) {
            this.obj = obj;
            this.message = message;
            this.email = email;
        }
    }

    /// <summary>
    /// Classe che si occupa di mandare la mail  al magazziniere e ai responsabili quando sono inserite nuove richieste
    /// </summary>
    public class BookingSendMail {
        DataAccess Conn;
        QueryHelper QHS;

        ArrayList MailList; //of SendMail

        public BookingSendMail(DataAccess Conn) {
            this.Conn = Conn;
            this.QHS = Conn.GetQueryHelper();
        }
        

         
        public void PrepareMailToSend(DataSet DS) {
            MailList = new ArrayList();
            if (!DS.Tables.Contains("booking")) return;
            if (!DS.Tables.Contains("bookingdetail")) return;
            DataTable Booking = DS.Tables["booking"];
            DataTable BookingDetail = DS.Tables["bookingdetail"];
            if (Booking.Select().Length == 0) return;
            DataRow Rb = DS.Tables["booking"].Rows[0];
            object idman = Rb["idman"];
            string manager_email = "";
            if (idman != DBNull.Value) manager_email = Conn.DO_READ_VALUE("manager", QHS.CmpEq("idman", idman), "email").ToString();
            string to_auth = "";
            if (manager_email != "") {
                foreach (DataRow Rbd in BookingDetail.Select()) {
                    if (Rbd.RowState == DataRowState.Unchanged) continue;
                    //Delle modified prende solo quelle da autorizzare
                    if (Rbd.RowState == DataRowState.Modified && Rbd["authorized", DataRowVersion.Current].ToString() != "") continue;

                    if (Rbd["idlist"].ToString() == "") continue;
                    //Deve verificare se la merce richiesta necessita autorizzazione
                    DataTable List = Conn.RUN_SELECT("list", "*", null, QHS.CmpEq("idlist", Rbd["idlist"]), null, false);
                    if (List.Rows.Count == 0) continue;
                    DataRow RLis = List.Rows[0];
                    if (RLis["idlistclass"].ToString() == "") continue;
                    DataTable ListClass = Conn.RUN_SELECT("listclass", "*", null, QHS.CmpEq("idlistclass", RLis["idlistclass"]), null, false);
                    if (ListClass.Rows.Count == 0) continue;
                    DataRow RLisClass = ListClass.Rows[0];
                    if (RLisClass["authrequired"].ToString().ToUpper() != "S") continue;
                    if (Rbd["authorized"].ToString().ToUpper() == "S") continue;

                    to_auth += Rb["forename"].ToString() + " " + Rb["surname"].ToString() + " ha prenotato " +
                                        RLis["description"].ToString() + " (" + Rbd["number"].ToString() + ") \r\n";

                }
                if (to_auth != "") {
                    to_auth = "Ci sono prenotazioni che necessitano di autorizzazione: \r\n" + to_auth;
                    MailList.Add(new MailToSend("Prenotazioni da autorizzare", to_auth, manager_email));
                }
            }

            //Mail al magazziniere ove necessario: merce non da autorizzare oppure merce appena autorizzata
            foreach (DataRow Rbd in BookingDetail.Select()) {
                if (Rbd.RowState == DataRowState.Unchanged) continue;

                
                if (Rbd["idlist"].ToString() == "") continue;

                DataTable StockTotal = Conn.RUN_SELECT("stocktotal", "*", null,
                                QHS.AppAnd(QHS.CmpEq("idlist", Rbd["idlist"]), QHS.CmpEq("idstore", Rbd["idstore"])), null, true);
                decimal Nmin = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("list", QHS.CmpEq("idlist", Rbd["idlist"]), "nmin"));
                decimal prev_unbooked = 0;


                if (StockTotal.Rows.Count > 0) {
                    DataRow ST = StockTotal.Rows[0];
                    prev_unbooked = CfgFn.GetNoNullDecimal(ST["number"]) - CfgFn.GetNoNullDecimal(ST["booked"]);
                    //if (CfgFn.GetNoNullDecimal(ST["number"]) >= CfgFn.GetNoNullDecimal(ST["booked"]) + CfgFn.GetNoNullDecimal(Rbd["number"])) continue;
                }
                decimal new_unbooked = prev_unbooked - CfgFn.GetNoNullDecimal(Rbd["number"]);

                //Al magazziniere non arriva la mail se c'Ë una quantit‡ di riordino e il residuo Ë superiore a quella quantit‡
                if (Nmin > 0 && new_unbooked >= Nmin) continue;



                //Deve verificare se la merce richiesta necessita autorizzazione
                DataTable List = Conn.RUN_SELECT("list", "*", null, QHS.CmpEq("idlist", Rbd["idlist"]), null, false);
                if (List.Rows.Count == 0) continue;
                DataRow RLis = List.Rows[0];
                if (RLis["idlistclass"].ToString() != "") {
                    DataTable ListClass = Conn.RUN_SELECT("listclass", "*", null, QHS.CmpEq("idlistclass", RLis["idlistclass"]), null, false);
                    if (ListClass.Rows.Count > 0) {
                        DataRow RLisClass = ListClass.Rows[0];
                        if (RLisClass["authrequired"].ToString().ToUpper() == "S") {

                            if (Rbd.RowState == DataRowState.Modified) {
                                if (Rbd["authorized", DataRowVersion.Original].ToString().ToUpper() != "N" &&
                                        Rbd["authorized", DataRowVersion.Current].ToString().ToUpper() == "N") {
                                    string to_subscriber = "L'autorizzazione alla richiesta per la merce: " + RLis["description"].ToString() + " NON Ë stata concessa.\r\n";
                                    if (Rb["email"].ToString() != "") {
                                        MailList.Add(new MailToSend("Autorizzazione richiesta", to_subscriber, Rb["email"].ToString()));
                                    }
                                    continue;
                                }
                            }



                            //Delle modified prende solo quelle quelle appena autorizzate
                            if (Rbd.RowState == DataRowState.Modified 
                                && Rbd["authorized", DataRowVersion.Original].ToString().ToUpper() == "S") continue;
                            if ((Rbd.RowState == DataRowState.Modified  || Rbd.RowState==DataRowState.Added) 
                                && Rbd["authorized"].ToString().ToUpper() != "S") continue;
                           
                        }
                    }
                }
                DataTable Store = Conn.RUN_SELECT("store", "*", null, QHS.CmpEq("idstore", Rbd["idstore"]), null, true);
                string to_storeman = "Magazzino: " + Store.Rows[0]["description"].ToString() + "\r\n";
                to_storeman += Rb["forename"].ToString() + " " + Rb["surname"].ToString() + " ha prenotato " +
                                    RLis["description"].ToString() + " (" + Rbd["number"].ToString() + ") \r\n";
                string emailstoreman= Store.Rows[0]["email"].ToString();
                if (emailstoreman == "") {
                    if (Conn.GetSys("defaultdepmail") != null && Conn.GetSys("defaultdepmail").ToString() != "") {
                        emailstoreman = Conn.GetSys("defaultdepmail").ToString();
                    }
                }
                if (emailstoreman!="")
                    MailList.Add(new MailToSend("Prenotazione merce magazzino",to_storeman,emailstoreman));

                if (Rbd.RowState == DataRowState.Modified) {
                    if (Rbd["authorized", DataRowVersion.Original].ToString().ToUpper() != "S" &&
                            Rbd["authorized", DataRowVersion.Current].ToString().ToUpper() == "S") {
                        string to_subscriber = "La richiesta di merce: " + RLis["description"].ToString() + " Ë stata autorizzata.\r\n";
                        if (Rb["email"].ToString() != "") {
                            MailList.Add(new MailToSend("Autorizzazione richiesta", to_subscriber, Rb["email"].ToString()));
                        }
                    }
                }
            }

        }

        //Da aggiungere: 
        //   5) mail all'utente quando la merce che ha richiesto viene autorizzata (ove richiesto)  >> da fare

        public void SendMail() {
            foreach (MailToSend MTS in MailList) {
                SendMail SM = new SendMail();
                SM.UseSMTPLoginAsFromField = true;
                SM.To = MTS.email;
                SM.Subject = MTS.obj;
                SM.MessageBody = MTS.message;
                SM.Conn = Conn;
                try {
                    SM.Send();
                }
                catch { }
            }
        }
    }
    

    public class StoreUnloadSendMail {

        struct UnloadDetail {
           
            public decimal number;
            public string list;
            public string store;
            public string forename;
            public string surname;
           
        }

        DataAccess Conn;
        QueryHelper QHS;
        ArrayList MailList; //of SendMail

        public StoreUnloadSendMail(DataAccess Conn) {
            this.Conn = Conn;
            this.QHS = Conn.GetQueryHelper();
        }
        public void SendMail() {
            foreach (MailToSend MTS in MailList) {
                SendMail SM = new SendMail();
                SM.UseSMTPLoginAsFromField = true;
                SM.To = MTS.email;
                SM.Subject = MTS.obj;
                SM.MessageBody = MTS.message;
                SM.Conn = Conn;
                try {
                    SM.Send();
                }
                catch { }
            }
        }
        public static string GetErrorMailAddress(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object email = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "email");
            if (email == null) email = DBNull.Value;
            return email.ToString();
        }

        public void PrepareMailToSend(DataSet DS) {
            CQueryHelper QHC = new CQueryHelper();
            MailList = new ArrayList();
            if (!DS.Tables.Contains("storeunload")) return;
            if (!DS.Tables.Contains("storeunloaddetail")) return;

            DataTable StoreUnload = DS.Tables["storeunload"];
            DataTable StoreUnloadDetail = DS.Tables["storeunloaddetail"];
            if (StoreUnload.Select().Length == 0) return;
            DataRow Su = StoreUnload.Rows[0];
            Hashtable ManMsg = new Hashtable();
            Hashtable BookerMsg = new Hashtable();
            Hashtable MailMan = new Hashtable();
            foreach (DataRow SUdet in StoreUnloadDetail.Select(QHC.IsNotNull("idman"))) {
                if (SUdet.RowState == DataRowState.Unchanged) continue;
                object idman = SUdet["idman"];

                if (MailMan[idman.ToString()] == null) {
                    object O= Conn.DO_READ_VALUE("manager", QHS.CmpEq("idman", idman), "email");
                    if (O == null ) O = DBNull.Value;
                    MailMan[idman.ToString()] = O.ToString();
                }

                DataTable StockView = Conn.RUN_SELECT("stockview", "*", null, QHS.CmpEq("idstock", SUdet["idstock"]), null, true);
                if (StockView == null || StockView.Rows.Count == 0) continue;
                object idlist = StockView.Rows[0]["idlist"];
                object idstore = StockView.Rows[0]["idstore"];
                string ListTitle = StockView.Rows[0]["list"].ToString();
                DataTable BookingDetail = Conn.RUN_SELECT("bookingdetail", "*", null,
                       QHS.AppAnd(QHS.CmpEq("idbooking", SUdet["idbooking"]), QHS.CmpEq("idlist", idlist), QHS.CmpEq("idstore", idstore)), null, true);
                if (BookingDetail.Rows.Count == 0) continue;
                DataTable Booking = Conn.RUN_SELECT("booking", "*", null,
                       QHS.CmpEq("idbooking", SUdet["idbooking"]), null, true);
                DataTable Store = Conn.RUN_SELECT("store", "*", null, QHS.CmpEq("idstore", idstore), null, true);
                string to_storeman = "Magazzino: " + Store.Rows[0]["description"].ToString() + "\r\n";
                UnloadDetail U = new UnloadDetail();
                U.forename = Booking.Rows[0]["forename"].ToString();
                U.surname = Booking.Rows[0]["surname"].ToString();
                U.list = ListTitle;
                U.number = CfgFn.GetNoNullDecimal(SUdet["number"]);
                U.store = Store.Rows[0]["description"].ToString();
                ArrayList L;
                if (ManMsg[idman.ToString()] == null) {
                    L = new ArrayList();
                    ManMsg[idman.ToString()] = L;
                }
                else {
                    L = (ArrayList)ManMsg[idman.ToString()];
                }
                L.Add(U);
            }

            foreach (DataRow SUdet in StoreUnloadDetail.Select()) {
                if (SUdet.RowState == DataRowState.Unchanged) continue;
                object idman = SUdet["idman"];
                DataTable StockView = Conn.RUN_SELECT("stockview", "*", null, QHS.CmpEq("idstock", SUdet["idstock"]), null, true);
                if (StockView == null || StockView.Rows.Count == 0) continue;
                object idlist = StockView.Rows[0]["idlist"];
                object idstore = StockView.Rows[0]["idstore"];
                string ListTitle = StockView.Rows[0]["list"].ToString();
                DataTable BookingDetail = Conn.RUN_SELECT("bookingdetail", "*", null,
                       QHS.AppAnd(QHS.CmpEq("idbooking", SUdet["idbooking"]), QHS.CmpEq("idlist", idlist), QHS.CmpEq("idstore", idstore)), null, true);
                if (BookingDetail.Rows.Count == 0) continue;
                DataTable Booking = Conn.RUN_SELECT("booking", "*", null,
                       QHS.CmpEq("idbooking", SUdet["idbooking"]), null, true);
                string email_booker = Booking.Rows[0]["email"].ToString();
                if (email_booker == "") continue;

                if (idman != DBNull.Value) {
                    object O = MailMan[idman.ToString()];
                    if (O.ToString() == email_booker) continue;
                }
                DataTable Store = Conn.RUN_SELECT("store", "*", null, QHS.CmpEq("idstore", idstore), null, true);
                string to_storeman = "Magazzino: " + Store.Rows[0]["description"].ToString() + "\r\n";
                UnloadDetail U = new UnloadDetail();
                U.forename = Booking.Rows[0]["forename"].ToString();
                U.surname = Booking.Rows[0]["surname"].ToString();
                U.list = ListTitle;
                U.number = CfgFn.GetNoNullDecimal(SUdet["number"]);
                U.store = Store.Rows[0]["description"].ToString();
                ArrayList L;
                if (BookerMsg[email_booker.ToString()] == null) {
                    L = new ArrayList();
                    BookerMsg[email_booker.ToString()] = L;  
                }
                else {
                    L = (ArrayList)BookerMsg[email_booker.ToString()];
                }
                L.Add(U);
            }
            bool booking_on_invoice;
            object Obooking_on_invoice = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "booking_on_invoice");
            if (Obooking_on_invoice == null || Obooking_on_invoice == DBNull.Value || Obooking_on_invoice.ToString() == "") Obooking_on_invoice = "N";
            booking_on_invoice = (Obooking_on_invoice.ToString().ToUpper()=="S");
            if (booking_on_invoice) // Prenota solo Merce Disponibile
            {
                // Scarico da Card
                foreach (string idman in ManMsg.Keys)
                {
                    string manager_email = MailMan[idman.ToString()].ToString();
                    bool err_mess = false;
                    string obj = "";
                    if (manager_email == "") {
                        err_mess = true;
                        manager_email = GetErrorMailAddress(Conn);
                        obj = "EMAIL NON INVIATA: ";
                    }
                    obj += "Prelievo merce da magazzino";
                    ArrayList L = (ArrayList)ManMsg[idman];
                    string msg = "";
                    if (err_mess) msg += "MAIL NON INVIATA al responsabile per mancanza indirizzo email\r\n";
                    msg+="Della merce Ë stata prelevata dal magazzino sotto la Sua responsabilit‡:\r\n";
                    foreach (UnloadDetail U in L)
                    {
                        msg += U.forename + " " + U.surname + " ha prelevato " + U.number + " " + U.list + " dal magazzino " + U.store + "\r\n";
                    }
                    MailToSend M = new MailToSend(obj, msg, manager_email);
                    MailList.Add(M);
                }

                foreach (string email_booker in BookerMsg.Keys)
                {
                    bool err_mess2 = false;
                    string obj2 = "";
                    string email = email_booker;
                    if (email == "") {
                        email = GetErrorMailAddress(Conn);
                        err_mess2 = true;
                        obj2 = "EMAIL NON INVIATA: ";
                    }
                    obj2 += "Prelievo merce da magazzino";

                    ArrayList L = (ArrayList)BookerMsg[email_booker];
                    string msg = "";
                    if (err_mess2) msg += "MAIL NON INVIATA al prelevante per mancanza indirizzo email\r\n";
                    msg += "Della merce da lei prenotata Ë stata prelevata dal magazzino:\r\n";
                    foreach (UnloadDetail U in L)
                    {
                        msg += U.number + " " + U.list + " dal magazzino " + U.store + "\r\n";
                    }
                    MailToSend M = new MailToSend(obj2, msg, email);
                    MailList.Add(M);
                }
            }

            else
            {
                // Gestione normale
                foreach (string idman in ManMsg.Keys)
                {
                    string obj = "";
                    string manager_email = MailMan[idman.ToString()].ToString();
                    bool err_mess = false;
                    if (manager_email == "") {
                        err_mess = true;
                        manager_email = GetErrorMailAddress(Conn);
                        obj = "EMAIL NON INVIATA: ";
                    }
                    obj += "Richiesta di merce da magazzino evasa";
                    ArrayList L = (ArrayList)ManMsg[idman];
                    string msg = "";
                    if (err_mess) msg += "MAIL NON INVIATA al responsabile per mancanza indirizzo email\r\n";
                    msg += "Si comunica che la sua richiesta di merce di magazzino Ë stata evasa. \r\n";
                           msg+= "Gli articoli\r\n" ;
                    foreach (UnloadDetail U in L)
                    {
                        msg += U.number + " " + U.list + " - magazzino " + U.store + "\r\n";
                    }
                    msg += "sono pronti per essere ritirati";
                    MailToSend M = new MailToSend(obj, msg, manager_email);
                    MailList.Add(M);
                }

                foreach (string email_booker in BookerMsg.Keys)
                {

                    bool err_mess2 = false;
                    string email = email_booker;
                    string obj2 = "";
                    if (email_booker == "") {
                        email = GetErrorMailAddress(Conn);
                        err_mess2 = true;
                        obj2 = "EMAIL NON INVIATA: ";
                    }
                    obj2 += "Richiesta di merce da magazzino evasa";
                    ArrayList L = (ArrayList)BookerMsg[email_booker];
                    string msg = "";
                    if (err_mess2) msg += "MAIL NON INVIATA al prelevante per mancanza indirizzo email\r\n";
                    msg += "Si comunica che la sua richiesta di merce di magazzino Ë stata evasa. \r\n";
                    msg += "Gli articoli\r\n";
                    foreach (UnloadDetail U in L)
                    {
                        msg += U.number + " " + U.list + " - magazzino "+ U.store + "\r\n";
                    }
                    msg += "sono pronti per essere ritirati";
                    MailToSend M = new MailToSend(obj2, msg, email);
                    MailList.Add(M);
                }
            }

        }
    }
}
