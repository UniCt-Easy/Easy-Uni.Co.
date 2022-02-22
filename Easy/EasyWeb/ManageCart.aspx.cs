
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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using funzioni_configurazione;
using HelpWeb;
using AllDataSet;
using metadatalibrary;
using funzioni_configurazione;
using EasyWebReport;
using funzioni_configurazione;
using System.Xml;



public partial class ManageCart : System.Web.UI.Page {

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
				decimal price =
					CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), Request.QueryString["price"],
						"x.y.n"));
				if (idlist == 0) return;
				if (quantity == 0) return;

				if (Session["Cart"] == null) {
					AL = new ArrayList();
					Session["Cart"] = AL;
				}
				else {
					AL = (ArrayList) Session["Cart"];
				}
					

				// Find if an item with same idlist and idstore exists in arraylist
				cartitem CI;
				bool found = false;
				int index;
				for (index = 0; index < AL.Count; index++) {
					CI = (cartitem) AL[index];
					if (CI.idlist == idlist && CI.idstore == idstore && CI.price == price && CI.idstock == idstock) {
						found = true;
						CI.quantity += quantity;
						break;
					}
				}

				if (!found) {
					CI = new cartitem();
					CI.idlist = idlist;
					CI.idstore = idstore;
					CI.quantity = quantity;
					CI.price = price;
					CI.idstock = idstock;
					AL.Add(CI);
				}

				myXmlWriter.WriteStartDocument();
				myXmlWriter.WriteStartElement("datagrid");
				myXmlWriter.WriteStartElement("htmlcode");
				htmltext += "<fieldset>";
				htmltext += "<legend style=\"text-align :center\">Operazione Effettuata</legend>";

				htmltext += "<div class=\"row\">";
				htmltext += "<div class=\"col-12 text-center\">";
				htmltext += "<label>Gli articoli da Lei scelti sono stati aggiunti al carrello</label>";
				htmltext += "</div>";
				htmltext += "</div>"; //chiude la rows

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
					htmltext += "<div class=\"col-12 text-center\">";
					htmltext += "<label>Il suo carrello è vuoto.</label>";
					htmltext += "</div>";
					htmltext += "</div>"; //chiude la rows

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
					AL = (ArrayList) Session["Cart"];
					if (AL.Count == 0) return;

					DataAccess Conn = GetVars.GetUserConn(Page);
					QueryHelper QHS = Conn.GetQueryHelper();

					cartitem CI;
					//htmltext += "<fieldset style=\"background-color: #eeeeee;\">";
					htmltext += "<div class=\"row\">";
					htmltext += "<div class=\"col-md-12 text-center\">";
					htmltext += "<label>Articoli attualmente nel carrello</label>";
					htmltext += "</div>";
					htmltext += "</div>"; //chiude la rows

					htmltext += "<div class=\"row\">";
					htmltext += "<div class=\"col-md-12\">";
					htmltext += "<table class=\"table table-striped\";>";
					//htmltext += "<thead><tr style=\"background-color:#d9edf7;color:#000000;\">";
					htmltext += "<thead><tr>";

					htmltext += "<thead><tr><th>Articolo</th><th>Class.Merceologica</th>";
					htmltext += "<th>Quantità</th></tr></thead><tbody>";

					int counter;
					string bgcolor = "";
					for (counter = 0; counter < AL.Count; counter++) {
						CI = (cartitem) AL[counter];
						//if (counter % 2 == 0)
						//    bgcolor = "#d9edf7;";//bgcolor = "#eaeaea;";
						//else
						//    bgcolor = "#c4e3f3;";//bgcolor = "#bababa;";
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

						/*
						filter = QHS.CmpEq("idstore", CI.idstore);
						T = Conn.RUN_SELECT("store", "description", null, filter, null, false);
						storedescription=T.Rows[0]["description"].ToString();
						*/

						htmltext += "<tr style=\"background-color:" + bgcolor + "\">";
						htmltext += "<td><style=\"text-align: justify;\">" + itemdescription + "</td>";
						htmltext += "<td><style=\"text-align: left;\">" + listclass + "</td>";
						htmltext += "<td><style=\"text-align: center;\">" + CI.quantity.ToString() + "</td>";
						htmltext += "</tr>";
					}

					htmltext += "</tbody></table>";

					htmltext += "</div>"; // chiude class col-md-12
					htmltext += "</div>"; //chiude la rows



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
					htmltext += "<p>Il suo carrello è già vuoto.</p>";
				}
				else {
					Session["Cart"] = null;

					htmltext += "<p>Il suo carrello è stato svuotato come richiesto.</p>";
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
