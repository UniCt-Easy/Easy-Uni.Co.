
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
using System.Web;
using System.Web.UI.WebControls;
using HelpWeb;
using EasyPagamentiDataSet;
using metadatalibrary;
using funzioni_configurazione;
using System.Web.UI.HtmlControls;
using System.Collections;
using q = metadatalibrary.MetaExpression;
using EasyPagamenti;
public partial class showcase_easypagamenti_default :MetaPage {
    showcase_easypagamenti DS;

    public override DataSet GetDataSet() {
        return DS;
    }
    public override DataSet CreateNewDataSet() {
        return new showcase_easypagamenti();
    }
    public override void SetDataSet(DataSet D) {
        DS = (showcase_easypagamenti)D;
    }
    private bool VerificaImporto() {
        ArrayList AR = (ArrayList)Session["Cart"];
        cartitem CI;

        for (int i = 0; i < AR.Count; i++) {
            CI = (cartitem)AR[i];
            if (CfgFn.GetNoNullDecimal(CI.price) == 0) {
                ShowClientMessage("Il prezzo Unitario deve essere maggiore di zero.", "Avviso", System.Windows.Forms.MessageBoxButtons.OK);
                return false;
            }
        }
                return true;
    }
    private void btnPagamento_Click() {
        if (Session["Cart"] != null) {
            if (!VerificaImporto())
                return;
            ApplicationState APS = ApplicationState.GetApplicationState(this);
            MetaData M = APS.Dispatcher.Get("webpayment");
            M.edit_type = "default";
            APS.CallPage(this, M, false);
            //string error = APS.CallPage(this, M, false);
            //if (error != "") {  // nel caso non funzioni il redirect mostra la causa 
            //    ShowClientMessage(error, "Errore", System.Windows.Forms.MessageBoxButtons.OK);
            //}
        }
    }
    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.CanInsert = false;
        Meta.CanCancel = false;
        Meta.CanSave = false;
        Meta.SearchEnabled = false;
        FillShowcases();
    }

    public override void DoCommand(string command) {
        if (command == "VaiAPagamento") {
            btnPagamento_Click();
            return;
        }
        string cmd = HelpForm.GetFieldLower(command, 0);

        if (!cmd.EndsWith("showcase"))
            return;
        object idshowcase = CfgFn.GetNoNullInt32(HelpForm.GetFieldLower(command, 1));
        object idstore = CfgFn.GetNoNullInt32(HelpForm.GetFieldLower(command, 2));
        object magazzinoscelto =  Session["magazzinoscelto"];
        string Query;
        //list.description
        Query = "SELECT stocktotalview.idstore as idstore, list.idlist as idlist,list.intcode as intcode, showcasedetail.title as description, ";
        Query += " stocktotalview.number as number, stocktotalview.ordered as ordered, stocktotalview.booked as booked,listclass.title as listclasstitle,";
        Query += " listclass.authrequired as authorizationrequired , showcasedetail.unitprice as price ,showcasedetail.idupb, showcasedetail.idestimkind, showcase.paymentexpiring,  ";
        Query += " showcasedetail.idivakind, list.insinfo, list.descrforuser, ivakind.rate, ";
		Query += " showcasedetail.competencystart, showcasedetail.competencystop, showcasedetail.idinvkind,showcasedetail.idupb_iva, showcase.idshowcase, ";
        Query += " showcasedetail.idsor1, showcasedetail.idsor2, showcasedetail.idsor3 ";
        Query += " FROM showcase join showcasedetail on (showcasedetail.idshowcase=showcase.idshowcase) ";
        Query += " join list on (showcasedetail.idlist=list.idlist) ";
        Query += " join stocktotalview on (list.idlist=stocktotalview.idlist) ";
        Query += " join listclass on (list.idlistclass=listclass.idlistclass) ";
		Query += " join ivakind on (showcasedetail.idivakind=ivakind.idivakind) ";
		Query += " WHERE showcasedetail.idshowcase=" + idshowcase + " and stocktotalview.idstore=" + magazzinoscelto;
        //Query += " AND list.active='S' AND list.idtassonomia is not null";
        Query += " AND list.active='S' ";
        Query += " order by description asc ";

        DataTable DT = DataAccess.SQLRunner(Conn as DataAccess, Query);
        if (DT != null && DT.Rows.Count != 0) {

            RenderCategoryTable(DT);
        }

        string filter;
        filter = QHS.CmpEq("idshowcase", idshowcase);
        DT = Conn.RUN_SELECT("showcase", "title", null, filter, null, false);
        if (DT == null)
            return;
        titoloVetrina.Text = "<strong>Categoria attualmente selezionata:</strong>" + DT.Rows[0]["title"].ToString();

        filter = QHS.CmpEq("idstore", idstore);
        DT = Conn.RUN_SELECT("store", "description,deliveryaddress", null, filter, null, false);
        if (DT == null)
            return;
        //lblStore.Text = "<strong>Magazzino:</strong>" + DT.Rows[0]["description"];//Hanno chiesto di nascondere le info del magazzino
        //LabAddress.Text = "<strong>Indirizzo:</strong>" + DT.Rows[0]["deliveryaddress"];
    }
        public void FillShowcases() {
        DataTable TStore = Conn.RUN_SELECT("store", "*", null,
                QHS.AppAnd(QHS.NullOrEq("active", "S"), Conn.Security.SelectCondition("store", true)),
                null, false);
        object magazzinoscelto = Session["magazzinoscelto"];
        string f = QHS.CmpEq("store.idstore", magazzinoscelto);
        // Se payment_ldap è configurato ad S, allora mostra solo le vetrine con la maschera compatibile ai servizi a cui l'utente loggato è autorizzato, 
        // ossia se il CF dell'utente loggato è presente in LDAP
        DataTable webconfig = Conn.RUN_SELECT("web_config", "*", null, null, null, false);
        DataRow rwebconf = webconfig.Rows[0];
        bool pagamenti_ldap = (rwebconf["payment_ldap"].ToString().ToUpper() == "S");
        var mascheraServizi = (ulong)CfgFn.GetNoNullInt32(Session["ldap_maschera"] ?? DBNull.Value);
        if (pagamenti_ldap) {
            string filter_maschera = "";
            if (mascheraServizi == 0) {
                //se l'utente non è associato ad alcu servizio, e quindi la sua ldap_maschera resta 0, deve vedere tutte le vetrine col campo 0, ossia non associate ad alcun servizio...
                filter_maschera = (" showcase.flagldapvisibility = 0 ");
                }
            else {
                //...diversamente vedrà solo le vetrine associate al SUO(o suoi) servizio
                filter_maschera = (" (( showcase.flagldapvisibility & " + mascheraServizi + " <> 0) or (showcase.flagldapvisibility= 0 )) ");
                }
            //var val = q.bitNot(0);

            // Deve aggiungere questo filtro: 
            //(showcase.flagldapvisibility == 0) or(showcase.flagldapvisibility & maschera != 0));
            //mascheraServizi rappresenta tutti i servizi a cui la persona è stata associata
            //flagldapvisibility rappresenta tutti i servizi per i quali quella vetrina debba essere visibile
            // se l'and bit a bit delle due maschere da un risultato diverso da 0, vuol dire che quella vetrina deve essere visibile, diversamente nascosta.
            //f = q.add(f, q.or(q.eq("showcase.flagldapvisibility", 0), q.fromString("showcase.flagldapvisibility & " + mascheraServizi + " <> 0"))); //q.cmpMask("showcase.flagldapvisibility",mascheraServizi, val))) ;
            f = QHS.AppAnd(f, filter_maschera);
            }
        string Query = " SELECT showcase.idshowcase as idshowcase, showcase.idstore as idstore, showcase.title as title, (showcase.flagldapvisibility & " + mascheraServizi+ ") as flag_showcase FROM showcase JOIN store ";
        Query += " on (showcase.idstore = store.idstore) WHERE " + f.ToString() + " Order by showcase.title";//store.active='S' and isnull(store.virtual,'S')='S' 

        DataTable DT = DataAccess.SQLRunner(Conn as DataAccess, Query);
        if (DT == null || DT.Rows.Count == 0)
            return;

        //Cancella le vetrine non associate a magazzini autorizzati
        foreach (DataRow r in DT.Select()) {
            string search = QHS.CmpEq("idstore", r["idstore"]);
            if (TStore.Select(search).Length > 0)
                continue;
            r.Delete();
        }
        DT.AcceptChanges();


        foreach (DataRow DR in DT.Rows) {
            string Label = DR["title"].ToString();
            string id = DR["idshowcase"].ToString();
            string idstore = DR["idstore"].ToString();
          
            hwButton HB = new hwButton();
            HB.ID = "btnShowcase_" + id + "_" + idstore;
            HB.CssClass = "showcasebutton";
            HB.Tag = "showcase." + id + "." + idstore;
            HB.Text = Label;
            showcases.Controls.Add(HB);
            HtmlGenericControl br = new HtmlGenericControl("br");
            showcases.Controls.Add(br);
        }


    }

    public void RenderCategoryTable(DataTable DT) {
        Table T = new Table();
        int count = 0;
        T.Style.Add("width", "100%");
        T.CellPadding = 0;
        T.CellSpacing = 0;
        foreach (DataRow DR in DT.Rows) {
            TableRow TR = new TableRow();
            TR.Style.Add("background-color", "#FFFFFF");
            TableCell TC = new TableCell();
            TC.Text = GetItemDetail(DR);

            TC.Style.Add("width", "100%");

            TR.Cells.Add(TC);
            T.Rows.Add(TR);
            count++;
        }

        items.Controls.Add(T);

    }

    public string GetItemDetail(DataRow DR) {
		string descrforuser = "";
		if (!DR["descrforuser"].Equals(DBNull.Value))
			descrforuser = DR["descrforuser"].ToString();
		string insinfo = "";
		if (!DR["insinfo"].Equals(DBNull.Value))
			insinfo = DR["insinfo"].ToString();
		string annotations="";

		string outputstr = "";
        string code = DR["intcode"].ToString();
        string description = DR["description"].ToString();
        bool skip = false;

        int idlist = CfgFn.GetNoNullInt32(DR["idlist"]);
        int idstore = CfgFn.GetNoNullInt32(DR["idstore"]);

        int idinvkind = CfgFn.GetNoNullInt32(DR["idinvkind"]);
        string competencystart ="";
        if (!DR["competencystart"].Equals(DBNull.Value))
        {
            DateTime Dcompetencystart = (DateTime)DR["competencystart"];
            competencystart = Dcompetencystart.ToString("yyyy-MM-dd");
        }
        string competencystop="";
        if (!DR["competencystop"].Equals(DBNull.Value))
        {
            DateTime Dcompetencystop = (DateTime)DR["competencystop"];
            competencystop = Dcompetencystop.ToString("yyyy-MM-dd");
        }
        string idupb_iva = DR["idupb_iva"].ToString();
        int idshowcase = CfgFn.GetNoNullInt32(DR["idshowcase"]);
        int idsor1 = CfgFn.GetNoNullInt32(DR["idsor1"]);
        int idsor2 = CfgFn.GetNoNullInt32(DR["idsor2"]);
        int idsor3 = CfgFn.GetNoNullInt32(DR["idsor3"]);
        string idupb = DR["idupb"].ToString();
        int idivakind = CfgFn.GetNoNullInt32(DR["idivakind"]);
        string idestimkind = DR["idestimkind"].ToString();
        int paymentexpiring = CfgFn.GetNoNullInt32(DR["paymentexpiring"]);
        int idstock = 0;
        decimal price = 0;
        price = CfgFn.GetNoNullDecimal(DR["price"]);
		decimal aliquota = CfgFn.GetNoNullDecimal(DR["rate"]);
		decimal iva = price * aliquota;

		decimal number = 0;
        string listclass = DR["listclasstitle"].ToString();
        string requiresauth = "";
        string semaphore = "";
        if (DR["authorizationrequired"] != null)
            if (DR["authorizationrequired"].ToString().ToUpper() == "S")
                requiresauth = "Richiede Autorizzazione";

        int field_to_match = idstock;
        field_to_match = idlist;
          
        string itemimage = "";

        if (HasImage(idlist))
            itemimage = "<img src=\"GetItemImage.aspx?idlist=" + idlist + "\" style=\"width: 100px;\"/>";
        else
            itemimage = "<img src=\"Immagini/imagenotavailable.png\" style=\"width: 100px;\"/>";
        outputstr += "<div class=\"tabArticolo\">";
        outputstr += "<table class=\"normalwrap\"  width=\"100%\">";
        outputstr += "<tr><td>";

		if (Session["nascondi_voce_class_merc"] != null && Session["nascondi_voce_class_merc"].ToString().ToUpper()!="S") {
			outputstr += "<p style=\"text-align: left;\"><b>Voce:</b>" + HttpUtility.HtmlEncode(code) + "</p>";
			outputstr += "<p style=\"text-align: left;\"><b>Class. Merceologica:</b>" + HttpUtility.HtmlEncode(listclass) + "</p>";
		}

        outputstr += "<p style=\"text-align: justify;\"><strong>Descrizione:</strong><i>" +
                HttpUtility.HtmlEncode(description) + "</i></p>";

		//DateTime start;
		//DateTime stop;
		//if (!DR["competencystart"].Equals(DBNull.Value) && !DR["competencystop"].Equals(DBNull.Value)) {
		//	DateTime.TryParse(DR["competencystart"].ToString(), out start);
		//	DateTime.TryParse(DR["competencystop"].ToString(), out stop);
		//	outputstr += "<p style=\"text-align: left;\"><b>Dal:</b>" + "&nbsp;" + start.ToString("dd/MM/yyyy") + "&nbsp;&nbsp;<b> Al:</b>" + "&nbsp;" + stop.ToString("dd/MM/yyyy") + " </p>";
		//}
		//if (!DR["competencystart"].Equals(DBNull.Value) && DR["competencystop"].Equals(DBNull.Value)) {
		//	DateTime.TryParse(DR["competencystart"].ToString(), out start);
		//	outputstr += "<p style=\"text-align: left;\"><b>Dal:</b>" + "&nbsp;" + start.ToString("dd/MM/yyyy")  + " </p>";
		//}
		//if (DR["competencystart"].Equals(DBNull.Value) && !DR["competencystop"].Equals(DBNull.Value)) {
		//	DateTime.TryParse(DR["competencystop"].ToString(), out stop);
		//	outputstr += "<p style=\"text-align: left;\">" + "<b>Fino Al:</b>" + "&nbsp;" + stop.ToString("dd/MM/yyyy") + " </p>";
		//}

		if (price > 0) {
            outputstr += "<p style=\"text-align: left;\"><b>Prezzo unitario:</b>" + HelpForm.StringValue(price+iva, "x.y.n") + "&nbsp;(di cui <b>iva:</b>" + HelpForm.StringValue(iva, "x.y.n") + ")</p>";
        }

        QueryCreator.MarkEvent("code:" + code + " listclass:" + listclass + " description: " + HttpUtility.HtmlEncode(description));


		if (insinfo.ToUpper() == "S") {
			outputstr += "<p style=\"text-align: left; padding-right: 5px\"><b>" + descrforuser + "&nbsp;</b><br>";
            outputstr += "<input onfocus=\"document.getElementById(this.id).className='focused';\" onblur=\"document.getElementById(this.id).className='';\" id=\"annotations" + field_to_match + "\" style=\"text-align:left;width:100%\" maxlength=\"400\" data-enterdec=\"dataannotation.2...1\" type=\"textarea\" rows=\"2\" height=\"50\" >";
            outputstr += "</p>";
		}

		outputstr += "</td>";
        outputstr += "<td><center>" + itemimage + "</center></td>";
        outputstr += "<td><center>" + semaphore + "</center></td>";
        outputstr += "</tr>";

        outputstr += "<tr><td colspan=\"3\">";
        outputstr += "<div class=\"row\" style=\"position: relative; bottom:0px;background-color:#transparent;text-align: right;\">";        
        
        outputstr += "<div class=\"col-12\">";

        outputstr += "<div class=\"row\">";

        outputstr += "<div class=\"col-8 col-sm-6\">";
        outputstr += "<div class=\"rowlabel\">Quantità:" + "</div>";
        outputstr += "<div class=\"rowinput\"><input onfocus=\"document.getElementById(this.id).className='focused';\" onblur=\"document.getElementById(this.id).className='';\" id=\"quant" + field_to_match + "\" style=\"text-align:right;\"  type=\"text\" size=\"3\" value=\"1\">" + "</div>";
        outputstr += "</div>";

        outputstr += "<div class=\"col-4 col-md-6\">";

        outputstr += "<div class=\"row justify-content-start\">";
        outputstr += "<input type=\"button\" class=\"itembutton\" onclick=\"javascript:inc('quant" + field_to_match + "');\" value=\"+\"/>";
        outputstr += "<input type=\"button\" class=\"itembutton\" onclick=\"javascript:dec('quant" + field_to_match + "');\" value=\"-\"/>";
        outputstr += "</div>";

        outputstr += "</div>";

        outputstr += "</div>";

        outputstr += "</div>";


        outputstr += "<div class=\"col-12\">";


        outputstr += "<div class=\"row\">";


        outputstr += "<div class=\"col-8 col-sm-6\">";
        if (price == 0) {
            outputstr += "<div class=\"rowlabel\">Importo:" + "</div>";
            outputstr += "<div class=\"rowinput\"> <input onfocus=\"document.getElementById(this.id).className='focused';\" onblur=\"document.getElementById(this.id).className='';\" id=\"price" + field_to_match + "\" style=\"text-align:right;\" data-enterdec=\"fixed.2...1\" type=\"text\" size=\"9\" >" + "</div>"; 
			//todo : aggiungere classe per formattare come currency
		}
        outputstr += "</div>";


        outputstr += "<div class=\"col-4 col-sm-6\">";
        outputstr += "<div class=\"row justify-content-start\">";
        outputstr += "<input type=\"button\" class=\"itembutton text-normal\" onclick=\"javascript:addtocart('" + idlist + "','" + idstore + "','" +
            HelpForm.StringValue(price, "x.y.n") + "','" + field_to_match + "','" +idupb+"','"+idestimkind+"','"+ paymentexpiring+"','"+ idivakind + "','" + 
            HelpForm.StringValue(annotations, "x.y.n") + "','" + insinfo + "','" + HelpForm.StringValue(aliquota, "x.y.n") + "'" +
            ",'" + idinvkind + "'" +
            ",'" + competencystart + "'" +
            ",'" + competencystop + "'" +
            ",'" + idupb_iva + "'" +
              ",'" + idshowcase + "'" +
                ",'" + idsor1 + "'" +
                  ",'" + idsor2 + "'" +
                    ",'" + idsor3 + "'" +
            ");\" value=\"Aggiungi al Carrello\"/>";
        outputstr += "</div>";
        outputstr += "</div>";


        outputstr += "</div>";

        outputstr += "</div>";


        outputstr += "</div>";

        outputstr += "</div></td>";
        outputstr += "</tr></table>";
        outputstr += "</div>";
        return outputstr;
    }

    public bool HasImage(int idlist) {
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
