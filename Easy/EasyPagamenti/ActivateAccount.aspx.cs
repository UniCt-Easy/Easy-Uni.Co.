
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyPagamenti.Extra;
using metaeasylibrary;
using metadatalibrary;
using EasyPagamentiDataSet;
using System.Data;
using EasyPagamenti;
public partial class Activate : Page {
    private string email, code;
    private void pulisciCampi() {
        txtEmail.Text = "";
        txtCodice.Text = "";
    }
    private void nascondiCampi() {
        campi.Style.Add(HtmlTextWriterStyle.Display, "none");

    }
    private void mostraLinkLogin() {
        LinkLogin.Style.Add(HtmlTextWriterStyle.Display, "block");
        LinkLogin.Style.Add(HtmlTextWriterStyle.Width, "150px");
        LinkLogin.Style.Add(HtmlTextWriterStyle.Margin, "auto");
        LinkLogin.Style.Add(HtmlTextWriterStyle.Margin, "20px");
    }
    private void mostraLinkResend() {
        LinkResend.Style.Add(HtmlTextWriterStyle.Display, "block");
        LinkResend.Style.Add(HtmlTextWriterStyle.Width, "150px");
        LinkResend.Style.Add(HtmlTextWriterStyle.MarginRight, "auto");
        LinkResend.Style.Add(HtmlTextWriterStyle.MarginTop, "0px");
    }
    protected void Page_Load(object sender, EventArgs e) {
        DataAccess depConn = null;
        string erroreDepConn;
        string depcodeGiven = configManager.getCfg("codicedipartimento").ToString();
        depConn = AccessKit.GetDepartmentConn(depcodeGiven, this.Page, out erroreDepConn);
        if (!string.IsNullOrEmpty(erroreDepConn)) {
            lblMessaggio.Text = erroreDepConn;
        }
        if (IsPostBack) {
            email = txtEmail.Text;
            code = txtCodice.Text;
            if (!Activation.Verify(email, code)) {
                mostraLinkResend();
                lblMessaggio.Text = "Codice non valido o scaduto.";
                return;
            }

            Meta_EasyDispatcher dispatcher = new Meta_EasyDispatcher(depConn);


            var ds = new dsmeta_registry();

            var getData = new GetData();
            getData.InitClass(ds, dispatcher.Conn, "registryreference");
            QueryHelper qhs = dispatcher.Conn.GetQueryHelper();
            var filterByEmail = qhs.CmpEq("email", email);
            getData.GET_PRIMARY_TABLE(filterByEmail);
            var referenceRow = ds.registryreference.First();
            if (referenceRow == null) {
                lblMessaggio.Text = "E-mail non registrata.";
                return;
            }
            if (referenceRow.activewebValue.Equals("S")) {
                nascondiCampi();
                mostraLinkLogin();
                lblMessaggio.Text = "Account già attivato.";
                return;
            }

            referenceRow.activewebValue = "S";

            var postData = new Easy_PostData_NoBL();
            postData.InitClass(ds, dispatcher.Conn);

            var pmc = postData.DO_POST_SERVICE();
            if (pmc.Count > 0) {
                string errore = "";
                foreach (EasyProcedureMessage m in pmc) {
                    errore += m.LongMess + " ";
                }

                lblMessaggio.Text = errore; //"Errore del server dati";
                return;
            }
            nascondiCampi();
            mostraLinkLogin();

            lblMessaggio.Text = "Account attivato";
        }
    }
}
