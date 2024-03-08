
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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_grantload;
using meta_assetgrant;
using meta_assetgrantdetail;
using meta_underwriting;
using meta_accmotive;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace grantload_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public grantloadTable grantload 		=> (grantloadTable)Tables["grantload"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetgrantTable assetgrant 		=> (assetgrantTable)Tables["assetgrant"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetgrantdetailTable assetgrantdetail 		=> (assetgrantdetailTable)Tables["assetgrantdetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetview_grant 		=> (MetaTable)Tables["assetview_grant"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetview_grantdetail 		=> (MetaTable)Tables["assetview_grantdetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epacc_grantdetail 		=> (MetaTable)Tables["epacc_grantdetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epacc_grant 		=> (MetaTable)Tables["epacc_grant"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public underwritingTable underwriting 		=> (underwritingTable)Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveTable accmotive 		=> (accmotiveTable)Tables["accmotive"];

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
	//////////////////// GRANTLOAD /////////////////////////////////
	var tgrantload= new grantloadTable();
	tgrantload.addBaseColumns("idgrantload","yload","kind","description","ct","cu","lt","lu","adate");
	Tables.Add(tgrantload);
	tgrantload.defineKey("idgrantload");

	//////////////////// ASSETGRANT /////////////////////////////////
	var tassetgrant= new assetgrantTable();
	tassetgrant.addBaseColumns("idasset","idgrant","idunderwriting","idaccmotive","amount","ygrant","description","doc","docdate","idgrantload","lt","lu","ct","cu","idpiece","idepacc","flag_entryprofitreservedone","flag_financesource");
	tassetgrant.defineColumn("!ninventario", typeof(int));
	tassetgrant.defineColumn("!inventario", typeof(string));
	tassetgrant.defineColumn("!yepacc", typeof(short));
	tassetgrant.defineColumn("!nepacc", typeof(int));
	tassetgrant.defineColumn("!codemotive", typeof(string));
	tassetgrant.defineColumn("!titlemotive", typeof(string));
	tassetgrant.defineColumn("!codeunderwriting", typeof(string));
	tassetgrant.defineColumn("!codeinv", typeof(string));
	tassetgrant.defineColumn("!inventorytree", typeof(string));
	tassetgrant.defineColumn("!inventoryagency", typeof(string));
	tassetgrant.defineColumn("!titleunderwriting", typeof(string));
	tassetgrant.defineColumn("!cost", typeof(decimal));
	Tables.Add(tassetgrant);
	tassetgrant.defineKey("idasset", "idgrant", "idpiece");

	//////////////////// ASSETGRANTDETAIL /////////////////////////////////
	var tassetgrantdetail= new assetgrantdetailTable();
	tassetgrantdetail.addBaseColumns("idasset","idgrant","iddetail","ydetail","amount","idgrantload","ct","cu","lt","lu","idpiece","idepacc");
	tassetgrantdetail.defineColumn("!ninventario", typeof(int));
	tassetgrantdetail.defineColumn("!inventario", typeof(string));
	tassetgrantdetail.defineColumn("!yepacc", typeof(short));
	tassetgrantdetail.defineColumn("!nepacc", typeof(int));
	tassetgrantdetail.defineColumn("!codeinv", typeof(string));
	tassetgrantdetail.defineColumn("!inventorytree", typeof(string));
	tassetgrantdetail.defineColumn("!inventoryagency", typeof(string));
	tassetgrantdetail.defineColumn("!cost", typeof(decimal));
	Tables.Add(tassetgrantdetail);
	tassetgrantdetail.defineKey("idasset", "idgrant", "iddetail", "idpiece");

	//////////////////// ASSETVIEW_GRANT /////////////////////////////////
	var tassetview_grant= new MetaTable("assetview_grant");
	tassetview_grant.defineColumn("idasset", typeof(int),false);
	tassetview_grant.defineColumn("idpiece", typeof(int),false);
	tassetview_grant.defineColumn("idasset_prev", typeof(int));
	tassetview_grant.defineColumn("idpiece_prev", typeof(int));
	tassetview_grant.defineColumn("idinventory_prev", typeof(int));
	tassetview_grant.defineColumn("codeinventory_prev", typeof(string));
	tassetview_grant.defineColumn("inventory_prev", typeof(string));
	tassetview_grant.defineColumn("ninventory_prev", typeof(int));
	tassetview_grant.defineColumn("idasset_next", typeof(int));
	tassetview_grant.defineColumn("idpiece_next", typeof(int));
	tassetview_grant.defineColumn("idinventory_next", typeof(int));
	tassetview_grant.defineColumn("codeinventory_next", typeof(string));
	tassetview_grant.defineColumn("inventory_next", typeof(string));
	tassetview_grant.defineColumn("ninventory_next", typeof(int));
	tassetview_grant.defineColumn("lifestart", typeof(DateTime));
	tassetview_grant.defineColumn("yearstart", typeof(int),true,true);
	tassetview_grant.defineColumn("nassetacquire", typeof(int));
	tassetview_grant.defineColumn("ninventory", typeof(int));
	tassetview_grant.defineColumn("idcurrlocation", typeof(int));
	tassetview_grant.defineColumn("currlocationcode", typeof(string));
	tassetview_grant.defineColumn("currlocation", typeof(string));
	tassetview_grant.defineColumn("idcurrman", typeof(int));
	tassetview_grant.defineColumn("currmanager", typeof(string));
	tassetview_grant.defineColumn("idcurrsubman", typeof(int));
	tassetview_grant.defineColumn("currsubmanager", typeof(string));
	tassetview_grant.defineColumn("idinv", typeof(int),false);
	tassetview_grant.defineColumn("codeinv", typeof(string),false);
	tassetview_grant.defineColumn("idinv_lev1", typeof(int),false);
	tassetview_grant.defineColumn("codeinv_lev1", typeof(string),false);
	tassetview_grant.defineColumn("inventorytree", typeof(string),false);
	tassetview_grant.defineColumn("inventorytree_lev1", typeof(string),false);
	tassetview_grant.defineColumn("idinventory", typeof(int));
	tassetview_grant.defineColumn("codeinventory", typeof(string),false);
	tassetview_grant.defineColumn("inventory", typeof(string),false);
	tassetview_grant.defineColumn("description", typeof(string),false);
	tassetview_grant.defineColumn("idassetload", typeof(int));
	tassetview_grant.defineColumn("idassetloadkind", typeof(int));
	tassetview_grant.defineColumn("yassetload", typeof(short));
	tassetview_grant.defineColumn("nassetload", typeof(int));
	tassetview_grant.defineColumn("idloadmot", typeof(int),false);
	tassetview_grant.defineColumn("loadmotive", typeof(string));
	tassetview_grant.defineColumn("loaddescription", typeof(string));
	tassetview_grant.defineColumn("ratificationdate", typeof(DateTime));
	tassetview_grant.defineColumn("loaddate", typeof(DateTime));
	tassetview_grant.defineColumn("loaddoc", typeof(string));
	tassetview_grant.defineColumn("loaddocdate", typeof(DateTime));
	tassetview_grant.defineColumn("loadenactment", typeof(string));
	tassetview_grant.defineColumn("loadenactmentdate", typeof(DateTime));
	tassetview_grant.defineColumn("loadprintdate", typeof(DateTime));
	tassetview_grant.defineColumn("taxable", typeof(decimal));
	tassetview_grant.defineColumn("taxrate", typeof(double));
	tassetview_grant.defineColumn("tax", typeof(decimal),true,true);
	tassetview_grant.defineColumn("abatable", typeof(decimal),true,true);
	tassetview_grant.defineColumn("unabatable", typeof(decimal),true,true);
	tassetview_grant.defineColumn("number", typeof(int),false);
	tassetview_grant.defineColumn("discount", typeof(double));
	tassetview_grant.defineColumn("cost", typeof(decimal),true,true);
	tassetview_grant.defineColumn("revals", typeof(decimal),true,true);
	tassetview_grant.defineColumn("revals_pending", typeof(decimal),true,true);
	tassetview_grant.defineColumn("subtractions", typeof(decimal),true,true);
	tassetview_grant.defineColumn("currentvalue", typeof(decimal),true,true);
	tassetview_grant.defineColumn("total", typeof(decimal),true,true);
	tassetview_grant.defineColumn("idassetunload", typeof(int));
	tassetview_grant.defineColumn("idassetunloadkind", typeof(int));
	tassetview_grant.defineColumn("yassetunload", typeof(short));
	tassetview_grant.defineColumn("nassetunload", typeof(int));
	tassetview_grant.defineColumn("unloaddate", typeof(DateTime));
	tassetview_grant.defineColumn("idunloadmot", typeof(int));
	tassetview_grant.defineColumn("unloadmotive", typeof(string));
	tassetview_grant.defineColumn("unloaddescription", typeof(string));
	tassetview_grant.defineColumn("unloaddoc", typeof(string));
	tassetview_grant.defineColumn("unloaddocdate", typeof(DateTime));
	tassetview_grant.defineColumn("unloadenactment", typeof(string));
	tassetview_grant.defineColumn("unloadenactmentdate", typeof(DateTime));
	tassetview_grant.defineColumn("unloadratificationdate", typeof(DateTime));
	tassetview_grant.defineColumn("unloadregistry", typeof(string));
	tassetview_grant.defineColumn("flag", typeof(byte),false);
	tassetview_grant.defineColumn("flagunload", typeof(string),true,true);
	tassetview_grant.defineColumn("flagtransf", typeof(string),true,true);
	tassetview_grant.defineColumn("transmitted", typeof(string));
	tassetview_grant.defineColumn("flagload", typeof(string),true,true);
	tassetview_grant.defineColumn("loadkind", typeof(string),true,true);
	tassetview_grant.defineColumn("multifield", typeof(string));
	tassetview_grant.defineColumn("idsor01", typeof(int),true,true);
	tassetview_grant.defineColumn("idsor02", typeof(int),true,true);
	tassetview_grant.defineColumn("idsor03", typeof(int),true,true);
	tassetview_grant.defineColumn("idsor04", typeof(int),true,true);
	tassetview_grant.defineColumn("idsor05", typeof(int),true,true);
	tassetview_grant.defineColumn("is_unloaded", typeof(string),true,true);
	tassetview_grant.defineColumn("is_loaded", typeof(string),true,true);
	tassetview_grant.defineColumn("idupb", typeof(string));
	tassetview_grant.defineColumn("codeupb", typeof(string));
	tassetview_grant.defineColumn("upb", typeof(string));
	tassetview_grant.defineColumn("cu", typeof(string),false);
	tassetview_grant.defineColumn("ct", typeof(DateTime),false);
	tassetview_grant.defineColumn("lu", typeof(string),false);
	tassetview_grant.defineColumn("lt", typeof(DateTime),false);
	tassetview_grant.defineColumn("rtf", typeof(Byte[]));
	tassetview_grant.defineColumn("txt", typeof(string));
	tassetview_grant.defineColumn("idinventoryagency", typeof(int),false);
	tassetview_grant.defineColumn("inventoryagency", typeof(string),false);
	tassetview_grant.defineColumn("idlist", typeof(int));
	tassetview_grant.defineColumn("intcode", typeof(string));
	tassetview_grant.defineColumn("list", typeof(string));
	tassetview_grant.defineColumn("idinventoryamortization", typeof(int));
	tassetview_grant.defineColumn("amortizationquota", typeof(double));
	tassetview_grant.defineColumn("historical", typeof(decimal));
	tassetview_grant.defineColumn("ispiece", typeof(string),true,true);
	tassetview_grant.defineColumn("inventorykindvisible", typeof(string),true,true);
	Tables.Add(tassetview_grant);
	tassetview_grant.defineKey("idasset", "idpiece");

	//////////////////// ASSETVIEW_GRANTDETAIL /////////////////////////////////
	var tassetview_grantdetail= new MetaTable("assetview_grantdetail");
	tassetview_grantdetail.defineColumn("idasset", typeof(int),false);
	tassetview_grantdetail.defineColumn("idpiece", typeof(int),false);
	tassetview_grantdetail.defineColumn("idasset_prev", typeof(int));
	tassetview_grantdetail.defineColumn("idpiece_prev", typeof(int));
	tassetview_grantdetail.defineColumn("idinventory_prev", typeof(int));
	tassetview_grantdetail.defineColumn("codeinventory_prev", typeof(string));
	tassetview_grantdetail.defineColumn("inventory_prev", typeof(string));
	tassetview_grantdetail.defineColumn("ninventory_prev", typeof(int));
	tassetview_grantdetail.defineColumn("idasset_next", typeof(int));
	tassetview_grantdetail.defineColumn("idpiece_next", typeof(int));
	tassetview_grantdetail.defineColumn("idinventory_next", typeof(int));
	tassetview_grantdetail.defineColumn("codeinventory_next", typeof(string));
	tassetview_grantdetail.defineColumn("inventory_next", typeof(string));
	tassetview_grantdetail.defineColumn("ninventory_next", typeof(int));
	tassetview_grantdetail.defineColumn("lifestart", typeof(DateTime));
	tassetview_grantdetail.defineColumn("yearstart", typeof(int),true,true);
	tassetview_grantdetail.defineColumn("nassetacquire", typeof(int));
	tassetview_grantdetail.defineColumn("ninventory", typeof(int));
	tassetview_grantdetail.defineColumn("idcurrlocation", typeof(int));
	tassetview_grantdetail.defineColumn("currlocationcode", typeof(string));
	tassetview_grantdetail.defineColumn("currlocation", typeof(string));
	tassetview_grantdetail.defineColumn("idcurrman", typeof(int));
	tassetview_grantdetail.defineColumn("currmanager", typeof(string));
	tassetview_grantdetail.defineColumn("idcurrsubman", typeof(int));
	tassetview_grantdetail.defineColumn("currsubmanager", typeof(string));
	tassetview_grantdetail.defineColumn("idinv", typeof(int),false);
	tassetview_grantdetail.defineColumn("codeinv", typeof(string),false);
	tassetview_grantdetail.defineColumn("idinv_lev1", typeof(int),false);
	tassetview_grantdetail.defineColumn("codeinv_lev1", typeof(string),false);
	tassetview_grantdetail.defineColumn("inventorytree", typeof(string),false);
	tassetview_grantdetail.defineColumn("inventorytree_lev1", typeof(string),false);
	tassetview_grantdetail.defineColumn("idinventory", typeof(int));
	tassetview_grantdetail.defineColumn("codeinventory", typeof(string),false);
	tassetview_grantdetail.defineColumn("inventory", typeof(string),false);
	tassetview_grantdetail.defineColumn("description", typeof(string),false);
	tassetview_grantdetail.defineColumn("idassetload", typeof(int));
	tassetview_grantdetail.defineColumn("idassetloadkind", typeof(int));
	tassetview_grantdetail.defineColumn("yassetload", typeof(short));
	tassetview_grantdetail.defineColumn("nassetload", typeof(int));
	tassetview_grantdetail.defineColumn("idloadmot", typeof(int),false);
	tassetview_grantdetail.defineColumn("loadmotive", typeof(string));
	tassetview_grantdetail.defineColumn("loaddescription", typeof(string));
	tassetview_grantdetail.defineColumn("ratificationdate", typeof(DateTime));
	tassetview_grantdetail.defineColumn("loaddate", typeof(DateTime));
	tassetview_grantdetail.defineColumn("loaddoc", typeof(string));
	tassetview_grantdetail.defineColumn("loaddocdate", typeof(DateTime));
	tassetview_grantdetail.defineColumn("loadenactment", typeof(string));
	tassetview_grantdetail.defineColumn("loadenactmentdate", typeof(DateTime));
	tassetview_grantdetail.defineColumn("loadprintdate", typeof(DateTime));
	tassetview_grantdetail.defineColumn("taxable", typeof(decimal));
	tassetview_grantdetail.defineColumn("taxrate", typeof(double));
	tassetview_grantdetail.defineColumn("tax", typeof(decimal),true,true);
	tassetview_grantdetail.defineColumn("abatable", typeof(decimal),true,true);
	tassetview_grantdetail.defineColumn("unabatable", typeof(decimal),true,true);
	tassetview_grantdetail.defineColumn("number", typeof(int),false);
	tassetview_grantdetail.defineColumn("discount", typeof(double));
	tassetview_grantdetail.defineColumn("cost", typeof(decimal),true,true);
	tassetview_grantdetail.defineColumn("revals", typeof(decimal),true,true);
	tassetview_grantdetail.defineColumn("revals_pending", typeof(decimal),true,true);
	tassetview_grantdetail.defineColumn("subtractions", typeof(decimal),true,true);
	tassetview_grantdetail.defineColumn("currentvalue", typeof(decimal),true,true);
	tassetview_grantdetail.defineColumn("total", typeof(decimal),true,true);
	tassetview_grantdetail.defineColumn("idassetunload", typeof(int));
	tassetview_grantdetail.defineColumn("idassetunloadkind", typeof(int));
	tassetview_grantdetail.defineColumn("yassetunload", typeof(short));
	tassetview_grantdetail.defineColumn("nassetunload", typeof(int));
	tassetview_grantdetail.defineColumn("unloaddate", typeof(DateTime));
	tassetview_grantdetail.defineColumn("idunloadmot", typeof(int));
	tassetview_grantdetail.defineColumn("unloadmotive", typeof(string));
	tassetview_grantdetail.defineColumn("unloaddescription", typeof(string));
	tassetview_grantdetail.defineColumn("unloaddoc", typeof(string));
	tassetview_grantdetail.defineColumn("unloaddocdate", typeof(DateTime));
	tassetview_grantdetail.defineColumn("unloadenactment", typeof(string));
	tassetview_grantdetail.defineColumn("unloadenactmentdate", typeof(DateTime));
	tassetview_grantdetail.defineColumn("unloadratificationdate", typeof(DateTime));
	tassetview_grantdetail.defineColumn("unloadregistry", typeof(string));
	tassetview_grantdetail.defineColumn("flag", typeof(byte),false);
	tassetview_grantdetail.defineColumn("flagunload", typeof(string),true,true);
	tassetview_grantdetail.defineColumn("flagtransf", typeof(string),true,true);
	tassetview_grantdetail.defineColumn("transmitted", typeof(string));
	tassetview_grantdetail.defineColumn("flagload", typeof(string),true,true);
	tassetview_grantdetail.defineColumn("loadkind", typeof(string),true,true);
	tassetview_grantdetail.defineColumn("multifield", typeof(string));
	tassetview_grantdetail.defineColumn("idsor01", typeof(int),true,true);
	tassetview_grantdetail.defineColumn("idsor02", typeof(int),true,true);
	tassetview_grantdetail.defineColumn("idsor03", typeof(int),true,true);
	tassetview_grantdetail.defineColumn("idsor04", typeof(int),true,true);
	tassetview_grantdetail.defineColumn("idsor05", typeof(int),true,true);
	tassetview_grantdetail.defineColumn("is_unloaded", typeof(string),true,true);
	tassetview_grantdetail.defineColumn("is_loaded", typeof(string),true,true);
	tassetview_grantdetail.defineColumn("idupb", typeof(string));
	tassetview_grantdetail.defineColumn("codeupb", typeof(string));
	tassetview_grantdetail.defineColumn("upb", typeof(string));
	tassetview_grantdetail.defineColumn("cu", typeof(string),false);
	tassetview_grantdetail.defineColumn("ct", typeof(DateTime),false);
	tassetview_grantdetail.defineColumn("lu", typeof(string),false);
	tassetview_grantdetail.defineColumn("lt", typeof(DateTime),false);
	tassetview_grantdetail.defineColumn("rtf", typeof(Byte[]));
	tassetview_grantdetail.defineColumn("txt", typeof(string));
	tassetview_grantdetail.defineColumn("idinventoryagency", typeof(int),false);
	tassetview_grantdetail.defineColumn("inventoryagency", typeof(string),false);
	tassetview_grantdetail.defineColumn("idlist", typeof(int));
	tassetview_grantdetail.defineColumn("intcode", typeof(string));
	tassetview_grantdetail.defineColumn("list", typeof(string));
	tassetview_grantdetail.defineColumn("idinventoryamortization", typeof(int));
	tassetview_grantdetail.defineColumn("amortizationquota", typeof(double));
	tassetview_grantdetail.defineColumn("historical", typeof(decimal));
	tassetview_grantdetail.defineColumn("ispiece", typeof(string),true,true);
	tassetview_grantdetail.defineColumn("inventorykindvisible", typeof(string),true,true);
	Tables.Add(tassetview_grantdetail);
	tassetview_grantdetail.defineKey("idasset", "idpiece");

	//////////////////// EPACC_GRANTDETAIL /////////////////////////////////
	var tepacc_grantdetail= new MetaTable("epacc_grantdetail");
	tepacc_grantdetail.defineColumn("idepacc", typeof(int),false);
	tepacc_grantdetail.defineColumn("adate", typeof(DateTime),false);
	tepacc_grantdetail.defineColumn("ct", typeof(DateTime),false);
	tepacc_grantdetail.defineColumn("cu", typeof(string),false);
	tepacc_grantdetail.defineColumn("description", typeof(string),false);
	tepacc_grantdetail.defineColumn("doc", typeof(string));
	tepacc_grantdetail.defineColumn("docdate", typeof(DateTime));
	tepacc_grantdetail.defineColumn("idman", typeof(int));
	tepacc_grantdetail.defineColumn("idreg", typeof(int));
	tepacc_grantdetail.defineColumn("idrelated", typeof(string));
	tepacc_grantdetail.defineColumn("lt", typeof(DateTime),false);
	tepacc_grantdetail.defineColumn("lu", typeof(string),false);
	tepacc_grantdetail.defineColumn("nepacc", typeof(int),false);
	tepacc_grantdetail.defineColumn("nphase", typeof(short),false);
	tepacc_grantdetail.defineColumn("paridepacc", typeof(int));
	tepacc_grantdetail.defineColumn("rtf", typeof(Byte[]));
	tepacc_grantdetail.defineColumn("start", typeof(DateTime));
	tepacc_grantdetail.defineColumn("stop", typeof(DateTime));
	tepacc_grantdetail.defineColumn("txt", typeof(string));
	tepacc_grantdetail.defineColumn("yepacc", typeof(short),false);
	tepacc_grantdetail.defineColumn("flagvariation", typeof(string));
	tepacc_grantdetail.defineColumn("idaccmotive", typeof(string));
	Tables.Add(tepacc_grantdetail);
	tepacc_grantdetail.defineKey("idepacc");

	//////////////////// EPACC_GRANT /////////////////////////////////
	var tepacc_grant= new MetaTable("epacc_grant");
	tepacc_grant.defineColumn("idepacc", typeof(int),false);
	tepacc_grant.defineColumn("adate", typeof(DateTime),false);
	tepacc_grant.defineColumn("ct", typeof(DateTime),false);
	tepacc_grant.defineColumn("cu", typeof(string),false);
	tepacc_grant.defineColumn("description", typeof(string),false);
	tepacc_grant.defineColumn("doc", typeof(string));
	tepacc_grant.defineColumn("docdate", typeof(DateTime));
	tepacc_grant.defineColumn("idman", typeof(int));
	tepacc_grant.defineColumn("idreg", typeof(int));
	tepacc_grant.defineColumn("idrelated", typeof(string));
	tepacc_grant.defineColumn("lt", typeof(DateTime),false);
	tepacc_grant.defineColumn("lu", typeof(string),false);
	tepacc_grant.defineColumn("nepacc", typeof(int),false);
	tepacc_grant.defineColumn("nphase", typeof(short),false);
	tepacc_grant.defineColumn("paridepacc", typeof(int));
	tepacc_grant.defineColumn("rtf", typeof(Byte[]));
	tepacc_grant.defineColumn("start", typeof(DateTime));
	tepacc_grant.defineColumn("stop", typeof(DateTime));
	tepacc_grant.defineColumn("txt", typeof(string));
	tepacc_grant.defineColumn("yepacc", typeof(short),false);
	tepacc_grant.defineColumn("flagvariation", typeof(string));
	tepacc_grant.defineColumn("idaccmotive", typeof(string));
	Tables.Add(tepacc_grant);
	tepacc_grant.defineKey("idepacc");

	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new underwritingTable();
	tunderwriting.addBaseColumns("idunderwriting","active","codeunderwriting","ct","cu","doc","docdate","idsor01","idsor02","idsor03","idsor04","idsor05","idunderwriter","lt","lu","title");
	Tables.Add(tunderwriting);
	tunderwriting.defineKey("idunderwriting");

	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new accmotiveTable();
	taccmotive.addBaseColumns("idaccmotive","active","codemotive","ct","cu","flagamm","flagdep","lt","lu","paridaccmotive","title","expensekind","flag");
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	#endregion


	#region DataRelation creation
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
