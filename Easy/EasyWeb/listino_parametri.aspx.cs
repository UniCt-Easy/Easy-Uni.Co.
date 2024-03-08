
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
using AllDataSet;
using metadatalibrary;
using funzioni_configurazione;

public partial class listino_parametri : MetaPage {
    vistaForm_listino_parametri DS;
    public override DataSet GetDataSet() {
        return DS;
    }
    public override DataSet CreateNewDataSet() {
        return new vistaForm_listino_parametri();
    }
    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_listino_parametri)D;
    }


    protected void Page_Load(object sender, EventArgs e) {

    }

    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.CanSave = false;
        Meta.CanInsert = false;        
        Meta.SearchEnabled = false;
        string filter = QHS.CmpEq("active", "S");
        QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1));
        ApplicationState APS = ApplicationState.GetApplicationState(this);
        MetaData MetaListClass = APS.Dispatcher.Get("listclass");
        filter = QHS.AppAnd(filter, MetaListClass.GetFilterForSearch(DS.listclass));
        GetData.SetStaticFilter(DS.listclass,filter);


    }
    public override bool CanClose(string command) {
        return false;
    }

    public override void AfterClear() {
        base.AfterClear();
        if (PState.var["inserted"] == null) {
            PState.var["inserted"] = "S";
            CommFun.DoMainCommand("maininsert");

        }
    }
    public override void AfterRowSelect(DataTable T, DataRow R) {
        if (R != null) {
            PState.var["idlistclass"] = R["idlistclass"];
            //txtCodClassMerc.Text = R["codelistclass"].ToString();
            //txtDescClassMerc.Text = R["title"].ToString();
        }
    }

    public override void DoCommand(string command) {
        base.DoCommand(command);
        if (command == "Accetta") {
            Hashtable h = new Hashtable();
            if (PState.var["idlistclass"]!=null) {
                h["idlistclass"] = PState.var["idlistclass"];
            }
            else {
                h["idlistclass"] = "";
            }
            
            h["code"] = txtCodClassMerc.Text;
            h["description"] = txtDescrizione.Text;
            PState.CallerPageState.var["filterListino"] = h;
            AppState.ReturnToCaller(this, true); 
        }
        if (command == "Annulla") {
            AppState.ReturnToCaller(this, true);
        }
    }
}
