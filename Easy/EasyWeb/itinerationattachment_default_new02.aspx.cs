
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using AllDataSet;
using System.IO;

public partial class itinerationattachment_default_new02 : MetaPage {
    vistaForm_itinerationattachment DS;
    public override DataSet GetDataSet() {
        return DS;
    }
    public override DataSet CreateNewDataSet() {
        return new vistaForm_itinerationattachment();
    }
    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_itinerationattachment)D;
    }
    protected void Page_Load(object sender, EventArgs e) {
        if (btnFileUpload.HasFile){
            labAttachFileName.Text = Path.GetFileName(btnFileUpload.FileName);
        }
    }

    
public override void AfterLink(bool firsttime, bool formToLink) {
        if (btnFileUpload.HasFile){
            DataRow Curr = DS.itinerationattachment.Rows[0];
            Curr["filename"] = Path.GetFileName(btnFileUpload.FileName);
            Curr["attachment"] = btnFileUpload.FileBytes;
            labAttachFileName.Text = Path.GetFileName(btnFileUpload.FileName);
        }
    }
    public override void AfterFill() {
        if (PState.EditMode){
            btnFileUpload.Visible = false;
        }

        if (PState.InsertMode){
            btnFileUpload.Visible = true;
        }
        DataRow Curr = DS.itinerationattachment.Rows[0];
        if (Curr["attachment"] == DBNull.Value) {
            btnVisualizza.Visible = false;
        }
        else {
            btnVisualizza.Visible = true;
        }
    }
    protected void btnVisualizza_Click(object sender, EventArgs e) {
        string fkey = QHS.CmpKey(DS.itinerationattachment.Rows[0]);
        Session["AttachmentCommand"] = null;
        Session["AttachmentFile"]= DS.itinerationattachment.Rows[0]["attachment"];
        Session["AttachmentFileName"] = DS.itinerationattachment.Rows[0]["filename"].ToString();

        string F = "window.open('AttachmentView.aspx');";
        if (!Page.ClientScript.IsClientScriptBlockRegistered(typeof(Page), "openwin"))
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "openwin", F, true);

    }
    public override void DoCommand(string command) {
        base.DoCommand(command);
        if (command == "visualizza") {
            btnVisualizza_Click(null, null);
            return;
        }

    }
}
