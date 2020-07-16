/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;


public partial class ManageAvanzamentoStati : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {
        string action = Request.QueryString["action"];
        XmlTextWriter myXmlWriter = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
        string htmltext = "";
        Page.Response.ContentType = "text/xml";
        Page.Response.Charset = "utf-8";
        /* Pagina che gestisce le chiamate AJAX provenienti dal client
         * invocate da mandate_default.aspx.
         * utilizza i seguenti parametri URL:
         * - idmankind: id del tipo richiesta
         * - yman: esericio richiesta
         * - nman: numero richiesta
         * - action: azione da effetturare:
         *   * call_nexgetnextoffice: chiama la sp nexgetnextoffice;
         */
        switch (action) {
            case "call_getnextoffice": {
                    /* Mostra i possibili Stati in cui può avanzare la Richiesta.
                     * Restituisce un XML contenente il risultato della sp,
                     * altrimenti un XML contenente un messaggio di
                     * "Nessuno Stato selezionabile"
                     */
                    object idcustomuser = Request.QueryString["idcustomuser"].ToString();
                    object idflowchart = Request.QueryString["idflowchart"].ToString();
                    object idmankind = Request.QueryString["idmankind"].ToString();
                    int len = idmankind.ToString().Length;
                    if (len > 2) idmankind = idmankind.ToString().Substring(1, len - 2);
                    object yman = Request.QueryString["yman"];
                    object nman = Request.QueryString["nman"];
                    object[] parametri = new object[] { idcustomuser, idflowchart, idmankind, yman, nman };

                    Easy_DataAccess UsrConnTemp = GetVars.GetUserConn(this);
                    if (UsrConnTemp == null || UsrConnTemp.Open() == false) {
                        //Il Server del Dipartimento non è in rete. 
                        //Il servizio non è disponibile in quanto il computer potrebbe essere spento.
                        WebLog.Log(this, "Il Server del dipartimento non risponde.");
                        return;
                    }

                    DataSet DNextOffice = UsrConnTemp.CallSP("getNextOffice", parametri, true, 3000);
                    UsrConnTemp.Close();
                    if (DNextOffice == null || DNextOffice.Tables.Count == 0) {
                        WebLog.Log(this, "Errore nel contattare il dipartimento o codice errato.");
                        return;
                    }

                    DataTable TNextOffice = DNextOffice.Tables[0];
                    if (TNextOffice.Rows.Count == 0) {
                        //WebLog.Log(this, "Errore nel contattare il dipartimento  o codice errato.");
                        WebLog.Log(this, "Nessuno Stato selezionabile.");
                        return;
                    }

                    // Visualizza il risultato della sp
                    DataAccess Conn = GetVars.GetUserConn(Page);
                    QueryHelper QHS = Conn.GetQueryHelper();

                    htmltext += "<div class=\"row\">";
                    htmltext += "<div class=\"col-md-12\"></div>";
                    htmltext += "<div class=\"col-md-12\">";
                    htmltext += "<label>Selezionare lo stato in cui porre la Richiesta</label>";
                    htmltext += "</div>";
                    htmltext += "<div class=\"col-md-4\"></div>";
                    htmltext += "</div>";//chiude la rows

                    htmltext += "<div class=\"row\">";
                    htmltext += "<div class=\"col-md-12\">";
                    htmltext += "<table class=\"table table-striped\";>";

                    htmltext += "<thead><tr>";

                    htmltext += "<thead><tr><th>Stato</th><th>Ufficio</th><th>Azione</th>";
                    htmltext += "</tr></thead><tbody>";

                    string bgcolor = "";
                    string filter = "";
                    string mandatestatus = "";
                    string office = "";
                    int indicescelta = 0;
                    if (TNextOffice.Rows.Count == 1) {
                        htmltext = "***";
                    }
                    else {
                        foreach (DataRow R in TNextOffice.Select()) {
                            bgcolor = "#FFFFFF";
                            string indicesceltastrg = indicescelta.ToString();
                            string sceltaiesima = "scelta." + indicesceltastrg;
                            string idbtnscelta = "btnscelta_" + indicesceltastrg;
                            // legge lo stato
                            string idmandatestatus = R["new_idmandatestatus"].ToString();
                            filter = QHS.CmpEq("idmandatestatus", R["new_idmandatestatus"]);
                            DataTable T;
                            T = Conn.RUN_SELECT("mandatestatus", "description", null, filter, null, false);
                            if (T.Rows.Count > 0) {
                                mandatestatus = T.Rows[0]["description"].ToString();
                            }
                            else {
                                mandatestatus = "Stato non trovato";
                            }
                            // legge l'ufficio
                            string idoffice = R["idoffice"].ToString();
                            filter = QHS.CmpEq("idoffice", R["idoffice"]);
                            DataTable Toffice;
                            Toffice = Conn.RUN_SELECT("office", "description", null, filter, null, false);
                            if (Toffice.Rows.Count > 0) {
                                office = Toffice.Rows[0]["description"].ToString();
                            }
                            else {
                                office = "Ufficio non esistente";
                            }
                            htmltext += "<tr style=\"background-color:" + bgcolor + "\">";
                            htmltext += "<td><style=\"text-align: center;\">" + mandatestatus + "</td>";
                            htmltext += "<td><style=\"text-align: center;\">" + office + "</td>";
                            htmltext += "<td><input type=\"button\""
                                + " id=\"" + HttpUtility.HtmlEncode(idbtnscelta) + "\""
                                + " Text=\"Seleziona\""
                                + " runat=\"server\""
                                + " data-getnext=\"" + HttpUtility.HtmlEncode(indicesceltastrg) + "\""
                                + " data-cmd=\"" + HttpUtility.HtmlEncode(sceltaiesima) + "\""
                                + " style=\"text-align: right;\" Value=\"Seleziona\" ID=\"" + HttpUtility.HtmlEncode(idbtnscelta) + "\""
                                + " Tag=\"" + HttpUtility.HtmlEncode(sceltaiesima) + "\"></td>";
                            htmltext += "</tr>";
                            indicescelta++;
                        }

                        htmltext += "</tbody></table>";

                        htmltext += "</div>";// chiude class col-md-12
                        htmltext += "</div>";//chiude la rows
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
