
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


using EasyPagamenti;
using EasyPagamenti.Extensions;
using EasyPagamenti.Extra;
using EasyPagamentiDataSet;
using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodeResend :System.Web.UI.Page {
        private string email;

    private void PulisciCampi() {
        txtEmail.Text = "";
    }
    private void NascondiCampi() {
        campi.Style.Add(HtmlTextWriterStyle.Display, "none");

    }
    private void MostraLinkLogin() {
        LinkLogin.Style.Add(HtmlTextWriterStyle.Display, "block");
        LinkLogin.Style.Add(HtmlTextWriterStyle.Width, "150px");
        LinkLogin.Style.Add(HtmlTextWriterStyle.Margin, "auto");
        LinkLogin.Style.Add(HtmlTextWriterStyle.Margin, "20px");
    }
    private void MostraLinkAttiva() {
        LinkAttiva.Style.Add(HtmlTextWriterStyle.Display, "block");
        LinkAttiva.Style.Add(HtmlTextWriterStyle.Width, "150px");
        LinkAttiva.Style.Add(HtmlTextWriterStyle.Margin, "auto");
        LinkAttiva.Style.Add(HtmlTextWriterStyle.MarginTop, "20px");
    }
    protected void Page_Load(object sender, EventArgs e) {
        DataAccess DepConn = null;
        string ErroreDepConn = string.Empty;
        string depcode_given = configManager.getCfg("codicedipartimento").ToString();
        DepConn = AccessKit.GetDepartmentConn(depcode_given, this.Page, out ErroreDepConn);
        if (!string.IsNullOrEmpty(ErroreDepConn)) {
            lblMessaggio.Text = ErroreDepConn;
        }


        if (IsPostBack) {
            if (string.IsNullOrEmpty(txtEmail.Text)) {
                lblMessaggio.Text = "Il Campo E-mail deve essere compilato.";
                return;
            }
            email = txtEmail.Text;

            Meta_EasyDispatcher dispatcher = new Meta_EasyDispatcher(DepConn);

            var metaRegistry = dispatcher.Get("registry");
            var metaReference = dispatcher.Get("registryreference");

            var ds = new dsmeta_registry();

            var getData = new GetData();
            getData.InitClass(ds, dispatcher.Conn, "registryreference");
            var qhs = dispatcher.Conn.GetQueryHelper();
            var filterByEmail = qhs.AppAnd(qhs.CmpEq("email", email),qhs.IsNotNull("userweb"));
            getData.GET_PRIMARY_TABLE(filterByEmail);

            var referenceRow = ds.registryreference.First();
            if (referenceRow == null) {
                lblMessaggio.Text = "E-mail non registrata.";
                return;
            }
            else if (referenceRow.Field<string>("activeweb") != null && referenceRow.Field<string>("activeweb").Equals("S")) {
                NascondiCampi();
                MostraLinkLogin();
                lblMessaggio.Text = "Account già attivato.";
                return;
            }

            try {
                Activation.SendEmail(email, DepConn);
            }
            catch (Exception ex) {
                lblMessaggio.Text = ""; //"Invio dell'e-mail di attivazione fallito.";
                return;
            }
            NascondiCampi();
            MostraLinkAttiva();
            LinkLogin.Style.Add(HtmlTextWriterStyle.Display, "none");
            lblMessaggio.Text = "E-mail di attivazione inviata.";
            return;
        }
    }
}
