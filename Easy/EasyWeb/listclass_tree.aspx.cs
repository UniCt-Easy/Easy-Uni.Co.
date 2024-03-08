
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

public partial class listclass_tree : MetaPage {
    vistaForm_listclass_tree DS;

    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_listclass_tree();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_listclass_tree)D;
    }

    protected override void OnInit(EventArgs e) {
        IsTree = true;
        IsList = true;
        MainTableSelector = listclasstree;

        base.OnInit(e);
    }


    public override void BeforeFill() {
        listclass_table.doPaginate = "S";
    }


    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.CanSave = false;
        Meta.CanInsert = false;
        Meta.SearchEnabled = false;


        string filter = Meta.GetFilterForSearch(DS.listclass);
        switch (Meta.edit_type) {
            case "estimatetree":
                filter = QHS.AppAnd(QHS.BitSet("flagvisiblekind", 2), filter);
                break;
            case "mandatetree":
                filter = QHS.AppAnd(QHS.BitSet("flagvisiblekind", 1), filter);
                break;
            case "bookingtree":
                filter = QHS.AppAnd(QHS.BitSet("flagvisiblekind", 0), filter);
                break;
            default:
                break;
        }
        

        listclasstree.Tag = "listclass." + Meta.edit_type;
        GetData.SetStaticFilter(DS.listclass, filter);

    }

    public override void AfterActivation(bool firsttime, bool formToLink) {
        if (listclasstree.Nodes.Count > 0) {
            if (listclasstree.Nodes[0].Expanded == false) {
                listclasstree.Nodes[0].Expand();
            }
        }
    }
}
