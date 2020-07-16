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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_assetgrant;
using meta_assetgrantdetail;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace assetgrantdetail_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Inventario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory 		=> (MetaTable)Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetview 		=> (MetaTable)Tables["assetview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytreeview 		=> (MetaTable)Tables["inventorytreeview"];

	///<summary>
	///Ente inventariale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventoryagency 		=> (MetaTable)Tables["inventoryagency"];

	///<summary>
	///Attribuzione di un contributo conto impianti ad un cespite
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetgrantTable assetgrant 		=> (assetgrantTable)Tables["assetgrant"];

	///<summary>
	///Risconto contributo conto impianti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetgrantdetailTable assetgrantdetail 		=> (assetgrantdetailTable)Tables["assetgrantdetail"];

	///<summary>
	///Accertamento di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epacc 		=> (MetaTable)Tables["epacc"];

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
	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new MetaTable("inventory");
	tinventory.defineColumn("idinventory", typeof(int),false);
	tinventory.defineColumn("active", typeof(string));
	tinventory.defineColumn("codeinventory", typeof(string),false);
	tinventory.defineColumn("ct", typeof(DateTime),false);
	tinventory.defineColumn("cu", typeof(string),false);
	tinventory.defineColumn("description", typeof(string),false);
	tinventory.defineColumn("flag", typeof(byte),false);
	tinventory.defineColumn("idinventoryagency", typeof(int),false);
	tinventory.defineColumn("idinventorykind", typeof(int),false);
	tinventory.defineColumn("idsor01", typeof(int));
	tinventory.defineColumn("idsor02", typeof(int));
	tinventory.defineColumn("idsor03", typeof(int));
	tinventory.defineColumn("idsor04", typeof(int));
	tinventory.defineColumn("idsor05", typeof(int));
	tinventory.defineColumn("lt", typeof(DateTime),false);
	tinventory.defineColumn("lu", typeof(string),false);
	tinventory.defineColumn("startnumber", typeof(int));
	Tables.Add(tinventory);
	tinventory.defineKey("idinventory");

	//////////////////// ASSETVIEW /////////////////////////////////
	var tassetview= new MetaTable("assetview");
	tassetview.defineColumn("idasset", typeof(int),false);
	tassetview.defineColumn("idpiece", typeof(int),false);
	tassetview.defineColumn("idasset_prev", typeof(int));
	tassetview.defineColumn("idpiece_prev", typeof(int));
	tassetview.defineColumn("idinventory_prev", typeof(int));
	tassetview.defineColumn("codeinventory_prev", typeof(string));
	tassetview.defineColumn("inventory_prev", typeof(string));
	tassetview.defineColumn("ninventory_prev", typeof(int));
	tassetview.defineColumn("idasset_next", typeof(int));
	tassetview.defineColumn("idpiece_next", typeof(int));
	tassetview.defineColumn("idinventory_next", typeof(int));
	tassetview.defineColumn("codeinventory_next", typeof(string));
	tassetview.defineColumn("inventory_next", typeof(string));
	tassetview.defineColumn("ninventory_next", typeof(int));
	tassetview.defineColumn("lifestart", typeof(DateTime));
	tassetview.defineColumn("yearstart", typeof(int),true,true);
	tassetview.defineColumn("nassetacquire", typeof(int));
	tassetview.defineColumn("ninventory", typeof(int));
	tassetview.defineColumn("idcurrlocation", typeof(int));
	tassetview.defineColumn("currlocationcode", typeof(string));
	tassetview.defineColumn("currlocation", typeof(string));
	tassetview.defineColumn("idcurrman", typeof(int));
	tassetview.defineColumn("currmanager", typeof(string));
	tassetview.defineColumn("idcurrsubman", typeof(int));
	tassetview.defineColumn("currsubmanager", typeof(string));
	tassetview.defineColumn("idinv", typeof(int),false);
	tassetview.defineColumn("codeinv", typeof(string),false);
	tassetview.defineColumn("idinv_lev1", typeof(int),false);
	tassetview.defineColumn("codeinv_lev1", typeof(string),false);
	tassetview.defineColumn("inventorytree", typeof(string),false);
	tassetview.defineColumn("inventorytree_lev1", typeof(string),false);
	tassetview.defineColumn("idinventory", typeof(int));
	tassetview.defineColumn("codeinventory", typeof(string),false);
	tassetview.defineColumn("inventory", typeof(string),false);
	tassetview.defineColumn("description", typeof(string),false);
	tassetview.defineColumn("idassetload", typeof(int));
	tassetview.defineColumn("idassetloadkind", typeof(int));
	tassetview.defineColumn("yassetload", typeof(short));
	tassetview.defineColumn("nassetload", typeof(int));
	tassetview.defineColumn("idloadmot", typeof(int),false);
	tassetview.defineColumn("loadmotive", typeof(string));
	tassetview.defineColumn("loaddescription", typeof(string));
	tassetview.defineColumn("ratificationdate", typeof(DateTime));
	tassetview.defineColumn("loaddate", typeof(DateTime));
	tassetview.defineColumn("loaddoc", typeof(string));
	tassetview.defineColumn("loaddocdate", typeof(DateTime));
	tassetview.defineColumn("loadenactment", typeof(string));
	tassetview.defineColumn("loadenactmentdate", typeof(DateTime));
	tassetview.defineColumn("loadprintdate", typeof(DateTime));
	tassetview.defineColumn("taxable", typeof(decimal));
	tassetview.defineColumn("taxrate", typeof(double));
	tassetview.defineColumn("tax", typeof(decimal),true,true);
	tassetview.defineColumn("abatable", typeof(decimal),true,true);
	tassetview.defineColumn("unabatable", typeof(decimal),true,true);
	tassetview.defineColumn("number", typeof(int),false);
	tassetview.defineColumn("discount", typeof(double));
	tassetview.defineColumn("cost", typeof(decimal),true,true);
	tassetview.defineColumn("revals", typeof(decimal),true,true);
	tassetview.defineColumn("revals_pending", typeof(decimal),true,true);
	tassetview.defineColumn("subtractions", typeof(decimal),true,true);
	tassetview.defineColumn("currentvalue", typeof(decimal),true,true);
	tassetview.defineColumn("total", typeof(decimal),true,true);
	tassetview.defineColumn("idassetunload", typeof(int));
	tassetview.defineColumn("idassetunloadkind", typeof(int));
	tassetview.defineColumn("yassetunload", typeof(short));
	tassetview.defineColumn("nassetunload", typeof(int));
	tassetview.defineColumn("unloaddate", typeof(DateTime));
	tassetview.defineColumn("idunloadmot", typeof(int));
	tassetview.defineColumn("unloadmotive", typeof(string));
	tassetview.defineColumn("unloaddescription", typeof(string));
	tassetview.defineColumn("unloaddoc", typeof(string));
	tassetview.defineColumn("unloaddocdate", typeof(DateTime));
	tassetview.defineColumn("unloadenactment", typeof(string));
	tassetview.defineColumn("unloadenactmentdate", typeof(DateTime));
	tassetview.defineColumn("unloadratificationdate", typeof(DateTime));
	tassetview.defineColumn("unloadregistry", typeof(string));
	tassetview.defineColumn("flag", typeof(byte),false);
	tassetview.defineColumn("flagunload", typeof(string),true,true);
	tassetview.defineColumn("flagtransf", typeof(string),true,true);
	tassetview.defineColumn("transmitted", typeof(string));
	tassetview.defineColumn("flagload", typeof(string),true,true);
	tassetview.defineColumn("loadkind", typeof(string),true,true);
	tassetview.defineColumn("multifield", typeof(string));
	tassetview.defineColumn("idsor01", typeof(int),true,true);
	tassetview.defineColumn("idsor02", typeof(int),true,true);
	tassetview.defineColumn("idsor03", typeof(int),true,true);
	tassetview.defineColumn("idsor04", typeof(int),true,true);
	tassetview.defineColumn("idsor05", typeof(int),true,true);
	tassetview.defineColumn("is_unloaded", typeof(string),true,true);
	tassetview.defineColumn("is_loaded", typeof(string),true,true);
	tassetview.defineColumn("idupb", typeof(string));
	tassetview.defineColumn("codeupb", typeof(string));
	tassetview.defineColumn("upb", typeof(string));
	tassetview.defineColumn("cu", typeof(string),false);
	tassetview.defineColumn("ct", typeof(DateTime),false);
	tassetview.defineColumn("lu", typeof(string),false);
	tassetview.defineColumn("lt", typeof(DateTime),false);
	tassetview.defineColumn("rtf", typeof(Byte[]));
	tassetview.defineColumn("txt", typeof(string));
	tassetview.defineColumn("idinventoryagency", typeof(int),false);
	tassetview.defineColumn("inventoryagency", typeof(string),false);
	tassetview.defineColumn("idlist", typeof(int));
	tassetview.defineColumn("intcode", typeof(string));
	tassetview.defineColumn("list", typeof(string));
	tassetview.defineColumn("idinventoryamortization", typeof(int));
	tassetview.defineColumn("amortizationquota", typeof(double));
	tassetview.defineColumn("historical", typeof(decimal));
	tassetview.defineColumn("ispiece", typeof(string),true,true);
	tassetview.defineColumn("inventorykindvisible", typeof(string),true,true);
	Tables.Add(tassetview);
	tassetview.defineKey("idasset", "idpiece");

	//////////////////// INVENTORYTREEVIEW /////////////////////////////////
	var tinventorytreeview= new MetaTable("inventorytreeview");
	tinventorytreeview.defineColumn("idinv", typeof(int),false);
	tinventorytreeview.defineColumn("codeinv", typeof(string),false);
	tinventorytreeview.defineColumn("nlevel", typeof(byte),false);
	tinventorytreeview.defineColumn("leveldescr", typeof(string),false);
	tinventorytreeview.defineColumn("paridinv", typeof(int));
	tinventorytreeview.defineColumn("description", typeof(string),false);
	tinventorytreeview.defineColumn("idinv_lev1", typeof(int),false);
	tinventorytreeview.defineColumn("codeinv_lev1", typeof(string),false);
	tinventorytreeview.defineColumn("cu", typeof(string),false);
	tinventorytreeview.defineColumn("ct", typeof(DateTime),false);
	tinventorytreeview.defineColumn("lu", typeof(string),false);
	tinventorytreeview.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tinventorytreeview);
	tinventorytreeview.defineKey("idinv");

	//////////////////// INVENTORYAGENCY /////////////////////////////////
	var tinventoryagency= new MetaTable("inventoryagency");
	tinventoryagency.defineColumn("idinventoryagency", typeof(int),false);
	tinventoryagency.defineColumn("active", typeof(string));
	tinventoryagency.defineColumn("agencycode", typeof(string));
	tinventoryagency.defineColumn("codeinventoryagency", typeof(string),false);
	tinventoryagency.defineColumn("ct", typeof(DateTime),false);
	tinventoryagency.defineColumn("cu", typeof(string),false);
	tinventoryagency.defineColumn("description", typeof(string),false);
	tinventoryagency.defineColumn("lt", typeof(DateTime),false);
	tinventoryagency.defineColumn("lu", typeof(string),false);
	tinventoryagency.defineColumn("name_c", typeof(string));
	tinventoryagency.defineColumn("name_l", typeof(string));
	tinventoryagency.defineColumn("name_r", typeof(string));
	tinventoryagency.defineColumn("title_c", typeof(string));
	tinventoryagency.defineColumn("title_l", typeof(string));
	tinventoryagency.defineColumn("title_r", typeof(string));
	Tables.Add(tinventoryagency);
	tinventoryagency.defineKey("idinventoryagency");

	//////////////////// ASSETGRANT /////////////////////////////////
	var tassetgrant= new assetgrantTable();
	tassetgrant.addBaseColumns("idasset","idgrant","idunderwriting","idaccmotive","amount","ygrant","description","doc","docdate","idgrantload","lt","lu","ct","cu","idpiece","idepacc");
	Tables.Add(tassetgrant);
	tassetgrant.defineKey("idasset", "idgrant", "idpiece");

	//////////////////// ASSETGRANTDETAIL /////////////////////////////////
	var tassetgrantdetail= new assetgrantdetailTable();
	tassetgrantdetail.addBaseColumns("idasset","idgrant","iddetail","ydetail","amount","idgrantload","ct","cu","lt","lu","idpiece","idepacc");
	Tables.Add(tassetgrantdetail);
	tassetgrantdetail.defineKey("idasset", "idgrant", "iddetail", "idpiece");

	//////////////////// EPACC /////////////////////////////////
	var tepacc= new MetaTable("epacc");
	tepacc.defineColumn("idepacc", typeof(int),false);
	tepacc.defineColumn("adate", typeof(DateTime),false);
	tepacc.defineColumn("ct", typeof(DateTime),false);
	tepacc.defineColumn("cu", typeof(string),false);
	tepacc.defineColumn("description", typeof(string),false);
	tepacc.defineColumn("doc", typeof(string));
	tepacc.defineColumn("docdate", typeof(DateTime));
	tepacc.defineColumn("idman", typeof(int));
	tepacc.defineColumn("idreg", typeof(int));
	tepacc.defineColumn("idrelated", typeof(string));
	tepacc.defineColumn("lt", typeof(DateTime),false);
	tepacc.defineColumn("lu", typeof(string),false);
	tepacc.defineColumn("nepacc", typeof(int),false);
	tepacc.defineColumn("nphase", typeof(short),false);
	tepacc.defineColumn("paridepacc", typeof(int));
	tepacc.defineColumn("rtf", typeof(Byte[]));
	tepacc.defineColumn("start", typeof(DateTime));
	tepacc.defineColumn("stop", typeof(DateTime));
	tepacc.defineColumn("txt", typeof(string));
	tepacc.defineColumn("yepacc", typeof(short),false);
	tepacc.defineColumn("flagvariation", typeof(string));
	tepacc.defineColumn("idaccmotive", typeof(string));
	Tables.Add(tepacc);
	tepacc.defineKey("idepacc");

	#endregion


	#region DataRelation creation
	this.defineRelation("assetview_inventorytreeview","assetview","inventorytreeview","idinv");
	this.defineRelation("inventory_assetview","inventory","assetview","idinventory");
	this.defineRelation("epacc_assetgrantdetail","epacc","assetgrantdetail","idepacc");
	this.defineRelation("inventoryagency_assetview","inventoryagency","assetview","idinventoryagency");
	this.defineRelation("assetview_assetgrantdetail","assetview","assetgrantdetail","idasset","idpiece");
	this.defineRelation("assetgrantdetail_assetgrant","assetgrant","assetgrantdetail","idasset","idpiece","idgrant");
	#endregion

}
}
}
