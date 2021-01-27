
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
using metadatalibrary;
using metaeasylibrary;
using AllDataSet;
using funzioni_configurazione;
using EasyWebReport;

public partial class lcard_web : MetaPage {
    CQueryHelper QHC;
    QueryHelper QHS;
    vistaForm_lcardweb DS;
    object idman;

    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_lcardweb();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_lcardweb)D;
    }


    protected void Page_Load(object sender, EventArgs e) {

    }
    public override void AfterClear() {
        cmbResponsabile.SelectedValue = idman.ToString();
        cmbResponsabile.Enabled = true;
        txtCodice.ReadOnly = false;
        txtDescrizione.ReadOnly = false;
        txtFine.ReadOnly = false;
        txtInizio.ReadOnly = false;
        txtIntestazione.ReadOnly = false;
        chkActive.Enabled = true;
        cmbMagazzino.Enabled = true;
    }
    public override void AfterFill() {
        cmbResponsabile.Enabled = false;
        txtCodice.ReadOnly = true;
        txtDescrizione.ReadOnly = true;
        //txtFine.ReadOnly = false;
        txtInizio.ReadOnly = true;
        txtIntestazione.ReadOnly = true;
        //chkActive.Enabled = false;
        cmbMagazzino.Enabled = false;
        
    }
    public override void AfterLink(bool firsttime, bool formToLink) {
        QHC = new CQueryHelper();
        QHS = Conn.GetQueryHelper();

        idman = CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);
        MetaData.SetDefault(DS.lcard, "idman", idman);
      

        Meta.DefaultListType = "webdefault";
        SearchTable = "lcardview";
        if (formToLink) {
            cmbMagazzino.DataSource = DS.store;
            cmbMagazzino.DataTextField = "description";
            cmbMagazzino.DataValueField = "idstore";

            cmbResponsabile.DataSource = DS.manager;
            cmbResponsabile.DataTextField = "title";
            cmbResponsabile.DataValueField = "idman";
        }
        cmbResponsabile.SelectedValue = idman.ToString();
        cmbResponsabile.Enabled = false;

        if (firsttime) {
            DataAccess SysConn = GetVars.GetSystemDataAccess(this);
            SysConn.RUN_SELECT_INTO_TABLE(DS.virtualuser, null, QHS.CmpEq("codicedipartimento", Conn.GetSys("userdb")), null, true);
            PostData.MarkAsTemporaryTable(DS.virtualuser, false);
        }
        HelpForm.SetDenyNull(DS.lcard.Columns["active"], true);
        Meta.DefaultListType = "default";

        Meta.CanCancel = false;
        Meta.CanInsert = false;
        Meta.CanInsertCopy = false;
    }
}
