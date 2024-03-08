
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
using metadatalibrary;
using metaeasylibrary;
using HelpWeb;
using funzioni_configurazione;
using AllDataSet;

public partial class sorting_tree : MetaPage
{
    vistaForm_sorting DS;
    QueryHelper QHS;
    CQueryHelper QHC;
    public override DataSet GetDataSet()
    {
        return DS;
    }

    public override DataSet CreateNewDataSet()
    {
        return new vistaForm_sorting();
    }

    public override void SetDataSet(DataSet D)
    {
        DS = (vistaForm_sorting)D;
    }

    protected override void OnInit(EventArgs e)
    {
        IsTree = true;
        IsList = true;
        MainTableSelector = sortingtree;

        base.OnInit(e);
    }


    public override void AfterLink(bool firsttime, bool formToLink)
    {
        Meta.CanSave = false;
        Meta.CanInsert = false;
        Meta.SearchEnabled = false;
        sortingtree.Tag = "sorting." + Meta.edit_type;
        
        int esercizio = (int)Meta.GetSys("esercizio");

        QHS = Conn.GetQueryHelper();
        object filter = Meta.ExtraParameter;
        string f = null;

        if (filter != null) f = filter.ToString();
        GetData.CacheTable(DS.sortinglevel, f, null, false);
        GetData.SetStaticFilter(DS.sorting,
            QHS.AppAnd(QHS.NullOrEq("start", Meta.GetSys("esercizio")),
                    QHS.NullOrGe("stop", Meta.GetSys("esercizio"))));
    }

    public override void AfterActivation(bool firsttime, bool formToLink)
    {
        if (sortingtree.Nodes.Count > 0)
        {
            if (sortingtree.Nodes[0].Expanded == false)
            {
                sortingtree.Nodes[0].Expand();
            }
        }
    }
         
}
