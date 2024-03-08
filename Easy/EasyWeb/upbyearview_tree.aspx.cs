
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

public partial class upbyearview_tree : MetaPage {
    dsmeta_upbyearview DS;

    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new dsmeta_upbyearview();
    }

    public override void SetDataSet(DataSet D) {
        DS = (dsmeta_upbyearview)D;
    }

    protected override void OnInit(EventArgs e) {
        IsTree = true;
        IsList = true;
        MainTableSelector = upbyearviewtree;

        base.OnInit(e);
    }

    public override void AfterFill() {

        return;
    }

    public override void BeforeFill() {
        upbyearviewtable.doPaginate = "S";
    }
    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.CanSave = false;
        Meta.CanInsert = false;
        Meta.SearchEnabled = false;

        upbyearviewtree.Tag = "upbyearview.tree";// + Meta.edit_type;
        GetData.SetStaticFilter(DS.upbyearview, QHC.AppAnd(QHS.CmpEq("active", "S"), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))));
    }

    public override void AfterActivation(bool firsttime, bool formToLink) {
        if (upbyearviewtree.Nodes.Count > 0) {
            if (upbyearviewtree.Nodes[0].Expanded == false) {
                upbyearviewtree.Nodes[0].Expand();
            }
        }
    }
}
