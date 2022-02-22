
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_finvardetail;
using meta_finview;
using meta_upb;
using meta_lcard;
using meta_underwriting;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace finvardetail_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finvardetailTable finvardetail 		=> (finvardetailTable)Tables["finvardetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable finview 		=> (finviewTable)Tables["finview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public lcardTable lcard 		=> (lcardTable)Tables["lcard"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public underwritingTable underwriting 		=> (underwritingTable)Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseview 		=> (MetaTable)Tables["expenseview"];

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
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// FINVARDETAIL /////////////////////////////////
	var tfinvardetail= new finvardetailTable();
	tfinvardetail.addBaseColumns("yvar","nvar","idfin","description","amount","cu","ct","lu","lt","idupb","limit","annotation","idlcard","idunderwriting","rownum","prevision2","prevision3","createexpense","idexp","residual","previousprevision");
	tfinvardetail.defineColumn("!codicebilancio", typeof(string));
	Tables.Add(tfinvardetail);
	tfinvardetail.defineKey("yvar", "nvar", "rownum");

	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new finviewTable();
	tfinview.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","idsor01","idsor02","idsor03","idsor04","idsor05","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	Tables.Add(tfinview);
	tfinview.defineKey("idupb", "idfin");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","expiration","txt","rtf","cu","ct","lu","lt","assured","printingorder","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// LCARD /////////////////////////////////
	var tlcard= new lcardTable();
	tlcard.addBaseColumns("idlcard","title","description","ystart","ystop","active","idman","lt","lu","idstore","extcode");
	Tables.Add(tlcard);
	tlcard.defineKey("idlcard");

	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new underwritingTable();
	tunderwriting.addBaseColumns("idunderwriting","idunderwriter","idsor01","idsor02","idsor03","idsor04","idsor05","cu","ct","lu","lt","title","active","doc","docdate");
	Tables.Add(tunderwriting);
	tunderwriting.defineKey("idunderwriting");

	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new MetaTable("expenseview");
	texpenseview.defineColumn("idexp", typeof(int),false);
	texpenseview.defineColumn("nphase", typeof(byte),false);
	texpenseview.defineColumn("phase", typeof(string),false);
	texpenseview.defineColumn("ymov", typeof(short),false);
	texpenseview.defineColumn("nmov", typeof(int),false);
	texpenseview.defineColumn("parentidexp", typeof(int));
	texpenseview.defineColumn("parentymov", typeof(short));
	texpenseview.defineColumn("parentnmov", typeof(int));
	texpenseview.defineColumn("idformerexpense", typeof(int));
	texpenseview.defineColumn("formerymov", typeof(short));
	texpenseview.defineColumn("formernmov", typeof(int));
	texpenseview.defineColumn("ayear", typeof(short),false);
	texpenseview.defineColumn("idfin", typeof(int));
	texpenseview.defineColumn("codefin", typeof(string));
	texpenseview.defineColumn("finance", typeof(string));
	texpenseview.defineColumn("idupb", typeof(string));
	texpenseview.defineColumn("codeupb", typeof(string));
	texpenseview.defineColumn("upb", typeof(string));
	texpenseview.defineColumn("idsor01", typeof(int));
	texpenseview.defineColumn("idsor02", typeof(int));
	texpenseview.defineColumn("idsor03", typeof(int));
	texpenseview.defineColumn("idsor04", typeof(int));
	texpenseview.defineColumn("idsor05", typeof(int));
	texpenseview.defineColumn("idreg", typeof(int));
	texpenseview.defineColumn("registry", typeof(string));
	texpenseview.defineColumn("cf", typeof(string));
	texpenseview.defineColumn("p_iva", typeof(string));
	texpenseview.defineColumn("idman", typeof(int));
	texpenseview.defineColumn("manager", typeof(string));
	texpenseview.defineColumn("kpay", typeof(int));
	texpenseview.defineColumn("ypay", typeof(short));
	texpenseview.defineColumn("npay", typeof(int));
	texpenseview.defineColumn("paymentadate", typeof(DateTime));
	texpenseview.defineColumn("doc", typeof(string));
	texpenseview.defineColumn("docdate", typeof(DateTime));
	texpenseview.defineColumn("description", typeof(string),false);
	texpenseview.defineColumn("amount", typeof(decimal));
	texpenseview.defineColumn("ayearstartamount", typeof(decimal));
	texpenseview.defineColumn("curramount", typeof(decimal));
	texpenseview.defineColumn("available", typeof(decimal));
	texpenseview.defineColumn("idregistrypaymethod", typeof(int));
	texpenseview.defineColumn("idpaymethod", typeof(int));
	texpenseview.defineColumn("iban", typeof(string));
	texpenseview.defineColumn("cin", typeof(string));
	texpenseview.defineColumn("idbank", typeof(string));
	texpenseview.defineColumn("idcab", typeof(string));
	texpenseview.defineColumn("cc", typeof(string));
	texpenseview.defineColumn("iddeputy", typeof(int));
	texpenseview.defineColumn("deputy", typeof(string));
	texpenseview.defineColumn("refexternaldoc", typeof(string));
	texpenseview.defineColumn("paymentdescr", typeof(string));
	texpenseview.defineColumn("idser", typeof(int));
	texpenseview.defineColumn("service", typeof(string));
	texpenseview.defineColumn("codeser", typeof(string));
	texpenseview.defineColumn("servicestart", typeof(DateTime));
	texpenseview.defineColumn("servicestop", typeof(DateTime));
	texpenseview.defineColumn("ivaamount", typeof(decimal));
	texpenseview.defineColumn("flag", typeof(byte));
	texpenseview.defineColumn("totflag", typeof(byte));
	texpenseview.defineColumn("flagarrear", typeof(string),true,true);
	texpenseview.defineColumn("autokind", typeof(byte));
	texpenseview.defineColumn("idpayment", typeof(int));
	texpenseview.defineColumn("expiration", typeof(DateTime));
	texpenseview.defineColumn("adate", typeof(DateTime),false);
	texpenseview.defineColumn("autocode", typeof(int));
	texpenseview.defineColumn("idclawback", typeof(int));
	texpenseview.defineColumn("clawback", typeof(string));
	texpenseview.defineColumn("clawbackref", typeof(string));
	texpenseview.defineColumn("nbill", typeof(int));
	texpenseview.defineColumn("idpay", typeof(int));
	texpenseview.defineColumn("npaymenttransmission", typeof(int));
	texpenseview.defineColumn("transmissiondate", typeof(DateTime));
	texpenseview.defineColumn("idaccdebit", typeof(string));
	texpenseview.defineColumn("codeaccdebit", typeof(string));
	texpenseview.defineColumn("cigcode", typeof(string));
	texpenseview.defineColumn("cupcode", typeof(string));
	texpenseview.defineColumn("txt", typeof(string));
	texpenseview.defineColumn("cu", typeof(string),false);
	texpenseview.defineColumn("ct", typeof(DateTime),false);
	texpenseview.defineColumn("lu", typeof(string),false);
	texpenseview.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(texpenseview);
	texpenseview.defineKey("idexp", "ayear");

	#endregion


	#region DataRelation creation
	this.defineRelation("upbfinvardetail","upb","finvardetail","idupb");
	this.defineRelation("finviewfinvardetail","finview","finvardetail","idfin");
	this.defineRelation("lcard_finvardetail","lcard","finvardetail","idlcard");
	this.defineRelation("underwriting_finvardetail","underwriting","finvardetail","idunderwriting");
	var cPar = new []{expenseview.Columns["idexp"], expenseview.Columns["ayear"]};
	var cChild = new []{finvardetail.Columns["idexp"], finvardetail.Columns["yvar"]};
	Relations.Add(new DataRelation("expenseview_finvardetail",cPar,cChild,false));

	#endregion

}
}
}
