
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
using System.Configuration;
using System.Collections.Generic;
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
using System.Linq;
using funzioni_configurazione;

public partial class upb_default_new02 : MetaPage {
    dsmeta_upbdefault DS;

    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new dsmeta_upbdefault();
    }

    public override void SetDataSet(DataSet D) {
        DS = (dsmeta_upbdefault)D;
    }

    protected void Page_Load(object sender, EventArgs e) {

    }
    protected override void OnInit(EventArgs e) {
        IsTree = false;
        IsList = false;

        base.OnInit(e);
    }

    public override void AfterLink(bool firsttime, bool formToLink) {
        GetData.SetStaticFilter(DS.upb, QHS.CmpEq("active", "S"));
        GetData.SetStaticFilter(DS.upb_parent, QHS.CmpEq("active", "S"));
        Meta.StartFilter = QHS.CmpEq("active", "S");

        if (formToLink) {
            cmbUpbParent.DataSource = DS.upb_parent;
            cmbUpbParent.DataValueField = "idupb";
            cmbUpbParent.DataTextField = "codeupb";

            cmbManager.DataSource = DS.manager;
            cmbManager.DataValueField = "idman";
            cmbManager.DataTextField = "title";
        }

        Meta.DefaultListType = "default";
        SearchTable = "upbview";
    }
    public override void AfterClear() {
        base.AfterClear();
        cmbUpbParent.Enabled = true;
        txtCodice.ReadOnly = false;

        if (Meta.edit_type == "createnew02" && PState.var["inserted"] == null) {

            PState.var["inserted"] = "S";
            CommFun.DoMainCommand("maininsert");


        }

    }
    public override void AfterActivation(bool firsttime, bool formToLink) {
        if (firsttime) {
            CalcolaDefaultPerIstitutoCassiere();
        }
    }

    void CalcolaDefaultPerIstitutoCassiere() {
        var cassiere = DS.treasurer.f_Eq("flagdefault",'S');
        if (cassiere.Count() == 1) {            
            MetaData.SetDefault(DS.upb, "idtreasurer", cassiere._First().idtreasurer);
            return;
        }
        cassiere = DS.treasurer.f_Ne("idtreasurer", 0);
        if (cassiere.Count() == 1) {            
            MetaData.SetDefault(DS.upb, "idtreasurer", cassiere.First().idtreasurer);
        }

    }

    public override void AfterFill() {
        base.AfterFill();
        cmbUpbParent.Enabled = PState.InsertMode;
        txtCodice.ReadOnly = !PState.InsertMode;
    }
}
