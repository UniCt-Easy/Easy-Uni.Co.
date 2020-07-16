/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using System.Xml;
using System.IO;
using System.Text;
using HelpWeb;

public partial class XMLRequestList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XmlTextWriter myXmlWriter = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);


        // This Page will return an XML
        Int16 PageNumber;
        string TxtBoxId;
        string RawHTMLTableData;
        string DivElencoId;
        string DestroyCLM;
        Page.Response.ContentType = "text/xml";
        Page.Response.Charset = "utf-8";
        Page.Response.CacheControl = "no-cache";
        Page.Response.Expires = -1;
        Page.Response.AddHeader("Pragma", "no-cache");
        CurrentListManager CLM = hwListManager.GetCurrentListManager(this.Page);
        DestroyCLM = Request.QueryString["DestroyCLM"];
        if (DestroyCLM == "Y")
        {
            hwListManager.SetCurrentListManager(this.Page, null);
            Page.Response.End();
            return;
        }

        try
        {
            PageNumber = Int16.Parse(Request.QueryString["PageNumber"]);
        } catch(Exception Ex)
        {
            PageNumber = 1;

        }
        
        TxtBoxId = Request.QueryString["TxtBoxId"];
        DivElencoId = Request.QueryString["DivElencoId"];

        if (TxtBoxId!=null && TxtBoxId.ToString().Trim() != "")
            CLM.txtClientID = TxtBoxId;
        else
            CLM.txtClientID = null;

        RawHTMLTableData = hwListManager.doSubsequentRequest(this.Page, PageNumber);
        RawHTMLTableData = RawHTMLTableData.Replace("<%=Elenco.ClientID%>", DivElencoId);
        myXmlWriter.WriteStartDocument();
        myXmlWriter.WriteStartElement("datagrid");
        myXmlWriter.WriteStartElement("htmlcode");

        myXmlWriter.WriteCData(RawHTMLTableData);
        myXmlWriter.WriteEndElement();
        myXmlWriter.WriteStartElement("meta");
        myXmlWriter.WriteStartElement("totalpages");

        // Write Value Here for total pages (determined at runtime)
        myXmlWriter.WriteValue(CLM.totpages.ToString());
        myXmlWriter.WriteEndElement();
        myXmlWriter.WriteStartElement("title");

        // TableName
        //        myXmlWriter.WriteValue(CLM.Exclude.TableName);
        myXmlWriter.WriteValue("");
        myXmlWriter.WriteEndElement();
        myXmlWriter.WriteEndElement();
        myXmlWriter.WriteEndElement();
        myXmlWriter.Flush();
        myXmlWriter.Close();
        Page.Response.End();
        
    }
}
