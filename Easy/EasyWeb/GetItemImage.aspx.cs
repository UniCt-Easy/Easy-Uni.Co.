
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
using EasyWebReport;
using HelpWeb;
using System.IO;
using metadatalibrary;
using metaeasylibrary;

public partial class GetItemImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idlist = Request.QueryString["idlist"];
        if (idlist == null||idlist=="") return;

        DataAccess Conn = GetVars.GetUserConn(Page);
        QueryHelper QHS;
        QHS = Conn.GetQueryHelper();
        string filter=QHS.CmpEq("idlist",idlist);
        DataTable DT = Conn.RUN_SELECT("list", "pic,picext", null, filter, null, false);

        if (DT.Rows.Count == 0) return;
        DataRow DR = DT.Rows[0];
        if (DR["pic"].Equals(DBNull.Value)) return;
        string fileext = DR["picext"].ToString();

        Page.Response.ContentType = "image/"+fileext;
        Page.Response.BinaryWrite((byte[])DR["pic"]);

        Page.Response.End();



    }
}
