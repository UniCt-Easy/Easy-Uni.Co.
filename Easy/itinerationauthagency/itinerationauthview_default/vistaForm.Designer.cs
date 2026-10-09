/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
//HIRES RULES
using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_upb;
using metadatalibrary;
namespace itinerationauthview_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationauthview 		=> (MetaTable)Tables["itinerationauthview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationattachment 		=> (MetaTable)Tables["itinerationattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbitinerationavailable 		=> (MetaTable)Tables["upbitinerationavailable"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// ITINERATIONAUTHVIEW /////////////////////////////////
	var titinerationauthview= new MetaTable("itinerationauthview");
	titinerationauthview.defineColumn("iditineration", typeof(int),false);
	titinerationauthview.defineColumn("statusimage", typeof(string),true,true);
	titinerationauthview.defineColumn("nitineration", typeof(int),false);
	titinerationauthview.defineColumn("yitineration", typeof(short),false);
	titinerationauthview.defineColumn("authstatus", typeof(string),true,true);
	titinerationauthview.defineColumn("authstatusimage", typeof(string),true,true);
	titinerationauthview.defineColumn("description", typeof(string),false);
	titinerationauthview.defineColumn("idreg", typeof(int),false);
	titinerationauthview.defineColumn("registry", typeof(string),false);
	titinerationauthview.defineColumn("start", typeof(DateTime),false);
	titinerationauthview.defineColumn("stop", typeof(DateTime),false);
	titinerationauthview.defineColumn("adate", typeof(DateTime),false);
	titinerationauthview.defineColumn("total", typeof(decimal));
	titinerationauthview.defineColumn("totadvance", typeof(decimal));
	titinerationauthview.defineColumn("lapcount", typeof(int),true,true);
	titinerationauthview.defineColumn("idman", typeof(int));
	titinerationauthview.defineColumn("managertitle", typeof(string));
	titinerationauthview.defineColumn("idauthmodel", typeof(int));
	titinerationauthview.defineColumn("idauthagency", typeof(int),false);
	titinerationauthview.defineColumn("authagencytitle", typeof(string),false);
	titinerationauthview.defineColumn("priority", typeof(int),false);
	titinerationauthview.defineColumn("flagstatus", typeof(string),false);
	titinerationauthview.defineColumn("authorizationdate", typeof(DateTime),false);
	titinerationauthview.defineColumn("iditinerationstatus", typeof(int));
	titinerationauthview.defineColumn("location", typeof(string));
	titinerationauthview.defineColumn("idsor01", typeof(int));
	titinerationauthview.defineColumn("idsor02", typeof(int));
	titinerationauthview.defineColumn("idsor03", typeof(int));
	titinerationauthview.defineColumn("idsor04", typeof(int));
	titinerationauthview.defineColumn("idsor05", typeof(int));
	titinerationauthview.defineColumn("applierannotations", typeof(string));
	titinerationauthview.defineColumn("annotationsrejectapproval", typeof(string));
	titinerationauthview.defineColumn("vehicle_motive", typeof(string));
	titinerationauthview.defineColumn("additionalannotations", typeof(string));
	titinerationauthview.defineColumn("idupb", typeof(string));
	titinerationauthview.defineColumn("annotationsrejectapproval_prec", typeof(string),false);
	titinerationauthview.defineColumn("vehicle_info", typeof(string));
	titinerationauthview.defineColumn("ismanager", typeof(string),false);
	Tables.Add(titinerationauthview);
	titinerationauthview.defineKey("iditineration", "idauthagency");

	//////////////////// ITINERATIONATTACHMENT /////////////////////////////////
	var titinerationattachment= new MetaTable("itinerationattachment");
	titinerationattachment.defineColumn("iditineration", typeof(int),false);
	titinerationattachment.defineColumn("idattachment", typeof(int),false);
	titinerationattachment.defineColumn("attachment", typeof(Byte[]));
	titinerationattachment.defineColumn("filename", typeof(string));
	titinerationattachment.defineColumn("lt", typeof(DateTime),false);
	titinerationattachment.defineColumn("lu", typeof(string),false);
	titinerationattachment.defineColumn("ct", typeof(DateTime),false);
	titinerationattachment.defineColumn("cu", typeof(string),false);
	titinerationattachment.defineColumn("idfilestorage", typeof(string));
	Tables.Add(titinerationattachment);
	titinerationattachment.defineKey("iditineration", "idattachment");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb","idtreasurer","start","stop","cigcode","idepupbkind","flag");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// UPBITINERATIONAVAILABLE /////////////////////////////////
	var tupbitinerationavailable= new MetaTable("upbitinerationavailable");
	tupbitinerationavailable.defineColumn("idupb", typeof(string),false);
	tupbitinerationavailable.defineColumn("codeupb", typeof(string),false);
	tupbitinerationavailable.defineColumn("title", typeof(string),false);
	tupbitinerationavailable.defineColumn("paridupb", typeof(string));
	tupbitinerationavailable.defineColumn("idunderwriter", typeof(int));
	tupbitinerationavailable.defineColumn("idman", typeof(int));
	tupbitinerationavailable.defineColumn("manager", typeof(string),false);
	tupbitinerationavailable.defineColumn("underwriter", typeof(string));
	tupbitinerationavailable.defineColumn("printingorder", typeof(string),false);
	tupbitinerationavailable.defineColumn("requested", typeof(decimal));
	tupbitinerationavailable.defineColumn("granted", typeof(decimal));
	tupbitinerationavailable.defineColumn("previousappropriation", typeof(decimal));
	tupbitinerationavailable.defineColumn("previousassessment", typeof(decimal));
	tupbitinerationavailable.defineColumn("expiration", typeof(DateTime));
	tupbitinerationavailable.defineColumn("assured", typeof(string));
	tupbitinerationavailable.defineColumn("active", typeof(string));
	tupbitinerationavailable.defineColumn("cupcode", typeof(string));
	tupbitinerationavailable.defineColumn("idsor01", typeof(int));
	tupbitinerationavailable.defineColumn("idsor02", typeof(int));
	tupbitinerationavailable.defineColumn("idsor03", typeof(int));
	tupbitinerationavailable.defineColumn("idsor04", typeof(int));
	tupbitinerationavailable.defineColumn("idsor05", typeof(int));
	tupbitinerationavailable.defineColumn("flagactivity", typeof(short));
	tupbitinerationavailable.defineColumn("flagkind", typeof(byte));
	tupbitinerationavailable.defineColumn("newcodeupb", typeof(string));
	tupbitinerationavailable.defineColumn("start", typeof(DateTime));
	tupbitinerationavailable.defineColumn("stop", typeof(DateTime));
	tupbitinerationavailable.defineColumn("cigcode", typeof(string));
	tupbitinerationavailable.defineColumn("idtreasurer", typeof(int));
	tupbitinerationavailable.defineColumn("codetreasurer", typeof(string));
	tupbitinerationavailable.defineColumn("idepupbkind", typeof(int));
	tupbitinerationavailable.defineColumn("flag", typeof(int));
	tupbitinerationavailable.defineColumn("ayear", typeof(short),false);
	tupbitinerationavailable.defineColumn("previsionedisponibile_impegni", typeof(decimal),true,true);
	tupbitinerationavailable.defineColumn("disponibilita_impegni", typeof(decimal),true,true);
	tupbitinerationavailable.defineColumn("missioniupbnoncontabilizzate", typeof(decimal),true,true);
	tupbitinerationavailable.defineColumn("disptotale", typeof(decimal),true,true);
	tupbitinerationavailable.defineColumn("cu", typeof(string),false);
	tupbitinerationavailable.defineColumn("ct", typeof(DateTime),false);
	tupbitinerationavailable.defineColumn("lu", typeof(string),false);
	tupbitinerationavailable.defineColumn("lt", typeof(DateTime),false);
	tupbitinerationavailable.defineColumn("differenzadisponibilita", typeof(decimal));
	Tables.Add(tupbitinerationavailable);
	tupbitinerationavailable.defineKey("ayear", "idupb");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_itinerationauthview_itinerationattachment","itinerationauthview","itinerationattachment","iditineration");
	this.defineRelation("upb_itinerationauthview","upb","itinerationauthview","idupb");
	this.defineRelation("upbitinerationavailable_itinerationauthview","upbitinerationavailable","itinerationauthview","idupb");
	#endregion

}
}
}
