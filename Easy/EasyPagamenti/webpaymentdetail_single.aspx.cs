
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using funzioni_configurazione;
using EasyPagamentiDataSet;
using EasyPagamenti;
using q = metadatalibrary.MetaExpression;

public partial class webpaymentdetail_single :MetaPage {
    CQueryHelper QHC;
    QueryHelper QHS;
    vistaForm_webpaymentdetail DS;


    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_webpaymentdetail();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_webpaymentdetail)D;
    }

    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.Name = "Dettaglio prenotazione pagamento";
        HelpForm.SetFormatForColumn(DS.webpaymentdetail.Columns["number"], "n");
        QHS = Conn.GetQueryHelper();

        //lblPrezzoUnitario.Visible = true;
        //txtPrezzoUnitario.Visible = true;
        txtPrezzoUnitario.ReadOnly = true;
        txtStore.Visible = true;
        grpImmagine.Visible = false;
        lblCodeListClass.Visible = false;
        txtCodeListClass.Visible = false;
        lblDesListClass.Visible = false;
        txtDesListClass.Visible = false;
       
        DataRow rwebpaymentdetail = Meta.SourceRow;
        DataRow rwebpayment = rwebpaymentdetail.Table.DataSet.Tables["webpayment"].Rows[0];
        int CurrentStatus = CfgFn.GetNoNullInt32(rwebpayment["idwebpaymentstatus"]);
        // 1: Bozza
        if (CurrentStatus != 1) {
            txtNumber.ReadOnly = true;
        }
        else {
            txtNumber.ReadOnly = false;
        }
        txtNumber.TextChanged += txtNumber_LeaveTextBoxHandler;
    }
    public void txtNumber_LeaveTextBoxHandler(object sender, EventArgs e){
        if (DS.webpaymentdetail.Rows.Count == 0)
            return;
        
        DataRow Curr = DS.webpaymentdetail.Rows[0];
        if (CfgFn.GetNoNullInt32(Curr["idivakind"]) != 0){
            var ivakind = Conn.readObject("ivakind", q.eq("idivakind", Curr["idivakind"]), "rate");
            double rate = CfgFn.GetNoNullDouble(ivakind["rate"]);
            double number = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(decimal), txtNumber.Text, "x.y.c"));
            double iva = CfgFn.RoundValuta(CfgFn.GetNoNullDouble(Curr["price"]) * rate * number);
            Curr["tax"] = iva;
        }
        
    }
    public override void AfterFill() {
        if (PState.EditMode) {
            DataRow R = DS.webpaymentdetail.Rows[0];
        }

    }

    public bool CanAuthorize() {
            return true;
   }

    protected void Page_Load(object sender, EventArgs e) {
        if (DS.webpaymentdetail.Rows.Count == 0)
            return;
        DataRow Curr = DS.webpaymentdetail.Rows[0];
        int idlist = CfgFn.GetNoNullInt32(Curr["idlist"]);
        HtmlImage I = new HtmlImage();
        if (idlist == 0)
            return;
        if (HasImage(idlist))
            I.Src = "GetItemImage.aspx?idlist=" + idlist.ToString();
        else
            I.Src = "Immagini/imagenotavailable.png";
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
        //string nums = num.ToString();
        //hwPanel gbox = new hwPanel();
        //hwButton btncodice = new hwButton();
        ////HtmlGenericControl gboxlabel = new HtmlGenericControl();
        //hwTextBox txt = new hwTextBox();
        //hwTextBox denom = new hwTextBox();
        //switch (num) {
        //case 1:
        //    gbox = gboxclass1;
        //    btncodice = btnCodice1;
        //    //gboxlabel = gboxlabel1;
        //    txt = txtCodice1;
        //    denom = txtDenom1;
        //    break;
        //case 2:
        //    gbox = gboxclass2;
        //    btncodice = btnCodice2;
        //    //gboxlabel = gboxlabel2;
        //    txt = txtCodice2;
        //    denom = txtDenom2;
        //    break;
        //case 3:
        //    gbox = gboxclass3;
        //    btncodice = btnCodice3;
        //    //gboxlabel = gboxlabel3;
        //    txt = txtCodice3;
        //    denom = txtDenom3;

        //    break;
        //}
        
        //bool hasdefault = (DS.webpaymentdetail.Columns["idsor" + num.ToString()].DefaultValue != DBNull.Value);

        //if (sortingkind == DBNull.Value) {
        //    gbox.Enabled = false;
        //    btncodice.Enabled = false;
        //    txt.Enabled = false;
        //    txt.Visible = false;
        //    btncodice.Visible = false;
        //    denom.Visible = false;
        //    gbox.Visible = false;
        //    gbox.GroupingText = "";
        //    //gboxlabel.InnerText = "";
        //}
        //else {
        //    string filter = QHS.CmpEq("idsorkind", sortingkind);
        //    GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);

        //    string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
        //    //gboxlabel.InnerText = title;
        //    gbox.GroupingText = title;
        //    if (!hasdefault) {
        //        gbox.Tag = "AutoManage.txtCodice" + nums + ".tree." + filter;
        //        btncodice.Tag = "manage.sorting" + nums + ".tree." + filter;
        //    }
        //    else {
        //        txt.ReadOnly = true;
        //    }
        //    DS.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;

        //}
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
