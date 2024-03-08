
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
[System.Xml.Serialization.XmlRoot("dsmeta_assetloadsub_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_assetloadsub_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable substate_alias2 		=> (MetaTable)Tables["substate_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager_alias2 		=> (MetaTable)Tables["manager_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable logassetloadsub 		=> (MetaTable)Tables["logassetloadsub"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsignsubasset 		=> (MetaTable)Tables["assetconsignsubasset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable substate_alias1 		=> (MetaTable)Tables["substate_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager_alias1 		=> (MetaTable)Tables["manager_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager 		=> (MetaTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorykind 		=> (MetaTable)Tables["inventorykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloadkind 		=> (MetaTable)Tables["assetloadkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsignsub 		=> (MetaTable)Tables["assetconsignsub"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsigneedefaultview 		=> (MetaTable)Tables["assetconsigneedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable substate 		=> (MetaTable)Tables["substate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloaddefaultview 		=> (MetaTable)Tables["assetloaddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloadsub 		=> (MetaTable)Tables["assetloadsub"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_assetloadsub_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_assetloadsub_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_assetloadsub_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_assetloadsub_default.xsd";

	#region create DataTables
	//////////////////// SUBSTATE_ALIAS2 /////////////////////////////////
	var tsubstate_alias2= new MetaTable("substate_alias2");
	tsubstate_alias2.defineColumn("description", typeof(string));
	tsubstate_alias2.defineColumn("idsubstate", typeof(int),false);
	tsubstate_alias2.ExtendedProperties["TableForReading"]="substate";
	Tables.Add(tsubstate_alias2);
	tsubstate_alias2.defineKey("idsubstate");

	//////////////////// MANAGER_ALIAS2 /////////////////////////////////
	var tmanager_alias2= new MetaTable("manager_alias2");
	tmanager_alias2.defineColumn("active", typeof(string));
	tmanager_alias2.defineColumn("idman", typeof(int),false);
	tmanager_alias2.defineColumn("title", typeof(string),false);
	tmanager_alias2.ExtendedProperties["TableForReading"]="manager";
	Tables.Add(tmanager_alias2);
	tmanager_alias2.defineKey("idman");

	//////////////////// LOGASSETLOADSUB /////////////////////////////////
	var tlogassetloadsub= new MetaTable("logassetloadsub");
	tlogassetloadsub.defineColumn("ct", typeof(DateTime));
	tlogassetloadsub.defineColumn("cu", typeof(string));
	tlogassetloadsub.defineColumn("idassetloadsub", typeof(int),false);
	tlogassetloadsub.defineColumn("idlogassetloadsub", typeof(int),false);
	tlogassetloadsub.defineColumn("idman", typeof(int));
	tlogassetloadsub.defineColumn("idsubstate", typeof(int),false);
	tlogassetloadsub.defineColumn("lt", typeof(DateTime));
	tlogassetloadsub.defineColumn("lu", typeof(string));
	tlogassetloadsub.defineColumn("timestamp", typeof(DateTime),false);
	tlogassetloadsub.defineColumn("!idman_manager_title", typeof(string));
	tlogassetloadsub.defineColumn("!idsubstate_substate_description", typeof(string));
	tlogassetloadsub.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tlogassetloadsub);
	tlogassetloadsub.defineKey("idassetloadsub", "idlogassetloadsub");

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
	Tables.Add(tassetconsignsubasset);
	tassetconsignsubasset.defineKey("idassetconsignsub", "idassetconsignsubasset", "idassetload", "idassetloadsub");

	//////////////////// SUBSTATE_ALIAS1 /////////////////////////////////
	var tsubstate_alias1= new MetaTable("substate_alias1");
	tsubstate_alias1.defineColumn("description", typeof(string));
	tsubstate_alias1.defineColumn("idsubstate", typeof(int),false);
	tsubstate_alias1.ExtendedProperties["TableForReading"]="substate";
	Tables.Add(tsubstate_alias1);
	tsubstate_alias1.defineKey("idsubstate");

	//////////////////// MANAGER_ALIAS1 /////////////////////////////////
	var tmanager_alias1= new MetaTable("manager_alias1");
	tmanager_alias1.defineColumn("active", typeof(string));
	tmanager_alias1.defineColumn("idman", typeof(int),false);
	tmanager_alias1.defineColumn("title", typeof(string),false);
	tmanager_alias1.ExtendedProperties["TableForReading"]="manager";
	Tables.Add(tmanager_alias1);
	tmanager_alias1.defineKey("idman");

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
	tinventorykind.defineColumn("description", typeof(string),false);
	tinventorykind.defineColumn("idinventorykind", typeof(int),false);
	Tables.Add(tinventorykind);
	tinventorykind.defineKey("idinventorykind");

	//////////////////// ASSETLOADKIND /////////////////////////////////
	var tassetloadkind= new MetaTable("assetloadkind");
	tassetloadkind.defineColumn("active", typeof(string));
	tassetloadkind.defineColumn("codeassetloadkind", typeof(string),false);
	tassetloadkind.defineColumn("description", typeof(string),false);
	tassetloadkind.defineColumn("idassetloadkind", typeof(int),false);
	Tables.Add(tassetloadkind);
	tassetloadkind.defineKey("idassetloadkind");

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
	tassetconsignsub.defineColumn("!idassetloadkind_assetloadkind_codeassetloadkind", typeof(string));
	tassetconsignsub.defineColumn("!idassetloadkind_assetloadkind_description", typeof(string));
	tassetconsignsub.defineColumn("!idinventorykind_inventorykind_description", typeof(string));
	tassetconsignsub.defineColumn("!idman_manager_title", typeof(string));
	tassetconsignsub.defineColumn("!idman_sub_manager_title", typeof(string));
	tassetconsignsub.defineColumn("!idsubstate_substate_description", typeof(string));
	Tables.Add(tassetconsignsub);
	tassetconsignsub.defineKey("idassetconsignsub", "idassetload", "idassetloadsub");

	//////////////////// ASSETCONSIGNEEDEFAULTVIEW /////////////////////////////////
	var tassetconsigneedefaultview= new MetaTable("assetconsigneedefaultview");
	tassetconsigneedefaultview.defineColumn("assetconsignee_active", typeof(string));
	tassetconsigneedefaultview.defineColumn("assetconsignee_lt", typeof(DateTime));
	tassetconsigneedefaultview.defineColumn("assetconsignee_lu", typeof(string));
	tassetconsigneedefaultview.defineColumn("assetconsignee_qualification", typeof(string));
	tassetconsigneedefaultview.defineColumn("assetconsignee_title", typeof(string));
	tassetconsigneedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tassetconsigneedefaultview.defineColumn("idinventoryagency", typeof(int),false);
	tassetconsigneedefaultview.defineColumn("idman", typeof(int));
	tassetconsigneedefaultview.defineColumn("manager_title", typeof(string));
	tassetconsigneedefaultview.defineColumn("start", typeof(DateTime),false);
	Tables.Add(tassetconsigneedefaultview);
	tassetconsigneedefaultview.defineKey("idinventoryagency", "start");

	//////////////////// SUBSTATE /////////////////////////////////
	var tsubstate= new MetaTable("substate");
	tsubstate.defineColumn("description", typeof(string));
	tsubstate.defineColumn("idsubstate", typeof(int),false);
	Tables.Add(tsubstate);
	tsubstate.defineKey("idsubstate");

	//////////////////// ASSETLOADDEFAULTVIEW /////////////////////////////////
	var tassetloaddefaultview= new MetaTable("assetloaddefaultview");
	tassetloaddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tassetloaddefaultview.defineColumn("idassetload", typeof(int),false);
	Tables.Add(tassetloaddefaultview);
	tassetloaddefaultview.defineKey("idassetload");

	//////////////////// ASSETLOADSUB /////////////////////////////////
	var tassetloadsub= new MetaTable("assetloadsub");
	tassetloadsub.defineColumn("ct", typeof(DateTime));
	tassetloadsub.defineColumn("cu", typeof(string));
	tassetloadsub.defineColumn("idassetload", typeof(int),false);
	tassetloadsub.defineColumn("idassetloadsub", typeof(int),false);
	tassetloadsub.defineColumn("idman", typeof(int));
	tassetloadsub.defineColumn("idsubstate", typeof(int));
	tassetloadsub.defineColumn("lt", typeof(DateTime));
	tassetloadsub.defineColumn("lu", typeof(string));
	Tables.Add(tassetloadsub);
	tassetloadsub.defineKey("idassetload", "idassetloadsub");

	#endregion


	#region DataRelation creation
	var cPar = new []{assetloadsub.Columns["idassetloadsub"], assetloadsub.Columns["idman"], assetloadsub.Columns["idsubstate"]};
	var cChild = new []{logassetloadsub.Columns["idassetloadsub"], logassetloadsub.Columns["idman"], logassetloadsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_logassetloadsub_assetloadsub_idassetloadsub-idman-idsubstate",cPar,cChild,false));

	cPar = new []{substate_alias2.Columns["idsubstate"]};
	cChild = new []{logassetloadsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_logassetloadsub_substate_alias2_idsubstate",cPar,cChild,false));

	cPar = new []{manager_alias2.Columns["idman"]};
	cChild = new []{logassetloadsub.Columns["idman"]};
	Relations.Add(new DataRelation("FK_logassetloadsub_manager_alias2_idman",cPar,cChild,false));

	cPar = new []{assetloadsub.Columns["idassetload"], assetloadsub.Columns["idassetloadsub"]};
	cChild = new []{assetconsignsub.Columns["idassetload"], assetconsignsub.Columns["idassetloadsub"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_assetloadsub_idassetload-idassetloadsub",cPar,cChild,false));

	cPar = new []{assetconsignsub.Columns["idassetconsignsub"], assetconsignsub.Columns["idassetload"], assetconsignsub.Columns["idassetloadsub"]};
	cChild = new []{assetconsignsubasset.Columns["idassetconsignsub"], assetconsignsubasset.Columns["idassetload"], assetconsignsubasset.Columns["idassetloadsub"]};
	Relations.Add(new DataRelation("FK_assetconsignsubasset_assetconsignsub_idassetconsignsub-idassetload-idassetloadsub",cPar,cChild,false));

	cPar = new []{substate_alias1.Columns["idsubstate"]};
	cChild = new []{assetconsignsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_substate_alias1_idsubstate",cPar,cChild,false));

	cPar = new []{manager_alias1.Columns["idman"]};
	cChild = new []{assetconsignsub.Columns["idman_sub"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_manager_alias1_idman_sub",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{assetconsignsub.Columns["idman"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_manager_idman",cPar,cChild,false));

	cPar = new []{inventorykind.Columns["idinventorykind"]};
	cChild = new []{assetconsignsub.Columns["idinventorykind"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_inventorykind_idinventorykind",cPar,cChild,false));

	cPar = new []{assetloadkind.Columns["idassetloadkind"]};
	cChild = new []{assetconsignsub.Columns["idassetloadkind"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_assetloadkind_idassetloadkind",cPar,cChild,false));

	cPar = new []{assetconsigneedefaultview.Columns["idman"]};
	cChild = new []{assetloadsub.Columns["idman"]};
	Relations.Add(new DataRelation("FK_assetloadsub_assetconsigneedefaultview_idman",cPar,cChild,false));

	cPar = new []{substate.Columns["idsubstate"]};
	cChild = new []{assetloadsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_assetloadsub_substate_idsubstate",cPar,cChild,false));

	cPar = new []{assetloaddefaultview.Columns["idassetload"]};
	cChild = new []{assetloadsub.Columns["idassetload"]};
	Relations.Add(new DataRelation("FK_assetloadsub_assetloaddefaultview_idassetload",cPar,cChild,false));

	#endregion

}
}
}
