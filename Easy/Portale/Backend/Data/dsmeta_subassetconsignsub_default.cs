
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
[System.Xml.Serialization.XmlRoot("dsmeta_subassetconsignsub_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_subassetconsignsub_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable substate 		=> (MetaTable)Tables["substate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager_alias1 		=> (MetaTable)Tables["manager_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorykind 		=> (MetaTable)Tables["inventorykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloadkind 		=> (MetaTable)Tables["assetloadkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsignsub 		=> (MetaTable)Tables["assetconsignsub"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable subassetconsignsubassetconsignsub 		=> (MetaTable)Tables["subassetconsignsubassetconsignsub"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager 		=> (MetaTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable subassetconsignsub 		=> (MetaTable)Tables["subassetconsignsub"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_subassetconsignsub_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_subassetconsignsub_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_subassetconsignsub_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_subassetconsignsub_default.xsd";

	#region create DataTables
	//////////////////// SUBSTATE /////////////////////////////////
	var tsubstate= new MetaTable("substate");
	tsubstate.defineColumn("description", typeof(string));
	tsubstate.defineColumn("idsubstate", typeof(int),false);
	Tables.Add(tsubstate);
	tsubstate.defineKey("idsubstate");

	//////////////////// MANAGER_ALIAS1 /////////////////////////////////
	var tmanager_alias1= new MetaTable("manager_alias1");
	tmanager_alias1.defineColumn("active", typeof(string));
	tmanager_alias1.defineColumn("idman", typeof(int),false);
	tmanager_alias1.defineColumn("title", typeof(string),false);
	tmanager_alias1.ExtendedProperties["TableForReading"]="manager";
	Tables.Add(tmanager_alias1);
	tmanager_alias1.defineKey("idman");

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

	//////////////////// SUBASSETCONSIGNSUBASSETCONSIGNSUB /////////////////////////////////
	var tsubassetconsignsubassetconsignsub= new MetaTable("subassetconsignsubassetconsignsub");
	tsubassetconsignsubassetconsignsub.defineColumn("idassetconsignsub", typeof(int),false);
	tsubassetconsignsubassetconsignsub.defineColumn("idsubassetconsignsub", typeof(int),false);
	Tables.Add(tsubassetconsignsubassetconsignsub);
	tsubassetconsignsubassetconsignsub.defineKey("idassetconsignsub", "idsubassetconsignsub");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new MetaTable("manager");
	tmanager.defineColumn("active", typeof(string));
	tmanager.defineColumn("idman", typeof(int),false);
	tmanager.defineColumn("title", typeof(string),false);
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// SUBASSETCONSIGNSUB /////////////////////////////////
	var tsubassetconsignsub= new MetaTable("subassetconsignsub");
	tsubassetconsignsub.defineColumn("idman_sub", typeof(int));
	tsubassetconsignsub.defineColumn("idsubassetconsignsub", typeof(int),false);
	Tables.Add(tsubassetconsignsub);
	tsubassetconsignsub.defineKey("idsubassetconsignsub");

	#endregion


	#region DataRelation creation
	var cPar = new []{subassetconsignsub.Columns["idsubassetconsignsub"]};
	var cChild = new []{subassetconsignsubassetconsignsub.Columns["idsubassetconsignsub"]};
	Relations.Add(new DataRelation("FK_subassetconsignsubassetconsignsub_subassetconsignsub_idsubassetconsignsub",cPar,cChild,false));

	cPar = new []{assetconsignsub.Columns["idassetconsignsub"]};
	cChild = new []{subassetconsignsubassetconsignsub.Columns["idassetconsignsub"]};
	Relations.Add(new DataRelation("FK_subassetconsignsubassetconsignsub_assetconsignsub_idassetconsignsub",cPar,cChild,false));

	cPar = new []{substate.Columns["idsubstate"]};
	cChild = new []{assetconsignsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_assetconsignsub_substate_idsubstate",cPar,cChild,false));

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

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{subassetconsignsub.Columns["idman_sub"]};
	Relations.Add(new DataRelation("FK_subassetconsignsub_manager_idman_sub",cPar,cChild,false));

	#endregion

}
}
}
