
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using EasyPagamenti;
using System.Data;
using HelpWeb;

public partial class sceglimagazzino :System.Web.UI.Page {
    QueryHelper QHS;
    protected void Page_Load(object sender, EventArgs e) {
        labError.Visible = false;
        lblMagazzino.Visible = false;
        DataAccess Conn = GetVars.GetUserConn(Page);
        if (Conn == null) return;

        QHS = Conn.GetQueryHelper();

        string def_val = "";

        string f1 = QHS.AppAnd(QHS.CmpEq("virtual", "S"), QHS.CmpEq("active", "S"));
        bool err = false;

        DataTable T = Conn.SQLRunner("select idstore, description" +
               " from store " +
                " where " + f1, true, -1);
        if (T == null || T.Rows.Count==0) {
            err = true;
			//Tabella STORE vuota
            //task 16480, si vuole nascondere questo messaggio di errore
			labError.Text = "Non vi sono Dipartimenti da selezionare(tabella vuota)";
			labError.Visible = false;
			return;
        }

        err = false;
        T.Columns.Add(new DataColumn("k", typeof(String)));
        foreach (DataRow R in T.Rows) {
            R["k"] = R["idstore"].ToString();
        }

        DataRow rStore = T.Rows[0];
        def_val = rStore["idstore"].ToString();

        T.PrimaryKey = new DataColumn[] { T.Columns["k"] };
        if (T.Rows.Count == 0) return;

        if (!IsPostBack) {
            cmbmagazzino.DataSource = T;
            cmbmagazzino.DataTextField = "description";
            cmbmagazzino.DataValueField = "k";
        }
        cmbmagazzino.DataBind();

        if (!IsPostBack) {
            if (err) {

                try {
                    if (T.Rows.Count > 0) cmbmagazzino.SelectedValue = def_val;
                }
                catch { }
            }
            else {

                try {
                    if (T.Rows.Count > 0) cmbmagazzino.SelectedValue = def_val;
                }
                catch { }
            }


        }
    }

    protected void btncancel_Click(object sender, EventArgs e) {
        Response.Redirect("IndiceReport.aspx");
    }

    protected void btnok_Click(object sender, EventArgs e) {
        Easy_DataAccess Conn = GetVars.GetUserConn(Page);
        bool err = false;

        string sel = cmbmagazzino.SelectedValue;
        if (sel == "" || sel == null) return;

        Session["magazzinoscelto"] = null;
        if (sel != null) {
            Session["magazzinoscelto"] = sel;
        }
        ApplicationState APS = ApplicationState.GetApplicationState(this);
        MetaData M = APS.Dispatcher.Get("showcase");
        M.Name = "Sezioni";
        M.edit_type = "defaultpagamenti";
        APS.CallPage(this, M, false);
    }
}
