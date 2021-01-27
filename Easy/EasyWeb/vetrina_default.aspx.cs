
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
using funzioni_configurazione;

public partial class vetrina_default :MetaPage
{
    vistaForm_showcase DS;

    public override DataSet GetDataSet()
    {
        return DS;
    }
    public override DataSet CreateNewDataSet()
    {
        return new vistaForm_showcase();
    }
    public override void SetDataSet(DataSet D)
    {
        DS = (vistaForm_showcase)D;
    }

    public override void AfterLink(bool firsttime, bool formToLink)
    {
        Meta.CanInsert = false;
        Meta.CanCancel = false;
        Meta.CanSave = false;
        Meta.SearchEnabled = false;
        FillShowcases();
        if (firsttime) {
            object booking_on_invoice = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "booking_on_invoice");
            if (booking_on_invoice == null || booking_on_invoice == DBNull.Value || booking_on_invoice == "") booking_on_invoice = "N";
            booking_on_invoice = booking_on_invoice.ToString().ToUpper();
            PState.var["booking_on_invoice"] = booking_on_invoice;
        }
    }

    bool booking_on_invoice() {
        if (PState.var["booking_on_invoice"] == null) return false;
        return (PState.var["booking_on_invoice"].ToString().ToUpper() == "S");
    }

    public override void DoCommand(string command)
    {
        string cmd = HelpForm.GetFieldLower(command, 0);

        if (!cmd.EndsWith("showcase")) return;
        object idshowcase = CfgFn.GetNoNullInt32( HelpForm.GetFieldLower(command, 1));
        object idstore = CfgFn.GetNoNullInt32( HelpForm.GetFieldLower(command, 2));
        string Query;

        Query = "SELECT stocktotalview.idstore as idstore, list.idlist as idlist,list.intcode as intcode, list.description as description, ";
        Query += " stocktotalview.number as number, stocktotalview.ordered as ordered, stocktotalview.booked as booked,listclass.title as listclasstitle,";
        Query += " listclass.authrequired as authorizationrequired ";
        Query += " FROM showcasedetail join list on (showcasedetail.idlist=list.idlist) ";
        Query += " join stocktotalview on (list.idlist=stocktotalview.idlist) ";
        Query += " join listclass on (list.idlistclass=listclass.idlistclass) ";
        Query += " WHERE showcasedetail.idshowcase=" + idshowcase + " and stocktotalview.idstore=" + idstore;
        Query += " AND list.active='S'";
        //Query += " AND (stocktotalview.number - stocktotalview.booked)>0";  //Solo la merce disponibile
        Query += " order by description asc ";


        //string Query = "select S.idlist,S.idstore, S.intcode,S.list as description,	ST.number,ST.ordered,ST.booked, " +
        //        "S.listclass as listclasstitle,S.authrequired as authorizationrequired," +
        //        "convert(  decimal(19,2),	ROUND(	 ( SUM ( S.residual * S.amount	) /ST.number)	,2	 ))	as avgprice " +
        //        "FROM showcasedetail SC join  stockview S on S.idlist=SC.idlist " +
        //        "join stocktotal ST on S.idlist=ST.idlist and S.idstore=ST.idstore " +
        //        "where "+
        //        QHS.AppAnd(QHS.CmpGt("S.amount",0),QHS.CmpGt("residual",0),QHS.CmpEq("S.idstore",idstore),QHS.CmpEq("SC.idshowcase",idshowcase))+
        //        " group by S.idlist,S.idstore, S.intcode,S.list,ST.number,ST.ordered,ST.booked, S.listclass,S.authrequired " +
        //        " order by description asc";

        if (booking_on_invoice()) {
            Query = "select S.idlist,S.idstore, S.intcode,S.list as description,	S.available, S.idstock," +
                    "S.listclass as listclasstitle,S.authrequired as authorizationrequired," +
                    "convert(decimal(19,2),ROUND(S.amount/ S.number,2))	as price " +
                    "FROM showcasedetail SC join  stockview S on S.idlist=SC.idlist " +
                    "where " +
                    QHS.AppAnd(QHS.CmpGt("S.amount", 0), QHS.CmpGt("S.available", 0), QHS.CmpEq("S.idstore", idstore), QHS.CmpEq("SC.idshowcase", idshowcase)) +
                    " order by description asc";
        }



        DataTable DT = Conn.SQLRunner( Query);
        if (DT != null && DT.Rows.Count != 0) {
            if (booking_on_invoice()) {
                foreach (DataRow R1 in DT.Select(null, "idstock")) {
                    if (R1.RowState == DataRowState.Deleted) continue;
                    string flt2 = QHS.AppAnd(QHC.MCmp(R1, "idlist", "idstore"), QHC.CmpGt("idstock", R1["idstock"]));
                    foreach (DataRow R2 in DT.Select(flt2)) R2.Delete();

                }

                DT.AcceptChanges();
            }

            RenderCategoryTable(DT);
        }

        string filter;
        filter = QHS.CmpEq("idshowcase", idshowcase);
        DT= Conn.RUN_SELECT("showcase", "title", null, filter, null, false);
        if (DT == null) return;
        titoloVetrina.Text = "<strong>Vetrina attualmente selezionata:</strong>&nbsp;" + DT.Rows[0]["title"].ToString();

        filter = QHS.CmpEq("idstore", idstore);
        DT = Conn.RUN_SELECT("store", "description,deliveryaddress", null, filter, null, false);
        if (DT == null) return;
        lblStore.Text = "<strong>Magazzino:&nbsp;</strong>" + DT.Rows[0]["description"] ;        
        LabAddress.Text= "<strong>Indirizzo:&nbsp;</strong>" + DT.Rows[0]["deliveryaddress"];
    }

    public void FillShowcases()
    {
        DataTable TStore = Conn.RUN_SELECT("store", "*", null, 
                QHS.AppAnd(QHS.NullOrEq("active","S"),Conn.Security.SelectCondition("store", true)), 
                null, false);

        //DataTable DT = DataAccess.RUN_SELECT(Conn, "showcase", "*", "title asc", null, false);
        string Query = " SELECT showcase.idshowcase as idshowcase, showcase.idstore as idstore, showcase.title as title FROM showcase JOIN store ";
        Query += " on (showcase.idstore = store.idstore) WHERE store.active='S'";

        DataTable DT = Conn.SQLRunner( Query);
        if (DT == null || DT.Rows.Count == 0) return;

        //Cancella le vetrine non associate a magazzini autorizzati
        foreach (DataRow r in DT.Select()) {
            string search = QHS.CmpEq("idstore", r["idstore"]);
            if (TStore.Select(search).Length > 0) continue;
            r.Delete();
        }
        DT.AcceptChanges();


        foreach (DataRow DR in DT.Rows)
        {
            string Label = DR["title"].ToString();
            string id = DR["idshowcase"].ToString();
            string idstore = DR["idstore"].ToString();
            hwButton HB = new hwButton();
            HB.ID = "btnShowcase_" + id + "_" + idstore;
            HB.CssClass = "showcasebutton";
            /*
            HB.Style.Add("border", "0px");
            HB.Style.Add("background-color", "white");
            HB.Style.Add("cursor", "hand");
            HB.Style.Add();
            */
            HB.Tag = "showcase." + id + "." + idstore;
            HB.Text=Label;

            showcases.Controls.Add(HB);
            HtmlGenericControl br = new HtmlGenericControl("br");
            showcases.Controls.Add(br);

        }


    }

    public void RenderCategoryTable(DataTable DT)
    {
        Table T = new Table();
        int count = 0;
        T.Style.Add("width", "100%");
        T.CellPadding = 0;
        T.CellSpacing = 0;
        foreach (DataRow DR in DT.Rows)
        {
            TableRow TR = new TableRow();
            if (count % 2 == 0) TR.Style.Add("background-color", "#dddddd");
            else
                TR.Style.Add("background-color", "#bababa");

            TableCell TC=new TableCell();
            TC.Text = GetItemDetail(DR);
            
            TC.Style.Add("width", "100%");

            TR.Cells.Add(TC);
            T.Rows.Add(TR);
            count++;
        }

        items.Controls.Add(T);

    }
    
    public string GetItemDetail(DataRow DR)
    {
        string outputstr = "";
        string code = DR["intcode"].ToString();
        string description = DR["description"].ToString();
        bool skip = false;
        //if (code == "AA01327")
        //    skip = true;
        //if (code == "AA00257")
        //    skip = true;


        int idlist = CfgFn.GetNoNullInt32(DR["idlist"]);
        int idstore = CfgFn.GetNoNullInt32(DR["idstore"]);
        int idstock = 0;
        decimal price = 0;
        if (booking_on_invoice()) {
            idstock = CfgFn.GetNoNullInt32(DR["idstock"]);
            price = CfgFn.GetNoNullDecimal(DR["price"]); //era avgprice
        }

        decimal disponibili = 0;
        decimal number = 0;

        int availability = 0;
        string listclass = DR["listclasstitle"].ToString();
         

        string requiresauth="";
      
        //string semaphore = "<img src=\"Immagini/tl_none.png\" alt=\"Disponibile\">";
        string semaphore = "";
        if (DR["authorizationrequired"] != null)
            if (DR["authorizationrequired"].ToString().ToUpper() == "S")
                requiresauth = "Richiede Autorizzazione";
        int field_to_match = idstock;

        if (!booking_on_invoice()) {
            field_to_match = idlist;

            number = CfgFn.GetNoNullDecimal(DR["number"]);
            decimal booked = CfgFn.GetNoNullDecimal(DR["booked"]);
            decimal ordered = CfgFn.GetNoNullDecimal(DR["ordered"]);
            disponibili = number - booked;
            if (disponibili < 0) disponibili = 0;

            if (disponibili > 0)
                semaphore = "<img src=\"Immagini/tl_green.png\" alt=\"Disponibile\">";
            else if (disponibili == 0 && ordered > 0)
                semaphore = "<img src=\"Immagini/tl_yellow.png\" alt=\"In ordinazione\">";
            else if (disponibili == 0 && ordered == 0)
                semaphore = "<img src=\"Immagini/tl_red.png\" alt=\"Non disponibile\">";
            else if (disponibili <= 0)
                semaphore = "<img src=\"Immagini/tl_red.png\" alt=\"Non disponibile\">";

        }
        else {
            availability= CfgFn.GetNoNullInt32(DR["available"]);
        }
        string itemimage="";

        if (HasImage(idlist))
            itemimage = "<img src=\"GetItemImage.aspx?idlist=" + idlist + "\" style=\"width: 100px;\"/>";
        else
            itemimage = "<img src=\"Immagini/imagenotavailable.png\" style=\"width: 100px;\"/>";

        outputstr += "<table class=\"normalwrap\"  width=\"100%\"><tr><td style=\"width: 98%;\">"; //valign=\"top\"
        outputstr += "<p style=\"font-size: 13px; text-align:left;\"><b>Codice Articolo:</b>&nbsp;" + HttpUtility.HtmlEncode(code) + "</p>";
        outputstr += "<p style=\"font-size: 13px; text-align:left;\"><b>Class. Merceologica:</b>&nbsp;" + HttpUtility.HtmlEncode(listclass) + "</p>";
        

            if (booking_on_invoice()) {
                outputstr += "<p style=\"font-size: 13px; text-align:left;\"><b>Prezzo unitario:</b>&nbsp;" + HelpForm.StringValue(price, "x.y.n") + "</p>";
                outputstr += "<p style=\"font-size: 13px; text-align:left;\"><b>Disponibili in magazzino:</b>&nbsp;" + HelpForm.StringValue(availability, "x.y.n") + "</p>";
            }
            else {
                outputstr += "<p style=\"font-size: 13px; text-align:left;\"><b>Giacenza in magazzino:</b>&nbsp;" + HelpForm.StringValue(number, "x.y.n") + "</p>";
                outputstr += "<p style=\"font-size: 13px; text-align:left;\"><b>Disponibili in magazzino:</b>&nbsp;" + HelpForm.StringValue(disponibili, "x.y.n") + "</p>";
            }

            //if (skip) {
            //    outputstr += "</td>";
            //    outputstr += "</tr></table><br/>";
            //    return outputstr;
            //}

            QueryCreator.MarkEvent("code:" + code + " listclass:" + listclass + " description: " + HttpUtility.HtmlEncode(description));
        
        outputstr += "<p style=\"width: 98%; text-align:justify ;font-size: 13px;\"><strong>Descrizione:</strong><br/><i>" +
                HttpUtility.HtmlEncode(description) + "</i></p>";

        

        outputstr += "<p style=\"width: 98%; font-size: 11px; color: red; text-align: right;\">"+requiresauth+"</p>";
        outputstr += "</td>";
        outputstr += "<td style=\"width: 300px;\"><center>" + itemimage + "</center></td>";  //valign=\"center\"
        outputstr += "<td style=\"width: 80px;\"><center>" + semaphore + "</center></td>";  //  valign=\"center\"
        outputstr += "</tr><tr><td colspan=\"3\">";
        outputstr += "<div style=\"position: relative; bottom:0px;background-color:#cccccc; width:100%;text-align: right;font-size:12px;\">";
        outputstr += "Quantità:<input onfocus=\"document.getElementById(this.id).className='focused';\" onblur=\"document.getElementById(this.id).className='';\" id=\"quant" + field_to_match + "\" style=\"text-align:right;\" type=\"text\" size=\"5\" value=\"1\">&nbsp;&nbsp;&nbsp;";
        outputstr += "<input type=\"button\" onclick=\"javascript:inc('quant" + field_to_match + "');\" value=\"+\"/>";
        outputstr += "<input type=\"button\" onclick=\"javascript:dec('quant" + field_to_match + "');\" value=\"-\"/>";
        outputstr += "<input type=\"button\" onclick=\"javascript:addtocart('" + idlist + "','" + idstore + "','" + HelpForm.StringValue(price, "x.y.n") + "','" + field_to_match + "');\" value=\"Aggiungi al Carrello\"/>";
        outputstr += "</div></td>";
        outputstr += "</tr></table><br/>";

       
        return outputstr;
    }

    public bool HasImage(int idlist)
    {
        string filter = QHS.CmpEq("idlist", idlist);
        DataTable T = Conn.RUN_SELECT("list", "*", null, filter, null, false);
        if (T == null || T.Rows.Count == 0) return false;
        DataRow DR = T.Rows[0];
        if (DR["pic"].Equals(DBNull.Value))
            return false;
        else
            return true;

    }
}
