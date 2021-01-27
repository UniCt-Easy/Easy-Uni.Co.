
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

public partial class upb_tree : MetaPage
{
    dsmeta_upb DS;

    public override DataSet GetDataSet()
    {
        return DS;
    }

    public override DataSet CreateNewDataSet()
    {
        return new dsmeta_upb();
    }

    public override void SetDataSet(DataSet D)
    {
        DS = (dsmeta_upb)D;
    }

    protected override void OnInit(EventArgs e)
    {
        IsTree = true;
        IsList = true;
        MainTableSelector = upbtree;

        base.OnInit(e);
    }

    public override void AfterFill()
    {

        return;
    }

    public override void BeforeFill() {
        upbtable.doPaginate = "S";
    }
    public override void AfterLink(bool firsttime, bool formToLink)
    {
        Meta.CanSave = false;
        Meta.CanInsert = false;
        Meta.SearchEnabled = false;
        if (Meta.edit_type == "treenosec") {
            GetData.MarkSkipSecurity(DS.upb);
        }

        upbtree.Tag = "upb.tree";// + Meta.edit_type;
        if (Meta.edit_type != "treenosec") {
            GetData.SetStaticFilter(DS.upb, Meta.GetFilterForSearch(DS.upb));
        }    
        else {
            GetData.SetStaticFilter(DS.upb, QHS.CmpEq("active","S"));
        }

    }

    public override void AfterActivation(bool firsttime, bool formToLink)
    {
        if (upbtree.Nodes.Count > 0)
        {
            if (upbtree.Nodes[0].Expanded==false)
            {
                upbtree.Nodes[0].Expand();
            }
        }
    }
}
