
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_assetconsignsub_consigneeembedded"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_assetconsignsub_consigneeembedded: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytree_alias1 		=> (MetaTable)Tables["inventorytree_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquire_alias2 		=> (MetaTable)Tables["assetacquire_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquire_alias1 		=> (MetaTable)Tables["assetacquire_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory_alias2 		=> (MetaTable)Tables["inventory_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset_alias2 		=> (MetaTable)Tables["asset_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable location 		=> (MetaTable)Tables["location"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory_alias1 		=> (MetaTable)Tables["inventory_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytree 		=> (MetaTable)Tables["inventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetlocation 		=> (MetaTable)Tables["assetlocation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquire 		=> (MetaTable)Tables["assetacquire"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory 		=> (MetaTable)Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset 		=> (MetaTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsignsubasset 		=> (MetaTable)Tables["assetconsignsubasset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager_alias1 		=> (MetaTable)Tables["manager_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable substate 		=> (MetaTable)Tables["substate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager 		=> (MetaTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorykind 		=> (MetaTable)Tables["inventorykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsignsub 		=> (MetaTable)Tables["assetconsignsub"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_assetconsignsub_consigneeembedded(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_assetconsignsub_consigneeembedded (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_assetconsignsub_consigneeembedded";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_assetconsignsub_consigneeembedded.xsd";

	#region create DataTables
	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("codeupb", typeof(string),false);
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("title", typeof(string),false);
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// INVENTORYTREE_ALIAS1 /////////////////////////////////
	var tinventorytree_alias1= new MetaTable("inventorytree_alias1");
	tinventorytree_alias1.defineColumn("codeinv", typeof(string),false);
	tinventorytree_alias1.defineColumn("description", typeof(string),false);
	tinventorytree_alias1.defineColumn("idinv", typeof(int),false);
	tinventorytree_alias1.ExtendedProperties["TableForReading"]="inventorytree";
	Tables.Add(tinventorytree_alias1);
	tinventorytree_alias1.defineKey("idinv");

	//////////////////// ASSETACQUIRE_ALIAS2 /////////////////////////////////
	var tassetacquire_alias2= new MetaTable("assetacquire_alias2");
	tassetacquire_alias2.defineColumn("description", typeof(string),false);
	tassetacquire_alias2.defineColumn("idinv", typeof(int),false);
	tassetacquire_alias2.defineColumn("idupb", typeof(string));
	tassetacquire_alias2.defineColumn("nassetacquire", typeof(int),false);
	tassetacquire_alias2.ExtendedProperties["TableForReading"]="assetacquire";
	Tables.Add(tassetacquire_alias2);
	tassetacquire_alias2.defineKey("nassetacquire");

	//////////////////// ASSETACQUIRE_ALIAS1 /////////////////////////////////
	var tassetacquire_alias1= new MetaTable("assetacquire_alias1");
	tassetacquire_alias1.defineColumn("description", typeof(string),false);
	tassetacquire_alias1.defineColumn("idinv", typeof(int),false);
	tassetacquire_alias1.defineColumn("idupb", typeof(string));
	tassetacquire_alias1.defineColumn("nassetacquire", typeof(int),false);
	tassetacquire_alias1.ExtendedProperties["TableForReading"]="assetacquire";
	Tables.Add(tassetacquire_alias1);
	tassetacquire_alias1.defineKey("nassetacquire");

	//////////////////// INVENTORY_ALIAS2 /////////////////////////////////
	var tinventory_alias2= new MetaTable("inventory_alias2");
	tinventory_alias2.defineColumn("active", typeof(string));
	tinventory_alias2.defineColumn("codeinventory", typeof(string),false);
	tinventory_alias2.defineColumn("description", typeof(string),false);
	tinventory_alias2.defineColumn("idinventory", typeof(int),false);
	tinventory_alias2.ExtendedProperties["TableForReading"]="inventory";
	Tables.Add(tinventory_alias2);
	tinventory_alias2.defineKey("idinventory");

	//////////////////// ASSET_ALIAS2 /////////////////////////////////
	var tasset_alias2= new MetaTable("asset_alias2");
	tasset_alias2.defineColumn("idasset", typeof(int),false);
	tasset_alias2.defineColumn("idinventory", typeof(int));
	tasset_alias2.defineColumn("idpiece", typeof(int),false);
	tasset_alias2.defineColumn("nassetacquire", typeof(int));
	tasset_alias2.defineColumn("ninventory", typeof(int));
	tasset_alias2.defineColumn("rfid", typeof(string));
	tasset_alias2.ExtendedProperties["TableForReading"]="asset";
	Tables.Add(tasset_alias2);
	tasset_alias2.defineKey("idasset", "idpiece");

	//////////////////// LOCATION /////////////////////////////////
	var tlocation= new MetaTable("location");
	tlocation.defineColumn("active", typeof(string));
	tlocation.defineColumn("description", typeof(string),false);
	tlocation.defineColumn("idlocation", typeof(int),false);
	Tables.Add(tlocation);
	tlocation.defineKey("idlocation");

	//////////////////// INVENTORY_ALIAS1 /////////////////////////////////
	var tinventory_alias1= new MetaTable("inventory_alias1");
	tinventory_alias1.defineColumn("active", typeof(string));
	tinventory_alias1.defineColumn("codeinventory", typeof(string),false);
	tinventory_alias1.defineColumn("description", typeof(string),false);
	tinventory_alias1.defineColumn("idinventory", typeof(int),false);
	tinventory_alias1.ExtendedProperties["TableForReading"]="inventory";
	Tables.Add(tinventory_alias1);
	tinventory_alias1.defineKey("idinventory");

	//////////////////// INVENTORYTREE /////////////////////////////////
	var tinventorytree= new MetaTable("inventorytree");
	tinventorytree.defineColumn("codeinv", typeof(string),false);
	tinventorytree.defineColumn("description", typeof(string),false);
	tinventorytree.defineColumn("idinv", typeof(int),false);
	Tables.Add(tinventorytree);
	tinventorytree.defineKey("idinv");

	//////////////////// ASSETLOCATION /////////////////////////////////
	var tassetlocation= new MetaTable("assetlocation");
	tassetlocation.defineColumn("idasset", typeof(int),false);
	tassetlocation.defineColumn("idassetlocation", typeof(int),false);
	Tables.Add(tassetlocation);
	tassetlocation.defineKey("idasset", "idassetlocation");

	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new MetaTable("assetacquire");
	tassetacquire.defineColumn("description", typeof(string),false);
	tassetacquire.defineColumn("idinv", typeof(int),false);
	tassetacquire.defineColumn("idupb", typeof(string));
	tassetacquire.defineColumn("nassetacquire", typeof(int),false);
	Tables.Add(tassetacquire);
	tassetacquire.defineKey("nassetacquire");

	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new MetaTable("inventory");
	tinventory.defineColumn("active", typeof(string));
	tinventory.defineColumn("codeinventory", typeof(string),false);
	tinventory.defineColumn("description", typeof(string),false);
	tinventory.defineColumn("idinventory", typeof(int),false);
	Tables.Add(tinventory);
	tinventory.defineKey("idinventory");

	//////////////////// ASSET /////////////////////////////////
	var tasset= new MetaTable("asset");
	tasset.defineColumn("idasset", typeof(int),false);
	tasset.defineColumn("idinventory", typeof(int));
	tasset.defineColumn("idpiece", typeof(int),false);
	tasset.defineColumn("nassetacquire", typeof(int));
	tasset.defineColumn("ninventory", typeof(int));
	tasset.defineColumn("rfid", typeof(string));
	Tables.Add(tasset);
	tasset.defineKey("idasset", "idpiece");

	//////////////////// ASSETCONSIGNSUBASSET /////////////////////////////////
	var tassetconsignsubasset= new MetaTable("assetconsignsubasset");
	tassetconsignsubasset.defineColumn("ct", typeof(DateTime));
	tassetconsignsubasset.defineColumn("cu", typeof(string));
	tassetconsignsubasset.defineColumn("idasset", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetconsignsub", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetconsignsubasset", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetload", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetloadsub", typeof(int),false);
	tassetconsignsubasset.defineColumn("idassetlocation", typeof(int));
	tassetconsignsubasset.defineColumn("idinv", typeof(int),false);
	tassetconsignsubasset.defineColumn("idinventory", typeof(int),false);
	tassetconsignsubasset.defineColumn("idlocation", typeof(int));
	tassetconsignsubasset.defineColumn("idpiece", typeof(int),false);
	tassetconsignsubasset.defineColumn("lt", typeof(DateTime));
	tassetconsignsubasset.defineColumn("lu", typeof(string));
	tassetconsignsubasset.defineColumn("nassetacquire", typeof(int),false);
	tassetconsignsubasset.defineColumn("!idasset_asset_ninventory", typeof(int));
	tassetconsignsubasset.defineColumn("!idasset_asset_idasset", typeof(int));
	tassetconsignsubasset.defineColumn("!idasset_asset_idpiece", typeof(int));
	tassetconsignsubasset.defineColumn("!idasset_asset_rfid", typeof(string));
	tassetconsignsubasset.defineColumn("!idasset_asset_idinventory_codeinventory", typeof(string));
	tassetconsignsubasset.defineColumn("!idasset_asset_idinventory_description", typeof(string));
	tassetconsignsubasset.defineColumn("!idasset_asset_nassetacquire_description", typeof(string));
	tassetconsignsubasset.defineColumn("!idasset_asset_nassetacquire_idinv", typeof(int));
	tassetconsignsubasset.defineColumn("!idasset_asset_nassetacquire_idupb", typeof(string));
	tassetconsignsubasset.defineColumn("!idinv_inventorytree_codeinv", typeof(string));
	tassetconsignsubasset.defineColumn("!idinv_inventorytree_description", typeof(string));
	tassetconsignsubasset.defineColumn("!idinventory_inventory_codeinventory", typeof(string));
	tassetconsignsubasset.defineColumn("!idinventory_inventory_description", typeof(string));
	tassetconsignsubasset.defineColumn("!idlocation_location_description", typeof(string));
	tassetconsignsubasset.defineColumn("!idpiece_asset_ninventory", typeof(int));
	tassetconsignsubasset.defineColumn("!idpiece_asset_idasset", typeof(int));
	tassetconsignsubasset.defineColumn("!idpiece_asset_idpiece", typeof(int));
	tassetconsignsubasset.defineColumn("!idpiece_asset_rfid", typeof(string));
	tassetconsignsubasset.defineColumn("!idpiece_asset_idinventory_codeinventory", typeof(string));
	tassetconsignsubasset.defineColumn("!idpiece_asset_idinventory_description", typeof(string));
	tassetconsignsubasset.defineColumn("!idpiece_asset_nassetacquire_description", typeof(string));
	tassetconsignsubasset.defineColumn("!idpiece_asset_nassetacquire_idinv", typeof(int));
	tassetconsignsubasset.defineColumn("!idpiece_asset_nassetacquire_idupb", typeof(string));
	tassetconsignsubasset.defineColumn("!nassetacquire_assetacquire_description", typeof(string));
	tassetconsignsubasset.defineColumn("!nassetacquire_assetacquire_idinv_codeinv", typeof(string));
	tassetconsignsubasset.defineColumn("!nassetacquire_assetacquire_idinv_description", typeof(string));
	tassetconsignsubasset.defineColumn("!nassetacquire_assetacquire_idupb_codeupb", typeof(string));
	tassetconsignsubasset.defineColumn("!nassetacquire_assetacquire_idupb_title", typeof(string));
	Tables.Add(tassetconsignsubasset);
	tassetconsignsubasset.defineKey("idassetconsignsub", "idassetconsignsubasset", "idassetload", "idassetloadsub");

	//////////////////// MANAGER_ALIAS1 /////////////////////////////////
	var tmanager_alias1= new MetaTable("manager_alias1");
	tmanager_alias1.defineColumn("active", typeof(string));
	tmanager_alias1.defineColumn("idman", typeof(int),false);
	tmanager_alias1.defineColumn("title", typeof(string),false);
	tmanager_alias1.ExtendedProperties["TableForReading"]="manager";
	Tables.Add(tmanager_alias1);
	tmanager_alias1.defineKey("idman");

	//////////////////// SUBSTATE /////////////////////////////////
	var tsubstate= new MetaTable("substate");
	tsubstate.defineColumn("description", typeof(string));
	tsubstate.defineColumn("idsubstate", typeof(int),false);
	Tables.Add(tsubstate);
	tsubstate.defineKey("idsubstate");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new MetaTable("manager");
	tmanager.defineColumn("active", typeof(string));
	tmanager.defineColumn("idman", typeof(int),false);
	tmanager.defineColumn("title", typeof(string),false);
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// INVENTORYKIND /////////////////////////////////
	var tinventorykind= new MetaTable("inventorykind");
	tinventorykind.defineColumn("active", typeof(string));
	tinventorykind.defineColumn("codeinventorykind", typeof(string),false);
	tinventorykind.defineColumn("ct", typeof(DateTime),false);
	tinventorykind.defineColumn("cu", typeof(string),false);
	tinventorykind.defineColumn("description", typeof(string),false);
	tinventorykind.defineColumn("flag", typeof(int),false);
	tinventorykind.defineColumn("idinv_allow", typeof(int));
	tinventorykind.defineColumn("idinv_deny", typeof(int));
	tinventorykind.defineColumn("idinventorykind", typeof(int),false);
	tinventorykind.defineColumn("lt", typeof(DateTime),false);
	tinventorykind.defineColumn("lu", typeof(string),false);
	Tables.Add(tinventorykind);
	tinventorykind.defineKey("idinventorykind");

	//////////////////// ASSETCONSIGNSUB /////////////////////////////////
	var tassetconsignsub= new MetaTable("assetconsignsub");
	tassetconsignsub.defineColumn("ct", typeof(DateTime));
	tassetconsignsub.defineColumn("cu", typeof(string));
	tassetconsignsub.defineColumn("idassetconsignsub", typeof(int),false);
	tassetconsignsub.defineColumn("idassetload", typeof(int),false);
	tassetconsignsub.defineColumn("idassetloadkind", typeof(int));
	tassetconsignsub.defineColumn("idassetloadsub", typeof(int),false);
	tassetconsignsub.defineColumn("idinventorykind", typeof(int));
	tassetconsignsub.defineColumn("idman", typeof(int),false);
	tassetconsignsub.defineColumn("idman_sub", typeof(int));
	tassetconsignsub.defineColumn("idsubstate", typeof(int));
	tassetconsignsub.defineColumn("lt", typeof(DateTime));
	tassetconsignsub.defineColumn("lu", typeof(string));
	Tables.Add(tassetconsignsub);
	tassetconsignsub.defineKey("idassetconsignsub", "idassetload", "idassetloadsub");

	#endregion


	#region DataRelation creation
	var cPar = new []{assetconsignsub.Columns["idassetconsignsub"], assetconsignsub.Columns["idassetload"], assetconsignsub.Columns["idassetloadsub"]};
	var cChild = new []{assetconsignsubasset.Columns["idassetconsignsub"], assetconsignsubasset.Columns["idassetload"], assetconsignsubasset.Columns["idassetloadsub"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_assetconsignsub_idassetconsignsub-idassetload-idassetloadsub",cPar,cChild,false));

	cPar = new []{assetacquire_alias2.Columns["nassetacquire"]};
	cChild = new []{assetconsignsubasset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_assetacquire_alias2_nassetacquire",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{assetacquire_alias2.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_assetacquire_alias2_upb_idupb",cPar,cChild,false));

	cPar = new []{inventorytree_alias1.Columns["idinv"]};
	cChild = new []{assetacquire_alias2.Columns["idinv"]};
	Relations.Add(new DataRelation("FK_assetacquire_alias2_inventorytree_alias1_idinv",cPar,cChild,false));

	cPar = new []{asset_alias2.Columns["idpiece"]};
	cChild = new []{assetconsignsubasset.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_asset_alias2_idpiece",cPar,cChild,false));

	cPar = new []{assetacquire_alias1.Columns["nassetacquire"]};
	cChild = new []{asset_alias2.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("FK_asset_alias2_assetacquire_alias1_nassetacquire",cPar,cChild,false));

	cPar = new []{inventory_alias2.Columns["idinventory"]};
	cChild = new []{asset_alias2.Columns["idinventory"]};
	Relations.Add(new DataRelation("FK_asset_alias2_inventory_alias2_idinventory",cPar,cChild,false));

	cPar = new []{location.Columns["idlocation"]};
	cChild = new []{assetconsignsubasset.Columns["idlocation"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_location_idlocation",cPar,cChild,false));

	cPar = new []{inventory_alias1.Columns["idinventory"]};
	cChild = new []{assetconsignsubasset.Columns["idinventory"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_inventory_alias1_idinventory",cPar,cChild,false));

	cPar = new []{inventorytree.Columns["idinv"]};
	cChild = new []{assetconsignsubasset.Columns["idinv"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_inventorytree_idinv",cPar,cChild,false));

	cPar = new []{assetlocation.Columns["idassetlocation"]};
	cChild = new []{assetconsignsubasset.Columns["idassetlocation"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_assetlocation_idassetlocation",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"]};
	cChild = new []{assetconsignsubasset.Columns["idasset"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_asset_idasset",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("FK_asset_assetacquire_nassetacquire",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{asset.Columns["idinventory"]};
	Relations.Add(new DataRelation("FK_asset_inventory_idinventory",cPar,cChild,false));

	cPar = new []{manager_alias1.Columns["idman"]};
	cChild = new []{assetconsignsub.Columns["idman_sub"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_manager_alias1_idman_sub",cPar,cChild,false));

	cPar = new []{substate.Columns["idsubstate"]};
	cChild = new []{assetconsignsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_substate_idsubstate",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{assetconsignsub.Columns["idman"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_manager_idman",cPar,cChild,false));

	cPar = new []{inventorykind.Columns["idinventorykind"]};
	cChild = new []{assetconsignsub.Columns["idinventorykind"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_inventorykind_idinventorykind",cPar,cChild,false));

	#endregion

}
}
}
