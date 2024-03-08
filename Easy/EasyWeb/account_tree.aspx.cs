
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


public partial class account_tree : MetaPage {
    vistaForm_account DS;
    
    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_account();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_account)D;
    }

    protected override void OnInit(EventArgs e) {
        IsTree = true;
        IsList = true;
        MainTableSelector = accounttree;

        base.OnInit(e);
    }


    public override void BeforeFill() {
        account_table.doPaginate = "S";
    }

    
    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.CanSave = false;
        Meta.CanInsert = false;
        Meta.SearchEnabled = false;
        QueryHelper Q = Meta.QHS;
        string param = Meta.ExtraParameter as string;
        string filterEsercizio = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
        string filter = GetData.MergeFilters(filterEsercizio, param);

        string oldfilter = GetData.MergeFilters(null, DS.accountlevel);
        if (oldfilter != null) GetData.SetStaticFilter(DS.accountlevel, filter);
        GetData.CacheTable(DS.accountlevel);
        if (Meta.edit_type != "treenew") {
            // Filtro su esercizio deve funzionare acnhe su altri eercizi.
            GetData.SetStaticFilter(DS.account, filter);
        }
        GetData.SetSorting(DS.account, "printingorder");


      

        accounttree.Tag = "account." + Meta.edit_type;
        account_table.Tag = "TreeNavigator." + Meta.edit_type;
        //GetData.CacheTable(DS.accountlevel, Q.CmpEq("ayear", Meta.Conn.GetEsercizio()),null,false);
        //GetData.SetStaticFilter(DS.account, Meta.GetFilterForSearch(DS.account));

    }

    public override void AfterActivation(bool firsttime, bool formToLink) {
        if (accounttree.Nodes.Count > 0) {
            if (accounttree.Nodes[0].Expanded == false) {
                accounttree.Nodes[0].Expand();
            }
        }
    }


}
