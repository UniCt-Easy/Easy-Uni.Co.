
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_grantload;
using meta_assetgrant;
using meta_assetgrantdetail;
using meta_accmotive;
using metadatalibrary;
namespace grantload_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Scarico risconti e contributi
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public grantloadTable grantload 		{get { return (grantloadTable )Tables["grantload"];}}
	///<summary>
	///Attribuzione di un contributo conto impianti ad un cespite
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public assetgrantTable assetgrant 		{get { return (assetgrantTable )Tables["assetgrant"];}}
	///<summary>
	///Risconto contributo conto impianti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public assetgrantdetailTable assetgrantdetail 		{get { return (assetgrantdetailTable )Tables["assetgrantdetail"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable assetview_grant 		{get { return (MetaTable)Tables["assetview_grant"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable assetview_grantdetail 		{get { return (MetaTable)Tables["assetview_grantdetail"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable epacc_grantdetail 		{get { return (MetaTable)Tables["epacc_grantdetail"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable epacc_grant 		{get { return (MetaTable)Tables["epacc_grant"];}}
	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable underwriting 		{get { return (MetaTable)Tables["underwriting"];}}
	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public accmotiveTable accmotive 		{get { return (accmotiveTable )Tables["accmotive"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public dsmeta(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";
	EnforceConstraints = false;

	#region create DataTables
	MetaTable T;
	//////////////////// GRANTLOAD /////////////////////////////////
	var tgrantload= new grantloadTable();
	tgrantload.addBaseColumns("idgrantload","yload","kind","description","ct","cu","lt","lu","adate");
	Tables.Add(tgrantload);
	tgrantload.defineKey("idgrantload");

	//////////////////// ASSETGRANT /////////////////////////////////
	var tassetgrant= new assetgrantTable();
	tassetgrant.addBaseColumns("idasset","idgrant","idunderwriting","idaccmotive","amount","ygrant","description","doc","docdate","idgrantload","lt","lu","ct","cu","idpiece","idepacc");
	tassetgrant.defineColumn("!ninventario", typeof(Int32));
	tassetgrant.defineColumn("!inventario", typeof(String));
	tassetgrant.defineColumn("!yepacc", typeof(Int16));
	tassetgrant.defineColumn("!nepacc", typeof(Int32));
	tassetgrant.defineColumn("!codemotive", typeof(String));
	tassetgrant.defineColumn("!titlemotive", typeof(String));
	tassetgrant.defineColumn("!codeunderwriting", typeof(String));
	tassetgrant.defineColumn("!codeinv", typeof(String));
	tassetgrant.defineColumn("!inventorytree", typeof(String));
	tassetgrant.defineColumn("!inventoryagency", typeof(String));
	tassetgrant.defineColumn("!titleunderwriting", typeof(String));
	tassetgrant.defineColumn("!cost", typeof(Decimal));
	Tables.Add(tassetgrant);
	tassetgrant.defineKey("idasset", "idgrant", "idpiece");

	//////////////////// ASSETGRANTDETAIL /////////////////////////////////
	var tassetgrantdetail= new assetgrantdetailTable();
	tassetgrantdetail.addBaseColumns("idasset","idgrant","iddetail","ydetail","amount","idgrantload","ct","cu","lt","lu","idpiece","idepacc");
	tassetgrantdetail.defineColumn("!ninventario", typeof(Int32));
	tassetgrantdetail.defineColumn("!inventario", typeof(String));
	tassetgrantdetail.defineColumn("!yepacc", typeof(Int16));
	tassetgrantdetail.defineColumn("!nepacc", typeof(Int32));
	tassetgrantdetail.defineColumn("!codeinv", typeof(String));
	tassetgrantdetail.defineColumn("!inventorytree", typeof(String));
	tassetgrantdetail.defineColumn("!inventoryagency", typeof(String));
	tassetgrantdetail.defineColumn("!cost", typeof(Decimal));
	Tables.Add(tassetgrantdetail);
	tassetgrantdetail.defineKey("idasset", "idgrant", "iddetail", "idpiece");

	//////////////////// ASSETVIEW_GRANT /////////////////////////////////
	T= new MetaTable("assetview_grant");
	T.defineColumn("idasset", typeof(Int32),false);
	T.defineColumn("idpiece", typeof(Int32),false);
	T.defineColumn("idasset_prev", typeof(Int32));
	T.defineColumn("idpiece_prev", typeof(Int32));
	T.defineColumn("idinventory_prev", typeof(Int32));
	T.defineColumn("codeinventory_prev", typeof(String));
	T.defineColumn("inventory_prev", typeof(String));
	T.defineColumn("ninventory_prev", typeof(Int32));
	T.defineColumn("idasset_next", typeof(Int32));
	T.defineColumn("idpiece_next", typeof(Int32));
	T.defineColumn("idinventory_next", typeof(Int32));
	T.defineColumn("codeinventory_next", typeof(String));
	T.defineColumn("inventory_next", typeof(String));
	T.defineColumn("ninventory_next", typeof(Int32));
	T.defineColumn("lifestart", typeof(DateTime));
	T.defineColumn("yearstart", typeof(Int32),true,true);
	T.defineColumn("nassetacquire", typeof(Int32));
	T.defineColumn("ninventory", typeof(Int32));
	T.defineColumn("idcurrlocation", typeof(Int32));
	T.defineColumn("currlocationcode", typeof(String));
	T.defineColumn("currlocation", typeof(String));
	T.defineColumn("idcurrman", typeof(Int32));
	T.defineColumn("currmanager", typeof(String));
	T.defineColumn("idcurrsubman", typeof(Int32));
	T.defineColumn("currsubmanager", typeof(String));
	T.defineColumn("idinv", typeof(Int32),false);
	T.defineColumn("codeinv", typeof(String),false);
	T.defineColumn("idinv_lev1", typeof(Int32),false);
	T.defineColumn("codeinv_lev1", typeof(String),false);
	T.defineColumn("inventorytree", typeof(String),false);
	T.defineColumn("inventorytree_lev1", typeof(String),false);
	T.defineColumn("idinventory", typeof(Int32));
	T.defineColumn("codeinventory", typeof(String),false);
	T.defineColumn("inventory", typeof(String),false);
	T.defineColumn("description", typeof(String),false);
	T.defineColumn("idassetload", typeof(Int32));
	T.defineColumn("idassetloadkind", typeof(Int32));
	T.defineColumn("yassetload", typeof(Int16));
	T.defineColumn("nassetload", typeof(Int32));
	T.defineColumn("idloadmot", typeof(Int32),false);
	T.defineColumn("loadmotive", typeof(String));
	T.defineColumn("loaddescription", typeof(String));
	T.defineColumn("ratificationdate", typeof(DateTime));
	T.defineColumn("loaddate", typeof(DateTime));
	T.defineColumn("loaddoc", typeof(String));
	T.defineColumn("loaddocdate", typeof(DateTime));
	T.defineColumn("loadenactment", typeof(String));
	T.defineColumn("loadenactmentdate", typeof(DateTime));
	T.defineColumn("loadprintdate", typeof(DateTime));
	T.defineColumn("taxable", typeof(Decimal));
	T.defineColumn("taxrate", typeof(Double));
	T.defineColumn("tax", typeof(Decimal),true,true);
	T.defineColumn("abatable", typeof(Decimal),true,true);
	T.defineColumn("unabatable", typeof(Decimal),true,true);
	T.defineColumn("number", typeof(Int32),false);
	T.defineColumn("discount", typeof(Double));
	T.defineColumn("cost", typeof(Decimal),true,true);
	T.defineColumn("revals", typeof(Decimal),true,true);
	T.defineColumn("revals_pending", typeof(Decimal),true,true);
	T.defineColumn("subtractions", typeof(Decimal),true,true);
	T.defineColumn("currentvalue", typeof(Decimal),true,true);
	T.defineColumn("total", typeof(Decimal),true,true);
	T.defineColumn("idassetunload", typeof(Int32));
	T.defineColumn("idassetunloadkind", typeof(Int32));
	T.defineColumn("yassetunload", typeof(Int16));
	T.defineColumn("nassetunload", typeof(Int32));
	T.defineColumn("unloaddate", typeof(DateTime));
	T.defineColumn("idunloadmot", typeof(Int32));
	T.defineColumn("unloadmotive", typeof(String));
	T.defineColumn("unloaddescription", typeof(String));
	T.defineColumn("unloaddoc", typeof(String));
	T.defineColumn("unloaddocdate", typeof(DateTime));
	T.defineColumn("unloadenactment", typeof(String));
	T.defineColumn("unloadenactmentdate", typeof(DateTime));
	T.defineColumn("unloadratificationdate", typeof(DateTime));
	T.defineColumn("unloadregistry", typeof(String));
	T.defineColumn("flag", typeof(Byte),false);
	T.defineColumn("flagunload", typeof(String),true,true);
	T.defineColumn("flagtransf", typeof(String),true,true);
	T.defineColumn("transmitted", typeof(String));
	T.defineColumn("flagload", typeof(String),true,true);
	T.defineColumn("loadkind", typeof(String),true,true);
	T.defineColumn("multifield", typeof(String));
	T.defineColumn("idsor01", typeof(Int32),true,true);
	T.defineColumn("idsor02", typeof(Int32),true,true);
	T.defineColumn("idsor03", typeof(Int32),true,true);
	T.defineColumn("idsor04", typeof(Int32),true,true);
	T.defineColumn("idsor05", typeof(Int32),true,true);
	T.defineColumn("is_unloaded", typeof(String),true,true);
	T.defineColumn("is_loaded", typeof(String),true,true);
	T.defineColumn("idupb", typeof(String));
	T.defineColumn("codeupb", typeof(String));
	T.defineColumn("upb", typeof(String));
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("rtf", typeof(Byte[]));
	T.defineColumn("txt", typeof(String));
	T.defineColumn("idinventoryagency", typeof(Int32),false);
	T.defineColumn("inventoryagency", typeof(String),false);
	T.defineColumn("idlist", typeof(Int32));
	T.defineColumn("intcode", typeof(String));
	T.defineColumn("list", typeof(String));
	T.defineColumn("idinventoryamortization", typeof(Int32));
	T.defineColumn("amortizationquota", typeof(Double));
	T.defineColumn("historical", typeof(Decimal));
	T.defineColumn("ispiece", typeof(String),true,true);
	T.defineColumn("inventorykindvisible", typeof(String),true,true);
	Tables.Add(T);
	T.defineKey("idasset", "idpiece");

	//////////////////// ASSETVIEW_GRANTDETAIL /////////////////////////////////
	T= new MetaTable("assetview_grantdetail");
	T.defineColumn("idasset", typeof(Int32),false);
	T.defineColumn("idpiece", typeof(Int32),false);
	T.defineColumn("idasset_prev", typeof(Int32));
	T.defineColumn("idpiece_prev", typeof(Int32));
	T.defineColumn("idinventory_prev", typeof(Int32));
	T.defineColumn("codeinventory_prev", typeof(String));
	T.defineColumn("inventory_prev", typeof(String));
	T.defineColumn("ninventory_prev", typeof(Int32));
	T.defineColumn("idasset_next", typeof(Int32));
	T.defineColumn("idpiece_next", typeof(Int32));
	T.defineColumn("idinventory_next", typeof(Int32));
	T.defineColumn("codeinventory_next", typeof(String));
	T.defineColumn("inventory_next", typeof(String));
	T.defineColumn("ninventory_next", typeof(Int32));
	T.defineColumn("lifestart", typeof(DateTime));
	T.defineColumn("yearstart", typeof(Int32),true,true);
	T.defineColumn("nassetacquire", typeof(Int32));
	T.defineColumn("ninventory", typeof(Int32));
	T.defineColumn("idcurrlocation", typeof(Int32));
	T.defineColumn("currlocationcode", typeof(String));
	T.defineColumn("currlocation", typeof(String));
	T.defineColumn("idcurrman", typeof(Int32));
	T.defineColumn("currmanager", typeof(String));
	T.defineColumn("idcurrsubman", typeof(Int32));
	T.defineColumn("currsubmanager", typeof(String));
	T.defineColumn("idinv", typeof(Int32),false);
	T.defineColumn("codeinv", typeof(String),false);
	T.defineColumn("idinv_lev1", typeof(Int32),false);
	T.defineColumn("codeinv_lev1", typeof(String),false);
	T.defineColumn("inventorytree", typeof(String),false);
	T.defineColumn("inventorytree_lev1", typeof(String),false);
	T.defineColumn("idinventory", typeof(Int32));
	T.defineColumn("codeinventory", typeof(String),false);
	T.defineColumn("inventory", typeof(String),false);
	T.defineColumn("description", typeof(String),false);
	T.defineColumn("idassetload", typeof(Int32));
	T.defineColumn("idassetloadkind", typeof(Int32));
	T.defineColumn("yassetload", typeof(Int16));
	T.defineColumn("nassetload", typeof(Int32));
	T.defineColumn("idloadmot", typeof(Int32),false);
	T.defineColumn("loadmotive", typeof(String));
	T.defineColumn("loaddescription", typeof(String));
	T.defineColumn("ratificationdate", typeof(DateTime));
	T.defineColumn("loaddate", typeof(DateTime));
	T.defineColumn("loaddoc", typeof(String));
	T.defineColumn("loaddocdate", typeof(DateTime));
	T.defineColumn("loadenactment", typeof(String));
	T.defineColumn("loadenactmentdate", typeof(DateTime));
	T.defineColumn("loadprintdate", typeof(DateTime));
	T.defineColumn("taxable", typeof(Decimal));
	T.defineColumn("taxrate", typeof(Double));
	T.defineColumn("tax", typeof(Decimal),true,true);
	T.defineColumn("abatable", typeof(Decimal),true,true);
	T.defineColumn("unabatable", typeof(Decimal),true,true);
	T.defineColumn("number", typeof(Int32),false);
	T.defineColumn("discount", typeof(Double));
	T.defineColumn("cost", typeof(Decimal),true,true);
	T.defineColumn("revals", typeof(Decimal),true,true);
	T.defineColumn("revals_pending", typeof(Decimal),true,true);
	T.defineColumn("subtractions", typeof(Decimal),true,true);
	T.defineColumn("currentvalue", typeof(Decimal),true,true);
	T.defineColumn("total", typeof(Decimal),true,true);
	T.defineColumn("idassetunload", typeof(Int32));
	T.defineColumn("idassetunloadkind", typeof(Int32));
	T.defineColumn("yassetunload", typeof(Int16));
	T.defineColumn("nassetunload", typeof(Int32));
	T.defineColumn("unloaddate", typeof(DateTime));
	T.defineColumn("idunloadmot", typeof(Int32));
	T.defineColumn("unloadmotive", typeof(String));
	T.defineColumn("unloaddescription", typeof(String));
	T.defineColumn("unloaddoc", typeof(String));
	T.defineColumn("unloaddocdate", typeof(DateTime));
	T.defineColumn("unloadenactment", typeof(String));
	T.defineColumn("unloadenactmentdate", typeof(DateTime));
	T.defineColumn("unloadratificationdate", typeof(DateTime));
	T.defineColumn("unloadregistry", typeof(String));
	T.defineColumn("flag", typeof(Byte),false);
	T.defineColumn("flagunload", typeof(String),true,true);
	T.defineColumn("flagtransf", typeof(String),true,true);
	T.defineColumn("transmitted", typeof(String));
	T.defineColumn("flagload", typeof(String),true,true);
	T.defineColumn("loadkind", typeof(String),true,true);
	T.defineColumn("multifield", typeof(String));
	T.defineColumn("idsor01", typeof(Int32),true,true);
	T.defineColumn("idsor02", typeof(Int32),true,true);
	T.defineColumn("idsor03", typeof(Int32),true,true);
	T.defineColumn("idsor04", typeof(Int32),true,true);
	T.defineColumn("idsor05", typeof(Int32),true,true);
	T.defineColumn("is_unloaded", typeof(String),true,true);
	T.defineColumn("is_loaded", typeof(String),true,true);
	T.defineColumn("idupb", typeof(String));
	T.defineColumn("codeupb", typeof(String));
	T.defineColumn("upb", typeof(String));
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("rtf", typeof(Byte[]));
	T.defineColumn("txt", typeof(String));
	T.defineColumn("idinventoryagency", typeof(Int32),false);
	T.defineColumn("inventoryagency", typeof(String),false);
	T.defineColumn("idlist", typeof(Int32));
	T.defineColumn("intcode", typeof(String));
	T.defineColumn("list", typeof(String));
	T.defineColumn("idinventoryamortization", typeof(Int32));
	T.defineColumn("amortizationquota", typeof(Double));
	T.defineColumn("historical", typeof(Decimal));
	T.defineColumn("ispiece", typeof(String),true,true);
	T.defineColumn("inventorykindvisible", typeof(String),true,true);
	Tables.Add(T);
	T.defineKey("idasset", "idpiece");

	//////////////////// EPACC_GRANTDETAIL /////////////////////////////////
	T= new MetaTable("epacc_grantdetail");
	T.defineColumn("idepacc", typeof(Int32),false);
	T.defineColumn("adate", typeof(DateTime),false);
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("description", typeof(String),false);
	T.defineColumn("doc", typeof(String));
	T.defineColumn("docdate", typeof(DateTime));
	T.defineColumn("idman", typeof(Int32));
	T.defineColumn("idreg", typeof(Int32));
	T.defineColumn("idrelated", typeof(String));
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("nepacc", typeof(Int32),false);
	T.defineColumn("nphase", typeof(Int16),false);
	T.defineColumn("paridepacc", typeof(Int32));
	T.defineColumn("rtf", typeof(Byte[]));
	T.defineColumn("start", typeof(DateTime));
	T.defineColumn("stop", typeof(DateTime));
	T.defineColumn("txt", typeof(String));
	T.defineColumn("yepacc", typeof(Int16),false);
	T.defineColumn("flagvariation", typeof(String));
	T.defineColumn("idaccmotive", typeof(String));
	Tables.Add(T);
	T.defineKey("idepacc");

	//////////////////// EPACC_GRANT /////////////////////////////////
	T= new MetaTable("epacc_grant");
	T.defineColumn("idepacc", typeof(Int32),false);
	T.defineColumn("adate", typeof(DateTime),false);
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("description", typeof(String),false);
	T.defineColumn("doc", typeof(String));
	T.defineColumn("docdate", typeof(DateTime));
	T.defineColumn("idman", typeof(Int32));
	T.defineColumn("idreg", typeof(Int32));
	T.defineColumn("idrelated", typeof(String));
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("nepacc", typeof(Int32),false);
	T.defineColumn("nphase", typeof(Int16),false);
	T.defineColumn("paridepacc", typeof(Int32));
	T.defineColumn("rtf", typeof(Byte[]));
	T.defineColumn("start", typeof(DateTime));
	T.defineColumn("stop", typeof(DateTime));
	T.defineColumn("txt", typeof(String));
	T.defineColumn("yepacc", typeof(Int16),false);
	T.defineColumn("flagvariation", typeof(String));
	T.defineColumn("idaccmotive", typeof(String));
	Tables.Add(T);
	T.defineKey("idepacc");

	//////////////////// UNDERWRITING /////////////////////////////////
	T= new MetaTable("underwriting");
	T.defineColumn("idunderwriting", typeof(Int32),false);
	T.defineColumn("active", typeof(String));
	T.defineColumn("codeunderwriting", typeof(String));
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("doc", typeof(String));
	T.defineColumn("docdate", typeof(DateTime));
	T.defineColumn("idsor01", typeof(Int32));
	T.defineColumn("idsor02", typeof(Int32));
	T.defineColumn("idsor03", typeof(Int32));
	T.defineColumn("idsor04", typeof(Int32));
	T.defineColumn("idsor05", typeof(Int32));
	T.defineColumn("idunderwriter", typeof(Int32));
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("title", typeof(String),false);
	Tables.Add(T);
	T.defineKey("idunderwriting");

	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new accmotiveTable();
	taccmotive.addBaseColumns("idaccmotive","active","codemotive","ct","cu","flagamm","flagdep","lt","lu","paridaccmotive","title","expensekind","flag");
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	this.defineRelation("grantload_assetgrantdetail","grantload","assetgrantdetail","idgrantload");
	this.defineRelation("grantload_assetgrant","grantload","assetgrant","idgrantload");
	this.defineRelation("assetview_grantdetail_assetgrantdetail","assetview_grantdetail","assetgrantdetail","idasset","idpiece");
	this.defineRelation("epacc_grantdetail_assetgrantdetail","epacc_grantdetail","assetgrantdetail","idepacc");
	this.defineRelation("assetview_grant_assetgrant","assetview_grant","assetgrant","idasset","idpiece");
	this.defineRelation("epacc_grant_assetgrant","epacc_grant","assetgrant","idepacc");
	this.defineRelation("underwriting_assetgrant","underwriting","assetgrant","idunderwriting");
	this.defineRelation("accmotive_assetgrant","accmotive","assetgrant","idaccmotive");
	#endregion

}
}
}
