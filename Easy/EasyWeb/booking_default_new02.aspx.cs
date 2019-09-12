/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HelpWeb;
using AllDataSet;
using metadatalibrary;
using funzioni_configurazione;
using EasyWebReport;
using stockmail;


public partial class booking_default_new02 : MetaPage {
    CQueryHelper QHC;
    QueryHelper QHS;
    vistaForm_booking DS;


    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_booking();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_booking)D;
    }

    public void SetChildParameter(int idman) {
        Hashtable HT = new Hashtable();

        HT["idman"] = idman;

        DS.bookingdetail.ExtendedProperties[MetaData.ExtraParams] = HT;

    }

    public override void AfterRowSelect(DataTable T, DataRow R) {
        if (T.TableName == "manager") {
            if (DS.booking.Rows.Count != 0)
                SetChildParameter(CfgFn.GetNoNullInt32(DS.booking.Rows[0]["idman"]));
        }
    }

    public override void AfterFill() {
        // A seconda dell'edittype,
        // Configurare il filtro in maniera diversa.
        // Se l'edittype è myteam, devo poter vedere tutte le prenotazioni delle quali sono responsabile;
        // altrimenti devo poter vedere tutte le mie prenotazioni

        btnvetrina.Visible = true;

        cmbCard.Enabled = PState.InsertMode && get_booking_on_invoice();
        btnCard.Visible = PState.InsertMode && get_booking_on_invoice();

        bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idman = 0;
        idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);

        if (PState.EditMode) {
            cmbidman.Enabled = false;
        }
        else {
            cmbidman.Enabled = true;
        }

        if (PState.InsertMode || PState.EditMode) {
            txtybooking.ReadOnly = true;
            txtnbooking.ReadOnly = true;
        }

        if (PState.InsertMode) {
            if (Conn.GetSys("idcustomuser") != null && Conn.GetSys("idcustomuser") != DBNull.Value)
                DS.booking.Rows[0]["idcustomuser"] = Conn.GetSys("user");
            if (Conn.GetUsr("surname") != null) {
                DS.booking.Rows[0]["surname"] = Conn.GetUsr("surname");
                txtsurname.Text = Conn.GetUsr("surname").ToString();
            }
            if (Conn.GetUsr("forename") != null) {
                DS.booking.Rows[0]["forename"] = Conn.GetUsr("forename");
                txtforename.Text = Conn.GetUsr("forename").ToString();
            }

            if (Conn.GetUsr("cf") != null) {
                DS.booking.Rows[0]["cf"] = Conn.GetUsr("cf");
                txtcf.Text = Conn.GetUsr("cf").ToString();
            }

            if (Conn.GetUsr("email") != null) {
                DS.booking.Rows[0]["email"] = Conn.GetUsr("email");
            }


            //if (IsManager)
            //{
            //    DS.booking.Rows[0]["idman"] = idman;
            //    cmbidman.SelectedValue = idman.ToString();
            //}

            if (DS.booking.Rows.Count != 0)
                SetChildParameter(CfgFn.GetNoNullInt32(DS.booking.Rows[0]["idman"]));

        }

        lblDetailsInWait.Text = "";
        lblDetailsNotAuth.Text = "";

        if (HasPendingAuthDetails())
            lblDetailsInWait.Text = "Ci sono dettagli in attesa di autorizzazione";

        if (HasUnauthorizedDetails())
            lblDetailsNotAuth.Text = "Ci sono dettagli non autorizzati";

        SetMainVisibility();

    }
    public override void DoCommand(string command) {
        if (command == "vetrina") {
            btnvetrina_Click(null, null);
        }
    }
    public void SetMainVisibility() {
        QHS = Conn.GetQueryHelper();
        if (Meta.edit_type == "myteamnew02") {
            // Posso guardare solo le prenotazioni delle quali io sono responsabile
            // Escluse le mie
            bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
            int idman = 0;
            idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);
            string filter = QHS.AppAnd(QHS.CmpEq("idman", idman), QHS.CmpNe("idcustomuser", Conn.GetSys("idcustomuser")));
            GetData.SetStaticFilter(DS.bookingview, filter);
        }
        else {
            // Posso guardare solo le mie prenotazioni
            if (Conn.GetSys("idcustomuser") != null && Conn.GetSys("idcustomuser") != DBNull.Value)
                GetData.SetStaticFilter(DS.bookingview, QHS.CmpEq("idcustomuser", Conn.GetSys("idcustomuser")));
        }
    }

    public override void AfterGetFormData() {

        if (DS.booking.Rows.Count != 0)
            SetChildParameter(CfgFn.GetNoNullInt32(DS.booking.Rows[0]["idman"]));

        bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idman = 0;
        idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);
        bool need_authorize = true;
        if (IsManager) {
            object idman_sel = DS.booking.Rows[0]["idman"];
            if (idman.ToString() == idman_sel.ToString())
                need_authorize = false;
        }
        foreach (DataRow RDet in DS.bookingdetail.Select()) {
            if (RDet.RowState != DataRowState.Added)
                continue;
            if (RequiresAuthorization(CfgFn.GetNoNullInt32(RDet["idlist"]))) {
                if (need_authorize)
                    RDet["authorized"] = DBNull.Value;
                else
                    RDet["authorized"] = "S";
            }
            else {
                RDet["authorized"] = "S";
            }
        }


    }

    public bool RequiresAuthorization(int idlist) {
        QueryHelper QHS = Conn.GetQueryHelper();
        string filter = QHS.CmpEq("idlist", idlist);

        DataTable T = Conn.RUN_SELECT("list", "*", null, filter, null, false);

        if (T == null || T.Rows.Count == 0)
            return false;

        string idlistclass = T.Rows[0]["idlistclass"].ToString();

        filter = QHS.CmpEq("idlistclass", idlistclass);
        T = Conn.RUN_SELECT("listclass", "*", null, filter, null, false);
        if (T == null || T.Rows.Count == 0)
            return false;

        string authrequired = T.Rows[0]["authrequired"].ToString();

        return (authrequired == "S" ? true : false);
    }

    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.Name = "Prenotazione";
        QHC = new CQueryHelper();
        QHS = Conn.GetQueryHelper();

        Meta.CanInsert = false;
        if (formToLink) {
            cmbidman.DataSource = DS.manager;
            cmbidman.DataValueField = "idman";
            cmbidman.DataTextField = "title";

            cmbCard.DataSource = DS.lcard;
            cmbCard.DataValueField = "idlcard";
            cmbCard.DataTextField = "title";
        }
        string filterLcard = QHS.CmpEq("active", "S"); // card attive

        bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idman = 0;
        idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);

        string filterManager = "";
        //if (IsManager) {
        //    filterManager = QHS.CmpEq("idman", idman);
        //}

        if (Conn.GetUsr("cf") != null) {
            filterManager = QHS.DoPar(QHS.AppOr(filterManager, "(idlcard in (select idlcard from lcardcf where " +
                                                    QHS.CmpEq("cf", Conn.GetUsr("cf")) + "))"));
        }

        filterLcard = QHS.AppAnd(filterLcard, filterManager);

        DataTable LCard = Meta.Conn.RUN_SELECT("lcard", "*", null, filterLcard, null, false);

        string filterId = QHC.FieldIn("idlcard", LCard.Select());
        GetData.SetStaticFilter(DS.lcard, filterId);
        string tag = btnCard.Tag;
        tag = tag + "." + filterId;
        btnCard.Tag = tag;

        SetMainVisibility();

        Meta.DefaultListType = "list";
        SearchTable = "bookingview";
        HelpForm.SetFormatForColumn(DS.bookingdetail.Columns["number"], "N");

        if (firsttime) {
            object booking_on_invoice = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "booking_on_invoice");
            if (booking_on_invoice == null || booking_on_invoice == DBNull.Value || booking_on_invoice == "")
                booking_on_invoice = "N";
            booking_on_invoice = booking_on_invoice.ToString().ToUpper();
            PState.var["booking_on_invoice"] = booking_on_invoice;

        }

        if (!get_booking_on_invoice()) {
            btnCard.Visible = false; 
            cmbCard.Enabled = false;
        }
        else {
            HelpForm.SetDenyNull(DS.booking.Columns["idlcard"], true);
        }
    }

    bool get_booking_on_invoice() {
        if (PState.var["booking_on_invoice"] == null)
            return false;
        return (PState.var["booking_on_invoice"].ToString().ToUpper() == "S");
    }


    public bool HasUnauthorizedDetails() {
        if (DS.bookingdetail.Rows.Count == 0)
            return false;
        foreach (DataRow DR in DS.bookingdetail.Rows)
            if (DR.RowState != DataRowState.Deleted && DR["authorized"].ToString() == "N")
                return true;
        return false;
    }

    public bool HasPendingAuthDetails() {
        if (DS.bookingdetail.Rows.Count == 0)
            return false;
        foreach (DataRow DR in DS.bookingdetail.Rows)
            if (DR.RowState != DataRowState.Deleted && DR["authorized"] == DBNull.Value)
                return true;
        return false;
    }


    public override void AfterClear() {
        txtybooking.ReadOnly = false;
        txtnbooking.ReadOnly = false;
        FillDSWithSessionValues();
        btnvetrina.Visible = false;
        btnCard.Visible = get_booking_on_invoice();
        cmbidman.Enabled = true;

    }

    protected void btnvetrina_Click(object sender, EventArgs e) {
        RebuildSessionFromDS();
        ApplicationState APS = ApplicationState.GetApplicationState(this);
        MetaData M = APS.Dispatcher.Get("showcase");
        M.edit_type = "defaultnew02";
        APS.CallPage(this, M, false);
    }

    public void RebuildSessionFromDS() {
        ArrayList AR = new ArrayList();
        cartitem CI;
        if (DS.bookingdetail.Rows.Count == 0)
            return;
        foreach (DataRow DR in DS.bookingdetail.Rows) {
            if (DR.RowState != DataRowState.Added)
                continue;
            CI = new cartitem();
            CI.idlist = CfgFn.GetNoNullInt32(DR["idlist"]);
            CI.idstore = CfgFn.GetNoNullInt32(DR["idstore"]);
            CI.quantity = CfgFn.GetNoNullInt32(DR["number"]);
            CI.price = CfgFn.GetNoNullDecimal(DR["price"]);
            CI.idstock = CfgFn.GetNoNullInt32(DR["idstock"]);
            AR.Add(CI);
        }

        if (AR.Count > 0)
            Session["Cart"] = AR;
    }

    public override void BeforeFill() {
        if (Session["Cart"] == null)
            return;
        AlignDSWithSession();
    }

    /// <summary>
    /// Viene chiamata dal BeforeFill quando la vetrina è aperta a partire da QUESTA pagina
    /// </summary>
    public void AlignDSWithSession() {
        bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);

        if (Session["Cart"] == null)
            return;
        ArrayList AR = (ArrayList)Session["Cart"];
        cartitem CI;
        string filter;
        DataTable T;
        DataRow ParentRow = DS.booking.Rows[0];
        QHC = new CQueryHelper();
        QHS = Conn.GetQueryHelper();

        MetaData MD = Meta.Dispatcher.Get("bookingdetail");
        string ErrMsg = "Alcuni articoli prenotati sono stati scartati perché già presenti nella prenotazione";
        bool dispmessage = false;
        for (int i = 0; i < AR.Count; i++) {
            CI = (cartitem)AR[i];
            string filternoStock = QHC.AppAnd(QHC.CmpEq("idlist", CI.idlist), QHC.CmpEq("idstore", CI.idstore));
            DataRow[] DR = DS.bookingdetail.Select(filternoStock);
            if (DR.Length != 0) {
                if (DR[0]["idstock"].ToString() != CI.idstock.ToString()) {
                    dispmessage = true;
                }
                else {
                    DR[0]["number"] = CI.quantity;
                }
            }
            else {
                DataRow DRNew = MD.Get_New_Row(ParentRow, DS.bookingdetail);
                string cond = "";
                //if (get_booking_on_invoice()) {
                //    cond= QHS.AppAnd(QHS.CmpGt("S.amount", 0), QHS.CmpGt("residual", 0), QHS.CmpEq("S.idstore", CI.idstore), QHS.CmpEq("S.idlist", CI.idlist),
                //        QHS.CmpEq("S.idstock", CI.idstock));
                //}
                //else {
                //    cond = QHS.AppAnd(QHS.CmpGt("S.amount", 0), QHS.CmpGt("residual", 0), QHS.CmpEq("S.idstore", CI.idstore), QHS.CmpEq("S.idlist", CI.idlist));                                
                //}


                //string Query = 
                //    "select S.idlist,S.idstore, S.intcode,S.list as description,	ST.number,ST.ordered,ST.booked, S.idstock," +
                //            "S.listclass as listclasstitle,S.authrequired as authorizationrequired " +
                //        //"S.amount as price " +
                //            "FROM stockview S " +
                //            "join stocktotal ST on S.idlist=ST.idlist and S.idstore=ST.idstore " +
                //            "where " + cond;

                string Query =
                   "select idlist, S.description,	S.authrequired " +
                    //"S.amount as price " +
                           "FROM stockview S " +
                           "join stocktotal ST on S.idlist=ST.idlist and S.idstore=ST.idstore " +
                           "where " + cond;

                T = Conn.RUN_SELECT("listview", "idlist,description,authrequired", null, QHS.CmpEq("idlist", CI.idlist), null, false);
                DataRow RList = T.Rows[0];

                DRNew["!list"] = RList["description"];
                DRNew["idlist"] = CI.idlist;

                if (RList["authrequired"].ToString().ToUpper() == "S")
                    DRNew["authorized"] = DBNull.Value;
                else
                    DRNew["authorized"] = "S";

                // Se sono responsabile sono GIA' autorizzato alla merce
                //if (IsManager)
                //    DRNew["authorized"] = "S";

                filter = QHS.CmpEq("idstore", CI.idstore);
                T = Conn.RUN_SELECT("store", "*", null, filter, null, false);
                DRNew["idstore"] = CI.idstore;
                DRNew["!store"] = T.Rows[0]["description"];
                DRNew["number"] = CI.quantity;
                if (get_booking_on_invoice()) {
                    if (CI.idstock != 0)
                        DRNew["idstock"] = CI.idstock;
                    if (CI.price != 0)
                        DRNew["price"] = CI.price;
                }
                SetSortingDefaults(DRNew);

            }
            if (dispmessage)
                ShowClientMessage(ErrMsg, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);

        }
        Session["Cart"] = null;
    }

    public void SetSortingDefaults(DataRow BookDtl) {
        QHS = Conn.GetQueryHelper();
        string idflowchart = Conn.GetSys("idflowchart").ToString();

        string filter = QHS.CmpEq("idflowchart", idflowchart);

        DataTable T = Conn.RUN_SELECT("flowchart", "*", null, filter, null, false);
        if (T == null || T.Rows.Count == 0)
            return;

        DataRow DR = T.Rows[0];
        BookDtl["idsor1"] = DR["idsor1"];
        BookDtl["idsor2"] = DR["idsor2"];
        BookDtl["idsor3"] = DR["idsor3"];
        BookDtl.Table.Columns["idsor1"].DefaultValue = DR["idsor1"];
        BookDtl.Table.Columns["idsor2"].DefaultValue = DR["idsor2"];
        BookDtl.Table.Columns["idsor3"].DefaultValue = DR["idsor3"];
        return;
    }


    public void FillDSWithSessionValues() {
        // Defaulting di idman se sono responsabile
        bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        int idman = 0;
        if (IsManager)
            idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);

        if (Session["Cart"] == null)
            return;
        ArrayList AR = (ArrayList)Session["Cart"];
        Session["Cart"] = null;
        CommFun.DoMainCommand("maininsert");
        Meta.SetDefaults(DS.booking);
        DataRow BookingRow = DS.booking.Rows[0];
        BookingRow["ybooking"] = Conn.GetSys("esercizio");

        QHS = Conn.GetQueryHelper();
        MetaData MD = Meta.Dispatcher.Get("bookingdetail");
        string message = "Alcuni articoli prenotati sono stati scartati perché già presenti nella prenotazione";
        bool dispmessage = false;

        for (int i = 0; i < AR.Count; i++) {
            cartitem ci = (cartitem)AR[i];
            string filter = QHC.CmpEq("idlist", ci.idlist);
            DataRow[] Details = DS.bookingdetail.Select(filter);
            if ((Details.Length) > 0) {
                dispmessage = true;
                continue;
            }
            DataTable T;
            MD.SetDefaults(DS.bookingdetail);
            DataRow BookingDetailRow = MD.Get_New_Row(BookingRow, DS.bookingdetail);

            BookingDetailRow["idlist"] = ci.idlist;
            string filterlist = "";
            filterlist = QHS.CmpEq("idlist", ci.idlist);
            T = Conn.RUN_SELECT("list", "*", null, filter, null, false);
            BookingDetailRow["!list"] = T.Rows[0]["description"];
            BookingDetailRow["idstore"] = ci.idstore;
            if (get_booking_on_invoice()) {
                if (ci.price != 0)
                    BookingDetailRow["price"] = ci.price;
                if (ci.idstock != 0)
                    BookingDetailRow["idstock"] = ci.idstock;
            }
            filter = QHS.CmpEq("idstore", ci.idstore);
            T = Conn.RUN_SELECT("store", "*", null, filter, null, false);
            BookingDetailRow["!store"] = T.Rows[0]["description"];

            if (RequiresAuthorization(ci.idlist))
                BookingDetailRow["authorized"] = DBNull.Value;
            else
                BookingDetailRow["authorized"] = "S";


            // Se sono responsabile sono GIA' autorizzato alla merce
            //if (IsManager)
            //    BookingDetailRow["authorized"] = "S";

            BookingDetailRow["number"] = ci.quantity;
            SetSortingDefaults(BookingDetailRow);

        }
        if (dispmessage)
            ShowClientMessage(message, "Attenzione", System.Windows.Forms.MessageBoxButtons.OK);

        Session["Cart"] = null;
    }

    public override void BeforePost() {
        PState.var["BSM"] = null;
        if (DS.booking.Select().Length > 0) {
            BookingSendMail BSM = new BookingSendMail(Conn as DataAccess);
            BSM.PrepareMailToSend(DS);
            PState.var["BSM"] = BSM;
        }
    }

    public override void AfterPost() {
        BookingSendMail BSM = PState.var["BSM"] as BookingSendMail;
        if (BSM != null) {
            BSM.SendMail();
            PState.var["BSM"] = null;
        }

    }

}
