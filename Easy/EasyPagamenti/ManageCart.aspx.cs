
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
using System.Collections;
using System.Web.UI;
using System.Text;
using funzioni_configurazione;
using metadatalibrary;
using System.Xml;
using EasyPagamenti;
using System.Web;

public partial class ManageCart :System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        string action = Request.QueryString["action"];
        ArrayList AL;
        //Hashtable HT;
        XmlTextWriter myXmlWriter = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
        string htmltext = "";
        Page.Response.ContentType = "text/xml";
        Page.Response.Charset = "utf-8";
        /* Pagina che gestisce le chiamate AJAX provenienti dal client
         * invocate da vetrina_default.aspx.
         * utilizza i seguenti parametri URL:
         * - idlist: id dell'articolo in listino
         * - idstore: id magazzino
         * - idstock: id stock
         * - units: numero di unità da prenotare.
         * - action: azione da effetturare. Ha tre valori:
         *   * add: aggiunge al carrello;
         *   * show: mostra il contenuto attuale del carrello;
         *   * empty: svuota il carrello.
         */
        switch (action) {
        case "add": {
                /* Aggiunge articoli al carrello
                 * necessita dei parametri idlist (id articolo), units (quantità),
                 * idstore (id magazzino). Restituisce un XML che contiene
                 * il messaggio di notifica di avvenuto inserimento dell'articolo nel carrello.
                 */

                int idlist = CfgFn.GetNoNullInt32(Request.QueryString["idlist"]);
                int quantity = CfgFn.GetNoNullInt32(Request.QueryString["units"]);
                int idstore = CfgFn.GetNoNullInt32(Request.QueryString["idstore"]);
                int idstock = CfgFn.GetNoNullInt32(Request.QueryString["idstock"]);

                string idinvkind = Request.QueryString["idinvkind"];

                string idupb = Request.QueryString["idupb"];
                string idupb_iva = Request.QueryString["idupb_iva"];
                int idshowcase = CfgFn.GetNoNullInt32(Request.QueryString["idshowcase"]);
                //DateTime competencystart = DateTime.MinValue;
                //DateTime competencystop = DateTime.MaxValue;
                //if (Request.QueryString["competencystart"] != "") {
                //    competencystart = DateTime.ParseExact(Request.QueryString["competencystart"].ToString().Substring(0, 10), "yyyy-MM-dd",
                //                System.Globalization.CultureInfo.InvariantCulture);
                //}
                //if (Request.QueryString["competencystop"] != "") {
                //    competencystop = DateTime.ParseExact(Request.QueryString["competencystop"].ToString().Substring(0, 10), "yyyy-MM-dd",
                //                System.Globalization.CultureInfo.InvariantCulture);
                //}
                string competencystart = Request.QueryString["competencystart"].ToString();
                string competencystop = Request.QueryString["competencystop"].ToString();

                int idsor1 = CfgFn.GetNoNullInt32(Request.QueryString["idsor1"]);
                int idsor2 = CfgFn.GetNoNullInt32(Request.QueryString["idsor2"]);
                int idsor3 = CfgFn.GetNoNullInt32(Request.QueryString["idsor3"]);
                string annotations = Server.UrlDecode(Request.QueryString["annotations"].ToString());
				string insinfo = Request.QueryString["insinfo"];

				string idestimkind = Request.QueryString["idestimkind"];
                int paymentexpiring = CfgFn.GetNoNullInt32(Request.QueryString["paymentexpiring"]);
                int idivakind = CfgFn.GetNoNullInt32(Request.QueryString["idivakind"]);
                decimal price = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), Request.QueryString["price"], "x.y.c"));
				decimal iva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), Request.QueryString["iva"], "x.y.c"));

				if (idlist == 0) return;
                if (quantity == 0) return;

                if (Session["Cart"] == null)
                    AL = new ArrayList();
                else
                    AL = (ArrayList)Session["Cart"];

                // Find if an item with same idlist and idstore exists in arraylist
                cartitem CI;
                bool found = false;
                int index;
                int previousquantity = 0;
                for (index = 0; index < AL.Count; index++) {
                    CI = (cartitem)AL[index];
                    if (CI.idlist == idlist && CI.idstore == idstore && CI.price == price && CI.idstock == idstock) {
                        found = true;
                        previousquantity = CI.quantity;
                        break;
                    }
                }

                if (found) {
                    CI = new cartitem();
                    CI.idlist = idlist;
                    CI.idstore = idstore;
                    CI.quantity = quantity + previousquantity;
                    CI.price = price;
                    //CI.idstock = idstock;
                    CI.idupb = idupb;
                    CI.idestimkind = idestimkind;
                    CI.paymentexpiring = paymentexpiring;
                    CI.idivakind = idivakind;
					CI.annotations = annotations;
					CI.iva = iva;
                    //if (competencystart != DateTime.MinValue)
                        CI.competencystart = competencystart;
                    //if (competencystop != DateTime.MaxValue)
                        CI.competencystop = competencystop;
                    if (idinvkind != "" && idinvkind != "0")
                        CI.idinvkind = idinvkind;
                    if (!string.IsNullOrEmpty(idupb_iva))
                        CI.idupb_iva = idupb_iva;
                    CI.idshowcase = idshowcase;
                        CI.idsor1 = idsor1;
                        CI.idsor2 = idsor2;
                        CI.idsor3 = idsor3;
                        AL[index] = CI;
                }
                else {
                    CI = new cartitem();
                    CI.idlist = idlist;
                    CI.idstore = idstore;
                    CI.quantity = quantity;
                    CI.price = price;
                    //CI.idstock = idstock;
                    CI.idupb = idupb;
                    CI.idestimkind = idestimkind;
                    CI.paymentexpiring = paymentexpiring;
                    CI.idivakind = idivakind;
					CI.annotations = annotations;
					CI.iva = iva;
                    //if (competencystart != DateTime.MinValue)
                        CI.competencystart = competencystart;
                    //if (competencystop != DateTime.MaxValue)
                        CI.competencystop = competencystop;
                    if (idinvkind != "" && idinvkind != "0")
                        CI.idinvkind = idinvkind;
                    if (!string.IsNullOrEmpty(idupb_iva))
                        CI.idupb_iva = idupb_iva;
                    CI.idshowcase = idshowcase;
                        CI.idsor1 = idsor1;
                        CI.idsor2 = idsor2;
                        CI.idsor3 = idsor3;
                        AL.Add(CI);
                }

                Session["Cart"] = AL;
                myXmlWriter.WriteStartDocument();
                myXmlWriter.WriteStartElement("datagrid");
                myXmlWriter.WriteStartElement("htmlcode");
                htmltext += "<fieldset>";
                htmltext += "<legend style=\"text-align :center\">Operazione Effettuata</legend>";

                htmltext += "<div class=\"row\">";
                htmltext += "<div class=\"col-md-2\"></div>";
                htmltext += "<div class=\"col-md-9\">";
                htmltext += "<label>Le voci da Lei scelte sono state aggiunte al Carrello</label>";
                htmltext += "</div>";
                htmltext += "<div class=\"col-md-1\"></div>";
                htmltext += "</div>";//chiude la rows

                htmltext += "</fieldset>";


                myXmlWriter.WriteCData(htmltext);
                myXmlWriter.WriteEndElement();
                myXmlWriter.WriteStartElement("meta");
                myXmlWriter.WriteStartElement("totalpages");
                myXmlWriter.WriteValue("0");
                myXmlWriter.WriteEndElement();
                myXmlWriter.WriteStartElement("title");

                myXmlWriter.WriteValue("");
                myXmlWriter.WriteEndElement();
                myXmlWriter.WriteEndElement();
                myXmlWriter.WriteEndElement();

                myXmlWriter.Flush();
                myXmlWriter.Close();


                break;
            }
        case "show": {
                /* Mostra il carrello corrente (se contiene articoli).
                 * Restituisce un XML contenente il contenuto 
                 * del carrello corrente se esso contiene elementi,
                 * altrimenti un XML contenente un messaggio di
                 * "Carrello Vuoto"
                 */
                if (Session["Cart"] == null) {
                    // Carrello vuoto

                    myXmlWriter.WriteStartDocument();
                    myXmlWriter.WriteStartElement("datagrid");
                    myXmlWriter.WriteStartElement("htmlcode");
                    htmltext += "<div class=\"row\">";
                    htmltext += "<div class=\"col-md-5\"></div>";
                    htmltext += "<div class=\"col-md-4\">";
                    htmltext += "<label>Il suo carrello è vuoto.</label>";
                    htmltext += "</div>";
                    htmltext += "<div class=\"col-md-3\"></div>";
                    htmltext += "</div>";//chiude la rows

                    myXmlWriter.WriteCData(htmltext);
                    myXmlWriter.WriteEndElement();
                    myXmlWriter.WriteStartElement("meta");
                    myXmlWriter.WriteStartElement("totalpages");
                    myXmlWriter.WriteValue("0");
                    myXmlWriter.WriteEndElement();
                    myXmlWriter.WriteStartElement("title");

                    myXmlWriter.WriteValue("");
                    myXmlWriter.WriteEndElement();
                    myXmlWriter.WriteEndElement();
                    myXmlWriter.WriteEndElement();

                    myXmlWriter.Flush();
                    myXmlWriter.Close();

                }
                else {
                    // Visualizza il riepilogo
                    // In base agli id nella HT si prelevano dal DB i codici e le descrizioni degli articoli.
                    // E si visualizza il riepilogo
                    AL = (ArrayList)Session["Cart"];
                    if (AL.Count == 0) return;

                    DataAccess Conn = GetVars.GetUserConn(Page);
                    QueryHelper QHS = Conn.GetQueryHelper();

                    cartitem CI;
                    htmltext += "<div class=\"row\">";
                    htmltext += "<div class=\"col-md-4\"></div>";
                    htmltext += "<div class=\"col-md-4\">";
                    htmltext += "<label>Voci attualmente nel Carrello</label>";
                    htmltext += "</div>";
                    htmltext += "<div class=\"col-md-4\"></div>";
                    htmltext += "</div>";//chiude la rows

                    htmltext += "<div class=\"row\">";
                    htmltext += "<div class=\"col-md-12\">";
                    htmltext += "<table class=\"table table-striped\";>";
                    htmltext += "<thead><tr>";
                    htmltext += "<thead><tr><th>Voce</th><th>Prezzo</th>";
                    //htmltext += "<th>Class.Merceologica</th>";// Hanno chiesto di nasconderla
                    htmltext += "<th>Quantità</th></tr></thead><tbody>";

                    int counter;
                    string bgcolor = "";
                    for (counter = 0; counter < AL.Count; counter++) {
                        CI = (cartitem)AL[counter];
                        bgcolor = "#FFFFFF";
                        string storedescription;
                        string itemdescription;
                        string filter;
                        string listclass;
                        string idlistclass;

                        filter = QHS.CmpEq("idlist", CI.idlist);
                        DataTable T;
                        T = Conn.RUN_SELECT("list", "description,idlistclass", null, filter, null, false);
                        itemdescription = T.Rows[0]["description"].ToString();

                        idlistclass = T.Rows[0]["idlistclass"].ToString();
                        filter = QHS.CmpEq("idlistclass", idlistclass);
                        T = Conn.RUN_SELECT("listclass", "title", null, filter, null, false);
                        listclass = T.Rows[0]["title"].ToString();

                        htmltext += "<tr style=\"background-color:" + bgcolor + "\">";
                        htmltext += "<td><style=\"text-align: justify;\">" + itemdescription + "</td>";
						decimal prezzoivato = CI.price + CI.iva;

						htmltext += "<td><style=\"text-align: justify;\">" + "€ "+prezzoivato.ToString() + "</td>";
                            // htmltext += "<td><style=\"text-align: left;\">" + listclass + "</td>";     // Hanno chiesto di nasconderla
                        htmltext += "<td><style=\"text-align: center;\">" + CI.quantity.ToString() + "</td>";
                        htmltext += "</tr>";
                    }
                    htmltext += "</tbody></table>";

                    htmltext += "</div>";// chiude class col-md-12
                    htmltext += "</div>";//chiude la rows



                    myXmlWriter.WriteStartDocument();
                    myXmlWriter.WriteStartElement("datagrid");
                    myXmlWriter.WriteStartElement("htmlcode");
                    myXmlWriter.WriteCData(htmltext);
                    myXmlWriter.WriteEndElement();
                    myXmlWriter.WriteStartElement("meta");
                    myXmlWriter.WriteStartElement("totalpages");
                    myXmlWriter.WriteValue("0");
                    myXmlWriter.WriteEndElement();
                    myXmlWriter.WriteStartElement("title");

                    myXmlWriter.WriteValue("");
                    myXmlWriter.WriteEndElement();
                    myXmlWriter.WriteEndElement();
                    myXmlWriter.WriteEndElement();

                    myXmlWriter.Flush();
                    myXmlWriter.Close();

                }


            }
            break;
        case "empty": {
                /* Svuota il carrello corrente. 
                 * Restituisce un XML contenente il messaggio di notifica
                 * dell'avvenuto svuotamento, oppure un messaggio di notifica
                 * che avvisa l'utente che il carrello è già vuoto.
                 */
                // azzera il carrello
                if (Session["Cart"] == null) {
                    htmltext += "<p>Il suo Carrello è già vuoto.</p>";
                }
                else {
                    Session["Cart"] = null;

                    htmltext += "<p>Il suo Carrello è stato svuotato come richiesto.</p>";
                }

                myXmlWriter.WriteStartDocument();
                myXmlWriter.WriteStartElement("datagrid");
                myXmlWriter.WriteStartElement("htmlcode");
                myXmlWriter.WriteCData(htmltext);
                myXmlWriter.WriteEndElement();
                myXmlWriter.WriteStartElement("meta");
                myXmlWriter.WriteStartElement("totalpages");
                myXmlWriter.WriteValue("0");
                myXmlWriter.WriteEndElement();
                myXmlWriter.WriteStartElement("title");

                myXmlWriter.WriteValue("");
                myXmlWriter.WriteEndElement();
                myXmlWriter.WriteEndElement();
                myXmlWriter.WriteEndElement();

                myXmlWriter.Flush();
                myXmlWriter.Close();



            }
            break;
        }

        Page.Response.End();

    }


}
