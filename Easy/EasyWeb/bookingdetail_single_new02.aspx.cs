
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using HelpWeb;
using AllDataSet;
using metadatalibrary;
using funzioni_configurazione;
using EasyWebReport;

public partial class bookingdetail_single_new02 : MetaPage {
    CQueryHelper QHC;
    QueryHelper QHS;
    vistaForm_bookingdetail DS;


    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_bookingdetail();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_bookingdetail)D;
    }

    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.Name = "Dettaglio prenotazione";
        HelpForm.SetFormatForColumn(DS.bookingdetail.Columns["number"], "n");
        QHS = Conn.GetQueryHelper();
        DataAccess.SetTableForReading(DS.sorting1, "sorting");
        DataAccess.SetTableForReading(DS.sorting2, "sorting");
        DataAccess.SetTableForReading(DS.sorting3, "sorting");
        DataTable tConfig = Conn.RUN_SELECT("config", "*", null,
            QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);
        if ((tConfig != null) && (tConfig.Rows.Count > 0)) {
            DataRow R = tConfig.Rows[0];
            object idsorkind1 = R["idsortingkind1"];
            object idsorkind2 = R["idsortingkind2"];
            object idsorkind3 = R["idsortingkind3"];
            SetGBoxClass(1, idsorkind1);
            SetGBoxClass(2, idsorkind2);
            SetGBoxClass(3, idsorkind3);
            if (idsorkind1 == DBNull.Value) {
                gboxclass1.Enabled = false;

            }
            if (idsorkind2 == DBNull.Value) {
                gboxclass2.Enabled = false;

            }
            if (idsorkind3 == DBNull.Value) {
                gboxclass3.Enabled = false;

            }
            object booking_on_invoice = R["booking_on_invoice"];
            if (booking_on_invoice.ToString().ToUpper() == "S") {
                //Se prenoto solo Merce disponibile devo vedere anche il prezzo della merce
                lblPrezzoUnitario.Visible = true;
                txtPrezzoUnitario.Visible = true;
            }
            else {
                lblPrezzoUnitario.Visible = false;
                txtPrezzoUnitario.Visible = false;
            }
        }


    }

    public override void AfterFill() {
        if (CanAuthorize())
            chkAuthorized.Enabled = true;

        if (PState.EditMode) {
            DataRow R = DS.bookingdetail.Rows[0];
            if (R["authorized", DataRowVersion.Original].ToString().ToUpper() == "S") {
                object num = Conn.DO_READ_VALUE("booktotalview", QHS.AppAnd(QHS.CmpEq("idbooking", R["idbooking"]), QHS.CmpEq("idlist", R["idlist"])),
                                                            "isnull(booked,0)-isnull(number,0)");
                decimal n = CfgFn.GetNoNullDecimal(num);
                txtUnloaded.Text = HelpForm.StringValue(n, "x.y.n");

                num = Conn.DO_READ_VALUE("booktotalview", QHS.AppAnd(QHS.CmpEq("idbooking", R["idbooking"]), QHS.CmpEq("idlist", R["idlist"])),
                                                            "isnull(allocated,0)");
                n = CfgFn.GetNoNullDecimal(num);
                txtDaScaricare.Text = HelpForm.StringValue(n, "x.y.n");
            }

        }

    }

    public bool CanAuthorize() {
        // In order to authorize I must be a manager
        // AND the manager 
        bool IsManager = (Session["CodiceResponsabile"] != null ? true : false);
        if (!IsManager)
            return false;
        Hashtable HT;
        if (DS.bookingdetail.ExtendedProperties[MetaData.ExtraParams] == null)
            return false;
        HT = (Hashtable)DS.bookingdetail.ExtendedProperties[MetaData.ExtraParams];

        int loggedinidman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);
        int idman = CfgFn.GetNoNullInt32(HT["idman"]);

        if (idman == loggedinidman)
            return true;
        else
            return false;

    }

    protected void Page_Load(object sender, EventArgs e) {
        if (DS.bookingdetail.Rows.Count == 0)
            return;
        DataRow Curr = DS.bookingdetail.Rows[0];
        int idlist = CfgFn.GetNoNullInt32(Curr["idlist"]);
        HtmlImage I = new HtmlImage();
        if (idlist == 0)
            return;
        if (HasImage(idlist))
            I.Src = "GetItemImage.aspx?idlist=" + idlist.ToString();
        else
            I.Src = "Immagini/imagenotavailable.png";
        //I.Style.Add("position", "absolute");
        I.Style.Add("z-index", "101");
        I.Style.Add("top", "14px");
        I.Style.Add("left", "374px");
        I.Style.Add("max-width", "309px");
        I.Style.Add("max-height", "175px");
        I.Style.Add("align", "center");
        I.Style.Add("vertical-align", "center");

        grpImmagine.Controls.Add(I);

    }


    void SetGBoxClass(int num, object sortingkind) {
        string nums = num.ToString();
        hwPanel gbox = new hwPanel();
        hwButton btncodice = new hwButton();
        //HtmlGenericControl gboxlabel = new HtmlGenericControl();
        hwTextBox txt = new hwTextBox();
        hwTextBox denom = new hwTextBox();
        switch (num) {
            case 1:
                gbox = gboxclass1;
                btncodice = btnCodice1;
                //gboxlabel = gboxlabel1;
                txt = txtCodice1;
                denom = txtDenom1;
                break;
            case 2:
                gbox = gboxclass2;
                btncodice = btnCodice2;
                //gboxlabel = gboxlabel2;
                txt = txtCodice2;
                denom = txtDenom2;
                break;
            case 3:
                gbox = gboxclass3;
                btncodice = btnCodice3;
                //gboxlabel = gboxlabel3;
                txt = txtCodice3;
                denom = txtDenom3;

                break;
        }

        bool hasdefault = (DS.bookingdetail.Columns["idsor" + num.ToString()].DefaultValue != DBNull.Value);

        if (sortingkind == DBNull.Value) {
            gbox.Enabled = false;
            btncodice.Enabled = false;
            txt.Enabled = false;
            txt.Visible = false;
            btncodice.Visible = false;
            denom.Visible = false;
            gbox.Visible = false;
            gbox.GroupingText = "";
            //gboxlabel.InnerText = "";
        }
        else {
            string filter = QHS.CmpEq("idsorkind", sortingkind);
            GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);

            string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
            //gboxlabel.InnerText = title;
            gbox.GroupingText = title;
            if (!hasdefault) {
                gbox.Tag = "AutoManage.txtCodice" + nums + ".tree." + filter;
                btncodice.Tag = "manage.sorting" + nums + ".tree." + filter;
            }
            else {
                txt.ReadOnly = true;
            }
            DS.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;

        }
    }


    public bool HasImage(int idlist) {
        QHS = Conn.GetQueryHelper();
        string filter = QHS.CmpEq("idlist", idlist);
        DataTable T = Conn.RUN_SELECT("list", "*", null, filter, null, false);
        if (T == null || T.Rows.Count == 0)
            return false;
        DataRow DR = T.Rows[0];
        if (DR["pic"].Equals(DBNull.Value))
            return false;
        else
            return true;

    }

}
