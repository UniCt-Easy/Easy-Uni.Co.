
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
[System.Xml.Serialization.XmlRoot("dsmeta_subassetloadsub_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_subassetloadsub_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable substate 		=> (MetaTable)Tables["substate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventoryagency 		=> (MetaTable)Tables["inventoryagency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetconsignee 		=> (MetaTable)Tables["assetconsignee"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloadkind 		=> (MetaTable)Tables["assetloadkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetload 		=> (MetaTable)Tables["assetload"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetloadsub 		=> (MetaTable)Tables["assetloadsub"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable subassetloadsubassetloadsub 		=> (MetaTable)Tables["subassetloadsubassetloadsub"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable manager 		=> (MetaTable)Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable subassetloadsub 		=> (MetaTable)Tables["subassetloadsub"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_subassetloadsub_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_subassetloadsub_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_subassetloadsub_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_subassetloadsub_default.xsd";

	#region create DataTables
	//////////////////// SUBSTATE /////////////////////////////////
	var tsubstate= new MetaTable("substate");
	tsubstate.defineColumn("description", typeof(string));
	tsubstate.defineColumn("idsubstate", typeof(int),false);
	Tables.Add(tsubstate);
	tsubstate.defineKey("idsubstate");

	//////////////////// INVENTORYAGENCY /////////////////////////////////
	var tinventoryagency= new MetaTable("inventoryagency");
	tinventoryagency.defineColumn("active", typeof(string));
	tinventoryagency.defineColumn("description", typeof(string),false);
	tinventoryagency.defineColumn("idinventoryagency", typeof(int),false);
	Tables.Add(tinventoryagency);
	tinventoryagency.defineKey("idinventoryagency");

	//////////////////// ASSETCONSIGNEE /////////////////////////////////
	var tassetconsignee= new MetaTable("assetconsignee");
	tassetconsignee.defineColumn("active", typeof(string));
	tassetconsignee.defineColumn("idinventoryagency", typeof(int),false);
	tassetconsignee.defineColumn("idman", typeof(int));
	tassetconsignee.defineColumn("start", typeof(DateTime),false);
	tassetconsignee.defineColumn("title", typeof(string));
	Tables.Add(tassetconsignee);
	tassetconsignee.defineKey("idinventoryagency", "start");

	//////////////////// ASSETLOADKIND /////////////////////////////////
	var tassetloadkind= new MetaTable("assetloadkind");
	tassetloadkind.defineColumn("active", typeof(string));
	tassetloadkind.defineColumn("codeassetloadkind", typeof(string),false);
	tassetloadkind.defineColumn("description", typeof(string),false);
	tassetloadkind.defineColumn("idassetloadkind", typeof(int),false);
	Tables.Add(tassetloadkind);
	tassetloadkind.defineKey("idassetloadkind");

	//////////////////// ASSETLOAD /////////////////////////////////
	var tassetload= new MetaTable("assetload");
	tassetload.defineColumn("description", typeof(string));
	tassetload.defineColumn("idassetload", typeof(int),false);
	tassetload.defineColumn("idassetloadkind", typeof(int),false);
	tassetload.defineColumn("nassetload", typeof(int),false);
	tassetload.defineColumn("yassetload", typeof(int),false);
	Tables.Add(tassetload);
	tassetload.defineKey("idassetload");

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
	tassetloadsub.defineColumn("!idassetload_assetload_yassetload", typeof(int));
	tassetloadsub.defineColumn("!idassetload_assetload_nassetload", typeof(int));
	tassetloadsub.defineColumn("!idassetload_assetload_description", typeof(string));
	tassetloadsub.defineColumn("!idassetload_assetload_idassetloadkind_codeassetloadkind", typeof(string));
	tassetloadsub.defineColumn("!idassetload_assetload_idassetloadkind_description", typeof(string));
	tassetloadsub.defineColumn("!idman_assetconsignee_title", typeof(string));
	tassetloadsub.defineColumn("!idman_assetconsignee_active", typeof(string));
	tassetloadsub.defineColumn("!idman_assetconsignee_idman_title", typeof(string));
	tassetloadsub.defineColumn("!idman_assetconsignee_idinventoryagency_description", typeof(string));
	tassetloadsub.defineColumn("!idsubstate_substate_description", typeof(string));
	Tables.Add(tassetloadsub);
	tassetloadsub.defineKey("idassetload", "idassetloadsub");

	//////////////////// SUBASSETLOADSUBASSETLOADSUB /////////////////////////////////
	var tsubassetloadsubassetloadsub= new MetaTable("subassetloadsubassetloadsub");
	tsubassetloadsubassetloadsub.defineColumn("idassetloadsub", typeof(int),false);
	tsubassetloadsubassetloadsub.defineColumn("idsubassetloadsub", typeof(int),false);
	Tables.Add(tsubassetloadsubassetloadsub);
	tsubassetloadsubassetloadsub.defineKey("idassetloadsub", "idsubassetloadsub");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new MetaTable("manager");
	tmanager.defineColumn("active", typeof(string));
	tmanager.defineColumn("idman", typeof(int),false);
	tmanager.defineColumn("title", typeof(string),false);
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// SUBASSETLOADSUB /////////////////////////////////
	var tsubassetloadsub= new MetaTable("subassetloadsub");
	tsubassetloadsub.defineColumn("idman", typeof(int));
	tsubassetloadsub.defineColumn("idsubassetloadsub", typeof(int),false);
	Tables.Add(tsubassetloadsub);
	tsubassetloadsub.defineKey("idsubassetloadsub");

	#endregion


	#region DataRelation creation
	var cPar = new []{subassetloadsub.Columns["idsubassetloadsub"]};
	var cChild = new []{subassetloadsubassetloadsub.Columns["idsubassetloadsub"]};
	Relations.Add(new DataRelation("FK_subassetloadsubassetloadsub_subassetloadsub_idsubassetloadsub",cPar,cChild,false));

	cPar = new []{assetloadsub.Columns["idassetloadsub"]};
	cChild = new []{subassetloadsubassetloadsub.Columns["idassetloadsub"]};
	Relations.Add(new DataRelation("FK_subassetloadsubassetloadsub_assetloadsub_idassetloadsub",cPar,cChild,false));

	cPar = new []{substate.Columns["idsubstate"]};
	cChild = new []{assetloadsub.Columns["idsubstate"]};
	Relations.Add(new DataRelation("FK_assetloadsub_substate_idsubstate",cPar,cChild,false));

	cPar = new []{assetconsignee.Columns["idman"]};
	cChild = new []{assetloadsub.Columns["idman"]};
	Relations.Add(new DataRelation("FK_assetloadsub_assetconsignee_idman",cPar,cChild,false));

	cPar = new []{inventoryagency.Columns["idinventoryagency"]};
	cChild = new []{assetconsignee.Columns["idinventoryagency"]};
	Relations.Add(new DataRelation("FK_assetconsignee_inventoryagency_idinventoryagency",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{assetconsignee.Columns["idman"]};
	Relations.Add(new DataRelation("FK_assetconsignee_manager_idman",cPar,cChild,false));

	cPar = new []{assetload.Columns["idassetload"]};
	cChild = new []{assetloadsub.Columns["idassetload"]};
	Relations.Add(new DataRelation("FK_assetloadsub_assetload_idassetload",cPar,cChild,false));

	cPar = new []{assetloadkind.Columns["idassetloadkind"]};
	cChild = new []{assetload.Columns["idassetloadkind"]};
	Relations.Add(new DataRelation("FK_assetload_assetloadkind_idassetloadkind",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{subassetloadsub.Columns["idman"]};
	Relations.Add(new DataRelation("FK_subassetloadsub_manager_idman",cPar,cChild,false));

	#endregion

}
}
}
