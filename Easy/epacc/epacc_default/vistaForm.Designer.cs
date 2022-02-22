
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
using meta_registry;
using meta_account;
using meta_upb;
using meta_manager;
using meta_accmotive;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace epacc_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account 		=> (accountTable)Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epacc 		=> (MetaTable)Tables["epacc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epaccyear 		=> (MetaTable)Tables["epaccyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epaccvar 		=> (MetaTable)Tables["epaccvar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epaccsorting 		=> (MetaTable)Tables["epaccsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingview 		=> (MetaTable)Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epaccsortingview 		=> (MetaTable)Tables["epaccsortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epacctotal 		=> (MetaTable)Tables["epacctotal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveTable accmotive 		=> (accmotiveTable)Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epaccview 		=> (MetaTable)Tables["epaccview"];

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
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","active","annotation","badgecode","birthdate","cf","ct","cu","extmatricula","foreigncf","forename","gender","idcategory","idcentralizedcategory","idmaritalstatus","idnation","idregistryclass","idtitle","location","lt","lu","maritalsurname","p_iva","residence","rtf","surname","title","txt");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new accountTable();
	taccount.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt");
	Tables.Add(taccount);
	taccount.defineKey("idacc");

	//////////////////// EPACC /////////////////////////////////
	var tepacc= new MetaTable("epacc");
	tepacc.defineColumn("yepacc", typeof(short),false);
	tepacc.defineColumn("nepacc", typeof(int),false);
	tepacc.defineColumn("description", typeof(string),false);
	tepacc.defineColumn("idreg", typeof(int));
	tepacc.defineColumn("start", typeof(DateTime));
	tepacc.defineColumn("stop", typeof(DateTime));
	tepacc.defineColumn("txt", typeof(string));
	tepacc.defineColumn("rtf", typeof(Byte[]));
	tepacc.defineColumn("adate", typeof(DateTime),false);
	tepacc.defineColumn("ct", typeof(DateTime),false);
	tepacc.defineColumn("cu", typeof(string),false);
	tepacc.defineColumn("lt", typeof(DateTime),false);
	tepacc.defineColumn("lu", typeof(string),false);
	tepacc.defineColumn("doc", typeof(string));
	tepacc.defineColumn("docdate", typeof(DateTime));
	tepacc.defineColumn("idrelated", typeof(string));
	tepacc.defineColumn("idepacc", typeof(int),false);
	tepacc.defineColumn("paridepacc", typeof(int));
	tepacc.defineColumn("nphase", typeof(short),false);
	tepacc.defineColumn("idman", typeof(int));
	tepacc.defineColumn("flagvariation", typeof(string));
	tepacc.defineColumn("idaccmotive", typeof(string));
	Tables.Add(tepacc);
	tepacc.defineKey("idepacc");

	//////////////////// EPACCYEAR /////////////////////////////////
	var tepaccyear= new MetaTable("epaccyear");
	tepaccyear.defineColumn("idepacc", typeof(int),false);
	tepaccyear.defineColumn("ayear", typeof(short),false);
	tepaccyear.defineColumn("idupb", typeof(string),false);
	tepaccyear.defineColumn("idacc", typeof(string),false);
	tepaccyear.defineColumn("amount", typeof(decimal),false);
	tepaccyear.defineColumn("amount2", typeof(decimal));
	tepaccyear.defineColumn("amount3", typeof(decimal));
	tepaccyear.defineColumn("amount4", typeof(decimal));
	tepaccyear.defineColumn("amount5", typeof(decimal));
	tepaccyear.defineColumn("lt", typeof(DateTime));
	tepaccyear.defineColumn("lu", typeof(string));
	tepaccyear.defineColumn("ct", typeof(DateTime));
	tepaccyear.defineColumn("cu", typeof(string));
	Tables.Add(tepaccyear);
	tepaccyear.defineKey("idepacc", "ayear");

	//////////////////// EPACCVAR /////////////////////////////////
	var tepaccvar= new MetaTable("epaccvar");
	tepaccvar.defineColumn("idepacc", typeof(int),false);
	tepaccvar.defineColumn("nvar", typeof(int),false);
	tepaccvar.defineColumn("adate", typeof(DateTime),false);
	tepaccvar.defineColumn("amount", typeof(decimal),false);
	tepaccvar.defineColumn("description", typeof(string),false);
	tepaccvar.defineColumn("ct", typeof(DateTime),false);
	tepaccvar.defineColumn("cu", typeof(string),false);
	tepaccvar.defineColumn("lt", typeof(DateTime),false);
	tepaccvar.defineColumn("lu", typeof(string),false);
	tepaccvar.defineColumn("amount2", typeof(decimal));
	tepaccvar.defineColumn("amount3", typeof(decimal));
	tepaccvar.defineColumn("amount4", typeof(decimal));
	tepaccvar.defineColumn("amount5", typeof(decimal));
	tepaccvar.defineColumn("yvar", typeof(short),false);
	Tables.Add(tepaccvar);
	tepaccvar.defineKey("idepacc", "nvar");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb","idtreasurer","start","stop","cigcode");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("active","ct","cu","email","lt","lu","passwordweb","phonenumber","rtf","title","txt","userweb","idman","iddivision","wantswarn","idsor01","idsor02","idsor03","idsor04","idsor05","newidman","financeactive");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// EPACCSORTING /////////////////////////////////
	var tepaccsorting= new MetaTable("epaccsorting");
	tepaccsorting.defineColumn("amount", typeof(decimal),false);
	tepaccsorting.defineColumn("adate", typeof(DateTime),false);
	tepaccsorting.defineColumn("description", typeof(string));
	tepaccsorting.defineColumn("ct", typeof(DateTime),false);
	tepaccsorting.defineColumn("cu", typeof(string),false);
	tepaccsorting.defineColumn("lt", typeof(DateTime),false);
	tepaccsorting.defineColumn("lu", typeof(string),false);
	tepaccsorting.defineColumn("idsor", typeof(int),false);
	tepaccsorting.defineColumn("idepacc", typeof(int),false);
	tepaccsorting.defineColumn("ayear", typeof(short),false);
	tepaccsorting.defineColumn("rownum", typeof(int),false);
	tepaccsorting.defineColumn("!percentuale", typeof(string));
	tepaccsorting.defineColumn("!sortingkind", typeof(string));
	tepaccsorting.defineColumn("!sortcode", typeof(string));
	tepaccsorting.defineColumn("!sorting", typeof(string));
	tepaccsorting.defineColumn("kind", typeof(string));
	Tables.Add(tepaccsorting);
	tepaccsorting.defineKey("idepacc", "rownum");

	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new MetaTable("sortingview");
	tsortingview.defineColumn("sortingkind", typeof(string),false);
	tsortingview.defineColumn("idsor", typeof(int),false);
	tsortingview.defineColumn("sortcode", typeof(string),false);
	tsortingview.defineColumn("description", typeof(string),false);
	tsortingview.defineColumn("idsorkind", typeof(int));
	Tables.Add(tsortingview);
	tsortingview.defineKey("idsor");

	//////////////////// EPACCSORTINGVIEW /////////////////////////////////
	var tepaccsortingview= new MetaTable("epaccsortingview");
	tepaccsortingview.defineColumn("idepacc", typeof(int),false);
	tepaccsortingview.defineColumn("rownum", typeof(int),false);
	tepaccsortingview.defineColumn("yepacc", typeof(short),false);
	tepaccsortingview.defineColumn("nepacc", typeof(int),false);
	tepaccsortingview.defineColumn("nphase", typeof(short),false);
	tepaccsortingview.defineColumn("description", typeof(string));
	tepaccsortingview.defineColumn("amount", typeof(decimal),false);
	tepaccsortingview.defineColumn("ayear", typeof(short),false);
	tepaccsortingview.defineColumn("adate", typeof(DateTime),false);
	tepaccsortingview.defineColumn("idsorkind", typeof(int),false);
	tepaccsortingview.defineColumn("idsor", typeof(int),false);
	tepaccsortingview.defineColumn("sortingkind", typeof(string),false);
	tepaccsortingview.defineColumn("sortcode", typeof(string),false);
	tepaccsortingview.defineColumn("sorting", typeof(string),false);
	tepaccsortingview.defineColumn("lt", typeof(DateTime),false);
	tepaccsortingview.defineColumn("lu", typeof(string),false);
	tepaccsortingview.defineColumn("ct", typeof(DateTime),false);
	tepaccsortingview.defineColumn("cu", typeof(string),false);
	tepaccsortingview.defineColumn("kind", typeof(string));
	Tables.Add(tepaccsortingview);
	tepaccsortingview.defineKey("idepacc", "rownum");

	//////////////////// EPACCTOTAL /////////////////////////////////
	var tepacctotal= new MetaTable("epacctotal");
	tepacctotal.defineColumn("idepacc", typeof(int),false);
	tepacctotal.defineColumn("ayear", typeof(short),false);
	tepacctotal.defineColumn("available", typeof(decimal));
	tepacctotal.defineColumn("available2", typeof(decimal));
	tepacctotal.defineColumn("available3", typeof(decimal));
	tepacctotal.defineColumn("available4", typeof(decimal));
	tepacctotal.defineColumn("available5", typeof(decimal));
	tepacctotal.defineColumn("curramount", typeof(decimal));
	tepacctotal.defineColumn("curramount2", typeof(decimal));
	tepacctotal.defineColumn("curramount3", typeof(decimal));
	tepacctotal.defineColumn("curramount4", typeof(decimal));
	tepacctotal.defineColumn("curramount5", typeof(decimal));
	Tables.Add(tepacctotal);
	tepacctotal.defineKey("idepacc", "ayear");

	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new accmotiveTable();
	taccmotive.addBaseColumns("idaccmotive","active","codemotive","ct","cu","lt","lu","paridaccmotive","title","flagdep","flagamm","expensekind");
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	//////////////////// EPACCVIEW /////////////////////////////////
	var tepaccview= new MetaTable("epaccview");
	tepaccview.defineColumn("idepacc", typeof(int),false);
	tepaccview.defineColumn("yepacc", typeof(short),false);
	tepaccview.defineColumn("nepacc", typeof(int),false);
	tepaccview.defineColumn("nphase", typeof(short),false);
	tepaccview.defineColumn("phase", typeof(string),true,true);
	tepaccview.defineColumn("flagvariation", typeof(string));
	tepaccview.defineColumn("description", typeof(string),false);
	tepaccview.defineColumn("amount", typeof(decimal),false);
	tepaccview.defineColumn("amount2", typeof(decimal));
	tepaccview.defineColumn("amount3", typeof(decimal));
	tepaccview.defineColumn("amount4", typeof(decimal));
	tepaccview.defineColumn("amount5", typeof(decimal));
	tepaccview.defineColumn("amountwithsign", typeof(decimal),true,true);
	tepaccview.defineColumn("amountwithsign2", typeof(decimal),true,true);
	tepaccview.defineColumn("amountwithsign3", typeof(decimal),true,true);
	tepaccview.defineColumn("amountwithsign4", typeof(decimal),true,true);
	tepaccview.defineColumn("amountwithsign5", typeof(decimal),true,true);
	tepaccview.defineColumn("totamount", typeof(decimal),true,true);
	tepaccview.defineColumn("curramount", typeof(decimal));
	tepaccview.defineColumn("curramount2", typeof(decimal));
	tepaccview.defineColumn("curramount3", typeof(decimal));
	tepaccview.defineColumn("curramount4", typeof(decimal));
	tepaccview.defineColumn("curramount5", typeof(decimal));
	tepaccview.defineColumn("totcurramount", typeof(decimal),true,true);
	tepaccview.defineColumn("available", typeof(decimal),true,true);
	tepaccview.defineColumn("available2", typeof(decimal),true,true);
	tepaccview.defineColumn("available3", typeof(decimal),true,true);
	tepaccview.defineColumn("available4", typeof(decimal),true,true);
	tepaccview.defineColumn("available5", typeof(decimal),true,true);
	tepaccview.defineColumn("totavailable", typeof(decimal),true,true);
	tepaccview.defineColumn("totalrevenue", typeof(decimal),true,true);
	tepaccview.defineColumn("revenueavailable", typeof(decimal),true,true);
	tepaccview.defineColumn("totalcredit", typeof(decimal),true,true);
	tepaccview.defineColumn("ayear", typeof(short),false);
	tepaccview.defineColumn("idacc", typeof(string),false);
	tepaccview.defineColumn("codeacc", typeof(string),false);
	tepaccview.defineColumn("account", typeof(string),false);
	tepaccview.defineColumn("idupb", typeof(string),false);
	tepaccview.defineColumn("codeupb", typeof(string),false);
	tepaccview.defineColumn("upb", typeof(string),false);
	tepaccview.defineColumn("paridepacc", typeof(int));
	tepaccview.defineColumn("parentyepacc", typeof(short));
	tepaccview.defineColumn("parentnepacc", typeof(int));
	tepaccview.defineColumn("yliv1", typeof(short),true,true);
	tepaccview.defineColumn("nliv1", typeof(int),true,true);
	tepaccview.defineColumn("start", typeof(DateTime));
	tepaccview.defineColumn("stop", typeof(DateTime));
	tepaccview.defineColumn("adate", typeof(DateTime),false);
	tepaccview.defineColumn("idreg", typeof(int));
	tepaccview.defineColumn("registry", typeof(string));
	tepaccview.defineColumn("doc", typeof(string));
	tepaccview.defineColumn("docdate", typeof(DateTime));
	tepaccview.defineColumn("idman", typeof(int));
	tepaccview.defineColumn("manager", typeof(string));
	tepaccview.defineColumn("idrelated", typeof(string));
	tepaccview.defineColumn("flagaccountusage", typeof(int));
	tepaccview.defineColumn("rateiattivi", typeof(string),true,true);
	tepaccview.defineColumn("rateipassivi", typeof(string),true,true);
	tepaccview.defineColumn("riscontiattivi", typeof(string),true,true);
	tepaccview.defineColumn("riscontipassivi", typeof(string),true,true);
	tepaccview.defineColumn("debit", typeof(string),true,true);
	tepaccview.defineColumn("credit", typeof(string),true,true);
	tepaccview.defineColumn("cost", typeof(string),true,true);
	tepaccview.defineColumn("revenue", typeof(string),true,true);
	tepaccview.defineColumn("fixedassets", typeof(string),true,true);
	tepaccview.defineColumn("freeusesurplus", typeof(string),true,true);
	tepaccview.defineColumn("captiveusesurplus", typeof(string),true,true);
	tepaccview.defineColumn("reserve", typeof(string),true,true);
	tepaccview.defineColumn("provision", typeof(string),true,true);
	tepaccview.defineColumn("idaccmotive", typeof(string));
	tepaccview.defineColumn("codemotive", typeof(string));
	tepaccview.defineColumn("lt", typeof(DateTime),false);
	tepaccview.defineColumn("lu", typeof(string),false);
	tepaccview.defineColumn("ct", typeof(DateTime),false);
	tepaccview.defineColumn("cu", typeof(string),false);
	tepaccview.defineColumn("idsor01", typeof(int));
	tepaccview.defineColumn("idsor02", typeof(int));
	tepaccview.defineColumn("idsor03", typeof(int));
	tepaccview.defineColumn("idsor04", typeof(int));
	tepaccview.defineColumn("idsor05", typeof(int));
	tepaccview.defineColumn("cf", typeof(string));
	tepaccview.defineColumn("p_iva", typeof(string));
	Tables.Add(tepaccview);

	#endregion


	#region DataRelation creation
	this.defineRelation("sortingview_epaccsorting","sortingview","epaccsorting","idsor");
	this.defineRelation("epacc_epaccsorting","epacc","epaccsorting","idepacc");
	this.defineRelation("epacc_epaccvar","epacc","epaccvar","idepacc");
	this.defineRelation("account_epaccyear","account","epaccyear","idacc");
	this.defineRelation("upb_epaccyear","upb","epaccyear","idupb");
	this.defineRelation("epacc_epaccyear","epacc","epaccyear","idepacc");
	this.defineRelation("accmotive_epacc","accmotive","epacc","idaccmotive");
	var cPar = new []{epacc.Columns["idepacc"]};
	var cChild = new []{epacc.Columns["paridepacc"]};
	Relations.Add(new DataRelation("epacc_epacc",cPar,cChild,false));

	this.defineRelation("registry_epacc","registry","epacc","idreg");
	this.defineRelation("manager_epacc","manager","epacc","idman");
	this.defineRelation("epacc_epaccview","epacc","epaccview","idepacc");
	#endregion

}
}
}
