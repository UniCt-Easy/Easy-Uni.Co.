/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using EasyWebReport;
using stockmail;


public partial class bookingauth : MetaPage
{
    CQueryHelper QHC;
    QueryHelper QHS;
    vistaForm_bookingdetail DS;

    public override void BeforeClosing()
    {
        //Meta.SetUsr("searchdone", null);
    }

    public override DataSet GetDataSet()
    {
        return DS;
    }

    public override DataSet CreateNewDataSet()
    {
        DataSet D = new vistaForm_bookingdetail();
        DataTable T = Conn.CreateTableByName("booking", "*");
        D.Tables.Add(T);
        D.Relations.Add("rel",T.Columns["idbooking"],
                        D.Tables["bookingdetail"].Columns["idbooking"] , false);
        return D;
    }

    public override void SetDataSet(DataSet D)
    {
        DS = (vistaForm_bookingdetail)D;
    }

    public override void AfterLink(bool firsttime, bool formToLink)
    {
        //HelpForm.SetFormatForColumn(DS.bookingdetail.Columns["number"], "N");

        Meta.DefaultListType = "list";
        SearchTable = "bookingdetailview";
        HelpForm.SetFormatForColumn(DS.bookingdetailview.Columns["number"], "n");

        DataAccess.SetTableForReading(DS.sorting1, "sorting");
        DataAccess.SetTableForReading(DS.sorting2, "sorting");
        DataAccess.SetTableForReading(DS.sorting3, "sorting");


        Meta.CanInsert = false;
        Meta.CanInsertCopy = false;
        Meta.CanCancel = false;
        QHS = Conn.GetQueryHelper();
        QHC = new CQueryHelper();
        int idman=CfgFn.GetNoNullInt32(Session["CodiceResponsabile"]);
        if(idman==0) return;
        string filter = QHS.AppAnd(QHS.CmpEq("idman", idman), QHS.IsNull("authorized"));
        GetData.SetStaticFilter(DS.bookingdetailview,filter);

    }
    public override void DoCommand(string command) {
        if (PState.IsEmpty) return;
        DataRow Curr = DS.bookingdetail.Rows[0];
        if (command == "autorizza") {
            Curr["authorized"] = "S";
            CommFun.FreshForm(false, false);
            CommFun.DoMainCommand("mainsave");
            if (DS.HasChanges()) return;
            CommFun.DoMainCommand("mainsetsearch");
            CommFun.DoMainCommand("maindosearch");
        }
    }
    public override void AfterClear()
    {
       /* 
        if (Meta.GetUsr("searchdone") != null) return;
        Meta.SetUsr("searchdone", "S");
        CommFun.DoMainCommand("maindosearch");
       */
        btnAutorizza.Visible = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public override void AfterFill()
    {
        
        if (DS.bookingdetail.Rows[0] == null) return;
        DataRow Curr = DS.bookingdetail.Rows[0];
        if(grpImmagine.Controls.Count!=0)
           grpImmagine.Controls.RemoveAt(0);
        int idlist = CfgFn.GetNoNullInt32(Curr["idlist"]);
        HtmlImage I = new HtmlImage();
        if (idlist == 0) return;
        if (HasImage(idlist))
            I.Src = "GetItemImage.aspx?idlist=" + idlist.ToString();
        else
            I.Src = "Immagini/imagenotavailable.png";
        //I.Style.Add("position", "absolute");
        I.Style.Add("z-index", "101");
        I.Style.Add("top", "14px");
        I.Style.Add("left", "374px");
        I.Style.Add("max-width", "309px");
        I.Style.Add("max-height", "175px");
        I.Style.Add("align", "center");
        I.Style.Add("vertical-align", "center");

        if (Curr["authorized"].ToString() == "") {
            btnAutorizza.Visible = true;
        }

        grpImmagine.Controls.Add(I);
        
    }


    public bool HasImage(int idlist)
    {
        string filter = QHS.CmpEq("idlist", idlist);
        DataTable T = Conn.RUN_SELECT("list", "*", null, filter, null, false);
        if (T == null || T.Rows.Count == 0) return false;
        DataRow DR = T.Rows[0];
        if (DR["pic"].Equals(DBNull.Value))
            return false;
        else
            return true;

    }

    public override void BeforePost() {
        PState.var["BSM"] = null;
        if (DS.Tables["booking"].Select().Length > 0) {
            BookingSendMail BSM = new BookingSendMail(Conn as DataAccess);
            BSM.PrepareMailToSend(DS);
            PState.var["BSM"] = BSM;
        }
    }

    public override void AfterPost() {
        BookingSendMail BSM = PState.var["BSM"] as BookingSendMail;
        if (BSM != null) {
            BSM.SendMail();
            PState.var["BSM"] = null;
        }

    }


}
