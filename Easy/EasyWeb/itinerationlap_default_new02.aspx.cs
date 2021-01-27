
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
using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using AllDataSet;
using EasyWebReport;
using itinerationFunctions;


public partial class itinerationlap_default_new02 : MetaPage {
    vistaForm_itinerationlap DS;
    CfgItineration Cfg;

    public override DataSet GetDataSet() {
        return DS;
    }
    public override DataSet CreateNewDataSet() {
        return new vistaForm_itinerationlap();
    }
    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_itinerationlap)D;
    }


    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.Name = "Tappa di missione";
        if (formToLink) {
            cmbLocalita.DataSource = DS.foreigncountry;
            cmbLocalita.DataValueField = "idforeigncountry";
            cmbLocalita.DataTextField = "description";
        }
        //Cfg = (CfgItineration)Meta.ExtraParameter;
        txtDataOraInizio.TextChanged += txtDataOraInizio_LeaveTextBoxHandler;
        txtDataOraInizio.AutoPostBack = true;
        txtDataOraTermine.TextChanged += txtDataOraTermine_LeaveTextBoxHandler;
        txtDataOraTermine.AutoPostBack = true;
    }

    public void txtDataOraInizio_LeaveTextBoxHandler(object sender, EventArgs e) {
        return;
    }

    public void txtDataOraTermine_LeaveTextBoxHandler(object sender, EventArgs e) {
        return;
    }



    public override void AfterFill() {
        if (PState.InsertMode) {
            LockUnLockDD();
        }

        RicalcolaGiorniOreMissione();
        RicalcolaNGiorniFrazionario();
    }

    void RicalcolaNGiorniFrazionario() {
        double ngg = GetNfrazionarioGiorni();
        string NGG = HelpForm.StringValue(ngg, "x.y.fixed.5...1");
        txtFrazioneGiorni.Text = NGG;
        //RicalcolaQuotaEsenteTappa();
    }

    double GetNfrazionarioGiorni() {
        if (DS.itinerationlap.Rows.Count == 0)
            return 0;
        return MissFun.GetNFrazionarioGiorni(DS.itinerationlap.Rows[0]);
    }


    void RicalcolaGiorniOreMissione() {
        CommFun.GetFormData(true);
        DataRow Curr = DS.itinerationlap.Rows[0];

        DataRow MissioneRow = Meta.SourceRow.GetParentRow("itinerationitinerationlap");
        MissFun.RicalcolaOreGiorniTappa(MissioneRow, Curr, Cfg);
        int ngiorni = CfgFn.GetNoNullInt32(Curr["days"]);
        int nore = CfgFn.GetNoNullInt32(Curr["hours"]);
        txtGiorni.Text = ngiorni.ToString();
        txtOre.Text = nore.ToString();


    }

    public void LockUnLockDD() {
        if (chkitaliaestero.Checked) {
            cmbLocalita.SelectedIndex = -1;
            cmbLocalita.Enabled = false;
            btnLocalita.Enabled = false;
            if (!PState.IsEmpty && this.CommFun.DrawStateIsDone) {
                DataRow Curr = DS.itinerationlap.Rows[0];
                Curr["idforeigncountry"] = DBNull.Value;

            }
        }
        else {
            cmbLocalita.Enabled = true;
            btnLocalita.Enabled = true;
        }


    }


    public void chkitaliaestero_Click(object sender, EventArgs e) {
        LockUnLockDD();

    }

    protected void Page_Load(object sender, EventArgs e) {

    }
}

